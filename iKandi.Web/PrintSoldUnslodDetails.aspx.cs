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
using iKandi.BLL;
using iKandi.Common;
using iKandi.Web.Components;
using System.Collections.Generic;
using System.Text;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using iTextSharp.text.html;
using iTextSharp.text.rtf.headerfooter;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Globalization;

namespace iKandi.Web.Internal.Design
{
  public partial class PrintSoldUnslodDetails : System.Web.UI.Page
  {
    AdminController odadminctl = new AdminController();
    PrintController obprint = new PrintController();
    protected void grdPrint_RowDataBound(object sender, GridViewRowEventArgs e)
    {
      //if (e.Row.RowType != DataControlRowType.DataRow)
      //  return;
      //Print p = (e.Row.DataItem as Print);

      //Label lblstatus = e.Row.FindControl("lblstatus") as Label;
      //if (p.Status == PrintStatus.Sold)
      //{
      //  (lblstatus.Parent as TableCell).Style.Add("background-color", "#ffa500");

      //}
      //else
      //{
      //  (lblstatus.Parent as TableCell).Style.Add("background-color", "#009000");
      //}


      //Label lblCurrency = e.Row.FindControl("lblCurrency") as Label;
      //lblCurrency.Text = Constants.GetCurrencySign(Enum.GetName(typeof(Currency), p.PrintCostCurrency));


    }
    protected void grdprintunslod_RowDataBound(object sender, GridViewRowEventArgs e) 
    {
      //if (e.Row.RowType != DataControlRowType.DataRow)
      //  return;
      //Print p = (e.Row.DataItem as Print);

      //Label lblstatus = e.Row.FindControl("lblstatus") as Label;
      //if (p.Status == PrintStatus.Sold)
      //{
      //  (lblstatus.Parent as TableCell).Style.Add("background-color", "#ffa500");

      //}
      //else
      //{
      //  (lblstatus.Parent as TableCell).Style.Add("background-color", "#009000");
      //}

      //Label lblCurrency = e.Row.FindControl("lblCurrency") as Label;
      //lblCurrency.Text = Constants.GetCurrencySign(Enum.GetName(typeof(Currency), p.PrintCostCurrency));
    }
    string GlobalTypeUnSold = "PrintListAsosUnSold.pdf";
    string GlobalTypeSold = "PrintListAsosSold.pdf";
    string MailType = "ASOS_Sold_Unsold_Reports";
    string name = "";
    string FitsPath = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {     
        BindControls();  

      
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
     
    }
    private void BindControls()
    {
      DataSet ds = obprint.GetAllPrintsBuyingHouseDALsolddetails();
      grdPrint.DataSource = ds.Tables[0];
      grdPrint.DataBind();

      grdprintunslod.DataSource = ds.Tables[1];
      grdprintunslod.DataBind();

    
      GenerateFabricQualityList_(ds.Tables[0]);
      GenerateFabricQualityList_unslod(ds.Tables[1]);
      string HourlyReportMailBody = "<div style='font-family:arial; font-size:12px'><div> Hi Team,</div><br/> <div> &nbsp; &nbsp;Please find the attached Last 3 months Sold/ Unsold print report for ASO as PDF attachments. </div> <br/><br/><strong>Thanks & Best Regards </strong> <br/><br/> BIPL Team<div style='margin-top:10px;'>   <img src='http://boutique.in/images/certificate.jpg' /></div>";
      SendClientRegistrationEmail("uday", "kumar", HourlyReportMailBody, MailType);

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
                if (MailType == "ASOS_Sold_Unsold_Reports")
                {
                    List<Attachment> atts = new List<Attachment>();

                    //ReportType = "HandOver-PreOrder";
                    name = "PrintListAsosSold" + ".pdf";
                    if (File.Exists(Constants.FITS_FOLDER_PATH + name))
                    {

                        FitsPath = Path.Combine(Constants.FITS_FOLDER_PATH, name);
                        atts.Add(new Attachment(FitsPath));
                    }
                    name = "PrintListAsosUnSold" + ".pdf";
                    if (File.Exists(Constants.FITS_FOLDER_PATH + name))
                    {

                        FitsPath = Path.Combine(Constants.FITS_FOLDER_PATH, name);
                        atts.Add(new Attachment(FitsPath));
                    }
                    
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
    public string FirstLetterToUpper(string word)
    {      
      return word.Substring(0, 1).ToUpper() + word.Substring(1).ToLower();
    }
    public bool GenerateFabricQualityList_(DataTable dt)
    {
        if ((System.IO.File.Exists(Constants.FITS_FOLDER_PATH + GlobalTypeSold)))
        {
            System.IO.File.Delete(Constants.FITS_FOLDER_PATH + GlobalTypeSold);
        }
        string pdfFilePath = Path.Combine(Constants.FITS_FOLDER_PATH, "PrintListAsosSold.pdf");      
      PDFTableGenerator gen = new PDFTableGenerator(pdfFilePath);
      List<OrderDetail> controllerName = new List<OrderDetail>();
      Color HeaderColor = new Color(System.Drawing.ColorTranslator.FromHtml("#BDC3CF"));

      //gen = new PDFTableGenerator(pdfFilePath, "Last 3 Months Sold List for ASOS", HeaderColor);
      gen = new PDFTableGenerator(pdfFilePath, FirstLetterToUpper("Last 3 Months Sold List for ASOS"), HeaderColor);    
      gen.CellHeight = 200;
      gen.Columns = new List<PDFHeader>();
    
      gen.Columns.Add(new PDFHeader("PRINT UPLOAD DATE", iKandi.Common.ContentAlignment.Horizontal, 7,""));
      gen.Columns.Add(new PDFHeader("PRINT NO.", iKandi.Common.ContentAlignment.Horizontal, 7, ""));
      gen.Columns.Add(new PDFHeader("FABRIC", iKandi.Common.ContentAlignment.Horizontal, 7, ""));
      gen.Columns.Add(new PDFHeader("DEPARTMENT NAME", iKandi.Common.ContentAlignment.Horizontal, 10, ""));
      gen.Columns.Add(new PDFHeader("ORIGINAL IMAGE", iKandi.Common.ContentAlignment.Horizontal, 10, ""));
      gen.Columns.Add(new PDFHeader("DEVELOPED IMAGE", iKandi.Common.ContentAlignment.Horizontal, 10, ""));
             
      gen.Rows = new List<List<PDFCell>>();

      foreach (DataRow dr in dt.Rows)
      {
          List<PDFCell> row = new List<PDFCell>();
          PDFCell cell;
            cell = new PDFCell(Convert.ToDateTime(dr["DatePurchased"].ToString()).ToString("dd MMM yy (ddd)"), iKandi.Common.ContentAlignment.Horizontal);
            cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
            cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
            cell.FontSize = 16;
            cell.Width = 20;

            row.Add(cell);


            cell = new PDFCell("PRD " + dr["PrintNumber"].ToString(), iKandi.Common.ContentAlignment.Horizontal);
            cell.FontColor = "#0000FF";
            cell.FontSize = 16;
            cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
            cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
            cell.Width = 20;
            row.Add(cell);

            cell = new PDFCell(dr["fabric"].ToString(), iKandi.Common.ContentAlignment.Horizontal);
            //cell.FontColor = "#0000FF";
            cell.FontSize = 16;
            cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
            cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
            cell.Width = 20;

            row.Add(cell);
            cell = new PDFCell(dr["DepartmentName"].ToString(), iKandi.Common.ContentAlignment.Horizontal);
            cell.FontColor = "#0000FF";
            cell.FontSize = 16;
            cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
            cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
            cell.Width = 20;
            row.Add(cell);

            string ImagePath = dr["ImageUrl"].ToString();
            if (ImagePath != "")
            {
              cell = new PDFCell(string.Empty, iKandi.Common.ContentAlignment.Horizontal);
              if (ImagePath != string.Empty)
                cell.ImageUrl = Path.Combine(Constants.PRINT_FOLDER_PATH, "thumb-" + ImagePath);
               // cell.ImageUrl = Path.Combine(Constants.PRINT_FOLDER_PATH, "PRD " + ImagePath);
              cell.ImageHeight = 300;
              cell.ImageWidth = 300;
              cell.Width = 400;
              cell.Height = 400;
              row.Add(cell);
            }
            else
            {
              cell = new PDFCell(string.Empty, iKandi.Common.ContentAlignment.Horizontal);    
              cell.ImageUrl = Path.Combine(Constants.PRINT_FOLDER_PATH, "thumb-" + ImagePath);
              //cell.ImageUrl = Path.Combine(Constants.PRINT_FOLDER_PATH, "PRD " + ImagePath);
                Path.Combine(Constants.STYLE_FOLDER_PATH, "thumb-" + ImagePath);
                cell.ImageHeight = 300;
                cell.ImageWidth = 300;
                cell.Width = 400;
                cell.Height = 400;
              row.Add(cell);
 
            }
            string ImagePathdev = dr["DevelopedImageUrl"].ToString();
            if (ImagePath != "")
            {
              cell = new PDFCell(string.Empty, iKandi.Common.ContentAlignment.Horizontal);
              if (ImagePath != string.Empty)
                cell.ImageUrl = Path.Combine(Constants.PRINT_FOLDER_PATH, "thumb-" + ImagePathdev);
                //cell.ImageUrl = Path.Combine(Constants.PRINT_FOLDER_PATH, "PRD " + ImagePathdev);
              cell.ImageHeight = 300;
              cell.ImageWidth = 300;
              cell.Width = 400;
              cell.Height = 400;
              row.Add(cell);
            }
            else
            {
              cell = new PDFCell(string.Empty, iKandi.Common.ContentAlignment.Horizontal);
              cell.ImageUrl = Path.Combine(Constants.PRINT_FOLDER_PATH, "thumb-" + ImagePathdev);
              cell.ImageHeight = 300;
              cell.ImageWidth = 300;
              cell.Width = 400;
              cell.Height = 400;
              row.Add(cell);
            }
            
          gen.Rows.Add(row);
        
      }
      if (gen.Rows.Count > 0)
      {
        return gen.GeneratePDF();
      }
      else
      {
        return false;
      }
    }
    public bool GenerateFabricQualityList_unslod(DataTable dt)
    {
        if ((System.IO.File.Exists(Constants.FITS_FOLDER_PATH + GlobalTypeUnSold)))
        {
            System.IO.File.Delete(Constants.FITS_FOLDER_PATH + GlobalTypeUnSold);
        }
        string pdfFilePath = Path.Combine(Constants.FITS_FOLDER_PATH, "PrintListAsosUnSold.pdf");
      PDFTableGenerator gen = new PDFTableGenerator(pdfFilePath);
      List<OrderDetail> controllerName = new List<OrderDetail>();
      Color HeaderColor = new Color(System.Drawing.ColorTranslator.FromHtml("#BDC3CF"));

      

      gen = new PDFTableGenerator(pdfFilePath, System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase("Last 3 Months Unsold List for ASOS".ToLower()), HeaderColor);
      gen.CellHeight = 200;
       
      gen.Columns = new List<PDFHeader>();
     
      gen.Columns.Add(new PDFHeader("PRINT UPLOAD DATE", iKandi.Common.ContentAlignment.Horizontal, 7));
      gen.Columns.Add(new PDFHeader("PRINT NO.", iKandi.Common.ContentAlignment.Horizontal, 7));
      gen.Columns.Add(new PDFHeader("FABRIC", iKandi.Common.ContentAlignment.Horizontal, 7));
      gen.Columns.Add(new PDFHeader("DEPARTMENT NAME", iKandi.Common.ContentAlignment.Horizontal, 10));
      gen.Columns.Add(new PDFHeader("ORIGINAL IMAGE", iKandi.Common.ContentAlignment.Horizontal, 10));
      gen.Columns.Add(new PDFHeader("DEVELOPED IMAGE", iKandi.Common.ContentAlignment.Horizontal, 10));

      gen.Rows = new List<List<PDFCell>>();

      foreach (DataRow dr in dt.Rows)
      {


        List<PDFCell> row = new List<PDFCell>();
        PDFCell cell;




        cell = new PDFCell(Convert.ToDateTime(dr["DatePurchased"].ToString()).ToString("dd MMM yy (ddd)"), iKandi.Common.ContentAlignment.Horizontal);
        cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
        cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
        cell.FontSize = 16;
        cell.Width = 400;
        cell.Height = 320;
        row.Add(cell);


        cell = new PDFCell("PRD " + dr["PrintNumber"].ToString(), iKandi.Common.ContentAlignment.Horizontal);
        cell.FontColor = "#0000FF";
        cell.FontSize = 16;
        cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
        cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
        cell.Width = 400;
        cell.Height = 320;
        row.Add(cell);

        cell = new PDFCell(dr["fabric"].ToString(), iKandi.Common.ContentAlignment.Horizontal);
        //cell.FontColor = "#0000FF";
        cell.FontSize = 16;
        cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
        cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
        cell.Width = 400;
        cell.Height = 320;
        row.Add(cell);

        cell = new PDFCell(dr["DepartmentName"].ToString(), iKandi.Common.ContentAlignment.Horizontal);
        cell.FontColor = "#0000FF";
        cell.FontSize = 16;
        cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
        cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
        cell.Width = 400;
        cell.Height = 320;
        row.Add(cell);

        string ImagePath = dr["ImageUrl"].ToString();
        if (ImagePath != "")
        {
          cell = new PDFCell(string.Empty, iKandi.Common.ContentAlignment.Horizontal);
          if (ImagePath != string.Empty)
            //cell.ImageUrl = Path.Combine(Constants.PRINT_FOLDER_PATH, "thumb-" + ImagePath);
            //cell.ImageUrl = Constants.MainUrlMail + "/uploads/Photo/thumb-" + ImagePath;
            cell.ImageUrl = Path.Combine(Constants.PRINT_FOLDER_PATH, "thumb-" + ImagePath);
          cell.ImageHeight = 300;
          cell.ImageWidth = 300;
          cell.Width = 400;
          cell.Height = 400;
          row.Add(cell);
        }
        else
        {
          cell = new PDFCell(string.Empty, iKandi.Common.ContentAlignment.Horizontal);
          cell.ImageUrl = Constants.MainUrlMail + "/uploads/Photo/Chrysanthemum.jpg";
          cell.ImageHeight = 300;
          cell.ImageWidth = 300;
          cell.Width = 400;
          cell.Height = 400;
          row.Add(cell);

        }
        string ImagePathdev = dr["DevelopedImageUrl"].ToString();
        if (ImagePath != "")
        {
          cell = new PDFCell(string.Empty, iKandi.Common.ContentAlignment.Horizontal);
          if (ImagePath != string.Empty)
            cell.ImageUrl = Path.Combine(Constants.PRINT_FOLDER_PATH, "thumb-" + ImagePathdev);
          cell.ImageHeight = 300;
          cell.ImageWidth = 300;
          cell.Width = 400;
          cell.Height = 400;
          row.Add(cell);
        }
        else
        {
          cell = new PDFCell(string.Empty, iKandi.Common.ContentAlignment.Horizontal);
          //cell.ImageUrl = Constants.MainUrlMail + "/uploads/Photo/Chrysanthemum.jpg";
          cell.ImageUrl = Path.Combine(Constants.PRINT_FOLDER_PATH, "thumb-" + ImagePathdev);
          cell.ImageHeight = 300;
          cell.ImageWidth = 300;
          cell.Width = 400;
          cell.Height = 400;
          row.Add(cell);
        }
        gen.Rows.Add(row);

      }
      if (gen.Rows.Count > 0)
      {
        return gen.GeneratePDF();
      }
      else
      {
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