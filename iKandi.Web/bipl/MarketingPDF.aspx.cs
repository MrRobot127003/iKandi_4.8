using System;
using System.Collections.Generic;
using System.Text;
using iKandi.Common;
using System.Data;
using iTextSharp.text;
using System.IO;
using iTextSharp.text.html;
using iTextSharp.text.pdf;
using iTextSharp.text.rtf.headerfooter;
using System.Web;
using System.Text.RegularExpressions;
using iTextSharp.text.html.simpleparser;

namespace iKandi.Web.bipl
{
    public partial class MarketingPDF : System.Web.UI.Page
    {
        public int Test
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.QueryString["Test"]))
                {
                    return Convert.ToInt32(Request.QueryString["Test"]);
                }

                return -1;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Test == 1)
            {
                ShowPdf(@"D:\BIPLProfile.pdf");
            }
            else
            {
                Showpptx(@"D:\bipl-pdf.pptx");
            }
            Page.ClientScript.RegisterStartupScript(this.GetType(), "myCloseScript", "window.close()", true); 

        }
        public void Showpptx(string filename)
        {
            //Clears all content output from Buffer Stream
            Response.ClearContent();
            //Clears all headers from Buffer Stream
            Response.ClearHeaders();
            //Adds an HTTP header to the output stream

            // Response.AddHeader("Content-Disposition", "inline;filename=" + filename);
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + filename);
            //Gets or Sets the HTTP MIME type of the output stream
            Response.ContentType = "application/vnd.ms-powerpoint.addin.macroEnabled.12";
            //Writes the content of the specified file directory to an HTTP response output stream as a file block
            Response.WriteFile(filename);
            //sends all currently buffered output to the client
            Response.Flush();
            //Clears all content output from Buffer Stream
            Response.Clear();
        }

        public void ShowPdf(string filename)
        {
            //Clears all content output from Buffer Stream
            Response.ClearContent();
            //Clears all headers from Buffer Stream
            Response.ClearHeaders();
            //Adds an HTTP header to the output stream
            Response.AddHeader("Content-Disposition", "inline;filename=" + filename);
            //Gets or Sets the HTTP MIME type of the output stream
            Response.ContentType = "application/pdf";
            //Writes the content of the specified file directory to an HTTP response output stream as a file block
            Response.WriteFile(filename);
            //sends all currently buffered output to the client
            Response.Flush();
            //Clears all content output from Buffer Stream
            Response.Clear();
        }

    }
}