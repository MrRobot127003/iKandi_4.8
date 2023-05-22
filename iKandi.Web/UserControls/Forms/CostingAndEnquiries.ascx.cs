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
using iKandi.Web.Components;


namespace iKandi.Web
{
    public partial class CostingAndEnquiries : BaseUserControl
    {
        List<iKandi.Common.Style> style = null;
        int ExistingStyleNumber = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindControls();
            }
        }
        protected void btnEnquiry_Click(object sender, EventArgs e)
        {
            string StyleNumber = txtStyleNumberSearch.Text;
            int IsCosted = 0;
            IsCosted = this.StyleControllerInstance.CostingEnquiryUpdateStyleFromStyleNumber(StyleNumber);
            if (IsCosted == 0)
            {
                lblerror.Visible = false;
            }
            else
            {
                lblerror.Visible = true;
            }
            BindControls();
        }

        private void BindControls()
        {


            if (ApplicationHelper.LoggedInUser.UserData.Designation == Designation.iKandi_Sales_Manager 
                || ApplicationHelper.LoggedInUser.UserData.Designation == Designation.iKandi_Sales_SalesManager)
            {
                style = this.StyleControllerInstance.CostingEnquiryGetAllStyles(1, ApplicationHelper.LoggedInUser.UserData.UserID);
                btnEnquiry.Visible = true;
            }
            else
            {
                style = this.StyleControllerInstance.CostingEnquiryGetAllStyles(2, ApplicationHelper.LoggedInUser.UserData.UserID);
            }
            grdEnquiry.DataSource = style;
            grdEnquiry.DataBind();
        }

        protected void grdEnquiry_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.DataRow)
                return;

            iKandi.Common.Style io = e.Row.DataItem as iKandi.Common.Style;

            Label lblStatus = e.Row.FindControl("lblStatus") as Label;
            (lblStatus.Parent as TableCell).BackColor = System.Drawing.ColorTranslator.FromHtml(Constants.GetStatusModeColor(io.StatusModeID));

            for (int i = 0; i < e.Row.Cells.Count; i++)
            {
                e.Row.Cells[i].CssClass = "font_color_blue";

            }

        }
    }
}