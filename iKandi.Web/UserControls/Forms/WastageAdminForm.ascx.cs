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

namespace iKandi.Web.UserControls.Forms
{
    public partial class WastageAdminForm : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            AdminController objAdminController = new AdminController();
            objAdminController.GetAllGroupBAL();
            DataSet ds = objAdminController.GetAllGroupBAL();
            ViewState["AllGroup"] = ds.Tables[0];
            if (!IsPostBack)
            {

                ddlProcess.DataSource = objAdminController.GetProcess();
                ddlProcess.DataValueField = "processid";
                ddlProcess.DataTextField = "processname";
                ddlProcess.DataBind();

                chkAllClient.DataSource = ds.Tables[0];
                chkAllClient.RepeatColumns = 5;
                chkAllClient.DataTextField = "Name";
                chkAllClient.DataValueField = "Id";
                chkAllClient.DataBind();
                BindControl("Process", grdGroup);
                BindControl("Cutting", grdCutting);
            }
        }
        public void BindControl(string grdType, GridView grd)
        {
            AdminController objAdminController = new AdminController();
            DataSet ds = objAdminController.GetAllProcessBAL(grdType);
            if (grdType == "Cutting")
                ViewState["CuttingTable"] = ds.Tables[0];
            if (grdType == "Process")
                ViewState["ProcessTable"] = ds.Tables[0];
            grd.DataSource = ds.Tables[0];
            grd.DataBind();
        }
        public void ShowAlert(string stringAlertMsg)
        {
            string myStringVariable = string.Empty;
            myStringVariable = stringAlertMsg;
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            //if (txtProcess.Text.Trim() == "")
            //{
            //    lblProcess.Text = "enter process";
            //        return;
            //}
            //if (txtProcess.Text.Trim() != "")         
            //    lblProcess.Text = "";        
            int temp = 0;
            for (int j = 0; j < chkAllClient.Items.Count - 1; j++)
                if (chkAllClient.Items[j].Selected == true)
                    temp = temp + 1;
            int intLastTextvalue = 0;
            AdminController objAdminController = new AdminController();

            if (temp == 0)
            {
                intLastTextvalue = 1;
                ShowAlert("Select Group.");
            }

            for (int x = 0; x < chkAllClient.Items.Count - 1; x++)
            {

                if (chkAllClient.Items[x].Selected == true)
                {
                    int rr = Convert.ToInt32(chkAllClient.Items[x].Value);

                    //DataSet ds = objAdminController.CheckProcessWithGroupBAL(rr, txtProcess.Text.Trim());
                    DataSet ds = objAdminController.CheckProcessWithGroupBAL(rr, ddlProcess.SelectedValue);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        temp = 0;
                        intLastTextvalue = 1;
                        string myStringVariable = string.Empty;
                        //myStringVariable = "Process: " + txtProcess.Text.Trim() + " Already Tagged with " + ds.Tables[0].Rows[0]["GroupName"].ToString();
                        myStringVariable = "Process: " + ddlProcess.SelectedValue + " Already Tagged with " + ds.Tables[0].Rows[0]["GroupName"].ToString();
                        ShowAlert(myStringVariable);
                        break;
                    }

                }

            }


            if (temp > 0)
            {
                int rowcount = 0;
                for (int i = 0; i < chkAllClient.Items.Count - 1; i++)
                {

                    if (chkAllClient.Items[i].Selected == true)
                    {

                        rowcount = rowcount + 1;
                        //objAdminController.InsertProcessBAL(txtProcess.Text.Trim(), Convert.ToInt32(chkAllClient.Items[i].Value), "Insert", 0, 0, 0, rowcount);
                        objAdminController.InsertProcessBAL(ddlProcess.SelectedValue, Convert.ToInt32(chkAllClient.Items[i].Value), "Insert", 0, 0, 0, rowcount);
                    }

                }

            }

            BindControl("Process", grdGroup);
            if (intLastTextvalue == 0)
            {
                for (int j = 0; j < chkAllClient.Items.Count - 1; j++)
                    chkAllClient.Items[j].Selected = false;
                //txtProcess.Text = "";
                //ddlProcess.SelectedValue = "Select process";
            }
        }

        protected void grdGroup_RowEditing(object sender, GridViewEditEventArgs e)
        {

            grdGroup.EditIndex = e.NewEditIndex;
            BindControl("Process", grdGroup);

            GridViewRow Rows = grdGroup.Rows[e.NewEditIndex];
            HiddenField hd = Rows.FindControl("hdnId") as HiddenField;
            int id = Convert.ToInt32(hd.Value);

            Label txtProcess = Rows.FindControl("txtProcess") as Label;
            Label txtGroupName = Rows.FindControl("txtGroupName") as Label;
            TextBox txtShrinkage = Rows.FindControl("txtShrinkage") as TextBox;
            TextBox txtWashing = Rows.FindControl("txtWashing") as TextBox;
        }

        protected void grdCutting_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Insert")
            {
                int intTempForValidation = 0;
                AdminController objAdminController = new AdminController();
                TextBox QtyRangeFromFooter = grdCutting.FooterRow.FindControl("txtQtyRangeFromFooter") as TextBox;
                TextBox QtyRangeToFooter = grdCutting.FooterRow.FindControl("txtQtyRangeToFooter") as TextBox;
                DropDownList UnitFooter = grdCutting.FooterRow.FindControl("ddlUnitFooter") as DropDownList;
                int QtyUnit = Convert.ToInt32(UnitFooter.SelectedValue);
                TextBox CuttingWastageFooter = grdCutting.FooterRow.FindControl("txtCuttingWastageFooter") as TextBox;

                if (QtyRangeToFooter.Text.Trim() == "" || QtyRangeFromFooter.Text.Trim() == "")
                {
                    intTempForValidation = intTempForValidation + 1;
                    ShowAlert("Enter Qty Range.");
                }

                if (CuttingWastageFooter.Text.Trim() == "")
                {
                    intTempForValidation = intTempForValidation + 1;
                    ShowAlert("Enter Cutting Wastage.");
                }
                if (intTempForValidation == 0)
                {
                    int rangeFrom = Convert.ToInt32(QtyRangeFromFooter.Text);
                    int rangeTo = Convert.ToInt32(QtyRangeToFooter.Text);
                    int cuttingwastage = Convert.ToInt32(CuttingWastageFooter.Text);
                    int iStatus = objAdminController.InsertCuttingBAL(rangeFrom, rangeTo, QtyUnit, cuttingwastage, 0);
                    if (iStatus == 0)
                        ShowAlert("Enter Valid Range.");

                    if (iStatus == 1)
                        ShowAlert("Cutting Wastage Successfully Entered.");

                    BindControl("Cutting", grdCutting);
                }
            }


            if (e.CommandName == "addnew")
            {
                int intTempForValidation = 0;
                AdminController objAdminController = new AdminController();
                Table tblGrdviewApplet = (Table)grdCutting.Controls[0];
                GridViewRow rows = (GridViewRow)tblGrdviewApplet.Controls[0];
                TextBox QtyRangeFromEmpty = (TextBox)rows.FindControl("txtQtyRangeFromEmpty");
                TextBox QtyRangeToEmpty = (TextBox)rows.FindControl("txtQtyRangeTOEmpty");
                int QtyUnit = 1;
                TextBox CuttingWastageEmpty = (TextBox)rows.FindControl("txtCuttingWastageEmpty");

                if (CuttingWastageEmpty.Text.Trim() == "")
                {
                    intTempForValidation = intTempForValidation + 1;
                    ShowAlert("Enter Cutting Wastage.");
                }
                if (QtyRangeToEmpty.Text.Trim() == "" || QtyRangeFromEmpty.Text.Trim() == "")
                {
                    intTempForValidation = intTempForValidation + 1;
                    ShowAlert("Enter Qty Range.");
                }
                if (intTempForValidation == 0)
                {
                    int rangeFrom = Convert.ToInt32(QtyRangeFromEmpty.Text);
                    int rangeTo = Convert.ToInt32(QtyRangeToEmpty.Text);
                    int cuttingwastage = Convert.ToInt32(CuttingWastageEmpty.Text);
                    int iStatus = objAdminController.InsertCuttingBAL(rangeFrom, rangeTo, QtyUnit, cuttingwastage, 0);
                    if (iStatus == 0)
                        ShowAlert("Enter Valid Range.");

                    if (iStatus == 1)
                        ShowAlert("Cutting Wastage Successfully Entered.");


                    BindControl("Cutting", grdCutting);
                }
            }
        }

        protected void grdCutting_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.DataRow)
                return;
            DataTable dt = (DataTable)ViewState["CuttingTable"];
            DropDownList ddl = e.Row.FindControl("ddlUnit") as DropDownList;
            int i = e.Row.DataItemIndex;
            ddl.SelectedValue = Convert.ToString(dt.Rows[i]["QtyUnit"]);
            LinkButton alnkDelete = e.Row.FindControl("alnkDelete") as LinkButton;

            

        }

        protected void grdCutting_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grdCutting.EditIndex = e.NewEditIndex;

            BindControl("Cutting", grdCutting);
            GridViewRow Rows = grdCutting.Rows[e.NewEditIndex];

            TextBox txtQtyRangeFrom = Rows.FindControl("txtQtyRangeFrom") as TextBox;
            TextBox txtQtyRangeTo = Rows.FindControl("txtQtyRangeTo") as TextBox;
            DropDownList ddlUnit = Rows.FindControl("ddlUnit") as DropDownList;
            int QtyUnit = Convert.ToInt32(ddlUnit.SelectedValue);
            TextBox txtCuttingWastage = Rows.FindControl("txtCuttingWastage") as TextBox;
        }

        protected void grdCutting_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            AdminController objAdminController = new AdminController();
            GridViewRow Rows = null;
            Rows = grdCutting.Rows[e.RowIndex];
            HiddenField hd = Rows.FindControl("hdnIDCutting23") as HiddenField;

            objAdminController.DeleteCuttingAndProcessBAL(Convert.ToInt32(hd.Value), "Cutting");
            BindControl("Cutting", grdCutting);
        }

        protected void grdGroup_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            AdminController objAdminController = new AdminController();
            GridViewRow Rows = null;
            Rows = grdGroup.Rows[e.RowIndex];
            HiddenField hd = Rows.FindControl("hdnId") as HiddenField;

            objAdminController.DeleteCuttingAndProcessBAL(Convert.ToInt32(hd.Value), "Process");
            BindControl("Process", grdGroup);
        }

        protected void grdGroup_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            AdminController objAdminController = new AdminController();
            GridViewRow Rows = grdGroup.Rows[e.RowIndex];
            HiddenField hd = Rows.FindControl("hdnId") as HiddenField;
            Label txtProcess = Rows.FindControl("txtProcess") as Label;
            Label txtGroupName = Rows.FindControl("txtGroupName") as Label;
            TextBox txtShrinkage = Rows.FindControl("txtShrinkage") as TextBox;
            TextBox txtWashing = Rows.FindControl("txtWashing") as TextBox;
            DataTable dt = (DataTable) ViewState["AllGroup"];

            int intGroupID = dt.Select("Name = '" + txtGroupName.Text.Trim() + "'").Length;
            if (intGroupID > 0)
            {
                int? intShrinkageValue = null;
                int? intWashingValue = null;
                DataRow[] dr = dt.Select("Name = '" + txtGroupName.Text.Trim() + "'");
                int intID = Convert.ToInt32(hd.Value);
                int rr = Convert.ToInt32(chkAllClient.Items[0].Value);
                string s1 = txtProcess.Text.Trim();
                if (txtShrinkage.Text.Trim() == "")
                    intShrinkageValue = null;
                else
                    intShrinkageValue = Convert.ToInt32(txtShrinkage.Text.Trim());

                if (txtWashing.Text.Trim() == "")
                    intWashingValue = null;
                else
                    intWashingValue = Convert.ToInt32(txtWashing.Text.Trim());

                objAdminController.InsertProcessBAL(s1, Convert.ToInt32(dr[0].ItemArray[1]), "Update", intShrinkageValue,
                                                    intWashingValue, intID, 0);
                grdGroup.EditIndex = -1;
                BindControl("Process", grdGroup);
                ShowAlert("Update Successfully.");
            }
        }

        protected void grdGroup_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grdGroup.EditIndex = -1;

            BindControl("Process", grdGroup);
        }

        protected void grdCutting_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grdCutting.EditIndex = -1;

            BindControl("Cutting", grdCutting);
        }

        protected void grdCutting_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

            AdminController objAdminController = new AdminController();
            GridViewRow Rows = grdCutting.Rows[e.RowIndex];
            HiddenField hd = Rows.FindControl("hdnIDCutting") as HiddenField;
            TextBox txtQtyRangeFrom = Rows.FindControl("txtQtyRangeFrom") as TextBox;
            TextBox txtQtyRangeTo = Rows.FindControl("txtQtyRangeTo") as TextBox;
            int QtyUnit = 1;
            TextBox txtCuttingWastage = Rows.FindControl("txtCuttingWastage") as TextBox;
            int iStatus = 0;
            if (txtQtyRangeFrom.Text.Trim() == "" || txtQtyRangeTo.Text.Trim() == "")
                ShowAlert("Enter Valid Range.");
            else if (txtCuttingWastage.Text.Trim() == "")
                ShowAlert("Enter Cutting Wastage.");
            else
            {
                int rangeFrom = Convert.ToInt32(txtQtyRangeFrom.Text);
                int rangeTo = Convert.ToInt32(txtQtyRangeTo.Text);
                int cuttingwastage = Convert.ToInt32(txtCuttingWastage.Text);
                iStatus = objAdminController.InsertCuttingBAL(rangeFrom, rangeTo, QtyUnit, cuttingwastage, Convert.ToInt32(hd.Value));
            }
            if (iStatus == 0)
            {
                ShowAlert("Enter Valid Range.");
            }
            if (iStatus == 1)
            {
                grdCutting.EditIndex = -1;
                BindControl("Cutting", grdCutting);
                ShowAlert("Update successfully.");
            }
        }

        protected void grdGroup_RowDataBound(object sender, GridViewRowEventArgs e)
        {
           
        }

        protected void grdGroup_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if(e.CommandName.ToUpper().Trim()!="ADD")
                return;
            LinkButton lb = e.CommandSource as LinkButton;
            AdminController objAdminController = new AdminController();
            HiddenField hd = lb.Parent.FindControl("hdnId") as HiddenField;
            Label txtProcess = lb.Parent.FindControl("lblprc") as Label;
            Label txtGroupName = lb.Parent.FindControl("lblgrp") as Label;
            TextBox txtShrink = lb.Parent.FindControl("txtShrink") as TextBox;
            TextBox txtWash = lb.Parent.FindControl("txtWash") as TextBox;
            DataTable dt = (DataTable)ViewState["AllGroup"];

            int intGroupID = dt.Select("Name = '" + txtGroupName.Text.Trim() + "'").Length;
            if (intGroupID > 0)
            {
                int? intShrinkageValue = null;
                int? intWashingValue = null;
                DataRow[] dr = dt.Select("Name = '" + txtGroupName.Text.Trim() + "'");
                int intID = Convert.ToInt32(hd.Value);
                int rr = Convert.ToInt32(chkAllClient.Items[0].Value);
                string s1 = txtProcess.Text.Trim();
                if (txtShrink.Text.Trim() != "")
                    intShrinkageValue = Convert.ToInt32(txtShrink.Text.Trim());

                if (txtWash.Text.Trim() != "")
                    intWashingValue = Convert.ToInt32(txtWash.Text.Trim());

                objAdminController.InsertProcessBAL(s1, Convert.ToInt32(dr[0].ItemArray[1]), "Update", intShrinkageValue,
                                                    intWashingValue, intID, 0);
                grdGroup.EditIndex = -1;
                BindControl("Process", grdGroup);
                ShowAlert("Added Successfully.");
            }
        }

        protected void grdGroup_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}