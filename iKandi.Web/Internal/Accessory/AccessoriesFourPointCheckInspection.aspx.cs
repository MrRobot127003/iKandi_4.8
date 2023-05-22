using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iKandi.BLL;
using System.Data;
using iKandi.Common;
using iKandi.Web.Components;

namespace iKandi.Web.Internal.Accessory
{
    public partial class AccessoriesFourPointCheckInspection : System.Web.UI.Page
    {
        int SupplierPoId;
        int SrvId;
        int Status;
        int UnitId;
        int Flag;
        int LabReport;
        static decimal TotalQuantitySRV;
        static string GarmentUnit;
        AccessoryWorkingController objAccessoryWorking = new AccessoryWorkingController();
        PermissionController objPermissionController = new PermissionController();
        AdminController adminController = new AdminController();
        static List<AccessoriesInspect> AccessoriesInspectionList = new List<AccessoriesInspect>();
        static List<int> DeletetedInspectionId = new List<int>();
        public int Count
        {
            get;
            set;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (iKandi.Web.Components.ApplicationHelper.LoggedInUser == null || iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData == null)
                Response.Redirect("~/public/Login.aspx");

            if (Request.QueryString["SupplierPoId"] != null && Request.QueryString["SrvId"] != null)
            {
                SupplierPoId = Convert.ToInt32(Request.QueryString["SupplierPoId"]);
                SrvId = Convert.ToInt32(Request.QueryString["SrvId"]);
                UnitId = Convert.ToInt32(Request.QueryString["UnitId"]);
                hdnSupplierPoId.Value = SupplierPoId.ToString();

            }
            if (Request.QueryString["Status"] != null)
            {
                Status = Convert.ToInt32(Request.QueryString["Status"]);

            }
            else
            {
                Status = 0;
            }
            if (Request.QueryString["Flag"] != null)
            {
                Flag = Convert.ToInt32(Request.QueryString["Flag"]);
            }
            else
            {
                Flag = 0;
            }
            if (Request.QueryString["LabReports"] != null)
            {
                LabReport = Convert.ToInt32(Request.QueryString["LabReports"]);
                hdnLabId.Value = LabReport.ToString();
            }
            else
            {
                LabReport = -1;
                hdnLabId.Value = LabReport.ToString();
            }


            if (!IsPostBack)
            {
                if (Flag == 1)
                {
                    CloseButton.Visible = false;
                }
                UserPermission();
                Bind();
            }
        }

        private void UserPermission()
        {
            DataTable dtLabspecimen = objPermissionController.GetAccessoryFourPointCheckPermission(ApplicationHelper.LoggedInUser.UserData.PrimaryGroupID, ApplicationHelper.LoggedInUser.UserData.DesignationID, 372).Tables[0];

            if (dtLabspecimen.Rows.Count > 0)
            {
                if (Convert.ToBoolean(dtLabspecimen.Rows[0]["PermisionWrite"]) == true)
                {
                    //txtInternalLabSpecimanCount.Attributes.Add("readonly", "false");
                    //txtExternalLabSpecimanCount.Attributes.Add("readonly", "false");
                    //btnSaveShortfall.Enabled = true;  
                    rdybtnCommercialPass.Enabled = true;
                    rbtFinalDecisionFail.Enabled = true;
                    rbtFinalDecisionPass.Enabled = true;
                }
                else
                {
                    txtInternalLabSpecimanCount.Attributes.Add("readonly", "readonly");
                    txtExternalLabSpecimanCount.Attributes.Add("readonly", "readonly");
                    rdybtnCommercialPass.Enabled = false;
                    rbtFinalDecisionFail.Enabled = false;
                    rbtFinalDecisionPass.Enabled = false;
                }
            }

            DataTable dtSentoLab = objPermissionController.GetAccessoryFourPointCheckPermission(ApplicationHelper.LoggedInUser.UserData.PrimaryGroupID, ApplicationHelper.LoggedInUser.UserData.DesignationID, 373).Tables[0];

            if (dtSentoLab.Rows.Count > 0)
            {
                if (Convert.ToBoolean(dtSentoLab.Rows[0]["PermisionWrite"]) == true)
                {
                    chkInternalSentToLab.Enabled = true;
                    chkExternalSentToLab.Enabled = true;
                }
                else
                {
                    //chkInternalSentToLab.Attributes.Add("readonly", "readonly");
                    //chkExternalSentToLab.Attributes.Add("readonly", "readonly");
                    chkInternalSentToLab.Enabled = false;
                    chkExternalSentToLab.Enabled = false;
                }
            }

            DataTable dtReceiveInLab = objPermissionController.GetAccessoryFourPointCheckPermission(ApplicationHelper.LoggedInUser.UserData.PrimaryGroupID, ApplicationHelper.LoggedInUser.UserData.DesignationID, 374).Tables[0];

            if (dtReceiveInLab.Rows.Count > 0)
            {
                if (Convert.ToBoolean(dtReceiveInLab.Rows[0]["PermisionWrite"]) == true)
                {
                    //chkInternalReceivedInLab.Attributes.Add("readonly", "false");
                    //chkExternalReceivedInLab.Attributes.Add("readonly", "false");                       
                    chkInternalReceivedInLab.Enabled = true;
                    chkExternalReceivedInLab.Enabled = true;
                    rdyBtnLabDecPassInter.Enabled = true;
                    rdyBtnLabDecFailInter.Enabled = true;
                    rdyBtnLabDecPassExt.Enabled = true;
                    rdyBtnLabDecFailExt.Enabled = true;
                }
                else
                {
                    //chkInternalReceivedInLab.Attributes.Add("readonly", "readonly");
                    //chkExternalReceivedInLab.Attributes.Add("readonly", "readonly");
                    chkInternalReceivedInLab.Enabled = false;
                    chkExternalReceivedInLab.Enabled = false;
                    rdyBtnLabDecPassInter.Enabled = false;
                    rdyBtnLabDecFailInter.Enabled = false;
                    rdyBtnLabDecPassExt.Enabled = false;
                    rdyBtnLabDecFailExt.Enabled = false;

                }
            }

            DataTable dtLabReport = objPermissionController.GetAccessoryFourPointCheckPermission(ApplicationHelper.LoggedInUser.UserData.PrimaryGroupID, ApplicationHelper.LoggedInUser.UserData.DesignationID, 375).Tables[0];

            if (dtLabReport.Rows.Count > 0)
            {
                if (Convert.ToBoolean(dtLabReport.Rows[0]["PermisionWrite"]) == true)
                {
                    //hylnkInternalLabReportText.Attributes.Add("disabled", "true");
                    //hylnkExternalLabReportText.Attributes.Add("disabled", "true");

                }
                else
                {
                    hylnkInternalLabReportText.Attributes.Add("onclick", "void(0)");
                    hylnkExternalLabReportText.Attributes.Add("onclick", "void(0)");
                }

                DataTable dtFinalDecision = objPermissionController.GetAccessoryFourPointCheckPermission(ApplicationHelper.LoggedInUser.UserData.PrimaryGroupID, ApplicationHelper.LoggedInUser.UserData.DesignationID, 376).Tables[0];

                if (dtFinalDecision.Rows.Count > 0)
                {
                    if (Convert.ToBoolean(dtFinalDecision.Rows[0]["PermisionWrite"]) == true)
                    {
                        //rbtFinalDecisionPass.Attributes.Add("readonly", "false");
                        //rbtFinalDecisionFail.Attributes.Add("readonly", "false");
                        rbtFinalDecisionPass.Enabled = true;
                        rbtFinalDecisionFail.Enabled = true;
                        rdybtnCommercialPass.Enabled = true;
                    }
                    else
                    {
                        //rbtFinalDecisionPass.Attributes.Add("readonly", "readonly");
                        //rbtFinalDecisionFail.Attributes.Add("readonly", "readonly");
                        rbtFinalDecisionPass.Enabled = false;
                        rbtFinalDecisionFail.Enabled = false;
                        rdybtnCommercialPass.Enabled = false;
                    }
                }

                DataTable dtFailRaise = objPermissionController.GetAccessoryFourPointCheckPermission(ApplicationHelper.LoggedInUser.UserData.PrimaryGroupID, ApplicationHelper.LoggedInUser.UserData.DesignationID, 377).Tables[0];

                if (dtFailRaise.Rows.Count > 0)
                {
                    if (Convert.ToBoolean(dtFailRaise.Rows[0]["PermisionWrite"]) == true)
                    {
                        //txtFailedRaisedDebit.Attributes.Add("readonly", "false");
                    }
                    else
                    {
                        txtFailedRaisedDebit.Attributes.Add("readonly", "readonly");
                    }
                }

                DataTable dtFailStock = objPermissionController.GetAccessoryFourPointCheckPermission(ApplicationHelper.LoggedInUser.UserData.PrimaryGroupID, ApplicationHelper.LoggedInUser.UserData.DesignationID, 378).Tables[0];

                if (dtFailStock.Rows.Count > 0)
                {
                    if (Convert.ToBoolean(dtFailStock.Rows[0]["PermisionWrite"]) == true)
                    {
                        //txtFailedStock.Attributes.Add("readonly", "false");
                    }
                    else
                    {
                        txtFailedStock.Attributes.Add("readonly", "readonly");
                    }
                }

                DataTable dtFailGoodStock = objPermissionController.GetAccessoryFourPointCheckPermission(ApplicationHelper.LoggedInUser.UserData.PrimaryGroupID, ApplicationHelper.LoggedInUser.UserData.DesignationID, 379).Tables[0];

                if (dtFailGoodStock.Rows.Count > 0)
                {
                    if (Convert.ToBoolean(dtFailGoodStock.Rows[0]["PermisionWrite"]) == true)
                    {
                        //txtFailedGoodStock.Attributes.Add("readonly", "false");
                    }
                    else
                    {
                        txtFailedGoodStock.Attributes.Add("readonly", "readonly");
                    }
                }

                DataTable dtFailParticular = objPermissionController.GetAccessoryFourPointCheckPermission(ApplicationHelper.LoggedInUser.UserData.PrimaryGroupID, ApplicationHelper.LoggedInUser.UserData.DesignationID, 380).Tables[0];

                if (dtFailParticular.Rows.Count > 0)
                {
                    if (Convert.ToBoolean(dtFailParticular.Rows[0]["PermisionWrite"]) == true)
                    {
                        // txtFailedParticular.Attributes.Add("readonly", "false");
                    }
                    else
                    {
                        txtFailedParticular.Attributes.Add("readonly", "readonly");
                    }
                }

                DataTable dtExtraRaise = objPermissionController.GetAccessoryFourPointCheckPermission(ApplicationHelper.LoggedInUser.UserData.PrimaryGroupID, ApplicationHelper.LoggedInUser.UserData.DesignationID, 381).Tables[0];

                if (dtExtraRaise.Rows.Count > 0)
                {
                    if (Convert.ToBoolean(dtExtraRaise.Rows[0]["PermisionWrite"]) == true)
                    {
                        // txtInspectRaisedDebit.Attributes.Add("readonly", "false");
                    }
                    else
                    {
                        txtInspectRaisedDebit.Attributes.Add("readonly", "readonly");
                    }
                }

                DataTable dtExtraUsable = objPermissionController.GetAccessoryFourPointCheckPermission(ApplicationHelper.LoggedInUser.UserData.PrimaryGroupID, ApplicationHelper.LoggedInUser.UserData.DesignationID, 382).Tables[0];

                if (dtExtraUsable.Rows.Count > 0)
                {
                    if (Convert.ToBoolean(dtExtraUsable.Rows[0]["PermisionWrite"]) == true)
                    {
                        //txtInspectUsableStock.Attributes.Add("readonly", "false");
                    }
                    else
                    {
                        txtInspectUsableStock.Attributes.Add("readonly", "readonly");
                    }
                }

                DataTable dtExtraParticular = objPermissionController.GetAccessoryFourPointCheckPermission(ApplicationHelper.LoggedInUser.UserData.PrimaryGroupID, ApplicationHelper.LoggedInUser.UserData.DesignationID, 383).Tables[0];

                if (dtExtraParticular.Rows.Count > 0)
                {
                    if (Convert.ToBoolean(dtExtraParticular.Rows[0]["PermisionWrite"]) == true)
                    {
                        //txtInspectParticular.Attributes.Add("readonly", "false");
                    }
                    else
                    {
                        txtInspectParticular.Attributes.Add("readonly", "readonly");
                    }
                }

                DataTable dtLabMgr = objPermissionController.GetAccessoryFourPointCheckPermission(ApplicationHelper.LoggedInUser.UserData.PrimaryGroupID, ApplicationHelper.LoggedInUser.UserData.DesignationID, 384).Tables[0];

                if (dtLabMgr.Rows.Count > 0)
                {
                    if (Convert.ToBoolean(dtLabMgr.Rows[0]["PermisionWrite"]) == true)
                    {

                        if (chkInternalSentToLab.Checked && !chkExternalSentToLab.Checked && rdyBtnLabDecPassInter.Checked || rdyBtnLabDecFailInter.Checked)
                        {
                            //chkLabManager.Attributes.Add("readonly", "false");
                            chkLabManager.Enabled = true;
                        }
                        else if (!chkInternalSentToLab.Checked && chkExternalSentToLab.Checked && rdyBtnLabDecPassExt.Checked || rdyBtnLabDecFailExt.Checked)
                        {
                            chkLabManager.Enabled = true;
                        }
                        else if (chkInternalSentToLab.Checked && chkExternalSentToLab.Checked && rdyBtnLabDecPassInter.Checked || rdyBtnLabDecFailInter.Checked && rdyBtnLabDecPassExt.Checked || rdyBtnLabDecFailExt.Checked)
                        {
                            chkLabManager.Enabled = true;
                        }
                        else
                        {
                            chkLabManager.Enabled = false;
                        }
                    }
                    else
                    {
                        //chkLabManager.Attributes.Add("readonly", "readonly");
                        chkLabManager.Enabled = false;
                    }
                }

                DataTable dtAccQA = objPermissionController.GetAccessoryFourPointCheckPermission(ApplicationHelper.LoggedInUser.UserData.PrimaryGroupID, ApplicationHelper.LoggedInUser.UserData.DesignationID, 385).Tables[0];

                if (dtAccQA.Rows.Count > 0)
                {
                    if (Convert.ToBoolean(dtAccQA.Rows[0]["PermisionWrite"]) == true)
                    {
                        //chkAccessoriesQA.Attributes.Add("readonly", "false");
                        if (rdybtnCommercialPass.Checked || rbtFinalDecisionFail.Checked || rbtFinalDecisionPass.Checked)
                        {
                            if (chkInternalSentToLab.Checked && !chkExternalSentToLab.Checked)
                            {

                                chkAccessoriesQA.Enabled = true;
                            }
                            else if (chkInternalSentToLab.Checked && chkExternalSentToLab.Checked)
                            {
                                chkAccessoriesQA.Enabled = true;
                            }
                            else
                            {
                                chkAccessoriesQA.Enabled = false;
                            }

                        }
                        else
                        {
                            chkAccessoriesQA.Enabled = false;
                        }

                    }
                    else
                    {
                        //chkAccessoriesQA.Attributes.Add("readonly", "readonly");
                        chkAccessoriesQA.Enabled = false;
                    }
                }

                DataTable dtAccGM = objPermissionController.GetAccessoryFourPointCheckPermission(ApplicationHelper.LoggedInUser.UserData.PrimaryGroupID, ApplicationHelper.LoggedInUser.UserData.DesignationID, 386).Tables[0];

                if (dtAccGM.Rows.Count > 0)
                {
                    if (Convert.ToBoolean(dtAccGM.Rows[0]["PermisionWrite"]) == true)
                    {
                        //chkAccessoriesGM.Attributes.Add("readonly", "false");
                        chkAccessoriesGM.Enabled = true;

                    }
                    else
                    {
                        //chkAccessoriesGM.Attributes.Add("readonly", "readonly");
                        chkAccessoriesGM.Enabled = false;
                    }
                }

                DataTable dtRollEntry = objPermissionController.GetAccessoryFourPointCheckPermission(ApplicationHelper.LoggedInUser.UserData.PrimaryGroupID, ApplicationHelper.LoggedInUser.UserData.DesignationID, 387).Tables[0];

                if (dtRollEntry.Rows.Count > 0)
                {
                    if (Convert.ToBoolean(dtRollEntry.Rows[0]["PermisionWrite"]) == true)
                    {
                        grv_Accessories_Inspection.Enabled = true;
                    }
                    else
                    {
                        grv_Accessories_Inspection.Enabled = false;
                    }
                }

                DataTable dtUnit = objPermissionController.GetAccessoryFourPointCheckPermission(ApplicationHelper.LoggedInUser.UserData.PrimaryGroupID, ApplicationHelper.LoggedInUser.UserData.DesignationID, 388).Tables[0];

                if (dtUnit.Rows.Count > 0)
                {
                    if (Convert.ToBoolean(dtUnit.Rows[0]["PermisionWrite"]) == true)
                    {
                        ddlAllocatedUnit.Enabled = true;
                    }
                    else
                    {
                        ddlAllocatedUnit.Enabled = false;
                    }
                }

                DataTable dtCheckerName = objPermissionController.GetAccessoryFourPointCheckPermission(ApplicationHelper.LoggedInUser.UserData.PrimaryGroupID, ApplicationHelper.LoggedInUser.UserData.DesignationID, 389).Tables[0];

                if (dtCheckerName.Rows.Count > 0)
                {
                    if (Convert.ToBoolean(dtCheckerName.Rows[0]["PermisionWrite"]) == true)
                    {
                        txtCheckerName1.Enabled = true;
                        txtCheckerName2.Enabled = true;
                    }
                    else
                    {
                        txtCheckerName1.Enabled = false;
                        txtCheckerName2.Enabled = false;
                    }
                }

                DataTable dtInspectionDate = objPermissionController.GetAccessoryFourPointCheckPermission(ApplicationHelper.LoggedInUser.UserData.PrimaryGroupID, ApplicationHelper.LoggedInUser.UserData.DesignationID, 409).Tables[0];

                if (dtInspectionDate.Rows.Count > 0)
                {
                    if (Convert.ToBoolean(dtInspectionDate.Rows[0]["PermisionWrite"]) == true)
                    {
                        txtDate.Enabled = true;
                    }
                    else
                    {
                        txtDate.Enabled = false;
                    }
                }
            }
        }

        private void BindDDLUnit()
        {
            DataSet ds = adminController.GetAllUnit();
            DataTable dt = ds.Tables[0];
            ddlAllocatedUnit.DataSource = dt;
            ddlAllocatedUnit.DataTextField = "UnitName";
            ddlAllocatedUnit.DataValueField = "Id";
            ddlAllocatedUnit.DataBind();
            ddlAllocatedUnit.Items.Insert(0, new ListItem("Select", "-1"));
        }
        private void Bind()
        {
            dvHistory.InnerHtml = "";
            AccessoriesInspectionList.Clear();

            BindDDLUnit();

            DataSet ds = objAccessoryWorking.GetAccessoriesInspection(SupplierPoId, SrvId);
            DataTable dtAccessoriesInspection = ds.Tables[0];
            string AccessoryDetail = "";
            string Size = "";

            if (dtAccessoriesInspection.Rows.Count > 0)
            {
                GarmentUnit = dtAccessoriesInspection.Rows[0]["UnitName"].ToString();
                AccessoryDetail = dtAccessoriesInspection.Rows[0]["AccessoryName"].ToString();
                Size = dtAccessoriesInspection.Rows[0]["Size"].ToString();
                lblAccessories.Text = "<span style='color:blue;'>" + AccessoryDetail + "</span><span style='color:gray;'> (" + Size + ")</span>";
                lblPrintCol.Text = dtAccessoriesInspection.Rows[0]["Color_Print"].ToString();
                lblSupplierName.Text = dtAccessoriesInspection.Rows[0]["SupplierName"].ToString();
                lblPO_No.Text = dtAccessoriesInspection.Rows[0]["PO_Number"].ToString();

                //lblSrvNo.ToolTip = dtAccessoriesInspection.Rows[0]["Remarks"].ToString();
                lblSrvNo.Text = "A-" + dtAccessoriesInspection.Rows[0]["SRV_Id"].ToString();
                lblpartychallannumber.Text = dtAccessoriesInspection.Rows[0]["PartyChallanNumber"].ToString();

                lblSrvRemarks.Text = dtAccessoriesInspection.Rows[0]["Remarks"].ToString();
                //Label2.Text = "A-" + dtAccessoriesInspection.Rows[0]["SRV_Id"].ToString();
                txtCheckerName1.Text = dtAccessoriesInspection.Rows[0]["CheckerName1"].ToString();
                txtCheckerName2.Text = dtAccessoriesInspection.Rows[0]["CheckerName2"].ToString();
                lblSerialNumber.Text = dtAccessoriesInspection.Rows[0]["SerialNumber"].ToString();
                lblReceivedQtyPO.Text = dtAccessoriesInspection.Rows[0]["ReceivedPoQty"].ToString();

                //new code start
                lblWastage.Text = (dtAccessoriesInspection.Rows[0]["Wastage"].ToString() == "" || dtAccessoriesInspection.Rows[0]["Wastage"].ToString() == "0") ? "" : (dtAccessoriesInspection.Rows[0]["Wastage"].ToString() + "%");
                lblShrinkage.Text = (dtAccessoriesInspection.Rows[0]["Shrinkage"].ToString() == "" || dtAccessoriesInspection.Rows[0]["Shrinkage"].ToString() == "0") ? "" : (dtAccessoriesInspection.Rows[0]["Shrinkage"].ToString() + "%");
                txtInternalLabSpecimanCount.Text = dtAccessoriesInspection.Rows[0]["InterNalLabSpecimenCount"].ToString() == "0" ? "" : dtAccessoriesInspection.Rows[0]["InterNalLabSpecimenCount"].ToString();
                chkInternalSentToLab.Checked = Convert.ToBoolean(dtAccessoriesInspection.Rows[0]["InternalIsSentToLab"]);
                hdnchkInternalSentToLab.Value = dtAccessoriesInspection.Rows[0]["InternalIsSentToLab"].ToString();

                //GreigeShrnk.InnerText = lblShrinkage.Text == "" ? "" : "Greige Shrnk :";
                //ResidShrnk.InnerText = lblWastage.Text == "" ? "" : "Res. Shrnk/Wstg :";
                if (lblWastage.Text == "")
                {
                    ResidShrnk.InnerText = "";
                }
                else
                {
                    ResidShrnk.InnerText = "Res. Shrnk/Wstg: ";
                }

                if (lblShrinkage.Text == "")
                {
                    GreigeShrnk.InnerText = "";
                }
                else
                {
                    GreigeShrnk.InnerText = "Greige Shrnk: ";
                }

                if (ResidShrnk.InnerText == "")
                {
                    //GreigeShrnk.Attributes.Add("style", "position: absolute; left:0px");
                    ResidShrnk.Attributes.Remove("ReshShrnk");
                    ResidShrnk.Attributes.Add("class", "ChangePositionReshShrnk");
                    lblShrinkage.Attributes.Add("class", "ChangePositionlblShrinkage");
                }

                //new code start
                int SupplierType = dtAccessoriesInspection.Rows[0]["SupplyType"] == DBNull.Value ? 0 : Convert.ToInt32(dtAccessoriesInspection.Rows[0]["SupplyType"]);
                if (SupplierType == 1)
                {
                    lblGreige.Attributes.Add("style", "color:White");
                    lblProcess.Attributes.Add("style", "color:#dacece99");
                    lblFinish.Attributes.Add("style", "display:none");
                }
                if (SupplierType == 2)
                {
                    lblGreige.Attributes.Add("style", "color:#dacece99");
                    lblProcess.Attributes.Add("style", "color:White");
                    lblFinish.Attributes.Add("style", "display:none");
                }
                if (SupplierType == 3)
                {
                    lblGreige.Attributes.Add("style", "display:none");
                    lblProcess.Attributes.Add("style", "display:none");
                    lblFinish.Attributes.Add("style", "color:White");
                }
                //new code end

                if (chkInternalSentToLab.Checked)
                {
                    chkInternalSentToLab.Enabled = false;
                }

                lblInternalSentToLabDate.Text = dtAccessoriesInspection.Rows[0]["InternalSentToLabDate"].ToString();
                hdnInternalSentToLabDate.Value = dtAccessoriesInspection.Rows[0]["InternalSentToLabDate"].ToString();

                chkInternalReceivedInLab.Checked = Convert.ToBoolean(dtAccessoriesInspection.Rows[0]["InternalIsReceivedinLab"]);
                hdnchkInternalReceivedInLab.Value = dtAccessoriesInspection.Rows[0]["InternalIsReceivedinLab"].ToString();

                if (chkInternalReceivedInLab.Checked)
                {
                    chkInternalReceivedInLab.Enabled = false;
                    // hylnkInternalLabReportText.Visible = false;
                    if (chkLabManager.Checked)
                    {
                        // hylnkInternalLabReportText.Attributes.Add("style", "display:none");
                        hylnkInternalLabReportText.Attributes.Add("onclick", "void(0)");
                    }
                }
                lblInternalReceivedIndLabDate.Text = dtAccessoriesInspection.Rows[0]["InternalIsReceivedinLabDate"].ToString();
                hdnInternalReceivedInLabDate.Value = dtAccessoriesInspection.Rows[0]["InternalIsReceivedinLabDate"].ToString();


                //uploadInternalLabReport.FileName = dtAccessoriesInspection.Rows[0]["InternalLabReports"].ToString();

                if (!string.IsNullOrEmpty(dtAccessoriesInspection.Rows[0]["InternalLabReports"].ToString()))
                {
                    hylnkInternalLabReport.Visible = true;
                    // hylnkInternalLabReport.NavigateUrl = "~/Uploads/Photo/" + dtAccessoriesInspection.Rows[0]["InternalLabReports"].ToString();
                    hdnInternalIsFile.Value = "1";
                    //lblInternalFileName.Text = dtAccessoriesInspection.Rows[0]["InternalLabReports"].ToString();

                }
                else
                {
                    hylnkInternalLabReport.Visible = false;
                    hdnInternalIsFile.Value = "0";
                    //hdnFileUpload1.Value = "0";
                }

                lblFinalDecisionDate.Text = dtAccessoriesInspection.Rows[0]["FinalDecisionDate"].ToString();
                string FinalDecision = dtAccessoriesInspection.Rows[0]["IsFinalDecision"] == DBNull.Value ? "" : dtAccessoriesInspection.Rows[0]["IsFinalDecision"].ToString();
                string IsCommercialPass = dtAccessoriesInspection.Rows[0]["IsCommercialPass"].ToString();
                hdnCommercialPass.Value = IsCommercialPass;
                hdnFinalPass.Value = FinalDecision;
                string InternalLabDec = dtAccessoriesInspection.Rows[0]["InternalLabDecesion"].ToString();
                string ExternalLabDec = dtAccessoriesInspection.Rows[0]["ExternalLabDecesion"].ToString();
                hdnintLabDec.Value = InternalLabDec;
                hdnExtLabDec.Value = ExternalLabDec;
                if (FinalDecision == "1" && IsCommercialPass != "1")
                {
                    rbtFinalDecisionPass.Checked = true;
                }
                if (FinalDecision == "0")
                {
                    rbtFinalDecisionFail.Checked = true;
                    // HdnFinalFail.Value = FinalDecision;
                }
                if (IsCommercialPass == "1")
                {
                    rdybtnCommercialPass.Checked = true;
                }
                if (InternalLabDec == "1")
                {
                    rdyBtnLabDecPassInter.Checked = true;
                    hdnintLabDec.Value = "1";
                }
                else if (InternalLabDec == "0")
                {
                    rdyBtnLabDecFailInter.Checked = true;
                    hdnintLabDec.Value = "0";
                }
                else
                {
                    hdnintLabDec.Value = "-1";
                }
                if (ExternalLabDec == "1")
                {
                    rdyBtnLabDecPassExt.Checked = true;
                    hdnExtLabDec.Value = "1";
                }
                else if (ExternalLabDec == "0")
                {
                    rdyBtnLabDecFailExt.Checked = true;
                    hdnExtLabDec.Value = "0";
                }
                else
                {
                    hdnExtLabDec.Value = "-1";
                }

                txtExternalLabSpecimanCount.Text = dtAccessoriesInspection.Rows[0]["ExternalLabSpecimenCount"].ToString() == "0" ? "" : dtAccessoriesInspection.Rows[0]["ExternalLabSpecimenCount"].ToString();
                chkExternalSentToLab.Checked = Convert.ToBoolean(dtAccessoriesInspection.Rows[0]["ExternalIsSentToLab"]);
                hdnchkExternalSentToLab.Value = dtAccessoriesInspection.Rows[0]["ExternalIsSentToLab"].ToString();

                if (chkExternalSentToLab.Checked)
                {
                    chkExternalSentToLab.Enabled = false;
                }

                lblExternalSentToLabDate.Text = dtAccessoriesInspection.Rows[0]["ExternalSentToLabDate"].ToString();
                hdnExternalSentToLabDate.Value = dtAccessoriesInspection.Rows[0]["ExternalSentToLabDate"].ToString();

                chkExternalReceivedInLab.Checked = Convert.ToBoolean(dtAccessoriesInspection.Rows[0]["ExternalIsReceivedinLab"]);
                hdnchkExternalReceivedInLab.Value = dtAccessoriesInspection.Rows[0]["ExternalIsReceivedinLab"].ToString();

                if (chkExternalReceivedInLab.Checked)
                {
                    chkExternalReceivedInLab.Enabled = false;
                    if (chkLabManager.Checked && rdyBtnLabDecPassExt.Checked || rdyBtnLabDecFailExt.Checked)
                    {
                        //hylnkExternalLabReportText.Attributes.Add("style", "display:none");

                        hylnkExternalLabReportText.Attributes.Add("onclick", "void(0)");
                    }
                }

                lblExternalReceivedInLabDate.Text = dtAccessoriesInspection.Rows[0]["ExternalIsReceivedinLabDate"].ToString();
                hdnExternalReceivedInLabDate.Value = dtAccessoriesInspection.Rows[0]["ExternalIsReceivedinLabDate"].ToString();

                //uploadExternalLabReport.FileName = dtAccessoriesInspection.Rows[0]["ExternalLabReports"].ToString();
                if (!string.IsNullOrEmpty(dtAccessoriesInspection.Rows[0]["ExternalLabReports"].ToString()))
                {
                    hylnkExternalLabReport.Visible = true;
                    //hylnkExternalLabReport.NavigateUrl = "~/Uploads/Photo/" + dtAccessoriesInspection.Rows[0]["ExternalLabReports"].ToString(); commented by shubhendu
                    hdnExternalIsFile.Value = "1";
                    //lblInternalFileName.Text = dtAccessoriesInspection.Rows[0]["InternalLabReports"].ToString();
                }
                else
                {
                    hylnkExternalLabReport.Visible = false;
                    hdnExternalIsFile.Value = "0";
                    //hdnFileUpload1.Value = "0";
                }

                lblTotalFailQty.Text = "0"; //bind total fail quantity on gridbind (pending)
                txtFailedRaisedDebit.Text = Convert.ToDecimal(dtAccessoriesInspection.Rows[0]["FailRaiseDebit"]) == 0 ? "" : Convert.ToDecimal(dtAccessoriesInspection.Rows[0]["FailRaiseDebit"]).ToString();
                txtFailedStock.Text = Convert.ToDecimal(dtAccessoriesInspection.Rows[0]["FailStock"]) == 0 ? "" : Convert.ToDecimal(dtAccessoriesInspection.Rows[0]["FailStock"]).ToString();
                txtFailedGoodStock.Text = Convert.ToDecimal(dtAccessoriesInspection.Rows[0]["FailGoodStock"]) == 0 ? "" : Convert.ToDecimal(dtAccessoriesInspection.Rows[0]["FailGoodStock"]).ToString();
                txtFailedParticular.Text = dtAccessoriesInspection.Rows[0]["FailStockParticular"].ToString();
                if (dtAccessoriesInspection.Rows[0]["FailedStockTraced"].ToString() == "1")
                {
                    txtFailedStock.Attributes.Add("style", "background-color:#e4e4e4");
                }


                lblInspectExtraQty.Text = Convert.ToDecimal(dtAccessoriesInspection.Rows[0]["InspectExtraQty"]) == 0 ? "" : Convert.ToDecimal(dtAccessoriesInspection.Rows[0]["InspectExtraQty"]).ToString();
                txtInspectRaisedDebit.Text = Convert.ToDecimal(dtAccessoriesInspection.Rows[0]["InspectRaiseDebit"]) == 0 ? "" : Convert.ToDecimal(dtAccessoriesInspection.Rows[0]["InspectRaiseDebit"]).ToString();
                txtInspectUsableStock.Text = Convert.ToDecimal(dtAccessoriesInspection.Rows[0]["InspectUsableStock"]) == 0 ? "" : Convert.ToDecimal(dtAccessoriesInspection.Rows[0]["InspectUsableStock"]).ToString();
                txtInspectParticular.Text = dtAccessoriesInspection.Rows[0]["InspectParticular"].ToString();

                //new work start : girish
                lblExcessQty.Text = dtAccessoriesInspection.Rows[0]["PendingReqdQty"].ToString() == "0" ? "" : Convert.ToInt32(dtAccessoriesInspection.Rows[0]["PendingReqdQty"]).ToString("N0");

                if (lblExcessQty.Text == "")
                {
                    spn_ExcessQty.InnerHtml = "";
                }
                else
                {
                    spn_ExcessQty.InnerHtml = "Actual Required Qty.";
                }
                //new work End : girish


                if (Convert.ToBoolean(dtAccessoriesInspection.Rows[0]["IsLabManager"]) == true && Convert.ToBoolean(dtAccessoriesInspection.Rows[0]["InternalIsSentToLab"]) == true && Convert.ToBoolean(dtAccessoriesInspection.Rows[0]["InternalIsReceivedinLab"]) == false)                         ////////////////
                {
                    //DataTable IsCheckedDt = new DataTable();
                    //IsCheckedDt = objAccessoryWorking.LabManagerChecked(SrvId);
                    //chkLabManager.Checked = Convert.ToBoolean(IsCheckedDt.Rows[0]["isLabManager"]);
                    chkLabManager.Checked = true;
                }
                else
                {
                    chkLabManager.Checked = Convert.ToBoolean(dtAccessoriesInspection.Rows[0]["IsLabManager"]);
                }

                if (Convert.ToBoolean(dtAccessoriesInspection.Rows[0]["IsLabManager"]) == true && Convert.ToBoolean(dtAccessoriesInspection.Rows[0]["ExternalIsSentToLab"]) == true && Convert.ToBoolean(dtAccessoriesInspection.Rows[0]["ExternalIsReceivedinLab"]) == false)                         ////////////////
                {
                    //DataTable IsCheckedDt = new DataTable();
                    //IsCheckedDt = objAccessoryWorking.LabManagerChecked(SrvId);
                    //chkLabManager.Checked = Convert.ToBoolean(IsCheckedDt.Rows[0]["isLabManager"]);.
                    chkLabManager.Checked = true;
                }
                else
                {
                    chkLabManager.Checked = Convert.ToBoolean(dtAccessoriesInspection.Rows[0]["IsLabManager"]);
                }
                if (chkLabManager.Checked)
                {
                    chkLabManager.Enabled = false;
                    lblAccLabManagerName.Text = dtAccessoriesInspection.Rows[0]["AccessoryLabManagerName"].ToString();
                    lblAccLabManagerName.Attributes.Add("style", "display:''");
                    //lblLabDatetime.InnerText = dtAccessoriesInspection.Rows[0]["LabManagerApprovedDate"].ToString();
                    lblLabDatetime.Attributes.Add("style", "display:block");
                    lblLabDatetime.Text = dtAccessoriesInspection.Rows[0]["LabManagerApprovedDate"].ToString() == "" ? "" : DateTime.Parse(dtAccessoriesInspection.Rows[0]["LabManagerApprovedDate"].ToString()).ToString("dd MMM yy (ddd)");

                }
                hdnLabManager.Value = dtAccessoriesInspection.Rows[0]["IsLabManager"].ToString();
                //hdnGM_Manager.Value = dtAccessoriesInspection.Rows[0]["IsAccessoryGM"].ToString();
                //hdnQAManager.Value = dtAccessoriesInspection.Rows[0]["IsAccessoryQA"].ToString();

                if (ApplicationHelper.LoggedInUser.UserData.DesignationID == 15)
                {
                    hdnGM_Manager.Value = "1";
                }
                if (ApplicationHelper.LoggedInUser.UserData.DesignationID == 148)
                {
                    hdnQAManager.Value = "1";
                }

                //if (dtAccessoriesInspection.Rows[0]["InterNalLabSpecimenCount"].ToString() != "" && Convert.ToBoolean(dtAccessoriesInspection.Rows[0]["InternalIsSentToLab"]) == true && dtAccessoriesInspection.Rows[0]["ExternalLabSpecimenCount"].ToString() != "" && Convert.ToBoolean(dtAccessoriesInspection.Rows[0]["ExternalIsSentToLab"]) == true)
                //{
                //    chkLabManager.Enabled = true;
                //}
                //else
                //{
                //    chkLabManager.Enabled = false;
                //}


                chkAccessoriesQA.Checked = Convert.ToBoolean(dtAccessoriesInspection.Rows[0]["IsAccessoryQA"]);
                chkAccessoriesGM.Checked = Convert.ToBoolean(dtAccessoriesInspection.Rows[0]["IsAccessoryGM"]);



                if (chkAccessoriesQA.Checked)
                {
                    chkAccessoriesQA.Enabled = false;
                    lblAccQAName.Text = dtAccessoriesInspection.Rows[0]["AccessoryQAName"].ToString();

                    lblAccQAName.Attributes.Add("style", "display:''");
                    //lblQADatetime.InnerText = dtAccessoriesInspection.Rows[0]["AccessoryQADate"].ToString();
                    lblQADatetime.Attributes.Add("style", "display:''");
                    lblQADatetime.Text = dtAccessoriesInspection.Rows[0]["AccessoryQADate"].ToString() == "" ? "" : DateTime.Parse(dtAccessoriesInspection.Rows[0]["AccessoryQADate"].ToString()).ToString("dd MMM yy (ddd)");
                }

                if (chkAccessoriesGM.Checked)
                {
                    chkAccessoriesGM.Enabled = false;
                    lblAccGMName.Text = dtAccessoriesInspection.Rows[0]["AccessoryGMName"].ToString();
                    lblAccGMName.Attributes.Add("style", "display:''");
                    //lblGMDateTime.InnerText = dtAccessoriesInspection.Rows[0]["AccessoryGMDate"].ToString();
                    lblGMDateTime.Attributes.Add("style", "display:''");
                    lblGMDateTime.Text = dtAccessoriesInspection.Rows[0]["AccessoryGMDate"].ToString() == "" ? "" : DateTime.Parse(dtAccessoriesInspection.Rows[0]["AccessoryGMDate"].ToString()).ToString("dd MMM yy (ddd)");
                }
                //chkLabManager.Checked = Convert.ToBoolean(dtAccessoriesInspection.Rows[0]["IsLabManager"]);

                //new code end

                if (dtAccessoriesInspection.Rows[0]["InspectionDate"].ToString() != string.Empty)
                {
                    txtDate.Text = Convert.ToDateTime(dtAccessoriesInspection.Rows[0]["InspectionDate"]).ToString("dd MMM yy");
                }
                else
                {
                    txtDate.Text = DateTime.Now.ToString("dd MMM yy");
                }
                txtComments.Text = "";
                Span6.InnerText = GarmentUnit;
                sp7.InnerText = '(' + GarmentUnit + ')';
                //txtTotalQuantity.Text = Convert.do(dtAccessoriesInspection.Rows[0]["TotalQuantity"]).ToString("N0");
                txtTotalQuantity.Text = Convert.ToDecimal(dtAccessoriesInspection.Rows[0]["TotalQuantity"]).ToString();

                //added by Girish
                if (dtAccessoriesInspection.Rows[0]["ActualReceivedQty"].ToString() != "")
                    hdnActualReceivedQty.Value = dtAccessoriesInspection.Rows[0]["ActualReceivedQty"].ToString();
                    //hdnActualReceivedQty.Value = Convert.ToDecimal(dtAccessoriesInspection.Rows[0]["ActualReceivedQty"]).ToString("N0");
                //added by Girish


                TotalQuantitySRV = Convert.ToDecimal(dtAccessoriesInspection.Rows[0]["TotalQuantity"]);


                if (Convert.ToInt32(dtAccessoriesInspection.Rows[0]["UnitId"]) != 0)
                    ddlAllocatedUnit.SelectedValue = dtAccessoriesInspection.Rows[0]["UnitId"].ToString();
                else
                    ddlAllocatedUnit.SelectedValue = UnitId.ToString();


                if (LabReport == 1)
                {
                    //InternalRowId.Attributes.Add("disabled", "disabled");
                    txtInternalLabSpecimanCount.Attributes.Add("readonly", "readonly");
                    chkInternalSentToLab.Enabled = false;
                    chkInternalReceivedInLab.Enabled = false;
                    rdyBtnLabDecFailInter.Enabled = false;
                    rdyBtnLabDecPassInter.Enabled = false;
                    //if (Convert.ToBoolean(dtAccessoriesInspection.Rows[0]["ExternalIsSentToLab"]) == true && Convert.ToBoolean(dtAccessoriesInspection.Rows[0]["IsLabManager"]) == false)
                    //{
                    //    chkExternalReceivedInLab.Enabled = true;
                    //}              
                    //hylnkInternalLabReportText.Attributes.Add("onclick", "void(0)");

                    if (chkExternalReceivedInLab.Checked)
                    {
                        if (chkLabManager.Checked && rdyBtnLabDecPassExt.Checked || rdyBtnLabDecFailExt.Checked)
                        {
                            //hylnkExternalLabReportText.Attributes.Add("style", "display:block");
                            hylnkExternalLabReportText.Attributes.Add("onclick", "void(0)");
                            hylnkExternalLabReportText.Enabled = false;
                        }
                        else
                        {
                            hylnkExternalLabReportText.Attributes.Add("style", "display:''");
                            //hylnkExternalLabReportText.Visible = true;
                        }
                    }
                    else
                    {
                        hylnkExternalLabReportText.Attributes.Add("style", "display:none");
                        //hylnkExternalLabReportText.Visible = false;
                    }

                    if (chkInternalReceivedInLab.Checked)
                    {
                        if (chkLabManager.Checked)
                        {
                            hylnkInternalLabReportText.Attributes.Add("onclick", "void(0)");
                        }
                        else
                        {
                            hylnkInternalLabReportText.Attributes.Add("style", "display:''");
                            //hylnkInternalLabReportText.Visible = true;
                        }
                    }
                    else
                    {
                        hylnkInternalLabReportText.Attributes.Add("style", "display:none");
                        //hylnkInternalLabReportText.Visible = false;
                    }
                    //if (chkInternalReceivedInLab.Checked)
                    //{                       
                    //    if (chkLabManager.Checked)
                    //    {
                    // hylnkInternalLabReportText.Attributes.Add("style", "display:none");
                    //hylnkInternalLabReportText.Attributes.Add("onclick", "void(0)");
                    //    }
                    //}

                    //hylnkInternalLabReportText.Attributes.Add("onclick", "void(0)");
                }
                if (LabReport == 0)
                {
                    //ExternalRowId.Attributes.Add("disabled", "disabled");
                    txtExternalLabSpecimanCount.Attributes.Add("readonly", "readonly");
                    chkExternalSentToLab.Enabled = false;
                    chkExternalReceivedInLab.Enabled = false;
                    rdyBtnLabDecPassExt.Enabled = false;
                    rdyBtnLabDecFailExt.Enabled = false;

                    //if (Convert.ToBoolean(dtAccessoriesInspection.Rows[0]["InternalIsSentToLab"]) == true && Convert.ToBoolean(dtAccessoriesInspection.Rows[0]["IsLabManager"]) == false)
                    //{
                    //    chkInternalReceivedInLab.Enabled = true;
                    //} 
                    //hylnkExternalLabReportText.Attributes.Add("onclick", "void(0)");    
                    if (chkInternalReceivedInLab.Checked)
                    {
                        if (chkLabManager.Checked)
                        {
                            hylnkInternalLabReportText.Attributes.Add("onclick", "void(0)");
                        }
                        else
                        {
                            hylnkInternalLabReportText.Attributes.Add("style", "display:''");
                            //hylnkInternalLabReportText.Visible = true;
                        }
                    }
                    else
                    {
                        hylnkInternalLabReportText.Attributes.Add("style", "display:none");
                        // hylnkInternalLabReportText.Visible = false;
                    }

                    if (chkExternalReceivedInLab.Checked)
                    {
                        if (chkLabManager.Checked && rdyBtnLabDecFailExt.Checked || rdyBtnLabDecPassExt.Checked)
                        {
                            //hylnkExternalLabReportText.Attributes.Add("style", "display:block");
                            hylnkExternalLabReportText.Attributes.Add("onclick", "void(0)");
                        }
                        else
                        {
                            hylnkExternalLabReportText.Attributes.Add("style", "display:''");
                            //hylnkExternalLabReportText.Visible = true;
                        }
                    }
                    else
                    {
                        hylnkExternalLabReportText.Attributes.Add("style", "display:none");
                        // hylnkExternalLabReportText.Visible = false;
                    }


                    //if (chkExternalReceivedInLab.Checked)
                    //{
                    //    if (chkLabManager.Checked)
                    //    {
                    //hylnkExternalLabReportText.Attributes.Add("style", "display:block");
                    //hylnkExternalLabReportText.Attributes.Add("onclick", "void(0)");
                    //    }
                    //}
                }
                if (txtInternalLabSpecimanCount.Text == "")
                {
                    chkInternalSentToLab.Enabled = false;
                    //chkInternalReceivedInLab.Enabled = false;
                    //hylnkInternalLabReportText.Attributes.Add("onclick", "void(0)");
                }
                if (txtExternalLabSpecimanCount.Text == "")
                {
                    chkExternalSentToLab.Enabled = false;
                    //chkExternalReceivedInLab.Enabled = false;
                    //hylnkExternalLabReportText.Attributes.Add("onclick", "void(0)");
                }
                if (dtAccessoriesInspection.Rows[0]["InterNalLabSpecimenCount"].ToString() != "" && Convert.ToBoolean(dtAccessoriesInspection.Rows[0]["InternalIsSentToLab"]) == true)
                {
                    chkInternalSentToLab.Attributes.Add("readonly", "readonly");
                    txtInternalLabSpecimanCount.Attributes.Add("readonly", "readonly");
                }

                if (dtAccessoriesInspection.Rows[0]["ExternalLabSpecimenCount"].ToString() != "" && Convert.ToBoolean(dtAccessoriesInspection.Rows[0]["ExternalIsSentToLab"]) == true)
                {
                    chkExternalSentToLab.Attributes.Add("readonly", "readonly");
                    txtExternalLabSpecimanCount.Attributes.Add("readonly", "readonly");
                }
                if (Convert.ToBoolean(dtAccessoriesInspection.Rows[0]["IsAccessoryQA"]) == true)
                {
                    //grv_Accessories_Inspection.Enabled = false;
                    if (dtAccessoriesInspection.Rows[0]["IsFinalDecision"].ToString() == "0")
                    {
                        //rbtFinalDecisionPass.Enabled = false;
                        //rbtFinalDecisionFail.Enabled = false;
                        rbtFinalDecisionFail.Checked = true;
                    }
                    else if (dtAccessoriesInspection.Rows[0]["IsFinalDecision"].ToString() == "1")
                    {
                        rbtFinalDecisionPass.Checked = true;
                    }
                    else if (dtAccessoriesInspection.Rows[0]["IsCommercialPass"].ToString() == "1")
                    {
                        rdybtnCommercialPass.Checked = true;
                    }
                }
                if (Convert.ToBoolean(dtAccessoriesInspection.Rows[0]["IsAccessoryGM"]) == true)
                {
                    grv_Accessories_Inspection.Enabled = false;
                    ddlAllocatedUnit.Enabled = false;
                    txtCheckerName1.Attributes.Add("readonly", "readonly");
                    txtCheckerName2.Attributes.Add("readonly", "readonly");

                    //rbtFinalDecisionPass.Attributes.Add("disabled", "disabled");
                    rbtFinalDecisionPass.Enabled = false;
                    rbtFinalDecisionFail.Enabled = false;

                    //int TotalFailQty = 0;
                    //int TotalExtraQty = 0;

                    if (((dtAccessoriesInspection.Rows[0]["FailRaiseDebit"].ToString() != "" && dtAccessoriesInspection.Rows[0]["FailRaiseDebit"].ToString() != "0") || (dtAccessoriesInspection.Rows[0]["FailStock"].ToString() != "" && dtAccessoriesInspection.Rows[0]["FailStock"].ToString() != "0") || (dtAccessoriesInspection.Rows[0]["FailGoodStock"].ToString() != "" && dtAccessoriesInspection.Rows[0]["FailGoodStock"].ToString() != "0")))
                    {
                        //FailedQtyId.Attributes.Add("readonly", "readonly");
                        //FailedQtyId.Attributes.Add("disabled", "disabled");
                        txtFailedRaisedDebit.Attributes.Add("readonly", "readonly");
                        txtFailedStock.Attributes.Add("readonly", "readonly");
                        txtFailedGoodStock.Attributes.Add("readonly", "readonly");
                        //txtFailedParticular.Attributes.Add("readonly", "readonly");
                    }

                    if (((dtAccessoriesInspection.Rows[0]["InspectExtraQty"].ToString() != "" && dtAccessoriesInspection.Rows[0]["InspectExtraQty"].ToString() != "0") || (dtAccessoriesInspection.Rows[0]["InspectRaiseDebit"].ToString() != "" && dtAccessoriesInspection.Rows[0]["InspectRaiseDebit"].ToString() != "0")))
                    {
                        //ExtraQtyId.Attributes.Add("readonly", "readonly");
                        //ExtraQtyId.Attributes.Add("disabled", "disabled");
                        txtInspectRaisedDebit.Attributes.Add("readonly", "readonly");
                        txtInspectUsableStock.Attributes.Add("readonly", "readonly");
                        //txtInspectParticular.Attributes.Add("readonly", "readonly");
                    }
                }
                //else
                //{
                //    if (txtFailedRaisedDebit.Text != "")
                //    {
                //        txtFailedParticular.Enabled = true;
                //    }
                //    else
                //    {
                //        txtFailedParticular.Enabled = false;
                //    }
                //    if (txtInspectRaisedDebit.Text != "")
                //    {
                //        txtInspectParticular.Enabled = true;
                //    }
                //    else
                //    {
                //        txtInspectParticular.Enabled = false;
                //    }
                //}

                hdnLoginId.Value = ApplicationHelper.LoggedInUser.UserData.DesignationID.ToString();
                // if (Convert.ToBoolean(dtAccessoriesInspection.Rows[0]["isLabManager"]) == true)
                if (ApplicationHelper.LoggedInUser.UserData.DesignationID == 40)
                {
                    grv_Accessories_Inspection.Enabled = false;
                }


                //else
                //{
                //    grv_Accessories_Inspection.Enabled = true;
                //}

                //hdnReceivedQty.Value = dtAccessoriesInspection.Rows[0]["Received"].ToString();
                //txtReceived.Text = dtAccessoriesInspection.Rows[0]["Received"].ToString() == string.Empty ? string.Empty : Convert.ToInt32(dtAccessoriesInspection.Rows[0]["Received"]).ToString("N0");
                //txtChecked.Text = dtAccessoriesInspection.Rows[0]["CheckedQty"].ToString() == string.Empty ? string.Empty : Convert.ToInt32(dtAccessoriesInspection.Rows[0]["CheckedQty"]).ToString("N0");
                //txtPass.Text = dtAccessoriesInspection.Rows[0]["PassQty"].ToString() == string.Empty ? string.Empty : Convert.ToInt32(dtAccessoriesInspection.Rows[0]["PassQty"]).ToString("N0");
                //txtHold.Text = dtAccessoriesInspection.Rows[0]["HoldQty"].ToString() == string.Empty ? string.Empty : Convert.ToInt32(dtAccessoriesInspection.Rows[0]["HoldQty"]).ToString("N0");
                //txtFail.Text = dtAccessoriesInspection.Rows[0]["FailQty"].ToString() == string.Empty ? string.Empty : Convert.ToInt32(dtAccessoriesInspection.Rows[0]["FailQty"]).ToString("N0");
                //hdnpassqty.Value = dtAccessoriesInspection.Rows[0]["PassQty"].ToString() == string.Empty ? string.Empty : Convert.ToInt32(dtAccessoriesInspection.Rows[0]["PassQty"]).ToString();

                //if (txtHold.Text != "")
                //{
                //    chkAccessoriesQA.Enabled = false;
                //    chkAccessoriesGM.Enabled = false;
                //}

                //if (Convert.ToBoolean(dtAccessoriesInspection.Rows[0]["IsAccessoryQA"]) == true)
                //{
                //    divAccessoriesQA.Visible = false;
                //    divSigAccessoriesQA.Visible = true;

                //    foreach (var user in ApplicationHelper.Users)
                //    {
                //        if (Convert.ToInt32(dtAccessoriesInspection.Rows[0]["AccessoryQABy"]) == user.UserID)
                //        {
                //            lblAccessoriesQAName.Text = user.FirstName + " " + user.LastName;
                //            imgAccessoriesQA.ImageUrl = user.SignPath != string.Empty ? "~/Uploads/Photo/" + user.SignPath : "~/Uploads/Photo/NotSign.jpg";
                //            lblAccessoriesQADate.Text = Convert.ToDateTime(dtAccessoriesInspection.Rows[0]["AccessoryQADate"]).ToString("dd MMM yy (ddd)");
                //        }
                //    }
                //}
                //if (Convert.ToBoolean(dtAccessoriesInspection.Rows[0]["IsAccessoryQA"]) == true && Convert.ToBoolean(dtAccessoriesInspection.Rows[0]["IsAccessoryGM"]) == true)
                //{
                //    txtReceived.Attributes.Add("disabled", "disabled");
                //    txtChecked.Attributes.Add("disabled", "disabled");
                //    txtPass.Attributes.Add("disabled", "disabled");
                //    txtHold.Attributes.Add("disabled", "disabled");
                //    txtFail.Attributes.Add("disabled", "disabled");
                //txtComments.Attributes.Add("disabled", "disabled");
                //    txtCheckerName1.Attributes.Add("disabled", "disabled");
                //    txtCheckerName1.Attributes.Add("disabled", "disabled");
                //    // btnSubmit.Visible = false;
                //}

                //if (Convert.ToBoolean(dtAccessoriesInspection.Rows[0]["IsAccessoryGM"]) == true)
                //{
                //    divAccessoriesGM.Visible = false;
                //    divSigAccessoriesGM.Visible = true;
                //    foreach (var user in ApplicationHelper.Users)
                //    {
                //        if (Convert.ToInt32(dtAccessoriesInspection.Rows[0]["AccessoryGMBy"]) == user.UserID)
                //        {
                //            lblAccessoriesGMName.Text = user.FirstName + " " + user.LastName;
                //            imgAccessoriesGM.ImageUrl = user.SignPath != string.Empty ? "~/Uploads/Photo/" + user.SignPath : "~/Uploads/Photo/NotSign.jpg";
                //            lblAccessoriesGMDate.Text = dtAccessoriesInspection.Rows[0]["AccessoryGMDate"] != System.DBNull.Value ? Convert.ToDateTime(dtAccessoriesInspection.Rows[0]["AccessoryGMDate"]).ToString("dd MMM yy (ddd)") : string.Empty;
                //        }
                //    }
                //}
            }

            if (ds.Tables.Count > 1)
            {
                for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
                {
                    AccessoriesInspect accessoriesInspect = new AccessoriesInspect();
                    Count = ds.Tables.Count;

                    accessoriesInspect.BoxNo = Convert.ToInt32(ds.Tables[1].Rows[i]["BoxNo"]);
                    if (ds.Tables[1].Rows[i]["DieLot"] != System.DBNull.Value)
                        accessoriesInspect.DieLot = Convert.ToInt32(ds.Tables[1].Rows[i]["DieLot"]);
                    if (ds.Tables[1].Rows[i]["ClaimedQty"] != System.DBNull.Value)
                        accessoriesInspect.ClaimedLength = Convert.ToDecimal(ds.Tables[1].Rows[i]["ClaimedQty"]);
                    if (ds.Tables[1].Rows[i]["ActLength"] != System.DBNull.Value)
                        accessoriesInspect.ActLength = Convert.ToDecimal(ds.Tables[1].Rows[i]["ActLength"]);
                    if (ds.Tables[1].Rows[i]["PassQty"] != System.DBNull.Value)
                        accessoriesInspect.PassQty = Convert.ToDecimal(ds.Tables[1].Rows[i]["PassQty"]);
                    if (ds.Tables[1].Rows[i]["CheckedQty"] != System.DBNull.Value)
                        accessoriesInspect.CheckedQty = Convert.ToDecimal(ds.Tables[1].Rows[i]["CheckedQty"]);
                    if (ds.Tables[1].Rows[i]["FailQty"] != System.DBNull.Value)
                        accessoriesInspect.FailQty = Convert.ToDecimal(ds.Tables[1].Rows[i]["FailQty"]);
                    if (ds.Tables[1].Rows[i]["HoldQty"] != System.DBNull.Value)
                        accessoriesInspect.HoldQty = Convert.ToDecimal(ds.Tables[1].Rows[i]["HoldQty"]);
                    if (ds.Tables[1].Rows[i]["Decision"] != System.DBNull.Value)
                        accessoriesInspect.Decision = ds.Tables[1].Rows[i]["Decision"].ToString();

                    accessoriesInspect.CreatedBy = Convert.ToInt32(ds.Tables[1].Rows[i]["CreatedBy"]);
                    accessoriesInspect.Inspection_Id = Convert.ToInt32(ds.Tables[1].Rows[i]["Inspection_Id"]);
                    accessoriesInspect.InspectionParticular_Id = Convert.ToInt32(ds.Tables[1].Rows[i]["InspectionParticular_Id"]);

                    AccessoriesInspectionList.Add(accessoriesInspect);
                }
                DataTable dtAccessoryInspecParticular = ds.Tables[1];
                grv_Accessories_Inspection.DataSource = dtAccessoryInspecParticular;
                grv_Accessories_Inspection.DataBind();
                decimal total = AccessoriesInspectionList.Sum(item => item.ActLength);
                int box = AccessoriesInspectionList.Sum(item => item.BoxNo);

                //lblTotalPcs.Text = "<span><b>" + total.ToString("N0") + "</b></span><span class='txtColorGray'> " + GarmentUnit + "</span> (<b>" + box.ToString() + "</b>)";
                //if (total < TotalQuantitySRV)
                //{
                //    tdTotalPcs.Style.Add("background-color", "#FDFD96;");
                //}
                //else if (total > TotalQuantitySRV)
                //{
                //    tdTotalPcs.Style.Add("background-color", "#FFB7B2;");
                //}
                if (ds.Tables[1].Rows.Count <= 0)
                {
                    rbtFinalDecisionPass.Enabled = false;
                    rdybtnCommercialPass.Enabled = false;
                    rbtFinalDecisionFail.Enabled = false;
                }
                if (ds.Tables.Count > 2)
                {
                    DataTable dtComment = ds.Tables[2];
                    for (int iComment = 0; iComment < dtComment.Rows.Count; iComment++)
                    {
                        dvHistory.InnerHtml = dvHistory.InnerHtml + "<div class='historyDiv'><span class='CommentBullet'></span>" + dtComment.Rows[iComment]["DetailDescription"].ToString() + "</div>";
                    }
                }
            }
                
            else
            {
                Count = 0;
                grv_Accessories_Inspection.DataSource = null;
                grv_Accessories_Inspection.DataBind();

                rbtFinalDecisionPass.Enabled = false;
                rdybtnCommercialPass.Enabled = false;
                rbtFinalDecisionFail.Enabled = false;
            }

            //if ((Status == 1) || (Status == 2))
            //{
            //    ScriptManager.RegisterStartupScript(this, this.GetType(), "err_msg", "disablePage();", true);
            //    btnSubmit.Visible = false;
            //}
        }

        decimal totalReceivedQty = 0, totalClaimedQty = 0, totalCheckedQty = 0, totalPassQty = 0, totalHoldQty = 0, totalFailQty = 0;
        int totalRollBox = 0;
        int totalDyeLot = 0;
        protected void grv_Accessories_Inspection_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                ImageButton btnAdd_Footer = (ImageButton)e.Row.FindControl("btnAdd_Footer");
                if (hdnLoginId.Value == "25")
                {

                    btnAdd_Footer.Enabled = false;
                }



            }
            if (e.Row.RowType == DataControlRowType.Header)
            {
                totalAccInspection.Visible = true;
                Label lblLengthHdr = (Label)e.Row.FindControl("lblLengthHdr");
                lblLengthHdr.Text = "Actual Quantity <br>" + "<span style='color:grey;font-weight:600'>(" + GarmentUnit + ")</span>";

                Label lblClaimedLengthHeader = (Label)e.Row.FindControl("lblClaimedLengthHeader");
                lblClaimedLengthHeader.Text = "Claimed Quantity <br>" + "<span style='color:grey;font-weight:600'>(" + GarmentUnit + ")</span>";

                Label lblcheckedHdr = (Label)e.Row.FindControl("lblcheckedHdr");
                lblcheckedHdr.Text = "Checked " + "<span style='color:grey;font-weight:600'>(" + GarmentUnit + ")</span>";

                Label lblPassHdr = (Label)e.Row.FindControl("lblPassHdr");
                lblPassHdr.Text = "Pass " + "<span style='color:grey;font-weight:600'>(" + GarmentUnit + ")</span>";

                Label lblHoldHdr = (Label)e.Row.FindControl("lblHoldHdr");
                lblHoldHdr.Text = "Hold " + "<span style='color:grey;font-weight:600'>(" + GarmentUnit + ")</span>";

                Label lblFailHdr = (Label)e.Row.FindControl("lblFailHdr");
                lblFailHdr.Text = "Fail " + "<span style='color:grey;font-weight:600'>(" + GarmentUnit + ")</span>";

            }
            if (e.Row.RowState == DataControlRowState.Edit && (e.Row.RowIndex < AccessoriesInspectionList.Count()))
            {
                AccessoriesInspect ss = AccessoriesInspectionList[e.Row.RowIndex];

                RadioButton rbtPassEdit = (RadioButton)e.Row.FindControl("rbtPass");
                RadioButton rbtFailEdit = (RadioButton)e.Row.FindControl("rbtFail");
                TextBox txtRollNo = (TextBox)e.Row.FindControl("txtRollNo");
                TextBox txtDeiLot = (TextBox)e.Row.FindControl("txtDeiLot");
                TextBox txtClaimedLength_Edit = (TextBox)e.Row.FindControl("txtClaimedLength_Edit");
                TextBox txtActLength = (TextBox)e.Row.FindControl("txtActLength");
                TextBox txtChecked = (TextBox)e.Row.FindControl("txtChecked");
                TextBox txtPass = (TextBox)e.Row.FindControl("txtPass");
                TextBox txtFail = (TextBox)e.Row.FindControl("txtFail");
                TextBox txtHold = (TextBox)e.Row.FindControl("txtHold");

                txtRollNo.Text = ss.BoxNo == 0 ? "" : ss.BoxNo.ToString();
                txtDeiLot.Text = ss.DieLot == 0 ? "" : ss.DieLot.ToString();
                txtClaimedLength_Edit.Text = ss.ClaimedLength == 0 ? "" : ss.ClaimedLength.ToString();
                txtActLength.Text = ss.ActLength == 0 ? "" : ss.ActLength.ToString();
                txtChecked.Text = ss.CheckedQty == 0 ? "" : ss.CheckedQty.ToString();
                txtPass.Text = ss.PassQty == 0 ? "" : ss.PassQty.ToString();
                txtFail.Text = ss.FailQty == 0 ? "" : ss.FailQty.ToString();
                txtHold.Text = ss.HoldQty == 0 ? "" : ss.HoldQty.ToString();

                if (ss.Decision == "1")
                {
                    rbtPassEdit.Checked = true;
                }
                if (ss.Decision == "0")
                {
                    rbtFailEdit.Checked = true;
                }

                totalRollBox = txtRollNo.Text == "" ? 0 + totalRollBox : Convert.ToInt32(txtRollNo.Text) + totalRollBox;
                totalDyeLot = txtDeiLot.Text == "" ? 0 + totalDyeLot : Convert.ToInt32(txtDeiLot.Text) + totalDyeLot;
                totalReceivedQty = txtActLength.Text == "" ? 0 + totalReceivedQty : Convert.ToDecimal(txtActLength.Text) + totalReceivedQty;
                totalClaimedQty = txtClaimedLength_Edit.Text == "" ? 0 + totalClaimedQty : Convert.ToDecimal(txtClaimedLength_Edit.Text) + totalClaimedQty;
                totalCheckedQty = txtChecked.Text == "" ? 0 + totalCheckedQty : Convert.ToDecimal(txtChecked.Text) + totalCheckedQty;
                totalPassQty = txtPass.Text == "" ? 0 + totalPassQty : Convert.ToDecimal(txtPass.Text) + totalPassQty;
                totalHoldQty = txtHold.Text == "" ? 0 + totalHoldQty : Convert.ToDecimal(txtHold.Text) + totalHoldQty;
                totalFailQty = txtFail.Text == "" ? 0 + totalFailQty : Convert.ToDecimal(txtFail.Text) + totalFailQty;
            }

            else if (e.Row.RowState == (DataControlRowState.Edit | DataControlRowState.Alternate) && (e.Row.RowIndex < AccessoriesInspectionList.Count()))
            {
                AccessoriesInspect ss = AccessoriesInspectionList[e.Row.RowIndex];

                RadioButton rbtPassEdit = (RadioButton)e.Row.FindControl("rbtPass");
                RadioButton rbtFailEdit = (RadioButton)e.Row.FindControl("rbtFail");

                TextBox txtRollNo = (TextBox)e.Row.FindControl("txtRollNo");
                TextBox txtDeiLot = (TextBox)e.Row.FindControl("txtDeiLot");
                TextBox txtClaimedLength_Edit = (TextBox)e.Row.FindControl("txtClaimedLength_Edit");
                TextBox txtActLength = (TextBox)e.Row.FindControl("txtActLength");
                TextBox txtChecked = (TextBox)e.Row.FindControl("txtChecked");
                TextBox txtPass = (TextBox)e.Row.FindControl("txtPass");
                TextBox txtFail = (TextBox)e.Row.FindControl("txtFail");
                TextBox txtHold = (TextBox)e.Row.FindControl("txtHold");

                txtRollNo.Text = ss.BoxNo == 0 ? "" : ss.BoxNo.ToString();
                txtDeiLot.Text = ss.DieLot == 0 ? "" : ss.DieLot.ToString();
                txtClaimedLength_Edit.Text = ss.ClaimedLength == 0 ? "" : ss.ClaimedLength.ToString();
                txtActLength.Text = ss.ActLength == 0 ? "" : ss.ActLength.ToString();
                txtChecked.Text = ss.CheckedQty == 0 ? "" : ss.CheckedQty.ToString();
                txtPass.Text = ss.PassQty == 0 ? "" : ss.PassQty.ToString();
                txtFail.Text = ss.FailQty == 0 ? "" : ss.FailQty.ToString();
                txtHold.Text = ss.HoldQty == 0 ? "" : ss.HoldQty.ToString();

                if (ss.Decision == "1")
                {
                    rbtPassEdit.Checked = true;
                }
                if (ss.Decision == "0")
                {
                    rbtFailEdit.Checked = true;
                }

                totalRollBox = txtRollNo.Text == "" ? 0 + totalRollBox : Convert.ToInt32(txtRollNo.Text) + totalRollBox;
                totalDyeLot = txtDeiLot.Text == "" ? 0 + totalDyeLot : Convert.ToInt32(txtDeiLot.Text) + totalDyeLot;
                totalReceivedQty = txtActLength.Text == "" ? 0 + totalReceivedQty : Convert.ToDecimal(txtActLength.Text) + totalReceivedQty;
                totalClaimedQty = txtClaimedLength_Edit.Text == "" ? 0 + totalClaimedQty : Convert.ToDecimal(txtClaimedLength_Edit.Text) + totalClaimedQty;
                totalCheckedQty = txtChecked.Text == "" ? 0 + totalCheckedQty : Convert.ToDecimal(txtChecked.Text) + totalCheckedQty;
                totalPassQty = txtPass.Text == "" ? 0 + totalPassQty : Convert.ToDecimal(txtPass.Text) + totalPassQty;
                totalHoldQty = txtHold.Text == "" ? 0 + totalHoldQty : Convert.ToDecimal(txtHold.Text) + totalHoldQty;
                totalFailQty = txtFail.Text == "" ? 0 + totalFailQty : Convert.ToDecimal(txtFail.Text) + totalFailQty;
            }

            else if (e.Row.RowState != (DataControlRowState.Edit | DataControlRowState.Alternate))
            {
                if (e.Row.RowType == DataControlRowType.DataRow && (e.Row.RowIndex < AccessoriesInspectionList.Count()))
                {
                    AccessoriesInspect ss = AccessoriesInspectionList[e.Row.RowIndex];

                    RadioButton rbtPass = (RadioButton)e.Row.FindControl("rbtPass");
                    RadioButton rbtFail = (RadioButton)e.Row.FindControl("rbtFail");
                    Label lblRollNo = (Label)e.Row.FindControl("lblRollNo");
                    Label lblDeiLot = (Label)e.Row.FindControl("lblDeiLot");
                    Label lblClaimedLength = (Label)e.Row.FindControl("lblClaimedLength");
                    Label lblActLength = (Label)e.Row.FindControl("lblActLength");
                    Label lblChecked = (Label)e.Row.FindControl("lblChecked");
                    Label lblPass = (Label)e.Row.FindControl("lblPass");
                    Label lblFail = (Label)e.Row.FindControl("lblFail");
                    Label lblHold = (Label)e.Row.FindControl("lblHold");
                    LinkButton lkEdit = (LinkButton)e.Row.FindControl("lkEdit");
                    LinkButton lnkDelete= (LinkButton) e.Row.FindControl("lnkDelete");


                    if (hdnLoginId.Value == "25" || chkAccessoriesQA.Checked)
                    {

                        lkEdit.Enabled = false;
                        lnkDelete.Enabled = false;
                    }

                    lblRollNo.Text = ss.BoxNo == 0 ? "" : ss.BoxNo.ToString();
                    lblDeiLot.Text = ss.DieLot == 0 ? "" : ss.DieLot.ToString();
                    lblClaimedLength.Text = ss.ClaimedLength == 0 ? "" : ss.ClaimedLength.ToString();
                    lblActLength.Text = ss.ActLength == 0 ? "" : ss.ActLength.ToString();
                    lblChecked.Text = ss.CheckedQty == 0 ? "" : ss.CheckedQty.ToString();
                    lblPass.Text = ss.PassQty == 0 ? "" : ss.PassQty.ToString();
                    lblFail.Text = ss.FailQty == 0 ? "" : ss.FailQty.ToString();
                    lblHold.Text = ss.HoldQty == 0 ? "" : ss.HoldQty.ToString();

                    decimal claimedValue = lblClaimedLength.Text != string.Empty ? Convert.ToDecimal(lblClaimedLength.Text) : 0;
                    decimal actualValue = lblActLength.Text != string.Empty ? Convert.ToDecimal(lblActLength.Text) : 0;
                    decimal holdValue = lblHold.Text != string.Empty ? Convert.ToDecimal(lblHold.Text) : 0;
                    if (holdValue > 0)
                    {
                        e.Row.Cells[6].Attributes.Add("style", "background-color:yellow;");
                    }

                    if (claimedValue < actualValue)
                    {
                        e.Row.Cells[3].Attributes.Add("style", "background-color:#FFB7B2");
                    }
                    else if (claimedValue > actualValue)
                    {
                        e.Row.Cells[3].Attributes.Add("style", "background-color:#FDFD96");
                    }
                    else
                    {
                        e.Row.Cells[3].Attributes.Add("style", "background-color:#fff");
                    }

                    if (ss.Decision == "1")
                    {
                        rbtPass.Checked = true;
                    }
                    if (ss.Decision == "0")
                    {
                        rbtFail.Checked = true;
                    }
                    string lblDeiLot2 = lblDeiLot.Text.Replace(",", "");
                    totalRollBox = lblRollNo.Text == "" ? 0 + totalRollBox : Convert.ToInt32(lblRollNo.Text.Replace(",", "")) + totalRollBox;
                    totalDyeLot = lblDeiLot.Text == "" ? 0 + totalDyeLot : Convert.ToInt32(lblDeiLot2) + totalDyeLot;
                    totalClaimedQty = lblClaimedLength.Text == "" ? 0 + totalClaimedQty : Convert.ToDecimal(lblClaimedLength.Text) + totalClaimedQty;
                    totalReceivedQty = lblActLength.Text == "" ? 0 + totalReceivedQty : Convert.ToDecimal(lblActLength.Text) + totalReceivedQty;
                    totalCheckedQty = lblChecked.Text == "" ? 0 + totalCheckedQty : Convert.ToDecimal(lblChecked.Text) + totalCheckedQty;
                    totalPassQty = lblPass.Text == "" ? 0 + totalPassQty : Convert.ToDecimal(lblPass.Text) + totalPassQty;
                    totalHoldQty = lblHold.Text == "" ? 0 + totalHoldQty : Convert.ToDecimal(lblHold.Text) + totalHoldQty;
                    totalFailQty = lblFail.Text == "" ? 0 + totalFailQty : Convert.ToDecimal(lblFail.Text) + totalFailQty;
                }
            }
            lblTotalRollNo.Text = totalRollBox == 0 ? "" : totalRollBox.ToString("N0");
            lblTotalDyedNo.Text = totalDyeLot == 0 ? "" : totalDyeLot.ToString();
            lblTotalClaimedLength.Text = totalClaimedQty == 0 ? "" : totalClaimedQty.ToString();
            lblTotalActualLength.Text = totalReceivedQty == 0 ? "" : totalReceivedQty.ToString();
            lblTotalChecked.Text = totalCheckedQty == 0 ? "" : totalCheckedQty.ToString();
            lblTotalPass.Text = totalPassQty == 0 ? "" : totalPassQty.ToString();
            lblTotalHold.Text = totalHoldQty == 0 ? "" : totalHoldQty.ToString();
            lblTotalFailed.Text = totalFailQty == 0 ? "" : totalFailQty.ToString();

            lblTotalFailQty.Text = Convert.ToDecimal(totalFailQty).ToString() == "0" ? "" : totalFailQty.ToString();

            if (totalPassQty > 0)
            {
                lblTotalPass.Attributes.Add("style", "color:green;");
            }

            if (totalFailQty > 0)
            {
                lblTotalFailed.Attributes.Add("style", "color:red;");
                lblTotalFailQty.Attributes.Add("style", "color:red;");
            }

            if (totalHoldQty > 0)
            {
                //lblTotalHold.Attributes.Add("style", "background-color:yellow;");
                tdTotalHold.Attributes.Add("style", "background-color:yellow;");
            }

            else
            {
                tdTotalHold.Attributes.Add("style", "background-color:#fff;");
            }

            //FailedQtyId.Visible = totalFailQty > 0 ? true : false;


            if (totalClaimedQty > totalReceivedQty)
            {
                //lblTotalActualLength.Attributes.Add("style", "background-color:#FDFD96");
                totalAccInspection.Rows[0].Cells[3].Attributes.Add("style", "background-color:#FDFD96");
            }
            else if (totalClaimedQty < totalReceivedQty)
            {
                //lblTotalActualLength.Attributes.Add("style", "background-color:#FFB7B2");
                //grv_Accessories_Inspection.Columns[3].ItemStyle.ForeColor = System.Drawing.ColorTranslator.FromHtml("#FFB7B2");
                totalAccInspection.Rows[0].Cells[3].Attributes.Add("style", "background-color:#FFB7B2");
            }
            else
            {
                //lblTotalActualLength.Attributes.Add("style", "background-color:#fff");                
                //grv_Accessories_Inspection.Columns[3].ItemStyle.ForeColor = System.Drawing.ColorTranslator.FromHtml("#fff");
                totalAccInspection.Rows[0].Cells[3].Attributes.Add("style", "background-color:#fff");
            }
        }

        protected void grv_Accessories_Inspection_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "AddEmpty")
            {
                Table tblgvDetail = (Table)grv_Accessories_Inspection.Controls[0];
                GridViewRow rows = (GridViewRow)tblgvDetail.Controls[0];
                
                ImageButton btnAdd_Empty = (ImageButton)rows.FindControl("btnAdd_Empty");
                btnAdd_Empty.Attributes.Add("display", "none");
                HiddenField hdnid = rows.FindControl("hdnParticularId") as HiddenField;
                TextBox txtRollNo_Empty = (TextBox)rows.FindControl("txtRollNo_Empty");
                TextBox txtDeiLot_Empty = (TextBox)rows.FindControl("txtDeiLot_Empty");
                TextBox txtClaimedLength_Empty = (TextBox)rows.FindControl("txtClaimedLength_Empty");   //new line
                TextBox txtActLength_Empty = (TextBox)rows.FindControl("txtActLength_Empty");
                TextBox txtPass_Empty = (TextBox)rows.FindControl("txtPass_Empty");
                TextBox txtChecked_Empty = (TextBox)rows.FindControl("txtChecked_Empty");
                TextBox txtFail_Empty = (TextBox)rows.FindControl("txtFail_Empty");
                TextBox txtHold_Empty = (TextBox)rows.FindControl("txtHold_Empty");

                RadioButton rbtPass_Empty = (RadioButton)rows.FindControl("rbtPass_Empty");
                RadioButton rbtFail_Empty = (RadioButton)rows.FindControl("rbtFail_Empty");
                //DataTable dt = new DataTable();
                //dt.Columns.Add("InspectionParticular_Id", typeof(int));
                //dt.Columns.Add("DieLot", typeof(int));
                //dt.Columns.Add("ClaimedLength", typeof(decimal));
                //dt.Columns.Add("BoxNo", typeof(int));
                //dt.Columns.Add("ActLength", typeof(decimal));
                //dt.Columns.Add("PassQty", typeof(decimal));
                //dt.Columns.Add("CheckedQty", typeof(decimal));
                //dt.Columns.Add("FailQty", typeof(decimal));
                //dt.Columns.Add("Decision", typeof(string));
                //dt.Columns.Add("CreatedBy", typeof(int));
                //dt.Columns.Add("HoldQty", typeof(decimal));
              
                
             //   dt.Rows.Clear();

               //DataRow dr = dt.NewRow();
               // dt.NewRow();

               

                if (txtRollNo_Empty.Text == string.Empty)
                {
                    ShowAlert("Roll/Box No. cannot blank!");
                    return;
                }
                if (txtDeiLot_Empty.Text == string.Empty)
                {
                    ShowAlert("Dye Lot cannot blank!");
                    return;
                }

                if (txtClaimedLength_Empty.Text == string.Empty)
                {
                    ShowAlert("Claimed Length cannot blank!");
                    return;
                }

                if (txtActLength_Empty.Text == string.Empty)
                {
                    ShowAlert("Actual Quantity cannot blank!");
                    return;
                }
                if (txtChecked_Empty.Text == string.Empty)
                {
                    ShowAlert("Checked Quantity cannot blank!");
                    return;
                }
                if (Convert.ToDecimal(txtChecked_Empty.Text) > Convert.ToDecimal(txtActLength_Empty.Text))
                {
                    ShowAlert("Checked Quantity cannot greater than Actual Quantity!");
                    return;
                }
                decimal passQty = txtPass_Empty.Text == string.Empty ? 0 : Convert.ToDecimal(txtPass_Empty.Text);
                decimal failQty = txtFail_Empty.Text == string.Empty ? 0 : Convert.ToDecimal(txtFail_Empty.Text);
                decimal holdQty = txtHold_Empty.Text == string.Empty ? 0 : Convert.ToDecimal(txtHold_Empty.Text);
                decimal checkedQty = txtChecked_Empty.Text == string.Empty ? 0 : Convert.ToDecimal(txtChecked_Empty.Text);
                if (passQty + failQty + holdQty != checkedQty)
                {
                    ShowAlert("(Pass + Fail + Hold) Quantity should be equal Checked Quantity!");
                    return;
                }

                //if (Convert.ToDecimal(lblTotalClaimedLength.Text) < Convert.ToDecimal(lblTotalActualLength.Text))
                //{

                //    lblInspectExtraQty.Text = (totalReceivedQty - Convert.ToDecimal(lblTotalClaimedLength.Text)).ToString();
                //}

                AccessoriesInspect accessoriesInspection = new AccessoriesInspect();
               
                //dr["BoxNo"] = Convert.ToInt32(txtRollNo_Empty.Text);
                //if(hdnid!= null)
                //{
                //dr["InspectionParticular_Id"] =Convert.ToInt32(hdnid.Value);
                //}
                //else
                //{
                //    dr["InspectionParticular_Id"] = 1;
                
                //}
               
                accessoriesInspection.BoxNo = Convert.ToInt32(txtRollNo_Empty.Text);
                if (txtDeiLot_Empty.Text != string.Empty)
                {
                    accessoriesInspection.DieLot = Convert.ToDecimal(txtDeiLot_Empty.Text);
                //    dr["DieLot"] = Convert.ToDecimal(txtDeiLot_Empty.Text);
                }
                if (txtClaimedLength_Empty.Text != string.Empty)
                {
                    accessoriesInspection.ClaimedLength = Convert.ToDecimal(txtClaimedLength_Empty.Text);
                  //  dr["ClaimedLength"] = Convert.ToDecimal(txtClaimedLength_Empty.Text);
                }
                if (txtActLength_Empty.Text != string.Empty)
                {
                    accessoriesInspection.ActLength = Convert.ToDecimal(txtActLength_Empty.Text);
                 //   dr["ActLength"] = Convert.ToDecimal(txtActLength_Empty.Text);
                }
                if (txtPass_Empty.Text != string.Empty)
                {

                    accessoriesInspection.PassQty = Convert.ToDecimal(txtPass_Empty.Text);
                   // dr["PassQty"] = Convert.ToDecimal(txtPass_Empty.Text);
                }
                if (txtChecked_Empty.Text != string.Empty)
                {
                    accessoriesInspection.CheckedQty = Convert.ToDecimal(txtChecked_Empty.Text);
                  //  dr["CheckedQty"] = Convert.ToDecimal(txtChecked_Empty.Text);
                }
                if (txtFail_Empty.Text != string.Empty)
                {
                    accessoriesInspection.FailQty = Convert.ToDecimal(txtFail_Empty.Text);
                 //   dr["FailQty"] = Convert.ToDecimal(txtFail_Empty.Text);
                }
                if (txtHold_Empty.Text != string.Empty)
                {
                    accessoriesInspection.HoldQty = Convert.ToDecimal(txtHold_Empty.Text);
                   // dr["HoldQty"] = Convert.ToDecimal(txtHold_Empty.Text);
                }
                if (rbtPass_Empty.Checked == true || rbtFail_Empty.Checked == true)
                {
                    accessoriesInspection.Decision = rbtPass_Empty.Checked ? "1" : "0";
                   // dr["Decision"] = rbtFail_Empty.Checked ? "1" : "0";
                }
                    accessoriesInspection.CreatedBy = iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.UserID;
                   // dr["CreatedBy"] = iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.UserID;
                    //  dt.Rows.Add(dr);
                      if (Count==0)
                      {
                          AccessoriesInspectionList.Clear();
                      }
                      AccessoriesInspectionList.Add(accessoriesInspection);
                      grv_Accessories_Inspection.DataSource = AccessoriesInspectionList;
                      grv_Accessories_Inspection.DataBind();
                      //grv_Accessories_Inspection.DataSource = dt;
                      //grv_Accessories_Inspection.DataBind();
            }
            if (e.CommandName == "AddFooter")
            {
                ImageButton btnAdd_Footer = (ImageButton)grv_Accessories_Inspection.FooterRow.FindControl("btnAdd_Footer");
                btnAdd_Footer.Attributes.Add("display", "none");

                AccessoriesInspectionList.Clear();
                decimal TotalActualLength = 0;
                for (int i = 0; i < grv_Accessories_Inspection.Rows.Count; i++)
                {
                    AccessoriesInspect accessoriesInspection = new AccessoriesInspect();

                    Label lblRollNo = (Label)grv_Accessories_Inspection.Rows[i].FindControl("lblRollNo");
                    Label lblDeiLot = (Label)grv_Accessories_Inspection.Rows[i].FindControl("lblDeiLot");
                    Label lblClaimedLength = (Label)grv_Accessories_Inspection.Rows[i].FindControl("lblClaimedLength"); //new line
                    Label lblActLength = (Label)grv_Accessories_Inspection.Rows[i].FindControl("lblActLength");
                    Label lblPass = (Label)grv_Accessories_Inspection.Rows[i].FindControl("lblPass");
                    Label lblChecked = (Label)grv_Accessories_Inspection.Rows[i].FindControl("lblChecked");
                    Label lblFail = (Label)grv_Accessories_Inspection.Rows[i].FindControl("lblFail");
                    Label lblHold = (Label)grv_Accessories_Inspection.Rows[i].FindControl("lblHold");
                    RadioButton rbtPass = (RadioButton)grv_Accessories_Inspection.Rows[i].FindControl("rbtPass");
                    RadioButton rbtFail = (RadioButton)grv_Accessories_Inspection.Rows[i].FindControl("rbtFail");
                    HiddenField hdnId = (HiddenField)grv_Accessories_Inspection.Rows[i].FindControl("hdnId");


                    if (lblRollNo.Text != string.Empty)
                        accessoriesInspection.BoxNo = Convert.ToInt32(lblRollNo.Text);
                    if (lblDeiLot.Text != string.Empty)
                        accessoriesInspection.DieLot = Convert.ToDecimal(lblDeiLot.Text.Replace(",", ""));
                    if (lblClaimedLength.Text != string.Empty)
                        accessoriesInspection.ClaimedLength = Convert.ToDecimal(lblClaimedLength.Text.Replace(",", ""));
                    if (lblActLength.Text != string.Empty)
                        accessoriesInspection.ActLength = Convert.ToDecimal(lblActLength.Text.Replace(",", ""));
                    if (lblPass.Text != string.Empty)
                        accessoriesInspection.PassQty = Convert.ToDecimal(lblPass.Text.Replace(",", ""));
                    if (lblChecked.Text != string.Empty)
                        accessoriesInspection.CheckedQty = Convert.ToDecimal(lblChecked.Text.Replace(",", ""));
                    if (lblFail.Text != string.Empty)
                        accessoriesInspection.FailQty = Convert.ToDecimal(lblFail.Text.Replace(",", ""));
                    if (lblHold.Text != string.Empty)
                        accessoriesInspection.HoldQty = Convert.ToDecimal(lblHold.Text.Replace(",", ""));
                    if (rbtPass.Checked == true || rbtFail.Checked == true)
                        accessoriesInspection.Decision = rbtPass.Checked ? "1" : "0";
                    accessoriesInspection.CreatedBy = iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.UserID;
                    accessoriesInspection.InspectionParticular_Id = Convert.ToInt32(hdnId.Value);

                    if (txtTotalQuantity.Text != string.Empty)
                        TotalQuantitySRV = Convert.ToDecimal(txtTotalQuantity.Text.Replace(",", ""));
                    TotalActualLength = accessoriesInspection.ActLength + TotalActualLength;
                    //hdnTotalQuantity.Value = TotalActualLength.ToString();

                    AccessoriesInspectionList.Add(accessoriesInspection);

                }

                AccessoriesInspect accessoriesInspectionFooter = new AccessoriesInspect();

                TextBox txtRollNo_Footer = (TextBox)grv_Accessories_Inspection.FooterRow.FindControl("txtRollNo_Footer");
                TextBox txtDeiLot_Footer = (TextBox)grv_Accessories_Inspection.FooterRow.FindControl("txtDeiLot_Footer");
                TextBox txtClaimedLength_Footer = (TextBox)grv_Accessories_Inspection.FooterRow.FindControl("txtClaimedLength_Footer"); //new line
                TextBox txtActLength_Footer = (TextBox)grv_Accessories_Inspection.FooterRow.FindControl("txtActLength_Footer");
                TextBox txtPass_Footer = (TextBox)grv_Accessories_Inspection.FooterRow.FindControl("txtPass_Footer");
                TextBox txtChecked_Footer = (TextBox)grv_Accessories_Inspection.FooterRow.FindControl("txtChecked_Footer");
                TextBox txtFail_Footer = (TextBox)grv_Accessories_Inspection.FooterRow.FindControl("txtFail_Footer");
                TextBox txtHold_Footer = (TextBox)grv_Accessories_Inspection.FooterRow.FindControl("txtHold_Footer");
                RadioButton rbtPass_Footer = (RadioButton)grv_Accessories_Inspection.FooterRow.FindControl("rbtPass_Footer");
                RadioButton rbtFail_Footer = (RadioButton)grv_Accessories_Inspection.FooterRow.FindControl("rbtFail_Footer");

                if (txtRollNo_Footer.Text == string.Empty)
                {
                    ShowAlert("Roll/Box No. cannot blank!");
                    return;
                }
                if (txtDeiLot_Footer.Text == string.Empty)
                {
                    ShowAlert("Dyed Lot cannot blank!");
                    return;
                }

                if (txtClaimedLength_Footer.Text == string.Empty)
                {
                    ShowAlert("Claimed Length cannot blank!");
                    return;
                }

                if (txtActLength_Footer.Text == string.Empty)
                {
                    ShowAlert("Actual Quantity cannot blank!");
                    return;
                }
                if (txtChecked_Footer.Text == string.Empty)
                {
                    ShowAlert("Checked Quantity cannot blank!");
                    return;
                }
                if (Convert.ToDecimal(txtChecked_Footer.Text) > Convert.ToDecimal(txtActLength_Footer.Text))
                {
                    ShowAlert("Checked Quantity cannot greater than Actual Quantity!");
                    return;
                }
                decimal passQty = txtPass_Footer.Text == string.Empty ? 0 : Convert.ToDecimal(txtPass_Footer.Text);
                decimal failQty = txtFail_Footer.Text == string.Empty ? 0 : Convert.ToDecimal(txtFail_Footer.Text);
                decimal holdQty = txtHold_Footer.Text == string.Empty ? 0 : Convert.ToDecimal(txtHold_Footer.Text);
                decimal checkedQty = txtChecked_Footer.Text == string.Empty ? 0 : Convert.ToDecimal(txtChecked_Footer.Text);
                if (passQty + failQty + holdQty != checkedQty)
                {
                    ShowAlert("(Pass + Fail + Hold) Quantity should be equal to Checked Quantity!");
                    return;
                }

                accessoriesInspectionFooter.BoxNo = Convert.ToInt32(txtRollNo_Footer.Text);

                if (txtDeiLot_Footer.Text != string.Empty)
                    accessoriesInspectionFooter.DieLot = Convert.ToDecimal(txtDeiLot_Footer.Text);

                if (txtClaimedLength_Footer.Text != string.Empty)
                    accessoriesInspectionFooter.ClaimedLength = Convert.ToDecimal(txtClaimedLength_Footer.Text);

                if (txtActLength_Footer.Text != string.Empty)
                    accessoriesInspectionFooter.ActLength = Convert.ToDecimal(txtActLength_Footer.Text);
                if (txtPass_Footer.Text != string.Empty)
                    accessoriesInspectionFooter.PassQty = Convert.ToDecimal(txtPass_Footer.Text);
                if (txtChecked_Footer.Text != string.Empty)
                    accessoriesInspectionFooter.CheckedQty = Convert.ToDecimal(txtChecked_Footer.Text);
                if (txtFail_Footer.Text != string.Empty)
                    accessoriesInspectionFooter.FailQty = Convert.ToDecimal(txtFail_Footer.Text);
                if (txtHold_Footer.Text != string.Empty)
                    accessoriesInspectionFooter.HoldQty = Convert.ToDecimal(txtHold_Footer.Text);
                if (rbtPass_Footer.Checked == true || rbtFail_Footer.Checked == true)
                    accessoriesInspectionFooter.Decision = rbtPass_Footer.Checked ? "1" : "0";
                accessoriesInspectionFooter.CreatedBy = iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.UserID;

                AccessoriesInspectionList.Add(accessoriesInspectionFooter);


                grv_Accessories_Inspection.DataSource = AccessoriesInspectionList;
                grv_Accessories_Inspection.DataBind();

                btnAdd_Footer.Attributes.Add("display", "");

            }
            decimal total = AccessoriesInspectionList.Sum(item => item.ActLength);
            int box = AccessoriesInspectionList.Sum(item => item.BoxNo);

            //lblTotalPcs.Text = "<span><b>" + total.ToString("N0") + "</b></span><span class='txtColorGray'> " + GarmentUnit + "</span> (<b>" + box.ToString() + "</b>)";
            //if (total < TotalQuantitySRV)
            //{
            //    tdTotalPcs.Style.Add("background-color", "#FDFD96;");
            //}
            //else if (total > TotalQuantitySRV)
            //{
            //    tdTotalPcs.Style.Add("background-color", "#FFB7B2;");
            //}

        }

        protected void grv_Accessories_Inspection_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            if (e.RowIndex < AccessoriesInspectionList.Count())
            {
                AccessoriesInspect ai = AccessoriesInspectionList[e.RowIndex];

                DeletetedInspectionId.Add(ai.InspectionParticular_Id);
                AccessoriesInspectionList.RemoveAt(e.RowIndex);
                grv_Accessories_Inspection.DataSource = AccessoriesInspectionList;
                grv_Accessories_Inspection.DataBind();
                decimal total = AccessoriesInspectionList.Sum(item => item.ActLength);
                int box = AccessoriesInspectionList.Sum(item => item.BoxNo);

                //lblTotalPcs.Text = "<span><b>" + total.ToString("N0") + "</b></span><span class='txtColorGray'> " + GarmentUnit + "</span> (<b>" + box.ToString() + "</b>)";
                //if (total < TotalQuantitySRV)
                //{
                //    tdTotalPcs.Style.Add("background-color", "#FDFD96;");
                //}
                //else if (total > TotalQuantitySRV)
                //{
                //    tdTotalPcs.Style.Add("background-color", "#FFB7B2;");
                //}

            }
        }

        protected void grv_Accessories_Inspection_RowEditing(object sender, GridViewEditEventArgs e)
        {
            chkAccessoriesQA.Checked = false;
            grv_Accessories_Inspection.EditIndex = e.NewEditIndex;
            grv_Accessories_Inspection.DataSource = AccessoriesInspectionList;
            grv_Accessories_Inspection.DataBind();
            grv_Accessories_Inspection.FooterRow.Visible = false;
        }

        protected void grv_Accessories_Inspection_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            //int TotalActualLength = 0;
            GridViewRow row = grv_Accessories_Inspection.Rows[e.RowIndex];

            AccessoriesInspect accessoriesInspection = new AccessoriesInspect();
            HiddenField hdnParticularId = (HiddenField)row.FindControl("hdnParticularId");
            TextBox txtRollNo = (TextBox)row.FindControl("txtRollNo");
            TextBox txtDeiLot = (TextBox)row.FindControl("txtDeiLot");
            TextBox txtClaimedLength_Edit = (TextBox)row.FindControl("txtClaimedLength_Edit");    //new line
            TextBox txtActLength = (TextBox)row.FindControl("txtActLength");
            TextBox txtPass = (TextBox)row.FindControl("txtPass");
            TextBox txtChecked = (TextBox)row.FindControl("txtChecked");
            TextBox txtFail = (TextBox)row.FindControl("txtFail");
            TextBox txtHold = (TextBox)row.FindControl("txtHold");
            RadioButton rbtPassEdit = (RadioButton)row.FindControl("rbtPass");
            RadioButton rbtFailEdit = (RadioButton)row.FindControl("rbtFail");

            if (hdnParticularId != null)
                accessoriesInspection.InspectionParticular_Id = Convert.ToInt32(hdnParticularId.Value);

            if (txtRollNo.Text != string.Empty)
                accessoriesInspection.BoxNo = Convert.ToInt32(txtRollNo.Text);
            if (txtDeiLot.Text != string.Empty)
                accessoriesInspection.DieLot = Convert.ToDecimal(txtDeiLot.Text.Replace(",", ""));

            if (txtClaimedLength_Edit.Text != string.Empty)
                accessoriesInspection.ClaimedLength = Convert.ToDecimal(txtClaimedLength_Edit.Text.Replace(",", ""));

            if (txtActLength.Text != string.Empty)
                accessoriesInspection.ActLength = Convert.ToDecimal(txtActLength.Text.Replace(",", ""));
            if (txtPass.Text != string.Empty)
                accessoriesInspection.PassQty = Convert.ToDecimal(txtPass.Text.Replace(",", ""));
            if (txtChecked.Text != string.Empty)
                accessoriesInspection.CheckedQty = Convert.ToDecimal(txtChecked.Text.Replace(",", ""));
            if (txtFail.Text != string.Empty)
                accessoriesInspection.FailQty = Convert.ToDecimal(txtFail.Text.Replace(",", ""));
            if (txtHold.Text != string.Empty)
                accessoriesInspection.HoldQty = Convert.ToDecimal(txtHold.Text.Replace(",", ""));
            if (rbtPassEdit.Checked == true || rbtFailEdit.Checked == true)
                accessoriesInspection.Decision = rbtPassEdit.Checked ? "1" : "0";
            accessoriesInspection.CreatedBy = iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.UserID;

            decimal passQty = txtPass.Text == string.Empty ? 0 : Convert.ToDecimal(txtPass.Text.Replace(",", ""));
            decimal failQty = txtFail.Text == string.Empty ? 0 : Convert.ToDecimal(txtFail.Text.Replace(",", ""));
            decimal holdQty = txtHold.Text == string.Empty ? 0 : Convert.ToDecimal(txtHold.Text.Replace(",", ""));
            decimal checkedQty = txtChecked.Text == string.Empty ? 0 : Convert.ToDecimal(txtChecked.Text.Replace(",", ""));

            if (txtRollNo.Text == string.Empty)
            {
                ShowAlert("Roll/Box No. cannot blank!");
                return;
            }
            if (txtDeiLot.Text == string.Empty)
            {
                ShowAlert("Dyed Lot cannot blank!");
                return;
            }

            if (txtClaimedLength_Edit.Text == string.Empty)
            {
                ShowAlert("Claimed Length cannot blank!");
                return;
            }


            if (txtActLength.Text == string.Empty)
            {
                ShowAlert("Actual Quantity cannot blank!");
                return;
            }
            if (txtChecked.Text == string.Empty)
            {
                ShowAlert("Checked Quantity cannot blank!");
                return;
            }
            if (Convert.ToDecimal(txtChecked.Text.Replace(",", "")) > Convert.ToDecimal(txtActLength.Text.Replace(",", "")))
            {
                ShowAlert("Checked Quantity cannot greater than Actual Quantity!");
                return;
            }
            if (passQty + failQty + holdQty != checkedQty)
            {
                ShowAlert("(Pass + Fail + Hold) Quantity should be equal Checked Quantity!");
                return;
            }

            AccessoriesInspectionList.RemoveAt(e.RowIndex);
            AccessoriesInspectionList.Insert(e.RowIndex, accessoriesInspection);


            grv_Accessories_Inspection.EditIndex = -1;
            grv_Accessories_Inspection.DataSource = AccessoriesInspectionList;
            grv_Accessories_Inspection.DataBind();

            decimal total = AccessoriesInspectionList.Sum(item => item.ActLength);
            int box = AccessoriesInspectionList.Sum(item => item.BoxNo);

            //lblTotalPcs.Text = "<span><b>" + total.ToString("N0") + "</b></span><span class='txtColorGray'> " + GarmentUnit + "</span> (<b>" + box.ToString() + "</b>)";
            //if (total < TotalQuantitySRV)
            //{
            //    tdTotalPcs.Style.Add("background-color", "#FDFD96;");
            //}
            //else if (total > TotalQuantitySRV)
            //{
            //    tdTotalPcs.Style.Add("background-color", "#FFB7B2;");
            //}


        }

        protected void grv_Accessories_Inspection_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grv_Accessories_Inspection.EditIndex = -1;
            grv_Accessories_Inspection.DataSource = AccessoriesInspectionList;
            grv_Accessories_Inspection.DataBind();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (chkAccessoriesGM.Checked && hdnLoginId.Value == "15")
            {
                //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "Confirm();", true);

            }
            AccessoriesInspectSystem accessoriesInspectSystem = new AccessoriesInspectSystem();
            //if (lblTotalHold.Text != string.Empty && lblTotalHold.Text != "0")
            //{
            //    ShowAlert("Hold Quantity should handle");
            //    //txtCheckerName1.Focus();                
            //    return;
            //}
            string InternalLabReportFileName = "";
            string ExternalLabReportFileName = "";
            //bool FinalDecision = false;

            accessoriesInspectSystem.SupplierPO_Id = SupplierPoId;
            accessoriesInspectSystem.SRV_Id = SrvId;
            if (txtCheckerName1.Text != string.Empty)
            {
                accessoriesInspectSystem.CheckerName1 = txtCheckerName1.Text;
            }

            accessoriesInspectSystem.CheckerName2 = txtCheckerName2.Text;

            accessoriesInspectSystem.Comments = txtComments.Text;
            accessoriesInspectSystem.CreatedBy = iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.UserID;
            if (lblTotalClaimedLength.Text != string.Empty)
                accessoriesInspectSystem.ClaimedQty = Convert.ToDecimal(lblTotalClaimedLength.Text.Replace(",", ""));

            if (lblTotalActualLength.Text != string.Empty)
                accessoriesInspectSystem.RecievedQty = Convert.ToDecimal(lblTotalActualLength.Text.Replace(",", ""));

            if (lblTotalChecked.Text != string.Empty)
                accessoriesInspectSystem.CheckedQty = Convert.ToDecimal(lblTotalChecked.Text.Replace(",", ""));

            if (lblTotalPass.Text != string.Empty)
                accessoriesInspectSystem.PassQty = Convert.ToDecimal(lblTotalPass.Text.Replace(",", ""));

            if (lblTotalHold.Text != string.Empty)
                accessoriesInspectSystem.HoldQty = Convert.ToDecimal(lblTotalHold.Text.Replace(",", ""));

            if (lblTotalFailed.Text != string.Empty)
                accessoriesInspectSystem.FailQty = Convert.ToDecimal(lblTotalFailed.Text.Replace(",", ""));


            if (ddlAllocatedUnit.SelectedValue != "-1")
            {
                accessoriesInspectSystem.UnitId = Convert.ToInt32(ddlAllocatedUnit.SelectedValue);
            }
            accessoriesInspectSystem.InspectionDate = Convert.ToDateTime(txtDate.Text);

            //if (chkAccessoriesQA.Checked == true)
            //{
            //    accessoriesInspectSystem.IsAccessoryQA = chkAccessoriesQA.Checked == true ? true : false;
            //}
            //if (chkAccessoriesGM.Checked == true)
            //{
            //    accessoriesInspectSystem.IsAccessoryGM = chkAccessoriesGM.Checked == true ? true : false;
            //}


            //new code start
            if (txtInternalLabSpecimanCount.Text != "")
            {
                accessoriesInspectSystem.InternalLabSpeciman = Convert.ToInt32(txtInternalLabSpecimanCount.Text);
            }

            accessoriesInspectSystem.InternalSentToLab = chkInternalSentToLab.Checked == true ? true : false;
            hdnchkInternalSentToLab.Value = chkInternalSentToLab.Checked == true ? "True" : "False";

            //if (chkInternalSentToLab.Checked)
            //{
            //    accessoriesInspectSystem.InternalSentToLabDate = Convert.ToDateTime(DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss"));
            //}

            if (hdnchkInternalSentToLab.Value == "True" && lblInternalSentToLabDate.Text == "")
            {
                accessoriesInspectSystem.InternalSentToLabDate = DateTime.Now;
            }
            else
            {
                if (lblInternalSentToLabDate.Text != "")
                {
                    accessoriesInspectSystem.InternalSentToLabDate = (DateTime.ParseExact(lblInternalSentToLabDate.Text, "dd MMM yy (ddd) HH:mm", System.Globalization.CultureInfo.InvariantCulture));
                    //accessoriesInspectSystem.InternalSentToLabDate = Convert.ToDateTime(hdnExternalReceivedInLabDate.Value);
                }
            }

            accessoriesInspectSystem.InternalReceivedInLab = chkInternalReceivedInLab.Checked == true ? true : false;
            hdnchkInternalReceivedInLab.Value = chkInternalReceivedInLab.Checked == true ? "True" : "False";

            //if (chkInternalReceivedInLab.Checked)
            //{
            //    accessoriesInspectSystem.InternalReceivedInLabDate = Convert.ToDateTime(DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss"));
            //}

            if (hdnchkInternalReceivedInLab.Value == "True" && lblInternalReceivedIndLabDate.Text == "")
            {
                accessoriesInspectSystem.InternalReceivedInLabDate = DateTime.Now;
            }
            else
            {
                if (lblInternalReceivedIndLabDate.Text != "")
                {
                    //accessoriesInspectSystem.InternalReceivedInLabDate = Convert.ToDateTime(hdnInternalReceivedInLabDate.Value);
                    accessoriesInspectSystem.InternalReceivedInLabDate = (DateTime.ParseExact(lblInternalReceivedIndLabDate.Text, "dd MMM yy (ddd) HH:mm", System.Globalization.CultureInfo.InvariantCulture));
                }
            }

            if (uploadInternalLabReport.HasFile)
            {
                string Exten = System.IO.Path.GetExtension(uploadInternalLabReport.FileName);
                string ActualfileName = "Internal_Lab_Report_" + uploadInternalLabReport.FileName;
                string Name = ActualfileName.Substring(0, ActualfileName.LastIndexOf('.'));
                InternalLabReportFileName = FileHelper.SaveFile(uploadInternalLabReport.PostedFile.InputStream, uploadInternalLabReport.FileName, Constants.PHOTO_FOLDER_PATH, true, Name);
                accessoriesInspectSystem.InternalLabReport = InternalLabReportFileName;
                hylnkInternalLabReport.Visible = false;
                //lblInternalFileName.Text = ActualfileName;
            }



            if (txtExternalLabSpecimanCount.Text != "")
            {
                accessoriesInspectSystem.ExternalLabSpeciman = Convert.ToInt32(txtExternalLabSpecimanCount.Text);
            }

            accessoriesInspectSystem.ExternalSentToLab = chkExternalSentToLab.Checked == true ? true : false;
            hdnchkExternalSentToLab.Value = chkExternalSentToLab.Checked == true ? "True" : "False";

            //if (chkExternalSentToLab.Checked)
            //{
            //    accessoriesInspectSystem.ExternalSentToLabDate = Convert.ToDateTime(DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss"));
            //}
            if (hdnchkExternalSentToLab.Value == "True" && lblExternalSentToLabDate.Text == "")
            {
                accessoriesInspectSystem.ExternalSentToLabDate = DateTime.Now;
            }
            else
            {
                if (lblExternalSentToLabDate.Text != "")
                {
                    //accessoriesInspectSystem.ExternalSentToLabDate = Convert.ToDateTime(hdnExternalSentToLabDate.Value);
                    accessoriesInspectSystem.ExternalSentToLabDate = (DateTime.ParseExact(lblExternalSentToLabDate.Text, "dd MMM yy (ddd) HH:mm", System.Globalization.CultureInfo.InvariantCulture));
                }
            }

            accessoriesInspectSystem.ExternalReceivedInLab = chkExternalReceivedInLab.Checked == true ? true : false;
            hdnchkExternalReceivedInLab.Value = chkExternalReceivedInLab.Checked == true ? "True" : "False";

            //if (chkExternalReceivedInLab.Checked)
            //{
            //    accessoriesInspectSystem.ExternalReceivedInLabDate = Convert.ToDateTime(DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss"));
            //}

            if (hdnchkExternalReceivedInLab.Value == "True" && lblExternalReceivedInLabDate.Text == "")
            {
                accessoriesInspectSystem.ExternalReceivedInLabDate = DateTime.Now;
            }
            else
            {
                if (lblExternalReceivedInLabDate.Text != "")
                {
                    accessoriesInspectSystem.ExternalReceivedInLabDate = (DateTime.ParseExact(lblExternalReceivedInLabDate.Text, "dd MMM yy (ddd) HH:mm", System.Globalization.CultureInfo.InvariantCulture));
                    //accessoriesInspectSystem.ExternalReceivedInLabDate = Convert.ToDateTime(hdnExternalReceivedInLabDate.Value);
                }
            }

            if (uploadExternalLabReport.HasFile)
            {
                string Exten = System.IO.Path.GetExtension(uploadExternalLabReport.FileName);
                string ActualfileName = "External_Lab_Report_" + uploadExternalLabReport.FileName;
                string Name = ActualfileName.Substring(0, ActualfileName.LastIndexOf('.'));
                ExternalLabReportFileName = FileHelper.SaveFile(uploadExternalLabReport.PostedFile.InputStream, uploadExternalLabReport.FileName, Constants.PHOTO_FOLDER_PATH, true, Name);
                accessoriesInspectSystem.ExternalLabReport = ExternalLabReportFileName;
                hylnkExternalLabReport.Visible = false;

            }

            if (hdnCommercialPass.Value != "1" && hdnFinalPass.Value == "1")
            {
                //FinalDecision = true;

                accessoriesInspectSystem.FinalDecision = 1;
                accessoriesInspectSystem.IsCommercialpass = -1;
            }
            else if (HdnFinalFail.Value == "0")
            {
                accessoriesInspectSystem.FinalDecision = 0;
                accessoriesInspectSystem.IsCommercialpass = -1;
            }
            else
            {

                accessoriesInspectSystem.FinalDecision = -1;
            }
            if (hdnCommercialPass.Value == "1")
            {
                //FinalDecision = false;
                accessoriesInspectSystem.FinalDecision = 1;
                accessoriesInspectSystem.IsCommercialpass = 1;
            }


            //accessoriesInspectSystem.FinalDecision = FinalDecision;

            //accessoriesInspectSystem.FinalDecisionDate = DateTime.Now; //Convert.ToDateTime(lblFinalDecisionDate.Text);

            if (hdnFinalPass.Value == "1" || HdnFinalFail.Value == "1")
            {
                if (lblFinalDecisionDate.Text == "")
                {
                    accessoriesInspectSystem.FinalDecisionDate = DateTime.Now;
                }
                else
                {
                    accessoriesInspectSystem.FinalDecisionDate = (DateTime.ParseExact(lblFinalDecisionDate.Text, "dd MMM yy (ddd) HH:mm", System.Globalization.CultureInfo.InvariantCulture));
                }
            }


            if (txtFailedRaisedDebit.Text != "")
            {
                accessoriesInspectSystem.FailedRaisedDebit = Convert.ToDecimal(txtFailedRaisedDebit.Text.Replace(",", ""));
            }
            if (txtFailedStock.Text != "")
            {
                accessoriesInspectSystem.FailedStock = Convert.ToDecimal(txtFailedStock.Text.Replace(",", ""));
            }
            if (txtFailedGoodStock.Text != "")
            {
                accessoriesInspectSystem.FailedGoodStock = Convert.ToDecimal(txtFailedGoodStock.Text.Replace(",", ""));
            }
            if (txtFailedParticular.Text != "")
            {
                accessoriesInspectSystem.FailedParticular = txtFailedParticular.Text;
            }
            if (txtInspectRaisedDebit.Text != "")
            {
                accessoriesInspectSystem.InspectRaisedDebit = Convert.ToDecimal(txtInspectRaisedDebit.Text.Replace(",", ""));
            }
            if (txtInspectUsableStock.Text != "")
            {
                accessoriesInspectSystem.InspectUsableStock = Convert.ToDecimal(txtInspectUsableStock.Text.Replace(",", ""));
            }
            if (txtInspectParticular.Text != "")
            {
                accessoriesInspectSystem.InspectParticular = txtInspectParticular.Text.Replace(",", "");
            }
            if (lblInspectExtraQty.Text != "")
            {
                accessoriesInspectSystem.TotalExternalQty = Convert.ToDecimal(lblInspectExtraQty.Text.Replace(",", ""));
            }
            else if (lblTotalFailQty.Text != "")
            {


            }
            else
            {
                if (hdnLoginId.Value == "148" && chkAccessoriesQA.Checked) // 148 for accessory QA
                {
                    //accessoriesInspectSystem.IsAccessoryGM = true;
                    //accessoriesInspectSystem.AccessoryGMBy = 2; // for bipl admin
                    //chkAccessoriesGM.Checked = true;
                }

            }

            accessoriesInspectSystem.IsLabManager = chkLabManager.Checked == true ? true : false;
            accessoriesInspectSystem.IsAccessoryGM = chkAccessoriesGM.Checked == true ? true : false;
            accessoriesInspectSystem.IsAccessoryQA = chkAccessoriesQA.Checked == true ? true : false;

            if (chkAccessoriesQA.Checked)
            {
                accessoriesInspectSystem.AccessoryQABy = ApplicationHelper.LoggedInUser.UserData.UserID;
            }
            if (chkAccessoriesGM.Checked && (lblInspectExtraQty.Text != "" || lblTotalFailQty.Text != ""))
            {

                accessoriesInspectSystem.AccessoryGMBy = ApplicationHelper.LoggedInUser.UserData.UserID; // change here 
            }
            if (chkLabManager.Checked)
            {
                accessoriesInspectSystem.LabManagerBy = ApplicationHelper.LoggedInUser.UserData.UserID;
            }

            //new code end

            //if (txtFailedRaisedDebit.Text != "" && txtFailedParticular.Text == "")
            //{
            //    //if (txtFailedParticular.Text == "")
            //    //{
            //        ShowAlert("Particular can't blank!");
            //    //}
            //    return;
            //}

            //if (txtInspectRaisedDebit.Text != "" && txtInspectParticular.Text == "")
            //{
            //    //if (txtInspectParticular.Text == "")
            //    //{
            //        ShowAlert("Particular can't blank!");
            //    //}
            //    return;
            //}

            if (txtCheckerName1.Text == string.Empty)
            {
                ShowAlert("A checker name is mandatory!");
                //txtCheckerName1.Focus();
                txtCheckerName1.Attributes.Add("style", "border-color:red");
                txtCheckerName1.ToolTip = "Atleast one checker is mandatory!";
                return;
            }
            else
            {
                txtCheckerName1.Attributes.Add("style", "border-color:black");
            }
            if (ddlAllocatedUnit.SelectedValue == "-1")
            {
                ShowAlert("Select Allocated Unit!");
                return;
            }


            if (chkLabManager.Checked && lblLabDatetime.Text == "")
            {
                if ((chkInternalSentToLab.Checked && chkExternalSentToLab.Checked) && LabReport == 1)
                {
                    accessoriesInspectSystem.LabManagerApprovedDate = DateTime.Now;
                }
                else if (chkInternalReceivedInLab.Checked && !chkExternalSentToLab.Checked)
                {
                    accessoriesInspectSystem.LabManagerApprovedDate = DateTime.Now;

                }


            }

            if (chkAccessoriesQA.Checked && lblQADatetime.Text == "")
            {
                accessoriesInspectSystem.QAManagerApprovedDate = DateTime.Now;
            }

            if (chkAccessoriesGM.Checked && lblGMDateTime.Text == "")
            {
                accessoriesInspectSystem.GMManagerApprovedDate = DateTime.Now;
            }
            //if(rdybtnCommercialPass.Checked)
            //{
            //    accessoriesInspectSystem.IsCommercialpass = 1;
            //    accessoriesInspectSystem.FinalDecision=1;
            //}
            if (rdyBtnLabDecPassInter.Checked)
            {
                accessoriesInspectSystem.InternalLabDec = 1;
            }
            else if (rdyBtnLabDecFailInter.Checked)
            {
                accessoriesInspectSystem.InternalLabDec = 0;
            }
            else
            {
                accessoriesInspectSystem.InternalLabDec = Convert.ToInt32(hdnintLabDec.Value);
            }
            if (rdyBtnLabDecPassExt.Checked)
            {
                accessoriesInspectSystem.ExternalLabDec = 1;
            }
            else if (rdyBtnLabDecFailExt.Checked)
            {
                accessoriesInspectSystem.ExternalLabDec = 0;
            }
            else
            {
                accessoriesInspectSystem.ExternalLabDec = Convert.ToInt32(hdnExtLabDec.Value);
            }




            //if (txtReceived.Text == string.Empty)
            //{
            //    ShowAlert("Received cannot blank!");
            //    return;
            //}

            //if (txtChecked.Text == string.Empty)
            //{
            //    ShowAlert("Checked cannot blank!");
            //    return;
            //}


            //uncomment after testing start
            //if (accessoriesInspectSystem.RecievedQty > accessoriesInspectSystem.TotalQty)
            //{
            //    ShowAlert("Received quantities cannot greater than total quantity!");
            //    return;
            //}
            //if (accessoriesInspectSystem.CheckedQty > accessoriesInspectSystem.RecievedQty)
            //{
            //    ShowAlert("Checked quantities cannot greater than received quantity!");
            //    return;
            //}
            //if ((accessoriesInspectSystem.PassQty + accessoriesInspectSystem.HoldQty + accessoriesInspectSystem.FailQty) > accessoriesInspectSystem.CheckedQty)
            //{
            //    ShowAlert("(Pass + Fail + Hold) quantities cannot greater than checked quantity!");
            //    return;
            //}
            //uncomment after testing end


            if (chkAccessoriesQA.Checked == true)
            {
                if ((Convert.ToDecimal(txtTotalQuantity.Text.Replace(",", "")) != Convert.ToDecimal(lblTotalActualLength.Text.Replace(",", ""))) && (Convert.ToDecimal(lblTotalClaimedLength.Text.Replace(",", "")) != Convert.ToDecimal(lblTotalActualLength.Text.Replace(",", ""))))
                //if (Convert.ToDecimal(txtTotalQuantity.Text.Replace(",", "")) != Convert.ToDecimal(lblTotalActualLength.Text.Replace(",", "")))
                {
                    //ShowAlert("If actual quantity is greater than claimed quantity then revise SRV get revised.");
                    ShowAlert("If actual quantity and claimed quantity have differences then SRV get revised.");
                }
            }

            if (DeletetedInspectionId.Count > 0)
            {
                for (int i = 0; i < DeletetedInspectionId.Count; i++)
                {
                    int id = DeletetedInspectionId[i];
                    objAccessoryWorking.DeleteInspectionParticular(id);
                }
                DeletetedInspectionId.Clear();
            }

            Table tblgvDetail = (Table)grv_Accessories_Inspection.Controls[0];
            GridViewRow rows = (GridViewRow)tblgvDetail.Controls[0];
            if (grv_Accessories_Inspection.Rows.Count == 0)
            {
                ImageButton btnAdd_Empty = (ImageButton)rows.FindControl("btnAdd_Empty");
                if (AccessoriesInspectionList.Count == 0)
                {
                    btnAdd_Empty.Focus();
                    return;
                }
            }
            if (grv_Accessories_Inspection.Rows.Count > 0)
            {
                ImageButton btnAdd_Footer = grv_Accessories_Inspection.FooterRow.FindControl("btnAdd_Footer") as ImageButton;
                TextBox txtRollNo_Footer = (TextBox)grv_Accessories_Inspection.FooterRow.FindControl("txtRollNo_Footer");
                if (txtRollNo_Footer.Text != string.Empty)
                {
                    btnAdd_Footer.Focus();
                    return;
                }
            }
            //End
            AccessoriesInspect objAccessoriesInspect = objAccessoryWorking.SaveAccessoriesInspection(accessoriesInspectSystem);

            if (AccessoriesInspectionList.Count > 0)
            {
                for (int i = 0; i < AccessoriesInspectionList.Count; i++)
                {
                    AccessoriesInspect accessoriesInspect = AccessoriesInspectionList[i];
                    accessoriesInspect.Inspection_Id = objAccessoriesInspect.Inspection_Id;
                    int InspectionParticularId = objAccessoryWorking.SaveInspectionParticular(accessoriesInspect);
                }
            }
            //objAccessoriesInspect.StockQty = 60;

            if (chkAccessoriesQA.Checked == true)
            {
                if (objAccessoriesInspect.StockQty > 0)
                {
                    //    ExtraQtyId.Attributes.Add("Style", "display: block");
                    if (lblInspectExtraQty.Text == "")
                        lblInspectExtraQty.Text = objAccessoriesInspect.StockQty.ToString() == "0" ? "" : objAccessoriesInspect.StockQty.ToString("N0");
                    else
                        lblInspectExtraQty.Text = (Convert.ToInt32(lblInspectExtraQty.Text.Replace(",", "")) + Convert.ToInt32(objAccessoriesInspect.StockQty.ToString())).ToString("N0");


                    if (lblInspectExtraQty.Text != "")
                    {
                        accessoriesInspectSystem.TotalExternalQty = Convert.ToInt32(lblInspectExtraQty.Text.Replace(",", ""));
                        accessoriesInspectSystem.Comments = "";
                        objAccessoriesInspect = objAccessoryWorking.SaveAccessoriesInspection(accessoriesInspectSystem);
                    }
                    //   AccessoriesInspect objAccessoriesInspect = objAccessoryWorking.SaveAccessoriesInspection(accessoriesInspectSystem);
                    //hdnInspectionId.Value = objAccessoriesInspect.Inspection_Id.ToString();
                    //hdnStockQty.Value = objAccessoriesInspect.StockQty.ToString();
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "ShowDiv(" + objAccessoriesInspect.StockQty + ");", true);
                    //return;
                }
            }

            //BindGridView();
            if (Flag == 1)
            {
                // Response.Redirect(Request.RawUrl);
                string SuccessMessage = string.Empty;
                SuccessMessage = "Save Successfully.";
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('" + SuccessMessage + "');", true);
                Bind();
                // ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "none", "executeAfter();", true);
            }
            else
            {
                if (objAccessoriesInspect.Inspection_Id > 0)
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "err_msg", "closePage();", true);
                }
            }

        }

        public void ShowAlert(string stringAlertMsg)
        {
            string myStringVariable = string.Empty;
            myStringVariable = stringAlertMsg;
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);
        }
    }
}