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
using System.Web.Services;

namespace iKandi.Web.UserControls.Lists
{
    public partial class SamplingFitsCycleHistory_PreOrder : BaseUserControl
    {
        int Userid = iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.UserID;
        String FitsFolderPath = "/" + System.Configuration.ConfigurationManager.AppSettings["fits.docs.folder"];
        public int StyleId
        {
            get;
            set;
        }
       

        public string UserId = "0";

        public string TopDesignation = "0";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                hdnStyleId.Value = Convert.ToString(StyleId);
                //hdnPPStatus.Value = Convert.ToString(PPStatus);
                //hdnOrderDetailID.Value = Convert.ToString(OrderDetailID);

                GetSamplingFitsCycleHistory();
                BindSamplingFitsCycle();
                //if (PPStatus == 1)
                //{
                //    hLinkTOPSent.Visible = true;
                //}

                //if (MoOpen == 1)
                //{
                //    hlnkflow.Visible = true;
                //}
                bool BchekPreordersampling = FITsControllerInstance.IsShowPre_Order_Sampling(StyleId);
                if (BchekPreordersampling == true)
                    hlnkflow.Visible = true;
                else
                    hlnkflow.Visible = false;
            }
            if (ApplicationHelper.LoggedInUser.UserData.Designation == Designation.iKandi_TopManagement_Manager)
            {
                TopDesignation = "1";
            }
            UserId = ApplicationHelper.LoggedInUser.UserData.UserID.ToString();
        }
        private void GetSamplingFitsCycleHistory()
        {
            if (StyleId != -1)
            {
                List<SamplePattern> objSamplePattern = FITsControllerInstance.GetSamplingFitsCycleHistory_ForPreOrder(StyleId);
                gvSamplingFitsCycleHistory.DataSource = objSamplePattern;
                gvSamplingFitsCycleHistory.DataBind();

                if (objSamplePattern.Count > 0)
                {
                    lblStyleNo.Text = objSamplePattern[0].StyleNumber;
                    lblCreation_FitsDate.Text = Convert.ToDateTime(objSamplePattern[0].CreatedOn) == DateTime.MinValue ? "" : (objSamplePattern[0].CreatedOn).ToString("dd MMM");
                    lblAM.Text = objSamplePattern[0].AcountMgrName;
                    lblPDM.Text = objSamplePattern[0].PD_MarchentName;
                    lblFabric1.Text = objSamplePattern[0].Fabric;
                    lblColorPrint.Text = objSamplePattern[0].FabricDetails;
                    lblClient.Text = objSamplePattern[0].ClientName;
                    lblDepartment.Text = objSamplePattern[0].DeptName;
                    lblSTCTargetDate.Text = Convert.ToDateTime(objSamplePattern[0].StcEta) == DateTime.MinValue ? "" : (objSamplePattern[0].StcEta).ToString("dd MMM");
                    string SketchUrl = objSamplePattern[0].SketchUrl;
                    if (SketchUrl != "")
                    {
                        ImgStyle.ImageUrl = "/Uploads/Style/thumb-" + SketchUrl;
                        ImgStyle.ImageAlign = ImageAlign.Middle;
                    }
                }
               

                
            }

        }
        protected void gvSamplingFitsCycleHistory_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //int FitsType = 0;

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
               

                Label lblStatus = (Label)e.Row.FindControl("lblStatus");

                Label lblFitsRequest = (Label)e.Row.FindControl("lblFitsRequest");


                Label lblSampleSentDate = (Label)e.Row.FindControl("lblSampleSentDate");
                lblSampleSentDate.Text = Convert.ToDateTime(DataBinder.Eval(e.Row.DataItem, "SampleSentDate")) == DateTime.MinValue ? "" : Convert.ToDateTime(DataBinder.Eval(e.Row.DataItem, "SampleSentDate")).ToString("dd MMM");

                CheckBox ChkIsQC = (CheckBox)e.Row.FindControl("ChkIsQC");
                ChkIsQC.Checked = Convert.ToBoolean(DataBinder.Eval(e.Row.DataItem, "IsQCPresent"));

                CheckBox ChkRefSample = (CheckBox)e.Row.FindControl("ChkRefSample");
                Label lblFitsEta = (Label)e.Row.FindControl("lblFitsEta");
                Label lblFitsCommentSent = (Label)e.Row.FindControl("lblFitsCommentSent");
                Label lblFitsActDate = (Label)e.Row.FindControl("lblFitsActDate");
                CheckBox chkStcApproved = (CheckBox)e.Row.FindControl("chkStcApproved");

                HiddenField hdnMasterQCId = (HiddenField)e.Row.FindControl("hdnMasterQCId");
                Label lblQC = (Label)e.Row.FindControl("lblQC");
                HyperLink hlkFitsUpload = (HyperLink)e.Row.FindControl("hlkFitsUpload");
                HyperLink hlkFitsUploadNew = (HyperLink)e.Row.FindControl("hlkFitsUploadNew");

                if (hdnMasterQCId.Value != "-1")
                {
                    lblQC.Text = DataBinder.Eval(e.Row.DataItem, "CQDName").ToString();
                   // lblQC.Text = "fhfgjgfkjhgkghkfg";
                }

                //Fits Section
                HtmlGenericControl dvFits = (HtmlGenericControl)e.Row.FindControl("dvFits");
                HtmlGenericControl dvSampling = (HtmlGenericControl)e.Row.FindControl("dvSampling");

                string Status = DataBinder.Eval(e.Row.DataItem, "Status").ToString();
                string FitsStatus = DataBinder.Eval(e.Row.DataItem, "FitsStatus").ToString();



                if ((Status == "Sampling") || (Status == "Buying Sample"))
                {
                    dvFits.Style.Add("display", "none");
                    dvSampling.Style.Add("display", "block");
                    dvSampling.InnerHtml = Status;
                }
                else
                {
                    dvFits.Style.Add("display", "block");
                    dvSampling.Style.Add("display", "none");
                    dvSampling.InnerHtml = "";
                    lblFitsCommentSent.Text = FitsStatus;

                    if (DataBinder.Eval(e.Row.DataItem, "FitsStatus").ToString() != "")
                        lblFitsRequest.Text = "Request For " + DataBinder.Eval(e.Row.DataItem, "FitsStatus").ToString();

                    ChkRefSample.Checked = Convert.ToBoolean(DataBinder.Eval(e.Row.DataItem, "ReqRefSample"));


                    string BiplFilePath = DataBinder.Eval(e.Row.DataItem, "BiplFilePath").ToString();
                    string FilePath = DataBinder.Eval(e.Row.DataItem, "FitsCommentUpload").ToString();

                    hlkFitsUpload.Visible = (string.IsNullOrEmpty(DataBinder.Eval(e.Row.DataItem, "FitsCommentUpload").ToString())) ? false : true;
                    hlkFitsUpload.NavigateUrl = (string.IsNullOrEmpty(DataBinder.Eval(e.Row.DataItem, "FitsCommentUpload").ToString())) ? "" : FitsFolderPath + DataBinder.Eval(e.Row.DataItem, "FitsCommentUpload").ToString();

                    hlkFitsUploadNew.Visible = (string.IsNullOrEmpty(DataBinder.Eval(e.Row.DataItem, "FitsCommentUpload_New").ToString())) ? false : true;
                    hlkFitsUploadNew.NavigateUrl = (string.IsNullOrEmpty(DataBinder.Eval(e.Row.DataItem, "FitsCommentUpload_New").ToString())) ? "" : FitsFolderPath + DataBinder.Eval(e.Row.DataItem, "FitsCommentUpload_New").ToString();


                    lblFitsEta.Text = Convert.ToDateTime(DataBinder.Eval(e.Row.DataItem, "FitsETADate")) == DateTime.MinValue ? "" : Convert.ToDateTime(DataBinder.Eval(e.Row.DataItem, "FitsETADate")).ToString("dd MMM");

                    lblFitsActDate.Text = Convert.ToDateTime(DataBinder.Eval(e.Row.DataItem, "FitsActualDate")) == DateTime.MinValue ? "" : Convert.ToDateTime(DataBinder.Eval(e.Row.DataItem, "FitsActualDate")).ToString("dd MMM");

                    chkStcApproved.Visible = true;

                    chkStcApproved.Checked = Convert.ToBoolean(DataBinder.Eval(e.Row.DataItem, "StcApproved"));

                    string FitsCommentSent = DataBinder.Eval(e.Row.DataItem, "FitsCommentSentFor").ToString();
                    if (FitsCommentSent != "")
                        lblFitsCommentSent.Text = "Fits Comments For " + FitsCommentSent;

                }

                // Hand Over Section
                Label lblHandoverEta = (Label)e.Row.FindControl("lblHandoverEta");
                lblHandoverEta.Text = Convert.ToDateTime(DataBinder.Eval(e.Row.DataItem, "HandOverEta")) == DateTime.MinValue ? "" : Convert.ToDateTime(DataBinder.Eval(e.Row.DataItem, "HandOverEta")).ToString("dd MMM");

                Label lblHandoverActDate = (Label)e.Row.FindControl("lblHandoverActDate");
                lblHandoverActDate.Text = Convert.ToDateTime(DataBinder.Eval(e.Row.DataItem, "HandOverActDate")) == DateTime.MinValue ? "" : Convert.ToDateTime(DataBinder.Eval(e.Row.DataItem, "HandOverActDate")).ToString("dd MMM");

                CheckBox ChkHandover = (CheckBox)e.Row.FindControl("ChkHandover");
                ChkHandover.Checked = Convert.ToBoolean(DataBinder.Eval(e.Row.DataItem, "IsHandOver"));

                ChkHandover.Enabled = false;

                // Pattern Ready Section
                Label lblPatternEta = (Label)e.Row.FindControl("lblPatternEta");
                lblPatternEta.Text = Convert.ToDateTime(DataBinder.Eval(e.Row.DataItem, "PatterntEta")) == DateTime.MinValue ? "" : Convert.ToDateTime(DataBinder.Eval(e.Row.DataItem, "PatterntEta")).ToString("dd MMM");

                Label lblPatternActDate = (Label)e.Row.FindControl("lblPatternActDate");
                lblPatternActDate.Text = Convert.ToDateTime(DataBinder.Eval(e.Row.DataItem, "PatternReadyActualDate")) == DateTime.MinValue ? "" : Convert.ToDateTime(DataBinder.Eval(e.Row.DataItem, "PatternReadyActualDate")).ToString("dd MMM");

                CheckBox ChkPattern = (CheckBox)e.Row.FindControl("ChkPattern");
                ChkPattern.Checked = Convert.ToBoolean(DataBinder.Eval(e.Row.DataItem, "IsPatternReady"));

                ChkPattern.Enabled = false;

                // Sample Sent Section
                Label lblSampleEta = (Label)e.Row.FindControl("lblSampleEta");
                lblSampleEta.Text = Convert.ToDateTime(DataBinder.Eval(e.Row.DataItem, "SampleSentEta")) == DateTime.MinValue ? "" : Convert.ToDateTime(DataBinder.Eval(e.Row.DataItem, "SampleSentEta")).ToString("dd MMM");

                Label lblSampleActDate = (Label)e.Row.FindControl("lblSampleActDate");
                lblSampleActDate.Text = Convert.ToDateTime(DataBinder.Eval(e.Row.DataItem, "SampleSentActualDate")) == DateTime.MinValue ? "" : Convert.ToDateTime(DataBinder.Eval(e.Row.DataItem, "SampleSentActualDate")).ToString("dd MMM");

                CheckBox ChkSample = (CheckBox)e.Row.FindControl("ChkSample");
                ChkSample.Checked = Convert.ToBoolean(DataBinder.Eval(e.Row.DataItem, "IsSampleSent"));

                ChkSample.Enabled = false;

                HyperLink hlkSampleUpload = (HyperLink)e.Row.FindControl("hlkSampleUpload");
                hlkSampleUpload.Visible = (string.IsNullOrEmpty(DataBinder.Eval(e.Row.DataItem, "SampleUpload").ToString())) ? false : true;
                hlkSampleUpload.NavigateUrl = (string.IsNullOrEmpty(DataBinder.Eval(e.Row.DataItem, "SampleUpload").ToString())) ? "" : FitsFolderPath + DataBinder.Eval(e.Row.DataItem, "SampleUpload").ToString();

                HyperLink hlkHandover = (HyperLink)e.Row.FindControl("hlkHandover");
                hlkHandover.Visible = (string.IsNullOrEmpty(DataBinder.Eval(e.Row.DataItem, "HandoverFileUpload").ToString())) ? false : true;
                hlkHandover.NavigateUrl = (string.IsNullOrEmpty(DataBinder.Eval(e.Row.DataItem, "HandoverFileUpload").ToString())) ? "" : FitsFolderPath + DataBinder.Eval(e.Row.DataItem, "HandoverFileUpload").ToString();

                HyperLink hlkSampleUploadNew = (HyperLink)e.Row.FindControl("hlkSampleUploadNew");
                hlkSampleUploadNew.Visible = (string.IsNullOrEmpty(DataBinder.Eval(e.Row.DataItem, "SampleUpload_New").ToString())) ? false : true;
                hlkSampleUploadNew.NavigateUrl = (string.IsNullOrEmpty(DataBinder.Eval(e.Row.DataItem, "SampleUpload_New").ToString())) ? "" : FitsFolderPath + DataBinder.Eval(e.Row.DataItem, "SampleUpload_New").ToString();

                Label lblComment = (Label)e.Row.FindControl("lblComment");
                string sComment = DataBinder.Eval(e.Row.DataItem, "Commentes").ToString();
                if (sComment != "")
                {
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

                if (Status != "Sampling")
                {
                    if (lblSampleActDate.Text != "")
                    {
                        DateTime SampleActDate = Convert.ToDateTime(DataBinder.Eval(e.Row.DataItem, "SampleSentActualDate"));
                        DateTime HandOverActDate = Convert.ToDateTime(DataBinder.Eval(e.Row.DataItem, "HandOverActDate"));
                        var DiffDate = (SampleActDate - HandOverActDate).TotalDays;
                        var weekCalc = Convert.ToDecimal(DiffDate / 7).ToString("#,##0.0");
                        Label lblFitCycleTime = (Label)e.Row.FindControl("lblFitCycleTime");
                        if (DiffDate == 0)
                        {
                            lblFitCycleTime.Text = "";
                        }
                        else
                        {
                            lblFitCycleTime.Text = Convert.ToString(DiffDate) + " (" + weekCalc + " )";
                        }


                        //int DaysDiff = DateTime.
                    }
                }
                //e.Row.Cells[3].Enabled = false;  
                //e.Row.Cells[6].Enabled = false;            
                ////e.Row.Cells[3].CssClass = "cellback";
                ////e.Row.Cells[4].CssClass = "cellback";
                //e.Row.Cells[5].CssClass = "cellback";
                //e.Row.Cells[6].CssClass = "cellback";
                //hlkSampleUpload.Enabled = true;

                ChkRefSample.Enabled = false;
                ChkSample.Enabled = false;
                chkStcApproved.Enabled = false;

            }
        }
        public void BindSamplingFitsCycle()
        {
            DataSet ds = FITsControllerInstance.GetSamplingFitsCycleForHistory(StyleId);
            DataTable dt = ds.Tables[0];
            DataTable dtStcApproved = ds.Tables[1];
            if (dtStcApproved.Rows.Count > 0)
            {
                if (dtStcApproved.Rows[0]["StcApproved"].ToString() == "0")
                {
                    divpattern.Visible = false;
                    hyplnkEditRequestSample.Visible = false;
                }
            }
            for (int i = dt.Rows.Count - 1; i >= 0; i--)
            {
                DataRow dr = dt.Rows[i];
                if (dr["ReqSample"].ToString() == "Select")
                    dr.Delete();
            }
            grdsamplebefore.DataSource = dt;
            grdsamplebefore.DataBind();

        }
        protected void grdsamplebefore_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                
            }
        }   
    }
}