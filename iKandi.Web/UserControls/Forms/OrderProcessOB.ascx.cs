using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using iKandi.Common;
using iKandi.Common.Entities;
using iKandi.BLL;
using System.Web.UI.HtmlControls;
using System.Drawing;
using iKandi.Web.Components;


namespace iKandi.Web.UserControls.Forms
{
    public partial class OrderProcessOB : BaseUserControl
    {
        OrderController obj_OrderController = new OrderController();
        iKandi.BLL.OrderProcessController obj_ProcessController = new BLL.OrderProcessController();
        AdminController obj_AdminController = new AdminController();
        OrderProcessController obj_OrderProcessController = new OrderProcessController();
        OBForm obj_OBForm = new OBForm();
        WorkflowController obj_WorkFlowController = new WorkflowController();
        //Add By Prabhaker 
        public int styleid
        {
            get;
            set;
        }
        public int OrderID
        {
            get;
            set;
        }
        public int ReUseStyleId
        {
            get;
            set;
        }
        //public int IsCreate
        //{
        //    get;
        //    set;
        //}
        //public int IsReUse
        //{
        //    get;
        //    set;
        //}

        public int CreateNew
        {
            get;
            set;
        }
        public int ReUse
        {
            get;
            set;
        }
        //public int ReUseStyleId
        //{
        //    get;
        //    set;
        //}
        public string ReUseStyleNumber
        {
            get;
            set;
        }
        public int NewRefrence
        {
            get;
            set;
        }
        double TotalSam = 0;
        double TotalMachine = 0;
        double FinalMachine = 0;
        double TotalFact = 0;

        int sl = 0;
        double TotalManpowerCost = 0;
        double TotalManpowerSAM = 0;
        double TotalManpowerNos = 0;
        double TotalgrdFact = 0;
        double SFactor = 0;
        double SCnt = 0;
        double machinecalc = 0;

        int RowNum = 0;
        int RowNumRef = 0;
        int iCheckCreateOB = 0;
        
        protected void Page_Load(object sender, EventArgs e)
        {
          
            GetQueryString();
            if (null == Request.QueryString["showOBFORM"])
            {
              return;
            }
            if (!IsPostBack)
            {
                iCheckCreateOB = obj_OrderController.GetCreateOBStatus(styleid);
                   
                hidelabel();
                hdnIsPopup.Value = "";
                showHidelable();
                BindControl(0, 0, 0, -1);
                bindStyleCode();
                SetParameter();
                lblGarment.Visible = true;
                ddlGarment.Visible = true;
                BindSection(0, 0, 0, -1);
                BindCuttingOB(0, 0, 0, -1);
                BindStichingOBGrid(0, 0, 0, -1);
                BindFinishingOB(0, 0, 0, -1);
                // BindCuttingManPower(0, 0, 0, -1);
                BindFinishingManPower(0, 0, 0, -1);
                BindStichingManPower(0, 0, 0, -1);
                BindRemarkGrd(0, 0, 0, -1);
                btnSubmit.Visible = true;
                SetOBPermission();
                CheckBoxEnable();
                FinalOBDone();
                if (iCheckCreateOB == 0)
                {
                    //if (iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.DesignationID == 19)
                    //    chkIsProductionGM.Enabled = true;
                    //else
                        //chkIsProductionGM.Enabled = false;
                    if (iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.DesignationID == 44)
                        chkIsIEManager.Enabled = true;
                    else
                        chkIsIEManager.Enabled = false;
                    if (iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.DesignationID == 45)
                        if (chkIsIEManager.Checked)
                        {

                            chkIsFactoryIE.Enabled = false;
                        }
                        else
                        {

                            chkIsFactoryIE.Enabled = true;
                        }
                    else
                        chkIsFactoryIE.Enabled = false;
                    //factorPlace = hf.Value;
                    //GlobalFactorValue.Value = hf.Value;
                }

               
            }
        }

        protected void SetOBPermission()
        {
            DataTable dtPermission = new DataTable();

            int DeptId = iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.PrimaryGroupID;
            int DesigId = Convert.ToInt32(ApplicationHelper.LoggedInUser.UserData.Designation);
            dtPermission = obj_OrderController.GetOBPermission(DeptId, DesigId, 166);
            HideControlPermission();
            if (dtPermission.Rows.Count > 0)
            {
                for (int ipermission = 0; ipermission < dtPermission.Rows.Count; ipermission++)
                {
                    int ColumnId = Convert.ToInt32(dtPermission.Rows[ipermission]["Technicalsectionid"]);
                    int SectionId = Convert.ToInt32(dtPermission.Rows[ipermission]["TechnicalFormsID"]);

                    string searchId = "Technicalsectionid =" + ColumnId;
                    DataRow[] dRow = dtPermission.Select(searchId);

                    //if (SectionId == 3)
                    //{

                    if (ColumnId == 204)
                    {
                        foreach (DataRow dr in dRow)
                        {
                            ddlGarment.Visible = true;
                            ddlGarment.Enabled = (dr["PermisionWrite"] == DBNull.Value) ? false : Convert.ToBoolean(dr["PermisionWrite"]);
                        }
                    }
                    if (ColumnId == 205)
                    {
                        foreach (DataRow dr in dRow)
                        {
                            lstSection.Visible = true;
                            lstSection.Enabled = (dr["PermisionWrite"] == DBNull.Value) ? false : Convert.ToBoolean(dr["PermisionWrite"]);
                        }
                    }
                    if (ColumnId == 206)
                    {
                        foreach (DataRow dr in dRow)
                        {

                            btnSave.Visible = true;
                            btnSave.Enabled = (dr["PermisionWrite"] == DBNull.Value) ? false : Convert.ToBoolean(dr["PermisionWrite"]);
                        }
                    }
                    if (ColumnId == 226)
                    {
                        foreach (DataRow dr in dRow)
                        {
                            GlobalFactorValue.Attributes.Add("class", "change-factor");
                            //bttnCheck.Visible = true;
                            //bttnCheck.Enabled = (dr["PermisionWrite"] == DBNull.Value) ? false : Convert.ToBoolean(dr["PermisionWrite"]);
                        }
                    }

                    if (ColumnId == 207)
                    {

                        foreach (DataRow dr in dRow)
                        {
                            grdStichingFront.Visible = true;
                            grdStichingFront.Enabled = (dr["PermisionWrite"] == DBNull.Value) ? false : Convert.ToBoolean(dr["PermisionWrite"]);
                            grdStichingBack.Visible = true;
                            grdStichingBack.Enabled = (dr["PermisionWrite"] == DBNull.Value) ? false : Convert.ToBoolean(dr["PermisionWrite"]);
                            grdStichingcoller.Visible = true;
                            grdStichingcoller.Enabled = (dr["PermisionWrite"] == DBNull.Value) ? false : Convert.ToBoolean(dr["PermisionWrite"]);
                            grdStichingsleep.Visible = true;
                            grdStichingsleep.Enabled = (dr["PermisionWrite"] == DBNull.Value) ? false : Convert.ToBoolean(dr["PermisionWrite"]);
                            grdStichingneck.Visible = true;
                            grdStichingneck.Enabled = (dr["PermisionWrite"] == DBNull.Value) ? false : Convert.ToBoolean(dr["PermisionWrite"]);
                            grdStichingLining.Visible = true;
                            grdStichingLining.Enabled = (dr["PermisionWrite"] == DBNull.Value) ? false : Convert.ToBoolean(dr["PermisionWrite"]);
                            grdStichinglower.Visible = true;
                            grdStichinglower.Enabled = (dr["PermisionWrite"] == DBNull.Value) ? false : Convert.ToBoolean(dr["PermisionWrite"]);
                            grdStichingbottom.Visible = true;
                            grdStichingbottom.Enabled = (dr["PermisionWrite"] == DBNull.Value) ? false : Convert.ToBoolean(dr["PermisionWrite"]);
                            grdStichingassembly.Visible = true;
                            grdStichingassembly.Enabled = (dr["PermisionWrite"] == DBNull.Value) ? false : Convert.ToBoolean(dr["PermisionWrite"]);
                            grdPiping.Visible = true;
                            grdPiping.Enabled = (dr["PermisionWrite"] == DBNull.Value) ? false : Convert.ToBoolean(dr["PermisionWrite"]);
                            grdUppersection.Visible = true;
                            grdUppersection.Enabled = (dr["PermisionWrite"] == DBNull.Value) ? false : Convert.ToBoolean(dr["PermisionWrite"]);
                            grdUppershell.Visible = true;
                            grdUppershell.Enabled = (dr["PermisionWrite"] == DBNull.Value) ? false : Convert.ToBoolean(dr["PermisionWrite"]);
                            grdLowershell.Visible = true;
                            grdLowershell.Enabled = (dr["PermisionWrite"] == DBNull.Value) ? false : Convert.ToBoolean(dr["PermisionWrite"]);
                            grdShellsection.Visible = true;
                            grdShellsection.Enabled = (dr["PermisionWrite"] == DBNull.Value) ? false : Convert.ToBoolean(dr["PermisionWrite"]);
                            grdWaistsection.Visible = true;
                            grdWaistsection.Enabled = (dr["PermisionWrite"] == DBNull.Value) ? false : Convert.ToBoolean(dr["PermisionWrite"]);
                            grdBandsection.Visible = true;
                            grdBandsection.Enabled = (dr["PermisionWrite"] == DBNull.Value) ? false : Convert.ToBoolean(dr["PermisionWrite"]);
                            grdFinishing.Visible = true;
                            grdFinishing.Enabled = (dr["PermisionWrite"] == DBNull.Value) ? false : Convert.ToBoolean(dr["PermisionWrite"]);

                            dvStchingFront.Visible = (dr["PermisionWrite"] == DBNull.Value) ? false : Convert.ToBoolean(dr["PermisionWrite"]); ;
                            dvStchingBack.Visible = (dr["PermisionWrite"] == DBNull.Value) ? false : Convert.ToBoolean(dr["PermisionWrite"]);
                            dvStchingcoller.Visible = (dr["PermisionWrite"] == DBNull.Value) ? false : Convert.ToBoolean(dr["PermisionWrite"]);
                            dvStchingSleeve.Visible = (dr["PermisionWrite"] == DBNull.Value) ? false : Convert.ToBoolean(dr["PermisionWrite"]);
                            dvStchingFrill.Visible = (dr["PermisionWrite"] == DBNull.Value) ? false : Convert.ToBoolean(dr["PermisionWrite"]);
                            dvStchingLining.Visible = (dr["PermisionWrite"] == DBNull.Value) ? false : Convert.ToBoolean(dr["PermisionWrite"]);
                            dvStchinglower.Visible = (dr["PermisionWrite"] == DBNull.Value) ? false : Convert.ToBoolean(dr["PermisionWrite"]);
                            dvStchingCami.Visible = (dr["PermisionWrite"] == DBNull.Value) ? false : Convert.ToBoolean(dr["PermisionWrite"]);
                            dvStchingAssembly.Visible = (dr["PermisionWrite"] == DBNull.Value) ? false : Convert.ToBoolean(dr["PermisionWrite"]);
                            dvStchingPiping.Visible = (dr["PermisionWrite"] == DBNull.Value) ? false : Convert.ToBoolean(dr["PermisionWrite"]);
                            dvStchingUpper.Visible = (dr["PermisionWrite"] == DBNull.Value) ? false : Convert.ToBoolean(dr["PermisionWrite"]);
                            dvStchingUpperShell.Visible = (dr["PermisionWrite"] == DBNull.Value) ? false : Convert.ToBoolean(dr["PermisionWrite"]);
                            dvStchingLowerShell.Visible = (dr["PermisionWrite"] == DBNull.Value) ? false : Convert.ToBoolean(dr["PermisionWrite"]);
                            dvStchingShell.Visible = (dr["PermisionWrite"] == DBNull.Value) ? false : Convert.ToBoolean(dr["PermisionWrite"]);
                            dvStchingWaist.Visible = (dr["PermisionWrite"] == DBNull.Value) ? false : Convert.ToBoolean(dr["PermisionWrite"]);
                            dvStchingBand.Visible = (dr["PermisionWrite"] == DBNull.Value) ? false : Convert.ToBoolean(dr["PermisionWrite"]);
                            dvFinishing.Visible = (dr["PermisionWrite"] == DBNull.Value) ? false : Convert.ToBoolean(dr["PermisionWrite"]);


                            for (int i = 0; i < grdStichingFront.Rows.Count; i++)
                            {
                                LinkButton LinkButton = (LinkButton)grdStichingFront.Rows[i].FindControl("lnkDelete");
                                if (LinkButton != null)
                                    LinkButton.Visible = (dr["PermisionWrite"] == DBNull.Value) ? false : Convert.ToBoolean(dr["PermisionWrite"]);
                            }
                            for (int i = 0; i < grdStichingBack.Rows.Count; i++)
                            {
                                LinkButton LinkButton = (LinkButton)grdStichingBack.Rows[i].FindControl("lnkDelete");
                                if (LinkButton != null)
                                    LinkButton.Visible = (dr["PermisionWrite"] == DBNull.Value) ? false : Convert.ToBoolean(dr["PermisionWrite"]);
                            }
                            for (int i = 0; i < grdStichingcoller.Rows.Count; i++)
                            {
                                LinkButton LinkButton = (LinkButton)grdStichingcoller.Rows[i].FindControl("lnkDelete");
                                if (LinkButton != null)
                                    LinkButton.Visible = (dr["PermisionWrite"] == DBNull.Value) ? false : Convert.ToBoolean(dr["PermisionWrite"]);
                            }
                            for (int i = 0; i < grdStichingsleep.Rows.Count; i++)
                            {
                                LinkButton LinkButton = (LinkButton)grdStichingsleep.Rows[i].FindControl("lnkDelete");
                                if (LinkButton != null)
                                    LinkButton.Visible = (dr["PermisionWrite"] == DBNull.Value) ? false : Convert.ToBoolean(dr["PermisionWrite"]);
                            }
                            for (int i = 0; i < grdStichingneck.Rows.Count; i++)
                            {
                                LinkButton LinkButton = (LinkButton)grdStichingneck.Rows[i].FindControl("lnkDelete");
                                if (LinkButton != null)
                                    LinkButton.Visible = (dr["PermisionWrite"] == DBNull.Value) ? false : Convert.ToBoolean(dr["PermisionWrite"]);
                            }
                            for (int i = 0; i < grdStichingLining.Rows.Count; i++)
                            {
                                LinkButton LinkButton = (LinkButton)grdStichingLining.Rows[i].FindControl("lnkDelete");
                                if (LinkButton != null)
                                    LinkButton.Visible = (dr["PermisionWrite"] == DBNull.Value) ? false : Convert.ToBoolean(dr["PermisionWrite"]);
                            }
                            for (int i = 0; i < grdStichinglower.Rows.Count; i++)
                            {
                                LinkButton LinkButton = (LinkButton)grdStichinglower.Rows[i].FindControl("lnkDelete");
                                if (LinkButton != null)
                                    LinkButton.Visible = (dr["PermisionWrite"] == DBNull.Value) ? false : Convert.ToBoolean(dr["PermisionWrite"]);
                            }
                            for (int i = 0; i < grdStichingbottom.Rows.Count; i++)
                            {
                                LinkButton LinkButton = (LinkButton)grdStichingbottom.Rows[i].FindControl("lnkDelete");
                                if (LinkButton != null)
                                    LinkButton.Visible = (dr["PermisionWrite"] == DBNull.Value) ? false : Convert.ToBoolean(dr["PermisionWrite"]);
                            }
                            for (int i = 0; i < grdStichingassembly.Rows.Count; i++)
                            {
                                LinkButton LinkButton = (LinkButton)grdStichingassembly.Rows[i].FindControl("lnkDelete");
                                if (LinkButton != null)
                                    LinkButton.Visible = (dr["PermisionWrite"] == DBNull.Value) ? false : Convert.ToBoolean(dr["PermisionWrite"]);
                            }
                            for (int i = 0; i < grdPiping.Rows.Count; i++)
                            {
                                LinkButton LinkButton = (LinkButton)grdPiping.Rows[i].FindControl("lnkDelete");
                                if (LinkButton != null)
                                    LinkButton.Visible = (dr["PermisionWrite"] == DBNull.Value) ? false : Convert.ToBoolean(dr["PermisionWrite"]);
                            }
                            for (int i = 0; i < grdUppersection.Rows.Count; i++)
                            {
                                LinkButton LinkButton = (LinkButton)grdUppersection.Rows[i].FindControl("lnkDelete");
                                if (LinkButton != null)
                                    LinkButton.Visible = (dr["PermisionWrite"] == DBNull.Value) ? false : Convert.ToBoolean(dr["PermisionWrite"]);
                            }
                            for (int i = 0; i < grdUppershell.Rows.Count; i++)
                            {
                                LinkButton LinkButton = (LinkButton)grdUppershell.Rows[i].FindControl("lnkDelete");
                                if (LinkButton != null)
                                    LinkButton.Visible = (dr["PermisionWrite"] == DBNull.Value) ? false : Convert.ToBoolean(dr["PermisionWrite"]);
                            }
                            for (int i = 0; i < grdLowershell.Rows.Count; i++)
                            {
                                LinkButton LinkButton = (LinkButton)grdLowershell.Rows[i].FindControl("lnkDelete");
                                if (LinkButton != null)
                                    LinkButton.Visible = (dr["PermisionWrite"] == DBNull.Value) ? false : Convert.ToBoolean(dr["PermisionWrite"]);
                            }
                            for (int i = 0; i < grdShellsection.Rows.Count; i++)
                            {
                                LinkButton LinkButton = (LinkButton)grdShellsection.Rows[i].FindControl("lnkDelete");
                                if (LinkButton != null)
                                    LinkButton.Visible = (dr["PermisionWrite"] == DBNull.Value) ? false : Convert.ToBoolean(dr["PermisionWrite"]);
                            }
                            for (int i = 0; i < grdWaistsection.Rows.Count; i++)
                            {
                                LinkButton LinkButton = (LinkButton)grdWaistsection.Rows[i].FindControl("lnkDelete");
                                if (LinkButton != null)
                                    LinkButton.Visible = (dr["PermisionWrite"] == DBNull.Value) ? false : Convert.ToBoolean(dr["PermisionWrite"]);
                            }
                            for (int i = 0; i < grdBandsection.Rows.Count; i++)
                            {
                                LinkButton LinkButton = (LinkButton)grdBandsection.Rows[i].FindControl("lnkDelete");
                                if (LinkButton != null)
                                    LinkButton.Visible = (dr["PermisionWrite"] == DBNull.Value) ? false : Convert.ToBoolean(dr["PermisionWrite"]);
                            }
                            for (int i = 0; i < grdFinishing.Rows.Count; i++)
                            {
                                LinkButton LinkButton = (LinkButton)grdFinishing.Rows[i].FindControl("lnkDelete");
                                if (LinkButton != null)
                                    LinkButton.Visible = (dr["PermisionWrite"] == DBNull.Value) ? false : Convert.ToBoolean(dr["PermisionWrite"]);
                            }
                        }
                    }

                    if (ColumnId == 208)
                    {
                        foreach (DataRow dr in dRow)
                        {
                            grdOBManPower.Visible = true;
                            grdOBManPower.Enabled = (dr["PermisionWrite"] == DBNull.Value) ? false : Convert.ToBoolean(dr["PermisionWrite"]);
                            grdOBFinishingManPower.Visible = true;
                            grdOBFinishingManPower.Enabled = (dr["PermisionWrite"] == DBNull.Value) ? false : Convert.ToBoolean(dr["PermisionWrite"]);
                        }
                    }

                    if (ColumnId == 209)
                    {
                        foreach (DataRow dr in dRow)
                        {
                            grdOBkRemarks.Visible = true;
                            grdOBkRemarks.Enabled = (dr["PermisionWrite"] == DBNull.Value) ? false : Convert.ToBoolean(dr["PermisionWrite"]);
                            for (int i = 0; i < grdOBkRemarks.Rows.Count; i++)
                            {
                                LinkButton LinkButton = (LinkButton)grdOBkRemarks.Rows[i].FindControl("lnkDelete");
                                if (LinkButton != null)
                                    LinkButton.Visible = (dr["PermisionWrite"] == DBNull.Value) ? false : Convert.ToBoolean(dr["PermisionWrite"]);
                            }
                        }
                    }

                    if (ColumnId == 210)
                    {
                        foreach (DataRow dr in dRow)
                        {
                            chkIsFactoryIE.Visible = true;
                            chkIsFactoryIE.Enabled = (dr["PermisionWrite"] == DBNull.Value) ? false : Convert.ToBoolean(dr["PermisionWrite"]);
                        }
                    }

                    //if (ColumnId == 211)
                    //{
                    //    foreach (DataRow dr in dRow)
                    //    {
                    //        chkIsFactoryManager.Visible = true;
                    //        chkIsFactoryManager.Enabled = (dr["PermisionWrite"] == DBNull.Value) ? false : Convert.ToBoolean(dr["PermisionWrite"]);
                    //    }
                    //}

                    if (ColumnId == 212)
                    {
                        foreach (DataRow dr in dRow)
                        {
                            chkIsIEManager.Visible = true;
                            chkIsIEManager.Enabled = (dr["PermisionWrite"] == DBNull.Value) ? false : Convert.ToBoolean(dr["PermisionWrite"]);
                        }
                    }
                    //if (ColumnId == 213)
                    //{
                    //    foreach (DataRow dr in dRow)
                    //    {
                    //        chkIsProductionGM.Visible = true;
                    //        chkIsProductionGM.Enabled = (dr["PermisionWrite"] == DBNull.Value) ? false : Convert.ToBoolean(dr["PermisionWrite"]);
                    //    }
                    //}
                    if (ColumnId == 214)
                    {
                        foreach (DataRow dr in dRow)
                        {
                            btnSubmit.Visible = true;
                            btnSubmit.Enabled = (dr["PermisionWrite"] == DBNull.Value) ? false : Convert.ToBoolean(dr["PermisionWrite"]);
                        }
                    }

                    if (ColumnId == 215)
                    {
                        foreach (DataRow dr in dRow)
                        {
                            repCuttingStyleCode.Visible = true;
                            repCuttingStyleCode.Visible = (dr["PermisionWrite"] == DBNull.Value) ? false : Convert.ToBoolean(dr["PermisionWrite"]);
                        }
                    }
                    //}
                }
                CheckBoxEnable();
            }
            else
            {
                CheckBoxEnable();
                HideControlPermission();
            }
            // Add By Shubhendu 15 dec 2021
            int count = 0;
            foreach (ListItem li in lstSection.Items)
            {               
                if (li.Selected)
                {
                    btnSubmit.Enabled = true;
                    btnSubmit.Attributes.Remove("disabled");
                    count =  1;
                    break;
                }                
            }

            if (count == 0)
            {
                btnSubmit.Attributes.Add("disabled", "disabled");
                btnSubmit.ToolTip = "Please Choose a Selection On Stiching";
                Stitchingh3.Attributes.Add("color", "red");
            }

        }

        public void HideControlPermission()
        {
            ddlGarment.Visible = false;
            lstSection.Visible = false;
            btnSave.Visible = false;
            grdStichingFront.Visible = false;
            grdStichingBack.Visible = false;
            grdStichingcoller.Visible = false;
            grdStichingsleep.Visible = false;
            grdStichingneck.Visible = false;
            grdStichingLining.Visible = false;
            grdStichinglower.Visible = false;
            grdStichingbottom.Visible = false;
            grdStichingassembly.Visible = false;
            grdPiping.Visible = false;
            grdUppersection.Visible = false;
            grdUppershell.Visible = false;
            grdLowershell.Visible = false;
            grdShellsection.Visible = false;
            grdWaistsection.Visible = false;
            grdBandsection.Visible = false;
            grdFinishing.Visible = false;
            grdOBManPower.Visible = false;
            grdOBFinishingManPower.Visible = false;
            grdOBkRemarks.Visible = false;
            chkIsFactoryIE.Visible = false;
            //chkIsFactoryManager.Visible = false;
            chkIsIEManager.Visible = false;
            //chkIsProductionGM.Visible = false;
            btnSubmit.Visible = false;
            repCuttingStyleCode.Visible = false;
            dvStchingFront.Visible = false;
            dvStchingBack.Visible = false;
            dvStchingcoller.Visible = false;
            dvStchingSleeve.Visible = false;
            dvStchingFrill.Visible = false;
            dvStchingLining.Visible = false;
            dvStchinglower.Visible = false;
            dvStchingCami.Visible = false;
            dvStchingAssembly.Visible = false;
            dvStchingPiping.Visible = false;
            dvStchingUpper.Visible = false;
            dvStchingUpperShell.Visible = false;
            dvStchingLowerShell.Visible = false;
            dvStchingShell.Visible = false;
            dvStchingWaist.Visible = false;
            dvStchingBand.Visible = false;
            dvFinishing.Visible = false;
        }

        protected void CheckBoxEnable()
        {
            int IsHOPPMDone = obj_OrderController.GetHoppmCompleteByStyleId(styleid);
            int IsRepeatOrder = obj_OrderController.GetCheckIsRepeat(styleid);
            int IsStcApproved = obj_ProcessController.GetStcApproved(styleid);
            chkIsFactoryIE.Enabled = true;
            //chkIsProductionGM.Enabled = true;
            //chkIsFactoryManager.Enabled = true;
            chkIsIEManager.Enabled = true;

            if (IsHOPPMDone == 1 && IsStcApproved == 1 && chkIsFactoryIE.Checked == true && chkIsFactoryManager.Checked == true && chkIsIEManager.Checked == true)
                {
                    //chkIsFactoryIE.Enabled = false;
                    chkIsIEManager.Enabled = true;
                    //chkIsFactoryManager.Enabled = false;
                    //chkIsIEManager.Enabled = false;
                }
                else if (IsStcApproved == 1 && IsHOPPMDone == 0)
                {
                    // Default set false for chkIsFactoryIE and chkIsIEManager
                    chkIsFactoryIE.Enabled = true;
                    //chkIsProductionGM.Enabled = true;
                    chkIsFactoryManager.Enabled = true;
                    chkIsIEManager.Enabled = true;
                }
                

            
            //else
            //{
            //    chkIsFactoryIE.Enabled = false;
            //    chkIsProductionGM.Enabled = false;
            //    chkIsFactoryManager.Enabled = false;
            //    chkIsIEManager.Enabled = false;
            //}
            //if (IsHOPPMDone == 1)
            //{
            //    chkIsFactoryIE.Enabled = true;
            //    chkIsProductionGM.Enabled = true;
            //    //chkIsFactoryManager.Enabled = true;
            //    chkIsIEManager.Enabled = true;
            //}
            //else
            //{
            //    chkIsFactoryIE.Enabled = false;
            //    chkIsProductionGM.Enabled = false;
            //    //chkIsFactoryManager.Enabled = false;
            //    chkIsIEManager.Enabled = false;
            //}
           
            //if (IsStcApproved == 1)
            //{
            //    chkIsFactoryIE.Enabled = true;
            //    chkIsProductionGM.Enabled = true;
            //    chkIsFactoryManager.Enabled = true;
            //    chkIsIEManager.Enabled = true;
            //}
            //else
            //{
            //    chkIsFactoryIE.Enabled = false;
            //    chkIsProductionGM.Enabled = false;
            //    chkIsFactoryManager.Enabled = false;
            //    chkIsIEManager.Enabled = false;
            //}

            int IsObNeededOrNot = obj_OrderController.CheckObIsNeededOrNot(styleid);
            if (IsRepeatOrder == 0)
            {
                if (IsObNeededOrNot == 0)
                {
                    chkIsFactoryIE.Enabled = false;
                    //chkIsProductionGM.Enabled = false;
                    //chkIsFactoryManager.Enabled = false;
                    chkIsIEManager.Enabled = false;
                }
                else
                {
                    chkIsFactoryIE.Enabled = true;
                    //chkIsProductionGM.Enabled = true;
                    //chkIsFactoryManager.Enabled = true;
                    chkIsIEManager.Enabled = true;
                }
            }

            //if (IsStcApproved == 1)
            //{
            //    chkIsFactoryIE.Enabled = true;
            //    chkIsProductionGM.Enabled = true;
            //    //chkIsFactoryManager.Enabled = true;
            //    chkIsIEManager.Enabled = true;
            //}
            //else
            //{
            //    chkIsFactoryIE.Enabled = false;
            //    chkIsProductionGM.Enabled = false;
            //    //chkIsFactoryManager.Enabled = false;
            //    chkIsIEManager.Enabled = false;
            //}



            if (chkIsFactoryIE.Checked == true &&  chkIsIEManager.Checked == true )
            {
                hdnDisabled.Value = "1";
                ddlGarment.Enabled = false;
                lstSection.Enabled = false;
                btnSave.Visible = false;
                chkIsFactoryIE.Enabled = false;
                //chkIsFactoryManager.Enabled = false;
                chkIsIEManager.Enabled = false;
                //chkIsProductionGM.Enabled = false;

                dvCuttingPopup.Attributes.Add("style", "display:none");
                dvlblCuttingPopup.Attributes.Add("style", "display:inline");

                dvStchingFront.Attributes.Add("style", "display:none");
                dvlblStchingFront.Attributes.Add("style", "display:inline");

                dvStchingBack.Attributes.Add("style", "display:none");
                dvlblStchingBack.Attributes.Add("style", "display:inline");

                dvStchingcoller.Attributes.Add("style", "display:none");
                dvlblStchingcoller.Attributes.Add("style", "display:inline");

                dvStchingSleeve.Attributes.Add("style", "display:none");
                dvlblStchingSleeve.Attributes.Add("style", "display:inline");

                dvStchingFrill.Attributes.Add("style", "display:none");
                dvlblStchingFrill.Attributes.Add("style", "display:inline");

                dvStchingLining.Attributes.Add("style", "display:none");
                dvlblStchingLining.Attributes.Add("style", "display:inline");
                //new
                dvStchinglower.Attributes.Add("style", "display:none");
                dvlblStchinglower.Attributes.Add("style", "display:inline");

                dvStchingCami.Attributes.Add("style", "display:none");
                dvlblStchingCami.Attributes.Add("style", "display:inline");

                dvStchingAssembly.Attributes.Add("style", "display:none");
                dvlblStchingAssembly.Attributes.Add("style", "display:inline");

                dvStchingPiping.Attributes.Add("style", "display:none");
                dvlblStchingPiping.Attributes.Add("style", "display:inline");

                dvStchingUpper.Attributes.Add("style", "display:none");
                dvlblStchingUpper.Attributes.Add("style", "display:inline");

                dvStchingUpperShell.Attributes.Add("style", "display:none");
                dvlblStchingUpperShell.Attributes.Add("style", "display:inline");

                dvStchingLowerShell.Attributes.Add("style", "display:none");
                dvlblStchingLowerShell.Attributes.Add("style", "display:inline");

                dvStchingShell.Attributes.Add("style", "display:none");
                dvlblStchingShell.Attributes.Add("style", "display:inline");

                dvStchingWaist.Attributes.Add("style", "display:none");
                dvlblStchingWaist.Attributes.Add("style", "display:inline");

                dvStchingBand.Attributes.Add("style", "display:none");
                dvlblStchingBand.Attributes.Add("style", "display:inline");

                dvFinishing.Attributes.Add("style", "display:none");
                dvlblFinishing.Attributes.Add("style", "display:inline");

                hdnIsCheckEnable.Value = "1";
            }

            NewRefrence = Convert.ToInt32(hdnRef.Value);
            if (NewRefrence == 1)
            {
                chkIsFactoryIE.Checked = false;
                //chkIsFactoryManager.Checked = false;
                chkIsIEManager.Checked = false;
               // chkIsProductionGM.Checked = false;

                chkIsFactoryIE.Enabled = false;
                //chkIsFactoryManager.Enabled = false;
                chkIsIEManager.Enabled = false;
                //chkIsProductionGM.Enabled = false;
            }
            //else
            //{
            //    chkIsFactoryIE.Enabled = true;
            //    chkIsFactoryManager.Enabled = true;
            //    chkIsIEManager.Enabled = true;
            //    chkIsProductionGM.Enabled = true;
            //}


        }

        private void FinalOBDone()
        {
            int IsFinalOB = 0;
            IsFinalOB = WorkflowControllerInstance.IsFinalOBDone(styleid, TaskMode.Final_OB, "FinalOB");
            if (IsFinalOB == 0)
            {
                btnSubmit.Enabled = true;
            }
            else
            {
                GlobalFactorValue.Attributes.Add("class", "do-not-allow-typing");
                btnSubmit.Enabled = false;
            }
        }

        public void SetParameter()
        {
            if (obj_OBForm.StyleCode == null)
            {

            }
            hdnStyleCode.Value = obj_OBForm.StyleCode.ToString();

            hdnClientID.Value = obj_OBForm.ClientID.ToString();
            hdnDeptId.Value = obj_OBForm.DeptId.ToString();
            hdnStyleId.Value = styleid.ToString();
        }
        protected void showHidelable()
        {
            lblStyleCaption.Visible = false;
            lblStyle.Visible = false;
            lblGarment.Visible = true;
            ddlGarment.Visible = true;

            DataTable dtReuseStyle = new DataTable();
            DataTable dtCostingExit = new DataTable();

            dtCostingExit = obj_OrderProcessController.GetCostingComplete(styleid);
            dtReuseStyle = obj_OrderProcessController.GET_OB_ReUseStyle(styleid);
            if (dtCostingExit.Rows[0]["CostingExist"].ToString() == "1")
            {
                btnSubmit.Enabled = true;
                lblCostingText.Visible = false;
                btnSubmit.Attributes.Remove("Style");
                
            }
            else
            {
                btnSubmit.Enabled = false;
                btnSubmit.Attributes.Add("style", "pointer-events:none");
                lblCostingText.Visible= true;   
            }
            if (dtReuseStyle.Rows.Count > 0)
            {
                hdnReUse.Value = dtReuseStyle.Rows[0]["IsReUse"].ToString() == "True" ? "1" : "0";
            }
            ReUse = Convert.ToInt32(hdnReUse.Value);
            if (ReUse == 1)
            {

                dvCuttingPopup.Attributes.Add("style", "display:none");
                dvlblCuttingPopup.Attributes.Add("style", "display:inline");

                dvStchingFront.Attributes.Add("style", "display:none");
                dvlblStchingFront.Attributes.Add("style", "display:inline");

                dvStchingBack.Attributes.Add("style", "display:none");
                dvlblStchingBack.Attributes.Add("style", "display:inline");

                dvStchingcoller.Attributes.Add("style", "display:none");
                dvlblStchingcoller.Attributes.Add("style", "display:inline");

                dvStchingSleeve.Attributes.Add("style", "display:none");
                dvlblStchingSleeve.Attributes.Add("style", "display:inline");

                dvStchingFrill.Attributes.Add("style", "display:none");
                dvlblStchingFrill.Attributes.Add("style", "display:inline");

                dvStchingLining.Attributes.Add("style", "display:none");
                dvlblStchingLining.Attributes.Add("style", "display:inline");
                //new
                dvStchinglower.Attributes.Add("style", "display:none");
                dvlblStchinglower.Attributes.Add("style", "display:inline");

                dvStchingCami.Attributes.Add("style", "display:none");
                dvlblStchingCami.Attributes.Add("style", "display:inline");

                dvStchingAssembly.Attributes.Add("style", "display:none");
                dvlblStchingAssembly.Attributes.Add("style", "display:inline");

                dvStchingPiping.Attributes.Add("style", "display:none");
                dvlblStchingPiping.Attributes.Add("style", "display:inline");

                dvStchingUpper.Attributes.Add("style", "display:none");
                dvlblStchingUpper.Attributes.Add("style", "display:inline");

                dvStchingUpperShell.Attributes.Add("style", "display:none");
                dvlblStchingUpperShell.Attributes.Add("style", "display:inline");

                dvStchingLowerShell.Attributes.Add("style", "display:none");
                dvlblStchingLowerShell.Attributes.Add("style", "display:inline");

                dvStchingShell.Attributes.Add("style", "display:none");
                dvlblStchingShell.Attributes.Add("style", "display:inline");

                dvStchingWaist.Attributes.Add("style", "display:none");
                dvlblStchingWaist.Attributes.Add("style", "display:inline");

                dvStchingBand.Attributes.Add("style", "display:none");
                dvlblStchingBand.Attributes.Add("style", "display:inline");

                dvFinishing.Attributes.Add("style", "display:none");
                dvlblFinishing.Attributes.Add("style", "display:inline");

            }
            else
            {

                dvCuttingPopup.Attributes.Add("style", "display:inline");
                dvlblCuttingPopup.Attributes.Add("style", "display:none");

                dvStchingFront.Attributes.Add("style", "display:inline");
                dvlblStchingFront.Attributes.Add("style", "display:none");

                dvStchingBack.Attributes.Add("style", "display:inline");
                dvlblStchingBack.Attributes.Add("style", "display:none");

                dvStchingcoller.Attributes.Add("style", "display:inline");
                dvlblStchingcoller.Attributes.Add("style", "display:none");

                dvStchingSleeve.Attributes.Add("style", "display:inline");
                dvlblStchingSleeve.Attributes.Add("style", "display:none");

                dvStchingFrill.Attributes.Add("style", "display:inline");
                dvlblStchingFrill.Attributes.Add("style", "display:none");

                dvStchingLining.Attributes.Add("style", "display:inline");
                dvlblStchingLining.Attributes.Add("style", "display:none");
                //new
                dvStchinglower.Attributes.Add("style", "display:inline");
                dvlblStchinglower.Attributes.Add("style", "display:none");

                dvStchingCami.Attributes.Add("style", "display:inline");
                dvlblStchingCami.Attributes.Add("style", "display:none");

                dvStchingAssembly.Attributes.Add("style", "display:inline");
                dvlblStchingAssembly.Attributes.Add("style", "display:none");

                dvStchingPiping.Attributes.Add("style", "display:inline");
                dvlblStchingPiping.Attributes.Add("style", "display:none");

                dvStchingUpper.Attributes.Add("style", "display:inline");
                dvlblStchingUpper.Attributes.Add("style", "display:none");

                dvStchingUpperShell.Attributes.Add("style", "display:inline");
                dvlblStchingUpperShell.Attributes.Add("style", "display:none");

                dvStchingLowerShell.Attributes.Add("style", "display:inline");
                dvlblStchingLowerShell.Attributes.Add("style", "display:none");

                dvStchingShell.Attributes.Add("style", "display:inline");
                dvlblStchingShell.Attributes.Add("style", "display:none");

                dvStchingWaist.Attributes.Add("style", "display:inline");
                dvlblStchingWaist.Attributes.Add("style", "display:none");

                dvStchingBand.Attributes.Add("style", "display:inline");
                dvlblStchingBand.Attributes.Add("style", "display:none");

                dvFinishing.Attributes.Add("style", "display:inline");
                dvlblFinishing.Attributes.Add("style", "display:none");
            }

        }

        protected void bindStyleCode()
        {

            DataTable dtStyleCode = new DataTable();

            if (hdnCreateNew.Value == "1")
            {

                dtStyleCode = obj_OrderController.checkIsStyleCodeSave(obj_OBForm);
                repCuttingStyleCode.DataSource = dtStyleCode;
                repCuttingStyleCode.DataBind();

                //ddlGarment.SelectedValue = dtStyleCode.Rows[0]["GarmentTypeID"].ToString();
            }
        }
        public void GetQueryString()
        {
            if (null != Request.QueryString["styleid"])
            {
                styleid = Convert.ToInt32(Request.QueryString["styleid"].ToString());
            }
            if (null != Request.QueryString["stylenumber"])
            {
                obj_OBForm.StyleCode = Request.QueryString["stylenumber"].ToString();
            }
            if (null != Request.QueryString["ClientID"])
            {
                obj_OBForm.ClientID = Convert.ToInt32(Request.QueryString["ClientID"].ToString());
            }
            if (null != Request.QueryString["DeptId"])
            {
                obj_OBForm.DeptId = Convert.ToInt32(Request.QueryString["DeptId"].ToString());
            }
            if (null != Request.QueryString["OrderID"])
            {
                OrderID = Convert.ToInt32(Request.QueryString["OrderID"].ToString());
            }
        }
        protected void hidelabel()
        {
            lblStchingassembly.Visible = false;
            lblStchingBack.Visible = false;
            lblStchingFront.Visible = false;
            lblStchingcoller.Visible = false;
            lblStchingLining.Visible = false;
            lblStchinglower.Visible = false;
            lblStchingneck.Visible = false;
            lblStchingsleep.Visible = false;
            lblStchingbottom.Visible = false;
        }
        protected void BindStichingOBGrid(int CreateNew, int NewRefrence, int ReUse, int ReUseStyleId)
        {
            tr1.Visible = false;
            tr2.Visible = false;
            tr3.Visible = false;
            tr4.Visible = false;
            tr5.Visible = false;
            tr6.Visible = false;
            tr7.Visible = false;
            tr8.Visible = false;
            tr9.Visible = false;
            TdPiping.Visible = false;
            TdUpper.Visible = false;
            TdUppershell.Visible = false;

            TdLowershell.Visible = false;
            TdShellsection.Visible = false;
            TdWaistsection.Visible = false;
            TdBandsection.Visible = false;
            //aded by abhishek on 9/9/2015
            TdNeckNewsection.Visible = false;
            TdNeckNeckFacing.Visible = false;
            Tdfrontback.Visible = false;

            //end by abhishek on 9/9/2015


            //
            try
            {
                DataTable dtSection = new DataTable();
                dtSection = obj_OrderController.GetSectionById(obj_OBForm, styleid, ReUse, CreateNew, NewRefrence, ReUseStyleId);
                int Sectioncount = dtSection.Rows.Count;

                for (int iSection = 0; iSection < Sectioncount; iSection++)
                {
                    string strSection = dtSection.Rows[iSection]["Section"].ToString();
                    int SectionId = Convert.ToInt32(dtSection.Rows[iSection]["OBSectionID"]);
                    switch (SectionId)
                    {
                        case 1:
                            //For Stiching Front
                            grdStichingFront.DataSource = GetTable();
                            grdStichingFront.DataBind();
                            tr1.Visible = true;
                            grdStichingFront.Visible = true;
                            BindStichingFrontOB(CreateNew, NewRefrence, ReUse, ReUseStyleId);
                            lblStchingFront.Visible = true;


                            break;
                        case 2:
                            //For Stiching Back
                            grdStichingBack.DataSource = GetTable();
                            grdStichingBack.DataBind();
                            tr2.Visible = true;
                            grdStichingBack.Visible = true;
                            BindStichingBackOB(CreateNew, NewRefrence, ReUse, ReUseStyleId);
                            lblStchingBack.Visible = true;


                            break;
                        case 3:
                            //For Stiching coller
                            grdStichingcoller.DataSource = GetTable();
                            grdStichingcoller.DataBind();
                            tr3.Visible = true;
                            grdStichingcoller.Visible = true;
                            BindStichingcollerOB(CreateNew, NewRefrence, ReUse, ReUseStyleId);
                            lblStchingcoller.Visible = true;


                            break;
                        case 4:
                            //For Stiching sleep
                            grdStichingsleep.DataSource = GetTable();
                            grdStichingsleep.DataBind();
                            tr4.Visible = true;
                            grdStichingsleep.Visible = true;
                            BindStichingsleepOB(CreateNew, NewRefrence, ReUse, ReUseStyleId);
                            lblStchingsleep.Visible = true;


                            break;
                        case 5:
                            //For Stiching neck
                            grdStichingneck.DataSource = GetTable();
                            grdStichingneck.DataBind();
                            tr5.Visible = true;
                            grdStichingneck.Visible = true;
                            BindStichingneckOB(CreateNew, NewRefrence, ReUse, ReUseStyleId);
                            lblStchingneck.Visible = true;


                            break;
                        case 6:
                            //For Stiching Lining
                            grdStichingLining.DataSource = GetTable();
                            grdStichingLining.DataBind();
                            tr6.Visible = true;
                            grdStichingLining.Visible = true;
                            BindStichingLiningOB(CreateNew, NewRefrence, ReUse, ReUseStyleId);
                            lblStchingLining.Visible = true;


                            break;
                        case 7:
                            //For Stiching lower
                            grdStichinglower.DataSource = GetTable();
                            grdStichinglower.DataBind();
                            tr7.Visible = true;
                            grdStichinglower.Visible = true;
                            BindStichinglowerOB(CreateNew, NewRefrence, ReUse, ReUseStyleId);
                            lblStchinglower.Visible = true;


                            break;
                        case 8:
                            //For Stiching bottom
                            grdStichingbottom.DataSource = GetTable();
                            grdStichingbottom.DataBind();
                            tr8.Visible = true;
                            grdStichingbottom.Visible = true;
                            BindStichingbottomOB(CreateNew, NewRefrence, ReUse, ReUseStyleId);
                            lblStchingbottom.Visible = true;


                            break;
                        case 9:
                            //For Stiching assembly
                            grdStichingassembly.DataSource = GetTable();
                            grdStichingassembly.DataBind();
                            tr9.Visible = true;
                            grdStichingassembly.Visible = true;
                            BindStichingassemblyOB(CreateNew, NewRefrence, ReUse, ReUseStyleId);
                            lblStchingassembly.Visible = true;
                            break;

                        case 11:
                            //For Piping Section 
                            grdPiping.DataSource = GetTable();
                            grdPiping.DataBind();
                            TdPiping.Visible = true;
                            grdPiping.Visible = true;
                            BindStichingPipingOB(CreateNew, NewRefrence, ReUse, ReUseStyleId);
                            lblPiping.Visible = true;
                            break;

                        case 12:
                            //For Upper Section 
                            grdUppersection.DataSource = GetTable();
                            grdUppersection.DataBind();
                            TdUpper.Visible = true;
                            grdUppersection.Visible = true;
                            BindStichingUpperOB(CreateNew, NewRefrence, ReUse, ReUseStyleId);
                            lblUpper.Visible = true;
                            break;

                        case 13:
                            //For Upper shell Section 
                            grdUppershell.DataSource = GetTable();
                            grdUppershell.DataBind();
                            TdUppershell.Visible = true;
                            grdUppershell.Visible = true;
                            BindStichingUppershellOB(CreateNew, NewRefrence, ReUse, ReUseStyleId);
                            lblUppershell.Visible = true;
                            break;

                        case 14:
                            //For Lower Section 
                            grdLowershell.DataSource = GetTable();
                            grdLowershell.DataBind();
                            TdLowershell.Visible = true;
                            grdLowershell.Visible = true;
                            BindStichingLowershellOB(CreateNew, NewRefrence, ReUse, ReUseStyleId);
                            lblLowershell.Visible = true;
                            break;

                        case 15:
                            //For Shell Section 
                            grdShellsection.DataSource = GetTable();
                            grdShellsection.DataBind();
                            TdShellsection.Visible = true;
                            grdShellsection.Visible = true;
                            BindStichingShellsectionOB(CreateNew, NewRefrence, ReUse, ReUseStyleId);
                            lblShellsection.Visible = true;
                            break;

                        case 16:
                            //For Shell Section  
                            grdWaistsection.DataSource = GetTable();
                            grdWaistsection.DataBind();
                            TdWaistsection.Visible = true;
                            grdWaistsection.Visible = true;
                            BindStichingWaistsectionOB(CreateNew, NewRefrence, ReUse, ReUseStyleId);
                            lblWaistsection.Visible = true;
                            break;

                        case 17:
                            //For Shell Section  
                            grdBandsection.DataSource = GetTable();
                            grdBandsection.DataBind();
                            TdBandsection.Visible = true;
                            grdBandsection.Visible = true;
                            BindStichingBandsectionOB(CreateNew, NewRefrence, ReUse, ReUseStyleId);
                            lblBandsection.Visible = true;
                            break;
                        //added abhishek on 9/9/2015
                        case 18:
                            //For Neck Section Section  
                            grdNeckNewsection.DataSource = GetTable();
                            grdNeckNewsection.DataBind();
                            TdNeckNewsection.Visible = true;
                            grdNeckNewsection.Visible = true;
                            BindStichingNeckNewsectionOB(CreateNew, NewRefrence, ReUse, ReUseStyleId);
                            lblNeckNewsection.Visible = true;
                            break;

                        case 19:
                            //For neck faching Section  
                            grdNeckFacing.DataSource = GetTable();
                            grdNeckFacing.DataBind();
                            TdNeckNeckFacing.Visible = true;
                            grdNeckFacing.Visible = true;
                            BindStichingNeckNewfacingOB(CreateNew, NewRefrence, ReUse, ReUseStyleId);
                            lblNeckafcing.Visible = true;
                            break;
                        case 20:
                            //For neck faching Section  
                            grdfrontback.DataSource = GetTable();
                            grdfrontback.DataBind();
                            Tdfrontback.Visible = true;
                            grdfrontback.Visible = true;
                            BindStichingfrontandbackOB(CreateNew, NewRefrence, ReUse, ReUseStyleId);
                            lblfrontback.Visible = true;
                            break;

                        //case 21:
                        //    //For Shell Section  
                        //    grdBandsection.DataSource = GetTable();
                        //    grdBandsection.DataBind();
                        //    TdBandsection.Visible = true;
                        //    grdBandsection.Visible = true;
                        //    BindStichingBandsectionOB(CreateNew, NewRefrence, ReUse, ReUseStyleId);
                        //    lblBandsection.Visible = true;
                        //    break;
                        //end aby abhishek 9/9/2015
                    }
                }



            }
            catch (Exception ex)
            {
                string str = ex.Message;
            }
        }
        protected void BindStichingOBGridBlanck(int CreateNew, int NewRefrence, int ReUse, int ReUseStyleId)
        {
            DataTable dtSection = new DataTable();


            dtSection = obj_OrderController.GetSectionById(obj_OBForm, styleid, ReUse, CreateNew, NewRefrence, ReUseStyleId);
            int Sectioncount = dtSection.Rows.Count;

            for (int iSection = 0; iSection < Sectioncount; iSection++)
            {
                string strSection = dtSection.Rows[iSection]["Section"].ToString();
                int SectionId = Convert.ToInt32(dtSection.Rows[iSection]["OBSectionID"]);
                switch (SectionId)
                {
                    case 1:
                        //For Stiching Front
                        tr1.Visible = true;
                        BindStichingFrontBlanckOB();
                        lblStchingFront.Visible = true;
                        lblStchingFront.Text = strSection;
                        break;
                    case 2:
                        //For Stiching Back
                        tr2.Visible = true;
                        BindStichingBackBlanckOB();
                        lblStchingBack.Visible = true;
                        lblStchingBack.Text = strSection;
                        break;
                    case 3:
                        //For Stiching coller
                        tr3.Visible = true;
                        BindStichingcollerBlanckOB();
                        lblStchingcoller.Visible = true;
                        lblStchingcoller.Text = strSection;

                        break;
                    case 4:
                        //For Stiching sleep
                        tr4.Visible = true;
                        BindStichingsleepBlanckOB();
                        lblStchingsleep.Visible = true;
                        lblStchingsleep.Text = strSection;

                        break;
                    case 5:
                        //For Stiching neck
                        tr5.Visible = true;
                        BindStichingneckBlanckOB();
                        lblStchingneck.Visible = true;
                        lblStchingneck.Text = strSection;
                        break;
                    case 6:
                        //For Stiching Lining
                        tr6.Visible = true;
                        BindStichingLiningBlanckOB();
                        lblStchingLining.Visible = true;
                        lblStchingLining.Text = strSection;

                        break;
                    case 7:
                        //For Stiching lower
                        tr7.Visible = true;
                        BindStichinglowerBlanckOB();
                        lblStchinglower.Text = strSection;
                        break;
                    case 8:
                        //For Stiching bottom
                        tr8.Visible = true;
                        BindStichingbottomBlanckOB();
                        lblStchingbottom.Visible = true;
                        lblStchingbottom.Text = strSection;
                        break;
                    case 9:
                        //For Stiching assembly
                        tr9.Visible = true;
                        BindStichingassemblyBlanckOB();
                        lblStchingassembly.Visible = true;
                        lblStchingassembly.Text = strSection;

                        break;
                }
            }
        }

        public void BindControl(int CreateNew, int NewRefrence, int ReUse, int ReUseStyleId)
        {
            if (ReUse == 1)
            {
                ReUseStyleId = Convert.ToInt32(hdnReUseStyleId.Value);
                lstSection.Enabled = false;
            }
            DataSet dsStyle = obj_ProcessController.GetStyleNumberClientDept(styleid, ReUseStyleId, obj_OBForm.ClientID, obj_OBForm.DeptId, CreateNew, NewRefrence, ReUse, 3);
            if (dsStyle.Tables[0].Rows.Count > 0)
            {
                string StyleDetail = "";
                for (int i = 0; i < dsStyle.Tables[0].Rows.Count; i++)
                {
                    StyleDetail = StyleDetail + " [" + dsStyle.Tables[0].Rows[i]["StyleDetail"].ToString() + "],";
                }

                lblOBBasicInformation.Text = StyleDetail.TrimEnd(',');
            }

            int desigId = Convert.ToInt32(iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.Designation);
            int DeptId = Convert.ToInt32(iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.PrimaryGroupID);

            //List<OrderDetail> ds = obj_OrderController.GetMoInfo(styleid, obj_OBForm.ClientID, obj_OBForm.DeptId, CreateNew, NewRefrence, ReUse, ReUseStyleId, 3);
            //if (ds.Count > 0)
            //{
            //    //gvOBMO.DataSource = ds;
            //    //gvOBMO.DataBind();
            //}
            //adedd by abishek on 11/4/2017
            DataTable dt_Serial = obj_OrderController.GetMoInfoOb_new(styleid, obj_OBForm.ClientID, obj_OBForm.DeptId, CreateNew, NewRefrence, ReUse, ReUseStyleId, 3);
            if (dt_Serial.Rows.Count > 0)
            {
                rptSerialNumber.DataSource = dt_Serial;
                rptSerialNumber.DataBind();

            }
            
            int GarmentId = -1;
            DataTable dtOBHeader = new DataTable();

            DataTable dtOBSAMOld = obj_OrderProcessController.GetStiched_OBSAM(styleid);
            if (dtOBSAMOld.Rows.Count > 0)
            {
                if (Convert.ToInt32(dtOBSAMOld.Rows[0]["OB"]) > 0)
                {
                    lblOldOB.Text = dtOBSAMOld.Rows[0]["OB"].ToString();
                    //abhishek
                    //lblOBCaption.Text = "OB :";
                    lblOBCaption.Text = "OB W/S :";
                    //end
                }
                if (Convert.ToDecimal(dtOBSAMOld.Rows[0]["SAM"]) > 0)
                {
                    lblOldSam.Text = dtOBSAMOld.Rows[0]["SAM"].ToString();
                    lblSAMCaption.Text = "SAM :";
                }
            }

            dtOBHeader = obj_OrderProcessController.OB_HeaderExist(styleid);

            if (dtOBHeader.Rows.Count > 0)
            {
                try
                {
                    if (string.IsNullOrEmpty(dtOBHeader.Rows[0]["GarmentTypeID"].ToString()))
                    {
                        GarmentId = 0;
                    }
                    else
                    {
                         GarmentId = Convert.ToInt32(dtOBHeader.Rows[0]["GarmentTypeID"].ToString());
                    }

                    bool IsFactoryIE = (dtOBHeader.Rows[0]["IsFactoryIE"] == DBNull.Value) ? false : Convert.ToBoolean(dtOBHeader.Rows[0]["IsFactoryIE"]);
                    bool IsFactoryManager = (dtOBHeader.Rows[0]["IsFactoryManager"] == DBNull.Value) ? false : Convert.ToBoolean(dtOBHeader.Rows[0]["IsFactoryManager"]);
                    bool IsIEManager = (dtOBHeader.Rows[0]["IsIEManager"] == DBNull.Value) ? false : Convert.ToBoolean(dtOBHeader.Rows[0]["IsIEManager"]);
                    bool IsProductionGM = (dtOBHeader.Rows[0]["IsProductionGM"] == DBNull.Value) ? false : Convert.ToBoolean(dtOBHeader.Rows[0]["IsProductionGM"]);

                    //
                    chkIsFactoryIE.Enabled = IsFactoryIE;
                    //chkIsFactoryManager.Enabled = IsFactoryManager;
                    chkIsIEManager.Enabled = IsIEManager;
                    //chkIsProductionGM.Enabled = IsProductionGM;

                    //

                    DateTime date1 = (dtOBHeader.Rows[0]["IsFactoryIE_Date"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dtOBHeader.Rows[0]["IsFactoryIE_Date"]);
                    DateTime date2 = (dtOBHeader.Rows[0]["IsFactoryManager_Date"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dtOBHeader.Rows[0]["IsFactoryManager_Date"]);
                    DateTime date3 = (dtOBHeader.Rows[0]["IsIEManager_Date"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dtOBHeader.Rows[0]["IsIEManager_Date"]);
                    DateTime date4 = (dtOBHeader.Rows[0]["IsProductionGM_Date"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dtOBHeader.Rows[0]["IsProductionGM_Date"]);

                    if (IsFactoryIE == true)
                    {
                        chkIsFactoryIE.Checked = true;
                        lblIsFactoryIEDate.Text = date1.ToString("dd-MMM-yy");
                    }
                    else
                    {
                        chkIsFactoryIE.Checked = false;
                    }
                    //if (IsFactoryManager == true)
                    //{
                    //    chkIsFactoryManager.Checked = true;
                    //    lblIsFactoryManagerDate.Text = date2.ToString("dd-MMM-yy");
                    //}
                    //else
                    //{
                    //    chkIsFactoryManager.Checked = false;
                    //}
                    if (IsIEManager == true)
                    {
                        chkIsIEManager.Checked = true;
                        lblIsIEManager.Text = date3.ToString("dd-MMM-yy");
                    }
                    else
                    {
                        chkIsIEManager.Checked = false;
                    }
                    //if (IsProductionGM == true)
                    //{
                    //    chkIsProductionGM.Checked = true;
                    //    lblIsProductionGMDate.Text = date4.ToString("dd-MMM-yy");
                    //}
                    //else
                    //{
                    //    chkIsProductionGM.Checked = false;
                    //}


                    if (IsFactoryIE == true  && IsIEManager == true && IsProductionGM == true)
                    {
                        chkIsFactoryIE.Enabled = false;
                        //chkIsFactoryManager.Enabled = false;
                        chkIsIEManager.Enabled = false;
                        //chkIsProductionGM.Enabled = false;

                        hdnIsCheckEnable.Value = "1";
                    }

                }
                catch (Exception ex)
                {
                    string error = ex.Message;
                }
                ReUse = Convert.ToInt32(hdnReUse.Value);
                if (ReUse == 1)
                {
                    chkIsFactoryIE.Enabled = false;
                    //chkIsFactoryManager.Enabled = false;
                    chkIsIEManager.Enabled = false;
                   // chkIsProductionGM.Enabled = false;

                    hdnIsCheckEnable.Value = "1";
                }

            }

            DataTable dtGarmentType = new DataTable();
            dtGarmentType = obj_OrderController.GetGarmentType();
            ddlGarment.DataSource = dtGarmentType;
            ddlGarment.DataValueField = "GarmentTypeID";
            ddlGarment.DataTextField = "GarmentType";
            ddlGarment.DataBind();
            if (hdngarentType.Value != "-1")
            {
                ddlGarment.SelectedValue = hdngarentType.Value;
            }
            else
            {
                ddlGarment.SelectedValue = GarmentId.ToString();
                hdngarentType.Value = GarmentId.ToString();
            }


            lblStyle.Text = obj_OBForm.StyleCode.ToString();

            //For Cutting
            DataTable dtGrdCutting = new DataTable();
            grdCuttingOB.DataSource = GetTable();
            grdCuttingOB.DataBind();

            grdFinishing.DataSource = GetTable();
            grdFinishing.DataBind();


            //CMT 

            DataTable dtcmt = new DataTable();
            dtcmt = obj_OrderProcessController.GetOBSheet_CMT(styleid);
            if (dtcmt.Rows.Count > 0)
            {
                lblCmt.Text = dtcmt.Rows[0]["CMT"].ToString();
            }

        }
        protected void BindCuttingOB(int CreateNew, int NewRefrence, int ReUse, int ReUseStyleId)
        {
            DataTable dtFinalCutting = new DataTable();
            string Flag = "Cutting";
            int GarmentTypeId = 0;

            GarmentTypeId = Convert.ToInt32(hdngarentType.Value);


            dtFinalCutting = obj_OrderController.GetFinalOBData(Flag, obj_OBForm, styleid, ReUseStyleId, GarmentTypeId, CreateNew, ReUse, NewRefrence);
            grdCuttingOB.DataSource = dtFinalCutting;
            grdCuttingOB.DataBind();

        }
        protected void BindStichingFrontOB(int CreateNew, int NewRefrence, int ReUse, int ReUseStyleId)
        {
            DataTable dtFinalStichingFront = new DataTable();
            string Flag = "Stiching Front";

            int GarmentTypeId = 0;

            GarmentTypeId = Convert.ToInt32(hdngarentType.Value);
            dtFinalStichingFront = obj_OrderController.GetFinalOBData(Flag, obj_OBForm, styleid, ReUseStyleId, GarmentTypeId, CreateNew, ReUse, NewRefrence);
            grdStichingFront.DataSource = dtFinalStichingFront;
            grdStichingFront.DataBind();
        }
        protected void BindStichingBackOB(int CreateNew, int NewRefrence, int ReUse, int ReUseStyleId)
        {
            DataTable dtFinalStichingBack = new DataTable();
            string Flag = "Stiching Back";

            int GarmentTypeId = 0;

            GarmentTypeId = Convert.ToInt32(hdngarentType.Value);

            dtFinalStichingBack = obj_OrderController.GetFinalOBData(Flag, obj_OBForm, styleid, ReUseStyleId, GarmentTypeId, CreateNew, ReUse, NewRefrence);
            grdStichingBack.DataSource = dtFinalStichingBack;
            grdStichingBack.DataBind();
        }
        protected void BindStichingcollerOB(int CreateNew, int NewRefrence, int ReUse, int ReUseStyleId)
        {
            DataTable dtFinalStichingcoller = new DataTable();
            string Flag = "Stiching coller";

            int GarmentTypeId = 0;

            GarmentTypeId = Convert.ToInt32(hdngarentType.Value);
            //IsCreate = Convert.ToInt32(hdnCreateNew.Value);
            //IsReUse = 0;
            //ReUseStyleId = -1;
            //NewRefrence = 0;
            dtFinalStichingcoller = obj_OrderController.GetFinalOBData(Flag, obj_OBForm, styleid, ReUseStyleId, GarmentTypeId, CreateNew, ReUse, NewRefrence);
            grdStichingcoller.DataSource = dtFinalStichingcoller;
            grdStichingcoller.DataBind();
        }
        protected void BindStichingsleepOB(int CreateNew, int NewRefrence, int ReUse, int ReUseStyleId)
        {
            DataTable dtFinalStichingsleep = new DataTable();
            string Flag = "Stiching sleep";

            int GarmentTypeId = 0;

            GarmentTypeId = Convert.ToInt32(hdngarentType.Value);
            //IsCreate = Convert.ToInt32(hdnCreateNew.Value);
            //IsReUse = 0;
            //ReUseStyleId = -1;
            //NewRefrence = 0;
            dtFinalStichingsleep = obj_OrderController.GetFinalOBData(Flag, obj_OBForm, styleid, ReUseStyleId, GarmentTypeId, CreateNew, ReUse, NewRefrence);
            grdStichingsleep.DataSource = dtFinalStichingsleep;
            grdStichingsleep.DataBind();
        }
        protected void BindStichingneckOB(int CreateNew, int NewRefrence, int ReUse, int ReUseStyleId)
        {
            DataTable dtFinalStichingneck = new DataTable();
            string Flag = "Stiching neck";

            int GarmentTypeId = 0;

            GarmentTypeId = Convert.ToInt32(hdngarentType.Value);
            //IsCreate = Convert.ToInt32(hdnCreateNew.Value);
            //IsReUse = 0;
            //ReUseStyleId = -1;
            //NewRefrence = 0;
            dtFinalStichingneck = obj_OrderController.GetFinalOBData(Flag, obj_OBForm, styleid, ReUseStyleId, GarmentTypeId, CreateNew, ReUse, NewRefrence);

            grdStichingneck.DataSource = dtFinalStichingneck;
            grdStichingneck.DataBind();
        }
        protected void BindStichingLiningOB(int CreateNew, int NewRefrence, int ReUse, int ReUseStyleId)
        {
            DataTable dtFinalStichingLining = new DataTable();
            string Flag = "Stiching Lining";

            int GarmentTypeId = 0;

            GarmentTypeId = Convert.ToInt32(hdngarentType.Value);
            //IsCreate = Convert.ToInt32(hdnCreateNew.Value);
            //IsReUse = 0;
            //ReUseStyleId = -1;
            //NewRefrence = 0;
            dtFinalStichingLining = obj_OrderController.GetFinalOBData(Flag, obj_OBForm, styleid, ReUseStyleId, GarmentTypeId, CreateNew, ReUse, NewRefrence);
            grdStichingLining.DataSource = dtFinalStichingLining;
            grdStichingLining.DataBind();
        }
        protected void BindStichinglowerOB(int CreateNew, int NewRefrence, int ReUse, int ReUseStyleId)
        {
            DataTable dtFinalStichinglower = new DataTable();
            string Flag = "Stiching lower";

            int GarmentTypeId = 0;

            GarmentTypeId = Convert.ToInt32(hdngarentType.Value);
            //IsCreate = Convert.ToInt32(hdnCreateNew.Value);
            //IsReUse = 0;
            //ReUseStyleId = -1;
            //NewRefrence = 0;
            dtFinalStichinglower = obj_OrderController.GetFinalOBData(Flag, obj_OBForm, styleid, ReUseStyleId, GarmentTypeId, CreateNew, ReUse, NewRefrence);

            grdStichinglower.DataSource = dtFinalStichinglower;
            grdStichinglower.DataBind();
        }
        protected void BindStichingbottomOB(int CreateNew, int NewRefrence, int ReUse, int ReUseStyleId)
        {
            DataTable dtFinalStichingbottom = new DataTable();
            string Flag = "Stiching bottom";

            int GarmentTypeId = 0;
            GarmentTypeId = Convert.ToInt32(hdngarentType.Value);
            //IsCreate = Convert.ToInt32(hdnCreateNew.Value);
            //IsReUse = 0;
            //ReUseStyleId = -1;
            //NewRefrence = 0;
            dtFinalStichingbottom = obj_OrderController.GetFinalOBData(Flag, obj_OBForm, styleid, ReUseStyleId, GarmentTypeId, CreateNew, ReUse, NewRefrence);

            grdStichingbottom.DataSource = dtFinalStichingbottom;
            grdStichingbottom.DataBind();
        }
        protected void BindStichingassemblyOB(int CreateNew, int NewRefrence, int ReUse, int ReUseStyleId)
        {
            DataTable dtFinalStichingassembly = new DataTable();
            string Flag = "Stiching assembly";

            int GarmentTypeId = 0;

            GarmentTypeId = Convert.ToInt32(hdngarentType.Value);
            //IsCreate = Convert.ToInt32(hdnCreateNew.Value);
            //IsReUse = 0;
            //ReUseStyleId = -1;
            //NewRefrence = 0;
            dtFinalStichingassembly = obj_OrderController.GetFinalOBData(Flag, obj_OBForm, styleid, ReUseStyleId, GarmentTypeId, CreateNew, ReUse, NewRefrence);

            grdStichingassembly.DataSource = dtFinalStichingassembly;
            grdStichingassembly.DataBind();
        }
        //For Rest Stich
        //For Piping Section
        protected void BindStichingPipingOB(int CreateNew, int NewRefrence, int ReUse, int ReUseStyleId)
        {
            DataTable dtFinalgrdPiping = new DataTable();
            string Flag = "Piping";

            int GarmentTypeId = 0;
            GarmentTypeId = Convert.ToInt32(hdngarentType.Value);
            //IsCreate = Convert.ToInt32(hdnCreateNew.Value);
            //IsReUse = 0;
            //ReUseStyleId = -1;
            //NewRefrence = 0;
            dtFinalgrdPiping = obj_OrderController.GetFinalOBData(Flag, obj_OBForm, styleid, ReUseStyleId, GarmentTypeId, CreateNew, ReUse, NewRefrence);

            grdPiping.DataSource = dtFinalgrdPiping;
            grdPiping.DataBind();
        }
        //END Piping

        //For Upper Section
        protected void BindStichingUpperOB(int CreateNew, int NewRefrence, int ReUse, int ReUseStyleId)
        {
            DataTable dtFinalgrdUpper = new DataTable();
            string Flag = "Upper";

            int GarmentTypeId = 0;
            GarmentTypeId = Convert.ToInt32(hdngarentType.Value);
            //IsCreate = Convert.ToInt32(hdnCreateNew.Value);
            //IsReUse = 0;
            //ReUseStyleId = -1;
            //NewRefrence = 0;
            dtFinalgrdUpper = obj_OrderController.GetFinalOBData(Flag, obj_OBForm, styleid, ReUseStyleId, GarmentTypeId, CreateNew, ReUse, NewRefrence);

            grdUppersection.DataSource = dtFinalgrdUpper;
            grdUppersection.DataBind();
        }
        //END Upper

        //For Upper Shell Section 
        protected void BindStichingUppershellOB(int CreateNew, int NewRefrence, int ReUse, int ReUseStyleId)
        {
            DataTable dtgrdUppershell = new DataTable();
            string Flag = "Uppershell";

            int GarmentTypeId = 0;
            GarmentTypeId = Convert.ToInt32(hdngarentType.Value);
            //IsCreate = Convert.ToInt32(hdnCreateNew.Value);
            //IsReUse = 0;
            //ReUseStyleId = -1;
            //NewRefrence = 0;
            dtgrdUppershell = obj_OrderController.GetFinalOBData(Flag, obj_OBForm, styleid, ReUseStyleId, GarmentTypeId, CreateNew, ReUse, NewRefrence);

            grdUppershell.DataSource = dtgrdUppershell;
            grdUppershell.DataBind();
        }
        //END Upper

        //For Lower shell
        protected void BindStichingLowershellOB(int CreateNew, int NewRefrence, int ReUse, int ReUseStyleId)
        {
            DataTable dtgrdLowershell = new DataTable();
            string Flag = "Lowershell";

            int GarmentTypeId = 0;
            GarmentTypeId = Convert.ToInt32(hdngarentType.Value);
            //IsCreate = Convert.ToInt32(hdnCreateNew.Value);
            //IsReUse = 0;
            //ReUseStyleId = -1;
            //NewRefrence = 0;
            dtgrdLowershell = obj_OrderController.GetFinalOBData(Flag, obj_OBForm, styleid, ReUseStyleId, GarmentTypeId, CreateNew, ReUse, NewRefrence);

            grdLowershell.DataSource = dtgrdLowershell;
            grdLowershell.DataBind();
        }
        //END Lower 

        //For Shell section
        protected void BindStichingShellsectionOB(int CreateNew, int NewRefrence, int ReUse, int ReUseStyleId)
        {
            DataTable dtgrdShellsection = new DataTable();
            string Flag = "Shellsection";

            int GarmentTypeId = 0;

            GarmentTypeId = Convert.ToInt32(hdngarentType.Value);
            //IsCreate = Convert.ToInt32(hdnCreateNew.Value);
            //IsReUse = 0;
            //ReUseStyleId = -1;
            //NewRefrence = 0;
            dtgrdShellsection = obj_OrderController.GetFinalOBData(Flag, obj_OBForm, styleid, ReUseStyleId, GarmentTypeId, CreateNew, ReUse, NewRefrence);

            grdShellsection.DataSource = dtgrdShellsection;
            grdShellsection.DataBind();
        }
        //END Shell


        //For Waist section
        protected void BindStichingWaistsectionOB(int CreateNew, int NewRefrence, int ReUse, int ReUseStyleId)
        {
            DataTable dtgrdWaistsection = new DataTable();
            string Flag = "Waistsection";

            int GarmentTypeId = 0;
            GarmentTypeId = Convert.ToInt32(hdngarentType.Value);
            //IsCreate = Convert.ToInt32(hdnCreateNew.Value);
            //IsReUse = 0;
            //ReUseStyleId = -1;
            //NewRefrence = 0;
            dtgrdWaistsection = obj_OrderController.GetFinalOBData(Flag, obj_OBForm, styleid, ReUseStyleId, GarmentTypeId, CreateNew, ReUse, NewRefrence);

            grdWaistsection.DataSource = dtgrdWaistsection;
            grdWaistsection.DataBind();
        }
        //END Waist


        //For Band section
        protected void BindStichingBandsectionOB(int CreateNew, int NewRefrence, int ReUse, int ReUseStyleId)
        {
            DataTable dtgrdBandsection = new DataTable();
            string Flag = "Bandsection";

            int GarmentTypeId = 0;

            GarmentTypeId = Convert.ToInt32(hdngarentType.Value);
            //IsCreate = Convert.ToInt32(hdnCreateNew.Value);
            //IsReUse = 0;
            //ReUseStyleId = -1;
            //NewRefrence = 0;
            dtgrdBandsection = obj_OrderController.GetFinalOBData(Flag, obj_OBForm, styleid, ReUseStyleId, GarmentTypeId, CreateNew, ReUse, NewRefrence);

            grdBandsection.DataSource = dtgrdBandsection;
            grdBandsection.DataBind();
        }
        //END Waist02e6  


        //For Neck new  section
        //added by abhishek on 9/9/2015----------------------------------------------neck section
        protected void BindStichingNeckNewsectionOB(int CreateNew, int NewRefrence, int ReUse, int ReUseStyleId)
        {
            DataTable dtgrdNeckNewsection = new DataTable();
            string Flag = "NeckNewsection";

            int GarmentTypeId = 0;

            GarmentTypeId = Convert.ToInt32(hdngarentType.Value);
            //IsCreate = Convert.ToInt32(hdnCreateNew.Value);
            //IsReUse = 0;
            //ReUseStyleId = -1;
            //NewRefrence = 0;
            dtgrdNeckNewsection = obj_OrderController.GetFinalOBData(Flag, obj_OBForm, styleid, ReUseStyleId, GarmentTypeId, CreateNew, ReUse, NewRefrence);

            grdNeckNewsection.DataSource = dtgrdNeckNewsection;
            grdNeckNewsection.DataBind();
        }
        protected void BindStichingNeckNewfacingOB(int CreateNew, int NewRefrence, int ReUse, int ReUseStyleId)
        {
            DataTable dtgrdNeckfacingction = new DataTable();
            string Flag = "NeckFacing";

            int GarmentTypeId = 0;

            GarmentTypeId = Convert.ToInt32(hdngarentType.Value);
            //IsCreate = Convert.ToInt32(hdnCreateNew.Value);
            //IsReUse = 0;
            //ReUseStyleId = -1;
            //NewRefrence = 0;
            dtgrdNeckfacingction = obj_OrderController.GetFinalOBData(Flag, obj_OBForm, styleid, ReUseStyleId, GarmentTypeId, CreateNew, ReUse, NewRefrence);

            grdNeckFacing.DataSource = dtgrdNeckfacingction;
            grdNeckFacing.DataBind();
        }
        protected void BindStichingfrontandbackOB(int CreateNew, int NewRefrence, int ReUse, int ReUseStyleId)
        {
            DataTable dtgrdfrontback = new DataTable();
            string Flag = "frontback";

            int GarmentTypeId = 0;

            GarmentTypeId = Convert.ToInt32(hdngarentType.Value);
            //IsCreate = Convert.ToInt32(hdnCreateNew.Value);
            //IsReUse = 0;
            //ReUseStyleId = -1;
            //NewRefrence = 0;
            dtgrdfrontback = obj_OrderController.GetFinalOBData(Flag, obj_OBForm, styleid, ReUseStyleId, GarmentTypeId, CreateNew, ReUse, NewRefrence);

            grdfrontback.DataSource = dtgrdfrontback;
            grdfrontback.DataBind();
        }
        //END Neck new
        //--------------------------------------------------------------------------------end by abhishek on 9/9/2015

        //END 

        protected void BindFinishingOB(int CreateNew, int NewRefrence, int ReUse, int ReUseStyleId)
        {
            DataTable dtFinalFinishing = new DataTable();
            string Flag = "Finishing";

            int GarmentTypeId = 0;

            GarmentTypeId = Convert.ToInt32(hdngarentType.Value);
            //IsCreate = Convert.ToInt32(hdnCreateNew.Value);
            //IsReUse = 0;
            //ReUseStyleId = -1;
            //NewRefrence = 0;
            dtFinalFinishing = obj_OrderController.GetFinalOBData(Flag, obj_OBForm, styleid, ReUseStyleId, GarmentTypeId, CreateNew, ReUse, NewRefrence);

            grdFinishing.DataSource = dtFinalFinishing;
            grdFinishing.DataBind();
        }


        protected void BindStichingFrontBlanckOB()
        {
            grdStichingFront.DataSource = GetTable();
            grdStichingFront.DataBind();
        }
        protected void BindStichingBackBlanckOB()
        {
            grdStichingBack.DataSource = GetTable();
            grdStichingBack.DataBind();
        }
        protected void BindStichingcollerBlanckOB()
        {
            grdStichingcoller.DataSource = GetTable();
            grdStichingcoller.DataBind();
        }
        protected void BindStichingsleepBlanckOB()
        {
            grdStichingsleep.DataSource = GetTable();
            grdStichingsleep.DataBind();
        }
        protected void BindStichingneckBlanckOB()
        {
            grdStichingneck.DataSource = GetTable();
            grdStichingneck.DataBind();
        }
        protected void BindStichingLiningBlanckOB()
        {
            grdStichingLining.DataSource = GetTable();
            grdStichingLining.DataBind();
        }
        protected void BindStichinglowerBlanckOB()
        {
            grdStichinglower.DataSource = GetTable();
            grdStichinglower.DataBind();
        }
        protected void BindStichingbottomBlanckOB()
        {
            grdStichingbottom.DataSource = GetTable();
            grdStichingbottom.DataBind();
        }
        protected void BindStichingassemblyBlanckOB()
        {
            grdStichingassembly.DataSource = GetTable();
            grdStichingassembly.DataBind();
        }

        public static DataTable GetTable()
        {
            DataTable table = new DataTable();
            table.Columns.Add("Operationcutting", typeof(string));
            table.Columns.Add("FactoryWorkSpace", typeof(string));
            table.Columns.Add("Description", typeof(string));
            table.Columns.Add("AttachmentName", typeof(string));
            table.Columns.Add("SAM", typeof(string));
            table.Columns.Add("Comments", typeof(string));
            // Here we add five DataRows.
            // table.Rows.Add("", "", "", "","","");
            return table;
        }


        protected void grdCuttingOB_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grdCuttingOB.EditIndex = e.NewEditIndex;

            BindCuttingOB(0, 0, 0, -1);
        }
        protected void grdCuttingOB_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow Rows = grdCuttingOB.Rows[e.RowIndex];


            HiddenField hdnFinalCuttingOBID = Rows.FindControl("hdnFinalCuttingOBID") as HiddenField;
            HiddenField hdnOperationIdEdit = Rows.FindControl("hdnOperationIdEdit") as HiddenField;
            HiddenField hdnWorkerTypeIDEdit = Rows.FindControl("hdnWorkerTypeIDEdit") as HiddenField;
            HiddenField hdnAttachmentIDEdit = Rows.FindControl("hdnAttachmentIDEdit") as HiddenField;
            HiddenField hdnStyleSequence = Rows.FindControl("hdnStyleSequence") as HiddenField;

            TextBox txtOperation = Rows.FindControl("txtOperationEdit") as TextBox;
            Label txtOperationType = Rows.FindControl("txtOperationTypeEdit") as Label;
            Label txtMachine = Rows.FindControl("txtMachineEdit") as Label;

            Label txtAttachment = Rows.FindControl("txtAttachmentEdit") as Label;
            Label txtSAM = Rows.FindControl("txtSAMEdit") as Label;
            TextBox txtMachineCount = Rows.FindControl("txtMachineCountEdit") as TextBox;
            TextBox txtFinalCount = Rows.FindControl("txtFinalCountEdit") as TextBox;
            HyperLink lnkShow = Rows.FindControl("lnkShowEdit") as HyperLink;
            TextBox txtComments = Rows.FindControl("txtCommentsEdit") as TextBox;
            //edit by prabhaker 08-feb-17
            TextBox txtfactor = Rows.FindControl("txtEditFactor") as TextBox;
            //end edit by prabhaker 08-feb-17
            //hdnOperationIdEdit
            //hdnWorkerTypeIDEdit

            int OperationId = Convert.ToInt32(hdnOperationIdEdit.Value);
            int WorkerType = Convert.ToInt32(hdnWorkerTypeIDEdit.Value);
            int IsUpdate = 0;
            obj_OBForm.Flag = "Cutting";
            obj_OBForm.FinalOBID = Convert.ToInt32(hdnFinalCuttingOBID.Value);


            if (txtOperation.Text == "")
            {
                obj_OBForm.NoOfOperation = 0;
            }
            else
            {
                obj_OBForm.NoOfOperation = Convert.ToInt32(txtOperation.Text.Trim());
            }

            if (txtSAM.Text.Trim() != "")
                obj_OBForm.Sam = Convert.ToDouble(txtSAM.Text.Trim());
            if (txtMachineCount.Text.Trim() != "")
                obj_OBForm.MachineCount = Convert.ToDouble(txtMachineCount.Text.Trim());
            if (txtFinalCount.Text.Trim() != "")
                obj_OBForm.FinalCount = Convert.ToInt32(txtFinalCount.Text.Trim());
            obj_OBForm.Comments = txtComments.Text.Trim();
            string IsReuseCode = string.Empty;
            int StyleSequence = 0;

            int IsExist = obj_OrderController.GetOperationType(styleid, OperationId, WorkerType, obj_OBForm.NoOfOperation, obj_OBForm.Flag, obj_OBForm.FinalOBID);

            if (IsExist == 1)
            {
                ShowAlert("Operation Already Exist");
                //grdCuttingOB.EditIndex = -1;
                return;
            }
            else
            {
                if (hdnReUse.Value == "1")
                {
                    ReUseStyleId = -1;
                    StyleSequence = Convert.ToInt32(hdnStyleSequence.Value);
                    IsReuseCode = "";
                    IsUpdate = obj_OrderController.UpdateFinalOB(obj_OBForm, styleid, ReUseStyleId, IsReuseCode, StyleSequence);
                }
                else
                {
                    IsReuseCode = "";
                    IsUpdate = obj_OrderController.UpdateFinalOB(obj_OBForm, styleid, ReUseStyleId, IsReuseCode, StyleSequence);
                }

                if (IsUpdate > 0)
                {

                    grdCuttingOB.EditIndex = -1;
                    BindCuttingOB(0, 0, 0, -1);
                    //BindCuttingManPower(0, 0, 0, -1);
                    //ShowAlert("Updated Sucessfully !");
                    return;
                }
                else
                {
                    ShowAlert("Not Update !");
                    return;
                }

            }

        }
        protected void grdCuttingOB_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }
        protected void grdCuttingOB_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            int ReUse = Convert.ToInt32(hdnReUse.Value);

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //return;
                Label lblSAM = (Label)e.Row.FindControl("lblSAM");
                Label lblMachineCount = (Label)e.Row.FindControl("lblMachineCount");
                Label lblFinalCount = (Label)e.Row.FindControl("lblFinalCount");
               //--------------------Edit-by-prabhaker-08-feb-17------------
                Label txtFactor = (Label)e.Row.FindControl("txtFactor");

                if (txtFactor != null)
                {
                    if (txtFactor.Text == "")
                        txtFactor.Text = "0";

                    TotalFact = TotalFact + Convert.ToDouble(txtFactor.Text);

                }
                //--------------------End-Edit-by-prabhaker-08-feb-17------------
                if (lblSAM != null)
                {
                    if (lblSAM.Text == "")
                        lblSAM.Text = "0";

                    TotalSam = TotalSam + Convert.ToDouble(lblSAM.Text);

                }

                if (lblMachineCount != null)
                {
                    if (lblMachineCount.Text == "")
                        lblMachineCount.Text = "0";

                    TotalMachine = TotalMachine + Convert.ToDouble(lblMachineCount.Text);

                }

                if (lblFinalCount != null)
                {
                    if (lblFinalCount.Text == "")
                        lblFinalCount.Text = "0";

                    FinalMachine = FinalMachine + Convert.ToDouble(lblFinalCount.Text);

                }

                Label lblOperation = (Label)e.Row.FindControl("lblOperation");
                if (lblOperation != null)
                {
                    if (lblOperation.Text == "0")
                    {
                        lblOperation.Text = "";
                    }
                }
                //LinkButton lnkEdit = (LinkButton)e.Row.FindControl("lnkEdit");
                //if (ReUse == 1)
                //{
                //    lnkEdit.Visible = false;
                //}
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label txtSAMFooter = (Label)e.Row.FindControl("txtSAMFooter");
                //TotalSam
                if (TotalSam != 0)
                    txtSAMFooter.Text = TotalSam.ToString();
                //edit by prabhaker 08-feb-17
                Label lblFactorFooter = (Label)e.Row.FindControl("lblFactorFooter");
                if (TotalFact != 0)
                    lblFactorFooter.Text = TotalFact.ToString();

                //end edit by prabhaker 08-feb-17
                Label txtMachineCountFooter = (Label)e.Row.FindControl("txtMachineCountFooter");

                //TotalSam
                if (TotalMachine != 0)
                    txtMachineCountFooter.Text = TotalMachine.ToString();

                Label txtFinalCountFooter = (Label)e.Row.FindControl("txtFinalCountFooter");
                //TotalSam
                if (FinalMachine != 0)
                    txtFinalCountFooter.Text = FinalMachine.ToString();


                TotalSam = 0;
                TotalMachine = 0;
                FinalMachine = 0;
            }
        }
        protected void grdCuttingOB_PageIndexChanged(object sender, EventArgs e)
        {

        }
        protected void grdCuttingOB_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdCuttingOB.PageIndex = e.NewPageIndex;
            grdCuttingOB.EditIndex = -1;
            BindCuttingOB(0, 0, 0, -1);
        }
        protected void grdCuttingOB_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grdCuttingOB.EditIndex = -1;
            BindCuttingOB(0, 0, 0, -1);
        }

        //For Stiching Front
        protected void grdStichingFront_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdStichingFront.PageIndex = e.NewPageIndex;
            grdStichingFront.EditIndex = -1;

            ReUse = 0;
            ReUseStyleId = -1;
            NewRefrence = 0;
            CreateNew = 0;

            BindStichingFrontOB(CreateNew, NewRefrence, ReUse, ReUseStyleId);
        }
        protected void grdStichingFront_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {

            grdStichingFront.EditIndex = -1;
            ReUse = 0;
            ReUseStyleId = -1;
            NewRefrence = 0;
            CreateNew = 0;

            BindStichingFrontOB(CreateNew, NewRefrence, ReUse, ReUseStyleId);
        }
        protected void grdStichingFront_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            int ReUse = Convert.ToInt32(hdnReUse.Value);


            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //return;

                Literal ltIndex = (Literal)e.Row.FindControl("ltIndex");

                ltIndex.Text = (Convert.ToInt32(RowNum) + 1).ToString();
                RowNum = (Convert.ToInt32(RowNum) + 1);


               // Literal ltIndex = (Literal)e.Row.FindControl("ltIndex");
               // ltIndex.Text = ((grdStichingFront.PageIndex * grdStichingFront.PageSize) + e.Row.RowIndex + 1).ToString();

               // RowNum = ((grdStichingFront.PageIndex * grdStichingFront.PageSize) + e.Row.RowIndex + 1);

                Label lblSAM = (Label)e.Row.FindControl("lblSAM");
                TextBox lblMachineCount = (TextBox)e.Row.FindControl("lblMachineCount");
                TextBox lblFinalCount = (TextBox)e.Row.FindControl("lblFinalCount");
                TextBox lblComments = (TextBox)e.Row.FindControl("lblComments");
                // Edit By Prabhaker )8-feb-17

                TextBox txtFactor = (TextBox)e.Row.FindControl("txtFactor");
                if (txtFactor != null)
                {
                    if (txtFactor.Text == "")
                        txtFactor.Text = "0";

                    TotalFact = TotalFact + Convert.ToDouble(txtFactor.Text);

                }
           
                if (lblSAM != null)
                {
                    if (lblSAM.Text == "")
                        lblSAM.Text = "0";

                    TotalSam = TotalSam + Convert.ToDouble(lblSAM.Text);

                }

                if (lblMachineCount != null)
                {
                    if (lblMachineCount.Text == "")
                        lblMachineCount.Text = "0";

                    TotalMachine = TotalMachine + Convert.ToDouble(lblMachineCount.Text);

                }

                if (lblFinalCount != null)
                {
                    if (lblFinalCount.Text == "")
                        lblFinalCount.Text = "0";

                    FinalMachine = FinalMachine + Convert.ToDouble(lblFinalCount.Text);

                }

                Label lblOperation = (Label)e.Row.FindControl("lblOperation");
                if (lblOperation != null)
                {
                    if (lblOperation.Text == "0")
                    {
                        lblOperation.Text = "";
                    }
                }
                //LinkButton lnkEdit = (LinkButton)e.Row.FindControl("lnkEdit");
                //if (ReUse == 1)
                //{
                //    lnkEdit.Visible = false;
                //} 
                LinkButton lnkDelete = (LinkButton)e.Row.FindControl("lnkDelete");
                if (ReUse == 1)
                {
                    lnkDelete.Attributes.Add("style", "display:none;");
                    lblMachineCount.Enabled = false;
                    lblFinalCount.Enabled = false;
                    lblComments.Enabled = false;
                }
                if ((chkIsFactoryIE.Checked)  && (chkIsIEManager.Checked))
                {
                    lnkDelete.Attributes.Add("style", "display:none;");
                    lblMachineCount.Enabled = false;
                    lblFinalCount.Enabled = false;
                    lblComments.Enabled = false;
                }



            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label txtSAMFooter = (Label)e.Row.FindControl("txtSAMFooter");

                //TotalSam
                if (TotalSam != 0)
                    txtSAMFooter.Text = TotalSam.ToString();

                Label txtMachineCountFooter = (Label)e.Row.FindControl("txtMachineCountFooter");

               
                //TotalSam
                if (TotalMachine != 0)
                {
                    txtMachineCountFooter.Text = TotalMachine.ToString();
                    //hdnMachineCountFooter.Value = TotalSam.ToString();
                }
                //edit by prabhaker 08-feb-17
                Label lblFactorFooter = (Label)e.Row.FindControl("lblFactorFooter");
                if (TotalFact != 0)
                {
                    int TottalRowsCount = grdStichingFront.Rows.Count;
                    lblFactorFooter.Text = Math.Round((Convert.ToDecimal(TotalFact) / TottalRowsCount), 2).ToString();
                    //lblFactorFooter.Text = TotalFact.ToString();
                }
                //end edit by prabhaker 08-feb-17
                Label txtFinalCountFooter = (Label)e.Row.FindControl("txtFinalCountFooter");
                //TotalSam
                if (FinalMachine != 0)
                    txtFinalCountFooter.Text = FinalMachine.ToString();

                TotalFact = 0;
                TotalSam = 0;
                TotalMachine = 0;
                FinalMachine = 0;
            }

        }
        protected void grdStichingFront_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grdStichingFront.EditIndex = e.NewEditIndex;

            ReUse = 0;
            ReUseStyleId = -1;
            NewRefrence = 0;
            CreateNew = 0;
            BindStichingFrontOB(CreateNew, NewRefrence, ReUse, ReUseStyleId);

        }
        protected void grdStichingFront_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow Rows = grdStichingFront.Rows[e.RowIndex];

            HiddenField hdnFinalCuttingOBID = Rows.FindControl("hdnFinalCuttingOBID") as HiddenField;
            HiddenField hdnOperationIdEdit = Rows.FindControl("hdnOperationIdEdit") as HiddenField;
            HiddenField hdnWorkerTypeIDEdit = Rows.FindControl("hdnWorkerTypeIDEdit") as HiddenField;
            HiddenField hdnAttachmentIDEdit = Rows.FindControl("hdnAttachmentIDEdit") as HiddenField;
            HiddenField hdnStyleSequence = Rows.FindControl("hdnStyleSequence") as HiddenField;

            TextBox txtOperation = Rows.FindControl("txtOperationEdit") as TextBox;
            Label txtOperationType = Rows.FindControl("txtOperationTypeEdit") as Label;
            Label txtMachine = Rows.FindControl("txtMachineEdit") as Label;

            Label txtAttachment = Rows.FindControl("txtAttachmentEdit") as Label;
            Label txtSAM = Rows.FindControl("txtSAMEdit") as Label;
            TextBox txtMachineCount = Rows.FindControl("txtMachineCountEdit") as TextBox;
            TextBox txtFinalCount = Rows.FindControl("txtFinalCountEdit") as TextBox;
            HyperLink lnkShow = Rows.FindControl("lnkShowEdit") as HyperLink;
            TextBox txtComments = Rows.FindControl("txtCommentsEdit") as TextBox;
            //edit by prabhaker 08-feb-17
            TextBox txtfactor = Rows.FindControl("txtEditFactor") as TextBox;
            //end edit by prabhaker 08-feb-17
            int OperationId = Convert.ToInt32(hdnOperationIdEdit.Value);
            int WorkerType = Convert.ToInt32(hdnWorkerTypeIDEdit.Value);

            obj_OBForm.Flag = "Stiching Front";
            obj_OBForm.FinalOBID = Convert.ToInt32(hdnFinalCuttingOBID.Value);

            if (txtOperation.Text == "")
            {
                obj_OBForm.NoOfOperation = 0;
            }
            else
            {
                obj_OBForm.NoOfOperation = Convert.ToInt32(txtOperation.Text.Trim());
            }

            if (txtSAM.Text.Trim() != "")
                obj_OBForm.Sam = Convert.ToDouble(txtSAM.Text.Trim());
            if (txtMachineCount.Text.Trim() != "")
                obj_OBForm.MachineCount = Convert.ToDouble(txtMachineCount.Text.Trim());
            if (txtFinalCount.Text.Trim() != "")
                obj_OBForm.FinalCount = Convert.ToInt32(txtFinalCount.Text.Trim());
            obj_OBForm.Comments = txtComments.Text.Trim();

            int IsUpdate = 0;
            string IsReuseCode = string.Empty;
            int StyleSequence = 0;

            int IsExist = obj_OrderController.GetOperationType(styleid, OperationId, WorkerType, obj_OBForm.NoOfOperation, obj_OBForm.Flag, obj_OBForm.FinalOBID);

            if (IsExist == 1)
            {
                ShowAlert("Operation Already Exist");
                //grdStichingFront.EditIndex = -1;
                return;
            }
            else
            {
                if (hdnReUse.Value == "1")
                {
                    ReUseStyleId = -1;
                    StyleSequence = Convert.ToInt32(hdnStyleSequence.Value);
                    IsReuseCode = "";
                    IsUpdate = obj_OrderController.UpdateFinalOB(obj_OBForm, styleid, ReUseStyleId, IsReuseCode, StyleSequence);
                }
                else
                {
                    IsReuseCode = "";
                    IsUpdate = obj_OrderController.UpdateFinalOB(obj_OBForm, styleid, ReUseStyleId, IsReuseCode, StyleSequence);
                }

                if (IsUpdate > 0)
                {
                    grdStichingFront.EditIndex = -1;
                    ReUse = 0;
                    ReUseStyleId = -1;
                    NewRefrence = 0;
                    CreateNew = 0;
                    BindStichingFrontOB(CreateNew, NewRefrence, ReUse, ReUseStyleId);
                    BindStichingManPower(CreateNew, NewRefrence, ReUse, ReUseStyleId);

                    //ShowAlert("Updated Sucessfully !");
                    return;
                }
                else
                {
                    ShowAlert("Not Update !");
                    return;
                }
            }
        }
        //For Stiching Back
        protected void grdStichingBack_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdStichingBack.PageIndex = e.NewPageIndex;
            grdStichingBack.EditIndex = -1;
            ReUse = 0;
            ReUseStyleId = -1;
            NewRefrence = 0;
            CreateNew = 0;
            BindStichingBackOB(CreateNew, NewRefrence, ReUse, ReUseStyleId);

        }
        protected void grdStichingBack_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grdStichingBack.EditIndex = -1;
            ReUse = 0;
            ReUseStyleId = -1;
            NewRefrence = 0;
            CreateNew = 0;
            BindStichingBackOB(CreateNew, NewRefrence, ReUse, ReUseStyleId);
        }
        protected void grdStichingBack_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            int ReUse = Convert.ToInt32(hdnReUse.Value);


            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //return;
                Literal ltIndex = (Literal)e.Row.FindControl("ltIndex");

                ltIndex.Text = (Convert.ToInt32(RowNum) + 1).ToString();
                RowNum = (Convert.ToInt32(RowNum) + 1);

                Label lblSAM = (Label)e.Row.FindControl("lblSAM");
                TextBox lblMachineCount = (TextBox)e.Row.FindControl("lblMachineCount");
                TextBox lblFinalCount = (TextBox)e.Row.FindControl("lblFinalCount");
                TextBox lblComments = (TextBox)e.Row.FindControl("lblComments");
                // Edit By Prabhaker 8-feb-17

                TextBox txtFactor = (TextBox)e.Row.FindControl("txtFactor");
                if (txtFactor != null)
                {
                    if (txtFactor.Text == "")
                        txtFactor.Text = "0";

                    TotalFact = TotalFact + Convert.ToDouble(txtFactor.Text);

                }
                // End Edit By Prabhaker )8-feb-17
                if (lblSAM != null)
                {
                    if (lblSAM.Text == "")
                        lblSAM.Text = "0";

                    TotalSam = TotalSam + Convert.ToDouble(lblSAM.Text);

                }

                if (lblMachineCount != null)
                {
                    if (lblMachineCount.Text == "")
                        lblMachineCount.Text = "0";

                    TotalMachine = TotalMachine + Convert.ToDouble(lblMachineCount.Text);

                }

                if (lblFinalCount != null)
                {
                    if (lblFinalCount.Text == "")
                        lblFinalCount.Text = "0";

                    FinalMachine = FinalMachine + Convert.ToDouble(lblFinalCount.Text);

                }

                Label lblOperation = (Label)e.Row.FindControl("lblOperation");
                if (lblOperation != null)
                {
                    if (lblOperation.Text == "0")
                    {
                        lblOperation.Text = "";
                    }
                }
                //LinkButton lnkEdit = (LinkButton)e.Row.FindControl("lnkEdit");
                //if (ReUse == 1)
                //{
                //    lnkEdit.Visible = false;
                //}
                LinkButton lnkDelete = (LinkButton)e.Row.FindControl("lnkDelete");
                if (ReUse == 1)
                {
                    lnkDelete.Attributes.Add("style", "display:none;");
                    lblMachineCount.Enabled = false;
                    lblFinalCount.Enabled = false;
                    lblComments.Enabled = false;
                }
                if ((chkIsFactoryIE.Checked)  && (chkIsIEManager.Checked))
                {
                    lnkDelete.Attributes.Add("style", "display:none;");
                    lblMachineCount.Enabled = false;
                    lblFinalCount.Enabled = false;
                    lblComments.Enabled = false;
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label txtSAMFooter = (Label)e.Row.FindControl("txtSAMFooter");
                //TotalSam
                if (TotalSam != 0)
                    txtSAMFooter.Text = TotalSam.ToString();

                //edit by prabhaker 08-feb-17
                Label lblFactorFooter = (Label)e.Row.FindControl("lblFactorFooter");
                if (TotalFact != 0)
                {
                    int TottalRowsCount = grdStichingBack.Rows.Count;
                    lblFactorFooter.Text = Math.Round((Convert.ToDecimal(TotalFact) / TottalRowsCount), 2).ToString();
                    //lblFactorFooter.Text = TotalFact.ToString();
                }
                //end edit by prabhaker 08-feb-17
                Label txtMachineCountFooter = (Label)e.Row.FindControl("txtMachineCountFooter");

                //TotalSam
                if (TotalMachine != 0)
                    txtMachineCountFooter.Text = TotalMachine.ToString();

                Label txtFinalCountFooter = (Label)e.Row.FindControl("txtFinalCountFooter");
                //TotalSam
                if (FinalMachine != 0)
                    txtFinalCountFooter.Text = FinalMachine.ToString();

                TotalFact = 0;
                TotalSam = 0;
                TotalMachine = 0;
                FinalMachine = 0;
            }

        }
        protected void grdStichingBack_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grdStichingBack.EditIndex = e.NewEditIndex;

            ReUse = 0;
            ReUseStyleId = -1;
            NewRefrence = 0;
            CreateNew = 0;
            BindStichingBackOB(CreateNew, NewRefrence, ReUse, ReUseStyleId);

        }
        protected void grdStichingBack_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow Rows = grdStichingBack.Rows[e.RowIndex];

            HiddenField hdnFinalCuttingOBID = Rows.FindControl("hdnFinalCuttingOBID") as HiddenField;
            HiddenField hdnOperationIdEdit = Rows.FindControl("hdnOperationIdEdit") as HiddenField;
            HiddenField hdnWorkerTypeIDEdit = Rows.FindControl("hdnWorkerTypeIDEdit") as HiddenField;
            HiddenField hdnAttachmentIDEdit = Rows.FindControl("hdnAttachmentIDEdit") as HiddenField;
            HiddenField hdnStyleSequence = Rows.FindControl("hdnStyleSequence") as HiddenField;

            TextBox txtOperation = Rows.FindControl("txtOperationEdit") as TextBox;
            Label txtOperationType = Rows.FindControl("txtOperationTypeEdit") as Label;
            Label txtMachine = Rows.FindControl("txtMachineEdit") as Label;

            Label txtAttachment = Rows.FindControl("txtAttachmentEdit") as Label;
            Label txtSAM = Rows.FindControl("txtSAMEdit") as Label;
            TextBox txtMachineCount = Rows.FindControl("txtMachineCountEdit") as TextBox;
            TextBox txtFinalCount = Rows.FindControl("txtFinalCountEdit") as TextBox;
            HyperLink lnkShow = Rows.FindControl("lnkShowEdit") as HyperLink;
            TextBox txtComments = Rows.FindControl("txtCommentsEdit") as TextBox;
            //edit by prabhaker 08-feb-17
            TextBox txtfactor = Rows.FindControl("txtEditFactor") as TextBox;
            //end edit by prabhaker 08-feb-17
            int OperationId = Convert.ToInt32(hdnOperationIdEdit.Value);
            int WorkerType = Convert.ToInt32(hdnWorkerTypeIDEdit.Value);

            obj_OBForm.Flag = "Stiching Back";
            obj_OBForm.FinalOBID = Convert.ToInt32(hdnFinalCuttingOBID.Value);

            if (txtOperation.Text == "")
            {
                obj_OBForm.NoOfOperation = 0;
            }
            else
            {
                obj_OBForm.NoOfOperation = Convert.ToInt32(txtOperation.Text.Trim());
            }
            if (txtSAM.Text.Trim() != "")
                obj_OBForm.Sam = Convert.ToDouble(txtSAM.Text.Trim());
            if (txtMachineCount.Text.Trim() != "")
                obj_OBForm.MachineCount = Convert.ToDouble(txtMachineCount.Text.Trim());
            if (txtFinalCount.Text.Trim() != "")
                obj_OBForm.FinalCount = Convert.ToInt32(txtFinalCount.Text.Trim());
            obj_OBForm.Comments = txtComments.Text.Trim();

            int IsUpdate = 0;
            string IsReuseCode = string.Empty;
            int StyleSequence = 0;

            int IsExist = obj_OrderController.GetOperationType(styleid, OperationId, WorkerType, obj_OBForm.NoOfOperation, obj_OBForm.Flag, obj_OBForm.FinalOBID);

            if (IsExist == 1)
            {
                ShowAlert("Operation Already Exist");
                //grdStichingBack.EditIndex = -1;
                return;
            }
            else
            {
                if (hdnReUse.Value == "1")
                {
                    ReUseStyleId = -1;
                    StyleSequence = Convert.ToInt32(hdnStyleSequence.Value);
                    IsReuseCode = "";
                    IsUpdate = obj_OrderController.UpdateFinalOB(obj_OBForm, styleid, ReUseStyleId, IsReuseCode, StyleSequence);
                }
                else
                {
                    IsReuseCode = "";
                    IsUpdate = obj_OrderController.UpdateFinalOB(obj_OBForm, styleid, ReUseStyleId, IsReuseCode, StyleSequence);
                }

                if (IsUpdate > 0)
                {
                    grdStichingBack.EditIndex = -1;
                    ReUse = 0;
                    ReUseStyleId = -1;
                    NewRefrence = 0;
                    CreateNew = 0;
                    BindStichingBackOB(CreateNew, NewRefrence, ReUse, ReUseStyleId);
                    BindStichingManPower(CreateNew, NewRefrence, ReUse, ReUseStyleId);

                    //ShowAlert("Updated Sucessfully !");
                    return;
                }
                else
                {
                    ShowAlert("Not Update !");
                    return;
                }
            }
        }
        //For Stiching coller
        protected void grdStichingcoller_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdStichingcoller.PageIndex = e.NewPageIndex;
            grdStichingcoller.EditIndex = -1;
            ReUse = 0;
            ReUseStyleId = -1;
            NewRefrence = 0;
            CreateNew = 0;
            BindStichingcollerOB(CreateNew, NewRefrence, ReUse, ReUseStyleId);

        }
        protected void grdStichingcoller_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grdStichingcoller.EditIndex = -1;
            ReUse = 0;
            ReUseStyleId = -1;
            NewRefrence = 0;
            CreateNew = 0;
            BindStichingcollerOB(CreateNew, NewRefrence, ReUse, ReUseStyleId);
        }
        protected void grdStichingcoller_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            int ReUse = Convert.ToInt32(hdnReUse.Value);


            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //return;
                Literal ltIndex = (Literal)e.Row.FindControl("ltIndex");

                ltIndex.Text = (Convert.ToInt32(RowNum) + 1).ToString();
                RowNum = (Convert.ToInt32(RowNum) + 1);

                Label lblSAM = (Label)e.Row.FindControl("lblSAM");
                TextBox lblMachineCount = (TextBox)e.Row.FindControl("lblMachineCount");
                TextBox lblFinalCount = (TextBox)e.Row.FindControl("lblFinalCount");
                TextBox lblComments = (TextBox)e.Row.FindControl("lblComments");

                // Edit By Prabhaker )8-feb-17

                TextBox txtFactor = (TextBox)e.Row.FindControl("txtFactor");
                if (txtFactor != null)
                {
                    if (txtFactor.Text == "")
                        txtFactor.Text = "0";

                    TotalFact = TotalFact + Convert.ToDouble(txtFactor.Text);

                }
                // End Edit By Prabhaker )8-feb-17
                if (lblSAM != null)
                {
                    if (lblSAM.Text == "")
                        lblSAM.Text = "0";

                    TotalSam = TotalSam + Convert.ToDouble(lblSAM.Text);

                }

                if (lblMachineCount != null)
                {
                    if (lblMachineCount.Text == "")
                        lblMachineCount.Text = "0";

                    TotalMachine = TotalMachine + Convert.ToDouble(lblMachineCount.Text);

                }

                if (lblFinalCount != null)
                {
                    if (lblFinalCount.Text == "")
                        lblFinalCount.Text = "0";

                    FinalMachine = FinalMachine + Convert.ToDouble(lblFinalCount.Text);

                }

                Label lblOperation = (Label)e.Row.FindControl("lblOperation");
                if (lblOperation != null)
                {
                    if (lblOperation.Text == "0")
                    {
                        lblOperation.Text = "";
                    }
                }

                //LinkButton lnkEdit = (LinkButton)e.Row.FindControl("lnkEdit");
                //if (ReUse == 1)
                //{
                //    lnkEdit.Visible = false;
                //}
                LinkButton lnkDelete = (LinkButton)e.Row.FindControl("lnkDelete");
                if (ReUse == 1)
                {
                    lnkDelete.Attributes.Add("style", "display:none;");
                    lblMachineCount.Enabled = false;
                    lblFinalCount.Enabled = false;
                    lblComments.Enabled = false;
                }
                if ((chkIsFactoryIE.Checked)  && (chkIsIEManager.Checked))
                {
                    lnkDelete.Attributes.Add("style", "display:none;");
                    lblMachineCount.Enabled = false;
                    lblFinalCount.Enabled = false;
                    lblComments.Enabled = false;
                }

            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label txtSAMFooter = (Label)e.Row.FindControl("txtSAMFooter");
                //TotalSam
                if (TotalSam != 0)
                    txtSAMFooter.Text = TotalSam.ToString();
                //edit by prabhaker 08-feb-17
                Label lblFactorFooter = (Label)e.Row.FindControl("lblFactorFooter");
                if (TotalFact != 0)
                {
                    int TottalRowsCount = grdStichingcoller.Rows.Count;
                    lblFactorFooter.Text = Math.Round((Convert.ToDecimal(TotalFact) / TottalRowsCount), 2).ToString();
                    //lblFactorFooter.Text = TotalFact.ToString();
                }
                //end edit by prabhaker 08-feb-17
                Label txtMachineCountFooter = (Label)e.Row.FindControl("txtMachineCountFooter");

               
                //TotalSam
                if (TotalMachine != 0)
                    txtMachineCountFooter.Text = TotalMachine.ToString();

                Label txtFinalCountFooter = (Label)e.Row.FindControl("txtFinalCountFooter");
                //TotalSam
                if (FinalMachine != 0)
                    txtFinalCountFooter.Text = FinalMachine.ToString();

                TotalFact = 0;
                TotalSam = 0;
                TotalMachine = 0;
                FinalMachine = 0;
            }

        }
        protected void grdStichingcoller_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grdStichingcoller.EditIndex = e.NewEditIndex;

            ReUse = 0;
            ReUseStyleId = -1; ;
            NewRefrence = 0;
            CreateNew = 0;
            BindStichingcollerOB(CreateNew, NewRefrence, ReUse, ReUseStyleId);

        }
        protected void grdStichingcoller_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow Rows = grdStichingcoller.Rows[e.RowIndex];

            HiddenField hdnFinalCuttingOBID = Rows.FindControl("hdnFinalCuttingOBID") as HiddenField;
            HiddenField hdnOperationIdEdit = Rows.FindControl("hdnOperationIdEdit") as HiddenField;
            HiddenField hdnWorkerTypeIDEdit = Rows.FindControl("hdnWorkerTypeIDEdit") as HiddenField;
            HiddenField hdnAttachmentIDEdit = Rows.FindControl("hdnAttachmentIDEdit") as HiddenField;
            HiddenField hdnStyleSequence = Rows.FindControl("hdnStyleSequence") as HiddenField;

            TextBox txtOperation = Rows.FindControl("txtOperationEdit") as TextBox;
            Label txtOperationType = Rows.FindControl("txtOperationTypeEdit") as Label;
            Label txtMachine = Rows.FindControl("txtMachineEdit") as Label;

            Label txtAttachment = Rows.FindControl("txtAttachmentEdit") as Label;
            Label txtSAM = Rows.FindControl("txtSAMEdit") as Label;
            TextBox txtMachineCount = Rows.FindControl("txtMachineCountEdit") as TextBox;
            TextBox txtFinalCount = Rows.FindControl("txtFinalCountEdit") as TextBox;
            HyperLink lnkShow = Rows.FindControl("lnkShowEdit") as HyperLink;
            TextBox txtComments = Rows.FindControl("txtCommentsEdit") as TextBox;
            //edit by prabhaker 08-feb-17
            TextBox txtfactor = Rows.FindControl("txtEditFactor") as TextBox;
            //end edit by prabhaker 08-feb-17

            int OperationId = Convert.ToInt32(hdnOperationIdEdit.Value);
            int WorkerType = Convert.ToInt32(hdnWorkerTypeIDEdit.Value);

            obj_OBForm.Flag = "Stiching coller";
            obj_OBForm.FinalOBID = Convert.ToInt32(hdnFinalCuttingOBID.Value);


            if (txtOperation.Text == "")
            {
                obj_OBForm.NoOfOperation = 0;
            }
            else
            {
                obj_OBForm.NoOfOperation = Convert.ToInt32(txtOperation.Text.Trim());
            }
            if (txtSAM.Text.Trim() != "")
                obj_OBForm.Sam = Convert.ToDouble(txtSAM.Text.Trim());
            if (txtMachineCount.Text.Trim() != "")
                obj_OBForm.MachineCount = Convert.ToDouble(txtMachineCount.Text.Trim());
            if (txtFinalCount.Text.Trim() != "")
                obj_OBForm.FinalCount = Convert.ToInt32(txtFinalCount.Text.Trim());
            obj_OBForm.Comments = txtComments.Text.Trim();

            int IsUpdate = 0;
            string IsReuseCode = string.Empty;
            int StyleSequence = 0;

            int IsExist = obj_OrderController.GetOperationType(styleid, OperationId, WorkerType, obj_OBForm.NoOfOperation, obj_OBForm.Flag, obj_OBForm.FinalOBID);

            if (IsExist == 1)
            {
                ShowAlert("Operation Already Exist");
                //grdStichingcoller.EditIndex = -1;
                return;
            }
            else
            {
                if (hdnReUse.Value == "1")
                {
                    ReUseStyleId = -1;
                    StyleSequence = Convert.ToInt32(hdnStyleSequence.Value);
                    IsReuseCode = "";
                    IsUpdate = obj_OrderController.UpdateFinalOB(obj_OBForm, styleid, ReUseStyleId, IsReuseCode, StyleSequence);
                }
                else
                {
                    IsReuseCode = "";
                    IsUpdate = obj_OrderController.UpdateFinalOB(obj_OBForm, styleid, ReUseStyleId, IsReuseCode, StyleSequence);
                }

                if (IsUpdate > 0)
                {
                    grdStichingcoller.EditIndex = -1;
                    ReUse = 0;
                    ReUseStyleId = -1;
                    NewRefrence = 0;
                    CreateNew = 0;
                    BindStichingcollerOB(CreateNew, NewRefrence, ReUse, ReUseStyleId);
                    BindStichingManPower(CreateNew, NewRefrence, ReUse, ReUseStyleId);
                    //ShowAlert("Updated Sucessfully !");
                    return;
                }
                else
                {
                    ShowAlert("Not Update !");
                    return;
                }
            }
        }
        //For Stiching sleep
        protected void grdStichingsleep_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdStichingsleep.PageIndex = e.NewPageIndex;
            grdStichingsleep.EditIndex = -1;
            ReUse = 0;
            ReUseStyleId = -1;
            NewRefrence = 0;
            CreateNew = 0;
            BindStichingsleepOB(CreateNew, NewRefrence, ReUse, ReUseStyleId);

        }
        protected void grdStichingsleep_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grdStichingsleep.EditIndex = -1;
            ReUse = 0;
            ReUseStyleId = -1;
            NewRefrence = 0;
            CreateNew = 0;
            BindStichingsleepOB(CreateNew, NewRefrence, ReUse, ReUseStyleId);
        }
        protected void grdStichingsleep_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            int ReUse = Convert.ToInt32(hdnReUse.Value);


            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //return;
                Literal ltIndex = (Literal)e.Row.FindControl("ltIndex");
                ltIndex.Text = (Convert.ToInt32(RowNum) + 1).ToString();
                RowNum = (Convert.ToInt32(RowNum) + 1);

                Label lblSAM = (Label)e.Row.FindControl("lblSAM");
                TextBox lblMachineCount = (TextBox)e.Row.FindControl("lblMachineCount");
                TextBox lblFinalCount = (TextBox)e.Row.FindControl("lblFinalCount");
                TextBox lblComments = (TextBox)e.Row.FindControl("lblComments");
                // Edit By Prabhaker )8-feb-17

                TextBox txtFactor = (TextBox)e.Row.FindControl("txtFactor");

                if (txtFactor != null)
                {
                    if (txtFactor.Text == "")
                        txtFactor.Text = "0";

                    TotalFact = TotalFact + Convert.ToDouble(txtFactor.Text);

                }
                // End Edit By Prabhaker )8-feb-17
                if (lblSAM != null)
                {
                    if (lblSAM.Text == "")
                        lblSAM.Text = "0";

                    TotalSam = TotalSam + Convert.ToDouble(lblSAM.Text);

                }

                if (lblMachineCount != null)
                {
                    if (lblMachineCount.Text == "")
                        lblMachineCount.Text = "0";

                    TotalMachine = TotalMachine + Convert.ToDouble(lblMachineCount.Text);

                }

                if (lblFinalCount != null)
                {
                    if (lblFinalCount.Text == "")
                        lblFinalCount.Text = "0";

                    FinalMachine = FinalMachine + Convert.ToDouble(lblFinalCount.Text);

                }

                Label lblOperation = (Label)e.Row.FindControl("lblOperation");
                if (lblOperation != null)
                {
                    if (lblOperation.Text == "0")
                    {
                        lblOperation.Text = "";
                    }
                }
                //LinkButton lnkEdit = (LinkButton)e.Row.FindControl("lnkEdit");
                //if (ReUse == 1)
                //{
                //    lnkEdit.Visible = false;
                //}
                LinkButton lnkDelete = (LinkButton)e.Row.FindControl("lnkDelete");
                if (ReUse == 1)
                {
                    lnkDelete.Attributes.Add("style", "display:none;");
                    lblMachineCount.Enabled = false;
                    lblFinalCount.Enabled = false;
                    lblComments.Enabled = false;
                }
                if ((chkIsFactoryIE.Checked)  && (chkIsIEManager.Checked))
                {
                    lnkDelete.Attributes.Add("style", "display:none;");
                    lblMachineCount.Enabled = false;
                    lblFinalCount.Enabled = false;
                    lblComments.Enabled = false;
                }

            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label txtSAMFooter = (Label)e.Row.FindControl("txtSAMFooter");
                //TotalSam
                if (TotalSam != 0)
                    txtSAMFooter.Text = TotalSam.ToString();
                //edit by prabhaker 08-feb-17
                Label lblFactorFooter = (Label)e.Row.FindControl("lblFactorFooter");
                if (TotalFact != 0)
                {
                    int TottalRowsCount = grdStichingsleep.Rows.Count;
                    lblFactorFooter.Text = Math.Round((Convert.ToDecimal(TotalFact) / TottalRowsCount), 2).ToString();
                    //lblFactorFooter.Text = TotalFact.ToString();
                }
                //end edit by prabhaker 08-feb-17
                Label txtMachineCountFooter = (Label)e.Row.FindControl("txtMachineCountFooter");

               
                //TotalSam
                if (TotalMachine != 0)
                    txtMachineCountFooter.Text = TotalMachine.ToString();

                Label txtFinalCountFooter = (Label)e.Row.FindControl("txtFinalCountFooter");
                //TotalSam
                if (FinalMachine != 0)
                    txtFinalCountFooter.Text = FinalMachine.ToString();

                TotalFact = 0;
                TotalSam = 0;
                TotalMachine = 0;
                FinalMachine = 0;
            }

        }
        protected void grdStichingsleep_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grdStichingsleep.EditIndex = e.NewEditIndex;

            ReUse = 0;
            ReUseStyleId = -1;
            NewRefrence = 0;
            CreateNew = 0;
            BindStichingsleepOB(CreateNew, NewRefrence, ReUse, ReUseStyleId);
        }
        protected void grdStichingsleep_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow Rows = grdStichingsleep.Rows[e.RowIndex];

            HiddenField hdnFinalCuttingOBID = Rows.FindControl("hdnFinalCuttingOBID") as HiddenField;
            HiddenField hdnOperationIdEdit = Rows.FindControl("hdnOperationIdEdit") as HiddenField;
            HiddenField hdnWorkerTypeIDEdit = Rows.FindControl("hdnWorkerTypeIDEdit") as HiddenField;
            HiddenField hdnAttachmentIDEdit = Rows.FindControl("hdnAttachmentIDEdit") as HiddenField;
            HiddenField hdnStyleSequence = Rows.FindControl("hdnStyleSequence") as HiddenField;

            TextBox txtOperation = Rows.FindControl("txtOperationEdit") as TextBox;
            Label txtOperationType = Rows.FindControl("txtOperationTypeEdit") as Label;
            Label txtMachine = Rows.FindControl("txtMachineEdit") as Label;

            Label txtAttachment = Rows.FindControl("txtAttachmentEdit") as Label;
            Label txtSAM = Rows.FindControl("txtSAMEdit") as Label;
            TextBox txtMachineCount = Rows.FindControl("txtMachineCountEdit") as TextBox;
            TextBox txtFinalCount = Rows.FindControl("txtFinalCountEdit") as TextBox;
            HyperLink lnkShow = Rows.FindControl("lnkShowEdit") as HyperLink;
            TextBox txtComments = Rows.FindControl("txtCommentsEdit") as TextBox;
            //edit by prabhaker 08-feb-17
            TextBox txtfactor = Rows.FindControl("txtEditFactor") as TextBox;
            //end edit by prabhaker 08-feb-17
            int OperationId = Convert.ToInt32(hdnOperationIdEdit.Value);
            int WorkerType = Convert.ToInt32(hdnWorkerTypeIDEdit.Value);

            obj_OBForm.Flag = "Stiching sleep";
            obj_OBForm.FinalOBID = Convert.ToInt32(hdnFinalCuttingOBID.Value);

            if (txtOperation.Text == "")
            {
                obj_OBForm.NoOfOperation = 0;
            }
            else
            {
                obj_OBForm.NoOfOperation = Convert.ToInt32(txtOperation.Text.Trim());
            }
            if (txtSAM.Text.Trim() != "")
                obj_OBForm.Sam = Convert.ToDouble(txtSAM.Text.Trim());
            if (txtMachineCount.Text.Trim() != "")
                obj_OBForm.MachineCount = Convert.ToDouble(txtMachineCount.Text.Trim());
            if (txtFinalCount.Text.Trim() != "")
                obj_OBForm.FinalCount = Convert.ToInt32(txtFinalCount.Text.Trim());
            obj_OBForm.Comments = txtComments.Text.Trim();

            int IsUpdate = 0;
            string IsReuseCode = string.Empty;
            int StyleSequence = 0;

            int IsExist = obj_OrderController.GetOperationType(styleid, OperationId, WorkerType, obj_OBForm.NoOfOperation, obj_OBForm.Flag, obj_OBForm.FinalOBID);

            if (IsExist == 1)
            {
                ShowAlert("Operation Already Exist");
                //grdStichingsleep.EditIndex = -1;
                return;
            }
            else
            {
                if (hdnReUse.Value == "1")
                {
                    ReUseStyleId = -1;
                    StyleSequence = Convert.ToInt32(hdnStyleSequence.Value);
                    IsReuseCode = "";
                    IsUpdate = obj_OrderController.UpdateFinalOB(obj_OBForm, styleid, ReUseStyleId, IsReuseCode, StyleSequence);
                }
                else
                {
                    IsReuseCode = "";
                    IsUpdate = obj_OrderController.UpdateFinalOB(obj_OBForm, styleid, ReUseStyleId, IsReuseCode, StyleSequence);
                }

                if (IsUpdate > 0)
                {
                    grdStichingsleep.EditIndex = -1;

                    ReUse = 0;
                    ReUseStyleId = -1;
                    NewRefrence = 0;
                    CreateNew = 0;
                    BindStichingsleepOB(CreateNew, NewRefrence, ReUse, ReUseStyleId);
                    BindStichingManPower(CreateNew, NewRefrence, ReUse, ReUseStyleId);
                    //ShowAlert("Updated Sucessfully !");
                    return;
                }
                else
                {
                    ShowAlert("Not Update !");
                    return;
                }
            }
        }
        //For Stiching neck
        protected void grdStichingneck_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdStichingneck.PageIndex = e.NewPageIndex;
            grdStichingneck.EditIndex = -1;

            ReUse = 0;
            ReUseStyleId = -1;
            NewRefrence = 0;
            CreateNew = 0;
            BindStichingneckOB(CreateNew, NewRefrence, ReUse, ReUseStyleId);
        }
        protected void grdStichingneck_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grdStichingneck.EditIndex = -1;
            ReUse = 0;
            ReUseStyleId = -1;
            NewRefrence = 0;
            CreateNew = 0;
            BindStichingneckOB(CreateNew, NewRefrence, ReUse, ReUseStyleId);
        }
        protected void grdStichingneck_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            int ReUse = Convert.ToInt32(hdnReUse.Value);


            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //return;
                Literal ltIndex = (Literal)e.Row.FindControl("ltIndex");
                ltIndex.Text = (Convert.ToInt32(RowNum) + 1).ToString();
                RowNum = (Convert.ToInt32(RowNum) + 1);

                Label lblSAM = (Label)e.Row.FindControl("lblSAM");
                TextBox lblMachineCount = (TextBox)e.Row.FindControl("lblMachineCount");
                TextBox lblFinalCount = (TextBox)e.Row.FindControl("lblFinalCount");
                TextBox lblComments = (TextBox)e.Row.FindControl("lblComments");
                // Edit By Prabhaker )8-feb-17

                TextBox txtFactor = (TextBox)e.Row.FindControl("txtFactor");
                if (txtFactor != null)
                {
                    if (txtFactor.Text == "")
                        txtFactor.Text = "0";

                    TotalFact = TotalFact + Convert.ToDouble(txtFactor.Text);

                }
                // End Edit By Prabhaker )8-feb-17
                if (lblSAM != null)
                {
                    if (lblSAM.Text == "")
                        lblSAM.Text = "0";

                    TotalSam = TotalSam + Convert.ToDouble(lblSAM.Text);

                }

                if (lblMachineCount != null)
                {
                    if (lblMachineCount.Text == "")
                        lblMachineCount.Text = "0";

                    TotalMachine = TotalMachine + Convert.ToDouble(lblMachineCount.Text);

                }

                if (lblFinalCount != null)
                {
                    if (lblFinalCount.Text == "")
                        lblFinalCount.Text = "0";

                    FinalMachine = FinalMachine + Convert.ToDouble(lblFinalCount.Text);

                }

                Label lblOperation = (Label)e.Row.FindControl("lblOperation");
                if (lblOperation != null)
                {
                    if (lblOperation.Text == "0")
                    {
                        lblOperation.Text = "";
                    }
                }
                //LinkButton lnkEdit = (LinkButton)e.Row.FindControl("lnkEdit");
                //if (ReUse == 1)
                //{
                //    lnkEdit.Visible = false;
                //}
                LinkButton lnkDelete = (LinkButton)e.Row.FindControl("lnkDelete");
                if (ReUse == 1)
                {
                    lnkDelete.Attributes.Add("style", "display:none;");
                    lblMachineCount.Enabled = false;
                    lblFinalCount.Enabled = false;
                    lblComments.Enabled = false;
                }
                if ((chkIsFactoryIE.Checked)  && (chkIsIEManager.Checked))
                {
                    lnkDelete.Attributes.Add("style", "display:none;");
                    lblMachineCount.Enabled = false;
                    lblFinalCount.Enabled = false;
                    lblComments.Enabled = false;
                }

            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label txtSAMFooter = (Label)e.Row.FindControl("txtSAMFooter");
                //TotalSam
                if (TotalSam != 0)
                    txtSAMFooter.Text = TotalSam.ToString();
                //edit by prabhaker 08-feb-17
                Label lblFactorFooter = (Label)e.Row.FindControl("lblFactorFooter");
                if (TotalFact != 0)
                {
                    int TottalRowsCount = grdStichingneck.Rows.Count;
                    lblFactorFooter.Text = Math.Round((Convert.ToDecimal(TotalFact) / TottalRowsCount), 2).ToString();
                    //lblFactorFooter.Text = TotalFact.ToString();
                }
                //end edit by prabhaker 08-feb-17
                Label txtMachineCountFooter = (Label)e.Row.FindControl("txtMachineCountFooter");
                                
                //TotalSam
                if (TotalMachine != 0)
                    txtMachineCountFooter.Text = TotalMachine.ToString();

                Label txtFinalCountFooter = (Label)e.Row.FindControl("txtFinalCountFooter");
                //TotalSam
                if (FinalMachine != 0)
                    txtFinalCountFooter.Text = FinalMachine.ToString();

                TotalFact = 0;
                TotalSam = 0;
                TotalMachine = 0;
                FinalMachine = 0;
            }
        }
        protected void grdStichingneck_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow Rows = grdStichingneck.Rows[e.RowIndex];

            HiddenField hdnFinalCuttingOBID = Rows.FindControl("hdnFinalCuttingOBID") as HiddenField;
            HiddenField hdnOperationIdEdit = Rows.FindControl("hdnOperationIdEdit") as HiddenField;
            HiddenField hdnWorkerTypeIDEdit = Rows.FindControl("hdnWorkerTypeIDEditneck") as HiddenField;
            HiddenField hdnAttachmentIDEdit = Rows.FindControl("hdnAttachmentIDEdit") as HiddenField;
            HiddenField hdnStyleSequence = Rows.FindControl("hdnStyleSequence") as HiddenField;

            TextBox txtOperation = Rows.FindControl("txtOperationEdit") as TextBox;
            Label txtOperationType = Rows.FindControl("txtOperationTypeEdit") as Label;
            Label txtMachine = Rows.FindControl("txtMachineEdit") as Label;

            Label txtAttachment = Rows.FindControl("txtAttachmentEdit") as Label;
            Label txtSAM = Rows.FindControl("txtSAMEdit") as Label;
            TextBox txtMachineCount = Rows.FindControl("txtMachineCountEdit") as TextBox;
            TextBox txtFinalCount = Rows.FindControl("txtFinalCountEdit") as TextBox;
            HyperLink lnkShow = Rows.FindControl("lnkShowEdit") as HyperLink;
            TextBox txtComments = Rows.FindControl("txtCommentsEdit") as TextBox;
            //edit by prabhaker 08-feb-17
            TextBox txtfactor = Rows.FindControl("txtEditFactor") as TextBox;
            //end edit by prabhaker 08-feb-17
            int OperationId = Convert.ToInt32(hdnOperationIdEdit.Value);
            int WorkerType = Convert.ToInt32(hdnWorkerTypeIDEdit.Value);

            obj_OBForm.Flag = "Stiching neck";
            obj_OBForm.FinalOBID = Convert.ToInt32(hdnFinalCuttingOBID.Value);


            if (txtOperation.Text == "")
            {
                obj_OBForm.NoOfOperation = 0;
            }
            else
            {
                obj_OBForm.NoOfOperation = Convert.ToInt32(txtOperation.Text.Trim());
            }
            if (txtSAM.Text.Trim() != "")
                obj_OBForm.Sam = Convert.ToDouble(txtSAM.Text.Trim());
            if (txtMachineCount.Text.Trim() != "")
                obj_OBForm.MachineCount = Convert.ToDouble(txtMachineCount.Text.Trim());
            if (txtFinalCount.Text.Trim() != "")
                obj_OBForm.FinalCount = Convert.ToInt32(txtFinalCount.Text.Trim());
            obj_OBForm.Comments = txtComments.Text.Trim();

            int IsUpdate = 0;
            string IsReuseCode = string.Empty;
            int StyleSequence = 0;
            int IsExist = obj_OrderController.GetOperationType(styleid, OperationId, WorkerType, obj_OBForm.NoOfOperation, obj_OBForm.Flag, obj_OBForm.FinalOBID);

            if (IsExist == 1)
            {
                ShowAlert("Operation Already Exist");
                //grdStichingneck.EditIndex = -1;
                return;
            }
            else
            {
                if (hdnReUse.Value == "1")
                {
                    ReUseStyleId = -1;
                    StyleSequence = Convert.ToInt32(hdnStyleSequence.Value);
                    IsReuseCode = "";
                    IsUpdate = obj_OrderController.UpdateFinalOB(obj_OBForm, styleid, ReUseStyleId, IsReuseCode, StyleSequence);
                }
                else
                {
                    IsReuseCode = "";
                    IsUpdate = obj_OrderController.UpdateFinalOB(obj_OBForm, styleid, ReUseStyleId, IsReuseCode, StyleSequence);
                }

                if (IsUpdate > 0)
                {
                    grdStichingneck.EditIndex = -1;
                    ReUse = 0;
                    ReUseStyleId = -1;
                    NewRefrence = 0;
                    CreateNew = 0;
                    BindStichingneckOB(CreateNew, NewRefrence, ReUse, ReUseStyleId);
                    BindStichingManPower(CreateNew, NewRefrence, ReUse, ReUseStyleId);
                    //ShowAlert("Updated Sucessfully !");
                    return;
                }
                else
                {
                    ShowAlert("Not Update !");
                    return;
                }
            }
        }
        protected void grdStichingneck_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grdStichingneck.EditIndex = e.NewEditIndex;

            ReUse = 0;
            ReUseStyleId = -1;
            NewRefrence = 0;
            CreateNew = 0;
            BindStichingneckOB(CreateNew, NewRefrence, ReUse, ReUseStyleId);

        }
        //For Stiching Lining
        protected void grdStichingLining_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdStichingLining.PageIndex = e.NewPageIndex;
            grdStichingLining.EditIndex = -1;
            ReUse = 0;
            ReUseStyleId = -1;
            NewRefrence = 0;
            CreateNew = 0;
            BindStichingLiningOB(CreateNew, NewRefrence, ReUse, ReUseStyleId);

        }
        protected void grdStichingLining_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grdStichingLining.EditIndex = -1;
            ReUse = 0;
            ReUseStyleId = -1;
            NewRefrence = 0;
            CreateNew = 0;
            BindStichingLiningOB(CreateNew, NewRefrence, ReUse, ReUseStyleId);
        }
        protected void grdStichingLining_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            int ReUse = Convert.ToInt32(hdnReUse.Value);


            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //return;
                Literal ltIndex = (Literal)e.Row.FindControl("ltIndex");
                ltIndex.Text = (Convert.ToInt32(RowNum) + 1).ToString();
                RowNum = (Convert.ToInt32(RowNum) + 1);

                Label lblSAM = (Label)e.Row.FindControl("lblSAM");
                TextBox lblMachineCount = (TextBox)e.Row.FindControl("lblMachineCount");
                TextBox lblFinalCount = (TextBox)e.Row.FindControl("lblFinalCount");
                TextBox lblComments = (TextBox)e.Row.FindControl("lblComments");
                // Edit By Prabhaker )8-feb-17

                TextBox txtFactor = (TextBox)e.Row.FindControl("txtFactor");
                if (txtFactor != null)
                {
                    if (txtFactor.Text == "")
                        txtFactor.Text = "0";

                    TotalFact = TotalFact + Convert.ToDouble(txtFactor.Text);

                }
                // End Edit By Prabhaker )8-feb-17
                if (lblSAM != null)
                {
                    if (lblSAM.Text == "")
                        lblSAM.Text = "0";

                    TotalSam = TotalSam + Convert.ToDouble(lblSAM.Text);

                }

                if (lblMachineCount != null)
                {
                    if (lblMachineCount.Text == "")
                        lblMachineCount.Text = "0";

                    TotalMachine = TotalMachine + Convert.ToDouble(lblMachineCount.Text);

                }

                if (lblFinalCount != null)
                {
                    if (lblFinalCount.Text == "")
                        lblFinalCount.Text = "0";

                    FinalMachine = FinalMachine + Convert.ToDouble(lblFinalCount.Text);

                }

                Label lblOperation = (Label)e.Row.FindControl("lblOperation");
                if (lblOperation != null)
                {
                    if (lblOperation.Text == "0")
                    {
                        lblOperation.Text = "";
                    }
                }
                //LinkButton lnkEdit = (LinkButton)e.Row.FindControl("lnkEdit");
                //if (ReUse == 1)
                //{
                //    lnkEdit.Visible = false;
                //}
                LinkButton lnkDelete = (LinkButton)e.Row.FindControl("lnkDelete");
                if (ReUse == 1)
                {
                    lnkDelete.Attributes.Add("style", "display:none;");
                    lblMachineCount.Enabled = false;
                    lblFinalCount.Enabled = false;
                    lblComments.Enabled = false;
                }
                if ((chkIsFactoryIE.Checked)  && (chkIsIEManager.Checked))
                {
                    lnkDelete.Attributes.Add("style", "display:none;");
                    lblMachineCount.Enabled = false;
                    lblFinalCount.Enabled = false;
                    lblComments.Enabled = false;
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label txtSAMFooter = (Label)e.Row.FindControl("txtSAMFooter");
                //TotalSam
                if (TotalSam != 0)
                    txtSAMFooter.Text = TotalSam.ToString();
                //edit by prabhaker 08-feb-17
                Label lblFactorFooter = (Label)e.Row.FindControl("lblFactorFooter");
                if (TotalFact != 0)
                {
                    int TottalRowsCount = grdStichingLining.Rows.Count;
                    lblFactorFooter.Text = Math.Round((Convert.ToDecimal(TotalFact) / TottalRowsCount), 2).ToString();
                   // lblFactorFooter.Text = TotalFact.ToString();
                }
                //end edit by prabhaker 08-feb-17
                Label txtMachineCountFooter = (Label)e.Row.FindControl("txtMachineCountFooter");
                        
                //TotalSam
                if (TotalMachine != 0)
                    txtMachineCountFooter.Text = TotalMachine.ToString();

                Label txtFinalCountFooter = (Label)e.Row.FindControl("txtFinalCountFooter");
                //TotalSam
                if (FinalMachine != 0)
                    txtFinalCountFooter.Text = FinalMachine.ToString();

                TotalFact = 0;
                TotalSam = 0;
                TotalMachine = 0;
                FinalMachine = 0;
            }

        }
        protected void grdStichingLining_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grdStichingLining.EditIndex = e.NewEditIndex;

            ReUse = 0;
            ReUseStyleId = -1;
            NewRefrence = 0;
            CreateNew = 0;
            BindStichingLiningOB(CreateNew, NewRefrence, ReUse, ReUseStyleId);
        }

        protected void grdStichingLining_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow Rows = grdStichingLining.Rows[e.RowIndex];

            HiddenField hdnFinalCuttingOBID = Rows.FindControl("hdnFinalCuttingOBID") as HiddenField;
            HiddenField hdnOperationIdEdit = Rows.FindControl("hdnOperationIdEdit") as HiddenField;
            HiddenField hdnWorkerTypeIDEdit = Rows.FindControl("hdnWorkerTypeIDEdit") as HiddenField;
            HiddenField hdnAttachmentIDEdit = Rows.FindControl("hdnAttachmentIDEdit") as HiddenField;
            HiddenField hdnStyleSequence = Rows.FindControl("hdnStyleSequence") as HiddenField;

            TextBox txtOperation = Rows.FindControl("txtOperationEdit") as TextBox;
            Label txtOperationType = Rows.FindControl("txtOperationTypeEdit") as Label;
            Label txtMachine = Rows.FindControl("txtMachineEdit") as Label;

            Label txtAttachment = Rows.FindControl("txtAttachmentEdit") as Label;
            Label txtSAM = Rows.FindControl("txtSAMEdit") as Label;
            TextBox txtMachineCount = Rows.FindControl("txtMachineCountEdit") as TextBox;
            TextBox txtFinalCount = Rows.FindControl("txtFinalCountEdit") as TextBox;
            HyperLink lnkShow = Rows.FindControl("lnkShowEdit") as HyperLink;
            TextBox txtComments = Rows.FindControl("txtCommentsEdit") as TextBox;
            //edit by prabhaker 08-feb-17
            TextBox txtfactor = Rows.FindControl("txtEditFactor") as TextBox;
            //end edit by prabhaker 08-feb-17
            int OperationId = Convert.ToInt32(hdnOperationIdEdit.Value);
            int WorkerType = Convert.ToInt32(hdnWorkerTypeIDEdit.Value);

            obj_OBForm.Flag = "Stiching Lining";
            obj_OBForm.FinalOBID = Convert.ToInt32(hdnFinalCuttingOBID.Value);

            if (txtOperation.Text == "")
            {
                obj_OBForm.NoOfOperation = 0;
            }
            else
            {
                obj_OBForm.NoOfOperation = Convert.ToInt32(txtOperation.Text.Trim());
            }
            if (txtSAM.Text.Trim() != "")
                obj_OBForm.Sam = Convert.ToDouble(txtSAM.Text.Trim());
            if (txtMachineCount.Text.Trim() != "")
                obj_OBForm.MachineCount = Convert.ToDouble(txtMachineCount.Text.Trim());
            if (txtFinalCount.Text.Trim() != "")
                obj_OBForm.FinalCount = Convert.ToInt32(txtFinalCount.Text.Trim());
            obj_OBForm.Comments = txtComments.Text.Trim();

            int IsUpdate = 0;
            string IsReuseCode = string.Empty;
            int StyleSequence = 0;
            int IsExist = obj_OrderController.GetOperationType(styleid, OperationId, WorkerType, obj_OBForm.NoOfOperation, obj_OBForm.Flag, obj_OBForm.FinalOBID);

            if (IsExist == 1)
            {
                ShowAlert("Operation Already Exist");
                //grdStichingLining.EditIndex = -1;
                return;
            }
            else
            {
                if (hdnReUse.Value == "1")
                {
                    ReUseStyleId = -1;
                    StyleSequence = Convert.ToInt32(hdnStyleSequence.Value);
                    IsReuseCode = "";
                    IsUpdate = obj_OrderController.UpdateFinalOB(obj_OBForm, styleid, ReUseStyleId, IsReuseCode, StyleSequence);
                }
                else
                {
                    IsReuseCode = "";
                    IsUpdate = obj_OrderController.UpdateFinalOB(obj_OBForm, styleid, ReUseStyleId, IsReuseCode, StyleSequence);
                }

                if (IsUpdate > 0)
                {
                    grdStichingLining.EditIndex = -1;

                    ReUse = 0;
                    ReUseStyleId = -1;
                    NewRefrence = 0;
                    CreateNew = 0;
                    BindStichingLiningOB(CreateNew, NewRefrence, ReUse, ReUseStyleId);
                    BindStichingManPower(CreateNew, NewRefrence, ReUse, ReUseStyleId);
                    //ShowAlert("Updated Sucessfully !");
                    return;
                }
                else
                {
                    ShowAlert("Not Update !");
                    return;
                }
            }
        }
        //For Stiching lower
        protected void grdStichinglower_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdStichinglower.PageIndex = e.NewPageIndex;
            grdStichinglower.EditIndex = -1;
            ReUse = 0;
            ReUseStyleId = -1;
            NewRefrence = 0;
            CreateNew = 0;
            BindStichinglowerOB(CreateNew, NewRefrence, ReUse, ReUseStyleId);
        }

        protected void grdStichinglower_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            int ReUse = Convert.ToInt32(hdnReUse.Value);


            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //return;
                Literal ltIndex = (Literal)e.Row.FindControl("ltIndex");
                ltIndex.Text = (Convert.ToInt32(RowNum) + 1).ToString();
                RowNum = (Convert.ToInt32(RowNum) + 1);

                Label lblSAM = (Label)e.Row.FindControl("lblSAM");
                TextBox lblMachineCount = (TextBox)e.Row.FindControl("lblMachineCount");
                TextBox lblFinalCount = (TextBox)e.Row.FindControl("lblFinalCount");
                TextBox lblComments = (TextBox)e.Row.FindControl("lblComments");
                // Edit By Prabhaker )8-feb-17

                TextBox txtFactor = (TextBox)e.Row.FindControl("txtFactor");
                if (txtFactor != null)
                {
                    if (txtFactor.Text == "")
                        txtFactor.Text = "0";

                    TotalFact = TotalFact + Convert.ToDouble(txtFactor.Text);

                }
                // End Edit By Prabhaker )8-feb-17
                if (lblSAM != null)
                {
                    if (lblSAM.Text == "")
                        lblSAM.Text = "0";

                    TotalSam = TotalSam + Convert.ToDouble(lblSAM.Text);

                }

                if (lblMachineCount != null)
                {
                    if (lblMachineCount.Text == "")
                        lblMachineCount.Text = "0";

                    TotalMachine = TotalMachine + Convert.ToDouble(lblMachineCount.Text);

                }

                if (lblFinalCount != null)
                {
                    if (lblFinalCount.Text == "")
                        lblFinalCount.Text = "0";

                    FinalMachine = FinalMachine + Convert.ToDouble(lblFinalCount.Text);

                }

                Label lblOperation = (Label)e.Row.FindControl("lblOperation");
                if (lblOperation != null)
                {
                    if (lblOperation.Text == "0")
                    {
                        lblOperation.Text = "";
                    }
                }
                //LinkButton lnkEdit = (LinkButton)e.Row.FindControl("lnkEdit");
                //if (ReUse == 1)
                //{
                //    lnkEdit.Visible = false;
                //}
                LinkButton lnkDelete = (LinkButton)e.Row.FindControl("lnkDelete");
                if (ReUse == 1)
                {
                    lnkDelete.Attributes.Add("style", "display:none;");
                    lblMachineCount.Enabled = false;
                    lblFinalCount.Enabled = false;
                    lblComments.Enabled = false;
                }
                if ((chkIsFactoryIE.Checked)  && (chkIsIEManager.Checked))
                {
                    lnkDelete.Attributes.Add("style", "display:none;");
                    lblMachineCount.Enabled = false;
                    lblFinalCount.Enabled = false;
                    lblComments.Enabled = false;
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label txtSAMFooter = (Label)e.Row.FindControl("txtSAMFooter");
                //TotalSam
                if (TotalSam != 0)
                    txtSAMFooter.Text = TotalSam.ToString();
                //edit by prabhaker 08-feb-17
                Label lblFactorFooter = (Label)e.Row.FindControl("lblFactorFooter");
                if (TotalFact != 0)
                {
                    int TottalRowsCount = grdStichinglower.Rows.Count;
                    lblFactorFooter.Text = Math.Round((Convert.ToDecimal(TotalFact) / TottalRowsCount), 2).ToString();

                   // lblFactorFooter.Text = TotalFact.ToString();
                }
                //end edit by prabhaker 08-feb-17
                Label txtMachineCountFooter = (Label)e.Row.FindControl("txtMachineCountFooter");

                
                //TotalSam
                if (TotalMachine != 0)
                    txtMachineCountFooter.Text = TotalMachine.ToString();

                Label txtFinalCountFooter = (Label)e.Row.FindControl("txtFinalCountFooter");
                //TotalSam
                if (FinalMachine != 0)
                    txtFinalCountFooter.Text = FinalMachine.ToString();

                TotalFact = 0;
                TotalSam = 0;
                TotalMachine = 0;
                FinalMachine = 0;
            }

        }
        protected void grdStichinglower_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grdStichinglower.EditIndex = -1;
            ReUse = 0;
            ReUseStyleId = -1;
            NewRefrence = 0;
            CreateNew = 0;
            BindStichinglowerOB(CreateNew, NewRefrence, ReUse, ReUseStyleId);

        }
        protected void grdStichinglower_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grdStichinglower.EditIndex = e.NewEditIndex;

            ReUse = 0;
            ReUseStyleId = -1;
            NewRefrence = 0;
            CreateNew = 0;
            BindStichinglowerOB(CreateNew, NewRefrence, ReUse, ReUseStyleId);

        }
        protected void grdStichinglower_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow Rows = grdStichinglower.Rows[e.RowIndex];

            HiddenField hdnFinalCuttingOBID = Rows.FindControl("hdnFinalCuttingOBID") as HiddenField;
            HiddenField hdnOperationIdEdit = Rows.FindControl("hdnOperationIdEdit") as HiddenField;
            HiddenField hdnWorkerTypeIDEdit = Rows.FindControl("hdnWorkerTypeIDEdit") as HiddenField;
            HiddenField hdnAttachmentIDEdit = Rows.FindControl("hdnAttachmentIDEdit") as HiddenField;
            HiddenField hdnStyleSequence = Rows.FindControl("hdnStyleSequence") as HiddenField;

            TextBox txtOperation = Rows.FindControl("txtOperationEdit") as TextBox;
            Label txtOperationType = Rows.FindControl("txtOperationTypeEdit") as Label;
            Label txtMachine = Rows.FindControl("txtMachineEdit") as Label;

            Label txtAttachment = Rows.FindControl("txtAttachmentEdit") as Label;
            Label txtSAM = Rows.FindControl("txtSAMEdit") as Label;
            TextBox txtMachineCount = Rows.FindControl("txtMachineCountEdit") as TextBox;
            TextBox txtFinalCount = Rows.FindControl("txtFinalCountEdit") as TextBox;
            HyperLink lnkShow = Rows.FindControl("lnkShowEdit") as HyperLink;
            TextBox txtComments = Rows.FindControl("txtCommentsEdit") as TextBox;
            //edit by prabhaker 08-feb-17
            TextBox txtfactor = Rows.FindControl("txtEditFactor") as TextBox;
            //end edit by prabhaker 08-feb-17
            int OperationId = Convert.ToInt32(hdnOperationIdEdit.Value);
            int WorkerType = Convert.ToInt32(hdnWorkerTypeIDEdit.Value);

            obj_OBForm.Flag = "Stiching lower";
            obj_OBForm.FinalOBID = Convert.ToInt32(hdnFinalCuttingOBID.Value);

            if (txtOperation.Text == "")
            {
                obj_OBForm.NoOfOperation = 0;
            }
            else
            {
                obj_OBForm.NoOfOperation = Convert.ToInt32(txtOperation.Text.Trim());
            }
            if (txtSAM.Text.Trim() != "")
                obj_OBForm.Sam = Convert.ToDouble(txtSAM.Text.Trim());
            if (txtMachineCount.Text.Trim() != "")
                obj_OBForm.MachineCount = Convert.ToDouble(txtMachineCount.Text.Trim());
            if (txtFinalCount.Text.Trim() != "")
                obj_OBForm.FinalCount = Convert.ToInt32(txtFinalCount.Text.Trim());
            obj_OBForm.Comments = txtComments.Text.Trim();

            int IsUpdate = 0;
            string IsReuseCode = string.Empty;
            int StyleSequence = 0;

            int IsExist = obj_OrderController.GetOperationType(styleid, OperationId, WorkerType, obj_OBForm.NoOfOperation, obj_OBForm.Flag, obj_OBForm.FinalOBID);

            if (IsExist == 1)
            {
                ShowAlert("Operation Already Exist");
                //grdStichinglower.EditIndex = -1;
                return;
            }
            else
            {
                if (hdnReUse.Value == "1")
                {
                    ReUseStyleId = -1;
                    StyleSequence = Convert.ToInt32(hdnStyleSequence.Value);
                    IsReuseCode = "";
                    IsUpdate = obj_OrderController.UpdateFinalOB(obj_OBForm, styleid, ReUseStyleId, IsReuseCode, StyleSequence);
                }
                else
                {
                    IsReuseCode = "";
                    IsUpdate = obj_OrderController.UpdateFinalOB(obj_OBForm, styleid, ReUseStyleId, IsReuseCode, StyleSequence);
                }

                if (IsUpdate > 0)
                {
                    grdStichinglower.EditIndex = -1;
                    ReUse = 0;
                    ReUseStyleId = -1;
                    NewRefrence = 0;
                    CreateNew = 0;
                    BindStichinglowerOB(CreateNew, NewRefrence, ReUse, ReUseStyleId);
                    BindStichingManPower(CreateNew, NewRefrence, ReUse, ReUseStyleId);
                    //ShowAlert("Updated Sucessfully !");
                    return;
                }
                else
                {
                    ShowAlert("Not Update !");
                    return;
                }
            }
        }
        //For Stiching Buttom
        protected void grdStichingbottom_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdStichingbottom.PageIndex = e.NewPageIndex;
            grdStichingbottom.EditIndex = -1;
            ReUse = 0;
            ReUseStyleId = -1;
            NewRefrence = 0;
            CreateNew = 0;
            BindStichingbottomOB(CreateNew, NewRefrence, ReUse, ReUseStyleId);
        }
        protected void grdStichingbottom_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grdStichingbottom.EditIndex = -1;
            ReUse = 0;
            ReUseStyleId = -1;
            NewRefrence = 0;
            CreateNew = 0;
            BindStichingbottomOB(CreateNew, NewRefrence, ReUse, ReUseStyleId);
        }
        protected void grdStichingbottom_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            int ReUse = Convert.ToInt32(hdnReUse.Value);


            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //return;
                Literal ltIndex = (Literal)e.Row.FindControl("ltIndex");
                ltIndex.Text = (Convert.ToInt32(RowNum) + 1).ToString();
                RowNum = (Convert.ToInt32(RowNum) + 1);

                Label lblSAM = (Label)e.Row.FindControl("lblSAM");
                TextBox lblMachineCount = (TextBox)e.Row.FindControl("lblMachineCount");
                TextBox lblFinalCount = (TextBox)e.Row.FindControl("lblFinalCount");
                TextBox lblComments = (TextBox)e.Row.FindControl("lblComments");
                // Edit By Prabhaker )8-feb-17

                TextBox txtFactor = (TextBox)e.Row.FindControl("txtFactor");
                if (txtFactor != null)
                {
                    if (txtFactor.Text == "")
                        txtFactor.Text = "0";

                    TotalFact = TotalFact + Convert.ToDouble(txtFactor.Text);

                }
                // End Edit By Prabhaker )8-feb-17
                if (lblSAM != null)
                {
                    if (lblSAM.Text == "")
                        lblSAM.Text = "0";

                    TotalSam = TotalSam + Convert.ToDouble(lblSAM.Text);

                }

                if (lblMachineCount != null)
                {
                    if (lblMachineCount.Text == "")
                        lblMachineCount.Text = "0";

                    TotalMachine = TotalMachine + Convert.ToDouble(lblMachineCount.Text);

                }

                if (lblFinalCount != null)
                {
                    if (lblFinalCount.Text == "")
                        lblFinalCount.Text = "0";

                    FinalMachine = FinalMachine + Convert.ToDouble(lblFinalCount.Text);

                }

                Label lblOperation = (Label)e.Row.FindControl("lblOperation");
                if (lblOperation != null)
                {
                    if (lblOperation.Text == "0")
                    {
                        lblOperation.Text = "";
                    }
                }
                //LinkButton lnkEdit = (LinkButton)e.Row.FindControl("lnkEdit");
                //if (ReUse == 1)
                //{
                //    lnkEdit.Visible = false;
                //}
                LinkButton lnkDelete = (LinkButton)e.Row.FindControl("lnkDelete");
                if (ReUse == 1)
                {
                    lnkDelete.Attributes.Add("style", "display:none;");
                    lblMachineCount.Enabled = false;
                    lblFinalCount.Enabled = false;
                    lblComments.Enabled = false;
                }
                if ((chkIsFactoryIE.Checked)  && (chkIsIEManager.Checked))
                {
                    lnkDelete.Attributes.Add("style", "display:none;");
                    lblMachineCount.Enabled = false;
                    lblFinalCount.Enabled = false;
                    lblComments.Enabled = false;
                }

            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label txtSAMFooter = (Label)e.Row.FindControl("txtSAMFooter");
                //TotalSam
                if (TotalSam != 0)
                    txtSAMFooter.Text = TotalSam.ToString();
                //edit by prabhaker 08-feb-17
                Label lblFactorFooter = (Label)e.Row.FindControl("lblFactorFooter");
                if (TotalFact != 0)
                {
                    int TottalRowsCount = grdStichingbottom.Rows.Count;
                    lblFactorFooter.Text = Math.Round((Convert.ToDecimal(TotalFact) / TottalRowsCount),2).ToString();
                    //lblFactorFooter.Text = TotalFact.ToString();
                }
                //end edit by prabhaker 08-feb-17
                Label txtMachineCountFooter = (Label)e.Row.FindControl("txtMachineCountFooter");
                           
                //TotalSam
                if (TotalMachine != 0)
                    txtMachineCountFooter.Text = TotalMachine.ToString();

                Label txtFinalCountFooter = (Label)e.Row.FindControl("txtFinalCountFooter");
                //TotalSam
                if (FinalMachine != 0)
                    txtFinalCountFooter.Text = FinalMachine.ToString();

                TotalFact = 0;
                TotalSam = 0;
                TotalMachine = 0;
                FinalMachine = 0;
            }
        }
        protected void grdStichingbottom_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grdStichingbottom.EditIndex = e.NewEditIndex;

            ReUse = 0;
            ReUseStyleId = -1;
            NewRefrence = 0;
            CreateNew = 0;
            BindStichingbottomOB(CreateNew, NewRefrence, ReUse, ReUseStyleId);

        }
        protected void grdStichingbottom_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow Rows = grdStichingbottom.Rows[e.RowIndex];

            HiddenField hdnFinalCuttingOBID = Rows.FindControl("hdnFinalCuttingOBID") as HiddenField;
            HiddenField hdnOperationIdEdit = Rows.FindControl("hdnOperationIdEdit") as HiddenField;
            HiddenField hdnWorkerTypeIDEdit = Rows.FindControl("hdnWorkerTypeIDEdit") as HiddenField;
            HiddenField hdnAttachmentIDEdit = Rows.FindControl("hdnAttachmentIDEdit") as HiddenField;
            HiddenField hdnStyleSequence = Rows.FindControl("hdnStyleSequence") as HiddenField;

            TextBox txtOperation = Rows.FindControl("txtOperationEdit") as TextBox;
            Label txtOperationType = Rows.FindControl("txtOperationTypeEdit") as Label;
            Label txtMachine = Rows.FindControl("txtMachineEdit") as Label;

            Label txtAttachment = Rows.FindControl("txtAttachmentEdit") as Label;
            Label txtSAM = Rows.FindControl("txtSAMEdit") as Label;
            TextBox txtMachineCount = Rows.FindControl("txtMachineCountEdit") as TextBox;
            TextBox txtFinalCount = Rows.FindControl("txtFinalCountEdit") as TextBox;
            HyperLink lnkShow = Rows.FindControl("lnkShowEdit") as HyperLink;
            TextBox txtComments = Rows.FindControl("txtCommentsEdit") as TextBox;
            //edit by prabhaker 08-feb-17
            TextBox txtfactor = Rows.FindControl("txtEditFactor") as TextBox;
            //end edit by prabhaker 08-feb-17
            int OperationId = Convert.ToInt32(hdnOperationIdEdit.Value);
            int WorkerType = Convert.ToInt32(hdnWorkerTypeIDEdit.Value);

            obj_OBForm.Flag = "Stiching bottom";
            obj_OBForm.FinalOBID = Convert.ToInt32(hdnFinalCuttingOBID.Value);

            if (txtOperation.Text == "")
            {
                obj_OBForm.NoOfOperation = 0;
            }
            else
            {
                obj_OBForm.NoOfOperation = Convert.ToInt32(txtOperation.Text.Trim());
            }
            if (txtSAM.Text.Trim() != "")
                obj_OBForm.Sam = Convert.ToDouble(txtSAM.Text.Trim());
            if (txtMachineCount.Text.Trim() != "")
                obj_OBForm.MachineCount = Convert.ToDouble(txtMachineCount.Text.Trim());
            if (txtFinalCount.Text.Trim() != "")
                obj_OBForm.FinalCount = Convert.ToInt32(txtFinalCount.Text.Trim());
            obj_OBForm.Comments = txtComments.Text.Trim();

            int IsUpdate = 0;
            string IsReuseCode = string.Empty;
            int StyleSequence = 0;

            int IsExist = obj_OrderController.GetOperationType(styleid, OperationId, WorkerType, obj_OBForm.NoOfOperation, obj_OBForm.Flag, obj_OBForm.FinalOBID);

            if (IsExist == 1)
            {
                ShowAlert("Operation Already Exist");
                //grdStichingbottom.EditIndex = -1;
                return;
            }
            else
            {
                if (hdnReUse.Value == "1")
                {
                    ReUseStyleId = -1;
                    StyleSequence = Convert.ToInt32(hdnStyleSequence.Value);
                    IsReuseCode = "";
                    IsUpdate = obj_OrderController.UpdateFinalOB(obj_OBForm, styleid, ReUseStyleId, IsReuseCode, StyleSequence);
                }
                else
                {
                    IsReuseCode = "";
                    IsUpdate = obj_OrderController.UpdateFinalOB(obj_OBForm, styleid, ReUseStyleId, IsReuseCode, StyleSequence);
                }

                if (IsUpdate > 0)
                {
                    grdStichingbottom.EditIndex = -1;
                    ReUse = 0;
                    ReUseStyleId = -1;
                    NewRefrence = 0;
                    CreateNew = 0;
                    BindStichingbottomOB(CreateNew, NewRefrence, ReUse, ReUseStyleId);
                    BindStichingManPower(CreateNew, NewRefrence, ReUse, ReUseStyleId);
                    //ViewState["Stiching"] = "1";
                    //ShowAlert("Updated Sucessfully !");
                    return;
                }
                else
                {
                    ShowAlert("Not Update !");
                    return;
                }
            }
        }
        //For Stiching assembly
        protected void grdStichingassembly_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdStichingassembly.PageIndex = e.NewPageIndex;
            grdStichingassembly.EditIndex = -1;
            ReUse = 0;
            ReUseStyleId = -1;
            NewRefrence = 0;
            CreateNew = 0;
            BindStichingassemblyOB(CreateNew, NewRefrence, ReUse, ReUseStyleId);

        }
        protected void grdStichingassembly_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grdStichingassembly.EditIndex = -1;
            ReUse = 0;
            ReUseStyleId = -1;
            NewRefrence = 0;
            CreateNew = 0;
            BindStichingassemblyOB(CreateNew, NewRefrence, ReUse, ReUseStyleId);
        }
        protected void grdStichingassembly_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            int ReUse = Convert.ToInt32(hdnReUse.Value);


            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //return;
                Literal ltIndex = (Literal)e.Row.FindControl("ltIndex");
                ltIndex.Text = (Convert.ToInt32(RowNum) + 1).ToString();
                RowNum = (Convert.ToInt32(RowNum) + 1);

                Label lblSAM = (Label)e.Row.FindControl("lblSAM");
                TextBox lblMachineCount = (TextBox)e.Row.FindControl("lblMachineCount");
                TextBox lblFinalCount = (TextBox)e.Row.FindControl("lblFinalCount");
                TextBox lblComments = (TextBox)e.Row.FindControl("lblComments");
                // Edit By Prabhaker )8-feb-17

                TextBox txtFactor = (TextBox)e.Row.FindControl("txtFactor");
                if (txtFactor != null)
                {
                    if (txtFactor.Text == "")
                        txtFactor.Text = "0";

                    TotalFact = TotalFact + Convert.ToDouble(txtFactor.Text);

                }
                // End Edit By Prabhaker )8-feb-17
                if (lblSAM != null)
                {
                    if (lblSAM.Text == "")
                        lblSAM.Text = "0";

                    TotalSam = TotalSam + Convert.ToDouble(lblSAM.Text);

                }

                if (lblMachineCount != null)
                {
                    if (lblMachineCount.Text == "")
                        lblMachineCount.Text = "0";

                    TotalMachine = TotalMachine + Convert.ToDouble(lblMachineCount.Text);

                }

                if (lblFinalCount != null)
                {
                    if (lblFinalCount.Text == "")
                        lblFinalCount.Text = "0";

                    FinalMachine = FinalMachine + Convert.ToDouble(lblFinalCount.Text);

                }

                Label lblOperation = (Label)e.Row.FindControl("lblOperation");
                if (lblOperation != null)
                {
                    if (lblOperation.Text == "0")
                    {
                        lblOperation.Text = "";
                    }
                }
                //LinkButton lnkEdit = (LinkButton)e.Row.FindControl("lnkEdit");
                //if (ReUse == 1)
                //{
                //    lnkEdit.Visible = false;
                //}
                LinkButton lnkDelete = (LinkButton)e.Row.FindControl("lnkDelete");
                if (ReUse == 1)
                {
                    lnkDelete.Attributes.Add("style", "display:none;");
                    lblMachineCount.Enabled = false;
                    lblFinalCount.Enabled = false;
                    lblComments.Enabled = false;
                }
                if ((chkIsFactoryIE.Checked)  && (chkIsIEManager.Checked))
                {
                    lnkDelete.Attributes.Add("style", "display:none;");
                    lblMachineCount.Enabled = false;
                    lblFinalCount.Enabled = false;
                    lblComments.Enabled = false;
                }

            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label txtSAMFooter = (Label)e.Row.FindControl("txtSAMFooter");
                //TotalSam
                if (TotalSam != 0)
                    txtSAMFooter.Text = TotalSam.ToString();
                //edit by prabhaker 08-feb-17
                Label lblFactorFooter = (Label)e.Row.FindControl("lblFactorFooter");
                if (TotalFact != 0)
                {
                   // lblFactorFooter.Text = TotalFact.ToString();
                    int TottalRowsCount = grdStichingassembly.Rows.Count;
                    lblFactorFooter.Text = Math.Round((Convert.ToDecimal(TotalFact) / TottalRowsCount), 2).ToString();
                }
                //end edit by prabhaker 08-feb-17
                Label txtMachineCountFooter = (Label)e.Row.FindControl("txtMachineCountFooter");
                                
                //TotalSam
                if (TotalMachine != 0)
                    txtMachineCountFooter.Text = TotalMachine.ToString();

                Label txtFinalCountFooter = (Label)e.Row.FindControl("txtFinalCountFooter");
                //TotalSam
                if (FinalMachine != 0)
                    txtFinalCountFooter.Text = FinalMachine.ToString();

                TotalFact = 0;
                TotalSam = 0;
                TotalMachine = 0;
                FinalMachine = 0;
            }

        }
        protected void grdStichingassembly_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grdStichingassembly.EditIndex = e.NewEditIndex;

            ReUse = 0;
            ReUseStyleId = -1;
            NewRefrence = 0;
            CreateNew = 0;
            BindStichingassemblyOB(CreateNew, NewRefrence, ReUse, ReUseStyleId);

        }
        protected void grdStichingassembly_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow Rows = grdStichingassembly.Rows[e.RowIndex];

            HiddenField hdnFinalCuttingOBID = Rows.FindControl("hdnFinalCuttingOBID") as HiddenField;
            HiddenField hdnOperationIdEdit = Rows.FindControl("hdnOperationIdEdit") as HiddenField;
            HiddenField hdnWorkerTypeIDEdit = Rows.FindControl("hdnWorkerTypeIDEdit") as HiddenField;
            HiddenField hdnAttachmentIDEdit = Rows.FindControl("hdnAttachmentIDEdit") as HiddenField;
            HiddenField hdnStyleSequence = Rows.FindControl("hdnStyleSequence") as HiddenField;

            TextBox txtOperation = Rows.FindControl("txtOperationEdit") as TextBox;
            Label txtOperationType = Rows.FindControl("txtOperationTypeEdit") as Label;
            Label txtMachine = Rows.FindControl("txtMachineEdit") as Label;

            Label txtAttachment = Rows.FindControl("txtAttachmentEdit") as Label;
            Label txtSAM = Rows.FindControl("txtSAMEdit") as Label;
            TextBox txtMachineCount = Rows.FindControl("txtMachineCountEdit") as TextBox;
            TextBox txtFinalCount = Rows.FindControl("txtFinalCountEdit") as TextBox;
            HyperLink lnkShow = Rows.FindControl("lnkShowEdit") as HyperLink;
            TextBox txtComments = Rows.FindControl("txtCommentsEdit") as TextBox;
            //edit by prabhaker 08-feb-17
            TextBox txtfactor = Rows.FindControl("txtEditFactor") as TextBox;
            //end edit by prabhaker 08-feb-17
            int OperationId = Convert.ToInt32(hdnOperationIdEdit.Value);
            int WorkerType = Convert.ToInt32(hdnWorkerTypeIDEdit.Value);

            obj_OBForm.Flag = "Stiching assembly";
            obj_OBForm.FinalOBID = Convert.ToInt32(hdnFinalCuttingOBID.Value);

            if (txtOperation.Text == "")
            {
                obj_OBForm.NoOfOperation = 0;
            }
            else
            {
                obj_OBForm.NoOfOperation = Convert.ToInt32(txtOperation.Text.Trim());
            }
            if (txtSAM.Text.Trim() != "")
                obj_OBForm.Sam = Convert.ToDouble(txtSAM.Text.Trim());
            if (txtMachineCount.Text.Trim() != "")
                obj_OBForm.MachineCount = Convert.ToDouble(txtMachineCount.Text.Trim());
            if (txtFinalCount.Text.Trim() != "")
                obj_OBForm.FinalCount = Convert.ToInt32(txtFinalCount.Text.Trim());
            obj_OBForm.Comments = txtComments.Text.Trim();

            int IsUpdate = 0;
            string IsReuseCode = string.Empty;
            int StyleSequence = 0;

            int IsExist = obj_OrderController.GetOperationType(styleid, OperationId, WorkerType, obj_OBForm.NoOfOperation, obj_OBForm.Flag, obj_OBForm.FinalOBID);

            if (IsExist == 1)
            {
                ShowAlert("Operation Already Exist");
                //grdStichingassembly.EditIndex = -1;
                return;
            }
            else
            {
                if (hdnReUse.Value == "1")
                {
                    ReUseStyleId = -1;
                    StyleSequence = Convert.ToInt32(hdnStyleSequence.Value);
                    IsReuseCode = "";
                    IsUpdate = obj_OrderController.UpdateFinalOB(obj_OBForm, styleid, ReUseStyleId, IsReuseCode, StyleSequence);
                }
                else
                {
                    IsReuseCode = "";
                    IsUpdate = obj_OrderController.UpdateFinalOB(obj_OBForm, styleid, ReUseStyleId, IsReuseCode, StyleSequence);
                }

                if (IsUpdate > 0)
                {
                    grdStichingassembly.EditIndex = -1;
                    ReUse = 0;
                    ReUseStyleId = -1;
                    NewRefrence = 0;
                    CreateNew = 0;
                    BindStichingassemblyOB(CreateNew, NewRefrence, ReUse, ReUseStyleId);
                    BindStichingManPower(CreateNew, NewRefrence, ReUse, ReUseStyleId);
                    //ShowAlert("Updated Sucessfully !");
                    return;
                }
                else
                {
                    ShowAlert("Not Update !");
                    return;
                }
            }
        }

        // For Rest Stich Section
        //For Piping Section
        protected void grdPiping_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdPiping.PageIndex = e.NewPageIndex;
            grdPiping.EditIndex = -1;
            BindStichingPipingOB(0, 0, 0, -1);
        }
        protected void grdPiping_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grdPiping.EditIndex = -1;
            ReUse = 0;
            ReUseStyleId = -1;
            NewRefrence = 0;
            CreateNew = 0;
            BindStichingPipingOB(CreateNew, NewRefrence, ReUse, ReUseStyleId);
        }
        protected void grdPiping_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            int ReUse = Convert.ToInt32(hdnReUse.Value);


            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //return;
                Literal ltIndex = (Literal)e.Row.FindControl("ltIndex");
                ltIndex.Text = (Convert.ToInt32(RowNum) + 1).ToString();
                RowNum = (Convert.ToInt32(RowNum) + 1);

                Label lblSAM = (Label)e.Row.FindControl("lblSAM");
                TextBox lblMachineCount = (TextBox)e.Row.FindControl("lblMachineCount");
                TextBox lblFinalCount = (TextBox)e.Row.FindControl("lblFinalCount");
                TextBox lblComments = (TextBox)e.Row.FindControl("lblComments");
                // Edit By Prabhaker )8-feb-17
                TextBox txtFactor = (TextBox)e.Row.FindControl("txtFactor");
                if (txtFactor != null)
                {
                    if (txtFactor.Text == "")
                        txtFactor.Text = "0";

                    TotalFact = TotalFact + Convert.ToDouble(txtFactor.Text);

                }
                // End Edit By Prabhaker )8-feb-17
                if (lblSAM != null)
                {
                    if (lblSAM.Text == "")
                        lblSAM.Text = "0";

                    TotalSam = TotalSam + Convert.ToDouble(lblSAM.Text);

                }

                if (lblMachineCount != null)
                {
                    if (lblMachineCount.Text == "")
                        lblMachineCount.Text = "0";

                    TotalMachine = TotalMachine + Convert.ToDouble(lblMachineCount.Text);

                }

                if (lblFinalCount != null)
                {
                    if (lblFinalCount.Text == "")
                        lblFinalCount.Text = "0";

                    FinalMachine = FinalMachine + Convert.ToDouble(lblFinalCount.Text);

                }

                Label lblOperation = (Label)e.Row.FindControl("lblOperation");
                if (lblOperation != null)
                {
                    if (lblOperation.Text == "0")
                    {
                        lblOperation.Text = "";
                    }
                }
                //LinkButton lnkEdit = (LinkButton)e.Row.FindControl("lnkEdit");
                //if (ReUse == 1)
                //{
                //    lnkEdit.Visible = false;
                //}
                LinkButton lnkDelete = (LinkButton)e.Row.FindControl("lnkDelete");

                if (ReUse == 1)
                {
                    lnkDelete.Attributes.Add("style", "display:none;");
                    lblMachineCount.Enabled = false;
                    lblFinalCount.Enabled = false;
                    lblComments.Enabled = false;
                }
                if ((chkIsFactoryIE.Checked)  && (chkIsIEManager.Checked))
                {
                    lnkDelete.Attributes.Add("style", "display:none;");
                    lblMachineCount.Enabled = false;
                    lblFinalCount.Enabled = false;
                    lblComments.Enabled = false;
                }

            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label txtSAMFooter = (Label)e.Row.FindControl("txtSAMFooter");
                //TotalSam
                if (TotalSam != 0)
                    txtSAMFooter.Text = TotalSam.ToString();
                //edit by prabhaker 08-feb-17
                Label lblFactorFooter = (Label)e.Row.FindControl("lblFactorFooter");
                if (TotalFact != 0)
                {
                    int TottalRowsCount = grdPiping.Rows.Count;
                    lblFactorFooter.Text = Math.Round((Convert.ToDecimal(TotalFact) / TottalRowsCount), 2).ToString();
                    //lblFactorFooter.Text = TotalFact.ToString();
                }
                //end edit by prabhaker 08-feb-17

                Label txtMachineCountFooter = (Label)e.Row.FindControl("txtMachineCountFooter");             
                //TotalSam
                if (TotalMachine != 0)
                    txtMachineCountFooter.Text = TotalMachine.ToString();

                Label txtFinalCountFooter = (Label)e.Row.FindControl("txtFinalCountFooter");
                //TotalSam
                if (FinalMachine != 0)
                    txtFinalCountFooter.Text = FinalMachine.ToString();

                TotalFact = 0;
                TotalSam = 0;
                TotalMachine = 0;
                FinalMachine = 0;
                //UpdatePanel14.Update();
            }

        }
        protected void grdPiping_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grdPiping.EditIndex = e.NewEditIndex;

            ReUse = 0;
            ReUseStyleId = -1;
            NewRefrence = 0;
            CreateNew = 0;
            BindStichingPipingOB(CreateNew, NewRefrence, ReUse, ReUseStyleId);

        }
        protected void grdPiping_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow Rows = grdPiping.Rows[e.RowIndex];

            HiddenField hdnFinalCuttingOBID = Rows.FindControl("hdnFinalCuttingOBID") as HiddenField;
            HiddenField hdnOperationIdEdit = Rows.FindControl("hdnOperationIdEdit") as HiddenField;
            HiddenField hdnWorkerTypeIDEdit = Rows.FindControl("hdnWorkerTypeIDEdit") as HiddenField;
            HiddenField hdnAttachmentIDEdit = Rows.FindControl("hdnAttachmentIDEdit") as HiddenField;
            HiddenField hdnStyleSequence = Rows.FindControl("hdnStyleSequence") as HiddenField;

            TextBox txtOperation = Rows.FindControl("txtOperationEdit") as TextBox;
            Label txtOperationType = Rows.FindControl("txtOperationTypeEdit") as Label;
            Label txtMachine = Rows.FindControl("txtMachineEdit") as Label;

            Label txtAttachment = Rows.FindControl("txtAttachmentEdit") as Label;
            Label txtSAM = Rows.FindControl("txtSAMEdit") as Label;
            TextBox txtMachineCount = Rows.FindControl("txtMachineCountEdit") as TextBox;
            TextBox txtFinalCount = Rows.FindControl("txtFinalCountEdit") as TextBox;
            HyperLink lnkShow = Rows.FindControl("lnkShowEdit") as HyperLink;
            TextBox txtComments = Rows.FindControl("txtCommentsEdit") as TextBox;
            //edit by prabhaker 08-feb-17
            TextBox txtfactor = Rows.FindControl("txtEditFactor") as TextBox;
            //end edit by prabhaker 08-feb-17
            int OperationId = Convert.ToInt32(hdnOperationIdEdit.Value);
            int WorkerType = Convert.ToInt32(hdnWorkerTypeIDEdit.Value);

            obj_OBForm.Flag = "Piping";
            obj_OBForm.FinalOBID = Convert.ToInt32(hdnFinalCuttingOBID.Value);


            if (txtOperation.Text == "")
            {
                obj_OBForm.NoOfOperation = 0;
            }
            else
            {
                obj_OBForm.NoOfOperation = Convert.ToInt32(txtOperation.Text.Trim());
            }
            if (txtSAM.Text.Trim() != "")
                obj_OBForm.Sam = Convert.ToDouble(txtSAM.Text.Trim());
            if (txtMachineCount.Text.Trim() != "")
                obj_OBForm.MachineCount = Convert.ToDouble(txtMachineCount.Text.Trim());
            if (txtFinalCount.Text.Trim() != "")
                obj_OBForm.FinalCount = Convert.ToInt32(txtFinalCount.Text.Trim());
            obj_OBForm.Comments = txtComments.Text.Trim();

            int IsUpdate = 0;
            string IsReuseCode = string.Empty;
            int StyleSequence = 0;

            int IsExist = obj_OrderController.GetOperationType(styleid, OperationId, WorkerType, obj_OBForm.NoOfOperation, obj_OBForm.Flag, obj_OBForm.FinalOBID);

            if (IsExist == 1)
            {
                ShowAlert("Operation Already Exist");
                //grdStichingassembly.EditIndex = -1;
                return;
            }
            else
            {
                if (hdnReUse.Value == "1")
                {
                    ReUseStyleId = -1;
                    StyleSequence = Convert.ToInt32(hdnStyleSequence.Value);
                    IsReuseCode = "";
                    IsUpdate = obj_OrderController.UpdateFinalOB(obj_OBForm, styleid, ReUseStyleId, IsReuseCode, StyleSequence);
                }
                else
                {
                    IsReuseCode = "";
                    IsUpdate = obj_OrderController.UpdateFinalOB(obj_OBForm, styleid, ReUseStyleId, IsReuseCode, StyleSequence);
                }

                if (IsUpdate > 0)
                {
                    grdPiping.EditIndex = -1;
                    ReUse = 0;
                    ReUseStyleId = -1;
                    NewRefrence = 0;
                    CreateNew = 0;
                    BindStichingPipingOB(CreateNew, NewRefrence, ReUse, ReUseStyleId);
                    BindStichingManPower(CreateNew, NewRefrence, ReUse, ReUseStyleId);
                    //ShowAlert("Updated Sucessfully !");
                    return;
                }
                else
                {
                    ShowAlert("Not Update !");
                    return;
                }
            }
        }
        protected void grdPiping_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = grdPiping.Rows[e.RowIndex];
            HiddenField hdnFinalCuttingOBID = (HiddenField)row.FindControl("hdnFinalOBIdItem");
            string Flag = "Piping";
            if (hdnFinalCuttingOBID != null)
            {
                int IsDelete = obj_OrderController.DeleteOBById(Convert.ToInt32(hdnFinalCuttingOBID.Value), Flag);
                grdPiping.EditIndex = -1;
                ReUse = 0;
                ReUseStyleId = -1;
                NewRefrence = 0;
                CreateNew = 0;
                //BindStichingPipingOB(CreateNew, NewRefrence, ReUse, ReUseStyleId);
                BindStichingManPower(CreateNew, NewRefrence, ReUse, ReUseStyleId);
                BindStichingOBGrid(CreateNew, NewRefrence, ReUse, ReUseStyleId);
            }
        }
        //END Piping

        //For Upper Section
        protected void grdUppersection_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdUppersection.PageIndex = e.NewPageIndex;
            grdUppersection.EditIndex = -1;
            ReUse = 0;
            ReUseStyleId = -1;
            NewRefrence = 0;
            CreateNew = 0;
            BindStichingUpperOB(CreateNew, NewRefrence, ReUse, ReUseStyleId);

        }
        protected void grdUppersection_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grdUppersection.EditIndex = -1;
            ReUse = 0;
            ReUseStyleId = -1;
            NewRefrence = 0;
            CreateNew = 0;
            BindStichingUpperOB(CreateNew, NewRefrence, ReUse, ReUseStyleId);
        }
        protected void grdUppersection_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            int ReUse = Convert.ToInt32(hdnReUse.Value);


            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //return;
                Literal ltIndex = (Literal)e.Row.FindControl("ltIndex");
                ltIndex.Text = (Convert.ToInt32(RowNum) + 1).ToString();
                RowNum = (Convert.ToInt32(RowNum) + 1);

                Label lblSAM = (Label)e.Row.FindControl("lblSAM");
                TextBox lblMachineCount = (TextBox)e.Row.FindControl("lblMachineCount");
                TextBox lblFinalCount = (TextBox)e.Row.FindControl("lblFinalCount");
                TextBox lblComments = (TextBox)e.Row.FindControl("lblComments");
                // Edit By Prabhaker )8-feb-17

                TextBox txtFactor = (TextBox)e.Row.FindControl("txtFactor");
                if (txtFactor != null)
                {
                    if (txtFactor.Text == "")
                        txtFactor.Text = "0";

                    TotalFact = TotalFact + Convert.ToDouble(txtFactor.Text);

                }
                // End Edit By Prabhaker )8-feb-17
                if (lblSAM != null)
                {
                    if (lblSAM.Text == "")
                        lblSAM.Text = "0";

                    TotalSam = TotalSam + Convert.ToDouble(lblSAM.Text);

                }

                if (lblMachineCount != null)
                {
                    if (lblMachineCount.Text == "")
                        lblMachineCount.Text = "0";

                    TotalMachine = TotalMachine + Convert.ToDouble(lblMachineCount.Text);

                }

                if (lblFinalCount != null)
                {
                    if (lblFinalCount.Text == "")
                        lblFinalCount.Text = "0";

                    FinalMachine = FinalMachine + Convert.ToDouble(lblFinalCount.Text);

                }

                Label lblOperation = (Label)e.Row.FindControl("lblOperation");
                if (lblOperation != null)
                {
                    if (lblOperation.Text == "0")
                    {
                        lblOperation.Text = "";
                    }
                }
                //LinkButton lnkEdit = (LinkButton)e.Row.FindControl("lnkEdit");
                //if (ReUse == 1)
                //{
                //    lnkEdit.Visible = false;
                //}
                LinkButton lnkDelete = (LinkButton)e.Row.FindControl("lnkDelete");
                if (ReUse == 1)
                {
                    lnkDelete.Attributes.Add("style", "display:none;");
                    lblMachineCount.Enabled = false;
                    lblFinalCount.Enabled = false;
                    lblComments.Enabled = false;
                }
                if ((chkIsFactoryIE.Checked)  && (chkIsIEManager.Checked))
                {
                    lnkDelete.Attributes.Add("style", "display:none;");
                    lblMachineCount.Enabled = false;
                    lblFinalCount.Enabled = false;
                    lblComments.Enabled = false;
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label txtSAMFooter = (Label)e.Row.FindControl("txtSAMFooter");
                //TotalSam
                if (TotalSam != 0)
                    txtSAMFooter.Text = TotalSam.ToString();
                //edit by prabhaker 08-feb-17
                Label lblFactorFooter = (Label)e.Row.FindControl("lblFactorFooter");
                if (TotalFact != 0)
                {
                    int TottalRowsCount = grdUppersection.Rows.Count;
                    lblFactorFooter.Text = Math.Round((Convert.ToDecimal(TotalFact) / TottalRowsCount), 2).ToString();
                    //lblFactorFooter.Text = TotalFact.ToString(); 
                }
                //end edit by prabhaker 08-feb-17
                Label txtMachineCountFooter = (Label)e.Row.FindControl("txtMachineCountFooter");

                
                //TotalSam
                if (TotalMachine != 0)
                    txtMachineCountFooter.Text = TotalMachine.ToString();

                Label txtFinalCountFooter = (Label)e.Row.FindControl("txtFinalCountFooter");
                //TotalSam
                if (FinalMachine != 0)
                    txtFinalCountFooter.Text = FinalMachine.ToString();

                TotalFact = 0;
                TotalSam = 0;
                TotalMachine = 0;
                FinalMachine = 0;
            }

        }
        protected void grdUppersection_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grdUppersection.EditIndex = e.NewEditIndex;

            ReUse = 0;
            ReUseStyleId = -1;
            NewRefrence = 0;
            CreateNew = 0;
            BindStichingUpperOB(CreateNew, NewRefrence, ReUse, ReUseStyleId);
        }
        protected void grdUppersection_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow Rows = grdUppersection.Rows[e.RowIndex];

            HiddenField hdnFinalCuttingOBID = Rows.FindControl("hdnFinalCuttingOBID") as HiddenField;
            HiddenField hdnOperationIdEdit = Rows.FindControl("hdnOperationIdEdit") as HiddenField;
            HiddenField hdnWorkerTypeIDEdit = Rows.FindControl("hdnWorkerTypeIDEdit") as HiddenField;
            HiddenField hdnAttachmentIDEdit = Rows.FindControl("hdnAttachmentIDEdit") as HiddenField;
            HiddenField hdnStyleSequence = Rows.FindControl("hdnStyleSequence") as HiddenField;

            TextBox txtOperation = Rows.FindControl("txtOperationEdit") as TextBox;
            Label txtOperationType = Rows.FindControl("txtOperationTypeEdit") as Label;
            Label txtMachine = Rows.FindControl("txtMachineEdit") as Label;

            Label txtAttachment = Rows.FindControl("txtAttachmentEdit") as Label;
            Label txtSAM = Rows.FindControl("txtSAMEdit") as Label;
            TextBox txtMachineCount = Rows.FindControl("txtMachineCountEdit") as TextBox;
            TextBox txtFinalCount = Rows.FindControl("txtFinalCountEdit") as TextBox;
            HyperLink lnkShow = Rows.FindControl("lnkShowEdit") as HyperLink;
            TextBox txtComments = Rows.FindControl("txtCommentsEdit") as TextBox;
            //edit by prabhaker 08-feb-17
            TextBox txtfactor = Rows.FindControl("txtEditFactor") as TextBox;
            //end edit by prabhaker 08-feb-17
            int OperationId = Convert.ToInt32(hdnOperationIdEdit.Value);
            int WorkerType = Convert.ToInt32(hdnWorkerTypeIDEdit.Value);

            obj_OBForm.Flag = "Upper";
            obj_OBForm.FinalOBID = Convert.ToInt32(hdnFinalCuttingOBID.Value);


            if (txtOperation.Text == "")
            {
                obj_OBForm.NoOfOperation = 0;
            }
            else
            {
                obj_OBForm.NoOfOperation = Convert.ToInt32(txtOperation.Text.Trim());
            }
            if (txtSAM.Text.Trim() != "")
                obj_OBForm.Sam = Convert.ToDouble(txtSAM.Text.Trim());
            if (txtMachineCount.Text.Trim() != "")
                obj_OBForm.MachineCount = Convert.ToDouble(txtMachineCount.Text.Trim());
            if (txtFinalCount.Text.Trim() != "")
                obj_OBForm.FinalCount = Convert.ToInt32(txtFinalCount.Text.Trim());
            obj_OBForm.Comments = txtComments.Text.Trim();

            int IsUpdate = 0;
            string IsReuseCode = string.Empty;
            int StyleSequence = 0;

            int IsExist = obj_OrderController.GetOperationType(styleid, OperationId, WorkerType, obj_OBForm.NoOfOperation, obj_OBForm.Flag, obj_OBForm.FinalOBID);

            if (IsExist == 1)
            {
                ShowAlert("Operation Already Exist");
                //grdStichingassembly.EditIndex = -1;
                return;
            }
            else
            {
                if (hdnReUse.Value == "1")
                {
                    ReUseStyleId = -1;
                    StyleSequence = Convert.ToInt32(hdnStyleSequence.Value);
                    IsReuseCode = "";
                    IsUpdate = obj_OrderController.UpdateFinalOB(obj_OBForm, styleid, ReUseStyleId, IsReuseCode, StyleSequence);
                }
                else
                {
                    IsReuseCode = "";
                    IsUpdate = obj_OrderController.UpdateFinalOB(obj_OBForm, styleid, ReUseStyleId, IsReuseCode, StyleSequence);
                }

                if (IsUpdate > 0)
                {
                    grdUppersection.EditIndex = -1;
                    ReUse = 0;
                    ReUseStyleId = -1;
                    NewRefrence = 0;
                    CreateNew = 0;
                    BindStichingUpperOB(CreateNew, NewRefrence, ReUse, ReUseStyleId);
                    BindStichingManPower(CreateNew, NewRefrence, ReUse, ReUseStyleId);
                    //ShowAlert("Updated Sucessfully !");
                    return;
                }
                else
                {
                    ShowAlert("Not Update !");
                    return;
                }
            }
        }
        protected void grdUppersection_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = grdUppersection.Rows[e.RowIndex];
            HiddenField hdnFinalCuttingOBID = (HiddenField)row.FindControl("hdnFinalOBIdItem");
            string Flag = "Upper";
            if (hdnFinalCuttingOBID != null)
            {
                int IsDelete = obj_OrderController.DeleteOBById(Convert.ToInt32(hdnFinalCuttingOBID.Value), Flag);
                grdUppersection.EditIndex = -1;
                ReUse = 0;
                ReUseStyleId = -1;
                NewRefrence = 0;
                CreateNew = 0;
                //BindStichingUpperOB(CreateNew, NewRefrence, ReUse, ReUseStyleId);
                BindStichingOBGrid(CreateNew, NewRefrence, ReUse, ReUseStyleId);
                BindStichingManPower(CreateNew, NewRefrence, ReUse, ReUseStyleId);

            }
        }
        //END Upper 

        //For Upper shell Section
        protected void grdUppershell_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdUppershell.PageIndex = e.NewPageIndex;
            grdUppershell.EditIndex = -1;
            ReUse = 0;
            ReUseStyleId = -1;
            NewRefrence = 0;
            CreateNew = 0;
            BindStichingUppershellOB(CreateNew, NewRefrence, ReUse, ReUseStyleId);

        }
        protected void grdUppershell_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grdUppershell.EditIndex = -1;
            ReUse = 0;
            ReUseStyleId = -1;
            NewRefrence = 0;
            CreateNew = 0;
            BindStichingUppershellOB(CreateNew, NewRefrence, ReUse, ReUseStyleId);
        }
        protected void grdUppershell_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            int ReUse = Convert.ToInt32(hdnReUse.Value);


            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //return;
                Literal ltIndex = (Literal)e.Row.FindControl("ltIndex");
                ltIndex.Text = (Convert.ToInt32(RowNum) + 1).ToString();
                RowNum = (Convert.ToInt32(RowNum) + 1);

                Label lblSAM = (Label)e.Row.FindControl("lblSAM");
                TextBox lblMachineCount = (TextBox)e.Row.FindControl("lblMachineCount");
                TextBox lblFinalCount = (TextBox)e.Row.FindControl("lblFinalCount");
                TextBox lblComments = (TextBox)e.Row.FindControl("lblComments");
                // Edit By Prabhaker )8-feb-17

                TextBox txtFactor = (TextBox)e.Row.FindControl("txtFactor");
                if (txtFactor != null)
                {
                    if (txtFactor.Text == "")
                        txtFactor.Text = "0";

                    TotalFact = TotalFact + Convert.ToDouble(txtFactor.Text);

                }
                // End Edit By Prabhaker )8-feb-17
                if (lblSAM != null)
                {
                    if (lblSAM.Text == "")
                        lblSAM.Text = "0";

                    TotalSam = TotalSam + Convert.ToDouble(lblSAM.Text);

                }

                if (lblMachineCount != null)
                {
                    if (lblMachineCount.Text == "")
                        lblMachineCount.Text = "0";

                    TotalMachine = TotalMachine + Convert.ToDouble(lblMachineCount.Text);

                }

                if (lblFinalCount != null)
                {
                    if (lblFinalCount.Text == "")
                        lblFinalCount.Text = "0";

                    FinalMachine = FinalMachine + Convert.ToDouble(lblFinalCount.Text);

                }

                Label lblOperation = (Label)e.Row.FindControl("lblOperation");
                if (lblOperation != null)
                {
                    if (lblOperation.Text == "0")
                    {
                        lblOperation.Text = "";
                    }
                }
                //LinkButton lnkEdit = (LinkButton)e.Row.FindControl("lnkEdit");
                //if (ReUse == 1)
                //{
                //    lnkEdit.Visible = false;
                //}
                LinkButton lnkDelete = (LinkButton)e.Row.FindControl("lnkDelete");
                if (ReUse == 1)
                {
                    lnkDelete.Attributes.Add("style", "display:none;");
                    lblMachineCount.Enabled = false;
                    lblFinalCount.Enabled = false;
                    lblComments.Enabled = false;
                }
                if ((chkIsFactoryIE.Checked)  && (chkIsIEManager.Checked))
                {
                    lnkDelete.Attributes.Add("style", "display:none;");
                    lblMachineCount.Enabled = false;
                    lblFinalCount.Enabled = false;
                    lblComments.Enabled = false;
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label txtSAMFooter = (Label)e.Row.FindControl("txtSAMFooter");
                //TotalSam
                if (TotalSam != 0)
                    txtSAMFooter.Text = TotalSam.ToString();
                //edit by prabhaker 08-feb-17
                Label lblFactorFooter = (Label)e.Row.FindControl("lblFactorFooter");
                if (TotalFact != 0)
                {
                    int TottalRowsCount = grdUppershell.Rows.Count;
                    lblFactorFooter.Text = Math.Round((Convert.ToDecimal(TotalFact) / TottalRowsCount), 2).ToString();
                    //lblFactorFooter.Text = TotalFact.ToString();
                }
                //end edit by prabhaker 08-feb-17
                Label txtMachineCountFooter = (Label)e.Row.FindControl("txtMachineCountFooter");

                
                //TotalSam
                if (TotalMachine != 0)
                    txtMachineCountFooter.Text = TotalMachine.ToString();

                Label txtFinalCountFooter = (Label)e.Row.FindControl("txtFinalCountFooter");
                //TotalSam
                if (FinalMachine != 0)
                    txtFinalCountFooter.Text = FinalMachine.ToString();

                TotalFact = 0;
                TotalSam = 0;
                TotalMachine = 0;
                FinalMachine = 0;
            }

        }
        protected void grdUppershell_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grdUppershell.EditIndex = e.NewEditIndex;

            ReUse = 0;
            ReUseStyleId = -1;
            NewRefrence = 0;
            CreateNew = 0;
            BindStichingUppershellOB(CreateNew, NewRefrence, ReUse, ReUseStyleId);
        }
        protected void grdUppershell_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow Rows = grdUppershell.Rows[e.RowIndex];

            HiddenField hdnFinalCuttingOBID = Rows.FindControl("hdnFinalCuttingOBID") as HiddenField;
            HiddenField hdnOperationIdEdit = Rows.FindControl("hdnOperationIdEdit") as HiddenField;
            HiddenField hdnWorkerTypeIDEdit = Rows.FindControl("hdnWorkerTypeIDEdit") as HiddenField;
            HiddenField hdnAttachmentIDEdit = Rows.FindControl("hdnAttachmentIDEdit") as HiddenField;
            HiddenField hdnStyleSequence = Rows.FindControl("hdnStyleSequence") as HiddenField;

            TextBox txtOperation = Rows.FindControl("txtOperationEdit") as TextBox;
            Label txtOperationType = Rows.FindControl("txtOperationTypeEdit") as Label;
            Label txtMachine = Rows.FindControl("txtMachineEdit") as Label;

            Label txtAttachment = Rows.FindControl("txtAttachmentEdit") as Label;
            Label txtSAM = Rows.FindControl("txtSAMEdit") as Label;
            TextBox txtMachineCount = Rows.FindControl("txtMachineCountEdit") as TextBox;
            TextBox txtFinalCount = Rows.FindControl("txtFinalCountEdit") as TextBox;
            HyperLink lnkShow = Rows.FindControl("lnkShowEdit") as HyperLink;
            TextBox txtComments = Rows.FindControl("txtCommentsEdit") as TextBox;
            //edit by prabhaker 08-feb-17
            TextBox txtfactor = Rows.FindControl("txtEditFactor") as TextBox;
            //end edit by prabhaker 08-feb-17
            int OperationId = Convert.ToInt32(hdnOperationIdEdit.Value);
            int WorkerType = Convert.ToInt32(hdnWorkerTypeIDEdit.Value);

            obj_OBForm.Flag = "Uppershell";
            obj_OBForm.FinalOBID = Convert.ToInt32(hdnFinalCuttingOBID.Value);


            if (txtOperation.Text == "")
            {
                obj_OBForm.NoOfOperation = 0;
            }
            else
            {
                obj_OBForm.NoOfOperation = Convert.ToInt32(txtOperation.Text.Trim());
            }
            if (txtSAM.Text.Trim() != "")
                obj_OBForm.Sam = Convert.ToDouble(txtSAM.Text.Trim());
            if (txtMachineCount.Text.Trim() != "")
                obj_OBForm.MachineCount = Convert.ToDouble(txtMachineCount.Text.Trim());
            if (txtFinalCount.Text.Trim() != "")
                obj_OBForm.FinalCount = Convert.ToInt32(txtFinalCount.Text.Trim());
            obj_OBForm.Comments = txtComments.Text.Trim();

            int IsUpdate = 0;
            string IsReuseCode = string.Empty;
            int StyleSequence = 0;

            int IsExist = obj_OrderController.GetOperationType(styleid, OperationId, WorkerType, obj_OBForm.NoOfOperation, obj_OBForm.Flag, obj_OBForm.FinalOBID);

            if (IsExist == 1)
            {
                ShowAlert("Operation Already Exist");
                //grdStichingassembly.EditIndex = -1;
                return;
            }
            else
            {
                if (hdnReUse.Value == "1")
                {
                    ReUseStyleId = -1;
                    StyleSequence = Convert.ToInt32(hdnStyleSequence.Value);
                    IsReuseCode = "";
                    IsUpdate = obj_OrderController.UpdateFinalOB(obj_OBForm, styleid, ReUseStyleId, IsReuseCode, StyleSequence);
                }
                else
                {
                    IsReuseCode = "";
                    IsUpdate = obj_OrderController.UpdateFinalOB(obj_OBForm, styleid, ReUseStyleId, IsReuseCode, StyleSequence);
                }

                if (IsUpdate > 0)
                {
                    grdUppershell.EditIndex = -1;
                    ReUse = 0;
                    ReUseStyleId = -1;
                    NewRefrence = 0;
                    CreateNew = 0;
                    BindStichingUppershellOB(CreateNew, NewRefrence, ReUse, ReUseStyleId);
                    BindStichingManPower(CreateNew, NewRefrence, ReUse, ReUseStyleId);
                    //ShowAlert("Updated Sucessfully !");
                    return;
                }
                else
                {
                    ShowAlert("Not Update !");
                    return;
                }
            }
        }
        protected void grdUppershell_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = grdUppershell.Rows[e.RowIndex];
            HiddenField hdnFinalCuttingOBID = (HiddenField)row.FindControl("hdnFinalOBIdItem");
            string Flag = "Uppershell";
            if (hdnFinalCuttingOBID != null)
            {
                int IsDelete = obj_OrderController.DeleteOBById(Convert.ToInt32(hdnFinalCuttingOBID.Value), Flag);
                grdUppershell.EditIndex = -1;
                ReUse = 0;
                ReUseStyleId = -1;
                NewRefrence = 0;
                CreateNew = 0;
                //BindStichingUppershellOB(CreateNew, NewRefrence, ReUse, ReUseStyleId);
                BindStichingOBGrid(CreateNew, NewRefrence, ReUse, ReUseStyleId);
                BindStichingManPower(CreateNew, NewRefrence, ReUse, ReUseStyleId);

            }
        }
        //END Upper 

        //For Lower shell Section
        protected void grdLowershell_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdLowershell.PageIndex = e.NewPageIndex;
            grdUppershell.EditIndex = -1;
            ReUse = 0;
            ReUseStyleId = -1;
            NewRefrence = 0;
            CreateNew = 0;
            BindStichingLowershellOB(CreateNew, NewRefrence, ReUse, ReUseStyleId);
        }
        protected void grdLowershell_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grdLowershell.EditIndex = -1;
            ReUse = 0;
            ReUseStyleId = -1;
            NewRefrence = 0;
            CreateNew = 0;
            BindStichingLowershellOB(CreateNew, NewRefrence, ReUse, ReUseStyleId);
        }
        protected void grdLowershell_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            int ReUse = Convert.ToInt32(hdnReUse.Value);


            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //return;
                Literal ltIndex = (Literal)e.Row.FindControl("ltIndex");
                ltIndex.Text = (Convert.ToInt32(RowNum) + 1).ToString();
                RowNum = (Convert.ToInt32(RowNum) + 1);

                Label lblSAM = (Label)e.Row.FindControl("lblSAM");
                TextBox lblMachineCount = (TextBox)e.Row.FindControl("lblMachineCount");
                TextBox lblFinalCount = (TextBox)e.Row.FindControl("lblFinalCount");
                TextBox lblComments = (TextBox)e.Row.FindControl("lblComments");
                // Edit By Prabhaker )8-feb-17

                TextBox txtFactor = (TextBox)e.Row.FindControl("txtFactor");
                if (txtFactor != null)
                {
                    if (txtFactor.Text == "")
                        txtFactor.Text = "0";

                    TotalFact = TotalFact + Convert.ToDouble(txtFactor.Text);

                }
                // End Edit By Prabhaker )8-feb-17
                if (lblSAM != null)
                {
                    if (lblSAM.Text == "")
                        lblSAM.Text = "0";

                    TotalSam = TotalSam + Convert.ToDouble(lblSAM.Text);

                }

                if (lblMachineCount != null)
                {
                    if (lblMachineCount.Text == "")
                        lblMachineCount.Text = "0";

                    TotalMachine = TotalMachine + Convert.ToDouble(lblMachineCount.Text);

                }

                if (lblFinalCount != null)
                {
                    if (lblFinalCount.Text == "")
                        lblFinalCount.Text = "0";

                    FinalMachine = FinalMachine + Convert.ToDouble(lblFinalCount.Text);

                }

                Label lblOperation = (Label)e.Row.FindControl("lblOperation");
                if (lblOperation != null)
                {
                    if (lblOperation.Text == "0")
                    {
                        lblOperation.Text = "";
                    }
                }
                //LinkButton lnkEdit = (LinkButton)e.Row.FindControl("lnkEdit");
                //if (ReUse == 1)
                //{
                //    lnkEdit.Visible = false;
                //}
                LinkButton lnkDelete = (LinkButton)e.Row.FindControl("lnkDelete");
                if (ReUse == 1)
                {
                    lnkDelete.Attributes.Add("style", "display:none;");
                    lblMachineCount.Enabled = false;
                    lblFinalCount.Enabled = false;
                    lblComments.Enabled = false;
                }
                if ((chkIsFactoryIE.Checked)  && (chkIsIEManager.Checked))
                {
                    lnkDelete.Attributes.Add("style", "display:none;");
                    lblMachineCount.Enabled = false;
                    lblFinalCount.Enabled = false;
                    lblComments.Enabled = false;
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label txtSAMFooter = (Label)e.Row.FindControl("txtSAMFooter");
                //TotalSam
                if (TotalSam != 0)
                    txtSAMFooter.Text = TotalSam.ToString();
                //edit by prabhaker 08-feb-17
                Label lblFactorFooter = (Label)e.Row.FindControl("lblFactorFooter");
                if (TotalFact != 0)
                {
                    int TottalRowsCount = grdLowershell.Rows.Count;
                    lblFactorFooter.Text = Math.Round((Convert.ToDecimal(TotalFact) / TottalRowsCount), 2).ToString();
                    //lblFactorFooter.Text = TotalFact.ToString();
                }
                //end edit by prabhaker 08-feb-17
                Label txtMachineCountFooter = (Label)e.Row.FindControl("txtMachineCountFooter");

                
                //TotalSam
                if (TotalMachine != 0)
                    txtMachineCountFooter.Text = TotalMachine.ToString();

                Label txtFinalCountFooter = (Label)e.Row.FindControl("txtFinalCountFooter");
                //TotalSam
                if (FinalMachine != 0)
                    txtFinalCountFooter.Text = FinalMachine.ToString();

                TotalFact = 0;
                TotalSam = 0;
                TotalMachine = 0;
                FinalMachine = 0;
            }

        }
        protected void grdLowershell_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grdLowershell.EditIndex = e.NewEditIndex;

            ReUse = 0;
            ReUseStyleId = -1;
            NewRefrence = 0;
            CreateNew = 0;
            BindStichingLowershellOB(CreateNew, NewRefrence, ReUse, ReUseStyleId);

        }
        protected void grdLowershell_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow Rows = grdLowershell.Rows[e.RowIndex];

            HiddenField hdnFinalCuttingOBID = Rows.FindControl("hdnFinalCuttingOBID") as HiddenField;
            HiddenField hdnOperationIdEdit = Rows.FindControl("hdnOperationIdEdit") as HiddenField;
            HiddenField hdnWorkerTypeIDEdit = Rows.FindControl("hdnWorkerTypeIDEdit") as HiddenField;
            HiddenField hdnAttachmentIDEdit = Rows.FindControl("hdnAttachmentIDEdit") as HiddenField;
            HiddenField hdnStyleSequence = Rows.FindControl("hdnStyleSequence") as HiddenField;

            TextBox txtOperation = Rows.FindControl("txtOperationEdit") as TextBox;
            Label txtOperationType = Rows.FindControl("txtOperationTypeEdit") as Label;
            Label txtMachine = Rows.FindControl("txtMachineEdit") as Label;

            Label txtAttachment = Rows.FindControl("txtAttachmentEdit") as Label;
            Label txtSAM = Rows.FindControl("txtSAMEdit") as Label;
            TextBox txtMachineCount = Rows.FindControl("txtMachineCountEdit") as TextBox;
            TextBox txtFinalCount = Rows.FindControl("txtFinalCountEdit") as TextBox;
            HyperLink lnkShow = Rows.FindControl("lnkShowEdit") as HyperLink;
            TextBox txtComments = Rows.FindControl("txtCommentsEdit") as TextBox;
            //edit by prabhaker 08-feb-17
            TextBox txtfactor = Rows.FindControl("txtEditFactor") as TextBox;
            //end edit by prabhaker 08-feb-17
            int OperationId = Convert.ToInt32(hdnOperationIdEdit.Value);
            int WorkerType = Convert.ToInt32(hdnWorkerTypeIDEdit.Value);

            obj_OBForm.Flag = "Lowershell";
            obj_OBForm.FinalOBID = Convert.ToInt32(hdnFinalCuttingOBID.Value);


            if (txtOperation.Text == "")
            {
                obj_OBForm.NoOfOperation = 0;
            }
            else
            {
                obj_OBForm.NoOfOperation = Convert.ToInt32(txtOperation.Text.Trim());
            }
            if (txtSAM.Text.Trim() != "")
                obj_OBForm.Sam = Convert.ToDouble(txtSAM.Text.Trim());
            if (txtMachineCount.Text.Trim() != "")
                obj_OBForm.MachineCount = Convert.ToDouble(txtMachineCount.Text.Trim());
            if (txtFinalCount.Text.Trim() != "")
                obj_OBForm.FinalCount = Convert.ToInt32(txtFinalCount.Text.Trim());
            obj_OBForm.Comments = txtComments.Text.Trim();

            int IsUpdate = 0;
            string IsReuseCode = string.Empty;
            int StyleSequence = 0;

            int IsExist = obj_OrderController.GetOperationType(styleid, OperationId, WorkerType, obj_OBForm.NoOfOperation, obj_OBForm.Flag, obj_OBForm.FinalOBID);

            if (IsExist == 1)
            {
                ShowAlert("Operation Already Exist");
                //grdStichingassembly.EditIndex = -1;
                return;
            }
            else
            {
                if (hdnReUse.Value == "1")
                {
                    ReUseStyleId = -1;
                    StyleSequence = Convert.ToInt32(hdnStyleSequence.Value);
                    IsReuseCode = "";
                    IsUpdate = obj_OrderController.UpdateFinalOB(obj_OBForm, styleid, ReUseStyleId, IsReuseCode, StyleSequence);
                }
                else
                {
                    IsReuseCode = "";
                    IsUpdate = obj_OrderController.UpdateFinalOB(obj_OBForm, styleid, ReUseStyleId, IsReuseCode, StyleSequence);
                }

                if (IsUpdate > 0)
                {
                    grdLowershell.EditIndex = -1;
                    ReUse = 0;
                    ReUseStyleId = -1;
                    NewRefrence = 0;
                    CreateNew = 0;
                    BindStichingLowershellOB(CreateNew, NewRefrence, ReUse, ReUseStyleId);
                    BindStichingManPower(CreateNew, NewRefrence, ReUse, ReUseStyleId);
                    //ShowAlert("Updated Sucessfully !");
                    return;
                }
                else
                {
                    ShowAlert("Not Update !");
                    return;
                }
            }
        }
        protected void grdLowershell_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = grdLowershell.Rows[e.RowIndex];
            HiddenField hdnFinalCuttingOBID = (HiddenField)row.FindControl("hdnFinalOBIdItem");
            string Flag = "Lowershell";
            if (hdnFinalCuttingOBID != null)
            {
                int IsDelete = obj_OrderController.DeleteOBById(Convert.ToInt32(hdnFinalCuttingOBID.Value), Flag);
                grdLowershell.EditIndex = -1;
                ReUse = 0;
                ReUseStyleId = -1;
                NewRefrence = 0;
                CreateNew = 0;
                //BindStichingLowershellOB(CreateNew, NewRefrence, ReUse, ReUseStyleId);
                BindStichingOBGrid(CreateNew, NewRefrence, ReUse, ReUseStyleId);
                BindStichingManPower(CreateNew, NewRefrence, ReUse, ReUseStyleId);

            }
        }
        //END Lower 



        //For Shell Section
        protected void grdShellsection_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdShellsection.PageIndex = e.NewPageIndex;
            grdShellsection.EditIndex = -1;
            ReUse = 0;
            ReUseStyleId = -1;
            NewRefrence = 0;
            CreateNew = 0;
            BindStichingShellsectionOB(CreateNew, NewRefrence, ReUse, ReUseStyleId);

        }
        protected void grdShellsection_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grdShellsection.EditIndex = -1;
            ReUse = 0;
            ReUseStyleId = -1;
            NewRefrence = 0;
            CreateNew = 0;
            BindStichingShellsectionOB(CreateNew, NewRefrence, ReUse, ReUseStyleId);
        }
        protected void grdShellsection_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            int ReUse = Convert.ToInt32(hdnReUse.Value);


            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //return;
                Literal ltIndex = (Literal)e.Row.FindControl("ltIndex");
                ltIndex.Text = (Convert.ToInt32(RowNum) + 1).ToString();


                RowNum = (Convert.ToInt32(RowNum) + 1);
                Label lblSAM = (Label)e.Row.FindControl("lblSAM");
                TextBox lblMachineCount = (TextBox)e.Row.FindControl("lblMachineCount");
                TextBox lblFinalCount = (TextBox)e.Row.FindControl("lblFinalCount");
                TextBox lblComments = (TextBox)e.Row.FindControl("lblComments");
                // Edit By Prabhaker )8-feb-17

                TextBox txtFactor = (TextBox)e.Row.FindControl("txtFactor");
                if (txtFactor != null)
                {
                    if (txtFactor.Text == "")
                        txtFactor.Text = "0";

                    TotalFact = TotalFact + Convert.ToDouble(txtFactor.Text);

                }
                // End Edit By Prabhaker )8-feb-17
                if (lblSAM != null)
                {
                    if (lblSAM.Text == "")
                        lblSAM.Text = "0";

                    TotalSam = TotalSam + Convert.ToDouble(lblSAM.Text);

                }

                if (lblMachineCount != null)
                {
                    if (lblMachineCount.Text == "")
                        lblMachineCount.Text = "0";

                    TotalMachine = TotalMachine + Convert.ToDouble(lblMachineCount.Text);

                }

                if (lblFinalCount != null)
                {
                    if (lblFinalCount.Text == "")
                        lblFinalCount.Text = "0";

                    FinalMachine = FinalMachine + Convert.ToDouble(lblFinalCount.Text);

                }

                Label lblOperation = (Label)e.Row.FindControl("lblOperation");
                if (lblOperation != null)
                {
                    if (lblOperation.Text == "0")
                    {
                        lblOperation.Text = "";
                    }
                }
                //LinkButton lnkEdit = (LinkButton)e.Row.FindControl("lnkEdit");
                //if (ReUse == 1)
                //{
                //    lnkEdit.Visible = false;
                //}
                LinkButton lnkDelete = (LinkButton)e.Row.FindControl("lnkDelete");
                if (ReUse == 1)
                {
                    lnkDelete.Attributes.Add("style", "display:none;");
                    lblMachineCount.Enabled = false;
                    lblFinalCount.Enabled = false;
                    lblComments.Enabled = false;
                }
                if ((chkIsFactoryIE.Checked)  && (chkIsIEManager.Checked))
                {
                    lnkDelete.Attributes.Add("style", "display:none;");
                    lblMachineCount.Enabled = false;
                    lblFinalCount.Enabled = false;
                    lblComments.Enabled = false;
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label txtSAMFooter = (Label)e.Row.FindControl("txtSAMFooter");
                //TotalSam
                if (TotalSam != 0)
                    txtSAMFooter.Text = TotalSam.ToString();
                //edit by prabhaker 08-feb-17
                Label lblFactorFooter = (Label)e.Row.FindControl("lblFactorFooter");
                if (TotalFact != 0)
                {
                    int TottalRowsCount = grdShellsection.Rows.Count;
                    lblFactorFooter.Text = Math.Round((Convert.ToDecimal(TotalFact) / TottalRowsCount), 2).ToString();
                    //lblFactorFooter.Text = TotalFact.ToString();
                }
                //end edit by prabhaker 08-feb-17
                Label txtMachineCountFooter = (Label)e.Row.FindControl("txtMachineCountFooter");

                //TotalSam
                if (TotalMachine != 0)
                    txtMachineCountFooter.Text = TotalMachine.ToString();

                Label txtFinalCountFooter = (Label)e.Row.FindControl("txtFinalCountFooter");
                //TotalSam
                if (FinalMachine != 0)
                    txtFinalCountFooter.Text = FinalMachine.ToString();

                TotalFact = 0;
                TotalSam = 0;
                TotalMachine = 0;
                FinalMachine = 0;
            }

        }
        protected void grdShellsection_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grdShellsection.EditIndex = e.NewEditIndex;

            ReUse = 0;
            ReUseStyleId = -1;
            NewRefrence = 0;
            CreateNew = 0;
            BindStichingShellsectionOB(CreateNew, NewRefrence, ReUse, ReUseStyleId);
        }
        protected void grdShellsection_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow Rows = grdShellsection.Rows[e.RowIndex];

            HiddenField hdnFinalCuttingOBID = Rows.FindControl("hdnFinalCuttingOBID") as HiddenField;
            HiddenField hdnOperationIdEdit = Rows.FindControl("hdnOperationIdEdit") as HiddenField;
            HiddenField hdnWorkerTypeIDEdit = Rows.FindControl("hdnWorkerTypeIDEdit") as HiddenField;
            HiddenField hdnAttachmentIDEdit = Rows.FindControl("hdnAttachmentIDEdit") as HiddenField;
            HiddenField hdnStyleSequence = Rows.FindControl("hdnStyleSequence") as HiddenField;

            TextBox txtOperation = Rows.FindControl("txtOperationEdit") as TextBox;
            Label txtOperationType = Rows.FindControl("txtOperationTypeEdit") as Label;
            Label txtMachine = Rows.FindControl("txtMachineEdit") as Label;

            Label txtAttachment = Rows.FindControl("txtAttachmentEdit") as Label;
            Label txtSAM = Rows.FindControl("txtSAMEdit") as Label;
            TextBox txtMachineCount = Rows.FindControl("txtMachineCountEdit") as TextBox;
            TextBox txtFinalCount = Rows.FindControl("txtFinalCountEdit") as TextBox;
            HyperLink lnkShow = Rows.FindControl("lnkShowEdit") as HyperLink;
            TextBox txtComments = Rows.FindControl("txtCommentsEdit") as TextBox;
            //edit by prabhaker 08-feb-17
            TextBox txtfactor = Rows.FindControl("txtEditFactor") as TextBox;
            //end edit by prabhaker 08-feb-17
            int OperationId = Convert.ToInt32(hdnOperationIdEdit.Value);
            int WorkerType = Convert.ToInt32(hdnWorkerTypeIDEdit.Value);

            obj_OBForm.Flag = "Shellsection";
            obj_OBForm.FinalOBID = Convert.ToInt32(hdnFinalCuttingOBID.Value);


            if (txtOperation.Text == "")
            {
                obj_OBForm.NoOfOperation = 0;
            }
            else
            {
                obj_OBForm.NoOfOperation = Convert.ToInt32(txtOperation.Text.Trim());
            }
            if (txtSAM.Text.Trim() != "")
                obj_OBForm.Sam = Convert.ToDouble(txtSAM.Text.Trim());
            if (txtMachineCount.Text.Trim() != "")
                obj_OBForm.MachineCount = Convert.ToDouble(txtMachineCount.Text.Trim());
            if (txtFinalCount.Text.Trim() != "")
                obj_OBForm.FinalCount = Convert.ToInt32(txtFinalCount.Text.Trim());
            obj_OBForm.Comments = txtComments.Text.Trim();

            int IsUpdate = 0;
            string IsReuseCode = string.Empty;
            int StyleSequence = 0;

            int IsExist = obj_OrderController.GetOperationType(styleid, OperationId, WorkerType, obj_OBForm.NoOfOperation, obj_OBForm.Flag, obj_OBForm.FinalOBID);

            if (IsExist == 1)
            {
                ShowAlert("Operation Already Exist");
                //grdStichingassembly.EditIndex = -1;
                return;
            }
            else
            {
                if (hdnReUse.Value == "1")
                {
                    ReUseStyleId = -1;
                    StyleSequence = Convert.ToInt32(hdnStyleSequence.Value);
                    IsReuseCode = "";
                    IsUpdate = obj_OrderController.UpdateFinalOB(obj_OBForm, styleid, ReUseStyleId, IsReuseCode, StyleSequence);
                }
                else
                {
                    IsReuseCode = "";
                    IsUpdate = obj_OrderController.UpdateFinalOB(obj_OBForm, styleid, ReUseStyleId, IsReuseCode, StyleSequence);
                }

                if (IsUpdate > 0)
                {
                    grdShellsection.EditIndex = -1;
                    ReUse = 0;
                    ReUseStyleId = -1;
                    NewRefrence = 0;
                    CreateNew = 0;
                    BindStichingShellsectionOB(CreateNew, NewRefrence, ReUse, ReUseStyleId);
                    BindStichingManPower(CreateNew, NewRefrence, ReUse, ReUseStyleId);
                    //ShowAlert("Updated Sucessfully !");
                    return;
                }
                else
                {
                    ShowAlert("Not Update !");
                    return;
                }
            }
        }
        protected void grdShellsection_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = grdShellsection.Rows[e.RowIndex];
            HiddenField hdnFinalCuttingOBID = (HiddenField)row.FindControl("hdnFinalOBIdItem");
            string Flag = "Shellsection";
            if (hdnFinalCuttingOBID != null)
            {
                int IsDelete = obj_OrderController.DeleteOBById(Convert.ToInt32(hdnFinalCuttingOBID.Value), Flag);
                grdShellsection.EditIndex = -1;
                ReUse = 0;
                ReUseStyleId = -1;
                NewRefrence = 0;
                CreateNew = 0;
                //BindStichingShellsectionOB(CreateNew, NewRefrence, ReUse, ReUseStyleId);
                BindStichingOBGrid(CreateNew, NewRefrence, ReUse, ReUseStyleId);
                BindStichingManPower(CreateNew, NewRefrence, ReUse, ReUseStyleId);

            }
        }
        //END Shell

        //For Waist section
        protected void grdWaistsection_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdWaistsection.PageIndex = e.NewPageIndex;
            grdWaistsection.EditIndex = -1;
            ReUse = 0;
            ReUseStyleId = -1;
            NewRefrence = 0;
            CreateNew = 0;
            BindStichingWaistsectionOB(CreateNew, NewRefrence, ReUse, ReUseStyleId);

        }
        protected void grdWaistsection_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grdWaistsection.EditIndex = -1;
            ReUse = 0;
            ReUseStyleId = -1;
            NewRefrence = 0;
            CreateNew = 0;
            BindStichingWaistsectionOB(CreateNew, NewRefrence, ReUse, ReUseStyleId);
        }
        protected void grdWaistsection_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            int ReUse = Convert.ToInt32(hdnReUse.Value);

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //return;
                Literal ltIndex = (Literal)e.Row.FindControl("ltIndex");
                ltIndex.Text = (Convert.ToInt32(RowNum) + 1).ToString();
                RowNum = (Convert.ToInt32(RowNum) + 1);

                Label lblSAM = (Label)e.Row.FindControl("lblSAM");
                TextBox lblMachineCount = (TextBox)e.Row.FindControl("lblMachineCount");
                TextBox lblFinalCount = (TextBox)e.Row.FindControl("lblFinalCount");
                TextBox lblComments = (TextBox)e.Row.FindControl("lblComments");
                // Edit By Prabhaker )8-feb-17

                TextBox txtFactor = (TextBox)e.Row.FindControl("txtFactor");
                if (txtFactor != null)
                {
                    if (txtFactor.Text == "")
                        txtFactor.Text = "0";

                    TotalFact = TotalFact + Convert.ToDouble(txtFactor.Text);

                }
                // End Edit By Prabhaker )8-feb-17
                if (lblSAM != null)
                {
                    if (lblSAM.Text == "")
                        lblSAM.Text = "0";

                    TotalSam = TotalSam + Convert.ToDouble(lblSAM.Text);

                }

                if (lblMachineCount != null)
                {
                    if (lblMachineCount.Text == "")
                        lblMachineCount.Text = "0";

                    TotalMachine = TotalMachine + Convert.ToDouble(lblMachineCount.Text);

                }

                if (lblFinalCount != null)
                {
                    if (lblFinalCount.Text == "")
                        lblFinalCount.Text = "0";

                    FinalMachine = FinalMachine + Convert.ToDouble(lblFinalCount.Text);

                }

                Label lblOperation = (Label)e.Row.FindControl("lblOperation");
                if (lblOperation != null)
                {
                    if (lblOperation.Text == "0")
                    {
                        lblOperation.Text = "";
                    }
                }
                //LinkButton lnkEdit = (LinkButton)e.Row.FindControl("lnkEdit");
                //if (ReUse == 1)
                //{
                //    lnkEdit.Visible = false;
                //}
                LinkButton lnkDelete = (LinkButton)e.Row.FindControl("lnkDelete");
                if (ReUse == 1)
                {
                    lnkDelete.Attributes.Add("style", "display:none;");
                    lblMachineCount.Enabled = false;
                    lblFinalCount.Enabled = false;
                    lblComments.Enabled = false;
                }
                if ((chkIsFactoryIE.Checked)  && (chkIsIEManager.Checked))
                {
                    lnkDelete.Attributes.Add("style", "display:none;");
                    lblMachineCount.Enabled = false;
                    lblFinalCount.Enabled = false;
                    lblComments.Enabled = false;
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label txtSAMFooter = (Label)e.Row.FindControl("txtSAMFooter");
                //TotalSam
                if (TotalSam != 0)
                    txtSAMFooter.Text = TotalSam.ToString();
                //edit by prabhaker 08-feb-17
                Label lblFactorFooter = (Label)e.Row.FindControl("lblFactorFooter");
                if (TotalFact != 0)
                {
                    int TottalRowsCount = grdWaistsection.Rows.Count;
                    lblFactorFooter.Text = Math.Round((Convert.ToDecimal(TotalFact) / TottalRowsCount), 2).ToString();
                    // lblFactorFooter.Text = TotalFact.ToString();
                }
                //end edit by prabhaker 08-feb-17
                Label txtMachineCountFooter = (Label)e.Row.FindControl("txtMachineCountFooter");

                //TotalSam
                if (TotalMachine != 0)
                    txtMachineCountFooter.Text = TotalMachine.ToString();

                Label txtFinalCountFooter = (Label)e.Row.FindControl("txtFinalCountFooter");
                //TotalSam
                if (FinalMachine != 0)
                    txtFinalCountFooter.Text = FinalMachine.ToString();

                TotalFact = 0;
                TotalSam = 0;
                TotalMachine = 0;
                FinalMachine = 0;
            }

        }
        protected void grdWaistsection_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grdWaistsection.EditIndex = e.NewEditIndex;

            ReUse = 0;
            ReUseStyleId = -1;
            NewRefrence = 0;
            CreateNew = 0;
            BindStichingWaistsectionOB(CreateNew, NewRefrence, ReUse, ReUseStyleId);
        }
        protected void grdWaistsection_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow Rows = grdWaistsection.Rows[e.RowIndex];

            HiddenField hdnFinalCuttingOBID = Rows.FindControl("hdnFinalCuttingOBID") as HiddenField;
            HiddenField hdnOperationIdEdit = Rows.FindControl("hdnOperationIdEdit") as HiddenField;
            HiddenField hdnWorkerTypeIDEdit = Rows.FindControl("hdnWorkerTypeIDEdit") as HiddenField;
            HiddenField hdnAttachmentIDEdit = Rows.FindControl("hdnAttachmentIDEdit") as HiddenField;
            HiddenField hdnStyleSequence = Rows.FindControl("hdnStyleSequence") as HiddenField;

            TextBox txtOperation = Rows.FindControl("txtOperationEdit") as TextBox;
            Label txtOperationType = Rows.FindControl("txtOperationTypeEdit") as Label;
            Label txtMachine = Rows.FindControl("txtMachineEdit") as Label;

            Label txtAttachment = Rows.FindControl("txtAttachmentEdit") as Label;
            Label txtSAM = Rows.FindControl("txtSAMEdit") as Label;
            TextBox txtMachineCount = Rows.FindControl("txtMachineCountEdit") as TextBox;
            TextBox txtFinalCount = Rows.FindControl("txtFinalCountEdit") as TextBox;
            HyperLink lnkShow = Rows.FindControl("lnkShowEdit") as HyperLink;
            TextBox txtComments = Rows.FindControl("txtCommentsEdit") as TextBox;
            //edit by prabhaker 08-feb-17
            TextBox txtfactor = Rows.FindControl("txtEditFactor") as TextBox;
            //end edit by prabhaker 08-feb-17
            int OperationId = Convert.ToInt32(hdnOperationIdEdit.Value);
            int WorkerType = Convert.ToInt32(hdnWorkerTypeIDEdit.Value);

            obj_OBForm.Flag = "Waistsection";
            obj_OBForm.FinalOBID = Convert.ToInt32(hdnFinalCuttingOBID.Value);


            if (txtOperation.Text == "")
            {
                obj_OBForm.NoOfOperation = 0;
            }
            else
            {
                obj_OBForm.NoOfOperation = Convert.ToInt32(txtOperation.Text.Trim());
            }
            if (txtSAM.Text.Trim() != "")
                obj_OBForm.Sam = Convert.ToDouble(txtSAM.Text.Trim());
            if (txtMachineCount.Text.Trim() != "")
                obj_OBForm.MachineCount = Convert.ToDouble(txtMachineCount.Text.Trim());
            if (txtFinalCount.Text.Trim() != "")
                obj_OBForm.FinalCount = Convert.ToInt32(txtFinalCount.Text.Trim());
            obj_OBForm.Comments = txtComments.Text.Trim();

            int IsUpdate = 0;
            string IsReuseCode = string.Empty;
            int StyleSequence = 0;

            int IsExist = obj_OrderController.GetOperationType(styleid, OperationId, WorkerType, obj_OBForm.NoOfOperation, obj_OBForm.Flag, obj_OBForm.FinalOBID);

            if (IsExist == 1)
            {
                ShowAlert("Operation Already Exist");
                //grdStichingassembly.EditIndex = -1;
                return;
            }
            else
            {
                if (hdnReUse.Value == "1")
                {
                    ReUseStyleId = -1;
                    StyleSequence = Convert.ToInt32(hdnStyleSequence.Value);
                    IsReuseCode = "";
                    IsUpdate = obj_OrderController.UpdateFinalOB(obj_OBForm, styleid, ReUseStyleId, IsReuseCode, StyleSequence);
                }
                else
                {
                    IsReuseCode = "";
                    IsUpdate = obj_OrderController.UpdateFinalOB(obj_OBForm, styleid, ReUseStyleId, IsReuseCode, StyleSequence);
                }

                if (IsUpdate > 0)
                {
                    grdWaistsection.EditIndex = -1;
                    ReUse = 0;
                    ReUseStyleId = -1;
                    NewRefrence = 0;
                    CreateNew = 0;
                    BindStichingWaistsectionOB(CreateNew, NewRefrence, ReUse, ReUseStyleId);
                    BindStichingManPower(CreateNew, NewRefrence, ReUse, ReUseStyleId);
                    //ShowAlert("Updated Sucessfully !");
                    return;
                }
                else
                {
                    ShowAlert("Not Update !");
                    return;
                }
            }
        }
        protected void grdWaistsection_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = grdWaistsection.Rows[e.RowIndex];
            HiddenField hdnFinalCuttingOBID = (HiddenField)row.FindControl("hdnFinalOBIdItem");
            string Flag = "Waistsection";
            if (hdnFinalCuttingOBID != null)
            {
                int IsDelete = obj_OrderController.DeleteOBById(Convert.ToInt32(hdnFinalCuttingOBID.Value), Flag);
                grdWaistsection.EditIndex = -1;
                ReUse = 0;
                ReUseStyleId = -1;
                NewRefrence = 0;
                CreateNew = 0;
                //BindStichingWaistsectionOB(CreateNew, NewRefrence, ReUse, ReUseStyleId);
                BindStichingOBGrid(CreateNew, NewRefrence, ReUse, ReUseStyleId);
                BindStichingManPower(CreateNew, NewRefrence, ReUse, ReUseStyleId);

            }
        }
        //END Waist


        //For Band section
        protected void grdBandsection_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdBandsection.PageIndex = e.NewPageIndex;
            grdBandsection.EditIndex = -1;
            ReUse = 0;
            ReUseStyleId = -1;
            NewRefrence = 0;
            CreateNew = 0;
            BindStichingBandsectionOB(CreateNew, NewRefrence, ReUse, ReUseStyleId);

        }
        protected void grdBandsection_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grdBandsection.EditIndex = -1;
            ReUse = 0;
            ReUseStyleId = -1;
            NewRefrence = 0;
            CreateNew = 0;
            BindStichingBandsectionOB(CreateNew, NewRefrence, ReUse, ReUseStyleId);
        }
        protected void grdBandsection_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            int ReUse = Convert.ToInt32(hdnReUse.Value);

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //return;
                Literal ltIndex = (Literal)e.Row.FindControl("ltIndex");
                ltIndex.Text = (Convert.ToInt32(RowNum) + 1).ToString();
                RowNum = (Convert.ToInt32(RowNum) + 1);

                Label lblSAM = (Label)e.Row.FindControl("lblSAM");
                TextBox lblMachineCount = (TextBox)e.Row.FindControl("lblMachineCount");
                TextBox lblFinalCount = (TextBox)e.Row.FindControl("lblFinalCount");
                TextBox lblComments = (TextBox)e.Row.FindControl("lblComments");
                // Edit By Prabhaker )8-feb-17

                TextBox txtFactor = (TextBox)e.Row.FindControl("txtFactor");
                if (txtFactor != null)
                {
                    if (txtFactor.Text == "")
                        txtFactor.Text = "0";

                    TotalFact = TotalFact + Convert.ToDouble(txtFactor.Text);

                }
                // End Edit By Prabhaker )8-feb-17
                if (lblSAM != null)
                {
                    if (lblSAM.Text == "")
                        lblSAM.Text = "0";

                    TotalSam = TotalSam + Convert.ToDouble(lblSAM.Text);

                }

                if (lblMachineCount != null)
                {
                    if (lblMachineCount.Text == "")
                        lblMachineCount.Text = "0";

                    TotalMachine = TotalMachine + Convert.ToDouble(lblMachineCount.Text);

                }

                if (lblFinalCount != null)
                {
                    if (lblFinalCount.Text == "")
                        lblFinalCount.Text = "0";

                    FinalMachine = FinalMachine + Convert.ToDouble(lblFinalCount.Text);

                }

                Label lblOperation = (Label)e.Row.FindControl("lblOperation");
                if (lblOperation != null)
                {
                    if (lblOperation.Text == "0")
                    {
                        lblOperation.Text = "";
                    }
                }
                //LinkButton lnkEdit = (LinkButton)e.Row.FindControl("lnkEdit");
                //if (ReUse == 1)
                //{
                //    lnkEdit.Visible = false;
                //}
                LinkButton lnkDelete = (LinkButton)e.Row.FindControl("lnkDelete");
                if (ReUse == 1)
                {
                    lnkDelete.Attributes.Add("style", "display:none;");
                    lblMachineCount.Enabled = false;
                    lblFinalCount.Enabled = false;
                    lblComments.Enabled = false;
                }
                if ((chkIsFactoryIE.Checked)  && (chkIsIEManager.Checked))
                {
                    lnkDelete.Attributes.Add("style", "display:none;");
                    lblMachineCount.Enabled = false;
                    lblFinalCount.Enabled = false;
                    lblComments.Enabled = false;
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label txtSAMFooter = (Label)e.Row.FindControl("txtSAMFooter");
                //TotalSam
                if (TotalSam != 0)
                    txtSAMFooter.Text = TotalSam.ToString();
                //edit by prabhaker 08-feb-17
                Label lblFactorFooter = (Label)e.Row.FindControl("lblFactorFooter");
                if (TotalFact != 0)
                {
                    int TottalRowsCount = grdBandsection.Rows.Count;
                    lblFactorFooter.Text = Math.Round((Convert.ToDecimal(TotalFact) / TottalRowsCount), 2).ToString();
                    //lblFactorFooter.Text = TotalFact.ToString();
                }
                //end edit by prabhaker 08-feb-17
                Label txtMachineCountFooter = (Label)e.Row.FindControl("txtMachineCountFooter");

                //TotalSam
                if (TotalMachine != 0)
                    txtMachineCountFooter.Text = TotalMachine.ToString();

                Label txtFinalCountFooter = (Label)e.Row.FindControl("txtFinalCountFooter");
                //TotalSam
                if (FinalMachine != 0)
                    txtFinalCountFooter.Text = FinalMachine.ToString();

                TotalFact = 0;
                TotalSam = 0;
                TotalMachine = 0;
                FinalMachine = 0;
            }

        }
        protected void grdBandsection_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grdBandsection.EditIndex = e.NewEditIndex;

            ReUse = 0;
            ReUseStyleId = -1;
            NewRefrence = 0;
            CreateNew = 0;
            BindStichingBandsectionOB(CreateNew, NewRefrence, ReUse, ReUseStyleId);

        }
        protected void grdBandsection_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow Rows = grdBandsection.Rows[e.RowIndex];

            HiddenField hdnFinalCuttingOBID = Rows.FindControl("hdnFinalCuttingOBID") as HiddenField;
            HiddenField hdnOperationIdEdit = Rows.FindControl("hdnOperationIdEdit") as HiddenField;
            HiddenField hdnWorkerTypeIDEdit = Rows.FindControl("hdnWorkerTypeIDEdit") as HiddenField;
            HiddenField hdnAttachmentIDEdit = Rows.FindControl("hdnAttachmentIDEdit") as HiddenField;
            HiddenField hdnStyleSequence = Rows.FindControl("hdnStyleSequence") as HiddenField;

            TextBox txtOperation = Rows.FindControl("txtOperationEdit") as TextBox;
            Label txtOperationType = Rows.FindControl("txtOperationTypeEdit") as Label;
            Label txtMachine = Rows.FindControl("txtMachineEdit") as Label;

            Label txtAttachment = Rows.FindControl("txtAttachmentEdit") as Label;
            Label txtSAM = Rows.FindControl("txtSAMEdit") as Label;
            TextBox txtMachineCount = Rows.FindControl("txtMachineCountEdit") as TextBox;
            TextBox txtFinalCount = Rows.FindControl("txtFinalCountEdit") as TextBox;
            HyperLink lnkShow = Rows.FindControl("lnkShowEdit") as HyperLink;
            TextBox txtComments = Rows.FindControl("txtCommentsEdit") as TextBox;
            //edit by prabhaker 08-feb-17
            TextBox txtfactor = Rows.FindControl("txtEditFactor") as TextBox;
            //end edit by prabhaker 08-feb-17
            int OperationId = Convert.ToInt32(hdnOperationIdEdit.Value);
            int WorkerType = Convert.ToInt32(hdnWorkerTypeIDEdit.Value);

            obj_OBForm.Flag = "Bandsection";
            obj_OBForm.FinalOBID = Convert.ToInt32(hdnFinalCuttingOBID.Value);


            if (txtOperation.Text == "")
            {
                obj_OBForm.NoOfOperation = 0;
            }
            else
            {
                obj_OBForm.NoOfOperation = Convert.ToInt32(txtOperation.Text.Trim());
            }
            if (txtSAM.Text.Trim() != "")
                obj_OBForm.Sam = Convert.ToDouble(txtSAM.Text.Trim());
            if (txtMachineCount.Text.Trim() != "")
                obj_OBForm.MachineCount = Convert.ToDouble(txtMachineCount.Text.Trim());
            if (txtFinalCount.Text.Trim() != "")
                obj_OBForm.FinalCount = Convert.ToInt32(txtFinalCount.Text.Trim());
            obj_OBForm.Comments = txtComments.Text.Trim();

            int IsUpdate = 0;
            string IsReuseCode = string.Empty;
            int StyleSequence = 0;

            int IsExist = obj_OrderController.GetOperationType(styleid, OperationId, WorkerType, obj_OBForm.NoOfOperation, obj_OBForm.Flag, obj_OBForm.FinalOBID);

            if (IsExist == 1)
            {
                ShowAlert("Operation Already Exist");
                //grdStichingassembly.EditIndex = -1;
                return;
            }
            else
            {
                if (hdnReUse.Value == "1")
                {
                    ReUseStyleId = -1;
                    StyleSequence = Convert.ToInt32(hdnStyleSequence.Value);
                    IsReuseCode = "";
                    IsUpdate = obj_OrderController.UpdateFinalOB(obj_OBForm, styleid, ReUseStyleId, IsReuseCode, StyleSequence);
                }
                else
                {
                    IsReuseCode = "";
                    IsUpdate = obj_OrderController.UpdateFinalOB(obj_OBForm, styleid, ReUseStyleId, IsReuseCode, StyleSequence);
                }

                if (IsUpdate > 0)
                {
                    grdBandsection.EditIndex = -1;
                    ReUse = 0;
                    ReUseStyleId = -1;
                    NewRefrence = 0;
                    CreateNew = 0;
                    BindStichingBandsectionOB(CreateNew, NewRefrence, ReUse, ReUseStyleId);
                    BindStichingManPower(CreateNew, NewRefrence, ReUse, ReUseStyleId);
                    // ShowAlert("Updated Sucessfully !");
                    return;
                }
                else
                {
                    ShowAlert("Not Update !");
                    return;
                }
            }
        }
        protected void grdBandsection_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = grdBandsection.Rows[e.RowIndex];
            HiddenField hdnFinalCuttingOBID = (HiddenField)row.FindControl("hdnFinalOBIdItem");
            string Flag = "Bandsection";
            if (hdnFinalCuttingOBID != null)
            {
                int IsDelete = obj_OrderController.DeleteOBById(Convert.ToInt32(hdnFinalCuttingOBID.Value), Flag);
                grdBandsection.EditIndex = -1;
                ReUse = 0;
                ReUseStyleId = -1;
                NewRefrence = 0;
                CreateNew = 0;
                //BindStichingBandsectionOB(CreateNew, NewRefrence, ReUse, ReUseStyleId);
                BindStichingOBGrid(CreateNew, NewRefrence, ReUse, ReUseStyleId);
                BindStichingManPower(CreateNew, NewRefrence, ReUse, ReUseStyleId);

            }
        }
        //END Band

        //added by abhishek on 9/9/2015------------------------------------------------//
        /*
        protected void grdNeckNewsection_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdNeckNewsection.PageIndex = e.NewPageIndex;
            grdNeckNewsection.EditIndex = -1;
            ReUse = 0;
            ReUseStyleId = -1;
            NewRefrence = 0;
            CreateNew = 0;
            BindStichingNeckNewsectionOB(CreateNew, NewRefrence, ReUse, ReUseStyleId);

        }
        protected void grdNeckNewsection_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grdBandsection.EditIndex = -1;
            ReUse = 0;
            ReUseStyleId = -1;
            NewRefrence = 0;
            CreateNew = 0;
            BindStichingNeckNewsectionOB(CreateNew, NewRefrence, ReUse, ReUseStyleId);
        }
         */
        protected void grdNeckNewsection_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            int ReUse = Convert.ToInt32(hdnReUse.Value);

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //return;
                Literal ltIndex = (Literal)e.Row.FindControl("ltIndex");
                ltIndex.Text = (Convert.ToInt32(RowNum) + 1).ToString();
                RowNum = (Convert.ToInt32(RowNum) + 1);

                Label lblSAM = (Label)e.Row.FindControl("lblSAM");
                TextBox lblMachineCount = (TextBox)e.Row.FindControl("lblMachineCount");
                TextBox lblFinalCount = (TextBox)e.Row.FindControl("lblFinalCount");
                TextBox lblComments = (TextBox)e.Row.FindControl("lblComments");
                // Edit By Prabhaker )8-feb-17

                TextBox txtFactor = (TextBox)e.Row.FindControl("txtFactor");
                if (txtFactor != null)
                {
                    if (txtFactor.Text == "")
                        txtFactor.Text = "0";

                    TotalFact = TotalFact + Convert.ToDouble(txtFactor.Text);

                }
                // End Edit By Prabhaker )8-feb-17
                if (lblSAM != null)
                {
                    if (lblSAM.Text == "")
                        lblSAM.Text = "0";

                    TotalSam = TotalSam + Convert.ToDouble(lblSAM.Text);

                }

                if (lblMachineCount != null)
                {
                    if (lblMachineCount.Text == "")
                        lblMachineCount.Text = "0";

                    TotalMachine = TotalMachine + Convert.ToDouble(lblMachineCount.Text);

                }

                if (lblFinalCount != null)
                {
                    if (lblFinalCount.Text == "")
                        lblFinalCount.Text = "0";

                    FinalMachine = FinalMachine + Convert.ToDouble(lblFinalCount.Text);

                }

                Label lblOperation = (Label)e.Row.FindControl("lblOperation");
                if (lblOperation != null)
                {
                    if (lblOperation.Text == "0")
                    {
                        lblOperation.Text = "";
                    }
                }
                //LinkButton lnkEdit = (LinkButton)e.Row.FindControl("lnkEdit");
                //if (ReUse == 1)
                //{
                //    lnkEdit.Visible = false;
                //}
                LinkButton lnkDelete = (LinkButton)e.Row.FindControl("lnkDelete");
                if (ReUse == 1)
                {
                    lnkDelete.Attributes.Add("style", "display:none;");
                    lblMachineCount.Enabled = false;
                    lblFinalCount.Enabled = false;
                    lblComments.Enabled = false;
                }
                if ((chkIsFactoryIE.Checked)  && (chkIsIEManager.Checked))
                {
                    lnkDelete.Attributes.Add("style", "display:none;");
                    lblMachineCount.Enabled = false;
                    lblFinalCount.Enabled = false;
                    lblComments.Enabled = false;
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label txtSAMFooter = (Label)e.Row.FindControl("txtSAMFooter");
                //TotalSam
                if (TotalSam != 0)
                    txtSAMFooter.Text = TotalSam.ToString();
                //edit by prabhaker 08-feb-17
                Label lblFactorFooter = (Label)e.Row.FindControl("lblFactorFooter");
                if (TotalFact != 0)
                {
                    int TottalRowsCount = grdNeckNewsection.Rows.Count;
                    lblFactorFooter.Text = Math.Round((Convert.ToDecimal(TotalFact) / TottalRowsCount), 2).ToString();
                }
                //end edit by prabhaker 08-feb-17
                Label txtMachineCountFooter = (Label)e.Row.FindControl("txtMachineCountFooter");

                //TotalSam
                if (TotalMachine != 0)
                    txtMachineCountFooter.Text = TotalMachine.ToString();

                Label txtFinalCountFooter = (Label)e.Row.FindControl("txtFinalCountFooter");
                //TotalSam
                if (FinalMachine != 0)
                    txtFinalCountFooter.Text = FinalMachine.ToString();

                TotalFact = 0;
                TotalSam = 0;
                TotalMachine = 0;
                FinalMachine = 0;
            }

        }

        protected void grdNeckNewsection_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = grdNeckNewsection.Rows[e.RowIndex];
            HiddenField hdnFinalCuttingOBID = (HiddenField)row.FindControl("hdnFinalOBIdItem");
            string Flag = "NeckNewsection";
            if (hdnFinalCuttingOBID != null)
            {
                int IsDelete = obj_OrderController.DeleteOBById(Convert.ToInt32(hdnFinalCuttingOBID.Value), Flag);
                grdNeckNewsection.EditIndex = -1;
                ReUse = 0;
                ReUseStyleId = -1;
                NewRefrence = 0;
                CreateNew = 0;
                //BindStichingBandsectionOB(CreateNew, NewRefrence, ReUse, ReUseStyleId);
                BindStichingOBGrid(CreateNew, NewRefrence, ReUse, ReUseStyleId);
                BindStichingManPower(CreateNew, NewRefrence, ReUse, ReUseStyleId);

            }
        }
        //for neck faching ------------------------------//
        protected void grdNeckFacing_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            int ReUse = Convert.ToInt32(hdnReUse.Value);

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //return;
                Literal ltIndex = (Literal)e.Row.FindControl("ltIndex");
                ltIndex.Text = (Convert.ToInt32(RowNum) + 1).ToString();
                RowNum = (Convert.ToInt32(RowNum) + 1);

                Label lblSAM = (Label)e.Row.FindControl("lblSAM");
                TextBox lblMachineCount = (TextBox)e.Row.FindControl("lblMachineCount");
                TextBox lblFinalCount = (TextBox)e.Row.FindControl("lblFinalCount");
                TextBox lblComments = (TextBox)e.Row.FindControl("lblComments");
                // Edit By Prabhaker )8-feb-17

                TextBox txtFactor = (TextBox)e.Row.FindControl("txtFactor");
                if (txtFactor != null)
                {
                    if (txtFactor.Text == "")
                        txtFactor.Text = "0";

                    TotalFact = TotalFact + Convert.ToDouble(txtFactor.Text);

                }
                // End Edit By Prabhaker )8-feb-17
                if (lblSAM != null)
                {
                    if (lblSAM.Text == "")
                        lblSAM.Text = "0";

                    TotalSam = TotalSam + Convert.ToDouble(lblSAM.Text);

                }

                if (lblMachineCount != null)
                {
                    if (lblMachineCount.Text == "")
                        lblMachineCount.Text = "0";

                    TotalMachine = TotalMachine + Convert.ToDouble(lblMachineCount.Text);

                }

                if (lblFinalCount != null)
                {
                    if (lblFinalCount.Text == "")
                        lblFinalCount.Text = "0";

                    FinalMachine = FinalMachine + Convert.ToDouble(lblFinalCount.Text);

                }

                Label lblOperation = (Label)e.Row.FindControl("lblOperation");
                if (lblOperation != null)
                {
                    if (lblOperation.Text == "0")
                    {
                        lblOperation.Text = "";
                    }
                }
                //LinkButton lnkEdit = (LinkButton)e.Row.FindControl("lnkEdit");
                //if (ReUse == 1)
                //{
                //    lnkEdit.Visible = false;
                //}
                LinkButton lnkDelete = (LinkButton)e.Row.FindControl("lnkDelete");
                if (ReUse == 1)
                {
                    lnkDelete.Attributes.Add("style", "display:none;");
                    lblMachineCount.Enabled = false;
                    lblFinalCount.Enabled = false;
                    lblComments.Enabled = false;
                }
                if ((chkIsFactoryIE.Checked)  && (chkIsIEManager.Checked))
                {
                    lnkDelete.Attributes.Add("style", "display:none;");
                    lblMachineCount.Enabled = false;
                    lblFinalCount.Enabled = false;
                    lblComments.Enabled = false;
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label txtSAMFooter = (Label)e.Row.FindControl("txtSAMFooter");
                //TotalSam
                if (TotalSam != 0)
                    txtSAMFooter.Text = TotalSam.ToString();
                //edit by prabhaker 08-feb-17
                Label lblFactorFooter = (Label)e.Row.FindControl("lblFactorFooter");
                if (TotalFact != 0)
                {
                    int TottalRowsCount = grdNeckFacing.Rows.Count;
                    lblFactorFooter.Text = Math.Round((Convert.ToDecimal(TotalFact) / TottalRowsCount), 2).ToString();
                    //lblFactorFooter.Text = TotalFact.ToString();
                }
                //end edit by prabhaker 08-feb-17
                Label txtMachineCountFooter = (Label)e.Row.FindControl("txtMachineCountFooter");

                //TotalSam
                if (TotalMachine != 0)
                    txtMachineCountFooter.Text = TotalMachine.ToString();

                Label txtFinalCountFooter = (Label)e.Row.FindControl("txtFinalCountFooter");
                //TotalSam
                if (FinalMachine != 0)
                    txtFinalCountFooter.Text = FinalMachine.ToString();

                TotalFact = 0;
                TotalSam = 0;
                TotalMachine = 0;
                FinalMachine = 0;
            }

        }

        protected void grdNeckFacing_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = grdNeckFacing.Rows[e.RowIndex];
            HiddenField hdnFinalCuttingOBID = (HiddenField)row.FindControl("hdnFinalOBIdItem");
            string Flag = "NeckFacing";
            if (hdnFinalCuttingOBID != null)
            {
                int IsDelete = obj_OrderController.DeleteOBById(Convert.ToInt32(hdnFinalCuttingOBID.Value), Flag);
                grdNeckFacing.EditIndex = -1;
                ReUse = 0;
                ReUseStyleId = -1;
                NewRefrence = 0;
                CreateNew = 0;
                //BindStichingBandsectionOB(CreateNew, NewRefrence, ReUse, ReUseStyleId);
                BindStichingOBGrid(CreateNew, NewRefrence, ReUse, ReUseStyleId);
                BindStichingManPower(CreateNew, NewRefrence, ReUse, ReUseStyleId);

            }
        }

        protected void grdfrontback_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            int ReUse = Convert.ToInt32(hdnReUse.Value);

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //return;
                Literal ltIndex = (Literal)e.Row.FindControl("ltIndex");
                ltIndex.Text = (Convert.ToInt32(RowNum) + 1).ToString();
                RowNum = (Convert.ToInt32(RowNum) + 1);

                Label lblSAM = (Label)e.Row.FindControl("lblSAM");
                TextBox lblMachineCount = (TextBox)e.Row.FindControl("lblMachineCount");
                TextBox lblFinalCount = (TextBox)e.Row.FindControl("lblFinalCount");
                TextBox lblComments = (TextBox)e.Row.FindControl("lblComments");
                // Edit By Prabhaker )8-feb-17

                TextBox txtFactor = (TextBox)e.Row.FindControl("txtFactor");
                if (txtFactor != null)
                {
                    if (txtFactor.Text == "")
                        txtFactor.Text = "0";

                    TotalFact = TotalFact + Convert.ToDouble(txtFactor.Text);

                }
                // End Edit By Prabhaker )8-feb-17
                if (lblSAM != null)
                {
                    if (lblSAM.Text == "")
                        lblSAM.Text = "0";

                    TotalSam = TotalSam + Convert.ToDouble(lblSAM.Text);

                }

                if (lblMachineCount != null)
                {
                    if (lblMachineCount.Text == "")
                        lblMachineCount.Text = "0";

                    TotalMachine = TotalMachine + Convert.ToDouble(lblMachineCount.Text);

                }

                if (lblFinalCount != null)
                {
                    if (lblFinalCount.Text == "")
                        lblFinalCount.Text = "0";

                    FinalMachine = FinalMachine + Convert.ToDouble(lblFinalCount.Text);

                }

                Label lblOperation = (Label)e.Row.FindControl("lblOperation");
                if (lblOperation != null)
                {
                    if (lblOperation.Text == "0")
                    {
                        lblOperation.Text = "";
                    }
                }
                //LinkButton lnkEdit = (LinkButton)e.Row.FindControl("lnkEdit");
                //if (ReUse == 1)
                //{
                //    lnkEdit.Visible = false;
                //}
                LinkButton lnkDelete = (LinkButton)e.Row.FindControl("lnkDelete");
                if (ReUse == 1)
                {
                    lnkDelete.Attributes.Add("style", "display:none;");
                    lblMachineCount.Enabled = false;
                    lblFinalCount.Enabled = false;
                    lblComments.Enabled = false;
                }
                if ((chkIsFactoryIE.Checked)  && (chkIsIEManager.Checked))
                {
                    lnkDelete.Attributes.Add("style", "display:none;");
                    lblMachineCount.Enabled = false;
                    lblFinalCount.Enabled = false;
                    lblComments.Enabled = false;
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label txtSAMFooter = (Label)e.Row.FindControl("txtSAMFooter");
                //TotalSam
                if (TotalSam != 0)
                    txtSAMFooter.Text = TotalSam.ToString();
                //edit by prabhaker 08-feb-17
                Label lblFactorFooter = (Label)e.Row.FindControl("lblFactorFooter");
                if (TotalFact != 0)
                {
                    int TottalRowsCount = grdfrontback.Rows.Count;
                    lblFactorFooter.Text = Math.Round((Convert.ToDecimal(TotalFact) / TottalRowsCount), 2).ToString();
                    //lblFactorFooter.Text = TotalFact.ToString();
                }

                //end edit by prabhaker 08-feb-17
                Label txtMachineCountFooter = (Label)e.Row.FindControl("txtMachineCountFooter");

                //TotalSam
                if (TotalMachine != 0)
                    txtMachineCountFooter.Text = TotalMachine.ToString();

                Label txtFinalCountFooter = (Label)e.Row.FindControl("txtFinalCountFooter");
                //TotalSam
                if (FinalMachine != 0)
                    txtFinalCountFooter.Text = FinalMachine.ToString();

                TotalFact = 0;
                TotalSam = 0;
                TotalMachine = 0;
                FinalMachine = 0;
            }

        }

        protected void grdfrontback_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = grdfrontback.Rows[e.RowIndex];
            HiddenField hdnFinalCuttingOBID = (HiddenField)row.FindControl("hdnFinalOBIdItem");
            string Flag = "frontback";
            if (hdnFinalCuttingOBID != null)
            {
                int IsDelete = obj_OrderController.DeleteOBById(Convert.ToInt32(hdnFinalCuttingOBID.Value), Flag);
                grdfrontback.EditIndex = -1;
                ReUse = 0;
                ReUseStyleId = -1;
                NewRefrence = 0;
                CreateNew = 0;
                //BindStichingBandsectionOB(CreateNew, NewRefrence, ReUse, ReUseStyleId);
                BindStichingOBGrid(CreateNew, NewRefrence, ReUse, ReUseStyleId);
                BindStichingManPower(CreateNew, NewRefrence, ReUse, ReUseStyleId);

            }
        }
        //end neck section-------------------------------//
        //end by abhishek on 9/9/2015--------------------------------------------------------------------//

        //END
        //For Stiching Finishing
        protected void grdFinishing_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdFinishing.PageIndex = e.NewPageIndex;
            grdFinishing.EditIndex = -1;
            ReUse = 0;
            ReUseStyleId = -1;
            NewRefrence = 0;
            CreateNew = 0;
            BindFinishingOB(CreateNew, NewRefrence, ReUse, ReUseStyleId);

        }
        protected void grdFinishing_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grdFinishing.EditIndex = -1;
            ReUse = 0;
            ReUseStyleId = -1;
            NewRefrence = 0;
            CreateNew = 0;
            BindFinishingOB(CreateNew, NewRefrence, ReUse, ReUseStyleId);
        }
        protected void grdFinishing_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            int ReUse = Convert.ToInt32(hdnReUse.Value);

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //return;
                Literal ltIndex = (Literal)e.Row.FindControl("ltIndex");
                ltIndex.Text = ((grdFinishing.PageIndex * grdFinishing.PageSize) + e.Row.RowIndex + 1).ToString();

                //ltIndex.Text = (Convert.ToInt32(RowNum) + 1).ToString();
                //RowNum = (Convert.ToInt32(RowNum) + 1);

                Label lblSAM = (Label)e.Row.FindControl("lblSAM");
                TextBox lblMachineCount = (TextBox)e.Row.FindControl("lblMachineCount");
                TextBox lblFinalCount = (TextBox)e.Row.FindControl("lblFinalCount");
                TextBox lblComments = (TextBox)e.Row.FindControl("lblComments");
                // Edit By Prabhaker 8-feb-17

                TextBox txtFactor = (TextBox)e.Row.FindControl("txtFactor");
                if (txtFactor != null)
                {
                    if (txtFactor.Text == "")
                        txtFactor.Text = "0";

                    TotalFact = TotalFact + Convert.ToDouble(txtFactor.Text);

                }
                // End Edit By Prabhaker )8-feb-17
                if (lblSAM != null)
                {
                    if (lblSAM.Text == "")
                        lblSAM.Text = "0";

                    TotalSam = TotalSam + Convert.ToDouble(lblSAM.Text);

                }

                if (lblMachineCount != null)
                {
                    if (lblMachineCount.Text == "")
                        lblMachineCount.Text = "0";

                    TotalMachine = TotalMachine + Convert.ToDouble(lblMachineCount.Text);

                }

                if (lblFinalCount != null)
                {
                    if (lblFinalCount.Text == "")
                        lblFinalCount.Text = "0";

                    FinalMachine = FinalMachine + Convert.ToDouble(lblFinalCount.Text);

                }

                Label lblOperation = (Label)e.Row.FindControl("lblOperation");
                if (lblOperation != null)
                {
                    if (lblOperation.Text == "0")
                    {
                        lblOperation.Text = "";
                    }
                }
                //LinkButton lnkEdit = (LinkButton)e.Row.FindControl("lnkEdit");
                //if (ReUse == 1)
                //{
                //    lnkEdit.Visible = false;
                //}
                LinkButton lnkDelete = (LinkButton)e.Row.FindControl("lnkDelete");
                if (ReUse == 1)
                {
                    lnkDelete.Attributes.Add("style", "display:none;");
                    lblMachineCount.Enabled = false;
                    lblFinalCount.Enabled = false;
                    lblComments.Enabled = false;
                }
                if ((chkIsFactoryIE.Checked)  && (chkIsIEManager.Checked))
                {
                    lnkDelete.Attributes.Add("style", "display:none;");
                    lblMachineCount.Enabled = false;
                    lblFinalCount.Enabled = false;
                    lblComments.Enabled = false;
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label txtSAMFooter = (Label)e.Row.FindControl("txtSAMFooter");
                //TotalSam
                if (TotalSam != 0)
                    txtSAMFooter.Text = TotalSam.ToString();

                //edit by prabhaker 08-feb-17
                Label lblFactorFooter = (Label)e.Row.FindControl("lblFactorFooter");
                if (TotalFact != 0)
                {
                    int TottalRowsCount = grdFinishing.Rows.Count;
                    lblFactorFooter.Text = Math.Round((Convert.ToDecimal(TotalFact) / TottalRowsCount), 2).ToString();
                    //lblFactorFooter.Text = TotalFact.ToString(); 
                }
                //end edit by prabhaker 08-feb-17

                Label txtMachineCountFooter = (Label)e.Row.FindControl("txtMachineCountFooter");              
                //TotalSam
                if (TotalMachine != 0)
                    txtMachineCountFooter.Text = TotalMachine.ToString();

                Label txtFinalCountFooter = (Label)e.Row.FindControl("txtFinalCountFooter");
                //TotalSam
                if (FinalMachine != 0)
                    txtFinalCountFooter.Text = FinalMachine.ToString();

                TotalFact = 0;
                TotalSam = 0;
                TotalMachine = 0;
                FinalMachine = 0;
            }

        }
        protected void grdFinishing_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grdFinishing.EditIndex = e.NewEditIndex;

            ReUse = 0;
            ReUseStyleId = -1;
            NewRefrence = 0;
            CreateNew = 0;
            BindFinishingOB(CreateNew, NewRefrence, ReUse, ReUseStyleId);
        }
        protected void grdFinishing_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {

        }
        protected void grdFinishing_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow Rows = grdFinishing.Rows[e.RowIndex];

            HiddenField hdnFinalCuttingOBID = Rows.FindControl("hdnFinalCuttingOBID") as HiddenField;
            HiddenField hdnOperationIdEdit = Rows.FindControl("hdnOperationIdEdit") as HiddenField;
            HiddenField hdnWorkerTypeIDEdit = Rows.FindControl("hdnWorkerTypeIDEdit") as HiddenField;
            HiddenField hdnAttachmentIDEdit = Rows.FindControl("hdnAttachmentIDEdit") as HiddenField;
            HiddenField hdnStyleSequence = Rows.FindControl("hdnStyleSequence") as HiddenField;

            TextBox txtOperation = Rows.FindControl("txtOperationEdit") as TextBox;
            Label txtOperationType = Rows.FindControl("txtOperationTypeEdit") as Label;
            Label txtMachine = Rows.FindControl("txtMachineEdit") as Label;

            Label txtAttachment = Rows.FindControl("txtAttachmentEdit") as Label;
            Label txtSAM = Rows.FindControl("txtSAMEdit") as Label;
            TextBox txtMachineCount = Rows.FindControl("txtMachineCountEdit") as TextBox;
            TextBox txtFinalCount = Rows.FindControl("txtFinalCountEdit") as TextBox;
            HyperLink lnkShow = Rows.FindControl("lnkShowEdit") as HyperLink;
            TextBox txtComments = Rows.FindControl("txtCommentsEdit") as TextBox;
            //edit by prabhaker 08-feb-17
            TextBox txtfactor = Rows.FindControl("txtEditFactor") as TextBox;
            //end edit by prabhaker 08-feb-17
            int OperationId = Convert.ToInt32(hdnOperationIdEdit.Value);
            int WorkerType = Convert.ToInt32(hdnWorkerTypeIDEdit.Value);

            obj_OBForm.Flag = "Finishing";
            obj_OBForm.FinalOBID = Convert.ToInt32(hdnFinalCuttingOBID.Value);


            if (txtOperation.Text == "")
            {
                obj_OBForm.NoOfOperation = 0;
            }
            else
            {
                obj_OBForm.NoOfOperation = Convert.ToInt32(txtOperation.Text.Trim());
            }
            if (txtSAM.Text.Trim() != "")
                obj_OBForm.Sam = Convert.ToDouble(txtSAM.Text.Trim());
            if (txtMachineCount.Text.Trim() != "")
                obj_OBForm.MachineCount = Convert.ToDouble(txtMachineCount.Text.Trim());
            if (txtFinalCount.Text.Trim() != "")
                obj_OBForm.FinalCount = Convert.ToInt32(txtFinalCount.Text.Trim());
            obj_OBForm.Comments = txtComments.Text.Trim();

            int IsUpdate = 0;
            string IsReuseCode = string.Empty;
            int StyleSequence = 0;

            int IsExist = obj_OrderController.GetOperationType(styleid, OperationId, WorkerType, obj_OBForm.NoOfOperation, obj_OBForm.Flag, obj_OBForm.FinalOBID);

            if (IsExist == 1)
            {
                ShowAlert("Operation Already Exist");
                //grdFinishing.EditIndex = -1;
                return;
            }
            else
            {
                if (hdnReUse.Value == "1")
                {
                    ReUseStyleId = -1;
                    StyleSequence = Convert.ToInt32(hdnStyleSequence.Value);
                    IsReuseCode = "";
                    IsUpdate = obj_OrderController.UpdateFinalOB(obj_OBForm, styleid, ReUseStyleId, IsReuseCode, StyleSequence);
                }
                else
                {
                    IsReuseCode = "";
                    IsUpdate = obj_OrderController.UpdateFinalOB(obj_OBForm, styleid, ReUseStyleId, IsReuseCode, StyleSequence);
                }

                if (IsUpdate > 0)
                {
                    grdFinishing.EditIndex = -1;
                    ReUse = 0;
                    ReUseStyleId = -1;
                    NewRefrence = 0;
                    CreateNew = 0;
                    BindFinishingOB(CreateNew, NewRefrence, ReUse, ReUseStyleId);
                    BindFinishingManPower(CreateNew, NewRefrence, ReUse, ReUseStyleId);
                    //ShowAlert("Updated Sucessfully !");
                    return;
                }
                else
                {
                    ShowAlert("Not Update !");
                    return;
                }
            }
        }



        #region "METHOD FOR SHOW ALERT"
        public void ShowAlert(string stringAlertMsg)
        {
            string myStringVariable = string.Empty;
            myStringVariable = stringAlertMsg;
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);
        }
        #endregion

        protected void BindSection(int CreateNew, int NewRefrence, int ReUse, int ReUseStyleId)
        {
            DataTable dtBindSection = new DataTable();
            dtBindSection = obj_AdminController.GetStichedSection();
            lstSection.DataSource = dtBindSection;
            lstSection.DataValueField = "OBSectionID";
            lstSection.DataTextField = "Section";
            lstSection.DataBind();


            DataTable dtSection = new DataTable();

            dtSection = obj_OrderController.GetSectionById(obj_OBForm, styleid, ReUse, CreateNew, NewRefrence, ReUseStyleId);

            if (dtSection.Rows.Count > 0)
            {
                for (int idtSection = 0; idtSection <= dtSection.Rows.Count - 1; idtSection++)
                {
                    string opration = dtSection.Rows[idtSection]["OBSectionID"].ToString();

                    //foreach (var oprval in opration)
                    //{
                    if (lstSection.Items.FindByValue(opration.ToString()) != null)
                        lstSection.Items.FindByValue(opration.ToString()).Selected = true;
                    //}
                }
            }
            ReUse = Convert.ToInt32(hdnReUse.Value);
            if (ReUse == 1)
            {
                lstSection.Enabled = false;
                btnSave.Visible = false;
            }
            else
            {
                lstSection.Enabled = true;
                btnSave.Visible = true;
            }

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(ddlGarment.SelectedValue) != -1)
            {
                int id = obj_OrderController.DeleteStichedOperation(obj_OBForm.ClientID, obj_OBForm.DeptId, styleid);
                
                for (int iSection = 0; iSection <= lstSection.Items.Count - 1; iSection++)
                {
                    if (lstSection.Items[iSection].Selected)
                    {
                        int SectionId = Convert.ToInt32(lstSection.Items[iSection].Value);
                        obj_OBForm.SectionId = SectionId;

                        obj_OBForm.GarmentTypeID = Convert.ToInt32(ddlGarment.SelectedValue);
                        int IsSave = obj_OrderController.InsertSection(obj_OBForm, styleid, -1, -1);

                        if (IsSave > 0)
                        {
                            ////this.Page.ClientScript.RegisterStartupScript(this.GetType(), "sCancel", "window.opener.location.href = window.opener.location.href;self.close()", true);
                            //var IsCreated = 1;
                            //Page.ClientScript.RegisterStartupScript(Page.GetType(), "scr", "NewPage(" + IsCreated + ")", true);

                        }
                    }
                    else
                    {
                        int FlagId = Convert.ToInt32(lstSection.Items[iSection].Value);
                        ReUseStyleId = -1;
                        NewRefrence = 0;
                        obj_OBForm.SectionId = FlagId;
                        int Deleteid = obj_OrderController.DeleteStichedRecordById(obj_OBForm.ClientID, obj_OBForm.DeptId, obj_OBForm.StyleCode, styleid, ReUseStyleId, NewRefrence, FlagId);
                    }
                }
            }
            else
            {
                ShowAlert("Please Select Garment Type");
                return;
            }
            CreateNew = 0;
            NewRefrence = 0;
            ReUse = 0;
            ReUseStyleId = -1;
            BindStichingOBGrid(CreateNew, NewRefrence, ReUse, ReUseStyleId);
        }



        protected void btnABC_Click(object sender, EventArgs e)
        {

            hdnIsPopup.Value = "";
            showHidelable();

            bindStyleCode();
            SetParameter();
            lblGarment.Visible = true;
            ddlGarment.Visible = true;
            CreateNew = Convert.ToInt32(hdnCreateNew.Value);
            NewRefrence = Convert.ToInt32(hdnRef.Value);
            ReUse = Convert.ToInt32(hdnReUse.Value);
            ReUseStyleId = Convert.ToInt32(hdnReUseStyleId.Value);
            if (ReUse == 1)
            {
                lstSection.Enabled = false;
                btnSave.Visible = false;
                chkIsFactoryIE.Enabled = false;
                //chkIsFactoryManager.Enabled = false;
                chkIsIEManager.Enabled = false;
                //chkIsProductionGM.Enabled = false;

                dvCuttingPopup.Attributes.Add("style", "display:none");
                dvlblCuttingPopup.Attributes.Add("style", "display:inline");

                dvStchingFront.Attributes.Add("style", "display:none");
                dvlblStchingFront.Attributes.Add("style", "display:inline");

                dvStchingBack.Attributes.Add("style", "display:none");
                dvlblStchingBack.Attributes.Add("style", "display:inline");

                dvStchingcoller.Attributes.Add("style", "display:none");
                dvlblStchingcoller.Attributes.Add("style", "display:inline");

                dvStchingSleeve.Attributes.Add("style", "display:none");
                dvlblStchingSleeve.Attributes.Add("style", "display:inline");

                dvStchingFrill.Attributes.Add("style", "display:none");
                dvlblStchingFrill.Attributes.Add("style", "display:inline");

                dvStchingLining.Attributes.Add("style", "display:none");
                dvlblStchingLining.Attributes.Add("style", "display:inline");
                //new
                dvStchinglower.Attributes.Add("style", "display:none");
                dvlblStchinglower.Attributes.Add("style", "display:inline");

                dvStchingCami.Attributes.Add("style", "display:none");
                dvlblStchingCami.Attributes.Add("style", "display:inline");

                dvStchingAssembly.Attributes.Add("style", "display:none");
                dvlblStchingAssembly.Attributes.Add("style", "display:inline");

                dvStchingPiping.Attributes.Add("style", "display:none");
                dvlblStchingPiping.Attributes.Add("style", "display:inline");

                dvStchingUpper.Attributes.Add("style", "display:none");
                dvlblStchingUpper.Attributes.Add("style", "display:inline");

                dvStchingUpperShell.Attributes.Add("style", "display:none");
                dvlblStchingUpperShell.Attributes.Add("style", "display:inline");

                dvStchingLowerShell.Attributes.Add("style", "display:none");
                dvlblStchingLowerShell.Attributes.Add("style", "display:inline");

                dvStchingShell.Attributes.Add("style", "display:none");
                dvlblStchingShell.Attributes.Add("style", "display:inline");

                dvStchingWaist.Attributes.Add("style", "display:none");
                dvlblStchingWaist.Attributes.Add("style", "display:inline");

                dvStchingBand.Attributes.Add("style", "display:none");
                dvlblStchingBand.Attributes.Add("style", "display:inline");
                //added by abhishek on 10/9/2015
                lblNeckNewsection.Attributes.Add("style", "display:none");
                dvlblNeckNewsection.Attributes.Add("style", "display:inline");

                lblNeckafcing.Attributes.Add("style", "display:none");
                DivNeckFacing.Attributes.Add("style", "display:inline");

                lblfrontback.Attributes.Add("style", "display:none");
                divfrontback.Attributes.Add("style", "display:inline");

                //end by abhishek 

                dvFinishing.Attributes.Add("style", "display:none");
                dvlblFinishing.Attributes.Add("style", "display:inline");

            }
            else
            {
                btnSave.Visible = true;

                dvCuttingPopup.Attributes.Add("style", "display:inline");
                dvlblCuttingPopup.Attributes.Add("style", "display:none");

                dvStchingFront.Attributes.Add("style", "display:inline");
                dvlblStchingFront.Attributes.Add("style", "display:none");

                dvStchingBack.Attributes.Add("style", "display:inline");
                dvlblStchingBack.Attributes.Add("style", "display:none");

                dvStchingcoller.Attributes.Add("style", "display:inline");
                dvlblStchingcoller.Attributes.Add("style", "display:none");

                dvStchingSleeve.Attributes.Add("style", "display:inline");
                dvlblStchingSleeve.Attributes.Add("style", "display:none");

                dvStchingFrill.Attributes.Add("style", "display:inline");
                dvlblStchingFrill.Attributes.Add("style", "display:none");

                dvStchingLining.Attributes.Add("style", "display:inline");
                dvlblStchingLining.Attributes.Add("style", "display:none");
                //new
                dvStchinglower.Attributes.Add("style", "display:inline");
                dvlblStchinglower.Attributes.Add("style", "display:none");

                dvStchingCami.Attributes.Add("style", "display:inline");
                dvlblStchingCami.Attributes.Add("style", "display:none");

                dvStchingAssembly.Attributes.Add("style", "display:inline");
                dvlblStchingAssembly.Attributes.Add("style", "display:none");

                dvStchingPiping.Attributes.Add("style", "display:inline");
                dvlblStchingPiping.Attributes.Add("style", "display:none");

                dvStchingUpper.Attributes.Add("style", "display:inline");
                dvlblStchingUpper.Attributes.Add("style", "display:none");

                dvStchingUpperShell.Attributes.Add("style", "display:inline");
                dvlblStchingUpperShell.Attributes.Add("style", "display:none");

                dvStchingLowerShell.Attributes.Add("style", "display:inline");
                dvlblStchingLowerShell.Attributes.Add("style", "display:none");

                dvStchingShell.Attributes.Add("style", "display:inline");
                dvlblStchingShell.Attributes.Add("style", "display:none");

                dvStchingWaist.Attributes.Add("style", "display:inline");
                dvlblStchingWaist.Attributes.Add("style", "display:none");

                dvStchingBand.Attributes.Add("style", "display:inline");
                dvlblStchingBand.Attributes.Add("style", "display:none");
                //added by abhishek on 10/9/2015
                lblNeckNewsection.Attributes.Add("style", "display:inline");
                dvlblNeckNewsection.Attributes.Add("style", "display:none");


                lblNeckafcing.Attributes.Add("style", "display:inline");
                DivNeckFacing.Attributes.Add("style", "display:none");


                lblfrontback.Attributes.Add("style", "display:inline");
                divfrontback.Attributes.Add("style", "display:none");


                //end by abhishek 



                //lblNeckNewsection
                //dvlblNeckNewsection
                dvFinishing.Attributes.Add("style", "display:inline");
                dvlblFinishing.Attributes.Add("style", "display:none");
            }

            int UserId = iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.UserID;
            //abhishek update proc new
            int iSaveAllRefData = obj_OrderProcessController.CreateNewRef_ReUse_All_OBdata(styleid, obj_OBForm.StyleCode, obj_OBForm.ClientID, obj_OBForm.DeptId, ReUseStyleId, ReUse, NewRefrence, UserId);

            BindControl(CreateNew, NewRefrence, ReUse, ReUseStyleId);

            // Data has been updated for Reuse/ New Ref

            BindSection(0, 0, 0, -1);
            BindCuttingOB(0, 0, 0, -1);
            BindStichingOBGrid(0, 0, 0, -1);
            BindFinishingOB(0, 0, 0, -1);
            // BindCuttingManPower(0, 0, 0, -1);
            BindFinishingManPower(0, 0, 0, -1);
            BindStichingManPower(0, 0, 0, -1);
            ViewState["datatable"] = null;
            BindRemarkGrd(0, 0, 0, -1);
            SetOBPermission();
        }

        protected void btnABCD_Click(object sender, EventArgs e)
        {
            CreateNew = 0;
            NewRefrence = 0;
            ReUse = 0;
            ReUseStyleId = -1;

            //BindSection(0, 0, 0, -1);
            //BindControl(0, 0, 0, -1);

            BindCuttingOB(0, 0, 0, -1);
            BindStichingOBGrid(0, 0, 0, -1);
            BindFinishingOB(0, 0, 0, -1);
            //BindCuttingManPower(0, 0, 0, -1);
            BindFinishingManPower(0, 0, 0, -1);
            BindStichingManPower(0, 0, 0, -1);
            BindRemarkGrd(0, 0, 0, -1);
            SetOBPermission();
        }

        protected void ddlGarment_SelectedIndexChanged(object sender, EventArgs e)
        {
            hdngarentType.Value = ddlGarment.SelectedValue;
            hdnIsPopup.Value = "";

            //CreateNew = 0;
            //NewRefrence = 0;
            //ReUse = 0;
            //ReUseStyleId = -1;

            //BindSection(CreateNew, NewRefrence, ReUse, ReUseStyleId);
            //BindControl(CreateNew, NewRefrence, ReUse, ReUseStyleId);

            BindCuttingOB(0, 0, 0, -1);
            BindStichingOBGrid(0, 0, 0, -1);
            BindFinishingOB(0, 0, 0, -1);
            //BindCuttingManPower(0, 0, 0, -1);
            BindFinishingManPower(0, 0, 0, -1);
            BindStichingManPower(0, 0, 0, -1);
            BindRemarkGrd(0, 0, 0, -1);
            SetOBPermission();


        }

        protected void btnSection_Click(object sender, EventArgs e)
        {
            //hdnIsPopup.Value = "";
            //showHidelable();
            //bindStyleCode();

            //SetParameter();
            //lblGarment.Visible = true;
            //ddlGarment.Visible = true;

            //CreateNew = 0;
            //NewRefrence = 0;
            //ReUse = 0;
            //ReUseStyleId = -1;
            //BindControl(CreateNew, NewRefrence, ReUse, ReUseStyleId);

            BindSection(0, 0, 0, -1);
            BindCuttingOB(0, 0, 0, -1);
            BindStichingOBGrid(0, 0, 0, -1);
            BindFinishingOB(0, 0, 0, -1);
            // BindCuttingManPower(0, 0, 0, -1);
            BindFinishingManPower(0, 0, 0, -1);
            BindStichingManPower(0, 0, 0, -1);
            BindRemarkGrd(0, 0, 0, -1);
            SetOBPermission();
        }

        protected void btnStichManPower_Click(object sender, EventArgs e)
        {
            // BindStichingOBGrid(0, 0, 0, -1);
            if (hdnGridFlag.Value == "1")
            {
                //BindStichingOBGrid(0, 0, 0, -1);
                hidelabel();
                hdnIsPopup.Value = "";
                showHidelable();
               // BindControl(0, 0, 0, -1);
               // bindStyleCode();
                //SetParameter();
                //lblGarment.Visible = true;
                //ddlGarment.Visible = true;
                BindSection(0, 0, 0, -1);
                //BindCuttingOB(0, 0, 0, -1);
                BindStichingOBGrid(0, 0, 0, -1);
                //BindFinishingOB(0, 0, 0, -1);
                // BindCuttingManPower(0, 0, 0, -1);
                //BindFinishingManPower(0, 0, 0, -1);
                BindStichingManPower(0, 0, 0, -1);
                //BindRemarkGrd(0, 0, 0, -1);
                //btnSubmit.Visible = true;
                //SetOBPermission();
                //CheckBoxEnable();
                FinalOBDone();
                if (iCheckCreateOB == 0)
                {
                    //if (iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.DesignationID == 19)
                    //    chkIsProductionGM.Enabled = true;
                    //else
                    //    chkIsProductionGM.Enabled = false;
                    if (iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.DesignationID == 44) // added by  shubhendu for check box enabled 
                        if (chkIsIEManager.Checked)
                        {
                            chkIsIEManager.Enabled = false;
                        }
                        else
                        {
                            chkIsIEManager.Enabled = true;
                        }
                    else
                        
                        chkIsIEManager.Enabled = false;
                    if (iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.DesignationID == 45)
                        if (chkIsIEManager.Checked)
                        {
                            chkIsFactoryIE.Enabled = false;
                        }
                        else
                        {
                            chkIsFactoryIE.Enabled = true;
                        }
                    else
                        chkIsFactoryIE.Enabled = false;
                }
            }
            if (hdnGridFlag.Value == "17")
            {
                BindFinishingOB(0, 0, 0, -1);
            }
            BindStichingManPower(0, 0, 0, -1);
        }


        protected void btnSubmit_Click(object sender, EventArgs e)
        {
          int GarmentTypeId = 0;
          GarmentTypeId = Convert.ToInt32(hdngarentType.Value);
          

          if (GarmentTypeId == -1)
          {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "scr", "alert('Please Select Garment Type');", true);
           
            return;
            
          }
            

          bool IsFactoryIE = Convert.ToBoolean(chkIsFactoryIE.Checked);
          //bool IsProductionGM = Convert.ToBoolean(chkIsProductionGM.Checked);
          //bool IsFactoryManager = Convert.ToBoolean(chkIsFactoryManager.Checked);
          bool IsIEManager = Convert.ToBoolean(chkIsIEManager.Checked);

          //int IsSaveSection = obj_OrderController.InsertSection(obj_OBForm, IsReuse, ReUseStyleId);
          int UserId = iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.UserID;
          int IsSave = obj_OrderController.UpdateCheckbox(styleid, IsFactoryIE, true, true, IsIEManager, UserId);

          SaveRemarks();

          // Add By Ravi kumar on 28/07/2015 create task for OB
          //bool iWorkClose;
          int iResult = 0;          
            if ((chkIsFactoryIE.Checked)  && (chkIsIEManager.Checked) )
            {
              // nikhil code for final ob
                iResult = obj_WorkFlowController.UpdateWorkflowInstancePostOrder_Style_Order_Basis(styleid, 0, TaskMode.Create_OB, ApplicationHelper.LoggedInUser.UserData.UserID);
                if (chkIsIEManager.Checked == true)
                {
                  if (iResult >= 0)
                  {
                    int  odid = OrderID;
                    //iResult = obj_WorkFlowController.UpdateWorkflowInstancePostOrder_Style_Order_Basis(styleid, OrderID, TaskMode.Final_OB, ApplicationHelper.LoggedInUser.UserData.UserID);
                    iResult = obj_WorkFlowController.UpdateWorkflowInstancePostOrder_Style_Order_Basis(styleid, odid, TaskMode.Final_OB, ApplicationHelper.LoggedInUser.UserData.UserID);
                  }
                    
                    //iResult = WorkflowControllerInstance.UpdateWorkflowInstancePostOrder_Style_Order_Basis(styleid, 0, TaskMode.HO_PPM, ApplicationHelper.LoggedInUser.UserData.UserID);
                }
            }
            else
            {             
              // for here OrderId = 0 as it is only depended on StyleId
                bool Bcheck = obj_WorkFlowController.IsCheckCreateOBInPre_Order(styleid);
               if(Bcheck==true)
               {
                   iResult = obj_WorkFlowController.UpdateWorkflowInstancePostOrder_Style_Order_Basis(styleid, 0, TaskMode.Create_OB, ApplicationHelper.LoggedInUser.UserData.UserID);
                   iResult = obj_WorkFlowController.UpdateWorkflowInstancePostOrder_Style_Order_Basis(styleid, 0, TaskMode.LIVE, ApplicationHelper.LoggedInUser.UserData.UserID);
               }
               else
               {
                    iResult = obj_WorkFlowController.UpdateWorkflowInstancePreOrder_ForCreateOB(styleid, 0, TaskMode.Create_OB, ApplicationHelper.LoggedInUser.UserData.UserID);

               }
                           
            }

          //}
          Page.ClientScript.RegisterStartupScript(Page.GetType(), "scr", "alert('Saved Successfully');", true);
          // End By Ravi kumar on 28/07/2015 create task for OB
          hdnIsPopup.Value = "";
          BindControl(0, 0, 0, -1);
          BindCuttingOB(0, 0, 0, -1);
          BindStichingOBGrid(0, 0, 0, -1);
          BindFinishingOB(0, 0, 0, -1);
          BindSection(0, 0, 0, -1);
          // BindCuttingManPower(0, 0, 0, -1);
          BindFinishingManPower(0, 0, 0, -1);
          BindStichingManPower(0, 0, 0, -1);
          BindRemarkGrd(0, 0, 0, -1);
          SetOBPermission();
          FinalOBDone();
          if (iCheckCreateOB == 0)
          {
              //if (iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.DesignationID == 19)
              //    chkIsProductionGM.Enabled = true;
              //else
              //    chkIsProductionGM.Enabled = false;
              if (iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.DesignationID == 44)
                  chkIsIEManager.Enabled = true;
              else
                  chkIsIEManager.Enabled = false;
              if (iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.DesignationID == 45)
                  chkIsFactoryIE.Enabled = true;
              else
                  chkIsFactoryIE.Enabled = false;
          }

        }



        protected void GrdCuttingManpower_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //Edite By Ashish
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Literal ltIndex = (Literal)e.Row.FindControl("ltIndex");
                ltIndex.Text = ((GrdCuttingManpower.PageIndex * GrdCuttingManpower.PageSize) + e.Row.RowIndex + 1).ToString();

                Label lblMachineCost = (Label)e.Row.FindControl("lblMachineCost");
                Label lblMachineSAM = (Label)e.Row.FindControl("lblMachineSAM");
                Label lblNos = (Label)e.Row.FindControl("lblNos");
                //Label lblgrdTotalfactor = (Label)e.Row.FindControl("lblgrdTotalfactor");
                Label txtFactor =(Label)e.Row.FindControl("txtFactor");

                if (lblMachineCost != null)
                {
                    if (lblMachineCost.Text == "")
                    {
                        lblMachineCost.Text = "0";
                    }
                    TotalManpowerCost = TotalManpowerCost + Convert.ToDouble(lblMachineCost.Text);


                }
                if (lblMachineSAM != null)
                {
                    if (lblMachineSAM.Text == "")
                    {
                        lblMachineSAM.Text = "0";
                    }
                    TotalManpowerSAM = TotalManpowerSAM + Convert.ToDouble(lblMachineSAM.Text);
                }

                if (lblNos != null)
                {
                    if (lblNos.Text == "")
                    {
                        lblNos.Text = "0";
                    }
                    TotalManpowerNos = TotalManpowerNos + Convert.ToDouble(lblNos.Text);
                }

                //-----------edit by prabhaker-------//
                if (lblgrdTotalfactor != null)
                {
                    if (lblgrdTotalfactor.Text == "")
                    {
                        lblgrdTotalfactor.Text = "0";
                    }
                    TotalgrdFact = TotalgrdFact + Convert.ToDouble(txtFactor.Text);

                }

                //----------end-of prabhaker--------------//

            }


            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label lblMachineCostTotal = (Label)e.Row.FindControl("lblMachineCostTotal");
                Label lblMachineSamTotal = (Label)e.Row.FindControl("lblMachineSamTotal");
                HiddenField hdnCuttingSamTotal = (HiddenField)e.Row.FindControl("hdnCuttingSamTotal");
                Label lblNosTotal = (Label)e.Row.FindControl("lblNosTotal");
                //TotalSam
                if (TotalManpowerCost != 0)
                {
                    lblMachineCostTotal.Text = TotalManpowerCost.ToString();
                }
                if (TotalManpowerSAM != 0)
                {
                    lblMachineSamTotal.Text = TotalManpowerSAM.ToString();
                    hdnCuttingSamTotal.Value = TotalManpowerSAM.ToString();
                    lblTotalCuttingSAM.Text = TotalManpowerSAM.ToString();
                }

                if (TotalManpowerNos != 0)
                {
                    lblNosTotal.Text = TotalManpowerNos.ToString();
                }
                if (TotalgrdFact != 0)
                {
                    lblgrdTotalfactor.Text = TotalgrdFact.ToString();
                }
                TotalgrdFact = 0;
                TotalManpowerCost = 0;
                TotalManpowerSAM = 0;
                TotalManpowerNos = 0;
            }
            //END
        }

        protected void GrdCuttingManpower_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GrdCuttingManpower.EditIndex = -1;
            CreateNew = 0;
            NewRefrence = 0;
            ReUse = 0;
            ReUseStyleId = -1;
            //BindCuttingManPower(CreateNew, NewRefrence, ReUse, ReUseStyleId);
        }

        //protected void GrdCuttingManpower_PageIndexChanging(object sender, GridViewPageEventArgs e)
        //{
        //    GrdCuttingManpower.PageIndex = e.NewPageIndex;
        //    GrdCuttingManpower.EditIndex = -1;
        //    CreateNew = 0;
        //    NewRefrence = 0;
        //    ReUse = 0;
        //    ReUseStyleId = -1;
        //    BindCuttingManPower(CreateNew, NewRefrence, ReUse, ReUseStyleId);
        //}

        protected void GrdCuttingManpower_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GrdCuttingManpower.EditIndex = e.NewEditIndex;

            CreateNew = 0;
            NewRefrence = 0;
            ReUse = 0;
            ReUseStyleId = -1;
            //BindCuttingManPower(CreateNew, NewRefrence, ReUse, ReUseStyleId);

        }



        protected void GrdFinishingManpower_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GrdFinishingManpower.EditIndex = -1;
            CreateNew = 0;
            NewRefrence = 0;
            ReUse = 0;
            ReUseStyleId = -1;
            BindFinishingManPower(CreateNew, NewRefrence, ReUse, ReUseStyleId);

        }

        protected void GrdFinishingManpower_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //Edite By Ashish
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Literal ltIndex = (Literal)e.Row.FindControl("ltIndex");
                ltIndex.Text = ((GrdFinishingManpower.PageIndex * GrdFinishingManpower.PageSize) + e.Row.RowIndex + 1).ToString();

                Label lblMachineCost = (Label)e.Row.FindControl("lblMachineCost");
                Label lblMachineSAM = (Label)e.Row.FindControl("lblMachineSAM");
                Label lblNoOfMachine = (Label)e.Row.FindControl("lblNoOfMachine");
                Label lblgrdTotalfactor = (Label)e.Row.FindControl("lblgrdTotalfactor");

                if (lblMachineCost != null)
                {
                    if (lblMachineCost.Text == "")
                    {
                        lblMachineCost.Text = "0";
                    }
                    TotalManpowerCost = TotalManpowerCost + Convert.ToDouble(lblMachineCost.Text);


                }
                if (lblMachineSAM != null)
                {
                    if (lblMachineSAM.Text == "")
                    {
                        lblMachineSAM.Text = "0";
                    }
                    TotalManpowerSAM = TotalManpowerSAM + Convert.ToDouble(lblMachineSAM.Text);
                }
                if (lblNoOfMachine != null)
                {
                    if (lblNoOfMachine.Text == "")
                    {
                        lblNoOfMachine.Text = "0";
                    }
                    TotalManpowerNos = TotalManpowerNos + Convert.ToDouble(lblNoOfMachine.Text);
                }

                //-----------edit by prabhaker-------//
                if (lblgrdTotalfactor != null)
                {
                    if (lblgrdTotalfactor.Text == "")
                    {
                        lblgrdTotalfactor.Text = "0";
                    }
                    TotalgrdFact = TotalgrdFact + Convert.ToDouble(lblgrdTotalfactor.Text);

                }

                //----------end-of prabhaker--------------//

            }


            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label lblMachineCostTotal = (Label)e.Row.FindControl("lblMachineCostTotal");
                Label lblMachineSamTotal = (Label)e.Row.FindControl("lblMachineSamTotal");
                HiddenField hdnFinishingSamTotal = (HiddenField)e.Row.FindControl("hdnFinishingSamTotal");
                Label lblNoOfMachineTotal = (Label)e.Row.FindControl("lblNoOfMachineTotal");
                //TotalSam
                if (TotalManpowerCost != 0)
                {
                    lblMachineCostTotal.Text = TotalManpowerCost.ToString();
                }
                if (TotalManpowerSAM != 0)
                {
                    lblMachineSamTotal.Text = TotalManpowerSAM.ToString();
                    hdnFinishingSamTotal.Value = TotalManpowerSAM.ToString();
                    lblTotalFinishingSAM.Text = TotalManpowerSAM.ToString();
                }
                if (TotalManpowerNos != 0)
                {
                    lblNoOfMachineTotal.Text = TotalManpowerNos.ToString();
                }
                if (TotalgrdFact != 0)
                {
                    lblgrdTotalfactor.Text = TotalgrdFact.ToString();
                }
                TotalgrdFact = 0;
                TotalManpowerCost = 0;
                TotalManpowerSAM = 0;
                TotalManpowerNos = 0;
            }
            //END
        }

        protected void GrdFinishingManpower_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GrdFinishingManpower.EditIndex = e.NewEditIndex;

            ReUse = 0;
            ReUseStyleId = -1;
            NewRefrence = 0;
            CreateNew = 0;
            BindFinishingManPower(CreateNew, NewRefrence, ReUse, ReUseStyleId);

        }


        //protected void GrdFinishingManpower_PageIndexChanging(object sender, GridViewPageEventArgs e)
        //{
        //    GrdFinishingManpower.PageIndex = e.NewPageIndex;
        //    GrdFinishingManpower.EditIndex = -1;

        //    ReUse = 0;
        //    ReUseStyleId = -1;
        //    NewRefrence = 0;
        //    CreateNew = 0;
        //    BindFinishingManPower(CreateNew, NewRefrence, ReUse, ReUseStyleId);

        //}


        protected void grdCuttingOB_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = grdCuttingOB.Rows[e.RowIndex];
            HiddenField hdnFinalCuttingOBID = (HiddenField)row.FindControl("hdnFinalCuttingOBID");
            string Flag = "Cutting";
            if (hdnFinalCuttingOBID != null)
            {
                int IsDelete = obj_OrderController.DeleteOBById(Convert.ToInt32(hdnFinalCuttingOBID.Value), Flag);
                grdCuttingOB.EditIndex = -1;

                ReUse = 0;
                ReUseStyleId = -1;
                NewRefrence = 0;
                CreateNew = 0;
                BindCuttingOB(CreateNew, NewRefrence, ReUse, ReUseStyleId);
                //BindCuttingManPower(CreateNew, NewRefrence, ReUse, ReUseStyleId);
            }
        }

        protected void grdStichingFront_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = grdStichingFront.Rows[e.RowIndex];
            HiddenField hdnFinalCuttingOBID = (HiddenField)row.FindControl("hdnFinalOBIdItem");
            string Flag = "Front";
            if (hdnFinalCuttingOBID != null)
            {
                int IsDelete = obj_OrderController.DeleteOBById(Convert.ToInt32(hdnFinalCuttingOBID.Value), Flag);
                grdStichingFront.EditIndex = -1;

                ReUse = 0;
                ReUseStyleId = -1;
                NewRefrence = 0;
                CreateNew = 0;
                //BindStichingFrontOB(CreateNew, NewRefrence, ReUse, ReUseStyleId);
                BindStichingOBGrid(CreateNew, NewRefrence, ReUse, ReUseStyleId);
                BindStichingManPower(CreateNew, NewRefrence, ReUse, ReUseStyleId);

            }
        }

        protected void grdStichingBack_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = grdStichingBack.Rows[e.RowIndex];
            HiddenField hdnFinalCuttingOBID = (HiddenField)row.FindControl("hdnFinalOBIdItem");
            string Flag = "back";
            if (hdnFinalCuttingOBID != null)
            {
                int IsDelete = obj_OrderController.DeleteOBById(Convert.ToInt32(hdnFinalCuttingOBID.Value), Flag);
                grdStichingBack.EditIndex = -1;
                ReUse = 0;
                ReUseStyleId = -1;
                NewRefrence = 0;
                CreateNew = 0;
                //BindStichingBackOB(CreateNew, NewRefrence, ReUse, ReUseStyleId);
                BindStichingOBGrid(CreateNew, NewRefrence, ReUse, ReUseStyleId);
                BindStichingManPower(CreateNew, NewRefrence, ReUse, ReUseStyleId);

            }
        }

        protected void grdStichingcoller_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = grdStichingcoller.Rows[e.RowIndex];
            HiddenField hdnFinalCuttingOBID = (HiddenField)row.FindControl("hdnFinalOBIdItem");
            string Flag = "coller";
            if (hdnFinalCuttingOBID != null)
            {
                int IsDelete = obj_OrderController.DeleteOBById(Convert.ToInt32(hdnFinalCuttingOBID.Value), Flag);
                grdStichingcoller.EditIndex = -1;
                ReUse = 0;
                ReUseStyleId = -1;
                NewRefrence = 0;
                CreateNew = 0;
                //BindStichingcollerOB(CreateNew, NewRefrence, ReUse, ReUseStyleId);
                BindStichingOBGrid(CreateNew, NewRefrence, ReUse, ReUseStyleId);
                BindStichingManPower(CreateNew, NewRefrence, ReUse, ReUseStyleId);

            }
        }

        protected void grdStichingsleep_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = grdStichingsleep.Rows[e.RowIndex];
            HiddenField hdnFinalCuttingOBID = (HiddenField)row.FindControl("hdnFinalOBIdItem");
            string Flag = "sleep";
            if (hdnFinalCuttingOBID != null)
            {
                int IsDelete = obj_OrderController.DeleteOBById(Convert.ToInt32(hdnFinalCuttingOBID.Value), Flag);
                grdStichingsleep.EditIndex = -1;
                ReUse = 0;
                ReUseStyleId = -1;
                NewRefrence = 0;
                CreateNew = 0;
                //BindStichingsleepOB(CreateNew, NewRefrence, ReUse, ReUseStyleId);
                BindStichingOBGrid(CreateNew, NewRefrence, ReUse, ReUseStyleId);
                BindStichingManPower(CreateNew, NewRefrence, ReUse, ReUseStyleId);

            }
        }

        protected void grdStichingneck_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = grdStichingneck.Rows[e.RowIndex];
            HiddenField hdnFinalCuttingOBID = (HiddenField)row.FindControl("hdnFinalOBIdItem");
            string Flag = "neck";
            if (hdnFinalCuttingOBID != null)
            {
                int IsDelete = obj_OrderController.DeleteOBById(Convert.ToInt32(hdnFinalCuttingOBID.Value), Flag);
                grdStichingneck.EditIndex = -1;
                ReUse = 0;
                ReUseStyleId = -1;
                NewRefrence = 0;
                CreateNew = 0;
                //BindStichingneckOB(CreateNew, NewRefrence, ReUse, ReUseStyleId);
                BindStichingOBGrid(CreateNew, NewRefrence, ReUse, ReUseStyleId);
                BindStichingManPower(CreateNew, NewRefrence, ReUse, ReUseStyleId);

            }
        }

        protected void grdStichingLining_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = grdStichingLining.Rows[e.RowIndex];
            HiddenField hdnFinalCuttingOBID = (HiddenField)row.FindControl("hdnFinalOBIdItem");
            string Flag = "Lining";
            if (hdnFinalCuttingOBID != null)
            {
                int IsDelete = obj_OrderController.DeleteOBById(Convert.ToInt32(hdnFinalCuttingOBID.Value), Flag);
                grdStichingLining.EditIndex = -1;
                ReUse = 0;
                ReUseStyleId = -1;
                NewRefrence = 0;
                CreateNew = 0;
                //BindStichingLiningOB(CreateNew, NewRefrence, ReUse, ReUseStyleId);
                BindStichingOBGrid(CreateNew, NewRefrence, ReUse, ReUseStyleId);
                BindStichingManPower(CreateNew, NewRefrence, ReUse, ReUseStyleId);

            }
        }

        protected void grdStichinglower_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = grdStichinglower.Rows[e.RowIndex];
            HiddenField hdnFinalCuttingOBID = (HiddenField)row.FindControl("hdnFinalOBIdItem");
            string Flag = "lower";
            if (hdnFinalCuttingOBID != null)
            {
                int IsDelete = obj_OrderController.DeleteOBById(Convert.ToInt32(hdnFinalCuttingOBID.Value), Flag);
                grdStichinglower.EditIndex = -1;

                ReUse = 0;
                ReUseStyleId = -1;
                NewRefrence = 0;
                CreateNew = 0;
                //BindStichinglowerOB(CreateNew, NewRefrence, ReUse, ReUseStyleId);
                BindStichingOBGrid(CreateNew, NewRefrence, ReUse, ReUseStyleId);
                BindStichingManPower(CreateNew, NewRefrence, ReUse, ReUseStyleId);

            }
        }

        protected void grdStichingbottom_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = grdStichingbottom.Rows[e.RowIndex];
            HiddenField hdnFinalCuttingOBID = (HiddenField)row.FindControl("hdnFinalOBIdItem");
            string Flag = "bottom";
            if (hdnFinalCuttingOBID != null)
            {
                int IsDelete = obj_OrderController.DeleteOBById(Convert.ToInt32(hdnFinalCuttingOBID.Value), Flag);
                grdStichingbottom.EditIndex = -1;

                ReUse = 0;
                ReUseStyleId = -1;
                NewRefrence = 0;
                CreateNew = 0;
                //BindStichingbottomOB(CreateNew, NewRefrence, ReUse, ReUseStyleId);
                BindStichingOBGrid(CreateNew, NewRefrence, ReUse, ReUseStyleId);
                BindStichingManPower(CreateNew, NewRefrence, ReUse, ReUseStyleId);

            }
        }

        protected void grdStichingassembly_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = grdStichingassembly.Rows[e.RowIndex];
            HiddenField hdnFinalCuttingOBID = (HiddenField)row.FindControl("hdnFinalOBIdItem");
            string Flag = "assembly";
            if (hdnFinalCuttingOBID != null)
            {
                int IsDelete = obj_OrderController.DeleteOBById(Convert.ToInt32(hdnFinalCuttingOBID.Value), Flag);
                grdStichingassembly.EditIndex = -1;
                ReUse = 0;
                ReUseStyleId = -1;
                NewRefrence = 0;
                CreateNew = 0;
                //BindStichingassemblyOB(CreateNew, NewRefrence, ReUse, ReUseStyleId);
                BindStichingOBGrid(CreateNew, NewRefrence, ReUse, ReUseStyleId);
                BindStichingManPower(CreateNew, NewRefrence, ReUse, ReUseStyleId);

            }
        }

        protected void grdFinishing_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = grdFinishing.Rows[e.RowIndex];
            HiddenField hdnFinalCuttingOBID = (HiddenField)row.FindControl("hdnFinalOBIdItem");
            string Flag = "Finishing";
            if (hdnFinalCuttingOBID != null)
            {
                int IsDelete = obj_OrderController.DeleteOBById(Convert.ToInt32(hdnFinalCuttingOBID.Value), Flag);
                grdFinishing.EditIndex = -1;
                ReUse = 0;
                ReUseStyleId = -1;
                NewRefrence = 0;
                CreateNew = 0;
                BindFinishingOB(CreateNew, NewRefrence, ReUse, ReUseStyleId);
                BindFinishingManPower(CreateNew, NewRefrence, ReUse, ReUseStyleId);

            }
        }

        protected void imgPlus_Click(object sender, EventArgs e)
        { //addde by abhishek on 10/9/2015 for new refrence--------------------//

            DataSet dsNewStyle = new DataSet();
            DataTable dt0 = new DataTable();
            DataTable dt1 = new DataTable();
            DataTable dt2 = new DataTable();
            DataTable dt3 = new DataTable();
            DataTable dt4 = new DataTable();
            DataTable dt5 = new DataTable();
            DataTable dt6 = new DataTable();
            DataTable dt7 = new DataTable();
            DataTable dt8 = new DataTable();
            DataTable dt9 = new DataTable();
            DataTable dt10 = new DataTable();
            DataTable dt11 = new DataTable();
            DataTable dt12 = new DataTable();
            DataTable dt13 = new DataTable();
            DataTable dt14 = new DataTable();
            DataTable dt15 = new DataTable();
            DataTable dt16 = new DataTable();
            DataTable dt17 = new DataTable();
            DataTable dt18 = new DataTable();
            DataTable dt19 = new DataTable();
            DataTable dt20 = new DataTable();

            DataTable dt21 = new DataTable();
            DataTable dt22 = new DataTable();
            DataTable dt23 = new DataTable();



            dt0 = null;
            dt1 = null;
            dt2 = null;
            dt3 = null;
            dt4 = null;
            dt5 = null;
            dt6 = null;
            dt7 = null;
            dt8 = null;
            dt9 = null;
            dt10 = null;
            dt11 = null;
            dt12 = null;
            dt13 = null;
            dt14 = null;
            dt15 = null;
            dt16 = null;
            dt17 = null;
            dt18 = null;
            dt19 = null;
            dt20 = null;
            dt21 = null;
            dt22 = null;
            dt23 = null;
            ShowGridPopup.Visible = false;
            foreach (RepeaterItem item in repCuttingStyleCode.Items)
            {
                ImageButton imgPlus = item.FindControl("imgPlus") as ImageButton;
                imgPlus.Attributes.Add("style", "display:inline");

                ImageButton imgMinus = item.FindControl("imgMinus") as ImageButton;
                imgMinus.Attributes.Add("style", "display:none");
            }
            ImageButton imgbtnPlus = (ImageButton)sender;
            RepeaterItem ritem = (RepeaterItem)imgbtnPlus.NamingContainer;

            ImageButton imgPlusthis = ritem.FindControl("imgPlus") as ImageButton;
            imgPlusthis.Attributes.Add("style", "display:none");

            ImageButton imgMinusthis = ritem.FindControl("imgMinus") as ImageButton;
            imgMinusthis.Attributes.Add("style", "display:inline");

            string StyleidNew = ((HiddenField)ritem.FindControl("rephdnStyleid")).Value;
            string StyleCodeNew = ((HiddenField)ritem.FindControl("hdnStyleCode")).Value;
            string GarmentType = ((HiddenField)ritem.FindControl("hdnRepGarmentType")).Value;
            int Garmentid = -1;
            ShowGridPopup.Visible = true;
            if (GarmentType != null)
            {
                if (GarmentType != "")
                {
                    Garmentid = Convert.ToInt32(GarmentType);
                }
            }

            if (StyleidNew != null)
            {

                dsNewStyle = obj_OrderController.GetAllOBData(Convert.ToInt32(StyleidNew), Garmentid);

                dt0 = dsNewStyle.Tables[0];
                dt1 = dsNewStyle.Tables[1];
                dt2 = dsNewStyle.Tables[2];
                dt3 = dsNewStyle.Tables[3];
                dt4 = dsNewStyle.Tables[4];
                dt5 = dsNewStyle.Tables[5];
                dt6 = dsNewStyle.Tables[6];
                dt7 = dsNewStyle.Tables[7];
                dt8 = dsNewStyle.Tables[8];
                dt9 = dsNewStyle.Tables[9];
                dt10 = dsNewStyle.Tables[10];
                dt11 = dsNewStyle.Tables[11];
                dt12 = dsNewStyle.Tables[12];
                dt13 = dsNewStyle.Tables[13];
                dt14 = dsNewStyle.Tables[14];
                dt15 = dsNewStyle.Tables[15];
                dt16 = dsNewStyle.Tables[16];
                dt17 = dsNewStyle.Tables[17];
                dt18 = dsNewStyle.Tables[18];

                dt19 = dsNewStyle.Tables[19];
                dt20 = dsNewStyle.Tables[20];
                dt21 = dsNewStyle.Tables[21];
                dt22 = dsNewStyle.Tables[22];
                //if (dt0.Rows.Count > 0)
                //{
                div1.Visible = true;
                grdOBCutting.DataSource = dt0;
                grdOBCutting.DataBind();
                //}
                trTotalStitch.Visible = true;
                if (dt1.Rows.Count > 0)
                {
                    div2.Visible = true;
                    grdOBFront.DataSource = dt1;
                    grdOBFront.DataBind();
                }
                if (dt2.Rows.Count > 0)
                {
                    div3.Visible = true;
                    grdOBBack.DataSource = dt2;
                    grdOBBack.DataBind();
                }
                if (dt3.Rows.Count > 0)
                {
                    div4.Visible = true;
                    grdOBcoller.DataSource = dt3;
                    grdOBcoller.DataBind();
                }
                if (dt4.Rows.Count > 0)
                {
                    div5.Visible = true;
                    grdOBsleep.DataSource = dt4;
                    grdOBsleep.DataBind();
                }
                if (dt5.Rows.Count > 0)
                {
                    div6.Visible = true;
                    grdOBneck.DataSource = dt5;
                    grdOBneck.DataBind();
                }
                if (dt6.Rows.Count > 0)
                {
                    div7.Visible = true;
                    grdOBLining.DataSource = dt6;
                    grdOBLining.DataBind();
                }
                if (dt7.Rows.Count > 0)
                {
                    div8.Visible = true;
                    grdOBlower.DataSource = dt7;
                    grdOBlower.DataBind();
                }
                if (dt8.Rows.Count > 0)
                {
                    div9.Visible = true;
                    grdOBbottom.DataSource = dt8;
                    grdOBbottom.DataBind();
                }
                if (dt9.Rows.Count > 0)
                {
                    div10.Visible = true;
                    grdOBassembly.DataSource = dt9;
                    grdOBassembly.DataBind();
                }

                if (dt10.Rows.Count > 0)
                {
                    div12.Visible = true;
                    grdOBpiping.DataSource = dt10;
                    grdOBpiping.DataBind();
                }

                if (dt11.Rows.Count > 0)
                {
                    div13.Visible = true;
                    grdOBUpper.DataSource = dt11;
                    grdOBUpper.DataBind();
                }

                if (dt12.Rows.Count > 0)
                {
                    div14.Visible = true;
                    grdOBUppershell.DataSource = dt12;
                    grdOBUppershell.DataBind();
                }


                if (dt13.Rows.Count > 0)
                {
                    div15.Visible = true;
                    grdOBLowershell.DataSource = dt13;
                    grdOBLowershell.DataBind();
                }

                if (dt14.Rows.Count > 0)
                {
                    div16.Visible = true;
                    grdOBShellsection.DataSource = dt14;
                    grdOBShellsection.DataBind();
                }

                if (dt15.Rows.Count > 0)
                {
                    div17.Visible = true;
                    grdOBWaistsection.DataSource = dt15;
                    grdOBWaistsection.DataBind();
                }

                if (dt16.Rows.Count > 0)
                {
                    div18.Visible = true;
                    grdOBBandsection.DataSource = dt16;
                    grdOBBandsection.DataBind();
                }

                if (dt17.Rows.Count > 0)
                {
                    div11.Visible = true;
                    trTotalFinish.Visible = true;
                    grdOBFinishing.DataSource = dt17;
                    grdOBFinishing.DataBind();
                }



                //For grd New Neck
                if (dt18.Rows.Count > 0)
                {
                    div22.Visible = true;
                    grdNewNeck.DataSource = dt18;
                    grdNewNeck.DataBind();
                }

                //For grd New facing
                if (dt19.Rows.Count > 0)
                {
                    div25.Visible = true;
                    grdNeckFacingref.DataSource = dt19;
                    grdNeckFacingref.DataBind();
                    
                }
                if (dt20.Rows.Count > 0)
                {
                    div24.Visible = true;
                    grdfrontbackref.DataSource = dt20;
                    grdfrontbackref.DataBind();
                }

                //For Stitch Man Power
                if (dt21.Rows.Count > 0)
                {
                    div19.Visible = true;
                    grdOBManPower.DataSource = dt21;
                    grdOBManPower.DataBind();
                }


                //For Stitch Finishing
                if (dt22.Rows.Count > 0)
                {
                    div20.Visible = true;
                    grdOBFinishingManPower.DataSource = dt22;
                    grdOBFinishingManPower.DataBind();
                }

                ////end by abhishek on 10/9/2015 for new refrence-------------------------//

            }
        }

        protected void imgMinus_Click(object sender, EventArgs e)
        {
            ShowGridPopup.Visible = false;
            foreach (RepeaterItem item in repCuttingStyleCode.Items)
            {
                ImageButton imgPlus = item.FindControl("imgPlus") as ImageButton;
                imgPlus.Attributes.Add("style", "display:inline");

                ImageButton imgMinus = item.FindControl("imgMinus") as ImageButton;
                imgMinus.Attributes.Add("style", "display:none");
            }
            ImageButton imgbtnPlus = (ImageButton)sender;
            RepeaterItem ritem = (RepeaterItem)imgbtnPlus.NamingContainer;

            ImageButton imgPlusthis = ritem.FindControl("imgPlus") as ImageButton;
            imgPlusthis.Attributes.Add("style", "display:inline");

            ImageButton imgMinusthis = ritem.FindControl("imgMinus") as ImageButton;
            imgMinusthis.Attributes.Add("style", "display:none");
        }



        protected void BindCuttingManPower(int CreateNew, int NewRefrence, int ReUse, int ReUseStyleId)
        {
            //CreateNew = 0;
            //IsReUse = 0;
            //ReUseStyleId = -1;
            //NewRefrence = 0;
            //ReUseStyleNumber = hdnReUseStyleNumber.Value;

            DataTable dtManpower = new DataTable();
            int Garmentid = Convert.ToInt32(ddlGarment.SelectedValue);
            dtManpower = obj_OrderController.GetManPower(styleid, Garmentid, "Cutting", obj_OBForm.StyleCode, ReUse, ReUseStyleId, NewRefrence);
            GrdCuttingManpower.DataSource = dtManpower;
            GrdCuttingManpower.DataBind();
            hdnCuttingCount.Value = dtManpower.Rows.Count.ToString();
            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "GetCuttingTotal", "GetCuttingTotal();", true);
        }

        protected void BindFinishingManPower(int CreateNew, int NewRefrence, int ReUse, int ReUseStyleId)
        {
            //CreateNew = 0;
            //IsReUse = 0;
            //ReUseStyleId = -1;
            //NewRefrence = 0;
            //ReUseStyleNumber = hdnReUseStyleNumber.Value;

            DataTable dtManpower = new DataTable();
            int Garmentid = Convert.ToInt32(ddlGarment.SelectedValue);
            dtManpower = obj_OrderController.GetManPower(styleid, Garmentid, "Finishing", obj_OBForm.StyleCode, ReUse, ReUseStyleId, NewRefrence);
            GrdFinishingManpower.DataSource = dtManpower;
            GrdFinishingManpower.DataBind();
            hdnFinishingCount.Value = dtManpower.Rows.Count.ToString();
            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "GetFinishingTotal", "GetFinishingTotal();", true);
        }
        protected void BindStichingManPower(int CreateNew, int NewRefrence, int ReUse, int ReUseStyleId)
        {
            //CreateNew = 0;
            //IsReUse = 0;
            //ReUseStyleId = -1;
            //NewRefrence = 0;
            //ReUseStyleNumber = hdnReUseStyleNumber.Value;

            DataTable dtManpower = new DataTable();
            int Garmentid = Convert.ToInt32(ddlGarment.SelectedValue);
            dtManpower = obj_OrderController.GetManPower(styleid, Garmentid, "Stiching", obj_OBForm.StyleCode, ReUse, ReUseStyleId, NewRefrence);
            GrdStichingManPower.DataSource = dtManpower;
            GrdStichingManPower.DataBind();
            hdnStitchCount.Value = dtManpower.Rows.Count.ToString();
            if (machinecalc != 0)
            {
                lblTotalmachineCount.Text = machinecalc.ToString();
                machinecalc = 0;
            }
            //if (ViewState["machinecalc"] != null)
            //{
            //    lblTotalmachineCount.Text = ViewState["machinecalc"].ToString();
            //}
            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "GetStitchTotal", "GetStitchTotal();", true);
            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "GetmachineTotal", "GetmachineTotal();", true);
            //if (ViewState["SFactor"] != null)
            //{
            //    lblgrdTotalfactor.Text = ViewState["SFactor"].ToString();
            //}

        }

        protected void GrdStichingManPower_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //Edite By Ashish
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Literal ltIndex = (Literal)e.Row.FindControl("ltIndex");
                ltIndex.Text = ((GrdStichingManPower.PageIndex * GrdStichingManPower.PageSize) + e.Row.RowIndex + 1).ToString();

                Label lblMachineCost = (Label)e.Row.FindControl("lblMachineCost");
                Label lblMachineSAM = (Label)e.Row.FindControl("lblMachineSAM");
                Label lblNoOfMachine = (Label)e.Row.FindControl("lblNoOfMachine");
                Label lblmachinecalc = (Label)e.Row.FindControl("lblmachinecalc");
                Label lblmachineFact = (Label)e.Row.FindControl("lblmachineFact");

                int cnt = DataBinder.Eval(e.Row.DataItem, "cnt") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "cnt"));


               // double machinecalc = 0 ;
                if (lblMachineCost != null)
                {
                    if (lblMachineCost.Text == "")
                    {
                        lblMachineCost.Text = "0";
                    }
                    TotalManpowerCost = TotalManpowerCost + Convert.ToDouble(lblMachineCost.Text);
                }
                //-----------edit by prabhaker-------//
                //if (lblgrdTotalfactor != null)
                //{
                //    if (lblgrdTotalfactor.Text == "")
                //    {
                //        lblgrdTotalfactor.Text = "0";
                //    }
                //    TotalgrdFact = TotalgrdFact + Convert.ToDouble(lblgrdTotalfactor.Text);

                //}


                if (lblmachineFact != null)
                {
                    if (lblmachineFact.Text == "")
                    {
                        lblmachineFact.Text = "0";
                    }
                    SFactor = SFactor + Convert.ToDouble(lblmachineFact.Text);
                    SCnt = SCnt + cnt;
                    //lblTotalmachineCount.Text = machinecalc.ToString();
                    ViewState["SFactor"] = SFactor;


                }
                //SFactor=SFactor/cou

                //----------end-of prabhaker--------------//

                if (lblmachinecalc != null)
                {
                    if (lblmachinecalc.Text == "")
                    {
                        lblmachinecalc.Text = "0";
                    }
                    machinecalc = machinecalc + Convert.ToDouble(lblmachinecalc.Text);
                    //lblTotalmachineCount.Text = machinecalc.ToString();
                    //ViewState["machinecalc"] = machinecalc;


                }


                if (lblMachineSAM != null)
                {
                    if (lblMachineSAM.Text == "")
                    {
                        lblMachineSAM.Text = "0";
                    }
                    TotalManpowerSAM = TotalManpowerSAM + Convert.ToDouble(lblMachineSAM.Text);
                }

                if (lblNoOfMachine != null)
                {
                    if (lblNoOfMachine.Text == "")
                    {
                        lblNoOfMachine.Text = "0";
                    }
                    TotalManpowerNos = TotalManpowerNos + Convert.ToDouble(lblNoOfMachine.Text);
                }

            }


            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label lblMachineCostTotal = (Label)e.Row.FindControl("lblMachineCostTotal");
                Label lblMachineSamTotal = (Label)e.Row.FindControl("lblMachineSamTotal");
                Label lblNoOfMachineTotal = (Label)e.Row.FindControl("lblNoOfMachineTotal");
                HiddenField hdnStitchSamTotal = (HiddenField)e.Row.FindControl("hdnStitchSamTotal");
                HiddenField hdnmachineTotal = (HiddenField)e.Row.FindControl("hdnmachineTotal");
                HiddenField machinecalchdn = (HiddenField)e.Row.FindControl("hdnmachinecalc");
                //Label lblgrdTotalfactor = (Label)e.Row.FindControl("lblgrdTotalfactor");
                HiddenField hdnfactorTotal = (HiddenField)e.Row.FindControl("hdnfactorTotal");
                

                //TotalSam
                if (TotalManpowerCost != 0)
                {
                    lblMachineCostTotal.Text = TotalManpowerCost.ToString();
                }
                if (TotalManpowerSAM != 0)
                {
                    lblMachineSamTotal.Text = TotalManpowerSAM.ToString();
                    hdnStitchSamTotal.Value = TotalManpowerSAM.ToString();
                    hdnmachineTotal.Value = TotalManpowerNos.ToString();
                    lblTotalStitchingSam.Text = TotalManpowerSAM.ToString();
                    
                }

                if (machinecalc != 0)
                {
                    machinecalchdn.Value = machinecalc.ToString();  //ViewState["machinecalc"].ToString(); //machinecalc.ToString();                   
                }
                if (TotalManpowerNos != 0)
                {
                    lblNoOfMachineTotal.Text = TotalManpowerNos.ToString();
                    lblTotalManaulCount.Text = TotalManpowerNos.ToString();
                }

                //-----------edit by prabhaker-------//
                if (SFactor != 0)
                {
                    hdnfactorTotal.Value = Math.Round((Convert.ToDecimal(SFactor) / Convert.ToDecimal(SCnt)), 2).ToString();
                    lblgrdTotalfactor.Text = Math.Round((Convert.ToDecimal(SFactor) / Convert.ToDecimal(SCnt)), 2).ToString();
                    SFactor = 0;
                    SCnt = 0;
                    //int TottalRowsCount = GrdStichingManPower.Rows.Count;
                    //lblgrdTotalfactor.Text = Math.Round((Convert.ToDecimal(SFactor) / Convert.ToDecimal(SCnt)), 2).ToString();
                    //ViewState["SFactor"] = lblgrdTotalfactor.Text;
                }

                //if (grdFactTotal != 0)
                //{
                //    machinecalchdn.Value = machinecalc.ToString();
                //}
                //if (TotalgrdFact != 0)
                //{
                //    lblgrdTotalfactor.Text = TotalgrdFact.ToString();

                //}
                SFactor = 0;
                //---------end of prabhaker code-------------//

                TotalManpowerCost = 0;
                TotalManpowerSAM = 0;
                TotalManpowerNos = 0;
            }
            //END
        }

        //protected void GrdStichingManPower_PageIndexChanging(object sender, GridViewPageEventArgs e)
        //{
        //    GrdStichingManPower.PageIndex = e.NewPageIndex;
        //    GrdStichingManPower.EditIndex = -1;
        //    BindStichingManPower(0, 0, 0, -1);
        //}



        protected void BindRemarkGrd(int CreateNew, int NewRefrence, int ReUse, int ReUseStyleId)
        {
            DataSet dsgrd = new DataSet();
            //IsCreate = Convert.ToInt32(hdnCreateNew.Value);
            //IsReUse = 0;
            //ReUseStyleId = -1;
            //NewRefrence = 0;

            //if (ViewState["datatable"] == null)
            //{
            //    dsgrd = obj_OrderController.GetOBRemarks(obj_OBForm.StyleCode, styleid, obj_OBForm.ClientID, obj_OBForm.DeptId, IsCreate, NewRefrence, IsReUse, ReUseStyleId);
            //    grdOBkRemarks.DataSource = dsgrd.Tables[0];
            //    grdOBkRemarks.DataBind();
            //    ViewState["datatable"] = dsgrd.Tables[0];
            //}
            //else
            //{
            //    DataTable dtnew = (DataTable)(ViewState["datatable"]);
            //    grdOBkRemarks.DataSource = dtnew;
            //    grdOBkRemarks.DataBind();
            //    ViewState["datatable"] = dtnew;
            //}


            if (CreateNew == 1)
            {
                dsgrd = obj_OrderController.GetOBRemarks(obj_OBForm.StyleCode, styleid, obj_OBForm.ClientID, obj_OBForm.DeptId, CreateNew, NewRefrence, ReUse, ReUseStyleId);
                grdOBkRemarks.DataSource = dsgrd.Tables[0];
                grdOBkRemarks.DataBind();
                ViewState["datatable"] = dsgrd.Tables[0];

            }
            else if (NewRefrence == 1)
            {
                dsgrd = obj_OrderController.GetOBRemarks(obj_OBForm.StyleCode, styleid, obj_OBForm.ClientID, obj_OBForm.DeptId, CreateNew, NewRefrence, ReUse, ReUseStyleId);
                grdOBkRemarks.DataSource = dsgrd.Tables[0];
                grdOBkRemarks.DataBind();
                ViewState["datatable"] = dsgrd.Tables[0];
            }
            else if (ReUse == 1)
            {
                dsgrd = obj_OrderController.GetOBRemarks(obj_OBForm.StyleCode, styleid, obj_OBForm.ClientID, obj_OBForm.DeptId, CreateNew, NewRefrence, ReUse, ReUseStyleId);
                grdOBkRemarks.DataSource = dsgrd.Tables[0];
                grdOBkRemarks.DataBind();
                ViewState["datatable"] = dsgrd.Tables[0];

            }
            else
            {
                if (ViewState["datatable"] == null)
                {
                    dsgrd = obj_OrderController.GetOBRemarks(obj_OBForm.StyleCode, styleid, obj_OBForm.ClientID, obj_OBForm.DeptId, CreateNew, NewRefrence, ReUse, ReUseStyleId);
                    grdOBkRemarks.DataSource = dsgrd.Tables[0];
                    grdOBkRemarks.DataBind();
                    ViewState["datatable"] = dsgrd.Tables[0];

                }
                else
                {
                    DataTable dtnew = (DataTable)(ViewState["datatable"]);
                    grdOBkRemarks.DataSource = dtnew;
                    grdOBkRemarks.DataBind();
                    ViewState["datatable"] = dtnew;

                }
            }


        }

        protected void BindOBMsg(int CreateNew, int NewRefrence, int ReUse, int ReUseStyleId)
        {
            DataSet dsgrd = new DataSet();
            if (ViewState["datatable"] == null)
            {
                dsgrd = obj_OrderController.GetOBRemarks(obj_OBForm.StyleCode, styleid, obj_OBForm.ClientID, obj_OBForm.DeptId, CreateNew, NewRefrence, ReUse, ReUseStyleId);
                grdOBkRemarks.DataSource = dsgrd.Tables[0];
                grdOBkRemarks.DataBind();
                ViewState["datatable"] = dsgrd.Tables[0];

            }
            else
            {
                DataTable dtnew = (DataTable)(ViewState["datatable"]);
                grdOBkRemarks.DataSource = dtnew;
                grdOBkRemarks.DataBind();
                ViewState["datatable"] = dtnew;

            }
        }

        protected void grdOBkRemarks_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string Username = iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.FirstName;
            //string[] name = Username.Split('@');
            string date = DateTime.Now.ToString("dd MMM yyyy");
            if (e.CommandName == "Insert")
            {
                TextBox txtRemarkFooter = grdOBkRemarks.FooterRow.FindControl("txtRemarkFooter") as TextBox;
                LinkButton abtnAdd = grdOBkRemarks.FooterRow.FindControl("abtnAdd") as LinkButton;
                DataTable dtnew = new DataTable();
                string Remark = txtRemarkFooter.Text.Trim();
                int GarmentId = Convert.ToInt32(ddlGarment.SelectedValue);
                if (Remark == "")
                {
                    ShowAlert("Please Enter Remarks");
                    return;
                }
                else
                {
                    if (ViewState["datatable"] != null)
                    {
                        dtnew = (DataTable)(ViewState["datatable"]);
                        for (int i = 0; i < grdOBkRemarks.Rows.Count; i++)
                        {
                            dtnew.Rows[i]["Remarks"] = ((TextBox)grdOBkRemarks.Rows[i].FindControl("txtRemarkEdit")).Text;
                        }
                        dtnew.AcceptChanges();
                        sl = dtnew.Rows.Count;
                        dtnew.Rows.Add(sl + 1, styleid, "", obj_OBForm.ClientID, obj_OBForm.DeptId, GarmentId, Username + "(" + date + "): ", Remark, sl + 1);
                        ViewState["datatable"] = dtnew;
                    }
                    //if (ViewState["datatable"] != null)
                    //{
                    //    dtnew = (DataTable)(ViewState["datatable"]);
                    //    sl = dtnew.Rows.Count;
                    //    dtnew.Rows.Add(sl + 1, styleid, hdnStyleCode.Value, obj_OBForm.ClientID, obj_OBForm.DeptId, GarmentId, name[0] + "(" + date + "): ", Remark, sl + 1);
                    //    ViewState["datatable"] = dtnew;
                    //}
                }
                BindOBMsg(0, 0, 0, -1);
            }
            if (e.CommandName == "addnew")
            {

                Table tblGrdviewApplet = (Table)grdOBkRemarks.Controls[0];
                GridViewRow rows = (GridViewRow)tblGrdviewApplet.Controls[0];
                TextBox txtRemarksEmpty = (TextBox)rows.FindControl("txtRemarksEmpty");
                string Remark = txtRemarksEmpty.Text.Trim();
                int GarmentId = Convert.ToInt32(ddlGarment.SelectedValue);

                DataTable dtnew = new DataTable();
                if (Remark == "")
                {
                    ShowAlert("Please Enter Remarks");
                    return;
                }
                else
                {
                    if (ViewState["datatable"] != null)
                    {
                        dtnew = (DataTable)(ViewState["datatable"]);
                        for (int i = 0; i < grdOBkRemarks.Rows.Count; i++)
                        {
                            dtnew.Rows[i]["Remarks"] = ((TextBox)grdOBkRemarks.Rows[i].FindControl("txtRemarkEdit")).Text;
                        }
                        dtnew.AcceptChanges();
                        sl = dtnew.Rows.Count;
                        dtnew.Rows.Add(sl + 1, styleid, "", obj_OBForm.ClientID, obj_OBForm.DeptId, GarmentId, Username + "(" + date + "): ", Remark, sl + 1);
                        ViewState["datatable"] = dtnew;
                    }
                }
                BindOBMsg(0, 0, 0, -1);
            }
        }
        protected void grdOBkRemarks_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Literal ltIndex = (Literal)e.Row.FindControl("ltIndex");
                ltIndex.Text = ((grdOBkRemarks.PageIndex * grdOBkRemarks.PageSize) + e.Row.RowIndex + 1).ToString();
                TextBox txtRemarkEdit = (TextBox)e.Row.FindControl("txtRemarkEdit");
                LinkButton lnkDelete = (LinkButton)e.Row.FindControl("lnkDelete");

                if ((chkIsFactoryIE.Checked) && (chkIsIEManager.Checked))
                {
                    lnkDelete.Attributes.Add("style", "display:none;");
                    txtRemarkEdit.Enabled = false;
                }

            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                TextBox txtRemarkFooter = (TextBox)e.Row.FindControl("txtRemarkFooter");
                LinkButton abtnAdd = (LinkButton)e.Row.FindControl("abtnAdd");
                if ((chkIsFactoryIE.Checked) && (chkIsIEManager.Checked))
                {
                    txtRemarkFooter.Enabled = false;
                    abtnAdd.Attributes.Add("style", "display:none;");
                }
            }
            if (e.Row.RowType == DataControlRowType.EmptyDataRow)
            {
                TextBox txtRemarksEmpty = (TextBox)e.Row.FindControl("txtRemarksEmpty");
                LinkButton addbutton = (LinkButton)e.Row.FindControl("addbutton");
                if ((chkIsFactoryIE.Checked) && (chkIsIEManager.Checked))
                {
                    txtRemarksEmpty.Enabled = false;
                    addbutton.Attributes.Add("style", "display:none;");
                }
            }
        }
        protected void grdOBkRemarks_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = grdOBkRemarks.Rows[e.RowIndex];
            HiddenField hdndataTableId = (HiddenField)row.FindControl("hdndataTableId");
            HiddenField hdnRiskFabricId = (HiddenField)row.FindControl("hdnRiskFabricId");
            DataTable dtnew = new DataTable();

            if (ViewState["datatable"] != null)
            {
                dtnew = (DataTable)(ViewState["datatable"]);
                if (hdnRiskFabricId.Value != "")
                {
                    dtnew.Rows.Remove(dtnew.Select("RemarkId=" + hdnRiskFabricId.Value)[0]);
                    int IsDelete = obj_OrderController.DeleteOBRemarkById(Convert.ToInt32(hdnRiskFabricId.Value));
                }
                else
                {
                    dtnew.Rows.Remove(dtnew.Select("RiskFabricId=" + hdndataTableId.Value)[0]);
                }
                ViewState["datatable"] = dtnew;
            }


            grdOBkRemarks.EditIndex = -1;
            BindRemarkGrd(0, 0, 0, -1);

        }
        protected void grdOBkRemarks_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }
        protected void SaveRemarks()
        {
            RiskAnalysisOB objRisk = new RiskAnalysisOB();

            CreateNew = 0;
            ReUse = 0;
            ReUseStyleId = -1;
            NewRefrence = 0;
            ReUseStyleNumber = hdnReUseStyleNumber.Value;

            int UserId = iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.UserID;
            int RiskFabricId = 0;
            int StyleSequence = 0;

            int IsDelete = obj_OrderController.DeleteOBRemarkByStyleId(styleid);

            Control control = null;
            control = grdOBkRemarks.Controls[0].Controls[0];
            if ((TextBox)control.FindControl("txtRemarksEmpty") != null)
            {
                TextBox txtRemarksEmpty = (TextBox)control.FindControl("txtRemarksEmpty");
                string RemarksEmpty = txtRemarksEmpty.Text.Trim();
                RiskFabricId = 0;
                StyleSequence = 0;
                if (RemarksEmpty != null)
                {
                    if (RemarksEmpty != "")
                    {
                        int isave = obj_OrderController.InsertupdateOBRemarksDetails(obj_OBForm.StyleCode, styleid, obj_OBForm.ClientID, obj_OBForm.DeptId, CreateNew, NewRefrence, ReUse, ReUseStyleId, RemarksEmpty, RiskFabricId, StyleSequence, UserId);
                    }
                }
            }
            else
            {

                for (int i = 0; i < grdOBkRemarks.Rows.Count; i++)
                {
                    TextBox RemarkEdit = (TextBox)grdOBkRemarks.Rows[i].FindControl("txtRemarkEdit");
                    HiddenField hdnRiskFabricId = (HiddenField)grdOBkRemarks.Rows[i].FindControl("hdnRiskFabricId");
                    HiddenField hdnStyleSequence = (HiddenField)grdOBkRemarks.Rows[i].FindControl("hdnStyleSequence");
                    string Remark = RemarkEdit.Text.Trim();
                    if (hdnRiskFabricId != null)
                    {
                        if (hdnRiskFabricId.Value == "")
                        {
                            RiskFabricId = 0;
                        }
                        else
                        {
                            RiskFabricId = Convert.ToInt32(hdnRiskFabricId.Value);
                        }
                    }
                    if (hdnStyleSequence.Value == "")
                    {
                        StyleSequence = 0;
                    }
                    else
                    {
                        StyleSequence = Convert.ToInt32(hdnStyleSequence.Value);
                    }
                    if (Remark != null)
                    {
                        if (Remark != "")
                        {
                            int isave = obj_OrderController.InsertupdateOBRemarksDetails(obj_OBForm.StyleCode, styleid, obj_OBForm.ClientID, obj_OBForm.DeptId, CreateNew, NewRefrence, ReUse, ReUseStyleId, Remark, RiskFabricId, StyleSequence, UserId);
                        }
                    }
                }
                var footerRow = grdOBkRemarks.FooterRow;
                if (footerRow != null)
                {
                    TextBox txtRemarkFooter = (TextBox)footerRow.FindControl("txtRemarkFooter");
                    string RemarkFooter = txtRemarkFooter.Text.Trim();
                    RiskFabricId = 0;
                    StyleSequence = 0;
                    if (RemarkFooter != null)
                    {
                        if (RemarkFooter != "")
                        {
                            int isave = obj_OrderController.InsertupdateOBRemarksDetails(obj_OBForm.StyleCode, styleid, obj_OBForm.ClientID, obj_OBForm.DeptId, CreateNew, NewRefrence, ReUse, ReUseStyleId, RemarkFooter, RiskFabricId, StyleSequence, UserId);
                        }
                    }
                }
            }
            int SaveData = obj_OrderController.ReuseOBRemarks(styleid, ReUse, UserId);
            //if (ReUse == 1)
            //{
            //    int SaveData = obj_OrderController.ReuseOBRemarks(styleid, ReUse, UserId);
            //}

            ViewState["datatable"] = null;
            //BindRemarkGrd();
        }

        protected void lstSection_SelectedIndexChanged(object sender, EventArgs e)
        {
            // int TableId=lstSection.s
            btnSubmit.Enabled = true;
            btnSubmit.Attributes.Remove("disabled");
        }


        protected void gvOBMO_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType != DataControlRowType.DataRow)
                return;
            OrderDetail od = (e.Row.DataItem as OrderDetail);
            Label lblFabric1 = e.Row.FindControl("lblFabric1") as Label;
            Label lblFabric2 = e.Row.FindControl("lblFabric2") as Label;
            Label lblFabric3 = e.Row.FindControl("lblFabric3") as Label;
            Label lblFabric4 = e.Row.FindControl("lblFabric4") as Label;
            Label Fabric1Percent = e.Row.FindControl("lblFabric1Percent") as Label;
            Label Fabric2Percent = e.Row.FindControl("lblFabric2Percent") as Label;
            Label Fabric3Percent = e.Row.FindControl("lblFabric3Percent") as Label;
            Label Fabric4Percent = e.Row.FindControl("lblFabric4Percent") as Label;

            Label lblFabric1DetailsRef = e.Row.FindControl("lblFabric1DetailsRef") as Label;
            Label lblFabric2DetailsRef = e.Row.FindControl("lblFabric2DetailsRef") as Label;
            Label lblFabric3DetailsRef = e.Row.FindControl("lblFabric3DetailsRef") as Label;
            Label lblFabric4DetailsRef = e.Row.FindControl("lblFabric4DetailsRef") as Label;

            Label lblFabricStartETAdate1 = e.Row.FindControl("lblFabricStartETAdate1") as Label;
            Label lblFabricEndETAdate1 = e.Row.FindControl("lblFabricEndETAdate1") as Label;
            Label lblFabricStartETAdate2 = e.Row.FindControl("lblFabricStartETAdate2") as Label;
            Label lblFabricEndETAdate2 = e.Row.FindControl("lblFabricEndETAdate2") as Label;
            Label lblFabricStartETAdate3 = e.Row.FindControl("lblFabricStartETAdate3") as Label;
            Label lblFabricEndETAdate3 = e.Row.FindControl("lblFabricEndETAdate3") as Label;
            Label lblFabricStartETAdate4 = e.Row.FindControl("lblFabricStartETAdate4") as Label;
            Label lblFabricEndETAdate4 = e.Row.FindControl("lblFabricEndETAdate4") as Label;

            HtmlTableRow tbl1 = (HtmlTableRow)e.Row.FindControl("tbl1");
            HtmlTableRow tbl2 = (HtmlTableRow)e.Row.FindControl("tbl2");
            HtmlTableRow tbl3 = (HtmlTableRow)e.Row.FindControl("tbl3");
            HtmlTableRow tbl4 = (HtmlTableRow)e.Row.FindControl("tbl4");

            Label lvlCutReady = e.Row.FindControl("lvlCutReady") as Label;
            Label lblCutPercentInhouse = e.Row.FindControl("lblCutPercentInhouse") as Label;
            Label lblStitched = e.Row.FindControl("lblStitched") as Label;
            Label lblStitchedPercentInhouse = e.Row.FindControl("lblStitchedPercentInhouse") as Label;
            Label lvlVA = e.Row.FindControl("lvlVA") as Label;
            Label lblVAPercentInhouse = e.Row.FindControl("lblVAPercentInhouse") as Label;
            Label lblPacked = e.Row.FindControl("lblPacked") as Label;
            Label lblPackedPercentInhouse = e.Row.FindControl("lblPackedPercentInhouse") as Label;

            Label lblCutreadyENDETA = e.Row.FindControl("lblCutreadyENDETA") as Label;
            Label lblCutreadyStartETA = e.Row.FindControl("lblCutreadyStartETA") as Label;
            Label lblStichedStartETA = e.Row.FindControl("lblStichedStartETA") as Label;
            Label lblStichedENDETA = e.Row.FindControl("lblStichedENDETA") as Label;
            Label lblVAStartETA = e.Row.FindControl("lblVAStartETA") as Label;
            Label lblVAENDETA = e.Row.FindControl("lblVAENDETA") as Label;
            Label lblPackedETA = e.Row.FindControl("lblPackedETA") as Label;
            HtmlTableCell tdFabric1 = e.Row.FindControl("tdFabric1") as HtmlTableCell;
            HtmlTableCell tdprint1 = e.Row.FindControl("tdprint1") as HtmlTableCell;
            HtmlTableCell tdFabric1DetailsRef = e.Row.FindControl("tdFabric1DetailsRef") as HtmlTableCell;
            HtmlTableCell tdFabricStartETAdate1 = e.Row.FindControl("tdFabricStartETAdate1") as HtmlTableCell;
            HtmlTableCell tdFabricEndETAdate1 = e.Row.FindControl("tdFabricEndETAdate1") as HtmlTableCell;
            HtmlTableCell tdFabric2 = e.Row.FindControl("tdFabric2") as HtmlTableCell;
            HtmlTableCell tdFabric2Percent = e.Row.FindControl("tdFabric2Percent") as HtmlTableCell;
            HtmlTableCell tdFabric2DetailsRef = e.Row.FindControl("tdFabric2DetailsRef") as HtmlTableCell;
            HtmlTableCell tdFabricStartETAdate2 = e.Row.FindControl("tdFabricStartETAdate2") as HtmlTableCell;
            HtmlTableCell tdFabricEndETAdate2 = e.Row.FindControl("tdFabricEndETAdate2") as HtmlTableCell;
            HtmlTableCell tdFabric3 = e.Row.FindControl("tdFabric3") as HtmlTableCell;
            HtmlTableCell tdFabric3Percent = e.Row.FindControl("tdFabric3Percent") as HtmlTableCell;
            HtmlTableCell tdFabric3DetailsRef = e.Row.FindControl("tdFabric3DetailsRef") as HtmlTableCell;
            HtmlTableCell tdFabricStartETAdate3 = e.Row.FindControl("tdFabricStartETAdate3") as HtmlTableCell;
            HtmlTableCell tdFabricEndETAdate3 = e.Row.FindControl("tdFabricEndETAdate3") as HtmlTableCell;
            HtmlTableCell tdFabric4Percent = e.Row.FindControl("tdFabric4Percent") as HtmlTableCell;
            HtmlTableCell tdFabric4DetailsRef = e.Row.FindControl("tdFabric4DetailsRef") as HtmlTableCell;
            HtmlTableCell tdFabricStartETAdate4 = e.Row.FindControl("tdFabricStartETAdate4") as HtmlTableCell;
            HtmlTableCell tdFabricEndETAdate4 = e.Row.FindControl("tdFabricEndETAdate4") as HtmlTableCell;
            // --------------------------------------------
            HtmlTableCell tdCutReady = e.Row.FindControl("tdCutReady") as HtmlTableCell;
            HtmlTableCell tdCutPercentInhouse = e.Row.FindControl("tdCutPercentInhouse") as HtmlTableCell;
            HtmlTableCell tdCutreadyStartETA = e.Row.FindControl("tdCutreadyStartETA") as HtmlTableCell;
            HtmlTableCell tdCutreadyENDETA = e.Row.FindControl("tdCutreadyENDETA") as HtmlTableCell;
            HtmlTableCell tdStitched = e.Row.FindControl("tdStitched") as HtmlTableCell;
            HtmlTableCell tdStitchedPercentInhouse = e.Row.FindControl("tdStitchedPercentInhouse") as HtmlTableCell;
            HtmlTableCell tdStichedStartETA = e.Row.FindControl("tdStichedStartETA") as HtmlTableCell;
            HtmlTableCell tdStichedENDETA = e.Row.FindControl("tdStichedENDETA") as HtmlTableCell;
            HtmlTableCell tdVA = e.Row.FindControl("tdVA") as HtmlTableCell;
            HtmlTableCell tdVAPercentInhouse = e.Row.FindControl("tdVAPercentInhouse") as HtmlTableCell;
            HtmlTableCell tdVAStartETA = e.Row.FindControl("tdVAStartETA") as HtmlTableCell;
            HtmlTableCell tdVAENDETA = e.Row.FindControl("tdVAENDETA") as HtmlTableCell;
            HtmlTableCell tdlPacked = e.Row.FindControl("tdlPacked") as HtmlTableCell;
            HtmlTableCell tdPackedPercentInhouse = e.Row.FindControl("tdPackedPercentInhouse") as HtmlTableCell;
            HtmlTableCell tdPackedETA = e.Row.FindControl("tdPackedETA") as HtmlTableCell;
            //---------------------
            HtmlTableCell tdstc = e.Row.FindControl("tdstc") as HtmlTableCell;
            HtmlTableCell tdLabel6 = e.Row.FindControl("tdLabel6") as HtmlTableCell;
            HtmlTableCell tdPatternSample = e.Row.FindControl("tdPatternSample") as HtmlTableCell;
            HtmlTableCell tdPatternETA = e.Row.FindControl("tdPatternETA") as HtmlTableCell;
            HtmlTableCell tdtop = e.Row.FindControl("tdtop") as HtmlTableCell;
            HtmlTableCell tdTOPETA = e.Row.FindControl("tdTOPETA") as HtmlTableCell;



            CheckBox CheckCB = e.Row.FindControl("cb") as CheckBox;




            if (lblFabric1 != null)
            {
                if (lblFabric1.Text != "")
                {
                    tbl1.Visible = true;
                    // if (Convert.ToInt32(Fabric1Percent.Text) >= 100)
                    if (lblFabricStartETAdate1.Text != "" && lblFabricEndETAdate1.Text != "" && Convert.ToInt32(Fabric1Percent.Text) >= 100)
                    {
                        lblFabric1.ForeColor = Color.Gray;
                        Fabric1Percent.ForeColor = Color.Gray;
                        lblFabricStartETAdate1.ForeColor = Color.Gray;
                        lblFabricEndETAdate1.ForeColor = Color.Gray;
                        lblFabric1DetailsRef.ForeColor = Color.Gray;

                    }


                    // td3f1.Style.Add(" background-color", "#FF0000");

                }
            }
            if (lblFabric2 != null)
            {
                if (lblFabric2.Text != "")
                {
                    tbl2.Visible = true;
                    // if (Convert.ToInt32(Fabric2Percent.Text) >= 100)
                    if (lblFabricStartETAdate2.Text != "" && lblFabricEndETAdate2.Text != "" && Convert.ToInt32(Fabric2Percent.Text) >= 100)
                    {
                        lblFabric2.ForeColor = Color.Gray;
                        Fabric2Percent.ForeColor = Color.Gray;
                        lblFabricStartETAdate2.ForeColor = Color.Gray;
                        lblFabricEndETAdate2.ForeColor = Color.Gray;
                        lblFabric2DetailsRef.ForeColor = Color.Gray;
                    }

                }
            }
            if (lblFabric3 != null)
            {
                if (lblFabric3.Text != "")
                {
                    tbl3.Visible = true;
                    //if (Convert.ToInt32(Fabric3Percent.Text) >= 100)
                    if (lblFabricStartETAdate3.Text != "" && lblFabricEndETAdate3.Text != "" && Convert.ToInt32(Fabric3Percent.Text) >= 100)
                    {
                        lblFabric3.ForeColor = Color.Gray;
                        Fabric3Percent.ForeColor = Color.Gray;
                        lblFabricStartETAdate3.ForeColor = Color.Gray;
                        lblFabricEndETAdate3.ForeColor = Color.Gray;
                        lblFabric3DetailsRef.ForeColor = Color.Gray;
                    }

                }
            }
            if (lblFabric4 != null)
            {
                if (lblFabric4.Text != "")
                {
                    tbl4.Visible = true;
                    //if (Convert.ToInt32(Fabric4Percent.Text) >= 100)
                    if (lblFabricStartETAdate4.Text != "" && lblFabricEndETAdate4.Text != "" && Convert.ToInt32(Fabric4Percent.Text) >= 100)
                    {
                        lblFabric3.ForeColor = Color.Gray;
                        Fabric3Percent.ForeColor = Color.Gray;
                        lblFabricStartETAdate4.ForeColor = Color.Gray;
                        lblFabricEndETAdate4.ForeColor = Color.Gray;
                        lblFabric4DetailsRef.ForeColor = Color.Gray;
                    }


                }
            }


            if (lblCutPercentInhouse != null)
            {
                //if (Convert.ToInt32(lblCutPercentInhouse.Text) >= 100)
                if (lblCutreadyStartETA.Text != "" && lblCutreadyENDETA.Text != "" && Convert.ToInt32(lblCutPercentInhouse.Text) >= 100)
                {
                    lblCutPercentInhouse.ForeColor = Color.Gray;
                    lvlCutReady.ForeColor = Color.Gray;
                    lblCutreadyENDETA.ForeColor = Color.Gray;
                    lblCutreadyStartETA.ForeColor = Color.Gray;

                }
            }



            if (lblStitchedPercentInhouse != null)
            {
                //if (Convert.ToInt32(lblStitchedPercentInhouse.Text) >= 100)
                if (lblStichedStartETA.Text != "" && lblStichedENDETA.Text != "" && Convert.ToInt32(lblStitchedPercentInhouse.Text) >= 100)
                {
                    lblStitchedPercentInhouse.ForeColor = Color.Gray;
                    lblStitched.ForeColor = Color.Gray;
                    lblStichedStartETA.ForeColor = Color.Gray;
                    lblStichedENDETA.ForeColor = Color.Gray;

                }
            }

            if (lblVAPercentInhouse != null)
            {
                // if (Convert.ToInt32(lblVAPercentInhouse.Text) >= 100)
                if (lblVAStartETA.Text != "" && lblVAENDETA.Text != "" && Convert.ToInt32(lblVAPercentInhouse.Text) >= 100)
                {
                    lblVAPercentInhouse.ForeColor = Color.Gray;
                    lvlVA.ForeColor = Color.Gray;
                    lblVAStartETA.ForeColor = Color.Gray;
                    lblVAENDETA.ForeColor = Color.Gray;

                }
            }

            if (lblPackedPercentInhouse != null)
            {
                //  if (Convert.ToInt32(lblPackedPercentInhouse.Text) >= 100 )
                if (lblPackedETA.Text != "" && Convert.ToInt32(lblPackedPercentInhouse.Text) >= 100)
                {
                    lblPackedPercentInhouse.ForeColor = Color.Gray;
                    lblPacked.ForeColor = Color.Gray;
                    lblPackedETA.ForeColor = Color.Gray;

                }
            }
            Repeater rptAccessoriesOB = e.Row.FindControl("rptAccessoriesOB") as Repeater;
            if (od.AccessoriesETA != null)
            {
                if (od.AccessoriesETA.Count > 0)
                {
                    rptAccessoriesOB.DataSource = od.AccessoriesETA;
                    rptAccessoriesOB.DataBind();
                }
            }
        }

        // For Refrence Front 
        protected void grdOBFront_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //return;
                Literal ltIndex = (Literal)e.Row.FindControl("ltIndex");
                ltIndex.Text = ((grdOBFront.PageIndex * grdOBFront.PageSize) + e.Row.RowIndex + 1).ToString();
                RowNumRef = ((grdOBFront.PageIndex * grdOBFront.PageSize) + e.Row.RowIndex + 1);

                Label lblSAM = (Label)e.Row.FindControl("lblSAM");
                Label lblMachineCount = (Label)e.Row.FindControl("lblMachineCount");
                Label lblFinalCount = (Label)e.Row.FindControl("lblFinalCount");
                //--------------------Edit-by-prabhaker-08-feb-17------------
                Label txtFactor = (Label)e.Row.FindControl("txtFactor");
                if (txtFactor != null)
                {
                    if (txtFactor.Text == "")
                        txtFactor.Text = "0";

                    TotalFact = TotalFact + Convert.ToDouble(txtFactor.Text);

                }
                //--------------------End-Edit-by-prabhaker-08-feb-17------------
                if (lblSAM != null)
                {
                    if (lblSAM.Text == "")
                        lblSAM.Text = "0";

                    TotalSam = TotalSam + Convert.ToDouble(lblSAM.Text);
                }
                if (lblMachineCount != null)
                {
                    if (lblMachineCount.Text == "")
                        lblMachineCount.Text = "0";

                    TotalMachine = TotalMachine + Convert.ToDouble(lblMachineCount.Text);
                }
                if (lblFinalCount != null)
                {
                    if (lblFinalCount.Text == "")
                        lblFinalCount.Text = "0";

                    FinalMachine = FinalMachine + Convert.ToDouble(lblFinalCount.Text);
                }

            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label lblSAMFooter = (Label)e.Row.FindControl("lblSAMFooter");
                //TotalSam
                if (TotalSam != 0)
                    lblSAMFooter.Text = TotalSam.ToString();

                Label lblMachineCountFooter = (Label)e.Row.FindControl("lblMachineCountFooter");
                //TotalSam
                if (TotalMachine != 0)
                    lblMachineCountFooter.Text = TotalMachine.ToString();

                Label lblFinalCountFooter = (Label)e.Row.FindControl("lblFinalCountFooter");
                //TotalSam 
                if (FinalMachine != 0)
                    lblFinalCountFooter.Text = FinalMachine.ToString();

                //edit by prabhaker 08-feb-17
                Label lblFactorFooter = (Label)e.Row.FindControl("lblFactorFooter");
                if (TotalFact != 0)              
                    lblFactorFooter.Text = TotalFact.ToString();
              
                //end edit by prabhaker 08-feb-17
                TotalFact = 0;
                TotalSam = 0;
                TotalMachine = 0;
                FinalMachine = 0;
            }
        }

        // For Refrence Back 
        protected void grdOBBack_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //return;
                Literal ltIndex = (Literal)e.Row.FindControl("ltIndex");
                ltIndex.Text = (Convert.ToInt32(RowNumRef) + 1).ToString();
                RowNumRef = (Convert.ToInt32(RowNumRef) + 1);

                Label lblSAM = (Label)e.Row.FindControl("lblSAM");
                Label lblMachineCount = (Label)e.Row.FindControl("lblMachineCount");
                Label lblFinalCount = (Label)e.Row.FindControl("lblFinalCount");
                //--------------------Edit-by-prabhaker-08-feb-17------------
                Label txtFactor = (Label)e.Row.FindControl("txtFactor");
                if (txtFactor != null)
                {
                    if (txtFactor.Text == "")
                        txtFactor.Text = "0";

                    TotalFact = TotalFact + Convert.ToDouble(txtFactor.Text);

                }
                //--------------------End-Edit-by-prabhaker-08-feb-17------------
                if (lblSAM != null)
                {
                    if (lblSAM.Text == "")
                        lblSAM.Text = "0";

                    TotalSam = TotalSam + Convert.ToDouble(lblSAM.Text);
                }
                if (lblMachineCount != null)
                {
                    if (lblMachineCount.Text == "")
                        lblMachineCount.Text = "0";

                    TotalMachine = TotalMachine + Convert.ToDouble(lblMachineCount.Text);
                }
                if (lblFinalCount != null)
                {
                    if (lblFinalCount.Text == "")
                        lblFinalCount.Text = "0";

                    FinalMachine = FinalMachine + Convert.ToDouble(lblFinalCount.Text);
                }

            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label lblSAMFooter = (Label)e.Row.FindControl("lblSAMFooter");
                //TotalSam
                if (TotalSam != 0)
                    lblSAMFooter.Text = TotalSam.ToString();

                Label lblMachineCountFooter = (Label)e.Row.FindControl("lblMachineCountFooter");
                //TotalSam
                if (TotalMachine != 0)
                    lblMachineCountFooter.Text = TotalMachine.ToString();

                Label lblFinalCountFooter = (Label)e.Row.FindControl("lblFinalCountFooter");
                //TotalSam 
                if (FinalMachine != 0)
                    lblFinalCountFooter.Text = FinalMachine.ToString();

                //edit by prabhaker 08-feb-17
                Label lblFactorFooter = (Label)e.Row.FindControl("lblFactorFooter");
                if (TotalFact != 0)
               
                    lblFactorFooter.Text = TotalFact.ToString();
                
                //end edit by prabhaker 08-feb-17
                TotalFact = 0;
                TotalSam = 0;
                TotalMachine = 0;
                FinalMachine = 0;
            }
        }

        // For Refrence Coller 
        protected void grdOBcoller_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //return;
                Literal ltIndex = (Literal)e.Row.FindControl("ltIndex");
                ltIndex.Text = (Convert.ToInt32(RowNumRef) + 1).ToString();
                RowNumRef = (Convert.ToInt32(RowNumRef) + 1);

                Label lblSAM = (Label)e.Row.FindControl("lblSAM");
                Label lblMachineCount = (Label)e.Row.FindControl("lblMachineCount");
                Label lblFinalCount = (Label)e.Row.FindControl("lblFinalCount");
                //--------------------Edit-by-prabhaker-08-feb-17------------
                Label txtFactor = (Label)e.Row.FindControl("txtFactor");
                if (txtFactor != null)
                {
                    if (txtFactor.Text == "")
                        txtFactor.Text = "0";

                    TotalFact = TotalFact + Convert.ToDouble(txtFactor.Text);

                }
                //--------------------End-Edit-by-prabhaker-08-feb-17------------
                if (lblSAM != null)
                {
                    if (lblSAM.Text == "")
                        lblSAM.Text = "0";

                    TotalSam = TotalSam + Convert.ToDouble(lblSAM.Text);
                }
                if (lblMachineCount != null)
                {
                    if (lblMachineCount.Text == "")
                        lblMachineCount.Text = "0";

                    TotalMachine = TotalMachine + Convert.ToDouble(lblMachineCount.Text);
                }
                if (lblFinalCount != null)
                {
                    if (lblFinalCount.Text == "")
                        lblFinalCount.Text = "0";

                    FinalMachine = FinalMachine + Convert.ToDouble(lblFinalCount.Text);
                }

            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label lblSAMFooter = (Label)e.Row.FindControl("lblSAMFooter");
                //TotalSam
                if (TotalSam != 0)
                    lblSAMFooter.Text = TotalSam.ToString();

                Label lblMachineCountFooter = (Label)e.Row.FindControl("lblMachineCountFooter");
                //TotalSam
                if (TotalMachine != 0)
                    lblMachineCountFooter.Text = TotalMachine.ToString();

                Label lblFinalCountFooter = (Label)e.Row.FindControl("lblFinalCountFooter");
                //TotalSam 
                if (FinalMachine != 0)
                    lblFinalCountFooter.Text = FinalMachine.ToString();
                //edit by prabhaker 08-feb-17
                Label lblFactorFooter = (Label)e.Row.FindControl("lblFactorFooter");
                if (TotalFact != 0)              
                    lblFactorFooter.Text = TotalFact.ToString();
                
                //end edit by prabhaker 08-feb-17
                TotalFact = 0;
                TotalSam = 0;
                TotalMachine = 0;
                FinalMachine = 0;
            }
        }

        // For Refrence sleep 
        protected void grdOBsleep_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //return;
                Literal ltIndex = (Literal)e.Row.FindControl("ltIndex");
                ltIndex.Text = (Convert.ToInt32(RowNumRef) + 1).ToString();
                RowNumRef = (Convert.ToInt32(RowNumRef) + 1);

                Label lblSAM = (Label)e.Row.FindControl("lblSAM");
                Label lblMachineCount = (Label)e.Row.FindControl("lblMachineCount");
                Label lblFinalCount = (Label)e.Row.FindControl("lblFinalCount");
                //--------------------Edit-by-prabhaker-08-feb-17------------
                Label txtFactor = (Label)e.Row.FindControl("txtFactor");
                if (txtFactor != null)
                {
                    if (txtFactor.Text == "")
                        txtFactor.Text = "0";

                    TotalFact = TotalFact + Convert.ToDouble(txtFactor.Text);

                }
                //--------------------End-Edit-by-prabhaker-08-feb-17------------
                if (lblSAM != null)
                {
                    if (lblSAM.Text == "")
                        lblSAM.Text = "0";

                    TotalSam = TotalSam + Convert.ToDouble(lblSAM.Text);
                }
                if (lblMachineCount != null)
                {
                    if (lblMachineCount.Text == "")
                        lblMachineCount.Text = "0";

                    TotalMachine = TotalMachine + Convert.ToDouble(lblMachineCount.Text);
                }
                if (lblFinalCount != null)
                {
                    if (lblFinalCount.Text == "")
                        lblFinalCount.Text = "0";

                    FinalMachine = FinalMachine + Convert.ToDouble(lblFinalCount.Text);
                }

            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label lblSAMFooter = (Label)e.Row.FindControl("lblSAMFooter");
                //TotalSam
                if (TotalSam != 0)
                    lblSAMFooter.Text = TotalSam.ToString();

                Label lblMachineCountFooter = (Label)e.Row.FindControl("lblMachineCountFooter");
                //TotalSam
                if (TotalMachine != 0)
                    lblMachineCountFooter.Text = TotalMachine.ToString();

                Label lblFinalCountFooter = (Label)e.Row.FindControl("lblFinalCountFooter");
                //TotalSam 
                if (FinalMachine != 0)
                    lblFinalCountFooter.Text = FinalMachine.ToString();
                //edit by prabhaker 08-feb-17
                Label lblFactorFooter = (Label)e.Row.FindControl("lblFactorFooter");
                if (TotalFact != 0)                
                    lblFactorFooter.Text = TotalFact.ToString();
                
                //end edit by prabhaker 08-feb-17
                TotalFact = 0;
                TotalSam = 0;
                TotalMachine = 0;
                FinalMachine = 0;
            }
        }

        // For Refrence neck 
        protected void grdOBneck_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //return;
                Literal ltIndex = (Literal)e.Row.FindControl("ltIndex");
                ltIndex.Text = (Convert.ToInt32(RowNumRef) + 1).ToString();
                RowNumRef = (Convert.ToInt32(RowNumRef) + 1);

                Label lblSAM = (Label)e.Row.FindControl("lblSAM");
                Label lblMachineCount = (Label)e.Row.FindControl("lblMachineCount");
                Label lblFinalCount = (Label)e.Row.FindControl("lblFinalCount");
                //--------------------Edit-by-prabhaker-08-feb-17------------
                Label txtFactor = (Label)e.Row.FindControl("txtFactor");
                if (txtFactor != null)
                {
                    if (txtFactor.Text == "")
                        txtFactor.Text = "0";

                    TotalFact = TotalFact + Convert.ToDouble(txtFactor.Text);

                }
                //--------------------End-Edit-by-prabhaker-08-feb-17------------
                if (lblSAM != null)
                {
                    if (lblSAM.Text == "")
                        lblSAM.Text = "0";

                    TotalSam = TotalSam + Convert.ToDouble(lblSAM.Text);
                }
                if (lblMachineCount != null)
                {
                    if (lblMachineCount.Text == "")
                        lblMachineCount.Text = "0";

                    TotalMachine = TotalMachine + Convert.ToDouble(lblMachineCount.Text);
                }
                if (lblFinalCount != null)
                {
                    if (lblFinalCount.Text == "")
                        lblFinalCount.Text = "0";

                    FinalMachine = FinalMachine + Convert.ToDouble(lblFinalCount.Text);
                }

            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label lblSAMFooter = (Label)e.Row.FindControl("lblSAMFooter");
                //TotalSam
                if (TotalSam != 0)
                    lblSAMFooter.Text = TotalSam.ToString();

                Label lblMachineCountFooter = (Label)e.Row.FindControl("lblMachineCountFooter");
                //TotalSam
                if (TotalMachine != 0)
                    lblMachineCountFooter.Text = TotalMachine.ToString();

                Label lblFinalCountFooter = (Label)e.Row.FindControl("lblFinalCountFooter");
                //TotalSam 
                if (FinalMachine != 0)
                    lblFinalCountFooter.Text = FinalMachine.ToString();
                //edit by prabhaker 08-feb-17
                Label lblFactorFooter = (Label)e.Row.FindControl("lblFactorFooter");
                if (TotalFact != 0)                
                    lblFactorFooter.Text = TotalFact.ToString();
                
                //end edit by prabhaker 08-feb-17
                TotalFact = 0;
                TotalSam = 0;
                TotalMachine = 0;
                FinalMachine = 0;
            }
        }

        // For Refrence Lining  
        protected void grdOBLining_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //return;
                Literal ltIndex = (Literal)e.Row.FindControl("ltIndex");
                ltIndex.Text = (Convert.ToInt32(RowNumRef) + 1).ToString();
                RowNumRef = (Convert.ToInt32(RowNumRef) + 1);

                Label lblSAM = (Label)e.Row.FindControl("lblSAM");
                Label lblMachineCount = (Label)e.Row.FindControl("lblMachineCount");
                Label lblFinalCount = (Label)e.Row.FindControl("lblFinalCount");
                //--------------------Edit-by-prabhaker-08-feb-17------------
                Label txtFactor = (Label)e.Row.FindControl("txtFactor");
                if (txtFactor != null)
                {
                    if (txtFactor.Text == "")
                        txtFactor.Text = "0";

                    TotalFact = TotalFact + Convert.ToDouble(txtFactor.Text);

                }
                //--------------------End-Edit-by-prabhaker-08-feb-17------------
                if (lblSAM != null)
                {
                    if (lblSAM.Text == "")
                        lblSAM.Text = "0";

                    TotalSam = TotalSam + Convert.ToDouble(lblSAM.Text);
                }
                if (lblMachineCount != null)
                {
                    if (lblMachineCount.Text == "")
                        lblMachineCount.Text = "0";

                    TotalMachine = TotalMachine + Convert.ToDouble(lblMachineCount.Text);
                }
                if (lblFinalCount != null)
                {
                    if (lblFinalCount.Text == "")
                        lblFinalCount.Text = "0";

                    FinalMachine = FinalMachine + Convert.ToDouble(lblFinalCount.Text);
                }

            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label lblSAMFooter = (Label)e.Row.FindControl("lblSAMFooter");
                //TotalSam
                if (TotalSam != 0)
                    lblSAMFooter.Text = TotalSam.ToString();

                Label lblMachineCountFooter = (Label)e.Row.FindControl("lblMachineCountFooter");
                //TotalSam
                if (TotalMachine != 0)
                    lblMachineCountFooter.Text = TotalMachine.ToString();

                Label lblFinalCountFooter = (Label)e.Row.FindControl("lblFinalCountFooter");
                //TotalSam 
                if (FinalMachine != 0)
                    lblFinalCountFooter.Text = FinalMachine.ToString();
                //edit by prabhaker 08-feb-17
                Label lblFactorFooter = (Label)e.Row.FindControl("lblFactorFooter");
                if (TotalFact != 0)
                {
                    lblFactorFooter.Text = TotalFact.ToString();
                }
                //end edit by prabhaker 08-feb-17
                TotalFact = 0;
                TotalSam = 0;
                TotalMachine = 0;
                FinalMachine = 0;
            }
        }


        // For Refrence Lower
        protected void grdOBlower_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //return;
                Literal ltIndex = (Literal)e.Row.FindControl("ltIndex");
                ltIndex.Text = (Convert.ToInt32(RowNumRef) + 1).ToString();
                RowNumRef = (Convert.ToInt32(RowNumRef) + 1);

                Label lblSAM = (Label)e.Row.FindControl("lblSAM");
                Label lblMachineCount = (Label)e.Row.FindControl("lblMachineCount");
                Label lblFinalCount = (Label)e.Row.FindControl("lblFinalCount");
                //--------------------Edit-by-prabhaker-08-feb-17------------
                Label txtFactor = (Label)e.Row.FindControl("txtFactor");
                if (txtFactor != null)
                {
                    if (txtFactor.Text == "")
                        txtFactor.Text = "0";

                    TotalFact = TotalFact + Convert.ToDouble(txtFactor.Text);

                }
                //--------------------End-Edit-by-prabhaker-08-feb-17------------
                if (lblSAM != null)
                {
                    if (lblSAM.Text == "")
                        lblSAM.Text = "0";

                    TotalSam = TotalSam + Convert.ToDouble(lblSAM.Text);
                }
                if (lblMachineCount != null)
                {
                    if (lblMachineCount.Text == "")
                        lblMachineCount.Text = "0";

                    TotalMachine = TotalMachine + Convert.ToDouble(lblMachineCount.Text);
                }
                if (lblFinalCount != null)
                {
                    if (lblFinalCount.Text == "")
                        lblFinalCount.Text = "0";

                    FinalMachine = FinalMachine + Convert.ToDouble(lblFinalCount.Text);
                }

            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label lblSAMFooter = (Label)e.Row.FindControl("lblSAMFooter");
                //TotalSam
                if (TotalSam != 0)
                    lblSAMFooter.Text = TotalSam.ToString();

                Label lblMachineCountFooter = (Label)e.Row.FindControl("lblMachineCountFooter");
                //TotalSam
                if (TotalMachine != 0)
                    lblMachineCountFooter.Text = TotalMachine.ToString();

                Label lblFinalCountFooter = (Label)e.Row.FindControl("lblFinalCountFooter");
                //TotalSam 
                if (FinalMachine != 0)
                    lblFinalCountFooter.Text = FinalMachine.ToString();
                //edit by prabhaker 08-feb-17
                Label lblFactorFooter = (Label)e.Row.FindControl("lblFactorFooter");
                if (TotalFact != 0)
                {
                    lblFactorFooter.Text = TotalFact.ToString();
                }
                //end edit by prabhaker 08-feb-17
                TotalFact = 0;
                TotalSam = 0;
                TotalMachine = 0;
                FinalMachine = 0;
            }
        }

        // For Refrence bottom
        protected void grdOBbottom_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //return;
                Literal ltIndex = (Literal)e.Row.FindControl("ltIndex");
                ltIndex.Text = (Convert.ToInt32(RowNumRef) + 1).ToString();
                RowNumRef = (Convert.ToInt32(RowNumRef) + 1);

                Label lblSAM = (Label)e.Row.FindControl("lblSAM");
                Label lblMachineCount = (Label)e.Row.FindControl("lblMachineCount");
                Label lblFinalCount = (Label)e.Row.FindControl("lblFinalCount");
                //--------------------Edit-by-prabhaker-08-feb-17------------
                Label txtFactor = (Label)e.Row.FindControl("txtFactor");
                if (txtFactor != null)
                {
                    if (txtFactor.Text == "")
                        txtFactor.Text = "0";

                    TotalFact = TotalFact + Convert.ToDouble(txtFactor.Text);

                }
                //--------------------End-Edit-by-prabhaker-08-feb-17------------
                if (lblSAM != null)
                {
                    if (lblSAM.Text == "")
                        lblSAM.Text = "0";

                    TotalSam = TotalSam + Convert.ToDouble(lblSAM.Text);
                }
                if (lblMachineCount != null)
                {
                    if (lblMachineCount.Text == "")
                        lblMachineCount.Text = "0";

                    TotalMachine = TotalMachine + Convert.ToDouble(lblMachineCount.Text);
                }
                if (lblFinalCount != null)
                {
                    if (lblFinalCount.Text == "")
                        lblFinalCount.Text = "0";

                    FinalMachine = FinalMachine + Convert.ToDouble(lblFinalCount.Text);
                }

            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label lblSAMFooter = (Label)e.Row.FindControl("lblSAMFooter");
                //TotalSam
                if (TotalSam != 0)
                    lblSAMFooter.Text = TotalSam.ToString();

                Label lblMachineCountFooter = (Label)e.Row.FindControl("lblMachineCountFooter");
                //TotalSam
                if (TotalMachine != 0)
                    lblMachineCountFooter.Text = TotalMachine.ToString();

                Label lblFinalCountFooter = (Label)e.Row.FindControl("lblFinalCountFooter");
                //TotalSam 
                if (FinalMachine != 0)
                    lblFinalCountFooter.Text = FinalMachine.ToString();
                //edit by prabhaker 08-feb-17
                Label lblFactorFooter = (Label)e.Row.FindControl("lblFactorFooter");
                if (TotalFact != 0)
                {
                    lblFactorFooter.Text = TotalFact.ToString();
                }
                //end edit by prabhaker 08-feb-17
                TotalFact = 0;
                TotalSam = 0;
                TotalMachine = 0;
                FinalMachine = 0;
            }
        }

        // For Refrence assembly 
        protected void grdOBassembly_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //return;
                Literal ltIndex = (Literal)e.Row.FindControl("ltIndex");
                ltIndex.Text = (Convert.ToInt32(RowNumRef) + 1).ToString();

                RowNumRef = (Convert.ToInt32(RowNumRef) + 1);

                Label lblSAM = (Label)e.Row.FindControl("lblSAM");
                Label lblMachineCount = (Label)e.Row.FindControl("lblMachineCount");
                Label lblFinalCount = (Label)e.Row.FindControl("lblFinalCount");
                //--------------------Edit-by-prabhaker-08-feb-17------------
                Label txtFactor = (Label)e.Row.FindControl("txtFactor");
                if (txtFactor != null)
                {
                    if (txtFactor.Text == "")
                        txtFactor.Text = "0";

                    TotalFact = TotalFact + Convert.ToDouble(txtFactor.Text);

                }
                //--------------------End-Edit-by-prabhaker-08-feb-17------------
                if (lblSAM != null)
                {
                    if (lblSAM.Text == "")
                        lblSAM.Text = "0";

                    TotalSam = TotalSam + Convert.ToDouble(lblSAM.Text);
                }
                if (lblMachineCount != null)
                {
                    if (lblMachineCount.Text == "")
                        lblMachineCount.Text = "0";

                    TotalMachine = TotalMachine + Convert.ToDouble(lblMachineCount.Text);
                }
                if (lblFinalCount != null)
                {
                    if (lblFinalCount.Text == "")
                        lblFinalCount.Text = "0";

                    FinalMachine = FinalMachine + Convert.ToDouble(lblFinalCount.Text);
                }

            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label lblSAMFooter = (Label)e.Row.FindControl("lblSAMFooter");
                //TotalSam
                if (TotalSam != 0)
                    lblSAMFooter.Text = TotalSam.ToString();

                Label lblMachineCountFooter = (Label)e.Row.FindControl("lblMachineCountFooter");
                //TotalSam
                if (TotalMachine != 0)
                    lblMachineCountFooter.Text = TotalMachine.ToString();

                Label lblFinalCountFooter = (Label)e.Row.FindControl("lblFinalCountFooter");
                //TotalSam 
                if (FinalMachine != 0)
                    lblFinalCountFooter.Text = FinalMachine.ToString();
                //edit by prabhaker 08-feb-17
                Label lblFactorFooter = (Label)e.Row.FindControl("lblFactorFooter");
                if (TotalFact != 0)
                {
                    lblFactorFooter.Text = TotalFact.ToString();
                }
                //end edit by prabhaker 08-feb-17
                TotalFact = 0;
                TotalSam = 0;
                TotalMachine = 0;
                FinalMachine = 0;
            }
        }

        // For Refrence piping 
        protected void grdOBpiping_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //return;
                Literal ltIndex = (Literal)e.Row.FindControl("ltIndex");
                ltIndex.Text = (Convert.ToInt32(RowNumRef) + 1).ToString();
                RowNumRef = (Convert.ToInt32(RowNumRef) + 1);

                Label lblSAM = (Label)e.Row.FindControl("lblSAM");
                Label lblMachineCount = (Label)e.Row.FindControl("lblMachineCount");
                Label lblFinalCount = (Label)e.Row.FindControl("lblFinalCount");
                //--------------------Edit-by-prabhaker-08-feb-17------------
                Label txtFactor = (Label)e.Row.FindControl("txtFactor");
                if (txtFactor != null)
                {
                    if (txtFactor.Text == "")
                        txtFactor.Text = "0";

                    TotalFact = TotalFact + Convert.ToDouble(txtFactor.Text);

                }
                //--------------------End-Edit-by-prabhaker-08-feb-17------------
                if (lblSAM != null)
                {
                    if (lblSAM.Text == "")
                        lblSAM.Text = "0";

                    TotalSam = TotalSam + Convert.ToDouble(lblSAM.Text);
                }
                if (lblMachineCount != null)
                {
                    if (lblMachineCount.Text == "")
                        lblMachineCount.Text = "0";

                    TotalMachine = TotalMachine + Convert.ToDouble(lblMachineCount.Text);
                }
                if (lblFinalCount != null)
                {
                    if (lblFinalCount.Text == "")
                        lblFinalCount.Text = "0";

                    FinalMachine = FinalMachine + Convert.ToDouble(lblFinalCount.Text);
                }

            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label lblSAMFooter = (Label)e.Row.FindControl("lblSAMFooter");
                //TotalSam
                if (TotalSam != 0)
                    lblSAMFooter.Text = TotalSam.ToString();

                Label lblMachineCountFooter = (Label)e.Row.FindControl("lblMachineCountFooter");
                //TotalSam
                if (TotalMachine != 0)
                    lblMachineCountFooter.Text = TotalMachine.ToString();

                Label lblFinalCountFooter = (Label)e.Row.FindControl("lblFinalCountFooter");
                //TotalSam 
                if (FinalMachine != 0)
                    lblFinalCountFooter.Text = FinalMachine.ToString();
                //edit by prabhaker 08-feb-17
                Label lblFactorFooter = (Label)e.Row.FindControl("lblFactorFooter");
                if (TotalFact != 0)
                {
                    lblFactorFooter.Text = TotalFact.ToString();
                }
                //end edit by prabhaker 08-feb-17

                TotalFact = 0;
                TotalSam = 0;
                TotalMachine = 0;
                FinalMachine = 0;
            }
        }

        // For Refrence Upper 
        protected void grdOBUpper_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //return;
                Literal ltIndex = (Literal)e.Row.FindControl("ltIndex");
                ltIndex.Text = (Convert.ToInt32(RowNumRef) + 1).ToString();

                RowNumRef = (Convert.ToInt32(RowNumRef) + 1);

                Label lblSAM = (Label)e.Row.FindControl("lblSAM");
                Label lblMachineCount = (Label)e.Row.FindControl("lblMachineCount");
                Label lblFinalCount = (Label)e.Row.FindControl("lblFinalCount");
                //--------------------Edit-by-prabhaker-08-feb-17------------
                Label txtFactor = (Label)e.Row.FindControl("txtFactor");
                if (txtFactor != null)
                {
                    if (txtFactor.Text == "")
                        txtFactor.Text = "0";

                    TotalFact = TotalFact + Convert.ToDouble(txtFactor.Text);

                }
                //--------------------End-Edit-by-prabhaker-08-feb-17------------
                if (lblSAM != null)
                {
                    if (lblSAM.Text == "")
                        lblSAM.Text = "0";

                    TotalSam = TotalSam + Convert.ToDouble(lblSAM.Text);
                }
                if (lblMachineCount != null)
                {
                    if (lblMachineCount.Text == "")
                        lblMachineCount.Text = "0";

                    TotalMachine = TotalMachine + Convert.ToDouble(lblMachineCount.Text);
                }
                if (lblFinalCount != null)
                {
                    if (lblFinalCount.Text == "")
                        lblFinalCount.Text = "0";

                    FinalMachine = FinalMachine + Convert.ToDouble(lblFinalCount.Text);
                }

            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label lblSAMFooter = (Label)e.Row.FindControl("lblSAMFooter");
                //TotalSam
                if (TotalSam != 0)
                    lblSAMFooter.Text = TotalSam.ToString();

                Label lblMachineCountFooter = (Label)e.Row.FindControl("lblMachineCountFooter");
                //TotalSam
                if (TotalMachine != 0)
                    lblMachineCountFooter.Text = TotalMachine.ToString();

                Label lblFinalCountFooter = (Label)e.Row.FindControl("lblFinalCountFooter");
                //TotalSam 
                if (FinalMachine != 0)
                    lblFinalCountFooter.Text = FinalMachine.ToString();
                //edit by prabhaker 08-feb-17
                Label lblFactorFooter = (Label)e.Row.FindControl("lblFactorFooter");
                if (TotalFact != 0)
                {
                    lblFactorFooter.Text = TotalFact.ToString();
                }
                //end edit by prabhaker 08-feb-17
                TotalFact = 0;
                TotalSam = 0;
                TotalMachine = 0;
                FinalMachine = 0;
            }
        }

        // For Refrence Upper shell 
        protected void grdOBUppershell_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //return; 
                Literal ltIndex = (Literal)e.Row.FindControl("ltIndex");
                ltIndex.Text = (Convert.ToInt32(RowNumRef) + 1).ToString();
                RowNumRef = (Convert.ToInt32(RowNumRef) + 1);

                Label lblSAM = (Label)e.Row.FindControl("lblSAM");
                Label lblMachineCount = (Label)e.Row.FindControl("lblMachineCount");
                Label lblFinalCount = (Label)e.Row.FindControl("lblFinalCount");
                //--------------------Edit-by-prabhaker-08-feb-17------------
                Label txtFactor = (Label)e.Row.FindControl("txtFactor");
                if (txtFactor != null)
                {
                    if (txtFactor.Text == "")
                        txtFactor.Text = "0";

                    TotalFact = TotalFact + Convert.ToDouble(txtFactor.Text);

                }
                //--------------------End-Edit-by-prabhaker-08-feb-17------------
                if (lblSAM != null)
                {
                    if (lblSAM.Text == "")
                        lblSAM.Text = "0";

                    TotalSam = TotalSam + Convert.ToDouble(lblSAM.Text);
                }
                if (lblMachineCount != null)
                {
                    if (lblMachineCount.Text == "")
                        lblMachineCount.Text = "0";

                    TotalMachine = TotalMachine + Convert.ToDouble(lblMachineCount.Text);
                }
                if (lblFinalCount != null)
                {
                    if (lblFinalCount.Text == "")
                        lblFinalCount.Text = "0";

                    FinalMachine = FinalMachine + Convert.ToDouble(lblFinalCount.Text);
                }

            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label lblSAMFooter = (Label)e.Row.FindControl("lblSAMFooter");
                //TotalSam
                if (TotalSam != 0)
                    lblSAMFooter.Text = TotalSam.ToString();

                Label lblMachineCountFooter = (Label)e.Row.FindControl("lblMachineCountFooter");
                //TotalSam
                if (TotalMachine != 0)
                    lblMachineCountFooter.Text = TotalMachine.ToString();

                Label lblFinalCountFooter = (Label)e.Row.FindControl("lblFinalCountFooter");
                //TotalSam 
                if (FinalMachine != 0)
                    lblFinalCountFooter.Text = FinalMachine.ToString();
                //edit by prabhaker 08-feb-17
                Label lblFactorFooter = (Label)e.Row.FindControl("lblFactorFooter");
                if (TotalFact != 0)
                {
                    lblFactorFooter.Text = TotalFact.ToString();
                }
                //end edit by prabhaker 08-feb-17
                TotalFact = 0;
                TotalSam = 0;
                TotalMachine = 0;
                FinalMachine = 0;
            }
        }

        // For Refrence Lower shell
        protected void grdOBLowershell_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //return; 
                Literal ltIndex = (Literal)e.Row.FindControl("ltIndex");
                ltIndex.Text = (Convert.ToInt32(RowNumRef) + 1).ToString();

                RowNumRef = (Convert.ToInt32(RowNumRef) + 1);

                Label lblSAM = (Label)e.Row.FindControl("lblSAM");
                Label lblMachineCount = (Label)e.Row.FindControl("lblMachineCount");
                Label lblFinalCount = (Label)e.Row.FindControl("lblFinalCount");
                //--------------------Edit-by-prabhaker-08-feb-17------------
                Label txtFactor = (Label)e.Row.FindControl("txtFactor");
                if (txtFactor != null)
                {
                    if (txtFactor.Text == "")
                        txtFactor.Text = "0";

                    TotalFact = TotalFact + Convert.ToDouble(txtFactor.Text);

                }
                //--------------------End-Edit-by-prabhaker-08-feb-17------------
                if (lblSAM != null)
                {
                    if (lblSAM.Text == "")
                        lblSAM.Text = "0";

                    TotalSam = TotalSam + Convert.ToDouble(lblSAM.Text);
                }
                if (lblMachineCount != null)
                {
                    if (lblMachineCount.Text == "")
                        lblMachineCount.Text = "0";

                    TotalMachine = TotalMachine + Convert.ToDouble(lblMachineCount.Text);
                }
                if (lblFinalCount != null)
                {
                    if (lblFinalCount.Text == "")
                        lblFinalCount.Text = "0";

                    FinalMachine = FinalMachine + Convert.ToDouble(lblFinalCount.Text);
                }

            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label lblSAMFooter = (Label)e.Row.FindControl("lblSAMFooter");
                //TotalSam
                if (TotalSam != 0)
                    lblSAMFooter.Text = TotalSam.ToString();

                Label lblMachineCountFooter = (Label)e.Row.FindControl("lblMachineCountFooter");
                //TotalSam
                if (TotalMachine != 0)
                    lblMachineCountFooter.Text = TotalMachine.ToString();

                Label lblFinalCountFooter = (Label)e.Row.FindControl("lblFinalCountFooter");
                //TotalSam 
                if (FinalMachine != 0)
                    lblFinalCountFooter.Text = FinalMachine.ToString();
                //edit by prabhaker 08-feb-17
                Label lblFactorFooter = (Label)e.Row.FindControl("lblFactorFooter");
                if (TotalFact != 0)
                {
                    lblFactorFooter.Text = TotalFact.ToString();
                }
                //end edit by prabhaker 08-feb-17
                TotalFact = 0;
                TotalSam = 0;
                TotalMachine = 0;
                FinalMachine = 0;
            }
        }

        // For Refrence Shell Section
        protected void grdOBShellsection_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //return; 
                Literal ltIndex = (Literal)e.Row.FindControl("ltIndex");
                ltIndex.Text = (Convert.ToInt32(RowNumRef) + 1).ToString();

                RowNumRef = (Convert.ToInt32(RowNumRef) + 1);

                Label lblSAM = (Label)e.Row.FindControl("lblSAM");
                Label lblMachineCount = (Label)e.Row.FindControl("lblMachineCount");
                Label lblFinalCount = (Label)e.Row.FindControl("lblFinalCount");
                //--------------------Edit-by-prabhaker-08-feb-17------------
                Label txtFactor = (Label)e.Row.FindControl("txtFactor");
                if (txtFactor != null)
                {
                    if (txtFactor.Text == "")
                        txtFactor.Text = "0";

                    TotalFact = TotalFact + Convert.ToDouble(txtFactor.Text);

                }
                //--------------------End-Edit-by-prabhaker-08-feb-17------------
                if (lblSAM != null)
                {
                    if (lblSAM.Text == "")
                        lblSAM.Text = "0";

                    TotalSam = TotalSam + Convert.ToDouble(lblSAM.Text);
                }
                if (lblMachineCount != null)
                {
                    if (lblMachineCount.Text == "")
                        lblMachineCount.Text = "0";

                    TotalMachine = TotalMachine + Convert.ToDouble(lblMachineCount.Text);
                }
                if (lblFinalCount != null)
                {
                    if (lblFinalCount.Text == "")
                        lblFinalCount.Text = "0";

                    FinalMachine = FinalMachine + Convert.ToDouble(lblFinalCount.Text);
                }

            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label lblSAMFooter = (Label)e.Row.FindControl("lblSAMFooter");
                //TotalSam
                if (TotalSam != 0)
                    lblSAMFooter.Text = TotalSam.ToString();

                Label lblMachineCountFooter = (Label)e.Row.FindControl("lblMachineCountFooter");
                //TotalSam
                if (TotalMachine != 0)
                    lblMachineCountFooter.Text = TotalMachine.ToString();

                Label lblFinalCountFooter = (Label)e.Row.FindControl("lblFinalCountFooter");
                //TotalSam 
                if (FinalMachine != 0)
                    lblFinalCountFooter.Text = FinalMachine.ToString();
                //edit by prabhaker 08-feb-17
                Label lblFactorFooter = (Label)e.Row.FindControl("lblFactorFooter");
                if (TotalFact != 0)
                {
                    lblFactorFooter.Text = TotalFact.ToString();
                }
                //end edit by prabhaker 08-feb-17
                TotalFact = 0;
                TotalSam = 0;
                TotalMachine = 0;
                FinalMachine = 0;
            }
        }

        // For Refrence Waist Section
        protected void grdOBWaistsection_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //return;
                Literal ltIndex = (Literal)e.Row.FindControl("ltIndex");
                ltIndex.Text = (Convert.ToInt32(RowNumRef) + 1).ToString();
                RowNumRef = (Convert.ToInt32(RowNumRef) + 1);

                Label lblSAM = (Label)e.Row.FindControl("lblSAM");
                Label lblMachineCount = (Label)e.Row.FindControl("lblMachineCount");
                Label lblFinalCount = (Label)e.Row.FindControl("lblFinalCount");
                //--------------------Edit-by-prabhaker-08-feb-17------------
                Label txtFactor = (Label)e.Row.FindControl("txtFactor");
                if (txtFactor != null)
                {
                    if (txtFactor.Text == "")
                        txtFactor.Text = "0";

                    TotalFact = TotalFact + Convert.ToDouble(txtFactor.Text);

                }
                //--------------------End-Edit-by-prabhaker-08-feb-17------------
                if (lblSAM != null)
                {
                    if (lblSAM.Text == "")
                        lblSAM.Text = "0";

                    TotalSam = TotalSam + Convert.ToDouble(lblSAM.Text);
                }
                if (lblMachineCount != null)
                {
                    if (lblMachineCount.Text == "")
                        lblMachineCount.Text = "0";

                    TotalMachine = TotalMachine + Convert.ToDouble(lblMachineCount.Text);
                }
                if (lblFinalCount != null)
                {
                    if (lblFinalCount.Text == "")
                        lblFinalCount.Text = "0";

                    FinalMachine = FinalMachine + Convert.ToDouble(lblFinalCount.Text);
                }

            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label lblSAMFooter = (Label)e.Row.FindControl("lblSAMFooter");
                //TotalSam
                if (TotalSam != 0)
                    lblSAMFooter.Text = TotalSam.ToString();

                Label lblMachineCountFooter = (Label)e.Row.FindControl("lblMachineCountFooter");
                //TotalSam
                if (TotalMachine != 0)
                    lblMachineCountFooter.Text = TotalMachine.ToString();

                Label lblFinalCountFooter = (Label)e.Row.FindControl("lblFinalCountFooter");
                //TotalSam 
                if (FinalMachine != 0)
                    lblFinalCountFooter.Text = FinalMachine.ToString();
                //edit by prabhaker 08-feb-17
                Label lblFactorFooter = (Label)e.Row.FindControl("lblFactorFooter");
                if (TotalFact != 0)
                {
                    lblFactorFooter.Text = TotalFact.ToString();
                }
                //end edit by prabhaker 08-feb-17
                TotalFact = 0;
                TotalSam = 0;
                TotalMachine = 0;
                FinalMachine = 0;
            }
        }

        // For Refrence Band Section
        protected void grdOBBandsection_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //return; 
                Literal ltIndex = (Literal)e.Row.FindControl("ltIndex");
                ltIndex.Text = (Convert.ToInt32(RowNumRef) + 1).ToString();
                RowNumRef = (Convert.ToInt32(RowNumRef) + 1);

                Label lblSAM = (Label)e.Row.FindControl("lblSAM");
                Label lblMachineCount = (Label)e.Row.FindControl("lblMachineCount");
                Label lblFinalCount = (Label)e.Row.FindControl("lblFinalCount");
                //--------------------Edit-by-prabhaker-08-feb-17------------
                Label txtFactor = (Label)e.Row.FindControl("txtFactor");
                if (txtFactor != null)
                {
                    if (txtFactor.Text == "")
                        txtFactor.Text = "0";

                    TotalFact = TotalFact + Convert.ToDouble(txtFactor.Text);

                }
                //--------------------End-Edit-by-prabhaker-08-feb-17------------
                if (lblSAM != null)
                {
                    if (lblSAM.Text == "")
                        lblSAM.Text = "0";

                    TotalSam = TotalSam + Convert.ToDouble(lblSAM.Text);
                }
                if (lblMachineCount != null)
                {
                    if (lblMachineCount.Text == "")
                        lblMachineCount.Text = "0";

                    TotalMachine = TotalMachine + Convert.ToDouble(lblMachineCount.Text);
                }
                if (lblFinalCount != null)
                {
                    if (lblFinalCount.Text == "")
                        lblFinalCount.Text = "0";

                    FinalMachine = FinalMachine + Convert.ToDouble(lblFinalCount.Text);
                }

            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label lblSAMFooter = (Label)e.Row.FindControl("lblSAMFooter");
                //TotalSam
                if (TotalSam != 0)
                    lblSAMFooter.Text = TotalSam.ToString();

                Label lblMachineCountFooter = (Label)e.Row.FindControl("lblMachineCountFooter");
                //TotalSam
                if (TotalMachine != 0)
                    lblMachineCountFooter.Text = TotalMachine.ToString();

                Label lblFinalCountFooter = (Label)e.Row.FindControl("lblFinalCountFooter");
                //TotalSam 
                if (FinalMachine != 0)
                    lblFinalCountFooter.Text = FinalMachine.ToString();
                //edit by prabhaker 08-feb-17
                Label lblFactorFooter = (Label)e.Row.FindControl("lblFactorFooter");
                if (TotalFact != 0)
                {
                    lblFactorFooter.Text = TotalFact.ToString();
                }
                //end edit by prabhaker 08-feb-17
                TotalFact = 0;
                TotalSam = 0;
                TotalMachine = 0;
                FinalMachine = 0;
            }
        }

        //added by abhishek for neck new section-------------------------------------------------//Abhishek 10/9/2015
        // For Refrence NewNeck Section
        protected void grdNewNeck_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //return; 
                Literal ltIndex = (Literal)e.Row.FindControl("ltIndex");
                ltIndex.Text = (Convert.ToInt32(RowNumRef) + 1).ToString();
                RowNumRef = (Convert.ToInt32(RowNumRef) + 1);

                Label lblSAM = (Label)e.Row.FindControl("lblSAM");
                Label lblMachineCount = (Label)e.Row.FindControl("lblMachineCount");
                Label lblFinalCount = (Label)e.Row.FindControl("lblFinalCount");
                //--------------------Edit-by-prabhaker-08-feb-17------------
                Label txtFactor = (Label)e.Row.FindControl("txtFactor");
                if (txtFactor != null)
                {
                    if (txtFactor.Text == "")
                        txtFactor.Text = "0";

                    TotalFact = TotalFact + Convert.ToDouble(txtFactor.Text);

                }
                //--------------------End-Edit-by-prabhaker-08-feb-17------------
                if (lblSAM != null)
                {
                    if (lblSAM.Text == "")
                        lblSAM.Text = "0";

                    TotalSam = TotalSam + Convert.ToDouble(lblSAM.Text);
                }
                if (lblMachineCount != null)
                {
                    if (lblMachineCount.Text == "")
                        lblMachineCount.Text = "0";

                    TotalMachine = TotalMachine + Convert.ToDouble(lblMachineCount.Text);
                }
                if (lblFinalCount != null)
                {
                    if (lblFinalCount.Text == "")
                        lblFinalCount.Text = "0";

                    FinalMachine = FinalMachine + Convert.ToDouble(lblFinalCount.Text);
                }

            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label lblSAMFooter = (Label)e.Row.FindControl("lblSAMFooter");
                //TotalSam
                if (TotalSam != 0)
                    lblSAMFooter.Text = TotalSam.ToString();

                Label lblMachineCountFooter = (Label)e.Row.FindControl("lblMachineCountFooter");
                //TotalSam
                if (TotalMachine != 0)
                    lblMachineCountFooter.Text = TotalMachine.ToString();

                Label lblFinalCountFooter = (Label)e.Row.FindControl("lblFinalCountFooter");
                //TotalSam 
                if (FinalMachine != 0)
                    lblFinalCountFooter.Text = FinalMachine.ToString();
                //edit by prabhaker 08-feb-17
                Label lblFactorFooter = (Label)e.Row.FindControl("lblFactorFooter");
                if (TotalFact != 0)
                {
                    lblFactorFooter.Text = TotalFact.ToString();
                }
                //end edit by prabhaker 08-feb-17
                TotalFact = 0;
                TotalSam = 0;
                TotalMachine = 0;
                FinalMachine = 0;
            }
        }
        //end new neck section


        // For Refrence Neck Facing Section
        protected void grdnewfacingref_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //return; 
                Literal ltIndex = (Literal)e.Row.FindControl("ltIndex");
                ltIndex.Text = (Convert.ToInt32(RowNumRef) + 1).ToString();
                RowNumRef = (Convert.ToInt32(RowNumRef) + 1);

                Label lblSAM = (Label)e.Row.FindControl("lblSAM");
                Label lblMachineCount = (Label)e.Row.FindControl("lblMachineCount");
                Label lblFinalCount = (Label)e.Row.FindControl("lblFinalCount");
                //--------------------Edit-by-prabhaker-08-feb-17------------
                Label txtFactor = (Label)e.Row.FindControl("txtFactor");
                if (txtFactor != null)
                {
                    if (txtFactor.Text == "")
                        txtFactor.Text = "0";

                    TotalFact = TotalFact + Convert.ToDouble(txtFactor.Text);

                }
                //--------------------End-Edit-by-prabhaker-08-feb-17------------
                if (lblSAM != null)
                {
                    if (lblSAM.Text == "")
                        lblSAM.Text = "0";

                    TotalSam = TotalSam + Convert.ToDouble(lblSAM.Text);
                }
                if (lblMachineCount != null)
                {
                    if (lblMachineCount.Text == "")
                        lblMachineCount.Text = "0";

                    TotalMachine = TotalMachine + Convert.ToDouble(lblMachineCount.Text);
                }
                if (lblFinalCount != null)
                {
                    if (lblFinalCount.Text == "")
                        lblFinalCount.Text = "0";

                    FinalMachine = FinalMachine + Convert.ToDouble(lblFinalCount.Text);
                }

            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label lblSAMFooter = (Label)e.Row.FindControl("lblSAMFooter");
                //TotalSam
                if (TotalSam != 0)
                    lblSAMFooter.Text = TotalSam.ToString();

                Label lblMachineCountFooter = (Label)e.Row.FindControl("lblMachineCountFooter");
                //TotalSam
                if (TotalMachine != 0)
                    lblMachineCountFooter.Text = TotalMachine.ToString();

                Label lblFinalCountFooter = (Label)e.Row.FindControl("lblFinalCountFooter");
                //TotalSam 
                if (FinalMachine != 0)
                    lblFinalCountFooter.Text = FinalMachine.ToString();
                //edit by prabhaker 08-feb-17
                Label lblFactorFooter = (Label)e.Row.FindControl("lblFactorFooter");
                if (TotalFact != 0)
                {
                    lblFactorFooter.Text = TotalFact.ToString();
                }
                //end edit by prabhaker 08-feb-17
                TotalFact = 0;
                TotalSam = 0;
                TotalMachine = 0;
                FinalMachine = 0;
            }
        }

        protected void grdfrontbackref_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //return; 
                Literal ltIndex = (Literal)e.Row.FindControl("ltIndex");
                ltIndex.Text = (Convert.ToInt32(RowNumRef) + 1).ToString();
                RowNumRef = (Convert.ToInt32(RowNumRef) + 1);

                Label lblSAM = (Label)e.Row.FindControl("lblSAM");
                Label lblMachineCount = (Label)e.Row.FindControl("lblMachineCount");
                Label lblFinalCount = (Label)e.Row.FindControl("lblFinalCount");
                //--------------------Edit-by-prabhaker-08-feb-17------------
                Label txtFactor = (Label)e.Row.FindControl("txtFactor");
                if (txtFactor != null)
                {
                    if (txtFactor.Text == "")
                        txtFactor.Text = "0";

                    TotalFact = TotalFact + Convert.ToDouble(txtFactor.Text);

                }
                //--------------------End-Edit-by-prabhaker-08-feb-17------------
                if (lblSAM != null)
                {
                    if (lblSAM.Text == "")
                        lblSAM.Text = "0";

                    TotalSam = TotalSam + Convert.ToDouble(lblSAM.Text);
                }
                if (lblMachineCount != null)
                {
                    if (lblMachineCount.Text == "")
                        lblMachineCount.Text = "0";

                    TotalMachine = TotalMachine + Convert.ToDouble(lblMachineCount.Text);
                }
                if (lblFinalCount != null)
                {
                    if (lblFinalCount.Text == "")
                        lblFinalCount.Text = "0";

                    FinalMachine = FinalMachine + Convert.ToDouble(lblFinalCount.Text);
                }

            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label lblSAMFooter = (Label)e.Row.FindControl("lblSAMFooter");
                //TotalSam
                if (TotalSam != 0)
                    lblSAMFooter.Text = TotalSam.ToString();

                Label lblMachineCountFooter = (Label)e.Row.FindControl("lblMachineCountFooter");
                //TotalSam
                if (TotalMachine != 0)
                    lblMachineCountFooter.Text = TotalMachine.ToString();

                Label lblFinalCountFooter = (Label)e.Row.FindControl("lblFinalCountFooter");
                //TotalSam 
                if (FinalMachine != 0)
                    lblFinalCountFooter.Text = FinalMachine.ToString();
                //edit by prabhaker 08-feb-17
                Label lblFactorFooter = (Label)e.Row.FindControl("lblFactorFooter");
                if (TotalFact != 0)
                {
                    lblFactorFooter.Text = TotalFact.ToString();
                }
                //end edit by prabhaker 08-feb-17
                TotalFact = 0;
                TotalSam = 0;
                TotalMachine = 0;
                FinalMachine = 0;
            }
        }
        //end new Neck Faching section

        //end by abhishek on 10/9/2015-------------------------------------------------------------//Abhishek 10/9/2015
        // For Refrence Finishing
        protected void grdOBFinishing_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //return;
                Literal ltIndex = (Literal)e.Row.FindControl("ltIndex");
                ltIndex.Text = (Convert.ToInt32(RowNumRef) + 1).ToString();
                RowNumRef = (Convert.ToInt32(RowNumRef) + 1);

                Label lblSAM = (Label)e.Row.FindControl("lblSAM");
                Label lblMachineCount = (Label)e.Row.FindControl("lblMachineCount");
                Label lblFinalCount = (Label)e.Row.FindControl("lblFinalCount");
                //--------------------Edit-by-prabhaker-08-feb-17------------
                Label txtFactor = (Label)e.Row.FindControl("txtFactor");
                //--------------------End-Edit-by-prabhaker-08-feb-17------------
                if (lblSAM != null)
                {
                    if (lblSAM.Text == "")
                        lblSAM.Text = "0";

                    TotalSam = TotalSam + Convert.ToDouble(lblSAM.Text);
                }
                if (lblMachineCount != null)
                {
                    if (lblMachineCount.Text == "")
                        lblMachineCount.Text = "0";

                    TotalMachine = TotalMachine + Convert.ToDouble(lblMachineCount.Text);
                }
                if (lblFinalCount != null)
                {
                    if (lblFinalCount.Text == "")
                        lblFinalCount.Text = "0";

                    FinalMachine = FinalMachine + Convert.ToDouble(lblFinalCount.Text);
                }


            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label lblSAMFooter = (Label)e.Row.FindControl("lblSAMFooter");
                //TotalSam
                if (TotalSam != 0)
                    lblSAMFooter.Text = TotalSam.ToString();

                Label lblMachineCountFooter = (Label)e.Row.FindControl("lblMachineCountFooter");
                //TotalSam
                if (TotalMachine != 0)
                    lblMachineCountFooter.Text = TotalMachine.ToString();

                Label lblFinalCountFooter = (Label)e.Row.FindControl("lblFinalCountFooter");
                //TotalSam 
                if (FinalMachine != 0)
                    lblFinalCountFooter.Text = FinalMachine.ToString();
                //edit by prabhaker 08-feb-17
                Label lblFactorFooter = (Label)e.Row.FindControl("lblFactorFooter");
                if (TotalFact != 0)
                {
                    lblFactorFooter.Text = TotalFact.ToString();
                }
                //end edit by prabhaker 08-feb-17
                TotalFact = 0;
                TotalSam = 0;
                TotalMachine = 0;
                FinalMachine = 0;
            }
        }

        // For Refrence OB Stiching Man Power
        //GrdStichingManPower_RowDataBound 
        protected void grdOBManPower_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //Edite By Ashish
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Literal ltIndex = (Literal)e.Row.FindControl("ltIndex");
                ltIndex.Text = ((GrdStichingManPower.PageIndex * GrdStichingManPower.PageSize) + e.Row.RowIndex + 1).ToString();

                Label lblMachineCost = (Label)e.Row.FindControl("lblMachineCost");
                Label lblMachineSAM = (Label)e.Row.FindControl("lblMachineSAM");
                Label lblNoOfMachine = (Label)e.Row.FindControl("lblNoOfMachine");
                Label lblTotalmachine = (Label)e.Row.FindControl("lblTotalmachine");
                Label lblTotalfactor = (Label)e.Row.FindControl("lblTotalfactor");
              

                if (lblMachineCost != null)
                {
                    if (lblMachineCost.Text == "")
                    {
                        lblMachineCost.Text = "0";
                    }
                    TotalManpowerCost = TotalManpowerCost + Convert.ToDouble(lblMachineCost.Text);


                }
                if (lblMachineSAM != null)
                {
                    if (lblMachineSAM.Text == "")
                    {
                        lblMachineSAM.Text = "0";
                    }
                    TotalManpowerSAM = TotalManpowerSAM + Convert.ToDouble(lblMachineSAM.Text);
                }

                if (lblNoOfMachine != null)
                {
                    if (lblNoOfMachine.Text == "")
                    {
                        lblNoOfMachine.Text = "0";
                    }
                    TotalManpowerNos = TotalManpowerNos + Convert.ToDouble(lblNoOfMachine.Text);
                }

                if (lblTotalmachine != null)
                {
                    if (lblTotalmachine.Text == "")
                    {
                        lblTotalmachine.Text = "0";
                    }
                    machinecalc = machinecalc + Convert.ToDouble(lblTotalmachine.Text);
                    lblTotalmanCount.Text = machinecalc.ToString();
                }

                //-----------edit by prabhaker-------//
                if (lblTotalfactor != null)
                {
                    if (lblTotalfactor.Text == "")
                    {
                        lblTotalfactor.Text = "0";
                    }
                    SFactor = SFactor + Convert.ToDouble(lblgrdTotalfactor.Text);

                }

                //----------end-of prabhaker--------------//

            }


            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label lblMachineCostTotal = (Label)e.Row.FindControl("lblMachineCostTotal");
                Label lblMachineSamTotal = (Label)e.Row.FindControl("lblMachineSamTotal");
                Label lblNoOfMachineTotal = (Label)e.Row.FindControl("lblNoOfMachineTotal");
                HiddenField hdnStitchSamTotal = (HiddenField)e.Row.FindControl("hdnStitchSamTotal");
                //Label lblgrdTotalfactor=(Label)e.Row.FindControl("lblgrdTotalfactor");
                Label txtFactor = (Label)e.Row.FindControl("txtFactor");
                //TotalSam
                if (TotalManpowerCost != 0)
                {
                    lblMachineCostTotal.Text = TotalManpowerCost.ToString();
                }
                if (TotalManpowerSAM != 0)
                {
                    lblMachineSamTotal.Text = TotalManpowerSAM.ToString();
                    hdnStitchSamTotal.Value = TotalManpowerSAM.ToString();
                    lblTodalOBStitching.Text = TotalManpowerSAM.ToString();
                }

                if (TotalManpowerNos != 0)
                {
                    lbltotalfinalmancount.Text = TotalManpowerNos.ToString();
                    lblNoOfMachineTotal.Text = TotalManpowerNos.ToString();
                }
                //-----------edit by prabhaker-------//
                if (lblgrdTotalfactor != null)
                {
                    if (lblgrdTotalfactor.Text == "")
                    {
                        lblgrdTotalfactor.Text = "0";
                    }
                    TotalgrdFact = TotalgrdFact + Convert.ToDouble(txtFactor.Text);

                }

                //----------end-of prabhaker--------------//
                TotalgrdFact=0;
                TotalManpowerCost = 0;
                TotalManpowerSAM = 0;
                TotalManpowerNos = 0;
            }
            //END
        }

        // For Refrence OB Finishing Man Power
        protected void grdOBFinishingManPower_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //Edite By Ashish
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Literal ltIndex = (Literal)e.Row.FindControl("ltIndex");
                ltIndex.Text = ((GrdFinishingManpower.PageIndex * GrdFinishingManpower.PageSize) + e.Row.RowIndex + 1).ToString();

                Label lblMachineCost = (Label)e.Row.FindControl("lblMachineCost");
                Label lblMachineSAM = (Label)e.Row.FindControl("lblMachineSAM");
                Label lblNoOfMachine = (Label)e.Row.FindControl("lblNoOfMachine");
                Label txtFactor=(Label)e.Row.FindControl("txtFactor");

                if (lblMachineCost != null)
                {
                    if (lblMachineCost.Text == "")
                    {
                        lblMachineCost.Text = "0";
                    }
                    TotalManpowerCost = TotalManpowerCost + Convert.ToDouble(lblMachineCost.Text);


                }
                if (lblMachineSAM != null)
                {
                    if (lblMachineSAM.Text == "")
                    {
                        lblMachineSAM.Text = "0";
                    }
                    TotalManpowerSAM = TotalManpowerSAM + Convert.ToDouble(lblMachineSAM.Text);
                }
                if (lblNoOfMachine != null)
                {
                    if (lblNoOfMachine.Text == "")
                    {
                        lblNoOfMachine.Text = "0";
                    }
                    TotalManpowerNos = TotalManpowerNos + Convert.ToDouble(lblNoOfMachine.Text);
                }
                //-----------edit by prabhaker-------//
                if (lblgrdTotalfactor != null)
                {
                    if (lblgrdTotalfactor.Text == "")
                    {
                        lblgrdTotalfactor.Text = "0";
                    }
                    TotalgrdFact = TotalgrdFact + Convert.ToDouble(txtFactor.Text);

                }

                //----------end-of prabhaker--------------//

            }


            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label lblMachineCostTotal = (Label)e.Row.FindControl("lblMachineCostTotal");
                Label lblMachineSamTotal = (Label)e.Row.FindControl("lblMachineSamTotal");
                HiddenField hdnFinishingSamTotal = (HiddenField)e.Row.FindControl("hdnFinishingSamTotal");
                Label lblNoOfMachineTotal = (Label)e.Row.FindControl("lblNoOfMachineTotal");
                //TotalSam
                if (TotalManpowerCost != 0)
                {
                    lblMachineCostTotal.Text = TotalManpowerCost.ToString();
                }
                if (TotalManpowerSAM != 0)
                {
                    lblMachineSamTotal.Text = TotalManpowerSAM.ToString();
                    hdnFinishingSamTotal.Value = TotalManpowerSAM.ToString();
                    lblTotalOBFinishing.Text = TotalManpowerSAM.ToString();
                    lblNoOfMachineTotal.Text=TotalManpowerNos.ToString();
                   
                }
                if (TotalManpowerNos != 0)
                {
                    lblNoOfMachineTotal.Text = TotalManpowerNos.ToString();
                }

                if (TotalgrdFact != 0)
                {
                    lblgrdTotalfactor.Text = TotalgrdFact.ToString();
                }

                TotalgrdFact = 0;
                TotalManpowerCost = 0;
                TotalManpowerSAM = 0;
                TotalManpowerNos = 0;
            }
            //END
        }

        protected void grdNeckFacing_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}