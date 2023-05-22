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
using System.Text;
using iKandi.BLL;
using iKandi.Common;
using iKandi.Web.Components;

namespace iKandi.Web.Admin.Categories
{
    public partial class UnitAdmin : System.Web.UI.Page
    {
        AdminController objadmin = new AdminController();
        //int SelectDropDown = 0;
        string unitname = "";
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (iKandi.Web.Components.ApplicationHelper.LoggedInUser == null || iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData == null)
                Response.Redirect("~/public/Login.aspx");

            if (!IsPostBack)
            {
                bindddl();
                getdata();
            }
        }
        private void bindddl()
        {
            DataSet dsUnitAdin = new DataSet();

            if (unitname != "")
            {
                ddlAdminUnit.SelectedValue = unitname;
            }
            dsUnitAdin = objadmin.GetUnitAdmin("Select Unit", 0);
            ddlAdminUnit.DataSource = dsUnitAdin.Tables[0];
            ddlAdminUnit.DataTextField = "UnitName";
            ddlAdminUnit.DataValueField = "GroupUnitID";

            ddlAdminUnit.DataBind();
            ddlAdminUnit.Items.Insert(0, new ListItem("Select Unit", "-1"));
            ddlAdminUnit.SelectedItem.Selected = true;
        }
        private void getdata()
        {
            DataSet dsUnitAdmim = new DataSet();
            dsUnitAdmim = objadmin.GetUnitAdmin(ddlAdminUnit.SelectedItem.ToString(), 0);
            grdUnitAdmin.DataSource = dsUnitAdmim.Tables[1];
            grdUnitAdmin.DataBind();         
            
        }

        protected void grdUnitAdmin_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if ((e.Row.RowState & DataControlRowState.Edit) > 0)
            {
                TextBox Edit_UnitName = (TextBox)e.Row.FindControl("Edit_UnitName");
                TextBox Edit_ConvertPerPcs = (TextBox)e.Row.FindControl("Edit_ConvertPerPcs");
                DropDownList ddlIsActive = (DropDownList)e.Row.FindControl("ddlIsActive");
                HiddenField hdnIsActiveEdit = (HiddenField)e.Row.FindControl("hdnIsActiveEdit");

                //added by raghvinder on 23-09-2020 start
                CheckBox chkEditFabric = (CheckBox)e.Row.FindControl("chkEditFabric");
                CheckBox chkEditAccessory = (CheckBox)e.Row.FindControl("chkEditAccessory");
                HiddenField hdnIsFabricEdit = (HiddenField)e.Row.FindControl("hdnIsFabricEdit");
                HiddenField hdnIsAccessoryEdit = (HiddenField)e.Row.FindControl("hdnIsAccessoryEdit");

                if (hdnIsFabricEdit.Value == "False")
                {
                    chkEditFabric.Checked = false;
                }
                else
                {
                    chkEditFabric.Checked = true;
                }

                if (hdnIsAccessoryEdit.Value == "False")
                {
                    chkEditAccessory.Checked = false;
                }
                else
                {
                    chkEditAccessory.Checked = true;
                }
                //added by raghvinder on 23-09-2020 end
                
               
                if (hdnIsActiveEdit.Value == "False")
                {
                     ddlIsActive.SelectedValue = "0";                   
                }
                else
                {
                     ddlIsActive.SelectedValue = "1";                    
                }
            }

            else
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                 
                    Label lblUnitName = (Label)e.Row.FindControl("lblUnitName");
                    Label lblConvertPerPcs = (Label)e.Row.FindControl("lblConvertPerPcs");

                    HiddenField hdnIsActive = (HiddenField)e.Row.FindControl("hdnIsActive");
                    Label lblActiveDective = (Label)e.Row.FindControl("lblActiveDective");
                    HiddenField hdnUnit = (HiddenField)e.Row.FindControl("hdnUnit");

                    //added by raghvinder on 23-09-2020 start
                    CheckBox chkFabric = (CheckBox)e.Row.FindControl("chkFabric");
                    CheckBox chkAccessory = (CheckBox)e.Row.FindControl("chkAccessory");
                    HiddenField hdnIsFabric = (HiddenField)e.Row.FindControl("hdnIsFabric");
                    HiddenField hdnIsAccessory = (HiddenField)e.Row.FindControl("hdnIsAccessory");

                    if (hdnIsFabric.Value == "False")
                    {
                        chkFabric.Checked = false;
                    }
                    else
                    {
                        chkFabric.Checked = true;
                    }

                    if (hdnIsAccessory.Value == "False")
                    {
                        chkAccessory.Checked = false;
                    }
                    else
                    {
                        chkAccessory.Checked = true;
                    }
                    //added by raghvinder on 23-09-2020 end

                    if (hdnIsActive.Value == "False")
                    {
                        lblActiveDective.Text = "In Active";
                    }
                    else
                    {
                        if (hdnIsActive.Value == "True" && hdnUnit.Value != "")
                        {

                            e.Row.Cells[4].BackColor = System.Drawing.Color.FromArgb(255, 241, 243);
                            lblActiveDective.Text = "Active";
                            e.Row.Cells[5].Enabled = false;                             
                            e.Row.Cells[5].Attributes.CssStyle.Add("opacity","0");
                           
                            
                        }
                        else
                        {                            
                            e.Row.Cells[4].BackColor = System.Drawing.Color.White;
                            lblActiveDective.Text = "Active";
                            
                        }
                    }

                    

                }
            }
        }

        protected void grdUnitAdmin_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName.Equals("EmptyInsert"))
            {
                grdUnitAdmin.EditIndex = -1;
                TextBox TxtUnitAdmin = grdUnitAdmin.Controls[0].Controls[0].FindControl("TxtUnitAdmin") as TextBox;
                TextBox TxtConvertPerPcs = grdUnitAdmin.Controls[0].Controls[0].FindControl("TxtConvertPerPcs") as TextBox;

                //added by raghvinder on 23-09-2020 start
                bool Isfabric = false, IsAccessory = false, IsActive = false;

                DropDownList Foo_IsActive = (DropDownList)grdUnitAdmin.FooterRow.FindControl("ddlIsActive");
                CheckBox Foo_IsFabric = (CheckBox)grdUnitAdmin.FooterRow.FindControl("chkFabric");
                CheckBox Foo_IsAccessory = (CheckBox)grdUnitAdmin.FooterRow.FindControl("chkAccessory");

                if (Foo_IsActive.SelectedValue == "1")
                {
                    IsActive = true;
                }
                if (Foo_IsFabric.Checked)
                {
                    Isfabric = true;
                }
                if (Foo_IsAccessory.Checked)
                {
                    IsAccessory = true;
                }
                //added by raghvinder on 23-09-2020 end

                int ValuePcs = 0;
                var UnitAdmin = TxtUnitAdmin.Text.Trim();
                var ConvertPcs = TxtConvertPerPcs.Text.Trim();
                if (ConvertPcs != "")
                {
                    ValuePcs = Convert.ToInt32(ConvertPcs);
                }

                if (UnitAdmin == "")
                {
                    string message = "Please enter the unit name!";
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('" + message + "');", true);                 
                    return;
                }
                //if ((ConvertPcs == "") || (ConvertPcs == "0"))
                //{
                //    string message = "Please enter convert to per pcs!";
                //    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('" + message + "');", true);
                //    return;
                //}

                //int result = objadmin.InsertUnitAdmin(0, TxtUnitAdmin.Text, ValuePcs, 1, 1);


                //int result = objadmin.InsertUnitAdmin(0, TxtUnitAdmin.Text, ValuePcs, IsActive,Isfabric,IsAccessory, 1);               
                
                

                //new code start
                string result = "";                
                result = objadmin.InsertUnitAdmin(0, TxtUnitAdmin.Text, ValuePcs, IsActive, Isfabric, IsAccessory, 1);
                     
                if (result == "Save Successfully")
                {
                    string message = "Your details has been saved successfully.";
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('" + message + "');", true);
                }

                if (result == "Duplicate Record")
                {
                    string message = "Duplicate record found!";
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('" + message + "');", true);
                }

                if (result == "Please select Fabric or Accessory")
                {
                    string message = "Please select Fabric or Accessory!";
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('" + message + "');", true);
                }
                //new code end

                unitname = ddlAdminUnit.SelectedItem.Value;
                getdata();
            }
            if (e.CommandName.Equals("Insert"))
            {
                grdUnitAdmin.EditIndex = -1;
                TextBox Foo_UnitName = (TextBox)grdUnitAdmin.FooterRow.FindControl("Foo_UnitName") as TextBox;
                TextBox Foo_ConvertPerPcs = (TextBox)grdUnitAdmin.FooterRow.FindControl("Foo_ConvertPerPcs") as TextBox;

                //added by raghvinder on 23-09-2020 start
                bool Isfabric = false, IsAccessory = false, IsActive=false; 
                
                DropDownList Foo_IsActive = (DropDownList)grdUnitAdmin.FooterRow.FindControl("ddlFooIsActive");
                CheckBox Foo_IsFabric = (CheckBox)grdUnitAdmin.FooterRow.FindControl("chkFooFabric");
                CheckBox Foo_IsAccessory = (CheckBox)grdUnitAdmin.FooterRow.FindControl("chkFooAccessory");
            
                if (Foo_IsActive.SelectedValue == "1")
                {
                    IsActive = true;
                }
                if (Foo_IsFabric.Checked)
                {
                    Isfabric = true;
                }
                if (Foo_IsAccessory.Checked)
                {
                    IsAccessory = true;
                }
                //added by raghvinder on 23-09-2020 end

                

                int ValuePcs = 0;
                var ConvertPcs = Foo_ConvertPerPcs.Text.Trim();
                if (ConvertPcs != "")
                {
                    ValuePcs = Convert.ToInt32(ConvertPcs);
                }
                var Foo_UnitNameAdd = Foo_UnitName.Text.Trim();
                if (Foo_UnitNameAdd == "")
                {
                    string message = "Please enter the Unit name!";
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('" + message + "');", true);
                    return;
                }
                //if ((ConvertPcs == "") || (ConvertPcs == "0"))
                //{
                //    string message = "Please enter convert to per pcs!";
                //    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('" + message + "');", true);
                //    return;
                //}

                //int result = objadmin.InsertUnitAdmin(0, Foo_UnitName.Text, ValuePcs, 1, 1);



                //int result = 0;
                //if (Isfabric == true || IsAccessory == true)
                //{
                //    result = objadmin.InsertUnitAdmin(0, Foo_UnitName.Text, ValuePcs, IsActive, Isfabric, IsAccessory, 1);
                //}
                //else
                //{
                //    string message = "Please select Fabric or Accessory!";
                //    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('" + message + "');", true);
                    
                //}

                //if (result > 0)
                //{
                //    string message = "Your details has been saved successfully.";
                //    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('" + message + "');", true);
                    
                //}
                //else
                //{
                //    string message = "Duplicate record found!";
                //    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('" + message + "');", true);
                   
                //}

                //new code start
                string result = "";
                result = objadmin.InsertUnitAdmin(0, Foo_UnitName.Text, ValuePcs, IsActive, Isfabric, IsAccessory, 1);
                if (result == "Save Successfully")
                {
                    string message = "Your details has been saved successfully.";
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('" + message + "');", true);                    
                }

                if (result == "Duplicate Record")
                {
                    string message = "Duplicate record found!";
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('" + message + "');", true);
                }

                if (result == "Please select Fabric or Accessory")
                {
                    string message = "Please select Fabric or Accessory!";
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('" + message + "');", true);
                }
                //new code end

                unitname = ddlAdminUnit.SelectedItem.Value; 
                getdata();

            }
        }

      
        protected void grdUnitAdmin_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            //dal obj = new dal();
            GridViewRow Rows = grdUnitAdmin.Rows[e.RowIndex];
            TextBox Edit_UnitName = Rows.FindControl("Edit_UnitName") as TextBox;
            HiddenField hdnGroupUnitId = Rows.FindControl("hdnGroupUnitId") as HiddenField;
            TextBox Edit_ConvertPerPcs = Rows.FindControl("Edit_ConvertPerPcs") as TextBox;
            DropDownList ddlIsActive = Rows.FindControl("ddlIsActive") as DropDownList;
            Label lblActiveDective = Rows.FindControl("lblActiveDective") as Label;

            //added by raghvinder on 23-09-2020 start
            bool Isfabric = false, IsAccessory = false, IsActive = false; 

            CheckBox chkEditFabric = Rows.FindControl("chkEditFabric") as CheckBox;
            CheckBox chkEditAccessory = Rows.FindControl("chkEditAccessory") as CheckBox;
            if (ddlIsActive.SelectedValue == "1")
            {
                IsActive = true;
            }
            if (chkEditFabric.Checked)
            {
                Isfabric = true;
            }
            if (chkEditAccessory.Checked)
            {
                IsAccessory = true;
            }
            //added by raghvinder on 23-09-2020 end

            int ValuePcs = 0;
            var ConvertPcs = Edit_ConvertPerPcs.Text.Trim();
            if (ConvertPcs != "")
            {
                ValuePcs = Convert.ToInt32(ConvertPcs);
            }
            var TxtEdit_UnitName = Edit_UnitName.Text.Trim();
            if (TxtEdit_UnitName == "")
            {
                string message = "Please enter the process name!";
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('" + message + "');", true);                
                return;
            }
            //if ((ConvertPcs == "")||(ConvertPcs == "0"))
            //{
            //    string message = "Please enter convert to per pcs!";
            //    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('" + message + "');", true);
            //    return;
            //}
            
            //int Result = objadmin.UpdateUnitAdmin(Convert.ToInt32(hdnGroupUnitId.Value), TxtEdit_UnitName, ValuePcs, Convert.ToInt32(ddlIsActive.SelectedValue), 2);

            int Result = 0;
            if (Isfabric == true || IsAccessory == true)
            {
                Result = objadmin.UpdateUnitAdmin(Convert.ToInt32(hdnGroupUnitId.Value), TxtEdit_UnitName, ValuePcs, IsActive, Isfabric, IsAccessory, 2);
            }
            else
            {
                string message = "Please select Fabric or Accessory!";
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('" + message + "');", true);                
            }
            grdUnitAdmin.EditIndex = -1;

            if (Result > 0)
            {
                string message = "Your details has been updated successfully.";
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('" + message + "');", true);
                
            }
            else
            {
                if (Result == -2)
                {
                    //ddlIsActive.ForeColor = System.Drawing.Color.Pink;
                    //lblActiveDective.ForeColor = System.Drawing.Color.Pink;
                    string message = "This record has been already associate with other group!";
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('" + message + "');", true);
                }
                else
                {
                    string message = "Duplicate record found!";
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('" + message + "');", true);
                }
               
            }
            unitname = ddlAdminUnit.SelectedItem.Value;
            getdata();
        }



        protected void grdUnitAdmin_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grdUnitAdmin.EditIndex = e.NewEditIndex;
         
           // unitname = ddlAdminUnit.SelectedItem.ToString();
            unitname = ddlAdminUnit.SelectedItem.Value;
            getdata();
        }

        protected void grdUnitAdmin_RowCanceling(object sender, GridViewCancelEditEventArgs e)
        {
            grdUnitAdmin.EditIndex = -1;
            unitname = ddlAdminUnit.SelectedItem.Value;
            getdata();
        }       

        protected void btn_Go(object sender, EventArgs e)
        {
            unitname = ddlAdminUnit.SelectedItem.Value;
            grdUnitAdmin.EditIndex = -1;
            getdata();
        }
        protected void ddlAdminUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlAdminUnit.SelectedValue = ddlAdminUnit.SelectedItem.Value;
            unitname = ddlAdminUnit.SelectedItem.Value;
        }

        protected void grdUnitAdmin_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                GridView HeaderGrid = (GridView)sender;
                GridViewRow HeaderGridRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
                TableCell HeaderCell = new TableCell();
                HeaderCell.Text = "Unit";
                HeaderCell.RowSpan = 2;
                HeaderCell.Style.Add("text-align", "center");
                HeaderCell.Style.Add("width", "150px");
                HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#39589c");
                HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                HeaderGridRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Convert To Per Pcs";
                HeaderCell.RowSpan = 2;
                HeaderCell.Style.Add("text-align", "center");
                HeaderCell.Style.Add("width", "480px");
                HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#39589c");
                HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                HeaderGridRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Is Applicable";                
                HeaderCell.ColumnSpan = 2;
                HeaderCell.Style.Add("text-align", "center");
                HeaderCell.Style.Add("width", "100px");
                HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#39589c");
                HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                HeaderGridRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Is Active";
                HeaderCell.RowSpan = 2;
                HeaderCell.Style.Add("text-align", "center");
                HeaderCell.Style.Add("width", "280px");
                HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#39589c");
                HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                HeaderGridRow.Cells.Add(HeaderCell);                

                HeaderCell = new TableCell();
                HeaderCell.Text = "Action";
                HeaderCell.RowSpan = 2;
                HeaderCell.Style.Add("text-align", "center");
                HeaderCell.Style.Add("width", "70px");
                HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#39589c");
                HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                HeaderGridRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Add";
                HeaderCell.RowSpan = 2;
                HeaderCell.Style.Add("text-align", "center");
                HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#39589c");
                HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                HeaderGridRow.Cells.Add(HeaderCell);
                grdUnitAdmin.Controls[0].Controls.AddAt(0, HeaderGridRow);

                GridViewRow HeaderGridRow1 = new GridViewRow(1, 0, DataControlRowType.Header, DataControlRowState.Insert);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Fabric";
                HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#39589c");
                HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");                
                HeaderCell.Style.Add("text-align", "center");
                HeaderGridRow1.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Accessory";
                HeaderCell.Style.Add("text-align", "center");
                HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#39589c");
                HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");                
                HeaderGridRow1.Cells.Add(HeaderCell);

                grdUnitAdmin.Controls[0].Controls.AddAt(1, HeaderGridRow1);
                

            }
        }
    }
}