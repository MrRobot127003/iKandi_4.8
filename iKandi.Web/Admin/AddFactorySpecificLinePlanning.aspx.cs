using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Globalization;
using iKandi.BLL;
using iKandi.Common;
using iKandi.Web.Components;

namespace iKandi.Web.Admin
{
    public partial class AddFactorySpecificLinePlanning : System.Web.UI.Page
    {
        int UserId = 0;
        int UnitId = 0, LinePlanFrameId = 0, CombinedFrameId = 0, LineNoId = 0;
        string UnitName = "", FloorNo = "", LineNo = "", StyleCode = "";
        DateTime StartDate = DateTime.Now;

        protected void Page_Load(object sender, EventArgs e)
        {
            UserId = ApplicationHelper.LoggedInUser.UserData.UserID;

            UnitId = Convert.ToInt32(Request.QueryString["UnitId"]);
            UnitName = Convert.ToString(Request.QueryString["UnitName"]);
            FloorNo = Convert.ToString(Request.QueryString["FloorNo"]);
            LineNo = Convert.ToString(Request.QueryString["LineNo"]);
            LinePlanFrameId = Convert.ToInt32(Request.QueryString["LinePlanFrameId"]);
            CombinedFrameId = Convert.ToInt32(Request.QueryString["CombinedFrameId"]);
            if (Request.QueryString["StyleCode"] != null)
            {
                StyleCode = Request.QueryString["StyleCode"].ToString();
            }
            LineNoId = Convert.ToInt32(LineNo.Replace("Line ", ""));
            ViewState["RowCount"] = null;

            if (!IsPostBack)
            {
                lblFactory.Text = "'" + UnitName + "'";
                //lblFloorNo.Text = "'" + FloorNo + "'";
                lblLineNo.Text = "'" + LineNo + "'";

                FillStyleCode(UnitId, LineNoId);

                if (StyleCode != "")
                {
                    ddlStyleCode.SelectedValue = Convert.ToString(StyleCode);
                    ddlStyleCode.Enabled = false;
                    lblSam.Visible = true;
                    lblSamLabel.Visible = true;
                    lblOB.Visible = true;
                    lblOBLabel.Visible = true;

                    lblFinishSam.Visible = true;
                    lblFinishSamLabel.Visible = true;
                    lblFinishOB.Visible = true;
                    lblFinishOBLabel.Visible = true;

                    btnSubmit.Visible = true;
                    gvNextChangeOverStyleDetail.Visible = true;
                    tdMessage.Visible = true;
                    trSubmit.Visible = true;
                    SetInitialRow();

                    //if (LinePlanFrameId > 0) commented by Gajendra on 26-07-2016
                    //{
                    //  if (CheckIsHalfStitched(LinePlanFrameId))
                    //  {
                    //    gvNextChangeOverStyleDetail.Enabled = false;
                    //  }
                    //}
                }
            }
            
          
        }
      
        private bool CheckIsHalfStitched(int LinePlanFrameId)
        {
            bool IsHalfStitched = false;
            AdminController oAdminController = new AdminController();
            IsHalfStitched = oAdminController.CheckIsHalfStitched(LinePlanFrameId);
            oAdminController = null;

            return IsHalfStitched;
        }

        private void FillStyleCode(int UnitId, int LineNumber)
        {
            AdminController oAdminController = new AdminController();
            ddlStyleCode.DataSource = oAdminController.GetStyleCodeDetails(UnitId, LineNumber, Convert.ToString(Request.QueryString["status"]), "");
            ddlStyleCode.DataValueField = "StyleCode";
            ddlStyleCode.DataTextField = "StyleCode";
            ddlStyleCode.DataBind();
            ddlStyleCode.Items.Insert(0, new ListItem("-- Select --", "0"));
            oAdminController = null;
        }


        //private void FillStyleNo(int UnitId)
        //{
        //    AdminController oAdminController = new AdminController();
        //    ddlStyleCode.DataSource = oAdminController.GetStyleCodeDetails(UnitId, Convert.ToString(Request.QueryString["status"]));
        //    ddlStyleCode.DataValueField = "StyleCode";
        //    ddlStyleCode.DataTextField = "StyleCode";
        //    ddlStyleCode.DataBind();
        //    ddlStyleCode.Items.Insert(0, new ListItem("-- Select --", "0"));
        //    oAdminController = null;
        //}

        private void FillSlot(DropDownList ddlSlot)
        {
            AdminController oAdminController = new AdminController();
            ddlSlot.DataSource = oAdminController.GetSlot();
            ddlSlot.DataValueField = "SlotID";
            ddlSlot.DataTextField = "SlotName";
            ddlSlot.DataBind();
            ddlSlot.Items.Insert(0, new ListItem("Select", "0"));
            oAdminController = null;
        }

        protected void ddlStyleCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlStyleCode.SelectedValue != "0")
            {
                lblSam.Visible = true;
                lblSamLabel.Visible = true;
                lblOB.Visible = true;
                lblOBLabel.Visible = true;

                lblFinishSam.Visible = true;
                lblFinishSamLabel.Visible = true;
                lblFinishOB.Visible = true;
                lblFinishOBLabel.Visible = true;

                btnSubmit.Visible = true;
                gvNextChangeOverStyleDetail.Visible = true;
                tdMessage.Visible = true;
                trSubmit.Visible = true;
                //GetStyleSam_OB(Convert.ToInt32(ddlStyleCode.SelectedValue));
                StyleCode = ddlStyleCode.SelectedValue;
                SetInitialRow();
                //trSlot.Visible = true;
                //FillSlot(ddlSlot);
            }
            else
            {
                lblSam.Visible = false;
                lblSamLabel.Visible = false;
                lblOB.Visible = false;
                lblOBLabel.Visible = false;

                lblFinishSam.Visible = false;
                lblFinishSamLabel.Visible = false;
                lblFinishOB.Visible = false;
                lblFinishOBLabel.Visible = false;

                btnSubmit.Visible = false;
                gvNextChangeOverStyleDetail.Visible = false;
                tdMessage.Visible = false;
                trSubmit.Visible = false;
                //trSlot.Visible = false;

                //lblSlot.Text = "";
            }
        }

        //protected void ddlSlot_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //  AdminController oAdminController = new AdminController();
        //  if (Convert.ToInt32(ddlSlot.SelectedValue) > 0)
        //  {
        //    DataTable dtSlot = oAdminController.GetSlot();
        //    DataView dvSlot = new DataView(dtSlot);
        //    dvSlot.RowFilter = "SlotID = " + Convert.ToInt32(ddlSlot.SelectedValue);
        //    lblSlot.Text = "(" + dvSlot.ToTable().Rows[0]["Period"].ToString() + ")";
        //    lblValidationMessage.Text = "";
        //  }
        //  else
        //  {
        //    lblSlot.Text = "";
        //  } 
        //  oAdminController = null;
        //}

        protected void ddlStyleNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddl = sender as DropDownList;
            GridViewRow row = ddl.NamingContainer as GridViewRow;
            int rowIndex = row.RowIndex;

            AdminController oAdminController = new AdminController();
            DropDownList ddlStyleNo = (DropDownList)gvNextChangeOverStyleDetail.Rows[rowIndex].FindControl("ddlStyleNo");
            DropDownList ddlSerialNo = (DropDownList)gvNextChangeOverStyleDetail.Rows[rowIndex].FindControl("ddlSerialNo");
            DropDownList ddlContract = (DropDownList)gvNextChangeOverStyleDetail.Rows[rowIndex].FindControl("ddlContract");

            Label lblExFactoryDate = (Label)gvNextChangeOverStyleDetail.Rows[rowIndex].FindControl("lblExFactoryDate");
            Label lblContractQty = (Label)gvNextChangeOverStyleDetail.Rows[rowIndex].FindControl("lblContractQty");
            Label lblUnitQty = (Label)gvNextChangeOverStyleDetail.Rows[rowIndex].FindControl("lblUnitQty");
            TextBox txtLineQty = (TextBox)gvNextChangeOverStyleDetail.Rows[rowIndex].FindControl("txtLineQty");

            Label lblStitchSam = (Label)gvNextChangeOverStyleDetail.Rows[rowIndex].FindControl("lblStitchSam");
            Label lblstOB = (Label)gvNextChangeOverStyleDetail.Rows[rowIndex].FindControl("lblstOB");
            Label lblFinishSam = (Label)gvNextChangeOverStyleDetail.Rows[rowIndex].FindControl("lblFinishSam");
            Label lblFinOB = (Label)gvNextChangeOverStyleDetail.Rows[rowIndex].FindControl("lblFinOB");
            CheckBox chkDblOBStitch = (CheckBox)gvNextChangeOverStyleDetail.Rows[rowIndex].FindControl("chkDblOBStitch");
            CheckBox chkDblOBFinish = (CheckBox)gvNextChangeOverStyleDetail.Rows[rowIndex].FindControl("chkDblOBFinish");

            if (Convert.ToInt32(ddlStyleNo.SelectedValue) > 0)
            {
                ddlSerialNo.Enabled = true;
                ddlSerialNo.Items.Clear();
                ddlSerialNo.DataSource = oAdminController.GetSerialNumber(UnitId, Convert.ToInt32(ddlStyleNo.SelectedValue), Convert.ToString("add"));
                ddlSerialNo.DataValueField = "Id";
                ddlSerialNo.DataTextField = "SerialNumber";
                ddlSerialNo.DataBind();
                ddlSerialNo.Items.Insert(0, new ListItem("Select", "0"));

                ddlContract.Items.Clear();
                ddlContract.Items.Insert(0, new ListItem("Select", "0"));
                lblValidationMessage.Text = "";

                lblExFactoryDate.Text = "";
                lblContractQty.Text = "";
                lblUnitQty.Text = "";
                txtLineQty.Text = "";
                lblStitchSam.Text = "";
                lblstOB.Text = "";
                lblFinishSam.Text = "";
                lblFinOB.Text = "";
                chkDblOBStitch.Checked = false;
                chkDblOBFinish.Checked = false;

                //for (int i = 0; i < gvNextChangeOverStyleDetail.Rows.Count; i++)
                //{
                //    DropDownList ddlCheckContract = (DropDownList)gvNextChangeOverStyleDetail.Rows[i].FindControl("ddlContract");
                //    var contracts = ddlCheckContract.SelectedValue;

                //    if (Convert.ToInt32(contracts) != 0)
                //    {
                //        ddlContract.Items.Remove(ddlContract.Items.FindByValue(contracts));
                //    }
                //}
                Label lblTotalContractQty = (Label)gvNextChangeOverStyleDetail.FooterRow.FindControl("lblTotalContractQty");
                Label lblTotalUnitQty = (Label)gvNextChangeOverStyleDetail.FooterRow.FindControl("lblTotalUnitQty");
                lblTotalContractQty.Text = "";
                lblTotalUnitQty.Text = "";
            }
            else
            {
                ddlSerialNo.Enabled = false;
            }
            oAdminController = null;
        }

        protected void ddlSerialNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddl = sender as DropDownList;
            GridViewRow row = ddl.NamingContainer as GridViewRow;
            int rowIndex = row.RowIndex;

            AdminController oAdminController = new AdminController();
            DropDownList ddlSerialNo = (DropDownList)gvNextChangeOverStyleDetail.Rows[rowIndex].FindControl("ddlSerialNo");
            DropDownList ddlContract = (DropDownList)gvNextChangeOverStyleDetail.Rows[rowIndex].FindControl("ddlContract");

            Label lblExFactoryDate = (Label)gvNextChangeOverStyleDetail.Rows[rowIndex].FindControl("lblExFactoryDate");
            Label lblContractQty = (Label)gvNextChangeOverStyleDetail.Rows[rowIndex].FindControl("lblContractQty");
            Label lblUnitQty = (Label)gvNextChangeOverStyleDetail.Rows[rowIndex].FindControl("lblUnitQty");
            TextBox txtLineQty = (TextBox)gvNextChangeOverStyleDetail.Rows[rowIndex].FindControl("txtLineQty");

            Label lblStitchSam = (Label)gvNextChangeOverStyleDetail.Rows[rowIndex].FindControl("lblStitchSam");
            Label lblstOB = (Label)gvNextChangeOverStyleDetail.Rows[rowIndex].FindControl("lblstOB");
            Label lblFinishSam = (Label)gvNextChangeOverStyleDetail.Rows[rowIndex].FindControl("lblFinishSam");
            Label lblFinOB = (Label)gvNextChangeOverStyleDetail.Rows[rowIndex].FindControl("lblFinOB");
            CheckBox chkDblOBStitch = (CheckBox)gvNextChangeOverStyleDetail.Rows[rowIndex].FindControl("chkDblOBStitch");
            CheckBox chkDblOBFinish = (CheckBox)gvNextChangeOverStyleDetail.Rows[rowIndex].FindControl("chkDblOBFinish");

            if (Convert.ToInt32(ddlSerialNo.SelectedValue) > 0)
            {
                ddlContract.Enabled = true;
                ddlContract.Items.Clear();
                ddlContract.DataSource = oAdminController.GetContract(UnitId, Convert.ToInt32(ddlSerialNo.SelectedValue), Convert.ToString("add"), LineNoId);
                ddlContract.DataValueField = "Id";
                ddlContract.DataTextField = "ContractNumber";
                ddlContract.DataBind();
                ddlContract.Items.Insert(0, new ListItem("Select", "0"));
                lblValidationMessage.Text = "";

                lblExFactoryDate.Text = "";
                lblContractQty.Text = "";
                lblUnitQty.Text = "";
                txtLineQty.Text = "";
                lblStitchSam.Text = "";
                lblstOB.Text = "";
                lblFinishSam.Text = "";
                lblFinOB.Text = "";
                chkDblOBStitch.Checked = false;
                chkDblOBFinish.Checked = false;

                //for (int i = 0; i < gvNextChangeOverStyleDetail.Rows.Count; i++)
                //{
                //    DropDownList ddlCheckContract = (DropDownList)gvNextChangeOverStyleDetail.Rows[i].FindControl("ddlContract");
                //    var contracts = ddlCheckContract.SelectedValue;

                //    if (Convert.ToInt32(contracts) !=0)
                //    {
                //        ddlContract.Items.Remove(ddlContract.Items.FindByValue(contracts));
                //    }
                //}
                Label lblTotalContractQty = (Label)gvNextChangeOverStyleDetail.FooterRow.FindControl("lblTotalContractQty");
                Label lblTotalUnitQty = (Label)gvNextChangeOverStyleDetail.FooterRow.FindControl("lblTotalUnitQty");
                lblTotalContractQty.Text = "";
                lblTotalUnitQty.Text = "";
            }
            else
            {
                ddlContract.Enabled = false;
            }
            oAdminController = null;
        }

        protected void ddlContract_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddl = sender as DropDownList;
            GridViewRow row = ddl.NamingContainer as GridViewRow;
            int rowIndex = row.RowIndex;
            int TotalContractQty = 0, TotalUnitQty = 0;

            AdminController oAdminController = new AdminController();
            DropDownList ddlStyleNo = (DropDownList)gvNextChangeOverStyleDetail.Rows[rowIndex].FindControl("ddlStyleNo");
            DropDownList ddlSerialNo = (DropDownList)gvNextChangeOverStyleDetail.Rows[rowIndex].FindControl("ddlSerialNo");
            DropDownList ddlContract = (DropDownList)gvNextChangeOverStyleDetail.Rows[rowIndex].FindControl("ddlContract");

            Label lblExFactoryDate = (Label)gvNextChangeOverStyleDetail.Rows[rowIndex].FindControl("lblExFactoryDate");
            Label lblContractQty = (Label)gvNextChangeOverStyleDetail.Rows[rowIndex].FindControl("lblContractQty");
            Label lblUnitQty = (Label)gvNextChangeOverStyleDetail.Rows[rowIndex].FindControl("lblUnitQty");
            TextBox txtLineQty = (TextBox)gvNextChangeOverStyleDetail.Rows[rowIndex].FindControl("txtLineQty");

            Label lblStitchSam = (Label)gvNextChangeOverStyleDetail.Rows[rowIndex].FindControl("lblStitchSam");
            Label lblstOB = (Label)gvNextChangeOverStyleDetail.Rows[rowIndex].FindControl("lblstOB");
            Label lblFinishSam = (Label)gvNextChangeOverStyleDetail.Rows[rowIndex].FindControl("lblFinishSam");
            Label lblFinOB = (Label)gvNextChangeOverStyleDetail.Rows[rowIndex].FindControl("lblFinOB");
            CheckBox chkDblOBStitch = (CheckBox)gvNextChangeOverStyleDetail.Rows[rowIndex].FindControl("chkDblOBStitch");
            CheckBox chkDblOBFinish = (CheckBox)gvNextChangeOverStyleDetail.Rows[rowIndex].FindControl("chkDblOBFinish");

            for (int i = 0; i < gvNextChangeOverStyleDetail.Rows.Count; i++)
            {
                DropDownList ddlCheckContract = (DropDownList)gvNextChangeOverStyleDetail.Rows[i].FindControl("ddlContract");
                if (Convert.ToInt32(ddlContract.SelectedValue) == Convert.ToInt32(ddlCheckContract.SelectedValue) && i != rowIndex)
                {
                    lblValidationMessage.Text = "Contract No. cannot be repeat. Please Check.";
                    ddlContract.SelectedValue = "0";
                    return;
                }
            }

            if (Convert.ToInt32(ddlContract.SelectedValue) > 0)
            {
                DataTable dtStyleSam_OB = oAdminController.GetStyleSam_OB(Convert.ToInt32(ddlStyleNo.SelectedValue));
                if (dtStyleSam_OB.Rows.Count > 0)
                {
                    lblStitchSam.Text = dtStyleSam_OB.Rows[0]["Sam"].ToString();
                    lblstOB.Text = dtStyleSam_OB.Rows[0]["OB"].ToString();

                    if (Convert.ToDecimal(dtStyleSam_OB.Rows[0]["FinishSam"]) > 0)
                    {
                        lblFinishSam.Text = dtStyleSam_OB.Rows[0]["FinishSam"].ToString();
                        lblFinOB.Text = dtStyleSam_OB.Rows[0]["FinishOB"].ToString();
                    }
                    else
                    {
                        lblFinishSam.Visible = false;
                        lblFinOB.Visible = false;
                    }
                }

                DataTable dt = oAdminController.GetDateAndQty(UnitId, Convert.ToInt32(ddlSerialNo.SelectedValue), Convert.ToInt32(ddlContract.SelectedValue), Convert.ToString(Request.QueryString["status"]), LineNoId);

                lblExFactoryDate.Text = dt.Rows[0]["ExFactory"].ToString();
                lblContractQty.Text = dt.Rows[0]["ContractQty"].ToString();
                lblUnitQty.Text = dt.Rows[0]["UnitQty"].ToString();
                txtLineQty.Text = dt.Rows[0]["LineQty"].ToString();
                txtLineQty.Enabled = true;
                lblValidationMessage.Text = "";

                lblContractQty.Text = lblContractQty.Text == "" ? "0" : lblContractQty.Text;
                lblUnitQty.Text = lblUnitQty.Text == "" ? "0" : lblUnitQty.Text;
                txtLineQty.Text = txtLineQty.Text == "" ? "0" : txtLineQty.Text;

                TotalContractQty = Convert.ToInt32(ViewState["lblTotalContractQty"]) + Convert.ToInt32(lblContractQty.Text);
                TotalUnitQty = Convert.ToInt32(ViewState["lblTotalUnitQty"]) + Convert.ToInt32(lblUnitQty.Text);
            }
            else
            {
                lblExFactoryDate.Text = "";
                lblContractQty.Text = "";
                lblUnitQty.Text = "";
                txtLineQty.Text = "";
                txtLineQty.Enabled = true;
            }
            Label lblTotalContractQty = (Label)gvNextChangeOverStyleDetail.FooterRow.FindControl("lblTotalContractQty");
            Label lblTotalUnitQty = (Label)gvNextChangeOverStyleDetail.FooterRow.FindControl("lblTotalUnitQty");

            lblTotalContractQty.Text = TotalContractQty.ToString();
            lblTotalUnitQty.Text = TotalUnitQty.ToString();
            oAdminController = null;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            int iCountLinePlanning = 0; lblValidationMessage.Text = "";
            int OrderDetailId = 0, OrderId = 0, FloorNoId = 0, SlotId = 0, ContractQty = 0, UnitQty = 0, LineQty = 0;
            DateTime StartDate;

            AdminController oAdminController = new AdminController();

            FloorNoId = FloorNo == "First" ? 1 : FloorNo == "Second" ? 2 : FloorNo == "Third" ? 3 : 4;

            int TotalLineQty = 0;
            lblValidationMessage.Text = "";
            for (int i = 0; i < gvNextChangeOverStyleDetail.Rows.Count; i++)
            {
                DropDownList ddlSerialNo = (DropDownList)gvNextChangeOverStyleDetail.Rows[i].FindControl("ddlSerialNo");
                DropDownList ddlContract = (DropDownList)gvNextChangeOverStyleDetail.Rows[i].FindControl("ddlContract");
                Label lblContractQty = (Label)gvNextChangeOverStyleDetail.Rows[i].FindControl("lblContractQty");
                Label lblUnitQty = (Label)gvNextChangeOverStyleDetail.Rows[i].FindControl("lblUnitQty");
                TextBox txtLineQty = (TextBox)gvNextChangeOverStyleDetail.Rows[i].FindControl("txtLineQty");

                TextBox txtStartDate = (TextBox)gvNextChangeOverStyleDetail.Rows[i].FindControl("txtStartDate");
                DropDownList ddlSlot = (DropDownList)gvNextChangeOverStyleDetail.Rows[i].FindControl("ddlSlot");
                Label lblEndDate = (Label)gvNextChangeOverStyleDetail.Rows[i].FindControl("lblEndDate");

                OrderId = Convert.ToInt32(ddlSerialNo.SelectedValue);
                OrderDetailId = Convert.ToInt32(ddlContract.SelectedValue);
                ContractQty = lblContractQty.Text == "" ? 0 : Convert.ToInt32(lblContractQty.Text);
                UnitQty = lblUnitQty.Text == "" ? 0 : Convert.ToInt32(lblUnitQty.Text);
                LineQty = txtLineQty.Text == "" ? 0 : Convert.ToInt32(txtLineQty.Text);
                var IshalfStitch = false; ;
                if (ViewState["IshalfStitch"] == null)
                {
                    IshalfStitch = CheckIsHalfStitched(LinePlanFrameId);
                    ViewState["IshalfStitch"] = IshalfStitch;
                }


                if (LinePlanFrameId > 0 && Convert.ToBoolean(ViewState["IshalfStitch"]))
                    TotalLineQty = LineQty;
                else
                    TotalLineQty = oAdminController.TotalLineQty(UnitId, LineNoId, OrderDetailId) + LineQty;

                //-------------------------------
                //if (i == 0)
                //{
                SlotId = Convert.ToInt32(ddlSlot.SelectedValue);

                if (txtStartDate.Text == "")
                {
                    lblValidationMessage.Text = "Start Date cannot be blank.";
                    return;
                }
                else
                {
                    StartDate = Convert.ToDateTime(txtStartDate.Text, new CultureInfo("en-GB"));
                }

                if (SlotId == 0)
                {
                    lblValidationMessage.Text = "Please select a slot.";
                    return;
                }
                //if (ddlSlot.Enabled == true)//ddlSerialNo.Enabled == true && ddlContract.Enabled == true &&
                //{
                //    if (oAdminController.CheckStartDate(StartDate, SlotId) <= DateTime.Now)
                //    {
                //        lblValidationMessage.Text = "You cannot scheduled this task at this time.";
                //        return;
                //    }
                //}
                //}
                //------------------------------------

                if (OrderId == 0)
                {
                    lblValidationMessage.Text = "Please select Serial No.";
                    return;
                }
                else if (OrderDetailId == 0)
                {
                    lblValidationMessage.Text = "Please select Contract No.";
                    return;
                }
                else if (LineQty == 0)
                {
                    lblValidationMessage.Text = "Line Qty cannot be blank.";
                    return;
                }
                else if (LineQty > UnitQty)
                {
                    lblValidationMessage.Text = "Line Qty cannot be greater than Unit Qty.";
                    return;
                }
                else if (TotalLineQty > UnitQty)
                {
                    lblValidationMessage.Text = "Total Line Qty in all lines cannot be greater than Unit Qty. Please Check.";
                    return;
                }
                else
                {
                    iCountLinePlanning = oAdminController.CheckLinePlanning(UnitId, FloorNoId, LineNoId, Convert.ToInt32(ddlStyleCode.SelectedValue), OrderDetailId);
                    if (iCountLinePlanning > 0)
                    {
                        if (Convert.ToString(Request.QueryString["status"]) == "add")
                        {
                            lblValidationMessage.Text = "This Contrat is already available for to be worked or in working state. Please Check.";
                            return;
                        }
                    }
                }
            }

            //if (Convert.ToString(Request.QueryString["status"]) == "update")
            //{
            //    oAdminController.DeleteLinePlanning_Update(UnitId, FloorNoId, LineNoId, Convert.ToInt32(ddlStyleCode.SelectedValue), LinePlanFrameId);
            //}

            for (int i = 0; i < gvNextChangeOverStyleDetail.Rows.Count; i++)
            {
                DropDownList ddlSerialNo = (DropDownList)gvNextChangeOverStyleDetail.Rows[i].FindControl("ddlSerialNo");
                DropDownList ddlContract = (DropDownList)gvNextChangeOverStyleDetail.Rows[i].FindControl("ddlContract");
                Label lblContractQty = (Label)gvNextChangeOverStyleDetail.Rows[i].FindControl("lblContractQty");
                Label lblUnitQty = (Label)gvNextChangeOverStyleDetail.Rows[i].FindControl("lblUnitQty");
                TextBox txtLineQty = (TextBox)gvNextChangeOverStyleDetail.Rows[i].FindControl("txtLineQty");

                TextBox txtStartDate = (TextBox)gvNextChangeOverStyleDetail.Rows[i].FindControl("txtStartDate");
                DropDownList ddlSlot = (DropDownList)gvNextChangeOverStyleDetail.Rows[i].FindControl("ddlSlot");
                Label lblEndDate = (Label)gvNextChangeOverStyleDetail.Rows[i].FindControl("lblEndDate");

                OrderId = Convert.ToInt32(ddlSerialNo.SelectedValue);
                OrderDetailId = Convert.ToInt32(ddlContract.SelectedValue);
                ContractQty = Convert.ToInt32(lblContractQty.Text);
                UnitQty = Convert.ToInt32(lblUnitQty.Text);
                LineQty = txtLineQty.Text == "" ? 0 : Convert.ToInt32(txtLineQty.Text);

                // Comment By Ravi kumar on 6-Mar-2017 for Manual Start Date
                //if(i==0)
                //    StartDate = Convert.ToDateTime(txtStartDate.Text, new CultureInfo("en-GB"));          
                //else
                //    StartDate = Convert.ToDateTime("1/1/1900", new CultureInfo("en-GB"));  

                StartDate = Convert.ToDateTime(txtStartDate.Text, new CultureInfo("en-GB"));
                SlotId = Convert.ToInt32(ddlSlot.SelectedValue);
                if (txtStartDate.Enabled == true)
                {
                    if (txtLineQty.Enabled == true) //ddlContract.Enabled == true &&
                    {
                        var OB = string.IsNullOrEmpty(lblOB.Text) ? "0" : lblOB.Text;
                        var FinishSam = string.IsNullOrEmpty(lblFinishSam.Text) ? "0" : lblFinishSam.Text;
                        var FinishOB = string.IsNullOrEmpty(lblFinishOB.Text) ? "0" : lblFinishOB.Text;
                        
                        //oAdminController.InsertLinePlanning(UnitId, FloorNoId, LineNoId, Convert.ToInt32(ddlStyleCode.SelectedValue), OrderId, OrderDetailId, StartDate, SlotId, ContractQty, StichedQty, StichedPer, UnitQty, LineQty, Convert.ToDecimal(lblSam.Text), LinePlanFrameId, CombinedFrameId, UserId, Convert.ToBoolean(ViewState["IshalfStitch"]),
                        //     Convert.ToInt32(OB), Convert.ToDecimal(FinishSam), Convert.ToInt32(FinishOB), DoubleOB_Stitch, DoubleOB_Finish);
                        //oAdminController.UpdateEndDate();
                    }
                }
                //if (Convert.ToInt32(Request.QueryString["ProductionUnit"]) > 0 && Convert.ToString(Request.QueryString["Enabled"]) == "false")
                //{
                //  ScriptManager.RegisterStartupScript(this, this.GetType(), "Close", "window.top.location.replace('/Admin/FactorySpecificLinePlanning.aspx?ProductionUnit=" + Convert.ToInt32(Request.QueryString["ProductionUnit"]) + "&Enabled=false');", true);
                //}
                //else
                //{
                //  ScriptManager.RegisterStartupScript(this, this.GetType(), "Close", "window.top.location.replace('/Admin/FactorySpecificLinePlanning.aspx?ProductionUnit=" + Convert.ToInt32(Request.QueryString["ProductionUnit"]) + "');", true);
                //}
            }
            if (Convert.ToInt32(Request.QueryString["ProductionUnit"]) > 0 && Convert.ToString(Request.QueryString["Enabled"]) == "false")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Close", "window.top.location.replace('/Admin/FactorySpecificLinePlanning.aspx?ProductionUnit=" + Convert.ToInt32(Request.QueryString["ProductionUnit"]) + "&Enabled=false');", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Close", "window.top.location.replace('/Admin/FactorySpecificLinePlanning.aspx?ProductionUnit=" + Convert.ToInt32(Request.QueryString["ProductionUnit"]) + "');", true);
            }
            oAdminController = null;
        }

        private void GetStyleSam_OB(int StyleId)
        {
            AdminController oAdminController = new AdminController();
            DataTable dtStyleSam_OB = oAdminController.GetStyleSam_OB(StyleId);
            if (dtStyleSam_OB.Rows.Count > 0)
            {
                lblSam.Text = dtStyleSam_OB.Rows[0]["Sam"].ToString();
                lblOB.Text = dtStyleSam_OB.Rows[0]["OB"].ToString();

                if (Convert.ToDecimal(dtStyleSam_OB.Rows[0]["FinishSam"]) > 0)
                {
                    lblFinishSam.Text = dtStyleSam_OB.Rows[0]["FinishSam"].ToString();
                    lblFinishOB.Text = dtStyleSam_OB.Rows[0]["FinishOB"].ToString();
                }
                else
                {
                    lblFinishSam.Visible = false;
                    lblFinishOB.Visible = false;
                    lblFinishSamLabel.Visible = false;
                    lblFinishOBLabel.Visible = false;
                }

            }
            if (lblSam.Text == "")
            {
                lblSamLabel.Visible = false;
            }
            if (lblOB.Text == "")
            {
                lblOBLabel.Visible = false;
            }

            //if (lblFinishSam.Text == "")
            //{
            //    lblFinishSamLabel.Visible = false;
            //}
            //if (lblFinishOB.Text == "")
            //{
            //    lblFinishOBLabel.Visible = false;
            //}

            oAdminController = null;
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            // Comment By Ravi kumar on 6/Mar/2017 for New Rule
            AddNewRow();
            //SetInitialRow();
        }

        private void AddNewRow()
        {
            int rowIndex = 0;
            if (ViewState["dtNextChangeOverStyleDetail"] != null)
            {
                DataTable dtCurrentNextChangeOverStyleDetail = (DataTable)ViewState["dtNextChangeOverStyleDetail"];
                DataRow drCurrentNextChangeOverStyleDetailRow = null;
                if (dtCurrentNextChangeOverStyleDetail.Rows.Count > 0)
                {
                    for (int i = 1; i <= dtCurrentNextChangeOverStyleDetail.Rows.Count; i++)
                    {
                        DropDownList ddlStyleNo = (DropDownList)gvNextChangeOverStyleDetail.Rows[rowIndex].Cells[1].FindControl("ddlStyleNo");
                        DropDownList ddlSerialNo = (DropDownList)gvNextChangeOverStyleDetail.Rows[rowIndex].Cells[2].FindControl("ddlSerialNo");
                        DropDownList ddlContract = (DropDownList)gvNextChangeOverStyleDetail.Rows[rowIndex].Cells[3].FindControl("ddlContract");
                        Label lblExFactoryDate = (Label)gvNextChangeOverStyleDetail.Rows[rowIndex].Cells[4].FindControl("lblExFactoryDate");
                        Label lblContractQty = (Label)gvNextChangeOverStyleDetail.Rows[rowIndex].Cells[5].FindControl("lblContractQty");
                        Label lblUnitQty = (Label)gvNextChangeOverStyleDetail.Rows[rowIndex].Cells[6].FindControl("lblUnitQty");
                        TextBox txtLineQty = (TextBox)gvNextChangeOverStyleDetail.Rows[rowIndex].Cells[7].FindControl("txtLineQty");

                        TextBox txtStartDate = (TextBox)gvNextChangeOverStyleDetail.Rows[rowIndex].Cells[8].FindControl("txtStartDate");
                        DropDownList ddlSlot = (DropDownList)gvNextChangeOverStyleDetail.Rows[rowIndex].Cells[9].FindControl("ddlSlot");
                        Label lblEndDate = (Label)gvNextChangeOverStyleDetail.Rows[rowIndex].Cells[10].FindControl("lblEndDate");

                        Label lblStitchSam = (Label)gvNextChangeOverStyleDetail.Rows[rowIndex].Cells[11].FindControl("lblStitchSam");
                        //Label lblstOB = (Label)gvNextChangeOverStyleDetail.Rows[rowIndex].Cells[11].FindControl("lblstOB");
                        Label lblFinishSam = (Label)gvNextChangeOverStyleDetail.Rows[rowIndex].Cells[12].FindControl("lblFinishSam");
                        //Label lblFinOB = (Label)gvNextChangeOverStyleDetail.Rows[rowIndex].FindControl("lblFinOB");
                        CheckBox chkDblOBStitch = (CheckBox)gvNextChangeOverStyleDetail.Rows[rowIndex].Cells[13].FindControl("chkDblOBStitch");
                        //FillSlot(ddlSlot);


                        int iBlankRow = 0;
                        for (int j = 0; j < gvNextChangeOverStyleDetail.Rows.Count; j++)
                        {
                            if (Convert.ToInt32(ddlStyleNo.SelectedValue) == 0 || Convert.ToInt32(ddlSerialNo.SelectedValue) == 0 || Convert.ToInt32(ddlContract.SelectedValue) == 0)
                            {
                                iBlankRow++;
                            }
                        }

                        if (iBlankRow > 0)
                        {
                            lblValidationMessage.Text = "Blank row need to be filled first";
                            return;
                        }
                        else
                        {
                            lblValidationMessage.Text = "";
                        }

                        drCurrentNextChangeOverStyleDetailRow = dtCurrentNextChangeOverStyleDetail.NewRow();

                        dtCurrentNextChangeOverStyleDetail.Rows[i - 1]["Column1"] = ddlStyleNo.SelectedValue;
                        dtCurrentNextChangeOverStyleDetail.Rows[i - 1]["Column2"] = ddlContract.SelectedValue;
                        dtCurrentNextChangeOverStyleDetail.Rows[i - 1]["Column3"] = ddlSerialNo.SelectedValue;
                        dtCurrentNextChangeOverStyleDetail.Rows[i - 1]["Column4"] = lblExFactoryDate.Text;
                        dtCurrentNextChangeOverStyleDetail.Rows[i - 1]["Column5"] = lblContractQty.Text;
                        dtCurrentNextChangeOverStyleDetail.Rows[i - 1]["Column6"] = lblUnitQty.Text;
                        dtCurrentNextChangeOverStyleDetail.Rows[i - 1]["Column7"] = txtLineQty.Text;
                        dtCurrentNextChangeOverStyleDetail.Rows[i - 1]["Column8"] = txtStartDate.Text;
                        dtCurrentNextChangeOverStyleDetail.Rows[i - 1]["Column9"] = ddlSlot.SelectedValue;
                        dtCurrentNextChangeOverStyleDetail.Rows[i - 1]["Column10"] = lblEndDate.Text;
                        dtCurrentNextChangeOverStyleDetail.Rows[i - 1]["Column11"] = lblStitchSam.Text;
                        dtCurrentNextChangeOverStyleDetail.Rows[i - 1]["Column12"] = lblFinishSam.Text;
                        dtCurrentNextChangeOverStyleDetail.Rows[i - 1]["Column13"] = chkDblOBStitch.Checked;

                        rowIndex++;
                    }

                    dtCurrentNextChangeOverStyleDetail.Rows.Add(drCurrentNextChangeOverStyleDetailRow);

                    ViewState["dtNextChangeOverStyleDetail"] = dtCurrentNextChangeOverStyleDetail;
                    ViewState["RowCount"] = dtCurrentNextChangeOverStyleDetail.Rows.Count - 1;


                    gvNextChangeOverStyleDetail.DataSource = dtCurrentNextChangeOverStyleDetail;
                    gvNextChangeOverStyleDetail.DataBind();

                    ViewState["RowCount"] = null;
                }
            }
            else
            {
                Response.Write("ViewState is null");
            }

            SetPreviousDataSet();

        }

        private void SetPreviousDataSet()
        {
            int rowIndex = 0;
            int TotalContractQty = 0, TotalUnitQty = 0;

            if (ViewState["dtNextChangeOverStyleDetail"] != null)
            {
                DataTable dtNextChangeOverStyleDetail = (DataTable)ViewState["dtNextChangeOverStyleDetail"];
                if (dtNextChangeOverStyleDetail.Rows.Count > 0)
                {
                    for (int i = 0; i < dtNextChangeOverStyleDetail.Rows.Count; i++)
                    {
                        DropDownList ddlSerialNo = (DropDownList)gvNextChangeOverStyleDetail.Rows[rowIndex].Cells[1].FindControl("ddlSerialNo");
                        DropDownList ddlContract = (DropDownList)gvNextChangeOverStyleDetail.Rows[rowIndex].Cells[2].FindControl("ddlContract");
                        Label lblPCDDate = (Label)gvNextChangeOverStyleDetail.Rows[rowIndex].Cells[3].FindControl("lblPCDDate");
                        Label lblExFactoryDate = (Label)gvNextChangeOverStyleDetail.Rows[rowIndex].Cells[4].FindControl("lblExFactoryDate");
                        Label lblContractQty = (Label)gvNextChangeOverStyleDetail.Rows[rowIndex].Cells[5].FindControl("lblContractQty");
                        Label lblUnitQty = (Label)gvNextChangeOverStyleDetail.Rows[rowIndex].Cells[6].FindControl("lblUnitQty");
                        TextBox txtLineQty = (TextBox)gvNextChangeOverStyleDetail.Rows[rowIndex].Cells[7].FindControl("txtLineQty");

                        TextBox txtStartDate = (TextBox)gvNextChangeOverStyleDetail.Rows[rowIndex].Cells[8].FindControl("txtStartDate");
                        DropDownList ddlSlot = (DropDownList)gvNextChangeOverStyleDetail.Rows[rowIndex].Cells[9].FindControl("ddlSlot");
                        Label lblEndDate = (Label)gvNextChangeOverStyleDetail.Rows[rowIndex].Cells[10].FindControl("lblEndDate");


                        ddlSerialNo.SelectedValue = dtNextChangeOverStyleDetail.Rows[i]["Column1"].ToString();
                        if (Convert.ToInt32(ddlSerialNo.SelectedValue) > 0)
                        {
                            AdminController oAdminController = new AdminController();

                            ddlContract.DataSource = oAdminController.GetContract(UnitId, Convert.ToInt32(ddlSerialNo.SelectedValue), Convert.ToString(Request.QueryString["status"]), LineNoId);
                            ddlContract.DataValueField = "Id";
                            ddlContract.DataTextField = "ContractNumber";
                            ddlContract.DataBind();
                            ddlContract.Items.Insert(0, new ListItem("Select", "0"));
                            //ddlContract.Enabled = true;
                            oAdminController = null;
                            FillSlot(ddlSlot);
                        }
                        ddlContract.SelectedValue = dtNextChangeOverStyleDetail.Rows[i]["Column2"].ToString();
                        lblPCDDate.Text = dtNextChangeOverStyleDetail.Rows[i]["Column3"].ToString();
                        lblExFactoryDate.Text = dtNextChangeOverStyleDetail.Rows[i]["Column4"].ToString();
                        lblContractQty.Text = dtNextChangeOverStyleDetail.Rows[i]["Column5"].ToString();
                        lblUnitQty.Text = dtNextChangeOverStyleDetail.Rows[i]["Column6"].ToString();
                        txtLineQty.Text = dtNextChangeOverStyleDetail.Rows[i]["Column7"].ToString();

                        txtStartDate.Text = dtNextChangeOverStyleDetail.Rows[i]["Column8"].ToString();
                        ddlSlot.SelectedValue = dtNextChangeOverStyleDetail.Rows[i]["Column9"].ToString();
                        lblEndDate.Text = dtNextChangeOverStyleDetail.Rows[i]["Column10"].ToString();
                        //txtStartDate.Enabled = true;
                        //txtStartDate.CssClass = "date-pick";
                        //ddlSlot.Enabled = true;

                        //if (string.IsNullOrEmpty(txtStartDate.Text))
                        //{
                        //    ddlSlot.Visible = false;
                        //    txtStartDate.Visible = false;
                        //}
                        //if (Convert.ToInt32(ddlContract.SelectedValue) > 0)
                        //{
                        //  txtLineQty.Enabled = true;
                        //  //txtStartDate.Enabled = true;
                        //  //ddlSlot.Enabled = true;

                        //}
                        //else
                        //{
                        //  txtLineQty.Enabled = false;
                        //  //txtStartDate.Enabled = false;
                        //  //ddlSlot.Enabled = false;
                        //}

                        lblContractQty.Text = lblContractQty.Text == "" ? "0" : lblContractQty.Text;
                        lblUnitQty.Text = lblUnitQty.Text == "" ? "0" : lblUnitQty.Text;

                        TotalContractQty = TotalContractQty + Convert.ToInt32(lblContractQty.Text);
                        TotalUnitQty = TotalUnitQty + Convert.ToInt32(lblUnitQty.Text);

                        rowIndex++;
                    }

                    Label lblTotalContractQty = (Label)gvNextChangeOverStyleDetail.FooterRow.FindControl("lblTotalContractQty");
                    Label lblTotalUnitQty = (Label)gvNextChangeOverStyleDetail.FooterRow.FindControl("lblTotalUnitQty");

                    ViewState["lblTotalContractQty"] = lblTotalContractQty.Text = TotalContractQty.ToString();
                    ViewState["lblTotalUnitQty"] = lblTotalUnitQty.Text = TotalUnitQty.ToString();
                }
            }
        }

        private void SetInitialRow()
        {
            AdminController oAdminController = new AdminController();
            DataTable dt = new DataTable();
            DataRow dr = null;

            int TotalContractQty = 0, TotalUnitQty = 0;

            dt = oAdminController.GetContractStyleDetail_Grid(UnitId, LineNoId, StyleCode, -1, LinePlanFrameId, 0);//StartDate, SlotId,
            //dt = oAdminController.GetContractStyleDetail(UnitId, LineNo);
            //if (dt.Rows.Count > 0)
            //{
            dt.Columns.Add(new DataColumn("Column1", typeof(string)));
            dt.Columns.Add(new DataColumn("Column2", typeof(string)));
            dt.Columns.Add(new DataColumn("Column3", typeof(string)));
            dt.Columns.Add(new DataColumn("Column4", typeof(string)));
            dt.Columns.Add(new DataColumn("Column5", typeof(string)));
            dt.Columns.Add(new DataColumn("Column6", typeof(string)));
            dt.Columns.Add(new DataColumn("Column7", typeof(string)));
            dt.Columns.Add(new DataColumn("Column8", typeof(string)));
            dt.Columns.Add(new DataColumn("Column9", typeof(string)));
            dt.Columns.Add(new DataColumn("Column10", typeof(string)));
            dt.Columns.Add(new DataColumn("Column11", typeof(string)));
            dt.Columns.Add(new DataColumn("Column12", typeof(string)));
            dt.Columns.Add(new DataColumn("Column13", typeof(string)));

            if (dt.Rows.Count == 0)
            {
                dr = dt.NewRow();

                dr["Column1"] = string.Empty;
                dr["Column2"] = string.Empty;
                dr["Column3"] = string.Empty;
                dr["Column4"] = string.Empty;
                dr["Column5"] = string.Empty;
                dr["Column6"] = string.Empty;
                dr["Column7"] = string.Empty;
                dr["Column8"] = string.Empty;
                dr["Column9"] = string.Empty;
                dr["Column10"] = string.Empty;
                dr["Column11"] = string.Empty;
                dr["Column12"] = string.Empty;
                dr["Column13"] = string.Empty;
                dt.Rows.Add(dr);
            }

            ViewState["dtNextChangeOverStyleDetail"] = dt;

            gvNextChangeOverStyleDetail.DataSource = dt;
            gvNextChangeOverStyleDetail.DataBind();

            if (Convert.ToString(Request.QueryString["status"]) == "update")
            {
                if (Convert.ToBoolean(dt.Rows[0]["IsHalfStich"]))
                {
                    lblSam.Text = dt.Rows[0]["Sam"].ToString();
                    lblOB.Text = dt.Rows[0]["OB"].ToString();
                    if (Convert.ToDecimal(dt.Rows[0]["FinishSam"]) > 0)
                    {
                        lblFinishSam.Text = dt.Rows[0]["FinishSam"].ToString();
                        lblFinishOB.Text = dt.Rows[0]["FinishOB"].ToString();
                    }
                    else
                    {
                        lblFinishSam.Visible = false;
                        lblFinishOB.Visible = false;
                        lblFinishSamLabel.Visible = false;
                        lblFinishOBLabel.Visible = false;
                    }
                }
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DropDownList ddlStyleNo = (DropDownList)gvNextChangeOverStyleDetail.Rows[i].FindControl("ddlStyleNo");
                    DropDownList ddlSerialNo = (DropDownList)gvNextChangeOverStyleDetail.Rows[i].FindControl("ddlSerialNo");
                    DropDownList ddlContract = (DropDownList)gvNextChangeOverStyleDetail.Rows[i].FindControl("ddlContract");
                    Label lblExFactoryDate = (Label)gvNextChangeOverStyleDetail.Rows[i].FindControl("lblExFactoryDate");

                    TextBox txtStartDate = (TextBox)gvNextChangeOverStyleDetail.Rows[i].FindControl("txtStartDate");
                    DropDownList ddlSlot = (DropDownList)gvNextChangeOverStyleDetail.Rows[i].FindControl("ddlSlot");
                    Label lblEndDate = (Label)gvNextChangeOverStyleDetail.Rows[i].FindControl("lblEndDate");

                    Label lblContractQty = (Label)gvNextChangeOverStyleDetail.Rows[i].FindControl("lblContractQty");
                    Label lblUnitQty = (Label)gvNextChangeOverStyleDetail.Rows[i].FindControl("lblUnitQty");
                    TextBox txtLineQty = (TextBox)gvNextChangeOverStyleDetail.Rows[i].FindControl("txtLineQty");

                    Label lblStitchSam = (Label)gvNextChangeOverStyleDetail.Rows[i].FindControl("lblStitchSam");
                    Label lblstOB = (Label)gvNextChangeOverStyleDetail.Rows[i].FindControl("lblstOB");
                    CheckBox chkDblOBStitch = (CheckBox)gvNextChangeOverStyleDetail.Rows[i].FindControl("chkDblOBStitch");
                    CheckBox chkDblOBFinish = (CheckBox)gvNextChangeOverStyleDetail.Rows[i].FindControl("chkDblOBFinish");


                    ddlSerialNo.SelectedValue = Convert.ToString(dt.Rows[i]["OrderID"]);
                    if (Convert.ToInt32(ddlSerialNo.SelectedValue) > 0)
                    {

                        //ddlContract.Enabled = true;
                        ddlContract.Items.Clear();
                        ddlContract.DataSource = oAdminController.GetContract(UnitId, Convert.ToInt32(ddlSerialNo.SelectedValue), Convert.ToString(Request.QueryString["status"]), LineNoId);
                        ddlContract.DataValueField = "Id";
                        ddlContract.DataTextField = "ContractNumber";
                        ddlContract.DataBind();
                        ddlContract.Items.Insert(0, new ListItem("Select", "0"));
                        lblValidationMessage.Text = "";

                        ddlContract.SelectedValue = Convert.ToString(dt.Rows[i]["OrderDetailsID"]);
                        if (Convert.ToInt32(ddlContract.SelectedValue) > 0)
                        {
                            DataTable dtDateAndQty = oAdminController.GetDateAndQty(UnitId, Convert.ToInt32(ddlSerialNo.SelectedValue), Convert.ToInt32(ddlContract.SelectedValue), Convert.ToString(Request.QueryString["status"]), LineNoId);

                            lblExFactoryDate.Text = dtDateAndQty.Rows[0]["ExFactory"].ToString();
                            lblContractQty.Text = dtDateAndQty.Rows[0]["ContractQty"].ToString();
                            lblUnitQty.Text = dtDateAndQty.Rows[0]["UnitQty"].ToString();
                            txtLineQty.Text = dtDateAndQty.Rows[0]["LineQty"].ToString();
                            //txtLineQty.Enabled = true;
                            lblValidationMessage.Text = "";

                            lblContractQty.Text = lblContractQty.Text == "" ? "0" : lblContractQty.Text;
                            lblUnitQty.Text = lblUnitQty.Text == "" ? "0" : lblUnitQty.Text;
                            txtLineQty.Text = txtLineQty.Text == "" ? "0" : txtLineQty.Text;

                            TotalContractQty = TotalContractQty + Convert.ToInt32(lblContractQty.Text);
                            TotalUnitQty = TotalUnitQty + Convert.ToInt32(lblUnitQty.Text);

                            FillSlot(ddlSlot);
                            ddlSlot.SelectedValue = Convert.ToString(dt.Rows[i]["SlotId"]);
                            txtStartDate.Text = Convert.ToDateTime(dt.Rows[i]["StartDate"]).ToString("dd/MM/yyyy");
                            lblEndDate.Text = dt.Rows[i]["EndDate"].ToString();

                            chkDblOBStitch.Checked = dt.Rows[0]["DoubleOB_Stitch"].ToString() == "" ? false : Convert.ToBoolean(dt.Rows[0]["DoubleOB_Stitch"]);
                            chkDblOBFinish.Checked = dt.Rows[0]["DoubleOB_Finish"].ToString() == "" ? false : Convert.ToBoolean(dt.Rows[0]["DoubleOB_Finish"]);
                        }
                        else
                        {
                            lblExFactoryDate.Text = "";
                            lblContractQty.Text = "";
                            lblUnitQty.Text = "";
                            txtLineQty.Text = "";

                            txtStartDate.Text = "";
                            lblEndDate.Text = "";
                            ddlSlot.Text = "";

                        }
                    }
                    else
                    {
                        ddlContract.Enabled = false;
                    }
                }
                if (dt.Rows.Count > 0)
                {
                    //chkDoubleOB_Stitch.Checked = dt.Rows[0]["DoubleOB_Stitch"].ToString() == "" ? false : Convert.ToBoolean(dt.Rows[0]["DoubleOB_Stitch"]);
                    //chkDoubleOB_Finish.Checked = dt.Rows[0]["DoubleOB_Finish"].ToString() == "" ? false : Convert.ToBoolean(dt.Rows[0]["DoubleOB_Finish"]);
                }

                Label lblTotalContractQty = (Label)gvNextChangeOverStyleDetail.FooterRow.FindControl("lblTotalContractQty");
                Label lblTotalUnitQty = (Label)gvNextChangeOverStyleDetail.FooterRow.FindControl("lblTotalUnitQty");

                ViewState["lblTotalContractQty"] = lblTotalContractQty.Text = TotalContractQty.ToString();
                ViewState["lblTotalUnitQty"] = lblTotalUnitQty.Text = TotalUnitQty.ToString();
            }
            //}
        }

        protected void gvNextChangeOverStyleDetail_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[0].ColumnSpan = 2;
                e.Row.Cells.RemoveAt(2);
                e.Row.Cells[0].BackColor = System.Drawing.Color.FromName("#405D99");
                e.Row.Cells[0].ForeColor = System.Drawing.Color.FromName("#FFFFFF");
                e.Row.Cells[0].Text = "Total";
                e.Row.Cells[0].HorizontalAlign = HorizontalAlign.Center;
                e.Row.Cells[0].Font.Size = 10;
                e.Row.Cells[0].Font.Bold = true;
            }
        }

        int TotalContractQty = 0, TotalUnitQty = 0;


        protected void gvNextChangeOverStyleDetail_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            AdminController oAdminController = new AdminController();
            string Status = "update";
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int iRowIndex = e.Row.RowIndex;

                if (ViewState["RowCount"] != null)
                {
                    if (iRowIndex == Convert.ToInt32(ViewState["RowCount"]))
                        Status = "add";
                }
                DropDownList ddlStyleNo = (DropDownList)e.Row.FindControl("ddlStyleNo");
                DropDownList ddlSerialNo = (DropDownList)e.Row.FindControl("ddlSerialNo");
                DropDownList ddlContract = (DropDownList)e.Row.FindControl("ddlContract");
                Label lblPCDDate = (Label)e.Row.FindControl("lblPCDDate");
                Label lblExFactoryDate = (Label)e.Row.FindControl("lblExFactoryDate");
                Label lblContractQty = (Label)e.Row.FindControl("lblContractQty");
                Label lblUnitQty = (Label)e.Row.FindControl("lblUnitQty");
                TextBox txtLineQty = (TextBox)e.Row.FindControl("txtLineQty");

                TextBox txtStartDate = (TextBox)e.Row.FindControl("txtStartDate");
                DropDownList ddlSlot = (DropDownList)e.Row.FindControl("ddlSlot");
                Label lblEndDate = (Label)e.Row.FindControl("lblEndDate");
                HiddenField hdnfldCheckStartDate = (HiddenField)e.Row.FindControl("hdnfldCheckStartDate");
                HiddenField hdnIsStitching = (HiddenField)e.Row.FindControl("hdnIsStitching");

                if ((hdnIsStitching.Value == "0") || (hdnIsStitching.Value == ""))
                {
                    txtStartDate.CssClass = "date-pick";
                    txtStartDate.Enabled = true;
                    ddlSlot.Enabled = true;
                }
                else if (hdnIsStitching.Value == "1")
                {
                    txtStartDate.Enabled = false;
                    ddlSlot.Enabled = false;
                }
                ddlStyleNo.DataSource = oAdminController.GetStyleDetails(UnitId, LineNoId, ddlStyleCode.SelectedValue, Convert.ToString(Status));
                ddlStyleNo.DataValueField = "Id";
                ddlStyleNo.DataTextField = "StyleNumber";
                ddlStyleNo.DataBind();
                ddlStyleNo.Items.Insert(0, new ListItem("Select", "0"));
                ddlSerialNo.Items.Insert(0, new ListItem("Select", "0"));
                ddlContract.Items.Insert(0, new ListItem("Select", "0"));

                //ddlSerialNo.DataSource = oAdminController.GetSerialNumber(UnitId, Convert.ToInt32(ddlStyleCode.SelectedValue), Convert.ToString(Status));
                //ddlSerialNo.DataValueField = "Id";
                //ddlSerialNo.DataTextField = "SerialNumber";
                //ddlSerialNo.DataBind();
                //ddlSerialNo.Items.Insert(0, new ListItem("Select", "0"));
                //ddlContract.Items.Insert(0, new ListItem("Select", "0"));

                FillSlot(ddlSlot);

                //ddlSerialNo.SelectedValue = ((DataRowView)e.Row.DataItem)["SerialId"].ToString();
                //ddlContract.SelectedValue = ((DataRowView)e.Row.DataItem)["ContractId"].ToString();

                //if (Convert.ToString(ViewState["delete"]) == "delete")
                //{
                //  ddlSerialNo.SelectedValue = ((DataRowView)e.Row.DataItem)["SerialId"].ToString();
                //  if (Convert.ToInt32(ddlSerialNo.SelectedValue) > 0)
                //  {            
                //    ddlContract.DataSource = oAdminController.GetContract(UnitId, Convert.ToInt32(ddlSerialNo.SelectedValue), Convert.ToString(ViewState["Status"]), LineNoId);
                //    ddlContract.DataValueField = "Id";
                //    ddlContract.DataTextField = "ContractNumber";
                //    ddlContract.DataBind();
                //    ddlContract.Items.Insert(0, new ListItem("Select", "0"));
                //    //ddlContract.Enabled = true;
                //    ddlContract.SelectedValue = ((DataRowView)e.Row.DataItem)["ContractId"].ToString();
                //    if (Convert.ToInt32(ddlContract.SelectedValue) > 0)
                //    {
                //        DataTable dt = oAdminController.GetDateAndQty(UnitId, Convert.ToInt32(ddlSerialNo.SelectedValue), Convert.ToInt32(ddlContract.SelectedValue), Convert.ToString(ViewState["Status"]), LineNoId);
                //      lblPCDDate.Text = dt.Rows[0]["PCDDate"].ToString();
                //      lblExFactoryDate.Text = dt.Rows[0]["ExFactory"].ToString();
                //      lblContractQty.Text = dt.Rows[0]["ContractQty"].ToString();
                //      lblUnitQty.Text = dt.Rows[0]["UnitQty"].ToString();
                //      txtLineQty.Text = dt.Rows[0]["LineQty"].ToString();

                //      ddlSlot.SelectedValue = Convert.ToString(dt.Rows[0]["SlotId"]);
                //      txtStartDate.Text = (string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["StartDate"])))? "": Convert.ToDateTime(dt.Rows[0]["StartDate"]).ToString("dd/MM/yyyy");
                //      lblEndDate.Text = Convert.ToString(dt.Rows[0]["EndDate"]);

                //      txtLineQty.Enabled = true;
                //    }
                //    if (iRowIndex != 0)
                //    {
                //        if (string.IsNullOrEmpty(txtStartDate.Text))
                //        {
                //            ddlSlot.Visible = false;
                //            txtStartDate.Visible = false;
                //        }
                //    }
                //  }          
                //}
                lblContractQty.Text = lblContractQty.Text == "" ? "0" : lblContractQty.Text;
                lblUnitQty.Text = lblUnitQty.Text == "" ? "0" : lblUnitQty.Text;
                txtLineQty.Text = txtLineQty.Text == "" ? "0" : txtLineQty.Text;

                ViewState["lblTotalContractQty"] = TotalContractQty = TotalContractQty + Convert.ToInt32(lblContractQty.Text);
                ViewState["lblTotalUnitQty"] = TotalUnitQty = TotalUnitQty + Convert.ToInt32(lblUnitQty.Text);

                if (!string.IsNullOrEmpty(hdnfldCheckStartDate.Value))
                {
                    ddlSerialNo.Enabled = false;
                    ddlContract.Enabled = false;
                }
            }

            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label lblTotalContractQty = (Label)e.Row.FindControl("lblTotalContractQty");
                Label lblTotalUnitQty = (Label)e.Row.FindControl("lblTotalUnitQty");

                lblTotalContractQty.Text = Convert.ToInt32(ViewState["lblTotalContractQty"]).ToString();
                lblTotalUnitQty.Text = Convert.ToInt32(ViewState["lblTotalUnitQty"]).ToString();
            }
            oAdminController = null;
        }

        protected void gvNextChangeOverStyleDetail_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int index = Convert.ToInt32(e.RowIndex);
            HiddenField hdnStitching = (HiddenField)gvNextChangeOverStyleDetail.Rows[index].Cells[8].FindControl("hdnIsStitching");
            if (hdnStitching.Value == "1")
                return;

            DataTable dtNextChangeOverStyleDetail = new DataTable();

            dtNextChangeOverStyleDetail.Columns.Add("SerialId");
            dtNextChangeOverStyleDetail.Columns.Add("ContractId");
            dtNextChangeOverStyleDetail.Columns.Add("PCDDate");
            dtNextChangeOverStyleDetail.Columns.Add("ExFactoryDate");
            dtNextChangeOverStyleDetail.Columns.Add("ContractQty");
            dtNextChangeOverStyleDetail.Columns.Add("UnitQty");
            dtNextChangeOverStyleDetail.Columns.Add("LineQty");
            dtNextChangeOverStyleDetail.Columns.Add("StartDate");
            dtNextChangeOverStyleDetail.Columns.Add("SlotId");
            dtNextChangeOverStyleDetail.Columns.Add("EndDate");
            dtNextChangeOverStyleDetail.Columns.Add("CheckStartDate");
            dtNextChangeOverStyleDetail.Columns.Add("IsStitching");

            foreach (GridViewRow row in gvNextChangeOverStyleDetail.Rows)
            {
                DataRow dr = dtNextChangeOverStyleDetail.NewRow();

                DropDownList ddlSerialNo = (DropDownList)row.Cells[1].FindControl("ddlSerialNo");
                DropDownList ddlContract = (DropDownList)row.Cells[2].FindControl("ddlContract");
                Label lblPCDDate = (Label)row.Cells[3].FindControl("lblPCDDate");
                Label lblExFactoryDate = (Label)row.Cells[4].FindControl("lblExFactoryDate");
                Label lblContractQty = (Label)row.Cells[5].FindControl("lblContractQty");
                Label lblUnitQty = (Label)row.Cells[6].FindControl("lblUnitQty");
                TextBox txtLineQty = (TextBox)row.Cells[7].FindControl("txtLineQty");

                TextBox txtStartDate = (TextBox)row.Cells[8].FindControl("txtStartDate");
                DropDownList ddlSlot = (DropDownList)row.Cells[9].FindControl("ddlSlot");
                Label lblEndDate = (Label)row.Cells[10].FindControl("lblEndDate");
                HiddenField hdnfldCheckStartDate = (HiddenField)row.Cells[11].FindControl("hdnfldCheckStartDate");
                HiddenField hdnIsStitching = (HiddenField)row.Cells[6].FindControl("hdnIsStitching");


                dr["SerialId"] = ddlSerialNo.Text;
                dr["ContractId"] = ddlContract.Text;
                dr["PCDDate"] = lblPCDDate.Text;
                dr["ExFactoryDate"] = lblExFactoryDate.Text;
                dr["ContractQty"] = lblContractQty.Text;
                dr["UnitQty"] = lblUnitQty.Text;
                dr["LineQty"] = lblUnitQty.Text;
                dr["StartDate"] = txtStartDate.Text;
                dr["SlotId"] = ddlSlot.SelectedValue;
                dr["EndDate"] = lblEndDate.Text;
                dr["CheckStartDate"] = hdnfldCheckStartDate.Value;
                dr["IsStitching"] = hdnIsStitching.Value;

                dtNextChangeOverStyleDetail.Rows.Add(dr);
            }

            //int index = Convert.ToInt32(e.RowIndex);
            DataTable dtCurrentNextChangeOverStyleDetail = dtNextChangeOverStyleDetail;

            if (dtCurrentNextChangeOverStyleDetail.Rows.Count > 1)
            {
                dtCurrentNextChangeOverStyleDetail.Rows.RemoveAt(index);
                lblValidationMessage.Text = "";
            }
            else
            {
                lblValidationMessage.Text = "Atleast one Entry need to be added";
            }

            dtNextChangeOverStyleDetail = dtCurrentNextChangeOverStyleDetail;

            dtNextChangeOverStyleDetail.Columns.Add(new DataColumn("Column1", typeof(string)));
            dtNextChangeOverStyleDetail.Columns.Add(new DataColumn("Column2", typeof(string)));
            dtNextChangeOverStyleDetail.Columns.Add(new DataColumn("Column3", typeof(string)));
            dtNextChangeOverStyleDetail.Columns.Add(new DataColumn("Column4", typeof(string)));
            dtNextChangeOverStyleDetail.Columns.Add(new DataColumn("Column5", typeof(string)));
            dtNextChangeOverStyleDetail.Columns.Add(new DataColumn("Column6", typeof(string)));
            dtNextChangeOverStyleDetail.Columns.Add(new DataColumn("Column7", typeof(string)));
            dtNextChangeOverStyleDetail.Columns.Add(new DataColumn("Column8", typeof(string)));
            dtNextChangeOverStyleDetail.Columns.Add(new DataColumn("Column9", typeof(string)));
            dtNextChangeOverStyleDetail.Columns.Add(new DataColumn("Column10", typeof(string)));
            dtNextChangeOverStyleDetail.Columns.Add(new DataColumn("Column11", typeof(string)));

            ViewState["dtNextChangeOverStyleDetail"] = dtCurrentNextChangeOverStyleDetail;
            ViewState["delete"] = "delete";

            gvNextChangeOverStyleDetail.DataSource = dtCurrentNextChangeOverStyleDetail;
            gvNextChangeOverStyleDetail.DataBind();

            SetDeletedDataSet();

            ViewState["delete"] = null;
        }

        private void SetDeletedDataSet()
        {
            int rowIndex = 0;
            int TotalContractQty = 0, TotalUnitQty = 0;

            if (ViewState["dtNextChangeOverStyleDetail"] != null)
            {
                DataTable dtNextChangeOverStyleDetail = (DataTable)ViewState["dtNextChangeOverStyleDetail"];
                if (dtNextChangeOverStyleDetail.Rows.Count > 0)
                {
                    for (int i = 0; i < dtNextChangeOverStyleDetail.Rows.Count; i++)
                    {
                        DropDownList ddlSerialNo = (DropDownList)gvNextChangeOverStyleDetail.Rows[rowIndex].Cells[1].FindControl("ddlSerialNo");
                        DropDownList ddlContract = (DropDownList)gvNextChangeOverStyleDetail.Rows[rowIndex].Cells[2].FindControl("ddlContract");
                        Label lblPCDDate = (Label)gvNextChangeOverStyleDetail.Rows[rowIndex].Cells[3].FindControl("lblPCDDate");
                        Label lblExFactoryDate = (Label)gvNextChangeOverStyleDetail.Rows[rowIndex].Cells[4].FindControl("lblExFactoryDate");
                        Label lblContractQty = (Label)gvNextChangeOverStyleDetail.Rows[rowIndex].Cells[5].FindControl("lblContractQty");
                        Label lblUnitQty = (Label)gvNextChangeOverStyleDetail.Rows[rowIndex].Cells[6].FindControl("lblUnitQty");
                        TextBox txtLineQty = (TextBox)gvNextChangeOverStyleDetail.Rows[rowIndex].Cells[7].FindControl("txtLineQty");

                        TextBox txtStartDate = (TextBox)gvNextChangeOverStyleDetail.Rows[rowIndex].Cells[8].FindControl("txtStartDate");
                        DropDownList ddlSlot = (DropDownList)gvNextChangeOverStyleDetail.Rows[rowIndex].Cells[9].FindControl("ddlSlot");
                        Label lblEndDate = (Label)gvNextChangeOverStyleDetail.Rows[rowIndex].Cells[10].FindControl("lblEndDate");
                        HiddenField hdnfldCheckStartDate = (HiddenField)gvNextChangeOverStyleDetail.Rows[rowIndex].Cells[1].FindControl("hdnfldCheckStartDate");
                        HiddenField hdnIsStitching = (HiddenField)gvNextChangeOverStyleDetail.Rows[rowIndex].Cells[8].FindControl("hdnIsStitching");

                        ddlSerialNo.SelectedValue = dtNextChangeOverStyleDetail.Rows[i]["SerialId"].ToString();
                        if (Convert.ToInt32(ddlSerialNo.SelectedValue) > 0)
                        {
                            AdminController oAdminController = new AdminController();

                            ddlContract.DataSource = oAdminController.GetContract(UnitId, Convert.ToInt32(ddlSerialNo.SelectedValue), Convert.ToString(Request.QueryString["status"]), LineNoId);
                            ddlContract.DataValueField = "Id";
                            ddlContract.DataTextField = "ContractNumber";
                            ddlContract.DataBind();
                            ddlContract.Items.Insert(0, new ListItem("Select", "0"));
                            //ddlContract.Enabled = true;
                            oAdminController = null;
                            FillSlot(ddlSlot);
                        }
                        ddlContract.SelectedValue = dtNextChangeOverStyleDetail.Rows[i]["ContractId"].ToString();
                        lblPCDDate.Text = dtNextChangeOverStyleDetail.Rows[i]["PCDDate"].ToString();
                        lblExFactoryDate.Text = dtNextChangeOverStyleDetail.Rows[i]["ExFactoryDate"].ToString();
                        lblContractQty.Text = dtNextChangeOverStyleDetail.Rows[i]["ContractQty"].ToString();
                        lblUnitQty.Text = dtNextChangeOverStyleDetail.Rows[i]["UnitQty"].ToString();
                        txtLineQty.Text = dtNextChangeOverStyleDetail.Rows[i]["LineQty"].ToString();

                        txtStartDate.Text = dtNextChangeOverStyleDetail.Rows[i]["StartDate"].ToString();
                        ddlSlot.SelectedValue = dtNextChangeOverStyleDetail.Rows[i]["SlotId"].ToString();
                        lblEndDate.Text = dtNextChangeOverStyleDetail.Rows[i]["EndDate"].ToString();

                        hdnfldCheckStartDate.Value = dtNextChangeOverStyleDetail.Rows[i]["CheckStartDate"].ToString();
                        hdnIsStitching.Value = dtNextChangeOverStyleDetail.Rows[i]["IsStitching"].ToString();
                        //txtStartDate.Enabled = true;
                        //txtStartDate.CssClass = "date-pick";
                        //ddlSlot.Enabled = true;

                        //if (string.IsNullOrEmpty(txtStartDate.Text))
                        //{
                        //    ddlSlot.Visible = false;
                        //    txtStartDate.Visible = false;
                        //}
                        //if (Convert.ToInt32(ddlContract.SelectedValue) > 0)
                        //{
                        //  txtLineQty.Enabled = true;
                        //  //txtStartDate.Enabled = true;
                        //  //ddlSlot.Enabled = true;

                        //}
                        //else
                        //{
                        //  txtLineQty.Enabled = false;
                        //  //txtStartDate.Enabled = false;
                        //  //ddlSlot.Enabled = false;
                        //}

                        lblContractQty.Text = lblContractQty.Text == "" ? "0" : lblContractQty.Text;
                        lblUnitQty.Text = lblUnitQty.Text == "" ? "0" : lblUnitQty.Text;

                        TotalContractQty = TotalContractQty + Convert.ToInt32(lblContractQty.Text);
                        TotalUnitQty = TotalUnitQty + Convert.ToInt32(lblUnitQty.Text);

                        rowIndex++;
                    }

                    Label lblTotalContractQty = (Label)gvNextChangeOverStyleDetail.FooterRow.FindControl("lblTotalContractQty");
                    Label lblTotalUnitQty = (Label)gvNextChangeOverStyleDetail.FooterRow.FindControl("lblTotalUnitQty");

                    ViewState["lblTotalContractQty"] = lblTotalContractQty.Text = TotalContractQty.ToString();
                    ViewState["lblTotalUnitQty"] = lblTotalUnitQty.Text = TotalUnitQty.ToString();
                }
            }
        }

        protected void gvNextChangeOverStyleDetail_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }
    }
}