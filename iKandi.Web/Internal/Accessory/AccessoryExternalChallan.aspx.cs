using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iKandi.Common;
using iKandi.BLL;
using System.Data;
using iKandi.Web.Components;
using System.Net;
using System.Net.Mail;
using System.IO;
using iTextSharp;
using Pechkin;
using iTextSharp.text.html;
using System.Xml;

using System.Web.Configuration;
using System.Text.RegularExpressions;


namespace iKandi.Web.Internal.Accessory
{
    public partial class AccessoryExternalChallan : BasePage
    {
        public int SupplierPoId
        {
            get;
            set;
        }
        public int ChallanId
        {
            get;
            set;
        }
        public int AccessoryMasterId
        {
            get;
            set;
        }
        public string Size
        {
            get;
            set;
        }
        public string ColorPrint
        {
            get;
            set;
        }
        public decimal GST
        {


            get;
            set;
        }

        string host = "";
        string MailType = "Accessory Send Challan ";
        string PoPath = string.Empty;

        AccessoryWorkingController objAccessoryWorking = new AccessoryWorkingController();
        AccessoryQualityController ObjAccessoryQlty = new AccessoryQualityController();
        protected void Page_Load(object sender, EventArgs e)
        {
            host = "http://" + Request.Url.Authority;
            if (iKandi.Web.Components.ApplicationHelper.LoggedInUser == null || iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData == null)
                Response.Redirect("~/public/Login.aspx");

            GetQueryString();
            if (!IsPostBack)
            {
                BindChallanProcess();
                BindData();
                DataTable dt = objAccessoryWorking.Getbipladdress("BIPLAddress4");
                divbipladdress.InnerHtml = dt.Rows[0]["VALUE"].ToString();
            }
        }
        private void GetQueryString()
        {
            if (Request.QueryString["SupplierPoId"] != null)
            {
                SupplierPoId = Convert.ToInt32(Request.QueryString["SupplierPoId"]);
            }
            else
            {
                SupplierPoId = 0;
            }
            if (Request.QueryString["ChallanId"] != null)
            {
                ChallanId = Convert.ToInt32(Request.QueryString["ChallanId"]);
            }
            else
            {
                ChallanId = 0;
            }

        }

        private void BindData()
        {
            AccessoryChallanCls objAccessoryChallan = new AccessoryChallanCls();
            AccessoryGstRateTotalAmount objAccessoryGstRateTotalAmount = new AccessoryGstRateTotalAmount();


            DataTable Dt = objAccessoryWorking.Get_AccessoryPODetail(SupplierPoId);
            if (Dt.Rows[0]["PoStatus"].ToString() != "2")
            {

                objAccessoryGstRateTotalAmount = objAccessoryWorking.AccessoryGstRateTotalAmount(SupplierPoId, ChallanId, "EXTRATEGST");

                lblRate.Text = objAccessoryGstRateTotalAmount.Rate.ToString();
                //if (objAccessoryGstRateTotalAmount.GSTno != null)
                //{
                string gstNo = "";
                if ((objAccessoryGstRateTotalAmount.GSTno == null) || (objAccessoryGstRateTotalAmount.GSTno == string.Empty))
                {
                    gstNo = "";
                }
                else
                {
                    gstNo = objAccessoryGstRateTotalAmount.GSTno.ToString().Substring(0, 2);
                }
                GST = objAccessoryGstRateTotalAmount.Gst;
                if (gstNo == "09")
                {
                    lblcgst.Text = (GST / 2).ToString();
                    lblsgst.Text = (GST / 2).ToString();
                    igst.Visible = false;
                }
                else
                {
                    lbligst.Text = objAccessoryGstRateTotalAmount.Gst.ToString();
                    licgst.Visible = false;
                    lisgst.Visible = false;
                }

                if (lbligst.Text == "0")
                {
                    lbligst.Text = "N/A";
                    lbligst.Attributes.Add("class", "");
                }
                if (lblcgst.Text == "0")
                {
                    lblcgst.Text = "N/A";
                    lblcgst.Attributes.Add("class", "");
                }
                if (lblsgst.Text == "0")
                {
                    lblsgst.Text = "N/A";
                    lblsgst.Attributes.Add("class", "");
                }
                //}
                string Amount = objAccessoryGstRateTotalAmount.TotalAmount.ToString();
                lblTotalAmount.Text = String.Format("{0:N2}", double.Parse(Amount));
            }
            else
            {
                tblaccExtChallan.Visible = false;
            }
            int UserId = iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.UserID;


            objAccessoryChallan = objAccessoryWorking.Get_AccessorySendChallan(SupplierPoId, ChallanId, UserId);


            hdnChallan.Value = objAccessoryChallan.ChallanId.ToString();
            lblPoNo.Text = objAccessoryChallan.PoNumber.ToString();
            lblSupplierName.Text = objAccessoryChallan.SupplierName;

            lblSupplierGstNo.Text = objAccessoryChallan.SupplierGstNo;

            lblSupplierAddress.Text = objAccessoryChallan.SupplierAddress;
            //rajeevS 
            string HSNCode = objAccessoryChallan.HSNCode;
            if ((Convert.ToBoolean(objAccessoryChallan.IsPartySignature.ToString()) || Convert.ToBoolean(objAccessoryChallan.IsAuthorizedSignatory.ToString())) && ((HSNCode == null) || (HSNCode == "")))
            {
                spn_HSNCode.InnerHtml = "";
                lblHSNCode.Visible = false;
            }
            else
            {
                lblHSNCode.Visible = true;
                lblHSNCode.Text = HSNCode;
                spn_HSNCode.InnerHtml = "HSNCode";
            }
            //rajeevs
            txtDescription.Text = objAccessoryChallan.ChallanDesc;

            lblChallan.Text = objAccessoryChallan.ChallanNumber;
            lblAccessoryQuality.Text = objAccessoryChallan.AccessoryName;
            hdnAccessoryQuality.Value = objAccessoryChallan.AccessoryName;  //new line 





            if (objAccessoryChallan.Size != "")
                lblSize.Text = objAccessoryChallan.Size == "Default" ? "" : "(" + objAccessoryChallan.Size + ")";

            lblcolorprint.Text = objAccessoryChallan.Color_Print;

            if (ChallanId > 0)
            {
                lblChallanDate.Text = objAccessoryChallan.ChallanDate.ToString("dd MMM yy (ddd)");
            }
            else
            {
                lblChallanDate.Text = DateTime.Today.ToString("dd MMM yy (ddd)");

                for (int i = 0; i < chkProcess.Items.Count; i++)
                {
                    if (chkProcess.Items[i].Text == "Process")
                    {
                        chkProcess.Items[i].Selected = true;
                    }
                }
            }
            ddlType.SelectedValue = "1";
            ddlType.Attributes.Add("disabled", "disabled");

            txtSendQty.Text = objAccessoryChallan.SendChallanQty == 0 ? "" : objAccessoryChallan.SendChallanQty.ToString();// changed from 0N to blank 09-08-2022  shubhendu
            hdnSendQty.Value = objAccessoryChallan.SendChallanQty.ToString();
            lblSendQtyUnitName.Text = objAccessoryChallan.GarmentUnitName;

            hdnIsUnitChange.Value = objAccessoryChallan.UnitChange == true ? "1" : "0";
            hdnConversionValue.Value = objAccessoryChallan.ConversionValue.ToString();

            hdnPO_Number.Value = objAccessoryChallan.PoNumber;
            hdnChallan_Number.Value = objAccessoryChallan.ChallanNumber;

            if (Convert.ToDecimal(objAccessoryChallan.Remaining_SendQty) == 0)
            {
                hdnRemainingQty.Value = "";
            }
            else
            {
                if (ChallanId == 0)
                    hdnRemainingQty.Value = (Convert.ToDecimal(objAccessoryChallan.Remaining_SendQty) - Convert.ToDecimal(objAccessoryChallan.SendChallanQty)).ToString();

                else
                    hdnRemainingQty.Value = Convert.ToDecimal(objAccessoryChallan.Remaining_SendQty).ToString();
            }
            if (objAccessoryChallan.Remaining_SendQty == 0)
            {
                tdRemainingQuantity.Attributes.Add("style", "display:none");
            }
            //lblRemainingQty.Text = objAccessoryChallan.Remaining_SendQty == 0 ? "" : objAccessoryChallan.Remaining_SendQty.ToString(); // changed from 0N to blank 09-08-2022  shubhendu 
            lblRemainingQty.Text = hdnRemainingQty.Value; //above line commented and for this 


            lblRemainingQtyUnitName.Text = objAccessoryChallan.Remaining_SendQty == 0 ? "" : objAccessoryChallan.GarmentUnitName;

            if (objAccessoryChallan.UnitChange == true)
            {
                hdnDefaultSendQty.Value = objAccessoryChallan.Default_SendChallanQty.ToString();
                lblDefaultSendQty.Text = objAccessoryChallan.Default_SendChallanQty == 0 ? "" : objAccessoryChallan.Default_SendChallanQty.ToString();
                hdnDefault_SendQtyUnitName.Value = objAccessoryChallan.DefaultGarmentUnitName;
                lblDefault_SendQtyUnitName.Text = objAccessoryChallan.SendChallanQty > 0 ? objAccessoryChallan.DefaultGarmentUnitName : "";


                hdnDefaultRemainingQty.Value = objAccessoryChallan.Default_Remaining_SendQty.ToString();
                lblDefaultRemainingQty.Text = objAccessoryChallan.Default_Remaining_SendQty == 0 ? "" : objAccessoryChallan.Default_Remaining_SendQty.ToString(); // changed from 0N to blank 09-08-2022  by shubhendu
                lblDefault_RemainingQtyUnitName.Text = objAccessoryChallan.Default_Remaining_SendQty == 0 ? "" : objAccessoryChallan.DefaultGarmentUnitName;
            }


            String imgPath = "~/" + System.Configuration.ConfigurationManager.AppSettings["photo.folder"];

            if (objAccessoryChallan.IsPartySignature == true)
            {
                chkReciever.Visible = false;
                hdnReceiverIsChecked.Value = "1";
                lblRecierverDate.Text = objAccessoryChallan.ReceivedDate == DateTime.MinValue ? "" : objAccessoryChallan.ReceivedDate.ToString("dd MMM yy (ddd)");
                imgpartysingature.ImageUrl = imgPath + objAccessoryChallan.RecievedSignature;
                lblRecieverSign.Text = objAccessoryChallan.RecievedBy;
            }

            if (objAccessoryChallan.IsAuthorizedSignatory == true)
            {
                chkAuthorise.Visible = false;
                hdnAuthoriseIsChecked.Value = "1";
                lblAuthoriseDate.Text = objAccessoryChallan.AuthorizedDate == DateTime.MinValue ? "" : objAccessoryChallan.AuthorizedDate.ToString("dd MMM yy (ddd)");
                imgAuthorizedSignatory.ImageUrl = imgPath + objAccessoryChallan.AuthSignature;
                lblAuthoRiseSign.Text = objAccessoryChallan.AuthoriseBy;
            }
            if ((objAccessoryChallan.IsPartySignature == true) && (objAccessoryChallan.IsAuthorizedSignatory == true))
            {
                //dvSendMail.Attributes.Add("style", "display:''");
                dvSendMail.Attributes.Add("style", "display:'';font-weight:bold;width:400px;");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "err_msg", "disablePage();", true);
                //btnSubmit.Visible = false;                
            }
        }

        private void BindChallanProcess()
        {
            List<ChallanProcess> ChallanProcessList = objAccessoryWorking.GetChallanProcessList(ChallanId);
            chkProcess.DataSource = ChallanProcessList;
            chkProcess.DataTextField = "ProcessName";
            chkProcess.DataValueField = "ChallanProcessId";
            chkProcess.DataBind();

            for (int i = 0; i < chkProcess.Items.Count; i++)
            {
                chkProcess.Items[i].Selected = ChallanProcessList[i].IsChecked;
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            if (hdnAuthoriseIsChecked.Value == "0" || hdnReceiverIsChecked.Value == "0")
            {
                if (txtSendQty.Text != "")
                {
                    try
                    {
                        //btnSubmit.Visible = false;
                        AccessoryChallanCls objAccessoryChallan = new AccessoryChallanCls();
                        objAccessoryChallan.Rate = Convert.ToDecimal(hdnrate.Value);

                        objAccessoryChallan.SupplierPoId = SupplierPoId;
                        objAccessoryChallan.ChallanId = hdnChallan.Value == "" ? -1 : Convert.ToInt32(hdnChallan.Value);
                        objAccessoryChallan.ChallanNumber = lblChallan.Text;
                        objAccessoryChallan.ChallanDate = lblChallanDate.Text != "" ? DateTime.ParseExact(lblChallanDate.Text, "dd MMM yy (ddd)", System.Globalization.CultureInfo.InvariantCulture) : DateTime.MinValue;
                        objAccessoryChallan.ChallanType = Convert.ToInt32(ddlType.SelectedValue);
                        objAccessoryChallan.ChallanDesc = txtDescription.Text;

                        if (hdnIsUnitChange.Value == "1")
                        {
                            objAccessoryChallan.SendQty = hdnDefaultSendQty.Value == "" ? -1 : Convert.ToDecimal(hdnDefaultSendQty.Value);
                        }
                        else
                        {
                            objAccessoryChallan.SendQty = txtSendQty.Text == "" ? 0 : Convert.ToDecimal(txtSendQty.Text.Replace(",", ""));
                        }


                        objAccessoryChallan.AccessoryUnitId = 1;
                        if (chkReciever.Checked)
                            objAccessoryChallan.IsPartySignature = true;
                        if (chkAuthorise.Checked)
                            objAccessoryChallan.IsAuthorizedSignatory = true;

                        List<ChallanProcess> objChallanProcessList = new List<ChallanProcess>();
                        for (int i = 0; i < chkProcess.Items.Count; i++)
                        {
                            ChallanProcess objProcess = new ChallanProcess();
                            if (chkProcess.Items[i].Selected)
                            {
                                objProcess.ChallanProcessId = Convert.ToInt32(chkProcess.Items[i].Value);
                                objChallanProcessList.Add(objProcess);
                            }
                        }
                        //objAccessoryChallan.GST = GST;//GST is the  property here decimal type storing from database value 

                        if (lbligst.Text == "" || lbligst.Text == "N/A")
                            lbligst.Text = "0";

                        if (lblcgst.Text == "" || lblcgst.Text == "N/A")
                            lblcgst.Text = "0";

                        if (lblsgst.Text == "" || lblsgst.Text == "N/A")
                            lblsgst.Text = "0";

                        Decimal GstTotal = Convert.ToDecimal(lbligst.Text) + Convert.ToDecimal(lblcgst.Text) + Convert.ToDecimal(lblsgst.Text);

                        objAccessoryChallan.GST = GstTotal;//commenting above line as per discussion with Vaibhav(QA) and storing gsm value in table
                        //RajeevS
                        objAccessoryChallan.HSNCode = lblHSNCode.Text;
                        //RajeevS

                        objAccessoryChallan.ChallanProcessList = objChallanProcessList;

                        int UserId = iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.UserID;

                        int iSave = objAccessoryWorking.Save_Accessory_Challan(objAccessoryChallan, UserId);

                        ChallanId = iSave;


                        if (iSave > 0)
                        {
                            if (chkAuthorise.Checked && chkReciever.Checked && rbtnYes.Checked)
                            {
                                RenderHtml();

                                string thisPath = "Challan_" + hdnChallan_Number.Value + ".pdf";
                                string url = host + "/Uploads/Accessory/" + thisPath;

                                string EmailContent = HttpContent(url);

                                SendDebitNoteEmail("test", "kumar", EmailContent, MailType);
                            }

                            ScriptManager.RegisterStartupScript(this, this.GetType(), "err_msg", "closePage();", true);
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "err_msg", "jQuery.facebox('Some error occured);", true);
                            return;
                        }
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                        System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                        //btnSubmit.Visible = true;
                    }
                }
            }

            if (hdnAuthoriseIsChecked.Value == "1" && hdnReceiverIsChecked.Value == "1" && (rbtnYes.Checked))
            {
                RenderHtml();

                string thisPath = "Challan_" + hdnChallan_Number.Value + ".pdf";
                string url = host + "/Uploads/Accessory/" + thisPath;

                string EmailContent = HttpContent(url);

                SendDebitNoteEmail("test", "kumar", EmailContent, MailType);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "err_msg", "closePage();", true);
            }
        }

        public void RenderHtml()
        {
            WebRequest Request;
            WebResponse Response;
            StreamReader reader;
            int UserId = iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.UserID;
            string strHTML;
            Request = WebRequest.Create(host + "/AccessoryPdfFile/AccessoryExternalChallanPdf.aspx?SupplierPoId=" + SupplierPoId + "&ChallanId=" + ChallanId + "&UserId=" + UserId);

            Request.Timeout = Convert.ToInt32(99999999);
            Response = Request.GetResponse();
            reader = new StreamReader(Response.GetResponseStream());
            strHTML = reader.ReadToEnd();
            genertaePdf(strHTML, "ss");
        }

        public void genertaePdf(string HTMLCode, string PolicyFile)
        {
            string strFileName = HttpContext.Current.Server.MapPath("~/Uploads/Accessory/" + "Challan_" + hdnChallan_Number.Value + ".pdf");
            HTMLCode = getImage(HTMLCode);
            getvartypeHTML(HTMLCode, strFileName);
        }

        public void getvartypeHTML(string HTMLCode, string PolicyFile)
        {
            string strFileName = HttpContext.Current.Server.MapPath("~/Uploads/Accessory/" + "Challan_" + hdnChallan_Number.Value + ".pdf");

            using (IPechkin pechkin = Factory.Create(new GlobalConfig()))
            {
                var pdf = pechkin.Convert(new ObjectConfig()
                                        .SetLoadImages(true).SetZoomFactor(1.5)
                                        .SetPrintBackground(true)
                                        .SetScreenMediaType(true)
                                        .SetCreateExternalLinks(true), (HTMLCode));
                using (FileStream file = System.IO.File.Create(strFileName))
                {
                    file.Write(pdf, 0, pdf.Length);
                }
            }

        }

        public string getImage(string input)
        {
            if (input == null)
                return string.Empty;
            string tempInput = input;
            string pattern = @"<img(.|\n)+?>";
            string src = string.Empty;
            HttpContext context = HttpContext.Current;

            //Change the relative URL's to absolute URL's for an image, if any in the HTML code.
            foreach (Match m in Regex.Matches(input, pattern, RegexOptions.IgnoreCase | RegexOptions.Multiline |

            RegexOptions.RightToLeft))
            {
                if (m.Success)
                {
                    string tempM = m.Value;
                    string pattern1 = "src=[\'|\"](.+?)[\'|\"]";
                    Regex reImg = new Regex(pattern1, RegexOptions.IgnoreCase | RegexOptions.Multiline);
                    Match mImg = reImg.Match(m.Value);

                    if (mImg.Success)
                    {
                        src = mImg.Value.ToLower().Replace("src=", "").Replace("\"", "");
                        if (src == "../../signatured.jpg" || src == "../signatured.jpg")
                        {
                            string imgsrc = @Server.MapPath("~/Signature/SignatureD.jpg");
                            src = "src=\"" + imgsrc + "\"";
                        }
                        if (src == "../../signdt.jpg" || src == "../signdt.jpg")
                        {
                            string imgsrc = @Server.MapPath("~/Signature/signdt.jpg");
                            src = "src=\"" + imgsrc + "\"";
                        }
                        if (src.ToLower().Contains("http://") == false)
                        {

                            try
                            {
                                tempM = tempM.Remove(mImg.Index, mImg.Length);
                                tempM = tempM.Insert(mImg.Index, src);

                                //insert new url img tag in whole html code
                                tempInput = tempInput.Remove(m.Index, m.Length);
                                tempInput = tempInput.Insert(m.Index, tempM);
                            }
                            catch (Exception ex)
                            {
                                System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                            }
                        }
                    }
                }
            }
            return tempInput;
        }

        public static string HttpContent(string url)
        {
            string result = "";
            try
            {
                HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(url);
                req.Timeout = 80000000;
                //req.UserAgent = "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 6.1; WOW64; Trident/4.0; SLCC2; .NET CLR 2.0.50727; .NET CLR 3.5.30729; .NET CLR 3.0.30729; .NET4.0C; .NET4.0E)";
                req.UserAgent = "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 6.1; WOW64; Trident/4.0; SLCC2; .NET CLR 2.0.50727; .NET CLR 3.5.30729; .NET CLR 3.0.30729; .NET4.0C; .NET4.0E)";

                using (var resp = req.GetResponse())
                {
                    result = new StreamReader(resp.GetResponseStream()).ReadToEnd();
                }

            }

            catch (Exception ex)
            {
                string err = ex.Message.ToString();
            }
            return result;
        }

        public Boolean SendDebitNoteEmail(String ClientName, String UsernamePasswordList, String ToEmail, string MailType)
        {

            try
            {
                String fromName = BLLCache.GetConfigurationKeyValue("FROMEMAIL");
                List<String> to = new List<String>();

                string email = "itsupport@boutique.in";
                to.Add(email);

                List<Attachment> atts = new List<Attachment>();

                if (File.Exists(Constants.ACCESSORY_FOLDER_PATH + "Challan_" + hdnChallan_Number.Value + ".pdf"))
                {
                    PoPath = Path.Combine(Constants.ACCESSORY_FOLDER_PATH, "Challan_" + hdnChallan_Number.Value + ".pdf");
                    atts.Add(new Attachment(PoPath));
                }

                this.SendEmail(fromName, to, null, null, ToEmail, MailType, atts, false, false);
                return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                return false;
            }
        }

        public Boolean SendEmail(String FromEmail, List<String> To, List<String> CC, List<String> BCC, String Subject, String Content, List<Attachment> Attachments, Boolean hasAppendAttachment, Boolean isAsync)
        {
            //System.Diagnostics.Debugger.Break();
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(FromEmail);
            mailMessage.ReplyTo = new MailAddress(FromEmail);
            mailMessage.Priority = MailPriority.Normal;
            mailMessage.Subject = MailType + "Against (" + hdnPO_Number.Value + ")";
            mailMessage.Body = "<span style='font-size:13px; font-family:Arial'>Dear Supplier, <br><br> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; With due respect, a <span style='color:gray'> Send Challan </span>" + "<b>" + hdnChallan_Number.Value + "</b> for " + "Purchase Order - " + hdnPO_Number.Value + " is raised for <span style='color:gray'> Accessory Quality </span>" + "<span style='color:#2f5597'>" + hdnAccessoryQuality.Value + "</span> for stage <span style='color:#2f5597'>Process.</span>" + " Please find the attached PDF File having all details. <br> <br> <br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <span style='font-size:10px;font-family:Arial;'> Disclaimer: This is system generated mail, for detail communicate at <span style='color:blue'> +91 120 67979 </span> </span> <br><br><b> Thanks & Regards </b> <br> BIPL Team</span>";
            //mailMessage.Body = "Dear Supplier, \n \n \t With due respect, a challan is raised against for PO NO - " + hdnPO_Number.Value + ". Please find attached file. \n \n \n \t " + content + "\n \n Thanks & Regards \n BIPL Team";

            mailMessage.IsBodyHtml = true;


            //AlternateView htmlView = AlternateView.CreateAlternateViewFromString(Subject, null, "text/html");
            //mailMessage.AlternateViews.Add(htmlView);

            if (hasAppendAttachment && Attachments != null)
            {
                int i = 1;

                foreach (Attachment attachment in Attachments)
                {
                    if (attachment.ContentStream.Length > 0)
                    {
                        LinkedResource imageId = new LinkedResource(attachment.ContentStream, "image/jpeg");
                        imageId.ContentId = "imageId" + i.ToString();
                        imageId.TransferEncoding = System.Net.Mime.TransferEncoding.Base64;
                        //htmlView.LinkedResources.Add(imageId);
                    }

                    i++;
                }
            }
            else
            {
                mailMessage.Body = mailMessage.Body;
            }

            Boolean isDebug = Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings["isDebug"]);
            //Boolean isDebug = false;

            if (isDebug)
            {
                // TODO
                mailMessage.To.Add(System.Configuration.ConfigurationManager.AppSettings["debugModeEmailId"]);
                mailMessage.Bcc.Add(Constants.WEBMASTER_EMAIL);
                //mailMessage.CC.Add("ravishankar@boutique.in");
                mailMessage.CC.Add("itsupport@boutique.in");
                //mailMessage.CC.Add("raghvinder@boutique.in");

            }
            else
            {
                foreach (String to in To)
                    mailMessage.To.Add(to);
                //mailMessage.Bcc.Add("samrat@boutique.in");
                //mailMessage.CC.Add("karan@boutique.in");
                //mailMessage.CC.Add("vinaygupta@boutique.in");
                //mailMessage.CC.Add("baldev@boutique.in");
                //mailMessage.CC.Add("shivraj@boutique.in");
                //mailMessage.CC.Add("atish@boutique.in");
                //mailMessage.CC.Add("itsupport@boutique.in");

                //mailMessage.CC.Add("ravi@boutique.in");


                mailMessage.Bcc.Add(System.Configuration.ConfigurationManager.AppSettings["debugModeEmailId"]);
                mailMessage.CC.Add("bipl_accessories@boutique.in");
            }

            SmtpClient smtpClient = new SmtpClient(Constants.SMTP_HOST, Constants.SMTP_PORT);

            if (!hasAppendAttachment && Attachments != null)
            {
                foreach (Attachment att in Attachments)
                {
                    mailMessage.Attachments.Add(att);
                }
            }

            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.Timeout = Constants.SMTP_TIMEOUT;

            if (Constants.SMTP_SECURE)
            {
                smtpClient.EnableSsl = true;
            }

            if (Constants.SMTP_IS_AUTH_REQUIRED)
            {
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new System.Net.NetworkCredential(Constants.SMTP_USERNAME, Constants.SMTP_PASSWORD);
            }
            try
            {
                smtpClient.Timeout = 300000;
                smtpClient.Send(mailMessage);
                System.Diagnostics.Trace.WriteLine("Email Having Subject of --" + Subject.ToString() + " is send successfully on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt") + "\n");
                ShowAlert("Mail Sent successfully");
                return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Some error has been occur in Email having subject of ---" + Subject.ToString() + " On" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                System.Diagnostics.Trace.WriteLine("Sorry !! Email has not been send on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt") + "\n");
                return false;
            }

            finally
            {
                try
                {
                    if (Attachments != null)
                    {
                        foreach (Attachment att in Attachments)
                        {
                            att.Dispose();
                        }

                        Attachments = null;
                    }

                    foreach (Attachment att in mailMessage.Attachments)
                    {
                        att.Dispose();
                    }

                    mailMessage = null;

                }
                catch (Exception ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                }
            }
        }

        public void ShowAlert(string stringAlertMsg)
        {
            string myStringVariable = string.Empty;
            myStringVariable = stringAlertMsg;
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);
        }

    }
}