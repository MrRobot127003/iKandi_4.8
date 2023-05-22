using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iKandi.Common;
using System.Net.Mail;
using System.Threading;
using System.Runtime.InteropServices;
using System.Reflection;
using System.IO;
using  System.Data;


namespace iKandi.BLL
{
    public class NotificationController : BaseController
    {
        #region Constants

        private const String CLIENT_NAME = "[[CLIENTNAME]]";
        private const String CONTENT = "[[CONTENT]]";
        // private const String EMAIL_FOOTER_LINE = BLLCache.GetConfigurationKeyValue(Constants.EMAIL_FOOTER_LINE1) + "</br>" + BLLCache.GetConfigurationKeyValue(Constants.EMAIL_FOOTER_LINE2) + "</br>" + BLLCache.GetConfigurationKeyValue(Constants.EMAIL_FOOTER_LINE1);
        private const String CONTENTSTYLE = @"<style style='text/css'> *{ font-size : 11pt !important; font-family : ""Trebuchet MS"" !important;} 
                                                TABLE {border-collapse: collapse; } 
                                                TABLE TD {border-collapse: collapse; border:1px solid black; padding: 5px !important; background-color: White; text-align: center; font-size : 11pt;} 
                                                table TH {border-collapse: collapse; border:1px solid black; color: Black; background-color: #F9DDF4; text-transform: uppercase; text-align: center; padding: 10px; font-weight: normal; font-size : 11pt; } 
                                                .signature { font-size : 10pt;}
                                                .footer_line1{font-size : 8pt !important; font-family : ""Trebuchet MS""; color: #0000FF; }
                                                .footer_line2{font-size : 8pt !important; font-family : ""Trebuchet MS""; color: #FF00FF;  }
                                                .footer_line3{font-size : 8pt !important; font-family : ""Trebuchet MS""; color: black; }
                                                .blue_font { color: #0000FF; !important }
                                            </style>";

        #endregion

        #region Fields

        // iKandi.BLL.Configuration.Configuration conf = new iKandi.BLL.Configuration.Configuration();

        #endregion

        #region Ctor(s)

        public NotificationController()
        {
        }

        public NotificationController(SessionInfo LoggedInUser)
            : base(LoggedInUser)
        {
        }

        #endregion
        //Added By Abhishek on 28/5/2015
        public static void SendMailUsingKeyValue(string KeyName, out List<string> to)
        {
            to = null;
            string ConfigKeyName = string.Empty;
            ConfigKeyName = KeyName;
            List<string> list = new List<string>();
            if (ConfigKeyName != string.Empty)
            {
                //string[] Recipent;//= Recipient_ikandi.Split(',');
                //string  Recipent = 
                var CheckKey = System.Configuration.ConfigurationManager.AppSettings[ConfigKeyName];

                if (!string.IsNullOrEmpty(CheckKey))
                {
                    string strListRecipent = System.Configuration.ConfigurationManager.AppSettings[ConfigKeyName];
                    string[] Recipent = strListRecipent.Split(',');
                    foreach (string str in Recipent)
                    {
                        list.Add(str);
                    }
                    to = list;

                }

            }


        }
        //END
        #region Public Methods

        #region Send Email

        public Boolean SendEmail(String FromEmail, List<String> To, List<String> CC, List<String> BCC, String Subject, String Content, List<Attachment> Attachments, Boolean hasAppendAttachment, Boolean isAsync)
        {
            //System.Diagnostics.Debugger.Break();

            string footerContent = BLLCache.GetConfigurationKeyValue(Constants.EMAIL_FOOTER_LINE1) + BLLCache.GetConfigurationKeyValue(Constants.EMAIL_FOOTER_LINE2) + BLLCache.GetConfigurationKeyValue(Constants.EMAIL_FOOTER_LINE3);
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(FromEmail);
            mailMessage.ReplyTo = new MailAddress(FromEmail);
            mailMessage.Priority = MailPriority.Normal;
            mailMessage.Subject = Subject;
            mailMessage.IsBodyHtml = true;


            AlternateView htmlView = AlternateView.CreateAlternateViewFromString(CONTENTSTYLE + Content + footerContent, null, "text/html");
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
                mailMessage.Body = CONTENTSTYLE + Content + footerContent;
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

                if (Subject.IndexOf("iKandi Error") > -1 && this.LoggedInUser != null && this.LoggedInUser.UserData != null)
                    mailMessage.Bcc.Add(this.LoggedInUser.UserData.Email);
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












        public Boolean SendDevelopermail(String FromEmail, List<String> To, List<String> CC, List<String> BCC, String Subject, String Content, List<Attachment> Attachments, Boolean hasAppendAttachment, Boolean isAsync)
        {
            //System.Diagnostics.Debugger.Break();

            string footerContent = BLLCache.GetConfigurationKeyValue(Constants.EMAIL_FOOTER_LINE1) + BLLCache.GetConfigurationKeyValue(Constants.EMAIL_FOOTER_LINE2) + BLLCache.GetConfigurationKeyValue(Constants.EMAIL_FOOTER_LINE3);
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(FromEmail);
            mailMessage.ReplyTo = new MailAddress(FromEmail);
            mailMessage.Priority = MailPriority.Normal;
            mailMessage.Subject = Subject;
            mailMessage.IsBodyHtml = true;


            AlternateView htmlView = AlternateView.CreateAlternateViewFromString(CONTENTSTYLE + Content + footerContent, null, "text/html");
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
                mailMessage.Body = CONTENTSTYLE + Content + footerContent;
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

                if (Subject.IndexOf("iKandi Error") > -1 && this.LoggedInUser != null && this.LoggedInUser.UserData != null)
                    mailMessage.Bcc.Add("itsupport@boutique.in");
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
        #endregion

        //Gajendra Email Notification
        public void NotificationEmailHistory_Ins(NotificationEmailHistory NEH)
        {

            this.NotificationDataProviderInstance.NotificationEmailHistory_Ins(NEH);
        }

        public Boolean SendForgotPasswordEmail(String FullName, String Password, String Email)
        {
            try
            {
                String fromName = BLLCache.GetConfigurationKeyValue("FROMEMAIL"); //Constants.KEY_FROM_EMAIL

                List<String> to = new List<String>();
                to.Add(Email);

                EmailTemplate template = this.AdminDataProviderInstance.GetEmailTemplateByType(EmailTemplateType.FORTOPASSWORD);

                template.Content = template.Content.Replace("[[FULLNAME]]", FullName);
                template.Content = template.Content.Replace("[[USERNAME]]", Email);
                template.Content = template.Content.Replace("[[PASSWORD]]", Password);

                System.Diagnostics.Trace.WriteLine("Processing of Forget Password Email having Subject ----" + template.Subject + "has been started on " + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt") + "\n");

                return this.SendEmail(fromName, to, null, null, template.Subject, template.Content, null, false, false);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in  Forget Password Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                System.Diagnostics.Trace.WriteLine("\n");
               // this.SendErrorEmail(ex.Message + "\n" + ex.StackTrace);
                return false;
            }
        }

        public Boolean SendUserRegistrationEmail(String FullName, String Password, String Email)
        {
            try
            {
                String fromName = BLLCache.GetConfigurationKeyValue("FROMEMAIL"); //Constants.KEY_FROM_EMAIL

                List<String> to = new List<String>();
                to.Add(Email);

                List<String> bcc = new List<String>();
                bcc.Add(fromName);

                EmailTemplate template = this.AdminDataProviderInstance.GetEmailTemplateByType(EmailTemplateType.USERREGISTRATION);

                template.Content = template.Content.Replace("[[FULLNAME]]", FullName);
                template.Content = template.Content.Replace("[[USERNAME]]", Email);
                template.Content = template.Content.Replace("[[PASSWORD]]", Password);

                System.Diagnostics.Trace.WriteLine("Processing of User Registration Email having Subject ----" + template.Subject + " has been started on " + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                return this.SendEmail(fromName, to, null, bcc, template.Subject, template.Content, null, false, false);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in  User Registration on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
               // this.SendErrorEmail(ex.Message + "\n" + ex.StackTrace);
                return false;
            }

        }

        public Boolean SendClientRegistrationEmail(String ClientName, String UsernamePasswordList, String ToEmail)
        {
            try
            {
                String fromName = BLLCache.GetConfigurationKeyValue("FROMEMAIL"); //Constants.KEY_FROM_EMAIL
                //Abhishek
                List<String> to = new List<String>();
                SendMailUsingKeyValue("BIPL.SendClientRegistrationEmail", out to);
                //to.Add("bipl_sales@boutique.in");
                //to.Add("bipl_sales@boutique.in");
                //to.Add("bipl_logistics@boutique.in");
                //to.Add("hitesh@boutique.in");
                //to.Add("sanjeev@boutique.in");

                //END
                EmailTemplate template = this.AdminDataProviderInstance.GetEmailTemplateByType(EmailTemplateType.CLIENTREGISTRATION);

                template.Subject = template.Description.Replace("[[CLIENTNAME]]", ClientName.ToUpper());
                template.Content = template.Content.Replace("[[CLIENTNAME]]", ClientName.ToUpper());
                template.Content = template.Content.Replace("[[CONTENT]]", UsernamePasswordList.Replace("\n", "<br />"));

                System.Diagnostics.Trace.WriteLine("Processing of Client Registration Email having Subject ----" + template.Subject + "has been started on " + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));


                return this.SendEmail(fromName, to, null, null, template.Subject.ToUpper(), template.Content, null, false, false);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
               // this.SendErrorEmail(ex.Message + "\n" + ex.StackTrace);
                return false;
            }
        }

        public Boolean SendShipmentPreAlertEmail(Int32 ShipmentID, List<String> additionalEmails, String Remarks)
        {
            try
            {
                EmailTemplate template = this.AdminDataProviderInstance.GetEmailTemplateByType(EmailTemplateType.PREALERTSHIPMENT);

                List<String> departmentList = new List<String>();
                List<String> designationList = new List<string>();

                departmentList.AddRange(template.DepartmentIDs.Split(new char[] { ',' }));
                designationList.AddRange(template.DesignationIDs.Split(new char[] { ',' }));

                //System.Diagnostics.Debugger.Break();            
                String fromName = BLLCache.GetConfigurationKeyValue("FROMEMAIL"); //Constants.KEY_FROM_EMAIL

                // Get the Shipment / Packing / etc
                ShipmentPlanning sp = this.DeliveryDataProviderInstance.GetShipmentPlanning(ShipmentID);

                List<Attachment> attachments = new List<Attachment>();

                DeliveryAddAttachments(sp.ShipmentInstructionsFile, attachments, Constants.DELIVERY_FOLDER_PATH);

                int invoiceCounter = 1;

                foreach (ShipmentPlanningOrder order in sp.ShipmentPlanningOrders)
                {
                    string url = "/Internal/Delivery/BIPLInvoice.aspx?type=2&packingId=" +
                        order.PackingList.PackingID.ToString() + "&invoiceid=" + order.PackingList.InvoiceID.ToString();

                    string fileName = "Invoice-" + invoiceCounter.ToString();

                    PDFController pdfController = new PDFController(this.LoggedInUser);
                    string pdfFilePath = pdfController.GeneratePDFForPrint(url, fileName, this.LoggedInUser.UserData.Username,
                        this.LoggedInUser.UserData.Password, 1200, -1);

                    if (!string.IsNullOrEmpty(pdfFilePath))
                        attachments.Add(new Attachment(pdfFilePath));

                    DeliveryController controller = new DeliveryController(this.LoggedInUser);
                    fileName = controller.GeneratePackingListExcel(-1, order.PackingList.PackingID, "PackingList_" + invoiceCounter.ToString());

                    if (!string.IsNullOrEmpty(fileName))
                    {
                        pdfFilePath = Path.Combine(Constants.TEMP_FOLDER_PATH, fileName);
                    }

                    if (!string.IsNullOrEmpty(pdfFilePath))
                        attachments.Add(new Attachment(pdfFilePath));

                    DeliveryAddAttachments(order.UploadCustomList, attachments, Constants.DELIVERY_FOLDER_PATH);

                    if (!string.IsNullOrEmpty(order.UploadBuyerList))
                        DeliveryAddAttachments(order.UploadBuyerList, attachments, Constants.DELIVERY_FOLDER_PATH);

                    if (!string.IsNullOrEmpty(order.UploadDocument))
                        DeliveryAddAttachments(order.UploadDocument, attachments, Constants.DELIVERY_FOLDER_PATH);

                    invoiceCounter++;
                }

                List<String> to = new List<String>();

                //get User Data
                List<User> userList = GetUserInfo(new List<String>(), designationList, departmentList, 0);

                foreach (User user in userList)
                {
                    if (to.Contains(user.Email))
                    {
                        continue;
                    }
                    else
                    {
                        // to.Add(user.Email);
                    }
                }
                // edit by surendra/hitesh
                //Abhishek
                SendMailUsingKeyValue("BIPL.SendShipmentPreAlertEmail", out to);
                //to.Add("bipl_merchandising@boutique.in");
                //to.Add("bipl_committee@boutique.in");
                //to.Add("bipl_qateam@boutique.in");
                //to.Add("bipl_logistics@boutique.in");
                //to.Add("bipl_production@boutique.in");
                ////to.Add("sanjeev@boutique.in");
                //to.Add("hitesh@boutique.in");

                //END


                // Utkarsh commented on 04/06/2010, Add Hanging partner also here if not blank
                /*
                // Get Partner Emails
                List<PartnerEmail> partnerEmails = this.PartnerDataProviderInstance.GetPartnerEmail(sp.IndiaPartner.PartnerID);

                foreach (PartnerEmail pEmail in partnerEmails)
                {
                    if (to.Contains(pEmail.Email))
                    {
                        continue;
                    }
                    else
                    {
                        to.Add(pEmail.Email);
                    }
                }
                */

                List<String> cc = new List<String>();
                cc.AddRange(additionalEmails);

                string invoiceNumbers = string.Empty;

                foreach (ShipmentPlanningOrder objShipmentPlanningOrder in sp.ShipmentPlanningOrders)
                {
                    if (invoiceNumbers == string.Empty)
                        invoiceNumbers = objShipmentPlanningOrder.PackingList.InvoiceNumber;
                    else
                        invoiceNumbers = invoiceNumbers + ", " + objShipmentPlanningOrder.PackingList.InvoiceNumber;
                }

                template.Subject = template.Subject.Replace("[[PACKAGES]]", sp.TotalPackages.ToString());

                template.Content = template.Content.Replace("[[PARTNER]]", sp.IndiaPartner.PartnerName.ToUpper());
                template.Content = template.Content.Replace("[[INVOICE NUMBER]]", invoiceNumbers.ToUpper());
                template.Content = template.Content.Replace("[[REMARKS]]", Remarks.ToUpper());
                template.Content = template.Content.Replace("[[MANAGER]]", this.LoggedInUser.UserData.FullName.ToUpper());

                System.Diagnostics.Trace.WriteLine("Processing of Shipment Pre Alert Email having Subject ----" + template.Subject + "has been started on " + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                return this.SendEmail(fromName, to, cc, null, template.Subject.ToUpper(), template.Content, attachments, false, false);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in  Shipment Pre Alert Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
               // this.SendErrorEmail(ex.Message + "\n" + ex.StackTrace);
                return false;
            }

        }

        public Boolean SendShipmentAdviseEmail(Int32 ShipmentID, List<String> additionalEmails, String Remarks, string shipmentAdvise)
        {
            try
            {
                EmailTemplate template = this.AdminDataProviderInstance.GetEmailTemplateByType(EmailTemplateType.POSTALERTSHIPMENT);

                List<String> departmentList = new List<String>();
                List<String> designationList = new List<string>();

                departmentList.AddRange(template.DepartmentIDs.Split(new char[] { ',' }));
                designationList.AddRange(template.DesignationIDs.Split(new char[] { ',' }));

                String fromName = BLLCache.GetConfigurationKeyValue("FROMEMAIL"); //Constants.KEY_FROM_EMAIL

                // Get the Shipment / Packing / etc
                ShipmentPlanning sp = this.DeliveryDataProviderInstance.GetShipmentPlanning(ShipmentID);

                List<Attachment> attachments = new List<Attachment>();

                DeliveryAddAttachments(sp.UploadDocument, attachments, Constants.DELIVERY_FOLDER_PATH);

                int invoiceCounter = 1;
                PDFController pdfController = new PDFController(this.LoggedInUser);

                foreach (ShipmentPlanningOrder order in sp.ShipmentPlanningOrders)
                {
                    string url = "/Internal/Delivery/BIPLInvoice.aspx?type=2&packingId=" +
                        order.PackingList.PackingID.ToString() + "&invoiceid=" + order.PackingList.InvoiceID.ToString();

                    string fileName = "Invoice-" + invoiceCounter.ToString();

                    string pdfFilePath = pdfController.GeneratePDFForPrint(url, fileName, this.LoggedInUser.UserData.Username,
                        this.LoggedInUser.UserData.Password, 1200, -1);

                    if (!String.IsNullOrEmpty(pdfFilePath))
                        attachments.Add(new Attachment(pdfFilePath));

                    //url = "/Internal/Packing/PackingList.aspx?pid=" + order.PackingList.PackingID.ToString();
                    DeliveryController controller = new DeliveryController(this.LoggedInUser);
                    fileName = controller.GeneratePackingListExcel(-1, order.PackingList.PackingID, "PackingList_" + invoiceCounter.ToString());

                    if (!string.IsNullOrEmpty(fileName))
                    {
                        pdfFilePath = Path.Combine(Constants.TEMP_FOLDER_PATH, fileName);
                    }


                    if (!String.IsNullOrEmpty(pdfFilePath))
                        attachments.Add(new Attachment(pdfFilePath));

                    invoiceCounter++;
                }

                List<String> to = new List<String>();

                //get User Data
                List<User> userList = GetUserInfo(new List<String>(), designationList, departmentList, 0);

                foreach (User user in userList)
                {
                    if (to.Contains(user.Email))
                    {
                        continue;
                    }
                    else
                    {
                        to.Add(user.Email);
                    }
                }

                // Get Partner Emails
                List<PartnerEmail> partnerEmails = this.PartnerDataProviderInstance.GetPartnerEmail(sp.Partner.PartnerID);

                // Utkarsh commented on 04/06/2010
                /*
                 
                foreach (PartnerEmail pEmail in partnerEmails)
                {
                    if (to.Contains(pEmail.Email))
                    {
                        continue;
                    }
                    else
                    {
                        to.Add(pEmail.Email);
                    }
                }
                
                */

                List<String> cc = new List<String>();
                cc.AddRange(additionalEmails);



                string buyerList = string.Empty;
                int r = 0;

                foreach (ShipmentPlanningOrder spo in sp.ShipmentPlanningOrders)
                {
                    DataTable od = this.DeliveryDataProviderInstance.GetPackingOrders(spo.PackingList.PackingID);

                    if (buyerList == string.Empty)
                        buyerList = od.Rows[r]["Buyer"].ToString();
                    else
                        buyerList = "/" + od.Rows[r]["Buyer"].ToString();
                    r++;
                }

                template.Subject = template.Subject.Replace("[[CLIENT]]", "(" + buyerList + ")");

                if (sp.ShipmentPlanningOrders.Count > 0)
                {
                    if (sp.ShipmentPlanningOrders[0].ModeName.ToLower().Contains("a"))
                        template.Subject = template.Subject.Replace("[[MODE]]", "AIR");
                    else
                        template.Subject = template.Subject.Replace("[[MODE]]", "SEA");
                }

                template.Subject = template.Subject.Replace("[[PACKAGES]]", sp.TotalPackages.ToString());

                template.Content = template.Content.Replace("[[PARTNER]]", sp.Partner.PartnerName.ToUpper());
                template.Content = template.Content.Replace("[[REMARKS]]", Remarks.ToUpper());
                template.Content = template.Content.Replace("[[SHIPMENT ADVISE]]", shipmentAdvise.ToUpper());
                template.Content = template.Content.Replace("[[MANAGER]]", this.LoggedInUser.UserData.FullName.ToUpper());

                System.Diagnostics.Trace.WriteLine("Processing of Shipment Advice Email having Subject ----" + template.Subject + "has been started on " + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                return this.SendEmail(fromName, to, cc, null, template.Subject.ToUpper(), template.Content, attachments, false, false);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in  Shipment Advice Email having on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                //this.SendErrorEmail(ex.Message + "\n" + ex.StackTrace);
                return false;
            }
        }

        public Boolean SendBookingEmail(Int32 BookingID, List<String> additionalEmails, String Remarks)
        {
            try
            {

                EmailTemplate template = this.AdminDataProviderInstance.GetEmailTemplateByType(EmailTemplateType.BOOKINGEMAILTOPARTNER);

                List<String> departmentList = new List<String>();
                List<String> designationList = new List<string>();

                departmentList.AddRange(template.DepartmentIDs.Split(new char[] { ',' }));
                designationList.AddRange(template.DesignationIDs.Split(new char[] { ',' }));

                String fromName = BLLCache.GetConfigurationKeyValue("FROMEMAIL"); //Constants.KEY_FROM_EMAIL

                DeliveryBooking db = this.DeliveryDataProviderInstance.GetBookingOrder(BookingID);

                List<Attachment> attachments = new List<Attachment>();

                DeliveryAddAttachments(db.BookingDocuments, attachments, Constants.DELIVERY_FOLDER_PATH);

                List<String> to = new List<String>();

                //get User Data
                List<User> userList = GetUserInfo(new List<String>(), designationList, departmentList, 0);

                foreach (User user in userList)
                {
                    if (to.Contains(user.Email))
                    {
                        continue;
                    }
                    else
                    {
                        to.Add(user.Email);
                    }
                }

                // Get Partner Emails
                List<PartnerEmail> partnerEmails = this.PartnerDataProviderInstance.GetPartnerEmail(db.ShipmentPlanningOrder.ShipmentPlanning.Partner.PartnerID);

                // Utkarsh commented on 04/06/2010
                /*
                 
                foreach (PartnerEmail pEmail in partnerEmails)
                {
                    if (to.Contains(pEmail.Email))
                    {
                        continue;
                    }
                    else
                    {
                        to.Add(pEmail.Email);
                    }
                }
                */

                List<String> cc = new List<String>();
                cc.AddRange(additionalEmails);



                template.Subject = template.Subject.Replace("[[PACKAGES]]", db.ShipmentPlanningOrder.PackingList.TotalPackages.ToString());
                template.Subject = template.Subject.Replace("[[CLIENT]]", "(" + db.ShipmentPlanningOrder.Buyer + ")");

                if (db.ModeName.ToLower().Contains("a"))
                    template.Subject = template.Subject.Replace("[[MODE]]", "AIR");
                else
                    template.Subject = template.Subject.Replace("[[MODE]]", "SEA");

                template.Content = template.Content.Replace("[[PARTNER]]", db.ShipmentPlanningOrder.ShipmentPlanning.Partner.PartnerName.ToUpper());
                template.Content = template.Content.Replace("[[AWB NUMBER]]", db.ShipmentPlanningOrder.ShipmentPlanning.BLAWBNumber.ToUpper());
                template.Content = template.Content.Replace("[[AWB DATE]]", db.ShipmentPlanningOrder.ShipmentPlanning.ExpectedDispatchDate.ToString("dd MMM yy (ddd)"));
                template.Content = template.Content.Replace("[[SHIPMENT ADVISE]]", "");
                template.Content = template.Content.Replace("[[REMARKS]]", Remarks.ToUpper());
                template.Content = template.Content.Replace("[[MANAGER]]", this.LoggedInUser.UserData.FullName.ToUpper());

                System.Diagnostics.Trace.WriteLine("Processing of Booking Email  having Subject ----" + template.Subject + "has been started on " + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                return this.SendEmail(fromName, to, cc, null, template.Subject.ToUpper(), template.Content, attachments, false, false);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in  Booking Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
               // this.SendErrorEmail(ex.Message + "\n" + ex.StackTrace);
                return false;
            }
        }



        // Tested
        //public void SendCourierDispatchList(DateTime CourrierDate)
        //{
        //    try
        //    {
        //        EmailTemplate template = this.AdminDataProviderInstance.GetEmailTemplateByType(EmailTemplateType.COURIERDISPATCHLIST);

        //        List<String> departmentList = new List<String>();
        //        List<String> designationList = new List<string>();

        //        departmentList.AddRange(template.DepartmentIDs.Split(new char[] { ',' }));
        //        designationList.AddRange(template.DesignationIDs.Split(new char[] { ',' }));

        //        //objDepartmentIdList.Add(Convert.ToInt32(Group.BIPL_Sales).ToString());
        //        //objDepartmentIdList.Add(Convert.ToInt32(Group.ikandi_Sales).ToString());
        //        //objDepartmentIdList.Add(Convert.ToInt32(Group.iKandi_Technical).ToString());
        //        //objDepartmentIdList.Add(Convert.ToInt32(Group.iKandi_Design).ToString());
        //        //objDepartmentIdList.Add(Convert.ToInt32(Group.BIPL_Merchandising).ToString());

        //        //designationList.Add(((int)Designation.BIPL_Sales_Assistant).ToString());

        //        //get User Data
        //        List<User> userList = GetUserInfo(new List<String>(), designationList, departmentList, 0);

        //        String fromName = BLLCache.GetConfigurationKeyValue("FROMEMAIL");

        //        List<String> to = new List<String>();

        //        string pdfFilePath = "";
        //        //foreach (User user in userList)
        //        //{
        //        //    if (to.Contains(user.Email))
        //        //    {
        //        //        continue;
        //        //    }
        //        //    else
        //        //    {
        //        //        //to.Add(user.Email);
        //        //    }
        //        //}
        //        // edit by surendra/hitesh
        //        //to.Add("ikandi_design@ikandi.org.uk");
        //        //to.Add("bipl_merchandising@boutique.in");
        //        //to.Add("ikandi_technical@ikandi.org.uk");
        //        //to.Add("sukh@ikandi.org.uk");
        //        //to.Add("rajina@boutique.in");
        //        //to.Add("arbind@boutique.in");
        //        //to.Add("bipl_qateam@boutique.in");
        //        //to.Add("sanjeev@boutique.in");
        //        //to.Add("Abhishek@boutique.in");


        //        template.Subject = template.Subject.Replace("[[DATE]]", CourrierDate.ToString("dd MMM yy (ddd)"));

        //        CourierController controller = new CourierController();

        //        if (!Directory.Exists(Constants.TEMP_FOLDER_PATH))
        //            Directory.CreateDirectory(Constants.TEMP_FOLDER_PATH);



        //        bool success = false;//= controller.GenerateDailyCourierReport(pdfFilePath, CourrierDate);

        //        bool bCheck = controller.GetAttchemrntEmilBuyingHouseBAL(pdfFilePath, CourrierDate, 1);
        //        bool bCheckIsBIPL = controller.GetAttchemrntEmilBuyingHouseBAL(pdfFilePath, CourrierDate, 2);

        //        if (bCheck == true)
        //        {
        //            SendMailUsingKeyValue("Ikandi.SendCourierDispatchList", out to);

        //            string pdfFilePathIkandi = Path.Combine(Constants.TEMP_FOLDER_PATH, "Courier List -IKANDI" + CourrierDate.ToString("dd MMM yyy") + ".pdf");
        //            success = controller.GenerateDailyCourierReport(pdfFilePathIkandi, CourrierDate);//, 2);



        //            List<Attachment> atts = new List<Attachment>();
        //            atts.Add(new Attachment(pdfFilePath));
        //            System.Diagnostics.Trace.WriteLine("Processing of Courier Dispatch List Email having Subject ----" + template.Subject + "has been started on " + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
        //            if (!success)
        //            {
        //                System.Diagnostics.Trace.WriteLine("There is no record in the pdf for Courier Dispatch List Email. So Email has not been send on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt") + "\n");
        //                return;
        //            }


        //            this.SendEmail(fromName, to, null, null, template.Subject.ToUpper(), template.Content, atts, false, true);
        //            to.Clear();
        //        }
        //        if (bCheckIsBIPL == true)
        //        {
        //            SendMailUsingKeyValue("BIPL.SendCourierDispatchList", out to);
        //            string pdfFilePathBH = Path.Combine(Constants.TEMP_FOLDER_PATH, "Courier List -BIPL" + CourrierDate.ToString("dd MMM yyy") + ".pdf");
        //            success = controller.GenerateDailyCourierReport(pdfFilePathBH, CourrierDate);//, 1);


        //            List<Attachment> atts = new List<Attachment>();
        //            atts.Add(new Attachment(pdfFilePath));
        //            System.Diagnostics.Trace.WriteLine("Processing of Courier Dispatch List Email having Subject ----" + template.Subject + "has been started on " + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
        //            if (!success)
        //            {
        //                System.Diagnostics.Trace.WriteLine("There is no record in the pdf for Courier Dispatch List Email. So Email has not been send on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt") + "\n");
        //                return;
        //            }


        //            this.SendEmail(fromName, to, null, null, template.Subject.ToUpper(), template.Content, atts, false, true);
        //            to.Clear();
        //        }
        //        // System.Diagnostics.Trace.WriteLine("Pdf for Courier Dispatch List Email has been generated successfully  on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

        //        //if (!success)
        //        //{
        //        //    System.Diagnostics.Trace.WriteLine("There is no record in the pdf for Courier Dispatch List Email. So Email has not been send on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt") + "\n");
        //        //    return;
        //        //}


        //        //this.SendEmail(fromName, to, null, null, template.Subject.ToUpper(), template.Content, atts, false, true);

        //    }
        //    catch (Exception ex)
        //    {
        //        System.Diagnostics.Trace.WriteLine("Error occur in  Courier Dispatch List Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
        //        System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
        //        //this.SendErrorEmail(ex.Message + "\n" + ex.StackTrace);
        //    }
        //}
        //Added By Abhishek on 23/2/2016
        public static void SendMailUsingKeyValueByTargetAdmin(string KeyName, out List<string> to)
        {
            to = null;
            
            List<string> list = new List<string>();


            var CheckKey = KeyName;

                if (!string.IsNullOrEmpty(CheckKey))
                {
                    string strListRecipent = KeyName;
                    string[] Recipent = strListRecipent.Split(',');
                    foreach (string str in Recipent)
                    {
                        list.Add(str);
                    }
                    to = list;

                }

           


        }
       //Edited by abhishek on 23/2/2016
        public void SendCourierDispatchList(DateTime CourrierDate)
        {
            try
            {
                EmailTemplate template = this.AdminDataProviderInstance.GetEmailTemplateByType(EmailTemplateType.COURIERDISPATCHLIST);
                List<String> departmentList = new List<String>();
                List<String> designationList = new List<string>();
                departmentList.AddRange(template.DepartmentIDs.Split(new char[] { ',' }));
                designationList.AddRange(template.DesignationIDs.Split(new char[] { ',' }));

                //objDepartmentIdList.Add(Convert.ToInt32(Group.BIPL_Sales).ToString());
                //objDepartmentIdList.Add(Convert.ToInt32(Group.ikandi_Sales).ToString());
                //objDepartmentIdList.Add(Convert.ToInt32(Group.iKandi_Technical).ToString());
                //objDepartmentIdList.Add(Convert.ToInt32(Group.iKandi_Design).ToString());
                //objDepartmentIdList.Add(Convert.ToInt32(Group.BIPL_Merchandising).ToString());

                //designationList.Add(((int)Designation.BIPL_Sales_Assistant).ToString());

                //get User Data
                List<User> userList = GetUserInfo(new List<String>(), designationList, departmentList, 0);

                String fromName = BLLCache.GetConfigurationKeyValue("FROMEMAIL");

                List<String> to = new List<String>();

                string pdfFilePath = "";
                //foreach (User user in userList)
                //{
                //    if (to.Contains(user.Email))
                //    {
                //        continue;
                //    }
                //    else
                //    {
                //        //to.Add(user.Email);
                //    }
                //}
                // edit by surendra/hitesh
                //to.Add("ikandi_design@ikandi.org.uk");
                //to.Add("bipl_merchandising@boutique.in");
                //to.Add("ikandi_technical@ikandi.org.uk");
                //to.Add("sukh@ikandi.org.uk");
                //to.Add("rajina@boutique.in");
                //to.Add("arbind@boutique.in");
                //to.Add("bipl_qateam@boutique.in");
                //to.Add("sanjeev@boutique.in");
                //to.Add("Abhishek@boutique.in");


                //template.Subject = template.Subject.Replace("[[DATE]]", CourrierDate.ToString("dd MMM yy (ddd)"));

                CourierController controller = new CourierController();

                if (!Directory.Exists(Constants.TEMP_FOLDER_PATH))
                    Directory.CreateDirectory(Constants.TEMP_FOLDER_PATH);



                bool success = false;//= controller.GenerateDailyCourierReport(pdfFilePath, CourrierDate);

                bool bCheck = controller.GetAttchemrntEmilBuyingHouseBAL(pdfFilePath, CourrierDate, 1);
                bool bCheckIsBIPL = controller.GetAttchemrntEmilBuyingHouseBAL(pdfFilePath, CourrierDate, 2);

                if (bCheck == true)
                { 

                    //SendMailUsingKeyValue("Ikandi.SendCourierDispatchList", out to);
                    //DataSet ds = new DataSet();
                    //ds=this.GetDispatchEntryMailWeekName(1);
                    //DataTable dt = new DataTable();
                    //string StrListEmailsID = string.Empty;
                    //dt = ds.Tables[1];
                    //StrListEmailsID = dt.Rows[0]["Emails"].ToString();
                    //SendMailUsingKeyValueByTargetAdmin(StrListEmailsID,out to);
                  
                    
                    //added by raghvinder on 25-08-2020 start
                    DataTable courierDate_dt = new DataTable();
                    courierDate_dt = NotificationDataProviderInstance.GetCourierDispatchListDate(CourrierDate);
                    DateTime CourierDate = Convert.ToDateTime(courierDate_dt.Rows[0]["CourierDate"].ToString());
                    //string pdfFilePathIkandi = Path.Combine(Constants.TEMP_FOLDER_PATH, "Courier List -IKANDI" + CourrierDate.ToString("dd MMM yyy") + ".pdf");
                    string pdfFilePathIkandi = Path.Combine(Constants.TEMP_FOLDER_PATH, "Courier List-IKANDI " + CourierDate.ToString("dd MMM yyy") + ".pdf");
                    template.Subject = template.Subject.Replace("[[DATE]]", CourierDate.ToString("dd MMM yy (ddd)"));
                    //added by raghvinder on 25-08-2020 end
                    success = controller.GenerateDailyCourierReport(pdfFilePathIkandi, CourrierDate, 1);



                    List<Attachment> atts = new List<Attachment>();
                    //atts.Add(new Attachment(pdfFilePath));
                    atts.Add(new Attachment(pdfFilePathIkandi));
                    System.Diagnostics.Trace.WriteLine("Processing of Courier Dispatch List Email having Subject ----" + template.Subject + "has been started on " + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    if (!success)
                    {
                        System.Diagnostics.Trace.WriteLine("There is no record in the pdf for Courier Dispatch List Email. So Email has not been send on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt") + "\n");
                        return;
                    }



                    //this.SendEmail(fromName, to, null, null, template.Subject.ToUpper(), template.Content, atts, false, true);
                    //to.Clear();
                }
                if (bCheckIsBIPL == true)
                {
                    
                    //DataSet ds = new DataSet();
                    //ds = this.GetDispatchEntryMailWeekName(0);
                    //DataTable dt = new DataTable();
                    //string StrListEmailsID = string.Empty;
                    //dt = ds.Tables[1];
                    //StrListEmailsID = dt.Rows[0]["Emails"].ToString();
                    //SendMailUsingKeyValueByTargetAdmin(StrListEmailsID, out to);
                    
                    //string pdfFilePathBH = Path.Combine(Constants.TEMP_FOLDER_PATH, "Courier List-BIPL " + CourrierDate.ToString("dd MMM yyy") + ".pdf");
                    //success = controller.GenerateDailyCourierReport(pdfFilePathBH, CourrierDate, 2);

                    //added by raghvinder on 25-08-2020 start
                    DataTable courierDate_dt = new DataTable();
                    courierDate_dt = NotificationDataProviderInstance.GetCourierDispatchListDate(CourrierDate);
                    DateTime CourierDate = Convert.ToDateTime(courierDate_dt.Rows[0]["CourierDate"].ToString());                    
                    string pdfFilePathBH = Path.Combine(Constants.TEMP_FOLDER_PATH, "Courier List-BIPL " + CourierDate.ToString("dd MMM yyy") + ".pdf");
                    template.Subject = template.Subject.Replace("[[DATE]]", CourierDate.ToString("dd MMM yy (ddd)"));
                    success = controller.GenerateDailyCourierReport(pdfFilePathBH, CourierDate, 2);
                    //added by raghvinder on 25-08-2020 end


                    List<Attachment> atts = new List<Attachment>();
                    //atts.Add(new Attachment(pdfFilePath));
                    atts.Add(new Attachment(pdfFilePathBH));
                    System.Diagnostics.Trace.WriteLine("Processing of Courier Dispatch List Email having Subject ----" + template.Subject + "has been started on " + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    if (!success)
                    {
                        System.Diagnostics.Trace.WriteLine("There is no record in the pdf for Courier Dispatch List Email. So Email has not been send on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt") + "\n");
                        return;
                    }


                    //this.SendEmail(fromName, to, null, null, template.Subject.ToUpper(), template.Content, atts, false, true);
                    //to.Clear();
                }
                //End by abhishek on 23/2/2016
                // System.Diagnostics.Trace.WriteLine("Pdf for Courier Dispatch List Email has been generated successfully  on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                //if (!success)
                //{
                //    System.Diagnostics.Trace.WriteLine("There is no record in the pdf for Courier Dispatch List Email. So Email has not been send on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt") + "\n");
                //    return;
                //}


                //this.SendEmail(fromName, to, null, null, template.Subject.ToUpper(), template.Content, atts, false, true);

            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in  Courier Dispatch List Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                this.SendErrorEmail(ex.Message + "\n" + ex.StackTrace);
            }
        }
        //end by abhishek 23/2/2016

        public Boolean SendEmailForPendingBIPLAgreement(iKandi.Common.Order objOrder, Boolean isAsync)
        {
            try
            {
                EmailTemplate template = this.AdminDataProviderInstance.GetEmailTemplateByType(EmailTemplateType.PENDINGBIPLAGREEMENT);
                List<String> departmentList = new List<String>();
                List<String> designationList = new List<string>();

                departmentList.AddRange(template.DepartmentIDs.Split(new char[] { ',' }));
                designationList.AddRange(template.DesignationIDs.Split(new char[] { ',' }));

                //designationList.Add(Convert.ToInt32(Designation.iKandi_Sales_Manager).ToString());
                //designationList.Add(Convert.ToInt32(Designation.iKandi_Sales_SalesManager).ToString());
                //designationList.Add(Convert.ToInt32(Designation.BIPL_Sales_Advisor).ToString());
                //designationList.Add(Convert.ToInt32(Designation.BIPL_Sales_Manager).ToString());

                // Get User Data
                List<User> userList = GetUserInfo(new List<String>(), designationList, departmentList, objOrder.Style.client.ClientID);

                String fromName = BLLCache.GetConfigurationKeyValue("FROMEMAIL");

                List<String> to = new List<String>();
                String salesMangerBipl = String.Empty;

                foreach (User user in userList)
                {
                    if (to.Contains(user.Email))
                    {
                        continue;
                    }
                    else
                    {
                        //  to.Add(user.Email);



                        if (user.DesignationID == Convert.ToInt32(Designation.BIPL_Sales_Manager))
                        {
                            //salesMangerBipl = user.FullName;
                            salesMangerBipl = "Roshan Verma";
                        }
                    }
                }
                //Abhishek
                //Commented Email 22-03-2016
               // SendMailUsingKeyValue("BIPL.SendEmailForPendingBIPLAgreement", out to);


                //to.Add("bipl_sales@boutique.in");
                //to.Add("bipl_fit_merch@boutique.in");
                //to.Add("bipl_accountmanagers@boutique.in");
                //END
                ////to.Add("roshan@boutique.in");
                ////to.Add("chandrakanta@boutique.in");
                ////to.Add("jatinder@boutique.in");
                ////to.Add("jeena@boutique.in");
                ////to.Add("shweta@boutique.in");
                ////to.Add("shradha@boutique.in");
                ////to.Add("hitesh@boutique.in");
                ////to.Add("NIKHIL@boutique.in");
                ////to.Add("arun@boutique.in");
                ////to.Add("ankit@boutique.in");
                ////to.Add("sanjeev@boutique.in");
                ////to.Add("hitesh@boutique.in");



                WorkflowInstance objWorkflowInstance = this.WorkflowControllerInstance.GetInstance(objOrder.Style.StyleID, -1, -1);
                if (objWorkflowInstance != null)
                {
                    List<WorkflowInstanceDetail> objWorkflowInstanceDetails = this.WorkflowControllerInstance.GetCurrentPendingTasks(objWorkflowInstance.WorkflowInstanceID);

                    Boolean isPending = false;
                    foreach (WorkflowInstanceDetail objWorkflowInstanceDetail in objWorkflowInstanceDetails)
                    {
                        if (objWorkflowInstanceDetail.ActionDate == DateTime.MinValue && objWorkflowInstanceDetail.StatusModeID == (int)TaskMode.BIPL_AGREEMENT_BIPL)
                        {
                            //Gajendra Email Notification
                            NotificationEmailHistory NEH = new NotificationEmailHistory();
                            NEH.Type = "5";
                            NEH.EmailID = "4";
                            NEH.OrderID = objOrder.OrderID.ToString();
                            NEH.OrderDetailsID = objOrder.OrderDetailsID.ToString();
                            this.NotificationControllerInstance.NotificationEmailHistory_Ins(NEH);
                            isPending = true;
                            break;
                        }
                        else
                        {
                            System.Diagnostics.Trace.WriteLine("Pending Bipl agreement email can not be send on  " + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                        }
                    }

                    if (isPending)
                    {

                        List<Attachment> attachments = new List<Attachment>();

                        CostingController costingController = new CostingController();
                        // TODO
                        int cID = costingController.GetParentCostingID(objOrder.Costing.CostingID);
                        int ClientID = costingController.GetClientID(objOrder.Costing.CostingID);
                        int DeptID = costingController.GetDeptID(objOrder.Costing.CostingID);

                        // Get the screenshot of Costing sheet
                        // order.Costing.CostingID
                        List<string> paths = iKandi.Common.WebPageScreenShotGenerator.GetScreenShot(new string[] { "/Internal/Sales/TabCostingSheet.aspx?cid=" + cID + "&StyleID=" + objOrder.Style.StyleID + "&ClientID=" + ClientID + "&DepartmentID=" + DeptID },
                           Constants.INTERNAL_SITE_BASE_URL + "/public/login.aspx ",
                          "anu@boutique.in",
                           BLLCache.GetConfigurationKeyValue("BIPLMANAGERUSERPASSWORD"), 1280, 1050, false);

                        if (paths.Count > 0)
                        {
                            AddAttachments(paths[0], attachments, string.Empty);
                        }

                        template.Subject = template.Subject.Replace("[[STYLE NUMBER]]", objOrder.Style.StyleNumber.ToUpper());
                        template.Subject = template.Subject.Replace("[[BUYER]]", objOrder.Style.client.CompanyName.ToUpper());
                        template.Content = template.Content.Replace("[[SALES MANAGER BIPL]]", salesMangerBipl.ToUpper());

                        System.Diagnostics.Trace.WriteLine("Processing of Pending Bipl agreement email having Subject ----" + template.Subject + "has been started on " + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                        return this.SendEmail(fromName, to, null, null, template.Subject.ToUpper(), template.Content, attachments, true, isAsync);
                    }
                }
                else
                {
                    System.Diagnostics.Trace.WriteLine("There is no record in Pending Bipl agreement email. So Email Cannot be send on " + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                }

               

                return false;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in  Pending Bipl agreement email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
              //  this.SendErrorEmail(ex.Message + "\n" + ex.StackTrace);
                return false;
            }
        }

        public Boolean SendEmailForMMR_Report(Boolean isAsync)
        {
            try
            {
                EmailTemplate template = new EmailTemplate();
                

                String fromName = BLLCache.GetConfigurationKeyValue("FROMEMAIL");

                List<String> to = new List<String>();
               
                SendMailUsingKeyValue("BIPL.SendEmailForPendingBIPLAgreement", out to);

                //to.Add("bipl_sales@boutique.in");
                //to.Add("bipl_fit_merch@boutique.in");
                //to.Add("bipl_accountmanagers@boutique.in");
                //END
                ////to.Add("roshan@boutique.in");
                ////to.Add("chandrakanta@boutique.in");
                ////to.Add("jatinder@boutique.in");
                ////to.Add("jeena@boutique.in");
                ////to.Add("shweta@boutique.in");
                ////to.Add("shradha@boutique.in");
                ////to.Add("hitesh@boutique.in");
                ////to.Add("NIKHIL@boutique.in");
                ////to.Add("arun@boutique.in");
                ////to.Add("ankit@boutique.in");
                ////to.Add("sanjeev@boutique.in");
                ////to.Add("hitesh@boutique.in");                              

                List<Attachment> attachments = new List<Attachment>();
            
                List<string> paths = iKandi.Common.WebPageScreenShotGenerator.GetScreenShot(new string[] { "/Internal/OrderProcessing/MMR_Reports.aspx" },
                    Constants.INTERNAL_SITE_BASE_URL + "/public/login.aspx ",
                    "roshan@boutique.in",
                    BLLCache.GetConfigurationKeyValue("BIPLMANAGERUSERPASSWORD"), 1280, 1050, false);

                if (paths.Count > 0)
                {
                    AddAttachments(paths[0], attachments, string.Empty);
                }

                template.Subject = "MMR Reports";                      
                template.Content =  "MMR Reports on dates ...";

                System.Diagnostics.Trace.WriteLine("Processing of Pending Bipl agreement email having Subject ----" + template.Subject + "has been started on " + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                return this.SendEmail(fromName, to, null, null, template.Subject.ToUpper(), template.Content, attachments, true, isAsync);
              
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in  Pending Bipl agreement email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                //  this.SendErrorEmail(ex.Message + "\n" + ex.StackTrace);
                return false;
            }
        }


        public Boolean Allocated(iKandi.Common.Order objOrder, int OrderDetailId, Int32 UnitId, string fabricDetail, string accessoriesDetail,
            string cuttingDetail, bool isReallocated, Boolean isAsync)
        {

            try
            {
                EmailTemplate template = this.AdminDataProviderInstance.GetEmailTemplateByType(EmailTemplateType.ALLOCATED);

                List<String> departmentList = new List<String>();
                List<String> designationList = new List<string>();

                departmentList.AddRange(template.DepartmentIDs.Split(new char[] { ',' }));
                designationList.AddRange(template.DesignationIDs.Split(new char[] { ',' }));


                // FACTORY MANAGER,  MERCHANDISING TEAM (OF THIS BUYER), LOGISTICS, QA, SALES MANAGERS BIPL.
                ProductionUnit objProductionUnit = this.AllocationDataProviderInstance.GetProductionUnits(UnitId);

                if (UnitId == 0)
                {
                    return false;
                }

                //objDesignationList.Add(Convert.ToInt32(Designation.BIPL_Merchandising_Manager).ToString());
                //objDesignationList.Add(Convert.ToInt32(Designation.BIPL_Merchandising_AccountManager).ToString());
                //objDesignationList.Add(Convert.ToInt32(Designation.BIPL_Merchandising_FitMerchant).ToString());
                //objDesignationList.Add(Convert.ToInt32(Designation.BIPL_Merchandising_SamplingMerchant).ToString());
                //objDesignationList.Add(Convert.ToInt32(Designation.BIPL_Sales_Manager).ToString());

                //objDeptList.Add(Convert.ToInt32(Group.BIPL_QA).ToString());
                //objDeptList.Add(Convert.ToInt32(Group.BIPL_Logistics).ToString());

                List<String> objUserList = new List<String>();
                objUserList.Add(objProductionUnit.ProductionUnitManagerId.ToString());

                //get User Data
                // List<User> userList = GetUserInfo(objUserList, designationList, departmentList, objOrder.ClientID);
                // Edit By surendra on 6 - sept-2013
                List<User> userList = GetUserInfoForAllocated(objUserList, designationList, departmentList, objOrder.ClientID);

                String fromName = BLLCache.GetConfigurationKeyValue("FROMEMAIL");

                List<String> to = new List<String>();
                String factoryManagerBipl = String.Empty;

                foreach (User user in userList)
                {
                    if (to.Contains(user.Email))
                    {
                        continue;
                    }
                    else
                    {
                        // edit by surendra/hitesh
                        // to.Add(user.Email);

                        if (user.DesignationID == Convert.ToInt32(Designation.BIPL_Production_FactoryManager))
                        {
                            factoryManagerBipl = user.FullName;
                        }
                    }
                }

                // edit by surendra/hitesh
                //Abhishek
                SendMailUsingKeyValue("BIPL.Allocated", out to);

                //END
                //to.Add("bipl_ieupdate@boutique.in");
                //to.Add("sanjeev@boutique.in");
                //to.Add("hitesh@boutique.in");


                Style objStyle = this.StyleDataProviderInstance.GetStyleByStyleId(objOrder.StyleID);
                OrderDetail orderDetail = objOrder.OrderBreakdown.Find(delegate(OrderDetail OD) { return OD.OrderDetailID == OrderDetailId; });

                if (orderDetail == null)
                {
                    System.Diagnostics.Trace.WriteLine("There is no records in  Allocated Email.So Email has not been send  on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    return false;
                }


                template.Subject = template.Subject.Replace("[[BUYER-DEPARTMENT]]", objOrder.Style.client.CompanyName.ToString().ToUpper() + "-" + objOrder.Style.cdept.Name.ToString().ToUpper());
                template.Subject = template.Subject.Replace("[[STYLE NUMBER]]", objOrder.Style.StyleNumber.ToString().ToUpper() + "-" + orderDetail.ContractNumber.ToString().ToUpper());
                template.Subject = template.Subject.Replace("[[EX FACTORY]]", orderDetail.ExFactory.ToString("dd MMM yy (ddd)").ToUpper());
                template.Subject = template.Subject.Replace("[[FACTORY UNIT]]", objProductionUnit.FactoryName.ToString().ToUpper());
                template.Subject = template.Subject.Replace("[[ALLOCATED OR REALLOCATED]]", isReallocated ? "RE-ALLOCATED" : "ALLOCATED");

                template.Content = template.Content.Replace("[[PRODUCTION MANAGER]]", "BIPL SALES DIRECTOR");
                template.Content = template.Content.Replace("[[FACTORY MANAGER]]", factoryManagerBipl.ToString().ToUpper());
                template.Content = template.Content.Replace("[[ALLOCATED OR REALLOCATED]]", isReallocated ? "Re-allocated" : "Allocated");

                if (fabricDetail.Trim().IndexOf(": ( 0% )") > -1)
                {
                    fabricDetail = fabricDetail.Replace(": ( 0% )", "");
                }

                template.Content = template.Content.Replace("[[Fabric Name: Fabric %]]", fabricDetail.Trim().ToUpper());
                template.Content = template.Content.Replace("[[Accessory Name: Accessory %]]", accessoriesDetail.Trim().ToUpper());
                template.Content = template.Content.Replace("[[Cut %]]", cuttingDetail.Trim().ToUpper());

                System.Diagnostics.Trace.WriteLine("Processing of Allocated Email having Subject ----" + template.Subject + "has been started on " + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                return this.SendEmail(fromName, to, null, null, template.Subject.ToUpper(), template.Content, null, false, isAsync);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in  Allocated Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                //this.SendErrorEmail(ex.Message + "\n" + ex.StackTrace);
                return false;
            }
        }

        // Tested
        public void SendProductionReport()
        {

            try
            {
                EmailTemplate template = this.AdminDataProviderInstance.GetEmailTemplateByType(EmailTemplateType.PRODUCTIONREPORT);

                List<String> departmentList = new List<String>();
                List<String> designationList = new List<string>();

                departmentList.AddRange(template.DepartmentIDs.Split(new char[] { ',' }));
                designationList.AddRange(template.DesignationIDs.Split(new char[] { ',' }));

                // SALES, MERCHANDISING, FABRICS, ACCESSORIES, QA, PRODUCTION, LOGISTICS, IKANDI MANAGER SALES

                //objDepartmentIdList.Add(Convert.ToInt32(Group.BIPL_Accessory).ToString());
                //objDepartmentIdList.Add(Convert.ToInt32(Group.BIPL_Fabrics).ToString());
                //objDepartmentIdList.Add(Convert.ToInt32(Group.BIPL_QA).ToString());
                //objDepartmentIdList.Add(Convert.ToInt32(Group.BIPL_Sales).ToString());
                //objDepartmentIdList.Add(Convert.ToInt32(Group.BIPL_Production).ToString());
                //objDepartmentIdList.Add(Convert.ToInt32(Group.BIPL_Logistics).ToString());
                //objDepartmentIdList.Add(Convert.ToInt32(Group.BIPL_Merchandising).ToString());


                //designationList.Add(((int)Designation.iKandi_Sales_Manager).ToString());
                //designationList.Add(((int)Designation.BIPL_Production_Manager).ToString());

                //get User Data
                List<User> userList = GetUserInfo(new List<String>(), designationList, departmentList, 0);

                String fromName = BLLCache.GetConfigurationKeyValue("FROMEMAIL");

                List<String> to = new List<String>();

                foreach (User user in userList)
                {
                    if (to.Contains(user.Email))
                    {
                        continue;
                    }
                    else
                    {
                        to.Add(user.Email);

                    }
                }
                double sumPCSCut = 0;
                double sumPcsStitched = 0;
                double sumBalOfMech = 0;
                double sumPcsPacked = 0;
                double sumExFactoried = 0;

                List<OrderDetail> orderDetail = this.ReportDataProviderInstance.GetProductionEmailContaint();
                StringBuilder sb = new StringBuilder();
                if (orderDetail.Count > 0)
                {
                    sb.Append("<TABLE border=1 cellpadding=5>");
                    sb.Append("<TR>");
                    sb.Append("<TH>FACTORY NAME</TH>");
                    sb.Append("<TH>TOTAL PCS CUT TODAY</TH>");
                    sb.Append("<TH>TOTAL PCS STITCHED TODAY</TH>");
                    sb.Append("<TH>BALANCE ON MACHINE</TH>");
                    sb.Append("<TH>TOTAL PCS PACKED TODAY</TH>");
                    sb.Append("<TH>TOTAL PCS EX-FACTORIED YESTERDAY.</TH>");
                    sb.Append("</TR>");

                    foreach (OrderDetail od in orderDetail)
                    {
                        sb.Append("<TR>");
                        sb.Append("<TD>" + ((od.Unit.FactoryName == null) ? string.Empty : od.Unit.FactoryName.ToString().ToUpper()) + "</TD>");
                        sb.Append("<TD>" + ((od.ParentOrder.CuttingHistory.Quantity == 0) ? string.Empty : od.ParentOrder.CuttingHistory.Quantity.ToString("N0")) + "</TD>");
                        sb.Append("<TD>" + ((od.ParentOrder.StitchingHistory.Quantity == 0) ? string.Empty : od.ParentOrder.StitchingHistory.Quantity.ToString("N0")) + "</TD>");
                        sb.Append("<TD>" + ((od.ParentOrder.CuttingDetail.BalanceInHouse == 0) ? string.Empty : od.ParentOrder.CuttingDetail.BalanceInHouse.ToString("N0")) + "</TD>");
                        sb.Append("<TD>" + ((od.ParentOrder.StitchingDetail.PcsPackedToday == 0) ? string.Empty : od.ParentOrder.StitchingDetail.PcsPackedToday.ToString("N0")) + "</TD>");
                        sb.Append("<TD>" + ((od.Quantity == 0) ? string.Empty : od.Quantity.ToString("N0")) + "</TD>");
                        sb.Append("</TR>");

                        sumPCSCut += od.ParentOrder.CuttingHistory.Quantity;
                        sumPcsStitched += od.ParentOrder.StitchingHistory.Quantity;
                        sumBalOfMech += od.ParentOrder.CuttingDetail.BalanceInHouse;
                        sumPcsPacked += od.ParentOrder.StitchingDetail.PcsPackedToday;
                        sumExFactoried += od.Quantity;
                    }

                    sb.Append("<TR>");
                    sb.Append("<TH>" + "TOTAL" + "</TH>");
                    sb.Append("<TD>" + ((sumPCSCut == 0) ? string.Empty : sumPCSCut.ToString("N0")) + "</TD>");
                    sb.Append("<TD>" + ((sumPcsStitched == 0) ? string.Empty : sumPcsStitched.ToString("N0")) + "</TD>");
                    sb.Append("<TD>" + ((sumBalOfMech == 0) ? string.Empty : sumBalOfMech.ToString("N0")) + "</TD>");
                    sb.Append("<TD>" + ((sumPcsPacked == 0) ? string.Empty : sumPcsPacked.ToString("N0")) + "</TD>");
                    sb.Append("<TD>" + ((sumExFactoried == 0) ? string.Empty : sumExFactoried.ToString("N0")) + "</TD>");
                    sb.Append("</TR>");
                    sb.Append("</TABLE>");
                }
                else
                {
                    sb.Append(string.Empty);
                }

                //template.Content = template.Content.Replace("[[PRODUCTION MANAGER]]", productionManagerBIPL.ToUpper());
                template.Content = template.Content.Replace("[[Content]]", sb.ToString());

                ReportController controller = new ReportController();

                if (!Directory.Exists(Constants.TEMP_FOLDER_PATH))
                    Directory.CreateDirectory(Constants.TEMP_FOLDER_PATH);

                string pdfFilePath = Path.Combine(Constants.TEMP_FOLDER_PATH, "Production Report -" + DateTime.Today.ToString("dd MMM yyy") + ".pdf");

                //bool success = controller.GenerateDailyProductionReport(pdfFilePath, string.Empty, DateTime.MinValue, DateTime.MinValue, -1, -1, -1);
                System.Diagnostics.Trace.WriteLine("Pdf for Production Report  Email has been generated successfully  on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                //if (!success)
                //{
                //    System.Diagnostics.Trace.WriteLine("There is no record in the pdf for Production Report Email. So Email has not been send on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                //    return;
                //}

                List<Attachment> atts = new List<Attachment>();
                atts.Add(new Attachment(pdfFilePath));

                System.Diagnostics.Trace.WriteLine("Processing of Production Report Email having Subject ----" + template.Subject + "has been started on " + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                this.SendEmail(fromName, to, null, null, template.Subject.ToUpper(), template.Content, atts, false, true);

            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in Production Report Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
               // this.SendErrorEmail(ex.Message + "\n" + ex.StackTrace);
            }
        }

        public void SendProductionReportDaily()
        {

            try
            {
                EmailTemplate template = this.AdminDataProviderInstance.GetEmailTemplateByType(EmailTemplateType.PRODUCTIONREPORT);

                List<String> departmentList = new List<String>();
                List<String> designationList = new List<string>();

                departmentList.AddRange(template.DepartmentIDs.Split(new char[] { ',' }));
                designationList.AddRange(template.DesignationIDs.Split(new char[] { ',' }));

                //get User Data
                List<User> userList = GetUserInfo(new List<String>(), designationList, departmentList, 0);

                String fromName = BLLCache.GetConfigurationKeyValue("FROMEMAIL");

                List<String> to = new List<String>();

                foreach (User user in userList)
                {
                    if (to.Contains(user.Email))
                    {
                        continue;
                    }
                    else
                    {
                        //to.Add(user.Email);

                    }
                }
                // edit by surendra on 06-Nov-2014
                //Abhishek
                SendMailUsingKeyValue("BIPL.SendProductionReportDaily", out to);


                //to.Add("bipl_ieupdate@boutique.in");
                //to.Add("sanjeev@boutique.in");
                //to.Add("hitesh@boutique.in");
                //END
                int sumPCSCut = 0;
                int sumPcsStitched = 0;
                int sumBalOfMech = 0;
                int sumPcsPacked = 0;
                int sumExFactoried = 0;

                DataSet DsRecords = this.ReportDataProviderInstance.GetProductionEmailContaintDaily();
                StringBuilder sb = new StringBuilder();
                if (DsRecords.Tables[0].Rows.Count > 0)
                {
                    sb.Append("<TABLE border=1 cellpadding=5>");
                    sb.Append("<TR><TD style='background-color:#f9ddf4;' colspan=6>DAILY PRODUCTION REPORT</TD></TR>");
                    sb.Append("<TR>");
                    sb.Append("<TH>FACTORY NAME</TH>");
                    sb.Append("<TH>TOTAL PCS CUT TODAY</TH>");
                    sb.Append("<TH>TOTAL PCS STITCHED TODAY</TH>");
                    sb.Append("<TH>BALANCE ON MACHINE</TH>");
                    sb.Append("<TH>TOTAL PCS PACKED TODAY</TH>");
                    sb.Append("<TH>TOTAL PCS EX-FACTORIED YESTERDAY.</TH>");
                    sb.Append("</TR>");
                    string cutting = string.Empty;
                    string stitching = string.Empty;
                    string packing = string.Empty;
                    string BalanceOnMachine = string.Empty;

                    string ExFactoryCount = string.Empty;
                    for (int i = 0; i <= DsRecords.Tables[0].Rows.Count - 1; i++)
                    {
                        sb.Append("<TR>");
                        sb.Append("<TD style='background-color:#f9ddf4;'>" + ((DsRecords.Tables[0].Rows[i]["UnitName"] == null) ? string.Empty : DsRecords.Tables[0].Rows[i]["UnitName"].ToString().ToUpper()) + "</TD>");
                        cutting = ""; stitching = ""; packing = ""; BalanceOnMachine = ""; ExFactoryCount = "";
                        if (DsRecords.Tables[0].Rows[i]["CurPcsCut"] != null)
                        {
                            cutting = Convert.ToInt32(DsRecords.Tables[0].Rows[i]["CurPcsCut"]).ToString("N0") + " ";
                        }
                        if (DsRecords.Tables[0].Rows[i]["CurPcsCut_Raised"] != null)
                        {
                            cutting += DsRecords.Tables[0].Rows[i]["CurPcsCut_Raised"].ToString();
                        }

                        if (DsRecords.Tables[0].Rows[i]["CurPcsPacked"] != null)
                        {
                            packing = Convert.ToInt32(DsRecords.Tables[0].Rows[i]["CurPcsPacked"]).ToString("N0") + " ";
                        }
                        if (DsRecords.Tables[0].Rows[i]["CurPcsPacked_Raised"] != null)
                        {
                            packing += DsRecords.Tables[0].Rows[i]["CurPcsPacked_Raised"].ToString();
                        }

                        if (DsRecords.Tables[0].Rows[i]["CurPcsStitched"] != null)
                        {
                            stitching = Convert.ToInt32(DsRecords.Tables[0].Rows[i]["CurPcsStitched"]).ToString("N0") + " ";

                        }
                        if (DsRecords.Tables[0].Rows[i]["CurPcsStitched_Raised"] != null)
                        {
                            stitching += DsRecords.Tables[0].Rows[i]["CurPcsStitched_Raised"].ToString();
                        }

                        if (DsRecords.Tables[0].Rows[i]["BalanceOnMachine"] != null)
                        {
                            BalanceOnMachine = Convert.ToInt32(DsRecords.Tables[0].Rows[i]["BalanceOnMachine"]).ToString("N0");
                            //double MachinCal = MachineCalculate(Convert.ToInt32(DsRecords.Tables[0].Rows[i]["BalanceOnMachine"]), Convert.ToInt32(DsRecords.Tables[0].Rows[i]["CurPcsStitched"]));
                            //if (MachinCal<=3)
                            //    BalanceOnMachine += "(" + MachinCal + " Days High Alert)";
                            //else if (MachinCal >= 7)
                            //    BalanceOnMachine += "(" + MachinCal + " Days High WIP)";
                            //else
                            //{
                            //    BalanceOnMachine += "(" + MachinCal + " Days )";
                            //}

                        }
                        if (DsRecords.Tables[0].Rows[i]["ExfactoriedCount"] != null)
                        {
                            ExFactoryCount = Convert.ToInt32(DsRecords.Tables[0].Rows[i]["ExfactoriedCount"]).ToString("N0");
                        }
                        if (DsRecords.Tables[0].Rows[i]["ExfactoriedCount_Raised"] != null)
                        {
                            ExFactoryCount += DsRecords.Tables[0].Rows[i]["ExfactoriedCount_Raised"].ToString();
                        }

                        cutting = (cutting.Trim() == "0") ? "" : cutting;
                        stitching = (stitching.Trim() == "0") ? "" : stitching;
                        BalanceOnMachine = (BalanceOnMachine.Trim() == "0") ? "" : BalanceOnMachine;
                        packing = (packing.Trim() == "0") ? "" : packing;
                        ExFactoryCount = (ExFactoryCount.Trim() == "0") ? "" : ExFactoryCount;

                        sb.Append("<TD>" + cutting + "</TD>");
                        sb.Append("<TD>" + stitching + "</TD>");
                        double MachinCal = MachineCalculate(Convert.ToInt32(DsRecords.Tables[0].Rows[i]["BalanceOnMachine"]), Convert.ToInt32(DsRecords.Tables[0].Rows[i]["CurPcsStitched"]));
                        if (MachinCal <= 3)
                        {
                            BalanceOnMachine += "(" + MachinCal + " Days High Alert)";
                            sb.Append("<TD style='color:Red;'>" + BalanceOnMachine + "</TD>");
                        }
                        else if (MachinCal >= 7)
                        {
                            BalanceOnMachine += "(" + MachinCal + " Days High WIP)";
                            sb.Append("<TD style='color:#0000A0;'>" + BalanceOnMachine + "</TD>");
                        }
                        else
                        {
                            BalanceOnMachine += "(" + MachinCal + " Days )";
                            sb.Append("<TD style='color:Green;'>" + BalanceOnMachine + "</TD>");
                        }

                        // sb.Append("<TD>" + BalanceOnMachine +"</TD>");
                        sb.Append("<TD>" + packing + "</TD>");
                        sb.Append("<TD>" + ExFactoryCount + "</TD>");
                        sb.Append("</TR>");

                        sumPCSCut += Convert.ToInt32(DsRecords.Tables[0].Rows[i]["CurPcsCut"]);
                        sumPcsStitched += Convert.ToInt32(DsRecords.Tables[0].Rows[i]["CurPcsStitched"]);
                        sumBalOfMech += Convert.ToInt32(DsRecords.Tables[0].Rows[i]["BalanceOnMachine"]);
                        sumPcsPacked += Convert.ToInt32(DsRecords.Tables[0].Rows[i]["CurPcsPacked"]);
                        sumExFactoried += Convert.ToInt32(DsRecords.Tables[0].Rows[i]["ExfactoriedCount"]);
                    }

                    sb.Append("<TR>");
                    sb.Append("<TH>" + "TOTAL" + "</TH>");
                    sb.Append("<TD style='background-color:#f9ddf4;'>" + ((sumPCSCut == 0) ? string.Empty : sumPCSCut.ToString("N0") + Convert.ToString(DsRecords.Tables[1].Rows[2]["CurPcsCut_Raised"])) + "</TD>");
                    sb.Append("<TD style='background-color:#f9ddf4;'>" + ((sumPcsStitched == 0) ? string.Empty : sumPcsStitched.ToString("N0") + Convert.ToString(DsRecords.Tables[1].Rows[2]["CurPcsStitched_Raised"])) + "</TD>");
                    // edit by surendra
                    double TotalCalc = MachineCalculate(Convert.ToInt32(sumBalOfMech), Convert.ToInt32(sumPcsStitched));
                    string BalanceOnTotal = string.Empty; ;
                    if (TotalCalc <= 3)
                    {
                        BalanceOnTotal += "(" + TotalCalc + " Days High Alert)";
                        sb.Append("<TD style='background-color:#f9ddf4;color:Red;'>" + ((sumBalOfMech == 0) ? string.Empty : sumBalOfMech.ToString("N0") + Convert.ToString(BalanceOnTotal)) + "</TD>");
                    }
                    else if (TotalCalc >= 7)
                    {
                        BalanceOnTotal += "(" + TotalCalc + " Days High WIP)";
                        sb.Append("<TD style='background-color:#f9ddf4;color:#0000A0;'>" + ((sumBalOfMech == 0) ? string.Empty : sumBalOfMech.ToString("N0") + Convert.ToString(BalanceOnTotal)) + "</TD>");
                    }
                    else
                    {
                        BalanceOnTotal += "(" + TotalCalc + " Days )";
                        sb.Append("<TD style='background-color:#f9ddf4;color:Green;'>" + ((sumBalOfMech == 0) ? string.Empty : sumBalOfMech.ToString("N0") + Convert.ToString(BalanceOnTotal)) + "</TD>");
                    }


                    // end
                    // sb.Append("<TD style='background-color:#f9ddf4;'>" + ((sumBalOfMech == 0) ? string.Empty : sumBalOfMech.ToString("N0")) + "</TD>");
                    sb.Append("<TD style='background-color:#f9ddf4;'>" + ((sumPcsPacked == 0) ? string.Empty : sumPcsPacked.ToString("N0") + Convert.ToString(DsRecords.Tables[1].Rows[2]["CurPcsPacked_Raised"])) + "</TD>");
                    sb.Append("<TD style='background-color:#f9ddf4;'>" + ((sumExFactoried == 0) ? string.Empty : sumExFactoried.ToString("N0") + Convert.ToString(DsRecords.Tables[1].Rows[0]["ExFactoriedCount_Raised"])) + "</TD>");
                    sb.Append("</TR>");

                    cutting = Convert.ToString(Convert.ToInt32(DsRecords.Tables[1].Rows[0]["CurPcsCut"]) / Convert.ToInt32(DsRecords.Tables[1].Rows[0]["DayCount"]));
                    stitching = Convert.ToString(Convert.ToInt32(DsRecords.Tables[1].Rows[0]["CurPcsStitched"]) / Convert.ToInt32(DsRecords.Tables[1].Rows[0]["DayCount"]));
                    packing = Convert.ToString(Convert.ToInt32(DsRecords.Tables[1].Rows[0]["CurPcsPacked"]) / Convert.ToInt32(DsRecords.Tables[1].Rows[0]["DayCount"]));
                    ExFactoryCount = Convert.ToString(Convert.ToInt32(DsRecords.Tables[1].Rows[0]["ExfactoriedCount"]) / Convert.ToInt32(DsRecords.Tables[1].Rows[0]["DayCount"]));


                    sb.Append("<TR>");
                    sb.Append("<TH>" + "Weekly Average" + "</TH>");
                    sb.Append("<TD style='background-color:#f9ddf4;' >" + ((cutting == "0") ? "" : Convert.ToInt32(cutting).ToString("N0")) + Convert.ToString(DsRecords.Tables[1].Rows[0]["CurPcsCut_Raised"]) + "</TD>");
                    sb.Append("<TD style='background-color:#f9ddf4;'>" + ((stitching == "0") ? "" : Convert.ToInt32(stitching).ToString("N0")) + Convert.ToString(DsRecords.Tables[1].Rows[0]["CurPcsStitched_Raised"]) + "</TD>");
                    sb.Append("<TD style='background-color:#f9ddf4;'>" + "" + "</TD>");
                    sb.Append("<TD style='background-color:#f9ddf4;'>" + ((packing == "0") ? "" : Convert.ToInt32(packing).ToString("N0")) + Convert.ToString(DsRecords.Tables[1].Rows[0]["CurPcsPacked_Raised"]) + "</TD>");
                    sb.Append("<TD style='background-color:#f9ddf4;'>" + ((ExFactoryCount == "0") ? "" : Convert.ToInt32(ExFactoryCount).ToString("N0")) + Convert.ToString(DsRecords.Tables[1].Rows[0]["ExFactoriedCount_Raised"]) + "</TD>");
                    sb.Append("</TR>");

                    cutting = Convert.ToString(Convert.ToInt32(DsRecords.Tables[1].Rows[1]["CurPcsCut"]) / Convert.ToInt32(DsRecords.Tables[1].Rows[1]["DayCount"]));
                    cutting = (cutting == "0") ? "" : Convert.ToInt32(cutting).ToString("N0");

                    stitching = Convert.ToString(Convert.ToInt32(DsRecords.Tables[1].Rows[1]["CurPcsStitched"]) / Convert.ToInt32(DsRecords.Tables[1].Rows[1]["DayCount"]));
                    stitching = (stitching == "0") ? "" : Convert.ToInt32(stitching).ToString("N0");

                    packing = Convert.ToString(Convert.ToInt32(DsRecords.Tables[1].Rows[1]["CurPcsPacked"]) / Convert.ToInt32(DsRecords.Tables[1].Rows[1]["DayCount"]));
                    packing = (packing == "0") ? "" : Convert.ToInt32(packing).ToString("N0");

                    ExFactoryCount = Convert.ToString(Convert.ToInt32(DsRecords.Tables[1].Rows[1]["ExfactoriedCount"]) / Convert.ToInt32(DsRecords.Tables[1].Rows[1]["DayCount"]));
                    ExFactoryCount = (ExFactoryCount == "0") ? "" : Convert.ToInt32(ExFactoryCount).ToString("N0");

                    sb.Append("<TR>");
                    sb.Append("<TH>" + "Monthly Average" + "</TH>");
                    sb.Append("<TD style='background-color:#f9ddf4;'>" + cutting + Convert.ToString(DsRecords.Tables[1].Rows[1]["CurPcsCut_Raised"]) + "</TD>");
                    sb.Append("<TD style='background-color:#f9ddf4;'>" + stitching + Convert.ToString(DsRecords.Tables[1].Rows[1]["CurPcsStitched_Raised"]) + "</TD>");
                    sb.Append("<TD style='background-color:#f9ddf4;'>" + "" + "</TD>");
                    sb.Append("<TD style='background-color:#f9ddf4;'>" + packing + Convert.ToString(DsRecords.Tables[1].Rows[1]["CurPcsPacked_Raised"]) + "</TD>");
                    sb.Append("<TD style='background-color:#f9ddf4;'>" + ExFactoryCount + Convert.ToString(DsRecords.Tables[1].Rows[1]["ExFactoriedCount_Raised"]) + "</TD>");
                    sb.Append("</TR>");
                    sb.Append("</TABLE>");

                    sb.Append("Note:<BR>1.Percentage is based on current day / previous day.");
                    sb.Append("<BR>2. Balance On Machine : Total Cut Pieces Issued - Total Pieces Stitched");



                }
                else
                {
                    sb.Append(string.Empty);
                }

                //template.Content = template.Content.Replace("[[PRODUCTION MANAGER]]", productionManagerBIPL.ToUpper());
                template.Content = template.Content.Replace("[[Content]]", sb.ToString());

                ReportController controller = new ReportController();

                if (!Directory.Exists(Constants.TEMP_FOLDER_PATH))
                    Directory.CreateDirectory(Constants.TEMP_FOLDER_PATH);

                string pdfFilePath = Path.Combine(Constants.TEMP_FOLDER_PATH, "Production Report -" + DateTime.Today.ToString("dd MMM yyy") + ".pdf");

                //bool success = controller.GenerateDailyProductionReport(pdfFilePath, string.Empty, DateTime.MinValue, DateTime.MinValue, -1, -1, -1);
                //System.Diagnostics.Trace.WriteLine("Pdf for Production Report  Email has been generated successfully  on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                //if (!success)
                //{
                //    System.Diagnostics.Trace.WriteLine("There is no record in the pdf for Production Report Email. So Email has not been send on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                //    return;
                //}

                List<Attachment> atts = new List<Attachment>();
                //atts.Add(new Attachment(pdfFilePath));--Attachment removed by client on 11/8/2011

                System.Diagnostics.Trace.WriteLine("Processing of Production Report Email having Subject ----" + template.Subject + "has been started on " + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                this.SendEmail(fromName, to, null, null, template.Subject.ToUpper(), template.Content, atts, false, true);

            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in Production Report Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                //this.SendErrorEmail(ex.Message + "\n" + ex.StackTrace);
            }
        }
        public double MachineCalculate(int BalOnMachine, int PcsStichedToday)
        {

            double Total = 0.0;
            if (PcsStichedToday == 0)
            {

                Total = 0;
            }
            else
            {
                Total = Math.Round((Convert.ToDouble(BalOnMachine)) / Convert.ToDouble(PcsStichedToday), 2);
                Total = Math.Round(Total, 1, MidpointRounding.ToEven);
                //  Total = overAll / Qty * 100;
                if (Total < 0)
                    Total = 0;
            }

            return Total;

        }



        public void SendProductionReportWeekly()
        {

            try
            {
                EmailTemplate template = this.AdminDataProviderInstance.GetEmailTemplateByType(EmailTemplateType.PRODUCTIONREPORT);

                List<String> departmentList = new List<String>();
                List<String> designationList = new List<string>();

                departmentList.AddRange(template.DepartmentIDs.Split(new char[] { ',' }));
                designationList.AddRange(template.DesignationIDs.Split(new char[] { ',' }));

                //get User Data
                List<User> userList = GetUserInfo(new List<String>(), designationList, departmentList, 0);

                String fromName = BLLCache.GetConfigurationKeyValue("FROMEMAIL");

                List<String> to = new List<String>();

                foreach (User user in userList)
                {
                    if (to.Contains(user.Email))
                    {
                        continue;
                    }
                    else
                    {
                        to.Add(user.Email);

                    }
                }
                int Cut0 = 0;
                int Cut4 = 0;
                int Cut12 = 0;
                int St0 = 0;
                int St4 = 0;
                int St12 = 0;
                int Pk0 = 0;
                int Pk4 = 0;
                int Pk12 = 0;
                int ExFactoried = 0;


                DataSet DsRecords = this.ReportDataProviderInstance.GetProductionEmailContaintWeekly();
                StringBuilder sb = new StringBuilder();
                if (DsRecords.Tables[0].Rows.Count > 0)
                {
                    sb.Append("<TABLE border=1 cellpadding=5>");
                    sb.Append("<TR><TD style='background-color:#f9ddf4;' colspan=11>WEEKLY PRODUCTION REPORT</TD></TR>");
                    sb.Append("<TR>");
                    sb.Append("<TH>FACTORY NAME</TH>");
                    sb.Append("<TH>TOTAL PCS CUT IN LAST WEEK</TH>");
                    sb.Append("<TH>TOTAL PCS CUT IN LAST 4 WEEKS</TH>");
                    sb.Append("<TH>TOTAL PCS CUT IN LAST 12 WEEKS</TH>");

                    sb.Append("<TH>TOTAL PCS STITCHED IN LAST WEEK</TH>");
                    sb.Append("<TH>TOTAL PCS STITCHED IN LAST 4 WEEKS</TH>");
                    sb.Append("<TH>TOTAL PCS STITCHED IN LAST 12 WEEKS</TH>");

                    sb.Append("<TH>TOTAL PCS PACKED IN LAST WEEK</TH>");
                    sb.Append("<TH>TOTAL PCS PACKED IN LAST 4 WEEKS</TH>");
                    sb.Append("<TH>TOTAL PCS PACKED IN LAST 12 WEEKS</TH>");

                    sb.Append("<TH>TOTAL PCS EX-FACTORIED YESTERDAY.</TH>");
                    sb.Append("</TR>");
                    string cutting = string.Empty;
                    string stitching = string.Empty;
                    string packing = string.Empty;
                    string BalanceOnMachine = string.Empty;
                    string ExFactoryCount = string.Empty;
                    for (int i = 0; i <= DsRecords.Tables[0].Rows.Count - 1; i++)
                    {
                        packing = ""; BalanceOnMachine = ""; ExFactoryCount = "";
                        sb.Append("<TR>");
                        sb.Append("<TD style='background-color:#f9ddf4;'>" + ((DsRecords.Tables[0].Rows[i]["UnitName"] == null) ? string.Empty : DsRecords.Tables[0].Rows[i]["UnitName"].ToString().ToUpper()) + "</TD>");

                        cutting = "";
                        cutting = Convert.ToInt32(DsRecords.Tables[0].Rows[i]["CutCurWeek"]).ToString("N0") + DsRecords.Tables[0].Rows[i]["Cut_Raised"].ToString();
                        sb.Append("<TD>" + ((cutting.Trim() == "0") ? "" : cutting) + "</TD>");

                        cutting = "";
                        cutting = Convert.ToInt32(DsRecords.Tables[0].Rows[i]["CutCur4Week"]).ToString("N0") + DsRecords.Tables[0].Rows[i]["Cut4_Raised"].ToString();
                        sb.Append("<TD>" + ((cutting.Trim() == "0") ? "" : cutting) + "</TD>");

                        cutting = "";
                        cutting = Convert.ToInt32(DsRecords.Tables[0].Rows[i]["CutCur12Week"]).ToString("N0") + DsRecords.Tables[0].Rows[i]["Cut12_Raised"].ToString();
                        sb.Append("<TD>" + ((cutting.Trim() == "0") ? "" : cutting) + "</TD>");



                        stitching = "";
                        stitching = Convert.ToInt32(DsRecords.Tables[0].Rows[i]["StCurWeek"]).ToString("N0") + DsRecords.Tables[0].Rows[i]["St_Raised"].ToString();
                        sb.Append("<TD>" + ((stitching.Trim() == "0") ? "" : stitching) + "</TD>");

                        stitching = "";
                        stitching = Convert.ToInt32(DsRecords.Tables[0].Rows[i]["StCur4Week"]).ToString("N0") + DsRecords.Tables[0].Rows[i]["St4_Raised"].ToString();
                        sb.Append("<TD>" + ((stitching.Trim() == "0") ? "" : stitching) + "</TD>");

                        stitching = "";
                        stitching = Convert.ToInt32(DsRecords.Tables[0].Rows[i]["StCur12Week"]).ToString("N0") + DsRecords.Tables[0].Rows[i]["St12_Raised"].ToString();
                        sb.Append("<TD>" + ((stitching.Trim() == "0") ? "" : stitching) + "</TD>");

                        packing = "";
                        packing = Convert.ToInt32(DsRecords.Tables[0].Rows[i]["PkCurWeek"]).ToString("N0") + DsRecords.Tables[0].Rows[i]["Pk_Raised"].ToString();
                        sb.Append("<TD>" + ((packing.Trim() == "0") ? "" : packing) + "</TD>");

                        packing = "";
                        packing = Convert.ToInt32(DsRecords.Tables[0].Rows[i]["PkCur4Week"]).ToString("N0") + DsRecords.Tables[0].Rows[i]["Pk4_Raised"].ToString();
                        sb.Append("<TD>" + ((packing.Trim() == "0") ? "" : packing) + "</TD>");

                        packing = "";
                        packing = Convert.ToInt32(DsRecords.Tables[0].Rows[i]["PkCur12Week"]).ToString("N0") + DsRecords.Tables[0].Rows[i]["Pk12_Raised"].ToString();
                        sb.Append("<TD>" + ((packing.Trim() == "0") ? "" : packing) + "</TD>");

                        ExFactoryCount = "";
                        ExFactoryCount = Convert.ToInt32(DsRecords.Tables[0].Rows[i]["ExfactoriedCount"]).ToString("N0") + DsRecords.Tables[0].Rows[i]["ExfactoriedCount_Raised"].ToString();
                        sb.Append("<TD>" + ((ExFactoryCount.Trim() == "0") ? "" : ExFactoryCount) + "</TD>");

                        sb.Append("</TR>");

                        Cut0 += Convert.ToInt32(DsRecords.Tables[0].Rows[i]["CutCurWeek"]);
                        Cut4 += Convert.ToInt32(DsRecords.Tables[0].Rows[i]["CutCur4Week"]);
                        Cut12 += Convert.ToInt32(DsRecords.Tables[0].Rows[i]["CutCur12Week"]);

                        St0 += Convert.ToInt32(DsRecords.Tables[0].Rows[i]["StCurWeek"]);
                        St4 += Convert.ToInt32(DsRecords.Tables[0].Rows[i]["StCur4Week"]);
                        St12 += Convert.ToInt32(DsRecords.Tables[0].Rows[i]["StCur12Week"]);

                        Pk0 += Convert.ToInt32(DsRecords.Tables[0].Rows[i]["PkCurWeek"]);
                        Pk4 += Convert.ToInt32(DsRecords.Tables[0].Rows[i]["PkCur4Week"]);
                        Pk12 += Convert.ToInt32(DsRecords.Tables[0].Rows[i]["PkCur12Week"]);

                        ExFactoried += Convert.ToInt32(DsRecords.Tables[0].Rows[i]["ExfactoriedCount"]);

                    }

                    sb.Append("<TR>");
                    sb.Append("<TH>" + "TOTAL" + "</TH>");
                    sb.Append("<TD style='background-color:#f9ddf4;'>" + ((Cut0 == 0) ? string.Empty : Cut0.ToString("N0")) + "</TD>");
                    sb.Append("<TD style='background-color:#f9ddf4;'>" + ((Cut4 == 0) ? string.Empty : Cut4.ToString("N0")) + "</TD>");
                    sb.Append("<TD style='background-color:#f9ddf4;'>" + ((Cut12 == 0) ? string.Empty : Cut12.ToString("N0")) + "</TD>");

                    sb.Append("<TD style='background-color:#f9ddf4;'>" + ((St0 == 0) ? string.Empty : St0.ToString("N0")) + "</TD>");
                    sb.Append("<TD style='background-color:#f9ddf4;'>" + ((St4 == 0) ? string.Empty : St4.ToString("N0")) + "</TD>");
                    sb.Append("<TD style='background-color:#f9ddf4;'>" + ((St12 == 0) ? string.Empty : St12.ToString("N0")) + "</TD>");

                    sb.Append("<TD style='background-color:#f9ddf4;'>" + ((Pk0 == 0) ? string.Empty : Pk0.ToString("N0")) + "</TD>");
                    sb.Append("<TD style='background-color:#f9ddf4;'>" + ((Pk4 == 0) ? string.Empty : Pk4.ToString("N0")) + "</TD>");
                    sb.Append("<TD style='background-color:#f9ddf4;'>" + ((Pk12 == 0) ? string.Empty : Pk12.ToString("N0")) + "</TD>");

                    sb.Append("<TD style='background-color:#f9ddf4;'>" + ((ExFactoried == 0) ? string.Empty : ExFactoried.ToString("N0")) + "</TD>");

                    sb.Append("</TR>");

                    sb.Append("</TABLE>");

                }
                else
                {
                    sb.Append(string.Empty);
                }

                //template.Content = template.Content.Replace("[[PRODUCTION MANAGER]]", productionManagerBIPL.ToUpper());
                template.Content = template.Content.Replace("[[Content]]", sb.ToString());

                ReportController controller = new ReportController();

                if (!Directory.Exists(Constants.TEMP_FOLDER_PATH))
                    Directory.CreateDirectory(Constants.TEMP_FOLDER_PATH);

                string pdfFilePath = Path.Combine(Constants.TEMP_FOLDER_PATH, "Production Report -" + DateTime.Today.ToString("dd MMM yyy") + ".pdf");

                //bool success = controller.GenerateDailyProductionReport(pdfFilePath, string.Empty, DateTime.MinValue, DateTime.MinValue, -1, -1, -1);
                System.Diagnostics.Trace.WriteLine("Pdf for Production Report  Email has been generated successfully  on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                //if (!success)
                //{
                //    System.Diagnostics.Trace.WriteLine("There is no record in the pdf for Production Report Email. So Email has not been send on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                //    return;
                //}

                List<Attachment> atts = new List<Attachment>();
                //atts.Add(new Attachment(pdfFilePath));

                System.Diagnostics.Trace.WriteLine("Processing of Production Report Email having Subject ----" + template.Subject + "has been started on " + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                this.SendEmail(fromName, to, null, null, template.Subject.ToUpper(), template.Content, atts, false, true);

            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in Production Report Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
               // this.SendErrorEmail(ex.Message + "\n" + ex.StackTrace);
            }
        }

      





   


        public void SendErrorEmail(string ErrorMessage)
        {
            System.Collections.Generic.List<string> to = new System.Collections.Generic.List<string>();
            to.Add(Constants.WEBMASTER_EMAIL);

            if (this.LoggedInUser != null)
            {
                if (this.LoggedInUser.UserData != null)
                {
                    ErrorMessage += "<br>User: " + this.LoggedInUser.UserData.FullName + " <br > UserID:" + this.LoggedInUser.UserData.UserID.ToString();
                }
                else if (this.LoggedInUser.ClientData != null)
                {
                    ErrorMessage += "<br>ClientID: " + this.LoggedInUser.ClientData.ClientID.ToString() + " <br > DeptID:" + this.LoggedInUser.ClientData.DeptID.ToString();
                }
                else if (this.LoggedInUser.PartnerData != null)
                {
                    ErrorMessage += "<br>PartnerID: " + this.LoggedInUser.PartnerData.PartnerID.ToString() + " <br > Partner Name:" + this.LoggedInUser.PartnerData.PartnerName.ToString();
                }
            }
            //Edit by surendra on 10 jan 2013
            //  this.SendEmail(BLLCache.GetConfigurationKeyValue("FROMEMAIL"), to, null, null, "iKandi Error", ErrorMessage, null, false, true);
            this.SendDevelopermail(BLLCache.GetConfigurationKeyValue("FROMEMAIL"), to, null, null, "iKandi Error", ErrorMessage, null, false, true);

            //end
        }

        // Tested
        public Boolean SendEmailForEditOrder(string OrderHtml, string SerialNumber, List<string> Attachments, int ClientID, Boolean isAsync, int bit, string Clients)
        {
            try
            {
                EmailTemplate template = null;

                if (bit == 1)
                {
                    template = this.AdminDataProviderInstance.GetEmailTemplateByType(EmailTemplateType.ORDERFORMCHANGES);
                }
                else
                {
                    template = this.AdminDataProviderInstance.GetEmailTemplateByType(EmailTemplateType.ORDERPROPOSAL);
                }

                List<String> departmentList = new List<String>();
                List<String> designationList = new List<string>();

                string WithClientDesignationIDs;
                string WithNoClientDesignationIDs;

                GetClientAssociatedDesignationID(template.DesignationIDs, out  WithClientDesignationIDs, out  WithNoClientDesignationIDs);

                departmentList.AddRange(template.DepartmentIDs.Split(new char[] { ',' }));
                designationList.AddRange(WithNoClientDesignationIDs.Split(new char[] { ',' }));

                // To add ikandi Sales Executive, BiplsalesManager, Bipl Merchandising Manager
                //List<String> objDesignationList = new List<String>();
                //objDesignationList.Add(Convert.ToInt32(Designation.iKandi_Sales_Manager).ToString());
                //objDesignationList.Add(Convert.ToInt32(Designation.iKandi_Sales_SalesManager).ToString());
                //objDesignationList.Add(Convert.ToInt32(Designation.BIPL_Sales_Manager).ToString());
                //objDesignationList.Add(Convert.ToInt32(Designation.BIPL_Merchandising_Manager).ToString());

                // Get User Data
                List<User> userList = GetUserInfo(new List<String>(), designationList, departmentList, 0);

                // to add Bipl Accounts Manager for that client, bipl fits Merchant of that client
                List<String> objDesignationListWithClient = new List<String>();
                objDesignationListWithClient.AddRange(WithClientDesignationIDs.Split(new char[] { ',' }));

                //objDesignationListWithClient.Add(Convert.ToInt32(Designation.BIPL_Merchandising_AccountManager).ToString());
                //objDesignationListWithClient.Add(Convert.ToInt32(Designation.BIPL_Merchandising_FitMerchant).ToString());

                List<User> userListWithClient = GetUserInfo(new List<String>(), objDesignationListWithClient, new List<String>(), ClientID);

                List<String> to = new List<String>();

                if (Clients != string.Empty)
                {
                    string[] clientArray = Clients.Split(new char[] { ',' });

                    foreach (string client in clientArray)
                    {
                        int clientId = Convert.ToInt32(client);

                        List<User> userListForManyClients = GetUserInfo(new List<String>(), objDesignationListWithClient, new List<string>(), clientId);

                        foreach (User user in userListForManyClients)
                        {
                            if (to.Contains(user.Email.ToString()))
                            {
                                continue;
                            }
                            else
                            {
                                to.Add(user.Email);
                            }
                        }
                    }
                }


                String fromName = BLLCache.GetConfigurationKeyValue("FROMEMAIL");


                String salesMangerBipl = String.Empty;
                String salesMangerIkandi = String.Empty;
                String merchandisingManager = String.Empty;
                String AccountManager = String.Empty;

                foreach (User user in userList)
                {


                    if (user.DesignationID == Convert.ToInt32(Designation.BIPL_Merchandising_Manager))
                    {
                        if (to.Contains(user.Email.ToString()))
                        {
                            continue;
                        }
                        else
                        {
                            to.Add(user.Email);
                        }
                        salesMangerBipl = user.FullName;
                    }
                    else if (user.DesignationID == Convert.ToInt32(Designation.iKandi_Sales_Manager))
                    {
                        salesMangerIkandi = user.FullName;
                    }
                    else
                    {
                        if (to.Contains(user.Email.ToString()))
                        {
                            continue;
                        }
                        else
                        {
                            to.Add(user.Email);
                        }
                    }
                }

                foreach (User user in userListWithClient)
                {
                    if (user.Designation == Designation.BIPL_Merchandising_AccountManager)
                    {
                        if (AccountManager == string.Empty)
                            AccountManager = user.FullName;
                        else
                            AccountManager = AccountManager + ", " + user.FullName;
                    }
                    else if (user.Designation == Designation.BIPL_Merchandising_Manager)
                    {
                        if (merchandisingManager == string.Empty)
                            merchandisingManager = user.FullName;
                        else
                            merchandisingManager = merchandisingManager + ", " + user.FullName;
                    }

                    if (to.Contains(user.Email.ToString()))
                    {
                        continue;

                    }
                    else
                    {

                        to.Add(user.Email);
                    }
                }

                List<Attachment> attachments = new List<Attachment>();
                foreach (string fileName in Attachments)
                {
                    if (fileName != null && fileName != "" && fileName != "null")
                    {
                        AddAttachments(fileName, attachments, Constants.ORDER_FOLDER_PATH);
                    }
                }

                if (bit == 1)
                {
                    //template.Subject = template.Subject.Replace("[[Subject]]", "Order Form Changes");
                    template.Content = template.Content.Replace("[[Sales-Department]]", "All");
                }
                else
                {
                    template.Subject = template.Subject.Replace("[[SerialNumber]]", SerialNumber);
                    template.Content = template.Content.Replace("[[From]]", this.LoggedInUser.UserData.FullName.ToUpper());
                    template.Content = template.Content.Replace("[[Merchandising Manager]]", merchandisingManager.ToUpper());
                    template.Content = template.Content.Replace("[[Account Manager]]", AccountManager.ToUpper());
                }

                System.Diagnostics.Trace.WriteLine("Processing of Order Form changes/ Purposed Order Form Changes having Subject ----" + template.Subject + "has been started on " + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                template.Content = template.Content.Replace("[[Changes]]", OrderHtml);
                //template.Content += "<br/><br/>Thanks!";
                to.Clear();
                //Abhishek
                SendMailUsingKeyValue("Ikandi.SendEmailForEditOrder", out to);


                //to.Add("bipl_merchandising@boutique.in");
                //to.Add("bipl_logistics@boutique.in");
                //to.Add("ikandi_sales@ikandi.org.uk");
                //to.Add("bipl_sales@boutique.in");
                //to.Add("hitesh@boutique.in");
                // to.Add("sanjeev@boutique.in");

                //END


                return this.SendEmail(fromName, to, null, null, template.Subject.ToUpper(), template.Content, attachments, false, isAsync);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in  FOrder Form changes/ Purposed Order Form Changes on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
               // this.SendErrorEmail(ex.Message + "\n" + ex.StackTrace);
                return false;
            }
        }





        public Boolean SendEmailFitPendingMo(int clientId, Boolean isAsync)
        { // This function is not in use
            try
            {
                EmailTemplate template = this.AdminDataProviderInstance.GetEmailTemplateByType(EmailTemplateType.PENDINGBIPLAGREEMENT);
                List<String> departmentList = new List<String>();
                List<String> designationList = new List<string>();

                departmentList.AddRange(template.DepartmentIDs.Split(new char[] { ',' }));
                designationList.AddRange(template.DesignationIDs.Split(new char[] { ',' }));

                //designationList.Add(Convert.ToInt32(Designation.iKandi_Sales_Manager).ToString());
                //designationList.Add(Convert.ToInt32(Designation.iKandi_Sales_SalesManager).ToString());
                //designationList.Add(Convert.ToInt32(Designation.BIPL_Sales_Advisor).ToString());
                //designationList.Add(Convert.ToInt32(Designation.BIPL_Sales_Manager).ToString());

                // Get User Data
                List<User> userList = GetUserInfo(new List<String>(), designationList, departmentList, 0);

                String fromName = BLLCache.GetConfigurationKeyValue("FROMEMAIL");

                List<String> to = new List<String>();
                String salesMangerBipl = String.Empty;

                foreach (User user in userList)
                {
                    if (to.Contains(user.Email))
                    {
                        continue;
                    }
                    else
                    {
                        to.Add(user.Email);

                        if (user.DesignationID == Convert.ToInt32(Designation.BIPL_Sales_Manager))
                        {
                            salesMangerBipl = user.FullName;
                        }
                    }
                }

                WorkflowInstance objWorkflowInstance = this.WorkflowControllerInstance.GetInstance(clientId, -1, -1);
                if (objWorkflowInstance != null)
                {
                    List<Attachment> attachments = new List<Attachment>();

                    CostingController costingController = new CostingController();
                    // TODO

                    // Get the screenshot of Costing sheet
                    // order.Costing.CostingID
                    List<string> paths = iKandi.Common.WebPageScreenShotGenerator.GetScreenShot(new string[] { "/Internal/OrderProcessing/FitPendingMoEmail.aspx" },
                        Constants.INTERNAL_SITE_BASE_URL + "/public/login.aspx",
                        BLLCache.GetConfigurationKeyValue("BIPLMANAGERUSERNAME"),
                        BLLCache.GetConfigurationKeyValue("BIPLMANAGERUSERPASSWORD"), 1280, 1050, true);

                    if (paths.Count > 0)
                    {
                        AddAttachments(paths[0], attachments, string.Empty);
                    }

                    template.Content = template.Content.Replace("[[SALES MANAGER BIPL]]", salesMangerBipl.ToUpper());

                    System.Diagnostics.Trace.WriteLine("Processing of Pending Bipl agreement email having Subject ----" + template.Subject + "has been started on " + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                    return this.SendEmail(fromName, to, null, null, template.Subject.ToUpper(), template.Content, attachments, true, isAsync);
                }

                return false;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in  Pending Bipl agreement email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                //this.SendErrorEmail(ex.Message + "\n" + ex.StackTrace);
                return false;
            }
        }


        // Tested
        public void SendDailyDesignsCreationEmail(DateTime CreationDate, Boolean isAsync)
        {
            try
            {
                EmailTemplate template = this.AdminDataProviderInstance.GetEmailTemplateByType(EmailTemplateType.DESIGNCREATION);

                List<String> departmentList = new List<String>();
                List<String> designationList = new List<string>();

                departmentList.AddRange(template.DepartmentIDs.Split(new char[] { ',' }));
                designationList.AddRange(template.DesignationIDs.Split(new char[] { ',' }));

                List<String> objUserIdList = new List<String>();
                List<Style> styles = this.StyleDataProviderInstance.GetNewlyCreatedStyles(CreationDate);

                if (styles.Count == 0)
                {
                    System.Diagnostics.Trace.WriteLine("There is no record for Daily Designs Creation Email of the date " + CreationDate.ToString("dd MM yy (ddd)") + ". So Email has not been send on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    return;
                }
                StringBuilder sb = new StringBuilder();

                sb.Append("<TABLE cellpadding=5 border=1>");
                sb.Append("<TR>");
                sb.Append("<TH>DESIGNER</TH>");
                sb.Append("<TH>CLIENT</TH>");
                sb.Append("<TH>DEPT</TH>");
                sb.Append("<TH>STYLE NUMBER</TH>");
                sb.Append("<TH>SAMPLING MERCHANDISER</TH>");
                sb.Append("<TH>SEASON</TH>");
                sb.Append("<TH>STORY</TH>");
                sb.Append("<TH>BUYING HOUSE</TH>");
                sb.Append("</TR>");

                foreach (Style style in styles)
                {
                    if (!objUserIdList.Exists(delegate(string id) { return id == style.DesignerID.ToString(); }))
                    {
                        objUserIdList.Add(style.DesignerID.ToString());
                    }

                    if (!objUserIdList.Exists(delegate(string id) { return id == style.SamplingMerchandisingManagerID.ToString(); }))
                    {
                        objUserIdList.Add(style.SamplingMerchandisingManagerID.ToString());
                    }

                    sb.Append("<TR>");
                    sb.AppendFormat("<TD>{0}</TD>", style.DesignerName.ToUpper());
                    sb.Append("<TD>" + style.Buyer.ToUpper() + "</TD>");
                    sb.Append("<TD>" + style.DepartmentName.ToUpper() + "</TD>");
                    sb.Append("<TD>" + style.StyleNumber.ToUpper() + "</TD>");
                    sb.Append("<TD>" + style.SamplingMerchandisingManagerName.ToUpper() + "</TD>");
                    sb.Append("<TD>" + style.Season.ToUpper() + "</TD>");
                    sb.Append("<TD>" + style.Story.ToUpper() + "</TD>");
                    sb.Append("<TD>" + style.BuyingHouseName.ToUpper() + "</TD>");
                    sb.Append("</TR>");

                }

                sb.Append("</TABLE>");

                //get User Data
                List<User> userList = GetUserInfo(objUserIdList, designationList, departmentList, 0);

                String fromName = BLLCache.GetConfigurationKeyValue("FROMEMAIL");

                List<String> to = new List<String>();
                string designerName = string.Empty;
                foreach (User user in userList)
                {
                    if (to.Contains(user.Email))
                    {
                        continue;
                    }
                    else
                    {
                        //to.Add(user.Email);

                        if (user.DesignationID == Convert.ToInt32(Designation.iKandi_Design_Designers))
                        {
                            if (designerName == string.Empty)
                                designerName = user.FullName;
                            else
                                designerName += ", " + user.FullName;
                        }
                    }
                }
                //Abhishek
                SendMailUsingKeyValue("BIPL.SendDailyDesignsCreationEmail", out to);


                //to.Add("bipl_merchandising@boutique.in");
                //to.Add("hitesh@boutique.in");
                //to.Add("sanjeev@boutique.in");
                //to.Add("surendra@boutique.in");

                //END



                template.Content = template.Content.Replace("[[CONTENT]]", sb.ToString());
                template.Content = template.Content.Replace("[[DESIGNER]]", designerName.ToUpper());
                System.Diagnostics.Trace.WriteLine("Processing of Daily Designs Creation Email having Subject ----" + template.Subject + "has been started on " + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                this.SendEmail(fromName, to, null, null, template.Subject.ToUpper(), template.Content, null, true, isAsync);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in Daily Designs Creation Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                //this.SendErrorEmail(ex.Message + "\n" + ex.StackTrace);

            }

        }


        // Tested
        public Boolean SendContactusEmail(String FullName, String Email, String phone, String msg)
        {
            try
            {
                String fromName = BLLCache.GetConfigurationKeyValue("FROMEMAIL"); //Constants.KEY_FROM_EMAIL

                List<String> to = new List<String>();
                to.Add("info@boutique.in");

                EmailTemplate template = this.AdminDataProviderInstance.GetEmailTemplateByType(EmailTemplateType.CONTACTUSENQUIRYMAIL);

                template.Content = template.Content.Replace("[[FULLNAME]]", FullName);
                template.Content = template.Content.Replace("[[EMAILID]]", Email);
                template.Content = template.Content.Replace("[[PHONE]]", phone);
                template.Content = template.Content.Replace("[[MSG]]", msg);
                System.Diagnostics.Trace.WriteLine("Processing of Forget Password Email having Subject ----" + template.Subject + "has been started on " + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt") + "\n");

                return this.SendEmail(fromName, to, null, null, template.Subject, template.Content, null, false, false);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in  Forget Password Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                System.Diagnostics.Trace.WriteLine("\n");
                //this.SendErrorEmail(ex.Message + "\n" + ex.StackTrace);
                return false;
            }
        }

        public void SendMondayCompanyReports(Boolean isAsync)
        {
            try
            {
                EmailTemplate template = this.AdminDataProviderInstance.GetEmailTemplateByType(EmailTemplateType.MONDAYCOMPANYREPORTS);

                List<String> departmentList = new List<String>();
                List<String> designationList = new List<string>();

                departmentList.AddRange(template.DepartmentIDs.Split(new char[] { ',' }));
                designationList.AddRange(template.DesignationIDs.Split(new char[] { ',' }));

                // MERCHANDISING, FABRIC, ACCESSORIES, PRODUCTION, LOGISTICS                 
                //objDepartmentIdList.Add(Convert.ToInt32(Group.BIPL_Accessory).ToString());
                //objDepartmentIdList.Add(Convert.ToInt32(Group.BIPL_Fabrics).ToString());
                //objDepartmentIdList.Add(Convert.ToInt32(Group.BIPL_Production).ToString());
                //objDepartmentIdList.Add(Convert.ToInt32(Group.BIPL_Logistics).ToString());
                //objDepartmentIdList.Add(Convert.ToInt32(Group.BIPL_Merchandising).ToString());

                String fromName = BLLCache.GetConfigurationKeyValue("FROMEMAIL");

                //get User Data
                List<User> userList = GetUserInfo(new List<String>(), designationList, departmentList, 0);

                List<String> to = new List<String>();

                foreach (User user in userList)
                {
                    if (to.Contains(user.Email))
                    {
                        continue;
                    }
                    else
                    {
                        // to.Add(user.Email);
                    }
                }
                // edit by surendra/hitesh
                //Abhishek
                SendMailUsingKeyValue("BIPL.SendMondayCompanyReports", out to);


                //to.Add("bipl_ieupdate@boutique.in");
                //to.Add("sanjeev@boutique.in");
                //to.Add("hitesh@boutique.in");
                //END


                System.Diagnostics.Trace.WriteLine("Processing of Monday Comany Reports Email having Subject ----" + template.Subject + "has been started on " + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                this.SendEmail(fromName, to, null, null, template.Subject.ToUpper(), template.Content, null, false, true);

            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in  Monday Comany Reports Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
               // this.SendErrorEmail(ex.Message + "\n" + ex.StackTrace);
            }
        }

        public bool SendStyleDeletedEmail(Style objStyle, Boolean isAsync)
        {
            try
            {
                EmailTemplate template = this.AdminDataProviderInstance.GetEmailTemplateByType(EmailTemplateType.STYLEDELETED);

                List<String> departmentList = new List<String>();
                List<String> designationList = new List<string>();

                departmentList.AddRange(template.DepartmentIDs.Split(new char[] { ',' }));
                designationList.AddRange(template.DesignationIDs.Split(new char[] { ',' }));

                List<String> objUserIdList = new List<String>();
                objUserIdList.Add(objStyle.DesignerID.ToString());
                objUserIdList.Add(objStyle.SamplingMerchandisingManagerID.ToString());

                //get User Data
                List<User> userList = GetUserInfo(objUserIdList, designationList, departmentList, 0);

                String fromName = BLLCache.GetConfigurationKeyValue("FROMEMAIL");

                List<String> to = new List<String>();
                foreach (User user in userList)
                {
                    if (to.Contains(user.Email))
                    {
                        continue;
                    }
                    else
                    {
                        to.Add(user.Email);

                        if (objStyle.DesignerID == user.UserID)
                        {
                            objStyle.DesignerName = user.FullName;
                        }
                        else if (objStyle.SamplingMerchandisingManagerID == user.UserID)
                        {
                            objStyle.SamplingMerchandisingManagerName = user.FullName;
                        }
                    }
                }

                List<String> cc = new List<String>();
                cc.Add(LoggedInUser.UserData.Email);


                template.Subject = template.Subject.Replace("[[STYLE NUMBER]]", objStyle.StyleNumber.ToUpper());
                template.Content = template.Content.Replace("[[SAMPLING MERCHANDISER]]", objStyle.SamplingMerchandisingManagerName.ToUpper());
                template.Content = template.Content.Replace("[[DESIGNER]]", objStyle.DesignerName.ToUpper());

                System.Diagnostics.Trace.WriteLine("Processing of Style Deleted Email having Subject ----" + template.Subject + "has been started on " + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                return this.SendEmail(fromName, to, cc, null, template.Subject.ToUpper(), template.Content, null, true, isAsync);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in Style Deleted Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                //this.SendErrorEmail(ex.Message + "\n" + ex.StackTrace);
                return false;
            }

        }

        // Tested
        public void SendCostedStyles(DateTime CostingDate, Boolean isAsync)
        {
            try
            {
                DataTable dt = this.CostingDataProviderInstance.GetCostedStyles(CostingDate);

                if (dt.Rows.Count == 0)
                {
                    System.Diagnostics.Trace.WriteLine("There is no record in Costed Styles for the date of" + CostingDate.ToString("dd MM yy (ddd)") + ". So Email has not been send on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    return;
                }

                StringBuilder sb = new StringBuilder();

                sb.Append("<TABLE border=1 cellpadding=5>");
                sb.Append("<TR>");
                sb.Append("<TH>CLIENT</TH>");
                sb.Append("<TH>STYLE #</TH>");
                sb.Append("<TH>IMAGE</TH>");
                sb.Append("</TR>");

                foreach (DataRow row in dt.Rows)
                {
                    string imageUrl = ((row["SampleImageURL1"] == DBNull.Value || row["SampleImageURL1"] == null) ? string.Empty : row["SampleImageURL1"].ToString());

                    sb.Append("<TR>");
                    sb.Append("<TD>" + ((row["CompanyName"] == DBNull.Value || row["CompanyName"] == null) ? string.Empty : row["CompanyName"].ToString().ToUpper()) + "</TD>");
                    sb.Append("<TD>" + ((row["StyleNumber"] == DBNull.Value || row["StyleNumber"] == null) ? string.Empty : row["StyleNumber"].ToString().ToUpper()) + "</TD>");
                    sb.Append("<TD><IMG SRC='" + Constants.SITE_BASE_URL + "/uploads/style/thumb-" + imageUrl + "'  /></TD>");
                    sb.Append("</TR>");
                }

                sb.Append("</TABLE>");

                EmailTemplate template = this.AdminDataProviderInstance.GetEmailTemplateByType(EmailTemplateType.STYLESCOSTEDTODAY);

                List<String> departmentList = new List<String>();
                List<String> designationList = new List<string>();

                departmentList.AddRange(template.DepartmentIDs.Split(new char[] { ',' }));
                designationList.AddRange(template.DesignationIDs.Split(new char[] { ',' }));

                // BIPL SALES, MERCHANDISING, ikandi sales          
                //objDesignationList.Add(Convert.ToInt32(Designation.BIPL_Merchandising_Manager).ToString());
                //objDesignationList.Add(Convert.ToInt32(Designation.BIPL_Merchandising_AccountManager).ToString());
                //objDesignationList.Add(Convert.ToInt32(Designation.BIPL_Merchandising_FitMerchant).ToString());
                //objDesignationList.Add(Convert.ToInt32(Designation.BIPL_Merchandising_SamplingMerchant).ToString());
                //objDesignationList.Add(Convert.ToInt32(Designation.BIPL_Sales_Manager).ToString());
                //objDesignationList.Add(Convert.ToInt32(Designation.BIPL_Sales_Advisor).ToString());
                //objDesignationList.Add(Convert.ToInt32(Designation.iKandi_Sales_Manager).ToString());
                //objDesignationList.Add(Convert.ToInt32(Designation.iKandi_Sales_SalesManager).ToString());

                //get User Data
                List<User> userList = GetUserInfo(new List<String>(), designationList, departmentList, 0);

                String fromName = BLLCache.GetConfigurationKeyValue("FROMEMAIL");

                List<String> to = new List<String>();
                String ikandiSalesManager = String.Empty;
                String biplSalesManager = String.Empty;
                foreach (User user in userList)
                {
                    if (to.Contains(user.Email))
                    {
                        continue;
                    }
                    else
                    {
                        to.Add(user.Email);

                        if (user.DesignationID == Convert.ToInt32(Designation.iKandi_Sales_Manager))
                        {
                            if (ikandiSalesManager == string.Empty)
                                ikandiSalesManager = user.FullName;
                            else
                                ikandiSalesManager += ", " + user.FullName;
                        }

                        if (user.DesignationID == Convert.ToInt32(Designation.BIPL_Sales_Manager))
                        {
                            if (biplSalesManager == string.Empty)
                                biplSalesManager = user.FullName;
                            else
                                biplSalesManager += ", " + user.FullName;
                        }
                    }
                }

                to.Clear();
                //Abhishek
                SendMailUsingKeyValue("BIPL.SendCostedStyles", out to);


                //to.Add("bipl_merchandising@boutique.in");
                //to.Add("bipl_sales@boutique.in");

                //END




                template.Content = template.Content.Replace("[[CONTENT]]", sb.ToString());
                template.Content = template.Content.Replace("[[IKANDI SALES MANAGER]]", ikandiSalesManager.ToUpper());
                template.Content = template.Content.Replace("[[BIPL SALES MANAGER]]", biplSalesManager.ToUpper());

                System.Diagnostics.Trace.WriteLine("Processing of Costed Styles Email having Subject ----" + template.Subject + "has been started on " + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                this.SendEmail(fromName, to, null, null, template.Subject.ToUpper(), template.Content, null, false, isAsync);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in  Costed Styles Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));

               // this.SendErrorEmail(ex.Message + "\n" + ex.StackTrace);

            }
        }

        // Tested
        public void SendFITSCommentsUploaded(DateTime CommentUploadedDate, Boolean isAsync)
        {
            try
            {
                bool bIkandi = false;
                bool bNonIkandi = false;
                StringBuilder sb = new StringBuilder();
                StringBuilder sbq = new StringBuilder();

                List<String> to = new List<String>();
                bIkandi = this.FITsDataProviderInstance.GetFITsCommentsUploaded_CheckIkandi(CommentUploadedDate, 1);
                bNonIkandi = this.FITsDataProviderInstance.GetFITsCommentsUploaded_CheckIkandi(CommentUploadedDate, 2);
                if (bIkandi == true)
                {
                    DataSet ds = this.FITsDataProviderInstance.GetFITsCommentsUploaded(CommentUploadedDate, 1);
                    DataTable dt = ds.Tables[0];

                    if (dt.Rows.Count != 0)
                        sb = FitsUploaded(ds);

                }
                if (bNonIkandi == true)
                {
                    DataSet ds = this.FITsDataProviderInstance.GetFITsCommentsUploaded(CommentUploadedDate, 2);
                    DataTable dt = ds.Tables[0];
                    if (dt.Rows.Count != 0)
                        sbq = FitsUploaded(ds);
                }



                // DataSet ds = this.FITsDataProviderInstance.GetFITsCommentsUploaded(CommentUploadedDate);

                //if (ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
                //{
                //    System.Diagnostics.Trace.WriteLine("There is no record in FITS Comments Uploaded Email for the date of" + CommentUploadedDate.ToString("dd MM yy (ddd)") + ". So Email has not been send on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                //    return;
                //}


                EmailTemplate template = this.AdminDataProviderInstance.GetEmailTemplateByType(EmailTemplateType.COMMENTSUPLOADED);
                EmailTemplate templateNonIkandi = this.AdminDataProviderInstance.GetEmailTemplateByType(EmailTemplateType.COMMENTSUPLOADED);

                List<String> departmentList = new List<String>();
                List<String> designationList = new List<string>();

                string WithClientDesignationIDs;
                string WithNoClientDesignationIDs;

                GetClientAssociatedDesignationID(template.DesignationIDs, out  WithClientDesignationIDs, out  WithNoClientDesignationIDs);

                departmentList.AddRange(template.DepartmentIDs.Split(new char[] { ',' }));
                designationList.AddRange(WithNoClientDesignationIDs.Split(new char[] { ',' }));






                // A/c manager, Merch. Mgrs, Fit Merchant, BIPL Sales Mgrs, ikandi Technical Team, ikandi sales Team.

                //objDesignationList.Add(Convert.ToInt32(Designation.BIPL_Merchandising_Manager).ToString());
                //objDesignationList.Add(Convert.ToInt32(Designation.BIPL_Sales_Manager).ToString());
                //objDesignationList.Add(Convert.ToInt32(Designation.iKandi_Sales_Manager).ToString());
                //objDesignationList.Add(Convert.ToInt32(Designation.iKandi_Technical_Manager).ToString());


                //get User Data
                List<User> userList = GetUserInfo(new List<String>(), designationList, departmentList, 0);

                String fromName = BLLCache.GetConfigurationKeyValue("FROMEMAIL");


                String ikandiTechnicalManager = String.Empty;

                //foreach (User user in userList)
                //{
                //    if (to.Contains(user.Email))
                //    {
                //        continue;
                //    }
                //    else
                //    {
                //        to.Add(user.Email);

                //        if (user.DesignationID == Convert.ToInt32(Designation.iKandi_Technical_Manager))
                //        {
                //            if (ikandiTechnicalManager == string.Empty)
                //                ikandiTechnicalManager = user.FullName;
                //            else
                //                ikandiTechnicalManager += ", " + user.FullName;
                //        }

                //    }
                //}
                if (bIkandi == true)
                {
                    template.Content = template.Content.Replace("[[STYLES_TABLE]]", sb.ToString());
                    //Abhishek
                    SendMailUsingKeyValue("Ikandi.SendFITSCommentsUploaded", out to);


                    //to.Add("bipl_merchandising@boutique.in");
                    //to.Add("ikandi_sales@ikandi.org.uk");
                    //to.Add("ikandi_technical@ikandi.org.uk");
                    //to.Add("bipl_qateam@boutique.in");
                    //to.Add("sanjeev@boutique.in");
                    //to.Add("hitesh@boutique.in");

                    //END

                    this.SendEmail(fromName, to, null, null, template.Subject.ToUpper(), template.Content, null, false, isAsync);
                    to.Clear();
                }
                if (bNonIkandi == true)
                {
                    templateNonIkandi.Content = templateNonIkandi.Content.Replace("[[STYLES_TABLE]]", sbq.ToString());
                    //Abhishek
                    SendMailUsingKeyValue("BIPL.SendFITSCommentsUploaded", out to);


                    //to.Add("bipl_merchandising@boutique.in");
                    //to.Add("bipl_qateam@boutique.in");
                    //to.Add("sanjeev@boutique.in");
                    //to.Add("hitesh@boutique.in");


                    //END
                    this.SendEmail(fromName, to, null, null, templateNonIkandi.Subject.ToUpper(), templateNonIkandi.Content, null, false, isAsync);
                    to.Clear();
                }

                //template.Content = template.Content.Replace("[[IKANDI_TECHNICAL_MANAGER]]", ikandiTechnicalManager.ToUpper());
                //System.Diagnostics.Trace.WriteLine("Processing of FITS Comments Uploaded Email having Subject ----" + template.Subject + "has been started on " + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                //if (template.Content.Length > 400)
                //{
                //    to.Add("bipl_merchandising@boutique.in");
                //    to.Add("ikandi_sales@ikandi.org.uk");
                //    to.Add("ikandi_technical@ikandi.org.uk");
                //    to.Add("bipl_qateam@boutique.in");
                //    to.Add("sanjeev@boutique.in");
                //    to.Add("hitesh@boutique.in");
                //    this.SendEmail(fromName, to, null, null, template.Subject.ToUpper(), template.Content, null, false, isAsync);
                //    to.Clear();
                //}


                // for btq only

                //    EmailTemplate templatebqt = this.AdminDataProviderInstance.GetEmailTemplateByType(EmailTemplateType.COMMENTSUPLOADEDBTQ);

                //    List<String> departmentListbtq = new List<String>();
                //    List<String> designationListbtq = new List<string>();
                //    List<String> toqtq = new List<String>();
                //    string WithClientDesignationIDsbtq;
                //    string WithNoClientDesignationIDsbtq;

                //    GetClientAssociatedDesignationID(templatebqt.DesignationIDs, out  WithClientDesignationIDsbtq, out  WithNoClientDesignationIDsbtq);


                //    WithNoClientDesignationIDsbtq = WithNoClientDesignationIDsbtq + "," + WithClientDesignationIDsbtq;


                //    departmentListbtq.AddRange(templatebqt.DepartmentIDs.Split(new char[] { ',' }));
                //    designationListbtq.AddRange(WithNoClientDesignationIDsbtq.Split(new char[] { ',' }));


                //    StringBuilder sbbtq = new StringBuilder();

                //    sbbtq.Append("<TABLE border=1 cellpadding=5>");
                //    sbbtq.Append("<TR>");
                //    sbbtq.Append("<TH>BUYER</TH>");
                //    sbbtq.Append("<TH>DEPT.</TH>");
                //    sbbtq.Append("<TH>ORDER DATE</TH>");
                //    sbbtq.Append("<TH>SERIAL NUMBER</TH>");
                //    sbbtq.Append("<TH>STYLE</TH>");
                //    sbbtq.Append("<TH>STC TGT</TH>");
                //    sbbtq.Append("<TH>COMMENTS SENT FOR</TH>");
                //    sbbtq.Append("</TR>");

                //    DataTable dtbtq = ds.Tables[0];

                //    foreach (DataRow row in dtbtq.Rows)
                //    {


                //        if (row["clientid"] != DBNull.Value && Convert.ToString(row["clientid"]) != string.Empty && Convert.ToInt32(row["clientid"]) > 0)
                //        {
                //            int clientId = Convert.ToInt32(row["clientid"]);

                //            List<String> objDesignationBasedOnClient = new List<string>();
                //            objDesignationBasedOnClient.AddRange(WithClientDesignationIDsbtq.Split(new char[] { ',' }));

                //            //objDesignationBasedOnClient.Add(Convert.ToInt32(Designation.BIPL_Merchandising_AccountManager).ToString());
                //            //objDesignationBasedOnClient.Add(Convert.ToInt32(Designation.BIPL_Merchandising_FitMerchant).ToString());
                //            //objDesignationBasedOnClient.Add(Convert.ToInt32(Designation.iKandi_Sales_SalesManager).ToString());
                //            //objDesignationBasedOnClient.Add(Convert.ToInt32(Designation.iKandi_Technical_Technologist).ToString());

                //            List<User> userListWithClient = GetUserInfo(new List<String>(), objDesignationBasedOnClient, new List<String>(), clientId);
                //            //foreach (User user in userListWithClient)
                //            //{
                //            //    if (toqtq.Contains(user.Email))
                //            //    {
                //            //        continue;
                //            //    }
                //            //    else
                //            //    {
                //            //        toqtq.Add(user.Email);
                //            //    }
                //            //}

                //        }

                //        string imageUrl = ((row["SampleImageURL1"] == DBNull.Value || row["SampleImageURL1"] == null) ? string.Empty : row["SampleImageURL1"].ToString());
                //        if (row["CompanyName"].ToString().ToUpper() != "XnY.in".ToUpper() && row["CompanyName"].ToString().ToUpper() != "dash".ToUpper() && row["CompanyName"].ToString().ToUpper() != "nougat".ToUpper() && row["CompanyName"].ToString().ToUpper() != "DKNY".ToUpper() && row["CompanyName"].ToString().ToUpper() != "american eagle".ToUpper() && row["CompanyName"].ToString().ToUpper() != "FORC. CO".ToUpper() && row["CompanyName"].ToString().ToUpper() != "DMC".ToUpper() && row["CompanyName"].ToString().ToUpper() != "BELk".ToUpper() && row["CompanyName"].ToString().ToUpper() != "Camaieu".ToUpper() && row["CompanyName"].ToString().ToUpper() != "foshini".ToUpper() && row["CompanyName"].ToString().ToUpper() != "Eminence".ToUpper() && row["CompanyName"].ToString().ToUpper() != "Sfera".ToUpper() && row["CompanyName"].ToString().ToUpper() != "matalan".ToUpper() && row["CompanyName"].ToString().ToUpper() != "ernstings family".ToUpper() && row["CompanyName"].ToString().ToUpper() != "acc".ToUpper() && row["CompanyName"].ToString().ToUpper() != "Bonprix".ToUpper())
                //        {
                //            continue;
                //        }

                //        sbbtq.Append("<TR>");
                //        sbbtq.Append("<TD>" + ((row["CompanyName"] == DBNull.Value || row["CompanyName"] == null) ? string.Empty : row["CompanyName"].ToString().ToUpper()) + "</TD>");
                //        sbbtq.Append("<TD>" + ((row["DepartmentName"] == DBNull.Value || row["DepartmentName"] == null) ? string.Empty : row["DepartmentName"].ToString().ToUpper()) + "</TD>");
                //        sbbtq.Append("<TD>" + ((row["OrderDate"] == DBNull.Value || row["OrderDate"] == null) ? string.Empty : Convert.ToDateTime(row["OrderDate"]).ToString("dd MMM yy (ddd)")) + "</TD>");
                //        sbbtq.Append("<TD>" + ((row["SerialNumber"] == DBNull.Value || row["SerialNumber"] == null) ? string.Empty : row["SerialNumber"].ToString().ToUpper()) + "</TD>");
                //        sbbtq.Append("<TD>" + ((row["StyleNumber"] == DBNull.Value || row["StyleNumber"] == null) ? string.Empty : row["StyleNumber"].ToString().ToUpper()));
                //        sbbtq.Append("<div><IMG SRC='" + Constants.SITE_BASE_URL + "/uploads/style/thumb-" + imageUrl + "'  /></div></TD>");
                //        sbbtq.Append("<TD>" + ((row["STCTGT"] == DBNull.Value || row["STCTGT"] == null) ? string.Empty : Convert.ToDateTime(row["STCTGT"]).ToString("dd MMM yy (ddd)")) + "</TD>");
                //        sbbtq.Append("<TD>" + ((row["CommentsSentFor"] == DBNull.Value || row["CommentsSentFor"] == null) ? string.Empty : row["CommentsSentFor"].ToString().ToUpper()) + "</TD>");
                //        sbbtq.Append("</TR>");


                //    }

                //    sbbtq.Append("</TABLE>");


                //    // A/c manager, Merch. Mgrs, Fit Merchant, BIPL Sales Mgrs, ikandi Technical Team, ikandi sales Team.

                //    //objDesignationList.Add(Convert.ToInt32(Designation.BIPL_Merchandising_Manager).ToString());
                //    //objDesignationList.Add(Convert.ToInt32(Designation.BIPL_Sales_Manager).ToString());
                //    //objDesignationList.Add(Convert.ToInt32(Designation.iKandi_Sales_Manager).ToString());
                //    //objDesignationList.Add(Convert.ToInt32(Designation.iKandi_Technical_Manager).ToString());


                //    //get User Data
                //    List<User> userListbtq = GetUserInfo(new List<String>(), designationListbtq, departmentListbtq, 0);

                //    String fromNamebtq = BLLCache.GetConfigurationKeyValue("FROMEMAIL");


                //    String ikandiTechnicalManagerbtq = String.Empty;

                //    //foreach (User user in userListbtq)
                //    //{
                //    //    if (toqtq.Contains(user.Email))
                //    //    {
                //    //        continue;
                //    //    }
                //    //    else
                //    //    {
                //    //        toqtq.Add(user.Email);

                //    //        if (user.DesignationID == Convert.ToInt32(Designation.iKandi_Technical_Manager))
                //    //        {
                //    //            if (ikandiTechnicalManager == string.Empty)
                //    //                ikandiTechnicalManager = user.FullName;
                //    //            else
                //    //                ikandiTechnicalManager += ", " + user.FullName;
                //    //        }

                //    //    }
                //    //}

                //    templatebqt.Content = templatebqt.Content.Replace("[[STYLES_TABLE]]", sbbtq.ToString());
                //    templatebqt.Content = templatebqt.Content.Replace("[[IKANDI_TECHNICAL_MANAGER]]", ikandiTechnicalManager.ToUpper());
                //    System.Diagnostics.Trace.WriteLine("Processing of FITS Comments Uploaded Email having Subject ----" + templatebqt.Subject + "has been started on " + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));


                //    if (templatebqt.Content.Length > 400)
                //    {
                //        to.Add("bipl_merchandising@boutique.in");
                //        to.Add("ikandi_sales@ikandi.org.uk");
                //        to.Add("ikandi_technical@ikandi.org.uk");
                //        to.Add("bipl_qateam@boutique.in");
                //        to.Add("sanjeev@boutique.in");
                //        to.Add("hitesh@boutique.in");
                //        this.SendEmail(fromName, to, null, null, templatebqt.Subject.ToUpper(), templatebqt.Content, null, false, isAsync);
                //    }






            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in FITS Comments Uploaded Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                //this.SendErrorEmail(ex.Message + "\n" + ex.StackTrace);

            }
        }


        // Tested
     

        string merchandisingManagerBIPL = string.Empty;



        // Tested
       

        // Tested
        public void SendQAPendingToday()
        {

            try
            {
                EmailTemplate template = this.AdminDataProviderInstance.GetEmailTemplateByType(EmailTemplateType.QAPENDING);

                List<String> departmentList = new List<String>();
                List<String> designationList = new List<string>();

                departmentList.AddRange(template.DepartmentIDs.Split(new char[] { ',' }));
                designationList.AddRange(template.DesignationIDs.Split(new char[] { ',' }));

                //QA, PRODUCTION, BIPL SALES MANAGER
                //objDepartmentIdList.Add(Convert.ToInt32(Group.BIPL_Production).ToString());
                //objDepartmentIdList.Add(Convert.ToInt32(Group.BIPL_QA).ToString());

                //designationList.Add(((int)Designation.BIPL_QA_Manager).ToString());
                //designationList.Add(((int)Designation.BIPL_Sales_Manager).ToString());

                //get User Data
                List<User> userList = GetUserInfo(new List<String>(), designationList, departmentList, 0);

                String fromName = BLLCache.GetConfigurationKeyValue("FROMEMAIL");

                List<String> to = new List<String>();
                string qAManager = string.Empty;

                //foreach (User user in userList)
                //{
                //    if (to.Contains(user.Email))
                //    {
                //        continue;
                //    }
                //    else
                //    {
                //        //to.Add(user.Email);

                //        if (user.Designation == Designation.BIPL_QA_Manager)
                //        {
                //            if (qAManager == string.Empty)
                //                qAManager = user.FullName;
                //            else
                //                qAManager = qAManager + ", " + user.FullName;
                //        }
                //    }
                //}
                // edit by surendra/hitesh
                //Abhishek
                SendMailUsingKeyValue("BIPL.SendQAPendingToday", out to);


                //to.Add("bipl_ieupdate@boutique.in");
                //to.Add("bipl_qateam@boutique.in");
                //to.Add("hitesh@boutique.in");
                //to.Add("sanjeev@boutique.in");
                //END
                template.Content = template.Content.Replace("[[QA MANAGER]]", qAManager.ToUpper());

                PDFController controller = new PDFController();

                if (!Directory.Exists(Constants.TEMP_FOLDER_PATH))
                    Directory.CreateDirectory(Constants.TEMP_FOLDER_PATH);

                string pdfFilePath = Path.Combine(Constants.TEMP_FOLDER_PATH, "QA Form Pending Report -" + DateTime.Today.ToString("dd MMM yyy") + ".pdf");

                bool success = controller.GenerateDailyQAPandingReport(pdfFilePath);

                if (!success)
                {
                    System.Diagnostics.Trace.WriteLine("There is no record in QA Pending Today Email for today. So Email has not been send on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    return;
                }

                List<Attachment> atts = new List<Attachment>();
                atts.Add(new Attachment(pdfFilePath));

                System.Diagnostics.Trace.WriteLine("Processing of QA Pending Today Email having Subject ----" + template.Subject + "has been started on " + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                this.SendEmail(fromName, to, null, null, template.Subject.ToUpper(), template.Content, atts, false, true);

            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in  QA Pending Today Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));

               // this.SendErrorEmail(ex.Message + "\n" + ex.StackTrace);
            }
        }

        // Tested
      

        // Tested
    

       
  

        public void SendCancelledOrderEmail(int OrderDetailID, int CancelledQuantity, string Remarks)
        {
            try
            {
                EmailTemplate template = this.AdminDataProviderInstance.GetEmailTemplateByType(EmailTemplateType.CANCELLEDORDER);

                List<String> departmentList = new List<String>();
                List<String> designationList = new List<string>();

                departmentList.AddRange(template.DepartmentIDs.Split(new char[] { ',' }));
                designationList.AddRange(template.DesignationIDs.Split(new char[] { ',' }));

                iKandi.Common.Order order = new iKandi.Common.Order();
                OrderController objOrder = new OrderController();
                order = objOrder.GetOrderByOrderDetailId(OrderDetailID);

                //MERCHANDISING TEAM (CURRENT ACCOUNT), BIPL SALES, FABRIC, ACCESSORY, PRODUCTION, LOGISTICS.

                //objDepartmentList.Add(Convert.ToInt32(Group.BIPL_Sales).ToString());
                //objDepartmentList.Add(Convert.ToInt32(Group.BIPL_Fabrics).ToString());
                //objDepartmentList.Add(Convert.ToInt32(Group.BIPL_Accessory).ToString());
                //objDepartmentList.Add(Convert.ToInt32(Group.BIPL_Production).ToString());
                //objDepartmentList.Add(Convert.ToInt32(Group.BIPL_Logistics).ToString());
                //designationList.Add(((int)Designation.BIPL_Merchandising_AccountManager).ToString());
                //designationList.Add(((int)Designation.BIPL_Merchandising_FitMerchant).ToString());
                //designationList.Add(((int)Designation.BIPL_Merchandising_Manager).ToString());
                //designationList.Add(((int)Designation.BIPL_Merchandising_SamplingMerchant).ToString());

                string accountManager = string.Empty;

                //get User Data
                List<User> userListWithClient = GetUserInfo(new List<String>(), designationList, departmentList, order.ClientID);

                String fromName = BLLCache.GetConfigurationKeyValue("FROMEMAIL");

                List<String> to = new List<String>();

                foreach (User user in userListWithClient)
                {
                    if (to.Contains(user.Email))
                    {
                        continue;
                    }
                    else
                    {
                        to.Add(user.Email);
                        if (user.Designation == Designation.BIPL_Merchandising_AccountManager)
                        {
                            if (accountManager == string.Empty)
                            {
                                accountManager = user.FullName;

                            }
                            else
                            {
                                accountManager = accountManager + ", " + user.FullName;

                            }
                        }
                    }
                }
                // edit by surendra/hitesh
                //Abhishek
                SendMailUsingKeyValue("BIPL.SendCancelledOrderEmail", out to);


                //to.Add("bipl_ieupdate@boutique.in");
                //to.Add("sanjeev@boutique.in");
                //to.Add("hitesh@boutique.in");
                //END

                template.Subject = template.Subject.Replace("[[IKANDI SERIAL]]", order.SerialNumber.ToString().ToUpper());
                template.Subject = template.Subject.Replace("[[STYLE NUMBER]]", order.Style.StyleNumber.ToString().ToUpper());
                template.Subject = template.Subject.Replace("[[BUYER]]", order.Style.client.CompanyName.ToString().ToUpper());
                template.Subject = template.Subject.Replace("[[DEPARTMENT]]", order.Style.cdept.Name.ToString().ToUpper());

                template.Content = template.Content.Replace("[[IKANDI SALES MANAGER]]", LoggedInUser.UserData.FullName.ToUpper());
                template.Content = template.Content.Replace("[[ACCOUNT MANAGER]]", accountManager.ToUpper());
                template.Subject = template.Subject.Replace("[[QTY]]", CancelledQuantity.ToString("N0"));
                template.Content = template.Content.Replace("[[COMMENTS]]", Remarks.ToString().ToUpper());
                System.Diagnostics.Trace.WriteLine("Processing of Cancelled Order Email having Subject ----" + template.Subject + "has been started on " + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                this.SendEmail(fromName, to, null, null, template.Subject.ToUpper(), template.Content, null, false, true);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in Cancelled Order Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));

               // this.SendErrorEmail(ex.Message + "\n" + ex.StackTrace);

            }

        }





        public void SendCancelledOrderEmail_NoLiability(int OrderDetailID, int CancelledQuantity, string Remarks)
        {
            try
            {
                EmailTemplate template = this.AdminDataProviderInstance.GetEmailTemplateByType(EmailTemplateType.CANCELLEDORDERWITHOUTLIABILITY);

                List<String> departmentList = new List<String>();
                List<String> designationList = new List<string>();

                departmentList.AddRange(template.DepartmentIDs.Split(new char[] { ',' }));
                designationList.AddRange(template.DesignationIDs.Split(new char[] { ',' }));

                iKandi.Common.Order order = new iKandi.Common.Order();
                OrderController objOrder = new OrderController();
                order = objOrder.GetOrderByOrderDetailId(OrderDetailID);

                string accountManager = string.Empty;

                //get User Data
                List<User> userListWithClient = GetUserInfo(new List<String>(), designationList, departmentList, order.ClientID);

                String fromName = BLLCache.GetConfigurationKeyValue("FROMEMAIL");

                List<String> to = new List<String>();

                foreach (User user in userListWithClient)
                {
                    if (to.Contains(user.Email))
                    {
                        continue;
                    }
                    else
                    {
                        to.Add(user.Email);
                        if (user.Designation == Designation.BIPL_Merchandising_AccountManager)
                        {
                            if (accountManager == string.Empty)
                            {
                                accountManager = user.FullName;

                            }
                            else
                            {
                                accountManager = accountManager + ", " + user.FullName;

                            }
                        }
                    }
                }
                // edit by surendra/hitesh
                to.Clear();
                to.Add("bipl_ieupdate");

                template.Subject = template.Subject.Replace("[[IKANDI SERIAL]]", order.SerialNumber.ToString().ToUpper());
                template.Subject = template.Subject.Replace("[[STYLE NUMBER]]", order.Style.StyleNumber.ToString().ToUpper());
                template.Subject = template.Subject.Replace("[[BUYER]]", order.Style.client.CompanyName.ToString().ToUpper());
                template.Subject = template.Subject.Replace("[[DEPARTMENT]]", order.Style.cdept.Name.ToString().ToUpper());

                template.Content = template.Content.Replace("[[IKANDI SALES MANAGER]]", LoggedInUser.UserData.FullName.ToUpper());
                template.Content = template.Content.Replace("[[ACCOUNT MANAGER]]", accountManager.ToUpper());
                template.Subject = template.Subject.Replace("[[QTY]]", CancelledQuantity.ToString("N0"));
                template.Content = template.Content.Replace("[[COMMENTS]]", Remarks.ToString().ToUpper());
                System.Diagnostics.Trace.WriteLine("Processing of Cancelled Order Email having Subject ----" + template.Subject + "has been started on " + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                this.SendEmail(fromName, to, null, null, template.Subject.ToUpper(), template.Content, null, false, true);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in Cancelled Order Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));

              //  this.SendErrorEmail(ex.Message + "\n" + ex.StackTrace);

            }

        }

        public void SendOnHoldOrderEmail(int OrderDetailID, string Remarks, int status /* 1=hold & 2= unhold */)
        {
            try
            {
                EmailTemplate template = this.AdminDataProviderInstance.GetEmailTemplateByType(EmailTemplateType.ONHOLD);

                List<String> departmentList = new List<String>();
                List<String> designationList = new List<string>();

                departmentList.AddRange(template.DepartmentIDs.Split(new char[] { ',' }));
                designationList.AddRange(template.DesignationIDs.Split(new char[] { ',' }));

                iKandi.Common.Order order = new iKandi.Common.Order();
                OrderController objOrder = new OrderController();
                order = objOrder.GetOrderByOrderDetailId(OrderDetailID);

                //MERCHANDISING TEAM (CURRENT ACCOUNT), BIPL SALES, FABRIC, ACCESSORY, PRODUCTION, LOGISTICS.
                //objDepartmentList.Add(Convert.ToInt32(Group.BIPL_Sales).ToString());
                //objDepartmentList.Add(Convert.ToInt32(Group.BIPL_Fabrics).ToString());
                //objDepartmentList.Add(Convert.ToInt32(Group.BIPL_Accessory).ToString());
                //objDepartmentList.Add(Convert.ToInt32(Group.BIPL_Production).ToString());
                //objDepartmentList.Add(Convert.ToInt32(Group.BIPL_Logistics).ToString());
                //designationList.Add(((int)Designation.BIPL_Merchandising_AccountManager).ToString());
                //designationList.Add(((int)Designation.BIPL_Merchandising_FitMerchant).ToString());
                //designationList.Add(((int)Designation.BIPL_Merchandising_Manager).ToString());
                //designationList.Add(((int)Designation.BIPL_Merchandising_SamplingMerchant).ToString());


                string accountManager = string.Empty;


                //get User Data
                List<User> userListWithClient = GetUserInfo(new List<String>(), designationList, departmentList, order.ClientID);

                String fromName = BLLCache.GetConfigurationKeyValue("FROMEMAIL");

                List<String> to = new List<String>();

                foreach (User user in userListWithClient)
                {
                    if (to.Contains(user.Email))
                    {
                        continue;
                    }
                    else
                    {

                        to.Add(user.Email);

                        if (user.Designation == Designation.BIPL_Merchandising_AccountManager)
                        {
                            if (accountManager == string.Empty)
                            {
                                accountManager = user.FullName;

                            }
                            else
                            {
                                accountManager = accountManager + ", " + user.FullName;

                            }
                        }
                    }
                }

                template.Subject = template.Subject.Replace("[[IKANDI SERIAL]]", order.SerialNumber.ToString().ToUpper());
                template.Subject = template.Subject.Replace("[[STYLE NUMBER]]", order.Style.StyleNumber.ToString().ToUpper());
                template.Subject = template.Subject.Replace("[[BUYER]]", order.Style.client.CompanyName.ToString().ToUpper());
                template.Subject = template.Subject.Replace("[[DEPARTMENT]]", order.Style.cdept.Name.ToString().ToUpper());
                if (status == 1)
                {
                    template.Subject = template.Subject.Replace("[[STATUS]]", ("PUT ON HOLD").ToUpper());
                    template.Content = template.Content.Replace("[[STATUS]]", ("PUT ON HOLD").ToUpper());
                }
                else if (status == 2)
                {
                    template.Subject = template.Subject.Replace("[[STATUS]]", ("PUT OFF HOLD").ToUpper());
                    template.Content = template.Content.Replace("[[STATUS]]", ("PUT OFF HOLD").ToUpper());
                }

                template.Content = template.Content.Replace("[[ACCOUNT MANAGER]]", accountManager.ToUpper());
                template.Content = template.Content.Replace("[[COMMENTS]]", Remarks.ToString().ToUpper());

                foreach (OrderDetail od in order.OrderBreakdown)
                {
                    if (od.OrderDetailID == OrderDetailID)
                        template.Subject = template.Subject.Replace("[[QTY]]", order.TotalQuantity.ToString("N0"));
                }

                System.Diagnostics.Trace.WriteLine("Processing of On Hold Order Email having Subject ----" + template.Subject + "has been started on " + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                this.SendEmail(fromName, to, null, null, template.Subject.ToUpper(), template.Content, null, false, true);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in On Hold Order Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));

                //this.SendErrorEmail(ex.Message + "\n" + ex.StackTrace);

            }

        }

        public void SendQAStausEmail(int ProductionPlanningID, bool IsFail)
        {
            try
            {
                EmailTemplate template = this.AdminDataProviderInstance.GetEmailTemplateByType((IsFail) ? EmailTemplateType.QAFAILED : EmailTemplateType.QAAPPROVED);

                List<String> departmentList = new List<String>();
                List<String> designationList = new List<string>();

                departmentList.AddRange(template.DepartmentIDs.Split(new char[] { ',' }));
                designationList.AddRange(template.DesignationIDs.Split(new char[] { ',' }));

                int orderDetailID = 0;
                int clientID = 0;
                DataTable dtQualityControll = new DataTable();
                QualityController qualityController = new QualityController();
                dtQualityControll = qualityController.GetQualityControlSatatusFailData(ProductionPlanningID);

                orderDetailID = (dtQualityControll.Rows[0]["OrderDetailID"] == DBNull.Value) ? -1 : Convert.ToInt32(dtQualityControll.Rows[0]["OrderDetailID"]);
                clientID = (dtQualityControll.Rows[0]["Clientid"] == DBNull.Value) ? -1 : Convert.ToInt32(dtQualityControll.Rows[0]["Clientid"]);

                //System.Diagnostics.Debugger.Break();            
                String fromName = BLLCache.GetConfigurationKeyValue("FROMEMAIL"); //Constants.KEY_FROM_EMAIL

                // FACTORY MANAGER/LOGISTICS/QA/PRODUCTION MANAGER/PRODUCTION TECHNOLOGIST/MERCHANDISING TEAM (CURRENT ACCOUNT), SALES MANAGER BIPL
                //objDepartmentList.Add(Convert.ToInt32(Group.BIPL_QA).ToString());                
                //designationListWithoutClent.Add(((int)Designation.BIPL_Production_FactoryManager).ToString());
                //designationListWithoutClent.Add(((int)Designation.BIPL_Production_Manager).ToString());
                //designationListWithoutClent.Add(((int)Designation.BIPL_Production_ProductionManager).ToString());
                //designationListWithoutClent.Add(((int)Designation.BIPL_Sales_Manager).ToString());
                //designationListWithoutClent.Add(((int)Designation.BIPL_QA_Manager).ToString());
                //designationListWithoutClent.Add(((int)Designation.BIPL_Logistics_DeliveryManager).ToString());
                //designationListWithoutClent.Add(((int)Designation.BIPL_Logistics_Manager).ToString());
                //designationListWithoutClent.Add(((int)Designation.BIPL_Logistics_ShippingManager).ToString());
                //designationList.Add(((int)Designation.BIPL_Merchandising_AccountManager).ToString());
                //designationList.Add(((int)Designation.BIPL_Merchandising_FitMerchant).ToString());
                //designationList.Add(((int)Designation.BIPL_Merchandising_Manager).ToString());
                //designationList.Add(((int)Designation.BIPL_Merchandising_SamplingMerchant).ToString());

                //get User Data
                List<User> userListWithClient = GetUserInfo(new List<String>(), designationList, departmentList, clientID);

                List<Attachment> attachments = new List<Attachment>();

                string url = "/Internal/Merchandising/QualityControl.aspx?orderDetailID=" + orderDetailID;
                string fileName = "QA Form-";
                string qaManager = string.Empty;

                PDFController pdfController = new PDFController(this.LoggedInUser);
                //string pdfFilePath = pdfController.GeneratePDFForPrint(url, fileName, this.LoggedInUser.UserData.Username,
                //this.LoggedInUser.UserData.Password, 1200, -1);

                string pdfFilePath = pdfController.GeneratePDFForMultiPagePrint(url, fileName, this.LoggedInUser.UserData.Username,
                            this.LoggedInUser.UserData.Password, 1250, -1);

                if (!string.IsNullOrEmpty(pdfFilePath))
                    attachments.Add(new Attachment(pdfFilePath));

                List<String> to = new List<String>();

                foreach (User user in userListWithClient)
                {
                    if (to.Contains(user.Email))
                    {
                        continue;
                    }
                    else
                    {
                        //to.Add(user.Email);
                    }
                }
                // edit by surendra/hitesh
                //Abhishek
                SendMailUsingKeyValue("BIPL.SendQAStausEmail", out to);

                //END
                //to.Add("bipl_ieupdate@boutique.in");
                //to.Add("bipl_logistics@boutique.in");

                ////  to.Add("bipl_qateam@boutique.in");
                //to.Add("hitesh@boutique.in");

                int qty = (dtQualityControll.Rows[0]["ShippingQty"] == DBNull.Value) ? 0 : Convert.ToInt32(dtQualityControll.Rows[0]["ShippingQty"]);
                template.Subject = template.Subject.Replace("[[IKANDI SERIAL]]", ((dtQualityControll.Rows[0]["SerialNumber"] == DBNull.Value) ? string.Empty : (dtQualityControll.Rows[0]["SerialNumber"].ToString().ToUpper())));
                template.Subject = template.Subject.Replace("[[STYLE NUMBER]]", ((dtQualityControll.Rows[0]["StyleNumber"] == DBNull.Value) ? string.Empty : (dtQualityControll.Rows[0]["StyleNumber"].ToString().ToUpper())));
                template.Subject = template.Subject.Replace("[[BUYER]]", ((dtQualityControll.Rows[0]["CompanyName"] == DBNull.Value) ? string.Empty : (dtQualityControll.Rows[0]["CompanyName"].ToString().ToUpper())));
                template.Subject = template.Subject.Replace("[[DEPARTMENT]]", ((dtQualityControll.Rows[0]["DepartmentName"] == DBNull.Value) ? string.Empty : (dtQualityControll.Rows[0]["DepartmentName"].ToString().ToUpper())));
                template.Subject = template.Subject.Replace("[[QTY]]", qty.ToString("N0"));

                System.Diagnostics.Trace.WriteLine("Processing of QA Staus Fail Email having Subject ----" + template.Subject + "has been started on " + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                this.SendEmail(fromName, to, null, null, template.Subject.ToUpper(), template.Content, attachments, false, false);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in QA Staus Fail Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));

               // this.SendErrorEmail(ex.Message + "\n" + ex.StackTrace);

            }

        }



        // Tested




        public void SendOrderDeleveredEmail(DateTime Date)
        {
            bool bIkandi = false;
            bool bNonIkandi = false;
            EmailTemplate template = null;
            EmailTemplate templatebtq = null;
            template = this.AdminDataProviderInstance.GetEmailTemplateByType(EmailTemplateType.ORDERDELEVEREDIKandi);
            templatebtq = this.AdminDataProviderInstance.GetEmailTemplateByType(EmailTemplateType.ORDERDELEVEREDBQT);
            StringBuilder sb = new StringBuilder();
            StringBuilder sbq = new StringBuilder();
            //for (int i = 1; i <= 2; i++)
            //{
            try
            {


                //if (i == 1)

                //if (i == 2)

                //List<String> departmentList = new List<String>();
                //List<String> designationList = new List<string>();

                //departmentList.AddRange(template.DepartmentIDs.Split(new char[] { ',' }));
                //designationList.AddRange(template.DesignationIDs.Split(new char[] { ',' }));

                //LOGISTIC MANAGER, DELIVERY MANAGER, IKANDI ACCOUNTS, SALES IKANDI
                //objDepartmentIdList.Add(Convert.ToInt32(Group.ikandi_Sales).ToString());
                //objDepartmentIdList.Add(Convert.ToInt32(Group.iKandi_FinanceLogistics).ToString());
                //designationList.Add(((int)Designation.BIPL_Logistics_DeliveryManager).ToString());
                //designationList.Add(((int)Designation.BIPL_Logistics_Manager).ToString());

                String fromName = BLLCache.GetConfigurationKeyValue("FROMEMAIL");

                List<String> to = new List<String>();

                //get User Data
                //List<User> userList = GetUsersEmailCompanyWise(new List<String>(), designationList, departmentList, 0, i);

                //foreach (User user in userList)
                //{
                //    if (to.Contains(user.Email))
                //    {
                //        continue;
                //    }
                //    else
                //    {
                //        to.Add(user.Email);
                //    }
                //}

                string partnerName = string.Empty;
                bIkandi = this.FITsDataProviderInstance.GetAllOrderDeliveredTodayCompanyWise_CheckIkandi(Date, 1);
                bNonIkandi = this.FITsDataProviderInstance.GetAllOrderDeliveredTodayCompanyWise_CheckIkandi(Date, 2);
                if (bIkandi == true)
                {
                    List<OrderDetail> orderDetail = this.ReportDataProviderInstance.GetAllOrderDeliveredTodayCompanyWise(Date, 1);
                    sb = OrderDelivered(orderDetail);
                }
                if (bNonIkandi == true)
                {
                    List<OrderDetail> orderDetail = this.ReportDataProviderInstance.GetAllOrderDeliveredTodayCompanyWise(Date, 2);
                    sbq = OrderDelivered(orderDetail);
                }
                //List<OrderDetail> orderDetail = this.ReportDataProviderInstance.GetAllOrderDeliveredTodayCompanyWise(Date, i);

                if (bIkandi == true)
                {
                    template.Content = template.Content.Replace("[[TABLE]]", sb.ToString());
                    template.Content = template.Content.Replace("[[PARTNER NAME]]", partnerName.ToUpper());

                    System.Diagnostics.Trace.WriteLine("Processing of Order Delevered Email having Subject ----" + template.Subject + "has been started on " + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    //Abhishek
                    SendMailUsingKeyValue("Ikandi.SendOrderDeleveredEmail", out to);


                    //to.Add("bipl_logistics@boutique.in");
                    //to.Add("ikandi_sales@ikandi.org.uk");
                    //to.Add("samantha@ikandi.org.uk");
                    //to.Add("robert@ikandi.org.uk");
                    //END
                    this.SendEmail(fromName, to, null, null, template.Subject.ToUpper(), template.Content, null, false, true);
                    to.Clear();
                }
                if (bNonIkandi == true)
                {
                    templatebtq.Content = templatebtq.Content.Replace("[[TABLE]]", sbq.ToString());
                    templatebtq.Content = templatebtq.Content.Replace("[[PARTNER NAME]]", partnerName.ToUpper());

                    System.Diagnostics.Trace.WriteLine("Processing of Order Delevered Email having Subject ----" + template.Subject + "has been started on " + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    //Abhishek
                    SendMailUsingKeyValue("BIPL.SendOrderDeleveredEmail", out to);


                    //to.Add("bipl_logistics@boutique.in");

                    //END
                    this.SendEmail(fromName, to, null, null, templatebtq.Subject.ToUpper(), templatebtq.Content, null, false, true);
                    to.Clear();
                }



                //}
                //else
                //{
                //    System.Diagnostics.Trace.WriteLine("There is no record in Order Delevered Email for the date of" + Date.ToString("dd MM yy (ddd)") + ". So Email has not been send on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                //}

            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in Order Delevered Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));

               // this.SendErrorEmail(ex.Message + "\n" + ex.StackTrace);
            }
        }





        public void SendEmailForEditAccessoryOrder()
        {
            try
            {
                EmailTemplate template = this.AdminDataProviderInstance.GetEmailTemplateByType(EmailTemplateType.EDITACCESSORYORDER);

                List<String> departmentList = new List<String>();
                List<String> designationList = new List<string>();

                departmentList.AddRange(template.DepartmentIDs.Split(new char[] { ',' }));
                designationList.AddRange(template.DesignationIDs.Split(new char[] { ',' }));

                List<AccessoryWorking> accessoryWorking = this.AccessoryWorkingDataProviderInstance.GetAccessoryWorkingByCurrentDate(DateTime.Today);
                if (accessoryWorking.Count == 0)
                {
                    System.Diagnostics.Trace.WriteLine("There is no record for Accessory Order form changes Email of the date " + DateTime.Today.ToString("dd MM yy (ddd)") + " on " + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                }
                else if (accessoryWorking.Count > 0)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append("<TABLE cellpadding=5 border=1>");
                    sb.Append("<TR>");
                    sb.Append("<TH>SERIAL NUMBER</TH>");
                    sb.Append("<TH>CHANGES</TH>");
                    sb.Append("</TR>");


                    foreach (AccessoryWorking acc in accessoryWorking)
                    {
                        string history = "";
                        history = acc.History;

                        if (acc.History.IndexOf(DateTime.Today.ToString("dd MMM yy (ddd)")) > -1)
                        {
                            history = acc.History.Substring(acc.History.IndexOf(DateTime.Today.ToString("dd MMM yy (ddd)")));
                        }
                        else
                        {
                            history = string.Empty;
                        }

                        if (history == string.Empty)
                        {
                            continue;
                        }
                        else
                        {
                            sb.Append("<TR>");
                            sb.Append("<TD>" + acc.Order.SerialNumber.ToUpper() + "</TD>");

                            sb.Append("<TD style='text-align: left !importanr;'>" + history.ToUpper() + "</TD>");
                            sb.Append("</TR>");
                        }

                    }
                    sb.Append("</TABLE>");

                    string str = sb.ToString();
                    if (str.IndexOf("<TD") == -1)
                    {
                        return;
                    }

                    System.Diagnostics.Trace.WriteLine("Accessory Order form changes Email process starts of the date " + DateTime.Today.ToString("dd MM yy (ddd)") + " on " + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                    //objDesignationList.Add(Convert.ToInt32(Designation.BIPL_Accessory_Manager).ToString());
                    //objDesignationList.Add(Convert.ToInt32(Designation.BIPL_Accessory_Assistant).ToString());
                    //objDesignationList.Add(((int)Designation.BIPL_Merchandising_AccountManager).ToString());
                    //objDesignationList.Add(((int)Designation.BIPL_Merchandising_FitMerchant).ToString());
                    //objDesignationList.Add(((int)Designation.BIPL_Merchandising_Manager).ToString());

                    List<User> userList = GetUserInfo(new List<String>(), designationList, departmentList, 0);

                    String fromName = BLLCache.GetConfigurationKeyValue("FROMEMAIL");

                    List<String> to = new List<String>();

                    foreach (User user in userList)
                    {

                        if (to.Contains(user.Email.ToString()))
                        {
                            continue;
                        }
                        else
                        {
                            //to.Add(user.Email);
                        }
                    }
                    // edit by surendra/hitesh
                    //Abhishek
                    SendMailUsingKeyValue("BIPL.SendEmailForEditAccessoryOrder", out to);


                    //to.Add("bipl_merchandising@boutique.in");
                    //to.Add("bipl_accessories@boutique.in");
                    //to.Add("sanjeev@boutique.in");
                    //to.Add("hitesh@boutique.in");

                    //END
                    System.Diagnostics.Trace.WriteLine("Processing of Accessory Order Form changes ----" + template.Subject + "has been started on " + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                    template.Content = template.Content.Replace("[[Changes]]", sb.ToString());
                    //template.Content += "<br/><br/>Thanks!";

                    this.SendEmail(fromName, to, null, null, template.Subject.ToUpper(), template.Content, null, false, false);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in Accessory Order Form changes on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
               // this.SendErrorEmail(ex.Message + "\n" + ex.StackTrace);

            }
        }

   
        // Tested
     

        public void SendEmailForCostConfirmed(string StyleNumber, string Comments, bool IsConfirmed, double BIPLPrice, int ClientID)
        {
            try
            {
                EmailTemplate template = this.AdminDataProviderInstance.GetEmailTemplateByType((IsConfirmed) ? EmailTemplateType.COSTCONFIRMED : EmailTemplateType.COSTDECLINED);

                List<String> departmentList = new List<String>();
                List<String> designationList = new List<string>();

                departmentList.AddRange(template.DepartmentIDs.Split(new char[] { ',' }));
                designationList.AddRange(template.DesignationIDs.Split(new char[] { ',' }));

                DataSet ds = this.ReportControllerInstance.GetAllOrdersOnStyle(StyleNumber, string.Empty, false);

                string styleImage = string.Empty;
                string biplPrice = BIPLPrice.ToString();

                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    styleImage = "<IMG SRC='" + Constants.SITE_BASE_URL + "/uploads/style/thumb-" + ds.Tables[0].Rows[0]["SampleImageURL1"].ToString() + "'  />";

                    StringBuilder sb = new StringBuilder();
                    sb.Append("<TABLE cellpadding=5 border=1>");
                    sb.Append("<TR>");
                    sb.Append("<TH>SERIAL NUMBER</TH>");
                    sb.Append("<TH>DEPARTMENT</TH>");
                    sb.Append("<TH>LINE ITEM NUMBER</TH>");
                    sb.Append("<TH>CONTRACT NUMBER</TH>");
                    sb.Append("<TH>QUANTITY</TH>");
                    sb.Append("<TH>STATUS MODE</TH>");
                    sb.Append("</TR>");


                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        sb.Append("<TR>");
                        sb.Append("<TD>" + row["SerialNumber"].ToString().ToUpper() + "</TD>");
                        sb.Append("<TD>" + row["DepartmentName"].ToString().ToUpper() + "</TD>");
                        sb.Append("<TD>" + row["LineItemNumber"].ToString().ToUpper() + "</TD>");
                        sb.Append("<TD>" + row["ContractNumber"].ToString().ToUpper() + "</TD>");
                        sb.Append("<TD>" + row["Quantity"] + "</TD>");
                        sb.Append("<TD>" + row["StatusMode"].ToString().ToUpper() + "</TD>");
                        sb.Append("</TR>");
                    }

                    sb.Append("</TABLE>");


                    //objDesignationList.Add(Convert.ToInt32(Designation.BIPL_Merchandising_Manager).ToString());
                    //objDesignationList.Add(Convert.ToInt32(Designation.BIPL_Sales_Manager).ToString());
                    //objDesignationList.Add(Convert.ToInt32(Designation.BIPL_Sales_Advisor).ToString());
                    //objDesignationList.Add(Convert.ToInt32(Designation.iKandi_Sales_Manager).ToString());
                    //objDesignationList.Add(Convert.ToInt32(Designation.BIPL_Merchandising_AccountManager).ToString());
                    //objDesignationList.Add(Convert.ToInt32(Designation.BIPL_Merchandising_FitMerchant).ToString());
                    //objDesignationList.Add(Convert.ToInt32(Designation.iKandi_Sales_SalesManager).ToString());

                    List<User> userList = GetUserInfo(new List<String>(), designationList, departmentList, ClientID);

                    String fromName = BLLCache.GetConfigurationKeyValue("FROMEMAIL");

                    List<String> to = new List<String>();

                    foreach (User user in userList)
                    {

                        if (to.Contains(user.Email.ToString()))
                        {
                            continue;
                        }
                        else
                        {
                            to.Add(user.Email);
                        }
                    }



                    template.Subject = template.Subject.Replace("[[STYLE]]", StyleNumber.ToUpper());
                    template.Subject = template.Subject.Replace("[[ACTION]]", (IsConfirmed) ? "ACCEPTED" : "DECLINED");
                    template.Content = template.Content.Replace("[[ACTION]]", (IsConfirmed) ? "ACCEPTED" : "DECLINED");
                    template.Content = template.Content.Replace("[[STYLE]]", StyleNumber.ToUpper());
                    template.Content = template.Content.Replace("[[CONTENT]]", sb.ToString());
                    template.Content = template.Content.Replace("[[STYLE_IMAGE]]", styleImage);
                    template.Content = template.Content.Replace("[[PRICE]]", biplPrice);
                    template.Content = template.Content.Replace("[[COMMENTS]]", Comments.ToUpper());

                    this.SendEmail(fromName, to, null, null, template.Subject.ToUpper(), template.Content, null, false, false);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                //this.SendErrorEmail(ex.Message + "\n" + ex.StackTrace);

            }
        }

        public void SendRaiseCancelledOrderInvoice(int OrderDetailID, int LiabilityID)
        {
            try
            {
                EmailTemplate template = this.AdminDataProviderInstance.GetEmailTemplateByType(EmailTemplateType.CANCELLEDORDERINVOICE);

                List<String> departmentList = new List<String>();
                List<String> designationList = new List<string>();

                departmentList.AddRange(template.DepartmentIDs.Split(new char[] { ',' }));
                designationList.AddRange(template.DesignationIDs.Split(new char[] { ',' }));

                String fromName = BLLCache.GetConfigurationKeyValue("FROMEMAIL"); //Constants.KEY_FROM_EMAIL

                iKandi.Common.Liability liability = this.LiabilityControllerInstance.GetLiabilityData(OrderDetailID, LiabilityID);
                iKandi.Common.Order order = this.OrderDataProviderInstance.GetOrderByOrderDetailId(liability.OrderDetail.OrderDetailID);

                //designationList.Add(((int)Designation.BIPL_Sales_Manager).ToString());
                //designationList.Add(((int)Designation.iKandi_FinanceLogistics_Accountant).ToString());
                //designationList.Add(((int)Designation.iKandi_Sales_Manager).ToString());
                //designationList.Add(((int)Designation.iKandi_Sales_SalesManager).ToString());

                string accountant = string.Empty;

                //get User Data
                List<User> userList = GetUserInfo(new List<String>(), designationList, departmentList, 0);

                List<Attachment> attachments = new List<Attachment>();

                string url = "/Internal/Sales/Liability.aspx?orderDetailId=" + OrderDetailID;
                string fileName = "Liability Form-";

                PDFController pdfController = new PDFController(this.LoggedInUser);
                string pdfFilePath = pdfController.GeneratePDFForPrint(url, fileName, this.LoggedInUser.UserData.Username, this.LoggedInUser.UserData.Password, 1200, -1);

                if (!string.IsNullOrEmpty(pdfFilePath))
                    attachments.Add(new Attachment(pdfFilePath));

                List<String> to = new List<String>();

                foreach (User user in userList)
                {
                    if (to.Contains(user.Email))
                    {
                        continue;
                    }
                    else
                    {
                        if (user.Designation == Designation.iKandi_FinanceLogistics_Accountant)
                        {
                            if (accountant == string.Empty)
                            {
                                accountant = user.FullName;
                            }
                            else
                            {
                                accountant = accountant + ", " + user.FullName;
                            }
                        }
                        to.Add(user.Email);

                    }
                }

                template.Subject = template.Subject.Replace("[[IKANDI SERIAL]]", order.SerialNumber.ToUpper());
                template.Subject = template.Subject.Replace("[[STYLE NUMBER]]", order.Style.StyleNumber.ToUpper());
                template.Subject = template.Subject.Replace("[[BUYER]]", order.Style.client.CompanyName.ToUpper());
                template.Subject = template.Subject.Replace("[[DEPARTMENT]]", order.Style.cdept.Name.ToUpper());
                template.Subject = template.Subject.Replace("[[QTY]]", liability.QuantityCancelled.ToString("N0"));

                System.Diagnostics.Trace.WriteLine("Processing of Cancelled Order Raise Invoice Email having Subject ----" + template.Subject + "has been started on " + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                this.SendEmail(fromName, to, null, null, template.Subject.ToUpper(), template.Content, attachments, false, false);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in Cancelled Order Raise Invoice Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));

                //this.SendErrorEmail(ex.Message + "\n" + ex.StackTrace);

            }

        }


        // Fatal Error
        public void SendMonthlyShipmentStatement(DateTime FromDate, DateTime ToDate)
        {

            try
            {
                EmailTemplate template = this.AdminDataProviderInstance.GetEmailTemplateByType(EmailTemplateType.SHIPMENTREPORT);

                List<String> departmentList = new List<String>();
                List<String> designationList = new List<string>();

                departmentList.AddRange(template.DepartmentIDs.Split(new char[] { ',' }));
                designationList.AddRange(template.DesignationIDs.Split(new char[] { ',' }));

                // SALES, MERCHANDISING, FABRICS, ACCESSORIES, QA, PRODUCTION, LOGISTICS, IKANDI MANAGER SALES
                //objDepartmentIdList.Add(Convert.ToInt32(Group.BIPL_Sales).ToString());
                //objDepartmentIdList.Add(Convert.ToInt32(Group.ikandi_Sales).ToString());
                //designationList.Add(((int)Designation.iKandi_FinanceLogistics_Accountant).ToString());
                //designationList.Add(((int)Designation.BIPL_Logistict_Accountant).ToString());
                //designationList.Add(((int)Designation.BIPL_Merchandising_AccountManager).ToString());
                //designationList.Add(((int)Designation.BIPL_Logistics_Manager).ToString());

                // Get User Data
                List<User> userList = GetUserInfo(new List<String>(), designationList, departmentList, 0);

                String fromName = BLLCache.GetConfigurationKeyValue("FROMEMAIL");

                List<String> to = new List<String>();

                foreach (User user in userList)
                {
                    if (to.Contains(user.Email))
                    {
                        continue;
                    }
                    else
                    {
                        to.Add(user.Email);
                    }
                }

                ReportController controller = new ReportController();

                if (!Directory.Exists(Constants.TEMP_FOLDER_PATH))
                    Directory.CreateDirectory(Constants.TEMP_FOLDER_PATH);

                string ReportType = "MONTHLY";
                string name = ReportType + " SHIPMENT REPORT ON -" + FromDate.ToString("dd MMM yyy") + " to " + ToDate.ToString("dd MMM yyy") + ".xls";
                string pdfFilePath = Path.Combine(Constants.TEMP_FOLDER_PATH, name);

                bool success = controller.GenerateShipmentStatementExcel(pdfFilePath, ReportType, FromDate, ToDate);

                System.Diagnostics.Trace.WriteLine("Excel for Monthly ShipMent Report  Email has been generated successfully  on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                if (!success)
                {
                    System.Diagnostics.Trace.WriteLine("There is no record in the Excel for Monthly ShipMent Report. So Email has not been send on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    return;
                }

                string subject = ReportType + " SHIPMENT REPORT FROM -" + FromDate.ToString("dd MMM yyy") + " to " + ToDate.ToString("dd MMM yyy");
                string duration = "( " + FromDate.ToString("dd MMM yyy") + " - " + ToDate.ToString("dd MMM yyy") + " )";
                template.Subject = template.Subject.Replace("[[SUBJECT]]", subject.ToUpper());
                template.Content = template.Content.Replace("[[Type]]", ReportType);
                template.Content = template.Content.Replace("[[Duration]]", duration);

                List<Attachment> atts = new List<Attachment>();
                atts.Add(new Attachment(pdfFilePath));

                System.Diagnostics.Trace.WriteLine("Processing of Excel for Monthly ShipMent Report having Subject ----" + template.Subject + "has been started on " + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                this.SendEmail(fromName, to, null, null, template.Subject.ToUpper(), template.Content, atts, false, true);

            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in Excel for Monthly ShipMent Report on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
               // this.SendErrorEmail(ex.Message + "\n" + ex.StackTrace);
            }
        }

        public void SendQuarterlyShipmentStatement(DateTime FromDate, DateTime ToDate)
        {

            try
            {
                EmailTemplate template = this.AdminDataProviderInstance.GetEmailTemplateByType(EmailTemplateType.SHIPMENTREPORT);

                List<String> departmentList = new List<String>();
                List<String> designationList = new List<string>();

                departmentList.AddRange(template.DepartmentIDs.Split(new char[] { ',' }));
                designationList.AddRange(template.DesignationIDs.Split(new char[] { ',' }));

                // SALES, MERCHANDISING, FABRICS, ACCESSORIES, QA, PRODUCTION, LOGISTICS, IKANDI MANAGER SALES

                //objDepartmentIdList.Add(Convert.ToInt32(Group.BIPL_Sales).ToString());
                //objDepartmentIdList.Add(Convert.ToInt32(Group.ikandi_Sales).ToString());

                //designationList.Add(((int)Designation.iKandi_FinanceLogistics_Accountant).ToString());
                //designationList.Add(((int)Designation.BIPL_Logistict_Accountant).ToString());
                //designationList.Add(((int)Designation.BIPL_Merchandising_AccountManager).ToString());
                //designationList.Add(((int)Designation.BIPL_Logistics_Manager).ToString());

                //get User Data
                List<User> userList = GetUserInfo(new List<String>(), designationList, departmentList, 0);

                String fromName = BLLCache.GetConfigurationKeyValue("FROMEMAIL");

                List<String> to = new List<String>();

                foreach (User user in userList)
                {
                    if (to.Contains(user.Email))
                    {
                        continue;
                    }
                    else
                    {
                        to.Add(user.Email);

                    }
                }

                ReportController controller = new ReportController();

                if (!Directory.Exists(Constants.TEMP_FOLDER_PATH))
                    Directory.CreateDirectory(Constants.TEMP_FOLDER_PATH);
                string ReportType = "QUATERLY";
                string name = ReportType + " SHIPMENT REPORT ON -" + FromDate.ToString("dd MMM yyy") + " to " + ToDate.ToString("dd MMM yyy") + ".xls";
                string pdfFilePath = Path.Combine(Constants.TEMP_FOLDER_PATH, name);

                bool success = controller.GenerateShipmentStatementExcel(pdfFilePath, ReportType, FromDate, ToDate);
                System.Diagnostics.Trace.WriteLine("Excel for QYATERLY ShipMent Report  Email has been generated successfully  on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                if (!success)
                {
                    System.Diagnostics.Trace.WriteLine("There is no record in the Excel for QUATERLY ShipMent Report. So Email has not been send on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    return;
                }

                string subject = ReportType + " SHIPMENT REPORT FROM -" + FromDate.ToString("dd MMM yyy") + " to " + ToDate.ToString("dd MMM yyy");
                string duration = "( " + FromDate.ToString("dd MMM yyy") + " - " + ToDate.ToString("dd MMM yyy") + " )";
                template.Subject = template.Subject.Replace("[[SUBJECT]]", subject.ToUpper());
                template.Content = template.Content.Replace("[[Type]]", ReportType);
                template.Content = template.Content.Replace("[[Duration]]", duration);

                List<Attachment> atts = new List<Attachment>();
                atts.Add(new Attachment(pdfFilePath));

                System.Diagnostics.Trace.WriteLine("Processing of Excel for Quaterly ShipMent Report having Subject ----" + template.Subject + "has been started on " + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                this.SendEmail(fromName, to, null, null, template.Subject.ToUpper(), template.Content, atts, false, true);

            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in Excel for Quaterly ShipMent Report on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
               // this.SendErrorEmail(ex.Message + "\n" + ex.StackTrace);
            }
        }

        public void SendYearlyShipmentStatement(DateTime FromDate, DateTime ToDate)
        {

            try
            {
                EmailTemplate template = this.AdminDataProviderInstance.GetEmailTemplateByType(EmailTemplateType.SHIPMENTREPORT);

                List<String> departmentList = new List<String>();
                List<String> designationList = new List<string>();

                departmentList.AddRange(template.DepartmentIDs.Split(new char[] { ',' }));
                designationList.AddRange(template.DesignationIDs.Split(new char[] { ',' }));

                // SALES, MERCHANDISING, FABRICS, ACCESSORIES, QA, PRODUCTION, LOGISTICS, IKANDI MANAGER SALES
                //objDepartmentIdList.Add(Convert.ToInt32(Group.BIPL_Sales).ToString());
                //objDepartmentIdList.Add(Convert.ToInt32(Group.ikandi_Sales).ToString());
                //designationList.Add(((int)Designation.iKandi_FinanceLogistics_Accountant).ToString());
                //designationList.Add(((int)Designation.BIPL_Logistict_Accountant).ToString());
                //designationList.Add(((int)Designation.BIPL_Merchandising_AccountManager).ToString());
                //designationList.Add(((int)Designation.BIPL_Logistics_Manager).ToString());

                //get User Data
                List<User> userList = GetUserInfo(new List<String>(), designationList, departmentList, 0);

                String fromName = BLLCache.GetConfigurationKeyValue("FROMEMAIL");

                List<String> to = new List<String>();

                foreach (User user in userList)
                {
                    if (to.Contains(user.Email))
                    {
                        continue;
                    }
                    else
                    {
                        to.Add(user.Email);

                    }
                }

                ReportController controller = new ReportController();

                if (!Directory.Exists(Constants.TEMP_FOLDER_PATH))
                    Directory.CreateDirectory(Constants.TEMP_FOLDER_PATH);
                string ReportType = "YEARLY";
                string name = ReportType + " SHIPMENT REPORT ON -" + FromDate.ToString("dd MMM yyy") + " to " + ToDate.ToString("dd MMM yyy") + ".xls";
                string pdfFilePath = Path.Combine(Constants.TEMP_FOLDER_PATH, name);

                bool success = controller.GenerateShipmentStatementExcel(pdfFilePath, ReportType, FromDate, ToDate);
                System.Diagnostics.Trace.WriteLine("Excel for Yearly ShipMent Report  Email has been generated successfully  on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                if (!success)
                {
                    System.Diagnostics.Trace.WriteLine("There is no record in the Excel for Yearly ShipMent Report. So Email has not been send on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    return;
                }

                string subject = ReportType + " SHIPMENT REPORT FROM -" + FromDate.ToString("dd MMM yyy") + " to " + ToDate.ToString("dd MMM yyy");
                string duration = "( " + FromDate.ToString("dd MMM yyy") + " - " + ToDate.ToString("dd MMM yyy") + " )";
                template.Subject = template.Subject.Replace("[[SUBJECT]]", subject.ToUpper());
                template.Content = template.Content.Replace("[[Type]]", ReportType);
                template.Content = template.Content.Replace("[[Duration]]", duration);

                List<Attachment> atts = new List<Attachment>();
                atts.Add(new Attachment(pdfFilePath));

                System.Diagnostics.Trace.WriteLine("Processing of Excel for Yearly ShipMent Report having Subject ----" + template.Subject + "has been started on " + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                this.SendEmail(fromName, to, null, null, template.Subject.ToUpper(), template.Content, atts, false, true);

            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in Excel for Yearly ShipMent Report on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
               // this.SendErrorEmail(ex.Message + "\n" + ex.StackTrace);
            }
        }

        // Tested
        public void SendFITSPendingOverAWeekEmail()
        {
            try
            {
                EmailTemplate template = this.AdminDataProviderInstance.GetEmailTemplateByType(EmailTemplateType.FITPENDINGEMAIL);

                List<String> departmentList = new List<String>();
                List<String> designationList = new List<string>();

                string WithClientDesignationIDs;
                string WithNoClientDesignationIDs;

                GetClientAssociatedDesignationID(template.DesignationIDs, out  WithClientDesignationIDs, out  WithNoClientDesignationIDs);

                departmentList.AddRange(template.DepartmentIDs.Split(new char[] { ',' }));
                designationList.AddRange(WithNoClientDesignationIDs.Split(new char[] { ',' }));

                List<String> to = new List<String>();


                DataSet ds = this.FITsDataProviderInstance.GetFITsPendingComments();

                StringBuilder sb = new StringBuilder();

                sb.Append("<TABLE border=1 cellpadding=5>");
                sb.Append("<TR>");
                sb.Append("<TH>ORDER DATE</TH>");
                sb.Append("<TH>SERIAL NUMBER</TH>");
                sb.Append("<TH>BUYER</TH>");
                sb.Append("<TH>DEPT.</TH>");
                sb.Append("<TH>STYLE</TH>");
                sb.Append("<TH>FABRIC</TH>");
                sb.Append("<TH>STC TGT</TH>");
                sb.Append("<TH>FIT STATUS</TH>");
                sb.Append("<TH>Ex-FACTORY</TH>");
                sb.Append("</TR>");

                DataTable dt = ds.Tables[0];

                if (dt.Rows.Count == 0)
                    return;

                List<String> objDesignationBasedOnClient = new List<string>();
                objDesignationBasedOnClient.AddRange(WithClientDesignationIDs.Split(new char[] { ',' }));

                //objDesignationBasedOnClient.Add(Convert.ToInt32(Designation.BIPL_Merchandising_AccountManager).ToString());
                //objDesignationBasedOnClient.Add(Convert.ToInt32(Designation.BIPL_Merchandising_FitMerchant).ToString());
                //objDesignationBasedOnClient.Add(Convert.ToInt32(Designation.iKandi_Sales_SalesManager).ToString());
                //objDesignationBasedOnClient.Add(Convert.ToInt32(Designation.iKandi_Technical_Technologist).ToString());
                //objDesignationBasedOnClient.Add(Convert.ToInt32(Designation.BIPL_Sales_Manager).ToString());

                foreach (DataRow row in dt.Rows)
                {
                    string fabric = string.Empty;
                    string fabric1 = (row["Fabric1"] == DBNull.Value || row["Fabric1"] == null) ? string.Empty : row["Fabric1"].ToString().ToUpper();
                    string fabric1Detail = (row["Fabric1Details"] == DBNull.Value || row["Fabric1Details"] == null) ? string.Empty : row["Fabric1Details"].ToString();

                    var Fab1Det = fabric1Detail.Trim().Split(' ');
                    int result;
                    if (!string.IsNullOrEmpty(Fab1Det[0]) && Int32.TryParse(Fab1Det[0], out result) && (Fab1Det.Length == 1 || (Fab1Det.Length == 2 && Fab1Det[1].Length <= 2)))
                    {
                        fabric1Detail = "PRD:" + fabric1Detail;
                        result = 0;
                    }

                    if (fabric1Detail.Trim() != string.Empty)
                    {
                        fabric1Detail = " : " + fabric1Detail.ToUpper();
                    }

                    //fabric = fabric1 + fabric1Detail;

                    DateTime exFactory = DateTime.MinValue;
                    DateTime dc = DateTime.MinValue;
                    int mode = -1;

                    if (row["Exfactory"] != DBNull.Value && row["Exfactory"] != null)
                        exFactory = Convert.ToDateTime(row["Exfactory"]);

                    if (row["DC"] != DBNull.Value && row["DC"] != null)
                        dc = Convert.ToDateTime(row["DC"]);

                    if (row["Mode"] != DBNull.Value && row["Mode"] != null)
                        mode = Convert.ToInt32(row["Mode"]);

                    string exBgColor = iKandi.BLL.CommonHelper.GetExFactoryColor(exFactory, dc, mode);

                    string imageUrl = ((row["SampleImageURL1"] == DBNull.Value || row["SampleImageURL1"] == null) ? string.Empty : row["SampleImageURL1"].ToString());
                    sb.Append("<TR>");
                    sb.Append("<TD>" + ((row["OrderDate"] == DBNull.Value || row["OrderDate"] == null) ? string.Empty : Convert.ToDateTime(row["OrderDate"]).ToString("dd MMM yy (ddd)")) + "</TD>");
                    sb.Append("<TD>" + ((row["SerialNumber"] == DBNull.Value || row["SerialNumber"] == null) ? string.Empty : row["SerialNumber"].ToString().ToUpper()) + "</TD>");
                    sb.Append("<TD>" + ((row["CompanyName"] == DBNull.Value || row["CompanyName"] == null) ? string.Empty : row["CompanyName"].ToString().ToUpper()) + "</TD>");
                    sb.Append("<TD>" + ((row["DepartmentName"] == DBNull.Value || row["DepartmentName"] == null) ? string.Empty : row["DepartmentName"].ToString().ToUpper()) + "</TD>");
                    sb.Append("<TD>" + ((row["StyleNumber"] == DBNull.Value || row["StyleNumber"] == null) ? string.Empty : row["StyleNumber"].ToString().ToUpper()));
                    sb.Append("<div><IMG SRC='" + Constants.SITE_BASE_URL + "/uploads/style/thumb-" + imageUrl + "'  /></div></TD>");
                    sb.Append("<TD>" + fabric + "</TD>");
                    sb.Append("<TD>" + ((row["STCTGT"] == DBNull.Value || row["STCTGT"] == null) ? string.Empty : Convert.ToDateTime(row["STCTGT"]).ToString("dd MMM yy (ddd)")) + "</TD>");

                    string planningFor = (row["PlanningFor"] == DBNull.Value || row["PlanningFor"] == null) ? string.Empty : row["PlanningFor"].ToString();

                    sb.Append("<TD>" + planningFor + "</TD>");
                    sb.Append("<TD style='background-color:" + exBgColor + "'>" + (exFactory == DateTime.MinValue ? string.Empty : exFactory.ToString("dd MMM yy (ddd)")) + "</TD>");

                    sb.Append("</TR>");

                    if (row["clientid"] != DBNull.Value || Convert.ToString(row["clientid"]) != string.Empty || Convert.ToInt32(row["clientid"]) > 0)
                    {
                        int clientId = Convert.ToInt32(row["clientid"]);



                        List<User> userListWithClient = GetUserInfo(new List<String>(), objDesignationBasedOnClient, new List<String>(), clientId);
                        foreach (User user in userListWithClient)
                        {
                            if (to.Contains(user.Email))
                            {
                                continue;
                            }
                            else
                            {
                                to.Add(user.Email);
                            }
                        }

                    }
                }

                sb.Append("</TABLE>");

                // A/c manager, Merch. Mgrs, Fit Merchant, BIPL Sales Mgrs, ikandi Technical Team, ikandi sales Team.              
                //objDesignationList.Add(Convert.ToInt32(Designation.BIPL_Merchandising_Manager).ToString());
                //objDesignationList.Add(Convert.ToInt32(Designation.BIPL_Sales_Manager).ToString());
                //objDesignationList.Add(Convert.ToInt32(Designation.iKandi_Sales_Manager).ToString());
                //objDesignationList.Add(Convert.ToInt32(Designation.iKandi_Technical_Manager).ToString());


                //get User Data
                List<User> userList = GetUserInfo(new List<String>(), designationList, departmentList, 0);

                String fromName = BLLCache.GetConfigurationKeyValue("FROMEMAIL");

                foreach (User user in userList)
                {
                    if (to.Contains(user.Email))
                    {
                        continue;
                    }
                    else
                    {
                        to.Add(user.Email);

                    }
                }

                template.Content = template.Content.Replace("[[STYLES_TABLE]]", sb.ToString());

                System.Diagnostics.Trace.WriteLine("Processing of FITS Comments pending having Subject ----" + template.Subject + "has been started on " + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                this.SendEmail(fromName, to, null, null, template.Subject.ToUpper(), template.Content, null, false, false);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in FITS Comments pending Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
               // this.SendErrorEmail(ex.Message + "\n" + ex.StackTrace);

            }
        }

        public void SendMailOrderRateChange(string StyleNumber, string OrderIds)
        {
            try
            {
                EmailTemplate template = this.AdminDataProviderInstance.GetEmailTemplateByType(EmailTemplateType.COSTINGRATECONTRACTCHANGE);

                List<String> departmentList = new List<String>();
                List<String> designationList = new List<string>();
                List<String> designationListcc = new List<string>();
                string WithClientDesignationIDs;
                string WithNoClientDesignationIDs;

                GetClientAssociatedDesignationID(template.DesignationIDs, out  WithClientDesignationIDs, out  WithNoClientDesignationIDs);

                departmentList.AddRange(template.DepartmentIDs.Split(new char[] { ',' }));
                designationList.AddRange(WithNoClientDesignationIDs.Split(new char[] { ',' }));
                designationListcc.Add("10");
                List<String> to = new List<String>();
                List<String> cc = new List<String>();

                DataSet ds = this.ReportControllerInstance.GetAllOrdersOnStyle(StyleNumber, OrderIds, false);

                StringBuilder sb = new StringBuilder();
                sb.Append("<Style>");
                sb.Append(".vertical_header     {     writing-mode: tb-rl;     filter: flipv fliph;     text-align: center;    vertical-align: middle;    width: 28px !important;    padding-top: 10px !important;    padding-bottom: 10px !important; /* padding:0px !important; */    margin: 0px !important;    }</Style>");
                sb.Append("<TABLE border=1 cellpadding=5>");
                sb.Append("<TR>");
                sb.Append("<TH HeaderStyle-CssClass='vertical_header'>ORDER DATE</TH>");
                sb.Append("<TH HeaderStyle-CssClass='vertical_header'>SERIAL NUMBER</TH>");
                sb.Append("<TH HeaderStyle-CssClass='vertical_header'>DEPT.</TH>");
                sb.Append("<TH>STYLE</TH>");
                sb.Append("<TH HeaderStyle-CssClass='vertical_header'>LINE #</TH>");
                sb.Append("<TH HeaderStyle-CssClass='vertical_header'>CONTRACT</TH>");
                sb.Append("<TH HeaderStyle-CssClass='vertical_header'>DESC.</TH>");
                sb.Append("<TH>QTY.</TH>");
                sb.Append("<TH>FABRIC DETAILS</TH>");
                sb.Append("<TH HeaderStyle-CssClass='vertical_header'>STC TGT.</TH>");
                sb.Append("<TH>FIT STATUS</TH>");
                sb.Append("<TH HeaderStyle-CssClass='vertical_header'>TOP SENT TGT.</TH>");
                sb.Append("<TH HeaderStyle-CssClass='vertical_header'>CUTTING</TH>");
                sb.Append("<TH HeaderStyle-CssClass='vertical_header'>STICHING</TH>");
                sb.Append("<TH HeaderStyle-CssClass='vertical_header' >PACKED</TH>");
                sb.Append("<TH>EX-FACTORY</TH>");
                sb.Append("<TH HeaderStyle-CssClass='vertical_header'>DC DATE</TH>");
                sb.Append("<TH HeaderStyle-CssClass='vertical_header'>BIPL PRICE</TH>");
                sb.Append("<TH HeaderStyle-CssClass='vertical_header'>IKANDI PRICE</TH>");
                sb.Append("<TH HeaderStyle-CssClass='vertical_header'>STATUS</TH>");
                sb.Append("<TH HeaderStyle-CssClass='vertical_header' >UNIT</TH>");
                sb.Append("</TR>");

                DataTable dt = ds.Tables[0];

                if (dt.Rows.Count == 0)
                    return;

                List<String> objDesignationBasedOnClient = new List<string>();
                objDesignationBasedOnClient.AddRange(WithClientDesignationIDs.Split(new char[] { ',' }));

                foreach (DataRow row in dt.Rows)
                {
                    DateTime exFactory = DateTime.MinValue;
                    DateTime dc = DateTime.MinValue;
                    string CurrencySymbolIkandi = string.Empty;
                    string CurrencySymbolBIPL = string.Empty;
                    int symbalType = -1;
                    if (row["ConvertTo"] != DBNull.Value && Convert.ToString(row["ConvertTo"]) != string.Empty)
                    {
                        symbalType = Convert.ToInt32(row["ConvertTo"]);
                    }
                    CurrencySymbolIkandi = Constants.GetCurrencySymbalByCurrencyType(symbalType);
                    CurrencySymbolBIPL = Constants.GetCurrencySymbalByCurrencyType(symbalType);

                    string fabric = string.Empty;
                    string fabric1 = (row["Fabric1"] == DBNull.Value || row["Fabric1"] == null) ? string.Empty : row["Fabric1"].ToString().ToUpper();
                    string fabric2 = (row["Fabric2"] == DBNull.Value || row["Fabric2"] == null) ? string.Empty : row["Fabric2"].ToString().ToUpper();
                    string fabric3 = (row["Fabric3"] == DBNull.Value || row["Fabric3"] == null) ? string.Empty : row["Fabric3"].ToString().ToUpper();
                    string fabric4 = (row["Fabric4"] == DBNull.Value || row["Fabric4"] == null) ? string.Empty : row["Fabric4"].ToString().ToUpper();


                    string ModeText = (row["ModeText"] == DBNull.Value || row["ModeText"] == null) ? string.Empty : row["ModeText"].ToString().ToUpper();

                    string fabric1Detail = (row["Fabric1Details"] == DBNull.Value || row["Fabric1Details"] == null) ? string.Empty : row["Fabric1Details"].ToString();
                    string fabric2Detail = (row["Fabric2Details"] == DBNull.Value || row["Fabric2Details"] == null) ? string.Empty : row["Fabric2Details"].ToString();
                    string fabric3Detail = (row["Fabric3Details"] == DBNull.Value || row["Fabric3Details"] == null) ? string.Empty : row["Fabric3Details"].ToString();
                    string fabric4Detail = (row["Fabric4Details"] == DBNull.Value || row["Fabric4Details"] == null) ? string.Empty : row["Fabric4Details"].ToString();


                    var Fab1Det = fabric1Detail.Trim().Split(' ');

                    var Fab2Det = fabric2Detail.Trim().Split(' ');

                    var Fab3Det = fabric3Detail.Trim().Split(' ');

                    var Fab4Det = fabric4Detail.Trim().Split(' ');

                    int result;
                    if (!string.IsNullOrEmpty(Fab1Det[0]) && Int32.TryParse(Fab1Det[0], out result) && (Fab1Det.Length == 1 || (Fab1Det.Length == 2 && Fab1Det[1].Length <= 2)))
                    {
                        fabric1Detail = "PRD:" + fabric1Detail;
                        result = 0;
                    }

                    if (!string.IsNullOrEmpty(Fab2Det[0]) && Int32.TryParse(Fab2Det[0], out result) && (Fab2Det.Length == 1 || (Fab2Det.Length == 2 && Fab2Det[1].Length <= 2)))
                    {
                        fabric2Detail = "PRD:" + fabric2Detail;
                        result = 0;
                    }

                    if (!string.IsNullOrEmpty(Fab3Det[0]) && Int32.TryParse(Fab3Det[0], out result) && (Fab3Det.Length == 1 || (Fab3Det.Length == 2 && Fab3Det[1].Length <= 2)))
                    {
                        fabric3Detail = "PRD:" + fabric3Detail;
                        result = 0;
                    }

                    if (!string.IsNullOrEmpty(Fab4Det[0]) && Int32.TryParse(Fab4Det[0], out result) && (Fab4Det.Length == 1 || (Fab4Det.Length == 2 && Fab4Det[1].Length <= 2)))
                    {
                        fabric4Detail = "PRD:" + fabric4Detail;
                        result = 0;
                    }

                    if (fabric1Detail.Trim() != string.Empty)
                    {
                        fabric1Detail = " : " + fabric1Detail.ToUpper();
                        fabric = fabric1 + fabric1Detail;

                    }
                    else if (fabric1.Trim() != string.Empty)
                    {
                        fabric = fabric1;
                    }

                    if (fabric2Detail.Trim() != string.Empty)
                    {
                        fabric2Detail = " : " + fabric2Detail.ToUpper();
                        fabric = fabric + "<BR>" + fabric2 + fabric2Detail;

                    }
                    else if (fabric2.Trim() != string.Empty)
                    {
                        fabric = fabric + "<BR>" + fabric2;

                    }

                    if (fabric3Detail.Trim() != string.Empty)
                    {
                        fabric3Detail = " : " + fabric3Detail.ToUpper();
                        fabric = fabric + "<BR>" + fabric3 + fabric3Detail;

                    }
                    else if (fabric3.Trim() != string.Empty)
                    {
                        fabric = fabric + "<BR>" + fabric3;

                    }

                    if (fabric4Detail.Trim() != string.Empty)
                    {
                        fabric4Detail = " : " + fabric4Detail.ToUpper();
                        fabric = fabric + "<BR>" + fabric4 + fabric4Detail;

                    }
                    else if (fabric4.Trim() != string.Empty)
                    {
                        fabric = fabric + "<BR>" + fabric4;

                    }



                    int mode = -1;

                    if (row["Exfactory"] != DBNull.Value && row["Exfactory"] != null)
                        exFactory = Convert.ToDateTime(row["Exfactory"]);

                    if (row["DC"] != DBNull.Value && row["DC"] != null)
                        dc = Convert.ToDateTime(row["DC"]);

                    if (row["Mode"] != DBNull.Value && row["Mode"] != null)
                        mode = Convert.ToInt32(row["Mode"]);


                    string exBgColor = iKandi.BLL.CommonHelper.GetExFactoryColor(exFactory, dc, mode);

                    string imageUrl = ((row["SampleImageURL1"] == DBNull.Value || row["SampleImageURL1"] == null) ? string.Empty : row["SampleImageURL1"].ToString());

                    sb.Append("<TR>");
                    sb.Append("<TD>" + ((row["OrderDate"] == DBNull.Value || row["OrderDate"] == null) ? string.Empty : Convert.ToDateTime(row["OrderDate"]).ToString("dd MMM yy (ddd)")) + "</TD>");
                    sb.Append("<TD>" + ((row["SerialNumber"] == DBNull.Value || row["SerialNumber"] == null) ? string.Empty : row["SerialNumber"].ToString().ToUpper()) + "</TD>");
                    sb.Append("<TD>" + ((row["DepartmentName"] == DBNull.Value || row["DepartmentName"] == null) ? string.Empty : row["DepartmentName"].ToString().ToUpper()) + "</TD>");
                    sb.Append("<TD>" + ((row["StyleNumber"] == DBNull.Value || row["StyleNumber"] == null) ? string.Empty : row["StyleNumber"].ToString().ToUpper()));
                    sb.Append("<div><IMG SRC='" + Constants.SITE_BASE_URL + "/uploads/style/thumb-" + imageUrl + "'  /></div></TD>");
                    sb.Append("<TD>" + ((row["LineItemNumber"] == DBNull.Value || row["LineItemNumber"] == null) ? string.Empty : row["LineItemNumber"].ToString().ToUpper()) + "</TD>");
                    sb.Append("<TD>" + ((row["ContractNumber"] == DBNull.Value || row["ContractNumber"] == null) ? string.Empty : row["ContractNumber"].ToString().ToUpper()) + "</TD>");
                    sb.Append("<TD>" + ((row["Description"] == DBNull.Value || row["Description"] == null) ? string.Empty : row["Description"].ToString().ToUpper()) + "</TD>");
                    sb.Append("<TD>" + ((row["Quantity"] == DBNull.Value || row["Quantity"] == null) ? string.Empty : row["Quantity"].ToString().ToUpper()) + "</TD>");
                    sb.Append("<TD>" + fabric + "</TD>");
                    sb.Append("<TD>" + ((row["STCUnallocated"] == DBNull.Value || row["STCUnallocated"] == null) ? string.Empty : Convert.ToDateTime(row["STCUnallocated"]).ToString("dd MMM yy (ddd)")) + "</TD>");
                    string FitStatus = string.Empty;


                    if (row["CommentsSentFor"] != DBNull.Value && !string.IsNullOrEmpty(row["CommentsSentFor"].ToString()))
                    {
                        bool isSTCApproved = ((row["StcApproved"]) == DBNull.Value) ? false : Convert.ToBoolean(row["StcApproved"]);

                        if (isSTCApproved)
                        {
                            FitStatus = "STC Approved On " + (((row["SealDate"]) == DBNull.Value) ? DateTime.MinValue.ToString("dd MMM yy (ddd)") : Convert.ToDateTime((row["SealDate"])).ToString("dd MMM yy (ddd)"));

                        }
                        else
                        {
                            DateTime AckDate = ((row["AckDate"]) == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime((row["AckDate"]));
                            string plannedFor = (((row["PlanningFor"]) == DBNull.Value) ? string.Empty : Convert.ToString((row["PlanningFor"])));

                            if (plannedFor.IndexOf("STC") > -1)
                                FitStatus = plannedFor + " Requested on " + (((row["FITRequestedOn"]) == DBNull.Value) ? DateTime.MinValue.ToString("dd MMM yy (ddd)") : Convert.ToDateTime((row["FITRequestedOn"])).ToString("dd MMM yy (ddd)"));
                            else if (AckDate == DateTime.MinValue)
                                FitStatus = (((row["CommentsSentFor"]) == DBNull.Value) ? string.Empty : Convert.ToString((row["CommentsSentFor"]))) + " Comment Received on " + (((row["FITRequestedOn"]) == DBNull.Value) ? DateTime.MinValue.ToString("dd MMM yy (ddd)") : Convert.ToDateTime((row["FITRequestedOn"])).ToString("dd MMM yy (ddd)"));
                            else
                                FitStatus = plannedFor + " Sent on " + (((row["AckDate"]) == DBNull.Value) ? DateTime.MinValue.ToString("dd MMM yy (ddd)") : Convert.ToDateTime((row["AckDate"])).ToString("dd MMM yy (ddd)"));
                        }
                    }
                    else
                    {
                        FitStatus = "Show Sealer Pending Form";
                    }

                    sb.Append("<TD>" + FitStatus + "</TD>");
                    sb.Append("<TD>" + ((row["TopSentTarget"] == DBNull.Value || row["TopSentTarget"] == null) ? string.Empty : row["TopSentTarget"].ToString().ToUpper()) + "</TD>");

                    int Quantity = 0;
                    double Cutting = 0;
                    double Stiching = 0;
                    double Packing = 0;

                    if (row["Quantity"] != DBNull.Value)
                    {
                        Quantity = Convert.ToInt32(row["Quantity"]);
                    }

                    if (Quantity > 0)
                    {
                        if (row["PcsCut"] != DBNull.Value)
                        {
                            Cutting = Convert.ToInt32((Convert.ToDouble(row["PcsCut"]) / Quantity) * 100);
                        }

                        if (row["PcsStitched"] != DBNull.Value)
                        {
                            Stiching = Convert.ToInt32((Convert.ToDouble(row["PcsStitched"]) / Quantity) * 100);
                        }

                        if (row["PcsPacked"] != DBNull.Value)
                        {
                            Packing = Convert.ToInt32((Convert.ToDouble(row["PcsPacked"]) / Quantity) * 100);
                        }
                    }

                    sb.Append("<TD>" + Cutting.ToString("N0") + "%</TD>");
                    sb.Append("<TD>" + Stiching.ToString("N0") + "%</TD>");
                    sb.Append("<TD>" + Packing.ToString("N0") + "%</TD>");
                    exFactory = ((row["ExFactory"]) == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(row["ExFactory"]);
                    sb.Append("<TD style='background-color:" + exBgColor + "'>" + (exFactory == DateTime.MinValue ? string.Empty : exFactory.ToString("dd MMM yy (ddd)")) + "</TD>");
                    sb.Append("<TD>" + dc.ToString("dd MMM yy (ddd)") + "</TD>");
                    sb.Append("<TD>" + CurrencySymbolBIPL + " " + ((row["BIPLPrice"] == DBNull.Value || row["BIPLPrice"] == null) ? string.Empty : Convert.ToDouble(row["BIPLPrice"]).ToString("N2")) + "</TD>");
                    sb.Append("<TD>" + CurrencySymbolIkandi + " " + ((row["iKandiPrice"] == DBNull.Value || row["iKandiPrice"] == null) ? string.Empty : Convert.ToDouble(row["iKandiPrice"]).ToString("N2")) + "</TD>");
                    sb.Append("<TD>" + ((row["StatusMode"] == DBNull.Value || row["StatusMode"] == null) ? string.Empty : row["StatusMode"].ToString()) + "</TD>");
                    sb.Append("<TD>" + ((row["FactoryCode"] == DBNull.Value || row["FactoryCode"] == null) ? string.Empty : row["FactoryCode"].ToString()) + "</TD>");
                    sb.Append("</TR>");

                    //if (row["clientid"] != DBNull.Value || Convert.ToString(row["clientid"]) != string.Empty || Convert.ToInt32(row["clientid"]) > 0)
                    //{
                    //    int clientId = Convert.ToInt32(row["clientid"]);



                    //    List<User> userListWithClient = GetUserInfo(new List<String>(), objDesignationBasedOnClient, new List<String>(), clientId);
                    //    foreach (User user in userListWithClient)
                    //    {
                    //        if (to.Contains(user.Email))
                    //        {
                    //            continue;
                    //        }
                    //        else
                    //        {
                    //            to.Add(user.Email);
                    //        }
                    //    }


                    //}
                }

                sb.Append("</TABLE>");

                //get User Data
                List<User> userList = GetUserInfo(new List<String>(), designationList, departmentList, 0);
                List<User> userListCC = GetUserInfo(new List<String>(), designationListcc, departmentList, 0);

                String fromName = BLLCache.GetConfigurationKeyValue("FROMEMAIL");

                //foreach (User user in userList)
                //{
                //    if (to.Contains(user.Email))
                //    {
                //        continue;
                //    }
                //    else
                //    {
                //        to.Add(user.Email);

                //    }
                //}

                //foreach (User user in userListCC)
                //{
                //    if (cc.Contains(user.Email))
                //    {
                //        continue;
                //    }
                //    else
                //    {
                //        cc.Add(user.Email);

                //    }
                //}

                //Abhishek
                SendMailUsingKeyValue("Ikandi.SendMailOrderRateChange", out to);


                //to.Add("bipl_sales@boutique.in");
                //to.Add("bipl_merchandising@boutique.in");
                //to.Add("ikandi_sales@ikandi.org.uk");
                //to.Add("hitesh@boutique.in");
                //to.Add("sanjeev@boutique.in");

                //END
                template.Content = template.Content.Replace("[[STYLES_TABLE]]", sb.ToString());

                System.Diagnostics.Trace.WriteLine("Processing of Send Costing Rate Change Mail having Subject ----" + template.Subject + "has been started on " + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                this.SendEmail(fromName, to, null, null, template.Subject.ToUpper(), template.Content, null, false, false);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in Costing Rate Change Mail on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
               // this.SendErrorEmail(ex.Message + "\n" + ex.StackTrace);

            }
        }


        public void SendSamplePendingOverAWeekEmail()
        {
            try
            {
                bool bIkandi = false;
                bool bNonIkandi = false;
                EmailTemplate template = this.AdminDataProviderInstance.GetEmailTemplateByType(EmailTemplateType.SAMPLEPENDINGEMAIL);
                EmailTemplate templateNonIkandi = this.AdminDataProviderInstance.GetEmailTemplateByType(EmailTemplateType.SAMPLEPENDINGEMAIL);

                List<String> departmentList = new List<String>();
                List<String> designationList = new List<string>();
                List<String> designationListcc = new List<string>();
                string WithClientDesignationIDs;
                string WithNoClientDesignationIDs;

                GetClientAssociatedDesignationID(template.DesignationIDs, out  WithClientDesignationIDs, out  WithNoClientDesignationIDs);

                departmentList.AddRange(template.DepartmentIDs.Split(new char[] { ',' }));
                designationList.AddRange(WithNoClientDesignationIDs.Split(new char[] { ',' }));
                designationListcc.Add("10");
                List<String> to = new List<String>();
                List<String> cc = new List<String>();
                StringBuilder sb = new StringBuilder();
                StringBuilder sbq = new StringBuilder();
                bIkandi = this.FITsDataProviderInstance.GetSamplePendingComments_WithPrice_CheckIkandi(1);
                bNonIkandi = this.FITsDataProviderInstance.GetSamplePendingComments_WithPrice_CheckIkandi(2);
                if (bIkandi == true)
                {
                    DataSet ds = this.FITsDataProviderInstance.GetSamplePendingComments_WithPrice(1);
                    DataTable dt = ds.Tables[0];

                    if (dt.Rows.Count != 0)
                        sb = SamplePending(ds);

                }
                if (bNonIkandi == true)
                {
                    DataSet ds = this.FITsDataProviderInstance.GetSamplePendingComments_WithPrice(2);
                    DataTable dt = ds.Tables[0];
                    if (dt.Rows.Count != 0)
                        sbq = SamplePending(ds);
                }

                List<User> userList = GetUserInfo(new List<String>(), designationList, departmentList, 0);
                List<User> userListCC = GetUserInfo(new List<String>(), designationListcc, departmentList, 0);

                String fromName = BLLCache.GetConfigurationKeyValue("FROMEMAIL");





                System.Diagnostics.Trace.WriteLine("Processing of FITS Comments pending having Subject ----" + template.Subject + "has been started on " + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                if (bIkandi == true)
                {
                    template.Content = template.Content.Replace("[[STYLES_TABLE]]", sb.ToString());
                    // if (template.Content.Length > 874)
                    //Abhishek
                    SendMailUsingKeyValue("Ikandi.SendSamplePendingOverAWeekEmail", out to);


                    //to.Add("bipl_fit_merch@boutique.in");
                    //to.Add("bipl_accountmanagers@boutique.in");
                    //// to.Add("bipl_qateam@boutique.in");
                    //to.Add("ikandi_technical@ikandi.org.uk");
                    //to.Add("ikandi_sales@ikandi.org.uk");
                    //to.Add("hitesh@boutique.in");
                    //to.Add("sanjeev@boutique.in");
                    //to.Add("jaiprakash@boutique.in");

                    //END
                    this.SendEmail(fromName, to, null, null, template.Subject.ToUpper(), template.Content, null, false, false);
                    to.Clear();
                }
                if (bNonIkandi == true)
                {
                    // to boutique
                    templateNonIkandi.Content = templateNonIkandi.Content.Replace("[[STYLES_TABLE]]", sbq.ToString());
                    // if (templateNonIkandi.Content.Length > 874)
                    //Abhishek
                    SendMailUsingKeyValue("BIPL.SendSamplePendingOverAWeekEmail", out to);


                    //to.Add("bipl_fit_merch@boutique.in");
                    //to.Add("bipl_accountmanagers@boutique.in");
                    //to.Add("jaiprakash@boutique.in");
                    //to.Add("hitesh@boutique.in");
                    //to.Add("sanjeev@boutique.in");

                    //END
                    this.SendEmail(fromName, to, null, null, templateNonIkandi.Subject.ToUpper(), templateNonIkandi.Content, null, false, false);
                    to.Clear();
                }

            }



            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in FITS Comments pending Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
              //  this.SendErrorEmail(ex.Message + "\n" + ex.StackTrace);

            }
        }

        public void SendSampleBIRTHDAYMail()
        {
            try
            {
                EmailTemplate template = this.AdminDataProviderInstance.GetEmailTemplateByType(EmailTemplateType.BirthdayMail);

                List<String> departmentList = new List<String>();
                List<String> designationList = new List<string>();
                List<String> designationListcc = new List<string>();
                // string WithClientDesignationIDs;
                // string WithNoClientDesignationIDs;

                //  GetClientAssociatedDesignationID(template.DesignationIDs, out  WithClientDesignationIDs, out  WithNoClientDesignationIDs);

                // departmentList.AddRange(template.DepartmentIDs.Split(new char[] { ',' }));
                //  designationList.AddRange(WithNoClientDesignationIDs.Split(new char[] { ',' }));
                //  designationListcc.Add("10");
                List<String> to = new List<String>();
                List<String> cc = new List<String>();

                //DataSet ds = this.FITsDataProviderInstance.GetSamplePendingComments_WithPrice();

                StringBuilder sb = new StringBuilder();

                //sb.Append("<TABLE border=1 cellpadding=5>");
                //sb.Append("<TR>");
                //sb.Append("<TH>ORDER DATE</TH>");
                //sb.Append("<TH>SERIAL NUMBER</TH>");
                //sb.Append("<TH>DEPT.</TH>");
                //sb.Append("<TH>STYLE</TH>");
                //sb.Append("<TH>LINE #</TH>");
                //sb.Append("<TH>CONTRACT</TH>");
                //sb.Append("<TH>DESC.</TH>");
                //sb.Append("<TH>QTY.</TH>");
                //sb.Append("<TH>FABRIC</TH>");
                //sb.Append("<TH>STC TGT.</TH>");
                //sb.Append("<TH>FIT STATUS</TH>");
                //sb.Append("<TH>MODE</TH>");
                //sb.Append("<TH>Ex-FACTORY</TH>");
                //sb.Append("<TH>DC DATE</TH>");
                //sb.Append("</TR>");
                sb.Append("<html>");
                sb.Append("<head>");

                sb.Append("<style type='text/css'>");
                sb.Append("body { font: 100% Verdana, Arial, Helvetica, sans-serif;margin: 0;padding: 0;text-align:center;color:#FFFFFF;}");
                sb.Append(".oneColFixCtr #container { width:759px;background: #FFFFFF; margin: 0 auto;text-align: left; background-image:url(http:/www.boutique.in:81/App_Themes/ikandi/images1/Birthday.jpg);background-repeat:no-repeat;height:550px; }");
                sb.Append(".oneColFixCtr #mainContent { padding: 0 20px; }");
                sb.Append("h1 {font-family:Brush Script MT; font-weight:lighter; font-size:50px; text-align:center;}");
                sb.Append("h2{font-family:Century Gothic; font-weight:100; font-size:18px; text-align:center;}");
                sb.Append("</style>");
                sb.Append("</head>");
                sb.Append("<body class='oneColFixCtr'>");
                sb.Append("<div id='container'>");
                sb.Append("<table width='759px' background='http:/www.boutique.in:81/App_Themes/ikandi/images1/Birthday.jpg'>");
                sb.Append("<tr><td>");
                sb.Append("<div id='mainContent'><p>&nbsp;</p><h1> Dear&nbsp;Prashant </h1><p>&nbsp;</p><p>&nbsp;</p><p>&nbsp;</p><p>&nbsp;</p><p>&nbsp;</p><p>&nbsp;</p><p>&nbsp;</p><p>&nbsp;</p><p>&nbsp;</p><p>&nbsp;</p><h2>From: Boutique International Pvt Ltd</h2></div>");
                sb.Append("</div>");
                sb.Append("</td></tr></table>");
                sb.Append("</div>");
                sb.Append("</body>");

                sb.Append("</html>");
                //sb.Append("<TH>STC TGT.</TH>");
                //sb.Append("<TH>FIT STATUS</TH>");
                //sb.Append("<TH>MODE</TH>");
                //sb.Append("<TH>Ex-FACTORY</TH>");
                //sb.Append("<TH>DC DATE</TH>");
                //sb.Append("</TR>");

                //DataTable dt = ds.Tables[0];

                //if (dt.Rows.Count == 0)
                //    return;

                // List<String> objDesignationBasedOnClient = new List<string>();
                // objDesignationBasedOnClient.AddRange(WithClientDesignationIDs.Split(new char[] { ',' }));

                //objDesignationBasedOnClient.Add(Convert.ToInt32(Designation.BIPL_Merchandising_AccountManager).ToString());
                //objDesignationBasedOnClient.Add(Convert.ToInt32(Designation.BIPL_Merchandising_FitMerchant).ToString());
                //objDesignationBasedOnClient.Add(Convert.ToInt32(Designation.iKandi_Sales_SalesManager).ToString());
                //objDesignationBasedOnClient.Add(Convert.ToInt32(Designation.iKandi_Technical_Technologist).ToString());
                //objDesignationBasedOnClient.Add(Convert.ToInt32(Designation.BIPL_Sales_Manager).ToString());






                // List<User> userListWithClient = GetUserInfo(new List<String>(), objDesignationBasedOnClient, new List<String>(), 0);
                //foreach (User user in userListWithClient)
                //{
                //    if (to.Contains(user.Email))
                //    {
                //        continue;
                //    }
                //    else
                //    {
                //        to.Add(user.Email);
                //    }
                //}







                // A/c manager, Merch. Mgrs, Fit Merchant, BIPL Sales Mgrs, ikandi Technical Team, ikandi sales Team.              
                //objDesignationList.Add(Convert.ToInt32(Designation.BIPL_Merchandising_Manager).ToString());
                //objDesignationList.Add(Convert.ToInt32(Designation.BIPL_Sales_Manager).ToString());
                //objDesignationList.Add(Convert.ToInt32(Designation.iKandi_Sales_Manager).ToString());
                //objDesignationList.Add(Convert.ToInt32(Designation.iKandi_Technical_Manager).ToString());


                //get User Data
                //List<User> userList = GetUserInfo(new List<String>(), designationList, departmentList, 0);
                //List<User> userListCC = GetUserInfo(new List<String>(), designationListcc, departmentList, 0);

                String fromName = BLLCache.GetConfigurationKeyValue("FROMEMAIL");

                //foreach (User user in userList)
                //{
                //    if (to.Contains(user.Email))
                //    {
                //        continue;
                //    }
                //    else
                //    {
                //        to.Add(user.Email);

                //    }
                //}

                //foreach (User user in userListCC)
                //{
                //    if (cc.Contains(user.Email))
                //    {
                //        continue;
                //    }
                //    else
                //    {
                //        cc.Add(user.Email);

                //    }
                //}


                //template.Content = template.Content.Replace("[[STYLES_TABLE]]", sb.ToString());
                template.Content = sb.ToString();

                // System.Diagnostics.Trace.WriteLine("Processing of FITS Comments pending having Subject ----" + template.Subject + "has been started on " + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                this.SendEmail(fromName, to, cc, null, template.Subject.ToUpper(), template.Content, null, false, false);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in FITS Comments pending Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
              //  this.SendErrorEmail(ex.Message + "\n" + ex.StackTrace);

            }
        }
        public StringBuilder OrderDelivered(List<OrderDetail> orderDetail)
        {
            StringBuilder sb = new StringBuilder();
            string partnerName = string.Empty;
            if (orderDetail.Count > 0)
            {
                sb.Append("<TABLE border=1 cellpadding=5>");
                sb.Append("<TR>");
                sb.Append("<TH>CLIENT</TH>");
                sb.Append("<TH>SERIAL NUMBER</TH>");
                sb.Append("<TH>STYLE NUMBER </TH>");
                sb.Append("<TH>STYLE</TH>");
                sb.Append("<TH>LINE NUMBER</TH>");
                sb.Append("<TH>CONTRACT NUMBER</TH>");
                sb.Append("<TH>DELEVERED QTY</TH>");
                sb.Append("</TR>");

                foreach (OrderDetail od in orderDetail)
                {
                    string imageUrl = (od.ParentOrder.Style.SampleImageURL1 == null) ? string.Empty : od.ParentOrder.Style.SampleImageURL1.ToString();
                    sb.Append("<TR>");
                    sb.Append("<TD>" + ((od.ParentOrder.Style.client.CompanyName == null) ? string.Empty : od.ParentOrder.Style.client.CompanyName.ToString().ToUpper()) + "</TD>");
                    sb.Append("<TD>" + ((od.ParentOrder.SerialNumber == null) ? string.Empty : od.ParentOrder.SerialNumber.ToString().ToUpper()) + "</TD>");
                    sb.Append("<TD>" + ((od.ParentOrder.Style.StyleNumber == null) ? string.Empty : od.ParentOrder.Style.StyleNumber.ToString().ToUpper()) + "</TD>");
                    sb.Append("<TD><div><IMG SRC='" + Constants.SITE_BASE_URL + "/uploads/style/thumb-" + imageUrl + "'  /></div></TD>");
                    sb.Append("<TD>" + ((od.LineItemNumber == null) ? string.Empty : od.LineItemNumber.ToString().ToUpper()) + "</TD>");
                    sb.Append("<TD>" + ((od.ContractNumber == null) ? string.Empty : od.ContractNumber.ToString().ToUpper()) + "</TD>");
                    sb.Append("<TD>" + ((od.Quantity == 0) ? string.Empty : od.Quantity.ToString("N0")) + "</TD>");
                    sb.Append("</TR>");

                    bool isFirstPartnerNameExist = false;
                    bool isSecondPartnerNameExist = false;
                    if (partnerName.Contains(od.FirstPartnerName.ToUpper().Trim()))
                    {
                        isFirstPartnerNameExist = true;

                    }
                    else
                    {
                        if (od.FirstPartnerName != string.Empty && isFirstPartnerNameExist != true)
                        {
                            if (partnerName == string.Empty)
                            {
                                partnerName = od.FirstPartnerName.ToUpper();
                            }
                            else
                            {
                                partnerName = partnerName + "," + od.FirstPartnerName.ToUpper();
                            }
                        }
                    }

                    if (partnerName.Contains(od.SecondPartnerName.ToUpper().Trim()))
                    {
                        isSecondPartnerNameExist = true;

                    }
                    else
                    {


                        if (od.SecondPartnerName != string.Empty && isSecondPartnerNameExist != true)
                        {
                            if (partnerName == string.Empty)
                            {
                                partnerName = od.SecondPartnerName.ToUpper();
                            }
                            else
                            {
                                partnerName = partnerName + "," + od.SecondPartnerName.ToUpper();
                            }
                        }
                    }
                }

                sb.Append("</TABLE>");



            }
            return sb;
        }
        public StringBuilder OrderByCurrentDat_OrderRemarks(List<iKandi.Common.Order> order, DateTime date)
        {
            // StringBuilder sb = new StringBuilder();
            string client = string.Empty;
            StringBuilder sb = new StringBuilder();
            sb.Append("<TABLE cellpadding=5 border=1>");
            sb.Append("<TR>");
            sb.Append("<TH>SERIAL NUMBER</TH>");
            sb.Append("<TH>CHANGES</TH>");
            sb.Append("</TR>");

            foreach (iKandi.Common.Order ord in order)
            {
                if (client != "")
                {
                    client = client + "," + ord.ClientID.ToString();
                }
                else
                {
                    client = ord.ClientID.ToString();
                }

                string history = "";
                history = ord.History;

                if (ord.History.IndexOf(date.ToString("dd MMM yy (ddd)")) > -1)
                {
                    history = ord.History.Substring(ord.History.IndexOf(date.ToString("dd MMM yy (ddd)")));
                    string orderHistory = history.ToUpper() + "<BR/>";
                    history = string.Empty;
                    string[] delim = { "<BR/>" };
                    string[] stringArray = orderHistory.Split(delim, StringSplitOptions.None);

                    if (stringArray.Length > 0)
                    {
                        for (int i = 0; i < stringArray.Length; i++)
                        {
                            if (stringArray[i].Trim() != string.Empty)
                            {
                                if (stringArray[i].Trim().ToUpper().IndexOf("FACTORY CHANGED ON MO") > -1 || stringArray[i].Trim().ToUpper().IndexOf("EX-FACTORY CHANGED ON ORDER FORM") > -1)
                                {
                                    history = history + "";
                                }
                                else if (stringArray[i].Trim().ToUpper().IndexOf("EXFACTORY CHANGED") > -1 && stringArray[i].Trim().ToUpper().IndexOf("FROM MO") == -1)
                                {
                                    history = history + "";
                                }
                                else
                                {
                                    history = history + stringArray[i].Trim().ToUpper() + "<br/>";
                                }
                            }
                        }
                    }
                }
                else
                {
                    history = string.Empty;
                }

                if (history == string.Empty)
                {
                    continue;
                }
                else
                {
                    sb.Append("<TR>");
                    sb.Append("<TD>" + ord.SerialNumber.ToUpper() + "</TD>");

                    sb.Append("<TD style='text-align : left;'>" + history.ToUpper() + "</TD>");
                    sb.Append("</TR>");
                }

            }
            sb.Append("</TABLE>");

            if (sb.ToString().ToUpper().IndexOf("<TD>") > -1)
            {
                //System.Diagnostics.Trace.WriteLine("Order form changes Email process starts of the date " + date.ToString("dd MM yy (ddd)") + " on " + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                //this.NotificationControllerInstance.SendEmailForEditOrder(sb.ToString(), "", new List<String>(), 0, true, 1, client);
            }
            return sb;
        }
        public StringBuilder SamplePending(DataSet ds)
        {
            StringBuilder sb = new StringBuilder();


            sb.Append("<TABLE border=1 cellpadding=5>");
            sb.Append("<TR>");
            sb.Append("<TH>ORDER DATE</TH>");
            sb.Append("<TH>SERIAL NUMBER</TH>");
            sb.Append("<TH>DEPT.</TH>");
            sb.Append("<TH>STYLE</TH>");
            sb.Append("<TH>LINE #</TH>");
            sb.Append("<TH>CONTRACT</TH>");
            sb.Append("<TH>DESC.</TH>");
            sb.Append("<TH>QTY.</TH>");
            sb.Append("<TH>FABRIC</TH>");
            sb.Append("<TH>STC TGT.</TH>");
            sb.Append("<TH>FIT STATUS</TH>");
            sb.Append("<TH>MODE</TH>");
            sb.Append("<TH>Ex-FACTORY</TH>");
            //sb.Append("<TH>DC DATE</TH>");
            sb.Append("</TR>");

            DataTable dt = ds.Tables[0];

            //if (dt.Rows.Count == 0)
            //    return sb;

            List<String> objDesignationBasedOnClient = new List<string>();
            //objDesignationBasedOnClient.AddRange(WithClientDesignationIDs.Split(new char[] { ',' }));

            //objDesignationBasedOnClient.Add(Convert.ToInt32(Designation.BIPL_Merchandising_AccountManager).ToString());
            //objDesignationBasedOnClient.Add(Convert.ToInt32(Designation.BIPL_Merchandising_FitMerchant).ToString());
            //objDesignationBasedOnClient.Add(Convert.ToInt32(Designation.iKandi_Sales_SalesManager).ToString());
            //objDesignationBasedOnClient.Add(Convert.ToInt32(Designation.iKandi_Technical_Technologist).ToString());
            //objDesignationBasedOnClient.Add(Convert.ToInt32(Designation.BIPL_Sales_Manager).ToString());

            foreach (DataRow row in dt.Rows)
            {
                string fabric = string.Empty;
                string fabric1 = (row["Fabric1"] == DBNull.Value || row["Fabric1"] == null) ? string.Empty : row["Fabric1"].ToString().ToUpper();
                string fabric2 = (row["Fabric2"] == DBNull.Value || row["Fabric2"] == null) ? string.Empty : row["Fabric2"].ToString().ToUpper();
                string fabric3 = (row["Fabric3"] == DBNull.Value || row["Fabric3"] == null) ? string.Empty : row["Fabric3"].ToString().ToUpper();
                string fabric4 = (row["Fabric4"] == DBNull.Value || row["Fabric4"] == null) ? string.Empty : row["Fabric4"].ToString().ToUpper();

                string CCGSM1 = (row["CCGSM1"] == DBNull.Value || row["CCGSM1"] == null) ? string.Empty : row["CCGSM1"].ToString().ToUpper();
                string CCGSM2 = (row["CCGSM2"] == DBNull.Value || row["CCGSM2"] == null) ? string.Empty : row["CCGSM2"].ToString().ToUpper();
                string CCGSM3 = (row["CCGSM3"] == DBNull.Value || row["CCGSM3"] == null) ? string.Empty : row["CCGSM3"].ToString().ToUpper();
                string CCGSM4 = (row["CCGSM4"] == DBNull.Value || row["CCGSM4"] == null) ? string.Empty : row["CCGSM4"].ToString().ToUpper();

                string CurrencySymbol = (row["CurrencySymbol"] == DBNull.Value || row["CurrencySymbol"] == null) ? string.Empty : row["CurrencySymbol"].ToString().ToUpper();
                string ModeText = (row["ModeText"] == DBNull.Value || row["ModeText"] == null) ? string.Empty : row["ModeText"].ToString().ToUpper();

                string fabric1Detail = (row["Fabric1Details"] == DBNull.Value || row["Fabric1Details"] == null) ? string.Empty : row["Fabric1Details"].ToString();
                string fabric2Detail = (row["Fabric2Details"] == DBNull.Value || row["Fabric2Details"] == null) ? string.Empty : row["Fabric2Details"].ToString();
                string fabric3Detail = (row["Fabric3Details"] == DBNull.Value || row["Fabric3Details"] == null) ? string.Empty : row["Fabric3Details"].ToString();
                string fabric4Detail = (row["Fabric4Details"] == DBNull.Value || row["Fabric4Details"] == null) ? string.Empty : row["Fabric4Details"].ToString();


                var Fab1Det = fabric1Detail.Trim().Split(' ');

                var Fab2Det = fabric2Detail.Trim().Split(' ');

                var Fab3Det = fabric3Detail.Trim().Split(' ');

                var Fab4Det = fabric4Detail.Trim().Split(' ');

                int result;
                if (!string.IsNullOrEmpty(Fab1Det[0]) && Int32.TryParse(Fab1Det[0], out result) && (Fab1Det.Length == 1 || (Fab1Det.Length == 2 && Fab1Det[1].Length <= 2)))
                {
                    fabric1Detail = "PRD:" + fabric1Detail;
                    result = 0;
                }

                if (!string.IsNullOrEmpty(Fab2Det[0]) && Int32.TryParse(Fab2Det[0], out result) && (Fab2Det.Length == 1 || (Fab2Det.Length == 2 && Fab2Det[1].Length <= 2)))
                {
                    fabric2Detail = "PRD:" + fabric2Detail;
                    result = 0;
                }

                if (!string.IsNullOrEmpty(Fab3Det[0]) && Int32.TryParse(Fab3Det[0], out result) && (Fab3Det.Length == 1 || (Fab3Det.Length == 2 && Fab3Det[1].Length <= 2)))
                {
                    fabric3Detail = "PRD:" + fabric3Detail;
                    result = 0;
                }

                if (!string.IsNullOrEmpty(Fab4Det[0]) && Int32.TryParse(Fab4Det[0], out result) && (Fab4Det.Length == 1 || (Fab4Det.Length == 2 && Fab4Det[1].Length <= 2)))
                {
                    fabric4Detail = "PRD:" + fabric4Detail;
                    result = 0;
                }

                if (fabric1Detail.Trim() != string.Empty)
                {
                    fabric1Detail = " : " + fabric1Detail.ToUpper();
                    fabric = fabric1 + fabric1Detail;
                    if (CCGSM1 != string.Empty)
                    {
                        fabric = fabric + "<BR><span style='color:black'>" + CCGSM1 + "</span>";
                    }
                }
                else if (fabric1.Trim() != string.Empty)
                {
                    fabric = fabric1;
                    if (CCGSM1 != string.Empty)
                    {
                        fabric = fabric + "<BR><span style='color:black'>" + CCGSM1 + "</span>";
                    }
                }

                if (fabric2Detail.Trim() != string.Empty)
                {
                    fabric2Detail = " : " + fabric2Detail.ToUpper();
                    fabric = fabric + "<BR>" + fabric2 + fabric2Detail;
                    if (CCGSM2 != string.Empty)
                    {
                        fabric = fabric + "<BR><span style='color:black'>" + CCGSM2 + "</span>";
                    }
                }
                else if (fabric2.Trim() != string.Empty)
                {
                    fabric = fabric + "<BR>" + fabric2;
                    if (CCGSM2 != string.Empty)
                    {
                        fabric = fabric + "<BR><span style='color:black'>" + CCGSM2 + "</span>";
                    }
                }

                if (fabric3Detail.Trim() != string.Empty)
                {
                    fabric3Detail = " : " + fabric3Detail.ToUpper();
                    fabric = fabric + "<BR>" + fabric3 + fabric3Detail;
                    if (CCGSM3 != string.Empty)
                    {
                        fabric = fabric + "<BR><span style='color:black'>" + CCGSM3 + "</span>";
                    }
                }
                else if (fabric3.Trim() != string.Empty)
                {
                    fabric = fabric + "<BR>" + fabric3;
                    if (CCGSM3 != string.Empty)
                    {
                        fabric = fabric + "<BR><span style='color:black'>" + CCGSM3 + "</span>";
                    }
                }

                if (fabric4Detail.Trim() != string.Empty)
                {
                    fabric4Detail = " : " + fabric4Detail.ToUpper();
                    fabric = fabric + "<BR>" + fabric4 + fabric4Detail;
                    if (CCGSM4 != string.Empty)
                    {
                        fabric = fabric + "<BR><span style='color:black'>" + CCGSM4 + "</span>";
                    }
                }
                else if (fabric4.Trim() != string.Empty)
                {
                    fabric = fabric + "<BR>" + fabric4;
                    if (CCGSM4 != string.Empty)
                    {
                        fabric = fabric + "<BR><span style='color:black'>" + CCGSM4 + "</span>";
                    }
                }

                //fabric = fabric1 + fabric1Detail; 

                DateTime exFactory = DateTime.MinValue;
                DateTime dc = DateTime.MinValue;
                int mode = -1;

                if (row["Exfactory"] != DBNull.Value && row["Exfactory"] != null)
                    exFactory = Convert.ToDateTime(row["Exfactory"]);

                if (row["DC"] != DBNull.Value && row["DC"] != null)
                    dc = Convert.ToDateTime(row["DC"]);

                if (row["Mode"] != DBNull.Value && row["Mode"] != null)
                    mode = Convert.ToInt32(row["Mode"]);


                string exBgColor = iKandi.BLL.CommonHelper.GetExFactoryColor(exFactory, dc, mode);

                string imageUrl = ((row["SampleImageURL1"] == DBNull.Value || row["SampleImageURL1"] == null) ? string.Empty : row["SampleImageURL1"].ToString());
                if (row["CompanyName"].ToString().ToUpper() == "XnY.in".ToUpper())
                {
                    continue;
                }

                sb.Append("<TR>");
                sb.Append("<TD>" + ((row["OrderDate"] == DBNull.Value || row["OrderDate"] == null) ? string.Empty : Convert.ToDateTime(row["OrderDate"]).ToString("dd MMM yy (ddd)")) + "</TD>");
                sb.Append("<TD>" + ((row["SerialNumber"] == DBNull.Value || row["SerialNumber"] == null) ? string.Empty : row["SerialNumber"].ToString().ToUpper()) + "</TD>");
                sb.Append("<TD>" + ((row["DepartmentName"] == DBNull.Value || row["DepartmentName"] == null) ? string.Empty : row["DepartmentName"].ToString().ToUpper()) + "</TD>");
                sb.Append("<TD>" + ((row["StyleNumber"] == DBNull.Value || row["StyleNumber"] == null) ? string.Empty : row["StyleNumber"].ToString().ToUpper()));
                sb.Append("<div><IMG SRC='" + Constants.SITE_BASE_URL + "/uploads/style/thumb-" + imageUrl + "'  /></div></TD>");
                sb.Append("<TD>" + ((row["LineItemNumber"] == DBNull.Value || row["LineItemNumber"] == null) ? string.Empty : row["LineItemNumber"].ToString().ToUpper()) + "</TD>");
                sb.Append("<TD>" + ((row["ContractNumber"] == DBNull.Value || row["ContractNumber"] == null) ? string.Empty : row["ContractNumber"].ToString().ToUpper()) + "</TD>");
                sb.Append("<TD>" + ((row["Description"] == DBNull.Value || row["Description"] == null) ? string.Empty : row["Description"].ToString().ToUpper()) + "</TD>");
                sb.Append("<TD>" + ((row["Quantity"] == DBNull.Value || row["Quantity"] == null) ? string.Empty : row["Quantity"].ToString().ToUpper()) + "</TD>");
                sb.Append("<TD>" + fabric + "</TD>");
                sb.Append("<TD>" + ((row["STCTGT"] == DBNull.Value || row["STCTGT"] == null) ? string.Empty : row["STCTGT"].ToString().ToUpper()) + "</TD>");
                string planningFor = (row["PlanningFor"] == DBNull.Value || row["PlanningFor"] == null) ? string.Empty : row["PlanningFor"].ToString();
                sb.Append("<TD>" + planningFor + "</TD>");
                sb.Append("<TD>" + Convert.ToString(ModeText) + "</TD>");
                sb.Append("<TD style='background-color:" + exBgColor + "'>" + (exFactory == DateTime.MinValue ? string.Empty : exFactory.ToString("dd MMM yy (ddd)")) + "</TD>");
                //sb.Append("<TD>" + dc.ToString("dd MMM yy (ddd)") + "</TD>");
                //sb.Append("<TD>" + ((row["iKandiPrice"] == DBNull.Value || row["iKandiPrice"] == null) ? string.Empty : CurrencySymbol + " " + row["iKandiPrice"].ToString().ToUpper()) + "</TD>");

                // sb.Append("<TD>" + ((row["CompanyName"] == DBNull.Value || row["CompanyName"] == null) ? string.Empty : row["CompanyName"].ToString().ToUpper()) + "</TD>");
                // sb.Append("<TD>" + ((row["STCTGT"] == DBNull.Value || row["STCTGT"] == null) ? string.Empty : Convert.ToDateTime(row["STCTGT"]).ToString("dd MMM yy (ddd)")) + "</TD>");



                sb.Append("</TR>");

                if (row["clientid"] != DBNull.Value || Convert.ToString(row["clientid"]) != string.Empty || Convert.ToInt32(row["clientid"]) > 0)
                {
                    int clientId = Convert.ToInt32(row["clientid"]);



                    List<User> userListWithClient = GetUserInfo(new List<String>(), objDesignationBasedOnClient, new List<String>(), clientId);
                    //foreach (User user in userListWithClient)
                    //{
                    //    if (to.Contains(user.Email))
                    //    {
                    //        continue;
                    //    }
                    //    else
                    //    {
                    //        //to.Add(user.Email);
                    //    }
                    //}
                    // edit by surendra on 06-Nov-2014




                }
            }

            sb.Append("</TABLE>");
            return sb;
        }
        public StringBuilder FitsUploaded(DataSet ds)
        {
            StringBuilder sb = new StringBuilder();


            sb.Append("<TABLE border=1 cellpadding=5>");
            sb.Append("<TR>");
            sb.Append("<TH>BUYER</TH>");
            sb.Append("<TH>DEPT.</TH>");
            sb.Append("<TH>ORDER DATE</TH>");
            sb.Append("<TH>SERIAL NUMBER</TH>");
            sb.Append("<TH>STYLE</TH>");
            sb.Append("<TH>STC TGT</TH>");
            sb.Append("<TH>COMMENTS SENT FOR</TH>");
            sb.Append("</TR>");

            DataTable dt = ds.Tables[0];

            foreach (DataRow row in dt.Rows)
            {
                string imageUrl = ((row["SampleImageURL1"] == DBNull.Value || row["SampleImageURL1"] == null) ? string.Empty : row["SampleImageURL1"].ToString());
                //if (row["CompanyName"].ToString().ToUpper() == "XnY.in".ToUpper() || row["CompanyName"].ToString().ToUpper() == "dash".ToUpper() || row["CompanyName"].ToString().ToUpper() == "nougat".ToUpper() || row["CompanyName"].ToString().ToUpper() == "DKNY".ToUpper() || row["CompanyName"].ToString().ToUpper() == "american eagle".ToUpper() || row["CompanyName"].ToString().ToUpper() == "FORC. CO".ToUpper() || row["CompanyName"].ToString().ToUpper() == "DMC".ToUpper() || row["CompanyName"].ToString().ToUpper() == "BELk".ToUpper() || row["CompanyName"].ToString().ToUpper() == "Camaieu".ToUpper() || row["CompanyName"].ToString().ToUpper() == "foshini".ToUpper() || row["CompanyName"].ToString().ToUpper() == "Eminence".ToUpper() || row["CompanyName"].ToString().ToUpper() == "Sfera".ToUpper() || row["CompanyName"].ToString().ToUpper() == "matalan".ToUpper() || row["CompanyName"].ToString().ToUpper() == "ernstings family".ToUpper() || row["CompanyName"].ToString().ToUpper() == "acc".ToUpper() || row["CompanyName"].ToString().ToUpper() == "Bonprix".ToUpper())
                //{
                //    continue;
                //}
                sb.Append("<TR>");
                sb.Append("<TD>" + ((row["CompanyName"] == DBNull.Value || row["CompanyName"] == null) ? string.Empty : row["CompanyName"].ToString().ToUpper()) + "</TD>");
                sb.Append("<TD>" + ((row["DepartmentName"] == DBNull.Value || row["DepartmentName"] == null) ? string.Empty : row["DepartmentName"].ToString().ToUpper()) + "</TD>");
                sb.Append("<TD>" + ((row["OrderDate"] == DBNull.Value || row["OrderDate"] == null) ? string.Empty : Convert.ToDateTime(row["OrderDate"]).ToString("dd MMM yy (ddd)")) + "</TD>");
                sb.Append("<TD>" + ((row["SerialNumber"] == DBNull.Value || row["SerialNumber"] == null) ? string.Empty : row["SerialNumber"].ToString().ToUpper()) + "</TD>");
                sb.Append("<TD>" + ((row["StyleNumber"] == DBNull.Value || row["StyleNumber"] == null) ? string.Empty : row["StyleNumber"].ToString().ToUpper()));
                sb.Append("<div><IMG SRC='" + Constants.SITE_BASE_URL + "/uploads/style/thumb-" + imageUrl + "'  /></div></TD>");
                sb.Append("<TD>" + ((row["STCTGT"] == DBNull.Value || row["STCTGT"] == null) ? string.Empty : Convert.ToDateTime(row["STCTGT"]).ToString("dd MMM yy (ddd)")) + "</TD>");
                sb.Append("<TD>" + ((row["CommentsSentFor"] == DBNull.Value || row["CommentsSentFor"] == null) ? string.Empty : row["CommentsSentFor"].ToString().ToUpper()) + "</TD>");
                sb.Append("</TR>");

                if (row["clientid"] != DBNull.Value && Convert.ToString(row["clientid"]) != string.Empty && Convert.ToInt32(row["clientid"]) > 0)
                {
                    int clientId = Convert.ToInt32(row["clientid"]);

                    List<String> objDesignationBasedOnClient = new List<string>();
                    // objDesignationBasedOnClient.AddRange(WithClientDesignationIDs.Split(new char[] { ',' }));

                    //objDesignationBasedOnClient.Add(Convert.ToInt32(Designation.BIPL_Merchandising_AccountManager).ToString());
                    //objDesignationBasedOnClient.Add(Convert.ToInt32(Designation.BIPL_Merchandising_FitMerchant).ToString());
                    //objDesignationBasedOnClient.Add(Convert.ToInt32(Designation.iKandi_Sales_SalesManager).ToString());
                    //objDesignationBasedOnClient.Add(Convert.ToInt32(Designation.iKandi_Technical_Technologist).ToString());

                    List<User> userListWithClient = GetUserInfo(new List<String>(), objDesignationBasedOnClient, new List<String>(), clientId);
                    //foreach (User user in userListWithClient)
                    //{
                    //    if (to.Contains(user.Email))
                    //    {
                    //        continue;
                    //    }
                    //    else
                    //    {
                    //        to.Add(user.Email);
                    //    }
                    //}

                }
            }

            sb.Append("</TABLE>");
            return sb;
        }
        public StringBuilder SamplePendingWithPrice(DataSet ds)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<TABLE border=1 cellpadding=5>");
            sb.Append("<TR>");
            sb.Append("<TH>ORDER DATE</TH>");
            sb.Append("<TH>SERIAL NUMBER</TH>");
            sb.Append("<TH>DEPT.</TH>");
            sb.Append("<TH>STYLE</TH>");
            sb.Append("<TH>LINE #</TH>");
            sb.Append("<TH>CONTRACT</TH>");
            sb.Append("<TH>DESC.</TH>");
            sb.Append("<TH>QTY.</TH>");
            sb.Append("<TH>FABRIC</TH>");
            sb.Append("<TH>STC TGT.</TH>");
            sb.Append("<TH>FIT STATUS</TH>");
            sb.Append("<TH>MODE</TH>");
            sb.Append("<TH>Ex-FACTORY</TH>");
            //sb.Append("<TH>DC DATE</TH>");
            //sb.Append("<TH>PRICE</TH>");
            sb.Append("</TR>");

            DataTable dt = ds.Tables[0];

            //if (dt.Rows.Count == 0)
            //    return;

            List<String> objDesignationBasedOnClient = new List<string>();
            //objDesignationBasedOnClient.AddRange(WithClientDesignationIDs.Split(new char[] { ',' }));

            //objDesignationBasedOnClient.Add(Convert.ToInt32(Designation.BIPL_Merchandising_AccountManager).ToString());
            //objDesignationBasedOnClient.Add(Convert.ToInt32(Designation.BIPL_Merchandising_FitMerchant).ToString());
            //objDesignationBasedOnClient.Add(Convert.ToInt32(Designation.iKandi_Sales_SalesManager).ToString());
            //objDesignationBasedOnClient.Add(Convert.ToInt32(Designation.iKandi_Technical_Technologist).ToString());
            //objDesignationBasedOnClient.Add(Convert.ToInt32(Designation.BIPL_Sales_Manager).ToString());

            foreach (DataRow row in dt.Rows)
            {
                string fabric = string.Empty;
                string fabric1 = (row["Fabric1"] == DBNull.Value || row["Fabric1"] == null) ? string.Empty : row["Fabric1"].ToString().ToUpper();
                string fabric2 = (row["Fabric2"] == DBNull.Value || row["Fabric2"] == null) ? string.Empty : row["Fabric2"].ToString().ToUpper();
                string fabric3 = (row["Fabric3"] == DBNull.Value || row["Fabric3"] == null) ? string.Empty : row["Fabric3"].ToString().ToUpper();
                string fabric4 = (row["Fabric4"] == DBNull.Value || row["Fabric4"] == null) ? string.Empty : row["Fabric4"].ToString().ToUpper();

                string CCGSM1 = (row["CCGSM1"] == DBNull.Value || row["CCGSM1"] == null) ? string.Empty : row["CCGSM1"].ToString().ToUpper();
                string CCGSM2 = (row["CCGSM2"] == DBNull.Value || row["CCGSM2"] == null) ? string.Empty : row["CCGSM2"].ToString().ToUpper();
                string CCGSM3 = (row["CCGSM3"] == DBNull.Value || row["CCGSM3"] == null) ? string.Empty : row["CCGSM3"].ToString().ToUpper();
                string CCGSM4 = (row["CCGSM4"] == DBNull.Value || row["CCGSM4"] == null) ? string.Empty : row["CCGSM4"].ToString().ToUpper();

                string CurrencySymbol = (row["CurrencySymbol"] == DBNull.Value || row["CurrencySymbol"] == null) ? string.Empty : row["CurrencySymbol"].ToString().ToUpper();
                string ModeText = (row["ModeText"] == DBNull.Value || row["ModeText"] == null) ? string.Empty : row["ModeText"].ToString().ToUpper();

                string fabric1Detail = (row["Fabric1DetailsRef"] == DBNull.Value || row["Fabric1DetailsRef"] == null) ? string.Empty : row["Fabric1DetailsRef"].ToString();
                string fabric2Detail = (row["Fabric2DetailsRef"] == DBNull.Value || row["Fabric2DetailsRef"] == null) ? string.Empty : row["Fabric2DetailsRef"].ToString();
                string fabric3Detail = (row["Fabric3DetailsRef"] == DBNull.Value || row["Fabric3DetailsRef"] == null) ? string.Empty : row["Fabric3DetailsRef"].ToString();
                string fabric4Detail = (row["Fabric4DetailsRef"] == DBNull.Value || row["Fabric4DetailsRef"] == null) ? string.Empty : row["Fabric4DetailsRef"].ToString();


                var Fab1Det = fabric1Detail.Trim().Split(' ');

                var Fab2Det = fabric2Detail.Trim().Split(' ');

                var Fab3Det = fabric3Detail.Trim().Split(' ');

                var Fab4Det = fabric4Detail.Trim().Split(' ');

                int result;
                if (!string.IsNullOrEmpty(Fab1Det[0]) && Int32.TryParse(Fab1Det[0], out result) && (Fab1Det.Length == 1 || (Fab1Det.Length == 2 && Fab1Det[1].Length <= 2)))
                {
                    fabric1Detail = "PRD:" + fabric1Detail;
                    result = 0;
                }

                if (!string.IsNullOrEmpty(Fab2Det[0]) && Int32.TryParse(Fab2Det[0], out result) && (Fab2Det.Length == 1 || (Fab2Det.Length == 2 && Fab2Det[1].Length <= 2)))
                {
                    fabric2Detail = "PRD:" + fabric2Detail;
                    result = 0;
                }

                if (!string.IsNullOrEmpty(Fab3Det[0]) && Int32.TryParse(Fab3Det[0], out result) && (Fab3Det.Length == 1 || (Fab3Det.Length == 2 && Fab3Det[1].Length <= 2)))
                {
                    fabric3Detail = "PRD:" + fabric3Detail;
                    result = 0;
                }

                if (!string.IsNullOrEmpty(Fab4Det[0]) && Int32.TryParse(Fab4Det[0], out result) && (Fab4Det.Length == 1 || (Fab4Det.Length == 2 && Fab4Det[1].Length <= 2)))
                {
                    fabric4Detail = "PRD:" + fabric4Detail;
                    result = 0;
                }

                if (fabric1Detail.Trim() != string.Empty)
                {
                    fabric1Detail = " : " + fabric1Detail.ToUpper();
                    fabric = fabric1 + fabric1Detail;
                    if (CCGSM1 != string.Empty)
                    {
                        fabric = fabric + "<BR><span style='color:black'>" + CCGSM1 + "</span>";
                    }
                }
                else if (fabric1.Trim() != string.Empty)
                {
                    fabric = fabric1;
                    if (CCGSM1 != string.Empty)
                    {
                        fabric = fabric + "<BR><span style='color:black'>" + CCGSM1 + "</span>";
                    }
                }

                if (fabric2Detail.Trim() != string.Empty)
                {
                    fabric2Detail = " : " + fabric2Detail.ToUpper();
                    fabric = fabric + "<BR>" + fabric2 + fabric2Detail;
                    if (CCGSM2 != string.Empty)
                    {
                        fabric = fabric + "<BR><span style='color:black'>" + CCGSM2 + "</span>";
                    }
                }
                else if (fabric2.Trim() != string.Empty)
                {
                    fabric = fabric + "<BR>" + fabric2;
                    if (CCGSM2 != string.Empty)
                    {
                        fabric = fabric + "<BR><span style='color:black'>" + CCGSM2 + "</span>";
                    }
                }

                if (fabric3Detail.Trim() != string.Empty)
                {
                    fabric3Detail = " : " + fabric3Detail.ToUpper();
                    fabric = fabric + "<BR>" + fabric3 + fabric3Detail;
                    if (CCGSM3 != string.Empty)
                    {
                        fabric = fabric + "<BR><span style='color:black'>" + CCGSM3 + "</span>";
                    }
                }
                else if (fabric3.Trim() != string.Empty)
                {
                    fabric = fabric + "<BR>" + fabric3;
                    if (CCGSM3 != string.Empty)
                    {
                        fabric = fabric + "<BR><span style='color:black'>" + CCGSM3 + "</span>";
                    }
                }

                if (fabric4Detail.Trim() != string.Empty)
                {
                    fabric4Detail = " : " + fabric4Detail.ToUpper();
                    fabric = fabric + "<BR>" + fabric4 + fabric4Detail;
                    if (CCGSM4 != string.Empty)
                    {
                        fabric = fabric + "<BR><span style='color:black'>" + CCGSM4 + "</span>";
                    }
                }
                else if (fabric4.Trim() != string.Empty)
                {
                    fabric = fabric + "<BR>" + fabric4;
                    if (CCGSM4 != string.Empty)
                    {
                        fabric = fabric + "<BR><span style='color:black'>" + CCGSM4 + "</span>";
                    }
                }

                //fabric = fabric1 + fabric1Detail;

                DateTime exFactory = DateTime.MinValue;
                DateTime dc = DateTime.MinValue;
                int mode = -1;

                if (row["Exfactory"] != DBNull.Value && row["Exfactory"] != null)
                    exFactory = Convert.ToDateTime(row["Exfactory"]);

                if (row["DC"] != DBNull.Value && row["DC"] != null)
                    dc = Convert.ToDateTime(row["DC"]);

                if (row["Mode"] != DBNull.Value && row["Mode"] != null)
                    mode = Convert.ToInt32(row["Mode"]);

                string exBgColor = iKandi.BLL.CommonHelper.GetExFactoryColor(exFactory, dc, mode);

                string imageUrl = ((row["SampleImageURL1"] == DBNull.Value || row["SampleImageURL1"] == null) ? string.Empty : row["SampleImageURL1"].ToString());
                if (row["CompanyName"].ToString().ToUpper() == "XnY.in".ToUpper())
                {
                    continue;
                }


                sb.Append("<TR>");
                sb.Append("<TD>" + ((row["OrderDate"] == DBNull.Value || row["OrderDate"] == null) ? string.Empty : Convert.ToDateTime(row["OrderDate"]).ToString("dd MMM yy (ddd)")) + "</TD>");
                sb.Append("<TD>" + ((row["SerialNumber"] == DBNull.Value || row["SerialNumber"] == null) ? string.Empty : row["SerialNumber"].ToString().ToUpper()) + "</TD>");
                sb.Append("<TD>" + ((row["DepartmentName"] == DBNull.Value || row["DepartmentName"] == null) ? string.Empty : row["DepartmentName"].ToString().ToUpper()) + "</TD>");
                sb.Append("<TD>" + ((row["StyleNumber"] == DBNull.Value || row["StyleNumber"] == null) ? string.Empty : row["StyleNumber"].ToString().ToUpper()));
                sb.Append("<div><IMG SRC='" + Constants.SITE_BASE_URL + "/uploads/style/thumb-" + imageUrl + "'  /></div></TD>");
                sb.Append("<TD>" + ((row["LineItemNumber"] == DBNull.Value || row["LineItemNumber"] == null) ? string.Empty : row["LineItemNumber"].ToString().ToUpper()) + "</TD>");
                sb.Append("<TD>" + ((row["ContractNumber"] == DBNull.Value || row["ContractNumber"] == null) ? string.Empty : row["ContractNumber"].ToString().ToUpper()) + "</TD>");
                sb.Append("<TD>" + ((row["Description"] == DBNull.Value || row["Description"] == null) ? string.Empty : row["Description"].ToString().ToUpper()) + "</TD>");
                sb.Append("<TD>" + ((row["Quantity"] == DBNull.Value || row["Quantity"] == null) ? string.Empty : row["Quantity"].ToString().ToUpper()) + "</TD>");
                sb.Append("<TD>" + fabric + "</TD>");
                sb.Append("<TD>" + ((row["STCTGT"] == DBNull.Value || row["STCTGT"] == null) ? string.Empty : row["STCTGT"].ToString().ToUpper()) + "</TD>");
                string planningFor = (row["PlanningFor"] == DBNull.Value || row["PlanningFor"] == null) ? string.Empty : row["PlanningFor"].ToString();
                sb.Append("<TD>" + planningFor + "</TD>");
                sb.Append("<TD>" + Convert.ToString(ModeText) + "</TD>");
                sb.Append("<TD style='background-color:" + exBgColor + "'>" + (exFactory == DateTime.MinValue ? string.Empty : exFactory.ToString("dd MMM yy (ddd)")) + "</TD>");
                //sb.Append("<TD>" + dc.ToString("dd MMM yy (ddd)") + "</TD>");
                //sb.Append("<TD>" + ((row["iKandiPrice"] == DBNull.Value || row["iKandiPrice"] == null) ? string.Empty : CurrencySymbol + " " + row["iKandiPrice"].ToString().ToUpper()) + "</TD>");

                // sb.Append("<TD>" + ((row["CompanyName"] == DBNull.Value || row["CompanyName"] == null) ? string.Empty : row["CompanyName"].ToString().ToUpper()) + "</TD>");
                // sb.Append("<TD>" + ((row["STCTGT"] == DBNull.Value || row["STCTGT"] == null) ? string.Empty : Convert.ToDateTime(row["STCTGT"]).ToString("dd MMM yy (ddd)")) + "</TD>");



                sb.Append("</TR>");

                if (row["clientid"] != DBNull.Value || Convert.ToString(row["clientid"]) != string.Empty || Convert.ToInt32(row["clientid"]) > 0)
                {
                    int clientId = Convert.ToInt32(row["clientid"]);



                    List<User> userListWithClient = GetUserInfo(new List<String>(), objDesignationBasedOnClient, new List<String>(), clientId);
                    //foreach (User user in userListWithClient)
                    //{
                    //    if (to.Contains(user.Email))
                    //    {
                    //        continue;
                    //    }
                    //    else
                    //    {
                    //        to.Add(user.Email);
                    //    }
                    //}

                }
            }

            sb.Append("</TABLE>");


            return sb;
        }

        public void SendFITSPendingOverAWeekEmail_WithPrice()
        {
            try
            {
                bool bIkandi = false;
                bool bNonIkandi = false;

                EmailTemplate template = this.AdminDataProviderInstance.GetEmailTemplateByType(EmailTemplateType.COMMENTSPENDING);
                EmailTemplate templateNonIkandi = this.AdminDataProviderInstance.GetEmailTemplateByType(EmailTemplateType.COMMENTSPENDING);

                List<String> departmentList = new List<String>();
                List<String> designationList = new List<string>();
                List<String> designationListCC = new List<string>();

                string WithClientDesignationIDs;
                string WithNoClientDesignationIDs;

                GetClientAssociatedDesignationID(template.DesignationIDs, out  WithClientDesignationIDs, out  WithNoClientDesignationIDs);

                departmentList.AddRange(template.DepartmentIDs.Split(new char[] { ',' }));
                designationList.AddRange(WithNoClientDesignationIDs.Split(new char[] { ',' }));
                designationListCC.Add("31");
                StringBuilder sb = new StringBuilder();
                StringBuilder sbq = new StringBuilder();
                List<String> to = new List<String>();
                List<String> cc = new List<String>();
                bIkandi = this.FITsDataProviderInstance.GetFITsPendingComments_WithPrice_CheckIkandi(1);
                bNonIkandi = this.FITsDataProviderInstance.GetFITsPendingComments_WithPrice_CheckIkandi(2);
                if (bIkandi == true)
                {
                    DataSet ds = this.FITsDataProviderInstance.GetFITsPendingComments_WithPrice(1);
                    DataTable dt = ds.Tables[0];

                    if (dt.Rows.Count != 0)
                        sb = SamplePendingWithPrice(ds);
                }
                if (bNonIkandi == true)
                {
                    DataSet ds = this.FITsDataProviderInstance.GetFITsPendingComments_WithPrice(2);
                    DataTable dt = ds.Tables[0];
                    if (dt.Rows.Count != 0)
                        sbq = SamplePendingWithPrice(ds);
                }




                // A/c manager, Merch. Mgrs, Fit Merchant, BIPL Sales Mgrs, ikandi Technical Team, ikandi sales Team.              
                //objDesignationList.Add(Convert.ToInt32(Designation.BIPL_Merchandising_Manager).ToString());
                //objDesignationList.Add(Convert.ToInt32(Designation.BIPL_Sales_Manager).ToString());
                //objDesignationList.Add(Convert.ToInt32(Designation.iKandi_Sales_Manager).ToString());
                //objDesignationList.Add(Convert.ToInt32(Designation.iKandi_Technical_Manager).ToString());


                //get User Data
                List<User> userList = GetUserInfo(new List<String>(), designationList, departmentList, 0);

                String fromName = BLLCache.GetConfigurationKeyValue("FROMEMAIL");

                //foreach (User user in userList)
                //{
                //    if (to.Contains(user.Email))
                //    {
                //        continue;
                //    }
                //    else
                //    {
                //        to.Add(user.Email);

                //    }
                //}
                // edit by surendra on 06-Nov-2014


                List<User> userList1 = GetUserInfo(new List<String>(), designationListCC, departmentList, 0);

                //foreach (User user in userList1)
                //{
                //    if (cc.Contains(user.Email))
                //    {
                //        continue;
                //    }
                //    else
                //    {
                //        //cc.Add(user.Email);

                //    }

                //}




                System.Diagnostics.Trace.WriteLine("Processing of FITS Comments pending having Subject ----" + template.Subject + "has been started on " + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                //  if (template.Content.Length > 874)
                if (bIkandi == true)
                {
                    template.Content = template.Content.Replace("[[STYLES_TABLE]]", sb.ToString());
                    //Abhishek
                    SendMailUsingKeyValue("Ikandi.SendFITSPendingOverAWeekEmail_WithPrice", out to);


                    //to.Add("bipl_fit_merch@boutique.in");
                    //to.Add("bipl_accountmanagers@boutique.in");
                    ////to.Add("bipl_qateam@boutique.in");
                    //to.Add("ikandi_sales@ikandi.org.uk");
                    //to.Add("ikandi_technical@ikandi.org.uk");
                    //to.Add("hitesh@boutique.in");
                    //to.Add("jaiprakash@boutique.in");
                    //to.Add("sanjeev@boutique.in");

                    //END
                    this.SendEmail(fromName, to, null, null, template.Subject.ToUpper(), template.Content, null, false, false);
                    to.Clear();
                }
                if (bNonIkandi == true)
                {
                    templateNonIkandi.Content = templateNonIkandi.Content.Replace("[[STYLES_TABLE]]", sbq.ToString());
                    //Abhishek
                    SendMailUsingKeyValue("BIPL.SendFITSPendingOverAWeekEmail_WithPrice", out to);


                    //to.Add("bipl_fit_merch@boutique.in");
                    //to.Add("bipl_accountmanagers@boutique.in");
                    //to.Add("jaiprakash@boutique.in");
                    ////to.Add("bipl_qateam@boutique.in");
                    ////to.Add("ikandi_sales@ikandi.org.uk");
                    ////to.Add("ikandi_technical@ikandi.org.uk");
                    //to.Add("hitesh@boutique.in");
                    //to.Add("sanjeev@boutique.in");

                    //END
                    this.SendEmail(fromName, to, null, null, templateNonIkandi.Subject.ToUpper(), templateNonIkandi.Content, null, false, false);
                    to.Clear();
                }

            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in FITS Comments pending Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
               // this.SendErrorEmail(ex.Message + "\n" + ex.StackTrace);

            }
        }

        // Tested
        public void SendPriceVariationList()
        {
            try
            {
                EmailTemplate template = this.AdminDataProviderInstance.GetEmailTemplateByType(EmailTemplateType.PRICEVARIATION);
                int iBipl = 0;
                int iCombined = 0;
                List<String> departmentList = new List<String>();
                List<String> designationList = new List<string>();

                departmentList.AddRange(template.DepartmentIDs.Split(new char[] { ',' }));
                designationList.AddRange(template.DesignationIDs.Split(new char[] { ',' }));

                List<String> to = new List<String>();

                //departmentList.Add(Convert.ToInt32(Group.BIPL_Logistics).ToString());
                //designationList.Add(((int)Designation.BIPL_Sales_Manager).ToString());
                //designationList.Add(((int)Designation.iKandi_Sales_Manager).ToString());
                //designationList.Add(((int)Designation.iKandi_Sales_SalesManager).ToString());
                //designationList.Add(((int)Designation.iKandi_FinanceLogistics_Accountant).ToString());
                //designationList.Add(((int)Designation.BIPL_Merchandising_AccountManager).ToString());
                //designationList.Add(((int)Designation.BIPL_Merchandising_FitMerchant).ToString());
                //designationList.Add(((int)Designation.BIPL_Merchandising_Manager).ToString());

                //get User Data
                List<User> userList = GetUserInfo(new List<String>(), designationList, departmentList, 0);

                //foreach (User user in userList)
                //{
                //    if (to.Contains(user.Email))
                //    {
                //        continue;
                //    }
                //    else
                //    {
                //        to.Add(user.Email);
                //    }
                //}

                String fromName = BLLCache.GetConfigurationKeyValue("FROMEMAIL");

                PDFController controller = new PDFController();

                if (!Directory.Exists(Constants.TEMP_FOLDER_PATH))
                    Directory.CreateDirectory(Constants.TEMP_FOLDER_PATH);

                List<Attachment> atts = new List<Attachment>();

                // For Combined Price Variation 
                System.Diagnostics.Trace.WriteLine("Pdf for For Combined Price Variation has been started  on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                string pdfFilePath = controller.GeneratePriceVariationPDF(1);

                if (pdfFilePath != string.Empty)
                {
                    iCombined = 1;
                    pdfFilePath = Constants.TEMP_FOLDER_PATH + pdfFilePath;
                    atts.Add(new Attachment(pdfFilePath));
                }

                // For Bipl Price Variation 
                System.Diagnostics.Trace.WriteLine("Pdf for For Bipl Price Variation has been started  on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                string pdfFilePath2 = controller.GeneratePriceVariationPDF(2);

                if (pdfFilePath2 != string.Empty)
                {
                    iBipl = 1;
                    if (iCombined == 1 && iBipl == 1)
                    {
                        pdfFilePath2 = Constants.TEMP_FOLDER_PATH + pdfFilePath2;
                        atts.Add(new Attachment(pdfFilePath2));
                        //Abhishek
                        SendMailUsingKeyValue("Ikandi.SendPriceVariationList", out to);


                        //to.Add("bipl_accountmanager@boutique.in");
                        //to.Add("bipl_sales@boutique.in");
                        //to.Add("bipl_fits@boutique.in");
                        //to.Add("sanjeev@boutique.in");
                        //to.Add("hitesh@boutique.in");
                        //to.Add("tanka@boutique.in");

                        //END
                        this.SendEmail(fromName, to, null, null, template.Subject.ToUpper(), template.Content, atts, false, true);
                        to.Clear();
                    }
                }

                // For Ikandi Price Variation 
                System.Diagnostics.Trace.WriteLine("Pdf for For Ikandi Price Variation has been started  on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                string pdfFilePath3 = controller.GeneratePriceVariationPDF(3);

                if (pdfFilePath3 != string.Empty)
                {
                    atts.Clear();

                    pdfFilePath3 = Constants.TEMP_FOLDER_PATH + pdfFilePath3;
                    atts.Add(new Attachment(pdfFilePath3));

                    //Abhishek
                    SendMailUsingKeyValue("BIPL.SendPriceVariationList", out to);

                    //to.Add("ikandi_sales@ikandi.org.uk");
                    //to.Add("bipl_accountmanager@boutique.in");
                    //to.Add("bipl_sales@boutique.in");
                    //to.Add("bipl_fits@boutique.in");
                    //to.Add("sanjeev@boutique.in");
                    //to.Add("hitesh@boutique.in");
                    //to.Add("tanka@boutique.in");

                    //END
                    this.SendEmail(fromName, to, null, null, template.Subject.ToUpper(), template.Content, atts, false, true);
                    to.Clear();
                }

                if (atts.Count == 0)
                {
                    System.Diagnostics.Trace.WriteLine("There is no attachments for Price variation email  on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt") + ".So email email has not be send.");
                    return;
                }

                // this.SendEmail(fromName, to, null, null, template.Subject.ToUpper(), template.Content, atts, false, true);

            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in  Price variation List Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
              //  this.SendErrorEmail(ex.Message + "\n" + ex.StackTrace);
            }
        }

     
     

      

        public void GetSampleDalayedOrToBeDispatchEmail()
        {
            try
            {
                DateTime Date = DateTime.Today;
                EmailTemplate template = this.AdminDataProviderInstance.GetEmailTemplateByType(EmailTemplateType.SamplesDelayedOrToBeDispatchedThisWeek);

                List<String> departmentList = new List<String>();
                List<String> designationList = new List<string>();

                departmentList.AddRange(template.DepartmentIDs.Split(new char[] { ',' }));
                designationList.AddRange(template.DesignationIDs.Split(new char[] { ',' }));


                // Get User Data
                List<User> userList = GetUserInfo(new List<String>(), designationList, departmentList, 0);

                String fromName = BLLCache.GetConfigurationKeyValue("FROMEMAIL");
                string biplmerchandisingManager = string.Empty;
                List<String> to = new List<String>();


                foreach (User user in userList)
                {
                    if (to.Contains(user.Email))
                    {
                        continue;
                    }
                    else
                    {
                        if (user.DesignationID == Convert.ToInt32(Designation.BIPL_Merchandising_Manager))
                        {
                            if (biplmerchandisingManager == string.Empty)
                                biplmerchandisingManager = user.FullName;
                            else
                                biplmerchandisingManager = biplmerchandisingManager + ", " + user.FullName;
                        }
                        to.Add(user.Email);
                    }
                }

                PDFController controller = new PDFController();

                if (!Directory.Exists(Constants.TEMP_FOLDER_PATH))
                    Directory.CreateDirectory(Constants.TEMP_FOLDER_PATH);

                List<Attachment> atts = new List<Attachment>();

                string pdfFilePath = Path.Combine(Constants.TEMP_FOLDER_PATH, "Overall Samples Delay or be Dispatch Email  -" + DateTime.Today.ToString("dd MMM yyy") + ".pdf");

                bool success = controller.GenerateSampleDalayedOrToBeDispatchEmailPDF(pdfFilePath, "Overall Samples Delay or be Dispatch Email");

                if (!success)
                {
                    System.Diagnostics.Trace.WriteLine("There is no record in  Overall Samples Delay or be Dispatch Email section of Production and QA Update Email Inline Cut for the date of" + Date.ToString("dd MM yy (ddd)") + ". So this S pdf has not been attached on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    return;
                }

                atts.Add(new Attachment(pdfFilePath));

                template.Content = template.Content.Replace("[[Merchandising Manager]]", biplmerchandisingManager);

                this.SendEmail(fromName, to, null, null, template.Subject.ToUpper(), template.Content, atts, false, true);

            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in Samples Delay or be Dispatch Email  on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
              //  this.SendErrorEmail(ex.Message + "\n" + ex.StackTrace);
            }
        }


        public void SendBulkOrGarmetTestPendingEmail()
        {
            try
            {
                DateTime Date = DateTime.Today;
                EmailTemplate template = this.AdminDataProviderInstance.GetEmailTemplateByType(EmailTemplateType.BULKORGARMENTTESTSPENDING);

                List<String> departmentList = new List<String>();
                List<String> designationList = new List<string>();
                List<String> to = new List<String>();

                String fromName = BLLCache.GetConfigurationKeyValue("FROMEMAIL");
                string labTech = string.Empty;

                departmentList.AddRange(template.DepartmentIDs.Split(new char[] { ',' }));
                designationList.AddRange(template.DesignationIDs.Split(new char[] { ',' }));

                // Get User Data
                List<User> userList = GetUserInfo(new List<String>(), designationList, departmentList, 0);

                foreach (User user in userList)
                {
                    if (to.Contains(user.Email))
                    {
                        continue;
                    }
                    else
                    {
                        if (user.DesignationID == Convert.ToInt32(Designation.BIPL_LAB_Supervisor))
                        {
                            if (labTech == string.Empty)
                                labTech = user.FullName;
                            else
                                labTech = labTech + ", " + user.FullName;
                        }
                        to.Add(user.Email);
                    }
                }

                LabTestController controller = new LabTestController();
                List<iKandi.Common.LabTest> labTest = controller.GetBulkOrGarmetTestPendingEmail();
                StringBuilder sb = new StringBuilder();
                sb.Append(string.Empty);

                if (labTest.Count > 0)
                {
                    sb.Append("<TABLE border=1 cellpadding=5>");
                    sb.Append("<TR>");
                    sb.Append("<TH>ORDEER DATE</TH>");
                    sb.Append("<TH>SERIAL NUMBER</TH>");
                    sb.Append("<TH>BUYER</TH>");
                    sb.Append("<TH>DEPARTMENT</TH>");
                    sb.Append("<TH>STYLE NUMBER</TH>");
                    sb.Append("<TH>BULK TEST COMPLITATION TARGET</TH>");
                    sb.Append("<TH>FABRICS</TH>");
                    sb.Append("<TH>GARMENT TEST STATUS</TH>");
                    sb.Append("</TR>");

                    foreach (iKandi.Common.LabTest lt in labTest)
                    {
                        sb.Append("<TR>");

                        //Order Date
                        sb.Append("<TD>");
                        sb.Append(lt.OrderDetail.ParentOrder.OrderDate == DateTime.MinValue ? string.Empty : lt.OrderDetail.ParentOrder.OrderDate.ToString("dd MMM yy (ddd)"));
                        sb.Append("</TD>");

                        //Serial Number
                        sb.Append("<TD>");
                        sb.Append(lt.OrderDetail.ParentOrder.SerialNumber.ToUpper());
                        sb.Append("</TD>");

                        //Buyer
                        sb.Append("<TD>");
                        sb.Append(lt.OrderDetail.ParentOrder.Style.client.CompanyName.ToUpper());
                        sb.Append("</TD>");

                        //Department
                        sb.Append("<TD>");
                        sb.Append(lt.OrderDetail.ParentOrder.Style.cdept.Name.ToUpper());
                        sb.Append("</TD>");

                        //Style Number
                        sb.Append("<TD>");
                        sb.Append(lt.OrderDetail.ParentOrder.Style.StyleNumber.ToUpper());
                        sb.Append("</TD>");

                        //BULK TEST COMPLITATION TARGET
                        sb.Append("<TD>");
                        sb.Append(lt.OrderDetail.BulkTarget == DateTime.MinValue ? string.Empty : lt.OrderDetail.BulkTarget.ToString("dd MMM yy (ddd)"));
                        sb.Append("</TD>");

                        //FABRICS
                        StringBuilder fabric = new StringBuilder();
                        fabric.Append(string.Empty);
                        fabric.Append(lt.OrderDetail.Fabric1.ToUpper());

                        if (lt.OrderDetail.Fabric1Details.ToUpper() != string.Empty)
                        {
                            fabric.Append(" : " + lt.OrderDetail.Fabric1Details.ToUpper());
                        }

                        if (lt.OrderDetail.ParentOrder.FabricApprovalDetails.F1ActionDate != DateTime.MinValue)
                        {
                            fabric.Append(" (BS " + lt.OrderDetail.ParentOrder.FabricApprovalDetails.F1ActionDate.ToString("dd MMM") + ")");
                        }

                        if (lt.labBulkTest1.Status != -2)
                        {
                            fabric.Append(" BULK TEST " + GetLebTestStatusText(lt.labBulkTest1.Status));
                        }

                        if (lt.OrderDetail.Fabric2 != string.Empty)
                        {
                            fabric.Append("<br/>");
                            fabric.Append(lt.OrderDetail.Fabric2.ToUpper());

                            if (lt.OrderDetail.Fabric2Details.ToUpper() != string.Empty)
                            {
                                fabric.Append(" : " + lt.OrderDetail.Fabric2Details.ToUpper());
                            }

                            if (lt.OrderDetail.ParentOrder.FabricApprovalDetails.F2ActionDate != DateTime.MinValue)
                            {
                                fabric.Append(" (BS " + lt.OrderDetail.ParentOrder.FabricApprovalDetails.F2ActionDate.ToString("dd MMM") + ")");
                            }

                            if (lt.labBulkTest2.Status != -2)
                            {
                                fabric.Append(" BULK TEST " + GetLebTestStatusText(lt.labBulkTest2.Status));
                            }
                        }

                        if (lt.OrderDetail.Fabric3 != string.Empty)
                        {
                            fabric.Append("<br/>");
                            fabric.Append(lt.OrderDetail.Fabric3.ToUpper());

                            if (lt.OrderDetail.Fabric3Details.ToUpper() != string.Empty)
                            {
                                fabric.Append(" : " + lt.OrderDetail.Fabric3Details.ToUpper());
                            }

                            if (lt.OrderDetail.ParentOrder.FabricApprovalDetails.F3ActionDate != DateTime.MinValue)
                            {
                                fabric.Append(" (BS " + lt.OrderDetail.ParentOrder.FabricApprovalDetails.F3ActionDate.ToString("dd MMM") + ")");
                            }

                            if (lt.labBulkTest3.Status != -2)
                            {
                                fabric.Append(" BULK TEST " + GetLebTestStatusText(lt.labBulkTest3.Status));
                            }
                        }

                        if (lt.OrderDetail.Fabric4 != string.Empty)
                        {
                            fabric.Append("<br/>");
                            fabric.Append(lt.OrderDetail.Fabric4.ToUpper());

                            if (lt.OrderDetail.Fabric4Details.ToUpper() != string.Empty)
                            {
                                fabric.Append(" : " + lt.OrderDetail.Fabric4Details.ToUpper());
                            }

                            if (lt.OrderDetail.ParentOrder.FabricApprovalDetails.F4ActionDate != DateTime.MinValue)
                            {
                                fabric.Append(" (BS " + lt.OrderDetail.ParentOrder.FabricApprovalDetails.F4ActionDate.ToString("dd MMM") + ")");
                            }

                            if (lt.labBulkTest4.Status != -2)
                            {
                                fabric.Append(" BULK TEST " + GetLebTestStatusText(lt.labBulkTest4.Status));
                            }
                        }

                        sb.Append("<TD>");
                        sb.Append(fabric.ToString());
                        sb.Append("</TD>");

                        //GARMENT TEST STATUS
                        sb.Append("<TD>");
                        sb.Append(GetLebTestStatusText(lt.labGarmetTest.Status));
                        sb.Append("</TD>");

                        sb.Append("</TR>");
                    }
                    sb.Append("</TABLE>");

                    System.Diagnostics.Trace.WriteLine("Processing of Bulk/Garmet Pending Email has been started On" + Date.ToString("dd MM yy (ddd)") + "At " + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                }
                else
                {
                    System.Diagnostics.Trace.WriteLine("There is no record in Bulk/Garmet Pending Email On" + Date.ToString("dd MM yy (ddd)") + ". So This Email has not been sent on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    return;
                }

                if (labTech == string.Empty)
                {
                    labTech = "LAB TECH";
                }

                template.Content = template.Content.Replace("[[Lab Tech]]", labTech);
                template.Content = template.Content.Replace("[[Content]]", sb.ToString());

                this.SendEmail(fromName, to, null, null, template.Subject.ToUpper(), template.Content, null, false, true);

            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in Bulk.Garment Pending Email  on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
              //  this.SendErrorEmail(ex.Message + "\n" + ex.StackTrace);
            }
        }




        public void GetOrderFormChangedByDate(DateTime date)
        {
            string client = string.Empty;
            // string html = "";
            bool bIkandi = false;
            bool bNonIkandi = false;
            EmailTemplate template = null;
            EmailTemplate templatebtq = null;
            template = this.AdminDataProviderInstance.GetEmailTemplateByType(EmailTemplateType.ORDERFORMCHANGES);
            templatebtq = this.AdminDataProviderInstance.GetEmailTemplateByType(EmailTemplateType.ORDERFORMCHANGES);
            StringBuilder sb = new StringBuilder();
            StringBuilder sbq = new StringBuilder();
            String fromName = BLLCache.GetConfigurationKeyValue("FROMEMAIL");
            List<String> to = new List<String>();
            //this.OrderControllerInstance.
            //OrderController orderController = OrderController();
            OrderController controller = new OrderController();
            bIkandi = this.FITsDataProviderInstance.GetOrderByCurrentDate_CheckIkandi(date, 1);
            bNonIkandi = this.FITsDataProviderInstance.GetOrderByCurrentDate_CheckIkandi(date, 2);
            if (bIkandi == true)
            {
                List<iKandi.Common.Order> order = controller.GetOrderByCurrentDate(date, 1);
                sb = OrderByCurrentDat_OrderRemarks(order, date);
                 template.Content = template.Content.Replace("[[Sales-Department]]", "All");
            }
            if (bNonIkandi == true)
            {
                List<iKandi.Common.Order> order = controller.GetOrderByCurrentDate(date, 2);
                sbq = OrderByCurrentDat_OrderRemarks(order, date);
                templatebtq.Content = template.Content.Replace("[[Sales-Department]]", "All");
            }
            if (bIkandi == true)
            {
                template.Content = template.Content.Replace("[[Changes]]", sb.ToString());
                // template.Content = template.Content.Replace("[[Sales-Department]]", "All");
                //Abhishek
                SendMailUsingKeyValue("Ikandi.GetOrderFormChangedByDate", out to);


                //to.Add("bipl_merchandising@boutique.in");
                //to.Add("bipl_logistics@boutique.in");
                //to.Add("bipl_sales@boutique.in");
                //to.Add("ikandi_sales@ikandi.org.uk");
                //END
                this.SendEmail(fromName, to, null, null, template.Subject.ToUpper(), template.Content, null, false, true);
                to.Clear();
            }
            if (bNonIkandi == true)
            {
                templatebtq.Content = templatebtq.Content.Replace("[[Changes]]", sbq.ToString());
                // template.Content = template.Content.Replace("[[Sales-Department]]", "All");
                //Abhishek
                SendMailUsingKeyValue("BIPL.GetOrderFormChangedByDate", out to);


                //to.Add("bipl_merchandising@boutique.in");
                //to.Add("bipl_logistics@boutique.in");
                //to.Add("bipl_sales@boutique.in");
                //END

                this.SendEmail(fromName, to, null, null, templatebtq.Subject.ToUpper(), templatebtq.Content, null, false, true);
                to.Clear();
            }




        }



        public void GetChangedOrderIkand(string MailType, DateTime iReportDate)
        {
            DataSet ds = new DataSet();
            DataTable dtorder = new DataTable();
            DataTable MailDt = new DataTable();
            DataTable MailDtFinal = new DataTable();
            OrderController controller = new OrderController();
            StringBuilder sb = new StringBuilder();



            DateTime Date = DateTime.Today;
            EmailTemplate template;
            if (MailType == "BIPL")
                template = this.AdminDataProviderInstance.GetEmailTemplateByType(EmailTemplateType.ORDERCHANGEREQUESTBIPL);
            else
                template = this.AdminDataProviderInstance.GetEmailTemplateByType(EmailTemplateType.ORDERCHANGEREQUESTIKANDI);


            List<String> departmentList = new List<String>();
            List<String> designationList = new List<string>();
            List<String> to = new List<String>();

            String fromName = BLLCache.GetConfigurationKeyValue("FROMEMAIL");
            string labTech = string.Empty;

            departmentList.AddRange(template.DepartmentIDs.Split(new char[] { ',' }));
            designationList.AddRange(template.DesignationIDs.Split(new char[] { ',' }));

            // Get User Data
            List<User> userList = GetUserInfo(new List<String>(), designationList, departmentList, 0);

            foreach (User user in userList)
            {
                if (to.Contains(user.Email))
                {
                    continue;
                }
                else
                {
                    to.Add(user.Email);
                }
            }


            ds = controller.OrderChangeRequestIkandi(MailType, iReportDate);
            MailDt.Columns.Add("ColumnName");
            MailDt.Columns.Add("ChangeType");
            MailDt.Columns.Add("OgiValue");
            MailDt.Columns.Add("CurrentValue");
            MailDt.Columns.Add("OrderId");
            MailDt.Columns.Add("OrderDetailId");
            MailDt.Columns.Add("SerialNumber");
            MailDt.Columns.Add("AgreementCreatedby");
            MailDt.Columns.Add("StyleNumber");
            MailDt.Columns.Add("ImageUrl");
            MailDt.Columns.Add("LineItemNumber");
            MailDt.Columns.Add("ContractNumber");
            MailDt.Columns.Add("Quantity");
            if (MailType == "BIPL")
            {
                MailDt.Columns.Add("AgreedValue");
                MailDt.Columns.Add("AgreementApprovedBy");
            }



            MailDt = GetOrderMainChanges(ds.Tables[0], MailDt, MailType);
            MailDt = GetOrderDetailChanges(ds.Tables[1], MailDt, MailType);
            MailDt.DefaultView.Sort = "OrderId,OrderDetailId";
            MailDtFinal = MailDt.DefaultView.ToTable();
            if (MailDtFinal.Rows.Count == 0)
                return;
            sb.Append("<TABLE cellpadding='1' style='text-transform:uppercase;font-size:smaller; border:solid 1 black'>");
            sb.Append("<TR>");
            sb.Append("<TH>SERIAL NUMBER</TH>");
            sb.Append("<TH>STYLE</TH>");
            sb.Append("<TH>LINE NO.</TH>");
            sb.Append("<TH>CONTRACT NO.</TH>");
            sb.Append("<TH>QTY.</TH>");
            sb.Append("<TH>ITEM</TH>");
            sb.Append("<TH>ORIGINAL VALUE</TH>");
            sb.Append("<TH>CHANGED VALUE</TH>");
            sb.Append("<TH>CHANGE REQUESTED BY</TH>");

            if (MailType == "BIPL")
            {
                sb.Append("<TH>AGREED VALUE</TH>");
                sb.Append("<TH>APPROVED BY</TH>");
            }

            sb.Append("</TR>");
            for (int i = 0; i <= MailDtFinal.Rows.Count - 1; i++)
            {
                if (MailDtFinal.Rows[i]["ChangeType"].ToString() != "O")
                {
                    sb.Append("<TR>");
                    if (Convert.ToString(MailDtFinal.Rows[i]["SerialNumber"]) == "")
                    {
                        MailDtFinal.Rows[i]["SerialNumber"] = MailDtFinal.Rows[i - 1]["SerialNumber"];
                        MailDtFinal.Rows[i]["AgreementCreatedBy"] = MailDtFinal.Rows[i - 1]["AgreementCreatedby"];
                        MailDtFinal.Rows[i]["StyleNumber"] = MailDtFinal.Rows[i - 1]["StyleNumber"];
                        MailDtFinal.Rows[i]["ImageUrl"] = MailDtFinal.Rows[i - 1]["ImageUrl"];
                        MailDtFinal.Rows[i]["LineItemNumber"] = MailDtFinal.Rows[i - 1]["LineItemNumber"];
                        MailDtFinal.Rows[i]["ContractNumber"] = MailDtFinal.Rows[i - 1]["ContractNumber"];
                        MailDtFinal.Rows[i]["Quantity"] = MailDtFinal.Rows[i - 1]["Quantity"];
                        if (MailType == "BIPL")
                        {
                            MailDtFinal.Rows[i]["AgreementApprovedBy"] = MailDtFinal.Rows[i - 1]["AgreementApprovedBy"];
                        }

                    }

                    sb.Append("<TD>" + MailDtFinal.Rows[i]["SerialNumber"] + "</TD>");
                    sb.Append("<TD>" + MailDtFinal.Rows[i]["StyleNumber"]);
                    sb.Append("<div><IMG SRC='" + Constants.SITE_BASE_URL + "/uploads/style/thumb-" + MailDtFinal.Rows[i]["ImageUrl"].ToString() + "'  /></div></TD>");
                    sb.Append("<TD>" + MailDtFinal.Rows[i]["LineItemNumber"] + "</TD>");
                    sb.Append("<TD>" + MailDtFinal.Rows[i]["ContractNumber"] + "</TD>");
                    sb.Append("<TD>" + MailDtFinal.Rows[i]["Quantity"] + "</TD>");
                    sb.Append("<TD>" + MailDtFinal.Rows[i]["ColumnName"] + "</TD>");
                    sb.Append("<TD>" + MailDtFinal.Rows[i]["OgiValue"] + "</TD>");
                    sb.Append("<TD>" + MailDtFinal.Rows[i]["CurrentValue"] + "</TD>");
                    sb.Append("<TD>" + MailDtFinal.Rows[i]["AgreementCreatedby"] + "</TD>");
                    if (MailType == "BIPL")
                    {
                        sb.Append("<TD>" + MailDtFinal.Rows[i]["AgreedValue"] + "</TD>");
                        sb.Append("<TD>" + MailDtFinal.Rows[i]["AgreementApprovedBy"] + "</TD>");
                    }

                    sb.Append("</TR>");
                }
            }
            sb.Append("</TABLE>");

            template.Content = template.Content.Replace("[[STYLES_TABLE]]", sb.ToString());
            this.SendEmail(fromName, to, null, null, template.Subject.ToUpper(), template.Content, null, false, true);
        }


        #endregion

        #region Private Methods
        private DataTable GetOrderMainChanges(DataTable dtorder, DataTable dt, string MailType)
        {
            DataRow dr;
            for (int i = 0; i <= dtorder.Rows.Count - 1; i++)
            {

                dr = dt.NewRow();
                dr["ColumnName"] = "BIPL PRICE";
                dr["ChangeType"] = "O";
                dr["OgiValue"] = Convert.ToString(dtorder.Rows[i]["BIPLPrice_d"]);
                dr["CurrentValue"] = Convert.ToString(dtorder.Rows[i]["BIPLPrice"]);
                dr["OrderId"] = Convert.ToString(dtorder.Rows[i]["Id"]);
                dr["OrderDetailId"] = "0";
                dr["SerialNumber"] = Convert.ToString(dtorder.Rows[i]["SerialNumber"]);
                dr["AgreementCreatedby"] = Convert.ToString(dtorder.Rows[i]["AgreementCreatedByName"]);
                dr["StyleNumber"] = Convert.ToString(dtorder.Rows[i]["StyleNumber"]);
                dr["ImageUrl"] = Convert.ToString(dtorder.Rows[i]["SampleImageURL1"]);
                dr["LineItemNumber"] = Convert.ToString(dtorder.Rows[i]["LineItemNumber"]);
                dr["ContractNumber"] = Convert.ToString(dtorder.Rows[i]["ContractNumber"]);
                dr["Quantity"] = Convert.ToString(dtorder.Rows[i]["Quantity"]);
                if (MailType == "BIPL")
                {
                    dr["AgreedValue"] = "";
                    dr["AgreementApprovedBy"] = Convert.ToString(dtorder.Rows[i]["AgreementApprovedByName"]);
                }
                dt.Rows.Add(dr);


                if (Convert.ToString(dtorder.Rows[i]["BIPLPrice"]) != Convert.ToString(dtorder.Rows[i]["BIPLPrice_d"]))
                {
                    dr = dt.NewRow();
                    dr["ColumnName"] = "BIPL PRICE";
                    dr["ChangeType"] = "M";
                    dr["OgiValue"] = Convert.ToString(dtorder.Rows[i]["BIPLPrice_d"]);
                    dr["CurrentValue"] = Convert.ToString(dtorder.Rows[i]["BIPLPrice"]);
                    dr["OrderId"] = Convert.ToString(dtorder.Rows[i]["Id"]);
                    dr["OrderDetailId"] = "0";
                    dr["SerialNumber"] = Convert.ToString(dtorder.Rows[i]["SerialNumber"]);
                    dr["AgreementCreatedby"] = Convert.ToString(dtorder.Rows[i]["AgreementCreatedByName"]);
                    dr["StyleNumber"] = Convert.ToString(dtorder.Rows[i]["StyleNumber"]);
                    dr["ImageUrl"] = Convert.ToString(dtorder.Rows[i]["SampleImageURL1"]);
                    dr["LineItemNumber"] = Convert.ToString(dtorder.Rows[i]["LineItemNumber"]);
                    dr["ContractNumber"] = Convert.ToString(dtorder.Rows[i]["ContractNumber"]);
                    dr["Quantity"] = Convert.ToString(dtorder.Rows[i]["Quantity"]);
                    if (MailType == "BIPL")
                    {
                        dr["AgreedValue"] = Convert.ToString(dtorder.Rows[i]["BIPLPrice_m"]);
                        dr["AgreementApprovedBy"] = Convert.ToString(dtorder.Rows[i]["AgreementApprovedByName"]);
                    }
                    dt.Rows.Add(dr);
                }
                if (Convert.ToString(dtorder.Rows[i]["TotalQuantity"]) != Convert.ToString(dtorder.Rows[i]["TotalQuantity_d"]))
                {
                    dr = dt.NewRow();
                    dr["ColumnName"] = "TOTAL QUANTITY";
                    dr["ChangeType"] = "M";
                    dr["OgiValue"] = Convert.ToString(dtorder.Rows[i]["TotalQuantity_d"]);
                    dr["CurrentValue"] = Convert.ToString(dtorder.Rows[i]["TotalQuantity"]);
                    dr["OrderId"] = Convert.ToString(dtorder.Rows[i]["Id"]);
                    dr["OrderDetailId"] = "0";
                    dr["SerialNumber"] = Convert.ToString(dtorder.Rows[i]["SerialNumber"]);
                    dr["AgreementCreatedby"] = Convert.ToString(dtorder.Rows[i]["AgreementCreatedByName"]);
                    dr["StyleNumber"] = Convert.ToString(dtorder.Rows[i]["StyleNumber"]);
                    dr["ImageUrl"] = Convert.ToString(dtorder.Rows[i]["SampleImageURL1"]);
                    dr["LineItemNumber"] = Convert.ToString(dtorder.Rows[i]["LineItemNumber"]);
                    dr["ContractNumber"] = Convert.ToString(dtorder.Rows[i]["ContractNumber"]);
                    dr["Quantity"] = Convert.ToString(dtorder.Rows[i]["Quantity"]);
                    if (MailType == "BIPL")
                    {
                        dr["AgreedValue"] = Convert.ToString(dtorder.Rows[i]["TotalQuantity_d"]);
                        dr["AgreementApprovedBy"] = Convert.ToString(dtorder.Rows[i]["AgreementApprovedByName"]);
                    }
                    dt.Rows.Add(dr);
                }

                if (Convert.ToString(dtorder.Rows[i]["CompanyName"]) != Convert.ToString(dtorder.Rows[i]["CompanyName_d"]))
                {
                    dr = dt.NewRow();
                    dr["ColumnName"] = "COMPANY NAME";
                    dr["ChangeType"] = "M";
                    dr["OgiValue"] = Convert.ToString(dtorder.Rows[i]["CompanyName_d"]);
                    dr["CurrentValue"] = Convert.ToString(dtorder.Rows[i]["CompanyName"]);
                    dr["OrderId"] = Convert.ToString(dtorder.Rows[i]["Id"]);
                    dr["OrderDetailId"] = "0";
                    dr["SerialNumber"] = Convert.ToString(dtorder.Rows[i]["SerialNumber"]);
                    dr["AgreementCreatedby"] = Convert.ToString(dtorder.Rows[i]["AgreementCreatedByName"]);
                    dr["StyleNumber"] = Convert.ToString(dtorder.Rows[i]["StyleNumber"]);
                    dr["ImageUrl"] = Convert.ToString(dtorder.Rows[i]["SampleImageURL1"]);
                    dr["LineItemNumber"] = Convert.ToString(dtorder.Rows[i]["LineItemNumber"]);
                    dr["ContractNumber"] = Convert.ToString(dtorder.Rows[i]["ContractNumber"]);
                    dr["Quantity"] = Convert.ToString(dtorder.Rows[i]["Quantity"]);
                    if (MailType == "BIPL")
                    {
                        dr["AgreedValue"] = Convert.ToString(dtorder.Rows[i]["CompanyName_m"]);
                        dr["AgreementApprovedBy"] = Convert.ToString(dtorder.Rows[i]["AgreementApprovedByName"]);
                    }
                    dt.Rows.Add(dr);
                }

                if (Convert.ToString(dtorder.Rows[i]["StyleNumber"]) != Convert.ToString(dtorder.Rows[i]["StyleNumber_d"]))
                {
                    dr = dt.NewRow();
                    dr["ColumnName"] = "STYLE NUMBER";
                    dr["ChangeType"] = "M";
                    dr["OgiValue"] = Convert.ToString(dtorder.Rows[i]["StyleNumber_d"]);
                    dr["CurrentValue"] = Convert.ToString(dtorder.Rows[i]["StyleNumber"]);
                    dr["OrderId"] = Convert.ToString(dtorder.Rows[i]["Id"]);
                    dr["OrderDetailId"] = "0";
                    dr["SerialNumber"] = Convert.ToString(dtorder.Rows[i]["SerialNumber"]);
                    dr["AgreementCreatedby"] = Convert.ToString(dtorder.Rows[i]["AgreementCreatedByName"]);
                    dr["StyleNumber"] = Convert.ToString(dtorder.Rows[i]["StyleNumber"]);
                    dr["ImageUrl"] = Convert.ToString(dtorder.Rows[i]["SampleImageURL1"]);
                    dr["LineItemNumber"] = Convert.ToString(dtorder.Rows[i]["LineItemNumber"]);
                    dr["ContractNumber"] = Convert.ToString(dtorder.Rows[i]["ContractNumber"]);
                    dr["Quantity"] = Convert.ToString(dtorder.Rows[i]["Quantity"]);
                    if (MailType == "BIPL")
                    {
                        dr["AgreedValue"] = Convert.ToString(dtorder.Rows[i]["StyleNumber_m"]);
                        dr["AgreementApprovedBy"] = Convert.ToString(dtorder.Rows[i]["AgreementApprovedByName"]);
                    }
                    dt.Rows.Add(dr);
                }

                if (Convert.ToString(dtorder.Rows[i]["DepartmentName"]) != Convert.ToString(dtorder.Rows[i]["DepartmentName_d"]))
                {
                    dr = dt.NewRow();
                    dr["ColumnName"] = "DEPARTMENT NAME";
                    dr["ChangeType"] = "M";
                    dr["OgiValue"] = Convert.ToString(dtorder.Rows[i]["DepartmentName_d"]);
                    dr["CurrentValue"] = Convert.ToString(dtorder.Rows[i]["DepartmentName"]);
                    dr["OrderId"] = Convert.ToString(dtorder.Rows[i]["Id"]);
                    dr["OrderDetailId"] = "0";
                    dr["SerialNumber"] = Convert.ToString(dtorder.Rows[i]["SerialNumber"]);
                    dr["AgreementCreatedby"] = Convert.ToString(dtorder.Rows[i]["AgreementCreatedByName"]);
                    dr["StyleNumber"] = Convert.ToString(dtorder.Rows[i]["StyleNumber"]);
                    dr["ImageUrl"] = Convert.ToString(dtorder.Rows[i]["SampleImageURL1"]);
                    dr["LineItemNumber"] = Convert.ToString(dtorder.Rows[i]["LineItemNumber"]);
                    dr["ContractNumber"] = Convert.ToString(dtorder.Rows[i]["ContractNumber"]);
                    dr["Quantity"] = Convert.ToString(dtorder.Rows[i]["Quantity"]);
                    if (MailType == "BIPL")
                    {
                        dr["AgreedValue"] = Convert.ToString(dtorder.Rows[i]["DepartmentName_m"]);
                        dr["AgreementApprovedBy"] = Convert.ToString(dtorder.Rows[i]["AgreementApprovedByName"]);
                    }
                    dt.Rows.Add(dr);
                }

                //if (Convert.ToString(dtorder.Rows[i]["BulkETA"]) != Convert.ToString(dtorder.Rows[i]["BulkETA_d"]))
                //{
                //    dr = dt.NewRow();
                //    dr["ColumnName"] = "Department Name";
                //    dr["ChangeType"] = "M";
                //    dr["OgiValue"] = Convert.ToString(dtorder.Rows[i]["BulkETA_d"]);
                //    dr["CurrentValue"] = Convert.ToString(dtorder.Rows[i]["BulkETA"]);
                //    dr["OrderId"] = Convert.ToString(dtorder.Rows[i]["Id"]);
                //    dr["OrderDetailId"] = "0";
                //    dr["SerialNumber"] = Convert.ToString(dtorder.Rows[i]["SerialNumber"]);
                //    if (MailType == "BIPL")
                //    {
                //        dr["AgreedValue"] = Convert.ToString(dtorder.Rows[i]["BulkETA_m"]);
                //    }
                //    dt.Rows.Add(dr);
                //}

                if (Convert.ToString(dtorder.Rows[i]["Description"]) != Convert.ToString(dtorder.Rows[i]["Description_d"]))
                {
                    dr = dt.NewRow();
                    dr["ColumnName"] = "ORDER DESCRIPTION";
                    dr["ChangeType"] = "M";
                    dr["OgiValue"] = Convert.ToString(dtorder.Rows[i]["Description_d"]);
                    dr["CurrentValue"] = Convert.ToString(dtorder.Rows[i]["Description"]);
                    dr["OrderId"] = Convert.ToString(dtorder.Rows[i]["Id"]);
                    dr["OrderDetailId"] = "0";
                    dr["SerialNumber"] = Convert.ToString(dtorder.Rows[i]["SerialNumber"]);
                    dr["AgreementCreatedby"] = Convert.ToString(dtorder.Rows[i]["AgreementCreatedByName"]);
                    dr["StyleNumber"] = Convert.ToString(dtorder.Rows[i]["StyleNumber"]);
                    dr["ImageUrl"] = Convert.ToString(dtorder.Rows[i]["SampleImageURL1"]);
                    dr["LineItemNumber"] = Convert.ToString(dtorder.Rows[i]["LineItemNumber"]);
                    dr["ContractNumber"] = Convert.ToString(dtorder.Rows[i]["ContractNumber"]);
                    dr["Quantity"] = Convert.ToString(dtorder.Rows[i]["Quantity"]);
                    if (MailType == "BIPL")
                    {
                        dr["AgreedValue"] = Convert.ToString(dtorder.Rows[i]["Description_m"]);
                        dr["AgreementApprovedBy"] = Convert.ToString(dtorder.Rows[i]["AgreementApprovedByName"]);
                    }
                    dt.Rows.Add(dr);
                }

                if (Convert.ToString(dtorder.Rows[i]["Comments"]) != Convert.ToString(dtorder.Rows[i]["Comments_d"]))
                {
                    dr = dt.NewRow();
                    dr["ColumnName"] = "ORDER COMMENTS";
                    dr["ChangeType"] = "M";
                    dr["OgiValue"] = Convert.ToString(dtorder.Rows[i]["Comments_d"]);
                    dr["CurrentValue"] = Convert.ToString(dtorder.Rows[i]["Comments"]);
                    dr["OrderId"] = Convert.ToString(dtorder.Rows[i]["Id"]);
                    dr["OrderDetailId"] = "0";
                    dr["SerialNumber"] = Convert.ToString(dtorder.Rows[i]["SerialNumber"]);
                    dr["AgreementCreatedby"] = Convert.ToString(dtorder.Rows[i]["AgreementCreatedByName"]);
                    dr["StyleNumber"] = Convert.ToString(dtorder.Rows[i]["StyleNumber"]);
                    dr["ImageUrl"] = Convert.ToString(dtorder.Rows[i]["SampleImageURL1"]);
                    dr["LineItemNumber"] = Convert.ToString(dtorder.Rows[i]["LineItemNumber"]);
                    dr["ContractNumber"] = Convert.ToString(dtorder.Rows[i]["ContractNumber"]);
                    dr["Quantity"] = Convert.ToString(dtorder.Rows[i]["Quantity"]);
                    if (MailType == "BIPL")
                    {
                        dr["AgreedValue"] = Convert.ToString(dtorder.Rows[i]["Comments_m"]);
                        dr["AgreementApprovedBy"] = Convert.ToString(dtorder.Rows[i]["AgreementApprovedByName"]);
                    }
                    dt.Rows.Add(dr);
                }

            }
            return dt;
        }



        private DataTable GetOrderDetailChanges(DataTable dtorder, DataTable dt, string MailType)
        {
            DataRow dr;
            for (int i = 0; i <= dtorder.Rows.Count - 1; i++)
            {
                if (Convert.ToString(dtorder.Rows[i]["LineItemNumber"]) != Convert.ToString(dtorder.Rows[i]["LineItemNumber_d"]))
                {
                    dr = dt.NewRow();
                    dr["ColumnName"] = "LINE NUMBER";
                    dr["ChangeType"] = "D";
                    dr["OgiValue"] = Convert.ToString(dtorder.Rows[i]["LineItemNumber_d"]);
                    dr["CurrentValue"] = Convert.ToString(dtorder.Rows[i]["LineItemNumber"]);
                    dr["OrderId"] = Convert.ToString(dtorder.Rows[i]["OrderId"]);
                    dr["OrderDetailId"] = Convert.ToString(dtorder.Rows[i]["Id"]);
                    dr["SerialNumber"] = "";
                    dr["AgreementCreatedBy"] = "";
                    dr["StyleNumber"] = "";
                    dr["ImageUrl"] = "";
                    dr["LineItemNumber"] = "";
                    dr["ContractNumber"] = "";
                    dr["Quantity"] = "";
                    if (MailType == "BIPL")
                    {
                        dr["AgreedValue"] = Convert.ToString(dtorder.Rows[i]["LineItemNumber_m"]);
                        dr["AgreementApprovedBy"] = "";
                    }
                    dt.Rows.Add(dr);
                }
                if (Convert.ToString(dtorder.Rows[i]["ContractNumber"]) != Convert.ToString(dtorder.Rows[i]["ContractNumber_d"]))
                {
                    dr = dt.NewRow();
                    dr["ColumnName"] = "CONTRACT NO.";
                    dr["ChangeType"] = "D";
                    dr["OgiValue"] = Convert.ToString(dtorder.Rows[i]["ContractNumber_d"]);
                    dr["CurrentValue"] = Convert.ToString(dtorder.Rows[i]["ContractNumber"]);
                    dr["OrderId"] = Convert.ToString(dtorder.Rows[i]["OrderId"]);
                    dr["OrderDetailId"] = Convert.ToString(dtorder.Rows[i]["Id"]);
                    dr["SerialNumber"] = "";
                    dr["AgreementCreatedBy"] = "";
                    dr["StyleNumber"] = "";
                    dr["ImageUrl"] = "";
                    dr["LineItemNumber"] = "";
                    dr["ContractNumber"] = "";
                    dr["Quantity"] = "";
                    if (MailType == "BIPL")
                    {
                        dr["AgreedValue"] = Convert.ToString(dtorder.Rows[i]["ContractNumber_m"]);
                        dr["AgreementApprovedBy"] = "";
                    }
                    dt.Rows.Add(dr);
                }

                if (Convert.ToString(dtorder.Rows[i]["Code"]) != Convert.ToString(dtorder.Rows[i]["ModeName_d"]))
                {
                    dr = dt.NewRow();
                    dr["ColumnName"] = "MODE";
                    dr["ChangeType"] = "D";
                    dr["OgiValue"] = Convert.ToString(dtorder.Rows[i]["ModeName_d"]);
                    dr["CurrentValue"] = Convert.ToString(dtorder.Rows[i]["Code"]);
                    dr["OrderId"] = Convert.ToString(dtorder.Rows[i]["OrderId"]);
                    dr["OrderDetailId"] = Convert.ToString(dtorder.Rows[i]["Id"]);
                    dr["SerialNumber"] = "";
                    dr["AgreementCreatedBy"] = "";
                    dr["StyleNumber"] = "";
                    dr["ImageUrl"] = "";
                    dr["LineItemNumber"] = "";
                    dr["ContractNumber"] = "";
                    dr["Quantity"] = "";
                    if (MailType == "BIPL")
                    {
                        dr["AgreedValue"] = Convert.ToString(dtorder.Rows[i]["ModeName_m"]);
                        dr["AgreementApprovedBy"] = "";
                    }
                    dt.Rows.Add(dr);
                }

                if (Convert.ToString(dtorder.Rows[i]["Description"]) != Convert.ToString(dtorder.Rows[i]["Description_d"]))
                {
                    dr = dt.NewRow();
                    dr["ColumnName"] = "DETAIL DESCRIPTION";
                    dr["ChangeType"] = "D";
                    dr["OgiValue"] = Convert.ToString(dtorder.Rows[i]["Description_d"]);
                    dr["CurrentValue"] = Convert.ToString(dtorder.Rows[i]["Description"]);
                    dr["OrderId"] = Convert.ToString(dtorder.Rows[i]["OrderId"]);
                    dr["OrderDetailId"] = Convert.ToString(dtorder.Rows[i]["Id"]);
                    dr["SerialNumber"] = "";
                    dr["AgreementCreatedBy"] = "";
                    dr["StyleNumber"] = "";
                    dr["ImageUrl"] = "";
                    dr["LineItemNumber"] = "";
                    dr["ContractNumber"] = "";
                    dr["Quantity"] = "";
                    if (MailType == "BIPL")
                    {
                        dr["AgreedValue"] = Convert.ToString(dtorder.Rows[i]["Description_m"]);
                        dr["AgreementApprovedBy"] = "";
                    }
                    dt.Rows.Add(dr);
                }

                if (Convert.ToString(dtorder.Rows[i]["iKandiPrice"]) != Convert.ToString(dtorder.Rows[i]["iKandiPrice_d"]))
                {
                    dr = dt.NewRow();
                    dr["ColumnName"] = "PRICE";
                    dr["ChangeType"] = "D";
                    dr["OgiValue"] = Convert.ToString(dtorder.Rows[i]["iKandiPrice_d"]);
                    dr["CurrentValue"] = Convert.ToString(dtorder.Rows[i]["iKandiPrice"]);
                    dr["OrderId"] = Convert.ToString(dtorder.Rows[i]["OrderId"]);
                    dr["OrderDetailId"] = Convert.ToString(dtorder.Rows[i]["Id"]);
                    dr["SerialNumber"] = "";
                    dr["AgreementCreatedBy"] = "";
                    dr["StyleNumber"] = "";
                    dr["ImageUrl"] = "";
                    dr["LineItemNumber"] = "";
                    dr["ContractNumber"] = "";
                    dr["Quantity"] = "";
                    if (MailType == "BIPL")
                    {
                        dr["AgreedValue"] = Convert.ToString(dtorder.Rows[i]["iKandiPrice_m"]);
                        dr["AgreementApprovedBy"] = "";
                    }
                    dt.Rows.Add(dr);
                }

                if (Convert.ToString(dtorder.Rows[i]["ExFactory"]) != Convert.ToString(dtorder.Rows[i]["ExFactory_d"]))
                {
                    dr = dt.NewRow();
                    dr["ColumnName"] = "EX-FACTORY DATE";
                    dr["ChangeType"] = "D";
                    dr["OgiValue"] = Convert.ToString(dtorder.Rows[i]["ExFactory_d"]);
                    dr["CurrentValue"] = Convert.ToString(dtorder.Rows[i]["ExFactory"]);
                    dr["OrderId"] = Convert.ToString(dtorder.Rows[i]["OrderId"]);
                    dr["OrderDetailId"] = Convert.ToString(dtorder.Rows[i]["Id"]);
                    dr["SerialNumber"] = "";
                    dr["AgreementCreatedBy"] = "";
                    dr["StyleNumber"] = "";
                    dr["ImageUrl"] = "";
                    dr["LineItemNumber"] = "";
                    dr["ContractNumber"] = "";
                    dr["Quantity"] = "";
                    if (MailType == "BIPL")
                    {
                        dr["AgreedValue"] = Convert.ToString(dtorder.Rows[i]["ExFactory_m"]);
                        dr["AgreementApprovedBy"] = "";
                    }
                    dt.Rows.Add(dr);
                }

                if (Convert.ToString(dtorder.Rows[i]["Fabric1"]) != Convert.ToString(dtorder.Rows[i]["Fabric1_d"]))
                {
                    dr = dt.NewRow();
                    dr["ColumnName"] = "FABRIC - 1";
                    dr["ChangeType"] = "D";
                    dr["OgiValue"] = Convert.ToString(dtorder.Rows[i]["Fabric1_d"]) + " " + Convert.ToString(dtorder.Rows[i]["Fabric1Details_d"]);
                    dr["CurrentValue"] = Convert.ToString(dtorder.Rows[i]["Fabric1"]) + " " + Convert.ToString(dtorder.Rows[i]["Fabric1Details"]);
                    dr["OrderId"] = Convert.ToString(dtorder.Rows[i]["OrderId"]);
                    dr["OrderDetailId"] = Convert.ToString(dtorder.Rows[i]["Id"]);
                    dr["SerialNumber"] = "";
                    dr["AgreementCreatedBy"] = "";
                    dr["StyleNumber"] = "";
                    dr["ImageUrl"] = "";
                    dr["LineItemNumber"] = "";
                    dr["ContractNumber"] = "";
                    dr["Quantity"] = "";
                    if (MailType == "BIPL")
                    {
                        dr["AgreedValue"] = Convert.ToString(dtorder.Rows[i]["Fabric1_m"]) + " " + Convert.ToString(dtorder.Rows[i]["Fabric1Details_m"]);
                        dr["AgreementApprovedBy"] = "";
                    }
                    dt.Rows.Add(dr);
                }

                if (Convert.ToString(dtorder.Rows[i]["Fabric2"]) != Convert.ToString(dtorder.Rows[i]["Fabric2_d"]))
                {
                    dr = dt.NewRow();
                    dr["ColumnName"] = "FABRIC - 2";
                    dr["ChangeType"] = "D";
                    dr["OgiValue"] = Convert.ToString(dtorder.Rows[i]["Fabric2_d"]) + " " + Convert.ToString(dtorder.Rows[i]["Fabric2Details_d"]);
                    dr["CurrentValue"] = Convert.ToString(dtorder.Rows[i]["Fabric2"]) + " " + Convert.ToString(dtorder.Rows[i]["Fabric2Details"]);
                    dr["OrderId"] = Convert.ToString(dtorder.Rows[i]["OrderId"]);
                    dr["OrderDetailId"] = Convert.ToString(dtorder.Rows[i]["Id"]);
                    dr["SerialNumber"] = "";
                    dr["AgreementCreatedBy"] = "";
                    dr["StyleNumber"] = "";
                    dr["ImageUrl"] = "";
                    dr["LineItemNumber"] = "";
                    dr["ContractNumber"] = "";
                    dr["Quantity"] = "";
                    if (MailType == "BIPL")
                    {
                        dr["AgreedValue"] = Convert.ToString(dtorder.Rows[i]["Fabric2_m"]) + " " + Convert.ToString(dtorder.Rows[i]["Fabric2Details_m"]);
                        dr["AgreementApprovedBy"] = "";
                    }
                    dt.Rows.Add(dr);
                }


                if (Convert.ToString(dtorder.Rows[i]["Fabric3"]) != Convert.ToString(dtorder.Rows[i]["Fabric3_d"]))
                {
                    dr = dt.NewRow();
                    dr["ColumnName"] = "FABRIC - 3";
                    dr["ChangeType"] = "D";
                    dr["OgiValue"] = Convert.ToString(dtorder.Rows[i]["Fabric3_d"]) + " " + Convert.ToString(dtorder.Rows[i]["Fabric3Details_d"]);
                    dr["CurrentValue"] = Convert.ToString(dtorder.Rows[i]["Fabric3"]) + " " + Convert.ToString(dtorder.Rows[i]["Fabric3Details"]);
                    dr["OrderId"] = Convert.ToString(dtorder.Rows[i]["OrderId"]);
                    dr["OrderDetailId"] = Convert.ToString(dtorder.Rows[i]["Id"]);
                    dr["SerialNumber"] = "";
                    dr["AgreementCreatedBy"] = "";
                    dr["StyleNumber"] = "";
                    dr["ImageUrl"] = "";
                    dr["LineItemNumber"] = "";
                    dr["ContractNumber"] = "";
                    dr["Quantity"] = "";
                    if (MailType == "BIPL")
                    {
                        dr["AgreedValue"] = Convert.ToString(dtorder.Rows[i]["Fabric3_m"]) + " " + Convert.ToString(dtorder.Rows[i]["Fabric3Details_m"]);
                        dr["AgreementApprovedBy"] = "";
                    }
                    dt.Rows.Add(dr);
                }


                if (Convert.ToString(dtorder.Rows[i]["Fabric4"]) != Convert.ToString(dtorder.Rows[i]["Fabric4_d"]))
                {
                    dr = dt.NewRow();
                    dr["ColumnName"] = "FABRIC - 4";
                    dr["ChangeType"] = "D";
                    dr["OgiValue"] = Convert.ToString(dtorder.Rows[i]["Fabric4_d"]) + " " + Convert.ToString(dtorder.Rows[i]["Fabric4Details_d"]);
                    dr["CurrentValue"] = Convert.ToString(dtorder.Rows[i]["Fabric4"]) + " " + Convert.ToString(dtorder.Rows[i]["Fabric4Details"]);
                    dr["OrderId"] = Convert.ToString(dtorder.Rows[i]["OrderId"]);
                    dr["OrderDetailId"] = Convert.ToString(dtorder.Rows[i]["Id"]);
                    dr["SerialNumber"] = "";
                    dr["AgreementCreatedBy"] = "";
                    dr["StyleNumber"] = "";
                    dr["ImageUrl"] = "";
                    dr["LineItemNumber"] = "";
                    dr["ContractNumber"] = "";
                    dr["Quantity"] = "";
                    if (MailType == "BIPL")
                    {
                        dr["AgreedValue"] = Convert.ToString(dtorder.Rows[i]["Fabric4_m"]) + " " + Convert.ToString(dtorder.Rows[i]["Fabric4Details_m"]);
                        dr["AgreementApprovedBy"] = "";
                    }
                    dt.Rows.Add(dr);
                }

                if (Convert.ToString(dtorder.Rows[i]["Quantity"]) != Convert.ToString(dtorder.Rows[i]["Quantity_d"]))
                {
                    dr = dt.NewRow();
                    dr["ColumnName"] = "QUANTITY";
                    dr["ChangeType"] = "D";
                    dr["OgiValue"] = Convert.ToString(dtorder.Rows[i]["Quantity_d"]);
                    dr["CurrentValue"] = Convert.ToString(dtorder.Rows[i]["Quantity"]);
                    dr["OrderId"] = Convert.ToString(dtorder.Rows[i]["OrderId"]);
                    dr["OrderDetailId"] = Convert.ToString(dtorder.Rows[i]["Id"]);
                    dr["SerialNumber"] = "";
                    dr["AgreementCreatedBy"] = "";
                    dr["StyleNumber"] = "";
                    dr["ImageUrl"] = "";
                    dr["LineItemNumber"] = "";
                    dr["ContractNumber"] = "";
                    dr["Quantity"] = "";
                    if (MailType == "BIPL")
                    {
                        dr["AgreedValue"] = Convert.ToString(dtorder.Rows[i]["Quantity_m"]);
                        dr["AgreementApprovedBy"] = "";
                    }
                    dt.Rows.Add(dr);
                }

                if (Convert.ToString(dtorder.Rows[i]["DC"]) != Convert.ToString(dtorder.Rows[i]["DC_d"]))
                {
                    dr = dt.NewRow();
                    dr["ColumnName"] = "DC DATE";
                    dr["ChangeType"] = "D";
                    dr["OgiValue"] = Convert.ToString(dtorder.Rows[i]["DC_d"]);
                    dr["CurrentValue"] = Convert.ToString(dtorder.Rows[i]["DC"]);
                    dr["OrderId"] = Convert.ToString(dtorder.Rows[i]["OrderId"]);
                    dr["OrderDetailId"] = Convert.ToString(dtorder.Rows[i]["Id"]);
                    dr["SerialNumber"] = "";
                    dr["AgreementCreatedBy"] = "";
                    dr["StyleNumber"] = "";
                    dr["ImageUrl"] = "";
                    dr["LineItemNumber"] = "";
                    dr["ContractNumber"] = "";
                    dr["Quantity"] = "";
                    if (MailType == "BIPL")
                    {
                        dr["AgreedValue"] = Convert.ToString(dtorder.Rows[i]["DC_m"]);
                        dr["AgreementApprovedBy"] = "";
                    }
                    dt.Rows.Add(dr);
                }
            }
            return dt;
        }

        private string GetLebTestStatusText(int Status)
        {
            string statusName = string.Empty;

            switch (Status)
            {
                case -1:
                    {
                        statusName = "PENDING";
                        break;
                    }
                case 1:
                    {
                        statusName = "PASS";
                        break;
                    }
                case 2:
                    {
                        statusName = "FAIL";
                        break;
                    }
            }

            return statusName;
        }

        private string GetTemplateReplacePart(string fromTemplate, string toTemplate, string templateContent)
        {
            string replacePart = string.Empty;
            int startPos = 0;
            int endPos = 0;
            int length = 0;

            if (templateContent.IndexOf(fromTemplate) > -1)
            {
                startPos = templateContent.IndexOf(fromTemplate);
            }

            if (templateContent.IndexOf(toTemplate) > -1)
            {
                endPos = templateContent.IndexOf(toTemplate);
            }

            if (startPos > 0 && endPos > 0)
            {
                length = (endPos - startPos) + toTemplate.Length;
                replacePart = templateContent.Substring(startPos, length);
            }

            return replacePart;

        }

        private List<User> GetUserInfo(List<String> objUserIdList, List<String> objDesignation, List<String> objDepartment, Int32 ClientId)
        {
            try
            {
                return this.UserDataProviderInstance.GetUsersEmail(objUserIdList, objDesignation, objDepartment, ClientId);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                return new List<User>();
            }
        }
        // edit by surendra on 6-sept-2013
        private List<User> GetUserInfoForAllocated(List<String> objUserIdList, List<String> objDesignation, List<String> objDepartment, Int32 ClientId)
        {
            try
            {
                return this.UserDataProviderInstance.GetUsersEmailforAllocated(objUserIdList, objDesignation, objDepartment, ClientId);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                return new List<User>();
            }
        }

        private List<User> GetUserInfoByAccountManagerID(List<String> objUserIdList, List<String> objDesignation, List<String> objDepartment, string AccountManagerIds)
        {
            try
            {
                return this.UserDataProviderInstance.GetUsersEmailByAccountManagerIds(objUserIdList, objDesignation, objDepartment, AccountManagerIds);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                return new List<User>();
            }
        }

        private void DeliveryAddAttachments(String files, List<Attachment> Attachments, String folderPath)
        {
            if (!String.IsNullOrEmpty(files))
            {
                String[] filesArr = files.Split(new String[] { "$$" }, StringSplitOptions.None);

                for (Int32 i = 0; i < filesArr.Length; i = i + 2)
                {
                    Attachment att = new Attachment(folderPath + "\\" + filesArr[i + 1]);
                    att.Name = filesArr[i];

                    Attachments.Add(att);
                }
            }
        }

        private void AddAttachments(String file, List<Attachment> Attachments, String folderPath)
        {
            if (!String.IsNullOrEmpty(file))
            {
                Attachment att = new Attachment((folderPath != string.Empty) ? folderPath + "\\" + file : file);
                if (att != null)
                {
                    att.Name = file;
                    Attachments.Add(att);
                }
            }
        }

        private void GetClientAssociatedDesignationID(string DesignationIDs, out string WithClientDesignationIDs, out string WithNoClientDesignationIDs)
        {
            WithClientDesignationIDs = string.Empty;
            WithNoClientDesignationIDs = string.Empty;

            List<string> arrDes = new List<string>(DesignationIDs.Split(new char[] { ',' }));

            if (arrDes.Contains(((int)Designation.BIPL_Merchandising_AccountManager).ToString()))
            {
                WithClientDesignationIDs += "," + ((int)Designation.BIPL_Merchandising_AccountManager).ToString();
                arrDes.Remove(((int)Designation.BIPL_Merchandising_AccountManager).ToString());
            }

            if (arrDes.Contains(((int)Designation.BIPL_Merchandising_FitMerchant).ToString()))
            {
                WithClientDesignationIDs += "," + ((int)Designation.BIPL_Merchandising_FitMerchant).ToString();
                arrDes.Remove(((int)Designation.BIPL_Merchandising_FitMerchant).ToString());
            }

            if (arrDes.Contains(((int)Designation.BIPL_Merchandising_SamplingMerchant).ToString()))
            {
                WithClientDesignationIDs += "," + ((int)Designation.BIPL_Merchandising_SamplingMerchant).ToString();
                arrDes.Remove(((int)Designation.BIPL_Merchandising_SamplingMerchant).ToString());
            }

            if (arrDes.Contains(((int)Designation.BIPL_Logistics_DeliveryManager).ToString()))
            {
                WithClientDesignationIDs += "," + ((int)Designation.BIPL_Logistics_DeliveryManager).ToString();
                arrDes.Remove(((int)Designation.BIPL_Logistics_DeliveryManager).ToString());
            }

            if (arrDes.Contains(((int)Designation.BIPL_Logistics_ShippingManager).ToString()))
            {
                WithClientDesignationIDs += "," + ((int)Designation.BIPL_Logistics_ShippingManager).ToString();
                arrDes.Remove(((int)Designation.BIPL_Logistics_ShippingManager).ToString());
            }

            if (arrDes.Contains(((int)Designation.iKandi_Design_Designers).ToString()))
            {
                WithClientDesignationIDs += "," + ((int)Designation.iKandi_Design_Designers).ToString();
                arrDes.Remove(((int)Designation.iKandi_Design_Designers).ToString());
            }

            if (arrDes.Contains(((int)Designation.iKandi_Design_Assistant).ToString()))
            {
                WithClientDesignationIDs += "," + ((int)Designation.iKandi_Design_Assistant).ToString();
                arrDes.Remove(((int)Designation.iKandi_Design_Assistant).ToString());
            }

            if (arrDes.Contains(((int)Designation.iKandi_Sales_SalesManager).ToString()))
            {
                WithClientDesignationIDs += "," + ((int)Designation.iKandi_Sales_SalesManager).ToString();
                arrDes.Remove(((int)Designation.iKandi_Sales_SalesManager).ToString());
            }

            if (arrDes.Contains(((int)Designation.iKandi_Technical_Technologist).ToString()))
            {
                WithClientDesignationIDs += "," + ((int)Designation.iKandi_Technical_Technologist).ToString();
                arrDes.Remove(((int)Designation.iKandi_Technical_Technologist).ToString());
            }

            if (arrDes.Contains(((int)Designation.BIPL_Client_Head).ToString()))
            {
                WithClientDesignationIDs += "," + ((int)Designation.BIPL_Client_Head).ToString();
                arrDes.Remove(((int)Designation.BIPL_Client_Head).ToString());
            }

            WithClientDesignationIDs = WithClientDesignationIDs.TrimStart(new char[] { ',' });

            WithNoClientDesignationIDs = String.Join(",", arrDes.ToArray());

        }

       

        /// <summary>
        /// yaten : GetUserInfoCompayWise
        /// </summary>
        /// <param name="objUserIdList"></param>
        /// <param name="objDesignation"></param>
        /// <param name="objDepartment"></param>
        /// <param name="ClientId"></param>
        /// <returns></returns>

        private List<User> GetUsersEmailCompanyWise(List<String> objUserIdList, List<String> objDesignation, List<String> objDepartment, Int32 ClientId, int CompanyId)
        {
            try
            {
                return this.UserDataProviderInstance.GetUsersEmailCompanyWise(objUserIdList, objDesignation, objDepartment, ClientId, CompanyId);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                return new List<User>();
            }
        }


        public void SendBiplInvoicedRaisedEmail(int BoutiqueBillingID, bool IsMailSend, int Id, DateTime FromDate, DateTime ToDate, int intId, int BuyerId2)
        {
            try
            {
                EmailTemplate template = this.AdminDataProviderInstance.GetEmailTemplateByType(EmailTemplateType.BIPLINVOICERAISED);

                List<String> departmentList = new List<String>();
                List<String> designationList = new List<string>();

                departmentList.AddRange(template.DepartmentIDs.Split(new char[] { ',' }));
                designationList.AddRange(template.DesignationIDs.Split(new char[] { ',' }));

                String fromName = BLLCache.GetConfigurationKeyValue("FROMEMAIL"); //Constants.KEY_FROM_EMAIL

                List<InvoiceOrder> invoicedOrderAll = this.InvoiceDataProviderInstance.GetBIPLInvoiceOrders(Id, FromDate, ToDate, string.Empty, string.Empty, intId, BuyerId2);
                List<InvoiceOrder> invoicedOrder = invoicedOrderAll.FindAll(delegate(InvoiceOrder order) { return order.IsBoutiqueBilling == true; });
                List<Attachment> attachments = new List<Attachment>();
                StringBuilder sb = new StringBuilder();
                string subject = string.Empty;
                string biplAccountant = string.Empty;
                int invoiceCounter = 1;
                bool IsFob = false;

                sb.Append("<TABLE border=1 cellpadding=5>");
                sb.Append("<TR>");
                sb.Append("<TH>INVOICED NO.</TH>");
                sb.Append("<TH>BUYER</TH>");
                sb.Append("<TH>SERIAL NO.</TH>");
                sb.Append("<TH>CONTRACT NO.</TH>");
                sb.Append("<TH>SHIPMENT NO.</TH>");
                sb.Append("<TH>QTY.</TH>");
                sb.Append("<TH>PRICE</TH>");
                sb.Append("</TR>");

                foreach (InvoiceOrder ip in invoicedOrder)
                {
                    if (ip.BoutiqueBilling.BoutiqueBillingID == BoutiqueBillingID && IsMailSend == true)
                    {
                        // for attached document
                        string url = "/Internal/Delivery/BIPLInvoice.aspx?type=2&packingId=" +
                            ip.Invoice.PackingID.ToString() + "&invoiceid=" + ip.Invoice.InvoiceID.ToString();

                        string fileName = "Invoice-" + ip.Invoice.InvoiceID.ToString() + "-" + invoiceCounter.ToString();

                        PDFController pdfController = new PDFController(this.LoggedInUser);
                        string pdfFilePath = "pdfFilePath" + invoiceCounter.ToString();
                        pdfFilePath = pdfController.GeneratePDFForPrint(url, fileName, this.LoggedInUser.UserData.Username,
                            this.LoggedInUser.UserData.Password, 1200, -1);

                        if (!string.IsNullOrEmpty(pdfFilePath))
                            attachments.Add(new Attachment(pdfFilePath));

                        // to attached data in mail
                        sb.Append("<TR>");
                        sb.Append("<TD>" + ((ip.Invoice.BIPLPInvoiceNo == null) ? string.Empty : ip.Invoice.BIPLPInvoiceNo.ToString().ToUpper()) + "</TD>");
                        sb.Append("<TD>" + ((ip.ParentOrder.Client.CompanyName == null) ? string.Empty : ip.ParentOrder.Client.CompanyName.ToUpper()) + "</TD>");
                        sb.Append("<TD>" + ((ip.ParentOrder.SerialNumber == null) ? string.Empty : ip.ParentOrder.SerialNumber.ToString().ToUpper()) + "</TD>");
                        sb.Append("<TD>" + ((ip.ContractNumber == null) ? string.Empty : ip.ContractNumber.ToString().ToUpper()) + "</TD>");
                        sb.Append("<TD>" + ((ip.ShipmentPlanning.ShipmentNumber == null) ? string.Empty : ip.ShipmentPlanning.ShipmentNumber.ToString().ToUpper()) + "</TD>");
                        sb.Append("<TD>" + (ip.ProductionPlanning.ShipmentQty).ToString("N0") + "</TD>");
                        sb.Append("<TD>" + ip.ParentOrder.Costing.CurrencySign + ip.ParentOrder.BiplPrice.ToString("N") + "</TD>");
                        sb.Append("</TR>");

                        // subject email

                        if (subject == string.Empty)
                        {
                            subject = ip.Invoice.BIPLPInvoiceNo.ToString().ToUpper() + " (" + ip.ParentOrder.Client.CompanyName + "-" + ip.ParentOrder.DepartmentName + ")" + " ";

                        }
                        else
                        {
                            subject = subject + ", " + ip.Invoice.BIPLPInvoiceNo.ToString().ToUpper() + " (" + ip.ParentOrder.Client.CompanyName + "-" + ip.ParentOrder.DepartmentName + ")" + " ";

                        }

                        if (ip.ModeName.ToString().ToUpper().Contains("D"))
                        {
                            IsFob = true;
                        }

                    }
                    else
                    {
                        continue;
                    }
                }
                sb.Append("</TABLE>");

                if (attachments.Count <= 1)
                {
                    System.Diagnostics.Trace.WriteLine("There is not enough attachment in Bipl Invoiced Raised Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt") + ".So email is not send.");
                    return;
                }

                List<String> to = new List<String>();

                // IKANDI ACCOUNTS               
                //designationList.Add(((int)Designation.BIPL_Logistics_Manager).ToString());
                //designationList.Add(((int)Designation.BIPL_Logistict_Accountant).ToString());
                //designationList.Add(((int)Designation.iKandi_FinanceLogistics_Accountant).ToString());

                if (IsFob == true)
                {
                    if (designationList.Contains(((int)Designation.iKandi_FinanceLogistics_Accountant).ToString()))
                        designationList.Remove(((int)Designation.iKandi_FinanceLogistics_Accountant).ToString());
                }

                //get User Data
                List<User> userList = GetUserInfo(new List<String>(), designationList, departmentList, 0);

                foreach (User user in userList)
                {
                    if (to.Contains(user.Email))
                    {
                        continue;
                    }
                    else
                    {
                        to.Add(user.Email);
                    }
                }


                template.Subject = template.Subject.Replace("[[SUBJECT]]", subject.ToUpper());

                template.Content = template.Content.Replace("[[CONTENT]]", sb.ToString());

                System.Diagnostics.Trace.WriteLine("Processing of Bipl Invoiced Raised Email having Subject ----" + template.Subject + "has been started on " + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                this.SendEmail(fromName, to, null, null, template.Subject.ToUpper(), template.Content, attachments, false, false);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in Bipl Invoiced Raised Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));

               // this.SendErrorEmail(ex.Message + "\n" + ex.StackTrace);
            }
        }

        #endregion
        //added by abhishek on 23/2/2016
        public DataSet GetDispatchEntryMailWeekName(int buyingID=-1)
        {
            DataSet ds = new DataSet();
            ds = NotificationDataProviderInstance.GetDispatchEntryMailWeekName(buyingID);
            return ds;
        }

        public DataSet GetpRODUCTMAIL(string reportname)
        {
            DataSet ds = new DataSet();
            ds = NotificationDataProviderInstance.GetpRODUCTMAIL(reportname);
            return ds;
        }

        //added by raghvinder on 25-08-2020 start
        public DataTable GetCourierDispatchListDate(DateTime CourierDate)
        {
            DataTable dt = new DataTable();
            dt = NotificationDataProviderInstance.GetCourierDispatchListDate(CourierDate);
            return dt;
        }

        public DataTable CourierDispatchListExists(DateTime CourierDate)
        {
            DataTable dt = new DataTable();
            dt = NotificationDataProviderInstance.CourierDispatchListExists(CourierDate);
            return dt;
        }
        
        //added by raghvinder on 25-08-2020 end

        public DataSet GetSupplierNameMail(string SupplierName)
        {
            DataSet ds = new DataSet();
            ds = NotificationDataProviderInstance.GetSupplierNameMail(SupplierName);
            return ds;
        }
        //end by abhishek on 23/2/2016
        public void SendNewOrdersOverallYesterday(DateTime Date)
        {

            try
            {
                EmailTemplate template = this.AdminDataProviderInstance.GetEmailTemplateByType(EmailTemplateType.NEWORDERS);
                EmailTemplate templatebtq = this.AdminDataProviderInstance.GetEmailTemplateByType(EmailTemplateType.NEWORDERS);

                List<String> departmentList = new List<String>();
                List<String> designationList = new List<string>();

                departmentList.AddRange(template.DepartmentIDs.Split(new char[] { ',' }));
                designationList.AddRange(template.DesignationIDs.Split(new char[] { ',' }));


                //MERCHANDISING (EXCLUDE SAMPLING MERHCHANT), FABRIC MANAGER, BIPL SALES MANAGER, LOGISTICS MANAGER, Ikandi Sales Manager, Bipl SALES Manager, ikandi sales Team
                //objDepartmentIdList.Add(Convert.ToInt32(Group.ikandi_Sales).ToString());

                //designationList.Add(((int)Designation.BIPL_Merchandising_AccountManager).ToString());
                //designationList.Add(((int)Designation.BIPL_Merchandising_FitMerchant).ToString());
                //designationList.Add(((int)Designation.BIPL_Merchandising_Manager).ToString());
                //designationList.Add(((int)Designation.BIPL_Fabrics_Manager).ToString());
                //designationList.Add(((int)Designation.BIPL_Sales_Manager).ToString());
                //designationList.Add(((int)Designation.BIPL_Logistics_Manager).ToString());
                //designationList.Add(((int)Designation.iKandi_Sales_Manager).ToString());
                //designationList.Add(((int)Designation.iKandi_Design_Manager).ToString());


                //get User Data
                List<User> userList = GetUserInfo(new List<String>(), designationList, departmentList, 0);

                String fromName = BLLCache.GetConfigurationKeyValue("FROMEMAIL");

                List<String> to = new List<String>();


                //foreach (User user in userList)
                //{
                //    if (to.Contains(user.Email))
                //    {
                //        continue;
                //    }
                //    else
                //    {
                //        to.Add(user.Email);
                //    }
                //}
                // edit by surendra on 06-Nov-2014
                //to.Add("bipl_company@boutique.in");
                //to.Add("ikandi_sales@ikandi.org.uk");
                //to.Add("ikandi_design@ikandi.org.uk");
                //to.Add("ikandi_technical@ikandi.org.uk");
                //to.Add("ikandi_managers@ikandi.org.uk");

                PDFController controller = new PDFController();



                if (!Directory.Exists(Constants.TEMP_FOLDER_PATH))
                    Directory.CreateDirectory(Constants.TEMP_FOLDER_PATH);

                string pdfFilePath = Path.Combine(Constants.TEMP_FOLDER_PATH, "Overall NewOrderIkandi -" + Date.ToString("dd MMM yyy") + ".pdf");
                string pdfFilePathNonIkandi = Path.Combine(Constants.TEMP_FOLDER_PATH, "Overall NewOrderNonIkandi -" + Date.ToString("dd MMM yyy") + ".pdf");

                List<OrderDetail> orderDetails = null;
                bool success = controller.GenerateOverallReport(pdfFilePath, "New Order", Date, out orderDetails);
                if (success == true)
                {
                    double totalQuantity = controller.GetNewOderEmailTotalQuantity(Date, true);

                    template.Content = template.Content.Replace("[[Total Quantity]]", totalQuantity.ToString("N0"));
                    //Abhishek
                    SendMailUsingKeyValue("Ikandi.SendNewOrdersOverallYesterday", out to);


                    //to.Add("bipl_merchandising@boutique.in");
                    //to.Add("ikandi_sales@ikandi.org.uk");
                    //to.Add("ikandi_technical@ikandi.org.uk");
                    //to.Add("ikandi_design@ikandi.org.uk");
                    //to.Add("bipl_sales@boutique.in");
                    //to.Add("bipl_committee@boutique.in");
                    //to.Add("hitesh@boutique.in");
                    //to.Add("rajkumar@boutique.in");
                    //to.Add("anil@boutique.in");
                    //END
                    List<Attachment> atts = new List<Attachment>();
                    atts.Add(new Attachment(pdfFilePath));

                    System.Diagnostics.Trace.WriteLine("Processing of New ikandi Orders Overall Email having Subject ----" + template.Subject + "has been started on " + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                    this.SendEmail(fromName, to, null, null, template.Subject.ToUpper(), template.Content, atts, false, true);
                }


                // edit by surendra
                bool successNonIkandi = controller.GenerateOverallReport(pdfFilePathNonIkandi, "New Order NonIkandi", Date, out orderDetails);
                if (successNonIkandi == true)
                {
                    double totalQuantity = controller.GetNewOderEmailTotalQuantity(Date, false);

                    templatebtq.Content = templatebtq.Content.Replace("[[Total Quantity]]", totalQuantity.ToString("N0"));
                    templatebtq.Content = templatebtq.Content.Replace("iKandi", "BIPL");
                    to.Clear();
                    //Abhishek
                    SendMailUsingKeyValue("BIPL.SendNewOrdersOverallYesterday", out to);


                    //to.Add("bipl_merchandising@boutique.in");
                    //to.Add("bipl_sales@boutique.in");
                    //to.Add("bipl_committee@boutique.in");
                    //to.Add("hitesh@boutique.in");
                    //to.Add("rajkumar@boutique.in");
                    //to.Add("anil@boutique.in");
                    //END

                    List<Attachment> attsNonIkandi = new List<Attachment>();
                    attsNonIkandi.Add(new Attachment(pdfFilePathNonIkandi));

                    System.Diagnostics.Trace.WriteLine("Processing of New Orders Overall Email having Subject ----" + template.Subject + "has been started on " + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                    this.SendEmail(fromName, to, null, null, templatebtq.Subject.ToUpper(), templatebtq.Content, attsNonIkandi, false, true);
                }



            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in  New Orders Overall Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));

                //this.SendErrorEmail(ex.Message + "\n" + ex.StackTrace);
            }
        }




        public string GetEmailSupplierByName(string Name)
        {
            return NotificationDataProviderInstance.GetEmailSupplierByName(Name);
        }
    }
}

