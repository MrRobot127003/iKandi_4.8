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
using System.Text;
using System.Collections.Generic;
using iKandi.BLL;
using System.Text.RegularExpressions;
using System.Web.Caching;
using iKandi.Common;
using iKandi.Web.Components;
using System.Drawing;


namespace iKandi.Web.Internal.Fabric
{
    public partial class FabricInspectionFourPointCheck : System.Web.UI.Page
    {
        FabricController fabobj = new FabricController();
        PermissionController objPermissionController = new PermissionController();

        public string Userid
        {
            get;
            set;

        }
        public static int SrvID
        {
            get;
            set;

        }
        public static int SupplierPoID
        {
            get;
            set;

        }
        public int Fabric_QualityID
        {
            get;
            set;

        }
        public int SRV_Id
        {
            get;
            set;

        }
        public int Count
        {

            get;
            set;
        }
        public static int FourPointCheck_Id
        {
            get;
            set;

        }
        public static int orderid
        {
            get;
            set;
        }
        public static int OrderDetailID
        {
            get;
            set;
        }
        public int postatus
        {
            get;
            set;
        }

        int RollNumber = 0, DeitLotNumber = 0, Status = -1;
        decimal ClaimedQty = 0, ActualLength = 0, Width_S = 0, Width_M = 0, Width_E = 0, Weaving_1 = 0, Weaving_2 = 0, Weaving_3 = 0, Weaving_4 = 0, total1 = 0, Patta = 0, Hole = 0, total2 = 0, PrintedDefectes_1 = 0, PrintedDefectes_2 = 0, PrintedDefectes_3 = 0, PrintedDefectes_4 = 0, total3 = 0, TotalPoints = 0, WeaPointsPerSquirdYards = 0, CheckedQty = 0, PassQty = 0, HoldQty = 0, FailQty = 0;
        string Statusstring = "";
        int Flag;
        int LabReport;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (iKandi.Web.Components.ApplicationHelper.LoggedInUser == null || iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData == null)
                Response.Redirect("~/public/Login.aspx");

            Userid = iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.UserID.ToString();
            hdnUserid.Value = iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.DesignationID.ToString();
            getquerystring();

            if (!IsPostBack)
            {
                ViewState["viewGrddate"] = null;
                txtdates.Text = DateTime.Today.ToString("dd MMM yy (ddd)");
                BindUnit();
                UserPermission();
                BindBasicSectionFabric();

                if (Flag == 1)
                {
                    Closesbox.Visible = false;
                }

                GetSum();

                //DataTable dtstatus = fabobj.GetRaisedPOWorkingDetails("GETPOSTATUS", "", SupplierPoID).Tables[0];
                DataTable dtstatus = fabobj.GetPOStatus("GETPOSTATUS", SupplierPoID, SrvID).Tables[0];

                if (dtstatus.Rows.Count > 0)
                {
                    postatus = Convert.ToInt32(dtstatus.Rows[0]["postatus"].ToString());
                    //ddlunitname.Enabled = false;
                    //grdfourpointcheck.Enabled = false;
                    //txtReceivedfourpoint.Enabled = false;
                    //txtchecedQtyfourpointchecK.Enabled = false;
                    //txtpassfourpointcheck.Enabled = false;
                    //txtholdfourpointcheck.Enabled = false;
                    //txtfailfourpointcheck.Enabled = false;
                    //btnSubmit.Visible = false;
                    //txtcommentsInput.Enabled = false;

                    //if (Convert.ToBoolean(dtstatus.Rows[0]["IsFabricGMSignatureDone"]))
                    //{
                    //    foreach (Control c in Page.Controls)
                    //    {
                    //        foreach (Control ctrl in c.Controls)
                    //        {
                    //            if (ctrl is TextBox)
                    //                ((TextBox)ctrl).Enabled = false;

                    //        }
                    //    }
                    //}
                }
            }
        }

        private void BindUnit()
        {
            DropdownHelper.BindUnitReports(ddlunitname);
        }

        //public void DisableForm(ControlCollection ctrls)
        //{
        //    foreach (Control ctrl in ctrls)
        //    {
        //        if (ctrl is TextBox)
        //            ((TextBox)ctrl).Enabled = false;
        //        if (ctrl is Button)
        //            ((Button)ctrl).Enabled = false;
        //        else if (ctrl is DropDownList)
        //            ((DropDownList)ctrl).Enabled = false;
        //        else if (ctrl is CheckBox)
        //            ((CheckBox)ctrl).Enabled = false;
        //        else if (ctrl is RadioButton)
        //            ((RadioButton)ctrl).Enabled = false;
        //        else if (ctrl is HtmlInputButton)
        //            ((HtmlInputButton)ctrl).Disabled = true;
        //        else if (ctrl is HtmlInputText)
        //            ((HtmlInputText)ctrl).Disabled = true;
        //        else if (ctrl is HtmlSelect)
        //            ((HtmlSelect)ctrl).Disabled = true;
        //        else if (ctrl is HtmlInputCheckBox)
        //            ((HtmlInputCheckBox)ctrl).Disabled = true;
        //        else if (ctrl is HtmlInputRadioButton)
        //            ((HtmlInputRadioButton)ctrl).Disabled = true;

        //        grdfourpointcheck.Enabled = false;
        //        btnSubmit.Enabled = false;



        //    }
        //}

        private void UserPermission()
        {
            hdnDesignationId.Value= ApplicationHelper.LoggedInUser.UserData.DesignationID.ToString();
            DataTable dtLabspecimen = objPermissionController.GetAccessoryFourPointCheckPermission(ApplicationHelper.LoggedInUser.UserData.PrimaryGroupID, ApplicationHelper.LoggedInUser.UserData.DesignationID, 390).Tables[0];

            if (dtLabspecimen.Rows.Count > 0)
            {
                if (Convert.ToBoolean(dtLabspecimen.Rows[0]["PermisionWrite"]) == true)
                {
                    //txtInternalLabSpecimanCount.Attributes.Add("readonly", "false");
                    //txtExternalLabSpecimanCount.Attributes.Add("readonly", "false");
                    //btnSaveShortfall.Enabled = true;               
                }
                else
                {
                    txtInternalLabSpecimanCount.Attributes.Add("readonly", "readonly");
                    txtExternalLabSpecimanCount.Attributes.Add("readonly", "readonly");
                }
            }

            DataTable dtSentoLab = objPermissionController.GetAccessoryFourPointCheckPermission(ApplicationHelper.LoggedInUser.UserData.PrimaryGroupID, ApplicationHelper.LoggedInUser.UserData.DesignationID, 391).Tables[0];

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

            DataTable dtReceiveInLab = objPermissionController.GetAccessoryFourPointCheckPermission(ApplicationHelper.LoggedInUser.UserData.PrimaryGroupID, ApplicationHelper.LoggedInUser.UserData.DesignationID, 392).Tables[0];

            if (dtReceiveInLab.Rows.Count > 0)
            {
                if (Convert.ToBoolean(dtReceiveInLab.Rows[0]["PermisionWrite"]) == true)
                {
                    //chkInternalReceivedInLab.Attributes.Add("readonly", "false");
                    //chkExternalReceivedInLab.Attributes.Add("readonly", "false");                       
                    chkInternalReceivedInLab.Enabled = true;
                    chkExternalReceivedInLab.Enabled = true;
                }
                else
                {
                    //chkInternalReceivedInLab.Attributes.Add("readonly", "readonly");
                    //chkExternalReceivedInLab.Attributes.Add("readonly", "readonly");
                    chkInternalReceivedInLab.Enabled = false;
                    chkExternalReceivedInLab.Enabled = false;

                }
            }

            DataTable dtLabReport = objPermissionController.GetAccessoryFourPointCheckPermission(ApplicationHelper.LoggedInUser.UserData.PrimaryGroupID, ApplicationHelper.LoggedInUser.UserData.DesignationID, 393).Tables[0];

            if (dtLabReport.Rows.Count > 0)
            {
                if (Convert.ToBoolean(dtLabReport.Rows[0]["PermisionWrite"]) == true)
                {
                    //hylnkInternalLabReportText.Attributes.Add("disabled", "true");
                    //hylnkExternalLabReportText.Attributes.Add("disabled", "true");
                    rdyBtnLabDecFailExt.Enabled = true;
                    rdyBtnLabDecFailInter.Enabled = true;
                    rdyBtnLabDecPassExt.Enabled = true;
                    rdyBtnLabDecPassInter.Enabled = true;

                }
                else
                {
                    hylnkInternalLabReportText.Attributes.Add("onclick", "void(0)");
                    hylnkExternalLabReportText.Attributes.Add("onclick", "void(0)");
                    rdyBtnLabDecFailExt.Enabled = false;
                    rdyBtnLabDecFailInter.Enabled = false;
                    rdyBtnLabDecPassExt.Enabled = false;
                    rdyBtnLabDecPassInter.Enabled = false;
                }

                DataTable dtFinalDecision = objPermissionController.GetAccessoryFourPointCheckPermission(ApplicationHelper.LoggedInUser.UserData.PrimaryGroupID, ApplicationHelper.LoggedInUser.UserData.DesignationID, 394).Tables[0];

                if (dtFinalDecision.Rows.Count > 0)
                {
                    if (Convert.ToBoolean(dtFinalDecision.Rows[0]["PermisionWrite"]) == true)
                    {
                        //rbtFinalDecisionPass.Attributes.Add("readonly", "false");
                        //rbtFinalDecisionFail.Attributes.Add("readonly", "false");
                        rbtFinalDecisionPass.Enabled = true;
                        rbtFinalDecisionFail.Enabled = true;
                        rdybtnComeercialPass.Enabled = true;
                    }
                    else
                    {
                        //rbtFinalDecisionPass.Attributes.Add("readonly", "readonly");
                        //rbtFinalDecisionFail.Attributes.Add("readonly", "readonly");
                        rbtFinalDecisionPass.Enabled = false;
                        rbtFinalDecisionFail.Enabled = false;
                        rdybtnComeercialPass.Enabled = false;

                    }
                }

                DataTable dtFailRaise = objPermissionController.GetAccessoryFourPointCheckPermission(ApplicationHelper.LoggedInUser.UserData.PrimaryGroupID, ApplicationHelper.LoggedInUser.UserData.DesignationID, 395).Tables[0];

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

                DataTable dtFailStock = objPermissionController.GetAccessoryFourPointCheckPermission(ApplicationHelper.LoggedInUser.UserData.PrimaryGroupID, ApplicationHelper.LoggedInUser.UserData.DesignationID, 396).Tables[0];

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

                DataTable dtFailGoodStock = objPermissionController.GetAccessoryFourPointCheckPermission(ApplicationHelper.LoggedInUser.UserData.PrimaryGroupID, ApplicationHelper.LoggedInUser.UserData.DesignationID, 397).Tables[0];

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

                DataTable dtFailParticular = objPermissionController.GetAccessoryFourPointCheckPermission(ApplicationHelper.LoggedInUser.UserData.PrimaryGroupID, ApplicationHelper.LoggedInUser.UserData.DesignationID, 398).Tables[0];

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

                DataTable dtExtraRaise = objPermissionController.GetAccessoryFourPointCheckPermission(ApplicationHelper.LoggedInUser.UserData.PrimaryGroupID, ApplicationHelper.LoggedInUser.UserData.DesignationID, 399).Tables[0];

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

                DataTable dtExtraUsable = objPermissionController.GetAccessoryFourPointCheckPermission(ApplicationHelper.LoggedInUser.UserData.PrimaryGroupID, ApplicationHelper.LoggedInUser.UserData.DesignationID, 400).Tables[0];

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

                DataTable dtExtraParticular = objPermissionController.GetAccessoryFourPointCheckPermission(ApplicationHelper.LoggedInUser.UserData.PrimaryGroupID, ApplicationHelper.LoggedInUser.UserData.DesignationID, 401).Tables[0];

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

                DataTable dtLabMgr = objPermissionController.GetAccessoryFourPointCheckPermission(ApplicationHelper.LoggedInUser.UserData.PrimaryGroupID, ApplicationHelper.LoggedInUser.UserData.DesignationID, 402).Tables[0];

                if (dtLabMgr.Rows.Count > 0)
                {
                    if (Convert.ToBoolean(dtLabMgr.Rows[0]["PermisionWrite"]) == true)
                    {

                        //chkLabManager.Attributes.Add("readonly", "false");
                        if (chkInternalReceivedInLab.Checked && chkExternalReceivedInLab.Checked == false)
                            if (rdyBtnLabDecFailInter.Checked || rdyBtnLabDecPassInter.Checked)
                            {
                                chkLabManager.Enabled = true;
                            }
                            else
                            {
                                chkLabManager.Enabled = false;
                            }
                        else if ((chkInternalReceivedInLab.Checked == false && chkExternalReceivedInLab.Checked))
                        {
                            if (rdyBtnLabDecFailExt.Checked || rdyBtnLabDecPassExt.Checked)
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
                            //if (rdyBtnLabDecFailInter.Checked || rdyBtnLabDecPassInter.Checked && rdyBtnLabDecFailExt.Checked || rdyBtnLabDecPassExt.Checked)
                            //{
                            //    chkLabManager.Enabled = true;
                            //}
                            //else
                            //{
                            //    chkLabManager.Enabled = false;
                            //}

                        }
                    }
                    else
                    {
                        //chkLabManager.Attributes.Add("readonly", "readonly");
                        chkLabManager.Enabled = false;
                    }
                }

                DataTable dtAccQA = objPermissionController.GetAccessoryFourPointCheckPermission(ApplicationHelper.LoggedInUser.UserData.PrimaryGroupID, ApplicationHelper.LoggedInUser.UserData.DesignationID, 403).Tables[0];


                //commented by Girish on 2023-03-10 :Start (Handling On BindBasicSectionFabric() Starting)

                //if (dtAccQA.Rows.Count > 0)
                //{
                //    if (Convert.ToBoolean(dtAccQA.Rows[0]["PermisionWrite"]) == true)
                //    {
                //        //chkAccessoriesQA.Attributes.Add("readonly", "false");
                //        if (rdybtnComeercialPass.Checked == true || rbtFinalDecisionPass.Checked == true || rbtFinalDecisionFail.Checked == true && Convert.ToInt32(hdnUserid.Value) == 148)
                //        {
                //            ChkFabricQa.Enabled = true;

                //        }
                //        else
                //        {
                //            ChkFabricQa.Enabled = false;
                //        }

                //    }
                //    else
                //    {
                //        //chkAccessoriesQA.Attributes.Add("readonly", "readonly");
                //        ChkFabricQa.Enabled = false;
                //    }
                //}

                //commented by Girish on 2023-03-10 :End 


                DataTable dtAccGM = objPermissionController.GetAccessoryFourPointCheckPermission(ApplicationHelper.LoggedInUser.UserData.PrimaryGroupID, ApplicationHelper.LoggedInUser.UserData.DesignationID, 404).Tables[0];

                if (dtAccGM.Rows.Count > 0)
                {
                    if (Convert.ToBoolean(dtAccGM.Rows[0]["PermisionWrite"]) == true)
                    {
                        //chkAccessoriesGM.Attributes.Add("readonly", "false");
                        ChkFabricGM.Enabled = true;

                    }
                    else
                    {
                        //chkAccessoriesGM.Attributes.Add("readonly", "readonly");
                        ChkFabricGM.Enabled = false;
                    }
                }

                DataTable dtRollEntry = objPermissionController.GetAccessoryFourPointCheckPermission(ApplicationHelper.LoggedInUser.UserData.PrimaryGroupID, ApplicationHelper.LoggedInUser.UserData.DesignationID, 405).Tables[0];

                if (dtRollEntry.Rows.Count > 0)
                {
                    if (Convert.ToBoolean(dtRollEntry.Rows[0]["PermisionWrite"]) == true)
                    {
                        grdfourpointcheck.Enabled = true;
                    }
                    else
                    {
                        grdfourpointcheck.Enabled = false;
                    }
                }

                DataTable dtUnit = objPermissionController.GetAccessoryFourPointCheckPermission(ApplicationHelper.LoggedInUser.UserData.PrimaryGroupID, ApplicationHelper.LoggedInUser.UserData.DesignationID, 406).Tables[0];

                if (dtUnit.Rows.Count > 0)
                {
                    if (Convert.ToBoolean(dtUnit.Rows[0]["PermisionWrite"]) == true)
                    {
                        ddlunitname.Enabled = true;
                    }
                    else
                    {
                        ddlunitname.Enabled = false;
                    }
                }

                DataTable dtCheckerName = objPermissionController.GetAccessoryFourPointCheckPermission(ApplicationHelper.LoggedInUser.UserData.PrimaryGroupID, ApplicationHelper.LoggedInUser.UserData.DesignationID, 407).Tables[0];

                if (dtCheckerName.Rows.Count > 0)
                {
                    if (Convert.ToBoolean(dtCheckerName.Rows[0]["PermisionWrite"]) == true)
                    {
                        txtcheckname1.Enabled = true;
                        txtcheckname2.Enabled = true;
                        txtcheckname3.Enabled = true;
                    }
                    else
                    {
                        txtcheckname1.Enabled = false;
                        txtcheckname2.Enabled = false;
                        txtcheckname3.Enabled = false;
                    }
                }

                DataTable dtInspectionDate = objPermissionController.GetAccessoryFourPointCheckPermission(ApplicationHelper.LoggedInUser.UserData.PrimaryGroupID, ApplicationHelper.LoggedInUser.UserData.DesignationID, 408).Tables[0];

                if (dtInspectionDate.Rows.Count > 0)
                {
                    if (Convert.ToBoolean(dtInspectionDate.Rows[0]["PermisionWrite"]) == true)
                    {
                        txtdates.Enabled = true;
                    }
                    else
                    {
                        txtdates.Enabled = false;
                    }
                }
            }
        }

        //public void SetPermission()
        //{
        //    ChkFabricQa.Enabled = false;
        //    // ChkCuttingQA.Enabled = false;
        //    ChkFabricGM.Enabled = false;

        //    if (ApplicationHelper.LoggedInUser.UserData.Designation == Designation.BIPL_FabricQA)
        //    {
        //        ChkFabricQa.Enabled = true;
        //    }
        //    if (ApplicationHelper.LoggedInUser.UserData.Designation == Designation.BIPL_Fabrics_Manager)
        //    {
        //        if (ChkFabricQa.Checked == true)
        //        {
        //            ChkFabricGM.Enabled = true;
        //        }
        //        else
        //        {

        //            ChkFabricGM.Enabled = false;
        //        }
        //    }
        //}



        // [WebMethod(EnableSession = true)]
        //public static void StoreSessionValue(int RollNumber, int DeitLotNumber, int Status,double ClaimedQty, double ActualLength, double CheckedQty, double PassQty, double HoldQty, double FailQty, double Width_S, double Width_M, double Width_E, double Weaving_1, double Weaving_2, double Weaving_3, double Weaving_4, double Patta, double Hole, double PrintedDefectes_1, double PrintedDefectes_2, double PrintedDefectes_3, double PrintedDefectes_4, double WeaPointsPerSquirdYards, double Statusstring)
        //{
        //    //HttpContext.Current.Session["SupplierPO_Id"] = theValue;
        //    ////if (HttpContext.Current.Session["imgurlsset"] == null)
        //    ////{
        //    //HttpContext.Current.Session["imgurlsset"] = imgurl;
        //    ////}
        //}

        public string GetUnitName(string po)
        {
            DataTable dt = fabobj.GetUnitName();

            //DataView dv = new DataView(dt);
            //dv.RowFilter = "(PO_Number == " + po + ")";
            DataRow[] dv = dt.Select("PO_Number = '" + po + "'");

            return dv[0]["UnitsNames"].ToString();
        }

        public bool isQaManagerSignaturedone = false; // added by Girish on 2023-03-13

        public void BindBasicSectionFabric()
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();

            ds = fabobj.GetFabFourPointCheckInsepection("1", SrvID, SupplierPoID, 0, Convert.ToInt32(Userid));
            dt = ds.Tables[0];

            if (dt.Rows.Count > 0)
            {
                // added by Girish on 2023-03-10 :Start
                bool FabricQASignEnabled = Convert.ToBoolean(dt.Rows[0]["FabricQASignEnabled"]);

                if (FabricQASignEnabled)
                {
                    ChkFabricQa.Enabled = true;
                }
                else
                {
                    ChkFabricQa.Enabled = false;
                }

                if (Convert.ToBoolean(dt.Rows[0]["IsFabricQA"]))
                {
                    isQaManagerSignaturedone = true;
                }

                lblExcessQty.Text = dt.Rows[0]["ExcessQty"].ToString() == "0" ? "" : Convert.ToInt32(dt.Rows[0]["ExcessQty"]).ToString("N0");

                if (lblExcessQty.Text == "")
                {
                    spn_ExcessQty.InnerHtml = "";
                }
                else
                {
                    spn_ExcessQty.InnerHtml = "Actual Required Qty.";
                }

                if (dt.Rows[0]["ActualReceivedQty"].ToString() != "")
                {
                    hdnActualReceivedQty.Value = Convert.ToDecimal(dt.Rows[0]["ActualReceivedQty"]).ToString("N0");
                }
                //added by Girish


                if (!string.IsNullOrEmpty(dt.Rows[0]["FourPointCheck_Id"].ToString()))
                    FourPointCheck_Id = Convert.ToInt32(dt.Rows[0]["FourPointCheck_Id"].ToString());
                else
                    FourPointCheck_Id = -1;
                StringBuilder str9 = new StringBuilder();
                str9.Append("<span style='color:blue'>" + dt.Rows[0]["Fabric"].ToString() + "</span> ");
                str9.Append("<span style='color:gray'>(" + dt.Rows[0]["GSM"].ToString() + ")</span> ");
                str9.Append("<span style='color:gray'>" + dt.Rows[0]["CC"].ToString() + "</span> ");
                if (Convert.ToInt32(dt.Rows[0]["CutWidth"]) > 0)
                    str9.Append("<span style='color:gray'>" + dt.Rows[0]["CutWidth"].ToString() + "&quot;</span>");
                // commented by shubhendu 
                //if(Convert.ToInt32(dt.Rows[0]["GriegeWidth"])>0)
                //    str9.Append("<span style='color:gray;font-weight:bold'>" + '(' + dt.Rows[0]["GriegeWidth"].ToString() + ')' + "&quot;</span>");

                //    hylnkInternalLabReportText.HRef = "FileUploadTest.aspx?Type=1&SrvNO=" + SrvID;// shubhendu change date 9/11/2021

                //    = Response.Write("<script type='text/javascript'>window.open('ProductsList.aspx?Type=1&SrvNO=" + SrvID + "','_blank');</script>");

                //  .NavigateUrl= "FileUploadTest.aspx?Type=2&SrvNO=" + SrvID;


                //string url = "FileUploadTest.aspx?Type=1&SrvNO=" + SrvID;
                //string s = "window.open('" + url + "', 'popup_window', 'width=300,height=100,left=100,top=100,resizable=yes');";
                //ClientScript.RegisterStartupScript(this.GetType(), "script", s, true);

                // str9.Append("<span>&quot;</span>");
                lblfab.Text = str9.ToString();
                lblPrintColor.Text = dt.Rows[0]["ColorPrint"].ToString();
                SRVNo.Text = "F-" + dt.Rows[0]["SRVNo"].ToString();
                PartyChallanNo.Text = dt.Rows[0]["PartyChallanNo"].ToString();

                //SRVNo.ToolTip = dt.Rows[0]["Remarks"].ToString();
                lblsrvremarks.Text = dt.Rows[0]["Remarks"].ToString();
                lblSupplierName.Text = dt.Rows[0]["SupplierName"].ToString();
                lblPONo.Text = dt.Rows[0]["PO_Number"].ToString();

                hdnCutWidth.Value = dt.Rows[0]["CutWidth"].ToString();  //new line 
                txtcheckname1.Text = dt.Rows[0]["CheckerName"] == DBNull.Value ? "" : dt.Rows[0]["CheckerName"].ToString();
                lblReceivedQty.Text = dt.Rows[0]["ReceivedQtyPO"].ToString();

                //lblsrvComments.Text = dt.Rows[0]["Remarks"].ToString();
                //new code start 03-02-2021


                //lblWastage.Text = (dt.Rows[0]["GerigeShrinkage"].ToString() == "" || dt.Rows[0]["GerigeShrinkage"].ToString() == "0.00") ? "" : dt.Rows[0]["GerigeShrinkage"].ToString() + "%";
                //lblShrinkage.Text = (dt.Rows[0]["ResidualShrinkage"].ToString() == "" || dt.Rows[0]["ResidualShrinkage"].ToString() == "0.00") ? "" : dt.Rows[0]["ResidualShrinkage"].ToString() + "%";
                if (dt.Rows[0]["SupplyType"].ToString() == "30" || dt.Rows[0]["SupplyType"].ToString() == "31")
                {
                    GreigeShrnk.InnerText = "Wastage: ";
                }
                else
                {
                    GreigeShrnk.InnerText = "Greige Shrnk: ";
                }
                double Average = 0;
                double Number = dt.Rows[0]["GerigeShrinkage"] == DBNull.Value ? 0 : Convert.ToDouble(dt.Rows[0]["GerigeShrinkage"]);
                double afterDecimal = Math.Floor(Number);
                if (afterDecimal > 0)
                    Average = Math.Round(Number, 2);
                else
                    Average = Convert.ToInt32(Number);

                lblWastage.Text = Average == 0 ? "" : Average.ToString() + "%";
                if (lblWastage.Text == "")
                {
                    GreigeShrnk.InnerText = "";
                }


                double Average2 = 0;
                double Number2 = dt.Rows[0]["ResidualShrinkage"] == DBNull.Value ? 0 : Convert.ToDouble(dt.Rows[0]["ResidualShrinkage"]);
                double afterDecimal2 = Math.Floor(Number2);
                if (afterDecimal2 > 0)
                    Average2 = Math.Round(Number2, 2);
                else
                    Average2 = Convert.ToInt32(Number2);

                lblShrinkage.Text = Average2 == 0 ? "" : Average2.ToString() + "%";

                if (lblShrinkage.Text == "")
                {
                    ResidShrnk.InnerText = "";
                }

                if (GreigeShrnk.InnerText == "")
                {
                    if (Flag == 1)
                    {
                        ResidShrnk.Attributes.Remove("ReshShrnk");
                        ResidShrnk.Attributes.Add("class", "ChangePositionReshShrnkFlag");
                        lblShrinkage.Attributes.Add("class", "ChangePositionlblShrinkageFlag");
                    }
                    else
                    {
                        ResidShrnk.Attributes.Remove("ReshShrnk");
                        ResidShrnk.Attributes.Add("class", "ChangePositionReshShrnk");
                        lblShrinkage.Attributes.Add("class", "ChangePositionlblShrinkage");
                    }
                }

                string CurrentStage = dt.Rows[0]["CurrentStage"] == DBNull.Value ? "" : dt.Rows[0]["CurrentStage"].ToString();
                lblStage1.Text = (dt.Rows[0]["stage1"] == DBNull.Value || dt.Rows[0]["stage1"].ToString() == "SELECT") ? "" : dt.Rows[0]["stage1"].ToString();
                lblStage2.Text = (dt.Rows[0]["stage2"] == DBNull.Value || dt.Rows[0]["stage2"].ToString() == "SELECT") ? "" : dt.Rows[0]["stage2"].ToString();
                lblStage3.Text = (dt.Rows[0]["stage3"] == DBNull.Value || dt.Rows[0]["stage3"].ToString() == "SELECT") ? "" : dt.Rows[0]["stage3"].ToString();
                lblStage4.Text = (dt.Rows[0]["stage4"] == DBNull.Value || dt.Rows[0]["stage4"].ToString() == "SELECT") ? "" : dt.Rows[0]["stage4"].ToString();

                if (lblStage1.Text.ToLower() == "griege")
                {
                    lblStage1.Text = "Greige";
                }
                if (lblStage1.Text == CurrentStage || lblStage1.Text == "Greige")
                {
                    lblStage1.Attributes.Add("style", "color:White;margin-right:5px");
                    lblStage2.Attributes.Add("style", "color:#d8d8d8;margin-right:5px");
                    lblStage3.Attributes.Add("style", "color:#d8d8d8;margin-right:5px");
                    lblStage4.Attributes.Add("style", "color:#d8d8d8");

                    if (lblStage1.Text.ToLower() == "finished")
                    {
                        FabricInspectionId.Attributes.Remove("FabricInspection");
                        FabricInspectionId.Attributes.Add("class", "FabricInspectionFinish");
                    }

                }
                if (lblStage2.Text == CurrentStage)
                {
                    lblStage1.Attributes.Add("style", "color:#dacece99;margin-right:5px");
                    lblStage2.Attributes.Add("style", "color:White;margin-right:5px");
                    lblStage3.Attributes.Add("style", "color:#dacece99;margin-right:5px");
                    lblStage4.Attributes.Add("style", "color:#dacece99");
                }
                if (lblStage3.Text == CurrentStage)
                {
                    lblStage1.Attributes.Add("style", "color:#dacece99;margin-right:5px");
                    lblStage2.Attributes.Add("style", "color:#dacece99;margin-right:5px");
                    lblStage3.Attributes.Add("style", "color:White;margin-right:5px");
                    lblStage4.Attributes.Add("style", "color:#dacece99");
                }
                if (lblStage4.Text == CurrentStage)
                {
                    lblStage1.Attributes.Add("style", "color:#dacece99;margin-right:5px");
                    lblStage2.Attributes.Add("style", "color:#dacece99;margin-right:5px");
                    lblStage3.Attributes.Add("style", "color:#dacece99;margin-right:5px");
                    lblStage4.Attributes.Add("style", "color:White");
                }


                txtcheckname2.Text = dt.Rows[0]["CheckerName2"] == DBNull.Value ? "" : dt.Rows[0]["CheckerName2"].ToString();
                txtcheckname3.Text = dt.Rows[0]["CheckerName3"] == DBNull.Value ? "" : dt.Rows[0]["CheckerName3"].ToString();
                txtInternalLabSpecimanCount.Text = (dt.Rows[0]["InterNalLabSpecimenCount"] == DBNull.Value || dt.Rows[0]["InterNalLabSpecimenCount"].ToString() == "0") ? "" : dt.Rows[0]["InterNalLabSpecimenCount"].ToString();
                chkInternalSentToLab.Checked = dt.Rows[0]["InternalIsSentToLab"] == DBNull.Value ? false : Convert.ToBoolean(dt.Rows[0]["InternalIsSentToLab"]);
                lblSerialNumber.Text = dt.Rows[0]["SerailNumber"].ToString();
                hdnchkInternalSentToLab.Value = dt.Rows[0]["InternalIsSentToLab"].ToString();

                if (chkInternalSentToLab.Checked)
                {
                    chkInternalSentToLab.Enabled = false;
                }

                lblInternalSentToLabDate.Text = dt.Rows[0]["InternalSentToLabDate"].ToString();
                hdnInternalSentToLabDate.Value = dt.Rows[0]["InternalSentToLabDate"].ToString();
                chkInternalReceivedInLab.Checked = Convert.ToBoolean(dt.Rows[0]["InternalIsReceivedinLab"]);
                hdnchkInternalReceivedInLab.Value = dt.Rows[0]["InternalIsReceivedinLab"].ToString();

                lblInternalReceivedIndLabDate.Text = dt.Rows[0]["InternalIsReceivedinLabDate"].ToString();
                hdnInternalReceivedInLabDate.Value = dt.Rows[0]["InternalIsReceivedinLabDate"].ToString();

                if (chkInternalReceivedInLab.Checked)
                {
                    chkInternalReceivedInLab.Enabled = false;
                    if (chkLabManager.Checked)
                    {
                        hylnkInternalLabReportText.Attributes.Add("style", "display:none");
                        hylnkInternalLabReportText.Attributes.Add("onclick", "void(0)");
                    }
                }

                if (!string.IsNullOrEmpty(dt.Rows[0]["InternalLabReports"].ToString()))
                {
                    hylnkInternalLabReport.Visible = true;
                    //hylnkInternalLabReport.NavigateUrl = "~/Uploads/Quality/" + dt.Rows[0]["InternalLabReports"].ToString();
                    hdnInternalIsFile.Value = "1";
                }
                else
                {
                    hylnkInternalLabReport.Visible = false;
                    hdnInternalIsFile.Value = "0";
                }

                lblFinalDecisionDate.Text = dt.Rows[0]["FinalDecisionDate"].ToString();
                string FinalDecision = dt.Rows[0]["IsFinalDecision"].ToString();
                string CommercialPass = dt.Rows[0]["IsCommercialPass"].ToString();
                if (FinalDecision == "1" && CommercialPass != "1")
                {
                    rbtFinalDecisionPass.Checked = true;
                    //ChkFabricQa.Enabled = true; //commented by Girish on 2023-03-10 (Handling On Starting)
                    //hdnDecissionPass.Value = "1";
                }
                if (FinalDecision == "0")
                {
                    rbtFinalDecisionFail.Checked = true;
                    //ChkFabricQa.Enabled = true; //commented by Girish on 2023-03-10 (Handling On Starting)
                    //hdnDecissionFail.Value = "1";
                }
                if (CommercialPass == "1" && FinalDecision == "1")
                {
                    rdybtnComeercialPass.Checked = true;
                    //ChkFabricQa.Enabled = true; //commented by Girish on 2023-03-10 (Handling On Starting)
                    //hdnDecissionCommercialpass.Value = "1";
                }
                txtExternalLabSpecimanCount.Text = dt.Rows[0]["ExternalLabSpecimenCount"].ToString() == "0" ? "" : dt.Rows[0]["ExternalLabSpecimenCount"].ToString();
                chkExternalSentToLab.Checked = Convert.ToBoolean(dt.Rows[0]["ExternalIsSentToLab"]);
                hdnchkExternalSentToLab.Value = dt.Rows[0]["ExternalIsSentToLab"].ToString();

                if (chkExternalSentToLab.Checked)
                {
                    chkExternalSentToLab.Enabled = false;
                }

                lblExternalSentToLabDate.Text = dt.Rows[0]["ExternalSentToLabDate"].ToString();
                hdnExternalSentToLabDate.Value = dt.Rows[0]["ExternalSentToLabDate"].ToString();

                chkExternalReceivedInLab.Checked = Convert.ToBoolean(dt.Rows[0]["ExternalIsReceivedinLab"]);
                hdnchkExternalReceivedInLab.Value = dt.Rows[0]["ExternalIsReceivedinLab"].ToString();

                if (chkExternalReceivedInLab.Checked)
                {
                    chkExternalReceivedInLab.Enabled = false;
                    if (chkLabManager.Checked && rdyBtnLabDecPassExt.Checked || rdyBtnLabDecFailExt.Checked)
                    {
                        hylnkExternalLabReportText.Attributes.Add("style", "display:none");
                        hylnkExternalLabReportText.Attributes.Add("onclick", "void(0)");
                    }
                }

                lblExternalReceivedInLabDate.Text = dt.Rows[0]["ExternalIsReceivedinLabDate"].ToString();
                hdnExternalReceivedInLabDate.Value = dt.Rows[0]["ExternalIsReceivedinLabDate"].ToString();

                if (!string.IsNullOrEmpty(dt.Rows[0]["ExternalLabReports"].ToString()))
                {
                    hylnkExternalLabReport.Visible = true;
                    //hylnkExternalLabReport.NavigateUrl = "~/Uploads/Photo/" + dt.Rows[0]["ExternalLabReports"].ToString();
                    hdnExternalIsFile.Value = "1";
                }
                else
                {
                    hylnkExternalLabReport.Visible = false;
                    hdnExternalIsFile.Value = "0";
                }

                // lblTotalFailQty.Text = "0"; //bind total fail quantity on gridbind (pending)
                txtFailedRaisedDebit.Text = dt.Rows[0]["FailRaiseDebit"].ToString() == "0" ? "" : Convert.ToInt32(dt.Rows[0]["FailRaiseDebit"]).ToString("N0");
                txtFailedStock.Text = dt.Rows[0]["FailStock"].ToString() == "0" ? "" : Convert.ToInt32(dt.Rows[0]["FailStock"]).ToString("N0");
                txtFailedGoodStock.Text = dt.Rows[0]["FailGoodStock"].ToString() == "0" ? "" : Convert.ToInt32(dt.Rows[0]["FailGoodStock"]).ToString("N0");


                //added on 2023-25-01 start
                if (!string.IsNullOrEmpty(dt.Rows[0]["FailStockParticular"].ToString()))
                {
                    string[] parts = dt.Rows[0]["FailStockParticular"].ToString().Split(new string[] { SRVNo.Text + " :" }, StringSplitOptions.None);
                    string name = "";
                    if (parts.Length > 1)
                    {
                        name = parts[1];
                    }
                    else
                    {
                        name = parts[0];
                    }
                    txtFailedParticular.Text = name;
                }


                if (!string.IsNullOrEmpty(dt.Rows[0]["InspectParticular"].ToString()))
                {
                    string[] parts = dt.Rows[0]["InspectParticular"].ToString().Split(new string[] { SRVNo.Text + " :" }, StringSplitOptions.None);
                    string name = "";
                    if (parts.Length > 1)
                    {
                        name = parts[1];
                    }
                    else
                    {
                        name = parts[0];
                    }
                    txtInspectParticular.Text = name;
                }
                //added on 2023-25-01 End                

                if (dt.Rows[0]["FailedStockTraced"].ToString() == "1")
                {
                    txtFailedStock.Attributes.Add("style", "background-color:#e4e4e4");
                }

                lblInspectExtraQty.Text = dt.Rows[0]["InspectExtraQty"].ToString() == "0" ? "" : Convert.ToInt32(dt.Rows[0]["InspectExtraQty"]).ToString("N0");
                txtInspectRaisedDebit.Text = dt.Rows[0]["InspectRaiseDebit"].ToString() == "0" ? "" : Convert.ToInt32(dt.Rows[0]["InspectRaiseDebit"]).ToString("N0");
                txtInspectUsableStock.Text = dt.Rows[0]["InspectUsableStock"].ToString() == "0" ? "" : Convert.ToInt32(dt.Rows[0]["InspectUsableStock"]).ToString("N0");



                if (Convert.ToInt16(dt.Rows[0]["internallabDecision"]) == 1)
                {
                    rdyBtnLabDecPassInter.Checked = true;
                    hdnIntPass.Value = "1";
                }
                else if (Convert.ToInt16(dt.Rows[0]["internallabDecision"]) == 0)
                {
                    rdyBtnLabDecFailInter.Checked = true;
                    hdnIntFail.Value = "0";

                }
                if (Convert.ToInt16(dt.Rows[0]["externalLabDecision"]) == 1)
                {

                    rdyBtnLabDecPassExt.Checked = true;
                    hdnExtPass.Value = "1";


                }
                else if (Convert.ToInt16(dt.Rows[0]["externalLabDecision"]) == 0)
                {
                    rdyBtnLabDecFailExt.Checked = true;
                    hdnExtFail.Value = "0";
                }
                if (Convert.ToInt16(dt.Rows[0]["IsCommercialPass"]) == 1)
                {
                    rdybtnComeercialPass.Checked = true;
                    hdnDecissionCommercialpass.Value = "1";

                }
                else
                {
                    rdybtnComeercialPass.Checked = false;


                }
                if (Convert.ToBoolean(dt.Rows[0]["IsLabManager"]) == true && Convert.ToBoolean(dt.Rows[0]["InternalIsSentToLab"]) == true && Convert.ToBoolean(dt.Rows[0]["InternalIsReceivedinLab"]) == false)                         ////////////////
                {
                    //    DataTable IsCheckedDt = new DataTable(); commented by shubhendu
                    //    IsCheckedDt = fabobj.LabManagerChecked(SrvID);
                    //    chkLabManager.Checked = Convert.ToBoolean(IsCheckedDt.Rows[0]["IsLabManager"]);
                    chkLabManager.Checked = true;
                }
                else
                {
                    chkLabManager.Checked = Convert.ToBoolean(dt.Rows[0]["IsLabManager"]);
                }
                if (Convert.ToBoolean(dt.Rows[0]["IsLabManager"]) == true && Convert.ToBoolean(dt.Rows[0]["ExternalIsSentToLab"]) == true && Convert.ToBoolean(dt.Rows[0]["ExternalIsReceivedinLab"]) == false)                         ////////////////
                {
                    //DataTable IsCheckedDt = new DataTable();// commented by shubhendu
                    //IsCheckedDt = fabobj.LabManagerChecked(SrvID);
                    //chkLabManager.Checked = Convert.ToBoolean(IsCheckedDt.Rows[0]["IsLabManager"]);
                    chkLabManager.Checked = true;
                }
                else
                {
                    chkLabManager.Checked = Convert.ToBoolean(dt.Rows[0]["IsLabManager"]);
                }

                // chkLabManager.Checked = Convert.ToBoolean(dt.Rows[0]["isLabManager"]);
                ChkFabricQa.Checked = Convert.ToBoolean(dt.Rows[0]["IsFabricQA"]);
                ChkFabricGM.Checked = Convert.ToBoolean(dt.Rows[0]["IsFabricGM"]);

                if (chkLabManager.Checked)
                {
                    chkLabManager.Enabled = false;
                    lblFabLabManagerName.Attributes.Add("style", "display:''");
                    lblFabLabManagerName.Text = dt.Rows[0]["FabricLabManagerName"].ToString();
                    lblLabDatetime.Attributes.Add("style", "display:''");
                    lblLabDatetime.Text = dt.Rows[0]["LabManagerApprovedDate"].ToString() == "" ? "" : DateTime.Parse(dt.Rows[0]["LabManagerApprovedDate"].ToString()).ToString("dd MMM yy (ddd)");
                }
                hdnLabManager.Value = dt.Rows[0]["IsLabManager"].ToString();
                //hdnGM_Manager.Value = dt.Rows[0]["IsFabricGM"].ToString();
                //hdnQAManager.Value = dt.Rows[0]["IsFabricQA"].ToString();

                if (ApplicationHelper.LoggedInUser.UserData.DesignationID == 15)
                {
                    hdnGM_Manager.Value = "1";
                }
                if (ApplicationHelper.LoggedInUser.UserData.DesignationID == 148)
                {
                    hdnQAManager.Value = "1";
                }

                if (ChkFabricQa.Checked)
                {
                    //ChkFabricQa.Enabled = false;  //commented by Girish (Handling On Starting) (Handling On Starting)
                    lblFabQAName.Attributes.Add("style", "display:''");
                    lblFabQAName.Text = dt.Rows[0]["FabricQAName"].ToString();
                    lblQADatetime.Attributes.Add("style", "display:''");
                    lblQADatetime.Text = dt.Rows[0]["FabricQAUpdatedOn"].ToString() == "" ? "" : DateTime.Parse(dt.Rows[0]["FabricQAUpdatedOn"].ToString()).ToString("dd MMM yy (ddd)");
                    int GoodStock = txtFailedGoodStock.Text.Trim() == "" ? 0 : Convert.ToInt32(txtFailedGoodStock.Text);
                    if (ApplicationHelper.LoggedInUser.UserData.DesignationID == 148 && GoodStock <= 0)
                        btnSubmit.Style.Add("display", "none");

                }

                if (ChkFabricGM.Checked)
                {
                    ChkFabricGM.Enabled = false; //Condition Correct :Girish
                    lblFabGMName.Attributes.Add("style", "display:''");
                    lblFabGMName.Text = dt.Rows[0]["FabricGMName"].ToString();
                    lblGMDateTime.Attributes.Add("style", "display:''");
                    lblGMDateTime.Text = dt.Rows[0]["FabricGMUpdatedOn"].ToString() == "" ? "" : DateTime.Parse(dt.Rows[0]["FabricGMUpdatedOn"].ToString()).ToString("dd MMM yy (ddd)");
                }

                //if (chkLabManager.Checked)
                //{
                //    chkLabManager.Enabled = false;
                //}

                //if (ChkFabricQa.Checked)
                //{
                //    ChkFabricQa.Enabled = false;
                //}

                //if (ChkFabricGM.Checked)
                //{
                //    ChkFabricGM.Enabled = false;
                //}


                if (LabReport == 1)
                {
                    txtInternalLabSpecimanCount.Attributes.Add("readonly", "readonly");
                    chkInternalSentToLab.Enabled = false;
                    chkInternalReceivedInLab.Enabled = false;
                    rdyBtnLabDecPassInter.Enabled = false;
                    rdyBtnLabDecFailInter.Enabled = false;
                    if (chkInternalReceivedInLab.Checked)
                    {
                        if (chkLabManager.Checked)
                        {
                            hylnkInternalLabReportText.Attributes.Add("onclick", "void(0)");
                        }
                        else
                        {
                            // hylnkInternalLabReportText.Visible = true;
                            hylnkInternalLabReportText.Attributes.Add("style", "display:''");
                        }
                    }
                    if (chkExternalReceivedInLab.Checked)
                    {
                        if (chkLabManager.Checked && rdyBtnLabDecPassExt.Checked || rdyBtnLabDecFailExt.Checked)
                        {
                            hylnkExternalLabReportText.Attributes.Add("onclick", "void(0)");
                        }
                        else
                        {
                            hylnkExternalLabReportText.Visible = true;
                            hylnkExternalLabReportText.Attributes.Add("style", "display:''");
                        }
                    }
                    else
                    {
                        //hylnkExternalLabReportText.Visible = false;
                        hylnkExternalLabReportText.Attributes.Add("style", "display:none");
                    }

                }
                if (LabReport == 0)
                {
                    txtExternalLabSpecimanCount.Attributes.Add("readonly", "readonly");
                    chkExternalSentToLab.Enabled = false;
                    chkExternalReceivedInLab.Enabled = false;
                    if (chkExternalReceivedInLab.Checked)
                    {
                        if (chkLabManager.Checked && rdyBtnLabDecPassExt.Checked || rdyBtnLabDecFailExt.Checked)
                        {
                            hylnkExternalLabReportText.Attributes.Add("onclick", "void(0)");
                        }
                        else
                        {
                            hylnkExternalLabReportText.Visible = true;
                            hylnkExternalLabReportText.Attributes.Add("style", "display:''");
                        }
                    }
                    else
                    {
                        // hylnkExternalLabReportText.Visible = false;
                        hylnkExternalLabReportText.Attributes.Add("style", "display:none");
                    }

                    if (chkInternalReceivedInLab.Checked)
                    {
                        if (chkLabManager.Checked)
                        {
                            hylnkInternalLabReportText.Attributes.Add("onclick", "void(0)");
                        }
                        else
                        {
                            //hylnkInternalLabReportText.Visible = true;
                            hylnkInternalLabReportText.Attributes.Add("style", "display:''");
                        }
                    }
                    else
                    {
                        //hylnkInternalLabReportText.Visible = false;
                        hylnkInternalLabReportText.Attributes.Add("style", "display:none");
                    }
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
                //if (dt.Rows[0]["FourPointCheckDate"].ToString() != string.Empty)
                //{
                //    txtdates.Text = Convert.ToDateTime(dt.Rows[0]["FourPointCheckDate"]).ToString("dd MMM yy");
                //}
                //else
                //{
                //    txtdates.Text = DateTime.Now.ToString("dd MMM yy");
                //}
                //new code end 03-02-2021

                if (dt.Rows[0]["InterNalLabSpecimenCount"].ToString() != "" && Convert.ToBoolean(dt.Rows[0]["InternalIsSentToLab"]) == true)
                {
                    chkInternalSentToLab.Attributes.Add("readonly", "readonly");
                    txtInternalLabSpecimanCount.Attributes.Add("readonly", "readonly");
                }

                if (dt.Rows[0]["ExternalLabSpecimenCount"].ToString() != "" && Convert.ToBoolean(dt.Rows[0]["ExternalIsSentToLab"]) == true)
                {
                    chkExternalSentToLab.Attributes.Add("readonly", "readonly");
                    txtExternalLabSpecimanCount.Attributes.Add("readonly", "readonly");
                }

                //if (Convert.ToBoolean(dt.Rows[0]["IsFabricQA"]) == true)
                //{
                //    if (dt.Rows[0]["IsFinalDecision"].ToString() == "1" || dt.Rows[0]["IsFinalDecision"].ToString() == "0")
                //    {
                //        rbtFinalDecisionPass.Enabled = false;
                //        rbtFinalDecisionFail.Enabled = false;
                //    }
                //}

                if (Convert.ToBoolean(dt.Rows[0]["IsFabricGM"]) == true)
                {
                    grdfourpointcheck.Enabled = false;
                    ddlunitname.Enabled = false;
                    txtcheckname1.Attributes.Add("readonly", "readonly");
                    txtcheckname2.Attributes.Add("readonly", "readonly");
                    txtcheckname3.Attributes.Add("readonly", "readonly");
                    rbtFinalDecisionPass.Enabled = false;
                    rbtFinalDecisionFail.Enabled = false;

                    if (((dt.Rows[0]["FailRaiseDebit"].ToString() != "" && dt.Rows[0]["FailRaiseDebit"].ToString() != "0") || (dt.Rows[0]["FailStock"].ToString() != "" && dt.Rows[0]["FailStock"].ToString() != "0") || (dt.Rows[0]["FailGoodStock"].ToString() != "" && dt.Rows[0]["FailGoodStock"].ToString() != "0")))
                    {
                        txtFailedRaisedDebit.Attributes.Add("readonly", "readonly");
                        txtFailedStock.Attributes.Add("readonly", "readonly");
                        txtFailedGoodStock.Attributes.Add("readonly", "readonly");
                        txtFailedParticular.Attributes.Add("readonly", "readonly");
                    }

                    if (((dt.Rows[0]["InspectExtraQty"].ToString() != "" && dt.Rows[0]["InspectExtraQty"].ToString() != "0") || (dt.Rows[0]["InspectRaiseDebit"].ToString() != "" && dt.Rows[0]["InspectRaiseDebit"].ToString() != "0")))
                    {
                        txtInspectRaisedDebit.Attributes.Add("readonly", "readonly");
                        txtInspectUsableStock.Attributes.Add("readonly", "readonly");
                        txtInspectParticular.Attributes.Add("readonly", "readonly");
                    }
                }

                hdnLoginId.Value = ApplicationHelper.LoggedInUser.UserData.DesignationID.ToString();
                if (ApplicationHelper.LoggedInUser.UserData.DesignationID == 40)
                {
                    grdfourpointcheck.Enabled = false;
                }

                dvHistory.InnerHtml = "";
                if (ds.Tables.Count > 1)
                {
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        DataTable dtComment = ds.Tables[1];
                        for (int iComment = 0; iComment < dtComment.Rows.Count; iComment++)
                        {
                            dvHistory.InnerHtml = dvHistory.InnerHtml + "<div class='historyDiv'><span class='CommentBullet'></span>" + dtComment.Rows[iComment]["DetailDescription"].ToString() + "</div>";
                        }
                    }
                }

                //if (LabReport == 0)
                //{
                //    InternalRowId.Attributes.Add("disabled", "disabled");
                //}
                //if (LabReport == 1)
                //{
                //    ExternalRowId.Attributes.Add("disabled", "disabled");
                //}


                //txtcheckname2.Text = dt.Rows[0]["CheckerName2"] == DBNull.Value ? "" : dt.Rows[0]["CheckerName2"].ToString();
                //txtcheckname3.Text = dt.Rows[0]["CheckerName3"] == DBNull.Value ? "" : dt.Rows[0]["CheckerName3"].ToString();


                //txtcheckname1.Text = dt.Rows[0]["CheckerName"].ToString();
                //txtcheckname2.Text = dt.Rows[0]["CheckerName"].ToString();
                //string[] qcname = dt.Rows[0]["CheckerName"].ToString().Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                //if (qcname.Length == 1)
                //{
                //    txtcheckname1.Text = qcname[0].ToString();
                //    txtcheckname2.Text = "";
                //}
                //else if (qcname.Length == 2)
                //{
                //    txtcheckname1.Text = qcname[0].ToString();
                //    txtcheckname2.Text = qcname[1].ToString();
                //}

                if (dt.Rows[0]["FourPointCheckDate"].ToString() != "")
                {
                    txtdates.Text = dt.Rows[0]["FourPointCheckDate"].ToString();
                }
                else
                    txtdates.Text = DateTime.Today.ToString("dd MMM yy (ddd)");

                if (dt.Rows[0]["ReceivedQty"].ToString() != "")
                    lblQty.Text = Convert.ToDecimal(dt.Rows[0]["ReceivedQty"]).ToString("N0");

                lblunitname.Text = " (" + GetUnitName(lblPONo.Text.Trim()) + ")";
                unitName.InnerText = " (" + GetUnitName(lblPONo.Text.Trim()) + ")";
                txtComments.Text = "";

                if (dt.Rows[0]["ReceivedUnit"].ToString() != "")
                    ddlunitname.SelectedValue = dt.Rows[0]["ReceivedUnit"].ToString();

                ds = fabobj.GetFabFourPointCheckInsepection("2", SrvID, SupplierPoID, FourPointCheck_Id, Convert.ToInt32(Userid));
                dt = ds.Tables[0];
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Count = ds.Tables[0].Rows.Count;
                }
                grdfourpointcheck.DataSource = ds.Tables[0];
                grdfourpointcheck.DataBind();

                ViewState["viewGrddate"] = ds.Tables[0];
            }
        }

        public void RebindDataTable()
        {
            DataTable dtnew = (DataTable)(ViewState["viewGrddate"]);
            dtnew.DefaultView.Sort = "ID ASC";


            foreach (GridViewRow grv in grdfourpointcheck.Rows)
            {
                HiddenField hdnrowid = (HiddenField)grv.FindControl("hdnrowid");
                Label lbltotal_item = (Label)grv.FindControl("lbltotal_item");
                Label lblTotal2_item = (Label)grv.FindControl("lblTotal2_item");
                Label lblTotal3_item = (Label)grv.FindControl("lblTotal3_item");
                Label lblpointTotal_item = (Label)grv.FindControl("lblpointTotal_item");
                Label lblweapointyard_item = (Label)grv.FindControl("lblweapointyard_item");
                Label lblstatus_item = (Label)grv.FindControl("lblstatus_item");

                decimal t1 = 0, t2 = 0, t3 = 0, t4 = 0, t5 = 0, t6 = 0;
                if (lbltotal_item.Text != "")
                {
                    t1 = Convert.ToDecimal(lbltotal_item.Text);
                }
                if (lblTotal2_item.Text != "")
                {
                    t2 = Convert.ToDecimal(lblTotal2_item.Text);
                }
                if (lblTotal3_item.Text != "")
                {
                    t3 = Convert.ToDecimal(lblTotal3_item.Text);
                }
                if (lblpointTotal_item.Text != "")
                {
                    t4 = Convert.ToDecimal(lblpointTotal_item.Text);
                }
                if (lblweapointyard_item.Text != "")
                {
                    t5 = Convert.ToDecimal(lblweapointyard_item.Text);
                }
                if (lblweapointyard_item.Text != "")
                {
                    t6 = Convert.ToDecimal(lblweapointyard_item.Text);
                }

                foreach (DataRow dr in dtnew.Rows)
                {
                    if (dr["ID"].ToString() == hdnrowid.Value)
                    {
                        dr["total1"] = Math.Round(t1, 0);
                        dr["total2"] = Math.Round(t2, 0);
                        dr["total3"] = Math.Round(t3, 0);
                        dr["TotalPoints"] = Math.Round(t4, 0);
                        dr["WeaPointsPerSquirdYards"] = Math.Round(t5, 0);
                        break;
                    }
                }
                dtnew.AcceptChanges();
                dtnew.DefaultView.Sort = "ID ASC";
                ViewState["viewGrddate"] = dtnew;

            }
        }

        public void Bindgrd()
        {
            DataTable dt = (DataTable)ViewState["viewGrddate"];
            dt.DefaultView.Sort = "ID asc";
            dt = dt.DefaultView.ToTable();

            if (ViewState["viewGrddate"] != null)
            {
                grdfourpointcheck.DataSource = dt;
                grdfourpointcheck.DataBind();
            }

        }

        public void getquerystring()
        {
            if (Request.QueryString["SrvID"] != null)
            {
                SrvID = Convert.ToInt32(Request.QueryString["SrvID"].ToString());
            }
            if (Request.QueryString["SupplierPoID"] != null)
            {
                SupplierPoID = Convert.ToInt32(Request.QueryString["SupplierPoID"].ToString());
            }
            if (Request.QueryString["orderid"] != null && Request.QueryString["orderid"] != "undefined")

                orderid = Convert.ToInt32(Request.QueryString["orderid"]);
            else
                orderid = -1;

            if (Request.QueryString["OrderDetailID"] != null && Request.QueryString["OrderDetailID"] != "undefined")
                OrderDetailID = Convert.ToInt32(Request.QueryString["OrderDetailID"]);
            else
                OrderDetailID = -1;
            //new code start
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
            //new code end
        }

        protected void OpenWindow(object sender, EventArgs e)
        {
            string url = "FileUploadTest.aspx";
            string s = "window.open('" + url + "', 'popup_window', 'width=300,height=100,left=100,top=100,resizable=yes');";
            ClientScript.RegisterStartupScript(this.GetType(), "script", s, true);
        }

        protected void btnAddFooter_Click(object sender, EventArgs e)
        {
            TextBox txtrollno_Footer = grdfourpointcheck.FooterRow.FindControl("txtrollno_Footer") as TextBox;
            TextBox txtdeilot_Footer = grdfourpointcheck.FooterRow.FindControl("txtdeilot_Footer") as TextBox;
            TextBox txtclaimedlength_Footer = grdfourpointcheck.FooterRow.FindControl("txtclaimedlength_Footer") as TextBox;    //new line
            TextBox txtactlenght_Footer = grdfourpointcheck.FooterRow.FindControl("txtactlenght_Footer") as TextBox;
            TextBox txtwidth_S_Footer = grdfourpointcheck.FooterRow.FindControl("txtwidth_S_Footer") as TextBox;
            TextBox txtwidth_M_Footer = grdfourpointcheck.FooterRow.FindControl("txtwidth_M_Footer") as TextBox;
            TextBox txtwidth_E_Footer = grdfourpointcheck.FooterRow.FindControl("txtwidth_E_Footer") as TextBox;
            TextBox txtwidth_weaving1_Footer = grdfourpointcheck.FooterRow.FindControl("txtwidth_weaving1_Footer") as TextBox;
            TextBox txtwidth_weaving2_Footer = grdfourpointcheck.FooterRow.FindControl("txtwidth_weaving2_Footer") as TextBox;
            TextBox txtwidth_weaving3_Footer = grdfourpointcheck.FooterRow.FindControl("txtwidth_weaving3_Footer") as TextBox;
            TextBox txtwidth_weaving4_Footer = grdfourpointcheck.FooterRow.FindControl("txtwidth_weaving4_Footer") as TextBox;
            TextBox txttotal_Footer = grdfourpointcheck.FooterRow.FindControl("txttotal_Footer") as TextBox;
            TextBox txtpatta_Footer = grdfourpointcheck.FooterRow.FindControl("txtpatta_Footer") as TextBox;
            TextBox txthole_Footer = grdfourpointcheck.FooterRow.FindControl("txthole_Footer") as TextBox;
            TextBox txtTotal2_Footer = grdfourpointcheck.FooterRow.FindControl("txtTotal2_Footer") as TextBox;
            TextBox txtprintdyeingdefacts1_Footer = grdfourpointcheck.FooterRow.FindControl("txtprintdyeingdefacts1_Footer") as TextBox;
            TextBox txtprintdyeingdefacts2_Footer = grdfourpointcheck.FooterRow.FindControl("txtprintdyeingdefacts2_Footer") as TextBox;
            TextBox txtprintdyeingdefacts3_Footer = grdfourpointcheck.FooterRow.FindControl("txtprintdyeingdefacts3_Footer") as TextBox;
            TextBox txtprintdyeingdefacts4_Footer = grdfourpointcheck.FooterRow.FindControl("txtprintdyeingdefacts4_Footer") as TextBox;
            TextBox txtweapointyard_Footer = grdfourpointcheck.FooterRow.FindControl("txtweapointyard_Footer") as TextBox;
            DropDownList ddlstatus_Footer = grdfourpointcheck.FooterRow.FindControl("ddlstatus_Footer") as DropDownList;

            TextBox txtchkd_Footer = grdfourpointcheck.FooterRow.FindControl("txtchkd_Footer") as TextBox;    //new line 02-02-2021
            TextBox txtpass_Footer = grdfourpointcheck.FooterRow.FindControl("txtpass_Footer") as TextBox;    //new line 02-02-2021
            TextBox txthold_Footer = grdfourpointcheck.FooterRow.FindControl("txthold_Footer") as TextBox;    //new line 02-02-2021
            TextBox txtfail_Footer = grdfourpointcheck.FooterRow.FindControl("txtfail_Footer") as TextBox;    //new line 02-02-2021

            DataTable dtnew = new DataTable();

            //new code start 02-02-2021
            if (txtchkd_Footer.Text != "")
            {
                CheckedQty = Convert.ToDecimal(txtchkd_Footer.Text);
            }
            if (txtpass_Footer.Text != "")
            {
                PassQty = Convert.ToDecimal(txtpass_Footer.Text);
            }
            if (txthold_Footer.Text != "")
            {
                HoldQty = Convert.ToDecimal(txthold_Footer.Text);
            }
            if (txtfail_Footer.Text != "")
            {
                FailQty = Convert.ToDecimal(txtfail_Footer.Text);
            }

            //new code end 02-02-2021

            if (txtrollno_Footer.Text != "")
            {
                RollNumber = Convert.ToInt32(txtrollno_Footer.Text);
            }
            if (txtdeilot_Footer.Text != "")
            {
                DeitLotNumber = Convert.ToInt32(txtdeilot_Footer.Text);
            }

            //new code start
            if (txtclaimedlength_Footer.Text != "")
            {
                ClaimedQty = Convert.ToDecimal(txtclaimedlength_Footer.Text);
            }
            //new code end

            if (txtactlenght_Footer.Text != "")
            {
                ActualLength = Convert.ToDecimal(txtactlenght_Footer.Text);
            }
            if (txtwidth_S_Footer.Text != "")
            {
                Width_S = Convert.ToDecimal(txtwidth_S_Footer.Text);
            }
            if (txtwidth_M_Footer.Text != "")
            {
                Width_M = Convert.ToDecimal(txtwidth_M_Footer.Text);
            }
            if (txtwidth_E_Footer.Text != "")
            {
                Width_E = Convert.ToDecimal(txtwidth_E_Footer.Text);
            }
            if (txtwidth_weaving1_Footer.Text != "")
            {
                Weaving_1 = Convert.ToDecimal(txtwidth_weaving1_Footer.Text);
            }
            if (txtwidth_weaving2_Footer.Text != "")
            {
                Weaving_2 = Convert.ToDecimal(txtwidth_weaving2_Footer.Text);
            }
            if (txtwidth_weaving3_Footer.Text != "")
            {
                Weaving_3 = Convert.ToDecimal(txtwidth_weaving3_Footer.Text);
            }
            if (txtwidth_weaving4_Footer.Text != "")
            {
                Weaving_4 = Convert.ToDecimal(txtwidth_weaving4_Footer.Text);
            }
            if (txtpatta_Footer.Text != "")
            {
                Patta = Convert.ToDecimal(txtpatta_Footer.Text);
            }

            if (txthole_Footer.Text != "")
            {
                Hole = Convert.ToDecimal(txthole_Footer.Text);
            }

            if (txtprintdyeingdefacts1_Footer.Text != "")
            {
                PrintedDefectes_1 = Convert.ToDecimal(txtprintdyeingdefacts1_Footer.Text);
            }
            if (txtprintdyeingdefacts2_Footer.Text != "")
            {
                PrintedDefectes_2 = Convert.ToDecimal(txtprintdyeingdefacts2_Footer.Text);
            }
            if (txtprintdyeingdefacts3_Footer.Text != "")
            {
                PrintedDefectes_3 = Convert.ToDecimal(txtprintdyeingdefacts3_Footer.Text);
            }
            if (txtprintdyeingdefacts4_Footer.Text != "")
            {
                PrintedDefectes_4 = Convert.ToDecimal(txtprintdyeingdefacts4_Footer.Text);
            }
            if (txtweapointyard_Footer.Text != "")
            {
                WeaPointsPerSquirdYards = Convert.ToDecimal(txtweapointyard_Footer.Text);
            }
            Status = Convert.ToInt32(ddlstatus_Footer.SelectedValue);
            if (ddlstatus_Footer.SelectedValue == "1")
            {
                Statusstring = "Pass";
            }
            else if (ddlstatus_Footer.SelectedValue == "2")
            {
                Statusstring = "Fail";
            }
            else
            {
                Statusstring = "";
            }

            if (ViewState["viewGrddate"] != null)
            {
                dtnew = (DataTable)(ViewState["viewGrddate"]);
                int i = 0;

                for (; i < grdfourpointcheck.Rows.Count; i++)
                {
                    dtnew.Rows[i]["ID"] = i + 1;
                    dtnew.Rows[i]["FourPointCheck_Parameter"] = -1;
                    dtnew.Rows[i]["FourPointCheck_Id"] = -1;
                    dtnew.Rows[i]["RollNumber"] = Convert.ToInt32(((Label)grdfourpointcheck.Rows[i].FindControl("lblrollno_item")).Text);
                    dtnew.Rows[i]["DeitLotNumber"] = Convert.ToInt32(((Label)grdfourpointcheck.Rows[i].FindControl("lbldeilot_item")).Text);
                    dtnew.Rows[i]["ClaimedQty"] = Convert.ToDecimal(((Label)grdfourpointcheck.Rows[i].FindControl("lblclaimedlength_item")).Text);    //new line
                    dtnew.Rows[i]["ActualLength"] = Convert.ToDecimal(((Label)grdfourpointcheck.Rows[i].FindControl("lblactlenght_item")).Text);
                    dtnew.Rows[i]["Width_S"] = Convert.ToDecimal(((Label)grdfourpointcheck.Rows[i].FindControl("lblwidth_S_item")).Text);
                    dtnew.Rows[i]["Width_M"] = Convert.ToDecimal(((Label)grdfourpointcheck.Rows[i].FindControl("lblwidth_M_item")).Text);
                    dtnew.Rows[i]["Width_E"] = Convert.ToDecimal(((Label)grdfourpointcheck.Rows[i].FindControl("lblwidth_E_item")).Text);
                    dtnew.Rows[i]["Weaving_1"] = Convert.ToDecimal(((Label)grdfourpointcheck.Rows[i].FindControl("lblwidth_weaving1_item")).Text);
                    dtnew.Rows[i]["Weaving_2"] = Convert.ToDecimal(((Label)grdfourpointcheck.Rows[i].FindControl("lblwidth_weaving2_item")).Text);
                    dtnew.Rows[i]["Weaving_3"] = Convert.ToDecimal(((Label)grdfourpointcheck.Rows[i].FindControl("lblwidth_weaving3_item")).Text);
                    dtnew.Rows[i]["Weaving_4"] = Convert.ToDecimal(((Label)grdfourpointcheck.Rows[i].FindControl("lblwidth_weaving4_item")).Text);
                    dtnew.Rows[i]["Patta"] = ((Label)grdfourpointcheck.Rows[i].FindControl("lblpatta_item")).Text;
                    dtnew.Rows[i]["Hole"] = Convert.ToDecimal(((Label)grdfourpointcheck.Rows[i].FindControl("lblhole_item")).Text);
                    dtnew.Rows[i]["PrintedDefectes_1"] = Convert.ToDecimal(((Label)grdfourpointcheck.Rows[i].FindControl("lblprintdyeingdefacts1_item")).Text);
                    dtnew.Rows[i]["PrintedDefectes_2"] = Convert.ToDecimal(((Label)grdfourpointcheck.Rows[i].FindControl("lblprintdyeingdefacts2_item")).Text);
                    dtnew.Rows[i]["PrintedDefectes_3"] = Convert.ToDecimal(((Label)grdfourpointcheck.Rows[i].FindControl("lblprintdyeingdefacts3_item")).Text);
                    dtnew.Rows[i]["PrintedDefectes_4"] = Convert.ToDecimal(((Label)grdfourpointcheck.Rows[i].FindControl("lblprintdyeingdefacts4_item")).Text);
                    dtnew.Rows[i]["WeaPointsPerSquirdYards"] = Convert.ToDecimal(((Label)grdfourpointcheck.Rows[i].FindControl("lblweapointyard_item")).Text);

                    dtnew.Rows[i]["CheckedQty"] = Convert.ToDecimal(((Label)grdfourpointcheck.Rows[i].FindControl("lblchkd_item")).Text);    //new line 02-02-2021
                    dtnew.Rows[i]["PassQty"] = Convert.ToDecimal(((Label)grdfourpointcheck.Rows[i].FindControl("lblpass_item")).Text);    //new line 02-02-2021
                    dtnew.Rows[i]["HoldQty"] = Convert.ToDecimal(((Label)grdfourpointcheck.Rows[i].FindControl("lblhold_item")).Text);    //new line 02-02-2021
                    dtnew.Rows[i]["FailQty"] = Convert.ToDecimal(((Label)grdfourpointcheck.Rows[i].FindControl("lblfail_item")).Text);    //new line 02-02-2021
                    string statuss = "";
                    string statusnarration = "";
                    if (((TextBox)grdfourpointcheck.Rows[i].FindControl("lblstatus_item")).Text == "Pass")
                    {
                        statuss = "1";
                        statusnarration = "Pass";
                    }
                    else if (((TextBox)grdfourpointcheck.Rows[i].FindControl("lblstatus_item")).Text == "Fail")
                    {
                        statuss = "2";
                        statusnarration = "Fail";
                    }
                    else
                    {
                        statuss = "-1";
                    }
                    dtnew.Rows[i]["Status"] = Convert.ToInt32(statuss);
                    dtnew.Rows[i]["Statusstring"] = statusnarration;
                }
                dtnew.AcceptChanges();
                dtnew.Rows.Add(i + 1, -1, -1, RollNumber, DeitLotNumber, ClaimedQty, ActualLength, Width_S, Width_M, Width_E, Weaving_1, Weaving_2, Weaving_3, Weaving_4, Patta, Hole, PrintedDefectes_1, PrintedDefectes_2, PrintedDefectes_3, PrintedDefectes_4, WeaPointsPerSquirdYards, Status, Statusstring, CheckedQty, PassQty, HoldQty, FailQty);
                ViewState["viewGrddate"] = dtnew;
            }
            Bindgrd();
        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            //new work Start:Girish
            GridView gv = (GridView)FindControl("grdfourpointcheck");
            if (gv.Rows.Count == 0)
            {
                Control emptyData = gv.Controls[0].Controls[0];

                TextBox txtrollno_Edit = (TextBox)emptyData.FindControl("txtrollno_emptyrow");
                TextBox txtdeilot_emptyrow = (TextBox)emptyData.FindControl("txtdeilot_emptyrow");

                TextBox txtactlenght_emptyrow = (TextBox)emptyData.FindControl("txtactlenght_emptyrow");
                TextBox txtcheckedlength_emptyrow = (TextBox)emptyData.FindControl("txtcheckedlength_emptyrow");
                TextBox txtpasslength_emptyrow = (TextBox)emptyData.FindControl("txtpasslength_emptyrow");
                TextBox txtholdlength_emptyrow = (TextBox)emptyData.FindControl("txtholdlength_emptyrow");
                TextBox txtfaillength_emptyrow = (TextBox)emptyData.FindControl("txtfaillength_emptyrow");

                TextBox txtwithd_s_emptyrow = (TextBox)emptyData.FindControl("txtwithd_s_emptyrow");

                Dictionary<string, Int32> textBoxes = new Dictionary<string, Int32>();

                textBoxes["RollNo"] = txtrollno_Edit.Text == "" ? 0 : Convert.ToInt32(txtrollno_Edit.Text);
                textBoxes["DyeLot"] = txtdeilot_emptyrow.Text == "" ? 0 : Convert.ToInt32(txtdeilot_emptyrow.Text);
                textBoxes["ActualLength"] = txtactlenght_emptyrow.Text == "" ? 0 : Convert.ToInt32(txtactlenght_emptyrow.Text);
                textBoxes["CheckedLength"] = txtcheckedlength_emptyrow.Text == "" ? 0 : Convert.ToInt32(txtcheckedlength_emptyrow.Text);
                textBoxes["PassLength"] = txtpasslength_emptyrow.Text == "" ? 0 : Convert.ToInt32(txtpasslength_emptyrow.Text);
                textBoxes["HoldLength"] = txtholdlength_emptyrow.Text == "" ? 0 : Convert.ToInt32(txtholdlength_emptyrow.Text);
                textBoxes["FailLength"] = txtfaillength_emptyrow.Text == "" ? 0 : Convert.ToInt32(txtfaillength_emptyrow.Text);
                textBoxes["StartWidth"] = txtwithd_s_emptyrow.Text == "" ? 0 : Convert.ToInt32(txtwithd_s_emptyrow.Text);

                if (textBoxes["RollNo"] > 0 && textBoxes["StartWidth"] > 0)
                {
                    if (textBoxes["DyeLot"] == 0)
                    {
                        ShowAlert("Please Enter Length Of DyeLot.");
                        return;
                    }
                    else if (textBoxes["ActualLength"] == 0)
                    {
                        ShowAlert("Please Enter Actual Length.");
                        return;
                    }
                    else if (textBoxes["CheckedLength"] == 0)
                    {
                        ShowAlert("Please Enter Checked Length.");
                        return;
                    }
                    else if (textBoxes["CheckedLength"] > textBoxes["ActualLength"])
                    {
                        ShowAlert("CheckedLength Cannot be greater than ActualLength.");
                        txtcheckedlength_emptyrow.Text = "";
                        return;
                    }
                    else if (textBoxes["CheckedLength"] != textBoxes["PassLength"] + textBoxes["HoldLength"] + textBoxes["FailLength"])
                    {
                        ShowAlert("(Pass + Fail + Hold) Quantity should be equal Checked Quantity.");
                        txtpasslength_emptyrow.Text = "";
                        txtholdlength_emptyrow.Text = "";
                        txtfaillength_emptyrow.Text = "";
                        return;
                    }
                }
            }
            //new work End:Girish            
            UpdateEntry();
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "AddActualReceivedQty", "AddActualReceivedQty('grdfourpointcheck_ctl04_txtclaimedlength_Edit');", true);

        }

        protected void grdfourpointcheck_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = grdfourpointcheck.Rows[e.RowIndex];
            HiddenField hdnrowid = (HiddenField)row.FindControl("hdnrowid");
            if (ViewState["viewGrddate"] != null)
            {
                DataTable dt = (DataTable)ViewState["viewGrddate"];
                dt.DefaultView.Sort = "ID ASC";

                for (int i = dt.Rows.Count - 1; i >= 0; i--)
                {
                    DataRow dr = dt.Rows[i];
                    if (dr["ID"].ToString() == hdnrowid.Value)
                        dr.Delete();
                }
                dt.AcceptChanges();
                ViewState["viewGrddate"] = dt;
            }
            Bindgrd();
            totalAccInspection.Visible = false;
        }

        decimal totalReceivedQty = 0, totalClaimedQty = 0, totalCheckedQty = 0, totalPassQty = 0, totalHoldQty = 0, totalFailQty = 0;
        int totalRollBox = 0, totalDyeLot = 0;

        protected void grdfourpointcheck_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.Footer)
            {

                LinkButton abtnAdd = (LinkButton)e.Row.FindControl("abtnAdd");
                if (hdnLoginId.Value == "33")
                {

                    abtnAdd.Enabled = false;

                }

            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblrollno_item = (Label)e.Row.FindControl("lblrollno_item");
                Button lnkDelete = (Button)e.Row.FindControl("lnkDelete");
                LinkButton LinkButton1 = (LinkButton)e.Row.FindControl("LinkButton1");

                //added by Girish on 2023-03-13
                if (isQaManagerSignaturedone)
                {
                    LinkButton1.Enabled = false;
                }
                //added by Girish on 2023-03-13


                //if (ChkFabricQa.Checked) // commented by Girrish on 2023-03-13
                //{
                //    LinkButton1.Enabled = false;
                //    lnkDelete.Enabled = false;
                //}


                if (hdnLoginId.Value == "33")
                {
                    lnkDelete.Enabled = false;
                    LinkButton1.Enabled = false;
                }
                if (lblrollno_item != null)
                {
                    Label lbldeilot_item = (Label)e.Row.FindControl("lbldeilot_item");
                    Label lblclaimedlength_item = (Label)e.Row.FindControl("lblclaimedlength_item"); //new line
                    Label lblactlenght_item = (Label)e.Row.FindControl("lblactlenght_item");
                    Label lblwidth_S_item = (Label)e.Row.FindControl("lblwidth_S_item");
                    Label lblwidth_M_item = (Label)e.Row.FindControl("lblwidth_M_item");
                    Label lblwidth_E_item = (Label)e.Row.FindControl("lblwidth_E_item");
                    Label lblwidth_weaving1_item = (Label)e.Row.FindControl("lblwidth_weaving1_item");
                    Label lblwidth_weaving2_item = (Label)e.Row.FindControl("lblwidth_weaving2_item");
                    Label lblwidth_weaving3_item = (Label)e.Row.FindControl("lblwidth_weaving3_item");
                    Label lblwidth_weaving4_item = (Label)e.Row.FindControl("lblwidth_weaving4_item");
                    Label lbltotal_item = (Label)e.Row.FindControl("lbltotal_item");
                    Label lblpatta_item = (Label)e.Row.FindControl("lblpatta_item");
                    Label lblhole_item = (Label)e.Row.FindControl("lblhole_item");
                    Label lblTotal2_item = (Label)e.Row.FindControl("lblTotal2_item");
                    Label lblprintdyeingdefacts1_item = (Label)e.Row.FindControl("lblprintdyeingdefacts1_item");
                    Label lblprintdyeingdefacts2_item = (Label)e.Row.FindControl("lblprintdyeingdefacts2_item");
                    Label lblprintdyeingdefacts3_item = (Label)e.Row.FindControl("lblprintdyeingdefacts3_item");
                    Label lblprintdyeingdefacts4_item = (Label)e.Row.FindControl("lblprintdyeingdefacts4_item");
                    Label lblTotal3_item = (Label)e.Row.FindControl("lblTotal3_item");
                    Label lblpointTotal_item = (Label)e.Row.FindControl("lblpointTotal_item");
                    Label lblweapointyard_item = (Label)e.Row.FindControl("lblweapointyard_item");
                    Label lblstatus_item = (Label)e.Row.FindControl("lblstatus_item");
                    HiddenField hdnrowid = (HiddenField)e.Row.FindControl("hdnrowid");

                    Label lblchkd_item = (Label)e.Row.FindControl("lblchkd_item"); //new line 02-02-2021
                    Label lblpass_item = (Label)e.Row.FindControl("lblpass_item"); //new line 02-02-2021
                    Label lblhold_item = (Label)e.Row.FindControl("lblhold_item"); //new line 02-02-2021
                    Label lblfail_item = (Label)e.Row.FindControl("lblfail_item"); //new line 02-02-2021

                    totalAccInspection.Visible = true; //new line 017-02-2021 added code by bharat

                    if (lbltotal_item.Text == "0")
                    {
                        lbltotal_item.Text = "";
                    }
                    if (lblTotal2_item.Text == "0")
                    {
                        lblTotal2_item.Text = "";
                    }
                    if (lblTotal3_item.Text == "0")
                    {
                        lblTotal3_item.Text = "";
                    }
                    if (lblpointTotal_item.Text == "0")
                    {
                        lblpointTotal_item.Text = "";
                    }
                    if (lblweapointyard_item.Text == "0")
                    {
                        lblweapointyard_item.Text = "";
                    }
                    //new code start
                    //if (lblrollno_item.Text != string.Empty)
                    //{
                    //    totalThaan = totalThaan + Convert.ToInt32(lblrollno_item.Text);
                    //    if (totalThaan == 0)
                    //    {
                    //        lblTotalThaans.Text = "";
                    //    }
                    //    else
                    //    {
                    //        lblTotalThaans.Text = totalThaan.ToString();
                    //    }
                    //    lblTotalThaans.Attributes.Add("style", "color:#000 !important");
                    //}
                    //if (lblactlenght_item.Text != string.Empty)
                    //{
                    //    totalReceivedQty = totalReceivedQty + Convert.ToDecimal(lblactlenght_item.Text);
                    //    if (totalReceivedQty == 0)
                    //    {
                    //        lblTotalActualLength.Text = "";
                    //    }
                    //    else
                    //    {
                    //        lblTotalActualLength.Text = totalReceivedQty.ToString("#,##0");
                    //    }
                    //    lblTotalActualLength.Attributes.Add("style", "color:#000 !important");
                    //    int Quantity = Convert.ToInt32(lblQty.Text.Replace("," , ""));
                    //    int totalActualQuantity = lblTotalActualLength.Text == "" ? 0 : Convert.ToInt32(lblTotalActualLength.Text.Replace(",", ""));
                    //    if (Quantity > totalActualQuantity)
                    //    {
                    //        lblTotalActualLength.Attributes.Add("style", "background-color:#FDFD96");
                    //    }
                    //    else if (Quantity < totalActualQuantity)
                    //    {
                    //        lblTotalActualLength.Attributes.Add("style", "background-color:#FFB7B2");
                    //    }
                    //    else
                    //    {
                    //        lblTotalActualLength.Attributes.Add("style", "background-color:#fff");
                    //    }
                    //}

                    decimal smallWidth = lblwidth_S_item.Text != string.Empty ? Convert.ToDecimal(lblwidth_S_item.Text) : 0;
                    decimal middleWidth = lblwidth_M_item.Text != string.Empty ? Convert.ToDecimal(lblwidth_M_item.Text) : 0;
                    decimal endWidth = lblwidth_E_item.Text != string.Empty ? Convert.ToDecimal(lblwidth_E_item.Text) : 0;
                    decimal cutWidth = hdnCutWidth.Value != string.Empty ? Convert.ToDecimal(hdnCutWidth.Value) : 0;

                    if (smallWidth < cutWidth)
                    {
                        e.Row.Cells[8].Attributes.Add("style", "background-color:#FDFD96");
                    }
                    else if (smallWidth > cutWidth)
                    {
                        e.Row.Cells[8].Attributes.Add("style", "background-color:#FFB7B2");
                    }
                    else
                    {
                        e.Row.Cells[8].Attributes.Add("style", "background-color:#fff");
                    }

                    if (middleWidth < cutWidth)
                    {
                        e.Row.Cells[9].Attributes.Add("style", "background-color:#FDFD96");
                    }
                    else if (middleWidth > cutWidth)
                    {
                        e.Row.Cells[9].Attributes.Add("style", "background-color:#FFB7B2");
                    }
                    else
                    {
                        e.Row.Cells[9].Attributes.Add("style", "background-color:#fff");
                    }

                    if (endWidth < cutWidth)
                    {
                        e.Row.Cells[10].Attributes.Add("style", "background-color:#FDFD96");
                    }
                    else if (endWidth > cutWidth)
                    {
                        e.Row.Cells[10].Attributes.Add("style", "background-color:#FFB7B2");
                    }
                    else
                    {
                        e.Row.Cells[10].Attributes.Add("style", "background-color:#fff");
                    }

                    decimal claimedValue = lblclaimedlength_item.Text != string.Empty ? Convert.ToDecimal(lblclaimedlength_item.Text) : 0;
                    decimal actualValue = lblactlenght_item.Text != string.Empty ? Convert.ToDecimal(lblactlenght_item.Text) : 0;
                    decimal holdValue = lblhold_item.Text != string.Empty ? Convert.ToDecimal(lblhold_item.Text) : 0;
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
                    //new code end

                    //new code 04-02-2021 start



                    totalRollBox = lblrollno_item.Text == "" ? 0 + totalRollBox : Convert.ToInt32(lblrollno_item.Text.Replace(",", "")) + totalRollBox;
                    totalDyeLot = lbldeilot_item.Text == "" ? 0 + totalDyeLot : Convert.ToInt32(lbldeilot_item.Text) + totalDyeLot;
                    totalClaimedQty = lblclaimedlength_item.Text == "" ? 0 + totalClaimedQty : Convert.ToDecimal(lblclaimedlength_item.Text) + totalClaimedQty;
                    totalReceivedQty = lblactlenght_item.Text == "" ? 0 + totalReceivedQty : Convert.ToDecimal(lblactlenght_item.Text) + totalReceivedQty;
                    totalCheckedQty = lblchkd_item.Text == "" ? 0 + totalCheckedQty : Convert.ToDecimal(lblchkd_item.Text) + totalCheckedQty;
                    totalPassQty = lblpass_item.Text == "" ? 0 + totalPassQty : Convert.ToDecimal(lblpass_item.Text) + totalPassQty;
                    totalHoldQty = lblhold_item.Text == "" ? 0 + totalHoldQty : Convert.ToDecimal(lblhold_item.Text) + totalHoldQty;
                    totalFailQty = lblfail_item.Text == "" ? 0 + totalFailQty : Convert.ToDecimal(lblfail_item.Text) + totalFailQty;

                    //totalwidthS = lblwidth_S_item.Text == "" ? 0 + totalwidthS : Convert.ToInt32(lblwidth_S_item.Text) + totalwidthS;
                    //totalwidthM = lblwidth_M_item.Text == "" ? 0 + totalwidthM : Convert.ToInt32(lblwidth_M_item.Text) + totalwidthM;
                    //totalwidthE = lblwidth_E_item.Text == "" ? 0 + totalwidthE : Convert.ToInt32(lblwidth_E_item.Text) + totalwidthE;
                    //totalwidthweaving1 = lblwidth_weaving1_item.Text == "" ? 0 + totalwidthweaving1 : Convert.ToInt32(lblwidth_weaving1_item.Text) + totalwidthweaving1;

                    //totalwidthweaving2 = lblwidth_weaving2_item.Text == "" ? 0 + totalwidthweaving2 : Convert.ToInt32(lblwidth_weaving2_item.Text) + totalwidthweaving2;
                    //totalwidthweaving3 = lblwidth_weaving3_item.Text == "" ? 0 + totalwidthweaving3 : Convert.ToInt32(lblwidth_weaving3_item.Text) + totalwidthweaving3;
                    //totalwidthweaving4 = lblwidth_weaving4_item.Text == "" ? 0 + totalwidthweaving4 : Convert.ToInt32(lblwidth_weaving4_item.Text) + totalwidthweaving4;
                    //totalTotal1 = lbltotal_item.Text == "" ? 0 + totalTotal1 : Convert.ToInt32(lbltotal_item.Text) + totalTotal1;
                    //totalPatta = lblpatta_item.Text == "" ? 0 + totalPatta : Convert.ToInt32(lblpatta_item.Text) + totalPatta;
                    //totalHole = lblhole_item.Text == "" ? 0 + totalHole : Convert.ToInt32(lblhole_item.Text) + totalHole;
                    //totalTotal2 = lblTotal2_item.Text == "" ? 0 + totalTotal2 : Convert.ToInt32(lblTotal2_item.Text) + totalTotal2;
                    //totalpringdyefact1 = lblprintdyeingdefacts1_item.Text == "" ? 0 + totalpringdyefact1 : Convert.ToInt32(lblprintdyeingdefacts1_item.Text) + totalpringdyefact1;
                    //totalpringdyefact2 = lblprintdyeingdefacts2_item.Text == "" ? 0 + totalpringdyefact2 : Convert.ToInt32(lblprintdyeingdefacts2_item.Text) + totalpringdyefact2;
                    //totalpringdyefact3 = lblprintdyeingdefacts3_item.Text == "" ? 0 + totalpringdyefact3 : Convert.ToInt32(lblprintdyeingdefacts3_item.Text) + totalpringdyefact3;
                    //totalpringdyefact4 = lblprintdyeingdefacts4_item.Text == "" ? 0 + totalpringdyefact4 : Convert.ToInt32(lblprintdyeingdefacts4_item.Text) + totalpringdyefact4;
                    //totalTotal3 = lblTotal3_item.Text == "" ? 0 + totalTotal3 : Convert.ToInt32(lblTotal3_item.Text) + totalTotal3;
                    //totalpointTotal = lblpointTotal_item.Text == "" ? 0 + totalpointTotal : Convert.ToInt32(lblpointTotal_item.Text) + totalpointTotal;
                    //totalweapointyard = lblweapointyard_item.Text == "" ? 0 + totalweapointyard : Convert.ToInt32(lblweapointyard_item.Text) + totalweapointyard;
                    // totalFailQty = lblstatus_item.Text == "" ? 0 + totalFailQty : Convert.ToDecimal(lblstatus_item.Text) + totalFailQty;

                    //new code 04-02-2021 end

                    CheckEmpty(lblrollno_item);
                    CheckEmpty(lbldeilot_item);
                    CheckEmpty(lblclaimedlength_item);   //new line
                    CheckEmpty(lblactlenght_item);
                    CheckEmpty(lblwidth_S_item);
                    CheckEmpty(lblwidth_M_item);
                    CheckEmpty(lblwidth_E_item);
                    CheckEmpty(lblwidth_weaving1_item);
                    CheckEmpty(lblwidth_weaving2_item);
                    CheckEmpty(lblwidth_weaving3_item);
                    CheckEmpty(lblwidth_weaving4_item);
                    CheckEmpty(lblpatta_item);
                    CheckEmpty(lblhole_item);
                    CheckEmpty(lblprintdyeingdefacts1_item);
                    CheckEmpty(lblprintdyeingdefacts2_item);
                    CheckEmpty(lblprintdyeingdefacts3_item);
                    CheckEmpty(lblprintdyeingdefacts4_item);
                    CheckEmpty(lblweapointyard_item);
                    CheckEmpty(lbltotal_item);
                    CheckEmpty(lblTotal2_item);
                    CheckEmpty(lblTotal3_item);
                    CheckEmpty(lblpointTotal_item);
                    CheckEmpty(lblchkd_item);   //new line 02-02-2021
                    CheckEmpty(lblpass_item);   //new line 02-02-2021
                    CheckEmpty(lblhold_item);   //new line 02-02-2021
                    CheckEmpty(lblfail_item);   //new line 02-02-2021

                    //new code 13 Jan 2021 start
                    //if (Convert.ToInt32(lbltotal_item.Text) == 0)
                    //{
                    //    lbltotal_item.Text = "";
                    //}
                    //if (Convert.ToInt32(lblTotal2_item.Text) == 0)
                    //{
                    //    lblTotal2_item.Text = "";
                    //}
                    //if (Convert.ToInt32(lblTotal3_item.Text) == 0)
                    //{
                    //    lblTotal3_item.Text = "";
                    //}
                    //new code 13 Jan 2021 end
                }
                else
                {
                    TextBox txtrollno_Edit = e.Row.FindControl("txtrollno_Edit") as TextBox;
                    TextBox txtdeilot_Edit = e.Row.FindControl("txtdeilot_Edit") as TextBox;
                    TextBox txtclaimedlength_Edit = e.Row.FindControl("txtclaimedlength_Edit") as TextBox;  //new line
                    TextBox txtactlenght_Edit = e.Row.FindControl("txtactlenght_Edit") as TextBox;
                    TextBox txtwidth_S_Edit = e.Row.FindControl("txtwidth_S_Edit") as TextBox;
                    TextBox txtwidth_M_Edit = e.Row.FindControl("txtwidth_M_Edit") as TextBox;
                    TextBox txtwidth_E_Edit = e.Row.FindControl("txtwidth_E_Edit") as TextBox;
                    TextBox txtwidth_weaving1_Edit = e.Row.FindControl("txtwidth_weaving1_Edit") as TextBox;
                    TextBox txtwidth_weaving2_Edit = e.Row.FindControl("txtwidth_weaving2_Edit") as TextBox;
                    TextBox txtwidth_weaving3_Edit = e.Row.FindControl("txtwidth_weaving3_Edit") as TextBox;
                    TextBox txtwidth_weaving4_Editv = e.Row.FindControl("txtwidth_weaving4_Edit") as TextBox;
                    TextBox txttotal_Edit = e.Row.FindControl("txttotal_Edit") as TextBox;
                    TextBox txtpatta_Edit = e.Row.FindControl("txtpatta_Edit") as TextBox;
                    TextBox txthole_Edit = e.Row.FindControl("txthole_Edit") as TextBox;
                    TextBox txtTotal2_Edit = e.Row.FindControl("txtTotal2_Edit") as TextBox;
                    TextBox txtprintdyeingdefacts1_Edit = e.Row.FindControl("txtprintdyeingdefacts1_Edit") as TextBox;
                    TextBox txtprintdyeingdefacts2_Edit = e.Row.FindControl("txtprintdyeingdefacts2_Edit") as TextBox;
                    TextBox txtprintdyeingdefacts3_Edit = e.Row.FindControl("txtprintdyeingdefacts3_Edit") as TextBox;
                    TextBox txtprintdyeingdefacts4_Edit = e.Row.FindControl("txtprintdyeingdefacts4_Edit") as TextBox;
                    TextBox txtTotal3_Edit = e.Row.FindControl("txtTotal3_Edit") as TextBox;
                    TextBox txtpointTotal_Edit = e.Row.FindControl("txtpointTotal_Edit") as TextBox;
                    TextBox txtweapointyard_Edit = e.Row.FindControl("txtweapointyard_Edit") as TextBox;
                    DropDownList ddlstatus_Edit = e.Row.FindControl("ddlstatus_Edit") as DropDownList;
                    HiddenField hdmrowidauto = e.Row.FindControl("hdmrowidauto") as HiddenField;

                    TextBox txtchkd_Edit = e.Row.FindControl("txtchkd_Edit") as TextBox;  //new line 02-02-2021
                    TextBox txtpass_Edit = e.Row.FindControl("txtpass_Edit") as TextBox;  //new line 02-02-2021
                    TextBox txthold_Edit = e.Row.FindControl("txthold_Edit") as TextBox;  //new line 02-02-2021
                    TextBox txtfail_Edit = e.Row.FindControl("txtfail_Edit") as TextBox;  //new line 02-02-2021


                    //uncomment after testing start

                    totalRollBox = txtrollno_Edit.Text == "" ? 0 + totalRollBox : Convert.ToInt32(txtrollno_Edit.Text.Replace(",", "")) + totalRollBox;
                    totalDyeLot = txtdeilot_Edit.Text == "" ? 0 + totalDyeLot : Convert.ToInt32(txtdeilot_Edit.Text) + totalDyeLot;
                    totalClaimedQty = txtclaimedlength_Edit.Text == "" ? 0 + totalClaimedQty : Convert.ToDecimal(txtclaimedlength_Edit.Text) + totalClaimedQty;
                    totalReceivedQty = txtactlenght_Edit.Text == "" ? 0 + totalReceivedQty : Convert.ToDecimal(txtactlenght_Edit.Text) + totalReceivedQty;
                    totalCheckedQty = txtchkd_Edit.Text == "" ? 0 + totalCheckedQty : Convert.ToDecimal(txtchkd_Edit.Text) + totalCheckedQty;
                    totalPassQty = txtpass_Edit.Text == "" ? 0 + totalPassQty : Convert.ToDecimal(txtpass_Edit.Text) + totalPassQty;
                    totalHoldQty = txthold_Edit.Text == "" ? 0 + totalHoldQty : Convert.ToDecimal(txthold_Edit.Text) + totalHoldQty;
                    totalFailQty = txtfail_Edit.Text == "" ? 0 + totalFailQty : Convert.ToDecimal(txtfail_Edit.Text) + totalFailQty;

                    //totalwidthS = txtwidth_S_Edit.Text == "" ? 0 + totalwidthS : Convert.ToInt32(txtwidth_S_Edit.Text) + totalwidthS;
                    //totalwidthM = txtwidth_M_Edit.Text == "" ? 0 + totalwidthM : Convert.ToInt32(txtwidth_M_Edit.Text) + totalwidthM;
                    //totalwidthE = txtwidth_E_Edit.Text == "" ? 0 + totalwidthE : Convert.ToInt32(txtwidth_E_Edit.Text) + totalwidthE;
                    //totalwidthweaving1 = txtwidth_weaving1_Edit.Text == "" ? 0 + totalwidthweaving1 : Convert.ToInt32(txtwidth_weaving1_Edit.Text) + totalwidthweaving1;

                    //totalwidthweaving2 = txtwidth_weaving2_Edit.Text == "" ? 0 + totalwidthweaving2 : Convert.ToInt32(txtwidth_weaving2_Edit.Text) + totalwidthweaving2;
                    //totalwidthweaving3 = txtwidth_weaving3_Edit.Text == "" ? 0 + totalwidthweaving3 : Convert.ToInt32(txtwidth_weaving3_Edit.Text) + totalwidthweaving3;
                    //totalwidthweaving4 = txtwidth_weaving4_Editv.Text == "" ? 0 + totalwidthweaving4 : Convert.ToInt32(txtwidth_weaving4_Editv.Text) + totalwidthweaving4;
                    //totalTotal1 = txttotal_Edit.Text == "" ? 0 + totalTotal1 : Convert.ToInt32(txttotal_Edit.Text) + totalTotal1;
                    //totalPatta = txtpatta_Edit.Text == "" ? 0 + totalPatta : Convert.ToInt32(txtpatta_Edit.Text) + totalPatta;
                    //totalHole = txthole_Edit.Text == "" ? 0 + totalHole : Convert.ToInt32(txthole_Edit.Text) + totalHole;
                    //totalTotal2 = txtTotal2_Edit.Text == "" ? 0 + totalTotal2 : Convert.ToInt32(txtTotal2_Edit.Text) + totalTotal2;
                    //totalpringdyefact1 = txtprintdyeingdefacts1_Edit.Text == "" ? 0 + totalpringdyefact1 : Convert.ToInt32(txtprintdyeingdefacts1_Edit.Text) + totalpringdyefact1;
                    //totalpringdyefact2 = txtprintdyeingdefacts2_Edit.Text == "" ? 0 + totalpringdyefact2 : Convert.ToInt32(txtprintdyeingdefacts2_Edit.Text) + totalpringdyefact2;
                    //totalpringdyefact3 = txtprintdyeingdefacts3_Edit.Text == "" ? 0 + totalpringdyefact3 : Convert.ToInt32(txtprintdyeingdefacts3_Edit.Text) + totalpringdyefact3;
                    //totalpringdyefact4 = txtprintdyeingdefacts4_Edit.Text == "" ? 0 + totalpringdyefact4 : Convert.ToInt32(txtprintdyeingdefacts4_Edit.Text) + totalpringdyefact4;
                    //totalTotal3 = txtTotal3_Edit.Text == "" ? 0 + totalTotal3 : Convert.ToInt32(txtTotal3_Edit.Text) + totalTotal3;
                    //totalpointTotal = txtpointTotal_Edit.Text == "" ? 0 + totalpointTotal : Convert.ToInt32(txtpointTotal_Edit.Text) + totalpointTotal;
                    //totalweapointyard = txtweapointyard_Edit.Text == "" ? 0 + totalweapointyard : Convert.ToInt32(txtweapointyard_Edit.Text) + totalweapointyard;

                    //uncomment after testing end

                    CheckEmpty(txtrollno_Edit);
                    CheckEmpty(txtdeilot_Edit);
                    CheckEmpty(txtclaimedlength_Edit);  //new line
                    CheckEmpty(txtactlenght_Edit);
                    CheckEmpty(txtwidth_S_Edit);
                    CheckEmpty(txtwidth_M_Edit);
                    CheckEmpty(txtwidth_E_Edit);
                    CheckEmpty(txtwidth_weaving1_Edit);
                    CheckEmpty(txtwidth_weaving2_Edit);
                    CheckEmpty(txtwidth_weaving3_Edit);
                    CheckEmpty(txtwidth_weaving4_Editv);
                    CheckEmpty(txtpatta_Edit);
                    CheckEmpty(txthole_Edit);
                    CheckEmpty(txtprintdyeingdefacts1_Edit);
                    CheckEmpty(txtprintdyeingdefacts2_Edit);
                    CheckEmpty(txtprintdyeingdefacts3_Edit);
                    CheckEmpty(txtprintdyeingdefacts4_Edit);
                    CheckEmpty(txtweapointyard_Edit);
                    CheckEmpty(txttotal_Edit);
                    CheckEmpty(txtTotal2_Edit);
                    CheckEmpty(txtTotal3_Edit);
                    CheckEmpty(txtpointTotal_Edit);
                    CheckEmpty(txtchkd_Edit);  //new line 02-02-2021
                    CheckEmpty(txtpass_Edit);  //new line 02-02-2021
                    CheckEmpty(txthold_Edit);  //new line 02-02-2021
                    CheckEmpty(txtfail_Edit);  //new line 02-02-2021
                }
            }

            else if (e.Row.RowType == DataControlRowType.DataRow && (e.Row.RowState & DataControlRowState.Edit) == DataControlRowState.Edit)
            {
                TextBox txtrollno_Edit = e.Row.FindControl("txtrollno_Edit") as TextBox;
                TextBox txtdeilot_Edit = e.Row.FindControl("txtdeilot_Edit") as TextBox;
                TextBox txtclaimedlength_Edit = e.Row.FindControl("txtclaimedlength_Edit") as TextBox;  //new line
                TextBox txtactlenght_Edit = e.Row.FindControl("txtactlenght_Edit") as TextBox;
                TextBox txtwidth_S_Edit = e.Row.FindControl("txtwidth_S_Edit") as TextBox;
                TextBox txtwidth_M_Edit = e.Row.FindControl("txtwidth_M_Edit") as TextBox;
                TextBox txtwidth_E_Edit = e.Row.FindControl("txtwidth_E_Edit") as TextBox;
                TextBox txtwidth_weaving1_Edit = e.Row.FindControl("txtwidth_weaving1_Edit") as TextBox;
                TextBox txtwidth_weaving2_Edit = e.Row.FindControl("txtwidth_weaving2_Edit") as TextBox;
                TextBox txtwidth_weaving3_Edit = e.Row.FindControl("txtwidth_weaving3_Edit") as TextBox;
                TextBox txtwidth_weaving4_Editv = e.Row.FindControl("txtwidth_weaving4_Edit") as TextBox;
                TextBox txttotal_Edit = e.Row.FindControl("txttotal_Edit") as TextBox;
                TextBox txtpatta_Edit = e.Row.FindControl("txtpatta_Edit") as TextBox;
                TextBox txthole_Edit = e.Row.FindControl("txthole_Edit") as TextBox;
                TextBox txtTotal2_Edit = e.Row.FindControl("txtTotal2_Edit") as TextBox;
                TextBox txtprintdyeingdefacts1_Edit = e.Row.FindControl("txtprintdyeingdefacts1_Edit") as TextBox;
                TextBox txtprintdyeingdefacts2_Edit = e.Row.FindControl("txtprintdyeingdefacts2_Edit") as TextBox;
                TextBox txtprintdyeingdefacts3_Edit = e.Row.FindControl("txtprintdyeingdefacts3_Edit") as TextBox;
                TextBox txtprintdyeingdefacts4_Edit = e.Row.FindControl("txtprintdyeingdefacts4_Edit") as TextBox;
                TextBox txtTotal3_Edit = e.Row.FindControl("txtTotal3_Edit") as TextBox;
                TextBox txtpointTotal_Edit = e.Row.FindControl("txtpointTotal_Edit") as TextBox;
                TextBox txtweapointyard_Edit = e.Row.FindControl("txtweapointyard_Edit") as TextBox;
                DropDownList ddlstatus_Edit = e.Row.FindControl("ddlstatus_Edit") as DropDownList;
                HiddenField hdmrowidauto = e.Row.FindControl("hdmrowidauto") as HiddenField;

                TextBox txtchkd_Edit = e.Row.FindControl("txtchkd_Edit") as TextBox;  //new line 02-02-2021
                TextBox txtpass_Edit = e.Row.FindControl("txtpass_Edit") as TextBox;  //new line 02-02-2021
                TextBox txthold_Edit = e.Row.FindControl("txthold_Edit") as TextBox;  //new line 02-02-2021
                TextBox txtfail_Edit = e.Row.FindControl("txtfail_Edit") as TextBox;  //new line 02-02-2021

                //uncomment after testing start

                totalRollBox = txtrollno_Edit.Text == "" ? 0 + totalRollBox : Convert.ToInt32(txtrollno_Edit.Text.Replace(",", "")) + totalRollBox;
                totalDyeLot = txtdeilot_Edit.Text == "" ? 0 + totalDyeLot : Convert.ToInt32(txtdeilot_Edit.Text) + totalDyeLot;
                totalClaimedQty = txtclaimedlength_Edit.Text == "" ? 0 + totalClaimedQty : Convert.ToDecimal(txtclaimedlength_Edit.Text) + totalClaimedQty;
                totalReceivedQty = txtactlenght_Edit.Text == "" ? 0 + totalReceivedQty : Convert.ToDecimal(txtactlenght_Edit.Text) + totalReceivedQty;
                totalCheckedQty = txtchkd_Edit.Text == "" ? 0 + totalCheckedQty : Convert.ToDecimal(txtchkd_Edit.Text) + totalCheckedQty;
                totalPassQty = txtpass_Edit.Text == "" ? 0 + totalPassQty : Convert.ToDecimal(txtpass_Edit.Text) + totalPassQty;
                totalHoldQty = txthold_Edit.Text == "" ? 0 + totalHoldQty : Convert.ToDecimal(txthold_Edit.Text) + totalHoldQty;
                totalFailQty = txtfail_Edit.Text == "" ? 0 + totalFailQty : Convert.ToDecimal(txtfail_Edit.Text) + totalFailQty;

                //totalwidthS = txtwidth_S_Edit.Text == "" ? 0 + totalwidthS : Convert.ToInt32(txtwidth_S_Edit.Text) + totalwidthS;
                //totalwidthM = txtwidth_M_Edit.Text == "" ? 0 + totalwidthM : Convert.ToInt32(txtwidth_M_Edit.Text) + totalwidthM;
                //totalwidthE = txtwidth_E_Edit.Text == "" ? 0 + totalwidthE : Convert.ToInt32(txtwidth_E_Edit.Text) + totalwidthE;
                //totalwidthweaving1 = txtwidth_weaving1_Edit.Text == "" ? 0 + totalwidthweaving1 : Convert.ToInt32(txtwidth_weaving1_Edit.Text) + totalwidthweaving1;
                //totalwidthweaving2 = txtwidth_weaving2_Edit.Text == "" ? 0 + totalwidthweaving2 : Convert.ToInt32(txtwidth_weaving2_Edit.Text) + totalwidthweaving2;
                //totalwidthweaving3 = txtwidth_weaving3_Edit.Text == "" ? 0 + totalwidthweaving3 : Convert.ToInt32(txtwidth_weaving3_Edit.Text) + totalwidthweaving3;
                //totalwidthweaving4 = txtwidth_weaving4_Editv.Text == "" ? 0 + totalwidthweaving4 : Convert.ToInt32(txtwidth_weaving4_Editv.Text) + totalwidthweaving4;
                //totalTotal1 = txttotal_Edit.Text == "" ? 0 + totalTotal1 : Convert.ToInt32(txttotal_Edit.Text) + totalTotal1;
                //totalPatta = txtpatta_Edit.Text == "" ? 0 + totalPatta : Convert.ToInt32(txtpatta_Edit.Text) + totalPatta;
                //totalHole = txthole_Edit.Text == "" ? 0 + totalHole : Convert.ToInt32(txthole_Edit.Text) + totalHole;
                //totalTotal2 = txtTotal2_Edit.Text == "" ? 0 + totalTotal2 : Convert.ToInt32(txtTotal2_Edit.Text) + totalTotal2;
                //totalpringdyefact1 = txtprintdyeingdefacts1_Edit.Text == "" ? 0 + totalpringdyefact1 : Convert.ToInt32(txtprintdyeingdefacts1_Edit.Text) + totalpringdyefact1;
                //totalpringdyefact2 = txtprintdyeingdefacts2_Edit.Text == "" ? 0 + totalpringdyefact2 : Convert.ToInt32(txtprintdyeingdefacts2_Edit.Text) + totalpringdyefact2;
                //totalpringdyefact3 = txtprintdyeingdefacts3_Edit.Text == "" ? 0 + totalpringdyefact3 : Convert.ToInt32(txtprintdyeingdefacts3_Edit.Text) + totalpringdyefact3;
                //totalpringdyefact4 = txtprintdyeingdefacts4_Edit.Text == "" ? 0 + totalpringdyefact4 : Convert.ToInt32(txtprintdyeingdefacts4_Edit.Text) + totalpringdyefact4;
                //totalTotal3 = txtTotal3_Edit.Text == "" ? 0 + totalTotal3 : Convert.ToInt32(txtTotal3_Edit.Text) + totalTotal3;
                //totalpointTotal = txtpointTotal_Edit.Text == "" ? 0 + totalpointTotal : Convert.ToInt32(txtpointTotal_Edit.Text) + totalpointTotal;
                //totalweapointyard = txtweapointyard_Edit.Text == "" ? 0 + totalweapointyard : Convert.ToInt32(txtweapointyard_Edit.Text) + totalweapointyard;

                //uncomment after testing end

                CheckEmpty(txtrollno_Edit);
                CheckEmpty(txtdeilot_Edit);
                CheckEmpty(txtclaimedlength_Edit);  //new line
                CheckEmpty(txtactlenght_Edit);
                CheckEmpty(txtwidth_S_Edit);
                CheckEmpty(txtwidth_M_Edit);
                CheckEmpty(txtwidth_E_Edit);
                CheckEmpty(txtwidth_weaving1_Edit);
                CheckEmpty(txtwidth_weaving2_Edit);
                CheckEmpty(txtwidth_weaving3_Edit);
                CheckEmpty(txtwidth_weaving4_Editv);
                CheckEmpty(txtpatta_Edit);
                CheckEmpty(txthole_Edit);
                CheckEmpty(txtprintdyeingdefacts1_Edit);
                CheckEmpty(txtprintdyeingdefacts2_Edit);
                CheckEmpty(txtprintdyeingdefacts3_Edit);
                CheckEmpty(txtprintdyeingdefacts4_Edit);
                CheckEmpty(txtweapointyard_Edit);
                CheckEmpty(txttotal_Edit);
                CheckEmpty(txtTotal2_Edit);
                CheckEmpty(txtTotal3_Edit);
                CheckEmpty(txtpointTotal_Edit);
                CheckEmpty(txtchkd_Edit);  //new line 02-02-2021
                CheckEmpty(txtpass_Edit);  //new line 02-02-2021
                CheckEmpty(txthold_Edit);  //new line 02-02-2021
                CheckEmpty(txtfail_Edit);  //new line 02-02-2021
            }

            lblTotalRollNo.Text = totalRollBox == 0 ? "" : totalRollBox.ToString("N0");
            lblTotalDyedNo.Text = totalDyeLot == 0 ? "" : totalDyeLot.ToString("N0");
            lblTotalClaimedLength.Text = totalClaimedQty == 0 ? "" : totalClaimedQty.ToString("N0");
            lblTotalActualLength.Text = totalReceivedQty == 0 ? "" : totalReceivedQty.ToString("N0");
            lblTotalChecked.Text = totalCheckedQty == 0 ? "" : totalCheckedQty.ToString("N0");
            lblTotalPass.Text = totalPassQty == 0 ? "" : totalPassQty.ToString("N0");
            lblTotalHold.Text = totalHoldQty == 0 ? "" : totalHoldQty.ToString("N0");
            lblTotalFailed.Text = totalFailQty == 0 ? "" : totalFailQty.ToString("N0");
            lblTotalFailQty.Text = totalFailQty == 0 ? "" : totalFailQty.ToString("N0");


            //lblTotalwidth_S_item.Text = totalwidthS == 0 ? "" : totalwidthS.ToString("N0");
            //lblTotalwidth_M_item.Text = totalwidthM == 0 ? "" : totalwidthM.ToString("N0");
            //lblTotalwidth_E_item.Text = totalwidthE == 0 ? "" : totalwidthE.ToString("N0");
            //lblTotalwidth_weaving1_item.Text = totalwidthweaving1 == 0 ? "" : totalwidthweaving1.ToString("N0");
            //lblTotalwidth_weaving2_item.Text = totalwidthweaving2 == 0 ? "" : totalwidthweaving2.ToString("N0");
            //lblTotalwidth_weaving3_item.Text = totalwidthweaving3 == 0 ? "" : totalwidthweaving3.ToString("N0");
            //lblTotalwidth_weaving4_item.Text = totalwidthweaving4 == 0 ? "" : totalwidthweaving4.ToString("N0");
            //lblTotaltotal_item.Text = totalTotal1 == 0 ? "" : totalTotal1.ToString("N0");
            //lblTotalpatta_item.Text = totalPatta == 0 ? "" : totalPatta.ToString("N0");
            //lblTotalhole_item.Text = totalHole == 0 ? "" : totalHole.ToString("N0");
            //lblTotalTotal2_item.Text = totalTotal2 == 0 ? "" : totalTotal2.ToString("N0");
            //lblTotalprintdyeingdefacts1_item.Text = totalpringdyefact1 == 0 ? "" : totalpringdyefact1.ToString("N0");
            //lblTotalprintdyeingdefacts2_item.Text = totalpringdyefact2 == 0 ? "" : totalpringdyefact2.ToString("N0");
            //lblTotalprintdyeingdefacts3_item.Text = totalpringdyefact3 == 0 ? "" : totalpringdyefact3.ToString("N0");
            //lblTotalprintdyeingdefacts4_item.Text = totalpringdyefact4 == 0 ? "" : totalpringdyefact4.ToString("N0");
            //lblTotalTotal3_item.Text = totalTotal3 == 0 ? "" : totalTotal3.ToString("N0");
            //lblTotalpointTotal_item.Text = totalpointTotal == 0 ? "" : totalpointTotal.ToString("N0");
            //lblTotalweapointyard_item.Text = totalweapointyard == 0 ? "" : totalweapointyard.ToString("N0");

            if (totalHoldQty > 0)
            {
                //lblTotalHold.Attributes.Add("style", "background-color:yellow;");
                tdTotalHold.Attributes.Add("style", "background-color:yellow;");
            }

            else
            {
                tdTotalHold.Attributes.Add("style", "background-color:#fff;");
            }

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
                tdTotalHold.Attributes.Add("style", "background-color:yellow;");
            }
            if (totalClaimedQty > totalReceivedQty)
            {
                totalAccInspection.Rows[0].Cells[3].Attributes.Add("style", "background-color:#FDFD96");
            }
            else if (totalClaimedQty < totalReceivedQty)
            {
                totalAccInspection.Rows[0].Cells[3].Attributes.Add("style", "background-color:#FFB7B2");
            }
            else
            {
                totalAccInspection.Rows[0].Cells[3].Attributes.Add("style", "background-color:#fff");
            }
            if (chkInternalReceivedInLab.Checked)
            {
                hylnkInternalLabReportText.Attributes.Add("style", "display:''");
                //hylnkInternalLabReportText.Visible = false;
            }
            else
            {
                hylnkInternalLabReportText.Attributes.Add("style", "display:none");
            }
            if (chkExternalReceivedInLab.Checked)
            {
                hylnkExternalLabReportText.Attributes.Add("style", "display:''");
                //hylnkExternalLabReportText.Visible = false;
            }
            else
            {
                hylnkExternalLabReportText.Attributes.Add("style", "display:none");
            }

        }

        public void CheckEmpty(Control c)
        {
            if (c is Label)
            {
                Label lbl = (Label)c;
                if (lbl != null)
                {
                    if (!string.IsNullOrEmpty(lbl.Text))
                    {
                        //if (Convert.ToDecimal(lbl.Text) <= 0)
                        //{
                        //    lbl.Text = "";
                        //}

                        ////new code start
                        //else
                        //{
                        //    lbl.Text = Convert.ToDecimal(lbl.Text).ToString("#,##0");
                        //}
                        lbl.Text = Convert.ToDecimal(lbl.Text) <= 0 ? "" : Convert.ToDecimal(lbl.Text).ToString("#,##0");
                        //new code end

                    }
                }
            }
            if (c is TextBox)
            {
                TextBox lbl = (TextBox)c;
                if (lbl != null)
                {
                    if (!string.IsNullOrEmpty(lbl.Text))
                    {
                        //if (Convert.ToDecimal(lbl.Text) <= 0)
                        //{
                        //    lbl.Text = "";
                        //}
                        lbl.Text = Convert.ToDecimal(lbl.Text) <= 0 ? "" : Convert.ToDecimal(lbl.Text).ToString("#,##0");

                    }
                }
            }
        }

        protected void grdfourpointcheck_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grdfourpointcheck.EditIndex = -1;
            Bindgrd();
        }

        protected void grdfourpointcheck_RowEditing(object sender, GridViewEditEventArgs e)
        {
            //RebindDataTable();
            grdfourpointcheck.EditIndex = e.NewEditIndex;
            Bindgrd();
            grdfourpointcheck.FooterRow.Visible = false;
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "AddActualReceivedQty", "AddActualReceivedQty('grdfourpointcheck_ctl04_txtclaimedlength_Edit');", true);

        }

        protected void grdfourpointcheck_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (ValidateSRVQty() == false)
            {
                //ShowAlert("Actual Length cannot be greater than total quantity");
                //return;
                //ShowAlert("Please check actual length is greater than total quantity,You need to revise SRV first..");

            }
            //int FourPointCheck_Id = -1, RollNumber = 0, DeitLotNumber = 0, Status = -1;
            // decimal ActualLength = 0, Width_S = 0, Width_M = 0, Width_E = 0, Weaving_1 = 0, Weaving_2 = 0, Weaving_3 = 0, Weaving_4 = 0, Patta = 0, Hole = 0, PrintedDefectes_1 = 0, PrintedDefectes_2 = 0, PrintedDefectes_3 = 0, PrintedDefectes_4 = 0, WeaPointsPerSquirdYards = 0;
            string Statusstring = "";
            if (e.CommandName == "Edit")
            {
            }
            if (e.CommandName == "Insert")
            {
                TextBox txtrollno_Footer = grdfourpointcheck.FooterRow.FindControl("txtrollno_Footer") as TextBox;
                TextBox txtdeilot_Footer = grdfourpointcheck.FooterRow.FindControl("txtdeilot_Footer") as TextBox;
                TextBox txtclaimedlength_Footer = grdfourpointcheck.FooterRow.FindControl("txtclaimedlength_Footer") as TextBox;    //new line
                TextBox txtactlenght_Footer = grdfourpointcheck.FooterRow.FindControl("txtactlenght_Footer") as TextBox;
                TextBox txtwidth_S_Footer = grdfourpointcheck.FooterRow.FindControl("txtwidth_S_Footer") as TextBox;
                TextBox txtwidth_M_Footer = grdfourpointcheck.FooterRow.FindControl("txtwidth_M_Footer") as TextBox;
                TextBox txtwidth_E_Footer = grdfourpointcheck.FooterRow.FindControl("txtwidth_E_Footer") as TextBox;
                TextBox txtwidth_weaving1_Footer = grdfourpointcheck.FooterRow.FindControl("txtwidth_weaving1_Footer") as TextBox;
                TextBox txtwidth_weaving2_Footer = grdfourpointcheck.FooterRow.FindControl("txtwidth_weaving2_Footer") as TextBox;
                TextBox txtwidth_weaving3_Footer = grdfourpointcheck.FooterRow.FindControl("txtwidth_weaving3_Footer") as TextBox;
                TextBox txtwidth_weaving4_Footer = grdfourpointcheck.FooterRow.FindControl("txtwidth_weaving4_Footer") as TextBox;
                TextBox txttotal_Footer = grdfourpointcheck.FooterRow.FindControl("txttotal_Footer") as TextBox;
                TextBox txtpatta_Footer = grdfourpointcheck.FooterRow.FindControl("txtpatta_Footer") as TextBox;
                TextBox txthole_Footer = grdfourpointcheck.FooterRow.FindControl("txthole_Footer") as TextBox;
                TextBox txtTotal2_Footer = grdfourpointcheck.FooterRow.FindControl("txtTotal2_Footer") as TextBox;

                TextBox txtprintdyeingdefacts1_Footer = grdfourpointcheck.FooterRow.FindControl("txtprintdyeingdefacts1_Footer") as TextBox;
                TextBox txtprintdyeingdefacts2_Footer = grdfourpointcheck.FooterRow.FindControl("txtprintdyeingdefacts2_Footer") as TextBox;
                TextBox txtprintdyeingdefacts3_Footer = grdfourpointcheck.FooterRow.FindControl("txtprintdyeingdefacts3_Footer") as TextBox;
                TextBox txtprintdyeingdefacts4_Footer = grdfourpointcheck.FooterRow.FindControl("txtprintdyeingdefacts4_Footer") as TextBox;
                TextBox txtTotal3_Footer = grdfourpointcheck.FooterRow.FindControl("txtTotal3_Footer") as TextBox;
                TextBox txtpointTotal_Footer = grdfourpointcheck.FooterRow.FindControl("txtpointTotal_Footer") as TextBox;
                TextBox txtweapointyard_Footer = grdfourpointcheck.FooterRow.FindControl("txtweapointyard_Footer") as TextBox;
                DropDownList ddlstatus_Footer = grdfourpointcheck.FooterRow.FindControl("ddlstatus_Footer") as DropDownList;
                HiddenField hdmrowidauto_foter = grdfourpointcheck.FooterRow.FindControl("hdmrowidauto_foter") as HiddenField;

                TextBox txtchkd_Footer = grdfourpointcheck.FooterRow.FindControl("txtchkd_Footer") as TextBox;    //new line 02-02-2021
                TextBox txtpass_Footer = grdfourpointcheck.FooterRow.FindControl("txtpass_Footer") as TextBox;    //new line 02-02-2021
                TextBox txthold_Footer = grdfourpointcheck.FooterRow.FindControl("txthold_Footer") as TextBox;    //new line 02-02-2021
                TextBox txtfail_Footer = grdfourpointcheck.FooterRow.FindControl("txtfail_Footer") as TextBox;    //new line 02-02-2021

                if (txtrollno_Footer.Text == string.Empty)
                {
                    ShowAlert("Roll/Box No. can't blank!");
                    return;
                }
                if (txtdeilot_Footer.Text == string.Empty)
                {
                    ShowAlert("Dyed Lot can't blank!");
                    return;
                }

                if (txtclaimedlength_Footer.Text == string.Empty)
                {
                    ShowAlert("Claimed Length can't blank!");
                    return;
                }

                if (txtactlenght_Footer.Text == string.Empty)
                {
                    ShowAlert("Actual Length can't blank!");
                    return;
                }
                if (txtchkd_Footer.Text == string.Empty)
                {
                    ShowAlert("Checked Quantity can't blank!");
                    return;
                }
                if (Convert.ToInt32(txtchkd_Footer.Text) > Convert.ToInt32(txtactlenght_Footer.Text))
                {
                    ShowAlert("Checked Quantity can't be greater than Actual Length!");
                    return;
                }
                int passQty = txtpass_Footer.Text == string.Empty ? 0 : Convert.ToInt32(txtpass_Footer.Text);
                int failQty = txtfail_Footer.Text == string.Empty ? 0 : Convert.ToInt32(txtfail_Footer.Text);
                int holdQty = txthold_Footer.Text == string.Empty ? 0 : Convert.ToInt32(txthold_Footer.Text);
                int checkedQty = txtchkd_Footer.Text == string.Empty ? 0 : Convert.ToInt32(txtchkd_Footer.Text);
                if (passQty + failQty + holdQty != checkedQty)
                {
                    ShowAlert("(Pass + Fail + Hold) Quantity should be equal to Checked Quantity!");
                    return;
                }

                DataTable dtnew = new DataTable();
                FourPointCheck_Id = -1;

                //new code start 02-02-2021
                if (txtchkd_Footer.Text != "")
                {
                    CheckedQty = Convert.ToDecimal(txtchkd_Footer.Text);
                }
                if (txtpass_Footer.Text != "")
                {
                    PassQty = Convert.ToDecimal(txtpass_Footer.Text);
                }
                if (txthold_Footer.Text != "")
                {
                    HoldQty = Convert.ToDecimal(txthold_Footer.Text);
                }
                if (txtfail_Footer.Text != "")
                {
                    FailQty = Convert.ToDecimal(txtfail_Footer.Text);
                }
                //new code end 02-02-2021

                if (txtrollno_Footer.Text != "")
                {
                    RollNumber = Convert.ToInt32(txtrollno_Footer.Text);
                }
                if (txtdeilot_Footer.Text != "")
                {
                    DeitLotNumber = Convert.ToInt32(txtdeilot_Footer.Text);
                }

                //new code start
                if (txtclaimedlength_Footer.Text != "")
                {
                    ClaimedQty = Convert.ToDecimal(txtclaimedlength_Footer.Text);
                }
                //new code end

                if (txtactlenght_Footer.Text != "")
                {
                    ActualLength = Convert.ToDecimal(txtactlenght_Footer.Text);
                }
                if (txtwidth_S_Footer.Text != "")
                {
                    Width_S = Convert.ToDecimal(txtwidth_S_Footer.Text);
                }
                if (txtwidth_M_Footer.Text != "")
                {
                    Width_M = Convert.ToDecimal(txtwidth_M_Footer.Text);
                }
                if (txtwidth_E_Footer.Text != "")
                {
                    Width_E = Convert.ToDecimal(txtwidth_E_Footer.Text);
                }
                if (txtwidth_weaving1_Footer.Text != "")
                {
                    Weaving_1 = Convert.ToDecimal(txtwidth_weaving1_Footer.Text);
                }
                if (txtwidth_weaving2_Footer.Text != "")
                {
                    Weaving_2 = Convert.ToDecimal(txtwidth_weaving2_Footer.Text);
                }
                if (txtwidth_weaving3_Footer.Text != "")
                {
                    Weaving_3 = Convert.ToDecimal(txtwidth_weaving3_Footer.Text);
                }
                if (txtwidth_weaving4_Footer.Text != "")
                {
                    Weaving_4 = Convert.ToDecimal(txtwidth_weaving4_Footer.Text);
                }
                if (txttotal_Footer.Text != "")
                {
                    total1 = Convert.ToDecimal(txttotal_Footer.Text);
                }
                if (txtpatta_Footer.Text != "")
                {
                    Patta = Convert.ToDecimal(txtpatta_Footer.Text);
                }

                if (txthole_Footer.Text != "")
                {
                    Hole = Convert.ToDecimal(txthole_Footer.Text);
                }
                if (txtTotal2_Footer.Text != "")
                {
                    total2 = Convert.ToDecimal(txtTotal2_Footer.Text);
                }
                if (txtprintdyeingdefacts1_Footer.Text != "")
                {
                    PrintedDefectes_1 = Convert.ToDecimal(txtprintdyeingdefacts1_Footer.Text);
                }
                if (txtprintdyeingdefacts2_Footer.Text != "")
                {
                    PrintedDefectes_2 = Convert.ToDecimal(txtprintdyeingdefacts2_Footer.Text);
                }
                if (txtprintdyeingdefacts3_Footer.Text != "")
                {
                    PrintedDefectes_3 = Convert.ToDecimal(txtprintdyeingdefacts3_Footer.Text);
                }
                if (txtprintdyeingdefacts4_Footer.Text != "")
                {
                    PrintedDefectes_4 = Convert.ToDecimal(txtprintdyeingdefacts4_Footer.Text);
                }
                if (txtweapointyard_Footer.Text != "")
                {
                    WeaPointsPerSquirdYards = Convert.ToDecimal(txtweapointyard_Footer.Text);
                }
                if (txtTotal3_Footer.Text != "")
                {
                    total3 = Convert.ToDecimal(txtTotal3_Footer.Text);
                }
                if (txtpointTotal_Footer.Text != "")
                {
                    TotalPoints = Convert.ToDecimal(txtpointTotal_Footer.Text);
                }
                Status = Convert.ToInt32(ddlstatus_Footer.SelectedValue);
                if (ddlstatus_Footer.SelectedValue == "1")
                {
                    Statusstring = "Pass";
                }
                else if (ddlstatus_Footer.SelectedValue == "2")
                {
                    Statusstring = "Fail";
                }
                else
                {
                    Statusstring = "";
                }



                if (ViewState["viewGrddate"] != null)
                {
                    dtnew = (DataTable)(ViewState["viewGrddate"]);
                    int i = 0;
                    for (; i < grdfourpointcheck.Rows.Count; i++)
                    {
                        dtnew.Rows[i]["ID"] = i + 1;
                        dtnew.Rows[i]["FourPointCheck_Parameter"] = -1;
                        dtnew.Rows[i]["FourPointCheck_Id"] = -1;
                        if (((Label)grdfourpointcheck.Rows[i].FindControl("lblrollno_item")).Text != "")
                        {
                            dtnew.Rows[i]["RollNumber"] = Convert.ToInt32(((Label)grdfourpointcheck.Rows[i].FindControl("lblrollno_item")).Text);
                        }
                        if (((Label)grdfourpointcheck.Rows[i].FindControl("lbldeilot_item")).Text != "")
                        {
                            dtnew.Rows[i]["DeitLotNumber"] = Convert.ToInt32(((Label)grdfourpointcheck.Rows[i].FindControl("lbldeilot_item")).Text);
                        }
                        //new code start
                        if (((Label)grdfourpointcheck.Rows[i].FindControl("lblclaimedlength_item")).Text != "")
                        {
                            dtnew.Rows[i]["ClaimedQty"] = Convert.ToDecimal(((Label)grdfourpointcheck.Rows[i].FindControl("lblclaimedlength_item")).Text);
                        }
                        //new code end
                        if (((Label)grdfourpointcheck.Rows[i].FindControl("lblactlenght_item")).Text != "")
                        {
                            dtnew.Rows[i]["ActualLength"] = Convert.ToDecimal(((Label)grdfourpointcheck.Rows[i].FindControl("lblactlenght_item")).Text);
                        }

                        //new code start 02-02-2021
                        if (((Label)grdfourpointcheck.Rows[i].FindControl("lblchkd_item")).Text != "")
                        {
                            dtnew.Rows[i]["CheckedQty"] = Convert.ToDecimal(((Label)grdfourpointcheck.Rows[i].FindControl("lblchkd_item")).Text);
                        }
                        if (((Label)grdfourpointcheck.Rows[i].FindControl("lblpass_item")).Text != "")
                        {
                            dtnew.Rows[i]["PassQty"] = Convert.ToDecimal(((Label)grdfourpointcheck.Rows[i].FindControl("lblpass_item")).Text);
                        }
                        if (((Label)grdfourpointcheck.Rows[i].FindControl("lblhold_item")).Text != "")
                        {
                            dtnew.Rows[i]["HoldQty"] = Convert.ToDecimal(((Label)grdfourpointcheck.Rows[i].FindControl("lblhold_item")).Text);
                        }
                        if (((Label)grdfourpointcheck.Rows[i].FindControl("lblfail_item")).Text != "")
                        {
                            dtnew.Rows[i]["FailQty"] = Convert.ToDecimal(((Label)grdfourpointcheck.Rows[i].FindControl("lblfail_item")).Text);
                        }

                        //new code end 02-02-2021

                        if (((Label)grdfourpointcheck.Rows[i].FindControl("lblwidth_S_item")).Text != "")
                        {
                            dtnew.Rows[i]["Width_S"] = Convert.ToDecimal(((Label)grdfourpointcheck.Rows[i].FindControl("lblwidth_S_item")).Text);
                        }
                        if (((Label)grdfourpointcheck.Rows[i].FindControl("lblwidth_M_item")).Text != "")
                        {
                            dtnew.Rows[i]["Width_M"] = Convert.ToDecimal(((Label)grdfourpointcheck.Rows[i].FindControl("lblwidth_M_item")).Text);
                        }
                        if (((Label)grdfourpointcheck.Rows[i].FindControl("lblwidth_E_item")).Text != "")
                        {
                            dtnew.Rows[i]["Width_E"] = Convert.ToDecimal(((Label)grdfourpointcheck.Rows[i].FindControl("lblwidth_E_item")).Text);
                        }
                        if (((Label)grdfourpointcheck.Rows[i].FindControl("lblwidth_weaving1_item")).Text != "")
                        {
                            dtnew.Rows[i]["Weaving_1"] = Convert.ToDecimal(((Label)grdfourpointcheck.Rows[i].FindControl("lblwidth_weaving1_item")).Text);
                        }
                        if (((Label)grdfourpointcheck.Rows[i].FindControl("lblwidth_weaving2_item")).Text != "")
                        {
                            dtnew.Rows[i]["Weaving_2"] = Convert.ToDecimal(((Label)grdfourpointcheck.Rows[i].FindControl("lblwidth_weaving2_item")).Text);
                        }
                        if (((Label)grdfourpointcheck.Rows[i].FindControl("lblwidth_weaving3_item")).Text != "")
                        {
                            dtnew.Rows[i]["Weaving_3"] = Convert.ToDecimal(((Label)grdfourpointcheck.Rows[i].FindControl("lblwidth_weaving3_item")).Text);
                        }
                        if (((Label)grdfourpointcheck.Rows[i].FindControl("lblwidth_weaving4_item")).Text != "")
                        {
                            dtnew.Rows[i]["Weaving_4"] = Convert.ToDecimal(((Label)grdfourpointcheck.Rows[i].FindControl("lblwidth_weaving4_item")).Text);
                        }
                        if (((Label)grdfourpointcheck.Rows[i].FindControl("lbltotal_item")).Text != "")
                        {
                            dtnew.Rows[i]["total1"] = Convert.ToDecimal(((Label)grdfourpointcheck.Rows[i].FindControl("lbltotal_item")).Text);
                        }
                        if (((Label)grdfourpointcheck.Rows[i].FindControl("lblTotal2_item")).Text != "")
                        {
                            dtnew.Rows[i]["total2"] = Convert.ToDecimal(((Label)grdfourpointcheck.Rows[i].FindControl("lblTotal2_item")).Text);
                        }
                        if (((Label)grdfourpointcheck.Rows[i].FindControl("lblTotal3_item")).Text != "")
                        {
                            dtnew.Rows[i]["total3"] = Convert.ToDecimal(((Label)grdfourpointcheck.Rows[i].FindControl("lblTotal3_item")).Text);
                        }
                        if (((Label)grdfourpointcheck.Rows[i].FindControl("lblpointTotal_item")).Text != "")
                        {
                            dtnew.Rows[i]["TotalPoints"] = Convert.ToDecimal(((Label)grdfourpointcheck.Rows[i].FindControl("lblpointTotal_item")).Text);
                        }
                        if (((Label)grdfourpointcheck.Rows[i].FindControl("lblpatta_item")).Text != "")
                        {
                            dtnew.Rows[i]["Patta"] = ((Label)grdfourpointcheck.Rows[i].FindControl("lblpatta_item")).Text;
                        }
                        if (((Label)grdfourpointcheck.Rows[i].FindControl("lblhole_item")).Text != "")
                        {
                            dtnew.Rows[i]["Hole"] = Convert.ToDecimal(((Label)grdfourpointcheck.Rows[i].FindControl("lblhole_item")).Text);
                        }
                        if (((Label)grdfourpointcheck.Rows[i].FindControl("lblprintdyeingdefacts1_item")).Text != "")
                        {
                            dtnew.Rows[i]["PrintedDefectes_1"] = Convert.ToDecimal(((Label)grdfourpointcheck.Rows[i].FindControl("lblprintdyeingdefacts1_item")).Text);
                        }
                        if (((Label)grdfourpointcheck.Rows[i].FindControl("lblprintdyeingdefacts2_item")).Text != "")
                        {
                            dtnew.Rows[i]["PrintedDefectes_2"] = Convert.ToDecimal(((Label)grdfourpointcheck.Rows[i].FindControl("lblprintdyeingdefacts2_item")).Text);
                        }
                        if (((Label)grdfourpointcheck.Rows[i].FindControl("lblprintdyeingdefacts3_item")).Text != "")
                        {
                            dtnew.Rows[i]["PrintedDefectes_3"] = Convert.ToDecimal(((Label)grdfourpointcheck.Rows[i].FindControl("lblprintdyeingdefacts3_item")).Text);
                        }
                        if (((Label)grdfourpointcheck.Rows[i].FindControl("lblprintdyeingdefacts4_item")).Text != "")
                        {
                            dtnew.Rows[i]["PrintedDefectes_4"] = Convert.ToDecimal(((Label)grdfourpointcheck.Rows[i].FindControl("lblprintdyeingdefacts4_item")).Text);
                        }
                        if (((Label)grdfourpointcheck.Rows[i].FindControl("lblweapointyard_item")).Text != "")
                        {
                            dtnew.Rows[i]["WeaPointsPerSquirdYards"] = Convert.ToDecimal(((Label)grdfourpointcheck.Rows[i].FindControl("lblweapointyard_item")).Text);
                        }
                        string statuss = "";
                        string statusnarration = "";
                        if (((Label)grdfourpointcheck.Rows[i].FindControl("lblstatus_item")).Text == "Pass")
                        {
                            statuss = "1";
                            statusnarration = "Pass";
                        }
                        else if (((Label)grdfourpointcheck.Rows[i].FindControl("lblstatus_item")).Text == "Fail")
                        {
                            statuss = "2";
                            statusnarration = "Fail";
                        }
                        else
                        {
                            statuss = "-1";
                        }
                        dtnew.Rows[i]["Status"] = Convert.ToInt32(statuss);
                        dtnew.Rows[i]["Statusstring"] = statusnarration;
                    }
                    dtnew.AcceptChanges();

                    int id = 0;
                    if (dtnew.Rows.Count <= 0)
                    {
                        id = 1;
                    }
                    else
                    {
                        id = dtnew.Rows.Count + 1;
                    }

                    dtnew.Rows.Add(id, -1, -1, RollNumber, DeitLotNumber, ClaimedQty, ActualLength, Width_S, Width_M, Width_E, Weaving_1, Weaving_2, Weaving_3, Weaving_4, total1, Patta, Hole, total2, PrintedDefectes_1, PrintedDefectes_2, PrintedDefectes_3, PrintedDefectes_4, total3, TotalPoints, WeaPointsPerSquirdYards, Status, Statusstring, CheckedQty, PassQty, HoldQty, FailQty);
                    ViewState["viewGrddate"] = dtnew;
                }
                Bindgrd();
            }
            if (e.CommandName == "addnew")
            {

                Table tblGrdviewApplet = (Table)grdfourpointcheck.Controls[0];
                GridViewRow rows = (GridViewRow)tblGrdviewApplet.Controls[0];
                TextBox txtrollno_emptyrow = (TextBox)rows.FindControl("txtrollno_emptyrow");
                TextBox txtdeilot_emptyrow = (TextBox)rows.FindControl("txtdeilot_emptyrow");
                TextBox txtclaimedlength_emptyrow = (TextBox)rows.FindControl("txtclaimedlength_emptyrow"); //new line
                TextBox txtactlenght_emptyrow = (TextBox)rows.FindControl("txtactlenght_emptyrow");
                TextBox txtwithd_s_emptyrow = (TextBox)rows.FindControl("txtwithd_s_emptyrow");
                TextBox txtwithd_M_emptyrow = (TextBox)rows.FindControl("txtwithd_M_emptyrow");
                TextBox txtwithd_E_emptyrow = (TextBox)rows.FindControl("txtwithd_E_emptyrow");
                TextBox txtweaving_1_emptyrow = (TextBox)rows.FindControl("txtweaving_1_emptyrow");
                TextBox txtweaving_2_emptyrow = (TextBox)rows.FindControl("txtweaving_2_emptyrow");
                TextBox txtweaving_3_emptyrow = (TextBox)rows.FindControl("txtweaving_3_emptyrow");
                TextBox txtweaving_4_emptyrow = (TextBox)rows.FindControl("txtweaving_4_emptyrow");
                TextBox txttotal1_emptyrow = (TextBox)rows.FindControl("txttotal1_emptyrow");
                TextBox txtpatta_emptyrow = (TextBox)rows.FindControl("txtpatta_emptyrow");
                TextBox txthole_emptyrow = (TextBox)rows.FindControl("txthole_emptyrow");
                TextBox txttotal2_emptyrow = (TextBox)rows.FindControl("txttotal2_emptyrow");
                TextBox txtprintdyeingdefacts1_emptyrow = (TextBox)rows.FindControl("txtprintdyeingdefacts1_emptyrow");
                TextBox txtprintdyeingdefacts2_emptyrow = (TextBox)rows.FindControl("txtprintdyeingdefacts2_emptyrow");
                TextBox txtprintdyeingdefacts3_emptyrow = (TextBox)rows.FindControl("txtprintdyeingdefacts3_emptyrow");
                TextBox txtprintdyeingdefacts4_emptyrow = (TextBox)rows.FindControl("txtprintdyeingdefacts4_emptyrow");
                TextBox txttotal3_emptyrow = (TextBox)rows.FindControl("txttotal3_emptyrow");
                TextBox txttotalpoint_emptyrow = (TextBox)rows.FindControl("txttotalpoint_emptyrow");
                TextBox txtweapointyard_emptyrow = (TextBox)rows.FindControl("txtweapointyard_emptyrow");
                DropDownList ddlstatus_emptyrow = (DropDownList)rows.FindControl("ddlstatus_emptyrow");
                HiddenField hdmrowidauto_empty = (HiddenField)rows.FindControl("hdmrowidauto_empty");

                TextBox txtcheckedlength_emptyrow = (TextBox)rows.FindControl("txtcheckedlength_emptyrow"); //new line 02-02-2021
                TextBox txtpasslength_emptyrow = (TextBox)rows.FindControl("txtpasslength_emptyrow"); //new line 02-02-2021
                TextBox txtholdlength_emptyrow = (TextBox)rows.FindControl("txtholdlength_emptyrow"); //new line 02-02-2021
                TextBox txtfaillength_emptyrow = (TextBox)rows.FindControl("txtfaillength_emptyrow"); //new line 02-02-2021

                if (txtrollno_emptyrow.Text == string.Empty)
                {
                    ShowAlert("Roll/Box No. can't blank!");
                    return;
                }
                if (txtdeilot_emptyrow.Text == string.Empty)
                {
                    ShowAlert("Dye Lot can't blank!");
                    return;
                }

                if (txtclaimedlength_emptyrow.Text == string.Empty)
                {
                    ShowAlert("Claimed Length can't blank!");
                    return;
                }

                if (txtactlenght_emptyrow.Text == string.Empty)
                {
                    ShowAlert("Actual Length can't blank!");
                    return;
                }
                if (txtcheckedlength_emptyrow.Text == string.Empty)
                {
                    ShowAlert("Checked Quantity can't blank!");
                    return;
                }
                if (Convert.ToInt32(txtcheckedlength_emptyrow.Text) > Convert.ToInt32(txtactlenght_emptyrow.Text))
                {
                    ShowAlert("Checked Quantity can't be greater than Actual Length!");
                    return;
                }
                int passQty = txtpasslength_emptyrow.Text == string.Empty ? 0 : Convert.ToInt32(txtpasslength_emptyrow.Text);
                int failQty = txtfaillength_emptyrow.Text == string.Empty ? 0 : Convert.ToInt32(txtfaillength_emptyrow.Text);
                int holdQty = txtholdlength_emptyrow.Text == string.Empty ? 0 : Convert.ToInt32(txtholdlength_emptyrow.Text);
                int checkedQty = txtcheckedlength_emptyrow.Text == string.Empty ? 0 : Convert.ToInt32(txtcheckedlength_emptyrow.Text);
                if (passQty + failQty + holdQty != checkedQty)
                {
                    ShowAlert("(Pass + Fail + Hold) Quantity should be equal Checked Quantity!");
                    return;
                }

                FourPointCheck_Id = -1;

                //new code start 02-02-2021
                if (txtcheckedlength_emptyrow.Text != "")
                {
                    CheckedQty = Convert.ToDecimal(txtcheckedlength_emptyrow.Text);
                }
                if (txtpasslength_emptyrow.Text != "")
                {
                    PassQty = Convert.ToDecimal(txtpasslength_emptyrow.Text);
                }
                if (txtholdlength_emptyrow.Text != "")
                {
                    HoldQty = Convert.ToDecimal(txtholdlength_emptyrow.Text);
                }
                if (txtfaillength_emptyrow.Text != "")
                {
                    FailQty = Convert.ToDecimal(txtfaillength_emptyrow.Text);
                }
                //new code end 02-02-2021

                if (txtrollno_emptyrow.Text != "")
                {
                    RollNumber = Convert.ToInt32(txtrollno_emptyrow.Text);
                }
                if (txtdeilot_emptyrow.Text != "")
                {
                    DeitLotNumber = Convert.ToInt32(txtdeilot_emptyrow.Text);
                }

                //new code start
                if (txtclaimedlength_emptyrow.Text != "")
                {
                    ClaimedQty = Convert.ToDecimal(txtclaimedlength_emptyrow.Text);
                }
                //new code end

                if (txtactlenght_emptyrow.Text != "")
                {
                    ActualLength = Convert.ToDecimal(txtactlenght_emptyrow.Text);
                }
                if (txtwithd_s_emptyrow.Text != "")
                {
                    Width_S = Convert.ToDecimal(txtwithd_s_emptyrow.Text);
                }
                if (txtwithd_M_emptyrow.Text != "")
                {
                    Width_M = Convert.ToDecimal(txtwithd_M_emptyrow.Text);
                }
                if (txtwithd_E_emptyrow.Text != "")
                {
                    Width_E = Convert.ToDecimal(txtwithd_E_emptyrow.Text);
                }
                if (txtweaving_1_emptyrow.Text != "")
                {
                    Weaving_1 = Convert.ToDecimal(txtweaving_1_emptyrow.Text);
                }
                if (txtweaving_2_emptyrow.Text != "")
                {
                    Weaving_2 = Convert.ToDecimal(txtweaving_2_emptyrow.Text);
                }
                if (txtweaving_3_emptyrow.Text != "")
                {
                    Weaving_3 = Convert.ToDecimal(txtweaving_3_emptyrow.Text);
                }
                if (txtweaving_4_emptyrow.Text != "")
                {
                    Weaving_4 = Convert.ToDecimal(txtweaving_4_emptyrow.Text);
                }
                if (txttotal1_emptyrow.Text != "")
                {
                    total1 = Convert.ToDecimal(txttotal1_emptyrow.Text);
                }

                if (txtpatta_emptyrow.Text != "")
                {
                    Patta = Convert.ToDecimal(txtpatta_emptyrow.Text);
                }
                if (txthole_emptyrow.Text != "")
                {
                    Hole = Convert.ToDecimal(txthole_emptyrow.Text);
                }
                if (txttotal2_emptyrow.Text != "")
                {
                    total2 = Convert.ToDecimal(txttotal2_emptyrow.Text);
                }
                if (txtprintdyeingdefacts1_emptyrow.Text != "")
                {
                    PrintedDefectes_1 = Convert.ToDecimal(txtprintdyeingdefacts1_emptyrow.Text);
                }
                if (txtprintdyeingdefacts2_emptyrow.Text != "")
                {
                    PrintedDefectes_2 = Convert.ToDecimal(txtprintdyeingdefacts2_emptyrow.Text);
                }
                if (txtprintdyeingdefacts3_emptyrow.Text != "")
                {
                    PrintedDefectes_3 = Convert.ToDecimal(txtprintdyeingdefacts3_emptyrow.Text);
                }
                if (txtprintdyeingdefacts4_emptyrow.Text != "")
                {
                    PrintedDefectes_4 = Convert.ToDecimal(txtprintdyeingdefacts4_emptyrow.Text);
                }
                if (txttotal3_emptyrow.Text != "")
                {
                    total3 = Convert.ToDecimal(txttotal3_emptyrow.Text);
                }
                if (txttotalpoint_emptyrow.Text != "")
                {
                    TotalPoints = Convert.ToDecimal(txttotalpoint_emptyrow.Text);
                }
                if (txtweapointyard_emptyrow.Text != "")
                {
                    WeaPointsPerSquirdYards = Convert.ToDecimal(txtweapointyard_emptyrow.Text);
                }
                Status = Convert.ToInt32(ddlstatus_emptyrow.SelectedValue);
                if (ddlstatus_emptyrow.SelectedValue == "1")
                {
                    Statusstring = "Pass";
                }
                else if (ddlstatus_emptyrow.SelectedValue == "2")
                {
                    Statusstring = "Fail";
                }
                else
                {
                    Statusstring = "";
                }
                if (ViewState["viewGrddate"] != null)
                {

                    DataTable dtnew = (DataTable)(ViewState["viewGrddate"]);

                    dtnew.AcceptChanges();
                    if (Count == 0)
                    {
                        if (dtnew.Rows.Count > 0)
                            dtnew.Rows.RemoveAt(0);
                    }

                    int id = 0;
                    if (dtnew.Rows.Count <= 0)
                    {
                        id = 1;
                    }
                    else
                    {
                        id = dtnew.Rows.Count + 1;
                    }
                    dtnew.Rows.Add(id, -1, -1, RollNumber, DeitLotNumber, ClaimedQty, ActualLength, Width_S, Width_M, Width_E, Weaving_1, Weaving_2, Weaving_3, Weaving_4, total1, Patta, Hole, total2, PrintedDefectes_1, PrintedDefectes_2, PrintedDefectes_3, PrintedDefectes_4, total3, TotalPoints, WeaPointsPerSquirdYards, Status, Statusstring, CheckedQty, PassQty, HoldQty, FailQty);
                    ViewState["viewGrddate"] = dtnew;

                    grdfourpointcheck.DataSource = dtnew;
                    grdfourpointcheck.DataBind();
                }
                // Bindgrd();
            }
        }

        protected void grdfourpointcheck_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            RollNumber = 0;
            DeitLotNumber = 0;
            ClaimedQty = 0; //new line
            ActualLength = 0;
            Width_S = 0;
            Width_M = 0;
            Width_E = 0;
            Weaving_1 = 0;
            Weaving_2 = 0;
            Weaving_3 = 0;
            Weaving_4 = 0;
            Patta = 0;
            Hole = 0;
            PrintedDefectes_1 = 0;
            PrintedDefectes_2 = 0;
            PrintedDefectes_3 = 0;
            PrintedDefectes_4 = 0;
            WeaPointsPerSquirdYards = 0;


            CheckedQty = 0; //new line 02-02-2021
            PassQty = 0; //new line 02-02-2021
            HoldQty = 0; //new line 02-02-2021
            FailQty = 0; //new line 02-02-2021

            GridViewRow Rows = grdfourpointcheck.Rows[e.RowIndex];
            TextBox txtrollno_Edit = Rows.FindControl("txtrollno_Edit") as TextBox;
            TextBox txtdeilot_Edit = Rows.FindControl("txtdeilot_Edit") as TextBox;
            TextBox txtclaimedlength_Edit = Rows.FindControl("txtclaimedlength_Edit") as TextBox;   //new line
            TextBox txtactlenght_Edit = Rows.FindControl("txtactlenght_Edit") as TextBox;
            TextBox txtwidth_S_Edit = Rows.FindControl("txtwidth_S_Edit") as TextBox;
            TextBox txtwidth_M_Edit = Rows.FindControl("txtwidth_M_Edit") as TextBox;
            TextBox txtwidth_E_Edit = Rows.FindControl("txtwidth_E_Edit") as TextBox;
            TextBox txtwidth_weaving1_Edit = Rows.FindControl("txtwidth_weaving1_Edit") as TextBox;
            TextBox txtwidth_weaving2_Edit = Rows.FindControl("txtwidth_weaving2_Edit") as TextBox;
            TextBox txtwidth_weaving3_Edit = Rows.FindControl("txtwidth_weaving3_Edit") as TextBox;
            TextBox txtwidth_weaving4_Editv = Rows.FindControl("txtwidth_weaving4_Edit") as TextBox;
            TextBox txttotal_Edit = Rows.FindControl("txttotal_Edit") as TextBox;
            TextBox txtpatta_Edit = Rows.FindControl("txtpatta_Edit") as TextBox;
            TextBox txthole_Edit = Rows.FindControl("txthole_Edit") as TextBox;
            TextBox txtTotal2_Edit = Rows.FindControl("txtTotal2_Edit") as TextBox;
            TextBox txtprintdyeingdefacts1_Edit = Rows.FindControl("txtprintdyeingdefacts1_Edit") as TextBox;
            TextBox txtprintdyeingdefacts2_Edit = Rows.FindControl("txtprintdyeingdefacts2_Edit") as TextBox;
            TextBox txtprintdyeingdefacts3_Edit = Rows.FindControl("txtprintdyeingdefacts3_Edit") as TextBox;
            TextBox txtprintdyeingdefacts4_Edit = Rows.FindControl("txtprintdyeingdefacts4_Edit") as TextBox;
            TextBox txtTotal3_Edit = Rows.FindControl("txtTotal3_Edit") as TextBox;
            TextBox txtpointTotal_Edit = Rows.FindControl("txtpointTotal_Edit") as TextBox;
            TextBox txtweapointyard_Edit = Rows.FindControl("txtweapointyard_Edit") as TextBox;
            DropDownList ddlstatus_Edit = Rows.FindControl("ddlstatus_Edit") as DropDownList;
            HiddenField hdmrowidauto = Rows.FindControl("hdmrowidauto") as HiddenField;

            TextBox txtchkd_Edit = Rows.FindControl("txtchkd_Edit") as TextBox;   //new line 02-02-2021
            TextBox txtpass_Edit = Rows.FindControl("txtpass_Edit") as TextBox;   //new line 02-02-2021
            TextBox txthold_Edit = Rows.FindControl("txthold_Edit") as TextBox;   //new line 02-02-2021
            TextBox txtfail_Edit = Rows.FindControl("txtfail_Edit") as TextBox;   //new line 02-02-2021    

            if (txtrollno_Edit.Text == string.Empty)
            {
                ShowAlert("Roll/Box No. can't blank!");
                return;
            }
            if (txtdeilot_Edit.Text == string.Empty)
            {
                ShowAlert("Dyed Lot can't blank!");
                return;
            }

            if (txtclaimedlength_Edit.Text == string.Empty)
            {
                ShowAlert("Claimed Length can't blank!");
                return;
            }
            if (txtactlenght_Edit.Text == string.Empty)
            {
                ShowAlert("Actual Length can't blank!");
                return;
            }
            if (txtchkd_Edit.Text == string.Empty)
            {
                ShowAlert("Checked Quantity can't blank!");
                return;
            }
            if (Convert.ToInt32(txtchkd_Edit.Text.Replace(",", "")) > Convert.ToInt32(txtactlenght_Edit.Text.Replace(",", "")))
            {
                ShowAlert("Checked Quantity can't be greater than Actual Length!");
                return;
            }
            int passQty = txtpass_Edit.Text == string.Empty ? 0 : Convert.ToInt32(txtpass_Edit.Text.Replace(",", ""));
            int failQty = txtfail_Edit.Text == string.Empty ? 0 : Convert.ToInt32(txtfail_Edit.Text.Replace(",", ""));
            int holdQty = txthold_Edit.Text == string.Empty ? 0 : Convert.ToInt32(txthold_Edit.Text.Replace(",", ""));
            int checkedQty = txtchkd_Edit.Text == string.Empty ? 0 : Convert.ToInt32(txtchkd_Edit.Text.Replace(",", ""));

            if (passQty + failQty + holdQty != checkedQty)
            {
                ShowAlert("(Pass + Fail + Hold) Quantity should be equal Checked Quantity!");
                return;
            }

            FourPointCheck_Id = -1;

            //new code start 02-02-2021
            if (txtchkd_Edit.Text != "")
            {
                CheckedQty = Convert.ToDecimal(txtchkd_Edit.Text);
            }
            if (txtpass_Edit.Text != "")
            {
                PassQty = Convert.ToDecimal(txtpass_Edit.Text);
            }
            if (txthold_Edit.Text != "")
            {
                HoldQty = Convert.ToDecimal(txthold_Edit.Text);
            }
            if (txtfail_Edit.Text != "")
            {
                FailQty = Convert.ToDecimal(txtfail_Edit.Text);
            }
            //new code end 02-02-2021

            if (txtrollno_Edit.Text != "")
            {
                RollNumber = Convert.ToInt32(txtrollno_Edit.Text);
            }
            if (txtdeilot_Edit.Text != "")
            {
                DeitLotNumber = Convert.ToInt32(txtdeilot_Edit.Text);
            }
            //new code start
            if (txtclaimedlength_Edit.Text != "")
            {
                ClaimedQty = Convert.ToDecimal(txtclaimedlength_Edit.Text);
            }
            //new code end
            if (txtactlenght_Edit.Text != "")
            {
                ActualLength = Convert.ToDecimal(txtactlenght_Edit.Text);
            }
            if (txtwidth_S_Edit.Text != "")
            {
                Width_S = Convert.ToDecimal(txtwidth_S_Edit.Text);
            }
            if (txtwidth_M_Edit.Text != "")
            {
                Width_M = Convert.ToDecimal(txtwidth_M_Edit.Text);
            }
            if (txtwidth_E_Edit.Text != "")
            {
                Width_E = Convert.ToDecimal(txtwidth_E_Edit.Text);
            }
            if (txtwidth_weaving1_Edit.Text != "")
            {
                Weaving_1 = Convert.ToDecimal(txtwidth_weaving1_Edit.Text);
            }
            if (txtwidth_weaving2_Edit.Text != "")
            {
                Weaving_2 = Convert.ToDecimal(txtwidth_weaving2_Edit.Text);
            }
            if (txtwidth_weaving3_Edit.Text != "")
            {
                Weaving_3 = Convert.ToDecimal(txtwidth_weaving3_Edit.Text);
            }
            if (txtwidth_weaving4_Editv.Text != "")
            {
                Weaving_4 = Convert.ToDecimal(txtwidth_weaving4_Editv.Text);
            }
            if (txtpatta_Edit.Text != "")
            {
                Patta = Convert.ToDecimal(txtpatta_Edit.Text);
            }
            if (txthole_Edit.Text != "")
            {
                Hole = Convert.ToDecimal(txthole_Edit.Text);
            }

            if (txtprintdyeingdefacts1_Edit.Text != "")
            {
                PrintedDefectes_1 = Convert.ToDecimal(txtprintdyeingdefacts1_Edit.Text);
            }
            if (txtprintdyeingdefacts2_Edit.Text != "")
            {
                PrintedDefectes_2 = Convert.ToDecimal(txtprintdyeingdefacts2_Edit.Text);
            }
            if (txtprintdyeingdefacts3_Edit.Text != "")
            {
                PrintedDefectes_3 = Convert.ToDecimal(txtprintdyeingdefacts3_Edit.Text);
            }
            if (txtprintdyeingdefacts4_Edit.Text != "")
            {
                PrintedDefectes_4 = Convert.ToDecimal(txtprintdyeingdefacts4_Edit.Text);
            }
            if (txtweapointyard_Edit.Text != "")
            {
                WeaPointsPerSquirdYards = Convert.ToDecimal(txtweapointyard_Edit.Text);
            }

            Status = Convert.ToInt32(ddlstatus_Edit.SelectedValue);
            if (ddlstatus_Edit.SelectedValue == "1")
            {
                Statusstring = "Pass";
            }
            else if (ddlstatus_Edit.SelectedValue == "2")
            {
                Statusstring = "Fail";
            }
            else
            {
                Statusstring = "";
            }
            DataTable dtnew = (DataTable)(ViewState["viewGrddate"]);
            dtnew.DefaultView.Sort = "ID ASC";



            foreach (DataRow dr in dtnew.Rows)
            {
                if (dr["ID"].ToString() == hdmrowidauto.Value)
                {
                    dr["FourPointCheck_Parameter"] = -1;
                    dr["FourPointCheck_Id"] = -1;
                    dr["RollNumber"] = Convert.ToInt32(RollNumber);
                    dr["DeitLotNumber"] = Convert.ToInt32(DeitLotNumber);
                    dr["ClaimedQty"] = ClaimedQty;  //new line
                    dr["ActualLength"] = ActualLength;
                    dr["Width_S"] = Width_S;
                    dr["Width_M"] = Width_M;
                    dr["Width_E"] = Width_E;
                    dr["Weaving_1"] = Weaving_1;
                    dr["Weaving_2"] = Weaving_2;
                    dr["Weaving_3"] = Weaving_3;
                    dr["Weaving_4"] = Weaving_4;
                    dr["Patta"] = Patta;
                    dr["Hole"] = Hole;
                    dr["PrintedDefectes_1"] = PrintedDefectes_1;
                    dr["PrintedDefectes_2"] = PrintedDefectes_2;
                    dr["PrintedDefectes_3"] = PrintedDefectes_3;
                    dr["PrintedDefectes_4"] = PrintedDefectes_4;
                    dr["WeaPointsPerSquirdYards"] = WeaPointsPerSquirdYards;
                    dr["Status"] = Convert.ToInt32(Status);
                    dr["Statusstring"] = Statusstring;

                    dr["CheckedQty"] = CheckedQty;  //new line 02-02-2021
                    dr["PassQty"] = PassQty;  //new line 02-02-2021
                    dr["HoldQty"] = HoldQty;  //new line 02-02-2021
                    dr["FailQty"] = FailQty;  //new line 02-02-2021
                    break;
                }
            }
            dtnew.AcceptChanges();
            grdfourpointcheck.EditIndex = -1;
            //grdfourpointcheck.DataSource = AccessoriesInspectionList;
            //grdfourpointcheck.DataBind();

            dtnew.DefaultView.Sort = "ID ASC";
            ViewState["viewGrddate"] = dtnew;

            if (ViewState["viewGrddate"] != null)
            {
                Bindgrd();
            }
        }

        public void ShowAlert(string stringAlertMsg)
        {
            string myStringVariable = string.Empty;
            myStringVariable = stringAlertMsg;
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "AddActualReceivedQty", "AddActualReceivedQty('grdfourpointcheck_ctl04_txtclaimedlength_Edit');", true);
        }

        public void UpdateEntry()
        {
            string InternalLabReportFileName = "";
            string ExternalLabReportFileName = "";
            //bool FinalDecision = false;

            DataTable dtresult;
            //string statuss = "";
            //string statusnarration = "";
            //string issaive = "";
            //#region "A"
            //DateTime inspectiondate;
            //int AllocatedUnit = 0;
            //decimal ReceivedQty = 0;
            //CheckedQty1 = 0, PassQty1 = 0, HoldQty1 = 0, FailQty1 = 0;
            //string Commentes = "", QcNames = "";


            //if (txtcommentsInput.Text != "")
            //{
            //    Commentes = "$$" + "<span style='font-weight:600'>" + DateTime.Today.ToString("dd MMM yy (ddd)") + " " + iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.FirstName.ToString() + " :</span>" + txtcommentsInput.Text + "$$";
            //}

            DateTime Inspectioedate = (DateTime.ParseExact(txtdates.Text, "dd MMM yy (ddd)", System.Globalization.CultureInfo.InvariantCulture));
            //int IsFabricQA = 0, IsCuttingQA = 0, IsFabricGM = 0;
            //#endregion

            //if (txtReceivedfourpoint.Text != "")
            //{
            //    ReceivedQty = Convert.ToInt32(txtReceivedfourpoint.Text.Trim().Replace(",", ""));
            //}
            //if (txtchecedQtyfourpointchecK.Text != "")
            //{
            //    CheckedQty = Convert.ToInt32(txtchecedQtyfourpointchecK.Text.Trim().Replace(",", ""));
            //}
            //if (txtpassfourpointcheck.Text != "")
            //{
            //    PassQty = Convert.ToInt32(txtpassfourpointcheck.Text.Trim().Replace(",", ""));
            //}
            //if (txtholdfourpointcheck.Text != "")
            //{
            //    HoldQty = Convert.ToInt32(txtholdfourpointcheck.Text.Trim().Replace(",", ""));
            //}
            //if (txtfailfourpointcheck.Text != "")
            //{
            //    FailQty = Convert.ToInt32(txtfailfourpointcheck.Text.Trim().Replace(",", ""));
            //}
            //if (ChkFabricQa.Enabled == true)
            //{
            //    IsFabricQA = ChkFabricQa.Checked == true ? 1 : 0;
            //}
            //else
            //{
            //    IsFabricQA = -1;
            //}

            //if (ChkFabricGM.Enabled == true)
            //{
            //    IsFabricGM = ChkFabricGM.Checked == true ? 1 : 0;
            //}
            //else
            //{
            //    IsFabricGM = -1;
            //}

            //new code start 02-02-2021 
            //int LabInternalSpecimanCount=0, LabExternalSpecimanCount=0, RaiseDebit=0, FailStock=0, GoodStock=0, InspectRaiseDebit=0, InspectUsableDebit=0;
            //string FailedParticular = "", InspectParticular = "", InternalLabReport = "", ExternalLabReport = "", CheckerName1 = "", CheckerName2 = "", CheckerName3 = "";
            //bool InternalSentToLab = false, ExternalSentToLab = false, InternalReceivedInLab = false, ExternalReceivedInLab = false, IsLabManager = false, IsFabricQA = false, IsFabricGM = false;
            //DateTime InternalSentToLabDate = DateTime.Now; 
            //DateTime InternalReceivedInLabDate = DateTime.Now;
            //DateTime ExternalSentToLabDate = DateTime.Now;
            //DateTime ExternalReceivedInLabDate = DateTime.Now;

            //FabricInspectSystem fabricInspectSystem = new FabricInspectSystem();
            //new code start 04-02-2021

            FabricInspectSystem fabricInspectSystem = new FabricInspectSystem();
            fabricInspectSystem.SupplierPO_Id = SupplierPoID;
            fabricInspectSystem.SRV_Id = SrvID;

            if (txtcheckname1.Text != string.Empty)
            {
                fabricInspectSystem.CheckerName1 = txtcheckname1.Text;
            }

            fabricInspectSystem.CheckerName2 = txtcheckname2.Text;
            fabricInspectSystem.CheckerName3 = txtcheckname3.Text;

            fabricInspectSystem.Comments = txtComments.Text;

            fabricInspectSystem.CreatedBy = iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.UserID;
            if (lblTotalClaimedLength.Text != string.Empty)
                fabricInspectSystem.ClaimedQty = Convert.ToInt32(lblTotalClaimedLength.Text.Replace(",", ""));

            if (lblTotalActualLength.Text != string.Empty)
                fabricInspectSystem.RecievedQty = Convert.ToInt32(lblTotalActualLength.Text.Replace(",", ""));

            if (lblTotalChecked.Text != string.Empty)
                fabricInspectSystem.CheckedQty = Convert.ToInt32(lblTotalChecked.Text.Replace(",", ""));

            if (lblTotalPass.Text != string.Empty)
                fabricInspectSystem.PassQty = Convert.ToInt32(lblTotalPass.Text.Replace(",", ""));

            if (lblTotalHold.Text != string.Empty)
                fabricInspectSystem.HoldQty = Convert.ToInt32(lblTotalHold.Text.Replace(",", ""));

            if (lblTotalFailed.Text != string.Empty)
                fabricInspectSystem.FailQty = Convert.ToInt32(lblTotalFailed.Text.Replace(",", ""));


            if (ddlunitname.SelectedValue != "-1")
            {
                fabricInspectSystem.UnitId = Convert.ToInt32(ddlunitname.SelectedValue);
            }
            fabricInspectSystem.InspectionDate = Inspectioedate;


            if (txtInternalLabSpecimanCount.Text != "" && txtInternalLabSpecimanCount.Text != null)
            {
                fabricInspectSystem.InternalLabSpeciman = Convert.ToInt32(txtInternalLabSpecimanCount.Text);
            }
            fabricInspectSystem.InternalSentToLab = chkInternalSentToLab.Checked == true ? true : false;
            hdnchkInternalSentToLab.Value = chkInternalSentToLab.Checked == true ? "True" : "False";

            //if (hdnchkInternalSentToLab.Value=="True" && lblInternalSentToLabDate.Text == "")
            //{
            //        fabricInspectSystem.InternalSentToLabDate = DateTime.Now;                
            //}
            //else
            //{
            //    fabricInspectSystem.InternalSentToLabDate = Convert.ToDateTime(hdnInternalSentToLabDate.Value);
            //}
            if (hdnchkInternalSentToLab.Value == "True" && lblInternalSentToLabDate.Text == "")
            {
                fabricInspectSystem.InternalSentToLabDate = DateTime.Now;
            }
            else
            {
                if (lblInternalSentToLabDate.Text != "")
                {
                    fabricInspectSystem.InternalSentToLabDate = (DateTime.ParseExact(lblInternalSentToLabDate.Text, "dd MMM yy (ddd) HH:mm", System.Globalization.CultureInfo.InvariantCulture));
                }
            }

            fabricInspectSystem.InternalReceivedInLab = chkInternalReceivedInLab.Checked == true ? true : false;
            hdnchkInternalReceivedInLab.Value = chkInternalReceivedInLab.Checked == true ? "True" : "False";


            //if (hdnchkInternalReceivedInLab.Value == "True" && lblInternalSentToLabDate.Text == "")
            //{
            //        fabricInspectSystem.InternalReceivedInLabDate = DateTime.Now;
            //}
            //else
            //{
            //    fabricInspectSystem.InternalReceivedInLabDate = Convert.ToDateTime(hdnInternalReceivedInLabDate.Value);
            //}

            if (hdnchkInternalReceivedInLab.Value == "True" && lblInternalReceivedIndLabDate.Text == "")
            {
                fabricInspectSystem.InternalReceivedInLabDate = DateTime.Now;
            }
            else
            {
                if (lblInternalReceivedIndLabDate.Text != "")
                {
                    fabricInspectSystem.InternalReceivedInLabDate = (DateTime.ParseExact(lblInternalReceivedIndLabDate.Text, "dd MMM yy (ddd) HH:mm", System.Globalization.CultureInfo.InvariantCulture));
                }
            }

            if (uploadInternalLabReport.HasFile)
            {
                string Exten = System.IO.Path.GetExtension(uploadInternalLabReport.FileName);
                string ActualfileName = "Internal_Lab_Report_" + uploadInternalLabReport.FileName;
                string Name = ActualfileName.Substring(0, ActualfileName.LastIndexOf('.'));
                InternalLabReportFileName = FileHelper.SaveFile(uploadInternalLabReport.PostedFile.InputStream, uploadInternalLabReport.FileName, Constants.PHOTO_FOLDER_PATH, true, Name);
                fabricInspectSystem.InternalLabReport = InternalLabReportFileName;
                hylnkInternalLabReport.Visible = false;
                //lblInternalFileName.Text = ActualfileName;
            }

            if (txtExternalLabSpecimanCount.Text != "")
            {
                fabricInspectSystem.ExternalLabSpeciman = Convert.ToInt32(txtExternalLabSpecimanCount.Text);
            }

            fabricInspectSystem.ExternalSentToLab = chkExternalSentToLab.Checked == true ? true : false;
            hdnchkExternalSentToLab.Value = chkExternalSentToLab.Checked == true ? "True" : "False";

            //if (hdnchkExternalSentToLab.Value == "True" && lblExternalReceivedInLabDate.Text == "")
            //{
            //        fabricInspectSystem.ExternalSentToLabDate = DateTime.Now;             
            //}
            //else
            //{
            //    fabricInspectSystem.ExternalSentToLabDate = Convert.ToDateTime(hdnExternalSentToLabDate.Value);
            //}
            if (hdnchkExternalSentToLab.Value == "True" && lblExternalSentToLabDate.Text == "")
            {
                fabricInspectSystem.ExternalSentToLabDate = DateTime.Now;
            }
            else
            {
                if (lblExternalSentToLabDate.Text != "")
                {
                    fabricInspectSystem.ExternalSentToLabDate = (DateTime.ParseExact(lblExternalSentToLabDate.Text, "dd MMM yy (ddd) HH:mm", System.Globalization.CultureInfo.InvariantCulture));
                }
            }

            fabricInspectSystem.ExternalReceivedInLab = chkExternalReceivedInLab.Checked == true ? true : false;
            hdnchkExternalReceivedInLab.Value = chkExternalReceivedInLab.Checked == true ? "True" : "False";

            //if (hdnchkExternalReceivedInLab.Value == "True" && lblExternalReceivedInLabDate.Text == "")
            //{
            //    fabricInspectSystem.ExternalReceivedInLabDate = DateTime.Now;
            //}
            //else
            //{
            //    fabricInspectSystem.ExternalReceivedInLabDate = Convert.ToDateTime(hdnExternalReceivedInLabDate.Value);
            //}

            if (hdnchkExternalReceivedInLab.Value == "True" && lblExternalReceivedInLabDate.Text == "")
            {
                fabricInspectSystem.ExternalReceivedInLabDate = DateTime.Now;
            }
            else
            {
                if (lblExternalReceivedInLabDate.Text != "")
                {
                    fabricInspectSystem.ExternalReceivedInLabDate = (DateTime.ParseExact(lblExternalReceivedInLabDate.Text, "dd MMM yy (ddd) HH:mm", System.Globalization.CultureInfo.InvariantCulture));
                }
            }

            if (uploadExternalLabReport.HasFile)
            {
                string Exten = System.IO.Path.GetExtension(uploadExternalLabReport.FileName);
                string ActualfileName = "External_Lab_Report_" + uploadExternalLabReport.FileName;
                string Name = ActualfileName.Substring(0, ActualfileName.LastIndexOf('.'));
                ExternalLabReportFileName = FileHelper.SaveFile(uploadExternalLabReport.PostedFile.InputStream, uploadExternalLabReport.FileName, Constants.PHOTO_FOLDER_PATH, true, Name);
                fabricInspectSystem.ExternalLabReport = ExternalLabReportFileName;
                hylnkExternalLabReport.Visible = false;

            }

            if (rdybtnComeercialPass.Checked)
            {
                if (hdnUserid.Value != "15")
                {
                    fabricInspectSystem.IsCommercialPass = 1;
                    fabricInspectSystem.FinalDecision = 1;
                }
                else
                {

                    fabricInspectSystem.IsCommercialPass = Convert.ToInt32(hdnDecissionCommercialpass.Value);
                    fabricInspectSystem.FinalDecision = 1;//Convert.ToInt32(hdnFinalDecissionPass.Value);
                }
                // if it is commericial pass then final decision is also passs by  added shubhendu
            }
            else
            {
                if (hdnUserid.Value == "15" && hdnDecissionCommercialpass.Value == "1")
                {
                    fabricInspectSystem.IsCommercialPass = Convert.ToInt32(hdnDecissionCommercialpass.Value);
                    fabricInspectSystem.FinalDecision = Convert.ToInt32(hdnFinalDecissionPass.Value);
                }
                else
                {
                    fabricInspectSystem.IsCommercialPass = -1;
                }
            }
            if (rdyBtnLabDecPassExt.Checked || hdnExtPass.Value == "1")
            {
                fabricInspectSystem.LabDecisionExternal = 1;
            }
            else if (rdyBtnLabDecFailExt.Checked || hdnExtFail.Value == "0")
            {
                fabricInspectSystem.LabDecisionExternal = 0;
            }
            else
            {
                fabricInspectSystem.LabDecisionExternal = -1;
            }
            if (rdyBtnLabDecPassInter.Checked || hdnIntPass.Value == "1")
            {

                fabricInspectSystem.LabdecisionInternal = 1;
            }
            else if (rdyBtnLabDecFailInter.Checked || hdnIntFail.Value == "0")
            {

                fabricInspectSystem.LabdecisionInternal = 0;
            }
            else
            {
                fabricInspectSystem.LabdecisionInternal = -1;

            }
            if (rbtFinalDecisionPass.Checked && !rdybtnComeercialPass.Checked)
            {
                //FinalDecision = true;
                if (hdnUserid.Value != "15")
                {
                    fabricInspectSystem.FinalDecision = 1;
                }
                else
                {
                    fabricInspectSystem.FinalDecision = Convert.ToInt32(hdnFinalDecissionPass.Value);
                }

            }
            else if (hdnUserid.Value == "15" && hdnFinalDecissionPass.Value == "1" && hdnDecissionCommercialpass.Value != "1")
            {
                //FinalDecision = false;
                //  fabricInspectSystem.FinalDecision = 1;

                fabricInspectSystem.FinalDecision = Convert.ToInt32(hdnFinalDecissionPass.Value);


            }
            else if (hdnUserid.Value != "15" && rbtFinalDecisionFail.Checked)
            {


                fabricInspectSystem.FinalDecision = 0;
            }
            else
            {


            }

            if (hdnUserid.Value != "15")
            {
                if (!rdybtnComeercialPass.Checked && !rbtFinalDecisionPass.Checked && !rbtFinalDecisionFail.Checked)
                {
                    fabricInspectSystem.FinalDecision = -1;
                }
            }

            if (rbtFinalDecisionPass.Checked || rbtFinalDecisionFail.Checked)
            {
                //fabricInspectSystem.FinalDecisionDate = Convert.ToDateTime(DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss"));
                //fabricInspectSystem.FinalDecisionDate = (DateTime.ParseExact(lblFinalDecisionDate.Text, "dd MMM yy (ddd) HH:mm", System.Globalization.CultureInfo.InvariantCulture));
                if (lblFinalDecisionDate.Text == "")
                {
                    fabricInspectSystem.FinalDecisionDate = DateTime.Now;
                }
                else
                {
                    fabricInspectSystem.FinalDecisionDate = (DateTime.ParseExact(lblFinalDecisionDate.Text, "dd MMM yy (ddd) HH:mm", System.Globalization.CultureInfo.InvariantCulture));
                }
            }


            if (txtFailedRaisedDebit.Text != "")
            {
                fabricInspectSystem.FailedRaisedDebit = Convert.ToInt32(txtFailedRaisedDebit.Text.Replace(",", ""));
            }
            if (txtFailedStock.Text != "")
            {
                fabricInspectSystem.FailedStock = Convert.ToInt32(txtFailedStock.Text.Replace(",", ""));
            }
            if (txtFailedGoodStock.Text != "")
            {
                fabricInspectSystem.FailedGoodStock = Convert.ToInt32(txtFailedGoodStock.Text.Replace(",", ""));
            }
            //added on 2023-25-01 Start
            if (txtFailedParticular.Text != "")
            {
                fabricInspectSystem.FailedParticular = SRVNo.Text + " :" + txtFailedParticular.Text;
            }
            if (txtInspectParticular.Text != "")
            {
                fabricInspectSystem.InspectParticular = SRVNo.Text + " :" + txtInspectParticular.Text;
            }
            //added on 2023-25-01 End
            if (txtInspectRaisedDebit.Text != "")
            {
                fabricInspectSystem.InspectRaisedDebit = Convert.ToInt32(txtInspectRaisedDebit.Text.Replace(",", ""));
            }
            if (txtInspectUsableStock.Text != "")
            {
                fabricInspectSystem.InspectUsableStock = Convert.ToInt32(txtInspectUsableStock.Text.Replace(",", ""));
            }

            if (lblInspectExtraQty.Text != "")
            {
                fabricInspectSystem.TotalExternalQty = Convert.ToInt32(lblInspectExtraQty.Text.Replace(",", ""));
            }
            else if (lblTotalFailQty.Text == "" && lblInspectExtraQty.Text == "")
            {
                if (hdnUserid.Value == "148" && ChkFabricQa.Checked)
                {
                    // Commented by RSB on dated 21 March 2022
                    //ChkFabricGM.Checked = true;
                    //fabricInspectSystem.FabricGMBy = 2;

                }
            }


            fabricInspectSystem.IsLabManager = chkLabManager.Checked == true ? true : false;
            fabricInspectSystem.IsFabricGM = ChkFabricGM.Checked == true ? true : false;
            fabricInspectSystem.IsFabricQA = ChkFabricQa.Checked == true ? true : false;

            if (ChkFabricQa.Checked)
            {
                fabricInspectSystem.FabricQABy = ApplicationHelper.LoggedInUser.UserData.UserID;

            }

            if (ChkFabricGM.Checked && hdnUserid.Value != "148")
            {
                fabricInspectSystem.FabricGMBy = ApplicationHelper.LoggedInUser.UserData.UserID;
            }

            if (chkLabManager.Checked)
            {
                fabricInspectSystem.LabManagerBy = ApplicationHelper.LoggedInUser.UserData.UserID;
            }

            if (chkLabManager.Checked == true && lblLabDatetime.Text == "")
            //if (chkLabManager.Checked == true && chkLabManager.Enabled!=false)
            {// for new amendment approve date on external sent to lab by 
                if ((chkInternalSentToLab.Checked && chkExternalSentToLab.Checked) && LabReport == 1)
                {
                    fabricInspectSystem.LabManagerApprovedDate = DateTime.Now;
                }
                else if (chkInternalSentToLab.Checked && chkExternalSentToLab.Checked)
                {

                    fabricInspectSystem.LabManagerApprovedDate = DateTime.Now;
                }
                // till here by shubhendu  
            }
            if (ChkFabricQa.Checked == true && lblQADatetime.Text == "")
            //if (ChkFabricQa.Checked == true && ChkFabricQa.Enabled != false)
            {
                fabricInspectSystem.FabricQAUpdatedOn = DateTime.Now;
            }
            if (ChkFabricGM.Checked == true && lblGMDateTime.Text == "")
            //if (ChkFabricGM.Checked == true && ChkFabricGM.Enabled != false)
            {
                fabricInspectSystem.FabricGMUpdatedOn = DateTime.Now;
            }
            //new code end

            if (txtcheckname1.Text == string.Empty)
            {
                ShowAlert("A checker name is mandatory!");
                //txtCheckerName1.Focus();
                txtcheckname1.Attributes.Add("style", "border-color:red");
                return;
            }
            else
            {
                txtcheckname1.Attributes.Add("style", "border-color:black");
            }
            if (ddlunitname.SelectedValue == "-1")
            {
                ShowAlert("Select Allocated Unit!");
                return;
            }


            if (ChkFabricQa.Checked == true)
            {
                if (grdfourpointcheck.Rows.Count > 0)
                {
                    if ((Convert.ToDecimal(lblQty.Text.Replace(",", "")) != Convert.ToDecimal(lblTotalActualLength.Text.Replace(",", ""))) && (Convert.ToDecimal(lblTotalClaimedLength.Text.Replace(",", "")) != Convert.ToDecimal(lblTotalActualLength.Text.Replace(",", ""))))
                    //if (Convert.ToDecimal(lblQty.Text.Replace(",", "")) != Convert.ToDecimal(lblTotalActualLength.Text.Replace(",", "")))
                    {
                        //ShowAlert("If actual quantity is greater than claimed quantity then revise SRV get revised.");
                        ShowAlert("If actual quantity and claimed quantity have differences then SRV get revised.");
                    }
                }
            }

            //new code end 04-02-2021









            //Commentes = txtComments.Text;
            //if (txtInternalLabSpecimanCount.Text != "" && txtInternalLabSpecimanCount.Text != null)
            //{
            //    LabInternalSpecimanCount =  Convert.ToInt32(txtInternalLabSpecimanCount.Text);
            //}
            //InternalSentToLab = chkInternalSentToLab.Checked == true ? true : false;
            //if (chkInternalSentToLab.Checked)
            //{
            //    InternalSentToLabDate = DateTime.Now;
            //}
            //InternalReceivedInLab = chkInternalReceivedInLab.Checked == true ? true : false;
            //if (chkInternalReceivedInLab.Checked)
            //{
            //    InternalReceivedInLabDate = DateTime.Now;
            //}

            //if (uploadInternalLabReport.HasFile)
            //{
            //    string Exten = System.IO.Path.GetExtension(uploadInternalLabReport.FileName);
            //    string ActualfileName = "Internal_Lab_Report_" + uploadInternalLabReport.FileName;
            //    string Name = ActualfileName.Substring(0, ActualfileName.LastIndexOf('.'));
            //    InternalLabReport = FileHelper.SaveFile(uploadInternalLabReport.PostedFile.InputStream, uploadInternalLabReport.FileName, Constants.PHOTO_FOLDER_PATH, true, Name);                
            //    hylnkInternalLabReport.Visible = false;
            //}
            //if (txtExternalLabSpecimanCount.Text != "" && txtExternalLabSpecimanCount.Text != null)
            //{
            //    LabExternalSpecimanCount = Convert.ToInt32(txtExternalLabSpecimanCount.Text);
            //}
            //ExternalSentToLab = chkExternalSentToLab.Checked == true ? true : false;
            //if (chkExternalSentToLab.Checked)
            //{
            //    ExternalSentToLabDate = DateTime.Now;
            //}
            //ExternalReceivedInLab = chkExternalReceivedInLab.Checked == true ? true : false;
            //if (chkExternalReceivedInLab.Checked)
            //{
            //    ExternalReceivedInLabDate = DateTime.Now;
            //}

            //if (uploadExternalLabReport.HasFile)
            //{
            //    string Exten = System.IO.Path.GetExtension(uploadExternalLabReport.FileName);
            //    string ActualfileName = "Internal_Lab_Report_" + uploadExternalLabReport.FileName;
            //    string Name = ActualfileName.Substring(0, ActualfileName.LastIndexOf('.'));
            //    ExternalLabReport = FileHelper.SaveFile(uploadInternalLabReport.PostedFile.InputStream, uploadInternalLabReport.FileName, Constants.PHOTO_FOLDER_PATH, true, Name);
            //    hylnkExternalLabReport.Visible = false;
            //}

            //if (rbtFinalDecisionPass.Checked)
            //{
            //    FinalDecision = true;
            //}
            //else if (rbtFinalDecisionFail.Checked)
            //{
            //    FinalDecision = false;
            //}

            //if (txtFailedRaisedDebit.Text != "" && txtFailedRaisedDebit.Text != null)
            //{
            //    RaiseDebit = Convert.ToInt32(txtFailedRaisedDebit.Text);
            //}
            //if (txtFailedStock.Text != "" && txtFailedStock.Text != null)
            //{
            //    FailStock = Convert.ToInt32(txtFailedStock.Text);
            //}
            //if (txtFailedGoodStock.Text != "" && txtFailedGoodStock.Text != null)
            //{
            //    GoodStock = Convert.ToInt32(txtFailedGoodStock.Text);
            //}
            //if (txtFailedParticular.Text != "" && txtFailedParticular.Text != null)
            //{
            //    FailedParticular = txtFailedParticular.Text;
            //}
            //if (txtInspectRaisedDebit.Text != "" && txtInspectRaisedDebit.Text != null)
            //{
            //    InspectRaiseDebit = Convert.ToInt32(txtInspectRaisedDebit.Text);
            //}
            //if (txtInspectUsableStock.Text != "" && txtInspectUsableStock.Text != null)
            //{
            //    InspectUsableDebit = Convert.ToInt32(txtInspectUsableStock.Text);
            //}
            //if (txtInspectParticular.Text != "" && txtInspectParticular.Text != null)
            //{
            //    InspectParticular = txtInspectParticular.Text;
            //}

            //if (txtcheckname1.Text == string.Empty && txtcheckname1.Text != null)
            //{
            //    ShowAlert("Checker Name First cannot blank!");
            //    return;
            //}
            //else
            //{
            //    CheckerName1 = txtcheckname1.Text;
            //}

            //if (txtcheckname2.Text != string.Empty && txtcheckname2.Text != null)
            //{
            //    CheckerName2 = txtcheckname2.Text;
            //}
            //if (txtcheckname3.Text != string.Empty && txtcheckname3.Text != null)
            //{
            //    CheckerName3 = txtcheckname3.Text;
            //}

            //if (ddlunitname.SelectedValue == "-1")
            //{
            //    ShowAlert("Select Allocated Unit!");
            //    return;
            //}
            ////new code end 02-02-2021 
            //else
            //{
            //    AllocatedUnit = Convert.ToInt32(ddlunitname.SelectedValue);
            //}
            //IsLabManager = chkLabManager.Checked == true ? true : false;
            //IsFabricQA = ChkFabricQa.Checked == true ? true : false;
            //IsFabricGM = ChkFabricGM.Checked == true ? true : false;
            //QcNames = txtcheckname1.Text + "," + txtcheckname2.Text + "," + txtcheckname3.Text;

            //DataTable dt = fabobj.GetFabFourPointCheckUpdateBasic(SupplierPoID, SrvID, Inspectioedate, AllocatedUnit, ReceivedQty, CheckedQty, PassQty, HoldQty, FailQty, iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.UserID, Commentes, QcNames, IsFabricQA, IsCuttingQA, IsFabricGM);
            //Need to update order id and order detail id in this function by surendra on 12 june 2019

            //DataTable dt = fabobj.GetFabFourPointCheckUpdateBasic(SupplierPoID, SrvID, Inspectioedate, AllocatedUnit, ReceivedQty, CheckedQty, PassQty, HoldQty, FailQty, iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.UserID, orderid, OrderDetailID, Commentes, LabInternalSpecimanCount, InternalSentToLab, InternalSentToLabDate, InternalReceivedInLab, InternalReceivedInLabDate, InternalLabReport, LabExternalSpecimanCount, ExternalSentToLab, ExternalSentToLabDate, ExternalReceivedInLab, ExternalReceivedInLabDate, ExternalLabReport, FinalDecision, RaiseDebit, FailStock, GoodStock, FailedParticular, InspectRaiseDebit, InspectUsableDebit, InspectParticular, CheckerName1, CheckerName2, CheckerName3, IsLabManager, IsFabricQA, IsFabricGM);

            DataTable dt = fabobj.GetFabFourPointCheckUpdateBasic(fabricInspectSystem);

            FourPointCheck_Id = Convert.ToInt32(dt.Rows[0]["FourPointCheck_Id"].ToString());

            if (FourPointCheck_Id > 0)
            {
                DataTable dtdelete = fabobj.GetFabFourPointCheckUpdateDelete(FourPointCheck_Id);
                FabricInspect fabricInspect = new FabricInspect();

                fabricInspect.Inspection_Id = FourPointCheck_Id;

                if (grdfourpointcheck.Rows.Count >= 0)
                {
                    int i = 0;
                    for (; i < grdfourpointcheck.Rows.Count; i++)
                    {
                        try
                        {
                            if (((Label)grdfourpointcheck.Rows[i].FindControl("lblrollno_item")).Text != "")
                            {
                                //RollNumber = Convert.ToInt32(((Label)grdfourpointcheck.Rows[i].FindControl("lblrollno_item")).Text);
                                fabricInspect.BoxNo = Convert.ToInt32(((Label)grdfourpointcheck.Rows[i].FindControl("lblrollno_item")).Text);
                            }
                            else
                            {
                                fabricInspect.BoxNo = 0;
                            }

                            if (((Label)grdfourpointcheck.Rows[i].FindControl("lbldeilot_item")).Text != "")
                            {
                                //DeitLotNumber = Convert.ToInt32(((Label)grdfourpointcheck.Rows[i].FindControl("lbldeilot_item")).Text);
                                string lbldeilot_item = ((Label)grdfourpointcheck.Rows[i].FindControl("lbldeilot_item")).Text.Replace(",", "");

                                //fabricInspect.DieLot = Convert.ToInt32(((Label)grdfourpointcheck.Rows[i].FindControl("lbldeilot_item")).Text);
                                fabricInspect.DieLot = Convert.ToInt32(lbldeilot_item);
                            }
                            else
                            {
                                fabricInspect.DieLot = 0;
                            }
                            //new code start
                            if (((Label)grdfourpointcheck.Rows[i].FindControl("lblclaimedlength_item")).Text != "")
                            {
                                //ClaimedQty = Convert.ToDecimal(((Label)grdfourpointcheck.Rows[i].FindControl("lblclaimedlength_item")).Text);
                                fabricInspect.ClaimedLength = Convert.ToDecimal(((Label)grdfourpointcheck.Rows[i].FindControl("lblclaimedlength_item")).Text);
                            }
                            else
                            {
                                fabricInspect.ClaimedLength = 0;
                            }
                            //new code end
                            if (((Label)grdfourpointcheck.Rows[i].FindControl("lblactlenght_item")).Text != "")
                            {
                                //ActualLength = Convert.ToDecimal(((Label)grdfourpointcheck.Rows[i].FindControl("lblactlenght_item")).Text);
                                fabricInspect.ActLength = Convert.ToDecimal(((Label)grdfourpointcheck.Rows[i].FindControl("lblactlenght_item")).Text);
                            }
                            else
                            {
                                fabricInspect.ActLength = 0;
                            }
                            if (((Label)grdfourpointcheck.Rows[i].FindControl("lblwidth_S_item")).Text != "")
                            {
                                //Width_S = Convert.ToDecimal(((Label)grdfourpointcheck.Rows[i].FindControl("lblwidth_S_item")).Text);
                                fabricInspect.Width_S = Convert.ToDecimal(((Label)grdfourpointcheck.Rows[i].FindControl("lblwidth_S_item")).Text);
                            }
                            else
                            {
                                fabricInspect.Width_S = 0;
                            }
                            if (((Label)grdfourpointcheck.Rows[i].FindControl("lblwidth_M_item")).Text != "")
                            {
                                //Width_M = Convert.ToDecimal(((Label)grdfourpointcheck.Rows[i].FindControl("lblwidth_M_item")).Text);
                                fabricInspect.Width_M = Convert.ToDecimal(((Label)grdfourpointcheck.Rows[i].FindControl("lblwidth_M_item")).Text);
                            }
                            else
                            {
                                fabricInspect.Width_M = 0;
                            }
                            if (((Label)grdfourpointcheck.Rows[i].FindControl("lblwidth_E_item")).Text != "")
                            {
                                // Width_E = Convert.ToDecimal(((Label)grdfourpointcheck.Rows[i].FindControl("lblwidth_E_item")).Text);
                                fabricInspect.Width_E = Convert.ToDecimal(((Label)grdfourpointcheck.Rows[i].FindControl("lblwidth_E_item")).Text);
                            }
                            else
                            {
                                fabricInspect.Width_E = 0;
                            }
                            if (((Label)grdfourpointcheck.Rows[i].FindControl("lblwidth_weaving1_item")).Text != "")
                            {
                                //Weaving_1 = Convert.ToDecimal(((Label)grdfourpointcheck.Rows[i].FindControl("lblwidth_weaving1_item")).Text);
                                fabricInspect.Weaving_1 = Convert.ToDecimal(((Label)grdfourpointcheck.Rows[i].FindControl("lblwidth_weaving1_item")).Text);
                            }
                            else
                            {
                                fabricInspect.Weaving_1 = 0;
                            }
                            if (((Label)grdfourpointcheck.Rows[i].FindControl("lblwidth_weaving2_item")).Text != "")
                            {
                                //Weaving_2 = Convert.ToDecimal(((Label)grdfourpointcheck.Rows[i].FindControl("lblwidth_weaving2_item")).Text);
                                fabricInspect.Weaving_2 = Convert.ToDecimal(((Label)grdfourpointcheck.Rows[i].FindControl("lblwidth_weaving2_item")).Text);
                            }
                            else
                            {
                                fabricInspect.Weaving_2 = 0;
                            }
                            if (((Label)grdfourpointcheck.Rows[i].FindControl("lblwidth_weaving3_item")).Text != "")
                            {
                                //Weaving_3 = Convert.ToDecimal(((Label)grdfourpointcheck.Rows[i].FindControl("lblwidth_weaving3_item")).Text);
                                fabricInspect.Weaving_3 = Convert.ToDecimal(((Label)grdfourpointcheck.Rows[i].FindControl("lblwidth_weaving3_item")).Text);
                            }
                            else
                            {
                                fabricInspect.Weaving_3 = 0;
                            }
                            if (((Label)grdfourpointcheck.Rows[i].FindControl("lblwidth_weaving4_item")).Text != "")
                            {
                                //Weaving_4 = Convert.ToDecimal(((Label)grdfourpointcheck.Rows[i].FindControl("lblwidth_weaving4_item")).Text);
                                fabricInspect.Weaving_4 = Convert.ToDecimal(((Label)grdfourpointcheck.Rows[i].FindControl("lblwidth_weaving4_item")).Text);
                            }
                            else
                            {
                                fabricInspect.Weaving_4 = 0;
                            }
                            if (((Label)grdfourpointcheck.Rows[i].FindControl("lblpatta_item")).Text != "")
                            {
                                //Patta = Convert.ToDecimal(((Label)grdfourpointcheck.Rows[i].FindControl("lblpatta_item")).Text);
                                fabricInspect.Patta = Convert.ToDecimal(((Label)grdfourpointcheck.Rows[i].FindControl("lblpatta_item")).Text);
                            }
                            else
                            {
                                fabricInspect.Patta = 0;
                            }
                            if (((Label)grdfourpointcheck.Rows[i].FindControl("lblhole_item")).Text != "")
                            {
                                // Hole = Convert.ToDecimal(((Label)grdfourpointcheck.Rows[i].FindControl("lblhole_item")).Text);
                                fabricInspect.Hole = Convert.ToDecimal(((Label)grdfourpointcheck.Rows[i].FindControl("lblhole_item")).Text);
                            }
                            else
                            {
                                fabricInspect.Hole = 0;
                            }
                            if (((Label)grdfourpointcheck.Rows[i].FindControl("lblprintdyeingdefacts1_item")).Text != "")
                            {
                                //PrintedDefectes_1 = Convert.ToDecimal(((Label)grdfourpointcheck.Rows[i].FindControl("lblprintdyeingdefacts1_item")).Text);
                                fabricInspect.PrintedDefectes_1 = Convert.ToDecimal(((Label)grdfourpointcheck.Rows[i].FindControl("lblprintdyeingdefacts1_item")).Text);
                            }
                            else
                            {
                                fabricInspect.PrintedDefectes_1 = 0;
                            }
                            if (((Label)grdfourpointcheck.Rows[i].FindControl("lblprintdyeingdefacts2_item")).Text != "")
                            {
                                //PrintedDefectes_2 = Convert.ToDecimal(((Label)grdfourpointcheck.Rows[i].FindControl("lblprintdyeingdefacts2_item")).Text);
                                fabricInspect.PrintedDefectes_2 = Convert.ToDecimal(((Label)grdfourpointcheck.Rows[i].FindControl("lblprintdyeingdefacts2_item")).Text);
                            }
                            else
                            {
                                fabricInspect.PrintedDefectes_2 = 0;
                            }
                            if (((Label)grdfourpointcheck.Rows[i].FindControl("lblprintdyeingdefacts3_item")).Text != "")
                            {
                                //PrintedDefectes_3 = Convert.ToDecimal(((Label)grdfourpointcheck.Rows[i].FindControl("lblprintdyeingdefacts3_item")).Text);
                                fabricInspect.PrintedDefectes_3 = Convert.ToDecimal(((Label)grdfourpointcheck.Rows[i].FindControl("lblprintdyeingdefacts3_item")).Text);
                            }
                            else
                            {
                                fabricInspect.PrintedDefectes_3 = 0;
                            }
                            if (((Label)grdfourpointcheck.Rows[i].FindControl("lblprintdyeingdefacts4_item")).Text != "")
                            {
                                //PrintedDefectes_4 = Convert.ToDecimal(((Label)grdfourpointcheck.Rows[i].FindControl("lblprintdyeingdefacts4_item")).Text);
                                fabricInspect.PrintedDefectes_4 = Convert.ToDecimal(((Label)grdfourpointcheck.Rows[i].FindControl("lblprintdyeingdefacts4_item")).Text);
                            }
                            else
                            {
                                fabricInspect.PrintedDefectes_4 = 0;
                            }

                            if (((Label)grdfourpointcheck.Rows[i].FindControl("lblweapointyard_item")).Text != "")
                            {
                                // WeaPointsPerSquirdYards = Convert.ToDecimal(((Label)grdfourpointcheck.Rows[i].FindControl("lblweapointyard_item")).Text);
                                fabricInspect.WeaPointsPerSquirdYards = Convert.ToDecimal(((Label)grdfourpointcheck.Rows[i].FindControl("lblweapointyard_item")).Text);
                            }
                            else
                            {
                                fabricInspect.WeaPointsPerSquirdYards = 0;
                            }

                            if (((Label)grdfourpointcheck.Rows[i].FindControl("lblstatus_item")).Text.ToLower() == "Pass".ToLower())
                            {
                                //statuss = "1";
                                fabricInspect.Decision = "1";
                            }
                            else if (((Label)grdfourpointcheck.Rows[i].FindControl("lblstatus_item")).Text.ToLower() == "Fail".ToLower())
                            {
                                //statuss = "2";
                                fabricInspect.Decision = "2";
                            }
                            else
                            {
                                //statuss = "-1";
                                fabricInspect.Decision = "-1";
                            }

                            //new code start 02-02-2021
                            if (((Label)grdfourpointcheck.Rows[i].FindControl("lblchkd_item")).Text != "")
                            {
                                //CheckedQty = Convert.ToDecimal(((Label)grdfourpointcheck.Rows[i].FindControl("lblchkd_item")).Text);
                                fabricInspect.CheckedQty = Convert.ToDecimal(((Label)grdfourpointcheck.Rows[i].FindControl("lblchkd_item")).Text);
                            }
                            else
                            {
                                fabricInspect.CheckedQty = 0;
                            }
                            if (((Label)grdfourpointcheck.Rows[i].FindControl("lblpass_item")).Text != "")
                            {
                                //PassQty = Convert.ToDecimal(((Label)grdfourpointcheck.Rows[i].FindControl("lblpass_item")).Text);
                                fabricInspect.PassQty = Convert.ToDecimal(((Label)grdfourpointcheck.Rows[i].FindControl("lblpass_item")).Text);
                            }
                            else
                            {
                                fabricInspect.PassQty = 0;
                            }
                            if (((Label)grdfourpointcheck.Rows[i].FindControl("lblhold_item")).Text != "")
                            {
                                //HoldQty = Convert.ToDecimal(((Label)grdfourpointcheck.Rows[i].FindControl("lblhold_item")).Text);
                                fabricInspect.HoldQty = Convert.ToDecimal(((Label)grdfourpointcheck.Rows[i].FindControl("lblhold_item")).Text);
                            }
                            else
                            {
                                fabricInspect.HoldQty = 0;
                            }
                            if (((Label)grdfourpointcheck.Rows[i].FindControl("lblfail_item")).Text != "")
                            {
                                //FailQty = Convert.ToDecimal(((Label)grdfourpointcheck.Rows[i].FindControl("lblfail_item")).Text);
                                fabricInspect.FailQty = Convert.ToDecimal(((Label)grdfourpointcheck.Rows[i].FindControl("lblfail_item")).Text);
                            }
                            else
                            {
                                fabricInspect.FailQty = 0;
                            }
                            fabricInspect.CreatedBy = iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.UserID;
                            //new code end 02-02-2021
                        }
                        catch (Exception ex)
                        {
                            if (((TextBox)grdfourpointcheck.Rows[i].FindControl("txtrollno_Edit")).Text != "")
                            {
                                fabricInspect.BoxNo = Convert.ToInt32(((TextBox)grdfourpointcheck.Rows[i].FindControl("txtrollno_Edit")).Text.Trim());
                            }
                            else
                            {
                                fabricInspect.BoxNo = 0;
                            }

                            if (((TextBox)grdfourpointcheck.Rows[i].FindControl("txtdeilot_Edit")).Text != "")
                            {
                                int deilot_Edit = Convert.ToInt32(((TextBox)grdfourpointcheck.Rows[i].FindControl("txtdeilot_Edit")).Text.Trim().Replace(",", ""));
                                fabricInspect.DieLot = deilot_Edit;
                            }
                            else
                            {
                                fabricInspect.DieLot = 0;
                            }
                            //new code start
                            if (((TextBox)grdfourpointcheck.Rows[i].FindControl("txtclaimedlength_Edit")).Text != "")
                            {
                                fabricInspect.ClaimedLength = Convert.ToDecimal(((TextBox)grdfourpointcheck.Rows[i].FindControl("txtclaimedlength_Edit")).Text.Trim());
                            }
                            else
                            {
                                fabricInspect.ClaimedLength = 0;
                            }
                            //new code end
                            if (((TextBox)grdfourpointcheck.Rows[i].FindControl("txtactlenght_Edit")).Text != "")
                            {
                                fabricInspect.ActLength = Convert.ToDecimal(((TextBox)grdfourpointcheck.Rows[i].FindControl("txtactlenght_Edit")).Text.Trim());
                            }
                            else
                            {
                                fabricInspect.ActLength = 0;
                            }
                            if (((TextBox)grdfourpointcheck.Rows[i].FindControl("txtwidth_S_Edit")).Text != "")
                            {
                                fabricInspect.Width_S = Convert.ToDecimal(((TextBox)grdfourpointcheck.Rows[i].FindControl("txtwidth_S_Edit")).Text.Trim());
                            }
                            else
                            {
                                fabricInspect.Width_S = 0;
                            }
                            if (((TextBox)grdfourpointcheck.Rows[i].FindControl("txtwidth_M_Edit")).Text != "")
                            {
                                fabricInspect.Width_M = Convert.ToDecimal(((TextBox)grdfourpointcheck.Rows[i].FindControl("txtwidth_M_Edit")).Text.Trim());
                            }
                            else
                            {
                                fabricInspect.Width_M = 0;
                            }
                            if (((TextBox)grdfourpointcheck.Rows[i].FindControl("txtwidth_E_Edit")).Text != "")
                            {
                                fabricInspect.Width_E = Convert.ToDecimal(((TextBox)grdfourpointcheck.Rows[i].FindControl("txtwidth_E_Edit")).Text.Trim());
                            }
                            else
                            {
                                fabricInspect.Width_E = 0;
                            }
                            if (((TextBox)grdfourpointcheck.Rows[i].FindControl("txtwidth_weaving1_Edit")).Text != "")
                            {
                                fabricInspect.Weaving_1 = Convert.ToDecimal(((TextBox)grdfourpointcheck.Rows[i].FindControl("txtwidth_weaving1_Edit")).Text.Trim());
                            }
                            else
                            {
                                fabricInspect.Weaving_1 = 0;
                            }
                            if (((TextBox)grdfourpointcheck.Rows[i].FindControl("txtwidth_weaving2_Edit")).Text != "")
                            {
                                fabricInspect.Weaving_2 = Convert.ToDecimal(((TextBox)grdfourpointcheck.Rows[i].FindControl("txtwidth_weaving2_Edit")).Text.Trim());
                            }
                            else
                            {
                                fabricInspect.Weaving_2 = 0;
                            }
                            if (((TextBox)grdfourpointcheck.Rows[i].FindControl("txtwidth_weaving3_Edit")).Text != "")
                            {
                                fabricInspect.Weaving_3 = Convert.ToDecimal(((TextBox)grdfourpointcheck.Rows[i].FindControl("txtwidth_weaving3_Edit")).Text.Trim());
                            }
                            else
                            {
                                fabricInspect.Weaving_3 = 0;
                            }
                            if (((TextBox)grdfourpointcheck.Rows[i].FindControl("txtwidth_weaving4_Edit")).Text != "")
                            {
                                fabricInspect.Weaving_4 = Convert.ToDecimal(((TextBox)grdfourpointcheck.Rows[i].FindControl("txtwidth_weaving4_Edit")).Text.Trim());
                            }
                            else
                            {
                                fabricInspect.Weaving_4 = 0;
                            }
                            if (((TextBox)grdfourpointcheck.Rows[i].FindControl("txtpatta_Edit")).Text != "")
                            {
                                fabricInspect.Patta = Convert.ToDecimal(((TextBox)grdfourpointcheck.Rows[i].FindControl("txtpatta_Edit")).Text.Trim());
                            }
                            else
                            {
                                fabricInspect.Patta = 0;
                            }
                            if (((TextBox)grdfourpointcheck.Rows[i].FindControl("txthole_Edit")).Text != "")
                            {
                                fabricInspect.Hole = Convert.ToDecimal(((TextBox)grdfourpointcheck.Rows[i].FindControl("txthole_Edit")).Text.Trim());
                            }
                            else
                            {
                                fabricInspect.Hole = 0;
                            }
                            if (((TextBox)grdfourpointcheck.Rows[i].FindControl("txtprintdyeingdefacts1_Edit")).Text != "")
                            {
                                fabricInspect.PrintedDefectes_1 = Convert.ToDecimal(((TextBox)grdfourpointcheck.Rows[i].FindControl("txtprintdyeingdefacts1_Edit")).Text.Trim());
                            }
                            else
                            {
                                fabricInspect.PrintedDefectes_1 = 0;
                            }
                            if (((TextBox)grdfourpointcheck.Rows[i].FindControl("txtprintdyeingdefacts2_Edit")).Text != "")
                            {
                                fabricInspect.PrintedDefectes_2 = Convert.ToDecimal(((TextBox)grdfourpointcheck.Rows[i].FindControl("txtprintdyeingdefacts2_Edit")).Text.Trim());
                            }
                            else
                            {
                                fabricInspect.PrintedDefectes_2 = 0;
                            }
                            if (((TextBox)grdfourpointcheck.Rows[i].FindControl("txtprintdyeingdefacts3_Edit")).Text != "")
                            {
                                fabricInspect.PrintedDefectes_3 = Convert.ToDecimal(((TextBox)grdfourpointcheck.Rows[i].FindControl("txtprintdyeingdefacts3_Edit")).Text.Trim());
                            }
                            else
                            {
                                fabricInspect.PrintedDefectes_3 = 0;
                            }
                            if (((TextBox)grdfourpointcheck.Rows[i].FindControl("txtprintdyeingdefacts4_Edit")).Text != "")
                            {
                                fabricInspect.PrintedDefectes_4 = Convert.ToDecimal(((TextBox)grdfourpointcheck.Rows[i].FindControl("txtprintdyeingdefacts4_Edit")).Text.Trim());
                            }
                            else
                            {
                                fabricInspect.PrintedDefectes_4 = 0;
                            }

                            if (((TextBox)grdfourpointcheck.Rows[i].FindControl("txtweapointyard_Edit")).Text != "")
                            {
                                fabricInspect.WeaPointsPerSquirdYards = Convert.ToDecimal(((TextBox)grdfourpointcheck.Rows[i].FindControl("txtweapointyard_Edit")).Text.Trim());
                            }
                            else
                            {
                                fabricInspect.WeaPointsPerSquirdYards = 0;
                            }

                            if (((DropDownList)grdfourpointcheck.Rows[i].FindControl("ddlstatus_Edit")).SelectedItem.Text.ToLower() == "Pass".ToLower())
                            {
                                fabricInspect.Decision = "1";

                            }
                            else if (((DropDownList)grdfourpointcheck.Rows[i].FindControl("ddlstatus_Edit")).SelectedItem.Text.ToLower() == "Fail".ToLower())
                            {
                                fabricInspect.Decision = "2";
                                //statusnarration = "fail";
                            }
                            else
                            {
                                fabricInspect.Decision = "-1";
                            }

                            //new code start 02-02-2021
                            if (((TextBox)grdfourpointcheck.Rows[i].FindControl("txtchkd_Edit")).Text != "")
                            {
                                fabricInspect.CheckedQty = Convert.ToDecimal(((TextBox)grdfourpointcheck.Rows[i].FindControl("txtchkd_Edit")).Text.Trim());
                            }
                            else
                            {
                                fabricInspect.CheckedQty = 0;
                            }
                            if (((TextBox)grdfourpointcheck.Rows[i].FindControl("txtpass_Edit")).Text != "")
                            {
                                fabricInspect.PassQty = Convert.ToDecimal(((TextBox)grdfourpointcheck.Rows[i].FindControl("txtpass_Edit")).Text.Trim());
                            }
                            else
                            {
                                fabricInspect.PassQty = 0;
                            }
                            if (((TextBox)grdfourpointcheck.Rows[i].FindControl("txthold_Edit")).Text != "")
                            {
                                fabricInspect.HoldQty = Convert.ToDecimal(((TextBox)grdfourpointcheck.Rows[i].FindControl("txthold_Edit")).Text.Trim());
                            }
                            else
                            {
                                fabricInspect.HoldQty = 0;
                            }
                            if (((TextBox)grdfourpointcheck.Rows[i].FindControl("txtfail_Edit")).Text != "")
                            {
                                fabricInspect.FailQty = Convert.ToDecimal(((TextBox)grdfourpointcheck.Rows[i].FindControl("txtfail_Edit")).Text.Trim());
                            }
                            else
                            {
                                fabricInspect.FailQty = 0;
                            }
                            fabricInspect.CreatedBy = iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.UserID;
                            //new code end 02-02-2021

                            System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                            System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));

                        }
                        //if (RollNumber > 0 && Width_S > 0)
                        if (fabricInspect.BoxNo > 0 && fabricInspect.Width_S > 0)
                        {

                            dtresult = fabobj.GetFabFourPointCheckUpdateDetails(fabricInspect);
                            //dtresult = fabobj.GetFabFourPointCheckUpdateDetails(FourPointCheck_Id, RollNumber, DeitLotNumber, ClaimedQty, ActualLength, CheckedQty,PassQty,HoldQty,FailQty, Width_S, Width_M, Width_E, Weaving_1, Weaving_2, Weaving_3, Weaving_4, Patta, Hole, PrintedDefectes_1, PrintedDefectes_2, PrintedDefectes_3, PrintedDefectes_4, WeaPointsPerSquirdYards, Convert.ToInt32(statuss));
                            //issaive = "save";
                        }
                    }

                }
                if (grdfourpointcheck.Rows.Count == 0)
                {

                    FabricInspect fabricInspect2 = new FabricInspect();

                    fabricInspect2.Inspection_Id = FourPointCheck_Id;

                    RollNumber = 0;
                    DeitLotNumber = 0;
                    ClaimedQty = 0; //new line
                    ActualLength = 0;
                    Width_S = 0;
                    Width_M = 0;
                    Width_E = 0;
                    Weaving_1 = 0;
                    Weaving_2 = 0;
                    Weaving_3 = 0;
                    Weaving_4 = 0;
                    Patta = 0;
                    Hole = 0;
                    PrintedDefectes_1 = 0;
                    PrintedDefectes_2 = 0;
                    PrintedDefectes_3 = 0;
                    PrintedDefectes_4 = 0;
                    WeaPointsPerSquirdYards = 0;

                    CheckedQty = 0; //new line 02-02-2021
                    PassQty = 0; //new line 02-02-2021
                    HoldQty = 0; //new line 02-02-2021
                    FailQty = 0; //new line 02-02-2021

                    TextBox txtrollno_emptyrow = grdfourpointcheck.Controls[0].Controls[0].FindControl("txtrollno_emptyrow") as TextBox;
                    TextBox txtdeilot_emptyrow = grdfourpointcheck.Controls[0].Controls[0].FindControl("txtdeilot_emptyrow") as TextBox;
                    TextBox txtclaimedlength_emptyrow = grdfourpointcheck.Controls[0].Controls[0].FindControl("txtclaimedlength_emptyrow") as TextBox; //new line
                    TextBox txtactlenght_emptyrow = grdfourpointcheck.Controls[0].Controls[0].FindControl("txtactlenght_emptyrow") as TextBox;
                    TextBox txtwithd_s_emptyrow = grdfourpointcheck.Controls[0].Controls[0].FindControl("txtwithd_s_emptyrow") as TextBox;
                    TextBox txtwithd_M_emptyrow = grdfourpointcheck.Controls[0].Controls[0].FindControl("txtwithd_M_emptyrow") as TextBox;
                    TextBox txtwithd_E_emptyrow = grdfourpointcheck.Controls[0].Controls[0].FindControl("txtwithd_E_emptyrow") as TextBox;
                    TextBox txtweaving_1_emptyrow = grdfourpointcheck.Controls[0].Controls[0].FindControl("txtweaving_1_emptyrow") as TextBox;
                    TextBox txtweaving_2_emptyrow = grdfourpointcheck.Controls[0].Controls[0].FindControl("txtweaving_2_emptyrow") as TextBox;
                    TextBox txtweaving_3_emptyrow = grdfourpointcheck.Controls[0].Controls[0].FindControl("txtweaving_3_emptyrow") as TextBox;
                    TextBox txtweaving_4_emptyrow = grdfourpointcheck.Controls[0].Controls[0].FindControl("txtweaving_4_emptyrow") as TextBox;

                    TextBox txtpatta_emptyrow = grdfourpointcheck.Controls[0].Controls[0].FindControl("txtpatta_emptyrow") as TextBox;
                    TextBox txthole_emptyrow = grdfourpointcheck.Controls[0].Controls[0].FindControl("txthole_emptyrow") as TextBox;
                    TextBox txttotal2_emptyrow = grdfourpointcheck.Controls[0].Controls[0].FindControl("txttotal2_emptyrow") as TextBox;
                    TextBox txtprintdyeingdefacts1_emptyrow = grdfourpointcheck.Controls[0].Controls[0].FindControl("txtprintdyeingdefacts1_emptyrow") as TextBox;
                    TextBox txtprintdyeingdefacts2_emptyrow = grdfourpointcheck.Controls[0].Controls[0].FindControl("txtprintdyeingdefacts2_emptyrow") as TextBox;
                    TextBox txtprintdyeingdefacts3_emptyrow = grdfourpointcheck.Controls[0].Controls[0].FindControl("txtprintdyeingdefacts3_emptyrow") as TextBox;
                    TextBox txtprintdyeingdefacts4_emptyrow = grdfourpointcheck.Controls[0].Controls[0].FindControl("txtprintdyeingdefacts4_emptyrow") as TextBox;
                    TextBox txttotal3_emptyrow = grdfourpointcheck.Controls[0].Controls[0].FindControl("txttotal3_emptyrow") as TextBox;
                    TextBox txttotalpoint_emptyrow = grdfourpointcheck.Controls[0].Controls[0].FindControl("txttotalpoint_emptyrow") as TextBox;
                    TextBox txtweapointyard_emptyrow = grdfourpointcheck.Controls[0].Controls[0].FindControl("txtweapointyard_emptyrow") as TextBox;
                    DropDownList ddlstatus_emptyrow = grdfourpointcheck.Controls[0].Controls[0].FindControl("ddlstatus_emptyrow") as DropDownList;

                    TextBox txtcheckedlength_emptyrow = grdfourpointcheck.Controls[0].Controls[0].FindControl("txtcheckedlength_emptyrow") as TextBox; //new line 02-02-2021
                    TextBox txtpasslength_emptyrow = grdfourpointcheck.Controls[0].Controls[0].FindControl("txtpasslength_emptyrow") as TextBox; //new line 02-02-2021
                    TextBox txtholdlength_emptyrow = grdfourpointcheck.Controls[0].Controls[0].FindControl("txtholdlength_emptyrow") as TextBox; //new line 02-02-2021                    
                    TextBox txtfaillength_emptyrow = grdfourpointcheck.Controls[0].Controls[0].FindControl("txtfaillength_emptyrow") as TextBox; //new line 02-02-2021

                    //new code start 02-02-2021
                    if (txtcheckedlength_emptyrow.Text != "")
                    {
                        //CheckedQty = Convert.ToDecimal(txtcheckedlength_emptyrow.Text);
                        fabricInspect2.CheckedQty = Convert.ToDecimal(txtcheckedlength_emptyrow.Text);
                    }
                    else
                    {
                        fabricInspect2.CheckedQty = 0;
                    }
                    if (txtpasslength_emptyrow.Text != "")
                    {
                        //PassQty = Convert.ToDecimal(txtpasslength_emptyrow.Text);
                        fabricInspect2.PassQty = Convert.ToDecimal(txtpasslength_emptyrow.Text);
                    }
                    else
                    {
                        fabricInspect2.PassQty = 0;
                    }
                    if (txtholdlength_emptyrow.Text != "")
                    {
                        //HoldQty = Convert.ToDecimal(txtholdlength_emptyrow.Text);
                        fabricInspect2.HoldQty = Convert.ToDecimal(txtholdlength_emptyrow.Text);
                    }
                    else
                    {
                        fabricInspect2.HoldQty = 0;
                    }
                    if (txtfaillength_emptyrow.Text != "")
                    {
                        // FailQty = Convert.ToDecimal(txtfaillength_emptyrow.Text);
                        fabricInspect2.FailQty = Convert.ToDecimal(txtfaillength_emptyrow.Text);
                    }
                    else
                    {
                        fabricInspect2.FailQty = 0;
                    }
                    //new code end 02-02-2021

                    if (txtrollno_emptyrow.Text != "")
                    {
                        // RollNumber = Convert.ToInt32(txtrollno_emptyrow.Text);
                        fabricInspect2.BoxNo = Convert.ToInt32(txtrollno_emptyrow.Text);
                    }
                    else
                    {
                        fabricInspect2.BoxNo = 0;
                    }
                    if (txtdeilot_emptyrow.Text != "")
                    {
                        //DeitLotNumber = Convert.ToInt32(txtdeilot_emptyrow.Text);
                        fabricInspect2.DieLot = Convert.ToInt32(txtdeilot_emptyrow.Text);
                    }
                    else
                    {
                        fabricInspect2.DieLot = 0;
                    }
                    //new code start
                    if (txtclaimedlength_emptyrow.Text != "")
                    {
                        //ClaimedQty = Convert.ToDecimal(txtclaimedlength_emptyrow.Text);
                        fabricInspect2.ClaimedLength = Convert.ToDecimal(txtclaimedlength_emptyrow.Text);
                    }
                    else
                    {
                        fabricInspect2.ClaimedLength = 0;
                    }
                    //new code end

                    if (txtactlenght_emptyrow.Text != "")
                    {
                        //ActualLength = Convert.ToDecimal(txtactlenght_emptyrow.Text);
                        fabricInspect2.ActLength = Convert.ToDecimal(txtactlenght_emptyrow.Text);
                    }
                    else
                    {
                        fabricInspect2.ActLength = 0;
                    }
                    if (txtwithd_s_emptyrow.Text != "")
                    {
                        //Width_S = Convert.ToDecimal(txtwithd_s_emptyrow.Text);
                        fabricInspect2.Width_S = Convert.ToDecimal(txtwithd_s_emptyrow.Text);
                    }
                    else
                    {
                        fabricInspect2.Width_S = 0;
                    }
                    if (txtwithd_M_emptyrow.Text != "")
                    {
                        //Width_M = Convert.ToDecimal(txtwithd_M_emptyrow.Text);
                        fabricInspect2.Width_M = Convert.ToDecimal(txtwithd_M_emptyrow.Text);
                    }
                    else
                    {
                        fabricInspect2.Width_M = 0;
                    }
                    if (txtwithd_E_emptyrow.Text != "")
                    {
                        //Width_E = Convert.ToDecimal(txtwithd_E_emptyrow.Text);
                        fabricInspect2.Width_E = Convert.ToDecimal(txtwithd_E_emptyrow.Text);
                    }
                    else
                    {
                        fabricInspect2.Width_E = 0;
                    }
                    if (txtweaving_1_emptyrow.Text != "")
                    {
                        //Weaving_1 = Convert.ToDecimal(txtweaving_1_emptyrow.Text);
                        fabricInspect2.Weaving_1 = Convert.ToDecimal(txtweaving_1_emptyrow.Text);
                    }
                    else
                    {
                        fabricInspect2.Weaving_1 = 0;
                    }
                    if (txtweaving_2_emptyrow.Text != "")
                    {
                        //Weaving_2 = Convert.ToDecimal(txtweaving_2_emptyrow.Text);
                        fabricInspect2.Weaving_2 = Convert.ToDecimal(txtweaving_2_emptyrow.Text);
                    }
                    else
                    {
                        fabricInspect2.Weaving_2 = 0;
                    }
                    if (txtweaving_3_emptyrow.Text != "")
                    {
                        //Weaving_3 = Convert.ToDecimal(txtweaving_3_emptyrow.Text);
                        fabricInspect2.Weaving_3 = Convert.ToDecimal(txtweaving_3_emptyrow.Text);
                    }
                    else
                    {
                        fabricInspect2.Weaving_3 = 0;
                    }
                    if (txtweaving_4_emptyrow.Text != "")
                    {
                        //Weaving_4 = Convert.ToDecimal(txtweaving_4_emptyrow.Text);
                        fabricInspect2.Weaving_4 = Convert.ToDecimal(txtweaving_4_emptyrow.Text);
                    }
                    else
                    {
                        fabricInspect2.Weaving_4 = 0;
                    }
                    if (txtpatta_emptyrow.Text != "")
                    {
                        //Patta = Convert.ToDecimal(txtpatta_emptyrow.Text);
                        fabricInspect2.Patta = Convert.ToDecimal(txtpatta_emptyrow.Text);
                    }
                    else
                    {
                        fabricInspect2.Patta = 0;
                    }
                    if (txthole_emptyrow.Text != "")
                    {
                        //Hole = Convert.ToDecimal(txthole_emptyrow.Text);
                        fabricInspect2.Hole = Convert.ToDecimal(txthole_emptyrow.Text);
                    }
                    else
                    {
                        fabricInspect2.Hole = 0;
                    }

                    if (txtprintdyeingdefacts1_emptyrow.Text != "")
                    {
                        //PrintedDefectes_1 = Convert.ToDecimal(txtprintdyeingdefacts1_emptyrow.Text);
                        fabricInspect2.PrintedDefectes_1 = Convert.ToDecimal(txtprintdyeingdefacts1_emptyrow.Text);
                    }
                    else
                    {
                        fabricInspect2.PrintedDefectes_1 = 0;
                    }
                    if (txtprintdyeingdefacts2_emptyrow.Text != "")
                    {
                        //PrintedDefectes_2 = Convert.ToDecimal(txtprintdyeingdefacts2_emptyrow.Text);
                        fabricInspect2.PrintedDefectes_2 = Convert.ToDecimal(txtprintdyeingdefacts2_emptyrow.Text);
                    }
                    else
                    {
                        fabricInspect2.PrintedDefectes_2 = 0;
                    }
                    if (txtprintdyeingdefacts3_emptyrow.Text != "")
                    {
                        //PrintedDefectes_3 = Convert.ToDecimal(txtprintdyeingdefacts3_emptyrow.Text);
                        fabricInspect2.PrintedDefectes_3 = Convert.ToDecimal(txtprintdyeingdefacts3_emptyrow.Text);
                    }
                    else
                    {
                        fabricInspect2.PrintedDefectes_3 = 0;
                    }
                    if (txtprintdyeingdefacts4_emptyrow.Text != "")
                    {
                        //PrintedDefectes_4 = Convert.ToDecimal(txtprintdyeingdefacts4_emptyrow.Text);
                        fabricInspect2.PrintedDefectes_4 = Convert.ToDecimal(txtprintdyeingdefacts4_emptyrow.Text);
                    }
                    else
                    {
                        fabricInspect2.PrintedDefectes_4 = 0;
                    }
                    if (txtweapointyard_emptyrow.Text != "")
                    {
                        //WeaPointsPerSquirdYards = Convert.ToDecimal(txtweapointyard_emptyrow.Text);
                        fabricInspect2.WeaPointsPerSquirdYards = Convert.ToDecimal(txtweapointyard_emptyrow.Text);
                    }
                    else
                    {
                        fabricInspect2.WeaPointsPerSquirdYards = 0;
                    }
                    Status = Convert.ToInt32(ddlstatus_emptyrow.SelectedValue);
                    if (ddlstatus_emptyrow.SelectedValue == "1")
                    {
                        //Statusstring = "pass";
                        // fabricInspect2.Decision = "Pass";
                        // cahnged by sanjeev on 24/08/2021 
                        fabricInspect2.Decision = "1";
                    }
                    else if (ddlstatus_emptyrow.SelectedValue == "2")
                    {
                        // fabricInspect2.Decision = "Fail";
                        // cahnged by sanjeev on 24/08/2021
                        fabricInspect2.Decision = "2";
                    }
                    else
                    {
                        // fabricInspect2.Decision = "";
                        // cahnged by sanjeev on 24/08/2021
                        fabricInspect2.Decision = "-1";
                    }
                    fabricInspect2.CreatedBy = iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.UserID;

                    //if (RollNumber > 0 && Width_S > 0)
                    if (fabricInspect2.BoxNo > 0 && fabricInspect2.Width_S > 0)
                    {
                        dtresult = fabobj.GetFabFourPointCheckUpdateDetails(fabricInspect2);
                        // dtresult = fabobj.GetFabFourPointCheckUpdateDetails(FourPointCheck_Id, RollNumber, DeitLotNumber, ClaimedQty, ActualLength, CheckedQty,PassQty,HoldQty,FailQty, Width_S, Width_M, Width_E, Weaving_1, Weaving_2, Weaving_3, Weaving_4, Patta, Hole, PrintedDefectes_1, PrintedDefectes_2, PrintedDefectes_3, PrintedDefectes_4, WeaPointsPerSquirdYards, Convert.ToInt32(ddlstatus_emptyrow.SelectedValue));
                        //issaive = "save";
                    }

                }
                else
                {
                    FabricInspect fabricInspect2 = new FabricInspect();
                    fabricInspect2.Inspection_Id = FourPointCheck_Id;

                    RollNumber = 0;
                    DeitLotNumber = 0;
                    ClaimedQty = 0; //new line
                    ActualLength = 0;
                    Width_S = 0;
                    Width_M = 0;
                    Width_E = 0;
                    Weaving_1 = 0;
                    Weaving_2 = 0;
                    Weaving_3 = 0;
                    Weaving_4 = 0;
                    Patta = 0;
                    Hole = 0;
                    PrintedDefectes_1 = 0;
                    PrintedDefectes_2 = 0;
                    PrintedDefectes_3 = 0;
                    PrintedDefectes_4 = 0;
                    WeaPointsPerSquirdYards = 0;
                    CheckedQty = 0; //new line 02-02-2021
                    PassQty = 0; //new line 02-02-2021
                    HoldQty = 0; //new line 02-02-2021
                    FailQty = 0; //new line 02-02-2021


                    TextBox txtrollno_Footer = grdfourpointcheck.FooterRow.FindControl("txtrollno_Footer") as TextBox;
                    TextBox txtdeilot_Footer = grdfourpointcheck.FooterRow.FindControl("txtdeilot_Footer") as TextBox;
                    TextBox txtclaimedlength_Footer = grdfourpointcheck.FooterRow.FindControl("txtclaimedlength_Footer") as TextBox; //new line
                    TextBox txtactlenght_Footer = grdfourpointcheck.FooterRow.FindControl("txtactlenght_Footer") as TextBox;
                    TextBox txtwidth_S_Footer = grdfourpointcheck.FooterRow.FindControl("txtwidth_S_Footer") as TextBox;
                    TextBox txtwidth_M_Footer = grdfourpointcheck.FooterRow.FindControl("txtwidth_M_Footer") as TextBox;
                    TextBox txtwidth_E_Footer = grdfourpointcheck.FooterRow.FindControl("txtwidth_E_Footer") as TextBox;
                    TextBox txtwidth_weaving1_Footer = grdfourpointcheck.FooterRow.FindControl("txtwidth_weaving1_Footer") as TextBox;
                    TextBox txtwidth_weaving2_Footer = grdfourpointcheck.FooterRow.FindControl("txtwidth_weaving2_Footer") as TextBox;
                    TextBox txtwidth_weaving3_Footer = grdfourpointcheck.FooterRow.FindControl("txtwidth_weaving3_Footer") as TextBox;
                    TextBox txtwidth_weaving4_Footer = grdfourpointcheck.FooterRow.FindControl("txtwidth_weaving4_Footer") as TextBox;
                    TextBox txttotal_Footer = grdfourpointcheck.FooterRow.FindControl("txttotal_Footer") as TextBox;
                    TextBox txtpatta_Footer = grdfourpointcheck.FooterRow.FindControl("txtpatta_Footer") as TextBox;
                    TextBox txthole_Footer = grdfourpointcheck.FooterRow.FindControl("txthole_Footer") as TextBox;
                    TextBox txtTotal2_Footer = grdfourpointcheck.FooterRow.FindControl("txtTotal2_Footer") as TextBox;
                    TextBox txtprintdyeingdefacts1_Footer = grdfourpointcheck.FooterRow.FindControl("txtprintdyeingdefacts1_Footer") as TextBox;
                    TextBox txtprintdyeingdefacts2_Footer = grdfourpointcheck.FooterRow.FindControl("txtprintdyeingdefacts2_Footer") as TextBox;
                    TextBox txtprintdyeingdefacts3_Footer = grdfourpointcheck.FooterRow.FindControl("txtprintdyeingdefacts3_Footer") as TextBox;
                    TextBox txtprintdyeingdefacts4_Footer = grdfourpointcheck.FooterRow.FindControl("txtprintdyeingdefacts4_Footer") as TextBox;
                    TextBox txtweapointyard_Footer = grdfourpointcheck.FooterRow.FindControl("txtweapointyard_Footer") as TextBox;
                    DropDownList ddlstatus_Footer = grdfourpointcheck.FooterRow.FindControl("ddlstatus_Footer") as DropDownList;

                    TextBox txtcheckedlength_emptyrow = grdfourpointcheck.FooterRow.FindControl("txtchkd_Footer") as TextBox; //new line 02-02-2021
                    TextBox txtpasslength_emptyrow = grdfourpointcheck.FooterRow.FindControl("txtpass_Footer") as TextBox; //new line 02-02-2021
                    TextBox txtholdlength_emptyrow = grdfourpointcheck.FooterRow.FindControl("txthold_Footer") as TextBox; //new line 02-02-2021                    
                    TextBox txtfaillength_emptyrow = grdfourpointcheck.FooterRow.FindControl("txtfail_Footer") as TextBox; //new line 02-02-2021

                    //new code start 02-02-2021
                    if (txtcheckedlength_emptyrow.Text != "")
                    {
                        //CheckedQty = Convert.ToDecimal(txtcheckedlength_emptyrow.Text);
                        fabricInspect2.CheckedQty = Convert.ToDecimal(txtcheckedlength_emptyrow.Text);
                    }
                    if (txtpasslength_emptyrow.Text != "")
                    {
                        //PassQty = Convert.ToDecimal(txtpasslength_emptyrow.Text);
                        fabricInspect2.PassQty = Convert.ToDecimal(txtpasslength_emptyrow.Text);
                    }
                    if (txtholdlength_emptyrow.Text != "")
                    {
                        //HoldQty = Convert.ToDecimal(txtholdlength_emptyrow.Text);
                        fabricInspect2.HoldQty = Convert.ToDecimal(txtholdlength_emptyrow.Text);
                    }
                    if (txtfaillength_emptyrow.Text != "")
                    {
                        //FailQty = Convert.ToDecimal(txtfaillength_emptyrow.Text);
                        fabricInspect2.FailQty = Convert.ToDecimal(txtfaillength_emptyrow.Text);
                    }
                    //new code end 02-02-2021

                    DataTable dtnew = new DataTable();
                    if (txtrollno_Footer.Text != "")
                    {
                        //RollNumber = Convert.ToInt32(txtrollno_Footer.Text);
                        fabricInspect2.BoxNo = Convert.ToInt32(txtrollno_Footer.Text);
                    }

                    if (txtdeilot_Footer.Text != "")
                    {
                        //DeitLotNumber = Convert.ToInt32(txtdeilot_Footer.Text);
                        fabricInspect2.DieLot = Convert.ToInt32(txtdeilot_Footer.Text);
                    }
                    //new code start
                    if (txtclaimedlength_Footer.Text != "")
                    {
                        //ClaimedQty = Convert.ToDecimal(txtclaimedlength_Footer.Text);
                        fabricInspect2.ClaimedLength = Convert.ToDecimal(txtclaimedlength_Footer.Text);
                    }
                    //new code end

                    if (txtactlenght_Footer.Text != "")
                    {
                        //ActualLength = Convert.ToDecimal(txtactlenght_Footer.Text);
                        fabricInspect2.ActLength = Convert.ToDecimal(txtactlenght_Footer.Text);
                    }
                    if (txtwidth_S_Footer.Text != "")
                    {
                        //Width_S = Convert.ToDecimal(txtwidth_S_Footer.Text);
                        fabricInspect2.Width_S = Convert.ToDecimal(txtwidth_S_Footer.Text);
                    }
                    if (txtwidth_M_Footer.Text != "")
                    {
                        //Width_M = Convert.ToDecimal(txtwidth_M_Footer.Text);
                        fabricInspect2.Width_M = Convert.ToDecimal(txtwidth_M_Footer.Text);
                    }
                    if (txtwidth_E_Footer.Text != "")
                    {
                        //Width_E = Convert.ToDecimal(txtwidth_E_Footer.Text);
                        fabricInspect2.Width_E = Convert.ToDecimal(txtwidth_E_Footer.Text);
                    }
                    if (txtwidth_weaving1_Footer.Text != "")
                    {
                        //Weaving_1 = Convert.ToDecimal(txtwidth_weaving1_Footer.Text);
                        fabricInspect2.Weaving_1 = Convert.ToDecimal(txtwidth_weaving1_Footer.Text);
                    }
                    if (txtwidth_weaving2_Footer.Text != "")
                    {
                        //Weaving_2 = Convert.ToDecimal(txtwidth_weaving2_Footer.Text);
                        fabricInspect2.Weaving_2 = Convert.ToDecimal(txtwidth_weaving2_Footer.Text);
                    }
                    if (txtwidth_weaving3_Footer.Text != "")
                    {
                        //Weaving_3 = Convert.ToDecimal(txtwidth_weaving3_Footer.Text);
                        fabricInspect2.Weaving_3 = Convert.ToDecimal(txtwidth_weaving3_Footer.Text);
                    }
                    if (txtwidth_weaving4_Footer.Text != "")
                    {
                        //Weaving_4 = Convert.ToDecimal(txtwidth_weaving4_Footer.Text);
                        fabricInspect2.Weaving_4 = Convert.ToDecimal(txtwidth_weaving4_Footer.Text);
                    }
                    if (txtpatta_Footer.Text != "")
                    {
                        //Patta = Convert.ToDecimal(txtpatta_Footer.Text);
                        fabricInspect2.Patta = Convert.ToDecimal(txtpatta_Footer.Text);
                    }

                    if (txthole_Footer.Text != "")
                    {
                        //Hole = Convert.ToDecimal(txthole_Footer.Text);
                        fabricInspect2.Hole = Convert.ToDecimal(txthole_Footer.Text);
                    }

                    if (txtprintdyeingdefacts1_Footer.Text != "")
                    {
                        //PrintedDefectes_1 = Convert.ToDecimal(txtprintdyeingdefacts1_Footer.Text);
                        fabricInspect2.PrintedDefectes_1 = Convert.ToDecimal(txtprintdyeingdefacts1_Footer.Text);
                    }
                    if (txtprintdyeingdefacts2_Footer.Text != "")
                    {
                        //PrintedDefectes_2 = Convert.ToDecimal(txtprintdyeingdefacts2_Footer.Text);
                        fabricInspect2.PrintedDefectes_2 = Convert.ToDecimal(txtprintdyeingdefacts2_Footer.Text);
                    }
                    if (txtprintdyeingdefacts3_Footer.Text != "")
                    {
                        //PrintedDefectes_3 = Convert.ToDecimal(txtprintdyeingdefacts3_Footer.Text);
                        fabricInspect2.PrintedDefectes_3 = Convert.ToDecimal(txtprintdyeingdefacts3_Footer.Text);
                    }
                    if (txtprintdyeingdefacts4_Footer.Text != "")
                    {
                        //PrintedDefectes_4 = Convert.ToDecimal(txtprintdyeingdefacts4_Footer.Text);
                        fabricInspect2.PrintedDefectes_4 = Convert.ToDecimal(txtprintdyeingdefacts4_Footer.Text);
                    }
                    if (txtweapointyard_Footer.Text != "")
                    {
                        //WeaPointsPerSquirdYards = Convert.ToDecimal(txtweapointyard_Footer.Text);
                        fabricInspect2.WeaPointsPerSquirdYards = Convert.ToDecimal(txtweapointyard_Footer.Text);
                    }
                    Status = Convert.ToInt32(ddlstatus_Footer.SelectedValue);
                    if (ddlstatus_Footer.SelectedValue == "1")
                    {
                        //Statusstring = "pass";
                        fabricInspect2.Decision = "Pass";
                    }
                    else if (ddlstatus_Footer.SelectedValue == "2")
                    {
                        //Statusstring = "fail";
                        fabricInspect2.Decision = "Fail";
                    }
                    else
                    {
                        //Statusstring = "";
                        fabricInspect2.Decision = "";
                    }
                    fabricInspect2.CreatedBy = iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.UserID;
                    //if (RollNumber > 0 && Width_S > 0)
                    if (fabricInspect2.BoxNo > 0 && fabricInspect2.Width_S > 0)
                    {
                        dtresult = fabobj.GetFabFourPointCheckUpdateDetails(fabricInspect2);
                        //dtresult = fabobj.GetFabFourPointCheckUpdateDetails(FourPointCheck_Id, RollNumber, DeitLotNumber, ClaimedQty, ActualLength, CheckedQty, PassQty, HoldQty, FailQty, Width_S, Width_M, Width_E, Weaving_1, Weaving_2, Weaving_3, Weaving_4, Patta, Hole, PrintedDefectes_1, PrintedDefectes_2, PrintedDefectes_3, PrintedDefectes_4, WeaPointsPerSquirdYards, Convert.ToInt32(statuss));
                        //issaive = "save";
                    }
                    //if (issaive != "")
                    //{
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "Close", "window.top.close();", true);
                    ////ScriptManager.RegisterStartupScript(this, this.GetType(), "Close", "window.top.location.replace('FrmWorkingOnRaisedPO.aspx');", true);
                    //}
                }










                if (ChkFabricQa.Checked == true)
                {
                    if ((dt.Rows[0]["Excess_Stock_Qty"] == DBNull.Value ? 0 : Convert.ToInt32(dt.Rows[0]["Excess_Stock_Qty"].ToString())) > 0)
                    {
                        //    ExtraQtyId.Attributes.Add("Style", "display: block");
                        if (lblInspectExtraQty.Text == "")
                            lblInspectExtraQty.Text = dt.Rows[0]["Excess_Stock_Qty"].ToString() == "0" ? "" : Convert.ToInt32(dt.Rows[0]["Excess_Stock_Qty"]).ToString("N0");
                        else
                            lblInspectExtraQty.Text = (Convert.ToInt32(lblInspectExtraQty.Text.Replace(",", "")) + Convert.ToInt32(dt.Rows[0]["Excess_Stock_Qty"].ToString())).ToString("N0");


                        if (lblInspectExtraQty.Text != "")
                        {
                            //FabricInspectSystem fabricInspect2 = new FabricInspectSystem();
                            fabricInspectSystem.TotalExternalQty = Convert.ToInt32(lblInspectExtraQty.Text.Replace(",", ""));
                            DataTable dtresult1 = new DataTable();
                            dtresult1 = fabobj.GetFabFourPointCheckUpdateBasic(fabricInspectSystem);
                        }
                    }
                }













                if (Flag == 1)
                {
                    // Response.Redirect(Request.RawUrl);
                    string SuccessMessage = string.Empty;
                    SuccessMessage = "Save Successfully.";
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('" + SuccessMessage + "');", true);
                    BindBasicSectionFabric();
                    //Response.Redirect(Request.RawUrl);

                    // ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "none", "executeAfter();", true);
                }
                if (Flag == 0)
                {
                    //if (fabricInspect.Inspection_Id > 0)
                    //{
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "err_msg", "closePage();", true);
                    //}
                }

                //if (Convert.ToInt32(dt.Rows[0]["Excess_Stock_Qty"].ToString()) > 0)
                //{
                //    divstock.Visible = true;
                //    lblqtys.Text = "" + dt.Rows[0]["Excess_Stock_Qty"].ToString();
                //}
                //else
                //{
                //    ScriptManager.RegisterStartupScript(this, this.GetType(), "Close", "window.top.location.replace('FrmWorkingOnRaisedPO.aspx');", true);
                //}

            }
        }

        protected void btncallback_Click(object sender, EventArgs e)
        {
            RebindDataTable();

        }

        public void GetSum()
        {
            DataTable dtnew = (DataTable)(ViewState["viewGrddate"]);
            dtnew.DefaultView.Sort = "ID ASC";
            foreach (GridViewRow grv in grdfourpointcheck.Rows)
            {

                Label lblrollno_item = (Label)grv.FindControl("lblrollno_item");
                if (lblrollno_item != null)
                {

                    Label lbldeilot_item = (Label)grv.FindControl("lbldeilot_item");
                    Label lblclaimedlength_item = (Label)grv.FindControl("lblclaimedlength_item"); //new line
                    Label lblactlenght_item = (Label)grv.FindControl("lblactlenght_item");
                    Label lblwidth_S_item = (Label)grv.FindControl("lblwidth_S_item");
                    Label lblwidth_M_item = (Label)grv.FindControl("lblwidth_M_item");
                    Label lblwidth_E_item = (Label)grv.FindControl("lblwidth_E_item");
                    Label lblwidth_weaving1_item = (Label)grv.FindControl("lblwidth_weaving1_item");
                    Label lblwidth_weaving2_item = (Label)grv.FindControl("lblwidth_weaving2_item");
                    Label lblwidth_weaving3_item = (Label)grv.FindControl("lblwidth_weaving3_item");
                    Label lblwidth_weaving4_item = (Label)grv.FindControl("lblwidth_weaving4_item");
                    Label lbltotal_item = (Label)grv.FindControl("lbltotal_item");
                    Label lblpatta_item = (Label)grv.FindControl("lblpatta_item");
                    Label lblhole_item = (Label)grv.FindControl("lblhole_item");
                    Label lblTotal2_item = (Label)grv.FindControl("lblTotal2_item");
                    Label lblprintdyeingdefacts1_item = (Label)grv.FindControl("lblprintdyeingdefacts1_item");
                    Label lblprintdyeingdefacts2_item = (Label)grv.FindControl("lblprintdyeingdefacts2_item");
                    Label lblprintdyeingdefacts3_item = (Label)grv.FindControl("lblprintdyeingdefacts3_item");
                    Label lblprintdyeingdefacts4_item = (Label)grv.FindControl("lblprintdyeingdefacts4_item");
                    Label lblTotal3_item = (Label)grv.FindControl("lblTotal3_item");
                    Label lblpointTotal_item = (Label)grv.FindControl("lblpointTotal_item");
                    Label lblweapointyard_item = (Label)grv.FindControl("lblweapointyard_item");
                    Label lblstatus_item = (Label)grv.FindControl("lblstatus_item");

                    Label lblchkd_item = (Label)grv.FindControl("lblchkd_item"); //new line 02-02-2021
                    Label lblpass_item = (Label)grv.FindControl("lblpass_item"); //new line 02-02-2021
                    Label lblhold_item = (Label)grv.FindControl("lblhold_item"); //new line 02-02-2021
                    Label lblfail_item = (Label)grv.FindControl("lblfail_item"); //new line 02-02-2021


                    HiddenField hdnrowid = (HiddenField)grv.FindControl("hdnrowid");
                    decimal w1 = 1;
                    decimal w2 = 2;
                    decimal w3 = 3;
                    decimal w4 = 4;
                    decimal pattamultiplier = 4;
                    decimal holemultiplier = 4;

                    decimal Defectsmultiplier1 = 1;
                    decimal Defectsmultiplier2 = 2;
                    decimal Defectsmultiplier3 = 3;
                    decimal Defectsmultiplier4 = 4;

                    decimal firsttotal = 0;
                    decimal pattaholetotal = 0;
                    decimal thridtotal = 0;

                    decimal widths = 0;
                    if (lblwidth_S_item.Text != "")
                    {
                        widths = Convert.ToDecimal(lblwidth_S_item.Text);
                    }
                    lbltotal_item.Text = "";
                    lblTotal2_item.Text = "";
                    lblTotal3_item.Text = "";
                    lblpointTotal_item.Text = "";
                    decimal weaving1 = (lblwidth_weaving1_item.Text == "" ? 0 : Convert.ToDecimal(lblwidth_weaving1_item.Text));
                    decimal weaving2 = (lblwidth_weaving2_item.Text == "" ? 0 : Convert.ToDecimal(lblwidth_weaving2_item.Text));
                    decimal weaving3 = (lblwidth_weaving3_item.Text == "" ? 0 : Convert.ToDecimal(lblwidth_weaving3_item.Text));
                    decimal weaving4 = (lblwidth_weaving4_item.Text == "" ? 0 : Convert.ToDecimal(lblwidth_weaving4_item.Text));
                    decimal pattaval = (lblpatta_item.Text == "" ? 0 : Convert.ToDecimal(lblpatta_item.Text));
                    decimal holeval = (lblhole_item.Text == "" ? 0 : Convert.ToDecimal(lblhole_item.Text));
                    firsttotal = (((weaving1 * w1) + (weaving2 * w2)) + ((weaving3) * w3) + ((weaving4) * w4));
                    if (firsttotal <= 0)
                    {
                        lbltotal_item.Text = "";
                        //txttotalqty.Text = "";
                    }
                    else
                    {
                        lbltotal_item.Text = Math.Round(firsttotal).ToString();
                    }

                    pattaholetotal = ((pattaval * pattamultiplier) + (holeval * holemultiplier));
                    if (pattaholetotal <= 0)
                    {
                        lblTotal2_item.Text = "";
                    }
                    else
                    {
                        lblTotal2_item.Text = Math.Round(pattaholetotal).ToString();
                    }

                    decimal defacts1 = (lblprintdyeingdefacts1_item.Text == "" ? 0 : Convert.ToDecimal(lblprintdyeingdefacts1_item.Text));
                    decimal defacts2 = (lblprintdyeingdefacts2_item.Text == "" ? 0 : Convert.ToDecimal(lblprintdyeingdefacts2_item.Text));
                    decimal defacts3 = (lblprintdyeingdefacts3_item.Text == "" ? 0 : Convert.ToDecimal(lblprintdyeingdefacts3_item.Text));
                    decimal defacts4 = (lblprintdyeingdefacts4_item.Text == "" ? 0 : Convert.ToDecimal(lblprintdyeingdefacts4_item.Text));

                    thridtotal = ((defacts1 * (Defectsmultiplier1)) + ((defacts2 * Defectsmultiplier2)) + ((defacts3 * Defectsmultiplier3)) + ((defacts4) * Defectsmultiplier4));
                    if (thridtotal <= 0)
                    {
                        lblTotal3_item.Text = "";
                    }
                    else
                    {
                        lblTotal3_item.Text = Math.Round(thridtotal).ToString();
                    }

                    //3 Total Points============================================================================== 
                    decimal t1 = (lbltotal_item.Text == "" ? 0 : Convert.ToDecimal(lbltotal_item.Text));
                    decimal t2 = (lblTotal2_item.Text == "" ? 0 : Convert.ToDecimal(lblTotal2_item.Text));
                    decimal t3 = (lblTotal3_item.Text == "" ? 0 : Convert.ToDecimal(lblTotal3_item.Text));

                    decimal subtotal = (t1 + t2 + t3);
                    if (subtotal <= 0)
                    {
                        lblpointTotal_item.Text = "";
                    }
                    else
                    {
                        lblpointTotal_item.Text = Math.Round(subtotal).ToString();
                    }
                    decimal rollvalue = (lblrollno_item.Text == "" ? 0 : Convert.ToDecimal(lblrollno_item.Text));
                    decimal ClaimedQty = (lblclaimedlength_item.Text == "" ? 0 : Convert.ToDecimal(lblclaimedlength_item.Text));   //new line 
                    decimal actuallengh = (lblactlenght_item.Text == "" ? 0 : Convert.ToDecimal(lblactlenght_item.Text));
                    decimal with_sw = (lblwidth_S_item.Text == "" ? 0 : Convert.ToDecimal(lblwidth_S_item.Text));
                    if ((actuallengh) > 0 && (with_sw) > 0)
                    {
                        decimal finalvalues = ((subtotal * 3600) / (with_sw * actuallengh));
                        if (finalvalues <= 0)
                        {
                            lblweapointyard_item.Text = "";
                        }
                        else
                        {
                            if (finalvalues <= 40)
                            {
                                //lblstatus_item.Text = "pass";
                            }
                            else
                            {
                                //lblstatus_item.Text = "fail";
                            }
                            lblweapointyard_item.Text = Math.Round(finalvalues).ToString();

                        }
                    }
                    decimal tt1 = 0, tt2 = 0, tt3 = 0, tt4 = 0, tt5 = 0; // tt6 = 0;
                    if (lbltotal_item.Text != "")
                    {
                        tt1 = Convert.ToDecimal(lbltotal_item.Text);
                    }
                    if (lblTotal2_item.Text != "")
                    {
                        tt2 = Convert.ToDecimal(lblTotal2_item.Text);
                    }
                    if (lblTotal3_item.Text != "")
                    {
                        tt3 = Convert.ToDecimal(lblTotal3_item.Text);
                    }
                    if (lblpointTotal_item.Text != "")
                    {
                        tt4 = Convert.ToDecimal(lblpointTotal_item.Text);
                    }
                    if (lblweapointyard_item.Text != "")
                    {
                        tt5 = Convert.ToDecimal(lblweapointyard_item.Text);
                    }
                    foreach (DataRow dr in dtnew.Rows)
                    {
                        if (dr["ID"].ToString() == hdnrowid.Value)
                        {
                            dr["total1"] = Math.Round(t1, 0);
                            dr["total2"] = Math.Round(t2, 0);
                            dr["total3"] = Math.Round(t3, 0);
                            dr["TotalPoints"] = Math.Round(tt4, 0);
                            dr["WeaPointsPerSquirdYards"] = Math.Round(tt5, 0);
                            //if (dr["Statusstring"].ToString().ToLower() == "pass")
                            //{
                            //  dr["Status"] = 1;
                            //  dr["Statusstring"] = "Pass";
                            //}
                            //else if (dr["Statusstring"].ToString().ToLower() == "fail")
                            //{
                            //  dr["Status"] = Convert.ToInt32(2);
                            //  dr["Statusstring"] = "fail";
                            //}
                            //else
                            //{
                            //  dr["Status"] = Convert.ToInt32(-1);
                            //}
                            break;
                        }
                    }
                    dtnew.AcceptChanges();
                    dtnew.DefaultView.Sort = "ID ASC";
                    ViewState["viewGrddate"] = dtnew;
                }
                else
                {
                    break;
                }


            }

        }

        public bool ValidateSRVQty()
        {
            Decimal ActualLength = 0;
            Boolean res = true;

            int i = 0;
            for (; i < grdfourpointcheck.Rows.Count; i++)
            {
                if (((Label)grdfourpointcheck.Rows[i].FindControl("lblactlenght_item")) != null)
                {
                    if (((Label)grdfourpointcheck.Rows[i].FindControl("lblactlenght_item")).Text != "")
                    {
                        ActualLength = ActualLength + Convert.ToDecimal(((Label)grdfourpointcheck.Rows[i].FindControl("lblactlenght_item")).Text);
                    }
                }
            }


            if (grdfourpointcheck.Rows.Count == 0)
            {
                TextBox txtactlenght_emptyrow = grdfourpointcheck.Controls[0].Controls[0].FindControl("txtactlenght_emptyrow") as TextBox; ;
                if (txtactlenght_emptyrow.Text != "")
                {
                    ActualLength = ActualLength + Convert.ToDecimal(txtactlenght_emptyrow.Text);
                }
            }
            else
            {
                TextBox txtactlenght_Footer = grdfourpointcheck.FooterRow.FindControl("txtactlenght_Footer") as TextBox;
                if (txtactlenght_Footer.Text != "")
                {
                    ActualLength = ActualLength + Convert.ToDecimal(txtactlenght_Footer.Text);
                }

            }
            if (ActualLength > Convert.ToDecimal(lblQty.Text.Replace(",", "")))
            {
                res = false;
            }
            return res;
        }

        protected void btnok_Click(object sender, EventArgs e)
        {
            DataTable dt = fabobj.GetFabFourPointexcessqty(SupplierPoID, FourPointCheck_Id, 1, Convert.ToInt32(lblqtys.Text));
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Close", "window.top.location.replace('FrmWorkingOnRaisedPO.aspx');", true);

        }

        protected void Btncancel_Click(object sender, EventArgs e)
        {
            DataTable dt = fabobj.GetFabFourPointexcessqty(SupplierPoID, FourPointCheck_Id, 0, Convert.ToInt32(lblqtys.Text));
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Close", "window.top.location.replace('FrmWorkingOnRaisedPO.aspx');", true);

        }

        protected void grdfourpointcheck_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                GridView HeaderGrid = (GridView)sender;
                GridViewRow HeaderGridRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
                GridViewRow HeaderGridRow2 = new GridViewRow(1, 0, DataControlRowType.Header, DataControlRowState.Insert);

                TableCell HeaderCell = new TableCell();

                HeaderCell.Text = "Roll<br> No.";
                HeaderCell.CssClass = "Header1";
                HeaderGridRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Dye Lot";
                HeaderCell.CssClass = "Header1";
                HeaderGridRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Claimed Length";
                HeaderCell.CssClass = "Header1";
                HeaderGridRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Act. Length";
                HeaderCell.CssClass = "Header1";
                HeaderGridRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Chkd";
                HeaderCell.CssClass = "Header1";
                HeaderGridRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Pass";
                HeaderCell.CssClass = "Header1";
                HeaderGridRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Hold";
                HeaderCell.CssClass = "Header1";
                HeaderGridRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Fail";
                HeaderCell.CssClass = "Header1";
                HeaderGridRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Width";
                HeaderCell.ColumnSpan = 3;
                HeaderCell.CssClass = "Header1";
                HeaderGridRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Weaving";
                HeaderCell.ColumnSpan = 4;
                HeaderCell.CssClass = "Header1";
                HeaderGridRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Total";
                HeaderCell.CssClass = "Header1";
                HeaderGridRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Patta";
                HeaderCell.CssClass = "Header1";
                HeaderGridRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Hole";
                HeaderCell.CssClass = "Header1";
                HeaderGridRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Total";
                HeaderCell.CssClass = "Header1";
                HeaderGridRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Printed & Dyeing Defects";
                HeaderCell.ColumnSpan = 4;
                HeaderCell.CssClass = "Header1";
                HeaderGridRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Total";
                HeaderCell.CssClass = "Header1";
                HeaderGridRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Total Points";
                HeaderCell.CssClass = "Header1";
                HeaderGridRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Weak Points per 100 sq Yards";
                HeaderCell.CssClass = "Header1";
                HeaderGridRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Status";
                HeaderCell.CssClass = "Header1";
                HeaderGridRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Action";
                HeaderCell.CssClass = "Header1";
                HeaderGridRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "";
                HeaderCell.CssClass = "Header2";
                HeaderGridRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "";
                HeaderCell.CssClass = "Header2";
                HeaderGridRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "";
                HeaderCell.CssClass = "Header2";
                HeaderGridRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "";
                HeaderCell.CssClass = "Header2";
                HeaderGridRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "";
                HeaderCell.CssClass = "Header2";
                HeaderGridRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "";
                HeaderCell.CssClass = "Header2";
                HeaderGridRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "";
                HeaderCell.CssClass = "Header2";
                HeaderGridRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "";
                HeaderCell.CssClass = "Header2";
                HeaderGridRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Start";
                HeaderCell.CssClass = "Header2";
                HeaderGridRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Middle";
                HeaderCell.CssClass = "Header2";
                HeaderGridRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "End";
                HeaderCell.CssClass = "Header2";
                HeaderGridRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "1";
                HeaderCell.CssClass = "Header2";
                HeaderGridRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "2";
                HeaderCell.CssClass = "Header2";
                HeaderGridRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "3";
                HeaderCell.CssClass = "Header2";
                HeaderGridRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "4";
                HeaderCell.CssClass = "Header2";
                HeaderGridRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "";
                HeaderCell.CssClass = "Header2";
                HeaderGridRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "4";
                HeaderCell.CssClass = "Header2";
                HeaderGridRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "4";
                HeaderCell.CssClass = "Header2";
                HeaderGridRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "";
                HeaderCell.CssClass = "Header2";
                HeaderGridRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "1";
                HeaderCell.CssClass = "Header2";
                HeaderGridRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "2";
                HeaderCell.CssClass = "Header2";
                HeaderGridRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "3";
                HeaderCell.CssClass = "Header2";
                HeaderGridRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "4";
                HeaderCell.CssClass = "Header2";
                HeaderGridRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "";
                HeaderCell.CssClass = "Header2";
                HeaderGridRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "";
                HeaderCell.CssClass = "Header2";
                HeaderGridRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "";
                HeaderCell.CssClass = "Header2";
                HeaderGridRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "";
                HeaderCell.CssClass = "Header2";
                HeaderGridRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "";
                HeaderCell.CssClass = "Header2";
                HeaderGridRow2.Cells.Add(HeaderCell);

                grdfourpointcheck.Controls[0].Controls.AddAt(0, HeaderGridRow);
                grdfourpointcheck.Controls[0].Controls.AddAt(1, HeaderGridRow2);

            }

        }

    }
}