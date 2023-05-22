using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using iKandi.Common;
using System.IO;
using iKandi.BLL;
using System.Data;
using System.Net;
using iKandi.BLL.Production;

namespace iKandi.Web
{
    public partial class frmHRAttandenceSheetScheduler : System.Web.UI.Page
    {
        string MailType = "Attandence Sheet";
        string Flag = string.Empty;

        string EmailContent = string.Empty;
        string WriteFile;
        protected void Page_Load(object sender, EventArgs e)
        {
            //            string name = "Upcomming_Exfactory" + ".xlsx";
            //            if (File.Exists("\\\\192.168.0.4\\UpComming_Exfactory\\Upcomming_Exfactory.xlsx"))
            //            {

            //                FitsPath = Path.Combine("\\\\192.168.0.4\\Upcomming_Exfactory\\", name);
            //                atts.Add(new Attachment(FitsPath));
            //            }
            //if 
            //File.Delete(file);
            //==========================For temparory comentes
            randorNewsLetterC47Html();
            Application["AttandenceSheet"] = WriteFile;
            //========================End commentes
            string url = Constants.MainUrlMail + "/HRStaffLateComersEmployeeReport.aspx";
            string EmailContent = HttpContent(url);
            //string HourlyReportMailBody = "<div style='font-family:arial; font-size:12px'><div> Hi Team BIPL,'" + EmailContent + "' </div><br/> <div><a href='" + WriteFile + "' style='color:blue; text-decoration:none;'>Today Attendance Sheet</a> </div><br/><br/><iframe src='HRStaffLateComersEmployeeReport.aspx'></iframe><br/><br/> <div> <strong>Thanks & Best Regards </strong> <br/> HR Teams</div><div style='margin-top:10px;'>   <img src='http://boutique.in/images/certificate.jpg' /></div></div>";
            SendClientRegistrationEmail("uday", "kumar", EmailContent, MailType);
        }
        public static string HttpContent(string url)
        {

            string result = "";
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(url);
            req.Timeout = 2000000;
            req.UserAgent = "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 6.1; WOW64; Trident/4.0; SLCC2; .NET CLR 2.0.50727; .NET CLR 3.5.30729; .NET CLR 3.0.30729; .NET4.0C; .NET4.0E)";
            using (var resp = req.GetResponse())
            {
                //var html = new StreamReader(resp.GetResponseStream()).ReadToEnd();
                result = new StreamReader(resp.GetResponseStream()).ReadToEnd();
            }




            //System.Net.WebRequest objRequest = System.Net.HttpWebRequest.Create(url.Trim());
            //objRequest.Timeout = 200000;
            //StreamReader sr = new StreamReader(objRequest.GetResponse().GetResponseStream());
            //result = sr.ReadToEnd();
            //sr.Close();
            return result;


        }
        public Boolean SendClientRegistrationEmail(String ClientName, String UsernamePasswordList, String ToEmail, string mailType)
        {

            try
            {
                String fromName = BLLCache.GetConfigurationKeyValue("FROMEMAIL"); //Constants.KEY_FROM_EMAIL

                //Abhishek
                List<String> to = new List<String>();
                //SendMailUsingKeyValue("BIPL.SendClientRegistrationEmail", out to);

                NotificationController objcontroller = new NotificationController();
                DataSet ds = objcontroller.GetpRODUCTMAIL(mailType);
                DataTable dt = ds.Tables[0];
                int StartHH = Convert.ToInt32(dt.Rows[0]["Hours"].ToString());
                int MinMM = Convert.ToInt32(dt.Rows[0]["Min"].ToString());
                string DaysName = dt.Rows[0]["Days"].ToString();
                string[] values = DaysName.Split(',');
                string email = ds.Tables[1].Rows[0]["EmailName"].ToString();
                //string email ="prabhaker@boutique.in,tanka@boutique.in";
                string[] email2 = email.Split(',');
                foreach (string em in email2)
                {
                    to.Add(em);
                }
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = values[i].Trim();
                }
                DateTime Extacttime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, StartHH, MinMM, 0);
                //uncommented by ravi
                //if (Flag != string.Empty)
                //{
                //    if (Flag == "Direct")
                //    {
                this.SendEmail(fromName, to, null, null, ToEmail, MailType, null, false, false);
                //    }
                //}
                //Done
                if (DateTime.Now == Extacttime)
                {




                    foreach (string WeekName in values)
                    {

                        string days = DateTime.Now.DayOfWeek.ToString();

                        //if (WeekName == days)
                        //{
                        //    this.SendEmail(fromName, to, null, null, ToEmail, MailType, null, false, false);
                        //}
                        //switch (WeekName)
                        switch (WeekName)
                        {
                            case "Monday":


                                this.SendEmail(fromName, to, null, null, ToEmail, MailType, null, false, false);
                                break;
                            case "Tuesday":
                                this.SendEmail(fromName, to, null, null, ToEmail, MailType, null, false, false);
                                break;
                            case "Wednesday":
                                this.SendEmail(fromName, to, null, null, ToEmail, MailType, null, false, false);
                                break;
                            case "Thursday":
                                this.SendEmail(fromName, to, null, null, ToEmail, MailType, null, false, false);
                                break;
                            case "Friday":
                                this.SendEmail(fromName, to, null, null, ToEmail, MailType, null, false, false);
                                break;
                            case "Saturday":
                                this.SendEmail(fromName, to, null, null, ToEmail, MailType, null, false, false);
                                break;
                            default:
                                //Console.WriteLine("Invalid grade");
                                break;
                        }
                    }

                }


                return true;

                //{


                //  




                //}
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                // this.SendErrorEmail(ex.Message + "\n" + ex.StackTrace);
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
            //if (Request.QueryString["MailType"] == "PenaltyDailyMailReports")
            //    mailMessage.Subject = "Daily Shipment Report";
            //else if (Request.QueryString["MailType"] == "QApendingReports")
            //    mailMessage.Subject = "QA Activity Report";
            //else
            //    mailMessage.Subject = "Hourly Pro;duction Report";
            mailMessage.Subject = "Today Attendance sheet";

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
                //   ShowAlert("Mail Sent successfully");
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
        public void randorNewsLetterC47Html()
        {
            WebRequest quest;
            WebResponse ponse;
            StreamReader reader;
            StreamWriter writer;
            string strHTML;

            // Give your ASP.NET Page address http://192.168.0.4/HRStaffAttandenceReport.aspx
            quest = WebRequest.Create(Constants.MainUrlMail + "/frmHRSheet.aspx");
            quest.Timeout = Convert.ToInt32(99999999);
            ponse = quest.GetResponse();
            reader = new StreamReader(ponse.GetResponseStream());

            strHTML = reader.ReadToEnd();
            


            string Reallocation_ReportHtml = "";
             string MonthSelection="";
             DateTime now = DateTime.Now;
            string Day = now.ToString("dd");
            string Month="";
            if (Application["Hr_AttandenceSheet_Selection"] == null)
            {
                
                MonthSelection = "0";
            }
            else
            {
                MonthSelection = Application["Hr_AttandenceSheet_Selection"].ToString();
            }
           

            if (MonthSelection == "0")
            {
                Month = now.ToString("MMM");
            }
            else
            {
                Month = MonthSelection;
                int iMonthNo = Convert.ToInt32(Month);
                DateTime dtDate = new DateTime(2000, iMonthNo, 1);
                string sMonthName = dtDate.ToString("MMM");
                string sMonthFullName = dtDate.ToString("MMMM");
                Month = sMonthFullName;
                Application["Hr_AttandenceSheet_Selection"] = "0";
            }

            Reallocation_ReportHtml = "AttandenceSheet_" + Day + Month + ".html";
            writer = File.CreateText(Server.MapPath("~/Uploads/NewsLetter/" + Reallocation_ReportHtml));
            writer.WriteLine(strHTML);
            writer.Close();
            //WriteFile = Server.MapPath("~/Uploads/NewsLetter/" + Reallocation_ReportHtml);
            WriteFile = Constants.MainUrlMail + "/uploads/NewsLetter/" + Reallocation_ReportHtml;
            // Response.WriteFile();   
        }
    }
}