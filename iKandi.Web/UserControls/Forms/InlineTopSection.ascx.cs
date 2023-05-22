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
    public partial class InlineTopSection : System.Web.UI.UserControl
    {
        iKandi.BLL.OrderProcessController obj_ProcessController = new BLL.OrderProcessController();
        WorkflowController WorkflowControllerInstance = new WorkflowController();

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
        

        protected void Page_Load(object sender, EventArgs e)
        {
          

            GetQueryString();
            
            if (!IsPostBack)
            {   
                BindTopSection();
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
            InlinePPM inlinePPM = obj_ProcessController.Get_InlineTopSection_by_style_id(styleid, FitsStyle);
            if (inlinePPM.OrderContracts.Count > 0)
            {
                dvTopSection.Visible = true;
                btnTopSubmit.Visible = true;
                InlinePPMOrderContract contract = inlinePPM.OrderContracts[0];
                grdOrderDetails.DataSource = inlinePPM.OrderContracts;
                grdOrderDetails.DataBind();
            }
            else
            {
                dvTopSection.Visible = false;
                btnTopSubmit.Visible = false;
            }

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

                TextBox txtTopSentActual = e.Row.FindControl("txtTopSentActual") as TextBox;
                (txtTopSentActual.Parent as TableCell).BackColor = System.Drawing.ColorTranslator.FromHtml(Constants.GetActualDateColor(((InlinePPMOrderContract)e.Row.DataItem).TopSentTarget, ((InlinePPMOrderContract)e.Row.DataItem).TopSentActual));
                (txtTopSentActual.BackColor) = System.Drawing.ColorTranslator.FromHtml(Constants.GetActualDateColor(((InlinePPMOrderContract)e.Row.DataItem).TopSentTarget, ((InlinePPMOrderContract)e.Row.DataItem).TopSentActual));
                txtTopSentActual.CssClass = "th date_style vertical_text_input " + hdnFabTab.Value + hdnDetTab.Value;

                //Code added by Bharat on 18 Mar 21
                 Label fabric1name = e.Row.FindControl("fabric1name") as Label;
                 HtmlContainerControl Fab1 = (HtmlContainerControl)e.Row.FindControl("Fab1");

                 if (fabric1name.Text=="")
                 {
                     Fab1.Visible = false;  
                 }
                 Label fabric2name = e.Row.FindControl("fabric2name") as Label;
                 HtmlContainerControl Fab2 = (HtmlContainerControl)e.Row.FindControl("Fab2");

                 if (fabric2name.Text == "")
                 {
                     Fab2.Visible = false;
                 }
                 Label fabric3name = e.Row.FindControl("fabric3name") as Label;
                 HtmlContainerControl Fab3 = (HtmlContainerControl)e.Row.FindControl("Fab3");

                 if (fabric3name.Text == "")
                 {
                     Fab3.Visible = false;
                 }
                 Label fabric4name = e.Row.FindControl("fabric4name") as Label;
                 HtmlContainerControl Fab4 = (HtmlContainerControl)e.Row.FindControl("Fab4");

                 if (fabric4name.Text == "")
                 {
                     Fab4.Visible = false;
                 }
                 Label fabric5name = e.Row.FindControl("fabric5name") as Label;
                 HtmlContainerControl Fab5 = (HtmlContainerControl)e.Row.FindControl("Fab5");

                 if (fabric5name.Text == "")
                 {
                     Fab5.Visible = false;
                 }
                 Label fabric6name = e.Row.FindControl("fabric6name") as Label;
                 HtmlContainerControl Fab6 = (HtmlContainerControl)e.Row.FindControl("Fab6");

                 if (fabric6name.Text == "")
                 {
                     Fab6.Visible = false;
                 }
             // End
            }
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
                TextBox topActualApproval = row.FindControl("txtTopActualApproval") as TextBox;
                TextBox BIPLComments = row.FindControl("txtBIPLComments") as TextBox;
                TextBox iKandiComments = row.FindControl("txtiKandiComments") as TextBox;
                FileUpload fileBIPL = row.FindControl("fileBIPLUpload") as FileUpload;
                FileUpload fileiKandi = row.FindControl("fileiKandiUpload") as FileUpload;
                CheckBox chkApproved = row.FindControl("chkApproved") as CheckBox;
                CheckBox chkRejected = row.FindControl("chkRejected") as CheckBox;
                HiddenField hdnOrderId = row.FindControl("hdnOrderId") as HiddenField;
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

                if (!string.IsNullOrEmpty(topActualApproval.Text))
                {
                    orderContract.TopActualApproval = DateHelper.ParseDate(topActualApproval.Text).Value;
                }
                else
                {
                    orderContract.TopActualApproval = Convert.ToDateTime("1/1/0001");
                }

                orderContract.TopStatus = (TopStatusType)TopStatusType.UNKNOWN;

                if (chkApproved.Checked)
                {
                    orderContract.TopStatus = (TopStatusType)TopStatusType.APPROVED;
                }
                if (chkRejected.Checked)
                {
                    orderContract.TopStatus = (TopStatusType)TopStatusType.REJECTED;
                }

                this.obj_ProcessController.SaveOrderContractTOPDetails(orderContract);

                if (!string.IsNullOrEmpty(topSentTarget.Text))
                {
                   int i= WorkflowControllerInstance.UpdateWorkflowInstancePostOrder_Only_For_Cutting(orderContract.OrderDetailID,orderContract.OrderID, TaskMode.TOP_Planned, ApplicationHelper.LoggedInUser.UserData.UserID);
                }

                if (!string.IsNullOrEmpty(topSentActual.Text))
                {
                    int j = WorkflowControllerInstance.UpdateWorkflowInstancePostOrder_Only_For_Cutting(orderContract.OrderDetailID,orderContract.OrderID,TaskMode.TOP_Sent, ApplicationHelper.LoggedInUser.UserData.UserID);
                }
            }
            BindTopSection();
                                                                                   

        }
    }
}