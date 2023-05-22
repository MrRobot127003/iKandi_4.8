using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iKandi.BLL;
using iKandi.BLL.Production;
using System.Data;
using iKandi.Common;
using System.Web.UI.HtmlControls;

namespace iKandi.Web.Internal.Production
{
    public partial class frmIEStichedSlotEntry : System.Web.UI.Page
    {

        public int ProductionUnit
        {
            get;
            set;
        }
        public int SlotId
        {
            get;
            set;
        }
        public int LineNo
        {
            get;
            set;
        }
        public string StartDate
        {
            get;
            set;
        }
        public string Status
        {
            get;
            set;
        }
        public int OrderDetailId
        {
            get;
            set;
        }
        public string CheckboxID
        {
            get;
            set;
        }
        static string IsSave = "CLUSTER";

        public static int RowCount = 0;
        public int isSubmit = 0;
        ProductionController objProductionController = new ProductionController();
        WorkflowController WorkflowControllerInstance = new WorkflowController();
        OrderController objOrderController = new OrderController();
        StitchingDetail objStitching = new StitchingDetail();
        DepartmentController objdept = new DepartmentController();
       
        DataSet ds;
        DataSet dsQclineman;
       
        public int getAltSum(int orderDetailIDs, int unitids, int lineplanid)
        {
            int AltSum = 0;
            if (orderDetailIDs != 0 && unitids != 0 && lineplanid != 0)
            {
                DataTable dt = this.objOrderController.GetAltAllSum(orderDetailIDs, unitids, lineplanid, StartDate);
                
                if (dt.Rows[0]["AltSum"].ToString() == "0" || dt.Rows[0]["AltSum"].ToString() == "")
                {
                    AltSum = 0;
                }
                else
                {
                    AltSum = Convert.ToInt32(dt.Rows[0]["AltSum"].ToString());
                }

                //AltSum = dt.Rows[0]["AltSum"].ToString() == "0" ? dt.Rows[0]["AltSum"].ToString() == "" ? 0 : Convert.ToInt32(dt.Rows[0]["AltSum"].ToString()) : Convert.ToInt32(dt.Rows[0]["AltSum"].ToString());

            }
            return AltSum;

        }
        //end 
        protected void Page_Load(object sender, EventArgs e)
        {
            if (iKandi.Web.Components.ApplicationHelper.LoggedInUser == null || iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData == null)
                Response.Redirect("~/public/Login.aspx");

            IsSave = "CLUSTER";

            if (!IsPostBack)
            {
                GetQueryString();
                GetFactoryName();
                GetAllStitchedSlot();
                GetSlot_LinePlanning();
                btnSubmit.Enabled = true;
                btnSubmit1.Enabled = true;
                IsSave = "";
                BindClsutergrd();

            }
        }
        public void Qclineman(DropDownList ddl )
        {
            int UserId = iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.UserID;
            dsQclineman = objProductionController.GetFinshingClusterDetailsQcLineMan(StartDate, LineNo, SlotId, ProductionUnit, "3", UserId);
            if (dsQclineman.Tables[0].Rows.Count > 0)
            {
                ddl.DataSource = dsQclineman.Tables[0];
                ddl.DataTextField = "QCName";
                ddl.DataValueField = "QCId";
                ddl.DataBind();
                
            }
        }
        // StitchingDetail objStitching_new = new StitchingDetail();
        private void GetQueryString()
        {
            if (null != Request.QueryString["ProductionUnit"])
            {
                ProductionUnit = Convert.ToInt32(Request.QueryString["ProductionUnit"].ToString());
                hdnProductionUnit.Value = ProductionUnit.ToString();
            }
            else
            {
                hdnProductionUnit.Value = "3";
            }
            if (null != Request.QueryString["SlotId"])
            {
                SlotId = Convert.ToInt32(Request.QueryString["SlotId"].ToString());
                hdnSlotId.Value = SlotId.ToString();
            }
            else
            {
                hdnSlotId.Value = "1";
            }
            if (null != Request.QueryString["LineNo"])
            {
                LineNo = Convert.ToInt32(Request.QueryString["LineNo"].ToString());
            }
            else
            {
                LineNo = -1;
            }
            if (null != Request.QueryString["StartDate"])
            {
                StartDate = Request.QueryString["StartDate"].ToString();
                hdnStartDate.Value = StartDate;
            }
            else
            {
                hdnStartDate.Value = "09/09/2015";
            }
            if (null != Request.QueryString["Status"])
            {
                Status = Request.QueryString["Status"].ToString();
                hdnStatus.Value = Status;
            }

        }

        private void GetFactoryName()
        {
            ProductionUnit = Convert.ToInt32(hdnProductionUnit.Value);
            string FactoryName = objProductionController.GetFactoryName(ProductionUnit);
            lblFactory.Text = "Factory " + FactoryName.ToString();
            lblfactoryslotname.Text = "Factory " + FactoryName.ToString();
        }

        protected void ddlSlot_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlSlot.SelectedIndex != 0)
            {
                if (ddlSlot.SelectedValue != hdnSlotId.Value)
                {                    
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", "alert('first off all, must work on earlier slot');", true);
                    ddlSlot.SelectedValue = hdnSlotId.Value;
                    return;
                }
                else
                {
                    GetSlot_LinePlanning();
                }
            }
        }

        private void GetAllStitchedSlot()
        {
            ProductionUnit = Convert.ToInt32(hdnProductionUnit.Value);
            StartDate = hdnStartDate.Value;
            int UserId = iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.UserID;
            DataSet dsSlot = objProductionController.GetAllStitchingSlot(ProductionUnit, StartDate, UserId);
            if (dsSlot.Tables[0].Rows.Count > 0)
            {
                ddlSlot.DataSource = dsSlot.Tables[0];
                ddlSlot.DataTextField = "Date_Slot";
                ddlSlot.DataValueField = "SlotID";
                ddlSlot.DataBind();
                ddlSlot.Items.Insert(0, new ListItem("Select", "-1"));
                ddlSlot.SelectedValue = dsSlot.Tables[0].Rows[0]["SlotID"].ToString();
            }
        }

        private void GetSlot_LinePlanning()
        {
            StartDate = hdnStartDate.Value;
            LineNo = 0;
            ProductionUnit = Convert.ToInt32(hdnProductionUnit.Value);
            if (ddlSlot.SelectedValue != "-1")
            {
                hdnSlotId.Value = ddlSlot.SelectedValue;
                string[] SlotName = ddlSlot.SelectedItem.Text.Split(')');
                hdnSlotName.Value = SlotName[1].ToString();
                //DataSet ds;
                SlotId = Convert.ToInt32(hdnSlotId.Value);
                lblSlot.Text = "(Slot " + SlotId.ToString() + ")";
                lblslots.Text = "(Slot " + SlotId.ToString() + ")";
                int UserId = iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.UserID;
                ds = objProductionController.GetSlot_LinePlanning(StartDate, LineNo, SlotId, ProductionUnit, "Stitching_IEwriter", UserId);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gvIEStitchedSlot.DataSource = ds.Tables[0];
                    gvIEStitchedSlot.DataBind();
                    tblStitchHeader.Visible = true;
                }
                else
                {
                    tblStitchHeader.Visible = false;
                }
                if (ds.Tables[0].Rows.Count < 1)
                {
                    btnSubmit.Visible = false;
                    btnSubmit1.Visible = false;
                }
                else
                {
                    RowCount = ds.Tables[0].Rows.Count;
                    btnSubmit.Visible = true;
                    btnSubmit1.Visible = true;
                }
            }
            else
            {
                btnSubmit.Visible = false;
                btnSubmit1.Visible = false;
            }

        }

        public void ShowAlert(string stringAlertMsg)
        {
            string myStringVariable = string.Empty;
            myStringVariable = stringAlertMsg;
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);
        }

        protected void gvIEStitchedSlot_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            int LineStitchQty = 0, LineQty = 0, OrderFinishingQty = 0, OrderStitchedQty = 0;

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                CheckBox chkMarkAsStyle = (CheckBox)e.Row.FindControl("chkMarkAsStyle");
                CheckBox chkmarkfinish = (CheckBox)e.Row.FindControl("chkmarkfinish");
                TextBox txtSlotPass = (TextBox)e.Row.FindControl("txtSlotPass");
                TextBox txlActualOB = (TextBox)e.Row.FindControl("txlActualOB");
                HiddenField Zeroproeduct = (HiddenField)e.Row.FindControl("Zeroproeduct");
                HiddenField hdnLineStitchedQty = (HiddenField)e.Row.FindControl("hdnLineStitchedQty");
                HtmlInputCheckBox ch = (HtmlInputCheckBox)e.Row.FindControl("chkpass");
                TextBox txtcot = (TextBox)e.Row.FindControl("txtcot");
                TextBox txtToBeFinish = (TextBox)e.Row.FindControl("txtToBeFinish");
                TextBox txtLineQty = (TextBox)e.Row.FindControl("txtLineQty");
                Label lblOrderStitchQty = (Label)e.Row.FindControl("lblOrderStitchQty");
                Label lblLineStitchQty = (Label)e.Row.FindControl("lblLineStitchQty");
                TextBox txtSlotSAM = (TextBox)e.Row.FindControl("txtSlotSAM");


                Label lblFabricDetails = (Label)e.Row.FindControl("lblFabricDetails");
                Label lblFinishOB = (Label)e.Row.FindControl("lblFinishOB");
                Label lblStitchOB = (Label)e.Row.FindControl("lblStitchOB");
                Label lblFinishSAM = (Label)e.Row.FindControl("lblFinishSAM");
                Label lblLinePlanning_FinishSAM = (Label)e.Row.FindControl("lblLinePlanning_FinishSAM");
                TextBox txtSlotPassFinish = (TextBox)e.Row.FindControl("txtSlotPassFinish");
                HtmlInputCheckBox chkpassFinish = (HtmlInputCheckBox)e.Row.FindControl("chkpassFinish");

                CheckBox chkMarkAsDayClose = (CheckBox)e.Row.FindControl("chkMarkAsDayClose");
                HiddenField hdnLinePlanningId = (HiddenField)e.Row.FindControl("hdnLinePlanningId");
                HiddenField hdnOrderDetailId = (HiddenField)e.Row.FindControl("hdnOrderDetailId");
                Label lblLinePlanningSAM = (Label)e.Row.FindControl("lblLinePlanningSAM");
                HiddenField hdnToBeFinish = (HiddenField)e.Row.FindControl("hdnToBeFinish");
                TextBox txtBalanceLineStichedQty = (TextBox)e.Row.FindControl("txtBalanceLineStichedQty");
                HiddenField hdnLineStitchBalance = (HiddenField)e.Row.FindControl("hdnLineStitchBalance");

                TextBox txtActualFinishOB = (TextBox)e.Row.FindControl("txtActualFinishOB");
                TextBox txtActTCOB = (TextBox)e.Row.FindControl("txtActTCOB");
                TextBox txtActPressOB = (TextBox)e.Row.FindControl("txtActPressOB");

                TextBox txtPeakCapTotal = (TextBox)e.Row.FindControl("txtPeakCapTotal");
                TextBox txtPeakCapTC = (TextBox)e.Row.FindControl("txtPeakCapTC");
                TextBox txtPeakCapPress = (TextBox)e.Row.FindControl("txtPeakCapPress");

                TextBox txtPeakOB_Finish = (TextBox)e.Row.FindControl("txtPeakOB_Finish");
                TextBox txtPeakTCOB = (TextBox)e.Row.FindControl("txtPeakTCOB");
                TextBox txtPeakPressOB = (TextBox)e.Row.FindControl("txtPeakPressOB");

                CheckBox chkRequiredActualOB = (CheckBox)e.Row.FindControl("chkRequiredActualOB");
                HiddenField hdnCheckRequiredActualOb = (HiddenField)e.Row.FindControl("hdnCheckRequiredActualOb");
                CheckBox chkSeqCheck = (CheckBox)e.Row.FindControl("chkSeqCheck");
                HiddenField hdnchkSeqCheck = (HiddenField)e.Row.FindControl("hdnchkSeqCheck");
                HiddenField hdnIsSequence = (HiddenField)e.Row.FindControl("hdnIsSequence");
                HiddenField hdnQcLinnManID = (HiddenField)e.Row.FindControl("hdnQcLinnManID");
                HyperLink hlnkQC = (HyperLink)e.Row.FindControl("hlnkQC");

                //Add By Prabhaker 23-aug-18
                DropDownList ddlIEName = (DropDownList)e.Row.FindControl("ddlIEName");
                DropDownList ddllQclineMan = (DropDownList)e.Row.FindControl("ddllQclineMan");
                Label lblIEName = (Label)e.Row.FindControl("lblIEName");
                ddlIEName.DataSource = ds.Tables[1];
                ddlIEName.DataTextField = "LineManName";
                ddlIEName.DataValueField = "LineManId";
                Qclineman(ddllQclineMan);
                if (lblIEName.Text != "" || lblIEName.Text != "-1")
                {
                    ddlIEName.DataBind();
                    ddlIEName.SelectedValue = lblIEName.Text;
                }
                else
                {
                    ddlIEName.Items.Clear();
                    ddlIEName.DataBind();
                    ddlIEName.Items.Insert(-1, "select");
                }
                ddllQclineMan.SelectedValue = hdnQcLinnManID.Value;
              
                if (hdnCheckRequiredActualOb.Value == "1")
                {
                    chkRequiredActualOB.Checked = true;
                }
                else
                {
                    chkRequiredActualOB.Checked = false;
                }

                if (hdnchkSeqCheck.Value == "True")
                {
                    chkSeqCheck.Checked = true;
                }
                else
                {
                    chkSeqCheck.Checked = false;
                }
                if (hdnIsSequence.Value == "True")
                {
                    chkSeqCheck.Visible = true;
                }
                else
                {
                    chkSeqCheck.Visible = false;
                }
                //------------------- End Code  By Prabhaker 05-Jan-18 --------------------//

                int Reuslt = this.getAltSum(Convert.ToInt32(hdnOrderDetailId.Value), ProductionUnit, Convert.ToInt32(hdnLinePlanningId.Value));
                if (Reuslt > 0)
                {
                    CheckboxID = chkMarkAsDayClose.ClientID;
                    chkMarkAsDayClose.Attributes.Add("onclick", "javascript:openShipedPopu('" + hdnOrderDetailId.Value + "','" + ProductionUnit + "', '" + hdnLinePlanningId.Value + "', '" + CheckboxID + "', '" + StartDate + "');");     
                }
                else
                {
                    CheckboxID = chkMarkAsDayClose.ID;
                    chkMarkAsDayClose.Attributes.Add("onclick", "javascript:Showmgs('" + CheckboxID + "')");
                }

                string FabricDetails = DataBinder.Eval(e.Row.DataItem, "FabricDetails").ToString();
                lblFabricDetails.Text = FabricDetails.Length > 30 ? FabricDetails.Substring(0, 30) : FabricDetails;
                lblFabricDetails.ToolTip = FabricDetails;

                txtSlotSAM.Text = DataBinder.Eval(e.Row.DataItem, "SlotSAM").ToString() == "0" ? "" : DataBinder.Eval(e.Row.DataItem, "SlotSAM").ToString();

                OrderStitchedQty = DataBinder.Eval(e.Row.DataItem, "OrderStichedQty") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "OrderStichedQty"));
                LineStitchQty = DataBinder.Eval(e.Row.DataItem, "LineStichedQty") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "LineStichedQty"));
                OrderFinishingQty = DataBinder.Eval(e.Row.DataItem, "OrderFinishingQty") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "OrderFinishingQty"));

                lblFinishOB.Text = DataBinder.Eval(e.Row.DataItem, "LinePlan_FinishOB").ToString() == "0" ? "" : DataBinder.Eval(e.Row.DataItem, "LinePlan_FinishOB").ToString();
                lblStitchOB.Text = DataBinder.Eval(e.Row.DataItem, "LinePlan_StitchOB").ToString() == "0" ? "" : DataBinder.Eval(e.Row.DataItem, "LinePlan_StitchOB").ToString();

                txtToBeFinish.Text = (OrderStitchedQty - OrderFinishingQty).ToString() == "0" ? "" : (OrderStitchedQty - OrderFinishingQty).ToString();
                hdnToBeFinish.Value = (OrderStitchedQty - OrderFinishingQty).ToString();
                txlActualOB.Text = DataBinder.Eval(e.Row.DataItem, "OB").ToString() == "-1" ? "" : DataBinder.Eval(e.Row.DataItem, "OB").ToString();
                txlActualOB.Text = txlActualOB.Text == "0" ? "" : txlActualOB.Text;
                lblLinePlanningSAM.Text = DataBinder.Eval(e.Row.DataItem, "LinePlanningSAM").ToString() == "0" ? "" : DataBinder.Eval(e.Row.DataItem, "LinePlanningSAM").ToString();
                txtBalanceLineStichedQty.Text = DataBinder.Eval(e.Row.DataItem, "BalanceLineStichedQty").ToString() == "0" ? "" : DataBinder.Eval(e.Row.DataItem, "BalanceLineStichedQty").ToString();
                hdnLineStitchBalance.Value = DataBinder.Eval(e.Row.DataItem, "BalanceLineStichedQty").ToString() == "0" ? "" : DataBinder.Eval(e.Row.DataItem, "BalanceLineStichedQty").ToString();

                txtActualFinishOB.Text = DataBinder.Eval(e.Row.DataItem, "FinishOB").ToString() == "0" ? "" : DataBinder.Eval(e.Row.DataItem, "FinishOB").ToString();
                txtActTCOB.Text = DataBinder.Eval(e.Row.DataItem, "Finish_ActTCOB").ToString() == "0" ? "" : DataBinder.Eval(e.Row.DataItem, "Finish_ActTCOB").ToString();
                txtActPressOB.Text = DataBinder.Eval(e.Row.DataItem, "Finish_ActPressOB").ToString() == "0" ? "" : DataBinder.Eval(e.Row.DataItem, "Finish_ActPressOB").ToString();

                txtPeakCapTotal.Text = DataBinder.Eval(e.Row.DataItem, "PeakCapTotal_Finish").ToString() == "0" ? "" : DataBinder.Eval(e.Row.DataItem, "PeakCapTotal_Finish").ToString();
                txtPeakCapTC.Text = DataBinder.Eval(e.Row.DataItem, "PeakCapTC_Finish").ToString() == "0" ? "" : DataBinder.Eval(e.Row.DataItem, "PeakCapTC_Finish").ToString();
                txtPeakCapPress.Text = DataBinder.Eval(e.Row.DataItem, "PeakCapPress_Finish").ToString() == "0" ? "" : DataBinder.Eval(e.Row.DataItem, "PeakCapPress_Finish").ToString();

                txtPeakOB_Finish.Text = DataBinder.Eval(e.Row.DataItem, "PeakOB_Finish").ToString() == "0" ? "" : DataBinder.Eval(e.Row.DataItem, "PeakOB_Finish").ToString();
                txtPeakTCOB.Text = DataBinder.Eval(e.Row.DataItem, "PeakTCOB_Finish").ToString() == "0" ? "" : DataBinder.Eval(e.Row.DataItem, "PeakTCOB_Finish").ToString();
                txtPeakPressOB.Text = DataBinder.Eval(e.Row.DataItem, "PeakPressOB_Finish").ToString() == "0" ? "" : DataBinder.Eval(e.Row.DataItem, "PeakPressOB_Finish").ToString();

                int SlotWiseQC = DataBinder.Eval(e.Row.DataItem, "SlotWiseQC") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "SlotWiseQC"));
                int SlotWiseQC_new = DataBinder.Eval(e.Row.DataItem, "Updatededbyfiled") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Updatededbyfiled"));

                if (SlotWiseQC_new == 0)
                    hlnkQC.CssClass = "QClinkBlue";
                if (SlotWiseQC_new == 1)
                    hlnkQC.CssClass = "QClinkyellow";
                if (SlotWiseQC_new == 2)
                    hlnkQC.CssClass = "QClinkgreen";

                if (lblFinishOB.Text != "")
                {
                    if (Convert.ToBoolean(DataBinder.Eval(e.Row.DataItem, "FinishDoubleOB")) == true)
                        lblFinishOB.Text = lblFinishOB.Text + " D";
                }
                if (lblStitchOB.Text != "")
                {
                    if (Convert.ToBoolean(DataBinder.Eval(e.Row.DataItem, "StitchDoubleOB")) == true)
                        lblStitchOB.Text = lblStitchOB.Text + " D";
                }
                if (txtcot.Text == "0")
                    txtcot.Text = "";

                if ((Zeroproeduct.Value == "True"))
                {
                    ch.Checked = true;
                    txtSlotPass.ReadOnly = true;
                }
                else
                    ch.Checked = false;

                LineQty = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "LineQty"));

                if (LineQty != 0)
                {
                    txtLineQty.Text = LineQty.ToString();

                    if (((LineStitchQty * 100) / LineQty) >= 80)
                        chkMarkAsStyle.Enabled = true;
                    else
                        chkMarkAsStyle.Enabled = false;
                }
                else
                    chkMarkAsStyle.Enabled = false;

                if (OrderStitchedQty != 0)
                {
                    lblOrderStitchQty.Text = OrderStitchedQty.ToString();

                    if (LineQty != 0)
                    {
                        if (((OrderFinishingQty * 100) / LineQty) >= 80)
                            chkmarkfinish.Enabled = true;
                        else
                            chkmarkfinish.Enabled = false;
                    }
                }
                else
                    chkmarkfinish.Enabled = false;

                if (chkMarkAsStyle.Checked)
                    chkMarkAsStyle.Enabled = false;

                if (LineStitchQty != 0)
                    lblLineStitchQty.Text = " (" + LineStitchQty.ToString() + ")";

                bool IsFinishing = Convert.ToBoolean(DataBinder.Eval(e.Row.DataItem, "IsFinishing"));
                if (IsFinishing == true)
                {
                    txtSlotPassFinish.Enabled = true;
                    lblFinishSAM.Text = DataBinder.Eval(e.Row.DataItem, "LinePlan_FinishSAM").ToString();
                    lblLinePlanning_FinishSAM.Text = DataBinder.Eval(e.Row.DataItem, "LinePlan_FinishSAM").ToString();
                }
                else
                {
                    txtSlotPassFinish.Enabled = false;
                    txtActualFinishOB.Enabled = false;
                    txtActTCOB.Enabled = false;
                    txtActPressOB.Enabled = false;
                    txtPeakCapTotal.Enabled = false;
                    txtPeakCapTC.Enabled = false;
                    txtPeakCapPress.Enabled = false;
                    txtPeakOB_Finish.Enabled = false;
                    txtPeakTCOB.Enabled = false;
                    txtPeakPressOB.Enabled = false;
                    chkpassFinish.Attributes.Add("disabled", "disabled");
                    txtToBeFinish.Text = "";
                }

                HyperLink hlinkBottleNeck = (HyperLink)e.Row.FindControl("hlinkBottleNeck");

                BottleNeck objBottleNeck = new BottleNeck();
                objBottleNeck.OrderDetailId = Convert.ToInt32(hdnOrderDetailId.Value);
                objBottleNeck.LinePlanningId = Convert.ToInt32(hdnLinePlanningId.Value);

                DataTable dtBottleNeck = objProductionController.GetStitching_BottleNeck(objBottleNeck);
                if (dtBottleNeck.Rows.Count > 0)
                {
                    hlinkBottleNeck.Visible = true;
                }
            }
        }

        public void BindClsutergrd()
        {
            StartDate = hdnStartDate.Value;
            LineNo = 0;
            ProductionUnit = Convert.ToInt32(hdnProductionUnit.Value);
            Session["UnitID"] = ProductionUnit;

            if (ddlSlot.SelectedValue != "-1")
            {
                hdnSlotId.Value = ddlSlot.SelectedValue;
                string[] SlotName = ddlSlot.SelectedItem.Text.Split(')');
                hdnSlotName.Value = SlotName[1].ToString();

                SlotId = Convert.ToInt32(hdnSlotId.Value);

                DataSet ds;
                int UserId = iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.UserID;

                ds = objProductionController.GetFinshingClusterDetails(StartDate, LineNo, SlotId, ProductionUnit, "1", UserId);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    btnSubmit.Visible = true;
                    tblClusterHeader.Visible = true;

                    grdfinshingCluster.DataSource = ds.Tables[0];
                    grdfinshingCluster.DataBind();
                }
                else
                    tblClusterHeader.Visible = false;

            }

        }                                      

        protected void grdfinshingCluster_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                TextBox txtcluster = (TextBox)e.Row.FindControl("txtcluster");
                Label clusterCount = (Label)e.Row.FindControl("clusterCount");
                Repeater rptcluster = (Repeater)e.Row.FindControl("rptcluster");

                txtcluster.Attributes.Add("onchange", "if (!validateinput(this)){return};");

                Label lblClusterCount = (Label)e.Row.FindControl("lblClusterCount");

                txtcluster.Text = txtcluster.Text == "0" ? "" : txtcluster.Text;
                StartDate = hdnStartDate.Value;
                LineNo = 0;
                ProductionUnit = Convert.ToInt32(hdnProductionUnit.Value);
                if (ddlSlot.SelectedValue != "-1")
                {
                    hdnSlotId.Value = ddlSlot.SelectedValue;
                    string[] SlotName = ddlSlot.SelectedItem.Text.Split(')');
                    hdnSlotName.Value = SlotName[1].ToString();

                    SlotId = Convert.ToInt32(hdnSlotId.Value);


                    int UserId = iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.UserID;
                    //GetFinshingClusterDetails(string StartDate="", int Lineno=0, int SlotId=0, int ProductionUnit=0, string Type="", int UserId=0)
                    DataSet dss = new DataSet();
                    int ClusterCount = Convert.ToInt32(txtcluster.Text == "" ? 0 : Convert.ToInt32(txtcluster.Text));
                    dss = objProductionController.GetFinshingClusterContarctDetails(StartDate, SlotId, ProductionUnit, "2", UserId, Convert.ToInt32(clusterCount.Text.Replace("Cluster ", "")), ClusterCount);
                    DataTable dt = new DataTable();
                    dt = dss.Tables[0];
                    DataTable dtClusterDoneCount = dss.Tables[1];
                    if (rptcluster != null && dt.Rows.Count > 0)
                    {
                        rptcluster.DataSource = dt;
                        rptcluster.DataBind();




                        // string _sqlWhere = "OrderDetailsID = '0'";
                        //// string _sqlOrder = "Nachname DESC";
                        // DataTable _newDataTable = dt.Select(_sqlWhere).CopyToDataTable();
                        // ViewState["datatable"] = _newDataTable;

                    }
                    if (dtClusterDoneCount.Rows.Count > 0)
                    {
                        lblClusterCount.Text = dtClusterDoneCount.Rows[0]["FinshingDone"].ToString() == "0" ? "" : dtClusterDoneCount.Rows[0]["FinshingDone"].ToString() + "+";

                    }

                }


            }
        }

        public void PreservPassValue()
        {
            DataTable table = new DataTable();
            table.Columns.Add("ID", typeof(int));
            table.Columns.Add("ClusterID", typeof(int));
            table.Columns.Add("PassValue", typeof(int));

            foreach (GridViewRow gvr in grdfinshingCluster.Rows)
            {
                int i = 0;
                Label clusterCount = (Label)gvr.FindControl("clusterCount");
                TextBox txtcluster = (TextBox)gvr.FindControl("txtcluster");
                Repeater rptcluster = (Repeater)gvr.FindControl("rptcluster");
                if (rptcluster != null)
                {
                    foreach (RepeaterItem ri in rptcluster.Items)
                    {
                        if (ri.ItemType == ListItemType.Item || ri.ItemType == ListItemType.AlternatingItem)
                        {
                            TextBox txtSlotPassFinish = ri.FindControl("txtSlotPassFinish") as TextBox;
                            if (txtSlotPassFinish.Text != "" && txtSlotPassFinish != null)
                            {
                                table.Rows.Add(i + 1, Convert.ToInt32(clusterCount.Text.Replace("Cluster ", "")), Convert.ToInt32(txtSlotPassFinish.Text));
                            }
                        }
                    }
                }
            }
            if (table.Rows.Count > 0)
            {
                ViewState["PassValue"] = table;
            }
        }

        protected void txtcluster_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            GridViewRow gvRow = (GridViewRow)txt.Parent.Parent;
            Label clusterCount = (Label)gvRow.FindControl("clusterCount");
            TextBox txtcluster = (TextBox)gvRow.FindControl("txtcluster");
            Repeater rptcluster = (Repeater)gvRow.FindControl("rptcluster");

            StartDate = hdnStartDate.Value;
            LineNo = 0;
            ProductionUnit = Convert.ToInt32(hdnProductionUnit.Value);
            if (txtcluster.Text == "")
                txtcluster.Text = "0";

            if (ddlSlot.SelectedValue != "-1" && Convert.ToInt32(txtcluster.Text) > 0)
            {
                hdnSlotId.Value = ddlSlot.SelectedValue;
                string[] SlotName = ddlSlot.SelectedItem.Text.Split(')');
                hdnSlotName.Value = SlotName[1].ToString();

                SlotId = Convert.ToInt32(hdnSlotId.Value);

                int UserId = iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.UserID;
                //GetFinshingClusterDetails(string StartDate="", int Lineno=0, int SlotId=0, int ProductionUnit=0, string Type="", int UserId=0)
                DataSet dss = new DataSet();
                dss = objProductionController.GetFinshingClusterContarctDetails(StartDate, SlotId, ProductionUnit, "2", UserId, Convert.ToInt32(clusterCount.Text.Replace("Cluster ", "")), Convert.ToInt32(txtcluster.Text));
                DataTable dt = new DataTable();

                dt = dss.Tables[0];
                //IsSave = "CLUSTER";
                string error = "";
                RetainClusterRecord(rptcluster, clusterCount.Text.Replace("Cluster ", ""), out error);
                PreservPassValue();
                if (error != "")
                {
                    ShowAlert(error);
                    updateCluster.Update();
                    BindClsutergrd();
                    DataTable tbl = rptcluster.DataSource as DataTable;
                    // return;

                }
                else
                {
                    foreach (GridViewRow gvr in grdfinshingCluster.Rows)
                    {
                        Label clusterCounts = (Label)gvr.FindControl("clusterCount");
                        TextBox txtclusters = (TextBox)gvr.FindControl("txtcluster");
                        Repeater rptclusters = (Repeater)gvr.FindControl("rptcluster");

                        if (rptcluster != null)
                        {
                            foreach (RepeaterItem ri in rptcluster.Items)
                            {
                                if (clusterCount.Text != clusterCounts.Text)
                                {
                                    if (ri.ItemType == ListItemType.Item || ri.ItemType == ListItemType.AlternatingItem)
                                    {

                                        dss = objProductionController.GetFinshingClusterContarctDetails(StartDate, SlotId, ProductionUnit, "2", UserId, Convert.ToInt32(clusterCounts.Text.Replace("Cluster ", "")), 0);
                                        dt = dss.Tables[0];
                                        rptclusters.DataSource = dt;
                                        rptclusters.DataBind();
                                    }
                                }
                            }
                        }
                    }
                    dss = objProductionController.GetFinshingClusterContarctDetails(StartDate, SlotId, ProductionUnit, "2", UserId, Convert.ToInt32(clusterCount.Text.Replace("Cluster ", "")), Convert.ToInt32(txtcluster.Text));

                    dt = dss.Tables[0];

                    rptcluster.DataSource = dt;
                    rptcluster.DataBind();
                    txtcluster.Text = "";
                }
            }
        }
       
        protected void rptcluster_OnItemDataBound(object sender, RepeaterItemEventArgs e)
        {

            int OrderFinishingQty = 0, OrderStitchedQty = 0;
            
            RepeaterItem item = e.Item;
            if (item.ItemType == ListItemType.AlternatingItem || item.ItemType == ListItemType.Item)
            {
                TextBox txtStylenumber = (TextBox)item.FindControl("txtStylenumber");
                //DropDownList ddlSerialNo = (DropDownList)item.FindControl("ddlSerialNo");

                DropDownList ddlPrintColorQuantity = (DropDownList)item.FindControl("ddlPrintColorQuantity");

                HiddenField hdnOrderID = (HiddenField)item.FindControl("hdnOrderID");
                HiddenField hdnOrderDetailsID = (HiddenField)item.FindControl("hdnOrderDetailsID");
                HiddenField hdncount = (HiddenField)item.FindControl("hdncount");
                TextBox txtSerialNumber = (TextBox)item.FindControl("txtSerialNumber");

                hdncount.Value = DataBinder.Eval(item.DataItem, "RowsCount") == DBNull.Value ? "0" : Convert.ToInt32(DataBinder.Eval(item.DataItem, "RowsCount")).ToString();
                if (hdnOrderDetailsID != null && hdnOrderDetailsID.Value != "0" && txtStylenumber.Text != "")
                {
                    // binddropdown("SERIALNO", ddlSerialNo, Convert.ToInt32(hdnOrderID.Value), txtStylenumber.Text.Trim());
                    binddropdown("PRINT", ddlPrintColorQuantity, Convert.ToInt32(hdnOrderDetailsID.Value), hdnOrderID.Value);

                    txtStylenumber.Enabled = false;
                    txtSerialNumber.Enabled = false;
                    ddlPrintColorQuantity.Enabled = false;
                    txtSerialNumber.Enabled = false;
                }

                CheckBox chkmarkfinish = (CheckBox)item.FindControl("chkmarkfinish");
                //ddlPrintColorQuantity.Attributes.Add("onchange", "javascript:jsFunction(this)");

                Label txtToBeFinish = (Label)item.FindControl("txtToBeFinish");

                Label lblLineStitchQty = (Label)item.FindControl("lblLineStitchQty");
                Label lblFinishOB = (Label)item.FindControl("lblFinishOB");
                Label lblLinePlanning_FinishSAM = (Label)item.FindControl("lblLinePlanning_FinishSAM");
                TextBox txtSlotPassFinish = (TextBox)item.FindControl("txtSlotPassFinish");
                HiddenField hdnToBeFinish = (HiddenField)item.FindControl("hdnToBeFinish");

                TextBox txtActualFinishOB = (TextBox)item.FindControl("txtActualFinishOB");
                TextBox txtActTCOB = (TextBox)item.FindControl("txtActTCOB");
                TextBox txtActPressOB = (TextBox)item.FindControl("txtActPressOB");

                TextBox txtPeakCapTotal = (TextBox)item.FindControl("txtPeakCapTotal");
                TextBox txtPeakCapTC = (TextBox)item.FindControl("txtPeakCapTC");
                TextBox txtPeakCapPress = (TextBox)item.FindControl("txtPeakCapPress");

                TextBox txtPeakOB_Finish = (TextBox)item.FindControl("txtPeakOB_Finish");
                TextBox txtPeakTCOB = (TextBox)item.FindControl("txtPeakTCOB");
                TextBox txtPeakPressOB = (TextBox)item.FindControl("txtPeakPressOB");

                Label lblTotQtyToFin = (Label)item.FindControl("lblTotQtyToFin");
                Label lblFinBal = (Label)item.FindControl("lblFinBal");

                HiddenField hdnpassvalue = (HiddenField)item.FindControl("hdnpassvalue");
                TextBox txtlastvalue = (TextBox)item.FindControl("txtlastvalue");
                HyperLink hlnkQC = (HyperLink)item.FindControl("hlnkQC");

                string FabricDetails = DataBinder.Eval(item.DataItem, "FabricDetails").ToString();

                OrderStitchedQty = DataBinder.Eval(item.DataItem, "OrderStichedQty") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(item.DataItem, "OrderStichedQty"));
                OrderFinishingQty = DataBinder.Eval(item.DataItem, "OrderFinishingQty") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(item.DataItem, "OrderFinishingQty"));

                lblFinishOB.Text = DataBinder.Eval(item.DataItem, "LinePlan_FinishOB").ToString() == "0" ? "" : DataBinder.Eval(item.DataItem, "LinePlan_FinishOB").ToString();

                // lblFinishSAM.Text = DataBinder.Eval(item.DataItem, "LinePlan_FinishSAM").ToString() == "0" ? "" : DataBinder.Eval(item.DataItem, "LinePlan_FinishSAM").ToString();
                lblLinePlanning_FinishSAM.Text = DataBinder.Eval(item.DataItem, "LinePlan_FinishSAM").ToString() == "0" ? "" : DataBinder.Eval(item.DataItem, "LinePlan_FinishSAM").ToString();
                txtToBeFinish.Text = (OrderStitchedQty - OrderFinishingQty).ToString() == "0" ? "" : (OrderStitchedQty - OrderFinishingQty).ToString();
                hdnToBeFinish.Value = (OrderStitchedQty - OrderFinishingQty).ToString();


                txtActualFinishOB.Text = DataBinder.Eval(item.DataItem, "FinishOB").ToString() == "0" ? "" : DataBinder.Eval(item.DataItem, "FinishOB").ToString();
                txtActTCOB.Text = DataBinder.Eval(item.DataItem, "Finish_ActTCOB").ToString() == "0" ? "" : DataBinder.Eval(item.DataItem, "Finish_ActTCOB").ToString();
                txtActPressOB.Text = DataBinder.Eval(item.DataItem, "Finish_ActPressOB").ToString() == "0" ? "" : DataBinder.Eval(item.DataItem, "Finish_ActPressOB").ToString();

                txtPeakCapTotal.Text = DataBinder.Eval(item.DataItem, "PeakCapTotal_Finish").ToString() == "0" ? "" : DataBinder.Eval(item.DataItem, "PeakCapTotal_Finish").ToString();
                txtPeakCapTC.Text = DataBinder.Eval(item.DataItem, "PeakCapTC_Finish").ToString() == "0" ? "" : DataBinder.Eval(item.DataItem, "PeakCapTC_Finish").ToString();
                txtPeakCapPress.Text = DataBinder.Eval(item.DataItem, "PeakCapPress_Finish").ToString() == "0" ? "" : DataBinder.Eval(item.DataItem, "PeakCapPress_Finish").ToString();

                txtPeakOB_Finish.Text = DataBinder.Eval(item.DataItem, "PeakOB_Finish").ToString() == "0" ? "" : DataBinder.Eval(item.DataItem, "PeakOB_Finish").ToString();
                txtPeakTCOB.Text = DataBinder.Eval(item.DataItem, "PeakTCOB_Finish").ToString() == "0" ? "" : DataBinder.Eval(item.DataItem, "PeakTCOB_Finish").ToString();
                txtPeakPressOB.Text = DataBinder.Eval(item.DataItem, "PeakPressOB_Finish").ToString() == "0" ? "" : DataBinder.Eval(item.DataItem, "PeakPressOB_Finish").ToString();
                //txtSlotPassFinish.Text = DataBinder.Eval(item.DataItem, "SlotPassVal").ToString() == "0" ? "" : DataBinder.Eval(item.DataItem, "SlotPassVal").ToString();
                hdnpassvalue.Value = DataBinder.Eval(item.DataItem, "SlotPassVal").ToString() == "0" ? "" : DataBinder.Eval(item.DataItem, "SlotPassVal").ToString();
                txtlastvalue.Text = DataBinder.Eval(item.DataItem, "LastPassValue").ToString() == "0" ? "" : DataBinder.Eval(item.DataItem, "LastPassValue").ToString();

                //int SlotWiseQC = DataBinder.Eval(item.DataItem, "SlotWiseQC") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(item.DataItem, "SlotWiseQC"));
                int SlotWiseQC_new = DataBinder.Eval(item.DataItem, "Updatededbyfiled") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(item.DataItem, "Updatededbyfiled"));
                if (IsSave == "CLUSTER")
                {
                    if (txtlastvalue.Text != "")
                    {
                        txtlastvalue.Visible = true;
                    }
                }
                if (OrderStitchedQty != 0)
                {
                    lblLineStitchQty.Text = OrderStitchedQty.ToString();
                }
                //if (SlotWiseQC == 1)
                //    hlnkQC.CssClass = "QClink";

                if (SlotWiseQC_new == 0)
                    hlnkQC.CssClass = "QClinkBlue";
                if (SlotWiseQC_new == 1)
                    hlnkQC.CssClass = "QClinkyellow";
                if (SlotWiseQC_new == 2)
                    hlnkQC.CssClass = "QClinkgreen";

            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                string lineplannotexist = "";
                StitchingDetail objStitching = new StitchingDetail();
                objStitching.ProductionUnitId = Convert.ToInt32(hdnProductionUnit.Value);
                objStitching.SlotId = Convert.ToInt32(hdnSlotId.Value);
                objStitching.SlotDate = hdnStartDate.Value;
                int UserId = iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.UserID;

                if (gvIEStitchedSlot.Rows.Count > 0)
                {

                    foreach (GridViewRow gvr in gvIEStitchedSlot.Rows)
                    {
                        HiddenField hdnStyleId = (HiddenField)gvr.FindControl("hdnStyleId");
                        HiddenField hdnFrameStyleId = (HiddenField)gvr.FindControl("hdnFrameStyleId");
                        HiddenField hdnLinePlanningId = (HiddenField)gvr.FindControl("hdnLinePlanningId");
                        HiddenField hdnLineNo = (HiddenField)gvr.FindControl("hdnLineNo");
                        HiddenField hdnOrderId = (HiddenField)gvr.FindControl("hdnOrderId");
                        HiddenField hdnOrderDetailId = (HiddenField)gvr.FindControl("hdnOrderDetailId");
                        TextBox txtSlotPass = (TextBox)gvr.FindControl("txtSlotPass");
                        TextBox txtSlotAlt = (TextBox)gvr.FindControl("txtSlotAlt");
                        TextBox txlActualOB = (TextBox)gvr.FindControl("txlActualOB");
                        CheckBox chkMarkAsStyle = (CheckBox)gvr.FindControl("chkMarkAsStyle");
                        CheckBox chkMarkAsDayClose = (CheckBox)gvr.FindControl("chkMarkAsDayClose");
                        HiddenField hdnEfficiency = (HiddenField)gvr.FindControl("hdnEfficiency");
                        CheckBox chkHalfStitch = (CheckBox)gvr.FindControl("chkHalfStitch");
                        Label lblLinePlanningSAM = (Label)gvr.FindControl("lblLinePlanningSAM");
                        HiddenField hdnZeroProductvity = (HiddenField)gvr.FindControl("hdnZeroProductvity");
                        HtmlInputCheckBox ch = (HtmlInputCheckBox)gvr.FindControl("chkpass");
                        TextBox txtComment = (TextBox)gvr.FindControl("txtComment");
                        TextBox txtcot = (TextBox)gvr.FindControl("txtcot");
                        TextBox txtPeakCapecity = (TextBox)gvr.FindControl("txtPeakCapecity");
                        TextBox txtPeakOB = (TextBox)gvr.FindControl("txtPeakOB");
                        Label lblStitchPlanSam = (Label)gvr.FindControl("lblStitchPlanSam");
                        TextBox txtSlotSAM = (TextBox)gvr.FindControl("txtSlotSAM");

                        // Finish

                        TextBox txtActualFinishOB = (TextBox)gvr.FindControl("txtActualFinishOB");
                        TextBox txtActTCOB = (TextBox)gvr.FindControl("txtActTCOB");
                        TextBox txtActPressOB = (TextBox)gvr.FindControl("txtActPressOB");

                        TextBox txtPeakCapTotal = (TextBox)gvr.FindControl("txtPeakCapTotal");
                        TextBox txtPeakCapTC = (TextBox)gvr.FindControl("txtPeakCapTC");
                        TextBox txtPeakCapPress = (TextBox)gvr.FindControl("txtPeakCapPress");

                        TextBox txtPeakOB_Finish = (TextBox)gvr.FindControl("txtPeakOB_Finish");
                        TextBox txtPeakTCOB = (TextBox)gvr.FindControl("txtPeakTCOB");
                        TextBox txtPeakPressOB = (TextBox)gvr.FindControl("txtPeakPressOB");

                        TextBox txtSlotPassFinish = (TextBox)gvr.FindControl("txtSlotPassFinish");
                        HtmlInputCheckBox chkpassFinish = (HtmlInputCheckBox)gvr.FindControl("chkpassFinish");
                        CheckBox chkmarkfinish = (CheckBox)gvr.FindControl("chkmarkfinish");

                        CheckBox chkRequiredActualOB = (CheckBox)gvr.FindControl("chkRequiredActualOB");
                        CheckBox chkSeqCheck = (CheckBox)gvr.FindControl("chkSeqCheck");
                        HiddenField hdnTargetQty = (HiddenField)gvr.FindControl("hdnTargetQty");

                        DropDownList ddlIEName = (DropDownList)gvr.FindControl("ddlIEName");
                        DropDownList ddllQclineMan = (DropDownList)gvr.FindControl("ddllQclineMan");

                        objStitching.LineManId = Convert.ToInt32(ddlIEName.SelectedValue);
                        objStitching.SlotPass = -1;
                        objStitching.SlotAlt = -1;
                        objStitching.ActualOB = -1;
                        objStitching.Pcs = -1;
                        objStitching.Efficiency = -1;
                        objStitching.AvailMins = -1;
                        objStitching.TargetEarnedMins = -1;
                        objStitching.cot = -1;
                        objStitching.PeakCapecity = -1;
                        objStitching.PeakOB = -1;
                        objStitching.FinishingOB = -1;
                        objStitching.ActTCOB = -1;
                        objStitching.ActPressOB = -1;
                        objStitching.PeakCapTotal = -1;
                        objStitching.PeakCapTC = -1;
                        objStitching.PeakCapPress = -1;
                        objStitching.PeakOB_Finish = -1;
                        objStitching.PeakTCOB = -1;
                        objStitching.PeakPressOB = -1;
                        objStitching.FinishingPass = -1;
                        objStitching.IsStitched = false;
                        objStitching.IsDayClosed = false;
                        objStitching.MarkAsFinishedPacked = false;
                        objStitching.TargetQty = -1;
                        objStitching.StitchSAM = -1;
                        objStitching.QCLineManID = Convert.ToInt32(ddllQclineMan.SelectedValue);

                        objStitching.checkRequiredActualOb = (chkRequiredActualOB.Checked == true ? 1 : 0);
                        objStitching.Sequenceframe = (chkSeqCheck.Checked == true ? true : false);

                        if (txtcot.Text != "")
                            objStitching.cot = Convert.ToInt32(txtcot.Text);

                        if (txtPeakCapecity.Text != "")
                            objStitching.PeakCapecity = Convert.ToInt32(txtPeakCapecity.Text);

                        if (txtPeakOB.Text != "")
                            objStitching.PeakOB = Convert.ToInt32(txtPeakOB.Text);

                        if (hdnStyleId != null)
                            objStitching.StyleId = Convert.ToInt32(hdnStyleId.Value);

                        if (hdnFrameStyleId != null)
                            objStitching.FrameStyleId = Convert.ToInt32(hdnFrameStyleId.Value);

                        if (!string.IsNullOrEmpty(hdnLinePlanningId.Value))
                            objStitching.LinePlanningID = Convert.ToInt32(hdnLinePlanningId.Value);

                        if (!string.IsNullOrEmpty(hdnLineNo.Value))
                            objStitching.LineNo = Convert.ToInt32(hdnLineNo.Value);

                        if (hdnOrderId != null)
                            objStitching.OrderID = Convert.ToInt32(hdnOrderId.Value);

                        if (hdnOrderDetailId != null)
                            objStitching.OrderDetailID = Convert.ToInt32(hdnOrderDetailId.Value);

                        if (txtSlotPass.Text != "")
                            objStitching.SlotPass = Convert.ToInt32(txtSlotPass.Text);

                        if (ch.Checked)
                        {
                            hdnZeroProductvity.Value = "1";
                            objStitching.SlotPass = 0;
                        }
                        if (txtSlotAlt.Text != "")
                            objStitching.SlotAlt = Convert.ToInt32(txtSlotAlt.Text);

                        if (txlActualOB.Text != "")
                            objStitching.ActualOB = Convert.ToInt32(txlActualOB.Text);

                        if (!string.IsNullOrEmpty(hdnEfficiency.Value))
                            objStitching.Efficiency = Convert.ToInt32(hdnEfficiency.Value) == 0 ? 1 : Convert.ToInt32(hdnEfficiency.Value);


                        if (lblLinePlanningSAM.Text != "")
                            objStitching.LinePlanningSAM = Convert.ToDouble(lblLinePlanningSAM.Text);

                        if (txtSlotSAM.Text != "")
                            objStitching.StitchSAM = Convert.ToDouble(txtSlotSAM.Text);
                        else
                            objStitching.StitchSAM = lblStitchPlanSam.Text == "" ? 0 : Convert.ToDouble(lblStitchPlanSam.Text);

                        if (chkMarkAsStyle.Enabled == true)
                            objStitching.IsStitched = chkMarkAsStyle.Checked;

                        if (chkMarkAsDayClose.Enabled == true)
                            objStitching.IsDayClosed = chkMarkAsDayClose.Checked;


                        objStitching.IsHalfStitch = chkHalfStitch.Checked;
                        objStitching.StitchRemark = txtComment.Text;
                        objStitching.ZeroProductvity = Convert.ToInt32(hdnZeroProductvity.Value);


                        if (txtActualFinishOB.Text != "")
                            objStitching.FinishingOB = Convert.ToInt32(txtActualFinishOB.Text);

                        if (txtActTCOB.Text != "")
                            objStitching.ActTCOB = Convert.ToInt32(txtActTCOB.Text);

                        if (txtActPressOB.Text != "")
                            objStitching.ActPressOB = Convert.ToInt32(txtActPressOB.Text);

                        if (txtPeakCapTotal.Text != "")
                            objStitching.PeakCapTotal = Convert.ToInt32(txtPeakCapTotal.Text);

                        if (txtPeakCapTC.Text != "")
                            objStitching.PeakCapTC = Convert.ToInt32(txtPeakCapTC.Text);

                        if (txtPeakCapPress.Text != "")
                            objStitching.PeakCapPress = Convert.ToInt32(txtPeakCapPress.Text);

                        if (txtPeakOB_Finish.Text != "")
                            objStitching.PeakOB_Finish = Convert.ToInt32(txtPeakOB_Finish.Text);

                        if (txtPeakTCOB.Text != "")
                            objStitching.PeakTCOB = Convert.ToInt32(txtPeakTCOB.Text);

                        if (txtPeakPressOB.Text != "")
                            objStitching.PeakPressOB = Convert.ToInt32(txtPeakPressOB.Text);

                        if (txtSlotPassFinish.Text != "")
                            objStitching.FinishingPass = Convert.ToInt32(txtSlotPassFinish.Text);

                        objStitching.ZeroProductivity_Finish = chkpassFinish.Checked;
                        objStitching.MarkAsFinishedPacked = chkmarkfinish.Checked;

                        if (txtSlotPass.Text == "")
                        {
                            if (ch.Checked == false)
                            {
                                if (objStitching.ActualOB != 0)
                                {
                                    objStitching.ActualOB = -1;
                                }
                            }
                        }

                        if (txtSlotPassFinish.Text == "")
                        {
                            if (chkpassFinish.Checked == false)
                            {
                                if (objStitching.FinishingOB != 0)
                                {
                                    objStitching.FinishingOB = -1;
                                }
                            }
                        }

                        if (chkHalfStitch.Checked)
                            objStitching.IsAnyHalfStitch = 1;


                        if (objStitching.ActualOB != -1)
                        {
                            if (objStitching.ActualOB == 0)
                            {
                                if ((objStitching.SlotPass == -1) && (objStitching.SlotAlt == -1))
                                {
                                    objStitching.ActualOB = -1;
                                }
                            }
                            if (objStitching.SlotId == 11)
                            {
                                objStitching.AvailMins = Convert.ToDouble(objStitching.ActualOB) * 75 == 0 ? 1 : Convert.ToDouble(objStitching.ActualOB) * 75;
                                objStitching.TargetEarnedMins = Convert.ToDouble(objStitching.ActualOB) * 75 * objStitching.Efficiency == 0 ? 1 : Convert.ToDouble(objStitching.ActualOB) * 75 * objStitching.Efficiency;
                            }
                            else
                            {
                                objStitching.AvailMins = Convert.ToDouble(objStitching.ActualOB) * 60 == 0 ? 1 : Convert.ToDouble(objStitching.ActualOB) * 60;
                                objStitching.TargetEarnedMins = Convert.ToDouble(objStitching.ActualOB) * 60 * objStitching.Efficiency == 0 ? 1 : Convert.ToDouble(objStitching.ActualOB) * 60 * objStitching.Efficiency;
                            }
                        }

                        if (hdnTargetQty != null)
                        {
                            objStitching.TargetQty = Convert.ToInt32(hdnTargetQty.Value);
                        }
                        string[] SSave = new string[2];

                        //if (objStitching.LineNo == 7 && objStitching.OrderID == 31743)
                        //{
                            if ((objStitching.ActualOB != -1) || (objStitching.FinishingOB != -1))
                            {
                                SSave = objProductionController.SaveSlot_LinePlanning_Stitching(objStitching, UserId);
                                if (SSave[0] != "")
                                {
                                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", "alert('Some error occurred during saving');", true);
                                    return;
                                }
                                if (SSave[1] != "")
                                {
                                    lineplannotexist = lineplannotexist + " and " + SSave[1].ToString();
                                }
                            }
                            else
                            {
                                if ((objStitching.IsDayClosed == true) || (objStitching.IsStitched == true) || (objStitching.MarkAsFinishedPacked == true) || (objStitching.Sequenceframe == true))
                                {
                                    SSave = objProductionController.SaveSlot_LinePlanning_Stitching(objStitching, UserId);
                                    if (SSave[0] != "")
                                    {
                                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", "alert('Some error occurred during saving');", true);
                                        return;
                                    }

                                    if (SSave[1] != "")
                                    {
                                        lineplannotexist = lineplannotexist + " and " + SSave[1].ToString();
                                    }
                                }
                            }
                        //}
                    }                    
                }
                SaveClusterData();

                if (hdnSlotClose.Value == "1")
                {
                    objStitching.SlotClose = 1;
                }
                objProductionController.Close_Stitched_FinishTask(objStitching, RowCount, UserId, "Stitching");

                hdnSlotClose.Value = "0";
                btnSubmit.Enabled = false;
                btnSubmit1.Enabled = false;
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", "alert('" + lineplannotexist + "');", true);
               
                Response.Redirect(Request.Url.ToString(), false);

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert(" + ex.Message + ");", true);
            }            

        }

        private void SaveClusterData()
        {  
            objStitching.ProductionUnitId = Convert.ToInt32(hdnProductionUnit.Value);
            objStitching.SlotId = Convert.ToInt32(hdnSlotId.Value);
            objStitching.SlotDate = hdnStartDate.Value;
            int UserId = iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.UserID;

            foreach (GridViewRow gvr in grdfinshingCluster.Rows)
            {
                Label clusterCount = (Label)gvr.FindControl("clusterCount");
                TextBox txtcluster = (TextBox)gvr.FindControl("txtcluster");
                Repeater rptcluster = (Repeater)gvr.FindControl("rptcluster");
                if (rptcluster != null)
                {
                    foreach (RepeaterItem ri in rptcluster.Items)
                    {
                        if (ri.ItemType == ListItemType.Item || ri.ItemType == ListItemType.AlternatingItem)
                        {
                            TextBox txtStylenumber = ri.FindControl("txtStylenumber") as TextBox;
                            // DropDownList ddlSerialNo = ri.FindControl("ddlSerialNo") as DropDownList;
                            TextBox txtSerialNumber = ri.FindControl("txtSerialNumber") as TextBox;
                            DropDownList ddlPrintColorQuantity = ri.FindControl("ddlPrintColorQuantity") as DropDownList;

                            HiddenField hdnserialNo = ri.FindControl("hdnserialNo") as HiddenField;
                            HiddenField hdnprintColorqty = ri.FindControl("hdnprintColorqty") as HiddenField;

                            Label lblFob = ri.FindControl("lblFob") as Label;
                            Label lblFSam = ri.FindControl("lblFSam") as Label;

                            Label lblTotQtyToFin = ri.FindControl("lblTotQtyToFin") as Label;
                            Label lblFinBal = ri.FindControl("lblFinBal") as Label;

                            TextBox txtActualFinishOB = ri.FindControl("txtActualFinishOB") as TextBox;
                            TextBox txtPeakCapTotal = ri.FindControl("txtPeakCapTotal") as TextBox;

                            TextBox txtPeakOB_Finish = ri.FindControl("txtPeakOB_Finish") as TextBox;
                            TextBox txtActTCOB = ri.FindControl("txtActTCOB") as TextBox;

                            TextBox txtPeakCapTC = ri.FindControl("txtPeakCapTC") as TextBox;
                            TextBox txtPeakTCOB = ri.FindControl("txtPeakTCOB") as TextBox;

                            TextBox txtActPressOB = ri.FindControl("txtActPressOB") as TextBox;
                            TextBox txtPeakCapPress = ri.FindControl("txtPeakCapPress") as TextBox;
                            TextBox txtPeakPressOB = ri.FindControl("txtPeakPressOB") as TextBox;

                            TextBox txtSlotPassFinish = ri.FindControl("txtSlotPassFinish") as TextBox;

                            HtmlInputCheckBox chkpassFinish = (HtmlInputCheckBox)ri.FindControl("chkpassFinish");
                            CheckBox chkmarkfinish = (CheckBox)ri.FindControl("chkmarkfinish");
                            CheckBox chkMarkAsDayClose = (CheckBox)ri.FindControl("chkMarkAsDayClose");

                            TextBox txtComment = ri.FindControl("txtComment") as TextBox;

                            HiddenField hdnOrderDetailsID = ri.FindControl("hdnOrderDetailsID") as HiddenField;

                            objStitching.SlotPass = -1;
                            objStitching.SlotAlt = -1;
                            objStitching.ActualOB = -1;
                            objStitching.Pcs = -1;
                            objStitching.Efficiency = -1;
                            objStitching.AvailMins = -1;
                            objStitching.TargetEarnedMins = -1;
                            objStitching.cot = -1;
                            objStitching.PeakCapecity = -1;
                            objStitching.PeakOB = -1;
                            objStitching.FinishingOB = -1;
                            objStitching.ActTCOB = -1;
                            objStitching.ActPressOB = -1;
                            objStitching.PeakCapTotal = -1;
                            objStitching.PeakCapTC = -1;
                            objStitching.PeakCapPress = -1;
                            objStitching.PeakOB_Finish = -1;
                            objStitching.PeakTCOB = -1;
                            objStitching.PeakPressOB = -1;
                            objStitching.FinishingPass = -1;
                            objStitching.IsStitched = false;
                            objStitching.IsDayClosed = false;
                            objStitching.MarkAsFinishedPacked = false;
                            objStitching.ClusterID = Convert.ToInt32(clusterCount.Text.Replace("Cluster ", ""));

                            if (txtStylenumber != null && txtStylenumber.Text != "")
                                objStitching.StyleNumber = txtStylenumber.Text.Trim();
                            else
                            {
                                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('please enter style number');", true);
                                return;
                            }
                            if (txtSerialNumber.Text != "")
                            {
                                List<Department> OrderID = new List<Department>();
                                OrderID = objdept.getUsp_GetOderIDnew("ORDERID", txtSerialNumber.Text.Trim());
                                objStitching.OrderID = Convert.ToInt32(OrderID[0].OrderID);

                                if (objStitching.OrderID == 0)
                                {
                                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert(" + txtSerialNumber.Text + " this serial number is not valid');", true);
                                }
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('please select at least one serial number');", true);
                                return;
                            }

                            if ((ddlPrintColorQuantity != null && ddlPrintColorQuantity.SelectedValue != "-1" && ddlPrintColorQuantity.SelectedValue != "") || ((hdnprintColorqty.Value != "") && (hdnprintColorqty.Value != "0") && (hdnprintColorqty.Value != "-1")))
                                objStitching.OrderDetailID = Convert.ToInt32(ddlPrintColorQuantity.SelectedValue == "" ? hdnprintColorqty.Value : ddlPrintColorQuantity.SelectedValue);
                            else
                            {
                                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('please select at least one contract number');", true);
                                return;
                            }
                            if (txtSlotPassFinish.Text != "")
                                objStitching.FinishingPass = Convert.ToInt32(txtSlotPassFinish.Text);

                            if (chkMarkAsDayClose.Enabled == true)
                                objStitching.IsDayClosed = chkMarkAsDayClose.Checked;

                            objStitching.StitchRemark = txtComment.Text;

                            if (txtActualFinishOB.Text != "")
                                objStitching.FinishingOB = Convert.ToInt32(txtActualFinishOB.Text);

                            if (txtActTCOB.Text != "")
                                objStitching.ActTCOB = Convert.ToInt32(txtActTCOB.Text);

                            if (txtActPressOB.Text != "")
                                objStitching.ActPressOB = Convert.ToInt32(txtActPressOB.Text);

                            if (txtPeakCapTotal.Text != "")
                                objStitching.PeakCapTotal = Convert.ToInt32(txtPeakCapTotal.Text);

                            if (txtPeakCapTC.Text != "")
                                objStitching.PeakCapTC = Convert.ToInt32(txtPeakCapTC.Text);

                            if (txtPeakCapPress.Text != "")
                                objStitching.PeakCapPress = Convert.ToInt32(txtPeakCapPress.Text);

                            if (txtPeakOB_Finish.Text != "")
                                objStitching.PeakOB_Finish = Convert.ToInt32(txtPeakOB_Finish.Text);

                            if (txtPeakTCOB.Text != "")
                                objStitching.PeakTCOB = Convert.ToInt32(txtPeakTCOB.Text);

                            if (txtPeakPressOB.Text != "")
                                objStitching.PeakPressOB = Convert.ToInt32(txtPeakPressOB.Text);

                            if (txtSlotPassFinish.Text != "")
                                objStitching.FinishingPass = Convert.ToInt32(txtSlotPassFinish.Text);

                            objStitching.ZeroProductivity_Finish = chkpassFinish.Checked;
                            objStitching.MarkAsFinishedPacked = chkmarkfinish.Checked;

                            if (txtSlotPassFinish.Text == "")
                            {
                                if (chkpassFinish.Checked == false)
                                    objStitching.FinishingOB = -1;
                            }
                            else
                            {
                                DepartmentController objdept = new DepartmentController();
                                if (hdnOrderDetailsID != null && hdnOrderDetailsID.Value != "")
                                {
                                    string PendingVal = objdept.Getfinishingsam(objStitching.OrderDetailID, 0, objStitching.ProductionUnitId, "FINSHINGQTY");
                                    char[] delimiters = new char[] { '_' };
                                    string[] parts = PendingVal.Split(delimiters,
                                                     StringSplitOptions.RemoveEmptyEntries);
                                    int val = Convert.ToInt32(parts[1]);

                                    if (txtSlotPassFinish.Text != "" && txtSlotPassFinish.Text != "0")
                                    {
                                        int Bal = val - Convert.ToInt32(txtSlotPassFinish.Text);
                                        if (Bal < 0)
                                        {
                                            //ShowAlert("There is no Finish balance qty available for" + " " + txtStylenumber.Text);
                                            Response.Write("<script>alert('There is no Finish balance qty available for '" + txtStylenumber.Text + "');</script>");
                                            //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('There is no Finish balance qty available for '" + txtStylenumber.Text + "');", true);
                                            txtSlotPassFinish.BorderColor = System.Drawing.Color.Red;
                                            break;
                                        }
                                    }
                                }
                            }
                            if (txtActualFinishOB.Text == "0")
                            {
                                objStitching.FinishingOB = Convert.ToInt32(txtActualFinishOB.Text);
                            }
                            if (objStitching.FinishingOB != -1)
                            {
                                string sSave = objProductionController.SaveSlot_Cluster_Stitching(objStitching, UserId);
                                if (sSave != "")
                                {
                                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('Some error occurred during saving');", true);
                                    return;
                                }
                            }
                            else
                            {
                                if ((objStitching.IsDayClosed == true) || (objStitching.MarkAsFinishedPacked == true))
                                {
                                    string sSave = objProductionController.SaveSlot_Cluster_Stitching(objStitching, UserId);
                                    if (sSave != "")
                                    {
                                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('Some error occurred during saving');", true);
                                        return;
                                    }
                                }
                            }
                            //objProductionController.SaveSlot_Cluster_Delete(objStitching, UserId);//delete last insert value
                        }
                    }
                }
            }
        }

        protected void ddlPrintColorQuantity_SelectedIndexChanged(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            GridViewRow gvRow = (GridViewRow)txt.Parent.Parent;


            Label clusterCount = (Label)gvRow.FindControl("clusterCount");
            TextBox txtcluster = (TextBox)gvRow.FindControl("txtcluster");
            Repeater rptcluster = (Repeater)gvRow.FindControl("rptcluster");
            DropDownList ddlserialNoSerach = (DropDownList)gvRow.FindControl("ddlserialNoSerach");
            DropDownList ddlPrintColorQuantity = (DropDownList)gvRow.FindControl("ddlPrintColorQuantity");
            foreach (RepeaterItem item in rptcluster.Items)
            {
                HiddenField hdnCheckRepOrderDetailsID = (HiddenField)item.FindControl("hdnCheckRepOrderDetailsID");

                if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                {
                    DropDownList ddlPrintColorQuantity_rep = (DropDownList)item.FindControl("ddlPrintColorQuantity");
                    if (ddlPrintColorQuantity_rep.SelectedValue != "-1" && ddlPrintColorQuantity_rep != null)
                    {
                        if (ddlPrintColorQuantity.SelectedValue == ddlPrintColorQuantity_rep.SelectedValue)
                        {
                            ShowAlert("Selected contract order already taken please choose another");
                            return;
                        }

                    }

                }
            }

            TextBox txtStylenumber = (TextBox)gvRow.FindControl("txtStylenumber");
            HiddenField hdnserialNo = (HiddenField)gvRow.FindControl("hdnserialNo");
            HiddenField hdnprintColorqty = (HiddenField)gvRow.FindControl("hdnprintColorqty");

            hdnprintColorqty.Value = ddlPrintColorQuantity.SelectedValue;

            binddropdown("SERIALNO", ddlserialNoSerach, Convert.ToInt32(hdnserialNo.Value), txtStylenumber.Text);
            binddropdown("PRINT", ddlPrintColorQuantity, Convert.ToInt32(hdnprintColorqty.Value), hdnserialNo.Value);

            StartDate = hdnStartDate.Value;
            LineNo = 0;
            ProductionUnit = Convert.ToInt32(hdnProductionUnit.Value);
            if (ddlSlot.SelectedValue != "-1" && Convert.ToInt32(txtcluster.Text) > 0)
            {
                hdnSlotId.Value = ddlSlot.SelectedValue;
                string[] SlotName = ddlSlot.SelectedItem.Text.Split(')');
                hdnSlotName.Value = SlotName[1].ToString();

                SlotId = Convert.ToInt32(hdnSlotId.Value);

                int UserId = iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.UserID;
                //GetFinshingClusterDetails(string StartDate="", int Lineno=0, int SlotId=0, int ProductionUnit=0, string Type="", int UserId=0)
                DataSet dss = new DataSet();
                dss = objProductionController.GetFinshingClusterContarctDetails(StartDate, SlotId, ProductionUnit, "2", UserId, Convert.ToInt32(clusterCount.Text.Replace("Cluster ", "")), Convert.ToInt32(txtcluster.Text));
                DataTable dt = new DataTable();
                dt = dss.Tables[0];

                if (rptcluster != null && dt.Rows.Count > 0)
                {
                    rptcluster.DataSource = dt;
                    rptcluster.DataBind();

                }
            }
        }

        public void binddropdown(string Flag, DropDownList ddl, int selectedval, string param)
        {
            DepartmentController dptcontoller = new DepartmentController();

            if (Flag == "SERIALNO")
            {
                DataTable dt = dptcontoller.GetSerialNumbercluster(param);
                ddl.DataSource = dt;
                ddl.DataValueField = "OrderID";
                ddl.DataTextField = "SerialNumber";
                ddl.DataBind();
                ddl.SelectedValue = selectedval.ToString();
            }
            if (Flag == "PRINT")
            {
                DataTable dt = dptcontoller.GetPrintColorQtycluster(Convert.ToInt32(param));
                ddl.DataSource = dt;
                ddl.DataValueField = "OrderDetailsID";
                ddl.DataTextField = "PrintColorQty";
                ddl.DataBind();
                ddl.SelectedValue = selectedval.ToString();
            }
        }

        public void RetainClusterRecord(Repeater rpt, string ClusterCount, out string strerror)
        {
            strerror = string.Empty;
            try
            {
                //StitchingDetail objStitching = new StitchingDetail();
                objStitching.ProductionUnitId = Convert.ToInt32(hdnProductionUnit.Value);
                objStitching.SlotId = Convert.ToInt32(hdnSlotId.Value);
                objStitching.SlotDate = hdnStartDate.Value;
                int UserId = iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.UserID;

                foreach (GridViewRow gvr in grdfinshingCluster.Rows)
                {
                    Label clusterCount = (Label)gvr.FindControl("clusterCount");
                    TextBox txtcluster = (TextBox)gvr.FindControl("txtcluster");
                    Repeater rptcluster = (Repeater)gvr.FindControl("rptcluster");
                    ClusterCount = clusterCount.Text;
                    if (rptcluster != null)
                    {
                        foreach (RepeaterItem ri in rptcluster.Items)
                        {
                            if (ri.ItemType == ListItemType.Item || ri.ItemType == ListItemType.AlternatingItem)
                            {
                                TextBox txtStylenumber = ri.FindControl("txtStylenumber") as TextBox;

                                //  DropDownList ddlSerialNo = ri.FindControl("ddlSerialNo") as DropDownList;
                                TextBox txtSerialNumber = ri.FindControl("txtSerialNumber") as TextBox;
                                DropDownList ddlPrintColorQuantity = ri.FindControl("ddlPrintColorQuantity") as DropDownList;

                                HiddenField hdnserialNo = ri.FindControl("hdnserialNo") as HiddenField;
                                HiddenField hdnprintColorqty = ri.FindControl("hdnprintColorqty") as HiddenField;

                                Label lblFinishOB = ri.FindControl("lblFinishOB") as Label;
                                Label lblLinePlanning_FinishSAM = ri.FindControl("lblLinePlanning_FinishSAM") as Label;



                                Label lblTotQtyToFin = ri.FindControl("lblTotQtyToFin") as Label;
                                Label lblFinBal = ri.FindControl("lblFinBal") as Label;

                                TextBox txtActualFinishOB = ri.FindControl("txtActualFinishOB") as TextBox;
                                TextBox txtPeakCapTotal = ri.FindControl("txtPeakCapTotal") as TextBox;

                                TextBox txtPeakOB_Finish = ri.FindControl("txtPeakOB_Finish") as TextBox;
                                TextBox txtActTCOB = ri.FindControl("txtActTCOB") as TextBox;

                                TextBox txtPeakCapTC = ri.FindControl("txtPeakCapTC") as TextBox;
                                TextBox txtPeakTCOB = ri.FindControl("txtPeakTCOB") as TextBox;

                                TextBox txtActPressOB = ri.FindControl("txtActPressOB") as TextBox;
                                TextBox txtPeakCapPress = ri.FindControl("txtPeakCapPress") as TextBox;
                                TextBox txtPeakPressOB = ri.FindControl("txtPeakPressOB") as TextBox;

                                TextBox txtSlotPassFinish = ri.FindControl("txtSlotPassFinish") as TextBox;

                                HtmlInputCheckBox chkpassFinish = (HtmlInputCheckBox)ri.FindControl("chkpassFinish");
                                CheckBox chkmarkfinish = (CheckBox)ri.FindControl("chkmarkfinish");
                                CheckBox chkMarkAsDayClose = (CheckBox)ri.FindControl("chkMarkAsDayClose");

                                TextBox txtComment = ri.FindControl("txtComment") as TextBox;

                                Label lblLineStitchQty = ri.FindControl("lblLineStitchQty") as Label;
                                Label txtToBeFinish = ri.FindControl("txtToBeFinish") as Label;
                                HiddenField hdnLineFinishedQty = ri.FindControl("hdnLineFinishedQty") as HiddenField;


                                HiddenField hdnisfinsh = ri.FindControl("hdnisfinsh") as HiddenField;
                                HiddenField hdnsampleimageurl = ri.FindControl("hdnsampleimageurl") as HiddenField;
                                HiddenField hdnslotdescription = ri.FindControl("hdnslotdescription") as HiddenField;
                                HiddenField hdnfabric1Details = ri.FindControl("hdnfabric1Details") as HiddenField;

                                HiddenField hdnexfact = ri.FindControl("hdnexfact") as HiddenField;
                                HiddenField hdnexfactdate = ri.FindControl("hdnexfactdate") as HiddenField;
                                HiddenField hdnOrderDetailsID = ri.FindControl("hdnOrderDetailsID") as HiddenField;

                                objStitching.SlotPass = -1;
                                objStitching.SlotAlt = -1;
                                objStitching.ActualOB = -1;
                                objStitching.Pcs = -1;
                                objStitching.Efficiency = -1;
                                objStitching.AvailMins = -1;
                                objStitching.TargetEarnedMins = -1;
                                objStitching.cot = -1;
                                objStitching.PeakCapecity = -1;
                                objStitching.PeakOB = -1;
                                objStitching.FinishingOB = -1;
                                objStitching.ActTCOB = -1;
                                objStitching.ActPressOB = -1;
                                objStitching.PeakCapTotal = -1;
                                objStitching.PeakCapTC = -1;
                                objStitching.PeakCapPress = -1;
                                objStitching.PeakOB_Finish = -1;
                                objStitching.PeakTCOB = -1;
                                objStitching.PeakPressOB = -1;
                                objStitching.FinishingPass = -1;
                                objStitching.IsStitched = false;
                                objStitching.IsDayClosed = false;
                                objStitching.MarkAsFinishedPacked = false;
                                objStitching.SerialNumber = "";


                                objStitching.ClusterID = Convert.ToInt32(ClusterCount.Replace("Cluster ", ""));



                                if (txtStylenumber != null && txtStylenumber.Text != "")
                                    objStitching.StyleNumber = txtStylenumber.Text.Trim();
                                else
                                {
                                    strerror = "please enter style number";
                                    return;
                                }

                                DepartmentController objdeptd = new DepartmentController();
                                if (txtSerialNumber.Text != "")
                                {
                                    List<Department> OrderID = new List<Department>();

                                    OrderID = objdeptd.getUsp_GetOderID("ORDERID", txtSerialNumber.Text.Trim());
                                    objStitching.OrderID = Convert.ToInt32(OrderID[0].OrderID);

                                    if (objStitching.OrderID == 0)
                                    {
                                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert(" + txtSerialNumber.Text + " this serial number is not valid');", true);
                                        // return;

                                    }
                                }
                                else
                                {
                                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('please select at least one serial number');", true);
                                    return;
                                }

                                if ((ddlPrintColorQuantity != null && ddlPrintColorQuantity.SelectedValue != "-1" && ddlPrintColorQuantity.SelectedValue != "") || ((hdnprintColorqty.Value != "") && (hdnprintColorqty.Value != "0") && (hdnprintColorqty.Value != "-1")))
                                    objStitching.OrderDetailID = Convert.ToInt32(ddlPrintColorQuantity.SelectedValue == "" ? hdnprintColorqty.Value : ddlPrintColorQuantity.SelectedValue);
                                else
                                {
                                    strerror = "please select at least one contract number";
                                    // ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('please select at least one contract number');", true);
                                    return;
                                }
                                if (txtSlotPassFinish.Text != "")
                                    objStitching.FinishingPass = Convert.ToInt32(txtSlotPassFinish.Text);

                                if (chkMarkAsDayClose.Enabled == true)
                                    objStitching.IsDayClosed = chkMarkAsDayClose.Checked;

                                objStitching.StitchRemark = txtComment.Text;

                                if (txtActualFinishOB.Text != "")
                                {
                                    objStitching.FinishingOB = Convert.ToInt32(txtActualFinishOB.Text);
                                    if (txtStylenumber.Enabled == true)
                                    {
                                        if (txtSlotPassFinish.Text == "" && chkpassFinish.Checked == false)
                                        {
                                            strerror = "Please enter pass value or select nil production";
                                            // ShowAlert("Please enter pass value or select nil production");
                                            return;
                                        }
                                    }
                                }
                                else
                                {
                                    if (txtStylenumber.Enabled == true)
                                    {
                                        strerror = "Please fill actual total OB first";
                                        //ShowAlert("Please fill actual total OB first");
                                        return;
                                    }

                                }
                                if (txtActTCOB.Text != "")
                                    objStitching.ActTCOB = Convert.ToInt32(txtActTCOB.Text);

                                if (txtActPressOB.Text != "")
                                    objStitching.ActPressOB = Convert.ToInt32(txtActPressOB.Text);

                                if (txtPeakCapTotal.Text != "")
                                    objStitching.PeakCapTotal = Convert.ToInt32(txtPeakCapTotal.Text);

                                if (txtPeakCapTC.Text != "")
                                    objStitching.PeakCapTC = Convert.ToInt32(txtPeakCapTC.Text);

                                if (txtPeakCapPress.Text != "")
                                    objStitching.PeakCapPress = Convert.ToInt32(txtPeakCapPress.Text);

                                if (txtPeakOB_Finish.Text != "")
                                    objStitching.PeakOB_Finish = Convert.ToInt32(txtPeakOB_Finish.Text);

                                if (txtPeakTCOB.Text != "")
                                    objStitching.PeakTCOB = Convert.ToInt32(txtPeakTCOB.Text);

                                if (txtPeakPressOB.Text != "")
                                    objStitching.PeakPressOB = Convert.ToInt32(txtPeakPressOB.Text);

                                if (txtSlotPassFinish.Text != "")
                                    objStitching.FinishingPass = Convert.ToInt32(txtSlotPassFinish.Text);

                                objStitching.ZeroProductivity_Finish = chkpassFinish.Checked;
                                objStitching.MarkAsFinishedPacked = chkmarkfinish.Checked;

                                if (txtSlotPassFinish.Text == "")
                                {
                                    if (chkpassFinish.Checked == false)
                                        objStitching.FinishingOB = -1;
                                }
                                DepartmentController objdept = new DepartmentController();
                                if (objStitching.OrderDetailID != -1 && objStitching.OrderDetailID.ToString() != "")
                                {
                                    string PendingVal = objdept.Getfinishingsam(objStitching.OrderDetailID, 0, objStitching.ProductionUnitId, "FINSHINGQTY");
                                    char[] delimiters = new char[] { '_' };
                                    string[] parts = PendingVal.Split(delimiters,
                                                     StringSplitOptions.RemoveEmptyEntries);
                                    int val = Convert.ToInt32(parts[1]);

                                    if (txtSlotPassFinish.Text != "" && txtSlotPassFinish.Text != "0")
                                    {
                                        int Bal = val - Convert.ToInt32(txtSlotPassFinish.Text);
                                        if (Bal < 0)
                                        {
                                            //ShowAlert("There is no Finish balance qty available for" + " " + txtStylenumber.Text);
                                            Response.Write("<script>alert('There is no Finish balance qty available for '" + txtStylenumber.Text + "');</script>");
                                            // ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('There is no Finish balance qty available for '" + txtStylenumber.Text + "');", true);
                                            txtSlotPassFinish.BorderColor = System.Drawing.Color.Red;
                                            break;
                                        }
                                    }
                                }
                                if (objStitching.FinishingOB != -1)
                                {
                                    string sSave = objProductionController.SaveSlot_Cluster_Stitching(objStitching, UserId, "CLUSTER");
                                    if (sSave != "")
                                    {
                                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('Some error occurred during saving');", true);
                                        return;
                                    }


                                    else
                                    {
                                        if ((objStitching.IsDayClosed == true) || (objStitching.MarkAsFinishedPacked == true))
                                        {
                                            string sSaves = objProductionController.SaveSlot_Cluster_Stitching(objStitching, UserId, "CLUSTER");
                                            if (sSaves != "")
                                            {
                                                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('Some error occurred during saving');", true);
                                                return;
                                            }
                                        }
                                    }
                                    ShowAlert("Record updated successfully");
                                }
                            }
                        }


                    }
                }
            }
            catch (Exception ex)
            {
                ShowAlert(ex.ToString());
            }
        }


    }
}

