using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using iKandi.Common;
using System.Web.UI.WebControls;
using iKandi.BLL.Production;
using System.Data;
using iKandi.Web.Components;
using System.Net;
using System.IO;
using iKandi.BLL;
using System.Net.Mail;
using System.Text;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using System.Globalization;
using System.Threading;
using System.Drawing;
using iTextSharp;
using Pechkin;
using iTextSharp.text.html;
using System.Xml;
using System.Runtime.CompilerServices;

using System.Web.Configuration;

using System.Text.RegularExpressions;

namespace iKandi.Web.Internal.Production
{
    public partial class POValueaddition : System.Web.UI.Page
    {
        string MailType = "Value Addition PO";
        string FitsPath = string.Empty;
        ProductionController objProductionController = new ProductionController();

        public string RiskVA_SupplierId
        {
            get;
            set;
        }
        public string RiskVA_Id
        {
            get;
            set;
        }
        public string RiskVA_PONumber
        {
            get;
            set;
        }

        


        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["RiskVASupplierId"] != null)
            {
                RiskVA_SupplierId = Request.QueryString["RiskVASupplierId"].ToString();
            }
            else
                RiskVA_SupplierId = "0";

            if (Request.QueryString["hdnVAId"] != null)
            {
                RiskVA_Id = Request.QueryString["hdnVAId"].ToString();
            }
            else
                RiskVA_Id = "-1";

            if (Request.QueryString["PONumber"] != null)
            {
                RiskVA_PONumber = Request.QueryString["PONumber"].ToString();
            }
            else
                RiskVA_PONumber = "0";



            if (!IsPostBack)
            {
                BindDropDown();
                ddlJob.SelectedValue = RiskVA_Id.ToString();
                Bind();
                

            }
        }


        protected void Bind()
        {
            PO_Valueaddition objPO_Valueaddition = objProductionController.GetValueAdditonPo(Convert.ToInt32(RiskVA_SupplierId), RiskVA_PONumber);

            lblPoNumber.Text = objPO_Valueaddition.PoNumber;
            txtDateofIssue.Text = objPO_Valueaddition.DateofIssue == DateTime.MinValue ? "" : objPO_Valueaddition.DateofIssue.ToString("dd MMM yy");
            hdnPOIssuedate.Value = objPO_Valueaddition.DateofIssue == DateTime.MinValue ? "" : objPO_Valueaddition.DateofIssue.ToString();
            txtAgreedQty.Text = objPO_Valueaddition.AgreedQty == 0 ? "" : objPO_Valueaddition.AgreedQty.ToString("N0");
            txtAgreedRate.Text = objPO_Valueaddition.AgreedRate == 0 ? "" : objPO_Valueaddition.AgreedRate.ToString();
           
           
            txtDebitforLateDelivery.Text = objPO_Valueaddition.DebitforLateDelivery == 0 ? "" : objPO_Valueaddition.DebitforLateDelivery.ToString("N0");
            txtActualEndDate.Text = objPO_Valueaddition.ActualEndDate == DateTime.MinValue ? "" : objPO_Valueaddition.ActualEndDate.ToString("dd MMM yy");
            //if (txtActualEndDate.Text == "01 Jan 00")
            //    txtActualEndDate.Text = "";
            string userStartdate = objPO_Valueaddition.UserStartDate == DateTime.MinValue ? "" : objPO_Valueaddition.UserStartDate.ToString("dd MMM yy");
            string DeliveryStartdate = objPO_Valueaddition.DeliveryStartDate == DateTime.MinValue ? "" : objPO_Valueaddition.DeliveryStartDate.ToString("dd MMM yy");
            if (DeliveryStartdate != "")
            {
                txtDeliveryStartDate.Text = DeliveryStartdate;
                lblUserStatrt.Text = userStartdate;
                lblUserStatrt.Attributes.Add("class","backColor");
                txtDeliveryStartDate.Attributes.Add("disabled", "disabled");
            }
            else {
               
                txtDeliveryStartDate.Text = userStartdate;
                lblUserStatrt.Attributes.Add("class", " ");
            }
            string userEnddate = objPO_Valueaddition.UserEndDate == DateTime.MinValue ? "" : objPO_Valueaddition.UserEndDate.ToString("dd MMM yy");
            string DeleveryEnddate = objPO_Valueaddition.DeliveryEndDate == DateTime.MinValue ? "" : objPO_Valueaddition.DeliveryEndDate.ToString("dd MMM yy");
            if (DeleveryEnddate != "")
            {
                txtDeliveryEndDate.Text = objPO_Valueaddition.DeliveryEndDate == DateTime.MinValue ? "" : objPO_Valueaddition.DeliveryEndDate.ToString("dd MMM yy");
                lblUserEnd.Text = userEnddate;
                lblUserEnd.Attributes.Add("class", "backColor");
                txtDeliveryEndDate.Attributes.Add("disabled", "disabled");
            }
            else
            {
                txtDeliveryEndDate.Text = userEnddate;
                lblUserEnd.Attributes.Add("class", " ");
            }


            txtDebitforAlteration.Text = objPO_Valueaddition.DebitforAltration == 0 ? "" : objPO_Valueaddition.DebitforAltration.ToString("N0");
            lblSupplierName.Text = objPO_Valueaddition.SupplierName;
            chkVendorSig.Checked = objPO_Valueaddition.VendorSignature == true ? true : false;
            chkBIPLMngtSig.Checked = objPO_Valueaddition.BIPLMngtSignature == true ? true : false;
            chkGMPlanningSig.Checked = objPO_Valueaddition.GMPlanningSignature == true ? true : false;
            var lblSAMVal = Math.Round(Convert.ToDecimal(objPO_Valueaddition.SAM), 0);
            lblSAM.Text = lblSAMVal.ToString();
            txtStyleNumber.Text = objPO_Valueaddition.StyleNo;
            txtSerialNumber.Text = objPO_Valueaddition.SerialNo;
            divtablecontent.InnerHtml = objPO_Valueaddition.RateHistory;//dt.Rows[0]["VALUE"].ToString();
            ddlUnit.SelectedValue = objPO_Valueaddition.Unit == "" ? "pcs" : objPO_Valueaddition.Unit;
            ddlJob.SelectedValue = objPO_Valueaddition.job;
            txtArea.Text = objPO_Valueaddition.Remarks;
            if (objPO_Valueaddition.DateofIssue == DateTime.MinValue)
                txtDateofIssue.Text = DateTime.Now.ToString("dd MMM yy");

            chkGMPlanningSig.Enabled = ApplicationHelper.LoggedInUser.UserData.DesignationID == 19 || ApplicationHelper.LoggedInUser.UserData.DesignationID == 111 ? true : false;
            chkBIPLMngtSig.Enabled = ApplicationHelper.LoggedInUser.UserData.DesignationID == 13 ? true : false;
            chkVendorSig.Enabled = ApplicationHelper.LoggedInUser.UserData.DesignationID == 46 || ApplicationHelper.LoggedInUser.UserData.DesignationID== 158 ? true : false;

            if (chkGMPlanningSig.Checked == false)
            {
                chkBIPLMngtSig.Enabled = false;
                //chkVendorSig.Enabled = false;

            }
            if (ApplicationHelper.LoggedInUser.UserData.DesignationID == 19 || ApplicationHelper.LoggedInUser.UserData.DesignationID == 111)
            {
                chkVendorSig.Enabled = true;

            }
            if (chkGMPlanningSig.Checked == true)
            {
                chkGMPlanningSig.Enabled = false;
                chkVendorSig.Enabled = true;
                lblGMName.Visible = true;
                if (objPO_Valueaddition.GMPlanningID == "30")
                    lblGMName.Text = "ShivRaj";
                if (ApplicationHelper.LoggedInUser.UserData.DesignationID == 46)
                {
                    if (chkVendorSig.Checked == true)
                    {
                        chkVendorSig.Enabled = false;
                        chkGMPlanningSig.Enabled = false;
                    }
                    else
                    {
                        chkVendorSig.Enabled = true;
                    }
                }
                if (ApplicationHelper.LoggedInUser.UserData.DesignationID == 13)
                {
                    chkVendorSig.Enabled = false;
                    chkBIPLMngtSig.Enabled = true;
                }
            }
            if (chkVendorSig.Checked == true && chkGMPlanningSig.Enabled == true)
            {
                chkBIPLMngtSig.Enabled = false;
                chkVendorSig.Enabled = false;

            }
            if (chkVendorSig.Checked == true)
            {
                lblVendorName.Text = objPO_Valueaddition.SupplierName;

            }
            if (chkBIPLMngtSig.Checked == true)
            {
                lblManagmentName.Visible = true;

            }

            lblVendorSigDate.Text = objPO_Valueaddition.VendorSignatureDate == DateTime.MinValue ? "" : objPO_Valueaddition.VendorSignatureDate.ToString("dd MMM yy (ddd)");
            lblBIPLMgntSigDate.Text = objPO_Valueaddition.BIPLMngtSignatureDate == DateTime.MinValue ? "" : objPO_Valueaddition.BIPLMngtSignatureDate.ToString("dd MMM yy (ddd)");
            lblGMPlanningSigDate.Text = objPO_Valueaddition.GMPlanningSignatureDate == DateTime.MinValue ? "" : objPO_Valueaddition.GMPlanningSignatureDate.ToString("dd MMM yy (ddd)");

            DataTable dt = objProductionController.GetValueAdditonPOHistory(Convert.ToInt32(RiskVA_SupplierId), RiskVA_PONumber);
            string str = "";
            str = "<ul>";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                str += "<li>" + dt.Rows[i]["DetailsDescription"] + "</li>";
            }
            str += "</ul>";
            divHistory.InnerHtml = str;
            if (objPO_Valueaddition.BIPLMngtSignature == true)
                chkBIPLMngtSig.Enabled = false;

            if (objPO_Valueaddition.GMPlanningSignature == true)
            {
                chkGMPlanningSig.Enabled = false;
                //txtSerialNumber.Enabled = true;
                //txtStyleNumber.Enabled = true;
            }

            if (objPO_Valueaddition.VendorSignature == true)
                chkVendorSig.Enabled = false;

        }
        protected void BindDropDown()
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            dt = objProductionController.BindPODropDown();

            if (dt.Rows.Count > 0)
            {
                ddlJob.DataSource = dt;
                ddlJob.DataTextField = "ValueAdditionName";
                ddlJob.DataValueField = "ValueAdditionID";
                ddlJob.DataBind();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            btnSubmit.Enabled = false;
            if (txtDateofIssue.Text == string.Empty)
            {
                ShowAlert("Date of Issue cannot blank!");
                txtDateofIssue.Focus();
                return;
            }
            if (txtAgreedQty.Text == string.Empty)
            {
                ShowAlert("Agreed Qty. cannot blank!");
                txtAgreedQty.Focus();
                return;
            }

            PO_Valueaddition poValueaddition = new PO_Valueaddition();
            //poValueaddition.DateofIssue = Convert.ToDateTime(txtDateofIssue.Text.ToString());
            if (hdnPOIssuedate.Value.ToString() != "")
            {
                poValueaddition.DateofIssue = Convert.ToDateTime(hdnPOIssuedate.Value.ToString());
            }
            else
            {
                poValueaddition.DateofIssue = DateTime.Now;
            }
            poValueaddition.AgreedQty = Convert.ToInt32(txtAgreedQty.Text.Replace(",", ""));
            poValueaddition.AgreedRate = txtAgreedRate.Text == "" ? 0 : Convert.ToDecimal(txtAgreedRate.Text);
            poValueaddition.DeliveryStartDate = txtDeliveryStartDate.Text == "" ? DateTime.MinValue : Convert.ToDateTime(txtDeliveryStartDate.Text);
            poValueaddition.DeliveryEndDate = txtDeliveryEndDate.Text == "" ? DateTime.MinValue : Convert.ToDateTime(txtDeliveryEndDate.Text);
            poValueaddition.ActualEndDate = txtActualEndDate.Text == "" ? DateTime.MinValue : Convert.ToDateTime(txtActualEndDate.Text);
            poValueaddition.DebitforLateDelivery = txtDebitforLateDelivery.Text == "" ? 0 : Convert.ToDecimal(txtDebitforLateDelivery.Text.Replace(",", ""));
            poValueaddition.DebitforAltration = txtDebitforAlteration.Text == "" ? 0 : Convert.ToDecimal(txtDebitforAlteration.Text.Replace(",", ""));
            poValueaddition.RiskVASupplierid = Convert.ToInt32(RiskVA_SupplierId);
            poValueaddition.SupplierName = lblSupplierName.Text;
            poValueaddition.VendorSignature = chkVendorSig.Checked == true ? true : false;
            poValueaddition.BIPLMngtSignature = chkBIPLMngtSig.Checked == true ? true : false;
            poValueaddition.GMPlanningSignature = chkGMPlanningSig.Checked == true ? true : false;
            poValueaddition.Unit = ddlUnit.SelectedValue;
            poValueaddition.UserId = ApplicationHelper.LoggedInUser.UserData.UserID;
            poValueaddition.job = ddlJob.SelectedValue;
            poValueaddition.Remarks = txtArea.Text;
            poValueaddition.SerialNo = txtSerialNumber.Text;
            poValueaddition.StyleNo = txtStyleNumber.Text;
            poValueaddition.PoNumber = lblPoNumber.Text;



            int SaveValueadd = objProductionController.AddValueAdditonPo(poValueaddition);
            //if (SaveValueadd == 0)
            //{
            //ShowConfirmed("Do You want send Mail to Vendor");
            string VA_SupplierName = lblSupplierName.Text;

            if (chkGMPlanningSig.Checked == true)
            {
                var checkRadio = rdbYes.Checked;
                if (checkRadio == true)
                {
                    //  randorPOValueadditionHtml();
                    randorHtml();
                    string url = "http://boutique.in/POValueadditionReplica.aspx?RiskVASupplierId=" + RiskVA_SupplierId + "&VA_SupplierName=" + VA_SupplierName;
                    //string url = "http://localhost:3220/POValueadditionReplica.aspx?RiskVASupplierId=" + RiskVA_SupplierId + "&VA_SupplierName=" + VA_SupplierName;
                    string EmailContent = HttpContent(url);
                    SendClientRegistrationEmail("test", "kumar", EmailContent, MailType, lblSupplierName.Text);
                }

            }
            //else
            //{
            //    ShowAlert("Saved Successfully!");
            //    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ClosePO", "funcReloadClosePO()", true);
            //}
            ShowAlert("Saved Successfully!");
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ClosePO", "funcReloadClosePO()", true);
            return;
            //}

        }
        public void ShowAlert(string stringAlertMsg)
        {
            string myStringVariable = string.Empty;
            myStringVariable = stringAlertMsg;
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);
        }
        public void ShowConfirmed(string stringAlertMsg)
        {
            string myStringVariable = string.Empty;
            myStringVariable = stringAlertMsg;
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "confirm('" + myStringVariable + "');", true);
        }

        //public void randorPOValueadditionHtml()
        //{
        //    WebResponse response;
        //    WebRequest quest;
        //    StreamReader reader;
        //    string strHTML;

        //     quest = WebRequest.Create("http://boutique.in:82/POValueAdditionMail.aspx?RiskVASupplierId=" + RiskVA_SupplierId);
        //   // quest = WebRequest.Create("http://localhost:3220/POValueAdditionMail.aspx?RiskVASupplierId=" + RiskVA_SupplierId);
        //    quest.Timeout = Convert.ToInt32(99999999);
        //    response = quest.GetResponse();
        //    reader = new StreamReader(response.GetResponseStream());
        //    strHTML = reader.ReadToEnd();
        //    string strFileName = HttpContext.Current.Server.MapPath("~/Uploads/Fits/" + "POValueaddition_" + RiskVA_SupplierId + ".pdf");
        //    iTextSharp.text.Document document = new iTextSharp.text.Document(PageSize.A4, 10, 10, 10, 10);
        //    document.GetTop(10);
        //    document.Header = null;
        //    //document.SetMargins(10,10,10,10);


        //    PdfWriter.GetInstance(document, new FileStream(strFileName, FileMode.Create));
        //    StringReader se = new StringReader(strHTML);
        //    HTMLWorker obj = new HTMLWorker(document);
        //    document.Open();
        //    //document.SetMargins(-100, 0, 0, 0);
        //    //document.NewPage();
        //    obj.Parse(se);
        //    document.Close();

        //}

        public void randorHtml()
        {
            WebRequest quest;
            WebResponse ponse;
            StreamReader reader;
           
            string strHTML;
            //quest = WebRequest.Create("http://localhost:3240/POValueAdditionMail.aspx?RiskVASupplierId=" + RiskVA_SupplierId);
            quest = WebRequest.Create("http://boutique.in/POValueAdditionMail.aspx?RiskVASupplierId=" + RiskVA_SupplierId);
            quest.Timeout = Convert.ToInt32(99999999);
            ponse = quest.GetResponse();
            reader = new StreamReader(ponse.GetResponseStream());
            strHTML = reader.ReadToEnd();
            genertaePdf(strHTML, "ss");
        }
        public void genertaePdf(string HTMLCode, string PolicyFile)
        {
            string strFileName = HttpContext.Current.Server.MapPath("~/Uploads/fits/" + "POValueaddition_" + RiskVA_SupplierId + ".pdf");
            HTMLCode = getImage(HTMLCode);
            getvartypeHTML(HTMLCode, strFileName);
        }
        public void getvartypeHTML(string HTMLCode, string PolicyFile)
        {
            string strFileName = HttpContext.Current.Server.MapPath("~/Uploads/fits/" + "POValueaddition_" + RiskVA_SupplierId + ".pdf");

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
        public string getTitle(string input)
        {
            if (input == null)
                return string.Empty;
            string tempInput = input;
            string pattern = @"(?<=<title.*>)([\s\S]*)(?=</title>)";
            string title = string.Empty;

            //get and remove Title in HTML..
            foreach (Match m1 in Regex.Matches(input, pattern, RegexOptions.IgnoreCase | RegexOptions.Multiline))
            {
                if (m1.Success)
                {
                    string tempM = m1.Value;
                    try
                    {
                        //tempM = tempM.Remove(m1.Index, m1.Length);
                        tempM = tempM.Replace(m1.Value, title);

                        //insert new url img tag in whole html code
                        //tempInput = tempInput.Remove(m1.Index, m1.Length);
                        tempInput = tempInput.Replace(m1.Value, tempM);
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                        System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                    }
                }
                else
                {
                    return "";
                }
            }
            return tempInput;
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
                            //src = src.Replace("../../", "/ErmNew/");
                            //src = src.Replace("../", "/ErmNew/");
                            src = "src=\"" + imgsrc + "\"";
                        }
                        if (src == "../../signdt.jpg" || src == "../signdt.jpg")
                        {
                            string imgsrc = @Server.MapPath("~/Signature/signdt.jpg");
                            //src = src.Replace("../../", "/ErmNew/");
                            //src = src.Replace("../", "/ErmNew/");
                            src = "src=\"" + imgsrc + "\"";
                        }
                        if (src.ToLower().Contains("http://") == false)
                        {
                            //Insert new URL in img tag
                            //src = "src=\"" + context.Request.Url.Scheme + "://" +
                            //context.Request.Url.Authority + src + "\"";
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
                                //string imgsrc = @Server.MapPath("~/imgSignature/" + dt + ".jpg");
                                //string html = "<html><div><img src='" + imgsrc + "'</div></html>";
                                //generatepdf(html);
                                //File.Delete(imgsrc);
                            }
                        }
                    }
                }
            }
            return tempInput;
        }
        public void CreatePDFDocument(string strHtml)
        {
            string strFileName = HttpContext.Current.Server.MapPath("~/Uploads/fits/" + "POValueaddition_" + RiskVA_SupplierId + ".pdf");
            iTextSharp.text.Document document = new iTextSharp.text.Document();
            PdfWriter.GetInstance(document, new FileStream(strFileName, FileMode.Create));
            StringReader se = new StringReader(strHtml);
            HTMLWorker obj = new HTMLWorker(document);
            document.Open();
            obj.Parse(se);
            document.Close();
        }

        public static string HttpContent(string url)
        {
            string result = "";
            try
            {
                HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(url);
                req.Timeout = 80000000;
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


        public Boolean SendClientRegistrationEmail(String ClientName, String UsernamePasswordList, String ToEmail, string MailType, string SupplierName)
        {

            try
            {
                String fromName = BLLCache.GetConfigurationKeyValue("FROMEMAIL");
                List<String> to = new List<String>();

                NotificationController objcontroller = new NotificationController();
                DataSet ds = objcontroller.GetSupplierNameMail(SupplierName);
                DataTable dt = ds.Tables[0];

                string email = ds.Tables[0].Rows[0]["EmailName"].ToString();
                string[] email2 = email.Split(',');
                foreach (string em in email2)
                {
                    to.Add(em);
                }

               

                List<Attachment> atts = new List<Attachment>();

                if (File.Exists(Constants.FITS_FOLDER_PATH + "POValueaddition_" + RiskVA_SupplierId + ".pdf"))
                {

                    FitsPath = Path.Combine(Constants.FITS_FOLDER_PATH, "POValueaddition_" + RiskVA_SupplierId + ".pdf");
                    atts.Add(new Attachment(FitsPath));
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
            mailMessage.Subject = MailType;
            mailMessage.IsBodyHtml = true;


            AlternateView htmlView = AlternateView.CreateAlternateViewFromString(Subject, null, "text/html");
            mailMessage.AlternateViews.Add(htmlView);

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
                        htmlView.LinkedResources.Add(imageId);
                    }

                    i++;
                }
            }
            else
            {
                mailMessage.Body = Subject;
            }

            Boolean isDebug = Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings["isDebug"]);
            //Boolean isDebug = false;

            if (isDebug)
            {
                // TODO
                mailMessage.To.Add(System.Configuration.ConfigurationManager.AppSettings["debugModeEmailId"]);
                mailMessage.Bcc.Add(Constants.WEBMASTER_EMAIL);
            }
            else
            {
                foreach (String to in To)
                    mailMessage.To.Add(to);

                // Commented bellow based on sam advise on dated 6 jul 2022
                //mailMessage.Bcc.Add("samrat@boutique.in");                
                //mailMessage.CC.Add("vinaygupta@boutique.in");
                //mailMessage.CC.Add("baldev@boutique.in");
                // End of comment
                mailMessage.CC.Add("karan@boutique.in");
                //mailMessage.CC.Add("shivraj@boutique.in");
                //mailMessage.CC.Add("atish@boutique.in");
                mailMessage.CC.Add("itsupport@boutique.in");
                // Added on the request of the Vijay sharma on dated 6 july 2022
                mailMessage.Bcc.Add("Bipl_fabric@boutique.in");
                // End of code
                //if (CC != null)
                //    foreach (String to in CC)
                //        mailMessage.CC.Add(to);

                //if (BCC != null)
                //    foreach (String to in BCC)
                //        mailMessage.Bcc.Add(to);


                mailMessage.Bcc.Add(System.Configuration.ConfigurationManager.AppSettings["debugModeEmailId"]);


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
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ClosePO", "funcReloadClosePO()", true);
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
                catch (Exception ex) {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                }
            }
        }

    }
}