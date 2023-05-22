using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace iKandi.Web.Internal.OrderProcessing
{
    public partial class ShowOBGrd : System.Web.UI.Page
    {
        iKandi.BLL.OrderController obj_OrderController = new BLL.OrderController();

        public string GarmentId
        {
            get;
            set;
        }
        public string StyleCode
        {
            get;
            set;
        }
        public int StyleId
        {
            get;
            set;
        }
        public int ClientIDs
        {
            get;
            set;
        }
        public int DeptId
        {
            get;
            set;
        }
        public string Flag
        {
            get;
            set;
        }
        public int FinalOBID
        {
            get;
            set;
        }
        public int OperationId
        {
            get;
            set;
        }
        public int WorkerTypeID
        {
            get;
            set;
        }
        public int AttachmentID
        {
            get;
            set;
        }
        public int ReUseStyleId
        {
            get;
            set;
        }
        public string ReuseStyleCode
        {
            get;
            set; 
        }

        public string ReUseStyleNumber
        {
            get;
            set;
        }

        public int IsReUse
        {
            get;
            set;
        }
        public int NewRef
        {
            get;
            set;
        }
        public string UpdateFlag
        {
            get;
            set;
        }
        public int StyleSequence
        {
            get;
            set;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (null != Request.QueryString["GarmentId"])
            {
                GarmentId = Request.QueryString["GarmentId"].ToString();
            }

            if (null != Request.QueryString["StyleSequence"])
            {
                StyleSequence = Convert.ToInt32(Request.QueryString["StyleSequence"]);
            }
            if (null != Request.QueryString["StyleCode"])
            {
                StyleCode = Request.QueryString["StyleCode"].ToString();
            }
            if (null != Request.QueryString["StyleId"])
            {
                StyleId = Convert.ToInt32(Request.QueryString["StyleId"]);
            }
            if (null != Request.QueryString["ClientID"])
            {
                ClientIDs = Convert.ToInt32(Request.QueryString["ClientID"].ToString());
            }
            if (null != Request.QueryString["DeptId"])
            {
                DeptId = Convert.ToInt32(Request.QueryString["DeptId"].ToString());
            }
            if (null != Request.QueryString["Flag"])
            {
                Flag = Request.QueryString["Flag"].ToString();
            }

            if (null != Request.QueryString["FinalCuttingOBID"])
            {
                FinalOBID = Convert.ToInt32(Request.QueryString["FinalCuttingOBID"].ToString());
            }
            if (null != Request.QueryString["OperationId"])
            {
                OperationId = Convert.ToInt32(Request.QueryString["OperationId"].ToString());
            }
            if (null != Request.QueryString["WorkerTypeID"])
            {
                WorkerTypeID = Convert.ToInt32(Request.QueryString["WorkerTypeID"].ToString());
            }
            if (null != Request.QueryString["AttachmentID"])
            {
                AttachmentID = Convert.ToInt32(Request.QueryString["AttachmentID"].ToString());
            }
            if (null != Request.QueryString["ReUseStyleId"])
            {
                ReUseStyleId = Convert.ToInt32(Request.QueryString["ReUseStyleId"].ToString());
            }
            if (null != Request.QueryString["ReUseStyleNumber"])
            {
                ReUseStyleNumber = Request.QueryString["ReUseStyleNumber"].ToString();
            }
            if (null != Request.QueryString["IsReUse"])
            {
                IsReUse = Convert.ToInt32(Request.QueryString["IsReUse"].ToString());
            }
            if (null != Request.QueryString["StyleCode"])
            {
                ReuseStyleCode = Request.QueryString["StyleCode"].ToString();
            }
            if (null != Request.QueryString["StyleCode"])
            {
                ReuseStyleCode = Request.QueryString["StyleCode"].ToString();
            }

            if (null != Request.QueryString["UpdateFlag"])//abhishek 11/1/2017
            {
                UpdateFlag = Request.QueryString["UpdateFlag"].ToString();
            }

            if (!IsPostBack)
            {
                BindOperation();
            }
        }

        protected void BindOperation()
        {
            DataTable dtOperation = new DataTable();
            if (Flag == "Cutting")
            {
                dtOperation = obj_OrderController.GetOperationById("tblOperationcutting", "tblCuttingOB", "Operationcutting", "FactoryWorkSpace", "GarmentTypeID",GarmentId);
                ddlOperation.DataSource = dtOperation;
                //ddlOperation.Items.Add(new ListItem("Select Operation", "-1", true));
                ddlOperation.DataValueField = "Operationcutting";
                ddlOperation.DataTextField = "FactoryWorkSpace";
                ddlOperation.DataBind();
            }
            if (Flag == "Stiching Front")
            {
                dtOperation = obj_OrderController.GetOperationById("tblOperationstitching_Front", "tblStitchingFrontOB", "Operationstitching_Front", "FactoryWorkSpace", "GarmentTypeID", GarmentId);
                ddlOperation.DataSource = dtOperation;
                ddlOperation.DataValueField = "Operationstitching_Front";
                ddlOperation.DataTextField = "FactoryWorkSpace";
                ddlOperation.DataBind();
                //ddlOperation.Items.Add(new ListItem("Select Operation", "-1", true));
            }
            if (Flag == "Stiching Back")
            {
                dtOperation = obj_OrderController.GetOperationById("tblOperationstitching_back", "tblStitchingbackOB", "Operationstitching_back", "FactoryWorkSpace", "GarmentTypeID", GarmentId);
                ddlOperation.DataSource = dtOperation;
                ddlOperation.DataValueField = "Operationstitching_back";
                ddlOperation.DataTextField = "FactoryWorkSpace";
                ddlOperation.DataBind();
                //ddlOperation.Items.Add(new ListItem("Select Operation", "-1", true));
            }
            if (Flag == "Stiching coller")
            {
                dtOperation = obj_OrderController.GetOperationById("tblOperationstitching_coller", "tblStitchingcollerOB", "Operationstitching_coller", "FactoryWorkSpace", "GarmentTypeID", GarmentId);
                ddlOperation.DataSource = dtOperation;
                ddlOperation.DataValueField = "Operationstitching_coller";
                ddlOperation.DataTextField = "FactoryWorkSpace";
                ddlOperation.DataBind();
                //ddlOperation.Items.Add(new ListItem("Select Operation", "-1", true));
            }
            if (Flag == "Stiching sleep")
            {
                dtOperation = obj_OrderController.GetOperationById("tblOperationstitching_sleep", "tblStitchingsleepOB", "Operationstitching_sleep", "FactoryWorkSpace", "GarmentTypeID", GarmentId);
                ddlOperation.DataSource = dtOperation;
                ddlOperation.DataValueField = "Operationstitching_sleep";
                ddlOperation.DataTextField = "FactoryWorkSpace";
                ddlOperation.DataBind();
                //ddlOperation.Items.Add(new ListItem("Select Operation", "-1", true));
            }
            if (Flag == "Stiching neck")
            {
                dtOperation = obj_OrderController.GetOperationById("tblOperationstitching_neck", "tblStitchingneckOB", "Operationstitching_neck", "FactoryWorkSpace", "GarmentTypeID", GarmentId);
                ddlOperation.DataSource = dtOperation;
                ddlOperation.DataValueField = "Operationstitching_neck";
                ddlOperation.DataTextField = "FactoryWorkSpace";
                ddlOperation.DataBind();
                //ddlOperation.Items.Add(new ListItem("Select Operation", "-1", true));
            }
            if (Flag == "Stiching Lining")
            {
                dtOperation = obj_OrderController.GetOperationById("tblOperationstitching_Lining", "tblStitchingLiningOB", "Operationstitching_Lining", "FactoryWorkSpace", "GarmentTypeID", GarmentId);
                ddlOperation.DataSource = dtOperation;
                ddlOperation.DataValueField = "Operationstitching_Lining";
                ddlOperation.DataTextField = "FactoryWorkSpace";
                ddlOperation.DataBind();
                //ddlOperation.Items.Add(new ListItem("Select Operation", "-1", true));
                //
            }
            if (Flag == "Stiching lower")
            {
                dtOperation = obj_OrderController.GetOperationById("tblOperationstitching_lower", "tblStitchinglowerOB", "Operationstitching_lower", "FactoryWorkSpace", "GarmentTypeID", GarmentId);
                ddlOperation.DataSource = dtOperation;
                ddlOperation.DataValueField = "Operationstitching_lower";
                ddlOperation.DataTextField = "FactoryWorkSpace";
                ddlOperation.DataBind();
                //ddlOperation.Items.Add(new ListItem("Select Operation", "-1", true));
            }
            if (Flag == "Stiching bottom")
            {
                dtOperation = obj_OrderController.GetOperationById("tblOperationstitching_bottom", "tblStitchingbottomOB", "Operationstitching_bottom", "FactoryWorkSpace", "GarmentTypeID", GarmentId);
                ddlOperation.DataSource = dtOperation;
                ddlOperation.DataValueField = "Operationstitching_bottom";
                ddlOperation.DataTextField = "FactoryWorkSpace";
                ddlOperation.DataBind();
                //ddlOperation.Items.Add(new ListItem("Select Operation", "-1", true));
            }
            if (Flag == "Stiching assembly")
            {
                dtOperation = obj_OrderController.GetOperationById("tblOperationstitching_assembly", "tblStitchingassemblyOB", "Operationstitching_assembly", "FactoryWorkSpace", "GarmentTypeID", GarmentId);
                ddlOperation.DataSource = dtOperation;
                ddlOperation.DataValueField = "Operationstitching_assembly";
                ddlOperation.DataTextField = "FactoryWorkSpace";
                ddlOperation.DataBind();
                //ddlOperation.Items.Add(new ListItem("Select Operation", "-1", true));
            }

            //For Rest Stich Section
            //For piping Section
            if (Flag == "Piping")
            {
                dtOperation = obj_OrderController.GetOperationById("tblOperationstitching_Piping", "tblStitchingPipingOB", "Operationstitching_Piping", "FactoryWorkSpace", "GarmentTypeID", GarmentId);
                ddlOperation.DataSource = dtOperation;
                ddlOperation.DataValueField = "Operationstitching_Piping";
                ddlOperation.DataTextField = "FactoryWorkSpace";
                ddlOperation.DataBind();
                //ddlOperation.Items.Add(new ListItem("Select Operation", "-1", true));
            }

            //END Piping
            //For Upper section
            if (Flag == "Upper")
            {
                dtOperation = obj_OrderController.GetOperationById("tblOperationstitching_Upper", "tblStitchingUpperOB", "Operationstitching_Upper", "FactoryWorkSpace", "GarmentTypeID", GarmentId);
                ddlOperation.DataSource = dtOperation;
                ddlOperation.DataValueField = "Operationstitching_Upper";
                ddlOperation.DataTextField = "FactoryWorkSpace";
                ddlOperation.DataBind();
                //ddlOperation.Items.Add(new ListItem("Select Operation", "-1", true));
            }

            //END Upper

            //For Upper shell section
            if (Flag == "Uppershell")
            {
                dtOperation = obj_OrderController.GetOperationById("tblOperationstitching_Uppershell", "tblStitchingUppershellOB", "Operationstitching_Uppershell", "FactoryWorkSpace", "GarmentTypeID", GarmentId);
                ddlOperation.DataSource = dtOperation;
                ddlOperation.DataValueField = "Operationstitching_Uppershell";
                ddlOperation.DataTextField = "FactoryWorkSpace";
                ddlOperation.DataBind();
                //ddlOperation.Items.Add(new ListItem("Select Operation", "-1", true));
            }
            //END Upper shell

            //For Lower shell section
            if (Flag == "Lowershell")
            {
                dtOperation = obj_OrderController.GetOperationById("tblOperationstitching_Lowershell", "tblStitchingLowershellOB", "Operationstitching_Lowershell", "FactoryWorkSpace", "GarmentTypeID", GarmentId);
                ddlOperation.DataSource = dtOperation;
                ddlOperation.DataValueField = "Operationstitching_Lowershell";
                ddlOperation.DataTextField = "FactoryWorkSpace";
                ddlOperation.DataBind();
                //ddlOperation.Items.Add(new ListItem("Select Operation", "-1", true));
            }
            //END Lower shell

            //For Shell section section
            if (Flag == "Shellsection")
            {
                dtOperation = obj_OrderController.GetOperationById("tblOperationstitching_Shellsection", "tblStitchingShellsectionOB", "Operationstitching_Shellsection", "FactoryWorkSpace", "GarmentTypeID", GarmentId);
                ddlOperation.DataSource = dtOperation;
                ddlOperation.DataValueField = "Operationstitching_Shellsection";
                ddlOperation.DataTextField = "FactoryWorkSpace";
                ddlOperation.DataBind();
                //ddlOperation.Items.Add(new ListItem("Select Operation", "-1", true));
            }
            //END Shell section

            //For Waist section section
            if (Flag == "Waistsection")
            {
                dtOperation = obj_OrderController.GetOperationById("tblOperationstitching_Waistsection", "tblStitchingWaistsectionOB", "Operationstitching_Waistsection", "FactoryWorkSpace", "GarmentTypeID", GarmentId);
                ddlOperation.DataSource = dtOperation;
                ddlOperation.DataValueField = "Operationstitching_Waistsection";
                ddlOperation.DataTextField = "FactoryWorkSpace";
                ddlOperation.DataBind();
                //ddlOperation.Items.Add(new ListItem("Select Operation", "-1", true));
            }
            //END Waist section

            //For Bandsection
            if (Flag == "Bandsection")
            {
                dtOperation = obj_OrderController.GetOperationById("tblOperationstitching_Bandsection", "tblStitchingBandsectionOB", "Operationstitching_Bandsection", "FactoryWorkSpace", "GarmentTypeID", GarmentId);
                ddlOperation.DataSource = dtOperation;
                ddlOperation.DataValueField = "Operationstitching_Bandsection";
                ddlOperation.DataTextField = "FactoryWorkSpace";
                ddlOperation.DataBind();
                //ddlOperation.Items.Add(new ListItem("Select Operation", "-1", true));
            }
            //END Band section

            //----Start Abhishek
            //For Neck New section
            if (Flag == "NeckNewsection")
            {
                dtOperation = obj_OrderController.GetOperationById("tblOperationstitching_NewNeck", "tblStitchingNewNeckOB", "Operationstitching_NewNeck", "FactoryWorkSpace", "GarmentTypeID", GarmentId);
                ddlOperation.DataSource = dtOperation;
                ddlOperation.DataValueField = "Operationstitching_NewNeck";
                ddlOperation.DataTextField = "FactoryWorkSpace";
                ddlOperation.DataBind();
                //ddlOperation.Items.Add(new ListItem("Select Operation", "-1", true));
            }

            //END Neck New section


            //For Neck faching section
            if (Flag == "NeckFacing")
            {
                dtOperation = obj_OrderController.GetOperationById("tblOperationstitching_Neckfacing", "tblStitchingNeckfacingOB", "Operationstitching_Neckfacing", "FactoryWorkSpace", "GarmentTypeID", GarmentId);
                ddlOperation.DataSource = dtOperation;
                ddlOperation.DataValueField = "Operationstitching_Neckfacing";
                ddlOperation.DataTextField = "FactoryWorkSpace";
                ddlOperation.DataBind();
                //ddlOperation.Items.Add(new ListItem("Select Operation", "-1", true));
            }
            if (Flag == "frontback")
            {
                dtOperation = obj_OrderController.GetOperationById("tblOperationstitching_Frontback", "tblStitchingFrontbackOB", "Operationstitching_Frontback", "FactoryWorkSpace", "GarmentTypeID", GarmentId);
                ddlOperation.DataSource = dtOperation;
                ddlOperation.DataValueField = "Operationstitching_Frontback";
                ddlOperation.DataTextField = "FactoryWorkSpace";
                ddlOperation.DataBind();
                //ddlOperation.Items.Add(new ListItem("Select Operation", "-1", true));
            }
            //END Neck New section


            //END Abhisek

            //END
            if (Flag == "Finishing")
            {
                dtOperation = obj_OrderController.GetOperationById("tblOperationFinishing", "tblFinishingOB", "OperationFinishing", "FactoryWorkSpace", "GarmentTypeID", GarmentId);
                ddlOperation.DataSource = dtOperation;
                ddlOperation.DataValueField = "OperationFinishing";
                ddlOperation.DataTextField = "FactoryWorkSpace";
                ddlOperation.DataBind();
                //ddlOperation.Items.Add(new ListItem("Select Operation", "-1", true));
            }

            if (dtOperation.Rows.Count > 0)
            {

                ddlOperation.SelectedValue = OperationId.ToString();
            }
            else
            {
                ShowAlert("please Select Another Garment !");
                return;
            }

            DataTable dtWorkerType = new DataTable();
            //int OperationIds = Convert.ToInt32(ddlOperation.SelectedValue);
            dtWorkerType = obj_OrderController.GetWorkerTypeById(OperationId, Flag);
            lstMachine.DataSource = dtWorkerType;
            lstMachine.DataValueField = "FactoryWorkSpace";
            lstMachine.DataTextField = "WorkerType";
            lstMachine.DataBind();
            lstMachine.SelectedValue = WorkerTypeID.ToString();


            DataTable dtAttechment = new DataTable();
            //int WorkerTypeIDs = Convert.ToInt32(lstMachine.SelectedValue);
            dtAttechment = obj_OrderController.GetAttachmentById(WorkerTypeID);
            lstAttechment.DataSource = dtAttechment;
            lstAttechment.DataValueField = "AttachmentID";
            lstAttechment.DataTextField = "AttachmentName";
            lstAttechment.DataBind();
            lstAttechment.SelectedValue = AttachmentID.ToString();

        }

        protected void ddlOperation_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dtWorkerType = new DataTable();
            int Id = Convert.ToInt32(ddlOperation.SelectedValue);
            dtWorkerType = obj_OrderController.GetWorkerTypeById(Id, Flag);
            lstMachine.DataSource = dtWorkerType;
            lstMachine.DataValueField = "FactoryWorkSpace";
            lstMachine.DataTextField = "WorkerType";
            lstMachine.DataBind();


            DataTable dtAttechBalnk = new DataTable();
            dtAttechBalnk = obj_OrderController.GetAttachmentById(0);
            lstAttechment.DataSource = dtAttechBalnk;
            lstAttechment.DataValueField = "AttachmentID";
            lstAttechment.DataTextField = "AttachmentName";
            lstAttechment.DataBind();
            lstAttechment.SelectedValue = AttachmentID.ToString();


        }

        protected void lstMachine_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dtAttechment = new DataTable();
            int Id = Convert.ToInt32(lstMachine.SelectedValue);
            dtAttechment = obj_OrderController.GetAttachmentById(Id);
            lstAttechment.DataSource = dtAttechment;
            lstAttechment.DataValueField = "AttachmentID";
            lstAttechment.DataTextField = "AttachmentName";
            lstAttechment.DataBind();

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (ddlOperation.SelectedValue == "-1")
            {
                ShowAlert("Please Select Operation");
                return;
            }
            if (lstMachine.SelectedValue == "")
            {
                ShowAlert("Please Select Machine/Manual !");
                return;
            }
            //if (lstAttechment.SelectedValue == "")
            //{
            //    ShowAlert("Please Select Attachment !");
            //    return;
            //}
            int AttachmentID = 0;
            int GarmentTypeID = Convert.ToInt32(GarmentId);
            int Operationcutting = Convert.ToInt32(ddlOperation.SelectedValue);
            int FactoryWorkSpace = Convert.ToInt32(lstMachine.SelectedValue);
            if (lstAttechment.SelectedValue != "")
            {
                AttachmentID = Convert.ToInt32(lstAttechment.SelectedValue);
            }
            else
            {
                AttachmentID = 0;
            }
            // string Flag = "Cutting";

            //DataTable dtIsExits = new DataTable();
            //if (Flag == "Cutting")
            //    dtIsExits = obj_OrderController.IsAllreadySave("tblFinalCuttingOB", "Operationcutting", ClientIDs.ToString(), DeptId.ToString(), StyleCode, FactoryWorkSpace.ToString(), AttachmentID.ToString(), Operationcutting.ToString());
            //if (Flag == "Stiching Front")
            //    dtIsExits = obj_OrderController.IsAllreadySave("tblFinalStitching_Front_OB", "Operationstitching_Front", ClientIDs.ToString(), DeptId.ToString(), StyleCode, FactoryWorkSpace.ToString(), AttachmentID.ToString(), Operationcutting.ToString());
            //if (Flag == "Stiching Back")
            //    dtIsExits = obj_OrderController.IsAllreadySave("tblFinalStitching_back_OB", "Operationstitching_Back", ClientIDs.ToString(), DeptId.ToString(), StyleCode, FactoryWorkSpace.ToString(), AttachmentID.ToString(), Operationcutting.ToString());
            //if (Flag == "Stiching coller")
            //    dtIsExits = obj_OrderController.IsAllreadySave("tblFinalStitching_coller_OB", "Operationstitching_coller", ClientIDs.ToString(), DeptId.ToString(), StyleCode, FactoryWorkSpace.ToString(), AttachmentID.ToString(), Operationcutting.ToString());
            //if (Flag == "Stiching sleep")
            //    dtIsExits = obj_OrderController.IsAllreadySave("tblFinalStitching_sleep_OB", "Operationstitching_sleep", ClientIDs.ToString(), DeptId.ToString(), StyleCode, FactoryWorkSpace.ToString(), AttachmentID.ToString(), Operationcutting.ToString());
            //if (Flag == "Stiching neck")
            //    dtIsExits = obj_OrderController.IsAllreadySave("tblFinalStitching_neck_OB", "Operationstitching_neck", ClientIDs.ToString(), DeptId.ToString(), StyleCode, FactoryWorkSpace.ToString(), AttachmentID.ToString(), Operationcutting.ToString());
            //if (Flag == "Stiching Lining")
            //    dtIsExits = obj_OrderController.IsAllreadySave("tblFinalStitching_Lining_OB", "Operationstitching_Lining", ClientIDs.ToString(), DeptId.ToString(), StyleCode, FactoryWorkSpace.ToString(), AttachmentID.ToString(), Operationcutting.ToString());
            //if (Flag == "Stiching lower")
            //    dtIsExits = obj_OrderController.IsAllreadySave("tblFinalStitching_lower_OB", "Operationstitching_lower", ClientIDs.ToString(), DeptId.ToString(), StyleCode, FactoryWorkSpace.ToString(), AttachmentID.ToString(), Operationcutting.ToString());
            //if (Flag == "Stiching bottom")
            //    dtIsExits = obj_OrderController.IsAllreadySave("tblFinalStitching_bottom_OB", "Operationstitching_bottom", ClientIDs.ToString(), DeptId.ToString(), StyleCode, FactoryWorkSpace.ToString(), AttachmentID.ToString(), Operationcutting.ToString());
            //if (Flag == "Stiching assembly")
            //    dtIsExits = obj_OrderController.IsAllreadySave("tblFinalStitching_assembly_OB", "Operationstitching_assembly", ClientIDs.ToString(), DeptId.ToString(), StyleCode, FactoryWorkSpace.ToString(), AttachmentID.ToString(), Operationcutting.ToString());
            //if (Flag == "Finishing")
            //    dtIsExits = obj_OrderController.IsAllreadySave("tblFinalFinishingOB", "Operationcutting", ClientIDs.ToString(), DeptId.ToString(), StyleCode, FactoryWorkSpace.ToString(), AttachmentID.ToString(), Operationcutting.ToString());

            //if (dtIsExits.Rows.Count > 0)
            //{
            //    ShowAlert("Record Already Exists");
            //    return;
            //}
            //else
            //{
            float Sfactor = 1.2f;
            //added by abhishek 11/1/2017
            if (UpdateFlag == "UPDATE")
            {
                int Result = obj_OrderController.UpdateFinalCuttingOB(ClientIDs, DeptId, StyleCode, StyleId, GarmentTypeID, Operationcutting, FactoryWorkSpace, AttachmentID, Flag, FinalOBID, ReUseStyleId, IsReUse, NewRef, OperationId, iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.UserID, Sfactor, StyleSequence);
                if (Result != 0)
                {
                    var IsCreated = 1;
                    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "scr", "NewCreated(" + IsCreated + ")", true);
                    
                }

            }
            else
            {


                int Result = obj_OrderController.InsertUpdateFinalCuttingOB(ClientIDs, DeptId, StyleCode, StyleId, GarmentTypeID, Operationcutting, FactoryWorkSpace, AttachmentID, Flag, FinalOBID, ReUseStyleId, IsReUse, NewRef, iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.UserID, Sfactor, StyleSequence);
                if (Result != 0)
                {
                    var IsCreated = 1;
                    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "scr", "NewCreated(" + IsCreated + ")", true);
                    
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
    }
}