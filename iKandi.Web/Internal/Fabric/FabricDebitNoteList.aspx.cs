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
using System.Text;
using System.Collections.Generic;
using iKandi.BLL;
using System.Text.RegularExpressions;
using System.Web.Caching;
using iKandi.Common;
using iKandi.Web.Components;
using System.Web.Services;
using System.Globalization;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using System.IO;

using Pechkin;
using iTextSharp.text;
using iTextSharp.text.html;
using System.Xml;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System.Web.Configuration;
using System.Text.RegularExpressions;
using System.Net;
using System.Net.Mail;
using System.Linq;
using iKandi.Common.Entities;
namespace iKandi.Web.Internal.Fabric
{
    public partial class FabricDebitNoteList : System.Web.UI.Page
    {
        public int SupplierPoId
        {
            get;
            set;
        }
        public int Debit_Note_ID
        {
            get;
            set;
        }

        public int Srv_id
        {

            get;
            set;
        }
        public static int Email_debitid;
        public static int Email_PoID;
        public static string Name;
        public static DateTime DateChecked;
        public static string PhotoPath;
        string host = "";
        FabricController objfab = new FabricController();
      
        protected void Page_Load(object sender, EventArgs e)
        {
            host = "http://" + Request.Url.Authority;
            if (Request.QueryString["SupplierPoId"] != null)
            {
                SupplierPoId = Convert.ToInt32(Request.QueryString["SupplierPoId"]);
            }
            else
            {
                SupplierPoId = 0;
            }
            if (Request.QueryString["Debit_Note_ID"] != null)
            {
                Debit_Note_ID = Convert.ToInt32(Request.QueryString["Debit_Note_ID"]);
            }
           
            else
            {
                Debit_Note_ID = 0;
            }

            if (Request.QueryString["Srv_ID"] != null)
            {
                Srv_id = Convert.ToInt32(Request.QueryString["Srv_ID"]);
            }
            else
            {
                Srv_id = 0;


            }
            if (Session["EmailDebitID"] != null && Session["EmailPoID"] != null)
            {
                Email_debitid = (int)Session["EmailDebitID"];
                Email_PoID = (int)Session["EmailPoID"];
              


            }
            if (!IsPostBack)
            {
               // EmailDebitnote(0);
                BindData();
                DataTable dt = objfab.Getbipladdress("BIPLAddress4");
                divbipladdress.InnerHtml = dt.Rows[0]["VALUE"].ToString();
                
            }
        }

        private void BindData()
        {
            FabricDebitNoteCls objAccessoryDebitNote = objfab.Get_FabricDebitNote(SupplierPoId, Debit_Note_ID, "", Srv_id);
           
            foreach (var user in iKandi.Web.Components.ApplicationHelper.Users)
            {
                if (objAccessoryDebitNote.QtyCheckedBy == user.UserID)
                {
                    Name = user.FirstName + " " + user.LastName;
                    PhotoPath = user.SignPath != string.Empty ?  user.SignPath : "NotSign.jpg"; ;
                    DateChecked = objAccessoryDebitNote.QtyCheckedDate;
                }
            }
            DataSet ds = objfab.GetFabricDebitNoteList(SupplierPoId);
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                lblPoNumber.Text = dt.Rows[0]["PO_Number"].ToString();
                hdnPO_Number.Value = dt.Rows[0]["PO_Number"].ToString();        //new line 23-04-2021
                hdnBillNumber.Value = dt.Rows[0]["PartyBillNo"].ToString();     //new line 23-04-2021
                lblSupplier.Text = dt.Rows[0]["SupplierName"].ToString(); 

                grdDebitNote.DataSource = ds.Tables[0];
                grdDebitNote.DataBind();
            }

            List<Fabric_Srv_Bill> Accessory_Srv_BillList = objfab.GetFabric_Srv_Bill_DropDownList(SupplierPoId, 0);
            if (Accessory_Srv_BillList.Count > 0)
            {
                bool isMoreThan3MonthsOld = false ;

                foreach (Fabric_Srv_Bill bill in Accessory_Srv_BillList)
                {
                    isMoreThan3MonthsOld = bill.isPartyBillOlderThan3Months;
                }

                if (isMoreThan3MonthsOld)
                {
                    btnCreate_ForAlert.Visible = true;
                    btnCreate.Visible = false;
                }
                else
                {
                    btnCreate.Visible = true;
                    btnCreate_ForAlert.Visible = false ;

                }
            }

        }
        protected void grdDebitNote_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblBillDate = (Label)e.Row.FindControl("lblBillDate");
                Label lblAmount = (Label)e.Row.FindControl("lblAmount");
                Label lblBillNo = (Label)e.Row.FindControl("lblBillNo");

                HiddenField hdnsupplierpoid = (HiddenField)e.Row.FindControl("hdnsupplierpoid");
                HiddenField hdnDebitId = (HiddenField)e.Row.FindControl("hdnDebitId");
                HiddenField hdnfab = (HiddenField)e.Row.FindControl("hdnfab");
                HiddenField hdnchallno = (HiddenField)e.Row.FindControl("hdnchallno");
                HiddenField hdnchallanid = (HiddenField)e.Row.FindControl("hdnchallanid");
                HiddenField hdnsupplierid = (HiddenField)e.Row.FindControl("hdnsupplierid");
                HiddenField hdndebitnotenumber = (HiddenField)e.Row.FindControl("hdndebitnotenumber");
                HiddenField hdnponumber = (HiddenField)e.Row.FindControl("hdnponumber");
                               

                string date  = DataBinder.Eval(e.Row.DataItem, "PartyBillDate").ToString();
                string Amount = DataBinder.Eval(e.Row.DataItem, "Amount").ToString();
                if (date != "")
                {
                    lblBillDate.Text = Convert.ToDateTime(date).ToString("dd MMM yy (ddd)");
                }
                if (Amount != "")
                {

                    lblAmount.Text = decimal.Parse(Amount).ToString("#,#.##");
                }

                System.Text.StringBuilder sb6 = new System.Text.StringBuilder();
                sb6.Append("<table id='data' style='width:100%' >");
                string challans = "";
                if (Convert.ToInt32(hdnchallanid.Value) > 0)
                {
                    challans = hdnchallno.Value;
                }
                else
                {
                    challans = "<img src='../../images/edit.png' />";
                }
                sb6.AppendFormat("<tr><td class='process' style='width: 77px;border: 0px solid #dbd8d8;text-align:center' onclick='ShowSupplierChallanScreen(" + hdnDebitId.Value + ',' + "&apos;" + hdnsupplierpoid.Value + "&apos;" + ',' + hdnchallanid.Value + ',' + "&apos;" + hdnfab.Value + "&apos;" +','+hdnDebitId.Value+ ")'>" + "<a style='font-size: 11px;cursor:pointer;color:blue;' class='test' title='' >" + challans + "</a>" + "</td></tr>");
                sb6.Append("</table>");
                e.Row.Cells[5].Text = sb6.ToString();
                if (hdnDebitId.Value != "")
                {
                    if (Convert.ToInt32(hdnsupplierpoid.Value) == Email_PoID && Convert.ToInt32(hdnDebitId.Value) == Email_debitid)
                    {
                        EmailDebitnote(Convert.ToInt32(hdnsupplierpoid.Value), hdndebitnotenumber.Value, hdnponumber.Value);


                    }
                }
            }
        }
       
        public void EmailDebitnote(int supplierid,string debitnumber,string ponumber)
        {
            if (Session["EmailDebitID"] != null && Session["EmailPoID"] != null)
            {
                 Email_debitid = (int)Session["EmailDebitID"];
                 Email_PoID = (int)Session["EmailPoID"];
                 randorHtml(Email_debitid, Email_PoID, supplierid, debitnumber, ponumber);
 
            }
          
        }
        //===============================================================================================Print area

        public void randorHtml(int debitid, int PoID, int SupplierMasterID, string debitnumber, string ponumber)
        {
            AdminController objadmin = new AdminController();
            string strHTML = "";
            string ss = host + "/../../FrmDebitNotePdf.aspx?SupplierPoId=" + PoID + "&DebitNoteId=" + debitid + "&PhotoPath=" + PhotoPath + "&DateChecked=" + DateChecked + "&Name=" + Name;

            Uri requestUri = null;
            Uri.TryCreate((ss), UriKind.Absolute, out requestUri);
            NetworkCredential nc = new NetworkCredential(ApplicationHelper.LoggedInUser.UserData.Username, BLLCache.GetConfigurationKeyValue("MASTERPASSWORD"));
            CredentialCache cache = new CredentialCache();
            cache.Add(requestUri, "Basic", nc);
            cache.Add(new Uri(ss), "NTLM", new NetworkCredential(ApplicationHelper.LoggedInUser.UserData.Username, BLLCache.GetConfigurationKeyValue("MASTERPASSWORD")));

            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(requestUri);
            request.Credentials = cache;

            request.Method = WebRequestMethods.Http.Get;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader respStream = new StreamReader(response.GetResponseStream());
            strHTML = respStream.ReadToEnd();
            //hdnemailpoid.genertaePdf(strHTML, "ss");
            string name = debitnumber + "_(" + ponumber + ")" + ".pdf";
            genertaePdf(strHTML, "ss", name);

            DataTable dtgrid = new DataTable();
            dtgrid = objadmin.GetSuppliarDetails_NEW_ForDebitNote(SupplierMasterID).Tables[0];

            string SupplierMailID = "";
            if (dtgrid.Rows.Count > 0)
            {
                //DataRow dr = dtgrid.Select("IsUserlogin1 = " + "True").First();
                //SupplierMailID = dr["Email"].ToString();
                int RowCnt;
                for (RowCnt = 0; RowCnt < dtgrid.Rows.Count; RowCnt++)
                {
                    if ((SupplierMailID).Length > 0)
                    {
                        SupplierMailID = SupplierMailID + ',' + dtgrid.Rows[RowCnt]["Email"].ToString();
                    }
                    else
                    {
                        SupplierMailID = dtgrid.Rows[RowCnt]["Email"].ToString();
                    }
                }
            }
            else
            {
                SupplierMailID = "bipl_itsupport@boutique.in";
            }
            //string SupplierMailID = "abhishek@boutique.in";

                try
                {
                    List<Attachment> atts = new List<Attachment>();
                    String fromName = BLLCache.GetConfigurationKeyValue("FROMEMAIL");
                    List<String> to = new List<String>();
                    NotificationController objcontroller = new NotificationController();
                    to.Add(SupplierMailID);
                    //to.Add("bipl_itsupport@boutique.in");
                   
                    string strFileName = HttpContext.Current.Server.MapPath("~/Uploads/fits/" + name);
                    if (File.Exists(Constants.FITS_FOLDER_PATH + name))
                    {

                        string FitsPath = Path.Combine(Constants.FITS_FOLDER_PATH, name);
                        atts.Add(new Attachment(FitsPath));
                    }
                    //string subject = "Fabric Debit Note " + debitnumber + " against PO " + ponumber;
                    string subject = "Fabric Debit Note Against Purchase Order (" + ponumber + ")";
                    this.SendEmail(fromName, to, null, null, subject, name, atts, false, false);

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Close", "alert('Mail sent')", true);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Close", "window.parent.Shadowbox.close();", true);



                }
                catch (Exception ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));

                }


           // }

            

        }
        public Boolean SendEmail(String FromEmail, List<String> To, List<String> CC, List<String> BCC, String Subject, String Content, List<Attachment> Attachments, Boolean hasAppendAttachment, Boolean isAsync)
        {
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(FromEmail);
            mailMessage.ReplyTo = new MailAddress(FromEmail);
            mailMessage.Priority = MailPriority.Normal;
            mailMessage.Subject = Subject;
            mailMessage.Body = "<span style='font-size:13px; font-family:Arial'>Dear Supplier, <br><br> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; With due respect, a <b>Debit note</b> is raised against <span style='color:gray'>" + "Bill No - </span></span><span style='color:#2f5597'>" + hdnBillNumber.Value + "</span> for <span style='color:gray'>" + "Purchase Order - </span></span><span style='color:#2f5597'>" + hdnPO_Number.Value + "</span>. Please find the attached PDF File having all details. <br> <br> <br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <span style='font-size:10px;font-family:Arial;'> Disclaimer: This is system generated mail, for detail communicate at <span style='color:blue'> +91 120 67979 </span> </span> <br><br><b> Thanks & Regards </b> <br> BIPL Team</span>";
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
                //mailMessage.Body = Subject;
                mailMessage.Body = mailMessage.Body;
            }

            Boolean isDebug = Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings["isDebug"]);

            if (isDebug)
            {
                // TODO
                mailMessage.To.Add(System.Configuration.ConfigurationManager.AppSettings["debugModeEmailId"]);
                mailMessage.Bcc.Add(Constants.WEBMASTER_EMAIL);
                mailMessage.CC.Add("itsupport@boutique.in");
            }
            else
            {
                foreach (String to in To)
                    mailMessage.To.Add(to);

                if (CC != null)
                    foreach (String to in CC)
                        mailMessage.CC.Add(to);

                if (BCC != null)
                    foreach (String to in BCC)
                        mailMessage.Bcc.Add(to);


                mailMessage.Bcc.Add(System.Configuration.ConfigurationManager.AppSettings["debugModeEmailId"]);
                mailMessage.CC.Add("Bipl_fabric@boutique.in");     
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
                // ShowAlert("Mail Sent successfully");
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
        public void genertaePdf(string HTMLCode, string PolicyFile,string filename)
        {
            string strFileName = "";
            HTMLCode = getImage(HTMLCode);
            getvartypeHTML(HTMLCode, strFileName,filename);
        }
        public void getvartypeHTML(string HTMLCode, string PolicyFile, string filename)
        {
           // string filename = "POFabric_" + "Abc" + ".pdf";
            string strFileName = HttpContext.Current.Server.MapPath("~/Uploads/fits/" + "" + filename);
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
            string strFileName = HttpContext.Current.Server.MapPath("~/Uploads/fits/Summery.pdf");
            iTextSharp.text.Document document = new iTextSharp.text.Document();
            PdfWriter.GetInstance(document, new FileStream(strFileName, FileMode.Create));
            StringReader se = new StringReader(strHtml);
            HTMLWorker obj = new HTMLWorker(document);
            document.Open();
            obj.Parse(se);
            document.Close();
        }
    }
}