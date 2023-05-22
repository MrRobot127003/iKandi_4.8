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
using iKandi.Common;
using iKandi.Web.Components;
using System.Globalization;
using System.Threading;
using System.Drawing;
using System.IO;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using iTextSharp;
using iKandi.BLL;
using System.Text;
using iKandi.BLL.Production;
using System.Net;
using Pechkin;
using iTextSharp.text;
using iTextSharp.text.html;
using System.Xml;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System.Web.Configuration;
using System.Text.RegularExpressions;

namespace iKandi.Web
{
  public partial class ClientDepartmentList : System.Web.UI.Page
  {
    AdminController objadmin = new AdminController();
    PDFController pdfcon = new PDFController();

    protected void Page_Load(object sender, EventArgs e)
    {
     // pdfcon.GenerateClientDepartmentList();

      if (!Page.IsPostBack)
      {
        DataSet dsFits = new DataSet();
        DataTable dtFits = new DataTable();

        dsFits = objadmin.GetFitsReport("FITS");
        dtFits = dsFits.Tables[0];

        for (int i = dtFits.Rows.Count - 1; i >= 0; i--)
        {
          DataRow dr = dtFits.Rows[i];
          if (dr["UserName"].ToString() == "Total")
            dr.Delete();
        }
        dtFits.AcceptChanges();

        grdclientdept.DataSource = dtFits;
        grdclientdept.DataBind();

        //string url = HttpContext.Current.Request.Url.AbsoluteUri;
        //WebClient MyWebClient = new WebClient();

        //// Read web page HTML to byte array
        //Byte[] PageHTMLBytes;
        //if (url != "")
        //{
        //  PageHTMLBytes = MyWebClient.DownloadData(url);

        //  // Convert result from byte array to string
        //  // and display it in TextBox txtPageHTML
        //  UTF8Encoding oUTF8 = new UTF8Encoding();
        //  string s = oUTF8.GetString(PageHTMLBytes);
        //}
       
      }
    }

    public void genertaePdf(string HTMLCode, string PolicyFile)
    {
      HTMLCode = getImage(HTMLCode);
      getvartypeHTML(HTMLCode, PolicyFile);

    }


    public void getvartypeHTML(string HTMLCode, string PolicyFile)
    {

        using (IPechkin pechkin = Factory.Create(new GlobalConfig()))
        {
            var pdf = pechkin.Convert(new ObjectConfig()
                                    .SetLoadImages(true).SetZoomFactor(1.5)
                                    .SetPrintBackground(true)
                                    .SetScreenMediaType(true)
                                    .SetCreateExternalLinks(true), (HTMLCode));
            using (FileStream file = System.IO.File.Create(PolicyFile))
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

    public void randorHtml()
    {
      WebRequest quest;
      WebResponse ponse;
      StreamReader reader;
      StreamWriter writer;
      string strHTML;


      //quest = WebRequest.Create("http://192.168.0.4/NewsLetterC45_46.aspx");
      quest = WebRequest.Create("http://localhost:3220/ClientDepartmentList.aspx");

      quest.Timeout = Convert.ToInt32(99999999);
      ponse = quest.GetResponse();
      reader = new StreamReader(ponse.GetResponseStream());
      strHTML = reader.ReadToEnd();
      string CurrentPageHtml = innerdiv.InnerHtml;
      CreatePDFDocument(CurrentPageHtml);
      string ReportHtml = "";
      ReportHtml = "Summery.html";
      writer = File.CreateText(Server.MapPath("~/Uploads/fits/" + ReportHtml));
      writer.WriteLine(strHTML);
      writer.Close();

    }
    

    public void CreatePDFDocument(string strHtml)
    {


      string strFileName = HttpContext.Current.Server.MapPath("~/Uploads/fits/Summery.pdf");

      //Creation of a document-object
      iTextSharp.text.Document document = new iTextSharp.text.Document();

      //We create a writer that listens to the document
      PdfWriter.GetInstance(document, new FileStream(strFileName, FileMode.Create));
      StringReader se = new StringReader(strHtml);
      HTMLWorker obj = new HTMLWorker(document);
      document.Open();
      obj.Parse(se);
      document.Close();
    }

  }
}