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
    public partial class Mailhourlyreport : System.Web.UI.Page
    {
        string MailType = string.Empty;
        string Flag = string.Empty;
        string url;
        string EmailContent = string.Empty;
        string WriteFile, ReportName;
        string name = "";
        string FitsPath = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Request.QueryString["MailType"] == "PenaltyDailyMailReports")
                url = Constants.MainUrlMail + "/frmLaxmanReport.aspx";
            else if (Request.QueryString["MailType"] == "QApendingReports")
                url = Constants.MainUrlMail + "/FrmActivityQALaxmanReport.aspx";
            else if (Request.QueryString["MailType"] == "Sales")
                url = Constants.MainUrlMail + "/frmSalesRevenue.aspx";
            else
                url = Constants.MainUrlMail + "/HourlyReportBIPL.aspx";


            string v = Request.QueryString["Flag"];
            if (v != null)
            {
                Flag = v;
            }
            string a = Request.QueryString["MailType"];
            if (v != null)
            {
                MailType = a;
            }


            //string EmailContent = HttpContent(url);

            if (url == Constants.MainUrlMail + "/HourlyReportBIPL.aspx" || url == Constants.MainIpMail + "/frmSalesRevenue.aspx")
            {
                string HourlyReportMailBody = "";
                //if (Application["HourlyError"] == "Sucess")
                //{
                if (url == Constants.MainUrlMail + "/HourlyReportBIPL.aspx")
                {
                    randorHourlyHtml();
                    HourlyReportMailBody = "<div style='font-family:arial; font-size:12px'><div> Hi Team BIPL,</div><br/> <div> &nbsp; &nbsp;Please <a href='" + WriteFile + "' style='color:blue; text-decoration:none;'>click here</a> to access <span style='color:gray'>hourly production figures </span> of " + ReportName + "</div><br/><br/> <div> <strong>Thanks & Best Regards </strong> <br/> BIPL IE & Production Teams</div><div style='margin-top:10px;'>   <img src='images/certificate.jpg' /></div></div>";
                    SendClientRegistrationEmail("uday", "kumar", HourlyReportMailBody, MailType);
                }
                else
                {
                    randorSalesRevenueHtml();
                    HourlyReportMailBody = "<div style='font-family:arial; font-size:12px'><div> Hi Team BIPL,</div><br/> <div> &nbsp; &nbsp;Please <a href='" + WriteFile + "' style='color:blue; text-decoration:none;'>click here</a> to access <span style='color:gray'>Sales Revenue</span> of " + ReportName + "</div><br/><br/> <div> <strong>Thanks & Best Regards </strong> <br/> BIPL Admin</div><div style='margin-top:10px;'>   <img src='images/certificate.jpg' /></div></div>";
                    SendClientRegistrationEmail("uday", "kumar", HourlyReportMailBody, MailType);
                }
                //}

            }
            else
            {
                EmailContent = HttpContent(url);
                if (url == Constants.MainUrlMail + "/frmLaxmanReport.aspx")
                {

                    SendClientRegistrationEmail_ForUpcommingExfactory("uday", "kumar", EmailContent, MailType);

                }
                else
                {

                    SendClientRegistrationEmail("uday", "kumar", EmailContent, MailType);
                }

            }


        }


        public void randorHourlyHtml()
        {
            WebRequest quest;
            WebResponse ponse;
            StreamReader reader;
            StreamWriter writer;
            string strHTML;
            ProductionController objProductionController = new ProductionController();
            DataSet ds = objProductionController.GetHourlyReportStyleCode("", "", -1, -1, -1, -1, "SlotTime");

            // Give your ASP.NET Page address
            quest = WebRequest.Create(Constants.MainUrlMail + "/HourlyReportBIPL.aspx");
            quest.Timeout = Convert.ToInt32(99999999);
            ponse = quest.GetResponse();
            reader = new StreamReader(ponse.GetResponseStream());

            strHTML = reader.ReadToEnd();

            string slotId = "";
            string SlotStartTime = "";
            string SlotEndTime = "";

            slotId = ds.Tables[1].Rows[0]["SlotID"].ToString();

            DataTable dtSlotTime = ds.Tables[0];

            DataRow[] results = dtSlotTime.Select("SlotID = " + slotId);

            //DataView dv = new DataView(dtSlotTime);
            //dv.RowFilter = "SlotID = " + slotId;
            SlotStartTime = results[0]["SlotStart"].ToString();
            SlotEndTime = results[0]["SlotEnd"].ToString();

            //SlotStartTime = dtClients.Tables[1].Rows[0]["start"].ToString();
            //SlotEndTime = dtClients.Tables[1].Rows[0]["EndTime"].ToString();
            if (slotId == "11")
                DeleteHrsReportBeforeTenDays();

            string HourlyReportHtml = "";
            DateTime now = DateTime.Now;
            string Day = now.ToString("dd");
            string Month = now.ToString("MMM");
            //ReportName = "HourlyReport_" + Day + Month + "_Slot" + slotId
            ReportName = "Slot " + slotId + "  <b>" + SlotStartTime + "</b> to <b>" + SlotEndTime + "</b>";
            HourlyReportHtml = "HourlyReport_" + Day + Month + "_Slot" + slotId + ".html";
            writer = File.CreateText(Server.MapPath("~/Uploads/HrlyReports/" + HourlyReportHtml));
            writer.WriteLine(strHTML);
            writer.Close();
            //WriteFile = Server.MapPath("~/Uploads/Fits/" + HourlyReportHtml);
            WriteFile = Constants.MainUrlMail + "/uploads/fits/" + HourlyReportHtml;
            // Response.WriteFile();   
        }
        public void randorSalesRevenueHtml()
        {
            WebRequest quest;
            WebResponse ponse;
            StreamReader reader;
            StreamWriter writer;
            string strHTML;
            ProductionController objProductionController = new ProductionController();
            DataSet dtClients = objProductionController.GetSlotId();

            // Give your ASP.NET Page address
            quest = WebRequest.Create(Constants.MainUrlMail + "/frmSalesRevenue.aspx");
            quest.Timeout = Convert.ToInt32(99999999);
            ponse = quest.GetResponse();
            reader = new StreamReader(ponse.GetResponseStream());

            strHTML = reader.ReadToEnd();

            //string slotId = "";
            //string SlotStartTime = "";
            //string SlotEndTime = "";

            //slotId = dtClients.Tables[0].Rows[0]["SlotID"].ToString();
            //SlotStartTime = dtClients.Tables[1].Rows[0]["start"].ToString();
            //SlotEndTime = dtClients.Tables[1].Rows[0]["EndTime"].ToString();
            //if (slotId == "11")
            //    DeleteHrsReportBeforeTenDays();

            string HourlyReportHtml = "";
            DateTime now = DateTime.Now;
            string Day = now.ToString("dd");
            string Month = now.ToString("MMM");
            //ReportName = "HourlyReport_" + Day + Month + "_Slot" + slotId
            //ReportName = "Slot " + slotId + "  <b>" + SlotStartTime + "</b> to <b>" + SlotEndTime + "</b>";
            HourlyReportHtml = "SalesRevenue_" + Day + Month + ".html";
            writer = File.CreateText(Server.MapPath("~/Uploads/HrlyReports/" + HourlyReportHtml));
            writer.WriteLine(strHTML);
            writer.Close();
            //WriteFile = Server.MapPath("~/Uploads/Fits/" + HourlyReportHtml);
            WriteFile = Constants.MainUrlMail + "/uploads/fits/" + HourlyReportHtml;
            // Response.WriteFile();   
        }
        public Boolean SendClientRegistrationEmail_ForUpcommingExfactory(String ClientName, String UsernamePasswordList, String ToEmail, string MailType)
        {

            try
            {
                String fromName = BLLCache.GetConfigurationKeyValue("FROMEMAIL"); //Constants.KEY_FROM_EMAIL

                //Abhishek
                List<String> to = new List<String>();
                //SendMailUsingKeyValue("BIPL.SendClientRegistrationEmail", out to);





                NotificationController objcontroller = new NotificationController();
                DataSet ds = objcontroller.GetpRODUCTMAIL(MailType);
                DataTable dt = ds.Tables[0];
                //int StartHH = Convert.ToInt32(dt.Rows[0]["Hours"].ToString());
                //int MinMM = Convert.ToInt32(dt.Rows[0]["Min"].ToString());
                //string DaysName = dt.Rows[0]["Days"].ToString();
                //string[] values = DaysName.Split(',');
                string email = ds.Tables[0].Rows[0]["EmailName"].ToString();
                string[] email2 = email.Split(',');
                foreach (string em in email2)
                {
                    to.Add(em);
                }
                //for (int i = 0; i < values.Length; i++)
                //{
                //    values[i] = values[i].Trim();
                //}
                //DateTime Extacttime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, StartHH, MinMM, 0);


                List<Attachment> atts = new List<Attachment>();

                //ReportType = "HandOver-PreOrder";
                name = "Upcoming_exfactory" + ".xlsx";
                if (File.Exists("\\\\192.168.0.4\\UpComming_Exfactory\\Upcoming_exfactory.xlsx"))
                {

                    FitsPath = Path.Combine("\\\\192.168.0.4\\Upcomming_Exfactory\\", name);
                    atts.Add(new Attachment(FitsPath));
                }
                name = "ProductionPlanningReports" + ".xlsx";
                if (File.Exists("\\\\192.168.0.4\\UpComming_Exfactory\\ProductionPlanningReports.xlsx"))
                {

                    FitsPath = Path.Combine("\\\\192.168.0.4\\Upcomming_Exfactory\\", name);
                    atts.Add(new Attachment(FitsPath));
                }
                name = "PPlanning_WithStylecode_Reports" + ".xlsx";
                if (File.Exists("\\\\192.168.0.4\\UpComming_Exfactory\\PPlanning_WithStylecode_Reports.xlsx"))
                {

                    FitsPath = Path.Combine("\\\\192.168.0.4\\Upcomming_Exfactory\\", name);
                    atts.Add(new Attachment(FitsPath));
                }
                name = "Rescan" + ".xlsx";
                if (File.Exists("\\\\192.168.0.4\\UpComming_Exfactory\\Rescan.xlsx"))
                {

                    FitsPath = Path.Combine("\\\\192.168.0.4\\Upcomming_Exfactory\\", name);
                    atts.Add(new Attachment(FitsPath));
                }
                //name = "WIP" + ".xlsx";
                //if (File.Exists("\\\\192.168.0.4\\UpComming_Exfactory\\WIP.xlsx"))
                //{

                //    FitsPath = Path.Combine("\\\\192.168.0.4\\Upcomming_Exfactory\\", name);
                //    atts.Add(new Attachment(FitsPath));
                //}
                name = "WIP" + ".xlsx";
                if (File.Exists("\\\\192.168.0.4\\UpComming_Exfactory\\WIP.xlsx"))
                {

                    FitsPath = Path.Combine("\\\\192.168.0.4\\Upcomming_Exfactory\\", name);
                    atts.Add(new Attachment(FitsPath));
                }



                // this.SendEmail(fromName, to, null, null, template.Subject.ToUpper(), template.Content, atts, false, true);
                this.SendEmail(fromName, to, null, null, ToEmail, MailType, atts, false, false);

                //if (DateTime.Now == Extacttime)
                //{




                //    foreach (string WeekName in values)
                //    {

                //        string days = DateTime.Now.DayOfWeek.ToString();

                //        if (WeekName == days)
                //        {
                //            this.SendEmail(fromName, to, null, null, ToEmail, MailType, null, false, false);
                //        }
                //        //switch (WeekName)
                //        //{
                //        //    case "Monday":
                //        //        {
                //        //           // 
                //        //            break;
                //        //        }
                //        //    case "Tuesday":
                //        //        // this.SendEmail("uday@boutiQue.in", to, null, null, ToEmail, "test", null, false, false);
                //        //        break;
                //        //    case "Wednesday":
                //        //      //  this.SendEmail("uday@boutiQue.in", to, null, null, ToEmail, "test", null, false, false);
                //        //        break;
                //        //    case "Thursday":
                //        //      // return this.SendEmail("uday@boutiQue.in", to, null, null, ToEmail, "test", null, false, false);
                //        //        break;
                //        //    case "Friday":
                //        //     // this.SendEmail("uday@boutiQue.in", to, null, null, ToEmail, "test", null, false, false);
                //        //        break;
                //        //    case "Saturday":
                //        //       //   this.SendEmail("uday@boutiQue.in", to, null, null, ToEmail, "test", null, false, false);
                //        //        break;
                //        //    default:
                //        //        //Console.WriteLine("Invalid grade");
                //        //        break;
                //        //}
                //    }

                //}


                return true;

                //{


                //  




                //}
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));

                return false;
            }
        }
        public static string HttpContent(string url)
        {
            string result = "";
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(url);
            req.Timeout = 7000000;
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

        public void DeleteHrsReportBeforeTenDays()
        {
            string[] Files = Directory.GetFiles(Server.MapPath("~/Uploads/HrlyReports/"));
            foreach (string file in Files)
            {
                string str = System.IO.File.GetLastWriteTime(file).ToString("D");
                DateTime dt = Convert.ToDateTime(str);
                DateTime oneTwentyDaysAgo = DateTime.Today.AddDays(-10);
                if (dt < oneTwentyDaysAgo)
                    File.Delete(file);

            }
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
                if (MailType == "QApendingReports")
                {
                    List<Attachment> atts = new List<Attachment>();
                    name = "CuttingInCen" + ".pdf";
                    if (File.Exists(Constants.FITS_FOLDER_PATH + name))
                    {

                        FitsPath = Path.Combine(Constants.FITS_FOLDER_PATH, name);
                        atts.Add(new Attachment(FitsPath));
                    }
                    this.SendEmail(fromName, to, null, null, ToEmail, MailType, atts, false, false);
                }
                else
                {
                    this.SendEmail(fromName, to, null, null, ToEmail, MailType, null, false, false);
                }

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
            if (Request.QueryString["MailType"] == "PenaltyDailyMailReports")
                mailMessage.Subject = "Daily shipment and Planning Report";
            else if (Request.QueryString["MailType"] == "QApendingReports")
                mailMessage.Subject = "Production Performance";
            else if (Request.QueryString["MailType"] == "Sales")
                mailMessage.Subject = "Sales Revenue";

            else
                mailMessage.Subject = "Hourly Production Report";

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
                ShowAlert("Mail Sent Successfully");
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