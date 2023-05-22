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
using iKandi.BLL;
using iKandi.Common;
using iKandi.Web.Components;
using System.Collections.Generic;


namespace iKandi.Web.UserControls.Lists
{
    public partial class Prints : BaseUserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindControls();
            }
        }

        private void BindControls()
        {
            if (!IsPostBack)
            {
                BindBuyingHouse();
                DropdownHelper.BindAllClients(ddlClients);
                DropdownHelper.BindAllPrintTypes(ddlPrintType as ListControl);

                BindDept(ddlClients.SelectedIndex);
            }

            int TotalRowCount = 0;
            int intID = Convert.ToInt32(ddlBuyingHouse.SelectedValue);
            int ChildDeptID;
            if (ddlPrintDepartment.SelectedValue == "All" || ddlPrintDepartment.SelectedValue == "")
                ChildDeptID = -1;
            else
                ChildDeptID = Convert.ToInt16(ddlPrintDepartment.SelectedValue);


            if (ddlDepts.SelectedValue == "All" || ddlDepts.SelectedValue == "-1")
                hdnDDLDepartment.Value = Convert.ToString("-1");
            else
                hdnDDLDepartment.Value = Convert.ToString(ddlDepts.SelectedValue);

            int PrintCategory = Convert.ToInt16(ddlPrintCategory.SelectedValue);

            List<Print> objPrints = this.PrintControllerInstance.GetAllPrintsBuyingHouseBAL(out TotalRowCount, Convert.ToInt32(ddlClients.SelectedValue), txtSearch.Text, Convert.ToInt32(ddlPrintType.SelectedValue), PrintCategory, intID, Convert.ToInt32(hdnDDLDepartment.Value), ChildDeptID);
            Session["Paging"] = objPrints;
            grdPrint.DataSource = objPrints;
            grdPrint.DataBind();
        }

        public void BindBuyingHouse()
        {
            DataTable dt = new DataTable();
            dt = this.PrintControllerInstance.GetAllBuyingHouseBAL();
            ddlBuyingHouse.DataSource = dt;
            ddlBuyingHouse.DataTextField = "CompanyName";
            ddlBuyingHouse.DataValueField = "ID";
            ddlBuyingHouse.DataBind();
        }

        protected void ddlDepts_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindChildClientDept();
        }

        public void BindChildClientDept()
        {
            StyleController objstyle = new StyleController();

            if (ddlClients.SelectedValue != "-1")
            {
                List<Client> BindDeptListAgainstCliets = objstyle.BindDeptListAgainstParentDeptWithFlag(Convert.ToInt32(ApplicationHelper.LoggedInUser.UserData.UserID), Convert.ToInt32(ddlClients.SelectedValue), Convert.ToInt32(0), Convert.ToInt32(ddlDepts.SelectedValue), "CHILDDEPTPRINT");

                if (BindDeptListAgainstCliets.Count > 0)
                {
                    ddlPrintDepartment.Items.Clear();
                    ddlPrintDepartment.DataSource = BindDeptListAgainstCliets;
                    ddlPrintDepartment.DataTextField = "CompanyName";
                    ddlPrintDepartment.DataValueField = "ClientID";
                    ddlPrintDepartment.DataBind();
                }
            }
            else
            {
                ddlPrintDepartment.Items.Clear();
                ddlPrintDepartment.Items.Insert(0, "All");
            }
        }

        protected void ddlClients_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindDept(0);
        }

        public void BIndParentDll()
        {
            ClientController objClientController = new ClientController();
            int DeptID = 0;
            if (ddlDepts.SelectedValue != "All" && ddlDepts.SelectedValue != "")
            {
                DeptID = Convert.ToInt32(ddlDepts.SelectedValue);
            }
            if (ddlClients.SelectedValue != "-1")
            {
                List<Client> BindDeptListAgainstCliets = this.AdminControllerInstance.BindDeptListAgainstParentDept(Convert.ToInt32(ApplicationHelper.LoggedInUser.UserData.UserID), Convert.ToInt32(ddlClients.SelectedValue), Convert.ToInt32(0), DeptID);
                if (BindDeptListAgainstCliets.Count > 0)
                {
                    ddlDepts.Items.Clear();
                    ddlDepts.DataSource = BindDeptListAgainstCliets;
                    ddlDepts.DataTextField = "CompanyName";
                    ddlDepts.DataValueField = "ClientID";
                    ddlDepts.DataBind();
                }
            }
            else
            {
                ddlDepts.Items.Clear();
                ddlDepts.Items.Insert(0, "All");
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {            
            BindControls();

        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.DataRow)
                return;
            Print p = (e.Row.DataItem as Print);

            Label lblstatus = e.Row.FindControl("lblstatus") as Label;
            if (p.Status == PrintStatus.Sold)
            {
                (lblstatus.Parent as TableCell).Style.Add("background-color", "#ffa500");

            }
            else
            {
                (lblstatus.Parent as TableCell).Style.Add("background-color", "#009000");                
                lblstatus.Style.Add("color", "#e4d2d2");
            }


            Label lblCurrency = e.Row.FindControl("lblCurrency") as Label;
            lblCurrency.Text = Constants.GetCurrencySign(Enum.GetName(typeof(Currency), p.PrintCostCurrency));

        }

        public void BindClient(int intID)
        {
            DataTable dt = new DataTable();
            dt = this.PrintControllerInstance.GetAllClientForBuyingHouseBAL(intID, 0);
            ddlClients.DataSource = dt;
            ddlClients.DataTextField = "companyname";
            ddlClients.DataValueField = "ClientId";
            ddlClients.DataBind();
        }

        public void BindDept(int clientId)
        {
            DataTable dt = new DataTable();
            dt = this.PrintControllerInstance.GetAllDeptForClient(Convert.ToInt32(ddlClients.SelectedValue));
            ddlDepts.DataSource = dt;
            ddlDepts.DataTextField = "DEPARTMENTNAME";
            ddlDepts.DataValueField = "ID";
            ddlDepts.DataBind();

            ddlPrintDepartment.Items.Clear();
            ddlPrintDepartment.Items.Insert(0, "All");            
        }

        protected void ddlBuyingHouse_SelectedIndexChanged(object sender, EventArgs e)
        {
            int intID = Convert.ToInt32(ddlBuyingHouse.SelectedValue);
            BindClient(intID);
            BindDept(0);
            BindChildClientDept();
        }

        protected void grdPrint_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdPrint.PageIndex = e.NewPageIndex;

            if (null != Session["Paging"])
            {
                grdPrint.DataSource = Session["Paging"];
                grdPrint.DataBind();
            }
            else BindControls();

           
        }

    }
}