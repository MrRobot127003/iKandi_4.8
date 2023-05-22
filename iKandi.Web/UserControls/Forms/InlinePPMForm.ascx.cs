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

namespace iKandi.Web
{
    public partial class InlinePPMForm : BaseUserControl
    {
        #region Properties

        private string StyleNumber
        {
            get
            {
                if (null != Request.QueryString["stylenumber"])
                {
                    string styleNumber;
                    styleNumber = Request.QueryString["stylenumber"].ToString();
                    return styleNumber;
                }
                return "-1";
            }
        }

        private int StyleID
        {
            get
            {
                if (null != Request.QueryString["styleid"])
                {
                    int styleVersion;
                    styleVersion = Convert.ToInt32(Request.QueryString["styleid"]);
                    return styleVersion;
                }
                return -1;
            }
        }

        #endregion

        #region Event Handlers

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SetupControls();
            }
        }

        protected void grdOrderDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HiddenField hdnSerial = e.Row.FindControl("hdnSerial") as HiddenField;
                (hdnSerial.Parent as TableCell).BackColor = System.Drawing.ColorTranslator.FromHtml(Constants.GetSerialNumberColor(((OrderDetail)e.Row.DataItem).ExFactory));

                HiddenField hdnUnit = e.Row.FindControl("hdnUnit") as HiddenField;
                (hdnUnit.Parent as TableCell).BackColor = System.Drawing.ColorTranslator.FromHtml(ApplicationHelper.GetUnitColor(((OrderDetail)e.Row.DataItem).Unit.FactoryCode));
                HiddenField hdnFabTab = e.Row.FindControl("hdnFabTab") as HiddenField;
                HiddenField hdnDetTab = e.Row.FindControl("hdnDetTab") as HiddenField;

                TextBox txtTopSentActual = e.Row.FindControl("txtTopSentActual") as TextBox;
                (txtTopSentActual.Parent as TableCell).BackColor = System.Drawing.ColorTranslator.FromHtml(Constants.GetActualDateColor(((InlinePPMOrderContract)e.Row.DataItem).TopSentTarget, ((InlinePPMOrderContract)e.Row.DataItem).TopSentActual));
                (txtTopSentActual.BackColor) = System.Drawing.ColorTranslator.FromHtml(Constants.GetActualDateColor(((InlinePPMOrderContract)e.Row.DataItem).TopSentTarget, ((InlinePPMOrderContract)e.Row.DataItem).TopSentActual));
                txtTopSentActual.CssClass = "date-picker date_style vertical_text_input " + hdnFabTab.Value + hdnDetTab.Value;
            }
        }

        #endregion

        #region Private Method

        private void SetupControls()
        {
            int countEmptyComment = 0;
            InlinePPM inlinePPM = this.InlinePPMControllerInstance.GetInlinePPMByStyleID(this.StyleNumber, this.StyleID);

            // Populate Pre-Production and Top Section Data

            if (inlinePPM.Order != null)
            {
                if (inlinePPM.Order.Client != null)
                    this.lblBuyer.Text = inlinePPM.Order.Client.CompanyName;

                this.lblStyleNumber.Text = inlinePPM.Order.Style.StyleNumber;
                this.lblQty.Text = inlinePPM.Order.TotalQuantity.ToString();

                //Populate  Images
                if (!string.IsNullOrEmpty(inlinePPM.Order.Style.SampleImageURL1))
                {
                    imgFront.ImageUrl = ResolveUrl("~/uploads/style/thumb-" + inlinePPM.Order.Style.SampleImageURL1);
                    imgFront.Visible = true;
                }

                if (!string.IsNullOrEmpty(inlinePPM.Order.Style.SampleImageURL2))
                {
                    imgBack.ImageUrl = ResolveUrl("~/uploads/style/thumb-" + inlinePPM.Order.Style.SampleImageURL2);
                    imgBack.Visible = true;
                }
            }

            if (inlinePPM.InlinePPMID == -1)
            {
                this.lblDateHeld.Text = DateTime.Today.ToString("dd MMM yy (ddd)");
                this.lblDateHeldBH.Text = DateTime.Today.ToString("dd MMM yy (ddd)");
            }
            else
            {
                // FileUpload
                inlinePPM.InlinePPmFile = this.InlinePPMControllerInstance.GetPPMFileDataByPPMID(inlinePPM.InlinePPMID);

                if (inlinePPM.InlinePPmFile != null)
                {
                    rptUploadFile.DataSource = inlinePPM.InlinePPmFile;
                    rptUploadFile.DataBind();
                }

                // Stitching Portion 
                this.txtStitchingComments.Text = inlinePPM.StitchingComments;

                // Wash Care
                this.txtWashcareComments.Text = inlinePPM.WashCareComments;

                // EMbroidory Portion
                this.txtEMBMachineComments.Text = inlinePPM.EMBMachineComments;
                this.txtEmbHandComments.Text = inlinePPM.EMBHandComments;

                // Lining Portion 
                this.txtFusing.Text = inlinePPM.LiningFusingComments;
                this.txtInterlining.Text = inlinePPM.LiniingInterLiningComments;
                this.txtPocketLining.Text = inlinePPM.LiningPocketLiningComments;
                this.txtShoulderPad.Text = inlinePPM.LiningShoulderPadComments;

                // Finishing Portion
                this.txtFinishingDC.Text = inlinePPM.FinishingDCComments;
                this.txtFinishingWash.Text = inlinePPM.FinishingWashComments;
                this.txtFinishingCrinckle.Text = inlinePPM.FinishingCrinckleComments;

                // PPM Remarks / Instruction
                this.divPrevPPMRemarks.InnerHtml = inlinePPM.PPMInstructions.ToString().Replace("$$", "<br />").Replace("\n", "<br />").Replace("\n\r", "<br />").Replace("\r\n", "<br />");

                //  Packing Portion
                this.txtTags.Text = inlinePPM.PackingTagsComments;
                this.txtSpaceButtons.Text = inlinePPM.PackingSpaceButtonsComments;
                this.txtCardBoard.Text = inlinePPM.PackingCardBoardComments;
                this.txtWOCardBoard.Text = inlinePPM.PackingWOCardBoardComments;
                this.txtPolytheneComments.Text = inlinePPM.PackingPolytheneComments;
                this.txtTissue.Text = inlinePPM.PackingTissueComments;
                this.txtFOAM.Text = inlinePPM.PackingFoamComments;
                this.txtHanger.Text = inlinePPM.PackingHangerPackComments;
                this.txtBoxSize.Text = inlinePPM.PackingBoxComments;


                // Meeting Attendence Section 
                this.hdnOwnerIds.Value = inlinePPM.UserIds;
                this.hdnOwnerNames.Value = inlinePPM.UserNames;

                if (inlinePPM.UserNames.IndexOf(",") > -1)
                {
                    inlinePPM.UserNames = inlinePPM.UserNames.Replace(",", ", ");
                }

                this.lblOwnerName.Text = inlinePPM.UserNames;
                this.txtMeetingAttendedOtherUser.Text = inlinePPM.MeetingAttendedOtherUser.ToString();
                if (inlinePPM.BBPlannedMeeting.ToString() == "1/1/0001")
                {

                }
                if (Convert.ToDateTime(inlinePPM.BBPlannedMeeting) != Convert.ToDateTime("1/1/0001"))

                    txtBhPlannedMeeting.Text = inlinePPM.BBPlannedMeeting.ToString("dd MMM yy (ddd)");
                else
                    txtBhPlannedMeeting.Text = "";

                if (Convert.ToInt32(inlinePPM.IsBHMeetingComplete) == 1)
                {
                    ChkBHMeetingComplete.Checked = true;
                    ChkBHMeetingComplete.Enabled = false;
                    txtBhPlannedMeeting.Enabled = false;
                    lblDateHeldBH.Text = inlinePPM.BHMeetingCompleteOn.ToString("dd MMM yy (ddd)");

                    if (Convert.ToInt32(inlinePPM.IsMeetingComplete) == 1)
                    {
                        chkIsMeetingComplete.Checked = inlinePPM.IsMeetingComplete;
                        chkIsMeetingComplete.Enabled = false;
                        this.lblDateHeld.Text = inlinePPM.IsMeetingCompletedOn.ToString("dd MMM yy (ddd)");
                    }

                }
                else
                {
                    ChkBHMeetingComplete.Checked = false;
                    chkIsMeetingComplete.Enabled = true;
                    lblDateHeldBH.Text = DateTime.Today.ToString("dd MMM yy (ddd)");

                    if (Convert.ToInt32(inlinePPM.IsMeetingComplete) == 1)
                    {
                        chkIsMeetingComplete.Checked = inlinePPM.IsMeetingComplete;
                        chkIsMeetingComplete.Enabled = false;
                        this.lblDateHeld.Text = inlinePPM.IsMeetingCompletedOn.ToString("dd MMM yy (ddd)");
                    }
                    else
                    {
                        this.lblDateHeld.Text = DateTime.Today.ToString("dd MMM yy (ddd)");
                    }

                }
                if (inlinePPM.ProdSAM != 0)
                {
                    txtSAM.Text = inlinePPM.ProdSAM.ToString();
                }
                if (inlinePPM.ProdOB != 0)
                {
                    txtOB.Text = inlinePPM.ProdOB.ToString();
                }

                hlnkViewSAM.Visible = String.IsNullOrEmpty(inlinePPM.ProdSamFile) ? false : true;
                if (hlnkViewSAM.Visible == true)
                {
                    hdnCheckFile.Value = "1";
                }
                else
                {
                    hdnCheckFile.Value = "0";
                }
                // hlkViewOB.Visible = String.IsNullOrEmpty(inlinePPM.ProdOBfile) ? false : true;

                hlnkViewSAM.NavigateUrl = "~/Uploads/Photo/" + inlinePPM.ProdSamFile;
                // hlkViewOB.NavigateUrl = "~/Uploads/InlinePPM.Docs/" + inlinePPM.ProdOBfile;

            }

            // Fabric
            string fabricDetail = string.Empty;

            if (inlinePPM.OrderContracts.Count > 0)
            {
                InlinePPMOrderContract contract = inlinePPM.OrderContracts[0];
                //string CCGSM = null;

                this.hdnIsIkandiClient.Value = Convert.ToString(contract.IsIkandiClient);
                if (this.hdnIsIkandiClient.Value == "1")
                {
                    txtBhPlannedMeeting.Enabled = false;
                }

                if (!string.IsNullOrEmpty(contract.Fabric1))
                {
                    // fabricDetail = contract.Fabric1;
                    lblFabricAndColor.Text = contract.Fabric1;//yy
                }
                if (!string.IsNullOrEmpty(contract.Fabric1Details))//yy
                    lblFabricAndColor.Text += "(" + contract.Fabric1Details + ")";//y
                if (!string.IsNullOrEmpty(contract.CCGSM1))//y
                    Label2.Text = contract.CCGSM1;

                if (!string.IsNullOrEmpty(contract.FabricApproval1))//y
                    lblApproval1.Text = contract.FabricApproval1;


                if (!string.IsNullOrEmpty(contract.Fabric2))
                {
                    // fabricDetail = contract.Fabric1;
                    lblFabricAndColor2.Text = contract.Fabric2;//yy
                }
                if (!string.IsNullOrEmpty(contract.Fabric2Details))//yy
                    lblFabricAndColor2.Text += "(" + contract.Fabric2Details + ")";//y
                if (!string.IsNullOrEmpty(contract.CCGSM2))//y
                    Label3.Text = contract.CCGSM2;

                if (!string.IsNullOrEmpty(contract.FabricApproval2))//y
                    lblApproval2.Text = contract.FabricApproval2;





                if (!string.IsNullOrEmpty(contract.Fabric3))
                {
                    // fabricDetail = contract.Fabric1;
                    lblFabricAndColor3.Text = contract.Fabric3;//yy
                }
                if (!string.IsNullOrEmpty(contract.Fabric3Details))//yy
                    lblFabricAndColor3.Text += "(" + contract.Fabric3Details + ")";//y
                if (!string.IsNullOrEmpty(contract.CCGSM3))//y
                    Label4.Text = contract.CCGSM3;
                if (!string.IsNullOrEmpty(contract.FabricApproval3))//y
                    lblApproval3.Text = contract.FabricApproval3;




                if (!string.IsNullOrEmpty(contract.Fabric4))
                {
                    // fabricDetail = contract.Fabric1;
                    lblFabricAndColor4.Text = contract.Fabric4;//yy
                }
                if (!string.IsNullOrEmpty(contract.Fabric4Details))//yy
                    lblFabricAndColor4.Text += "(" + contract.Fabric4Details + ")";//y
                if (!string.IsNullOrEmpty(contract.CCGSM4))//y
                    Label5.Text = contract.CCGSM4;

                if (!string.IsNullOrEmpty(contract.FabricApproval4))//y
                    lblApproval4.Text = contract.FabricApproval4;
            }

            //this.lblFabricAndColor.Text = fabricDetail;


            List<string> units = new List<string>();
            List<string> serialNumbers = new List<string>();
            DateTime exFactory = Convert.ToDateTime("1/1/0001");

            foreach (InlinePPMOrderContract contract in inlinePPM.OrderContracts)
            {
                // Get Units and prepare a list of units

                if (!string.IsNullOrEmpty(contract.Unit.FactoryName))
                {
                    if (units.Count > 0)
                    {
                        if (!units.Exists(delegate(string factoryName) { return factoryName.ToLower().Trim() == contract.Unit.FactoryName.ToLower().Trim(); }))
                        {
                            units.Add(contract.Unit.FactoryName);
                        }
                    }
                    else
                    {
                        units.Add(contract.Unit.FactoryName);
                    }
                }

                if (serialNumbers.Count > 0)
                {
                    if (!serialNumbers.Exists(delegate(string serialNumber) { return serialNumber.ToLower().Trim() == contract.ParentOrder.SerialNumber.ToLower().Trim(); }))
                    {
                        serialNumbers.Add(contract.ParentOrder.SerialNumber);
                    }
                }
                else
                {
                    serialNumbers.Add(contract.ParentOrder.SerialNumber);
                }

                if (contract.ExFactory != Convert.ToDateTime("1/1/1900"))
                {
                    //if (exFactory == Convert.ToDateTime("1/1/0001"))
                    //    exFactory = contract.ExFactory;
                    //else if (exFactory.CompareTo(contract.ExFactory) == -1)
                    //    exFactory = contract.ExFactory;
                    exFactory = contract.ExFactory;
                }
            }

            this.lblUnit.Text = string.Join(", ", units.ToArray());
            this.lbliKandiSerial.Text = string.Join(", ", serialNumbers.ToArray());

            if (exFactory != Convert.ToDateTime("1/1/0001"))
                this.lblExFactory.Text = exFactory.ToString("dd MMM yy (ddd)");

            // TODO: set other fields
            grdOrderDetails.DataSource = inlinePPM.OrderContracts;
            grdOrderDetails.DataBind();

            rptTrims.DataSource = inlinePPM.TrimsComments;
            rptTrims.DataBind();

            // trim portion
            foreach (InlinePPMTrims trim in inlinePPM.TrimsComments)
            {
                if (inlinePPM.TrimsComments.ToString().Trim() == string.Empty)
                {
                    countEmptyComment++;
                }
            }

            rowPPMRemarks.Attributes.Add("rowspan", (1 + inlinePPM.TrimsComments.Count - countEmptyComment).ToString());

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            InlinePPM inlinePPM = this.InlinePPMControllerInstance.GetInlinePPMByStyleID(this.StyleNumber, this.StyleID);

            string dateToday = DateTime.Today.ToString("dd MMM yy (ddd)");

            if (inlinePPM.InlinePPMID == -1)
                inlinePPM.DateHeldOn = DateTime.Today;

            inlinePPM.Order = new iKandi.Common.Order();

            inlinePPM.StyleNumber = this.StyleNumber;
            inlinePPM.StyleID = this.StyleID;

            // Stitching Portion
            if (this.txtStitchingComments.Text != null)
            {
                inlinePPM.StitchingComments = this.txtStitchingComments.Text;
            }
            else
            {
                inlinePPM.StitchingComments = string.Empty;
            }


            // Wash Care Portion
            if (this.txtWashcareComments.Text != null)
            {
                inlinePPM.WashCareComments = this.txtWashcareComments.Text;
            }
            else
            {
                inlinePPM.WashCareComments = string.Empty;
            }

            //Embroidory Portion
            if (this.txtEMBMachineComments.Text != null)
            {
                inlinePPM.EMBMachineComments = this.txtEMBMachineComments.Text;
            }
            else
            {
                inlinePPM.EMBMachineComments = string.Empty;
            }

            if (this.txtEmbHandComments.Text != null)
            {
                inlinePPM.EMBHandComments = this.txtEmbHandComments.Text;
            }
            else
            {
                inlinePPM.EMBHandComments = string.Empty;
            }


            // PP Instruction Comments

            if (!string.IsNullOrEmpty(this.txtPPMRemarksCorrections.Text))
            {
                inlinePPM.PPMInstructions = ApplicationHelper.LoggedInUser.UserData.FirstName + "(" + DateTime.Today.ToString("dd MMM") + ")" + " - " + this.txtPPMRemarksCorrections.Text;
            }
            else
            {
                inlinePPM.PPMInstructions = string.Empty;
            }


            // Lining Portion 
            if (this.txtFusing.Text != null)
            {
                inlinePPM.LiningFusingComments = this.txtFusing.Text;
            }
            else
            {
                inlinePPM.LiningFusingComments = string.Empty;
            }

            if (this.txtInterlining.Text != null)
            {
                inlinePPM.LiniingInterLiningComments = this.txtInterlining.Text;
            }
            else
            {
                inlinePPM.LiniingInterLiningComments = string.Empty;
            }

            if (this.txtPocketLining.Text != null)
            {
                inlinePPM.LiningPocketLiningComments = this.txtPocketLining.Text;
            }
            else
            {
                inlinePPM.LiningPocketLiningComments = string.Empty;
            }

            if (this.txtShoulderPad.Text != null)
            {
                inlinePPM.LiningShoulderPadComments = this.txtShoulderPad.Text;
            }
            else
            {
                inlinePPM.LiningShoulderPadComments = string.Empty;
            }


            // Finishing Portion

            if (this.txtFinishingDC.Text != null)
            {
                inlinePPM.FinishingDCComments = this.txtFinishingDC.Text;
            }
            else
            {
                inlinePPM.FinishingDCComments = string.Empty;
            }

            if (this.txtFinishingWash.Text != null)
            {
                inlinePPM.FinishingWashComments = this.txtFinishingWash.Text;
            }
            else
            {
                inlinePPM.FinishingWashComments = string.Empty;
            }

            if (this.txtFinishingCrinckle.Text != null)
            {
                inlinePPM.FinishingCrinckleComments = this.txtFinishingCrinckle.Text;
            }
            else
            {
                inlinePPM.FinishingCrinckleComments = string.Empty;
            }

            inlinePPM.PPMRemarks = string.Empty;

            // Packing Portion
            if (this.txtTags.Text != null)
            {
                inlinePPM.PackingTagsComments = this.txtTags.Text;
            }
            else
            {
                inlinePPM.PackingTagsComments = string.Empty;
            }

            if (this.txtSpaceButtons.Text != null)
            {
                inlinePPM.PackingSpaceButtonsComments = this.txtSpaceButtons.Text;
            }
            else
            {
                inlinePPM.PackingSpaceButtonsComments = string.Empty;
            }

            if (this.txtCardBoard.Text != null)
            {
                inlinePPM.PackingCardBoardComments = this.txtCardBoard.Text;
            }
            else
            {
                inlinePPM.PackingCardBoardComments = string.Empty;
            }

            if (this.txtWOCardBoard.Text != null)
            {
                inlinePPM.PackingWOCardBoardComments = this.txtWOCardBoard.Text;
            }
            else
            {
                inlinePPM.PackingWOCardBoardComments = string.Empty;
            }

            if (this.txtPolytheneComments.Text != null)
            {
                inlinePPM.PackingPolytheneComments = this.txtPolytheneComments.Text;
            }
            else
            {
                inlinePPM.PackingPolytheneComments = string.Empty;
            }

            if (this.txtTissue.Text != null)
            {
                inlinePPM.PackingTissueComments = this.txtTissue.Text;
            }
            else
            {
                inlinePPM.PackingTissueComments = string.Empty;
            }

            if (this.txtFOAM.Text != null)
            {
                inlinePPM.PackingFoamComments = this.txtFOAM.Text;
            }
            else
            {
                inlinePPM.PackingFoamComments = string.Empty;
            }

            if (this.txtHanger.Text != null)
            {
                inlinePPM.PackingHangerPackComments = this.txtHanger.Text;
            }
            else
            {
                inlinePPM.PackingHangerPackComments = string.Empty;
            }

            if (this.txtBoxSize.Text != null)
            {
                inlinePPM.PackingBoxComments = this.txtBoxSize.Text;
            }
            else
            {
                inlinePPM.PackingBoxComments = string.Empty;
            }

            //  MEETING ATTENDED BY  Portion 

            if (this.hdnOwnerIds.Value != null)
            {
                inlinePPM.UserIds = this.hdnOwnerIds.Value;
            }
            else
            {
                inlinePPM.UserIds = string.Empty;
            }

            inlinePPM.IsMeetingComplete = chkIsMeetingComplete.Checked;
            inlinePPM.IsBHMeetingComplete = ChkBHMeetingComplete.Checked;
            if (ChkBHMeetingComplete.Checked == true)
            {
                inlinePPM.BHMeetingCompleteOn = DateTime.Now;
            }
            else
            {
                inlinePPM.BHMeetingCompleteOn = Convert.ToDateTime("1/1/0001");
            }

            if (!string.IsNullOrEmpty(txtBhPlannedMeeting.Text))
            {
                inlinePPM.BBPlannedMeeting = DateHelper.ParseDate(txtBhPlannedMeeting.Text).Value;
            }
            else
            {
                inlinePPM.BBPlannedMeeting = Convert.ToDateTime("1/1/0001");
            }


            inlinePPM.IsMeetingCompletedOn = DateTime.Now;

            if (this.txtMeetingAttendedOtherUser.Text != null)
            {
                inlinePPM.MeetingAttendedOtherUser = this.txtMeetingAttendedOtherUser.Text;
            }
            else
            {
                inlinePPM.MeetingAttendedOtherUser = string.Empty;
            }

            string SAMFile = string.Empty;
            string OBFile = string.Empty;

            if (uploadSAM.HasFile)
            {
               // hdnCheckFile.Value = "1";
                SAMFile = FileHelper.SaveFile(uploadSAM.PostedFile.InputStream, uploadSAM.FileName, Constants.PHOTO_FOLDER_PATH, false, string.Empty);
            }
            //if (uploadOB.HasFile)
            //    OBFile = FileHelper.SaveFile(uploadOB.PostedFile.InputStream, uploadOB.FileName, Constants.INLINEPPM_DOCS_FOLDER_PATH, false, string.Empty);

            if (SAMFile != string.Empty)
                inlinePPM.ProdSamFile = SAMFile;

            if (OBFile != string.Empty)
                inlinePPM.ProdOBfile = OBFile;

            if (txtSAM.Text != "")
            {
                inlinePPM.ProdSAM = Convert.ToDouble(txtSAM.Text);
            }
            else
            {
                inlinePPM.ProdSAM = -1;
            }
            if (txtOB.Text != "")
            {
                inlinePPM.ProdOB = Convert.ToInt32(txtOB.Text);
            }
            else
            {
                inlinePPM.ProdOB = -1;
            }

            // Trim Portion

            if (inlinePPM.TrimsComments == null)
                inlinePPM.TrimsComments = new System.Collections.Generic.List<InlinePPMTrims>();

            foreach (RepeaterItem item in rptTrims.Items)
            {
                HiddenField hdnField = item.FindControl("hdnAccessoryID") as HiddenField;
                TextBox comments = item.FindControl("txtAccessoryComments") as TextBox;

                InlinePPMTrims trimComment = inlinePPM.TrimsComments.Find(delegate(InlinePPMTrims trim)
                {
                    return trim.Id == Convert.ToInt32(hdnField.Value);
                });

                if (trimComment == null)
                {
                    trimComment = new InlinePPMTrims();
                    inlinePPM.TrimsComments.Add(trimComment);
                }

                trimComment.Id = Convert.ToInt32(hdnField.Value);
                trimComment.TrimsComments = comments.Text;
            }

            // Tops Section

            if (inlinePPM.OrderContracts == null)
                inlinePPM.OrderContracts = new System.Collections.Generic.List<InlinePPMOrderContract>();

            foreach (GridViewRow row in grdOrderDetails.Rows)
            {
                if (row.RowType != DataControlRowType.DataRow) continue;

                HiddenField hdnField = row.FindControl("hdnOrderContractID") as HiddenField;
                TextBox topSentTarget = row.FindControl("txtTopSentTarget") as TextBox;
                TextBox topSentActual = row.FindControl("txtTopSentActual") as TextBox;
                TextBox topActualApproval = row.FindControl("txtTopActualApproval") as TextBox;
                TextBox BIPLComments = row.FindControl("txtBIPLComments") as TextBox;
                TextBox iKandiComments = row.FindControl("txtiKandiComments") as TextBox;
                FileUpload fileBIPL = row.FindControl("fileBIPLUpload") as FileUpload;
                FileUpload fileiKandi = row.FindControl("fileiKandiUpload") as FileUpload;
                RadioButton rdApproved = row.FindControl("rdApproved") as RadioButton;
                RadioButton rdRejected = row.FindControl("rdRejected") as RadioButton;

                InlinePPMOrderContract orderContract = inlinePPM.OrderContracts.Find(delegate(InlinePPMOrderContract contract)
                {
                    return contract.OrderDetailID == Convert.ToInt32(hdnField.Value);
                });

                if (orderContract == null)
                {
                    orderContract = new InlinePPMOrderContract();
                    inlinePPM.OrderContracts.Add(orderContract);
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

                if (rdApproved.Checked)
                {
                    orderContract.TopStatus = (TopStatusType)TopStatusType.APPROVED;
                    if (oldTopStatus != (int)orderContract.TopStatus)
                    {
                        orderContract.TopActualApproval = DateTime.Today;
                        orderContract.TopSentActual = (orderContract.TopSentActual == Convert.ToDateTime("1/1/1900") || orderContract.TopSentActual == Convert.ToDateTime("1/1/0001")) ? DateTime.Today : orderContract.TopSentActual;
                    }
                }
                else if (rdRejected.Checked)
                {
                    orderContract.TopStatus = (TopStatusType)TopStatusType.REJECTED;
                    if (oldTopStatus != (int)orderContract.TopStatus)
                    {
                        orderContract.TopSentActual = Convert.ToDateTime("1/1/0001");
                        orderContract.TopActualApproval = DateTime.Today;
                    }
                }
                else
                {
                    orderContract.TopStatus = (TopStatusType)TopStatusType.UNKNOWN;
                }

            }

            // uplodes File

            inlinePPM.InlinePPmFile = new List<InlinePPMFile>();

            for (int i = 0; i < Request.Files.Count; i++)
            {
                if (Request.Files.AllKeys[i].EndsWith("uploadFile") && Request.Files != null && Request.Files[i].InputStream != null && Request.Files[i].InputStream.Length > 0)
                {
                    InlinePPMFile ippmf = new InlinePPMFile();
                    string suggestedFileName = "fileName";
                    if (Request.Files[i].FileName.IndexOf(".") > -1)
                    {
                        suggestedFileName = Request.Files[i].FileName.Substring(0, Request.Files[i].FileName.IndexOf(".") - 1);
                        int index = suggestedFileName.LastIndexOf("\\");
                        if (index > 0)
                        {
                            suggestedFileName = suggestedFileName.Substring(index + 1) + this.StyleNumber.ToString();
                        }

                    }
                    string imageName = FileHelper.SaveFile(Request.Files[i].InputStream, Request.Files[i].FileName, Constants.INLINEPPM_DOCS_FOLDER_PATH, true, suggestedFileName);
                    ippmf.File = imageName;
                    inlinePPM.InlinePPmFile.Add(ippmf);
                }

            }


            this.InlinePPMControllerInstance.Save(inlinePPM);

            if (inlinePPM.IsBHMeetingComplete == true)
            {
                UserTask task = new UserTask();

                task.AssignedToDesigntation = (int)Designation.BIPL_Production_FactoryManager;
                task.CreatedBy = ApplicationHelper.LoggedInUser.UserData.UserID;
                task.CreatedOn = DateTime.Now;
                task.ETA = DateTime.Now.AddDays(3);
                task.Style = this.StyleControllerInstance.GetStyleByStyleNumber(lblStyleNumber.Text);
                task.OrderDetail = new OrderDetail();
                task.OrderDetail.OrderDetailID = 0;
                task.Type = UserTaskType.ShipmentOffer;
                task.IntField3 = 0;

                this.UserTaskControllerInstance.InsertUserTaskShipment(task);
            }

            pnlForm.Visible = false;
            pnlMessage.Visible = true;
        }

        #endregion



    }
}
