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

using iKandi.Common;
using System.Collections.Generic;
using iKandi.Web.Components;

namespace iKandi.Web
{
    public partial class FITsForm : BaseUserControl
    {
        #region Fields

        public List<iKandi.Common.Order> objOrderCollection;
        public List<iKandi.Common.OrderDetail> objOrderDetailCollection;
        public iKandi.Common.Fits objFits;
        String FitsFolderPath = "~/" + System.Configuration.ConfigurationManager.AppSettings["fits.docs.folder"];
        Boolean isNewRow = false;
        public Int32 intIndex = 0;
        public Int32 intOrderDetailCount = 0;
        public int prevReqIndex = -1;
        public DateTime minStcDate = DateTime.MaxValue;
        public DateTime minOrderDate = DateTime.MaxValue;
        public DateTime trackingDate = DateTime.MaxValue;
        public static bool isBiplAllowed = false;

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
                _biplUser = (ApplicationHelper.LoggedInUser.UserData.Designation == Designation.BIPL_Merchandising_FitMerchant);
                return _biplUser;
            }
        }

        #endregion

        #region Properties

        private string StyleCodeVersion
        {
            get
            {
                if (null != Request.QueryString["StyleCodeVersion"])
                {
                    return Request.QueryString["StyleCodeVersion"].ToString();
                }
                return string.Empty;
            }
        }


        private ClientDepartment clientDepartment;
        public ClientDepartment ClientDepartment
        {
            get { return clientDepartment; }
            set { clientDepartment = value; }
        }

        #endregion

        #region Page Events

        protected void Page_Load(Object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindControls();
            }
        }

        protected void rptFitSection_ItemDataBound(Object sender, RepeaterItemEventArgs e)
        {

            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                if (objFits == null || objFits.Id < 0)
                    return;

                Boolean EnableIKnadiControl = (IsIKandiUser || isBiplAllowed) && isNewRow && !(objFits.IsStcApproved);
                Boolean EnableBiplUserControl = IsBiplUser && !isNewRow && !(objFits.IsStcApproved);

                DropDownList ddlFitsComments = ((DropDownList)e.Item.FindControl("ddlFitsComments"));
                DropDownList ddlRequest = ((DropDownList)e.Item.FindControl("ddlRequest"));
                Label lblFitPlanningFor = ((Label)e.Item.FindControl("lblFitPlanningFor"));
                TextBox txtNextPlannedFitDate = ((TextBox)e.Item.FindControl("txtNextPlannedFitDate"));
                FileUpload fileIkandiUpload = ((FileUpload)e.Item.FindControl("fileIkandiUpload"));
                FileUpload fileBiplUpload = ((FileUpload)e.Item.FindControl("fileBiplUpload"));
                CheckBox chkBoxAcknowledge = ((CheckBox)e.Item.FindControl("chkBoxAcknowledge"));
                Label lblAcknowledge = ((Label)e.Item.FindControl("lblAcknowledge"));
                TextBox txtAckDate = ((TextBox)e.Item.FindControl("txtAckDate"));
                Label txtPlannedDispatchDate = ((Label)e.Item.FindControl("txtPlannedDispatchDate"));
                TextBox txtSuggestedFitDate = ((TextBox)e.Item.FindControl("txtSuggestedFitDate"));
                HyperLink hlkViewMe = ((HyperLink)e.Item.FindControl("hlkViewMe"));
                HyperLink hlkViewMeBipl = ((HyperLink)e.Item.FindControl("hlkViewMeBipl"));
                CheckBox chkBoxReferenceSample = ((CheckBox)e.Item.FindControl("chkBoxReferenceSample"));
                CustomValidator cviKandiFileUpload = ((CustomValidator)e.Item.FindControl("cviKandiFileUpload"));


                if (prevReqIndex > -1)
                {
                    ddlFitsComments.SelectedIndex = prevReqIndex;
                    ddlRequest.SelectedIndex = prevReqIndex + 1;
                    ddlFitsComments.Enabled = false;
                }
                else
                {
                    ddlFitsComments.SelectedIndex = e.Item.ItemIndex;
                    ddlRequest.SelectedIndex = e.Item.ItemIndex + 1;
                    ddlFitsComments.Enabled = false;
                }

                lblFitPlanningFor.Text = ddlRequest.SelectedValue;
                txtNextPlannedFitDate.Enabled = EnableIKnadiControl;

                ddlRequest.Enabled = EnableIKnadiControl;
                cviKandiFileUpload.Enabled = EnableIKnadiControl;

                fileIkandiUpload.Enabled = (IsIKandiUser || isBiplAllowed) && !objFits.IsStcApproved;
                fileBiplUpload.Enabled = IsBiplUser && !objFits.IsStcApproved;
                chkBoxAcknowledge.Enabled = EnableBiplUserControl;
                txtAckDate.Enabled = EnableBiplUserControl;
                txtPlannedDispatchDate.Enabled = EnableBiplUserControl;
                txtSuggestedFitDate.Enabled = EnableBiplUserControl;

                //if (IsIKandiUser || isBiplAllowed)
                //    cviKandiFileUpload.Enabled = ddlRequest.Enabled;


                if ((objFits != null && objFits.Id > 0 && objFits.FitsTrack != null && objFits.FitsTrack.Count > 0))
                {
                    FitsTrack rowFitsTrack = ((FitsTrack)e.Item.DataItem);

                    if (isNewRow && e.Item.ItemIndex == objFits.FitsTrack.Count - 1)
                    {
                        txtNextPlannedFitDate.Text = GetNextDate(Convert.ToDateTime("1/1/0001"), objFits.Department).ToString("dd MMM yy (ddd)");
                        txtNextPlannedFitDate.Enabled = true;
                        hlkViewMe.Visible = (string.IsNullOrEmpty(rowFitsTrack.FilePath)) ? false : true;
                        return;
                    }

                    ddlFitsComments.SelectedValue = rowFitsTrack.CommentsSentFor.ToString();
                    txtNextPlannedFitDate.Text = rowFitsTrack.NextPlannedDate.ToString("dd MMM yy (ddd)");
                    ddlRequest.SelectedValue = rowFitsTrack.PlanningFor;
                    prevReqIndex = ddlRequest.SelectedIndex;
                    lblFitPlanningFor.Text = ddlRequest.SelectedValue;
                    chkBoxReferenceSample.Checked = rowFitsTrack.RequiredSample;
                    hlkViewMe.NavigateUrl = (string.IsNullOrEmpty(rowFitsTrack.FilePath)) ? "" : FitsFolderPath + rowFitsTrack.FilePath;
                    hlkViewMe.Visible = (string.IsNullOrEmpty(rowFitsTrack.FilePath)) ? false : true;
                    hlkViewMeBipl.NavigateUrl = (string.IsNullOrEmpty(rowFitsTrack.BiplFilePath)) ? "" : FitsFolderPath + rowFitsTrack.BiplFilePath;
                    hlkViewMeBipl.Visible = (string.IsNullOrEmpty(rowFitsTrack.BiplFilePath)) ? false : true;
                    txtSuggestedFitDate.Text = rowFitsTrack.SuggestedFitDate == Convert.ToDateTime("1/1/0001") ? string.Empty : rowFitsTrack.SuggestedFitDate.ToString("dd MMM yy (ddd)");
                    chkBoxAcknowledge.Checked = rowFitsTrack.AcknowledgeTick;

                    if (lblFitPlanningFor.Text.ToUpper().Trim() == "STC" && objFits.IsStcApproved)
                    {
                        txtAckDate.Text = string.Empty;
                    }
                    else
                    {
                        txtAckDate.Text = (rowFitsTrack.AckDate == Convert.ToDateTime("1/1/0001")) ? DateTime.Now.ToString("dd MMM yy (ddd)") : rowFitsTrack.AckDate.ToString("dd MMM yy (ddd)");
                    }
                    txtPlannedDispatchDate.Text = (rowFitsTrack.PlannedDispatchDate == Convert.ToDateTime("1/1/0001")) ? "" : rowFitsTrack.PlannedDispatchDate.ToString("dd MMM yy (ddd)");

                    if (rowFitsTrack.SuggestedFitDate > rowFitsTrack.NextPlannedDate)
                    {
                        txtSuggestedFitDate.CssClass = "date_style backgroundclr-red";
                    }

                    txtNextPlannedFitDate.Enabled = false;
                    ddlRequest.Enabled = false;
                    cviKandiFileUpload.Enabled = ddlRequest.Enabled;
                    chkBoxReferenceSample.Enabled = false;

                    if (rowFitsTrack.AcknowledgeTick)
                    {
                        chkBoxAcknowledge.Enabled = false;
                        txtAckDate.Enabled = false;
                        txtPlannedDispatchDate.Enabled = false;
                        txtSuggestedFitDate.Enabled = false;
                    }

                    if (IsBiplUser && rowFitsTrack.PlanningFor == "STC" && !objFits.IsStcApproved)
                    {
                        ddlRequest.Enabled = true;
                        chkBoxAcknowledge.Enabled = false;
                        txtAckDate.Enabled = false;
                        txtPlannedDispatchDate.Enabled = false;
                        txtSuggestedFitDate.Enabled = false;
                        fileBiplUpload.Enabled = false;
                        cviKandiFileUpload.Enabled = ddlRequest.Enabled;
                    }

                    //if (IsIKandiUser || isBiplAllowed)
                    //    cviKandiFileUpload.Enabled = ddlRequest.Enabled;
                }
                else
                {
                    txtNextPlannedFitDate.Text = GetNextDate(Convert.ToDateTime("1/1/0001"), ClientDepartment).ToString("dd MMM yy (ddd)");
                    txtNextPlannedFitDate.Enabled = true;
                }
                if (ddlRequest.SelectedItem.Text == "STC" && (hlkViewMe.Visible == true || hlkViewMe.NavigateUrl != ""))
                {
                    ddlRequest.Enabled = false;
                    cviKandiFileUpload.Enabled = ddlRequest.Enabled;
                }
            }
        }

        protected void grdBasicInfo_RowDataBound(Object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                OrderDetail od = e.Row.DataItem as OrderDetail;

                if (intOrderDetailCount < (e.Row.RowIndex + 1))
                {
                    intIndex = intIndex + 1;
                    intOrderDetailCount = intOrderDetailCount + objOrderDetailCollection.Count;
                }

                if (Convert.ToDateTime(DataBinder.Eval(e.Row.DataItem, "STCUnallocated")) < minStcDate && Convert.ToDateTime(DataBinder.Eval(e.Row.DataItem, "STCUnallocated")) != Convert.ToDateTime("1/1/0001"))
                {
                    minStcDate = Convert.ToDateTime(DataBinder.Eval(e.Row.DataItem, "STCUnallocated"));
                }

                if (od.ParentOrder.OrderDate < minOrderDate && od.ParentOrder.OrderDate != Convert.ToDateTime("1/1/0001"))
                {
                    minOrderDate = od.ParentOrder.OrderDate;
                }

                Label lblSerialNumber = e.Row.FindControl("lblSerialNumber") as Label;
                (lblSerialNumber.Parent as TableCell).BackColor = System.Drawing.ColorTranslator.FromHtml(Constants.GetSerialNumberColor(((OrderDetail)e.Row.DataItem).ExFactory));

                HiddenField hdnExFactory = e.Row.FindControl("hdnExFactory") as HiddenField;
                (hdnExFactory.Parent as TableCell).BackColor = System.Drawing.ColorTranslator.FromHtml(iKandi.BLL.CommonHelper.GetExFactoryColor(((OrderDetail)e.Row.DataItem).ExFactory, ((OrderDetail)e.Row.DataItem).DC, ((OrderDetail)e.Row.DataItem).Mode));

                HiddenField hdnMode = e.Row.FindControl("hdnMode") as HiddenField;
                (hdnMode.Parent as TableCell).BackColor = System.Drawing.ColorTranslator.FromHtml(iKandi.BLL.CommonHelper.GetDeliveryModeColor(((OrderDetail)e.Row.DataItem).Mode));

                HiddenField hdnStatus = e.Row.FindControl("hdnStatus") as HiddenField;
                (hdnStatus.Parent as TableCell).BackColor = System.Drawing.ColorTranslator.FromHtml(Constants.GetStatusModeColor(((OrderDetail)e.Row.DataItem).StatusModeID));
            }
        }

        protected void ddlRequest_SelectedIndexChanged(Object sender, EventArgs e)
        {
            if (((DropDownList)sender).SelectedValue == "STC")
            {
                if (objFits != null)
                {
                    if (IsBiplUser && !isNewRow && !(objFits.IsStcApproved))
                    {
                        ((CheckBox)rptFitSection.Items[rptFitSection.Items.Count - 1].FindControl("chkBoxReferenceSample")).Enabled = true;
                        if (IsIKandiUser || isBiplAllowed)
                        {
                            chkBoxStcApproved.Enabled = false;
                            txtComments.Enabled = false;
                            FileUpload1.Enabled = false;
                            hlkViewMe.Enabled = (string.IsNullOrEmpty(objFits.FilePath)) ? false : true;
                        }

                    }
                }
                else
                {
                    ((CheckBox)rptFitSection.Items[rptFitSection.Items.Count - 1].FindControl("chkBoxReferenceSample")).Enabled = true;

                    if (IsIKandiUser || isBiplAllowed)
                    {
                        chkBoxStcApproved.Enabled = false;
                        txtComments.Enabled = false;
                        FileUpload1.Enabled = false;
                    }
                }
            }
            else
            {
                ((CheckBox)rptFitSection.Items[rptFitSection.Items.Count - 1].FindControl("chkBoxReferenceSample")).Enabled = false;
                Label lblFitPlanningFor = ((Label)rptFitSection.Items[rptFitSection.Items.Count - 1].FindControl("lblFitPlanningFor"));
                lblFitPlanningFor.Text = ((DropDownList)sender).SelectedValue;
                if (IsIKandiUser || isBiplAllowed)
                {
                    chkBoxStcApproved.Enabled = false;
                    txtComments.Enabled = false;
                    FileUpload1.Enabled = false;
                    hlkViewMe.Enabled = (objFits == null || string.IsNullOrEmpty(objFits.FilePath)) ? false : true;
                }
            }
        }

        protected void btnSaveAll_Click(Object sender, EventArgs e)
        {
            SaveFitsDetails();
        }

        #endregion

        #region Private Method

        private void BindControls()
        {
            if (StyleCodeVersion != string.Empty)
            {
                string styleNum = Constants.ExtractStyleCode(StyleCodeVersion);
                objOrderDetailCollection = this.OrderControllerInstance.GetOrder(StyleCodeVersion, (ClientDepartment == null ? -1 : ClientDepartment.DeptID));

                //if (ApplicationHelper.LoggedInUser.UserData.Designation == Designation.BIPL_Merchandising_FitMerchant && objOrderDetailCollection[0].ParentOrder.BuyingHouseID > 1 && IsIKandiUser==true)
                if (objOrderDetailCollection.Count > 0)
                {
                    if (objOrderDetailCollection[0].ParentOrder.IsIkandiClient != 1)
                    {
                        isBiplAllowed = true;
                    }
                }

                if (IsBiplUser && !isNewRow)
                {
                    pnlStcHide.Enabled = true;
                }
                else
                {
                    chkBoxStcApproved.Enabled = false;
                    txtComments.Enabled = false;
                    FileUpload1.Enabled = false;
                }

                //Set User control Header

                if (ClientDepartment != null)
                {
                    lblDepartMentName.Text = (ClientDepartment == null ? string.Empty : ClientDepartment.Name);
                    hdnDeptId.Value = ClientDepartment.DeptID.ToString();
                    ucFITsTopsSection.DeptID = ClientDepartment.DeptID;
                }
                SealerPending objSealerPending = this.SealerPendingControllerInstance.GetSealerPendingInfo(styleNum, (ClientDepartment != null ? ClientDepartment.DeptID : -1));
                if (!string.IsNullOrEmpty(objSealerPending.RemarksBIPL))
                    txtCommentsBIPL.Text = objSealerPending.RemarksBIPL.Replace("$$", Environment.NewLine);
                if (!string.IsNullOrEmpty(objSealerPending.RemarksIKANDI))
                    txtCommentsIkandi.Text = objSealerPending.RemarksIKANDI.Replace("$$", Environment.NewLine);

                //Set Basic Info
                grdBasicInfo.DataSource = objOrderDetailCollection;
                grdBasicInfo.DataBind();

                if (clientDepartment != null && clientDepartment.DeptID > 0)
                    objFits = this.FITsControllerInstance.GetFITsBasicInfo(this.StyleCodeVersion, ClientDepartment.DeptID);
                else
                    objFits = null;

                if (objFits == null || objFits.Id <= 0)
                {
                    txtTrackDate.Text = "";
                    chkSpecs.Checked = false;
                    hdnSpecsUploadedDate.Value = Convert.ToDateTime("1/1/0001").ToString();
                    lblSpecsUploadedDate.Text = string.Empty;

                    chkBoxStcApproved.Enabled = false;
                    txtComments.Enabled = false;
                    FileUpload1.Enabled = false;
                }
                else
                {
                    txtTrackDate.Text = objFits.SampleTrackingDate == Convert.ToDateTime("1/1/0001") ? "" : objFits.SampleTrackingDate.ToString("dd MMM yy (ddd)");
                    hdnSpecsUploadedDate.Value = objFits.SpecsUploadDate.ToString("dd MMM yy (ddd)");
                    lblSpecsUploadedDate.Text = objFits.SpecsUploadDate == Convert.ToDateTime("1/1/0001") ? string.Empty : "(" + objFits.SpecsUploadDate.ToString("dd MMM yy (ddd)") + ")";
                    chkSpecs.Checked = objFits.SpecsUploadDate != Convert.ToDateTime("1/1/0001") ? true : false;

                    if (chkSpecs.Checked)
                    {
                        chkSpecs.Enabled = false;
                    }

                    hlkViewMeSpecs.Visible = (string.IsNullOrEmpty(objFits.SpecsURL)) ? false : true;
                    hlkViewMeSpecs.NavigateUrl = (string.IsNullOrEmpty(objFits.SpecsURL)) ? "" : FitsFolderPath + objFits.SpecsURL;

                }

                if (!(String.IsNullOrEmpty(txtTrackDate.Text)))
                {
                    if (objOrderDetailCollection.Count > 0 && objOrderDetailCollection[0].ParentOrder.IsRepeat == true)
                        txtTrackDate.Style.Add("background-color", "#01cc01");
                    else if (objOrderDetailCollection.Count > 0 && objOrderDetailCollection[0].ParentOrder.IsRepeat == false)
                    {
                        if (minOrderDate != DateTime.MaxValue && minOrderDate.AddDays(10) < trackingDate && trackingDate != DateTime.MaxValue)
                            txtTrackDate.Style.Add("background-color", "red");
                        else
                            txtTrackDate.Style.Add("background-color", "#01cc01");
                    }
                }

                lblStc.Text = minStcDate == DateTime.MaxValue ? "" : minStcDate.ToString("dd MMM yy (ddd)");


                if (objFits != null && objFits.FitsTrack != null && objFits.FitsTrack.Count > 0)
                {
                    if (objFits.FitsTrack[objFits.FitsTrack.Count - 1].AcknowledgeTick && !objFits.IsStcApproved && (IsIKandiUser || isBiplAllowed))
                    {
                        objFits.FitsTrack.Add(new FitsTrack());
                        isNewRow = true;
                    }

                    hdnMon.Value = objFits.Department.Mon.ToString();
                    hdnTue.Value = objFits.Department.Tue.ToString();
                    hdnWed.Value = objFits.Department.Wed.ToString();
                    hdnThu.Value = objFits.Department.Thu.ToString();
                    hdnFri.Value = objFits.Department.Fri.ToString();

                    rptFitSection.DataSource = objFits.FitsTrack;
                    rptFitSection.DataBind();

                    //set stc information
                    if (objFits.IsStcApproved)
                    {
                        chkBoxStcApproved.Checked = true;
                        chkBoxStcApproved.Enabled = false;
                        txtComments.Text = objFits.Comments;
                        hlkViewMe.Visible = (string.IsNullOrEmpty(objFits.FilePath)) ? false : true;
                        hlkViewMe.NavigateUrl = (string.IsNullOrEmpty(objFits.FilePath)) ? "" : FitsFolderPath + objFits.FilePath;
                        txtComments.Enabled = false;

                        if (ApplicationHelper.LoggedInUser.UserData.Designation == Designation.iKandi_Technical_Technologist || ApplicationHelper.LoggedInUser.UserData.Designation == Designation.iKandi_Technical_Manager || isBiplAllowed)// || (ApplicationHelper.LoggedInUser.UserData.Designation == Designation.BIPL_Merchandising_FitMerchant && objOrderDetailCollection[0].ParentOrder.BuyingHouseID > 1))
                        {
                            FileUpload1.Enabled = false;
                            chkBoxStcApproved.Enabled = false;
                            txtComments.Enabled = false;
                            hlkViewMe.Enabled = (string.IsNullOrEmpty(objFits.FilePath)) ? false : true;
                        }
                        else
                            FileUpload1.Enabled = true;
                    }

                    else if (objFits.FitsTrack.Count > 0 && objFits.FitsTrack[objFits.FitsTrack.Count - 1].PlanningFor == "STC")
                    {
                        if (ApplicationHelper.LoggedInUser.UserData.Designation == Designation.iKandi_Technical_Technologist || ApplicationHelper.LoggedInUser.UserData.Designation == Designation.iKandi_Technical_Manager)// || (ApplicationHelper.LoggedInUser.UserData.Designation == Designation.BIPL_Merchandising_FitMerchant && objOrderDetailCollection[0].ParentOrder.BuyingHouseID > 1))
                        {
                            chkBoxStcApproved.Enabled = false;
                            txtComments.Enabled = false;
                            FileUpload1.Enabled = false;
                            hlkViewMe.Enabled = (string.IsNullOrEmpty(objFits.FilePath)) ? false : true;
                        }
                    }
                }
                else
                {
                    isNewRow = true;
                    rptFitSection.DataSource = "a";
                    rptFitSection.DataBind();
                }

                if (objFits != null)
                {
                    hdnMon.Value = objFits.Department.Mon.ToString();
                    hdnTue.Value = objFits.Department.Tue.ToString();
                    hdnWed.Value = objFits.Department.Wed.ToString();
                    hdnThu.Value = objFits.Department.Thu.ToString();
                    hdnFri.Value = objFits.Department.Fri.ToString();
                }
                btnSaveAll.Visible = true;
            }
        }

        private void SaveFitsDetails()
        {
            Boolean isNew = true;
            Boolean isAllowed = false;
            objFits = this.FITsControllerInstance.GetFITsBasicInfo(this.StyleCodeVersion, Convert.ToInt32(hdnDeptId.Value));

            if (objFits != null && objFits.Id > 0)
            {
                isNew = false;
            }

            if (isNew) // Insert will take place for fits
            {
                objFits.Department = new ClientDepartment();
                objFits.Department.DeptID = Convert.ToInt32(hdnDeptId.Value);
                objFits.Department.Mon = Convert.ToInt32(hdnMon.Value);
                objFits.Department.Tue = Convert.ToInt32(hdnTue.Value);
                objFits.Department.Wed = Convert.ToInt32(hdnWed.Value);
                objFits.Department.Thu = Convert.ToInt32(hdnThu.Value);
                objFits.Department.Fri = Convert.ToInt32(hdnFri.Value);
                objFits.IsStcApproved = false;
                objFits.StyleCodeVersion = StyleCodeVersion;

                if (IsIKandiUser || isBiplAllowed)
                {
                    int i = 0;
                    objFits.FitsTrack = new List<FitsTrack>();

                    foreach (RepeaterItem rptItemFitsTrack in rptFitSection.Items)
                    {
                        DropDownList ddlFitsComments = ((DropDownList)rptItemFitsTrack.FindControl("ddlFitsComments"));
                        DropDownList ddlRequest = ((DropDownList)rptItemFitsTrack.FindControl("ddlRequest"));
                        TextBox txtNextPlannedFitDate = ((TextBox)rptItemFitsTrack.FindControl("txtNextPlannedFitDate"));
                        FileUpload fileIkandiUpload = ((FileUpload)rptItemFitsTrack.FindControl("fileIkandiUpload"));
                        CheckBox chkBoxReferenceSample = ((CheckBox)rptItemFitsTrack.FindControl("chkBoxReferenceSample"));

                        FitsTrack objFitsTrack = new FitsTrack();
                        objFitsTrack.CommentsSentFor = ddlFitsComments.SelectedValue;
                        objFitsTrack.NextPlannedDate = (txtNextPlannedFitDate.Text != String.Empty) ? DateHelper.ParseDate(txtNextPlannedFitDate.Text).Value : Convert.ToDateTime("1/1/0001");
                        objFitsTrack.PlanningFor = ddlRequest.SelectedValue;
                        objFitsTrack.RequiredSample = chkBoxReferenceSample.Checked;
                        System.Web.UI.WebControls.Button btn = (System.Web.UI.WebControls.Button)this.FindControl("btnSaveAll");
                        var fileNameIkandi = StyleCodeVersion.ToString() + "-" + lblDepartMentName.Text + "-" + ddlFitsComments.SelectedValue + "-" + "IKANDI";
                        objFitsTrack.FilePath = SaveUploadedFile(fileIkandiUpload, fileNameIkandi);
                        objFits.FitsTrack.Add(objFitsTrack);
                        if ((i + 1) == objFits.FitsTrack.Count)
                        {
                            if (fileIkandiUpload.HasFile)
                            {
                                isAllowed = true;
                            }
                        }
                        else { isAllowed = false; }
                    }

                    objFits = this.FITsControllerInstance.CreateFITs(objFits, isAllowed);
                }

                else
                {
                    objFits.SampleTrackingDate = DateHelper.ParseDate(txtTrackDate.Text).Value;

                    if (fileUploadSpecs.HasFile)
                    {
                        var fileNameStyle = this.StyleCodeVersion.ToString() + "-" + lblDepartMentName.Text;
                        objFits.SpecsURL = SaveUploadedFile(fileUploadSpecs, fileNameStyle);
                        hlkViewMeSpecs.Visible = true;
                        hlkViewMeSpecs.NavigateUrl = (string.IsNullOrEmpty(objFits.SpecsURL)) ? "" : FitsFolderPath + objFits.SpecsURL;
                    }
                    DateTime specsDate = objFits.SpecsUploadDate;
                    DateTime hdnSpecsDate = new DateTime(specsDate.Year, specsDate.Month, specsDate.Day, 00, 00, 00);
                    if ((chkSpecs.Checked == true || fileUploadSpecs.HasFile) && hdnSpecsDate != DateHelper.ParseDate(hdnSpecsUploadedDate.Value).Value)
                    {
                        objFits.SpecsUploadDate = DateTime.Now;
                    }
                    else
                    {
                        objFits.SpecsUploadDate = objFits.SpecsUploadDate;
                    }

                    objFits = this.FITsControllerInstance.CreateFITs(objFits, false);
                }
            }
            else // Update will take place for fits
            {
                objFits.Department = new ClientDepartment();
                objFits.Department.DeptID = Convert.ToInt32(hdnDeptId.Value);
                objFits.Department.Mon = Convert.ToInt32(hdnMon.Value);
                objFits.Department.Tue = Convert.ToInt32(hdnTue.Value);
                objFits.Department.Wed = Convert.ToInt32(hdnWed.Value);
                objFits.Department.Thu = Convert.ToInt32(hdnThu.Value);
                objFits.Department.Fri = Convert.ToInt32(hdnFri.Value);
                objFits.IsStcApproved = chkBoxStcApproved.Checked;
                objFits.StyleCodeVersion = this.StyleCodeVersion;
                objFits.Comments = txtComments.Text;
                System.Web.UI.WebControls.Button btn = (System.Web.UI.WebControls.Button)this.FindControl("btnSaveAll");

                var fileNameSTC = this.StyleCodeVersion.ToString() + "-" + lblDepartMentName.Text + "-" + "STC Approved Sample";
                objFits.FilePath = (objFits.IsStcApproved && FileUpload1.HasFile) ? SaveUploadedFile(FileUpload1, fileNameSTC) : objFits.FilePath;

                if (objFits.SealDate == Convert.ToDateTime("1/1/0001"))
                {
                    objFits.SealDate = objFits.IsStcApproved ? DateTime.Now : objFits.SealDate;
                }

                objFits.SampleTrackingDate = DateHelper.ParseDate(txtTrackDate.Text).Value;

                if (fileUploadSpecs.HasFile)
                {
                    var fileNameStyle = this.StyleCodeVersion.ToString() + "-" + lblDepartMentName.Text;
                    objFits.SpecsURL = SaveUploadedFile(fileUploadSpecs, fileNameStyle);
                    hlkViewMeSpecs.Visible = true;
                    hlkViewMeSpecs.NavigateUrl = (string.IsNullOrEmpty(objFits.SpecsURL)) ? "" : FitsFolderPath + objFits.SpecsURL;
                }

                DateTime specsDate = objFits.SpecsUploadDate;
                DateTime hdnSpecsDate = new DateTime(specsDate.Year, specsDate.Month, specsDate.Day, 00, 00, 00);
                if ((chkSpecs.Checked == true || fileUploadSpecs.HasFile) && hdnSpecsDate != DateHelper.ParseDate(hdnSpecsUploadedDate.Value).Value)
                {
                    objFits.SpecsUploadDate = DateTime.Now;
                }
                else
                {
                    objFits.SpecsUploadDate = objFits.SpecsUploadDate;
                }


                int i = 0;

                Boolean IsLastRowWillInsert = true;

                foreach (RepeaterItem rptItemFitsTrack in rptFitSection.Items)
                {
                    DropDownList ddlFitsComments = ((DropDownList)rptItemFitsTrack.FindControl("ddlFitsComments"));
                    DropDownList ddlRequest = ((DropDownList)rptItemFitsTrack.FindControl("ddlRequest"));
                    Label lblFitPlanningFor = ((Label)rptItemFitsTrack.FindControl("lblFitPlanningFor"));
                    TextBox txtNextPlannedFitDate = ((TextBox)rptItemFitsTrack.FindControl("txtNextPlannedFitDate"));
                    TextBox txtSuggestedFitDate = ((TextBox)rptItemFitsTrack.FindControl("txtSuggestedFitDate"));
                    FileUpload fileIkandiUpload = ((FileUpload)rptItemFitsTrack.FindControl("fileIkandiUpload"));
                    FileUpload fileBiplUpload = ((FileUpload)rptItemFitsTrack.FindControl("fileBiplUpload"));
                    CheckBox chkBoxAcknowledge = ((CheckBox)rptItemFitsTrack.FindControl("chkBoxAcknowledge"));
                    TextBox txtAckDate = ((TextBox)rptItemFitsTrack.FindControl("txtAckDate"));
                    Label txtPlannedDispatchDate = ((Label)rptItemFitsTrack.FindControl("txtPlannedDispatchDate"));
                    HyperLink hlkViewMe = ((HyperLink)rptItemFitsTrack.FindControl("hlkViewMe"));
                    CheckBox chkBoxReferenceSample = ((CheckBox)rptItemFitsTrack.FindControl("chkBoxReferenceSample"));

                    if (i >= objFits.FitsTrack.Count)
                    {
                        if (IsLastRowWillInsert)
                        {
                            objFits.FitsTrack.Add(new FitsTrack());
                        }
                        else
                        {
                            break;
                        }
                    }
                    if ((i + 1) == objFits.FitsTrack.Count)
                    {
                        if (fileIkandiUpload.HasFile)
                        {
                            isAllowed = true;
                        }
                    }
                    else isAllowed = false;

                    System.Web.UI.WebControls.Button btn1 = (System.Web.UI.WebControls.Button)this.FindControl("btnSaveAll");
                    var fileNameIkandi = this.StyleCodeVersion.ToString() + "-" + lblDepartMentName.Text + "-" + ddlFitsComments.SelectedValue + "-" + "IKANDI";
                    var fileNameBipl = this.StyleCodeVersion.ToString() + "-" + lblDepartMentName.Text + "-" + ddlRequest.SelectedValue + "-" + "BIPL";
                    objFits.FitsTrack[i].CommentsSentFor = ddlFitsComments.SelectedValue;
                    objFits.FitsTrack[i].NextPlannedDate = (txtNextPlannedFitDate.Text != String.Empty) ? DateHelper.ParseDate(txtNextPlannedFitDate.Text).Value : Convert.ToDateTime("1/1/0001");
                    objFits.FitsTrack[i].SuggestedFitDate = (txtSuggestedFitDate.Text != String.Empty) ? DateHelper.ParseDate(txtSuggestedFitDate.Text).Value : Convert.ToDateTime("1/1/0001");
                    objFits.FitsTrack[i].PlanningFor = ddlRequest.SelectedValue;
                    objFits.FitsTrack[i].RequiredSample = chkBoxReferenceSample.Checked;
                    objFits.FitsTrack[i].AcknowledgeTick = chkBoxAcknowledge.Checked;

                    if (objFits.FitsTrack[i].AcknowledgeTick)
                    {
                        objFits.FitsTrack[i].AckDate = (txtAckDate.Text != String.Empty) ? DateHelper.ParseDate(txtAckDate.Text).Value : Convert.ToDateTime("1/1/0001");
                        objFits.FitsTrack[i].ActualDispatchDate = (objFits.FitsTrack[i].AcknowledgeTick && objFits.FitsTrack[i].AckDate == Convert.ToDateTime("1/1/0001")) ? DateTime.Now : objFits.FitsTrack[i].AckDate;
                        objFits.FitsTrack[i].SuggestedFitDate = (txtSuggestedFitDate.Text != String.Empty) ? DateHelper.ParseDate(txtSuggestedFitDate.Text).Value : GetSuggestFitsDate(Convert.ToDateTime("1/1/0001"), objFits.Department);
                    }
                    else
                    {
                        objFits.FitsTrack[i].AckDate = Convert.ToDateTime("1/1/0001");
                        objFits.FitsTrack[i].ActualDispatchDate = Convert.ToDateTime("1/1/0001");
                        objFits.FitsTrack[i].SuggestedFitDate = Convert.ToDateTime("1/1/0001");
                    }

                    objFits.FitsTrack[i].PlannedDispatchDate = (txtPlannedDispatchDate.Text != String.Empty) ? DateHelper.ParseDate(txtPlannedDispatchDate.Text).Value : Convert.ToDateTime("1/1/0001");

                    if (fileIkandiUpload.HasFile)
                    {
                        IsLastRowWillInsert = false;
                    }

                    objFits.FitsTrack[i].FilePath = fileIkandiUpload.HasFile ? SaveUploadedFile(fileIkandiUpload, fileNameIkandi) : objFits.FitsTrack[i].FilePath;
                    objFits.FitsTrack[i].BiplFilePath = fileBiplUpload.HasFile ? SaveUploadedFile(fileBiplUpload, fileNameBipl) : objFits.FitsTrack[i].BiplFilePath;

                    i++;
                }
                bool status;

                if ((IsIKandiUser == true || isBiplAllowed == true) && isAllowed == true)
                {
                    status = true;
                }
                else
                {
                    status = false;
                }


                objFits = this.FITsControllerInstance.UpdateFITs(objFits, status);
            }

            rptFitSection.DataSource = objFits.FitsTrack;
            rptFitSection.DataBind();

            //set stc information
            if (objFits.IsStcApproved)
            {
                chkBoxStcApproved.Checked = true;
                chkBoxStcApproved.Enabled = false;
                txtComments.Text = objFits.Comments;
                hlkViewMe.Visible = (string.IsNullOrEmpty(objFits.FilePath)) ? false : true;
                hlkViewMe.NavigateUrl = (string.IsNullOrEmpty(objFits.FilePath)) ? "" : FitsFolderPath + objFits.FilePath;
                txtComments.Enabled = false;
                FileUpload1.Enabled = true;
            }

            if (IsBiplUser && !isNewRow)
            {
                pnlStcHide.Enabled = true;
            }
            else
            {
                chkBoxStcApproved.Enabled = false;
                txtComments.Enabled = false;
                FileUpload1.Enabled = false;
                hlkViewMe.Enabled = (string.IsNullOrEmpty(objFits.FilePath)) ? false : true;
            }

            System.Web.UI.WebControls.Button btnSave = (System.Web.UI.WebControls.Button)this.FindControl("btnSaveAll");
            System.Web.UI.WebControls.Panel pnlHide = (System.Web.UI.WebControls.Panel)btnSave.Parent.Parent.Parent.Parent.Parent.FindControl("pnlForm");
            pnlHide.Visible = false;
            System.Web.UI.WebControls.Panel pnlShow = (System.Web.UI.WebControls.Panel)btnSave.Parent.Parent.Parent.Parent.Parent.FindControl("pnlMessage");
            pnlShow.Visible = true;
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

        private DateTime GetNextDate(DateTime dtNextPlanned, ClientDepartment objClientDepartment)
        {
            if (dtNextPlanned != Convert.ToDateTime("1/1/0001"))
            {
                return dtNextPlanned;
            }
            else
            {
                dtNextPlanned = DateTime.Now.AddDays(7);
            }

            ArrayList arr = new ArrayList();
            arr.Add(objClientDepartment.Mon);
            arr.Add(objClientDepartment.Tue);
            arr.Add(objClientDepartment.Wed);
            arr.Add(objClientDepartment.Thu);
            arr.Add(objClientDepartment.Fri);
            arr.Add("0");
            arr.Add("0");
            arr.Add(objClientDepartment.Mon);
            arr.Add(objClientDepartment.Tue);
            arr.Add(objClientDepartment.Wed);
            arr.Add(objClientDepartment.Thu);
            arr.Add(objClientDepartment.Fri);

            DateTime dt = dtNextPlanned;

            int i = Convert.ToInt32(Enum.Parse(DayOfWeek.Monday.GetType(), dtNextPlanned.DayOfWeek.ToString()));

            for (int l = i; l < arr.Count; l++)
            {
                if (arr[l].ToString() == "1")
                {
                    dt = dtNextPlanned.AddDays(l - i + 1);
                    break;
                }
            }

            return dt;
        }

        private DateTime GetSuggestFitsDate(DateTime dtSuggestFitssDate, ClientDepartment objClientDepartment)
        {
            if (dtSuggestFitssDate != Convert.ToDateTime("1/1/0001"))
            {
                return dtSuggestFitssDate;
            }
            else
            {
                dtSuggestFitssDate = DateTime.Now.AddDays(2);
            }

            ArrayList arr = new ArrayList();
            arr.Add(objClientDepartment.Mon);
            arr.Add(objClientDepartment.Tue);
            arr.Add(objClientDepartment.Wed);
            arr.Add(objClientDepartment.Thu);
            arr.Add(objClientDepartment.Fri);
            arr.Add("0");
            arr.Add("0");
            arr.Add(objClientDepartment.Mon);
            arr.Add(objClientDepartment.Tue);
            arr.Add(objClientDepartment.Wed);
            arr.Add(objClientDepartment.Thu);
            arr.Add(objClientDepartment.Fri);

            DateTime dt = dtSuggestFitssDate;

            int i = Convert.ToInt32(Enum.Parse(DayOfWeek.Monday.GetType(), dtSuggestFitssDate.DayOfWeek.ToString()));

            for (int l = i; l < arr.Count; l++)
            {
                if (arr[l].ToString() == "1")
                {
                    dt = dtSuggestFitssDate.AddDays(l - i + 1);
                    break;
                }
            }

            return dt;
        }

        #endregion
    }
}