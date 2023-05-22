using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iKandi.Web.Components;
using iKandi.Common;
using iKandi.BLL;

namespace iKandi.Web.UserControls.Reports
{
    public partial class StyleDigitalInfo :BaseUserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DropdownHelper.BindBuyingHouse(ddlBuyingHouse);
                DropdownHelper.FillDropDownClient(ddlClient, Convert.ToInt32(ddlBuyingHouse.SelectedValue),true,0);
            }
        }

        private void MsgBox(string DisplayMessage)
        {
            string script = string.Empty;
            script = "alert('" + DisplayMessage + "');";
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "ShowMessage", script, true);
        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            if (ddlBuyingHouse.SelectedIndex < 0)
            {
                MsgBox("Please Select Buying House.");
                return;
            }
            if (ddlClient.SelectedIndex < 0)
            {
                MsgBox("Please Select Client.");
                return;
            }
            if (txtFrom.Text == "" || txtTo.Text == "")
            {
                MsgBox("Invalid Date Range.");
                return;
            }
            int iDateType = (rdoExfactory.Checked == true) ? 1 : 2;
            PDFController PDfCon = new PDFController();
            DateTime dtfrom = DateHelper.ParseDate(txtFrom.Text).Value;
            DateTime dtTo=DateHelper.ParseDate(txtTo.Text).Value;
            string ClientList = string.Empty;
            if (ddlClient.Items[0].Selected == true)
            {
                ClientList = "-1";
            }
            if (ClientList != "-1")
            {
                for (int i = 0; i <= ddlClient.Items.Count - 1; i++)
                {

                    if (ddlClient.Items[i].Selected == true)
                    {
                        ClientList += (ClientList == "") ? ddlClient.Items[i].Value.ToString() : "," + ddlClient.Items[i].Value.ToString();
                    }
                }
            }
            string PDFPath = PDfCon.GenerateStyleDigitalInfo(ClientList, iDateType, dtfrom, dtTo);
            if (PDFPath != "")
                this.RenderFile(PDFPath, "StyleDigitalInfo.PDF", Constants.CONTENT_TYPE_PDF);
            else
            {
                string script = string.Empty;
                script = "ShowHideMessageBox(true, 'No Record Found.');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", script, true);
            }
        }

        protected void ddlBuyingHouse_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropdownHelper.FillDropDownClient(ddlClient, Convert.ToInt32(ddlBuyingHouse.SelectedValue),true,0);
        }
    }
}