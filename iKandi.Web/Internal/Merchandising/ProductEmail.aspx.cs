using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iKandi.Common;
using iKandi.BLL.Production;
using System.Text;
using System.Net.Mail;
using iKandi.BLL;



namespace iKandi.Web.Internal.Merchandising
{
    public partial class ProductEmail : System.Web.UI.Page
    {
        ProductionController objProductionController = new ProductionController();
        
        string userName = "";
        string PhoneNumber = "";
        string UserEmailID = "";
        string UserRemark = "";
        string MailType = "";
        public string FabStyleNum
        {
            get;
            set;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["FabStyle"] != null)
            {
                FabStyleNum = Request.QueryString["FabStyle"];
            }
            if (!Page.IsPostBack) {
               // SendEmaildata();
            }
            
            lblStyleNo.Text = FabStyleNum;
           
        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            User_EmailSend objUser_EmailSend = new User_EmailSend();
            
            objUser_EmailSend.StyleNoForEmail = lblStyleNo.Text;
            objUser_EmailSend.UserName = txtUserName.Text;
            objUser_EmailSend.UserPhoneNo = txtPhoneNo.Text;
            objUser_EmailSend.UserEmailId = txtEmailId.Text;
            objUser_EmailSend.UserMessage = txtMassage.Text;
            //int SaveValueadd = objProductionController.AddEmail();
             userName = objUser_EmailSend.UserName;
             PhoneNumber = objUser_EmailSend.UserPhoneNo;
             UserEmailID = objUser_EmailSend.UserEmailId;
             UserRemark = objUser_EmailSend.UserMessage;

             SendClientRegistrationEmail("test", "kumar", "", MailType);
           //  ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ClosePO", "CloseModal()", true);
             ScriptManager.RegisterStartupScript(this, this.GetType(), "Close", "window.parent.Shadowbox.close();", true);
        }

        public void ShowAlert(string stringAlertMsg)
        {
            string myStringVariable = string.Empty;
            myStringVariable = stringAlertMsg;
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);
        }

        public Boolean SendClientRegistrationEmail(String ClientName, String UsernamePasswordList, String ToEmail, string MailType)
        {

            try
            {
               String fromName = BLLCache.GetConfigurationKeyValue("FROMEMAIL"); //Constants.KEY_FROM_EMAIL

                //Abhishek
                List<String> to = new List<String>();

                StringBuilder EmailData = new StringBuilder();
                // string imgepath="../../images/as03_s.jpg";


               // EmailData.Append("<div  style='font-size: 12px; font-weight: 500; margin: 5px 0px 15px; font-family: arial;border:0px;'>Hi BIPL Team,</div>");
                MailType = "<table style='font-size: 12px; font-weight: 500; margin: 5px 0px 15px; font-family: arial;border:0px; border-collapse: collapse;'>";
                MailType = MailType + "<tr><td colspan='2' style='font-size: 12px; font-weight: 500; margin: 5px 0px 15px; font-family: arial;border:0px;padding:5px 5px 10px'>Hi BIPL Team,</td></tr>";
                MailType = MailType + "<tr><td colspan='2' style='font-family: arial,halvetica;font-size: 12px;border:1px solid #999;padding:5px 5px;text-align:center'>Following Enquiry Raised</td></tr>";
                MailType = MailType + "<tr><td style='font-size:11px;font-family: arial;color:gray;border:1px solid #999;width:100px;padding:5px 5px;text-align:right'> Style Number </td>" + "<td style='font-size:11px;font-family: arial;color:#000;border:1px solid #999;width:300px;padding:5px 5px'>" + FabStyleNum + "</td></tr>";
                MailType = MailType + "<tr><td style='font-size:11px;font-family: arial;color:gray;border:1px solid #999;width:100px;padding:5px 5px;text-align:right'> User Name </td>" + "<td style='font-size:11px;font-family: arial;color:#000;border:1px solid #999;width:300px;padding:5px 5px'>" + userName + "</td></tr>";
                MailType = MailType + "<tr><td style='font-size:11px;font-family: arial;color:gray;border:1px solid #999;width:100px;padding:5px 5px;text-align:right'> Phone Number </td>" + "<td style='font-size:11px;font-family: arial;color:#000;border:1px solid #999;width:300px;padding:5px 5px'>" + PhoneNumber + "</td></tr>";
                MailType = MailType + "<tr><td style='font-size:11px;font-family: arial;color:gray;border:1px solid #999;width:100px;padding:5px 5px;text-align:right'>  Email </td>" + "<td style='font-size:11px;font-family: arial;color:#000;border:1px solid #999;width:300px;padding:5px 5px'>" + UserEmailID + "</td></tr>";
                MailType = MailType + "<tr><td style='font-size:11px;font-family: arial;color:gray;border:1px solid #999;width:100px;padding:5px 5px;text-align:right'>  Remark </td>" + "<td style='font-size:11px;font-family: arial;color:#000;border:1px solid #999;width:300px;padding:5px 5px'>" + UserRemark + "</td></tr>";
                MailType = MailType + "<tr><td colspan='2' style='font-size: 12px; font-weight: 500; margin: 5px 0px 15px; font-family: arial;border:0px;padding:15px 5px 5px'><strong>Thanks & Best Regards </strong><br /> BIPL Teams</td></tr>";
                MailType = MailType + "<tr><td colspan='2' style='font-size: 12px; font-weight: 500; margin: 5px 0px 15px; font-family: arial;border:0px;padding:2px 5px 10px'> <img src='http://boutique.in/images/certificate.jpg' /></td></tr>";
                
                MailType = MailType + "</table>";
                //MailType = MailType + "<div style='margin-left: 5px; font-size: 12px;font-family: arial;'><strong>Thanks & Best Regards </strong><br /> BIPL Teams </div>";
              //  MailType = MailType + "<div style='margin-top: 10px; margin-left: 5px;'> <img src='http://boutique.in/images/certificate.jpg' /></div>";
                   this.SendEmail(fromName, to, MailType, ToEmail);
                     
                    // BodyData.InnerHtml = MailType.ToString();

                return true;

               
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                return false;
            }
        }



        //protected void SendEmaildata()
        //{
           
        //    StringBuilder EmailData = new StringBuilder();
        //    // string imgepath="../../images/as03_s.jpg";

        //    EmailData.Append("<div class='MainHeading'>Hi BIPL Team,</div>");
        //    EmailData.Append("<div style='margin-left:20px;'>Following Enquiry Raised:</div>");
        //    EmailData.Append("<div style='margin-left:30px;font-size:12px;'> Style Number: " + FabStyleNum + "</div>");
        //    EmailData.Append("<div style='margin-left:30px;font-size:12px;'> Contact Name: " + FabStyleNum + "</div>");
        //    EmailData.Append("<div style='margin-left:30px;font-size:12px;'> Email: " + FabStyleNum + "</div>");
        //    EmailData.Append("<div style='margin-left:30px;font-size:12px;'> Remark: " + FabStyleNum + "</div>");
            
        //  //  BodyData.InnerHtml = EmailData.ToString();

        //    MailType = EmailData.ToString();

        //    this.SendEmail(fromName, to, null, null, ToEmail, MailType, atts, false, false);
        //}

        public Boolean SendEmail(String FromEmail, List<String> To, String Subject, String Content)
        {
            //System.Diagnostics.Debugger.Break();


            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(FromEmail);
            mailMessage.ReplyTo = new MailAddress(FromEmail);
            mailMessage.Priority = MailPriority.Normal;
            mailMessage.Subject = "Enquiry Email";
            mailMessage.IsBodyHtml = true;


            AlternateView htmlView = AlternateView.CreateAlternateViewFromString(Subject, null, "text/html");
            mailMessage.AlternateViews.Add(htmlView);

       
                mailMessage.Body = Subject;
          

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
                //mailMessage.Bcc.Add("samrat@boutique.in");
                //mailMessage.CC.Add("karan@boutique.in");
                //mailMessage.CC.Add("vinaygupta@boutique.in");
                //mailMessage.CC.Add("baldev@boutique.in");
                //mailMessage.CC.Add("shivraj@boutique.in");
                //mailMessage.CC.Add("atish@boutique.in");
                //mailMessage.CC.Add("itsupport@boutique.in");
                //if (CC != null)
                //    foreach (String to in CC)
                //        mailMessage.CC.Add(to);

                //if (BCC != null)
                //    foreach (String to in BCC)
                //        mailMessage.Bcc.Add(to);


                mailMessage.Bcc.Add(System.Configuration.ConfigurationManager.AppSettings["debugModeEmailId"]);


            }

            SmtpClient smtpClient = new SmtpClient(Constants.SMTP_HOST, Constants.SMTP_PORT);

            //if (!hasAppendAttachment && Attachments != null)
            //{
            //    foreach (Attachment att in Attachments)
            //    {
            //        mailMessage.Attachments.Add(att);
            //    }
            //}

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
                   // ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ClosePO", "CloseModal()", true);
              
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
                    //if (Attachments != null)
                    //{
                    //    foreach (Attachment att in Attachments)
                    //    {
                    //        att.Dispose();
                    //    }

                    //    Attachments = null;
                    //}

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