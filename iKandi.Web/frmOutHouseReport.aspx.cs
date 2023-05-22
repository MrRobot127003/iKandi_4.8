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
using iKandi.BLL;
using System.Text;
using iKandi.BLL.Production;
using System.Net;
using iTextSharp;
using Pechkin;
using iTextSharp.text.html;
using System.Xml;
using System.Runtime.CompilerServices;

using System.Web.Configuration;

using System.Text.RegularExpressions;

namespace iKandi.Web
{
    public partial class frmOutHouseReport : System.Web.UI.Page
    {
        AdminController objadmin = new AdminController();
        ReportController controller = new ReportController();
        ProductionController objProductionController = new ProductionController();

        string MailType = string.Empty;
        string Flag = string.Empty;
        string EmailContent = string.Empty;
        
        DataTable dtOutHouseReport = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            //CreateExcel(ds);
            randorHtml();
            bindgrd();
            string Month_PM_Img = System.IO.Path.Combine("http://boutique.in:81/pic/", "BIPLOPFactorMonthly.png");
            string Month_Delay_Img = System.IO.Path.Combine("http://boutique.in:81/pic/", "BIPLOHDelayMonthly.png");
            Month_PM_Img_Chart.Src = Month_PM_Img;
            Month_Delay_Img_Chart.Src = Month_Delay_Img;
        }
        public string GetColSpanUnit(string IsFirstQuarter, string IsSecondQuarter, string IsThirdQuarter, string IsFourthQuarter)
        {
            string Colspans = "";
            if (IsFirstQuarter == "True" && IsSecondQuarter == "True" && IsThirdQuarter == "True" && IsFourthQuarter == "True")
            {
                Colspans = "4";
            }
            else if (IsFirstQuarter == "True" && IsSecondQuarter == "True" && IsThirdQuarter == "True")
            {
                Colspans = "3";
            }
            else if (IsFirstQuarter == "True" && IsSecondQuarter == "True")
            {
                Colspans = "2";
            }
            else if (IsFirstQuarter == "True")
            {
                Colspans = "1";
            }
            return Colspans;

        }
        //Added code by Bharat On 13-jul-20 for Va Min Rate pdf
         public void randorHtml()
        {
            WebRequest quest;
            WebResponse ponse;
            StreamReader reader;
            //StreamWriter writer;
            string strHTML;
            quest = WebRequest.Create("http://localhost:3220/VAMinRate_Rrport.aspx");
            quest.Timeout = Convert.ToInt32(99999999);
            ponse = quest.GetResponse();
            reader = new StreamReader(ponse.GetResponseStream());
            strHTML = reader.ReadToEnd();
            genertaePdf(strHTML, "ss");
        }
        public void genertaePdf(string HTMLCode, string PolicyFile)
        {
            string strFileName = HttpContext.Current.Server.MapPath("~/Uploads/fits/" + "VAMinRateVendor_Report"+ ".pdf");
            HTMLCode = getImage(HTMLCode);
            getvartypeHTML(HTMLCode, strFileName);
        }
        public void getvartypeHTML(string HTMLCode, string PolicyFile)
        {
            string strFileName = HttpContext.Current.Server.MapPath("~/Uploads/fits/" + "VAMinRateVendor_Report" + ".pdf");

            using (IPechkin pechkin = Factory.Create(new GlobalConfig()))
            {
                var pdf = pechkin.Convert(new ObjectConfig()
                                        .SetLoadImages(true).SetZoomFactor(1.5)
                                        .SetPrintBackground(true)
                                        .SetScreenMediaType(true)
                                        .SetCreateExternalLinks(true), (HTMLCode));
                using (FileStream file = System.IO.File.Create(strFileName))
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
        public void CreatePDFDocument(string strHtml)
        {
            string strFileName = HttpContext.Current.Server.MapPath("~/Uploads/fits/" + "VAMinRateVendor_Report" + ".pdf");
            iTextSharp.text.Document document = new iTextSharp.text.Document();
            PdfWriter.GetInstance(document, new FileStream(strFileName, FileMode.Create));
            StringReader se = new StringReader(strHtml);
            HTMLWorker obj = new HTMLWorker(document);
            document.Open();
            obj.Parse(se);
            document.Close();
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
                    result = new StreamReader(resp.GetResponseStream()).ReadToEnd();
                }

            }

            catch (Exception ex)
            {
                string err = ex.Message.ToString();
            }

            return result;
        }



        protected void HideColumn()
        {
            //int index = 0;
            string IsFirstQuarter = dtOutHouseReport.Rows[0]["IsFirstQuarter"].ToString();
            string IsSecondQuarter = dtOutHouseReport.Rows[0]["IsSecondQuarter"].ToString();
            string IsThirdQuarter = dtOutHouseReport.Rows[0]["IsThirdQuarter"].ToString();
            string IsFourthQuarter = dtOutHouseReport.Rows[0]["IsFourthQuarter"].ToString();
            int Colspans = Convert.ToInt32(GetColSpanUnit(IsFirstQuarter, IsSecondQuarter, IsThirdQuarter, IsFourthQuarter));
            if (Colspans == 1)
            {
                grdOuthouseSummary.Columns[3].Visible = false;
                grdOuthouseSummary.Columns[4].Visible = false;
                grdOuthouseSummary.Columns[5].Visible = false;
                grdOuthouseSummary.Columns[8].Visible = false;
                grdOuthouseSummary.Columns[9].Visible = false;
                grdOuthouseSummary.Columns[10].Visible = false;
                grdOuthouseSummary.Columns[13].Visible = false;
                grdOuthouseSummary.Columns[14].Visible = false;
                grdOuthouseSummary.Columns[15].Visible = false;
                grdOuthouseSummary.Columns[18].Visible = false;

                grdOuthouseSummary.Columns[19].Visible = false;
                grdOuthouseSummary.Columns[20].Visible = false;
                grdOuthouseSummary.Columns[23].Visible = false;
                grdOuthouseSummary.Columns[24].Visible = false;
                grdOuthouseSummary.Columns[25].Visible = false;
                grdOuthouseSummary.Columns[28].Visible = false;
                grdOuthouseSummary.Columns[29].Visible = false;
                grdOuthouseSummary.Columns[30].Visible = false;

            }
            else if (Colspans == 2)
            {

                grdOuthouseSummary.Columns[4].Visible = false;
                grdOuthouseSummary.Columns[5].Visible = false;
                grdOuthouseSummary.Columns[9].Visible = false;
                grdOuthouseSummary.Columns[10].Visible = false;
                grdOuthouseSummary.Columns[14].Visible = false;
                grdOuthouseSummary.Columns[15].Visible = false;
                grdOuthouseSummary.Columns[19].Visible = false;
                grdOuthouseSummary.Columns[20].Visible = false;
                grdOuthouseSummary.Columns[24].Visible = false;
                grdOuthouseSummary.Columns[25].Visible = false;
                grdOuthouseSummary.Columns[29].Visible = false;
                grdOuthouseSummary.Columns[30].Visible = false;
            }
            else if (Colspans == 3)
            {

                grdOuthouseSummary.Columns[5].Visible = false;

                grdOuthouseSummary.Columns[10].Visible = false;
                grdOuthouseSummary.Columns[15].Visible = false;
                grdOuthouseSummary.Columns[20].Visible = false;
                grdOuthouseSummary.Columns[25].Visible = false;
                grdOuthouseSummary.Columns[30].Visible = false;


            }

        }
        //protected void HideColumnWithoutStitch()
        //{
        //    int index = 0;
        //    string IsFirstQuarter = dtAvgWithoutStitch.Rows[0]["IsFirstQuarter"].ToString();
        //    string IsSecondQuarter = dtAvgWithoutStitch.Rows[0]["IsSecondQuarter"].ToString();
        //    string IsThirdQuarter = dtAvgWithoutStitch.Rows[0]["IsThirdQuarter"].ToString();
        //    string IsFourthQuarter = dtAvgWithoutStitch.Rows[0]["IsFourthQuarter"].ToString();
        //    int Colspans = Convert.ToInt32(GetColSpanUnit(IsFirstQuarter, IsSecondQuarter, IsThirdQuarter, IsFourthQuarter));
        //    if (Colspans == 1)
        //    {

        //        grdfabavgwithoutstitch.Columns[3].Visible = false;
        //        grdfabavgwithoutstitch.Columns[4].Visible = false;
        //        grdfabavgwithoutstitch.Columns[5].Visible = false;

        //        grdfabavgwithoutstitch.Columns[7].Visible = false;
        //        grdfabavgwithoutstitch.Columns[8].Visible = false;
        //        grdfabavgwithoutstitch.Columns[9].Visible = false;

        //        grdfabavgwithoutstitch.Columns[12].Visible = false;
        //        grdfabavgwithoutstitch.Columns[13].Visible = false;
        //        grdfabavgwithoutstitch.Columns[15].Visible = false;


        //        //grdfabavgwithoutstitch.Columns[18].Visible = false;
        //        //grdfabavgwithoutstitch.Columns[19].Visible = false;
        //        //grdfabavgwithoutstitch.Columns[20].Visible = false;


        //    }
        //    else if (Colspans == 2)
        //    {

        //        grdfabavgwithoutstitch.Columns[4].Visible = false;
        //        grdfabavgwithoutstitch.Columns[5].Visible = false;
        //        grdfabavgwithoutstitch.Columns[8].Visible = false;
        //        grdfabavgwithoutstitch.Columns[9].Visible = false;
        //        grdfabavgwithoutstitch.Columns[13].Visible = false;
        //        grdfabavgwithoutstitch.Columns[15].Visible = false;
        //        //grdfabavgwithoutstitch.Columns[18].Visible = false;
        //        //grdfabavgwithoutstitch.Columns[19].Visible = false;
        //        //grdfabavgwithoutstitch.Columns[20].Visible = false;

        //    }
        //    else if (Colspans == 3)
        //    {

        //        grdfabavgwithoutstitch.Columns[5].Visible = false;
        //        grdfabavgwithoutstitch.Columns[10].Visible = false;
        //        grdfabavgwithoutstitch.Columns[15].Visible = false;
        //        //grdfabavgwithoutstitch.Columns[20].Visible = false;
        //    }

        //}

        public string GetMonthYear()
        {
            string curentmontval = "";
            string endMonthYear = "";
            string StartMonthYear = "";

            // This block is for the End month and year
            if (DateTime.Now.Month == 5)
            {
                endMonthYear = "";
            }
            else
            {
                endMonthYear = DateTime.Now.AddMonths(-1).ToString("MMM") + " " + DateTime.Now.AddMonths(-1).ToString("yy");
            }

            // This block is for start month and year
            if (DateTime.Now.Month == 4)
            {
                StartMonthYear = "Jan" + " " + DateTime.Now.AddMonths(-1).ToString("yy");
            }
            else if (DateTime.Now.Month == 1 || DateTime.Now.Month == 2 || DateTime.Now.Month == 3)
            {
                StartMonthYear = "Apr" + " " + DateTime.Now.AddYears(-1).ToString("yy");
            }
            else
            {
                StartMonthYear = "Apr" + " " + DateTime.Now.AddYears(0).ToString("yy");
            }

            if (endMonthYear == "")
            {
                curentmontval = StartMonthYear;
            }
            else
            {
                curentmontval = StartMonthYear + " - " + endMonthYear;
            }

            return curentmontval;
        }

        public int GetQuarterNumber()
        {
            int QtrNumber = 0;
            if (DateTime.Now.Month >= 1 && DateTime.Now.Month <= 3)
            {
                QtrNumber = 4;
            }
            else if (DateTime.Now.Month >= 4 && DateTime.Now.Month <= 6)
            {
                QtrNumber = 1;
            }
            else if (DateTime.Now.Month >= 7 && DateTime.Now.Month <= 9)
            {
                QtrNumber = 2;
            }
            else 
            {
                QtrNumber = 3;
            }

            return QtrNumber;
        }

        protected void grdOuthouseSummary_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                string previousMonth = DateTime.Now.AddMonths(-1).ToString("MMM");
                string CurrentMonth = DateTime.Now.AddMonths(0).ToString("MMM");

                GridView HeaderGrid = (GridView)sender;
                GridViewRow HeaderGridRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
                
                String CurrentQuarterNumber = "";
                CurrentQuarterNumber = Convert.ToString(GetQuarterNumber());

                string IsFirstQuarter = dtOutHouseReport.Rows[0]["IsFirstQuarter"].ToString();
                string IsSecondQuarter = dtOutHouseReport.Rows[0]["IsSecondQuarter"].ToString();
                string IsThirdQuarter = dtOutHouseReport.Rows[0]["IsThirdQuarter"].ToString();
                string IsFourthQuarter = dtOutHouseReport.Rows[0]["IsFourthQuarter"].ToString();
                int Colspans = Convert.ToInt32(GetColSpanUnit(IsFirstQuarter, IsSecondQuarter, IsThirdQuarter, IsFourthQuarter));

                TableCell HeaderCell = new TableCell();
                HeaderCell.Text = "Fabricator";
                HeaderCell.RowSpan = 2;
                HeaderCell.Style.Add("text-align", "center");
                HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#DDDFE4");
                HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#575759");
                HeaderCell.BorderColor = System.Drawing.ColorTranslator.FromHtml("#999999");
                HeaderCell.Attributes.Add("Class", "fontsizecolor");
                HeaderGridRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Total Machines";
                HeaderCell.RowSpan = 2;
                HeaderCell.Style.Add("text-align", "center");
                HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#DDDFE4");
                HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#575759");
                HeaderCell.Attributes.Add("Class", "fontsizecolor");
                HeaderCell.BorderColor = System.Drawing.ColorTranslator.FromHtml("#999999");
                HeaderGridRow.Cells.Add(HeaderCell);


                HeaderCell = new TableCell();
                HeaderCell.Text = "Machines in Use";
                HeaderCell.ColumnSpan = Colspans + 1;
                HeaderCell.Style.Add("text-align", "center");
                HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#DDDFE4");
                HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#575759");
                HeaderCell.Attributes.Add("Class", "fontsizecolor");
                HeaderCell.BorderColor = System.Drawing.ColorTranslator.FromHtml("#999999");
                HeaderGridRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Styles Costed";
                HeaderCell.ColumnSpan = Colspans + 1;
                HeaderCell.Style.Add("text-align", "center");
                HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#DDDFE4");
                HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#575759");
                HeaderCell.Attributes.Add("Class", "fontsizecolor");
                HeaderCell.BorderColor = System.Drawing.ColorTranslator.FromHtml("#999999");
                HeaderGridRow.Cells.Add(HeaderCell);


                HeaderCell = new TableCell();
                HeaderCell.Text = "Monthly pcs stitch";
                HeaderCell.ColumnSpan = Colspans + 1;
                HeaderCell.Style.Add("text-align", "center");
                HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#DDDFE4");
                HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#575759");
                HeaderCell.Attributes.Add("Class", "fontsizecolor");
                HeaderCell.BorderColor = System.Drawing.ColorTranslator.FromHtml("#999999");
                HeaderGridRow.Cells.Add(HeaderCell);



                HeaderCell = new TableCell();
                HeaderCell.Text = "Initial Multiplier";
                HeaderCell.ColumnSpan = Colspans + 1;
                HeaderCell.Style.Add("text-align", "center");
                HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#DDDFE4");
                HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#575759");
                HeaderCell.Attributes.Add("Class", "fontsizecolor");
                HeaderCell.BorderColor = System.Drawing.ColorTranslator.FromHtml("#999999");
                HeaderGridRow.Cells.Add(HeaderCell);


                HeaderCell = new TableCell();
                HeaderCell.Text = "Production Multiplier";
                HeaderCell.ColumnSpan = Colspans + 1;
                HeaderCell.Style.Add("text-align", "center");
                HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#DDDFE4");
                HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#575759");
                HeaderCell.Attributes.Add("Class", "fontsizecolor");
                HeaderCell.BorderColor = System.Drawing.ColorTranslator.FromHtml("#999999");
                HeaderGridRow.Cells.Add(HeaderCell);


                HeaderCell = new TableCell();
                HeaderCell.Text = "Avg. Delay in Weeks";
                HeaderCell.ColumnSpan = Colspans + 1;
                HeaderCell.Style.Add("text-align", "center");
                HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#DDDFE4");
                HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#575759");
                HeaderCell.Attributes.Add("Class", "fontsizecolor");
                HeaderCell.BorderColor = System.Drawing.ColorTranslator.FromHtml("#999999");
                HeaderGridRow.Cells.Add(HeaderCell);



                grdOuthouseSummary.Controls[0].Controls.AddAt(0, HeaderGridRow);

                GridViewRow HeaderGridRow1 = new GridViewRow(1, 0, DataControlRowType.Header, DataControlRowState.Insert);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Last 6 Months";
                HeaderCell.Style.Add("text-align", "center");
                HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#DDDFE4");
                HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#575759");
                HeaderCell.Attributes.Add("Class", "fontsizecolor");
                HeaderCell.BorderColor = System.Drawing.ColorTranslator.FromHtml("#999999");
                HeaderCell.Width = 94;


                HeaderGridRow1.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Q2";
                HeaderCell.Style.Add("text-align", "center");
                HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#DDDFE4");
                HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#575759");
                HeaderCell.Attributes.Add("Class", "fontsizecolor");
                HeaderCell.BorderColor = System.Drawing.ColorTranslator.FromHtml("#999999");
                HeaderCell.Width = 94;
                if (Colspans == 1)
                {
                    HeaderCell.Visible = false;
                }

                HeaderGridRow1.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Q" + CurrentQuarterNumber;
                HeaderCell.Style.Add("text-align", "center");
                HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#DDDFE4");
                HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#575759");
                HeaderCell.Attributes.Add("Class", "fontsizecolor");
                HeaderCell.BorderColor = System.Drawing.ColorTranslator.FromHtml("#999999");
                HeaderCell.Width = 94;
                if (Colspans == 1)
                {
                    HeaderCell.Visible = false;
                }
                HeaderGridRow1.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Q" + CurrentQuarterNumber;
                HeaderCell.Style.Add("text-align", "center");
                HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#DDDFE4");
                HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#575759");
                HeaderCell.Attributes.Add("Class", "fontsizecolor");
                HeaderCell.BorderColor = System.Drawing.ColorTranslator.FromHtml("#999999");
                HeaderCell.Width = 94;
                if (Colspans == 1)
                {
                    HeaderCell.Visible = false;
                }
                else if (Colspans == 3)
                {
                    HeaderCell.Visible = false;
                }
                HeaderGridRow1.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Q" + CurrentQuarterNumber;
                HeaderCell.Style.Add("text-align", "center");
                HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#DDDFE4");
                HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#575759");
                HeaderCell.Attributes.Add("Class", "fontsizecolor");
                HeaderCell.BorderColor = System.Drawing.ColorTranslator.FromHtml("#999999");
                HeaderGridRow1.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Last 6 Months";
                HeaderCell.Style.Add("text-align", "center");
                HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#DDDFE4");
                HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#575759");
                HeaderCell.Attributes.Add("Class", "fontsizecolor");
                HeaderCell.BorderColor = System.Drawing.ColorTranslator.FromHtml("#999999");
                HeaderCell.Width = 94;
                HeaderGridRow1.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Q" + CurrentQuarterNumber;
                HeaderCell.Style.Add("text-align", "center");
                HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#DDDFE4");
                HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#575759");
                HeaderCell.Attributes.Add("Class", "fontsizecolor");
                HeaderCell.BorderColor = System.Drawing.ColorTranslator.FromHtml("#999999");
                HeaderCell.Width = 94;
                if (Colspans == 1)
                {
                    HeaderCell.Visible = false;
                }
                HeaderGridRow1.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Q" + CurrentQuarterNumber;
                HeaderCell.Style.Add("text-align", "center");
                HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#DDDFE4");
                HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#575759");
                HeaderCell.Attributes.Add("Class", "fontsizecolor");
                HeaderCell.BorderColor = System.Drawing.ColorTranslator.FromHtml("#999999");
                HeaderCell.Width = 94;
                HeaderGridRow1.Cells.Add(HeaderCell);
                if (Colspans == 1)
                {
                    HeaderCell.Visible = false;
                }

                HeaderCell = new TableCell();
                HeaderCell.Text = "Q" + CurrentQuarterNumber;
                HeaderCell.Style.Add("text-align", "center");
                HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#DDDFE4");
                HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#575759");
                HeaderCell.Attributes.Add("Class", "fontsizecolor");
                HeaderCell.BorderColor = System.Drawing.ColorTranslator.FromHtml("#999999");
                HeaderCell.Width = 94;
                if (Colspans == 1)
                {
                    HeaderCell.Visible = false;
                }
                else if (Colspans == 3)
                {
                    HeaderCell.Visible = false;
                }
                HeaderGridRow1.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Q" + CurrentQuarterNumber;
                HeaderCell.Style.Add("text-align", "center");
                HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#DDDFE4");
                HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#575759");
                HeaderCell.Attributes.Add("Class", "fontsizecolor");
                HeaderCell.BorderColor = System.Drawing.ColorTranslator.FromHtml("#999999");
                HeaderGridRow1.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Last 6 Months";
                HeaderCell.Style.Add("text-align", "center");
                HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#DDDFE4");
                HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#575759");
                HeaderCell.Attributes.Add("Class", "fontsizecolor");
                HeaderCell.BorderColor = System.Drawing.ColorTranslator.FromHtml("#999999");
                HeaderCell.Width = 94;
                HeaderGridRow1.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Q" + CurrentQuarterNumber;
                HeaderCell.Style.Add("text-align", "center");
                HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#DDDFE4");
                HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#575759");
                HeaderCell.Attributes.Add("Class", "fontsizecolor");
                HeaderCell.BorderColor = System.Drawing.ColorTranslator.FromHtml("#999999");
                HeaderCell.Width = 94;
                if (Colspans == 1)
                {
                    HeaderCell.Visible = false;
                }
                HeaderGridRow1.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Q" + CurrentQuarterNumber;
                HeaderCell.Style.Add("text-align", "center");
                HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#DDDFE4");
                HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#575759");
                HeaderCell.Attributes.Add("Class", "fontsizecolor");
                HeaderCell.BorderColor = System.Drawing.ColorTranslator.FromHtml("#999999");
                HeaderCell.Width = 94;
                if (Colspans == 1)
                {
                    HeaderCell.Visible = false;
                }
                HeaderGridRow1.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Q" + CurrentQuarterNumber;
                HeaderCell.Style.Add("text-align", "center");
                HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#DDDFE4");
                HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#575759");
                HeaderCell.Attributes.Add("Class", "fontsizecolor");
                HeaderCell.BorderColor = System.Drawing.ColorTranslator.FromHtml("#999999");
                HeaderCell.Width = 94;
                if (Colspans == 1)
                {
                    HeaderCell.Visible = false;
                }
                else if (Colspans == 3)
                {
                    HeaderCell.Visible = false;
                }
                HeaderGridRow1.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Q" + CurrentQuarterNumber;
                HeaderCell.Style.Add("text-align", "center");
                HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#DDDFE4");
                HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#575759");
                HeaderCell.Attributes.Add("Class", "fontsizecolor");
                HeaderCell.BorderColor = System.Drawing.ColorTranslator.FromHtml("#999999");
                HeaderGridRow1.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Last 6 Months";
                HeaderCell.Style.Add("text-align", "center");
                HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#DDDFE4");
                HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#575759");
                HeaderCell.Attributes.Add("Class", "fontsizecolor");
                HeaderCell.BorderColor = System.Drawing.ColorTranslator.FromHtml("#999999");
                HeaderCell.Width = 94;
                HeaderGridRow1.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Q" + CurrentQuarterNumber;
                HeaderCell.Style.Add("text-align", "center");
                HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#DDDFE4");
                HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#575759");
                HeaderCell.Attributes.Add("Class", "fontsizecolor");
                HeaderCell.BorderColor = System.Drawing.ColorTranslator.FromHtml("#999999");
                HeaderCell.Width = 94;
                if (Colspans == 1)
                {
                    HeaderCell.Visible = false;
                }
                HeaderGridRow1.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Q" + CurrentQuarterNumber;
                HeaderCell.Style.Add("text-align", "center");
                HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#DDDFE4");
                HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#575759");
                HeaderCell.Attributes.Add("Class", "fontsizecolor");
                HeaderCell.BorderColor = System.Drawing.ColorTranslator.FromHtml("#999999");
                if (Colspans == 1)
                {
                    HeaderCell.Visible = false;
                }
                HeaderCell.Width = 94;

                HeaderGridRow1.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Q" + CurrentQuarterNumber;
                HeaderCell.Style.Add("text-align", "center");
                HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#DDDFE4");
                HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#575759");
                HeaderCell.Attributes.Add("Class", "fontsizecolor");
                HeaderCell.BorderColor = System.Drawing.ColorTranslator.FromHtml("#999999");
                HeaderCell.Width = 94;
                if (Colspans == 1)
                {
                    HeaderCell.Visible = false;
                }
                else if (Colspans == 3)
                {
                    HeaderCell.Visible = false;
                }
                HeaderGridRow1.Cells.Add(HeaderCell);



                HeaderCell = new TableCell();
                HeaderCell.Text = "Q" + CurrentQuarterNumber;
                HeaderCell.Style.Add("text-align", "center");
                HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#DDDFE4");
                HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#575759");
                HeaderCell.Attributes.Add("Class", "fontsizecolor");
                HeaderCell.BorderColor = System.Drawing.ColorTranslator.FromHtml("#999999");
                HeaderGridRow1.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Last 6 Months";
                HeaderCell.Style.Add("text-align", "center");
                HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#DDDFE4");
                HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#575759");
                HeaderCell.Attributes.Add("Class", "fontsizecolor");
                HeaderCell.BorderColor = System.Drawing.ColorTranslator.FromHtml("#999999");
                HeaderCell.Width = 94;
                HeaderGridRow1.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Q" + CurrentQuarterNumber;
                HeaderCell.Style.Add("text-align", "center");
                HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#DDDFE4");
                HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#575759");
                HeaderCell.Attributes.Add("Class", "fontsizecolor");
                HeaderCell.BorderColor = System.Drawing.ColorTranslator.FromHtml("#999999");
                HeaderCell.Width = 94;
                if (Colspans == 1)
                {
                    HeaderCell.Visible = false;
                }
                HeaderGridRow1.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Q" + CurrentQuarterNumber;
                HeaderCell.Style.Add("text-align", "center");
                HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#DDDFE4");
                HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#575759");
                HeaderCell.Attributes.Add("Class", "fontsizecolor");
                HeaderCell.BorderColor = System.Drawing.ColorTranslator.FromHtml("#999999");
                HeaderCell.Width = 94;
                if (Colspans == 2)
                {
                    HeaderCell.Visible = false;
                }
                else if (Colspans == 1)
                {
                    HeaderCell.Visible = false;
                }
                HeaderGridRow1.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Q" + CurrentQuarterNumber;
                HeaderCell.Style.Add("text-align", "center");
                HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#DDDFE4");
                HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#575759");
                HeaderCell.Attributes.Add("Class", "fontsizecolor");
                HeaderCell.BorderColor = System.Drawing.ColorTranslator.FromHtml("#999999");
                HeaderCell.Width = 94;
                if (Colspans == 2)
                {
                    HeaderCell.Visible = false;
                }
                else if (Colspans == 1)
                {
                    HeaderCell.Visible = false;
                }
                else if (Colspans == 3)
                {
                    HeaderCell.Visible = false;
                }
                HeaderGridRow1.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Q" + CurrentQuarterNumber;
                HeaderCell.Style.Add("text-align", "center");
                HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#DDDFE4");
                HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#575759");
                HeaderCell.Attributes.Add("Class", "fontsizecolor");
                HeaderCell.BorderColor = System.Drawing.ColorTranslator.FromHtml("#999999");
                HeaderGridRow1.Cells.Add(HeaderCell);


                HeaderCell = new TableCell();
                HeaderCell.Text = "Last 6 Months";
                HeaderCell.Style.Add("text-align", "center");
                HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#DDDFE4");
                HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#575759");
                HeaderCell.Attributes.Add("Class", "fontsizecolor");
                HeaderCell.BorderColor = System.Drawing.ColorTranslator.FromHtml("#999999");
                HeaderCell.Width = 94;
                HeaderGridRow1.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Q" + CurrentQuarterNumber;
                HeaderCell.Style.Add("text-align", "center");
                HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#DDDFE4");
                HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#575759");
                HeaderCell.Attributes.Add("Class", "fontsizecolor");
                HeaderCell.BorderColor = System.Drawing.ColorTranslator.FromHtml("#999999");
                HeaderCell.Width = 94;
                if (Colspans == 1)
                {
                    HeaderCell.Visible = false;
                }
                HeaderGridRow1.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Q" + CurrentQuarterNumber;
                HeaderCell.Style.Add("text-align", "center");
                HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#DDDFE4");
                HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#575759");
                HeaderCell.Attributes.Add("Class", "fontsizecolor");
                HeaderCell.BorderColor = System.Drawing.ColorTranslator.FromHtml("#999999");
                HeaderCell.Width = 94;
                if (Colspans == 2)
                {
                    HeaderCell.Visible = false;
                }
                else if (Colspans == 1)
                {
                    HeaderCell.Visible = false;
                }
                HeaderGridRow1.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Q" + CurrentQuarterNumber;
                HeaderCell.Style.Add("text-align", "center");
                HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#DDDFE4");
                HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#575759");
                HeaderCell.Attributes.Add("Class", "fontsizecolor");
                HeaderCell.BorderColor = System.Drawing.ColorTranslator.FromHtml("#999999");
                HeaderCell.Width = 94;
                if (Colspans == 2)
                {
                    HeaderCell.Visible = false;
                    //HeaderCell.Visible = false;
                }
                else if (Colspans == 1)
                {
                    HeaderCell.Visible = false;
                }
                else if (Colspans == 3)
                {
                    HeaderCell.Visible = false;
                }
                HeaderGridRow1.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Q" + CurrentQuarterNumber;
                HeaderCell.Style.Add("text-align", "center");
                HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#DDDFE4");
                HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#575759");
                HeaderCell.Attributes.Add("Class", "fontsizecolor");
                HeaderCell.BorderColor = System.Drawing.ColorTranslator.FromHtml("#999999");
                HeaderGridRow1.Cells.Add(HeaderCell);

                grdOuthouseSummary.Controls[0].Controls.AddAt(1, HeaderGridRow1);

            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblFabricatorName = (Label)e.Row.FindControl("lblFabricatorName");
                Label lblCurrentMonth_Production = (Label)e.Row.FindControl("lblCurrentMonth_Production");
                Label lblCurrentMonth_AvgDelay = (Label)e.Row.FindControl("lblCurrentMonth_AvgDelay");
                

                Label lblFirstQuarter_Average_Pcs_PerDayOutPut = (Label)e.Row.FindControl("lblFirstQuarter_Average_Pcs_PerDayOutPut");
                Label lblSecondQuarter_Average_Pcs_PerDayOutPut = (Label)e.Row.FindControl("lblSecondQuarter_Average_Pcs_PerDayOutPut");
                Label lblThirdQuarter_Average_Pcs_PerDayOutPut = (Label)e.Row.FindControl("lblThirdQuarter_Average_Pcs_PerDayOutPut");
                Label lblFourthQuarter_Average_Pcs_PerDayOutPut = (Label)e.Row.FindControl("lblFourthQuarter_Average_Pcs_PerDayOutPut");
                Label lblCurrentMonth_Average_Pcs_PerDayOutPut = (Label)e.Row.FindControl("lblCurrentMonth_Average_Pcs_PerDayOutPut");
                if (lblFabricatorName.Text == "Total")
                {
                    DataSet dsTotalMuliplierFactor_For_Financial_Month = new DataSet();
                    dsTotalMuliplierFactor_For_Financial_Month = objadmin.TotalMuliplierFactor_For_Financial_Month();
                    lblCurrentMonth_Production.Text = dsTotalMuliplierFactor_For_Financial_Month.Tables[0].Rows[0]["TotalValue_Current"].ToString();
                    lblCurrentMonth_AvgDelay.Text = dsTotalMuliplierFactor_For_Financial_Month.Tables[1].Rows[0]["TotalValue_Current"].ToString();
                }
                HiddenField hdnOrderQty = (HiddenField)e.Row.FindControl("hdnOrderQty");

                if (!string.IsNullOrEmpty(lblFirstQuarter_Average_Pcs_PerDayOutPut.Text))
                {
                    if (Convert.ToDecimal(lblFirstQuarter_Average_Pcs_PerDayOutPut.Text) > 999)
                    {
                        lblFirstQuarter_Average_Pcs_PerDayOutPut.Text = (Math.Round(Convert.ToDecimal(lblFirstQuarter_Average_Pcs_PerDayOutPut.Text) / 1000)).ToString() + "k";
                    }
                }
                if (!string.IsNullOrEmpty(lblSecondQuarter_Average_Pcs_PerDayOutPut.Text))
                {
                    if (Convert.ToInt32(lblSecondQuarter_Average_Pcs_PerDayOutPut.Text) > 999)
                    {
                        lblSecondQuarter_Average_Pcs_PerDayOutPut.Text = (Convert.ToInt32(lblSecondQuarter_Average_Pcs_PerDayOutPut.Text) / 1000).ToString() + "k";
                    }
                }
                if (!string.IsNullOrEmpty(lblThirdQuarter_Average_Pcs_PerDayOutPut.Text))
                {
                    if (Convert.ToInt32(lblThirdQuarter_Average_Pcs_PerDayOutPut.Text) > 999)
                    {
                        lblThirdQuarter_Average_Pcs_PerDayOutPut.Text = (Convert.ToInt32(lblThirdQuarter_Average_Pcs_PerDayOutPut.Text) / 1000).ToString() + "k";
                    }
                }
                if (!string.IsNullOrEmpty(lblFourthQuarter_Average_Pcs_PerDayOutPut.Text))
                {
                    if (Convert.ToInt32(lblFourthQuarter_Average_Pcs_PerDayOutPut.Text) > 999)
                    {
                        lblFourthQuarter_Average_Pcs_PerDayOutPut.Text = (Convert.ToInt32(lblFourthQuarter_Average_Pcs_PerDayOutPut.Text) / 1000).ToString() + "k";
                    }
                }
                if (!string.IsNullOrEmpty(lblCurrentMonth_Average_Pcs_PerDayOutPut.Text))
                {
                    if (Convert.ToInt32(lblCurrentMonth_Average_Pcs_PerDayOutPut.Text) > 999)
                    {
                        lblCurrentMonth_Average_Pcs_PerDayOutPut.Text = (Math.Round(Convert.ToDecimal(lblCurrentMonth_Average_Pcs_PerDayOutPut.Text) / 1000)).ToString() + "k";
                    }
                }

            }


        }

        //protected void grdfabavgwithoutstitch_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    if (e.Row.RowType == DataControlRowType.Header)
        //    {
        //        string previousMonth = DateTime.Now.AddMonths(-1).ToString("MMM");
        //        string CurrentMonth = DateTime.Now.AddMonths(0).ToString("MMM");

        //        GridView HeaderGrid = (GridView)sender;
        //        GridViewRow HeaderGridRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);

        //        string IsFirstQuarter = dtAvgWithoutStitch.Rows[0]["IsFirstQuarter"].ToString();
        //        string IsSecondQuarter = dtAvgWithoutStitch.Rows[0]["IsSecondQuarter"].ToString();
        //        string IsThirdQuarter = dtAvgWithoutStitch.Rows[0]["IsThirdQuarter"].ToString();
        //        string IsFourthQuarter = dtAvgWithoutStitch.Rows[0]["IsFourthQuarter"].ToString();
        //        int Colspans = Convert.ToInt32(GetColSpanUnit(IsFirstQuarter, IsSecondQuarter, IsThirdQuarter, IsFourthQuarter));

        //        TableCell HeaderCell = new TableCell();
        //        HeaderCell.Text = "Fabricator";
        //        HeaderCell.RowSpan = 2;
        //        HeaderCell.Style.Add("text-align", "center");
        //        HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#DDDFE4");
        //        HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#575759");
        //        HeaderCell.Attributes.Add("Class", "fontsizecolor2");
        //        HeaderCell.BorderColor = System.Drawing.ColorTranslator.FromHtml("#999999");
        //        HeaderGridRow.Cells.Add(HeaderCell);

        //        HeaderCell = new TableCell();
        //        HeaderCell.Text = "Total Machines";
        //        HeaderCell.RowSpan = 2;
        //        HeaderCell.Style.Add("text-align", "center");
        //        HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#DDDFE4");
        //        HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#575759");
        //        HeaderCell.Attributes.Add("Class", "fontsizecolor2");
        //        HeaderCell.BorderColor = System.Drawing.ColorTranslator.FromHtml("#999999");
        //        HeaderGridRow.Cells.Add(HeaderCell);

        //        HeaderCell = new TableCell();
        //        HeaderCell.Text = "Styles Costed";
        //        HeaderCell.ColumnSpan = Colspans + 1;
        //        HeaderCell.Style.Add("text-align", "center");
        //        HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#DDDFE4");
        //        HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#575759");
        //        HeaderCell.Attributes.Add("Class", "fontsizecolor2");
        //        HeaderCell.BorderColor = System.Drawing.ColorTranslator.FromHtml("#999999");
        //        HeaderGridRow.Cells.Add(HeaderCell);

        //        HeaderCell = new TableCell();
        //        HeaderCell.Text = "Initial Multiplier";
        //        HeaderCell.ColumnSpan = Colspans + 1;
        //        HeaderCell.Style.Add("text-align", "center");
        //        HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#DDDFE4");
        //        HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#575759");
        //        HeaderCell.Attributes.Add("Class", "fontsizecolor2");
        //        HeaderCell.BorderColor = System.Drawing.ColorTranslator.FromHtml("#999999");
        //        HeaderGridRow.Cells.Add(HeaderCell);


        //        HeaderCell = new TableCell();
        //        HeaderCell.Text = "Production Multiplier";
        //        HeaderCell.ColumnSpan = Colspans + 1;
        //        HeaderCell.Style.Add("text-align", "center");
        //        HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#DDDFE4");
        //        HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#575759");
        //        HeaderCell.Attributes.Add("Class", "fontsizecolor2");
        //        HeaderCell.BorderColor = System.Drawing.ColorTranslator.FromHtml("#999999");
        //        HeaderGridRow.Cells.Add(HeaderCell);

        //        grdfabavgwithoutstitch.Controls[0].Controls.AddAt(0, HeaderGridRow);
        //        GridViewRow HeaderGridRow1 = new GridViewRow(1, 0, DataControlRowType.Header, DataControlRowState.Insert);

        //        HeaderCell = new TableCell();
        //        HeaderCell.Text = GetMonthYear();
        //        HeaderCell.Style.Add("text-align", "center");
        //        HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#DDDFE4");
        //        HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#575759");
        //        HeaderCell.Attributes.Add("Class", "fontsizecolor2");
        //        HeaderCell.BorderColor = System.Drawing.ColorTranslator.FromHtml("#999999");
        //        HeaderCell.Width = 94;
        //        HeaderGridRow1.Cells.Add(HeaderCell);

        //        HeaderCell = new TableCell();
        //        HeaderCell.Text = "Q2";
        //        HeaderCell.Style.Add("text-align", "center");
        //        HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#DDDFE4");
        //        HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#575759");
        //        HeaderCell.Attributes.Add("Class", "fontsizecolor2");
        //        HeaderCell.BorderColor = System.Drawing.ColorTranslator.FromHtml("#999999");
        //        HeaderCell.Width = 94;
        //        if (Colspans == 1)
        //        {
        //            HeaderCell.Visible = false;
        //        }
        //        HeaderGridRow1.Cells.Add(HeaderCell);

        //        HeaderCell = new TableCell();
        //        HeaderCell.Text = "Q3";
        //        HeaderCell.Style.Add("text-align", "center");
        //        HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#DDDFE4");
        //        HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#575759");
        //        HeaderCell.Attributes.Add("Class", "fontsizecolor2");
        //        HeaderCell.BorderColor = System.Drawing.ColorTranslator.FromHtml("#999999");
        //        HeaderCell.Width = 94;
        //        HeaderGridRow1.Cells.Add(HeaderCell);
        //        if (Colspans == 1)
        //        {
        //            HeaderCell.Visible = false;
        //        }

        //        HeaderCell = new TableCell();
        //        HeaderCell.Text = "Q2";
        //        HeaderCell.Style.Add("text-align", "center");
        //        HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#DDDFE4");
        //        HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#575759");
        //        HeaderCell.Attributes.Add("Class", "fontsizecolor2");
        //        HeaderCell.BorderColor = System.Drawing.ColorTranslator.FromHtml("#999999");
        //        HeaderCell.Width = 94;
        //        if (Colspans == 1)
        //        {
        //            HeaderCell.Visible = false;
        //        }
        //        else if (Colspans == 3)
        //        {
        //            HeaderCell.Visible = false;
        //        }
        //        HeaderGridRow1.Cells.Add(HeaderCell);

        //        HeaderCell = new TableCell();
        //        HeaderCell.Text = CurrentMonth;
        //        HeaderCell.Style.Add("text-align", "center");
        //        HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#DDDFE4");
        //        HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#575759");
        //        HeaderCell.Attributes.Add("Class", "fontsizecolor2");
        //        HeaderCell.BorderColor = System.Drawing.ColorTranslator.FromHtml("#999999");
        //        HeaderGridRow1.Cells.Add(HeaderCell);

        //        HeaderCell = new TableCell();
        //        HeaderCell.Text = GetMonthYear();
        //        HeaderCell.Style.Add("text-align", "center");
        //        HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#DDDFE4");
        //        HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#575759");
        //        HeaderCell.Attributes.Add("Class", "fontsizecolor2");
        //        HeaderCell.BorderColor = System.Drawing.ColorTranslator.FromHtml("#999999");
        //        HeaderCell.Width = 94;
        //        HeaderGridRow1.Cells.Add(HeaderCell);

        //        HeaderCell = new TableCell();
        //        HeaderCell.Text = "Q2";
        //        HeaderCell.Style.Add("text-align", "center");
        //        HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#DDDFE4");
        //        HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#575759");
        //        HeaderCell.Attributes.Add("Class", "fontsizecolor2");
        //        HeaderCell.BorderColor = System.Drawing.ColorTranslator.FromHtml("#999999");
        //        HeaderCell.Width = 94;
        //        if (Colspans == 1)
        //        {
        //            HeaderCell.Visible = false;
        //        }
        //        HeaderGridRow1.Cells.Add(HeaderCell);

        //        HeaderCell = new TableCell();
        //        HeaderCell.Text = "Q3";
        //        HeaderCell.Style.Add("text-align", "center");
        //        HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#DDDFE4");
        //        HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#575759");
        //        HeaderCell.Attributes.Add("Class", "fontsizecolor2");
        //        HeaderCell.BorderColor = System.Drawing.ColorTranslator.FromHtml("#999999");
        //        if (Colspans == 1)
        //        {
        //            HeaderCell.Visible = false;
        //        }
        //        HeaderCell.Width = 94;

        //        HeaderGridRow1.Cells.Add(HeaderCell);

        //        HeaderCell = new TableCell();
        //        HeaderCell.Text = "Q2";
        //        HeaderCell.Style.Add("text-align", "center");
        //        HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#DDDFE4");
        //        HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#575759");
        //        HeaderCell.Attributes.Add("Class", "fontsizecolor2");
        //        HeaderCell.BorderColor = System.Drawing.ColorTranslator.FromHtml("#999999");
        //        HeaderCell.Width = 94;
        //        if (Colspans == 1)
        //        {
        //            HeaderCell.Visible = false;
        //        }
        //        else if (Colspans == 3)
        //        {
        //            HeaderCell.Visible = false;
        //        }
        //        HeaderGridRow1.Cells.Add(HeaderCell);



        //        HeaderCell = new TableCell();
        //        HeaderCell.Text = CurrentMonth;
        //        HeaderCell.Style.Add("text-align", "center");
        //        HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#DDDFE4");
        //        HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#575759");
        //        HeaderCell.Attributes.Add("Class", "fontsizecolor2");
        //        HeaderCell.BorderColor = System.Drawing.ColorTranslator.FromHtml("#999999");
        //        HeaderGridRow1.Cells.Add(HeaderCell);

        //        HeaderCell = new TableCell();
        //        HeaderCell.Text = GetMonthYear();
        //        HeaderCell.Style.Add("text-align", "center");
        //        HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#DDDFE4");
        //        HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#575759");
        //        HeaderCell.Attributes.Add("Class", "fontsizecolor2");
        //        HeaderCell.BorderColor = System.Drawing.ColorTranslator.FromHtml("#999999");
        //        HeaderCell.Width = 94;
        //        HeaderGridRow1.Cells.Add(HeaderCell);

        //        HeaderCell = new TableCell();
        //        HeaderCell.Text = "Q2";
        //        HeaderCell.Style.Add("text-align", "center");
        //        HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#DDDFE4");
        //        HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#575759");
        //        HeaderCell.Attributes.Add("Class", "fontsizecolor2");
        //        HeaderCell.BorderColor = System.Drawing.ColorTranslator.FromHtml("#999999");
        //        HeaderCell.Width = 94;
        //        if (Colspans == 1)
        //        {
        //            HeaderCell.Visible = false;
        //        }
        //        HeaderGridRow1.Cells.Add(HeaderCell);

        //        HeaderCell = new TableCell();
        //        HeaderCell.Text = "Q3";
        //        HeaderCell.Style.Add("text-align", "center");
        //        HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#DDDFE4");
        //        HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#575759");
        //        HeaderCell.Attributes.Add("Class", "fontsizecolor2");
        //        HeaderCell.BorderColor = System.Drawing.ColorTranslator.FromHtml("#999999");
        //        HeaderCell.Width = 94;
        //        if (Colspans == 2)
        //        {
        //            HeaderCell.Visible = false;
        //        }
        //        else if (Colspans == 1)
        //        {
        //            HeaderCell.Visible = false;
        //        }
        //        HeaderGridRow1.Cells.Add(HeaderCell);

        //        HeaderCell = new TableCell();
        //        HeaderCell.Text = "Q2";
        //        HeaderCell.Style.Add("text-align", "center");
        //        HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#DDDFE4");
        //        HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#575759");
        //        HeaderCell.Attributes.Add("Class", "fontsizecolor2");
        //        HeaderCell.BorderColor = System.Drawing.ColorTranslator.FromHtml("#999999");
        //        HeaderCell.Width = 94;
        //        if (Colspans == 2)
        //        {
        //            HeaderCell.Visible = false;
        //        }
        //        else if (Colspans == 1)
        //        {
        //            HeaderCell.Visible = false;
        //        }
        //        else if (Colspans == 3)
        //        {
        //            HeaderCell.Visible = false;
        //        }
        //        HeaderGridRow1.Cells.Add(HeaderCell);

        //        HeaderCell = new TableCell();
        //        HeaderCell.Text = CurrentMonth;
        //        HeaderCell.Style.Add("text-align", "center");
        //        HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#DDDFE4");
        //        HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#575759");
        //        HeaderCell.Attributes.Add("Class", "fontsizecolor2");
        //        HeaderCell.BorderColor = System.Drawing.ColorTranslator.FromHtml("#999999");
        //        HeaderGridRow1.Cells.Add(HeaderCell);

        //        grdfabavgwithoutstitch.Controls[0].Controls.AddAt(1, HeaderGridRow1);

        //    }

        //}

        protected void grdva_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {


                GridView HeaderGrid = (GridView)sender;
                GridViewRow HeaderGridRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);

                TableCell HeaderCell = new TableCell();
                HeaderCell.Text = "Outhouse ";
                HeaderCell.ColumnSpan = 5;
                HeaderCell.Style.Add("text-align", "center");
                HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#DDDFE4");
                HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#575759");
                HeaderCell.Attributes.Add("Class", "fontsizecolor3");
                HeaderCell.BorderColor = System.Drawing.ColorTranslator.FromHtml("#999999");
                HeaderGridRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "VA";
                HeaderCell.ColumnSpan = 5;
                HeaderCell.Style.Add("text-align", "center");
                HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#DDDFE4");
                HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#575759");
                HeaderCell.Attributes.Add("Class", "fontsizecolor3");
                HeaderCell.BorderColor = System.Drawing.ColorTranslator.FromHtml("#999999");
                HeaderGridRow.Cells.Add(HeaderCell);


                GridViewRow HeaderGridRow1 = new GridViewRow(1, 0, DataControlRowType.Header, DataControlRowState.Insert);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Total";
                HeaderCell.Style.Add("text-align", "center");
                HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#DDDFE4");
                HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#575759");
                HeaderCell.Attributes.Add("Class", "fontsizecolor3");
                HeaderCell.BorderColor = System.Drawing.ColorTranslator.FromHtml("#999999");
                HeaderCell.RowSpan = 2;
                HeaderGridRow1.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Costed";
                HeaderCell.Style.Add("text-align", "center");
                HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#DDDFE4");
                HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#575759");
                HeaderCell.Attributes.Add("Class", "fontsizecolor3");
                HeaderCell.BorderColor = System.Drawing.ColorTranslator.FromHtml("#999999");
                HeaderCell.RowSpan = 2;
                HeaderGridRow1.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Pending ";
                HeaderCell.Style.Add("text-align", "center");
                HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#DDDFE4");
                HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#575759");
                HeaderCell.Attributes.Add("Class", "fontsizecolor3");
                HeaderCell.BorderColor = System.Drawing.ColorTranslator.FromHtml("#999999");
                HeaderCell.ColumnSpan = 3;

                HeaderGridRow1.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Total";
                HeaderCell.Style.Add("text-align", "center");
                HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#DDDFE4");
                HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#575759");
                HeaderCell.RowSpan = 2;
                HeaderCell.Attributes.Add("Class", "fontsizecolor3");
                HeaderCell.BorderColor = System.Drawing.ColorTranslator.FromHtml("#999999");
                HeaderGridRow1.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Costed";
                HeaderCell.Style.Add("text-align", "center");
                HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#DDDFE4");
                HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#575759");
                HeaderCell.Attributes.Add("Class", "fontsizecolor3");
                HeaderCell.BorderColor = System.Drawing.ColorTranslator.FromHtml("#999999");
                HeaderCell.RowSpan = 2;
                HeaderGridRow1.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Pending ";
                HeaderCell.Style.Add("text-align", "center");
                HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#DDDFE4");
                HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#575759");
                HeaderCell.Attributes.Add("Class", "fontsizecolor3");
                HeaderCell.BorderColor = System.Drawing.ColorTranslator.FromHtml("#999999");
                HeaderCell.ColumnSpan = 3;
                HeaderGridRow1.Cells.Add(HeaderCell);

                GridViewRow HeaderGridRow2 = new GridViewRow(1, 0, DataControlRowType.Header, DataControlRowState.Insert);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Total";
                HeaderCell.Style.Add("text-align", "center");
                HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#DDDFE4");
                HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#575759");
                HeaderCell.Attributes.Add("Class", "fontsizecolor3");
                HeaderCell.BorderColor = System.Drawing.ColorTranslator.FromHtml("#999999");
                HeaderGridRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Ex within 45 days";
                HeaderCell.Style.Add("text-align", "center");
                HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#DDDFE4");
                HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#575759");
                HeaderCell.Attributes.Add("Class", "fontsizecolor3");
                HeaderCell.BorderColor = System.Drawing.ColorTranslator.FromHtml("#999999");
                HeaderGridRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Ex beyond 45 days";
                HeaderCell.Style.Add("text-align", "center");
                HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#DDDFE4");
                HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#575759");
                HeaderCell.Attributes.Add("Class", "fontsizecolor3");
                HeaderCell.BorderColor = System.Drawing.ColorTranslator.FromHtml("#999999");
                HeaderGridRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Total";
                HeaderCell.Style.Add("text-align", "center");
                HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#DDDFE4");
                HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#575759");
                HeaderCell.Attributes.Add("Class", "fontsizecolor3");
                HeaderCell.BorderColor = System.Drawing.ColorTranslator.FromHtml("#999999");
                HeaderGridRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Ex within 45 days";
                HeaderCell.Style.Add("text-align", "center");
                HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#DDDFE4");
                HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#575759");
                HeaderCell.Attributes.Add("Class", "fontsizecolor3");
                HeaderCell.BorderColor = System.Drawing.ColorTranslator.FromHtml("#999999");
                HeaderGridRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Ex beyond 45 days";
                HeaderCell.Style.Add("text-align", "center");
                HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#DDDFE4");
                HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#575759");
                HeaderCell.Attributes.Add("Class", "fontsizecolor3");
                HeaderCell.BorderColor = System.Drawing.ColorTranslator.FromHtml("#999999");
                HeaderGridRow2.Cells.Add(HeaderCell);

                grdva.Controls[0].Controls.AddAt(1, HeaderGridRow2);
                grdva.Controls[0].Controls.AddAt(1, HeaderGridRow1);
                grdva.Controls[0].Controls.AddAt(0, HeaderGridRow);

            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblAvrage_Machine_45Days = (Label)e.Row.FindControl("lblAvrage_Machine_45Days");
                if (!string.IsNullOrEmpty(lblAvrage_Machine_45Days.Text) && lblAvrage_Machine_45Days.Text != "0")
                {
                    // lblAvrage_Machine_45Days.Attributes.Add("style", "Background-color:red");
                    e.Row.Cells[3].Attributes.Add("style", "Background-color:red;color:yellow;");
                    lblAvrage_Machine_45Days.ForeColor = System.Drawing.Color.Yellow;

                }
                Label lblAvrage_Psc_PerDayOutPut_45Days = (Label)e.Row.FindControl("lblAvrage_Psc_PerDayOutPut_45Days");
                if (!string.IsNullOrEmpty(lblAvrage_Psc_PerDayOutPut_45Days.Text) && lblAvrage_Psc_PerDayOutPut_45Days.Text != "0")
                {
                    e.Row.Cells[8].Attributes.Add("style", "Background-color:red");
                    lblAvrage_Psc_PerDayOutPut_45Days.ForeColor = System.Drawing.Color.Yellow;

                }

            }
        }
        ////protected void grdnew_RowDataBound(object sender, GridViewRowEventArgs e)
        ////{
        ////  if (e.Row.RowType == DataControlRowType.Header)
        ////  {
        ////    string previousMonth = DateTime.Now.AddMonths(-1).ToString("MMM");
        ////    string CurrentMonth = DateTime.Now.AddMonths(0).ToString("MMM");

        ////    GridView HeaderGrid = (GridView)sender;
        ////    GridViewRow HeaderGridRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);

        ////    TableCell HeaderCell = new TableCell();
        ////    HeaderCell.Text = "Fabricator";
        ////    HeaderCell.RowSpan = 2;
        ////    HeaderCell.Style.Add("text-align", "center");
        ////    HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#dddfe4");
        ////    HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#575759");
        ////    HeaderGridRow.Cells.Add(HeaderCell);

        ////    HeaderCell = new TableCell();
        ////    HeaderCell.Text = "Total Machines";
        ////    HeaderCell.RowSpan = 2;
        ////    HeaderCell.Style.Add("text-align", "center");
        ////    HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#dddfe4");
        ////    HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#575759");
        ////    HeaderGridRow.Cells.Add(HeaderCell);


        ////    //HeaderCell = new TableCell();
        ////    //HeaderCell.Text = "Machines in Use";
        ////    //HeaderCell.ColumnSpan = 2;
        ////    //HeaderCell.Style.Add("text-align", "center");
        ////    //HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#39589c");
        ////    //HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#575759");
        ////    //HeaderGridRow.Cells.Add(HeaderCell);

        ////    HeaderCell = new TableCell();
        ////    HeaderCell.Text = "Styles Costed";
        ////    HeaderCell.ColumnSpan = 2;
        ////    HeaderCell.Style.Add("text-align", "center");
        ////    HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#dddfe4");
        ////    HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#575759");
        ////    HeaderGridRow.Cells.Add(HeaderCell);


        ////    //HeaderCell = new TableCell();
        ////    //HeaderCell.Text = "Monthly pcs stitch";
        ////    //HeaderCell.ColumnSpan = 2;
        ////    //HeaderCell.Style.Add("text-align", "center");
        ////    //HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#39589c");
        ////    //HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#575759");
        ////    //HeaderGridRow.Cells.Add(HeaderCell);



        ////    HeaderCell = new TableCell();
        ////    HeaderCell.Text = "Initial Multiplier";
        ////    HeaderCell.ColumnSpan = 2;
        ////    HeaderCell.Style.Add("text-align", "center");
        ////    HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#dddfe4");
        ////    HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#575759");
        ////    HeaderGridRow.Cells.Add(HeaderCell);


        ////    HeaderCell = new TableCell();
        ////    HeaderCell.Text = "Production Multiplier";
        ////    HeaderCell.ColumnSpan = 2;
        ////    HeaderCell.Style.Add("text-align", "center");
        ////    HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#dddfe4");
        ////    HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#575759");
        ////    HeaderGridRow.Cells.Add(HeaderCell);


        ////    //HeaderCell = new TableCell();
        ////    //HeaderCell.Text = "Avg. Delay in days";
        ////    //HeaderCell.ColumnSpan = 2;
        ////    //HeaderCell.Style.Add("text-align", "center");
        ////    //HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#39589c");
        ////    //HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#575759");
        ////    //HeaderGridRow.Cells.Add(HeaderCell);



        ////    grdnew.Controls[0].Controls.AddAt(0, HeaderGridRow);

        ////    GridViewRow HeaderGridRow1 = new GridViewRow(1, 0, DataControlRowType.Header, DataControlRowState.Insert);

        ////    //HeaderCell = new TableCell();
        ////    //HeaderCell.Text = previousMonth;
        ////    //HeaderCell.Style.Add("text-align", "center");
        ////    //HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#39589c");
        ////    //HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#575759");
        ////    //HeaderGridRow1.Cells.Add(HeaderCell);

        ////    //HeaderCell = new TableCell();
        ////    //HeaderCell.Text = CurrentMonth;
        ////    //HeaderCell.Style.Add("text-align", "center");
        ////    //HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#39589c");
        ////    //HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#575759");
        ////    //HeaderGridRow1.Cells.Add(HeaderCell);

        ////    HeaderCell = new TableCell();
        ////    HeaderCell.Text = "Last 3 Months";
        ////    HeaderCell.Style.Add("text-align", "center");
        ////    HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#dddfe4");
        ////    HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#575759");
        ////    HeaderGridRow1.Cells.Add(HeaderCell);

        ////    HeaderCell = new TableCell();
        ////    HeaderCell.Text = CurrentMonth;
        ////    HeaderCell.Style.Add("text-align", "center");
        ////    HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#dddfe4");
        ////    HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#575759");
        ////    HeaderGridRow1.Cells.Add(HeaderCell);

        ////    HeaderCell = new TableCell();
        ////    HeaderCell.Text = "Last 3 Months";
        ////    HeaderCell.Style.Add("text-align", "center");
        ////    HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#dddfe4");
        ////    HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#575759");
        ////    HeaderGridRow1.Cells.Add(HeaderCell);

        ////    HeaderCell = new TableCell();
        ////    HeaderCell.Text = CurrentMonth;
        ////    HeaderCell.Style.Add("text-align", "center");
        ////    HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#dddfe4");
        ////    HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#575759");
        ////    HeaderGridRow1.Cells.Add(HeaderCell);

        ////    HeaderCell = new TableCell();
        ////    HeaderCell.Text = "Last 3 Months";
        ////    HeaderCell.Style.Add("text-align", "center");
        ////    HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#dddfe4");
        ////    HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#575759");
        ////    HeaderGridRow1.Cells.Add(HeaderCell);

        ////    HeaderCell = new TableCell();
        ////    HeaderCell.Text = CurrentMonth;
        ////    HeaderCell.Style.Add("text-align", "center");
        ////    HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#dddfe4");
        ////    HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#575759");
        ////    HeaderGridRow1.Cells.Add(HeaderCell);

        ////    //HeaderCell = new TableCell();
        ////    //HeaderCell.Text = "Last Three Monthes";
        ////    //HeaderCell.Style.Add("text-align", "center");
        ////    //HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#39589c");
        ////    //HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#575759");
        ////    //HeaderGridRow1.Cells.Add(HeaderCell);

        ////    //HeaderCell = new TableCell();
        ////    //HeaderCell.Text = CurrentMonth;
        ////    //HeaderCell.Style.Add("text-align", "center");
        ////    //HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#39589c");
        ////    //HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#575759");
        ////    //HeaderGridRow1.Cells.Add(HeaderCell);


        ////    //HeaderCell = new TableCell();
        ////    //HeaderCell.Text = "Last Three Monthes";
        ////    //HeaderCell.Style.Add("text-align", "center");
        ////    //HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#39589c");
        ////    //HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#575759");
        ////    //HeaderGridRow1.Cells.Add(HeaderCell);

        ////    //HeaderCell = new TableCell();
        ////    //HeaderCell.Text = CurrentMonth;
        ////    //HeaderCell.Style.Add("text-align", "center");
        ////    //HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#39589c");
        ////    //HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#575759");
        ////    //HeaderGridRow1.Cells.Add(HeaderCell);

        ////    grdnew.Controls[0].Controls.AddAt(1, HeaderGridRow1);

        ////    //e.Row.Cells[6].he.Visible = false;
        ////    //e.Row.Cells[7].Visible = false;
        ////    //e.Row.Cells[12].Visible = false;
        ////    grdnew.Columns[8].Visible = false;
        ////    grdnew.Columns[2].Visible = false;
        ////    grdnew.Columns[6].Visible = false;
        ////    grdnew.Columns[7].Visible = false;
        ////    grdnew.Columns[12].Visible = false;
        ////    grdnew.Columns[13].Visible = false;


        ////  }


        ////  if (e.Row.RowType == DataControlRowType.DataRow)
        ////  {
        ////    Label lblTotal_Machines = (Label)e.Row.FindControl("lblTotal_Machines");
        ////    Label lblAvrage_Machine = (Label)e.Row.FindControl("lblAvrage_Machine");
        ////    Label lblAvrage_Psc_PerDayOutPut = (Label)e.Row.FindControl("lblAvrage_Psc_PerDayOutPut");
        ////    Label lblIntialMultiplier = (Label)e.Row.FindControl("lblIntialMultiplier");
        ////    Label lblProductionMultiplier = (Label)e.Row.FindControl("lblProductionMultiplier");
        ////    Label lblAvgDelay = (Label)e.Row.FindControl("lblAvgDelay");
        ////    Label lblFabricatorName = (Label)e.Row.FindControl("lblFabricatorName");

        ////    Label lblStyleCosted = (Label)e.Row.FindControl("lblStyleCosted");
        ////    Label lblStyleCosted_CurrentMonth = (Label)e.Row.FindControl("lblStyleCosted_CurrentMonth");
        ////    Label lblAvrage_Machine_CurrentMonth = (Label)e.Row.FindControl("lblAvrage_Machine_CurrentMonth");
        ////    Label lblIntialMultiplier_CurrentMonth = (Label)e.Row.FindControl("lblIntialMultiplier_CurrentMonth");
        ////    Label lblProductionMultiplier_CurrentMonth = (Label)e.Row.FindControl("lblProductionMultiplier_CurrentMonth");
        ////    Label lblAvgDelay_CurrentMonth = (Label)e.Row.FindControl("lblAvgDelay_CurrentMonth");
        ////    Label lblAvrage_Psc_PerDayOutPut_CurrentMonth = (Label)e.Row.FindControl("lblAvrage_Psc_PerDayOutPut_CurrentMonth");


        ////    if (lblTotal_Machines.Text.Trim() == "0")
        ////    {
        ////      lblTotal_Machines.Text = "";
        ////    }
        ////    if (lblAvrage_Machine.Text.Trim() == "0")
        ////    {
        ////      lblAvrage_Machine.Text = "";
        ////    }
        ////    if (lblAvrage_Psc_PerDayOutPut.Text.Trim() == "0")
        ////    {
        ////      lblAvrage_Psc_PerDayOutPut.Text = "";
        ////    }
        ////    if (lblIntialMultiplier.Text.Trim() == "0")
        ////    {
        ////      lblIntialMultiplier.Text = "";
        ////    }
        ////    if (lblProductionMultiplier.Text.Trim() == "0")
        ////    {
        ////      lblProductionMultiplier.Text = "";
        ////    }
        ////    if (lblAvgDelay.Text.Trim() == "0")
        ////    {
        ////      lblAvgDelay.Text = "";
        ////    }



        ////    if (lblStyleCosted.Text.Trim() == "0")
        ////    {
        ////      lblStyleCosted.Text = "";
        ////    }
        ////    if (lblStyleCosted_CurrentMonth.Text.Trim() == "0")
        ////    {
        ////      lblStyleCosted_CurrentMonth.Text = "";
        ////    }
        ////    if (lblAvrage_Machine_CurrentMonth.Text.Trim() == "0")
        ////    {
        ////      lblAvrage_Machine_CurrentMonth.Text = "";
        ////    }
        ////    if (lblIntialMultiplier_CurrentMonth.Text.Trim() == "0")
        ////    {
        ////      lblIntialMultiplier_CurrentMonth.Text = "";
        ////    }
        ////    if (lblProductionMultiplier_CurrentMonth.Text.Trim() == "0")
        ////    {
        ////      lblProductionMultiplier_CurrentMonth.Text = "";
        ////    }
        ////    if (lblAvgDelay_CurrentMonth.Text.Trim() == "0")
        ////    {
        ////      lblAvgDelay_CurrentMonth.Text = "";
        ////    }

        ////    if (lblAvrage_Psc_PerDayOutPut_CurrentMonth.Text.Trim() == "0")
        ////    {
        ////      lblAvrage_Psc_PerDayOutPut_CurrentMonth.Text = "";
        ////    }




        ////    if (lblFabricatorName.Text == "Total")
        ////    {
        ////      lblFabricatorName.Font.Bold = true;
        ////      lblTotal_Machines.Font.Bold = true;
        ////      lblAvrage_Machine.Font.Bold = true;
        ////      lblAvrage_Psc_PerDayOutPut.Font.Bold = true;
        ////      lblIntialMultiplier.Font.Bold = true;
        ////      lblProductionMultiplier.Font.Bold = true;
        ////      lblAvgDelay.Font.Bold = true;

        ////      lblStyleCosted.Font.Bold = true;
        ////      lblStyleCosted_CurrentMonth.Font.Bold = true;
        ////      lblAvrage_Machine_CurrentMonth.Font.Bold = true;
        ////      lblIntialMultiplier_CurrentMonth.Font.Bold = true;
        ////      lblProductionMultiplier_CurrentMonth.Font.Bold = true;
        ////      lblAvgDelay_CurrentMonth.Font.Bold = true;
        ////      lblAvrage_Psc_PerDayOutPut_CurrentMonth.Font.Bold = true;

        ////    }
        ////    if (lblAvrage_Psc_PerDayOutPut.Text != "")
        ////      lblAvrage_Psc_PerDayOutPut.Text = Get_WithDecimal(lblAvrage_Psc_PerDayOutPut.Text.ToString());
        ////    if (lblAvrage_Psc_PerDayOutPut_CurrentMonth.Text != "")
        ////      lblAvrage_Psc_PerDayOutPut_CurrentMonth.Text = Get_WithDecimal(lblAvrage_Psc_PerDayOutPut_CurrentMonth.Text.ToString());


        ////  }
        ////}
        public string Get_WithDecimal(string value, int round = 0)
        {
            string result = "";
            //bool val = false;
            decimal DivideByThousand = 1000M;
            value = value.Replace("k", "");
            if (Convert.ToDecimal(value) > DivideByThousand)
            {
                //val = true;
                result = Math.Round(Convert.ToDouble(((Convert.ToDouble(value)) / Convert.ToDouble(DivideByThousand))), round, MidpointRounding.AwayFromZero).ToString() + " k";
            }
            else
            {
                result = value;
                //val = false;
            }
            return result;
        }
        public double GetVal(string val, int iCount)
        {
            if (string.IsNullOrEmpty(val))
            {
                val = "0";
            }
            double rest = 0;
            if (iCount == 0)
                rest = 0;
            else
                rest = Math.Round(Convert.ToDouble(val) / iCount, 1, MidpointRounding.AwayFromZero);
            return rest;
        }
        public int GetVal_NoDecimal(string val, int iCount)
        {
            if (string.IsNullOrEmpty(val))
            {
                val = "0";
            }
            int rest = 0;
            if (iCount == 0)
                rest = 0;
            else
                rest = Convert.ToInt32(Math.Round(Convert.ToDouble(val) / iCount, 0, MidpointRounding.AwayFromZero));
            return rest;
        }
        public void bindgrd()
        {
            //Add By Prabhaker

            string ComplienceAuditReport_Out_House_ReportHtml = "";
            DateTime now = DateTime.Now;
            string Day = now.ToString("dd");
            string Month = now.ToString("MMM");

            ComplienceAuditReport_Out_House_ReportHtml = "ComplienceAuditReport_Out_House_" + Day + "_" + Month + ".html";
            QAComplienceMailOut_House.NavigateUrl = "http://boutique.in/Uploads/Audit_Report/" + ComplienceAuditReport_Out_House_ReportHtml;

            //End Of Code




            DataSet dsOuthouseSummary = new DataSet();
            dsOuthouseSummary = objadmin.GetOuthouseSummary();
            dtOutHouseReport = dsOuthouseSummary.Tables[0];
            if (dtOutHouseReport.Rows.Count > 0)
            {

                int iCount_FirstQuarter_Rate = Convert.ToInt32(dsOuthouseSummary.Tables[1].Rows[0]["FirstQuarter_Rate"]);
                int iCount_CurrentMonth_Rate = Convert.ToInt32(dsOuthouseSummary.Tables[2].Rows[0]["CurrentMonth_Rate"]);
                int iCount_CurrentMonth_Production = Convert.ToInt32(dsOuthouseSummary.Tables[3].Rows[0]["CurrentMonth_Production"]);
                int iCount_FirstQuarter_Production = Convert.ToInt32(dsOuthouseSummary.Tables[4].Rows[0]["FirstQuarter_Production"]);
                int iCount_FirstQuarter_AvgDelay = Convert.ToInt32(dsOuthouseSummary.Tables[5].Rows[0]["FirstQuarter_AvgDelay"]);
                int iCount_CurrentMonth_AvgDelay = Convert.ToInt32(dsOuthouseSummary.Tables[6].Rows[0]["CurrentMonth_AvgDelay"]);
                int iFirstQuarter_Avg_Pcs_PerDayOutPut = Convert.ToInt32(dsOuthouseSummary.Tables[7].Rows[0]["FirstQuarter_Avg_Pcs_PerDayOutPut"]);


                DataRow row = dtOutHouseReport.NewRow();
                row["FabricatoryName"] = "Total";
                row["Total_Machines"] = dtOutHouseReport.Compute("Sum(Total_Machines)", "Total_Machines > 0");
                row["FirstQuarter_Average_Machine"] = dtOutHouseReport.Compute("Sum(FirstQuarter_Average_Machine)", "");
                row["SecondQuarter_Average_Machine"] = dtOutHouseReport.Compute("Sum(SecondQuarter_Average_Machine)", "SecondQuarter_Average_Machine > 0");
                row["ThirdQuarter_Average_Machine"] = dtOutHouseReport.Compute("Sum(ThirdQuarter_Average_Machine)", "ThirdQuarter_Average_Machine > 0");
                row["FourthQuarter_Average_Machine"] = dtOutHouseReport.Compute("Sum(FourthQuarter_Average_Machine)", "FourthQuarter_Average_Machine > 0");
                row["FirstQuarter_Average_Pcs_PerDayOutPut"] = GetVal(dtOutHouseReport.Compute("Sum(FirstQuarter_Average_Pcs_PerDayOutPut)", "FirstQuarter_Average_Pcs_PerDayOutPut > 0").ToString(), iFirstQuarter_Avg_Pcs_PerDayOutPut);
                row["SecondQuarter_Average_Pcs_PerDayOutPut"] = dtOutHouseReport.Compute("Sum(SecondQuarter_Average_Pcs_PerDayOutPut)", "SecondQuarter_Average_Pcs_PerDayOutPut > 0");
                row["ThirdQuarter_Average_Pcs_PerDayOutPut"] = dtOutHouseReport.Compute("Sum(ThirdQuarter_Average_Pcs_PerDayOutPut)", "ThirdQuarter_Average_Pcs_PerDayOutPut > 0");
                row["FourthQuarter_Average_Pcs_PerDayOutPut"] = dtOutHouseReport.Compute("Sum(FourthQuarter_Average_Pcs_PerDayOutPut)", "FourthQuarter_Average_Pcs_PerDayOutPut > 0");
                row["FirstQuarter_Rate"] = GetVal(dtOutHouseReport.Compute("Sum(FirstQuarter_Rate)", "FirstQuarter_Rate > 0").ToString(), iCount_FirstQuarter_Rate);
                row["SecondQuarter_Rate"] = GetVal(dtOutHouseReport.Compute("Sum(SecondQuarter_Rate)", "SecondQuarter_Rate > 0").ToString(), iCount_FirstQuarter_Rate);
                row["ThirdQuarter_Rate"] = GetVal(dtOutHouseReport.Compute("Sum(ThirdQuarter_Rate)", "ThirdQuarter_Rate > 0").ToString(), iCount_FirstQuarter_Rate);
                row["FourthQuarter_Rate"] = GetVal(dtOutHouseReport.Compute("Sum(FourthQuarter_Rate)", "FourthQuarter_Rate > 0").ToString(), iCount_FirstQuarter_Rate);
                row["FirstQuarter_Production"] = GetVal(dtOutHouseReport.Compute("Sum(FirstQuarter_Production)", "FirstQuarter_Production > 0").ToString(), iCount_FirstQuarter_Production);
                row["SecondQuarter_Production"] = GetVal(dtOutHouseReport.Compute("Sum(SecondQuarter_Production)", "SecondQuarter_Production > 0").ToString(), iCount_FirstQuarter_Production);
                row["ThirdQuarter_Production"] = GetVal(dtOutHouseReport.Compute("Sum(ThirdQuarter_Production)", "ThirdQuarter_Production > 0").ToString(), iCount_FirstQuarter_Production);
                row["FourthQuarter_Production"] = GetVal(dtOutHouseReport.Compute("Sum(FourthQuarter_Production)", "FourthQuarter_Production > 0").ToString(), iCount_FirstQuarter_Production);
                row["FirstQuarter_AvgDelay"] = GetVal_NoDecimal(dtOutHouseReport.Compute("Sum(FirstQuarter_AvgDelay)", "FirstQuarter_AvgDelay > 0").ToString(), iCount_FirstQuarter_AvgDelay);
                row["SecondQuarter_AvgDelay"] = dtOutHouseReport.Compute("Sum(SecondQuarter_AvgDelay)", "SecondQuarter_AvgDelay > 0");
                row["ThirdQuarter_AvgDelay"] = dtOutHouseReport.Compute("Sum(ThirdQuarter_AvgDelay)", "ThirdQuarter_AvgDelay > 0");
                row["FourthQuarter_AvgDelay"] = dtOutHouseReport.Compute("Sum(FourthQuarter_AvgDelay)", "FourthQuarter_AvgDelay > 0");
                row["FirstQuarter_StyleCosted"] = dtOutHouseReport.Compute("Sum(FirstQuarter_StyleCosted)", "FirstQuarter_StyleCosted > 0");
                row["SecondQuarter_StyleCosted"] = dtOutHouseReport.Compute("Sum(SecondQuarter_StyleCosted)", "SecondQuarter_StyleCosted > 0");
                row["ThirdQuarter_StyleCosted"] = dtOutHouseReport.Compute("Sum(ThirdQuarter_StyleCosted)", "ThirdQuarter_StyleCosted > 0");
                row["FourthQuarter_StyleCosted"] = dtOutHouseReport.Compute("Sum(FourthQuarter_StyleCosted)", "FourthQuarter_StyleCosted > 0");
                row["CurrentMonth_Average_Machine"] = dtOutHouseReport.Compute("Sum(CurrentMonth_Average_Machine)", "CurrentMonth_Average_Machine > 0");
                row["CurrentMonth_Average_Pcs_PerDayOutPut"] = dtOutHouseReport.Compute("Sum(CurrentMonth_Average_Pcs_PerDayOutPut)", "CurrentMonth_Average_Pcs_PerDayOutPut > 0");
                row["CurrentMonth_Rate"] = GetVal(dtOutHouseReport.Compute("Sum(CurrentMonth_Rate)", "CurrentMonth_Rate > 0").ToString(), iCount_CurrentMonth_Rate);
                row["CurrentMonth_AvgDelay"] = GetVal_NoDecimal(dtOutHouseReport.Compute("Sum(CurrentMonth_AvgDelay)", "CurrentMonth_AvgDelay > 0").ToString(), iCount_CurrentMonth_AvgDelay);
                row["CurrentMonth_StyleCosted"] = dtOutHouseReport.Compute("Sum(CurrentMonth_StyleCosted)", "CurrentMonth_StyleCosted > 0");
                row["CurrentMonth_Production"] = GetVal(dtOutHouseReport.Compute("Sum(CurrentMonth_Production)", "CurrentMonth_Production > 0").ToString(), iCount_CurrentMonth_Production);

                row["IsFirstQuarter"] = 0;
                row["IsSecondQuarter"] = 0;
                row["IsThirdQuarter"] = 0;
                row["IsFourthQuarter"] = 0;
                dtOutHouseReport.Rows.Add(row);
                dtOutHouseReport.AcceptChanges();
                DataTable dt = new DataTable();
                dt = dtOutHouseReport.Copy();

                grdOuthouseSummary.DataSource = dt;
                grdOuthouseSummary.DataBind();

                HideColumn();
                GridViewRow rows = grdOuthouseSummary.Rows[grdOuthouseSummary.Rows.Count - 1];
                rows.Font.Bold = true;
            }
            DataTable dtOutHouseReportVa = dsOuthouseSummary.Tables[8];
            if (dtOutHouseReportVa.Rows.Count > 0)
            {
                grdva.DataSource = dtOutHouseReportVa;
                grdva.DataBind();
            }

            //DataSet dsAvgWithoutStitch = new DataSet();
            //dsAvgWithoutStitch = objadmin.GetOuthouseSummaryReportwithout();
            //dtAvgWithoutStitch = dsAvgWithoutStitch.Tables[0];


            //if (dtAvgWithoutStitch.Rows.Count > 0)
            //{
            //    int iCount = dtAvgWithoutStitch.Rows.Count;
            //    int iCount_FirstQuarter_Rate = Convert.ToInt32(dsAvgWithoutStitch.Tables[1].Rows[0]["FirstQuarter_Rate"]);
            //    int iCount_CurrentMonth_Rate = Convert.ToInt32(dsAvgWithoutStitch.Tables[2].Rows[0]["CurrentMonth_Rate"]);
            //    int iCount_CurrentMonth_Production = Convert.ToInt32(dsAvgWithoutStitch.Tables[3].Rows[0]["CurrentMonth_Production"]);
            //    int iCount_FirstQuarter_Production = Convert.ToInt32(dsAvgWithoutStitch.Tables[4].Rows[0]["FirstQuarter_Production"]);


            //    DataRow rows = dtAvgWithoutStitch.NewRow();
            //    rows["Fabricator_Name"] = "Total";
            //    rows["Total_Machines"] = dtAvgWithoutStitch.Compute("Sum(Total_Machines)", "Total_Machines > 0");


            //    rows["FirstQuarter_Rate"] = GetVal(dtAvgWithoutStitch.Compute("Sum(FirstQuarter_Rate)", "FirstQuarter_Rate > 0").ToString(), iCount_FirstQuarter_Rate);
            //    rows["SecondQuarter_Rate"] = GetVal(dtAvgWithoutStitch.Compute("Sum(SecondQuarter_Rate)", "SecondQuarter_Rate > 0").ToString(), iCount_FirstQuarter_Rate);
            //    rows["ThirdQuarter_Rate"] = GetVal(dtAvgWithoutStitch.Compute("Sum(ThirdQuarter_Rate)", "ThirdQuarter_Rate > 0").ToString(), iCount_FirstQuarter_Rate);
            //    rows["FourthQuarter_Rate"] = GetVal(dtAvgWithoutStitch.Compute("Sum(FourthQuarter_Rate)", "FourthQuarter_Rate > 0").ToString(), iCount_FirstQuarter_Rate);

            //    rows["FirstQuarter_Production"] = GetVal(dtAvgWithoutStitch.Compute("Sum(FirstQuarter_Production)", "FirstQuarter_Production > 0").ToString(), iCount_FirstQuarter_Production);
            //    rows["SecondQuarter_Production"] = GetVal(dtAvgWithoutStitch.Compute("Sum(SecondQuarter_Production)", "SecondQuarter_Production > 0").ToString(), iCount_FirstQuarter_Production);
            //    rows["ThirdQuarter_Production"] = GetVal(dtAvgWithoutStitch.Compute("Sum(ThirdQuarter_Production)", "ThirdQuarter_Production > 0").ToString(), iCount_FirstQuarter_Production);
            //    rows["FourthQuarter_Production"] = GetVal(dtAvgWithoutStitch.Compute("Sum(FourthQuarter_Production)", "FourthQuarter_Production > 0").ToString(), iCount_FirstQuarter_Production);

            //    rows["FirstQuarter_StyleCosted"] = dtAvgWithoutStitch.Compute("Sum(FirstQuarter_StyleCosted)", "FirstQuarter_StyleCosted > 0");
            //    rows["SecondQuarter_StyleCosted"] = dtAvgWithoutStitch.Compute("Sum(SecondQuarter_StyleCosted)", "SecondQuarter_StyleCosted > 0");
            //    rows["ThirdQuarter_StyleCosted"] = dtAvgWithoutStitch.Compute("Sum(ThirdQuarter_StyleCosted)", "ThirdQuarter_StyleCosted > 0");
            //    rows["FourthQuarter_StyleCosted"] = dtAvgWithoutStitch.Compute("Sum(FourthQuarter_StyleCosted)", "FourthQuarter_StyleCosted > 0");


            //    rows["CurrentMonth_Rate"] = GetVal(dtAvgWithoutStitch.Compute("Sum(CurrentMonth_Rate)", "CurrentMonth_Rate > 0").ToString(), iCount_CurrentMonth_Rate);
            //    rows["CurrentMonth_StyleCosted"] = dtAvgWithoutStitch.Compute("Sum(CurrentMonth_StyleCosted)", "CurrentMonth_StyleCosted > 0");
            //    rows["CurrentMonth_Production"] = GetVal(dtAvgWithoutStitch.Compute("Sum(CurrentMonth_Production)", "CurrentMonth_Production > 0").ToString(), iCount_CurrentMonth_Production);

            //    rows["IsFirstQuarter"] = 0;
            //    rows["IsSecondQuarter"] = 0;
            //    rows["IsThirdQuarter"] = 0;
            //    rows["IsFourthQuarter"] = 0;
            //    dtAvgWithoutStitch.Rows.Add(rows);
            //    dtAvgWithoutStitch.AcceptChanges();

            //    //grdfabavgwithoutstitch.DataSource = dtAvgWithoutStitch;
            //    //grdfabavgwithoutstitch.DataBind();
            //    //HideColumnWithoutStitch();

            //    //GridViewRow rowsbottom = grdfabavgwithoutstitch.Rows[grdfabavgwithoutstitch.Rows.Count - 1];
            //    //rowsbottom.Font.Bold = true;

            //}
        }
        public void CreateExcel(DataSet ds)
        {
            try
            {
                //Directory.Delete(Constants.FITS_FOLDER_PATH);

                //string sourcePath = @"C:\";
              string sourcePath = @"E:\";
                string GlobalType = "Daily Outhouse Style and VA.xlsx";
                if ((System.IO.File.Exists(Constants.FITS_FOLDER_PATH + GlobalType)))
                {
                    System.IO.File.Delete(Constants.FITS_FOLDER_PATH + GlobalType);

                }
             
                //string targetPath = @"C:\Users\surendra\Documents\Live_Code\02_feb_2015_Sales_reports_cutting -Forcast- Released-6.0 - Copy\iKandi.Web\Uploads\Fits";
                string targetPath = Constants.FITS_FOLDER_PATH + GlobalType;
                string sourceFile = System.IO.Path.Combine(sourcePath, GlobalType);
                string destFile = System.IO.Path.Combine(targetPath, GlobalType);
                System.IO.File.Copy(sourceFile, targetPath, true);

                string GlobalType_OutHouseReallocation = "Reallocation_OutHouse.xlsx";
                if ((System.IO.File.Exists(Constants.FITS_FOLDER_PATH + GlobalType_OutHouseReallocation)))
                {
                    System.IO.File.Delete(Constants.FITS_FOLDER_PATH + GlobalType_OutHouseReallocation);

                }
                string GlobalType_Reallocation_OutHouse_Emb = "ValueAddition_OutHouse.xlsx";
                if ((System.IO.File.Exists(Constants.FITS_FOLDER_PATH + GlobalType_Reallocation_OutHouse_Emb)))
                {
                    System.IO.File.Delete(Constants.FITS_FOLDER_PATH + GlobalType_Reallocation_OutHouse_Emb);

                }

                //string targetPath = @"C:\Users\surendra\Documents\Live_Code\02_feb_2015_Sales_reports_cutting -Forcast- Released-6.0 - Copy\iKandi.Web\Uploads\Fits";
                string targetPath_OutHouseReallocation = Constants.FITS_FOLDER_PATH + GlobalType_OutHouseReallocation;
                string sourceFile_OutHouseReallocation = System.IO.Path.Combine(sourcePath, GlobalType_OutHouseReallocation);
                string destFile_OutHouseReallocation = System.IO.Path.Combine(targetPath_OutHouseReallocation, GlobalType_OutHouseReallocation);
                System.IO.File.Copy(sourceFile_OutHouseReallocation, targetPath_OutHouseReallocation, true);

                string targetPath_OutHouse_Emb = Constants.FITS_FOLDER_PATH + GlobalType_Reallocation_OutHouse_Emb;
                string sourceFile_OutHouse_Emb = System.IO.Path.Combine(sourcePath, GlobalType_Reallocation_OutHouse_Emb);
                string destFile_OOutHouse_Emb = System.IO.Path.Combine(targetPath_OutHouse_Emb, GlobalType_Reallocation_OutHouse_Emb);
                System.IO.File.Copy(sourceFile_OutHouse_Emb, targetPath_OutHouse_Emb, true);

                //if ((System.IO.File.Exists(Constants.FITS_FOLDER_PATH + GlobalType)))
                //{
                //    System.IO.File.Delete(Constants.FITS_FOLDER_PATH + GlobalType);

                //}
                //System.IO.File.Create(Constants.FITS_FOLDER_PATH + GlobalType);
                //if (!Directory.Exists(Constants.FITS_FOLDER_PATH + GlobalType))
                //{
                //    //If Directory (Folder) does not exists. Create it.
                //    Directory.CreateDirectory(Constants.FITS_FOLDER_PATH + GlobalType);
                //}

                string ReportType = "Cutting_OutHouse";
                // string name = ReportType + "-" + DateTime.Now.ToString("dd MMM yyy") +".xls";
                string pdfFilePath = Path.Combine(Constants.FITS_FOLDER_PATH, GlobalType);

                bool success = controller.GenerateFitsReportExcel(pdfFilePath, ReportType, ds = objadmin.GetFitsReport("Cutting_OutHouse"), GlobalType);

                 ReportType = "OutHouse";
                // string name = ReportType + "-" + DateTime.Now.ToString("dd MMM yyy") +".xls";
                 pdfFilePath = Path.Combine(Constants.FITS_FOLDER_PATH, GlobalType);

                 success = controller.GenerateFitsReportExcel(pdfFilePath, ReportType, ds = objadmin.GetFitsReport("OutHouse"), GlobalType);

                 ReportType = "Finished_OutHouse";
                 // string name = ReportType + "-" + DateTime.Now.ToString("dd MMM yyy") +".xls";
                 pdfFilePath = Path.Combine(Constants.FITS_FOLDER_PATH, GlobalType);

                 success = controller.GenerateFitsReportExcel(pdfFilePath, ReportType, ds = objadmin.GetFitsReport("Finished_OutHouse"), GlobalType);

                ReportType = "All_orders_with_ValueAddition";
                //name = ReportType + "-" + DateTime.Now.ToString("dd MMM yyy") + ".xls";
                pdfFilePath = Path.Combine(Constants.FITS_FOLDER_PATH, GlobalType);
                 success = controller.GenerateFitsReportExcel(pdfFilePath, ReportType, ds = objadmin.GetFitsReport("All_orders_with_ValueAddition"), GlobalType);

                 ReportType = "Ern_orders_with_ValueAddition";
                 //name = ReportType + "-" + DateTime.Now.ToString("dd MMM yyy") + ".xls";
                 pdfFilePath = Path.Combine(Constants.FITS_FOLDER_PATH, GlobalType);
                 success = controller.GenerateFitsReportExcel(pdfFilePath, ReportType, ds = objadmin.GetFitsReport("Ern_orders_with_ValueAddition"), GlobalType);

                 ReportType = "Ern_Outhouse_Cutting";
                 //name = ReportType + "-" + DateTime.Now.ToString("dd MMM yyy") +".xls";
                 pdfFilePath = Path.Combine(Constants.FITS_FOLDER_PATH, GlobalType);

                 success = controller.GenerateFitsReportExcel(pdfFilePath, ReportType, ds = objadmin.GetFitsReport("Ern_Outhouse_Cutting"), GlobalType);

                 ReportType = "Ern_Outhouse";
                 //name = ReportType + "-" + DateTime.Now.ToString("dd MMM yyy") +".xls";
                 pdfFilePath = Path.Combine(Constants.FITS_FOLDER_PATH, GlobalType);

                 success = controller.GenerateFitsReportExcel(pdfFilePath, ReportType, ds = objadmin.GetFitsReport("Ern_Outhouse"), GlobalType);

                 ReportType = "Ern_Outhouse_Finished";
                 //name = ReportType + "-" + DateTime.Now.ToString("dd MMM yyy") +".xls";
                 pdfFilePath = Path.Combine(Constants.FITS_FOLDER_PATH, GlobalType);

                 success = controller.GenerateFitsReportExcel(pdfFilePath, ReportType, ds = objadmin.GetFitsReport("Ern_Outhouse_Finished"), GlobalType);

                //ReportType = "Reallocation_OutHouse";
                ////name = ReportType + "-" + DateTime.Now.ToString("dd MMM yyy") +".xls";
                //string pdfFilePath_OutHouseReallocation = Path.Combine(Constants.FITS_FOLDER_PATH, GlobalType_OutHouseReallocation);

                //success = controller.GenerateFitsReportExcel(pdfFilePath_OutHouseReallocation, ReportType, ds = objadmin.GetFitsReport("Reallocation_OutHouse"), GlobalType_OutHouseReallocation);

                //ReportType = "Reallocation_OutHouse_Emb";
                ////name = ReportType + "-" + DateTime.Now.ToString("dd MMM yyy") +".xls";
                //string pdfFilePath_Reallocation_OutHouse_Emb = Path.Combine(Constants.FITS_FOLDER_PATH, GlobalType_Reallocation_OutHouse_Emb);

                // controller.GenerateFitsReportExcel(pdfFilePath_Reallocation_OutHouse_Emb, ReportType, ds = objadmin.GetFitsReport("Reallocation_OutHouse_Emb"), GlobalType_Reallocation_OutHouse_Emb);

                

            }
            catch (Exception ex)
            {
                string error = ex.ToString();

            }

        }


       

    }
}