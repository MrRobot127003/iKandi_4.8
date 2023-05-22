using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using iKandi.Common;
using iKandi.Web.Components;
using iKandi.BLL;

namespace iKandi.Web.Admin
{
    public partial class ClientAssociation : System.Web.UI.Page
    {
        AdminController AdminControllerInstance = new AdminController();

        public int ID { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["Modeid"] != null)
            {
                ID = Convert.ToInt32(Request.QueryString["Modeid"].ToString());
            }

            if (!IsPostBack)
            {
                BindClientData(ID);
            }
        }

        protected void BtnSaveClientAssoc_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["Modeid"] != null)
            {
                string SelectedChkList = string.Empty;
                int id;
                if (chkClientAssociation.Items.Count > 0)
                {
                    for (int i = 0; i < chkClientAssociation.Items.Count; i++)
                    {
                        if (chkClientAssociation.Items[i].Selected)
                        {
                            SelectedChkList += chkClientAssociation.Items[i].Value + ",";
                        }
                    }
                }
                id = Convert.ToInt32(Request.QueryString["Modeid"].ToString());
                AdminControllerInstance.UpdateDeliveryModesAssociation(id, SelectedChkList);
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('Saved Successfully !!'); CloseWin();", true);
            }
        }

        public void BindClientData(int Modeid)
        {
            DataSet ds = new DataSet();
            string[] Findbytextvalue = null;
            ds = AdminControllerInstance.GetClientlist(ID);
            DataTable dt = ds.Tables[10];
            string mapping = dt.Rows[0]["ClintMapping"].ToString();
            lblModeName.Text = dt.Rows[0]["Code"].ToString();
            Findbytextvalue = mapping.Split(',');
            chkClientAssociation.DataTextField = "clientcode";
            chkClientAssociation.DataValueField = "clientid";
            chkClientAssociation.DataSource = ds.Tables[0];
            chkClientAssociation.DataBind();

            for (int i = 0; i < Findbytextvalue.Length - 1; i++)
            {
                bool chkexist = false;
                foreach (ListItem li in chkClientAssociation.Items)
                {
                    if (li.Value == Findbytextvalue[i].ToString()) { chkexist = true; break; } else { chkexist = false; }
                }
                if (chkexist && !string.IsNullOrEmpty(Findbytextvalue[i].ToString()))
                {
                    chkClientAssociation.Items.FindByValue(Findbytextvalue[i].ToString()).Selected = true;
                }
            }
        }

        protected void chkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSelectAll.Checked)
            {

                foreach (ListItem li in chkClientAssociation.Items)
                {
                    li.Selected = true;


                }
            }
            else
            {

                foreach (ListItem li in chkClientAssociation.Items)
                {
                    li.Selected = false;

                }
            }

        }
    }
}