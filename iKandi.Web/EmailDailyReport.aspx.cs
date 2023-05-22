using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Net.Mail;
using iKandi.Common;

namespace iKandi.Web
{
  public partial class EmailDailyReport : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
        //string url = "http://localhost:3220/EmailDailyReport.aspx";
        ////string url = "http://192.168.0.106:85/EmailDailyReport.aspx";
        //string EmailContent = HttpContent(url);
        //SendClientRegistrationEmail("uday", "kumar", EmailContent);




    }

    public static string HttpContent(string url)
    {

        string result = "";
        System.Net.WebRequest objRequest = System.Net.HttpWebRequest.Create(url.Trim());
        objRequest.Timeout = 200000;
        StreamReader sr = new StreamReader(objRequest.GetResponse().GetResponseStream());
        result = sr.ReadToEnd();
        sr.Close();
        return result;
       
       
    }


    public Boolean SendClientRegistrationEmail(String ClientName, String UsernamePasswordList, String ToEmail)
    {
        try
        {
          //  String fromName = BLLCache.GetConfigurationKeyValue("FROMEMAIL"); //Constants.KEY_FROM_EMAIL
            //Abhishek
            List<String> to = new List<String>();
          //  SendMailUsingKeyValue("BIPL.SendClientRegistrationEmail", out to);
            to.Add("uday@boutiQue.in");
            to.Add("Prabhaker@boutiQue.in");
            
            

            //END



            return this.SendEmail("uday@boutiQue.in", to, null, null, ToEmail, "test", null, false, false);
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
        mailMessage.Subject = Subject;
        mailMessage.IsBodyHtml = true;


        AlternateView htmlView = AlternateView.CreateAlternateViewFromString( Subject, null, "text/html");
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
            Response.Write("<script>alert('mail sent successfully');</script>");
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
  }
}