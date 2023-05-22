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
using System.Globalization;


namespace iKandi.BLL
{
    public class PDFController : BaseController
    {
        public static class Globals
        {
            public static int TotalQty;
        }

        // public string Tqty;

        int TQty = 0;

        #region

        public Color SummryColor
        {
            get;
            set;
        }
        public Color STCNameBackColor
        {
            get;
            set;
        }
        public Color STCNameForeColor
        {
            get;
            set;
        }
        public Color BalanceBackColor
        {
            get;
            set;
        }
        public Color BalanceForColor
        {
            get;
            set;
        }
        public Color StitchBackColor
        {
            get;
            set;
        }
        public Color StitchForColor
        {
            get;
            set;
        }
        public Color StitchHeaderForColor
        {
            get;
            set;
        }
        public Color DescriptionForColor
        {
            get;
            set;
        }
        public Color StitchDefaultForeColor
        {
            get;
            set;
        }
        public Color EmbBackColor
        {
            get;
            set;
        }
        public Color EmbForColor
        {
            get;
            set;
        }
        public Color PackBackColor
        {
            get;
            set;
        }
        public Color PackForColor
        {
            get;
            set;
        }

        public Color AccessBackColor
        {
            get;
            set;
        }

        public Color AccessForeColor
        {
            get;
            set;
        }

        public int Access_ColorGreen
        {
            get;
            set;
        }
        public int Access_ColorWhite
        {
            get;
            set;
        }
        public int Access_ColorRed
        {
            get;
            set;
        }

        public Color StyleForColor
        {
            get;
            set;
        }

        public Color SAM_OBForColor
        {
            get;
            set;
        }

        public PDFController()
        {
        }

        public PDFController(SessionInfo LoggedInUser)
            : base(LoggedInUser)
        {
        }

        #endregion


        public string IsReScan
        {
          get;
          set;
        }
        /// <summary>
        /// Ex: Constants.SITE_BASE_URL + "/Internal/Sales/TabCostingSheet.aspx?cid=" + cID
        /// </summary>
        /// <param name="PageURL"></param>
        /// <param name="PDFFileName"></param>
        /// <param name="Username"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        public string GeneratePDFForPrint(string PageURL, string PDFFileName, string Username, string Password, int Width, int Height)
        {
            try
            {

                List<string> paths = iKandi.Common.WebPageScreenShotGenerator.GetScreenShot(new string[] { PageURL },
                              Constants.INTERNAL_SITE_BASE_URL + "/public/login.aspx ",
                              Username,
                              Password, Width, Height, true);

                if (!Directory.Exists(Constants.TEMP_FOLDER_PATH))
                    Directory.CreateDirectory(Constants.TEMP_FOLDER_PATH);

                string pdfFilePath = Path.Combine(Constants.TEMP_FOLDER_PATH, PDFFileName + "-" + DateTime.Now.ToString("dd MMM yyy hh-mm-ss") + ".pdf");

                PrintPDFGenerator pdfGen = new PrintPDFGenerator(pdfFilePath);

                if (Width < Height || Height == -1)
                    pdfGen.IsLandScape = false;
                else
                    pdfGen.IsLandScape = true;

                pdfGen.DocumentPageSize = PageSize.A4;

                pdfGen.ImagePath = paths[0];

                if (PageURL.ToString().ToUpper().Contains("BIPLINVOICEPRINT"))
                    pdfGen.GeneratePDF_Invoice();
                else
                    pdfGen.GeneratePDF();

                return pdfFilePath;

            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                // this.NotificationControllerInstance.SendErrorEmail(ex.Message + "\n" + ex.StackTrace);

            }

            return string.Empty;
        }

        public string GeneratePDFForMultiPagePrint(string PageURL, string PDFFileName, string Username, string Password, int Width, int Height)
        {
            System.Drawing.Image img = null;
            System.Drawing.Image[] arrImg = null;
            try
            {
                List<string> paths = iKandi.Common.WebPageScreenShotGenerator.GetScreenShot(new string[] { PageURL },
                              Constants.INTERNAL_SITE_BASE_URL + "/public/login.aspx ",
                              Username,
                              Password, Width, Height, true);


                img = System.Drawing.Image.FromFile(paths[0]);
                int count = 1;
                float pageHeight = PageSize.A4.Height;
                float pageWidth = PageSize.A4.Width;
                float ratio = pageWidth / pageHeight;
                float newHeight = (float)Math.Floor((pageHeight * img.Width) / pageWidth);

                if (img.Height > pageHeight)
                {
                    count = Convert.ToInt32(Math.Ceiling(img.Height / newHeight));

                }

                arrImg = new System.Drawing.Image[count];

                float y = 0;

                for (int i = 0; i < count; i++)
                {

                    float pHeight = newHeight;

                    if ((img.Height - y) < newHeight)
                    {
                        pHeight = img.Height - y;
                    }

                    arrImg[i] = cropImage(img, new System.Drawing.Rectangle(0, Convert.ToInt32(y), Convert.ToInt32(img.Width), Convert.ToInt32(pHeight)));
                    //arrImg[i].Save(@"D:\Projects\Ikandi\iKandi.Web\Uploads\ScreenShots\ScreenShots" + i + ".jpg");
                    y += newHeight;

                }

                if (!Directory.Exists(Constants.TEMP_FOLDER_PATH))
                    Directory.CreateDirectory(Constants.TEMP_FOLDER_PATH);

                string pdfFilePath = Path.Combine(Constants.TEMP_FOLDER_PATH, PDFFileName + "-" + DateTime.Now.ToString("dd MMM yyy hh-mm-ss") + ".pdf");

                MultiPagePrintPDFGenerator pdfGen = new MultiPagePrintPDFGenerator(pdfFilePath);

                pdfGen.IsLandScape = false;

                pdfGen.DocumentPageSize = PageSize.A4;

                pdfGen.ImagePaths = new List<System.Drawing.Image>();

                for (int i = 0; i < count; i++)
                {
                    pdfGen.ImagePaths.Add(arrImg[i]);
                }

                pdfGen.GeneratePDF();

                return pdfFilePath;

            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                // this.NotificationControllerInstance.SendErrorEmail(ex.Message + "\n" + ex.StackTrace);

            }
            finally
            {
                if (img != null)
                    img.Dispose();

                foreach (System.Drawing.Image image in arrImg)
                {
                    if (image != null)
                        image.Dispose();
                }
            }

            return string.Empty;
        }

        private static System.Drawing.Image cropImage(System.Drawing.Image img, System.Drawing.Rectangle cropArea)
        {
            System.Drawing.Bitmap bmpImage = null;
            System.Drawing.Bitmap bmpCrop = null;
            try
            {
                bmpImage = new System.Drawing.Bitmap(img);
                bmpCrop = bmpImage.Clone(cropArea, bmpImage.PixelFormat);

                return (System.Drawing.Image)(bmpCrop);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                NotificationController controller = new NotificationController();
                //  controller.SendErrorEmail(ex.Message + "\n" + ex.StackTrace);
            }
            finally
            {
                if (bmpImage != null)
                {
                    bmpImage.Dispose();
                }
                //if (bmpCrop != null)
                //{
                //    bmpCrop.Dispose();
                //}
            }
            return null;
        }

        //public string GeneratePDFCriticalPath()
        //{
        //    if (!Directory.Exists(Constants.TEMP_FOLDER_PATH))
        //        Directory.CreateDirectory(Constants.TEMP_FOLDER_PATH);
        //    string fileName = "Critical Path Report -" + DateTime.Now.ToString("dd MMM yyy hh-mm-ss") + ".pdf";

        //    return "";
        //}

        public string GenerateDailyOrderSummaryReport(int PageSize, int PageIndex, out int TotalRowCount, string SearchText, int ClientId, int SortedBy, int SortedBy2, int SortedBy3, int SortedBy4, int TotalQuantity, int FactoryManagerUserID, int Userid, DateTime FromExDate, DateTime ToExDate)
        {


            if (!Directory.Exists(Constants.TEMP_FOLDER_PATH))
                Directory.CreateDirectory(Constants.TEMP_FOLDER_PATH);

            string fileName = "Order Summary Report -" + DateTime.Now.ToString("dd MMM yyy hh-mm-ss") + ".pdf";
            // string fileName = "a" + ".pdf";
            string pdfFilePath = Path.Combine(Constants.TEMP_FOLDER_PATH, fileName);

            List<OrderDetail> OrderDetail = this.ReportDataProviderInstance.GetManagingOrderSummaryReport(PageSize, PageIndex, out TotalRowCount, SearchText, ClientId, SortedBy, SortedBy2, SortedBy3, SortedBy4, out TotalQuantity, FactoryManagerUserID, Userid, FromExDate, ToExDate);
            Color HeaderColor = new Color(System.Drawing.ColorTranslator.FromHtml("#F9DDF4"));

            PDFTableGenerator gen = new PDFTableGenerator(pdfFilePath, "Order Summary Report", HeaderColor);

            gen.CellHeight = 200; // Height of the main grid
            gen.IsHeaderTable = true; // To determind weather a table before main grid is added
            gen.HeaderTableBodyHeight = 50;
            gen.HeaderTableHeaderHeight = 50;

            gen.HeaderTableColumns = new List<PDFHeader>(); // create the instance Header of the table before the Main grid
            gen.HeaderTableColumns.Add(new PDFHeader("Selected Client", iKandi.Common.ContentAlignment.Horizontal, 10));
            gen.HeaderTableColumns.Add(new PDFHeader("Factory Manager", iKandi.Common.ContentAlignment.Horizontal, 15));
            gen.HeaderTableColumns.Add(new PDFHeader("From Date", iKandi.Common.ContentAlignment.Horizontal, 10));
            gen.HeaderTableColumns.Add(new PDFHeader("To Date", iKandi.Common.ContentAlignment.Horizontal, 10));
            gen.HeaderTableColumns.Add(new PDFHeader("Sorted By ", iKandi.Common.ContentAlignment.Horizontal, 32));
            gen.HeaderTableColumns.Add(new PDFHeader("Total Quantity", iKandi.Common.ContentAlignment.Horizontal, 10));
            gen.HeaderTableColumns.Add(new PDFHeader("Date", iKandi.Common.ContentAlignment.Horizontal, 10));
            try
            {
                gen.HeaderTableRows = new List<List<PDFCell>>();     // creater the instance of Rows of the table before Main grid which is List<List<PDFCell>>

                List<PDFCell> headerTableRow = new List<PDFCell>();  // vreate the instance of the List<PDFCell> which added the individual columns of a particular row

                string ClientName = string.Empty;
                if (ClientId == -1)
                {
                    ClientName = "All";
                }
                else
                {
                    List<Client> clients = this.ClientDataProviderInstance.GetAllClients();
                    Client objClient = clients.Find(delegate(Client c) { return (c.ClientID == ClientId); });
                    ClientName = objClient.CompanyName;
                }

                PDFCell headerCell = new PDFCell(ClientName.ToUpper(), iKandi.Common.ContentAlignment.Horizontal); // create the instance of each column value along with formating
                headerCell.FontColor = "#0000FF";
                headerCell.FontSize = 18;
                headerCell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                headerCell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                headerTableRow.Add(headerCell); // Add the object the column into a  row  list

                string FactoryManagerName = string.Empty;
                if (FactoryManagerUserID != -1)
                {
                    User objUser = this.UserDataProviderInstance.GetUserByID(FactoryManagerUserID);
                    {
                        FactoryManagerName = objUser.FullName;
                    }
                }
                else
                {
                    FactoryManagerName = "ALL";
                }

                headerCell = new PDFCell(FactoryManagerName.ToUpper(), iKandi.Common.ContentAlignment.Horizontal); // create the instance of each column value along with formating
                headerCell.FontColor = "#0000FF";
                headerCell.FontSize = 18;
                headerCell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                headerCell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                headerTableRow.Add(headerCell);

                string fromDate = string.Empty;
                if (FromExDate != DateTime.MinValue)
                {
                    fromDate = FromExDate.ToString("dd MMM yy (ddd)");
                }
                headerCell = new PDFCell(fromDate, iKandi.Common.ContentAlignment.Horizontal); // create the instance of each column value along with formating
                headerCell.FontColor = "#0000FF";
                headerCell.FontSize = 18;
                headerCell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                headerCell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                headerTableRow.Add(headerCell);

                string toDate = string.Empty;
                if (ToExDate != DateTime.MinValue)
                {
                    toDate = ToExDate.ToString("dd MMM yy (ddd)");
                }

                headerCell = new PDFCell(toDate, iKandi.Common.ContentAlignment.Horizontal); // create the instance of each column value along with formating
                headerCell.FontColor = "#0000FF";
                headerCell.FontSize = 18;
                headerCell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                headerCell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                headerTableRow.Add(headerCell);

                string sortedName = string.Empty;
                string name = string.Empty;

                name = GetOrderSummarySortedParamaterName(SortedBy);
                {
                    if (name != string.Empty)
                    {
                        sortedName = name.ToUpper();
                    }
                }

                name = GetOrderSummarySortedParamaterName(SortedBy2);
                {
                    if (name != string.Empty)
                    {
                        sortedName = sortedName + ", " + name.ToUpper();
                    }
                }

                name = GetOrderSummarySortedParamaterName(SortedBy3);
                {
                    if (name != string.Empty)
                    {
                        sortedName = sortedName + ", " + name.ToUpper();
                    }
                }

                name = GetOrderSummarySortedParamaterName(SortedBy4);
                {
                    if (name != string.Empty)
                    {
                        sortedName = sortedName + ", " + name.ToUpper();
                    }
                }

                if (sortedName.IndexOf(",") == 0)
                {
                    sortedName = sortedName.Substring(1);
                }


                headerCell = new PDFCell(sortedName.ToUpper(), iKandi.Common.ContentAlignment.Horizontal); // create the instance of each column value along with formating
                headerCell.FontColor = "#0000FF";
                headerCell.FontSize = 18;
                headerCell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                headerCell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                headerTableRow.Add(headerCell);

                headerCell = new PDFCell(TotalQuantity.ToString("N0"), iKandi.Common.ContentAlignment.Horizontal); // create the instance of each column value along with formating
                headerCell.FontColor = "#0000FF";
                headerCell.FontSize = 18;
                headerCell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                headerCell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                headerTableRow.Add(headerCell);

                headerCell = new PDFCell(DateTime.Today.ToString("dd MMM yy (ddd)"), iKandi.Common.ContentAlignment.Horizontal); // create the instance of each column value along with formating
                headerCell.FontColor = "#0000FF";
                headerCell.FontSize = 18;
                headerCell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                headerCell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                headerTableRow.Add(headerCell);

                gen.HeaderTableRows.Add(headerTableRow); // add a row list into a lis of row list   
                gen.Columns = new List<PDFHeader>(); // Header of the main grid
                gen.Columns.Add(new PDFHeader("Serial No.", iKandi.Common.ContentAlignment.Vertical, 2, 10));
                gen.Columns.Add(new PDFHeader("Order  Dt.", iKandi.Common.ContentAlignment.Vertical, 2, 10));
                gen.Columns.Add(new PDFHeader("Line No.", iKandi.Common.ContentAlignment.Vertical, 2, 10));
                gen.Columns.Add(new PDFHeader("contrt.", iKandi.Common.ContentAlignment.Vertical, 2, 10));
                gen.Columns.Add(new PDFHeader("Dept.", iKandi.Common.ContentAlignment.Vertical, 2, 10));
                gen.Columns.Add(new PDFHeader("Style Number", iKandi.Common.ContentAlignment.Horizontal, 7));
                gen.Columns.Add(new PDFHeader("Style", iKandi.Common.ContentAlignment.Horizontal, 7));
                gen.Columns.Add(new PDFHeader("Desc", iKandi.Common.ContentAlignment.Vertical, 4, 20));
                gen.Columns.Add(new PDFHeader("Fabric", ContentAlignment.Horizontal, 14));
                gen.Columns.Add(new PDFHeader("Stc Tgt.", iKandi.Common.ContentAlignment.Vertical, 2, 10));
                gen.Columns.Add(new PDFHeader("Fits", iKandi.Common.ContentAlignment.Horizontal, 7));
                gen.Columns.Add(new PDFHeader("Bulk Tgt.", iKandi.Common.ContentAlignment.Vertical, 2, 10));
                gen.Columns.Add(new PDFHeader("Top Actual", iKandi.Common.ContentAlignment.Vertical, 2, 10));
                gen.Columns.Add(new PDFHeader("Qty", iKandi.Common.ContentAlignment.Horizontal, 5));
                gen.Columns.Add(new PDFHeader("Mode", iKandi.Common.ContentAlignment.Vertical, 2, 10));
                gen.Columns.Add(new PDFHeader("Ex Factory", iKandi.Common.ContentAlignment.Horizontal, 10));
                gen.Columns.Add(new PDFHeader("MDA Number", iKandi.Common.ContentAlignment.Vertical, 2, 10));
                gen.Columns.Add(new PDFHeader("Status", iKandi.Common.ContentAlignment.Vertical, 2, 10));
                gen.Columns.Add(new PDFHeader("Unit Name", iKandi.Common.ContentAlignment.Vertical, 2, 10));
                gen.Columns.Add(new PDFHeader("Shipping Remarks", iKandi.Common.ContentAlignment.Horizontal, 10));
                gen.Columns.Add(new PDFHeader("Production Remarks", iKandi.Common.ContentAlignment.Horizontal, 10));

                gen.Rows = new List<List<PDFCell>>(); // Rows adding logic of the Main grid

                foreach (OrderDetail orderDetail in OrderDetail)
                {
                    int icount = 0;
                    List<PDFCell> row = new List<PDFCell>();

                    PDFCell cell = new PDFCell(orderDetail.ParentOrder.SerialNumber, iKandi.Common.ContentAlignment.Vertical);

                    cell.FontSize = 16;
                    cell.BackGroundColor = Constants.GetSerialNumberColor(orderDetail.ExFactory);
                    cell.FontColor = "#0000FF";
                    cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                    row.Add(cell);

                    string OrderDate = ((orderDetail.ParentOrder.OrderDate) == DateTime.MinValue) ? String.Empty : orderDetail.ParentOrder.OrderDate.ToString("dd MMM yy (ddd)");

                    cell = new PDFCell(OrderDate, iKandi.Common.ContentAlignment.Vertical);
                    cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                    row.Add(cell);

                    cell = new PDFCell(orderDetail.LineItemNumber, iKandi.Common.ContentAlignment.Vertical);
                    cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                    row.Add(cell);

                    cell = new PDFCell(orderDetail.ContractNumber, iKandi.Common.ContentAlignment.Vertical);
                    cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                    row.Add(cell);

                    cell = new PDFCell(orderDetail.ParentOrder.Style.cdept.Name, iKandi.Common.ContentAlignment.Vertical);
                    cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                    row.Add(cell);

                    cell = new PDFCell(orderDetail.ParentOrder.Style.StyleNumber, iKandi.Common.ContentAlignment.Horizontal);
                    cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                    cell.FontSize = 16;
                    cell.FontColor = "#0000FF";
                    row.Add(cell);

                    string ImagePath = orderDetail.ParentOrder.Style.SampleImageURL1;

                    cell = new PDFCell(string.Empty, iKandi.Common.ContentAlignment.Horizontal);
                    if (ImagePath != string.Empty)
                    {
                        cell.ImageUrl = Path.Combine(Constants.STYLE_FOLDER_PATH, "thumb-" + ImagePath);
                    }
                    row.Add(cell);

                    cell = new PDFCell(orderDetail.Description, iKandi.Common.ContentAlignment.Vertical);
                    cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                    row.Add(cell);

                    string Fabric1 = orderDetail.Fabric1;
                    string Fabric1Detail = orderDetail.Fabric1Details.ToString().Trim();
                    int Fabric1Percent = orderDetail.ParentOrder.FabricInhouseHistory.Fabric1Percent;

                    if (Fabric1Detail != "")
                    {
                        Fabric1 = Fabric1 + " : " + Fabric1Detail;
                    }

                    if (orderDetail.ParentOrder.FabricApprovalDetails.F5BulkStatus != "")
                    {
                        Fabric1 = Fabric1 + " ( " + orderDetail.ParentOrder.FabricApprovalDetails.F5BulkStatus.ToString().ToUpper() + " ) ";
                    }

                    if (Fabric1Percent != 0)
                    {
                        Fabric1 = Fabric1 + " (" + Fabric1Percent + "%)";
                    }

                    string Fabric2 = orderDetail.Fabric2;
                    string Fabric2Detail = orderDetail.Fabric2Details.ToString().Trim();
                    int Fabric2Percent = orderDetail.ParentOrder.FabricInhouseHistory.Fabric2Percent;

                    if (Fabric2Detail != "")
                    {
                        Fabric2 = Fabric2 + " : " + Fabric2Detail;
                    }

                    if (orderDetail.ParentOrder.FabricApprovalDetails.F6BulkStatus != "")
                    {
                        Fabric2 = Fabric2 + " ( " + orderDetail.ParentOrder.FabricApprovalDetails.F6BulkStatus.ToString().ToUpper() + " ) ";
                    }

                    if (Fabric2Percent != 0)
                    {
                        Fabric2 = Fabric2 + " (" + Fabric2Percent + "%)";
                    }

                    string Fabric3 = orderDetail.Fabric3;
                    string Fabric3Detail = orderDetail.Fabric3Details.ToString().Trim();
                    int Fabric3Percent = orderDetail.ParentOrder.FabricInhouseHistory.Fabric3Percent;

                    if (Fabric3Detail != "")
                    {
                        Fabric3 = Fabric3 + " : " + Fabric3Detail;
                    }

                    if (orderDetail.ParentOrder.FabricApprovalDetails.F7BulkStatus != "")
                    {
                        Fabric3 = Fabric3 + " ( " + orderDetail.ParentOrder.FabricApprovalDetails.F7BulkStatus.ToString().ToUpper() + " ) ";
                    }

                    if (Fabric3Percent != 0)
                    {
                        Fabric3 = Fabric3 + " (" + Fabric3Percent + "%)";
                    }

                    string Fabric4 = orderDetail.Fabric4;
                    string Fabric4Detail = orderDetail.Fabric4Details.ToString().Trim();
                    int Fabric4Percent = orderDetail.ParentOrder.FabricInhouseHistory.Fabric4Percent;

                    if (Fabric4Detail != "")
                    {
                        Fabric4 = Fabric4 + " : " + Fabric4Detail;
                    }

                    if (orderDetail.ParentOrder.FabricApprovalDetails.F8BulkStatus != "")
                    {
                        Fabric4 = Fabric4 + " ( " + orderDetail.ParentOrder.FabricApprovalDetails.F8BulkStatus.ToString().ToUpper() + " ) ";
                    }

                    if (Fabric4Percent != 0)
                    {
                        Fabric4 = Fabric4 + " (" + Fabric4Percent + "%)";
                    }

                    cell = new PDFCell(Fabric1 + "\n" + "\n" + Fabric2 + "\n" + "\n" + Fabric3 + "\n" + "\n" + Fabric4, iKandi.Common.ContentAlignment.Horizontal);
                    cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
                    cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                    cell.Padding = 5;
                    row.Add(cell);

                    string stcTgt;
                    if ((orderDetail.STCUnallocated) == DateTime.MinValue)
                    {
                        stcTgt = "";
                    }
                    else
                    {
                        stcTgt = orderDetail.STCUnallocated.ToString("dd MMM yy (ddd)");
                    }

                    cell = new PDFCell(stcTgt, iKandi.Common.ContentAlignment.Vertical);
                    cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                    row.Add(cell);

                    string FitsStatus = orderDetail.FitStatus.ToString();

                    cell = new PDFCell(FitsStatus, iKandi.Common.ContentAlignment.Horizontal);
                    cell.BackGroundColor = orderDetail.FitStatusBgColor.ToString();
                    cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
                    cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                    cell.Padding = 5;
                    row.Add(cell);

                    string BulkTgt;
                    if ((orderDetail.BulkTarget) == DateTime.MinValue)
                    {
                        BulkTgt = "";
                    }
                    else
                    {
                        BulkTgt = orderDetail.BulkTarget.ToString("dd MMM yy (ddd)");
                    }

                    cell = new PDFCell(BulkTgt, iKandi.Common.ContentAlignment.Vertical);
                    cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                    row.Add(cell);

                    string TopSendTgt;
                    if ((orderDetail.ParentOrder.InlinePPMOrderContract.TopSentTarget) == DateTime.MinValue)
                    {
                        TopSendTgt = "";
                    }
                    else
                    {
                        TopSendTgt = orderDetail.ParentOrder.InlinePPMOrderContract.TopSentTarget.ToString("dd MMM yy (ddd)");
                    }

                    cell = new PDFCell(TopSendTgt, iKandi.Common.ContentAlignment.Vertical);
                    cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                    row.Add(cell);

                    cell = new PDFCell(orderDetail.Quantity.ToString("N0"), iKandi.Common.ContentAlignment.Horizontal);
                    cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                    cell.FontSize = 16;
                    cell.FontColor = "#0000FF";
                    row.Add(cell);

                    cell = new PDFCell(orderDetail.ModeName, iKandi.Common.ContentAlignment.Vertical);
                    cell.BackGroundColor = iKandi.BLL.CommonHelper.GetDeliveryModeColor(orderDetail.Mode);
                    cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                    row.Add(cell);

                    string ExFactory;
                    if ((orderDetail.ExFactory) == DateTime.MinValue)
                    {
                        ExFactory = "";
                    }
                    else
                    {
                        ExFactory = orderDetail.ExFactory.ToString("dd MMM yy (ddd)");
                    }

                    string plannedEx;
                    if (orderDetail.PlannedEx == DateTime.MinValue)
                    {
                        plannedEx = "";
                    }
                    else
                    {
                        plannedEx = "( " + orderDetail.PlannedEx.ToString("dd MMM yy (ddd)") + " )";
                    }

                    cell = new PDFCell(ExFactory + " \n\n" + plannedEx, iKandi.Common.ContentAlignment.Horizontal);
                    cell.FontSize = 16;
                    cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                    cell.BackGroundColor = iKandi.BLL.CommonHelper.GetExFactoryColor(orderDetail.ExFactory, orderDetail.DC, orderDetail.Mode);
                    row.Add(cell);

                    //MDA Number
                    cell = new PDFCell(orderDetail.MDANumber, iKandi.Common.ContentAlignment.Vertical);
                    cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                    row.Add(cell);

                    cell = new PDFCell(orderDetail.ParentOrder.WorkflowInstanceDetail.StatusMode, iKandi.Common.ContentAlignment.Vertical);
                    cell.BackGroundColor = Constants.GetStatusModeColor(orderDetail.ParentOrder.WorkflowInstanceDetail.StatusModeID);
                    cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                    row.Add(cell);

                    cell = new PDFCell(orderDetail.Unit.FactoryName, iKandi.Common.ContentAlignment.Vertical);
                    cell.BackGroundColor = orderDetail.Unit.ProductionUnitColor;
                    cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                    row.Add(cell);
                    string SanjeevRemark = "";

                    if (orderDetail.SanjeevRemarks.ToString().LastIndexOf("$$") > -1)
                    {
                        SanjeevRemark = orderDetail.SanjeevRemarks.ToString().Substring(orderDetail.SanjeevRemarks.ToString().LastIndexOf("$$") + 2);
                    }
                    else
                    {
                        SanjeevRemark = orderDetail.SanjeevRemarks.ToString();
                    }

                    cell = new PDFCell(SanjeevRemark, iKandi.Common.ContentAlignment.Horizontal);
                    cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
                    cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                    cell.Padding = 5;
                    row.Add(cell);

                    string ProductionRemarks = "";

                    if (orderDetail.ParentOrder.StitchingDetail.ProdRemarks.ToString().LastIndexOf("$$") > -1)
                    {
                        ProductionRemarks = orderDetail.ParentOrder.StitchingDetail.ProdRemarks.ToString().Substring(orderDetail.ParentOrder.StitchingDetail.ProdRemarks.ToString().LastIndexOf("$$") + 2);
                    }
                    else
                    {
                        ProductionRemarks = orderDetail.ParentOrder.StitchingDetail.ProdRemarks.ToString();
                    }

                    cell = new PDFCell(ProductionRemarks, iKandi.Common.ContentAlignment.Horizontal);
                    cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
                    cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                    cell.Padding = 5;
                    row.Add(cell);

                    gen.Rows.Add(row);
                    icount = icount + 1;
                }

                gen.GeneratePDF(); // Method which makes the Pdf 

            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
            }
            return fileName;
        }


        public bool GeneratePDFCriticalPath(string PDFPath)
        {
            //'Order Date	Serial No.	Client	Department	Style Number	Line No	Contract No	Description	Qty	Mode	Pack Type	DC Date';
            PDFPath = "e:\\TEST.PDF";
            Color HeaderColor = new Color(System.Drawing.ColorTranslator.FromHtml("#F9DDF4"));
            PDFTableGenerator gen = new PDFTableGenerator(PDFPath, "CRITICAL PATH", HeaderColor);

            gen.Columns = new List<PDFHeader>();


            gen.Columns.Add(new PDFHeader("Basic Information", iKandi.Common.ContentAlignment.Horizontal, 2, 10));
            gen.Columns[0].ColumnSpan = 6;
            gen.Columns.Add(new PDFHeader("Basic Information1", iKandi.Common.ContentAlignment.Horizontal, 2, 10));
            gen.Columns[1].ColumnSpan = 6;
            gen.Columns.Add(new PDFHeader("Basic Information3", iKandi.Common.ContentAlignment.Horizontal, 2, 10));
            gen.Columns[2].ColumnSpan = 3;

            gen.Columns.Add(new PDFHeader("A", iKandi.Common.ContentAlignment.Horizontal, 2, 10));
            gen.Columns.Add(new PDFHeader("B", iKandi.Common.ContentAlignment.Horizontal, 2, 10));
            gen.Columns.Add(new PDFHeader("C", iKandi.Common.ContentAlignment.Horizontal, 2, 10));

            gen.Columns.Add(new PDFHeader("D", iKandi.Common.ContentAlignment.Horizontal, 2, 10));
            gen.Columns.Add(new PDFHeader("E", iKandi.Common.ContentAlignment.Horizontal, 2, 10));
            gen.Columns.Add(new PDFHeader("F", iKandi.Common.ContentAlignment.Horizontal, 2, 10));
            gen.Columns.Add(new PDFHeader("G", iKandi.Common.ContentAlignment.Horizontal, 2, 10));

            gen.Columns.Add(new PDFHeader("H", iKandi.Common.ContentAlignment.Horizontal, 2, 10));
            gen.Columns.Add(new PDFHeader("I", iKandi.Common.ContentAlignment.Horizontal, 2, 10));
            gen.Columns.Add(new PDFHeader("J", iKandi.Common.ContentAlignment.Horizontal, 2, 10));
            gen.Columns.Add(new PDFHeader("K", iKandi.Common.ContentAlignment.Horizontal, 2, 10));
            gen.Columns.Add(new PDFHeader("L", iKandi.Common.ContentAlignment.Horizontal, 2, 10));





            //gen.Columns.Add(new PDFHeader("Order Date", iKandi.Common.ContentAlignment.Vertical, 2, 10));
            //gen.Columns.Add(new PDFHeader("Serial No.", iKandi.Common.ContentAlignment.Vertical, 2, 10));
            //gen.Columns.Add(new PDFHeader("Client", iKandi.Common.ContentAlignment.Vertical, 2, 10));
            //gen.Columns.Add(new PDFHeader("Department", iKandi.Common.ContentAlignment.Vertical, 2, 10));
            //gen.Columns.Add(new PDFHeader("Style Number", iKandi.Common.ContentAlignment.Vertical, 2, 10));
            //gen.Columns.Add(new PDFHeader("Line No", iKandi.Common.ContentAlignment.Vertical, 2, 10));
            //gen.Columns.Add(new PDFHeader("Contract No", iKandi.Common.ContentAlignment.Vertical, 2, 10));
            //gen.Columns.Add(new PDFHeader("Description", iKandi.Common.ContentAlignment.Horizontal, 2, 10));
            //gen.Columns.Add(new PDFHeader("Qty", iKandi.Common.ContentAlignment.Horizontal, 2, 10));
            //gen.Columns.Add(new PDFHeader("Mode", iKandi.Common.ContentAlignment.Vertical, 2, 10));
            //gen.Columns.Add(new PDFHeader("Pack Type", iKandi.Common.ContentAlignment.Horizontal, 2, 10));
            //gen.Columns.Add(new PDFHeader("DC Date", iKandi.Common.ContentAlignment.Vertical, 2, 10));

            // gen.Columns[1].ColumnSpan = 2;
            // gen.Columns.Add(new PDFHeader("Fabric", iKandi.Common.ContentAlignment.Horizontal, 2, 10));
            // gen.Columns.Add(new PDFHeader("Accessories", iKandi.Common.ContentAlignment.Horizontal, 2, 10));





            gen.Rows = new List<List<PDFCell>>();

            List<PDFCell> row = new List<PDFCell>();
            PDFCell cell = new PDFCell("Order Dete", iKandi.Common.ContentAlignment.Vertical);
            cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
            cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
            cell.Padding = 10;
            cell.Width = 2;
            row.Add(cell);
            cell = new PDFCell("Order Dete", iKandi.Common.ContentAlignment.Vertical);
            cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
            cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
            cell.Padding = 10;
            cell.Width = 2;
            row.Add(cell);
            cell = new PDFCell("Order Dete", iKandi.Common.ContentAlignment.Vertical);
            cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
            cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
            cell.Padding = 10;
            cell.Width = 2;
            row.Add(cell);

            cell = new PDFCell("Order Dete", iKandi.Common.ContentAlignment.Vertical);
            cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
            cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
            cell.Padding = 10;
            cell.Width = 2;
            row.Add(cell);

            cell = new PDFCell("Serial No.1", iKandi.Common.ContentAlignment.Vertical);
            cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
            cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
            cell.Padding = 10;
            cell.Width = 2;
            row.Add(cell);


            cell = new PDFCell("Client", iKandi.Common.ContentAlignment.Vertical);
            cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
            cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
            cell.Padding = 10;
            cell.Width = 2;
            row.Add(cell);


            cell = new PDFCell("Department", iKandi.Common.ContentAlignment.Vertical);
            cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
            cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
            cell.Padding = 10;
            row.Add(cell);


            cell = new PDFCell("Style Number", iKandi.Common.ContentAlignment.Vertical);
            cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
            cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
            cell.Padding = 10;
            cell.Width = 2;
            row.Add(cell);


            cell = new PDFCell("Line No", iKandi.Common.ContentAlignment.Vertical);
            cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
            cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
            cell.Padding = 10;
            cell.Width = 2;
            row.Add(cell);

            cell = new PDFCell("Contract No", iKandi.Common.ContentAlignment.Vertical);
            cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
            cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
            cell.Padding = 10;
            cell.Width = 2;
            row.Add(cell);

            cell = new PDFCell("Description", iKandi.Common.ContentAlignment.Horizontal);
            cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
            cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
            cell.Padding = 10;
            cell.Width = 2;
            row.Add(cell);


            cell = new PDFCell("Qty", iKandi.Common.ContentAlignment.Horizontal);
            cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
            cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
            cell.Padding = 10;
            cell.Width = 2;
            row.Add(cell);


            cell = new PDFCell("Mode", iKandi.Common.ContentAlignment.Horizontal);
            cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
            cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
            cell.Padding = 10;
            cell.Width = 2;
            row.Add(cell);

            cell = new PDFCell("Pack Type", iKandi.Common.ContentAlignment.Horizontal);
            cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
            cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
            cell.Padding = 10;
            cell.Width = 2;
            row.Add(cell);

            cell = new PDFCell("DC Date", iKandi.Common.ContentAlignment.Vertical);
            cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
            cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
            cell.Padding = 10;
            cell.Width = 2;
            row.Add(cell);

            gen.Rows.Add(row);

            return gen.GeneratePDF();

        }



        public double GetNewOderEmailTotalQuantity(DateTime Date, bool BCHECK)
        {
            double totalQuantity = 0;
            List<OrderDetail> orderDetail = this.OrderDataProviderInstance.GetAllNewOrderReport(Date, BCHECK);

            foreach (OrderDetail od in orderDetail)
            {
                if (od.ParentOrder.WorkflowInstanceDetail.StatusModeID != 24)
                {
                    totalQuantity = totalQuantity + od.Quantity;
                }
            }

            return totalQuantity;
        }


        public bool GenerateDailyQAPandingReport(string PDFPath)
        {
            List<OrderDetail> orderdetails = this.ReportDataProviderInstance.GetAllQAPendingFromProductionReport();

            if (orderdetails == null || orderdetails.Count == 0)
            {
                return false;
            }

            Color HeaderColor = new Color(System.Drawing.ColorTranslator.FromHtml("#F9DDF4"));
            PDFTableGenerator gen = new PDFTableGenerator(PDFPath, "QA Forms Pending Report", HeaderColor);
            gen.CellHeight = 200;

            gen.Columns = new List<PDFHeader>();
            gen.Columns.Add(new PDFHeader("Buyer", iKandi.Common.ContentAlignment.Vertical, 1, 10));
            gen.Columns.Add(new PDFHeader("Serial No.", iKandi.Common.ContentAlignment.Vertical, 1, 10));
            gen.Columns.Add(new PDFHeader("Dept.", iKandi.Common.ContentAlignment.Vertical, 2, 10));
            gen.Columns.Add(new PDFHeader("Style No.", iKandi.Common.ContentAlignment.Horizontal, 6));
            gen.Columns.Add(new PDFHeader("Style", iKandi.Common.ContentAlignment.Horizontal, 6));
            gen.Columns.Add(new PDFHeader("Line/Item No", iKandi.Common.ContentAlignment.Vertical, 2, 10));
            gen.Columns.Add(new PDFHeader("Contract No", iKandi.Common.ContentAlignment.Vertical, 2, 10));
            gen.Columns.Add(new PDFHeader("Description", iKandi.Common.ContentAlignment.Vertical, 3, 15));
            gen.Columns.Add(new PDFHeader("Qty / Shipping Qty", iKandi.Common.ContentAlignment.Vertical, 2, 10));
            gen.Columns.Add(new PDFHeader("Mode", iKandi.Common.ContentAlignment.Vertical, 2, 10));
            gen.Columns.Add(new PDFHeader("ExFactory", iKandi.Common.ContentAlignment.Vertical, 2, 10));
            gen.Columns.Add(new PDFHeader("Status", iKandi.Common.ContentAlignment.Vertical, 2, 10));
            gen.Columns.Add(new PDFHeader("Sealer Tgt", iKandi.Common.ContentAlignment.Vertical, 2, 10));
            gen.Columns.Add(new PDFHeader("Sealer Actual", iKandi.Common.ContentAlignment.Vertical, 2, 10));
            gen.Columns.Add(new PDFHeader("Fabric Details", iKandi.Common.ContentAlignment.Horizontal, 12));
            gen.Columns.Add(new PDFHeader("Accessories", iKandi.Common.ContentAlignment.Horizontal, 14));
            gen.Columns.Add(new PDFHeader("Inline Cut Date", iKandi.Common.ContentAlignment.Vertical, 2, 10));
            gen.Columns.Add(new PDFHeader("Cutting Actual", iKandi.Common.ContentAlignment.Vertical, 2, 10));
            gen.Columns.Add(new PDFHeader("PCS cut", iKandi.Common.ContentAlignment.Vertical, 2, 10));
            gen.Columns.Add(new PDFHeader("PCS issued", iKandi.Common.ContentAlignment.Vertical, 2, 10));
            gen.Columns.Add(new PDFHeader("Unit", iKandi.Common.ContentAlignment.Vertical, 2, 10));
            gen.Columns.Add(new PDFHeader("Top Target", iKandi.Common.ContentAlignment.Vertical, 2, 10));
            gen.Columns.Add(new PDFHeader("Top Actual", iKandi.Common.ContentAlignment.Vertical, 2, 10));
            gen.Columns.Add(new PDFHeader("Pcs Stiched Today", iKandi.Common.ContentAlignment.Vertical, 2, 10));
            gen.Columns.Add(new PDFHeader("Pcs Stiched Overall", iKandi.Common.ContentAlignment.Vertical, 2, 10));
            gen.Columns.Add(new PDFHeader("Packed", iKandi.Common.ContentAlignment.Vertical, 2, 10));
            gen.Columns.Add(new PDFHeader("Bal On Mach.", iKandi.Common.ContentAlignment.Vertical, 2, 10));
            gen.Columns.Add(new PDFHeader("Pcs Packed Today", iKandi.Common.ContentAlignment.Vertical, 2, 10));
            gen.Columns.Add(new PDFHeader("Pcs Packed Overall", iKandi.Common.ContentAlignment.Vertical, 2, 10));
            gen.Columns.Add(new PDFHeader("Production Remarks", iKandi.Common.ContentAlignment.Horizontal, 10));


            gen.Rows = new List<List<PDFCell>>();

            foreach (OrderDetail orderdetail in orderdetails)
            {
                if (orderdetail.ParentOrder.WorkflowInstanceDetail.StatusModeID != 24)
                {
                    List<PDFCell> row = new List<PDFCell>();

                    PDFCell cell = new PDFCell(orderdetail.ParentOrder.Style.client.CompanyName, iKandi.Common.ContentAlignment.Vertical);
                    cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                    row.Add(cell);

                    cell = new PDFCell(orderdetail.ParentOrder.SerialNumber, iKandi.Common.ContentAlignment.Vertical);
                    cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                    cell.FontColor = "#0000ff";
                    cell.FontSize = 16;
                    cell.BackGroundColor = Constants.GetSerialNumberColor(orderdetail.ExFactory);
                    row.Add(cell);

                    cell = new PDFCell(orderdetail.ParentOrder.Style.cdept.Name.ToUpper(), iKandi.Common.ContentAlignment.Vertical);
                    cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                    row.Add(cell);

                    cell = new PDFCell(orderdetail.ParentOrder.Style.StyleNumber);
                    cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                    cell.FontColor = "#0000ff";
                    cell.FontSize = 16;
                    row.Add(cell);

                    string ImagePath = orderdetail.ParentOrder.Style.SampleImageURL1;

                    cell = new PDFCell(string.Empty, iKandi.Common.ContentAlignment.Horizontal);
                    if (ImagePath != string.Empty)
                    {
                        cell.ImageUrl = Path.Combine(Constants.STYLE_FOLDER_PATH, "thumb-" + ImagePath);

                    }
                    row.Add(cell);

                    cell = new PDFCell(orderdetail.LineItemNumber, iKandi.Common.ContentAlignment.Vertical);
                    cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                    row.Add(cell);

                    cell = new PDFCell(orderdetail.ContractNumber, iKandi.Common.ContentAlignment.Vertical);
                    cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                    row.Add(cell);

                    cell = new PDFCell(orderdetail.ParentOrder.Description, iKandi.Common.ContentAlignment.Vertical);
                    cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                    row.Add(cell);

                    cell = new PDFCell(orderdetail.Quantity.ToString("N0") + " / " + orderdetail.ParentOrder.ProductionPlanning.ShipmentQty.ToString("N0"), iKandi.Common.ContentAlignment.Vertical);
                    cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                    cell.FontColor = "#0000ff";
                    cell.FontSize = 16;
                    row.Add(cell);

                    cell = new PDFCell(orderdetail.ModeName, iKandi.Common.ContentAlignment.Vertical);
                    cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                    cell.BackGroundColor = Constants.GetStatusModeColor(orderdetail.Mode);
                    row.Add(cell);

                    string ExFactory = (orderdetail.ExFactory == DateTime.MinValue) ? string.Empty : orderdetail.ExFactory.ToString("dd MMM yy (ddd)");
                    cell = new PDFCell(ExFactory, iKandi.Common.ContentAlignment.Vertical);
                    cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                    cell.FontColor = "#0000ff";
                    cell.FontSize = 16;
                    cell.BackGroundColor = iKandi.BLL.CommonHelper.GetExFactoryColor(orderdetail.ExFactory, orderdetail.DC, orderdetail.Mode);
                    row.Add(cell);

                    cell = new PDFCell(orderdetail.ParentOrder.WorkflowInstanceDetail.StatusMode, iKandi.Common.ContentAlignment.Vertical);
                    cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                    cell.BackGroundColor = Constants.GetStatusModeColor(orderdetail.ParentOrder.WorkflowInstanceDetail.StatusModeID);
                    row.Add(cell);

                    string SealerTgt = (orderdetail.STCUnallocated == DateTime.MinValue) ? string.Empty : orderdetail.STCUnallocated.ToString("ss MMM yy (ddd)");
                    cell = new PDFCell(SealerTgt, iKandi.Common.ContentAlignment.Vertical);
                    cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                    row.Add(cell);


                    string SealerActual = (orderdetail.ParentOrder.Fits.SealDate == DateTime.MinValue) ? string.Empty : orderdetail.ParentOrder.Fits.SealDate.ToString("dd MMM yy (ddd)");
                    cell = new PDFCell(SealerActual, iKandi.Common.ContentAlignment.Vertical);
                    cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                    row.Add(cell);

                    string Fabric1 = orderdetail.Fabric1;
                    string Fabric1Detail = orderdetail.Fabric1Details.ToString().Trim();
                    int Fabric1Percent = orderdetail.ParentOrder.FabricInhouseHistory.Fabric1Percent;

                    if (Fabric1Detail != "")
                    {
                        Fabric1 = Fabric1 + " : " + Fabric1Detail;
                    }

                    if (Fabric1Percent != 0)
                    {
                        Fabric1 = Fabric1 + " (" + Fabric1Percent + "%)";
                    }

                    string Fabric2 = orderdetail.Fabric2;
                    string Fabric2Detail = orderdetail.Fabric2Details.ToString().Trim();
                    int Fabric2Percent = orderdetail.ParentOrder.FabricInhouseHistory.Fabric2Percent;

                    if (Fabric2Detail != "")
                    {
                        Fabric2 = Fabric2 + " : " + Fabric2Detail;
                    }

                    if (Fabric2Percent != 0)
                    {
                        Fabric2 = Fabric2 + " (" + Fabric2Percent + "%)";
                    }


                    string Fabric3 = orderdetail.Fabric3;
                    string Fabric3Detail = orderdetail.Fabric3Details.ToString().Trim();
                    int Fabric3Percent = orderdetail.ParentOrder.FabricInhouseHistory.Fabric3Percent;

                    if (Fabric3Detail != "")
                    {
                        Fabric3 = Fabric3 + " : " + Fabric3Detail;
                    }

                    if (Fabric3Percent != 0)
                    {
                        Fabric3 = Fabric3 + " (" + Fabric3Percent + "%)";
                    }

                    string Fabric4 = orderdetail.Fabric4;
                    string Fabric4Detail = orderdetail.Fabric4Details.ToString().Trim();
                    int Fabric4Percent = orderdetail.ParentOrder.FabricInhouseHistory.Fabric4Percent;

                    if (Fabric4Detail != "")
                    {
                        Fabric4 = Fabric4 + " : " + Fabric4Detail;
                    }

                    if (Fabric4Percent != 0)
                    {
                        Fabric4 = Fabric4 + " (" + Fabric4Percent + "%)";
                    }

                    cell = new PDFCell(Fabric1 + "\n\n" + Fabric2 + "\n\n" + Fabric3 + "\n\n" + Fabric4);
                    cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
                    cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                    cell.BackGroundColor = Constants.GetPercentageColor(orderdetail.ParentOrder.FabricInhouseHistory.Fabric1Percent);
                    cell.Padding = 5;
                    row.Add(cell);

                    string accessoriesHistory = (Convert.ToString(orderdetail.AccessoryHistory) == null) ? "" : orderdetail.AccessoryHistory.ToString();
                    cell = new PDFCell(accessoriesHistory.ToString().Replace("<br/><br/>", "\n"), iKandi.Common.ContentAlignment.Horizontal, 100);
                    cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
                    cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                    cell.Padding = 5;
                    row.Add(cell);

                    String InlineCutDate = (orderdetail.ParentOrder.Style.InLineCutDate == DateTime.MinValue) ? string.Empty : orderdetail.ParentOrder.Style.InLineCutDate.ToString("dd MMM yy (ddd)");
                    cell = new PDFCell(InlineCutDate, iKandi.Common.ContentAlignment.Vertical);
                    cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                    row.Add(cell);

                    String CuttingActual = (orderdetail.ParentOrder.CuttingHistory.Date == DateTime.MinValue) ? string.Empty : orderdetail.ParentOrder.CuttingHistory.Date.ToString("dd MMM yy (ddd)");
                    cell = new PDFCell(CuttingActual, iKandi.Common.ContentAlignment.Vertical);
                    cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                    row.Add(cell);

                    cell = new PDFCell(orderdetail.ParentOrder.CuttingDetail.PcsCut.ToString("N0"), iKandi.Common.ContentAlignment.Vertical);
                    cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                    row.Add(cell);

                    cell = new PDFCell(orderdetail.ParentOrder.CuttingDetail.PcsIssued.ToString("N0"), iKandi.Common.ContentAlignment.Vertical);
                    cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                    row.Add(cell);


                    cell = new PDFCell(orderdetail.Unit.FactoryCode, iKandi.Common.ContentAlignment.Vertical);
                    cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                    row.Add(cell);

                    string TopSendTgt = (orderdetail.ParentOrder.InlinePPMOrderContract.TopSentTarget == DateTime.MinValue) ? string.Empty : orderdetail.ParentOrder.InlinePPMOrderContract.TopSentTarget.ToString("dd MMM yy (ddd)");
                    cell = new PDFCell(TopSendTgt, iKandi.Common.ContentAlignment.Vertical);
                    cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                    row.Add(cell);

                    string TopSendActual = (orderdetail.ParentOrder.InlinePPMOrderContract.TopSentActual == DateTime.MinValue) ? string.Empty : orderdetail.ParentOrder.InlinePPMOrderContract.TopSentActual.ToString("dd MMM yy (ddd)");
                    cell = new PDFCell(TopSendActual, iKandi.Common.ContentAlignment.Vertical);
                    cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                    cell.BackGroundColor = Constants.GetActualDateColor(orderdetail.ParentOrder.InlinePPMOrderContract.TopSentTarget, orderdetail.ParentOrder.InlinePPMOrderContract.TopSentActual);
                    row.Add(cell);

                    cell = new PDFCell(orderdetail.ParentOrder.StitchingDetail.TotalPcsStitchedToday.ToString("N0"), iKandi.Common.ContentAlignment.Vertical);
                    cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                    row.Add(cell);

                    cell = new PDFCell(orderdetail.ParentOrder.StitchingDetail.OverallPcsStitched.ToString("N0"), iKandi.Common.ContentAlignment.Vertical);
                    cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                    row.Add(cell);

                    cell = new PDFCell(orderdetail.ParentOrder.StitchingDetail.PercentageOverallPcsPacked.ToString("N0") + "%", iKandi.Common.ContentAlignment.Vertical);
                    cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                    cell.BackGroundColor = Constants.GetPercentageColor(orderdetail.ParentOrder.StitchingDetail.PercentageOverallPcsPacked);
                    row.Add(cell);

                    cell = new PDFCell(orderdetail.ParentOrder.StitchingDetail.BalOnMach.ToString("N0"), iKandi.Common.ContentAlignment.Vertical);
                    cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                    row.Add(cell);

                    cell = new PDFCell(orderdetail.ParentOrder.StitchingDetail.PcsPackedToday.ToString("N0"), iKandi.Common.ContentAlignment.Vertical);
                    cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                    row.Add(cell);

                    cell = new PDFCell(orderdetail.ParentOrder.StitchingDetail.OverallPcsPacked.ToString("N0"), iKandi.Common.ContentAlignment.Vertical);
                    cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                    row.Add(cell);

                    string ProductionRemarks = "";

                    if (orderdetail.ParentOrder.StitchingDetail.ProdRemarks.ToString().LastIndexOf("$$") > -1)
                    {
                        ProductionRemarks = orderdetail.ParentOrder.StitchingDetail.ProdRemarks.ToString().Substring(orderdetail.ParentOrder.StitchingDetail.ProdRemarks.ToString().LastIndexOf("$$") + 2);
                    }
                    else
                    {
                        ProductionRemarks = orderdetail.ParentOrder.StitchingDetail.ProdRemarks.ToString();
                    }
                    cell = new PDFCell(ProductionRemarks, iKandi.Common.ContentAlignment.Horizontal);
                    cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
                    cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                    row.Add(cell);

                    gen.Rows.Add(row);
                }
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







        public string GenerateFabricQualityList(int PageSize, int PageIndex, out int TotalPageCount, string SearchText, int GroupId, int SubGroupId, String GsmFrom, String GsmTo, String WidthFrom, String WidthTo, String PriceFrom, String PriceTo, int IsReg, int Order1, int Order2, int Order3, int Order4)
        {

            if (!Directory.Exists(Constants.TEMP_FOLDER_PATH))
                Directory.CreateDirectory(Constants.TEMP_FOLDER_PATH);

            string fileName = "Fabric Quality List-" + DateTime.Now.ToString("dd MMM yyy hh-mm-ss") + ".pdf";
            // string fileName = "a" + ".pdf";
            string pdfFilePath = Path.Combine(Constants.TEMP_FOLDER_PATH, fileName);

            List<FabricQuality> fabricQuality = this.FabricQualityDataProviderInstance.GetAllFabricQuality(PageSize, PageIndex, out TotalPageCount, SearchText, GroupId, SubGroupId, GsmFrom, GsmTo, WidthFrom, WidthTo, PriceFrom, PriceTo, IsReg, Order1, Order2, Order3, Order4);
            Color HeaderColor = new Color(System.Drawing.ColorTranslator.FromHtml("#F9DDF4"));

            PDFTableGenerator gen = new PDFTableGenerator(pdfFilePath, "Fabric Quality List", HeaderColor);

            gen.CellHeight = 100;

            gen.Columns = new List<PDFHeader>();
            gen.Columns.Add(new PDFHeader("IDENTIFACTION", iKandi.Common.ContentAlignment.Horizontal, 8));
            gen.Columns.Add(new PDFHeader("GROUP NAME", iKandi.Common.ContentAlignment.Horizontal, 5));
            gen.Columns.Add(new PDFHeader("SUBGROUP NAME", iKandi.Common.ContentAlignment.Horizontal, 7));
            gen.Columns.Add(new PDFHeader("TRADE NAME.", iKandi.Common.ContentAlignment.Horizontal, 10));
            gen.Columns.Add(new PDFHeader("SUPPLIER", iKandi.Common.ContentAlignment.Horizontal, 10));
            gen.Columns.Add(new PDFHeader("COMPOSITION", iKandi.Common.ContentAlignment.Horizontal, 10));
            gen.Columns.Add(new PDFHeader("COUNT CONSTRUCTION", iKandi.Common.ContentAlignment.Horizontal, 10));
            gen.Columns.Add(new PDFHeader("GSM", iKandi.Common.ContentAlignment.Horizontal, 4));
            gen.Columns.Add(new PDFHeader("IMAGE", iKandi.Common.ContentAlignment.Horizontal, 8));
            gen.Columns.Add(new PDFHeader("WIDTH", ContentAlignment.Horizontal, 4));
            gen.Columns.Add(new PDFHeader("WASTEAGE", iKandi.Common.ContentAlignment.Horizontal, 5));
            gen.Columns.Add(new PDFHeader("ORIGIN", iKandi.Common.ContentAlignment.Horizontal, 5));
            gen.Columns.Add(new PDFHeader("", iKandi.Common.ContentAlignment.Horizontal, 12));
            gen.Columns.Add(new PDFHeader("IS REG.", iKandi.Common.ContentAlignment.Horizontal, 4));

            gen.Rows = new List<List<PDFCell>>();

            foreach (FabricQuality fq in fabricQuality)
            {
                List<PDFCell> row = new List<PDFCell>();

                //Identification
                PDFCell cell = new PDFCell(fq.Identification, iKandi.Common.ContentAlignment.Horizontal);
                cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                row.Add(cell);

                // Group Name
                cell = new PDFCell(fq.CategoryName.ToUpper(), iKandi.Common.ContentAlignment.Horizontal);
                cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                row.Add(cell);

                // SubGroup Name
                cell = new PDFCell(fq.SubCategoryName.ToUpper(), iKandi.Common.ContentAlignment.Horizontal);
                cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                row.Add(cell);

                // Trade Name
                cell = new PDFCell(fq.TradeName.ToUpper(), iKandi.Common.ContentAlignment.Horizontal);
                cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                row.Add(cell);

                // SUPPLIER
                cell = new PDFCell(fq.SupplierName.ToUpper(), iKandi.Common.ContentAlignment.Horizontal);
                cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                row.Add(cell);

                //COMPOSITION 
                cell = new PDFCell(fq.Composition.ToUpper(), iKandi.Common.ContentAlignment.Horizontal);
                cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                row.Add(cell);

                //CC 
                cell = new PDFCell(fq.CountConstruction.ToString(), iKandi.Common.ContentAlignment.Horizontal);
                cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                row.Add(cell);

                //GSM 
                cell = new PDFCell(fq.GSM.ToString(), iKandi.Common.ContentAlignment.Horizontal);
                cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                row.Add(cell);

                // IMAGE
                string pics = string.Empty;
                for (int i = 0; i < fq.Pictures.Count; i++)
                {
                    if (pics == string.Empty)
                    {
                        if (!String.IsNullOrEmpty(fq.Pictures[i].ImageFile))
                        {
                            pics = fq.Pictures[i].ImageFile;
                            i = fq.Pictures.Count;
                        }

                    }
                }


                cell = new PDFCell(string.Empty, iKandi.Common.ContentAlignment.Horizontal);
                if (pics != string.Empty)
                {
                    cell.ImageUrl = Path.Combine(Constants.QUALITY_FOLDER_PATH, "thumb-" + pics);

                }
                row.Add(cell);

                // WIDTH
                cell = new PDFCell(fq.Width.ToString(), iKandi.Common.ContentAlignment.Horizontal);
                cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                row.Add(cell);

                //WASTEAGE
                string wastage = fq.Wastage.ToString("N0") + "%";
                cell = new PDFCell(wastage, iKandi.Common.ContentAlignment.Horizontal);
                cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                row.Add(cell);

                // ORIGIN
                string origin = ((Origin)fq.Origin).ToString();
                cell = new PDFCell(origin, iKandi.Common.ContentAlignment.Horizontal);
                cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                row.Add(cell);

                // empty 

                string empty = string.Empty;


                if (fq.Origin != 1 && fq.Origin != -1)
                {
                    empty = "PRICE FOR DYED : S- " + fq.PriceForDyedBySea.ToString() + ", A- " + fq.PriceForDyedByAir.ToString() + "\n" +
                            "Price For Printed : S- " + fq.PriceForPrintedBySea.ToString() + ", A- " + fq.PriceForPrintedByAir.ToString();
                }
                else if (fq.Origin != 2 && fq.Origin != -1)
                {
                    empty = "PRICE FOR DYED :  " + fq.PriceDyedIndian.ToString() + "\n" +
                        "Price For Printed :  " + fq.PricePrintedIndian.ToString();
                }


                cell = new PDFCell(empty, iKandi.Common.ContentAlignment.Horizontal);
                cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
                cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                cell.Padding = 5;
                row.Add(cell);

                //IS REG.
                string isReg;
                if (Convert.ToBoolean(fq.IsBiplRegistered) == true)
                {
                    isReg = "YES";
                }
                else
                {
                    isReg = "NO";
                }

                cell = new PDFCell(isReg, iKandi.Common.ContentAlignment.Horizontal);
                cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                row.Add(cell);



                gen.Rows.Add(row);
            }

            gen.GeneratePDF();
            return fileName;

        }

        public string GenerateAccessoryQualityList(int PageSize, int PageIndex, out int TotalPageCount, string SearchText, int GroupId, int SubGroupId, String PriceFrom, String PriceTo, int IsReg, int Order1, int Order2, int Order3)
        {

            if (!Directory.Exists(Constants.TEMP_FOLDER_PATH))
                Directory.CreateDirectory(Constants.TEMP_FOLDER_PATH);

            string fileName = "Accessory Quality List-" + DateTime.Now.ToString("dd MMM yyy hh-mm-ss") + ".pdf";
            // string fileName = "a" + ".pdf";
            string pdfFilePath = Path.Combine(Constants.TEMP_FOLDER_PATH, fileName);

            List<AccessoryQuality> GetAccessoryQuality = this.AccessoryQualityDataProviderInstance.GetAllAccessoryQuality(PageSize, PageIndex, out TotalPageCount, SearchText, GroupId, SubGroupId, PriceFrom, PriceTo, IsReg, Order1, Order2, Order3);
            Color HeaderColor = new Color(System.Drawing.ColorTranslator.FromHtml("#F9DDF4"));

            PDFTableGenerator gen = new PDFTableGenerator(pdfFilePath, "Accessory Summary Report", HeaderColor);

            gen.CellHeight = 100;

            gen.Columns = new List<PDFHeader>();
            gen.Columns.Add(new PDFHeader("IDENTIFACTION", iKandi.Common.ContentAlignment.Horizontal, 8));
            gen.Columns.Add(new PDFHeader("GROUP NAME", iKandi.Common.ContentAlignment.Horizontal, 7));
            gen.Columns.Add(new PDFHeader("SUBGROUP NAME", iKandi.Common.ContentAlignment.Horizontal, 8));
            gen.Columns.Add(new PDFHeader("TRADE NAME", iKandi.Common.ContentAlignment.Horizontal, 10));
            gen.Columns.Add(new PDFHeader("PRICE", iKandi.Common.ContentAlignment.Horizontal, 10));
            gen.Columns.Add(new PDFHeader("SUPPLIER NAME", iKandi.Common.ContentAlignment.Horizontal, 10));
            gen.Columns.Add(new PDFHeader("SUPPLIER REFERENCE", iKandi.Common.ContentAlignment.Horizontal, 10));
            gen.Columns.Add(new PDFHeader("BUYER NAME", iKandi.Common.ContentAlignment.Horizontal, 10));
            gen.Columns.Add(new PDFHeader("COMPOSITION", iKandi.Common.ContentAlignment.Horizontal, 10));
            gen.Columns.Add(new PDFHeader("ORIGIN", iKandi.Common.ContentAlignment.Horizontal, 5));
            gen.Columns.Add(new PDFHeader("IMAGE", iKandi.Common.ContentAlignment.Horizontal, 8));
            gen.Columns.Add(new PDFHeader("LEAD TIME(IN DAYS)", iKandi.Common.ContentAlignment.Horizontal, 8));
            gen.Columns.Add(new PDFHeader("IS REG.", iKandi.Common.ContentAlignment.Horizontal, 4));
            try
            {
                gen.Rows = new List<List<PDFCell>>();

                foreach (AccessoryQuality Aq in GetAccessoryQuality)
                {
                    List<PDFCell> row = new List<PDFCell>();

                    //Identification
                    PDFCell cell = new PDFCell(Aq.Identification, iKandi.Common.ContentAlignment.Horizontal);
                    cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                    row.Add(cell);

                    // Group Name
                    cell = new PDFCell(Aq.CategoryName.ToUpper(), iKandi.Common.ContentAlignment.Horizontal);
                    cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                    row.Add(cell);

                    // SubGroup Name
                    cell = new PDFCell(Aq.SubCategoryName.ToUpper(), iKandi.Common.ContentAlignment.Horizontal);
                    cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                    row.Add(cell);

                    // Trade Name
                    cell = new PDFCell(Aq.TradeName.ToUpper(), iKandi.Common.ContentAlignment.Horizontal);
                    cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                    row.Add(cell);
                    //Price Name
                    cell = new PDFCell(Aq.Price.ToString(), iKandi.Common.ContentAlignment.Horizontal);
                    cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                    row.Add(cell);

                    // SUPPLIER name
                    cell = new PDFCell(Aq.SupplierName.ToUpper(), iKandi.Common.ContentAlignment.Horizontal);
                    cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                    row.Add(cell);

                    // SUPPLIER refrence
                    cell = new PDFCell(Aq.SupplierReference.ToUpper(), iKandi.Common.ContentAlignment.Horizontal);
                    cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                    row.Add(cell);

                    // Company Name
                    cell = new PDFCell(Aq.Buyers[0].Client.CompanyName == null ? string.Empty : Aq.Buyers[0].Client.CompanyName.ToUpper(), iKandi.Common.ContentAlignment.Horizontal);
                    cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                    row.Add(cell);

                    //COMPOSITION 
                    cell = new PDFCell(Aq.Composition == null ? string.Empty : Aq.Composition.ToUpper(), iKandi.Common.ContentAlignment.Horizontal);
                    cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                    row.Add(cell);

                    //Origian 
                    string origin = ((Origin)Aq.Origin).ToString();
                    cell = new PDFCell(origin, iKandi.Common.ContentAlignment.Horizontal);
                    cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                    row.Add(cell);
                    // IMAGE
                    string pics = string.Empty;
                    for (int i = 0; i < Aq.Pictures.Count; i++)
                    {
                        if (pics == string.Empty)
                        {
                            if (!String.IsNullOrEmpty(Aq.Pictures[i].ImageFile))
                            {
                                pics = Aq.Pictures[i].ImageFile;
                                i = Aq.Pictures.Count;
                            }

                        }
                    }


                    cell = new PDFCell(string.Empty, iKandi.Common.ContentAlignment.Horizontal);
                    if (pics != string.Empty)
                    {
                        cell.ImageUrl = Path.Combine(Constants.QUALITY_FOLDER_PATH, "thumb-" + pics);

                    }
                    row.Add(cell);

                    //CC 
                    //cell = new PDFCell(fq.CountConstruction.ToString(), iKandi.Common.ContentAlignment.Horizontal);
                    //cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    //cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                    //row.Add(cell);

                    //GSM 
                    //cell = new PDFCell(fq.GSM.ToString(), iKandi.Common.ContentAlignment.Horizontal);
                    //cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    //cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                    //row.Add(cell);


                    //string pics = string.Empty;
                    //for (int i = 0; i < fq.Pictures.Count; i++)
                    //{
                    //    if (pics == string.Empty)
                    //    {
                    //        if (!String.IsNullOrEmpty(fq.Pictures[i].ImageFile))
                    //        {
                    //            pics = fq.Pictures[i].ImageFile;
                    //            i = fq.Pictures.Count;
                    //        }

                    //    }
                    //}

                    // IMAGE
                    //cell = new PDFCell(string.Empty, iKandi.Common.ContentAlignment.Horizontal);
                    //cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    //cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                    //row.Add(cell);
                    //if (pics != string.Empty)
                    //{
                    //    cell.ImageUrl = Path.Combine(Constants.QUALITY_FOLDER_PATH, "thumb-" + pics);

                    //}


                    // WIDTH
                    //cell = new PDFCell(fq.Width.ToString(), iKandi.Common.ContentAlignment.Horizontal);
                    //cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    //cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                    //row.Add(cell);

                    //leadtime

                    cell = new PDFCell(Aq.LeadTime.ToString(), iKandi.Common.ContentAlignment.Horizontal);
                    cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                    row.Add(cell);
                    //WASTEAGE
                    //string wastage = fq.Wastage.ToString("N0") + "%";
                    //cell = new PDFCell(wastage, iKandi.Common.ContentAlignment.Horizontal);
                    //cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    //cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                    //row.Add(cell);

                    // ORIGIN


                    // empty 




                    //if (fq.Origin != 1 && fq.Origin != -1)
                    //{
                    //    empty = "PRICE FOR DYED : S- " + fq.PriceForDyedBySea.ToString() + ", A- " + fq.PriceForDyedByAir.ToString() + "\n" +
                    //            "Price For Printed : S- " + fq.PriceForPrintedBySea.ToString() + ", A- " + fq.PriceForPrintedByAir.ToString();
                    //}
                    //else if (fq.Origin != 2 && fq.Origin != -1)
                    //{
                    //    empty = "PRICE FOR DYED :  " + fq.PriceDyedIndian.ToString() + "\n" +
                    //        "Price For Printed :  " + fq.PricePrintedIndian.ToString();
                    //}


                    //cell = new PDFCell(empty, iKandi.Common.ContentAlignment.Horizontal);
                    //cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
                    //cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                    //cell.Padding = 5;
                    //row.Add(cell);

                    //IS REG.
                    string isReg;
                    if (Convert.ToBoolean(Aq.IsBiplRegistered) == true)
                    {
                        isReg = "YES";
                    }
                    else
                    {
                        isReg = "NO";
                    }

                    cell = new PDFCell(isReg, iKandi.Common.ContentAlignment.Horizontal);
                    cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                    row.Add(cell);



                    gen.Rows.Add(row);
                }

                gen.GeneratePDF();

            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
            }
            return fileName;
        }

        public string GenerateSamplingStatusFilePDF(string SearchText, int ClientId, int SortedBy, int UserID)
        {


            if (!Directory.Exists(Constants.TEMP_FOLDER_PATH))
                Directory.CreateDirectory(Constants.TEMP_FOLDER_PATH);

            string fileName = "Sampling StatusFile -" + DateTime.Now.ToString("dd MMM yyy hh-mm-ss") + ".pdf";
            // string fileName = "a" + ".pdf";
            string pdfFilePath = Path.Combine(Constants.TEMP_FOLDER_PATH, fileName);

            List<SamplingStatus> samplingSataus = this.StyleDataProviderInstance.GetAllStyleSamplingStatus(UserID, ClientId, SortedBy, SearchText);
            Color HeaderColor = new Color(System.Drawing.ColorTranslator.FromHtml("#bdc3cf"));

            PDFTableGenerator gen = new PDFTableGenerator(pdfFilePath, "Sampling Status File", HeaderColor);

            gen.CellHeight = 200;

            gen.Columns = new List<PDFHeader>();
            gen.Columns.Add(new PDFHeader("Unit", iKandi.Common.ContentAlignment.Vertical, 3, 15));
            gen.Columns.Add(new PDFHeader("Designer Name", iKandi.Common.ContentAlignment.Vertical, 3, 15));
            gen.Columns.Add(new PDFHeader("Assigned To", iKandi.Common.ContentAlignment.Vertical, 3, 15));
            gen.Columns.Add(new PDFHeader("Client Name", iKandi.Common.ContentAlignment.Vertical, 3, 15));
            gen.Columns.Add(new PDFHeader("Dept. Name", iKandi.Common.ContentAlignment.Vertical, 3, 15));
            gen.Columns.Add(new PDFHeader("Style Number", iKandi.Common.ContentAlignment.Horizontal, 6));
            gen.Columns.Add(new PDFHeader("Style", iKandi.Common.ContentAlignment.Horizontal, 7));
            gen.Columns.Add(new PDFHeader("Fabric", ContentAlignment.Horizontal, 15));
            gen.Columns.Add(new PDFHeader("Current Update", ContentAlignment.Horizontal, 24));
            gen.Columns.Add(new PDFHeader("Remarks", iKandi.Common.ContentAlignment.Horizontal, 15));
            gen.Columns.Add(new PDFHeader("Issued On", iKandi.Common.ContentAlignment.Vertical, 2, 10));
            gen.Columns.Add(new PDFHeader("Received On", iKandi.Common.ContentAlignment.Vertical, 2, 10));
            gen.Columns.Add(new PDFHeader("Target Delivery", iKandi.Common.ContentAlignment.Vertical, 2, 10));
            gen.Columns.Add(new PDFHeader("Exp. DSPH. Dt.", iKandi.Common.ContentAlignment.Vertical, 2, 10));
            gen.Columns.Add(new PDFHeader("Courriered On", iKandi.Common.ContentAlignment.Vertical, 2, 10));
            gen.Columns.Add(new PDFHeader("Counter Complete", iKandi.Common.ContentAlignment.Vertical, 2, 10));
            gen.Columns.Add(new PDFHeader("Priority", iKandi.Common.ContentAlignment.Vertical, 2, 10));
            gen.Columns.Add(new PDFHeader("Status", iKandi.Common.ContentAlignment.Vertical, 2, 10));


            gen.Rows = new List<List<PDFCell>>();

            foreach (SamplingStatus ss in samplingSataus)
            {
                List<PDFCell> row = new List<PDFCell>();

                //For Unit
                PDFCell cell = new PDFCell(ss.FactoryName, iKandi.Common.ContentAlignment.Vertical);
                cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                row.Add(cell);

                // For Designer Name
                cell = new PDFCell(ss.DesignerName, iKandi.Common.ContentAlignment.Vertical);
                cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                row.Add(cell);

                // for Assigned To
                string name = string.Empty;
                int samplingManagerId = ss.SamplingMerchandisingManagerID;

                List<User> users = this.UserDataProviderInstance.GetUsersByDesignation((int)Designation.BIPL_Merchandising_SamplingMerchant);
                foreach (User user in users)
                {
                    if (samplingManagerId == user.UserID)
                    {
                        name = name + user.FullName + "\n";
                    }
                }

                cell = new PDFCell(name, iKandi.Common.ContentAlignment.Vertical);
                cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                row.Add(cell);

                // FOR Client NAME
                cell = new PDFCell(ss.ClientName, iKandi.Common.ContentAlignment.Vertical);
                cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                row.Add(cell);

                // FOR department Name
                cell = new PDFCell(ss.DepartmentName, iKandi.Common.ContentAlignment.Vertical);
                cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                row.Add(cell);

                // for Style
                cell = new PDFCell(ss.StyleNumber, iKandi.Common.ContentAlignment.Horizontal);
                cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                cell.FontSize = 16;
                cell.FontColor = "#0000FF";
                row.Add(cell);

                string ImagePath = ss.SketchURL;
                cell = new PDFCell(string.Empty, iKandi.Common.ContentAlignment.Horizontal);
                if (ImagePath != string.Empty)
                {
                    cell.ImageUrl = Path.Combine(Constants.STYLE_FOLDER_PATH, "thumb-" + ImagePath);
                }
                row.Add(cell);

                // for Fabric
                string fabric = ss.Fabric;
                int indexOf = fabric.LastIndexOf("**");
                if (indexOf > -1)
                    indexOf += 2;
                else
                    indexOf = 0;
                fabric = fabric.Substring(indexOf);
                fabric = fabric.Replace("#", "");
                fabric = fabric.Replace("@", "");
                cell = new PDFCell(fabric.ToString().Replace(",", "\n"), iKandi.Common.ContentAlignment.Horizontal);
                cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                row.Add(cell);

                // Current Update
                string currentUpdate = GetStyleCurrentUpdateData(ss);
                cell = new PDFCell(currentUpdate, iKandi.Common.ContentAlignment.Horizontal);
                cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
                cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                cell.FontSize = 16;
                row.Add(cell);

                // for remarks
                string remarks = ss.SamplingStatusRemarks;
                cell = new PDFCell(remarks.ToString().Replace("<br/>", "\n"), iKandi.Common.ContentAlignment.Horizontal);
                cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
                cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                cell.Padding = 5;
                row.Add(cell);

                //Issued On
                string issuedOn = ((ss.IssuedOn) == DateTime.MinValue) ? String.Empty : ss.IssuedOn.ToString("dd MMM yy (ddd)");
                cell = new PDFCell(issuedOn, iKandi.Common.ContentAlignment.Vertical);
                cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                row.Add(cell);

                //Received Date
                string receivedDate = ((ss.ReceivedOn) == DateTime.MinValue) ? String.Empty : ss.ReceivedOn.ToString("dd MMM yy (ddd)");
                cell = new PDFCell(receivedDate, iKandi.Common.ContentAlignment.Vertical);
                cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                row.Add(cell);

                //Target Delivery
                string tgtDelivery = ((ss.ETA) == DateTime.MinValue) ? String.Empty : ss.ETA.ToString("dd MMM yy (ddd)");
                cell = new PDFCell(tgtDelivery, iKandi.Common.ContentAlignment.Vertical);
                cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                row.Add(cell);

                //Exp. Dsph. Dt
                string expDsphDt = ((ss.MerchandiserDispatchDate) == DateTime.MinValue) ? String.Empty : ss.MerchandiserDispatchDate.ToString("dd MMM yy (ddd)");
                cell = new PDFCell(expDsphDt, iKandi.Common.ContentAlignment.Vertical);
                cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                row.Add(cell);

                //Courriered On
                string courrieredOn = ((ss.SentToiKandiOn) == DateTime.MinValue) ? String.Empty : ss.SentToiKandiOn.ToString("dd MMM yy (ddd)");
                cell = new PDFCell(courrieredOn, iKandi.Common.ContentAlignment.Vertical);
                cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                row.Add(cell);

                //Counter complete
                string counterComplete = ((ss.CounterComplete) > 0) ? "Yes" : "No";
                cell = new PDFCell(counterComplete, iKandi.Common.ContentAlignment.Vertical);
                cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                row.Add(cell);

                // FOR priority
                string bgColor = "#FFFFFF";
                if (ss.Priority.ToUpper().Trim() == "URGENT")
                {
                    bgColor = "#FF3300";
                }
                else if (ss.Priority.ToUpper().Trim() == "HIGH")
                {
                    bgColor = "#FD9903";
                }
                else if (ss.Priority.ToUpper().Trim() == "MEDIUM")
                {
                    bgColor = "#FFFF00";
                }
                else if (ss.Priority.ToUpper().Trim() == "LOW")
                {
                    bgColor = "#01CC01";
                }

                cell = new PDFCell(ss.Priority, iKandi.Common.ContentAlignment.Vertical);
                cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                cell.BackGroundColor = bgColor;
                row.Add(cell);

                // for Status
                cell = new PDFCell(ss.Status, iKandi.Common.ContentAlignment.Vertical);
                cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                cell.BackGroundColor = Constants.GetStatusModeColor(ss.StatusModeID);
                row.Add(cell);

                gen.Rows.Add(row);
            }

            gen.GeneratePDF();
            return fileName;

        }

        private void UpdateColumnDataBinding(bool chk, string txt, StyleCurrentUpdate objStyleCurrentUpdate)
        {
            if (objStyleCurrentUpdate == null)
            {
                chk = false;
            }
            else
            {
                if (objStyleCurrentUpdate.IsChecked == true)
                {
                    chk = true;
                    txt = objStyleCurrentUpdate.Date == DateTime.MinValue ? string.Empty : objStyleCurrentUpdate.Date.ToString("dd MMM yy (ddd)");
                }
                else
                {
                    chk = false;
                    txt = string.Empty;
                }
            }
        }

        #region GenerateSamplingStatusFilePDF1
        public string GenerateSamplingStatusFilePDF1(string SearchText, int ClientId, int SortedBy, int UserID, string SeasonName, string IsOwnerLoggedIn)
        {

            if (!Directory.Exists(Constants.TEMP_FOLDER_PATH))
                Directory.CreateDirectory(Constants.TEMP_FOLDER_PATH);

            string fileName = "Sampling StatusFile -" + DateTime.Now.ToString("dd MMM yyy hh-mm-ss") + ".pdf";
            // string fileName = "a" + ".pdf";
            string pdfFilePath = Path.Combine(Constants.TEMP_FOLDER_PATH, fileName);

            List<SamplingStatus> samplingSataus = this.StyleDataProviderInstance.GetAllStyleSamplingStatusDAL_Pdf(
                UserID,
                ClientId,
                SortedBy,
                SearchText,
                SeasonName,
                IsOwnerLoggedIn);
            Color HeaderColor = new Color(System.Drawing.ColorTranslator.FromHtml("#bdc3cf"));

            PDFTableGenerator gen = new PDFTableGenerator(pdfFilePath, "Sampling Status File", HeaderColor);
            gen.CellBorderColor = "#DEDEDE";
            gen.CellHeight = 200;
            gen.PaddingTop = 5;
            gen.PaddingBottom = 5;
            gen.HeaderTableHeaderHeight = 50;

            Color bcolor = new Color(System.Drawing.ColorTranslator.FromHtml("#DEDEDE"));

            gen.Columns = new List<PDFHeader>();
            gen.Columns.Add(new PDFHeader("ASSIGNMENTS", iKandi.Common.ContentAlignment.Horizontal, 25));
            gen.Columns.Add(new PDFHeader("STYLE", iKandi.Common.ContentAlignment.Horizontal, 10));
            gen.Columns.Add(new PDFHeader("FABRIC", iKandi.Common.ContentAlignment.Horizontal, 15));
            gen.Columns.Add(new PDFHeader("TRACKING", iKandi.Common.ContentAlignment.Horizontal, 20));
            gen.Columns.Add(new PDFHeader("METERAGE IN HOUSE", iKandi.Common.ContentAlignment.Horizontal, 15));
            //gen.Columns.Add(new PDFHeader("FABRIC REMARKS", iKandi.Common.ContentAlignment.Horizontal, 15));
            gen.Columns.Add(new PDFHeader("SAMPLING STATUS", iKandi.Common.ContentAlignment.Horizontal, 30));
            //gen.Columns.Add(new PDFHeader("ISSUE", ContentAlignment.Horizontal, 15));
            gen.Columns.Add(new PDFHeader("REMARKS", ContentAlignment.Horizontal, 24));
            gen.Columns.Add(new PDFHeader("WORKFLOW", ContentAlignment.Horizontal, 24));

            gen.Rows = new List<List<PDFCell>>();

            int cellcount = 0;
            string bckColor;
            foreach (SamplingStatus ss in samplingSataus)
            {
                bckColor = cellcount % 2 == 0 ? "#FFFFFF" : "#F7F7F7";
                cellcount++;
                List<PDFCell> row = new List<PDFCell>();
                Phrase ph;
                PdfPCell pdfCell;
                PdfPTable pt;
                PDFCell cell;
                //For ASSIGNMENTS
                {
                    string assignment = ss.Assignment;
                    pt = new PdfPTable(2);
                    assignment = assignment.ToUpper().Replace("&POUND;", "£");
                    string[] assignments = assignment.Split('|');
                    for (int ii = 0; ii < assignments.Length; ii += 2)
                    {

                        if (string.IsNullOrEmpty(assignments[ii].Trim()))
                            continue;
                        ph = new Phrase();
                        ph.Add(new Chunk(assignments[ii],
                                         new Font(Font.HELVETICA, 11f, Font.BOLD, Color.BLACK)));

                        pt.AddCell(new PdfPCell(ph) { Border = Rectangle.NO_BORDER });
                        ph = new Phrase();
                        ph.Add(new Chunk(" : " + assignments[ii + 1],
                                         new Font(Font.HELVETICA, 11f, Font.NORMAL, Color.BLUE)));
                        pt.AddCell(new PdfPCell(ph) { Border = Rectangle.NO_BORDER });
                    }
                    cell = new PDFCell(pt);
                    cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
                    cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                    row.Add(cell);
                }

                // For STYLE
                {
                    pt = new PdfPTable(1);
                    pt.AddCell(
                        new PdfPCell(new Phrase(ss.StyleNumber.ToUpper(),
                                                new Font(Font.HELVETICA, 11f, Font.BOLD, Color.BLUE))) { Border = Rectangle.NO_BORDER, HorizontalAlignment = Element.ALIGN_CENTER });
                    //string imgPath = Environment.CurrentDirectory + "/iKandi.Web/Uploads/Style/thumb-" + ss.SketchURL;
                    string imgPath = Path.Combine(Constants.STYLE_FOLDER_PATH, "thumb-" + ss.SketchURL);
                    if (File.Exists(imgPath))
                    {
                        try
                        {
                            Image jpeg = Image.GetInstance(imgPath);
                            jpeg.ScaleAbsolute(80f, 100f);
                            jpeg.Alignment = Image.ALIGN_MIDDLE | Image.TEXTWRAP;
                            pt.AddCell(new PdfPCell(new Phrase(new Chunk(jpeg, 0, 0))) { Border = Rectangle.NO_BORDER, HorizontalAlignment = Element.ALIGN_CENTER });
                        }
                        catch (Exception ex)
                        {
                            //eat
                            System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                            System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                        }
                    }
                    string seasonstory = ss.AllSeasonStory;
                    if (!string.IsNullOrEmpty(seasonstory.Trim()))
                        seasonstory = seasonstory.Replace("|", "\n");
                    pt.AddCell(
                        new PdfPCell(new Phrase(seasonstory.ToUpper(),
                                                new Font(Font.HELVETICA, 11f, Font.NORMAL, Color.BLUE))) { Border = Rectangle.NO_BORDER, HorizontalAlignment = Element.ALIGN_CENTER });
                    cell = new PDFCell(pt);
                    cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                    row.Add(cell);
                }

                //FABRIC
                {
                    string fabric = ss.NewFabric;
                    if (string.IsNullOrEmpty(fabric.Trim()))
                        row.Add(new PDFCell(""));
                    else
                    {
                        pt = new PdfPTable(1);
                        string[] strs = fabric.Split('&');
                        for (int ii = 0; ii < strs.Length; ii++)
                        {
                            if (string.IsNullOrEmpty(strs[ii].Trim()))
                                continue;
                            string[] text = strs[ii].Split('|');
                            if (text.Length < 1)
                                continue;
                            ph = new Phrase();
                            if (text.Length > 0)
                            {
                                ph.Add(new Chunk(text[0] + " ", new Font(Font.HELVETICA, 8f, Font.BOLD, Color.BLUE)));
                            }
                            if (text.Length > 1)
                            {
                                ph.Add(
                                    new Chunk(text[1], new Font(Font.HELVETICA, 8f, Font.BOLD, Color.BLACK)).
                                        SetBackground(Color.YELLOW));
                            }
                            if (text.Length > 2)
                            {
                                ph.Add(new Chunk(" " + text[2], new Font(Font.HELVETICA, 8f, Font.BOLD, Color.BLACK)));
                            }
                            pt.AddCell(new PdfPCell(ph)
                            {
                                BorderColor = bcolor,
                                Padding = 1f,
                                FixedHeight = 50,
                                VerticalAlignment = Element.ALIGN_MIDDLE
                            });
                        }
                        cell = new PDFCell(pt);
                        cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
                        cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                        row.Add(cell);
                    }
                }

                //TRACKING
                {
                    string tracking = ss.Tracking;
                    if (string.IsNullOrEmpty(tracking.Trim()))
                        row.Add(new PDFCell(""));
                    else
                    {
                        pt = new PdfPTable(1);
                        //tracking.Replace()
                        string[] strs = tracking.Split('~');

                        for (int ii = 0; ii < strs.Length; ii++)
                        {
                            if (string.IsNullOrEmpty(strs[ii].Trim()))
                                continue;
                            PdfPTable ppt = new PdfPTable(2);
                            string[] text = strs[ii].Split('|');
                            if (text.Length == 8)
                            {
                                for (int jj = 0; jj < 8; jj++)
                                {
                                    if (jj % 2 == 0)
                                        ppt.AddCell(
                                            new PdfPCell(new Phrase(text[jj], new Font(Font.HELVETICA, 8f, Font.BOLD,
                                                                                       new Color(
                                                                                           System.Drawing.
                                                                                               ColorTranslator.
                                                                                               FromHtml(
                                                                                                   "#3C3C3C"))))) { BorderColor = bcolor });
                                    else if (jj == 7)
                                    {
                                        string[] txts = text[jj].Split('_');
                                        Color clr = null;
                                        if (txts.Length > 1)
                                        {
                                            switch (txts[1].Trim())
                                            {
                                                case "GREEN":
                                                    clr = Color.GREEN;
                                                    break;
                                                case "YELLOW":
                                                    clr = Color.YELLOW;
                                                    break;
                                                case "BLUE":
                                                    clr = Color.BLUE;
                                                    break;
                                                case "ORANGE":
                                                    clr = Color.ORANGE;
                                                    break;
                                                case "RED":
                                                    clr = Color.RED;
                                                    break;
                                            }

                                        }
                                        else
                                            clr = null;
                                        ppt.AddCell(
                                            new PdfPCell(new Phrase(txts[0], new Font(Font.HELVETICA, 8f, Font.BOLD,
                                                                                      new Color(
                                                                                          System.Drawing.
                                                                                              ColorTranslator.
                                                                                              FromHtml(
                                                                                                  "#3C3C3C")))))
                                            {
                                                BorderColor = bcolor,
                                                BackgroundColor = clr
                                            });
                                    }
                                    else
                                        ppt.AddCell(
                                            new PdfPCell(new Phrase(text[jj], new Font(Font.HELVETICA, 8f, Font.NORMAL,
                                                                                       new Color(
                                                                                           System.Drawing.
                                                                                               ColorTranslator.
                                                                                               FromHtml(
                                                                                                   "#0000FF"))))) { BorderColor = bcolor });

                                }
                                pt.AddCell(new PdfPCell(ppt) { BorderColor = bcolor, Padding = 1f, FixedHeight = 50 });
                            }
                        }
                        cell = new PDFCell(pt);
                        cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
                        cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                        row.Add(cell);
                    }
                }

                //METERAGE IN HOUSE
                {
                    pt = new PdfPTable(1);
                    string[] strMeterageInHouse = ss.MeterageInHouse.Split(',');
                    string[] sstr = { "S/O AVAILABLE", "Meterage Available", "Metrage In House" };
                    for (int ii = 0; ii < strMeterageInHouse.Length; ii++)
                    {
                        bool chk1 = false;
                        bool chk2 = false;
                        string txt = "";
                        if (strMeterageInHouse[ii].IndexOf("#") != -1)
                        {
                            if (strMeterageInHouse[ii].Split('#')[0] != "" ||
                                strMeterageInHouse[ii].Split('#')[0] != " ")
                            {
                                if (Convert.ToInt32(strMeterageInHouse[ii].Split('#')[0]) == 1)
                                {
                                    chk1 = true;
                                }
                                if (Convert.ToInt32(strMeterageInHouse[ii].Split('#')[0]) == 12)
                                {
                                    chk2 = true;
                                    chk1 = true;
                                }
                            }
                        }
                        if (strMeterageInHouse[ii].IndexOf("$") != -1)
                        {
                            if (strMeterageInHouse.Length > ii && strMeterageInHouse[ii].Split('$')[0] != " ")
                            {
                                if (Convert.ToDouble(strMeterageInHouse[ii].Split('$')[1]) > 0 &&
                                    Convert.ToDouble(strMeterageInHouse[ii].Split('$')[1]) < 5)
                                {
                                    chk1 = true;
                                    txt = strMeterageInHouse[ii].Split('$')[0];
                                }
                                if (Convert.ToDouble(strMeterageInHouse[ii].Split('$')[0]) >= 5)
                                {
                                    chk2 = true;
                                    txt = strMeterageInHouse[ii].Split('$')[0];
                                }
                                if (Convert.ToDouble(strMeterageInHouse[ii].Split('$')[0]) >= 6)
                                {
                                    chk2 = true;
                                    chk1 = true;
                                    txt = strMeterageInHouse[ii].Split('$')[0];
                                }
                                if (Convert.ToDouble(strMeterageInHouse[ii].Split('$')[0]) == 0)
                                {
                                    txt = strMeterageInHouse[ii].Split('$')[0];
                                }
                            }
                        }
                        PdfPTable ppt = new PdfPTable(2);
                        for (int jj = 0; jj < 3; jj++)
                        {
                            ppt.AddCell(
                                new PdfPCell(new Phrase(sstr[jj],
                                                        new Font(Font.HELVETICA, 8f, Font.NORMAL,
                                                                 new Color(
                                                                     System.Drawing.ColorTranslator.FromHtml("#3C3C3C"))))) { BorderColor = bcolor });
                            string str = "";
                            switch (jj)
                            {
                                case 0:
                                    str = chk1 == true ? "Yes" : "No";
                                    break;
                                case 1:
                                    str = chk2 == true ? "Yes" : "No";
                                    break;
                                case 2:
                                    str = txt;
                                    break;
                            }
                            ppt.AddCell(
                                new PdfPCell(new Phrase(str,
                                                        new Font(Font.HELVETICA, 8f, Font.NORMAL,
                                                                 new Color(
                                                                     System.Drawing.ColorTranslator.FromHtml("#0000FF"))))) { BorderColor = bcolor });
                        }
                        pt.AddCell(new PdfPCell(ppt) { BorderColor = bcolor, Padding = 5f, FixedHeight = 50 });
                    }
                    cell = new PDFCell(pt);
                    cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                    row.Add(cell);
                }


                // for SAMPLING STATUS
                {
                    pt = new PdfPTable(3);
                    pt.SetWidths(new int[] { 60, 10, 30 });
                    //  if (ss.CurrentUpdate.Count > 0)
                    // {
                    string[] strs = new string[4]
                                        {
                                            "FABRIC SAMPLING PROGRAM ISSUED : ", "ISSUED FOR PATTERN MAKING : ",
                                            "FABRIC ISSUED FOR CUTTING : ", "ON MACHINE/FINISHING/READY FOR DISPATCH : "
                                        };
                    for (int ii = 0; ii < 4; ii++)
                    {
                        bool flag = false;
                        string txt = "";
                        if (ss.CurrentUpdate.Count > ii)
                        {
                            StyleCurrentUpdate objStyleCurrentUpdate =
                                ss.CurrentUpdate.Find(
                                    delegate(StyleCurrentUpdate s)
                                    {
                                        return (s.Type == (StyleCurrentUpdates)(ii + 1) &&
                                                s.StyleId == ss.StyleID);
                                    });
                            if (objStyleCurrentUpdate != null)
                            {
                                if (objStyleCurrentUpdate.IsChecked == true)
                                {
                                    flag = true;
                                    txt = objStyleCurrentUpdate.Date == DateTime.MinValue
                                              ? string.Empty
                                              : objStyleCurrentUpdate.Date.ToString("dd MMM yy (ddd)");
                                }
                            }
                        }
                        pdfCell =
                            new PdfPCell(new Phrase(strs[ii], new Font(Font.HELVETICA, 8f, Font.NORMAL, Color.BLACK))) { BorderColor = bcolor };
                        //    pdfCell.Width = 10f;
                        pt.AddCell(pdfCell);
                        pdfCell = new PdfPCell(new Phrase(flag == false ? "No" : "Yes",
                                                          new Font(Font.HELVETICA, 8f, Font.NORMAL, Color.BLACK))) { BorderColor = bcolor };
                        //  pdfCell.Width = 2f;
                        pt.AddCell(pdfCell);
                        pdfCell = new PdfPCell(new Phrase(txt,
                                                          new Font(Font.HELVETICA, 8f, Font.NORMAL, Color.BLUE))) { BorderColor = bcolor };
                        //pdfCell.Width = 4f;
                        pt.AddCell(pdfCell);
                    }
                    //  }

                    cell = new PDFCell(pt);
                    cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                    row.Add(cell);
                }

                // for REMARKS
                {
                    ph = new Phrase();
                    ph.Add(new Chunk("ISSUE\n\n", new Font(Font.HELVETICA, 11f, Font.NORMAL, Color.BLACK)));
                    ph.Add(new Chunk(ss.LastIssue + "\n\n\n\n\n",
                                     new Font(Font.HELVETICA, 11f, Font.NORMAL, Color.BLACK)));
                    ph.Add(new Chunk("RESOLUTION\n\n", new Font(Font.HELVETICA, 11f, Font.NORMAL, Color.BLACK)));
                    ph.Add(new Chunk(ss.OwnerLastResolution, new Font(Font.HELVETICA, 11f, Font.NORMAL, Color.BLACK)));
                    cell = new PDFCell(new PdfPCell(ph) { BorderColor = bcolor });
                    cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
                    cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_TOP;
                    row.Add(cell);
                }

                // for WORKFLOW
                {
                    pt = new PdfPTable(2);
                    pt.AddCell(
                        new PdfPCell(new Phrase("Target Delivery", new Font(Font.HELVETICA, 11f, Font.BOLD, Color.BLACK))) { BorderColor = bcolor });
                    pt.AddCell(
                        new PdfPCell(
                            new Phrase(
                                (Convert.ToDateTime(ss.ETA) == DateTime.MinValue)
                                    ? ""
                                    : Convert.ToDateTime(ss.ETA).ToString("dd MMM yy (ddd)"),
                                new Font(Font.HELVETICA, 11f, Font.NORMAL, Color.BLUE))) { BorderColor = bcolor });
                    pt.AddCell(
                        new PdfPCell(new Phrase("EXPTD. DISP", new Font(Font.HELVETICA, 11f, Font.BOLD, Color.BLACK))) { BorderColor = bcolor });
                    pt.AddCell(
                        new PdfPCell(
                            new Phrase(
                                (Convert.ToDateTime(ss.MerchandiserDispatchDate) == DateTime.MinValue)
                                    ? ""
                                    : Convert.ToDateTime(ss.MerchandiserDispatchDate).ToString("dd MMM yy (ddd)"),
                                new Font(Font.HELVETICA, 11f, Font.NORMAL, Color.BLUE))) { BorderColor = bcolor });
                    pt.AddCell(
                        new PdfPCell(new Phrase("Couriered On", new Font(Font.HELVETICA, 11f, Font.BOLD, Color.BLACK))) { BorderColor = bcolor });
                    pt.AddCell(
                        new PdfPCell(
                            new Phrase(
                                (Convert.ToDateTime(ss.SentToiKandiOn) == DateTime.MinValue)
                                    ? ""
                                    : Convert.ToDateTime(ss.SentToiKandiOn).ToString("dd MMM yy (ddd)"),
                                new Font(Font.HELVETICA, 11f, Font.NORMAL, Color.BLUE))) { BorderColor = bcolor });
                    pt.AddCell(
                        new PdfPCell(new Phrase("Counter Complete",
                                                new Font(Font.HELVETICA, 11f, Font.BOLD, Color.BLACK))) { BorderColor = bcolor });
                    pt.AddCell(
                        new PdfPCell(
                            new Phrase(
                                ss.CounterComplete == 1 ? "Yes" : "NO",
                                new Font(Font.HELVETICA, 11f, Font.NORMAL, Color.BLUE))) { BorderColor = bcolor });
                    pt.AddCell(
                        new PdfPCell(new Phrase("Priority", new Font(Font.HELVETICA, 11f, Font.BOLD, Color.BLACK))) { BorderColor = bcolor });
                    pt.AddCell(
                        new PdfPCell(new Phrase(ss.Priority, new Font(Font.HELVETICA, 11f, Font.NORMAL, Color.BLUE))) { BackgroundColor = Color.RED, BorderColor = bcolor });
                    pt.AddCell(new PdfPCell(new Phrase("Status", new Font(Font.HELVETICA, 11f, Font.BOLD, Color.BLACK))) { BorderColor = bcolor });
                    pt.AddCell(
                        new PdfPCell(new Phrase(ss.Status, new Font(Font.HELVETICA, 11f, Font.NORMAL, Color.BLUE)))
                        {
                            BackgroundColor = new Color(System.Drawing.ColorTranslator.FromHtml("#7ECFED")),
                            BorderColor = bcolor
                        });
                    cell = new PDFCell(pt);
                    cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                    row.Add(cell);
                }
                foreach (PDFCell pc in row)
                {
                    pc.BackGroundColor = bckColor;
                }
                gen.Rows.Add(row);
            }

            gen.GeneratePDF();
            return fileName;

        }

        #endregion

        public string GenerateShowroomCostingPDF(List<iKandi.Common.ShowroomCosting> showroomStyles, string Title)
        {
            if (!Directory.Exists(Constants.TEMP_FOLDER_PATH))
                Directory.CreateDirectory(Constants.TEMP_FOLDER_PATH);

            string fileName = "Showroom Costing -" + DateTime.Now.ToString("dd MMM yyy hh-mm") + ".pdf";

            string pdfFilePath = Path.Combine(Constants.TEMP_FOLDER_PATH, fileName);

            Color HeaderColor = new Color(System.Drawing.ColorTranslator.FromHtml("#F9DDF4"));

            PDFTableGenerator gen = new PDFTableGenerator(pdfFilePath, "", HeaderColor);

            gen.IsLandScape = false;

            gen.HeaderTableColumns = new List<PDFHeader>();
            gen.HeaderTableRows = new List<List<PDFCell>>();
            List<PDFCell> tableRow = new List<PDFCell>();

            PDFHeader topHeaderCell = new PDFHeader(string.Empty, iKandi.Common.ContentAlignment.Horizontal);
            topHeaderCell.Width = 10;
            gen.HeaderTableColumns.Add(topHeaderCell);

            topHeaderCell = new PDFHeader(string.Empty, iKandi.Common.ContentAlignment.Horizontal);
            topHeaderCell.Width = 60;
            gen.HeaderTableColumns.Add(topHeaderCell);


            PDFCell headercell = new PDFCell(string.Empty, iKandi.Common.ContentAlignment.Horizontal);
            headercell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
            headercell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
            headercell.ImageUrl = AppDomain.CurrentDomain.BaseDirectory + "/app_themes/ikandi/images/boutique_logo.jpg";
            tableRow.Add(headercell);

            headercell = new PDFCell(Title, iKandi.Common.ContentAlignment.Horizontal);
            headercell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
            headercell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
            headercell.FontColor = "#0000ff";
            headercell.FontSize = 24;
            tableRow.Add(headercell);

            gen.HeaderTableRows.Add(tableRow);
            gen.IsHeaderTable = true;


            //gen.CellHeight = 200;

            gen.Columns = new List<PDFHeader>();
            //gen.Columns.Add(new PDFHeader("", iKandi.Common.ContentAlignment.Horizontal, 14));
            //gen.Columns.Add(new PDFHeader("", iKandi.Common.ContentAlignment.Horizontal, 14));
            //gen.Columns.Add(new PDFHeader("", iKandi.Common.ContentAlignment.Horizontal, 14));
            //gen.Columns.Add(new PDFHeader("", iKandi.Common.ContentAlignment.Horizontal, 14));
            //gen.Columns.Add(new PDFHeader("", iKandi.Common.ContentAlignment.Horizontal, 14));
            //gen.Columns.Add(new PDFHeader("", iKandi.Common.ContentAlignment.Horizontal, 14));
            //gen.Columns.Add(new PDFHeader("", iKandi.Common.ContentAlignment.Horizontal, 16));

            //foreach (PDFHeader hdr in gen.Columns)
            //{
            //    hdr.Height = 0;
            //}

            gen.Rows = new List<List<PDFCell>>();

            int count = (int)Math.Ceiling((double)showroomStyles.Count / 7);


            for (int j = 0; j < count; j++)
            {
                List<PDFCell> row1 = new List<PDFCell>();
                List<PDFCell> row2 = new List<PDFCell>();
                List<PDFCell> row3 = new List<PDFCell>();
                List<PDFCell> row4 = new List<PDFCell>();
                List<PDFCell> row5 = new List<PDFCell>();
                List<PDFCell> row6 = new List<PDFCell>();

                for (int k = j * 7; k < (j * 7 + 7) && k < showroomStyles.Count; k++)
                {
                    ShowroomCosting sc = showroomStyles[k];
                    // For Image
                    string ImagePath = sc.StyleFrontImageURL;
                    PDFCell cell = new PDFCell(string.Empty, iKandi.Common.ContentAlignment.Horizontal);

                    cell.ImageWidth = 150f;

                    if (ImagePath != string.Empty)
                    {
                        cell.ImageUrl = Path.Combine(Constants.STYLE_FOLDER_PATH, ImagePath);
                    }
                    row1.Add(cell);

                    // For Style Number
                    cell = new PDFCell(sc.StyleNumber, iKandi.Common.ContentAlignment.Horizontal);
                    cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                    cell.FontSize = 17;
                    cell.FontFamily = "trebuchet ms";
                    row2.Add(cell);

                    // For Fabric
                    cell = new PDFCell(sc.Fabric.Replace("$$", "\n").Replace(",", ""), iKandi.Common.ContentAlignment.Horizontal);
                    cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
                    cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                    cell.FontColor = "#0000ff";
                    cell.FontSize = 7;
                    cell.FontFamily = "trebuchet ms";
                    row3.Add(cell);

                    // For Price Quoted
                    cell = new PDFCell(Constants.GetCurrencySign(sc.Currency.ToString()) + sc.PriceQuoted.ToString("0.00"), iKandi.Common.ContentAlignment.Horizontal);
                    cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                    cell.FontSize = 16;
                    cell.BackGroundColor = "#01cc01";
                    cell.FontFamily = "trebuchet ms";
                    row4.Add(cell);

                    // For Minimums
                    cell = new PDFCell("MOQ:" + sc.Minimums.ToString("N0") + " Units", iKandi.Common.ContentAlignment.Horizontal);
                    cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                    cell.FontSize = 12;
                    cell.FontFamily = "trebuchet ms";
                    row5.Add(cell);

                    // For Comments
                    cell = new PDFCell("Comments", iKandi.Common.ContentAlignment.Horizontal);
                    cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                    cell.FontColor = "#f1f1f1";
                    cell.FontSize = 15;
                    cell.Height = 80f;
                    cell.FontFamily = "trebuchet ms";
                    row6.Add(cell);
                }

                if (j == (count - 1))
                {
                    for (int l = 0; l < ((j * 7 + 7) - showroomStyles.Count); l++)
                    {
                        PDFCell cell = new PDFCell(string.Empty, iKandi.Common.ContentAlignment.Horizontal);
                        row1.Add(cell);

                        cell = new PDFCell(string.Empty, iKandi.Common.ContentAlignment.Horizontal);
                        row2.Add(cell);

                        cell = new PDFCell(string.Empty, iKandi.Common.ContentAlignment.Horizontal);
                        row3.Add(cell);

                        cell = new PDFCell(string.Empty, iKandi.Common.ContentAlignment.Horizontal);
                        row4.Add(cell);

                        cell = new PDFCell(string.Empty, iKandi.Common.ContentAlignment.Horizontal);
                        row5.Add(cell);

                        cell = new PDFCell(string.Empty, iKandi.Common.ContentAlignment.Horizontal);
                        row6.Add(cell);
                    }
                }

                gen.Rows.Add(row1);
                gen.Rows.Add(row2);
                gen.Rows.Add(row3);
                gen.Rows.Add(row4);
                gen.Rows.Add(row5);
                gen.Rows.Add(row6);

            }

            /*
            foreach (ShowroomCosting sc in showroomStyles)
            {
                List<PDFCell> row = new List<PDFCell>();

                //For Serial Number
                PDFCell cell = new PDFCell((i++).ToString(), iKandi.Common.ContentAlignment.Horizontal);
                cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                row.Add(cell);

                // For Style Number
                cell = new PDFCell(sc.StyleNumber, iKandi.Common.ContentAlignment.Horizontal);
                cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                row.Add(cell);

                // For Image
                string ImagePath = sc.StyleFrontImageURL;
                cell = new PDFCell(string.Empty, iKandi.Common.ContentAlignment.Horizontal);
                if (ImagePath != string.Empty)
                {
                    cell.ImageUrl = Path.Combine(Constants.STYLE_FOLDER_PATH, "thumb-" + ImagePath);
                }
                row.Add(cell);

                // For Fabric
                cell = new PDFCell(sc.Fabric.Replace("$$", "\n"), iKandi.Common.ContentAlignment.Horizontal);
                cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                row.Add(cell);

                // For Price Quoted
                cell = new PDFCell(sc.PriceQuoted.ToString("0.00"), iKandi.Common.ContentAlignment.Horizontal);
                cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                row.Add(cell);

                // For Minimums
                cell = new PDFCell(sc.Minimums.ToString(), iKandi.Common.ContentAlignment.Horizontal);
                cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                row.Add(cell);

                // For Comments
                cell = new PDFCell(string.Empty, iKandi.Common.ContentAlignment.Horizontal);
                cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                row.Add(cell);

                gen.Rows.Add(row);
            }
             
             */

            gen.GeneratePDF();

            return fileName;

        }


        public string GenerateShowroomPDF(List<iKandi.Common.ShowroomCosting> showroomStyles, List<iKandi.Common.Print> showroomPrints, string Title, int Logo, int Moq, int Price)
        {
            // System.Diagnostics.Debugger.Break();

            if (!Directory.Exists(Constants.TEMP_FOLDER_PATH))
                Directory.CreateDirectory(Constants.TEMP_FOLDER_PATH);

            string fileName = "Virtual Showroom -" + DateTime.Now.ToString("dd MMM yyy hh-mm") + ".pdf";

            string pdfFilePath = Path.Combine(Constants.TEMP_FOLDER_PATH, fileName);

            Color HeaderColor = new Color(System.Drawing.ColorTranslator.FromHtml("#F9DDF4"));

            PDFTableGenerator gen = new PDFTableGenerator(pdfFilePath, "", HeaderColor);

            gen.CellBorderColor = "#cccccc";

            //gen.HideMainTableCellBorder = true;

            gen.IsLandScape = false;

            gen.HeaderTableColumns = new List<PDFHeader>();
            gen.HeaderTableRows = new List<List<PDFCell>>();
            List<PDFCell> tableRow = new List<PDFCell>();

            PDFHeader topHeaderCell = new PDFHeader(string.Empty, iKandi.Common.ContentAlignment.Horizontal);
            topHeaderCell.Width = 10;
            gen.HeaderTableColumns.Add(topHeaderCell);

            topHeaderCell = new PDFHeader(string.Empty, iKandi.Common.ContentAlignment.Horizontal);
            topHeaderCell.Width = 60;
            gen.HeaderTableColumns.Add(topHeaderCell);


            PDFCell headercell = new PDFCell(string.Empty, iKandi.Common.ContentAlignment.Horizontal);
            headercell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
            headercell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;

            //headercell.ImageUrl = AppDomain.CurrentDomain.BaseDirectory + "/app_themes/ikandi/images/boutique_logo.jpg";
            //Edit By Ashish
            if (Logo == 1)
            {
                headercell.ImageUrl = AppDomain.CurrentDomain.BaseDirectory + "/app_themes/ikandi/images/boutique_logo.jpg";
            }
            if (Logo == 2)
            {
                headercell.ImageUrl = AppDomain.CurrentDomain.BaseDirectory + "/app_themes/ikandi/images/ikandi.gif";
            }
            //
            tableRow.Add(headercell);

            headercell = new PDFCell(Title, iKandi.Common.ContentAlignment.Horizontal);
            headercell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
            headercell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
            headercell.FontColor = "#0000ff";
            headercell.FontSize = 24;
            tableRow.Add(headercell);

            gen.HeaderTableRows.Add(tableRow);
            gen.IsHeaderTable = true;

            //gen.CellHeight = 200;

            gen.Columns = new List<PDFHeader>();

            gen.Rows = new List<List<PDFCell>>();

            int count = (int)Math.Ceiling((double)showroomStyles.Count / 7);


            for (int j = 0; j < count; j++)
            {
                List<PDFCell> row1 = new List<PDFCell>();
                List<PDFCell> row2 = new List<PDFCell>();
                List<PDFCell> row3 = new List<PDFCell>();
                List<PDFCell> row4 = new List<PDFCell>();
                List<PDFCell> row5 = new List<PDFCell>();
                List<PDFCell> row6 = new List<PDFCell>();

                for (int k = j * 7; k < (j * 7 + 7) && k < showroomStyles.Count; k++)
                {
                    ShowroomCosting sc = showroomStyles[k];
                    // For Image
                    string ImagePath = sc.StyleFrontImageURL;
                    PDFCell cell = new PDFCell(string.Empty, iKandi.Common.ContentAlignment.Horizontal);

                    cell.ImageWidth = 150f;

                    if (ImagePath != string.Empty)
                    {
                        cell.ImageUrl = Path.Combine(Constants.STYLE_FOLDER_PATH, ImagePath);
                    }

                    cell.HideBorderBottom = true;

                    row1.Add(cell);


                    // For Fabric
                    cell = new PDFCell(sc.Fabric.Replace("$$", "\n").Replace(",", ""), iKandi.Common.ContentAlignment.Horizontal);
                    cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                    cell.FontColor = "#000000";
                    cell.FontColor = "#666666";
                    cell.FontSize = 7;
                    cell.FontFamily = "trebuchet ms";

                    cell.HideBorderBottom = true;
                    cell.HideBorderTop = true;

                    row2.Add(cell);

                    //Edit By Ashish
                    // For Price Quoted
                    //cell = new PDFCell(Constants.GetCurrencySign(sc.Currency.ToString()) + sc.PriceQuoted.ToString("0.00"), iKandi.Common.ContentAlignment.Horizontal);
                    if (Price == 1)
                    {
                        cell = new PDFCell(Constants.GetCurrencySign(sc.Currency.ToString()) + sc.PriceQuoted.ToString("0.00"), iKandi.Common.ContentAlignment.Horizontal);
                    }
                    else
                    {
                        cell = new PDFCell("", iKandi.Common.ContentAlignment.Horizontal);
                    }
                    cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                    cell.FontColor = "#000000";
                    cell.FontSize = 12;
                    //cell.BackGroundColor = "#01cc01";
                    cell.FontFamily = "trebuchet ms";

                    cell.HideBorderBottom = true;
                    cell.HideBorderTop = true;

                    row3.Add(cell);

                    //Edit By Ashish
                    // For Minimums
                    //cell = new PDFCell("MOQ:" + sc.Minimums.ToString("N0") + " Units", iKandi.Common.ContentAlignment.Horizontal);
                    if (Moq == 1)
                    {
                        cell = new PDFCell("MOQ:" + sc.Minimums.ToString("N0") + " Units", iKandi.Common.ContentAlignment.Horizontal);
                    }
                    else
                    {
                        cell = new PDFCell("", iKandi.Common.ContentAlignment.Horizontal);
                    }
                    cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                    cell.FontColor = "#666666";
                    cell.FontSize = 12;
                    cell.FontFamily = "trebuchet ms";

                    cell.HideBorderBottom = true;
                    cell.HideBorderTop = true;

                    row4.Add(cell);

                    // For Style Number
                    cell = new PDFCell(sc.StyleNumber, iKandi.Common.ContentAlignment.Horizontal);
                    cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                    cell.FontColor = "#000000";
                    cell.FontSize = 12;
                    cell.FontFamily = "trebuchet ms";

                    cell.HideBorderBottom = true;
                    cell.HideBorderTop = true;

                    row5.Add(cell);

                    // For Comments string contains comment txt //US
                    cell = new PDFCell("", iKandi.Common.ContentAlignment.Horizontal);
                    cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                    cell.FontColor = "#f1f1f1";
                    cell.FontSize = 15;
                    cell.Height = 80f;
                    cell.FontFamily = "trebuchet ms";

                    cell.HideBorderTop = true;

                    row6.Add(cell);
                }

                if (j == (count - 1))
                {
                    for (int l = 0; l < ((j * 7 + 7) - showroomStyles.Count); l++)
                    {
                        PDFCell cell = new PDFCell(string.Empty, iKandi.Common.ContentAlignment.Horizontal);
                        cell.HideBorderBottom = true;
                        row1.Add(cell);

                        cell = new PDFCell(string.Empty, iKandi.Common.ContentAlignment.Horizontal);
                        cell.HideBorderBottom = true;
                        cell.HideBorderTop = true;
                        row2.Add(cell);

                        cell = new PDFCell(string.Empty, iKandi.Common.ContentAlignment.Horizontal);
                        cell.HideBorderBottom = true;
                        cell.HideBorderTop = true;
                        row3.Add(cell);

                        cell = new PDFCell(string.Empty, iKandi.Common.ContentAlignment.Horizontal);
                        cell.HideBorderBottom = true;
                        cell.HideBorderTop = true;
                        row4.Add(cell);

                        cell = new PDFCell(string.Empty, iKandi.Common.ContentAlignment.Horizontal);
                        cell.HideBorderBottom = true;
                        cell.HideBorderTop = true;
                        row5.Add(cell);

                        cell = new PDFCell(string.Empty, iKandi.Common.ContentAlignment.Horizontal);
                        cell.HideBorderTop = true;
                        row6.Add(cell);
                    }
                }

                gen.Rows.Add(row1);
                gen.Rows.Add(row2);
                gen.Rows.Add(row3);
                gen.Rows.Add(row4);
                gen.Rows.Add(row5);
                gen.Rows.Add(row6);

            }

            //List<PDFCell> blankRow = new List<PDFCell>();
            //PDFCell blankCell = new PDFCell("\n\n\n");
            //blankCell.FontSize = 15;
            //blankCell.Height = 80f;
            //blankRow.Add(blankCell);
            //blankRow.Add(blankCell);
            //blankRow.Add(blankCell);
            //blankRow.Add(blankCell);
            //blankRow.Add(blankCell);
            //blankRow.Add(blankCell);
            //blankRow.Add(blankCell);

            // gen.Rows.Add(blankRow);

            count = (int)Math.Ceiling((double)showroomPrints.Count / 7);

            for (int j = 0; j < count; j++)
            {
                List<PDFCell> row1 = new List<PDFCell>();
                List<PDFCell> row2 = new List<PDFCell>();
                List<PDFCell> row3 = new List<PDFCell>();
                List<PDFCell> row4 = new List<PDFCell>();

                for (int k = j * 7; k < (j * 7 + 7) && k < showroomPrints.Count; k++)
                {
                    Print print = showroomPrints[k];
                    // For Image
                    string ImagePath = print.ImageUrl;
                    PDFCell cell = new PDFCell(string.Empty, iKandi.Common.ContentAlignment.Horizontal);

                    cell.ImageWidth = 150f;

                    if (ImagePath != string.Empty)
                    {
                        cell.ImageUrl = Path.Combine(Constants.PRINT_FOLDER_PATH, ImagePath);
                    }
                    cell.HideBorderBottom = true;

                    row1.Add(cell);

                    // For Print Number
                    cell = new PDFCell("PRD " + print.PrintNumber, iKandi.Common.ContentAlignment.Horizontal);
                    cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                    cell.FontSize = 12;
                    cell.FontColor = "#666666";
                    cell.FontFamily = "trebuchet ms";
                    cell.HideBorderBottom = true;
                    cell.HideBorderTop = true;
                    row2.Add(cell);

                    // For Descrition
                    cell = new PDFCell(print.Description, iKandi.Common.ContentAlignment.Horizontal);
                    cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                    cell.FontColor = "#000000";
                    cell.FontSize = 7;
                    cell.FontFamily = "trebuchet ms";
                    cell.HideBorderBottom = true;
                    cell.HideBorderTop = true;
                    row3.Add(cell);

                    // For Sold Status
                    cell = new PDFCell(print.Status.ToString(), iKandi.Common.ContentAlignment.Horizontal);
                    cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                    cell.FontSize = 12;
                    cell.FontColor = "#666666";
                    cell.FontFamily = "trebuchet ms";
                    cell.HideBorderTop = true;
                    row4.Add(cell);
                }

                if (j == (count - 1))
                {
                    for (int l = 0; l < ((j * 7 + 7) - showroomPrints.Count); l++)
                    {
                        PDFCell cell = new PDFCell(string.Empty, iKandi.Common.ContentAlignment.Horizontal);
                        cell.HideBorderBottom = true;
                        row1.Add(cell);

                        cell = new PDFCell(string.Empty, iKandi.Common.ContentAlignment.Horizontal);
                        cell.HideBorderBottom = true;
                        cell.HideBorderTop = true;
                        row2.Add(cell);

                        cell = new PDFCell(string.Empty, iKandi.Common.ContentAlignment.Horizontal);
                        cell.HideBorderBottom = true;
                        cell.HideBorderTop = true;
                        row3.Add(cell);

                        cell = new PDFCell(string.Empty, iKandi.Common.ContentAlignment.Horizontal);
                        cell.HideBorderTop = true;
                        row4.Add(cell);
                    }
                }

                gen.Rows.Add(row1);
                gen.Rows.Add(row2);
                gen.Rows.Add(row3);
                gen.Rows.Add(row4);

            }


            gen.GeneratePDF();

            return pdfFilePath;

        }


        public string GeneratePriceVariationPDF(int Type)
        {

            if (!Directory.Exists(Constants.TEMP_FOLDER_PATH))
                Directory.CreateDirectory(Constants.TEMP_FOLDER_PATH);
            string fileName = string.Empty;
            string pdfFilePath = string.Empty;
            string title = string.Empty;

            if (Type == 1)
            {
                fileName = "Combined Price Variations -" + DateTime.Now.ToString("dd MMM yyy hh-mm-ss") + ".pdf";
                pdfFilePath = Path.Combine(Constants.TEMP_FOLDER_PATH, fileName);
                title = "COMBINED PRICE VARIATIONS";
            }
            else if (Type == 2)
            {
                fileName = "Bipl Price Variations -" + DateTime.Now.ToString("dd MMM yyy hh-mm-ss") + ".pdf";
                pdfFilePath = Path.Combine(Constants.TEMP_FOLDER_PATH, fileName);
                title = "BIPL PRICE VARIATIONS";
            }

            else if (Type == 3)
            {
                fileName = "iKandi Price Variations -" + DateTime.Now.ToString("dd MMM yyy hh-mm-ss") + ".pdf";
                pdfFilePath = Path.Combine(Constants.TEMP_FOLDER_PATH, fileName);
                title = "IKANDI PRICE VARIATIONS";
            }


            DataSet ds = this.ReportControllerInstance.GetPriceVariationReport(Type);

            if (ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
                return string.Empty;

            Color HeaderColor = new Color(System.Drawing.ColorTranslator.FromHtml("#F9DDF4"));

            PDFTableGenerator gen = new PDFTableGenerator(pdfFilePath, title, HeaderColor);

            gen.CellHeight = 200;

            gen.Columns = new List<PDFHeader>();
            gen.Columns.Add(new PDFHeader("Order Date", iKandi.Common.ContentAlignment.Vertical, 2, 10));
            gen.Columns.Add(new PDFHeader("Serial Number", iKandi.Common.ContentAlignment.Vertical, 2, 10));
            gen.Columns.Add(new PDFHeader("Buyer", iKandi.Common.ContentAlignment.Vertical, 2, 10));
            gen.Columns.Add(new PDFHeader("Dept.", iKandi.Common.ContentAlignment.Vertical, 2, 10));
            gen.Columns.Add(new PDFHeader("Style No.", iKandi.Common.ContentAlignment.Horizontal, 8));
            gen.Columns.Add(new PDFHeader("Style", iKandi.Common.ContentAlignment.Horizontal, 8));
            gen.Columns.Add(new PDFHeader("Line No", iKandi.Common.ContentAlignment.Vertical, 2, 10));
            gen.Columns.Add(new PDFHeader("Contract No", iKandi.Common.ContentAlignment.Vertical, 2, 10));
            gen.Columns.Add(new PDFHeader("Quantity", iKandi.Common.ContentAlignment.Horizontal, 5));
            gen.Columns.Add(new PDFHeader("Mode", iKandi.Common.ContentAlignment.Vertical, 2, 10));
            gen.Columns.Add(new PDFHeader("ExFactory", ContentAlignment.Vertical, 2, 10));
            gen.Columns.Add(new PDFHeader("Status", iKandi.Common.ContentAlignment.Vertical, 2, 10));
            if (Type == 1 || Type == 2)
            {
                gen.Columns.Add(new PDFHeader("BIPL Price Quoted", iKandi.Common.ContentAlignment.Horizontal, 5));
                gen.Columns.Add(new PDFHeader("BIPL Price Agreed", iKandi.Common.ContentAlignment.Horizontal, 5));
            }
            if (Type == 1 || Type == 3)
            {
                gen.Columns.Add(new PDFHeader("iKandi Price Quoted", iKandi.Common.ContentAlignment.Horizontal, 5));
                gen.Columns.Add(new PDFHeader("iKandi Price Agreed", iKandi.Common.ContentAlignment.Horizontal, 5));
            }
            gen.Columns.Add(new PDFHeader("Merchant Remarks", iKandi.Common.ContentAlignment.Horizontal, 19));
            gen.Columns.Add(new PDFHeader("Ikandi Remarks", iKandi.Common.ContentAlignment.Horizontal, 19));

            gen.Rows = new List<List<PDFCell>>();

            foreach (DataRow dataRow in ds.Tables[0].Rows)
            {
                List<PDFCell> row = new List<PDFCell>();

                //Order Date
                PDFCell cell = new PDFCell((dataRow["OrderDate"] == DBNull.Value) ? string.Empty : Convert.ToDateTime(dataRow["OrderDate"]).ToString("dd MMM yy (ddd)"), iKandi.Common.ContentAlignment.Vertical);
                cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                row.Add(cell);

                // Serial Number
                cell = new PDFCell((dataRow["SerialNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(dataRow["SerialNumber"]), iKandi.Common.ContentAlignment.Vertical);
                cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                row.Add(cell);

                // Buyer
                cell = new PDFCell((dataRow["CompanyName"] == DBNull.Value) ? string.Empty : Convert.ToString(dataRow["CompanyName"]), iKandi.Common.ContentAlignment.Vertical);
                cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                row.Add(cell);

                // Dept
                cell = new PDFCell((dataRow["DepartmentName"] == DBNull.Value) ? string.Empty : Convert.ToString(dataRow["DepartmentName"]), iKandi.Common.ContentAlignment.Vertical);
                cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                row.Add(cell);

                // Style
                cell = new PDFCell((dataRow["StyleNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(dataRow["StyleNumber"]), iKandi.Common.ContentAlignment.Horizontal);
                cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                cell.FontSize = 16;
                cell.FontColor = "#0000FF";
                row.Add(cell);

                string ImagePath = (dataRow["SampleImageURL1"] == DBNull.Value) ? string.Empty : Convert.ToString(dataRow["SampleImageURL1"]);
                cell = new PDFCell(string.Empty, iKandi.Common.ContentAlignment.Horizontal);
                if (ImagePath != string.Empty)
                {
                    cell.ImageUrl = Path.Combine(Constants.STYLE_FOLDER_PATH, "thumb-" + ImagePath);
                }
                row.Add(cell);

                // Line No.
                cell = new PDFCell((dataRow["LineItemNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(dataRow["LineItemNumber"]), iKandi.Common.ContentAlignment.Vertical);
                cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                row.Add(cell);

                // Contract
                cell = new PDFCell((dataRow["ContractNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(dataRow["ContractNumber"]), iKandi.Common.ContentAlignment.Vertical);
                cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                row.Add(cell);

                // Quantity
                cell = new PDFCell((dataRow["Quantity"] == DBNull.Value) ? string.Empty : Convert.ToInt32(dataRow["Quantity"]).ToString("N0"), iKandi.Common.ContentAlignment.Horizontal);
                cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                row.Add(cell);

                // Mode
                cell = new PDFCell((dataRow["Mode"] == DBNull.Value) ? string.Empty : CommonHelper.GetOrderDeliveryMode(Convert.ToInt32(dataRow["Mode"])), iKandi.Common.ContentAlignment.Vertical);
                cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                row.Add(cell);

                // Ex-Factory
                cell = new PDFCell((dataRow["ExFactory"] == DBNull.Value) ? string.Empty : Convert.ToDateTime(dataRow["ExFactory"]).ToString("dd MMM yy (ddd)"), iKandi.Common.ContentAlignment.Vertical);
                cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                row.Add(cell);

                // Status
                cell = new PDFCell((dataRow["Status"] == DBNull.Value) ? string.Empty : Convert.ToString(dataRow["Status"]), iKandi.Common.ContentAlignment.Vertical);
                cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                row.Add(cell);

                int sign = -1;
                string currencySign = "£";
                if (dataRow["ConvertTo"] != DBNull.Value && dataRow["ConvertTo"].ToString().Trim() != string.Empty)
                {
                    sign = Convert.ToInt32(dataRow["ConvertTo"]);
                }
                currencySign = iKandi.Common.Constants.GetCurrencySymbalByCurrencyType(sign);


                if (Type == 1 || Type == 2)
                {

                    //Bipl Price Quoted
                    cell = new PDFCell((dataRow["BIPLPriceQuoted"] == DBNull.Value || Math.Round(Convert.ToDouble(dataRow["BIPLPriceQuoted"]), 2) == 0) ? string.Empty : (currencySign + Convert.ToDouble(dataRow["BIPLPriceQuoted"]).ToString("#.00")), iKandi.Common.ContentAlignment.Horizontal);
                    cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                    row.Add(cell);

                    //BIPL Price Agreed
                    cell = new PDFCell((dataRow["BIPLPriceAgreed"] == DBNull.Value || Math.Round(Convert.ToDouble(dataRow["BIPLPriceAgreed"]), 2) == 0) ? string.Empty : (currencySign + Convert.ToDouble(dataRow["BIPLPriceAgreed"]).ToString("#.00")), iKandi.Common.ContentAlignment.Horizontal);
                    cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                    row.Add(cell);
                }

                if (Type == 1 || Type == 3)
                {
                    // iKandi Price Quoted
                    cell = new PDFCell((dataRow["iKandiPriceQuoted"] == DBNull.Value || Math.Round(Convert.ToDouble(dataRow["iKandiPriceQuoted"]), 2) == 0) ? string.Empty : (currencySign + Convert.ToDouble(dataRow["iKandiPriceQuoted"]).ToString("#.00")), iKandi.Common.ContentAlignment.Horizontal);
                    cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                    row.Add(cell);

                    // iKandi Price agreed
                    cell = new PDFCell((dataRow["iKandiPriceAgreed"] == DBNull.Value || Math.Round(Convert.ToDouble(dataRow["iKandiPriceAgreed"]), 2) == 0) ? string.Empty : (currencySign + Convert.ToDouble(dataRow["iKandiPriceAgreed"]).ToString("#.00")), iKandi.Common.ContentAlignment.Horizontal);
                    cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                    row.Add(cell);
                }

                // Merchant Remarks
                string merchantRemarks = "";

                if (dataRow["MerchantNotes"] != DBNull.Value)
                {
                    if (dataRow["MerchantNotes"].ToString().LastIndexOf("$$") > -1)
                        merchantRemarks = dataRow["MerchantNotes"].ToString().Substring(dataRow["MerchantNotes"].ToString().LastIndexOf("$$") + 2);
                    else
                        merchantRemarks = dataRow["MerchantNotes"].ToString();
                }

                cell = new PDFCell(merchantRemarks, iKandi.Common.ContentAlignment.Horizontal);
                cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
                cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                row.Add(cell);

                // ikandi Remarks
                string ikandiRemarks = "";

                if (dataRow["IkandiRemarks"] != DBNull.Value)
                {
                    if (dataRow["IkandiRemarks"].ToString().LastIndexOf("$$") > -1)
                        ikandiRemarks = dataRow["IkandiRemarks"].ToString().Substring(dataRow["IkandiRemarks"].ToString().LastIndexOf("$$") + 2);
                    else
                        ikandiRemarks = dataRow["IkandiRemarks"].ToString();
                }

                cell = new PDFCell(ikandiRemarks, iKandi.Common.ContentAlignment.Horizontal);
                cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
                cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                row.Add(cell);


                gen.Rows.Add(row);
            }

            gen.GeneratePDF();
            return fileName;

        }


        public bool GenerateSampleDalayedOrToBeDispatchEmailPDF(String pdfFilePath, string fileName)
        {

            string title = "Samples delayed or to be dispatched this week".ToUpper();

            List<SamplingStatus> samplingSataus = this.StyleDataProviderInstance.GetSampleDalayedOrToBeDispatchEmail();
            Color HeaderColor = new Color(System.Drawing.ColorTranslator.FromHtml("#F9DDF4"));

            PDFTableGenerator gen = new PDFTableGenerator(pdfFilePath, title, HeaderColor);

            gen.CellHeight = 200;

            gen.Columns = new List<PDFHeader>();
            gen.Columns.Add(new PDFHeader("Unit", iKandi.Common.ContentAlignment.Vertical, 3, 15));
            gen.Columns.Add(new PDFHeader("Designer Name", iKandi.Common.ContentAlignment.Vertical, 3, 15));
            gen.Columns.Add(new PDFHeader("Assigned To", iKandi.Common.ContentAlignment.Vertical, 3, 15));
            gen.Columns.Add(new PDFHeader("Client Name", iKandi.Common.ContentAlignment.Vertical, 3, 15));
            gen.Columns.Add(new PDFHeader("Dept. Name", iKandi.Common.ContentAlignment.Vertical, 3, 15));
            gen.Columns.Add(new PDFHeader("Style Number", iKandi.Common.ContentAlignment.Horizontal, 6));
            gen.Columns.Add(new PDFHeader("Style", iKandi.Common.ContentAlignment.Horizontal, 7));
            gen.Columns.Add(new PDFHeader("Fabric", ContentAlignment.Horizontal, 15));
            gen.Columns.Add(new PDFHeader("Current Update", ContentAlignment.Horizontal, 24));
            gen.Columns.Add(new PDFHeader("Remarks", iKandi.Common.ContentAlignment.Horizontal, 15));
            gen.Columns.Add(new PDFHeader("Issued On", iKandi.Common.ContentAlignment.Vertical, 2, 10));
            gen.Columns.Add(new PDFHeader("Received On", iKandi.Common.ContentAlignment.Vertical, 2, 10));
            gen.Columns.Add(new PDFHeader("Target Delivery", iKandi.Common.ContentAlignment.Vertical, 2, 10));
            gen.Columns.Add(new PDFHeader("Exp. DSPH. Dt.", iKandi.Common.ContentAlignment.Vertical, 2, 10));
            gen.Columns.Add(new PDFHeader("Courriered On", iKandi.Common.ContentAlignment.Vertical, 2, 10));
            gen.Columns.Add(new PDFHeader("Counter Complete", iKandi.Common.ContentAlignment.Vertical, 2, 10));
            gen.Columns.Add(new PDFHeader("Priority", iKandi.Common.ContentAlignment.Vertical, 2, 10));
            gen.Columns.Add(new PDFHeader("Status", iKandi.Common.ContentAlignment.Vertical, 2, 10));


            gen.Rows = new List<List<PDFCell>>();

            foreach (SamplingStatus ss in samplingSataus)
            {
                List<PDFCell> row = new List<PDFCell>();

                //For Unit
                PDFCell cell = new PDFCell(ss.FactoryName, iKandi.Common.ContentAlignment.Vertical);
                cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                row.Add(cell);

                // For Designer Name
                cell = new PDFCell(ss.DesignerName, iKandi.Common.ContentAlignment.Vertical);
                cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                row.Add(cell);

                // for Assigned To
                string name = string.Empty;
                int samplingManagerId = ss.SamplingMerchandisingManagerID;

                List<User> users = this.UserDataProviderInstance.GetUsersByDesignation((int)Designation.BIPL_Merchandising_SamplingMerchant);
                foreach (User user in users)
                {
                    if (samplingManagerId == user.UserID)
                    {
                        name = name + user.FullName + "\n";
                    }
                }

                cell = new PDFCell(name, iKandi.Common.ContentAlignment.Vertical);
                cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                row.Add(cell);

                // FOR Client NAME
                cell = new PDFCell(ss.ClientName, iKandi.Common.ContentAlignment.Vertical);
                cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                row.Add(cell);

                // FOR department Name
                cell = new PDFCell(ss.DepartmentName, iKandi.Common.ContentAlignment.Vertical);
                cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                row.Add(cell);

                // for Style
                cell = new PDFCell(ss.StyleNumber, iKandi.Common.ContentAlignment.Horizontal);
                cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                cell.FontSize = 16;
                cell.FontColor = "#0000FF";
                row.Add(cell);

                string ImagePath = ss.SketchURL;
                cell = new PDFCell(string.Empty, iKandi.Common.ContentAlignment.Horizontal);
                if (ImagePath != string.Empty)
                {
                    cell.ImageUrl = Path.Combine(Constants.STYLE_FOLDER_PATH, "thumb-" + ImagePath);
                }
                row.Add(cell);

                // for Fabric
                string fabric = ss.Fabric;
                cell = new PDFCell(fabric.ToString().Replace(",", "\n"), iKandi.Common.ContentAlignment.Horizontal);
                cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                row.Add(cell);

                // Current Update
                string currentUpdate = GetStyleCurrentUpdateData(ss);
                cell = new PDFCell(currentUpdate, iKandi.Common.ContentAlignment.Horizontal);
                cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
                cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                cell.FontSize = 16;
                row.Add(cell);

                // for remarks
                string remarks = ss.SamplingStatusRemarks;
                cell = new PDFCell(remarks.ToString().Replace("<br/>", "\n"), iKandi.Common.ContentAlignment.Horizontal);
                cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
                cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                cell.Padding = 5;
                row.Add(cell);

                //Issued On
                string issuedOn = ((ss.IssuedOn) == DateTime.MinValue) ? String.Empty : ss.IssuedOn.ToString("dd MMM yy (ddd)");
                cell = new PDFCell(issuedOn, iKandi.Common.ContentAlignment.Vertical);
                cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                row.Add(cell);

                //Received Date
                string receivedDate = ((ss.ReceivedOn) == DateTime.MinValue) ? String.Empty : ss.ReceivedOn.ToString("dd MMM yy (ddd)");
                cell = new PDFCell(receivedDate, iKandi.Common.ContentAlignment.Vertical);
                cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                row.Add(cell);

                //Target Delivery
                string tgtDelivery = ((ss.ETA) == DateTime.MinValue) ? String.Empty : ss.ETA.ToString("dd MMM yy (ddd)");
                cell = new PDFCell(tgtDelivery, iKandi.Common.ContentAlignment.Vertical);
                cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                row.Add(cell);

                //Exp. Dsph. Dt
                string expDsphDt = ((ss.MerchandiserDispatchDate) == DateTime.MinValue) ? String.Empty : ss.MerchandiserDispatchDate.ToString("dd MMM yy (ddd)");
                cell = new PDFCell(expDsphDt, iKandi.Common.ContentAlignment.Vertical);
                cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                row.Add(cell);

                //Courriered On
                string courrieredOn = ((ss.SentToiKandiOn) == DateTime.MinValue) ? String.Empty : ss.SentToiKandiOn.ToString("dd MMM yy (ddd)");
                cell = new PDFCell(courrieredOn, iKandi.Common.ContentAlignment.Vertical);
                cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                row.Add(cell);

                //Counter complete
                string counterComplete = ((ss.CounterComplete) > 0) ? "Yes" : "No";
                cell = new PDFCell(counterComplete, iKandi.Common.ContentAlignment.Vertical);
                cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                row.Add(cell);

                // FOR priority
                string bgColor = "#FFFFFF";
                if (ss.Priority.ToUpper().Trim() == "URGENT")
                {
                    bgColor = "#FF3300";
                }
                else if (ss.Priority.ToUpper().Trim() == "HIGH")
                {
                    bgColor = "#FD9903";
                }
                else if (ss.Priority.ToUpper().Trim() == "MEDIUM")
                {
                    bgColor = "#FFFF00";
                }
                else if (ss.Priority.ToUpper().Trim() == "LOW")
                {
                    bgColor = "#01CC01";
                }

                cell = new PDFCell(ss.Priority, iKandi.Common.ContentAlignment.Vertical);
                cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                cell.BackGroundColor = bgColor;
                row.Add(cell);

                // for Status
                cell = new PDFCell(ss.Status, iKandi.Common.ContentAlignment.Vertical);
                cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                cell.BackGroundColor = Constants.GetStatusModeColor(ss.StatusModeID);
                row.Add(cell);

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


        public string GenerateStyleDigitalInfo(string iClientId, int iDateType, DateTime iFromDate, DateTime iToDate)
        {
            DataTable dt = this.ReportDataProviderInstance.GetStyleDigitalInfo(iClientId, iDateType, iFromDate, iToDate);

            if (!Directory.Exists(Constants.TEMP_FOLDER_PATH))
                Directory.CreateDirectory(Constants.TEMP_FOLDER_PATH);
            string fileName = string.Empty;
            string pdfFilePath = string.Empty;
            string title = string.Empty;
            string fab1 = string.Empty;

            fileName = "Style Digital information -" + DateTime.Now.ToString("dd MMM yyy hh-mm-ss") + ".pdf";
            pdfFilePath = Path.Combine(Constants.TEMP_FOLDER_PATH, fileName);
            title = "STYLE DIGITAL INFORMATION";

            if (dt.Rows.Count == 0)
            {
                return "";
            }

            Color HeaderColor = new Color(System.Drawing.ColorTranslator.FromHtml("#F9DDF4"));
            PDFTableGenerator gen = new PDFTableGenerator(pdfFilePath, "STYLE DIGITAL INFORMATION", HeaderColor);
            gen.CellHeight = 225;

            gen.Columns = new List<PDFHeader>();
            gen.Columns.Add(new PDFHeader("Style Number", iKandi.Common.ContentAlignment.Horizontal, 4));
            gen.Columns.Add(new PDFHeader("Buyer", iKandi.Common.ContentAlignment.Horizontal, 4));
            gen.Columns.Add(new PDFHeader("Front Digital", iKandi.Common.ContentAlignment.Horizontal, 6));
            gen.Columns.Add(new PDFHeader("Back Digital", iKandi.Common.ContentAlignment.Horizontal, 6));
            gen.Columns.Add(new PDFHeader("Print Digital", iKandi.Common.ContentAlignment.Horizontal, 6));
            gen.Columns.Add(new PDFHeader("Fabric Name", iKandi.Common.ContentAlignment.Horizontal, 6));
            gen.Columns.Add(new PDFHeader("DC Date", iKandi.Common.ContentAlignment.Horizontal, 4));

            gen.Rows = new List<List<PDFCell>>();

            for (int i = 0; i <= dt.Rows.Count - 1; i++)
            {
                List<PDFCell> row = new List<PDFCell>();

                PDFCell cell = new PDFCell(Convert.ToString(dt.Rows[i]["StyleNumber"]), iKandi.Common.ContentAlignment.Horizontal);
                cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                row.Add(cell);

                cell = new PDFCell(Convert.ToString(dt.Rows[i]["CompanyName"]), iKandi.Common.ContentAlignment.Horizontal);
                cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                row.Add(cell);

                string ImagePath = Convert.ToString(dt.Rows[i]["FrontDigit"]);
                cell = new PDFCell(string.Empty, iKandi.Common.ContentAlignment.Horizontal);
                if (ImagePath != string.Empty)
                {
                    cell.ImageUrl = Path.Combine(Constants.STYLE_FOLDER_PATH, ImagePath);
                }
                row.Add(cell);


                ImagePath = Convert.ToString(dt.Rows[i]["BackDigit"]);
                cell = new PDFCell(string.Empty, iKandi.Common.ContentAlignment.Horizontal);
                if (ImagePath != string.Empty)
                {
                    cell.ImageUrl = Path.Combine(Constants.STYLE_FOLDER_PATH, ImagePath);
                }
                row.Add(cell);


                ImagePath = Convert.ToString(dt.Rows[i]["Print1"]);
                cell = new PDFCell(string.Empty, iKandi.Common.ContentAlignment.Horizontal);
                if (ImagePath != string.Empty)
                {
                    cell.ImageUrl = Path.Combine(Constants.PRINT_FOLDER_PATH, ImagePath);
                }
                else
                {
                    ImagePath = Convert.ToString(dt.Rows[i]["Print2"]);
                    cell = new PDFCell(string.Empty, iKandi.Common.ContentAlignment.Horizontal);
                    if (ImagePath != string.Empty)
                    {
                        cell.ImageUrl = Path.Combine(Constants.PRINT_FOLDER_PATH, ImagePath);
                    }
                    else
                    {
                        ImagePath = Convert.ToString(dt.Rows[i]["Print3"]);
                        cell = new PDFCell(string.Empty, iKandi.Common.ContentAlignment.Horizontal);
                        if (ImagePath != string.Empty)
                        {
                            cell.ImageUrl = Path.Combine(Constants.PRINT_FOLDER_PATH, ImagePath);
                        }
                        else
                        {
                            ImagePath = Convert.ToString(dt.Rows[i]["Print4"]);
                            cell = new PDFCell(string.Empty, iKandi.Common.ContentAlignment.Horizontal);
                            if (ImagePath != string.Empty)
                            {
                                cell.ImageUrl = Path.Combine(Constants.PRINT_FOLDER_PATH, ImagePath);
                            }
                        }

                    }
                }
                row.Add(cell);

                cell = new PDFCell(Convert.ToString(dt.Rows[i]["FabricName"]), iKandi.Common.ContentAlignment.Horizontal);
                cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                row.Add(cell);


                cell = new PDFCell(Convert.ToString(dt.Rows[i]["DC"]), iKandi.Common.ContentAlignment.Horizontal);
                cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                row.Add(cell);

                gen.Rows.Add(row);

            }
            gen.GeneratePDF();
            return pdfFilePath;



            /*
            string Fabric1 = orderdetail.Fabric1;
            string Fabric1Detail = orderdetail.Fabric1Details.ToString().Trim();
            int Fabric1Percent = orderdetail.ParentOrder.FabricInhouseHistory.Fabric1Percent;

            if (Fabric1Detail != "")
            {
                Fabric1 = Fabric1 + " : " + Fabric1Detail;
            }

            if (Fabric1Percent != 0)
            {
                Fabric1 = Fabric1 + " (" + Fabric1Percent + "%)";
            }

            string Fabric2 = orderdetail.Fabric2;
            string Fabric2Detail = orderdetail.Fabric2Details.ToString().Trim();
            int Fabric2Percent = orderdetail.ParentOrder.FabricInhouseHistory.Fabric2Percent;

            if (Fabric2Detail != "")
            {
                Fabric2 = Fabric2 + " : " + Fabric2Detail;
            }

            if (Fabric2Percent != 0)
            {
                Fabric2 = Fabric2 + " (" + Fabric2Percent + "%)";
            }

            string Fabric3 = orderdetail.Fabric3;
            string Fabric3Detail = orderdetail.Fabric3Details.ToString().Trim();
            int Fabric3Percent = orderdetail.ParentOrder.FabricInhouseHistory.Fabric3Percent;

            if (Fabric3Detail != "")
            {
                Fabric3 = Fabric3 + " : " + Fabric3Detail;
            }

            if (Fabric3Percent != 0)
            {
                Fabric3 = Fabric3 + " (" + Fabric3Percent + "%)";
            }

            string Fabric4 = orderdetail.Fabric4;
            string Fabric4Detail = orderdetail.Fabric4Details.ToString().Trim();
            int Fabric4Percent = orderdetail.ParentOrder.FabricInhouseHistory.Fabric4Percent;

            if (Fabric4Detail != "")
            {
                Fabric4 = Fabric4 + " : " + Fabric4Detail;
            }

            if (Fabric4Percent != 0)
            {
                Fabric4 = Fabric4 + " (" + Fabric4Percent + "%)";
            }

            cell = new PDFCell(Fabric1 + "\n\n" + Fabric2 + "\n\n" + Fabric3 + "\n\n" + Fabric4);
            cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
            cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
            cell.Padding = 5;
            row.Add(cell);
        */
        }



        public string GeneratePDFCriticalPath(DataTable Dt, string ImgUrl, DataTable dtPermission, int IsClient)
        {

            if (!Directory.Exists(Constants.TEMP_FOLDER_PATH))
                Directory.CreateDirectory(Constants.TEMP_FOLDER_PATH);
            string fileName = string.Empty;
            string pdfFilePath = string.Empty;
            string title = string.Empty;
            string fab1 = string.Empty;
            int result;

            fileName = "Critical Path Report -" + DateTime.Now.ToString("dd MMM yyy hh-mm-ss") + ".pdf";
            pdfFilePath = Path.Combine(Constants.TEMP_FOLDER_PATH, fileName);
            title = "CRITICAL PATH REPORT";


            if (Dt.Rows.Count == 0)
                return string.Empty;

            Color HeaderColor = new Color(System.Drawing.ColorTranslator.FromHtml("#F9DDF4"));

            PDFTableGenerator gen = new PDFTableGenerator(pdfFilePath, title, HeaderColor);

            gen.CellHeight = 200;

            gen.Columns = new List<PDFHeader>();
            if (IsClient != 1)
            {
                gen.Columns.Add(new PDFHeader("ORDER DATE", iKandi.Common.ContentAlignment.Vertical, 2));
                gen.Columns.Add(new PDFHeader("SERIAL NO.", iKandi.Common.ContentAlignment.Vertical, 2));
                gen.Columns.Add(new PDFHeader("CLIENT", iKandi.Common.ContentAlignment.Vertical, 2));
                gen.Columns.Add(new PDFHeader("DEPARTMENT", iKandi.Common.ContentAlignment.Vertical, 2));
                gen.Columns.Add(new PDFHeader("STYLE NO.", iKandi.Common.ContentAlignment.Vertical, 2));
                gen.Columns.Add(new PDFHeader("Style", iKandi.Common.ContentAlignment.Horizontal, 8));
                gen.Columns.Add(new PDFHeader("LINE NO.", iKandi.Common.ContentAlignment.Vertical, 2));
                gen.Columns.Add(new PDFHeader("CONTRACT NO.", iKandi.Common.ContentAlignment.Vertical, 2));
                gen.Columns.Add(new PDFHeader("DESCRIPTION", iKandi.Common.ContentAlignment.Horizontal, 5));
                gen.Columns.Add(new PDFHeader("QUANTITY", iKandi.Common.ContentAlignment.Vertical, 2));
                gen.Columns.Add(new PDFHeader("MODE", iKandi.Common.ContentAlignment.Vertical, 2));
                gen.Columns.Add(new PDFHeader("PACK TYPE", ContentAlignment.Vertical, 2));
                gen.Columns.Add(new PDFHeader("DC DATE", iKandi.Common.ContentAlignment.Vertical, 2));
                gen.Columns.Add(new PDFHeader("ORDER STATUS", iKandi.Common.ContentAlignment.Vertical, 2));
                gen.Columns.Add(new PDFHeader("FABRIC", iKandi.Common.ContentAlignment.Horizontal, 20));
                gen.Columns.Add(new PDFHeader("ACCESSORIES", iKandi.Common.ContentAlignment.Vertical, 2));
                gen.Columns.Add(new PDFHeader("FIT STATUS", iKandi.Common.ContentAlignment.Horizontal, 20, 10));
                gen.Columns.Add(new PDFHeader("PPM - TARGET", iKandi.Common.ContentAlignment.Vertical, 2));
                gen.Columns.Add(new PDFHeader("PPM - ACTUAL", iKandi.Common.ContentAlignment.Vertical, 2));
                gen.Columns.Add(new PDFHeader("PCD - TARGET", iKandi.Common.ContentAlignment.Vertical, 2));
                gen.Columns.Add(new PDFHeader("PCD - ACTUAL", iKandi.Common.ContentAlignment.Vertical, 2));
                gen.Columns.Add(new PDFHeader("CUTTING", iKandi.Common.ContentAlignment.Vertical, 2));
                gen.Columns.Add(new PDFHeader("SEWING", iKandi.Common.ContentAlignment.Vertical, 2));
                gen.Columns.Add(new PDFHeader("FINISH/PACK", iKandi.Common.ContentAlignment.Vertical, 2));
                gen.Columns.Add(new PDFHeader("PCS CUT", iKandi.Common.ContentAlignment.Vertical, 2));
                gen.Columns.Add(new PDFHeader("PCS STITCHED", iKandi.Common.ContentAlignment.Vertical, 2));
                gen.Columns.Add(new PDFHeader("PCS PACKED", iKandi.Common.ContentAlignment.Vertical, 2));
                gen.Columns.Add(new PDFHeader("INLINE", iKandi.Common.ContentAlignment.Vertical, 2));
                gen.Columns.Add(new PDFHeader("FINAL", iKandi.Common.ContentAlignment.Vertical, 2));
            }
            else
            {
                if (IsFieldPermitted(dtPermission, "1"))
                    gen.Columns.Add(new PDFHeader("ORDER DATE", iKandi.Common.ContentAlignment.Vertical, 2));

                if (IsFieldPermitted(dtPermission, "2"))
                    gen.Columns.Add(new PDFHeader("SERIAL NO.", iKandi.Common.ContentAlignment.Vertical, 2));

                if (IsFieldPermitted(dtPermission, "3"))
                    gen.Columns.Add(new PDFHeader("CLIENT", iKandi.Common.ContentAlignment.Vertical, 2));

                if (IsFieldPermitted(dtPermission, "4"))
                    gen.Columns.Add(new PDFHeader("DEPARTMENT", iKandi.Common.ContentAlignment.Vertical, 2));

                if (IsFieldPermitted(dtPermission, "5"))
                    gen.Columns.Add(new PDFHeader("STYLE NO.", iKandi.Common.ContentAlignment.Vertical, 2));

                if (IsFieldPermitted(dtPermission, "5"))
                    gen.Columns.Add(new PDFHeader("Style", iKandi.Common.ContentAlignment.Horizontal, 8));

                if (IsFieldPermitted(dtPermission, "6"))
                    gen.Columns.Add(new PDFHeader("LINE NO.", iKandi.Common.ContentAlignment.Vertical, 2));

                if (IsFieldPermitted(dtPermission, "7"))
                    gen.Columns.Add(new PDFHeader("CONTRACT NO.", iKandi.Common.ContentAlignment.Vertical, 2));

                if (IsFieldPermitted(dtPermission, "8"))
                    gen.Columns.Add(new PDFHeader("DESCRIPTION", iKandi.Common.ContentAlignment.Horizontal, 5));

                if (IsFieldPermitted(dtPermission, "9"))
                    gen.Columns.Add(new PDFHeader("QUANTITY", iKandi.Common.ContentAlignment.Vertical, 2));

                if (IsFieldPermitted(dtPermission, "10"))
                    gen.Columns.Add(new PDFHeader("MODE", iKandi.Common.ContentAlignment.Vertical, 2));

                if (IsFieldPermitted(dtPermission, "11"))
                    gen.Columns.Add(new PDFHeader("PACK TYPE", ContentAlignment.Vertical, 2));

                if (IsFieldPermitted(dtPermission, "12"))
                    gen.Columns.Add(new PDFHeader("DC DATE", iKandi.Common.ContentAlignment.Vertical, 2));

                if (IsFieldPermitted(dtPermission, "28"))
                    gen.Columns.Add(new PDFHeader("ORDER STATUS", iKandi.Common.ContentAlignment.Vertical, 2));

                if (IsFieldPermitted(dtPermission, "13"))
                    gen.Columns.Add(new PDFHeader("FABRIC", iKandi.Common.ContentAlignment.Horizontal, 20));

                if (IsFieldPermitted(dtPermission, "14"))
                    gen.Columns.Add(new PDFHeader("ACCESSORIES", iKandi.Common.ContentAlignment.Vertical, 2));

                if (IsFieldPermitted(dtPermission, "15"))
                    gen.Columns.Add(new PDFHeader("FIT STATUS", iKandi.Common.ContentAlignment.Horizontal, 20, 10));

                if (IsFieldPermitted(dtPermission, "16"))
                    gen.Columns.Add(new PDFHeader("PPM - TARGET", iKandi.Common.ContentAlignment.Vertical, 2));

                if (IsFieldPermitted(dtPermission, "17"))
                    gen.Columns.Add(new PDFHeader("PPM - ACTUAL", iKandi.Common.ContentAlignment.Vertical, 2));

                if (IsFieldPermitted(dtPermission, "18"))
                    gen.Columns.Add(new PDFHeader("PCD - TARGET", iKandi.Common.ContentAlignment.Vertical, 2));

                if (IsFieldPermitted(dtPermission, "19"))
                    gen.Columns.Add(new PDFHeader("PCD - ACTUAL", iKandi.Common.ContentAlignment.Vertical, 2));

                if (IsFieldPermitted(dtPermission, "20"))
                    gen.Columns.Add(new PDFHeader("CUTTING", iKandi.Common.ContentAlignment.Vertical, 2));

                if (IsFieldPermitted(dtPermission, "21"))
                    gen.Columns.Add(new PDFHeader("SEWING", iKandi.Common.ContentAlignment.Vertical, 2));

                if (IsFieldPermitted(dtPermission, "22"))
                    gen.Columns.Add(new PDFHeader("FINISH/PACK", iKandi.Common.ContentAlignment.Vertical, 2));

                if (IsFieldPermitted(dtPermission, "23"))
                    gen.Columns.Add(new PDFHeader("PCS CUT", iKandi.Common.ContentAlignment.Vertical, 2));

                if (IsFieldPermitted(dtPermission, "24"))
                    gen.Columns.Add(new PDFHeader("PCS STITCHED", iKandi.Common.ContentAlignment.Vertical, 2));

                if (IsFieldPermitted(dtPermission, "25"))
                    gen.Columns.Add(new PDFHeader("PCS PACKED", iKandi.Common.ContentAlignment.Vertical, 2));

                if (IsFieldPermitted(dtPermission, "26"))
                    gen.Columns.Add(new PDFHeader("INLINE", iKandi.Common.ContentAlignment.Vertical, 2));

                if (IsFieldPermitted(dtPermission, "27"))
                    gen.Columns.Add(new PDFHeader("FINAL", iKandi.Common.ContentAlignment.Vertical, 2));
            }



            gen.Rows = new List<List<PDFCell>>();

            foreach (DataRow dataRow in Dt.Rows)
            {
                List<PDFCell> row = new List<PDFCell>();



                //Fabric Cal

                var Fab1Det = Convert.ToString(dataRow["Fabric1Details"]).Trim().Split(' ');

                if (!string.IsNullOrEmpty(Fab1Det[0]) && Int32.TryParse(Fab1Det[0], out result) && (Fab1Det.Length == 1 || (Fab1Det.Length == 2 && Fab1Det[1].Length <= 2)) && dataRow["Fabric1Details"] != null && Convert.ToString(dataRow["Fabric1Details"]) != "")
                {
                    dataRow["Fabric1Details"] = "PRD:" + Convert.ToString(dataRow["Fabric1Details"]);
                    result = 0;
                }
                if (dataRow["Fabric1Details"] != null && Convert.ToString(dataRow["Fabric1Details"]) != "")
                    dataRow["Fabric1"] = Convert.ToString(dataRow["Fabric1"]) + " " + Convert.ToString(dataRow["Fabric1Details"]);

                var Fab2Det = Convert.ToString(dataRow["Fabric2Details"]).Trim().Split(' ');


                if (!string.IsNullOrEmpty(Fab1Det[0]) && Int32.TryParse(Fab1Det[0], out result) && (Fab1Det.Length == 1 || (Fab1Det.Length == 2 && Fab1Det[1].Length <= 2)) && dataRow["Fabric2Details"] != null && Convert.ToString(dataRow["Fabric2Details"]) != "")
                {
                    dataRow["Fabric2Details"] = "PRD:" + Convert.ToString(dataRow["Fabric2Details"]);
                    result = 0;
                }

                if (dataRow["Fabric2Details"] != null && Convert.ToString(dataRow["Fabric2Details"]) != "")
                    dataRow["Fabric2"] = Convert.ToString(dataRow["Fabric2"]) + " " + Convert.ToString(dataRow["Fabric2Details"]);


                var Fab3Det = Convert.ToString(dataRow["Fabric3Details"]).Trim().Split(' ');

                if (!string.IsNullOrEmpty(Fab1Det[0]) && Int32.TryParse(Fab1Det[0], out result) && (Fab1Det.Length == 1 || (Fab1Det.Length == 2 && Fab1Det[1].Length <= 2)) && dataRow["Fabric3Details"] != null && Convert.ToString(dataRow["Fabric3Details"]) != "")
                {
                    dataRow["Fabric3Details"] = "PRD:" + Convert.ToString(dataRow["Fabric3Details"]);
                    result = 0;
                }

                if (dataRow["Fabric3Details"] != null && Convert.ToString(dataRow["Fabric3Details"]) != "")
                    dataRow["Fabric3"] = Convert.ToString(dataRow["Fabric3"]) + " " + Convert.ToString(dataRow["Fabric3Details"]);



                var Fab4Det = Convert.ToString(dataRow["Fabric4Details"]).Trim().Split(' ');

                if (!string.IsNullOrEmpty(Fab1Det[0]) && Int32.TryParse(Fab1Det[0], out result) && (Fab1Det.Length == 1 || (Fab1Det.Length == 2 && Fab1Det[1].Length <= 2)) && dataRow["Fabric4Details"] != null && Convert.ToString(dataRow["Fabric4Details"]) != "")
                {
                    dataRow["Fabric4Details"] = "PRD:" + Convert.ToString(dataRow["Fabric4Details"]);
                    result = 0;
                }
                if (dataRow["Fabric4Details"] != null && Convert.ToString(dataRow["Fabric4Details"]) != "")
                    dataRow["Fabric4"] = Convert.ToString(dataRow["Fabric4"]) + " " + Convert.ToString(dataRow["Fabric4Details"]);



                if (dataRow["Fabric1"] != null && Convert.ToString(dataRow["Fabric1"]) != "")
                {
                    fab1 = dataRow["Fabric1"] + " " + "(" + dataRow["Fabric1InHouse"] + ")";
                    if (dataRow["Fabric1Approval"] != null && Convert.ToString(dataRow["Fabric1Approval"]) != "")
                    {
                        fab1 = fab1 + dataRow["Fabric1Approval"];
                    }
                }

                if (dataRow["Fabric2"] != null && Convert.ToString(dataRow["Fabric2"]) != "")
                {
                    fab1 = fab1 + dataRow["Fabric2"] + " " + "(" + dataRow["Fabric2InHouse"] + ")";
                    if (dataRow["Fabric2Approval"] != null && Convert.ToString(dataRow["Fabric2Approval"]) != "")
                    {
                        fab1 = fab1 + dataRow["Fabric2Approval"];
                    }
                }

                if (dataRow["Fabric3"] != null && Convert.ToString(dataRow["Fabric3"]) != "")
                {
                    fab1 = fab1 + dataRow["Fabric3"] + " " + "(" + dataRow["Fabric3InHouse"] + ")";
                    if (dataRow["Fabric3Approval"] != null && Convert.ToString(dataRow["Fabric3Approval"]) != "")
                    {
                        fab1 = fab1 + dataRow["Fabric3Approval"];
                    }
                }

                if (dataRow["Fabric4"] != null && Convert.ToString(dataRow["Fabric4"]) != "")
                {
                    fab1 = fab1 + dataRow["Fabric4"] + " " + "(" + dataRow["Fabric4InHouse"] + ")";
                    if (dataRow["Fabric4Approval"] != null && Convert.ToString(dataRow["Fabric4Approval"]) != "")
                    {
                        fab1 = fab1 + dataRow["Fabric4Approval"];
                    }
                }



                ///end Fabric 
                //Order Date
                PDFCell cell;
                if (IsClient == 1)
                {
                    if (IsFieldPermitted(dtPermission, "1"))
                    {
                        cell = new PDFCell((dataRow["OrderDate"] == DBNull.Value) ? string.Empty : dataRow["OrderDate"].ToString(), iKandi.Common.ContentAlignment.Vertical);
                        cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                        cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                        row.Add(cell);
                    }

                    if (IsFieldPermitted(dtPermission, "2"))
                    {
                        cell = new PDFCell((dataRow["SerialNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(dataRow["SerialNumber"]), iKandi.Common.ContentAlignment.Vertical);
                        cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                        cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                        row.Add(cell);
                    }

                    // Buyer
                    if (IsFieldPermitted(dtPermission, "3"))
                    {
                        cell = new PDFCell((dataRow["Buyer"] == DBNull.Value) ? string.Empty : Convert.ToString(dataRow["Buyer"]), iKandi.Common.ContentAlignment.Vertical);
                        cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                        cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                        row.Add(cell);
                    }

                    // Dept
                    if (IsFieldPermitted(dtPermission, "4"))
                    {
                        cell = new PDFCell((dataRow["DepartmentName"] == DBNull.Value) ? string.Empty : Convert.ToString(dataRow["DepartmentName"]), iKandi.Common.ContentAlignment.Vertical);
                        cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                        cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                        row.Add(cell);
                    }

                    // Style
                    if (IsFieldPermitted(dtPermission, "5"))
                    {
                        cell = new PDFCell((dataRow["StyleNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(dataRow["StyleNumber"]), iKandi.Common.ContentAlignment.Vertical);
                        cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                        cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                        row.Add(cell);
                    }

                    //style image
                    //  MyHyperLink.NavigateUrl = HttpRuntime.AppDomainAppVirtualPath + "/Catalog/ASP/Products"; 



                    if (IsFieldPermitted(dtPermission, "5"))
                    {
                        string ImagePath = (dataRow["SampleImageURL1"] == DBNull.Value) ? string.Empty : Convert.ToString(dataRow["SampleImageURL1"]);
                        cell = new PDFCell(string.Empty, iKandi.Common.ContentAlignment.Horizontal);

                        if (ImagePath != string.Empty)
                        {
                            cell.ImageUrl = Path.Combine(Constants.STYLE_FOLDER_PATH, "thumb-" + ImagePath);
                            // cell.ImageUrl = Path.Combine(ImgUrl, "/thumb-" + ImagePath);
                        }
                        row.Add(cell);
                    }

                    // Line No.
                    if (IsFieldPermitted(dtPermission, "6"))
                    {
                        cell = new PDFCell((dataRow["LineItemNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(dataRow["LineItemNumber"]), iKandi.Common.ContentAlignment.Vertical);
                        cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                        cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                        row.Add(cell);
                    }

                    // Contract
                    if (IsFieldPermitted(dtPermission, "7"))
                    {
                        cell = new PDFCell((dataRow["ContractNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(dataRow["ContractNumber"]), iKandi.Common.ContentAlignment.Vertical);
                        cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                        cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                        row.Add(cell);
                    }

                    // Des
                    if (IsFieldPermitted(dtPermission, "8"))
                    {
                        cell = new PDFCell((dataRow["OrderDescription"] == DBNull.Value) ? string.Empty : dataRow["OrderDescription"].ToString(), iKandi.Common.ContentAlignment.Horizontal);
                        cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                        cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                        row.Add(cell);
                    }

                    ///Quantity
                    ///
                    if (IsFieldPermitted(dtPermission, "9"))
                    {
                        cell = new PDFCell((dataRow["Quantity"] == DBNull.Value) ? string.Empty : dataRow["Quantity"].ToString(), iKandi.Common.ContentAlignment.Vertical);
                        cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                        cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                        row.Add(cell);
                    }

                    // Mode
                    if (IsFieldPermitted(dtPermission, "10"))
                    {
                        cell = new PDFCell((dataRow["Code"] == DBNull.Value) ? string.Empty : dataRow["Code"].ToString(), iKandi.Common.ContentAlignment.Vertical);
                        cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                        cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                        row.Add(cell);
                    }

                    if (IsFieldPermitted(dtPermission, "11"))
                    {
                        cell = new PDFCell((dataRow["PackType"] == DBNull.Value) ? string.Empty : dataRow["PackType"].ToString(), iKandi.Common.ContentAlignment.Vertical);
                        cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                        cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                        row.Add(cell);
                    }

                    if (IsFieldPermitted(dtPermission, "12"))
                    {
                        cell = new PDFCell((dataRow["DCDate"] == DBNull.Value) ? string.Empty : dataRow["DCDate"].ToString(), iKandi.Common.ContentAlignment.Vertical);
                        cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                        cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                        row.Add(cell);
                    }


                    if (IsFieldPermitted(dtPermission, "28"))
                    {
                        cell = new PDFCell((dataRow["Order_Status"] == DBNull.Value) ? string.Empty : dataRow["Order_Status"].ToString(), iKandi.Common.ContentAlignment.Vertical);
                        cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                        cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                        row.Add(cell);
                    }

                    if (IsFieldPermitted(dtPermission, "13"))
                    {
                        cell = new PDFCell(fab1, iKandi.Common.ContentAlignment.Horizontal);
                        cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                        cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                        // cell.CellText = iTextSharp.text.html.simpleparser.HTMLWorker.ParseToList(new StringReader(fab1), null);
                        row.Add(cell);
                    }


                    if (IsFieldPermitted(dtPermission, "14"))
                    {
                        cell = new PDFCell((dataRow["AccessoryApproval"] == DBNull.Value) ? string.Empty : dataRow["AccessoryApproval"].ToString(), iKandi.Common.ContentAlignment.Vertical);
                        cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                        cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                        row.Add(cell);
                    }

                    if (IsFieldPermitted(dtPermission, "15"))
                    {
                        cell = new PDFCell((dataRow["FITPopStatus"] == DBNull.Value) ? string.Empty : dataRow["FITPopStatus"].ToString().Replace("<b><span style=color:blue>", "").Replace("</span></b>", ""), iKandi.Common.ContentAlignment.Horizontal);
                        cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                        cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                        row.Add(cell);
                    }

                    if (IsFieldPermitted(dtPermission, "16"))
                    {
                        cell = new PDFCell((dataRow["PPM_Planned"] == DBNull.Value) ? string.Empty : dataRow["PPM_Planned"].ToString(), iKandi.Common.ContentAlignment.Vertical);
                        cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                        cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                        row.Add(cell);
                    }

                    if (IsFieldPermitted(dtPermission, "17"))
                    {
                        cell = new PDFCell((dataRow["PPM_Actual"] == DBNull.Value) ? string.Empty : dataRow["PPM_Actual"].ToString(), iKandi.Common.ContentAlignment.Vertical);
                        cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                        cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                        row.Add(cell);
                    }


                    if (IsFieldPermitted(dtPermission, "18"))
                    {
                        cell = new PDFCell((dataRow["PCDPlanned"] == DBNull.Value) ? string.Empty : dataRow["PCDPlanned"].ToString(), iKandi.Common.ContentAlignment.Vertical);
                        cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                        cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                        row.Add(cell);
                    }


                    if (IsFieldPermitted(dtPermission, "19"))
                    {
                        cell = new PDFCell((dataRow["PCDActual"] == DBNull.Value) ? string.Empty : dataRow["PCDActual"].ToString(), iKandi.Common.ContentAlignment.Vertical);
                        cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                        cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                        row.Add(cell);
                    }

                    if (IsFieldPermitted(dtPermission, "20"))
                    {
                        cell = new PDFCell((dataRow["Cutting"] == DBNull.Value) ? string.Empty : dataRow["Cutting"].ToString(), iKandi.Common.ContentAlignment.Vertical);
                        cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                        cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                        row.Add(cell);
                    }

                    if (IsFieldPermitted(dtPermission, "21"))
                    {
                        cell = new PDFCell((dataRow["Sewing"] == DBNull.Value) ? string.Empty : dataRow["Sewing"].ToString(), iKandi.Common.ContentAlignment.Vertical);
                        cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                        cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                        row.Add(cell);
                    }

                    if (IsFieldPermitted(dtPermission, "22"))
                    {
                        cell = new PDFCell((dataRow["Finish_Pack"] == DBNull.Value) ? string.Empty : dataRow["Finish_Pack"].ToString(), iKandi.Common.ContentAlignment.Vertical);
                        cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                        cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                        row.Add(cell);
                    }


                    if (IsFieldPermitted(dtPermission, "23"))
                    {
                        cell = new PDFCell((dataRow["PcsCut"] == DBNull.Value) ? string.Empty : dataRow["PcsCut"].ToString().Replace("<span style=color:blue>", "").Replace("</span>", ""), iKandi.Common.ContentAlignment.Vertical);
                        cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                        cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                        row.Add(cell);
                    }

                    if (IsFieldPermitted(dtPermission, "24"))
                    {
                        cell = new PDFCell((dataRow["PcsStitched"] == DBNull.Value) ? string.Empty : dataRow["PcsStitched"].ToString().Replace("<span style=color:blue>", "").Replace("</span>", ""), iKandi.Common.ContentAlignment.Vertical);
                        cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                        cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                        row.Add(cell);
                    }

                    if (IsFieldPermitted(dtPermission, "25"))
                    {
                        cell = new PDFCell((dataRow["PcsPacked"] == DBNull.Value) ? string.Empty : dataRow["PcsPacked"].ToString().Replace("<span style=color:blue>", "").Replace("</span>", ""), iKandi.Common.ContentAlignment.Vertical);
                        cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                        cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                        row.Add(cell);
                    }

                    if (IsFieldPermitted(dtPermission, "26"))
                    {
                        cell = new PDFCell((dataRow["Inline_Inspection"] == DBNull.Value) ? string.Empty : dataRow["Inline_Inspection"].ToString(), iKandi.Common.ContentAlignment.Vertical);
                        cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                        cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                        row.Add(cell);
                    }

                    if (IsFieldPermitted(dtPermission, "27"))
                    {
                        cell = new PDFCell((dataRow["Final_Inspection"] == DBNull.Value) ? string.Empty : dataRow["Final_Inspection"].ToString(), iKandi.Common.ContentAlignment.Vertical);
                        cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                        cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                        row.Add(cell);
                    }
                }
                else
                {
                    cell = new PDFCell((dataRow["OrderDate"] == DBNull.Value) ? string.Empty : dataRow["OrderDate"].ToString(), iKandi.Common.ContentAlignment.Vertical);
                    cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                    row.Add(cell);

                    // Serial Number
                    cell = new PDFCell((dataRow["SerialNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(dataRow["SerialNumber"]), iKandi.Common.ContentAlignment.Vertical);
                    cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                    row.Add(cell);

                    // Buyer
                    cell = new PDFCell((dataRow["Buyer"] == DBNull.Value) ? string.Empty : Convert.ToString(dataRow["Buyer"]), iKandi.Common.ContentAlignment.Vertical);
                    cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                    row.Add(cell);

                    // Dept
                    cell = new PDFCell((dataRow["DepartmentName"] == DBNull.Value) ? string.Empty : Convert.ToString(dataRow["DepartmentName"]), iKandi.Common.ContentAlignment.Vertical);
                    cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                    row.Add(cell);

                    // Style


                    cell = new PDFCell((dataRow["StyleNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(dataRow["StyleNumber"]), iKandi.Common.ContentAlignment.Vertical);
                    cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                    row.Add(cell);

                    //style image

                    //style image


                    //////////////////////////////
                    string ImagePath = (dataRow["SampleImageURL1"] == DBNull.Value) ? string.Empty : Convert.ToString(dataRow["SampleImageURL1"]);

                    cell = new PDFCell(string.Empty, iKandi.Common.ContentAlignment.Horizontal);
                    if (ImagePath != string.Empty)
                    {
                        cell.ImageUrl = Path.Combine(Constants.STYLE_FOLDER_PATH, "thumb-" + ImagePath);
                    }
                    row.Add(cell);

                    // Line No.
                    cell = new PDFCell((dataRow["LineItemNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(dataRow["LineItemNumber"]), iKandi.Common.ContentAlignment.Vertical);
                    cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                    row.Add(cell);

                    // Contract
                    cell = new PDFCell((dataRow["ContractNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(dataRow["ContractNumber"]), iKandi.Common.ContentAlignment.Vertical);
                    cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                    row.Add(cell);

                    // Des
                    cell = new PDFCell((dataRow["OrderDescription"] == DBNull.Value) ? string.Empty : dataRow["OrderDescription"].ToString(), iKandi.Common.ContentAlignment.Horizontal);
                    cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                    row.Add(cell);

                    ///Quantity
                    cell = new PDFCell((dataRow["Quantity"] == DBNull.Value) ? string.Empty : dataRow["Quantity"].ToString(), iKandi.Common.ContentAlignment.Vertical);
                    cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                    row.Add(cell);

                    // Mode
                    cell = new PDFCell((dataRow["Code"] == DBNull.Value) ? string.Empty : dataRow["Code"].ToString(), iKandi.Common.ContentAlignment.Vertical);
                    cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                    row.Add(cell);

                    // Ex-Factory
                    cell = new PDFCell((dataRow["PackType"] == DBNull.Value) ? string.Empty : dataRow["PackType"].ToString(), iKandi.Common.ContentAlignment.Vertical);
                    cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                    row.Add(cell);

                    cell = new PDFCell((dataRow["DCDate"] == DBNull.Value) ? string.Empty : dataRow["DCDate"].ToString(), iKandi.Common.ContentAlignment.Vertical);
                    cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                    row.Add(cell);

                    cell = new PDFCell((dataRow["Order_Status"] == DBNull.Value) ? string.Empty : dataRow["Order_Status"].ToString(), iKandi.Common.ContentAlignment.Vertical);
                    cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                    row.Add(cell);

                    cell = new PDFCell(fab1, iKandi.Common.ContentAlignment.Horizontal);
                    cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                    // cell.CellText = iTextSharp.text.html.simpleparser.HTMLWorker.ParseToList(new StringReader(fab1), null);
                    row.Add(cell);

                    cell = new PDFCell((dataRow["AccessoryApproval"] == DBNull.Value) ? string.Empty : dataRow["AccessoryApproval"].ToString(), iKandi.Common.ContentAlignment.Vertical);
                    cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                    row.Add(cell);

                    cell = new PDFCell((dataRow["FITPopStatus"] == DBNull.Value) ? string.Empty : dataRow["FITPopStatus"].ToString().Replace("<b><span style=color:blue>", "").Replace("</span></b>", ""), iKandi.Common.ContentAlignment.Horizontal);
                    cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                    row.Add(cell);


                    cell = new PDFCell((dataRow["PPM_Planned"] == DBNull.Value) ? string.Empty : dataRow["PPM_Planned"].ToString(), iKandi.Common.ContentAlignment.Vertical);
                    cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                    row.Add(cell);


                    cell = new PDFCell((dataRow["PPM_Actual"] == DBNull.Value) ? string.Empty : dataRow["PPM_Actual"].ToString(), iKandi.Common.ContentAlignment.Vertical);
                    cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                    row.Add(cell);



                    cell = new PDFCell((dataRow["PCDPlanned"] == DBNull.Value) ? string.Empty : dataRow["PCDPlanned"].ToString(), iKandi.Common.ContentAlignment.Vertical);
                    cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                    row.Add(cell);



                    cell = new PDFCell((dataRow["PCDActual"] == DBNull.Value) ? string.Empty : dataRow["PCDActual"].ToString(), iKandi.Common.ContentAlignment.Vertical);
                    cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                    row.Add(cell);


                    cell = new PDFCell((dataRow["Cutting"] == DBNull.Value) ? string.Empty : dataRow["Cutting"].ToString(), iKandi.Common.ContentAlignment.Vertical);
                    cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                    row.Add(cell);


                    cell = new PDFCell((dataRow["Sewing"] == DBNull.Value) ? string.Empty : dataRow["Sewing"].ToString(), iKandi.Common.ContentAlignment.Vertical);
                    cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                    row.Add(cell);


                    cell = new PDFCell((dataRow["Finish_Pack"] == DBNull.Value) ? string.Empty : dataRow["Finish_Pack"].ToString(), iKandi.Common.ContentAlignment.Vertical);
                    cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                    row.Add(cell);



                    cell = new PDFCell((dataRow["PcsCut"] == DBNull.Value) ? string.Empty : dataRow["PcsCut"].ToString().Replace("<span style=color:blue>", "").Replace("</span>", ""), iKandi.Common.ContentAlignment.Vertical);
                    cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                    row.Add(cell);


                    cell = new PDFCell((dataRow["PcsStitched"] == DBNull.Value) ? string.Empty : dataRow["PcsStitched"].ToString().Replace("<span style=color:blue>", "").Replace("</span>", ""), iKandi.Common.ContentAlignment.Vertical);
                    cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                    row.Add(cell);


                    cell = new PDFCell((dataRow["PcsPacked"] == DBNull.Value) ? string.Empty : dataRow["PcsPacked"].ToString().Replace("<span style=color:blue>", "").Replace("</span>", ""), iKandi.Common.ContentAlignment.Vertical);
                    cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                    row.Add(cell);

                    cell = new PDFCell((dataRow["Inline_Inspection"] == DBNull.Value) ? string.Empty : dataRow["Inline_Inspection"].ToString(), iKandi.Common.ContentAlignment.Vertical);
                    cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                    row.Add(cell);

                    cell = new PDFCell((dataRow["Final_Inspection"] == DBNull.Value) ? string.Empty : dataRow["Final_Inspection"].ToString(), iKandi.Common.ContentAlignment.Vertical);
                    cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                    row.Add(cell);
                }
                gen.Rows.Add(row);
            }

            gen.GeneratePDF();
            return pdfFilePath;

        }


        public string GeneratePDFPendingPayment(DataTable Dt, string ImgUrl)
        {
            if (!Directory.Exists(Constants.TEMP_FOLDER_PATH))
                Directory.CreateDirectory(Constants.TEMP_FOLDER_PATH);
            string fileName = string.Empty;
            string pdfFilePath = string.Empty;
            string title = string.Empty;

            fileName = "Pending Payment ;Report -" + DateTime.Now.ToString("dd MMM yyy hh-mm-ss") + ".pdf";
            pdfFilePath = Path.Combine(Constants.TEMP_FOLDER_PATH, fileName);
            title = "PENDING PAYMENT REPORT";
            if (Dt.Rows.Count == 0)
                return string.Empty;

            Color HeaderColor = new Color(System.Drawing.ColorTranslator.FromHtml("#F9DDF4"));
            PDFTableGenerator gen = new PDFTableGenerator(pdfFilePath, title, HeaderColor);

            gen.CellHeight = 30;

            gen.Columns = new List<PDFHeader>();
            gen.Columns.Add(new PDFHeader("BuyerCode", ContentAlignment.Horizontal, 1));
            gen.Columns.Add(new PDFHeader("Bank Ref. No.", ContentAlignment.Horizontal, 1));
            gen.Columns.Add(new PDFHeader("BE Date", ContentAlignment.Horizontal, 1));
            //Edit By Ashish for Removing Date Header in PrintPDF on 26/9/2014
            //gen.Columns.Add(new PDFHeader("Date", ContentAlignment.Horizontal, 1));
            //END
            gen.Columns.Add(new PDFHeader("CURR", ContentAlignment.Horizontal, 1));
            gen.Columns.Add(new PDFHeader("Bill Amount", ContentAlignment.Horizontal, 1));
            gen.Columns.Add(new PDFHeader("Pending Amount", ContentAlignment.Horizontal, 1));
            gen.Columns.Add(new PDFHeader("DueDate", ContentAlignment.Horizontal, 1));
            gen.Columns.Add(new PDFHeader("Delay", ContentAlignment.Horizontal, 1));
            gen.Columns.Add(new PDFHeader("Bill Amount(INR)", ContentAlignment.Horizontal, 1));
            gen.Columns.Add(new PDFHeader("Pending Amount(INR)", ContentAlignment.Horizontal, 1));
            gen.Columns.Add(new PDFHeader("Remarks", ContentAlignment.Horizontal, 1));
            gen.Rows = new List<List<PDFCell>>();
            double btotal = 0;
            double ptotal = 0;
            double gbtotal = 0;
            double gptotal = 0;
            string bcode = "";
            List<PDFCell> row = new List<PDFCell>();
            foreach (DataRow dataRow in Dt.Rows)
            {
                string cname = dataRow["CompanyName"] != DBNull.Value
                                   ? Convert.ToString(dataRow["CompanyName"]).Trim()
                                   : "";
                if (string.IsNullOrEmpty(bcode))
                    bcode = cname;
                if (bcode != cname)
                {
                    //Edit By Ashish for replace Loop limit 7 to 6 on 26/9/2014
                    for (int i = 0; i < 6; i++)
                        row.Add(new PDFCell(""));
                    row.Add(CreatePDFCell("SUB TOTAL", Element.ALIGN_CENTER, Element.ALIGN_MIDDLE, 2, 15));
                    row.Add(CreatePDFCell(btotal.ToString("N2"), Element.ALIGN_CENTER, Element.ALIGN_MIDDLE));
                    row.Add(CreatePDFCell(ptotal.ToString("N2"), Element.ALIGN_CENTER, Element.ALIGN_MIDDLE));
                    row.Add(new PDFCell(""));
                    btotal = 0;
                    ptotal = 0;
                    bcode = cname;
                }
                string bankrefno = Convert.ToString(dataRow["BENumber"]);
                string bedate = (dataRow["BEDate"] == DBNull.Value ||
                                 Convert.ToDateTime(dataRow["BEDate"]) == DateTime.MinValue)
                                    ? ""
                                    : Convert.ToDateTime(dataRow["BEDate"]).ToString("dd MMM yy (ddd)");
                //Edit By Ashish for Removing InvoiceDate on 26/9/2014
                //string invoicedate = (dataRow["InvoiceDate"] == DBNull.Value ||
                //                      Convert.ToDateTime(dataRow["InvoiceDate"]) == DateTime.MinValue)
                //                         ? ""
                //                         : Convert.ToDateTime(dataRow["InvoiceDate"]).ToString("dd MMM yy (ddd)");
                //END
                string curr = dataRow["ConvertTo"] != DBNull.Value
                                  ? iKandi.BLL.CommonHelper.GetCurrencyName(Convert.ToInt32(dataRow["ConvertTo"]))
                                  : "";
                string billamount = dataRow["CurrencySymbol"] != DBNull.Value
                                        ? Convert.ToString(dataRow["CurrencySymbol"])
                                        : "";
                //Edit By Ashish for assing £ and € sine on 26/9/2014
                if (billamount == "&pound;")
                {
                    billamount = "£";
                }
                if (billamount == "&euro;")
                {
                    billamount = "€";

                }

                billamount += " " +
                              (dataRow["Total"] != DBNull.Value ? Convert.ToDouble(dataRow["Total"]).ToString("N2") : "");
                //billamount = billamount.Replace("&pound;", "£"); 
                //END

                string pendingamount = dataRow["CurrencySymbol"] != DBNull.Value
                                           ? Convert.ToString(dataRow["CurrencySymbol"])
                                           : "";
                //Edit By Ashish for assing £ and € sine on 26/9/2014
                if (pendingamount == "&pound;")
                {
                    pendingamount = "£";
                }
                if (pendingamount == "&euro;")
                {
                    pendingamount = "€";
                }

                pendingamount += " " +
                                 (dataRow["PendingPayment"] != DBNull.Value
                                      ? Convert.ToDouble(dataRow["PendingPayment"]).ToString("N2")
                                      : "");
                //pendingamount = pendingamount.Replace("&pound;", "£");
                //END

                string duedate = (dataRow["PaymentDueDate"] == DBNull.Value ||
                                  Convert.ToDateTime(dataRow["PaymentDueDate"]) == DateTime.MinValue)
                                     ? ""
                                     : Convert.ToDateTime(dataRow["PaymentDueDate"]).ToString("dd MMM yy (ddd)");
                string delay = dataRow["Delay"] != DBNull.Value ? Convert.ToString(dataRow["Delay"]) : "";
                string billamountInr = dataRow["Total"] != DBNull.Value
                                           ? (Convert.ToDouble(dataRow["Total"]) *
                                              Convert.ToDouble(dataRow["ConversionRateINR"])).ToString("N2")
                                           : "";
                btotal += Convert.ToDouble(billamountInr);
                gbtotal += Convert.ToDouble(billamountInr);
                string pendingamountInr = dataRow["Total"] != DBNull.Value
                                              ? (Convert.ToDouble(dataRow["PendingPayment"]) *
                                                 Convert.ToDouble(dataRow["ConversionRateINR"])).ToString("N2")
                                              : "";
                ptotal += Convert.ToDouble(pendingamountInr);
                gptotal += Convert.ToDouble(pendingamountInr);
                string remarks = dataRow["Remarks"] == DBNull.Value
                                     ? ""
                                     : dataRow["Remarks"].ToString().Replace("$$", "<br />");

                row.Add(CreatePDFCell(cname, Element.ALIGN_CENTER, Element.ALIGN_MIDDLE));
                row.Add(CreatePDFCell(bankrefno, Element.ALIGN_CENTER, Element.ALIGN_MIDDLE, "Blue", 12));
                row.Add(CreatePDFCell(bedate, Element.ALIGN_CENTER, Element.ALIGN_MIDDLE));
                //Edit By Ashish For Removing Date in Print Pdf  on 26/9/2014
                //row.Add(CreatePDFCell(invoicedate, Element.ALIGN_CENTER, Element.ALIGN_MIDDLE));
                //END
                row.Add(CreatePDFCell(curr, Element.ALIGN_CENTER, Element.ALIGN_MIDDLE));
                row.Add(CreatePDFCell(billamount, Element.ALIGN_CENTER, Element.ALIGN_MIDDLE));
                row.Add(CreatePDFCell(pendingamount, Element.ALIGN_CENTER, Element.ALIGN_MIDDLE));
                row.Add(CreatePDFCell(duedate, Element.ALIGN_CENTER, Element.ALIGN_MIDDLE));
                row.Add(CreatePDFCell(delay, Element.ALIGN_CENTER, Element.ALIGN_MIDDLE, "Blue", 12));
                row.Add(CreatePDFCell(billamountInr, Element.ALIGN_CENTER, Element.ALIGN_MIDDLE, "Blue", 12));
                row.Add(CreatePDFCell(pendingamountInr, Element.ALIGN_CENTER, Element.ALIGN_MIDDLE, "Blue", 12));
                row.Add(CreatePDFCell(remarks, Element.ALIGN_CENTER, Element.ALIGN_MIDDLE));
            }
            //Edit By Ashish for replace Loop limit 7 to 6 on 26/9/2014
            for (int i = 0; i < 6; i++)
                row.Add(new PDFCell(""));
            row.Add(CreatePDFCell("SUB TOTAL", Element.ALIGN_CENTER, Element.ALIGN_MIDDLE, 2, 15));
            row.Add(CreatePDFCell(btotal.ToString(), Element.ALIGN_CENTER, Element.ALIGN_MIDDLE));
            row.Add(CreatePDFCell(ptotal.ToString(), Element.ALIGN_CENTER, Element.ALIGN_MIDDLE));
            row.Add(new PDFCell(""));

            //Edit By Ashish for replace Loop limit 7 to 6 on 26/9/2014
            for (int i = 0; i < 6; i++)
                row.Add(new PDFCell(""));
            row.Add(CreatePDFCell("GRAND TOTAL", Element.ALIGN_CENTER, Element.ALIGN_MIDDLE, 2, 15));
            row.Add(CreatePDFCell(gbtotal.ToString("N2"), Element.ALIGN_CENTER, Element.ALIGN_MIDDLE));
            row.Add(CreatePDFCell(gptotal.ToString("N2"), Element.ALIGN_CENTER, Element.ALIGN_MIDDLE));
            row.Add(new PDFCell(""));
            gen.Rows.Add(row);
            gen.GeneratePDF();
            return pdfFilePath;
        }

        private PDFCell CreatePDFCell(string cellText, int horizontal, int vertical)
        {
            PDFCell cell = new PDFCell(cellText);
            cell.TextHorizontalAlignment = horizontal;
            cell.TextVerticalAlignment = vertical;
            return cell;
        }

        private PDFCell CreatePDFCell(string cellText, int horizontal, int vertical, int colspan)
        {
            PDFCell cell = CreatePDFCell(cellText, horizontal, vertical);
            cell.ColSpan = colspan;
            return cell;
        }

        private PDFCell CreatePDFCell(string cellText, int horizontal, int vertical, int colspan, string fontcolor, int fontsize)
        {
            PDFCell cell = CreatePDFCell(cellText, horizontal, vertical, fontcolor, fontsize);
            cell.ColSpan = colspan;
            return cell;
        }

        private PDFCell CreatePDFCell(string cellText, int horizontal, int vertical, int colspan, int fontsize)
        {
            PDFCell cell = CreatePDFCell(cellText, horizontal, vertical, colspan);
            cell.FontSize = fontsize;
            return cell;
        }

        private PDFCell CreatePDFCell(string cellText, int horizontal, int vertical, string fontcolor)
        {
            PDFCell cell = CreatePDFCell(cellText, horizontal, vertical);
            cell.FontColor = fontcolor;
            return cell;
        }

        private PDFCell CreatePDFCell(string cellText, int horizontal, int vertical, string fontcolor, int fontsize)
        {
            PDFCell cell = CreatePDFCell(cellText, horizontal, vertical);
            cell.FontColor = fontcolor;
            cell.FontSize = fontsize;
            return cell;
        }

        private PDFCell CreatePDFCell(string cellText, int horizontal, int vertical, int colspan, string fontcolor)
        {
            PDFCell cell = CreatePDFCell(cellText, horizontal, vertical);
            cell.FontColor = fontcolor;
            cell.ColSpan = colspan;
            return cell;
        }

        public string LiabilityFormGeneratePDF(DataTable Dt)
        {

            if (!Directory.Exists(Constants.TEMP_FOLDER_PATH))
                Directory.CreateDirectory(Constants.TEMP_FOLDER_PATH);
            string fileName = string.Empty;
            string pdfFilePath = string.Empty;
            string title = string.Empty;
            string fab1 = string.Empty;

            fileName = "Liability Report -" + DateTime.Now.ToString("dd MMM yyy hh-mm-ss") + ".pdf";
            pdfFilePath = Path.Combine(Constants.TEMP_FOLDER_PATH, fileName);
            title = "Liability Report";


            if (Dt.Rows.Count == 0)
                return string.Empty;

            Color HeaderColor = new Color(System.Drawing.ColorTranslator.FromHtml("#F9DDF4"));

            PDFTableGenerator gen = new PDFTableGenerator(pdfFilePath, title, HeaderColor);

            gen.CellHeight = 200;

            gen.Columns = new List<PDFHeader>();

            gen.Columns.Add(new PDFHeader("LBTY NO.", iKandi.Common.ContentAlignment.Vertical, 2));
            gen.Columns.Add(new PDFHeader("CANCELLATION DATE", iKandi.Common.ContentAlignment.Horizontal, 6));
            gen.Columns.Add(new PDFHeader("SERIAL NO.", iKandi.Common.ContentAlignment.Vertical, 2));
            gen.Columns.Add(new PDFHeader("DEPT.", iKandi.Common.ContentAlignment.Vertical, 2));
            gen.Columns.Add(new PDFHeader("STYLE NO.", iKandi.Common.ContentAlignment.Vertical, 2));
            gen.Columns.Add(new PDFHeader("STYLE", iKandi.Common.ContentAlignment.Horizontal, 8));
            gen.Columns.Add(new PDFHeader("QTY CANCELLED", iKandi.Common.ContentAlignment.Vertical, 2));
            gen.Columns.Add(new PDFHeader("OWNER", iKandi.Common.ContentAlignment.Vertical, 2));
            gen.Columns.Add(new PDFHeader("FABRIC LIABILITY", iKandi.Common.ContentAlignment.Horizontal, 6));
            gen.Columns.Add(new PDFHeader("ACCESSORY LIABILITY", iKandi.Common.ContentAlignment.Horizontal, 6));

            //gen.Columns.Add(new PDFHeader("FABRIC1 PRICE", iKandi.Common.ContentAlignment.Horizontal, 5));
            //gen.Columns.Add(new PDFHeader("FABRIC1 QUANTITY", iKandi.Common.ContentAlignment.Vertical, 2));

            //gen.Columns.Add(new PDFHeader("FABRIC2 PRICE", iKandi.Common.ContentAlignment.Horizontal, 5));
            //gen.Columns.Add(new PDFHeader("FABRIC2 QUANTITY", iKandi.Common.ContentAlignment.Vertical, 2));

            //gen.Columns.Add(new PDFHeader("FABRIC3 PRICE", iKandi.Common.ContentAlignment.Horizontal, 5));
            //gen.Columns.Add(new PDFHeader("FABRIC3 QUANTITY", iKandi.Common.ContentAlignment.Vertical, 2));

            //gen.Columns.Add(new PDFHeader("FABRIC4 PRICE", iKandi.Common.ContentAlignment.Horizontal, 5));
            //gen.Columns.Add(new PDFHeader("FABRIC4 QUANTITY", iKandi.Common.ContentAlignment.Vertical, 2));

            gen.Columns.Add(new PDFHeader("CANCELLATION COST", iKandi.Common.ContentAlignment.Horizontal, 6));

            gen.Columns.Add(new PDFHeader("INVOICE NO.", iKandi.Common.ContentAlignment.Vertical, 2));

            gen.Columns.Add(new PDFHeader("INVOICE DATE.", iKandi.Common.ContentAlignment.Vertical, 2));

            gen.Columns.Add(new PDFHeader("STATUS", iKandi.Common.ContentAlignment.Horizontal, 10));


            gen.Columns.Add(new PDFHeader("MERCHANT REMARKS", iKandi.Common.ContentAlignment.Horizontal, 10));

            gen.Columns.Add(new PDFHeader("DOCUMENTATION REMARKS", iKandi.Common.ContentAlignment.Horizontal, 10));


            gen.Rows = new List<List<PDFCell>>();

            foreach (DataRow dataRow in Dt.Rows)
            {
                List<PDFCell> row = new List<PDFCell>();


                PDFCell cell;

                cell = new PDFCell((dataRow["LiabilityNumber"] == DBNull.Value) ? string.Empty : dataRow["LiabilityNumber"].ToString(), iKandi.Common.ContentAlignment.Vertical);
                cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                row.Add(cell);


                cell = new PDFCell((dataRow["DateCancelled"] == DBNull.Value) ? string.Empty : Convert.ToDateTime(dataRow["DateCancelled"]).ToString("dd MMM yy (ddd)"), iKandi.Common.ContentAlignment.Horizontal);
                cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                row.Add(cell);


                cell = new PDFCell((dataRow["SerialNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(dataRow["SerialNumber"]), iKandi.Common.ContentAlignment.Vertical);
                cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                row.Add(cell);

                // Dept
                cell = new PDFCell((dataRow["DepartmentName"] == DBNull.Value) ? string.Empty : Convert.ToString(dataRow["DepartmentName"]), iKandi.Common.ContentAlignment.Vertical);
                cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                row.Add(cell);

                // Style


                cell = new PDFCell((dataRow["StyleNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(dataRow["StyleNumber"]), iKandi.Common.ContentAlignment.Vertical);
                cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                row.Add(cell);

                //style image

                //style image


                //////////////////////////////
                string ImagePath = (dataRow["SampleImageURL1"] == DBNull.Value) ? string.Empty : Convert.ToString(dataRow["SampleImageURL1"]);

                cell = new PDFCell(string.Empty, iKandi.Common.ContentAlignment.Horizontal);
                if (ImagePath != string.Empty)
                {
                    cell.ImageUrl = Path.Combine(Constants.STYLE_FOLDER_PATH, "thumb-" + ImagePath);
                }
                row.Add(cell);

                cell = new PDFCell((dataRow["QuantityCancelled"] == DBNull.Value) ? string.Empty : Convert.ToInt32(dataRow["QuantityCancelled"]).ToString("N0"), iKandi.Common.ContentAlignment.Vertical);
                cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                row.Add(cell);


                cell = new PDFCell((dataRow["Owner"] == DBNull.Value) ? string.Empty : Convert.ToString(dataRow["Owner"]), iKandi.Common.ContentAlignment.Vertical);
                cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                row.Add(cell);


                int sign = Convert.ToInt32(dataRow["ConvertTo"]);
                string currencySign = iKandi.Common.Constants.GetCurrencySymbalByCurrencyType(sign);

                //cell = new PDFCell((dataRow["Fabric1Price"] == DBNull.Value || dataRow["Fabric1Price"] == "") ? currencySign + " " + "0" : currencySign + " " +Convert.ToDecimal(dataRow["Fabric1Price"]).ToString("N2"), iKandi.Common.ContentAlignment.Horizontal);
                //cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                //cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                //row.Add(cell);

                //cell = new PDFCell((dataRow["Fabric1Quantity"] == DBNull.Value || dataRow["Fabric1Quantity"]=="") ? "0.00" : Convert.ToInt32(dataRow["Fabric1Quantity"]).ToString("N2"), iKandi.Common.ContentAlignment.Vertical);
                //cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                //cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                //row.Add(cell);


                //cell = new PDFCell((dataRow["Fabric2Price"] == DBNull.Value || dataRow["Fabric2Price"] == "") ? currencySign + " " + "0" : currencySign + " " + Convert.ToDecimal(dataRow["Fabric2Price"]).ToString("N2"), iKandi.Common.ContentAlignment.Horizontal);
                //cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                //cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                //row.Add(cell);

                //cell = new PDFCell((dataRow["Fabric2Quantity"] == DBNull.Value || dataRow["Fabric2Quantity"] == "") ? "0.00" : Convert.ToInt32(dataRow["Fabric2Quantity"]).ToString("N2"), iKandi.Common.ContentAlignment.Vertical);
                //cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                //cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                //row.Add(cell);

                //cell = new PDFCell((dataRow["Fabric3Price"] == DBNull.Value || dataRow["Fabric3Price"] == "") ? currencySign + " " + "0" : currencySign + " " + Convert.ToDecimal(dataRow["Fabric3Price"]).ToString("N2"), iKandi.Common.ContentAlignment.Horizontal);
                //cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                //cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                //row.Add(cell);

                //cell = new PDFCell((dataRow["Fabric3Quantity"] == DBNull.Value || dataRow["Fabric3Quantity"] == "") ? "0.00" : Convert.ToInt32(dataRow["Fabric3Quantity"]).ToString("N2"), iKandi.Common.ContentAlignment.Vertical);
                //cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                //cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                //row.Add(cell);


                //cell = new PDFCell((dataRow["Fabric4Price"] == DBNull.Value || dataRow["Fabric4Price"] == "") ? currencySign + " " + "0" : currencySign + " " + Convert.ToDecimal(dataRow["Fabric4Price"]).ToString("N2"), iKandi.Common.ContentAlignment.Horizontal);
                //cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                //cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                //row.Add(cell);

                //cell = new PDFCell((dataRow["Fabric4Quantity"] == DBNull.Value || dataRow["Fabric4Quantity"] == "") ? "0.00" : Convert.ToInt32(dataRow["Fabric4Quantity"]).ToString("N2"), iKandi.Common.ContentAlignment.Vertical);
                //cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                //cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                //row.Add(cell);


                cell = new PDFCell((dataRow["Fabric_Liability"] == DBNull.Value) ? string.Empty : currencySign + " " + dataRow["Fabric_Liability"].ToString(), iKandi.Common.ContentAlignment.Horizontal);
                cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                row.Add(cell);

                cell = new PDFCell((dataRow["TotalQty"] == DBNull.Value) ? string.Empty : currencySign + " " + dataRow["TotalQty"].ToString(), iKandi.Common.ContentAlignment.Horizontal);
                cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                row.Add(cell);

                double dblTotalCancellation;
                dblTotalCancellation = Convert.ToDouble(dataRow["TotalQty"]) + Convert.ToDouble(dataRow["Fabric_Liability"]);
                cell = new PDFCell(currencySign + " " + Convert.ToString(dblTotalCancellation), iKandi.Common.ContentAlignment.Vertical);
                cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                row.Add(cell);


                cell = new PDFCell((dataRow["InvoiceNumber"] == DBNull.Value) ? string.Empty : dataRow["InvoiceNumber"].ToString(), iKandi.Common.ContentAlignment.Vertical);
                cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                row.Add(cell);

                cell = new PDFCell((dataRow["InvoiceDate"] == DBNull.Value || Convert.ToDateTime(dataRow["InvoiceDate"]) == DateTime.MinValue) ? string.Empty : Convert.ToDateTime(dataRow["InvoiceDate"]).ToString("dd MMM yy (ddd)"), iKandi.Common.ContentAlignment.Vertical);
                cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                row.Add(cell);
                DateTime CreatedOn;
                string Status = ((iKandi.Common.PaymentStatus)Convert.ToInt32(dataRow["PaymentStatus"])).ToString();
                string StrCreatedOn = string.Empty;
                string StrOwner = string.Empty;
                string StrNextActionDate = string.Empty;
                string StrAckOn = string.Empty;
                string StrHoldTillDate = string.Empty;
                string StrAcceptedOn = string.Empty;
                string StrInvoiceRaised = string.Empty;
                string StrRaisedOn = string.Empty;
                int IkandiAck;
                int AcceptToSettle;
                int RaiseCustomerinvoice;


                if (dataRow["IkandiAcknowledge"] == DBNull.Value || dataRow["IkandiAcknowledge"].ToString() == "")
                {
                    IkandiAck = 0;
                }
                else
                {
                    IkandiAck = Convert.ToInt32(dataRow["IkandiAcknowledge"]);
                }

                if (dataRow["AcceptanceToSettle"] == DBNull.Value || dataRow["AcceptanceToSettle"].ToString() == "")
                {
                    AcceptToSettle = 0;
                }
                else
                {
                    AcceptToSettle = Convert.ToInt32(dataRow["AcceptanceToSettle"]);
                }

                if (dataRow["RaiseCustomerInvoice"] == DBNull.Value || dataRow["RaiseCustomerInvoice"].ToString() == "")
                {
                    RaiseCustomerinvoice = 0;
                }
                else
                {
                    RaiseCustomerinvoice = Convert.ToInt32(dataRow["RaiseCustomerInvoice"]);
                }
                if (dataRow["Owner"] != DBNull.Value)
                {
                    StrOwner = Convert.ToString(dataRow["Owner"]);
                }

                if (IkandiAck == 0)
                {
                    if (dataRow["CreatedOn"] == DBNull.Value || Convert.ToDateTime(dataRow["CreatedOn"]) == DateTime.MinValue)
                    {
                        StrNextActionDate = string.Empty;
                        StrRaisedOn = string.Empty;
                    }
                    else
                    {
                        StrRaisedOn = "RAISED ON: " + Convert.ToDateTime(dataRow["CreatedOn"]).ToString("dd MMM yy (ddd)");
                        CreatedOn = Convert.ToDateTime(dataRow["CreatedOn"]);
                        CreatedOn = CreatedOn.AddDays(1);
                        if (CreatedOn.DayOfWeek == DayOfWeek.Sunday)
                            CreatedOn = CreatedOn.AddDays(1);
                        else if (CreatedOn.DayOfWeek == DayOfWeek.Saturday)
                            CreatedOn = CreatedOn.AddDays(2);
                        StrNextActionDate = "NEXT ACTION DATE: " + CreatedOn.ToString("dd MMM yy (ddd)");
                    }

                    StrAckOn = string.Empty;
                    StrHoldTillDate = string.Empty;
                    StrAcceptedOn = string.Empty;
                    StrInvoiceRaised = string.Empty;
                }

                else if (IkandiAck == 1 && AcceptToSettle == 1 && StrOwner.ToUpper() == "IKANDI")
                {
                    if (dataRow["SettlementDate"] == DBNull.Value || Convert.ToDateTime(dataRow["SettlementDate"]) == DateTime.MinValue)
                        StrAcceptedOn = string.Empty;
                    else
                        StrAcceptedOn = "ACCEPTED ON: " + Convert.ToDateTime(dataRow["SettlementDate"]).ToString("dd MMM yy (ddd)");


                    StrRaisedOn = string.Empty;
                    StrNextActionDate = string.Empty;
                    StrAckOn = string.Empty;
                    StrInvoiceRaised = string.Empty;
                }
                else if (IkandiAck == 1 && RaiseCustomerinvoice == 0)
                {
                    if (dataRow["AcknowledgementDate"] == DBNull.Value || Convert.ToDateTime(dataRow["AcknowledgementDate"]) == DateTime.MinValue)
                        StrAckOn = string.Empty;
                    else
                        StrAckOn = "Acknowledged on: " + Convert.ToDateTime(dataRow["AcknowledgementDate"]).ToString("dd MMM yy (ddd)");

                    if (dataRow["HoldTillDate"] == DBNull.Value || Convert.ToDateTime(dataRow["HoldTillDate"]) == DateTime.MinValue)
                        StrHoldTillDate = string.Empty;
                    else
                        StrHoldTillDate = "NEXT ACTION DATE :" + Convert.ToDateTime(dataRow["HoldTillDate"]).ToString("dd MMM yy (ddd)");
                    StrRaisedOn = string.Empty;
                    StrNextActionDate = string.Empty;
                    StrAcceptedOn = string.Empty;
                    StrInvoiceRaised = string.Empty;
                }

                else if (IkandiAck == 1 && RaiseCustomerinvoice == 1)
                {
                    if (dataRow["SettlementDate"] == DBNull.Value || Convert.ToDateTime(dataRow["SettlementDate"]) == DateTime.MinValue)
                        StrAcceptedOn = string.Empty;
                    else
                        StrAcceptedOn = "ACCEPTED ON :" + Convert.ToDateTime(dataRow["SettlementDate"]).ToString("dd MMM yy (ddd)");

                    if (dataRow["HoldTillDate"] == DBNull.Value || Convert.ToDateTime(dataRow["HoldTillDate"]) == DateTime.MinValue)
                        StrInvoiceRaised = string.Empty;
                    else
                        StrInvoiceRaised = "RAISED INVOICE ON :" + Convert.ToDateTime(dataRow["HoldTillDate"]).ToString("dd MMM yy (ddd)");

                    StrAckOn = string.Empty;
                    StrHoldTillDate = string.Empty;
                    StrRaisedOn = string.Empty;
                    StrNextActionDate = string.Empty;
                }


                Status = Status + "\n" + ((StrRaisedOn != "") ? StrRaisedOn + "\n" : "") + ((StrNextActionDate != "") ? StrNextActionDate + "\n" : "") + ((StrAckOn != "") ? StrAckOn + "\n" : "") + ((StrHoldTillDate != "") ? StrHoldTillDate + "\n" : "") + ((StrAcceptedOn != "") ? StrAcceptedOn + "\n" : "") + StrInvoiceRaised;


                cell = new PDFCell(Status, iKandi.Common.ContentAlignment.Horizontal);
                cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                row.Add(cell);

                cell = new PDFCell((dataRow["MerchantRemarks"] == DBNull.Value) ? string.Empty : Convert.ToString(dataRow["MerchantRemarks"]), iKandi.Common.ContentAlignment.Horizontal);
                cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                row.Add(cell);


                cell = new PDFCell((dataRow["DocumentationRemarks"] == DBNull.Value) ? string.Empty : Convert.ToString(dataRow["DocumentationRemarks"]), iKandi.Common.ContentAlignment.Horizontal);
                cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                row.Add(cell);
                gen.Rows.Add(row);
            }

            gen.GeneratePDF();
            return pdfFilePath;

        }

        # region Private method


        private bool IsFieldPermitted(DataTable dtPermission, string Value)
        {
            dtPermission.DefaultView.RowFilter = "FieldId='" + Value + "'";
            DataView dv = dtPermission.DefaultView;
            if (dv.Count > 0)
                return true;
            else
                return false;
        }
        private string GetOrderSummarySortedParamaterName(int Id)
        {
            string name = string.Empty;

            if (Id == 1)
            {
                name = "BUYER";
            }
            else if (Id == 2)
            {
                name = "STYLE NUMBER";
            }

            else if (Id == 3)
            {
                name = "DEPARTMENT";
            }

            else if (Id == 4)
            {
                name = "EX-FACTORY";
            }

            else if (Id == 5)
            {
                name = "STATUS";
            }

            return name;

        }

        private string GetStyleCurrentUpdateData(SamplingStatus ss)
        {
            StringBuilder sb = new StringBuilder();

            if (ss.CurrentUpdate.Count > 0)
            {
                StyleCurrentUpdate objStyleCurreUpdate = null;
                objStyleCurreUpdate = ss.CurrentUpdate.Find(delegate(StyleCurrentUpdate s) { return (s.Type == StyleCurrentUpdates.On_Machine_Or_Finishing_Or_Ready_For_Dispatch && s.StyleId == ss.StyleID); });
                string str = GetStyleCurrentUpdateCurrentRowValue(objStyleCurreUpdate, "On Machine/Finishing/Ready for dispatch :");
                sb.Append(str);

                if (str == string.Empty)
                {
                    objStyleCurreUpdate = null;
                    objStyleCurreUpdate = ss.CurrentUpdate.Find(delegate(StyleCurrentUpdate s) { return (s.Type == StyleCurrentUpdates.Fabric_Issued_For_Cutting && s.StyleId == ss.StyleID); });
                    str = GetStyleCurrentUpdateCurrentRowValue(objStyleCurreUpdate, "Fabric issued for Cutting :");
                    sb.Append(str);

                    if (str == string.Empty)
                    {
                        objStyleCurreUpdate = null;
                        objStyleCurreUpdate = ss.CurrentUpdate.Find(delegate(StyleCurrentUpdate s) { return (s.Type == StyleCurrentUpdates.Issued_For_Pattern_Making && s.StyleId == ss.StyleID); });
                        str = GetStyleCurrentUpdateCurrentRowValue(objStyleCurreUpdate, "Issued for Pattern Making :");
                        sb.Append(str);

                        if (str == string.Empty)
                        {
                            objStyleCurreUpdate = null;
                            objStyleCurreUpdate = ss.CurrentUpdate.Find(delegate(StyleCurrentUpdate s) { return (s.Type == StyleCurrentUpdates.Fabric_Sampling_Program_Issued && s.StyleId == ss.StyleID); });
                            str = GetStyleCurrentUpdateCurrentRowValue(objStyleCurreUpdate, "Fabric Sampling Program Issued : ");
                            sb.Append(str);
                        }
                    }
                }
            }
            else
            {
                sb.Append(string.Empty);
            }

            return sb.ToString();
        }

        private string GetStyleCurrentUpdateCurrentRowValue(StyleCurrentUpdate objStyleCurreUpdate, string text)
        {
            StringBuilder sb = new StringBuilder();

            if (objStyleCurreUpdate != null)
            {
                if (objStyleCurreUpdate.IsChecked == true)
                {
                    sb.Append(text);
                    sb.Append(objStyleCurreUpdate.Date.ToString("dd MMM yy (ddd)"));
                    sb.Append("\n \n");
                }
                else
                {
                    sb.Append(string.Empty);
                }
            }
            else
            {
                sb.Append(string.Empty);
            }

            return sb.ToString();
        }

        #endregion

        # region ManageOrderReport

        public string GenerateManageOrderReport(int PageSize, int PageIndex, string SearchText, int ClientId, string Year, int UnitId, int DateType, int StatusMode, int StatusModeSequence, int OrderBy1, int OrderBy2, int OrderBy3, int OrderBy4, string FromDate, string ToDate, int BuyingHouseId, int desigId, int DeptId, int UserId, int SalesView, string SessionId, string BuyingHouseName, string StatusName, string StatusSequenceName, string UnitName, int ClientDeptId, string ClientDeptName, int OrderType, int IsUnshipped, int TotalCount, int AM, int OutHouse, int ClientParentDeptId,string ParentDeptName)//Gajendra Paging
        {


            string fileName = "Order Summary Report -" + DateTime.Now.ToString("dd MMM yyy") + ".pdf";
            try
            {

                if (!Directory.Exists(Constants.TEMP_FOLDER_PATH))
                    Directory.CreateDirectory(Constants.TEMP_FOLDER_PATH);

                string pdfFilePath = Path.Combine(Constants.TEMP_FOLDER_PATH, fileName);

                OrderController OrderControllerInstance = new OrderController();

                DateTime dtFromDate = DateTime.Now;
                if (FromDate == "")
                {
                    dtFromDate = DateTime.MinValue;
                }
                else
                {
                    dtFromDate = DateTime.ParseExact(FromDate, "dd MMM yy (ddd)", null);
                }
                DateTime dtToDate = DateTime.Now;
                if (ToDate == "")
                {
                    dtToDate = DateTime.MinValue;
                }
                else
                {
                    dtToDate = DateTime.ParseExact(ToDate, "dd MMM yy (ddd)", null);
                }

                string strUserID = "";
                List<MOOrderDetails> OrderDetail = null;



                //List<MOOrderDetails> OrderDetail = OrderControllerInstance.GetOrdersBasicInfo(SearchText, Year, dtFromDate, dtToDate, ClientId, DateType, UserId, StatusMode, StatusModeSequence, OrderBy1, OrderBy2, OrderBy3, OrderBy4, strUserID, BuyingHouseId, UnitId, desigId, DeptId, SalesView, SessionId, ClientDeptId, "", OrderType, 1, out TotalCount);//Gajendra Paging
                OrderDetail = OrderControllerInstance.GetOrdersBasicInfo(SearchText,"", Year, dtFromDate, dtToDate, ClientId, DateType, UserId, StatusMode, StatusModeSequence, OrderBy1, OrderBy2, OrderBy3, OrderBy4, strUserID, BuyingHouseId, UnitId, desigId, DeptId, SalesView, SessionId, ClientDeptId, "", OrderType, 1, out TotalCount, AM, IsUnshipped, OutHouse,ClientParentDeptId, 1000);//Surendra2

                //OrderDetail = OrderControllerInstance.GetOrdersBasicInfoForPrint(SearchText, Year, dtFromDate, dtToDate, ClientId, DateType, UserId, StatusMode, StatusModeSequence, OrderBy1, OrderBy2, OrderBy3, OrderBy4, strUserID, BuyingHouseId, UnitId, desigId, DeptId, SalesView, SessionId, ClientDeptId, "", OrderType, IsUnshipped);//Gajendra Paging





                //List<MOOrderDetails> OrderDetail = OrderControllerInstance.GetOrdersBasicInfo(SearchText, Year, dtFromDate, dtToDate, ClientId, DateType, UserId, StatusMode, StatusModeSequence, OrderBy1, OrderBy2, OrderBy3, OrderBy4, strUserID, BuyingHouseId, UnitId, desigId, DeptId, SalesView, SessionId, ClientDeptId, "", OrderType, 1, out TotalCount);//Gajendra Paging
                Color HeaderColor = new Color(System.Drawing.ColorTranslator.FromHtml("#FAFCFF"));
                Color BorderColor = new Color(System.Drawing.ColorTranslator.FromHtml("#A9A9A9"));

                //Added By Ashish on 1/6/2015
                foreach (MOOrderDetails orderDetail in OrderDetail)
                {
                    int Qty = Convert.ToInt32(orderDetail.Quantity);
                    TQty += Qty;
                }

                //PDFTableGenerator gen1 = new PDFTableGenerator(pdfFilePath, "(" + TQty + " " + "Pcs." + ") Order Summary Report (Check Paper Usage before you print)" + "(" + DateTime.Now.ToString("dd MMM yyy") + ")", HeaderColor);
                string tOTALqTY = "Qty:" + " " + string.Format("{0:n0}", TQty) + " " + "Pcs.";
                string Datet = "Date:" + " " + DateTime.Now.ToString("dd MMM yyy");
                string HeaderText2 = "(Check Paper Usage before you print)";
                PDFTableGenerator gen = new PDFTableGenerator(pdfFilePath, tOTALqTY, "Order Summary Report", HeaderText2, Datet, HeaderColor);

                //gen.CellHeight = 200; // Height of the main grid
                gen.IsHeaderTable = true; // To determind weather a table before main grid is added
                gen.HeaderTableBodyHeight = 30;
                gen.HeaderTableHeaderHeight = 30;
                gen.CellBorderColor = "#A9A9A9";




                string DataTypeText = "";
                if (DateType == 1)
                {
                    DataTypeText = "Exfact.";
                }
                if (DateType == 2)
                {
                    DataTypeText = "DC.";
                }
                if (DateType == 3)
                {
                    DataTypeText = "ORDERDATE.";
                }

                string ClientName = string.Empty;
                if (ClientId == -1)
                {
                    ClientName = "All";
                }
                else
                {
                    List<Client> clients = this.ClientDataProviderInstance.GetAllClients();
                    Client objClient = clients.Find(delegate(Client c) { return (c.ClientID == ClientId); });
                    ClientName = objClient.CompanyName;
                }

                string fromDate = string.Empty;
                if ((dtFromDate == DateTime.MinValue) || (dtFromDate == Convert.ToDateTime("1753-01-01")))
                {
                    fromDate = string.Empty;
                }
                else
                {
                    fromDate = dtFromDate.ToString("dd MMM yy (ddd)");
                }

                string toDate = string.Empty;
                if ((dtToDate == DateTime.MinValue) || (dtToDate == Convert.ToDateTime("1753-01-01")))
                {
                    toDate = string.Empty;
                }
                else
                {
                    toDate = dtToDate.ToString("dd MMM yy (ddd)");
                }
                //abhishek on 4/11/2016
                string OrderTypestr = string.Empty;
                if (OrderType == -1)
                    OrderTypestr = "ALL";
                else if (OrderType == 2)
                    OrderTypestr = "Kasuka though BIPL";
                else if (OrderType == 3)
                    OrderTypestr = "Kasuka through IKANDI";
                else
                {
                    OrderTypestr = "ALL";
                }
                string strIsUnshipped = string.Empty;
                if (IsUnshipped == 1)
                    strIsUnshipped = "shipped";
                else if (IsUnshipped == 2)
                    strIsUnshipped = "Unshipped";


                //end 
                gen.HeaderTableColumns = new List<PDFHeader>(); // create the instance Header of the table before the Main grid
                gen.HeaderTableColumns.Add(new PDFHeader("Search", iKandi.Common.ContentAlignment.Horizontal, 8));
                gen.HeaderTableColumns.Add(new PDFHeader("Type", iKandi.Common.ContentAlignment.Horizontal, 8));
                gen.HeaderTableColumns.Add(new PDFHeader("YEAR", iKandi.Common.ContentAlignment.Horizontal, 8));
                gen.HeaderTableColumns.Add(new PDFHeader("From", iKandi.Common.ContentAlignment.Horizontal, 10));
                gen.HeaderTableColumns.Add(new PDFHeader("To", iKandi.Common.ContentAlignment.Horizontal, 10));
                gen.HeaderTableColumns.Add(new PDFHeader("BUYING HOUSE", iKandi.Common.ContentAlignment.Horizontal, 10));
                gen.HeaderTableColumns.Add(new PDFHeader("CLIENT", iKandi.Common.ContentAlignment.Horizontal, 10));
                gen.HeaderTableColumns.Add(new PDFHeader("Order Type", iKandi.Common.ContentAlignment.Horizontal, 15));
                gen.HeaderTableColumns.Add(new PDFHeader("Pare.Dept", iKandi.Common.ContentAlignment.Horizontal, 15));
                gen.HeaderTableColumns.Add(new PDFHeader("DEPT", iKandi.Common.ContentAlignment.Horizontal, 10));
                gen.HeaderTableColumns.Add(new PDFHeader("STATUS ", iKandi.Common.ContentAlignment.Horizontal, 13));
                gen.HeaderTableColumns.Add(new PDFHeader("UPTO", iKandi.Common.ContentAlignment.Horizontal, 13));
                gen.HeaderTableColumns.Add(new PDFHeader("Unit", iKandi.Common.ContentAlignment.Horizontal, 10));
                gen.HeaderTableColumns.Add(new PDFHeader("Shipp Status", iKandi.Common.ContentAlignment.Horizontal, 10));
                try
                {

                    gen.HeaderTableRows = new List<List<PDFCell>>();     // creater the instance of Rows of the table before Main grid which is List<List<PDFCell>>

                    List<PDFCell> headerTableRow = new List<PDFCell>();  // vreate the instance of the List<PDFCell> which added the individual columns of a particular row

                    PDFCell headerCell = new PDFCell(SearchText, iKandi.Common.ContentAlignment.Horizontal); // create the instance of each column value along with formating
                    headerCell.FontColor = "#0000FF";
                    headerCell.FontSize = 15;
                    headerCell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    headerCell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                    headerTableRow.Add(headerCell); // Add the object the column into a  row  list


                    headerCell = new PDFCell(DataTypeText.ToUpper(), iKandi.Common.ContentAlignment.Horizontal); // create the instance of each column value along with formating
                    headerCell.FontColor = "#0000FF";
                    headerCell.FontSize = 15;
                    headerCell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    headerCell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                    headerTableRow.Add(headerCell); // Add the object the column into a  row  list

                    headerCell = new PDFCell(Year.ToUpper(), iKandi.Common.ContentAlignment.Horizontal); // create the instance of each column value along with formating
                    headerCell.FontColor = "#0000FF";
                    headerCell.FontSize = 15;
                    headerCell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    headerCell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                    headerTableRow.Add(headerCell); // Add the object the column into a  row  list


                    headerCell = new PDFCell(fromDate, iKandi.Common.ContentAlignment.Horizontal); // create the instance of each column value along with formating
                    headerCell.FontColor = "#0000FF";
                    headerCell.FontSize = 15;
                    headerCell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    headerCell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                    headerTableRow.Add(headerCell);


                    headerCell = new PDFCell(toDate, iKandi.Common.ContentAlignment.Horizontal); // create the instance of each column value along with formating
                    headerCell.FontColor = "#0000FF";
                    headerCell.FontSize = 15;
                    headerCell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    headerCell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                    headerTableRow.Add(headerCell);


                    headerCell = new PDFCell(BuyingHouseName.ToUpper(), iKandi.Common.ContentAlignment.Horizontal); // create the instance of each column value along with formating
                    headerCell.FontColor = "#0000FF";
                    headerCell.FontSize = 15;
                    headerCell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    headerCell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                    headerTableRow.Add(headerCell);

                    headerCell = new PDFCell(ClientName.ToUpper(), iKandi.Common.ContentAlignment.Horizontal); // create the instance of each column value along with formating
                    headerCell.FontColor = "#0000FF";
                    headerCell.FontSize = 15;
                    headerCell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    headerCell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                    headerTableRow.Add(headerCell);

                    headerCell = new PDFCell(OrderTypestr.ToUpper(), iKandi.Common.ContentAlignment.Horizontal); // create the instance of each column value along with formating
                    headerCell.FontColor = "#0000FF";
                    headerCell.FontSize = 15;
                    headerCell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    headerCell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                    headerTableRow.Add(headerCell);


                    headerCell = new PDFCell(ParentDeptName, iKandi.Common.ContentAlignment.Horizontal); // create the instance of each column value along with formating
                    headerCell.FontColor = "#0000FF";
                    headerCell.FontSize = 15;
                    headerCell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    headerCell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                    headerTableRow.Add(headerCell);


                    headerCell = new PDFCell(ClientDeptName.ToUpper(), iKandi.Common.ContentAlignment.Horizontal); // create the instance of each column value along with formating
                    headerCell.FontColor = "#0000FF";
                    headerCell.FontSize = 15;
                    headerCell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    headerCell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                    headerTableRow.Add(headerCell);


                    headerCell = new PDFCell(StatusName.ToUpper(), iKandi.Common.ContentAlignment.Horizontal); // create the instance of each column value along with formating
                    headerCell.FontColor = "#0000FF";
                    headerCell.FontSize = 15;
                    headerCell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    headerCell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                    headerTableRow.Add(headerCell);

                    headerCell = new PDFCell(StatusSequenceName.ToUpper(), iKandi.Common.ContentAlignment.Horizontal); // create the instance of each column value along with formating
                    headerCell.FontColor = "#0000FF";
                    headerCell.FontSize = 15;
                    headerCell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    headerCell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                    headerTableRow.Add(headerCell);

                    headerCell = new PDFCell(UnitName.ToString(), iKandi.Common.ContentAlignment.Horizontal); // create the instance of each column value along with formating
                    headerCell.FontColor = "#0000FF";
                    headerCell.FontSize = 15;
                    headerCell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    headerCell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                    headerTableRow.Add(headerCell);

                    headerCell = new PDFCell(strIsUnshipped.ToString(), iKandi.Common.ContentAlignment.Horizontal); // create the instance of each column value along with formating
                    headerCell.FontColor = "#0000FF";
                    headerCell.FontSize = 15;
                    headerCell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    headerCell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                    headerTableRow.Add(headerCell);

                    gen.HeaderTableRows.Add(headerTableRow); // add a row list into a lis of row list   

                    Color HeaderFont = new Color(System.Drawing.ColorTranslator.FromHtml("#4D5763"));
                    var HeaderFontSize = FontFactory.GetFont("trebuchet ms", 17, Font.BOLD, HeaderFont);
                    Font verdanaBold = FontFactory.GetFont("trebuchet ms", 17, Font.BOLD);
                    gen.Columns = new List<PDFHeader>(); // Header of the main grid
                


                    gen.Rows = new List<List<PDFCell>>(); // Rows adding logic of the Main grid              

                    List<PDFCell> row = new List<PDFCell>();
                  
                    string BasicSec = "Basic Info";
                    PDFCell cell = new PDFCell(BasicSec, iKandi.Common.ContentAlignment.Horizontal,15);
                    cell.FontSize = 17;
                    cell.BackGroundColor = "#f9f9fa";
                    cell.FontColor = "#000000";
                    cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    cell.Height = 25;
                    cell.Width = 15;
                  
                    row.Add(cell);

                    string sFabricSection;
                    sFabricSection = "Fabric";
                    //sFabricSection = "Quality/Decription                     Avg         Start ETA      Act Dt/End ETA";
                    cell = new PDFCell(sFabricSection, iKandi.Common.ContentAlignment.Horizontal, "");
                    cell.FontSize = 17;
                    cell.BackGroundColor = "#f9f9fa";
                    cell.FontColor = "#000000";
                    cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    cell.Height = 25;
                    row.Add(cell);

                    string AccessoriesSection = "Accessories";
                    //AccessoriesSection = "Quality           In House  Apprd. on      Recd         Tot        Act Dat/End ETA";
                    cell = new PDFCell(AccessoriesSection, iKandi.Common.ContentAlignment.Horizontal, "");
                    cell.FontSize = 17;
                    cell.BackGroundColor = "#f9f9fa";
                    cell.FontColor = "#000000";
                    cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    cell.Height = 25;
                    row.Add(cell);

                    string TechnicalSection;
                    TechnicalSection = "Technical";
                    //TechnicalSection = "Deliverable                          Target / Actual                            ETA";
                    cell = new PDFCell(TechnicalSection, iKandi.Common.ContentAlignment.Horizontal, "");
                    cell.FontSize = 17;
                    cell.BackGroundColor = "#f9f9fa";
                    cell.FontColor = "#000000";
                    cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    cell.Height = 25;
                    row.Add(cell);

                    string ProductionSection = "Production";
                    //ProductionSection = "                    Today                                     Start ETA";
                    //ProductionSection = "                    OverAll                                     StartETA / End ETA";
                    cell = new PDFCell(ProductionSection, iKandi.Common.ContentAlignment.Horizontal, "");
                    cell.FontSize = 17;
                    cell.BackGroundColor = "#f9f9fa";
                    cell.FontColor = "#000000";
                    cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    cell.Height = 25;
                    row.Add(cell);

                    gen.Rows.Add(row);


                    foreach (MOOrderDetails orderDetail in OrderDetail)
                    {
                        try
                        {
                            List<PDFCell> morow = new List<PDFCell>();

                            // Basic Info section Start
                            #region BasicInfo Section

                            var phrase = new Phrase();
                            string ImagePath = "";
                           // morow[1].Width = 50;
                            phrase.Add(Chunk.NEWLINE);
                            if (orderDetail.IsShiped)
                            {
                                DescriptionForColor = new Color(System.Drawing.ColorTranslator.FromHtml("#A9A9A9"));
                            }
                            else
                            {
                                DescriptionForColor = new Color(System.Drawing.ColorTranslator.FromHtml("#807F80"));
                            }
                          //abhishek 12/2018
                            string OrderStatus = "";
                            if (orderDetail.IsRepeatWithChanges == true)
                              OrderStatus = orderDetail.IsRepeatWithChanges == true ? "Repeat" : string.Empty;
                            else if (orderDetail.IsRepeat == true)
                              OrderStatus = orderDetail.IsRepeat == true ? "Direct Repeat" : string.Empty;

                            var ListTitleCompFont = FontFactory.GetFont("trebuchet ms", 14, DescriptionForColor);
                            var OrderDate = "";
                            if (orderDetail.bOrderDateRead == true)
                            {
                              OrderDate = orderDetail.ParentOrder.OrderDate.ToString("dd MMM yy (ddd)") + "      "+OrderStatus+"       " + orderDetail.ParentOrder.SerialNumber.ToString();
                            }
                            phrase.Add(new Chunk(OrderDate, ListTitleCompFont));

                            phrase.Add(Chunk.NEWLINE);
                            phrase.Add(Chunk.NEWLINE);
                            phrase.Add(Chunk.NEWLINE);

                            ImagePath = orderDetail.ParentOrder.Style.SampleImageURL1;
                            if (ImagePath != "")
                            {
                                if (File.Exists(HttpContext.Current.Server.MapPath("~/Uploads/Style/thumb-" + ImagePath)))
                                {
                                    iTextSharp.text.Image image1 = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath("~/Uploads/Style/thumb-" + ImagePath));
                                    image1.Alignment = Element.ALIGN_CENTER;
                                    image1.ScalePercent(20f);
                                    image1.ScaleAbsolute(80f, 115.25f);
                                    Chunk imageChunk1 = new Chunk(image1, 0, 0);
                                    phrase.Add(imageChunk1);
                                }
                                else
                                {
                                    iTextSharp.text.Image image1 = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath("~/Uploads/Style/index.jpg"));
                                    image1.Alignment = Element.ALIGN_CENTER;
                                    image1.ScalePercent(20f);
                                    image1.ScaleAbsolute(80f, 115.25f);
                                    Chunk imageChunk1 = new Chunk(image1, 0, 0);
                                    phrase.Add(imageChunk1);
                                }

                            }
                            else
                            {
                                iTextSharp.text.Image image1 = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath("~/Uploads/Style/index.jpg"));
                                image1.Alignment = Element.ALIGN_CENTER;
                                image1.ScalePercent(20f);
                                image1.ScaleAbsolute(80f, 115.25f);
                                Chunk imageChunk1 = new Chunk(image1, 0, 0);
                                phrase.Add(imageChunk1);
                            }


                            phrase.Add(Chunk.NEWLINE);
                            phrase.Add(Chunk.NEWLINE);

                            if (orderDetail.IsShiped)
                            {
                                StyleForColor = new Color(System.Drawing.ColorTranslator.FromHtml("#A9A9A9"));
                            }
                            else
                            {
                                if (orderDetail.IsRiskTask == 1)
                                {
                                    StyleForColor = new Color(System.Drawing.ColorTranslator.FromHtml("#000000"));
                                }
                                else
                                {
                                    StyleForColor = new Color(System.Drawing.ColorTranslator.FromHtml("#FF0000"));
                                }
                            }

                            var StyleFont = FontFactory.GetFont("trebuchet ms", 14, StyleForColor);

                            var StyleNumber = "";
                            if (orderDetail.bStylelNo)
                            {
                                StyleNumber = orderDetail.ParentOrder.Style.StyleNumber;
                            }
                            phrase.Add(new Chunk(StyleNumber, StyleFont));


                            phrase.Add(Chunk.NEWLINE);
                            phrase.Add(Chunk.NEWLINE);



                            var Description = "";
                            if (orderDetail.bBusinessDescriptionRead)
                            {
                                Description = orderDetail.Description;
                            }
                            var DescriptionFont = FontFactory.GetFont("trebuchet ms", 11, DescriptionForColor);
                            phrase.Add(new Chunk(Description, DescriptionFont));

                            phrase.Add(Chunk.NEWLINE);
                            phrase.Add(Chunk.NEWLINE);

                            var Department = "";
                            var LineNo = "";
                            var ContactNo = "";
                            if (orderDetail.bDepartmentRead)
                            {
                                Department = orderDetail.ParentOrder.Style.cdept.Name;
                            }
                            if (orderDetail.bLineNo)
                            {
                                LineNo = orderDetail.LineItemNumber;
                            }
                            if (orderDetail.bContractNo)
                            {
                                ContactNo = orderDetail.ContractNumber;
                            }
                            var DeptSection = "";
                            DeptSection = Department + "                    " + LineNo + "               " + ContactNo;


                            var DeptSectionFont = FontFactory.GetFont("Arial", 11, DescriptionForColor);
                            phrase.Add(new Chunk(DeptSection, DeptSectionFont));

                            phrase.Add(Chunk.NEWLINE);
                            phrase.Add(Chunk.NEWLINE);

                            var Symbol = Constants.GetCurrencySymbalByCurrencyType(orderDetail.ParentOrder.Costing.ConvertTo);
                            string Price = "";

                            if (LoggedInUser.UserData.Company == Company.Boutique)
                            {
                                Price = orderDetail.ParentOrder.BiplPrice.ToString();
                            }
                            if (LoggedInUser.UserData.Company == Company.iKandi)
                            {
                                Price = orderDetail.iKandiPrice.ToString();
                            }

                            string lblPriceSymbol = orderDetail.bIKANDIPriceGrossRead == true ? "Rs. " : "";
                            string lblikandiGross = orderDetail.bIKANDIPriceGrossRead == true ? Convert.ToString(orderDetail.BoutiqueBusiness) + " " + "Lac" : "";

                            //var PriceSection = "";
                            //if (orderDetail.bBIPLPrice)
                            //{
                            //    // PriceSection = Symbol + " " + Price + "               " + lblPriceSymbol + lblikandiGross;
                            //    PriceSection = Symbol + " " + Math.Round(Convert.ToDecimal(Price), 2, MidpointRounding.AwayFromZero);
                            //}

                            //var PriceFont = FontFactory.GetFont("trebuchet ms", 11, Color.BLUE);

                            //phrase.Add(new Chunk(PriceSection, PriceFont));

                            phrase.Add(Chunk.NEWLINE);
                            phrase.Add(Chunk.NEWLINE);

                            //var DiscountFont = FontFactory.GetFont("trebuchet ms", 11, DescriptionForColor);
                            //string lblIkandiPriceTag = orderDetail.bIKANDIPriceGrossRead == true ? Constants.GetCurrencySymbalByCurrencyType(orderDetail.ParentOrder.Costing.ConvertTo) : "";
                            //string lblIkandiDiscount = "";
                            //if (orderDetail.bIKANDIPriceRead)
                            //{
                            //    if (Convert.ToString(orderDetail.discount).Length >= 5)
                            //    {
                            //        lblIkandiDiscount = orderDetail.bIKANDIPriceGrossRead == true ? orderDetail.discount.ToString().Substring(0, 5) : "";
                            //    }
                            //    else
                            //    {
                            //        lblIkandiDiscount = orderDetail.bIKANDIPriceGrossRead == true ? orderDetail.discount.ToString() : "";
                            //    }
                            //}
                            //string lblMargin = orderDetail.bMarginRead == true ? orderDetail.Margin.ToString() + "%" : "";

                            ////var DiscountSection = lblIkandiPriceTag + " " + lblIkandiDiscount + "         " + lblMargin;
                            //var DiscountSection = lblIkandiPriceTag + " " + lblIkandiDiscount;

                            //phrase.Add(new Chunk(DiscountSection, DiscountFont));

                            //added by abhishek on 2/2/2016
                            //----------------------------for--photo shot-----------------------------------//
                            phrase.Add(Chunk.NEWLINE);
                            phrase.Add(Chunk.NEWLINE);
                            string Weightgsm = "";
                            if ((orderDetail.ParentOrder as iKandi.Common.Order).Costing.Weight.ToString() != "" && (orderDetail.ParentOrder as iKandi.Common.Order).Costing.Weight.ToString()!="0")
                            {
                              Weightgsm=(orderDetail.ParentOrder as iKandi.Common.Order).Costing.Weight.ToString();

                              var photoshotDate = "";
                              if (orderDetail.IsPhotoShoot.ToString() != "")
                              {
                                if (Convert.ToDateTime(orderDetail.IsPhotoShoot) != DateTime.MinValue)
                                {
                                  photoshotDate = orderDetail.IsPhotoShoot.ToString("dd MMM (ddd)");
                                }
                              }
                              Weightgsm = "Weight: " + Weightgsm + " gms";
                              var WeightFont = FontFactory.GetFont("trebuchet ms", 11, DescriptionForColor);
                              phrase.Add(new Chunk(Weightgsm, WeightFont));
                            }

                            phrase.Add(Chunk.NEWLINE);
                          
                            var IsPhotoShot = "";

                            if (orderDetail.PhotoShoot == true)
                            {
                              IsPhotoShot = "Yes";

                              var photoshotDate = "";
                              if (orderDetail.IsPhotoShoot.ToString() != "")
                              {
                                if (Convert.ToDateTime(orderDetail.IsPhotoShoot) != DateTime.MinValue)
                                {
                                  photoshotDate = orderDetail.IsPhotoShoot.ToString("dd MMM (ddd)");
                                }
                              }
                              var photoshotsec = "";
                              photoshotsec = "PhotoShot :" + "  " + IsPhotoShot + "  " + photoshotDate;
                              var PhotoShotFont = FontFactory.GetFont("trebuchet ms", 11, DescriptionForColor);
                              phrase.Add(new Chunk(photoshotsec, PhotoShotFont));
                            }


                            phrase.Add(Chunk.NEWLINE);
                            phrase.Add(Chunk.NEWLINE);

                            //--------------------for-Future-task-show--------------------------//
                            phrase.Add(Chunk.NEWLINE);
                            phrase.Add(Chunk.NEWLINE);
                            var DelayTask = Regex.Replace(orderDetail.DelayTask, "<.*?>", string.Empty); ;
                            var isusercounttask = DelayTask;
                            var usercounttaskFont = FontFactory.GetFont("trebuchet ms", 11, DescriptionForColor);
                            phrase.Add(new Chunk(isusercounttask, usercounttaskFont));


                            phrase.Add(Chunk.NEWLINE);
                            phrase.Add(Chunk.NEWLINE);

                            //end by abhishek on 2/2/2016

                            phrase.Add(Chunk.NEWLINE);
                            phrase.Add(Chunk.NEWLINE);
                            //var lblpopending = "";
                            //var lblPOCostingDiff = "";
                            //if (orderDetail.bPriceVAriationRead)
                            //{
                            //    lblpopending = orderDetail.Pricevariation;
                            //}
                            //if (orderDetail.bPOPendingRead)
                            //{
                            //    lblPOCostingDiff = orderDetail.POpending;
                            //}
                            ////var POPendingCosting = lblpopending + " " + lblPOCostingDiff;
                            //var POPendingCosting = "";

                            //var PendingFont = FontFactory.GetFont("trebuchet ms", 11, Color.RED);

                            //phrase.Add(new Chunk(POPendingCosting, PendingFont));

                            phrase.Add(Chunk.NEWLINE);
                            phrase.Add(Chunk.NEWLINE);

                            if (orderDetail.bBasicInfoRemarkRead)
                            {
                                //  string shipRemark = orderDetail.SanjeevRemarks.ToString().ToLower();
                                //if (shipRemark != "")
                                //{
                                //    string shippingRemark;
                                //    shippingRemark = Constants.GetLastComments(shipRemark.ToString(), "~", "....", 100);

                                //    if (shippingRemark.Trim() == "")
                                //    {

                                //        shippingRemark = Constants.GetComment(shipRemark.ToString(), "~", "....", 100);
                                //    }

                                //    string[] shRemark = shippingRemark.Split('(');
                                //    string sOnlyRemark = shRemark[1].ToString();
                                //    string[] sOnlyRemarkArr = sOnlyRemark.Split(')');
                                //    string sRemarkDate = sOnlyRemarkArr[0].ToString();
                                //    string sLatestRemarkFull = sOnlyRemarkArr[1].ToString();

                                //    string sLatestRemark = "";
                                //    if (sLatestRemarkFull.Length >= 30)
                                //    {
                                //        sLatestRemark = sLatestRemarkFull.Substring(0, 30);
                                //    }
                                //    else
                                //    {
                                //        sLatestRemark = sLatestRemarkFull;
                                //    }
                                //    lblShipping = sRemarkDate + sLatestRemark;

                                //}
                            }

                            //var ShippingRemarkFont = FontFactory.GetFont("trebuchet ms", 11, DescriptionForColor);

                            //phrase.Add(new Chunk(lblShipping, ShippingRemarkFont));

                            //phrase.Add(Chunk.NEWLINE);
                            //phrase.Add(Chunk.NEWLINE);

                            PDFCell BasicCell = new PDFCell(phrase); 
                            //cell.BackGroundColor = Constants.GetSerialNumberColor(orderDetail.ExFactory);                       
                            BasicCell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                            BasicCell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_TOP;
                            BasicCell.Height = 200;
                            BasicCell.Width = 15;
                          
                      
                            morow.Add(BasicCell);
                            
                            phrase.Add(Chunk.NEWLINE);
                            gen.Rows.Add(morow);

                            #endregion BasicInfo Section
                            // BasicInfo Section End

                            // Fabric Section Start    
                            #region Fabric Section

                            List<PDFCell> FabricRow = new List<PDFCell>();
                            PdfPTable pt;
                            pt = new PdfPTable(6) { WidthPercentage = 150 };
                            var FabPhrase = new Phrase();



                            FabPhrase.Add(Chunk.NEWLINE);
                            var BIHFabric = "";
                            if (orderDetail.FBIHDateRead)
                            {
                                if (orderDetail.BulkTarget != DateTime.MinValue)
                                {
                                    BIHFabric = "B.I.H : " + orderDetail.BulkTarget.ToString("dd MMM yy (ddd)");
                                }
                            }
                            Color BIHForColor = new Color(System.Drawing.ColorTranslator.FromHtml(orderDetail.BIHForColor));

                            var FabricHeaderFont = FontFactory.GetFont("trebuchet ms", 17, Font.BOLD, BIHForColor);
                            FabPhrase.Add(new Chunk(BIHFabric, FabricHeaderFont));
                            Color bBIHcolor = new Color(System.Drawing.ColorTranslator.FromHtml(orderDetail.BIHBackColor));
                            pt.AddCell(new PdfPCell(FabPhrase) { Colspan = 6, BorderColor = BorderColor, BackgroundColor = bBIHcolor, HorizontalAlignment = Element.ALIGN_CENTER, FixedHeight = 40, VerticalAlignment = Element.ALIGN_TOP, PaddingBottom = 5 });
                            FabPhrase.Add(Chunk.NEWLINE);
                            FabPhrase.Add(Chunk.NEWLINE);




                            if (orderDetail.FQualityRead)
                            {
                                if (orderDetail.Fabric1 != "")
                                {
                                    var Fabric1 = orderDetail.Fabric1;
                                    var Fab1STCAverage = "";
                                    var Temp1aVG = "";
                                    var Fabric1Percent = "";
                                    var QuantityAvl1 = "";
                                    var FinalOrderFabric1 = "";
                                    if (orderDetail.FOrdRead)
                                    {
                                        Fab1STCAverage = orderDetail.Fabric1STCAverage.ToString();
                                    }
                                    Temp1aVG = orderDetail.Fabric1STCAverage.ToString();
                                    if (orderDetail.CutWidth1 != 0)//abhishek
                                    {
                                        Fab1STCAverage = Fab1STCAverage + "/" + orderDetail.CutWidth1 + " In";
                                    }
                                    if (orderDetail.FPerInhouseRead)
                                    {
                                        if (orderDetail.ParentOrder.FabricInhouseHistory.Fabric1Percent != 0)
                                        {
                                            Fabric1Percent = orderDetail.ParentOrder.FabricInhouseHistory.Fabric1Percent.ToString() + " %";
                                        }
                                    }
                                    if (orderDetail.FRecdRead)
                                    {
                                        if (orderDetail.QuantityAvl1 != "0"&& orderDetail.QuantityAvl1 != "")
                                        {
                                          QuantityAvl1 = Math.Round(Convert.ToDecimal(orderDetail.QuantityAvl1.Replace(",", ".")), 1, MidpointRounding.AwayFromZero).ToString("G29") + "k";
                                        }
                                    }
                                    if (orderDetail.FFabTotalRead)
                                    {
                                        if (orderDetail.FinalOrderFabric1 != "0")
                                        {
                                            FinalOrderFabric1 = orderDetail.FinalOrderFabric1;
                                        }
                                    }


                                    var Fab1NamePhrase = new Phrase();
                                    Color Fabric1NameBackColor = new Color(System.Drawing.ColorTranslator.FromHtml(orderDetail.Fabric1NameBackColor));
                                    Color Fabric1NameForColor = new Color(System.Drawing.ColorTranslator.FromHtml(orderDetail.Fabric1NameForColor));
                                    var Fabric1Font = FontFactory.GetFont("trebuchet ms", 11, Font.NORMAL, Fabric1NameForColor);
                                    Fab1NamePhrase.Add(new Chunk(Fabric1, Fabric1Font));
                                    pt.AddCell(new PdfPCell(Fab1NamePhrase) { BorderWidth = 1, Padding = 2, BorderColor = BorderColor, BackgroundColor = Fabric1NameBackColor, HorizontalAlignment = Element.ALIGN_LEFT, FixedHeight = 30, VerticalAlignment = Element.ALIGN_TOP, PaddingTop = 5 });


                                    var Fab1STCAveragePhrase = new Phrase();
                                    Color Percent1BackColor = new Color(System.Drawing.ColorTranslator.FromHtml(orderDetail.Percent1BackColor));
                                    Color Percent1ForColor = new Color(System.Drawing.ColorTranslator.FromHtml(orderDetail.Percent1ForColor));
                                    var Fab1STCAverage1Font = FontFactory.GetFont("trebuchet ms", 11, Font.NORMAL, Percent1ForColor);
                                    Fab1STCAveragePhrase.Add(new Chunk(Fab1STCAverage, Fab1STCAverage1Font));
                                    pt.AddCell(new PdfPCell(Fab1STCAveragePhrase) { BorderWidth = 1, BorderColor = BorderColor, Padding = 2, HorizontalAlignment = Element.ALIGN_CENTER, FixedHeight = 30, VerticalAlignment = Element.ALIGN_TOP, PaddingTop = 5 });


                                    var Fabric1PercentPhrase = new Phrase();
                                    Fabric1PercentPhrase.Add(new Chunk(Fabric1Percent, Fab1STCAverage1Font));
                                    pt.AddCell(new PdfPCell(Fabric1PercentPhrase) { BorderWidth = 1, BorderColor = BorderColor, Padding = 2, BackgroundColor = Percent1BackColor, HorizontalAlignment = Element.ALIGN_CENTER, FixedHeight = 30, VerticalAlignment = Element.ALIGN_TOP, PaddingTop = 5 });
                                    var QuantityAvl1Phrase = new Phrase();
                                    QuantityAvl1Phrase.Add(new Chunk(QuantityAvl1, Fab1STCAverage1Font));
                                    pt.AddCell(new PdfPCell(QuantityAvl1Phrase) { BorderWidth = 1, BorderColor = BorderColor, Padding = 2, HorizontalAlignment = Element.ALIGN_CENTER, FixedHeight = 30, VerticalAlignment = Element.ALIGN_TOP, PaddingTop = 5 });

                                    orderDetail.Fab1InHouseChecked_k = (orderDetail.Fab1InHouseChecked_k == null ? "" : orderDetail.Fab1InHouseChecked_k);
                                    string FabCutWidthAvg = "";
                                    if (orderDetail.Fab1InHouseChecked_k != "0K" && orderDetail.Fab1InHouseChecked_k != "" && orderDetail.Fab1InHouseChecked_k != "0" && orderDetail.Fabric1STCAverage.ToString() != "")
                                    {
                                        if (Temp1aVG == "0")
                                            Temp1aVG = "1";
                                        string fab1CutIssueAvgIn_K = Math.Round(((Convert.ToDecimal(orderDetail.Fab1InHouseChecked_k.Replace("k", "")) / Convert.ToDecimal(Temp1aVG.ToString()))), 1, MidpointRounding.AwayFromZero).ToString("G29");
                                        FabCutWidthAvg = "(" + fab1CutIssueAvgIn_K + "k Pcs)";
                                        FabCutWidthAvg = FabCutWidthAvg == " (0k Pcs)" ? "" : FabCutWidthAvg;
                                    }
                                    //abhishek
                                    //var QuantityFab1Phrase = new Phrase();
                                    //QuantityFab1Phrase.Add(new Chunk(orderDetail.Fab1InHouseChecked_k + " " + FabCutWidthAvg, Fab1STCAverage1Font));
                                    //pt.AddCell(new PdfPCell(QuantityFab1Phrase) { BorderWidth = 1, BorderColor = BorderColor, Padding = 2, HorizontalAlignment = Element.ALIGN_CENTER, FixedHeight = 30, VerticalAlignment = Element.ALIGN_TOP, PaddingTop = 5 });



                                    //var FinalOrderFabric1Phrase = new Phrase();
                                    //FinalOrderFabric1Phrase.Add(new Chunk(FinalOrderFabric1, Fab1STCAverage1Font));
                                    //pt.AddCell(new PdfPCell(FinalOrderFabric1Phrase) { BorderWidth = 1, BorderColor = BorderColor, Padding = 2, HorizontalAlignment = Element.ALIGN_CENTER, FixedHeight = 30, VerticalAlignment = Element.ALIGN_TOP, PaddingTop = 5 });



                                    var FinalOrderFabric1Phrase = new Phrase();
                                    FinalOrderFabric1Phrase.Add(new Chunk(orderDetail.Fab1InHouseChecked_k + " " + FabCutWidthAvg, Fab1STCAverage1Font));
                                    pt.AddCell(new PdfPCell(FinalOrderFabric1Phrase) { BorderWidth = 1, BorderColor = BorderColor, Padding = 2, HorizontalAlignment = Element.ALIGN_CENTER, FixedHeight = 30, VerticalAlignment = Element.ALIGN_TOP, PaddingTop = 5 });
                                    FinalOrderFabric1Phrase.Add(Chunk.NEWLINE);


                                    string finalOrder1 = "";
                                    if (orderDetail.FinalOrderFabric1 != "0" && orderDetail.FinalOrderFabric1 != "")
                                    {
                                      finalOrder1 = Math.Round(Convert.ToDecimal(orderDetail.FinalOrderFabric1), 1, MidpointRounding.AwayFromZero).ToString("G29") + "k";
                                    }
                                    var Fab1RequiredQtyPhrase = new Phrase();
                                    var Fabric1RequiredQtyFont = FontFactory.GetFont("trebuchet ms", 9, Font.NORMAL, Percent1ForColor);
                                    Fab1RequiredQtyPhrase.Add(new Chunk(finalOrder1, Fab1STCAverage1Font));
                                    pt.AddCell(new PdfPCell(Fab1RequiredQtyPhrase) { BorderWidth = 1, BorderColor = BorderColor, Padding = 2, HorizontalAlignment = Element.ALIGN_CENTER, FixedHeight = 30, VerticalAlignment = Element.ALIGN_TOP, PaddingTop = 5 });
                                    Fab1RequiredQtyPhrase.Add(Chunk.NEWLINE);

                                    var Fabric1Details = "";
                                    if (orderDetail.FQualityRead)
                                    {
                                        Fabric1Details = orderDetail.Fabric1Details + " " + orderDetail.ParentOrder.FabricApprovalDetails.F5BulkStatus;
                                    }
                                    var TotalSummary1 = "";
                                    if (orderDetail.FFabSummaryRead)
                                    {
                                        if (orderDetail.TotalSummary1.Length > 16)
                                        {
                                            TotalSummary1 = orderDetail.TotalSummary1.Substring(0, 16);
                                        }
                                        else
                                        {
                                            TotalSummary1 = orderDetail.TotalSummary1;
                                        }
                                    }

                                    var Fab1StartEta = "";
                                    var Fabric1ENDETA = "";
                                    if (orderDetail.FFabStartETARead)
                                    {
                                        if (orderDetail.fabric1ETA != DateTime.MinValue)
                                        {
                                            Fab1StartEta = orderDetail.fabric1ETA.ToString("dd MMM");
                                        }
                                    }
                                    if (orderDetail.FFabEndETARead)
                                    {
                                        if (orderDetail.Fabric1ENDETA != DateTime.MinValue)
                                        {
                                            Fabric1ENDETA = orderDetail.Fabric1ENDETA.ToString("dd MMM");
                                        }
                                    }


                                    var Fab1DetailPhrase = new Phrase();
                                    Color BulkApproval1BackColor = new Color(System.Drawing.ColorTranslator.FromHtml(orderDetail.BulkApproval1BackColor));
                                    Color BulkApproval1ForColor = new Color(System.Drawing.ColorTranslator.FromHtml(orderDetail.BulkApproval1ForColor));
                                    var Fabric1DetailFont = FontFactory.GetFont("trebuchet ms", 9, Font.NORMAL, BulkApproval1ForColor);
                                    Fab1DetailPhrase.Add(new Chunk(Fabric1Details, Fabric1DetailFont));
                                    pt.AddCell(new PdfPCell(Fab1DetailPhrase) { BorderWidth = 1, BorderColor = BorderColor, BackgroundColor = BulkApproval1BackColor, HorizontalAlignment = Element.ALIGN_LEFT, FixedHeight = 25, VerticalAlignment = Element.ALIGN_TOP, PaddingTop = 5 });

                                    if (TotalSummary1 != "")
                                    {

                                        if (orderDetail.Caption1 == "Black")
                                        {
                                            SummryColor = new Color(System.Drawing.ColorTranslator.FromHtml("#807f80"));
                                        }
                                        if (orderDetail.Caption1 == "Red")
                                        {
                                            SummryColor = new Color(System.Drawing.ColorTranslator.FromHtml("#ff3300"));
                                        }
                                        if (orderDetail.Caption1 == "Green")
                                        {
                                            SummryColor = new Color(System.Drawing.ColorTranslator.FromHtml("#006600"));
                                        }
                                        if (orderDetail.IsShiped)
                                        {
                                            SummryColor = Color.GRAY;
                                        }

                                    }

                                    SummryColor = SummryColor == null ? Color.WHITE : SummryColor;
                                    var TotalSummary1Phrase = new Phrase();
                                    var TotalSummary1Font = FontFactory.GetFont("trebuchet ms", 9, Font.NORMAL, SummryColor);
                                    TotalSummary1Phrase.Add(new Chunk(TotalSummary1, TotalSummary1Font));
                                    pt.AddCell(new PdfPCell(TotalSummary1Phrase) { BorderWidth = 1,Colspan=2, BorderColor = BorderColor, HorizontalAlignment = Element.ALIGN_LEFT, FixedHeight = 25, VerticalAlignment = Element.ALIGN_TOP, PaddingTop = 5 });
                                    //abhishek strikeof ETA 23/9/2016

                                    var Fab1Strikeof = "";
                                    if (orderDetail.StrikeOff1ETA != DateTime.MinValue)
                                    {
                                        Fab1Strikeof = orderDetail.StrikeOff1ETA.ToString("dd MMM");
                                    }
                                    var Fabric1Strikeof = new Phrase();
                                    Color Strikeof1BackColor = new Color(System.Drawing.ColorTranslator.FromHtml(orderDetail.StrikeOfBackColor1));
                                    Color Strikeof1ForColor = new Color(System.Drawing.ColorTranslator.FromHtml(orderDetail.StrikeOfForeColor1));
                                    var Fabric1StrikeOfETAFont = FontFactory.GetFont("trebuchet ms", 9, Font.NORMAL, Strikeof1ForColor);
                                    Fabric1Strikeof.Add(new Chunk(Fab1Strikeof, Fabric1StrikeOfETAFont));
                                    pt.AddCell(new PdfPCell(Fabric1Strikeof) { BorderWidth = 1, BorderColor = BorderColor, BackgroundColor = Strikeof1BackColor, HorizontalAlignment = Element.ALIGN_CENTER, FixedHeight = 25, VerticalAlignment = Element.ALIGN_TOP, PaddingTop = 5 });
                                    Fabric1Strikeof.Add(Chunk.NEWLINE);


                                    var Fab1StartEtaPhrase = new Phrase();
                                    Color StartETA1BackColor = new Color(System.Drawing.ColorTranslator.FromHtml(orderDetail.StartETA1BackColor));
                                    Color StartETA1ForColor = new Color(System.Drawing.ColorTranslator.FromHtml(orderDetail.StartETA1ForColor));
                                    var Fab1StartEtaeFont = FontFactory.GetFont("trebuchet ms", 9, Font.NORMAL, StartETA1ForColor);
                                    Fab1StartEtaPhrase.Add(new Chunk(Fab1StartEta, Fab1StartEtaeFont));
                                    pt.AddCell(new PdfPCell(Fab1StartEtaPhrase) { BorderWidth = 1, BorderColor = BorderColor, BackgroundColor = StartETA1BackColor, HorizontalAlignment = Element.ALIGN_CENTER, FixedHeight = 25, VerticalAlignment = Element.ALIGN_TOP, PaddingTop = 5 });
                         

                                    var Fabric1ENDETAPhrase = new Phrase();
                                    Color ENDETA1BackColor = new Color(System.Drawing.ColorTranslator.FromHtml(orderDetail.ENDETA1BackColor));
                                    Color ENDETA1ForColor = new Color(System.Drawing.ColorTranslator.FromHtml(orderDetail.ENDETA1ForColor));
                                    var Fabric1ENDETAFont = FontFactory.GetFont("trebuchet ms", 9, Font.NORMAL, ENDETA1ForColor);
                                    Fabric1ENDETAPhrase.Add(new Chunk(Fabric1ENDETA, Fabric1ENDETAFont));
                                    pt.AddCell(new PdfPCell(Fabric1ENDETAPhrase) { BorderWidth = 1, BorderColor = BorderColor, BackgroundColor = ENDETA1BackColor, HorizontalAlignment = Element.ALIGN_CENTER, FixedHeight = 25, VerticalAlignment = Element.ALIGN_TOP, PaddingTop = 5 });
                                    Fabric1ENDETAPhrase.Add(Chunk.NEWLINE);




                                }

                                // For Fabric 2
                                if (orderDetail.Fabric2 != "")
                                {
                                    var Fabric2 = orderDetail.Fabric2;
                                    var Fab2STCAverage = "";
                                    var Fabric2Percent = "";
                                    var QuantityAvl2 = "";
                                    var FinalOrderFabric2 = "";
                                    var Temp2aVG = "";

                                    if (orderDetail.FOrdRead)
                                    {
                                        Fab2STCAverage = orderDetail.Fabric2STCAverage.ToString();
                                    }
                                    Temp2aVG = orderDetail.Fabric2STCAverage.ToString();
                                    if (orderDetail.CutWidth2 != 0)//abhishek
                                    {
                                        Fab2STCAverage = Fab2STCAverage + "/" + orderDetail.CutWidth2 + "IN";
                                    }
                                    if (orderDetail.FPerInhouseRead)
                                    {
                                        if (orderDetail.ParentOrder.FabricInhouseHistory.Fabric2Percent != 0)
                                        {
                                            Fabric2Percent = orderDetail.ParentOrder.FabricInhouseHistory.Fabric2Percent.ToString() + " %";
                                        }
                                    }
                                    if (orderDetail.FRecdRead)
                                    {
                                      if (orderDetail.QuantityAvl2 != "0" && orderDetail.QuantityAvl2 != "")
                                        {
                                          
                                            QuantityAvl2 = Math.Round(Convert.ToDecimal(orderDetail.QuantityAvl2.Replace(",", ".")), 1, MidpointRounding.AwayFromZero).ToString("G29") + "k";
                                        }
                                    }
                                    if (orderDetail.FFabTotalRead)
                                    {
                                        if (orderDetail.FinalOrderFabric2 != "0")
                                        {
                                            FinalOrderFabric2 = orderDetail.FinalOrderFabric2;
                                        }
                                    }
                                    var Fab2NamePhrase = new Phrase();
                                    Color Fabric2NameBackColor = new Color(System.Drawing.ColorTranslator.FromHtml(orderDetail.Fabric2NameBackColor));
                                    Color Fabric2NameForColor = new Color(System.Drawing.ColorTranslator.FromHtml(orderDetail.Fabric2NameForColor));

                                    var Fabric2Font = FontFactory.GetFont("trebuchet ms", 11, Font.NORMAL, Fabric2NameForColor);
                                    Fab2NamePhrase.Add(new Chunk(Fabric2, Fabric2Font));

                                    pt.AddCell(new PdfPCell(Fab2NamePhrase) { BorderWidth = 1, BorderColor = BorderColor, Padding = 2, BackgroundColor = Fabric2NameBackColor, HorizontalAlignment = Element.ALIGN_LEFT, FixedHeight = 30, VerticalAlignment = Element.ALIGN_TOP, PaddingTop = 5 });

                                    var Fab2STCAveragePhrase = new Phrase();

                                    Color Percent2BackColor = new Color(System.Drawing.ColorTranslator.FromHtml(orderDetail.Percent2BackColor));
                                    Color Percent2ForColor = new Color(System.Drawing.ColorTranslator.FromHtml(orderDetail.Percent2ForColor));

                                    var Fab2STCAverage2Font = FontFactory.GetFont("trebuchet ms", 11, Font.NORMAL, Percent2ForColor);

                                    Fab2STCAveragePhrase.Add(new Chunk(Fab2STCAverage, Fab2STCAverage2Font));

                                    pt.AddCell(new PdfPCell(Fab2STCAveragePhrase) { BorderWidth = 1, BorderColor = BorderColor, Padding = 2, HorizontalAlignment = Element.ALIGN_CENTER, FixedHeight = 30, VerticalAlignment = Element.ALIGN_TOP, PaddingTop = 5 });

                                    var Fabric2PercentPhrase = new Phrase();

                                    Fabric2PercentPhrase.Add(new Chunk(Fabric2Percent, Fab2STCAverage2Font));

                                    pt.AddCell(new PdfPCell(Fabric2PercentPhrase) { BorderWidth = 1, BorderColor = BorderColor, Padding = 2, BackgroundColor = Percent2BackColor, HorizontalAlignment = Element.ALIGN_CENTER, FixedHeight = 30, VerticalAlignment = Element.ALIGN_TOP, PaddingTop = 5 });

                                    var QuantityAvl2Phrase = new Phrase();

                                    QuantityAvl2Phrase.Add(new Chunk(QuantityAvl2, Fab2STCAverage2Font));

                                    pt.AddCell(new PdfPCell(QuantityAvl2Phrase) { BorderWidth = 1, BorderColor = BorderColor, Padding = 2, HorizontalAlignment = Element.ALIGN_CENTER, FixedHeight = 30, VerticalAlignment = Element.ALIGN_TOP, PaddingTop = 5 });

                                    orderDetail.FinalOrderFabric2_k = (orderDetail.FinalOrderFabric2_k == null ? "" : orderDetail.FinalOrderFabric2_k);
                                    var FinalOrderFabric1Phrase = new Phrase();
                                    string FabCutWidthAvg = "";
                                    if (orderDetail.FinalOrderFabric2_k != "0K" && orderDetail.FinalOrderFabric2_k != "" && orderDetail.FinalOrderFabric2_k != "0" && orderDetail.Fabric2STCAverage.ToString() != "")
                                    {
                                        if (Temp2aVG == "0")
                                            Temp2aVG = "1";
                                        string fab1CutIssueAvgIn_K = Math.Round(((Convert.ToDecimal(orderDetail.FinalOrderFabric2_k.Replace("k", "")) / Convert.ToDecimal(Temp2aVG))), 1, MidpointRounding.AwayFromZero).ToString("G29");
                                        FabCutWidthAvg = "(" + fab1CutIssueAvgIn_K + "k Pcs)";
                                        FabCutWidthAvg = FabCutWidthAvg == " (0k Pcs)" ? "" : FabCutWidthAvg;
                                    }
                                    //abhishek
                                    //var QuantityFab2Phrase = new Phrase();
                                    //QuantityFab2Phrase.Add(new Chunk(orderDetail.FinalOrderFabric2_k + " " + FabCutWidthAvg, Fab2STCAverage2Font));
                                    //pt.AddCell(new PdfPCell(QuantityFab2Phrase) { BorderWidth = 1, BorderColor = BorderColor, Padding = 2, HorizontalAlignment = Element.ALIGN_CENTER, FixedHeight = 30, VerticalAlignment = Element.ALIGN_TOP, PaddingTop = 5 });


                                    //var FinalOrderFabric2Phrase = new Phrase();
                                    //FinalOrderFabric2Phrase.Add(new Chunk(FinalOrderFabric2, Fab2STCAverage2Font));
                                    //pt.AddCell(new PdfPCell(FinalOrderFabric2Phrase) { BorderWidth = 1, BorderColor = BorderColor, Padding = 2, HorizontalAlignment = Element.ALIGN_CENTER, FixedHeight = 30, VerticalAlignment = Element.ALIGN_TOP, PaddingTop = 5 });
                                    //FinalOrderFabric2Phrase.Add(Chunk.NEWLINE);

                                    var FinalOrderFabric2Phrase = new Phrase();
                                    FinalOrderFabric2Phrase.Add(new Chunk(orderDetail.FinalOrderFabric2_k + " " + FabCutWidthAvg, Fab2STCAverage2Font));
                                    pt.AddCell(new PdfPCell(FinalOrderFabric2Phrase) { BorderWidth = 1, BorderColor = BorderColor, Padding = 2, HorizontalAlignment = Element.ALIGN_CENTER, FixedHeight = 30, VerticalAlignment = Element.ALIGN_TOP, PaddingTop = 5 });
                                    FinalOrderFabric2Phrase.Add(Chunk.NEWLINE);


                                    string finalOrder1 = "";
                                    if (orderDetail.FinalOrderFabric2 != "0" && orderDetail.FinalOrderFabric2 != "")
                                    {
                                      finalOrder1 = Math.Round(Convert.ToDecimal(orderDetail.FinalOrderFabric2), 1, MidpointRounding.AwayFromZero).ToString("G29") + "k";
                                    }
                                    Color BulkColor = new Color(System.Drawing.ColorTranslator.FromHtml(orderDetail.BulkApproval2BackColor));
                                    var Fab1RequiredQtyPhrase = new Phrase();
                                    var Fabric1RequiredQtyFont = FontFactory.GetFont("trebuchet ms", 9, Font.NORMAL, BulkColor);
                                    Fab1RequiredQtyPhrase.Add(new Chunk(finalOrder1, Fab2STCAverage2Font));
                                    pt.AddCell(new PdfPCell(Fab1RequiredQtyPhrase) { BorderWidth = 1, BorderColor = BorderColor, Padding = 2, HorizontalAlignment = Element.ALIGN_CENTER, FixedHeight = 30, VerticalAlignment = Element.ALIGN_TOP, PaddingTop = 5 });

                                    Fab1RequiredQtyPhrase.Add(Chunk.NEWLINE);

                                    var Fabric2Details = "";
                                    if (orderDetail.FQualityRead)
                                    {
                                        Fabric2Details = orderDetail.Fabric2Details + " " + orderDetail.ParentOrder.FabricApprovalDetails.F6BulkStatus;
                                    }
                                    var TotalSummary2 = "";
                                    if (orderDetail.FFabSummaryRead)
                                    {
                                        if (orderDetail.TotalSummary2.Length > 16)
                                        {
                                            TotalSummary2 = orderDetail.TotalSummary2.Substring(0, 16);
                                        }
                                        else
                                        {
                                            TotalSummary2 = orderDetail.TotalSummary2;
                                        }
                                    }

                                    var Fab2StartEta = "";
                                    var Fabric2ENDETA = "";
                                    if (orderDetail.FFabStartETARead)
                                    {
                                        if (orderDetail.fabric2ETA != DateTime.MinValue)
                                        {
                                            Fab2StartEta = orderDetail.fabric2ETA.ToString("dd MMM");
                                        }
                                    }
                                    if (orderDetail.FFabEndETARead)
                                    {
                                        if (orderDetail.Fabric2ENDETA != DateTime.MinValue)
                                        {
                                            Fabric2ENDETA = orderDetail.Fabric2ENDETA.ToString("dd MMM");
                                        }
                                    }

                                    var Fab2DetailPhrase = new Phrase();
                                    Color BulkApproval2BackColor = new Color(System.Drawing.ColorTranslator.FromHtml(orderDetail.BulkApproval2BackColor));
                                    Color BulkApproval2ForColor = new Color(System.Drawing.ColorTranslator.FromHtml(orderDetail.BulkApproval2ForColor));

                                    var Fabric2DetailFont = FontFactory.GetFont("trebuchet ms", 9, Font.NORMAL, BulkApproval2ForColor);
                                    Fab2DetailPhrase.Add(new Chunk(Fabric2Details, Fabric2DetailFont));

                                    pt.AddCell(new PdfPCell(Fab2DetailPhrase) { BorderWidth = 1, BorderColor = BorderColor, BackgroundColor = BulkApproval2BackColor, HorizontalAlignment = Element.ALIGN_LEFT, FixedHeight = 25, VerticalAlignment = Element.ALIGN_TOP, PaddingTop = 5 });


                                    if (TotalSummary2 != "")
                                    {

                                        if (orderDetail.Caption2 == "Black")
                                        {
                                            SummryColor = new Color(System.Drawing.ColorTranslator.FromHtml("#807f80"));
                                        }
                                        if (orderDetail.Caption2 == "Red")
                                        {
                                            SummryColor = new Color(System.Drawing.ColorTranslator.FromHtml("#ff3300"));
                                        }
                                        if (orderDetail.Caption2 == "Green")
                                        {
                                            SummryColor = new Color(System.Drawing.ColorTranslator.FromHtml("#006600"));
                                        }
                                        if (orderDetail.IsShiped)
                                        {
                                            SummryColor = Color.GRAY;
                                        }

                                    }
                                    SummryColor = SummryColor == null ? Color.WHITE : SummryColor;
                                    var TotalSummary2Phrase = new Phrase();
                                    var TotalSummary2Font = FontFactory.GetFont("trebuchet ms", 9, Font.NORMAL, SummryColor);
                                    TotalSummary2Phrase.Add(new Chunk(TotalSummary2, TotalSummary2Font));
                                    pt.AddCell(new PdfPCell(TotalSummary2Phrase) { BorderWidth = 1,Colspan=2, BorderColor = BorderColor, HorizontalAlignment = Element.ALIGN_LEFT, FixedHeight = 25, VerticalAlignment = Element.ALIGN_TOP, PaddingTop = 5 });




                                    //abhishek strikeof ETA 23/9/2016
                                    var Fab2Strikeof = "";

                                    if (orderDetail.StrikeOff2ETA != DateTime.MinValue)
                                    {
                                        Fab2Strikeof = orderDetail.StrikeOff2ETA.ToString("dd MMM");
                                    }
                                    var Fabric2Strikeof = new Phrase();
                                    Color Strikeof2BackColor = new Color(System.Drawing.ColorTranslator.FromHtml(orderDetail.StrikeOfBackColor2));
                                    Color Strikeof2ForColor = new Color(System.Drawing.ColorTranslator.FromHtml(orderDetail.StrikeOfForeColor2));

                                    var Fabric2StrikeOfETAFont = FontFactory.GetFont("trebuchet ms", 9, Font.NORMAL, Strikeof2ForColor);
                                    Fabric2Strikeof.Add(new Chunk(Fab2Strikeof, Fabric2StrikeOfETAFont));

                                    pt.AddCell(new PdfPCell(Fabric2Strikeof) { BorderWidth = 1, BorderColor = BorderColor, BackgroundColor = Strikeof2BackColor, HorizontalAlignment = Element.ALIGN_CENTER, FixedHeight = 25, VerticalAlignment = Element.ALIGN_TOP, PaddingTop = 5 });

                                    Fabric2Strikeof.Add(Chunk.NEWLINE);


                                    var Fab2StartEtaPhrase = new Phrase();
                                    Color StartETA2BackColor = new Color(System.Drawing.ColorTranslator.FromHtml(orderDetail.StartETA2BackColor));
                                    Color StartETA2ForColor = new Color(System.Drawing.ColorTranslator.FromHtml(orderDetail.StartETA2ForColor));

                                    var Fab2StartEtaeFont = FontFactory.GetFont("trebuchet ms", 9, Font.NORMAL, StartETA2ForColor);
                                    Fab2StartEtaPhrase.Add(new Chunk(Fab2StartEta, Fab2StartEtaeFont));

                                    pt.AddCell(new PdfPCell(Fab2StartEtaPhrase) { BorderWidth = 1, BorderColor = BorderColor, BackgroundColor = StartETA2BackColor, HorizontalAlignment = Element.ALIGN_CENTER, FixedHeight = 25, VerticalAlignment = Element.ALIGN_TOP, PaddingTop = 5 });


                                    var Fabric2ENDETAPhrase = new Phrase();
                                    Color ENDETA2BackColor = new Color(System.Drawing.ColorTranslator.FromHtml(orderDetail.ENDETA2BackColor));
                                    Color ENDETA2ForColor = new Color(System.Drawing.ColorTranslator.FromHtml(orderDetail.ENDETA2ForColor));

                                    var Fabric2ENDETAFont = FontFactory.GetFont("trebuchet ms", 9, Font.NORMAL, ENDETA2ForColor);
                                    Fabric2ENDETAPhrase.Add(new Chunk(Fabric2ENDETA, Fabric2ENDETAFont));

                                    pt.AddCell(new PdfPCell(Fabric2ENDETAPhrase) { BorderWidth = 1, BorderColor = BorderColor, BackgroundColor = ENDETA2BackColor, HorizontalAlignment = Element.ALIGN_CENTER, FixedHeight = 25, VerticalAlignment = Element.ALIGN_TOP, PaddingTop = 5 });

                                    Fabric2ENDETAPhrase.Add(Chunk.NEWLINE);
                                }

                                // For Fabric 3
                                if (orderDetail.Fabric3 != "")
                                {
                                    var Fabric3 = orderDetail.Fabric3;
                                    var Fab3STCAverage = "";
                                    var Fabric3Percent = "";
                                    var QuantityAvl3 = "";
                                    var FinalOrderFabric3 = "";
                                    var Temp3aVG = "";
                                    if (orderDetail.FOrdRead)
                                    {
                                        Fab3STCAverage = orderDetail.Fabric3STCAverage.ToString();
                                    }
                                    Temp3aVG = orderDetail.Fabric3STCAverage.ToString();
                                    if (orderDetail.CutWidth3 != 0)//abhishek
                                    {
                                        Fab3STCAverage = Fab3STCAverage + "/" + orderDetail.CutWidth3 + "IN";
                                    }
                                    if (orderDetail.FPerInhouseRead)
                                    {
                                        if (orderDetail.ParentOrder.FabricInhouseHistory.Fabric3Percent != 0)
                                        {
                                            Fabric3Percent = orderDetail.ParentOrder.FabricInhouseHistory.Fabric3Percent.ToString() + " %";
                                        }
                                    }
                                    if (orderDetail.FRecdRead)
                                    {
                                      if (orderDetail.QuantityAvl3 != "0" && orderDetail.QuantityAvl3 != "")
                                        {
                                           
                                            QuantityAvl3 = Math.Round(Convert.ToDecimal(orderDetail.QuantityAvl3.Replace(",", ".")), 1, MidpointRounding.AwayFromZero).ToString("G29") + "k";
                                        }
                                    }
                                    if (orderDetail.FFabTotalRead)
                                    {
                                        if (orderDetail.FinalOrderFabric3 != "0")
                                        {
                                            FinalOrderFabric3 = orderDetail.FinalOrderFabric3;
                                        }
                                    }

                                    var Fab3NamePhrase = new Phrase();
                                    Color Fabric3NameBackColor = new Color(System.Drawing.ColorTranslator.FromHtml(orderDetail.Fabric3NameBackColor));
                                    Color Fabric3NameForColor = new Color(System.Drawing.ColorTranslator.FromHtml(orderDetail.Fabric3NameForColor));

                                    var Fabric3Font = FontFactory.GetFont("trebuchet ms", 11, Font.NORMAL, Fabric3NameForColor);
                                    Fab3NamePhrase.Add(new Chunk(Fabric3, Fabric3Font));

                                    pt.AddCell(new PdfPCell(Fab3NamePhrase) { BorderWidth = 1, BorderColor = BorderColor, Padding = 2, BackgroundColor = Fabric3NameBackColor, HorizontalAlignment = Element.ALIGN_LEFT, FixedHeight = 30, VerticalAlignment = Element.ALIGN_TOP, PaddingTop = 5 });

                                    var Fab3STCAveragePhrase = new Phrase();

                                    Color Percent3BackColor = new Color(System.Drawing.ColorTranslator.FromHtml(orderDetail.Percent3BackColor));
                                    Color Percent3ForColor = new Color(System.Drawing.ColorTranslator.FromHtml(orderDetail.Percent3ForColor));

                                    var Fab3STCAverage3Font = FontFactory.GetFont("trebuchet ms", 11, Font.NORMAL, Percent3ForColor);

                                    Fab3STCAveragePhrase.Add(new Chunk(Fab3STCAverage, Fab3STCAverage3Font));

                                    pt.AddCell(new PdfPCell(Fab3STCAveragePhrase) { BorderWidth = 1, BorderColor = BorderColor, Padding = 2, HorizontalAlignment = Element.ALIGN_CENTER, FixedHeight = 30, VerticalAlignment = Element.ALIGN_TOP, PaddingTop = 5 });

                                    var Fabric3PercentPhrase = new Phrase();

                                    Fabric3PercentPhrase.Add(new Chunk(Fabric3Percent, Fab3STCAverage3Font));

                                    pt.AddCell(new PdfPCell(Fabric3PercentPhrase) { BorderWidth = 1, BorderColor = BorderColor, Padding = 2, BackgroundColor = Percent3BackColor, HorizontalAlignment = Element.ALIGN_CENTER, FixedHeight = 30, VerticalAlignment = Element.ALIGN_TOP, PaddingTop = 5 });

                                    var QuantityAvl3Phrase = new Phrase();

                                    QuantityAvl3Phrase.Add(new Chunk(QuantityAvl3, Fab3STCAverage3Font));

                                    pt.AddCell(new PdfPCell(QuantityAvl3Phrase) { BorderWidth = 1, BorderColor = BorderColor, Padding = 2, HorizontalAlignment = Element.ALIGN_CENTER, FixedHeight = 30, VerticalAlignment = Element.ALIGN_TOP, PaddingTop = 5 });
                                    orderDetail.FinalOrderFabric3_k = (orderDetail.FinalOrderFabric3_k == null ? "" : orderDetail.FinalOrderFabric3_k);
                                    string FabCutWidthAvg = "";
                                    if (orderDetail.FinalOrderFabric3_k != "0K" && orderDetail.FinalOrderFabric3_k != "" && orderDetail.FinalOrderFabric3_k != "0" && orderDetail.Fabric3STCAverage.ToString() != "")
                                    {
                                        if (Temp3aVG == "0")
                                            Temp3aVG = "1";
                                        string fab1CutIssueAvgIn_K = Math.Round(((Convert.ToDecimal(orderDetail.FinalOrderFabric3_k.Replace("k", "")) / Convert.ToDecimal(Temp3aVG))), 1, MidpointRounding.AwayFromZero).ToString("G29");
                                        FabCutWidthAvg = "(" + fab1CutIssueAvgIn_K + "k Pcs)";
                                        FabCutWidthAvg = FabCutWidthAvg == " (0k Pcs)" ? "" : FabCutWidthAvg;
                                    }
                                    //var FinalOrderFabric3Phrase = new Phrase();
                                    //FinalOrderFabric3Phrase.Add(new Chunk(FinalOrderFabric3, Fab3STCAverage3Font));
                                    //pt.AddCell(new PdfPCell(FinalOrderFabric3Phrase) { BorderWidth = 1, BorderColor = BorderColor, Padding = 2, HorizontalAlignment = Element.ALIGN_CENTER, FixedHeight = 30, VerticalAlignment = Element.ALIGN_TOP, PaddingTop = 5 });
                                    //FinalOrderFabric3Phrase.Add(Chunk.NEWLINE);

                                    var FinalOrderFabric3Phrase = new Phrase();
                                    FinalOrderFabric3Phrase.Add(new Chunk(orderDetail.FinalOrderFabric3_k + " " + FabCutWidthAvg, Fab3STCAverage3Font));
                                    pt.AddCell(new PdfPCell(FinalOrderFabric3Phrase) { BorderWidth = 1, BorderColor = BorderColor, Padding = 2, HorizontalAlignment = Element.ALIGN_CENTER, FixedHeight = 30, VerticalAlignment = Element.ALIGN_TOP, PaddingTop = 5 });
                                    FinalOrderFabric3Phrase.Add(Chunk.NEWLINE);


                                    string finalOrder1 = "";
                                    if (orderDetail.FinalOrderFabric3 != "0" && orderDetail.FinalOrderFabric3 != "")
                                    {
                                      finalOrder1 = Math.Round(Convert.ToDecimal(orderDetail.FinalOrderFabric3), 1, MidpointRounding.AwayFromZero).ToString("G29") + "k";
                                    }
                                    Color BulkColor = new Color(System.Drawing.ColorTranslator.FromHtml(orderDetail.BulkApproval2BackColor));
                                    var Fab1RequiredQtyPhrase = new Phrase();
                                    var Fabric1RequiredQtyFont = FontFactory.GetFont("trebuchet ms", 9, Font.NORMAL, BulkColor);
                                    Fab1RequiredQtyPhrase.Add(new Chunk(finalOrder1, Fab3STCAverage3Font));
                                    pt.AddCell(new PdfPCell(Fab1RequiredQtyPhrase) { BorderWidth = 1, BorderColor = BorderColor, Padding = 2, HorizontalAlignment = Element.ALIGN_CENTER, FixedHeight = 30, VerticalAlignment = Element.ALIGN_TOP, PaddingTop = 5 });

                                    Fab1RequiredQtyPhrase.Add(Chunk.NEWLINE);

                                    var Fabric3Details = "";
                                    if (orderDetail.FQualityRead)
                                    {
                                        Fabric3Details = orderDetail.Fabric3Details + " " + orderDetail.ParentOrder.FabricApprovalDetails.F7BulkStatus;
                                    }
                                    var TotalSummary3 = "";
                                    if (orderDetail.FFabSummaryRead)
                                    {
                                        if (orderDetail.TotalSummary3.Length > 16)
                                        {
                                            TotalSummary3 = orderDetail.TotalSummary3.Substring(0, 16);
                                        }
                                        else
                                        {
                                            TotalSummary3 = orderDetail.TotalSummary3;
                                        }
                                    }

                                    var Fab3StartEta = "";
                                    var Fabric3ENDETA = "";
                                    if (orderDetail.FFabStartETARead)
                                    {
                                        if (orderDetail.fabric3ETA != DateTime.MinValue)
                                        {
                                            Fab3StartEta = orderDetail.fabric3ETA.ToString("dd MMM");
                                        }
                                    }
                                    if (orderDetail.FFabEndETARead)
                                    {
                                        if (orderDetail.Fabric3ENDETA != DateTime.MinValue)
                                        {
                                            Fabric3ENDETA = orderDetail.Fabric3ENDETA.ToString("dd MMM");
                                        }
                                    }

                                    var Fab3DetailPhrase = new Phrase();
                                    Color BulkApproval3BackColor = new Color(System.Drawing.ColorTranslator.FromHtml(orderDetail.BulkApproval3BackColor));
                                    Color BulkApproval3ForColor = new Color(System.Drawing.ColorTranslator.FromHtml(orderDetail.BulkApproval3ForColor));

                                    var Fabric3DetailFont = FontFactory.GetFont("trebuchet ms", 9, Font.NORMAL, BulkApproval3ForColor);
                                    Fab3DetailPhrase.Add(new Chunk(Fabric3Details, Fabric3DetailFont));

                                    pt.AddCell(new PdfPCell(Fab3DetailPhrase) { BorderWidth = 1, BorderColor = BorderColor, BackgroundColor = BulkApproval3BackColor, HorizontalAlignment = Element.ALIGN_LEFT, FixedHeight = 25, VerticalAlignment = Element.ALIGN_TOP, PaddingTop = 5 });

                                    if (TotalSummary3 != "")
                                    {

                                        if (orderDetail.Caption3 == "Black")
                                        {
                                            SummryColor = new Color(System.Drawing.ColorTranslator.FromHtml("#807f80"));
                                        }
                                        if (orderDetail.Caption3 == "Red")
                                        {
                                            SummryColor = new Color(System.Drawing.ColorTranslator.FromHtml("#ff3300"));
                                        }
                                        if (orderDetail.Caption3 == "Green")
                                        {
                                            SummryColor = new Color(System.Drawing.ColorTranslator.FromHtml("#006600"));
                                        }
                                        if (orderDetail.IsShiped)
                                        {
                                            SummryColor = Color.GRAY;
                                        }

                                    }

                                    SummryColor = SummryColor == null ? Color.WHITE : SummryColor;
                                    var TotalSummary3Phrase = new Phrase();
                                    var TotalSummary3Font = FontFactory.GetFont("trebuchet ms", 9, Font.NORMAL, SummryColor);
                                    TotalSummary3Phrase.Add(new Chunk(TotalSummary3, TotalSummary3Font));

                                    pt.AddCell(new PdfPCell(TotalSummary3Phrase) { BorderWidth = 1, Colspan = 2, BorderColor = BorderColor, HorizontalAlignment = Element.ALIGN_LEFT, FixedHeight = 25, VerticalAlignment = Element.ALIGN_TOP, PaddingTop = 5 });



                                    var Fab3Strikeof = "";

                                    if (orderDetail.StrikeOff3ETA != DateTime.MinValue)
                                    {
                                        Fab3Strikeof = orderDetail.StrikeOff3ETA.ToString("dd MMM");
                                    }
                                    var Fabric3Strikeof = new Phrase();
                                    Color Strikeof3BackColor = new Color(System.Drawing.ColorTranslator.FromHtml(orderDetail.StrikeOfBackColor3));
                                    Color Strikeof3ForColor = new Color(System.Drawing.ColorTranslator.FromHtml(orderDetail.StrikeOfForeColor3));

                                    var Fabric3StrikeOfETAFont = FontFactory.GetFont("trebuchet ms", 9, Font.NORMAL, Strikeof3ForColor);
                                    Fabric3Strikeof.Add(new Chunk(Fab3Strikeof, Fabric3StrikeOfETAFont));

                                    pt.AddCell(new PdfPCell(Fabric3Strikeof) { BorderWidth = 1, BorderColor = BorderColor, BackgroundColor = Strikeof3BackColor, HorizontalAlignment = Element.ALIGN_CENTER, FixedHeight = 35, VerticalAlignment = Element.ALIGN_TOP, PaddingTop = 5 });

                                    Fabric3Strikeof.Add(Chunk.NEWLINE);

                                    var Fab3StartEtaPhrase = new Phrase();
                                    Color StartETA3BackColor = new Color(System.Drawing.ColorTranslator.FromHtml(orderDetail.StartETA3BackColor));
                                    Color StartETA3ForColor = new Color(System.Drawing.ColorTranslator.FromHtml(orderDetail.StartETA3ForColor));

                                    var Fab3StartEtaeFont = FontFactory.GetFont("trebuchet ms", 9, Font.NORMAL, StartETA3ForColor);
                                    Fab3StartEtaPhrase.Add(new Chunk(Fab3StartEta, Fab3StartEtaeFont));

                                    pt.AddCell(new PdfPCell(Fab3StartEtaPhrase) { BorderWidth = 1, BorderColor = BorderColor, BackgroundColor = StartETA3BackColor, HorizontalAlignment = Element.ALIGN_CENTER, FixedHeight = 25, VerticalAlignment = Element.ALIGN_TOP, PaddingTop = 5 });


                                    var Fabric3ENDETAPhrase = new Phrase();
                                    Color ENDETA3BackColor = new Color(System.Drawing.ColorTranslator.FromHtml(orderDetail.ENDETA3BackColor));
                                    Color ENDETA3ForColor = new Color(System.Drawing.ColorTranslator.FromHtml(orderDetail.ENDETA3ForColor));

                                    var Fabric3ENDETAFont = FontFactory.GetFont("trebuchet ms", 9, Font.NORMAL, ENDETA3ForColor);
                                    Fabric3ENDETAPhrase.Add(new Chunk(Fabric3ENDETA, Fabric3ENDETAFont));

                                    pt.AddCell(new PdfPCell(Fabric3ENDETAPhrase) { BorderWidth = 1, BorderColor = BorderColor, BackgroundColor = ENDETA3BackColor, HorizontalAlignment = Element.ALIGN_CENTER, FixedHeight = 25, VerticalAlignment = Element.ALIGN_TOP, PaddingTop = 5 });

                                    Fabric3ENDETAPhrase.Add(Chunk.NEWLINE);


                                }

                                // For Fabric 4
                                if (orderDetail.Fabric4 != "")
                                {
                                    var Fabric4 = orderDetail.Fabric4;
                                    var Fab4STCAverage = "";
                                    var Fabric4Percent = "";
                                    var QuantityAvl4 = "";
                                    var FinalOrderFabric4 = "";
                                    var Temp4aVG = "";
                                    if (orderDetail.FOrdRead)
                                    {
                                        Fab4STCAverage = orderDetail.Fabric4STCAverage.ToString();
                                    }
                                    Temp4aVG = orderDetail.Fabric4STCAverage.ToString();
                                    if (orderDetail.CutWidth4 != 0)//abhishek
                                    {
                                        Fab4STCAverage = Fab4STCAverage + "/" + orderDetail.CutWidth4 + "IN";
                                    }
                                    if (orderDetail.FPerInhouseRead)
                                    {
                                        if (orderDetail.ParentOrder.FabricInhouseHistory.Fabric4Percent != 0)
                                        {
                                            Fabric4Percent = orderDetail.ParentOrder.FabricInhouseHistory.Fabric4Percent.ToString() + " %";
                                        }
                                    }
                                    if (orderDetail.FRecdRead)
                                    {
                                      if (orderDetail.QuantityAvl4 != "0" && orderDetail.QuantityAvl4 != "")
                                        {
                                            QuantityAvl4 = Math.Round(Convert.ToDecimal(orderDetail.QuantityAvl4.Replace(",", ".")), 1, MidpointRounding.AwayFromZero).ToString("G29") + "k";
                                        }
                                    }
                                    if (orderDetail.FFabTotalRead)
                                    {
                                        if (orderDetail.FinalOrderFabric4 != "0")
                                        {
                                            FinalOrderFabric4 = orderDetail.FinalOrderFabric4;
                                        }
                                    }

                                    var Fab4NamePhrase = new Phrase();
                                    Color Fabric4NameBackColor = new Color(System.Drawing.ColorTranslator.FromHtml(orderDetail.Fabric4NameBackColor));
                                    Color Fabric4NameForColor = new Color(System.Drawing.ColorTranslator.FromHtml(orderDetail.Fabric4NameForColor));

                                    var Fabric4Font = FontFactory.GetFont("trebuchet ms", 11, Font.NORMAL, Fabric4NameForColor);
                                    Fab4NamePhrase.Add(new Chunk(Fabric4, Fabric4Font));

                                    pt.AddCell(new PdfPCell(Fab4NamePhrase) { BorderWidth = 1, BorderColor = BorderColor, Padding = 2, BackgroundColor = Fabric4NameBackColor, HorizontalAlignment = Element.ALIGN_LEFT, FixedHeight = 30, VerticalAlignment = Element.ALIGN_TOP, PaddingTop = 5 });
                                    //pt.AddCell(new PdfPCell(Fabric3ENDETAPhrase) { BorderWidth = 1, BorderColor = BorderColor, BackgroundColor = ENDETA3BackColor, HorizontalAlignment = Element.ALIGN_CENTER, FixedHeight = 25, VerticalAlignment = Element.ALIGN_TOP, PaddingTop = 5 });
                                    var Fab4STCAveragePhrase = new Phrase();

                                    Color Percent4BackColor = new Color(System.Drawing.ColorTranslator.FromHtml(orderDetail.Percent4BackColor));
                                    Color Percent4ForColor = new Color(System.Drawing.ColorTranslator.FromHtml(orderDetail.Percent4ForColor));

                                    var Fab4STCAverage4Font = FontFactory.GetFont("trebuchet ms", 11, Font.NORMAL, Percent4ForColor);

                                    Fab4STCAveragePhrase.Add(new Chunk(Fab4STCAverage, Fab4STCAverage4Font));

                                    pt.AddCell(new PdfPCell(Fab4STCAveragePhrase) { BorderWidth = 1, BorderColor = BorderColor, Padding = 2, HorizontalAlignment = Element.ALIGN_LEFT, FixedHeight = 30, VerticalAlignment = Element.ALIGN_TOP, PaddingTop = 5 });

                                    var Fabric4PercentPhrase = new Phrase();

                                    Fabric4PercentPhrase.Add(new Chunk(Fabric4Percent, Fab4STCAverage4Font));

                                    pt.AddCell(new PdfPCell(Fabric4PercentPhrase) { BorderWidth = 1, BorderColor = BorderColor, Padding = 2, BackgroundColor = Percent4BackColor, HorizontalAlignment = Element.ALIGN_LEFT, FixedHeight = 30, VerticalAlignment = Element.ALIGN_TOP, PaddingTop = 5 });

                                    var QuantityAvl4Phrase = new Phrase();

                                    QuantityAvl4Phrase.Add(new Chunk(QuantityAvl4, Fab4STCAverage4Font));

                                    pt.AddCell(new PdfPCell(QuantityAvl4Phrase) { BorderWidth = 1, BorderColor = BorderColor, Padding = 2, HorizontalAlignment = Element.ALIGN_LEFT, FixedHeight = 30, VerticalAlignment = Element.ALIGN_TOP, PaddingTop = 5 });

                                    orderDetail.FinalOrderFabric4_k = (orderDetail.FinalOrderFabric4_k == null ? "" : orderDetail.FinalOrderFabric4_k);
                                    string FabCutWidthAvg = "";
                                    if (orderDetail.FinalOrderFabric4_k != "0K" && orderDetail.FinalOrderFabric4_k != "" && orderDetail.FinalOrderFabric4_k != "0" && orderDetail.Fabric4STCAverage.ToString() != "")
                                    {
                                        if (Temp4aVG == "0")
                                            Temp4aVG = "1";
                                        string fab1CutIssueAvgIn_K = Math.Round(((Convert.ToDecimal(orderDetail.FinalOrderFabric4_k.Replace("k", "")) / Convert.ToDecimal(Temp4aVG))), 1, MidpointRounding.AwayFromZero).ToString("G29");
                                        FabCutWidthAvg = "(" + fab1CutIssueAvgIn_K + "k Pcs)";
                                        FabCutWidthAvg = FabCutWidthAvg == " (0k Pcs)" ? "" : FabCutWidthAvg;
                                    }


                                    //var FinalOrderFabric4Phrase = new Phrase();

                                    //FinalOrderFabric4Phrase.Add(new Chunk(FinalOrderFabric4, Fab4STCAverage4Font));

                                    //pt.AddCell(new PdfPCell(FinalOrderFabric4Phrase) { BorderWidth = 1, BorderColor = BorderColor, Padding = 2, HorizontalAlignment = Element.ALIGN_LEFT, FixedHeight = 30, VerticalAlignment = Element.ALIGN_TOP, PaddingTop = 5 });

                                    //FinalOrderFabric4Phrase.Add(Chunk.NEWLINE);


                                    var FinalOrderFabric4Phrase = new Phrase();

                                    FinalOrderFabric4Phrase.Add(new Chunk(orderDetail.FinalOrderFabric4_k + " " + FabCutWidthAvg, Fab4STCAverage4Font));

                                    pt.AddCell(new PdfPCell(FinalOrderFabric4Phrase) { BorderWidth = 1, BorderColor = BorderColor, Padding = 2, HorizontalAlignment = Element.ALIGN_LEFT, FixedHeight = 30, VerticalAlignment = Element.ALIGN_TOP, PaddingTop = 5 });

                                    FinalOrderFabric4Phrase.Add(Chunk.NEWLINE);


                                    string finalOrder1 = "";
                                    if (orderDetail.FinalOrderFabric4 != "0" && orderDetail.FinalOrderFabric4 != "")
                                    {
                                      finalOrder1 = Math.Round(Convert.ToDecimal(orderDetail.FinalOrderFabric4), 1, MidpointRounding.AwayFromZero).ToString("G29") + "k";
                                    }
                                    Color BulkColor = new Color(System.Drawing.ColorTranslator.FromHtml(orderDetail.BulkApproval2BackColor));
                                    var Fab1RequiredQtyPhrase = new Phrase();
                                    var Fabric1RequiredQtyFont = FontFactory.GetFont("trebuchet ms", 9, Font.NORMAL, BulkColor);
                                    Fab1RequiredQtyPhrase.Add(new Chunk(finalOrder1, Fab4STCAverage4Font));
                                    pt.AddCell(new PdfPCell(Fab1RequiredQtyPhrase) { BorderWidth = 1, BorderColor = BorderColor, Padding = 2, HorizontalAlignment = Element.ALIGN_CENTER, FixedHeight = 30, VerticalAlignment = Element.ALIGN_TOP, PaddingTop = 5 });
                                    Fab1RequiredQtyPhrase.Add(Chunk.NEWLINE);


                                    var Fabric4Details = "";
                                    if (orderDetail.FQualityRead)
                                    {
                                        Fabric4Details = orderDetail.Fabric4Details + " " + orderDetail.ParentOrder.FabricApprovalDetails.F8BulkStatus;
                                    }
                                    var TotalSummary4 = "";
                                    if (orderDetail.FFabSummaryRead)
                                    {
                                        if (orderDetail.TotalSummary4.Length > 16)
                                        {
                                            TotalSummary4 = orderDetail.TotalSummary4.Substring(0, 16);
                                        }
                                        else
                                        {
                                            TotalSummary4 = orderDetail.TotalSummary4;
                                        }
                                    }

                                    var Fab4StartEta = "";
                                    var Fabric4ENDETA = "";
                                    if (orderDetail.FFabStartETARead)
                                    {
                                        if (orderDetail.fabric4ETA != DateTime.MinValue)
                                        {
                                            Fab4StartEta = orderDetail.fabric4ETA.ToString("dd MMM");
                                        }
                                    }
                                    if (orderDetail.FFabEndETARead)
                                    {
                                        if (orderDetail.Fabric4ENDETA != DateTime.MinValue)
                                        {
                                            Fabric4ENDETA = orderDetail.Fabric4ENDETA.ToString("dd MMM");
                                        }
                                    }

                                    var Fab4DetailPhrase = new Phrase();
                                    Color BulkApproval4BackColor = new Color(System.Drawing.ColorTranslator.FromHtml(orderDetail.BulkApproval4BackColor));
                                    Color BulkApproval4ForColor = new Color(System.Drawing.ColorTranslator.FromHtml(orderDetail.BulkApproval4ForColor));

                                    var Fabric4DetailFont = FontFactory.GetFont("trebuchet ms", 9, Font.NORMAL, BulkApproval4ForColor);
                                    Fab4DetailPhrase.Add(new Chunk(Fabric4Details, Fabric4DetailFont));

                                    pt.AddCell(new PdfPCell(Fab4DetailPhrase) { BorderWidth = 1, BorderColor = BorderColor, BackgroundColor = BulkApproval4BackColor, HorizontalAlignment = Element.ALIGN_LEFT, FixedHeight = 25, VerticalAlignment = Element.ALIGN_TOP, PaddingTop = 5 });
                                    if (TotalSummary4 != "")
                                    {

                                        if (orderDetail.Caption4 == "Black")
                                        {
                                            SummryColor = new Color(System.Drawing.ColorTranslator.FromHtml("#807f80"));
                                        }
                                        if (orderDetail.Caption4 == "Red")
                                        {
                                            SummryColor = new Color(System.Drawing.ColorTranslator.FromHtml("#ff3300"));
                                        }
                                        if (orderDetail.Caption4 == "Green")
                                        {
                                            SummryColor = new Color(System.Drawing.ColorTranslator.FromHtml("#006600"));
                                        }
                                        if (orderDetail.IsShiped)
                                        {
                                            SummryColor = Color.GRAY;
                                        }



                                    }

                                    SummryColor = SummryColor == null ? Color.WHITE : SummryColor;
                                    var TotalSummary4Phrase = new Phrase();
                                    var TotalSummary4Font = FontFactory.GetFont("trebuchet ms", 9, Font.NORMAL, SummryColor);
                                    TotalSummary4Phrase.Add(new Chunk(TotalSummary4, TotalSummary4Font));

                                    pt.AddCell(new PdfPCell(TotalSummary4Phrase) { BorderWidth = 1, Colspan = 2, BorderColor = BorderColor, HorizontalAlignment = Element.ALIGN_LEFT, FixedHeight = 25, VerticalAlignment = Element.ALIGN_TOP, PaddingTop = 5 });

                                    var Fab4Strikeof = "";

                                    if (orderDetail.StrikeOff4ETA != DateTime.MinValue)
                                    {
                                        Fab4Strikeof = orderDetail.StrikeOff4ETA.ToString("dd MMM");
                                    }
                                    var Fabric4Strikeof = new Phrase();
                                    Color Strikeof4BackColor = new Color(System.Drawing.ColorTranslator.FromHtml(orderDetail.StrikeOfBackColor4));
                                    Color Strikeof4ForColor = new Color(System.Drawing.ColorTranslator.FromHtml(orderDetail.StrikeOfForeColor4));

                                    var Fabric4StrikeOfETAFont = FontFactory.GetFont("trebuchet ms", 9, Font.NORMAL, Strikeof4ForColor);
                                    Fabric4Strikeof.Add(new Chunk(Fab4Strikeof, Fabric4StrikeOfETAFont));

                                    pt.AddCell(new PdfPCell(Fabric4Strikeof) { BorderWidth = 1, BorderColor = BorderColor, BackgroundColor = Strikeof4BackColor, HorizontalAlignment = Element.ALIGN_CENTER, FixedHeight = 45, VerticalAlignment = Element.ALIGN_TOP, PaddingTop = 5 });

                                    Fabric4Strikeof.Add(Chunk.NEWLINE);

                                    var Fab4StartEtaPhrase = new Phrase();
                                    Color StartETA4BackColor = new Color(System.Drawing.ColorTranslator.FromHtml(orderDetail.StartETA4BackColor));
                                    Color StartETA4ForColor = new Color(System.Drawing.ColorTranslator.FromHtml(orderDetail.StartETA4ForColor));

                                    var Fab4StartEtaeFont = FontFactory.GetFont("trebuchet ms", 9, Font.NORMAL, StartETA4ForColor);
                                    Fab4StartEtaPhrase.Add(new Chunk(Fab4StartEta, Fab4StartEtaeFont));

                                    pt.AddCell(new PdfPCell(Fab4StartEtaPhrase) { BorderWidth = 1, BorderColor = BorderColor, BackgroundColor = StartETA4BackColor, HorizontalAlignment = Element.ALIGN_LEFT, FixedHeight = 25, VerticalAlignment = Element.ALIGN_TOP, PaddingTop = 5 });


                                    var Fabric4ENDETAPhrase = new Phrase();
                                    Color ENDETA4BackColor = new Color(System.Drawing.ColorTranslator.FromHtml(orderDetail.ENDETA4BackColor));
                                    Color ENDETA4ForColor = new Color(System.Drawing.ColorTranslator.FromHtml(orderDetail.ENDETA4ForColor));

                                    var Fabric4ENDETAFont = FontFactory.GetFont("trebuchet ms", 9, Font.NORMAL, ENDETA4ForColor);
                                    Fabric4ENDETAPhrase.Add(new Chunk(Fabric4ENDETA, Fabric4ENDETAFont));

                                    pt.AddCell(new PdfPCell(Fabric4ENDETAPhrase) { BorderWidth = 1, BorderColor = BorderColor, BackgroundColor = ENDETA4BackColor, HorizontalAlignment = Element.ALIGN_LEFT, FixedHeight = 25, VerticalAlignment = Element.ALIGN_TOP, PaddingTop = 5 });

                                    Fabric4ENDETAPhrase.Add(Chunk.NEWLINE);

                                }
                            }

                            float[] fabColumnWidth = new float[] { 45f, 10f, 12f, 15f, 30f, 10f };
                            pt.SetWidths(fabColumnWidth);

                            PDFCell FabricCell = new PDFCell(pt);
                            FabricRow.Add(FabricCell);
                            gen.Rows.Add(FabricRow);

                            #endregion Fabric Section
                            // Fabric Section End

                            // Accessories Section Start
                            #region Accessories Section

                            Access_ColorGreen = 0;
                            Access_ColorWhite = 0;
                            Access_ColorRed = 0;

                            if (orderDetail.Accessories.Count <= 0)
                            {
                                Access_ColorWhite = 1;
                            }

                            foreach (MOOrderDetails.AccessoriesDetails AccessDetail in orderDetail.Accessories)
                            {
                                if (orderDetail.BulkTarget.Date >= System.DateTime.Now.Date)
                                {
                                    if (AccessDetail.BIHETAAcc != System.DateTime.MinValue)
                                    {

                                        if (AccessDetail.Inhouse_Percent >= 100)
                                        {
                                            Access_ColorGreen = 1;
                                        }
                                        else
                                        {
                                            Access_ColorWhite = 1;
                                        }
                                    }
                                    else
                                    {
                                        Access_ColorWhite = 1;
                                    }

                                }
                                if (orderDetail.BulkTarget.Date < System.DateTime.Now.Date)
                                {
                                    if (AccessDetail.BIHETAAcc != System.DateTime.MinValue)
                                    {

                                        if (orderDetail.BulkTarget.Date < AccessDetail.BIHETAAcc.Date)
                                        {
                                            Access_ColorRed = 1;
                                        }
                                        if (AccessDetail.Inhouse_Percent >= 100)
                                        {
                                            if (orderDetail.BulkTarget.Date >= AccessDetail.BIHETAAcc.Date)
                                            {
                                                Access_ColorGreen = 1;
                                            }
                                        }
                                        else
                                        {
                                            Access_ColorRed = 1;
                                        }

                                    }
                                    else
                                    {
                                        Access_ColorRed = 1;
                                    }

                                }

                                if (Access_ColorRed == 1)
                                {
                                    if (orderDetail.FBIHDateRead == true)
                                    {
                                        if (orderDetail.IsShiped == true)
                                        {
                                            AccessBackColor = new Color(System.Drawing.ColorTranslator.FromHtml("#F9F9FA"));
                                            AccessForeColor = new Color(System.Drawing.ColorTranslator.FromHtml("#807F80"));
                                        }
                                        else
                                        {
                                            AccessBackColor = new Color(System.Drawing.ColorTranslator.FromHtml("#FF3300"));
                                            AccessForeColor = new Color(System.Drawing.ColorTranslator.FromHtml("#FFFF66"));

                                        }
                                    }
                                    else
                                    {
                                        AccessBackColor = new Color(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                                    }
                                }

                                else if (Access_ColorWhite == 1)
                                {
                                    if (orderDetail.FBIHDateRead == true)
                                    {
                                        if (orderDetail.IsShiped == true)
                                        {
                                            AccessBackColor = new Color(System.Drawing.ColorTranslator.FromHtml("#F9F9FA"));
                                            AccessForeColor = new Color(System.Drawing.ColorTranslator.FromHtml("#807F80"));
                                        }
                                        else
                                        {
                                            AccessBackColor = new Color(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                                            AccessForeColor = new Color(System.Drawing.ColorTranslator.FromHtml("#000000"));
                                        }
                                    }
                                    else
                                    {
                                        AccessBackColor = new Color(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));

                                    }
                                }

                                else
                                {
                                    if (orderDetail.FBIHDateRead == true)
                                    {
                                        if (orderDetail.IsShiped == true)
                                        {
                                            AccessBackColor = new Color(System.Drawing.ColorTranslator.FromHtml("#F9F9FA"));
                                            AccessForeColor = new Color(System.Drawing.ColorTranslator.FromHtml("#807F80"));
                                        }
                                        else
                                        {
                                            AccessBackColor = new Color(System.Drawing.ColorTranslator.FromHtml("#00FF70"));
                                            AccessForeColor = new Color(System.Drawing.ColorTranslator.FromHtml("#000000"));
                                        }
                                    }
                                    else
                                    {
                                        AccessBackColor = new Color(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                                        AccessForeColor = new Color(System.Drawing.ColorTranslator.FromHtml("#000000"));

                                    }
                                }
                            }

                            List<PDFCell> AccessRow = new List<PDFCell>();
                            PdfPTable ptAccess;
                            ptAccess = new PdfPTable(6) { WidthPercentage = 100 };

                            var AccessHeaderPhrase = new Phrase();

                            AccessHeaderPhrase.Add(Chunk.NEWLINE);
                            var BIHAccess = "";
                            if (orderDetail.FBIHDateRead)
                            {
                                BIHAccess = "B.I.H : " + orderDetail.BulkTarget.ToString("dd MMM yy (ddd)");
                            }

                            //Color AccessForColor = new Color(System.Drawing.ColorTranslator.FromHtml(orderDetail.BIHForColor));

                            var AccessHeaderFont = FontFactory.GetFont("trebuchet ms", 17, Font.BOLD, AccessForeColor);
                            AccessHeaderPhrase.Add(new Chunk(BIHAccess, AccessHeaderFont));

                            Color bAccesscolor = new Color(System.Drawing.ColorTranslator.FromHtml(orderDetail.BIHBackColor));

                            ptAccess.AddCell(new PdfPCell(AccessHeaderPhrase) { Colspan = 6, BorderColor = BorderColor, BackgroundColor = AccessBackColor, HorizontalAlignment = Element.ALIGN_CENTER, FixedHeight = 40, VerticalAlignment = Element.ALIGN_TOP, PaddingBottom = 5 });

                            AccessHeaderPhrase.Add(Chunk.NEWLINE);

                            foreach (MOOrderDetails.AccessoriesDetails AccessDetail in orderDetail.Accessories)
                            {
                                var AccessPhrase1 = new Phrase();

                                AccessPhrase1.Add(Chunk.NEWLINE);
                                var lblAccessories = "";
                                var lblParcentInHouse = "";
                                if (iKandi.Common.MOOrderDetails.AccApprovedOnRead)
                                {
                                    lblAccessories = AccessDetail.AccessoriesName;
                                }
                                if (iKandi.Common.MOOrderDetails.AccRecdRead)
                                {
                                    if (AccessDetail.Inhouse_Percent != 0)
                                    {
                                        lblParcentInHouse = AccessDetail.Inhouse_Percent + " %";
                                    }
                                }
                                var lblDateAcc = "";
                                if (iKandi.Common.MOOrderDetails.AccApprovedOnRead)
                                {
                                    if (AccessDetail.UpdatedOn != DateTime.MinValue)
                                    {
                                        lblDateAcc = AccessDetail.UpdatedOn.ToString("dd MMM");
                                    }
                                }
                                var txtQuantityAvail = "";
                                if (iKandi.Common.MOOrderDetails.AccAvilableOnRead)
                                {
                                  if (AccessDetail.QuantityAvail != "")
                                  {
                                    txtQuantityAvail = AccessDetail.QnAvail_k;
                                  }
                                }
                                var txtRequired = "";
                                if (iKandi.Common.MOOrderDetails.AccTotalRead)
                                {
                                    AccessDetail.Required = "0";
                                    if (AccessDetail.Required != "")
                                  {
                                    if (AccessDetail.Required != "")
                                    {
                                      double finalOrder1 = 0;
                                      finalOrder1 = Convert.ToDouble(Convert.ToString(AccessDetail.Required).Replace(",", ""));

                                      //Add By Prabhaker On 11-sep-18
                                      //double FinalOrderFabric1_kd = (finalOrder1 / 1000);
                                      //txtTotal.Text = Math.Round((FinalOrderFabric1_kd), 1, MidpointRounding.AwayFromZero).ToString() + "k";
                                      Double lac = 100000, thousand = 1000, crore = 10000000, tenk = 10000, tenl = 1000000, tencr = 100000000;

                                      if (finalOrder1 < tenk)
                                      {
                                        double QtyAvail_k = (finalOrder1 / thousand);
                                        txtRequired = Math.Round((QtyAvail_k), 1, MidpointRounding.AwayFromZero).ToString() + "k";
                                      }
                                      else if (finalOrder1 >= tenk && finalOrder1 < lac)
                                      {
                                        double QtyAvail_k = Math.Round((finalOrder1 / thousand), 0);
                                        if (QtyAvail_k < 100)
                                        {
                                          txtRequired = Math.Round((QtyAvail_k), 0, MidpointRounding.AwayFromZero).ToString() + "k";
                                        }
                                        else
                                        {
                                          txtRequired = Math.Round((QtyAvail_k / 100), 0, MidpointRounding.AwayFromZero).ToString() + "lc";
                                        }
                                      }
                                      else if (finalOrder1 >= lac && finalOrder1 < tenl)
                                      {
                                        double QtyAvail_k = Math.Round((finalOrder1 / lac), 1);
                                        txtRequired = Math.Round((QtyAvail_k), 1, MidpointRounding.AwayFromZero).ToString() + "lc";

                                      }
                                      else if (finalOrder1 >= tenl && finalOrder1 < crore)
                                      {
                                        double QtyAvail_k = Math.Round((finalOrder1 / lac), 0);
                                        if (QtyAvail_k < 100)
                                        {
                                          txtRequired = Math.Round((QtyAvail_k), 0, MidpointRounding.AwayFromZero).ToString() + "lc";
                                        }
                                        else
                                        {
                                          txtRequired = Math.Round((QtyAvail_k / 100), 0, MidpointRounding.AwayFromZero).ToString() + "cr";
                                        }

                                      }
                                      else if (finalOrder1 >= crore && finalOrder1 < tencr)
                                      {
                                        double QtyAvail_k = Math.Round((finalOrder1 / crore), 1);
                                        txtRequired = Math.Round((QtyAvail_k), 1, MidpointRounding.AwayFromZero).ToString() + "cr";

                                      }
                                      else
                                      {
                                        double QtyAvail_k = Math.Round((finalOrder1 / crore), 0);
                                        if (QtyAvail_k < 100)
                                        {
                                          txtRequired = Math.Round((QtyAvail_k), 0, MidpointRounding.AwayFromZero).ToString() + "cr";
                                        }
                                        else
                                        {
                                          txtRequired = Math.Round((QtyAvail_k / 100), 0, MidpointRounding.AwayFromZero).ToString() + "cr";
                                        }

                                      }

                                    }
                                    txtRequired = txtRequired == "0k" ? "" : txtRequired;
                                  }

                                   
                                }
                                var BIHETAAcc = "";
                                if (iKandi.Common.MOOrderDetails.AccessoriesETARead)
                                {
                                    if (AccessDetail.BIHETAAcc != DateTime.MinValue)
                                    {
                                        BIHETAAcc = AccessDetail.BIHETAAcc.ToString("dd MMM");
                                    }
                                }

                                Color AccessNameBackColor = new Color(System.Drawing.ColorTranslator.FromHtml(AccessDetail.AccessNameBackColor));
                                Color AccessNameForColor = new Color(System.Drawing.ColorTranslator.FromHtml(AccessDetail.AccessNameForColor));
                                var lblAccessoriesFont = FontFactory.GetFont("trebuchet ms", 10, Font.NORMAL, AccessNameForColor);

                                AccessPhrase1.Add(new Chunk(lblAccessories, lblAccessoriesFont));

                                ptAccess.AddCell(new PdfPCell(AccessPhrase1) { BorderWidth = 1, BorderColor = BorderColor, BackgroundColor = AccessNameBackColor, HorizontalAlignment = Element.ALIGN_LEFT, FixedHeight = 30, VerticalAlignment = Element.ALIGN_TOP });

                                var AccessPhrase2 = new Phrase();
                                Color AccessPercentInhouseBackColor = new Color(System.Drawing.ColorTranslator.FromHtml(AccessDetail.AccessPercentInhouseBackColor));
                                Color AccessPercentInhouseForColor = new Color(System.Drawing.ColorTranslator.FromHtml(AccessDetail.AccessPercentInhouseForColor));
                                var AccessPercentFont = FontFactory.GetFont("trebuchet ms", 10, Font.NORMAL, AccessPercentInhouseForColor);

                                AccessPhrase2.Add(new Chunk(lblParcentInHouse, AccessPercentFont));

                                ptAccess.AddCell(new PdfPCell(AccessPhrase2) { BorderWidth = 1, BorderColor = BorderColor, BackgroundColor = AccessPercentInhouseBackColor, HorizontalAlignment = Element.ALIGN_LEFT, FixedHeight = 30, VerticalAlignment = Element.ALIGN_TOP, PaddingTop = 5 });

                                var AccessPhrase3 = new Phrase();

                                Color AccessCaptionForColor = new Color(System.Drawing.ColorTranslator.FromHtml(AccessDetail.AccessPercentInhouseForColor));
                                var AccessCaptionFont = FontFactory.GetFont("trebuchet ms", 10, Font.NORMAL, AccessCaptionForColor);

                                AccessPhrase3.Add(new Chunk(lblDateAcc, AccessCaptionFont));

                                ptAccess.AddCell(new PdfPCell(AccessPhrase3) { BorderWidth = 1, BorderColor = BorderColor, HorizontalAlignment = Element.ALIGN_LEFT, FixedHeight = 30, VerticalAlignment = Element.ALIGN_TOP, PaddingTop = 5 });

                                var AccessPhrase4 = new Phrase();

                                AccessPhrase4.Add(new Chunk(txtQuantityAvail, AccessCaptionFont));

                                ptAccess.AddCell(new PdfPCell(AccessPhrase4) { BorderWidth = 1, BorderColor = BorderColor, HorizontalAlignment = Element.ALIGN_LEFT, FixedHeight = 30, VerticalAlignment = Element.ALIGN_TOP, PaddingTop = 5 });

                                var AccessPhrase5 = new Phrase();

                                AccessPhrase5.Add(new Chunk(txtRequired, AccessCaptionFont));

                                ptAccess.AddCell(new PdfPCell(AccessPhrase5) { BorderWidth = 1, BorderColor = BorderColor, HorizontalAlignment = Element.ALIGN_LEFT, FixedHeight = 30, VerticalAlignment = Element.ALIGN_TOP, PaddingTop = 5 });

                                var AccessPhrase6 = new Phrase();
                                Color AccessETABackColor = new Color(System.Drawing.ColorTranslator.FromHtml(AccessDetail.AccessETABackColor));
                                Color AccessETAForColor = new Color(System.Drawing.ColorTranslator.FromHtml(AccessDetail.AccessETAForColor));
                                var AccessETAFont = FontFactory.GetFont("trebuchet ms", 10, Font.NORMAL, AccessETAForColor);


                                AccessPhrase6.Add(new Chunk(BIHETAAcc, AccessETAFont));

                                ptAccess.AddCell(new PdfPCell(AccessPhrase6) { BorderWidth = 1, BorderColor = BorderColor, BackgroundColor = AccessETABackColor, HorizontalAlignment = Element.ALIGN_LEFT, FixedHeight = 30, VerticalAlignment = Element.ALIGN_TOP, PaddingTop = 5 });

                                //AccessPhrase.Add(Chunk.NEWLINE);                                                 

                            }

                            float[] columnWidths = new float[] { 20f, 11f, 26f, 10f, 10f, 26f };
                            ptAccess.SetWidths(columnWidths);

                            PDFCell AccessCell = new PDFCell(ptAccess);
                            AccessRow.Add(AccessCell);

                            gen.Rows.Add(AccessRow);

                            #endregion Accessories Section
                            // Accessories Section End

                            // Technical Section Start
                            #region Technical Section

                            List<PDFCell> TechnicalRow = new List<PDFCell>();
                            PdfPTable ptTechnical;
                            ptTechnical = new PdfPTable(3) { WidthPercentage = 100 };

                            var TechnicalHeaderPhrase = new Phrase();

                            TechnicalHeaderPhrase.Add(Chunk.NEWLINE);
                            var PCDTechnical = "";
                            if (orderDetail.FitsPCDRead)
                            {
                                PCDTechnical = "PCD : " + orderDetail.PCDDate.ToString("dd MMM yy (ddd)");
                            }

                            Color PCDForeColor = new Color(System.Drawing.ColorTranslator.FromHtml(orderDetail.PCDForeColor));

                            var TechnicalHeaderFont = FontFactory.GetFont("trebuchet ms", 17, Font.BOLD, PCDForeColor);
                            TechnicalHeaderPhrase.Add(new Chunk(PCDTechnical, TechnicalHeaderFont));

                            Color PCDBackColor = new Color(System.Drawing.ColorTranslator.FromHtml(orderDetail.PCDBackColor));

                            ptTechnical.AddCell(new PdfPCell(TechnicalHeaderPhrase) { Colspan = 3, BackgroundColor = PCDBackColor, BorderColor = BorderColor, BorderWidth = 1, HorizontalAlignment = Element.ALIGN_CENTER, FixedHeight = 40, VerticalAlignment = Element.ALIGN_TOP, PaddingBottom = 5 });

                            if (orderDetail.FitsLineRead == true)
                            {
                                TechnicalHeaderPhrase.Add(Chunk.NEWLINE);

                                var TechCostingPhrase = new Phrase();

                                //var TechCosting =  orderDetail.Samcap + " " + orderDetail.Samval + "   OB W/S " + orderDetail.OBval;

                                var lblst = "";

                                if (orderDetail.LinePlannigStartDate != "")
                                {
                                    lblst = "ST: " + orderDetail.LinePlannigStartDate;
                                }

                                var TechCosting = "";
                                //if (orderDetail.IsLinePlan == 1)
                                //{
                                //    TechCosting = orderDetail.Samcap + " " + orderDetail.Samval + "   OB W/S " + orderDetail.OBval;

                                //}
                                //else
                                //{
                                //    //TechCosting = orderDetail.Samcap + " " + orderDetail.Samval + "   OB W/S " + orderDetail.OBval + "   line " + orderDetail.LinesNo + "   day " + orderDetail.Days;
                                //    TechCosting = orderDetail.Samcap + " " + orderDetail.Samval + "   OB W/S " + orderDetail.OBval + " " + lblst;
                                //}

                                if (orderDetail.IsLinePlannigStartDate.ToLower() == "false")//abhishek
                                {
                                  TechCosting = orderDetail.Samcap + " " + orderDetail.Samval + "   OB W/S " + orderDetail.OBval;
                                }
                                else
                                {
                                  TechCosting = orderDetail.Samcap + " " + orderDetail.Samval + "   OB W/S " + orderDetail.OBval + "        " + lblst;
                                }

                                Color TechCostingForeColor = new Color(System.Drawing.ColorTranslator.FromHtml("#696969"));

                                var TechCostingFont = FontFactory.GetFont("trebuchet ms", 11, Font.NORMAL, TechCostingForeColor);
                                TechCostingPhrase.Add(new Chunk(TechCosting, TechCostingFont));


                                ptTechnical.AddCell(new PdfPCell(TechCostingPhrase) { Colspan = 3, Border = Rectangle.NO_BORDER, HorizontalAlignment = Element.ALIGN_LEFT, FixedHeight = 30, VerticalAlignment = Element.ALIGN_TOP, PaddingBottom = 5 });

                                TechCostingPhrase.Add(Chunk.NEWLINE);
                            }

                            if (orderDetail.FitsStatusRead == true) //abhishek 2/6/2017
                            {
                                var FitsStatusPhrase = new Phrase();
                                string FitsStatus;

                                if (orderDetail.FitStatus != string.Empty)
                                {
                                    FitsStatus = orderDetail.FitStatus;
                                }
                                else
                                {
                                    FitsStatus = "Show Sealer Pending Form";
                                }

                                Color FitsStatusForeColor = new Color(System.Drawing.ColorTranslator.FromHtml(orderDetail.LinktypeForeColorforfitspending));

                                Color FitsStatusBackColor = new Color(System.Drawing.ColorTranslator.FromHtml(orderDetail.FitsPandingColor));

                                var FitsStatusFont = FontFactory.GetFont("trebuchet ms", 12, Font.BOLD, FitsStatusForeColor);
                                FitsStatusPhrase.Add(new Chunk(FitsStatus, FitsStatusFont));

                                ptTechnical.AddCell(new PdfPCell(FitsStatusPhrase) { BackgroundColor = FitsStatusBackColor, Colspan = 3, Border = Rectangle.NO_BORDER, HorizontalAlignment = Element.ALIGN_CENTER, FixedHeight = 30, VerticalAlignment = Element.ALIGN_MIDDLE, PaddingBottom = 5 });

                                FitsStatusPhrase.Add(Chunk.NEWLINE);
                            }
                            //added by abhishek on 2/6/2017=====fits section===================================================//

                            // hand Over Section
                            Color STCtgtForeColor = new Color(System.Drawing.ColorTranslator.FromHtml("#696969"));

                            if (orderDetail.ParentOrder.Fits.SealDate == DateTime.MinValue)
                            {
                                var HandOverPhrase = new Phrase();
                                HandOverPhrase.Add(Chunk.NEWLINE);
                                var HandOver = "";
                                if (orderDetail.FitsTOPSentRead)
                                {
                                    string[] ArrayCad = null;
                                    //if (orderDetail.CADMaster != "")
                                    //{
                                    ArrayCad = orderDetail.CADMaster.Split(new string[] { " " }, StringSplitOptions.None);
                                    //}
                                    string str = "Hand Over" + " " + (ArrayCad[0].ToString() == "" ? "" : "(" + ArrayCad[0].ToString() + ")");
                                    HandOver = str;
                                }
                                if (orderDetail.IsShiped == true)
                                {
                                    STCNameBackColor = new Color(System.Drawing.ColorTranslator.FromHtml("#F9F9FA"));
                                    STCNameForeColor = new Color(System.Drawing.ColorTranslator.FromHtml("#807F80"));
                                }
                                else
                                {
                                    if (orderDetail.HandOverTargetDate.Date >= DateTime.Now.Date)
                                    {
                                        if (orderDetail.HandOverActualDate == DateTime.MinValue)
                                        {
                                            STCNameBackColor = new Color(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                                            STCNameForeColor = new Color(System.Drawing.ColorTranslator.FromHtml("#000000"));
                                        }
                                    }
                                    else
                                    {
                                        if (orderDetail.HandOverActualDate == DateTime.MinValue)
                                        {
                                            STCNameBackColor = new Color(System.Drawing.ColorTranslator.FromHtml("#FFFF66"));
                                            STCNameForeColor = new Color(System.Drawing.ColorTranslator.FromHtml("#FF3300"));
                                        }
                                    }
                                }

                                if (orderDetail.HandOverETADate != DateTime.MinValue && orderDetail.HandOverActualDate != DateTime.MinValue)
                                {
                                    STCNameBackColor = new Color(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                                    STCNameForeColor = Color.GRAY;
                                }
                                if (orderDetail.FitsTOPSentRead != true)
                                {
                                    STCNameBackColor = new Color(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                                    STCNameForeColor = Color.GRAY;
                                }
                                var HandOverFont = FontFactory.GetFont("trebuchet ms", 11, Font.NORMAL, STCNameForeColor);
                                HandOverPhrase.Add(new Chunk(HandOver, HandOverFont));
                                ptTechnical.AddCell(new PdfPCell(HandOverPhrase) { Border = Rectangle.BOTTOM_BORDER, BorderColor = BorderColor, BackgroundColor = STCNameBackColor, HorizontalAlignment = Element.ALIGN_LEFT, FixedHeight = 40, VerticalAlignment = Element.ALIGN_MIDDLE, PaddingBottom = 5 });
                                var HandOverTargetPhrase = new Phrase();

                                var FitsHandOverTarget = "";
                                if (orderDetail.FitsTopSentTargetDateRead)
                                {
                                    if (orderDetail.HandOverTargetDate != DateTime.MinValue)
                                    {
                                        FitsHandOverTarget = orderDetail.HandOverTargetDate.ToString("dd MMM");
                                    }
                                }
                                var FitsHandOverActual = "";
                                if (orderDetail.FitsTopSentTargetDateRead)
                                {
                                    if (orderDetail.HandOverActualDate != DateTime.MinValue)
                                    {
                                        FitsHandOverActual = orderDetail.HandOverActualDate.ToString("dd MMM");
                                    }
                                }

                                var HandOverSendTarget = FitsHandOverTarget + "\n ---------------------------" + "\n" + FitsHandOverActual;
                                var HandOverTargetFont = FontFactory.GetFont("trebuchet ms", 11, Font.NORMAL, STCtgtForeColor);
                                HandOverTargetPhrase.Add(new Chunk(HandOverSendTarget, HandOverTargetFont));
                                ptTechnical.AddCell(new PdfPCell(HandOverTargetPhrase) { Border = Rectangle.BOTTOM_BORDER, BorderWidthLeft = 1, BorderColor = BorderColor, HorizontalAlignment = Element.ALIGN_CENTER, FixedHeight = 40, VerticalAlignment = Element.ALIGN_TOP, PaddingBottom = 5 });
                                var HandOverETAPhrase = new Phrase();
                                string HandOverETA = "";
                                if (orderDetail.FitsTOPSentETARead)
                                {
                                    if (orderDetail.HandOverActualDate != DateTime.MinValue)
                                    {
                                        HandOverETA = orderDetail.HandOverActualDate.ToString("dd MMM");
                                    }
                                    if (orderDetail.HandOverETADate != DateTime.MinValue)
                                    {
                                        HandOverETA = orderDetail.HandOverETADate.ToString("dd MMM");
                                    }
                                }
                                Color HandOverETAForeColor = new Color(System.Drawing.ColorTranslator.FromHtml(orderDetail.HandOverETAForeColor));
                                Color HandOverETABackColor = new Color(System.Drawing.ColorTranslator.FromHtml(orderDetail.HandOverETABackColor));

                                var HandOverETAFont = FontFactory.GetFont("trebuchet ms", 11, Font.NORMAL, HandOverETAForeColor);
                                HandOverETAPhrase.Add(new Chunk(HandOverETA, HandOverETAFont));
                                ptTechnical.AddCell(new PdfPCell(HandOverETAPhrase) { BackgroundColor = HandOverETABackColor, Border = Rectangle.BOTTOM_BORDER, BorderWidthLeft = 1, BorderColor = BorderColor, HorizontalAlignment = Element.ALIGN_CENTER, FixedHeight = 40, VerticalAlignment = Element.ALIGN_MIDDLE, PaddingBottom = 5 });
                                // End hand over section
                            }
                            // PatternReady Section                           

                            if (orderDetail.ParentOrder.Fits.SealDate == DateTime.MinValue)
                            {
                                var PatternReadyPhrase = new Phrase();
                                PatternReadyPhrase.Add(Chunk.NEWLINE);
                                var PatternReady = "";
                                if (orderDetail.FitsTOPSentRead)
                                {
                                    PatternReady = "Pattern Ready";
                                }
                                if (orderDetail.IsShiped == true)
                                {
                                    STCNameBackColor = new Color(System.Drawing.ColorTranslator.FromHtml("#F9F9FA"));
                                    STCNameForeColor = new Color(System.Drawing.ColorTranslator.FromHtml("#807F80"));
                                }
                                else
                                {
                                    if (orderDetail.PatternReadyTargetDate.Date >= DateTime.Now.Date)
                                    {
                                        if (orderDetail.PatternReadyActualDate == DateTime.MinValue)
                                        {
                                            STCNameBackColor = new Color(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                                            STCNameForeColor = new Color(System.Drawing.ColorTranslator.FromHtml("#000000"));
                                        }
                                    }
                                    else
                                    {
                                        if (orderDetail.PatternReadyActualDate == DateTime.MinValue)
                                        {
                                            STCNameBackColor = new Color(System.Drawing.ColorTranslator.FromHtml("#FFFF66"));
                                            STCNameForeColor = new Color(System.Drawing.ColorTranslator.FromHtml("#FF3300"));
                                        }
                                    }
                                }

                                if (orderDetail.PatternReadyETADate != DateTime.MinValue && orderDetail.PatternReadyActualDate != DateTime.MinValue)
                                {
                                    STCNameBackColor = new Color(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                                    STCNameForeColor = Color.GRAY;
                                }
                                if (orderDetail.FitsTOPSentRead != true)
                                {
                                    STCNameBackColor = new Color(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                                    STCNameForeColor = Color.GRAY;
                                }
                                var PatternReadyFont = FontFactory.GetFont("trebuchet ms", 11, Font.NORMAL, STCNameForeColor);
                                PatternReadyPhrase.Add(new Chunk(PatternReady, PatternReadyFont));
                                ptTechnical.AddCell(new PdfPCell(PatternReadyPhrase) { Border = Rectangle.BOTTOM_BORDER, BorderColor = BorderColor, BackgroundColor = STCNameBackColor, HorizontalAlignment = Element.ALIGN_LEFT, FixedHeight = 40, VerticalAlignment = Element.ALIGN_MIDDLE, PaddingBottom = 5 });
                                var PatternReadyTargetPhrase = new Phrase();

                                var FitsPatternReadyTarget = "";
                                if (orderDetail.FitsTopSentTargetDateRead)
                                {
                                    if (orderDetail.PatternReadyTargetDate != DateTime.MinValue)
                                    {
                                        FitsPatternReadyTarget = orderDetail.PatternReadyTargetDate.ToString("dd MMM");
                                    }
                                }
                                var FitsPatternReadyActual = "";
                                if (orderDetail.FitsTopSentTargetDateRead)
                                {
                                    if (orderDetail.PatternReadyActualDate != DateTime.MinValue)
                                    {
                                        FitsPatternReadyActual = orderDetail.PatternReadyActualDate.ToString("dd MMM");
                                    }
                                }

                                var PatternReadySendTarget = FitsPatternReadyTarget + "\n ---------------------------" + "\n" + FitsPatternReadyActual;
                                var PatternReadyTargetFont = FontFactory.GetFont("trebuchet ms", 11, Font.NORMAL, STCtgtForeColor);
                                PatternReadyTargetPhrase.Add(new Chunk(PatternReadySendTarget, PatternReadyTargetFont));
                                ptTechnical.AddCell(new PdfPCell(PatternReadyTargetPhrase) { Border = Rectangle.BOTTOM_BORDER, BorderWidthLeft = 1, BorderColor = BorderColor, HorizontalAlignment = Element.ALIGN_CENTER, FixedHeight = 40, VerticalAlignment = Element.ALIGN_TOP, PaddingBottom = 5 });
                                var PatternReadyETAPhrase = new Phrase();
                                string PatternReadyETA = "";
                                if (orderDetail.FitsTOPSentETARead)
                                {
                                    if (orderDetail.PatternReadyActualDate != DateTime.MinValue)
                                    {
                                        PatternReadyETA = orderDetail.PatternReadyActualDate.ToString("dd MMM");
                                    }
                                    if (orderDetail.PatternReadyETADate != DateTime.MinValue)
                                    {
                                        PatternReadyETA = orderDetail.PatternReadyETADate.ToString("dd MMM");
                                    }
                                }
                                Color PatternReadyETAForeColor = new Color(System.Drawing.ColorTranslator.FromHtml(orderDetail.PatternReadyETAForeColor));
                                Color PatternReadyETABackColor = new Color(System.Drawing.ColorTranslator.FromHtml(orderDetail.PatternReadyETABackColor));

                                var PatternReadyETAFont = FontFactory.GetFont("trebuchet ms", 11, Font.NORMAL, PatternReadyETAForeColor);
                                PatternReadyETAPhrase.Add(new Chunk(PatternReadyETA, PatternReadyETAFont));
                                ptTechnical.AddCell(new PdfPCell(PatternReadyETAPhrase) { BackgroundColor = PatternReadyETABackColor, Border = Rectangle.BOTTOM_BORDER, BorderWidthLeft = 1, BorderColor = BorderColor, HorizontalAlignment = Element.ALIGN_CENTER, FixedHeight = 40, VerticalAlignment = Element.ALIGN_MIDDLE, PaddingBottom = 5 });
                                // End PatternReady section
                            }
                            // SampleSent Section  

                            if (orderDetail.ParentOrder.Fits.SealDate == DateTime.MinValue)
                            {
                                var SampleSentPhrase = new Phrase();
                                SampleSentPhrase.Add(Chunk.NEWLINE);
                                var SampleSent = "";
                                if (orderDetail.FitsTOPSentRead)
                                {
                                    SampleSent = "Sample Sent";
                                }
                                if (orderDetail.IsShiped == true)
                                {
                                    STCNameBackColor = new Color(System.Drawing.ColorTranslator.FromHtml("#F9F9FA"));
                                    STCNameForeColor = new Color(System.Drawing.ColorTranslator.FromHtml("#807F80"));
                                }
                                else
                                {
                                    if (orderDetail.SampleSentTargetDate.Date >= DateTime.Now.Date)
                                    {
                                        if (orderDetail.SampleSentActualDate == DateTime.MinValue)
                                        {
                                            STCNameBackColor = new Color(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                                            STCNameForeColor = new Color(System.Drawing.ColorTranslator.FromHtml("#000000"));
                                        }
                                    }
                                    else
                                    {
                                        if (orderDetail.SampleSentActualDate == DateTime.MinValue)
                                        {
                                            STCNameBackColor = new Color(System.Drawing.ColorTranslator.FromHtml("#FFFF66"));
                                            STCNameForeColor = new Color(System.Drawing.ColorTranslator.FromHtml("#FF3300"));
                                        }
                                    }
                                }

                                if (orderDetail.SampleSentETADate != DateTime.MinValue && orderDetail.SampleSentActualDate != DateTime.MinValue)
                                {
                                    STCNameBackColor = new Color(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                                    STCNameForeColor = Color.GRAY;
                                }
                                if (orderDetail.FitsTOPSentRead != true)
                                {
                                    STCNameBackColor = new Color(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                                    STCNameForeColor = Color.GRAY;
                                }
                                var SampleSentFont = FontFactory.GetFont("trebuchet ms", 11, Font.NORMAL, STCNameForeColor);
                                SampleSentPhrase.Add(new Chunk(SampleSent, SampleSentFont));
                                ptTechnical.AddCell(new PdfPCell(SampleSentPhrase) { Border = Rectangle.BOTTOM_BORDER, BorderColor = BorderColor, BackgroundColor = STCNameBackColor, HorizontalAlignment = Element.ALIGN_LEFT, FixedHeight = 40, VerticalAlignment = Element.ALIGN_MIDDLE, PaddingBottom = 5 });
                                var SampleSentTargetPhrase = new Phrase();

                                var FitsSampleSentTarget = "";
                                if (orderDetail.FitsTopSentTargetDateRead)
                                {
                                    if (orderDetail.SampleSentTargetDate != DateTime.MinValue)
                                    {
                                        FitsSampleSentTarget = orderDetail.SampleSentTargetDate.ToString("dd MMM");
                                    }
                                }
                                var FitsSampleSentActual = "";
                                if (orderDetail.FitsTopSentTargetDateRead)
                                {
                                    if (orderDetail.SampleSentActualDate != DateTime.MinValue)
                                    {
                                        FitsSampleSentActual = orderDetail.SampleSentActualDate.ToString("dd MMM");
                                    }
                                }

                                var SampleSentSendTarget = FitsSampleSentTarget + "\n ---------------------------" + "\n" + FitsSampleSentActual;
                                var SampleSentTargetFont = FontFactory.GetFont("trebuchet ms", 11, Font.NORMAL, STCtgtForeColor);
                                SampleSentTargetPhrase.Add(new Chunk(SampleSentSendTarget, SampleSentTargetFont));
                                ptTechnical.AddCell(new PdfPCell(SampleSentTargetPhrase) { Border = Rectangle.BOTTOM_BORDER, BorderWidthLeft = 1, BorderColor = BorderColor, HorizontalAlignment = Element.ALIGN_CENTER, FixedHeight = 40, VerticalAlignment = Element.ALIGN_TOP, PaddingBottom = 5 });
                                var SampleSentETAPhrase = new Phrase();
                                string SampleSentETA = "";
                                if (orderDetail.FitsTOPSentETARead)
                                {
                                    if (orderDetail.SampleSentActualDate != DateTime.MinValue)
                                    {
                                        SampleSentETA = orderDetail.SampleSentActualDate.ToString("dd MMM");
                                    }
                                    if (orderDetail.SampleSentETADate != DateTime.MinValue)
                                    {
                                        SampleSentETA = orderDetail.SampleSentETADate.ToString("dd MMM");
                                    }
                                }
                                Color SampleSentETAForeColor = new Color(System.Drawing.ColorTranslator.FromHtml(orderDetail.SampleSentETAForeColor));
                                Color SampleSentETABackColor = new Color(System.Drawing.ColorTranslator.FromHtml(orderDetail.SampleSentETABackColor));

                                var SampleSentETAFont = FontFactory.GetFont("trebuchet ms", 11, Font.NORMAL, SampleSentETAForeColor);
                                SampleSentETAPhrase.Add(new Chunk(SampleSentETA, SampleSentETAFont));
                                ptTechnical.AddCell(new PdfPCell(SampleSentETAPhrase) { BackgroundColor = SampleSentETABackColor, Border = Rectangle.BOTTOM_BORDER, BorderWidthLeft = 1, BorderColor = BorderColor, HorizontalAlignment = Element.ALIGN_CENTER, FixedHeight = 40, VerticalAlignment = Element.ALIGN_MIDDLE, PaddingBottom = 5 });
                            }
                            // End SampleSent section
                            // FitsUpload Section                 

                            if (orderDetail.ParentOrder.Fits.SealDate == DateTime.MinValue)
                            {
                                var FitsUploadPhrase = new Phrase();
                                FitsUploadPhrase.Add(Chunk.NEWLINE);
                                var FitsUpload = "";
                                if (orderDetail.FitsTOPSentRead)
                                {
                                    FitsUpload = "Fits Cmnt. Upload";
                                }
                                if (orderDetail.IsShiped == true)
                                {
                                    STCNameBackColor = new Color(System.Drawing.ColorTranslator.FromHtml("#F9F9FA"));
                                    STCNameForeColor = new Color(System.Drawing.ColorTranslator.FromHtml("#807F80"));
                                }
                                else
                                {
                                    if (orderDetail.FitsCommentesTargetDate.Date >= DateTime.Now.Date)
                                    {
                                        if (orderDetail.FitsCommentesActualDate == DateTime.MinValue)
                                        {
                                            STCNameBackColor = new Color(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                                            STCNameForeColor = new Color(System.Drawing.ColorTranslator.FromHtml("#000000"));
                                        }
                                    }
                                    else
                                    {
                                        if (orderDetail.FitsCommentesActualDate == DateTime.MinValue)
                                        {
                                            STCNameBackColor = new Color(System.Drawing.ColorTranslator.FromHtml("#FFFF66"));
                                            STCNameForeColor = new Color(System.Drawing.ColorTranslator.FromHtml("#FF3300"));
                                        }
                                    }
                                }

                                if (orderDetail.FitsCommentesETADate != DateTime.MinValue && orderDetail.FitsCommentesActualDate != DateTime.MinValue)
                                {
                                    STCNameBackColor = new Color(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                                    STCNameForeColor = Color.GRAY;
                                }
                                if (orderDetail.FitsTOPSentRead != true)
                                {
                                    STCNameBackColor = new Color(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                                    STCNameForeColor = Color.GRAY;
                                }
                                var FitsUploadFont = FontFactory.GetFont("trebuchet ms", 11, Font.NORMAL, STCNameForeColor);
                                FitsUploadPhrase.Add(new Chunk(FitsUpload, FitsUploadFont));
                                ptTechnical.AddCell(new PdfPCell(FitsUploadPhrase) { Border = Rectangle.BOTTOM_BORDER, BorderColor = BorderColor, BackgroundColor = STCNameBackColor, HorizontalAlignment = Element.ALIGN_LEFT, FixedHeight = 40, VerticalAlignment = Element.ALIGN_MIDDLE, PaddingBottom = 5 });
                                var FitsUploadTargetPhrase = new Phrase();

                                var FitsFitsUploadTarget = "";
                                if (orderDetail.FitsTopSentTargetDateRead)
                                {
                                    if (orderDetail.FitsCommentesTargetDate != DateTime.MinValue)
                                    {
                                        FitsFitsUploadTarget = orderDetail.FitsCommentesTargetDate.ToString("dd MMM");
                                    }
                                }
                                var FitsFitsUploadActual = "";
                                if (orderDetail.FitsTopSentTargetDateRead)
                                {
                                    if (orderDetail.FitsCommentesActualDate != DateTime.MinValue)
                                    {
                                        FitsFitsUploadActual = orderDetail.FitsCommentesActualDate.ToString("dd MMM");
                                    }
                                }

                                var FitsUploadSendTarget = FitsFitsUploadTarget + "\n ---------------------------" + "\n" + FitsFitsUploadActual;
                                var FitsUploadTargetFont = FontFactory.GetFont("trebuchet ms", 11, Font.NORMAL, STCtgtForeColor);
                                FitsUploadTargetPhrase.Add(new Chunk(FitsUploadSendTarget, FitsUploadTargetFont));
                                ptTechnical.AddCell(new PdfPCell(FitsUploadTargetPhrase) { Border = Rectangle.BOTTOM_BORDER, BorderWidthLeft = 1, BorderColor = BorderColor, HorizontalAlignment = Element.ALIGN_CENTER, FixedHeight = 40, VerticalAlignment = Element.ALIGN_TOP, PaddingBottom = 5 });
                                var FitsUploadETAPhrase = new Phrase();
                                string FitsUploadETA = "";
                                if (orderDetail.FitsTOPSentETARead)
                                {
                                    if (orderDetail.FitsCommentesActualDate != DateTime.MinValue)
                                    {
                                        FitsUploadETA = orderDetail.FitsCommentesActualDate.ToString("dd MMM");
                                    }
                                    if (orderDetail.FitsCommentesETADate != DateTime.MinValue)
                                    {
                                        FitsUploadETA = orderDetail.FitsCommentesETADate.ToString("dd MMM");
                                    }
                                }
                                Color FitsUploadETAForeColor = new Color(System.Drawing.ColorTranslator.FromHtml(orderDetail.FitsCommentesETAForeColor));
                                Color FitsUploadETABackColor = new Color(System.Drawing.ColorTranslator.FromHtml(orderDetail.FitsCommentesETABackColor));

                                var FitsUploadETAFont = FontFactory.GetFont("trebuchet ms", 11, Font.NORMAL, FitsUploadETAForeColor);
                                FitsUploadETAPhrase.Add(new Chunk(FitsUploadETA, FitsUploadETAFont));
                                ptTechnical.AddCell(new PdfPCell(FitsUploadETAPhrase) { BackgroundColor = FitsUploadETABackColor, Border = Rectangle.BOTTOM_BORDER, BorderWidthLeft = 1, BorderColor = BorderColor, HorizontalAlignment = Element.ALIGN_CENTER, FixedHeight = 40, VerticalAlignment = Element.ALIGN_MIDDLE, PaddingBottom = 5 });
                            }
                            // End FitsUpload section
                            //End abhishek=========================================================================================================//

                            // PP Sample Sent Section abhishek 9/9/2018

                            if (orderDetail.ParentOrder.Fits.SealDate != DateTime.MinValue)
                            {
                              var ProdFilePhrase = new Phrase();

                              ProdFilePhrase.Add(Chunk.NEWLINE);
                              var ProdFileSheet = "";
                              if (orderDetail.FitsProdFileRead)
                              {
                                ProdFileSheet = "PP Sample Sent";
                              }

                              if (orderDetail.IsShiped == true)
                              {
                                STCNameBackColor = new Color(System.Drawing.ColorTranslator.FromHtml("#F9F9FA"));
                                STCNameForeColor = new Color(System.Drawing.ColorTranslator.FromHtml("#807F80"));
                              }
                              else
                              {

                                //if (orderDetail.PPSampleTgtDate.Date >= DateTime.Now.Date)
                                //{

                                //  if (orderDetail.ProductionFileDate == DateTime.MinValue)
                                //  {
                                //    STCNameBackColor = new Color(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                                //    STCNameForeColor = new Color(System.Drawing.ColorTranslator.FromHtml("#000000"));
                                //  }
                                //}
                                //else
                                //{
                                //  if (orderDetail.ProductionFileDate == DateTime.MinValue)
                                //  {
                                //    STCNameBackColor = new Color(System.Drawing.ColorTranslator.FromHtml("#FFFF66"));
                                //    STCNameForeColor = new Color(System.Drawing.ColorTranslator.FromHtml("#FF3300"));
                                //  }
                                //}
                              }
                              STCNameForeColor = Color.GRAY;
                              if (orderDetail.PPSampleETA != DateTime.MinValue)
                              {
                                STCNameBackColor = new Color(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                                STCNameForeColor = Color.GRAY;
                              }

                              if (orderDetail.FitsProdFileRead != true)
                              {
                                STCNameBackColor = new Color(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                                STCNameForeColor = Color.GRAY;
                              }

                              var ProdFiletFont = FontFactory.GetFont("trebuchet ms", 11, Font.NORMAL, STCNameForeColor);
                              ProdFilePhrase.Add(new Chunk(ProdFileSheet, ProdFiletFont));

                              //Color PatternSampleForeColor = new Color(System.Drawing.ColorTranslator.FromHtml("#696969"));

                              ptTechnical.AddCell(new PdfPCell(ProdFilePhrase) { Border = Rectangle.BOTTOM_BORDER, BorderColor = BorderColor, BackgroundColor = STCNameBackColor, HorizontalAlignment = Element.ALIGN_LEFT, FixedHeight = 40, VerticalAlignment = Element.ALIGN_MIDDLE, PaddingBottom = 5 });

                              var ProdPhrase = new Phrase();

                              var ProdTargetDate = "";
                              //if (orderDetail.FitsProdTargetDateRead)abhishek
                              //{
                              //    if (orderDetail.STCDateReqTarCutting != DateTime.MinValue)
                              //    {
                              //        ProdTargetDate = orderDetail.STCDateReqTarCutting.ToString("dd MMM yy (ddd)");
                              //    }
                              //}
                              if (orderDetail.FitsProdTargetDateRead)
                              {
                                if (orderDetail.PPSampleTgtDate != DateTime.MinValue)
                                {
                                  ProdTargetDate = orderDetail.PPSampleTgtDate.ToString("dd MMM");
                                }
                              }

                              var ProdActualDate = "";
                              //if (orderDetail.FitsProdActualDateRead)
                              //{
                              //  if (orderDetail.ProductionFileDate != DateTime.MinValue)
                              //  {
                              //    ProdActualDate = orderDetail.ProductionFileDate.ToString("dd MMM yy (ddd)");
                              //  }
                              //}
                              var ProdReq = ProdTargetDate + "\n ---------------------------" + "\n" + ProdActualDate;

                              var ProdReqFont = FontFactory.GetFont("trebuchet ms", 11, Font.NORMAL, STCtgtForeColor);
                              ProdPhrase.Add(new Chunk(ProdReq, ProdReqFont));

                              ptTechnical.AddCell(new PdfPCell(ProdPhrase) { Border = Rectangle.BOTTOM_BORDER, BorderWidthLeft = 1, BorderColor = BorderColor, HorizontalAlignment = Element.ALIGN_CENTER, FixedHeight = 40, VerticalAlignment = Element.ALIGN_TOP, PaddingBottom = 5 });

                              var ProductionETAPhrase = new Phrase();
                              string ProductionETA = "";
                              if (orderDetail.FitsProdFileETARead)
                              {
                                if (orderDetail.PPSampleETA != DateTime.MinValue)
                                {
                                  ProductionETA = orderDetail.PPSampleETA.ToString("dd MMM");
                                }
                              }

                              Color ProductionETAForeColor = new Color(System.Drawing.ColorTranslator.FromHtml(orderDetail.FitsProdETAForColor));
                              Color ProductionETABackColor = new Color(System.Drawing.ColorTranslator.FromHtml(orderDetail.FitsProdETABackColor));

                              var ProductionETAFont = FontFactory.GetFont("trebuchet ms", 11, Font.NORMAL, ProductionETAForeColor);
                              ProductionETAPhrase.Add(new Chunk(ProductionETA, ProductionETAFont));

                              ptTechnical.AddCell(new PdfPCell(ProductionETAPhrase) { BackgroundColor = ProductionETABackColor, Border = Rectangle.BOTTOM_BORDER, BorderWidthLeft = 1, BorderColor = BorderColor, HorizontalAlignment = Element.ALIGN_CENTER, FixedHeight = 40, VerticalAlignment = Element.ALIGN_MIDDLE, PaddingBottom = 5 });
                            }
                            // End PP Sample Sent section

                            // STC Section 

                            //if (orderDetail.ParentOrder.Fits.SealDate != DateTime.MinValue)
                            //{
                                var STCNamePhrase = new Phrase();
                                var STCName = "";
                                if (orderDetail.FitsStcRead)
                                {
                                    STCName = "STC";
                                }

                                //if (orderDetail.STCDateReqTar.Date >= DateTime.Now.Date)
                                //{
                                //    if (orderDetail.ParentOrder.Fits.SealDate == DateTime.MinValue)
                                //    {
                                //        STCNameBackColor = new Color(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                                //        STCNameForeColor = new Color(System.Drawing.ColorTranslator.FromHtml("#000000"));
                                //    }
                                //}
                                if (orderDetail.STCtargetsDate.Date >= DateTime.Now.Date)
                                {
                                    if (orderDetail.ParentOrder.Fits.SealDate == DateTime.MinValue)
                                    {
                                        STCNameBackColor = new Color(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                                        STCNameForeColor = new Color(System.Drawing.ColorTranslator.FromHtml("#000000"));
                                    }
                                }
                                else
                                {
                                    if (orderDetail.ParentOrder.Fits.SealDate == DateTime.MinValue)
                                    {
                                        STCNameBackColor = new Color(System.Drawing.ColorTranslator.FromHtml("#FFFF66"));
                                        STCNameForeColor = new Color(System.Drawing.ColorTranslator.FromHtml("#FF3300"));
                                    }
                                }

                                //if (orderDetail.ParentOrder.Fits.SealDate != DateTime.MinValue)
                                //{
                                //    iStcBackColor = 1;
                                //}
                                if (orderDetail.STCETA != DateTime.MinValue && orderDetail.ParentOrder.Fits.SealDate != DateTime.MinValue)
                                {
                                    STCNameBackColor = new Color(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                                    STCNameForeColor = Color.GRAY;
                                }

                                //if (iStcBackColor == 1)
                                //{
                                //    STCNameBackColor = new Color(System.Drawing.ColorTranslator.FromHtml("#FFFF66"));
                                //    STCNameForeColor = new Color(System.Drawing.ColorTranslator.FromHtml("#FF3300"));
                                //}
                                //else
                                //{
                                //    STCNameBackColor = new Color(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                                //    STCNameForeColor = Color.GRAY;
                                //}

                                if (orderDetail.IsShiped == true)
                                {
                                    STCNameBackColor = new Color(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                                    STCNameForeColor = Color.GRAY;
                                }


                                var STCNameFont = FontFactory.GetFont("trebuchet ms", 11, Font.NORMAL, STCNameForeColor);
                                STCNamePhrase.Add(new Chunk(STCName, STCNameFont));



                                ptTechnical.AddCell(new PdfPCell(STCNamePhrase) { Border = Rectangle.BOTTOM_BORDER, BorderWidthTop = Rectangle.TOP_BORDER, BorderColor = BorderColor, BackgroundColor = STCNameBackColor, HorizontalAlignment = Element.ALIGN_LEFT, FixedHeight = 40, VerticalAlignment = Element.ALIGN_MIDDLE, PaddingBottom = 5 });

                                var STCtgtPhrase = new Phrase();

                                var StcTargetDate = "";
                                if (orderDetail.FitsStcTargetDateRead)
                                {
                                    //if (orderDetail.STCDateReqTar != DateTime.MinValue)
                                    //{
                                    //    //abhishek
                                    //    StcTargetDate = orderDetail.STCDateReqTar.ToString("dd MMM yy (ddd)");

                                    //} 
                                    if (orderDetail.STCtargetsDate != DateTime.MinValue)
                                    {
                                        //abhishek
                                        StcTargetDate = orderDetail.STCtargetsDate.ToString("dd MMM");

                                    }
                                }

                                var SealDate = "";
                                if (orderDetail.FitsStcActualDateRead)
                                {
                                    if (orderDetail.ParentOrder.Fits.SealDate != DateTime.MinValue)
                                    {
                                        SealDate = orderDetail.ParentOrder.Fits.SealDate.ToString("dd MMM");
                                    }
                                }

                                var STCtgt = StcTargetDate + "\n ---------------------------" + "\n" + SealDate;

                                var STCtgtFont = FontFactory.GetFont("trebuchet ms", 11, Font.NORMAL, STCtgtForeColor);
                                STCtgtPhrase.Add(new Chunk(STCtgt, STCtgtFont));

                                ptTechnical.AddCell(new PdfPCell(STCtgtPhrase) { Border = Rectangle.BOTTOM_BORDER, BorderWidthTop = Rectangle.TOP_BORDER, BorderWidthLeft = 1, BorderColor = BorderColor, HorizontalAlignment = Element.ALIGN_CENTER, FixedHeight = 40, VerticalAlignment = Element.ALIGN_TOP, PaddingBottom = 5 });

                                var STCETAPhrase = new Phrase();
                                string STCETA = "";
                                if (orderDetail.FitsSTCETARead)
                                {
                                    if (orderDetail.ParentOrder.Fits.SealDate == DateTime.MinValue)
                                    {
                                        if (orderDetail.STCETA != DateTime.MinValue)
                                        {
                                            STCETA = orderDetail.STCETA.ToString("dd MMM");
                                        }
                                    }
                                    else
                                    {
                                        STCETA = orderDetail.ParentOrder.Fits.SealDate.ToString("dd MMM");
                                    }
                                }
                                Color STCETAForeColor = new Color(System.Drawing.ColorTranslator.FromHtml(orderDetail.FitsSTCETAForColor));
                                Color STCETABackColor = new Color(System.Drawing.ColorTranslator.FromHtml(orderDetail.FitsSTCETABackColor));

                                var STCETAFont = FontFactory.GetFont("trebuchet ms", 11, Font.NORMAL, STCETAForeColor);
                                STCETAPhrase.Add(new Chunk(STCETA, STCETAFont));

                                ptTechnical.AddCell(new PdfPCell(STCETAPhrase) { BackgroundColor = STCETABackColor, Border = Rectangle.BOTTOM_BORDER, BorderWidthTop = Rectangle.TOP_BORDER, BorderWidthLeft = 1, BorderColor = BorderColor, HorizontalAlignment = Element.ALIGN_CENTER, FixedHeight = 40, VerticalAlignment = Element.ALIGN_MIDDLE, PaddingBottom = 5 });
                           // }
                            // End STC section


                            // Pattern Sample Section
                            if (orderDetail.ParentOrder.Fits.SealDate != DateTime.MinValue)//abhishek if ETA SealDate done then hide row 27/6/2017
                            {
                                var PatternSamplePhrase = new Phrase();

                                PatternSamplePhrase.Add(Chunk.NEWLINE);

                                var PatternSample = "";
                                if (orderDetail.FitsPatternRead)
                                {
                                    PatternSample = "Pattern Sample";
                                }

                                if (orderDetail.IsShiped == true)
                                {
                                    STCNameBackColor = new Color(System.Drawing.ColorTranslator.FromHtml("#F9F9FA"));
                                    STCNameForeColor = new Color(System.Drawing.ColorTranslator.FromHtml("#807F80"));
                                }
                                else
                                {

                                    if (orderDetail.PatternSampleTarget.Date >= DateTime.Now.Date)
                                    {

                                        if (orderDetail.PatternSampleDate == DateTime.MinValue)
                                        {
                                            STCNameBackColor = new Color(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                                            STCNameForeColor = new Color(System.Drawing.ColorTranslator.FromHtml("#000000"));
                                        }
                                    }
                                    else
                                    {
                                        if (orderDetail.PatternSampleDate == DateTime.MinValue)
                                        {
                                            STCNameBackColor = new Color(System.Drawing.ColorTranslator.FromHtml("#FFFF66"));
                                            STCNameForeColor = new Color(System.Drawing.ColorTranslator.FromHtml("#FF3300"));
                                        }
                                    }
                                }

                                if (orderDetail.PatternSampleDateETA != DateTime.MinValue && orderDetail.PatternSampleDate != DateTime.MinValue)
                                {
                                    STCNameBackColor = new Color(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                                    STCNameForeColor = Color.GRAY;
                                }
                                if (orderDetail.FitsPatternRead != true)
                                {
                                    STCNameBackColor = new Color(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                                    STCNameForeColor = Color.GRAY;
                                }

                                var PatternSampleFont = FontFactory.GetFont("trebuchet ms", 11, Font.NORMAL, STCNameForeColor);
                                PatternSamplePhrase.Add(new Chunk(PatternSample, PatternSampleFont));

                                //Color PatternSampleForeColor = new Color(System.Drawing.ColorTranslator.FromHtml("#696969"));

                                ptTechnical.AddCell(new PdfPCell(PatternSamplePhrase) { Border = Rectangle.BOTTOM_BORDER, BorderColor = BorderColor, BackgroundColor = STCNameBackColor, HorizontalAlignment = Element.ALIGN_LEFT, FixedHeight = 40, VerticalAlignment = Element.ALIGN_MIDDLE, PaddingBottom = 5 });

                                var PatternPhrase = new Phrase();

                                var PatternTargetDate = "";
                                //if (orderDetail.FitsPatternTargetDateRead)//abhishek
                                //{
                                //    if (orderDetail.STCDateReqTarPattern != DateTime.MinValue)
                                //    {
                                //        PatternTargetDate = orderDetail.STCDateReqTarPattern.ToString("dd MMM yy (ddd)");
                                //    }
                                //}

                                if (orderDetail.PatternSampleTarget != DateTime.MinValue)
                                {
                                    PatternTargetDate = orderDetail.PatternSampleTarget.ToString("dd MMM");
                                }

                                var PatternActualDate = "";
                                if (orderDetail.FitsPatternActualDateRead)
                                {
                                    if (orderDetail.PatternSampleDate != DateTime.MinValue)
                                    {
                                        PatternActualDate = orderDetail.PatternSampleDate.ToString("dd MMM");
                                    }
                                }

                                var PatternReq = PatternTargetDate + "\n ---------------------------" + "\n" + PatternActualDate;

                                var PatternReqFont = FontFactory.GetFont("trebuchet ms", 11, Font.NORMAL, STCtgtForeColor);
                                PatternPhrase.Add(new Chunk(PatternReq, PatternReqFont));

                                ptTechnical.AddCell(new PdfPCell(PatternPhrase) { Border = Rectangle.BOTTOM_BORDER, BorderWidthLeft = 1, BorderColor = BorderColor, HorizontalAlignment = Element.ALIGN_CENTER, FixedHeight = 40, VerticalAlignment = Element.ALIGN_TOP, PaddingBottom = 5 });

                                var PATTERNETAPhrase = new Phrase();
                                string PATTERNETA = "";
                                if (orderDetail.FitsPatternETARead)
                                {
                                    if (orderDetail.PatternSampleDateETA != DateTime.MinValue)
                                    {
                                        PATTERNETA = orderDetail.PatternSampleDateETA.ToString("dd MMM");
                                    }
                                }
                                Color PATTERNETAForeColor = new Color(System.Drawing.ColorTranslator.FromHtml(orderDetail.FitsPatternETAForColor));
                                Color PATTERNETABackColor = new Color(System.Drawing.ColorTranslator.FromHtml(orderDetail.FitsPatternETABackColor));

                                var PATTERNETAFont = FontFactory.GetFont("trebuchet ms", 11, Font.NORMAL, PATTERNETAForeColor);
                                PATTERNETAPhrase.Add(new Chunk(PATTERNETA, PATTERNETAFont));

                                ptTechnical.AddCell(new PdfPCell(PATTERNETAPhrase) { BackgroundColor = PATTERNETABackColor, Border = Rectangle.BOTTOM_BORDER, BorderWidthLeft = 1, BorderColor = BorderColor, HorizontalAlignment = Element.ALIGN_CENTER, FixedHeight = 40, VerticalAlignment = Element.ALIGN_MIDDLE, PaddingBottom = 5 });
                            }
                            // End Pattern Sample

                            // Cutting Sample Section

                            if (orderDetail.ParentOrder.Fits.SealDate != DateTime.MinValue)
                            {
                                var CuttingSheetPhrase = new Phrase();

                                CuttingSheetPhrase.Add(Chunk.NEWLINE);
                                var CuttingSheet = "";
                                if (orderDetail.FitsCuttingkRead)
                                {
                                    CuttingSheet = "Cutting Sheet";
                                }
                                if (orderDetail.IsShiped == true)
                                {
                                    STCNameBackColor = new Color(System.Drawing.ColorTranslator.FromHtml("#F9F9FA"));
                                    STCNameForeColor = new Color(System.Drawing.ColorTranslator.FromHtml("#807F80"));
                                }
                                else
                                {

                                    if (orderDetail.CuttingTarget.Date >= DateTime.Now.Date)
                                    {

                                        if (orderDetail.CuttingReceivedDate == DateTime.MinValue)
                                        {
                                            STCNameBackColor = new Color(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                                            STCNameForeColor = new Color(System.Drawing.ColorTranslator.FromHtml("#000000"));
                                        }
                                    }
                                    else
                                    {
                                        if (orderDetail.CuttingReceivedDate == DateTime.MinValue)
                                        {
                                            STCNameBackColor = new Color(System.Drawing.ColorTranslator.FromHtml("#FFFF66"));
                                            STCNameForeColor = new Color(System.Drawing.ColorTranslator.FromHtml("#FF3300"));
                                        }
                                    }
                                }

                                if (orderDetail.CuttingReceivedDateETA != DateTime.MinValue && orderDetail.CuttingReceivedDate != DateTime.MinValue)
                                {
                                    STCNameBackColor = new Color(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                                    STCNameForeColor = Color.GRAY;
                                }

                                if (orderDetail.FitsCuttingkRead != true)
                                {
                                    STCNameBackColor = new Color(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                                    STCNameForeColor = Color.GRAY;
                                }

                                var CuttingSheetFont = FontFactory.GetFont("trebuchet ms", 11, Font.NORMAL, STCNameForeColor);
                                CuttingSheetPhrase.Add(new Chunk(CuttingSheet, CuttingSheetFont));

                                //Color PatternSampleForeColor = new Color(System.Drawing.ColorTranslator.FromHtml("#696969"));

                                ptTechnical.AddCell(new PdfPCell(CuttingSheetPhrase) { Border = Rectangle.BOTTOM_BORDER, BorderColor = BorderColor, BackgroundColor = STCNameBackColor, HorizontalAlignment = Element.ALIGN_LEFT, FixedHeight = 40, VerticalAlignment = Element.ALIGN_MIDDLE, PaddingBottom = 5 });

                                var CuttingPhrase = new Phrase();

                                var CuttingTargetDate = "";
                                //if (orderDetail.FitsCuttingTargetDateRead)//abhishek
                                //{
                                //    if (orderDetail.STCDateReqTarCutting != DateTime.MinValue)
                                //    {
                                //        CuttingTargetDate = orderDetail.STCDateReqTarCutting.ToString("dd MMM yy (ddd)");
                                //    }
                                //}

                                if (orderDetail.FitsCuttingTargetDateRead)
                                {
                                    if (orderDetail.CuttingTarget != DateTime.MinValue)
                                    {
                                        CuttingTargetDate = orderDetail.CuttingTarget.ToString("dd MMM");
                                    }
                                }

                                var CuttingActualDate = "";
                                if (orderDetail.FitsCuttingActualDateRead)
                                {
                                    if (orderDetail.CuttingReceivedDate != DateTime.MinValue)
                                    {
                                        CuttingActualDate = orderDetail.CuttingReceivedDate.ToString("dd MMM");
                                    }
                                }
                                var CuttingReq = CuttingTargetDate + "\n ---------------------------" + "\n" + CuttingActualDate;

                                var CuttingReqFont = FontFactory.GetFont("trebuchet ms", 11, Font.NORMAL, STCtgtForeColor);
                                CuttingPhrase.Add(new Chunk(CuttingReq, CuttingReqFont));

                                ptTechnical.AddCell(new PdfPCell(CuttingPhrase) { Border = Rectangle.BOTTOM_BORDER, BorderWidthLeft = 1, BorderColor = BorderColor, HorizontalAlignment = Element.ALIGN_CENTER, FixedHeight = 40, VerticalAlignment = Element.ALIGN_TOP, PaddingBottom = 5 });

                                var CuttingReceivedPhrase = new Phrase();
                                string CuttingReceived = "";
                                if (orderDetail.FitsCuttingETARead)
                                {
                                    if (orderDetail.CuttingReceivedDateETA != DateTime.MinValue)
                                    {
                                        CuttingReceived = orderDetail.CuttingReceivedDateETA.ToString("dd MMM");
                                    }
                                }

                                Color CuttingETAForeColor = new Color(System.Drawing.ColorTranslator.FromHtml(orderDetail.FitsCuttingETAForColor));
                                Color CuttingETABackColor = new Color(System.Drawing.ColorTranslator.FromHtml(orderDetail.FitsCuttingETABackColor));

                                var CuttingReceivedFont = FontFactory.GetFont("trebuchet ms", 11, Font.NORMAL, CuttingETAForeColor);
                                CuttingReceivedPhrase.Add(new Chunk(CuttingReceived, CuttingReceivedFont));

                                ptTechnical.AddCell(new PdfPCell(CuttingReceivedPhrase) { BackgroundColor = CuttingETABackColor, Border = Rectangle.BOTTOM_BORDER, BorderWidthLeft = 1, BorderColor = BorderColor, HorizontalAlignment = Element.ALIGN_CENTER, FixedHeight = 40, VerticalAlignment = Element.ALIGN_MIDDLE, PaddingBottom = 5 });
                            }
                            // End Cutting Sample

                            if (orderDetail.ParentOrder.Fits.SealDate != DateTime.MinValue)
                            {
                                // Production Section


                                var ProdFilePhrase = new Phrase();

                                ProdFilePhrase.Add(Chunk.NEWLINE);
                                var ProdFileSheet = "";
                                if (orderDetail.FitsProdFileRead)
                                {
                                    ProdFileSheet = "Prod File";
                                }

                                if (orderDetail.IsShiped == true)
                                {
                                    STCNameBackColor = new Color(System.Drawing.ColorTranslator.FromHtml("#F9F9FA"));
                                    STCNameForeColor = new Color(System.Drawing.ColorTranslator.FromHtml("#807F80"));
                                }
                                else
                                {

                                    if (orderDetail.ProductionFileTarget.Date >= DateTime.Now.Date)
                                    {

                                        if (orderDetail.ProductionFileDate == DateTime.MinValue)
                                        {
                                            STCNameBackColor = new Color(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                                            STCNameForeColor = new Color(System.Drawing.ColorTranslator.FromHtml("#000000"));
                                        }
                                    }
                                    else
                                    {
                                        if (orderDetail.ProductionFileDate == DateTime.MinValue)
                                        {
                                            STCNameBackColor = new Color(System.Drawing.ColorTranslator.FromHtml("#FFFF66"));
                                            STCNameForeColor = new Color(System.Drawing.ColorTranslator.FromHtml("#FF3300"));
                                        }
                                    }
                                }

                                if (orderDetail.ProductionFileDateETA != DateTime.MinValue && orderDetail.ProductionFileDate != DateTime.MinValue)
                                {
                                    STCNameBackColor = new Color(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                                    STCNameForeColor = Color.GRAY;
                                }

                                if (orderDetail.FitsProdFileRead != true)
                                {
                                    STCNameBackColor = new Color(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                                    STCNameForeColor = Color.GRAY;
                                }

                                var ProdFiletFont = FontFactory.GetFont("trebuchet ms", 11, Font.NORMAL, STCNameForeColor);
                                ProdFilePhrase.Add(new Chunk(ProdFileSheet, ProdFiletFont));

                                //Color PatternSampleForeColor = new Color(System.Drawing.ColorTranslator.FromHtml("#696969"));

                                ptTechnical.AddCell(new PdfPCell(ProdFilePhrase) { Border = Rectangle.BOTTOM_BORDER, BorderColor = BorderColor, BackgroundColor = STCNameBackColor, HorizontalAlignment = Element.ALIGN_LEFT, FixedHeight = 40, VerticalAlignment = Element.ALIGN_MIDDLE, PaddingBottom = 5 });

                                var ProdPhrase = new Phrase();

                                var ProdTargetDate = "";
                                //if (orderDetail.FitsProdTargetDateRead)abhishek
                                //{
                                //    if (orderDetail.STCDateReqTarCutting != DateTime.MinValue)
                                //    {
                                //        ProdTargetDate = orderDetail.STCDateReqTarCutting.ToString("dd MMM yy (ddd)");
                                //    }
                                //}
                                if (orderDetail.FitsProdTargetDateRead)
                                {
                                    if (orderDetail.ProductionFileTarget != DateTime.MinValue)
                                    {
                                        ProdTargetDate = orderDetail.ProductionFileTarget.ToString("dd MMM");
                                    }
                                }

                                var ProdActualDate = "";
                                if (orderDetail.FitsProdActualDateRead)
                                {
                                    if (orderDetail.ProductionFileDate != DateTime.MinValue)
                                    {
                                        ProdActualDate = orderDetail.ProductionFileDate.ToString("dd MMM");
                                    }
                                }
                                var ProdReq = ProdTargetDate + "\n ---------------------------" + "\n" + ProdActualDate;

                                var ProdReqFont = FontFactory.GetFont("trebuchet ms", 11, Font.NORMAL, STCtgtForeColor);
                                ProdPhrase.Add(new Chunk(ProdReq, ProdReqFont));

                                ptTechnical.AddCell(new PdfPCell(ProdPhrase) { Border = Rectangle.BOTTOM_BORDER, BorderWidthLeft = 1, BorderColor = BorderColor, HorizontalAlignment = Element.ALIGN_CENTER, FixedHeight = 40, VerticalAlignment = Element.ALIGN_TOP, PaddingBottom = 5 });

                                var ProductionETAPhrase = new Phrase();
                                string ProductionETA = "";
                                if (orderDetail.FitsProdFileETARead)
                                {
                                    if (orderDetail.ProductionFileDateETA != DateTime.MinValue)
                                    {
                                        ProductionETA = orderDetail.ProductionFileDateETA.ToString("dd MMM");
                                    }
                                }

                                Color ProductionETAForeColor = new Color(System.Drawing.ColorTranslator.FromHtml(orderDetail.FitsProdETAForColor));
                                Color ProductionETABackColor = new Color(System.Drawing.ColorTranslator.FromHtml(orderDetail.FitsProdETABackColor));

                                var ProductionETAFont = FontFactory.GetFont("trebuchet ms", 11, Font.NORMAL, ProductionETAForeColor);
                                ProductionETAPhrase.Add(new Chunk(ProductionETA, ProductionETAFont));

                                ptTechnical.AddCell(new PdfPCell(ProductionETAPhrase) { BackgroundColor = ProductionETABackColor, Border = Rectangle.BOTTOM_BORDER, BorderWidthLeft = 1, BorderColor = BorderColor, HorizontalAlignment = Element.ALIGN_CENTER, FixedHeight = 40, VerticalAlignment = Element.ALIGN_MIDDLE, PaddingBottom = 5 });

                                // End Production Section

                            }
                            // HOPPM Section

                            if (orderDetail.ParentOrder.Fits.SealDate != DateTime.MinValue)
                            {
                                var HOPPMPhrase = new Phrase();

                                HOPPMPhrase.Add(Chunk.NEWLINE);

                                var HOPPM = "";
                                if (orderDetail.FitsHOPPMRead)
                                {
                                    HOPPM = "HO PPM";
                                }

                                if (orderDetail.IsShiped == true)
                                {
                                    STCNameBackColor = new Color(System.Drawing.ColorTranslator.FromHtml("#F9F9FA"));
                                    STCNameForeColor = new Color(System.Drawing.ColorTranslator.FromHtml("#807F80"));
                                }
                                else
                                {

                                    if (orderDetail.HOPPMTargetETA.Date >= DateTime.Now.Date)
                                    {

                                        if (orderDetail.HOPPMActionactualDate == DateTime.MinValue)
                                        {
                                            STCNameBackColor = new Color(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                                            STCNameForeColor = new Color(System.Drawing.ColorTranslator.FromHtml("#000000"));
                                        }
                                    }
                                    else
                                    {
                                        if (orderDetail.HOPPMActionactualDate == DateTime.MinValue)
                                        {
                                            STCNameBackColor = new Color(System.Drawing.ColorTranslator.FromHtml("#FFFF66"));
                                            STCNameForeColor = new Color(System.Drawing.ColorTranslator.FromHtml("#FF3300"));
                                        }
                                    }
                                }

                                if (orderDetail.HOPPMETA != DateTime.MinValue && orderDetail.HOPPMActionactualDate != DateTime.MinValue)
                                {
                                    STCNameBackColor = new Color(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                                    STCNameForeColor = Color.GRAY;
                                }

                                if (orderDetail.FitsHOPPMRead != true)
                                {
                                    STCNameBackColor = new Color(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                                    STCNameForeColor = Color.GRAY;
                                }

                                var HOPPMtFont = FontFactory.GetFont("trebuchet ms", 11, Font.NORMAL, STCNameForeColor);
                                HOPPMPhrase.Add(new Chunk(HOPPM, HOPPMtFont));


                                ptTechnical.AddCell(new PdfPCell(HOPPMPhrase) { Border = Rectangle.BOTTOM_BORDER, BorderColor = BorderColor, BackgroundColor = STCNameBackColor, HorizontalAlignment = Element.ALIGN_LEFT, FixedHeight = 40, VerticalAlignment = Element.ALIGN_MIDDLE, PaddingBottom = 5 });

                                var HOPPMTargetPhrase = new Phrase();

                                var HOPPMTargetDate = "";
                                //if (orderDetail.FitsHOPPMTargetDateRead)
                                //{
                                //    if (orderDetail.HOPPMTarget != DateTime.MinValue)
                                //    {
                                //        HOPPMTargetDate = orderDetail.HOPPMTarget.ToString("dd MMM yy (ddd)");
                                //    }
                                //}
                                if (orderDetail.FitsHOPPMTargetDateRead)
                                {
                                    if (orderDetail.HOPPMTargetETA != DateTime.MinValue)
                                    {
                                        HOPPMTargetDate = orderDetail.HOPPMTargetETA.ToString("dd MMM");
                                    }
                                }
                                var HOPPMActualDate = "";
                                if (orderDetail.FitsHOPPMActualDateRead)
                                {
                                    if (orderDetail.HOPPMActionactualDate != DateTime.MinValue)
                                    {
                                        HOPPMActualDate = orderDetail.HOPPMActionactualDate.ToString("dd MMM");
                                    }
                                }
                                var HOPPMTarget = HOPPMTargetDate + "\n ---------------------------" + "\n" + HOPPMActualDate;

                                var HOPPMTargetFont = FontFactory.GetFont("trebuchet ms", 11, Font.NORMAL, STCtgtForeColor);
                                HOPPMTargetPhrase.Add(new Chunk(HOPPMTarget, HOPPMTargetFont));

                                ptTechnical.AddCell(new PdfPCell(HOPPMTargetPhrase) { Border = Rectangle.BOTTOM_BORDER, BorderWidthLeft = 1, BorderColor = BorderColor, HorizontalAlignment = Element.ALIGN_CENTER, FixedHeight = 40, VerticalAlignment = Element.ALIGN_TOP, PaddingBottom = 5 });

                                var HOPPMETAPhrase = new Phrase();
                                string HOPPMETA = "";
                                if (orderDetail.FitsHOPPMETARead)
                                {
                                    if (orderDetail.HOPPMActionactualDate != DateTime.MinValue)
                                    {
                                        HOPPMETA = orderDetail.HOPPMActionactualDate.ToString("dd MMM");
                                    }
                                    else
                                    {
                                        if (orderDetail.HOPPMETA != DateTime.MinValue)
                                        {
                                            HOPPMETA = orderDetail.HOPPMETA.ToString("dd MMM");
                                        }
                                    }
                                }

                                Color HOPPMETAForeColor = new Color(System.Drawing.ColorTranslator.FromHtml(orderDetail.FitsHOPPMETAForColor));
                                Color HOPPMETABackColor = new Color(System.Drawing.ColorTranslator.FromHtml(orderDetail.FitsHOPPMETABackColor));

                                var HOPPMETAFont = FontFactory.GetFont("trebuchet ms", 11, Font.NORMAL, HOPPMETAForeColor);
                                HOPPMETAPhrase.Add(new Chunk(HOPPMETA, HOPPMETAFont));

                                ptTechnical.AddCell(new PdfPCell(HOPPMETAPhrase) { BackgroundColor = HOPPMETABackColor, Border = Rectangle.BOTTOM_BORDER, BorderWidthLeft = 1, BorderColor = BorderColor, HorizontalAlignment = Element.ALIGN_CENTER, FixedHeight = 40, VerticalAlignment = Element.ALIGN_MIDDLE, PaddingBottom = 5 });
                            }
                            // End HOPPM Section

                            // Top Sent Section

                            if (orderDetail.ParentOrder.Fits.SealDate != DateTime.MinValue)
                            {
                                var TopSentPhrase = new Phrase();

                                TopSentPhrase.Add(Chunk.NEWLINE);
                                var TopSent = "";
                                if (orderDetail.FitsTOPSentRead)
                                {
                                    TopSent = "TOP Sent";
                                }
                                STCNameBackColor = new Color(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                                STCNameForeColor = Color.GRAY;

                                if (orderDetail.IsShiped == true)
                                {
                                    STCNameBackColor = new Color(System.Drawing.ColorTranslator.FromHtml("#F9F9FA"));
                                    STCNameForeColor = new Color(System.Drawing.ColorTranslator.FromHtml("#807F80"));
                                }
                                else
                                {

                                    if (orderDetail.TOPTargetETA.Date >= DateTime.Now.Date)
                                    {

                                        if (orderDetail.ParentOrder.InlinePPMOrderContract.TopSentActual == DateTime.MinValue)
                                        {
                                            STCNameBackColor = new Color(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                                            STCNameForeColor = new Color(System.Drawing.ColorTranslator.FromHtml("#000000"));
                                        }
                                    }
                                    else
                                    {
                                        if (orderDetail.ParentOrder.InlinePPMOrderContract.TopSentActual == DateTime.MinValue)
                                        {
                                            STCNameBackColor = new Color(System.Drawing.ColorTranslator.FromHtml("#FFFF66"));
                                            STCNameForeColor = new Color(System.Drawing.ColorTranslator.FromHtml("#FF3300"));
                                        }
                                    }
                                }

                                if (orderDetail.TOPETA != DateTime.MinValue && orderDetail.ParentOrder.InlinePPMOrderContract.TopSentActual != DateTime.MinValue)
                                {
                                    STCNameBackColor = new Color(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                                    STCNameForeColor = Color.GRAY;
                                }

                                if (orderDetail.FitsTOPSentRead != true)
                                {
                                    STCNameBackColor = new Color(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                                    STCNameForeColor = Color.GRAY;
                                }

                                var TopSentFont = FontFactory.GetFont("trebuchet ms", 11, Font.NORMAL, STCNameForeColor);
                                TopSentPhrase.Add(new Chunk(TopSent, TopSentFont));


                                ptTechnical.AddCell(new PdfPCell(TopSentPhrase) { Border = Rectangle.BOTTOM_BORDER, BorderColor = BorderColor, BackgroundColor = STCNameBackColor, HorizontalAlignment = Element.ALIGN_LEFT, FixedHeight = 40, VerticalAlignment = Element.ALIGN_MIDDLE, PaddingBottom = 5 });

                                var TopSendTargetPhrase = new Phrase();

                                var FitsTopSentTarget = "";
                                if (orderDetail.FitsTopSentTargetDateRead)
                                {
                                    if (orderDetail.TOPTargetETA != DateTime.MinValue)
                                    {
                                        FitsTopSentTarget = orderDetail.TOPTargetETA.ToString("dd MMM");
                                    }
                                }

                                var FitsTopSentActual = "";
                                if (orderDetail.FitsTopSentMActualDateRead)
                                {
                                    if (orderDetail.ParentOrder.InlinePPMOrderContract.TopSentActual != DateTime.MinValue)
                                    {
                                        FitsTopSentActual = orderDetail.ParentOrder.InlinePPMOrderContract.TopSentActual.ToString("dd MMM");
                                    }
                                }

                                var TopSendTarget = FitsTopSentTarget + "\n ---------------------------" + "\n" + FitsTopSentActual;

                                var TopSendTargetFont = FontFactory.GetFont("trebuchet ms", 11, Font.NORMAL, STCtgtForeColor);
                                TopSendTargetPhrase.Add(new Chunk(TopSendTarget, TopSendTargetFont));

                                ptTechnical.AddCell(new PdfPCell(TopSendTargetPhrase) { Border = Rectangle.BOTTOM_BORDER, BorderWidthLeft = 1, BorderColor = BorderColor, HorizontalAlignment = Element.ALIGN_CENTER, FixedHeight = 40, VerticalAlignment = Element.ALIGN_TOP, PaddingBottom = 5 });

                                var TOPETAPhrase = new Phrase();
                                string TOPETA = "";
                                if (orderDetail.FitsTOPSentETARead)
                                {
                                    if (orderDetail.ParentOrder.InlinePPMOrderContract.TopSentActual != DateTime.MinValue)
                                    {
                                        TOPETA = orderDetail.ParentOrder.InlinePPMOrderContract.TopSentActual.ToString("dd MMM");
                                    }
                                    if (orderDetail.TOPETA != DateTime.MinValue)
                                    {
                                        TOPETA = orderDetail.TOPETA.ToString("dd MMM");
                                    }
                                }
                                Color TOPETAForeColor = new Color(System.Drawing.ColorTranslator.FromHtml(orderDetail.FitsTOPSentETAForColor));
                                Color TOPETABackColor = new Color(System.Drawing.ColorTranslator.FromHtml(orderDetail.FitsTOPSentETABackColor));

                                var TOPETAFont = FontFactory.GetFont("trebuchet ms", 11, Font.NORMAL, TOPETAForeColor);
                                TOPETAPhrase.Add(new Chunk(TOPETA, TOPETAFont));

                                ptTechnical.AddCell(new PdfPCell(TOPETAPhrase) { BackgroundColor = TOPETABackColor, Border = Rectangle.BOTTOM_BORDER, BorderWidthLeft = 1, BorderColor = BorderColor, HorizontalAlignment = Element.ALIGN_CENTER, FixedHeight = 40, VerticalAlignment = Element.ALIGN_MIDDLE, PaddingBottom = 5 });
                            }
                            // End Top Sent Section
                            //added by abhishek on 2/2/2016

                            // Test Report Section==========================================================//
                            //if (orderDetail.IsTestReportvisible == "" || orderDetail.IsTestReportvisible == string.Empty)
                            //{


                            if (orderDetail.ParentOrder.Fits.SealDate != DateTime.MinValue)
                            {
                                var TestReportSection = new Phrase();

                                TestReportSection.Add(Chunk.NEWLINE);

                                var TestReport = "";
                                if (orderDetail.IsTestReportDone == 2)
                                {
                                    TestReport = "Test Report";
                                }
                                if (orderDetail.IsTestReportDone == 0)
                                {
                                    TestReport = "Test Report Fail";
                                }
                                if (orderDetail.IsTestReportDone == 1)
                                {
                                    TestReport = "Test Report Pass";
                                }
                                if (orderDetail.IsTestReportDone == 3)
                                {
                                    TestReport = "Waive off Pass";
                                }
                                //TestReport = orderDetail.IsTestReportDone == false ? "Test Report Fail" : "Test Report Done";


                                if (orderDetail.TestReportsDateETA != DateTime.MinValue)
                                {
                                    STCNameForeColor = new Color(System.Drawing.ColorTranslator.FromHtml("#807F80"));
                                }

                                if (orderDetail.IsShiped == true)
                                {
                                    STCNameBackColor = new Color(System.Drawing.ColorTranslator.FromHtml("#F9F9FA"));
                                    STCNameForeColor = new Color(System.Drawing.ColorTranslator.FromHtml("#807F80"));
                                }
                                else
                                {

                                    if (orderDetail.TestReportTargetETA.Date >= DateTime.Now.Date)
                                    {

                                        if (orderDetail.TestReportsDateActual == DateTime.MinValue)
                                        {
                                            STCNameBackColor = new Color(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                                            STCNameForeColor = new Color(System.Drawing.ColorTranslator.FromHtml("#000000"));
                                        }
                                    }
                                    else
                                    {
                                        if (orderDetail.TestReportsDateActual == DateTime.MinValue)
                                        {
                                            STCNameBackColor = new Color(System.Drawing.ColorTranslator.FromHtml("#FFFF66"));
                                            STCNameForeColor = new Color(System.Drawing.ColorTranslator.FromHtml("#FF3300"));
                                        }
                                    }
                                }

                                if (orderDetail.TestReportsDateETA != DateTime.MinValue && orderDetail.TestReportsDateActual != DateTime.MinValue)
                                {
                                    STCNameBackColor = new Color(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                                    STCNameForeColor = Color.GRAY;
                                }

                                if (orderDetail.FitsHOPPMRead != true)
                                {
                                    STCNameBackColor = new Color(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                                    STCNameForeColor = Color.GRAY;
                                }

                                var TestReportFont = FontFactory.GetFont("trebuchet ms", 11, Font.NORMAL, STCNameForeColor);
                                TestReportSection.Add(new Chunk(TestReport, TestReportFont));


                                ptTechnical.AddCell(new PdfPCell(TestReportSection) { Border = Rectangle.BOTTOM_BORDER, BorderColor = BorderColor, BackgroundColor = STCNameBackColor, HorizontalAlignment = Element.ALIGN_LEFT, FixedHeight = 40, VerticalAlignment = Element.ALIGN_MIDDLE, PaddingBottom = 5 });

                                var TestReportTargetPhrase = new Phrase();

                                var TestReportTargetDate = "";
                                if (orderDetail.FitsHOPPMTargetDateRead)
                                {
                                    if (orderDetail.TestReportTargetETA != DateTime.MinValue)
                                    {
                                        TestReportTargetDate = orderDetail.TestReportTargetETA.ToString("dd MMM");
                                    }
                                }

                                var TestReportActualDate = "";
                                if (orderDetail.FitsHOPPMActualDateRead)
                                {
                                    if (orderDetail.TestReportsDateActual != DateTime.MinValue)
                                    {
                                        TestReportActualDate = orderDetail.TestReportsDateActual.ToString("dd MMM");
                                    }
                                }
                                var TestReportTarget = TestReportTargetDate + "\n ---------------------------" + "\n" + TestReportActualDate;

                                var TestReportTargetFont = FontFactory.GetFont("trebuchet ms", 11, Font.NORMAL, STCtgtForeColor);
                                TestReportTargetPhrase.Add(new Chunk(TestReportTarget, TestReportTargetFont));

                                ptTechnical.AddCell(new PdfPCell(TestReportTargetPhrase) { Border = Rectangle.BOTTOM_BORDER, BorderWidthLeft = 1, BorderColor = BorderColor, HorizontalAlignment = Element.ALIGN_CENTER, FixedHeight = 40, VerticalAlignment = Element.ALIGN_TOP, PaddingBottom = 5 });

                                var TestReportETAPhrase = new Phrase();
                                string TestReportETA = "";
                                if (orderDetail.FitsHOPPMETARead)
                                {
                                    if (orderDetail.TestReportsDateActual != DateTime.MinValue)
                                    {
                                        TestReportETA = orderDetail.TestReportsDateActual.ToString("dd MMM");
                                    }
                                    else
                                    {
                                        if (orderDetail.TestReportsDateETA != DateTime.MinValue)
                                        {
                                            TestReportETA = orderDetail.TestReportsDateETA.ToString("dd MMM");
                                        }
                                    }
                                }

                                //Color TestReportETAForeColor = new Color(System.Drawing.ColorTranslator.FromHtml(STCtgtForeColor));
                                //Color TestReportETABackColor = new Color(System.Drawing.ColorTranslator.FromHtml(orderDetail.FitsHOPPMETABackColor));

                                var TestReportETAFont = FontFactory.GetFont("trebuchet ms", 11, Font.NORMAL, STCtgtForeColor);
                                TestReportETAPhrase.Add(new Chunk(TestReportETA, TestReportETAFont));

                                ptTechnical.AddCell(new PdfPCell(TestReportETAPhrase) { BackgroundColor = STCNameBackColor, Border = Rectangle.BOTTOM_BORDER, BorderWidthLeft = 1, BorderColor = BorderColor, HorizontalAlignment = Element.ALIGN_CENTER, FixedHeight = 40, VerticalAlignment = Element.ALIGN_MIDDLE, PaddingBottom = 5 });
                                //}
                            }


                            // End TestReport Section
                            // cd chart Section==============================================================//
                            if (orderDetail.IsCdchartVisible == "" || orderDetail.IsCdchartVisible == string.Empty)
                            {
                                var CDchartPhrase = new Phrase();
                                STCNameBackColor = null;
                                STCNameForeColor = null;
                                CDchartPhrase.Add(Chunk.NEWLINE);

                                var CDchart = "";
                                if (orderDetail.FitsHOPPMRead)
                                {
                                    CDchart = "CD Chart";
                                }

                                if (orderDetail.IsShiped == true)
                                {
                                    STCNameBackColor = new Color(System.Drawing.ColorTranslator.FromHtml("#F9F9FA"));
                                    STCNameForeColor = new Color(System.Drawing.ColorTranslator.FromHtml("#807F80"));
                                }
                                else
                                {

                                    if (orderDetail.CdchartTargetDateETA.Date >= DateTime.Now.Date)
                                    {

                                        if (orderDetail.CdchartActualDateETA == DateTime.MinValue)
                                        {
                                            STCNameBackColor = new Color(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                                            STCNameForeColor = new Color(System.Drawing.ColorTranslator.FromHtml("#000000"));
                                        }
                                    }
                                    else
                                    {
                                        if (orderDetail.CdchartActualDateETA == DateTime.MinValue)
                                        {
                                            STCNameBackColor = new Color(System.Drawing.ColorTranslator.FromHtml("#FFFF66"));
                                            STCNameForeColor = new Color(System.Drawing.ColorTranslator.FromHtml("#FF3300"));
                                        }
                                    }
                                }

                                if (orderDetail.CdchartDateETA != DateTime.MinValue && orderDetail.CdchartActualDateETA != DateTime.MinValue)
                                {
                                    STCNameBackColor = new Color(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                                    STCNameForeColor = Color.GRAY;
                                }

                                if (orderDetail.FitsHOPPMRead != true)
                                {
                                    STCNameBackColor = new Color(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                                    STCNameForeColor = Color.GRAY;
                                }

                                var CdchartDateFont = FontFactory.GetFont("trebuchet ms", 11, Font.NORMAL, STCNameForeColor);
                                CDchartPhrase.Add(new Chunk(CDchart, CdchartDateFont));


                                ptTechnical.AddCell(new PdfPCell(CDchartPhrase) { Border = Rectangle.BOTTOM_BORDER, BorderColor = BorderColor, BackgroundColor = STCNameBackColor, HorizontalAlignment = Element.ALIGN_LEFT, FixedHeight = 40, VerticalAlignment = Element.ALIGN_MIDDLE, PaddingBottom = 5 });

                                var CdchartTargetPhrase = new Phrase();

                                var CdchartTargetDate = "";
                                if (orderDetail.FitsHOPPMTargetDateRead)
                                {
                                    if (orderDetail.CdchartTargetDateETA != DateTime.MinValue)
                                    {
                                        CdchartTargetDate = orderDetail.CdchartTargetDateETA.ToString("dd MMM yy (ddd)");
                                    }
                                }

                                var CdchartActualDate = "";
                                if (orderDetail.FitsHOPPMActualDateRead)
                                {
                                    if (orderDetail.CdchartActualDateETA != DateTime.MinValue)
                                    {
                                        CdchartActualDate = orderDetail.CdchartActualDateETA.ToString("dd MMM yy (ddd)");
                                    }
                                }
                                var CdchartTargetDateETA = CdchartTargetDate + "\n ---------------------------" + "\n" + CdchartActualDate;

                                var CdchartTargetFont = FontFactory.GetFont("trebuchet ms", 11, Font.NORMAL, STCtgtForeColor);
                                CdchartTargetPhrase.Add(new Chunk(CdchartTargetDateETA, CdchartTargetFont));

                                ptTechnical.AddCell(new PdfPCell(CdchartTargetPhrase) { Border = Rectangle.BOTTOM_BORDER, BorderWidthLeft = 1, BorderColor = BorderColor, HorizontalAlignment = Element.ALIGN_CENTER, FixedHeight = 40, VerticalAlignment = Element.ALIGN_TOP, PaddingBottom = 5 });

                                var CdchartETAPhrase = new Phrase();
                                string CdchartDateETA = "";
                                if (orderDetail.FitsHOPPMETARead)
                                {
                                    if (orderDetail.CdchartActualDateETA != DateTime.MinValue)
                                    {
                                        CdchartDateETA = orderDetail.CdchartActualDateETA.ToString("dd MMM yy (ddd)");
                                    }
                                    else
                                    {
                                        if (orderDetail.CdchartDateETA != DateTime.MinValue)
                                        {
                                            CdchartDateETA = orderDetail.CdchartDateETA.ToString("dd MMM yy (ddd)");
                                        }
                                    }
                                }

                                Color CdchartETAFontETAForeColor = new Color(System.Drawing.ColorTranslator.FromHtml(orderDetail.FitsHOPPMETAForColor));
                                Color CdchartETABackColor = new Color(System.Drawing.ColorTranslator.FromHtml(orderDetail.FitsHOPPMETABackColor));

                                var CdchartETAFont = FontFactory.GetFont("trebuchet ms", 11, Font.NORMAL, STCNameForeColor);
                                CdchartETAPhrase.Add(new Chunk(CdchartDateETA, CdchartETAFont));

                                ptTechnical.AddCell(new PdfPCell(CdchartETAPhrase) { BackgroundColor = STCNameBackColor, Border = Rectangle.BOTTOM_BORDER, BorderWidthLeft = 1, BorderColor = BorderColor, HorizontalAlignment = Element.ALIGN_CENTER, FixedHeight = 40, VerticalAlignment = Element.ALIGN_MIDDLE, PaddingBottom = 5 });

                            }
                            // End cd chart Section
                            //end by abhishek on 2/2/2016

                            PDFCell TechnicalCell = new PDFCell(ptTechnical);
                            TechnicalRow.Add(TechnicalCell);
                            gen.Rows.Add(TechnicalRow);


                            #endregion Technical Section
                            // Technical Section End

                            // Production Section Start===================Created By Gajendra 11-02-2015========================
                            #region Production Section

                            List<PDFCell> ProductionRow = new List<PDFCell>();
                            PdfPTable ptProduction;
                            ptProduction = new PdfPTable(11) { WidthPercentage = 130 };

                            var ProdExFactPhrase = new Phrase();
                            ProdExFactPhrase.Add(Chunk.NEWLINE);
                            var ExFactory = "";
                            if (orderDetail.bExFactoryRead)
                            {
                                ExFactory = "Ex Fac: " + orderDetail.ExFactory.ToString("dd MMM yy (ddd)");
                            }
                            Color ExFactoryForeColor = new Color(System.Drawing.ColorTranslator.FromHtml(orderDetail.ExFactoryForeColor));

                            var ProductionHeaderFont = FontFactory.GetFont("trebuchet ms", 16, Font.BOLD, ExFactoryForeColor);
                            ProdExFactPhrase.Add(new Chunk(ExFactory, ProductionHeaderFont));
                            Color ExFactoryColor = new Color(System.Drawing.ColorTranslator.FromHtml(orderDetail.ExFactoryColor));
                            ptProduction.AddCell(new PdfPCell(ProdExFactPhrase) { Colspan = 6, BorderColor = BorderColor, BackgroundColor = ExFactoryColor, Border = Rectangle.NO_BORDER, BorderWidthBottom = 1, HorizontalAlignment = Element.ALIGN_LEFT, FixedHeight = 40, VerticalAlignment = Element.ALIGN_MIDDLE, PaddingBottom = 5 });



                            //string DC = "DC: ";
                            //string DCdate = (Convert.ToDateTime(orderDetail.DC) == Convert.ToDateTime("1/1/1900")) ? "" : (Convert.ToDateTime(orderDetail.DC)).ToString("dd MMM yy (ddd)");
                            //var DCdatail = "";
                            //if (orderDetail.bDCDateRead)
                            //  DCdatail = DC + DCdate;


                            var ProdModePhrase = new Phrase();//abhishek on 11/8/216
                            string ModeName = "";
                            if (orderDetail.bModeRead == true)
                            {
                              if (orderDetail.ContractStatus)
                                ModeName = "OnHold  "+orderDetail.ModeName;
                              else
                                ModeName =  orderDetail.ModeName;

                            }
                            var ModeNameFont = FontFactory.GetFont("trebuchet ms", 10, Font.NORMAL, ExFactoryForeColor);
                            ProdModePhrase.Add(new Chunk(ModeName, ModeNameFont));
                            ptProduction.AddCell(new PdfPCell(ProdModePhrase) { Colspan = 5, BorderColor = BorderColor, BackgroundColor = ExFactoryColor, Border = Rectangle.NO_BORDER, BorderWidthBottom = 1, HorizontalAlignment = Element.ALIGN_RIGHT, FixedHeight = 40, VerticalAlignment = Element.ALIGN_BOTTOM, PaddingBottom = 5 });
                            ProdModePhrase.Add(Chunk.NEWLINE);


                            //-----------------------------------------
                            Color BlackToForeColor = new Color(System.Drawing.ColorTranslator.FromHtml(orderDetail.BlackToForeColor));
                            //var OfferPhrase = new Phrase();
                            //string Offer = "";
                            //if (orderDetail.FitsPlannedDateRead)
                            //{
                            //    Offer = "Offer:";
                            //}
                            //string PlannedEx = "";
                            //if (orderDetail.FitsPlannedDateRead)
                            //{
                            //    if (orderDetail.PlannedEx != DateTime.MinValue)
                            //    {
                            //        PlannedEx = orderDetail.PlannedEx.ToString("dd MMM yy (ddd)");
                            //    }
                            //}
                            //var Offerdatail = Offer + " " + PlannedEx;
                            //var OfferFont = FontFactory.GetFont("trebuchet ms", 11, Font.NORMAL, BlackToForeColor);
                            //OfferPhrase.Add(new Chunk(Offerdatail, OfferFont));
                            //ptProduction.AddCell(new PdfPCell(OfferPhrase) { BorderColor = BorderColor, Colspan = 3, Border = Rectangle.NO_BORDER, BorderWidthBottom = 1, HorizontalAlignment = Element.ALIGN_LEFT, FixedHeight = 40, VerticalAlignment = Element.ALIGN_MIDDLE, PaddingBottom = 5 });


                            Color LinktypeForeColor = new Color(System.Drawing.ColorTranslator.FromHtml(orderDetail.LinktypeForeColor));
                            var StatusModePhrase = new Phrase();
                            string ProdStatusMode = "";
                            if (orderDetail.bStatusRead)
                            {
                                //ProdStatusMode = orderDetail.ParentOrder.WorkflowInstanceDetail.StatusMode;
                                ProdStatusMode = "";
                            }
                            var StatusModeFont = FontFactory.GetFont("trebuchet ms", 12, Font.BOLD, LinktypeForeColor);
                            StatusModePhrase.Add(new Chunk(ProdStatusMode, StatusModeFont));

                            ptProduction.AddCell(new PdfPCell(StatusModePhrase) { Colspan = 7, BorderColor = BorderColor, Border = Rectangle.NO_BORDER, BorderWidthBottom = 1, HorizontalAlignment = Element.ALIGN_RIGHT, FixedHeight = 40, VerticalAlignment = Element.ALIGN_MIDDLE, PaddingBottom = 5 });
                            StatusModePhrase.Add(Chunk.NEWLINE);
                            //------------------------------------------------------------

                            //Unit

                            var QuantityPhrase = new Phrase();
                            string Quantity = "";
                            if (orderDetail.bQuantityRead == true)
                            {
                                Quantity = orderDetail.Quantity.ToString() + " Pcs.";
                                Globals.TotalQty += Convert.ToInt32(orderDetail.Quantity);

                            }
                            var QuantityFont = FontFactory.GetFont("trebuchet ms", 12, Font.BOLD, BlackToForeColor);
                            QuantityPhrase.Add(new Chunk(Quantity, ProductionHeaderFont));
                            ptProduction.AddCell(new PdfPCell(QuantityPhrase) { Colspan = 6, BorderColor = BorderColor, Border = Rectangle.NO_BORDER, BorderWidthBottom = 1, HorizontalAlignment = Element.ALIGN_LEFT, FixedHeight = 40, VerticalAlignment = Element.ALIGN_MIDDLE, PaddingBottom = 5 });

                            //var DCPhrase = new Phrase(); //As per QA DC date will not show in Pdf //abhishek
                            //string DC = "DC: ";
                            //string DCdate = (Convert.ToDateTime(orderDetail.DC) == Convert.ToDateTime("1/1/1900")) ? "" : (Convert.ToDateTime(orderDetail.DC)).ToString("dd MMM yy (ddd)");
                            //var DCdatail = "";
                            //if (orderDetail.bDCDateRead)
                            //    DCdatail = DC + DCdate;
                            //var DCFont = FontFactory.GetFont("trebuchet ms", 11, Font.NORMAL, BlackToForeColor);
                            //DCPhrase.Add(new Chunk(DCdatail, DCFont));
                            //DCdatail = "";//as per tanka dc date hide 
                            //ptProduction.AddCell(new PdfPCell(DCPhrase) { BorderColor = BorderColor, Colspan = 11, Border = Rectangle.NO_BORDER, BorderWidthBottom = 1, HorizontalAlignment = Element.ALIGN_RIGHT, FixedHeight = 40, VerticalAlignment = Element.ALIGN_MIDDLE, PaddingBottom = 5 });
                            //DCPhrase.Add(Chunk.NEWLINE);


                            #region Loop data Start
                            int CuttingShareAll = 0; int StitchingShareAll = 0; int FinishingShareAll = 0; int TotalCutPcsAll = 0; int TotalCutReadyAll = 0; int TotalStitchedAll = 0; int TotalFinishedAll = 0; int TotalValueAddedAll = 0; int TotalCutIssueAll = 0; 
                            int TotalRescanAll = 0; int TotalPendingRescan = 0;
                             
                            /*abhishek set colspan value daynmiclly for hide VA Pdf Cell*/
                            //Added by abhishek on 11/4/2016=========================================//
                          string IsOutHouseExists="";
                          foreach (MOOrderDetails.ProductionDetails ProdDetail in orderDetail.Production)
                          {
                            int UnitIds = ProdDetail.UnitId;
                            if (UnitIds != 3 && UnitIds != 11 && UnitIds != 96 && UnitIds != 120)
                                        {
                                          IsOutHouseExists="1";
                                        }
                          }
                            int ColspanValue = 1;
                            if (orderDetail.Production != null)
                            {
                                if (orderDetail.Production.Count > 0)
                                {
                                    IsReScan = orderDetail.IsReScan;
                                    if (!string.IsNullOrEmpty(orderDetail.IsVaCompleted))//abhishek
                                    {
                                        ColspanValue = 2;
                                        //FactorynameColsapn = 2;
                                    }
                                    if (Convert.ToInt32(IsReScan) == 1)
                                    {
                                      ColspanValue += 1;
                                    }
                                    if (orderDetail.Production.Count > 1)
                                    {
                                        ColspanValue += 2;
                                        if (Convert.ToInt32(IsReScan) == 1)
                                        {
                                          ColspanValue = 2;
                                        }
                                    }
                                    if (orderDetail.Production.Count == 1 || orderDetail.Production.Count == 0)
                                    {
                                      if (Convert.ToInt32(IsReScan) == 0)
                                      {
                                        ColspanValue = 7;
                                      }
                                      else
                                      {
                                        ColspanValue = 6;
                                      }
 
                                    }
                                    if (string.IsNullOrEmpty(orderDetail.IsVaCompleted))
                                    {
                                      ColspanValue = Math.Abs(ColspanValue - 1);
                                    }
                                    ColspanValue = 5;
                                    //--------------------------------------------------------------------------------
                                    if (orderDetail.Production.Count != 0 && orderDetail.Production.Count != 1)
                                    {
                                      if (IsOutHouseExists == "1")
                                      {
                                        //CutAlloc
                                        ColspanValue = Math.Abs(ColspanValue - 1);
                                      }
                                    }
                                    else
                                    {
                                      ColspanValue = ColspanValue + 1;
                                    }
                                    //"CutToday"
                                   // ColspanValue = ColspanValue + 1;
                                    //CutReadys = new Phrase();
                                    //ColspanValue = ColspanValue + 1;
                                    //--------------------------------------------------------------------------------
                                    if (orderDetail.Production.Count != 0 && orderDetail.Production.Count != 1)
                                    {
                                      if (IsOutHouseExists == "1")
                                      {
                                        //Cut Issue
                                        ColspanValue = Math.Abs(ColspanValue - 1);
                                      }
                                    }
                                    //--------------------------------------------------------------------------------
                                    if (orderDetail.Production.Count != 0 && orderDetail.Production.Count != 1)
                                    {
                                      if (IsOutHouseExists == "1")
                                      {
                                        // "Alloc";
                                        ColspanValue = Math.Abs(ColspanValue - 1);
                                      }
                                    }
                                   
                                    // "Stitched";
                                    //ColspanValue = ColspanValue + 1;


                                    if (orderDetail.Production.Count != 0 && orderDetail.Production.Count != 1)
                                    {
                                      if (IsOutHouseExists == "1")
                                      {
                                        // "Alloca";
                                        ColspanValue = Math.Abs(ColspanValue - 1);
                                      }
                                    }

                                    if (string.IsNullOrEmpty(orderDetail.IsVaCompleted))
                                    {
                                      //va
                                      ColspanValue = Math.Abs(ColspanValue - 1);
                                    }
                                    else
                                    {
                                      ColspanValue = ColspanValue + 1;
                                    }
                                    //"Fin/pkd";
                                   // ColspanValue = ColspanValue + 1;
                                    if (Convert.ToInt32(IsReScan) == 1)
                                    {
                                      //"Rscan Comp" + "\n" + "Pendg Rscan";
                                      ColspanValue = (ColspanValue - 1);
                                    }
                                    else
                                    {
                                      ColspanValue = ColspanValue + 1;
                                    }
                                   
                                    if (ColspanValue == 7)
                                    {
                                      ColspanValue = 4;
                                    }
                                    else if (ColspanValue == 1)
                                    {
                                      ColspanValue = 2;
                                    }
                                    else if (ColspanValue == 6 || ColspanValue == 5)
                                    {
                                      ColspanValue = 6;
                                    }
                                    else if (ColspanValue == 8)
                                    {
                                      ColspanValue = 7;
                                    }
                                    
                                   
                                    Color gerycolor = new Color(System.Drawing.ColorTranslator.FromHtml(orderDetail.LinktypeForeColor));
                                    var ProdUnitPhrase1 = new Phrase();
                                    var Unit1 = "";
                                    var UnitFont1 = FontFactory.GetFont("trebuchet ms", 12, Font.NORMAL, Color.GRAY);
                                    ProdUnitPhrase1.Add(new Chunk(Unit1, UnitFont1));
                                    ptProduction.AddCell(new PdfPCell(ProdUnitPhrase1) { Border = Rectangle.BOTTOM_BORDER, Colspan = ColspanValue, BorderWidthTop = Rectangle.TOP_BORDER, BorderWidthLeft = 1, BorderColor = BorderColor, HorizontalAlignment = Element.ALIGN_CENTER, FixedHeight = 40, VerticalAlignment = Element.ALIGN_MIDDLE, PaddingBottom = 5 });

                                    //--------------------------------------------------------------------------------
                                    if (orderDetail.Production.Count != 0 && orderDetail.Production.Count != 1)
                                    {
                                      if(IsOutHouseExists=="1")
                                      {
                                        var ProdCutAllocatePhrase1 = new Phrase();

                                        var Unit2 = "Alloc";
                                        var UnitFont2 = FontFactory.GetFont("trebuchet ms", 9, Font.NORMAL, Color.GRAY);
                                        ProdCutAllocatePhrase1.Add(new Chunk(Unit2, UnitFont2));
                                        ptProduction.AddCell(new PdfPCell(ProdCutAllocatePhrase1) { Border = Rectangle.BOTTOM_BORDER, BorderWidthTop = Rectangle.TOP_BORDER, BorderWidthLeft = 1, BorderColor = BorderColor, HorizontalAlignment = Element.ALIGN_CENTER, FixedHeight = 40, VerticalAlignment = Element.ALIGN_MIDDLE, PaddingBottom = 5 });
                                      }
                                    }
                                    //--------------------------------------------------------------------------------
                                    var CutToday = new Phrase();
                                    var Unit3 = "Cut";
                                    var UnitFont3 = FontFactory.GetFont("trebuchet ms", 9, Font.NORMAL, Color.GRAY);
                                    CutToday.Add(new Chunk(Unit3, UnitFont3));
                                    ptProduction.AddCell(new PdfPCell(CutToday) { Border = Rectangle.BOTTOM_BORDER, BorderWidthTop = Rectangle.TOP_BORDER, BorderWidthLeft = 1, BorderColor = BorderColor, HorizontalAlignment = Element.ALIGN_CENTER, FixedHeight = 40, VerticalAlignment = Element.ALIGN_MIDDLE, PaddingBottom = 5 });

                                    //--------------------------------------------------------------------------------
                                    var CutReadys = new Phrase();
                                    var Unit4 = "Cut Rdy";
                                    var UnitFont4 = FontFactory.GetFont("trebuchet ms", 9, Font.NORMAL, Color.GRAY);
                                    CutReadys.Add(new Chunk(Unit4, UnitFont4));
                                    ptProduction.AddCell(new PdfPCell(CutReadys) { Border = Rectangle.BOTTOM_BORDER, BorderWidthTop = Rectangle.TOP_BORDER, BorderWidthLeft = 1, BorderColor = BorderColor, HorizontalAlignment = Element.ALIGN_CENTER, FixedHeight = 40, VerticalAlignment = Element.ALIGN_MIDDLE, PaddingBottom = 5 });

                                    //--------------------------------------------------------------------------------
                                    if (orderDetail.Production.Count != 0 && orderDetail.Production.Count != 1)
                                    {
                                      if (IsOutHouseExists == "1")
                                      {
                                        var CutIssue = new Phrase();
                                        var Unit10 = "Cut Issue";
                                        UnitFont4 = FontFactory.GetFont("trebuchet ms", 9, Font.NORMAL, Color.GRAY);
                                        CutIssue.Add(new Chunk(Unit10, UnitFont4));
                                        ptProduction.AddCell(new PdfPCell(CutIssue) { Border = Rectangle.BOTTOM_BORDER, BorderWidthTop = Rectangle.TOP_BORDER, BorderWidthLeft = 1, BorderColor = BorderColor, HorizontalAlignment = Element.ALIGN_CENTER, FixedHeight = 40, VerticalAlignment = Element.ALIGN_MIDDLE, PaddingBottom = 5 });
                                      }
                                    }


                                    //--------------------------------------------------------------------------------
                                    if (orderDetail.Production.Count != 0 && orderDetail.Production.Count != 1)
                                    {
                                      if (IsOutHouseExists == "1")
                                      {
                                        var Allocs = new Phrase();
                                        var Unit5 = "Alloc";
                                        var UnitFont5 = FontFactory.GetFont("trebuchet ms", 9, Font.NORMAL, Color.GRAY);
                                        Allocs.Add(new Chunk(Unit5, UnitFont5));
                                        ptProduction.AddCell(new PdfPCell(Allocs) { Border = Rectangle.BOTTOM_BORDER, BorderWidthTop = Rectangle.TOP_BORDER, BorderWidthLeft = 1, BorderColor = BorderColor, HorizontalAlignment = Element.ALIGN_CENTER, FixedHeight = 40, VerticalAlignment = Element.ALIGN_MIDDLE, PaddingBottom = 5 });
                                      }
                                    }

                                    //--------------------------------------------------------------------------------

                                    var Stitched = new Phrase();
                                    var Unit6 = "Stitched";
                                    var UnitFont6 = FontFactory.GetFont("trebuchet ms", 9, Font.NORMAL, Color.GRAY);
                                    Stitched.Add(new Chunk(Unit6, UnitFont6));
                                    ptProduction.AddCell(new PdfPCell(Stitched) { Border = Rectangle.BOTTOM_BORDER, BorderWidthTop = Rectangle.TOP_BORDER, BorderWidthLeft = 1, BorderColor = BorderColor, HorizontalAlignment = Element.ALIGN_CENTER, FixedHeight = 40, VerticalAlignment = Element.ALIGN_MIDDLE, PaddingBottom = 5 });

                                    //--------------------------------------------------------------------------------
                                    if (orderDetail.Production.Count != 0 && orderDetail.Production.Count != 1)
                                    {
                                      if (IsOutHouseExists == "1")
                                      {
                                        var Alloca = new Phrase();
                                        var Unit7 = "Alloca";
                                        var UnitFont7 = FontFactory.GetFont("trebuchet ms", 9, Font.NORMAL, Color.GRAY);
                                        Alloca.Add(new Chunk(Unit7, UnitFont7));
                                        ptProduction.AddCell(new PdfPCell(Alloca) { Border = Rectangle.BOTTOM_BORDER, BorderWidthTop = Rectangle.TOP_BORDER, BorderWidthLeft = 1, BorderColor = BorderColor, HorizontalAlignment = Element.ALIGN_CENTER, FixedHeight = 40, VerticalAlignment = Element.ALIGN_MIDDLE, PaddingBottom = 5 });
                                      }
                                    }
                                    //--------------------------------------------------------------------------------
                                    if (string.IsNullOrEmpty(orderDetail.IsVaCompleted))
                                    {

                                        var VA = new Phrase();//1
                                        var Unit8 = "VA";
                                        var UnitFont8 = FontFactory.GetFont("trebuchet ms", 9, Font.NORMAL, Color.GRAY);
                                        VA.Add(new Chunk(Unit8, UnitFont8));
                                        ptProduction.AddCell(new PdfPCell(VA) { Border = Rectangle.BOTTOM_BORDER, BorderWidthTop = Rectangle.TOP_BORDER, BorderWidthLeft = 1, BorderColor = BorderColor, HorizontalAlignment = Element.ALIGN_CENTER, FixedHeight = 40, VerticalAlignment = Element.ALIGN_MIDDLE, PaddingBottom = 5 });

                                    }
                                    //--------------------------------------------------------------------------------

                                    var Finpkd = new Phrase();
                                    var Unit9 = "Fin/pkd";
                                    var UnitFont9 = FontFactory.GetFont("trebuchet ms", 9, Font.NORMAL, Color.GRAY);
                                    Finpkd.Add(new Chunk(Unit9, UnitFont9));
                                    ptProduction.AddCell(new PdfPCell(Finpkd) { Border = Rectangle.BOTTOM_BORDER, BorderWidthTop = Rectangle.TOP_BORDER, BorderWidthLeft = 1, BorderColor = BorderColor, HorizontalAlignment = Element.ALIGN_CENTER, FixedHeight = 40, VerticalAlignment = Element.ALIGN_MIDDLE, PaddingBottom = 5 });

                                    //--------------------------------------------Rescan------------------------------------//
                                    if (Convert.ToInt32(IsReScan) == 1)
                                    {
                                      var Rescan = new Phrase();
                                      var HeaderCaption = "Rscan Comp" + "\n" + "Pendg Rscan";
                                      //var HeaderCaption = "R";
                                      var RescanFont = FontFactory.GetFont("trebuchet ms", 9, Font.NORMAL, Color.GRAY);
                                      Rescan.Add(new Chunk(HeaderCaption, RescanFont));
                                      ptProduction.AddCell(new PdfPCell(Rescan) { Border = Rectangle.BOTTOM_BORDER, BorderWidthTop = Rectangle.TOP_BORDER, BorderWidthLeft = 1, BorderColor = BorderColor, HorizontalAlignment = Element.ALIGN_CENTER, FixedHeight = 40, VerticalAlignment = Element.ALIGN_MIDDLE, PaddingBottom = 5 });
                                    }

                                    //--------------------------------------------------------------------------------
                                    //end by abhishek=================================================================//


                                    string[] arr1 = new string[] { "\n --------" + "\n" };


                                    //LabelTest.Text = state;
                                    //LabelTest.ForeColor = System.Drawing.Color.Blue; 
                                    string lbllineno = "";
                                    var CutFont = FontFactory.GetFont("trebuchet ms", 11, Font.NORMAL, LinktypeForeColor);
                                    foreach (MOOrderDetails.ProductionDetails ProdDetail in orderDetail.Production)
                                    {
                                        var ProdUnitPhrase = new Phrase();
                                        var Unit = ProdDetail.FactoryName;
                                        int UnitIds = ProdDetail.UnitId;
                                        var UnitFont = FontFactory.GetFont("trebuchet ms", 12, Font.NORMAL, Color.GRAY);
                                        lbllineno = "";
                                        if (UnitIds != 3 && UnitIds != 11 && UnitIds != 96 && UnitIds != 120)
                                        {
                                          if (ProdDetail.LineNoOut.ToString() == "Line")
                                          {
                                            lbllineno = "Plnd";
                                          }
                                          else if ((ProdDetail.LineNoOut).ToString() == "pndg LP")
                                          {
                                            lbllineno = "Pndg LP";
                                          }
                                         
                                        }
                                        else
                                        {
                                          
                                          if (ProdDetail.LineNo.ToString() != "")
                                            lbllineno = ProdDetail.LineNo.ToString();
                                          
                                        }

                                        ProdUnitPhrase.Add(new Chunk(Unit + "\n" + lbllineno, UnitFont));
                                        ptProduction.AddCell(new PdfPCell(ProdUnitPhrase) { Border = Rectangle.BOTTOM_BORDER, Colspan = ColspanValue, BorderWidthTop = Rectangle.TOP_BORDER, BorderWidthLeft = 1, BorderColor = BorderColor, HorizontalAlignment = Element.ALIGN_LEFT, FixedHeight = 40, VerticalAlignment = Element.ALIGN_MIDDLE, PaddingBottom = 5 });
                                        //--------------------------------------------------------------------------------

                                        if (orderDetail.Production.Count != 0 && orderDetail.Production.Count != 1)
                                        {
                                          if (IsOutHouseExists == "1")
                                          {
                                            var ProdCutAllocatePhrase = new Phrase();
                                            var lblCutAllocate = "";
                                            if (ProdDetail.CuttingShare >= 1000)
                                              lblCutAllocate = Math.Round(Convert.ToDouble(ProdDetail.CuttingShare) / 1000, 1) + "k";
                                            else
                                              lblCutAllocate = ProdDetail.CuttingShare == 0 ? "" : String.Format("{0:#,##0}", ProdDetail.CuttingShare);
                                            //double CuttingSharVal = ProdDetail.CuttingShare == 0 ? 0 : Math.Round(Convert.ToDouble(ProdDetail.CuttingShare) / 1000, 1);
                                            //lblCutAllocate = CuttingSharVal == 0 ? "" : CuttingSharVal.ToString() + "k";

                                            var CutAllocateFont = FontFactory.GetFont("trebuchet ms", 12, Font.NORMAL, Color.GRAY);
                                            ProdCutAllocatePhrase.Add(new Chunk(lblCutAllocate, CutAllocateFont));
                                            ptProduction.AddCell(new PdfPCell(ProdCutAllocatePhrase) { Border = Rectangle.BOTTOM_BORDER, BorderWidthTop = Rectangle.TOP_BORDER, BorderWidthLeft = 1, BorderColor = BorderColor, HorizontalAlignment = Element.ALIGN_CENTER, FixedHeight = 40, VerticalAlignment = Element.ALIGN_MIDDLE, PaddingBottom = 5 });
                                          }
                                        }
                                        // --------------------------------------------------------------------------------
                                       
                                          var ProdCutPhrase = new Phrase();
                                          var txtCutToday = "";
                                          txtCutToday = ProdDetail.TodayCut == 0 ? "" : ProdDetail.TodayCut.ToString();

                                          var txtCutQtyTotal = "";
                                          if (ProdDetail.TotalCutPcs >= 1000)
                                            txtCutQtyTotal = Math.Round(Convert.ToDouble(ProdDetail.TotalCutPcs) / 1000, 1) + "k";
                                          else
                                            txtCutQtyTotal = ProdDetail.TotalCutPcs == 0 ? "" : String.Format("{0:#,##0}", ProdDetail.TotalCutPcs);

                                          var Cut = txtCutToday + "\n -----" + "\n" + txtCutQtyTotal;
                                        
                                          ProdCutPhrase.Add(new Chunk(Cut, CutFont));

                                          ptProduction.AddCell(new PdfPCell(ProdCutPhrase) { Border = Rectangle.BOTTOM_BORDER, BorderWidthTop = Rectangle.TOP_BORDER, BorderWidthLeft = 1, BorderColor = BorderColor, HorizontalAlignment = Element.ALIGN_CENTER, FixedHeight = 40, VerticalAlignment = Element.ALIGN_TOP, PaddingBottom = 5 });
                                        
                                        //--------------------------------------------------------------------------------   


                                        var ProdCutReadyPhrase = new Phrase();
                                        var txtCutReadyToday = "";
                                        txtCutReadyToday = ProdDetail.TodayCutReady == 0 ? "" : ProdDetail.TodayCutReady.ToString();

                                        var txtCutReadyTotal = "";
                                        if (ProdDetail.TotalCutReady >= 1000)
                                            txtCutReadyTotal = Math.Round(Convert.ToDouble(ProdDetail.TotalCutReady) / 1000, 1) + "k";
                                        else
                                            txtCutReadyTotal = ProdDetail.TotalCutReady == 0 ? "" : String.Format("{0:#,##0}", ProdDetail.TotalCutReady);

                                        var CutReady = txtCutReadyToday + "\n -----" + "\n" + txtCutReadyTotal;
                                        ProdCutReadyPhrase.Add(new Chunk(CutReady, CutFont));
                                        ptProduction.AddCell(new PdfPCell(ProdCutReadyPhrase) { Border = Rectangle.BOTTOM_BORDER, BorderWidthTop = Rectangle.TOP_BORDER, BorderWidthLeft = 1, BorderColor = BorderColor, HorizontalAlignment = Element.ALIGN_CENTER, FixedHeight = 40, VerticalAlignment = Element.ALIGN_TOP, PaddingBottom = 5 });


                                        //--------------------------------------------------------------------------------   
                                        if (orderDetail.Production.Count != 0 && orderDetail.Production.Count != 1)
                                        {
                                          if (IsOutHouseExists == "1")
                                          {
                                            var ProCutIssuePhrase = new Phrase();
                                            var txtCutIssueToday = "";
                                            if (ProdDetail.CutIssueQty >= 1000)
                                              txtCutIssueToday = Math.Round(Convert.ToDouble(ProdDetail.CutIssueQty) / 1000, 1) + "k";
                                            else
                                              txtCutIssueToday = ProdDetail.CutIssueQty == 0 ? "" : String.Format("{0:#,##0}", ProdDetail.CutIssueQty);

                                            var txtCutIssueTotal = "";
                                            if (Convert.ToDouble(ProdDetail.CutIssueQtyTotal) >= 1000)
                                              txtCutIssueTotal = Math.Round(Convert.ToDouble(ProdDetail.CutIssueQtyTotal) / 1000, 1) + "k";
                                            else
                                              txtCutIssueTotal = ProdDetail.CutIssueQtyTotal == 0 ? "" : String.Format("{0:#,##0}", ProdDetail.CutIssueQtyTotal);


                                            //double TotalCutIssueVal = ProdDetail.TotalCutReady == 0 ? 0 : Math.Round(Convert.ToDouble(ProdDetail.TotalCutReady) / 1000, 1); 

                                            //txtCutIssueTotal = txtCutIssueTotal == "0" ? "" : String.Format("{0:#,##0}", Convert.ToInt32(txtCutIssueTotal));

                                            var CutIssues = txtCutIssueToday + "\n -----" + "\n" + txtCutIssueTotal;
                                            ProCutIssuePhrase.Add(new Chunk(CutIssues, CutFont));
                                            ptProduction.AddCell(new PdfPCell(ProCutIssuePhrase) { Border = Rectangle.BOTTOM_BORDER, BorderWidthTop = Rectangle.TOP_BORDER, BorderWidthLeft = 1, BorderColor = BorderColor, HorizontalAlignment = Element.ALIGN_CENTER, FixedHeight = 40, VerticalAlignment = Element.ALIGN_TOP, PaddingBottom = 5 });
                                          }
                                        }
                                        //--------------------------------------------------------------------------------     

                                        
                                          if (orderDetail.Production.Count != 0 && orderDetail.Production.Count != 1)
                                          {
                                            if (IsOutHouseExists == "1")
                                            {
                                              var ProdStitchingSharePhrase = new Phrase();
                                              var lblStitchingAllocate = "";

                                              if (ProdDetail.StitchingShare >= 1000)
                                                lblStitchingAllocate = Math.Round(Convert.ToDouble(ProdDetail.StitchingShare) / 1000, 1) + "k";
                                              else
                                                lblStitchingAllocate = ProdDetail.StitchingShare == 0 ? "" : String.Format("{0:#,##0}", ProdDetail.StitchingShare);


                                              var CutAllocateFonts = FontFactory.GetFont("trebuchet ms", 12, Font.NORMAL, Color.GRAY);
                                              ProdStitchingSharePhrase.Add(new Chunk(lblStitchingAllocate, CutAllocateFonts));
                                              ptProduction.AddCell(new PdfPCell(ProdStitchingSharePhrase) { Border = Rectangle.BOTTOM_BORDER, BorderWidthTop = Rectangle.TOP_BORDER, BorderWidthLeft = 1, BorderColor = BorderColor, HorizontalAlignment = Element.ALIGN_CENTER, FixedHeight = 40, VerticalAlignment = Element.ALIGN_MIDDLE, PaddingBottom = 5 });
                                            }
                                        }
                                        //--------------------------------------------------------------------------------   

                                        var ProdStitchPhrase = new Phrase();
                                        var txtStitchToday = "";
                                        txtStitchToday = ProdDetail.TodayStitch == 0 ? "" : ProdDetail.TodayStitch.ToString();

                                        var txtStitchTotal = "";

                                        if (ProdDetail.LinePlanning_StitchQty >= 1000)
                                            txtStitchTotal = Math.Round(Convert.ToDouble(ProdDetail.LinePlanning_StitchQty) / 1000, 1) + "k";
                                        else
                                            txtStitchTotal = ProdDetail.LinePlanning_StitchQty == 0 ? "" : String.Format("{0:#,##0}", ProdDetail.LinePlanning_StitchQty);


                                        var Stitch = txtStitchToday + "\n -----" + "\n" + txtStitchTotal;
                                        ProdStitchPhrase.Add(new Chunk(Stitch, CutFont));
                                        ptProduction.AddCell(new PdfPCell(ProdStitchPhrase) { Border = Rectangle.BOTTOM_BORDER, BorderWidthTop = Rectangle.TOP_BORDER, BorderWidthLeft = 1, BorderColor = BorderColor, HorizontalAlignment = Element.ALIGN_CENTER, FixedHeight = 40, VerticalAlignment = Element.ALIGN_TOP, PaddingBottom = 5 });
                                        //--------------------------------------------------------------------------------   

                                        if (orderDetail.Production.Count != 0 && orderDetail.Production.Count != 1)
                                        {
                                          if (IsOutHouseExists == "1")
                                          {
                                            var ProdFinishingSharePhrase = new Phrase();
                                            var lblFinishAllocate = "";
                                            double FinishingShareVal = ProdDetail.FinishingShare == 0 ? 0 : Math.Round(Convert.ToDouble(ProdDetail.FinishingShare) / 1000, 1);
                                            lblFinishAllocate = FinishingShareVal == 0 ? "" : FinishingShareVal.ToString() + "k";
                                            var CutAllocateFontss = FontFactory.GetFont("trebuchet ms", 12, Font.NORMAL, Color.GRAY);
                                            ProdFinishingSharePhrase.Add(new Chunk(lblFinishAllocate, CutAllocateFontss));
                                            ptProduction.AddCell(new PdfPCell(ProdFinishingSharePhrase) { Border = Rectangle.BOTTOM_BORDER, BorderWidthTop = Rectangle.TOP_BORDER, BorderWidthLeft = 1, BorderColor = BorderColor, HorizontalAlignment = Element.ALIGN_CENTER, FixedHeight = 40, VerticalAlignment = Element.ALIGN_MIDDLE, PaddingBottom = 5 });
                                          }
                                        }
                                        //--------------------------------------------------------------------------------   
                                        if (string.IsNullOrEmpty(orderDetail.IsVaCompleted))
                                        {
                                            var ProdVATPhrase = new Phrase();//2
                                            var txtVAToday = "";
                                            txtVAToday = ProdDetail.ValueAddedQtyToday == 0 ? "" : ProdDetail.ValueAddedQtyToday.ToString();

                                            var txtVATotal = "";
                                            if (ProdDetail.ValueAddedQty >= 1000)
                                                txtVATotal = Math.Round(Convert.ToDouble(ProdDetail.ValueAddedQty) / 1000, 1) + "k";
                                            else
                                                txtVATotal = ProdDetail.ValueAddedQty == 0 ? "" : String.Format("{0:#,##0}", ProdDetail.ValueAddedQty);

                                            var VAT = txtVAToday + "\n ------" + "\n" + txtVATotal;
                                            ProdVATPhrase.Add(new Chunk(VAT, CutFont));
                                            ptProduction.AddCell(new PdfPCell(ProdVATPhrase) { Border = Rectangle.BOTTOM_BORDER, BorderWidthTop = Rectangle.TOP_BORDER, BorderWidthLeft = 1, BorderColor = BorderColor, HorizontalAlignment = Element.ALIGN_CENTER, FixedHeight = 40, VerticalAlignment = Element.ALIGN_TOP, PaddingBottom = 5 });


                                        }
                                        //--------------------------------------------------------------------------------   

                                        var ProdFinishPhrase = new Phrase();
                                        var txtFinishToday = "";
                                        txtFinishToday = ProdDetail.TodayFinish == 0 ? "" : ProdDetail.TodayFinish.ToString();

                                        var txtFinishTotal = "";
                                        if (ProdDetail.TotalFinished >= 1000)
                                            txtFinishTotal = Math.Round(Convert.ToDouble(ProdDetail.TotalFinished) / 1000, 1) + "k";
                                        else
                                            txtFinishTotal = ProdDetail.TotalFinished == 0 ? "" : String.Format("{0:#,##0}", ProdDetail.TotalFinished);

                                        var Finish = txtFinishToday + "\n -----" + "\n" + txtFinishTotal;
                                        ProdFinishPhrase.Add(new Chunk(Finish, CutFont));
                                        ptProduction.AddCell(new PdfPCell(ProdFinishPhrase) { Border = Rectangle.BOTTOM_BORDER, BorderWidthTop = Rectangle.TOP_BORDER, BorderWidthLeft = 1, BorderColor = BorderColor, HorizontalAlignment = Element.ALIGN_CENTER, FixedHeight = 40, VerticalAlignment = Element.ALIGN_TOP, PaddingBottom = 5 });

                                        //----------------------------------------------Rescan--------------------------------------------------------------------------//
                                        double RescanTotalValueShareVal = 0.0;
                                        double RescanPendingValueShareVal = 0.0;
                                        if (Convert.ToInt32(IsReScan) == 1)
                                        {

                                         
                                          if (Convert.ToDouble(ProdDetail.RescanTotalValue) >= 1000)
                                            RescanTotalValueShareVal = Math.Round(Convert.ToDouble(ProdDetail.RescanTotalValue) / 1000, 1);
                                          else
                                            RescanTotalValueShareVal = Convert.ToInt32(Convert.ToDouble(ProdDetail.RescanTotalValue));

                                          if (Convert.ToDouble(ProdDetail.RescanPendingValue) >= 1000)
                                            RescanPendingValueShareVal = Math.Round(Convert.ToDouble(ProdDetail.RescanPendingValue) / 1000, 1);
                                          else
                                            RescanPendingValueShareVal = Convert.ToInt32(Convert.ToDouble(ProdDetail.RescanPendingValue));

                                          var ProdRescanPhrase = new Phrase();
                                          var txtRescanToday = "";
                                          if (ProdDetail.RescanTotalValue >= 1000)
                                            txtRescanToday = RescanTotalValueShareVal == 0 ? "" : RescanTotalValueShareVal.ToString() + "k";
                                          else
                                            txtRescanToday = RescanTotalValueShareVal == 0 ? "" : RescanTotalValueShareVal.ToString();

                                          var txtRescanTotal = "";
                                          if (RescanTotalValueShareVal >= 1000)
                                            txtRescanTotal = RescanPendingValueShareVal == 0 ? "" : RescanPendingValueShareVal.ToString() + "k";
                                          else
                                            txtRescanTotal = RescanPendingValueShareVal == 0 ? "" : RescanPendingValueShareVal.ToString();

                                          var Rescan = txtRescanToday + "\n -----" + "\n" + txtRescanTotal;
                                          ProdRescanPhrase.Add(new Chunk(Rescan, CutFont));
                                          ptProduction.AddCell(new PdfPCell(ProdRescanPhrase) { Border = Rectangle.BOTTOM_BORDER, BorderWidthTop = Rectangle.TOP_BORDER, BorderWidthLeft = 1, BorderColor = BorderColor, HorizontalAlignment = Element.ALIGN_CENTER, FixedHeight = 40, VerticalAlignment = Element.ALIGN_TOP, PaddingBottom = 5 });
                                        }
                                        //--------------------------------------------------------------------------------

                                        ProdFinishPhrase.Add(Chunk.NEWLINE);
                                        //----------------------------Total----------------------------------------------------

                                        if (ProdDetail.OutHouseHalfStitch == 0)//abhishek
                                        {
                                            StitchingShareAll += ProdDetail.StitchingShare;
                                        }
                                        CuttingShareAll += ProdDetail.CuttingShare;
                                        FinishingShareAll += ProdDetail.FinishingShare;
                                        TotalCutPcsAll += ProdDetail.TotalCutPcs;
                                        TotalCutReadyAll += ProdDetail.TotalCutReady;
                                        TotalStitchedAll += ProdDetail.TotalStitched;
                                        TotalFinishedAll += ProdDetail.TotalFinished;
                                        TotalValueAddedAll += ProdDetail.ValueAddedQty;
                                        TotalCutIssueAll += ProdDetail.CutIssueQtyTotal;
                                        TotalRescanAll = TotalRescanAll + ProdDetail.RescanTotalValue;
                                        TotalPendingRescan = TotalPendingRescan + ProdDetail.RescanPendingValue;
                                        //----------------------------Total----------------------------------------------------
                                    }
                            #endregion Loop end
                                    ////===========================================================================================
                                    # region Footer Start
                                    // added abhishek 11/4/2016
                                    int COUNT = 0;
                                    foreach (MOOrderDetails.ProductionDetails ProdDetail in orderDetail.Production)
                                    {
                                        COUNT = COUNT + 1;
                                    }
                                    var ProdTotalPhrase = new Phrase();
                                    var TotalFont = FontFactory.GetFont("trebuchet ms", 12, Font.NORMAL, Color.GRAY);
                                    ProdTotalPhrase.Add(new Chunk("Total", TotalFont));
                                    ptProduction.AddCell(new PdfPCell(ProdTotalPhrase) { Border = Rectangle.BOTTOM_BORDER, Colspan = ColspanValue, BorderWidthTop = Rectangle.TOP_BORDER, BorderWidthLeft = 1, BorderWidthBottom = 2, BorderColor = BorderColor, HorizontalAlignment = Element.ALIGN_LEFT, FixedHeight = 40, VerticalAlignment = Element.ALIGN_CENTER, PaddingBottom = 5 });
                                    //--------------------------------------------------------------------------------

                                    if (orderDetail.Production.Count != 0 && orderDetail.Production.Count != 1)
                                    {
                                      if (IsOutHouseExists == "1")
                                      {
                                           
                                        var ProdCutAllocateAllPhrase = new Phrase();
                                        var lblCutAllocate_Footer = "";
                                        if (CuttingShareAll >= 1000)
                                          lblCutAllocate_Footer = Math.Round(Convert.ToDouble(CuttingShareAll) / 1000, 1) + "k";
                                        else
                                          lblCutAllocate_Footer = CuttingShareAll == 0 ? "" : String.Format("{0:#,##0}", CuttingShareAll);

                                        ProdCutAllocateAllPhrase.Add(new Chunk(lblCutAllocate_Footer, TotalFont));
                                        ptProduction.AddCell(new PdfPCell(ProdCutAllocateAllPhrase) { Border = Rectangle.BOTTOM_BORDER, BorderWidthTop = Rectangle.TOP_BORDER, BorderWidthLeft = 1, BorderWidthBottom = 2, BorderColor = BorderColor, HorizontalAlignment = Element.ALIGN_CENTER, FixedHeight = 40, VerticalAlignment = Element.ALIGN_TOP, PaddingBottom = 5 });
                                      }
                                        //--------------------------------------------------------------------------------
                                    }
                                    var ProdCutAllPhrase = new Phrase();
                                    var lblCutTotal_Footer = "";
                                    if (TotalCutPcsAll >= 1000)
                                        lblCutTotal_Footer = Math.Round(Convert.ToDouble(TotalCutPcsAll) / 1000, 1) + "k";
                                    else
                                        lblCutTotal_Footer = TotalCutPcsAll == 0 ? "" : String.Format("{0:#,##0}", TotalCutPcsAll);

                                    var lblCutTotal_Percent = Math.Round(((Convert.ToDouble(TotalCutPcsAll) / (CuttingShareAll == 0 ? 1 : CuttingShareAll)) * 100), 0).ToString() + "%";

                                    var CutAll = COUNT > 1 ? lblCutTotal_Footer + "\n -----" + "\n" + lblCutTotal_Percent : lblCutTotal_Percent;

                                    var CutAllFont = FontFactory.GetFont("trebuchet ms", 10, Font.NORMAL, LinktypeForeColor);
                                    ProdCutAllPhrase.Add(new Chunk(CutAll, CutAllFont));
                                    ptProduction.AddCell(new PdfPCell(ProdCutAllPhrase) { Border = Rectangle.BOTTOM_BORDER, BorderWidthTop = Rectangle.TOP_BORDER, BorderWidthLeft = 1, BorderWidthBottom = 2, BorderColor = BorderColor, HorizontalAlignment = Element.ALIGN_CENTER, FixedHeight = 40, VerticalAlignment = Element.ALIGN_CENTER, PaddingBottom = 5 });
                                    //--------------------------------------------------------------------------------   

                                    var ProdCutReadyAllPhrase = new Phrase();
                                    var lblCutReadyTotal_Footer = "";
                                    if (TotalCutReadyAll >= 1000)
                                        lblCutReadyTotal_Footer = Math.Round(Convert.ToDouble(TotalCutReadyAll) / 1000, 1) + "k";
                                    else
                                        lblCutReadyTotal_Footer = TotalCutReadyAll == 0 ? "" : String.Format("{0:#,##0}", TotalCutReadyAll);

                                    var lblCutReadyTotal_Percent = Math.Round(((Convert.ToDouble(TotalCutReadyAll) / (CuttingShareAll == 0 ? 1 : CuttingShareAll)) * 100), 0).ToString() + "%";

                                    var CutReadyALL = COUNT > 1 ? lblCutReadyTotal_Footer + "\n -----" + "\n" + lblCutReadyTotal_Percent : lblCutTotal_Percent;

                                    ProdCutReadyAllPhrase.Add(new Chunk(CutReadyALL, CutAllFont));
                                    ptProduction.AddCell(new PdfPCell(ProdCutReadyAllPhrase) { Border = Rectangle.BOTTOM_BORDER, BorderWidthTop = Rectangle.TOP_BORDER, BorderWidthLeft = 1, BorderWidthBottom = 2, BorderColor = BorderColor, HorizontalAlignment = Element.ALIGN_CENTER, FixedHeight = 40, VerticalAlignment = Element.ALIGN_CENTER, PaddingBottom = 5 });


                                    //-----------------------Cut Issue--------------------------------------------------------- //  
                                    if (orderDetail.Production.Count != 0 && orderDetail.Production.Count != 1)
                                    {
                                      if (IsOutHouseExists == "1")
                                      {
                                        var ProdCutIssueAllPhrase = new Phrase();
                                        var lblCutIssueTotal_Footer = "";
                                        if (TotalCutIssueAll >= 1000)
                                          lblCutIssueTotal_Footer = Math.Round(Convert.ToDouble(TotalCutIssueAll) / 1000, 1) + "k";
                                        else
                                          lblCutIssueTotal_Footer = TotalCutIssueAll == 0 ? "" : String.Format("{0:#,##0}", TotalCutIssueAll);

                                        var lblCutIssueTotal_Percent = Math.Round(((Convert.ToDouble(TotalCutIssueAll) / (CuttingShareAll == 0 ? 1 : CuttingShareAll)) * 100), 0).ToString() + "%";
                                        var CutIssueALL = COUNT > 1 ? lblCutIssueTotal_Footer + "\n -----" + "\n" + lblCutIssueTotal_Percent : lblCutTotal_Percent;

                                        ProdCutIssueAllPhrase.Add(new Chunk(CutIssueALL, CutAllFont));
                                        ptProduction.AddCell(new PdfPCell(ProdCutIssueAllPhrase) { Border = Rectangle.BOTTOM_BORDER, BorderWidthTop = Rectangle.TOP_BORDER, BorderWidthLeft = 1, BorderWidthBottom = 2, BorderColor = BorderColor, HorizontalAlignment = Element.ALIGN_CENTER, FixedHeight = 40, VerticalAlignment = Element.ALIGN_CENTER, PaddingBottom = 5 });
                                      }
                                    }

                                    //--------------------------------------------------------------------------------     

                                    if (orderDetail.Production.Count != 0 && orderDetail.Production.Count != 1)
                                    {
                                      if (IsOutHouseExists == "1")
                                      {

                                        var ProdStitchingAllPhrase = new Phrase();
                                        var lblStitchingAllocate_Footer = "";

                                        if (StitchingShareAll >= 1000)
                                          lblStitchingAllocate_Footer = Math.Round(Convert.ToDouble(StitchingShareAll) / 1000, 1) + "k";
                                        else
                                          lblStitchingAllocate_Footer = StitchingShareAll == 0 ? "" : String.Format("{0:#,##0}", StitchingShareAll);

                                        ProdStitchingAllPhrase.Add(new Chunk(lblStitchingAllocate_Footer, TotalFont));
                                        ptProduction.AddCell(new PdfPCell(ProdStitchingAllPhrase) { Border = Rectangle.BOTTOM_BORDER, BorderWidthTop = Rectangle.TOP_BORDER, BorderWidthLeft = 1, BorderWidthBottom = 2, BorderColor = BorderColor, HorizontalAlignment = Element.ALIGN_CENTER, FixedHeight = 40, VerticalAlignment = Element.ALIGN_TOP, PaddingBottom = 5 });
                                      }
                                    }
                                    //--------------------------------------------------------------------------------   

                                    var ProdStitchAllPhrase = new Phrase();

                                    var lblStitchTotal_Footer = "";
                                    if (TotalStitchedAll >= 1000)
                                        lblStitchTotal_Footer = Math.Round(Convert.ToDouble(TotalStitchedAll) / 1000, 1) + "k";
                                    else
                                        lblStitchTotal_Footer = TotalStitchedAll == 0 ? "" : String.Format("{0:#,##0}", TotalStitchedAll);

                                    var lblStitchTotal_Percent = Math.Round(((Convert.ToDouble(TotalStitchedAll) / (StitchingShareAll == 0 ? 1 : StitchingShareAll)) * 100), 0).ToString() + "%";

                                    var StitchAll = COUNT > 1 ? lblStitchTotal_Footer + "\n -----" + "\n" + lblStitchTotal_Percent : lblStitchTotal_Percent;
                                    ProdStitchAllPhrase.Add(new Chunk(StitchAll, CutAllFont));
                                    ptProduction.AddCell(new PdfPCell(ProdStitchAllPhrase) { Border = Rectangle.BOTTOM_BORDER, BorderWidthTop = Rectangle.TOP_BORDER, BorderWidthLeft = 1, BorderWidthBottom = 2, BorderColor = BorderColor, HorizontalAlignment = Element.ALIGN_CENTER, FixedHeight = 40, VerticalAlignment = Element.ALIGN_CENTER, PaddingBottom = 5 });
                                    //--------------------------------------------------------------------------------   

                                    if (orderDetail.Production.Count != 0 && orderDetail.Production.Count != 1)
                                    {
                                      if (IsOutHouseExists == "1")
                                      {
                                        var ProdFinishingAllPhrase = new Phrase();
                                        var lblFinishAllocate_Footer = "";
                                        if (FinishingShareAll >= 1000)
                                          lblFinishAllocate_Footer = Math.Round(Convert.ToDouble(FinishingShareAll) / 1000, 1) + "k";
                                        else
                                          lblFinishAllocate_Footer = FinishingShareAll == 0 ? "" : String.Format("{0:#,##0}", FinishingShareAll);

                                        ProdFinishingAllPhrase.Add(new Chunk(lblFinishAllocate_Footer, TotalFont));
                                        ptProduction.AddCell(new PdfPCell(ProdFinishingAllPhrase) { Border = Rectangle.BOTTOM_BORDER, BorderWidthTop = Rectangle.TOP_BORDER, BorderWidthLeft = 1, BorderWidthBottom = 2, BorderColor = BorderColor, HorizontalAlignment = Element.ALIGN_CENTER, FixedHeight = 40, VerticalAlignment = Element.ALIGN_TOP, PaddingBottom = 5 });
                                      }
                                    }
                                    //--------------------------------------------------------------------------------   
                                    if (string.IsNullOrEmpty(orderDetail.IsVaCompleted))
                                    {
                                        var ProdVATAllPhrase = new Phrase();
                                        var lblVATotal_Footer = "";

                                        if (TotalValueAddedAll >= 1000)
                                            lblVATotal_Footer = Math.Round(Convert.ToDouble(TotalValueAddedAll) / 1000, 1) + "k";
                                        else
                                            lblVATotal_Footer = TotalValueAddedAll == 0 ? "" : String.Format("{0:#,##0}", TotalValueAddedAll);

                                        var lblVATotal_Percent = Math.Round(((Convert.ToDouble(TotalValueAddedAll) / (FinishingShareAll == 0 ? 1 : FinishingShareAll)) * 100), 0).ToString() + "%";

                                        var VATAll = COUNT > 1 ? lblVATotal_Footer + "\n -----" + "\n" + lblVATotal_Percent : lblVATotal_Percent;
                                        ProdVATAllPhrase.Add(new Chunk(VATAll, CutAllFont));
                                        ptProduction.AddCell(new PdfPCell(ProdVATAllPhrase) { Border = Rectangle.BOTTOM_BORDER, BorderWidthTop = Rectangle.TOP_BORDER, BorderWidthLeft = 1, BorderWidthBottom = 2, BorderColor = BorderColor, HorizontalAlignment = Element.ALIGN_CENTER, FixedHeight = 40, VerticalAlignment = Element.ALIGN_CENTER, PaddingBottom = 5 });


                                    }
                                    //--------------------------------------------------------------------------------   

                                    var ProdFinishAllPhrase = new Phrase();
                                    var lblFinishTotal_Footer = "";
                                    if (TotalFinishedAll >= 1000)
                                        lblFinishTotal_Footer = Math.Round(Convert.ToDouble(TotalFinishedAll) / 1000, 1) + "k";
                                    else
                                        lblFinishTotal_Footer = TotalFinishedAll == 0 ? "" : String.Format("{0:#,##0}", TotalFinishedAll);


                                    var lblFinishTotal_Percent = Math.Round(((Convert.ToDouble(TotalFinishedAll) / (FinishingShareAll == 0 ? 1 : FinishingShareAll)) * 100), 0).ToString() + "%";

                                    var FinishAll = COUNT > 1 ? lblFinishTotal_Footer + "\n -----" + "\n" + lblFinishTotal_Percent : lblFinishTotal_Percent;
                                    ProdFinishAllPhrase.Add(new Chunk(FinishAll, CutAllFont));
                                    ptProduction.AddCell(new PdfPCell(ProdFinishAllPhrase) { Border = Rectangle.BOTTOM_BORDER, BorderWidthTop = Rectangle.TOP_BORDER, BorderWidthLeft = 1, BorderWidthBottom = 2, BorderColor = BorderColor, HorizontalAlignment = Element.ALIGN_CENTER, FixedHeight = 40, VerticalAlignment = Element.ALIGN_CENTER, PaddingBottom = 5 });


                                    //-----------------------------------Rescan---------------------------------------------   
                                    if (Convert.ToInt32(IsReScan)==1)
                                    {

                                      double RescanTotalValueShareVal = 0.0;
                                      double RescanPendingValueShareVal = 0.0;
                                      if (Convert.ToDouble(TotalRescanAll) > 1000)
                                        RescanTotalValueShareVal = Math.Round(Convert.ToDouble(TotalRescanAll) / 1000, 1);
                                      else
                                        RescanTotalValueShareVal = Convert.ToInt32(Convert.ToDouble(TotalRescanAll));

                                      if (Convert.ToDouble(TotalPendingRescan) > 1000)
                                        RescanPendingValueShareVal = Math.Round(Convert.ToDouble(TotalPendingRescan) / 1000, 1);
                                      else
                                        RescanPendingValueShareVal = Convert.ToInt32(Convert.ToDouble(TotalPendingRescan));

                                      var ProdRescanAllPhrase = new Phrase();
                                      var lblRescanTotal_Footer = "";

                                      if (TotalRescanAll >= 1000)
                                        lblRescanTotal_Footer = RescanTotalValueShareVal == 0 ? "" : RescanTotalValueShareVal.ToString() + "k";
                                      else
                                        lblRescanTotal_Footer = RescanTotalValueShareVal == 0 ? "" : RescanTotalValueShareVal.ToString();

                                      var txtPendingRescanFooter = "";
                                      if (Convert.ToDouble(TotalPendingRescan) > 1000)
                                        txtPendingRescanFooter = RescanPendingValueShareVal == 0 ? "" : RescanPendingValueShareVal.ToString() + "k";
                                      else
                                        txtPendingRescanFooter = RescanPendingValueShareVal == 0 ? "" : RescanPendingValueShareVal.ToString();

                                      //var lblRescanTotal_Percent = Math.Round(((Convert.ToDouble(TotalValueAddedAll) / (FinishingShareAll == 0 ? 1 : FinishingShareAll)) * 100), 0).ToString() + "%";

                                      var RescanAll = lblRescanTotal_Footer + "\n -----" + "\n" + txtPendingRescanFooter;
                                      ProdRescanAllPhrase.Add(new Chunk(RescanAll, CutAllFont));
                                      ptProduction.AddCell(new PdfPCell(ProdRescanAllPhrase) { Border = Rectangle.BOTTOM_BORDER, BorderWidthTop = Rectangle.TOP_BORDER, BorderWidthLeft = 1, BorderWidthBottom = 2, BorderColor = BorderColor, HorizontalAlignment = Element.ALIGN_CENTER, FixedHeight = 40, VerticalAlignment = Element.ALIGN_CENTER, PaddingBottom = 5 });

                                    }

                                    ProdFinishAllPhrase.Add(Chunk.NEWLINE);
                                    //--------------------------------------------------------------------------------
                                }
                            }
                                    #endregion Footer end

                            var MdaPhrase = new Phrase();
                            string Mda = "";
                            if (orderDetail.bMDARead)
                            {
                                if (orderDetail.ParentOrder.Style.client.IsMDARequired != 0)
                                {
                                    Mda = orderDetail.MDANumber.ToString();
                                }
                            }
                            var MdaFont = FontFactory.GetFont("trebuchet ms", 11, Font.NORMAL, BlackToForeColor);
                            MdaPhrase.Add(new Chunk(Mda, MdaFont));

                            ptProduction.AddCell(new PdfPCell(MdaPhrase) { BorderColor = BorderColor, Colspan = 11, Border = Rectangle.NO_BORDER, HorizontalAlignment = Element.ALIGN_LEFT, FixedHeight = 30, VerticalAlignment = Element.ALIGN_TOP, PaddingBottom = 5 });
                            MdaPhrase.Add(Chunk.NEWLINE);


                            var ICPhrase = new Phrase();
                            string Caption = "";

                            var icFont = FontFactory.GetFont("trebuchet ms", 11, Font.NORMAL, BlackToForeColor);
                            ICPhrase.Add(new Chunk(Caption, icFont));

                            ptProduction.AddCell(new PdfPCell(ICPhrase) { BorderColor = BorderColor, Colspan = 11, Border = Rectangle.NO_BORDER, HorizontalAlignment = Element.ALIGN_RIGHT, FixedHeight = 30, VerticalAlignment = Element.ALIGN_TOP, PaddingBottom = 5 });
                            ICPhrase.Add(Chunk.NEWLINE);


                            //--------------------------------------------------------------------------------

                            //var lblst = "";
                            var lblEnd = "";
                            var lineNo = "";

                            if (orderDetail.LinePlanningEndDate != DateTime.MinValue)
                            {
                                lblEnd = "TO: " + orderDetail.LinePlanningEndDate.ToString("dd MMM yy");
                            }
                            var finaldate = "";

                            var Day = "";
                            if (orderDetail.IsLinePlan == 1)
                            {
                                Day = finaldate;
                            }
                            else
                            {
                                lineNo = "";
                            }

                            var EndPhrase = new Phrase();
                            EndPhrase.Add(new Chunk(lineNo + " " + Day, MdaFont));
                            ptProduction.AddCell(new PdfPCell(EndPhrase) { BorderColor = BorderColor, Colspan = 11, Border = Rectangle.NO_BORDER, HorizontalAlignment = Element.ALIGN_RIGHT, FixedHeight = 30, VerticalAlignment = Element.ALIGN_TOP, PaddingBottom = 5 });
                            EndPhrase.Add(Chunk.NEWLINE);

                            var ShippedPhrase = new Phrase();
                            string lblShippedCaption = "";
                            if (orderDetail.IsShiped == true)
                            {

                                string ShippedDate = "";
                                string ShortExtra = "";
                                if (orderDetail.IsShipedDate != DateTime.MinValue)
                                {
                                    ShippedDate = orderDetail.IsShipedDate.ToString("dd MMM yy");
                                }

                                double dQuantity = orderDetail.Quantity;
                                int ShippedQty = orderDetail.ShippedQty;

                                if (dQuantity > Convert.ToDouble(ShippedQty))
                                {
                                    ShortExtra = "short";
                                }
                                else
                                {
                                    ShortExtra = "extra";
                                }
                                double ShortShipped = dQuantity - Convert.ToDouble(ShippedQty);
                                double ShortShippedPercent = (ShortShipped * 100) / dQuantity;
                                ShortShippedPercent = Math.Round(ShortShippedPercent, 2);
                                double ctplqty = Convert.ToDouble(TotalCutPcsAll) - Convert.ToDouble(ShippedQty);
                                double ctplPercentage = (ctplqty * 100) / Convert.ToDouble(TotalCutPcsAll);
                                ctplPercentage = Math.Round(ctplPercentage, 2);
                                string ShippedCaption = "";
                                if (ctplPercentage == 0.0)
                                {
                                    if (ShortShippedPercent > 0.0)
                                    {
                                        ShippedCaption = ShippedQty + " Shpd ( " + ShortShippedPercent + " % " + ShortExtra + ") On " + ShippedDate;
                                    }
                                    else
                                    {

                                        ShippedCaption = ShippedQty + " Shpd (" + ShortShippedPercent + " % " + ShortExtra + ") On " + ShippedDate;
                                    }
                                }
                                else
                                {
                                    if (ctplPercentage > 0.0)
                                    {
                                        if (ShortShippedPercent > 0.0)
                                        {
                                            if (orderDetail.TotalPenalty == 0.0)
                                                ShippedCaption = ShippedQty + " Shpd (" + ShortShippedPercent + " % " + ShortExtra + "), CTSL (" + ctplPercentage + " %) On " + ShippedDate + " & No Penalty";
                                            else
                                                ShippedCaption = ShippedQty + " Shpd (" + ShortShippedPercent + " % " + ShortExtra + "), CTSL (" + ctplPercentage + " %) On " + ShippedDate + " & Pnlty % to Shpd " + orderDetail.PenaltyPercentAge + "% Total Pnlty " + orderDetail.TotalPenalty;

                                        }
                                        else
                                        {
                                            if (orderDetail.TotalPenalty == 0.0)
                                                ShippedCaption = ShippedQty + " Shpd (" + ShortShippedPercent + " % " + ShortExtra + "), CTSL (" + ctplPercentage + " %) On " + ShippedDate + " & No Penalty";
                                            else
                                                ShippedCaption = ShippedQty + " Shpd (" + ShortShippedPercent + " % " + ShortExtra + "), CTSL (" + ctplPercentage + " %) On " + ShippedDate + " & Pnlty % to Shpd " + orderDetail.PenaltyPercentAge + "% Total Pnlty " + orderDetail.TotalPenalty;

                                        }

                                    }
                                    else
                                    {
                                        if (ShortShippedPercent > 0.0)
                                        {
                                            if (orderDetail.TotalPenalty == 0.0)
                                                ShippedCaption = ShippedQty + " Shpd (" + ShortShippedPercent + " % " + ShortExtra + "), CTSL (" + ctplPercentage + " %) On " + ShippedDate + " & No Penalty";
                                            else
                                                ShippedCaption = ShippedQty + " Shpd (" + ShortShippedPercent + " % " + ShortExtra + "), CTSL (" + ctplPercentage + " %) On " + ShippedDate + " & Pnlty % to Shpd " + orderDetail.PenaltyPercentAge + "% Total Pnlty " + orderDetail.TotalPenalty;

                                        }
                                        else
                                        {
                                            if (orderDetail.TotalPenalty == 0.0)
                                                ShippedCaption = ShippedQty + " Shpd (" + ShortShippedPercent + " % " + ShortExtra + "), CTSL (" + ctplPercentage + " %) On " + ShippedDate + " & No Penalty";
                                            else
                                                ShippedCaption = ShippedQty + " Shpd (" + ShortShippedPercent + " % " + ShortExtra + "), CTSL (" + ctplPercentage + " %) On " + ShippedDate + " & Pnlty % to Shpd " + orderDetail.PenaltyPercentAge + "% Total Pnlty " + orderDetail.TotalPenalty;
                                        }

                                    }
                                }
                                lblShippedCaption = ShippedCaption;
                            }
                            else
                            {
                                lblShippedCaption = "Waiting to be shipped.";
                            }
                            Color ShipFontColor = Color.GRAY;
                            var ShippedFont = FontFactory.GetFont("trebuchet ms", 12, Font.NORMAL, ShipFontColor);
                            ShippedPhrase.Add(new Chunk(lblShippedCaption, ShippedFont));
                            ptProduction.AddCell(new PdfPCell(ShippedPhrase) { BorderColor = BorderColor, Colspan = 11, Border = Rectangle.NO_BORDER, HorizontalAlignment = Element.ALIGN_LEFT, FixedHeight = 60, VerticalAlignment = Element.ALIGN_TOP, PaddingBottom = 5 });
                            //--------------------------------------------------------------------------------

                            float[] ProductioColWidths = new float[] { 20f, 17f, 22f, 22f, 22f, 17f, 22f, 17f, 22f, 22f, 22f  };
                            ptProduction.SetWidths(ProductioColWidths);

                            PDFCell ProductionCell = new PDFCell(ptProduction);
                            ProductionRow.Add(ProductionCell);
                            gen.Rows.Add(ProductionRow);

                            #endregion Production Section
                        }
                        catch (Exception ex)
                        {
                            System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                            System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                        }
                    }
                    gen.GeneratePDF_MO(); // Method which makes the Pdf 

                }
                catch (Exception ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                }

            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                fileName = "";
            }
            return fileName;
        }

        #endregion


        public bool GenerateOverallReport(string PDFPath, string Type, DateTime Date, out List<OrderDetail> orderDetails)
        {

            PDFTableGenerator gen = new PDFTableGenerator(PDFPath);
            List<OrderDetail> orderDetail;
            List<OrderDetail> controllerName = new List<OrderDetail>();
            Color HeaderColor = new Color(System.Drawing.ColorTranslator.FromHtml("#F9DDF4"));
            //if (Type == "Packing")
            //{
            //    gen = new PDFTableGenerator(PDFPath, "Overall Packing Report", HeaderColor);
            //    controllerName = this.OrderDataProviderInstance.GetAllOrderPackedToday(Date);
            //}
            //else if (Type == "Inline Cut")
            //{
            //    gen = new PDFTableGenerator(PDFPath, "Overall Inline Cut Report", HeaderColor);
            //    controllerName = this.OrderDataProviderInstance.GetAllInlineCutToday(Date);
            //}
            //else if (Type == "Ex-Factory")
            //{
            //    gen = new PDFTableGenerator(PDFPath, "Overall Ex-Factory Report", HeaderColor);
            //    //controllerName = this.OrderDataProviderInstance.GetAllExfactoryReport(Date);
            //}
            if (Type == "New Order")
            {
                gen = new PDFTableGenerator(PDFPath, "Overall New Order Report", HeaderColor);
                controllerName = this.OrderDataProviderInstance.GetAllNewOrderReport(Date, true);
            }
            else if (Type == "New Order NonIkandi")
            {
                gen = new PDFTableGenerator(PDFPath, "Overall New Non Ikandi Order Report", HeaderColor);
                controllerName = this.OrderDataProviderInstance.GetAllNewOrderReport(Date, false);
            }
            else if (Type == "Stc UnAllocated")
            {
                gen = new PDFTableGenerator(PDFPath, "Overall Stc Styles Report", HeaderColor);
                //controllerName = this.OrderDataProviderInstance.GetAllStcUnAllocatedReport(Date);
            }

            else if (Type == "Top Requseted")
            {
                gen = new PDFTableGenerator(PDFPath, "Top Requested Report", HeaderColor);
                controllerName = this.ReportDataProviderInstance.GetAllTopRequestedReport();
            }

            else if (Type == "PP Meeting Pending")
            {
                gen = new PDFTableGenerator(PDFPath, "PP Meetings Pending Report", HeaderColor);
                controllerName = this.ReportDataProviderInstance.GetAllPPMeetingPending(Date);
            }

            else if (Type == "Live")
            {
                gen = new PDFTableGenerator(PDFPath, "Overall Live Order Report", HeaderColor);
                // controllerName = this.OrderDataProviderInstance.GetAllOrderLiveToday(Date);
            }
            else if (Type == "Ex-Factories Planned")
            {
                gen = new PDFTableGenerator(PDFPath, "Overall Ex-Factories Planned Report", HeaderColor);
                // controllerName = this.OrderDataProviderInstance.GetAllOrderExFactoryPlannedToday(Date);
            }
            else if (Type == "Approved To Ex-Factory")
            {
                gen = new PDFTableGenerator(PDFPath, "Overall Approved To Ship Report", HeaderColor);
                //  controllerName = this.OrderDataProviderInstance.GetAllOrderApprovedToExFactoryToday(Date);
            }

            else if (Type == "Part Ex-Factory")
            {
                gen = new PDFTableGenerator(PDFPath, "Overall Part Ex-Factory Report", HeaderColor);
                // controllerName = this.OrderDataProviderInstance.GetAllPartOfExFactoryReport(Date);
            }
            else if (Type == "Fabric Order Changes")
            {
                gen = new PDFTableGenerator(PDFPath, "Fabric Order Form Changes", HeaderColor);
                controllerName = this.FabricWorkingDataProviderInstance.GetFabricWorkingByCurrentDate();
            }

            else if (Type == "Live Pending")
            {
                gen = new PDFTableGenerator(PDFPath, "Live Pending", HeaderColor);
                // controllerName = this.OrderDataProviderInstance.GetAllLivePendingEmail(Date);
            }

            else if (Type == "Inline Not Cut Today")
            {
                gen = new PDFTableGenerator(PDFPath, "Inline Cut Pending Report", HeaderColor);
                // controllerName = this.OrderDataProviderInstance.GetInlineCutPendingTodayEmail(Date);
            }
            else if (Type == "Pending Buying Samples")
            {
                gen = new PDFTableGenerator(PDFPath, "Pending Buying Samples", HeaderColor);
                //  controllerName = this.OrderDataProviderInstance.GetPendingBuyingSamplesForMondayEmail();
            }

            orderDetails = orderDetail = controllerName;

            gen.CellHeight = 200;
            gen.Columns = new List<PDFHeader>();

            if (Type != "Fabric Order Changes")
            {
                if (Type == "Live Pending")
                {
                    gen.Columns.Add(new PDFHeader("Order Date", iKandi.Common.ContentAlignment.Horizontal, 7));
                }

                gen.Columns.Add(new PDFHeader("Style Number", iKandi.Common.ContentAlignment.Horizontal, 7));
            }

            if (Type == "Packing" || Type == "Inline Cut" || Type == "Ex-Factory" || Type == "New Order" || Type == "New Order NonIkandi" || Type == "Stc UnAllocated" || Type == "Live" || Type == "Ex-Factories Planned" || Type == "Approved To Ex-Factory" || Type == "Part Ex-Factory" || Type == "Live Pending" || Type == "Pending Buying Samples")
            {
                gen.Columns.Add(new PDFHeader("Style", iKandi.Common.ContentAlignment.Horizontal, 8));
                gen.Columns.Add(new PDFHeader("Serial No.", iKandi.Common.ContentAlignment.Horizontal, 8));
                gen.Columns.Add(new PDFHeader("Line No.", iKandi.Common.ContentAlignment.Horizontal, 8, 10));
                gen.Columns.Add(new PDFHeader("Contract", iKandi.Common.ContentAlignment.Horizontal, 8, 10));

                if (Type == "New Order" || Type == "New Order NonIkandi" || Type == "Live" || Type == "Live Pending" || Type == "Pending Buying Samples")
                {
                    gen.Columns.Add(new PDFHeader("Fabric Details", ContentAlignment.Horizontal, 15));
                }

                gen.Columns.Add(new PDFHeader("Qty", iKandi.Common.ContentAlignment.Horizontal, 4));
                gen.Columns.Add(new PDFHeader("Mode", iKandi.Common.ContentAlignment.Horizontal, 4));
                gen.Columns.Add(new PDFHeader("Ex Factory", iKandi.Common.ContentAlignment.Horizontal, 10));
                //gen.Columns.Add(new PDFHeader("Status", iKandi.Common.ContentAlignment.Horizontal, 8));
                gen.Columns.Add(new PDFHeader("Dept. Name", iKandi.Common.ContentAlignment.Horizontal, 10));
                if (Type == "Pending Buying Samples")
                {
                    gen.Columns.Add(new PDFHeader("Target Date", ContentAlignment.Horizontal, 10));
                }
            }

            else if (Type == "Top Requseted" || Type == "PP Meeting Pending" || Type == "Inline Not Cut Today")
            {
                gen.Columns.Add(new PDFHeader("Style", iKandi.Common.ContentAlignment.Horizontal, 8));
                gen.Columns.Add(new PDFHeader("Serial No.", iKandi.Common.ContentAlignment.Vertical, 2, 10));
                gen.Columns.Add(new PDFHeader("Line No.", iKandi.Common.ContentAlignment.Vertical, 2, 10));
                gen.Columns.Add(new PDFHeader("Contract", iKandi.Common.ContentAlignment.Vertical, 2, 10));
                gen.Columns.Add(new PDFHeader("Qty", iKandi.Common.ContentAlignment.Horizontal, 4));
                gen.Columns.Add(new PDFHeader("Mode", iKandi.Common.ContentAlignment.Vertical, 2, 10));
                gen.Columns.Add(new PDFHeader("Ex Factory", iKandi.Common.ContentAlignment.Horizontal, 10));
                gen.Columns.Add(new PDFHeader("Status", iKandi.Common.ContentAlignment.Vertical, 2, 10));

                if (Type == "PP Meeting Pending" || Type == "Inline Not Cut Today")
                {
                    gen.Columns.Add(new PDFHeader("Unit", iKandi.Common.ContentAlignment.Vertical, 2, 10));
                }

                gen.Columns.Add(new PDFHeader("Seal Date", iKandi.Common.ContentAlignment.Vertical, 2, 10));

                if (Type != "Top Requseted")
                {
                    gen.Columns.Add(new PDFHeader("Fabric Details", ContentAlignment.Horizontal, 15));
                    gen.Columns.Add(new PDFHeader("Accessories", ContentAlignment.Horizontal, 15));
                }

                if (Type == "Inline Not Cut Today")
                {
                    gen.Columns.Add(new PDFHeader("Inline Cut Tgt.", iKandi.Common.ContentAlignment.Horizontal, 10));
                }

                if (Type != "Inline Not Cut Today")
                {
                    gen.Columns.Add(new PDFHeader("Completion Tgt.", iKandi.Common.ContentAlignment.Vertical, 2, 10));
                    gen.Columns.Add(new PDFHeader("Completed", iKandi.Common.ContentAlignment.Vertical, 2, 10));
                    gen.Columns.Add(new PDFHeader("Pcs Cut", iKandi.Common.ContentAlignment.Vertical, 2, 10));
                    gen.Columns.Add(new PDFHeader("% Cut", iKandi.Common.ContentAlignment.Vertical, 2, 10));
                    gen.Columns.Add(new PDFHeader("Pcs To Be Cut", ContentAlignment.Vertical, 2, 10));
                    gen.Columns.Add(new PDFHeader("Pcs Issued", iKandi.Common.ContentAlignment.Vertical, 2, 10));
                    gen.Columns.Add(new PDFHeader("Bal. In House", iKandi.Common.ContentAlignment.Vertical, 2, 10));
                    gen.Columns.Add(new PDFHeader("Inline", iKandi.Common.ContentAlignment.Vertical, 2, 10));
                    gen.Columns.Add(new PDFHeader("Top Send Tgt.", iKandi.Common.ContentAlignment.Vertical, 2, 10));
                    gen.Columns.Add(new PDFHeader("Send", ContentAlignment.Vertical, 2, 10));
                }
            }

            if (Type == "Top Requseted")
            {
                gen.Columns.Add(new PDFHeader("Unit Name", iKandi.Common.ContentAlignment.Vertical, 2, 10));
                gen.Columns.Add(new PDFHeader("Sealer Remarks BIPL", ContentAlignment.Horizontal, 11));
                gen.Columns.Add(new PDFHeader("Fits Remark", ContentAlignment.Horizontal, 11));
                gen.Columns.Add(new PDFHeader("Production Remarks", ContentAlignment.Horizontal, 11));
            }

            if (Type != "New Order" && Type != "New Order NonIkandi" && Type != "Stc UnAllocated" && Type != "PP Meeting Pending" && Type != "Live" && Type != "Top Requseted" && Type != "Fabric Order Changes" && Type != "Approved To Ex-Factory" && Type != "Live Pending" && Type != "Inline Not Cut Today" && Type != "Pending Buying Samples")
            {
                gen.Columns.Add(new PDFHeader("Unit", iKandi.Common.ContentAlignment.Vertical, 2, 10));
            }

            if (Type == "Stc UnAllocated")
            {
                gen.Columns.Add(new PDFHeader("Seal Date", iKandi.Common.ContentAlignment.Vertical, 2, 10));
                gen.Columns.Add(new PDFHeader("Fabric Details", ContentAlignment.Horizontal, 15));
                gen.Columns.Add(new PDFHeader("Accessories", ContentAlignment.Horizontal, 15));
            }

            if (Type == "Ex-Factories Planned" || Type == "Approved To Ex-Factory")
            {
                gen.Columns.Add(new PDFHeader("Planned Ex Date", iKandi.Common.ContentAlignment.Horizontal, 10));

                if (Type == "Approved To Ex-Factory")
                {
                    gen.Columns.Add(new PDFHeader("Shipping Quantity", iKandi.Common.ContentAlignment.Horizontal, 4));
                }
            }

            if (Type == "Ex-Factory" || Type == "Ex-Factories Planned" || Type == "Part Ex-Factory")
            {
                gen.Columns.Add(new PDFHeader("Shipping Qty.", ContentAlignment.Horizontal, 4));

            }

            if (Type == "Fabric Order Changes")
            {
                gen.Columns.Add(new PDFHeader("Order Dt.", iKandi.Common.ContentAlignment.Vertical, 2, 10));
                gen.Columns.Add(new PDFHeader("Serial No.", iKandi.Common.ContentAlignment.Vertical, 2, 10));
                gen.Columns.Add(new PDFHeader("Dept.", iKandi.Common.ContentAlignment.Vertical, 2, 10));
                gen.Columns.Add(new PDFHeader("Style No.", iKandi.Common.ContentAlignment.Vertical, 2, 10));
                gen.Columns.Add(new PDFHeader("Line No.", iKandi.Common.ContentAlignment.Vertical, 2, 10));
                gen.Columns.Add(new PDFHeader("Contract No.", iKandi.Common.ContentAlignment.Vertical, 2, 10));
                gen.Columns.Add(new PDFHeader("Description", iKandi.Common.ContentAlignment.Vertical, 2, 10));
                gen.Columns.Add(new PDFHeader("Qty", iKandi.Common.ContentAlignment.Horizontal, 3));
                gen.Columns.Add(new PDFHeader("Fabric Details", ContentAlignment.Horizontal, 15));
                gen.Columns.Add(new PDFHeader("Total Greige", ContentAlignment.Horizontal, 6));
                gen.Columns.Add(new PDFHeader("Final Order Placed", ContentAlignment.Horizontal, 8));
                gen.Columns.Add(new PDFHeader("% Diff", ContentAlignment.Horizontal, 5));
                gen.Columns.Add(new PDFHeader("History", ContentAlignment.Horizontal, 40));
            }

            gen.Rows = new List<List<PDFCell>>();

            foreach (OrderDetail od in orderDetail)
            {
                if (od.ParentOrder.WorkflowInstanceDetail.StatusModeID != 24)
                {

                    List<PDFCell> row = new List<PDFCell>();
                    PDFCell cell;

                    if (Type != "Fabric Order Changes")
                    {
                        //for order Date 
                        if (Type == "Live Pending")
                        {
                            string orderDate = ((od.ParentOrder.OrderDate) == DateTime.MinValue) ? String.Empty : od.ParentOrder.OrderDate.ToString("dd MMM yy (ddd)");
                            cell = new PDFCell(orderDate, iKandi.Common.ContentAlignment.Horizontal);

                            cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                            cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                            row.Add(cell);
                        }

                        // For Style Number
                        cell = new PDFCell(od.ParentOrder.Style.StyleNumber, iKandi.Common.ContentAlignment.Horizontal);
                        cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                        cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                        row.Add(cell);
                    }

                    if (Type == "Packing" || Type == "Inline Cut" || Type == "Ex-Factory" || Type == "New Order" || Type == "New Order NonIkandi" || Type == "Stc UnAllocated" || Type == "Live" || Type == "Ex-Factories Planned" || Type == "Approved To Ex-Factory" || Type == "Part Ex-Factory" || Type == "Live Pending" || Type == "Pending Buying Samples")
                    {
                        // For Image
                        string ImagePath = od.ParentOrder.Style.SampleImageURL1;
                        cell = new PDFCell(string.Empty, iKandi.Common.ContentAlignment.Horizontal);
                        if (ImagePath != string.Empty)
                            cell.ImageUrl = Path.Combine(Constants.STYLE_FOLDER_PATH, "thumb-" + ImagePath);
                        row.Add(cell);

                        // For Serial Number
                        cell = new PDFCell(od.ParentOrder.SerialNumber + "\n" + "\n" + od.IsRepeatstr.ToUpper(), iKandi.Common.ContentAlignment.Horizontal, "NewOrderMail");
                        cell.FontColor = "#0000FF";
                        cell.BackGroundColor = Constants.GetSerialNumberColor(od.ExFactory);
                        cell.FontSize = 16;
                        cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                        cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                        row.Add(cell);

                        // For Line Number
                        cell = new PDFCell(od.LineItemNumber, iKandi.Common.ContentAlignment.Horizontal);
                        cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                        cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                        row.Add(cell);

                        // For Contract No
                        cell = new PDFCell(od.ContractNumber, iKandi.Common.ContentAlignment.Horizontal);
                        cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                        cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                        row.Add(cell);

                        if (Type == "New Order" || Type == "New Order NonIkandi" || Type == "Live" || Type == "Live Pending" || Type == "Pending Buying Samples")
                        {
                            // For Fabric Detail

                            string Fabric1 = od.Fabric1;
                            string Fabric1Detail = od.Fabric1Details.ToString().Trim();
                            int Fabric1Percent = od.ParentOrder.FabricInhouseHistory.Fabric1Percent;

                            if (Fabric1Detail != "")
                            {
                                Fabric1 = Fabric1 + " : " + Fabric1Detail;
                            }

                            if (Fabric1Percent != 0)
                            {
                                Fabric1 = Fabric1 + " (" + Fabric1Percent + "%)";
                            }

                            string Fabric2 = od.Fabric2;
                            string Fabric2Detail = od.Fabric2Details.ToString().Trim();
                            int Fabric2Percent = od.ParentOrder.FabricInhouseHistory.Fabric2Percent;

                            if (Fabric2Detail != "")
                            {
                                Fabric2 = Fabric2 + " : " + Fabric2Detail;
                            }

                            if (Fabric2Percent != 0)
                            {
                                Fabric2 = Fabric2 + " (" + Fabric2Percent + "%)";
                            }

                            string Fabric3 = od.Fabric3;
                            string Fabric3Detail = od.Fabric3Details.ToString().Trim();
                            int Fabric3Percent = od.ParentOrder.FabricInhouseHistory.Fabric3Percent;

                            if (Fabric3Detail != "")
                            {
                                Fabric3 = Fabric3 + " : " + Fabric3Detail;
                            }

                            if (Fabric3Percent != 0)
                            {
                                Fabric3 = Fabric3 + " (" + Fabric3Percent + "%)";
                            }

                            string Fabric4 = od.Fabric4;
                            string Fabric4Detail = od.Fabric4Details.ToString().Trim();
                            int Fabric4Percent = od.ParentOrder.FabricInhouseHistory.Fabric4Percent;

                            if (Fabric4Detail != "")
                            {
                                Fabric4 = Fabric4 + " : " + Fabric4Detail;
                            }

                            if (Fabric4Percent != 0)
                            {
                                Fabric4 = Fabric4 + " (" + Fabric4Percent + "%)";
                            }

                            cell = new PDFCell(Fabric1 + "\n" + "\n" + Fabric2 + "\n" + "\n" + Fabric3 + "\n" + "\n" + Fabric4, iKandi.Common.ContentAlignment.Horizontal);
                            cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
                            cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                            cell.BackGroundColor = Constants.GetPercentageColor(Fabric1Percent);
                            row.Add(cell);
                        }

                        //For Quantity
                        cell = new PDFCell(od.Quantity.ToString("N0"), iKandi.Common.ContentAlignment.Horizontal);
                        cell.FontSize = 16;
                        cell.FontColor = "#0000FF";
                        cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                        cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                        row.Add(cell);

                        // For Mode
                        cell = new PDFCell(od.ModeName, iKandi.Common.ContentAlignment.Horizontal);
                        //cell.BackGroundColor = iKandi.BLL.CommonHelper.GetDeliveryModeColor(od.Mode);
                        cell.BackGroundColor = iKandi.BLL.CommonHelper.GetDeliveryModeColor(od.Mode);
                        cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                        cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                        row.Add(cell);

                        // for Ex-Factory
                        string ExFactory = ((od.ExFactory) == DateTime.MinValue) ? String.Empty : od.ExFactory.ToString("dd MMM yy (ddd)");
                        cell = new PDFCell(ExFactory, iKandi.Common.ContentAlignment.Horizontal);
                        cell.FontSize = 16;
                        cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                        cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                        cell.BackGroundColor = iKandi.BLL.CommonHelper.GetExFactoryColor(od.ExFactory, od.DC, od.Mode);
                        row.Add(cell);
                        //abhishek
                        // For Status
                        //cell = new PDFCell(od.ParentOrder.WorkflowInstanceDetail.StatusMode, iKandi.Common.ContentAlignment.Horizontal);
                        //cell.BackGroundColor = Constants.GetStatusModeColor(od.ParentOrder.WorkflowInstanceDetail.StatusModeID);
                        //cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                        //cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                        //row.Add(cell);

                        cell = new PDFCell(od.ParentOrder.Style.DepartmentName, iKandi.Common.ContentAlignment.Horizontal);
                        //cell.BackGroundColor = Constants.GetStatusModeColor(od.ParentOrder.WorkflowInstanceDetail.StatusModeID);
                        cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                        cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                        row.Add(cell);

                        if (Type == "Pending Buying Samples")
                        {
                            string DueDate = ((od.ParentOrder.Style.DueDate) == DateTime.MinValue) ? String.Empty : od.ParentOrder.Style.DueDate.ToString("dd MMM yy (ddd)");
                            cell = new PDFCell(DueDate, iKandi.Common.ContentAlignment.Horizontal);
                            cell.FontSize = 16;
                            cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                            cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                            row.Add(cell);
                        }
                    }

                    else if (Type == "Top Requseted" || Type == "PP Meeting Pending" || Type == "Inline Not Cut Today")
                    {
                        // For Image
                        string ImagePath = od.ParentOrder.Style.SampleImageURL1;
                        cell = new PDFCell(string.Empty, iKandi.Common.ContentAlignment.Horizontal);
                        if (ImagePath != string.Empty)
                            cell.ImageUrl = Path.Combine(Constants.STYLE_FOLDER_PATH, "thumb-" + ImagePath);
                        row.Add(cell);

                        // For Serial Number
                        cell = new PDFCell(od.ParentOrder.SerialNumber, iKandi.Common.ContentAlignment.Vertical);
                        cell.FontColor = "#0000FF";
                        cell.BackGroundColor = Constants.GetSerialNumberColor(od.ExFactory);
                        cell.FontSize = 16;
                        cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                        cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                        row.Add(cell);

                        // For Line Number
                        cell = new PDFCell(od.LineItemNumber, iKandi.Common.ContentAlignment.Vertical);
                        cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                        cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                        row.Add(cell);

                        // For Contract No
                        cell = new PDFCell(od.ContractNumber, iKandi.Common.ContentAlignment.Vertical);
                        cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                        cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                        row.Add(cell);

                        //For Quantity
                        cell = new PDFCell(od.Quantity.ToString("N0"), iKandi.Common.ContentAlignment.Horizontal);
                        cell.FontSize = 16;
                        cell.FontColor = "#0000FF";
                        cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                        cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                        row.Add(cell);

                        // For Mode
                        cell = new PDFCell(od.ModeName, iKandi.Common.ContentAlignment.Vertical);
                        cell.BackGroundColor = iKandi.BLL.CommonHelper.GetDeliveryModeColor(od.Mode);
                        cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                        cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                        row.Add(cell);

                        // for Ex-Factory
                        string ExFactory = ((od.ExFactory) == DateTime.MinValue) ? String.Empty : od.ExFactory.ToString("dd MMM yy (ddd)");
                        cell = new PDFCell(ExFactory, iKandi.Common.ContentAlignment.Horizontal);
                        cell.FontSize = 16;
                        cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                        cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                        cell.BackGroundColor = iKandi.BLL.CommonHelper.GetExFactoryColor(od.ExFactory, od.DC, od.Mode);
                        row.Add(cell);

                        // For Status
                        cell = new PDFCell(od.ParentOrder.WorkflowInstanceDetail.StatusMode, iKandi.Common.ContentAlignment.Vertical);
                        cell.BackGroundColor = Constants.GetStatusModeColor(od.ParentOrder.WorkflowInstanceDetail.StatusModeID);
                        cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                        cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                        row.Add(cell);

                        if (Type == "PP Meeting Pending" || Type == "Inline Not Cut Today")
                        {
                            //for Unit Name
                            cell = new PDFCell(od.Unit.FactoryName, iKandi.Common.ContentAlignment.Vertical);
                            cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                            cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                            row.Add(cell);
                        }

                        // For Seal date
                        string sealDate = ((od.ParentOrder.Fits.SealDate) == DateTime.MinValue) ? String.Empty : od.ParentOrder.Fits.SealDate.ToString("dd MMM yy (ddd)");
                        cell = new PDFCell(sealDate, iKandi.Common.ContentAlignment.Vertical);
                        cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                        cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                        row.Add(cell);

                        if (Type != "Top Requseted")
                        {
                            // For Fabric Detail
                            string Fabric1 = od.Fabric1;
                            string Fabric1Detail = od.Fabric1Details.ToString().Trim();
                            int Fabric1Percent = od.ParentOrder.FabricInhouseHistory.Fabric1Percent;

                            if (Fabric1Detail != "")
                            {
                                Fabric1 = Fabric1 + " : " + Fabric1Detail;
                            }

                            if (Fabric1Percent != 0)
                            {
                                Fabric1 = Fabric1 + " (" + Fabric1Percent + "%)";
                            }

                            string Fabric2 = od.Fabric2;
                            string Fabric2Detail = od.Fabric2Details.ToString().Trim();
                            int Fabric2Percent = od.ParentOrder.FabricInhouseHistory.Fabric2Percent;

                            if (Fabric2Detail != "")
                            {
                                Fabric2 = Fabric2 + " : " + Fabric2Detail;
                            }

                            if (Fabric2Percent != 0)
                            {
                                Fabric2 = Fabric2 + " (" + Fabric2Percent + "%)";
                            }


                            string Fabric3 = od.Fabric3;
                            string Fabric3Detail = od.Fabric3Details.ToString().Trim();
                            int Fabric3Percent = od.ParentOrder.FabricInhouseHistory.Fabric3Percent;

                            if (Fabric3Detail != "")
                            {
                                Fabric3 = Fabric3 + " : " + Fabric3Detail;
                            }

                            if (Fabric3Percent != 0)
                            {
                                Fabric3 = Fabric3 + " (" + Fabric3Percent + "%)";
                            }

                            string Fabric4 = od.Fabric4;
                            string Fabric4Detail = od.Fabric4Details.ToString().Trim();
                            int Fabric4Percent = od.ParentOrder.FabricInhouseHistory.Fabric4Percent;

                            if (Fabric4Detail != "")
                            {
                                Fabric4 = Fabric4 + " : " + Fabric4Detail;
                            }

                            if (Fabric4Percent != 0)
                            {
                                Fabric4 = Fabric4 + " (" + Fabric4Percent + "%)";
                            }

                            cell = new PDFCell(Fabric1 + "\n" + "\n" + Fabric2 + "\n" + "\n" + Fabric3 + "\n" + "\n" + Fabric4, iKandi.Common.ContentAlignment.Horizontal);
                            cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
                            cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                            cell.BackGroundColor = Constants.GetPercentageColor(Fabric1Percent);
                            row.Add(cell);

                            // For Accessories
                            string AccessaryHistory = (Convert.ToString(od.AccessoryHistory) == null) ? "" : od.AccessoryHistory.ToString();
                            cell = new PDFCell(AccessaryHistory.Replace("<br/><br/>", "\n"), iKandi.Common.ContentAlignment.Horizontal);
                            cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
                            cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;

                            row.Add(cell);
                        }

                        if (Type == "Inline Not Cut Today")
                        {
                            // For Inline Cut Target                                       
                            string complitionTgt = ((od.InlineCut) == DateTime.MinValue) ? String.Empty : od.InlineCut.ToString("dd MMM yy (ddd)");
                            cell = new PDFCell(complitionTgt, iKandi.Common.ContentAlignment.Horizontal);
                            cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                            cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                            cell.FontSize = 16;
                            row.Add(cell);
                        }

                        if (Type != "Inline Not Cut Today")
                        {
                            // For Complition Target                                       
                            string complitionTgt = ((od.CuttingETA) == DateTime.MinValue) ? String.Empty : od.CuttingETA.ToString("dd MMM yy (ddd)");
                            cell = new PDFCell(complitionTgt, iKandi.Common.ContentAlignment.Vertical);
                            cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                            cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                            row.Add(cell);

                            // For Completed                                                    
                            string completed = ((od.ParentOrder.CuttingHistory.Date) == DateTime.MinValue) ? String.Empty : od.ParentOrder.CuttingHistory.Date.ToString("dd MMM yy (ddd)");
                            cell = new PDFCell(completed, iKandi.Common.ContentAlignment.Vertical);
                            cell.BackGroundColor = Constants.GetActualDateColor(od.CuttingETA, od.ParentOrder.CuttingHistory.Date);
                            cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                            cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                            row.Add(cell);

                            // ForPcs Cut
                            cell = new PDFCell(od.ParentOrder.CuttingDetail.PcsCut.ToString("N0"), iKandi.Common.ContentAlignment.Vertical);
                            cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                            cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                            cell.FontColor = "#0000ff";
                            row.Add(cell);

                            // For % cut
                            cell = new PDFCell(od.ParentOrder.CuttingDetail.PercentagePcsCut.ToString("N0") + "%", iKandi.Common.ContentAlignment.Vertical);
                            cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                            cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                            cell.BackGroundColor = Constants.GetPercentageColor(od.ParentOrder.CuttingDetail.PercentagePcsCut);
                            row.Add(cell);

                            // For Pcs to Be Cut
                            cell = new PDFCell(od.ParentOrder.CuttingDetail.PcsToBeCut.ToString("N0"), iKandi.Common.ContentAlignment.Vertical);
                            cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                            cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                            row.Add(cell);

                            // For Pcs Issued
                            cell = new PDFCell(od.ParentOrder.CuttingDetail.PcsIssued.ToString("N0"), iKandi.Common.ContentAlignment.Vertical);
                            cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                            cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                            row.Add(cell);

                            // For Bal In House
                            cell = new PDFCell(od.ParentOrder.CuttingDetail.BalanceInHouse.ToString("N0"), iKandi.Common.ContentAlignment.Vertical);
                            cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                            cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                            row.Add(cell);

                            // For Inline 
                            string inline = ((od.ParentOrder.Style.InLineCutDate) == DateTime.MinValue) ? String.Empty : od.ParentOrder.Style.InLineCutDate.ToString("dd MMM yy (ddd)");
                            cell = new PDFCell(inline, iKandi.Common.ContentAlignment.Vertical);
                            cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                            cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                            row.Add(cell);

                            // For TopSend Tgt.
                            string topSentTgt = ((od.ParentOrder.InlinePPMOrderContract.TopSentTarget) == DateTime.MinValue) ? String.Empty : od.ParentOrder.InlinePPMOrderContract.TopSentTarget.ToString("dd MMM yy (ddd)");
                            cell = new PDFCell(topSentTgt, iKandi.Common.ContentAlignment.Vertical);
                            cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                            cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                            row.Add(cell);

                            //For Sent
                            string sent = ((od.ParentOrder.InlinePPMOrderContract.TopSentActual) == DateTime.MinValue) ? String.Empty : od.ParentOrder.InlinePPMOrderContract.TopSentActual.ToString("dd MMM yy (ddd)");
                            cell = new PDFCell(sent, iKandi.Common.ContentAlignment.Vertical);
                            cell.BackGroundColor = Constants.GetActualDateColor(od.ParentOrder.InlinePPMOrderContract.TopSentTarget, od.ParentOrder.InlinePPMOrderContract.TopSentActual);
                            cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                            cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                            row.Add(cell);
                        }
                    }

                    if (Type == "Stc UnAllocated")
                    {
                        // For Seal date
                        string sealDate = ((od.ParentOrder.Fits.SealDate) == DateTime.MinValue) ? String.Empty : od.ParentOrder.Fits.SealDate.ToString("dd MMM yy (ddd)");
                        cell = new PDFCell(sealDate, iKandi.Common.ContentAlignment.Vertical);
                        cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                        cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                        row.Add(cell);

                        // For Fabric Detail
                        string Fabric1 = od.Fabric1;
                        string Fabric1Detail = od.Fabric1Details.ToString().Trim();
                        int Fabric1Percent = od.ParentOrder.FabricInhouseHistory.Fabric1Percent;

                        if (Fabric1Detail != "")
                        {
                            Fabric1 = Fabric1 + " : " + Fabric1Detail;
                        }

                        if (Fabric1Percent != 0)
                        {
                            Fabric1 = Fabric1 + " (" + Fabric1Percent + "%)";
                        }

                        string Fabric2 = od.Fabric2;
                        string Fabric2Detail = od.Fabric2Details.ToString().Trim();
                        int Fabric2Percent = od.ParentOrder.FabricInhouseHistory.Fabric2Percent;

                        if (Fabric2Detail != "")
                        {
                            Fabric2 = Fabric2 + " : " + Fabric2Detail;
                        }

                        if (Fabric2Percent != 0)
                        {
                            Fabric2 = Fabric2 + " (" + Fabric2Percent + "%)";
                        }

                        string Fabric3 = od.Fabric3;
                        string Fabric3Detail = od.Fabric3Details.ToString().Trim();
                        int Fabric3Percent = od.ParentOrder.FabricInhouseHistory.Fabric3Percent;

                        if (Fabric3Detail != "")
                        {
                            Fabric3 = Fabric3 + " : " + Fabric3Detail;
                        }

                        if (Fabric3Percent != 0)
                        {
                            Fabric3 = Fabric3 + " (" + Fabric3Percent + "%)";
                        }

                        string Fabric4 = od.Fabric4;
                        string Fabric4Detail = od.Fabric4Details.ToString().Trim();
                        int Fabric4Percent = od.ParentOrder.FabricInhouseHistory.Fabric4Percent;

                        if (Fabric4Detail != "")
                        {
                            Fabric4 = Fabric4 + " : " + Fabric4Detail;
                        }

                        if (Fabric4Percent != 0)
                        {
                            Fabric4 = Fabric4 + " (" + Fabric4Percent + "%)";
                        }

                        cell = new PDFCell(Fabric1 + "\n" + "\n" + Fabric2 + "\n" + "\n" + Fabric3 + "\n" + "\n" + Fabric4, iKandi.Common.ContentAlignment.Horizontal);
                        cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
                        cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                        cell.BackGroundColor = Constants.GetPercentageColor(Fabric1Percent);
                        row.Add(cell);

                        // For Accessories
                        string AccessaryHistory = (Convert.ToString(od.AccessoryHistory) == null) ? "" : od.AccessoryHistory.ToString();
                        cell = new PDFCell(AccessaryHistory.Replace("<br/><br/>", "\n"), iKandi.Common.ContentAlignment.Horizontal);
                        cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
                        cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;

                        row.Add(cell);
                    }

                    if (Type == "Top Requseted")
                    {
                        //for Unit Name
                        cell = new PDFCell(od.Unit.FactoryName, iKandi.Common.ContentAlignment.Vertical);
                        cell.BackGroundColor = od.Unit.ProductionUnitColor.ToString();
                        cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                        cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                        row.Add(cell);

                        // For Sealer Remarks Remarks Bipl
                        string accRemarks = "";

                        if (od.Remarks.ToString().LastIndexOf("$$") > -1)
                        {
                            accRemarks = od.Remarks.ToString().Substring(od.Remarks.ToString().LastIndexOf("$$") + 2);
                        }
                        else
                        {
                            accRemarks = od.Remarks.ToString();
                        }
                        cell = new PDFCell(accRemarks, iKandi.Common.ContentAlignment.Horizontal);
                        cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
                        cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                        row.Add(cell);

                        // For Fits remarks 
                        string fitsRemmarks = "";

                        if (od.ParentOrder.Fits.Comments.ToString().LastIndexOf("$$") > -1)
                        {
                            fitsRemmarks = od.ParentOrder.Fits.Comments.ToString().Substring(od.ParentOrder.Fits.Comments.ToString().LastIndexOf("$$") + 2);
                        }
                        else
                        {
                            fitsRemmarks = od.ParentOrder.Fits.Comments.ToString();
                        }
                        cell = new PDFCell(fitsRemmarks, iKandi.Common.ContentAlignment.Horizontal);
                        cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
                        cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                        row.Add(cell);

                        // For Production Remarks Remarks Bipl
                        string prodRemarks = "";

                        if (od.ParentOrder.StitchingDetail.ProdRemarks.ToString().LastIndexOf("$$") > -1)
                        {
                            prodRemarks = od.ParentOrder.StitchingDetail.ProdRemarks.ToString().Substring(od.ParentOrder.StitchingDetail.ProdRemarks.ToString().LastIndexOf("$$") + 2);
                        }
                        else
                        {
                            prodRemarks = od.ParentOrder.StitchingDetail.ProdRemarks.ToString();
                        }
                        cell = new PDFCell(prodRemarks, iKandi.Common.ContentAlignment.Horizontal);
                        cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
                        cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                        row.Add(cell);
                    }

                    if (Type != "New Order" && Type != "New Order NonIkandi" && Type != "Stc UnAllocated" && Type != "PP Meeting Pending" && Type != "Live" && Type != "Top Requseted" && Type != "Fabric Order Changes" && Type != "Approved To Ex-Factory" && Type != "Live Pending" && Type != "Inline Not Cut Today" && Type != "Pending Buying Samples")
                    {
                        //for Unit
                        cell = new PDFCell(od.Unit.FactoryCode, iKandi.Common.ContentAlignment.Vertical);
                        cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                        cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                        row.Add(cell);
                    }

                    if (Type == "Ex-Factories Planned" || Type == "Approved To Ex-Factory")
                    {
                        // For Planned Ex-Date
                        string plannedEx = ((od.PlannedEx) == DateTime.MinValue) ? String.Empty : od.PlannedEx.ToString("dd MMM yy (ddd)");
                        cell = new PDFCell(plannedEx, iKandi.Common.ContentAlignment.Horizontal);
                        cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                        cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                        row.Add(cell);

                        if (Type == "Approved To Ex-Factory")
                        {
                            // For Shipping Quantity
                            cell = new PDFCell(od.ParentOrder.ProductionPlanning.ShipmentQty.ToString("N0"), iKandi.Common.ContentAlignment.Horizontal);
                            cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                            cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                            cell.FontColor = "#F42727";
                            cell.FontSize = 16;

                            row.Add(cell);
                        }
                    }

                    if (Type == "Fabric Order Changes")
                    {
                        cell = new PDFCell(od.ParentOrder.OrderDate.ToString("dd MMM yy (ddd)"), iKandi.Common.ContentAlignment.Vertical);
                        cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                        cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                        row.Add(cell);

                        cell = new PDFCell(od.ParentOrder.SerialNumber, iKandi.Common.ContentAlignment.Vertical);
                        cell.FontColor = "#0000FF";
                        cell.BackGroundColor = Constants.GetSerialNumberColor(od.ExFactory);
                        cell.FontSize = 16;
                        cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                        cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                        row.Add(cell);

                        cell = new PDFCell(od.ParentOrder.DepartmentName, iKandi.Common.ContentAlignment.Vertical);
                        cell.FontSize = 16;
                        cell.FontColor = "#0000FF";
                        cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                        cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                        row.Add(cell);

                        cell = new PDFCell(od.ParentOrder.Style.StyleNumber, iKandi.Common.ContentAlignment.Vertical);
                        cell.FontSize = 16;
                        cell.FontColor = "#0000FF";
                        cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                        cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                        row.Add(cell);

                        cell = new PDFCell(od.LineItemNumber, iKandi.Common.ContentAlignment.Vertical);
                        cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                        cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                        row.Add(cell);

                        cell = new PDFCell(od.ContractNumber, iKandi.Common.ContentAlignment.Vertical);
                        cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                        cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                        row.Add(cell);

                        cell = new PDFCell(od.Description, iKandi.Common.ContentAlignment.Vertical);
                        cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                        cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                        row.Add(cell);

                        cell = new PDFCell(od.Quantity.ToString("N0"), iKandi.Common.ContentAlignment.Horizontal);
                        cell.FontSize = 16;
                        cell.FontColor = "#0000FF";
                        cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                        cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                        row.Add(cell);

                        string Fabric1 = od.Fabric1;
                        string Fabric1Detail = od.Fabric1Details.ToString().Trim();

                        if (Fabric1Detail != "")
                        {
                            Fabric1 = Fabric1 + " : " + Fabric1Detail;
                        }

                        string Fabric2 = od.Fabric2;
                        string Fabric2Detail = od.Fabric2Details.ToString().Trim();

                        if (Fabric2Detail != "")
                        {
                            Fabric2 = Fabric2 + " : " + Fabric2Detail;
                        }

                        string Fabric3 = od.Fabric3;
                        string Fabric3Detail = od.Fabric3Details.ToString().Trim();

                        if (Fabric3Detail != "")
                        {
                            Fabric3 = Fabric3 + " : " + Fabric3Detail;
                        }

                        string Fabric4 = od.Fabric4;
                        string Fabric4Detail = od.Fabric4Details.ToString().Trim();

                        if (Fabric4Detail != "")
                        {
                            Fabric4 = Fabric4 + " : " + Fabric4Detail;
                        }

                        cell = new PDFCell(Fabric1 + "\n" + "\n" + Fabric2 + "\n" + "\n" + Fabric3 + "\n" + "\n" + Fabric4, iKandi.Common.ContentAlignment.Horizontal);
                        cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
                        cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                        row.Add(cell);

                        string Fabric1Greige = od.ParentOrder.FabricWorking.Fabric1Greige.ToString("N0");
                        if (Fabric1Greige == "0")
                            Fabric1Greige = string.Empty;

                        string Fabric2Greige = od.ParentOrder.FabricWorking.Fabric2Greige.ToString("N0");
                        if (Fabric2Greige == "0")
                            Fabric2Greige = string.Empty;

                        string Fabric3Greige = od.ParentOrder.FabricWorking.Fabric3Greige.ToString("N0");
                        if (Fabric3Greige == "0")
                            Fabric3Greige = string.Empty;

                        string Fabric4Greige = od.ParentOrder.FabricWorking.Fabric4Greige.ToString("N0");
                        if (Fabric4Greige == "0")
                            Fabric4Greige = string.Empty;

                        cell = new PDFCell(Fabric1Greige + "\n" + "\n" + Fabric2Greige + "\n" + "\n" + Fabric3Greige + "\n" + "\n" + Fabric4Greige, iKandi.Common.ContentAlignment.Horizontal);
                        cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
                        cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                        row.Add(cell);

                        string Fabric1Final = od.ParentOrder.FabricWorking.Fabric1FinalOrder.ToString("N0");
                        if (Fabric1Final == "0")
                            Fabric1Final = string.Empty;

                        string Fabric2Final = od.ParentOrder.FabricWorking.Fabric2FinalOrder.ToString("N0");
                        if (Fabric2Final == "0")
                            Fabric2Final = string.Empty;

                        string Fabric3Final = od.ParentOrder.FabricWorking.Fabric3FinalOrder.ToString("N0");
                        if (Fabric3Final == "0")
                            Fabric3Final = string.Empty;

                        string Fabric4Final = od.ParentOrder.FabricWorking.Fabric4FinalOrder.ToString("N0");
                        if (Fabric4Final == "0")
                            Fabric4Final = string.Empty;

                        cell = new PDFCell(Fabric1Final + "\n" + "\n" + Fabric2Final + "\n" + "\n" + Fabric3Final + "\n" + "\n" + Fabric4Final, iKandi.Common.ContentAlignment.Horizontal);
                        cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
                        cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                        row.Add(cell);

                        decimal diff1 = 0;
                        decimal diff2 = 0;
                        decimal diff3 = 0;
                        decimal diff4 = 0;
                        String Diff1 = string.Empty;
                        String Diff2 = string.Empty;
                        String Diff3 = string.Empty;
                        String Diff4 = string.Empty;

                        if (!string.IsNullOrEmpty(Fabric1Final) && !string.IsNullOrEmpty(Fabric1Greige))
                            diff1 = ((Convert.ToDecimal(Fabric1Final.Replace(",", "")) - Convert.ToDecimal(Fabric1Greige.Replace(",", ""))) / Convert.ToDecimal(Fabric1Greige.Replace(",", ""))) * 100;
                        if (!string.IsNullOrEmpty(Fabric2Final) && !string.IsNullOrEmpty(Fabric2Greige))
                            diff2 = ((Convert.ToDecimal(Fabric2Final.Replace(",", "")) - Convert.ToDecimal(Fabric2Greige.Replace(",", ""))) / Convert.ToDecimal(Fabric2Greige.Replace(",", ""))) * 100;
                        if (!string.IsNullOrEmpty(Fabric3Final) && !string.IsNullOrEmpty(Fabric3Greige))
                            diff3 = ((Convert.ToDecimal(Fabric3Final.Replace(",", "")) - Convert.ToDecimal(Fabric3Greige.Replace(",", ""))) / Convert.ToDecimal(Fabric3Greige.Replace(",", ""))) * 100;
                        if (!string.IsNullOrEmpty(Fabric4Final) && !string.IsNullOrEmpty(Fabric4Greige))
                            diff4 = ((Convert.ToDecimal(Fabric4Final.Replace(",", "")) - Convert.ToDecimal(Fabric4Greige.Replace(",", ""))) / Convert.ToDecimal(Fabric4Greige.Replace(",", ""))) * 100;

                        if (Convert.ToInt32(diff1) != 0)
                            Diff1 = (Convert.ToInt32(diff1)).ToString() + "%";
                        else
                            Diff1 = String.Empty;

                        if (Convert.ToInt32(diff2) != 0)
                            Diff2 = (Convert.ToInt32(diff2)).ToString() + "%";
                        else
                            Diff2 = String.Empty;

                        if (Convert.ToInt32(diff3) != 0)
                            Diff3 = (Convert.ToInt32(diff3)).ToString() + "%";
                        else
                            Diff3 = String.Empty;

                        if (Convert.ToInt32(diff4) != 0)
                            Diff4 = (Convert.ToInt32(diff4)).ToString() + "%";
                        else
                            Diff4 = String.Empty;

                        cell = new PDFCell(Diff1 + "\n" + "\n" + Diff2 + "\n" + "\n" + Diff3 + "\n" + "\n" + Diff4, iKandi.Common.ContentAlignment.Horizontal);
                        cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                        cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                        row.Add(cell);

                        string History = string.Empty;
                        if (od.ParentOrder.FabricWorking.History.IndexOf(DateTime.Today.ToString("dd MMM yy (ddd)")) > -1)
                            History = od.ParentOrder.FabricWorking.History.Substring(od.ParentOrder.FabricWorking.History.IndexOf(DateTime.Today.ToString("dd MMM yy (ddd)")));
                        cell = new PDFCell(History.Replace("<br/><br/>", "\n").Replace("<br/>", "\n"), iKandi.Common.ContentAlignment.Horizontal);
                        cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
                        cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                        row.Add(cell);

                    }

                    if (Type == "Ex-Factory" || Type == "Ex-Factories Planned" || Type == "Part Ex-Factory")
                    {
                        // For Shipping Quantity
                        cell = new PDFCell(od.ParentOrder.ProductionPlanning.ShipmentQty.ToString("N0"), iKandi.Common.ContentAlignment.Horizontal);
                        cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                        cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                        cell.FontColor = "#0000FF";
                        cell.FontSize = 16;
                        row.Add(cell);
                    }
                    gen.Rows.Add(row);
                }
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




        //public string GetPrint(string stylenumber, int styleid, int strClientId, int DepartmentId, int CreateNew, int NewRef, int ReUse, int ReUseStyleId, string RemarksType)
        //{

        //    string fileName = "HOPPM Report -" + DateTime.Now.ToString("dd MMM yyy") + ".pdf";
        //    try
        //    {

        //        if (!Directory.Exists(Constants.TEMP_FOLDER_PATH))
        //            Directory.CreateDirectory(Constants.TEMP_FOLDER_PATH);

        //        string pdfFilePath = Path.Combine(Constants.TEMP_FOLDER_PATH, fileName);

        //        OrderController OrderControllerInstance = new OrderController();


        //        iKandi.BLL.OrderProcessController ordProcess = new OrderProcessController();
        //        string strUserID = "";
        //        DataSet dsgrd = new DataSet();
        //        dsgrd = ordProcess.GetHOPPMRemarks(stylenumber, styleid, strClientId, DepartmentId, CreateNew, NewRef, ReUse, ReUseStyleId, RemarksType);
        //        Color HeaderColor = new Color(System.Drawing.ColorTranslator.FromHtml("#FAFCFF"));
        //        Color BorderColor = new Color(System.Drawing.ColorTranslator.FromHtml("#A9A9A9"));

        //        PDFTableGenerator gen = new PDFTableGenerator(pdfFilePath, "HOPPM Report");

        //        gen.IsHeaderTable = true; // To determind weather a table before main grid is added
        //        gen.HeaderTableBodyHeight = 30;
        //        gen.HeaderTableHeaderHeight = 30;
        //        gen.CellBorderColor = "#A9A9A9";

        //        string ClientName = string.Empty;
        //        gen.HeaderTableColumns = new List<PDFHeader>();

        //        try
        //        {

        //            gen.HeaderTableRows = new List<List<PDFCell>>();   
        //            List<PDFCell> headerTableRow = new List<PDFCell>();  

        //            PDFCell headerCell = new PDFCell("BASIC INFORMATION: [DR 61859 C MOTHERCARE Second_Eid]", iKandi.Common.ContentAlignment.Horizontal); 
        //            headerCell.FontColor = "#0000FF";
        //            headerCell.FontSize = 15;
        //            headerCell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
        //            headerCell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
        //            headerTableRow.Add(headerCell);


        //            gen.HeaderTableRows.Add(headerTableRow); 



        //            gen.Columns = new List<PDFHeader>(); 

        //            gen.Rows = new List<List<PDFCell>>();           
        //            List<PDFCell> row = new List<PDFCell>();

        //            PDFCell cell = new PDFCell("", iKandi.Common.ContentAlignment.Horizontal, "");


        //            string Section = "SL";
        //            cell = new PDFCell(Section, iKandi.Common.ContentAlignment.Horizontal, "");
        //            cell.FontSize = 9;
        //            cell.BackGroundColor = "#f9f9fa";
        //            cell.FontColor = "#B2BDDD";
        //            cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
        //            cell.Height = 20;
        //            row.Add(cell);


        //            string Section2 = "Remarks";
        //            cell = new PDFCell(Section2, iKandi.Common.ContentAlignment.Horizontal, "");
        //            cell.FontSize = 9;
        //            cell.BackGroundColor = "#f9f9fa";
        //            cell.FontColor = "#B2BDDD";
        //            cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
        //            cell.Height = 20;
        //            row.Add(cell);

        //            gen.Rows.Add(row);


        //            //foreach (MOOrderDetails orderDetail in OrderDetail)
        //            //{ 
        //            for (int i = 0; i < dsgrd.Tables[0].Rows.Count; i++)
        //            {
        //                try
        //                {

        //                    List<PDFCell> PDFRow = new List<PDFCell>();
        //                    PdfPTable ptTable;
        //                    ptTable = new PdfPTable(6) { WidthPercentage = 100 };

        //                    var PDFHeaderPhrase = new Phrase();
        //                    PDFHeaderPhrase.Add(Chunk.NEWLINE);


        //                    var BIHAccess = "";
        //                    BIHAccess = "B.I.H : " + DateTime.Now.ToString("dd MMM yy (ddd)");

        //                    var PDFHeaderFont = FontFactory.GetFont("trebuchet ms", 17, Font.BOLD, AccessForeColor);
        //                    PDFHeaderPhrase.Add(new Chunk(BIHAccess, PDFHeaderFont));
        //                    Color bAccesscolor = new Color(System.Drawing.ColorTranslator.FromHtml("#000000"));
        //                    ptTable.AddCell(new PdfPCell(PDFHeaderPhrase) { Colspan = 6, BorderColor = BorderColor, BackgroundColor = AccessBackColor, HorizontalAlignment = Element.ALIGN_CENTER, FixedHeight = 40, VerticalAlignment = Element.ALIGN_TOP, PaddingBottom = 5 });
        //                    PDFHeaderPhrase.Add(Chunk.NEWLINE);


        //                    float[] columnWidths = new float[] { 20f, 11f, 26f, 10f, 10f, 26f };
        //                    ptTable.SetWidths(columnWidths);

        //                    PDFCell PDFCell = new PDFCell(ptTable);
        //                    PDFRow.Add(PDFCell);
        //                    gen.Rows.Add(PDFRow);

        //                    // Accessories Section End
        //                }
        //                catch (Exception ex)
        //                {
        //                }

        //                //}
        //            }

        //            gen.GeneratePDF_MO(); // Method which makes the Pdf 

        //        }
        //        catch (Exception ex)
        //        {

        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //    }
        //    return fileName;



        //} 

        //public HttpServerUtility Server { get; }
        //added by abhishek on 20/10/2015
        public string GetPrintHoppm_ppmform(string stylenumber, int styleid, int strClientId, int DepartmentId, int CreateNew, int NewRef, int ReUse, int ReUseStyleId, string RemarksType)
        {

            //string fileName = "HOPPM ReportTest -" + DateTime.Now.ToString("dd MMM yyy hh-mm-ss") + ".pdf";
            string fileName = "PP Meeting Form " + stylenumber + DateTime.Now.ToString("dd MMM yyy hh-mm-ss") + ".pdf";
            String FitsFolderPath = "~/" + System.Configuration.ConfigurationManager.AppSettings["InlinePPM.Docs.folder"];
            iKandi.BLL.OrderProcessController obj_ProcessController = new BLL.OrderProcessController();
            string BasicInformation = "";
            if (!Directory.Exists(Constants.TEMP_FOLDER_PATH))
                Directory.CreateDirectory(Constants.TEMP_FOLDER_PATH);

            string pdfFilePath = Path.Combine(Constants.TEMP_FOLDER_PATH, fileName);
            try
            {
                // string imagepath = HttpServerUtility.MapPath("~/App_Themes/ikandi/images/new-boutique-logo.png");


                Document document = new Document();
                PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(pdfFilePath, FileMode.Create));
                document.Open();

                DataTable dtStyleDetails = new DataTable();
                dtStyleDetails = obj_ProcessController.GetStyleNumber(styleid);


                string Serial = "";
                string ContractNumber = "";
                if (dtStyleDetails.Rows.Count > 0)
                {

                    for (int i = 0; i < dtStyleDetails.Rows.Count; i++)
                    {
                        if (dtStyleDetails.Rows[i]["SerialNumber"].ToString() != "")
                        {
                            Serial = Serial + dtStyleDetails.Rows[i]["SerialNumber"].ToString() + ",";
                        }
                        ContractNumber = ContractNumber + dtStyleDetails.Rows[i]["ContractNumber"].ToString() + ",";
                    }

                    Serial = Serial.TrimEnd(',');
                    ContractNumber = ContractNumber.TrimEnd(',');
                }

                //string ImageName = orderDetail.ParentOrder.Style.SampleImageURL1;
                string ImageName = dtStyleDetails.Rows[0]["SampleImageURL1"].ToString();

                if (File.Exists(HttpContext.Current.Server.MapPath("~/Uploads/Style/thumb-" + ImageName)))
                {
                    iTextSharp.text.Image gif = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath("~/Uploads/Style/thumb-" + ImageName));
                    gif.ScalePercent(20f);
                    gif.ScaleAbsolute(60f, 100.5f);
                    gif.SetAbsolutePosition(480, 720);
                    document.Add(gif);
                }
                else
                {
                    iTextSharp.text.Image gif = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath("~/Uploads/Style/index.jpg"));
                    //iTextSharp.text.Image gif = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath("~/Uploads/Style/thumb-TP 10220856-FRONT.jpg"));
                    gif.ScalePercent(20f);
                    gif.ScaleAbsolute(60f, 100.5f);
                    gif.SetAbsolutePosition(480, 720);
                    document.Add(gif);
                }

                //iTextSharp.text.Image gif = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath("~/Uploads/Style/index.jpg"));
                //gif.ScalePercent(45f);
                //gif.SetAbsolutePosition(500, 730);
                //document.Add(gif);



                iTextSharp.text.Font fontRemarkHeader = iTextSharp.text.FontFactory.GetFont(FontFactory.HELVETICA, 10);

                iTextSharp.text.Font fontRemark = iTextSharp.text.FontFactory.GetFont(FontFactory.HELVETICA, 8);

                iKandi.BLL.OrderProcessController ordProcess = new OrderProcessController();

                DataSet dsgrd = new DataSet();
                dsgrd = ordProcess.GetHOPPMRemarks(stylenumber, styleid, strClientId, DepartmentId, CreateNew, NewRef, ReUse, ReUseStyleId, "Fabric");

                //PdfPTable table;
                PdfPTable table = new PdfPTable(2);
                //PdfPRow row = null;
                float[] widths = new float[] { 3f, 6f };

                table.SetWidths(widths);
                table.WidthPercentage = 100;
                PdfPCell cell = new PdfPCell(new Phrase("HOPPM Report"));
                table.HeaderRows = 1;
                cell.Colspan = 2;


                DataSet dsStyle = obj_ProcessController.GetStyleClientAndDept(styleid, ReUseStyleId, strClientId, DepartmentId, CreateNew, NewRef, ReUse, 4);

                if (dsStyle.Tables[0].Rows.Count > 0)
                {
                    string StyleDetail = "";
                    for (int i = 0; i < dsStyle.Tables[0].Rows.Count; i++)
                    {
                        StyleDetail = StyleDetail + " [" + dsStyle.Tables[0].Rows[i]["StyleDetail"].ToString() + "],";
                    }

                    BasicInformation = StyleDetail.TrimEnd(',');
                }

                Font blue = FontFactory.GetFont("HELVETICA", 10, Font.BOLD, new Color(72, 99, 160));

                //For Header 
                cell = new PdfPCell(new Phrase("HOPPM Report", new Font(Font.HELVETICA, 12, Font.BOLD, new Color(72, 99, 160))));
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                //cell.Width = 10;
                cell.FixedHeight = 18f;
                cell.Border = 0;
                cell.Colspan = 2;

                table.AddCell(cell);

                cell = new PdfPCell(new Phrase("", blue));
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                //cell.Width = 10;
                cell.FixedHeight = 15f;
                cell.Border = 0;
                cell.Colspan = 2;

                table.AddCell(cell);

                //END


                //For Header Style
                cell = new PdfPCell(new Phrase(BasicInformation, new Font(Font.HELVETICA, 12, Font.BOLD | Font.NORMAL)));
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                //cell.Width = 10;
                cell.Border = 0;
                cell.Colspan = 2;

                table.AddCell(cell);
                //END           

                //

                string Client = dtStyleDetails.Rows[0]["CompanyName"].ToString();
                cell = new PdfPCell(new Phrase("Client :" + Client, new Font(Font.BOLD, 10, Font.BOLD | Font.BOLD)));
                cell.HorizontalAlignment = Element.ALIGN_LEFT;
                cell.FixedHeight = 15f;
                cell.Border = 0;
                cell.Colspan = 2;
                table.AddCell(cell);

                string Style = dtStyleDetails.Rows[0]["StyleNumber"].ToString();
                cell = new PdfPCell(new Phrase("Style :" + Style, new Font(Font.BOLD, 10, Font.BOLD | Font.BOLD)));
                cell.HorizontalAlignment = Element.ALIGN_LEFT;
                cell.FixedHeight = 15f;
                cell.Border = 0;
                cell.Colspan = 2;
                table.AddCell(cell);


                cell = new PdfPCell(new Phrase("Serial :" + Serial, new Font(Font.BOLD, 10, Font.BOLD | Font.BOLD)));
                cell.HorizontalAlignment = Element.ALIGN_LEFT;
                cell.FixedHeight = 15f;
                cell.Border = 0;
                cell.Colspan = 2;
                table.AddCell(cell);


                cell = new PdfPCell(new Phrase("CN No. :" + ContractNumber, new Font(Font.BOLD, 10, Font.BOLD | Font.BOLD)));
                cell.HorizontalAlignment = Element.ALIGN_LEFT;
                cell.FixedHeight = 15f;
                cell.Border = 0;
                cell.Colspan = 2;
                table.AddCell(cell);

                //
                //For Fabric Remarks
                if (dsgrd.Tables[0].Rows.Count > 0)
                {

                    //cell = new PdfPCell(new Phrase("Fabric", new Font(Font.HELVETICA, 10, Font.BOLD | Font.NORMAL )));
                    cell = new PdfPCell(new Phrase("Fabric", blue));
                    cell.HorizontalAlignment = Element.ALIGN_LEFT;
                    //cell.Width = 10;
                    cell.FixedHeight = 15f;
                    cell.BorderWidthTop = 0.3f;
                    cell.BorderWidthLeft = 0.3f;
                    cell.BorderWidthRight = 0.3f;
                    cell.BorderWidthBottom = 0.3f;
                    cell.Colspan = 2;
                    table.AddCell(cell);

                    foreach (DataColumn c in dsgrd.Tables[0].Columns)
                    {
                        if (c.ColumnName == "RemarksBy")
                        {
                            // table.AddCell(new Phrase(c.ColumnName, fontRemarkHeader));
                            cell = new PdfPCell(new Phrase("RemarksBy", new Font(Font.HELVETICA, 8, Font.BOLD | Font.NORMAL)));
                            cell.HorizontalAlignment = Element.ALIGN_LEFT;
                            cell.Border = 0;
                            cell.Colspan = 1;
                            table.AddCell(cell);

                        }
                        if (c.ColumnName == "FabricRemark")
                        {
                            cell = new PdfPCell(new Phrase("Remark", new Font(Font.HELVETICA, 8, Font.BOLD | Font.NORMAL)));
                            cell.HorizontalAlignment = Element.ALIGN_LEFT;
                            cell.Border = 0;
                            cell.Colspan = 1;
                            table.AddCell(cell);
                        }
                    }

                    foreach (DataRow r in dsgrd.Tables[0].Rows)
                    {
                        if (dsgrd.Tables[0].Rows.Count > 0)
                        {
                            //table.AddCell(new Phrase(r[2].ToString(), fontRemark));
                            //table.AddCell(new Phrase(r[3].ToString(), fontRemark));

                            cell = new PdfPCell(new Phrase(r[2].ToString(), fontRemark));
                            cell.HorizontalAlignment = Element.ALIGN_LEFT;
                            cell.Border = 0;
                            cell.Colspan = 1;
                            table.AddCell(cell);


                            cell = new PdfPCell(new Phrase(r[3].ToString(), fontRemark));
                            cell.HorizontalAlignment = Element.ALIGN_LEFT;
                            cell.Border = 0;
                            cell.Colspan = 1;
                            table.AddCell(cell);




                        }
                    }

                }
                else
                {
                    cell = new PdfPCell(new Phrase("Fabric", blue));
                    cell.HorizontalAlignment = Element.ALIGN_LEFT;
                    //cell.Width = 10;
                    cell.FixedHeight = 15f;
                    cell.Border = 1;
                    cell.BorderWidthLeft = 0.3f;
                    cell.BorderWidthRight = 0.3f;
                    cell.Colspan = 2;
                    table.AddCell(cell);






                    //cell = new PdfPCell(new Phrase("____________________________________________________________________________________________________________________________________", new Font(Font.HELVETICA, 10, Font.NORMAL | Font.NORMAL)));
                    //cell.HorizontalAlignment = Element.ALIGN_LEFT;
                    ////cell.Width = 10;
                    //cell.FixedHeight = 15f;
                    //cell.Border = 0;
                    //cell.Colspan = 2;
                    //table.AddCell(cell);
                }
                //END
                //For Accesories Remarks

                DataSet dsAccesories = new DataSet();
                dsAccesories = ordProcess.GetHOPPMRemarks(stylenumber, styleid, strClientId, DepartmentId, CreateNew, NewRef, ReUse, ReUseStyleId, "Accesories");

                if (dsAccesories.Tables[0].Rows.Count > 0)
                {
                    cell = new PdfPCell(new Phrase("Accesories", blue));
                    cell.HorizontalAlignment = Element.ALIGN_LEFT;
                    //cell.Width = 10;
                    cell.FixedHeight = 15f;
                    cell.BorderWidthTop = 0.3f;
                    cell.BorderWidthLeft = 0.3f;
                    cell.BorderWidthRight = 0.3f;
                    cell.BorderWidthBottom = 0.3f;
                    cell.Colspan = 2;
                    table.AddCell(cell);

                    foreach (DataColumn c in dsAccesories.Tables[0].Columns)
                    {
                        if (c.ColumnName == "RemarksBy")
                        {
                            // table.AddCell(new Phrase(c.ColumnName, fontRemarkHeader));
                            cell = new PdfPCell(new Phrase("RemarksBy", new Font(Font.HELVETICA, 8, Font.BOLD | Font.NORMAL)));
                            cell.HorizontalAlignment = Element.ALIGN_LEFT;
                            cell.Border = 0;
                            cell.Colspan = 1;
                            table.AddCell(cell);

                        }
                        if (c.ColumnName == "FabricRemark")
                        {
                            cell = new PdfPCell(new Phrase("Remark", new Font(Font.HELVETICA, 8, Font.BOLD | Font.NORMAL)));
                            cell.HorizontalAlignment = Element.ALIGN_LEFT;
                            cell.Border = 0;
                            cell.Colspan = 1;
                            table.AddCell(cell);
                        }
                    }

                    foreach (DataRow r in dsAccesories.Tables[0].Rows)
                    {
                        if (dsAccesories.Tables[0].Rows.Count > 0)
                        {
                            cell = new PdfPCell(new Phrase(r[2].ToString(), fontRemark));
                            cell.HorizontalAlignment = Element.ALIGN_LEFT;
                            cell.Border = 0;
                            cell.Colspan = 1;
                            table.AddCell(cell);


                            cell = new PdfPCell(new Phrase(r[3].ToString(), fontRemark));
                            cell.HorizontalAlignment = Element.ALIGN_LEFT;
                            cell.Border = 0;
                            cell.Colspan = 1;
                            table.AddCell(cell);

                        }
                    }
                    //cell = new PdfPCell(new Phrase("____________________________________________________________________________________________________________________________________", new Font(Font.BOLD, 10, Font.BOLD | Font.BOLD)));
                    //cell.HorizontalAlignment = Element.ALIGN_LEFT;
                    ////cell.Width = 10;
                    //cell.FixedHeight = 15f;
                    //cell.Border = 0;
                    //cell.Colspan = 2;
                    //table.AddCell(cell);
                }
                else
                {
                    cell = new PdfPCell(new Phrase("Accesories", blue));
                    cell.HorizontalAlignment = Element.ALIGN_LEFT;
                    cell.FixedHeight = 15f;
                    cell.Border = 1;
                    cell.BorderWidthLeft = 0.3f;
                    cell.BorderWidthRight = 0.3f;

                    cell.Colspan = 2;
                    table.AddCell(cell);

                    //cell = new PdfPCell(new Phrase("____________________________________________________________________________________________________________________________________", new Font(Font.HELVETICA, 10, Font.NORMAL | Font.NORMAL)));
                    //cell.HorizontalAlignment = Element.ALIGN_LEFT;
                    //cell.FixedHeight = 15f;
                    //cell.Border = 0;
                    //cell.Colspan = 2;
                    //table.AddCell(cell);
                }

                //END
                /*
                //For Fitting Fitting
                DataSet dsFitting = new DataSet();
                dsFitting = ordProcess.GetHOPPMRemarks(stylenumber, styleid, strClientId, DepartmentId, CreateNew, NewRef, ReUse, ReUseStyleId, "Fitting");

                if (dsFitting.Tables[0].Rows.Count > 0)
                {
                    //cell = new PdfPCell(new Phrase("Fitting", new Font(Font.HELVETICA, 10, Font.BOLD | Font.NORMAL)));
                    cell = new PdfPCell(new Phrase("Fitting", blue));
                    cell.HorizontalAlignment = Element.ALIGN_LEFT;
                    //cell.Width = 10;
                    cell.FixedHeight = 15f;
                    cell.Border = 0;
                    cell.Colspan = 2;
                    table.AddCell(cell);

                    foreach (DataColumn c in dsFitting.Tables[0].Columns)
                    {
                        if (c.ColumnName == "RemarksBy" || c.ColumnName == "FabricRemark")
                        {
                            table.AddCell(new Phrase(c.ColumnName, fontRemarkHeader));
                        }
                    }

                    foreach (DataRow r in dsFitting.Tables[0].Rows)
                    {
                        if (dsFitting.Tables[0].Rows.Count > 0)
                        {
                            //table.AddCell(new Phrase(r[2].ToString(), fontRemark));
                            //table.AddCell(new Phrase(r[3].ToString(), fontRemark));
                            cell = new PdfPCell(new Phrase(r[2].ToString(), fontRemark));
                            cell.HorizontalAlignment = Element.ALIGN_LEFT;
                            //cell.Width = 10;
                            cell.FixedHeight = 15f;
                            cell.Border = 0;
                            cell.Colspan = 1;
                            table.AddCell(cell);


                            cell = new PdfPCell(new Phrase(r[3].ToString(), fontRemark));
                            cell.HorizontalAlignment = Element.ALIGN_LEFT;
                            //cell.Width = 10;
                            cell.FixedHeight = 15f;
                            cell.Border = 0;
                            cell.Colspan = 1;
                            table.AddCell(cell);

                        }
                    }
                    cell = new PdfPCell(new Phrase("____________________________________________________________________________________________________________________________________", new Font(Font.BOLD, 10, Font.BOLD | Font.BOLD)));
                    cell.HorizontalAlignment = Element.ALIGN_LEFT;
                    //cell.Width = 10;
                    cell.FixedHeight = 15f;
                    cell.Border = 0;
                    cell.Colspan = 2;
                    table.AddCell(cell);
                }
                else
                {
                    cell = new PdfPCell(new Phrase("Fitting", blue));
                    cell.HorizontalAlignment = Element.ALIGN_LEFT;
                    //cell.Width = 10;
                    cell.FixedHeight = 15f;
                    cell.Border = 0;
                    cell.Colspan = 2;
                    table.AddCell(cell);

                    cell = new PdfPCell(new Phrase("____________________________________________________________________________________________________________________________________", new Font(Font.HELVETICA, 10, Font.NORMAL | Font.NORMAL)));
                    cell.HorizontalAlignment = Element.ALIGN_LEFT;
                    //cell.Width = 10;
                    cell.FixedHeight = 15f;
                    cell.Border = 0;
                    cell.Colspan = 2;
                    table.AddCell(cell);
                }
                //END
                 */

                //For Making
                DataSet dsMaking = new DataSet();
                dsMaking = ordProcess.GetHOPPMRemarks(stylenumber, styleid, strClientId, DepartmentId, CreateNew, NewRef, ReUse, ReUseStyleId, "Making");
                if (dsMaking.Tables[0].Rows.Count > 0)
                {
                    cell = new PdfPCell(new Phrase("Making", blue));
                    cell.HorizontalAlignment = Element.ALIGN_LEFT;
                    //cell.Width = 10;
                    cell.FixedHeight = 15f;
                    //cell.Border = 1;
                    cell.BorderWidthTop = 0.3f;
                    cell.BorderWidthLeft = 0.3f;
                    cell.BorderWidthRight = 0.3f;
                    cell.BorderWidthBottom = 0.3f;


                    cell.Colspan = 2;
                    table.AddCell(cell);


                    foreach (DataColumn c in dsMaking.Tables[0].Columns)
                    {
                        if (c.ColumnName == "RemarksBy")
                        {
                            // table.AddCell(new Phrase(c.ColumnName, fontRemarkHeader));
                            cell = new PdfPCell(new Phrase("RemarksBy", new Font(Font.HELVETICA, 8, Font.BOLD | Font.NORMAL)));
                            cell.HorizontalAlignment = Element.ALIGN_LEFT;
                            cell.Border = 0;
                            cell.Colspan = 1;
                            table.AddCell(cell);

                        }
                        if (c.ColumnName == "FabricRemark")
                        {
                            cell = new PdfPCell(new Phrase("Remark", new Font(Font.HELVETICA, 8, Font.BOLD | Font.NORMAL)));
                            cell.HorizontalAlignment = Element.ALIGN_LEFT;
                            cell.Border = 0;
                            cell.Colspan = 1;
                            table.AddCell(cell);
                        }
                    }

                    foreach (DataRow r in dsMaking.Tables[0].Rows)
                    {
                        if (dsMaking.Tables[0].Rows.Count > 0)
                        {
                            cell = new PdfPCell(new Phrase(r[2].ToString(), fontRemark));
                            cell.HorizontalAlignment = Element.ALIGN_LEFT;
                            cell.Border = 0;
                            cell.Colspan = 1;
                            table.AddCell(cell);


                            cell = new PdfPCell(new Phrase(r[3].ToString(), fontRemark));
                            cell.HorizontalAlignment = Element.ALIGN_LEFT;
                            cell.Border = 0;
                            cell.Colspan = 1;
                            table.AddCell(cell);

                        }
                    }
                    //cell = new PdfPCell(new Phrase("____________________________________________________________________________________________________________________________________", new Font(Font.BOLD, 10, Font.BOLD | Font.BOLD)));
                    //cell.HorizontalAlignment = Element.ALIGN_LEFT;
                    //cell.FixedHeight = 15f;
                    //cell.Border = 0;
                    //cell.Colspan = 2;
                    //table.AddCell(cell);
                }
                else
                {
                    cell = new PdfPCell(new Phrase("Making", blue));
                    cell.HorizontalAlignment = Element.ALIGN_LEFT;
                    cell.FixedHeight = 15f;
                    cell.Border = 1;
                    cell.BorderWidthLeft = 0.3f;
                    cell.BorderWidthRight = 0.3f;
                    cell.Colspan = 2;
                    table.AddCell(cell);

                    //cell = new PdfPCell(new Phrase("____________________________________________________________________________________________________________________________________", new Font(Font.HELVETICA, 10, Font.NORMAL | Font.NORMAL)));
                    //cell.HorizontalAlignment = Element.ALIGN_LEFT;
                    //cell.FixedHeight = 15f;
                    //cell.Border = 0;
                    //cell.Colspan = 2;
                    //table.AddCell(cell);
                }
                //END
                //For Imbroidery
                DataSet dsImbroidery = new DataSet();
                dsImbroidery = ordProcess.GetHOPPMRemarks(stylenumber, styleid, strClientId, DepartmentId, CreateNew, NewRef, ReUse, ReUseStyleId, "Imbroidery");
                if (dsImbroidery.Tables[0].Rows.Count > 0)
                {
                    cell = new PdfPCell(new Phrase("Value Addition", blue));
                    cell.HorizontalAlignment = Element.ALIGN_LEFT;
                    cell.FixedHeight = 15f;
                    //cell.Border = 1;
                    cell.Colspan = 2;
                    cell.BorderWidthTop = 0.3f;
                    cell.BorderWidthLeft = 0.3f;
                    cell.BorderWidthRight = 0.3f;
                    cell.BorderWidthBottom = 0.3f;
                    table.AddCell(cell);

                    foreach (DataColumn c in dsImbroidery.Tables[0].Columns)
                    {
                        if (c.ColumnName == "RemarksBy")
                        {
                            // table.AddCell(new Phrase(c.ColumnName, fontRemarkHeader));
                            cell = new PdfPCell(new Phrase("RemarksBy", new Font(Font.HELVETICA, 8, Font.BOLD | Font.NORMAL)));
                            cell.HorizontalAlignment = Element.ALIGN_LEFT;
                            cell.Border = 0;
                            cell.Colspan = 1;
                            table.AddCell(cell);

                        }
                        if (c.ColumnName == "FabricRemark")
                        {
                            cell = new PdfPCell(new Phrase("Remark", new Font(Font.HELVETICA, 8, Font.BOLD | Font.NORMAL)));
                            cell.HorizontalAlignment = Element.ALIGN_LEFT;
                            cell.Border = 0;
                            cell.Colspan = 1;
                            table.AddCell(cell);
                        }
                    }

                    foreach (DataRow r in dsImbroidery.Tables[0].Rows)
                    {
                        if (dsImbroidery.Tables[0].Rows.Count > 0)
                        {
                            cell = new PdfPCell(new Phrase(r[2].ToString(), fontRemark));
                            cell.HorizontalAlignment = Element.ALIGN_LEFT;
                            cell.Border = 0;
                            cell.Colspan = 1;
                            table.AddCell(cell);


                            cell = new PdfPCell(new Phrase(r[3].ToString(), fontRemark));
                            cell.HorizontalAlignment = Element.ALIGN_LEFT;
                            cell.Border = 0;
                            cell.Colspan = 1;
                            table.AddCell(cell);

                        }
                    }
                    //cell = new PdfPCell(new Phrase("____________________________________________________________________________________________________________________________________", new Font(Font.BOLD, 10, Font.BOLD | Font.BOLD)));
                    //cell.HorizontalAlignment = Element.ALIGN_LEFT;
                    //cell.FixedHeight = 15f;
                    //cell.Border = 0;
                    //cell.Colspan = 2;
                    //table.AddCell(cell);
                }
                else
                {
                    cell = new PdfPCell(new Phrase("Value Addition", blue));
                    cell.HorizontalAlignment = Element.ALIGN_LEFT;
                    cell.FixedHeight = 15f;
                    cell.Border = 1;
                    cell.BorderWidthLeft = 0.3f;
                    cell.BorderWidthRight = 0.3f;
                    cell.Colspan = 2;
                    table.AddCell(cell);

                    //cell = new PdfPCell(new Phrase("____________________________________________________________________________________________________________________________________", new Font(Font.HELVETICA, 10, Font.NORMAL | Font.NORMAL)));
                    //cell.HorizontalAlignment = Element.ALIGN_LEFT;
                    //cell.FixedHeight = 15f;
                    //cell.Border = 0;
                    //cell.Colspan = 2;
                    //table.AddCell(cell);
                }
                //END

                //For Washing

                DataSet dsWashing = new DataSet();
                dsWashing = ordProcess.GetHOPPMRemarks(stylenumber, styleid, strClientId, DepartmentId, CreateNew, NewRef, ReUse, ReUseStyleId, "Washing");
                if (dsWashing.Tables[0].Rows.Count > 0)
                {
                    cell = new PdfPCell(new Phrase("Washing", blue));
                    cell.HorizontalAlignment = Element.ALIGN_LEFT;
                    cell.FixedHeight = 15f;
                    //cell.Border = 1;
                    cell.Colspan = 2;
                    cell.BorderWidthTop = 0.3f;
                    cell.BorderWidthLeft = 0.3f;
                    cell.BorderWidthRight = 0.3f;
                    cell.BorderWidthBottom = 0.3f;
                    table.AddCell(cell);

                    foreach (DataColumn c in dsWashing.Tables[0].Columns)
                    {
                        if (c.ColumnName == "RemarksBy")
                        {
                            // table.AddCell(new Phrase(c.ColumnName, fontRemarkHeader));
                            cell = new PdfPCell(new Phrase("RemarksBy", new Font(Font.HELVETICA, 8, Font.BOLD | Font.NORMAL)));
                            cell.HorizontalAlignment = Element.ALIGN_LEFT;
                            cell.Border = 0;
                            cell.Colspan = 1;
                            table.AddCell(cell);

                        }
                        if (c.ColumnName == "FabricRemark")
                        {
                            cell = new PdfPCell(new Phrase("Remark", new Font(Font.HELVETICA, 8, Font.BOLD | Font.NORMAL)));
                            cell.HorizontalAlignment = Element.ALIGN_LEFT;
                            cell.Border = 0;
                            cell.Colspan = 1;
                            table.AddCell(cell);
                        }
                    }

                    foreach (DataRow r in dsWashing.Tables[0].Rows)
                    {
                        if (dsWashing.Tables[0].Rows.Count > 0)
                        {
                            cell = new PdfPCell(new Phrase(r[2].ToString(), fontRemark));
                            cell.HorizontalAlignment = Element.ALIGN_LEFT;
                            cell.Border = 0;
                            cell.Colspan = 1;
                            table.AddCell(cell);


                            cell = new PdfPCell(new Phrase(r[3].ToString(), fontRemark));
                            cell.HorizontalAlignment = Element.ALIGN_LEFT;
                            cell.Border = 0;
                            cell.Colspan = 1;
                            table.AddCell(cell);

                        }
                    }
                    //cell = new PdfPCell(new Phrase("____________________________________________________________________________________________________________________________________", new Font(Font.BOLD, 10, Font.BOLD | Font.BOLD)));
                    //cell.HorizontalAlignment = Element.ALIGN_LEFT;
                    //cell.FixedHeight = 15f;
                    //cell.Border = 0;
                    //cell.Colspan = 2;
                    //table.AddCell(cell);
                }
                else
                {
                    cell = new PdfPCell(new Phrase("Washing", blue));
                    cell.HorizontalAlignment = Element.ALIGN_LEFT;
                    cell.FixedHeight = 15f;
                    cell.Border = 1;
                    cell.BorderWidthLeft = 0.3f;
                    cell.BorderWidthRight = 0.3f;
                    cell.Colspan = 2;
                    table.AddCell(cell);

                    //cell = new PdfPCell(new Phrase("____________________________________________________________________________________________________________________________________", new Font(Font.HELVETICA, 10, Font.NORMAL | Font.NORMAL)));
                    //cell.HorizontalAlignment = Element.ALIGN_LEFT;
                    //cell.FixedHeight = 15f;
                    //cell.Border = 0;
                    //cell.Colspan = 2;
                    //table.AddCell(cell);
                }
                //END

                //For Finishing
                DataSet dsFinishing = new DataSet();
                dsFinishing = ordProcess.GetHOPPMRemarks(stylenumber, styleid, strClientId, DepartmentId, CreateNew, NewRef, ReUse, ReUseStyleId, "Finishing");
                if (dsFinishing.Tables[0].Rows.Count > 0)
                {
                    cell = new PdfPCell(new Phrase("Finishing/Packing", blue));
                    cell.HorizontalAlignment = Element.ALIGN_LEFT;
                    cell.FixedHeight = 15f;
                    cell.BorderWidthTop = 0.3f;
                    cell.BorderWidthLeft = 0.3f;
                    cell.BorderWidthRight = 0.3f;
                    cell.BorderWidthBottom = 0.3f;
                    cell.Colspan = 2;
                    table.AddCell(cell);



                    foreach (DataColumn c in dsFinishing.Tables[0].Columns)
                    {
                        if (c.ColumnName == "RemarksBy")
                        {
                            // table.AddCell(new Phrase(c.ColumnName, fontRemarkHeader));
                            cell = new PdfPCell(new Phrase("RemarksBy", new Font(Font.HELVETICA, 8, Font.BOLD | Font.NORMAL)));
                            cell.HorizontalAlignment = Element.ALIGN_LEFT;
                            cell.Border = 0;
                            cell.Colspan = 1;
                            table.AddCell(cell);

                        }
                        if (c.ColumnName == "FabricRemark")
                        {
                            cell = new PdfPCell(new Phrase("Remark", new Font(Font.HELVETICA, 8, Font.BOLD | Font.NORMAL)));
                            cell.HorizontalAlignment = Element.ALIGN_LEFT;
                            cell.Border = 0;
                            cell.Colspan = 1;
                            table.AddCell(cell);
                        }
                    }

                    foreach (DataRow r in dsFinishing.Tables[0].Rows)
                    {
                        if (dsFinishing.Tables[0].Rows.Count > 0)
                        {
                            cell = new PdfPCell(new Phrase(r[2].ToString(), fontRemark));
                            cell.HorizontalAlignment = Element.ALIGN_LEFT;
                            cell.Border = 0;
                            cell.Colspan = 1;
                            table.AddCell(cell);


                            cell = new PdfPCell(new Phrase(r[3].ToString(), fontRemark));
                            cell.HorizontalAlignment = Element.ALIGN_LEFT;
                            cell.Border = 0;
                            cell.Colspan = 1;
                            table.AddCell(cell);
                        }
                    }
                    cell = new PdfPCell(new Phrase("____________________________________________________________________________________________________________________________________", new Font(Font.BOLD, 10, Font.BOLD | Font.BOLD)));
                    cell.HorizontalAlignment = Element.ALIGN_LEFT;
                    cell.FixedHeight = 15f;
                    cell.Border = 0;
                    cell.Colspan = 2;
                    table.AddCell(cell);
                }
                else
                {
                    cell = new PdfPCell(new Phrase("Finishing/Packing", blue));
                    cell.HorizontalAlignment = Element.ALIGN_LEFT;
                    cell.FixedHeight = 15f;
                    cell.BorderWidthTop = 0.3f;
                    cell.BorderWidthLeft = 0.3f;
                    cell.BorderWidthRight = 0.3f;
                    cell.BorderWidthBottom = 0.3f;
                    cell.Colspan = 2;
                    table.AddCell(cell);

                    //cell = new PdfPCell(new Phrase("____________________________________________________________________________________________________________________________________", new Font(Font.HELVETICA, 10, Font.NORMAL | Font.NORMAL)));
                    //cell.HorizontalAlignment = Element.ALIGN_LEFT;
                    ////cell.Width = 10;
                    //cell.FixedHeight = 15f;
                    //cell.Border = 0;
                    //cell.Colspan = 2;
                    //table.AddCell(cell);
                }
                //END

                //
                DataSet dsHoPPM = obj_ProcessController.GetHOPPM(stylenumber, styleid, strClientId, DepartmentId, CreateNew, NewRef, ReUse, ReUseStyleId);


                ////For FactoryRepresentativeNames
                //cell = new PdfPCell(new Phrase("Factory Representative Names" + ":" + dsHoPPM.Tables[0].Rows[0]["FactoryRepresentativeNames"].ToString(), new Font(Font.HELVETICA, 11, Font.NORMAL | Font.NORMAL)));
                //cell.HorizontalAlignment = Element.ALIGN_LEFT;
                //cell.FixedHeight = 15f;
                //cell.Border = 0;
                //cell.Colspan = 2;
                //table.AddCell(cell);

                //For FactoryRepresentativeNames
                cell = new PdfPCell(new Phrase("Factory Representative", new Font(Font.HELVETICA, 11, Font.NORMAL | Font.NORMAL)));
                cell.HorizontalAlignment = Element.ALIGN_LEFT;
                cell.Border = 0;
                cell.Colspan = 1;
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(":" + UppercaseFirst(dsHoPPM.Tables[0].Rows[0]["FactoryRepresentativeNames"].ToString()), new Font(Font.HELVETICA, 9, Font.NORMAL | Font.NORMAL)));
                cell.HorizontalAlignment = Element.ALIGN_LEFT;
                cell.Border = 0;
                cell.Colspan = 1;
                table.AddCell(cell);




                //For QaRepresentativeNames
                //cell = new PdfPCell(new Phrase("Qa Representative Names" + ":" + dsHoPPM.Tables[0].Rows[0]["QaRepresentativeNames"].ToString(), new Font(Font.HELVETICA, 11, Font.NORMAL | Font.NORMAL)));
                //cell.HorizontalAlignment = Element.ALIGN_LEFT;
                ////cell.Width = 10;
                //cell.FixedHeight = 15f;
                //cell.Border = 0;
                //cell.Colspan = 2;
                //table.AddCell(cell);

                cell = new PdfPCell(new Phrase("Qa Representative" + ":", new Font(Font.HELVETICA, 11, Font.NORMAL | Font.NORMAL)));
                cell.HorizontalAlignment = Element.ALIGN_LEFT;
                //cell.FixedHeight = 15f;
                cell.Border = 0;
                cell.Colspan = 1;
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(":" + UppercaseFirst(dsHoPPM.Tables[0].Rows[0]["QaRepresentativeNames"].ToString()), new Font(Font.HELVETICA, 9, Font.NORMAL | Font.NORMAL)));
                cell.HorizontalAlignment = Element.ALIGN_LEFT;
                cell.Border = 0;
                cell.Colspan = 1;
                table.AddCell(cell);


                //For MerchandiserRepresentativeName
                //cell = new PdfPCell(new Phrase("Merchandiser Representative Name" + ":" + dsHoPPM.Tables[0].Rows[0]["MerchandiserRepresentativeName"].ToString(), new Font(Font.HELVETICA, 11, Font.NORMAL | Font.NORMAL)));
                //cell.HorizontalAlignment = Element.ALIGN_LEFT;
                ////cell.Width = 10;
                //cell.FixedHeight = 15f;
                //cell.Border = 0;
                //cell.Colspan = 2;
                //table.AddCell(cell);

                cell = new PdfPCell(new Phrase("Merchandiser Representative", new Font(Font.HELVETICA, 11, Font.NORMAL | Font.NORMAL)));
                cell.HorizontalAlignment = Element.ALIGN_LEFT;
                cell.Border = 0;
                cell.Colspan = 0;
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(":" + UppercaseFirst(dsHoPPM.Tables[0].Rows[0]["MerchandiserRepresentativeName"].ToString()), new Font(Font.HELVETICA, 9, Font.NORMAL | Font.NORMAL)));
                cell.HorizontalAlignment = Element.ALIGN_LEFT;
                cell.Border = 0;
                cell.Colspan = 1;
                table.AddCell(cell);

                //

                //For Representative Approval and Date
                cell = new PdfPCell(new Phrase("____________________________________________________________________________________________________________________________________", new Font(Font.HELVETICA, 10, Font.NORMAL | Font.NORMAL)));
                cell.HorizontalAlignment = Element.ALIGN_LEFT;
                cell.FixedHeight = 15f;
                cell.Border = 0;
                cell.Colspan = 2;
                table.AddCell(cell);

                bool IsQAPreProdApprovedOn = false;
                string QAPreProdApprovedOn = "No";
                string QAPreProdApprovedOnDate = "_____________";
                IsQAPreProdApprovedOn = Convert.ToBoolean(dsHoPPM.Tables[0].Rows[0]["IsQAPreProdApprovedOn"]);
                if (IsQAPreProdApprovedOn == true)
                {
                    QAPreProdApprovedOn = "Yes";
                    QAPreProdApprovedOnDate = dsHoPPM.Tables[0].Rows[0]["QAPreProdApprovedOn"] == DBNull.Value ? "" : Convert.ToDateTime(dsHoPPM.Tables[0].Rows[0]["QAPreProdApprovedOn"]).ToString("dd-MMM-yyyy");
                }


                bool IsQAProdApprovedOn = false;
                IsQAProdApprovedOn = Convert.ToBoolean(dsHoPPM.Tables[0].Rows[0]["IsQAProdApprovedOn"]);
                string QAProdApprovedOn = "NO";
                string QAProdApprovedOnDate = "_____________";
                if (IsQAProdApprovedOn == true)
                {
                    QAProdApprovedOn = "Yes";
                    QAProdApprovedOnDate = dsHoPPM.Tables[0].Rows[0]["QAProdApprovedOn"] == DBNull.Value ? "" : Convert.ToDateTime(dsHoPPM.Tables[0].Rows[0]["QAProdApprovedOn"]).ToString("dd-MMM-yyyy");
                }

                bool IsMerchandisingManagerApprovedOn = false;
                IsMerchandisingManagerApprovedOn = Convert.ToBoolean(dsHoPPM.Tables[0].Rows[0]["IsMerchandisingManagerApprovedOn"]);
                string MerchandisingManagerApprovedOn = "NO";
                string MerchandisingManagerApprovedOnDate = "_____________";
                if (IsMerchandisingManagerApprovedOn == true)
                {
                    MerchandisingManagerApprovedOn = "Yes";
                    MerchandisingManagerApprovedOnDate = dsHoPPM.Tables[0].Rows[0]["MerchandisingManagerApprovedOn"] == DBNull.Value ? "" : Convert.ToDateTime(dsHoPPM.Tables[0].Rows[0]["MerchandisingManagerApprovedOn"]).ToString("dd-MMM-yyyy");
                }

                bool IsFactoryPPMComplete = false;
                IsFactoryPPMComplete = Convert.ToBoolean(dsHoPPM.Tables[0].Rows[0]["IsFactoryPPMComplete"]);
                string FactoryPPMComplete = "NO";
                string FactoryPPMCompleteDate = "_____________";
                if (IsFactoryPPMComplete == true)
                {
                    FactoryPPMComplete = "Yes";
                    FactoryPPMCompleteDate = dsHoPPM.Tables[0].Rows[0]["FactoryPPMCompleteOn"] == DBNull.Value ? "" : Convert.ToDateTime(dsHoPPM.Tables[0].Rows[0]["FactoryPPMCompleteOn"]).ToString("dd-MMM-yyyy");
                }

                bool IsHOPPMComplete = false;
                IsHOPPMComplete = Convert.ToBoolean(dsHoPPM.Tables[0].Rows[0]["IsHOPPMComplete"]);
                string HOPPMComplete = "NO";
                string HOPPMCompleteDate = "_____________";
                if (IsHOPPMComplete == true)
                {
                    HOPPMComplete = "Yes";
                    HOPPMCompleteDate = dsHoPPM.Tables[0].Rows[0]["HOPPMCompleteOn"] == DBNull.Value ? "" : Convert.ToDateTime(dsHoPPM.Tables[0].Rows[0]["HOPPMCompleteOn"]).ToString("dd-MMM-yyyy");

                }

                //For Representative Approved Date
                cell = new PdfPCell(new Phrase("QAPreProdApprovedOn: " + QAPreProdApprovedOn + " |  " + "QAProdApprovedOn: " + QAProdApprovedOn + " |  " + "MerchandisingManagerApprovedOn: " + MerchandisingManagerApprovedOn + " |  " + "FactoryPPMComplete: " + FactoryPPMComplete + " |  " + "HOPPMComplete: " + HOPPMComplete, new Font(Font.BOLD, 7, Font.BOLD | Font.BOLD)));
                cell.HorizontalAlignment = Element.ALIGN_LEFT;
                cell.FixedHeight = 15f;
                cell.Border = 0;
                cell.Colspan = 2;
                table.AddCell(cell);


                cell = new PdfPCell(new Phrase(QAPreProdApprovedOnDate + "  " + "                               " + QAProdApprovedOnDate + "  " + "                            " + MerchandisingManagerApprovedOnDate + " " + "                                                 " + FactoryPPMCompleteDate + "  " + "                     " + HOPPMCompleteDate, new Font(Font.BOLD, 7, Font.BOLD | Font.BOLD)));
                cell.HorizontalAlignment = Element.ALIGN_LEFT;
                cell.FixedHeight = 15f;
                cell.Border = 0;
                cell.Colspan = 2;
                table.AddCell(cell);
                //END


                //For Note 1
                DataTable dt = obj_ProcessController.Hoppm_OBComplete_Check(styleid);
                if (dt.Rows.Count > 0)
                {
                    int IsOb = Convert.ToInt32(dt.Rows[0]["ishoppmcomplete"].ToString());
                    if (IsOb == 0)
                    {
                        cell = new PdfPCell(new Phrase("IE Finalize OB W/S SAM Task Is Incomplete", new Font(Font.BOLD, 7, Font.BOLD | Font.BOLD, Color.BLUE)));
                        cell.HorizontalAlignment = Element.ALIGN_LEFT;
                        cell.FixedHeight = 15f;
                        cell.Border = 0;
                        cell.Colspan = 2;
                        table.AddCell(cell);
                    }


                }

                //For Note 2
                cell = new PdfPCell(new Phrase("* (This PPM Shall Be Deemed Incomplete Unless Attended By Both Pre Production QA Mgr And Production QA Mgr)", new Font(Font.BOLD, 7, Font.BOLD | Font.BOLD, Color.BLUE)));
                cell.HorizontalAlignment = Element.ALIGN_LEFT;
                cell.FixedHeight = 15f;
                cell.Border = 0;
                cell.Colspan = 2;
                table.AddCell(cell);

                //END


                document.Add(table);
                document.Close();
                //ShowPdf(fileName);
                fileName = pdfFilePath;

            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
            }
            return fileName;
        }
        //end by abhishek on 20/10/2015
        public string GetPrintHoppm(string stylenumber, int styleid, int strClientId, int DepartmentId, int CreateNew, int NewRef, int ReUse, int ReUseStyleId, string RemarksType)
        {

            string fileName = "HOPPM ReportTest -" + DateTime.Now.ToString("dd MMM yyy hh-mm-ss") + ".pdf";
            // fileName = "Combined Price Variations -" + DateTime.Now.ToString("dd MMM yyy hh-mm-ss") + ".pdf";
            String FitsFolderPath = "~/" + System.Configuration.ConfigurationManager.AppSettings["InlinePPM.Docs.folder"];
            iKandi.BLL.OrderProcessController obj_ProcessController = new BLL.OrderProcessController();
            string BasicInformation = "";
            if (!Directory.Exists(Constants.TEMP_FOLDER_PATH))
                Directory.CreateDirectory(Constants.TEMP_FOLDER_PATH);

            string pdfFilePath = Path.Combine(Constants.TEMP_FOLDER_PATH, fileName);
            try
            {               
                Document document = new Document();
                PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(pdfFilePath, FileMode.Create));
                document.Open();

                DataTable dtStyleDetails = new DataTable();
                dtStyleDetails = obj_ProcessController.GetStyleNumber(styleid);


                string Serial = "";
                string ContractNumber = "";
                if (dtStyleDetails.Rows.Count > 0)
                {

                    for (int i = 0; i < dtStyleDetails.Rows.Count; i++)
                    {
                        if (dtStyleDetails.Rows[i]["SerialNumber"].ToString() != "")
                        {
                            Serial = Serial + dtStyleDetails.Rows[i]["SerialNumber"].ToString() + ",";
                        }

                        ContractNumber = ContractNumber + dtStyleDetails.Rows[i]["ContractNumber"].ToString() + ",";
                    }

                    Serial = Serial.TrimEnd(',');
                    ContractNumber = ContractNumber.TrimEnd(',');
                }


                string ImageName = dtStyleDetails.Rows[0]["SampleImageURL1"].ToString();

                if (File.Exists(HttpContext.Current.Server.MapPath("~/Uploads/Style/thumb-" + ImageName)))
                {
                    iTextSharp.text.Image gif = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath("~/Uploads/Style/thumb-" + ImageName));
                    gif.ScalePercent(20f);
                    gif.ScaleAbsolute(60f, 100.5f);
                    gif.SetAbsolutePosition(480, 720);
                    document.Add(gif);
                }
                else
                {
                    iTextSharp.text.Image gif = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath("~/Uploads/Style/index.jpg"));
                    gif.ScalePercent(20f);
                    gif.ScaleAbsolute(60f, 100.5f);
                    gif.SetAbsolutePosition(480, 720);
                    document.Add(gif);
                }

                iTextSharp.text.Font fontRemarkHeader = iTextSharp.text.FontFactory.GetFont(FontFactory.HELVETICA, 10);

                iTextSharp.text.Font fontRemark = iTextSharp.text.FontFactory.GetFont(FontFactory.HELVETICA, 8);

                iKandi.BLL.OrderProcessController ordProcess = new OrderProcessController();

                DataSet dsgrd = new DataSet();
                dsgrd = ordProcess.GetHOPPMRemarks(stylenumber, styleid, strClientId, DepartmentId, CreateNew, NewRef, ReUse, ReUseStyleId, "Fabric");

                PdfPTable table = new PdfPTable(2);
                float[] widths = new float[] { 3f, 6f };

                table.SetWidths(widths);
                table.WidthPercentage = 100;
                PdfPCell cell = new PdfPCell(new Phrase("HOPPM Report"));
                table.HeaderRows = 1;
                cell.Colspan = 2;


                DataSet dsStyle = obj_ProcessController.GetStyleClientAndDept(styleid, ReUseStyleId, strClientId, DepartmentId, CreateNew, NewRef, ReUse, 4);

                if (dsStyle.Tables[0].Rows.Count > 0)
                {
                    string StyleDetail = "";
                    for (int i = 0; i < dsStyle.Tables[0].Rows.Count; i++)
                    {
                        StyleDetail = StyleDetail + " [" + dsStyle.Tables[0].Rows[i]["StyleDetail"].ToString() + "],";
                    }

                    BasicInformation = StyleDetail.TrimEnd(',');
                }

                Font blue = FontFactory.GetFont("HELVETICA", 10, Font.BOLD, new Color(72, 99, 160));

                //For Header 
                cell = new PdfPCell(new Phrase("HOPPM Report", new Font(Font.HELVETICA, 12, Font.BOLD, new Color(72, 99, 160))));
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                //cell.Width = 10;
                cell.FixedHeight = 18f;
                cell.Border = 0;
                cell.Colspan = 2;         
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase("", blue));
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                //cell.Width = 10;
                cell.FixedHeight = 15f;
                cell.Border = 0;
                cell.Colspan = 2;

                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(BasicInformation, new Font(Font.HELVETICA, 12, Font.BOLD | Font.NORMAL)));
                cell.HorizontalAlignment = Element.ALIGN_CENTER;              
                cell.Border = 0;
                cell.Colspan = 2;
                cell.FixedHeight = 18f;
                //cell.BackgroundColor = Color.GRAY;

                table.AddCell(cell);
        
                string Client = dtStyleDetails.Rows[0]["CompanyName"].ToString();
                cell = new PdfPCell(new Phrase("Client :" + Client, new Font(Font.BOLD, 10, Font.BOLD | Font.BOLD)));
                cell.HorizontalAlignment = Element.ALIGN_LEFT;
                cell.FixedHeight = 15f;
                cell.Border = 0;
                cell.Colspan = 2;
                table.AddCell(cell);

                string Style = dtStyleDetails.Rows[0]["StyleNumber"].ToString();
                cell = new PdfPCell(new Phrase("Style :" + Style, new Font(Font.BOLD, 10, Font.BOLD | Font.BOLD)));
                cell.HorizontalAlignment = Element.ALIGN_LEFT;
                cell.FixedHeight = 15f;
                cell.Border = 0;
                cell.Colspan = 2;
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase("Serial :" + Serial, new Font(Font.BOLD, 10, Font.BOLD | Font.BOLD)));
                cell.HorizontalAlignment = Element.ALIGN_LEFT;
                cell.FixedHeight = 15f;
                cell.Border = 0;
                cell.Colspan = 2;
                table.AddCell(cell);


                cell = new PdfPCell(new Phrase("CN No. :" + ContractNumber, new Font(Font.BOLD, 10, Font.BOLD | Font.BOLD)));
                cell.HorizontalAlignment = Element.ALIGN_LEFT;
                cell.FixedHeight = 15f;
                cell.Border = 0;
                cell.Colspan = 2;
                table.AddCell(cell);

                //
                //For Fabric Remarks
                if (dsgrd.Tables[0].Rows.Count > 0)
                {
                    cell = new PdfPCell(new Phrase("Fabric", blue));
                    cell.HorizontalAlignment = Element.ALIGN_LEFT;   
                    cell.FixedHeight = 15f;     
                    cell.Border = 0;
                    cell.Colspan = 2;
                    table.AddCell(cell);

                    foreach (DataRow r in dsgrd.Tables[0].Rows)
                    {
                        if (dsgrd.Tables[0].Rows.Count > 0)
                        {                   

                            cell = new PdfPCell(new Phrase(r["indexs"].ToString() + " " + r["RemarksBy"].ToString(), fontRemark));//abhishek 29/6
                            cell.HorizontalAlignment = Element.ALIGN_LEFT;
                            cell.Border = 0;
                            cell.Colspan = 1;
                            table.AddCell(cell);

                            cell = new PdfPCell(new Phrase(r["FabricRemark"].ToString(), fontRemark));
                            cell.HorizontalAlignment = Element.ALIGN_LEFT;
                            cell.Border = 0;
                            cell.Colspan = 1;
                            table.AddCell(cell);
                        }
                    }
                }
                else
                {
                    cell = new PdfPCell(new Phrase("Fabric", blue));
                    cell.HorizontalAlignment = Element.ALIGN_LEFT;       
                    cell.FixedHeight = 15f;         
                    cell.Colspan = 2;
                    cell.Border = 0;
                    table.AddCell(cell);

                }
                //END
                //For Accesories Remarks

                DataSet dsAccesories = new DataSet();
                dsAccesories = ordProcess.GetHOPPMRemarks(stylenumber, styleid, strClientId, DepartmentId, CreateNew, NewRef, ReUse, ReUseStyleId, "Accesories");

                if (dsAccesories.Tables[0].Rows.Count > 0)
                {
                    cell = new PdfPCell(new Phrase("Accesories", blue));
                    cell.HorizontalAlignment = Element.ALIGN_LEFT;
                    cell.FixedHeight = 15f;       
                    cell.Border = 0;
                    cell.Colspan = 2;
                    table.AddCell(cell);      

                    foreach (DataRow r in dsAccesories.Tables[0].Rows)
                    {
                        if (dsAccesories.Tables[0].Rows.Count > 0)
                        {
                            cell = new PdfPCell(new Phrase(r["indexs"].ToString() + " " + r["RemarksBy"].ToString(), fontRemark));
                            cell.HorizontalAlignment = Element.ALIGN_LEFT;
                            cell.Border = 0;
                            cell.Colspan = 1;
                            table.AddCell(cell);

                            cell = new PdfPCell(new Phrase(r["FabricRemark"].ToString(), fontRemark));
                            cell.HorizontalAlignment = Element.ALIGN_LEFT;
                            cell.Border = 0;
                            cell.Colspan = 1;
                            table.AddCell(cell);

                        }
                    }      
                }
                else
                {
                    cell = new PdfPCell(new Phrase("Accesories", blue));
                    cell.HorizontalAlignment = Element.ALIGN_LEFT;
                    cell.FixedHeight = 15f;    
                    cell.Border = 0;
                    cell.Colspan = 2;
                    table.AddCell(cell);
                }

                //For Rnd Remarks

                DataSet dsRnd = new DataSet();
                dsRnd = ordProcess.GetHOPPMRemarks(stylenumber, styleid, strClientId, DepartmentId, CreateNew, NewRef, ReUse, ReUseStyleId, "RnD");

                if (dsRnd.Tables[0].Rows.Count > 0)
                {
                    cell = new PdfPCell(new Phrase("R&D", blue));
                    cell.HorizontalAlignment = Element.ALIGN_LEFT;
                    cell.FixedHeight = 15f;
                    cell.Border = 0;
                    cell.Colspan = 2;
                    table.AddCell(cell);

                    foreach (DataRow r in dsRnd.Tables[0].Rows)
                    {
                        if (dsRnd.Tables[0].Rows.Count > 0)
                        {
                            cell = new PdfPCell(new Phrase(r["indexs"].ToString() + " " + r["RemarksBy"].ToString(), fontRemark));
                            cell.HorizontalAlignment = Element.ALIGN_LEFT;
                            cell.Border = 0;
                            cell.Colspan = 1;
                            table.AddCell(cell);

                            cell = new PdfPCell(new Phrase(r["FabricRemark"].ToString(), fontRemark));
                            cell.HorizontalAlignment = Element.ALIGN_LEFT;
                            cell.Border = 0;
                            cell.Colspan = 1;
                            table.AddCell(cell);

                        }
                    }
                }
                else
                {
                    cell = new PdfPCell(new Phrase("R&D", blue));
                    cell.HorizontalAlignment = Element.ALIGN_LEFT;
                    cell.FixedHeight = 15f;
                    cell.Border = 0;
                    cell.Colspan = 2;
                    table.AddCell(cell);
                }

                //For Making
                DataSet dsMaking = new DataSet();
                dsMaking = ordProcess.GetHOPPMRemarks(stylenumber, styleid, strClientId, DepartmentId, CreateNew, NewRef, ReUse, ReUseStyleId, "Making");
                if (dsMaking.Tables[0].Rows.Count > 0)
                {
                    cell = new PdfPCell(new Phrase("Making", blue));
                    cell.HorizontalAlignment = Element.ALIGN_LEFT;      
                    cell.FixedHeight = 15f;     

                    cell.Border = 0;
                    cell.Colspan = 2;
                    table.AddCell(cell);

                    foreach (DataRow r in dsMaking.Tables[0].Rows)
                    {
                        if (dsMaking.Tables[0].Rows.Count > 0)
                        {
                            cell = new PdfPCell(new Phrase(r["indexs"].ToString() + " " + r["RemarksBy"].ToString(), fontRemark));
                            cell.HorizontalAlignment = Element.ALIGN_LEFT;
                            cell.Border = 0;
                            cell.Colspan = 1;
                            table.AddCell(cell);


                            cell = new PdfPCell(new Phrase(new Phrase(r["FabricRemark"].ToString(), fontRemark)));
                            cell.HorizontalAlignment = Element.ALIGN_LEFT;
                            cell.Border = 0;
                            cell.Colspan = 1;
                            table.AddCell(cell);

                        }
                    }     
                }
                else
                {
                    cell = new PdfPCell(new Phrase("Making", blue));
                    cell.HorizontalAlignment = Element.ALIGN_LEFT;
                    cell.FixedHeight = 15f;        
                    cell.Colspan = 2;
                    cell.Border = 0;
                    table.AddCell(cell);
            
                }
                //END
                //For Imbroidery
                DataSet dsImbroidery = new DataSet();
                dsImbroidery = ordProcess.GetHOPPMRemarks(stylenumber, styleid, strClientId, DepartmentId, CreateNew, NewRef, ReUse, ReUseStyleId, "Imbroidery");
                if (dsImbroidery.Tables[0].Rows.Count > 0)
                {
                    cell = new PdfPCell(new Phrase("Value Addition", blue));
                    cell.HorizontalAlignment = Element.ALIGN_LEFT;
                    cell.FixedHeight = 15f;
                    cell.Colspan = 2;
          
                    cell.Border = 0;
                    table.AddCell(cell);

                    foreach (DataRow r in dsImbroidery.Tables[0].Rows)
                    {
                        if (dsImbroidery.Tables[0].Rows.Count > 0)
                        {
                            cell = new PdfPCell(new Phrase(r["indexs"].ToString() + " " + r["RemarksBy"].ToString(), fontRemark));
                            cell.HorizontalAlignment = Element.ALIGN_LEFT;
                            cell.Border = 0;
                            cell.Colspan = 1;
                            table.AddCell(cell);


                            cell = new PdfPCell(new Phrase(r["FabricRemark"].ToString(), fontRemark));
                            cell.HorizontalAlignment = Element.ALIGN_LEFT;
                            cell.Border = 0;
                            cell.Colspan = 1;
                            table.AddCell(cell);

                        }
                    }        
                }
                else
                {
                    cell = new PdfPCell(new Phrase("Value Addition", blue));
                    cell.HorizontalAlignment = Element.ALIGN_LEFT;
                    cell.FixedHeight = 15f;          
                    cell.Colspan = 2;
                    cell.Border = 0;
                    table.AddCell(cell);
                }
                //END

                //For Washing

                DataSet dsWashing = new DataSet();
                dsWashing = ordProcess.GetHOPPMRemarks(stylenumber, styleid, strClientId, DepartmentId, CreateNew, NewRef, ReUse, ReUseStyleId, "Washing");
                if (dsWashing.Tables[0].Rows.Count > 0)
                {
                    cell = new PdfPCell(new Phrase("Washing", blue));
                    cell.HorizontalAlignment = Element.ALIGN_LEFT;
                    cell.FixedHeight = 15f; 
                    cell.Colspan = 2;      
                    cell.Border = 0;
                    table.AddCell(cell);

                    foreach (DataRow r in dsWashing.Tables[0].Rows)
                    {
                        if (dsWashing.Tables[0].Rows.Count > 0)
                        {
                            cell = new PdfPCell(new Phrase(r["indexs"].ToString() + " " + r["RemarksBy"].ToString(), fontRemark));
                            cell.HorizontalAlignment = Element.ALIGN_LEFT;
                            cell.Border = 0;
                            cell.Colspan = 1;
                            table.AddCell(cell);


                            cell = new PdfPCell(new Phrase(r["FabricRemark"].ToString(), fontRemark));
                            cell.HorizontalAlignment = Element.ALIGN_LEFT;
                            cell.Border = 0;
                            cell.Colspan = 1;
                            table.AddCell(cell);

                        }
                    }       
                }
                else
                {
                    cell = new PdfPCell(new Phrase("Washing", blue));
                    cell.HorizontalAlignment = Element.ALIGN_LEFT;
                    cell.FixedHeight = 15f;                   
                    cell.Colspan = 2;
                    cell.Border = 0;
                    table.AddCell(cell);
                }
                //END

                //For Finishing
                DataSet dsFinishing = new DataSet();
                dsFinishing = ordProcess.GetHOPPMRemarks(stylenumber, styleid, strClientId, DepartmentId, CreateNew, NewRef, ReUse, ReUseStyleId, "Finishing");
                if (dsFinishing.Tables[0].Rows.Count > 0)
                {
                    cell = new PdfPCell(new Phrase("Finishing/Packing", blue));
                    cell.HorizontalAlignment = Element.ALIGN_LEFT;
                    cell.FixedHeight = 15f;    
                    cell.Border = 0;
                    cell.Colspan = 2;
                    table.AddCell(cell);


                    foreach (DataRow r in dsFinishing.Tables[0].Rows)
                    {
                        if (dsFinishing.Tables[0].Rows.Count > 0)
                        {
                            cell = new PdfPCell(new Phrase(r["indexs"].ToString() + " " + r["RemarksBy"].ToString(), fontRemark));
                            cell.HorizontalAlignment = Element.ALIGN_LEFT;
                            cell.Border = 0;
                            cell.Colspan = 1;
                            table.AddCell(cell);


                            cell = new PdfPCell(new Phrase(r["FabricRemark"].ToString(), fontRemark));
                            cell.HorizontalAlignment = Element.ALIGN_LEFT;
                            cell.Border = 0;
                            cell.Colspan = 1;
                            table.AddCell(cell);
                        }
                    }
                    cell = new PdfPCell(new Phrase("____________________________________________________________________________________________________________________________________", new Font(Font.BOLD, 10, Font.BOLD | Font.BOLD)));
                    cell.HorizontalAlignment = Element.ALIGN_LEFT;
                    cell.FixedHeight = 15f;
                    cell.Border = 0;
                    cell.Colspan = 2;

                    table.AddCell(cell);
                }
                else
                {
                    cell = new PdfPCell(new Phrase("Finishing/Packing", blue));
                    cell.HorizontalAlignment = Element.ALIGN_LEFT;
                    cell.FixedHeight = 15f;             
                    cell.Colspan = 2;
                    cell.Border = 0;
                    table.AddCell(cell);

                }
                //END

                //
                DataSet dsHoPPM = obj_ProcessController.GetHOPPM(stylenumber, styleid, strClientId, DepartmentId, CreateNew, NewRef, ReUse, ReUseStyleId);

                cell = new PdfPCell(new Phrase("Factory Representative", new Font(Font.HELVETICA, 11, Font.NORMAL | Font.NORMAL)));
                cell.HorizontalAlignment = Element.ALIGN_LEFT;
                cell.Border = 0;
                cell.Colspan = 1;
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(":" + UppercaseFirst(dsHoPPM.Tables[0].Rows[0]["FactoryRepresentativeNames"].ToString()), new Font(Font.HELVETICA, 9, Font.NORMAL | Font.NORMAL)));
                cell.HorizontalAlignment = Element.ALIGN_LEFT;
                cell.Border = 0;
                cell.Colspan = 1;
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase("Qa Representative" + ":", new Font(Font.HELVETICA, 11, Font.NORMAL | Font.NORMAL)));
                cell.HorizontalAlignment = Element.ALIGN_LEFT;
                //cell.FixedHeight = 15f;
                cell.Border = 0;
                cell.Colspan = 1;
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(":" + UppercaseFirst(dsHoPPM.Tables[0].Rows[0]["QaRepresentativeNames"].ToString()), new Font(Font.HELVETICA, 9, Font.NORMAL | Font.NORMAL)));
                cell.HorizontalAlignment = Element.ALIGN_LEFT;
                cell.Border = 0;
                cell.Colspan = 1;
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase("Merchandiser Representative", new Font(Font.HELVETICA, 11, Font.NORMAL | Font.NORMAL)));
                cell.HorizontalAlignment = Element.ALIGN_LEFT;
                cell.Border = 0;
                cell.Colspan = 0;
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(":" + UppercaseFirst(dsHoPPM.Tables[0].Rows[0]["MerchandiserRepresentativeName"].ToString()), new Font(Font.HELVETICA, 9, Font.NORMAL | Font.NORMAL)));
                cell.HorizontalAlignment = Element.ALIGN_LEFT;
                cell.Border = 0;
                cell.Colspan = 1;
                table.AddCell(cell);

                //

                //For Representative Approval and Date
                cell = new PdfPCell(new Phrase("____________________________________________________________________________________________________________________________________", new Font(Font.HELVETICA, 10, Font.NORMAL | Font.NORMAL)));
                cell.HorizontalAlignment = Element.ALIGN_LEFT;
                cell.FixedHeight = 15f;
                cell.Border = 0;
                cell.Colspan = 2;
                table.AddCell(cell);

                bool IsQAPreProdApprovedOn = false;
                string QAPreProdApprovedOnDate = "_____________";
                IsQAPreProdApprovedOn = Convert.ToBoolean(dsHoPPM.Tables[0].Rows[0]["IsQAPreProdApprovedOn"]);
                if (IsQAPreProdApprovedOn == true)
                {
                    QAPreProdApprovedOnDate = dsHoPPM.Tables[0].Rows[0]["QAPreProdApprovedOn"] == DBNull.Value ? "" : Convert.ToDateTime(dsHoPPM.Tables[0].Rows[0]["QAPreProdApprovedOn"]).ToString("dd-MMM-yyyy");
                }


                bool IsQAProdApprovedOn = false;
                IsQAProdApprovedOn = Convert.ToBoolean(dsHoPPM.Tables[0].Rows[0]["IsQAProdApprovedOn"]);
                string QAProdApprovedOn = "NO";
                string QAProdApprovedOnDate = "_____________";
                if (IsQAProdApprovedOn == true)
                {
                    QAProdApprovedOn = "Yes";
                    QAProdApprovedOnDate = dsHoPPM.Tables[0].Rows[0]["QAProdApprovedOn"] == DBNull.Value ? "" : Convert.ToDateTime(dsHoPPM.Tables[0].Rows[0]["QAProdApprovedOn"]).ToString("dd-MMM-yyyy");
                }

                bool IsMerchandisingManagerApprovedOn = false;
                IsMerchandisingManagerApprovedOn = Convert.ToBoolean(dsHoPPM.Tables[0].Rows[0]["IsMerchandisingManagerApprovedOn"]);
                string MerchandisingManagerApprovedOn = "NO";
                string MerchandisingManagerApprovedOnDate = "_____________";
                if (IsMerchandisingManagerApprovedOn == true)
                {
                    MerchandisingManagerApprovedOn = "Yes";
                    MerchandisingManagerApprovedOnDate = dsHoPPM.Tables[0].Rows[0]["MerchandisingManagerApprovedOn"] == DBNull.Value ? "" : Convert.ToDateTime(dsHoPPM.Tables[0].Rows[0]["MerchandisingManagerApprovedOn"]).ToString("dd-MMM-yyyy");
                }

                bool IsFactoryPPMComplete = false;
                IsFactoryPPMComplete = Convert.ToBoolean(dsHoPPM.Tables[0].Rows[0]["IsFactoryPPMComplete"]);
                string FactoryPPMComplete = "NO";
                string FactoryPPMCompleteDate = "_____________";
                if (IsFactoryPPMComplete == true)
                {
                    FactoryPPMComplete = "Yes";
                    FactoryPPMCompleteDate = dsHoPPM.Tables[0].Rows[0]["FactoryPPMCompleteOn"] == DBNull.Value ? "" : Convert.ToDateTime(dsHoPPM.Tables[0].Rows[0]["FactoryPPMCompleteOn"]).ToString("dd-MMM-yyyy");
                }

                bool IsHOPPMComplete = false;
                IsHOPPMComplete = Convert.ToBoolean(dsHoPPM.Tables[0].Rows[0]["IsHOPPMComplete"]);
                string HOPPMComplete = "NO";
                string HOPPMCompleteDate = "_____________";
                if (IsHOPPMComplete == true)
                {
                    HOPPMComplete = "Yes";
                    HOPPMCompleteDate = dsHoPPM.Tables[0].Rows[0]["HOPPMCompleteOn"] == DBNull.Value ? "" : Convert.ToDateTime(dsHoPPM.Tables[0].Rows[0]["HOPPMCompleteOn"]).ToString("dd-MMM-yyyy");
                }

                bool ISSeam_Slippage_OK = false;
                ISSeam_Slippage_OK = Convert.ToBoolean(dsHoPPM.Tables[0].Rows[0]["Seam_Slippage_OK"]);
                string ISSeam_Slippage_Ok_Comeplete = "NO";
                string ISSeam_Slippage_DATE = "_____________";
                if (ISSeam_Slippage_OK == true)
                {
                    ISSeam_Slippage_Ok_Comeplete = "Yes";
                    ISSeam_Slippage_DATE = dsHoPPM.Tables[0].Rows[0]["SeamSlippageOK"] == DBNull.Value ? "" : Convert.ToDateTime(dsHoPPM.Tables[0].Rows[0]["SeamSlippageOK"]).ToString("dd-MMM-yyyy");

                }

                //For Representative Approved Date
                cell = new PdfPCell(new Phrase("Attended By GM QA: " + QAProdApprovedOn + " |  " + "Signed Off By DMM: " + MerchandisingManagerApprovedOn + " |  " + "FactoryPPMComplete: " + FactoryPPMComplete + " |  " + "HOPPMComplete: " + HOPPMComplete + " |  " + " 	Seam Slippage OK: " + ISSeam_Slippage_Ok_Comeplete, new Font(Font.BOLD, 7, Font.BOLD | Font.BOLD)));
                cell.HorizontalAlignment = Element.ALIGN_LEFT;
                cell.FixedHeight = 15f;
                cell.Border = 0;
                cell.Colspan = 2;
                table.AddCell(cell);


                cell = new PdfPCell(new Phrase(QAProdApprovedOnDate + "  " + "                  " + MerchandisingManagerApprovedOnDate + " " + "                    " + FactoryPPMCompleteDate + "  " + "                       " + HOPPMCompleteDate + "  " + "                     " + ISSeam_Slippage_DATE, new Font(Font.BOLD, 7, Font.BOLD | Font.BOLD)));
                cell.HorizontalAlignment = Element.ALIGN_LEFT;
                cell.FixedHeight = 15f;
                cell.Border = 0;
                cell.Colspan = 2;
                table.AddCell(cell);
      
                cell = new PdfPCell(new Phrase("IE Finalize OB W/S SAM Task Is Incomplete", new Font(Font.BOLD, 7, Font.BOLD | Font.BOLD, Color.BLUE)));
                cell.HorizontalAlignment = Element.ALIGN_LEFT;
                cell.FixedHeight = 15f;
                cell.Border = 0;
                cell.Colspan = 2;
                table.AddCell(cell);

                //For Note 2
                cell = new PdfPCell(new Phrase("* (This PPM Shall Be Deemed Incomplete Unless Attended By Both Pre Production QA Mgr And Production QA Mgr)", new Font(Font.BOLD, 7, Font.BOLD | Font.BOLD, Color.BLUE)));
                cell.HorizontalAlignment = Element.ALIGN_LEFT;
                cell.FixedHeight = 15f;
                cell.Border = 0;
                cell.Colspan = 2;
                table.AddCell(cell);

                //END


                document.Add(table);
                document.Close();
                ShowPdf(fileName);

            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
            }
            return fileName;
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
        public HttpResponse Response
        {
            get;
            set;
        }

        public string UppercaseFirst(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }
            return char.ToUpper(s[0]) + s.Substring(1);
        }

        //updated abhishek on 30/6/2016
        public string GetPrintRisk(string stylenumber, int styleid, int strClientId, int DepartmentId, int OrderId, int CreateNew, int NewRef, int ReUse, int ReUseStyleId, string RemarksType)
        {
            string fileName = "Risk ReportTest -" + DateTime.Now.ToString("dd MMM yyy") + ".pdf";
            string BasicInformation = "";
            if (!Directory.Exists(Constants.TEMP_FOLDER_PATH))
                Directory.CreateDirectory(Constants.TEMP_FOLDER_PATH);

            string pdfFilePath = Path.Combine(Constants.TEMP_FOLDER_PATH, fileName);



            try
            {
                Document document = new Document();
                PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(pdfFilePath, FileMode.Create));
                document.Open();
                iTextSharp.text.Font fontRemarkHeader = iTextSharp.text.FontFactory.GetFont(FontFactory.HELVETICA, 10);

                iTextSharp.text.Font fontRemark = iTextSharp.text.FontFactory.GetFont(FontFactory.HELVETICA, 8);

                iKandi.BLL.OrderProcessController ordProcess = new OrderProcessController();

                DataSet dsFabric = new DataSet();
                dsFabric = ordProcess.GetRiskRemark(stylenumber, styleid, strClientId, DepartmentId, CreateNew, NewRef, ReUse, ReUseStyleId, "Fabric");


                //abhishek for fabric sec limitation remarks..
                DataSet dsgrdLimitation = new DataSet();
                dsgrdLimitation = ordProcess.GetRiskRemarkForLimitation(stylenumber, styleid, strClientId, DepartmentId, CreateNew, NewRef, ReUse, ReUseStyleId, "Fabric");


                PdfPTable table = new PdfPTable(2);
                float[] widths = new float[] { 2f, 6f };

                table.SetWidths(widths);
                table.WidthPercentage = 100;
                PdfPCell cell = new PdfPCell(new Phrase("Risk Report"));
                table.HeaderRows = 1;
                cell.Colspan = 2;

                iKandi.BLL.OrderProcessController obj_ProcessController = new BLL.OrderProcessController();
                DataSet dsStyle = obj_ProcessController.GetStyleNumberClientDept(styleid, ReUseStyleId, strClientId, DepartmentId, CreateNew, NewRef, ReUse, 1);
                if (dsStyle.Tables[0].Rows.Count > 0)
                {
                    string StyleDetail = "";

                    for (int i = 0; i < dsStyle.Tables[0].Rows.Count; i++)
                    {
                        StyleDetail = StyleDetail + " [" + dsStyle.Tables[0].Rows[i]["StyleDetail"].ToString() + "],";

                    }

                    BasicInformation = StyleDetail.TrimEnd(',');
                }

                Font blue = FontFactory.GetFont("HELVETICA", 10, Font.BOLD, new Color(72, 99, 160));


                //For Header 
                cell = new PdfPCell(new Phrase("Risk Analysis Report", blue));
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                //cell.Width = 10;
                cell.FixedHeight = 15f;
                cell.Border = 0;
                cell.Colspan = 2;

                table.AddCell(cell);

                cell = new PdfPCell(new Phrase("", blue));
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                //cell.Width = 10;
                cell.FixedHeight = 15f;
                cell.Border = 0;
                cell.Colspan = 2;

                table.AddCell(cell);

                //END

                //For Header Style
                cell = new PdfPCell(new Phrase("BASIC INFORMATION:" + BasicInformation.ToUpper(), new Font(Font.HELVETICA, 12, Font.BOLD | Font.NORMAL)));
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                cell.Border = 0;
                cell.Colspan = 2;

                table.AddCell(cell);
                //END           


                //For Fabric Remarks
                if (dsFabric.Tables[0].Rows.Count > 0)
                {
                    cell = new PdfPCell(new Phrase("Fabric", blue));
                    cell.HorizontalAlignment = Element.ALIGN_LEFT;
                    cell.FixedHeight = 15f;
                    //cell.BorderWidthTop = 0.3f;
                    //cell.BorderWidthLeft = 0.3f;
                    //cell.BorderWidthRight = 0.3f;
                    //cell.BorderWidthBottom = 0.3f;
                    cell.Colspan = 2;
                    cell.Border = 0;

                    table.AddCell(cell);


                    //foreach (DataColumn c in dsFabric.Tables[0].Columns)
                    //{
                    //    if (c.ColumnName == "RemarksBy")
                    //    {
                    //        // table.AddCell(new Phrase(c.ColumnName, fontRemarkHeader));
                    //        cell = new PdfPCell(new Phrase("RemarksBy", new Font(Font.HELVETICA, 8, Font.BOLD | Font.NORMAL)));
                    //        cell.HorizontalAlignment = Element.ALIGN_LEFT;
                    //        cell.Border = 0;
                    //        cell.Colspan = 1;
                    //        table.AddCell(cell);

                    //    }
                    //    if (c.ColumnName == "FabricRemark")
                    //    {
                    //        cell = new PdfPCell(new Phrase("Remark", new Font(Font.HELVETICA, 8, Font.BOLD | Font.NORMAL)));
                    //        cell.HorizontalAlignment = Element.ALIGN_LEFT;
                    //        cell.Border = 0;
                    //        cell.Colspan = 1;
                    //        table.AddCell(cell);
                    //    }
                    //}


                    foreach (DataRow r in dsgrdLimitation.Tables[0].Rows)
                    {
                        if (dsgrdLimitation.Tables[0].Rows.Count > 0)
                        {
                            cell = new PdfPCell(new Phrase(new Phrase(r["indexs"].ToString() + " " + r["RemarksBy"].ToString(), fontRemark)));
                            cell.HorizontalAlignment = Element.ALIGN_LEFT;
                            cell.Border = 0;
                            cell.Colspan = 1;
                            table.AddCell(cell);

                            cell = new PdfPCell(new Phrase(new Phrase(r["FabricRemark"].ToString(), fontRemark)));
                            cell.HorizontalAlignment = Element.ALIGN_LEFT;
                            cell.Border = 0;
                            cell.Colspan = 1;
                            table.AddCell(cell);

                        }
                    }
                    foreach (DataRow r in dsFabric.Tables[0].Rows)
                    {
                        if (dsFabric.Tables[0].Rows.Count > 0)
                        {
                            cell = new PdfPCell(new Phrase(new Phrase(r["indexs"].ToString() + " " + r["RemarksBy"].ToString(), fontRemark)));
                            cell.HorizontalAlignment = Element.ALIGN_LEFT;
                            cell.Border = 0;
                            cell.Colspan = 1;
                            table.AddCell(cell);

                            cell = new PdfPCell(new Phrase(new Phrase(r["FabricRemark"].ToString(), fontRemark)));
                            cell.HorizontalAlignment = Element.ALIGN_LEFT;
                            cell.Border = 0;
                            cell.Colspan = 1;
                            table.AddCell(cell);

                        }
                    }

                }
                else
                {
                    cell = new PdfPCell(new Phrase("Fabric", blue));
                    cell.HorizontalAlignment = Element.ALIGN_LEFT;
                    cell.FixedHeight = 15f;
                    //cell.Border = 1;
                    //cell.BorderWidthLeft = 0.3f;
                    //cell.BorderWidthRight = 0.3f;
                    //cell.Border = 1;
                    cell.Colspan = 2;
                    cell.Border = 0;
                    table.AddCell(cell);

                    foreach (DataRow r in dsgrdLimitation.Tables[0].Rows)
                    {
                        if (dsgrdLimitation.Tables[0].Rows.Count > 0)
                        {
                            cell = new PdfPCell(new Phrase(new Phrase(r["indexs"].ToString() + " " + r["RemarksBy"].ToString(), fontRemark)));
                            cell.HorizontalAlignment = Element.ALIGN_LEFT;
                            cell.Border = 0;
                            cell.Colspan = 1;
                            table.AddCell(cell);

                            cell = new PdfPCell(new Phrase(new Phrase(r["FabricRemark"].ToString(), fontRemark)));
                            cell.HorizontalAlignment = Element.ALIGN_LEFT;
                            cell.Border = 0;
                            cell.Colspan = 1;
                            table.AddCell(cell);

                        }
                    }



                }

                //END
                //For Accesories Remarks
                DataSet dsAccesories = new DataSet();
                dsAccesories = ordProcess.GetRiskRemark(stylenumber, styleid, strClientId, DepartmentId, CreateNew, NewRef, ReUse, ReUseStyleId, "Accesories");

                DataSet dsgrdLimitationAccesories = new DataSet();
                dsgrdLimitationAccesories = ordProcess.GetRiskRemarkForLimitation(stylenumber, styleid, strClientId, DepartmentId, CreateNew, NewRef, ReUse, ReUseStyleId, "Accesories");

                if (dsAccesories.Tables[0].Rows.Count > 0)
                {
                    cell = new PdfPCell(new Phrase("Accesories", blue));
                    cell.HorizontalAlignment = Element.ALIGN_LEFT;
                    cell.FixedHeight = 15f;
                    //cell.BorderWidthTop = 0.3f;
                    //cell.BorderWidthLeft = 0.3f;
                    //cell.BorderWidthRight = 0.3f;
                    //cell.BorderWidthBottom = 0.3f;
                    cell.Colspan = 2;
                    cell.Border = 0;
                    table.AddCell(cell);


                    //foreach (DataColumn c in dsAccesories.Tables[0].Columns)
                    //{
                    //    if (c.ColumnName == "RemarksBy")
                    //    {
                    //        // table.AddCell(new Phrase(c.ColumnName, fontRemarkHeader));
                    //        cell = new PdfPCell(new Phrase("RemarksBy", new Font(Font.HELVETICA, 8, Font.BOLD | Font.NORMAL)));
                    //        cell.HorizontalAlignment = Element.ALIGN_LEFT;
                    //        cell.Border = 0;
                    //        cell.Colspan = 1;
                    //        table.AddCell(cell);

                    //    }
                    //    if (c.ColumnName == "AccessoryRemark")
                    //    {
                    //        cell = new PdfPCell(new Phrase("Remark", new Font(Font.HELVETICA, 8, Font.BOLD | Font.NORMAL)));
                    //        cell.HorizontalAlignment = Element.ALIGN_LEFT;
                    //        cell.Border = 0;
                    //        cell.Colspan = 1;
                    //        table.AddCell(cell);
                    //    }

                    //}
                    //DataSet dsgrdLimitation = new DataSet();
                    //dsgrdLimitation = ordProcess.GetRiskRemarkForLimitation(stylenumber, styleid, strClientId, DepartmentId, CreateNew, NewRef, ReUse, ReUseStyleId, "Accesories");

                    foreach (DataRow r in dsgrdLimitationAccesories.Tables[0].Rows)
                    {
                        if (dsgrdLimitationAccesories.Tables[0].Rows.Count > 0)
                        {
                            cell = new PdfPCell(new Phrase(new Phrase(r["indexs"].ToString() + " " + r["RemarksBy"].ToString(), fontRemark)));
                            cell.HorizontalAlignment = Element.ALIGN_LEFT;
                            cell.Border = 0;
                            cell.Colspan = 1;
                            table.AddCell(cell);

                            cell = new PdfPCell(new Phrase(new Phrase(r["AccessoryRemark"].ToString(), fontRemark)));
                            cell.HorizontalAlignment = Element.ALIGN_LEFT;
                            cell.Border = 0;
                            cell.Colspan = 1;
                            table.AddCell(cell);

                        }
                    }
                    foreach (DataRow r in dsAccesories.Tables[0].Rows)
                    {
                        if (dsAccesories.Tables[0].Rows.Count > 0)
                        {
                            cell = new PdfPCell(new Phrase(r["indexs"].ToString() + " " + r["RemarksBy"].ToString(), fontRemark));
                            cell.HorizontalAlignment = Element.ALIGN_LEFT;
                            cell.Border = 0;
                            cell.Colspan = 1;
                            table.AddCell(cell);

                            cell = new PdfPCell(new Phrase(r["AccessoryRemark"].ToString(), fontRemark));
                            cell.HorizontalAlignment = Element.ALIGN_LEFT;
                            cell.Border = 0;
                            cell.Colspan = 1;
                            table.AddCell(cell);

                        }
                    }
                    //cell = new PdfPCell(new Phrase("____________________________________________________________________________________________________________________________________", new Font(Font.BOLD, 10, Font.BOLD | Font.BOLD)));
                }
                else
                {
                    cell = new PdfPCell(new Phrase("Accesories", blue));
                    cell.HorizontalAlignment = Element.ALIGN_LEFT;
                    //cell.Width = 10;
                    cell.FixedHeight = 15f;
                    //cell.Border = 1;
                    //cell.BorderWidthLeft = 0.3f;
                    //cell.BorderWidthRight = 0.3f;
                    //cell.Border = 1;
                    cell.Colspan = 2;
                    cell.Border = 0;
                    table.AddCell(cell);


                    foreach (DataRow r in dsgrdLimitationAccesories.Tables[0].Rows)
                    {
                        if (dsgrdLimitationAccesories.Tables[0].Rows.Count > 0)
                        {
                            cell = new PdfPCell(new Phrase(new Phrase(r["indexs"].ToString() + " " + r["RemarksBy"].ToString(), fontRemark)));
                            cell.HorizontalAlignment = Element.ALIGN_LEFT;
                            cell.Border = 0;
                            cell.Colspan = 1;
                            table.AddCell(cell);

                            cell = new PdfPCell(new Phrase(new Phrase(r["AccessoryRemark"].ToString(), fontRemark)));
                            cell.HorizontalAlignment = Element.ALIGN_LEFT;
                            cell.Border = 0;
                            cell.Colspan = 1;
                            table.AddCell(cell);

                        }
                    }

                }

                //END

                //For Fitting Remarks
                DataSet dsFitting = new DataSet();
                dsFitting = ordProcess.GetRiskRemark(stylenumber, styleid, strClientId, DepartmentId, CreateNew, NewRef, ReUse, ReUseStyleId, "Fitting");

                if (dsFitting.Tables[0].Rows.Count > 0)
                {
                    cell = new PdfPCell(new Phrase("Fitting", blue));
                    cell.HorizontalAlignment = Element.ALIGN_LEFT;
                    //cell.Width = 10;
                    cell.FixedHeight = 15f;
                    //cell.BorderWidthTop = 0.3f;
                    //cell.BorderWidthLeft = 0.3f;
                    //cell.BorderWidthRight = 0.3f;
                    //cell.BorderWidthBottom = 0.3f;
                    cell.Colspan = 2;
                    cell.Border = 0;
                    table.AddCell(cell);

                    //foreach (DataColumn c in dsFitting.Tables[0].Columns)
                    //{
                    //    if (c.ColumnName == "RemarksBy")
                    //    {
                    //        // table.AddCell(new Phrase(c.ColumnName, fontRemarkHeader));
                    //        cell = new PdfPCell(new Phrase("RemarksBy", new Font(Font.HELVETICA, 8, Font.BOLD | Font.NORMAL)));
                    //        cell.HorizontalAlignment = Element.ALIGN_LEFT;
                    //        cell.Border = 0;
                    //        cell.Colspan = 1;
                    //        table.AddCell(cell);

                    //    }
                    //    if (c.ColumnName == "FittingRemark")
                    //    {
                    //        cell = new PdfPCell(new Phrase("Remark", new Font(Font.HELVETICA, 8, Font.BOLD | Font.NORMAL)));
                    //        cell.HorizontalAlignment = Element.ALIGN_LEFT;
                    //        cell.Border = 0;
                    //        cell.Colspan = 1;
                    //        table.AddCell(cell);
                    //    }


                    //}

                    foreach (DataRow r in dsFitting.Tables[0].Rows)
                    {
                        if (dsFitting.Tables[0].Rows.Count > 0)
                        {

                            cell = new PdfPCell(new Phrase(r["indexs"].ToString() + " " + r["RemarksBy"].ToString(), fontRemark));
                            cell.HorizontalAlignment = Element.ALIGN_LEFT;
                            cell.Border = 0;
                            cell.Colspan = 1;
                            table.AddCell(cell);

                            cell = new PdfPCell(new Phrase(r["FittingRemark"].ToString(), fontRemark));
                            cell.HorizontalAlignment = Element.ALIGN_LEFT;
                            cell.Border = 0;
                            cell.Colspan = 1;
                            table.AddCell(cell);

                            //table.AddCell(new Phrase(r[2].ToString(), fontRemark));
                            //table.AddCell(new Phrase(r[3].ToString(), fontRemark));
                        }
                    }
                }
                else
                {
                    cell = new PdfPCell(new Phrase("Fitting", blue));
                    cell.HorizontalAlignment = Element.ALIGN_LEFT;
                    cell.FixedHeight = 15f;
                    //cell.BorderWidthLeft = 0.3f;
                    //cell.BorderWidthRight = 0.3f;
                    cell.Colspan = 2;
                    //cell.Border = 1;
                    cell.Border = 0;
                    table.AddCell(cell);

                }

                //END


                //For Making Remarks
                DataSet dsMaking = new DataSet();
                dsMaking = ordProcess.GetRiskRemark(stylenumber, styleid, strClientId, DepartmentId, CreateNew, NewRef, ReUse, ReUseStyleId, "Making");

                if (dsMaking.Tables[0].Rows.Count > 0)
                {
                    cell = new PdfPCell(new Phrase("Making", blue));
                    cell.HorizontalAlignment = Element.ALIGN_LEFT;
                    //cell.BorderWidthTop = 0.3f;
                    //cell.BorderWidthLeft = 0.3f;
                    //cell.BorderWidthRight = 0.3f;
                    //cell.BorderWidthBottom = 0.3f;
                    cell.FixedHeight = 15f;
                    cell.Colspan = 2;
                    cell.Border = 0;
                    table.AddCell(cell);

                    //foreach (DataColumn c in dsMaking.Tables[0].Columns)
                    //{
                    //    if (c.ColumnName == "RemarksBy")
                    //    {
                    //        // table.AddCell(new Phrase(c.ColumnName, fontRemarkHeader));
                    //        cell = new PdfPCell(new Phrase("RemarksBy", new Font(Font.HELVETICA, 8, Font.BOLD | Font.NORMAL)));
                    //        cell.HorizontalAlignment = Element.ALIGN_LEFT;
                    //        cell.Border = 0;
                    //        cell.Colspan = 1;
                    //        table.AddCell(cell);

                    //    }
                    //    if (c.ColumnName == "MakingRemark")
                    //    {
                    //        cell = new PdfPCell(new Phrase("Remark", new Font(Font.HELVETICA, 8, Font.BOLD | Font.NORMAL)));
                    //        cell.HorizontalAlignment = Element.ALIGN_LEFT;
                    //        cell.Border = 0;
                    //        cell.Colspan = 1;
                    //        table.AddCell(cell);
                    //    }


                    //}

                    foreach (DataRow r in dsMaking.Tables[0].Rows)
                    {
                        if (dsMaking.Tables[0].Rows.Count > 0)
                        {
                            cell = new PdfPCell(new Phrase(r["indexs"].ToString() + " " + r["RemarksBy"].ToString(), fontRemark));
                            cell.HorizontalAlignment = Element.ALIGN_LEFT;
                            cell.Border = 0;
                            cell.Colspan = 1;
                            table.AddCell(cell);

                            cell = new PdfPCell(new Phrase(r["MakingRemark"].ToString(), fontRemark));
                            cell.HorizontalAlignment = Element.ALIGN_LEFT;
                            cell.Border = 0;
                            cell.Colspan = 1;
                            table.AddCell(cell);
                        }
                    }
                }
                else
                {
                    cell = new PdfPCell(new Phrase("Making", blue));
                    cell.HorizontalAlignment = Element.ALIGN_LEFT;
                    //cell.Width = 10;
                    cell.FixedHeight = 15f;
                    //cell.BorderWidthLeft = 0.3f;
                    //cell.BorderWidthRight = 0.3f;
                    //cell.Border = 1;
                    cell.Colspan = 2;
                    cell.Border = 0;
                    table.AddCell(cell);
                }

                //END

                //For Imbroidery Remarks
                DataSet dsImbroidery = new DataSet();
                dsImbroidery = ordProcess.GetRiskRemark(stylenumber, styleid, strClientId, DepartmentId, CreateNew, NewRef, ReUse, ReUseStyleId, "Imbroidery");

                if (dsImbroidery.Tables[0].Rows.Count > 0)
                {
                    cell = new PdfPCell(new Phrase("Value Addition", blue));
                    cell.HorizontalAlignment = Element.ALIGN_LEFT;
                    cell.FixedHeight = 15f;
                    //cell.BorderWidthTop = 0.3f;
                    //cell.BorderWidthLeft = 0.3f;
                    //cell.BorderWidthRight = 0.3f;
                    //cell.BorderWidthBottom = 0.3f;
                    cell.Colspan = 2;
                    cell.Border = 0;
                    table.AddCell(cell);

                    //foreach (DataColumn c in dsImbroidery.Tables[0].Columns)
                    //{
                    //    if (c.ColumnName == "RemarksBy")
                    //    {
                    //        // table.AddCell(new Phrase(c.ColumnName, fontRemarkHeader));
                    //        cell = new PdfPCell(new Phrase("RemarksBy", new Font(Font.HELVETICA, 8, Font.BOLD | Font.NORMAL)));
                    //        cell.HorizontalAlignment = Element.ALIGN_LEFT;
                    //        cell.Border = 0;
                    //        cell.Colspan = 1;
                    //        table.AddCell(cell);

                    //    }
                    //    if (c.ColumnName == "ImbroideryRemark")
                    //    {
                    //        cell = new PdfPCell(new Phrase("Remark", new Font(Font.HELVETICA, 8, Font.BOLD | Font.NORMAL)));
                    //        cell.HorizontalAlignment = Element.ALIGN_LEFT;
                    //        cell.Border = 0;
                    //        cell.Colspan = 1;
                    //        table.AddCell(cell);
                    //    }


                    //}

                    foreach (DataRow r in dsImbroidery.Tables[0].Rows)
                    {
                        if (dsImbroidery.Tables[0].Rows.Count > 0)
                        {
                            cell = new PdfPCell(new Phrase(r["indexs"].ToString() + " " + r["RemarksBy"].ToString(), fontRemark));
                            cell.HorizontalAlignment = Element.ALIGN_LEFT;
                            cell.Border = 0;
                            cell.Colspan = 1;
                            table.AddCell(cell);

                            cell = new PdfPCell(new Phrase(r["ImbroideryRemark"].ToString(), fontRemark));
                            cell.HorizontalAlignment = Element.ALIGN_LEFT;
                            cell.Border = 0;
                            cell.Colspan = 1;
                            table.AddCell(cell);
                        }
                    }
                }
                else
                {
                    cell = new PdfPCell(new Phrase("Value Addition", blue));
                    cell.HorizontalAlignment = Element.ALIGN_LEFT;
                    //cell.Width = 10;
                    cell.FixedHeight = 15f;
                    //cell.BorderWidthLeft = 0.3f;
                    //cell.BorderWidthRight = 0.3f;
                    //cell.Border = 1;
                    cell.Colspan = 2;
                    cell.Border = 0;
                    table.AddCell(cell);

                }

                //END

                //For Washing Remarks
                DataSet dsWashing = new DataSet();
                dsWashing = ordProcess.GetRiskRemark(stylenumber, styleid, strClientId, DepartmentId, CreateNew, NewRef, ReUse, ReUseStyleId, "Washing");

                if (dsWashing.Tables[0].Rows.Count > 0)
                {
                    cell = new PdfPCell(new Phrase("Washing", blue));
                    cell.HorizontalAlignment = Element.ALIGN_LEFT;
                    //cell.Width = 10;
                    cell.FixedHeight = 15f;
                    //cell.BorderWidthTop = 0.3f;
                    //cell.BorderWidthLeft = 0.3f;
                    //cell.BorderWidthRight = 0.3f;
                    //cell.BorderWidthBottom = 0.3f;
                    cell.Colspan = 2;
                    cell.Border = 0;
                    table.AddCell(cell);

                    //foreach (DataColumn c in dsWashing.Tables[0].Columns)
                    //{
                    //    if (c.ColumnName == "RemarksBy")
                    //    {
                    //        // table.AddCell(new Phrase(c.ColumnName, fontRemarkHeader));
                    //        cell = new PdfPCell(new Phrase("RemarksBy", new Font(Font.HELVETICA, 8, Font.BOLD | Font.NORMAL)));
                    //        cell.HorizontalAlignment = Element.ALIGN_LEFT;
                    //        cell.Border = 0;
                    //        cell.Colspan = 1;
                    //        table.AddCell(cell);

                    //    }
                    //    if (c.ColumnName == "WashingRemark")
                    //    {
                    //        cell = new PdfPCell(new Phrase("Remark", new Font(Font.HELVETICA, 8, Font.BOLD | Font.NORMAL)));
                    //        cell.HorizontalAlignment = Element.ALIGN_LEFT;
                    //        cell.Border = 0;
                    //        cell.Colspan = 1;
                    //        table.AddCell(cell);
                    //    }

                    //}

                    foreach (DataRow r in dsWashing.Tables[0].Rows)
                    {
                        if (dsWashing.Tables[0].Rows.Count > 0)
                        {
                            cell = new PdfPCell(new Phrase(r["indexs"].ToString() + " " + r["RemarksBy"].ToString(), fontRemark));
                            cell.HorizontalAlignment = Element.ALIGN_LEFT;
                            cell.Border = 0;
                            cell.Colspan = 1;
                            table.AddCell(cell);

                            cell = new PdfPCell(new Phrase(r["WashingRemark"].ToString(), fontRemark));
                            cell.HorizontalAlignment = Element.ALIGN_LEFT;
                            cell.Border = 0;
                            cell.Colspan = 1;
                            table.AddCell(cell);

                        }
                    }
                }
                else
                {
                    cell = new PdfPCell(new Phrase("Washing", blue));
                    cell.HorizontalAlignment = Element.ALIGN_LEFT;
                    //cell.Width = 10;
                    cell.FixedHeight = 15f;
                    //cell.BorderWidthLeft = 0.3f;
                    //cell.BorderWidthRight = 0.3f;
                    //cell.Border = 1;
                    cell.Colspan = 2;
                    cell.Border = 0;
                    table.AddCell(cell);

                }

                //END

                //For Finishing Remarks
                DataSet dsFinishing = new DataSet();
                dsFinishing = ordProcess.GetRiskRemark(stylenumber, styleid, strClientId, DepartmentId, CreateNew, NewRef, ReUse, ReUseStyleId, "Finishing");

                if (dsFinishing.Tables[0].Rows.Count > 0)
                {
                    cell = new PdfPCell(new Phrase("Finishing/Packing", blue));
                    cell.HorizontalAlignment = Element.ALIGN_LEFT;
                    cell.FixedHeight = 15f;
                    //cell.BorderWidthTop = 0.3f;
                    //cell.BorderWidthLeft = 0.3f;
                    //cell.BorderWidthRight = 0.3f;
                    //cell.BorderWidthBottom = 0.3f;
                    cell.Colspan = 2;
                    cell.Border = 0;
                    table.AddCell(cell);

                    //foreach (DataColumn c in dsFinishing.Tables[0].Columns)
                    //{
                    //    if (c.ColumnName == "RemarksBy")
                    //    {
                    //        cell = new PdfPCell(new Phrase("RemarksBy", new Font(Font.HELVETICA, 8, Font.BOLD | Font.NORMAL)));
                    //        cell.HorizontalAlignment = Element.ALIGN_LEFT;
                    //        cell.Border = 0;
                    //        cell.Colspan = 1;
                    //        table.AddCell(cell);

                    //    }
                    //    if (c.ColumnName == "FinishingRemark")
                    //    {
                    //        cell = new PdfPCell(new Phrase("Remark", new Font(Font.HELVETICA, 8, Font.BOLD | Font.NORMAL)));
                    //        cell.HorizontalAlignment = Element.ALIGN_LEFT;
                    //        cell.Border = 0;
                    //        cell.Colspan = 1;
                    //        table.AddCell(cell);
                    //    }

                    //}

                    foreach (DataRow r in dsFinishing.Tables[0].Rows)
                    {
                        if (dsFinishing.Tables[0].Rows.Count > 0)
                        {
                            cell = new PdfPCell(new Phrase(r["indexs"].ToString() + " " + r["RemarksBy"].ToString(), fontRemark));
                            cell.HorizontalAlignment = Element.ALIGN_LEFT;
                            cell.Border = 0;
                            cell.Colspan = 1;
                            table.AddCell(cell);

                            cell = new PdfPCell(new Phrase(r["FinishingRemark"].ToString(), fontRemark));
                            cell.HorizontalAlignment = Element.ALIGN_LEFT;
                            cell.Border = 0;
                            cell.Colspan = 1;
                            table.AddCell(cell);

                        }
                    }
                }
                else
                {
                    cell = new PdfPCell(new Phrase("Finishing/Packing", blue));
                    cell.HorizontalAlignment = Element.ALIGN_LEFT;
                    //cell.Width = 10;
                    cell.FixedHeight = 15f;
                    //cell.BorderWidthTop = 0.3f;
                    //cell.BorderWidthLeft = 0.3f;
                    //cell.BorderWidthRight = 0.3f;
                    //cell.BorderWidthBottom = 0.3f;
                    cell.Colspan = 2;
                    cell.Border = 0;
                    table.AddCell(cell);




                    cell = new PdfPCell(new Phrase("____________________________________________________________________________________________________________________________________", new Font(Font.HELVETICA, 10, Font.NORMAL | Font.NORMAL)));
                    cell.HorizontalAlignment = Element.ALIGN_LEFT;
                    //cell.Width = 10;
                    cell.FixedHeight = 15f;
                    cell.Border = 1;
                    cell.Colspan = 2;
                    cell.Border = 0;
                    table.AddCell(cell);
                } cell.Border = 1;

                //END
                cell = new PdfPCell(new Phrase("", new Font(Font.HELVETICA, 10, Font.NORMAL | Font.NORMAL)));
                cell.HorizontalAlignment = Element.ALIGN_LEFT;
                //cell.Width = 10;
                cell.FixedHeight = 10f;
                cell.Border = 0;
                cell.Colspan = 2;
                table.AddCell(cell);

                DataSet dsRiskAnalysis = obj_ProcessController.GetRiskAnalysis(stylenumber, styleid, strClientId, DepartmentId, OrderId, CreateNew, NewRef, ReUse, ReUseStyleId);

                bool IsAccountManager = false;
                string AccountManagerOn = "No";
                string AccountManagerDate = "_____________";
                IsAccountManager = Convert.ToBoolean(dsRiskAnalysis.Tables[0].Rows[0]["IsAccountMgr"]);
                if (IsAccountManager == true)
                {
                    AccountManagerOn = "Yes";
                    AccountManagerDate = dsRiskAnalysis.Tables[0].Rows[0]["AccountMgrApprovedOn"] == DBNull.Value ? "" : Convert.ToDateTime(dsRiskAnalysis.Tables[0].Rows[0]["AccountMgrApprovedOn"]).ToString("dd-MMM-yyyy");
                }


                bool IsQAPreProd = false;
                IsQAPreProd = Convert.ToBoolean(dsRiskAnalysis.Tables[0].Rows[0]["IsQAPreProd"]);
                
                string QAPreProdDate = "_____________";
                if (IsQAPreProd == true)
                {                
                    QAPreProdDate = dsRiskAnalysis.Tables[0].Rows[0]["QAPreProdApprovedOn"] == DBNull.Value ? "" : Convert.ToDateTime(dsRiskAnalysis.Tables[0].Rows[0]["QAPreProdApprovedOn"]).ToString("dd-MMM-yyyy");
                }

                bool IsQAProd = false;
                IsQAProd = Convert.ToBoolean(dsRiskAnalysis.Tables[0].Rows[0]["IsQAProd"]);
                string QAProdOn = "NO";
                string QAProdDate = "_____________";
                if (IsQAProd == true)
                {
                    QAProdOn = "Yes";
                    QAProdDate = dsRiskAnalysis.Tables[0].Rows[0]["QAProdApprovedOn"] == DBNull.Value ? "" : Convert.ToDateTime(dsRiskAnalysis.Tables[0].Rows[0]["QAProdApprovedOn"]).ToString("dd-MMM-yyyy");
                }

                bool IsMerchandisingMgr = false;
                IsMerchandisingMgr = Convert.ToBoolean(dsRiskAnalysis.Tables[0].Rows[0]["IsMerchandisingMgr"]);
                
                string MerchandisingMgrDate = "_____________";
                if (IsMerchandisingMgr == true)
                {
                    
                    MerchandisingMgrDate = dsRiskAnalysis.Tables[0].Rows[0]["MerchandisingMgrApprovedOn"] == DBNull.Value ? "" : Convert.ToDateTime(dsRiskAnalysis.Tables[0].Rows[0]["MerchandisingMgrApprovedOn"]).ToString("dd-MMM-yyyy");
                }



                //For Representative Approved Date
                cell = new PdfPCell(new Phrase("Signed Off by Fits/ Account Manager: " + AccountManagerOn + " |                    " + "Signed Off by Pre Production QA: " + QAProdOn, new Font(Font.BOLD, 7, Font.BOLD | Font.BOLD)));
                cell.HorizontalAlignment = Element.ALIGN_LEFT;
                cell.FixedHeight = 15f;
                cell.Border = 0;
                cell.Colspan = 2;
                table.AddCell(cell);


                cell = new PdfPCell(new Phrase("                    " + AccountManagerDate + "  " + "  " + "                                                       " + QAProdDate, new Font(Font.BOLD, 7, Font.BOLD | Font.BOLD)));
                cell.HorizontalAlignment = Element.ALIGN_LEFT;
                cell.FixedHeight = 15f;
                cell.Border = 0;
                cell.Colspan = 2;
                table.AddCell(cell);
                //END
                //table.AddCell(cell);
                document.Add(table);
                document.Close();
                ShowPdf(fileName);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
            }
            return fileName;
        }
        //end by abhishek 
    }


}
