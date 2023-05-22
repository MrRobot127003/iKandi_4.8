using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using iKandi.Common;
using iKandi.Common.Entities;
using System.Collections;
using iKandi.Web.Components;
using System.Web.UI.WebControls.WebParts;
using System.Text.RegularExpressions;
using System.Web.UI.HtmlControls;
using System.Drawing;



namespace iKandi.Web.UserControls.Forms
{
    public partial class Fitting : BaseUserControl
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
        public bool isBiplAllowed = false;

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

        #endregion

        //#region Properties

        //private string stylenumber
        //{
        //    get
        //    {
        //        if (null != Request.QueryString["stylenumber"])
        //        {
        //            return Request.QueryString["stylenumber"].ToString();
        //        }
        //        return string.Empty;
        //    }
        //}


        private ClientDepartment clientDepartment;
        public ClientDepartment ClientDepartment
        {
            get { return clientDepartment; }
            set { clientDepartment = value; }
        }

        //#endregion
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
        int sl = 0;

        iKandi.BLL.OrderController obj_OrderController = new BLL.OrderController();
        iKandi.BLL.OrderProcessController obj_ProcessController = new BLL.OrderProcessController();

        public int styleid
        {
            get;
            set;
        }
        public string FitsStyle
        {
            get;
            set;
        }
        public string StyleCode
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
        public string DepartmentName
        {
            get;
            set;
        }
        public int ClientDeptId
        {
            get;
            set;
        }
        public bool BH_Enabled
        {
            get;
            set;
        }
        public bool BIPL_Enabled
        {
            get;
            set;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
          
            GetQueryString();
            if (null == Request.QueryString["showFITSFORM"])
            {
              dvFitting.Visible = false;
              return;
            }
            if (!IsPostBack)
            {
                //HiddenField hdnShowForm = (HiddenField)this.Parent.FindControl("hdnShowForm");
                //if (hdnShowForm != null)
                //{
                //    if (hdnShowForm.Value != "0")
                //    {
                //        if (hdnShowForm.Value != "ShowFitsForm")
                //        {
                //            return;
                //        }
                //    }
                //}

                ViewState["ddlRequest"] = -1;
                BindControlgvNew(0, 0, 0, -1);
                BindControls(0, 0, 0, -1, "");
                BindBHGrd(0, 0, 0, -1, "");
                BindBIPLGrd(0, 0, 0, -1, "");
            }
        }

        private void GetQueryString()
        {

            if (null != Request.QueryString["styleid"])
            {
                styleid = Convert.ToInt32(Request.QueryString["styleid"].ToString());
            }
            if (null != Request.QueryString["FitsStyle"])
            {
                FitsStyle = Request.QueryString["FitsStyle"].ToString();
            }
            if (null != Request.QueryString["StyleCode"])
            {
                StyleCode = Request.QueryString["StyleCode"].ToString();
            }
            if (null != Request.QueryString["ClientID"])
            {
                strClientId = Convert.ToInt32(Request.QueryString["ClientID"].ToString());
            }
            if (null != Request.QueryString["DeptId"])
            {
                DepartmentId = Convert.ToInt32(Request.QueryString["DeptId"].ToString());
            }
            if ((FitsStyle == string.Empty) || (FitsStyle == null))
            {
                FitsStyle = StyleCode;
            }
        }

        private void BindControlgvNew(int CreateNew, int NewRef, int ReUse, int ReUseStyleId)
        {
            DataTable dtPermission = new DataTable();
            List<OrderDetail> OdList = new List<OrderDetail>();
            int desigId = Convert.ToInt32(iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.Designation);
            int DeptId = Convert.ToInt32(iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.PrimaryGroupID);

            OdList = obj_OrderController.GetMoInfo(styleid, strClientId, DepartmentId, CreateNew, NewRef, ReUse, ReUseStyleId, 2);

            if (OdList.Count >= 3)
            {
                dvGvFits.Attributes.Add("style", "height:500px; overflow-x: hidden; overflow-y: auto;");
            }
            else
            {
                dvGvFits.Attributes.Add("style", "height:300px; overflow-x: hidden; overflow-y: auto;");
            }

            if (OdList.Count > 0)
            {
                gvFits.DataSource = OdList;
                gvFits.DataBind();
            }

        }

        private void BindControls(int CreateNew, int NewRef, int ReUse, int ReUseStyleId, string ReUseStyleNumber)
        {
            DataSet dsStyle = obj_ProcessController.GetStyleNumberClientDept(styleid, ReUseStyleId, strClientId, DepartmentId, CreateNew, NewRef, ReUse, 2);
            if (dsStyle.Tables[0].Rows.Count > 0)
            {
                string StyleDetail = "";
                for (int i = 0; i < dsStyle.Tables[0].Rows.Count; i++)
                {
                    StyleDetail = StyleDetail + " [" + dsStyle.Tables[0].Rows[i]["StyleDetail"].ToString() + "],";
                }

                lblFitsBasicInformation.Text = StyleDetail.TrimEnd(',');
            }

            if (FitsStyle != string.Empty)
            {
                // int ClientDeptId;
                string styleNum = Constants.ExtractStyleCode(FitsStyle);

                List<ClientDepartment> objClientDepartment = this.ClientControllerInstance.GetClientDeptsByClientIDOnlyForOrders(strClientId, FitsStyle);
                if (objClientDepartment.Count > 0)
                {
                    ClientDeptId = objClientDepartment[0].DeptID;
                    hdnFitsDeptId.Value = ClientDeptId.ToString();
                }
                else
                {
                    ClientDeptId = ClientDepartment == null ? DepartmentId : ClientDepartment.DeptID;
                    hdnFitsDeptId.Value = ClientDeptId.ToString();
                }

                objOrderDetailCollection = this.OrderControllerInstance.GetOrder(FitsStyle, ClientDeptId);


                if (objOrderDetailCollection.Count > 0)
                {
                    if (objOrderDetailCollection[0].ParentOrder.IsIkandiClient != 1)
                    {
                        isBiplAllowed = true;
                        hdnBIPLAllowed.Value = "1";
                    }
                    minStcDate = objOrderDetailCollection[0].STCUnallocated;

                    DepartmentName = objOrderDetailCollection[0].ParentOrder.Style.cdept.Name;
                    lblStc.Text = minStcDate == DateTime.MaxValue ? "" : minStcDate.ToString("dd MMM yy (ddd)");
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
                SealerPending objSealerPending = this.SealerPendingControllerInstance.GetSealerPendingInfo(styleNum, (ClientDepartment != null ? ClientDepartment.DeptID : -1));
                if (!string.IsNullOrEmpty(objSealerPending.RemarksBIPL))
                    txtCommentsBIPL.Text = objSealerPending.RemarksBIPL.Replace("$$", Environment.NewLine);
                if (!string.IsNullOrEmpty(objSealerPending.RemarksIKANDI))
                    txtCommentsIkandi.Text = objSealerPending.RemarksIKANDI.Replace("$$", Environment.NewLine);

                objFits = this.FITsControllerInstance.GetFITsBasicInfo_ForOrderProcess(this.FitsStyle, ClientDeptId, styleid, CreateNew, NewRef, ReUse, ReUseStyleId, 0);

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

                DataSet dsStyleVirsion = this.FITsControllerInstance.GetFitsCodeVirsion(this.FitsStyle, CreateNew);
                if (dsStyleVirsion.Tables[0].Rows.Count > 0)
                {
                    repStyleCodeVirsion.DataSource = dsStyleVirsion.Tables[0];
                    repStyleCodeVirsion.DataBind();
                    ShowGridPopup.Visible = false;
                }
                else
                {
                    repStyleCodeVirsion.DataSource = null;
                    repStyleCodeVirsion.DataBind();
                    ShowGridPopup.Visible = false;
                }

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

                    gvBuyingHouse.DataSource = objFits.FitsTrack;
                    gvBuyingHouse.DataBind();
                    //BindBHGrd(CreateNew, NewRef, ReUse, ReUseStyleId, ReUseStyleNumber);
                    //BindBIPLGrd(CreateNew, NewRef, ReUse, ReUseStyleId, ReUseStyleNumber);

                    Boolean EnableIKnadiControl = (IsIKandiUser || isBiplAllowed) && isNewRow && !(objFits.IsStcApproved);
                    Boolean EnableBiplUserControl = IsBiplUser && !isNewRow && !(objFits.IsStcApproved);
                    BH_Enabled = EnableIKnadiControl;
                    BIPL_Enabled = EnableBiplUserControl;
                    grdFitsBhRemarks.Enabled = EnableIKnadiControl;
                    grdFitsBIPLRemark.Enabled = EnableBiplUserControl;

                    //if (isBiplAllowed)
                    //{

                    //}
                    //if (IsIKandiUser)
                    //{
                    //    grdFitsBhRemarks.Enabled = true;
                    //    grdFitsBIPLRemark.Enabled = false;
                    //}



                    //set stc information
                    if (objFits.IsStcApproved)
                    {
                        chkBoxStcApproved.Checked = true;
                        chkBoxStcApproved.Enabled = false;
                        txtComments.Text = objFits.Comments;
                        hlkViewMe.Visible = (string.IsNullOrEmpty(objFits.FilePath)) ? false : true;
                        hlkViewMe.NavigateUrl = (string.IsNullOrEmpty(objFits.FilePath)) ? "" : FitsFolderPath + objFits.FilePath;
                        txtComments.Enabled = false;
                        //commented by uday 2-1-2016
                        //if (ApplicationHelper.LoggedInUser.UserData.Designation == Designation.iKandi_Technical_Technologist || ApplicationHelper.LoggedInUser.UserData.Designation == Designation.iKandi_Technical_Manager || isBiplAllowed)// || (ApplicationHelper.LoggedInUser.UserData.Designation == Designation.BIPL_Merchandising_FitMerchant && objOrderDetailCollection[0].ParentOrder.BuyingHouseID > 1))
                        //{
                        //    FileUpload1.Enabled = false;
                        //    chkBoxStcApproved.Enabled = false;
                        //    txtComments.Enabled = false;
                        //    hlkViewMe.Enabled = (string.IsNullOrEmpty(objFits.FilePath)) ? false : true;
                        //}
                        //else
                        //{
                        //    FileUpload1.Enabled = true;
                        //}
                    }

                    else if (objFits.FitsTrack.Count > 0 && objFits.FitsTrack[objFits.FitsTrack.Count - 1].PlanningFor == "STC")
                    {
                        //commented by uday 2-1-2016
                        //if (ApplicationHelper.LoggedInUser.UserData.Designation == Designation.iKandi_Technical_Technologist || ApplicationHelper.LoggedInUser.UserData.Designation == Designation.iKandi_Technical_Manager)// || (ApplicationHelper.LoggedInUser.UserData.Designation == Designation.BIPL_Merchandising_FitMerchant && objOrderDetailCollection[0].ParentOrder.BuyingHouseID > 1))
                        //{
                        //    chkBoxStcApproved.Enabled = false;
                        //    txtComments.Enabled = false;
                        //    FileUpload1.Enabled = false;
                        //    hlkViewMe.Enabled = (string.IsNullOrEmpty(objFits.FilePath)) ? false : true;
                        //}
                    }
                }
                else
                {
                    isNewRow = true;
                    gvBuyingHouse.DataSource = "a";
                    gvBuyingHouse.DataBind();
                    Boolean EnableIKnadiControl = (IsIKandiUser || isBiplAllowed) && isNewRow && !(objFits.IsStcApproved);
                    Boolean EnableBiplUserControl = IsBiplUser && !isNewRow && !(objFits.IsStcApproved);
                    grdFitsBhRemarks.Enabled = EnableIKnadiControl;
                    grdFitsBIPLRemark.Enabled = EnableBiplUserControl;
                }

                if (objFits != null)
                {
                    //hdnMon.Value = objFits.Department.Mon.ToString();
                    //hdnTue.Value = objFits.Department.Tue.ToString();
                    //hdnWed.Value = objFits.Department.Wed.ToString();
                    //hdnThu.Value = objFits.Department.Thu.ToString();
                    //hdnFri.Value = objFits.Department.Fri.ToString();
                }
                btnSaveAll.Visible = true;
            }
        }

        protected void ddlRequest_SelectedIndexChanged(Object sender, EventArgs e)
        {
            if (((DropDownList)sender).SelectedValue == "STC")
            {
                //if (objFits != null)
                //{
                if (IsBiplUser && !isNewRow)
                {
                    ((CheckBox)gvBuyingHouse.Rows[gvBuyingHouse.Rows.Count - 1].FindControl("chkBoxReferenceSample")).Enabled = true;
                    //((CheckBox)gvBuyingHouse.Rows[rptFitSection.Items.Count - 1].FindControl("chkBoxReferenceSample")).Enabled = true;
                    //if (IsIKandiUser || isBiplAllowed)
                    //{
                    chkBoxStcApproved.Enabled = true;
                    txtComments.Enabled = true;
                    FileUpload1.Enabled = true;
                    //hlkViewMe.Enabled = (string.IsNullOrEmpty(objFits.FilePath)) ? false : true;
                    //}

                }
                else
                {
                    //((CheckBox)rptFitSection.Items[rptFitSection.Items.Count - 1].FindControl("chkBoxReferenceSample")).Enabled = true;
                    ((CheckBox)gvBuyingHouse.Rows[gvBuyingHouse.Rows.Count - 1].FindControl("chkBoxReferenceSample")).Enabled = true;
                    if (IsIKandiUser || isBiplAllowed)
                    {
                        chkBoxStcApproved.Enabled = false;
                        txtComments.Enabled = false;
                        FileUpload1.Enabled = false;
                    }
                }
                // }

            }
            else
            {
                ((CheckBox)gvBuyingHouse.Rows[gvBuyingHouse.Rows.Count - 1].FindControl("chkBoxReferenceSample")).Enabled = false;
                //Label lblFitPlanningFor = ((Label)rptFitSection.Items[rptFitSection.Items.Count - 1].FindControl("lblFitPlanningFor"));
                //lblFitPlanningFor.Text = ((DropDownList)sender).SelectedValue;
                if (IsIKandiUser || isBiplAllowed)
                {
                    chkBoxStcApproved.Enabled = false;
                    txtComments.Enabled = false;
                    FileUpload1.Enabled = false;
                    hlkViewMe.Enabled = (objFits == null || string.IsNullOrEmpty(objFits.FilePath)) ? false : true;
                }
            }
        }


        protected void rptFitsAccessories_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                string OrderDetailsID = (DataBinder.Eval(e.Item.DataItem, "OrderDetailsID").ToString());
                string AccessoriesName = (DataBinder.Eval(e.Item.DataItem, "AccessoriesName").ToString());

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
            arr.Add(1);
            arr.Add(1);
            arr.Add(1);
            arr.Add(1);
            arr.Add(1);
            arr.Add("0");
            arr.Add("0");
            arr.Add(1);
            arr.Add(1);
            arr.Add(1);
            arr.Add(1);
            arr.Add(1);

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

        protected void gvBuyingHouse_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (objFits == null || objFits.Id < 0)
                    return;

                Boolean EnableIKnadiControl = (IsIKandiUser || isBiplAllowed) && isNewRow && !(objFits.IsStcApproved);
                Boolean EnableBiplUserControl = IsBiplUser && !isNewRow && !(objFits.IsStcApproved);

                DropDownList ddlFitsComments = ((DropDownList)e.Row.FindControl("ddlFitsComments"));
                DropDownList ddlRequest = ((DropDownList)e.Row.FindControl("ddlRequest"));
                TextBox txtNextPlannedFitDate = ((TextBox)e.Row.FindControl("txtNextPlannedFitDate"));
                FileUpload fileIkandiUpload = ((FileUpload)e.Row.FindControl("fileIkandiUpload"));
                HyperLink hlkViewMe = ((HyperLink)e.Row.FindControl("hlkViewMe"));
                CheckBox chkBoxReferenceSample = ((CheckBox)e.Row.FindControl("chkBoxReferenceSample"));
                CustomValidator cvIkandiFileUpload = ((CustomValidator)e.Row.FindControl("cvIkandiFileUpload"));

                //CustomValidator cvBIPLFileUpload = ((CustomValidator)e.Row.FindControl("cvBIPLFileUpload"));

                Label lblFitPlanningFor = ((Label)e.Row.FindControl("lblFitPlanningFor"));
                FileUpload fileBiplUpload = ((FileUpload)e.Row.FindControl("fileBiplUpload"));
                CheckBox chkBoxAcknowledge = ((CheckBox)e.Row.FindControl("chkBoxAcknowledge"));
                TextBox txtAckDate = ((TextBox)e.Row.FindControl("txtAckDate"));
                TextBox txtPlannedDispatchDate = ((TextBox)e.Row.FindControl("txtPlannedDispatchDate"));
                TextBox txtSuggestedFitDate = ((TextBox)e.Row.FindControl("txtSuggestedFitDate"));
                HyperLink hlkViewMeBipl = ((HyperLink)e.Row.FindControl("hlkViewMeBipl"));

                if (prevReqIndex > -1)
                {
                    if (prevReqIndex == 13)
                    {
                        ddlFitsComments.SelectedIndex = prevReqIndex - 1;
                    }
                    else
                    {
                        ddlFitsComments.SelectedIndex = prevReqIndex;
                    }
                    ddlRequest.SelectedIndex = prevReqIndex;
                    ddlFitsComments.Enabled = false;
                }
                else
                {
                    ddlFitsComments.SelectedIndex = e.Row.DataItemIndex;
                    ddlRequest.SelectedIndex = e.Row.DataItemIndex + 1;
                    ddlFitsComments.Enabled = false;
                }

                lblFitPlanningFor.Text = ddlRequest.SelectedValue;
                txtNextPlannedFitDate.Enabled = EnableIKnadiControl;

                ddlRequest.Enabled = EnableIKnadiControl;
                cvIkandiFileUpload.Enabled = EnableIKnadiControl;

                fileIkandiUpload.Enabled = (IsIKandiUser || isBiplAllowed) && !objFits.IsStcApproved;
                //fileBiplUpload.Enabled = IsBiplUser && !objFits.IsStcApproved;
                fileBiplUpload.Enabled = EnableBiplUserControl;
                //cvBIPLFileUpload.Enabled = EnableBiplUserControl;
                chkBoxAcknowledge.Enabled = EnableBiplUserControl;
                txtAckDate.Enabled = EnableBiplUserControl;
                txtPlannedDispatchDate.Enabled = EnableBiplUserControl;
                txtSuggestedFitDate.Enabled = EnableBiplUserControl;
                if (EnableBiplUserControl)
                {
                    hdnIsBiplUser.Value = "1";
                }

                if (IsIKandiUser || isBiplAllowed)
                    cvIkandiFileUpload.Enabled = ddlRequest.Enabled;

                if ((objFits != null && objFits.Id > 0 && objFits.FitsTrack != null && objFits.FitsTrack.Count > 0))
                {
                    FitsTrack rowFitsTrack = ((FitsTrack)e.Row.DataItem);

                    if (isNewRow && e.Row.DataItemIndex == objFits.FitsTrack.Count - 1)
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
                    cvIkandiFileUpload.Enabled = ddlRequest.Enabled;
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
                        cvIkandiFileUpload.Enabled = ddlRequest.Enabled;
                    }

                    if (IsIKandiUser || isBiplAllowed)
                        cvIkandiFileUpload.Enabled = ddlRequest.Enabled;
                }
                else
                {
                    txtNextPlannedFitDate.Text = GetNextDate(Convert.ToDateTime("1/1/0001"), objFits.Department).ToString("dd MMM yy (ddd)");
                    txtNextPlannedFitDate.Enabled = true;
                }
                if (ddlRequest.SelectedItem.Text == "STC" && (hlkViewMe.Visible == true || hlkViewMe.NavigateUrl != ""))
                {
                    ddlRequest.Enabled = false;
                    cvIkandiFileUpload.Enabled = ddlRequest.Enabled;
                }
            }
        }


        protected void btnSaveAll_Click(object sender, EventArgs e)
        {
            if ((chkBoxStcApproved.Checked && WorkflowControllerInstance.GetDesignationName() == "Production  Merchandiser") || (chkBoxStcApproved.Checked && WorkflowControllerInstance.GetDesignationName() == "DMM") || (chkBoxStcApproved.Checked && WorkflowControllerInstance.GetDesignationName() == "Account Manager") || !(chkBoxStcApproved.Checked))
          {
            try
            {
              SaveFitsDetails();
              if (hdnBiplFilenotupload.Value != "1")
              {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "scr", "alert('Saved Successfully');", true);
              }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
              Page.ClientScript.RegisterStartupScript(Page.GetType(), "scr", "alert('Page could not saved');", true);
            }
          }
          else
          {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "scr", "alert('You cannot approve STC.');", true);
          }
        }

        private void SaveFitsDetails()
        {
          Boolean isNew = true;
          Boolean isAllowed = false;
          CreateNew = Convert.ToInt32(hdnFitsCreateNew.Value);
          NewRefrence = Convert.ToInt32(hdnFitsNewRef.Value);
          ReUse = Convert.ToInt32(hdnFitsReUse.Value);
          ReUseStyleId = Convert.ToInt32(hdnFitsStyleId.Value);
          ReUseStyleNumber = hdnFitsStyleNumber.Value;
          ClientDeptId = Convert.ToInt32(hdnFitsDeptId.Value);
          int iAllow = Convert.ToInt32(hdnBIPLAllowed.Value);
          if (iAllow == 1)
          {
            isBiplAllowed = true;
          }
          else
          {
            isBiplAllowed = false;
          }

          objFits = this.FITsControllerInstance.GetFITsBasicInfo_ForOrderProcess(this.FitsStyle, ClientDeptId, styleid, CreateNew, NewRefrence, ReUse, ReUseStyleId, 1);

          if (objFits != null && objFits.Id > 0)
          {
            isNew = false;
          }
          if (isNew) // Insert will take place for fits
          {
            objFits.Department = new ClientDepartment();
            objFits.Department.DeptID = Convert.ToInt32(ClientDeptId);
            // comment by ravi
            //objFits.Department.Mon = Convert.ToInt32(hdnMon.Value);
            //objFits.Department.Tue = Convert.ToInt32(hdnTue.Value);
            //objFits.Department.Wed = Convert.ToInt32(hdnWed.Value);
            //objFits.Department.Thu = Convert.ToInt32(hdnThu.Value);
            //objFits.Department.Fri = Convert.ToInt32(hdnFri.Value);
            objFits.Department.Mon = 1;
            objFits.Department.Tue = 1;
            objFits.Department.Wed = 1;
            objFits.Department.Thu = 1;
            objFits.Department.Fri = 1;
            objFits.IsStcApproved = false;
            objFits.StyleCodeVersion = FitsStyle;
            objFits.Comments = txtComments.Text;
            objFits.FilePath = "";
              // edit by surendra
            if ((iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.CompanyID ==1) || (iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.CompanyID ==2))
                // end
            {
              int i = 0;
              objFits.FitsTrack = new List<FitsTrack>();

              foreach (GridViewRow gvr in gvBuyingHouse.Rows)
              {
                DropDownList ddlFitsComments = ((DropDownList)gvr.FindControl("ddlFitsComments"));
                DropDownList ddlRequest = ((DropDownList)gvr.FindControl("ddlRequest"));
                TextBox txtNextPlannedFitDate = ((TextBox)gvr.FindControl("txtNextPlannedFitDate"));
                FileUpload fileIkandiUpload = ((FileUpload)gvr.FindControl("fileIkandiUpload"));
                CheckBox chkBoxReferenceSample = ((CheckBox)gvr.FindControl("chkBoxReferenceSample"));

                FitsTrack objFitsTrack = new FitsTrack();
                objFitsTrack.CommentsSentFor = ddlFitsComments.SelectedValue;
                objFitsTrack.NextPlannedDate = (txtNextPlannedFitDate.Text != String.Empty) ? DateHelper.ParseDate(txtNextPlannedFitDate.Text).Value : Convert.ToDateTime("1/1/0001");
                objFitsTrack.PlanningFor = ddlRequest.SelectedValue;
                objFitsTrack.RequiredSample = chkBoxReferenceSample.Checked;
                //System.Web.UI.WebControls.Button btn = (System.Web.UI.WebControls.Button)this.FindControl("btnSaveAll");
                var fileNameIkandi = FitsStyle.ToString() + "-" + DepartmentName + "-" + ddlFitsComments.SelectedValue + "-" + "IKANDI";
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

              objFits = this.FITsControllerInstance.CreateFitsForOrderProcess(objFits, isAllowed, styleid, CreateNew, NewRefrence, ReUse, ReUseStyleId);
              //SaveBHRemark();
              //SaveBIPLRemark();
            }
            else
            {
              objFits.SampleTrackingDate = DateHelper.ParseDate(txtTrackDate.Text).Value;

              if (fileUploadSpecs.HasFile)
              {
                var fileNameStyle = FitsStyle.ToString() + "-" + DepartmentName;
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
              if (objFits.SpecsUploadDate == DateTime.MinValue)
              {
                objFits.SpecsUploadDate = DateTime.Now;
              }

              objFits = this.FITsControllerInstance.CreateFitsForOrderProcess(objFits, isAllowed, styleid, CreateNew, NewRefrence, ReUse, ReUseStyleId);
              
              //SaveBHRemark();
              //SaveBIPLRemark();
              //objFits = this.FITsControllerInstance.CreateFITs(objFits, false);
            }
          }
          else // Update will take place for fits
          {
            objFits.Department = new ClientDepartment();
            objFits.Department.DeptID = ClientDeptId;
            //objFits.Department.Mon = Convert.ToInt32(hdnMon.Value);
            //objFits.Department.Tue = Convert.ToInt32(hdnTue.Value);
            //objFits.Department.Wed = Convert.ToInt32(hdnWed.Value);
            //objFits.Department.Thu = Convert.ToInt32(hdnThu.Value);
            //objFits.Department.Fri = Convert.ToInt32(hdnFri.Value);
            objFits.Department.Mon = 1;
            objFits.Department.Tue = 1;
            objFits.Department.Wed = 1;
            objFits.Department.Thu = 1;
            objFits.Department.Fri = 1;
            objFits.IsStcApproved = chkBoxStcApproved.Checked;
            objFits.StyleCodeVersion = this.FitsStyle;
            objFits.Comments = txtComments.Text;
            System.Web.UI.WebControls.Button btn = (System.Web.UI.WebControls.Button)this.FindControl("btnSaveAll");

            var fileNameSTC = this.FitsStyle.ToString() + "-" + DepartmentName + "-" + "STC Approved Sample";
            objFits.FilePath = (objFits.IsStcApproved && FileUpload1.HasFile) ? SaveUploadedFile(FileUpload1, fileNameSTC) : objFits.FilePath;

            if (objFits.SealDate == Convert.ToDateTime("1/1/0001"))
            {
              objFits.SealDate = objFits.IsStcApproved ? DateTime.Now : objFits.SealDate;
            }

            objFits.SampleTrackingDate = DateHelper.ParseDate(txtTrackDate.Text).Value;

            if (fileUploadSpecs.HasFile)
            {
              var fileNameStyle = this.FitsStyle.ToString() + "-" + DepartmentName;
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

            foreach (GridViewRow gvr in gvBuyingHouse.Rows)
            {
              DropDownList ddlFitsComments = ((DropDownList)gvr.FindControl("ddlFitsComments"));
              DropDownList ddlRequest = ((DropDownList)gvr.FindControl("ddlRequest"));
              Label lblFitPlanningFor = ((Label)gvr.FindControl("lblFitPlanningFor"));
              TextBox txtNextPlannedFitDate = ((TextBox)gvr.FindControl("txtNextPlannedFitDate"));
              TextBox txtSuggestedFitDate = ((TextBox)gvr.FindControl("txtSuggestedFitDate"));
              FileUpload fileIkandiUpload = ((FileUpload)gvr.FindControl("fileIkandiUpload"));
              FileUpload fileBiplUpload = ((FileUpload)gvr.FindControl("fileBiplUpload"));
              CheckBox chkBoxAcknowledge = ((CheckBox)gvr.FindControl("chkBoxAcknowledge"));
              TextBox txtAckDate = ((TextBox)gvr.FindControl("txtAckDate"));
              TextBox txtPlannedDispatchDate = ((TextBox)gvr.FindControl("txtPlannedDispatchDate"));
              HyperLink hlkViewMe = ((HyperLink)gvr.FindControl("hlkViewMe"));
              CheckBox chkBoxReferenceSample = ((CheckBox)gvr.FindControl("chkBoxReferenceSample"));
              Label lblValidateFileUpload = ((Label)gvr.FindControl("lblValidateFileUpload"));
              HyperLink hlkViewMeBipl = ((HyperLink)gvr.FindControl("hlkViewMeBipl"));

              hdnBiplFilenotupload.Value = "0";
              lblValidateFileUpload.Text = "";

              if (hdnIsBiplUser.Value == "1")
              {
                if (hlkViewMeBipl.Visible == false)
                {
                  if (fileBiplUpload.Enabled == true)
                  {
                    if (!fileBiplUpload.HasFile)
                    {
                      hdnBiplFilenotupload.Value = "1";
                      lblValidateFileUpload.Text = "File upload is required";
                      return;
                    }
                  }
                }
              }

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
              var fileNameIkandi = this.FitsStyle.ToString() + "-" + DepartmentName + "-" + ddlFitsComments.SelectedValue + "-" + "IKANDI";
              var fileNameBipl = this.FitsStyle.ToString() + "-" + DepartmentName + "-" + ddlRequest.SelectedValue + "-" + "BIPL";
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

            int UserId = iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.UserID;

            objFits = this.FITsControllerInstance.UpdateFits_ForOrderProcess(objFits, status, styleid, CreateNew, NewRefrence, ReUse, ReUseStyleId, UserId);

          }
          if (grdFitsBhRemarks.Enabled == true)
          {
            SaveBHRemark();
          }
          if (grdFitsBIPLRemark.Enabled == true)
          {
            SaveBIPLRemark();
          }
          BindControlgvNew(CreateNew, NewRefrence, ReUse, ReUseStyleId);
          BindControls(CreateNew, NewRefrence, ReUse, ReUseStyleId, ReUseStyleNumber);
          BindBHGrd(CreateNew, NewRefrence, ReUse, ReUseStyleId, ReUseStyleNumber);
          BindBIPLGrd(CreateNew, NewRefrence, ReUse, ReUseStyleId, ReUseStyleNumber);

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

          //System.Web.UI.WebControls.Button btnSave = (System.Web.UI.WebControls.Button)this.FindControl("btnSaveAll");
          //System.Web.UI.WebControls.Panel pnlHide = (System.Web.UI.WebControls.Panel)btnSave.Parent.Parent.Parent.Parent.Parent.FindControl("pnlForm");
          //pnlHide.Visible = false;
          //System.Web.UI.WebControls.Panel pnlShow = (System.Web.UI.WebControls.Panel)btnSave.Parent.Parent.Parent.Parent.Parent.FindControl("pnlMessage");
          //pnlShow.Visible = true;
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



        protected void Button1_Click(object sender, EventArgs e)
        {

            CreateNew = Convert.ToInt32(hdnFitsCreateNew.Value);
            NewRefrence = Convert.ToInt32(hdnFitsNewRef.Value);
            ReUse = Convert.ToInt32(hdnFitsReUse.Value);
            ReUseStyleId = Convert.ToInt32(hdnFitsStyleId.Value);
            ReUseStyleNumber = hdnFitsStyleNumber.Value;
            ViewState["BHData"] = null;
            ViewState["BIPLData"] = null;
            BindControls(CreateNew, NewRefrence, ReUse, ReUseStyleId, ReUseStyleNumber);
            BindControlgvNew(CreateNew, NewRefrence, ReUse, ReUseStyleId);
            BindBHGrd(CreateNew, NewRefrence, ReUse, ReUseStyleId, ReUseStyleNumber);
            BindBIPLGrd(CreateNew, NewRefrence, ReUse, ReUseStyleId, ReUseStyleNumber);

        }

        protected void gvFits_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //if (e.Row.RowType != DataControlRowType.DataRow)
            //    return;
            //OrderDetail od = (e.Row.DataItem as OrderDetail);

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

            Repeater rptFitsAccessories = e.Row.FindControl("rptFitsAccessories") as Repeater;
            if (od.AccessoriesETA != null)
            {
                if (od.AccessoriesETA.Count > 0)
                {
                    rptFitsAccessories.DataSource = od.AccessoriesETA;
                    rptFitsAccessories.DataBind();
                }
            }

        }

        //Added By Ashish on 22/5/2015
        //For Fits BH Remark
        protected void BindBHGrd(int CreateNew, int NewRef, int ReUse, int ReUseStyleId, string ReUseStyleNumber)
        {
            DataSet dsgrd = new DataSet();
            DataTable dtBHRemark = new DataTable();
            string RemarksType = "BIH";
            ClientDeptId = Convert.ToInt32(hdnFitsDeptId.Value);

            if (ViewState["BHData"] == null)
            {
                dsgrd = obj_ProcessController.GetFitsRemark(FitsStyle, styleid, strClientId, ClientDeptId, CreateNew, NewRef, ReUse, ReUseStyleId, RemarksType);
                dtBHRemark = dsgrd.Tables[0];
                grdFitsBhRemarks.DataSource = dtBHRemark;
                grdFitsBhRemarks.DataBind();
                ViewState["BHData"] = dtBHRemark;
            }
            else
            {
                DataTable dtnew = (DataTable)(ViewState["BHData"]);
                grdFitsBhRemarks.DataSource = dtnew;
                grdFitsBhRemarks.DataBind();
                ViewState["BHData"] = dtnew;
            }


            //if (CreateNew == 1)
            //{
            //    dsgrd = obj_ProcessController.GetFitsRemark(FitsStyle, styleid, strClientId, ClientDeptId, CreateNew, NewRef, ReUse, ReUseStyleId, RemarksType);
            //    grdFitsBhRemarks.DataSource = dsgrd.Tables[0];
            //    grdFitsBhRemarks.DataBind();
            //    ViewState["BHData"] = dsgrd.Tables[0];

            //}
            //else if (NewRef == 1)
            //{
            //    dsgrd = obj_ProcessController.GetFitsRemark(FitsStyle, styleid, strClientId, ClientDeptId, CreateNew, NewRef, ReUse, ReUseStyleId, RemarksType);
            //    grdFitsBhRemarks.DataSource = dsgrd.Tables[0];
            //    grdFitsBhRemarks.DataBind();
            //    ViewState["BHData"] = dsgrd.Tables[0];
            //}
            //else if (ReUse == 1)
            //{
            //    dsgrd = obj_ProcessController.GetFitsRemark(FitsStyle, styleid, strClientId, ClientDeptId, CreateNew, NewRef, ReUse, ReUseStyleId, RemarksType);
            //    grdFitsBhRemarks.DataSource = dsgrd.Tables[0];
            //    grdFitsBhRemarks.DataBind();
            //    ViewState["BHData"] = dsgrd.Tables[0];
            //}
            //else
            //{

            //}

        }
        protected void grdFitsBhRemarks_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string Username = iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.FirstName;
            //string[] name = Username.Split('@');
            string date = DateTime.Now.ToString("dd MMM yyyy");
            if (e.CommandName == "Insert")
            {
                TextBox txtRemarkFooter = grdFitsBhRemarks.FooterRow.FindControl("txtRemarkFooter") as TextBox;
                LinkButton abtnAdd = grdFitsBhRemarks.FooterRow.FindControl("abtnAdd") as LinkButton;

                DataTable dtnew = new DataTable();
                string Remark = txtRemarkFooter.Text.Trim();

                if (Remark == "")
                {
                    ShowAlert("Please Enter Remarks");
                    return;
                }
                else
                {
                    if (ViewState["BHData"] != null)
                    {
                        dtnew = (DataTable)(ViewState["BHData"]);
                        for (int i = 0; i < grdFitsBhRemarks.Rows.Count; i++)
                        {
                            dtnew.Rows[i]["BHRemark"] = ((TextBox)grdFitsBhRemarks.Rows[i].FindControl("txtRemarkEdit")).Text;
                        }
                        dtnew.AcceptChanges();
                        sl = dtnew.Rows.Count;
                        dtnew.Rows.Add(sl + 1, styleid, Username + "(" + date + "): ", Remark, sl + 1);
                        ViewState["BHData"] = dtnew;
                    }
                    //if (ViewState["BHData"] != null)
                    //{
                    //    dtnew = (DataTable)(ViewState["BHData"]);
                    //    sl = dtnew.Rows.Count;
                    //    dtnew.Rows.Add(0, styleid, Remark, sl + 1);
                    //    ViewState["BHData"] = dtnew;
                    //}
                }
                BindBHGrd(CreateNew, NewRefrence, ReUse, ReUseStyleId, ReUseStyleNumber);
            }
            if (e.CommandName == "addnew")
            {

                Table tblGrdviewApplet = (Table)grdFitsBhRemarks.Controls[0];
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
                    if (ViewState["BHData"] != null)
                    {
                        dtnew = (DataTable)(ViewState["BHData"]);
                        for (int i = 0; i < grdFitsBhRemarks.Rows.Count; i++)
                        {
                            dtnew.Rows[i]["BHRemark"] = ((TextBox)grdFitsBhRemarks.Rows[i].FindControl("txtRemarkEdit")).Text;
                        }
                        dtnew.AcceptChanges();
                        sl = dtnew.Rows.Count;
                        dtnew.Rows.Add(sl + 1, styleid, Username + "(" + date + "): ", Remark, sl + 1);
                        ViewState["BHData"] = dtnew;
                    }
                }
                BindBHGrd(CreateNew, NewRefrence, ReUse, ReUseStyleId, ReUseStyleNumber);
            }
        }
        protected void grdFitsBhRemarks_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            bool EnableBH = grdFitsBhRemarks.Enabled;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Literal ltIndex = (Literal)e.Row.FindControl("ltIndex");
                ltIndex.Text = ((grdFitsBhRemarks.PageIndex * grdFitsBhRemarks.PageSize) + e.Row.RowIndex + 1).ToString();

                LinkButton lnkDelete = (LinkButton)e.Row.FindControl("lnkDelete");
                if (!EnableBH)
                {
                    lnkDelete.Visible = false;
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                LinkButton abtnAdd = (LinkButton)e.Row.FindControl("abtnAdd");
                if (!EnableBH)
                {
                    abtnAdd.Visible = false;
                }
            }
            if (e.Row.RowType == DataControlRowType.EmptyDataRow)
            {
                LinkButton addbutton = (LinkButton)e.Row.FindControl("addbutton");
                if (!EnableBH)
                {
                    addbutton.Visible = false;
                }
            }
        }
        protected void grdFitsBhRemarks_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = grdFitsBhRemarks.Rows[e.RowIndex];
            HiddenField hdndataTableId = (HiddenField)row.FindControl("hdndataTableId");
            Label lblFitsBHId = (Label)row.FindControl("lblFitsBHId");
            DataTable dtnew = new DataTable();
            string RemarksType = "BIH";
            if (ViewState["BHData"] != null)
            {
                dtnew = (DataTable)(ViewState["BHData"]);
                if (lblFitsBHId.Text != "")
                {
                    dtnew.Rows.Remove(dtnew.Select("BHId=" + lblFitsBHId.Text)[0]);
                    int IsDelete = obj_ProcessController.DeleteFitingRemarkById(Convert.ToInt32(lblFitsBHId.Text), RemarksType);
                }
                else
                {
                    dtnew.Rows.Remove(dtnew.Select("BHId=" + hdndataTableId.Value)[0]);
                }
                ViewState["BHData"] = dtnew;
            }


            grdFitsBhRemarks.EditIndex = -1;
            BindBHGrd(CreateNew, NewRefrence, ReUse, ReUseStyleId, ReUseStyleNumber);
        }
        protected void SaveBHRemark()
        {
            RiskAnalysisOB objRisk = new RiskAnalysisOB();

            CreateNew = Convert.ToInt32(hdnFitsCreateNew.Value);
            NewRefrence = Convert.ToInt32(hdnFitsNewRef.Value);
            ReUse = Convert.ToInt32(hdnFitsReUse.Value);
            ReUseStyleId = Convert.ToInt32(hdnFitsStyleId.Value);
            ReUseStyleNumber = hdnFitsStyleNumber.Value;
            ClientDeptId = Convert.ToInt32(hdnFitsDeptId.Value);
            int UserId = iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.UserID;
            int RiskFabricId = 0;
            int StyleSequence = 0;
            string RemarksType = "BIH";

            Control control = null;
            control = grdFitsBhRemarks.Controls[0].Controls[0];
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
                        int isave = obj_ProcessController.InsertUpdateFitsRemark(FitsStyle, styleid, strClientId, ClientDeptId, CreateNew, NewRefrence, ReUse, ReUseStyleId, RemarksEmpty, RiskFabricId, StyleSequence, RemarksType, UserId);
                    }
                }
            }
            else
            {

                for (int i = 0; i < grdFitsBhRemarks.Rows.Count; i++)
                {
                    TextBox RemarkEdit = (TextBox)grdFitsBhRemarks.Rows[i].FindControl("txtRemarkEdit");
                    Label lblFitsBHId = (Label)grdFitsBhRemarks.Rows[i].FindControl("lblFitsBHId");
                    HiddenField hdnStyleSequence = (HiddenField)grdFitsBhRemarks.Rows[i].FindControl("hdnStyleSequence");
                    string Remark = RemarkEdit.Text.Trim();

                    if (lblFitsBHId != null)
                    {
                        if (lblFitsBHId.Text == "")
                        {
                            RiskFabricId = 0;
                        }
                        else
                        {
                            RiskFabricId = Convert.ToInt32(lblFitsBHId.Text);
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
                            int isave = obj_ProcessController.InsertUpdateFitsRemark(FitsStyle, styleid, strClientId, ClientDeptId, CreateNew, NewRefrence, ReUse, ReUseStyleId, Remark, RiskFabricId, StyleSequence, RemarksType, UserId);
                        }
                    }

                }
                var footerRow = grdFitsBhRemarks.FooterRow;
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
                            int isave = obj_ProcessController.InsertUpdateFitsRemark(FitsStyle, styleid, strClientId, ClientDeptId, CreateNew, NewRefrence, ReUse, ReUseStyleId, RemarkFooter, RiskFabricId, StyleSequence, RemarksType, UserId);
                        }
                    }
                }
            }
            int SaveData = obj_ProcessController.InsertForReuseFitsRemark(styleid, ReUse, RemarksType, UserId);

            ViewState["BHData"] = null;
            BindBHGrd(CreateNew, NewRefrence, ReUse, ReUseStyleId, ReUseStyleNumber);
        }

        //For Fits BIPL Remark
        protected void BindBIPLGrd(int CreateNew, int NewRef, int ReUse, int ReUseStyleId, string ReUseStyleNumber)
        {
            DataSet dsgrd = new DataSet();
            DataTable dtBIPLRemark = new DataTable();
            ClientDeptId = Convert.ToInt32(hdnFitsDeptId.Value);
            string RemarksType = "BIPL";
            if (ViewState["BIPLData"] == null)
            {
                dsgrd = obj_ProcessController.GetFitsRemark(FitsStyle, styleid, strClientId, ClientDeptId, CreateNew, NewRef, ReUse, ReUseStyleId, RemarksType);
                dtBIPLRemark = dsgrd.Tables[0];
                //System.Data.DataColumn newColumn = new System.Data.DataColumn("BIPL_Enabled", typeof(bool));
                //newColumn.DefaultValue = BIPL_Enabled;
                //dtBIPLRemark.Columns.Add(newColumn);

                //foreach (DataRow row in dtBIPLRemark.Rows)
                //{
                //    row["BIPL_Enabled"] = BIPL_Enabled;
                //    dtBIPLRemark.Rows.Add(row);
                //}
                grdFitsBIPLRemark.DataSource = dtBIPLRemark;
                grdFitsBIPLRemark.DataBind();
                ViewState["BIPLData"] = dtBIPLRemark;
            }
            else
            {
                DataTable dtnew = (DataTable)(ViewState["BIPLData"]);
                grdFitsBIPLRemark.DataSource = dtnew;
                grdFitsBIPLRemark.DataBind();
                ViewState["BIPLData"] = dtnew;
            }

            //if (CreateNew == 1)
            //{
            //    dsgrd = obj_ProcessController.GetFitsRemark(FitsStyle, styleid, strClientId, ClientDeptId, CreateNew, NewRef, ReUse, ReUseStyleId, RemarksType);
            //    grdFitsBIPLRemark.DataSource = dsgrd.Tables[0];
            //    grdFitsBIPLRemark.DataBind();
            //    ViewState["BIPLData"] = dsgrd.Tables[0];

            //}
            //else if (NewRef == 1)
            //{
            //    dsgrd = obj_ProcessController.GetFitsRemark(FitsStyle, styleid, strClientId, ClientDeptId, CreateNew, NewRef, ReUse, ReUseStyleId, RemarksType);
            //    grdFitsBIPLRemark.DataSource = dsgrd.Tables[0];
            //    grdFitsBIPLRemark.DataBind();
            //    ViewState["BIPLData"] = dsgrd.Tables[0];
            //}
            //else if (ReUse == 1)
            //{
            //    dsgrd = obj_ProcessController.GetFitsRemark(FitsStyle, styleid, strClientId, ClientDeptId, CreateNew, NewRef, ReUse, ReUseStyleId, RemarksType);
            //    grdFitsBIPLRemark.DataSource = dsgrd.Tables[0];
            //    grdFitsBIPLRemark.DataBind();
            //    ViewState["BIPLData"] = dsgrd.Tables[0];
            //}
            //else
            //{

            //}

        }
        protected void grdFitsBIPLRemark_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string Username = iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.FirstName;
            //string[] name = Username.Split('@');
            string date = DateTime.Now.ToString("dd MMM yyyy");
            if (e.CommandName == "Insert")
            {
                TextBox txtRemarkFooter = grdFitsBIPLRemark.FooterRow.FindControl("txtRemarkFooter") as TextBox;
                LinkButton abtnAdd = grdFitsBIPLRemark.FooterRow.FindControl("abtnAdd") as LinkButton;

                DataTable dtnew = new DataTable();
                string Remark = txtRemarkFooter.Text.Trim();

                if (Remark == "")
                {
                    ShowAlert("Please Enter Remarks");
                    return;
                }
                else
                {
                    if (ViewState["BIPLData"] != null)
                    {
                        dtnew = (DataTable)(ViewState["BIPLData"]);
                        for (int i = 0; i < grdFitsBIPLRemark.Rows.Count; i++)
                        {
                            dtnew.Rows[i]["BIPLRemark"] = ((TextBox)grdFitsBIPLRemark.Rows[i].FindControl("txtRemarkEdit")).Text;
                        }
                        dtnew.AcceptChanges();
                        sl = dtnew.Rows.Count;
                        dtnew.Rows.Add(sl + 1, styleid, Username + "(" + date + "): ", Remark, sl + 1);
                        ViewState["BIPLData"] = dtnew;
                    }
                    //if (ViewState["BIPLData"] != null)
                    //{
                    //    dtnew = (DataTable)(ViewState["BIPLData"]);
                    //    sl = dtnew.Rows.Count;
                    //    dtnew.Rows.Add(0, styleid, txtRemarkFooter.Text.Trim(), sl + 1);
                    //    ViewState["BIPLData"] = dtnew;
                    //}
                }
                //abtnAdd.CssClass.Replace("FooterShow link", "Footerhide link");
                BindBIPLGrd(CreateNew, NewRefrence, ReUse, ReUseStyleId, ReUseStyleNumber);
            }
            if (e.CommandName == "addnew")
            {

                Table tblGrdviewApplet = (Table)grdFitsBIPLRemark.Controls[0];
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
                    if (ViewState["BIPLData"] != null)
                    {
                        dtnew = (DataTable)(ViewState["BIPLData"]);
                        for (int i = 0; i < grdFitsBIPLRemark.Rows.Count; i++)
                        {
                            dtnew.Rows[i]["BIPLRemark"] = ((TextBox)grdFitsBIPLRemark.Rows[i].FindControl("txtRemarkEdit")).Text;
                        }
                        dtnew.AcceptChanges();
                        sl = dtnew.Rows.Count;
                        dtnew.Rows.Add(sl + 1, styleid, Username + "(" + date + "): ", Remark, sl + 1);
                        ViewState["BIPLData"] = dtnew;
                    }
                }
                BindBIPLGrd(CreateNew, NewRefrence, ReUse, ReUseStyleId, ReUseStyleNumber);
            }
        }
        protected void grdFitsBIPLRemark_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            bool EnableBIPL = grdFitsBIPLRemark.Enabled;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Literal ltIndex = (Literal)e.Row.FindControl("ltIndex");
                ltIndex.Text = ((grdFitsBIPLRemark.PageIndex * grdFitsBIPLRemark.PageSize) + e.Row.RowIndex + 1).ToString();
                LinkButton lnkDelete = (LinkButton)e.Row.FindControl("lnkDelete");
                if (!EnableBIPL)
                {
                    lnkDelete.Visible = false;
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                LinkButton abtnAdd = (LinkButton)e.Row.FindControl("abtnAdd");
                if (!EnableBIPL)
                {
                    abtnAdd.Visible = false;
                }
            }
            if (e.Row.RowType == DataControlRowType.EmptyDataRow)
            {
                LinkButton addbutton = (LinkButton)e.Row.FindControl("addbutton");
                if (!EnableBIPL)
                {
                    addbutton.Visible = false;
                }
            }
        }
        protected void grdFitsBIPLRemark_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = grdFitsBIPLRemark.Rows[e.RowIndex];
            HiddenField hdndataTableId = (HiddenField)row.FindControl("hdndataTableId");
            Label lblFitsBIPLId = (Label)row.FindControl("lblFitsBIPLId");
            //HiddenField hdnBHIdId = (HiddenField)row.FindControl("hdnBHIdId");
            DataTable dtnew = new DataTable();
            string RemarksType = "BIPL";
            if (ViewState["BIPLData"] != null)
            {
                dtnew = (DataTable)(ViewState["BIPLData"]);
                if (lblFitsBIPLId.Text != "")
                {
                    dtnew.Rows.Remove(dtnew.Select("BIPLRemarkId=" + lblFitsBIPLId.Text)[0]);
                    int IsDelete = obj_ProcessController.DeleteFitingRemarkById(Convert.ToInt32(lblFitsBIPLId.Text), RemarksType);
                }
                else
                {
                    dtnew.Rows.Remove(dtnew.Select("BIPLRemarkId=" + hdndataTableId.Value)[0]);
                }
                ViewState["BIPLData"] = dtnew;
            }


            grdFitsBhRemarks.EditIndex = -1;
            BindBIPLGrd(CreateNew, NewRefrence, ReUse, ReUseStyleId, ReUseStyleNumber);
        }
        protected void SaveBIPLRemark()
        {
            RiskAnalysisOB objRisk = new RiskAnalysisOB();

            CreateNew = Convert.ToInt32(hdnFitsCreateNew.Value);
            NewRefrence = Convert.ToInt32(hdnFitsNewRef.Value);
            ReUse = Convert.ToInt32(hdnFitsReUse.Value);
            ReUseStyleId = Convert.ToInt32(hdnFitsStyleId.Value);
            ReUseStyleNumber = hdnFitsStyleNumber.Value;
            ClientDeptId = Convert.ToInt32(hdnFitsDeptId.Value);
            int UserId = iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.UserID;
            int RiskFabricId = 0;
            int StyleSequence = 0;
            string RemarksType = "BIPL";

            Control control = null;
            control = grdFitsBIPLRemark.Controls[0].Controls[0];
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
                        int isave = obj_ProcessController.InsertUpdateFitsRemark(FitsStyle, styleid, strClientId, ClientDeptId, CreateNew, NewRefrence, ReUse, ReUseStyleId, RemarksEmpty, RiskFabricId, StyleSequence, RemarksType, UserId);
                    }
                }
            }
            else
            {

                for (int i = 0; i < grdFitsBIPLRemark.Rows.Count; i++)
                {
                    TextBox RemarkEdit = (TextBox)grdFitsBIPLRemark.Rows[i].FindControl("txtRemarkEdit");
                    Label lblFitsBIPLId = (Label)grdFitsBIPLRemark.Rows[i].FindControl("lblFitsBIPLId");
                    HiddenField hdnStyleSequence = (HiddenField)grdFitsBIPLRemark.Rows[i].FindControl("hdnStyleSequence");
                    string Remark = RemarkEdit.Text.Trim();

                    if (lblFitsBIPLId != null)
                    {
                        if (lblFitsBIPLId.Text == "")
                        {
                            RiskFabricId = 0;
                        }
                        else
                        {
                            RiskFabricId = Convert.ToInt32(lblFitsBIPLId.Text);
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
                            int isave = obj_ProcessController.InsertUpdateFitsRemark(FitsStyle, styleid, strClientId, ClientDeptId, CreateNew, NewRefrence, ReUse, ReUseStyleId, Remark, RiskFabricId, StyleSequence, RemarksType, UserId);
                        }
                    }
                }
                var footerRow = grdFitsBIPLRemark.FooterRow;
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
                            int isave = obj_ProcessController.InsertUpdateFitsRemark(FitsStyle, styleid, strClientId, ClientDeptId, CreateNew, NewRefrence, ReUse, ReUseStyleId, RemarkFooter, RiskFabricId, StyleSequence, RemarksType, UserId);
                        }
                    }
                }

            }
            int SaveData = obj_ProcessController.InsertForReuseFitsRemark(styleid, ReUse, RemarksType, UserId);

            ViewState["BIPLData"] = null;
            BindBIPLGrd(CreateNew, NewRefrence, ReUse, ReUseStyleId, ReUseStyleNumber);
        }

        protected void btnSaveSpecUpload_Click(object sender, EventArgs e)
        {
            SaveFitsDetails();
        }

        //END 

        //Added by Ravi on 17/6/2015

        protected void imgPlus_Click(object sender, EventArgs e)
        {
            DataSet dsNewStyle = new DataSet();
            DataTable dt0 = new DataTable();
            DataTable dt1 = new DataTable();
            dt0 = null;
            dt1 = null;

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

                dsNewStyle = obj_ProcessController.GetFitingRemark(StyleCodeNew, Convert.ToInt32(StyleidNew));

                dt0 = dsNewStyle.Tables[0];
                dt1 = dsNewStyle.Tables[1];

                //if ((dt0.Rows.Count > 0) || (dt1.Rows.Count > 0))
                //{
                //    ShowGridPopup.Visible = true;
                //}
                //else
                //{
                //    ShowGridPopup.Visible = false;
                //}

                if (dt0 != null)
                {
                    GridHOPPMFittingRemark.DataSource = dt0;
                    GridHOPPMFittingRemark.DataBind();

                    lblHOPPMFittingRemark.Text = "BH SECTION";

                }
                if (dt1 != null)
                {
                    GridRiskFittingRemark.DataSource = dt1;
                    GridRiskFittingRemark.DataBind();
                    lblRiskFittingRemark.Text = "BIPL SECTION";

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


        //protected void repStyleCodeVirsion_ItemCommand(object source, RepeaterCommandEventArgs e)
        //{
        //    if (e.CommandName == "Show")
        //    {
        //        string StyleidNew = ((HiddenField)e.Item.FindControl("rephdnStyleid")).Value;
        //        string StyleCodeNew = ((HiddenField)e.Item.FindControl("rephdnStylCode")).Value;
        //        ((ImageButton)e.Item.FindControl("imgMinus")).Attributes.Add("style", "display:inline");
        //        ((ImageButton)e.Item.FindControl("imgPlus")).Attributes.Add("style", "display:none");
        //        ShowGridPopup.Attributes.Add("style", "display:inline");

        //        if (StyleidNew != null)
        //        {

        //            DataSet dsNewStyle = obj_ProcessController.GetFitingRemark(StyleCodeNew, Convert.ToInt32(StyleidNew));
        //            //GridRiskFabricRemark.DataSource=dsNewStyle.Tables.
        //            DataTable dt0 = dsNewStyle.Tables[0];                                     
        //            DataTable dt1 = dsNewStyle.Tables[1];
        //            //ShowGridPopup.Visible = true;
        //            if ((dt0.Rows.Count > 0) || (dt1.Rows.Count > 0))
        //            {
        //                ShowGridPopup.Visible = true;
        //            }
        //            else
        //            {
        //                ShowGridPopup.Visible = false;
        //            }

        //            if (dt0 != null)
        //            {
        //                GridHOPPMFittingRemark.DataSource = dt0;
        //                GridHOPPMFittingRemark.DataBind();

        //                lblHOPPMFittingRemark.Text = "BH SECTION";

        //            }
        //            if (dt1 != null)
        //            {
        //                GridRiskFittingRemark.DataSource = dt1;
        //                GridRiskFittingRemark.DataBind();
        //                lblRiskFittingRemark.Text = "BIPL SECTION";

        //            }


        //        }
        //    }
        //    if (e.CommandName == "Hide")
        //    {
        //        ((ImageButton)e.Item.FindControl("imgPlus")).Attributes.Add("style", "display:inline");
        //        ((ImageButton)e.Item.FindControl("imgMinus")).Attributes.Add("style", "display:none");
        //        ShowGridPopup.Attributes.Add("style", "display:none");
        //    }
        //}

        protected void GridHOPPMFittingRemark_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Literal ltIndex = (Literal)e.Row.FindControl("ltIndex");
                ltIndex.Text = ((GridHOPPMFittingRemark.PageIndex * GridHOPPMFittingRemark.PageSize) + e.Row.RowIndex + 1).ToString();
            }

        }

        protected void GridRiskFittingRemark_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Literal ltIndex = (Literal)e.Row.FindControl("ltIndex");
                ltIndex.Text = ((GridRiskFittingRemark.PageIndex * GridRiskFittingRemark.PageSize) + e.Row.RowIndex + 1).ToString();
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


        //EMD
    }
}