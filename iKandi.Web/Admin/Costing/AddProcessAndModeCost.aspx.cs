using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using iKandi.BLL;
using System.Collections.Generic;
using iKandi.Web.Components;
using iKandi.Common;
using System.Text;
using System.Linq;
using System.Web.UI.HtmlControls;
using System.Text.RegularExpressions;
using System.Net;

namespace iKandi.Web.Admin.Costing
{
    public partial class AddProcessAndModeCost : System.Web.UI.Page
    {
        CostingContollerNew costingObj = new CostingContollerNew();
        int UserId = -1;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (iKandi.Web.Components.ApplicationHelper.LoggedInUser == null || iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData == null)
                Response.Redirect("~/public/Login.aspx");

            UserId = ApplicationHelper.LoggedInUser.UserData.UserID;
            
            if (!IsPostBack)
            {               
                getModeCost();
                getProcessCost();                
            }
        }

        private void getModeCost()
        {
            grdModeCost.DataSource = costingObj.GetModeCost(UserId,0);
            grdModeCost.DataBind();        
        }

        protected void grdModeCost_RowDataBound(object sender, GridViewRowEventArgs e)
        {
           // e.Row.Cells[2].ToolTip = "Edit";
            if ((e.Row.RowState & DataControlRowState.Edit) > 0)
            {
                TextBox txtModeCost = (TextBox)e.Row.FindControl("txtModeCost");
            }            
        }

        protected void grdModeCost_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void grdModeCost_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grdModeCost.EditIndex = e.NewEditIndex;
            getModeCost();
        }
        protected void grdModeCost_RowCanceling(object sender, GridViewCancelEditEventArgs e)
        {
            grdModeCost.EditIndex = -1;
            getModeCost();
        }

        //protected void grdModeCost_DataBound(object sender, GridViewCancelEditEventArgs e)
        //{
        //    LinkButton btninsert = new LinkButton();
        //    btninsert.ID = "Submit";
        //    btninsert.CommandName = "Insert";
        //   // btninsert.Text = "Insert"; 
        //    btninsert.CssClass = "imagelink";
        //    grdModeCost.FooterRow.Cells[2].Controls.Add(btninsert);
        //}
        protected void grdModeCost_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow Rows = grdModeCost.Rows[e.RowIndex];
            TextBox txtModeCost = Rows.FindControl("txtModeCost") as TextBox;
            HiddenField hdnModeId = Rows.FindControl("hdnModeId") as HiddenField;
            if (Convert.ToString(txtModeCost.Text.Trim()) == "")
            {
                string message = "Please enter the mode cost!";
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('" + message + "');", true);
                return;
            }
            else
            {
                if (Convert.ToDecimal(txtModeCost.Text) <= 0)
                {
                    string message = "Please enter mode cost greater than 0!";
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('" + message + "');", true);
                    return;
                }
            }
            int Result = costingObj.UpdateModeCost(Convert.ToInt32(hdnModeId.Value), Convert.ToDecimal(txtModeCost.Text), UserId, 2);
            grdModeCost.EditIndex = -1;

            if (Result > 0)
            {
                string message = "Your details has been Updated successfully.";
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('" + message + "');", true);
            }
            else
            {                
                string message = "Duplicate record found!";
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('" + message + "');", true);   
            }
            getModeCost();

        }
        private void getProcessCost()
        {
            grdProcessCost.DataSource = costingObj.GetProcessCost(UserId, 0);
            grdProcessCost.DataBind();    
        }

        protected void grdProcessCost_RowDataBound(object sender, GridViewRowEventArgs e)
        {           
            if ((e.Row.RowState & DataControlRowState.Edit) > 0)
            {
                TextBox txtProcessCost = (TextBox)e.Row.FindControl("txtProcessCost");
            }
        }

        protected void grdProcessCost_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void grdProcessCost_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grdProcessCost.EditIndex = e.NewEditIndex;
            getProcessCost();
        }
        protected void grdProcessCost_RowCanceling(object sender, GridViewCancelEditEventArgs e)
        {
            grdProcessCost.EditIndex = -1;
            getProcessCost();
        }
  
        protected void grdProcessCost_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow Rows = grdProcessCost.Rows[e.RowIndex];
            TextBox txtProcessCost = Rows.FindControl("txtProcessCost") as TextBox;
            HiddenField hdnProcessId = Rows.FindControl("hdnProcessId") as HiddenField;
            if (Convert.ToString(txtProcessCost.Text.Trim()) == "")
            {
                string message = "Please enter the process cost!";
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('" + message + "');", true);
                return;
            }
            else
            {
                if (Convert.ToDecimal(txtProcessCost.Text) == 0)
                {
                    string message = "Please enter the process cost greater than 0!";
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('" + message + "');", true);
                    return;
                }
            }
            int Result = costingObj.UpdateProcessCost(Convert.ToInt32(hdnProcessId.Value), Convert.ToDecimal(txtProcessCost.Text), UserId, 2);
           

            if (Result > 0)
            {
                string message = "Your details has been updated successfully.";
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('" + message + "');", true);

            }
            else
            {
                string message = "Duplicate record found!";
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('" + message + "');", true);

            }
            grdProcessCost.EditIndex = -1;
            getProcessCost();

        }
        protected void Add_ModeCostdata(object sender, EventArgs e)
        {
            grdModeCost.EditIndex = -1;
            grdProcessCost.EditIndex = -1;
            string TxtModeCostPence = this.TxtModeCostPence.Text;

            if (TxtModeCostPence.Trim() == "")
            {
                string message = "Please enter mode cost!";
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('" + message + "');", true);
                return;
            }
            else
            {
                if (Convert.ToDecimal(TxtModeCostPence) <= 0)
                {
                    string message = "Please enter mode cost greater than 0!";
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('" + message + "');", true);
                    return;
                }
            }
            int result = costingObj.InsertModeCost(Convert.ToDecimal(TxtModeCostPence), UserId, 1);
            if (result > 0)
            {
                string message = "Your details has been saved successfully.";
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('" + message + "');", true);
            }
            else
            {
                string message = "Duplicate record found!";
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('" + message + "');", true);
            }
            getModeCost();
            getProcessCost();
            this.TxtModeCostPence.Text="";
        }

        protected void Add_Processdata(object sender, EventArgs e)
        {
            grdModeCost.EditIndex = -1;
            grdProcessCost.EditIndex = -1;
            string TxtProcessCostPence = this.TxtProcessCostPence.Text;
            if (TxtProcessCostPence == "")
            {
                string message = "Please enter the process cost!";
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('" + message + "');", true);
                return;
            }
            else
            {
                if (Convert.ToDecimal(TxtProcessCostPence) <= 0)
                {
                    string message = "Please enter the Process Cost Greater than 0!";
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('" + message + "');", true);
                    return;
                }
            }
            int result = costingObj.InsertProcessCost(Convert.ToDecimal(TxtProcessCostPence), UserId, 1);
            if (result > 0)
            {
                string message = "Your details has been saved successfully.";
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('" + message + "');", true);
            }
            else
            {
                string message = "Duplicate record found!";
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('" + message + "');", true);
            }
            getProcessCost();
            getModeCost();
            this.TxtProcessCostPence.Text="";
          
        }
    }
}