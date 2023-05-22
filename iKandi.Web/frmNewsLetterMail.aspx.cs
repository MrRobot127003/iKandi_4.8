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
    public partial class frmNewsLetterMail : System.Web.UI.Page
    {
        string MailType = "News Letter";
        string Flag = string.Empty;
       
        string EmailContent = string.Empty;
        string WriteFile, WriteFile_c45_46;
        protected void Page_Load(object sender, EventArgs e)
        {
            randorNewsLetterC47Html();
            Application["NewsLetterC47"] = WriteFile;

            randorNewsLetterC45_46Html();
            Application["NewsLetterC45_46"] = WriteFile_c45_46;
            string HourlyReportMailBody = "<div style='font-family:arial; font-size:12px'><div> Hi Team BIPL,</div><br/> <div><a href='" + WriteFile + "' style='color:blue; text-decoration:none;'>News Letter of c47</a> </div><div><a href='" + WriteFile_c45_46 + "' style='color:blue; text-decoration:none;'>News Letter of C45-46</a> </div><br/><br/> <div> <strong>Thanks & Best Regards </strong> <br/> BIPL IE & Production Teams</div><div style='margin-top:10px;'>   <img src='http://boutique.in/images/certificate.jpg' /></div></div>";
            SendClientRegistrationEmail("uday", "kumar", HourlyReportMailBody, MailType);
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
            mailMessage.Subject = "Production Plan";

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

            // Give your ASP.NET Page address
            quest = WebRequest.Create("http://192.168.0.4/NewsLetterC47.aspx");
            quest.Timeout = Convert.ToInt32(99999999);
            ponse = quest.GetResponse();
            reader = new StreamReader(ponse.GetResponseStream());

            strHTML = reader.ReadToEnd();



            string Reallocation_ReportHtml = "";
            DateTime now = DateTime.Now;
            string Day = now.ToString("dd");
            string Month = now.ToString("MMM");

            Reallocation_ReportHtml = "NewsLetterC47_" + Day + Month + ".html";
            writer = File.CreateText(Server.MapPath("~/Uploads/NewsLetter/" + Reallocation_ReportHtml));
            writer.WriteLine(strHTML);
            writer.Close();
            //WriteFile = Server.MapPath("~/Uploads/Fits/" + HourlyReportHtml);
            WriteFile = "http://boutique.in/uploads/NewsLetter/" + Reallocation_ReportHtml;
            // Response.WriteFile();   
        }


        public void randorNewsLetterC45_46Html()
        {
            WebRequest quest;
            WebResponse ponse;
            StreamReader reader;
            StreamWriter writer;
            string strHTML;

            // Give your ASP.NET Page address
            quest = WebRequest.Create("http://192.168.0.4/NewsLetterC45_46.aspx");
            quest.Timeout = Convert.ToInt32(99999999);
            ponse = quest.GetResponse();
            reader = new StreamReader(ponse.GetResponseStream());

            strHTML = reader.ReadToEnd();



            string Reallocation_ReportHtml = "";
            DateTime now = DateTime.Now;
            string Day = now.ToString("dd");
            string Month = now.ToString("MMM");

            Reallocation_ReportHtml = "NewsLetterC45_46_" + Day + Month + ".html";
            writer = File.CreateText(Server.MapPath("~/Uploads/NewsLetter/" + Reallocation_ReportHtml));
            writer.WriteLine(strHTML);
            writer.Close();
            //WriteFile = Server.MapPath("~/Uploads/Fits/" + HourlyReportHtml);
            WriteFile_c45_46 = "http://boutique.in/uploads/NewsLetter/" + Reallocation_ReportHtml;
            // Response.WriteFile();   
        }
    }
}