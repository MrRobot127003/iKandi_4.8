using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.IO;
using iKandi.BLL;
using System.Data;
using System.Net.Mail;
using iKandi.Common;


namespace iKandi.Web
{
    public partial class frmMonthlyAuditReportScheduler : System.Web.UI.Page
    {
        string MailType = "Monthly Audit Report";
        AdminController objadmin = new AdminController();
        string Flag = string.Empty;
        string FitsPath = string.Empty;
        string WriteFile;

        protected void Page_Load(object sender, EventArgs e)
        {
            randorInternalAuditHtml();
            Application["InternalAuditReport"] = WriteFile;
            string url = Constants.MainUrlMail + "/InternalAuditReplica.aspx";
            string EmailContent = HttpContent(url);
            SendClientRegistrationEmail("uday", "kumar", EmailContent, MailType);
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


        public Boolean SendClientRegistrationEmail(String ClientName, String UsernamePasswordList, String ToEmail, string MailType)
        {

            try
            {
                String fromName = BLLCache.GetConfigurationKeyValue("FROMEMAIL"); 
                List<String> to = new List<String>();
                NotificationController objcontroller = new NotificationController();
                DataSet ds = objcontroller.GetpRODUCTMAIL(MailType);
                DataTable dt = ds.Tables[0];
                string email = ds.Tables[1].Rows[0]["EmailName"].ToString();
                string[] email2 = email.Split(',');

                foreach (string em in email2)
                {
                    to.Add(em);
                }

                if (MailType != string.Empty)
                {
                    this.SendEmail(fromName, to, null, null, ToEmail, MailType, null, false, false);
                }

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

                if (CC != null)
                    foreach (String to in CC)
                        mailMessage.CC.Add(to);

                if (BCC != null)
                    foreach (String to in BCC)
                        mailMessage.Bcc.Add(to);


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


        public void ShowAlert(string stringAlertMsg)
        {
            string myStringVariable = string.Empty;
            myStringVariable = stringAlertMsg;
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);
        }

        public void randorInternalAuditHtml()
        {
            AdminController adminController = new AdminController();
            WebResponse response;
            WebRequest quest;

            StreamReader reader;
            StreamWriter writer;
            string strHTML;
            List<Unit1> Units = new List<Unit1>();
            DataSet ds = adminController.GetAllUnit();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                Units.Add(new Unit1() { Id = Convert.ToString(ds.Tables[0].Rows[i]["Id"]), UnitName = Convert.ToString(ds.Tables[0].Rows[i]["UnitName"]) });
            }
            foreach (var unit in Units)
            {
                int count = adminController.InternalAuditCount(Convert.ToInt32(unit.Id));
                if (count > 0)
                {
                    quest = WebRequest.Create(Constants.MainUrlMail + "/InternalAudit_Report.aspx?UnitId=" + unit.Id);
                    quest.Timeout = Convert.ToInt32(99999999);
                    response = quest.GetResponse();
                    reader = new StreamReader(response.GetResponseStream());
                    strHTML = reader.ReadToEnd();

                    string Reallocation_ReportHtml = "";
                    DateTime now = DateTime.Now;

                    string Month = "";
                    Month = now.AddMonths(-1).ToString("MMM");

                    Reallocation_ReportHtml = "InternalAudit_" + Month + "_" + unit.UnitName + ".html";
                    writer = File.CreateText(Server.MapPath("~/Uploads/Internal_Audit/" + Reallocation_ReportHtml));
                    writer.WriteLine(strHTML);
                    writer.Close();

                    WriteFile = Constants.MainUrlMail + "/Uploads/Internal_Audit/" + Reallocation_ReportHtml;
                }
            }

        }



    }
    public class Unit1
    {
        public string Id
        {
            get;
            set;
        }
        public string UnitName
        {
            get;
            set;
        }
    }
}