using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iKandi.BLL;
using System.Data;

namespace iKandi.Web.Admin.ProductionAdmin
{
    public partial class frmStyleCodeInterval : System.Web.UI.Page
    {
        AdminController objadmincontroller = new AdminController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGridViewCuttingWs();
            }
        }
        public void BindGridViewCuttingWs()
        {
            DataSet ds = new DataSet();
            ds = objadmincontroller.GetStyleCodeInterval();
            DataTable dt = new DataTable();
            dt = ds.Tables[0];           
           
                grdStyleCodeInterval.DataSource = dt;
                grdStyleCodeInterval.DataBind();
           
        }
    
        protected void grdStyleCodeInterval_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("EmptyInsert"))
            {
                TextBox txt_Empty_fromQty = grdStyleCodeInterval.Controls[0].Controls[0].FindControl("txt_Empty_fromQty") as TextBox;
                TextBox txt_Empty_toQty = grdStyleCodeInterval.Controls[0].Controls[0].FindControl("txt_Empty_toQty") as TextBox;
                
                var fromQty = txt_Empty_fromQty.Text.Trim();
                var toQty = txt_Empty_toQty.Text.Trim();

                if (fromQty == "")
                {
                    string message = "Please enter From Qty Value!";
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('" + message + "');", true);
                    return;
                }
                if (toQty == "")
                {
                    string message = "Please enter To Qty Value!";
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('" + message + "');", true);
                    return;
                }
                else
                {
                    if (Convert.ToInt32(toQty) <= Convert.ToInt32(fromQty))
                    {
                        string message = "To Qty Value is Not Less than from Qty!";
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('" + message + "');", true);
                        return;
                    }
                }
                int result = objadmincontroller.Insert_Delete_StyleCodeInterval(0, fromQty, toQty, 3);
                if (result > 0)
                {
                    string message = "Your details has been saved successfully.";
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('" + message + "');", true);
                }              

                BindGridViewCuttingWs();
            }
            if (e.CommandName.Equals("Insert"))
            {
                TextBox Foo_FromQty = (TextBox)grdStyleCodeInterval.FooterRow.FindControl("foo_txtfromQty") as TextBox;
                TextBox Foo_ToQty = (TextBox)grdStyleCodeInterval.FooterRow.FindControl("Foo_txttoQty") as TextBox;

                var fromQty = Foo_FromQty.Text.Trim();
                var toQty = Foo_ToQty.Text.Trim();
               
                if (fromQty == "")
                {
                    string message = "Please enter From Qty Value!";
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('" + message + "');", true);
                    return;
                }
                if (toQty == "")
                {
                    string message = "Please enter To Qty Value!";
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('" + message + "');", true);
                    return;
                }
                else
                {
                    if (Convert.ToInt32(toQty) <= Convert.ToInt32(fromQty))
                    {
                        string message = "To Qty Value is Not Less than from value!";
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('" + message + "');", true);
                        return;
                    }
                }
                int result = objadmincontroller.Insert_Delete_StyleCodeInterval(0, fromQty, toQty, 3);
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

                BindGridViewCuttingWs();

            }

            if (e.CommandName.Equals("Delete"))
            {
                  GridViewRow row = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
                int index = row.RowIndex;               
                HiddenField hdnRowID = (HiddenField)grdStyleCodeInterval.Rows[index].FindControl("hdnRowID") as HiddenField;
                int result = objadmincontroller.Insert_Delete_StyleCodeInterval(Convert.ToInt32(hdnRowID.Value), "", "", 2);
                if (result > 0)
                {
                    string message = "Your details has been Deleted successfully.";
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('" + message + "');", true);                  
                }
                BindGridViewCuttingWs();
            }
        }

        protected void Add_data(object sender, EventArgs e)
        {

        }
        protected void grdStyleCodeInterval_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void DeleteAllData(object sender, EventArgs e)
        {
            try
            {
                int result = objadmincontroller.Insert_Delete_StyleCodeInterval(0, "", "", 4);
                if (result > 0)
                {
                    string message = "Your details has been Deleted successfully.";
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('" + message + "');", true);
                }
                BindGridViewCuttingWs();
            }
            catch { }
        }
    }
}