using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Collections.Generic;
using iKandi.Common;


namespace iKandi.Web.UserControls.Lists
{
    public partial class Clients : BaseUserControl
    {
        List<iKandi.Common.Client> objClients = new List<iKandi.Common.Client>();

        # region Fields
        int TotalRowCount = 0;
        # endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            //BindControls(); 
            string eventTargetbtn = (this.Request["__EVENTTARGET"] == null) ? string.Empty : this.Request["__EVENTTARGET"];
            //if (eventTargetbtn == "ChildWindowPostBack" || eventTargetbtn.Contains("GO"))
            //{

            //}
            //else { ViewState["Status"] = 1; }
            if (!IsPostBack)
            {
                BindControls(0, 0);
                BindDDLBuyingHouse();
                BindDDLClient(0);
            }
            string eventTarget = (this.Request["__EVENTTARGET"] == null) ? string.Empty : this.Request["__EVENTTARGET"];
            if (eventTarget == "ChildWindowPostBack" || eventTarget.Contains("ddlBuyingHouse"))
            {
                ViewState["Status"] = 0;
            }
            else if (Convert.ToInt32(Request.QueryString["PageIndex"]) >= 0)
            {
                ViewState["Status"] = 1;
                BindControls(Convert.ToInt32(ddlBuyingHouse.SelectedValue), Convert.ToInt32(ddlClient.SelectedValue));

            }

        }

        public void BindDDLBuyingHouse()
        {
            DataTable dt = this.PrintControllerInstance.GetAllBuyingHouseBAL();
            ddlBuyingHouse.DataSource = dt;
            ddlBuyingHouse.DataTextField = "CompanyName";
            ddlBuyingHouse.DataValueField = "ID";
            ListItem li = new ListItem();
            li.Text = "ALL";
            li.Value = "0";
            ddlBuyingHouse.Items.Insert(0, li);
            ddlBuyingHouse.DataBind();
        }

        public void BindDDLClient(int Id)
        {
            DataTable dt = this.PrintControllerInstance.GetAllClientForBuyingHouseBAL(Id, 0);

            ddlClient.DataSource = dt;
            ddlClient.DataTextField = "companyname";
            ddlClient.DataValueField = "ClientId";
            ddlClient.DataBind();
        }
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.DataRow)
                return;
            HiddenField hdnClientID = e.Row.FindControl("hdnClientID") as HiddenField;
            Label lblCountry = (Label)e.Row.FindControl("lblCountry");
            string ClientId = hdnClientID.Value;
            GridView grd = e.Row.FindControl("grdAssisment") as GridView;
            grd.DataSource = this.ClientControllerInstance.GETDepartmentByClientID(ClientId);
            grd.DataBind();

            DataSet dsCountryLists = this.ClientControllerInstance.GetCountryCodesByClientID(Convert.ToInt32(ClientId));

            if (dsCountryLists.Tables[0].Rows.Count > 0)
            {
                List<string> countryCodes=new List<string>();
                  for (int i = 0; i < dsCountryLists.Tables[0].Rows.Count; i++)
                {
                    countryCodes.Add(dsCountryLists.Tables[0].Rows[i]["CountryCodeid"].ToString());
                }
                string str = "";
                int counter = 0;
                for (int i = 0; i < countryCodes.Count(); i++)
                {
                    counter++;
                    if (counter < countryCodes.Count())
                        str += this.ClientControllerInstance.GetCountryById(countryCodes[i]) + ", ";
                    else
                        str += this.ClientControllerInstance.GetCountryById(countryCodes[i]);
                }
                lblCountry.Text = "(" + str + ")";
            }
        }

        # region Methods


        private void BindControls(int intBuyingHouseID, int intClientID)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["PageIndex"]))
            {
                this.HyperLinkPager1.PageIndex = Convert.ToInt32(Request.QueryString["PageIndex"]);
            }
            else
            {
                this.HyperLinkPager1.PageIndex = 0;
            }
            if (Convert.ToInt32(ViewState["Status"]) == 0)
            {
                objClients = this.ClientControllerInstance.GetAllClients(HyperLinkPager1.PageSize, 0, out TotalRowCount, intBuyingHouseID, intClientID);
            }
            //System.Diagnostics.Debugger.Break();
            else if (Convert.ToInt32(ViewState["btnStatus"]) == 1)
            {
                objClients = this.ClientControllerInstance.GetAllClients(HyperLinkPager1.PageSize, 0, out TotalRowCount, intBuyingHouseID, intClientID);
            }
            else
                objClients = this.ClientControllerInstance.GetAllClients(HyperLinkPager1.PageSize, (!string.IsNullOrEmpty(Request.QueryString["PageIndex"])) ? Convert.ToInt32(Request.QueryString["PageIndex"]) : 0, out TotalRowCount, intBuyingHouseID, intClientID);

            GridView1.DataSource = objClients;
            GridView1.DataBind();

            this.HyperLinkPager1.TotalRecords = TotalRowCount;
            //this.HyperLinkPager1.PageIndex = 1;
            int TotalPageCount = this.HyperLinkPager1.CalculateTotalPages();
        }

        # endregion



        protected void ddlBuyingHouse_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindDDLClient(Convert.ToInt32(ddlBuyingHouse.SelectedValue));
            HyperLinkPager1.PageIndex = 0;
            btnSave_Click(btnSave, new EventArgs()); // This btnSave Is Name Of GO Button
            HyperLinkPager1.PageIndex = 0;
            //Request.QueryString["PageIndex"].Remove(0);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            this.HyperLinkPager1.PageIndex = 0;
            ViewState["btnStatus"] = 1;
            BindControls(Convert.ToInt32(ddlBuyingHouse.SelectedValue), Convert.ToInt32(ddlClient.SelectedValue));
            this.HyperLinkPager1.PageIndex = 0;
            ViewState["btnStatus"] = 0;
        }

        protected void grdAssisment_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.DataRow)
                return;
            HiddenField hdnDeptID = e.Row.FindControl("hdnDeptID") as HiddenField;
            Repeater rptUSERLIST = e.Row.FindControl("rptUSERLIST") as Repeater;

            rptUSERLIST.DataSource = this.ClientControllerInstance.GetUserListNameByDeptID(hdnDeptID.Value);
            rptUSERLIST.DataBind();
        }

    }
}