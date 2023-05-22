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

namespace iKandi.Web.UserControls
{
    public partial class Users : BaseUserControl
    {
        List<User> objUsers = new List<User>();

        # region Fields
        int TotalRowCount = 0;
        # endregion 

        protected void Page_Load(object sender, EventArgs e)
        {
            BindControls(false);
        }
        private void BindControls(Boolean IsFirstPage)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["PageIndex"]))
            {
                this.HyperLinkPager1.PageIndex = Convert.ToInt32(Request.QueryString["PageIndex"]);
            }
            else
            {
                this.HyperLinkPager1.PageIndex = 0;
            }

            if (IsFirstPage)
            {
                this.HyperLinkPager1.PageIndex = 0;
            }
            objUsers = this.UserControllerInstance.GetAllUsers(HyperLinkPager1.PageSize, this.HyperLinkPager1.PageIndex, out TotalRowCount,txtSearchText.Text,Convert.ToInt32(ddlactiive.SelectedValue));
            grdUsers.DataSource = objUsers;
            grdUsers.DataBind();

            this.HyperLinkPager1.TotalRecords = TotalRowCount;
            int TotalPageCount = this.HyperLinkPager1.CalculateTotalPages();




        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindControls(true);
        }

        protected void grdUsers_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.DataRow)
                return;

       
            Label label = e.Row.FindControl("Label7") as Label;
            if(label.Text=="01 Jan 01 (Mon) ")
            {
                label.Text="";
            }
            Label label34 = e.Row.FindControl("Label34") as Label;
            if(label34.Text=="01 Jan 01 (Mon) ")
            {
                label34.Text="";
            }
            




        }



    }
}