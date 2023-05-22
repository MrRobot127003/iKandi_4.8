using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using iKandi.Common;
using iKandi.Common.Entities;
using System.Text.RegularExpressions;
using System.Web.UI.HtmlControls;
using System.Drawing;
using iKandi.Web.Components;
using System.IO;
using iKandi.BLL;



namespace iKandi.Web.UserControls.Forms
{
    public partial class HOPPM : System.Web.UI.UserControl
    {
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
        public int ReUseStyleId
        {
            get;
            set;
        }
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
        public iTextSharp.text.Color DescriptionForColor
        {
            get;
            set;
        }
        int sl = 0;
        String FitsFolderPath = "~/" + System.Configuration.ConfigurationManager.AppSettings["inlineppm.docs.folder"];
        iKandi.BLL.OrderController obj_OrderController = new BLL.OrderController();
        iKandi.BLL.OrderProcessController obj_ProcessController = new BLL.OrderProcessController();
        iKandi.BLL.WorkflowController WorkflowControllerInstance = new BLL.WorkflowController();
        iKandi.BLL.StyleController StyleControllerInstance = new BLL.StyleController();


        public int styleid
        {
            get;
            set;
        }
        public string stylenumber
        {
            get;
            set;
        }
        public int strClientId
        {
            get;
            set;
        }
        public int DepartmentId
        {
            get;
            set;
        }
        public int CheckFirstTime
        {
            get;
            set;
        }
        public int OrderID
        {
            get;
            set;
        }

        #region "Event Use For F5 Functionality"
        //protected void Page_PreRender(object sender, EventArgs e)
        //{

        //    ViewState["Time"] = Session["Time"];
        //}
        #endregion

        string strRepeatOrderCheck = "";
        bool bRepeatCheck = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (iKandi.Web.Components.ApplicationHelper.LoggedInUser == null || iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData == null)
                Response.Redirect("~/public/Login.aspx");       

            GetQueryString();
            if (null == Request.QueryString["showHOPPMFORM"])
            {
              return;
            }
            if (!IsPostBack)
            {
                //HiddenField hdnShowForm = (HiddenField)this.Parent.FindControl("hdnShowForm");
                //if (hdnShowForm != null)
                //{
                //    if (hdnShowForm.Value != "0")
                //        return;
                //}
                strRepeatOrderCheck = StyleControllerInstance.IsRepeatedStyle(styleid);
                if (strRepeatOrderCheck != "1")
                    bRepeatCheck = true;

                ShowGridPopup.Visible = false;
                BindControl(0, 0, 0, -1, "");
                BindRemarkGrd(0, 0, 0, -1, "", true);
                BindAccessoriesGrd(0, 0, 0, -1, "", true);
                // Bind RndGrd here
                BindgrdRiskRnD(0, 0, 0, -1, "", true);
                // End of RndGrid
                BindFitingGrd(0, 0, 0, -1, "", true);
                BindMakingGrd(0, 0, 0, -1, "", true);
                BindImbroideryGrd(0, 0, 0, -1, "", true);
                BindWashingGrd(0, 0, 0, -1, "", true);
                BindFinishingGrd(0, 0, 0, -1, "", true);
                Session["Time"] = DateTime.Now.ToString();
                hdnstylenumber.Value = stylenumber;
                hdnStyleId.Value = styleid.ToString();
                SetHoppmPermission();
            }


            if (chkHOPPMComplete.Enabled == false && chkHOPPMComplete.Checked == false)
            {
                lblTaskMsg.Visible = true;
            }
            else
            {
                lblTaskMsg.Visible = false;
            }
            //----------------For repeat order case if repeat order then both signature would be enabled--------------
            //if (bRepeatCheck == true)
            //{
            //    chkProdQAMgr.Enabled = true;
            //    chkMM.Enabled = true;
            //    chkHOPPMComplete.Checked = false;
            //    chkProdQAMgr.Checked = false;
            //    chkMM.Checked = false;
            //    chkFactoryPPMComplete.Enabled = false;
            //    chkSeamSlippage.Enabled = false;

            //}
            // -----------------------------------------------------------------------------------------------------------
        }

        protected void SetHoppmPermission()
        {
            DataTable dtPermission = new DataTable();

            int DeptId = iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.PrimaryGroupID;
            int DesigId = Convert.ToInt32(ApplicationHelper.LoggedInUser.UserData.Designation);
            int IsFinalOB = 0;
            IsFinalOB = WorkflowControllerInstance.IsFinalOBDone(styleid, TaskMode.Final_OB, "HOPPM");

            dtPermission = obj_OrderController.GetOBPermission(DeptId, DesigId, 262);

            if (dtPermission.Rows.Count > 0)
            {
                for (int ipermission = 0; ipermission < dtPermission.Rows.Count; ipermission++)
                {
                    int ColumnId = Convert.ToInt32(dtPermission.Rows[ipermission]["Technicalsectionid"]);
                    int SectionId = Convert.ToInt32(dtPermission.Rows[ipermission]["TechnicalFormsID"]);

                    string searchId = "Technicalsectionid =" + ColumnId;
                    DataRow[] dRow = dtPermission.Select(searchId);

                    //if (SectionId == 2)
                    //{
                    if (ColumnId == 188)
                    {
                        foreach (DataRow dr in dRow)
                        {
                            grdHoppmFabricRemark.Visible = true;
                            grdHoppmFabricRemark.Enabled = (dr["PermisionWrite"] == DBNull.Value) ? false : Convert.ToBoolean(dr["PermisionWrite"]);
                            for (int i = 0; i < grdHoppmFabricRemark.Rows.Count; i++)
                            {
                                LinkButton LinkButton = (LinkButton)grdHoppmFabricRemark.Rows[i].FindControl("lnkDelete");
                                if (LinkButton != null)
                                    LinkButton.Visible = (dr["PermisionWrite"] == DBNull.Value) ? false : Convert.ToBoolean(dr["PermisionWrite"]);
                            }
                        }
                    }

                    if (ColumnId == 189)
                    {
                        foreach (DataRow dr in dRow)
                        {
                            grdRiskAccessories.Visible = true;
                            grdRiskAccessories.Enabled = (dr["PermisionWrite"] == DBNull.Value) ? false : Convert.ToBoolean(dr["PermisionWrite"]);
                            for (int i = 0; i < grdRiskAccessories.Rows.Count; i++)
                            {
                                LinkButton LinkButton = (LinkButton)grdRiskAccessories.Rows[i].FindControl("lnkDelete");
                                if (LinkButton != null)
                                    LinkButton.Visible = (dr["PermisionWrite"] == DBNull.Value) ? false : Convert.ToBoolean(dr["PermisionWrite"]);
                            }
                        }
                    }

                    if (ColumnId == 227)
                    {
                        foreach (DataRow dr in dRow)
                        {
                            grdRiskRnD.Visible = true;
                            grdRiskRnD.Enabled = (dr["PermisionWrite"] == DBNull.Value) ? false : Convert.ToBoolean(dr["PermisionWrite"]);
                            for (int i = 0; i < grdRiskRnD.Rows.Count; i++)
                            {
                                LinkButton LinkButton = (LinkButton)grdRiskRnD.Rows[i].FindControl("lnkDelete");
                                if (LinkButton != null)
                                    LinkButton.Visible = (dr["PermisionWrite"] == DBNull.Value) ? false : Convert.ToBoolean(dr["PermisionWrite"]);
                            }
                        }
                    }

                    if (ColumnId == 190)
                    {
                        foreach (DataRow dr in dRow)
                        {
                            grdriskFiting.Visible = true;
                            grdriskFiting.Enabled = (dr["PermisionWrite"] == DBNull.Value) ? false : Convert.ToBoolean(dr["PermisionWrite"]);
                            for (int i = 0; i < grdriskFiting.Rows.Count; i++)
                            {
                                LinkButton LinkButton = (LinkButton)grdriskFiting.Rows[i].FindControl("lnkDelete");
                                if (LinkButton != null)
                                    LinkButton.Visible = (dr["PermisionWrite"] == DBNull.Value) ? false : Convert.ToBoolean(dr["PermisionWrite"]);
                            }
                        }
                    }

                    if (ColumnId == 191)
                    {
                        foreach (DataRow dr in dRow)
                        {
                            grdRiskMaking.Visible = true;
                            grdRiskMaking.Enabled = (dr["PermisionWrite"] == DBNull.Value) ? false : Convert.ToBoolean(dr["PermisionWrite"]);
                            for (int i = 0; i < grdRiskMaking.Rows.Count; i++)
                            {
                                LinkButton LinkButton = (LinkButton)grdRiskMaking.Rows[i].FindControl("lnkDelete");
                                if (LinkButton != null)
                                    LinkButton.Visible = (dr["PermisionWrite"] == DBNull.Value) ? false : Convert.ToBoolean(dr["PermisionWrite"]);
                            }
                        }
                    }

                    if (ColumnId == 192)
                    {
                        foreach (DataRow dr in dRow)
                        {
                            grdRiskImbroidery.Visible = true;
                            grdRiskImbroidery.Enabled = (dr["PermisionWrite"] == DBNull.Value) ? false : Convert.ToBoolean(dr["PermisionWrite"]);
                            for (int i = 0; i < grdRiskImbroidery.Rows.Count; i++)
                            {
                                LinkButton LinkButton = (LinkButton)grdRiskImbroidery.Rows[i].FindControl("lnkDelete");
                                if (LinkButton != null)
                                    LinkButton.Visible = (dr["PermisionWrite"] == DBNull.Value) ? false : Convert.ToBoolean(dr["PermisionWrite"]);
                            }
                        }
                    }

                    if (ColumnId == 193)
                    {
                        foreach (DataRow dr in dRow)
                        {
                            grdRiskWashing.Visible = true;
                            grdRiskWashing.Enabled = (dr["PermisionWrite"] == DBNull.Value) ? false : Convert.ToBoolean(dr["PermisionWrite"]);
                            for (int i = 0; i < grdRiskWashing.Rows.Count; i++)
                            {
                                LinkButton LinkButton = (LinkButton)grdRiskWashing.Rows[i].FindControl("lnkDelete");
                                if (LinkButton != null)
                                    LinkButton.Visible = (dr["PermisionWrite"] == DBNull.Value) ? false : Convert.ToBoolean(dr["PermisionWrite"]);
                            }
                        }
                    }
                    if (ColumnId == 194)
                    {
                        foreach (DataRow dr in dRow)
                        {
                            grdRiskFinishing.Visible = true;
                            grdRiskFinishing.Enabled = (dr["PermisionWrite"] == DBNull.Value) ? false : Convert.ToBoolean(dr["PermisionWrite"]);
                            for (int i = 0; i < grdRiskFinishing.Rows.Count; i++)
                            {
                                LinkButton LinkButton = (LinkButton)grdRiskFinishing.Rows[i].FindControl("lnkDelete");
                                if (LinkButton != null)
                                    LinkButton.Visible = (dr["PermisionWrite"] == DBNull.Value) ? false : Convert.ToBoolean(dr["PermisionWrite"]);
                            }
                        }
                    }
                    if (ColumnId == 195)
                    {
                        foreach (DataRow dr in dRow)
                        {
                            btnAddFactory.Visible = true;
                            btnAddFactory.Visible = (dr["PermisionWrite"] == DBNull.Value) ? false : Convert.ToBoolean(dr["PermisionWrite"]);
                        }
                    }
                    if (ColumnId == 196)
                    {
                        foreach (DataRow dr in dRow)
                        {
                            btnAddQa.Visible = true;
                            btnAddQa.Visible = (dr["PermisionWrite"] == DBNull.Value) ? false : Convert.ToBoolean(dr["PermisionWrite"]);
                        }
                    }

                    if (ColumnId == 197)
                    {
                        foreach (DataRow dr in dRow)
                        {
                            /*abhishek
                          //  chkPreProdQAMgr.Visible = true;
                            //chkPreProdQAMgr.Enabled = (dr["PermisionWrite"] == DBNull.Value) ? false : Convert.ToBoolean(dr["PermisionWrite"]);
                            //if (chkPreProdQAMgr.Enabled == true)
                            //{
                            //    if (chkPreProdQAMgr.Checked == true && chkProdQAMgr.Checked == true && chkMM.Checked == true && chkFactoryPPMComplete.Checked == true && chkHOPPMComplete.Checked == true)
                            //    {
                            //        NewRefrence = Convert.ToInt32(hdnHoppmNewRef.Value);
                            //        if (NewRefrence == 1)
                            //        {
                            //            FinalHoppmDone(1);
                            //        }
                            //        else
                            //        {
                            //            chkPreProdQAMgr.Enabled = false;
                            //            FinalHoppmDone(2);
                            //        }
                            //    }
                            //}
                            */
                        }
                    }

                    if (ColumnId == 198)
                    {
                        foreach (DataRow dr in dRow)
                        {
                            chkProdQAMgr.Visible = true;
                            chkProdQAMgr.Enabled = (dr["PermisionWrite"] == DBNull.Value) ? false : Convert.ToBoolean(dr["PermisionWrite"]);
                            if (chkProdQAMgr.Enabled == true)
                            {
                                if (chkProdQAMgr.Checked == true && chkMM.Checked == true && chkFactoryPPMComplete.Checked == true && chkHOPPMComplete.Checked == true && chkSeamSlippage.Checked == true)
                                {
                                    NewRefrence = Convert.ToInt32(hdnHoppmNewRef.Value);
                                    if (NewRefrence == 1)
                                    {
                                        FinalHoppmDone(1);
                                    }
                                    else
                                    {
                                        chkProdQAMgr.Enabled = false;
                                        FinalHoppmDone(2);
                                    }
                                }
                            }
                        }
                    }

                    if (ColumnId == 199)
                    {
                        foreach (DataRow dr in dRow)
                        {
                            chkMM.Visible = true;
                            chkMM.Enabled = (dr["PermisionWrite"] == DBNull.Value) ? false : Convert.ToBoolean(dr["PermisionWrite"]);
                            if (chkMM.Enabled == true)
                            {
                                if (chkProdQAMgr.Checked == true && chkMM.Checked == true && chkFactoryPPMComplete.Checked == true && chkHOPPMComplete.Checked == true && chkSeamSlippage.Checked == true)
                                {
                                    NewRefrence = Convert.ToInt32(hdnHoppmNewRef.Value);
                                    if (NewRefrence == 1)
                                    {
                                        FinalHoppmDone(1);
                                    }
                                    else
                                    {
                                        chkMM.Enabled = false;
                                        FinalHoppmDone(2);
                                    }
                                }
                            }

                        }
                    }
                    if (ColumnId == 200)
                    {
                        foreach (DataRow dr in dRow)
                        {
                            chkFactoryPPMComplete.Visible = true;
                            chkFactoryPPMComplete.Enabled = (dr["PermisionWrite"] == DBNull.Value) ? false : Convert.ToBoolean(dr["PermisionWrite"]);
                            if (chkFactoryPPMComplete.Enabled == true)
                            {
                                if (chkProdQAMgr.Checked == true && chkMM.Checked == true && chkFactoryPPMComplete.Checked == true && chkHOPPMComplete.Checked == true && chkSeamSlippage.Checked == true)
                                {
                                    NewRefrence = Convert.ToInt32(hdnHoppmNewRef.Value);
                                    if (NewRefrence == 1)
                                    {
                                        FinalHoppmDone(1);
                                    }
                                    else
                                    {
                                        chkFactoryPPMComplete.Enabled = false;
                                        FinalHoppmDone(2);
                                    }
                                }
                            }
                        }
                    }
                    if (ColumnId == 201)
                    {
                        foreach (DataRow dr in dRow)
                        {
                            chkHOPPMComplete.Visible = true;
                            chkHOPPMComplete.Enabled = (dr["PermisionWrite"] == DBNull.Value) ? false : Convert.ToBoolean(dr["PermisionWrite"]);
                            if (chkHOPPMComplete.Enabled == true)
                            {
                                if (IsFinalOB == 0)
                                {
                                    chkHOPPMComplete.Enabled = false;
                                }
                                else
                                {
                                    chkHOPPMComplete.Enabled = true;
                                }
                                if (chkProdQAMgr.Checked == true && chkMM.Checked == true && chkFactoryPPMComplete.Checked == true && chkHOPPMComplete.Checked == true && chkSeamSlippage.Checked == true)
                                {
                                    NewRefrence = Convert.ToInt32(hdnHoppmNewRef.Value);
                                    if (NewRefrence == 1)
                                    {
                                        FinalHoppmDone(1);
                                    }
                                    else
                                    {
                                        chkHOPPMComplete.Enabled = false;
                                        FinalHoppmDone(2);
                                    }
                                }
                            }

                        }
                    }
                    //abhishek 
                    if (ColumnId == 201) //colmn id need to be chnage right now taking ref of HOPPm complete
                    {
                        foreach (DataRow dr in dRow)
                        {
                            chkSeamSlippage.Visible = true;
                            chkSeamSlippage.Enabled = (dr["PermisionWrite"] == DBNull.Value) ? false : Convert.ToBoolean(dr["PermisionWrite"]);
                            //bool checkeds=(dr["PermisionWrite"] == DBNull.Value) ? false : Convert.ToBoolean(dr["PermisionWrite"]);
                            if (chkSeamSlippage.Checked == true)
                            {
                                if (IsFinalOB == 0)
                                {
                                    //chkHOPPMComplete.Enabled = false;
                                    chkSeamSlippage.Enabled = false;
                                }
                                else
                                {
                                    //chkHOPPMComplete.Enabled = true;

                                    chkSeamSlippage.Enabled = true;
                                }
                                if (chkProdQAMgr.Checked == true && chkMM.Checked == true && chkFactoryPPMComplete.Checked == true && chkHOPPMComplete.Checked == true && chkSeamSlippage.Checked == true)
                                {
                                    NewRefrence = Convert.ToInt32(hdnHoppmNewRef.Value);
                                    if (NewRefrence == 1)
                                    {
                                        FinalHoppmDone(1);
                                    }
                                    else
                                    {
                                        //chkHOPPMComplete.Enabled = false;
                                        chkSeamSlippage.Enabled = false;
                                        FinalHoppmDone(2);
                                    }
                                }
                            }

                        }
                    }

                    if (ColumnId == 202)
                    {
                        foreach (DataRow dr in dRow)
                        {
                            btnSubmit.Visible = true;
                            btnSubmit.Enabled = (dr["PermisionWrite"] == DBNull.Value) ? false : Convert.ToBoolean(dr["PermisionWrite"]);
                        }
                    }
                    if (ColumnId == 203)
                    {
                        foreach (DataRow dr in dRow)
                        {
                            repStyleCodeVirsion.Visible = true;
                            repStyleCodeVirsion.Visible = (dr["PermisionWrite"] == DBNull.Value) ? false : Convert.ToBoolean(dr["PermisionWrite"]);
                        }
                    }

                    string ActionDate = string.Empty;


                    if (ColumnId == 41)//not in use
                    {
                        foreach (DataRow dr in dRow)
                        {
                            btnFile1Upload.Visible = true;
                            btnFile1Upload.Visible = (dr["PermisionWrite"] == DBNull.Value) ? false : Convert.ToBoolean(dr["PermisionWrite"]);
                        }
                    }

                }
            }
            else
            {
                grdHoppmFabricRemark.Visible = false;
                grdRiskAccessories.Visible = false;
                grdriskFiting.Visible = false;
                grdRiskMaking.Visible = false;
                grdRiskImbroidery.Visible = false;
                grdRiskWashing.Visible = false;
                grdRiskFinishing.Visible = false;
                btnAddFactory.Visible = false;
                btnAddQa.Visible = false;
                repStyleCodeVirsion.Visible = false;
                // chkPreProdQAMgr.Visible = false;
                chkProdQAMgr.Visible = false;
                chkMM.Visible = false;
                chkFactoryPPMComplete.Visible = false;
                chkHOPPMComplete.Visible = false;
                chkSeamSlippage.Visible = false;
                btnSubmit.Visible = false;
            }

        }

        private void GetQueryString()
        {

            if (null != Request.QueryString["styleid"])
            {
                styleid = Convert.ToInt32(Request.QueryString["styleid"].ToString());
            }
            if (null != Request.QueryString["stylenumber"])
            {
                stylenumber = Request.QueryString["stylenumber"].ToString();
            }
            if (null != Request.QueryString["ClientID"])
            {
                strClientId = Convert.ToInt32(Request.QueryString["ClientID"].ToString());
            }
            if (null != Request.QueryString["DeptId"])
            {
                DepartmentId = Convert.ToInt32(Request.QueryString["DeptId"].ToString());
            }
            if (null != Request.QueryString["OrderID"])
            {
                OrderID = Convert.ToInt32(Request.QueryString["OrderID"].ToString());
            }

            
        }

        private void FinalHoppmDone(int Flag)
        {
            if (Flag == 1)
            {
                grdHoppmFabricRemark.Enabled = true;
                grdRiskAccessories.Enabled = true;
                // enable the RnD grid
                grdriskFiting.Enabled = true;
                grdRiskMaking.Enabled = true;
                grdRiskImbroidery.Enabled = true;
                grdRiskWashing.Enabled = true;
                grdRiskFinishing.Enabled = true;
                hdnEnableFalse.Value = "0";
                btnSubmit.Visible = true;
                btnFile1Upload.Visible = false;
            }
            else
            {
                grdHoppmFabricRemark.Enabled = false;
                grdRiskAccessories.Enabled = false;
                // disable the RnD grid
                grdriskFiting.Enabled = false;
                grdRiskMaking.Enabled = false;
                grdRiskImbroidery.Enabled = false;
                grdRiskWashing.Enabled = false;
                grdRiskFinishing.Enabled = false;
                hdnEnableFalse.Value = "1";
                btnSubmit.Visible = false;
                btnFile1Upload.Visible = false;




            }
        }

        private void BindControl(int CreateNew, int NewRef, int ReUse, int ReUseStyleId, string ReUseStyleNumber)
        {
            //Label lblBasicInformation = (Label)this.Parent.FindControl("lblBasicInformation");
            DataSet dsStyle = obj_ProcessController.GetStyleNumberClientDept(styleid, ReUseStyleId, strClientId, DepartmentId, CreateNew, NewRef, ReUse, 4);
            if (dsStyle.Tables[0].Rows.Count > 0)
            {
                string StyleDetail = "";
                for (int i = 0; i < dsStyle.Tables[0].Rows.Count; i++)
                {
                    StyleDetail = StyleDetail + " [" + dsStyle.Tables[0].Rows[i]["StyleDetail"].ToString() + "],";
                }

                lblHoBasicInformation.Text = StyleDetail.TrimEnd(',');
            }

            DataTable dtPermission = new DataTable();
            List<OrderDetail> OdList = new List<OrderDetail>();
            int desigId = Convert.ToInt32(iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.Designation);
            int DeptId = Convert.ToInt32(iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.PrimaryGroupID);
            //Edited By Ashish on 17/8/2015 for comment Mo grid Becouse it no need
            //OdList = obj_OrderController.GetMoInfo(styleid, strClientId, DepartmentId, CreateNew, NewRef, ReUse, ReUseStyleId, 4);
            //if (OdList.Count >= 3)
            //{
            //    dvGvHoppm.Attributes.Add("style", "height:500px; overflow-x: hidden; overflow-y: auto;");
            //}
            //else
            //{
            //    dvGvHoppm.Attributes.Add("style", "height:300px; overflow-x: hidden; overflow-y: auto;");
            //}
            //if (OdList.Count > 0)
            //{
            //    gvHOPPM.DataSource = OdList;
            //    gvHOPPM.DataBind();
            //}

            DataTable dtStyleDetails = new DataTable();
            dtStyleDetails = obj_ProcessController.GetStyleNumber(styleid);

            string Serial = "";
            string ContractNumber = "";
            if (dtStyleDetails.Rows.Count > 0)
            {

                for (int i = 0; i < dtStyleDetails.Rows.Count; i++)
                {
                    if (dtStyleDetails.Rows[i]["SerialNumber"].ToString() != "")
                    {
                        Serial = Serial + dtStyleDetails.Rows[i]["SerialNumber"].ToString() + ",";
                    }
                    ContractNumber = ContractNumber + dtStyleDetails.Rows[i]["ContractNumber"].ToString() + ",";
                }

                Serial = Serial.TrimEnd(',');
                ContractNumber = ContractNumber.TrimEnd(',');
            }

            if (dtStyleDetails.Rows.Count > 0)
            {
                string ClientName = dtStyleDetails.Rows[0]["CompanyName"].ToString();
                string StyleNo = dtStyleDetails.Rows[0]["StyleNumber"].ToString();

                lblClient.Text = ClientName;
                lblStyle.Text = StyleNo;

                lblSerialNo.Text = Serial;
                lblCN.Text = ContractNumber;

                //imgstyle
                string ImageName = dtStyleDetails.Rows[0]["SampleImageURL1"].ToString();

                if (!String.IsNullOrEmpty(ImageName))
                {
                    imgstyle.ImageUrl = "~/" + System.Configuration.ConfigurationManager.AppSettings["style.folder"] + System.Configuration.ConfigurationManager.AppSettings["image.prefix"] + ImageName;

                }
                else
                {
                    imgstyle.Visible = false;
                }

            }
            DataSet dsHoPPM = obj_ProcessController.GetHOPPM(stylenumber, styleid, strClientId, DepartmentId, CreateNew, NewRef, ReUse, ReUseStyleId);

            hdnQaRepresentativeId.Value = dsHoPPM.Tables[0].Rows[0]["QaRepresentativeIds"].ToString();

            dvQaRepresentativeValues.InnerHtml = "";
            string strId = dsHoPPM.Tables[0].Rows[0]["QaRepresentativeIds"].ToString();
            string[] strIdArray = strId.Split(',');
            string strValue = dsHoPPM.Tables[0].Rows[0]["QaRepresentativeNames"].ToString();
            string[] strValueArray = strValue.Split(',');
            hdnCounter.Value = "0";
            if (strValueArray.Length > 0 && strValueArray[0] != "")
            {
                for (int iQaRepresentativeId = 1; iQaRepresentativeId <= strValueArray.Length; iQaRepresentativeId++)
                {
                    if (iQaRepresentativeId == 1)
                    {
                        dvQaRepresentativeValues.InnerHtml = "<span id=\"dvQaRepresentative" + iQaRepresentativeId + "\"><span>" + strValueArray[iQaRepresentativeId - 1] + " <a class=\"remove_field\" onclick=\"DeleteQaRepresentative(" + iQaRepresentativeId + ", " + strIdArray[iQaRepresentativeId - 1] + ", '" + strValueArray[iQaRepresentativeId - 1] + "')\"><img src=\"../../images/delete.png\" /></a></span></span>";
                    }
                    else
                    {
                        dvQaRepresentativeValues.InnerHtml += "<span id=\"dvQaRepresentative" + iQaRepresentativeId + "\"><span>," + strValueArray[iQaRepresentativeId - 1] + " <a class=\"remove_field\" onclick=\"DeleteQaRepresentative(" + iQaRepresentativeId + ", " + strIdArray[iQaRepresentativeId - 1] + ", '" + strValueArray[iQaRepresentativeId - 1] + "')\"><img src=\"../../images/delete.png\" /></a></span></span>";
                    }
                    hdnCounter.Value = iQaRepresentativeId.ToString();
                }
            }

            hdnQaRepresentativeName.Value = dsHoPPM.Tables[0].Rows[0]["QaRepresentativeNames"].ToString();

            hdnFactoryRepresentativeId.Value = dsHoPPM.Tables[0].Rows[0]["FactoryRepresentativeIds"].ToString();

            dvFactoryRepresentativeValues.InnerHtml = "";
            string strFactoryId = dsHoPPM.Tables[0].Rows[0]["FactoryRepresentativeIds"].ToString();
            string[] strFactoryIdArray = strFactoryId.Split(',');
            string strFactoryValue = dsHoPPM.Tables[0].Rows[0]["FactoryRepresentativeNames"].ToString();
            string[] strFactoryValueArray = strFactoryValue.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            hdnFactoryCounter.Value = "0";
            if (strFactoryValueArray.Length > 0 && strFactoryValueArray[0] != "")
            {
                for (int iFactoryRepresentativeId = 1; iFactoryRepresentativeId <= strFactoryValueArray.Length; iFactoryRepresentativeId++)
                {
                    if (iFactoryRepresentativeId == 1)
                    {
                        dvFactoryRepresentativeValues.InnerHtml = "<span id=\"dvFactoryRepresentative" + iFactoryRepresentativeId + "\"><span>" + strFactoryValueArray[iFactoryRepresentativeId - 1] + " <a class=\"remove_field\" onclick=\"DeleteFactoryRepresentative(" + iFactoryRepresentativeId + ", " + strFactoryIdArray[iFactoryRepresentativeId - 1] + ", '" + strFactoryValueArray[iFactoryRepresentativeId - 1] + "')\"><img src=\"../../images/delete.png\" /></a></span></span>";
                    }
                    else
                    {
                        string factoryRepresentative = "0";
                        if (strFactoryIdArray.Length >= (iFactoryRepresentativeId))
                        {
                            factoryRepresentative = strFactoryIdArray[iFactoryRepresentativeId - 1].ToString();
                        }

                        dvFactoryRepresentativeValues.InnerHtml += "<span id=\"dvFactoryRepresentative" + iFactoryRepresentativeId + "\"><span>," + strFactoryValueArray[iFactoryRepresentativeId - 1] + " <a class=\"remove_field\" onclick=\"DeleteFactoryRepresentative(" + iFactoryRepresentativeId + ", " + factoryRepresentative + ", '" + strFactoryValueArray[iFactoryRepresentativeId - 1] + "')\"><img src=\"../../images/delete.png\" /></a></span></span>";
                    }
                    hdnFactoryCounter.Value = iFactoryRepresentativeId.ToString();
                }
            }

            hdnFactoryRepresentativeName.Value = dsHoPPM.Tables[0].Rows[0]["FactoryRepresentativeNames"].ToString();

            //
            hdnMerchandiserRepresentativeId.Value = dsHoPPM.Tables[0].Rows[0]["MerchandiserRepresentativeIds"].ToString();

            dvMerchandiserRepresentativeValues.InnerHtml = "";
            string strMerchandiserId = dsHoPPM.Tables[0].Rows[0]["MerchandiserRepresentativeIds"].ToString();
            string[] strMerchandiserIdArray = strMerchandiserId.Split(',');
            string strMerchandiserValue = dsHoPPM.Tables[0].Rows[0]["MerchandiserRepresentativeName"].ToString();
            string[] strMerchandiserValueArray = strMerchandiserValue.Split(',');
            hdnMerchandiserCounter.Value = "0";
            if (strMerchandiserValueArray.Length > 0 && strMerchandiserValueArray[0] != "")
            {
                for (int iMerchandiserRepresentativeId = 1; iMerchandiserRepresentativeId <= strMerchandiserValueArray.Length; iMerchandiserRepresentativeId++)
                {
                    if (iMerchandiserRepresentativeId == 1)
                    {
                        dvMerchandiserRepresentativeValues.InnerHtml = "<span id=\"dvMerchandiserRepresentative" + iMerchandiserRepresentativeId + "\"><span>" + strMerchandiserValueArray[iMerchandiserRepresentativeId - 1] + " <a class=\"remove_field\" onclick=\"DeleteMerchandiserRepresentative(" + iMerchandiserRepresentativeId + ", " + strMerchandiserIdArray[iMerchandiserRepresentativeId - 1] + ", '" + strMerchandiserValueArray[iMerchandiserRepresentativeId - 1] + "')\"><img src=\"../../images/delete.png\" /></a></span></span>";
                    }
                    else
                    {
                        dvMerchandiserRepresentativeValues.InnerHtml += "<span id=\"dvMerchandiserRepresentative" + iMerchandiserRepresentativeId + "\"><span>," + strMerchandiserValueArray[iMerchandiserRepresentativeId - 1] + " <a class=\"remove_field\" onclick=\"DeleteMerchandiserRepresentative(" + iMerchandiserRepresentativeId + ", " + strMerchandiserIdArray[iMerchandiserRepresentativeId - 1] + ", '" + strMerchandiserValueArray[iMerchandiserRepresentativeId - 1] + "')\"><img src=\"../../images/delete.png\" /></a></span></span>";
                    }
                    hdnMerchandiserCounter.Value = iMerchandiserRepresentativeId.ToString();
                }
            }

            hdnMerchandiserRepresentativeName.Value = dsHoPPM.Tables[0].Rows[0]["MerchandiserRepresentativeName"].ToString();


            // Add
            string File1 = dsHoPPM.Tables[0].Rows[0]["UploadSnap1"].ToString();
            hlkViewSnap1.Visible = (string.IsNullOrEmpty(File1)) ? false : true;
            hlkViewSnap1.NavigateUrl = (string.IsNullOrEmpty(File1)) ? "" : FitsFolderPath + File1;
            hdnSnap1.Value = (string.IsNullOrEmpty(File1)) ? "" : File1;

            string File2 = dsHoPPM.Tables[0].Rows[0]["UploadSnap2"].ToString();
            hlkViewSnap2.Visible = (string.IsNullOrEmpty(File2)) ? false : true;
            hlkViewSnap2.NavigateUrl = (string.IsNullOrEmpty(File2)) ? "" : FitsFolderPath + File2;
            hdnSnap2.Value = (string.IsNullOrEmpty(File2)) ? "" : File2;

            //

            //chkPreProdQAMgr.Checked = Convert.ToBoolean(dsHoPPM.Tables[0].Rows[0]["IsQAPreProdApprovedOn"]);
            chkProdQAMgr.Checked = Convert.ToBoolean(dsHoPPM.Tables[0].Rows[0]["IsQAProdApprovedOn"]);
            chkMM.Checked = Convert.ToBoolean(dsHoPPM.Tables[0].Rows[0]["IsMerchandisingManagerApprovedOn"]);
            chkFactoryPPMComplete.Checked = Convert.ToBoolean(dsHoPPM.Tables[0].Rows[0]["IsFactoryPPMComplete"]);
            chkHOPPMComplete.Checked = Convert.ToBoolean(dsHoPPM.Tables[0].Rows[0]["IsHOPPMComplete"]);

            chkSeamSlippage.Checked = Convert.ToBoolean(dsHoPPM.Tables[0].Rows[0]["Seam_Slippage_OK"]);

            //if (((chkPreProdQAMgr.Checked) && (chkProdQAMgr.Checked)) && ((chkFactoryPPMComplete.Checked) || (chkHOPPMComplete.Checked)))
            //{
            //    chkMM.Enabled = true;
            //}
            //else
            //{
            //    chkMM.Enabled = false;
            //}


            //if (chkFactoryPPMComplete.Checked == true)
            //{
            //    chkHOPPMComplete.Enabled = true;
            //}
            //else
            //{
            //    chkHOPPMComplete.Enabled = false;
            //}


            //END

            if (chkMM.Checked)
            {
                //chkPreProdQAMgr.Enabled = false;
                chkProdQAMgr.Enabled = false;
                chkFactoryPPMComplete.Enabled = false;
                chkHOPPMComplete.Enabled = false;
                chkSeamSlippage.Enabled = false;
                txtFactoryRepresentitive.Enabled = false;
                txtQaRepresentative.Enabled = false;
                btnAddFactory.Attributes.Add("style", "display:none;");
                btnAddQa.Attributes.Add("style", "display:none;");
                btnAddMerchandiser.Attributes.Add("style", "display:none;");
            }
            else
            {
                //chkPreProdQAMgr.Enabled = true;
                chkProdQAMgr.Enabled = true;
                chkFactoryPPMComplete.Enabled = true;
                chkHOPPMComplete.Enabled = true;
                chkSeamSlippage.Enabled = true;
                txtFactoryRepresentitive.Enabled = true;
                txtQaRepresentative.Enabled = true;
                btnAddFactory.Attributes.Add("style", "display:block;");
                btnAddQa.Attributes.Add("style", "display:block;");
                btnAddMerchandiser.Attributes.Add("style", "display:block;");
            }

            int DatabaseReuse = dsHoPPM.Tables[0].Rows[0]["IsReuse"] == DBNull.Value ? 0 : Convert.ToInt32(dsHoPPM.Tables[0].Rows[0]["IsReuse"]);

            //if (chkPreProdQAMgr.Checked)
            //{
            //    lblchkPreProdQAMgr.Text = dsHoPPM.Tables[0].Rows[0]["QAPreProdApprovedOn"] == DBNull.Value ? "" : Convert.ToDateTime(dsHoPPM.Tables[0].Rows[0]["QAPreProdApprovedOn"]).ToString("dd-MMM-yyyy");
            //}
            //else
            //{
            //    lblchkPreProdQAMgr.Text = "";
            //}
            if (chkProdQAMgr.Checked)
            {
                lblchkProdQAMgr.Text = dsHoPPM.Tables[0].Rows[0]["QAProdApprovedOn"] == DBNull.Value ? "" : Convert.ToDateTime(dsHoPPM.Tables[0].Rows[0]["QAProdApprovedOn"]).ToString("dd-MMM-yyyy");
            }
            else
            {
                lblchkProdQAMgr.Text = "";
            }
            if (chkMM.Checked)
            {
                lblchkMM.Text = dsHoPPM.Tables[0].Rows[0]["MerchandisingManagerApprovedOn"] == DBNull.Value ? "" : Convert.ToDateTime(dsHoPPM.Tables[0].Rows[0]["MerchandisingManagerApprovedOn"]).ToString("dd-MMM-yyyy");
            }
            else
            {
                lblchkMM.Text = "";
            }

            if (chkFactoryPPMComplete.Checked)
            {
                lblchkFactoryPPMComplete.Text = dsHoPPM.Tables[0].Rows[0]["FactoryPPMCompleteOn"] == DBNull.Value ? "" : Convert.ToDateTime(dsHoPPM.Tables[0].Rows[0]["FactoryPPMCompleteOn"]).ToString("dd-MMM-yyyy");
            }
            else
            {
                lblchkFactoryPPMComplete.Text = "";
            }

            if (chkHOPPMComplete.Checked)
            {
                lblchkHOPPMComplete.Text = dsHoPPM.Tables[0].Rows[0]["HOPPMCompleteOn"] == DBNull.Value ? "" : Convert.ToDateTime(dsHoPPM.Tables[0].Rows[0]["HOPPMCompleteOn"]).ToString("dd-MMM-yyyy");
            }
            else
            {
                lblchkHOPPMComplete.Text = "";
            }
            if (chkSeamSlippage.Checked)
            {
                lblSeamSlippageOn.Text = dsHoPPM.Tables[0].Rows[0]["SeamSlippageOK"] == DBNull.Value ? "" : Convert.ToDateTime(dsHoPPM.Tables[0].Rows[0]["SeamSlippageOK"]).ToString("dd-MMM-yyyy");
            }
            else
            {
                lblchkHOPPMComplete.Text = "";
            }
            if (ReUse == 1)
            {
                //chkPreProdQAMgr.Enabled = false;
                chkProdQAMgr.Enabled = false;
                chkMM.Enabled = false;
                chkFactoryPPMComplete.Enabled = false;
                chkHOPPMComplete.Enabled = false;
                chkSeamSlippage.Enabled = false;
                txtFactoryRepresentitive.Enabled = false;
                txtQaRepresentative.Enabled = false;
                btnAddFactory.Attributes.Add("style", "display:none;");
                btnAddQa.Attributes.Add("style", "display:none;");
                btnAddMerchandiser.Attributes.Add("style", "display:none;");
                FileSnap1.Enabled = false;
                FileSnap2.Enabled = false;

            }
            if ((DatabaseReuse == 1) && (CreateNew == 0) && (NewRef == 0))
            {
                //chkPreProdQAMgr.Enabled = false;
                chkProdQAMgr.Enabled = false;
                chkMM.Enabled = false;
                chkFactoryPPMComplete.Enabled = false;
                chkHOPPMComplete.Enabled = false;
                chkSeamSlippage.Enabled = false;
                txtFactoryRepresentitive.Enabled = false;
                txtQaRepresentative.Enabled = false;
                btnAddFactory.Attributes.Add("style", "display:none;");
                btnAddQa.Attributes.Add("style", "display:none;");
                btnAddMerchandiser.Attributes.Add("style", "display:none;");
                FileSnap1.Enabled = false;
                FileSnap2.Enabled = false;

            }
            ShowGridPopup.Visible = false;
            if (dsHoPPM.Tables[1].Rows.Count > 0)
            {
                repStyleCodeVirsion.DataSource = dsHoPPM.Tables[1];
                repStyleCodeVirsion.DataBind();
            }
            else
            {
                repStyleCodeVirsion.DataSource = null;
                repStyleCodeVirsion.DataBind();
            }

            if (chkProdQAMgr.Checked == true && chkMM.Checked == true && chkFactoryPPMComplete.Checked == true && chkHOPPMComplete.Checked == true && chkSeamSlippage.Checked == true)
            {
                if (NewRef == 1)
                {

                    chkProdQAMgr.Enabled = true;
                    chkMM.Enabled = true;
                    chkFactoryPPMComplete.Enabled = true;
                    chkHOPPMComplete.Enabled = true;
                    chkSeamSlippage.Enabled = true;
                    FinalHoppmDone(1);
                }
                else
                {

                    chkProdQAMgr.Enabled = false;
                    chkMM.Enabled = false;
                    chkFactoryPPMComplete.Enabled = false;
                    chkHOPPMComplete.Enabled = false;
                    chkSeamSlippage.Enabled = false;
                    FinalHoppmDone(2);
                }
            }


            //Added By Ashish on 28/7/2015

            if ((chkProdQAMgr.Checked))
            {
                chkMM.Enabled = true;
            }
            else
            {
                chkMM.Enabled = false;
            }
            //END
        }


        protected void rptHoppmAccessories_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                string OrderDetailsID = (DataBinder.Eval(e.Item.DataItem, "OrderDetailsID").ToString());
                string AccessoriesName = (DataBinder.Eval(e.Item.DataItem, "AccessoriesName").ToString());

            }
        }


        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            //btnSubmit.Visible = false;          
            CreateNew = Convert.ToInt32(hdnHoppmCreateNew.Value);
            NewRefrence = Convert.ToInt32(hdnHoppmNewRef.Value);
            ReUse = Convert.ToInt32(hdnHoppmReUse.Value);
            ReUseStyleId = Convert.ToInt32(hdnHoppmStyleId.Value);
            ReUseStyleNumber = hdnHoppmStyleNumber.Value;
            if (ViewState["HoPopUpClick"] != null)
            {
                if (ViewState["HoPopUpClick"].ToString() == "1")
                {
                    SaveHOPPM(CreateNew, NewRefrence, ReUse, ReUseStyleId);
                    ViewState["HoPopUpClick"] = "0";
                }
                else
                {
                    SaveHOPPM(0, 0, 0, -1);
                }
            }
            else
            {
                SaveHOPPM(0, 0, 0, -1);
            }

        }

        private void SaveHOPPM(int CreateNew, int NewRefrence, int ReUse, int ReUseStyleId)
        {
            HOPPMOB objHOPPM = new HOPPMOB();

            if (hdnQaRepresentativeId.Value.StartsWith(","))
            {
                hdnQaRepresentativeId.Value = hdnQaRepresentativeId.Value.Substring(1, hdnQaRepresentativeId.Value.Length - 1);
            }
            if (hdnQaRepresentativeName.Value.StartsWith(","))
            {
                hdnQaRepresentativeName.Value = hdnQaRepresentativeName.Value.Substring(1, hdnQaRepresentativeName.Value.Length - 1);
            }
            objHOPPM.QaRepresentativeIds = hdnQaRepresentativeId.Value;
            objHOPPM.QaRepresentativeNames = hdnQaRepresentativeName.Value;

            if (hdnFactoryRepresentativeId.Value.StartsWith(","))
            {
                hdnFactoryRepresentativeId.Value = hdnFactoryRepresentativeId.Value.Substring(1, hdnFactoryRepresentativeId.Value.Length - 1);
            }
            if (hdnFactoryRepresentativeName.Value.StartsWith(","))
            {
                hdnFactoryRepresentativeName.Value = hdnFactoryRepresentativeName.Value.Substring(1, hdnFactoryRepresentativeName.Value.Length - 1);
            }
            objHOPPM.FactoryRepresentativeIds = hdnFactoryRepresentativeId.Value;
            objHOPPM.FactoryRepresentativeNames = hdnFactoryRepresentativeName.Value;

            //Added By Ashish on 23/7/2015
            if (hdnMerchandiserRepresentativeId.Value.StartsWith(","))
            {
                hdnMerchandiserRepresentativeId.Value = hdnMerchandiserRepresentativeId.Value.Substring(1, hdnMerchandiserRepresentativeId.Value.Length - 1);
            }
            if (hdnMerchandiserRepresentativeName.Value.StartsWith(","))
            {
                hdnMerchandiserRepresentativeName.Value = hdnMerchandiserRepresentativeName.Value.Substring(1, hdnMerchandiserRepresentativeName.Value.Length - 1);
            }
            objHOPPM.MerchandiserId = hdnMerchandiserRepresentativeId.Value;
            objHOPPM.MerchandiserName = hdnMerchandiserRepresentativeName.Value;

            //Add
            string FileName1 = FileSnap1.FileName;
            string FileName2 = FileSnap2.FileName;
            string fileNameStyle1;
            string fileNameStyle2;
            if (FileName1 != "")
            {
                int FileName1LastIndx = 0;
                int FileName1Len = 0;
                FileName1Len = FileName1.Length;
                FileName1LastIndx = FileName1.LastIndexOf(".");
                string Extension1;
                Extension1 = FileName1.Substring(FileName1LastIndx, (FileName1Len - FileName1LastIndx));

                if (FileSnap1.HasFile)
                {

                    fileNameStyle1 = ((stylenumber.ToString() + "-" + DepartmentId + "_" + "FileNameAvail_" + Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd")) + Extension1).Replace(" ", "")).Replace(":", "");//FileName1;
                    //objHOPPM.FileUploadUrl1 = SaveUploadedFile(FileSnap1, fileNameStyle);
                    FileSnap1.SaveAs(Server.MapPath(FitsFolderPath) + fileNameStyle1);
                    objHOPPM.FileUploadUrl1 = fileNameStyle1 == "" ? "" : fileNameStyle1;
                    hlkViewSnap1.Visible = true;
                    hlkViewSnap1.NavigateUrl = (string.IsNullOrEmpty(objHOPPM.FileUploadUrl1)) ? "" : FitsFolderPath + objHOPPM.FileUploadUrl1;
                }
            }
            else
            {
                //fileNameStyle1 = hdnSnap1.Value + "-" + DepartmentId + "FileNameNotAvail_" + Convert.ToString(DateTime.Now); //;
                //FileSnap1.SaveAs(Server.MapPath(FitsFolderPath) + fileNameStyle1);
                //objHOPPM.FileUploadUrl1 = fileNameStyle1 == "" ? "" : fileNameStyle1;
                //hlkViewSnap1.Visible = true;
                //hlkViewSnap1.NavigateUrl = (string.IsNullOrEmpty(objHOPPM.FileUploadUrl1)) ? "" : FitsFolderPath + objHOPPM.FileUploadUrl1;
            }


            if (FileName2 != "")
            {
                int FileName2LastIndx = 0;
                int FileName2Len = 0;
                FileName2Len = FileName2.Length;
                FileName2LastIndx = FileName2.LastIndexOf(".");
                string Extension2;
                Extension2 = FileName2.Substring(FileName2LastIndx, (FileName2Len - FileName2LastIndx));

                if (FileSnap2.HasFile)
                {

                    fileNameStyle2 = ((stylenumber.ToString() + "-" + DepartmentId + "_" + "FileNameAvai2_" + Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd")) + Extension2).Replace(" ", "")).Replace(":", ""); //+ FileName2; ;
                    FileSnap2.SaveAs(Server.MapPath(FitsFolderPath) + fileNameStyle2);
                    objHOPPM.FileUploadUrl2 = fileNameStyle2 == "" ? "" : fileNameStyle2;
                    hlkViewSnap2.Visible = true;
                    hlkViewSnap2.NavigateUrl = (string.IsNullOrEmpty(objHOPPM.FileUploadUrl2)) ? "" : FitsFolderPath + objHOPPM.FileUploadUrl2;
                }
            }
            else
            {
                //fileNameStyle2 = hdnSnap2.Value + "-" + DepartmentId + "FileNameNotAvail_" + Convert.ToString(DateTime.Now);  //;
                //FileSnap2.SaveAs(Server.MapPath(FitsFolderPath) + fileNameStyle2);
                //objHOPPM.FileUploadUrl2 = fileNameStyle2 == "" ? "" : fileNameStyle2;
                //hlkViewSnap2.Visible = true;
                //hlkViewSnap2.NavigateUrl = (string.IsNullOrEmpty(objHOPPM.FileUploadUrl2)) ? "" : FitsFolderPath + objHOPPM.FileUploadUrl2;
            }


            //
            if (chkMM.Checked)
            {
                objHOPPM.IsMerchandisingManagerApprovedOn = true;
            }

            if (chkProdQAMgr.Checked)
            {
                objHOPPM.IsQAProdApprovedOn = true;
            }
            if (chkFactoryPPMComplete.Checked)
            {
                objHOPPM.IsFactoryPPMComplete = true;
            }
            if (chkHOPPMComplete.Checked)
            {
                objHOPPM.IsHOPPMComplete = true;
            }
            //abhi
            if (chkSeamSlippage.Checked)
            {
                objHOPPM.Seam_Slippage_OK = true;
            }
            if (chkSeamSlippage.Checked == true)
            {

                int isave = obj_ProcessController.SaveHOPPM(stylenumber, styleid, strClientId, DepartmentId, CreateNew, ReUse, ReUseStyleId, objHOPPM.QaRepresentativeIds, objHOPPM.QaRepresentativeNames, objHOPPM.FactoryRepresentativeIds, objHOPPM.FactoryRepresentativeNames, objHOPPM.MerchandiserId, objHOPPM.MerchandiserName, objHOPPM.IsMerchandisingManagerApprovedOn, objHOPPM.IsQAProdApprovedOn, objHOPPM.IsFactoryPPMComplete, objHOPPM.IsHOPPMComplete, objHOPPM.FileUploadUrl1, objHOPPM.FileUploadUrl2, ApplicationHelper.LoggedInUser.UserData.UserID, objHOPPM.Seam_Slippage_OK);

                int iResult;
                if (chkFactoryPPMComplete.Checked)
                {
                    iResult = WorkflowControllerInstance.UpdateWorkflowInstancePostOrder_Style_Order_Basis(styleid, 0, TaskMode.FACTORY_PPM, ApplicationHelper.LoggedInUser.UserData.UserID);
                }

                if ((chkFactoryPPMComplete.Checked) && (chkHOPPMComplete.Checked))
                {
                    iResult = WorkflowControllerInstance.UpdateWorkflowInstancePostOrder_Style_Order_Basis(styleid, 0, TaskMode.FACTORY_PPM, ApplicationHelper.LoggedInUser.UserData.UserID);
                    //// Edit by surendra
                    //bMrMaturOBCheckBox = WorkflowControllerInstance.GetMrMathurCheckBox(styleid);
                    ////
                    ////if (bMrMaturOBCheckBox==true) 
                    iResult = WorkflowControllerInstance.UpdateWorkflowInstancePostOrder_Style_Order_Basis(styleid, OrderID, TaskMode.HO_PPM, ApplicationHelper.LoggedInUser.UserData.UserID);
                }

                if (isave == 1)
                {
                    SaveRemarks(CreateNew, NewRefrence, ReUse, ReUseStyleId);
                    SaveAccessoryRemark(CreateNew, NewRefrence, ReUse, ReUseStyleId);
                    // Save RnD Remarks here
                    SaveRnDRemark(CreateNew, NewRefrence, ReUse, ReUseStyleId);
                    SaveFitingRemark(CreateNew, NewRefrence, ReUse, ReUseStyleId);
                    SaveMakingRemark(CreateNew, NewRefrence, ReUse, ReUseStyleId);
                    SaveImbroideryRemark(CreateNew, NewRefrence, ReUse, ReUseStyleId);
                    SaveWashingRemark(CreateNew, NewRefrence, ReUse, ReUseStyleId);
                    SaveFinishingRemark(CreateNew, NewRefrence, ReUse, ReUseStyleId);
                    //Page.ClientScript.RegisterStartupScript(Page.GetType(), "scr", "alert('Saved Successfully');", true);

                    //btnSubmit.Visible = false;
                    //Session["Time"] = DateTime.Now.ToString();

                    BindControl(0, 0, 0, -1, "");
                    BindRemarkGrd(0, 0, 0, -1, "", true);
                    BindAccessoriesGrd(0, 0, 0, -1, "", true);
                    // Bind RnD Remarks Here
                    BindgrdRiskRnD(0, 0, 0, -1, "", true);
                    BindFitingGrd(0, 0, 0, -1, "", true);
                    BindMakingGrd(0, 0, 0, -1, "", true);
                    BindImbroideryGrd(0, 0, 0, -1, "", true);
                    BindWashingGrd(0, 0, 0, -1, "", true);
                    BindFinishingGrd(0, 0, 0, -1, "", true);
                    SetHoppmPermission();

                }

                else
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "scr", "alert('Page could not saved');", true);
                    //btnSubmit.Enabled = true;
                }
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "scr", "alert('With Out Seam Slippage OK HO PPM Can not be saved');", true);
            }
        }

        private string SaveUploadedFile(FileUpload FileUploadCtrl, String fileName)
        {
            if (FileUploadCtrl.HasFile)
            {
                return FileHelper.SaveFile(FileUploadCtrl.PostedFile.InputStream, FileUploadCtrl.FileName, Constants.FITS_FOLDER_PATH, false, fileName);
            }
            else
            {
                return "";
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            CreateNew = Convert.ToInt32(hdnHoppmCreateNew.Value);
            NewRefrence = Convert.ToInt32(hdnHoppmNewRef.Value);
            ReUse = Convert.ToInt32(hdnHoppmReUse.Value);
            ReUseStyleId = Convert.ToInt32(hdnHoppmStyleId.Value);
            ReUseStyleNumber = hdnHoppmStyleNumber.Value;

            BindControl(CreateNew, NewRefrence, ReUse, ReUseStyleId, ReUseStyleNumber);
            //Edited by Abhishek on 27/10/2015

            int IsFinalOB = 0;
            IsFinalOB = WorkflowControllerInstance.IsFinalOBDone(styleid, TaskMode.Final_OB, "HOPPM");
            if (IsFinalOB != 0)
            {
                if (Convert.ToInt32(hdnHoppmCreateNew.Value) == 1)
                {
                    chkMM.Enabled = true;
                    chkHOPPMComplete.Enabled = false;
                }
            }

            //Edited end by abhishek on 27/10/2015

            BindRemarkGrd(CreateNew, NewRefrence, ReUse, ReUseStyleId, ReUseStyleNumber, true);
            BindAccessoriesGrd(CreateNew, NewRefrence, ReUse, ReUseStyleId, ReUseStyleNumber, true);
            BindgrdRiskRnD(CreateNew, NewRefrence, ReUse, ReUseStyleId, ReUseStyleNumber, true);
            BindFitingGrd(CreateNew, NewRefrence, ReUse, ReUseStyleId, ReUseStyleNumber, true);
            BindMakingGrd(CreateNew, NewRefrence, ReUse, ReUseStyleId, ReUseStyleNumber, true);
            BindImbroideryGrd(CreateNew, NewRefrence, ReUse, ReUseStyleId, ReUseStyleNumber, true);
            BindWashingGrd(CreateNew, NewRefrence, ReUse, ReUseStyleId, ReUseStyleNumber, true);
            BindFinishingGrd(CreateNew, NewRefrence, ReUse, ReUseStyleId, ReUseStyleNumber, true);
            ViewState["HoPopUpClick"] = "1";
            SetHoppmPermission();
            if (ReUse == 1)
                btnSubmit.Visible = true;
        }

        protected void gvHOPPM_RowDataBound(object sender, GridViewRowEventArgs e)
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
                        Fabric1Percent.ForeColor = System.Drawing.Color.Gray;
                        lblFabricStartETAdate1.ForeColor = System.Drawing.Color.Gray;
                        lblFabricEndETAdate1.ForeColor = System.Drawing.Color.Gray;
                        lblFabric1DetailsRef.ForeColor = System.Drawing.Color.Gray;

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
                        lblFabric2.ForeColor = System.Drawing.Color.Gray;
                        Fabric2Percent.ForeColor = System.Drawing.Color.Gray;
                        lblFabricStartETAdate2.ForeColor = System.Drawing.Color.Gray;
                        lblFabricEndETAdate2.ForeColor = System.Drawing.Color.Gray;
                        lblFabric2DetailsRef.ForeColor = System.Drawing.Color.Gray;
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
            Repeater rptHoppmAccessories = e.Row.FindControl("rptHoppmAccessories") as Repeater;
            if (od.AccessoriesETA != null)
            {
                if (od.AccessoriesETA.Count > 0)
                {
                    rptHoppmAccessories.DataSource = od.AccessoriesETA;
                    rptHoppmAccessories.DataBind();
                }
            }

        }


        //Added By Ashish for remarks
        //Fabric
        protected void BindRemarkGrd(int CreateNew, int NewRef, int ReUse, int ReUseStyleId, string ReUseStyleNumber, bool Submited)
        {
            DataSet dsgrd = new DataSet();
            string RemarksType = "Fabric";
            if (Submited)
            {
                if (chkMM.Checked)
                {
                    if (bRepeatCheck == true)
                        grdHoppmFabricRemark.Enabled = true;
                    else
                        grdHoppmFabricRemark.Enabled = false;
                }
                else
                {
                    grdHoppmFabricRemark.Enabled = true;
                }
            }
            else
            {
                grdHoppmFabricRemark.Enabled = true;
            }
            if (CreateNew == 1)
            {
                dsgrd = obj_ProcessController.GetHOPPMRemarks(stylenumber, styleid, strClientId, DepartmentId, CreateNew, NewRef, ReUse, ReUseStyleId, RemarksType);
                grdHoppmFabricRemark.DataSource = dsgrd.Tables[0];
                grdHoppmFabricRemark.DataBind();
                ViewState["datatable"] = dsgrd.Tables[0];
            }

            else if (NewRef == 1)
            {
                dsgrd = obj_ProcessController.GetHOPPMRemarks(stylenumber, styleid, strClientId, DepartmentId, CreateNew, NewRef, ReUse, ReUseStyleId, RemarksType);
                grdHoppmFabricRemark.DataSource = dsgrd.Tables[0];
                grdHoppmFabricRemark.DataBind();
                ViewState["datatable"] = dsgrd.Tables[0];
            }
            else if (ReUse == 1)
            {
                dsgrd = obj_ProcessController.GetHOPPMRemarks(stylenumber, styleid, strClientId, DepartmentId, CreateNew, NewRef, ReUse, ReUseStyleId, RemarksType);
                grdHoppmFabricRemark.DataSource = dsgrd.Tables[0];
                grdHoppmFabricRemark.DataBind();
                ViewState["datatable"] = dsgrd.Tables[0];

            }
            else
            {
                //if (ViewState["datatable"] == null)
                //{
                dsgrd = obj_ProcessController.GetHOPPMRemarks(stylenumber, styleid, strClientId, DepartmentId, CreateNew, NewRef, ReUse, ReUseStyleId, RemarksType);
                grdHoppmFabricRemark.DataSource = dsgrd.Tables[0];
                grdHoppmFabricRemark.DataBind();
                ViewState["datatable"] = dsgrd.Tables[0];

                //}
                //else
                //{
                //    DataTable dtnew = (DataTable)(ViewState["datatable"]);
                //    grdHoppmFabricRemark.DataSource = dtnew;
                //    grdHoppmFabricRemark.DataBind();
                //    ViewState["datatable"] = dtnew;

                //}
            }

        }
        protected void grdHoppmFabricRemark_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string Username = iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.FirstName;
            //string[] name = Username.Split('@');
            string date = DateTime.Now.ToString("dd MMM yyyy");
            if (e.CommandName == "Insert")
            {
                TextBox txtRemarkFooter = grdHoppmFabricRemark.FooterRow.FindControl("txtRemarkFooter") as TextBox;
                LinkButton abtnAdd = grdHoppmFabricRemark.FooterRow.FindControl("abtnAdd") as LinkButton;


                DataTable dtnew = new DataTable();
                string Remark = txtRemarkFooter.Text.Trim();
                if (Remark == "")
                {
                    ShowAlert("Please Enter Remarks");
                    return;
                }
                else
                {
                    //added by abhishek on 23/11/2015
                    SaveRemarks(0, 0, 0, -1);
                    //end by abhishek
                    if (ViewState["datatable"] != null)
                    {
                        dtnew = (DataTable)(ViewState["datatable"]);
                        for (int i = 0; i < grdHoppmFabricRemark.Rows.Count; i++)
                        {
                            dtnew.Rows[i]["FabricRemark"] = ((TextBox)grdHoppmFabricRemark.Rows[i].FindControl("txtRemarkEdit")).Text;
                        }
                        dtnew.AcceptChanges();
                        sl = dtnew.Rows.Count;
                        dtnew.Rows.Add(0, styleid, Username + "(" + date + "): ", Remark, sl + 1, sl + 1);
                        ViewState["datatable"] = dtnew;
                    }
                    //if (ViewState["datatable"] != null)
                    //{
                    //    dtnew = (DataTable)(ViewState["datatable"]);
                    //    sl = dtnew.Rows.Count;
                    //    dtnew.Rows.Add(sl + 1, styleid, Remark, sl + 1);
                    //    ViewState["datatable"] = dtnew;
                    //}
                }
                BindRemarkGrd(CreateNew, NewRefrence, ReUse, ReUseStyleId, ReUseStyleNumber, false);

            }
            if (e.CommandName == "addnew")
            {

                Table tblGrdviewApplet = (Table)grdHoppmFabricRemark.Controls[0];
                GridViewRow rows = (GridViewRow)tblGrdviewApplet.Controls[0];
                TextBox txtRemarksEmpty = (TextBox)rows.FindControl("txtRemarksEmpty");

                DataTable dtnew = new DataTable();
                string Remark = txtRemarksEmpty.Text.Trim();
                //Remark = Regex.Replace(Remark, @"\s+", "");
                if (Remark == "")
                {
                    ShowAlert("Please Enter Remarks");
                    return;
                }
                else
                {
                    //added by abhishek on 23/11/2015
                    SaveRemarks(0, 0, 0, -1);
                    //end by abhishek
                    if (ViewState["datatable"] != null)
                    {
                        dtnew = (DataTable)(ViewState["datatable"]);
                        for (int i = 0; i < grdHoppmFabricRemark.Rows.Count; i++)
                        {
                            dtnew.Rows[i]["FabricRemark"] = ((TextBox)grdHoppmFabricRemark.Rows[i].FindControl("txtRemarkEdit")).Text;
                        }
                        dtnew.AcceptChanges();
                        sl = dtnew.Rows.Count;
                        dtnew.Rows.Add(0, styleid, Username + "(" + date + "): ", Remark, sl + 1, sl + 1);
                        ViewState["datatable"] = dtnew;
                    }
                }

                BindRemarkGrd(CreateNew, NewRefrence, ReUse, ReUseStyleId, ReUseStyleNumber, false);

                //BindGrd();
            }
        }
        public static String RemarksByHide;
        protected void grdHoppmFabricRemark_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    Literal ltIndex = (Literal)e.Row.FindControl("ltIndex");
            //    ltIndex.Text = ((grdHoppmFabricRemark.PageIndex * grdHoppmFabricRemark.PageSize) + e.Row.RowIndex + 1).ToString();
            //}
            bool EnableHOPPM = grdHoppmFabricRemark.Enabled;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Literal ltIndex = (Literal)e.Row.FindControl("ltIndex");
                //ltIndex.Text = ((grdHoppmFabricRemark.PageIndex * grdHoppmFabricRemark.PageSize) + e.Row.RowIndex + 1).ToString();
                LinkButton lnkDelete = (LinkButton)e.Row.FindControl("lnkDelete");


                if (!EnableHOPPM)
                {
                    lnkDelete.Visible = false;
                }



                TextBox txtRemarkEdit = (TextBox)e.Row.FindControl("txtRemarkEdit");
                NewRefrence = Convert.ToInt32(hdnHoppmNewRef.Value);
                if (chkProdQAMgr.Checked == true && chkMM.Checked == true && chkFactoryPPMComplete.Checked == true && chkHOPPMComplete.Checked == true)
                {
                    if (NewRefrence == 1)
                    {
                        txtRemarkEdit.Enabled = true;
                        lnkDelete.Visible = true;
                        lnkDelete.Attributes.Add("style", "display:block;");
                    }
                    else
                    {
                        txtRemarkEdit.Enabled = false;
                        lnkDelete.Visible = false;
                        lnkDelete.Attributes.Add("style", "display:none;");
                    }
                }

            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                LinkButton abtnAdd = (LinkButton)e.Row.FindControl("abtnAdd");
                if (!EnableHOPPM)
                {
                    abtnAdd.Visible = false;
                }
                NewRefrence = Convert.ToInt32(hdnHoppmNewRef.Value);
                TextBox txtRemarkFooter = (TextBox)e.Row.FindControl("txtRemarkFooter");
                if (chkProdQAMgr.Checked == true && chkMM.Checked == true && chkFactoryPPMComplete.Checked == true && chkHOPPMComplete.Checked == true)
                {
                    if (NewRefrence == 1)
                    {
                        txtRemarkFooter.Enabled = true;
                        abtnAdd.Visible = true;
                    }
                    else
                    {
                        txtRemarkFooter.Enabled = false;
                        abtnAdd.Visible = false;
                    }

                }
            }
            if (e.Row.RowType == DataControlRowType.EmptyDataRow)
            {
                LinkButton addbutton = (LinkButton)e.Row.FindControl("addbutton");
                if (!EnableHOPPM)
                {
                    addbutton.Visible = false;
                }
            }
        }
        protected void grdRiskRemarks_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = grdHoppmFabricRemark.Rows[e.RowIndex];
            HiddenField hdndataTableId = (HiddenField)row.FindControl("hdndataTableId");
            HiddenField hdnRiskFabricId = (HiddenField)row.FindControl("hdnRiskFabricId");
            DataTable dtnew = new DataTable();
            string RemarksType = "Fabric";
            if (ViewState["datatable"] != null)
            {
                dtnew = (DataTable)(ViewState["datatable"]);
                if (hdnRiskFabricId.Value != "0")
                {
                    dtnew.Rows.Remove(dtnew.Select("RiskFabricId=" + hdnRiskFabricId.Value)[0]);
                    int IsDelete = obj_ProcessController.DeleteHoppmRemarkById(Convert.ToInt32(hdnRiskFabricId.Value), RemarksType);
                }
                else
                {
                    dtnew.Rows.Remove(dtnew.Select("dataTableId=" + hdndataTableId.Value)[0]);
                }
                ViewState["datatable"] = dtnew;
            }


            grdHoppmFabricRemark.EditIndex = -1;
            BindRemarkGrd(CreateNew, NewRefrence, ReUse, ReUseStyleId, ReUseStyleNumber, false);

        }
        protected void grdRiskRemarks_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }
        protected void SaveRemarks(int CreateNew, int NewRefrence, int ReUse, int ReUseStyleId)
        {
            RiskAnalysisOB objRisk = new RiskAnalysisOB();

            int UserId = iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.UserID;
            int RiskFabricId = 0;
            int StyleSequence = 0;
            string RemarksType = "Fabric";

            Control control = null;
            control = grdHoppmFabricRemark.Controls[0].Controls[0];
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
                        int isave = obj_ProcessController.InsertUpdateHOPPMRemarks(stylenumber, styleid, strClientId, DepartmentId, CreateNew, NewRefrence, ReUse, ReUseStyleId, RemarksEmpty, RiskFabricId, StyleSequence, RemarksType, UserId);
                    }
                }
            }
            else
            {

                for (int i = 0; i < grdHoppmFabricRemark.Rows.Count; i++)
                {
                    TextBox RemarkEdit = (TextBox)grdHoppmFabricRemark.Rows[i].FindControl("txtRemarkEdit");
                    HiddenField hdnRiskFabricId = (HiddenField)grdHoppmFabricRemark.Rows[i].FindControl("hdnRiskFabricId");
                    HiddenField hdnStyleSequence = (HiddenField)grdHoppmFabricRemark.Rows[i].FindControl("hdnStyleSequence");
                    string Remark = RemarkEdit.Text.Trim();
                    //Remark = Regex.Replace(Remark, @"\s+", "");
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
                            int isave = obj_ProcessController.InsertUpdateHOPPMRemarks(stylenumber, styleid, strClientId, DepartmentId, CreateNew, NewRefrence, ReUse, ReUseStyleId, Remark, RiskFabricId, StyleSequence, RemarksType, UserId);
                        }

                    }
                }
                var footerRow = grdHoppmFabricRemark.FooterRow;
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
                            int isave = obj_ProcessController.InsertUpdateHOPPMRemarks(stylenumber, styleid, strClientId, DepartmentId, CreateNew, NewRefrence, ReUse, ReUseStyleId, RemarkFooter, RiskFabricId, StyleSequence, RemarksType, UserId);
                        }
                    }
                }
            }
            if (ReUse == 1)
            {
                int SaveData = obj_ProcessController.ReuseHoppmRemarks(styleid, ReUse, RemarksType, UserId);
            }
            ViewState["datatable"] = null;
        }

        //Accessories
        protected void BindAccessoriesGrd(int CreateNew, int NewRef, int ReUse, int ReUseStyleId, string ReUseStyleNumber, bool Submited)
        {
            DataSet dsgrd = new DataSet();
            string RemarksType = "Accesories";
            if (Submited)
            {
                if (chkMM.Checked)
                {
                    if (bRepeatCheck == true)
                        grdRiskAccessories.Enabled = true;
                    else
                        grdRiskAccessories.Enabled = false;
                }
                else
                {
                    grdRiskAccessories.Enabled = true;
                }
            }
            else
            {
                grdRiskAccessories.Enabled = true;
            }
            if (CreateNew == 1)
            {
                dsgrd = obj_ProcessController.GetHOPPMRemarks(stylenumber, styleid, strClientId, DepartmentId, CreateNew, NewRef, ReUse, ReUseStyleId, RemarksType);
                grdRiskAccessories.DataSource = dsgrd.Tables[0];
                grdRiskAccessories.DataBind();
                ViewState["AccessoriesData"] = dsgrd.Tables[0];

            }
            else if (NewRef == 1)
            {
                dsgrd = obj_ProcessController.GetHOPPMRemarks(stylenumber, styleid, strClientId, DepartmentId, CreateNew, NewRef, ReUse, ReUseStyleId, RemarksType);
                grdRiskAccessories.DataSource = dsgrd.Tables[0];
                grdRiskAccessories.DataBind();
                ViewState["AccessoriesData"] = dsgrd.Tables[0];

            }
            else if (ReUse == 1)
            {
                dsgrd = obj_ProcessController.GetHOPPMRemarks(stylenumber, styleid, strClientId, DepartmentId, CreateNew, NewRef, ReUse, ReUseStyleId, RemarksType);
                grdRiskAccessories.DataSource = dsgrd.Tables[0];
                grdRiskAccessories.DataBind();
                ViewState["AccessoriesData"] = dsgrd.Tables[0];

            }
            else
            {
                //if (ViewState["AccessoriesData"] == null)
                //{
                dsgrd = obj_ProcessController.GetHOPPMRemarks(stylenumber, styleid, strClientId, DepartmentId, CreateNew, NewRef, ReUse, ReUseStyleId, RemarksType);
                grdRiskAccessories.DataSource = dsgrd.Tables[0];
                grdRiskAccessories.DataBind();
                ViewState["AccessoriesData"] = dsgrd.Tables[0];

                //}
                //else
                //{
                //    DataTable dtnew = (DataTable)(ViewState["AccessoriesData"]);
                //    grdRiskAccessories.DataSource = dtnew;
                //    grdRiskAccessories.DataBind();
                //    ViewState["AccessoriesData"] = dtnew;

                //}
            }

        }
        protected void grdRiskAccessories_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string Username = iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.FirstName;
            //string[] name = Username.Split('@');
            string date = DateTime.Now.ToString("dd MMM yyyy");
            if (e.CommandName == "Insert")
            {
                TextBox txtRemarkFooter = grdRiskAccessories.FooterRow.FindControl("txtRemarkFooter") as TextBox;
                LinkButton abtnAdd = grdRiskAccessories.FooterRow.FindControl("abtnAdd") as LinkButton;

                DataTable dtnew = new DataTable();
                string Remark = txtRemarkFooter.Text.Trim();
                if (Remark == "")
                {
                    ShowAlert("Please Enter Remarks");
                    return;
                }
                else
                {
                    //added by abhishek on 23/11/2015
                    SaveAccessoryRemark(0, 0, 0, -1);
                    //end by abhishek 23/10/2015
                    if (ViewState["AccessoriesData"] != null)
                    {
                        dtnew = (DataTable)(ViewState["AccessoriesData"]);
                        for (int i = 0; i < grdRiskAccessories.Rows.Count; i++)
                        {
                            dtnew.Rows[i]["FabricRemark"] = ((TextBox)grdRiskAccessories.Rows[i].FindControl("txtRemarkEdit")).Text;
                        }
                        dtnew.AcceptChanges();
                        sl = dtnew.Rows.Count;
                        dtnew.Rows.Add(0, styleid, Username + "(" + date + "): ", Remark, sl + 1, sl + 1);
                        ViewState["AccessoriesData"] = dtnew;
                    }
                }

                BindAccessoriesGrd(CreateNew, NewRefrence, ReUse, ReUseStyleId, ReUseStyleNumber, false);
            }
            if (e.CommandName == "addnew")
            {

                Table tblGrdviewApplet = (Table)grdRiskAccessories.Controls[0];
                GridViewRow rows = (GridViewRow)tblGrdviewApplet.Controls[0];
                TextBox txtRemarksEmpty = (TextBox)rows.FindControl("txtRemarksEmpty");

                DataTable dtnew = new DataTable();
                string Remark = txtRemarksEmpty.Text.Trim();
                if (Remark == "")
                {
                    ShowAlert("Please Enter Remarks");
                    return;
                }
                else
                {
                    //added by abhishek on 23/11/2015
                    SaveAccessoryRemark(0, 0, 0, -1);
                    //end by abhishek 23/10/2015
                    if (ViewState["AccessoriesData"] != null)
                    {
                        dtnew = (DataTable)(ViewState["AccessoriesData"]);
                        for (int i = 0; i < grdRiskAccessories.Rows.Count; i++)
                        {
                            dtnew.Rows[i]["FabricRemark"] = ((TextBox)grdRiskAccessories.Rows[i].FindControl("txtRemarkEdit")).Text;
                        }
                        dtnew.AcceptChanges();
                        sl = dtnew.Rows.Count;
                        dtnew.Rows.Add(0, styleid, Username + "(" + date + "): ", Remark, sl + 1, sl + 1);
                        ViewState["AccessoriesData"] = dtnew;
                    }
                }

                BindAccessoriesGrd(CreateNew, NewRefrence, ReUse, ReUseStyleId, ReUseStyleNumber, false);

            }
        }
        protected void grdRiskAccessories_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            bool EnableHOPPM = grdRiskAccessories.Enabled;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Literal ltIndex = (Literal)e.Row.FindControl("ltIndex");
                //ltIndex.Text = ((grdRiskAccessories.PageIndex * grdRiskAccessories.PageSize) + e.Row.RowIndex + 1).ToString();
                LinkButton lnkDelete = (LinkButton)e.Row.FindControl("lnkDelete");
                if (!EnableHOPPM)
                {
                    lnkDelete.Visible = false;
                }

                TextBox txtRemarkEdit = (TextBox)e.Row.FindControl("txtRemarkEdit");
                NewRefrence = Convert.ToInt32(hdnHoppmNewRef.Value);
                if (chkProdQAMgr.Checked == true && chkMM.Checked == true && chkFactoryPPMComplete.Checked == true && chkHOPPMComplete.Checked == true)
                {
                    if (NewRefrence == 1)
                    {
                        txtRemarkEdit.Enabled = true;
                        lnkDelete.Visible = true;
                        lnkDelete.Attributes.Add("style", "display:block;");
                    }
                    else
                    {
                        if (bRepeatCheck == true)
                        {
                        }
                        else
                        {
                            txtRemarkEdit.Enabled = false;
                            lnkDelete.Visible = false;
                            lnkDelete.Attributes.Add("style", "display:none;");
                        }
                    }
                }

            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                LinkButton abtnAdd = (LinkButton)e.Row.FindControl("abtnAdd");
                if (!EnableHOPPM)
                {
                    abtnAdd.Visible = false;
                }
                NewRefrence = Convert.ToInt32(hdnHoppmNewRef.Value);
                TextBox txtRemarkFooter = (TextBox)e.Row.FindControl("txtRemarkFooter");
                if (chkProdQAMgr.Checked == true && chkMM.Checked == true && chkFactoryPPMComplete.Checked == true && chkHOPPMComplete.Checked == true)
                {
                    if (NewRefrence == 1)
                    {
                        txtRemarkFooter.Enabled = true;
                        abtnAdd.Visible = true;
                    }
                    else
                    {
                        if (bRepeatCheck == true)
                        {
                        }
                        else
                        {
                            txtRemarkFooter.Enabled = false;
                            abtnAdd.Visible = false;
                        }

                    }

                }
            }
            if (e.Row.RowType == DataControlRowType.EmptyDataRow)
            {
                LinkButton addbutton = (LinkButton)e.Row.FindControl("addbutton");
                if (!EnableHOPPM)
                {
                    addbutton.Visible = false;
                }
            }
        }
        protected void grdRiskAccessories_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = grdRiskAccessories.Rows[e.RowIndex];
            HiddenField hdndataTableId = (HiddenField)row.FindControl("hdndataTableId");
            HiddenField hdnRiskFabricId = (HiddenField)row.FindControl("hdnRiskId");
            DataTable dtnew = new DataTable();
            string RemarksType = "Accesories";
            if (ViewState["AccessoriesData"] != null)
            {
                dtnew = (DataTable)(ViewState["AccessoriesData"]);
                if (hdnRiskFabricId.Value != "0")
                {
                    dtnew.Rows.Remove(dtnew.Select("RiskFabricId=" + hdnRiskFabricId.Value)[0]);
                    int IsDelete = obj_ProcessController.DeleteHoppmRemarkById(Convert.ToInt32(hdnRiskFabricId.Value), RemarksType);
                }
                else
                {
                    dtnew.Rows.Remove(dtnew.Select("dataTableId=" + hdndataTableId.Value)[0]);
                }
                ViewState["AccessoriesData"] = dtnew;
            }


            grdRiskAccessories.EditIndex = -1;
            BindAccessoriesGrd(CreateNew, NewRefrence, ReUse, ReUseStyleId, ReUseStyleNumber, false);
        }
        protected void grdRiskAccessories_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {

        }
        protected void SaveAccessoryRemark(int CreateNew, int NewRefrence, int ReUse, int ReUseStyleId)
        {
            RiskAnalysisOB objRisk = new RiskAnalysisOB();

            int UserId = iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.UserID;
            int RiskFabricId = 0;
            int StyleSequence = 0;
            string RemarksType = "Accesories";

            Control control = null;
            control = grdRiskAccessories.Controls[0].Controls[0];
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
                        int isave = obj_ProcessController.InsertUpdateHOPPMRemarks(stylenumber, styleid, strClientId, DepartmentId, CreateNew, NewRefrence, ReUse, ReUseStyleId, RemarksEmpty, RiskFabricId, StyleSequence, RemarksType, UserId);
                    }
                }
            }
            else
            {

                for (int i = 0; i < grdRiskAccessories.Rows.Count; i++)
                {
                    TextBox RemarkEdit = (TextBox)grdRiskAccessories.Rows[i].FindControl("txtRemarkEdit");
                    HiddenField hdnRiskId = (HiddenField)grdRiskAccessories.Rows[i].FindControl("hdnRiskId");
                    HiddenField hdnStyleSequence = (HiddenField)grdRiskAccessories.Rows[i].FindControl("hdnStyleSequence");
                    string Remark = RemarkEdit.Text.Trim();
                    //Remark = Regex.Replace(Remark, @"\s+", "");
                    if (hdnRiskId != null)
                    {
                        if (hdnRiskId.Value == "")
                        {
                            RiskFabricId = 0;
                        }
                        else
                        {
                            RiskFabricId = Convert.ToInt32(hdnRiskId.Value);
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
                            int isave = obj_ProcessController.InsertUpdateHOPPMRemarks(stylenumber, styleid, strClientId, DepartmentId, CreateNew, NewRefrence, ReUse, ReUseStyleId, Remark, RiskFabricId, StyleSequence, RemarksType, UserId);
                        }
                    }
                }

                var footerRow = grdRiskAccessories.FooterRow;
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
                            int isave = obj_ProcessController.InsertUpdateHOPPMRemarks(stylenumber, styleid, strClientId, DepartmentId, CreateNew, NewRefrence, ReUse, ReUseStyleId, RemarkFooter, RiskFabricId, StyleSequence, RemarksType, UserId);
                        }
                    }
                }
            }
            if (ReUse == 1)
            {
                int SaveData = obj_ProcessController.ReuseHoppmRemarks(styleid, ReUse, RemarksType, UserId);
            }
            ViewState["AccessoriesData"] = null;

        }

        // write Complete Block for the R&D Grid here
        protected void BindgrdRiskRnD(int CreateNew, int NewRef, int ReUse, int ReUseStyleId, string ReUseStyleNumber, bool Submited)
        {
            DataSet dsgrd = new DataSet();
            string RemarksType = "RnD";
            if (Submited)
            {
                if (chkMM.Checked)
                {
                    if (bRepeatCheck == true)
                        grdRiskRnD.Enabled = true;
                    else
                        grdRiskRnD.Enabled = false;
                }
                else
                {
                    grdRiskRnD.Enabled = true;
                }
            }
            else
            {
                grdRiskRnD.Enabled = true;
            }
            if (CreateNew == 1)
            {
                dsgrd = obj_ProcessController.GetHOPPMRemarks(stylenumber, styleid, strClientId, DepartmentId, CreateNew, NewRef, ReUse, ReUseStyleId, RemarksType);
                grdRiskRnD.DataSource = dsgrd.Tables[0];
                grdRiskRnD.DataBind();
                ViewState["RnDData"] = dsgrd.Tables[0];

            }
            else if (NewRef == 1)
            {
                dsgrd = obj_ProcessController.GetHOPPMRemarks(stylenumber, styleid, strClientId, DepartmentId, CreateNew, NewRef, ReUse, ReUseStyleId, RemarksType);
                grdRiskRnD.DataSource = dsgrd.Tables[0];
                grdRiskRnD.DataBind();
                ViewState["RnDData"] = dsgrd.Tables[0];

            }
            else if (ReUse == 1)
            {
                dsgrd = obj_ProcessController.GetHOPPMRemarks(stylenumber, styleid, strClientId, DepartmentId, CreateNew, NewRef, ReUse, ReUseStyleId, RemarksType);
                grdRiskRnD.DataSource = dsgrd.Tables[0];
                grdRiskRnD.DataBind();
                ViewState["RnDData"] = dsgrd.Tables[0];

            }
            else
            {
                //if (ViewState["AccessoriesData"] == null)
                //{
                dsgrd = obj_ProcessController.GetHOPPMRemarks(stylenumber, styleid, strClientId, DepartmentId, CreateNew, NewRef, ReUse, ReUseStyleId, RemarksType);
                grdRiskRnD.DataSource = dsgrd.Tables[0];
                grdRiskRnD.DataBind();
                ViewState["RnDData"] = dsgrd.Tables[0];

                //}
                //else
                //{
                //    DataTable dtnew = (DataTable)(ViewState["AccessoriesData"]);
                //    grdRiskAccessories.DataSource = dtnew;
                //    grdRiskAccessories.DataBind();
                //    ViewState["AccessoriesData"] = dtnew;

                //}
            }

        }
        protected void grdRiskRnD_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string Username = iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.FirstName;
            //string[] name = Username.Split('@');
            string date = DateTime.Now.ToString("dd MMM yyyy");
            if (e.CommandName == "Insert")
            {
                TextBox txtRemarkFooter = grdRiskRnD.FooterRow.FindControl("txtRemarkFooter") as TextBox;
                LinkButton abtnAdd = grdRiskRnD.FooterRow.FindControl("abtnAdd") as LinkButton;

                DataTable dtnew = new DataTable();
                string Remark = txtRemarkFooter.Text.Trim();
                if (Remark == "")
                {
                    ShowAlert("Please Enter Remarks");
                    return;
                }
                else
                {
                    //added by abhishek on 23/11/2015
                    SaveRnDRemark(0, 0, 0, -1);
                    //end by abhishek 23/10/2015
                    if (ViewState["RnDData"] != null)
                    {
                        dtnew = (DataTable)(ViewState["RnDData"]);
                        for (int i = 0; i < grdRiskRnD.Rows.Count; i++)
                        {
                            dtnew.Rows[i]["FabricRemark"] = ((TextBox)grdRiskRnD.Rows[i].FindControl("txtRemarkEdit")).Text;
                        }
                        dtnew.AcceptChanges();
                        sl = dtnew.Rows.Count;
                        dtnew.Rows.Add(0, styleid, Username + "(" + date + "): ", Remark, sl + 1, sl + 1);
                        ViewState["RnDData"] = dtnew;
                    }
                }

                BindgrdRiskRnD(CreateNew, NewRefrence, ReUse, ReUseStyleId, ReUseStyleNumber, false);
            }
            if (e.CommandName == "addnew")
            {

                Table tblGrdviewApplet = (Table)grdRiskRnD.Controls[0];
                GridViewRow rows = (GridViewRow)tblGrdviewApplet.Controls[0];
                TextBox txtRemarksEmpty = (TextBox)rows.FindControl("txtRemarksEmpty");

                DataTable dtnew = new DataTable();
                string Remark = txtRemarksEmpty.Text.Trim();
                if (Remark == "")
                {
                    ShowAlert("Please Enter Remarks");
                    return;
                }
                else
                {
                    //added by abhishek on 23/11/2015
                    SaveRnDRemark(0, 0, 0, -1);
                    //end by abhishek 23/10/2015
                    if (ViewState["RnDData"] != null)
                    {
                        dtnew = (DataTable)(ViewState["RnDData"]);
                        for (int i = 0; i < grdRiskRnD.Rows.Count; i++)
                        {
                            dtnew.Rows[i]["FabricRemark"] = ((TextBox)grdRiskRnD.Rows[i].FindControl("txtRemarkEdit")).Text;
                        }
                        dtnew.AcceptChanges();
                        sl = dtnew.Rows.Count;
                        dtnew.Rows.Add(0, styleid, Username + "(" + date + "): ", Remark, sl + 1, sl + 1);
                        ViewState["RnDData"] = dtnew;
                    }
                }

                BindgrdRiskRnD(CreateNew, NewRefrence, ReUse, ReUseStyleId, ReUseStyleNumber, false);

            }
        }
        protected void grdRiskRnD_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            bool EnableHOPPM = grdRiskRnD.Enabled;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Literal ltIndex = (Literal)e.Row.FindControl("ltIndex");
                //ltIndex.Text = ((grdRiskAccessories.PageIndex * grdRiskAccessories.PageSize) + e.Row.RowIndex + 1).ToString();
                LinkButton lnkDelete = (LinkButton)e.Row.FindControl("lnkDelete");
                if (!EnableHOPPM)
                {
                    lnkDelete.Visible = false;
                }

                TextBox txtRemarkEdit = (TextBox)e.Row.FindControl("txtRemarkEdit");
                NewRefrence = Convert.ToInt32(hdnHoppmNewRef.Value);
                if (chkProdQAMgr.Checked == true && chkMM.Checked == true && chkFactoryPPMComplete.Checked == true && chkHOPPMComplete.Checked == true)
                {
                    if (NewRefrence == 1)
                    {
                        txtRemarkEdit.Enabled = true;
                        lnkDelete.Visible = true;
                        lnkDelete.Attributes.Add("style", "display:block;");
                    }
                    else
                    {
                        if (bRepeatCheck == true)
                        {
                        }
                        else
                        {
                            txtRemarkEdit.Enabled = false;
                            lnkDelete.Visible = false;
                            lnkDelete.Attributes.Add("style", "display:none;");
                        }
                    }
                }

            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                LinkButton abtnAdd = (LinkButton)e.Row.FindControl("abtnAdd");
                if (!EnableHOPPM)
                {
                    abtnAdd.Visible = false;
                }
                NewRefrence = Convert.ToInt32(hdnHoppmNewRef.Value);
                TextBox txtRemarkFooter = (TextBox)e.Row.FindControl("txtRemarkFooter");
                if (chkProdQAMgr.Checked == true && chkMM.Checked == true && chkFactoryPPMComplete.Checked == true && chkHOPPMComplete.Checked == true)
                {
                    if (NewRefrence == 1)
                    {
                        txtRemarkFooter.Enabled = true;
                        abtnAdd.Visible = true;
                    }
                    else
                    {
                        if (bRepeatCheck == true)
                        {
                        }
                        else
                        {
                            txtRemarkFooter.Enabled = false;
                            abtnAdd.Visible = false;
                        }

                    }

                }
            }
            if (e.Row.RowType == DataControlRowType.EmptyDataRow)
            {
                LinkButton addbutton = (LinkButton)e.Row.FindControl("addbutton");
                if (!EnableHOPPM)
                {
                    addbutton.Visible = false;
                }
            }
        }
        protected void grdRiskRnD_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = grdRiskRnD.Rows[e.RowIndex];
            HiddenField hdndataTableId = (HiddenField)row.FindControl("hdndataTableId");
            HiddenField hdnRiskFabricId = (HiddenField)row.FindControl("hdnRiskId");
            DataTable dtnew = new DataTable();
            string RemarksType = "RnD";
            if (ViewState["RnDData"] != null)
            {
                dtnew = (DataTable)(ViewState["RnDData"]);
                if (hdnRiskFabricId.Value != "0")
                {
                    dtnew.Rows.Remove(dtnew.Select("RiskRnDId=" + hdnRiskFabricId.Value)[0]);
                    int IsDelete = obj_ProcessController.DeleteHoppmRemarkById(Convert.ToInt32(hdnRiskFabricId.Value), RemarksType);
                }
                else
                {
                    dtnew.Rows.Remove(dtnew.Select("dataTableId=" + hdndataTableId.Value)[0]);
                }
                ViewState["RnDData"] = dtnew;
            }


            grdRiskRnD.EditIndex = -1;
            BindgrdRiskRnD(CreateNew, NewRefrence, ReUse, ReUseStyleId, ReUseStyleNumber, false);
        }
        protected void grdRiskRnD_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {

        }
        protected void SaveRnDRemark(int CreateNew, int NewRefrence, int ReUse, int ReUseStyleId)
        {
            RiskAnalysisOB objRisk = new RiskAnalysisOB();

            int UserId = iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.UserID;
            int RiskFabricId = 0;
            int StyleSequence = 0;
            string RemarksType = "RnD";

            Control control = null;
            control = grdRiskRnD.Controls[0].Controls[0];
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
                        int isave = obj_ProcessController.InsertUpdateHOPPMRemarks(stylenumber, styleid, strClientId, DepartmentId, CreateNew, NewRefrence, ReUse, ReUseStyleId, RemarksEmpty, RiskFabricId, StyleSequence, RemarksType, UserId);
                    }
                }
            }
            else
            {

                for (int i = 0; i < grdRiskRnD.Rows.Count; i++)
                {
                    TextBox RemarkEdit = (TextBox)grdRiskRnD.Rows[i].FindControl("txtRemarkEdit");
                    HiddenField hdnRiskId = (HiddenField)grdRiskRnD.Rows[i].FindControl("hdnRiskId");
                    HiddenField hdnStyleSequence = (HiddenField)grdRiskRnD.Rows[i].FindControl("hdnStyleSequence");
                    string Remark = RemarkEdit.Text.Trim();
                    //Remark = Regex.Replace(Remark, @"\s+", "");
                    if (hdnRiskId != null)
                    {
                        if (hdnRiskId.Value == "")
                        {
                            RiskFabricId = 0;
                        }
                        else
                        {
                            RiskFabricId = Convert.ToInt32(hdnRiskId.Value);
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
                            int isave = obj_ProcessController.InsertUpdateHOPPMRemarks(stylenumber, styleid, strClientId, DepartmentId, CreateNew, NewRefrence, ReUse, ReUseStyleId, Remark, RiskFabricId, StyleSequence, RemarksType, UserId);
                        }
                    }
                }

                var footerRow = grdRiskRnD.FooterRow;
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
                            int isave = obj_ProcessController.InsertUpdateHOPPMRemarks(stylenumber, styleid, strClientId, DepartmentId, CreateNew, NewRefrence, ReUse, ReUseStyleId, RemarkFooter, RiskFabricId, StyleSequence, RemarksType, UserId);
                        }
                    }
                }
            }
            if (ReUse == 1)
            {
                int SaveData = obj_ProcessController.ReuseHoppmRemarks(styleid, ReUse, RemarksType, UserId);
            }
            ViewState["RnDData"] = null;

        }

        //Fiting
        protected void BindFitingGrd(int CreateNew, int NewRef, int ReUse, int ReUseStyleId, string ReUseStyleNumber, bool Submited)
        {
            DataSet dsgrd = new DataSet();
            string RemarksType = "Fitting";
            if (Submited)
            {
                if (chkMM.Checked)
                {
                    if (bRepeatCheck == true)
                        grdriskFiting.Enabled = true;
                    else
                        grdriskFiting.Enabled = false;
                }
                else
                {
                    grdriskFiting.Enabled = true;
                }
            }
            else
            {
                grdriskFiting.Enabled = true;
            }
            if (CreateNew == 1)
            {
                dsgrd = obj_ProcessController.GetHOPPMRemarks(stylenumber, styleid, strClientId, DepartmentId, CreateNew, NewRef, ReUse, ReUseStyleId, RemarksType);
                grdriskFiting.DataSource = dsgrd.Tables[0];
                grdriskFiting.DataBind();
                ViewState["FitingData"] = dsgrd.Tables[0];

            }
            else if (NewRef == 1)
            {
                dsgrd = obj_ProcessController.GetHOPPMRemarks(stylenumber, styleid, strClientId, DepartmentId, CreateNew, NewRef, ReUse, ReUseStyleId, RemarksType);
                grdriskFiting.DataSource = dsgrd.Tables[0];
                grdriskFiting.DataBind();
                ViewState["FitingData"] = dsgrd.Tables[0];

            }
            else if (ReUse == 1)
            {
                dsgrd = obj_ProcessController.GetHOPPMRemarks(stylenumber, styleid, strClientId, DepartmentId, CreateNew, NewRef, ReUse, ReUseStyleId, RemarksType);
                grdriskFiting.DataSource = dsgrd.Tables[0];
                grdriskFiting.DataBind();
                ViewState["FitingData"] = dsgrd.Tables[0];
            }
            else
            {
                if (ViewState["FitingData"] == null)
                {
                    dsgrd = obj_ProcessController.GetHOPPMRemarks(stylenumber, styleid, strClientId, DepartmentId, CreateNew, NewRef, ReUse, ReUseStyleId, RemarksType);
                    grdriskFiting.DataSource = dsgrd.Tables[0];
                    grdriskFiting.DataBind();
                    ViewState["FitingData"] = dsgrd.Tables[0];
                }
                else
                {
                    DataTable dtnew = (DataTable)(ViewState["FitingData"]);
                    grdriskFiting.DataSource = dtnew;
                    grdriskFiting.DataBind();
                    ViewState["FitingData"] = dtnew;

                }
            }

        }
        protected void grdriskFiting_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string Username = iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.FirstName;
            //string[] name = Username.Split('@');
            string date = DateTime.Now.ToString("dd MMM yyyy");
            if (e.CommandName == "Insert")
            {
                TextBox txtRemarkFooter = grdriskFiting.FooterRow.FindControl("txtRemarkFooter") as TextBox;
                LinkButton abtnAdd = grdriskFiting.FooterRow.FindControl("abtnAdd") as LinkButton;

                DataTable dtnew = new DataTable();
                string Remark = txtRemarkFooter.Text.Trim();
                if (Remark == "")
                {
                    ShowAlert("Please Enter Remarks");
                    return;
                }
                else
                {
                    //added by abhishek on 23/11/2015
                    SaveFitingRemark(0, 0, 0, -1);
                    //end by abhishek on 23/11/2015

                    if (ViewState["FitingData"] != null)
                    {
                        dtnew = (DataTable)(ViewState["FitingData"]);
                        for (int i = 0; i < grdriskFiting.Rows.Count; i++)
                        {
                            dtnew.Rows[i]["FabricRemark"] = ((TextBox)grdriskFiting.Rows[i].FindControl("txtRemarkEdit")).Text;
                        }
                        dtnew.AcceptChanges();
                        sl = dtnew.Rows.Count;
                        dtnew.Rows.Add(0, styleid, Username + "(" + date + "): ", Remark, sl + 1, sl + 1);
                        ViewState["FitingData"] = dtnew;
                    }
                }

                BindFitingGrd(CreateNew, NewRefrence, ReUse, ReUseStyleId, ReUseStyleNumber, false);
            }
            if (e.CommandName == "addnew")
            {

                Table tblGrdviewApplet = (Table)grdriskFiting.Controls[0];
                GridViewRow rows = (GridViewRow)tblGrdviewApplet.Controls[0];
                TextBox txtRemarksEmpty = (TextBox)rows.FindControl("txtRemarksEmpty");

                DataTable dtnew = new DataTable();
                string Remark = txtRemarksEmpty.Text.Trim();
                //Remark = Regex.Replace(Remark, @"\s+", "");
                if (Remark == "")
                {
                    ShowAlert("Please Enter Remarks");
                    return;
                }
                else
                {
                    //added by abhishek on 23/11/2015
                    SaveFitingRemark(0, 0, 0, -1);
                    //end by abhishek on 23/11/2015

                    if (ViewState["FitingData"] != null)
                    {
                        dtnew = (DataTable)(ViewState["FitingData"]);
                        for (int i = 0; i < grdriskFiting.Rows.Count; i++)
                        {
                            dtnew.Rows[i]["FabricRemark"] = ((TextBox)grdriskFiting.Rows[i].FindControl("txtRemarkEdit")).Text;
                        }
                        dtnew.AcceptChanges();
                        sl = dtnew.Rows.Count;
                        dtnew.Rows.Add(0, styleid, Username + "(" + date + "): ", Remark, sl + 1, sl + 1);
                        ViewState["FitingData"] = dtnew;
                    }
                }
                BindFitingGrd(CreateNew, NewRefrence, ReUse, ReUseStyleId, ReUseStyleNumber, false);

            }
        }
        protected void grdriskFiting_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            bool EnableHOPPM = grdriskFiting.Enabled;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Literal ltIndex = (Literal)e.Row.FindControl("ltIndex");
                //ltIndex.Text = ((grdriskFiting.PageIndex * grdriskFiting.PageSize) + e.Row.RowIndex + 1).ToString();
                LinkButton lnkDelete = (LinkButton)e.Row.FindControl("lnkDelete");
                if (!EnableHOPPM)
                {
                    lnkDelete.Visible = false;
                }

                TextBox txtRemarkEdit = (TextBox)e.Row.FindControl("txtRemarkEdit");
                NewRefrence = Convert.ToInt32(hdnHoppmNewRef.Value);
                if (chkProdQAMgr.Checked == true && chkMM.Checked == true && chkFactoryPPMComplete.Checked == true && chkHOPPMComplete.Checked == true)
                {
                    if (NewRefrence == 1)
                    {
                        txtRemarkEdit.Enabled = true;
                        lnkDelete.Visible = true;
                        lnkDelete.Attributes.Add("style", "display:block;");
                    }
                    else
                    {
                        txtRemarkEdit.Enabled = false;
                        lnkDelete.Visible = false;
                        lnkDelete.Attributes.Add("style", "display:none;");
                    }
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                LinkButton abtnAdd = (LinkButton)e.Row.FindControl("abtnAdd");
                if (!EnableHOPPM)
                {
                    abtnAdd.Visible = false;
                }

                NewRefrence = Convert.ToInt32(hdnHoppmNewRef.Value);
                TextBox txtRemarkFooter = (TextBox)e.Row.FindControl("txtRemarkFooter");
                if (chkProdQAMgr.Checked == true && chkMM.Checked == true && chkFactoryPPMComplete.Checked == true && chkHOPPMComplete.Checked == true)
                {
                    if (NewRefrence == 1)
                    {
                        txtRemarkFooter.Enabled = true;
                        abtnAdd.Visible = true;
                    }
                    else
                    {
                        txtRemarkFooter.Enabled = false;
                        abtnAdd.Visible = false;
                    }

                }
            }
            if (e.Row.RowType == DataControlRowType.EmptyDataRow)
            {
                LinkButton addbutton = (LinkButton)e.Row.FindControl("addbutton");
                if (!EnableHOPPM)
                {
                    addbutton.Visible = false;
                }
            }
        }
        protected void grdriskFiting_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = grdriskFiting.Rows[e.RowIndex];
            HiddenField hdndataTableId = (HiddenField)row.FindControl("hdndataTableId");
            HiddenField hdnRiskFabricId = (HiddenField)row.FindControl("hdnRiskId");
            DataTable dtnew = new DataTable();
            string RemarksType = "Fitting";
            if (ViewState["FitingData"] != null)
            {
                dtnew = (DataTable)(ViewState["FitingData"]);
                if (hdnRiskFabricId.Value != "0")
                {
                    dtnew.Rows.Remove(dtnew.Select("RiskFabricId=" + hdnRiskFabricId.Value)[0]);
                    int IsDelete = obj_ProcessController.DeleteHoppmRemarkById(Convert.ToInt32(hdnRiskFabricId.Value), RemarksType);
                }
                else
                {
                    dtnew.Rows.Remove(dtnew.Select("dataTableId=" + hdndataTableId.Value)[0]);
                }
                ViewState["FitingData"] = dtnew;
            }


            grdriskFiting.EditIndex = -1;
            BindFitingGrd(CreateNew, NewRefrence, ReUse, ReUseStyleId, ReUseStyleNumber, false);
        }
        protected void SaveFitingRemark(int CreateNew, int NewRefrence, int ReUse, int ReUseStyleId)
        {
            RiskAnalysisOB objRisk = new RiskAnalysisOB();

            int UserId = iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.UserID;
            int RiskFabricId = 0;
            int StyleSequence = 0;
            string RemarksType = "Fitting";

            Control control = null;
            control = grdriskFiting.Controls[0].Controls[0];
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
                        int isave = obj_ProcessController.InsertUpdateHOPPMRemarks(stylenumber, styleid, strClientId, DepartmentId, CreateNew, NewRefrence, ReUse, ReUseStyleId, RemarksEmpty, RiskFabricId, StyleSequence, RemarksType, UserId);
                    }
                }
            }
            else
            {

                for (int i = 0; i < grdriskFiting.Rows.Count; i++)
                {
                    TextBox RemarkEdit = (TextBox)grdriskFiting.Rows[i].FindControl("txtRemarkEdit");
                    HiddenField hdnRiskId = (HiddenField)grdriskFiting.Rows[i].FindControl("hdnRiskId");
                    HiddenField hdnStyleSequence = (HiddenField)grdriskFiting.Rows[i].FindControl("hdnStyleSequence");
                    string Remark = RemarkEdit.Text.Trim();

                    if (hdnRiskId != null)
                    {
                        if (hdnRiskId.Value == "")
                        {
                            RiskFabricId = 0;
                        }
                        else
                        {
                            RiskFabricId = Convert.ToInt32(hdnRiskId.Value);
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
                            int isave = obj_ProcessController.InsertUpdateHOPPMRemarks(stylenumber, styleid, strClientId, DepartmentId, CreateNew, NewRefrence, ReUse, ReUseStyleId, Remark, RiskFabricId, StyleSequence, RemarksType, UserId);
                        }
                    }

                }
                var footerRow = grdriskFiting.FooterRow;
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
                            int isave = obj_ProcessController.InsertUpdateHOPPMRemarks(stylenumber, styleid, strClientId, DepartmentId, CreateNew, NewRefrence, ReUse, ReUseStyleId, RemarkFooter, RiskFabricId, StyleSequence, RemarksType, UserId);
                        }
                    }
                }
            }
            if (ReUse == 1)
            {
                int SaveData = obj_ProcessController.ReuseHoppmRemarks(styleid, ReUse, RemarksType, UserId);
            }

            ViewState["FitingData"] = null;
            //BindFitingGrd(CreateNew, NewRefrence, ReUse, ReUseStyleId, ReUseStyleNumber,true);
        }

        //Making
        protected void BindMakingGrd(int CreateNew, int NewRef, int ReUse, int ReUseStyleId, string ReUseStyleNumber, bool Submited)
        {
            DataSet dsgrd = new DataSet();
            string RemarksType = "Making";
            if (Submited)
            {
                if (chkMM.Checked)
                {
                    if (bRepeatCheck == true)
                        grdRiskMaking.Enabled = true;
                    else
                        grdRiskMaking.Enabled = false;
                }
                else
                {
                    grdRiskMaking.Enabled = true;
                }
            }
            else
            {
                grdRiskMaking.Enabled = true;
            }
            if (CreateNew == 1)
            {
                dsgrd = obj_ProcessController.GetHOPPMRemarks(stylenumber, styleid, strClientId, DepartmentId, CreateNew, NewRef, ReUse, ReUseStyleId, RemarksType);
                grdRiskMaking.DataSource = dsgrd.Tables[0];
                grdRiskMaking.DataBind();
                ViewState["MakingData"] = dsgrd.Tables[0];

            }
            else if (NewRef == 1)
            {
                dsgrd = obj_ProcessController.GetHOPPMRemarks(stylenumber, styleid, strClientId, DepartmentId, CreateNew, NewRef, ReUse, ReUseStyleId, RemarksType);
                grdRiskMaking.DataSource = dsgrd.Tables[0];
                grdRiskMaking.DataBind();
                ViewState["MakingData"] = dsgrd.Tables[0];
            }
            else if (ReUse == 1)
            {
                dsgrd = obj_ProcessController.GetHOPPMRemarks(stylenumber, styleid, strClientId, DepartmentId, CreateNew, NewRef, ReUse, ReUseStyleId, RemarksType);
                grdRiskMaking.DataSource = dsgrd.Tables[0];
                grdRiskMaking.DataBind();
                ViewState["MakingData"] = dsgrd.Tables[0];

            }
            else
            {
                //if (ViewState["MakingData"] == null)
                //{
                dsgrd = obj_ProcessController.GetHOPPMRemarks(stylenumber, styleid, strClientId, DepartmentId, CreateNew, NewRef, ReUse, ReUseStyleId, RemarksType);
                grdRiskMaking.DataSource = dsgrd.Tables[0];
                grdRiskMaking.DataBind();
                ViewState["MakingData"] = dsgrd.Tables[0];

                //}
                //else
                //{ 
                //    DataTable dtnew = (DataTable)(ViewState["MakingData"]);                    
                //    grdRiskMaking.DataSource = dtnew;
                //    grdRiskMaking.DataBind();
                //    ViewState["MakingData"] = dtnew;

                //}
            }

        }
        protected void grdRiskMaking_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string Username = iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.FirstName;
            //string[] name = Username.Split('@');
            string date = DateTime.Now.ToString("dd MMM yyyy");
            if (e.CommandName == "Insert")
            {
                TextBox txtRemarkFooter = grdRiskMaking.FooterRow.FindControl("txtRemarkFooter") as TextBox;
                LinkButton abtnAdd = grdRiskMaking.FooterRow.FindControl("abtnAdd") as LinkButton;

                DataTable dtnew = new DataTable();
                string Remark = txtRemarkFooter.Text.Trim();
                if (Remark == "")
                {
                    ShowAlert("Please Enter Remarks");
                    return;
                }
                else
                {
                    //addde by abhishek on 23/11/2015
                    SaveMakingRemark(0, 0, 0, -1);
                    //end abhishek on 23/11/2015
                    if (ViewState["MakingData"] != null)
                    {
                        dtnew = (DataTable)(ViewState["MakingData"]);
                        for (int i = 0; i < grdRiskMaking.Rows.Count; i++)
                        {
                            dtnew.Rows[i]["FabricRemark"] = ((TextBox)grdRiskMaking.Rows[i].FindControl("txtRemarkEdit")).Text;
                        }
                        dtnew.AcceptChanges();
                        sl = dtnew.Rows.Count;
                        dtnew.Rows.Add(0, styleid, Username + "(" + date + "): ", Remark, sl + 1, sl + 1);
                        ViewState["MakingData"] = dtnew;
                    }
                }
                BindMakingGrd(CreateNew, NewRefrence, ReUse, ReUseStyleId, ReUseStyleNumber, false);

            }
            if (e.CommandName == "addnew")
            {

                Table tblGrdviewApplet = (Table)grdRiskMaking.Controls[0];
                GridViewRow rows = (GridViewRow)tblGrdviewApplet.Controls[0];
                TextBox txtRemarksEmpty = (TextBox)rows.FindControl("txtRemarksEmpty");

                DataTable dtnew = new DataTable();
                string Remark = txtRemarksEmpty.Text.Trim();
                //Remark = Regex.Replace(Remark, @"\s+", "");
                if (Remark == "")
                {
                    ShowAlert("Please Enter Remarks");
                    return;
                }
                else
                {
                    //addde by abhishek on 23/11/2015
                    SaveMakingRemark(0, 0, 0, -1);
                    //end abhishek on 23/11/2015
                    if (ViewState["MakingData"] != null)
                    {
                        dtnew = (DataTable)(ViewState["MakingData"]);
                        for (int i = 0; i < grdRiskMaking.Rows.Count; i++)
                        {
                            dtnew.Rows[i]["FabricRemark"] = ((TextBox)grdRiskMaking.Rows[i].FindControl("txtRemarkEdit")).Text;
                        }
                        dtnew.AcceptChanges();
                        sl = dtnew.Rows.Count;
                        dtnew.Rows.Add(0, styleid, Username + "(" + date + "): ", Remark, sl + 1, sl + 1);
                        ViewState["MakingData"] = dtnew;
                    }
                }
                BindMakingGrd(CreateNew, NewRefrence, ReUse, ReUseStyleId, ReUseStyleNumber, false);
            }
        }
        protected void grdRiskMaking_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            bool EnableHOPPM = grdRiskMaking.Enabled;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Literal ltIndex = (Literal)e.Row.FindControl("ltIndex");
                //abhishek 20/6/2016
                //ltIndex.Text = ((grdRiskMaking.PageIndex * grdRiskMaking.PageSize) + e.Row.RowIndex + 1).ToString();

                LinkButton lnkDelete = (LinkButton)e.Row.FindControl("lnkDelete");
                if (!EnableHOPPM)
                {
                    lnkDelete.Visible = false;
                }
                TextBox txtRemarkEdit = (TextBox)e.Row.FindControl("txtRemarkEdit");
                NewRefrence = Convert.ToInt32(hdnHoppmNewRef.Value);
                if (chkProdQAMgr.Checked == true && chkMM.Checked == true && chkFactoryPPMComplete.Checked == true && chkHOPPMComplete.Checked == true)
                {
                    if (NewRefrence == 1)
                    {
                        txtRemarkEdit.Enabled = true;
                        lnkDelete.Visible = true;
                        lnkDelete.Attributes.Add("style", "display:block;");
                    }
                    else
                    {
                        if (bRepeatCheck == true)
                        {
                            txtRemarkEdit.Enabled = true;
                            lnkDelete.Visible = true;
                            // lnkDelete.Attributes.Add("style", "display:none;");
                        }
                        else
                        {
                            txtRemarkEdit.Enabled = false;
                            lnkDelete.Visible = false;
                            lnkDelete.Attributes.Add("style", "display:none;");
                        }

                    }
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                LinkButton abtnAdd = (LinkButton)e.Row.FindControl("abtnAdd");
                if (!EnableHOPPM)
                {
                    abtnAdd.Visible = false;
                }
                NewRefrence = Convert.ToInt32(hdnHoppmNewRef.Value);
                TextBox txtRemarkFooter = (TextBox)e.Row.FindControl("txtRemarkFooter");
                if (chkProdQAMgr.Checked == true && chkMM.Checked == true && chkFactoryPPMComplete.Checked == true && chkHOPPMComplete.Checked == true)
                {
                    if (NewRefrence == 1)
                    {
                        txtRemarkFooter.Enabled = true;
                        abtnAdd.Visible = true;
                    }
                    else
                    {
                        txtRemarkFooter.Enabled = false;
                        abtnAdd.Visible = false;
                    }

                }
            }
            if (e.Row.RowType == DataControlRowType.EmptyDataRow)
            {
                LinkButton addbutton = (LinkButton)e.Row.FindControl("addbutton");
                if (!EnableHOPPM)
                {
                    addbutton.Visible = false;
                }
            }
        }
        //protected void grdRiskMaking_OnRowCreated(object sender, GridViewRowEventArgs e)
        //{
        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {
        //        e.Row.Cells[0].CssClass = "hiddencol";
        //    }
        //    else if (e.Row.RowType == DataControlRowType.Header)
        //    {
        //        e.Row.Cells[0].CssClass = "hiddencol";
        //    }
        //}
        protected void grdRiskMaking_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = grdRiskMaking.Rows[e.RowIndex];
            HiddenField hdndataTableId = (HiddenField)row.FindControl("hdndataTableId");
            HiddenField hdnRiskFabricId = (HiddenField)row.FindControl("hdnRiskId");
            DataTable dtnew = new DataTable();
            string RemarksType = "Making";
            if (ViewState["MakingData"] != null)
            {
                dtnew = (DataTable)(ViewState["MakingData"]);
                if (hdnRiskFabricId.Value != "0")
                {
                    dtnew.Rows.Remove(dtnew.Select("RiskFabricId=" + hdnRiskFabricId.Value)[0]);
                    int IsDelete = obj_ProcessController.DeleteHoppmRemarkById(Convert.ToInt32(hdnRiskFabricId.Value), RemarksType);
                }
                else
                {
                    dtnew.Rows.Remove(dtnew.Select("dataTableId=" + hdndataTableId.Value)[0]);
                }
                ViewState["MakingData"] = dtnew;
            }


            grdRiskMaking.EditIndex = -1;
            BindMakingGrd(CreateNew, NewRefrence, ReUse, ReUseStyleId, ReUseStyleNumber, false);
        }
        protected void SaveMakingRemark(int CreateNew, int NewRefrence, int ReUse, int ReUseStyleId)
        {
            RiskAnalysisOB objRisk = new RiskAnalysisOB();

            int UserId = iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.UserID;
            int RiskFabricId = 0;
            int StyleSequence = 0;
            string RemarksType = "Making";

            Control control = null;
            control = grdRiskMaking.Controls[0].Controls[0];
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
                        int isave = obj_ProcessController.InsertUpdateHOPPMRemarks(stylenumber, styleid, strClientId, DepartmentId, CreateNew, NewRefrence, ReUse, ReUseStyleId, RemarksEmpty, RiskFabricId, StyleSequence, RemarksType, UserId);
                    }
                }
            }
            else
            {

                for (int i = 0; i < grdRiskMaking.Rows.Count; i++)
                {
                    TextBox RemarkEdit = (TextBox)grdRiskMaking.Rows[i].FindControl("txtRemarkEdit");
                    HiddenField hdnRiskId = (HiddenField)grdRiskMaking.Rows[i].FindControl("hdnRiskId");
                    HiddenField hdnStyleSequence = (HiddenField)grdRiskMaking.Rows[i].FindControl("hdnStyleSequence");
                    string Remark = RemarkEdit.Text.Trim();
                    //Remark = Regex.Replace(Remark, @"\s+", "");
                    if (hdnRiskId != null)
                    {
                        if (hdnRiskId.Value == "")
                        {
                            RiskFabricId = 0;
                        }
                        else
                        {
                            RiskFabricId = Convert.ToInt32(hdnRiskId.Value);
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
                            int isave = obj_ProcessController.InsertUpdateHOPPMRemarks(stylenumber, styleid, strClientId, DepartmentId, CreateNew, NewRefrence, ReUse, ReUseStyleId, Remark, RiskFabricId, StyleSequence, RemarksType, UserId);
                        }
                    }

                }
                var footerRow = grdRiskMaking.FooterRow;
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
                            int isave = obj_ProcessController.InsertUpdateHOPPMRemarks(stylenumber, styleid, strClientId, DepartmentId, CreateNew, NewRefrence, ReUse, ReUseStyleId, RemarkFooter, RiskFabricId, StyleSequence, RemarksType, UserId);
                        }
                    }
                }
            }
            if (ReUse == 1)
            {
                int SaveData = obj_ProcessController.ReuseHoppmRemarks(styleid, ReUse, RemarksType, UserId);
            }

            ViewState["MakingData"] = null;
        }

        //Imbroidery
        protected void BindImbroideryGrd(int CreateNew, int NewRef, int ReUse, int ReUseStyleId, string ReUseStyleNumber, bool Submited)
        {
            DataSet dsgrd = new DataSet();
            string RemarksType = "Imbroidery";

            if (Submited)
            {
                if (chkMM.Checked)
                {
                    if (bRepeatCheck == true)
                        grdRiskImbroidery.Enabled = true;
                    else
                        grdRiskImbroidery.Enabled = false;
                }
                else
                {
                    grdRiskImbroidery.Enabled = true;
                }
            }
            else
            {
                grdRiskImbroidery.Enabled = true;
            }
            if (CreateNew == 1)
            {
                dsgrd = obj_ProcessController.GetHOPPMRemarks(stylenumber, styleid, strClientId, DepartmentId, CreateNew, NewRef, ReUse, ReUseStyleId, RemarksType);
                grdRiskImbroidery.DataSource = dsgrd.Tables[0];
                grdRiskImbroidery.DataBind();
                ViewState["ImbroideryData"] = dsgrd.Tables[0];

            }
            else if (NewRef == 1)
            {
                dsgrd = obj_ProcessController.GetHOPPMRemarks(stylenumber, styleid, strClientId, DepartmentId, CreateNew, NewRef, ReUse, ReUseStyleId, RemarksType);
                grdRiskImbroidery.DataSource = dsgrd.Tables[0];
                grdRiskImbroidery.DataBind();
                ViewState["ImbroideryData"] = dsgrd.Tables[0];

            }
            else if (ReUse == 1)
            {
                dsgrd = obj_ProcessController.GetHOPPMRemarks(stylenumber, styleid, strClientId, DepartmentId, CreateNew, NewRef, ReUse, ReUseStyleId, RemarksType);
                grdRiskImbroidery.DataSource = dsgrd.Tables[0];
                grdRiskImbroidery.DataBind();
                ViewState["ImbroideryData"] = dsgrd.Tables[0];

            }
            else
            {
                //if (ViewState["ImbroideryData"] == null)
                //{
                dsgrd = obj_ProcessController.GetHOPPMRemarks(stylenumber, styleid, strClientId, DepartmentId, CreateNew, NewRef, ReUse, ReUseStyleId, RemarksType);
                grdRiskImbroidery.DataSource = dsgrd.Tables[0];
                grdRiskImbroidery.DataBind();
                ViewState["ImbroideryData"] = dsgrd.Tables[0];

                //}
                //else
                //{
                //    DataTable dtnew = (DataTable)(ViewState["ImbroideryData"]);
                //    grdRiskImbroidery.DataSource = dtnew;
                //    grdRiskImbroidery.DataBind();
                //    ViewState["ImbroideryData"] = dtnew;

                //}
            }

        }
        protected void grdRiskImbroidery_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string Username = iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.FirstName;
            //string[] name = Username.Split('@');
            string date = DateTime.Now.ToString("dd MMM yyyy");
            if (e.CommandName == "Insert")
            {
                TextBox txtRemarkFooter = grdRiskImbroidery.FooterRow.FindControl("txtRemarkFooter") as TextBox;
                LinkButton abtnAdd = grdRiskImbroidery.FooterRow.FindControl("abtnAdd") as LinkButton;

                DataTable dtnew = new DataTable();
                string Remark = txtRemarkFooter.Text.Trim();
                if (Remark == "")
                {
                    ShowAlert("Please Enter Remarks");
                    return;
                }
                else
                {
                    //added by abhishek on 23/11/2015
                    SaveImbroideryRemark(0, 0, 0, -1);
                    //end by abhishek on 23/11/2015

                    if (ViewState["ImbroideryData"] != null)
                    {
                        dtnew = (DataTable)(ViewState["ImbroideryData"]);
                        for (int i = 0; i < grdRiskImbroidery.Rows.Count; i++)
                        {
                            dtnew.Rows[i]["FabricRemark"] = ((TextBox)grdRiskImbroidery.Rows[i].FindControl("txtRemarkEdit")).Text;
                        }
                        dtnew.AcceptChanges();
                        sl = dtnew.Rows.Count;
                        dtnew.Rows.Add(0, styleid, Username + "(" + date + "): ", Remark, sl + 1, sl + 1);
                        ViewState["ImbroideryData"] = dtnew;
                    }
                }
                BindImbroideryGrd(CreateNew, NewRefrence, ReUse, ReUseStyleId, ReUseStyleNumber, false);
            }
            if (e.CommandName == "addnew")
            {

                Table tblGrdviewApplet = (Table)grdRiskImbroidery.Controls[0];
                GridViewRow rows = (GridViewRow)tblGrdviewApplet.Controls[0];
                TextBox txtRemarksEmpty = (TextBox)rows.FindControl("txtRemarksEmpty");

                DataTable dtnew = new DataTable();
                string Remark = txtRemarksEmpty.Text.Trim();
                //Remark = Regex.Replace(Remark, @"\s+", "");
                if (Remark == "")
                {
                    ShowAlert("Please Enter Remarks");
                    return;
                }
                else
                {
                    //added by abhishek on 23/11/2015
                    SaveImbroideryRemark(0, 0, 0, -1);
                    //end by abhishek on 23/11/2015
                    if (ViewState["ImbroideryData"] != null)
                    {
                        dtnew = (DataTable)(ViewState["ImbroideryData"]);
                        for (int i = 0; i < grdRiskImbroidery.Rows.Count; i++)
                        {
                            dtnew.Rows[i]["FabricRemark"] = ((TextBox)grdRiskImbroidery.Rows[i].FindControl("txtRemarkEdit")).Text;
                        }
                        dtnew.AcceptChanges();
                        sl = dtnew.Rows.Count;
                        dtnew.Rows.Add(0, styleid, Username + "(" + date + "): ", Remark, sl + 1, sl + 1);
                        ViewState["ImbroideryData"] = dtnew;
                    }
                }
                BindImbroideryGrd(CreateNew, NewRefrence, ReUse, ReUseStyleId, ReUseStyleNumber, false);
            }
        }
        protected void grdRiskImbroidery_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            bool EnableHOPPM = grdRiskImbroidery.Enabled;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Literal ltIndex = (Literal)e.Row.FindControl("ltIndex");
                //ltIndex.Text = ((grdRiskImbroidery.PageIndex * grdRiskImbroidery.PageSize) + e.Row.RowIndex + 1).ToString();
                LinkButton lnkDelete = (LinkButton)e.Row.FindControl("lnkDelete");
                if (!EnableHOPPM)
                {
                    lnkDelete.Visible = false;
                }
                TextBox txtRemarkEdit = (TextBox)e.Row.FindControl("txtRemarkEdit");
                NewRefrence = Convert.ToInt32(hdnHoppmNewRef.Value);
                if (chkProdQAMgr.Checked == true && chkMM.Checked == true && chkFactoryPPMComplete.Checked == true && chkHOPPMComplete.Checked == true)
                {
                    if (NewRefrence == 1)
                    {
                        txtRemarkEdit.Enabled = true;
                        lnkDelete.Visible = true;
                        lnkDelete.Attributes.Add("style", "display:block;");
                    }
                    else
                    {
                        txtRemarkEdit.Enabled = false;
                        lnkDelete.Visible = false;
                        lnkDelete.Attributes.Add("style", "display:none;");
                    }
                }

            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                LinkButton abtnAdd = (LinkButton)e.Row.FindControl("abtnAdd");
                if (!EnableHOPPM)
                {
                    abtnAdd.Visible = false;
                }

                NewRefrence = Convert.ToInt32(hdnHoppmNewRef.Value);
                TextBox txtRemarkFooter = (TextBox)e.Row.FindControl("txtRemarkFooter");
                if (chkProdQAMgr.Checked == true && chkMM.Checked == true && chkFactoryPPMComplete.Checked == true && chkHOPPMComplete.Checked == true)
                {
                    if (NewRefrence == 1)
                    {
                        txtRemarkFooter.Enabled = true;
                        abtnAdd.Visible = true;
                    }
                    else
                    {
                        txtRemarkFooter.Enabled = false;
                        abtnAdd.Visible = false;
                    }

                }
            }
            if (e.Row.RowType == DataControlRowType.EmptyDataRow)
            {
                LinkButton addbutton = (LinkButton)e.Row.FindControl("addbutton");
                if (!EnableHOPPM)
                {
                    addbutton.Visible = false;
                }
            }
        }
        protected void grdRiskImbroidery_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = grdRiskImbroidery.Rows[e.RowIndex];
            HiddenField hdndataTableId = (HiddenField)row.FindControl("hdndataTableId");
            HiddenField hdnRiskFabricId = (HiddenField)row.FindControl("hdnRiskId");
            DataTable dtnew = new DataTable();
            string RemarksType = "Imbroidery";
            if (ViewState["ImbroideryData"] != null)
            {
                dtnew = (DataTable)(ViewState["ImbroideryData"]);
                if (hdnRiskFabricId.Value != "0")
                {
                    dtnew.Rows.Remove(dtnew.Select("RiskFabricId=" + hdnRiskFabricId.Value)[0]);
                    int IsDelete = obj_ProcessController.DeleteHoppmRemarkById(Convert.ToInt32(hdnRiskFabricId.Value), RemarksType);
                }
                else
                {
                    dtnew.Rows.Remove(dtnew.Select("dataTableId=" + hdndataTableId.Value)[0]);
                }
                ViewState["ImbroideryData"] = dtnew;
            }


            grdRiskImbroidery.EditIndex = -1;
            BindImbroideryGrd(CreateNew, NewRefrence, ReUse, ReUseStyleId, ReUseStyleNumber, false);
        }
        protected void SaveImbroideryRemark(int CreateNew, int NewRefrence, int ReUse, int ReUseStyleId)
        {
            RiskAnalysisOB objRisk = new RiskAnalysisOB();
            int UserId = iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.UserID;
            int RiskFabricId = 0;
            int StyleSequence = 0;
            string RemarksType = "Imbroidery";

            Control control = null;
            control = grdRiskImbroidery.Controls[0].Controls[0];
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
                        int isave = obj_ProcessController.InsertUpdateHOPPMRemarks(stylenumber, styleid, strClientId, DepartmentId, CreateNew, NewRefrence, ReUse, ReUseStyleId, RemarksEmpty, RiskFabricId, StyleSequence, RemarksType, UserId);
                    }
                }
            }
            else
            {

                for (int i = 0; i < grdRiskImbroidery.Rows.Count; i++)
                {
                    TextBox RemarkEdit = (TextBox)grdRiskImbroidery.Rows[i].FindControl("txtRemarkEdit");
                    HiddenField hdnRiskId = (HiddenField)grdRiskImbroidery.Rows[i].FindControl("hdnRiskId");
                    HiddenField hdnStyleSequence = (HiddenField)grdRiskImbroidery.Rows[i].FindControl("hdnStyleSequence");
                    string Remark = RemarkEdit.Text.Trim();
                    //Remark = Regex.Replace(Remark, @"\s+", "");
                    if (hdnRiskId != null)
                    {
                        if (hdnRiskId.Value == "")
                        {
                            RiskFabricId = 0;
                        }
                        else
                        {
                            RiskFabricId = Convert.ToInt32(hdnRiskId.Value);
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
                            int isave = obj_ProcessController.InsertUpdateHOPPMRemarks(stylenumber, styleid, strClientId, DepartmentId, CreateNew, NewRefrence, ReUse, ReUseStyleId, Remark, RiskFabricId, StyleSequence, RemarksType, UserId);
                        }
                    }

                }

                var footerRow = grdRiskImbroidery.FooterRow;
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
                            int isave = obj_ProcessController.InsertUpdateHOPPMRemarks(stylenumber, styleid, strClientId, DepartmentId, CreateNew, NewRefrence, ReUse, ReUseStyleId, RemarkFooter, RiskFabricId, StyleSequence, RemarksType, UserId);
                        }
                    }
                }
            }
            if (ReUse == 1)
            {
                int SaveData = obj_ProcessController.ReuseHoppmRemarks(styleid, ReUse, RemarksType, UserId);
            }
            //}
            //else
            //{
            //    ShowAlert("Please Enter Remarks");
            //    return;
            //}
            ViewState["ImbroideryData"] = null;
            //BindImbroideryGrd(CreateNew, NewRefrence, ReUse, ReUseStyleId, ReUseStyleNumber,true);
        }

        //Washing
        protected void BindWashingGrd(int CreateNew, int NewRef, int ReUse, int ReUseStyleId, string ReUseStyleNumber, bool Submited)
        {
            DataSet dsgrd = new DataSet();
            string RemarksType = "Washing";
            if (Submited)
            {
                if (chkMM.Checked)
                {
                    if (bRepeatCheck == true)
                        grdRiskWashing.Enabled = true;
                    else
                        grdRiskWashing.Enabled = false;

                }
                else
                {
                    grdRiskWashing.Enabled = true;
                }
            }
            else
            {
                grdRiskWashing.Enabled = true;
            }
            if (CreateNew == 1)
            {
                dsgrd = obj_ProcessController.GetHOPPMRemarks(stylenumber, styleid, strClientId, DepartmentId, CreateNew, NewRef, ReUse, ReUseStyleId, RemarksType);
                grdRiskWashing.DataSource = dsgrd.Tables[0];
                grdRiskWashing.DataBind();
                ViewState["WashingData"] = dsgrd.Tables[0];
            }

            else if (NewRef == 1)
            {
                dsgrd = obj_ProcessController.GetHOPPMRemarks(stylenumber, styleid, strClientId, DepartmentId, CreateNew, NewRef, ReUse, ReUseStyleId, RemarksType);
                grdRiskWashing.DataSource = dsgrd.Tables[0];
                grdRiskWashing.DataBind();
                ViewState["WashingData"] = dsgrd.Tables[0];

            }
            else if (ReUse == 1)
            {
                dsgrd = obj_ProcessController.GetHOPPMRemarks(stylenumber, styleid, strClientId, DepartmentId, CreateNew, NewRef, ReUse, ReUseStyleId, RemarksType);
                grdRiskWashing.DataSource = dsgrd.Tables[0];
                grdRiskWashing.DataBind();
                ViewState["WashingData"] = dsgrd.Tables[0];

            }
            else
            {
                //if (ViewState["WashingData"] == null)
                //{
                dsgrd = obj_ProcessController.GetHOPPMRemarks(stylenumber, styleid, strClientId, DepartmentId, CreateNew, NewRef, ReUse, ReUseStyleId, RemarksType);
                grdRiskWashing.DataSource = dsgrd.Tables[0];
                grdRiskWashing.DataBind();
                ViewState["WashingData"] = dsgrd.Tables[0];
                //}
                //else
                //{
                //    DataTable dtnew = (DataTable)(ViewState["WashingData"]);
                //    grdRiskWashing.DataSource = dtnew;
                //    grdRiskWashing.DataBind();
                //    ViewState["WashingData"] = dtnew;
                //}
            }

        }
        protected void grdRiskWashing_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string Username = iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.FirstName;
            //string[] name = Username.Split('@');
            string date = DateTime.Now.ToString("dd MMM yyyy");
            if (e.CommandName == "Insert")
            {
                TextBox txtRemarkFooter = grdRiskWashing.FooterRow.FindControl("txtRemarkFooter") as TextBox;
                LinkButton abtnAdd = grdRiskWashing.FooterRow.FindControl("abtnAdd") as LinkButton;

                DataTable dtnew = new DataTable();
                string Remark = txtRemarkFooter.Text.Trim();
                //Remark = Regex.Replace(Remark, @"\s+", "");
                if (Remark == "")
                {
                    ShowAlert("Please Enter Remarks");
                    return;
                }
                else
                {
                    //added by abhishek on 23/11/2015
                    SaveWashingRemark(0, 0, 0, -1);
                    //end by abhishek 23/11/2015

                    if (ViewState["WashingData"] != null)
                    {
                        dtnew = (DataTable)(ViewState["WashingData"]);
                        for (int i = 0; i < grdRiskWashing.Rows.Count; i++)
                        {
                            dtnew.Rows[i]["FabricRemark"] = ((TextBox)grdRiskWashing.Rows[i].FindControl("txtRemarkEdit")).Text;
                        }
                        dtnew.AcceptChanges();
                        sl = dtnew.Rows.Count;
                        dtnew.Rows.Add(0, styleid, Username + "(" + date + "): ", Remark, sl + 1, sl + 1);
                        ViewState["WashingData"] = dtnew;
                    }
                    //if (ViewState["WashingData"] != null)
                    //{
                    //    dtnew = (DataTable)(ViewState["WashingData"]);
                    //    sl = dtnew.Rows.Count;
                    //    dtnew.Rows.Add(sl + 1, styleid, Remark, sl + 1);
                    //    ViewState["WashingData"] = dtnew;
                    //}
                }
                //abtnAdd.CssClass.Replace("FooterShow link", "Footerhide link");
                BindWashingGrd(CreateNew, NewRefrence, ReUse, ReUseStyleId, ReUseStyleNumber, false);
            }
            if (e.CommandName == "addnew")
            {

                Table tblGrdviewApplet = (Table)grdRiskWashing.Controls[0];
                GridViewRow rows = (GridViewRow)tblGrdviewApplet.Controls[0];
                TextBox txtRemarksEmpty = (TextBox)rows.FindControl("txtRemarksEmpty");

                DataTable dtnew = new DataTable();
                string Remark = txtRemarksEmpty.Text.Trim();
                //Remark = Regex.Replace(Remark, @"\s+", "");
                if (Remark == "")
                {
                    ShowAlert("Please Enter Remarks");
                    return;
                }
                else
                {
                    //added by abhishek on 23/11/2015
                    SaveWashingRemark(0, 0, 0, -1);
                    //end by abhishek 23/11/2015
                    if (ViewState["WashingData"] != null)
                    {
                        dtnew = (DataTable)(ViewState["WashingData"]);
                        for (int i = 0; i < grdRiskWashing.Rows.Count; i++)
                        {
                            dtnew.Rows[i]["FabricRemark"] = ((TextBox)grdRiskWashing.Rows[i].FindControl("txtRemarkEdit")).Text;
                        }
                        dtnew.AcceptChanges();
                        sl = dtnew.Rows.Count;
                        dtnew.Rows.Add(0, styleid, Username + "(" + date + "): ", Remark, sl + 1, sl + 1);
                        ViewState["WashingData"] = dtnew;
                    }
                }
                BindWashingGrd(CreateNew, NewRefrence, ReUse, ReUseStyleId, ReUseStyleNumber, false);
            }
        }
        protected void grdRiskWashing_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            bool EnableHOPPM = grdRiskWashing.Enabled;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Literal ltIndex = (Literal)e.Row.FindControl("ltIndex");
                //ltIndex.Text = ((grdRiskWashing.PageIndex * grdRiskWashing.PageSize) + e.Row.RowIndex + 1).ToString();
                LinkButton lnkDelete = (LinkButton)e.Row.FindControl("lnkDelete");
                if (!EnableHOPPM)
                {
                    lnkDelete.Visible = false;
                }
                TextBox txtRemarkEdit = (TextBox)e.Row.FindControl("txtRemarkEdit");
                NewRefrence = Convert.ToInt32(hdnHoppmNewRef.Value);
                if (chkProdQAMgr.Checked == true && chkMM.Checked == true && chkFactoryPPMComplete.Checked == true && chkHOPPMComplete.Checked == true)
                {
                    if (NewRefrence == 1)
                    {
                        txtRemarkEdit.Enabled = true;
                        lnkDelete.Visible = true;
                        lnkDelete.Attributes.Add("style", "display:block;");
                    }
                    else
                    {
                        if (bRepeatCheck == true)
                        {
                            lnkDelete.Visible = true;
                            txtRemarkEdit.Enabled = true;
                            //lnkDelete.Attributes.Add("style", "display:none;");
                        }
                        else
                        {
                            lnkDelete.Visible = false;
                            txtRemarkEdit.Enabled = false;
                            lnkDelete.Attributes.Add("style", "display:none;");
                        }

                    }
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                LinkButton abtnAdd = (LinkButton)e.Row.FindControl("abtnAdd");
                if (!EnableHOPPM)
                {
                    abtnAdd.Visible = false;
                }

                NewRefrence = Convert.ToInt32(hdnHoppmNewRef.Value);
                TextBox txtRemarkFooter = (TextBox)e.Row.FindControl("txtRemarkFooter");
                if (chkProdQAMgr.Checked == true && chkMM.Checked == true && chkFactoryPPMComplete.Checked == true && chkHOPPMComplete.Checked == true)
                {
                    if (NewRefrence == 1)
                    {
                        abtnAdd.Visible = true;
                        txtRemarkFooter.Enabled = true;
                    }
                    else
                    {
                        if (bRepeatCheck == true)
                        {
                            txtRemarkFooter.Enabled = true;
                            abtnAdd.Visible = true;
                        }
                        else
                        {
                            txtRemarkFooter.Enabled = false;
                            abtnAdd.Visible = false;
                        }

                    }

                }
            }
            if (e.Row.RowType == DataControlRowType.EmptyDataRow)
            {
                LinkButton addbutton = (LinkButton)e.Row.FindControl("addbutton");
                if (!EnableHOPPM)
                {
                    addbutton.Visible = false;
                }
            }
        }
        protected void grdRiskWashing_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = grdRiskWashing.Rows[e.RowIndex];
            HiddenField hdndataTableId = (HiddenField)row.FindControl("hdndataTableId");
            HiddenField hdnRiskFabricId = (HiddenField)row.FindControl("hdnRiskId");
            DataTable dtnew = new DataTable();
            string RemarksType = "Washing";
            if (ViewState["WashingData"] != null)
            {
                dtnew = (DataTable)(ViewState["WashingData"]);
                if (hdnRiskFabricId.Value != "0")
                {
                    dtnew.Rows.Remove(dtnew.Select("RiskFabricId=" + hdnRiskFabricId.Value)[0]);
                    int IsDelete = obj_ProcessController.DeleteHoppmRemarkById(Convert.ToInt32(hdnRiskFabricId.Value), RemarksType);
                }
                else
                {
                    dtnew.Rows.Remove(dtnew.Select("dataTableId=" + hdndataTableId.Value)[0]);
                }
                ViewState["WashingData"] = dtnew;
            }


            grdRiskWashing.EditIndex = -1;
            BindWashingGrd(CreateNew, NewRefrence, ReUse, ReUseStyleId, ReUseStyleNumber, false);
        }
        protected void SaveWashingRemark(int CreateNew, int NewRefrence, int ReUse, int ReUseStyleId)
        {
            RiskAnalysisOB objRisk = new RiskAnalysisOB();

            int UserId = iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.UserID;
            int RiskFabricId = 0;
            int StyleSequence = 0;
            string RemarksType = "Washing";

            Control control = null;
            control = grdRiskWashing.Controls[0].Controls[0];
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
                        int isave = obj_ProcessController.InsertUpdateHOPPMRemarks(stylenumber, styleid, strClientId, DepartmentId, CreateNew, NewRefrence, ReUse, ReUseStyleId, RemarksEmpty, RiskFabricId, StyleSequence, RemarksType, UserId);
                    }
                }
            }
            else
            {
                for (int i = 0; i < grdRiskWashing.Rows.Count; i++)
                {
                    TextBox RemarkEdit = (TextBox)grdRiskWashing.Rows[i].FindControl("txtRemarkEdit");
                    HiddenField hdnRiskId = (HiddenField)grdRiskWashing.Rows[i].FindControl("hdnRiskId");
                    HiddenField hdnStyleSequence = (HiddenField)grdRiskWashing.Rows[i].FindControl("hdnStyleSequence");
                    string Remark = RemarkEdit.Text.Trim();
                    //Remark = Regex.Replace(Remark, @"\s+", "");
                    if (hdnRiskId != null)
                    {
                        if (hdnRiskId.Value == "")
                        {
                            RiskFabricId = 0;
                        }
                        else
                        {
                            RiskFabricId = Convert.ToInt32(hdnRiskId.Value);
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
                            int isave = obj_ProcessController.InsertUpdateHOPPMRemarks(stylenumber, styleid, strClientId, DepartmentId, CreateNew, NewRefrence, ReUse, ReUseStyleId, Remark, RiskFabricId, StyleSequence, RemarksType, UserId);
                        }
                    }

                }
                var footerRow = grdRiskWashing.FooterRow;
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
                            int isave = obj_ProcessController.InsertUpdateHOPPMRemarks(stylenumber, styleid, strClientId, DepartmentId, CreateNew, NewRefrence, ReUse, ReUseStyleId, RemarkFooter, RiskFabricId, StyleSequence, RemarksType, UserId);
                        }
                    }
                }
            }
            if (ReUse == 1)
            {
                int SaveData = obj_ProcessController.ReuseHoppmRemarks(styleid, ReUse, RemarksType, UserId);
            }

            ViewState["WashingData"] = null;

        }

        //Finishing
        protected void BindFinishingGrd(int CreateNew, int NewRef, int ReUse, int ReUseStyleId, string ReUseStyleNumber, bool Submited)
        {
            DataSet dsgrd = new DataSet();
            string RemarksType = "Finishing";
            if (Submited)
            {
                if (chkMM.Checked)
                {
                    if (bRepeatCheck == true)
                        grdRiskFinishing.Enabled = true;
                    else
                        grdRiskFinishing.Enabled = false;
                }
                else
                {
                    grdRiskFinishing.Enabled = true;
                }
            }
            else
            {
                grdRiskFinishing.Enabled = true;
            }
            if (CreateNew == 1)
            {
                dsgrd = obj_ProcessController.GetHOPPMRemarks(stylenumber, styleid, strClientId, DepartmentId, CreateNew, NewRef, ReUse, ReUseStyleId, RemarksType);
                grdRiskFinishing.DataSource = dsgrd.Tables[0];
                grdRiskFinishing.DataBind();
                ViewState["FinishingData"] = dsgrd.Tables[0];

            }
            else if (NewRef == 1)
            {
                dsgrd = obj_ProcessController.GetHOPPMRemarks(stylenumber, styleid, strClientId, DepartmentId, CreateNew, NewRef, ReUse, ReUseStyleId, RemarksType);
                grdRiskFinishing.DataSource = dsgrd.Tables[0];
                grdRiskFinishing.DataBind();
                ViewState["FinishingData"] = dsgrd.Tables[0];
            }
            else if (ReUse == 1)
            {
                dsgrd = obj_ProcessController.GetHOPPMRemarks(stylenumber, styleid, strClientId, DepartmentId, CreateNew, NewRef, ReUse, ReUseStyleId, RemarksType);
                grdRiskFinishing.DataSource = dsgrd.Tables[0];
                grdRiskFinishing.DataBind();
                ViewState["FinishingData"] = dsgrd.Tables[0];
            }
            else
            {
                //if (ViewState["FinishingData"] == null)
                //{
                dsgrd = obj_ProcessController.GetHOPPMRemarks(stylenumber, styleid, strClientId, DepartmentId, CreateNew, NewRef, ReUse, ReUseStyleId, RemarksType);
                grdRiskFinishing.DataSource = dsgrd.Tables[0];
                grdRiskFinishing.DataBind();
                ViewState["FinishingData"] = dsgrd.Tables[0];
                //}
                //else
                //{
                //    DataTable dtnew = (DataTable)(ViewState["FinishingData"]);
                //    grdRiskFinishing.DataSource = dtnew;
                //    grdRiskFinishing.DataBind();
                //    ViewState["FinishingData"] = dtnew;
                //}
            }

        }
        protected void grdRiskFinishing_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string Username = iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.FirstName;
            //string[] name = Username.Split('@');
            string date = DateTime.Now.ToString("dd MMM yyyy");
            if (e.CommandName == "Insert")
            {
                TextBox txtRemarkFooter = grdRiskFinishing.FooterRow.FindControl("txtRemarkFooter") as TextBox;
                LinkButton abtnAdd = grdRiskFinishing.FooterRow.FindControl("abtnAdd") as LinkButton;

                DataTable dtnew = new DataTable();
                string Remark = txtRemarkFooter.Text.Trim();
                //Remark = Regex.Replace(Remark, @"\s+", "");
                if (Remark == "")
                {
                    ShowAlert("Please Enter Remarks");
                    return;
                }
                else
                {
                    //added by abhishek on 23/11/2015
                    SaveFinishingRemark(0, 0, 0, -1);
                    //end by abhishek 23/11/2015

                    if (ViewState["FinishingData"] != null)
                    {
                        dtnew = (DataTable)(ViewState["FinishingData"]);
                        for (int i = 0; i < grdRiskFinishing.Rows.Count; i++)
                        {
                            dtnew.Rows[i]["FabricRemark"] = ((TextBox)grdRiskFinishing.Rows[i].FindControl("txtRemarkEdit")).Text;
                        }
                        dtnew.AcceptChanges();
                        sl = dtnew.Rows.Count;
                        dtnew.Rows.Add(0, styleid, Username + "(" + date + "): ", Remark, sl + 1, sl + 1);
                        ViewState["FinishingData"] = dtnew;
                    }
                    //if (ViewState["FinishingData"] != null)
                    //{
                    //    dtnew = (DataTable)(ViewState["FinishingData"]);
                    //    sl = dtnew.Rows.Count;
                    //    dtnew.Rows.Add(sl + 1, styleid, Remark, sl + 1);
                    //    ViewState["FinishingData"] = dtnew;
                    //}
                }
                //abtnAdd.CssClass.Replace("FooterShow link", "Footerhide link");
                BindFinishingGrd(CreateNew, NewRefrence, ReUse, ReUseStyleId, ReUseStyleNumber, false);
            }
            if (e.CommandName == "addnew")
            {

                Table tblGrdviewApplet = (Table)grdRiskFinishing.Controls[0];
                GridViewRow rows = (GridViewRow)tblGrdviewApplet.Controls[0];
                TextBox txtRemarksEmpty = (TextBox)rows.FindControl("txtRemarksEmpty");

                DataTable dtnew = new DataTable();
                string Remark = txtRemarksEmpty.Text.Trim();
                //Remark = Regex.Replace(Remark, @"\s+", "");
                if (Remark == "")
                {
                    ShowAlert("Please Enter Remarks");
                    return;
                }
                else
                {
                    //added by abhishek on 23/11/2015
                    SaveFinishingRemark(0, 0, 0, -1);
                    //end by abhishek 23/11/2015

                    if (ViewState["FinishingData"] != null)
                    {
                        dtnew = (DataTable)(ViewState["FinishingData"]);
                        for (int i = 0; i < grdRiskFinishing.Rows.Count; i++)
                        {
                            dtnew.Rows[i]["FabricRemark"] = ((TextBox)grdRiskFinishing.Rows[i].FindControl("txtRemarkEdit")).Text;
                        }
                        dtnew.AcceptChanges();
                        sl = dtnew.Rows.Count;
                        dtnew.Rows.Add(0, styleid, Username + "(" + date + "): ", Remark, sl + 1, sl + 1);
                        ViewState["FinishingData"] = dtnew;
                    }
                }
                BindFinishingGrd(CreateNew, NewRefrence, ReUse, ReUseStyleId, ReUseStyleNumber, false);
            }
        }
        protected void grdRiskFinishing_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            bool EnableHOPPM = grdRiskFinishing.Enabled;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Literal ltIndex = (Literal)e.Row.FindControl("ltIndex");
                //ltIndex.Text = ((grdRiskFinishing.PageIndex * grdRiskFinishing.PageSize) + e.Row.RowIndex + 1).ToString();
                LinkButton lnkDelete = (LinkButton)e.Row.FindControl("lnkDelete");
                if (!EnableHOPPM)
                {
                    lnkDelete.Visible = false;
                }
                TextBox txtRemarkEdit = (TextBox)e.Row.FindControl("txtRemarkEdit");
                NewRefrence = Convert.ToInt32(hdnHoppmNewRef.Value);
                if (chkProdQAMgr.Checked == true && chkMM.Checked == true && chkFactoryPPMComplete.Checked == true && chkHOPPMComplete.Checked == true)
                {
                    if (NewRefrence == 1)
                    {
                        txtRemarkEdit.Enabled = true;
                        lnkDelete.Visible = true;
                        lnkDelete.Attributes.Add("style", "display:block;");
                    }
                    else
                    {
                        txtRemarkEdit.Enabled = false;
                        lnkDelete.Visible = false;
                        lnkDelete.Attributes.Add("style", "display:none;");
                    }
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                LinkButton abtnAdd = (LinkButton)e.Row.FindControl("abtnAdd");
                if (!EnableHOPPM)
                {
                    abtnAdd.Visible = false;
                }
                NewRefrence = Convert.ToInt32(hdnHoppmNewRef.Value);
                TextBox txtRemarkFooter = (TextBox)e.Row.FindControl("txtRemarkFooter");
                if (chkProdQAMgr.Checked == true && chkMM.Checked == true && chkFactoryPPMComplete.Checked == true && chkHOPPMComplete.Checked == true)
                {
                    if (NewRefrence == 1)
                    {
                        txtRemarkFooter.Enabled = true;
                        abtnAdd.Visible = true;
                    }
                    else
                    {
                        txtRemarkFooter.Enabled = false;
                        abtnAdd.Visible = false;
                    }

                }
            }
            if (e.Row.RowType == DataControlRowType.EmptyDataRow)
            {
                LinkButton addbutton = (LinkButton)e.Row.FindControl("addbutton");
                if (!EnableHOPPM)
                {
                    addbutton.Visible = false;
                }
            }
        }
        protected void grdRiskFinishing_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = grdRiskFinishing.Rows[e.RowIndex];
            HiddenField hdndataTableId = (HiddenField)row.FindControl("hdndataTableId");
            HiddenField hdnRiskFabricId = (HiddenField)row.FindControl("hdnRiskId");
            DataTable dtnew = new DataTable();
            string RemarksType = "Finishing";
            if (ViewState["FinishingData"] != null)
            {
                dtnew = (DataTable)(ViewState["FinishingData"]);
                if (hdnRiskFabricId.Value != "0")
                {
                    dtnew.Rows.Remove(dtnew.Select("RiskFabricId=" + hdnRiskFabricId.Value)[0]);
                    int IsDelete = obj_ProcessController.DeleteHoppmRemarkById(Convert.ToInt32(hdnRiskFabricId.Value), RemarksType);
                }
                else
                {
                    dtnew.Rows.Remove(dtnew.Select("dataTableId=" + hdndataTableId.Value)[0]);
                }
                ViewState["FinishingData"] = dtnew;
            }


            grdRiskFinishing.EditIndex = -1;
            BindFinishingGrd(CreateNew, NewRefrence, ReUse, ReUseStyleId, ReUseStyleNumber, false);
        }
        protected void SaveFinishingRemark(int CreateNew, int NewRefrence, int ReUse, int ReUseStyleId)
        {
            RiskAnalysisOB objRisk = new RiskAnalysisOB();

            int UserId = iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.UserID;
            int RiskFabricId = 0;
            int StyleSequence = 0;
            string RemarksType = "Finishing";

            Control control = null;
            control = grdRiskFinishing.Controls[0].Controls[0];
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
                        int isave = obj_ProcessController.InsertUpdateHOPPMRemarks(stylenumber, styleid, strClientId, DepartmentId, CreateNew, NewRefrence, ReUse, ReUseStyleId, RemarksEmpty, RiskFabricId, StyleSequence, RemarksType, UserId);
                    }
                }
            }
            else
            {

                for (int i = 0; i < grdRiskFinishing.Rows.Count; i++)
                {
                    TextBox RemarkEdit = (TextBox)grdRiskFinishing.Rows[i].FindControl("txtRemarkEdit");
                    HiddenField hdnRiskId = (HiddenField)grdRiskFinishing.Rows[i].FindControl("hdnRiskId");
                    HiddenField hdnStyleSequence = (HiddenField)grdRiskFinishing.Rows[i].FindControl("hdnStyleSequence");
                    string Remark = RemarkEdit.Text.Trim();
                    if (hdnRiskId != null)
                    {
                        if (hdnRiskId.Value == "")
                        {
                            RiskFabricId = 0;
                        }
                        else
                        {
                            RiskFabricId = Convert.ToInt32(hdnRiskId.Value);
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
                            int isave = obj_ProcessController.InsertUpdateHOPPMRemarks(stylenumber, styleid, strClientId, DepartmentId, CreateNew, NewRefrence, ReUse, ReUseStyleId, Remark, RiskFabricId, StyleSequence, RemarksType, UserId);
                        }
                    }
                }
                var footerRow = grdRiskFinishing.FooterRow;
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
                            int isave = obj_ProcessController.InsertUpdateHOPPMRemarks(stylenumber, styleid, strClientId, DepartmentId, CreateNew, NewRefrence, ReUse, ReUseStyleId, RemarkFooter, RiskFabricId, StyleSequence, RemarksType, UserId);
                        }
                    }
                }
            }
            if (ReUse == 1)
            {
                int SaveData = obj_ProcessController.ReuseHoppmRemarks(styleid, ReUse, RemarksType, UserId);
            }

            ViewState["FinishingData"] = null;

            //BindFinishingGrd(CreateNew, NewRefrence, ReUse, ReUseStyleId, ReUseStyleNumber, true);
        }


        protected void imgPlus_Click(object sender, EventArgs e)
        {
            DataSet dsNewStyle = new DataSet();
            DataTable dt0 = new DataTable();
            DataTable dt1 = new DataTable();
            DataTable dt2 = new DataTable();
            DataTable dt3 = new DataTable();
            DataTable dt4 = new DataTable();
            DataTable dt5 = new DataTable();
            DataTable dt6 = new DataTable();
            DataTable dt7 = new DataTable();
            dt0 = null;
            dt1 = null;
            dt2 = null;
            dt3 = null;
            dt4 = null;
            dt5 = null;
            dt6 = null;
            dt7 = null;
            ShowGridPopup.Visible = false;
            foreach (RepeaterItem item in repStyleCodeVirsion.Items)
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
            string StyleCodeNew = ((HiddenField)ritem.FindControl("rephdnStylCode")).Value;

            ShowGridPopup.Visible = true;

            if (StyleidNew != null)
            {

                dsNewStyle = obj_ProcessController.GetHoppm_AllRemark(StyleCodeNew, Convert.ToInt32(StyleidNew));

                dt0 = dsNewStyle.Tables[0];
                dt1 = dsNewStyle.Tables[1];
                dt2 = dsNewStyle.Tables[2];
                dt3 = dsNewStyle.Tables[3];
                dt4 = dsNewStyle.Tables[4];
                dt5 = dsNewStyle.Tables[5];
                dt6 = dsNewStyle.Tables[6];
                dt7 = dsNewStyle.Tables[7];
                if (dt0 != null)
                {
                    GridHOPPMFabeic.DataSource = dt0;
                    GridHOPPMFabeic.DataBind();
                    lblFabric.Text = "Fabric";

                }
                if (dt1 != null)
                {
                    GridHOPPMAccessories.DataSource = dt1;
                    GridHOPPMAccessories.DataBind();
                    lblHOPPMAccessories.Text = "Accessories";

                }
                if (dt2 != null)
                {
                    GridHOPPMFittingRemark.DataSource = dt2;
                    GridHOPPMFittingRemark.DataBind();
                    lblHOPPMFittingRemark.Text = "Fitting";

                }
                if (dt3 != null)
                {
                    GridHOPPMMaking.DataSource = dt3;
                    GridHOPPMMaking.DataBind();
                    lblMaking.Text = "Making";

                }
                if (dt4 != null)
                {
                    GridHOPPMImbroideryRemark.DataSource = dt4;
                    GridHOPPMImbroideryRemark.DataBind();

                    //lblHOPPMImbroideryRemark.Text = "Embroidery";
                    //abhishek
                    lblHOPPMImbroideryRemark.Text = "Value addition";
                    //Ende

                }

                if (dt5 != null)
                {
                    GridRiskWashing.DataSource = dt5;
                    GridRiskWashing.DataBind();
                    lblRiskWashing.Text = "Washing";

                }

                if (dt6 != null)
                {
                    GridRiskFinishing.DataSource = dt6;
                    GridRiskFinishing.DataBind();
                    //updated by abhishek on 17/8/2015
                    lblRiskFinishing.Text = "Finishing/Packing";
                    //end by abhishek on 17/8/2015-
                }
                if (dt7 != null)
                {
                    hlkRefViewSnap1.Visible = true;
                    hlkRefViewSnap2.Visible = true;

                    string File1 = dsNewStyle.Tables[7].Rows[0]["UploadSnap1"].ToString();
                    hlkRefViewSnap1.NavigateUrl = (string.IsNullOrEmpty(File1)) ? "" : FitsFolderPath + File1;

                    string File2 = dsNewStyle.Tables[7].Rows[0]["UploadSnap2"].ToString();
                    hlkRefViewSnap2.NavigateUrl = (string.IsNullOrEmpty(File1)) ? "" : FitsFolderPath + File2;
                }
            }
        }

        protected void imgMinus_Click(object sender, EventArgs e)
        {
            ShowGridPopup.Visible = false;
            foreach (RepeaterItem item in repStyleCodeVirsion.Items)
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


        protected void GridHOPPMFabeic_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Literal ltIndex = (Literal)e.Row.FindControl("ltIndex");
                ltIndex.Text = ((grdHoppmFabricRemark.PageIndex * grdHoppmFabricRemark.PageSize) + e.Row.RowIndex + 1).ToString();
            }

        }

        protected void GridHOPPMAccessories_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Literal ltIndex = (Literal)e.Row.FindControl("ltIndex");
                ltIndex.Text = ((grdHoppmFabricRemark.PageIndex * grdHoppmFabricRemark.PageSize) + e.Row.RowIndex + 1).ToString();
            }
        }

        // Write the Rowdatabound for RnD Grid
        protected void GridHOPPMRnD_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Literal ltIndex = (Literal)e.Row.FindControl("ltIndex");
                ltIndex.Text = ((grdHoppmFabricRemark.PageIndex * grdHoppmFabricRemark.PageSize) + e.Row.RowIndex + 1).ToString();
            }
        }

        protected void GridHOPPMFittingRemark_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Literal ltIndex = (Literal)e.Row.FindControl("ltIndex");
                ltIndex.Text = ((grdHoppmFabricRemark.PageIndex * grdHoppmFabricRemark.PageSize) + e.Row.RowIndex + 1).ToString();
            }

        }

        protected void GridHOPPMMaking_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Literal ltIndex = (Literal)e.Row.FindControl("ltIndex");
                ltIndex.Text = ((grdHoppmFabricRemark.PageIndex * grdHoppmFabricRemark.PageSize) + e.Row.RowIndex + 1).ToString();
            }
        }

        protected void GridHOPPMImbroideryRemark_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Literal ltIndex = (Literal)e.Row.FindControl("ltIndex");
                ltIndex.Text = ((grdHoppmFabricRemark.

                    PageIndex * grdHoppmFabricRemark.PageSize) + e.Row.RowIndex + 1).ToString();
            }

        }

        protected void GridRiskWashing_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Literal ltIndex = (Literal)e.Row.FindControl("ltIndex");
                ltIndex.Text = ((grdHoppmFabricRemark.PageIndex * grdHoppmFabricRemark.PageSize) + e.Row.RowIndex + 1).ToString();
            }
        }

        protected void GridRiskFinishing_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Literal ltIndex = (Literal)e.Row.FindControl("ltIndex");
                ltIndex.Text = ((grdHoppmFabricRemark.PageIndex * grdHoppmFabricRemark.PageSize) + e.Row.RowIndex + 1).ToString();
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
        //END

        //protected void BtnPrint_Click(object sender, EventArgs e)
        //{
        //   // GetPrint(CreateNew, NewRefrence, ReUse, ReUseStyleId, ReUseStyleNumber);
        //    iKandi.BLL.PDFController pdfControl = new BLL.PDFController();
        //    int desigId = Convert.ToInt32(iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.Designation);
        //    int DeptId = Convert.ToInt32(iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.PrimaryGroupID);

        //    //pdfControl.GetPrint(styleid, ReUseStyleId, strClientId, DepartmentId, CreateNew, NewRefrence, ReUse);  
        //   string strN= pdfControl.GenerateManageOrderReport(100000, 0, "", -1, "2015,2016", -1, 1, 0, 18, 4, 1, 2, 3, -1, "", "", 0, 13, 5, 15, 0, "bh523zivkbekrmeija4pnb45", "ALL", "ALL", "APPROVED TO EX", "ALL", -1, "ALL");



        //}

        protected void btnCheckbox_Click(object sender, EventArgs e)
        {
            chkHOPPMComplete.Enabled = true;
        }

        protected void chkPreProdQAMgr_CheckedChanged(object sender, EventArgs e)
        {
            if ((chkProdQAMgr.Checked) && (chkMM.Checked) && (chkFactoryPPMComplete.Checked))
            {
                chkHOPPMComplete.Enabled = true;
            }
            else
            {
                chkHOPPMComplete.Enabled = false;
            }
        }

        protected void chkProdQAMgr_CheckedChanged(object sender, EventArgs e)
        {
            if ((chkProdQAMgr.Checked) && (chkMM.Checked) && (chkFactoryPPMComplete.Checked))
            {
                chkHOPPMComplete.Enabled = true;
            }
            else
            {
                chkHOPPMComplete.Enabled = false;
            }
        }

        protected void chkMM_CheckedChanged(object sender, EventArgs e)
        {
            if ((chkProdQAMgr.Checked) && (chkMM.Checked) && (chkFactoryPPMComplete.Checked))
            {
                chkHOPPMComplete.Enabled = true;
            }
            else
            {
                chkHOPPMComplete.Enabled = false;
            }
        }

        protected void chkFactoryPPMComplete_CheckedChanged(object sender, EventArgs e)
        {
            if ((chkProdQAMgr.Checked) && (chkMM.Checked) && (chkFactoryPPMComplete.Checked))
            {
                chkHOPPMComplete.Enabled = true;
            }
            else
            {
                chkHOPPMComplete.Enabled = false;
            }
        }

        protected void btnFile1Upload_Click(object sender, EventArgs e)
        {
            HOPPMOB objHOPPM = new HOPPMOB();
            string FileName1 = FileSnap1.FileName;
            string fileNameStyle1;
            string FileName2 = FileSnap2.FileName;
            string fileNameStyle2;

            if (FileName1 != "")
            {
                int FileName1LastIndx = 0;
                int FileName1Len = 0;
                FileName1Len = FileName1.Length;
                FileName1LastIndx = FileName1.LastIndexOf(".");
                string Extension1;
                Extension1 = FileName1.Substring(FileName1LastIndx, (FileName1Len - FileName1LastIndx));

                if (FileSnap1.HasFile)
                {

                    //fileNameStyle1 = stylenumber.ToString() + "-" + DepartmentId + "_" + FileName1;
                    //FileSnap1.SaveAs(Server.MapPath(FitsFolderPath) + fileNameStyle1);
                    //objHOPPM.FileUploadUrl1 = fileNameStyle1 == "" ? "" : fileNameStyle1;
                    //hlkViewSnap1.Visible = true;
                    //hlkViewSnap1.NavigateUrl = (string.IsNullOrEmpty(objHOPPM.FileUploadUrl1)) ? "" : FitsFolderPath + objHOPPM.FileUploadUrl1;

                    fileNameStyle1 = ((stylenumber.ToString() + "-" + DepartmentId + "_" + "FileNameAvail_" + Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd")) + Extension1).Replace(" ", "")).Replace(":", "");//FileName1;
                    //objHOPPM.FileUploadUrl1 = SaveUploadedFile(FileSnap1, fileNameStyle);
                    FileSnap1.SaveAs(Server.MapPath(FitsFolderPath) + fileNameStyle1);
                    objHOPPM.FileUploadUrl1 = fileNameStyle1 == "" ? "" : fileNameStyle1;
                    hlkViewSnap1.Visible = true;
                    hlkViewSnap1.NavigateUrl = (string.IsNullOrEmpty(objHOPPM.FileUploadUrl1)) ? "" : FitsFolderPath + objHOPPM.FileUploadUrl1;
                }
            }
            else
            {
                //fileNameStyle1 = hdnSnap1.Value + "-" + DepartmentId;
                //FileSnap1.SaveAs(Server.MapPath(FitsFolderPath) + fileNameStyle1);
                //objHOPPM.FileUploadUrl1 = fileNameStyle1 == "" ? "" : fileNameStyle1;
                //hlkViewSnap1.Visible = true;
                //hlkViewSnap1.NavigateUrl = (string.IsNullOrEmpty(objHOPPM.FileUploadUrl1)) ? "" : FitsFolderPath + objHOPPM.FileUploadUrl1;
            }

            if (FileName2 != "")
            {
                int FileName2LastIndx = 0;
                int FileName2Len = 0;
                FileName2Len = FileName2.Length;
                FileName2LastIndx = FileName2.LastIndexOf(".");
                string Extension2;
                Extension2 = FileName2.Substring(FileName2LastIndx, (FileName2Len - FileName2LastIndx));

                if (FileSnap2.HasFile)
                {

                    //fileNameStyle2 = stylenumber.ToString() + "-" + DepartmentId + "_" + FileName2; ;
                    //FileSnap2.SaveAs(Server.MapPath(FitsFolderPath) + fileNameStyle2);
                    //objHOPPM.FileUploadUrl2 = fileNameStyle2 == "" ? "" : fileNameStyle2;
                    //hlkViewSnap2.Visible = true;
                    //hlkViewSnap2.NavigateUrl = (string.IsNullOrEmpty(objHOPPM.FileUploadUrl2)) ? "" : FitsFolderPath + objHOPPM.FileUploadUrl2;

                    fileNameStyle2 = ((stylenumber.ToString() + "-" + DepartmentId + "_" + "FileNameAvai2_" + Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd")) + Extension2).Replace(" ", "")).Replace(":", ""); //+ FileName2; ;
                    FileSnap2.SaveAs(Server.MapPath(FitsFolderPath) + fileNameStyle2);
                    objHOPPM.FileUploadUrl2 = fileNameStyle2 == "" ? "" : fileNameStyle2;
                    hlkViewSnap2.Visible = true;
                    hlkViewSnap2.NavigateUrl = (string.IsNullOrEmpty(objHOPPM.FileUploadUrl2)) ? "" : FitsFolderPath + objHOPPM.FileUploadUrl2;

                }
            }
            else
            {
                //fileNameStyle2 = hdnSnap2.Value + "-" + DepartmentId;
                //FileSnap2.SaveAs(Server.MapPath(FitsFolderPath) + fileNameStyle2);
                //objHOPPM.FileUploadUrl2 = fileNameStyle2 == "" ? "" : fileNameStyle2;
                //hlkViewSnap2.Visible = true;
                //hlkViewSnap2.NavigateUrl = (string.IsNullOrEmpty(objHOPPM.FileUploadUrl2)) ? "" : FitsFolderPath + objHOPPM.FileUploadUrl2;
            }


            int isave = obj_ProcessController.UpdateHoppmFile(styleid, objHOPPM.FileUploadUrl1, objHOPPM.FileUploadUrl2);
        }





        //protected void Button3_Click(object sender, EventArgs e)
        //{


        //}







    }
}