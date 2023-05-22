using System;
using System.Collections;
using System.Collections.Generic;
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
using iKandi.Web.Components;
using iKandi.Common;
using System.IO;
using System.Globalization;
using System.Text.RegularExpressions;

namespace iKandi.Web.UserControls.Forms
{
    public partial class frmLossDistributionAdmin : System.Web.UI.UserControl
    {
        AdminController objadmin = new AdminController();
        public string UserId
        {
            get;
            set;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            UserId = ApplicationHelper.LoggedInUser.UserData.UserID.ToString();
            if (!Page.IsPostBack)
            {
                BindGrd();
                //DropDownList ddl = grdLossdistribution.EmptyDataTemplate.FindControl("ddldepartmentempty") as DropDownList;
               // BindDepartmentDdl(ddl);
            }
        }

        private void BindGrd()
        {
            DataTable dt = new DataTable();

            dt = objadmin.GetLossDistributionDetails();

            grdLossdistribution.DataSource = dt;
            grdLossdistribution.DataBind();
        }

        protected void grdLossdistribution_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //RadioButtonList rbtnIsActiveItem = (RadioButtonList)e.Row.FindControl("rbtnIsActiveItem") as RadioButtonList;

                HiddenField hdnIsActive = (HiddenField)e.Row.FindControl("hdnIsActive") as HiddenField;
                DropDownList ddldepartment = (DropDownList)e.Row.FindControl("ddldepartment") as DropDownList;
                BindDepartmentDdl(ddldepartment);

                HiddenField hdndepratmentId = (HiddenField)e.Row.FindControl("hdndepratmentId") as HiddenField;

                HtmlInputRadioButton rdo_active = (HtmlInputRadioButton)e.Row.FindControl("rdo_active") as HtmlInputRadioButton;

                HtmlInputRadioButton rdo_inactive = (HtmlInputRadioButton)e.Row.FindControl("rdo_inactive") as HtmlInputRadioButton;
                HtmlInputCheckBox chk_stitching = (HtmlInputCheckBox)e.Row.FindControl("chk_stitching") as HtmlInputCheckBox;
                HtmlInputCheckBox Chk_Finishing = (HtmlInputCheckBox)e.Row.FindControl("Chk_Finishing") as HtmlInputCheckBox;
                HtmlInputCheckBox Chk_cutting = (HtmlInputCheckBox)e.Row.FindControl("Chk_cutting") as HtmlInputCheckBox;
                HiddenField hnd_Stitching = (HiddenField)e.Row.FindControl("hnd_Stitching") as HiddenField;
                HiddenField hdn_finishing = (HiddenField)e.Row.FindControl("hdn_finishing") as HiddenField;
                HiddenField hdn_cutting = (HiddenField)e.Row.FindControl("hdn_cutting") as HiddenField;






                if (hnd_Stitching.Value.ToUpper() == "TRUE")
                {
                    chk_stitching.Checked = true;
                }
                else
                {
                    chk_stitching.Checked = false;
                }
                if (hdn_finishing.Value.ToUpper() == "TRUE")
                {
                    Chk_Finishing.Checked = true;
                }
                else
                {
                    Chk_Finishing.Checked = false;
                }

                if (hdn_cutting.Value.ToUpper() == "TRUE")
                {
                    Chk_cutting.Checked = true;
                }
                else
                {
                    Chk_cutting.Checked = false;
                }



                if (hdnIsActive.Value.ToUpper() == "TRUE")
                {
                    rdo_active.Checked = true;
                }
                else
                {
                    rdo_inactive.Checked = true;

                    chk_stitching.Disabled = true;
                    Chk_cutting.Disabled = true;
                    Chk_Finishing.Disabled = true;


                }


                if (hdndepratmentId.Value != "")
                {
                    ddldepartment.SelectedValue = hdndepratmentId.Value;

                }






            }
            if (e.Row.RowType == DataControlRowType.EmptyDataRow)
            {

                DropDownList ddldepartmentempty = (DropDownList)e.Row.FindControl("ddldepartmentempty");
                if (ddldepartmentempty != null)
                {
                    BindDepartmentDdl(ddldepartmentempty);
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {

                DropDownList ddldepartmentfoter = (DropDownList)e.Row.FindControl("ddldepartmentfoter");
                if (ddldepartmentfoter != null)
                {
                    BindDepartmentDdlfoter(ddldepartmentfoter);
                }
            }




        }

        protected void grdLossdistribution_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Insert")
            {
                int stiching;
                int finshing;
                int cutting;
                DataSet ds = new DataSet();
                Table tblGrdviewApplet = (Table)grdLossdistribution.Controls[0];
                GridViewRow rows = (GridViewRow)tblGrdviewApplet.Controls[0];

                DropDownList ddldepartmentfoter = grdLossdistribution.FooterRow.FindControl("ddldepartmentfoter") as DropDownList;


                RadioButtonList rbtnIsActiveFooter = grdLossdistribution.FooterRow.FindControl("rbtnIsActiveFooter") as RadioButtonList;


                CheckBox chk_footer_stitching = grdLossdistribution.FooterRow.FindControl("chk_footer_stitching") as CheckBox;
                CheckBox Chk_footer_Finishing = grdLossdistribution.FooterRow.FindControl("Chk_footer_Finishing") as CheckBox;
                CheckBox Chk_footer_cutting = grdLossdistribution.FooterRow.FindControl("Chk_footer_cutting") as CheckBox;

                if (chk_footer_stitching.Checked == true)
                {
                    stiching = 1;
                }
                else
                {
                    stiching = 0;
                }
                if (Chk_footer_Finishing.Checked == true)
                {
                    finshing = 1;
                }
                else
                {
                    finshing = 0;
                }
                if (Chk_footer_cutting.Checked == true)
                {
                    cutting = 1;
                }
                else
                {
                    cutting = 0;
                }





                //if (txtNameItem.Text == "")
                //{
                //    string script = string.Empty;
                //    script = "ShowHideMessageBox(true, 'Enter department name','');";
                //    ScriptManager.RegisterStartupScript(Page, typeof(Page), "ShowMessage", script, true);
                //    return;
                //}
                if (rbtnIsActiveFooter.SelectedValue == "")
                {
                    string script = string.Empty;
                    script = "ShowHideMessageBox(true, 'Select active or inactive','');";
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "ShowMessage", script, true);
                    return;
                }

                int Isactive = Convert.ToInt32(rbtnIsActiveFooter.SelectedValue);


                int deptid = Convert.ToInt32(ddldepartmentfoter.SelectedValue);

                int CurrentLoggedInUserID = ApplicationHelper.LoggedInUser.UserData.UserID;
                if (deptid == -1)
                {
                    string script = string.Empty;
                    script = "ShowHideMessageBox(true, 'Select department name','');";
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "ShowMessage", script, true);
                    return;
                }
                int result = objadmin.InsertLossLineDesignation(deptid, Isactive, CurrentLoggedInUserID, stiching, finshing, cutting);

                if (result == -1)
                {
                    string SussMsg = string.Empty;

                    SussMsg = "ShowHideMessageBox(true, 'Department name already exists ','');";
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "ShowMessage", SussMsg, true);
                    BindGrd();
                }
                else
                {
                    string SussMsg = string.Empty;

                    SussMsg = "ShowHideMessageBox(true, 'Record add successfully','');";
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "ShowMessage", SussMsg, true);

                    BindGrd();
                }


                //bindDropDownList();
            }

            if (e.CommandName == "addnew")
            {
                DataSet ds = new DataSet();
                Table tblGrdviewApplet = (Table)grdLossdistribution.Controls[0];
                GridViewRow rows = (GridViewRow)tblGrdviewApplet.Controls[0];

                //TextBox txtemptyname = (TextBox)rows.FindControl("txtNameEmpty") as TextBox;

                int stiching;
                int finshing;
                int cutting;

                CheckBox chk_add_stitching = (CheckBox)rows.FindControl("chk_add_stitching") as CheckBox;
                CheckBox Chk_add_Finishing = (CheckBox)rows.FindControl("Chk_add_Finishing") as CheckBox;
                CheckBox chk_footer_cutting = (CheckBox)rows.FindControl("chk_footer_cutting") as CheckBox;


                if (chk_add_stitching.Checked == true)
                {
                    stiching = 1;
                }
                else
                {
                    stiching = 0;
                }
                if (Chk_add_Finishing.Checked == true)
                {
                    finshing = 1;
                }
                else
                {
                    finshing = 0;
                }
                if (chk_footer_cutting.Checked == true)
                {
                    cutting = 1;
                }
                else
                {
                    cutting = 0;
                }


                RadioButtonList rdolist = (RadioButtonList)rows.FindControl("rbtnIsActiveItemEmpty") as RadioButtonList;
                DropDownList ddldepartmentempty = (DropDownList)rows.FindControl("ddldepartmentempty") as DropDownList;


                if (rdolist.SelectedValue == "")
                {
                    string script = string.Empty;
                    script = "ShowHideMessageBox(true, 'select Active or Inactive','');";
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "ShowMessage", script, true);
                    return;
                }

                int Isactive = Convert.ToInt32(rdolist.SelectedValue);
                int ddlDeptid = Convert.ToInt32(ddldepartmentempty.SelectedValue);

                if (ddlDeptid == -1)
                {
                    string script = string.Empty;
                    script = "ShowHideMessageBox(true, 'Select department name','');";
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "ShowMessage", script, true);
                    return;
                }

                int CurrentLoggedInUserID = ApplicationHelper.LoggedInUser.UserData.UserID;
                int result = objadmin.InsertLossLineDesignation(ddlDeptid, Isactive, CurrentLoggedInUserID, stiching, finshing, cutting);
                BindGrd();
            }

        }

        protected void rbtnIsActiveItem_SelectedIndexChanged(object sender, EventArgs e)
        {

            //// string strtxt = ((TextBox)(sender)).Text.Trim();
            // GridViewRow gvr = ((RadioButtonList)sender).Parent.Parent as GridViewRow;

            // RadioButtonList rdolist = (RadioButtonList)gvr.FindControl("rbtnIsActiveItem");

            // rdolist.Attributes.Add("onchange", "javascript:return UpdateLineLineDesignation(this)");
        }
        protected void btnbottom_Click(object sender, EventArgs e)
        {
            BindGrd();

        }
        public void BindDepartmentDdl(DropDownList objddl)
        {
            DataTable dt = objadmin.BindDepartmentDdl();
            objddl.DataSource = dt;
            objddl.DataTextField = "Name";
            objddl.DataValueField = "id";
            objddl.DataBind();

           
           
        }
        public void BindDepartmentDdlfoter(DropDownList objddl)
        {
            DataTable dt = objadmin.BindDepartmentDdl();
            objddl.DataSource = dt;
            objddl.DataTextField = "Name";
            objddl.DataValueField = "id";
            objddl.DataBind();

            DataTable dtd = objadmin.getdepartment();


            foreach (DataRow row in dtd.Rows)
            {

                foreach (var item in row.ItemArray)
                {
                    objddl.Items.Remove(objddl.Items.FindByValue(item.ToString()));
                }
            }


        }



        //public ListItem RemoveListItem()
        //{
        //    //ArrayList lists=new ArrayList();
        //    ListItem removeItem = null;
           
        //    foreach (GridViewRow row in grdLossdistribution.Rows)
        //    {
        //       // DropDownList ddldepartmentfoter = (DropDownList)row.FindControl("ddldepartmentfoter");
        //       // if (ddldepartmentfoter != null)
        //      //  {
        //            removeItem = ddldepartmentfoter.SelectedItem;
        //           // lists.Add(ddldepartment.SelectedValue.ToString());
        //       // }
                
        //    }
        //    return removeItem;
        //}
    }
}