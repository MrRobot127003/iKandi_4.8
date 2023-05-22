using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iKandi.BLL;
using iKandi.Common;
using System.Data;
using System.Web.UI.HtmlControls;
using iKandi.Web.Components;

namespace iKandi.Web.Admin.FitsSample
{
    public partial class frmPreorder_SamplingCycle : BasePage
    {
        String FitsFolderPath = "~/" + System.Configuration.ConfigurationManager.AppSettings["fits.docs.folder"];
        string StyleNumber = "";
        string TaskStatus = "";
        int TopDesignation = 0;
        int CadManager = 0;
        int fitsIndex = 0;
        public string RequestStatus
        {
            get;
            set;
        }
        public int StyleId
        {
            get;
            set;
        }
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
        public int NewRefrence
        {
            get;
            set;
        }
        public string UserId
        {
            get;
            set;
        }
        public bool OrderExist
        {
            get;
            set;
        }
        public int intShownFinalized
        {
            get;
            set;
        }
        private Boolean _iKandiUser = false;
        public Boolean IsIKandiUser
        {
            get
            {
                _iKandiUser = (ApplicationHelper.LoggedInUser.UserData.Designation == Designation.iKandi_Technical_Technologist || ApplicationHelper.LoggedInUser.UserData.Designation == Designation.iKandi_Technical_Manager);
                return _iKandiUser;
            }
        }

        private Boolean _biplUser = false;
        public Boolean IsBiplUser
        {
            get
            {
                _biplUser = (ApplicationHelper.LoggedInUser.UserData.Designation == Designation.BIPL_Merchandising_Manager || ApplicationHelper.LoggedInUser.UserData.Designation == Designation.BIPL_Merchandising_AccountManager || ApplicationHelper.LoggedInUser.UserData.Designation == Designation.BIPL_Merchandising_FitMerchant);
                return _biplUser;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (null != Request.QueryString["StyleNumber"])
            {
                StyleNumber = Request.QueryString["StyleNumber"].ToString();
            }
            if (null != Request.QueryString["TaskStatus"])
            {
                TaskStatus = Request.QueryString["TaskStatus"].ToString();
            }
            if (null != Request.QueryString["StyleId"])
            {
                StyleId = Convert.ToInt32(Request.QueryString["StyleId"]);
                hdnStyleId.Value = StyleId.ToString();
            }
            if (null != Request.QueryString["RequestStatus"])
            {
                RequestStatus = Request.QueryString["RequestStatus"];
                intShownFinalized = 0;
            }
            else
            {
                RequestStatus = "Sampling 1";
                intShownFinalized = 1;
            }
            

            this.UserId = ApplicationHelper.LoggedInUser.UserData.UserID.ToString();

            if (ApplicationHelper.LoggedInUser.UserData.Designation == Designation.BIPL_CAD_Manager)
                CadManager = 1;
            if (ApplicationHelper.LoggedInUser.UserData.Designation == Designation.BIPL_Sales_Manager)
                TopDesignation = 1;
            if (ApplicationHelper.LoggedInUser.UserData.Designation == Designation.iKandi_TopManagement_Manager)
                TopDesignation = 1;

            if (!IsPostBack)
            {
                BindClient();
                BindStatus();
                GetSamplingFitsCycleFlow_PreOrder();
                if (TopDesignation == 1)
                    btnSubmit.Visible = false;
                ViewState["Save"] = 0;
            }

        }
        private void BindClient()
        {
            try
            {
                List<SamplePattern> objSamplePattern = FITsControllerInstance.Get_Client_ByAutoAllocPattern();
                if (objSamplePattern.Count > 0)
                {
                    ddlClientNameSelect.Items.Clear();
                    ddlClientNameSelect.DataSource = objSamplePattern;
                    ddlClientNameSelect.DataTextField = "ClientName";
                    ddlClientNameSelect.DataValueField = "ClientId";
                    ddlClientNameSelect.DataBind();
                    ddlClientNameSelect.Items.Insert(0, "Select");
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
            }
        }

        private void BindStatus()
        {
            try
            {
                List<SamplePattern> objSamplePattern = FITsControllerInstance.GetAutoAllocation_Status();
                if (objSamplePattern.Count > 0)
                {
                    ddlTypeNameSelect.Items.Clear();
                    ddlTypeNameSelect.DataSource = objSamplePattern;
                    ddlTypeNameSelect.DataTextField = "Status";
                    ddlTypeNameSelect.DataValueField = "Status";
                    ddlTypeNameSelect.DataBind();
                    ddlTypeNameSelect.Items.Insert(0, "Select");
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
            }
        }

        private void GetSamplingFitsCycleFlow_PreOrder()
        {
            SamplePattern objSample = new SamplePattern();
            objSample.Styleid = StyleId;
            objSample.StyleNumber = txtsearch.Value;
            objSample.ClientId = ddlClientNameSelect.SelectedValue == "Select" ? 0 : Convert.ToInt32(ddlClientNameSelect.SelectedValue);
            objSample.ClientDeptid = ddlDeptNameSelect.SelectedValue == "Select" ? 0 : Convert.ToInt32(ddlDeptNameSelect.SelectedValue);
            objSample.Status = RequestStatus;
            objSample.ClientParentDeptid = ddlparentDept.SelectedValue == "Select" ? 0 : Convert.ToInt32(ddlparentDept.SelectedValue);

            if (StyleId > 0)
            {
                objSample.Styleid = StyleId;
                hdnStyleId.Value = StyleId.ToString();
                tblSearch.Style.Add("display", "none");
                gvSamplingFitsCycleflow.DataSource = null;
                gvSamplingFitsCycleflow.DataBind();

                List<SamplePattern> objSamplePattern = FITsControllerInstance.GetSamplingFitsCycleFlow_PreOrder(objSample, Convert.ToInt32(UserId), -1, -1, -1, -1);
                if (objSamplePattern.Count > 0)
                {
                    foreach (SamplePattern objSampleNew in objSamplePattern)
                    {
                        OrderExist = objSampleNew.IsOrderExist;
                    }
                    gvSamplingFitsCycleflow.DataSource = objSamplePattern;
                    gvSamplingFitsCycleflow.DataBind();
                }
                else
                {
                    gvSamplingFitsCycleflow.DataSource = null;
                    gvSamplingFitsCycleflow.DataBind();
                    btnSubmit.Visible = false;
                }
            }
            else
            {
                if ((TopDesignation == 1) || (CadManager == 1))
                {
                    tblSearch.Style.Add("display", "");
                    if (TopDesignation == 1)
                        btnSubmit.Visible = false;

                    if (CadManager == 1)
                        btnSubmit.Visible = true;

                    gvSamplingFitsCycleflow.DataSource = null;
                    gvSamplingFitsCycleflow.DataBind();
                    List<SamplePattern> objSamplePattern = FITsControllerInstance.GetSamplingFitsCycleFlow_PreOrder(objSample, Convert.ToInt32(UserId), -1, -1, -1, -1);
                    if (objSamplePattern.Count > 0)
                    {
                        gvSamplingFitsCycleflow.DataSource = objSamplePattern;
                        gvSamplingFitsCycleflow.DataBind();
                    }
                    else
                    {
                        gvSamplingFitsCycleflow.DataSource = null;
                        gvSamplingFitsCycleflow.DataBind();
                        btnSubmit.Visible = false;
                    }
                }
                else
                {
                    btnSubmit.Visible = false;
                }
            }

        }

        protected void ddlClientNameSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClientController objClientController = new ClientController();
            //if (ddlClientNameSelect.SelectedValue != "Select")
            //{
            //    List<SamplePattern> objSamplePattern = FITsControllerInstance.Get_ClientDepts_ByAutoAllocPattern(Convert.ToInt32(ddlClientNameSelect.SelectedValue));

            //    if (objSamplePattern.Count > 0)
            //    {
            //        ddlDeptNameSelect.Items.Clear();
            //        ddlDeptNameSelect.DataSource = objSamplePattern;
            //        ddlDeptNameSelect.DataTextField = "DeptName";
            //        ddlDeptNameSelect.DataValueField = "ClientDeptid";
            //        ddlDeptNameSelect.DataBind();
            //        ddlDeptNameSelect.Items.Insert(0, "Select");
            //    }
            //}
            //else
            //{
            //    ddlDeptNameSelect.Items.Clear();
            //    ddlDeptNameSelect.Items.Insert(0, "Select");
            //}

            int ClientID = 0;
            if (ddlClientNameSelect.SelectedValue == "Select" || ddlClientNameSelect.SelectedValue == "")
                ClientID = -1;
            else
                ClientID = Convert.ToInt16(ddlClientNameSelect.SelectedValue);

            List<SamplePattern> objSamplePatterns = FITsControllerInstance.Get_ClientDeptsParent(ClientID, "Parent", -1);
            if (objSamplePatterns.Count > 0)
            {
                ddlparentDept.Items.Clear();
                ddlparentDept.DataSource = objSamplePatterns;
                ddlparentDept.DataTextField = "DeptName";
                ddlparentDept.DataValueField = "ClientDeptid";
                ddlparentDept.DataBind();
                ddlparentDept.Items.Insert(0, "Select");
            }
            else
            {
                ddlparentDept.Items.Clear();
                ddlparentDept.Items.Insert(0, "Select");

                ddlDeptNameSelect.Items.Clear();
                ddlDeptNameSelect.Items.Insert(0, "Select");
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            GetSamplingFitsCycleFlow_PreOrder();
        }

        protected void btnFitsReuse_Click(object sender, EventArgs e)
        {
            CreateNew = Convert.ToInt32(hdnFitsCreateNew.Value);
            NewRefrence = Convert.ToInt32(hdnFitsNewRef.Value);
            ReUse = Convert.ToInt32(hdnFitsReUse.Value);
            ReUseStyleId = Convert.ToInt32(hdnReUseStyleId.Value);
            SamplePattern objSample = new SamplePattern();
            objSample.Styleid = StyleId;
            objSample.StyleNumber = txtsearch.Value;
            objSample.ClientId = ddlClientNameSelect.SelectedValue == "Select" ? 0 : Convert.ToInt32(ddlClientNameSelect.SelectedValue);
            objSample.ClientDeptid = ddlDeptNameSelect.SelectedValue == "Select" ? 0 : Convert.ToInt32(ddlDeptNameSelect.SelectedValue);
            objSample.Status = RequestStatus;

            List<SamplePattern> objSamplePattern = FITsControllerInstance.GetSamplingFitsCycleFlow_PreOrder(objSample, Convert.ToInt32(UserId), CreateNew, NewRefrence, ReUse, ReUseStyleId);
            gvSamplingFitsCycleflow.DataSource = objSamplePattern;
            gvSamplingFitsCycleflow.DataBind();
            btnSubmit.Visible = true;

        }

        protected void gvSamplingFitsCycleflow_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            int FitsType = 0;

            if (e.Row.RowType == DataControlRowType.Header)
            {
                Label lblAMHead = (Label)e.Row.FindControl("lblAMHead");
                Label lblPDMHead = (Label)e.Row.FindControl("lblPDMHead");

                Label lblPRDMHead = (Label)e.Row.FindControl("lblPRDMHead");
                Label lblPDHead = (Label)e.Row.FindControl("lblPDHead");

                if (OrderExist == true)
                {
                    lblAMHead.Visible = true;
                    lblPRDMHead.Visible = true;
                    lblPDMHead.Visible = false;
                    lblPDHead.Visible = false;
                }
                else
                {
                    lblAMHead.Visible = false;
                    lblPRDMHead.Visible = false;
                    lblPDMHead.Visible = true;
                    lblPDHead.Visible = true;
                }



            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblCreation_FitsDate = (Label)e.Row.FindControl("lblCreation_FitsDate");
                Label lblStatus = (Label)e.Row.FindControl("lblStatus");
                DateTime CreationDate = Convert.ToDateTime(DataBinder.Eval(e.Row.DataItem, "CreatedOn"));
                DateTime FitsCommentDate = Convert.ToDateTime(DataBinder.Eval(e.Row.DataItem, "FitsCommentDate"));


                if (CreationDate != DateTime.MinValue)
                {
                    if (FitsCommentDate != DateTime.MinValue)
                        lblCreation_FitsDate.Text = "(" + FitsCommentDate.ToString("dd MMM (ddd)") + ")";
                    else
                        lblCreation_FitsDate.Text = "(" + CreationDate.ToString("dd MMM (ddd)") + ")";
                }
                DropDownList ddlFits = (DropDownList)e.Row.FindControl("ddlFits");

                Label lblAM = (Label)e.Row.FindControl("lblAM");
                lblAM.Text = DataBinder.Eval(e.Row.DataItem, "AcountMgrName") == DBNull.Value ? "" : DataBinder.Eval(e.Row.DataItem, "AcountMgrName").ToString();

                Label lblPDM = (Label)e.Row.FindControl("lblPDM");
                lblPDM.Text = DataBinder.Eval(e.Row.DataItem, "PD_MarchentName") == DBNull.Value ? "" : DataBinder.Eval(e.Row.DataItem, "PD_MarchentName").ToString();

                Label lblSTCTargetDate = (Label)e.Row.FindControl("lblSTCTargetDate");
                lblSTCTargetDate.Text = Convert.ToDateTime(DataBinder.Eval(e.Row.DataItem, "StcEta")) == DateTime.MinValue ? "" : Convert.ToDateTime(DataBinder.Eval(e.Row.DataItem, "StcEta")).ToString("dd MMM (ddd)");

                Label lblSampleSentDate = (Label)e.Row.FindControl("lblSampleSentDate");
                lblSampleSentDate.Text = Convert.ToDateTime(DataBinder.Eval(e.Row.DataItem, "SampleSentDate")) == DateTime.MinValue ? "" : Convert.ToDateTime(DataBinder.Eval(e.Row.DataItem, "SampleSentDate")).ToString("dd MMM (ddd)");

                CheckBox ChkIsQC = (CheckBox)e.Row.FindControl("ChkIsQC");
                ChkIsQC.Checked = Convert.ToBoolean(DataBinder.Eval(e.Row.DataItem, "IsQCPresent"));

                CheckBox ChkRefSample = (CheckBox)e.Row.FindControl("ChkRefSample");
                Label lblFitsEta = (Label)e.Row.FindControl("lblFitsEta");
                Label lblFits = (Label)e.Row.FindControl("lblFits");
                HiddenField hdnFits = (HiddenField)e.Row.FindControl("hdnFits");
                
                Label lblFitsActDate = (Label)e.Row.FindControl("lblFitsActDate");
                CheckBox chkStcApproved = (CheckBox)e.Row.FindControl("chkStcApproved");
                HiddenField hdnIsIkandiClient = (HiddenField)e.Row.FindControl("hdnIsIkandiClient");
                int IsIkandiClient = Convert.ToInt16(hdnIsIkandiClient.Value);

                HiddenField hdnMasterQCId = (HiddenField)e.Row.FindControl("hdnMasterQCId");
                DropDownList ddlQC = (DropDownList)e.Row.FindControl("ddlQC");
                ImageButton ImgbtnHistory = (ImageButton)e.Row.FindControl("ImgbtnHistory");
                RadioButtonList rblHandoversection = (RadioButtonList)e.Row.FindControl("rblHandoversection");
                //rblHandoversection.SelectedValue = DataBinder.Eval(e.Row.DataItem, "IsQCPresent");
                List<SamplePattern> objSamplePattern = FITsControllerInstance.GetAllCQD();
               
                if (objSamplePattern.Count > 0)
                {
                    ddlQC.DataSource = objSamplePattern;
                    ddlQC.DataTextField = "CQDName";
                    ddlQC.DataValueField = "CQDId";
                    ddlQC.DataBind();
                    ddlQC.Items.Insert(0, "Select");

                    if (hdnMasterQCId.Value != "-1")
                    {
                        ddlQC.SelectedValue = hdnMasterQCId.Value;
                    }
                }
                ddlQC.Enabled = false;
                if (ChkIsQC.Checked == true)
                    ddlQC.Enabled = true;

                //Fits Section
                HtmlGenericControl dvFits = (HtmlGenericControl)e.Row.FindControl("dvFits");
                HtmlGenericControl dvSampling = (HtmlGenericControl)e.Row.FindControl("dvSampling");
                FileUpload fitsUpload = (FileUpload)e.Row.FindControl("fitsUpload");
                FileUpload SampleUpload = (FileUpload)e.Row.FindControl("SampleUpload");
                HiddenField hdnStateSelection = e.Row.FindControl("hdnStateSelection") as HiddenField;

                FileUpload fitsUpload_New = (FileUpload)e.Row.FindControl("fitsUpload_New");
                FileUpload SampleUpload_New = (FileUpload)e.Row.FindControl("SampleUpload_New");

                HiddenField hdnFitsType = (HiddenField)e.Row.FindControl("hdnFitsType");
                HyperLink hlkFitsUpload = (HyperLink)e.Row.FindControl("hlkFitsUpload");
                HyperLink hlkFitsUpload_New = (HyperLink)e.Row.FindControl("hlkFitsUpload_New");

                if (hdnFitsType != null)
                    FitsType = Convert.ToInt32(hdnFitsType.Value);

                string Status = DataBinder.Eval(e.Row.DataItem, "Status").ToString();
                hdnStateSelection.Value = Convert.ToString(GetFitsIndex(DataBinder.Eval(e.Row.DataItem, "Status").ToString()));
                string FitsStatus = DataBinder.Eval(e.Row.DataItem, "FitsStatus").ToString();
                bool RequestDone = Convert.ToBoolean(DataBinder.Eval(e.Row.DataItem, "FitsRequestDone"));
                bool ApprovedDone = Convert.ToBoolean(DataBinder.Eval(e.Row.DataItem, "FitsApprovedDone"));
                bool FitsNotRequest = Convert.ToBoolean(DataBinder.Eval(e.Row.DataItem, "FitsNotRequest"));
                bool HistoryPresent = Convert.ToBoolean(DataBinder.Eval(e.Row.DataItem, "HistoryPresent"));

                //lblStatus.Text = Status == "Buying Sample" ? "Fit 1" : Status;
                //  lblStatus.Text = RequestStatus; //Comment code by bharat on 25-10-19
              

                if (HistoryPresent == true)
                    ImgbtnHistory.Visible = true;
                else
                    ImgbtnHistory.Visible = false;

                //fitsUpload.Enabled = false;
                SampleUpload.Enabled = false;
                //fitsUpload_New.Enabled = false;
                SampleUpload_New.Enabled = false;
                hlkFitsUpload_New.Visible = (string.IsNullOrEmpty(DataBinder.Eval(e.Row.DataItem, "FitsCommentUpload_New").ToString())) ? false : true;
                ddlFits.SelectedIndex = GetFitsIndex(DataBinder.Eval(e.Row.DataItem, "FitsStatus").ToString());
                hlkFitsUpload_New.NavigateUrl = (string.IsNullOrEmpty(DataBinder.Eval(e.Row.DataItem, "FitsCommentUpload_New").ToString())) ? "" : FitsFolderPath + DataBinder.Eval(e.Row.DataItem, "FitsCommentUpload_New").ToString();
                if ((Status == "Sampling") || (Status == "Buying Sample"))
                {
                    //dvFits.Style.Add("display", "none");
                    //dvSampling.Style.Add("display", "block");
                    //dvSampling.InnerHtml = Status == "Buying Sample" ? "Fit 1" : Status;
                }
                else
                {
                    dvFits.Style.Add("display", "block");
                    dvSampling.Style.Add("display", "none");
                    dvSampling.InnerHtml = "";
                    hdnFits.Value = FitsStatus == "" ? Status : FitsStatus;
                    
                   
                    //if (DataBinder.Eval(e.Row.DataItem, "FitsStatus").ToString() != "")
                    //{
                    //    ddlFits.SelectedIndex = GetFitsIndex(DataBinder.Eval(e.Row.DataItem, "FitsStatus").ToString());
                    //    if (ddlFits.SelectedIndex == 14)
                    //        ChkRefSample.Enabled = true;
                    //}
                    //ChkRefSample.Checked = false;


                    //string BiplFilePath = DataBinder.Eval(e.Row.DataItem, "BiplFilePath").ToString();
                    //string FilePath = DataBinder.Eval(e.Row.DataItem, "FitsCommentUpload").ToString();

                    //hlkFitsUpload.Visible = (string.IsNullOrEmpty(DataBinder.Eval(e.Row.DataItem, "FitsCommentUpload").ToString())) ? false : true;
                    //hlkFitsUpload_New.Visible = (string.IsNullOrEmpty(DataBinder.Eval(e.Row.DataItem, "FitsCommentUpload_New").ToString())) ? false : true;

                   // hlkFitsUpload.NavigateUrl = (string.IsNullOrEmpty(DataBinder.Eval(e.Row.DataItem, "FitsCommentUpload").ToString())) ? "" : FitsFolderPath + DataBinder.Eval(e.Row.DataItem, "FitsCommentUpload").ToString();

                    lblStatus.Text = hdnFits.Value;//add code by bharat on 25-10-19
                    lblFitsEta.Text = Convert.ToDateTime(DataBinder.Eval(e.Row.DataItem, "FitsETADate")) == DateTime.MinValue ? "" : Convert.ToDateTime(DataBinder.Eval(e.Row.DataItem, "FitsETADate")).ToString("dd MMM (ddd)");

                    lblFitsActDate.Text = Convert.ToDateTime(DataBinder.Eval(e.Row.DataItem, "FitsActualDate")) == DateTime.MinValue ? "" : Convert.ToDateTime(DataBinder.Eval(e.Row.DataItem, "FitsActualDate")).ToString("dd MMM (ddd)");

                    chkStcApproved.Visible = true;

                    chkStcApproved.Checked = Convert.ToBoolean(DataBinder.Eval(e.Row.DataItem, "StcApproved"));

                    string FitsCommentSent = DataBinder.Eval(e.Row.DataItem, "FitsCommentSentFor").ToString();
                    string FitsPlanningFor = DataBinder.Eval(e.Row.DataItem, "FitsPlanningFor").ToString();

                    //if (FitsPlanningFor != "")
                    //{
                    //    lblFits.Text = FitsPlanningFor;
                    //    lblStatus.Text = FitsPlanningFor;
                    //}
                    //else
                    //{
                    //    if (FitsCommentSent != "")
                    //        lblFits.Text = FitsCommentSent;
                    //}
                }

                // Hand Over Section
                Label lblHandoverEta = (Label)e.Row.FindControl("lblHandoverEta");
                if (Convert.ToDateTime(DataBinder.Eval(e.Row.DataItem, "HandOverEta")) == DateTime.MinValue)
                {
                    lblHandoverEta.Text = Convert.ToDateTime(DataBinder.Eval(e.Row.DataItem, "SamplingHandOverEta")) == DateTime.MinValue ? "" : Convert.ToDateTime(DataBinder.Eval(e.Row.DataItem, "SamplingHandOverEta")).ToString("dd MMM (ddd)");
                }
                else
                {
                    lblHandoverEta.Text = Convert.ToDateTime(DataBinder.Eval(e.Row.DataItem, "HandOverEta")) == DateTime.MinValue ? "" : Convert.ToDateTime(DataBinder.Eval(e.Row.DataItem, "HandOverEta")).ToString("dd MMM (ddd)");
                }

                Label lblHandoverActDate = (Label)e.Row.FindControl("lblHandoverActDate");
                HiddenField hdnHandoverActDate = (HiddenField)e.Row.FindControl("hdnHandoverActDate");

                lblHandoverActDate.Text = Convert.ToDateTime(DataBinder.Eval(e.Row.DataItem, "HandOverActDate")) == DateTime.MinValue ? "" : Convert.ToDateTime(DataBinder.Eval(e.Row.DataItem, "HandOverActDate")).ToString("dd MMM (ddd)");
                hdnHandoverActDate.Value = Convert.ToDateTime(DataBinder.Eval(e.Row.DataItem, "HandOverActDate")) == DateTime.MinValue ? "" : Convert.ToDateTime(DataBinder.Eval(e.Row.DataItem, "HandOverActDate")).ToString("dd MMM yy");

                CheckBox ChkHandover = (CheckBox)e.Row.FindControl("ChkHandover");
                ChkHandover.Checked = Convert.ToBoolean(DataBinder.Eval(e.Row.DataItem, "IsHandOver"));
                if (ChkHandover.Checked)
                    ChkHandover.Enabled = false;

                // Pattern Ready Section
                Label lblPatternEta = (Label)e.Row.FindControl("lblPatternEta");
                lblPatternEta.Text = Convert.ToDateTime(DataBinder.Eval(e.Row.DataItem, "PatterntEta")) == DateTime.MinValue ? "" : Convert.ToDateTime(DataBinder.Eval(e.Row.DataItem, "PatterntEta")).ToString("dd MMM (ddd)");

                Label lblPatternActDate = (Label)e.Row.FindControl("lblPatternActDate");
                HiddenField hdnPatternActDate = (HiddenField)e.Row.FindControl("hdnPatternActDate");

                lblPatternActDate.Text = Convert.ToDateTime(DataBinder.Eval(e.Row.DataItem, "PatternReadyActualDate")) == DateTime.MinValue ? "" : Convert.ToDateTime(DataBinder.Eval(e.Row.DataItem, "PatternReadyActualDate")).ToString("dd MMM (ddd)");
                hdnPatternActDate.Value = Convert.ToDateTime(DataBinder.Eval(e.Row.DataItem, "PatternReadyActualDate")) == DateTime.MinValue ? "" : Convert.ToDateTime(DataBinder.Eval(e.Row.DataItem, "PatternReadyActualDate")).ToString("dd MMM yy");

                CheckBox ChkPattern = (CheckBox)e.Row.FindControl("ChkPattern");
                ChkPattern.Checked = Convert.ToBoolean(DataBinder.Eval(e.Row.DataItem, "IsPatternReady"));
                bool IscostingWithPattern = Convert.ToBoolean(DataBinder.Eval(e.Row.DataItem, "IsCostingWithPattern"));

                if (intShownFinalized == 1)
                    rblHandoversection.Visible = true;
                else
                    rblHandoversection.Visible = false;
                if (CadManager == 1)
                {
                    if (Request.QueryString["RequestStatus"].Contains("Sampling 1"))
                    {
                        rblHandoversection.Visible = false;
                    }
                    else
                    {
                        rblHandoversection.Visible = true;
                        rblHandoversection.Enabled = false;
                    }
                }
                else
                {
                    if (null != Request.QueryString["RequestStatus"])
                    {
                        if (Request.QueryString["RequestStatus"].Contains("Sampling 1"))
                        {
                            rblHandoversection.Visible = false;
                        }
                        else
                        {
                           
                                rblHandoversection.Visible = true;
                                rblHandoversection.Enabled = false;
                           
                           
                        }
                    }
                    if ((Request.QueryString["RequestStatus"] == null) && (IscostingWithPattern == true) && (CadManager != 1))
                    {
                        rblHandoversection.SelectedIndex = 1;
                        rblHandoversection.Visible = true;
                        rblHandoversection.Enabled = false;
                    }

                   
                   
                }


                if (CadManager != 1)
                    {
                        ChkPattern.Enabled = false;
                        //if (lblFits.Text == "Sampling 1")
                        //    rblHandoversection.Enabled = false;
                        //else
                        //    rblHandoversection.Enabled = true;

                   

                        //if (RequestStatus.Contains("Sampling 1"))
                        //    rblHandoversection.Visible = false;
                        //else
                        //    rblHandoversection.Visible = true;

                    }
                if (ChkHandover.Checked)
                    ChkPattern.Enabled = true;
                else
                    ChkPattern.Enabled = false;

                if (ChkPattern.Checked)
                    ChkPattern.Enabled = false;

                // Sample Sent Section
                Label lblSampleEta = (Label)e.Row.FindControl("lblSampleEta");
                lblSampleEta.Text = Convert.ToDateTime(DataBinder.Eval(e.Row.DataItem, "SampleSentEta")) == DateTime.MinValue ? "" : Convert.ToDateTime(DataBinder.Eval(e.Row.DataItem, "SampleSentEta")).ToString("dd MMM (ddd)");

                Label lblSampleActDate = (Label)e.Row.FindControl("lblSampleActDate");
                HiddenField hdnSampleActDate = (HiddenField)e.Row.FindControl("hdnSampleActDate");

                lblSampleActDate.Text = Convert.ToDateTime(DataBinder.Eval(e.Row.DataItem, "SampleSentActualDate")) == DateTime.MinValue ? "" : Convert.ToDateTime(DataBinder.Eval(e.Row.DataItem, "SampleSentActualDate")).ToString("dd MMM (ddd)");
                hdnSampleActDate.Value = Convert.ToDateTime(DataBinder.Eval(e.Row.DataItem, "SampleSentActualDate")) == DateTime.MinValue ? "" : Convert.ToDateTime(DataBinder.Eval(e.Row.DataItem, "SampleSentActualDate")).ToString("dd MMM yy");

                CheckBox ChkSample = (CheckBox)e.Row.FindControl("ChkSample");
                ChkSample.Checked = Convert.ToBoolean(DataBinder.Eval(e.Row.DataItem, "IsSampleSent"));

                if (ChkPattern.Checked)
                {
                    if (IscostingWithPattern == false)
                    {
                        ChkSample.Enabled = true;
                        SampleUpload.Enabled = true;
                        SampleUpload_New.Enabled = true;
                    }
                    else
                    {
                        ChkSample.Enabled = false;
                        SampleUpload.Enabled = false;
                        SampleUpload_New.Enabled = false;
                    }
                }
                else
                    ChkSample.Enabled = false;

                if (ChkSample.Checked)
                {
                    ChkSample.Enabled = false;
                    SampleUpload.Enabled = false;
                    SampleUpload_New.Enabled = false;
                }


                HyperLink hlkSampleUpload = (HyperLink)e.Row.FindControl("hlkSampleUpload");
                hlkSampleUpload.Visible = (string.IsNullOrEmpty(DataBinder.Eval(e.Row.DataItem, "SampleUpload").ToString())) ? false : true;
                hlkSampleUpload.NavigateUrl = (string.IsNullOrEmpty(DataBinder.Eval(e.Row.DataItem, "SampleUpload").ToString())) ? "" : FitsFolderPath + DataBinder.Eval(e.Row.DataItem, "SampleUpload").ToString();

                HyperLink hlkSampleUpload_New = (HyperLink)e.Row.FindControl("hlkSampleUpload_New");
                hlkSampleUpload_New.Visible = (string.IsNullOrEmpty(DataBinder.Eval(e.Row.DataItem, "SampleUpload_New").ToString())) ? false : true;
                hlkSampleUpload_New.NavigateUrl = (string.IsNullOrEmpty(DataBinder.Eval(e.Row.DataItem, "SampleUpload_New").ToString())) ? "" : FitsFolderPath + DataBinder.Eval(e.Row.DataItem, "SampleUpload_New").ToString();

                Label lblComment = (Label)e.Row.FindControl("lblComment");
                HtmlImage imgComment = (HtmlImage)e.Row.FindControl("imgComment");
                string sComment = DataBinder.Eval(e.Row.DataItem, "Commentes").ToString();
                if (sComment != "")
                {
                    imgComment.Visible = true;
                    string Comment = "";
                    string[] ArrComment = sComment.Trim().Split('~');
                    if (ArrComment.Length > 0)
                    {
                        for (int i = 0; i < ArrComment.Length; i++)
                        {
                            Comment = Comment + ArrComment[i].Trim().ToString() + "</br>";
                        }
                        lblComment.Text = Comment.ToString();
                    }
                }

                if (TopDesignation == 1)
                {
                    e.Row.Cells[3].Enabled = false;
                    e.Row.Cells[5].Enabled = false;
                    e.Row.Cells[6].Enabled = false;
                    e.Row.Cells[3].CssClass = "cellback";
                    e.Row.Cells[4].CssClass = "cellback";
                    e.Row.Cells[5].CssClass = "cellback";
                    e.Row.Cells[6].CssClass = "cellback";
                    e.Row.Cells[7].CssClass = "cellback";
                    ddlFits.Enabled = false;
                    ChkIsQC.Enabled = false;
                    fitsUpload.Enabled = false;
                    SampleUpload.Enabled = false;
                    //fitsUpload_New.Enabled = false;
                    SampleUpload_New.Enabled = false;
                    chkStcApproved.Enabled = false;
                    ChkSample.Enabled = false;
                }

                if (CadManager == 1)
                {
                    e.Row.Cells[3].Enabled = false;
                    e.Row.Cells[5].Enabled = false;
                    e.Row.Cells[3].CssClass = "cellback";
                    e.Row.Cells[4].CssClass = "cellback";
                    e.Row.Cells[5].CssClass = "cellback";
                    e.Row.Cells[7].CssClass = "cellback";
                    //fitsUpload.Enabled = false;
                    SampleUpload.Enabled = false;
                    //fitsUpload_New.Enabled = false;
                    SampleUpload_New.Enabled = false;
                    chkStcApproved.Enabled = false;
                    ddlFits.Enabled = false;
                    ChkIsQC.Enabled = false;
                    ChkSample.Enabled = false;
                }
                else
                {
                    if ((IsIKandiUser == true) && (IsIkandiClient == 1))
                    {
                        ChkIsQC.Enabled = false;
                        ChkHandover.Enabled = false;
                        ChkPattern.Enabled = false;
                        ChkSample.Enabled = false;
                        chkStcApproved.Enabled = false;
                        SampleUpload.Enabled = false;
                        SampleUpload_New.Enabled = false;
                        ddlQC.Enabled = false;

                        if ((Status != "Sampling") && (Status != "Buying Sample"))
                        {
                            if (RequestDone == true)
                            {
                                e.Row.Cells[3].Enabled = false;
                                e.Row.Cells[5].Enabled = false;
                                e.Row.Cells[6].Enabled = false;
                                e.Row.Cells[3].CssClass = "cellback";
                                e.Row.Cells[4].CssClass = "cellback";
                                e.Row.Cells[5].CssClass = "cellback";
                                e.Row.Cells[6].CssClass = "cellback";
                                e.Row.Cells[7].CssClass = "cellback";
                                fitsUpload.Enabled = false;
                                SampleUpload.Enabled = false;
                                //fitsUpload_New.Enabled = false;
                                SampleUpload_New.Enabled = false;
                                chkStcApproved.Enabled = false;
                                ddlFits.Enabled = false;
                                ChkRefSample.Enabled = false;
                                ChkSample.Enabled = false;
                                btnSubmit.Visible = false;
                            }
                            else
                            {
                                ddlFits.Enabled = true;
                                fitsUpload.Enabled = true;
                                //fitsUpload_New.Enabled = true;
                                fitsIndex = GetFitsIndex(DataBinder.Eval(e.Row.DataItem, "FitsStatus").ToString());
                                fitsIndex = fitsIndex + 1;
                                ddlFits.SelectedIndex = fitsIndex;
                                hlkFitsUpload.Visible = false;
                                hlkFitsUpload_New.Visible = false;
                                lblFitsActDate.Text = "";
                            }
                        }
                    }
                    if ((IsBiplUser == true) && (IsIkandiClient == 1))
                    {
                        ddlFits.Enabled = false;
                        fitsUpload.Enabled = false;
                        //fitsUpload_New.Enabled = false;
                        ChkRefSample.Enabled = false;
                        chkStcApproved.Enabled = false;

                        if (ChkHandover.Checked == false)
                            ChkHandover.Enabled = true;

                        if (ChkHandover.Checked)
                            ChkPattern.Enabled = true;
                        else
                            ChkPattern.Enabled = false;

                        if (ChkPattern.Checked)
                        {
                            ChkPattern.Enabled = false;
                            if (IscostingWithPattern == false)
                            {
                                ChkSample.Enabled = true;
                                SampleUpload.Enabled = true;
                                SampleUpload_New.Enabled = true;
                            }
                            else
                            {
                                ChkSample.Enabled = false;
                                SampleUpload.Enabled = false;
                                SampleUpload_New.Enabled = false;
                            }
                        }

                        if (FitsStatus == "Stc")
                        {
                            if (ChkPattern.Checked)
                            {
                                chkStcApproved.Enabled = true;
                                chkStcApproved.Checked = true;
                                if (ChkRefSample.Checked == false)
                                {
                                    ChkSample.Enabled = false;
                                }
                            }
                            else
                            {
                                if (chkStcApproved.Checked)
                                    chkStcApproved.Enabled = false;
                            }
                        }
                        else
                        {
                            if (chkStcApproved.Checked)
                                chkStcApproved.Enabled = false;
                        }

                        if ((ApprovedDone == true) || (FitsNotRequest == true))
                        {
                            e.Row.Cells[3].Enabled = false;
                            e.Row.Cells[5].Enabled = false;
                            e.Row.Cells[6].Enabled = false;
                            e.Row.Cells[3].CssClass = "cellback";
                            e.Row.Cells[4].CssClass = "cellback";
                            e.Row.Cells[5].CssClass = "cellback";
                            e.Row.Cells[6].CssClass = "cellback";
                            e.Row.Cells[7].CssClass = "cellback";
                            fitsUpload.Enabled = false;
                            SampleUpload.Enabled = false;
                            //fitsUpload_New.Enabled = false;
                            SampleUpload_New.Enabled = false;
                            chkStcApproved.Enabled = false;
                            ddlFits.Enabled = false;
                            ChkRefSample.Enabled = false;
                            ChkSample.Enabled = false;
                            btnSubmit.Visible = false;
                        }
                    }
                    if ((IsBiplUser == true) && (IsIkandiClient == 0) && (FitsType == 0))
                    {
                        if ((Status != "Sampling") && (Status != "Buying Sample"))
                        {
                            if (RequestDone == true)
                            {
                                chkStcApproved.Enabled = false;

                                if (ChkHandover.Checked == false)
                                    ChkHandover.Enabled = true;

                                if (ChkHandover.Checked)
                                    ChkPattern.Enabled = true;
                                else
                                    ChkPattern.Enabled = false;

                                if (ChkPattern.Checked)
                                {
                                    ChkPattern.Enabled = false;
                                    if (IscostingWithPattern == false)
                                    ChkSample.Enabled = true;
                                    else
                                        ChkSample.Enabled = false;
                                }
                                else
                                    ChkSample.Enabled = false;

                                if (ChkSample.Checked)
                                    ChkSample.Enabled = false;

                                if (FitsStatus == "Stc")
                                {
                                    if (ChkPattern.Checked)
                                    {
                                        chkStcApproved.Enabled = true;
                                        chkStcApproved.Checked = true;
                                        if (ChkRefSample.Checked == false)
                                        {
                                            ChkSample.Enabled = false;
                                        }
                                    }
                                    else
                                    {
                                        if (chkStcApproved.Checked)
                                            chkStcApproved.Enabled = false;
                                    }
                                }
                                else
                                {
                                    if (chkStcApproved.Checked)
                                        chkStcApproved.Enabled = false;
                                }

                                if (hlkFitsUpload.Visible == true)
                                {
                                    fitsUpload.Enabled = false;
                                    ddlFits.Enabled = false;
                                }
                                //if (hlkFitsUpload_New.Visible == true)
                                //{
                                //    fitsUpload_New.Enabled = false;
                                //}
                            }
                            else
                            {
                                ddlFits.Enabled = true;
                                fitsUpload.Enabled = true;
                                //fitsUpload_New.Enabled = true;
                                fitsIndex = GetFitsIndex(DataBinder.Eval(e.Row.DataItem, "FitsStatus").ToString());
                                fitsIndex = fitsIndex + 1;
                                ddlFits.SelectedIndex = fitsIndex;
                                ddlQC.Enabled = false;
                                hlkFitsUpload.Visible = false;
                                hlkFitsUpload_New.Visible = false;
                                ChkHandover.Enabled = false;
                                ChkPattern.Enabled = false;
                                ChkSample.Enabled = false;
                                chkStcApproved.Enabled = false;
                                lblFitsActDate.Text = "";
                            }
                        }

                    }

                    if ((IsBiplUser == true) && (IsIkandiClient == 0) && (FitsType == 1))
                    {
                        if ((Status != "Sampling") && (Status != "Buying Sample"))
                        {
                            ddlFits.Enabled = true;
                            fitsUpload.Enabled = true;
                            //fitsUpload_New.Enabled = true;
                            fitsIndex = GetFitsIndex(DataBinder.Eval(e.Row.DataItem, "FitsStatus").ToString());
                            fitsIndex = fitsIndex + 1;
                            ddlFits.SelectedIndex = fitsIndex;
                            ChkIsQC.Enabled = false;
                            ChkHandover.Enabled = false;
                            ChkPattern.Enabled = false;
                            ChkSample.Enabled = false;
                            chkStcApproved.Enabled = false;
                            SampleUpload.Enabled = false;
                            SampleUpload_New.Enabled = false;
                            ddlQC.Enabled = false;
                            lblFitsActDate.Text = "";
                        }

                    }
                }

                if (lblHandoverActDate.Text == "")
                {
                    e.Row.Cells[5].BackColor = System.Drawing.Color.Yellow;
                    e.Row.Cells[6].BackColor = System.Drawing.Color.White;
                    e.Row.Cells[7].BackColor = System.Drawing.Color.White;
                    e.Row.Cells[4].BackColor = System.Drawing.Color.White;
                }
                else
                {
                    if (lblPatternActDate.Text == "")
                    {
                        e.Row.Cells[6].BackColor = System.Drawing.Color.Yellow;
                        e.Row.Cells[5].BackColor = System.Drawing.Color.White;
                        e.Row.Cells[7].BackColor = System.Drawing.Color.White;
                        e.Row.Cells[4].BackColor = System.Drawing.Color.White;
                    }
                    else
                    {
                        if (lblSampleActDate.Text == "")
                        {
                            e.Row.Cells[7].BackColor = System.Drawing.Color.Yellow;
                            e.Row.Cells[6].BackColor = System.Drawing.Color.White;
                            e.Row.Cells[5].BackColor = System.Drawing.Color.White;
                            e.Row.Cells[4].BackColor = System.Drawing.Color.White;
                        }

                    }
                }

                if (lblFitsEta.Text != "" && lblFitsActDate.Text == "")
                {
                    e.Row.Cells[7].BackColor = System.Drawing.Color.White;
                    e.Row.Cells[6].BackColor = System.Drawing.Color.White;
                    e.Row.Cells[5].BackColor = System.Drawing.Color.White;
                    e.Row.Cells[4].BackColor = System.Drawing.Color.Yellow;
                }


                if (RequestStatus.Contains("HandOver"))
                {
                    if (!ChkHandover.Checked)
                    {
                        ChkHandover.Enabled = true;
                    }
                    ChkPattern.Enabled = false;
                    ChkSample.Enabled = false;
                }
                if (RequestStatus.Contains("PatternReady"))
                {
                    if (!ChkPattern.Checked)
                    {
                        ChkPattern.Enabled = true;
                    }
                    ChkHandover.Enabled = false;
                    ChkSample.Enabled = false;
                }
                if (RequestStatus.Contains("SampleSent"))
                {
                    ChkHandover.Enabled = false;
                    ChkPattern.Enabled = false;
                    if (!chkStcApproved.Checked)
                    {
                        if (IscostingWithPattern == false)
                        {
                            ChkSample.Enabled = true;
                            SampleUpload.Enabled = true;
                            SampleUpload_New.Enabled = true;
                        }
                        else
                        {
                            ChkSample.Enabled = false;
                            SampleUpload.Enabled = false;
                            SampleUpload_New.Enabled = false;
                        }
                    }
                }
                if (ViewState["Save"] != null)
                {
                    if (ViewState["Save"].ToString() == "1")
                    {
                        e.Row.Cells[3].Enabled = false;
                        e.Row.Cells[5].Enabled = false;
                        e.Row.Cells[6].Enabled = false;
                        e.Row.Cells[3].CssClass = "cellback";
                        e.Row.Cells[4].CssClass = "cellback";
                        e.Row.Cells[5].CssClass = "cellback";
                        e.Row.Cells[6].CssClass = "cellback";
                        e.Row.Cells[7].CssClass = "cellback";
                        //fitsUpload.Enabled = false;
                        SampleUpload.Enabled = false;
                        //fitsUpload_New.Enabled = false;
                        SampleUpload_New.Enabled = false;
                        chkStcApproved.Enabled = false;
                        ddlFits.Enabled = false;
                        //ChkRefSample.Enabled = false;
                        ChkSample.Enabled = false;
                        btnSubmit.Visible = false;

                    }
                }

            }

        }

        protected void gvSamplingFitsCycleflow_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void ddlFits_SelectedIndexChanged(Object sender, EventArgs e)
        {
            DropDownList ddlFits = (DropDownList)sender;
            GridViewRow row = (GridViewRow)ddlFits.NamingContainer;
            string status = ((DropDownList)sender).SelectedItem.Text;

            //CheckBox ChkRefSample = (CheckBox)row.FindControl("ChkRefSample");
            //if (status == "Stc")
            //    ChkRefSample.Enabled = true;
            //else
            //    ChkRefSample.Enabled = false;
        }

        protected void ChkIsQC_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox ChkIsQC = (CheckBox)sender;
            GridViewRow row = (GridViewRow)ChkIsQC.NamingContainer;
            DropDownList ddlQC = (DropDownList)row.FindControl("ddlQC");
            if (ChkIsQC.Checked)
            {
                ddlQC.Enabled = true;
            }
            else
            {
                ddlQC.Enabled = false;
                ddlQC.SelectedValue = "Select";
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            SamplePattern objSample = new SamplePattern();
            int FitsType = 0;
            string sSave = "";
            ReUseStyleId = Convert.ToInt32(hdnReUseStyleId.Value);
            ReUse = Convert.ToInt32(hdnFitsReUse.Value);
            foreach (GridViewRow gvr in gvSamplingFitsCycleflow.Rows)
            {
                HiddenField hdngvStyleId = (HiddenField)gvr.FindControl("hdngvStyleId");
                HiddenField hdnIsIkandiClient = (HiddenField)gvr.FindControl("hdnIsIkandiClient");
                CheckBox ChkIsQC = (CheckBox)gvr.FindControl("ChkIsQC");
                DropDownList ddlQC = (DropDownList)gvr.FindControl("ddlQC");
                //Label lblStatus = (Label)gvr.FindControl("lblStatus");
                HiddenField hdnStatus = (HiddenField)gvr.FindControl("hdnStatus");
                Label lblFits = (Label)gvr.FindControl("lblFits");
                HiddenField hdnFits = (HiddenField)gvr.FindControl("hdnFits");
                DropDownList ddlFits = (DropDownList)gvr.FindControl("ddlFits");
                CheckBox ChkRefSample = (CheckBox)gvr.FindControl("ChkRefSample");
                FileUpload fitsUpload = (FileUpload)gvr.FindControl("fitsUpload");
                FileUpload fitsUpload_New = (FileUpload)gvr.FindControl("fitsUpload_New");

                CheckBox ChkHandover = (CheckBox)gvr.FindControl("ChkHandover");
                CheckBox ChkPattern = (CheckBox)gvr.FindControl("ChkPattern");
                CheckBox ChkSample = (CheckBox)gvr.FindControl("ChkSample");
                FileUpload SampleUpload = (FileUpload)gvr.FindControl("SampleUpload");
                FileUpload SampleUpload_New = (FileUpload)gvr.FindControl("SampleUpload_New");


                CheckBox chkStcApproved = (CheckBox)gvr.FindControl("chkStcApproved");
                TextBox txtComment = (TextBox)gvr.FindControl("txtComment");
                HiddenField hdnFitsType = (HiddenField)gvr.FindControl("hdnFitsType");
                HiddenField hdnClientId = (HiddenField)gvr.FindControl("hdnClientId");
                HiddenField hdnClientDeptid = (HiddenField)gvr.FindControl("hdnClientDeptid");
                HiddenField hdnIsOrderExist = (HiddenField)gvr.FindControl("hdnIsOrderExist");
                HiddenField hdnIsCostingWithPattern = (HiddenField)gvr.FindControl("hdnIsCostingWithPattern");

                Label lblHandoverActDate = (Label)gvr.FindControl("lblHandoverActDate");
                Label lblPatternActDate = (Label)gvr.FindControl("lblPatternActDate");
                Label lblSampleActDate = (Label)gvr.FindControl("lblSampleActDate");

                HiddenField hdnHandoverActDate = (HiddenField)gvr.FindControl("hdnHandoverActDate");
                HiddenField hdnPatternActDate = (HiddenField)gvr.FindControl("hdnPatternActDate");
                HiddenField hdnStateSelection = (HiddenField)gvr.FindControl("hdnStateSelection");
                
                HiddenField hdnSampleActDate = (HiddenField)gvr.FindControl("hdnSampleActDate");
                RadioButtonList rblHandoversection = (RadioButtonList)gvr.FindControl("rblHandoversection");

                if (hdnFitsType != null)
                    FitsType = Convert.ToInt32(hdnFitsType.Value);

                if (ReUseStyleId != -1)
                    objSample.Styleid = Convert.ToInt32(hdnStyleId.Value);
                else
                    objSample.Styleid = Convert.ToInt32(hdngvStyleId.Value);

                if (hdnIsCostingWithPattern != null)
                    objSample.IsCostingWithPattern = Convert.ToBoolean(hdnIsCostingWithPattern.Value);

                objSample.ClientId = Convert.ToInt32(hdnClientId.Value);
                objSample.ClientDeptid = Convert.ToInt32(hdnClientDeptid.Value);
                objSample.PDDecesion = rblHandoversection.SelectedValue;
                objSample.Status = ddlFits.SelectedValue;
                objSample.IsIkandiClient = Convert.ToInt32(hdnIsIkandiClient.Value);
                objSample.FitsSentFor = "";
                objSample.FitsPlanningFor = "";
                objSample.FitsCommentUpload = "";
                objSample.SampleUpload = "";
                objSample.FitsCommentUpload_New = "";
                objSample.SampleUpload_New = "";
                objSample.Commentes = "";

                if (ddlFits.SelectedIndex < Convert.ToInt32(hdnStateSelection.Value))
                {
                    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "scr", "jQuery.facebox('Later stage can not less then intial Stage');", true);
                    ddlFits.Focus();
                    ddlFits.SelectedIndex = Convert.ToInt32(hdnStateSelection.Value);
                    return;
                }
                else
                {
                    if (hdnFits.Value != ddlFits.SelectedValue)
                    {
                        Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "scr", "jQuery.facebox('Later Stage Should be In Sequence.');", true);
                        ddlFits.Focus();
                        ddlFits.SelectedIndex = Convert.ToInt32(hdnStateSelection.Value);
                        return; 
                    }
                }
                if (txtComment.Text != "")
                {
                    string sRemark = txtComment.Text.ToString();
                    sRemark = sRemark.Replace("<", " ");
                    sRemark = sRemark.Replace(">", " ");
                    sRemark = sRemark.Replace("~", " ");
                    sRemark = ApplicationHelper.LoggedInUser.UserData.FirstName + " (" + DateTime.Now.ToString("dd MMM") + ") : " + sRemark;
                    objSample.Commentes = sRemark;
                }

                objSample.IsHandOver = ChkHandover.Checked;
                objSample.IsPatternReady = ChkPattern.Checked;
                objSample.IsSampleSent = ChkSample.Checked;

                if (lblHandoverActDate.Text == "")
                {

                    if (ChkHandover.Enabled == true)
                        objSample.HandOverActDate = DateTime.Now.Date;
                    else
                        objSample.HandOverActDate = DateTime.MinValue;
                }
                else
                {
                    objSample.HandOverActDate = DateTime.ParseExact(hdnHandoverActDate.Value, "dd MMM yy", System.Globalization.CultureInfo.InvariantCulture);
                }

                if (lblPatternActDate.Text == "")
                {
                    if (ChkPattern.Enabled == true)
                        objSample.PatternReadyActualDate = DateTime.Now.Date;
                    else
                        objSample.PatternReadyActualDate = DateTime.MinValue;
                }
                else
                {
                    objSample.PatternReadyActualDate = DateTime.ParseExact(hdnPatternActDate.Value, "dd MMM yy", System.Globalization.CultureInfo.InvariantCulture);
                }

                if (lblSampleActDate.Text == "")
                {
                    if (ChkSample.Enabled == true)
                        objSample.SampleSentActualDate = DateTime.Now.Date;
                    else
                        objSample.SampleSentActualDate = DateTime.MinValue;
                }
                else
                {
                    objSample.SampleSentActualDate = DateTime.ParseExact(hdnSampleActDate.Value, "dd MMM yy", System.Globalization.CultureInfo.InvariantCulture);
                }
                //if (objSample.Status == "Sampling")
                //{
                    if (ChkIsQC.Enabled == true)
                    {
                        objSample.IsQCPresent = ChkIsQC.Checked;
                        if (ChkIsQC.Checked)
                            objSample.QCMasterId = Convert.ToInt32(ddlQC.SelectedItem.Value);
                    }
                    if (SampleUpload.HasFile)
                    {
                        objSample.SampleUpload = SaveUploadedFile(SampleUpload, "");
                    }
                    if (SampleUpload_New.HasFile)
                    {
                        objSample.SampleUpload_New = SaveUploadedFile(SampleUpload_New, "");
                    }
                    if (fitsUpload_New.HasFile)
                    {
                        objSample.FitsCommentUpload_New = SaveUploadedFile(fitsUpload_New, "");
                    }
                    if (hdnFits.Value == "Sampling 10")
                    {
                        if (rblHandoversection.SelectedValue == "0")
                        {
                            Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "scr", "jQuery.facebox('You Must be select finalize with out sample when you select final Cycle');", true);
                            rblHandoversection.Focus();
                            return;
                        }
                       
                    }
                //}

                if (IsBiplUser == true)
                {
                    //if ((objSample.Status == "Sampling") || (objSample.Status == "Buying Sample"))
                    //{
                        if (ChkIsQC.Enabled == true)
                        {
                            objSample.IsQCPresent = ChkIsQC.Checked;
                            if (ChkIsQC.Checked)
                                objSample.QCMasterId = Convert.ToInt32(ddlQC.SelectedItem.Value);
                        }
                        if (SampleUpload.HasFile)
                        {
                            objSample.SampleUpload = SaveUploadedFile(SampleUpload, "");
                        }
                        if (SampleUpload_New.HasFile)
                        {
                            objSample.SampleUpload_New = SaveUploadedFile(SampleUpload_New, "");
                        }
                   
                }
                if ((IsIKandiUser == true) && (objSample.IsIkandiClient == 1))
                {
                    if (ChkIsQC.Enabled == true)
                    {
                        objSample.IsQCPresent = ChkIsQC.Checked;
                        if (ChkIsQC.Checked)
                            objSample.QCMasterId = Convert.ToInt32(ddlQC.SelectedItem.Value);
                    }
                    if (ChkRefSample.Enabled == true)
                        objSample.ReqRefSample = ChkRefSample.Checked;

                    objSample.FitsSentFor = hdnFits.Value;
                    objSample.FitsPlanningFor = ddlFits.SelectedItem.Text;

                    if (fitsUpload.HasFile)
                    {
                        objSample.FitsCommentUpload = SaveUploadedFile(fitsUpload, "");
                    }
                    if (fitsUpload_New.HasFile)
                    {
                        objSample.FitsCommentUpload_New = SaveUploadedFile(fitsUpload_New, "");
                    }

                    if (ReUseStyleId == -1)
                    {
                        if (fitsUpload.HasFile == false)
                        {
                            Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "scr", "jQuery.facebox('Please upload fits');", true);
                            fitsUpload.Focus();
                            return;
                        }
                    }
                }

                // Save data
                sSave = FITsControllerInstance.SaveSamplingFitsCycleFlow_PreOrder(objSample, Convert.ToInt32(UserId), IsBiplUser, IsIKandiUser, ReUse, ReUseStyleId);
                if (sSave != "")
                {
                    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "scr", "jQuery.facebox('Some error occured due to " + sSave + "');", true);
                    return;
                }
                // This logic has been implemented on Order confirm by Ravi kumar

                //bool bCheckOrderExistAndSamplingStatus = WorkflowControllerInstance.CheckOrderExistAndSamplingStatus(objSample.Styleid);
                //if (bCheckOrderExistAndSamplingStatus == true)
                //{
                //    hdnIsOrderExist.Value = "True";
                //    this.WorkflowControllerInstance.UpdatePreOrderToPostOrder_ForSampling(objSample.Styleid);

                //}
                // Edit by surendra for Fits flow for pre order

                if ((ChkHandover.Enabled == true) && (ChkHandover.Checked))
                {
                    //if (hdnIsOrderExist.Value == "False")
                    this.WorkflowControllerInstance.Update_PreOrder_Fits_Cycle(objSample.Styleid, "Handover", objSample.Status, rblHandoversection.SelectedValue, Convert.ToInt32(UserId));
                        //this.WorkflowControllerInstance.UpdateWorkflowInstancePreOrder(objSample.Styleid, TaskMode.HandOver, Convert.ToInt32(UserId));
                    //else
                    //    this.WorkflowControllerInstance.UpdateWorkflowInstancePostOrder_Style_Order_Basis(objSample.Styleid, 0, TaskMode.HandOver, Convert.ToInt32(UserId));

                }
                // PREORDER
                //if (hdnIsOrderExist.Value == "False")
                //{
                    if ((ChkPattern.Enabled == true) && (ChkPattern.Checked))
                    {
                        this.WorkflowControllerInstance.Update_PreOrder_Fits_Cycle(objSample.Styleid, "PatternReady", objSample.Status, rblHandoversection.SelectedValue, Convert.ToInt32(UserId));
                        //if (objSample.IsCostingWithPattern == true)
                        //{
                        //    // Write code for work flow of pattern ready done and not create further task
                        //    this.WorkflowControllerInstance.UpdateWorkflow_PatternReady(objSample.Styleid, TaskMode.Pattern_Ready, Convert.ToInt32(UserId));
                        //}
                        //else
                        //{
                        //    this.WorkflowControllerInstance.UpdateWorkflowInstancePreOrder(objSample.Styleid, TaskMode.Pattern_Ready, Convert.ToInt32(UserId));
                        //}
                    }
                //}
                //else
                //{
                //    //POST ORDER
                //    if ((ChkPattern.Enabled == true) && (ChkPattern.Checked))
                //    {
                //        bool BcheckIsGrading = this.FITsControllerInstance.BcheckIsGrading(objSample.Styleid);
                //        this.WorkflowControllerInstance.UpdateWorkflowInstancePostOrder_Style_Order_Basis(objSample.Styleid, 0, TaskMode.Pattern_Ready, Convert.ToInt32(UserId));
                //        if ((BcheckIsGrading == true))
                //            this.WorkflowControllerInstance.DeleteUnnessaryFits_UploadComentesTask(objSample.Styleid, TaskMode.Fits_SampleSent);
                //    }
                //}

                if ((ChkSample.Enabled == true) && (ChkSample.Checked))
                {
                    //if (hdnIsOrderExist.Value == "False")
                    //{
                        this.WorkflowControllerInstance.UpdateWorkflowInstancePreOrder(objSample.Styleid, TaskMode.Fits_SampleSent, Convert.ToInt32(UserId));

                        //if (objSample.Status == "Sampling")
                            this.WorkflowControllerInstance.DeleteUnnessaryFits_UploadComentesTask(objSample.Styleid, TaskMode.FitsCommentes_Upload);
                    //}
                    //else
                    //    this.WorkflowControllerInstance.UpdateWorkflowInstancePostOrder_Style_Order_Basis(objSample.Styleid, 0, TaskMode.Fits_SampleSent, Convert.ToInt32(UserId));

                }
                //if ((chkStcApproved.Enabled == true) && (chkStcApproved.Checked))
                //{
                //    if (hdnIsOrderExist.Value == "True")
                //    {
                //        int iResult = this.WorkflowControllerInstance.UpdateWorkflowInstancePostOrder_Style_Order_Basis(objSample.Styleid, 0, TaskMode.Sealed_To_Cut, Convert.ToInt32(UserId));
                //        this.WorkflowControllerInstance.DeleteUnnessaryFits_UploadComentesTask(objSample.Styleid, TaskMode.FitsCommentes_Upload);
                //        this.WorkflowControllerInstance.DeleteUnnessaryFits_UploadComentesTask(objSample.Styleid, TaskMode.HandOver);
                //    }
                //}

            }
            if (sSave == "")
            {
            //    // Comment for Reuse
            //    if (ReUseStyleId == -1)
            //    {
            //        bool ReUseSave = FITsControllerInstance.ReUseSamplingFitsCycleFlow(objSample.Styleid, ReUse, Convert.ToInt32(UserId), objSample.Status);
            //    }
               Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "scr", "jQuery.facebox('Data has been saved successfully!');", true);
            }

            ViewState["Save"] = "1";

            GetSamplingFitsCycleFlow_PreOrder();
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

        private int GetFitsIndex(string FitsStatus)
        {
            switch (FitsStatus)
            {
                case "Buying Sample":
                    return -1;
                case "sampling 1":
                    return 0;
                case "Sampling 2":
                    return 1;
                case "Sampling 3":
                    return 2;
                case "Sampling 4":
                    return 3;
                case "Sampling 5":
                    return 4;
                case "Sampling 6":
                    return 5;
                case "Sampling 7":
                    return 6;
                case "Sampling 8":
                    return 7;
                case "Sampling 9":
                    return 8;
                case "Sampling 10":
                    return 9;
                
                

            }
            return 0;
        }

        protected void gvSamplingFitsCycleflow_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvSamplingFitsCycleflow.PageIndex = e.NewPageIndex;
            GetSamplingFitsCycleFlow_PreOrder();
        }
        protected void ddlparentDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ClientID = 0;
            int ParentSelectedVal = 0;
            if (ddlClientNameSelect.SelectedValue == "Select" || ddlClientNameSelect.SelectedValue == "")
                ClientID = -1;
            else
                ClientID = Convert.ToInt16(ddlClientNameSelect.SelectedValue);

            if (ddlparentDept.SelectedValue == "Select" || ddlparentDept.SelectedValue == "")
                ParentSelectedVal = -1;
            else
                ParentSelectedVal = Convert.ToInt16(ddlparentDept.SelectedValue);

            List<SamplePattern> objSamplePattern = FITsControllerInstance.Get_ClientDeptsParent(ClientID, "SubParent", ParentSelectedVal);
            if (objSamplePattern.Count > 0)
            {
                ddlDeptNameSelect.Items.Clear();
                ddlDeptNameSelect.DataSource = objSamplePattern;
                ddlDeptNameSelect.DataTextField = "DeptName";
                ddlDeptNameSelect.DataValueField = "ClientDeptid";
                ddlDeptNameSelect.DataBind();
                ddlDeptNameSelect.Items.Insert(0, "Select");
            }
            else
            {
                ddlDeptNameSelect.Items.Clear();
                ddlDeptNameSelect.Items.Insert(0, "Select");

            }

        }
    }
}