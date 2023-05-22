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
using iKandi.Web.Components;
using System.Collections.Generic;
using iKandi.BLL;

namespace iKandi.Web.UserControls.Forms
{
    public partial class frmPPSampleSent_ContractWise : System.Web.UI.UserControl
    {
        iKandi.BLL.OrderProcessController obj_ProcessController = new BLL.OrderProcessController();
        WorkflowController WorkflowControllerInstance = new WorkflowController();

        public int OrderDetailID
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
        InlinePPM inlinePPM = new InlinePPM();
        InlinePPMOrderContract contract = new InlinePPMOrderContract();
        protected void Page_Load(object sender, EventArgs e)
        {
            GetQueryString();

            if (!IsPostBack)
            {
                BindHistorySection();
                BindTopSection();
            }
        }
        private void GetQueryString()
        {
            if (null != Request.QueryString["OrderDetailID"])
            {
                OrderDetailID = Convert.ToInt32(Request.QueryString["OrderDetailID"].ToString());
            }
            if (null != Request.QueryString["FitsStyle"])
            {
                FitsStyle = Request.QueryString["FitsStyle"].ToString();
            }
            if (null != Request.QueryString["StyleCode"])
            {
                StyleCode = Request.QueryString["StyleCode"].ToString();
            }
            if ((FitsStyle == string.Empty) || (FitsStyle == null))
            {
                FitsStyle = StyleCode;
            }
            if (FitsStyle == null)
            {
                FitsStyle = "";
            }
        }

        private void BindTopSection()
        {
            inlinePPM = obj_ProcessController.Get_PPSample_OrderDetaiLDID(OrderDetailID);
            if (inlinePPM.OrderContracts.Count > 0)
            {
                dvTopSection.Visible = true;
                btnTopSubmit.Visible = true;
                contract = inlinePPM.OrderContracts[0];
               
                grdOrderDetails.DataSource = inlinePPM.OrderContracts;
                grdOrderDetails.DataBind();
            }
            else
            {
                dvTopSection.Visible = false;
                btnTopSubmit.Visible = false;
            }

        }
        private void BindHistorySection()
        {
            InlinePPM inlinePPM = obj_ProcessController.Get_PPSample_History_OrderDetaiLDID(OrderDetailID);
            if (inlinePPM.OrderContracts.Count > 0)
            {
                GridView_History.DataSource = inlinePPM.OrderContracts;
                GridView_History.DataBind();
            }
            //else
            //{
            //    dvTopSection.Visible = false;
            //    btnTopSubmit.Visible = false;
            //}

        }

        protected void grdOrderDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HiddenField hdnSerial = e.Row.FindControl("hdnSerial") as HiddenField;
                (hdnSerial.Parent as TableCell).BackColor = System.Drawing.ColorTranslator.FromHtml(Constants.GetSerialNumberColor(((OrderDetail)e.Row.DataItem).ExFactory));

                HiddenField hdnUnit = e.Row.FindControl("hdnUnit") as HiddenField;
                // (hdnUnit.Parent as TableCell).BackColor = System.Drawing.ColorTranslator.FromHtml(ApplicationHelper.GetUnitColor(((OrderDetail)e.Row.DataItem).Unit.FactoryCode));
                HiddenField hdnFabTab = e.Row.FindControl("hdnFabTab") as HiddenField;
                HiddenField hdnDetTab = e.Row.FindControl("hdnDetTab") as HiddenField;
                DropDownList ddlPattern = e.Row.FindControl("ddlPattern") as DropDownList;
                  HiddenField hdnPPSample = e.Row.FindControl("hdnPPSample") as HiddenField;
                  CheckBox chkApproved = e.Row.FindControl("chkApproved") as CheckBox;
                TextBox txtTopSentActual = e.Row.FindControl("txtTopSentActual") as TextBox;
                (txtTopSentActual.Parent as TableCell).BackColor = System.Drawing.ColorTranslator.FromHtml(Constants.GetActualDateColor(((InlinePPMOrderContract)e.Row.DataItem).TopSentTarget, ((InlinePPMOrderContract)e.Row.DataItem).TopSentActual));
                (txtTopSentActual.BackColor) = System.Drawing.ColorTranslator.FromHtml(Constants.GetActualDateColor(((InlinePPMOrderContract)e.Row.DataItem).TopSentTarget, ((InlinePPMOrderContract)e.Row.DataItem).TopSentActual));
                txtTopSentActual.CssClass = "th date_style vertical_text_input " + hdnFabTab.Value + hdnDetTab.Value;
               // ddlPattern.SelectedItem.Text = DataBinder.Eval(e.Row.DataItem, "PPSampleStatus").ToString();
                ddlPattern.SelectedIndex = GetFitsIndex(DataBinder.Eval(e.Row.DataItem, "PPSampleStatus").ToString());
                hdnPPSample.Value = Convert.ToString(GetFitsIndex(DataBinder.Eval(e.Row.DataItem, "PPSampleStatus").ToString()));
                if (chkApproved.Checked == true)
                    ddlPattern.Enabled = false;
                if (hdnPPSample.Value == "")
                    hdnPPSample.Value = "0";
            }
        }
        private int GetFitsIndex(string FitsStatus)
        {
            switch (FitsStatus)
            {

                case "PP Sample 1":
                    return 0;
                case "PP Sample 2":
                    return 1;
                case "PP Sample 3":
                    return 2;
                case "PP Sample 4":
                    return 3;
                case "PP Sample Done":
                    return 4;


            }
            return 0;
        }

        protected void btnTopSubmit_Click(object sender, EventArgs e)
        {
            //InlinePPM inlinePPM = obj_ProcessController.Get_InlineTopSection_by_style_id(styleid, FitsStyle);

            //InlinePPMOrderContract orderContract = inlinePPM.OrderContracts.Find(delegate(InlinePPMOrderContract contract)
            //{
            //    return contract.OrderDetailID == Convert.ToInt32(hdnField.Value);
            //});
            //InlinePPM inlinePPM = new InlinePPM();
            //inlinePPM.OrderContracts = new InlinePPMOrderContract

            foreach (GridViewRow row in grdOrderDetails.Rows)
            {
                if (row.RowType != DataControlRowType.DataRow) continue;
                HiddenField hdnInlinePPMID = row.FindControl("hdnInlinePPMID") as HiddenField;
                HiddenField hdnField = row.FindControl("hdnOrderContractID") as HiddenField;
                TextBox topSentTarget = row.FindControl("txtTopSentTarget") as TextBox;
                TextBox topSentActual = row.FindControl("txtTopSentActual") as TextBox;
                //TextBox topActualApproval = row.FindControl("txtTopActualApproval") as TextBox;
                TextBox BIPLComments = row.FindControl("txtBIPLComments") as TextBox;
                TextBox iKandiComments = row.FindControl("txtiKandiComments") as TextBox;
                FileUpload fileBIPL = row.FindControl("fileBIPLUpload") as FileUpload;
                FileUpload fileiKandi = row.FindControl("fileiKandiUpload") as FileUpload;
                CheckBox chkApproved = row.FindControl("chkApproved") as CheckBox;
                CheckBox chkRejected = row.FindControl("chkRejected") as CheckBox;
                HiddenField hdnOrderId = row.FindControl("hdnOrderId") as HiddenField;
                DropDownList ddlPattern = row.FindControl("ddlPattern") as DropDownList;
                HiddenField hdnPPSample = row.FindControl("hdnPPSample") as HiddenField;
                //RadioButton rdApproved = row.FindControl("rdApproved") as RadioButton;
                //RadioButton rdRejected = row.FindControl("rdRejected") as RadioButton;

                //orderContract.OrderDetailID == Convert.ToInt32(hdnField.Value);
                InlinePPMOrderContract orderContract = new InlinePPMOrderContract();

                orderContract.OrderDetailID = Convert.ToInt32(hdnField.Value);
                orderContract.OrderID = Convert.ToInt32(hdnOrderId.Value);
                if (hdnInlinePPMID != null)
                {
                    orderContract.InlinePPMId = Convert.ToInt32(hdnInlinePPMID.Value);
                }
                int oldTopStatus = (int)orderContract.TopStatus;
                DateTime oldTopActualApprovalDate = orderContract.TopActualApproval;
                DateTime oldTopSendActualDate = orderContract.TopSentActual;
                string BIPLFileID = string.Empty;
                string iKandiFileID = string.Empty;

                if (ddlPattern.SelectedIndex < Convert.ToInt32(hdnPPSample.Value))
                {
                    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "scr", "jQuery.facebox('Later stage can not less then intial Stage');", true);
                    ddlPattern.Focus();
                    ddlPattern.SelectedIndex = Convert.ToInt32(hdnPPSample.Value);
                    return;
                }

                if (fileBIPL.HasFile)
                    BIPLFileID = FileHelper.SaveFile(fileBIPL.PostedFile.InputStream, fileBIPL.FileName, Constants.INLINEPPM_DOCS_FOLDER_PATH, false, string.Empty);

                if (BIPLFileID != string.Empty)
                    orderContract.BIPLUploadFile = BIPLFileID;

                if (fileiKandi.HasFile)
                    iKandiFileID = FileHelper.SaveFile(fileiKandi.PostedFile.InputStream, fileiKandi.FileName, Constants.INLINEPPM_DOCS_FOLDER_PATH, false, string.Empty);


                if (iKandiFileID != string.Empty)
                    orderContract.iKandiUploadFile = iKandiFileID;

                if (hdnField.Value != null)
                {
                    int oOrderdetailid;
                    if (int.TryParse(hdnField.Value, out oOrderdetailid))
                    {
                        orderContract.OrderDetailID = oOrderdetailid;
                    }
                    else
                    {
                        orderContract.OrderDetailID = -1;
                    }
                }
                else
                {
                    orderContract.OrderDetailID = -1;
                }

                //orderContract.MDA = MDA.Text;
                if (BIPLComments.Text != null)
                {
                    orderContract.BIPLComments = BIPLComments.Text;
                }
                else
                {
                    orderContract.BIPLComments = string.Empty;
                }

                if (iKandiComments.Text != null)
                {
                    orderContract.iKandiComments = iKandiComments.Text;
                }
                else
                {
                    orderContract.iKandiComments = string.Empty;
                }

                if (!string.IsNullOrEmpty(topSentTarget.Text))
                {
                    orderContract.TopSentTarget = DateHelper.ParseDate(topSentTarget.Text).Value;
                }
                else
                {
                    orderContract.TopSentTarget = Convert.ToDateTime("1/1/0001");
                }

                if (!string.IsNullOrEmpty(topSentActual.Text))
                {
                    orderContract.TopSentActual = DateHelper.ParseDate(topSentActual.Text).Value;
                }
                else
                {
                    orderContract.TopSentActual = Convert.ToDateTime("1/1/0001");
                }

                //if (!string.IsNullOrEmpty(topActualApproval.Text))
                //{
                //    orderContract.TopActualApproval = DateHelper.ParseDate(topActualApproval.Text).Value;
                //}
                //else
                //{
                //    orderContract.TopActualApproval = Convert.ToDateTime("1/1/0001");
                //}
                orderContract.PPSampleStatus = ddlPattern.SelectedItem.Text;
                orderContract.TopStatus = (TopStatusType)TopStatusType.UNKNOWN;

                if (chkApproved.Checked)
                {
                    orderContract.TopStatus = (TopStatusType)TopStatusType.APPROVED;
                    orderContract.PPSampleStatus = "PP Sample Done";
                }
                if (chkRejected.Checked)
                {
                    orderContract.TopStatus = (TopStatusType)TopStatusType.REJECTED;
                }

                this.obj_ProcessController.SavePPMDetails(orderContract);


               

                //if (!string.IsNullOrEmpty(topSentTarget.Text))
                //{
                //    int i = WorkflowControllerInstance.UpdateWorkflowInstancePostOrder_Only_For_Cutting(orderContract.OrderDetailID, orderContract.OrderID, TaskMode.TOP_Planned, ApplicationHelper.LoggedInUser.UserData.UserID);
                //}

                //if (!string.IsNullOrEmpty(topSentActual.Text))
                //{
                //    int j = WorkflowControllerInstance.UpdateWorkflowInstancePostOrder_Only_For_Cutting(orderContract.OrderDetailID, orderContract.OrderID, TaskMode.TOP_Sent, ApplicationHelper.LoggedInUser.UserData.UserID);
                //}
            }
            BindTopSection();
            BindHistorySection();

        }
    }
}