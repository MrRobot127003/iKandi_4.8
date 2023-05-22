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
using System.Text;


namespace iKandi.Web
{
    public partial class frmOutHouseReportsScheduler : System.Web.UI.Page
    {
        AdminController objadmin = new AdminController();
        string MailType = "Daily Outhouse Style and VA";
        string Flag = string.Empty;
        string FitsPath = string.Empty;
        string name = "";
       
        protected void Page_Load(object sender, EventArgs e)
        {

            string url = "http://localhost:3220/frmOutHouseReport.aspx";
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
                    //var html = new StreamReader(resp.GetResponseStream()).ReadToEnd();
                    result = new StreamReader(resp.GetResponseStream()).ReadToEnd();
                    
                }

               
                //System.Net.WebRequest objRequest = System.Net.HttpWebRequest.Create(url.Trim());
                //objRequest.Timeout = 200000;
                //StreamReader sr = new StreamReader(objRequest.GetResponse().GetResponseStream());
                //result = sr.ReadToEnd();
                //sr.Close();
                
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

                  if (MailType != string.Empty)
                  {
                      if (MailType == "Daily Outhouse Style and VA")
                      {
                          List<Attachment> atts = new List<Attachment>();

                          //ReportType = "HandOver-PreOrder";
                          name = "Daily Outhouse Style and VA" + ".xlsx";
                          if (File.Exists(Constants.FITS_FOLDER_PATH + name))
                          {

                              FitsPath = Path.Combine(Constants.FITS_FOLDER_PATH, name);
                              atts.Add(new Attachment(FitsPath));
                          }
                          name = "Vendor Factor summary report formulae" + ".pdf";
                          if (File.Exists(Constants.FITS_FOLDER_PATH + name))
                          {

                              FitsPath = Path.Combine(Constants.FITS_FOLDER_PATH, name);
                              atts.Add(new Attachment(FitsPath));
                          }
                          name = "VAMinRateVendor_Report" + ".pdf";
                          if (File.Exists(Constants.FITS_FOLDER_PATH + name))
                          {

                              FitsPath = Path.Combine(Constants.FITS_FOLDER_PATH, name);
                              atts.Add(new Attachment(FitsPath));
                          }
                          //name = "Reallocation_OutHouse" + ".xlsx";
                          //if (File.Exists(Constants.FITS_FOLDER_PATH + name))
                          //{

                          //    FitsPath = Path.Combine(Constants.FITS_FOLDER_PATH, name);
                          //    atts.Add(new Attachment(FitsPath));
                          //}
                          //name = "BIPL_outhouse_Excel_Report" + ".pdf";
                          //if (File.Exists(Constants.FITS_FOLDER_PATH + name))
                          //{

                          //    FitsPath = Path.Combine(Constants.FITS_FOLDER_PATH, name);
                          //    atts.Add(new Attachment(FitsPath));
                          //}



                          this.SendEmail(fromName, to, null, null, ToEmail, MailType, atts, false, false);
                      }
                  }
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
       
       
    }
}