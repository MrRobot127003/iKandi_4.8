using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iKandi.Common;
using System.Data;
using System.Drawing;
using System.IO;
using iKandi.DAL;
using Excel = Microsoft.Office.Interop.Excel;
using System.Globalization;

namespace iKandi.BLL
{
    public class ReportController : BaseController
    {
        public int GlobalCount = 0;
        public int GlobalCount_Top = 0;
        public int GlobalCount_Weight = 0;
        public int GlobalCount_Planning = 0;
        public int GlobalCount_PO = 0;
        public int GlobalCount_OutHouse = 0;
        public int GlobalCount_OutHouse_Emb = 0;
        public int GlobalType_Upcomming_Exfactory = 0;
        public int GlobalType_UpCommingDC_ForFabricSorted = 0;
        public int GlobalType_Rescan = 0;
        public int GlobalType_PatternStatus = 0;
        public int GlobalCountStyleCode_Planning = 0;
        public int GlobalCount_OnHold = 0;
        public int GlobalCount_WIP = 0;
        public int GlobalCount_Fabric_Wip = 0;
        public int GlobalCount_AM = 0;
        public int GlobalCount_AM_Material = 0;
        public int GlobalCount_FitsComenetes = 0;
        public int GlobalPending_Cost_Confirmation = 0;
        public int GlobalCount_Fabric_Po_Details = 0;
        public int GlobalCount_Accessory_Po_Details = 0;




        #region

        public ReportController()
        {
        }

        public ReportController(SessionInfo LoggedInUser)
            : base(LoggedInUser)
        {
        }

        #endregion
        // Added for Critical Path Report 
        public DataSet CriticalPatchReport(string SearchText, int Client, int Department, int SupplyType, int ModeType, int PackingType, int Terms, int UserId, int BuyingHouse)
        {
            return this.ReportDataProviderInstance.CriticalPatchReport(SearchText, Client, Department, SupplyType, ModeType, PackingType, Terms, UserId, BuyingHouse);
        }
        public DataSet GetAllOrdersOnStyleNew(int styleNumber)
        {
            return this.ReportDataProviderInstance.GetAllOrdersOnStyleDAL(styleNumber);
        }
        public DataSet GetSamplingStatusReport(int PageSize, int PageIndex, out int TotalPageCount, int BuyerID, int StyleID, DateTime FromDate, DateTime ToDate, string SearchText)
        {
            return this.ReportDataProviderInstance.GetSamplingStatusReport(PageSize, PageIndex, out TotalPageCount, BuyerID, StyleID, FromDate, ToDate, SearchText);
        }

        public DataSet GetSamplingDispatchReport(DateTime CourierDate, string SearchText)
        {
            return this.ReportDataProviderInstance.GetSamplingDispatchReport(CourierDate, SearchText);
        }
        public DataSet GetFabricSamplingReport(string SearchText)
        {
            return this.ReportDataProviderInstance.GetFabricSamplingReport(SearchText);
        }

        public DataSet GetPendingImagesReport(int BuyerID, string SearchText)
        {
            return this.ReportDataProviderInstance.GetPendingImagesReport(BuyerID, SearchText);
        }

        public DataSet GetFabricQualityPendingReport(string SearchText)
        {
            return this.ReportDataProviderInstance.GetFabricQualityPendingReport(SearchText);
        }

        public DataSet GetFabricRunningQualityReport(int BuyerID, int FromPrice, int ToPrice)
        {
            return this.ReportDataProviderInstance.GetFabricRunningQuality(BuyerID, FromPrice, ToPrice);
        }

        public List<DesignerTargetAllocation> GetDesignerTargetReport(int DesignerID, int Year, int Type)
        {
            List<DesignerTargetAllocation> dtaList = new List<DesignerTargetAllocation>();
            try
            {
                dtaList = this.ConvertDataSetToDTAList(this.ReportDataProviderInstance.GetDesignerTargetAllocation(DesignerID, Year, Type), Type);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                //  throw ex;
            }
            return dtaList;
        }

        private List<DesignerTargetAllocation> ConvertDataSetToDTAList(DataSet dsDta, int Type)
        {
            List<DesignerTargetAllocation> dtaList = new List<DesignerTargetAllocation>();
            System.Data.DataTable dt1 = dsDta.Tables[0];
            System.Data.DataTable dt2 = dsDta.Tables[1];
            System.Data.DataTable dt3 = dsDta.Tables[2];
            System.Data.DataTable dt4 = dsDta.Tables[3];
            System.Data.DataTable dt5 = dsDta.Tables[4];
            int i = 0;

            if (dsDta.Tables.Count == 5 && dt1.Rows.Count > 0 && dt2.Rows.Count > 0 && dt3.Rows.Count > 0 && dt4.Rows.Count > 0 && dt5.Rows.Count > 0)
            {
                foreach (DataRow dr in dt1.Rows)
                {
                    DesignerTargetAllocation dta = new DesignerTargetAllocation();
                    dta.Client = new Client();

                    int TotalSampleissued = 0;
                    int TotalOrderQuantity = 0;
                    int StyleBooked = 0;
                    int TotalBIPLTurnOver = 0;
                    int TotalPrintsIssued = 0;
                    int PrintBooked = 0;

                    if (dt4.Rows.Count >= i + 1)
                        TotalSampleissued = ((dt4.Rows[i]["TotalSampleissued"] == DBNull.Value) ? 0 : Convert.ToInt32(dt4.Rows[i]["TotalSampleissued"]));
                    if (dt2.Rows.Count >= i + 1)
                    {
                        TotalOrderQuantity = ((dt2.Rows[i]["TotalOrderQuantity"] == DBNull.Value) ? 0 : Convert.ToInt32(dt2.Rows[i]["TotalOrderQuantity"]));
                        StyleBooked = ((dt2.Rows[i]["StyleBooked"] == DBNull.Value) ? 0 : Convert.ToInt32(dt2.Rows[i]["StyleBooked"]));
                        TotalBIPLTurnOver = ((dt2.Rows[i]["TotalBIPLTurnOver"] == DBNull.Value) ? 0 : Convert.ToInt32(dt2.Rows[i]["TotalBIPLTurnOver"]));
                    }
                    if (dt3.Rows.Count >= i + 1)
                        PrintBooked = ((dt3.Rows[i]["StyleBooked"] == DBNull.Value) ? 0 : Convert.ToInt32(dt3.Rows[i]["StyleBooked"]));

                    if (dt5.Rows.Count >= i + 1)
                        TotalPrintsIssued = ((dt5.Rows[i]["TotalPrintsIssued"] == DBNull.Value) ? 0 : Convert.ToInt32(dt5.Rows[i]["TotalPrintsIssued"]));


                    dta.DesignerName = ((dr["DesignerFirstname"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["DesignerFirstname"])) + " " + ((dr["DesignerLastname"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["DesignerLastname"]));
                    dta.DesignerID = (dr["DesignerID"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["DesignerID"]);
                    dta.Client.CompanyName = (dr["ClientName"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["ClientName"]);
                    dta.Client.ClientID = (dr["ClientId"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["ClientId"]);
                    dta.TargetTurnOver = (dr["TargetTurnOver"] == DBNull.Value) ? "0" : Convert.ToString(dr["TargetTurnOver"]);
                    if (dt2.Rows.Count >= i + 1 && dt3.Rows.Count >= i + 1)
                        dta.ActualTurnOver = (((dt2.Rows[i]["ActualTurnOver"] == DBNull.Value) ? 0 : Convert.ToInt32(dt2.Rows[i]["ActualTurnOver"])) + ((dt3.Rows[i]["ActualTurnOver"] == DBNull.Value) ? 0 : Convert.ToInt32(dt3.Rows[i]["ActualTurnOver"]))).ToString();
                    else
                        dta.ActualTurnOver = "0";
                    dta.TotalSamplingAllocation = (dr["TotalSamplingAllocation"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["TotalSamplingAllocation"]);
                    if (dt4.Rows.Count >= i + 1)
                        dta.ActualSamplingIssued = (dt4.Rows[i]["TotalSampleissued"] == DBNull.Value) ? 0 : Convert.ToInt32(dt4.Rows[i]["TotalSampleissued"]);
                    else
                        dta.ActualSamplingIssued = 0;
                    dta.TargetHitRateStyle = (dr["StyleTargetHitRate"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["StyleTargetHitRate"]);
                    if ((StyleBooked * 100) > 0 && dta.ActualSamplingIssued > 0)
                        dta.ActualHitRateStyle = Convert.ToInt32((StyleBooked * 100) / dta.ActualSamplingIssued);
                    else
                        dta.ActualHitRateStyle = 0;
                    if (TotalOrderQuantity > 0 && StyleBooked > 0)
                        dta.AverageOrderSize = Convert.ToInt32(TotalOrderQuantity / StyleBooked);
                    else
                        dta.AverageOrderSize = 0;
                    if (!String.IsNullOrEmpty(dta.ActualTurnOver) && Convert.ToDouble(dta.ActualTurnOver) > 0 && TotalOrderQuantity > 0)
                        dta.AverageIkandiGrossPrice = Math.Round(Convert.ToDouble(Convert.ToInt32(dta.ActualTurnOver) / TotalOrderQuantity), 2);
                    else
                        dta.AverageIkandiGrossPrice = 0;
                    if (TotalBIPLTurnOver > 0 && TotalOrderQuantity > 0)
                        dta.AverageBiplPrice = Math.Round(Convert.ToDouble(TotalBIPLTurnOver / TotalOrderQuantity), 2);
                    else
                        dta.AverageBiplPrice = 0;
                    if (Convert.ToInt32(dta.TargetTurnOver) > 0 && dta.AverageIkandiGrossPrice > 0)
                        dta.OverallQtyToAchieveTarget = Convert.ToInt32(dta.TargetTurnOver) / Convert.ToInt32(dta.AverageIkandiGrossPrice);
                    else
                        dta.OverallQtyToAchieveTarget = 0;
                    dta.ActualQtyBooked = TotalOrderQuantity;
                    dta.Type = (dr["type"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["type"]);
                    dta.TotalPrintAllocation = (dr["TotalPrintBudgetAllocation"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["TotalPrintBudgetAllocation"]);
                    if (dt5.Rows.Count >= i + 1)
                        dta.ActualPrintsIssued = (dt5.Rows[i]["TotalPrintsIssued"] == DBNull.Value) ? 0 : Convert.ToInt32(dt5.Rows[i]["TotalPrintsIssued"]);
                    else
                        dta.ActualPrintsIssued = 0;
                    dta.TargetHitRatePrint = (dr["PrintTargetHitRate"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["PrintTargetHitRate"]);
                    if ((PrintBooked * 100) > 0 && dta.ActualPrintsIssued > 0)
                        dta.ActualHitRatePrint = Convert.ToInt32((PrintBooked * 100) / dta.ActualPrintsIssued);
                    else
                        dta.ActualHitRatePrint = 0;

                    dtaList.Add(dta);
                    i++;
                }
            }
            return dtaList;
        }

        public List<OrderDetail> GetIkandiViewReportsFinancials(string searchText, DateTime FromDate, DateTime ToDate, int ClientID)
        {
            return this.ReportDataProviderInstance.GetiKandiViewReportsFinancials(searchText, FromDate, ToDate, ClientID);
        }

        public List<OrderDetail> GetIkandiViewReportsTechnical(string searchText, DateTime FromDate, DateTime ToDate, int ClientID)
        {
            return this.ReportDataProviderInstance.GetiKandiViewReportsTechnicals(searchText, FromDate, ToDate, ClientID);

        }

        public DataSet GetModeReports(int StatusId)
        {
            return this.ReportDataProviderInstance.GetModeReports(StatusId);
        }
        public List<OrderDetail> GetOrderSummaryReports(string searchText, DateTime FromDate, DateTime ToDate, int ClientID)
        {
            return this.ReportDataProviderInstance.GetOrderSummaryReport(searchText, FromDate, ToDate, ClientID);

        }


        //Kuldeep 
        //public bool GenerateStyleDigitalInfo(string PDFPath,string iClientId,int iDateType, DateTime iFromDate,DateTime iToDate)
        //{
        //    System.Data.DataTable dt =this.ReportDataProviderInstance.GetStyleDigitalInfo(iClientId,iDateType,iFromDate,iToDate);

        //    if (dt.Rows.Count==0)
        //    {
        //        return false;
        //    }

        //    Color HeaderColor = new Color(System.Drawing.ColorTranslator.FromHtml("#F9DDF4"));
        //    PDFTableGenerator gen = new PDFTableGenerator(PDFPath, "STYLE DIGITAL INFORMATION", HeaderColor);
        //    gen.CellHeight = 225;

        //    gen.Columns = new List<PDFHeader>();
        //    gen.Columns.Add(new PDFHeader("Style Number", iKandi.Common.ContentAlignment.Vertical, 2, 10));
        //    gen.Columns.Add(new PDFHeader("Front Digital", iKandi.Common.ContentAlignment.Horizontal,6));
        //    gen.Columns.Add(new PDFHeader("Back Digital", iKandi.Common.ContentAlignment.Horizontal, 6));
        //    gen.Columns.Add(new PDFHeader("Fabric Name", iKandi.Common.ContentAlignment.Horizontal,6));
        //    gen.Columns.Add(new PDFHeader("Print Digital", iKandi.Common.ContentAlignment.Horizontal, 6));
        //    gen.Columns.Add(new PDFHeader("ExFactory", iKandi.Common.ContentAlignment.Vertical, 2, 10));
        //    gen.Columns.Add(new PDFHeader("DC Date", iKandi.Common.ContentAlignment.Vertical, 2, 10));

        //    gen.Rows = new List<List<PDFCell>>();

        //    for (int i = 0; i <= dt.Rows.Count - 1; i++)
        //    {
        //        List<PDFCell> row = new List<PDFCell>();

        //        PDFCell cell = new PDFCell(Convert.ToString(dt.Rows[i]["StyleNumber"]), iKandi.Common.ContentAlignment.Vertical);
        //        cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
        //        cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
        //        row.Add(cell);

        //        string ImagePath = Convert.ToString(dt.Rows[i]["FrontDigit"]);
        //        cell = new PDFCell(string.Empty, iKandi.Common.ContentAlignment.Horizontal);
        //        if (ImagePath != string.Empty)
        //        {
        //            cell.ImageUrl = Path.Combine(iKandi.Common.Constants.STYLE_FOLDER_PATH, ImagePath);
        //        }
        //        row.Add(cell);


        //        ImagePath = Convert.ToString(dt.Rows[i]["BackDigit"]);
        //        cell = new PDFCell(string.Empty, iKandi.Common.ContentAlignment.Horizontal);
        //        if (ImagePath != string.Empty)
        //        {
        //            cell.ImageUrl = Path.Combine(iKandi.Common.Constants.STYLE_FOLDER_PATH, ImagePath);
        //        }
        //        row.Add(cell);


        //        cell = new PDFCell(Convert.ToString(dt.Rows[i]["FabricName"]), iKandi.Common.ContentAlignment.Horizontal);
        //        cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
        //        cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
        //        row.Add(cell);


        //        ImagePath = Convert.ToString(dt.Rows[i]["Print1"]);
        //        cell = new PDFCell(string.Empty, iKandi.Common.ContentAlignment.Horizontal);
        //        if (ImagePath != string.Empty)
        //        {
        //            cell.ImageUrl = Path.Combine(iKandi.Common.Constants.STYLE_FOLDER_PATH, ImagePath);
        //        }
        //        else
        //        {
        //            ImagePath = Convert.ToString(dt.Rows[i]["Print2"]);
        //            cell = new PDFCell(string.Empty, iKandi.Common.ContentAlignment.Horizontal);
        //            if (ImagePath != string.Empty)
        //            {
        //                cell.ImageUrl = Path.Combine(iKandi.Common.Constants.STYLE_FOLDER_PATH, ImagePath);
        //            }
        //            else
        //            {
        //                ImagePath = Convert.ToString(dt.Rows[i]["Print3"]);
        //                cell = new PDFCell(string.Empty, iKandi.Common.ContentAlignment.Horizontal);
        //                if (ImagePath != string.Empty)
        //                {
        //                    cell.ImageUrl = Path.Combine(iKandi.Common.Constants.STYLE_FOLDER_PATH, ImagePath);
        //                }
        //                else
        //                {
        //                    ImagePath = Convert.ToString(dt.Rows[i]["Print4"]);
        //                    cell = new PDFCell(string.Empty, iKandi.Common.ContentAlignment.Horizontal);
        //                    if (ImagePath != string.Empty)
        //                    {
        //                        cell.ImageUrl = Path.Combine(iKandi.Common.Constants.STYLE_FOLDER_PATH, ImagePath);
        //                    }
        //                }

        //            }
        //        }
        //        row.Add(cell);


        //        cell = new PDFCell(Convert.ToString(dt.Rows[i]["ExFactory"]), iKandi.Common.ContentAlignment.Vertical);
        //        cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
        //        cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
        //        row.Add(cell);

        //        cell = new PDFCell(Convert.ToString(dt.Rows[i]["DC"]), iKandi.Common.ContentAlignment.Vertical);
        //        cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
        //        cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
        //        row.Add(cell);

        //        gen.Rows.Add(row);

        //    }
        //    return gen.GeneratePDF();



        //            /*
        //            string Fabric1 = orderdetail.Fabric1;
        //            string Fabric1Detail = orderdetail.Fabric1Details.ToString().Trim();
        //            int Fabric1Percent = orderdetail.ParentOrder.FabricInhouseHistory.Fabric1Percent;

        //            if (Fabric1Detail != "")
        //            {
        //                Fabric1 = Fabric1 + " : " + Fabric1Detail;
        //            }

        //            if (Fabric1Percent != 0)
        //            {
        //                Fabric1 = Fabric1 + " (" + Fabric1Percent + "%)";
        //            }

        //            string Fabric2 = orderdetail.Fabric2;
        //            string Fabric2Detail = orderdetail.Fabric2Details.ToString().Trim();
        //            int Fabric2Percent = orderdetail.ParentOrder.FabricInhouseHistory.Fabric2Percent;

        //            if (Fabric2Detail != "")
        //            {
        //                Fabric2 = Fabric2 + " : " + Fabric2Detail;
        //            }

        //            if (Fabric2Percent != 0)
        //            {
        //                Fabric2 = Fabric2 + " (" + Fabric2Percent + "%)";
        //            }

        //            string Fabric3 = orderdetail.Fabric3;
        //            string Fabric3Detail = orderdetail.Fabric3Details.ToString().Trim();
        //            int Fabric3Percent = orderdetail.ParentOrder.FabricInhouseHistory.Fabric3Percent;

        //            if (Fabric3Detail != "")
        //            {
        //                Fabric3 = Fabric3 + " : " + Fabric3Detail;
        //            }

        //            if (Fabric3Percent != 0)
        //            {
        //                Fabric3 = Fabric3 + " (" + Fabric3Percent + "%)";
        //            }

        //            string Fabric4 = orderdetail.Fabric4;
        //            string Fabric4Detail = orderdetail.Fabric4Details.ToString().Trim();
        //            int Fabric4Percent = orderdetail.ParentOrder.FabricInhouseHistory.Fabric4Percent;

        //            if (Fabric4Detail != "")
        //            {
        //                Fabric4 = Fabric4 + " : " + Fabric4Detail;
        //            }

        //            if (Fabric4Percent != 0)
        //            {
        //                Fabric4 = Fabric4 + " (" + Fabric4Percent + "%)";
        //            }

        //            cell = new PDFCell(Fabric1 + "\n\n" + Fabric2 + "\n\n" + Fabric3 + "\n\n" + Fabric4);
        //            cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
        //            cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
        //            cell.Padding = 5;
        //            row.Add(cell);
        //        */
        //}


        public DataSet GetOrderSummaryReportAccessories(string searchText, DateTime FromDate, DateTime ToDate, int ClientID)
        {
            return this.ReportDataProviderInstance.GetOrdersSummaryReportAccessories(searchText, FromDate, ToDate, ClientID);
        }

        public List<OrderDetail> GetOrderSummaryReportStiching(string searchText, DateTime FromDate, DateTime ToDate, int ClientID)
        {
            return this.ReportDataProviderInstance.GetOrdersSummaryReportStiching(searchText, FromDate, ToDate, ClientID);

        }

        public List<OrderDetail> GetOrderSummaryReportCutting(string searchText, DateTime FromDate, DateTime ToDate, int ClientID)
        {
            return this.ReportDataProviderInstance.GetOrdersSummaryReportCutting(searchText, FromDate, ToDate, ClientID);

        }
        public DataSet GetClientDepartmentOrder(int DeptID)
        {
            return this.ReportDataProviderInstance.GetClientDepartmentOrder(DeptID);
        }

        public DataSet GetOrderSummaryReportClientSummary(int ClientID)
        {
            return this.ReportDataProviderInstance.GetOrderClientSummaryReport(ClientID);
        }

        public DataSet GetSealerPendingOrdersReport(int ClientID, string SearchText)
        {
            return this.ReportDataProviderInstance.GetSealerPendingOrdersReport(ClientID, SearchText);
        }

        public List<OrderDetail> GetProductionReportInfo(string searchText, DateTime FromDate, DateTime ToDate, int ClientID, int UserID, int Unit)
        {
            return this.ReportDataProviderInstance.GetProductionReportInfo(searchText, FromDate, ToDate, ClientID, UserID, Unit);
        }

        public List<OrderDetail> GetCriticalPatchReport(string SearchText, int Client, int Department, int SupplyType, int ModeType, int PackingType, int Terms)
        {
            return this.ReportDataProviderInstance.GetCriticalPatchReport(SearchText, Client, Department, SupplyType, ModeType, PackingType, Terms);
        }

        public List<OrderDetail> GetOrderSummaryReport(int PageSize, int PageIndex, out int TotalRowCount, string SearchText, int ClientId, int SortedBy1, int SortedBy2, int SortedBy3, int SortedBy4, out int TotalQuantity, int FactoryManagerID, int UserId, DateTime FromDate, DateTime ToDate)
        {
            return this.ReportDataProviderInstance.GetManagingOrderSummaryReport(PageSize, PageIndex, out TotalRowCount, SearchText, ClientId, SortedBy1, SortedBy2, SortedBy3, SortedBy4, out TotalQuantity, FactoryManagerID, UserId, FromDate, ToDate);
        }

        //public bool GenerateDailyProductionReport(string PDFPath, string searchText, DateTime FromDate, DateTime ToDate, int ClientID, int UserID, int UnitID)
        //{
        //    List<OrderDetail> orderdetails = this.ReportDataProviderInstance.GetProductionReportInfo(searchText, FromDate, ToDate, ClientID, UserID, UnitID);

        //    if (orderdetails == null || orderdetails.Count == 0)
        //    {
        //        return false;
        //    }

        //    Color HeaderColor = new Color(System.Drawing.ColorTranslator.FromHtml("#F9DDF4"));
        //    PDFTableGenerator gen = new PDFTableGenerator(PDFPath, "PRODUCTION REPORT", HeaderColor);
        //    gen.CellHeight = 225;

        //    gen.Columns = new List<PDFHeader>();
        //    gen.Columns.Add(new PDFHeader("Buyer", iKandi.Common.ContentAlignment.Vertical, 2, 10));
        //    gen.Columns.Add(new PDFHeader("Serial No.", iKandi.Common.ContentAlignment.Vertical, 2, 10));
        //    gen.Columns.Add(new PDFHeader("Dept.", iKandi.Common.ContentAlignment.Vertical, 2, 10));
        //    gen.Columns.Add(new PDFHeader("Style No.", iKandi.Common.ContentAlignment.Vertical, 2, 10));
        //    gen.Columns.Add(new PDFHeader("Style", iKandi.Common.ContentAlignment.Horizontal, 6));
        //    gen.Columns.Add(new PDFHeader("Line/Item No", iKandi.Common.ContentAlignment.Vertical, 2, 10));
        //    gen.Columns.Add(new PDFHeader("Contract No", iKandi.Common.ContentAlignment.Vertical, 2, 10));
        //    gen.Columns.Add(new PDFHeader("Description", iKandi.Common.ContentAlignment.Vertical, 3, 15));
        //    gen.Columns.Add(new PDFHeader("Qty", iKandi.Common.ContentAlignment.Vertical, 2, 10));
        //    gen.Columns.Add(new PDFHeader("Mode", iKandi.Common.ContentAlignment.Vertical, 2, 10));
        //    gen.Columns.Add(new PDFHeader("ExFactory", iKandi.Common.ContentAlignment.Vertical, 2, 10));
        //    gen.Columns.Add(new PDFHeader("Status", iKandi.Common.ContentAlignment.Vertical, 2, 10));
        //    gen.Columns.Add(new PDFHeader("Sealer Tgt", iKandi.Common.ContentAlignment.Vertical, 2, 10));
        //    gen.Columns.Add(new PDFHeader("Sealer Actual", iKandi.Common.ContentAlignment.Vertical, 2, 10));
        //    gen.Columns.Add(new PDFHeader("Fabric Details", iKandi.Common.ContentAlignment.Horizontal, 12));
        //    gen.Columns.Add(new PDFHeader("Accessories", iKandi.Common.ContentAlignment.Horizontal, 15));
        //    gen.Columns.Add(new PDFHeader("Inline Cut Date", iKandi.Common.ContentAlignment.Vertical, 2, 10));
        //    gen.Columns.Add(new PDFHeader("Cutting Actual", iKandi.Common.ContentAlignment.Vertical, 2, 10));
        //    gen.Columns.Add(new PDFHeader("PCS cut", iKandi.Common.ContentAlignment.Vertical, 2, 10));
        //    gen.Columns.Add(new PDFHeader("PCS issued", iKandi.Common.ContentAlignment.Vertical, 2, 10));
        //    gen.Columns.Add(new PDFHeader("PCS cut %", iKandi.Common.ContentAlignment.Vertical, 2, 10));
        //    gen.Columns.Add(new PDFHeader("Unit", iKandi.Common.ContentAlignment.Vertical, 2, 10));
        //    gen.Columns.Add(new PDFHeader("Top Target", iKandi.Common.ContentAlignment.Vertical, 2, 10));
        //    gen.Columns.Add(new PDFHeader("Top Actual", iKandi.Common.ContentAlignment.Vertical, 2, 10));
        //    gen.Columns.Add(new PDFHeader("Pcs Stiched Today", iKandi.Common.ContentAlignment.Vertical, 2, 10));
        //    gen.Columns.Add(new PDFHeader("Pcs Stiched Overall", iKandi.Common.ContentAlignment.Vertical, 2, 10));
        //    gen.Columns.Add(new PDFHeader("Pcs Stiched %", iKandi.Common.ContentAlignment.Vertical, 2, 10));
        //    gen.Columns.Add(new PDFHeader("Packed", iKandi.Common.ContentAlignment.Vertical, 2, 10));
        //    gen.Columns.Add(new PDFHeader("Bal On Mach.", iKandi.Common.ContentAlignment.Vertical, 2, 10));
        //    gen.Columns.Add(new PDFHeader("Pcs Packed Today", iKandi.Common.ContentAlignment.Vertical, 2, 10));
        //    gen.Columns.Add(new PDFHeader("Pcs Packed Overall", iKandi.Common.ContentAlignment.Vertical, 2, 10));
        //    gen.Columns.Add(new PDFHeader("Production Remarks", iKandi.Common.ContentAlignment.Horizontal, 9));


        //    gen.Rows = new List<List<PDFCell>>();

        //    foreach (OrderDetail orderdetail in orderdetails)
        //    {
        //        if (orderdetail.ParentOrder.WorkflowInstanceDetail.StatusModeID != 24)
        //        {
        //            List<PDFCell> row = new List<PDFCell>();

        //            PDFCell cell = new PDFCell(orderdetail.ParentOrder.Style.client.CompanyName, iKandi.Common.ContentAlignment.Vertical);
        //            cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
        //            cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
        //            row.Add(cell);

        //            cell = new PDFCell(orderdetail.ParentOrder.SerialNumber, iKandi.Common.ContentAlignment.Vertical);
        //            cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
        //            cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
        //            cell.FontColor = "#0000ff";
        //            cell.FontSize = 16;
        //            cell.BackGroundColor = iKandi.Common.Constants.GetSerialNumberColor(orderdetail.ExFactory);
        //            row.Add(cell);

        //            cell = new PDFCell(orderdetail.ParentOrder.Style.cdept.Name.ToUpper(), iKandi.Common.ContentAlignment.Vertical);
        //            cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
        //            cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
        //            row.Add(cell);

        //            cell = new PDFCell(orderdetail.ParentOrder.Style.StyleNumber, iKandi.Common.ContentAlignment.Vertical);
        //            cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
        //            cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
        //            cell.FontColor = "#0000ff";
        //            cell.FontSize = 16;
        //            row.Add(cell);

        //            string ImagePath = orderdetail.ParentOrder.Style.SampleImageURL1;

        //            cell = new PDFCell(string.Empty, iKandi.Common.ContentAlignment.Horizontal);
        //            if (ImagePath != string.Empty)
        //            {
        //                cell.ImageUrl = Path.Combine(iKandi.Common.Constants.STYLE_FOLDER_PATH, "thumb-" + ImagePath);
        //            }
        //            row.Add(cell);

        //            cell = new PDFCell(orderdetail.LineItemNumber, iKandi.Common.ContentAlignment.Vertical);
        //            cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
        //            cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
        //            row.Add(cell);

        //            cell = new PDFCell(orderdetail.ContractNumber, iKandi.Common.ContentAlignment.Vertical);
        //            cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
        //            cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
        //            row.Add(cell);

        //            cell = new PDFCell(orderdetail.ParentOrder.Description, iKandi.Common.ContentAlignment.Vertical);
        //            cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
        //            cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
        //            row.Add(cell);

        //            cell = new PDFCell(orderdetail.Quantity.ToString("N0"), iKandi.Common.ContentAlignment.Vertical);
        //            cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
        //            cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
        //            cell.FontColor = "#0000ff";
        //            cell.FontSize = 16;
        //            row.Add(cell);

        //            cell = new PDFCell(orderdetail.ModeName, iKandi.Common.ContentAlignment.Vertical);
        //            cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
        //            cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
        //            cell.BackGroundColor = iKandi.Common.Constants.GetStatusModeColor(orderdetail.Mode);
        //            row.Add(cell);

        //            string ExFactory = (orderdetail.ExFactory == DateTime.MinValue) ? string.Empty : orderdetail.ExFactory.ToString("dd MMM yy (ddd)");
        //            cell = new PDFCell(ExFactory, iKandi.Common.ContentAlignment.Vertical);
        //            cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
        //            cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
        //            cell.FontColor = "#0000ff";
        //            cell.FontSize = 16;
        //            cell.BackGroundColor = iKandi.BLL.CommonHelper.GetExFactoryColor(orderdetail.ExFactory, orderdetail.DC, orderdetail.Mode);
        //            row.Add(cell);

        //            cell = new PDFCell(orderdetail.ParentOrder.WorkflowInstanceDetail.StatusMode, iKandi.Common.ContentAlignment.Vertical);
        //            cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
        //            cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
        //            cell.BackGroundColor = iKandi.Common.Constants.GetStatusModeColor(orderdetail.ParentOrder.WorkflowInstanceDetail.StatusModeID);
        //            row.Add(cell);

        //            string SealerTgt = (orderdetail.STCUnallocated == DateTime.MinValue) ? string.Empty : orderdetail.STCUnallocated.ToString("dd MMM yy (ddd)");
        //            cell = new PDFCell(SealerTgt, iKandi.Common.ContentAlignment.Vertical);
        //            cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
        //            cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
        //            row.Add(cell);

        //            string SealerActual = (orderdetail.ParentOrder.Fits.SealDate == DateTime.MinValue) ? string.Empty : orderdetail.ParentOrder.Fits.SealDate.ToString("dd MMM yy (ddd)");
        //            cell = new PDFCell(SealerActual, iKandi.Common.ContentAlignment.Vertical);
        //            cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
        //            cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
        //            row.Add(cell);

        //            string Fabric1 = orderdetail.Fabric1;
        //            string Fabric1Detail = orderdetail.Fabric1Details.ToString().Trim();
        //            int Fabric1Percent = orderdetail.ParentOrder.FabricInhouseHistory.Fabric1Percent;

        //            if (Fabric1Detail != "")
        //            {
        //                Fabric1 = Fabric1 + " : " + Fabric1Detail;
        //            }

        //            if (Fabric1Percent != 0)
        //            {
        //                Fabric1 = Fabric1 + " (" + Fabric1Percent + "%)";
        //            }

        //            string Fabric2 = orderdetail.Fabric2;
        //            string Fabric2Detail = orderdetail.Fabric2Details.ToString().Trim();
        //            int Fabric2Percent = orderdetail.ParentOrder.FabricInhouseHistory.Fabric2Percent;

        //            if (Fabric2Detail != "")
        //            {
        //                Fabric2 = Fabric2 + " : " + Fabric2Detail;
        //            }

        //            if (Fabric2Percent != 0)
        //            {
        //                Fabric2 = Fabric2 + " (" + Fabric2Percent + "%)";
        //            }

        //            string Fabric3 = orderdetail.Fabric3;
        //            string Fabric3Detail = orderdetail.Fabric3Details.ToString().Trim();
        //            int Fabric3Percent = orderdetail.ParentOrder.FabricInhouseHistory.Fabric3Percent;

        //            if (Fabric3Detail != "")
        //            {
        //                Fabric3 = Fabric3 + " : " + Fabric3Detail;
        //            }

        //            if (Fabric3Percent != 0)
        //            {
        //                Fabric3 = Fabric3 + " (" + Fabric3Percent + "%)";
        //            }

        //            string Fabric4 = orderdetail.Fabric4;
        //            string Fabric4Detail = orderdetail.Fabric4Details.ToString().Trim();
        //            int Fabric4Percent = orderdetail.ParentOrder.FabricInhouseHistory.Fabric4Percent;

        //            if (Fabric4Detail != "")
        //            {
        //                Fabric4 = Fabric4 + " : " + Fabric4Detail;
        //            }

        //            if (Fabric4Percent != 0)
        //            {
        //                Fabric4 = Fabric4 + " (" + Fabric4Percent + "%)";
        //            }

        //            cell = new PDFCell(Fabric1 + "\n\n" + Fabric2 + "\n\n" + Fabric3 + "\n\n" + Fabric4);
        //            cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
        //            cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
        //            cell.Padding = 5;
        //            row.Add(cell);

        //            cell = new PDFCell(orderdetail.AccessoryHistory.ToString().Replace("<br/><br/>", "\n"), iKandi.Common.ContentAlignment.Horizontal, 100);
        //            cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
        //            cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
        //            cell.Padding = 5;
        //            row.Add(cell);

        //            String InlineCutDate = (orderdetail.ParentOrder.Style.InLineCutDate == DateTime.MinValue) ? string.Empty : orderdetail.ParentOrder.Style.InLineCutDate.ToString("dd MMM yy (ddd)");
        //            cell = new PDFCell(InlineCutDate, iKandi.Common.ContentAlignment.Vertical);
        //            cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
        //            cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
        //            row.Add(cell);

        //            String CuttingActual = (orderdetail.ParentOrder.CuttingHistory.Date == DateTime.MinValue) ? string.Empty : orderdetail.ParentOrder.CuttingHistory.Date.ToString("dd MMM yy (ddd)");
        //            cell = new PDFCell(CuttingActual, iKandi.Common.ContentAlignment.Vertical);
        //            cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
        //            cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
        //            row.Add(cell);

        //            cell = new PDFCell(orderdetail.ParentOrder.CuttingDetail.PcsCut.ToString("N0"), iKandi.Common.ContentAlignment.Vertical);
        //            cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
        //            cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
        //            row.Add(cell);

        //            string percentCut = orderdetail.ParentOrder.CuttingDetail.PcsIssued.ToString("N0");
        //            cell = new PDFCell(percentCut, iKandi.Common.ContentAlignment.Vertical);
        //            cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
        //            cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
        //            row.Add(cell);

        //            cell = new PDFCell(orderdetail.ParentOrder.CuttingHistory.PercentagePcsCut.ToString("N0") +"%", iKandi.Common.ContentAlignment.Vertical);
        //            cell.BackGroundColor = iKandi.Common.Constants.GetPercentageColor(orderdetail.ParentOrder.CuttingHistory.PercentagePcsCut);
        //            cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
        //            cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
        //            row.Add(cell);

        //            cell = new PDFCell(orderdetail.Unit.FactoryName, iKandi.Common.ContentAlignment.Vertical);
        //            cell.BackGroundColor = orderdetail.Unit.ProductionUnitColor;
        //            cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
        //            cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
        //            row.Add(cell);

        //            string TopSendTgt = (orderdetail.ParentOrder.InlinePPMOrderContract.TopSentTarget == DateTime.MinValue) ? string.Empty : orderdetail.ParentOrder.InlinePPMOrderContract.TopSentTarget.ToString("dd MMM yy (ddd)");
        //            cell = new PDFCell(TopSendTgt, iKandi.Common.ContentAlignment.Vertical);
        //            cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
        //            cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
        //            row.Add(cell);

        //            string TopSendActual = (orderdetail.ParentOrder.InlinePPMOrderContract.TopSentActual == DateTime.MinValue) ? string.Empty : orderdetail.ParentOrder.InlinePPMOrderContract.TopSentActual.ToString("dd MMM yy (ddd)");
        //            cell = new PDFCell(TopSendActual, iKandi.Common.ContentAlignment.Vertical);
        //            cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
        //            cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
        //            cell.BackGroundColor = iKandi.Common.Constants.GetActualDateColor(orderdetail.ParentOrder.InlinePPMOrderContract.TopSentTarget, orderdetail.ParentOrder.InlinePPMOrderContract.TopSentActual);
        //            row.Add(cell);

        //            cell = new PDFCell(orderdetail.ParentOrder.StitchingDetail.TotalPcsStitchedToday.ToString("N0"), iKandi.Common.ContentAlignment.Vertical);
        //            cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
        //            cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
        //            row.Add(cell);

        //            cell = new PDFCell(orderdetail.ParentOrder.StitchingDetail.OverallPcsStitched.ToString("N0"), iKandi.Common.ContentAlignment.Vertical);
        //            cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
        //            cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
        //            row.Add(cell);

        //            string percentStitched = orderdetail.ParentOrder.StitchingDetail.PercentageOverallPcsStitched.ToString("N0") + "%";
        //            cell = new PDFCell(percentStitched, iKandi.Common.ContentAlignment.Vertical);
        //            cell.BackGroundColor = iKandi.Common.Constants.GetPercentageColor(orderdetail.ParentOrder.StitchingDetail.PercentageOverallPcsStitched);
        //            cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
        //            cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
        //            row.Add(cell);

        //            cell = new PDFCell(orderdetail.ParentOrder.StitchingDetail.PercentageOverallPcsPacked.ToString("N0") + "%", iKandi.Common.ContentAlignment.Vertical);
        //            cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
        //            cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
        //            cell.BackGroundColor = iKandi.Common.Constants.GetPercentageColor(orderdetail.ParentOrder.StitchingDetail.PercentageOverallPcsPacked);
        //            row.Add(cell);

        //            cell = new PDFCell(orderdetail.ParentOrder.StitchingDetail.BalOnMach.ToString("N0"), iKandi.Common.ContentAlignment.Vertical);
        //            cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
        //            cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
        //            row.Add(cell);

        //            cell = new PDFCell(orderdetail.ParentOrder.StitchingDetail.PcsPackedToday.ToString("N0"), iKandi.Common.ContentAlignment.Vertical);
        //            cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
        //            cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
        //            row.Add(cell);

        //            cell = new PDFCell(orderdetail.ParentOrder.StitchingDetail.OverallPcsPacked.ToString("N0"), iKandi.Common.ContentAlignment.Vertical);
        //            cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
        //            cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
        //            row.Add(cell);

        //            string ProductionRemarks = "";

        //            if (orderdetail.ParentOrder.StitchingDetail.ProdRemarks.ToString().LastIndexOf("$$") > -1)
        //            {
        //                ProductionRemarks = orderdetail.ParentOrder.StitchingDetail.ProdRemarks.ToString().Substring(orderdetail.ParentOrder.StitchingDetail.ProdRemarks.ToString().LastIndexOf("$$") + 2);
        //            }
        //            else
        //            {
        //                ProductionRemarks = orderdetail.ParentOrder.StitchingDetail.ProdRemarks.ToString();
        //            }
        //            cell = new PDFCell(ProductionRemarks, iKandi.Common.ContentAlignment.Horizontal);
        //            cell.TextHorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
        //            cell.TextVerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
        //            row.Add(cell);

        //            gen.Rows.Add(row);
        //        }
        //    }

        //    return gen.GeneratePDF();
        //}

        public DataSet GetFabricPendingApproval(int PageSize, int PageIndex, out int TotalRowCount, int ClientID, int DepartmentID, int Stage)
        {
            return this.ReportDataProviderInstance.GetFabricPendingApprovalReport(PageSize, PageIndex, out TotalRowCount, ClientID, DepartmentID, Stage);
        }

        public DataSet GetFITsReport(int PageSize, int PageIndex, out int TotalRowCount, int ClientID, int DepartmentID, DateTime SuggestedFitsDate)
        {
            return this.ReportDataProviderInstance.GetFITsReport(PageSize, PageIndex, out TotalRowCount, ClientID, DepartmentID, SuggestedFitsDate);
        }

        public DataSet GetClientDepartmentSalesReport(int ClientID, int Year, int DateType, int PriceType, int BuyingHouseId)
        {
            return this.ReportDataProviderInstance.GetClientDepartmentSalesReport(ClientID, Year, DateType, PriceType, BuyingHouseId);
        }

        public DataSet GetOverallSalesReport(int Year, int DateType, int PriceType)
        {
            return this.ReportDataProviderInstance.GetOverallSalesReport(Year, DateType, PriceType);
        }

        public DataSet GetOverallSalesReportTemp(int Year, int DateType, int PriceType)
        {
            return this.ReportDataProviderInstance.GetOverallSalesReportTemp(Year, DateType, PriceType);
        }

        public DataSet GetOverallSalesReportBuyingHouse(int Year, int DateType, int PriceType)
        {
            return this.ReportDataProviderInstance.GetOverallSalesReportBuyingHouse(Year, DateType, PriceType);
        }

        public DataSet GetOverallSalesReportSExecutive(int Year, int DateType, int PriceType)
        {
            return this.ReportDataProviderInstance.GetOverallSalesReportSExecutive(Year, DateType, PriceType);
        }

        public DataSet GetOverallSalesReportById(int Year, int DateType, int PriceType, int Id, int UserId, bool IsBIPL, int FactoryCode)
        {
            return this.ReportDataProviderInstance.GetOverallSalesReportById(Year, DateType, PriceType, Id, UserId, IsBIPL, FactoryCode);
        }

        public DataSet GetClientQuantityRevenueReport(int Year, int DateType, int PriceType, int UserId)
        {
            return this.ReportDataProviderInstance.GetClientQuantityRevenueReport(Year, DateType, PriceType, UserId);
        }

        public DataSet GetDhrByDesigner(int Year, int UserId)
        {
            return this.ReportDataProviderInstance.GetDhrByDesigner(Year, UserId);
        }

        public DataSet GetClientAllReport(int Year, int DateType, int PriceType, int UserId, bool IsBIPL, int FactoryCode)
        {
            return this.ReportDataProviderInstance.GetClientAllReport(Year, DateType, PriceType, UserId, IsBIPL, FactoryCode);
        }

        public DataSet GetExFactoryQuantityReport()
        {
            return this.ReportDataProviderInstance.GetExFactoryQuantityReport();
        }

        public DataSet GetAllOrdersOnStyle(string styleNumber, string OrderIDList, bool AllOrders)
        {
            return this.ReportDataProviderInstance.GetAllOrdersOnStyle(styleNumber, OrderIDList, AllOrders);
        }

        public DataSet GetPendingBuyerOrderForms(int ClientId)
        {
            return this.ReportDataProviderInstance.GetPendingBuyerOrderForms(ClientId);
        }

        public DataSet GetSealingPerformance(int orderDate)
        {
            return this.ReportDataProviderInstance.GetSealingPerformance(orderDate);
        }

        public DataSet GetExFactoryMakeUpReport(int Year, int DateType)
        {
            return this.ReportDataProviderInstance.GetExFactoryMakeUpReport(Year, DateType);
        }

        public DataSet GetFabricPerformance(int orderDate)
        {
            return this.ReportDataProviderInstance.GetFabricPerformance(orderDate);
        }

        public DataSet GetAccessoryPerformance(int orderDate)
        {
            return this.ReportDataProviderInstance.GetAccessoryPerformance(orderDate);
        }

        public DataSet GetFabricBaseTestPending(int PageSize, int PageIndex, out int TotalRowCount)
        {
            return this.ReportDataProviderInstance.GetFabricBaseTestPending(PageSize, PageIndex, out TotalRowCount);
        }

        public List<OrderDetail> GetRejectedQaContracts(int PageSize, int PageIndex, out int TotalRowCount, int ClientID)
        {
            return this.ReportDataProviderInstance.GetRejectedQaContracts(PageSize, PageIndex, out TotalRowCount, ClientID);
        }

        public System.Data.DataTable SaveQuoteToolInformation(string styleNumber, int[] modeIdCollection)
        {
            return this.ReportDataProviderInstance.SaveQuoteToolInformation(styleNumber, modeIdCollection);
        }

        public bool DeleteQuoteToolInformation()
        {
            return this.ReportDataProviderInstance.DeleteQuoteToolInformation();
        }

        public System.Data.DataTable GetAllQuoteToolInformation()
        {
            return this.ReportDataProviderInstance.GetAllQuoteToolInformation();
        }

        public DataSet GetFitDelay()
        {
            return this.ReportDataProviderInstance.GetFitDelay();
        }
        public DataSet GetFitDelayforFactory()
        {
            return this.ReportDataProviderInstance.GetFitDelayforFactory();
        }
        public DataSet GetPrintsPerformanceReport(string Duration)
        {
            return this.ReportDataProviderInstance.GetPrintsPerformanceReport(Duration);
        }

        public DataSet GetBestSellers(int PageSize, int PageIndex, out int TotalRowCount, int IsBest, int Limit)
        {
            return this.ReportDataProviderInstance.GetBestSellers(PageSize, PageIndex, out TotalRowCount, IsBest, Limit);
        }

        public DataSet GetFabricPrices(int PageSize, int PageIndex, out int TotalRowCount, string SearchText, string PriceFrom, string PriceTo)
        {
            return this.ReportDataProviderInstance.GetFabricPrices(PageSize, PageIndex, out TotalRowCount, SearchText, PriceFrom, PriceTo);
        }

        public DataSet GetIndAndPrintCostReport(DateTime fromDate, DateTime toDate)
        {
            return this.ReportDataProviderInstance.GetIndAndPrintCostReport(fromDate, toDate);
        }
        public System.Data.DataSet GetHitRateForDesigners(int UserID)
        {
            return this.ReportDataProviderInstance.GetHitRateForDesigners(UserID);
        }

        public System.Data.DataSet GetDesignerMonthlyWork(int Year)
        {
            return this.ReportDataProviderInstance.GetDesignerMonthlyWork(Year);
        }

        public System.Data.DataSet GetDesignersHitRate(int Days)
        {
            return this.ReportDataProviderInstance.GetDesignersHitRate(Days);
        }
        public int GetMOQAStatusHistory(string q, string DeptID)
        {
            return this.ReportDataProviderInstance.GetMOQAStatusHistory(q, DeptID);
        }
        public System.Data.DataSet GetFitDaysForAllClients()
        {
            return this.ReportDataProviderInstance.GetAllFitDays();
        }

        public System.Data.DataSet GetFitDaysForAllClients(int pageIndex, int pageSize, out int totalRecords)
        {
            int start = pageIndex * pageSize;
            return this.ReportDataProviderInstance.GetAllFitDays(start, pageSize, out totalRecords);
        }

        public List<OrderDetail> GetProductionEmailContaint()
        {
            return this.ReportDataProviderInstance.GetProductionEmailContaint();
        }

        public System.Data.DataSet GetClientsWeeklyStylesQuantity()
        {
            return this.ReportDataProviderInstance.GetClientsWeeklyStylesQuantity();
        }

        public List<OrderDetail> GetEmbellishmentReport(string FromPrice, string ToPrice, int Type)
        {
            return this.ReportDataProviderInstance.GetEmbellishmentReport(FromPrice, ToPrice, Type);
        }

        /// <summary>
        /// 
        /// </summary>GetShipmentMonthlyDetailsReport

        /// <returns></returns>
        /// <author>vikas.agarwal</author>
        public DataSet GetWhereAreMyOrdersReport()
        {
            return this.ReportDataProviderInstance.GetWhereAreMyOrdersReport();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <author>vikas.agarwal</author>
        public DataSet GetShipmentByUnitReport()
        {
            return this.ReportDataProviderInstance.GetShipmentByUnitReport();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <author>vikas.agarwal</author>
        public DataSet GetOrdersPlacedVsShippedReport(int UnitID)
        {
            return this.ReportDataProviderInstance.GetOrdersPlacedVsShippedReport(UnitID);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="month"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        /// <author>vikas.agarwal</author>
        public DataSet GetCIFContracts(int month, int year)
        {
            return this.ReportDataProviderInstance.GetCIFContracts(month, year);
        }

        int weeklyShipmentCount = 0;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="startIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        /// <author>vikas.agarwal</author>
        public DataSet GetWeeklyShipmentsReport(int startIndex, int pageSize, DateTime start, DateTime end, int clientId, int supplyType)
        {
            return this.ReportDataProviderInstance.GetWeeklyShipmentsReport(startIndex, pageSize, out weeklyShipmentCount, start, end,
                clientId, supplyType);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="startIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        /// <author>vikas.agarwal</author>
        public int GetWeeklyShipmentsReportCount(int startIndex, int pageSize, DateTime start, DateTime end, int clientId, int supplyType)
        {
            return weeklyShipmentCount;
        }


        int pendingOrdercount = 0;
        // int  = 0;
        //double totalPendingOrderAmount = 0;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="startIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        /// <author>vikas.agarwal</author>
        public DataSet GetPendingOrdersReport(
            int startIndex,
            int pageSize,
            DateTime start,
            DateTime end,
            int datetype,
            int clientID,
            int supplyType
            )
        {
            int totalPendingOrderQuantity = 0;
            double totalPendingOrderAmount = 0;
            if (datetype == 1)
            {
                return this.ReportDataProviderInstance.GetPendingOrdersReport(
                    startIndex, pageSize, out pendingOrdercount, start, end, DateTime.MinValue, DateTime.MaxValue, clientID, supplyType, out totalPendingOrderQuantity, out totalPendingOrderAmount);
            }
            else if (datetype == 2)
            {
                return this.ReportDataProviderInstance.GetPendingOrdersReport(
                    startIndex, pageSize, out pendingOrdercount, DateTime.MinValue, DateTime.MaxValue, start, end, clientID, supplyType, out totalPendingOrderQuantity, out totalPendingOrderAmount);
            }
            else if (datetype == 3)
            {
                return this.ReportDataProviderInstance.GetPendingOrdersReport(
                    startIndex, pageSize, out pendingOrdercount, start, end, start, end, clientID, supplyType, out totalPendingOrderQuantity, out totalPendingOrderAmount);
            }
            else
            {
                return this.ReportDataProviderInstance.GetPendingOrdersReport(
                    startIndex, pageSize, out pendingOrdercount, DateTime.MinValue, DateTime.MaxValue, DateTime.MinValue, DateTime.MaxValue, clientID, supplyType, out totalPendingOrderQuantity, out totalPendingOrderAmount);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="startIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        /// <author>vikas.agarwal</author>
        public int GetPendingOrdersReportCount(
            int startIndex,
            int pageSize,
            DateTime start,
            DateTime end,
            int datetype,
            int clientID,
            int supplyType
            )
        {
            return pendingOrdercount;
        }

        public DataSet GetPendingOrdersReportTotals(
            int startIndex,
            int pageSize,
            DateTime start,
            DateTime end,
            int datetype,
            int clientID,
            int supplyType,
            out int totalPendingOrderQuantity,
            out double totalPendingOrderAmount
            )
        {
            DataSet ds = new DataSet();
            if (datetype == 1)
            {
                return this.ReportDataProviderInstance.GetPendingOrdersReport(
                     startIndex, pageSize, out pendingOrdercount, start, end, DateTime.MinValue, DateTime.MaxValue, clientID, supplyType, out totalPendingOrderQuantity, out totalPendingOrderAmount);
            }
            else if (datetype == 2)
            {
                return this.ReportDataProviderInstance.GetPendingOrdersReport(
                    startIndex, pageSize, out pendingOrdercount, DateTime.MinValue, DateTime.MaxValue, start, end, clientID, supplyType, out totalPendingOrderQuantity, out totalPendingOrderAmount);
            }
            else if (datetype == 3)
            {
                return this.ReportDataProviderInstance.GetPendingOrdersReport(
                    startIndex, pageSize, out pendingOrdercount, start, end, start, end, clientID, supplyType, out totalPendingOrderQuantity, out totalPendingOrderAmount);
            }
            else
            {
                return this.ReportDataProviderInstance.GetPendingOrdersReport(
                      startIndex, pageSize, out pendingOrdercount, DateTime.MinValue, DateTime.MaxValue, DateTime.MinValue, DateTime.MaxValue, clientID, supplyType, out totalPendingOrderQuantity, out totalPendingOrderAmount);
            }

        }


        int shipmentRegistercount = 0;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="startIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        /// <author>vikas.agarwal</author>
        public DataSet GetShipmentRegisterReport(int startIndex, int pageSize, DateTime start, DateTime end, int clientId, int supplyType)
        {
            return this.ReportDataProviderInstance.GetShipmentRegisterReport(
                startIndex, pageSize, out shipmentRegistercount, start, end, clientId, supplyType);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="startIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        /// <author>vikas.agarwal</author>
        public int GetShipmentRegisterReportCount(int startIndex, int pageSize, DateTime start, DateTime end, int clientId, int supplyType)
        {
            return shipmentRegistercount;
        }

        int monthlyShipmentDetailscount = 0;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="startIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        /// <author>vikas.agarwal</author>
        public DataSet GetShipmentMonthlyDetailsReport(
            int startIndex,
            int pageSize,
            int month,
            int year
            )
        {
            return this.ReportDataProviderInstance.GetShipmentMonthlyDetailsReport(startIndex, pageSize,
                out monthlyShipmentDetailscount, month, year);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="startIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        /// <author>vikas.agarwal</author>
        public int GetShipmentMonthlyDetailsReportCount(
            int startIndex,
            int pageSize,
            int month,
            int year
            )
        {
            return monthlyShipmentDetailscount;
        }

        int pendingPaymentscount = 0;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="StartRecord"></param>
        /// <param name="DueStartDate"></param>
        /// <param name="DueEndDate"></param>
        /// <param name="BEStartDate"></param>
        /// <param name="BEEndDate"></param>
        /// <param name="BENumber"></param>
        /// <param name="ClientID"></param>
        /// <returns></returns>
        public DataSet GetPendingPaymentsReport(
           int startIndex,
           int pageSize,
           DateTime startDate,
           DateTime endDate,
           string bENumber,
            int datetype,
           int clientID,
           string GroupField)
        {
            if (datetype == 1)
            {
                return this.ReportDataProviderInstance.GetPendingPaymentsReport(
                    startIndex, pageSize, out pendingPaymentscount, startDate, endDate, DateTime.MinValue, DateTime.MaxValue, bENumber, clientID, GroupField);
            }
            else if (datetype == 2)
            {
                return this.ReportDataProviderInstance.GetPendingPaymentsReport(
                    startIndex, pageSize, out pendingPaymentscount, DateTime.MinValue, DateTime.MaxValue, startDate, endDate, bENumber, clientID, GroupField);
            }
            else if (datetype == 3)
            {
                return this.ReportDataProviderInstance.GetPendingPaymentsReport(
                    startIndex, pageSize, out pendingPaymentscount, startDate, endDate, startDate, endDate, bENumber, clientID, GroupField);
            }
            else
            {
                return this.ReportDataProviderInstance.GetPendingPaymentsReport(
                    startIndex, pageSize, out pendingPaymentscount, DateTime.MinValue, DateTime.MaxValue, DateTime.MinValue, DateTime.MaxValue, bENumber, clientID, GroupField);
            }
        }



        public int GetPendingPaymentsReportCount(
           int startIndex,
           int pageSize,
           DateTime startDate,
           DateTime endDate,
           string bENumber,
            int datetype,
           int clientID)
        {
            return pendingPaymentscount;
        }

        public DataSet GetPPMeetingFormDataForStyleCutToday(DateTime Date)
        {
            return this.ReportDataProviderInstance.GetPPMeetingFormDataForStyleCutToday(Date);
        }

        public DataSet GetSignOff(int ClientId)
        {
            return this.ReportDataProviderInstance.GetSignOff(ClientId);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ClientId"></param>
        /// <returns></returns>
        public List<string> GetAllClientNames(string stringClients)
        {
            return this.ReportDataProviderInstance.GetAllClientNames(stringClients);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="stringClients"></param>
        /// <returns></returns>
        public string GetAllClientsId(string stringClients)
        {
            return this.ReportDataProviderInstance.GetAllClientsIds(stringClients);
        }
        # region Excel Method

        public bool GenerateShipmentStatementExcel(string PDFPath, string ReportType, DateTime FromDate, DateTime ToDate)
        {
            string bgColor = "#CC99FF";
            string altBgColor = "#FFFFFF";
            string color = bgColor;
            string beNum = "";
            double totaslCif = 0;
            if (!Directory.Exists(iKandi.Common.Constants.TEMP_FOLDER_PATH))
                Directory.CreateDirectory(iKandi.Common.Constants.TEMP_FOLDER_PATH);

            DataSet ds = this.ReportDataProviderInstance.GetShipmentEmailReportData(FromDate, ToDate);

            if (ds.Tables.Count > 0)
            {
                string fileName = ReportType + " SHIPMENT REPORT ON -" + FromDate.ToString("dd MMM yyy") + " to " + ToDate.ToString("dd MMM yyy") + ".xls";

                string pdfFilePath = Path.Combine(iKandi.Common.Constants.TEMP_FOLDER_PATH, fileName);

                string headerText = ReportType + " DETAILS  OF  SHIPMENT  (IKANDI)  as  on  : " + FromDate.ToString("dd MMM yyy") + " To " + ToDate.ToString("dd MMM yyy");
                ExcelGenerator genExcal = new ExcelGenerator(pdfFilePath, headerText);

                genExcal.Columns = new List<ExcelHeader>(); // Header of the main grid

                ExcelHeader Header = new ExcelHeader("DIVISION", iKandi.Common.TextAlignment.center);
                Header.BackGroundColor = "#FFFF99";
                Header.FontColor = "black";
                Header.FontSize = 14;
                Header.Width = 6;
                Header.Isbold = true;
                genExcal.Columns.Add(Header);

                Header = new ExcelHeader("Bank Ref No.", iKandi.Common.TextAlignment.center);
                Header.BackGroundColor = "#FFFF99";
                Header.FontColor = "black";
                Header.FontSize = 14;
                Header.Width = 8;
                Header.Isbold = true;
                genExcal.Columns.Add(Header);

                Header = new ExcelHeader("AWB/ BL NO.", iKandi.Common.TextAlignment.center);
                Header.BackGroundColor = "#FFFF99";
                Header.FontColor = "black";
                Header.FontSize = 14;
                Header.Width = 8;
                Header.Isbold = true;
                genExcal.Columns.Add(Header);

                Header = new ExcelHeader("HAWB NO.", iKandi.Common.TextAlignment.center);
                Header.BackGroundColor = "#FFFF99";
                Header.FontColor = "black";
                Header.FontSize = 14;
                Header.Width = 8;
                Header.Isbold = true;
                genExcal.Columns.Add(Header);

                Header = new ExcelHeader("AWB. DATE", iKandi.Common.TextAlignment.center);
                Header.BackGroundColor = "#FFFF99";
                Header.FontColor = "black";
                Header.FontSize = 14;
                Header.Width = 7;
                Header.Isbold = true;
                genExcal.Columns.Add(Header);

                Header = new ExcelHeader("INVOICE NO.", iKandi.Common.TextAlignment.center);
                Header.BackGroundColor = "#FFFF99";
                Header.FontColor = "black";
                Header.FontSize = 14;
                Header.Width = 8;
                Header.Isbold = true;
                genExcal.Columns.Add(Header);

                Header = new ExcelHeader("ORDER NO.", iKandi.Common.TextAlignment.center);
                Header.BackGroundColor = "#FFFF99";
                Header.FontColor = "black";
                Header.FontSize = 14;
                Header.Width = 8;
                Header.Isbold = true;
                genExcal.Columns.Add(Header);

                Header = new ExcelHeader("STYLE NO.", iKandi.Common.TextAlignment.center);
                Header.BackGroundColor = "#FFFF99";
                Header.FontColor = "black";
                Header.FontSize = 14;
                Header.Width = 8;
                Header.Isbold = true;
                genExcal.Columns.Add(Header);

                Header = new ExcelHeader("QUANTITY IN PCS.", iKandi.Common.TextAlignment.center);
                Header.BackGroundColor = "#FFFF99";
                Header.FontColor = "black";
                Header.FontSize = 14;
                Header.Width = 6;
                Header.Isbold = true;
                genExcal.Columns.Add(Header);

                Header = new ExcelHeader("UNIT PRICE IN GBP.", iKandi.Common.TextAlignment.center);
                Header.BackGroundColor = "#FFFF99";
                Header.FontColor = "black";
                Header.FontSize = 14;
                Header.Width = 6;
                Header.Isbold = true;
                genExcal.Columns.Add(Header);

                Header = new ExcelHeader("FOB VALUE IN GBP.", iKandi.Common.TextAlignment.center);
                Header.BackGroundColor = "#FFFF99";
                Header.FontColor = "black";
                Header.FontSize = 14;
                Header.Width = 8;
                Header.Isbold = true;
                genExcal.Columns.Add(Header);

                Header = new ExcelHeader("FREIGHT IN (GBP)", iKandi.Common.TextAlignment.center);
                Header.BackGroundColor = "#FFFF99";
                Header.FontColor = "black";
                Header.FontSize = 14;
                Header.Width = 8;
                Header.Isbold = true;
                genExcal.Columns.Add(Header);

                Header = new ExcelHeader("INSURANCE IN (GBP)", iKandi.Common.TextAlignment.center);
                Header.BackGroundColor = "#FFFF99";
                Header.FontColor = "black";
                Header.FontSize = 14;
                Header.Width = 8;
                Header.Isbold = true;
                genExcal.Columns.Add(Header);

                Header = new ExcelHeader("TOTAL CIF VALUE IN (GBP)", iKandi.Common.TextAlignment.center);
                Header.BackGroundColor = "#FFFF99";
                Header.FontColor = "black";
                Header.FontSize = 14;
                Header.Width = 8;
                Header.Isbold = true;
                genExcal.Columns.Add(Header);

                if (ds.Tables[0].Rows.Count == 0)
                {
                    return false;
                }

                else if (ds.Tables[0].Rows.Count > 0) // For target Date
                {
                    genExcal.Rows = new List<List<ExcelCell>>(); // Rows adding logic of the Main grid

                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        List<ExcelCell> row = new List<ExcelCell>();

                        // for Division
                        string division = dr["CompanyName"] == DBNull.Value ? string.Empty : Convert.ToString(dr["CompanyName"]);
                        ExcelCell cell = new ExcelCell(division, iKandi.Common.TextAlignment.left);
                        cell.BackGroundColor = "#FF9900";
                        cell.FontColor = "Black";
                        cell.FontSize = 13;
                        cell.Isbold = false;
                        row.Add(cell);

                        // For BE NUM
                        string BankRefBo = dr["BENumber"] == DBNull.Value ? string.Empty : Convert.ToString(dr["BENumber"]);
                        cell = new ExcelCell(BankRefBo, iKandi.Common.TextAlignment.center);

                        if (beNum.ToUpper() == BankRefBo.ToUpper())
                        {
                            color = bgColor;
                        }
                        else
                        {
                            beNum = BankRefBo;
                            color = altBgColor;
                            string tempColor = altBgColor;
                            altBgColor = bgColor;
                            bgColor = tempColor;
                        }

                        cell.BackGroundColor = color;
                        cell.FontColor = "Black";
                        cell.FontSize = 13;
                        cell.Isbold = false;
                        row.Add(cell);


                        // For AWB/BL NUM
                        string BlNum = dr["BLAWBNo"] == DBNull.Value ? string.Empty : Convert.ToString(dr["BLAWBNo"]);
                        cell = new ExcelCell(BlNum, iKandi.Common.TextAlignment.center);
                        cell.BackGroundColor = color;
                        cell.FontColor = "Black";
                        cell.FontSize = 13;
                        cell.Isbold = false;
                        row.Add(cell);

                        // For HAWB Num
                        string hawbNo = dr["HAWBNO"] == DBNull.Value ? string.Empty : Convert.ToString(dr["HAWBNO"]);
                        cell = new ExcelCell(hawbNo, iKandi.Common.TextAlignment.center);
                        cell.BackGroundColor = color;
                        //cell.BackGroundColor = "#CC99FF";
                        cell.FontColor = "Black";
                        cell.FontSize = 13;
                        cell.Isbold = false;
                        row.Add(cell);

                        // For AWB Date
                        string AwbDate = (dr["ExpectedDispatchDate"] == DBNull.Value || Convert.ToDateTime(dr["ExpectedDispatchDate"]) == DateTime.MinValue) ? string.Empty : Convert.ToDateTime(dr["ExpectedDispatchDate"]).ToString("MM/dd/yyyy");
                        cell = new ExcelCell(AwbDate, iKandi.Common.TextAlignment.center);
                        cell.BackGroundColor = color;
                        cell.FontColor = "Black";
                        cell.FontSize = 13;
                        cell.Isbold = false;
                        row.Add(cell);

                        // For Invoice Number
                        string invoiceNumber = (dr["InvoiceNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["InvoiceNumber"]);
                        cell = new ExcelCell(invoiceNumber, iKandi.Common.TextAlignment.left);
                        cell.BackGroundColor = color;
                        cell.FontColor = "Black";
                        cell.FontSize = 13;
                        cell.Isbold = false;
                        row.Add(cell);

                        // For OrderNumber
                        string orderNumber = (dr["SerialNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["SerialNumber"]);
                        cell = new ExcelCell(orderNumber, iKandi.Common.TextAlignment.center);
                        cell.BackGroundColor = color;
                        cell.FontColor = "Black";
                        cell.FontSize = 13;
                        cell.Isbold = false;
                        row.Add(cell);

                        // For Style Number
                        string styleNumber = (dr["StyleNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["StyleNumber"]);
                        cell = new ExcelCell(styleNumber, iKandi.Common.TextAlignment.center);
                        cell.BackGroundColor = color;
                        cell.FontColor = "Black";
                        cell.FontSize = 13;
                        cell.Isbold = false;
                        row.Add(cell);


                        // For Quantity
                        string qty = (dr["Quantity"] == DBNull.Value) ? string.Empty : Convert.ToInt32(dr["Quantity"]).ToString("N0");
                        cell = new ExcelCell(qty, iKandi.Common.TextAlignment.center);
                        cell.BackGroundColor = color;
                        cell.FontColor = "Black";
                        cell.FontSize = 13;
                        cell.Isbold = false;
                        row.Add(cell);

                        //Unit Price
                        string unitPrice = (dr["UnitPrice"] == DBNull.Value) ? string.Empty : Convert.ToDouble(dr["UnitPrice"]).ToString("N2");
                        cell = new ExcelCell(unitPrice, iKandi.Common.TextAlignment.center);
                        cell.BackGroundColor = color;
                        cell.FontColor = "Black";
                        cell.FontSize = 13;
                        cell.Isbold = false;
                        row.Add(cell);

                        // Fob Value
                        string fobValue = (dr["FOBValue"] == DBNull.Value) ? string.Empty : Convert.ToDouble(dr["FOBValue"]).ToString("N2");
                        cell = new ExcelCell(fobValue, iKandi.Common.TextAlignment.right);
                        cell.BackGroundColor = color;
                        cell.FontColor = "Black";
                        cell.FontSize = 13;
                        cell.Isbold = false;
                        row.Add(cell);

                        //Freight
                        string freight = (dr["Freight"] == DBNull.Value) ? string.Empty : Convert.ToDouble(dr["Freight"]).ToString("N2");
                        cell = new ExcelCell(freight, iKandi.Common.TextAlignment.right);
                        cell.BackGroundColor = color;
                        cell.FontColor = "Black";
                        cell.FontSize = 13;
                        cell.Isbold = false;
                        row.Add(cell);

                        //Insurance
                        string insurance = (dr["Insurance"] == DBNull.Value) ? string.Empty : Convert.ToDouble(dr["Insurance"]).ToString("N2");
                        cell = new ExcelCell(insurance, iKandi.Common.TextAlignment.right);
                        cell.BackGroundColor = color;
                        cell.FontColor = "Black";
                        cell.FontSize = 13;
                        cell.Isbold = false;
                        row.Add(cell);

                        //Total Cif
                        string total = (dr["TotalCIF"] == DBNull.Value) ? string.Empty : Convert.ToDouble(dr["TotalCIF"]).ToString("N2");
                        cell = new ExcelCell(total, iKandi.Common.TextAlignment.right);
                        cell.BackGroundColor = color;
                        cell.FontColor = "Black";
                        cell.FontSize = 13;
                        cell.Isbold = false;
                        row.Add(cell);

                        genExcal.Rows.Add(row);



                        totaslCif += (dr["TotalCIF"] == DBNull.Value) ? 0 : Convert.ToDouble(dr["TotalCIF"]);

                    }
                    List<ExcelCell> row1 = new List<ExcelCell>();

                    // for Division blank

                    ExcelCell cell1 = new ExcelCell("Total", iKandi.Common.TextAlignment.left);
                    cell1.BackGroundColor = "#FFFF99";
                    cell1.FontColor = "Black";
                    cell1.FontSize = 13;
                    cell1.Isbold = true;
                    row1.Add(cell1);

                    // For AWB/BL NUM

                    cell1 = new ExcelCell("", iKandi.Common.TextAlignment.center);
                    cell1.BackGroundColor = "#FFFF99";
                    cell1.FontColor = "Black";
                    cell1.FontSize = 13;
                    cell1.Isbold = false;
                    row1.Add(cell1);

                    // For AWB/BL NUM

                    cell1 = new ExcelCell("", iKandi.Common.TextAlignment.center);
                    cell1.BackGroundColor = "#FFFF99";
                    cell1.FontColor = "Black";
                    cell1.FontSize = 13;
                    cell1.Isbold = false;
                    row1.Add(cell1);

                    // For HAWB Num

                    cell1 = new ExcelCell("", iKandi.Common.TextAlignment.center);
                    cell1.BackGroundColor = "#FFFF99";
                    cell1.FontColor = "Black";
                    cell1.FontSize = 13;
                    cell1.Isbold = false;
                    row1.Add(cell1);

                    // For AWB Date

                    cell1 = new ExcelCell("", iKandi.Common.TextAlignment.center);
                    cell1.BackGroundColor = "#FFFF99";
                    cell1.FontColor = "Black";
                    cell1.FontSize = 13;
                    cell1.Isbold = false;
                    row1.Add(cell1);

                    // For Invoice Number

                    cell1 = new ExcelCell("", iKandi.Common.TextAlignment.left);
                    cell1.BackGroundColor = "#FFFF99";
                    cell1.FontColor = "Black";
                    cell1.FontSize = 13;
                    cell1.Isbold = false;
                    row1.Add(cell1);

                    // For OrderNumber

                    cell1 = new ExcelCell("", iKandi.Common.TextAlignment.center);
                    cell1.BackGroundColor = "#FFFF99";
                    cell1.FontColor = "Black";
                    cell1.FontSize = 13;
                    cell1.Isbold = false;
                    row1.Add(cell1);

                    // For Style Number

                    cell1 = new ExcelCell("", iKandi.Common.TextAlignment.center);
                    cell1.BackGroundColor = "#FFFF99";
                    cell1.FontColor = "Black";
                    cell1.FontSize = 13;
                    cell1.Isbold = false;
                    row1.Add(cell1);

                    // For Quantity

                    cell1 = new ExcelCell("", iKandi.Common.TextAlignment.center);
                    cell1.BackGroundColor = "#FFFF99";
                    cell1.FontColor = "Black";
                    cell1.FontSize = 13;
                    cell1.Isbold = false;
                    row1.Add(cell1);

                    //Unit Price

                    cell1 = new ExcelCell("", iKandi.Common.TextAlignment.center);
                    cell1.BackGroundColor = "#FFFF99";
                    cell1.FontColor = "Black";
                    cell1.FontSize = 13;
                    cell1.Isbold = false;
                    row1.Add(cell1);

                    // Fob Value

                    cell1 = new ExcelCell("", iKandi.Common.TextAlignment.right);
                    cell1.BackGroundColor = "#FFFF99";
                    cell1.FontColor = "Black";
                    cell1.FontSize = 13;
                    cell1.Isbold = false;
                    row1.Add(cell1);

                    //Freight

                    cell1 = new ExcelCell("", iKandi.Common.TextAlignment.right);
                    cell1.BackGroundColor = "#FFFF99";
                    cell1.FontColor = "Black";
                    cell1.FontSize = 13;
                    cell1.Isbold = false;
                    row1.Add(cell1);

                    //Insurance

                    cell1 = new ExcelCell("", iKandi.Common.TextAlignment.right);
                    cell1.BackGroundColor = "#FFFF99";
                    cell1.FontColor = "Black";
                    cell1.FontSize = 13;
                    cell1.Isbold = false;
                    row1.Add(cell1);

                    //Total Cif

                    cell1 = new ExcelCell(totaslCif.ToString("N2"), iKandi.Common.TextAlignment.right);
                    cell1.BackGroundColor = "#FFFF99";
                    cell1.FontColor = "Black";
                    cell1.FontSize = 13;
                    cell1.Isbold = true;
                    row1.Add(cell1);

                    genExcal.Rows.Add(row1);

                }

                return genExcal.GenerateExcel();
            }
            else
            {
                return false;
            }

        }

        public DataSet GetFactoryLineWisePlanReport(string searchText, DateTime FromDate, DateTime ToDate, int Unit)
        {
            return this.ReportDataProviderInstance.GetFactoryLineWisePlanReport(searchText, FromDate, ToDate, Unit);
        }

        public DataSet GetPriceVariationReport(int Type)
        {
            return this.ReportDataProviderInstance.GetPriceVariationReport(Type);
        }

        public DataSet GetPendingBuyingSamplesReport(int PageSize, int PageIndex, out int TotalRowCount, string searchText, DateTime FromDate, DateTime ToDate)
        {
            return this.ReportDataProviderInstance.GetPendingBuyingSamplesReport(PageSize, PageIndex, out TotalRowCount, searchText, FromDate, ToDate);
        }

        public DataSet GetFabricBookedPerformanceReport(int PageSize, int PageIndex, out int TotalRowCount, string searchText, int Months)
        {
            return this.ReportDataProviderInstance.GetFabricBookedPerformanceReport(PageSize, PageIndex, out TotalRowCount, searchText, Months);
        }

        public DataSet GetAverageLeadTimesReport(int DateType, int ClientID)
        {
            return this.ReportDataProviderInstance.GetAverageLeadTimesReport(DateType, ClientID);
        }

        #endregion
        //addde by abhishek on 6/7/2017 for fits report Excel
        public bool GenerateFitsReportExcel(string PDFPath, string ReportType, DataSet ds, string GlobalSheet)
        {

            //string bgColor = "#CC99FF";
            //string altBgColor = "#FFFFFF";
            //string color = bgColor;
            //string beNum = "";
            //double totaslCif = 0;
            //if (!Directory.Exists(iKandi.Common.Constants.TEMP_FOLDER_PATH))
            //    Directory.CreateDirectory(iKandi.Common.Constants.TEMP_FOLDER_PATH);

            //DataSet ds = this.ReportDataProviderInstance.GetShipmentEmailReportData(FromDate, ToDate);
            AdminController objadmin = new AdminController();
            //DataSet ds = objadmin.GetFitsReport("HANDOVER");

            if (ds.Tables[0].Rows.Count > 0)
            {
                //Hand Over (" + dt.Rows.Count + ")
                //string fileName = ReportType + "-" + DateTime.Now.ToString("dd MMM yyy");

                //string pdfFilePath = Path.Combine(iKandi.Common.Constants.TEMP_FOLDER_PATH, fileName);

                Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
                xlApp.DisplayAlerts = false;
                Excel.Workbook xlWorkBook = xlApp.Workbooks.Open(PDFPath, 0, false, 5, "", "", false, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "", true, false, 0, true, false, false);
                Excel.Sheets worksheets = xlWorkBook.Worksheets;

                //----------changed by Surendra Sharma for Pending weight style on 08-03-2018.----
                if (ReportType == "Pending weight style")
                {
                    GlobalCount_Weight = GlobalCount_Weight + 1;
                    var xlNewSheet = (Excel.Worksheet)worksheets.Add(worksheets[GlobalCount_Weight], Type.Missing, Type.Missing, Type.Missing);
                    xlNewSheet.Name = "Pending weight style";
                    xlNewSheet.Cells[1, 1] = "Style Number";
                    xlNewSheet.Cells[1, 2] = "ExFactory Date";
                    xlNewSheet.Cells[1, 3] = "Mode";
                    xlNewSheet.Cells[1, 4] = "Department Name";
                    xlNewSheet.Cells[1, 5] = "Client Name";

                    if (ds.Tables[0].Rows.Count == 0)
                    {
                        return false;
                    }
                    else if (ds.Tables[0].Rows.Count > 0)
                    {
                        int i = 1;
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            string StyleNumber = dr["StyleNumber"] == DBNull.Value ? string.Empty : Convert.ToString(dr["StyleNumber"]);
                            xlNewSheet.Cells[i + 1, 1] = StyleNumber;
                            xlNewSheet.Cells[i + 1, 2] = (dr["ExFactory"] == DBNull.Value || Convert.ToString(dr["ExFactory"]) == "") ? string.Empty : dr["ExFactory"];
                            xlNewSheet.Cells[i + 1, 3] = (dr["Code"] == DBNull.Value || Convert.ToString(dr["Code"]) == "") ? string.Empty : dr["Code"];
                            xlNewSheet.Cells[i + 1, 4] = (dr["DepartmentName"] == DBNull.Value || Convert.ToString(dr["DepartmentName"]) == "") ? string.Empty : dr["DepartmentName"];
                            xlNewSheet.Cells[i + 1, 5] = (dr["ClientName"] == DBNull.Value || Convert.ToString(dr["ClientName"]) == "") ? string.Empty : dr["ClientName"];

                            i++;
                        }
                        xlNewSheet.Columns.AutoFit();
                        xlNewSheet.Range["A1", "E1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        xlNewSheet.Range["A1", "E1"].EntireColumn.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        //xlNewSheet.Range["A1", "D1"].Font.Bold = true;
                        xlNewSheet.Range["A1"].EntireColumn.Font.Bold = true;
                        xlNewSheet.Range["B1"].EntireColumn.Font.Bold = true;
                        xlNewSheet.Range["B1"].EntireColumn.Font.Size = 14;
                        xlNewSheet.Range["A1"].Cells.Font.Bold = false;
                        xlNewSheet.Range["B1"].Cells.Font.Bold = false;
                        xlNewSheet.Range["B1"].Cells.Font.Size = 11;
                        xlNewSheet.Range["B1"].Cells.ColumnWidth = 16;
                        xlNewSheet.Range["A1", "E1"].EntireColumn.WrapText = true;

                        //----------change date format with filter created by Surendra Sharma on 09-03-2018.----
                        xlNewSheet.Range["B1"].Cells.EntireColumn.NumberFormat = "dd mmm (ddd);@";
                        //-------------End-----------------------------------------------------------------------

                        xlNewSheet.get_Range("A1:E" + i).Cells.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;

                        ((Excel.Worksheet)xlApp.ActiveWorkbook.Sheets[1]).Activate();

                        xlNewSheet.Select();

                        releaseObject(xlNewSheet);

                    }
                }
                //------------------------------End--------------------------------------------

                //--------------Pending Cost Confirmation-----------------------------------------------
                if (ReportType == "Pending_Cost_Confirmation")
                {
                    GlobalPending_Cost_Confirmation = GlobalPending_Cost_Confirmation + 1;
                    var xlNewSheet14 = (Excel.Worksheet)worksheets.Add(worksheets[GlobalPending_Cost_Confirmation], Type.Missing, Type.Missing, Type.Missing);
                    xlNewSheet14.Name = "Pending_Cost_Confirmation";
                    xlNewSheet14.Cells[1, 1] = "Customer";
                    xlNewSheet14.Cells[1, 2] = "Department Name";
                    xlNewSheet14.Cells[1, 3] = "Style";
                    xlNewSheet14.Cells[1, 4] = "Current Cost";
                    xlNewSheet14.Cells[1, 5] = "Requested Cost";
                    xlNewSheet14.Cells[1, 6] = "Request Raised Date";
                    xlNewSheet14.Cells[1, 7] = "First Exfactory";
                    xlNewSheet14.Cells[1, 8] = "AM Name";
                    xlNewSheet14.Cells[1, 9] = "Total Quantity";
                    xlNewSheet14.Cells[1, 10] = "Overall Diff. in Value(In Lacs)";

                    if (ds.Tables[0].Rows.Count == 0)
                    {
                        return false;
                    }
                    else if (ds.Tables[0].Rows.Count > 0)
                    {
                        int i = 1;
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            string currency = dr["Currency"] == DBNull.Value ? string.Empty : dr["Currency"].ToString();
                            xlNewSheet14.Cells[i + 1, 1] = dr["Customer"] == DBNull.Value ? string.Empty : dr["Customer"].ToString();
                            xlNewSheet14.Cells[i + 1, 2] = dr["DepartmentName"] == DBNull.Value ? string.Empty : dr["DepartmentName"].ToString();
                            xlNewSheet14.Cells[i + 1, 3] = dr["Style"] == DBNull.Value ? string.Empty : dr["Style"].ToString();
                            xlNewSheet14.Cells[i + 1, 4] = dr["CurrentCost"] == DBNull.Value ? string.Empty : dr["CurrentCost"].ToString();
                            xlNewSheet14.Cells[i + 1, 5] = dr["RequestedCost"] == DBNull.Value ? string.Empty : dr["RequestedCost"].ToString();
                            xlNewSheet14.Cells[i + 1, 6] = dr["RequestRaisedDate"] == DBNull.Value ? string.Empty : dr["RequestRaisedDate"].ToString();
                            xlNewSheet14.Cells[i + 1, 7] = dr["FirstExfactory"] == DBNull.Value ? string.Empty : dr["FirstExfactory"].ToString();
                            xlNewSheet14.Cells[i + 1, 8] = dr["FirstName"] == DBNull.Value ? string.Empty : dr["FirstName"].ToString();
                            xlNewSheet14.Cells[i + 1, 9] = dr["Quantity"] == DBNull.Value || Convert.ToInt32(dr["Quantity"]) == 0 ? string.Empty : Convert.ToInt32(dr["Quantity"]).ToString("N0");
                            xlNewSheet14.Cells[i + 1, 10] = dr["OverallPrice"] == DBNull.Value || Convert.ToInt32(dr["OverallPrice"]) == 0 ? string.Empty : (Convert.ToDecimal(dr["OverallPrice"].ToString()) / 100000).ToString();

                            xlNewSheet14.Range["D" + (i + 1)].Cells.NumberFormat = currency + " " + "0.00";
                            xlNewSheet14.Range["E" + (i + 1)].Cells.NumberFormat = currency + " " + "0.00";
                            xlNewSheet14.Range["J" + (i + 1)].Cells.NumberFormat = "₹" + " " + "0.0";

                            i++;
                        }
                        xlNewSheet14.Columns.AutoFit();
                        xlNewSheet14.Range["A2:A" + i].Cells.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Gray);
                        xlNewSheet14.Range["B2:B" + i].Cells.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Gray);
                        xlNewSheet14.Range["D2:D" + i].Cells.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Gray);
                        xlNewSheet14.Range["G2:G" + i].Cells.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Gray);
                        //xlNewSheet14.Range[""].EntireColumn.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Gray);

                        xlNewSheet14.Range["A1", "J1"].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        xlNewSheet14.Range["A1", "J1"].EntireColumn.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet14.Range["A1", "J1"].EntireColumn.WrapText = true;
                        xlNewSheet14.Range["F1"].Cells.EntireColumn.NumberFormat = "dd mmm (ddd);@";
                        xlNewSheet14.Range["G1"].Cells.EntireColumn.NumberFormat = "dd mmm (ddd);@";
                        xlNewSheet14.Range["A" + i, "J" + i].Cells.Font.Bold = true;
                        System.Drawing.Color back = System.Drawing.ColorTranslator.FromHtml("#fff0a5");
                        xlNewSheet14.Range["A" + i, "J" + i].Cells.Interior.Color = System.Drawing.ColorTranslator.ToOle(back);
                        xlNewSheet14.Range["A" + i, "J" + i].Cells.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black);

                        xlNewSheet14.get_Range("A1:J" + i).Cells.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;

                        ((Excel.Worksheet)xlApp.ActiveWorkbook.Sheets[1]).Activate();

                        xlNewSheet14.Select();

                        releaseObject(xlNewSheet14);
                    }
                }
                //------------------------------End--------------------------------------------

                if (ReportType == "HandOver-PreOrder")
                {
                    //iKandi.Common.Constants.WorkSheetCount_ForExcel = iKandi.Common.Constants.WorkSheetCount_ForExcel + 1;
                    GlobalCount = GlobalCount + 1;
                    var xlNewSheet = (Excel.Worksheet)worksheets.Add(worksheets[GlobalCount], Type.Missing, Type.Missing, Type.Missing);
                    xlNewSheet.Name = "HandOver-PreOrder";
                    xlNewSheet.Cells[1, 1] = "Style Number";
                    xlNewSheet.Cells[1, 2] = "HandOver Target Date";
                    xlNewSheet.Cells[1, 3] = "Style Created Date";
                    xlNewSheet.Cells[1, 4] = "PD Manager";
                    xlNewSheet.Cells[1, 5] = "PD";
                    if (ds.Tables[0].Rows.Count == 0)
                    {
                        return false;
                    }
                    else if (ds.Tables[0].Rows.Count > 0)
                    {
                        int i = 1;
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            string StyleNumber = dr["StyleNumber"] == DBNull.Value ? string.Empty : Convert.ToString(dr["StyleNumber"]);
                            xlNewSheet.Cells[i + 1, 1] = StyleNumber;
                            //string ETA = (dr["ETA"] == DBNull.Value || Convert.ToString(dr["ETA"]) == "") ? string.Empty : Convert.ToString(dr["ETA"]);
                            xlNewSheet.Cells[i + 1, 2] = (dr["ETA"] == DBNull.Value || Convert.ToString(dr["ETA"]) == "") ? string.Empty : dr["ETA"];
                            //string StyleCreatedOn = (dr["StyleCreatedDate"] == DBNull.Value || Convert.ToString(dr["StyleCreatedDate"]) == "") ? string.Empty : Convert.ToString(dr["StyleCreatedDate"]);
                            xlNewSheet.Cells[i + 1, 3] = (dr["StyleCreatedDate"] == DBNull.Value || Convert.ToString(dr["StyleCreatedDate"]) == "") ? string.Empty : dr["StyleCreatedDate"];
                            string PDManager = (dr["PD Manager"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["PD Manager"]);
                            xlNewSheet.Cells[i + 1, 4] = PDManager;
                            string PD = (dr["PD"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["PD"]);
                            xlNewSheet.Cells[i + 1, 5] = PD;
                            i++;
                        }
                        xlNewSheet.Columns.AutoFit();
                        xlNewSheet.Range["A1", "E1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        xlNewSheet.Range["A1", "E1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                        xlNewSheet.Range["A1", "E1"].Font.Bold = true;
                        ((Excel.Worksheet)xlApp.ActiveWorkbook.Sheets[1]).Activate();

                        xlNewSheet.Select();

                        releaseObject(xlNewSheet);

                    }



                }
                if (ReportType == "HandOver-PostOrder")
                {
                    //iKandi.Common.Constants.WorkSheetCount_ForExcel = iKandi.Common.Constants.WorkSheetCount_ForExcel + 1;
                    GlobalCount = GlobalCount + 1;
                    var xlNewSheet2 = (Excel.Worksheet)worksheets.Add(worksheets[GlobalCount], Type.Missing, Type.Missing, Type.Missing);
                    xlNewSheet2.Name = "HandOver-PostOrder";
                    xlNewSheet2.Cells[1, 1] = "Style Number";
                    xlNewSheet2.Cells[1, 2] = "HandOver Target Date";
                    xlNewSheet2.Cells[1, 3] = "Serial Number";
                    xlNewSheet2.Cells[1, 4] = "Type";
                    xlNewSheet2.Cells[1, 5] = "Order Date";
                    xlNewSheet2.Cells[1, 6] = "Account Manager";
                    xlNewSheet2.Cells[1, 7] = "Prod Merch";
                    xlNewSheet2.Cells[1, 8] = "Stc Target Date";
                    xlNewSheet2.Cells[1, 9] = "Ex-Factory Target Date";
                    if (ds.Tables[0].Rows.Count == 0)
                    {
                        return false;
                    }
                    else if (ds.Tables[0].Rows.Count > 0)
                    {
                        int j = 1;
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            xlNewSheet2.Cells[j + 1, 1] = dr["StyleNumber"] == DBNull.Value ? string.Empty : Convert.ToString(dr["StyleNumber"]);
                            xlNewSheet2.Cells[j + 1, 2] = (dr["ETA"] == DBNull.Value || Convert.ToString(dr["ETA"]) == "") ? string.Empty : dr["ETA"];
                            xlNewSheet2.Cells[j + 1, 3] = dr["SerialNumber"] == DBNull.Value ? string.Empty : Convert.ToString(dr["SerialNumber"]);
                            xlNewSheet2.Cells[j + 1, 4] = dr["Type"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Type"]);
                            xlNewSheet2.Cells[j + 1, 5] = (dr["OrderDate"] == DBNull.Value || Convert.ToString(dr["OrderDate"]) == "") ? string.Empty : dr["OrderDate"];
                            xlNewSheet2.Cells[j + 1, 6] = (dr["AC Manager"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["AC Manager"]);
                            xlNewSheet2.Cells[j + 1, 7] = (dr["PD Merch"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["PD Merch"]);
                            xlNewSheet2.Cells[j + 1, 8] = (dr["STCTargetDate"] == DBNull.Value || Convert.ToString(dr["STCTargetDate"]) == "") ? string.Empty : dr["STCTargetDate"];
                            xlNewSheet2.Cells[j + 1, 9] = (dr["ExfactDate"] == DBNull.Value || Convert.ToString(dr["ExfactDate"]) == "") ? string.Empty : dr["ExfactDate"];

                            j++;
                        }
                        xlNewSheet2.Columns.AutoFit();
                        xlNewSheet2.Range["A1", "I1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        xlNewSheet2.Range["A1", "I1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        //xlNewSheet2.Range["A1", "I1"].Font.Bold = true;
                        xlNewSheet2.Range["A1", "I1"].EntireColumn.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet2.Range["A1"].EntireColumn.Font.Bold = true;
                        xlNewSheet2.Range["I1"].EntireColumn.Font.Bold = true;
                        xlNewSheet2.Range["I1"].EntireColumn.Font.Size = 14;
                        xlNewSheet2.Range["A1"].Cells.Font.Bold = false;
                        xlNewSheet2.Range["I1"].Cells.Font.Bold = false;
                        xlNewSheet2.Range["I1"].Cells.Font.Size = 11;
                        xlNewSheet2.Range["B1"].Cells.ColumnWidth = 12;
                        xlNewSheet2.Range["C1"].Cells.ColumnWidth = 12;
                        xlNewSheet2.Range["F1"].Cells.ColumnWidth = 12;
                        xlNewSheet2.Range["I1"].Cells.ColumnWidth = 16;
                        xlNewSheet2.Range["A1", "I1"].EntireColumn.WrapText = true;
                        xlNewSheet2.Range["C1"].EntireColumn.Font.Bold = true;
                        xlNewSheet2.Range["C1"].EntireColumn.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Blue);
                        xlNewSheet2.Range["C1"].Cells.Font.Bold = false;
                        xlNewSheet2.Range["C1"].Cells.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black);
                        //----------change date format with filter created by Surendra Sharma on 09-03-2018.----
                        xlNewSheet2.Range["B1"].Cells.EntireColumn.NumberFormat = "dd mmm (ddd);@";
                        xlNewSheet2.Range["E1"].Cells.EntireColumn.NumberFormat = "dd mmm (ddd);@";
                        xlNewSheet2.Range["H1"].Cells.EntireColumn.NumberFormat = "dd mmm (ddd);@";
                        xlNewSheet2.Range["I1"].Cells.EntireColumn.NumberFormat = "dd mmm (ddd);@";
                        //-------------End-----------------------------------------------------------------------

                        xlNewSheet2.get_Range("A1:I" + j).Cells.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;

                        releaseObject(xlNewSheet2);


                    }

                }
                if (ReportType == "PatternReady-PreOrder")
                {
                    //iKandi.Common.Constants.WorkSheetCount_ForExcel = iKandi.Common.Constants.WorkSheetCount_ForExcel + 1;
                    GlobalCount = GlobalCount + 1;
                    var xlNewSheet3 = (Excel.Worksheet)worksheets.Add(worksheets[GlobalCount], Type.Missing, Type.Missing, Type.Missing);
                    xlNewSheet3.Name = "PatternReady-PreOrder";
                    xlNewSheet3.Cells[1, 1] = "Style Number";
                    xlNewSheet3.Cells[1, 2] = "Pattern Ready Target Date";
                    xlNewSheet3.Cells[1, 3] = "PD Manager";
                    xlNewSheet3.Cells[1, 4] = "PD";
                    xlNewSheet3.Cells[1, 5] = "Allocated To Master";
                    //xlNewSheet3.Cells[1, 6] = "Account Manager";
                    //xlNewSheet3.Cells[1, 7] = "PD";
                    //xlNewSheet3.Cells[1, 8] = "Stc Target Date";
                    //xlNewSheet3.Cells[1, 9] = "Ex-Factory Target Date";
                    if (ds.Tables[0].Rows.Count == 0)
                    {
                        return false;
                    }
                    else if (ds.Tables[0].Rows.Count > 0)
                    {
                        int K = 1;
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            xlNewSheet3.Cells[K + 1, 1] = dr["StyleNumber"] == DBNull.Value ? string.Empty : Convert.ToString(dr["StyleNumber"]);
                            xlNewSheet3.Cells[K + 1, 2] = (dr["ETA"] == DBNull.Value || Convert.ToString(dr["ETA"]) == "") ? string.Empty : dr["ETA"];
                            xlNewSheet3.Cells[K + 1, 3] = (dr["PD Manager"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["PD Manager"]);
                            xlNewSheet3.Cells[K + 1, 4] = (dr["PD"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["PD"]);
                            xlNewSheet3.Cells[K + 1, 5] = (dr["Allocated to Master"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["Allocated to Master"]);
                            //xlNewSheet3.Cells[K + 1, 6] = (dr["AC Manager"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["AC Manager"]);
                            //xlNewSheet3.Cells[K + 1, 7] = (dr["PD Merch"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["PD Merch"]);
                            //xlNewSheet3.Cells[K + 1, 8] = (dr["STCTargetDate"] == DBNull.Value || Convert.ToString(dr["STCTargetDate"]) == "") ? string.Empty : Convert.ToString(dr["STCTargetDate"]);
                            //xlNewSheet3.Cells[K + 1, 9] = (dr["ExfactDate"] == DBNull.Value || Convert.ToString(dr["ExfactDate"]) == "") ? string.Empty : Convert.ToString(dr["ExfactDate"]);
                            K++;
                        }
                        xlNewSheet3.Columns.AutoFit();
                        xlNewSheet3.Range["A1", "E1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        xlNewSheet3.Range["A1", "E1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                        xlNewSheet3.Range["A1", "E1"].Font.Bold = true;
                        ((Excel.Worksheet)xlApp.ActiveWorkbook.Sheets[GlobalCount]).Activate();
                        releaseObject(xlNewSheet3);


                    }

                }
                if (ReportType == "PatternReady-PostOrder")
                {
                    //iKandi.Common.Constants.WorkSheetCount_ForExcel = iKandi.Common.Constants.WorkSheetCount_ForExcel + 1;
                    GlobalCount = GlobalCount + 1;
                    var xlNewSheet4 = (Excel.Worksheet)worksheets.Add(worksheets[GlobalCount], Type.Missing, Type.Missing, Type.Missing);
                    xlNewSheet4.Name = "PatternReady-PostOrder";
                    xlNewSheet4.Cells[1, 1] = "Style Number";
                    xlNewSheet4.Cells[1, 2] = "Pattern Ready Target Date";
                    xlNewSheet4.Cells[1, 3] = "Serial Number";
                    xlNewSheet4.Cells[1, 4] = "Type";
                    xlNewSheet4.Cells[1, 5] = "Order Date";
                    xlNewSheet4.Cells[1, 6] = "Account Manager";
                    xlNewSheet4.Cells[1, 7] = "Prod Merch";
                    xlNewSheet4.Cells[1, 8] = "Allocated To Master";
                    xlNewSheet4.Cells[1, 9] = "Stc Target Date";
                    xlNewSheet4.Cells[1, 10] = "Ex-Factory Target Date";
                    if (ds.Tables[0].Rows.Count == 0)
                    {
                        return false;
                    }
                    else if (ds.Tables[0].Rows.Count > 0)
                    {
                        int L = 1;
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            xlNewSheet4.Cells[L + 1, 1] = dr["StyleNumber"] == DBNull.Value ? string.Empty : Convert.ToString(dr["StyleNumber"]);
                            xlNewSheet4.Cells[L + 1, 2] = (dr["ETA"] == DBNull.Value || Convert.ToString(dr["ETA"]) == "") ? string.Empty : dr["ETA"];
                            xlNewSheet4.Cells[L + 1, 3] = dr["SerialNumber"] == DBNull.Value ? string.Empty : Convert.ToString(dr["SerialNumber"]);
                            xlNewSheet4.Cells[L + 1, 4] = dr["Type"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Type"]);
                            xlNewSheet4.Cells[L + 1, 5] = (dr["OrderDate"] == DBNull.Value || Convert.ToString(dr["OrderDate"]) == "") ? string.Empty : dr["OrderDate"];
                            xlNewSheet4.Cells[L + 1, 6] = (dr["AC Manager"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["AC Manager"]);
                            xlNewSheet4.Cells[L + 1, 7] = (dr["PD Merch"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["PD Merch"]);
                            xlNewSheet4.Cells[L + 1, 8] = (dr["Allocated to Master"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["Allocated to Master"]);
                            xlNewSheet4.Cells[L + 1, 9] = (dr["STCTargetDate"] == DBNull.Value || Convert.ToString(dr["STCTargetDate"]) == "") ? string.Empty : dr["STCTargetDate"];
                            xlNewSheet4.Cells[L + 1, 10] = (dr["ExfactDate"] == DBNull.Value || Convert.ToString(dr["ExfactDate"]) == "") ? string.Empty : dr["ExfactDate"];
                            L++;
                        }
                        xlNewSheet4.Columns.AutoFit();
                        xlNewSheet4.Range["A1", "J1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        xlNewSheet4.Range["A1", "J1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                        // xlNewSheet4.Range["A1", "J1"].Font.Bold = true;

                        xlNewSheet4.Range["A1", "J1"].EntireColumn.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet4.Range["A1"].EntireColumn.Font.Bold = true;
                        xlNewSheet4.Range["C1"].EntireColumn.Font.Bold = true;
                        xlNewSheet4.Range["C1"].EntireColumn.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Blue);
                        //xlNewSheet4.Range["I1"].EntireColumn.Font.Size = 14;
                        xlNewSheet4.Range["A1"].Cells.Font.Bold = false;
                        xlNewSheet4.Range["C1"].Cells.Font.Bold = false;
                        xlNewSheet4.Range["C1"].Cells.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black);
                        xlNewSheet4.Range["B1"].Cells.ColumnWidth = 12;
                        xlNewSheet4.Range["A1", "J1"].EntireColumn.WrapText = true;
                        xlNewSheet4.Range["J1"].EntireColumn.Font.Bold = true;
                        xlNewSheet4.Range["J1"].EntireColumn.Font.Size = 14;
                        xlNewSheet4.Range["J1"].Cells.Font.Bold = false;
                        xlNewSheet4.Range["J1"].Cells.Font.Size = 11;
                        xlNewSheet4.Range["J1"].Cells.ColumnWidth = 16;
                        //xlNewSheet4.Range["I1"].Cells.Font.Size = 11;
                        //----------change date format with filter created by Surendra Sharma on 09-03-2018.----
                        xlNewSheet4.Range["B1"].Cells.EntireColumn.NumberFormat = "dd mmm (ddd);@";
                        xlNewSheet4.Range["E1"].Cells.EntireColumn.NumberFormat = "dd mmm (ddd);@";
                        xlNewSheet4.Range["I1"].Cells.EntireColumn.NumberFormat = "dd mmm (ddd);@";
                        xlNewSheet4.Range["J1"].Cells.EntireColumn.NumberFormat = "dd mmm (ddd);@";
                        //-------------End-----------------------------------------------------------------------

                        xlNewSheet4.get_Range("A1:J" + L).Cells.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;

                        releaseObject(xlNewSheet4);


                    }

                }

                if (ReportType == "SampleSent-PreOrder")
                {
                    //iKandi.Common.Constants.WorkSheetCount_ForExcel = iKandi.Common.Constants.WorkSheetCount_ForExcel + 1;
                    GlobalCount = GlobalCount + 1;
                    var xlNewSheet5 = (Excel.Worksheet)worksheets.Add(worksheets[GlobalCount], Type.Missing, Type.Missing, Type.Missing);
                    xlNewSheet5.Name = "SampleSent-PreOrder";
                    xlNewSheet5.Cells[1, 1] = "Style Number";
                    xlNewSheet5.Cells[1, 2] = "Sample Sent Target Date";
                    xlNewSheet5.Cells[1, 3] = "PD Manager";
                    xlNewSheet5.Cells[1, 4] = "PD";
                    xlNewSheet5.Cells[1, 5] = "QC Name";
                    //xlNewSheet3.Cells[1, 6] = "Account Manager";
                    //xlNewSheet3.Cells[1, 7] = "PD";
                    //xlNewSheet3.Cells[1, 8] = "Stc Target Date";
                    //xlNewSheet3.Cells[1, 9] = "Ex-Factory Target Date";
                    if (ds.Tables[0].Rows.Count == 0)
                    {
                        return false;
                    }
                    else if (ds.Tables[0].Rows.Count > 0)
                    {
                        int L = 1;
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            xlNewSheet5.Cells[L + 1, 1] = dr["StyleNumber"] == DBNull.Value ? string.Empty : Convert.ToString(dr["StyleNumber"]);
                            xlNewSheet5.Cells[L + 1, 2] = (dr["ETA"] == DBNull.Value || Convert.ToString(dr["ETA"]) == "") ? string.Empty : dr["ETA"];
                            xlNewSheet5.Cells[L + 1, 3] = (dr["PD Manager"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["PD Manager"]);
                            xlNewSheet5.Cells[L + 1, 4] = (dr["PD"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["PD"]);
                            xlNewSheet5.Cells[L + 1, 5] = (dr["QC Name"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["QC Name"]);
                            //xlNewSheet3.Cells[K + 1, 6] = (dr["AC Manager"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["AC Manager"]);
                            //xlNewSheet3.Cells[K + 1, 7] = (dr["PD Merch"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["PD Merch"]);
                            //xlNewSheet3.Cells[K + 1, 8] = (dr["STCTargetDate"] == DBNull.Value || Convert.ToString(dr["STCTargetDate"]) == "") ? string.Empty : Convert.ToString(dr["STCTargetDate"]);
                            //xlNewSheet3.Cells[K + 1, 9] = (dr["ExfactDate"] == DBNull.Value || Convert.ToString(dr["ExfactDate"]) == "") ? string.Empty : Convert.ToString(dr["ExfactDate"]);
                            L++;
                        }
                        xlNewSheet5.Columns.AutoFit();
                        xlNewSheet5.Range["A1", "E1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        xlNewSheet5.Range["A1", "E1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                        xlNewSheet5.Range["A1", "E1"].Font.Bold = true;
                        releaseObject(xlNewSheet5);


                    }

                }
                if (ReportType == "SampleSent-PostOrder")
                {
                    //iKandi.Common.Constants.WorkSheetCount_ForExcel = iKandi.Common.Constants.WorkSheetCount_ForExcel + 1;
                    GlobalCount = GlobalCount + 1;
                    var xlNewSheet6 = (Excel.Worksheet)worksheets.Add(worksheets[GlobalCount], Type.Missing, Type.Missing, Type.Missing);
                    xlNewSheet6.Name = "SampleSent-PostOrder";
                    xlNewSheet6.Cells[1, 1] = "Style Number";
                    xlNewSheet6.Cells[1, 2] = "Sample Sent Target Date";
                    xlNewSheet6.Cells[1, 3] = "Serial Number";
                    xlNewSheet6.Cells[1, 4] = "Type";
                    xlNewSheet6.Cells[1, 5] = "Order Date";
                    xlNewSheet6.Cells[1, 6] = "Account Manager";
                    xlNewSheet6.Cells[1, 7] = "Prod Merch";
                    xlNewSheet6.Cells[1, 8] = "QC Name";
                    xlNewSheet6.Cells[1, 9] = "Stc Target Date";
                    xlNewSheet6.Cells[1, 10] = "Ex-Factory Target Date";
                    if (ds.Tables[0].Rows.Count == 0)
                    {
                        return false;
                    }
                    else if (ds.Tables[0].Rows.Count > 0)
                    {
                        int M = 1;
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            xlNewSheet6.Cells[M + 1, 1] = dr["StyleNumber"] == DBNull.Value ? string.Empty : Convert.ToString(dr["StyleNumber"]);
                            xlNewSheet6.Cells[M + 1, 2] = (dr["ETA"] == DBNull.Value || Convert.ToString(dr["ETA"]) == "") ? string.Empty : dr["ETA"];
                            xlNewSheet6.Cells[M + 1, 3] = dr["SerialNumber"] == DBNull.Value ? string.Empty : Convert.ToString(dr["SerialNumber"]);
                            xlNewSheet6.Cells[M + 1, 4] = dr["Type"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Type"]);
                            xlNewSheet6.Cells[M + 1, 5] = (dr["OrderDate"] == DBNull.Value || Convert.ToString(dr["OrderDate"]) == "") ? string.Empty : dr["OrderDate"];
                            xlNewSheet6.Cells[M + 1, 6] = (dr["AC Manager"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["AC Manager"]);
                            xlNewSheet6.Cells[M + 1, 7] = (dr["PD Merch"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["PD Merch"]);
                            xlNewSheet6.Cells[M + 1, 8] = (dr["QC Name"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["QC Name"]);
                            xlNewSheet6.Cells[M + 1, 9] = (dr["STCTargetDate"] == DBNull.Value || Convert.ToString(dr["STCTargetDate"]) == "") ? string.Empty : dr["STCTargetDate"];
                            xlNewSheet6.Cells[M + 1, 10] = (dr["ExfactDate"] == DBNull.Value || Convert.ToString(dr["ExfactDate"]) == "") ? string.Empty : dr["ExfactDate"];
                            M++;
                        }
                        xlNewSheet6.Columns.AutoFit();
                        xlNewSheet6.Range["A1", "J1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        xlNewSheet6.Range["A1", "J1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                        //xlNewSheet6.Range["A1", "J1"].Font.Bold = true;

                        xlNewSheet6.Range["A1", "J1"].EntireColumn.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet6.Range["A1"].EntireColumn.Font.Bold = true;
                        xlNewSheet6.Range["C1"].EntireColumn.Font.Bold = true;
                        xlNewSheet6.Range["C1"].EntireColumn.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Blue);
                        //xlNewSheet6.Range["I1"].EntireColumn.Font.Size = 14;
                        xlNewSheet6.Range["A1"].Cells.Font.Bold = false;
                        xlNewSheet6.Range["C1"].Cells.Font.Bold = false;
                        xlNewSheet6.Range["C1"].Cells.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black);
                        xlNewSheet6.Range["B1"].Cells.ColumnWidth = 13;
                        xlNewSheet6.Range["J1"].Cells.ColumnWidth = 13;
                        xlNewSheet6.Range["A1", "J1"].EntireColumn.WrapText = true;
                        xlNewSheet6.Range["J1"].EntireColumn.Font.Bold = true;
                        xlNewSheet6.Range["J1"].EntireColumn.Font.Size = 14;
                        xlNewSheet6.Range["J1"].Cells.Font.Bold = false;
                        xlNewSheet6.Range["J1"].Cells.Font.Size = 11;
                        xlNewSheet6.Range["J1"].Cells.ColumnWidth = 16;
                        //xlNewSheet6.Range["I1"].Cells.Font.Size = 11;
                        //----------change date format with filter created by Surendra Sharma on 09-03-2018.----
                        xlNewSheet6.Range["B1"].Cells.EntireColumn.NumberFormat = "dd mmm (ddd);@";
                        xlNewSheet6.Range["E1"].Cells.EntireColumn.NumberFormat = "dd mmm (ddd);@";
                        xlNewSheet6.Range["I1"].Cells.EntireColumn.NumberFormat = "dd mmm (ddd);@";
                        xlNewSheet6.Range["J1"].Cells.EntireColumn.NumberFormat = "dd mmm (ddd);@";
                        //-------------End-----------------------------------------------------------------------

                        xlNewSheet6.get_Range("A1:J" + M).Cells.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;

                        releaseObject(xlNewSheet6);
                    }

                }

                // add code by bharat on 19-july for Fits Comment 

                if (ReportType == "FitCommentes_Pending")
                {
                    //iKandi.Common.Constants.WorkSheetCount_ForExcel = iKandi.Common.Constants.WorkSheetCount_ForExcel + 1;
                    GlobalCount_FitsComenetes = GlobalCount_FitsComenetes + 1;
                    var xlNewSheet21 = (Excel.Worksheet)worksheets.Add(worksheets[GlobalCount_FitsComenetes], Type.Missing, Type.Missing, Type.Missing);
                    xlNewSheet21.Name = "FitCommentes_Pending";
                    xlNewSheet21.Cells[1, 1] = "Style Number";
                    xlNewSheet21.Cells[1, 2] = "FitsCommentes Upload Tgt Date";
                    xlNewSheet21.Cells[1, 3] = "Serial Number";
                    xlNewSheet21.Cells[1, 4] = "Type";
                    xlNewSheet21.Cells[1, 5] = "Order Date";
                    xlNewSheet21.Cells[1, 6] = "Account Manager";
                    xlNewSheet21.Cells[1, 7] = "Prod Merch";
                    xlNewSheet21.Cells[1, 8] = "QC Name";
                    xlNewSheet21.Cells[1, 9] = "Stc Target Date";
                    xlNewSheet21.Cells[1, 10] = "Ex-Factory Target Date";
                    xlNewSheet21.Cells[1, 11] = "Fits Comment Pending Over A Week";
                    xlNewSheet21.Cells[1, 12] = "Line Item Number";
                    if (ds.Tables[0].Rows.Count == 0)
                    {
                        return false;
                    }
                    else if (ds.Tables[0].Rows.Count > 0)
                    {
                        int M = 1;

                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            xlNewSheet21.Cells[M + 1, 1] = dr["StyleNumber"] == DBNull.Value ? string.Empty : Convert.ToString(dr["StyleNumber"]);
                            xlNewSheet21.Cells[M + 1, 2] = (dr["ETA"] == DBNull.Value || Convert.ToString(dr["ETA"]) == "") ? string.Empty : dr["ETA"];
                            xlNewSheet21.Cells[M + 1, 3] = dr["SerialNumber"] == DBNull.Value ? string.Empty : Convert.ToString(dr["SerialNumber"]);
                            xlNewSheet21.Cells[M + 1, 4] = dr["Type"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Type"]);
                            xlNewSheet21.Cells[M + 1, 5] = (dr["OrderDate"] == DBNull.Value || Convert.ToString(dr["OrderDate"]) == "") ? string.Empty : dr["OrderDate"];
                            xlNewSheet21.Cells[M + 1, 6] = (dr["AC Manager"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["AC Manager"]);
                            xlNewSheet21.Cells[M + 1, 7] = (dr["PD Merch"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["PD Merch"]);
                            xlNewSheet21.Cells[M + 1, 8] = (dr["QC Name"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["QC Name"]);
                            // xlNewSheet6.Cells[M + 1, 8] = (dr["Technologist"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["Technologist"]);
                            xlNewSheet21.Cells[M + 1, 9] = (dr["STCTargetDate"] == DBNull.Value || Convert.ToString(dr["STCTargetDate"]) == "") ? string.Empty : dr["STCTargetDate"];
                            xlNewSheet21.Cells[M + 1, 10] = (dr["ExfactDate"] == DBNull.Value || Convert.ToString(dr["ExfactDate"]) == "") ? string.Empty : dr["ExfactDate"];
                            if (dr["IsFitsCommentesPending"].ToString() == "1")
                                xlNewSheet21.Cells[M + 1, 11] = "True";
                            else
                                xlNewSheet21.Cells[M + 1, 11] = "False";
                            xlNewSheet21.Cells[M + 1, 12] = (dr["LineItemNumber"] == DBNull.Value || Convert.ToString(dr["LineItemNumber"]) == "") ? string.Empty : dr["LineItemNumber"];
                            M++;
                        }
                        xlNewSheet21.Columns.AutoFit();
                        xlNewSheet21.Range["A1", "L1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        xlNewSheet21.Range["A1", "L1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                        //xlNewSheet6.Range["A1", "J1"].Font.Bold = true;

                        xlNewSheet21.Range["A1", "L1"].EntireColumn.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet21.Range["A1"].EntireColumn.Font.Bold = true;
                        xlNewSheet21.Range["C1"].EntireColumn.Font.Bold = true;
                        xlNewSheet21.Range["C1"].EntireColumn.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Blue);
                        //xlNewSheet6.Range["I1"].EntireColumn.Font.Size = 14;
                        xlNewSheet21.Range["A1"].Cells.Font.Bold = false;
                        xlNewSheet21.Range["C1"].Cells.Font.Bold = false;
                        xlNewSheet21.Range["C1"].Cells.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black);
                        xlNewSheet21.Range["B1"].Cells.ColumnWidth = 13;
                        xlNewSheet21.Range["J1"].Cells.ColumnWidth = 13;
                        xlNewSheet21.Range["A1", "J1"].EntireColumn.WrapText = true;
                        xlNewSheet21.Range["J1"].EntireColumn.Font.Bold = true;
                        xlNewSheet21.Range["J1"].EntireColumn.Font.Size = 14;
                        xlNewSheet21.Range["J1"].Cells.Font.Bold = false;
                        xlNewSheet21.Range["J1"].Cells.Font.Size = 11;
                        xlNewSheet21.Range["J1"].Cells.ColumnWidth = 16;
                        //xlNewSheet6.Range["k1"].Cells.ColumnWidth = 80;
                        //xlNewSheet6.Range["J1"].Cells.ColumnWidth = 40;
                        //xlNewSheet6.Range["I1"].Cells.Font.Size = 11;
                        //----------change date format with filter created by Surendra Sharma on 09-03-2018.----
                        xlNewSheet21.Range["B1"].Cells.EntireColumn.NumberFormat = "dd mmm (ddd);@";
                        xlNewSheet21.Range["E1"].Cells.EntireColumn.NumberFormat = "dd mmm (ddd);@";
                        xlNewSheet21.Range["I1"].Cells.EntireColumn.NumberFormat = "dd mmm (ddd);@";
                        xlNewSheet21.Range["J1"].Cells.EntireColumn.NumberFormat = "dd mmm (ddd);@";
                        //-------------End-----------------------------------------------------------------------

                        xlNewSheet21.get_Range("A1:L" + M).Cells.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;

                        releaseObject(xlNewSheet21);
                    }

                }
                //end



                if (ReportType == "COSTING BIPL")
                {
                    //iKandi.Common.Constants.WorkSheetCount_ForExcel = iKandi.Common.Constants.WorkSheetCount_ForExcel + 1;
                    GlobalCount = GlobalCount + 1;
                    var xlNewSheet17 = (Excel.Worksheet)worksheets.Add(worksheets[GlobalCount], Type.Missing, Type.Missing, Type.Missing);
                    xlNewSheet17.Name = "Initial_Costing_BIPL";
                    xlNewSheet17.Cells[1, 1] = "Style Number";
                    xlNewSheet17.Cells[1, 2] = "Initial BIPL Target Date";
                    xlNewSheet17.Cells[1, 3] = "Style Created Date";
                    xlNewSheet17.Cells[1, 4] = "PD";


                    if (ds.Tables[0].Rows.Count == 0)
                    {
                        return false;
                    }
                    else if (ds.Tables[0].Rows.Count > 0)
                    {
                        int N = 1;
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            xlNewSheet17.Cells[N + 1, 1] = dr["StyleNumber"] == DBNull.Value ? string.Empty : Convert.ToString(dr["StyleNumber"]);
                            xlNewSheet17.Cells[N + 1, 2] = (dr["ETA"] == DBNull.Value || Convert.ToString(dr["ETA"]) == "") ? string.Empty : dr["ETA"];
                            xlNewSheet17.Cells[N + 1, 3] = (dr["StyleCreatedDate"] == DBNull.Value || Convert.ToString(dr["StyleCreatedDate"]) == "") ? string.Empty : dr["StyleCreatedDate"];
                            xlNewSheet17.Cells[N + 1, 4] = (dr["PD"] == DBNull.Value || Convert.ToString(dr["PD"]) == "") ? string.Empty : Convert.ToString(dr["PD"]);

                            N++;
                        }
                        xlNewSheet17.Columns.AutoFit();
                        xlNewSheet17.Range["A1", "D1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        xlNewSheet17.Range["A1", "D1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                        //xlNewSheet17.Range["A1", "D1"].Font.Bold = true;

                        xlNewSheet17.Range["A1", "D1"].EntireColumn.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet17.Range["A1"].EntireColumn.Font.Bold = true;
                        //xlNewSheet4.Range["I1"].EntireColumn.Font.Size = 14;
                        xlNewSheet17.Range["A1"].Cells.Font.Bold = false;
                        xlNewSheet17.Range["B1"].Cells.ColumnWidth = 13;
                        xlNewSheet17.Range["C1"].Cells.ColumnWidth = 13;
                        xlNewSheet17.Range["A1", "D1"].EntireColumn.WrapText = true;
                        //----------change date format with filter created by Surendra Sharma on 09-03-2018.----
                        xlNewSheet17.Range["B1"].Cells.EntireColumn.NumberFormat = "dd mmm (ddd);@";
                        xlNewSheet17.Range["C1"].Cells.EntireColumn.NumberFormat = "dd mmm (ddd);@";
                        //-------------End-----------------------------------------------------------------------

                        xlNewSheet17.get_Range("A1:D" + N).Cells.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;

                        releaseObject(xlNewSheet17);



                    }

                }
                if (ReportType == "PriceQuoted-BIPL")
                {
                    //iKandi.Common.Constants.WorkSheetCount_ForExcel = iKandi.Common.Constants.WorkSheetCount_ForExcel + 1;
                    GlobalCount = GlobalCount + 1;
                    var xlNewSheet7 = (Excel.Worksheet)worksheets.Add(worksheets[GlobalCount], Type.Missing, Type.Missing, Type.Missing);
                    xlNewSheet7.Name = "PriceQuoted-BIPL";
                    xlNewSheet7.Cells[1, 1] = "Style Number";
                    xlNewSheet7.Cells[1, 2] = "Price Quoted Target Date";
                    xlNewSheet7.Cells[1, 3] = "Style Created Date";
                    xlNewSheet7.Cells[1, 4] = "PD";
                    xlNewSheet7.Cells[1, 5] = "Pending Status";

                    if (ds.Tables[0].Rows.Count == 0)
                    {
                        return false;
                    }
                    else if (ds.Tables[0].Rows.Count > 0)
                    {
                        int N = 1;
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            xlNewSheet7.Cells[N + 1, 1] = dr["StyleNumber"] == DBNull.Value ? string.Empty : Convert.ToString(dr["StyleNumber"]);
                            xlNewSheet7.Cells[N + 1, 2] = (dr["ETA"] == DBNull.Value || Convert.ToString(dr["ETA"]) == "") ? string.Empty : dr["ETA"];
                            xlNewSheet7.Cells[N + 1, 3] = (dr["StyleCreatedDate"] == DBNull.Value || Convert.ToString(dr["StyleCreatedDate"]) == "") ? string.Empty : dr["StyleCreatedDate"];
                            xlNewSheet7.Cells[N + 1, 4] = (dr["PD"] == DBNull.Value || Convert.ToString(dr["PD"]) == "") ? string.Empty : Convert.ToString(dr["PD"]);
                            xlNewSheet7.Cells[N + 1, 5] = (dr["StatusPending"] == DBNull.Value || Convert.ToString(dr["StatusPending"]) == "") ? string.Empty : Convert.ToString(dr["StatusPending"]);

                            N++;
                        }
                        xlNewSheet7.Columns.AutoFit();
                        xlNewSheet7.Range["A1", "E1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        xlNewSheet7.Range["A1", "E1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                        //xlNewSheet7.Range["A1", "E1"].Font.Bold = true;

                        xlNewSheet7.Range["A1", "E1"].EntireColumn.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet7.Range["A1"].EntireColumn.Font.Bold = true;
                        xlNewSheet7.Range["E1"].EntireColumn.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Gray);
                        //xlNewSheet4.Range["I1"].EntireColumn.Font.Size = 14;
                        xlNewSheet7.Range["A1"].Cells.Font.Bold = false;
                        xlNewSheet7.Range["E1"].Cells.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black);
                        xlNewSheet7.Range["B1"].Cells.ColumnWidth = 12;
                        xlNewSheet7.Range["C1"].Cells.ColumnWidth = 12;
                        xlNewSheet7.Range["A1", "E1"].EntireColumn.WrapText = true;
                        //----------change date format with filter created by Surendra Sharma on 09-03-2018.----
                        xlNewSheet7.Range["B1"].Cells.EntireColumn.NumberFormat = "dd mmm (ddd);@";
                        xlNewSheet7.Range["C1"].Cells.EntireColumn.NumberFormat = "dd mmm (ddd);@";
                        //-------------End-----------------------------------------------------------------------

                        xlNewSheet7.get_Range("A1:E" + N).Cells.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;

                        releaseObject(xlNewSheet7);



                    }

                }

                if (ReportType == "TOP Pending")
                {
                    //iKandi.Common.Constants.WorkSheetCount_ForExcel = iKandi.Common.Constants.WorkSheetCount_ForExcel + 1;
                    GlobalCount_Top = GlobalCount_Top + 1;
                    var xlNewSheet8 = (Excel.Worksheet)worksheets.Add(worksheets[GlobalCount_Top], Type.Missing, Type.Missing, Type.Missing);
                    xlNewSheet8.Name = "TOP Pending";
                    xlNewSheet8.Cells[1, 1] = "Serial number";
                    xlNewSheet8.Cells[1, 2] = "Style number";
                    xlNewSheet8.Cells[1, 3] = "Department Name";
                    xlNewSheet8.Cells[1, 4] = "AM";
                    xlNewSheet8.Cells[1, 5] = "Contract Number";
                    xlNewSheet8.Cells[1, 6] = "Line-Item Number";
                    xlNewSheet8.Cells[1, 7] = "First Fabric Color/Print";
                    xlNewSheet8.Cells[1, 8] = "First Fabric Inhouse %";
                    xlNewSheet8.Cells[1, 9] = "Quantity";
                    xlNewSheet8.Cells[1, 10] = "Unit Name";
                    xlNewSheet8.Cells[1, 11] = "Sealed Date";
                    xlNewSheet8.Cells[1, 12] = "Pattern Sample Date";
                    xlNewSheet8.Cells[1, 13] = "HOPPM Date";
                    xlNewSheet8.Cells[1, 14] = "TOP ETA";
                    xlNewSheet8.Cells[1, 15] = "Test Report status";
                    xlNewSheet8.Cells[1, 16] = "Ex-Factory";
                    xlNewSheet8.Cells[1, 17] = "MDA";

                    if (ds.Tables[0].Rows.Count == 0)
                    {
                        return false;
                    }
                    else if (ds.Tables[0].Rows.Count > 0)
                    {
                        int O = 1;
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            xlNewSheet8.Cells[O + 1, 1] = dr["Serialnumber"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Serialnumber"]);
                            xlNewSheet8.Cells[O + 1, 2] = dr["Stylenumber"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Stylenumber"]);
                            xlNewSheet8.Cells[O + 1, 3] = dr["DepartmentName"] == DBNull.Value ? string.Empty : Convert.ToString(dr["DepartmentName"]);
                            xlNewSheet8.Cells[O + 1, 4] = dr["AM"] == DBNull.Value ? string.Empty : Convert.ToString(dr["AM"]);
                            xlNewSheet8.Cells[O + 1, 5] = dr["ContractNumber"] == DBNull.Value ? string.Empty : Convert.ToString(dr["ContractNumber"]);
                            xlNewSheet8.Cells[O + 1, 6] = dr["LineItemNumber"] == DBNull.Value ? string.Empty : Convert.ToString(dr["LineItemNumber"]);
                            xlNewSheet8.Cells[O + 1, 7] = dr["Fabric1Details"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Fabric1Details"]);
                            xlNewSheet8.Cells[O + 1, 8] = dr["First Fabric Inhouse %"] == DBNull.Value ? string.Empty : Convert.ToString(dr["First Fabric Inhouse %"]);
                            xlNewSheet8.Cells[O + 1, 9] = dr["Quantity"] == DBNull.Value ? string.Empty : Convert.ToString(Convert.ToInt32(dr["Quantity"]).ToString("N0"));
                            xlNewSheet8.Cells[O + 1, 10] = dr["UnitName"] == DBNull.Value ? string.Empty : Convert.ToString(dr["UnitName"]);
                            xlNewSheet8.Cells[O + 1, 11] = dr["SealDate"] == DBNull.Value ? string.Empty : dr["SealDate"];
                            xlNewSheet8.Cells[O + 1, 12] = dr["PatternSampleDate"] == DBNull.Value ? string.Empty : dr["PatternSampleDate"];
                            xlNewSheet8.Cells[O + 1, 13] = dr["HOPPMDate"] == DBNull.Value ? string.Empty : dr["HOPPMDate"];
                            xlNewSheet8.Cells[O + 1, 14] = dr["TOPETA"] == DBNull.Value ? string.Empty : dr["TOPETA"];
                            xlNewSheet8.Cells[O + 1, 15] = dr["TestReportsStatus"] == DBNull.Value ? string.Empty : dr["TestReportsStatus"];
                            xlNewSheet8.Cells[O + 1, 16] = dr["ExFactory"] == DBNull.Value ? string.Empty : dr["ExFactory"];
                            xlNewSheet8.Cells[O + 1, 17] = dr["MDA"] == DBNull.Value ? string.Empty : Convert.ToString(dr["MDA"]);


                            O++;
                        }
                        xlNewSheet8.Columns.AutoFit();
                        xlNewSheet8.Range["A1", "Q1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        xlNewSheet8.Range["A1", "Q1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                        //xlNewSheet8.Range["A1", "N1"].Font.Bold = true;
                        xlNewSheet8.Range["A1", "Q1"].EntireColumn.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet8.Range["I1"].EntireColumn.Font.Bold = true;
                        xlNewSheet8.Range["I1"].Cells.Font.Bold = false;
                        xlNewSheet8.Range["L1"].Cells.ColumnWidth = 12;
                        xlNewSheet8.Range["A1", "Q1"].EntireColumn.WrapText = true;
                        xlNewSheet8.Range["A1"].EntireColumn.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Blue);
                        xlNewSheet8.Range["A1"].Cells.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black);
                        xlNewSheet8.Range["A1"].EntireColumn.Font.Bold = true;
                        xlNewSheet8.Range["A1"].Cells.Font.Bold = false;
                        xlNewSheet8.Range["B1"].EntireColumn.Font.Bold = true;
                        xlNewSheet8.Range["B1"].Cells.Font.Bold = false;
                        xlNewSheet8.Range["P1"].EntireColumn.Font.Bold = true;
                        xlNewSheet8.Range["P1"].Cells.Font.Bold = false;
                        //----------change date format with filter created by Surendra Sharma on 09-03-2018.----
                        xlNewSheet8.Range["K1"].Cells.EntireColumn.NumberFormat = "dd mmm (ddd);@";
                        xlNewSheet8.Range["L1"].Cells.EntireColumn.NumberFormat = "dd mmm (ddd);@";
                        xlNewSheet8.Range["M1"].Cells.EntireColumn.NumberFormat = "dd mmm (ddd);@";
                        xlNewSheet8.Range["N1"].Cells.EntireColumn.NumberFormat = "dd mmm (ddd);@";
                        xlNewSheet8.Range["P1"].Cells.EntireColumn.NumberFormat = "dd mmm (ddd);@";
                        //-------------End-----------------------------------------------------------------------

                        xlNewSheet8.get_Range("A1:Q" + O).Cells.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                        releaseObject(xlNewSheet8);
                    }

                }
                if (ReportType == "TOP Approval Pending")
                {
                    //iKandi.Common.Constants.WorkSheetCount_ForExcel = iKandi.Common.Constants.WorkSheetCount_ForExcel + 1;
                    GlobalCount_Top = GlobalCount_Top + 1;
                    var xlNewSheet9 = (Excel.Worksheet)worksheets.Add(worksheets[GlobalCount_Top], Type.Missing, Type.Missing, Type.Missing);
                    xlNewSheet9.Name = "TOP Approval Pending";
                    xlNewSheet9.Cells[1, 1] = "Serial number";
                    xlNewSheet9.Cells[1, 2] = "Style number";
                    xlNewSheet9.Cells[1, 3] = "Department Name";
                    xlNewSheet9.Cells[1, 4] = "AM";
                    xlNewSheet9.Cells[1, 5] = "Contract Number";
                    xlNewSheet9.Cells[1, 6] = "Line-Item Number";
                    xlNewSheet9.Cells[1, 7] = "First Fabric Color/Print";
                    xlNewSheet9.Cells[1, 8] = "First Fabric Inhouse %";
                    xlNewSheet9.Cells[1, 9] = "Quantity";
                    xlNewSheet9.Cells[1, 10] = "Unit Name";
                    xlNewSheet9.Cells[1, 11] = "Sealed Date";
                    xlNewSheet9.Cells[1, 12] = "Pattern Sample Date";
                    xlNewSheet9.Cells[1, 13] = "HOPPM Date";
                    xlNewSheet9.Cells[1, 14] = "TOP Sent Actual Date";
                    xlNewSheet9.Cells[1, 15] = "Test Report status";
                    xlNewSheet9.Cells[1, 16] = "Ex-Factory";
                    xlNewSheet9.Cells[1, 17] = "MDA";

                    if (ds.Tables[0].Rows.Count == 0)
                    {
                        return false;
                    }
                    else if (ds.Tables[0].Rows.Count > 0)
                    {
                        int P = 1;
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            xlNewSheet9.Cells[P + 1, 1] = dr["Serialnumber"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Serialnumber"]);
                            xlNewSheet9.Cells[P + 1, 2] = dr["Stylenumber"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Stylenumber"]);
                            xlNewSheet9.Cells[P + 1, 3] = dr["DepartmentName"] == DBNull.Value ? string.Empty : Convert.ToString(dr["DepartmentName"]);
                            xlNewSheet9.Cells[P + 1, 4] = dr["AM"] == DBNull.Value ? string.Empty : Convert.ToString(dr["AM"]);
                            xlNewSheet9.Cells[P + 1, 5] = dr["ContractNumber"] == DBNull.Value ? string.Empty : Convert.ToString(dr["ContractNumber"]);
                            xlNewSheet9.Cells[P + 1, 6] = dr["LineItemNumber"] == DBNull.Value ? string.Empty : Convert.ToString(dr["LineItemNumber"]);
                            xlNewSheet9.Cells[P + 1, 7] = dr["Fabric1Details"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Fabric1Details"]);
                            xlNewSheet9.Cells[P + 1, 8] = dr["First Fabric Inhouse %"] == DBNull.Value ? string.Empty : Convert.ToString(dr["First Fabric Inhouse %"]);
                            xlNewSheet9.Cells[P + 1, 9] = dr["Quantity"] == DBNull.Value ? string.Empty : Convert.ToString(Convert.ToInt32(dr["Quantity"]).ToString("N0"));
                            xlNewSheet9.Cells[P + 1, 10] = dr["UnitName"] == DBNull.Value ? string.Empty : Convert.ToString(dr["UnitName"]);
                            xlNewSheet9.Cells[P + 1, 11] = dr["SealDate"] == DBNull.Value ? string.Empty : dr["SealDate"];
                            xlNewSheet9.Cells[P + 1, 12] = dr["PatternSampleDate"] == DBNull.Value ? string.Empty : dr["PatternSampleDate"];
                            xlNewSheet9.Cells[P + 1, 13] = dr["HOPPMDate"] == DBNull.Value ? string.Empty : dr["HOPPMDate"];
                            xlNewSheet9.Cells[P + 1, 14] = dr["TopsentActualDate"] == DBNull.Value ? string.Empty : dr["TopsentActualDate"];
                            xlNewSheet9.Cells[P + 1, 15] = dr["TestReportsStatus"] == DBNull.Value ? string.Empty : dr["TestReportsStatus"];
                            xlNewSheet9.Cells[P + 1, 16] = dr["ExFactory"] == DBNull.Value ? string.Empty : dr["ExFactory"];
                            xlNewSheet9.Cells[P + 1, 17] = dr["MDA"] == DBNull.Value ? string.Empty : Convert.ToString(dr["MDA"]);


                            P++;
                        }
                        xlNewSheet9.Columns.AutoFit();
                        xlNewSheet9.Range["A1", "Q1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        xlNewSheet9.Range["A1", "Q1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;

                        //xlNewSheet9.Range["A1", "N1"].Font.Bold = true;
                        xlNewSheet9.Range["A1", "Q1"].EntireColumn.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet9.Range["I1"].EntireColumn.Font.Bold = true;
                        xlNewSheet9.Range["I1"].Cells.Font.Bold = false;
                        xlNewSheet9.Range["L1"].Cells.ColumnWidth = 12;
                        xlNewSheet9.Range["A1", "Q1"].EntireColumn.WrapText = true;
                        xlNewSheet9.Range["B1"].EntireColumn.Font.Bold = true;
                        xlNewSheet9.Range["B1"].Cells.Font.Bold = false;
                        xlNewSheet9.Range["A1"].EntireColumn.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Blue);
                        xlNewSheet9.Range["A1"].Cells.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black);
                        xlNewSheet9.Range["A1"].EntireColumn.Font.Bold = true;
                        xlNewSheet9.Range["A1"].Cells.Font.Bold = false;
                        xlNewSheet9.Range["P1"].EntireColumn.Font.Bold = true;
                        xlNewSheet9.Range["P1"].Cells.Font.Bold = false;
                        //----------change date format with filter created by Surendra Sharma on 09-03-2018.----
                        xlNewSheet9.Range["k1"].Cells.EntireColumn.NumberFormat = "dd mmm (ddd);@";
                        xlNewSheet9.Range["L1"].Cells.EntireColumn.NumberFormat = "dd mmm (ddd);@";
                        xlNewSheet9.Range["M1"].Cells.EntireColumn.NumberFormat = "dd mmm (ddd);@";
                        xlNewSheet9.Range["N1"].Cells.EntireColumn.NumberFormat = "dd mmm (ddd);@";
                        xlNewSheet9.Range["P1"].Cells.EntireColumn.NumberFormat = "dd mmm (ddd);@";
                        //-------------End-----------------------------------------------------------------------

                        xlNewSheet9.get_Range("A1:Q1" + P).Cells.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                        releaseObject(xlNewSheet9);
                        ((Excel.Worksheet)xlApp.ActiveWorkbook.Sheets[1]).Activate();
                    }

                }
                if (ReportType == "TOP_Approved_MDA_Pending_Reports")
                {
                    //iKandi.Common.Constants.WorkSheetCount_ForExcel = iKandi.Common.Constants.WorkSheetCount_ForExcel + 1;
                    GlobalCount_Top = GlobalCount_Top + 1;
                    var xlNewSheet10 = (Excel.Worksheet)worksheets.Add(worksheets[GlobalCount_Top], Type.Missing, Type.Missing, Type.Missing);
                    xlNewSheet10.Name = "TOP-Approved-MDA-Reports";
                    xlNewSheet10.Cells[1, 1] = "Serial number";
                    xlNewSheet10.Cells[1, 2] = "Style number";
                    xlNewSheet10.Cells[1, 3] = "Department Name";
                    xlNewSheet10.Cells[1, 4] = "AM";
                    xlNewSheet10.Cells[1, 5] = "Contract Number";
                    xlNewSheet10.Cells[1, 6] = "Line-Item Number";
                    xlNewSheet10.Cells[1, 7] = "First Fabric Color/Print";
                    xlNewSheet10.Cells[1, 8] = "First Fabric Inhouse %";
                    xlNewSheet10.Cells[1, 9] = "Quantity";
                    xlNewSheet10.Cells[1, 10] = "Unit Name";
                    xlNewSheet10.Cells[1, 11] = "Sealed Date";
                    xlNewSheet10.Cells[1, 12] = "Pattern Sample Date";
                    xlNewSheet10.Cells[1, 13] = "HOPPM Date";
                    xlNewSheet10.Cells[1, 14] = "TOP Sent Actual Date";
                    xlNewSheet10.Cells[1, 15] = "Test Report status";
                    xlNewSheet10.Cells[1, 16] = "Ex-Factory";
                    xlNewSheet10.Cells[1, 17] = "TOP Approved Date";
                    xlNewSheet10.Cells[1, 18] = "MDA";

                    if (ds.Tables[0].Rows.Count == 0)
                    {
                        return false;
                    }
                    else if (ds.Tables[0].Rows.Count > 0)
                    {
                        int Q = 1;
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            xlNewSheet10.Cells[Q + 1, 1] = dr["Serialnumber"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Serialnumber"]);
                            xlNewSheet10.Cells[Q + 1, 2] = dr["Stylenumber"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Stylenumber"]);
                            xlNewSheet10.Cells[Q + 1, 3] = dr["DepartmentName"] == DBNull.Value ? string.Empty : Convert.ToString(dr["DepartmentName"]);
                            xlNewSheet10.Cells[Q + 1, 4] = dr["AM"] == DBNull.Value ? string.Empty : Convert.ToString(dr["AM"]);
                            xlNewSheet10.Cells[Q + 1, 5] = dr["ContractNumber"] == DBNull.Value ? string.Empty : Convert.ToString(dr["ContractNumber"]);
                            xlNewSheet10.Cells[Q + 1, 6] = dr["LineItemNumber"] == DBNull.Value ? string.Empty : Convert.ToString(dr["LineItemNumber"]);
                            xlNewSheet10.Cells[Q + 1, 7] = dr["Fabric1Details"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Fabric1Details"]);
                            xlNewSheet10.Cells[Q + 1, 8] = dr["First Fabric Inhouse %"] == DBNull.Value ? string.Empty : Convert.ToString(dr["First Fabric Inhouse %"]);
                            xlNewSheet10.Cells[Q + 1, 9] = dr["Quantity"] == DBNull.Value ? string.Empty : Convert.ToString(Convert.ToInt32(dr["Quantity"]).ToString("N0"));
                            xlNewSheet10.Cells[Q + 1, 10] = dr["UnitName"] == DBNull.Value ? string.Empty : Convert.ToString(dr["UnitName"]);
                            xlNewSheet10.Cells[Q + 1, 11] = dr["SealDate"] == DBNull.Value ? string.Empty : dr["SealDate"];
                            xlNewSheet10.Cells[Q + 1, 12] = dr["PatternSampleDate"] == DBNull.Value ? string.Empty : dr["PatternSampleDate"];
                            xlNewSheet10.Cells[Q + 1, 13] = dr["HOPPMDate"] == DBNull.Value ? string.Empty : dr["HOPPMDate"];
                            xlNewSheet10.Cells[Q + 1, 14] = dr["TopsentActualDate"] == DBNull.Value ? string.Empty : dr["TopsentActualDate"];
                            xlNewSheet10.Cells[Q + 1, 15] = dr["TestReportsStatus"] == DBNull.Value ? string.Empty : dr["TestReportsStatus"];
                            xlNewSheet10.Cells[Q + 1, 16] = dr["ExFactory"] == DBNull.Value ? string.Empty : dr["ExFactory"];
                            xlNewSheet10.Cells[Q + 1, 17] = dr["TOPApprovedDate"] == DBNull.Value ? string.Empty : dr["TOPApprovedDate"];
                            xlNewSheet10.Cells[Q + 1, 18] = dr["MDA"] == DBNull.Value ? string.Empty : Convert.ToString(dr["MDA"]);


                            Q++;
                        }
                        xlNewSheet10.Columns.AutoFit();
                        xlNewSheet10.Range["A1", "R1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        xlNewSheet10.Range["A1", "R1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                        //xlNewSheet10.Range["A1", "O1"].Font.Bold = true;
                        xlNewSheet10.Range["A1", "R1"].EntireColumn.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet10.Range["I1"].EntireColumn.Font.Bold = true;
                        xlNewSheet10.Range["I1"].Cells.Font.Bold = false;
                        xlNewSheet10.Range["L1"].Cells.ColumnWidth = 12;
                        xlNewSheet10.Range["A1", "R1"].EntireColumn.WrapText = true;
                        xlNewSheet10.Range["B1"].EntireColumn.Font.Bold = true;
                        xlNewSheet10.Range["B1"].Cells.Font.Bold = false;

                        xlNewSheet10.Range["A1"].EntireColumn.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Blue);
                        xlNewSheet10.Range["A1"].Cells.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black);
                        xlNewSheet10.Range["A1"].EntireColumn.Font.Bold = true;
                        xlNewSheet10.Range["A1"].Cells.Font.Bold = false;
                        xlNewSheet10.Range["P1"].EntireColumn.Font.Bold = true;
                        xlNewSheet10.Range["P1"].Cells.Font.Bold = false;
                        //----------change date format with filter created by Surendra Sharma on 09-03-2018.----
                        xlNewSheet10.Range["K1"].Cells.EntireColumn.NumberFormat = "dd mmm (ddd);@";
                        xlNewSheet10.Range["L1"].Cells.EntireColumn.NumberFormat = "dd mmm (ddd);@";
                        xlNewSheet10.Range["M1"].Cells.EntireColumn.NumberFormat = "dd mmm (ddd);@";
                        xlNewSheet10.Range["N1"].Cells.EntireColumn.NumberFormat = "dd mmm (ddd);@";
                        xlNewSheet10.Range["P1"].Cells.EntireColumn.NumberFormat = "dd mmm (ddd);@";
                        xlNewSheet10.Range["Q1"].Cells.EntireColumn.NumberFormat = "dd mmm (ddd);@";
                        //-------------End-----------------------------------------------------------------------

                        xlNewSheet10.get_Range("A1:R" + Q).Cells.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                        releaseObject(xlNewSheet10);
                        ((Excel.Worksheet)xlApp.ActiveWorkbook.Sheets[1]).Activate();

                    }

                }
                //if (ReportType == "TOP_Approved_Fabric_BIH_Reports")
                //{
                //    iKandi.Common.Constants.WorkSheetCount_ForExcel = iKandi.Common.Constants.WorkSheetCount_ForExcel + 1;
                //    var xlNewSheet11 = (Excel.Worksheet)worksheets.Add(worksheets[iKandi.Common.Constants.WorkSheetCount_ForExcel], Type.Missing, Type.Missing, Type.Missing);
                //    xlNewSheet11.Name = "TOP-Fabric_BIH-Reports";
                //    xlNewSheet11.Cells[1, 1] = "Serial number";
                //    xlNewSheet11.Cells[1, 2] = "Style number";
                //    xlNewSheet11.Cells[1, 3] = "Department Name";
                //    xlNewSheet11.Cells[1, 4] = "Contract Number";
                //    xlNewSheet11.Cells[1, 5] = "Line-Item Number";
                //    xlNewSheet11.Cells[1, 6] = "First Fabric Color/Print";
                //    xlNewSheet11.Cells[1, 7] = "Quantity";
                //    xlNewSheet11.Cells[1, 8] = "Unit Name";
                //    xlNewSheet11.Cells[1, 9] = "First Fabric InHouse %";
                //    xlNewSheet11.Cells[1, 10] = "Second Fabric InHouse %";
                //    xlNewSheet11.Cells[1, 11] = "Third Fabric InHouse %";
                //    xlNewSheet11.Cells[1, 12] = "Fourth Fabric InHouse %";
                //    xlNewSheet11.Cells[1, 13] = "AM";
                //    xlNewSheet11.Cells[1, 14] = "Ex-Factory";


                //    if (ds.Tables[0].Rows.Count == 0)
                //    {
                //        return false;
                //    }
                //    else if (ds.Tables[0].Rows.Count > 0)
                //    {
                //        int Q = 1;
                //        foreach (DataRow dr in ds.Tables[0].Rows)
                //        {
                //            xlNewSheet11.Cells[Q + 1, 1] = dr["Serialnumber"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Serialnumber"]);
                //            xlNewSheet11.Cells[Q + 1, 2] = dr["Stylenumber"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Stylenumber"]);
                //            xlNewSheet11.Cells[Q + 1, 3] = dr["DepartmentName"] == DBNull.Value ? string.Empty : Convert.ToString(dr["DepartmentName"]);
                //            xlNewSheet11.Cells[Q + 1, 4] = dr["ContractNumber"] == DBNull.Value ? string.Empty : Convert.ToString(dr["ContractNumber"]);
                //            xlNewSheet11.Cells[Q + 1, 5] = dr["LineItemNumber"] == DBNull.Value ? string.Empty : Convert.ToString(dr["LineItemNumber"]);
                //            xlNewSheet11.Cells[Q + 1, 6] = dr["Fabric1Details"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Fabric1Details"]);
                //            xlNewSheet11.Cells[Q + 1, 7] = dr["Quantity"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Quantity"]);
                //            xlNewSheet11.Cells[Q + 1, 8] = dr["UnitName"] == DBNull.Value ? string.Empty : Convert.ToString(dr["UnitName"]);
                //            xlNewSheet11.Cells[Q + 1, 9] = dr["FirstFabricInHouse"] == DBNull.Value ? string.Empty : Convert.ToString(dr["FirstFabricInHouse"]);
                //            xlNewSheet11.Cells[Q + 1, 10] = dr["SecondFabricInHouse"] == DBNull.Value ? string.Empty : Convert.ToString(dr["SecondFabricInHouse"]);
                //            xlNewSheet11.Cells[Q + 1, 11] = dr["ThirdFabricInHouse"] == DBNull.Value ? string.Empty : Convert.ToString(dr["ThirdFabricInHouse"]);
                //            xlNewSheet11.Cells[Q + 1, 12] = dr["FourthFabricInHouse"] == DBNull.Value ? string.Empty : Convert.ToString(dr["FourthFabricInHouse"]);
                //            xlNewSheet11.Cells[Q + 1, 13] = dr["AM"] == DBNull.Value ? string.Empty : Convert.ToString(dr["AM"]);
                //            xlNewSheet11.Cells[Q + 1, 14] = dr["ExFactory"] == DBNull.Value ? string.Empty : Convert.ToString(dr["ExFactory"]);


                //            Q++;
                //        }
                //        xlNewSheet11.Columns.AutoFit();
                //        xlNewSheet11.Range["A1", "N1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                //        xlNewSheet11.Range["A1", "N1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                //        xlNewSheet11.Range["A1", "N1"].Font.Bold = true;
                //        releaseObject(xlNewSheet11);
                //        ((Excel.Worksheet)xlApp.ActiveWorkbook.Sheets[1]).Activate();

                //    }

                //}
                if (ReportType == "Pattern_Sample_Pending")
                {
                    // iKandi.Common.Constants.WorkSheetCount_ForExcel = iKandi.Common.Constants.WorkSheetCount_ForExcel + 1;
                    GlobalCount_Planning = GlobalCount_Planning + 1;
                    var xlNewSheet11 = (Excel.Worksheet)worksheets.Add(worksheets[GlobalCount_Planning], Type.Missing, Type.Missing, Type.Missing);
                    xlNewSheet11.Name = "Pattern_Sample_Pending";
                    xlNewSheet11.Cells[1, 1] = "Serial number";
                    xlNewSheet11.Cells[1, 2] = "Style number";
                    xlNewSheet11.Cells[1, 3] = "Department Name";
                    xlNewSheet11.Cells[1, 4] = "Contract Number";
                    xlNewSheet11.Cells[1, 5] = "Line-Item Number";
                    //xlNewSheet11.Cells[1, 6] = "First Fabric Color/Print";
                    xlNewSheet11.Cells[1, 6] = "Quantity";
                    xlNewSheet11.Cells[1, 7] = "Unit Name";
                    xlNewSheet11.Cells[1, 8] = "First Fabric";
                    xlNewSheet11.Cells[1, 9] = "First Fabric Color/Print";
                    xlNewSheet11.Cells[1, 10] = "First Fabric In House %";
                    xlNewSheet11.Cells[1, 11] = "Second Fabric";
                    xlNewSheet11.Cells[1, 12] = "Second Fabric Color/Print";
                    xlNewSheet11.Cells[1, 13] = "Second Fabric In House %";
                    xlNewSheet11.Cells[1, 14] = "Third Fabric";
                    xlNewSheet11.Cells[1, 15] = "Third Fabric Color/Print";
                    xlNewSheet11.Cells[1, 16] = "Third Fabric In House %";
                    xlNewSheet11.Cells[1, 17] = "Fourth Fabric";
                    xlNewSheet11.Cells[1, 18] = "Fourth Fabric Color/Print";
                    xlNewSheet11.Cells[1, 19] = "Fourth Fabric In House %";
                    xlNewSheet11.Cells[1, 20] = "Sealed Date";
                    //xlNewSheet11.Cells[1, 10] = "Pattern Sample Date";
                    xlNewSheet11.Cells[1, 21] = "HOPPM ETA";
                    xlNewSheet11.Cells[1, 22] = "TOP ETA";
                    //xlNewSheet11.Cells[1, 13] = "StyleCode";
                    xlNewSheet11.Cells[1, 23] = "ExFactory";


                    if (ds.Tables[0].Rows.Count == 0)
                    {
                        return false;
                    }
                    else if (ds.Tables[0].Rows.Count > 0)
                    {
                        int R = 1;
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            xlNewSheet11.Cells[R + 1, 1] = dr["Serialnumber"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Serialnumber"]);
                            xlNewSheet11.Cells[R + 1, 2] = dr["Stylenumber"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Stylenumber"]);
                            xlNewSheet11.Cells[R + 1, 3] = dr["DepartmentName"] == DBNull.Value ? string.Empty : Convert.ToString(dr["DepartmentName"]);
                            xlNewSheet11.Cells[R + 1, 4] = dr["ContractNumber"] == DBNull.Value ? string.Empty : Convert.ToString(dr["ContractNumber"]);
                            xlNewSheet11.Cells[R + 1, 5] = dr["LineItemNumber"] == DBNull.Value ? string.Empty : Convert.ToString(dr["LineItemNumber"]);
                            //xlNewSheet11.Cells[R + 1, 6] = dr["Fabric1Details"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Fabric1Details"]);
                            xlNewSheet11.Cells[R + 1, 6] = dr["Quantity"] == DBNull.Value ? string.Empty : Convert.ToInt32(dr["Quantity"]).ToString("N0");//add code by bharat on 12-12-19
                            xlNewSheet11.Cells[R + 1, 7] = dr["UnitName"] == DBNull.Value ? string.Empty : Convert.ToString(dr["UnitName"]);
                            xlNewSheet11.Cells[R + 1, 8] = dr["Fabric1"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Fabric1"]);
                            xlNewSheet11.Cells[R + 1, 9] = dr["Fabric1Details"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Fabric1Details"]);
                            xlNewSheet11.Cells[R + 1, 10] = dr["FirstFabricInHouse"] == DBNull.Value ? string.Empty : Convert.ToString(dr["FirstFabricInHouse"]);

                            xlNewSheet11.Cells[R + 1, 11] = dr["Fabric2"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Fabric2"]);
                            xlNewSheet11.Cells[R + 1, 12] = dr["Fabric2Details"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Fabric2Details"]);
                            xlNewSheet11.Cells[R + 1, 13] = dr["SecondFabricInHouse"] == DBNull.Value ? string.Empty : Convert.ToString(dr["SecondFabricInHouse"]);
                            xlNewSheet11.Cells[R + 1, 14] = dr["Fabric3"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Fabric3"]);
                            xlNewSheet11.Cells[R + 1, 15] = dr["Fabric3Details"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Fabric3Details"]);
                            xlNewSheet11.Cells[R + 1, 16] = dr["ThirdFabricInHouse"] == DBNull.Value ? string.Empty : Convert.ToString(dr["ThirdFabricInHouse"]);
                            xlNewSheet11.Cells[R + 1, 17] = dr["Fabric4"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Fabric4"]);
                            xlNewSheet11.Cells[R + 1, 18] = dr["Fabric4Details"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Fabric4Details"]);
                            xlNewSheet11.Cells[R + 1, 19] = dr["FourthFabricInHouse"] == DBNull.Value ? string.Empty : Convert.ToString(dr["FourthFabricInHouse"]);
                            xlNewSheet11.Cells[R + 1, 20] = dr["SealDate"] == DBNull.Value ? string.Empty : dr["SealDate"];
                            //xlNewSheet11.Cells[R + 1, 10] = dr["PatternSampleDate"] == DBNull.Value ? string.Empty : Convert.ToString(dr["PatternSampleDate"]);
                            xlNewSheet11.Cells[R + 1, 21] = dr["HOPPMETA"] == DBNull.Value ? string.Empty : dr["HOPPMETA"];
                            xlNewSheet11.Cells[R + 1, 22] = dr["TOPETA"] == DBNull.Value ? string.Empty : dr["TOPETA"];
                            //xlNewSheet11.Cells[R + 1, 13] = dr["STYLECODE"] == DBNull.Value ? string.Empty : Convert.ToString(dr["STYLECODE"]);
                            xlNewSheet11.Cells[R + 1, 23] = dr["ExFactory"] == DBNull.Value ? string.Empty : dr["ExFactory"];



                            R++;
                        }
                        xlNewSheet11.Columns.AutoFit();
                        xlNewSheet11.Range["A1", "W1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        xlNewSheet11.Range["A1", "W1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                        //xlNewSheet11.Range["A1", "W1"].Font.Bold = true;

                        xlNewSheet11.Range["A1", "W1"].EntireColumn.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet11.Range["F1"].EntireColumn.Font.Bold = true;
                        xlNewSheet11.Range["F1"].Cells.Font.Bold = false;
                        xlNewSheet11.Range["J1"].Cells.ColumnWidth = 12;
                        xlNewSheet11.Range["A1", "W1"].EntireColumn.WrapText = true;
                        xlNewSheet11.Range["B1"].EntireColumn.Font.Bold = true;
                        xlNewSheet11.Range["B1"].Cells.Font.Bold = false;
                        xlNewSheet11.Range["W1"].EntireColumn.Font.Bold = true;
                        xlNewSheet11.Range["W1"].EntireColumn.Font.Size = 16;
                        xlNewSheet11.Range["W1"].Cells.Font.Bold = false;
                        xlNewSheet11.Range["W1"].Cells.Font.Size = 11;
                        xlNewSheet11.Range["A1"].EntireColumn.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Blue);
                        xlNewSheet11.Range["A1"].Cells.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black);
                        xlNewSheet11.Range["A1"].EntireColumn.Font.Bold = true;
                        xlNewSheet11.Range["A1"].Cells.Font.Bold = false;
                        //----------change date format with filter created by Surendra Sharma on 09-03-2018.----
                        xlNewSheet11.Range["T1"].Cells.EntireColumn.NumberFormat = "dd mmm (ddd);@";
                        xlNewSheet11.Range["U1"].Cells.EntireColumn.NumberFormat = "dd mmm (ddd);@";
                        xlNewSheet11.Range["V1"].Cells.EntireColumn.NumberFormat = "dd mmm (ddd);@";
                        xlNewSheet11.Range["W1"].Cells.EntireColumn.NumberFormat = "dd mmm (ddd);@";
                        //-------------End-----------------------------------------------------------------------

                        xlNewSheet11.get_Range("A1:W" + R).Cells.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;

                        releaseObject(xlNewSheet11);
                        ((Excel.Worksheet)xlApp.ActiveWorkbook.Sheets[1]).Activate();

                    }

                }

                //------------------------------
                if (ReportType == "Production_Planning")
                {
                    // iKandi.Common.Constants.WorkSheetCount_ForExcel = iKandi.Common.Constants.WorkSheetCount_ForExcel + 1;
                    GlobalCount_Planning = GlobalCount_Planning + 1;
                    var xlNewSheet11 = (Excel.Worksheet)worksheets.Add(worksheets[GlobalCount_Planning], Type.Missing, Type.Missing, Type.Missing);
                    xlNewSheet11.Name = "Production_Planning";
                    xlNewSheet11.Cells[1, 1] = "Serial number";
                    xlNewSheet11.Cells[1, 2] = "Style number";
                    xlNewSheet11.Cells[1, 3] = "Department Name";
                    xlNewSheet11.Cells[1, 4] = "Contract Number";
                    xlNewSheet11.Cells[1, 5] = "Line-Item Number";
                    xlNewSheet11.Cells[1, 6] = "Quantity";
                    xlNewSheet11.Cells[1, 7] = "Unit Name";
                    xlNewSheet11.Cells[1, 8] = "First Fabric";
                    xlNewSheet11.Cells[1, 9] = "First Fabric Color/Print";
                    xlNewSheet11.Cells[1, 10] = "First Fabric In House %";
                    xlNewSheet11.Cells[1, 11] = "In House END ETA DATE";
                    xlNewSheet11.Cells[1, 12] = "STC Requested Date";
                    xlNewSheet11.Cells[1, 13] = "Sealed Date";
                    xlNewSheet11.Cells[1, 14] = "Pattern Sample Date";
                    xlNewSheet11.Cells[1, 15] = "ExFactory";
                    xlNewSheet11.Cells[1, 16] = "Mode";
                    xlNewSheet11.Cells[1, 17] = "Final Status";
                    xlNewSheet11.Cells[1, 18] = "Planned Status";
                    xlNewSheet11.Cells[1, 19] = "Plan Start Date";
                    xlNewSheet11.Cells[1, 20] = "Plan Start Line";


                    //xlNewSheet11.Cells[1, 17] = "STC Requested But Grading Pending";
                    //xlNewSheet11.Cells[1, 18] = "STC Done But Pattern Sample Pending";
                    //xlNewSheet11.Cells[1, 19] = "Pattern Sample Done But Production Pending";



                    if (ds.Tables[0].Rows.Count == 0)
                    {
                        return false;
                    }
                    else if (ds.Tables[0].Rows.Count > 0)
                    {
                        int S = 1;
                        int J = 1;
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            int Percent = 0;
                            xlNewSheet11.Cells[S + 1, 1] = dr["Serialnumber"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Serialnumber"]);
                            xlNewSheet11.Cells[S + 1, 2] = dr["Stylenumber"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Stylenumber"]);
                            xlNewSheet11.Cells[S + 1, 3] = dr["DepartmentName"] == DBNull.Value ? string.Empty : Convert.ToString(dr["DepartmentName"]);
                            xlNewSheet11.Cells[S + 1, 4] = dr["ContractNumber"] == DBNull.Value ? string.Empty : Convert.ToString(dr["ContractNumber"]);
                            xlNewSheet11.Cells[S + 1, 5] = dr["LineItemNumber"] == DBNull.Value ? string.Empty : Convert.ToString(dr["LineItemNumber"]);
                            //xlNewSheet11.Cells[R + 1, 6] = dr["Fabric1Details"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Fabric1Details"]);
                            xlNewSheet11.Cells[S + 1, 6] = dr["Quantity"] == DBNull.Value ? string.Empty : Convert.ToInt32(dr["Quantity"]).ToString("N0"); // added code by bharat on 12-12-19
                            xlNewSheet11.Cells[S + 1, 7] = dr["UnitName"] == DBNull.Value ? string.Empty : Convert.ToString(dr["UnitName"]);
                            xlNewSheet11.Cells[S + 1, 8] = dr["Fabric1"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Fabric1"]);
                            xlNewSheet11.Cells[S + 1, 9] = dr["Fabric1Details"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Fabric1Details"]);
                            xlNewSheet11.Cells[S + 1, 10] = dr["FirstFabricInHouse"] == DBNull.Value ? string.Empty : Convert.ToString(dr["FirstFabricInHouse"]);
                            Percent = dr["FirstFabricInHouse"].ToString() == "" ? 0 : Convert.ToInt32(dr["FirstFabricInHouse"]);
                            //xlNewSheet11.Cells[S + 1, 10].Color = System.Drawing.Color.AliceBlue;
                            xlNewSheet11.Cells[S + 1, 11] = dr["fabric1endeta"] == DBNull.Value ? string.Empty : dr["fabric1endeta"];
                            xlNewSheet11.Cells[S + 1, 12] = dr["STCrequestedDate"] == DBNull.Value ? string.Empty : dr["STCrequestedDate"];
                            xlNewSheet11.Cells[S + 1, 13] = dr["SealDate"] == DBNull.Value ? string.Empty : dr["SealDate"];
                            xlNewSheet11.Cells[S + 1, 14] = dr["PatternSampleDate"] == DBNull.Value ? string.Empty : dr["PatternSampleDate"];
                            xlNewSheet11.Cells[S + 1, 15] = dr["ExFactory"] == DBNull.Value ? string.Empty : dr["ExFactory"];
                            xlNewSheet11.Cells[S + 1, 16] = dr["code"] == DBNull.Value ? string.Empty : Convert.ToString(dr["code"]);
                            //xlNewSheet11.Cells[S + 1, 17] = dr["StcRequestedandGrdPDNG"] == DBNull.Value ? string.Empty : Convert.ToString(dr["StcRequestedandGrdPDNG"]);
                            //xlNewSheet11.Cells[S + 1, 18] = dr["STCDoneandPatternsamplePending"] == DBNull.Value ? string.Empty : Convert.ToString(dr["STCDoneandPatternsamplePending"]);
                            //xlNewSheet11.Cells[S + 1, 19] = dr["PatternSampleDoneAndNotInHouse"] == DBNull.Value ? string.Empty : Convert.ToString(dr["PatternSampleDoneAndNotInHouse"]);
                            xlNewSheet11.Cells[S + 1, 17] = dr["FinalStatus"] == DBNull.Value ? string.Empty : Convert.ToString(dr["FinalStatus"]);
                            xlNewSheet11.Cells[S + 1, 18] = dr["Planned_Status"] == DBNull.Value ? "Not Planned" : Convert.ToString(dr["Planned_Status"]);
                            xlNewSheet11.Cells[S + 1, 19] = dr["StartDate"] == DBNull.Value ? string.Empty : dr["StartDate"];
                            xlNewSheet11.Cells[S + 1, 20] = dr["LINE_NO"] == DBNull.Value ? string.Empty : Convert.ToString(dr["LINE_NO"]);


                            //Add By Prabhaker On 3rd May 18

                            xlNewSheet11.Range["A" + J, "A" + J].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["B" + J, "B" + J].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["C" + J, "C" + J].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["D" + J, "D" + J].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["E" + J, "E" + J].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["F" + J, "F" + J].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["G" + J, "G" + J].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["H" + J, "H" + J].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["I" + J, "I" + J].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["J" + J, "J" + J].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["K" + J, "K" + J].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["L" + J, "L" + J].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["M" + J, "M" + J].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["N" + J, "N" + J].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["O" + J, "O" + J].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["P" + J, "P" + J].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["Q" + J, "Q" + J].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["R" + J, "R" + J].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["S" + J, "S" + J].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["T" + J, "T" + J].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;


                            xlNewSheet11.Range["A" + J, "A" + J].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet11.Range["A" + J, "A" + J].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet11.Range["A" + J, "A" + J].Font.Name = "Calibri";
                            xlNewSheet11.Range["A" + J, "A" + J].Font.Size = 11;
                            xlNewSheet11.Range["A" + J, "A" + J].Font.FontStyle = "Regular";
                            //xlNewSheet11.Range["A" + J, "A" + J].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Gray);

                            xlNewSheet11.Range["B" + J, "B" + J].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet11.Range["B" + J, "B" + J].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet11.Range["B" + J, "B" + J].Font.Name = "Calibri";
                            xlNewSheet11.Range["B" + J, "B" + J].Font.Size = 11;
                            xlNewSheet11.Range["B" + J, "B" + J].Font.FontStyle = "Regular";

                            xlNewSheet11.Range["C" + J, "C" + J].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet11.Range["C" + J, "C" + J].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet11.Range["C" + J, "C" + J].Font.Name = "Calibri";
                            xlNewSheet11.Range["C" + J, "C" + J].Font.Size = 11;
                            xlNewSheet11.Range["C" + J, "C" + J].Font.FontStyle = "Regular";


                            xlNewSheet11.Range["D" + J, "D" + J].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet11.Range["D" + J, "D" + J].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet11.Range["D" + J, "D" + J].Font.Name = "Calibri";
                            xlNewSheet11.Range["D" + J, "D" + J].Font.Size = 11;
                            xlNewSheet11.Range["D" + J, "D" + J].Font.FontStyle = "Bold";


                            xlNewSheet11.Range["E" + J, "E" + J].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet11.Range["E" + J, "E" + J].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet11.Range["E" + J, "E" + J].Font.Name = "Calibri";
                            xlNewSheet11.Range["E" + J, "E" + J].Font.Size = 11;
                            xlNewSheet11.Range["E" + J, "E" + J].Font.FontStyle = "Bold";


                            xlNewSheet11.Range["F" + J, "F" + J].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet11.Range["F" + J, "F" + J].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet11.Range["F" + J, "F" + J].Font.Name = "Calibri";
                            xlNewSheet11.Range["F" + J, "F" + J].Font.Size = 11;
                            xlNewSheet11.Range["F" + J, "F" + J].Font.FontStyle = "Bold";
                            // xlNewSheet11.Range["F" + J, "F" + J].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Gray);

                            xlNewSheet11.Range["G" + J, "G" + J].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet11.Range["G" + J, "G" + J].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet11.Range["G" + J, "G" + J].Font.Name = "Calibri";
                            xlNewSheet11.Range["G" + J, "G" + J].Font.Size = 11;
                            xlNewSheet11.Range["G" + J, "G" + J].Font.FontStyle = "Regular";


                            xlNewSheet11.Range["H" + J, "H" + J].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet11.Range["H" + J, "H" + J].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet11.Range["H" + J, "H" + J].Font.Name = "Calibri";
                            xlNewSheet11.Range["H" + J, "H" + J].Font.Size = 11;
                            xlNewSheet11.Range["H" + J, "H" + J].Font.FontStyle = "Regular";
                            // xlNewSheet11.Range["H" + J, "H" + J].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Gray);

                            xlNewSheet11.Range["I" + J, "I" + J].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet11.Range["I" + J, "I" + J].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet11.Range["I" + J, "I" + J].Font.Name = "Calibri";
                            xlNewSheet11.Range["I" + J, "I" + J].Font.Size = 11;
                            xlNewSheet11.Range["I" + J, "I" + J].Font.FontStyle = "Regular";
                            //xlNewSheet11.Range["I" + J, "I" + J].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Gray);


                            xlNewSheet11.Range["J" + J, "J" + J].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet11.Range["J" + J, "J" + J].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet11.Range["J" + J, "J" + J].Font.Name = "Calibri";
                            xlNewSheet11.Range["J" + J, "J" + J].Font.Size = 11;
                            xlNewSheet11.Range["J" + J, "J" + J].Font.FontStyle = "Bold";
                            // xlNewSheet11.Range["J" + J, "J" + J].EntireColumn.ColumnWidth = 10;


                            xlNewSheet11.Range["K" + J, "K" + J].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet11.Range["K" + J, "K" + J].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet11.Range["K" + J, "K" + J].Font.Name = "Calibri";
                            xlNewSheet11.Range["K" + J, "K" + J].Font.Size = 11;
                            xlNewSheet11.Range["K" + J, "K" + J].Font.FontStyle = "Regular";
                            // xlNewSheet11.Range["K" + J, "K" + J].EntireColumn.ColumnWidth = 10;


                            xlNewSheet11.Range["L" + J, "L" + J].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet11.Range["L" + J, "L" + J].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet11.Range["L" + J, "L" + J].Font.Name = "Calibri";
                            xlNewSheet11.Range["L" + J, "L" + J].Font.Size = 11;
                            xlNewSheet11.Range["L" + J, "L" + J].Font.FontStyle = "Regular";
                            //  xlNewSheet11.Range["L" + J, "L" + J].EntireColumn.ColumnWidth = 10;

                            // xlNewSheet11.Range["L" + J, "L" + J].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Gray);

                            xlNewSheet11.Range["M" + J, "M" + J].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet11.Range["M" + J, "M" + J].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet11.Range["M" + J, "M" + J].Font.Name = "Calibri";
                            xlNewSheet11.Range["M" + J, "M" + J].Font.Size = 11;
                            xlNewSheet11.Range["M" + J, "M" + J].EntireColumn.ColumnWidth = 10;
                            xlNewSheet11.Range["M" + J, "M" + J].Font.FontStyle = "Regular";


                            xlNewSheet11.Range["N" + J, "N" + J].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet11.Range["N" + J, "N" + J].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet11.Range["N" + J, "N" + J].Font.Name = "Calibri";
                            xlNewSheet11.Range["N" + J, "N" + J].Font.Size = 11;
                            xlNewSheet11.Range["N" + J, "N" + J].Font.FontStyle = "Regular";
                            //  xlNewSheet11.Range["J" + J, "J" + J].EntireColumn.ColumnWidth = 10;



                            xlNewSheet11.Range["O" + J, "O" + J].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet11.Range["O" + J, "O" + J].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet11.Range["O" + J, "O" + J].Font.Name = "Calibri";
                            xlNewSheet11.Range["O" + J, "O" + J].Font.Size = 11;
                            xlNewSheet11.Range["O" + J, "O" + J].Font.FontStyle = "Regular";
                            // xlNewSheet11.Range["O" + J, "O" + J].EntireColumn.ColumnWidth = 8;

                            //xlNewSheet11.Range["O" + J, "O" + J].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Gray);

                            xlNewSheet11.Range["P" + J, "P" + J].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet11.Range["P" + J, "P" + J].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet11.Range["P" + J, "P" + J].Font.Name = "Calibri";
                            xlNewSheet11.Range["P" + J, "P" + J].Font.Size = 11;
                            xlNewSheet11.Range["P" + J, "P" + J].Font.FontStyle = "Regular";
                            // xlNewSheet11.Range["P" + J, "P" + J].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Gray);


                            xlNewSheet11.Range["Q" + J, "Q" + J].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet11.Range["Q" + J, "Q" + J].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet11.Range["Q" + J, "Q" + J].Font.Name = "Calibri";
                            xlNewSheet11.Range["Q" + J, "Q" + J].Font.Size = 11;
                            xlNewSheet11.Range["Q" + J, "Q" + J].Font.FontStyle = "Bold";


                            xlNewSheet11.Range["R" + J, "R" + J].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet11.Range["R" + J, "R" + J].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet11.Range["R" + J, "R" + J].Font.Name = "Calibri";
                            xlNewSheet11.Range["R" + J, "R" + J].Font.Size = 11;
                            xlNewSheet11.Range["R" + J, "R" + J].Font.FontStyle = "Regular";

                            xlNewSheet11.Range["S" + J, "S" + J].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet11.Range["S" + J, "S" + J].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet11.Range["S" + J, "S" + J].Font.Name = "Calibri";
                            xlNewSheet11.Range["S" + J, "S" + J].Font.Size = 11;
                            xlNewSheet11.Range["S" + J, "S" + J].Font.FontStyle = "Regular";
                            // xlNewSheet11.Range["S" + J, "S" + J].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Gray);

                            xlNewSheet11.Range["T" + J, "T" + J].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet11.Range["T" + J, "T" + J].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet11.Range["T" + J, "T" + J].Font.Name = "Calibri";
                            xlNewSheet11.Range["T" + J, "T" + J].Font.Size = 11;
                            // xlNewSheet11.Range["T" + J, "T" + J].EntireColumn.ColumnWidth = 10;
                            xlNewSheet11.Range["T" + J, "T" + J].Font.FontStyle = "Regular";

                            //End Of Code



                            J = S + 1;
                            //if (S != 1)
                            //{
                            if (Percent == 0)
                            {
                                xlNewSheet11.Range["J" + J, "J" + J].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.White);
                                //StrBackColorCode = "#F9F9FA";
                            }
                            if (Percent >= 0.1 && Percent <= 89.99)
                            {
                                xlNewSheet11.Range["J" + J, "J" + J].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                                //StrBackColorCode = "#FFFF00";
                            }
                            if (Percent >= 90 && Percent <= 99.99)
                            {
                                xlNewSheet11.Range["J" + J, "J" + J].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Orange);
                                //StrBackColorCode = "#FFA500";
                            }
                            else if (Percent >= 100 && Percent <= 105)
                            {
                                xlNewSheet11.Range["J" + J, "J" + J].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.LightGreen);
                                //StrBackColorCode = "#d7e4bc";
                            }
                            else if (Percent > 105)
                            {
                                xlNewSheet11.Range["J" + J, "J" + J].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Red);
                                //StrBackColorCode = "red";

                            }
                            //}




                            S++;
                        }

                        xlNewSheet11.Range["A1", "A1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        xlNewSheet11.Range["A1", "A1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet11.Range["A1", "A1"].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        xlNewSheet11.Range["A1", "A1"].Font.Bold = false;
                        xlNewSheet11.Range["A1", "A1"].Font.Name = "Calibri";
                        xlNewSheet11.Range["A1", "A1"].Font.Size = 11;
                        xlNewSheet11.Range["A1", "A1"].Font.FontStyle = "Bold";


                        xlNewSheet11.Range["B1", "B1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        xlNewSheet11.Range["B1", "B1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet11.Range["B1", "B1"].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        xlNewSheet11.Range["B1", "B1"].Font.Bold = false;
                        xlNewSheet11.Range["B1", "B1"].Font.Name = "Calibri";
                        xlNewSheet11.Range["B1", "B1"].Font.Size = 11;
                        xlNewSheet11.Range["B1", "B1"].Font.FontStyle = "Bold";

                        xlNewSheet11.Range["C1", "C1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        xlNewSheet11.Range["C1", "C1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet11.Range["C1", "C1"].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        xlNewSheet11.Range["C1", "C1"].Font.Bold = false;
                        xlNewSheet11.Range["C1", "C1"].Font.Name = "Calibri";
                        xlNewSheet11.Range["C1", "C1"].Font.Size = 11;
                        xlNewSheet11.Range["C1", "C1"].Font.FontStyle = "Bold";

                        xlNewSheet11.Range["D1", "D1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        xlNewSheet11.Range["D1", "D1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet11.Range["D1", "D1"].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        xlNewSheet11.Range["D1", "D1"].Font.Bold = false;
                        xlNewSheet11.Range["D1", "D1"].Font.Name = "Calibri";
                        xlNewSheet11.Range["D1", "D1"].Font.Size = 11;
                        xlNewSheet11.Range["D1", "D1"].Font.FontStyle = "Bold";

                        xlNewSheet11.Range["E1", "E1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        xlNewSheet11.Range["E1", "E1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet11.Range["E1", "E1"].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        xlNewSheet11.Range["E1", "E1"].Font.Bold = false;
                        xlNewSheet11.Range["E1", "E1"].Font.Name = "Calibri";
                        xlNewSheet11.Range["E1", "E1"].Font.Size = 11;
                        xlNewSheet11.Range["E1", "E1"].Font.FontStyle = "Bold";
                        xlNewSheet11.Range["E1", "E1"].ColumnWidth = 12.00;
                        xlNewSheet11.Range["E1", "E1"].WrapText = true;

                        xlNewSheet11.Range["F1", "F1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        xlNewSheet11.Range["F1", "F1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet11.Range["F1", "F1"].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        xlNewSheet11.Range["F1", "F1"].Font.Bold = false;
                        xlNewSheet11.Range["F1", "F1"].Font.Name = "Calibri";
                        xlNewSheet11.Range["F1", "F1"].Font.Size = 11;
                        xlNewSheet11.Range["F1", "F1"].Font.FontStyle = "Bold";


                        xlNewSheet11.Range["G1", "G1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        xlNewSheet11.Range["G1", "G1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet11.Range["G1", "G1"].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        xlNewSheet11.Range["G1", "G1"].Font.Bold = false;
                        xlNewSheet11.Range["G1", "G1"].Font.Name = "Calibri";
                        xlNewSheet11.Range["G1", "G1"].Font.Size = 11;
                        xlNewSheet11.Range["G1", "G1"].Font.FontStyle = "Bold";

                        xlNewSheet11.Range["H1", "H1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        xlNewSheet11.Range["H1", "H1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet11.Range["H1", "H1"].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        xlNewSheet11.Range["H1", "H1"].Font.Bold = false;
                        xlNewSheet11.Range["H1", "H1"].Font.Name = "Calibri";
                        xlNewSheet11.Range["H1", "H1"].Font.Size = 11;
                        xlNewSheet11.Range["H1", "H1"].Font.FontStyle = "Bold";


                        xlNewSheet11.Range["I1", "I1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        xlNewSheet11.Range["I1", "I1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet11.Range["I1", "I1"].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        xlNewSheet11.Range["I1", "I1"].Font.Bold = false;
                        xlNewSheet11.Range["I1", "I1"].Font.Name = "Calibri";
                        xlNewSheet11.Range["I1", "I1"].Font.Size = 11;
                        xlNewSheet11.Range["I1", "I1"].Font.FontStyle = "Bold";

                        xlNewSheet11.Range["J1", "J1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        xlNewSheet11.Range["J1", "J1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet11.Range["J1", "J1"].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        xlNewSheet11.Range["J1", "J1"].Font.Bold = false;
                        xlNewSheet11.Range["J1", "J1"].Font.Name = "Calibri";
                        xlNewSheet11.Range["J1", "J1"].Font.Size = 11;
                        xlNewSheet11.Range["J1", "J1"].Font.FontStyle = "Bold";
                        xlNewSheet11.Range["J1", "J1"].ColumnWidth = 11.14;
                        xlNewSheet11.Range["J1", "J1"].WrapText = true;

                        xlNewSheet11.Range["K1", "K1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        xlNewSheet11.Range["K1", "K1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet11.Range["K1", "K1"].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        xlNewSheet11.Range["K1", "K1"].Font.Bold = false;
                        xlNewSheet11.Range["K1", "K1"].Font.Name = "Calibri";
                        xlNewSheet11.Range["K1", "K1"].Font.Size = 11;
                        xlNewSheet11.Range["K1", "K1"].Font.FontStyle = "Bold";
                        xlNewSheet11.Range["K1", "K1"].ColumnWidth = 13.50;
                        xlNewSheet11.Range["K1", "K1"].WrapText = true;

                        xlNewSheet11.Range["L1", "L1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        xlNewSheet11.Range["L1", "L1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet11.Range["L1", "L1"].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        xlNewSheet11.Range["L1", "L1"].Font.Bold = false;
                        xlNewSheet11.Range["L1", "L1"].Font.Name = "Calibri";
                        xlNewSheet11.Range["L1", "L1"].Font.Size = 11;
                        xlNewSheet11.Range["L1", "L1"].Font.FontStyle = "Bold";
                        xlNewSheet11.Range["L1", "L1"].ColumnWidth = 13.50;
                        xlNewSheet11.Range["L1", "L1"].WrapText = true;

                        xlNewSheet11.Range["M1", "M1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        xlNewSheet11.Range["M1", "M1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet11.Range["M1", "M1"].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        xlNewSheet11.Range["M1", "M1"].Font.Bold = false;
                        xlNewSheet11.Range["M1", "M1"].Font.Name = "Calibri";
                        xlNewSheet11.Range["M1", "M1"].Font.Size = 11;
                        xlNewSheet11.Range["M1", "M1"].Font.FontStyle = "Bold";


                        xlNewSheet11.Range["N1", "N1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        xlNewSheet11.Range["N1", "N1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet11.Range["N1", "N1"].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        xlNewSheet11.Range["N1", "N1"].Font.Bold = false;
                        xlNewSheet11.Range["N1", "N1"].Font.Name = "Calibri";
                        xlNewSheet11.Range["N1", "N1"].Font.Size = 11;
                        xlNewSheet11.Range["N1", "N1"].Font.FontStyle = "Bold";
                        xlNewSheet11.Range["N1", "N1"].ColumnWidth = 13.50;
                        xlNewSheet11.Range["N1", "N1"].WrapText = true;

                        xlNewSheet11.Range["O1", "O1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        xlNewSheet11.Range["O1", "O1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet11.Range["O1", "O1"].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        xlNewSheet11.Range["O1", "O1"].Font.Bold = false;
                        xlNewSheet11.Range["O1", "O1"].Font.Name = "Calibri";
                        xlNewSheet11.Range["O1", "O1"].Font.Size = 11;
                        xlNewSheet11.Range["O1", "O1"].Font.FontStyle = "Bold";

                        xlNewSheet11.Range["P1", "P1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        xlNewSheet11.Range["P1", "P1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet11.Range["P1", "P1"].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        xlNewSheet11.Range["P1", "P1"].Font.Bold = false;
                        xlNewSheet11.Range["P1", "P1"].Font.Name = "Calibri";
                        xlNewSheet11.Range["P1", "P1"].Font.Size = 11;
                        xlNewSheet11.Range["P1", "P1"].Font.FontStyle = "Bold";

                        xlNewSheet11.Range["Q1", "Q1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        xlNewSheet11.Range["Q1", "Q1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet11.Range["Q1", "Q1"].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        xlNewSheet11.Range["Q1", "Q1"].Font.Bold = false;
                        xlNewSheet11.Range["Q1", "Q1"].Font.Name = "Calibri";
                        xlNewSheet11.Range["Q1", "Q1"].Font.Size = 11;
                        xlNewSheet11.Range["Q1", "Q1"].Font.FontStyle = "Bold";

                        xlNewSheet11.Range["R1", "R1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        xlNewSheet11.Range["R1", "R1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet11.Range["R1", "R1"].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        xlNewSheet11.Range["R1", "R1"].Font.Bold = false;
                        xlNewSheet11.Range["R1", "R1"].Font.Name = "Calibri";
                        xlNewSheet11.Range["R1", "R1"].Font.Size = 11;
                        xlNewSheet11.Range["R1", "R1"].Font.FontStyle = "Bold";

                        xlNewSheet11.Range["S1", "S1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        xlNewSheet11.Range["S1", "S1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet11.Range["S1", "S1"].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        xlNewSheet11.Range["S1", "S1"].Font.Bold = false;
                        xlNewSheet11.Range["S1", "S1"].Font.Name = "Calibri";
                        xlNewSheet11.Range["S1", "S1"].Font.Size = 11;
                        xlNewSheet11.Range["S1", "S1"].Font.FontStyle = "Bold";

                        xlNewSheet11.Range["T1", "T1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        xlNewSheet11.Range["T1", "T1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet11.Range["T1", "T1"].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        xlNewSheet11.Range["T1", "T1"].Font.Bold = false;
                        xlNewSheet11.Range["T1", "T1"].Font.Name = "Calibri";
                        xlNewSheet11.Range["T1", "T1"].Font.Size = 11;
                        xlNewSheet11.Range["T1", "T1"].Font.FontStyle = "Bold";


                        xlNewSheet11.Range["A1", "V1"].RowHeight = 35;
                        xlNewSheet11.Range["K1"].Cells.EntireColumn.NumberFormat = "d mmm (ddd);@";
                        xlNewSheet11.Range["L1"].Cells.EntireColumn.NumberFormat = "d mmm (ddd);@";
                        xlNewSheet11.Range["M1"].Cells.EntireColumn.NumberFormat = "d mmm (ddd);@";
                        xlNewSheet11.Range["N1"].Cells.EntireColumn.NumberFormat = "d mmm (ddd);@";
                        xlNewSheet11.Range["O1"].Cells.EntireColumn.NumberFormat = "d mmm (ddd);@";
                        xlNewSheet11.Range["S1"].Cells.EntireColumn.NumberFormat = "d mmm (ddd);@";
                        //xlNewSheet11.Range["T1"].Cells.EntireColumn.NumberFormat = "d mmm (ddd);@";

                        xlNewSheet11.Columns.AutoFit();
                        xlNewSheet11.Range["A1", "T1"].WrapText = true;
                        xlNewSheet11.Range["A1", "T1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);

                        xlNewSheet11.Range["A1", "T1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet11.Range["A1", "T1"].Font.Bold = true;
                        releaseObject(xlNewSheet11);
                        ((Excel.Worksheet)xlApp.ActiveWorkbook.Sheets[1]).Activate();

                    }

                }
                if (ReportType == "Production_Planning_AgainstStyleCode")
                {
                    GlobalCountStyleCode_Planning = GlobalCountStyleCode_Planning + 1;
                    var xlNewSheet = (Excel.Worksheet)worksheets.Add(worksheets[GlobalCountStyleCode_Planning], Type.Missing, Type.Missing, Type.Missing);
                    xlNewSheet.Name = "Planning_StyleCode";
                    xlNewSheet.Cells[1, 1] = "StyleCode";
                    xlNewSheet.Cells[1, 2] = "AM";
                    xlNewSheet.Cells[1, 3] = "CompanyName";
                    xlNewSheet.Cells[1, 4] = "First Exfactory";
                    xlNewSheet.Cells[1, 5] = "Last Exfactory";
                    xlNewSheet.Cells[1, 6] = "Total Qty.";
                    xlNewSheet.Cells[1, 7] = "Quantity Range";
                    xlNewSheet.Cells[1, 8] = "Gmt Weight";
                    xlNewSheet.Cells[1, 9] = "SAM(Weighted)";
                    xlNewSheet.Cells[1, 10] = "Planned Status";
                    xlNewSheet.Cells[1, 11] = "Plan Start Date";
                    xlNewSheet.Cells[1, 12] = "Plan Start Line";
                    xlNewSheet.Cells[1, 13] = "Unit";


                    if (ds.Tables[0].Rows.Count == 0)
                    {
                        return false;
                    }
                    else if (ds.Tables[0].Rows.Count > 0)
                    {
                        int i = 1;
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            string StyleCode = dr["StyleCode"] == DBNull.Value ? string.Empty : Convert.ToString(dr["StyleCode"]);
                            xlNewSheet.Cells[i + 1, 1] = StyleCode;
                            xlNewSheet.Cells[i + 1, 2] = (dr["AM"] == DBNull.Value || Convert.ToString(dr["AM"]) == "") ? string.Empty : dr["AM"];
                            xlNewSheet.Cells[i + 1, 3] = (dr["ClientName"] == DBNull.Value || Convert.ToString(dr["ClientName"]) == "") ? string.Empty : dr["ClientName"];
                            xlNewSheet.Cells[i + 1, 4] = (dr["MinExfactory"] == DBNull.Value || Convert.ToString(dr["MinExfactory"]) == "") ? string.Empty : dr["MinExfactory"];
                            xlNewSheet.Cells[i + 1, 5] = (dr["MaxExfactory"] == DBNull.Value || Convert.ToString(dr["MaxExfactory"]) == "") ? string.Empty : dr["MaxExfactory"];
                            xlNewSheet.Cells[i + 1, 6] = (dr["Quantity"] == DBNull.Value || Convert.ToString(dr["Quantity"]) == "") ? string.Empty : Convert.ToInt32(dr["Quantity"]).ToString("N0"); // added code by bharat on 12-12-19
                            xlNewSheet.Cells[i + 1, 7] = (dr["Intervel"] == DBNull.Value || Convert.ToString(dr["Intervel"]) == "") ? string.Empty : dr["Intervel"];
                            xlNewSheet.Cells[i + 1, 8] = (dr["Weight"] == DBNull.Value || Convert.ToString(dr["Weight"]) == "0 gms") ? string.Empty : dr["Weight"];
                            xlNewSheet.Cells[i + 1, 9] = (dr["Sam"] == DBNull.Value || Convert.ToString(dr["Sam"]) == "") ? string.Empty : dr["Sam"];
                            xlNewSheet.Cells[i + 1, 10] = (dr["PlannedStyle"] == DBNull.Value || Convert.ToString(dr["PlannedStyle"]) == "") ? string.Empty : dr["PlannedStyle"];
                            xlNewSheet.Cells[i + 1, 11] = (dr["PlannedStartDate"] == DBNull.Value || Convert.ToString(dr["PlannedStartDate"]) == "") ? string.Empty : dr["PlannedStartDate"];
                            xlNewSheet.Cells[i + 1, 12] = (dr["LineNo"] == DBNull.Value || Convert.ToString(dr["LineNo"]) == "") ? string.Empty : dr["LineNo"];
                            xlNewSheet.Cells[i + 1, 13] = (dr["UnitName"] == DBNull.Value || Convert.ToString(dr["UnitName"]) == "") ? string.Empty : dr["UnitName"];

                            i++;
                        }
                        xlNewSheet.Columns.AutoFit();
                        xlNewSheet.Range["A1", "M1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        xlNewSheet.Range["A1", "M1"].EntireColumn.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        //xlNewSheet.Range["A1", "D1"].Font.Bold = true;
                        xlNewSheet.Range["A1"].EntireColumn.Font.Bold = true;
                        //xlNewSheet.Range["B1"].EntireColumn.Font.Bold = true;

                        xlNewSheet.Range["A1"].Cells.Font.Bold = false;


                        xlNewSheet.Range["A1", "M1"].EntireColumn.WrapText = true;

                        //----------change date format with filter created by Surendra Sharma on 09-03-2018.----
                        xlNewSheet.Range["D1"].Cells.EntireColumn.NumberFormat = "dd mmm (ddd);@";
                        xlNewSheet.Range["E1"].Cells.EntireColumn.NumberFormat = "dd mmm (ddd);@";
                        xlNewSheet.Range["K1"].Cells.EntireColumn.NumberFormat = "dd mmm (ddd);@";
                        //-------------End-----------------------------------------------------------------------

                        xlNewSheet.get_Range("A1:M" + i).Cells.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;

                        ((Excel.Worksheet)xlApp.ActiveWorkbook.Sheets[1]).Activate();

                        xlNewSheet.Select();

                        releaseObject(xlNewSheet);

                    }
                }

                if (ReportType == "Upcoming_exfactory")
                {
                    // iKandi.Common.Constants.WorkSheetCount_ForExcel = iKandi.Common.Constants.WorkSheetCount_ForExcel + 1;
                    GlobalType_Upcomming_Exfactory = GlobalType_Upcomming_Exfactory + 1;
                    var xlNewSheet11 = (Excel.Worksheet)worksheets.Add(worksheets[GlobalType_Upcomming_Exfactory], Type.Missing, Type.Missing, Type.Missing);
                    CultureInfo ci = new CultureInfo("en-IN");
                    ci.NumberFormat.CurrencySymbol = "₹";




                    xlNewSheet11.Name = "Upcoming_exfactory";
                    xlNewSheet11.Cells[1, 1] = "Department Name";
                    xlNewSheet11.Cells[1, 2] = "Serial number";
                    xlNewSheet11.Cells[1, 3] = "Style number";
                    xlNewSheet11.Cells[1, 4] = "Line Number";
                    xlNewSheet11.Cells[1, 5] = "ContractNumber";
                    xlNewSheet11.Cells[1, 6] = "Fabric1";
                    xlNewSheet11.Cells[1, 7] = "Colour/Print";
                    xlNewSheet11.Cells[1, 8] = "Weight(gms)";
                    xlNewSheet11.Cells[1, 9] = "Quantity";
                    xlNewSheet11.Cells[1, 10] = "PcsStitched Percent(%)";
                    xlNewSheet11.Cells[1, 11] = "PcsFinished Percent(%)";
                    xlNewSheet11.Cells[1, 12] = "Value in  INR/ Lacs.";
                    xlNewSheet11.Cells[1, 13] = "Ikandi Value in Thousands";
                    xlNewSheet11.Cells[1, 14] = "TOP Status";
                    xlNewSheet11.Cells[1, 15] = "MDA";
                    xlNewSheet11.Cells[1, 16] = "DeliveryMode";
                    xlNewSheet11.Cells[1, 17] = "ExFactory";
                    xlNewSheet11.Cells[1, 18] = "DC";
                    xlNewSheet11.Cells[1, 19] = "Booking Status";
                    xlNewSheet11.Cells[1, 20] = "Start date";
                    xlNewSheet11.Cells[1, 21] = "End Date";
                    xlNewSheet11.Cells[1, 22] = "Ship Plan Date";
                    xlNewSheet11.Cells[1, 23] = "Line Plan";
                    xlNewSheet11.Cells[1, 24] = "UnitName";
                    //xlNewSheet11.Cells[1, 22] = "Weight";
                    xlNewSheet11.Cells[1, 25] = "Remark";
                    xlNewSheet11.Cells[1, 26] = "Destination Code";



                    if (ds.Tables[0].Rows.Count == 0)
                    {
                        return false;
                    }
                    else if (ds.Tables[0].Rows.Count > 0)
                    {
                        int R = 1;
                        int Y = 2;
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {



                            xlNewSheet11.Cells[R + 1, 1] = dr["DepartmentName"] == DBNull.Value ? string.Empty : Convert.ToString(dr["DepartmentName"]);
                            xlNewSheet11.Cells[R + 1, 2] = dr["Serialnumber"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Serialnumber"]);
                            xlNewSheet11.Cells[R + 1, 3] = dr["Stylenumber"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Stylenumber"]);
                            xlNewSheet11.Cells[R + 1, 4] = dr["LineNOs"] == DBNull.Value ? string.Empty : Convert.ToString(dr["LineNOs"]);
                            xlNewSheet11.Cells[R + 1, 5] = dr["ContractNumber"] == DBNull.Value ? string.Empty : Convert.ToString(dr["ContractNumber"]);

                            xlNewSheet11.Cells[R + 1, 6] = dr["Fabric1"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Fabric1"]);
                            xlNewSheet11.Cells[R + 1, 7] = dr["Fabric1Details"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Fabric1Details"]);
                            xlNewSheet11.Cells[R + 1, 8] = (dr["Weight"] == DBNull.Value || dr["Weight"].ToString() == "0") ? string.Empty : Convert.ToString(dr["Weight"]);
                            xlNewSheet11.Cells[R + 1, 9] = dr["Quantity"] == DBNull.Value ? string.Empty : Convert.ToString(Convert.ToInt32(dr["Quantity"]).ToString("N0"));
                            xlNewSheet11.Cells[R + 1, 10] = dr["PcsStitched_Percent"] == DBNull.Value ? string.Empty : Convert.ToString(dr["PcsStitched_Percent"]);
                            xlNewSheet11.Cells[R + 1, 11] = dr["PcsFinished_Percent"] == DBNull.Value ? string.Empty : Convert.ToString(dr["PcsFinished_Percent"]);
                            xlNewSheet11.Cells[R + 1, 12] = dr["Value"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Value"]);

                            xlNewSheet11.Cells[R + 1, 13] = Convert.ToString(dr["ikandiValue"]) == "0" ? string.Empty : Convert.ToString(dr["ikandiValue"]);
                            xlNewSheet11.Cells[R + 1, 14] = dr["TOPStatus"] == DBNull.Value ? string.Empty : Convert.ToString(dr["TOPStatus"]);
                            xlNewSheet11.Cells[R + 1, 15] = dr["MDA"] == DBNull.Value ? string.Empty : Convert.ToString(dr["MDA"]);

                            xlNewSheet11.Cells[R + 1, 16] = dr["DeliveryMode"] == DBNull.Value ? string.Empty : Convert.ToString(dr["DeliveryMode"]);
                            xlNewSheet11.Cells[R + 1, 17] = (dr["ExFactory"] == DBNull.Value || Convert.ToString(dr["ExFactory"]) == "") ? string.Empty : dr["ExFactory"];
                            xlNewSheet11.Cells[R + 1, 18] = (dr["DC"] == DBNull.Value || Convert.ToString(dr["DC"]) == "") ? string.Empty : dr["DC"];
                            xlNewSheet11.Cells[R + 1, 19] = dr["BookingStatus"] == DBNull.Value ? string.Empty : Convert.ToString(dr["BookingStatus"]);
                            //xlNewSheet11.Cells[R + 1, 17] = dr["Readydate"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Readydate"]);
                            //xlNewSheet11.Cells[R + 1, 18] = dr["ReadyTime"] == DBNull.Value ? string.Empty : Convert.ToString(dr["ReadyTime"]);
                            xlNewSheet11.Cells[R + 1, 20] = (dr["StartDate"] == DBNull.Value || Convert.ToString(dr["StartDate"]) == "") ? string.Empty : dr["StartDate"];
                            xlNewSheet11.Cells[R + 1, 21] = (dr["EndDate"] == DBNull.Value || Convert.ToString(dr["EndDate"]) == "") ? string.Empty : dr["EndDate"];
                            xlNewSheet11.Cells[R + 1, 22] = (dr["PlanDate"] == DBNull.Value || Convert.ToString(dr["PlanDate"]) == "") ? string.Empty : dr["PlanDate"];
                            xlNewSheet11.Cells[R + 1, 23] = dr["lineplan"] == DBNull.Value ? string.Empty : dr["lineplan"];//Line plan
                            xlNewSheet11.Cells[R + 1, 24] = dr["UnitID"] == DBNull.Value ? string.Empty : Convert.ToString(dr["UnitID"]);
                            xlNewSheet11.Cells[R + 1, 25] = dr["Remark"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Remark"]);//Weight     
                            xlNewSheet11.Cells[R + 1, 26] = dr["DestinationCode"] == DBNull.Value ? string.Empty : Convert.ToString(dr["DestinationCode"]);//Weight




                            //xlNewSheet11.Cells[R + 1, 19] = dr["Fabric4Details"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Fabric4Details"]);

                            xlNewSheet11.Range["A1", "A1"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;

                            xlNewSheet11.Range["B1", "B1"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["C1", "C1"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["D1", "D1"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["E1", "E1"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["F1", "F1"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["G1", "G1"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["H1", "H1"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["I1", "I1"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["J1", "J1"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["K1", "K1"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["L1", "L1"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["M1", "M1"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["N1", "N1"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["O1", "O1"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["P1", "P1"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["Q1", "Q1"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["R1", "R1"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["S1", "S1"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["T1", "T1"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["U1", "U1"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["V1", "V1"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["W1", "W1"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["X1", "X1"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["Y1", "Y1"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["Z1", "Z1"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;

                            xlNewSheet11.Range["A" + Y, "A" + Y].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["B" + Y, "B" + Y].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["C" + Y, "C" + Y].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["D" + Y, "D" + Y].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["E" + Y, "E" + Y].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["F" + Y, "F" + Y].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["G" + Y, "G" + Y].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["H" + Y, "H" + Y].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["I" + Y, "I" + Y].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["J" + Y, "J" + Y].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["K" + Y, "K" + Y].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["L" + Y, "L" + Y].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["M" + Y, "M" + Y].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["N" + Y, "N" + Y].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["O" + Y, "O" + Y].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["P" + Y, "P" + Y].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["Q" + Y, "Q" + Y].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["R" + Y, "R" + Y].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["S" + Y, "S" + Y].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["T" + Y, "T" + Y].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;

                            xlNewSheet11.Range["U" + Y, "U" + Y].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["V" + Y, "V" + Y].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["W" + Y, "W" + Y].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["X" + Y, "X" + Y].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["Y" + Y, "Y" + Y].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["Z" + Y, "Z" + Y].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;



                            xlNewSheet11.Range["A" + Y, "A" + Y].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet11.Range["A" + Y, "A" + Y].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet11.Range["A" + Y, "A" + Y].Font.Name = "Calibri";
                            xlNewSheet11.Range["A" + Y, "A" + Y].Font.Size = 8;
                            xlNewSheet11.Range["A" + Y, "A" + Y].Font.FontStyle = "Regular";//Department Name

                            xlNewSheet11.Range["B" + Y, "B" + Y].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet11.Range["B" + Y, "B" + Y].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet11.Range["B" + Y, "B" + Y].Font.Name = "Calibri";
                            xlNewSheet11.Range["B" + Y, "B" + Y].Font.Size = 11;
                            xlNewSheet11.Range["B" + Y, "B" + Y].Font.FontStyle = "Bold";//Serial number

                            xlNewSheet11.Range["C" + Y, "C" + Y].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet11.Range["C" + Y, "C" + Y].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet11.Range["C" + Y, "C" + Y].Font.Name = "Calibri";
                            xlNewSheet11.Range["C" + Y, "C" + Y].Font.Size = 11;
                            xlNewSheet11.Range["C" + Y, "C" + Y].Font.FontStyle = "Regular";//Style number


                            xlNewSheet11.Range["D" + Y, "D" + Y].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet11.Range["D" + Y, "D" + Y].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet11.Range["D" + Y, "D" + Y].Font.Name = "Calibri";
                            xlNewSheet11.Range["D" + Y, "D" + Y].Font.Size = 9;
                            xlNewSheet11.Range["D" + Y, "D" + Y].Font.FontStyle = "Regular";//Line Number


                            xlNewSheet11.Range["E" + Y, "E" + Y].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet11.Range["E" + Y, "E" + Y].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet11.Range["E" + Y, "E" + Y].Font.Name = "Calibri";
                            xlNewSheet11.Range["E" + Y, "E" + Y].Font.Size = 9;
                            xlNewSheet11.Range["E" + Y, "E" + Y].Font.FontStyle = "Regular";//ContractNumber

                            xlNewSheet11.Range["F" + Y, "F" + Y].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet11.Range["F" + Y, "F" + Y].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet11.Range["F" + Y, "F" + Y].Font.Name = "Calibri";
                            xlNewSheet11.Range["F" + Y, "F" + Y].Font.Size = 8;
                            xlNewSheet11.Range["F" + Y, "F" + Y].Font.FontStyle = "Regular";//Fabric1

                            xlNewSheet11.Range["G" + Y, "G" + Y].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet11.Range["G" + Y, "G" + Y].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet11.Range["G" + Y, "G" + Y].Font.Name = "Calibri";
                            xlNewSheet11.Range["G" + Y, "G" + Y].Font.Size = 8;
                            xlNewSheet11.Range["G" + Y, "G" + Y].Font.FontStyle = "Regular";//Colour/Print

                            xlNewSheet11.Range["H" + Y, "H" + Y].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet11.Range["H" + Y, "H" + Y].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet11.Range["H" + Y, "H" + Y].Font.Name = "Calibri";
                            xlNewSheet11.Range["H" + Y, "H" + Y].Font.Size = 8;
                            xlNewSheet11.Range["H" + Y, "H" + Y].Font.FontStyle = "Regular";//Weight 


                            xlNewSheet11.Range["I" + Y, "I" + Y].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet11.Range["I" + Y, "I" + Y].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet11.Range["I" + Y, "I" + Y].Font.Name = "Calibri";
                            xlNewSheet11.Range["I" + Y, "I" + Y].Font.Size = 12;
                            xlNewSheet11.Range["I" + Y, "I" + Y].Font.FontStyle = "Bold";//Quantity

                            xlNewSheet11.Range["J" + Y, "J" + Y].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet11.Range["J" + Y, "J" + Y].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet11.Range["J" + Y, "J" + Y].Font.Name = "Calibri";
                            xlNewSheet11.Range["J" + Y, "J" + Y].Font.Size = 9;
                            xlNewSheet11.Range["J" + Y, "J" + Y].Font.FontStyle = "Regular";//PcsStitche

                            xlNewSheet11.Range["K" + Y, "K" + Y].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet11.Range["K" + Y, "K" + Y].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet11.Range["K" + Y, "K" + Y].Font.Name = "Calibri";
                            xlNewSheet11.Range["K" + Y, "K" + Y].Font.Size = 9;
                            xlNewSheet11.Range["K" + Y, "K" + Y].Font.FontStyle = "Regular";//PcsStitche

                            xlNewSheet11.Range["L" + Y, "L" + Y].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet11.Range["L" + Y, "L" + Y].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet11.Range["L" + Y, "L" + Y].Font.Name = "Calibri";
                            xlNewSheet11.Range["L" + Y, "L" + Y].Font.Size = 9;
                            xlNewSheet11.Range["L" + Y, "L" + Y].Font.FontStyle = "Regular";//Value in

                            xlNewSheet11.Range["M" + Y, "M" + Y].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet11.Range["M" + Y, "M" + Y].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet11.Range["M" + Y, "M" + Y].Font.Name = "Calibri";
                            xlNewSheet11.Range["M" + Y, "M" + Y].Font.Size = 8;
                            xlNewSheet11.Range["M" + Y, "M" + Y].Font.FontStyle = "Regular";//TOP Status

                            xlNewSheet11.Range["N" + Y, "N" + Y].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet11.Range["N" + Y, "N" + Y].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet11.Range["N" + Y, "N" + Y].Font.Name = "Calibri";
                            xlNewSheet11.Range["N" + Y, "N" + Y].Font.Size = 9;
                            xlNewSheet11.Range["N" + Y, "N" + Y].Font.FontStyle = "Regular";//MDA

                            xlNewSheet11.Range["O" + Y, "O" + Y].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet11.Range["O" + Y, "O" + Y].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet11.Range["O" + Y, "O" + Y].Font.Name = "Calibri";
                            xlNewSheet11.Range["O" + Y, "O" + Y].Font.Size = 9;
                            xlNewSheet11.Range["O" + Y, "O" + Y].Font.FontStyle = "Regular";//DeliveryMode

                            xlNewSheet11.Range["P" + Y, "P" + Y].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet11.Range["P" + Y, "P" + Y].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet11.Range["P" + Y, "P" + Y].Font.Name = "Calibri";
                            xlNewSheet11.Range["P" + Y, "P" + Y].Font.Size = 12;
                            xlNewSheet11.Range["P" + Y, "P" + Y].Font.FontStyle = "Bold";//ExFactory

                            xlNewSheet11.Range["Q" + Y, "Q" + Y].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet11.Range["Q" + Y, "Q" + Y].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet11.Range["Q" + Y, "Q" + Y].Font.Name = "Calibri";
                            xlNewSheet11.Range["Q" + Y, "Q" + Y].Font.Size = 11;
                            xlNewSheet11.Range["Q" + Y, "Q" + Y].Font.FontStyle = "Regular";//DC

                            xlNewSheet11.Range["R" + Y, "R" + Y].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet11.Range["R" + Y, "R" + Y].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet11.Range["R" + Y, "R" + Y].Font.Name = "Calibri";
                            xlNewSheet11.Range["R" + Y, "R" + Y].Font.Size = 10;
                            xlNewSheet11.Range["R" + Y, "R" + Y].Font.FontStyle = "Regular";//Booking Status

                            xlNewSheet11.Range["S" + Y, "S" + Y].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet11.Range["S" + Y, "S" + Y].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet11.Range["S" + Y, "S" + Y].Font.Name = "Calibri";
                            xlNewSheet11.Range["S" + Y, "S" + Y].Font.Size = 10;
                            xlNewSheet11.Range["S" + Y, "S" + Y].Font.FontStyle = "Regular";//Start Date


                            xlNewSheet11.Range["T" + Y, "U" + Y].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet11.Range["T" + Y, "U" + Y].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet11.Range["T" + Y, "U" + Y].Font.Name = "Calibri";
                            xlNewSheet11.Range["T" + Y, "U" + Y].Font.Size = 10;
                            xlNewSheet11.Range["T" + Y, "U" + Y].Font.FontStyle = "Regular";//End Date

                            xlNewSheet11.Range["U" + Y, "U" + Y].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet11.Range["U" + Y, "U" + Y].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet11.Range["U" + Y, "U" + Y].Font.Name = "Calibri";
                            xlNewSheet11.Range["U" + Y, "U" + Y].Font.Size = 10;
                            xlNewSheet11.Range["U" + Y, "U" + Y].Font.FontStyle = "Regular";//Ship Plan Date

                            xlNewSheet11.Range["V" + Y, "V" + Y].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet11.Range["V" + Y, "V" + Y].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet11.Range["V" + Y, "V" + Y].Font.Name = "Calibri";
                            xlNewSheet11.Range["V" + Y, "V" + Y].Font.Size = 11;
                            xlNewSheet11.Range["V" + Y, "V" + Y].Font.FontStyle = "Regular";//Line Plan

                            xlNewSheet11.Range["W" + Y, "W" + Y].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet11.Range["W" + Y, "W" + Y].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet11.Range["W" + Y, "W" + Y].Font.Name = "Calibri";
                            xlNewSheet11.Range["W" + Y, "W" + Y].Font.Size = 10;
                            xlNewSheet11.Range["W" + Y, "W" + Y].Font.FontStyle = "Regular";//UnitName

                            xlNewSheet11.Range["X" + Y, "X" + Y].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet11.Range["X" + Y, "X" + Y].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet11.Range["X" + Y, "X" + Y].Font.Name = "Calibri";
                            xlNewSheet11.Range["X" + Y, "X" + Y].Font.Size = 10;
                            xlNewSheet11.Range["X" + Y, "X" + Y].Font.FontStyle = "Regular";//Remark

                            xlNewSheet11.Range["Y" + Y, "Y" + Y].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet11.Range["Y" + Y, "Y" + Y].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet11.Range["Y" + Y, "Y" + Y].Font.Name = "Calibri";
                            xlNewSheet11.Range["Y" + Y, "Y" + Y].Font.Size = 10;
                            xlNewSheet11.Range["Y" + Y, "Y" + Y].Font.FontStyle = "Regular";//Remark

                            xlNewSheet11.Range["Z" + Y, "Z" + Y].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet11.Range["Z" + Y, "Z" + Y].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet11.Range["Z" + Y, "Z" + Y].Font.Name = "Calibri";
                            xlNewSheet11.Range["Z" + Y, "Z" + Y].Font.Size = 10;
                            xlNewSheet11.Range["Z" + Y, "Z" + Y].Font.FontStyle = "Regular";//Remark


                            R++;
                            Y++;
                        }
                        xlNewSheet11.Range["A1", "A1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        xlNewSheet11.Range["A1", "A1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet11.Range["A1", "A1"].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        xlNewSheet11.Range["A1", "A1"].Font.Bold = false;
                        xlNewSheet11.Range["A1", "A1"].Font.Name = "Calibri";
                        xlNewSheet11.Range["A1", "A1"].Font.Size = 8;
                        xlNewSheet11.Range["A1", "A1"].Font.FontStyle = "Regular";


                        xlNewSheet11.Range["B1", "B1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        xlNewSheet11.Range["B1", "B1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet11.Range["B1", "B1"].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        xlNewSheet11.Range["B1", "B1"].Font.Bold = false;
                        xlNewSheet11.Range["B1", "B1"].Font.Name = "Calibri";
                        xlNewSheet11.Range["B1", "B1"].Font.Size = 11;
                        xlNewSheet11.Range["B1", "B1"].Font.FontStyle = "Regular";

                        xlNewSheet11.Range["C1", "C1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        xlNewSheet11.Range["C1", "C1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet11.Range["C1", "C1"].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        xlNewSheet11.Range["C1", "C1"].Font.Bold = false;
                        xlNewSheet11.Range["C1", "C1"].Font.Name = "Calibri";
                        xlNewSheet11.Range["C1", "C1"].Font.Size = 11;
                        xlNewSheet11.Range["C1", "C1"].Font.FontStyle = "Regular";

                        xlNewSheet11.Range["D1", "D1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        xlNewSheet11.Range["D1", "D1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet11.Range["D1", "D1"].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        xlNewSheet11.Range["D1", "D1"].Font.Bold = false;
                        xlNewSheet11.Range["D1", "D1"].Font.Name = "Calibri";
                        xlNewSheet11.Range["D1", "D1"].Font.Size = 9;
                        xlNewSheet11.Range["D1", "D1"].Font.FontStyle = "Regular";

                        xlNewSheet11.Range["E1", "E1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        xlNewSheet11.Range["E1", "E1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet11.Range["E1", "E1"].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        xlNewSheet11.Range["E1", "E1"].Font.Bold = false;
                        xlNewSheet11.Range["E1", "E1"].Font.Name = "Calibri";
                        xlNewSheet11.Range["E1", "E1"].Font.Size = 9;
                        xlNewSheet11.Range["E1", "E1"].Font.FontStyle = "Regular";


                        xlNewSheet11.Range["F1", "F1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        xlNewSheet11.Range["F1", "F1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet11.Range["F1", "F1"].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        xlNewSheet11.Range["F1", "F1"].Font.Bold = false;
                        xlNewSheet11.Range["F1", "F1"].Font.Name = "Calibri";
                        xlNewSheet11.Range["F1", "F1"].Font.Size = 8;
                        xlNewSheet11.Range["F1", "F1"].Font.FontStyle = "Regular";


                        xlNewSheet11.Range["G1", "G1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        xlNewSheet11.Range["G1", "G1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet11.Range["G1", "G1"].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        xlNewSheet11.Range["G1", "G1"].Font.Bold = false;
                        xlNewSheet11.Range["G1", "G1"].Font.Name = "Calibri";
                        xlNewSheet11.Range["G1", "G1"].Font.Size = 8;
                        xlNewSheet11.Range["G1", "G1"].Font.FontStyle = "Regular";

                        xlNewSheet11.Range["H1", "H1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        xlNewSheet11.Range["H1", "H1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet11.Range["H1", "H1"].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        xlNewSheet11.Range["H1", "H1"].Font.Bold = false;
                        xlNewSheet11.Range["H1", "H1"].Font.Name = "Calibri";
                        xlNewSheet11.Range["H1", "H1"].Font.Size = 8;
                        xlNewSheet11.Range["H1", "H1"].Font.FontStyle = "Regular";


                        xlNewSheet11.Range["I1", "I1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        xlNewSheet11.Range["I1", "I1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet11.Range["I1", "I1"].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        xlNewSheet11.Range["I1", "I1"].Font.Bold = false;
                        xlNewSheet11.Range["I1", "I1"].Font.Name = "Calibri";
                        xlNewSheet11.Range["I1", "I1"].Font.Size = 12;
                        xlNewSheet11.Range["I1", "I1"].Font.FontStyle = "Bold";

                        xlNewSheet11.Range["J1", "J1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        xlNewSheet11.Range["J1", "J1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet11.Range["J1", "J1"].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        xlNewSheet11.Range["J1", "J1"].Font.Bold = false;
                        xlNewSheet11.Range["J1", "J1"].Font.Name = "Calibri";
                        xlNewSheet11.Range["J1", "J1"].Font.Size = 9;
                        xlNewSheet11.Range["J1", "J1"].Font.FontStyle = "Regular";

                        xlNewSheet11.Range["K1", "K1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        xlNewSheet11.Range["K1", "K1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet11.Range["K1", "K1"].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        xlNewSheet11.Range["K1", "K1"].Font.Bold = false;
                        xlNewSheet11.Range["K1", "K1"].Font.Name = "Calibri";
                        xlNewSheet11.Range["K1", "K1"].Font.Size = 9;
                        xlNewSheet11.Range["K1", "K1"].Font.FontStyle = "Regular";

                        xlNewSheet11.Range["L1", "L1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        xlNewSheet11.Range["L1", "L1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet11.Range["L1", "L1"].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        xlNewSheet11.Range["L1", "L1"].Font.Bold = false;
                        xlNewSheet11.Range["L1", "L1"].Font.Name = "Calibri";
                        xlNewSheet11.Range["L1", "L1"].Font.Size = 8;
                        xlNewSheet11.Range["L1", "L1"].Font.FontStyle = "Regular";

                        xlNewSheet11.Range["M1", "M1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        xlNewSheet11.Range["M1", "M1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet11.Range["M1", "M1"].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        xlNewSheet11.Range["M1", "M1"].Font.Bold = false;
                        xlNewSheet11.Range["M1", "M1"].Font.Name = "Calibri";
                        xlNewSheet11.Range["M1", "M1"].Font.Size = 8;
                        xlNewSheet11.Range["M1", "M1"].Font.FontStyle = "Regular";

                        xlNewSheet11.Range["N1", "N1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        xlNewSheet11.Range["N1", "N1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet11.Range["N1", "N1"].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        xlNewSheet11.Range["N1", "N1"].Font.Bold = false;
                        xlNewSheet11.Range["N1", "N1"].Font.Name = "Calibri";
                        xlNewSheet11.Range["N1", "N1"].Font.Size = 8;
                        xlNewSheet11.Range["N1", "N1"].Font.FontStyle = "Regular";


                        xlNewSheet11.Range["O1", "O1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        xlNewSheet11.Range["O1", "O1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet11.Range["O1", "O1"].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        xlNewSheet11.Range["O1", "O1"].Font.Bold = false;
                        xlNewSheet11.Range["O1", "O1"].Font.Name = "Calibri";
                        xlNewSheet11.Range["O1", "O1"].Font.Size = 11;
                        xlNewSheet11.Range["O1", "O1"].Font.FontStyle = "Regular";

                        xlNewSheet11.Range["P1", "P1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        xlNewSheet11.Range["P1", "P1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet11.Range["P1", "P1"].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        xlNewSheet11.Range["P1", "P1"].Font.Bold = false;
                        xlNewSheet11.Range["P1", "P1"].Font.Name = "Calibri";
                        xlNewSheet11.Range["P1", "P1"].Font.Size = 12;
                        xlNewSheet11.Range["P1", "P1"].Font.FontStyle = "Bold";

                        xlNewSheet11.Range["Q1", "Q1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        xlNewSheet11.Range["Q1", "Q1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet11.Range["Q1", "Q1"].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        xlNewSheet11.Range["Q1", "Q1"].Font.Bold = false;
                        xlNewSheet11.Range["Q1", "Q1"].Font.Name = "Calibri";
                        xlNewSheet11.Range["Q1", "Q1"].Font.Size = 12;
                        xlNewSheet11.Range["Q1", "Q1"].Font.FontStyle = "Regular";


                        xlNewSheet11.Range["R1", "R1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        xlNewSheet11.Range["R1", "R1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet11.Range["R1", "R1"].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        xlNewSheet11.Range["R1", "R1"].Font.Bold = false;
                        xlNewSheet11.Range["R1", "R1"].Font.Name = "Calibri";
                        xlNewSheet11.Range["R1", "R1"].Font.Size = 10;
                        xlNewSheet11.Range["R1", "R1"].Font.FontStyle = "Regular";


                        xlNewSheet11.Range["S1", "S1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        xlNewSheet11.Range["S1", "S1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet11.Range["S1", "S1"].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        xlNewSheet11.Range["S1", "S1"].Font.Bold = false;
                        xlNewSheet11.Range["S1", "S1"].Font.Name = "Calibri";
                        xlNewSheet11.Range["S1", "S1"].Font.Size = 10;
                        xlNewSheet11.Range["S1", "S1"].Font.FontStyle = "Regular";

                        xlNewSheet11.Range["T1", "T1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        xlNewSheet11.Range["T1", "T1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet11.Range["T1", "T1"].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        xlNewSheet11.Range["T1", "T1"].Font.Bold = false;
                        xlNewSheet11.Range["T1", "T1"].Font.Name = "Calibri";
                        xlNewSheet11.Range["T1", "T1"].Font.Size = 10;
                        xlNewSheet11.Range["T1", "T1"].Font.FontStyle = "Regular";

                        xlNewSheet11.Range["U1", "U1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        xlNewSheet11.Range["U1", "U1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet11.Range["U1", "U1"].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        xlNewSheet11.Range["U1", "U1"].Font.Bold = false;
                        xlNewSheet11.Range["U1", "U1"].Font.Name = "Calibri";
                        xlNewSheet11.Range["U1", "U1"].Font.Size = 11;
                        xlNewSheet11.Range["U1", "U1"].Font.FontStyle = "Regular";


                        xlNewSheet11.Range["V1", "V1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        xlNewSheet11.Range["V1", "V1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet11.Range["V1", "V1"].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        xlNewSheet11.Range["V1", "V1"].Font.Bold = false;
                        xlNewSheet11.Range["V1", "V1"].Font.Name = "Calibri";
                        xlNewSheet11.Range["V1", "V1"].Font.Size = 11;
                        xlNewSheet11.Range["V1", "V1"].Font.FontStyle = "Regular";


                        xlNewSheet11.Range["W1", "W1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        xlNewSheet11.Range["W1", "W1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet11.Range["W1", "W1"].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        xlNewSheet11.Range["W1", "W1"].Font.Bold = false;
                        xlNewSheet11.Range["W1", "W1"].Font.Name = "Calibri";
                        xlNewSheet11.Range["W1", "W1"].Font.Size = 9;
                        xlNewSheet11.Range["W1", "W1"].Font.FontStyle = "Regular";

                        xlNewSheet11.Range["X1", "X1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        xlNewSheet11.Range["X1", "X1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet11.Range["X1", "X1"].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        xlNewSheet11.Range["X1", "X1"].Font.Bold = false;
                        xlNewSheet11.Range["X1", "X1"].Font.Name = "Calibri";
                        xlNewSheet11.Range["X1", "X1"].Font.Size = 9;
                        xlNewSheet11.Range["X1", "X1"].Font.FontStyle = "Regular";

                        xlNewSheet11.Range["Y1", "Y1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        xlNewSheet11.Range["Y1", "Y1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet11.Range["Y1", "Y1"].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        xlNewSheet11.Range["Y1", "Y1"].Font.Bold = false;
                        xlNewSheet11.Range["Y1", "Y1"].Font.Name = "Calibri";
                        xlNewSheet11.Range["Y1", "Y1"].Font.Size = 9;
                        xlNewSheet11.Range["Y1", "Y1"].Font.FontStyle = "Regular";

                        xlNewSheet11.Range["Z1", "Z1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        xlNewSheet11.Range["Z1", "Z1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet11.Range["Z1", "Z1"].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        xlNewSheet11.Range["Z1", "Z1"].Font.Bold = false;
                        xlNewSheet11.Range["Z1", "Z1"].Font.Name = "Calibri";
                        xlNewSheet11.Range["Z1", "Z1"].Font.Size = 9;
                        xlNewSheet11.Range["Z1", "Z1"].Font.FontStyle = "Regular";


                        xlNewSheet11.Range["A1", "Z1"].RowHeight = 32;
                        xlNewSheet11.Columns.AutoFit();
                        //xlNewSheet11.Range["O1"].Cells.EntireColumn.NumberFormat = "d mmm (ddd);@";
                        xlNewSheet11.Range["Q1"].Cells.EntireColumn.NumberFormat = "d mmm (ddd);@";
                        xlNewSheet11.Range["R1"].Cells.EntireColumn.NumberFormat = "d mmm (ddd);@";
                        xlNewSheet11.Range["S1"].Cells.EntireColumn.NumberFormat = "d mmm (ddd);@";
                        xlNewSheet11.Range["T1"].Cells.EntireColumn.NumberFormat = "d mmm (ddd);@";
                        xlNewSheet11.Range["U1"].Cells.EntireColumn.NumberFormat = "d mmm (ddd);@";
                        xlNewSheet11.Range["V1"].Cells.EntireColumn.NumberFormat = "d mmm (ddd);@";
                        xlNewSheet11.Range["L1"].Cells.EntireColumn.NumberFormat = "₹0.00";
                        xlNewSheet11.Range["M1"].Cells.EntireColumn.NumberFormat = "£0.00";

                        //xlNewSheet11.Range["A1", "T1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        //xlNewSheet11.Range["A1", "T1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        //xlNewSheet11.Range["A1", "T1"].Font.Bold = true;

                        //xlNewSheet11.Range["A1", "T1"].Font.Name = "Calibri";
                        //xlNewSheet11.Range["A1", "T1"].Font.Size = 6;



                        releaseObject(xlNewSheet11);
                        ((Excel.Worksheet)xlApp.ActiveWorkbook.Sheets[1]).Activate();

                    }

                }
                if (ReportType == "CUT_WIP")
                {
                    // iKandi.Common.Constants.WorkSheetCount_ForExcel = iKandi.Common.Constants.WorkSheetCount_ForExcel + 1;
                    GlobalCount_WIP = GlobalCount_WIP + 1;
                    var xlNewSheet11 = (Excel.Worksheet)worksheets.Add(worksheets[GlobalCount_WIP], Type.Missing, Type.Missing, Type.Missing);
                    CultureInfo ci = new CultureInfo("en-IN");
                    ci.NumberFormat.CurrencySymbol = "₹";




                    xlNewSheet11.Name = "Cut_WIP";
                    xlNewSheet11.Cells[1, 1] = "Department Name";
                    xlNewSheet11.Cells[1, 2] = "Serial number";
                    xlNewSheet11.Cells[1, 3] = "Style number";
                    xlNewSheet11.Cells[1, 4] = "Line Number";
                    xlNewSheet11.Cells[1, 5] = "ContractNumber";
                    xlNewSheet11.Cells[1, 6] = "Fabric1";
                    xlNewSheet11.Cells[1, 7] = "Colour/Print";
                    xlNewSheet11.Cells[1, 8] = "Order Qty";
                    xlNewSheet11.Cells[1, 9] = "CutQty";
                    xlNewSheet11.Cells[1, 10] = "CutReady Qty";
                    xlNewSheet11.Cells[1, 11] = "Stitched Qty";
                    xlNewSheet11.Cells[1, 12] = "WIP";
                    xlNewSheet11.Cells[1, 13] = "ExFactory";
                    xlNewSheet11.Cells[1, 14] = "Line Plan Status";
                    xlNewSheet11.Cells[1, 15] = "Start Date";
                    xlNewSheet11.Cells[1, 16] = "Planned Status";





                    if (ds.Tables[0].Rows.Count == 0)
                    {
                        return false;
                    }
                    else if (ds.Tables[0].Rows.Count > 0)
                    {
                        int R = 1;
                        int Y = 2;
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {



                            xlNewSheet11.Cells[R + 1, 1] = dr["DepartmentName"] == DBNull.Value ? string.Empty : Convert.ToString(dr["DepartmentName"]);
                            xlNewSheet11.Cells[R + 1, 2] = dr["Serialnumber"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Serialnumber"]);
                            xlNewSheet11.Cells[R + 1, 3] = dr["Stylenumber"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Stylenumber"]);
                            xlNewSheet11.Cells[R + 1, 4] = dr["LineItemNumber"] == DBNull.Value ? string.Empty : Convert.ToString(dr["LineItemNumber"]);
                            xlNewSheet11.Cells[R + 1, 5] = dr["ContractNumber"] == DBNull.Value ? string.Empty : Convert.ToString(dr["ContractNumber"]);
                            xlNewSheet11.Cells[R + 1, 6] = dr["Fabric1"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Fabric1"]);
                            xlNewSheet11.Cells[R + 1, 7] = dr["Fabric1Details"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Fabric1Details"]);
                            xlNewSheet11.Cells[R + 1, 8] = dr["Quantity"] == DBNull.Value ? string.Empty : Convert.ToString(Convert.ToInt32(dr["Quantity"]).ToString("N0"));
                            xlNewSheet11.Cells[R + 1, 9] = dr["CutQty"] == DBNull.Value || dr["CutQty"].ToString() == "0" ? string.Empty : Convert.ToString(Convert.ToInt32(dr["CutQty"]).ToString("N0"));
                            xlNewSheet11.Cells[R + 1, 10] = dr["CutReadyQuantity"] == DBNull.Value || dr["CutReadyQuantity"].ToString() == "0" ? string.Empty : Convert.ToString(Convert.ToInt32(dr["CutReadyQuantity"]).ToString("N0"));
                            xlNewSheet11.Cells[R + 1, 11] = dr["StichedQty"].ToString() == "" ? string.Empty : Convert.ToString(Convert.ToInt32(dr["StichedQty"]).ToString("N0"));
                            xlNewSheet11.Cells[R + 1, 12] = dr["WIP"].ToString() == "" ? string.Empty : Convert.ToString(Convert.ToInt32(dr["WIP"]).ToString("N0"));
                            xlNewSheet11.Cells[R + 1, 13] = (dr["ExFactory"] == DBNull.Value || Convert.ToString(dr["ExFactory"]) == "") ? string.Empty : dr["ExFactory"];
                            xlNewSheet11.Cells[R + 1, 14] = dr["LinePlan"] == DBNull.Value ? string.Empty : Convert.ToString(dr["LinePlan"]);
                            xlNewSheet11.Cells[R + 1, 15] = (dr["PlanDate"] == DBNull.Value || Convert.ToString(dr["PlanDate"]) == "") ? string.Empty : dr["PlanDate"];
                            xlNewSheet11.Cells[R + 1, 16] = dr["PlannedStatus"] == DBNull.Value ? string.Empty : Convert.ToString(dr["PlannedStatus"]); ;







                            //xlNewSheet11.Cells[R + 1, 19] = dr["Fabric4Details"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Fabric4Details"]);

                            xlNewSheet11.Range["A1", "A1"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;

                            xlNewSheet11.Range["B1", "B1"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["C1", "C1"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["D1", "D1"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["E1", "E1"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["F1", "F1"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["G1", "G1"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["H1", "H1"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["I1", "I1"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["J1", "J1"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["K1", "K1"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["L1", "L1"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["M1", "M1"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["N1", "N1"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["O1", "O1"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["P1", "P1"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;


                            xlNewSheet11.Range["A" + Y, "A" + Y].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["B" + Y, "B" + Y].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["C" + Y, "C" + Y].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["D" + Y, "D" + Y].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["E" + Y, "E" + Y].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["F" + Y, "F" + Y].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["G" + Y, "G" + Y].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["H" + Y, "H" + Y].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["I" + Y, "I" + Y].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["J" + Y, "J" + Y].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["K" + Y, "K" + Y].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["L" + Y, "L" + Y].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["M" + Y, "M" + Y].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["N" + Y, "N" + Y].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["O" + Y, "O" + Y].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["P" + Y, "P" + Y].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;




                            xlNewSheet11.Range["A" + Y, "A" + Y].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet11.Range["A" + Y, "A" + Y].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet11.Range["A" + Y, "A" + Y].Font.Name = "Calibri";
                            xlNewSheet11.Range["A" + Y, "A" + Y].Font.Size = 8;
                            xlNewSheet11.Range["A" + Y, "A" + Y].Font.FontStyle = "Regular";//Department Name

                            xlNewSheet11.Range["B" + Y, "B" + Y].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet11.Range["B" + Y, "B" + Y].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet11.Range["B" + Y, "B" + Y].Font.Name = "Calibri";
                            xlNewSheet11.Range["B" + Y, "B" + Y].Font.Size = 11;
                            xlNewSheet11.Range["B" + Y, "B" + Y].Font.FontStyle = "Bold";//Serial number

                            xlNewSheet11.Range["C" + Y, "C" + Y].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet11.Range["C" + Y, "C" + Y].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet11.Range["C" + Y, "C" + Y].Font.Name = "Calibri";
                            xlNewSheet11.Range["C" + Y, "C" + Y].Font.Size = 11;
                            xlNewSheet11.Range["C" + Y, "C" + Y].Font.FontStyle = "Regular";//Style number


                            xlNewSheet11.Range["D" + Y, "D" + Y].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet11.Range["D" + Y, "D" + Y].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet11.Range["D" + Y, "D" + Y].Font.Name = "Calibri";
                            xlNewSheet11.Range["D" + Y, "D" + Y].Font.Size = 9;
                            xlNewSheet11.Range["D" + Y, "D" + Y].Font.FontStyle = "Regular";//Line Number


                            xlNewSheet11.Range["E" + Y, "E" + Y].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet11.Range["E" + Y, "E" + Y].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet11.Range["E" + Y, "E" + Y].Font.Name = "Calibri";
                            xlNewSheet11.Range["E" + Y, "E" + Y].Font.Size = 9;
                            xlNewSheet11.Range["E" + Y, "E" + Y].Font.FontStyle = "Regular";//ContractNumber

                            xlNewSheet11.Range["F" + Y, "F" + Y].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet11.Range["F" + Y, "F" + Y].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet11.Range["F" + Y, "F" + Y].Font.Name = "Calibri";
                            xlNewSheet11.Range["F" + Y, "F" + Y].Font.Size = 8;
                            xlNewSheet11.Range["F" + Y, "F" + Y].Font.FontStyle = "Regular";//Fabric1

                            xlNewSheet11.Range["G" + Y, "G" + Y].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet11.Range["G" + Y, "G" + Y].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet11.Range["G" + Y, "G" + Y].Font.Name = "Calibri";
                            xlNewSheet11.Range["G" + Y, "G" + Y].Font.Size = 8;
                            xlNewSheet11.Range["G" + Y, "G" + Y].Font.FontStyle = "Regular";//Colour/Print

                            xlNewSheet11.Range["H" + Y, "H" + Y].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet11.Range["H" + Y, "H" + Y].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet11.Range["H" + Y, "H" + Y].Font.Name = "Calibri";
                            xlNewSheet11.Range["H" + Y, "H" + Y].Font.Size = 8;
                            xlNewSheet11.Range["H" + Y, "H" + Y].Font.FontStyle = "Regular";//Weight 
                            xlNewSheet11.Range["H" + Y, "H" + Y].Font.FontStyle = "Bold";//Serial number


                            xlNewSheet11.Range["I" + Y, "I" + Y].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet11.Range["I" + Y, "I" + Y].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet11.Range["I" + Y, "I" + Y].Font.Name = "Calibri";
                            xlNewSheet11.Range["I" + Y, "I" + Y].Font.Size = 8;
                            xlNewSheet11.Range["I" + Y, "I" + Y].Font.FontStyle = "Regular";//Quantity

                            xlNewSheet11.Range["J" + Y, "J" + Y].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet11.Range["J" + Y, "J" + Y].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet11.Range["J" + Y, "J" + Y].Font.Name = "Calibri";
                            xlNewSheet11.Range["J" + Y, "J" + Y].Font.Size = 8;
                            xlNewSheet11.Range["J" + Y, "J" + Y].Font.FontStyle = "Regular";//PcsStitche

                            xlNewSheet11.Range["K" + Y, "K" + Y].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet11.Range["K" + Y, "K" + Y].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet11.Range["K" + Y, "K" + Y].Font.Name = "Calibri";
                            xlNewSheet11.Range["K" + Y, "K" + Y].Font.Size = 8;
                            xlNewSheet11.Range["K" + Y, "K" + Y].Font.FontStyle = "Regular";//PcsStitche

                            xlNewSheet11.Range["L" + Y, "L" + Y].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet11.Range["L" + Y, "L" + Y].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet11.Range["L" + Y, "L" + Y].Font.Name = "Calibri";
                            xlNewSheet11.Range["L" + Y, "L" + Y].Font.Size = 8;
                            xlNewSheet11.Range["L" + Y, "L" + Y].Font.FontStyle = "Regular";//Value in

                            xlNewSheet11.Range["M" + Y, "M" + Y].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet11.Range["M" + Y, "M" + Y].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet11.Range["M" + Y, "M" + Y].Font.Name = "Calibri";
                            xlNewSheet11.Range["M" + Y, "M" + Y].Font.Size = 8;
                            xlNewSheet11.Range["M" + Y, "M" + Y].Font.FontStyle = "Regular";//TOP Status

                            xlNewSheet11.Range["N" + Y, "N" + Y].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet11.Range["N" + Y, "N" + Y].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet11.Range["N" + Y, "N" + Y].Font.Name = "Calibri";
                            xlNewSheet11.Range["N" + Y, "N" + Y].Font.Size = 8;
                            xlNewSheet11.Range["N" + Y, "N" + Y].Font.FontStyle = "Regular";//MDA

                            xlNewSheet11.Range["O" + Y, "O" + Y].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet11.Range["O" + Y, "O" + Y].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet11.Range["O" + Y, "O" + Y].Font.Name = "Calibri";
                            xlNewSheet11.Range["O" + Y, "O" + Y].Font.Size = 8;
                            xlNewSheet11.Range["O" + Y, "O" + Y].Font.FontStyle = "Regular";//DeliveryMode

                            xlNewSheet11.Range["P" + Y, "P" + Y].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet11.Range["P" + Y, "P" + Y].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet11.Range["P" + Y, "P" + Y].Font.Name = "Calibri";
                            xlNewSheet11.Range["P" + Y, "P" + Y].Font.Size = 8;
                            xlNewSheet11.Range["P" + Y, "P" + Y].Font.FontStyle = "Regular";//DeliveryMode




                            R++;
                            Y++;
                        }
                        xlNewSheet11.Range["A1", "A1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        xlNewSheet11.Range["A1", "A1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet11.Range["A1", "A1"].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        xlNewSheet11.Range["A1", "A1"].Font.Bold = false;
                        xlNewSheet11.Range["A1", "A1"].Font.Name = "Calibri";
                        xlNewSheet11.Range["A1", "A1"].Font.Size = 8;
                        xlNewSheet11.Range["A1", "A1"].Font.FontStyle = "Regular";


                        xlNewSheet11.Range["B1", "B1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        xlNewSheet11.Range["B1", "B1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet11.Range["B1", "B1"].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        xlNewSheet11.Range["B1", "B1"].Font.Bold = false;
                        xlNewSheet11.Range["B1", "B1"].Font.Name = "Calibri";
                        xlNewSheet11.Range["B1", "B1"].Font.Size = 11;
                        xlNewSheet11.Range["B1", "B1"].Font.FontStyle = "Regular";

                        xlNewSheet11.Range["C1", "C1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        xlNewSheet11.Range["C1", "C1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet11.Range["C1", "C1"].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        xlNewSheet11.Range["C1", "C1"].Font.Bold = false;
                        xlNewSheet11.Range["C1", "C1"].Font.Name = "Calibri";
                        xlNewSheet11.Range["C1", "C1"].Font.Size = 11;
                        xlNewSheet11.Range["C1", "C1"].Font.FontStyle = "Regular";

                        xlNewSheet11.Range["D1", "D1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        xlNewSheet11.Range["D1", "D1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet11.Range["D1", "D1"].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        xlNewSheet11.Range["D1", "D1"].Font.Bold = false;
                        xlNewSheet11.Range["D1", "D1"].Font.Name = "Calibri";
                        xlNewSheet11.Range["D1", "D1"].Font.Size = 9;
                        xlNewSheet11.Range["D1", "D1"].Font.FontStyle = "Regular";

                        xlNewSheet11.Range["E1", "E1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        xlNewSheet11.Range["E1", "E1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet11.Range["E1", "E1"].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        xlNewSheet11.Range["E1", "E1"].Font.Bold = false;
                        xlNewSheet11.Range["E1", "E1"].Font.Name = "Calibri";
                        xlNewSheet11.Range["E1", "E1"].Font.Size = 9;
                        xlNewSheet11.Range["E1", "E1"].Font.FontStyle = "Regular";


                        xlNewSheet11.Range["F1", "F1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        xlNewSheet11.Range["F1", "F1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet11.Range["F1", "F1"].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        xlNewSheet11.Range["F1", "F1"].Font.Bold = false;
                        xlNewSheet11.Range["F1", "F1"].Font.Name = "Calibri";
                        xlNewSheet11.Range["F1", "F1"].Font.Size = 8;
                        xlNewSheet11.Range["F1", "F1"].Font.FontStyle = "Regular";


                        xlNewSheet11.Range["G1", "G1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        xlNewSheet11.Range["G1", "G1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet11.Range["G1", "G1"].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        xlNewSheet11.Range["G1", "G1"].Font.Bold = false;
                        xlNewSheet11.Range["G1", "G1"].Font.Name = "Calibri";
                        xlNewSheet11.Range["G1", "G1"].Font.Size = 8;
                        xlNewSheet11.Range["G1", "G1"].Font.FontStyle = "Regular";

                        xlNewSheet11.Range["H1", "H1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        xlNewSheet11.Range["H1", "H1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet11.Range["H1", "H1"].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        xlNewSheet11.Range["H1", "H1"].Font.Bold = false;
                        xlNewSheet11.Range["H1", "H1"].Font.Name = "Calibri";
                        xlNewSheet11.Range["H1", "H1"].Font.Size = 8;
                        xlNewSheet11.Range["H1", "H1"].Font.FontStyle = "Regular";


                        xlNewSheet11.Range["I1", "I1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        xlNewSheet11.Range["I1", "I1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet11.Range["I1", "I1"].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        xlNewSheet11.Range["I1", "I1"].Font.Bold = false;
                        xlNewSheet11.Range["I1", "I1"].Font.Name = "Calibri";
                        xlNewSheet11.Range["I1", "I1"].Font.Size = 8;
                        xlNewSheet11.Range["I1", "I1"].Font.FontStyle = "Regular";

                        xlNewSheet11.Range["J1", "J1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        xlNewSheet11.Range["J1", "J1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet11.Range["J1", "J1"].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        xlNewSheet11.Range["J1", "J1"].Font.Bold = false;
                        xlNewSheet11.Range["J1", "J1"].Font.Name = "Calibri";
                        xlNewSheet11.Range["J1", "J1"].Font.Size = 9;
                        xlNewSheet11.Range["J1", "J1"].Font.FontStyle = "Regular";

                        xlNewSheet11.Range["K1", "K1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        xlNewSheet11.Range["K1", "K1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet11.Range["K1", "K1"].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        xlNewSheet11.Range["K1", "K1"].Font.Bold = false;
                        xlNewSheet11.Range["K1", "K1"].Font.Name = "Calibri";
                        xlNewSheet11.Range["K1", "K1"].Font.Size = 9;
                        xlNewSheet11.Range["K1", "K1"].Font.FontStyle = "Regular";

                        xlNewSheet11.Range["L1", "L1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        xlNewSheet11.Range["L1", "L1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet11.Range["L1", "L1"].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        xlNewSheet11.Range["L1", "L1"].Font.Bold = false;
                        xlNewSheet11.Range["L1", "L1"].Font.Name = "Calibri";
                        xlNewSheet11.Range["L1", "L1"].Font.Size = 8;
                        xlNewSheet11.Range["L1", "L1"].Font.FontStyle = "Regular";

                        xlNewSheet11.Range["M1", "M1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        xlNewSheet11.Range["M1", "M1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet11.Range["M1", "M1"].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        xlNewSheet11.Range["M1", "M1"].Font.Bold = false;
                        xlNewSheet11.Range["M1", "M1"].Font.Name = "Calibri";
                        xlNewSheet11.Range["M1", "M1"].Font.Size = 8;
                        xlNewSheet11.Range["M1", "M1"].Font.FontStyle = "Regular";

                        xlNewSheet11.Range["N1", "N1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        xlNewSheet11.Range["N1", "N1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet11.Range["N1", "N1"].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        xlNewSheet11.Range["N1", "N1"].Font.Bold = false;
                        xlNewSheet11.Range["N1", "N1"].Font.Name = "Calibri";
                        xlNewSheet11.Range["N1", "N1"].Font.Size = 8;
                        xlNewSheet11.Range["N1", "N1"].Font.FontStyle = "Regular";


                        xlNewSheet11.Range["O1", "O1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        xlNewSheet11.Range["O1", "O1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet11.Range["O1", "O1"].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        xlNewSheet11.Range["O1", "O1"].Font.Bold = false;
                        xlNewSheet11.Range["O1", "O1"].Font.Name = "Calibri";
                        xlNewSheet11.Range["O1", "O1"].Font.Size = 8;
                        xlNewSheet11.Range["O1", "O1"].Font.FontStyle = "Regular";

                        xlNewSheet11.Range["P1", "P1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        xlNewSheet11.Range["P1", "P1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet11.Range["P1", "P1"].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        xlNewSheet11.Range["P1", "P1"].Font.Bold = false;
                        xlNewSheet11.Range["P1", "P1"].Font.Name = "Calibri";
                        xlNewSheet11.Range["P1", "P1"].Font.Size = 8;
                        xlNewSheet11.Range["P1", "P1"].Font.FontStyle = "Regular";


                        xlNewSheet11.Range["A1", "P1"].RowHeight = 32;
                        xlNewSheet11.Columns.AutoFit();
                        //xlNewSheet11.Range["O1"].Cells.EntireColumn.NumberFormat = "d mmm (ddd);@";
                        xlNewSheet11.Range["M1"].Cells.EntireColumn.NumberFormat = "d mmm (ddd);@";
                        xlNewSheet11.Range["O1"].Cells.EntireColumn.NumberFormat = "d mmm (ddd);@";


                        //xlNewSheet11.Range["A1", "T1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        //xlNewSheet11.Range["A1", "T1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        //xlNewSheet11.Range["A1", "T1"].Font.Bold = true;

                        //xlNewSheet11.Range["A1", "T1"].Font.Name = "Calibri";
                        //xlNewSheet11.Range["A1", "T1"].Font.Size = 6;



                        releaseObject(xlNewSheet11);
                        ((Excel.Worksheet)xlApp.ActiveWorkbook.Sheets[1]).Activate();

                    }

                }
                if (ReportType == "Finished_WIP")
                {
                    // iKandi.Common.Constants.WorkSheetCount_ForExcel = iKandi.Common.Constants.WorkSheetCount_ForExcel + 1;
                    // iKandi.Common.Constants.WorkSheetCount_ForExcel = iKandi.Common.Constants.WorkSheetCount_ForExcel + 1;
                    GlobalCount_WIP = GlobalCount_WIP + 1;
                    var xlNewSheet11 = (Excel.Worksheet)worksheets.Add(worksheets[GlobalCount_WIP], Type.Missing, Type.Missing, Type.Missing);
                    CultureInfo ci = new CultureInfo("en-IN");
                    ci.NumberFormat.CurrencySymbol = "₹";




                    xlNewSheet11.Name = "Finished_WIP";
                    xlNewSheet11.Cells[1, 1] = "Department Name";
                    xlNewSheet11.Cells[1, 2] = "Serial number";
                    xlNewSheet11.Cells[1, 3] = "Style number";
                    xlNewSheet11.Cells[1, 4] = "Line Number";
                    xlNewSheet11.Cells[1, 5] = "ContractNumber";
                    xlNewSheet11.Cells[1, 6] = "Fabric1";
                    xlNewSheet11.Cells[1, 7] = "Colour/Print";
                    xlNewSheet11.Cells[1, 8] = "Order Qty";
                    xlNewSheet11.Cells[1, 9] = "CutQty";
                    xlNewSheet11.Cells[1, 10] = "CutReady Qty";
                    xlNewSheet11.Cells[1, 11] = "Stitched Qty";
                    xlNewSheet11.Cells[1, 12] = "Finished Qty";
                    xlNewSheet11.Cells[1, 13] = "WIP";
                    xlNewSheet11.Cells[1, 14] = "ExFactory";
                    xlNewSheet11.Cells[1, 15] = "Line Plan Status";
                    xlNewSheet11.Cells[1, 16] = "Start Date";
                    xlNewSheet11.Cells[1, 17] = "Planned Status";





                    if (ds.Tables[0].Rows.Count == 0)
                    {
                        return false;
                    }
                    else if (ds.Tables[0].Rows.Count > 0)
                    {
                        int R = 1;
                        int Y = 2;
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {



                            xlNewSheet11.Cells[R + 1, 1] = dr["DepartmentName"] == DBNull.Value ? string.Empty : Convert.ToString(dr["DepartmentName"]);
                            xlNewSheet11.Cells[R + 1, 2] = dr["Serialnumber"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Serialnumber"]);
                            xlNewSheet11.Cells[R + 1, 3] = dr["Stylenumber"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Stylenumber"]);
                            xlNewSheet11.Cells[R + 1, 4] = dr["LineItemNumber"] == DBNull.Value ? string.Empty : Convert.ToString(dr["LineItemNumber"]);
                            xlNewSheet11.Cells[R + 1, 5] = dr["ContractNumber"] == DBNull.Value ? string.Empty : Convert.ToString(dr["ContractNumber"]);
                            xlNewSheet11.Cells[R + 1, 6] = dr["Fabric1"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Fabric1"]);
                            xlNewSheet11.Cells[R + 1, 7] = dr["Fabric1Details"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Fabric1Details"]);
                            xlNewSheet11.Cells[R + 1, 8] = dr["Quantity"] == DBNull.Value ? string.Empty : Convert.ToString(Convert.ToInt32(dr["Quantity"]).ToString("N0"));
                            xlNewSheet11.Cells[R + 1, 9] = dr["CutQty"] == DBNull.Value || dr["CutQty"].ToString() == "0" ? string.Empty : Convert.ToString(Convert.ToInt32(dr["CutQty"]).ToString("N0"));
                            xlNewSheet11.Cells[R + 1, 10] = dr["CutReadyQuantity"] == DBNull.Value || dr["CutReadyQuantity"].ToString() == "0" ? string.Empty : Convert.ToString(Convert.ToInt32(dr["CutReadyQuantity"]).ToString("N0"));
                            xlNewSheet11.Cells[R + 1, 11] = dr["StichedQty"].ToString() == "" ? string.Empty : Convert.ToString(Convert.ToInt32(dr["StichedQty"]).ToString("N0"));
                            xlNewSheet11.Cells[R + 1, 12] = dr["finishedQty"].ToString() == "" ? string.Empty : Convert.ToString(Convert.ToInt32(dr["finishedQty"]).ToString("N0"));
                            xlNewSheet11.Cells[R + 1, 13] = dr["WIP"].ToString() == "" ? string.Empty : Convert.ToString(Convert.ToInt32(dr["WIP"]).ToString("N0"));
                            xlNewSheet11.Cells[R + 1, 14] = (dr["ExFactory"] == DBNull.Value || Convert.ToString(dr["ExFactory"]) == "") ? string.Empty : dr["ExFactory"];
                            xlNewSheet11.Cells[R + 1, 15] = dr["LinePlan"] == DBNull.Value ? string.Empty : Convert.ToString(dr["LinePlan"]);
                            xlNewSheet11.Cells[R + 1, 16] = (dr["PlanDate"] == DBNull.Value || Convert.ToString(dr["PlanDate"]) == "") ? string.Empty : dr["PlanDate"];
                            xlNewSheet11.Cells[R + 1, 17] = dr["PlannedStatus"] == DBNull.Value ? string.Empty : Convert.ToString(dr["PlannedStatus"]); ;







                            //xlNewSheet11.Cells[R + 1, 19] = dr["Fabric4Details"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Fabric4Details"]);

                            xlNewSheet11.Range["A1", "A1"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;

                            xlNewSheet11.Range["B1", "B1"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["C1", "C1"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["D1", "D1"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["E1", "E1"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["F1", "F1"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["G1", "G1"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["H1", "H1"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["I1", "I1"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["J1", "J1"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["K1", "K1"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["L1", "L1"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["M1", "M1"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["N1", "N1"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["O1", "O1"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["P1", "P1"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["Q1", "Q1"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;

                            xlNewSheet11.Range["A" + Y, "A" + Y].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["B" + Y, "B" + Y].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["C" + Y, "C" + Y].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["D" + Y, "D" + Y].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["E" + Y, "E" + Y].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["F" + Y, "F" + Y].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["G" + Y, "G" + Y].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["H" + Y, "H" + Y].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["I" + Y, "I" + Y].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["J" + Y, "J" + Y].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["K" + Y, "K" + Y].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["L" + Y, "L" + Y].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["M" + Y, "M" + Y].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["N" + Y, "N" + Y].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["O" + Y, "O" + Y].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["P" + Y, "P" + Y].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["Q" + Y, "Q" + Y].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;




                            xlNewSheet11.Range["A" + Y, "A" + Y].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet11.Range["A" + Y, "A" + Y].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet11.Range["A" + Y, "A" + Y].Font.Name = "Calibri";
                            xlNewSheet11.Range["A" + Y, "A" + Y].Font.Size = 8;
                            xlNewSheet11.Range["A" + Y, "A" + Y].Font.FontStyle = "Regular";//Department Name

                            xlNewSheet11.Range["B" + Y, "B" + Y].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet11.Range["B" + Y, "B" + Y].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet11.Range["B" + Y, "B" + Y].Font.Name = "Calibri";
                            xlNewSheet11.Range["B" + Y, "B" + Y].Font.Size = 11;
                            xlNewSheet11.Range["B" + Y, "B" + Y].Font.FontStyle = "Bold";//Serial number

                            xlNewSheet11.Range["C" + Y, "C" + Y].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet11.Range["C" + Y, "C" + Y].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet11.Range["C" + Y, "C" + Y].Font.Name = "Calibri";
                            xlNewSheet11.Range["C" + Y, "C" + Y].Font.Size = 11;
                            xlNewSheet11.Range["C" + Y, "C" + Y].Font.FontStyle = "Regular";//Style number


                            xlNewSheet11.Range["D" + Y, "D" + Y].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet11.Range["D" + Y, "D" + Y].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet11.Range["D" + Y, "D" + Y].Font.Name = "Calibri";
                            xlNewSheet11.Range["D" + Y, "D" + Y].Font.Size = 9;
                            xlNewSheet11.Range["D" + Y, "D" + Y].Font.FontStyle = "Regular";//Line Number


                            xlNewSheet11.Range["E" + Y, "E" + Y].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet11.Range["E" + Y, "E" + Y].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet11.Range["E" + Y, "E" + Y].Font.Name = "Calibri";
                            xlNewSheet11.Range["E" + Y, "E" + Y].Font.Size = 9;
                            xlNewSheet11.Range["E" + Y, "E" + Y].Font.FontStyle = "Regular";//ContractNumber

                            xlNewSheet11.Range["F" + Y, "F" + Y].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet11.Range["F" + Y, "F" + Y].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet11.Range["F" + Y, "F" + Y].Font.Name = "Calibri";
                            xlNewSheet11.Range["F" + Y, "F" + Y].Font.Size = 8;
                            xlNewSheet11.Range["F" + Y, "F" + Y].Font.FontStyle = "Regular";//Fabric1

                            xlNewSheet11.Range["G" + Y, "G" + Y].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet11.Range["G" + Y, "G" + Y].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet11.Range["G" + Y, "G" + Y].Font.Name = "Calibri";
                            xlNewSheet11.Range["G" + Y, "G" + Y].Font.Size = 8;
                            xlNewSheet11.Range["G" + Y, "G" + Y].Font.FontStyle = "Regular";//Colour/Print

                            xlNewSheet11.Range["H" + Y, "H" + Y].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet11.Range["H" + Y, "H" + Y].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet11.Range["H" + Y, "H" + Y].Font.Name = "Calibri";
                            xlNewSheet11.Range["H" + Y, "H" + Y].Font.Size = 8;
                            xlNewSheet11.Range["H" + Y, "H" + Y].Font.FontStyle = "Regular";//Weight 
                            xlNewSheet11.Range["H" + Y, "H" + Y].Font.FontStyle = "Bold";//Serial number


                            xlNewSheet11.Range["I" + Y, "I" + Y].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet11.Range["I" + Y, "I" + Y].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet11.Range["I" + Y, "I" + Y].Font.Name = "Calibri";
                            xlNewSheet11.Range["I" + Y, "I" + Y].Font.Size = 8;
                            xlNewSheet11.Range["I" + Y, "I" + Y].Font.FontStyle = "Regular";//Quantity

                            xlNewSheet11.Range["J" + Y, "J" + Y].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet11.Range["J" + Y, "J" + Y].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet11.Range["J" + Y, "J" + Y].Font.Name = "Calibri";
                            xlNewSheet11.Range["J" + Y, "J" + Y].Font.Size = 8;
                            xlNewSheet11.Range["J" + Y, "J" + Y].Font.FontStyle = "Regular";//PcsStitche

                            xlNewSheet11.Range["K" + Y, "K" + Y].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet11.Range["K" + Y, "K" + Y].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet11.Range["K" + Y, "K" + Y].Font.Name = "Calibri";
                            xlNewSheet11.Range["K" + Y, "K" + Y].Font.Size = 8;
                            xlNewSheet11.Range["K" + Y, "K" + Y].Font.FontStyle = "Regular";//PcsStitche

                            xlNewSheet11.Range["L" + Y, "L" + Y].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet11.Range["L" + Y, "L" + Y].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet11.Range["L" + Y, "L" + Y].Font.Name = "Calibri";
                            xlNewSheet11.Range["L" + Y, "L" + Y].Font.Size = 8;
                            xlNewSheet11.Range["L" + Y, "L" + Y].Font.FontStyle = "Regular";//Value in

                            xlNewSheet11.Range["M" + Y, "M" + Y].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet11.Range["M" + Y, "M" + Y].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet11.Range["M" + Y, "M" + Y].Font.Name = "Calibri";
                            xlNewSheet11.Range["M" + Y, "M" + Y].Font.Size = 8;
                            xlNewSheet11.Range["M" + Y, "M" + Y].Font.FontStyle = "Regular";//TOP Status

                            xlNewSheet11.Range["N" + Y, "N" + Y].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet11.Range["N" + Y, "N" + Y].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet11.Range["N" + Y, "N" + Y].Font.Name = "Calibri";
                            xlNewSheet11.Range["N" + Y, "N" + Y].Font.Size = 8;
                            xlNewSheet11.Range["N" + Y, "N" + Y].Font.FontStyle = "Regular";//MDA

                            xlNewSheet11.Range["O" + Y, "O" + Y].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet11.Range["O" + Y, "O" + Y].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet11.Range["O" + Y, "O" + Y].Font.Name = "Calibri";
                            xlNewSheet11.Range["O" + Y, "O" + Y].Font.Size = 8;
                            xlNewSheet11.Range["O" + Y, "O" + Y].Font.FontStyle = "Regular";//DeliveryMode

                            xlNewSheet11.Range["P" + Y, "P" + Y].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet11.Range["P" + Y, "P" + Y].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet11.Range["P" + Y, "P" + Y].Font.Name = "Calibri";
                            xlNewSheet11.Range["P" + Y, "P" + Y].Font.Size = 8;
                            xlNewSheet11.Range["P" + Y, "P" + Y].Font.FontStyle = "Regular";//DeliveryMode

                            xlNewSheet11.Range["Q" + Y, "Q" + Y].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet11.Range["Q" + Y, "Q" + Y].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet11.Range["Q" + Y, "Q" + Y].Font.Name = "Calibri";
                            xlNewSheet11.Range["Q" + Y, "Q" + Y].Font.Size = 8;
                            xlNewSheet11.Range["Q" + Y, "Q" + Y].Font.FontStyle = "Regular";//DeliveryMode



                            R++;
                            Y++;
                        }
                        xlNewSheet11.Range["A1", "A1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        xlNewSheet11.Range["A1", "A1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet11.Range["A1", "A1"].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        xlNewSheet11.Range["A1", "A1"].Font.Bold = false;
                        xlNewSheet11.Range["A1", "A1"].Font.Name = "Calibri";
                        xlNewSheet11.Range["A1", "A1"].Font.Size = 8;
                        xlNewSheet11.Range["A1", "A1"].Font.FontStyle = "Regular";


                        xlNewSheet11.Range["B1", "B1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        xlNewSheet11.Range["B1", "B1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet11.Range["B1", "B1"].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        xlNewSheet11.Range["B1", "B1"].Font.Bold = false;
                        xlNewSheet11.Range["B1", "B1"].Font.Name = "Calibri";
                        xlNewSheet11.Range["B1", "B1"].Font.Size = 11;
                        xlNewSheet11.Range["B1", "B1"].Font.FontStyle = "Regular";

                        xlNewSheet11.Range["C1", "C1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        xlNewSheet11.Range["C1", "C1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet11.Range["C1", "C1"].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        xlNewSheet11.Range["C1", "C1"].Font.Bold = false;
                        xlNewSheet11.Range["C1", "C1"].Font.Name = "Calibri";
                        xlNewSheet11.Range["C1", "C1"].Font.Size = 11;
                        xlNewSheet11.Range["C1", "C1"].Font.FontStyle = "Regular";

                        xlNewSheet11.Range["D1", "D1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        xlNewSheet11.Range["D1", "D1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet11.Range["D1", "D1"].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        xlNewSheet11.Range["D1", "D1"].Font.Bold = false;
                        xlNewSheet11.Range["D1", "D1"].Font.Name = "Calibri";
                        xlNewSheet11.Range["D1", "D1"].Font.Size = 9;
                        xlNewSheet11.Range["D1", "D1"].Font.FontStyle = "Regular";

                        xlNewSheet11.Range["E1", "E1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        xlNewSheet11.Range["E1", "E1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet11.Range["E1", "E1"].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        xlNewSheet11.Range["E1", "E1"].Font.Bold = false;
                        xlNewSheet11.Range["E1", "E1"].Font.Name = "Calibri";
                        xlNewSheet11.Range["E1", "E1"].Font.Size = 9;
                        xlNewSheet11.Range["E1", "E1"].Font.FontStyle = "Regular";


                        xlNewSheet11.Range["F1", "F1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        xlNewSheet11.Range["F1", "F1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet11.Range["F1", "F1"].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        xlNewSheet11.Range["F1", "F1"].Font.Bold = false;
                        xlNewSheet11.Range["F1", "F1"].Font.Name = "Calibri";
                        xlNewSheet11.Range["F1", "F1"].Font.Size = 8;
                        xlNewSheet11.Range["F1", "F1"].Font.FontStyle = "Regular";


                        xlNewSheet11.Range["G1", "G1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        xlNewSheet11.Range["G1", "G1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet11.Range["G1", "G1"].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        xlNewSheet11.Range["G1", "G1"].Font.Bold = false;
                        xlNewSheet11.Range["G1", "G1"].Font.Name = "Calibri";
                        xlNewSheet11.Range["G1", "G1"].Font.Size = 8;
                        xlNewSheet11.Range["G1", "G1"].Font.FontStyle = "Regular";

                        xlNewSheet11.Range["H1", "H1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        xlNewSheet11.Range["H1", "H1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet11.Range["H1", "H1"].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        xlNewSheet11.Range["H1", "H1"].Font.Bold = false;
                        xlNewSheet11.Range["H1", "H1"].Font.Name = "Calibri";
                        xlNewSheet11.Range["H1", "H1"].Font.Size = 8;
                        xlNewSheet11.Range["H1", "H1"].Font.FontStyle = "Regular";


                        xlNewSheet11.Range["I1", "I1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        xlNewSheet11.Range["I1", "I1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet11.Range["I1", "I1"].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        xlNewSheet11.Range["I1", "I1"].Font.Bold = false;
                        xlNewSheet11.Range["I1", "I1"].Font.Name = "Calibri";
                        xlNewSheet11.Range["I1", "I1"].Font.Size = 8;
                        xlNewSheet11.Range["I1", "I1"].Font.FontStyle = "Regular";

                        xlNewSheet11.Range["J1", "J1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        xlNewSheet11.Range["J1", "J1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet11.Range["J1", "J1"].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        xlNewSheet11.Range["J1", "J1"].Font.Bold = false;
                        xlNewSheet11.Range["J1", "J1"].Font.Name = "Calibri";
                        xlNewSheet11.Range["J1", "J1"].Font.Size = 8;
                        xlNewSheet11.Range["J1", "J1"].Font.FontStyle = "Regular";

                        xlNewSheet11.Range["K1", "K1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        xlNewSheet11.Range["K1", "K1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet11.Range["K1", "K1"].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        xlNewSheet11.Range["K1", "K1"].Font.Bold = false;
                        xlNewSheet11.Range["K1", "K1"].Font.Name = "Calibri";
                        xlNewSheet11.Range["K1", "K1"].Font.Size = 8;
                        xlNewSheet11.Range["K1", "K1"].Font.FontStyle = "Regular";

                        xlNewSheet11.Range["L1", "L1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        xlNewSheet11.Range["L1", "L1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet11.Range["L1", "L1"].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        xlNewSheet11.Range["L1", "L1"].Font.Bold = false;
                        xlNewSheet11.Range["L1", "L1"].Font.Name = "Calibri";
                        xlNewSheet11.Range["L1", "L1"].Font.Size = 8;
                        xlNewSheet11.Range["L1", "L1"].Font.FontStyle = "Regular";

                        xlNewSheet11.Range["M1", "M1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        xlNewSheet11.Range["M1", "M1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet11.Range["M1", "M1"].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        xlNewSheet11.Range["M1", "M1"].Font.Bold = false;
                        xlNewSheet11.Range["M1", "M1"].Font.Name = "Calibri";
                        xlNewSheet11.Range["M1", "M1"].Font.Size = 8;
                        xlNewSheet11.Range["M1", "M1"].Font.FontStyle = "Regular";

                        xlNewSheet11.Range["N1", "N1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        xlNewSheet11.Range["N1", "N1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet11.Range["N1", "N1"].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        xlNewSheet11.Range["N1", "N1"].Font.Bold = false;
                        xlNewSheet11.Range["N1", "N1"].Font.Name = "Calibri";
                        xlNewSheet11.Range["N1", "N1"].Font.Size = 8;
                        xlNewSheet11.Range["N1", "N1"].Font.FontStyle = "Regular";


                        xlNewSheet11.Range["O1", "O1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        xlNewSheet11.Range["O1", "O1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet11.Range["O1", "O1"].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        xlNewSheet11.Range["O1", "O1"].Font.Bold = false;
                        xlNewSheet11.Range["O1", "O1"].Font.Name = "Calibri";
                        xlNewSheet11.Range["O1", "O1"].Font.Size = 8;
                        xlNewSheet11.Range["O1", "O1"].Font.FontStyle = "Regular";

                        xlNewSheet11.Range["P1", "P1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        xlNewSheet11.Range["P1", "P1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet11.Range["P1", "P1"].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        xlNewSheet11.Range["P1", "P1"].Font.Bold = false;
                        xlNewSheet11.Range["P1", "P1"].Font.Name = "Calibri";
                        xlNewSheet11.Range["P1", "P1"].Font.Size = 8;
                        xlNewSheet11.Range["P1", "P1"].Font.FontStyle = "Regular";

                        xlNewSheet11.Range["Q1", "Q1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        xlNewSheet11.Range["Q1", "Q1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet11.Range["Q1", "Q1"].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        xlNewSheet11.Range["Q1", "Q1"].Font.Bold = false;
                        xlNewSheet11.Range["Q1", "Q1"].Font.Name = "Calibri";
                        xlNewSheet11.Range["Q1", "Q1"].Font.Size = 8;
                        xlNewSheet11.Range["Q1", "Q1"].Font.FontStyle = "Regular";

                        xlNewSheet11.Range["A1", "Q1"].RowHeight = 32;
                        xlNewSheet11.Columns.AutoFit();
                        //xlNewSheet11.Range["O1"].Cells.EntireColumn.NumberFormat = "d mmm (ddd);@";
                        xlNewSheet11.Range["N1"].Cells.EntireColumn.NumberFormat = "d mmm (ddd);@";
                        xlNewSheet11.Range["P1"].Cells.EntireColumn.NumberFormat = "d mmm (ddd);@";


                        //xlNewSheet11.Range["A1", "T1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        //xlNewSheet11.Range["A1", "T1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        //xlNewSheet11.Range["A1", "T1"].Font.Bold = true;

                        //xlNewSheet11.Range["A1", "T1"].Font.Name = "Calibri";
                        //xlNewSheet11.Range["A1", "T1"].Font.Size = 6;



                        releaseObject(xlNewSheet11);
                        ((Excel.Worksheet)xlApp.ActiveWorkbook.Sheets[1]).Activate();


                    }
                }


                if (ReportType == "Rescan")
                {
                    // iKandi.Common.Constants.WorkSheetCount_ForExcel = iKandi.Common.Constants.WorkSheetCount_ForExcel + 1;
                    GlobalType_Rescan = GlobalType_Rescan + 1;
                    var xlNewSheet11 = (Excel.Worksheet)worksheets.Add(worksheets[GlobalType_Rescan], Type.Missing, Type.Missing, Type.Missing);

                    int colcount = 0;
                    int column = 6;
                    int column1 = 6;
                    char c1 = 'G';
                    char c2 = 'A';

                    string strchar = "";

                    xlNewSheet11.Name = "Rescan";
                    xlNewSheet11.Cells[1, 1] = "Serial number";
                    xlNewSheet11.Cells[1, 2] = "Style number";
                    xlNewSheet11.Cells[1, 3] = "Line Number";
                    xlNewSheet11.Cells[1, 4] = "ContractNumber";
                    xlNewSheet11.Cells[1, 5] = "Fabric1";
                    xlNewSheet11.Cells[1, 6] = "Colour/Print";

                    for (int i = 0; i < ds.Tables[0].Columns.Count; i++)
                    {
                        if (ds.Tables[0].Columns[i].ColumnName.ToString() == "RescanDone1")
                        {
                            colcount = 0;
                        }

                        if (ds.Tables[0].Columns[i].ColumnName.ToString() == "RescanPending1")
                        {
                            break;
                        }
                        colcount++;
                    }
                    int col2 = 7;
                    int col3 = 8;
                    for (int i = 1; i <= colcount; i++)
                    {
                        xlNewSheet11.Cells[1, col2] = "Rescan C" + i + Environment.NewLine + "Done (Pendg) Qty" + Environment.NewLine + "Date";
                        xlNewSheet11.Cells[1, col3] = "Rescan C" + i + Environment.NewLine + "Fault" + Environment.NewLine + "Details";
                        if (i < 10)
                        {
                            if (i == 1 || i == 3 || i == 5 || i == 7 || i == 9)
                            {
                                xlNewSheet11.Cells.Characters[12, 4].Font.Bold = true;
                                xlNewSheet11.Cells.Characters[17, 7].Font.Color = ColorTranslator.ToOle(System.Drawing.Color.Red);
                            }
                            else
                            {
                                xlNewSheet11.Cells.Characters[12, 4].Font.Bold = false;
                                xlNewSheet11.Cells.Characters[17, 7].Font.Color = ColorTranslator.ToOle(System.Drawing.Color.Black);
                            }
                        }
                        else
                        {
                            if (i == 11 || i == 13 || i == 15)
                            {
                                xlNewSheet11.Cells.Characters[13, 4].Font.Bold = true;
                                xlNewSheet11.Cells.Characters[18, 7].Font.Color = ColorTranslator.ToOle(System.Drawing.Color.Red);
                            }
                            else
                            {
                                xlNewSheet11.Cells.Characters[13, 4].Font.Bold = false;
                                xlNewSheet11.Cells.Characters[18, 7].Font.Color = ColorTranslator.ToOle(System.Drawing.Color.Black);
                            }
                        }

                        column++;
                        column1 = column1 + 2;
                        if (c1 == 'Z')
                        {
                            c2++;
                            c2++;
                            strchar = strchar + "A" + c2.ToString() + ",";
                        }
                        else
                        {
                            c1++;
                            strchar = strchar + c1.ToString() + ",";
                            if (c1 == 'Z')
                            {
                                c2++;
                                strchar = strchar + "A" + c2.ToString() + ",";
                            }
                            else
                            {
                                c1++;
                            }
                        }
                        col2 = col2 + 2;
                        col3 = col3 + 2;
                    }
                    c1++;
                    xlNewSheet11.Cells[1, column1 + 1] = "ExFactory";
                    xlNewSheet11.Cells[1, column1 + 2] = "DC";
                    if (ds.Tables[0].Rows.Count == 0)
                    {
                        return false;
                    }
                    else if (ds.Tables[0].Rows.Count > 0)
                    {
                        int R = 1;
                        int F = 1;
                        int E = 1;
                        int Y = 1;
                        int o = 6;
                        int prevx = 7;
                        int nextx = 8;
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            o = 6;
                            F = 1;
                            E = 1;
                            prevx = 7;
                            nextx = 8;
                            xlNewSheet11.Cells[R + 1, 1] = ds.Tables[0].Rows[i]["SerialNumber"] == DBNull.Value ? string.Empty : Convert.ToString(ds.Tables[0].Rows[i]["SerialNumber"]);
                            xlNewSheet11.Cells[R + 1, 2] = ds.Tables[0].Rows[i]["StyleNumber"] == DBNull.Value ? string.Empty : Convert.ToString(ds.Tables[0].Rows[i]["StyleNumber"]);
                            xlNewSheet11.Cells[R + 1, 3] = ds.Tables[0].Rows[i]["LineItemNumber"] == DBNull.Value ? string.Empty : Convert.ToString(ds.Tables[0].Rows[i]["LineItemNumber"]);
                            xlNewSheet11.Cells[R + 1, 4] = ds.Tables[0].Rows[i]["ContractNumber"] == DBNull.Value ? string.Empty : Convert.ToString(ds.Tables[0].Rows[i]["ContractNumber"]);
                            xlNewSheet11.Cells[R + 1, 5] = ds.Tables[0].Rows[i]["Fabric1"] == DBNull.Value ? string.Empty : Convert.ToString(ds.Tables[0].Rows[i]["Fabric1"]);
                            xlNewSheet11.Cells[R + 1, 6] = ds.Tables[0].Rows[i]["Fabric1Details"] == DBNull.Value ? string.Empty : Convert.ToString(ds.Tables[0].Rows[i]["Fabric1Details"]);

                            for (int x = 7; x <= column; x++)
                            {
                                if (ds.Tables[0].Rows[i]["RescanDone" + F] == DBNull.Value && ds.Tables[0].Rows[i]["RescanPending" + F] == DBNull.Value)
                                {
                                    xlNewSheet11.Cells[R + 1, prevx] = "";
                                }
                                else
                                {    // Added Code By Bharat On 20-12-19
                                    string RescanDonevalue = (ds.Tables[0].Rows[i]["RescanDone" + F] == DBNull.Value ? string.Empty : Convert.ToInt32(ds.Tables[0].Rows[i]["RescanDone" + F]).ToString("N0")) + " (" + (ds.Tables[0].Rows[i]["RescanPending" + F] == DBNull.Value ? string.Empty : Convert.ToInt32(ds.Tables[0].Rows[i]["RescanPending" + F]).ToString("N0")) + ")" + Environment.NewLine + (ds.Tables[0].Rows[i]["MarkRescanDate" + F] == DBNull.Value ? string.Empty : ds.Tables[0].Rows[i]["MarkRescanDate" + F].ToString());

                                    int startindex = RescanDonevalue.IndexOf('(');
                                    int Endindex = RescanDonevalue.IndexOf(')');
                                    int comp = Endindex - startindex;
                                    if (comp == 1)
                                    {

                                        StringBuilder sb = new StringBuilder(RescanDonevalue);
                                        sb.Remove(startindex, 1);
                                        sb.Remove(startindex, 1);
                                        RescanDonevalue = sb.ToString();
                                    }
                                    xlNewSheet11.Cells[R + 1, prevx] = RescanDonevalue;
                                    Excel.Range ColorMeMine = xlNewSheet11.Cells[R + 1, prevx] as Excel.Range;
                                    if (startindex != 1)
                                    {
                                        ColorMeMine.Characters[0, startindex - 1].Font.Color = ColorTranslator.ToOle(System.Drawing.Color.Blue);
                                        ColorMeMine.Characters[0, startindex - 1].Font.Bold = true;
                                    }
                                    ColorMeMine.Characters[startindex, (Endindex - startindex + 2)].Font.Color = ColorTranslator.ToOle(System.Drawing.Color.Red);

                                }
                                F++;
                                if (ds.Tables[0].Rows[i]["RescanFaults" + E] == DBNull.Value && ds.Tables[0].Rows[i]["RescanFaults" + E] == DBNull.Value)
                                {
                                    xlNewSheet11.Cells[R + 1, nextx] = "";
                                }
                                else
                                {
                                    string RescanFaultsComment = (ds.Tables[0].Rows[i]["RescanFaults" + E] == DBNull.Value ? string.Empty : ds.Tables[0].Rows[i]["RescanFaults" + E].ToString());
                                    string[] Splitcomment = RescanFaultsComment.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                                    string results = "";
                                    System.Data.DataTable dtCommentIndex = new System.Data.DataTable();

                                    dtCommentIndex.Columns.Add("startindex", typeof(string));
                                    dtCommentIndex.Columns.Add("Endindex", typeof(string));
                                    foreach (string str in Splitcomment)
                                    {
                                        int lenResult = results.Length;
                                        results = results + str + "\r\n";
                                        int startindex = str.LastIndexOf('(');
                                        int Endindex = str.LastIndexOf(')');
                                        xlNewSheet11.Cells[R + 1, nextx] = results + "\r\n";
                                        DataRow dr = dtCommentIndex.NewRow();
                                        dr["startindex"] = lenResult + startindex + 1;
                                        dr["Endindex"] = (Endindex - startindex + 2);

                                        dtCommentIndex.Rows.Add(dr);
                                    }
                                    dtCommentIndex.AcceptChanges();
                                    Excel.Range ColorMeMine23 = xlNewSheet11.Cells[R + 1, nextx] as Excel.Range;
                                    for (int b = 0; b < dtCommentIndex.Rows.Count; b++)
                                    {
                                        int a = Convert.ToInt32(dtCommentIndex.Rows[b][0].ToString());
                                        int n = Convert.ToInt32(dtCommentIndex.Rows[b][1].ToString());

                                        ColorMeMine23.Characters[a, n].Font.Color = ColorTranslator.ToOle(System.Drawing.Color.Red);
                                    }
                                }
                                E++;

                                o = o + 2;
                                prevx = prevx + 2;
                                nextx = nextx + 2;
                            }
                            xlNewSheet11.Cells[R + 1, o + 1] = ds.Tables[0].Rows[i]["ExFactory"] == DBNull.Value ? string.Empty : Convert.ToString(ds.Tables[0].Rows[i]["ExFactory"]);
                            xlNewSheet11.Cells[R + 1, o + 2] = ds.Tables[0].Rows[i]["DC"] == DBNull.Value ? string.Empty : Convert.ToString(ds.Tables[0].Rows[i]["DC"]);
                            Y++;
                            R++;
                        }

                        if (c2 == 'A')
                        {
                            xlNewSheet11.Range["A1", c1 + "1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                            xlNewSheet11.Range["A1", c1 + "1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet11.Range["A1", c1 + "1"].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet11.Range["A1", c1 + "1"].Cells.ColumnWidth = 16;
                            xlNewSheet11.Range["A1", c1 + "1"].EntireRow.RowHeight = 50;
                            xlNewSheet11.get_Range("A1:" + c1 + +Y).Cells.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.get_Range("A1:" + c1 + +Y).Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet11.get_Range("A1:" + c1 + +Y).Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        }
                        else
                        {
                            xlNewSheet11.Range["A1", "A" + c2 + "1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                            xlNewSheet11.Range["A1", "A" + c2 + "1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet11.Range["A1", "A" + c2 + "1"].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet11.Range["A1", "A" + c2 + "1"].Cells.ColumnWidth = 16;
                            xlNewSheet11.Range["A1", "A" + c2 + "1"].EntireRow.RowHeight = 50;
                            xlNewSheet11.get_Range("A1:" + "A" + c2 + +Y).Cells.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.get_Range("A1:" + "A" + c2 + +Y).Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet11.get_Range("A1:" + "A" + c2 + +Y).Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        }


                        xlNewSheet11.Range["B1"].Cells.EntireColumn.Font.Bold = true;
                        xlNewSheet11.Range["B1"].Cells.Font.Bold = false;

                        string[] Collection23 = strchar.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);

                        for (int n = 0; n < Collection23.Length - 1; n++)
                        {
                            string a = Collection23[n];
                            xlNewSheet11.Range[a + "1"].Cells.EntireColumn.Font.Bold = false;
                            xlNewSheet11.Range[a + "1"].Cells.Font.Color = ColorTranslator.ToOle(System.Drawing.Color.Black);
                            xlNewSheet11.Range[a + "1"].Cells.ColumnWidth = 50;
                            xlNewSheet11.get_Range(a + "1:" + a + Y).Cells.EntireColumn.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                            xlNewSheet11.Range[a + "1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        }


                        if (c2 == 'A')
                        {

                            xlNewSheet11.Range[c1 + "1"].Cells.EntireColumn.NumberFormat = "d mmm (ddd);@";
                            c1--;
                            xlNewSheet11.Range[c1 + "1"].Cells.EntireColumn.NumberFormat = "d mmm (ddd);@";
                        }
                        else
                        {
                            xlNewSheet11.Range["A" + c2 + "1"].Cells.EntireColumn.NumberFormat = "d mmm (ddd);@";
                            c2--;
                            xlNewSheet11.Range["A" + c2 + "1"].Cells.EntireColumn.NumberFormat = "d mmm (ddd);@";
                        }
                        xlNewSheet11.Range["E1"].Cells.EntireColumn.ColumnWidth = 40;
                        xlNewSheet11.Range["F1"].Cells.EntireColumn.ColumnWidth = 25;

                        //foreach (DataRow dr in ds.Tables[0].Rows)
                        //{


                        //    xlNewSheet11.Cells[R + 1, 1] = dr["SerialNumber"] == DBNull.Value ? string.Empty : Convert.ToString(dr["SerialNumber"]);
                        //    xlNewSheet11.Cells[R + 1, 2] = dr["StyleNumber"] == DBNull.Value ? string.Empty : Convert.ToString(dr["StyleNumber"]);
                        //    xlNewSheet11.Cells[R + 1, 3] = dr["LineItemNumber"] == DBNull.Value ? string.Empty : Convert.ToString(dr["LineItemNumber"]);
                        //    xlNewSheet11.Cells[R + 1, 4] = dr["ContractNumber"] == DBNull.Value ? string.Empty : Convert.ToString(dr["ContractNumber"]);
                        //    xlNewSheet11.Cells[R + 1, 5] = dr["Fabric1"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Fabric1"]);
                        //    xlNewSheet11.Cells[R + 1, 6] = dr["Fabric1Details"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Fabric1Details"]);
                        //    xlNewSheet11.Cells[R + 1, 7] = (dr["Rescan_Date"] == DBNull.Value || Convert.ToString(dr["Rescan_Date"]) == "") ? string.Empty : dr["Rescan_Date"];
                        //    xlNewSheet11.Cells[R + 1, 8] = dr["Total_rescan_needed"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Total_rescan_needed"]);
                        //    xlNewSheet11.Cells[R + 1, 9] = dr["Total_rescan_Completed"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Total_rescan_Completed"]);
                        //    xlNewSheet11.Cells[R + 1, 10] = (dr["Total_rescan_Pending"] == DBNull.Value || Convert.ToString(dr["Total_rescan_Pending"]) == "") ? string.Empty : dr["Total_rescan_Pending"];
                        //    xlNewSheet11.Cells[R + 1, 11] = (dr["ExFactory"] == DBNull.Value || Convert.ToString(dr["ExFactory"]) == "") ? string.Empty : dr["ExFactory"];
                        //    xlNewSheet11.Cells[R + 1, 12] = (dr["DC"] == DBNull.Value || Convert.ToString(dr["DC"]) == "") ? string.Empty : dr["DC"];








                        //    //xlNewSheet11.Cells[R + 1, 19] = dr["Fabric4Details"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Fabric4Details"]);

                        //    xlNewSheet11.Range["A1", "A1"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;

                        //    xlNewSheet11.Range["B1", "B1"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                        //    xlNewSheet11.Range["C1", "C1"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                        //    xlNewSheet11.Range["D1", "D1"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                        //    xlNewSheet11.Range["E1", "E1"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                        //    xlNewSheet11.Range["F1", "F1"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                        //    xlNewSheet11.Range["G1", "G1"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                        //    xlNewSheet11.Range["H1", "H1"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                        //    xlNewSheet11.Range["I1", "I1"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                        //    xlNewSheet11.Range["J1", "J1"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                        //    xlNewSheet11.Range["K1", "K1"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                        //    xlNewSheet11.Range["L1", "L1"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;


                        //    xlNewSheet11.Range["A" + Y, "A" + Y].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                        //    xlNewSheet11.Range["B" + Y, "B" + Y].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                        //    xlNewSheet11.Range["C" + Y, "C" + Y].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                        //    xlNewSheet11.Range["D" + Y, "D" + Y].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                        //    xlNewSheet11.Range["E" + Y, "E" + Y].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                        //    xlNewSheet11.Range["F" + Y, "F" + Y].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                        //    xlNewSheet11.Range["G" + Y, "G" + Y].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                        //    xlNewSheet11.Range["H" + Y, "H" + Y].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                        //    xlNewSheet11.Range["I" + Y, "I" + Y].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                        //    xlNewSheet11.Range["J" + Y, "J" + Y].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                        //    xlNewSheet11.Range["K" + Y, "K" + Y].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                        //    xlNewSheet11.Range["L" + Y, "L" + Y].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;




                        //    xlNewSheet11.Range["A" + Y, "A" + Y].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        //    xlNewSheet11.Range["A" + Y, "A" + Y].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        //    xlNewSheet11.Range["A" + Y, "A" + Y].Font.Name = "Calibri";
                        //    xlNewSheet11.Range["A1"].Cells.Font.Size = 10;
                        //    xlNewSheet11.Range["A" + Y, "A" + Y].Font.Size = 8;
                        //    xlNewSheet11.Range["A" + Y, "A" + Y].Font.FontStyle = "Regular";//Department Name

                        //    xlNewSheet11.Range["B" + Y, "B" + Y].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        //    xlNewSheet11.Range["B" + Y, "B" + Y].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        //    xlNewSheet11.Range["B" + Y, "B" + Y].Font.Name = "Calibri";
                        //    xlNewSheet11.Range["B" + Y, "B" + Y].Font.Size = 11;
                        //    xlNewSheet11.Range["B" + Y, "B" + Y].Font.FontStyle = "Bold";//Serial number
                        //    xlNewSheet11.Range["B1"].Cells.Font.Size = 10;

                        //    xlNewSheet11.Range["C" + Y, "C" + Y].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        //    xlNewSheet11.Range["C" + Y, "C" + Y].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        //    xlNewSheet11.Range["C" + Y, "C" + Y].Font.Name = "Calibri";
                        //    xlNewSheet11.Range["C" + Y, "C" + Y].Font.Size = 11;
                        //    xlNewSheet11.Range["C" + Y, "C" + Y].Font.FontStyle = "Regular";//Style number
                        //    xlNewSheet11.Range["C1"].Cells.Font.Size = 10;


                        //    xlNewSheet11.Range["D" + Y, "D" + Y].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        //    xlNewSheet11.Range["D" + Y, "D" + Y].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        //    xlNewSheet11.Range["D" + Y, "D" + Y].Font.Name = "Calibri";
                        //    xlNewSheet11.Range["D" + Y, "D" + Y].Font.Size = 9;
                        //    xlNewSheet11.Range["D" + Y, "D" + Y].Font.FontStyle = "Regular";//Line Number
                        //    xlNewSheet11.Range["D1"].Cells.Font.Size = 10;


                        //    xlNewSheet11.Range["E" + Y, "E" + Y].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        //    xlNewSheet11.Range["E" + Y, "E" + Y].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        //    xlNewSheet11.Range["E" + Y, "E" + Y].Font.Name = "Calibri";
                        //    xlNewSheet11.Range["E" + Y, "E" + Y].Font.Size = 9;
                        //    xlNewSheet11.Range["E" + Y, "E" + Y].Font.FontStyle = "Regular";//ContractNumber
                        //    xlNewSheet11.Range["E1"].Cells.Font.Size = 10;

                        //    xlNewSheet11.Range["F" + Y, "F" + Y].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        //    xlNewSheet11.Range["F" + Y, "F" + Y].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        //    xlNewSheet11.Range["F" + Y, "F" + Y].Font.Name = "Calibri";
                        //    xlNewSheet11.Range["F" + Y, "F" + Y].Font.Size = 8;
                        //    xlNewSheet11.Range["F" + Y, "F" + Y].Font.FontStyle = "Regular";//Fabric1
                        //    xlNewSheet11.Range["F1"].Cells.Font.Size = 10;

                        //    xlNewSheet11.Range["G" + Y, "G" + Y].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        //    xlNewSheet11.Range["G" + Y, "G" + Y].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        //    xlNewSheet11.Range["G" + Y, "G" + Y].Font.Name = "Calibri";
                        //    xlNewSheet11.Range["G" + Y, "G" + Y].Font.Size = 9;
                        //    xlNewSheet11.Range["G" + Y, "G" + Y].Font.FontStyle = "Regular";//Colour/Print
                        //    xlNewSheet11.Range["G1"].Cells.Font.Size = 10;

                        //    xlNewSheet11.Range["H" + Y, "H" + Y].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        //    xlNewSheet11.Range["H" + Y, "H" + Y].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        //    xlNewSheet11.Range["H" + Y, "H" + Y].Font.Name = "Calibri";
                        //    xlNewSheet11.Range["H" + Y, "H" + Y].Font.Size = 11;
                        //    xlNewSheet11.Range["H" + Y, "H" + Y].Font.FontStyle = "Regular";//Weight 
                        //    xlNewSheet11.Range["H" + Y, "H" + Y].Font.FontStyle = "Bold";
                        //    xlNewSheet11.Range["H1"].Cells.Font.Size = 10;


                        //    xlNewSheet11.Range["I" + Y, "I" + Y].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        //    xlNewSheet11.Range["I" + Y, "I" + Y].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        //    xlNewSheet11.Range["I" + Y, "I" + Y].Font.Name = "Calibri";
                        //    xlNewSheet11.Range["I" + Y, "I" + Y].Font.Size = 11;
                        //    xlNewSheet11.Range["I" + Y, "I" + Y].Font.FontStyle = "Bold";//Quantity
                        //    xlNewSheet11.Range["I1"].Cells.Font.Size = 10;


                        //    xlNewSheet11.Range["J" + Y, "J" + Y].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        //    xlNewSheet11.Range["J" + Y, "J" + Y].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        //    xlNewSheet11.Range["J" + Y, "J" + Y].Font.Name = "Calibri";
                        //    xlNewSheet11.Range["J" + Y, "J" + Y].Font.Size = 11;
                        //    xlNewSheet11.Range["J" + Y, "J" + Y].Font.FontStyle = "Regular";//PcsStitche
                        //    xlNewSheet11.Range["J" + Y, "J" + Y].Font.FontStyle = "Bold";
                        //    xlNewSheet11.Range["J1"].Cells.Font.Size = 10;

                        //    xlNewSheet11.Range["K" + Y, "K" + Y].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        //    xlNewSheet11.Range["K" + Y, "K" + Y].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        //    xlNewSheet11.Range["K" + Y, "K" + Y].Font.Name = "Calibri";
                        //    xlNewSheet11.Range["K" + Y, "K" + Y].Font.Size = 8;
                        //    xlNewSheet11.Range["K" + Y, "K" + Y].Font.FontStyle = "Regular";//Value in
                        //    xlNewSheet11.Range["K1"].Cells.Font.Size = 10;

                        //    xlNewSheet11.Range["L" + Y, "L" + Y].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        //    xlNewSheet11.Range["L" + Y, "L" + Y].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        //    xlNewSheet11.Range["L" + Y, "L" + Y].Font.Name = "Calibri";
                        //    xlNewSheet11.Range["L" + Y, "L" + Y].Font.Size = 8;
                        //    xlNewSheet11.Range["L" + Y, "L" + Y].Font.FontStyle = "Regular";//TOP Status
                        //    xlNewSheet11.Range["L1"].Cells.Font.Size = 10;

                        //    xlNewSheet11.Range["I" + Y, "I" + Y].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.DarkBlue);
                        //    xlNewSheet11.Range["J" + Y, "J" + Y].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red);



                        //    R++;
                        //    Y++;
                        //}
                        //xlNewSheet11.Range["A1", "A1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        //xlNewSheet11.Range["A1", "A1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        //xlNewSheet11.Range["A1", "A1"].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        //xlNewSheet11.Range["A1", "A1"].Font.Bold = false;
                        //xlNewSheet11.Range["A1", "A1"].Font.Name = "Calibri";

                        //xlNewSheet11.Range["A1", "A1"].Font.FontStyle = "Regular";
                        //xlNewSheet11.Range["A1"].Cells.ColumnWidth = 9.71;


                        //xlNewSheet11.Range["B1", "B1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        //xlNewSheet11.Range["B1", "B1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        //xlNewSheet11.Range["B1", "B1"].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        //xlNewSheet11.Range["B1", "B1"].Font.Bold = false;
                        //xlNewSheet11.Range["B1", "B1"].Font.Name = "Calibri";

                        //xlNewSheet11.Range["B1", "B1"].Font.FontStyle = "Regular";
                        //xlNewSheet11.Range["B1"].Cells.ColumnWidth = 14.14;


                        //xlNewSheet11.Range["C1", "C1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        //xlNewSheet11.Range["C1", "C1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        //xlNewSheet11.Range["C1", "C1"].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        //xlNewSheet11.Range["C1", "C1"].Font.Bold = false;
                        //xlNewSheet11.Range["C1", "C1"].Font.Name = "Calibri";

                        //xlNewSheet11.Range["C1", "C1"].Font.FontStyle = "Regular";
                        //xlNewSheet11.Range["C1"].Cells.ColumnWidth = 11.71;



                        //xlNewSheet11.Range["D1", "D1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        //xlNewSheet11.Range["D1", "D1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        //xlNewSheet11.Range["D1", "D1"].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        //xlNewSheet11.Range["D1", "D1"].Font.Bold = false;
                        //xlNewSheet11.Range["D1", "D1"].Font.Name = "Calibri";

                        //xlNewSheet11.Range["D1", "D1"].Font.FontStyle = "Regular";
                        //xlNewSheet11.Range["D1"].Cells.ColumnWidth = 12.86;


                        //xlNewSheet11.Range["E1", "E1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        //xlNewSheet11.Range["E1", "E1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        //xlNewSheet11.Range["E1", "E1"].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        //xlNewSheet11.Range["E1", "E1"].Font.Bold = false;
                        //xlNewSheet11.Range["E1", "E1"].Font.Name = "Calibri";

                        //xlNewSheet11.Range["E1", "E1"].Font.FontStyle = "Regular";
                        //xlNewSheet11.Range["E1"].Cells.ColumnWidth = 25.71;




                        //xlNewSheet11.Range["F1", "F1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        //xlNewSheet11.Range["F1", "F1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        //xlNewSheet11.Range["F1", "F1"].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        //xlNewSheet11.Range["F1", "F1"].Font.Bold = false;
                        //xlNewSheet11.Range["F1", "F1"].Font.Name = "Calibri";

                        //xlNewSheet11.Range["F1", "F1"].Font.FontStyle = "Regular";
                        //xlNewSheet11.Range["F1"].Cells.ColumnWidth = 11.71;



                        //xlNewSheet11.Range["G1", "G1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        //xlNewSheet11.Range["G1", "G1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        //xlNewSheet11.Range["G1", "G1"].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        //xlNewSheet11.Range["G1", "G1"].Font.Bold = false;
                        //xlNewSheet11.Range["G1", "G1"].Font.Name = "Calibri";

                        //xlNewSheet11.Range["G1", "G1"].Font.FontStyle = "Regular";
                        //xlNewSheet11.Range["G1"].Cells.ColumnWidth = 13.14;


                        //xlNewSheet11.Range["H1", "H1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        //xlNewSheet11.Range["H1", "H1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        //xlNewSheet11.Range["H1", "H1"].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        //xlNewSheet11.Range["H1", "H1"].Font.Bold = false;
                        //xlNewSheet11.Range["H1", "H1"].Font.Name = "Calibri";

                        //xlNewSheet11.Range["H1", "H1"].Font.FontStyle = "Regular";
                        //xlNewSheet11.Range["H1"].Cells.ColumnWidth = 11.43;


                        //xlNewSheet11.Range["I1", "I1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        //xlNewSheet11.Range["I1", "I1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        //xlNewSheet11.Range["I1", "I1"].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        //xlNewSheet11.Range["I1", "I1"].Font.Bold = false;
                        //xlNewSheet11.Range["I1", "I1"].Font.Name = "Calibri";


                        //xlNewSheet11.Range["I1"].Cells.ColumnWidth = 11.43;


                        //xlNewSheet11.Range["J1", "J1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        //xlNewSheet11.Range["J1", "J1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        //xlNewSheet11.Range["J1", "J1"].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        //xlNewSheet11.Range["J1", "J1"].Font.Bold = false;
                        //xlNewSheet11.Range["J1", "J1"].Font.Name = "Calibri";

                        //xlNewSheet11.Range["J1", "J1"].Font.FontStyle = "Regular";

                        //xlNewSheet11.Range["J1"].Cells.ColumnWidth = 11.43;



                        //xlNewSheet11.Range["K1", "K1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        //xlNewSheet11.Range["K1", "K1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        //xlNewSheet11.Range["K1", "K1"].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        //xlNewSheet11.Range["K1", "K1"].Font.Bold = false;
                        //xlNewSheet11.Range["K1", "K1"].Font.Name = "Calibri";

                        //xlNewSheet11.Range["K1", "K1"].Font.FontStyle = "Regular";
                        //xlNewSheet11.Range["K1"].Cells.ColumnWidth = 8.43;


                        //xlNewSheet11.Range["L1", "L1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        //xlNewSheet11.Range["L1", "L1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        //xlNewSheet11.Range["L1", "L1"].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        //xlNewSheet11.Range["L1", "L1"].Font.Bold = false;
                        //xlNewSheet11.Range["L1", "L1"].Font.Name = "Calibri";

                        //xlNewSheet11.Range["L1", "L1"].Font.FontStyle = "Regular";
                        //xlNewSheet11.Range["L1"].Cells.ColumnWidth = 8.71;




                        //xlNewSheet11.Range["A1", "L1"].RowHeight = 32;
                        ////xlNewSheet11.Columns.AutoFit();
                        //xlNewSheet11.Range["G1"].Cells.EntireColumn.NumberFormat = "d mmm (ddd);@";
                        //xlNewSheet11.Range["K1"].Cells.EntireColumn.NumberFormat = "d mmm (ddd);@";
                        //xlNewSheet11.Range["L1"].Cells.EntireColumn.NumberFormat = "d mmm (ddd);@";
                        //xlNewSheet11.Range["A1", "L1"].EntireColumn.WrapText = true;
                        //xlNewSheet11.Range["A1", "T1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        //xlNewSheet11.Range["A1", "T1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        //xlNewSheet11.Range["A1", "T1"].Font.Bold = true;

                        //xlNewSheet11.Range["A1", "T1"].Font.Name = "Calibri";
                        //xlNewSheet11.Range["A1", "T1"].Font.Size = 6;

                        //xlNewSheet11.Range["I1"].EntireColumn.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Blue);

                        releaseObject(xlNewSheet11);
                        ((Excel.Worksheet)xlApp.ActiveWorkbook.Sheets[1]).Activate();

                    }

                }
                if (ReportType == "PatternStatus")
                {
                    // iKandi.Common.Constants.WorkSheetCount_ForExcel = iKandi.Common.Constants.WorkSheetCount_ForExcel + 1;
                    GlobalType_PatternStatus = GlobalType_PatternStatus + 1;
                    var xlNewSheet11 = (Excel.Worksheet)worksheets.Add(worksheets[GlobalType_PatternStatus], Type.Missing, Type.Missing, Type.Missing);



                    xlNewSheet11.Name = "PatternStatus";
                    xlNewSheet11.Cells[1, 1] = "Buyer";
                    xlNewSheet11.Cells[1, 2] = "Style number";
                    xlNewSheet11.Cells[1, 3] = "Department Name";
                    xlNewSheet11.Cells[1, 4] = "PD";
                    xlNewSheet11.Cells[1, 5] = "STC Requested Date";
                    xlNewSheet11.Cells[1, 6] = "Issue Date to Gulbas After Sealing";
                    xlNewSheet11.Cells[1, 7] = "Issue Date To Production";
                    xlNewSheet11.Cells[1, 8] = "Current Stage (Correction , Checking , Grading )";
                    xlNewSheet11.Cells[1, 9] = "Style Type";
                    xlNewSheet11.Cells[1, 10] = "Request Type";





                    if (ds.Tables[0].Rows.Count == 0)
                    {
                        return false;
                    }
                    else if (ds.Tables[0].Rows.Count > 0)
                    {
                        int R = 1;
                        int Y = 2;
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {


                            xlNewSheet11.Cells[R + 1, 1] = dr["CompanyName"] == DBNull.Value ? string.Empty : Convert.ToString(dr["CompanyName"]);
                            xlNewSheet11.Cells[R + 1, 2] = dr["StyleNumber"] == DBNull.Value ? string.Empty : Convert.ToString(dr["StyleNumber"]);
                            xlNewSheet11.Cells[R + 1, 3] = dr["DepartmentName"] == DBNull.Value ? string.Empty : Convert.ToString(dr["DepartmentName"]);
                            xlNewSheet11.Cells[R + 1, 4] = dr["ProductionMerchentName"] == DBNull.Value ? string.Empty : Convert.ToString(dr["ProductionMerchentName"]);
                            xlNewSheet11.Cells[R + 1, 5] = dr["StcRequestedDate"] == DBNull.Value ? string.Empty : Convert.ToString(dr["StcRequestedDate"]);
                            xlNewSheet11.Cells[R + 1, 6] = dr["HandOverActualDate"] == DBNull.Value ? string.Empty : Convert.ToString(dr["HandOverActualDate"]);
                            xlNewSheet11.Cells[R + 1, 7] = dr["PatternReadyETA"] == DBNull.Value ? string.Empty : Convert.ToString(dr["PatternReadyETA"]);
                            xlNewSheet11.Cells[R + 1, 8] = dr["CurrentStatus"] == DBNull.Value ? string.Empty : Convert.ToString(dr["CurrentStatus"]);
                            xlNewSheet11.Cells[R + 1, 9] = dr["styletype"] == DBNull.Value ? string.Empty : Convert.ToString(dr["styletype"]);
                            xlNewSheet11.Cells[R + 1, 10] = dr["FitsStype"] == DBNull.Value ? string.Empty : Convert.ToString(dr["FitsStype"]);

                            //xlNewSheet11.Cells[R + 1, 19] = dr["Fabric4Details"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Fabric4Details"]);

                            xlNewSheet11.Range["A1", "A1"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;

                            xlNewSheet11.Range["B1", "B1"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["C1", "C1"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["D1", "D1"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["E1", "E1"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["F1", "F1"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["G1", "G1"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["H1", "H1"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["I1", "I1"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["J1", "J1"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["A" + Y, "A" + Y].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["B" + Y, "B" + Y].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["C" + Y, "C" + Y].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["D" + Y, "D" + Y].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["E" + Y, "E" + Y].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["F" + Y, "F" + Y].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["G" + Y, "G" + Y].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["H" + Y, "H" + Y].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["I" + Y, "I" + Y].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["J" + Y, "J" + Y].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;






                            xlNewSheet11.Range["A" + Y, "A" + Y].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet11.Range["A" + Y, "A" + Y].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet11.Range["A" + Y, "A" + Y].Font.Name = "Calibri";
                            xlNewSheet11.Range["A1"].Cells.Font.Size = 10;
                            xlNewSheet11.Range["A" + Y, "A" + Y].Font.Size = 8;
                            xlNewSheet11.Range["A" + Y, "A" + Y].Font.FontStyle = "Regular";//Department Name

                            xlNewSheet11.Range["B" + Y, "B" + Y].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet11.Range["B" + Y, "B" + Y].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet11.Range["B" + Y, "B" + Y].Font.Name = "Calibri";
                            xlNewSheet11.Range["B" + Y, "B" + Y].Font.Size = 11;
                            xlNewSheet11.Range["B" + Y, "B" + Y].Font.FontStyle = "Bold";//Serial number
                            xlNewSheet11.Range["B1"].Cells.Font.Size = 10;

                            xlNewSheet11.Range["C" + Y, "C" + Y].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet11.Range["C" + Y, "C" + Y].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet11.Range["C" + Y, "C" + Y].Font.Name = "Calibri";
                            xlNewSheet11.Range["C" + Y, "C" + Y].Font.Size = 11;
                            xlNewSheet11.Range["C" + Y, "C" + Y].Font.FontStyle = "Regular";//Style number
                            xlNewSheet11.Range["C1"].Cells.Font.Size = 10;


                            xlNewSheet11.Range["D" + Y, "D" + Y].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet11.Range["D" + Y, "D" + Y].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet11.Range["D" + Y, "D" + Y].Font.Name = "Calibri";
                            xlNewSheet11.Range["D" + Y, "D" + Y].Font.Size = 9;
                            xlNewSheet11.Range["D" + Y, "D" + Y].Font.FontStyle = "Regular";//Line Number
                            xlNewSheet11.Range["D1"].Cells.Font.Size = 10;


                            xlNewSheet11.Range["E" + Y, "E" + Y].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet11.Range["E" + Y, "E" + Y].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet11.Range["E" + Y, "E" + Y].Font.Name = "Calibri";
                            xlNewSheet11.Range["E" + Y, "E" + Y].Font.Size = 9;
                            xlNewSheet11.Range["E" + Y, "E" + Y].Font.FontStyle = "Regular";//ContractNumber
                            xlNewSheet11.Range["E1"].Cells.Font.Size = 10;

                            xlNewSheet11.Range["F" + Y, "F" + Y].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet11.Range["F" + Y, "F" + Y].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet11.Range["F" + Y, "F" + Y].Font.Name = "Calibri";
                            xlNewSheet11.Range["F" + Y, "F" + Y].Font.Size = 9;
                            xlNewSheet11.Range["F" + Y, "F" + Y].Font.FontStyle = "Regular";//ContractNumber
                            xlNewSheet11.Range["F1"].Cells.Font.Size = 10;

                            xlNewSheet11.Range["G" + Y, "G" + Y].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet11.Range["G" + Y, "G" + Y].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet11.Range["G" + Y, "G" + Y].Font.Name = "Calibri";
                            xlNewSheet11.Range["G" + Y, "G" + Y].Font.Size = 9;
                            xlNewSheet11.Range["G" + Y, "G" + Y].Font.FontStyle = "Regular";//ContractNumber
                            xlNewSheet11.Range["G1"].Cells.Font.Size = 10;

                            xlNewSheet11.Range["H" + Y, "H" + Y].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet11.Range["H" + Y, "H" + Y].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet11.Range["H" + Y, "H" + Y].Font.Name = "Calibri";
                            xlNewSheet11.Range["H" + Y, "H" + Y].Font.Size = 9;
                            xlNewSheet11.Range["H" + Y, "H" + Y].Font.FontStyle = "Regular";//ContractNumber
                            xlNewSheet11.Range["H1"].Cells.Font.Size = 10;

                            xlNewSheet11.Range["I" + Y, "I" + Y].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet11.Range["I" + Y, "I" + Y].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet11.Range["I" + Y, "I" + Y].Font.Name = "Calibri";
                            xlNewSheet11.Range["I" + Y, "I" + Y].Font.Size = 9;
                            xlNewSheet11.Range["I" + Y, "I" + Y].Font.FontStyle = "Regular";//ContractNumber
                            xlNewSheet11.Range["I1"].Cells.Font.Size = 10;

                            xlNewSheet11.Range["J" + Y, "J" + Y].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet11.Range["J" + Y, "J" + Y].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet11.Range["J" + Y, "J" + Y].Font.Name = "Calibri";
                            xlNewSheet11.Range["J" + Y, "J" + Y].Font.Size = 9;
                            xlNewSheet11.Range["J" + Y, "J" + Y].Font.FontStyle = "Regular";//ContractNumber
                            xlNewSheet11.Range["J1"].Cells.Font.Size = 10;


                            R++;
                            Y++;
                        }
                        xlNewSheet11.Range["A1", "A1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        xlNewSheet11.Range["A1", "A1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet11.Range["A1", "A1"].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        xlNewSheet11.Range["A1", "A1"].Font.Bold = false;
                        xlNewSheet11.Range["A1", "A1"].Font.Name = "Calibri";

                        xlNewSheet11.Range["A1", "A1"].Font.FontStyle = "Regular";
                        xlNewSheet11.Range["A1"].Cells.ColumnWidth = 9.71;


                        xlNewSheet11.Range["B1", "B1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        xlNewSheet11.Range["B1", "B1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet11.Range["B1", "B1"].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        xlNewSheet11.Range["B1", "B1"].Font.Bold = false;
                        xlNewSheet11.Range["B1", "B1"].Font.Name = "Calibri";

                        xlNewSheet11.Range["B1", "B1"].Font.FontStyle = "Regular";
                        xlNewSheet11.Range["B1"].Cells.ColumnWidth = 16;


                        xlNewSheet11.Range["C1", "C1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        xlNewSheet11.Range["C1", "C1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet11.Range["C1", "C1"].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        xlNewSheet11.Range["C1", "C1"].Font.Bold = false;
                        xlNewSheet11.Range["C1", "C1"].Font.Name = "Calibri";

                        xlNewSheet11.Range["C1", "C1"].Font.FontStyle = "Regular";
                        xlNewSheet11.Range["C1"].Cells.ColumnWidth = 20;



                        xlNewSheet11.Range["D1", "D1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        xlNewSheet11.Range["D1", "D1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet11.Range["D1", "D1"].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        xlNewSheet11.Range["D1", "D1"].Font.Bold = false;
                        xlNewSheet11.Range["D1", "D1"].Font.Name = "Calibri";

                        xlNewSheet11.Range["D1", "D1"].Font.FontStyle = "Regular";
                        xlNewSheet11.Range["D1"].Cells.ColumnWidth = 20;


                        xlNewSheet11.Range["E1", "E1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        xlNewSheet11.Range["E1", "E1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet11.Range["E1", "E1"].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        xlNewSheet11.Range["E1", "E1"].Font.Bold = false;
                        xlNewSheet11.Range["E1", "E1"].Font.Name = "Calibri";

                        xlNewSheet11.Range["E1", "E1"].Font.FontStyle = "Regular";
                        xlNewSheet11.Range["E1"].Cells.ColumnWidth = 25.71;

                        xlNewSheet11.Range["F1", "F1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        xlNewSheet11.Range["F1", "F1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet11.Range["F1", "F1"].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        xlNewSheet11.Range["F1", "F1"].Font.Bold = false;
                        xlNewSheet11.Range["F1", "F1"].Font.Name = "Calibri";

                        xlNewSheet11.Range["F1", "F1"].Font.FontStyle = "Regular";
                        xlNewSheet11.Range["F1"].Cells.ColumnWidth = 20;

                        xlNewSheet11.Range["G1", "G1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        xlNewSheet11.Range["G1", "G1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet11.Range["G1", "G1"].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        xlNewSheet11.Range["G1", "G1"].Font.Bold = false;
                        xlNewSheet11.Range["G1", "G1"].Font.Name = "Calibri";

                        xlNewSheet11.Range["G1", "G1"].Font.FontStyle = "Regular";
                        xlNewSheet11.Range["G1"].Cells.ColumnWidth = 20;

                        xlNewSheet11.Range["H1", "H1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        xlNewSheet11.Range["H1", "H1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet11.Range["H1", "H1"].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        xlNewSheet11.Range["H1", "H1"].Font.Bold = false;
                        xlNewSheet11.Range["H1", "H1"].Font.Name = "Calibri";

                        xlNewSheet11.Range["H1", "H1"].Font.FontStyle = "Regular";
                        xlNewSheet11.Range["H1"].Cells.ColumnWidth = 20;

                        xlNewSheet11.Range["I1", "I1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        xlNewSheet11.Range["I1", "I1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet11.Range["I1", "I1"].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        xlNewSheet11.Range["I1", "I1"].Font.Bold = false;
                        xlNewSheet11.Range["I1", "I1"].Font.Name = "Calibri";

                        xlNewSheet11.Range["I1", "I1"].Font.FontStyle = "Regular";
                        xlNewSheet11.Range["I1"].Cells.ColumnWidth = 20;

                        xlNewSheet11.Range["J1", "J1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        xlNewSheet11.Range["J1", "J1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet11.Range["J1", "J1"].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        xlNewSheet11.Range["J1", "J1"].Font.Bold = false;
                        xlNewSheet11.Range["J1", "J1"].Font.Name = "Calibri";

                        xlNewSheet11.Range["J1", "J1"].Font.FontStyle = "Regular";
                        xlNewSheet11.Range["J1"].Cells.ColumnWidth = 20;







                        xlNewSheet11.Range["A1", "J1"].RowHeight = 42;
                        //xlNewSheet11.Columns.AutoFit();
                        xlNewSheet11.Range["E1"].Cells.EntireColumn.NumberFormat = "d mmm (ddd);@";
                        xlNewSheet11.Range["F1"].Cells.EntireColumn.NumberFormat = "d mmm (ddd);@";
                        xlNewSheet11.Range["G1"].Cells.EntireColumn.NumberFormat = "d mmm (ddd);@";
                        xlNewSheet11.Range["A1", "J1"].EntireColumn.WrapText = true;
                        //xlNewSheet11.Range["A1", "T1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        //xlNewSheet11.Range["A1", "T1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        //xlNewSheet11.Range["A1", "T1"].Font.Bold = true;

                        //xlNewSheet11.Range["A1", "T1"].Font.Name = "Calibri";
                        //xlNewSheet11.Range["A1", "T1"].Font.Size = 6;

                        //xlNewSheet11.Range["I1"].EntireColumn.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Blue);

                        releaseObject(xlNewSheet11);
                        ((Excel.Worksheet)xlApp.ActiveWorkbook.Sheets[1]).Activate();

                    }

                }
                if (ReportType == "FabriInhouseShortforUpcomingDC")
                {
                    // iKandi.Common.Constants.WorkSheetCount_ForExcel = iKandi.Common.Constants.WorkSheetCount_ForExcel + 1;
                    GlobalType_UpCommingDC_ForFabricSorted = GlobalType_UpCommingDC_ForFabricSorted + 1;
                    var xlNewSheet11 = (Excel.Worksheet)worksheets.Add(worksheets[GlobalType_UpCommingDC_ForFabricSorted], Type.Missing, Type.Missing, Type.Missing);



                    xlNewSheet11.Name = "FabriInhouseShortforUpcomingDC";
                    //xlNewSheet11.Cells[1, 1] = "S.n.";
                    //xlNewSheet11.Cells[1, 2] = "Department Name";
                    //xlNewSheet11.Cells[1, 3] = "Serial number";
                    //xlNewSheet11.Cells[1, 4] = "Style number";
                    //xlNewSheet11.Cells[1, 5] = "UnitName";
                    //xlNewSheet11.Cells[1, 6] = "Fabric1";
                    ////xlNewSheet11.Cells[1, 6] = "First Fabric Color/Print";
                    //xlNewSheet11.Cells[1, 7] = "Colour/Print";
                    //xlNewSheet11.Cells[1, 8] = "Quantity";
                    //xlNewSheet11.Cells[1, 9] = "PcsStitched_Percent(%)";
                    //xlNewSheet11.Cells[1, 10] = "Value in  INR/ Lacs.";
                    //xlNewSheet11.Cells[1, 11] = "TOP Status";
                    //xlNewSheet11.Cells[1, 12] = "MDA";
                    //xlNewSheet11.Cells[1, 13] = "DeliveryMode";
                    //xlNewSheet11.Cells[1, 14] = "ExFactory";
                    //xlNewSheet11.Cells[1, 15] = "DC";
                    //xlNewSheet11.Cells[1, 16] = "Booking Status";
                    //xlNewSheet11.Cells[1, 17] = "Ready date";
                    //xlNewSheet11.Cells[1, 18] = "ReadyTime";
                    //xlNewSheet11.Cells[1, 19] = "Remark";
                    //xlNewSheet11.Cells[1, 20] = "ContractNumber";

                    xlNewSheet11.Cells[1, 1] = "Department Name";
                    xlNewSheet11.Cells[1, 2] = "Serial number";
                    xlNewSheet11.Cells[1, 3] = "Style number";
                    xlNewSheet11.Cells[1, 4] = "Line Number";
                    xlNewSheet11.Cells[1, 5] = "ContractNumber";
                    xlNewSheet11.Cells[1, 6] = "Fabric1";
                    xlNewSheet11.Cells[1, 7] = "Colour/Print";
                    xlNewSheet11.Cells[1, 8] = "Weight(gms)";
                    xlNewSheet11.Cells[1, 9] = "Quantity";
                    xlNewSheet11.Cells[1, 10] = "PcsStitched Percent(%)";
                    xlNewSheet11.Cells[1, 11] = "Value in  INR/ Lacs.";
                    //xlNewSheet11.Cells[1, 12] = "TOP Status";
                    //xlNewSheet11.Cells[1, 13] = "MDA";
                    xlNewSheet11.Cells[1, 12] = "DeliveryMode";
                    xlNewSheet11.Cells[1, 13] = "ExFactory";
                    xlNewSheet11.Cells[1, 14] = "DC";
                    xlNewSheet11.Cells[1, 15] = "Booking Status";
                    xlNewSheet11.Cells[1, 16] = "Start date";
                    xlNewSheet11.Cells[1, 17] = "End Date";
                    xlNewSheet11.Cells[1, 18] = "Ship Plan Date";
                    xlNewSheet11.Cells[1, 19] = "Line Plan";
                    xlNewSheet11.Cells[1, 20] = "UnitName";
                    //xlNewSheet11.Cells[1, 22] = "Weight";
                    xlNewSheet11.Cells[1, 21] = "Remark";
                    xlNewSheet11.Cells[1, 22] = "Fabric StartDate";
                    xlNewSheet11.Cells[1, 23] = "Fabric EndDate";



                    if (ds.Tables[0].Rows.Count == 0)
                    {
                        return false;
                    }
                    else if (ds.Tables[0].Rows.Count > 0)
                    {
                        int R = 1;
                        int Y = 2;
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            //xlNewSheet11.Cells[R + 1, 1] = dr["DepartmentName"] == DBNull.Value ? string.Empty : Convert.ToString(dr["DepartmentName"]);
                            //xlNewSheet11.Cells[R + 1, 2] = dr["Serialnumber"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Serialnumber"]);
                            //xlNewSheet11.Cells[R + 1, 3] = dr["Stylenumber"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Stylenumber"]);
                            //xlNewSheet11.Cells[R + 1, 4] = dr["LineNOs"] == DBNull.Value ? string.Empty : Convert.ToString(dr["LineNOs"]);
                            //xlNewSheet11.Cells[R + 1, 5] = dr["ContractNumber"] == DBNull.Value ? string.Empty : Convert.ToString(dr["ContractNumber"]);

                            //xlNewSheet11.Cells[R + 1, 6] = dr["Fabric1"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Fabric1"]);
                            //xlNewSheet11.Cells[R + 1, 7] = dr["Fabric1Details"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Fabric1Details"]);
                            ////xlNewSheet11.Cells[R + 1, 6] = dr["Fabric1Details"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Fabric1Details"]);
                            //xlNewSheet11.Cells[R + 1, 8] =  dr["Quantity"] == DBNull.Value ? string.Empty : Convert.ToString(Convert.ToInt32(dr["Quantity"]).ToString("N0"));
                            //xlNewSheet11.Cells[R + 1, 9] =  (dr["Weight"] == DBNull.Value || dr["Weight"].ToString() == "0") ? string.Empty : Convert.ToString(dr["Weight"]);
                            //xlNewSheet11.Cells[R + 1, 10] = dr["Value"] == DBNull.Value ? string.Empty : Convert.ToString("₹" + dr["Value"]);
                            //xlNewSheet11.Cells[R + 1, 11] = dr["TOPStatus"] == DBNull.Value ? string.Empty : Convert.ToString(dr["TOPStatus"]);
                            //xlNewSheet11.Cells[R + 1, 12] = dr["MDA"] == DBNull.Value ? string.Empty : Convert.ToString(dr["MDA"]);

                            //xlNewSheet11.Cells[R + 1, 13] = dr["DeliveryMode"] == DBNull.Value ? string.Empty : Convert.ToString(dr["DeliveryMode"]);
                            //xlNewSheet11.Cells[R + 1, 14] = dr["ExFactory"] == DBNull.Value ? string.Empty : Convert.ToDateTime(dr["ExFactory"]).ToString("dd MMM yy (ddd)");
                            //xlNewSheet11.Cells[R + 1, 15] = dr["DC"] == DBNull.Value ? string.Empty : Convert.ToDateTime(dr["DC"]).ToString("dd MMM yy (ddd)");
                            //xlNewSheet11.Cells[R + 1, 16] = dr["BookingStatus"] == DBNull.Value ? string.Empty : Convert.ToString(dr["BookingStatus"]);
                            ////xlNewSheet11.Cells[R + 1, 17] = dr["Readydate"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Readydate"]);
                            ////xlNewSheet11.Cells[R + 1, 18] = dr["ReadyTime"] == DBNull.Value ? string.Empty : Convert.ToString(dr["ReadyTime"]);
                            //xlNewSheet11.Cells[R + 1, 17] = dr["StartDate"] == DBNull.Value ? string.Empty : Convert.ToDateTime(dr["StartDate"]).ToString("dd MMM yy (ddd)");//startdate
                            //xlNewSheet11.Cells[R + 1, 18] = dr["EndDate"] == DBNull.Value ? string.Empty : Convert.ToDateTime(dr["EndDate"]).ToString("dd MMM yy (ddd)");//Endate
                            //xlNewSheet11.Cells[R + 1, 19] = dr["PlanDate"] == DBNull.Value ? string.Empty : Convert.ToDateTime(dr["PlanDate"]).ToString("dd MMM yy (ddd)");//Ship Plan Date
                            //xlNewSheet11.Cells[R + 1, 20] = dr["lineplan"] == DBNull.Value ? string.Empty : dr["lineplan"];//Line plan
                            //xlNewSheet11.Cells[R + 1, 21] = dr["UnitID"] == DBNull.Value ? string.Empty : Convert.ToString(dr["UnitID"]);
                            //xlNewSheet11.Cells[R + 1, 22] = dr["Remark"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Remark"]);//Weight                          
                            //xlNewSheet11.Cells[R + 1, 23] = dr["PcsStitched_Percent"] == DBNull.Value ? string.Empty : Convert.ToString(dr["PcsStitched_Percent"]);


                            xlNewSheet11.Cells[R + 1, 1] = dr["DepartmentName"] == DBNull.Value ? string.Empty : Convert.ToString(dr["DepartmentName"]);
                            xlNewSheet11.Cells[R + 1, 2] = dr["Serialnumber"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Serialnumber"]);
                            xlNewSheet11.Cells[R + 1, 3] = dr["Stylenumber"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Stylenumber"]);
                            xlNewSheet11.Cells[R + 1, 4] = dr["LineNOs"] == DBNull.Value ? string.Empty : Convert.ToString(dr["LineNOs"]);
                            xlNewSheet11.Cells[R + 1, 5] = dr["ContractNumber"] == DBNull.Value ? string.Empty : Convert.ToString(dr["ContractNumber"]);

                            xlNewSheet11.Cells[R + 1, 6] = dr["Fabric1"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Fabric1"]);
                            xlNewSheet11.Cells[R + 1, 7] = dr["Fabric1Details"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Fabric1Details"]);
                            xlNewSheet11.Cells[R + 1, 8] = (dr["Weight"] == DBNull.Value || dr["Weight"].ToString() == "0") ? string.Empty : Convert.ToString(dr["Weight"]);
                            xlNewSheet11.Cells[R + 1, 9] = dr["Quantity"] == DBNull.Value ? string.Empty : Convert.ToString(Convert.ToInt32(dr["Quantity"]).ToString("N0"));
                            xlNewSheet11.Cells[R + 1, 10] = dr["PcsStitched_Percent"] == DBNull.Value ? string.Empty : Convert.ToString(dr["PcsStitched_Percent"]);
                            xlNewSheet11.Cells[R + 1, 11] = dr["Value"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Value"]);
                            //xlNewSheet11.Cells[R + 1, 12] = dr["TOPStatus"] == DBNull.Value ? string.Empty : Convert.ToString(dr["TOPStatus"]);
                            //xlNewSheet11.Cells[R + 1, 13] = dr["MDA"] == DBNull.Value ? string.Empty : Convert.ToString(dr["MDA"]);

                            xlNewSheet11.Cells[R + 1, 12] = dr["DeliveryMode"] == DBNull.Value ? string.Empty : Convert.ToString(dr["DeliveryMode"]);
                            xlNewSheet11.Cells[R + 1, 13] = (dr["ExFactory"] == DBNull.Value || Convert.ToString(dr["ExFactory"]) == "") ? string.Empty : dr["ExFactory"];
                            xlNewSheet11.Cells[R + 1, 14] = (dr["DC"] == DBNull.Value || Convert.ToString(dr["DC"]) == "") ? string.Empty : dr["DC"];
                            xlNewSheet11.Cells[R + 1, 15] = dr["BookingStatus"] == DBNull.Value ? string.Empty : Convert.ToString(dr["BookingStatus"]);
                            //xlNewSheet11.Cells[R + 1, 17] = dr["Readydate"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Readydate"]);
                            //xlNewSheet11.Cells[R + 1, 18] = dr["ReadyTime"] == DBNull.Value ? string.Empty : Convert.ToString(dr["ReadyTime"]);
                            xlNewSheet11.Cells[R + 1, 16] = (dr["StartDate"] == DBNull.Value || Convert.ToString(dr["StartDate"]) == "") ? string.Empty : dr["StartDate"];
                            xlNewSheet11.Cells[R + 1, 17] = (dr["EndDate"] == DBNull.Value || Convert.ToString(dr["EndDate"]) == "") ? string.Empty : dr["EndDate"];
                            xlNewSheet11.Cells[R + 1, 18] = (dr["PlanDate"] == DBNull.Value || Convert.ToString(dr["PlanDate"]) == "") ? string.Empty : dr["PlanDate"];
                            xlNewSheet11.Cells[R + 1, 19] = dr["lineplan"] == DBNull.Value ? string.Empty : dr["lineplan"];//Line plan
                            xlNewSheet11.Cells[R + 1, 20] = dr["UnitID"] == DBNull.Value ? string.Empty : Convert.ToString(dr["UnitID"]);
                            xlNewSheet11.Cells[R + 1, 21] = dr["Remark"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Remark"]);//Weight                          
                            xlNewSheet11.Cells[R + 1, 22] = (dr["FabricStartDate"] == DBNull.Value || Convert.ToString(dr["FabricStartDate"]) == "") ? string.Empty : dr["FabricStartDate"];
                            xlNewSheet11.Cells[R + 1, 23] = (dr["FabricEndDate"] == DBNull.Value || Convert.ToString(dr["FabricEndDate"]) == "") ? string.Empty : dr["FabricEndDate"];



                            //xlNewSheet11.Cells[R + 1, 19] = dr["Fabric4Details"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Fabric4Details"]);

                            xlNewSheet11.Range["A1", "A1"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;

                            xlNewSheet11.Range["B1", "B1"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["C1", "C1"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["D1", "D1"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["E1", "E1"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["F1", "F1"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["G1", "G1"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["H1", "H1"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["I1", "I1"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["J1", "J1"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["K1", "K1"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["L1", "L1"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["M1", "M1"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["N1", "N1"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["O1", "O1"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["P1", "P1"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["Q1", "Q1"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["R1", "R1"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["S1", "S1"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["T1", "T1"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["U1", "U1"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["V1", "V1"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["W1", "W1"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;

                            xlNewSheet11.Range["A" + Y, "A" + Y].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["B" + Y, "B" + Y].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["C" + Y, "C" + Y].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["D" + Y, "D" + Y].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["E" + Y, "E" + Y].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["F" + Y, "F" + Y].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["G" + Y, "G" + Y].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["H" + Y, "H" + Y].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["I" + Y, "I" + Y].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["J" + Y, "J" + Y].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["K" + Y, "K" + Y].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["L" + Y, "L" + Y].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["M" + Y, "M" + Y].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["N" + Y, "N" + Y].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["O" + Y, "O" + Y].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["P" + Y, "P" + Y].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["Q" + Y, "Q" + Y].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["R" + Y, "R" + Y].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["S" + Y, "S" + Y].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["T" + Y, "T" + Y].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;

                            xlNewSheet11.Range["U" + Y, "U" + Y].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["V" + Y, "V" + Y].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["W" + Y, "W" + Y].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;



                            xlNewSheet11.Range["A" + Y, "A" + Y].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet11.Range["A" + Y, "A" + Y].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet11.Range["A" + Y, "A" + Y].Font.Name = "Calibri";
                            xlNewSheet11.Range["A" + Y, "A" + Y].Font.Size = 8;
                            xlNewSheet11.Range["A" + Y, "A" + Y].Font.FontStyle = "Regular";//Department Name

                            xlNewSheet11.Range["B" + Y, "B" + Y].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet11.Range["B" + Y, "B" + Y].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet11.Range["B" + Y, "B" + Y].Font.Name = "Calibri";
                            xlNewSheet11.Range["B" + Y, "B" + Y].Font.Size = 11;
                            xlNewSheet11.Range["B" + Y, "B" + Y].Font.FontStyle = "Bold";//Serial number

                            xlNewSheet11.Range["C" + Y, "C" + Y].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet11.Range["C" + Y, "C" + Y].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet11.Range["C" + Y, "C" + Y].Font.Name = "Calibri";
                            xlNewSheet11.Range["C" + Y, "C" + Y].Font.Size = 11;
                            xlNewSheet11.Range["C" + Y, "C" + Y].Font.FontStyle = "Regular";//Style number


                            xlNewSheet11.Range["D" + Y, "D" + Y].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet11.Range["D" + Y, "D" + Y].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet11.Range["D" + Y, "D" + Y].Font.Name = "Calibri";
                            xlNewSheet11.Range["D" + Y, "D" + Y].Font.Size = 9;
                            xlNewSheet11.Range["D" + Y, "D" + Y].Font.FontStyle = "Regular";//Line Number


                            xlNewSheet11.Range["E" + Y, "E" + Y].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet11.Range["E" + Y, "E" + Y].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet11.Range["E" + Y, "E" + Y].Font.Name = "Calibri";
                            xlNewSheet11.Range["E" + Y, "E" + Y].Font.Size = 9;
                            xlNewSheet11.Range["E" + Y, "E" + Y].Font.FontStyle = "Regular";//ContractNumber

                            xlNewSheet11.Range["F" + Y, "F" + Y].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet11.Range["F" + Y, "F" + Y].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet11.Range["F" + Y, "F" + Y].Font.Name = "Calibri";
                            xlNewSheet11.Range["F" + Y, "F" + Y].Font.Size = 8;
                            xlNewSheet11.Range["F" + Y, "F" + Y].Font.FontStyle = "Regular";//Fabric1

                            xlNewSheet11.Range["G" + Y, "G" + Y].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet11.Range["G" + Y, "G" + Y].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet11.Range["G" + Y, "G" + Y].Font.Name = "Calibri";
                            xlNewSheet11.Range["G" + Y, "G" + Y].Font.Size = 8;
                            xlNewSheet11.Range["G" + Y, "G" + Y].Font.FontStyle = "Regular";//Colour/Print

                            xlNewSheet11.Range["H" + Y, "H" + Y].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet11.Range["H" + Y, "H" + Y].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet11.Range["H" + Y, "H" + Y].Font.Name = "Calibri";
                            xlNewSheet11.Range["H" + Y, "H" + Y].Font.Size = 8;
                            xlNewSheet11.Range["H" + Y, "H" + Y].Font.FontStyle = "Regular";//Weight 


                            xlNewSheet11.Range["I" + Y, "I" + Y].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet11.Range["I" + Y, "I" + Y].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet11.Range["I" + Y, "I" + Y].Font.Name = "Calibri";
                            xlNewSheet11.Range["I" + Y, "I" + Y].Font.Size = 12;
                            xlNewSheet11.Range["I" + Y, "I" + Y].Font.FontStyle = "Bold";//Quantity

                            xlNewSheet11.Range["J" + Y, "J" + Y].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet11.Range["J" + Y, "J" + Y].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet11.Range["J" + Y, "J" + Y].Font.Name = "Calibri";
                            xlNewSheet11.Range["J" + Y, "J" + Y].Font.Size = 9;
                            xlNewSheet11.Range["J" + Y, "J" + Y].Font.FontStyle = "Regular";//PcsStitche

                            xlNewSheet11.Range["K" + Y, "K" + Y].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet11.Range["K" + Y, "K" + Y].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet11.Range["K" + Y, "K" + Y].Font.Name = "Calibri";
                            xlNewSheet11.Range["K" + Y, "K" + Y].Font.Size = 9;
                            xlNewSheet11.Range["K" + Y, "K" + Y].Font.FontStyle = "Regular";//Value in

                            xlNewSheet11.Range["L" + Y, "L" + Y].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet11.Range["L" + Y, "L" + Y].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet11.Range["L" + Y, "L" + Y].Font.Name = "Calibri";
                            xlNewSheet11.Range["L" + Y, "L" + Y].Font.Size = 8;
                            xlNewSheet11.Range["L" + Y, "L" + Y].Font.FontStyle = "Regular";//TOP Status

                            xlNewSheet11.Range["M" + Y, "M" + Y].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet11.Range["M" + Y, "M" + Y].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet11.Range["M" + Y, "M" + Y].Font.Name = "Calibri";
                            xlNewSheet11.Range["M" + Y, "M" + Y].Font.Size = 12;
                            xlNewSheet11.Range["M" + Y, "M" + Y].Font.FontStyle = "Bold";//Quantity

                            xlNewSheet11.Range["N" + Y, "N" + Y].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet11.Range["N" + Y, "N" + Y].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet11.Range["N" + Y, "N" + Y].Font.Name = "Calibri";
                            xlNewSheet11.Range["N" + Y, "N" + Y].Font.Size = 9;
                            xlNewSheet11.Range["N" + Y, "N" + Y].Font.FontStyle = "Regular";//DeliveryMode

                            xlNewSheet11.Range["O" + Y, "O" + Y].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet11.Range["O" + Y, "O" + Y].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet11.Range["O" + Y, "O" + Y].Font.Name = "Calibri";
                            xlNewSheet11.Range["O" + Y, "O" + Y].Font.Size = 12;
                            xlNewSheet11.Range["O" + Y, "O" + Y].Font.FontStyle = "Bold";//ExFactory

                            xlNewSheet11.Range["P" + Y, "P" + Y].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet11.Range["P" + Y, "P" + Y].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet11.Range["P" + Y, "P" + Y].Font.Name = "Calibri";
                            xlNewSheet11.Range["P" + Y, "P" + Y].Font.Size = 11;
                            xlNewSheet11.Range["P" + Y, "P" + Y].Font.FontStyle = "Regular";//DC

                            xlNewSheet11.Range["Q" + Y, "Q" + Y].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet11.Range["Q" + Y, "Q" + Y].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet11.Range["Q" + Y, "Q" + Y].Font.Name = "Calibri";
                            xlNewSheet11.Range["Q" + Y, "Q" + Y].Font.Size = 10;
                            xlNewSheet11.Range["Q" + Y, "Q" + Y].Font.FontStyle = "Regular";//Booking Status

                            xlNewSheet11.Range["R" + Y, "R" + Y].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet11.Range["R" + Y, "R" + Y].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet11.Range["R" + Y, "R" + Y].Font.Name = "Calibri";
                            xlNewSheet11.Range["R" + Y, "R" + Y].Font.Size = 10;
                            xlNewSheet11.Range["R" + Y, "R" + Y].Font.FontStyle = "Regular";//Start Date


                            xlNewSheet11.Range["S" + Y, "S" + Y].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet11.Range["S" + Y, "S" + Y].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet11.Range["S" + Y, "S" + Y].Font.Name = "Calibri";
                            xlNewSheet11.Range["S" + Y, "S" + Y].Font.Size = 10;
                            xlNewSheet11.Range["S" + Y, "S" + Y].Font.FontStyle = "Regular";//End Date

                            xlNewSheet11.Range["T" + Y, "T" + Y].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet11.Range["T" + Y, "T" + Y].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet11.Range["T" + Y, "T" + Y].Font.Name = "Calibri";
                            xlNewSheet11.Range["T" + Y, "T" + Y].Font.Size = 10;
                            xlNewSheet11.Range["T" + Y, "T" + Y].Font.FontStyle = "Regular";//Ship Plan Date

                            xlNewSheet11.Range["U" + Y, "U" + Y].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet11.Range["U" + Y, "U" + Y].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet11.Range["U" + Y, "U" + Y].Font.Name = "Calibri";
                            xlNewSheet11.Range["U" + Y, "U" + Y].Font.Size = 11;
                            xlNewSheet11.Range["U" + Y, "U" + Y].Font.FontStyle = "Regular";//Line Plan

                            xlNewSheet11.Range["V" + Y, "V" + Y].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet11.Range["V" + Y, "V" + Y].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet11.Range["V" + Y, "V" + Y].Font.Name = "Calibri";
                            xlNewSheet11.Range["V" + Y, "V" + Y].Font.Size = 10;
                            xlNewSheet11.Range["V" + Y, "V" + Y].Font.FontStyle = "Regular";//UnitName

                            xlNewSheet11.Range["W" + Y, "W" + Y].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet11.Range["W" + Y, "W" + Y].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet11.Range["W" + Y, "W" + Y].Font.Name = "Calibri";
                            xlNewSheet11.Range["W" + Y, "W" + Y].Font.Size = 10;
                            xlNewSheet11.Range["W" + Y, "W" + Y].Font.FontStyle = "Regular";//Remark


                            R++;
                            Y++;
                        }
                        xlNewSheet11.Range["A1", "A1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        xlNewSheet11.Range["A1", "A1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet11.Range["A1", "A1"].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        xlNewSheet11.Range["A1", "A1"].Font.Bold = false;
                        xlNewSheet11.Range["A1", "A1"].Font.Name = "Calibri";
                        xlNewSheet11.Range["A1", "A1"].Font.Size = 8;
                        xlNewSheet11.Range["A1", "A1"].Font.FontStyle = "Regular";


                        xlNewSheet11.Range["B1", "B1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        xlNewSheet11.Range["B1", "B1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet11.Range["B1", "B1"].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        xlNewSheet11.Range["B1", "B1"].Font.Bold = false;
                        xlNewSheet11.Range["B1", "B1"].Font.Name = "Calibri";
                        xlNewSheet11.Range["B1", "B1"].Font.Size = 11;
                        xlNewSheet11.Range["B1", "B1"].Font.FontStyle = "Regular";

                        xlNewSheet11.Range["C1", "C1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        xlNewSheet11.Range["C1", "C1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet11.Range["C1", "C1"].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        xlNewSheet11.Range["C1", "C1"].Font.Bold = false;
                        xlNewSheet11.Range["C1", "C1"].Font.Name = "Calibri";
                        xlNewSheet11.Range["C1", "C1"].Font.Size = 11;
                        xlNewSheet11.Range["C1", "C1"].Font.FontStyle = "Regular";

                        xlNewSheet11.Range["D1", "D1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        xlNewSheet11.Range["D1", "D1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet11.Range["D1", "D1"].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        xlNewSheet11.Range["D1", "D1"].Font.Bold = false;
                        xlNewSheet11.Range["D1", "D1"].Font.Name = "Calibri";
                        xlNewSheet11.Range["D1", "D1"].Font.Size = 9;
                        xlNewSheet11.Range["D1", "D1"].Font.FontStyle = "Regular";

                        xlNewSheet11.Range["E1", "E1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        xlNewSheet11.Range["E1", "E1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet11.Range["E1", "E1"].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        xlNewSheet11.Range["E1", "E1"].Font.Bold = false;
                        xlNewSheet11.Range["E1", "E1"].Font.Name = "Calibri";
                        xlNewSheet11.Range["E1", "E1"].Font.Size = 9;
                        xlNewSheet11.Range["E1", "E1"].Font.FontStyle = "Regular";


                        xlNewSheet11.Range["F1", "F1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        xlNewSheet11.Range["F1", "F1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet11.Range["F1", "F1"].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        xlNewSheet11.Range["F1", "F1"].Font.Bold = false;
                        xlNewSheet11.Range["F1", "F1"].Font.Name = "Calibri";
                        xlNewSheet11.Range["F1", "F1"].Font.Size = 8;
                        xlNewSheet11.Range["F1", "F1"].Font.FontStyle = "Regular";


                        xlNewSheet11.Range["G1", "G1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        xlNewSheet11.Range["G1", "G1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet11.Range["G1", "G1"].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        xlNewSheet11.Range["G1", "G1"].Font.Bold = false;
                        xlNewSheet11.Range["G1", "G1"].Font.Name = "Calibri";
                        xlNewSheet11.Range["G1", "G1"].Font.Size = 8;
                        xlNewSheet11.Range["G1", "G1"].Font.FontStyle = "Regular";

                        xlNewSheet11.Range["H1", "H1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        xlNewSheet11.Range["H1", "H1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet11.Range["H1", "H1"].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        xlNewSheet11.Range["H1", "H1"].Font.Bold = false;
                        xlNewSheet11.Range["H1", "H1"].Font.Name = "Calibri";
                        xlNewSheet11.Range["H1", "H1"].Font.Size = 8;
                        xlNewSheet11.Range["H1", "H1"].Font.FontStyle = "Regular";


                        xlNewSheet11.Range["I1", "I1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        xlNewSheet11.Range["I1", "I1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet11.Range["I1", "I1"].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        xlNewSheet11.Range["I1", "I1"].Font.Bold = false;
                        xlNewSheet11.Range["I1", "I1"].Font.Name = "Calibri";
                        xlNewSheet11.Range["I1", "I1"].Font.Size = 12;
                        xlNewSheet11.Range["I1", "I1"].Font.FontStyle = "Bold";

                        xlNewSheet11.Range["J1", "J1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        xlNewSheet11.Range["J1", "J1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet11.Range["J1", "J1"].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        xlNewSheet11.Range["J1", "J1"].Font.Bold = false;
                        xlNewSheet11.Range["J1", "J1"].Font.Name = "Calibri";
                        xlNewSheet11.Range["J1", "J1"].Font.Size = 9;
                        xlNewSheet11.Range["J1", "J1"].Font.FontStyle = "Regular";

                        xlNewSheet11.Range["K1", "K1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        xlNewSheet11.Range["K1", "K1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet11.Range["K1", "K1"].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        xlNewSheet11.Range["K1", "K1"].Font.Bold = false;
                        xlNewSheet11.Range["K1", "K1"].Font.Name = "Calibri";
                        xlNewSheet11.Range["K1", "K1"].Font.Size = 8;
                        xlNewSheet11.Range["K1", "K1"].Font.FontStyle = "Regular";

                        xlNewSheet11.Range["L1", "L1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        xlNewSheet11.Range["L1", "L1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet11.Range["L1", "L1"].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        xlNewSheet11.Range["L1", "L1"].Font.Bold = false;
                        xlNewSheet11.Range["L1", "L1"].Font.Name = "Calibri";
                        xlNewSheet11.Range["L1", "L1"].Font.Size = 8;
                        xlNewSheet11.Range["L1", "L1"].Font.FontStyle = "Regular";

                        xlNewSheet11.Range["M1", "M1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        xlNewSheet11.Range["M1", "M1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet11.Range["M1", "M1"].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        xlNewSheet11.Range["M1", "M1"].Font.Bold = false;
                        xlNewSheet11.Range["M1", "M1"].Font.Name = "Calibri";
                        xlNewSheet11.Range["M1", "M1"].Font.Size = 12;
                        xlNewSheet11.Range["M1", "M1"].Font.FontStyle = "Calibri";
                        xlNewSheet11.Range["M1", "M1"].Font.FontStyle = "Bold";


                        xlNewSheet11.Range["N1", "N1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        xlNewSheet11.Range["N1", "N1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet11.Range["N1", "N1"].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        xlNewSheet11.Range["N1", "N1"].Font.Bold = false;
                        xlNewSheet11.Range["N1", "N1"].Font.Name = "Calibri";
                        xlNewSheet11.Range["N1", "N1"].Font.Size = 11;
                        xlNewSheet11.Range["N1", "N1"].Font.FontStyle = "Regular";

                        xlNewSheet11.Range["O1", "O1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        xlNewSheet11.Range["O1", "O1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet11.Range["O1", "O1"].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        xlNewSheet11.Range["O1", "O1"].Font.Bold = false;
                        xlNewSheet11.Range["O1", "O1"].Font.Name = "Calibri";
                        xlNewSheet11.Range["O1", "O1"].Font.Size = 10;
                        xlNewSheet11.Range["O1", "O1"].Font.FontStyle = "Regular";

                        xlNewSheet11.Range["P1", "P1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        xlNewSheet11.Range["P1", "P1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet11.Range["P1", "P1"].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        xlNewSheet11.Range["P1", "P1"].Font.Bold = false;
                        xlNewSheet11.Range["P1", "P1"].Font.Name = "Calibri";
                        xlNewSheet11.Range["P1", "P1"].Font.Size = 12;
                        xlNewSheet11.Range["P1", "P1"].Font.FontStyle = "Regular";


                        xlNewSheet11.Range["Q1", "Q1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        xlNewSheet11.Range["Q1", "Q1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet11.Range["Q1", "Q1"].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        xlNewSheet11.Range["Q1", "Q1"].Font.Bold = false;
                        xlNewSheet11.Range["Q1", "Q1"].Font.Name = "Calibri";
                        xlNewSheet11.Range["Q1", "Q1"].Font.Size = 10;
                        xlNewSheet11.Range["Q1", "Q1"].Font.FontStyle = "Regular";


                        xlNewSheet11.Range["R1", "R1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        xlNewSheet11.Range["R1", "R1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet11.Range["R1", "R1"].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        xlNewSheet11.Range["R1", "R1"].Font.Bold = false;
                        xlNewSheet11.Range["R1", "R1"].Font.Name = "Calibri";
                        xlNewSheet11.Range["R1", "R1"].Font.Size = 10;
                        xlNewSheet11.Range["R1", "R1"].Font.FontStyle = "Regular";

                        xlNewSheet11.Range["S1", "S1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        xlNewSheet11.Range["S1", "S1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet11.Range["S1", "S1"].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        xlNewSheet11.Range["S1", "S1"].Font.Bold = false;
                        xlNewSheet11.Range["S1", "S1"].Font.Name = "Calibri";
                        xlNewSheet11.Range["S1", "S1"].Font.Size = 10;
                        xlNewSheet11.Range["S1", "S1"].Font.FontStyle = "Regular";

                        xlNewSheet11.Range["T1", "T1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        xlNewSheet11.Range["T1", "T1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet11.Range["T1", "T1"].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        xlNewSheet11.Range["T1", "T1"].Font.Bold = false;
                        xlNewSheet11.Range["T1", "T1"].Font.Name = "Calibri";
                        xlNewSheet11.Range["T1", "T1"].Font.Size = 11;
                        xlNewSheet11.Range["T1", "T1"].Font.FontStyle = "Regular";


                        xlNewSheet11.Range["U1", "U1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        xlNewSheet11.Range["U1", "U1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet11.Range["U1", "U1"].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        xlNewSheet11.Range["U1", "U1"].Font.Bold = false;
                        xlNewSheet11.Range["U1", "U1"].Font.Name = "Calibri";
                        xlNewSheet11.Range["U1", "U1"].Font.Size = 11;
                        xlNewSheet11.Range["U1", "U1"].Font.FontStyle = "Regular";


                        xlNewSheet11.Range["V1", "V1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        xlNewSheet11.Range["V1", "V1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet11.Range["V1", "V1"].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        xlNewSheet11.Range["V1", "V1"].Font.Bold = false;
                        xlNewSheet11.Range["V1", "V1"].Font.Name = "Calibri";
                        xlNewSheet11.Range["V1", "V1"].Font.Size = 9;
                        xlNewSheet11.Range["V1", "V1"].Font.FontStyle = "Regular";

                        xlNewSheet11.Range["W1", "W1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        xlNewSheet11.Range["W1", "W1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet11.Range["W1", "W1"].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        xlNewSheet11.Range["W1", "W1"].Font.Bold = false;
                        xlNewSheet11.Range["W1", "W1"].Font.Name = "Calibri";
                        xlNewSheet11.Range["W1", "W1"].Font.Size = 9;
                        xlNewSheet11.Range["W1", "W1"].Font.FontStyle = "Regular";


                        xlNewSheet11.Range["A1", "V1"].RowHeight = 32;
                        xlNewSheet11.Columns.AutoFit();
                        xlNewSheet11.Range["M1"].Cells.EntireColumn.NumberFormat = "d mmm (ddd);@";
                        xlNewSheet11.Range["N1"].Cells.EntireColumn.NumberFormat = "d mmm (ddd);@";
                        xlNewSheet11.Range["P1"].Cells.EntireColumn.NumberFormat = "d mmm (ddd);@";
                        xlNewSheet11.Range["Q1"].Cells.EntireColumn.NumberFormat = "d mmm (ddd);@";
                        xlNewSheet11.Range["R1"].Cells.EntireColumn.NumberFormat = "d mmm (ddd);@";
                        xlNewSheet11.Range["V1"].Cells.EntireColumn.NumberFormat = "d mmm (ddd);@";
                        xlNewSheet11.Range["W1"].Cells.EntireColumn.NumberFormat = "d mmm (ddd);@";
                        //xlNewSheet11.Range["A1", "T1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        //xlNewSheet11.Range["A1", "T1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        //xlNewSheet11.Range["A1", "T1"].Font.Bold = true;

                        //xlNewSheet11.Range["A1", "T1"].Font.Name = "Calibri";
                        //xlNewSheet11.Range["A1", "T1"].Font.Size = 6;



                        releaseObject(xlNewSheet11);
                        ((Excel.Worksheet)xlApp.ActiveWorkbook.Sheets[1]).Activate();

                    }

                }
                if (ReportType == "Sampling-status")//abhishek 23 march
                {
                    // iKandi.Common.Constants.WorkSheetCount_ForExcel = iKandi.Common.Constants.WorkSheetCount_ForExcel + 1;
                    GlobalType_Upcomming_Exfactory = GlobalType_Upcomming_Exfactory + 1;
                    var xlNewSheet11 = (Excel.Worksheet)worksheets.Add(worksheets[GlobalType_Upcomming_Exfactory], Type.Missing, Type.Missing, Type.Missing);



                    xlNewSheet11.Name = "Sampling-status";

                    xlNewSheet11.Cells[1, 1] = "Client Code";
                    xlNewSheet11.Cells[1, 2] = "Department Name";
                    xlNewSheet11.Cells[1, 3] = "Style Created Date";
                    xlNewSheet11.Cells[1, 4] = "Style Number";
                    xlNewSheet11.Cells[1, 5] = "Style Type";
                    xlNewSheet11.Cells[1, 6] = "HandOver ETA";
                    xlNewSheet11.Cells[1, 7] = "HandOver Actual Date";
                    xlNewSheet11.Cells[1, 8] = "PatternReady ETA";
                    xlNewSheet11.Cells[1, 9] = "PatternReady Actual Date";
                    xlNewSheet11.Cells[1, 10] = "SampleSent ETA";
                    xlNewSheet11.Cells[1, 11] = "SampleSent Actual Date";
                    xlNewSheet11.Cells[1, 12] = "PreOrder CurrentStatus";
                    xlNewSheet11.Cells[1, 13] = "Delay";
                    xlNewSheet11.Cells[1, 14] = "Remarks";
                    xlNewSheet11.Cells[1, 15] = "PD";
                    xlNewSheet11.Cells[1, 16] = "Delay Remarks";
                    xlNewSheet11.Cells[1, 17] = "Designer Name";
                    if (ds.Tables[0].Rows.Count == 0)
                    {
                        return false;
                    }
                    else if (ds.Tables[0].Rows.Count > 0)
                    {
                        int R = 1;
                        int Y = 2;
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            string sampleType = dr["SampleType"] == DBNull.Value ? string.Empty : Convert.ToString(dr["SampleType"]);
                            xlNewSheet11.Cells[R + 1, 1] = dr["ClientCode"] == DBNull.Value ? string.Empty : Convert.ToString(dr["ClientCode"]);
                            xlNewSheet11.Cells[R + 1, 2] = dr["DepartmentName"] == DBNull.Value ? string.Empty : Convert.ToString(dr["DepartmentName"]);
                            xlNewSheet11.Cells[R + 1, 3] = (dr["StyleCreatedDate"] == DBNull.Value || Convert.ToString(dr["StyleCreatedDate"]) == "") ? string.Empty : dr["StyleCreatedDate"];
                            xlNewSheet11.Cells[R + 1, 4] = dr["StyleNumber"] == DBNull.Value ? string.Empty : Convert.ToString(dr["StyleNumber"]);
                            xlNewSheet11.Cells[R + 1, 5] = dr["SampleType"] == DBNull.Value ? string.Empty : Convert.ToString(dr["SampleType"]);
                            xlNewSheet11.Cells[R + 1, 6] = (dr["HanOverETA"] == DBNull.Value || Convert.ToString(dr["HanOverETA"]) == "") ? string.Empty : dr["HanOverETA"];
                            xlNewSheet11.Cells[R + 1, 7] = (dr["HanOverActual"] == DBNull.Value || Convert.ToString(dr["HanOverActual"]) == "") ? string.Empty : dr["HanOverActual"];
                            xlNewSheet11.Cells[R + 1, 8] = (dr["PatternReadyETA"] == DBNull.Value || Convert.ToString(dr["PatternReadyETA"]) == "") ? string.Empty : dr["PatternReadyETA"];
                            xlNewSheet11.Cells[R + 1, 9] = (dr["PatternReadyActual"] == DBNull.Value || Convert.ToString(dr["PatternReadyActual"]) == "") ? string.Empty : dr["PatternReadyActual"];
                            if (sampleType == "Pattern Based")
                            {
                                xlNewSheet11.Cells[R + 1, 10] = "";
                                xlNewSheet11.Cells[R + 1, 11] = "";
                            }
                            else
                            {

                                xlNewSheet11.Cells[R + 1, 10] = (dr["SampleSentETA"] == DBNull.Value || Convert.ToString(dr["SampleSentETA"]) == "") ? string.Empty : dr["SampleSentETA"];
                                xlNewSheet11.Cells[R + 1, 11] = (dr["SampleSentActual"] == DBNull.Value || Convert.ToString(dr["SampleSentActual"]) == "") ? string.Empty : dr["SampleSentActual"];
                            }

                            xlNewSheet11.Cells[R + 1, 12] = dr["PreOrderCurrentStatus"] == DBNull.Value ? string.Empty : Convert.ToString(dr["PreOrderCurrentStatus"]);
                            if (sampleType == "Pattern Based")
                            {
                                xlNewSheet11.Cells[R + 1, 13] = "";
                            }
                            else
                            {
                                xlNewSheet11.Cells[R + 1, 13] = dr["SamplesentDelay"] == DBNull.Value ? "N/A" : Convert.ToString(dr["SamplesentDelay"]);
                            }

                            string remarks = dr["Remarks"].ToString();
                            xlNewSheet11.Cells[R + 1, 14] = Get_Remarks(remarks);
                            xlNewSheet11.Cells[R + 1, 15] = dr["PD"] == DBNull.Value ? string.Empty : Convert.ToString(dr["PD"]);
                            string commentes = dr["Commentes"].ToString();
                            xlNewSheet11.Cells[R + 1, 16] = Get_Remarks(commentes);
                            xlNewSheet11.Cells[R + 1, 17] = dr["DesignerName"] == DBNull.Value ? string.Empty : Convert.ToString(dr["DesignerName"]);
                            xlNewSheet11.Range["A1", "A1"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;

                            xlNewSheet11.Range["B1", "B1"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["C1", "C1"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["D1", "D1"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["E1", "E1"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["F1", "F1"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["G1", "G1"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["H1", "H1"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["I1", "I1"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["J1", "J1"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["K1", "K1"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["L1", "L1"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["M1", "M1"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["N1", "N1"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["O1", "O1"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["P1", "P1"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["Q1", "Q1"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["A" + Y, "A" + Y].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["B" + Y, "B" + Y].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["C" + Y, "C" + Y].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["D" + Y, "D" + Y].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["E" + Y, "E" + Y].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["F" + Y, "F" + Y].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["G" + Y, "G" + Y].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["H" + Y, "H" + Y].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["I" + Y, "I" + Y].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["J" + Y, "J" + Y].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["K" + Y, "K" + Y].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["L" + Y, "L" + Y].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["M" + Y, "M" + Y].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["N" + Y, "N" + Y].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["O" + Y, "O" + Y].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["P" + Y, "P" + Y].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet11.Range["Q" + Y, "Q" + Y].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;




                            xlNewSheet11.Range["A" + Y, "A" + Y].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet11.Range["A" + Y, "A" + Y].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet11.Range["A" + Y, "A" + Y].Font.Name = "Calibri";
                            xlNewSheet11.Range["A" + Y, "A" + Y].Font.Size = 11;
                            xlNewSheet11.Range["A" + Y, "A" + Y].Font.FontStyle = "Regular";
                            xlNewSheet11.Range["A" + Y, "A" + Y].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Gray);

                            xlNewSheet11.Range["B" + Y, "B" + Y].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet11.Range["B" + Y, "B" + Y].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet11.Range["B" + Y, "B" + Y].Font.Name = "Calibri";
                            xlNewSheet11.Range["B" + Y, "B" + Y].Font.Size = 11;
                            xlNewSheet11.Range["B" + Y, "B" + Y].Font.FontStyle = "Regular";

                            xlNewSheet11.Range["C" + Y, "C" + Y].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet11.Range["C" + Y, "C" + Y].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet11.Range["C" + Y, "C" + Y].Font.Name = "Calibri";
                            xlNewSheet11.Range["C" + Y, "C" + Y].Font.Size = 11;
                            xlNewSheet11.Range["C" + Y, "C" + Y].Font.FontStyle = "Regular";


                            xlNewSheet11.Range["D" + Y, "D" + Y].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet11.Range["D" + Y, "D" + Y].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet11.Range["D" + Y, "D" + Y].Font.Name = "Calibri";
                            xlNewSheet11.Range["D" + Y, "D" + Y].Font.Size = 11;
                            xlNewSheet11.Range["D" + Y, "D" + Y].Font.FontStyle = "Bold";


                            xlNewSheet11.Range["E" + Y, "E" + Y].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet11.Range["E" + Y, "E" + Y].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet11.Range["E" + Y, "E" + Y].Font.Name = "Calibri";
                            xlNewSheet11.Range["E" + Y, "E" + Y].Font.Size = 11;
                            xlNewSheet11.Range["E" + Y, "E" + Y].Font.FontStyle = "Bold";


                            xlNewSheet11.Range["F" + Y, "F" + Y].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet11.Range["F" + Y, "F" + Y].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet11.Range["F" + Y, "F" + Y].Font.Name = "Calibri";
                            xlNewSheet11.Range["F" + Y, "F" + Y].Font.Size = 11;
                            xlNewSheet11.Range["F" + Y, "F" + Y].Font.FontStyle = "Regular";
                            xlNewSheet11.Range["F" + Y, "F" + Y].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Gray);

                            xlNewSheet11.Range["G" + Y, "G" + Y].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet11.Range["G" + Y, "G" + Y].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet11.Range["G" + Y, "G" + Y].Font.Name = "Calibri";
                            xlNewSheet11.Range["G" + Y, "G" + Y].Font.Size = 11;
                            xlNewSheet11.Range["G" + Y, "G" + Y].Font.FontStyle = "Regular";


                            xlNewSheet11.Range["H" + Y, "H" + Y].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet11.Range["H" + Y, "H" + Y].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet11.Range["H" + Y, "H" + Y].Font.Name = "Calibri";
                            xlNewSheet11.Range["H" + Y, "H" + Y].Font.Size = 11;
                            xlNewSheet11.Range["H" + Y, "H" + Y].Font.FontStyle = "Regular";
                            xlNewSheet11.Range["H" + Y, "H" + Y].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Gray);

                            xlNewSheet11.Range["I" + Y, "I" + Y].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet11.Range["I" + Y, "I" + Y].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet11.Range["I" + Y, "I" + Y].Font.Name = "Calibri";
                            xlNewSheet11.Range["I" + Y, "I" + Y].Font.Size = 11;
                            xlNewSheet11.Range["I" + Y, "I" + Y].Font.FontStyle = "Regular";
                            xlNewSheet11.Range["I" + Y, "I" + Y].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Gray);


                            xlNewSheet11.Range["J" + Y, "J" + Y].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet11.Range["J" + Y, "J" + Y].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet11.Range["J" + Y, "J" + Y].Font.Name = "Calibri";
                            xlNewSheet11.Range["J" + Y, "J" + Y].Font.Size = 11;
                            xlNewSheet11.Range["J" + Y, "J" + Y].Font.FontStyle = "Bold";


                            xlNewSheet11.Range["K" + Y, "K" + Y].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet11.Range["K" + Y, "K" + Y].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet11.Range["K" + Y, "K" + Y].Font.Name = "Calibri";
                            xlNewSheet11.Range["K" + Y, "K" + Y].Font.Size = 11;
                            xlNewSheet11.Range["K" + Y, "K" + Y].Font.FontStyle = "Regular";

                            xlNewSheet11.Range["L" + Y, "L" + Y].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet11.Range["L" + Y, "L" + Y].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet11.Range["L" + Y, "L" + Y].Font.Name = "Calibri";
                            xlNewSheet11.Range["L" + Y, "L" + Y].Font.Size = 11;
                            xlNewSheet11.Range["L" + Y, "L" + Y].Font.FontStyle = "Regular";
                            xlNewSheet11.Range["L" + Y, "L" + Y].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Gray);

                            xlNewSheet11.Range["M" + Y, "M" + Y].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet11.Range["M" + Y, "M" + Y].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet11.Range["M" + Y, "M" + Y].Font.Name = "Calibri";
                            xlNewSheet11.Range["M" + Y, "M" + Y].Font.Size = 11;
                            xlNewSheet11.Range["M" + Y, "M" + Y].EntireColumn.ColumnWidth = 100;
                            xlNewSheet11.Range["M" + Y, "M" + Y].Font.FontStyle = "Regular";
                            if (dr["SamplesentDelay"] == DBNull.Value)
                                xlNewSheet11.Range["M" + Y, "M" + Y].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Gray);
                            else if (Convert.ToDouble(dr["SamplesentDelay"]) < 0)
                                xlNewSheet11.Range["M" + Y, "M" + Y].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Green);
                            else
                                xlNewSheet11.Range["M" + Y, "M" + Y].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red);


                            xlNewSheet11.Range["N" + Y, "N" + Y].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                            xlNewSheet11.Range["N" + Y, "N" + Y].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet11.Range["N" + Y, "N" + Y].Font.Name = "Calibri";
                            xlNewSheet11.Range["N" + Y, "N" + Y].Font.Size = 11;
                            xlNewSheet11.Range["N" + Y, "N" + Y].EntireColumn.ColumnWidth = 100;
                            xlNewSheet11.Range["N" + Y, "N" + Y].Font.FontStyle = "Regular";
                            xlNewSheet11.Range["N" + Y, "N" + Y].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black);
                            xlNewSheet11.Range["N" + Y, "N" + Y].WrapText = true;

                            xlNewSheet11.Range["O" + Y, "O" + Y].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet11.Range["O" + Y, "O" + Y].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet11.Range["O" + Y, "O" + Y].Font.Name = "Calibri";
                            xlNewSheet11.Range["O" + Y, "O" + Y].Font.Size = 11;
                            xlNewSheet11.Range["O" + Y, "O" + Y].EntireColumn.ColumnWidth = 120;
                            xlNewSheet11.Range["O" + Y, "O" + Y].Font.FontStyle = "Regular";

                            xlNewSheet11.Range["P" + Y, "P" + Y].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                            xlNewSheet11.Range["P" + Y, "P" + Y].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet11.Range["P" + Y, "P" + Y].Font.Name = "Calibri";
                            xlNewSheet11.Range["P" + Y, "P" + Y].Font.Size = 11;
                            xlNewSheet11.Range["P" + Y, "P" + Y].EntireColumn.ColumnWidth = 100;
                            xlNewSheet11.Range["P" + Y, "P" + Y].Font.FontStyle = "Regular";
                            xlNewSheet11.Range["P" + Y, "P" + Y].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black);
                            xlNewSheet11.Range["P" + Y, "P" + Y].WrapText = true;

                            xlNewSheet11.Range["Q" + Y, "Q" + Y].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet11.Range["Q" + Y, "Q" + Y].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet11.Range["Q" + Y, "Q" + Y].Font.Name = "Calibri";
                            xlNewSheet11.Range["Q" + Y, "Q" + Y].Font.Size = 11;
                            xlNewSheet11.Range["Q" + Y, "Q" + Y].EntireColumn.ColumnWidth = 120;
                            xlNewSheet11.Range["Q" + Y, "Q" + Y].Font.FontStyle = "Regular";

                            // xlNewSheet11.Rows.WrapText = false;
                            xlApp.ActiveWindow.Zoom = 83;

                            R++;
                            Y++;
                        }
                        xlNewSheet11.Range["A1", "A1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        xlNewSheet11.Range["A1", "A1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet11.Range["A1", "A1"].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        xlNewSheet11.Range["A1", "A1"].Font.Bold = false;
                        xlNewSheet11.Range["A1", "A1"].Font.Name = "Calibri";
                        xlNewSheet11.Range["A1", "A1"].Font.Size = 11;
                        xlNewSheet11.Range["A1", "A1"].Font.FontStyle = "Bold";


                        xlNewSheet11.Range["B1", "B1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        xlNewSheet11.Range["B1", "B1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet11.Range["B1", "B1"].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        xlNewSheet11.Range["B1", "B1"].Font.Bold = false;
                        xlNewSheet11.Range["B1", "B1"].Font.Name = "Calibri";
                        xlNewSheet11.Range["B1", "B1"].Font.Size = 11;
                        xlNewSheet11.Range["B1", "B1"].Font.FontStyle = "Bold";

                        xlNewSheet11.Range["C1", "C1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        xlNewSheet11.Range["C1", "C1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet11.Range["C1", "C1"].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        xlNewSheet11.Range["C1", "C1"].Font.Bold = false;
                        xlNewSheet11.Range["C1", "C1"].Font.Name = "Calibri";
                        xlNewSheet11.Range["C1", "C1"].Font.Size = 11;
                        xlNewSheet11.Range["C1", "C1"].Font.FontStyle = "Bold";

                        xlNewSheet11.Range["D1", "D1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        xlNewSheet11.Range["D1", "D1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet11.Range["D1", "D1"].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        xlNewSheet11.Range["D1", "D1"].Font.Bold = false;
                        xlNewSheet11.Range["D1", "D1"].Font.Name = "Calibri";
                        xlNewSheet11.Range["D1", "D1"].Font.Size = 11;
                        xlNewSheet11.Range["D1", "D1"].Font.FontStyle = "Bold";

                        xlNewSheet11.Range["E1", "E1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        xlNewSheet11.Range["E1", "E1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet11.Range["E1", "E1"].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        xlNewSheet11.Range["E1", "E1"].Font.Bold = false;
                        xlNewSheet11.Range["E1", "E1"].Font.Name = "Calibri";
                        xlNewSheet11.Range["E1", "E1"].Font.Size = 11;
                        xlNewSheet11.Range["E1", "E1"].Font.FontStyle = "Bold";


                        xlNewSheet11.Range["F1", "F1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        xlNewSheet11.Range["F1", "F1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet11.Range["F1", "F1"].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        xlNewSheet11.Range["F1", "F1"].Font.Bold = false;
                        xlNewSheet11.Range["F1", "F1"].Font.Name = "Calibri";
                        xlNewSheet11.Range["F1", "F1"].Font.Size = 11;
                        xlNewSheet11.Range["F1", "F1"].Font.FontStyle = "Bold";


                        xlNewSheet11.Range["G1", "G1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        xlNewSheet11.Range["G1", "G1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet11.Range["G1", "G1"].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        xlNewSheet11.Range["G1", "G1"].Font.Bold = false;
                        xlNewSheet11.Range["G1", "G1"].Font.Name = "Calibri";
                        xlNewSheet11.Range["G1", "G1"].Font.Size = 11;
                        xlNewSheet11.Range["G1", "G1"].Font.FontStyle = "Bold";

                        xlNewSheet11.Range["H1", "H1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        xlNewSheet11.Range["H1", "H1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet11.Range["H1", "H1"].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        xlNewSheet11.Range["H1", "H1"].Font.Bold = false;
                        xlNewSheet11.Range["H1", "H1"].Font.Name = "Calibri";
                        xlNewSheet11.Range["H1", "H1"].Font.Size = 11;
                        xlNewSheet11.Range["H1", "H1"].Font.FontStyle = "Bold";


                        xlNewSheet11.Range["I1", "I1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        xlNewSheet11.Range["I1", "I1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet11.Range["I1", "I1"].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        xlNewSheet11.Range["I1", "I1"].Font.Bold = false;
                        xlNewSheet11.Range["I1", "I1"].Font.Name = "Calibri";
                        xlNewSheet11.Range["I1", "I1"].Font.Size = 11;
                        xlNewSheet11.Range["I1", "I1"].Font.FontStyle = "Bold";

                        xlNewSheet11.Range["J1", "J1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        xlNewSheet11.Range["J1", "J1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet11.Range["J1", "J1"].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        xlNewSheet11.Range["J1", "J1"].Font.Bold = false;
                        xlNewSheet11.Range["J1", "J1"].Font.Name = "Calibri";
                        xlNewSheet11.Range["J1", "J1"].Font.Size = 11;
                        xlNewSheet11.Range["J1", "J1"].Font.FontStyle = "Bold";

                        xlNewSheet11.Range["K1", "K1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        xlNewSheet11.Range["K1", "K1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet11.Range["K1", "K1"].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        xlNewSheet11.Range["K1", "K1"].Font.Bold = false;
                        xlNewSheet11.Range["K1", "K1"].Font.Name = "Calibri";
                        xlNewSheet11.Range["K1", "K1"].Font.Size = 11;
                        xlNewSheet11.Range["K1", "K1"].Font.FontStyle = "Bold";

                        xlNewSheet11.Range["L1", "L1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        xlNewSheet11.Range["L1", "L1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet11.Range["L1", "L1"].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        xlNewSheet11.Range["L1", "L1"].Font.Bold = false;
                        xlNewSheet11.Range["L1", "L1"].Font.Name = "Calibri";
                        xlNewSheet11.Range["L1", "L1"].Font.Size = 11;
                        xlNewSheet11.Range["L1", "L1"].Font.FontStyle = "Bold";

                        xlNewSheet11.Range["M1", "M1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        xlNewSheet11.Range["M1", "M1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet11.Range["M1", "M1"].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        xlNewSheet11.Range["M1", "M1"].Font.Bold = false;
                        xlNewSheet11.Range["M1", "M1"].Font.Name = "Calibri";
                        xlNewSheet11.Range["M1", "M1"].Font.Size = 11;
                        xlNewSheet11.Range["M1", "M1"].Font.FontStyle = "Bold";

                        xlNewSheet11.Range["N1", "N1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        xlNewSheet11.Range["N1", "N1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet11.Range["N1", "N1"].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        xlNewSheet11.Range["N1", "N1"].Font.Bold = false;
                        xlNewSheet11.Range["N1", "N1"].Font.Name = "Calibri";
                        xlNewSheet11.Range["N1", "N1"].Font.Size = 11;
                        xlNewSheet11.Range["N1", "N1"].Font.FontStyle = "Bold";

                        xlNewSheet11.Range["O1", "O1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        xlNewSheet11.Range["O1", "O1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet11.Range["O1", "O1"].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        xlNewSheet11.Range["O1", "O1"].Font.Bold = false;
                        xlNewSheet11.Range["O1", "O1"].Font.Name = "Calibri";
                        xlNewSheet11.Range["O1", "O1"].Font.Size = 11;
                        xlNewSheet11.Range["O1", "O1"].Font.FontStyle = "Bold";

                        xlNewSheet11.Range["P1", "P1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        xlNewSheet11.Range["P1", "P1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet11.Range["P1", "P1"].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        xlNewSheet11.Range["P1", "P1"].Font.Bold = false;
                        xlNewSheet11.Range["P1", "P1"].Font.Name = "Calibri";
                        xlNewSheet11.Range["P1", "P1"].Font.Size = 11;
                        xlNewSheet11.Range["P1", "P1"].Font.FontStyle = "Bold";

                        xlNewSheet11.Range["Q1", "Q1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        xlNewSheet11.Range["Q1", "Q1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet11.Range["Q1", "Q1"].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        xlNewSheet11.Range["Q1", "Q1"].Font.Bold = false;
                        xlNewSheet11.Range["Q1", "Q1"].Font.Name = "Calibri";
                        xlNewSheet11.Range["Q1", "Q1"].Font.Size = 11;
                        xlNewSheet11.Range["Q1", "Q1"].Font.FontStyle = "Bold";

                        xlNewSheet11.Range["A1", "V1"].RowHeight = 35;
                        xlNewSheet11.Range["C1"].Cells.EntireColumn.NumberFormat = "d mmm (ddd);@";
                        xlNewSheet11.Range["F1"].Cells.EntireColumn.NumberFormat = "d mmm (ddd);@";
                        xlNewSheet11.Range["G1"].Cells.EntireColumn.NumberFormat = "d mmm (ddd);@";
                        xlNewSheet11.Range["H1"].Cells.EntireColumn.NumberFormat = "d mmm (ddd);@";
                        xlNewSheet11.Range["I1"].Cells.EntireColumn.NumberFormat = "d mmm (ddd);@";
                        xlNewSheet11.Range["J1"].Cells.EntireColumn.NumberFormat = "d mmm (ddd);@";
                        xlNewSheet11.Range["K1"].Cells.EntireColumn.NumberFormat = "d mmm (ddd);@";
                        xlNewSheet11.Columns.AutoFit();

                        releaseObject(xlNewSheet11);
                        ((Excel.Worksheet)xlApp.ActiveWorkbook.Sheets[1]).Activate();

                    }

                }
                if (ReportType == "Cutting_OutHouse")
                {
                    // iKandi.Common.Constants.WorkSheetCount_ForExcel = iKandi.Common.Constants.WorkSheetCount_ForExcel + 1;
                    CultureInfo ci = new CultureInfo("en-IN");
                    ci.NumberFormat.CurrencySymbol = "₹";
                    GlobalCount = GlobalCount + 1;
                    var xlNewSheet12 = (Excel.Worksheet)worksheets.Add(worksheets[GlobalCount], Type.Missing, Type.Missing, Type.Missing);



                    xlNewSheet12.Name = "Cutting_OutHouse";
                    xlNewSheet12.Cells[1, 13] = "Cutting Detail";
                    xlNewSheet12.Cells[2, 1] = "Style Code";
                    xlNewSheet12.Cells[2, 2] = "Serial number";
                    xlNewSheet12.Cells[2, 3] = "Department Name";
                    xlNewSheet12.Cells[2, 4] = "Order Quantity";
                    xlNewSheet12.Cells[2, 5] = "Sealed Date";
                    xlNewSheet12.Cells[2, 6] = "Pattern Sample Date";
                    xlNewSheet12.Cells[2, 7] = "MinExFactory";
                    xlNewSheet12.Cells[2, 8] = "MaxExFactory";
                    xlNewSheet12.Cells[2, 9] = "SAM(Weighted)";
                    xlNewSheet12.Cells[2, 10] = "BIPL Budget";

                    xlNewSheet12.Cells[2, 11] = "Supplier1";
                    xlNewSheet12.Cells[2, 12] = "Cutting_1";
                    xlNewSheet12.Cells[2, 13] = "Supplier_2";
                    xlNewSheet12.Cells[2, 14] = "Cutting_2";
                    xlNewSheet12.Cells[2, 15] = "Supplier_3";
                    xlNewSheet12.Cells[2, 16] = "Cutting_3";
                    xlNewSheet12.Cells[2, 17] = "Supplier_4";
                    xlNewSheet12.Cells[2, 18] = "Cutting_4";
                    xlNewSheet12.Cells[2, 19] = "Supplier_5";
                    xlNewSheet12.Cells[2, 20] = "Cutting_5";




                    if (ds.Tables[0].Rows.Count == 0)
                    {
                        return false;
                    }
                    else if (ds.Tables[0].Rows.Count > 0)
                    {
                        int T = 2;
                        int U = 1;
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            //int IsVaFineLineCheck = 0;
                            //int IsVaFineLineCheck2 = 0;
                            //int IsVaFineLineCheck3 = 0;
                            //int IsVaFineLineCheck4 = 0;
                            //int IsVaFineLineCheck5 = 0;


                            int IsFinalOB = 0;
                            xlNewSheet12.Cells[T + 1, 1] = dr["StyleCode"] == DBNull.Value ? string.Empty : Convert.ToString(dr["StyleCode"]);
                            xlNewSheet12.Cells[T + 1, 2] = dr["SerialNumber"] == DBNull.Value ? string.Empty : Convert.ToString(dr["SerialNumber"]);
                            xlNewSheet12.Cells[T + 1, 3] = dr["DepartmentName"] == DBNull.Value ? string.Empty : Convert.ToString(dr["DepartmentName"]);
                            xlNewSheet12.Cells[T + 1, 4] = dr["Quantity"] == DBNull.Value ? string.Empty : Convert.ToInt32(dr["Quantity"]).ToString("N0");//added code by bharat on 12-12-19
                            xlNewSheet12.Cells[T + 1, 5] = dr["SealDate"] == DBNull.Value ? string.Empty : Convert.ToString(dr["SealDate"]);
                            xlNewSheet12.Cells[T + 1, 6] = dr["MinPatternsampleDate"] == DBNull.Value ? string.Empty : Convert.ToString(dr["MinPatternsampleDate"]);
                            xlNewSheet12.Cells[T + 1, 7] = dr["MinExfactory"] == DBNull.Value ? string.Empty : Convert.ToString(dr["MinExfactory"]);
                            xlNewSheet12.Cells[T + 1, 8] = dr["MaxExfactory"] == DBNull.Value ? string.Empty : Convert.ToString(dr["MaxExfactory"]);
                            xlNewSheet12.Cells[T + 1, 9] = dr["Sam"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Sam"]);
                            xlNewSheet12.Cells[T + 1, 10] = dr["biplbudget"] == DBNull.Value ? string.Empty : Convert.ToString(ci.NumberFormat.CurrencySymbol = "₹" + dr["biplbudget"]);



                            //xlNewSheet11.Cells[S + 1, 10].Color = System.Drawing.Color.AliceBlue;₹

                            xlNewSheet12.Cells[T + 1, 11] = dr["VA_Stch_Supplier_1"] == DBNull.Value ? string.Empty : Convert.ToString(dr["VA_Stch_Supplier_1"]);
                            xlNewSheet12.Cells[T + 1, 12] = dr["VA_Stch_Rate_1"] == DBNull.Value ? string.Empty : Convert.ToString(dr["VA_Stch_Rate_1"]);
                            xlNewSheet12.Cells[T + 1, 13] = dr["VA_Stch_Supplier_2"] == DBNull.Value ? string.Empty : Convert.ToString(dr["VA_Stch_Supplier_2"]);
                            xlNewSheet12.Cells[T + 1, 14] = dr["VA_Stch_Rate_2"] == DBNull.Value ? string.Empty : Convert.ToString(dr["VA_Stch_Rate_2"]);
                            xlNewSheet12.Cells[T + 1, 15] = dr["VA_Stch_Supplier_3"] == DBNull.Value ? string.Empty : Convert.ToString(dr["VA_Stch_Supplier_3"]);
                            xlNewSheet12.Cells[T + 1, 16] = dr["VA_Stch_Rate_3"] == DBNull.Value ? string.Empty : Convert.ToString(dr["VA_Stch_Rate_3"]);
                            xlNewSheet12.Cells[T + 1, 17] = dr["VA_Stch_Supplier_4"] == DBNull.Value ? string.Empty : Convert.ToString(dr["VA_Stch_Supplier_4"]);

                            xlNewSheet12.Cells[T + 1, 18] = dr["VA_Stch_Rate_4"] == DBNull.Value ? string.Empty : Convert.ToString(dr["VA_Stch_Rate_4"]);
                            xlNewSheet12.Cells[T + 1, 19] = dr["VA_Stch_Supplier_5"] == DBNull.Value ? string.Empty : Convert.ToString(dr["VA_Stch_Supplier_5"]);
                            xlNewSheet12.Cells[T + 1, 20] = dr["VA_Stch_Rate_5"] == DBNull.Value ? string.Empty : Convert.ToString(dr["VA_Stch_Rate_5"]);
                            IsFinalOB = dr["IsFinalOB"] == DBNull.Value ? 0 : Convert.ToInt32(dr["IsFinalOB"]);

                            U = T + 1;



                            xlNewSheet12.Range["A" + U, "A" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet12.Range["A" + U, "A" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet12.Range["A" + U, "A" + U].Font.Name = "Calibri";
                            xlNewSheet12.Range["A" + U, "A" + U].Font.Size = 11;
                            xlNewSheet12.Range["A" + U, "A" + U].Font.FontStyle = "Bold";



                            xlNewSheet12.Range["B" + U, "B" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet12.Range["B" + U, "B" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet12.Range["B" + U, "B" + U].Font.Name = "Calibri";
                            xlNewSheet12.Range["B" + U, "B" + U].Font.Size = 11;
                            xlNewSheet12.Range["B" + U, "B" + U].Font.FontStyle = "Bold";
                            xlNewSheet12.Range["B" + U, "B" + U].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.DarkBlue);




                            xlNewSheet12.Range["C" + U, "C" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet12.Range["C" + U, "C" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet12.Range["C" + U, "C" + U].Font.Name = "Calibri";
                            xlNewSheet12.Range["C" + U, "C" + U].Font.Size = 10;
                            xlNewSheet12.Range["C" + U, "C" + U].Font.FontStyle = "Ragular";

                            if (IsFinalOB == 0)
                            {
                                xlNewSheet12.Range["A" + U, "A" + U].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Red);

                                //xlNewSheet12.get_Range("A2", "A2").Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;

                            }

                            xlNewSheet12.Range["D" + U, "D" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet12.Range["D" + U, "D" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet12.Range["D" + U, "D" + U].Font.Name = "Calibri";
                            xlNewSheet12.Range["D" + U, "D" + U].Font.Size = 12;
                            xlNewSheet12.Range["D" + U, "D" + U].Font.FontStyle = "Bold";



                            xlNewSheet12.Range["E" + U, "E" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet12.Range["E" + U, "E" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet12.Range["E" + U, "E" + U].Font.Name = "Calibri";
                            xlNewSheet12.Range["E" + U, "E" + U].Font.Size = 10;
                            xlNewSheet12.Range["E" + U, "E" + U].Font.FontStyle = "Ragular";
                            xlNewSheet12.Range["E" + U, "E" + U].Font.FontStyle = "Bold";

                            xlNewSheet12.Range["F" + U, "F" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet12.Range["F" + U, "F" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet12.Range["F" + U, "F" + U].Font.Name = "Calibri";
                            xlNewSheet12.Range["F" + U, "F" + U].Font.Size = 10;
                            xlNewSheet12.Range["F" + U, "F" + U].Font.FontStyle = "Ragular";


                            xlNewSheet12.Range["G" + U, "G" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet12.Range["G" + U, "G" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet12.Range["G" + U, "G" + U].Font.Name = "Calibri";
                            xlNewSheet12.Range["G" + U, "G" + U].Font.Size = 10;
                            xlNewSheet12.Range["G" + U, "G" + U].Font.FontStyle = "Ragular";

                            xlNewSheet12.Range["H" + U, "H" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet12.Range["H" + U, "H" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet12.Range["H" + U, "H" + U].Font.Name = "Calibri";
                            xlNewSheet12.Range["H" + U, "H" + U].Font.Size = 10;
                            xlNewSheet12.Range["H" + U, "H" + U].Font.FontStyle = "Ragular";


                            xlNewSheet12.Range["I" + U, "I" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet12.Range["I" + U, "I" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet12.Range["I" + U, "I" + U].Font.Name = "Calibri";
                            xlNewSheet12.Range["I" + U, "I" + U].Font.Size = 10;
                            xlNewSheet12.Range["I" + U, "I" + U].Font.FontStyle = "Bold";

                            xlNewSheet12.Range["J" + U, "J" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet12.Range["J" + U, "J" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet12.Range["J" + U, "J" + U].Font.Name = "Calibri";
                            xlNewSheet12.Range["J" + U, "J" + U].Font.Size = 11;
                            xlNewSheet12.Range["J" + U, "J" + U].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red);
                            xlNewSheet12.Range["J" + U, "J" + U].Font.FontStyle = "Bold";


                            xlNewSheet12.Range["K" + U, "K" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet12.Range["K" + U, "K" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet12.Range["K" + U, "K" + U].Font.Name = "Calibri";
                            xlNewSheet12.Range["K" + U, "K" + U].Font.Size = 11;
                            xlNewSheet12.Range["K" + U, "K" + U].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.DarkBlue);
                            xlNewSheet12.Range["K" + U, "K" + U].Font.FontStyle = "Bold";

                            xlNewSheet12.Range["L" + U, "L" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet12.Range["L" + U, "L" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet12.Range["L" + U, "L" + U].Font.Name = "Calibri";
                            xlNewSheet12.Range["L" + U, "L" + U].Font.Size = 11;
                            xlNewSheet12.Range["L" + U, "L" + U].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Green);
                            xlNewSheet12.Range["L" + U, "L" + U].Font.FontStyle = "Bold";

                            xlNewSheet12.Range["M" + U, "M" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet12.Range["M" + U, "M" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet12.Range["M" + U, "M" + U].Font.Name = "Calibri";
                            xlNewSheet12.Range["M" + U, "M" + U].Font.Size = 11;
                            xlNewSheet12.Range["M" + U, "M" + U].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.DarkBlue);
                            xlNewSheet12.Range["M" + U, "M" + U].Font.FontStyle = "Bold";

                            xlNewSheet12.Range["N" + U, "N" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet12.Range["N" + U, "N" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet12.Range["N" + U, "N" + U].Font.Name = "Calibri";
                            xlNewSheet12.Range["N" + U, "N" + U].Font.Size = 11;
                            xlNewSheet12.Range["N" + U, "N" + U].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Green);
                            xlNewSheet12.Range["N" + U, "N" + U].Font.FontStyle = "Bold";

                            xlNewSheet12.Range["O" + U, "O" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet12.Range["O" + U, "O" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet12.Range["O" + U, "O" + U].Font.Name = "Calibri";
                            xlNewSheet12.Range["O" + U, "O" + U].Font.Size = 11;
                            xlNewSheet12.Range["O" + U, "O" + U].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.DarkBlue);
                            xlNewSheet12.Range["O" + U, "O" + U].Font.FontStyle = "Bold";

                            xlNewSheet12.Range["P" + U, "P" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet12.Range["P" + U, "P" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet12.Range["P" + U, "P" + U].Font.Name = "Calibri";
                            xlNewSheet12.Range["P" + U, "P" + U].Font.Size = 11;
                            xlNewSheet12.Range["P" + U, "P" + U].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Green);
                            xlNewSheet12.Range["P" + U, "P" + U].Font.FontStyle = "Bold";

                            xlNewSheet12.Range["Q" + U, "Q" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet12.Range["Q" + U, "Q" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet12.Range["Q" + U, "Q" + U].Font.Name = "Calibri";
                            xlNewSheet12.Range["Q" + U, "Q" + U].Font.Size = 11;
                            xlNewSheet12.Range["Q" + U, "Q" + U].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.DarkBlue);
                            xlNewSheet12.Range["Q" + U, "Q" + U].Font.FontStyle = "Bold";

                            xlNewSheet12.Range["R" + U, "R" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet12.Range["R" + U, "R" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet12.Range["R" + U, "R" + U].Font.Name = "Calibri";
                            xlNewSheet12.Range["R" + U, "R" + U].Font.Size = 11;
                            xlNewSheet12.Range["R" + U, "R" + U].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Green);
                            xlNewSheet12.Range["R" + U, "R" + U].Font.FontStyle = "Bold";

                            xlNewSheet12.Range["S" + U, "S" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet12.Range["S" + U, "S" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet12.Range["S" + U, "S" + U].Font.Name = "Calibri";
                            xlNewSheet12.Range["S" + U, "S" + U].Font.Size = 11;
                            xlNewSheet12.Range["S" + U, "S" + U].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.DarkBlue);
                            xlNewSheet12.Range["S" + U, "S" + U].Font.FontStyle = "Bold";

                            xlNewSheet12.Range["T" + U, "T" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet12.Range["T" + U, "T" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet12.Range["T" + U, "T" + U].Font.Name = "Calibri";
                            xlNewSheet12.Range["T" + U, "T" + U].Font.Size = 11;
                            xlNewSheet12.Range["T" + U, "T" + U].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Green);
                            xlNewSheet12.Range["T" + U, "T" + U].Font.FontStyle = "Bold";


                            //xlNewSheet12.Range["J" + U, "J" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            //xlNewSheet12.Range["J" + U, "J" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            //xlNewSheet12.Range["J" + U, "J" + U].Font.Name = "Calibri";
                            //xlNewSheet12.Range["J" + U, "J" + U].Font.Size = 12;
                            //xlNewSheet12.Range["J" + U, "J" + U].Font.FontStyle = "Bold";

                            //xlNewSheet12.Range["K2" + U, "K2" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            //xlNewSheet12.Range["K2" + U, "K2" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            //xlNewSheet12.Range["K2" + U, "K2" + U].Font.Name = "Calibri";
                            //xlNewSheet12.Range["K2" + U, "K2" + U].Font.Size = 10;
                            //xlNewSheet12.Range["K2" + U, "K2" + U].Font.FontStyle = "Ragular";

                            //xlNewSheet12.Range["L" + U, "L" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            //xlNewSheet12.Range["L" + U, "L" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            //xlNewSheet12.Range["L" + U, "L" + U].Font.Name = "Calibri";
                            //xlNewSheet12.Range["L" + U, "L" + U].Font.Size = 10;
                            //xlNewSheet12.Range["L" + U, "L" + U].Font.FontStyle = "Ragular";
                            //xlNewSheet12.Range["L" + U, "L" + U].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red);
                            //xlNewSheet12.Range["L" + U, "L" + U].Font.FontStyle = "Bold";




                            //xlNewSheet12.Range["M2" + U, "M2" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            //xlNewSheet12.Range["M2" + U, "M2" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            //xlNewSheet12.Range["M2" + U, "M2" + U].Font.Name = "Calibri";
                            //xlNewSheet12.Range["M2" + U, "M2" + U].Font.Size = 10;
                            //xlNewSheet12.Range["M2" + U, "M2" + U].Font.FontStyle = "Ragular";

                            //xlNewSheet12.Range["N2" + U, "N2" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            //xlNewSheet12.Range["N2" + U, "N2" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            //xlNewSheet12.Range["N2" + U, "N2" + U].Font.Name = "Calibri";
                            //xlNewSheet12.Range["N2" + U, "N2" + U].Font.Size = 10;
                            //xlNewSheet12.Range["N2" + U, "N2" + U].Font.FontStyle = "Ragular";


                            //xlNewSheet12.Range["O2" + U, "O2" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            //xlNewSheet12.Range["O2" + U, "O2" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            //xlNewSheet12.Range["O2" + U, "O2" + U].Font.Name = "Calibri";
                            //xlNewSheet12.Range["O2" + U, "O2" + U].Font.Size = 10;
                            //xlNewSheet12.Range["O2" + U, "O2" + U].Font.FontStyle = "Ragular";




                            T++;
                        }



                        xlNewSheet12.Columns.AutoFit();

                        xlNewSheet12.get_Range("A1", "A2").Merge();
                        xlNewSheet12.get_Range("B1", "B2").Merge();
                        xlNewSheet12.get_Range("C1", "C2").Merge();
                        xlNewSheet12.get_Range("D1", "D2").Merge();
                        xlNewSheet12.get_Range("E1", "E2").Merge();
                        xlNewSheet12.get_Range("F1", "F2").Merge();
                        xlNewSheet12.get_Range("G1", "G2").Merge();
                        xlNewSheet12.get_Range("H1", "H2").Merge();
                        xlNewSheet12.get_Range("I1", "I2").Merge();
                        xlNewSheet12.get_Range("J1", "J2").Merge();
                        //xlNewSheet12.get_Range("K1", "K2").Merge();

                        xlNewSheet12.Range["A1", "A2"].Font.Bold = true;
                        xlNewSheet12.Range["A1", "A2"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet12.Range["B1", "B2"].Font.Bold = true;
                        xlNewSheet12.Range["B1", "B2"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet12.Range["C1", "C2"].Font.Bold = true;
                        xlNewSheet12.Range["C1", "C2"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet12.Range["D1", "D2"].Font.Bold = true;
                        xlNewSheet12.Range["D1", "D2"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet12.Range["E1", "E2"].Font.Bold = true;
                        xlNewSheet12.Range["E1", "E2"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet12.Range["F1", "F2"].Font.Bold = true;
                        xlNewSheet12.Range["F1", "F2"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet12.Range["G1", "G2"].Font.Bold = true;
                        xlNewSheet12.Range["G1", "G2"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet12.Range["H1", "H2"].Font.Bold = true;
                        xlNewSheet12.Range["H1", "H2"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet12.Range["I1", "I2"].Font.Bold = true;
                        xlNewSheet12.Range["I1", "I2"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet12.Range["J1", "J2"].Font.Bold = true;
                        xlNewSheet12.Range["J1", "J2"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        //xlNewSheet12.Range["K1", "K2"].Font.Bold = true;
                        //xlNewSheet12.Range["K1", "K2"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                        xlNewSheet12.Range["A1", "T1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        xlNewSheet12.Range["A2", "T2"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        xlNewSheet12.Range["A1", "T1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                        xlNewSheet12.Range["A2", "T2"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                        xlNewSheet12.Range["A1", "T1"].EntireColumn.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet12.Range["A2", "T2"].EntireColumn.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet12.get_Range("A1:T" + T).Cells.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                        xlNewSheet12.get_Range("A2:T" + T).Cells.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;

                        xlNewSheet12.Range["E1"].Cells.EntireColumn.NumberFormat = "d mmm (ddd);@";
                        xlNewSheet12.Range["F1"].Cells.EntireColumn.NumberFormat = "d mmm (ddd);@";
                        xlNewSheet12.Range["G1"].Cells.EntireColumn.NumberFormat = "d mmm (ddd);@";
                        xlNewSheet12.Range["H1"].Cells.EntireColumn.NumberFormat = "d mmm (ddd);@";
                        xlNewSheet12.Range["J1"].Cells.EntireColumn.NumberFormat = "₹0.00";
                        xlNewSheet12.Range["L1"].Cells.EntireColumn.NumberFormat = "₹0.00";
                        xlNewSheet12.Range["N1"].Cells.EntireColumn.NumberFormat = "₹0.00";
                        xlNewSheet12.Range["P1"].Cells.EntireColumn.NumberFormat = "₹0.00";
                        xlNewSheet12.Range["R1"].Cells.EntireColumn.NumberFormat = "₹0.00";
                        xlNewSheet12.Range["T1"].Cells.EntireColumn.NumberFormat = "₹0.00";

                        xlNewSheet12.get_Range("K1", "T1").Merge();
                        xlNewSheet12.get_Range("K1", "T1").Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;



                        xlNewSheet12.Select();
                        ((Excel.Worksheet)xlApp.ActiveWorkbook.Sheets[1]).Activate();
                        releaseObject(xlNewSheet12);
                        //((Excel.Worksheet)xlApp.ActiveWorkbook.Sheets[1]).Activate();

                    }

                }
                if (ReportType == "Fabric_Average_Saving")
                {
                    // iKandi.Common.Constants.WorkSheetCount_ForExcel = iKandi.Common.Constants.WorkSheetCount_ForExcel + 1;
                    CultureInfo ci = new CultureInfo("en-IN");
                    ci.NumberFormat.CurrencySymbol = "₹";
                    GlobalCount = GlobalCount + 1;
                    var xlNewSheet12 = (Excel.Worksheet)worksheets.Add(worksheets[GlobalCount], Type.Missing, Type.Missing, Type.Missing);



                    xlNewSheet12.Name = "Fabric_Average_Saving";
                    xlNewSheet12.Cells[1, 1] = "Serial Number/Contract Number";
                    xlNewSheet12.Cells[1, 2] = "Qty";
                    xlNewSheet12.Cells[1, 3] = "Rate";
                    xlNewSheet12.Cells[1, 4] = "Fabric";
                    xlNewSheet12.Cells[1, 5] = "OrderDate";
                    xlNewSheet12.Cells[1, 6] = "Exfactory";
                    xlNewSheet12.Cells[1, 7] = "Cost Avg.";
                    xlNewSheet12.Cells[1, 8] = "OrderAvg.";
                    xlNewSheet12.Cells[1, 9] = "Cut Avg.";
                    xlNewSheet12.Cells[1, 10] = "Cost - Order Rev";
                    xlNewSheet12.Cells[1, 11] = "Cost - Order %";
                    xlNewSheet12.Cells[1, 12] = "Cost - Order Weight";
                    xlNewSheet12.Cells[1, 13] = "Order - Cut Rev";
                    xlNewSheet12.Cells[1, 14] = "Order - Cut Rev %";
                    xlNewSheet12.Cells[1, 15] = "Order - Cut Weight";


                    if (ds.Tables[0].Rows.Count == 0)
                    {
                        return false;
                    }
                    else if (ds.Tables[0].Rows.Count > 0)
                    {
                        int T = 1;
                        int U = 2;
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            string Order_Costing_Meterage = string.Empty;
                            string Order_Costing_Rate = string.Empty;
                            string Order_Costing_Meterage_Kg = string.Empty;
                            string Order_Costing_Rate_Kg = string.Empty;
                            string Cut_Order_Meterage = string.Empty;
                            string Cut_Order_Rate = string.Empty;
                            string Cut_Order_Meterage_Kg = string.Empty;
                            string Cut_Order_Rate_Kg = string.Empty;
                            string Total = string.Empty;
                            string orderAvg = string.Empty;
                            string CostAvg = string.Empty;
                            string CutAvg = string.Empty;
                            string Unit = string.Empty;

                            Total = dr["SerialNumber"] == DBNull.Value ? string.Empty : Convert.ToString(dr["SerialNumber"]);
                            xlNewSheet12.Cells[T + 1, 1] = Convert.ToString(dr["SerialNumber"]) == "0" ? string.Empty : Convert.ToString(dr["SerialNumber"]);
                            xlNewSheet12.Cells[T + 1, 2] = Convert.ToString(dr["Quantity"]) == "0" ? string.Empty : Convert.ToString(Convert.ToInt32(dr["Quantity"]).ToString("N0"));
                            xlNewSheet12.Cells[T + 1, 3] = Convert.ToString(dr["Rate"]) == "0" ? string.Empty : Convert.ToString(dr["Rate"]);
                            xlNewSheet12.Cells[T + 1, 4] = dr["Fabric"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Fabric"]);
                            //add code by Bharat on 29-jun-20
                            if (Total == Convert.ToString("Total"))
                            {
                                if (Convert.ToString(dr["OrderDate"]) == "1 Jan (Sat)")
                                {
                                    xlNewSheet12.Cells[T + 1, 5] = "";
                                }
                                if (Convert.ToString(dr["ExFactory"]) == "1 Jan (Sat)")
                                {
                                    xlNewSheet12.Cells[T + 1, 6] = "";
                                }
                            }
                            else
                            {
                                xlNewSheet12.Cells[T + 1, 5] = Convert.ToString(dr["OrderDate"]) == "01-01-1900 00:00:00" ? string.Empty : Convert.ToString(dr["OrderDate"]);
                                xlNewSheet12.Cells[T + 1, 6] = Convert.ToString(dr["ExFactory"]) == "01-01-1900 00:00:00" ? string.Empty : Convert.ToString(dr["ExFactory"]);
                            }
                            //end
                            xlNewSheet12.Cells[T + 1, 7] = Convert.ToString(dr["CostAvg"]) == "0" ? string.Empty : Convert.ToString(dr["CostAvg"]);
                            xlNewSheet12.Cells[T + 1, 8] = Convert.ToString(dr["OrderAvg"]) == "0" ? string.Empty : Convert.ToString(dr["OrderAvg"]);
                            orderAvg = Convert.ToString(dr["OrderAvg"]) == "0" ? string.Empty : Convert.ToString(dr["OrderAvg"]);
                            //Unit = dr["UNIT"] == "0" ? string.Empty : Convert.ToString(dr["UNIT"]);
                            xlNewSheet12.Cells[T + 1, 9] = Convert.ToString(dr["CutAvg"]) == "0" ? "N/A" : Convert.ToString(dr["CutAvg"]);





                            CostAvg = Convert.ToString(dr["CostAvg"]) == "0" ? string.Empty : Convert.ToString(dr["CostAvg"]);
                            CutAvg = Convert.ToString(dr["CutAvg"]) == "0" ? string.Empty : Convert.ToString(dr["CutAvg"]);

                            Order_Costing_Meterage = dr["Cost-Order Rev"] == DBNull.Value ? string.Empty : Convert.ToString(Convert.ToInt32(dr["Cost-Order Rev"]).ToString("N0"));
                            if (Order_Costing_Meterage == "")
                                Order_Costing_Meterage = "0";
                            Order_Costing_Rate = dr["Cost-Order %"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Cost-Order %"]);
                            if (Order_Costing_Rate == "")
                                Order_Costing_Rate = "0";
                            if (Total == Convert.ToString("Total"))
                            {
                                Order_Costing_Meterage_Kg = dr["Cost-Order Weight"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Cost-Order Weight"] + " %");
                                if (Order_Costing_Meterage_Kg == "")
                                    Order_Costing_Meterage_Kg = "0";
                            }
                            else
                            {
                                Order_Costing_Meterage_Kg = dr["Cost-Order Weight"] == DBNull.Value ? string.Empty : Convert.ToString(Convert.ToInt32(dr["Cost-Order Weight"]).ToString("N0"));
                                if (Order_Costing_Meterage_Kg == "")
                                    Order_Costing_Meterage_Kg = "0";
                            }

                            if (CutAvg == "")
                                CutAvg = "0";
                            if (orderAvg == "")
                                orderAvg = "0";

                            Cut_Order_Meterage = dr["Order - Cut Rev"] == DBNull.Value ? string.Empty : Convert.ToString(Convert.ToInt32(dr["Order - Cut Rev"]).ToString("N0"));
                            if (Cut_Order_Meterage == "")
                                Cut_Order_Meterage = "0";


                            Cut_Order_Rate = dr["Order -Cut Rev %"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Order -Cut Rev %"]);
                            if (Cut_Order_Rate == "")
                                Cut_Order_Rate = "0";
                            if (Total == Convert.ToString("Total"))
                            {
                                Cut_Order_Meterage_Kg = dr["Order -Cut Weight"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Order -Cut Weight"] + " %");
                                if (Cut_Order_Meterage_Kg == "")
                                    Cut_Order_Meterage_Kg = "0";
                            }
                            else
                            {
                                Cut_Order_Meterage_Kg = dr["Order -Cut Weight"] == DBNull.Value ? string.Empty : Convert.ToString(Convert.ToInt32(dr["Order -Cut Weight"]).ToString("N0"));
                                if (Cut_Order_Meterage_Kg == "")
                                    Cut_Order_Meterage_Kg = "0";
                            }



                            U = T + 1;
                            // Code Added By Bharat on 21-jul
                            if (Order_Costing_Meterage != "0")
                            {
                                xlNewSheet12.Cells[T + 1, 10] = ci.NumberFormat.CurrencySymbol = "₹" + Order_Costing_Meterage;
                            }
                            else
                            {
                                xlNewSheet12.Cells[T + 1, 10] = "";
                            }
                            if (Order_Costing_Rate != "0")
                            {
                                xlNewSheet12.Cells[T + 1, 11] = Order_Costing_Rate + "%";
                            }
                            else
                            {
                                xlNewSheet12.Cells[T + 1, 11] = "";
                            }
                            if (Order_Costing_Meterage_Kg != "0")
                            {
                                xlNewSheet12.Cells[T + 1, 12] = Order_Costing_Meterage_Kg;
                            }
                            else
                            {
                                xlNewSheet12.Cells[T + 1, 12] = "";
                            }
                            if (Cut_Order_Meterage != "0")
                            {
                                xlNewSheet12.Cells[T + 1, 13] = ci.NumberFormat.CurrencySymbol = "₹" + Cut_Order_Meterage;
                            }
                            else
                            {
                                xlNewSheet12.Cells[T + 1, 13] = "";
                            }
                            if (Cut_Order_Rate != "0")
                            {
                                xlNewSheet12.Cells[T + 1, 14] = Cut_Order_Rate + "%";
                            }
                            else
                            {
                                xlNewSheet12.Cells[T + 1, 14] = "";
                            }
                            if (Cut_Order_Meterage_Kg != "0")
                            {
                                xlNewSheet12.Cells[T + 1, 15] = Cut_Order_Meterage_Kg;
                            }
                            else
                            {
                                xlNewSheet12.Cells[T + 1, 15] = "";
                            }
                            //end

                            if (Total == Convert.ToString("Total"))
                            {
                                xlNewSheet12.Range["A" + U, "A" + U].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                                xlNewSheet12.Range["B" + U, "B" + U].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                                xlNewSheet12.Range["C" + U, "C" + U].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                                xlNewSheet12.Range["D" + U, "D" + U].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                                xlNewSheet12.Range["E" + U, "E" + U].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                                xlNewSheet12.Range["F" + U, "F" + U].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                                xlNewSheet12.Range["G" + U, "G" + U].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                                xlNewSheet12.Range["H" + U, "H" + U].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                                xlNewSheet12.Range["I" + U, "I" + U].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);

                                xlNewSheet12.Range["A" + U, "A" + U].Font.FontStyle = "Bold";
                                xlNewSheet12.Range["B" + U, "B" + U].Font.FontStyle = "Bold";
                                xlNewSheet12.Range["C" + U, "C" + U].Font.FontStyle = "Bold";
                                xlNewSheet12.Range["D" + U, "D" + U].Font.FontStyle = "Bold";
                                xlNewSheet12.Range["E" + U, "E" + U].Font.FontStyle = "Bold";
                                xlNewSheet12.Range["F" + U, "F" + U].Font.FontStyle = "Bold";
                                xlNewSheet12.Range["G" + U, "G" + U].Font.FontStyle = "Bold";
                                xlNewSheet12.Range["H" + U, "H" + U].Font.FontStyle = "Bold";
                                xlNewSheet12.Range["I" + U, "I" + U].Font.FontStyle = "Bold";
                            }


                            xlNewSheet12.Range["A" + U, "A" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet12.Range["A" + U, "A" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet12.Range["A" + U, "A" + U].Font.Name = "Calibri";
                            xlNewSheet12.Range["A" + U, "A" + U].Font.Size = 11;
                            //xlNewSheet12.Range["A" + U, "A" + U].Font.FontStyle = "Bold";



                            xlNewSheet12.Range["B" + U, "B" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet12.Range["B" + U, "B" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet12.Range["B" + U, "B" + U].Font.Name = "Calibri";
                            xlNewSheet12.Range["B" + U, "B" + U].Font.Size = 11;




                            xlNewSheet12.Range["C" + U, "C" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet12.Range["C" + U, "C" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet12.Range["C" + U, "C" + U].Font.Name = "Calibri";
                            xlNewSheet12.Range["C" + U, "C" + U].Font.Size = 10;
                            xlNewSheet12.Range["C" + U, "C" + U].Font.FontStyle = "Ragular";



                            xlNewSheet12.Range["D" + U, "D" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet12.Range["D" + U, "D" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet12.Range["D" + U, "D" + U].Font.Name = "Calibri";
                            xlNewSheet12.Range["D" + U, "D" + U].Font.Size = 10;
                            xlNewSheet12.Range["D" + U, "D" + U].Font.FontStyle = "Ragular";




                            xlNewSheet12.Range["E" + U, "E" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet12.Range["E" + U, "E" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet12.Range["E" + U, "E" + U].Font.Name = "Calibri";
                            xlNewSheet12.Range["E" + U, "E" + U].Font.Size = 10;
                            xlNewSheet12.Range["E" + U, "E" + U].Font.FontStyle = "Ragular";
                            //xlNewSheet12.Range["E" + U, "E" + U].Font.FontStyle = "Bold";

                            xlNewSheet12.Range["F" + U, "F" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet12.Range["F" + U, "F" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet12.Range["F" + U, "F" + U].Font.Name = "Calibri";
                            xlNewSheet12.Range["F" + U, "F" + U].Font.Size = 10;
                            xlNewSheet12.Range["F" + U, "F" + U].Font.FontStyle = "Ragular";


                            xlNewSheet12.Range["G" + U, "G" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet12.Range["G" + U, "G" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet12.Range["G" + U, "G" + U].Font.Name = "Calibri";
                            xlNewSheet12.Range["G" + U, "G" + U].Font.Size = 10;
                            xlNewSheet12.Range["G" + U, "G" + U].Font.FontStyle = "Ragular";
                            //xlNewSheet12.Range["G" + U, "G" + U].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Yellow);

                            xlNewSheet12.Range["H" + U, "H" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet12.Range["H" + U, "H" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet12.Range["H" + U, "H" + U].Font.Name = "Calibri";
                            xlNewSheet12.Range["H" + U, "H" + U].Font.Size = 10;
                            xlNewSheet12.Range["H" + U, "H" + U].Font.FontStyle = "Ragular";

                            xlNewSheet12.Range["I" + U, "I" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet12.Range["I" + U, "I" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet12.Range["I" + U, "I" + U].Font.Name = "Calibri";
                            xlNewSheet12.Range["I" + U, "I" + U].Font.Size = 10;
                            xlNewSheet12.Range["I" + U, "I" + U].Font.FontStyle = "Ragular";



                            xlNewSheet12.Range["J" + U, "J" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet12.Range["J" + U, "J" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet12.Range["J" + U, "J" + U].Font.Name = "Calibri";
                            xlNewSheet12.Range["J" + U, "J" + U].Font.Size = 10;
                            xlNewSheet12.Range["J" + U, "J" + U].Font.FontStyle = "Ragular";
                            xlNewSheet12.Range["J" + U, "J" + U].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black);


                            xlNewSheet12.Range["K" + U, "K" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet12.Range["K" + U, "K" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet12.Range["K" + U, "K" + U].Font.Name = "Calibri";
                            xlNewSheet12.Range["K" + U, "K" + U].Font.Size = 10;
                            //xlNewSheet12.Range["I" + U, "I" + U].Font.FontStyle = "Bold";
                            xlNewSheet12.Range["K" + U, "K" + U].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black);

                            xlNewSheet12.Range["L" + U, "L" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet12.Range["L" + U, "L" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet12.Range["L" + U, "L" + U].Font.Name = "Calibri";
                            xlNewSheet12.Range["L" + U, "L" + U].Font.Size = 11;
                            xlNewSheet12.Range["L" + U, "L" + U].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black);

                            xlNewSheet12.Range["M" + U, "M" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet12.Range["M" + U, "M" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet12.Range["M" + U, "M" + U].Font.Name = "Calibri";
                            xlNewSheet12.Range["M" + U, "M" + U].Font.Size = 11;
                            xlNewSheet12.Range["M" + U, "M" + U].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black);
                            //xlNewSheet12.Range["J" + U, "J" + U].Font.FontStyle = "Bold";

                            xlNewSheet12.Range["N" + U, "N" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet12.Range["N" + U, "N" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet12.Range["N" + U, "N" + U].Font.Name = "Calibri";
                            xlNewSheet12.Range["N" + U, "N" + U].Font.Size = 11;
                            xlNewSheet12.Range["N" + U, "N" + U].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black);

                            xlNewSheet12.Range["O" + U, "O" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet12.Range["O" + U, "O" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet12.Range["O" + U, "O" + U].Font.Name = "Calibri";
                            xlNewSheet12.Range["O" + U, "O" + U].Font.Size = 11;
                            xlNewSheet12.Range["O" + U, "O" + U].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black);

                            T++;
                        }



                        xlNewSheet12.Columns.AutoFit();

                        //xlNewSheet12.get_Range("A1", "A2").Merge();
                        //xlNewSheet12.get_Range("B1", "B2").Merge();
                        //xlNewSheet12.get_Range("C1", "C2").Merge();
                        //xlNewSheet12.get_Range("D1", "D2").Merge();
                        //xlNewSheet12.get_Range("E1", "E2").Merge();
                        //xlNewSheet12.get_Range("F1", "F2").Merge();
                        //xlNewSheet12.get_Range("G1", "G2").Merge();
                        //xlNewSheet12.get_Range("H1", "H2").Merge();
                        //xlNewSheet12.get_Range("I1", "I2").Merge();


                        xlNewSheet12.Range["A1", "A1"].Font.Bold = true;
                        xlNewSheet12.Range["A1", "A1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet12.Range["B1", "B1"].Font.Bold = true;
                        xlNewSheet12.Range["B1", "B1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet12.Range["C1", "C1"].Font.Bold = true;
                        xlNewSheet12.Range["C1", "C1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet12.Range["D1", "D1"].Font.Bold = true;
                        xlNewSheet12.Range["D1", "D1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet12.Range["E1", "E1"].Font.Bold = true;
                        xlNewSheet12.Range["E1", "E1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet12.Range["F1", "F1"].Font.Bold = true;
                        xlNewSheet12.Range["F1", "F1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet12.Range["G1", "G1"].Font.Bold = true;
                        xlNewSheet12.Range["G1", "G1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet12.Range["H1", "H1"].Font.Bold = true;
                        xlNewSheet12.Range["H1", "H1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet12.Range["I1", "I1"].Font.Bold = true;
                        xlNewSheet12.Range["I1", "I1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet12.Range["J1", "J1"].Font.Bold = true;
                        xlNewSheet12.Range["J1", "J1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet12.Range["K1", "K1"].Font.Bold = true;
                        xlNewSheet12.Range["K1", "K1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet12.Range["L1", "L1"].Font.Bold = true;
                        xlNewSheet12.Range["L1", "L1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet12.Range["M1", "M1"].Font.Bold = true;
                        xlNewSheet12.Range["M1", "M1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet12.Range["N1", "N1"].Font.Bold = true;
                        xlNewSheet12.Range["N1", "N1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet12.Range["O1", "O1"].Font.Bold = true;
                        xlNewSheet12.Range["O1", "O1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;



                        xlNewSheet12.Range["A1", "O1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        xlNewSheet12.Range["A1", "O1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                        xlNewSheet12.Range["A1", "O1"].EntireColumn.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                        xlNewSheet12.get_Range("A1:O" + T).Cells.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;


                        xlNewSheet12.Range["E1"].Cells.EntireColumn.NumberFormat = "d mmm (ddd);@";
                        xlNewSheet12.Range["F1"].Cells.EntireColumn.NumberFormat = "d mmm (ddd);@";
                        //xlNewSheet12.Range["J1"].Cells.ColumnWidth = 8;
                        //xlNewSheet12.Range["K1"].Cells.ColumnWidth = 7.45;
                        //xlNewSheet12.Range["L1"].Cells.ColumnWidth =11;
                        //xlNewSheet12.Range["M1"].Cells.ColumnWidth = 9;
                        //xlNewSheet12.Range["N1"].Cells.ColumnWidth = 7.45;
                        //xlNewSheet12.Range["O1"].Cells.ColumnWidth = 11;
                        //xlNewSheet12.Range["J1"].Cells.ColumnWidth = 8;

                        //xlNewSheet12.get_Range("J1", "L1").Merge();
                        //xlNewSheet12.get_Range("J1", "L1").Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                        //xlNewSheet12.get_Range("M1", "O1").Merge();
                        //xlNewSheet12.get_Range("M1", "O1").Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;


                        xlNewSheet12.Select();
                        ((Excel.Worksheet)xlApp.ActiveWorkbook.Sheets[1]).Activate();
                        releaseObject(xlNewSheet12);
                        //((Excel.Worksheet)xlApp.ActiveWorkbook.Sheets[1]).Activate();

                    }

                }
                if (ReportType == "OutHouse")
                {
                    // iKandi.Common.Constants.WorkSheetCount_ForExcel = iKandi.Common.Constants.WorkSheetCount_ForExcel + 1;
                    CultureInfo ci = new CultureInfo("en-IN");
                    ci.NumberFormat.CurrencySymbol = "₹";
                    GlobalCount = GlobalCount + 1;
                    var xlNewSheet12 = (Excel.Worksheet)worksheets.Add(worksheets[GlobalCount], Type.Missing, Type.Missing, Type.Missing);



                    xlNewSheet12.Name = "Stitch_OutHouse";
                    xlNewSheet12.Cells[1, 13] = "Stitch Detail";
                    xlNewSheet12.Cells[2, 1] = "Style Code";
                    xlNewSheet12.Cells[2, 2] = "Serial number";
                    xlNewSheet12.Cells[2, 3] = "Department Name";
                    xlNewSheet12.Cells[2, 4] = "Order Quantity";
                    xlNewSheet12.Cells[2, 5] = "Sealed Date";
                    xlNewSheet12.Cells[2, 6] = "Pattern Sample Date";
                    xlNewSheet12.Cells[2, 7] = "MinExFactory";
                    xlNewSheet12.Cells[2, 8] = "MaxExFactory";
                    xlNewSheet12.Cells[2, 9] = "SAM(Weighted)";
                    xlNewSheet12.Cells[2, 10] = "BIPL Budget";

                    xlNewSheet12.Cells[2, 11] = "Supplier1";
                    xlNewSheet12.Cells[2, 12] = "Stitch_1";
                    xlNewSheet12.Cells[2, 13] = "Supplier_2";
                    xlNewSheet12.Cells[2, 14] = "Stitch_2";
                    xlNewSheet12.Cells[2, 15] = "Supplier_3";
                    xlNewSheet12.Cells[2, 16] = "Stitch_3";
                    xlNewSheet12.Cells[2, 17] = "Supplier_4";
                    xlNewSheet12.Cells[2, 18] = "Stitch_4";
                    xlNewSheet12.Cells[2, 19] = "Supplier_5";
                    xlNewSheet12.Cells[2, 20] = "Stitch_5";




                    if (ds.Tables[0].Rows.Count == 0)
                    {
                        return false;
                    }
                    else if (ds.Tables[0].Rows.Count > 0)
                    {
                        int T = 2;
                        int U = 1;
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            //int IsVaFineLineCheck = 0;
                            //int IsVaFineLineCheck2 = 0;
                            //int IsVaFineLineCheck3 = 0;
                            //int IsVaFineLineCheck4 = 0;
                            //int IsVaFineLineCheck5 = 0;


                            int IsFinalOB = 0;
                            xlNewSheet12.Cells[T + 1, 1] = dr["StyleCode"] == DBNull.Value ? string.Empty : Convert.ToString(dr["StyleCode"]);
                            xlNewSheet12.Cells[T + 1, 2] = dr["SerialNumber"] == DBNull.Value ? string.Empty : Convert.ToString(dr["SerialNumber"]);
                            xlNewSheet12.Cells[T + 1, 3] = dr["DepartmentName"] == DBNull.Value ? string.Empty : Convert.ToString(dr["DepartmentName"]);
                            xlNewSheet12.Cells[T + 1, 4] = dr["Quantity"] == DBNull.Value ? string.Empty : Convert.ToInt32(dr["Quantity"]).ToString("N0");// Added Code By Bharat On 12-12-19
                            xlNewSheet12.Cells[T + 1, 5] = dr["SealDate"] == DBNull.Value ? string.Empty : Convert.ToString(dr["SealDate"]);
                            xlNewSheet12.Cells[T + 1, 6] = dr["MinPatternsampleDate"] == DBNull.Value ? string.Empty : Convert.ToString(dr["MinPatternsampleDate"]);
                            xlNewSheet12.Cells[T + 1, 7] = dr["MinExfactory"] == DBNull.Value ? string.Empty : Convert.ToString(dr["MinExfactory"]);
                            xlNewSheet12.Cells[T + 1, 8] = dr["MaxExfactory"] == DBNull.Value ? string.Empty : Convert.ToString(dr["MaxExfactory"]);
                            xlNewSheet12.Cells[T + 1, 9] = dr["Sam"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Sam"]);
                            xlNewSheet12.Cells[T + 1, 10] = dr["biplbudget"] == DBNull.Value ? string.Empty : Convert.ToString(ci.NumberFormat.CurrencySymbol = "₹" + dr["biplbudget"]);



                            //xlNewSheet11.Cells[S + 1, 10].Color = System.Drawing.Color.AliceBlue;₹

                            xlNewSheet12.Cells[T + 1, 11] = dr["VA_Stch_Supplier_1"] == DBNull.Value ? string.Empty : Convert.ToString(dr["VA_Stch_Supplier_1"]);
                            xlNewSheet12.Cells[T + 1, 12] = dr["VA_Stch_Rate_1"] == DBNull.Value ? string.Empty : Convert.ToString(dr["VA_Stch_Rate_1"]);
                            xlNewSheet12.Cells[T + 1, 13] = dr["VA_Stch_Supplier_2"] == DBNull.Value ? string.Empty : Convert.ToString(dr["VA_Stch_Supplier_2"]);
                            xlNewSheet12.Cells[T + 1, 14] = dr["VA_Stch_Rate_2"] == DBNull.Value ? string.Empty : Convert.ToString(dr["VA_Stch_Rate_2"]);
                            xlNewSheet12.Cells[T + 1, 15] = dr["VA_Stch_Supplier_3"] == DBNull.Value ? string.Empty : Convert.ToString(dr["VA_Stch_Supplier_3"]);
                            xlNewSheet12.Cells[T + 1, 16] = dr["VA_Stch_Rate_3"] == DBNull.Value ? string.Empty : Convert.ToString(dr["VA_Stch_Rate_3"]);
                            xlNewSheet12.Cells[T + 1, 17] = dr["VA_Stch_Supplier_4"] == DBNull.Value ? string.Empty : Convert.ToString(dr["VA_Stch_Supplier_4"]);

                            xlNewSheet12.Cells[T + 1, 18] = dr["VA_Stch_Rate_4"] == DBNull.Value ? string.Empty : Convert.ToString(dr["VA_Stch_Rate_4"]);
                            xlNewSheet12.Cells[T + 1, 19] = dr["VA_Stch_Supplier_5"] == DBNull.Value ? string.Empty : Convert.ToString(dr["VA_Stch_Supplier_5"]);
                            xlNewSheet12.Cells[T + 1, 20] = dr["VA_Stch_Rate_5"] == DBNull.Value ? string.Empty : Convert.ToString(dr["VA_Stch_Rate_5"]);
                            IsFinalOB = dr["IsFinalOB"] == DBNull.Value ? 0 : Convert.ToInt32(dr["IsFinalOB"]);

                            U = T + 1;



                            xlNewSheet12.Range["A" + U, "A" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet12.Range["A" + U, "A" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet12.Range["A" + U, "A" + U].Font.Name = "Calibri";
                            xlNewSheet12.Range["A" + U, "A" + U].Font.Size = 11;
                            xlNewSheet12.Range["A" + U, "A" + U].Font.FontStyle = "Bold";



                            xlNewSheet12.Range["B" + U, "B" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet12.Range["B" + U, "B" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet12.Range["B" + U, "B" + U].Font.Name = "Calibri";
                            xlNewSheet12.Range["B" + U, "B" + U].Font.Size = 11;
                            xlNewSheet12.Range["B" + U, "B" + U].Font.FontStyle = "Bold";
                            xlNewSheet12.Range["B" + U, "B" + U].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.DarkBlue);




                            xlNewSheet12.Range["C" + U, "C" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet12.Range["C" + U, "C" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet12.Range["C" + U, "C" + U].Font.Name = "Calibri";
                            xlNewSheet12.Range["C" + U, "C" + U].Font.Size = 10;
                            xlNewSheet12.Range["C" + U, "C" + U].Font.FontStyle = "Ragular";

                            if (IsFinalOB == 0)
                            {
                                xlNewSheet12.Range["A" + U, "A" + U].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Red);

                                xlNewSheet12.get_Range("A2", "A2").Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;

                            }

                            xlNewSheet12.Range["D" + U, "D" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet12.Range["D" + U, "D" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet12.Range["D" + U, "D" + U].Font.Name = "Calibri";
                            xlNewSheet12.Range["D" + U, "D" + U].Font.Size = 12;
                            xlNewSheet12.Range["D" + U, "D" + U].Font.FontStyle = "Bold";



                            xlNewSheet12.Range["E" + U, "E" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet12.Range["E" + U, "E" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet12.Range["E" + U, "E" + U].Font.Name = "Calibri";
                            xlNewSheet12.Range["E" + U, "E" + U].Font.Size = 10;
                            xlNewSheet12.Range["E" + U, "E" + U].Font.FontStyle = "Ragular";
                            xlNewSheet12.Range["E" + U, "E" + U].Font.FontStyle = "Bold";

                            xlNewSheet12.Range["F" + U, "F" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet12.Range["F" + U, "F" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet12.Range["F" + U, "F" + U].Font.Name = "Calibri";
                            xlNewSheet12.Range["F" + U, "F" + U].Font.Size = 10;
                            xlNewSheet12.Range["F" + U, "F" + U].Font.FontStyle = "Ragular";


                            xlNewSheet12.Range["G" + U, "G" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet12.Range["G" + U, "G" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet12.Range["G" + U, "G" + U].Font.Name = "Calibri";
                            xlNewSheet12.Range["G" + U, "G" + U].Font.Size = 10;
                            xlNewSheet12.Range["G" + U, "G" + U].Font.FontStyle = "Ragular";

                            xlNewSheet12.Range["H" + U, "H" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet12.Range["H" + U, "H" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet12.Range["H" + U, "H" + U].Font.Name = "Calibri";
                            xlNewSheet12.Range["H" + U, "H" + U].Font.Size = 10;
                            xlNewSheet12.Range["H" + U, "H" + U].Font.FontStyle = "Ragular";


                            xlNewSheet12.Range["I" + U, "I" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet12.Range["I" + U, "I" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet12.Range["I" + U, "I" + U].Font.Name = "Calibri";
                            xlNewSheet12.Range["I" + U, "I" + U].Font.Size = 10;
                            xlNewSheet12.Range["I" + U, "I" + U].Font.FontStyle = "Bold";

                            xlNewSheet12.Range["J" + U, "J" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet12.Range["J" + U, "J" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet12.Range["J" + U, "J" + U].Font.Name = "Calibri";
                            xlNewSheet12.Range["J" + U, "J" + U].Font.Size = 11;
                            xlNewSheet12.Range["J" + U, "J" + U].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red);
                            xlNewSheet12.Range["J" + U, "J" + U].Font.FontStyle = "Bold";


                            xlNewSheet12.Range["K" + U, "K" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet12.Range["K" + U, "K" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet12.Range["K" + U, "K" + U].Font.Name = "Calibri";
                            xlNewSheet12.Range["K" + U, "K" + U].Font.Size = 11;
                            xlNewSheet12.Range["K" + U, "K" + U].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.DarkBlue);
                            xlNewSheet12.Range["K" + U, "K" + U].Font.FontStyle = "Bold";

                            xlNewSheet12.Range["L" + U, "L" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet12.Range["L" + U, "L" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet12.Range["L" + U, "L" + U].Font.Name = "Calibri";
                            xlNewSheet12.Range["L" + U, "L" + U].Font.Size = 11;
                            xlNewSheet12.Range["L" + U, "L" + U].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Green);
                            xlNewSheet12.Range["L" + U, "L" + U].Font.FontStyle = "Bold";

                            xlNewSheet12.Range["M" + U, "M" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet12.Range["M" + U, "M" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet12.Range["M" + U, "M" + U].Font.Name = "Calibri";
                            xlNewSheet12.Range["M" + U, "M" + U].Font.Size = 11;
                            xlNewSheet12.Range["M" + U, "M" + U].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.DarkBlue);
                            xlNewSheet12.Range["M" + U, "M" + U].Font.FontStyle = "Bold";

                            xlNewSheet12.Range["N" + U, "N" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet12.Range["N" + U, "N" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet12.Range["N" + U, "N" + U].Font.Name = "Calibri";
                            xlNewSheet12.Range["N" + U, "N" + U].Font.Size = 11;
                            xlNewSheet12.Range["N" + U, "N" + U].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Green);
                            xlNewSheet12.Range["N" + U, "N" + U].Font.FontStyle = "Bold";

                            xlNewSheet12.Range["O" + U, "O" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet12.Range["O" + U, "O" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet12.Range["O" + U, "O" + U].Font.Name = "Calibri";
                            xlNewSheet12.Range["O" + U, "O" + U].Font.Size = 11;
                            xlNewSheet12.Range["O" + U, "O" + U].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.DarkBlue);
                            xlNewSheet12.Range["O" + U, "O" + U].Font.FontStyle = "Bold";

                            xlNewSheet12.Range["P" + U, "P" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet12.Range["P" + U, "P" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet12.Range["P" + U, "P" + U].Font.Name = "Calibri";
                            xlNewSheet12.Range["P" + U, "P" + U].Font.Size = 11;
                            xlNewSheet12.Range["P" + U, "P" + U].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Green);
                            xlNewSheet12.Range["P" + U, "P" + U].Font.FontStyle = "Bold";

                            xlNewSheet12.Range["Q" + U, "Q" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet12.Range["Q" + U, "Q" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet12.Range["Q" + U, "Q" + U].Font.Name = "Calibri";
                            xlNewSheet12.Range["Q" + U, "Q" + U].Font.Size = 11;
                            xlNewSheet12.Range["Q" + U, "Q" + U].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.DarkBlue);
                            xlNewSheet12.Range["Q" + U, "Q" + U].Font.FontStyle = "Bold";

                            xlNewSheet12.Range["R" + U, "R" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet12.Range["R" + U, "R" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet12.Range["R" + U, "R" + U].Font.Name = "Calibri";
                            xlNewSheet12.Range["R" + U, "R" + U].Font.Size = 11;
                            xlNewSheet12.Range["R" + U, "R" + U].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Green);
                            xlNewSheet12.Range["R" + U, "R" + U].Font.FontStyle = "Bold";

                            xlNewSheet12.Range["S" + U, "S" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet12.Range["S" + U, "S" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet12.Range["S" + U, "S" + U].Font.Name = "Calibri";
                            xlNewSheet12.Range["S" + U, "S" + U].Font.Size = 11;
                            xlNewSheet12.Range["S" + U, "S" + U].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.DarkBlue);
                            xlNewSheet12.Range["S" + U, "S" + U].Font.FontStyle = "Bold";

                            xlNewSheet12.Range["T" + U, "T" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet12.Range["T" + U, "T" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet12.Range["T" + U, "T" + U].Font.Name = "Calibri";
                            xlNewSheet12.Range["T" + U, "T" + U].Font.Size = 11;
                            xlNewSheet12.Range["T" + U, "T" + U].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Green);
                            xlNewSheet12.Range["T" + U, "T" + U].Font.FontStyle = "Bold";


                            //xlNewSheet12.Range["J" + U, "J" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            //xlNewSheet12.Range["J" + U, "J" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            //xlNewSheet12.Range["J" + U, "J" + U].Font.Name = "Calibri";
                            //xlNewSheet12.Range["J" + U, "J" + U].Font.Size = 12;
                            //xlNewSheet12.Range["J" + U, "J" + U].Font.FontStyle = "Bold";

                            //xlNewSheet12.Range["K2" + U, "K2" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            //xlNewSheet12.Range["K2" + U, "K2" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            //xlNewSheet12.Range["K2" + U, "K2" + U].Font.Name = "Calibri";
                            //xlNewSheet12.Range["K2" + U, "K2" + U].Font.Size = 10;
                            //xlNewSheet12.Range["K2" + U, "K2" + U].Font.FontStyle = "Ragular";

                            //xlNewSheet12.Range["L" + U, "L" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            //xlNewSheet12.Range["L" + U, "L" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            //xlNewSheet12.Range["L" + U, "L" + U].Font.Name = "Calibri";
                            //xlNewSheet12.Range["L" + U, "L" + U].Font.Size = 10;
                            //xlNewSheet12.Range["L" + U, "L" + U].Font.FontStyle = "Ragular";
                            //xlNewSheet12.Range["L" + U, "L" + U].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red);
                            //xlNewSheet12.Range["L" + U, "L" + U].Font.FontStyle = "Bold";




                            //xlNewSheet12.Range["M2" + U, "M2" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            //xlNewSheet12.Range["M2" + U, "M2" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            //xlNewSheet12.Range["M2" + U, "M2" + U].Font.Name = "Calibri";
                            //xlNewSheet12.Range["M2" + U, "M2" + U].Font.Size = 10;
                            //xlNewSheet12.Range["M2" + U, "M2" + U].Font.FontStyle = "Ragular";

                            //xlNewSheet12.Range["N2" + U, "N2" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            //xlNewSheet12.Range["N2" + U, "N2" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            //xlNewSheet12.Range["N2" + U, "N2" + U].Font.Name = "Calibri";
                            //xlNewSheet12.Range["N2" + U, "N2" + U].Font.Size = 10;
                            //xlNewSheet12.Range["N2" + U, "N2" + U].Font.FontStyle = "Ragular";


                            //xlNewSheet12.Range["O2" + U, "O2" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            //xlNewSheet12.Range["O2" + U, "O2" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            //xlNewSheet12.Range["O2" + U, "O2" + U].Font.Name = "Calibri";
                            //xlNewSheet12.Range["O2" + U, "O2" + U].Font.Size = 10;
                            //xlNewSheet12.Range["O2" + U, "O2" + U].Font.FontStyle = "Ragular";




                            T++;
                        }



                        xlNewSheet12.Columns.AutoFit();

                        xlNewSheet12.get_Range("A1", "A2").Merge();
                        xlNewSheet12.get_Range("B1", "B2").Merge();
                        xlNewSheet12.get_Range("C1", "C2").Merge();
                        xlNewSheet12.get_Range("D1", "D2").Merge();
                        xlNewSheet12.get_Range("E1", "E2").Merge();
                        xlNewSheet12.get_Range("F1", "F2").Merge();
                        xlNewSheet12.get_Range("G1", "G2").Merge();
                        xlNewSheet12.get_Range("H1", "H2").Merge();
                        xlNewSheet12.get_Range("I1", "I2").Merge();
                        xlNewSheet12.get_Range("J1", "J2").Merge();
                        //xlNewSheet12.get_Range("K1", "K2").Merge();

                        xlNewSheet12.Range["A1", "A2"].Font.Bold = true;
                        xlNewSheet12.Range["A1", "A2"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet12.Range["B1", "B2"].Font.Bold = true;
                        xlNewSheet12.Range["B1", "B2"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet12.Range["C1", "C2"].Font.Bold = true;
                        xlNewSheet12.Range["C1", "C2"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet12.Range["D1", "D2"].Font.Bold = true;
                        xlNewSheet12.Range["D1", "D2"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet12.Range["E1", "E2"].Font.Bold = true;
                        xlNewSheet12.Range["E1", "E2"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet12.Range["F1", "F2"].Font.Bold = true;
                        xlNewSheet12.Range["F1", "F2"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet12.Range["G1", "G2"].Font.Bold = true;
                        xlNewSheet12.Range["G1", "G2"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet12.Range["H1", "H2"].Font.Bold = true;
                        xlNewSheet12.Range["H1", "H2"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet12.Range["I1", "I2"].Font.Bold = true;
                        xlNewSheet12.Range["I1", "I2"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet12.Range["J1", "J2"].Font.Bold = true;
                        xlNewSheet12.Range["J1", "J2"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        //xlNewSheet12.Range["K1", "K2"].Font.Bold = true;
                        //xlNewSheet12.Range["K1", "K2"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                        xlNewSheet12.Range["A1", "T1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        xlNewSheet12.Range["A2", "T2"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        xlNewSheet12.Range["A1", "T1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                        xlNewSheet12.Range["A2", "T2"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                        xlNewSheet12.Range["A1", "T1"].EntireColumn.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet12.Range["A2", "T2"].EntireColumn.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet12.get_Range("A1:T" + T).Cells.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                        xlNewSheet12.get_Range("A2:T" + T).Cells.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;

                        xlNewSheet12.Range["E1"].Cells.EntireColumn.NumberFormat = "d mmm (ddd);@";
                        xlNewSheet12.Range["F1"].Cells.EntireColumn.NumberFormat = "d mmm (ddd);@";
                        xlNewSheet12.Range["G1"].Cells.EntireColumn.NumberFormat = "d mmm (ddd);@";
                        xlNewSheet12.Range["H1"].Cells.EntireColumn.NumberFormat = "d mmm (ddd);@";
                        xlNewSheet12.Range["J1"].Cells.EntireColumn.NumberFormat = "₹0.00";
                        xlNewSheet12.Range["L1"].Cells.EntireColumn.NumberFormat = "₹0.00";
                        xlNewSheet12.Range["N1"].Cells.EntireColumn.NumberFormat = "₹0.00";
                        xlNewSheet12.Range["P1"].Cells.EntireColumn.NumberFormat = "₹0.00";
                        xlNewSheet12.Range["R1"].Cells.EntireColumn.NumberFormat = "₹0.00";
                        xlNewSheet12.Range["T1"].Cells.EntireColumn.NumberFormat = "₹0.00";

                        xlNewSheet12.get_Range("K1", "T1").Merge();
                        xlNewSheet12.get_Range("K1", "T1").Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;



                        xlNewSheet12.Select();
                        ((Excel.Worksheet)xlApp.ActiveWorkbook.Sheets[1]).Activate();
                        releaseObject(xlNewSheet12);
                        //((Excel.Worksheet)xlApp.ActiveWorkbook.Sheets[1]).Activate();

                    }

                }
                if (ReportType == "Finished_OutHouse")
                {
                    // iKandi.Common.Constants.WorkSheetCount_ForExcel = iKandi.Common.Constants.WorkSheetCount_ForExcel + 1;
                    CultureInfo ci = new CultureInfo("en-IN");
                    ci.NumberFormat.CurrencySymbol = "₹";
                    GlobalCount = GlobalCount + 1;
                    var xlNewSheet12 = (Excel.Worksheet)worksheets.Add(worksheets[GlobalCount], Type.Missing, Type.Missing, Type.Missing);



                    xlNewSheet12.Name = "Finished_OutHouse";
                    xlNewSheet12.Cells[1, 13] = "Finished Detail";
                    xlNewSheet12.Cells[2, 1] = "Style Code";
                    xlNewSheet12.Cells[2, 2] = "Serial number";
                    xlNewSheet12.Cells[2, 3] = "Department Name";
                    xlNewSheet12.Cells[2, 4] = "Order Quantity";
                    xlNewSheet12.Cells[2, 5] = "Sealed Date";
                    xlNewSheet12.Cells[2, 6] = "Pattern Sample Date";
                    xlNewSheet12.Cells[2, 7] = "MinExFactory";
                    xlNewSheet12.Cells[2, 8] = "MaxExFactory";
                    xlNewSheet12.Cells[2, 9] = "SAM(Weighted)";
                    xlNewSheet12.Cells[2, 10] = "BIPL Budget";

                    xlNewSheet12.Cells[2, 11] = "Supplier1";
                    xlNewSheet12.Cells[2, 12] = "Finished_1";
                    xlNewSheet12.Cells[2, 13] = "Supplier_2";
                    xlNewSheet12.Cells[2, 14] = "Finished_2";
                    xlNewSheet12.Cells[2, 15] = "Supplier_3";
                    xlNewSheet12.Cells[2, 16] = "Finished_3";
                    xlNewSheet12.Cells[2, 17] = "Supplier_4";
                    xlNewSheet12.Cells[2, 18] = "Finished_4";
                    xlNewSheet12.Cells[2, 19] = "Supplier_5";
                    xlNewSheet12.Cells[2, 20] = "Finished_5";




                    if (ds.Tables[0].Rows.Count == 0)
                    {
                        return false;
                    }
                    else if (ds.Tables[0].Rows.Count > 0)
                    {
                        int T = 2;
                        int U = 1;
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            //int IsVaFineLineCheck = 0;
                            //int IsVaFineLineCheck2 = 0;
                            //int IsVaFineLineCheck3 = 0;
                            //int IsVaFineLineCheck4 = 0;
                            //int IsVaFineLineCheck5 = 0;


                            int IsFinalOB = 0;
                            xlNewSheet12.Cells[T + 1, 1] = dr["StyleCode"] == DBNull.Value ? string.Empty : Convert.ToString(dr["StyleCode"]);
                            xlNewSheet12.Cells[T + 1, 2] = dr["SerialNumber"] == DBNull.Value ? string.Empty : Convert.ToString(dr["SerialNumber"]);
                            xlNewSheet12.Cells[T + 1, 3] = dr["DepartmentName"] == DBNull.Value ? string.Empty : Convert.ToString(dr["DepartmentName"]);
                            xlNewSheet12.Cells[T + 1, 4] = dr["Quantity"] == DBNull.Value ? string.Empty : Convert.ToInt32(dr["Quantity"]).ToString("N0"); // Added Code By Bharat on 12-12-19
                            xlNewSheet12.Cells[T + 1, 5] = dr["SealDate"] == DBNull.Value ? string.Empty : Convert.ToString(dr["SealDate"]);
                            xlNewSheet12.Cells[T + 1, 6] = dr["MinPatternsampleDate"] == DBNull.Value ? string.Empty : Convert.ToString(dr["MinPatternsampleDate"]);
                            xlNewSheet12.Cells[T + 1, 7] = dr["MinExfactory"] == DBNull.Value ? string.Empty : Convert.ToString(dr["MinExfactory"]);
                            xlNewSheet12.Cells[T + 1, 8] = dr["MaxExfactory"] == DBNull.Value ? string.Empty : Convert.ToString(dr["MaxExfactory"]);
                            xlNewSheet12.Cells[T + 1, 9] = dr["Sam"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Sam"]);
                            xlNewSheet12.Cells[T + 1, 10] = dr["biplbudget"] == DBNull.Value ? string.Empty : Convert.ToString(ci.NumberFormat.CurrencySymbol = "₹" + dr["biplbudget"]);



                            //xlNewSheet11.Cells[S + 1, 10].Color = System.Drawing.Color.AliceBlue;₹

                            xlNewSheet12.Cells[T + 1, 11] = dr["VA_Stch_Supplier_1"] == DBNull.Value ? string.Empty : Convert.ToString(dr["VA_Stch_Supplier_1"]);
                            xlNewSheet12.Cells[T + 1, 12] = dr["VA_Stch_Rate_1"] == DBNull.Value ? string.Empty : Convert.ToString(dr["VA_Stch_Rate_1"]);
                            xlNewSheet12.Cells[T + 1, 13] = dr["VA_Stch_Supplier_2"] == DBNull.Value ? string.Empty : Convert.ToString(dr["VA_Stch_Supplier_2"]);
                            xlNewSheet12.Cells[T + 1, 14] = dr["VA_Stch_Rate_2"] == DBNull.Value ? string.Empty : Convert.ToString(dr["VA_Stch_Rate_2"]);
                            xlNewSheet12.Cells[T + 1, 15] = dr["VA_Stch_Supplier_3"] == DBNull.Value ? string.Empty : Convert.ToString(dr["VA_Stch_Supplier_3"]);
                            xlNewSheet12.Cells[T + 1, 16] = dr["VA_Stch_Rate_3"] == DBNull.Value ? string.Empty : Convert.ToString(dr["VA_Stch_Rate_3"]);
                            xlNewSheet12.Cells[T + 1, 17] = dr["VA_Stch_Supplier_4"] == DBNull.Value ? string.Empty : Convert.ToString(dr["VA_Stch_Supplier_4"]);

                            xlNewSheet12.Cells[T + 1, 18] = dr["VA_Stch_Rate_4"] == DBNull.Value ? string.Empty : Convert.ToString(dr["VA_Stch_Rate_4"]);
                            xlNewSheet12.Cells[T + 1, 19] = dr["VA_Stch_Supplier_5"] == DBNull.Value ? string.Empty : Convert.ToString(dr["VA_Stch_Supplier_5"]);
                            xlNewSheet12.Cells[T + 1, 20] = dr["VA_Stch_Rate_5"] == DBNull.Value ? string.Empty : Convert.ToString(dr["VA_Stch_Rate_5"]);
                            IsFinalOB = dr["IsFinalOB"] == DBNull.Value ? 0 : Convert.ToInt32(dr["IsFinalOB"]);

                            U = T + 1;



                            xlNewSheet12.Range["A" + U, "A" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet12.Range["A" + U, "A" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet12.Range["A" + U, "A" + U].Font.Name = "Calibri";
                            xlNewSheet12.Range["A" + U, "A" + U].Font.Size = 11;
                            xlNewSheet12.Range["A" + U, "A" + U].Font.FontStyle = "Bold";



                            xlNewSheet12.Range["B" + U, "B" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet12.Range["B" + U, "B" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet12.Range["B" + U, "B" + U].Font.Name = "Calibri";
                            xlNewSheet12.Range["B" + U, "B" + U].Font.Size = 11;
                            xlNewSheet12.Range["B" + U, "B" + U].Font.FontStyle = "Bold";
                            xlNewSheet12.Range["B" + U, "B" + U].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.DarkBlue);




                            xlNewSheet12.Range["C" + U, "C" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet12.Range["C" + U, "C" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet12.Range["C" + U, "C" + U].Font.Name = "Calibri";
                            xlNewSheet12.Range["C" + U, "C" + U].Font.Size = 10;
                            xlNewSheet12.Range["C" + U, "C" + U].Font.FontStyle = "Ragular";

                            if (IsFinalOB == 0)
                            {
                                xlNewSheet12.Range["A" + U, "A" + U].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Red);

                                //xlNewSheet12.get_Range("A2", "A2").Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;

                            }

                            xlNewSheet12.Range["D" + U, "D" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet12.Range["D" + U, "D" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet12.Range["D" + U, "D" + U].Font.Name = "Calibri";
                            xlNewSheet12.Range["D" + U, "D" + U].Font.Size = 12;
                            xlNewSheet12.Range["D" + U, "D" + U].Font.FontStyle = "Bold";



                            xlNewSheet12.Range["E" + U, "E" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet12.Range["E" + U, "E" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet12.Range["E" + U, "E" + U].Font.Name = "Calibri";
                            xlNewSheet12.Range["E" + U, "E" + U].Font.Size = 10;
                            xlNewSheet12.Range["E" + U, "E" + U].Font.FontStyle = "Ragular";
                            xlNewSheet12.Range["E" + U, "E" + U].Font.FontStyle = "Bold";

                            xlNewSheet12.Range["F" + U, "F" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet12.Range["F" + U, "F" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet12.Range["F" + U, "F" + U].Font.Name = "Calibri";
                            xlNewSheet12.Range["F" + U, "F" + U].Font.Size = 10;
                            xlNewSheet12.Range["F" + U, "F" + U].Font.FontStyle = "Ragular";


                            xlNewSheet12.Range["G" + U, "G" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet12.Range["G" + U, "G" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet12.Range["G" + U, "G" + U].Font.Name = "Calibri";
                            xlNewSheet12.Range["G" + U, "G" + U].Font.Size = 10;
                            xlNewSheet12.Range["G" + U, "G" + U].Font.FontStyle = "Ragular";

                            xlNewSheet12.Range["H" + U, "H" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet12.Range["H" + U, "H" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet12.Range["H" + U, "H" + U].Font.Name = "Calibri";
                            xlNewSheet12.Range["H" + U, "H" + U].Font.Size = 10;
                            xlNewSheet12.Range["H" + U, "H" + U].Font.FontStyle = "Ragular";


                            xlNewSheet12.Range["I" + U, "I" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet12.Range["I" + U, "I" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet12.Range["I" + U, "I" + U].Font.Name = "Calibri";
                            xlNewSheet12.Range["I" + U, "I" + U].Font.Size = 10;
                            xlNewSheet12.Range["I" + U, "I" + U].Font.FontStyle = "Bold";

                            xlNewSheet12.Range["J" + U, "J" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet12.Range["J" + U, "J" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet12.Range["J" + U, "J" + U].Font.Name = "Calibri";
                            xlNewSheet12.Range["J" + U, "J" + U].Font.Size = 11;
                            xlNewSheet12.Range["J" + U, "J" + U].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red);
                            xlNewSheet12.Range["J" + U, "J" + U].Font.FontStyle = "Bold";


                            xlNewSheet12.Range["K" + U, "K" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet12.Range["K" + U, "K" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet12.Range["K" + U, "K" + U].Font.Name = "Calibri";
                            xlNewSheet12.Range["K" + U, "K" + U].Font.Size = 11;
                            xlNewSheet12.Range["K" + U, "K" + U].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.DarkBlue);
                            xlNewSheet12.Range["K" + U, "K" + U].Font.FontStyle = "Bold";

                            xlNewSheet12.Range["L" + U, "L" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet12.Range["L" + U, "L" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet12.Range["L" + U, "L" + U].Font.Name = "Calibri";
                            xlNewSheet12.Range["L" + U, "L" + U].Font.Size = 11;
                            xlNewSheet12.Range["L" + U, "L" + U].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Green);
                            xlNewSheet12.Range["L" + U, "L" + U].Font.FontStyle = "Bold";

                            xlNewSheet12.Range["M" + U, "M" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet12.Range["M" + U, "M" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet12.Range["M" + U, "M" + U].Font.Name = "Calibri";
                            xlNewSheet12.Range["M" + U, "M" + U].Font.Size = 11;
                            xlNewSheet12.Range["M" + U, "M" + U].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.DarkBlue);
                            xlNewSheet12.Range["M" + U, "M" + U].Font.FontStyle = "Bold";

                            xlNewSheet12.Range["N" + U, "N" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet12.Range["N" + U, "N" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet12.Range["N" + U, "N" + U].Font.Name = "Calibri";
                            xlNewSheet12.Range["N" + U, "N" + U].Font.Size = 11;
                            xlNewSheet12.Range["N" + U, "N" + U].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Green);
                            xlNewSheet12.Range["N" + U, "N" + U].Font.FontStyle = "Bold";

                            xlNewSheet12.Range["O" + U, "O" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet12.Range["O" + U, "O" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet12.Range["O" + U, "O" + U].Font.Name = "Calibri";
                            xlNewSheet12.Range["O" + U, "O" + U].Font.Size = 11;
                            xlNewSheet12.Range["O" + U, "O" + U].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.DarkBlue);
                            xlNewSheet12.Range["O" + U, "O" + U].Font.FontStyle = "Bold";

                            xlNewSheet12.Range["P" + U, "P" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet12.Range["P" + U, "P" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet12.Range["P" + U, "P" + U].Font.Name = "Calibri";
                            xlNewSheet12.Range["P" + U, "P" + U].Font.Size = 11;
                            xlNewSheet12.Range["P" + U, "P" + U].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Green);
                            xlNewSheet12.Range["P" + U, "P" + U].Font.FontStyle = "Bold";

                            xlNewSheet12.Range["Q" + U, "Q" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet12.Range["Q" + U, "Q" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet12.Range["Q" + U, "Q" + U].Font.Name = "Calibri";
                            xlNewSheet12.Range["Q" + U, "Q" + U].Font.Size = 11;
                            xlNewSheet12.Range["Q" + U, "Q" + U].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.DarkBlue);
                            xlNewSheet12.Range["Q" + U, "Q" + U].Font.FontStyle = "Bold";

                            xlNewSheet12.Range["R" + U, "R" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet12.Range["R" + U, "R" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet12.Range["R" + U, "R" + U].Font.Name = "Calibri";
                            xlNewSheet12.Range["R" + U, "R" + U].Font.Size = 11;
                            xlNewSheet12.Range["R" + U, "R" + U].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Green);
                            xlNewSheet12.Range["R" + U, "R" + U].Font.FontStyle = "Bold";

                            xlNewSheet12.Range["S" + U, "S" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet12.Range["S" + U, "S" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet12.Range["S" + U, "S" + U].Font.Name = "Calibri";
                            xlNewSheet12.Range["S" + U, "S" + U].Font.Size = 11;
                            xlNewSheet12.Range["S" + U, "S" + U].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.DarkBlue);
                            xlNewSheet12.Range["S" + U, "S" + U].Font.FontStyle = "Bold";

                            xlNewSheet12.Range["T" + U, "T" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet12.Range["T" + U, "T" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet12.Range["T" + U, "T" + U].Font.Name = "Calibri";
                            xlNewSheet12.Range["T" + U, "T" + U].Font.Size = 11;
                            xlNewSheet12.Range["T" + U, "T" + U].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Green);
                            xlNewSheet12.Range["T" + U, "T" + U].Font.FontStyle = "Bold";


                            //xlNewSheet12.Range["J" + U, "J" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            //xlNewSheet12.Range["J" + U, "J" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            //xlNewSheet12.Range["J" + U, "J" + U].Font.Name = "Calibri";
                            //xlNewSheet12.Range["J" + U, "J" + U].Font.Size = 12;
                            //xlNewSheet12.Range["J" + U, "J" + U].Font.FontStyle = "Bold";

                            //xlNewSheet12.Range["K2" + U, "K2" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            //xlNewSheet12.Range["K2" + U, "K2" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            //xlNewSheet12.Range["K2" + U, "K2" + U].Font.Name = "Calibri";
                            //xlNewSheet12.Range["K2" + U, "K2" + U].Font.Size = 10;
                            //xlNewSheet12.Range["K2" + U, "K2" + U].Font.FontStyle = "Ragular";

                            //xlNewSheet12.Range["L" + U, "L" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            //xlNewSheet12.Range["L" + U, "L" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            //xlNewSheet12.Range["L" + U, "L" + U].Font.Name = "Calibri";
                            //xlNewSheet12.Range["L" + U, "L" + U].Font.Size = 10;
                            //xlNewSheet12.Range["L" + U, "L" + U].Font.FontStyle = "Ragular";
                            //xlNewSheet12.Range["L" + U, "L" + U].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red);
                            //xlNewSheet12.Range["L" + U, "L" + U].Font.FontStyle = "Bold";




                            //xlNewSheet12.Range["M2" + U, "M2" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            //xlNewSheet12.Range["M2" + U, "M2" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            //xlNewSheet12.Range["M2" + U, "M2" + U].Font.Name = "Calibri";
                            //xlNewSheet12.Range["M2" + U, "M2" + U].Font.Size = 10;
                            //xlNewSheet12.Range["M2" + U, "M2" + U].Font.FontStyle = "Ragular";

                            //xlNewSheet12.Range["N2" + U, "N2" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            //xlNewSheet12.Range["N2" + U, "N2" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            //xlNewSheet12.Range["N2" + U, "N2" + U].Font.Name = "Calibri";
                            //xlNewSheet12.Range["N2" + U, "N2" + U].Font.Size = 10;
                            //xlNewSheet12.Range["N2" + U, "N2" + U].Font.FontStyle = "Ragular";


                            //xlNewSheet12.Range["O2" + U, "O2" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            //xlNewSheet12.Range["O2" + U, "O2" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            //xlNewSheet12.Range["O2" + U, "O2" + U].Font.Name = "Calibri";
                            //xlNewSheet12.Range["O2" + U, "O2" + U].Font.Size = 10;
                            //xlNewSheet12.Range["O2" + U, "O2" + U].Font.FontStyle = "Ragular";




                            T++;
                        }



                        xlNewSheet12.Columns.AutoFit();

                        xlNewSheet12.get_Range("A1", "A2").Merge();
                        xlNewSheet12.get_Range("B1", "B2").Merge();
                        xlNewSheet12.get_Range("C1", "C2").Merge();
                        xlNewSheet12.get_Range("D1", "D2").Merge();
                        xlNewSheet12.get_Range("E1", "E2").Merge();
                        xlNewSheet12.get_Range("F1", "F2").Merge();
                        xlNewSheet12.get_Range("G1", "G2").Merge();
                        xlNewSheet12.get_Range("H1", "H2").Merge();
                        xlNewSheet12.get_Range("I1", "I2").Merge();
                        xlNewSheet12.get_Range("J1", "J2").Merge();
                        //xlNewSheet12.get_Range("K1", "K2").Merge();

                        xlNewSheet12.Range["A1", "A2"].Font.Bold = true;
                        xlNewSheet12.Range["A1", "A2"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet12.Range["B1", "B2"].Font.Bold = true;
                        xlNewSheet12.Range["B1", "B2"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet12.Range["C1", "C2"].Font.Bold = true;
                        xlNewSheet12.Range["C1", "C2"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet12.Range["D1", "D2"].Font.Bold = true;
                        xlNewSheet12.Range["D1", "D2"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet12.Range["E1", "E2"].Font.Bold = true;
                        xlNewSheet12.Range["E1", "E2"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet12.Range["F1", "F2"].Font.Bold = true;
                        xlNewSheet12.Range["F1", "F2"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet12.Range["G1", "G2"].Font.Bold = true;
                        xlNewSheet12.Range["G1", "G2"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet12.Range["H1", "H2"].Font.Bold = true;
                        xlNewSheet12.Range["H1", "H2"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet12.Range["I1", "I2"].Font.Bold = true;
                        xlNewSheet12.Range["I1", "I2"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet12.Range["J1", "J2"].Font.Bold = true;
                        xlNewSheet12.Range["J1", "J2"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        //xlNewSheet12.Range["K1", "K2"].Font.Bold = true;
                        //xlNewSheet12.Range["K1", "K2"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                        xlNewSheet12.Range["A1", "T1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        xlNewSheet12.Range["A2", "T2"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        xlNewSheet12.Range["A1", "T1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                        xlNewSheet12.Range["A2", "T2"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                        xlNewSheet12.Range["A1", "T1"].EntireColumn.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet12.Range["A2", "T2"].EntireColumn.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet12.get_Range("A1:T" + T).Cells.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                        xlNewSheet12.get_Range("A2:T" + T).Cells.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;

                        xlNewSheet12.Range["E1"].Cells.EntireColumn.NumberFormat = "d mmm (ddd);@";
                        xlNewSheet12.Range["F1"].Cells.EntireColumn.NumberFormat = "d mmm (ddd);@";
                        xlNewSheet12.Range["G1"].Cells.EntireColumn.NumberFormat = "d mmm (ddd);@";
                        xlNewSheet12.Range["H1"].Cells.EntireColumn.NumberFormat = "d mmm (ddd);@";
                        xlNewSheet12.Range["J1"].Cells.EntireColumn.NumberFormat = "₹0.00";
                        xlNewSheet12.Range["L1"].Cells.EntireColumn.NumberFormat = "₹0.00";
                        xlNewSheet12.Range["N1"].Cells.EntireColumn.NumberFormat = "₹0.00";
                        xlNewSheet12.Range["P1"].Cells.EntireColumn.NumberFormat = "₹0.00";
                        xlNewSheet12.Range["R1"].Cells.EntireColumn.NumberFormat = "₹0.00";
                        xlNewSheet12.Range["T1"].Cells.EntireColumn.NumberFormat = "₹0.00";

                        xlNewSheet12.get_Range("K1", "T1").Merge();
                        xlNewSheet12.get_Range("K1", "T1").Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;



                        xlNewSheet12.Select();
                        ((Excel.Worksheet)xlApp.ActiveWorkbook.Sheets[1]).Activate();
                        releaseObject(xlNewSheet12);
                        //((Excel.Worksheet)xlApp.ActiveWorkbook.Sheets[1]).Activate();

                    }

                }
                if (ReportType == "Ern_Outhouse_Cutting")
                {
                    // iKandi.Common.Constants.WorkSheetCount_ForExcel = iKandi.Common.Constants.WorkSheetCount_ForExcel + 1;
                    CultureInfo ci = new CultureInfo("en-IN");
                    ci.NumberFormat.CurrencySymbol = "₹";
                    GlobalCount = GlobalCount + 1;
                    var xlNewSheet12 = (Excel.Worksheet)worksheets.Add(worksheets[GlobalCount], Type.Missing, Type.Missing, Type.Missing);



                    xlNewSheet12.Name = "Ern_Outhouse_Cutting";
                    xlNewSheet12.Cells[1, 13] = "Cutting Detail";
                    xlNewSheet12.Cells[2, 1] = "Style Code";
                    xlNewSheet12.Cells[2, 2] = "Serial number";
                    xlNewSheet12.Cells[2, 3] = "Department Name";
                    xlNewSheet12.Cells[2, 4] = "Order Quantity";
                    xlNewSheet12.Cells[2, 5] = "Sealed Date";
                    xlNewSheet12.Cells[2, 6] = "Pattern Sample Date";
                    xlNewSheet12.Cells[2, 7] = "MinExFactory";
                    xlNewSheet12.Cells[2, 8] = "MaxExFactory";
                    xlNewSheet12.Cells[2, 9] = "SAM(Weighted)";
                    xlNewSheet12.Cells[2, 10] = "BIPL Budget";

                    xlNewSheet12.Cells[2, 11] = "Supplier1";
                    xlNewSheet12.Cells[2, 12] = "Cutting_1";
                    xlNewSheet12.Cells[2, 13] = "Supplier_2";
                    xlNewSheet12.Cells[2, 14] = "Cutting_2";
                    xlNewSheet12.Cells[2, 15] = "Supplier_3";
                    xlNewSheet12.Cells[2, 16] = "Cutting_3";
                    xlNewSheet12.Cells[2, 17] = "Supplier_4";
                    xlNewSheet12.Cells[2, 18] = "Cutting_4";
                    xlNewSheet12.Cells[2, 19] = "Supplier_5";
                    xlNewSheet12.Cells[2, 20] = "Cutting_5";




                    if (ds.Tables[0].Rows.Count == 0)
                    {
                        return false;
                    }
                    else if (ds.Tables[0].Rows.Count > 0)
                    {
                        int T = 2;
                        int U = 1;
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            //int IsVaFineLineCheck = 0;
                            //int IsVaFineLineCheck2 = 0;
                            //int IsVaFineLineCheck3 = 0;
                            //int IsVaFineLineCheck4 = 0;
                            //int IsVaFineLineCheck5 = 0;


                            int IsFinalOB = 0;
                            xlNewSheet12.Cells[T + 1, 1] = dr["StyleCode"] == DBNull.Value ? string.Empty : Convert.ToString(dr["StyleCode"]);
                            xlNewSheet12.Cells[T + 1, 2] = dr["SerialNumber"] == DBNull.Value ? string.Empty : Convert.ToString(dr["SerialNumber"]);
                            xlNewSheet12.Cells[T + 1, 3] = dr["DepartmentName"] == DBNull.Value ? string.Empty : Convert.ToString(dr["DepartmentName"]);
                            xlNewSheet12.Cells[T + 1, 4] = dr["Quantity"] == DBNull.Value ? string.Empty : Convert.ToInt32(dr["Quantity"]).ToString("N0");//Added Code by bharat on 12-12-19
                            xlNewSheet12.Cells[T + 1, 5] = dr["SealDate"] == DBNull.Value ? string.Empty : Convert.ToString(dr["SealDate"]);
                            xlNewSheet12.Cells[T + 1, 6] = dr["MinPatternsampleDate"] == DBNull.Value ? string.Empty : Convert.ToString(dr["MinPatternsampleDate"]);
                            xlNewSheet12.Cells[T + 1, 7] = dr["MinExfactory"] == DBNull.Value ? string.Empty : Convert.ToString(dr["MinExfactory"]);
                            xlNewSheet12.Cells[T + 1, 8] = dr["MaxExfactory"] == DBNull.Value ? string.Empty : Convert.ToString(dr["MaxExfactory"]);
                            xlNewSheet12.Cells[T + 1, 9] = dr["Sam"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Sam"]);
                            xlNewSheet12.Cells[T + 1, 10] = dr["biplbudget"] == DBNull.Value ? string.Empty : Convert.ToString(dr["biplbudget"]);



                            //xlNewSheet11.Cells[S + 1, 10].Color = System.Drawing.Color.AliceBlue;₹

                            xlNewSheet12.Cells[T + 1, 11] = dr["VA_Stch_Supplier_1"] == DBNull.Value ? string.Empty : Convert.ToString(dr["VA_Stch_Supplier_1"]);
                            xlNewSheet12.Cells[T + 1, 12] = dr["VA_Stch_Rate_1"] == DBNull.Value ? string.Empty : Convert.ToString(dr["VA_Stch_Rate_1"]);
                            xlNewSheet12.Cells[T + 1, 13] = dr["VA_Stch_Supplier_2"] == DBNull.Value ? string.Empty : Convert.ToString(dr["VA_Stch_Supplier_2"]);
                            xlNewSheet12.Cells[T + 1, 14] = dr["VA_Stch_Rate_2"] == DBNull.Value ? string.Empty : Convert.ToString(dr["VA_Stch_Rate_2"]);
                            xlNewSheet12.Cells[T + 1, 15] = dr["VA_Stch_Supplier_3"] == DBNull.Value ? string.Empty : Convert.ToString(dr["VA_Stch_Supplier_3"]);
                            xlNewSheet12.Cells[T + 1, 16] = dr["VA_Stch_Rate_3"] == DBNull.Value ? string.Empty : Convert.ToString(dr["VA_Stch_Rate_3"]);
                            xlNewSheet12.Cells[T + 1, 17] = dr["VA_Stch_Supplier_4"] == DBNull.Value ? string.Empty : Convert.ToString(dr["VA_Stch_Supplier_4"]);

                            xlNewSheet12.Cells[T + 1, 18] = dr["VA_Stch_Rate_4"] == DBNull.Value ? string.Empty : Convert.ToString(dr["VA_Stch_Rate_4"]);
                            xlNewSheet12.Cells[T + 1, 19] = dr["VA_Stch_Supplier_5"] == DBNull.Value ? string.Empty : Convert.ToString(dr["VA_Stch_Supplier_5"]);
                            xlNewSheet12.Cells[T + 1, 20] = dr["VA_Stch_Rate_5"] == DBNull.Value ? string.Empty : Convert.ToString(dr["VA_Stch_Rate_5"]);
                            IsFinalOB = dr["IsFinalOB"] == DBNull.Value ? 0 : Convert.ToInt32(dr["IsFinalOB"]);

                            U = T + 1;



                            xlNewSheet12.Range["A" + U, "A" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet12.Range["A" + U, "A" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet12.Range["A" + U, "A" + U].Font.Name = "Calibri";
                            xlNewSheet12.Range["A" + U, "A" + U].Font.Size = 11;
                            xlNewSheet12.Range["A" + U, "A" + U].Font.FontStyle = "Bold";



                            xlNewSheet12.Range["B" + U, "B" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet12.Range["B" + U, "B" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet12.Range["B" + U, "B" + U].Font.Name = "Calibri";
                            xlNewSheet12.Range["B" + U, "B" + U].Font.Size = 11;
                            xlNewSheet12.Range["B" + U, "B" + U].Font.FontStyle = "Bold";
                            xlNewSheet12.Range["B" + U, "B" + U].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.DarkBlue);




                            xlNewSheet12.Range["C" + U, "C" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet12.Range["C" + U, "C" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet12.Range["C" + U, "C" + U].Font.Name = "Calibri";
                            xlNewSheet12.Range["C" + U, "C" + U].Font.Size = 10;
                            xlNewSheet12.Range["C" + U, "C" + U].Font.FontStyle = "Ragular";

                            if (IsFinalOB == 0)
                            {
                                xlNewSheet12.Range["A" + U, "A" + U].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Red);

                                //xlNewSheet12.get_Range("A2", "A2").Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;

                            }

                            xlNewSheet12.Range["D" + U, "D" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet12.Range["D" + U, "D" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet12.Range["D" + U, "D" + U].Font.Name = "Calibri";
                            xlNewSheet12.Range["D" + U, "D" + U].Font.Size = 12;
                            xlNewSheet12.Range["D" + U, "D" + U].Font.FontStyle = "Bold";



                            xlNewSheet12.Range["E" + U, "E" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet12.Range["E" + U, "E" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet12.Range["E" + U, "E" + U].Font.Name = "Calibri";
                            xlNewSheet12.Range["E" + U, "E" + U].Font.Size = 10;
                            xlNewSheet12.Range["E" + U, "E" + U].Font.FontStyle = "Ragular";
                            xlNewSheet12.Range["E" + U, "E" + U].Font.FontStyle = "Bold";

                            xlNewSheet12.Range["F" + U, "F" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet12.Range["F" + U, "F" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet12.Range["F" + U, "F" + U].Font.Name = "Calibri";
                            xlNewSheet12.Range["F" + U, "F" + U].Font.Size = 10;
                            xlNewSheet12.Range["F" + U, "F" + U].Font.FontStyle = "Ragular";


                            xlNewSheet12.Range["G" + U, "G" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet12.Range["G" + U, "G" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet12.Range["G" + U, "G" + U].Font.Name = "Calibri";
                            xlNewSheet12.Range["G" + U, "G" + U].Font.Size = 10;
                            xlNewSheet12.Range["G" + U, "G" + U].Font.FontStyle = "Ragular";

                            xlNewSheet12.Range["H" + U, "H" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet12.Range["H" + U, "H" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet12.Range["H" + U, "H" + U].Font.Name = "Calibri";
                            xlNewSheet12.Range["H" + U, "H" + U].Font.Size = 10;
                            xlNewSheet12.Range["H" + U, "H" + U].Font.FontStyle = "Ragular";


                            xlNewSheet12.Range["I" + U, "I" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet12.Range["I" + U, "I" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet12.Range["I" + U, "I" + U].Font.Name = "Calibri";
                            xlNewSheet12.Range["I" + U, "I" + U].Font.Size = 10;
                            xlNewSheet12.Range["I" + U, "I" + U].Font.FontStyle = "Bold";

                            xlNewSheet12.Range["J" + U, "J" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet12.Range["J" + U, "J" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet12.Range["J" + U, "J" + U].Font.Name = "Calibri";
                            xlNewSheet12.Range["J" + U, "J" + U].Font.Size = 11;
                            xlNewSheet12.Range["J" + U, "J" + U].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red);
                            xlNewSheet12.Range["J" + U, "J" + U].Font.FontStyle = "Bold";


                            xlNewSheet12.Range["K" + U, "K" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet12.Range["K" + U, "K" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet12.Range["K" + U, "K" + U].Font.Name = "Calibri";
                            xlNewSheet12.Range["K" + U, "K" + U].Font.Size = 11;
                            xlNewSheet12.Range["K" + U, "K" + U].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.DarkBlue);
                            xlNewSheet12.Range["K" + U, "K" + U].Font.FontStyle = "Bold";

                            xlNewSheet12.Range["L" + U, "L" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet12.Range["L" + U, "L" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet12.Range["L" + U, "L" + U].Font.Name = "Calibri";
                            xlNewSheet12.Range["L" + U, "L" + U].Font.Size = 11;
                            xlNewSheet12.Range["L" + U, "L" + U].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Green);
                            xlNewSheet12.Range["L" + U, "L" + U].Font.FontStyle = "Bold";

                            xlNewSheet12.Range["M" + U, "M" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet12.Range["M" + U, "M" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet12.Range["M" + U, "M" + U].Font.Name = "Calibri";
                            xlNewSheet12.Range["M" + U, "M" + U].Font.Size = 11;
                            xlNewSheet12.Range["M" + U, "M" + U].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.DarkBlue);
                            xlNewSheet12.Range["M" + U, "M" + U].Font.FontStyle = "Bold";

                            xlNewSheet12.Range["N" + U, "N" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet12.Range["N" + U, "N" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet12.Range["N" + U, "N" + U].Font.Name = "Calibri";
                            xlNewSheet12.Range["N" + U, "N" + U].Font.Size = 11;
                            xlNewSheet12.Range["N" + U, "N" + U].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Green);
                            xlNewSheet12.Range["N" + U, "N" + U].Font.FontStyle = "Bold";

                            xlNewSheet12.Range["O" + U, "O" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet12.Range["O" + U, "O" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet12.Range["O" + U, "O" + U].Font.Name = "Calibri";
                            xlNewSheet12.Range["O" + U, "O" + U].Font.Size = 11;
                            xlNewSheet12.Range["O" + U, "O" + U].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.DarkBlue);
                            xlNewSheet12.Range["O" + U, "O" + U].Font.FontStyle = "Bold";

                            xlNewSheet12.Range["P" + U, "P" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet12.Range["P" + U, "P" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet12.Range["P" + U, "P" + U].Font.Name = "Calibri";
                            xlNewSheet12.Range["P" + U, "P" + U].Font.Size = 11;
                            xlNewSheet12.Range["P" + U, "P" + U].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Green);
                            xlNewSheet12.Range["P" + U, "P" + U].Font.FontStyle = "Bold";

                            xlNewSheet12.Range["Q" + U, "Q" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet12.Range["Q" + U, "Q" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet12.Range["Q" + U, "Q" + U].Font.Name = "Calibri";
                            xlNewSheet12.Range["Q" + U, "Q" + U].Font.Size = 11;
                            xlNewSheet12.Range["Q" + U, "Q" + U].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.DarkBlue);
                            xlNewSheet12.Range["Q" + U, "Q" + U].Font.FontStyle = "Bold";

                            xlNewSheet12.Range["R" + U, "R" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet12.Range["R" + U, "R" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet12.Range["R" + U, "R" + U].Font.Name = "Calibri";
                            xlNewSheet12.Range["R" + U, "R" + U].Font.Size = 11;
                            xlNewSheet12.Range["R" + U, "R" + U].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Green);
                            xlNewSheet12.Range["R" + U, "R" + U].Font.FontStyle = "Bold";

                            xlNewSheet12.Range["S" + U, "S" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet12.Range["S" + U, "S" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet12.Range["S" + U, "S" + U].Font.Name = "Calibri";
                            xlNewSheet12.Range["S" + U, "S" + U].Font.Size = 11;
                            xlNewSheet12.Range["S" + U, "S" + U].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.DarkBlue);
                            xlNewSheet12.Range["S" + U, "S" + U].Font.FontStyle = "Bold";

                            xlNewSheet12.Range["T" + U, "T" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet12.Range["T" + U, "T" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet12.Range["T" + U, "T" + U].Font.Name = "Calibri";
                            xlNewSheet12.Range["T" + U, "T" + U].Font.Size = 11;
                            xlNewSheet12.Range["T" + U, "T" + U].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Green);
                            xlNewSheet12.Range["T" + U, "T" + U].Font.FontStyle = "Bold";


                            //xlNewSheet12.Range["J" + U, "J" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            //xlNewSheet12.Range["J" + U, "J" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            //xlNewSheet12.Range["J" + U, "J" + U].Font.Name = "Calibri";
                            //xlNewSheet12.Range["J" + U, "J" + U].Font.Size = 12;
                            //xlNewSheet12.Range["J" + U, "J" + U].Font.FontStyle = "Bold";

                            //xlNewSheet12.Range["K2" + U, "K2" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            //xlNewSheet12.Range["K2" + U, "K2" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            //xlNewSheet12.Range["K2" + U, "K2" + U].Font.Name = "Calibri";
                            //xlNewSheet12.Range["K2" + U, "K2" + U].Font.Size = 10;
                            //xlNewSheet12.Range["K2" + U, "K2" + U].Font.FontStyle = "Ragular";

                            //xlNewSheet12.Range["L" + U, "L" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            //xlNewSheet12.Range["L" + U, "L" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            //xlNewSheet12.Range["L" + U, "L" + U].Font.Name = "Calibri";
                            //xlNewSheet12.Range["L" + U, "L" + U].Font.Size = 10;
                            //xlNewSheet12.Range["L" + U, "L" + U].Font.FontStyle = "Ragular";
                            //xlNewSheet12.Range["L" + U, "L" + U].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red);
                            //xlNewSheet12.Range["L" + U, "L" + U].Font.FontStyle = "Bold";




                            //xlNewSheet12.Range["M2" + U, "M2" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            //xlNewSheet12.Range["M2" + U, "M2" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            //xlNewSheet12.Range["M2" + U, "M2" + U].Font.Name = "Calibri";
                            //xlNewSheet12.Range["M2" + U, "M2" + U].Font.Size = 10;
                            //xlNewSheet12.Range["M2" + U, "M2" + U].Font.FontStyle = "Ragular";

                            //xlNewSheet12.Range["N2" + U, "N2" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            //xlNewSheet12.Range["N2" + U, "N2" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            //xlNewSheet12.Range["N2" + U, "N2" + U].Font.Name = "Calibri";
                            //xlNewSheet12.Range["N2" + U, "N2" + U].Font.Size = 10;
                            //xlNewSheet12.Range["N2" + U, "N2" + U].Font.FontStyle = "Ragular";


                            //xlNewSheet12.Range["O2" + U, "O2" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            //xlNewSheet12.Range["O2" + U, "O2" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            //xlNewSheet12.Range["O2" + U, "O2" + U].Font.Name = "Calibri";
                            //xlNewSheet12.Range["O2" + U, "O2" + U].Font.Size = 10;
                            //xlNewSheet12.Range["O2" + U, "O2" + U].Font.FontStyle = "Ragular";




                            T++;
                        }



                        xlNewSheet12.Columns.AutoFit();

                        xlNewSheet12.get_Range("A1", "A2").Merge();
                        xlNewSheet12.get_Range("B1", "B2").Merge();
                        xlNewSheet12.get_Range("C1", "C2").Merge();
                        xlNewSheet12.get_Range("D1", "D2").Merge();
                        xlNewSheet12.get_Range("E1", "E2").Merge();
                        xlNewSheet12.get_Range("F1", "F2").Merge();
                        xlNewSheet12.get_Range("G1", "G2").Merge();
                        xlNewSheet12.get_Range("H1", "H2").Merge();
                        xlNewSheet12.get_Range("I1", "I2").Merge();
                        xlNewSheet12.get_Range("J1", "J2").Merge();
                        //xlNewSheet12.get_Range("K1", "K2").Merge();

                        xlNewSheet12.Range["A1", "A2"].Font.Bold = true;
                        xlNewSheet12.Range["A1", "A2"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet12.Range["B1", "B2"].Font.Bold = true;
                        xlNewSheet12.Range["B1", "B2"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet12.Range["C1", "C2"].Font.Bold = true;
                        xlNewSheet12.Range["C1", "C2"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet12.Range["D1", "D2"].Font.Bold = true;
                        xlNewSheet12.Range["D1", "D2"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet12.Range["E1", "E2"].Font.Bold = true;
                        xlNewSheet12.Range["E1", "E2"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet12.Range["F1", "F2"].Font.Bold = true;
                        xlNewSheet12.Range["F1", "F2"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet12.Range["G1", "G2"].Font.Bold = true;
                        xlNewSheet12.Range["G1", "G2"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet12.Range["H1", "H2"].Font.Bold = true;
                        xlNewSheet12.Range["H1", "H2"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet12.Range["I1", "I2"].Font.Bold = true;
                        xlNewSheet12.Range["I1", "I2"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet12.Range["J1", "J2"].Font.Bold = true;
                        xlNewSheet12.Range["J1", "J2"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        //xlNewSheet12.Range["K1", "K2"].Font.Bold = true;
                        //xlNewSheet12.Range["K1", "K2"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                        xlNewSheet12.Range["A1", "T1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        xlNewSheet12.Range["A2", "T2"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        xlNewSheet12.Range["A1", "T1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                        xlNewSheet12.Range["A2", "T2"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                        xlNewSheet12.Range["A1", "T1"].EntireColumn.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet12.Range["A2", "T2"].EntireColumn.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet12.get_Range("A1:T" + T).Cells.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                        xlNewSheet12.get_Range("A2:T" + T).Cells.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;

                        xlNewSheet12.Range["E1"].Cells.EntireColumn.NumberFormat = "d mmm (ddd);@";
                        xlNewSheet12.Range["F1"].Cells.EntireColumn.NumberFormat = "d mmm (ddd);@";
                        xlNewSheet12.Range["G1"].Cells.EntireColumn.NumberFormat = "d mmm (ddd);@";
                        xlNewSheet12.Range["H1"].Cells.EntireColumn.NumberFormat = "d mmm (ddd);@";

                        xlNewSheet12.Range["J1"].Cells.EntireColumn.NumberFormat = "₹0.00";
                        xlNewSheet12.Range["L1"].Cells.EntireColumn.NumberFormat = "₹0.00";
                        xlNewSheet12.Range["N1"].Cells.EntireColumn.NumberFormat = "₹0.00";
                        xlNewSheet12.Range["P1"].Cells.EntireColumn.NumberFormat = "₹0.00";
                        xlNewSheet12.Range["R1"].Cells.EntireColumn.NumberFormat = "₹0.00";
                        xlNewSheet12.Range["T1"].Cells.EntireColumn.NumberFormat = "₹0.00";



                        xlNewSheet12.get_Range("K1", "T1").Merge();
                        xlNewSheet12.get_Range("K1", "T1").Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;



                        xlNewSheet12.Select();
                        ((Excel.Worksheet)xlApp.ActiveWorkbook.Sheets[1]).Activate();
                        releaseObject(xlNewSheet12);
                        //((Excel.Worksheet)xlApp.ActiveWorkbook.Sheets[1]).Activate();

                    }

                }
                if (ReportType == "Ern_Outhouse")
                {
                    // iKandi.Common.Constants.WorkSheetCount_ForExcel = iKandi.Common.Constants.WorkSheetCount_ForExcel + 1;
                    CultureInfo ci = new CultureInfo("en-IN");
                    ci.NumberFormat.CurrencySymbol = "₹";
                    GlobalCount = GlobalCount + 1;
                    var xlNewSheet12 = (Excel.Worksheet)worksheets.Add(worksheets[GlobalCount], Type.Missing, Type.Missing, Type.Missing);



                    xlNewSheet12.Name = "Ern_Outhouse";
                    xlNewSheet12.Cells[1, 13] = "Stitch Detail";
                    xlNewSheet12.Cells[2, 1] = "Style Code";
                    xlNewSheet12.Cells[2, 2] = "Serial number";
                    xlNewSheet12.Cells[2, 3] = "Department Name";
                    xlNewSheet12.Cells[2, 4] = "Order Quantity";
                    xlNewSheet12.Cells[2, 5] = "Sealed Date";
                    xlNewSheet12.Cells[2, 6] = "Pattern Sample Date";
                    xlNewSheet12.Cells[2, 7] = "MinExFactory";
                    xlNewSheet12.Cells[2, 8] = "MaxExFactory";
                    xlNewSheet12.Cells[2, 9] = "SAM(Weighted)";
                    xlNewSheet12.Cells[2, 10] = "BIPL Budget";

                    xlNewSheet12.Cells[2, 11] = "Supplier1";
                    xlNewSheet12.Cells[2, 12] = "Stitch_1";
                    xlNewSheet12.Cells[2, 13] = "Supplier_2";
                    xlNewSheet12.Cells[2, 14] = "Stitch_2";
                    xlNewSheet12.Cells[2, 15] = "Supplier_3";
                    xlNewSheet12.Cells[2, 16] = "Stitch_3";
                    xlNewSheet12.Cells[2, 17] = "Supplier_4";
                    xlNewSheet12.Cells[2, 18] = "Stitch_4";
                    xlNewSheet12.Cells[2, 19] = "Supplier_5";
                    xlNewSheet12.Cells[2, 20] = "Stitch_5";




                    if (ds.Tables[0].Rows.Count == 0)
                    {
                        return false;
                    }
                    else if (ds.Tables[0].Rows.Count > 0)
                    {
                        int T = 2;
                        int U = 1;
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            //int IsVaFineLineCheck = 0;
                            //int IsVaFineLineCheck2 = 0;
                            //int IsVaFineLineCheck3 = 0;
                            //int IsVaFineLineCheck4 = 0;
                            //int IsVaFineLineCheck5 = 0;


                            int IsFinalOB = 0;
                            xlNewSheet12.Cells[T + 1, 1] = dr["StyleCode"] == DBNull.Value ? string.Empty : Convert.ToString(dr["StyleCode"]);
                            xlNewSheet12.Cells[T + 1, 2] = dr["SerialNumber"] == DBNull.Value ? string.Empty : Convert.ToString(dr["SerialNumber"]);
                            xlNewSheet12.Cells[T + 1, 3] = dr["DepartmentName"] == DBNull.Value ? string.Empty : Convert.ToString(dr["DepartmentName"]);
                            xlNewSheet12.Cells[T + 1, 4] = dr["Quantity"] == DBNull.Value ? string.Empty : Convert.ToInt32(dr["Quantity"]).ToString("N0"); // Add Code Bharat On 12-12-19
                            xlNewSheet12.Cells[T + 1, 5] = dr["SealDate"] == DBNull.Value ? string.Empty : Convert.ToString(dr["SealDate"]);
                            xlNewSheet12.Cells[T + 1, 6] = dr["MinPatternsampleDate"] == DBNull.Value ? string.Empty : Convert.ToString(dr["MinPatternsampleDate"]);
                            xlNewSheet12.Cells[T + 1, 7] = dr["MinExfactory"] == DBNull.Value ? string.Empty : Convert.ToString(dr["MinExfactory"]);
                            xlNewSheet12.Cells[T + 1, 8] = dr["MaxExfactory"] == DBNull.Value ? string.Empty : Convert.ToString(dr["MaxExfactory"]);
                            xlNewSheet12.Cells[T + 1, 9] = dr["Sam"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Sam"]);
                            xlNewSheet12.Cells[T + 1, 10] = dr["biplbudget"] == DBNull.Value ? string.Empty : Convert.ToString(dr["biplbudget"]);



                            //xlNewSheet11.Cells[S + 1, 10].Color = System.Drawing.Color.AliceBlue;₹

                            xlNewSheet12.Cells[T + 1, 11] = dr["VA_Stch_Supplier_1"] == DBNull.Value ? string.Empty : Convert.ToString(dr["VA_Stch_Supplier_1"]);
                            xlNewSheet12.Cells[T + 1, 12] = dr["VA_Stch_Rate_1"] == DBNull.Value ? string.Empty : Convert.ToString(dr["VA_Stch_Rate_1"]);
                            xlNewSheet12.Cells[T + 1, 13] = dr["VA_Stch_Supplier_2"] == DBNull.Value ? string.Empty : Convert.ToString(dr["VA_Stch_Supplier_2"]);
                            xlNewSheet12.Cells[T + 1, 14] = dr["VA_Stch_Rate_2"] == DBNull.Value ? string.Empty : Convert.ToString(dr["VA_Stch_Rate_2"]);
                            xlNewSheet12.Cells[T + 1, 15] = dr["VA_Stch_Supplier_3"] == DBNull.Value ? string.Empty : Convert.ToString(dr["VA_Stch_Supplier_3"]);
                            xlNewSheet12.Cells[T + 1, 16] = dr["VA_Stch_Rate_3"] == DBNull.Value ? string.Empty : Convert.ToString(dr["VA_Stch_Rate_3"]);
                            xlNewSheet12.Cells[T + 1, 17] = dr["VA_Stch_Supplier_4"] == DBNull.Value ? string.Empty : Convert.ToString(dr["VA_Stch_Supplier_4"]);

                            xlNewSheet12.Cells[T + 1, 18] = dr["VA_Stch_Rate_4"] == DBNull.Value ? string.Empty : Convert.ToString(dr["VA_Stch_Rate_4"]);
                            xlNewSheet12.Cells[T + 1, 19] = dr["VA_Stch_Supplier_5"] == DBNull.Value ? string.Empty : Convert.ToString(dr["VA_Stch_Supplier_5"]);
                            xlNewSheet12.Cells[T + 1, 20] = dr["VA_Stch_Rate_5"] == DBNull.Value ? string.Empty : Convert.ToString(dr["VA_Stch_Rate_5"]);
                            IsFinalOB = dr["IsFinalOB"] == DBNull.Value ? 0 : Convert.ToInt32(dr["IsFinalOB"]);

                            U = T + 1;



                            xlNewSheet12.Range["A" + U, "A" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet12.Range["A" + U, "A" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet12.Range["A" + U, "A" + U].Font.Name = "Calibri";
                            xlNewSheet12.Range["A" + U, "A" + U].Font.Size = 11;
                            xlNewSheet12.Range["A" + U, "A" + U].Font.FontStyle = "Bold";



                            xlNewSheet12.Range["B" + U, "B" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet12.Range["B" + U, "B" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet12.Range["B" + U, "B" + U].Font.Name = "Calibri";
                            xlNewSheet12.Range["B" + U, "B" + U].Font.Size = 11;
                            xlNewSheet12.Range["B" + U, "B" + U].Font.FontStyle = "Bold";
                            xlNewSheet12.Range["B" + U, "B" + U].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.DarkBlue);




                            xlNewSheet12.Range["C" + U, "C" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet12.Range["C" + U, "C" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet12.Range["C" + U, "C" + U].Font.Name = "Calibri";
                            xlNewSheet12.Range["C" + U, "C" + U].Font.Size = 10;
                            xlNewSheet12.Range["C" + U, "C" + U].Font.FontStyle = "Ragular";

                            if (IsFinalOB == 0)
                            {
                                xlNewSheet12.Range["A" + U, "A" + U].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Red);

                                //xlNewSheet12.get_Range("A2", "A2").Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;

                            }

                            xlNewSheet12.Range["D" + U, "D" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet12.Range["D" + U, "D" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet12.Range["D" + U, "D" + U].Font.Name = "Calibri";
                            xlNewSheet12.Range["D" + U, "D" + U].Font.Size = 12;
                            xlNewSheet12.Range["D" + U, "D" + U].Font.FontStyle = "Bold";



                            xlNewSheet12.Range["E" + U, "E" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet12.Range["E" + U, "E" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet12.Range["E" + U, "E" + U].Font.Name = "Calibri";
                            xlNewSheet12.Range["E" + U, "E" + U].Font.Size = 10;
                            xlNewSheet12.Range["E" + U, "E" + U].Font.FontStyle = "Ragular";
                            xlNewSheet12.Range["E" + U, "E" + U].Font.FontStyle = "Bold";

                            xlNewSheet12.Range["F" + U, "F" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet12.Range["F" + U, "F" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet12.Range["F" + U, "F" + U].Font.Name = "Calibri";
                            xlNewSheet12.Range["F" + U, "F" + U].Font.Size = 10;
                            xlNewSheet12.Range["F" + U, "F" + U].Font.FontStyle = "Ragular";


                            xlNewSheet12.Range["G" + U, "G" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet12.Range["G" + U, "G" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet12.Range["G" + U, "G" + U].Font.Name = "Calibri";
                            xlNewSheet12.Range["G" + U, "G" + U].Font.Size = 10;
                            xlNewSheet12.Range["G" + U, "G" + U].Font.FontStyle = "Ragular";

                            xlNewSheet12.Range["H" + U, "H" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet12.Range["H" + U, "H" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet12.Range["H" + U, "H" + U].Font.Name = "Calibri";
                            xlNewSheet12.Range["H" + U, "H" + U].Font.Size = 10;
                            xlNewSheet12.Range["H" + U, "H" + U].Font.FontStyle = "Ragular";


                            xlNewSheet12.Range["I" + U, "I" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet12.Range["I" + U, "I" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet12.Range["I" + U, "I" + U].Font.Name = "Calibri";
                            xlNewSheet12.Range["I" + U, "I" + U].Font.Size = 10;
                            xlNewSheet12.Range["I" + U, "I" + U].Font.FontStyle = "Bold";

                            xlNewSheet12.Range["J" + U, "J" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet12.Range["J" + U, "J" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet12.Range["J" + U, "J" + U].Font.Name = "Calibri";
                            xlNewSheet12.Range["J" + U, "J" + U].Font.Size = 11;
                            xlNewSheet12.Range["J" + U, "J" + U].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red);
                            xlNewSheet12.Range["J" + U, "J" + U].Font.FontStyle = "Bold";


                            xlNewSheet12.Range["K" + U, "K" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet12.Range["K" + U, "K" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet12.Range["K" + U, "K" + U].Font.Name = "Calibri";
                            xlNewSheet12.Range["K" + U, "K" + U].Font.Size = 11;
                            xlNewSheet12.Range["K" + U, "K" + U].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.DarkBlue);
                            xlNewSheet12.Range["K" + U, "K" + U].Font.FontStyle = "Bold";

                            xlNewSheet12.Range["L" + U, "L" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet12.Range["L" + U, "L" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet12.Range["L" + U, "L" + U].Font.Name = "Calibri";
                            xlNewSheet12.Range["L" + U, "L" + U].Font.Size = 11;
                            xlNewSheet12.Range["L" + U, "L" + U].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Green);
                            xlNewSheet12.Range["L" + U, "L" + U].Font.FontStyle = "Bold";

                            xlNewSheet12.Range["M" + U, "M" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet12.Range["M" + U, "M" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet12.Range["M" + U, "M" + U].Font.Name = "Calibri";
                            xlNewSheet12.Range["M" + U, "M" + U].Font.Size = 11;
                            xlNewSheet12.Range["M" + U, "M" + U].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.DarkBlue);
                            xlNewSheet12.Range["M" + U, "M" + U].Font.FontStyle = "Bold";

                            xlNewSheet12.Range["N" + U, "N" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet12.Range["N" + U, "N" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet12.Range["N" + U, "N" + U].Font.Name = "Calibri";
                            xlNewSheet12.Range["N" + U, "N" + U].Font.Size = 11;
                            xlNewSheet12.Range["N" + U, "N" + U].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Green);
                            xlNewSheet12.Range["N" + U, "N" + U].Font.FontStyle = "Bold";

                            xlNewSheet12.Range["O" + U, "O" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet12.Range["O" + U, "O" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet12.Range["O" + U, "O" + U].Font.Name = "Calibri";
                            xlNewSheet12.Range["O" + U, "O" + U].Font.Size = 11;
                            xlNewSheet12.Range["O" + U, "O" + U].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.DarkBlue);
                            xlNewSheet12.Range["O" + U, "O" + U].Font.FontStyle = "Bold";

                            xlNewSheet12.Range["P" + U, "P" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet12.Range["P" + U, "P" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet12.Range["P" + U, "P" + U].Font.Name = "Calibri";
                            xlNewSheet12.Range["P" + U, "P" + U].Font.Size = 11;
                            xlNewSheet12.Range["P" + U, "P" + U].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Green);
                            xlNewSheet12.Range["P" + U, "P" + U].Font.FontStyle = "Bold";

                            xlNewSheet12.Range["Q" + U, "Q" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet12.Range["Q" + U, "Q" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet12.Range["Q" + U, "Q" + U].Font.Name = "Calibri";
                            xlNewSheet12.Range["Q" + U, "Q" + U].Font.Size = 11;
                            xlNewSheet12.Range["Q" + U, "Q" + U].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.DarkBlue);
                            xlNewSheet12.Range["Q" + U, "Q" + U].Font.FontStyle = "Bold";

                            xlNewSheet12.Range["R" + U, "R" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet12.Range["R" + U, "R" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet12.Range["R" + U, "R" + U].Font.Name = "Calibri";
                            xlNewSheet12.Range["R" + U, "R" + U].Font.Size = 11;
                            xlNewSheet12.Range["R" + U, "R" + U].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Green);
                            xlNewSheet12.Range["R" + U, "R" + U].Font.FontStyle = "Bold";

                            xlNewSheet12.Range["S" + U, "S" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet12.Range["S" + U, "S" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet12.Range["S" + U, "S" + U].Font.Name = "Calibri";
                            xlNewSheet12.Range["S" + U, "S" + U].Font.Size = 11;
                            xlNewSheet12.Range["S" + U, "S" + U].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.DarkBlue);
                            xlNewSheet12.Range["S" + U, "S" + U].Font.FontStyle = "Bold";

                            xlNewSheet12.Range["T" + U, "T" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet12.Range["T" + U, "T" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet12.Range["T" + U, "T" + U].Font.Name = "Calibri";
                            xlNewSheet12.Range["T" + U, "T" + U].Font.Size = 11;
                            xlNewSheet12.Range["T" + U, "T" + U].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Green);
                            xlNewSheet12.Range["T" + U, "T" + U].Font.FontStyle = "Bold";


                            //xlNewSheet12.Range["J" + U, "J" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            //xlNewSheet12.Range["J" + U, "J" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            //xlNewSheet12.Range["J" + U, "J" + U].Font.Name = "Calibri";
                            //xlNewSheet12.Range["J" + U, "J" + U].Font.Size = 12;
                            //xlNewSheet12.Range["J" + U, "J" + U].Font.FontStyle = "Bold";

                            //xlNewSheet12.Range["K2" + U, "K2" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            //xlNewSheet12.Range["K2" + U, "K2" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            //xlNewSheet12.Range["K2" + U, "K2" + U].Font.Name = "Calibri";
                            //xlNewSheet12.Range["K2" + U, "K2" + U].Font.Size = 10;
                            //xlNewSheet12.Range["K2" + U, "K2" + U].Font.FontStyle = "Ragular";

                            //xlNewSheet12.Range["L" + U, "L" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            //xlNewSheet12.Range["L" + U, "L" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            //xlNewSheet12.Range["L" + U, "L" + U].Font.Name = "Calibri";
                            //xlNewSheet12.Range["L" + U, "L" + U].Font.Size = 10;
                            //xlNewSheet12.Range["L" + U, "L" + U].Font.FontStyle = "Ragular";
                            //xlNewSheet12.Range["L" + U, "L" + U].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red);
                            //xlNewSheet12.Range["L" + U, "L" + U].Font.FontStyle = "Bold";




                            //xlNewSheet12.Range["M2" + U, "M2" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            //xlNewSheet12.Range["M2" + U, "M2" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            //xlNewSheet12.Range["M2" + U, "M2" + U].Font.Name = "Calibri";
                            //xlNewSheet12.Range["M2" + U, "M2" + U].Font.Size = 10;
                            //xlNewSheet12.Range["M2" + U, "M2" + U].Font.FontStyle = "Ragular";

                            //xlNewSheet12.Range["N2" + U, "N2" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            //xlNewSheet12.Range["N2" + U, "N2" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            //xlNewSheet12.Range["N2" + U, "N2" + U].Font.Name = "Calibri";
                            //xlNewSheet12.Range["N2" + U, "N2" + U].Font.Size = 10;
                            //xlNewSheet12.Range["N2" + U, "N2" + U].Font.FontStyle = "Ragular";


                            //xlNewSheet12.Range["O2" + U, "O2" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            //xlNewSheet12.Range["O2" + U, "O2" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            //xlNewSheet12.Range["O2" + U, "O2" + U].Font.Name = "Calibri";
                            //xlNewSheet12.Range["O2" + U, "O2" + U].Font.Size = 10;
                            //xlNewSheet12.Range["O2" + U, "O2" + U].Font.FontStyle = "Ragular";




                            T++;
                        }



                        xlNewSheet12.Columns.AutoFit();

                        xlNewSheet12.get_Range("A1", "A2").Merge();
                        xlNewSheet12.get_Range("B1", "B2").Merge();
                        xlNewSheet12.get_Range("C1", "C2").Merge();
                        xlNewSheet12.get_Range("D1", "D2").Merge();
                        xlNewSheet12.get_Range("E1", "E2").Merge();
                        xlNewSheet12.get_Range("F1", "F2").Merge();
                        xlNewSheet12.get_Range("G1", "G2").Merge();
                        xlNewSheet12.get_Range("H1", "H2").Merge();
                        xlNewSheet12.get_Range("I1", "I2").Merge();
                        xlNewSheet12.get_Range("J1", "J2").Merge();
                        //xlNewSheet12.get_Range("K1", "K2").Merge();

                        xlNewSheet12.Range["A1", "A2"].Font.Bold = true;
                        xlNewSheet12.Range["A1", "A2"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet12.Range["B1", "B2"].Font.Bold = true;
                        xlNewSheet12.Range["B1", "B2"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet12.Range["C1", "C2"].Font.Bold = true;
                        xlNewSheet12.Range["C1", "C2"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet12.Range["D1", "D2"].Font.Bold = true;
                        xlNewSheet12.Range["D1", "D2"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet12.Range["E1", "E2"].Font.Bold = true;
                        xlNewSheet12.Range["E1", "E2"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet12.Range["F1", "F2"].Font.Bold = true;
                        xlNewSheet12.Range["F1", "F2"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet12.Range["G1", "G2"].Font.Bold = true;
                        xlNewSheet12.Range["G1", "G2"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet12.Range["H1", "H2"].Font.Bold = true;
                        xlNewSheet12.Range["H1", "H2"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet12.Range["I1", "I2"].Font.Bold = true;
                        xlNewSheet12.Range["I1", "I2"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet12.Range["J1", "J2"].Font.Bold = true;
                        xlNewSheet12.Range["J1", "J2"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        //xlNewSheet12.Range["K1", "K2"].Font.Bold = true;
                        //xlNewSheet12.Range["K1", "K2"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                        xlNewSheet12.Range["A1", "T1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        xlNewSheet12.Range["A2", "T2"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        xlNewSheet12.Range["A1", "T1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                        xlNewSheet12.Range["A2", "T2"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                        xlNewSheet12.Range["A1", "T1"].EntireColumn.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet12.Range["A2", "T2"].EntireColumn.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet12.get_Range("A1:T" + T).Cells.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                        xlNewSheet12.get_Range("A2:T" + T).Cells.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;

                        xlNewSheet12.Range["E1"].Cells.EntireColumn.NumberFormat = "d mmm (ddd);@";
                        xlNewSheet12.Range["F1"].Cells.EntireColumn.NumberFormat = "d mmm (ddd);@";
                        xlNewSheet12.Range["G1"].Cells.EntireColumn.NumberFormat = "d mmm (ddd);@";
                        xlNewSheet12.Range["H1"].Cells.EntireColumn.NumberFormat = "d mmm (ddd);@";

                        xlNewSheet12.Range["J1"].Cells.EntireColumn.NumberFormat = "₹0.00";
                        xlNewSheet12.Range["L1"].Cells.EntireColumn.NumberFormat = "₹0.00";
                        xlNewSheet12.Range["N1"].Cells.EntireColumn.NumberFormat = "₹0.00";
                        xlNewSheet12.Range["P1"].Cells.EntireColumn.NumberFormat = "₹0.00";
                        xlNewSheet12.Range["R1"].Cells.EntireColumn.NumberFormat = "₹0.00";
                        xlNewSheet12.Range["T1"].Cells.EntireColumn.NumberFormat = "₹0.00";



                        xlNewSheet12.get_Range("K1", "T1").Merge();
                        xlNewSheet12.get_Range("K1", "T1").Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;



                        xlNewSheet12.Select();
                        ((Excel.Worksheet)xlApp.ActiveWorkbook.Sheets[1]).Activate();
                        releaseObject(xlNewSheet12);
                        //((Excel.Worksheet)xlApp.ActiveWorkbook.Sheets[1]).Activate();

                    }

                }
                if (ReportType == "Ern_Outhouse_Finished")
                {
                    // iKandi.Common.Constants.WorkSheetCount_ForExcel = iKandi.Common.Constants.WorkSheetCount_ForExcel + 1;
                    CultureInfo ci = new CultureInfo("en-IN");
                    ci.NumberFormat.CurrencySymbol = "₹";
                    GlobalCount = GlobalCount + 1;
                    var xlNewSheet12 = (Excel.Worksheet)worksheets.Add(worksheets[GlobalCount], Type.Missing, Type.Missing, Type.Missing);



                    xlNewSheet12.Name = "Ern_Outhouse_Finished";
                    xlNewSheet12.Cells[1, 13] = "Finished Detail";
                    xlNewSheet12.Cells[2, 1] = "Style Code";
                    xlNewSheet12.Cells[2, 2] = "Serial number";
                    xlNewSheet12.Cells[2, 3] = "Department Name";
                    xlNewSheet12.Cells[2, 4] = "Order Quantity";
                    xlNewSheet12.Cells[2, 5] = "Sealed Date";
                    xlNewSheet12.Cells[2, 6] = "Pattern Sample Date";
                    xlNewSheet12.Cells[2, 7] = "MinExFactory";
                    xlNewSheet12.Cells[2, 8] = "MaxExFactory";
                    xlNewSheet12.Cells[2, 9] = "SAM(Weighted)";
                    xlNewSheet12.Cells[2, 10] = "BIPL Budget";

                    xlNewSheet12.Cells[2, 11] = "Supplier1";
                    xlNewSheet12.Cells[2, 12] = "Finished_1";
                    xlNewSheet12.Cells[2, 13] = "Supplier_2";
                    xlNewSheet12.Cells[2, 14] = "Finished_2";
                    xlNewSheet12.Cells[2, 15] = "Supplier_3";
                    xlNewSheet12.Cells[2, 16] = "Finished_3";
                    xlNewSheet12.Cells[2, 17] = "Supplier_4";
                    xlNewSheet12.Cells[2, 18] = "Finished_4";
                    xlNewSheet12.Cells[2, 19] = "Supplier_5";
                    xlNewSheet12.Cells[2, 20] = "Finished_5";




                    if (ds.Tables[0].Rows.Count == 0)
                    {
                        return false;
                    }
                    else if (ds.Tables[0].Rows.Count > 0)
                    {
                        int T = 2;
                        int U = 1;
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            //int IsVaFineLineCheck = 0;
                            //int IsVaFineLineCheck2 = 0;
                            //int IsVaFineLineCheck3 = 0;
                            //int IsVaFineLineCheck4 = 0;
                            //int IsVaFineLineCheck5 = 0;


                            int IsFinalOB = 0;
                            xlNewSheet12.Cells[T + 1, 1] = dr["StyleCode"] == DBNull.Value ? string.Empty : Convert.ToString(dr["StyleCode"]);
                            xlNewSheet12.Cells[T + 1, 2] = dr["SerialNumber"] == DBNull.Value ? string.Empty : Convert.ToString(dr["SerialNumber"]);
                            xlNewSheet12.Cells[T + 1, 3] = dr["DepartmentName"] == DBNull.Value ? string.Empty : Convert.ToString(dr["DepartmentName"]);
                            xlNewSheet12.Cells[T + 1, 4] = dr["Quantity"] == DBNull.Value ? string.Empty : Convert.ToInt32(dr["Quantity"]).ToString("N0"); // Added Code By Bharat on 12-12-19
                            xlNewSheet12.Cells[T + 1, 5] = dr["SealDate"] == DBNull.Value ? string.Empty : Convert.ToString(dr["SealDate"]);
                            xlNewSheet12.Cells[T + 1, 6] = dr["MinPatternsampleDate"] == DBNull.Value ? string.Empty : Convert.ToString(dr["MinPatternsampleDate"]);
                            xlNewSheet12.Cells[T + 1, 7] = dr["MinExfactory"] == DBNull.Value ? string.Empty : Convert.ToString(dr["MinExfactory"]);
                            xlNewSheet12.Cells[T + 1, 8] = dr["MaxExfactory"] == DBNull.Value ? string.Empty : Convert.ToString(dr["MaxExfactory"]);
                            xlNewSheet12.Cells[T + 1, 9] = dr["Sam"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Sam"]);
                            xlNewSheet12.Cells[T + 1, 10] = dr["biplbudget"] == DBNull.Value ? string.Empty : Convert.ToString(dr["biplbudget"]);



                            //xlNewSheet11.Cells[S + 1, 10].Color = System.Drawing.Color.AliceBlue;₹

                            xlNewSheet12.Cells[T + 1, 11] = dr["VA_Stch_Supplier_1"] == DBNull.Value ? string.Empty : Convert.ToString(dr["VA_Stch_Supplier_1"]);
                            xlNewSheet12.Cells[T + 1, 12] = dr["VA_Stch_Rate_1"] == DBNull.Value ? string.Empty : Convert.ToString(dr["VA_Stch_Rate_1"]);
                            xlNewSheet12.Cells[T + 1, 13] = dr["VA_Stch_Supplier_2"] == DBNull.Value ? string.Empty : Convert.ToString(dr["VA_Stch_Supplier_2"]);
                            xlNewSheet12.Cells[T + 1, 14] = dr["VA_Stch_Rate_2"] == DBNull.Value ? string.Empty : Convert.ToString(dr["VA_Stch_Rate_2"]);
                            xlNewSheet12.Cells[T + 1, 15] = dr["VA_Stch_Supplier_3"] == DBNull.Value ? string.Empty : Convert.ToString(dr["VA_Stch_Supplier_3"]);
                            xlNewSheet12.Cells[T + 1, 16] = dr["VA_Stch_Rate_3"] == DBNull.Value ? string.Empty : Convert.ToString(dr["VA_Stch_Rate_3"]);
                            xlNewSheet12.Cells[T + 1, 17] = dr["VA_Stch_Supplier_4"] == DBNull.Value ? string.Empty : Convert.ToString(dr["VA_Stch_Supplier_4"]);

                            xlNewSheet12.Cells[T + 1, 18] = dr["VA_Stch_Rate_4"] == DBNull.Value ? string.Empty : Convert.ToString(dr["VA_Stch_Rate_4"]);
                            xlNewSheet12.Cells[T + 1, 19] = dr["VA_Stch_Supplier_5"] == DBNull.Value ? string.Empty : Convert.ToString(dr["VA_Stch_Supplier_5"]);
                            xlNewSheet12.Cells[T + 1, 20] = dr["VA_Stch_Rate_5"] == DBNull.Value ? string.Empty : Convert.ToString(dr["VA_Stch_Rate_5"]);
                            IsFinalOB = dr["IsFinalOB"] == DBNull.Value ? 0 : Convert.ToInt32(dr["IsFinalOB"]);

                            U = T + 1;



                            xlNewSheet12.Range["A" + U, "A" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet12.Range["A" + U, "A" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet12.Range["A" + U, "A" + U].Font.Name = "Calibri";
                            xlNewSheet12.Range["A" + U, "A" + U].Font.Size = 11;
                            xlNewSheet12.Range["A" + U, "A" + U].Font.FontStyle = "Bold";



                            xlNewSheet12.Range["B" + U, "B" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet12.Range["B" + U, "B" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet12.Range["B" + U, "B" + U].Font.Name = "Calibri";
                            xlNewSheet12.Range["B" + U, "B" + U].Font.Size = 11;
                            xlNewSheet12.Range["B" + U, "B" + U].Font.FontStyle = "Bold";
                            xlNewSheet12.Range["B" + U, "B" + U].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.DarkBlue);




                            xlNewSheet12.Range["C" + U, "C" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet12.Range["C" + U, "C" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet12.Range["C" + U, "C" + U].Font.Name = "Calibri";
                            xlNewSheet12.Range["C" + U, "C" + U].Font.Size = 10;
                            xlNewSheet12.Range["C" + U, "C" + U].Font.FontStyle = "Ragular";

                            if (IsFinalOB == 0)
                            {
                                xlNewSheet12.Range["A" + U, "A" + U].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Red);

                                //xlNewSheet12.get_Range("A2", "A2").Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;

                            }

                            xlNewSheet12.Range["D" + U, "D" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet12.Range["D" + U, "D" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet12.Range["D" + U, "D" + U].Font.Name = "Calibri";
                            xlNewSheet12.Range["D" + U, "D" + U].Font.Size = 12;
                            xlNewSheet12.Range["D" + U, "D" + U].Font.FontStyle = "Bold";



                            xlNewSheet12.Range["E" + U, "E" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet12.Range["E" + U, "E" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet12.Range["E" + U, "E" + U].Font.Name = "Calibri";
                            xlNewSheet12.Range["E" + U, "E" + U].Font.Size = 10;
                            xlNewSheet12.Range["E" + U, "E" + U].Font.FontStyle = "Ragular";
                            xlNewSheet12.Range["E" + U, "E" + U].Font.FontStyle = "Bold";

                            xlNewSheet12.Range["F" + U, "F" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet12.Range["F" + U, "F" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet12.Range["F" + U, "F" + U].Font.Name = "Calibri";
                            xlNewSheet12.Range["F" + U, "F" + U].Font.Size = 10;
                            xlNewSheet12.Range["F" + U, "F" + U].Font.FontStyle = "Ragular";


                            xlNewSheet12.Range["G" + U, "G" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet12.Range["G" + U, "G" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet12.Range["G" + U, "G" + U].Font.Name = "Calibri";
                            xlNewSheet12.Range["G" + U, "G" + U].Font.Size = 10;
                            xlNewSheet12.Range["G" + U, "G" + U].Font.FontStyle = "Ragular";

                            xlNewSheet12.Range["H" + U, "H" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet12.Range["H" + U, "H" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet12.Range["H" + U, "H" + U].Font.Name = "Calibri";
                            xlNewSheet12.Range["H" + U, "H" + U].Font.Size = 10;
                            xlNewSheet12.Range["H" + U, "H" + U].Font.FontStyle = "Ragular";


                            xlNewSheet12.Range["I" + U, "I" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet12.Range["I" + U, "I" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet12.Range["I" + U, "I" + U].Font.Name = "Calibri";
                            xlNewSheet12.Range["I" + U, "I" + U].Font.Size = 10;
                            xlNewSheet12.Range["I" + U, "I" + U].Font.FontStyle = "Bold";

                            xlNewSheet12.Range["J" + U, "J" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet12.Range["J" + U, "J" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet12.Range["J" + U, "J" + U].Font.Name = "Calibri";
                            xlNewSheet12.Range["J" + U, "J" + U].Font.Size = 11;
                            xlNewSheet12.Range["J" + U, "J" + U].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red);
                            xlNewSheet12.Range["J" + U, "J" + U].Font.FontStyle = "Bold";


                            xlNewSheet12.Range["K" + U, "K" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet12.Range["K" + U, "K" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet12.Range["K" + U, "K" + U].Font.Name = "Calibri";
                            xlNewSheet12.Range["K" + U, "K" + U].Font.Size = 11;
                            xlNewSheet12.Range["K" + U, "K" + U].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.DarkBlue);
                            xlNewSheet12.Range["K" + U, "K" + U].Font.FontStyle = "Bold";

                            xlNewSheet12.Range["L" + U, "L" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet12.Range["L" + U, "L" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet12.Range["L" + U, "L" + U].Font.Name = "Calibri";
                            xlNewSheet12.Range["L" + U, "L" + U].Font.Size = 11;
                            xlNewSheet12.Range["L" + U, "L" + U].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Green);
                            xlNewSheet12.Range["L" + U, "L" + U].Font.FontStyle = "Bold";

                            xlNewSheet12.Range["M" + U, "M" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet12.Range["M" + U, "M" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet12.Range["M" + U, "M" + U].Font.Name = "Calibri";
                            xlNewSheet12.Range["M" + U, "M" + U].Font.Size = 11;
                            xlNewSheet12.Range["M" + U, "M" + U].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.DarkBlue);
                            xlNewSheet12.Range["M" + U, "M" + U].Font.FontStyle = "Bold";

                            xlNewSheet12.Range["N" + U, "N" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet12.Range["N" + U, "N" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet12.Range["N" + U, "N" + U].Font.Name = "Calibri";
                            xlNewSheet12.Range["N" + U, "N" + U].Font.Size = 11;
                            xlNewSheet12.Range["N" + U, "N" + U].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Green);
                            xlNewSheet12.Range["N" + U, "N" + U].Font.FontStyle = "Bold";

                            xlNewSheet12.Range["O" + U, "O" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet12.Range["O" + U, "O" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet12.Range["O" + U, "O" + U].Font.Name = "Calibri";
                            xlNewSheet12.Range["O" + U, "O" + U].Font.Size = 11;
                            xlNewSheet12.Range["O" + U, "O" + U].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.DarkBlue);
                            xlNewSheet12.Range["O" + U, "O" + U].Font.FontStyle = "Bold";

                            xlNewSheet12.Range["P" + U, "P" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet12.Range["P" + U, "P" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet12.Range["P" + U, "P" + U].Font.Name = "Calibri";
                            xlNewSheet12.Range["P" + U, "P" + U].Font.Size = 11;
                            xlNewSheet12.Range["P" + U, "P" + U].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Green);
                            xlNewSheet12.Range["P" + U, "P" + U].Font.FontStyle = "Bold";

                            xlNewSheet12.Range["Q" + U, "Q" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet12.Range["Q" + U, "Q" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet12.Range["Q" + U, "Q" + U].Font.Name = "Calibri";
                            xlNewSheet12.Range["Q" + U, "Q" + U].Font.Size = 11;
                            xlNewSheet12.Range["Q" + U, "Q" + U].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.DarkBlue);
                            xlNewSheet12.Range["Q" + U, "Q" + U].Font.FontStyle = "Bold";

                            xlNewSheet12.Range["R" + U, "R" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet12.Range["R" + U, "R" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet12.Range["R" + U, "R" + U].Font.Name = "Calibri";
                            xlNewSheet12.Range["R" + U, "R" + U].Font.Size = 11;
                            xlNewSheet12.Range["R" + U, "R" + U].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Green);
                            xlNewSheet12.Range["R" + U, "R" + U].Font.FontStyle = "Bold";

                            xlNewSheet12.Range["S" + U, "S" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet12.Range["S" + U, "S" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet12.Range["S" + U, "S" + U].Font.Name = "Calibri";
                            xlNewSheet12.Range["S" + U, "S" + U].Font.Size = 11;
                            xlNewSheet12.Range["S" + U, "S" + U].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.DarkBlue);
                            xlNewSheet12.Range["S" + U, "S" + U].Font.FontStyle = "Bold";

                            xlNewSheet12.Range["T" + U, "T" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet12.Range["T" + U, "T" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet12.Range["T" + U, "T" + U].Font.Name = "Calibri";
                            xlNewSheet12.Range["T" + U, "T" + U].Font.Size = 11;
                            xlNewSheet12.Range["T" + U, "T" + U].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Green);
                            xlNewSheet12.Range["T" + U, "T" + U].Font.FontStyle = "Bold";


                            //xlNewSheet12.Range["J" + U, "J" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            //xlNewSheet12.Range["J" + U, "J" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            //xlNewSheet12.Range["J" + U, "J" + U].Font.Name = "Calibri";
                            //xlNewSheet12.Range["J" + U, "J" + U].Font.Size = 12;
                            //xlNewSheet12.Range["J" + U, "J" + U].Font.FontStyle = "Bold";

                            //xlNewSheet12.Range["K2" + U, "K2" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            //xlNewSheet12.Range["K2" + U, "K2" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            //xlNewSheet12.Range["K2" + U, "K2" + U].Font.Name = "Calibri";
                            //xlNewSheet12.Range["K2" + U, "K2" + U].Font.Size = 10;
                            //xlNewSheet12.Range["K2" + U, "K2" + U].Font.FontStyle = "Ragular";

                            //xlNewSheet12.Range["L" + U, "L" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            //xlNewSheet12.Range["L" + U, "L" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            //xlNewSheet12.Range["L" + U, "L" + U].Font.Name = "Calibri";
                            //xlNewSheet12.Range["L" + U, "L" + U].Font.Size = 10;
                            //xlNewSheet12.Range["L" + U, "L" + U].Font.FontStyle = "Ragular";
                            //xlNewSheet12.Range["L" + U, "L" + U].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red);
                            //xlNewSheet12.Range["L" + U, "L" + U].Font.FontStyle = "Bold";




                            //xlNewSheet12.Range["M2" + U, "M2" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            //xlNewSheet12.Range["M2" + U, "M2" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            //xlNewSheet12.Range["M2" + U, "M2" + U].Font.Name = "Calibri";
                            //xlNewSheet12.Range["M2" + U, "M2" + U].Font.Size = 10;
                            //xlNewSheet12.Range["M2" + U, "M2" + U].Font.FontStyle = "Ragular";

                            //xlNewSheet12.Range["N2" + U, "N2" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            //xlNewSheet12.Range["N2" + U, "N2" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            //xlNewSheet12.Range["N2" + U, "N2" + U].Font.Name = "Calibri";
                            //xlNewSheet12.Range["N2" + U, "N2" + U].Font.Size = 10;
                            //xlNewSheet12.Range["N2" + U, "N2" + U].Font.FontStyle = "Ragular";


                            //xlNewSheet12.Range["O2" + U, "O2" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            //xlNewSheet12.Range["O2" + U, "O2" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            //xlNewSheet12.Range["O2" + U, "O2" + U].Font.Name = "Calibri";
                            //xlNewSheet12.Range["O2" + U, "O2" + U].Font.Size = 10;
                            //xlNewSheet12.Range["O2" + U, "O2" + U].Font.FontStyle = "Ragular";




                            T++;
                        }



                        xlNewSheet12.Columns.AutoFit();

                        xlNewSheet12.get_Range("A1", "A2").Merge();
                        xlNewSheet12.get_Range("B1", "B2").Merge();
                        xlNewSheet12.get_Range("C1", "C2").Merge();
                        xlNewSheet12.get_Range("D1", "D2").Merge();
                        xlNewSheet12.get_Range("E1", "E2").Merge();
                        xlNewSheet12.get_Range("F1", "F2").Merge();
                        xlNewSheet12.get_Range("G1", "G2").Merge();
                        xlNewSheet12.get_Range("H1", "H2").Merge();
                        xlNewSheet12.get_Range("I1", "I2").Merge();
                        xlNewSheet12.get_Range("J1", "J2").Merge();
                        //xlNewSheet12.get_Range("K1", "K2").Merge();

                        xlNewSheet12.Range["A1", "A2"].Font.Bold = true;
                        xlNewSheet12.Range["A1", "A2"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet12.Range["B1", "B2"].Font.Bold = true;
                        xlNewSheet12.Range["B1", "B2"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet12.Range["C1", "C2"].Font.Bold = true;
                        xlNewSheet12.Range["C1", "C2"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet12.Range["D1", "D2"].Font.Bold = true;
                        xlNewSheet12.Range["D1", "D2"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet12.Range["E1", "E2"].Font.Bold = true;
                        xlNewSheet12.Range["E1", "E2"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet12.Range["F1", "F2"].Font.Bold = true;
                        xlNewSheet12.Range["F1", "F2"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet12.Range["G1", "G2"].Font.Bold = true;
                        xlNewSheet12.Range["G1", "G2"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet12.Range["H1", "H2"].Font.Bold = true;
                        xlNewSheet12.Range["H1", "H2"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet12.Range["I1", "I2"].Font.Bold = true;
                        xlNewSheet12.Range["I1", "I2"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet12.Range["J1", "J2"].Font.Bold = true;
                        xlNewSheet12.Range["J1", "J2"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        //xlNewSheet12.Range["K1", "K2"].Font.Bold = true;
                        //xlNewSheet12.Range["K1", "K2"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                        xlNewSheet12.Range["A1", "T1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        xlNewSheet12.Range["A2", "T2"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        xlNewSheet12.Range["A1", "T1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                        xlNewSheet12.Range["A2", "T2"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                        xlNewSheet12.Range["A1", "T1"].EntireColumn.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet12.Range["A2", "T2"].EntireColumn.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet12.get_Range("A1:T" + T).Cells.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                        xlNewSheet12.get_Range("A2:T" + T).Cells.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;

                        xlNewSheet12.Range["E1"].Cells.EntireColumn.NumberFormat = "d mmm (ddd);@";
                        xlNewSheet12.Range["F1"].Cells.EntireColumn.NumberFormat = "d mmm (ddd);@";
                        xlNewSheet12.Range["G1"].Cells.EntireColumn.NumberFormat = "d mmm (ddd);@";
                        xlNewSheet12.Range["H1"].Cells.EntireColumn.NumberFormat = "d mmm (ddd);@";

                        xlNewSheet12.Range["J1"].Cells.EntireColumn.NumberFormat = "₹0.00";
                        xlNewSheet12.Range["L1"].Cells.EntireColumn.NumberFormat = "₹0.00";
                        xlNewSheet12.Range["N1"].Cells.EntireColumn.NumberFormat = "₹0.00";
                        xlNewSheet12.Range["P1"].Cells.EntireColumn.NumberFormat = "₹0.00";
                        xlNewSheet12.Range["R1"].Cells.EntireColumn.NumberFormat = "₹0.00";
                        xlNewSheet12.Range["T1"].Cells.EntireColumn.NumberFormat = "₹0.00";



                        xlNewSheet12.get_Range("K1", "T1").Merge();
                        xlNewSheet12.get_Range("K1", "T1").Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;



                        xlNewSheet12.Select();
                        ((Excel.Worksheet)xlApp.ActiveWorkbook.Sheets[1]).Activate();
                        releaseObject(xlNewSheet12);
                        //((Excel.Worksheet)xlApp.ActiveWorkbook.Sheets[1]).Activate();

                    }

                }

                if (ReportType == "All_orders_with_ValueAddition")
                {
                    CultureInfo ci = new CultureInfo("en-IN");
                    ci.NumberFormat.CurrencySymbol = "₹";
                    GlobalCount = GlobalCount + 1;
                    var xlNewSheet13 = (Excel.Worksheet)worksheets.Add(worksheets[GlobalCount], Type.Missing, Type.Missing, Type.Missing);
                    xlNewSheet13.Name = "All_orders_with_ValueAddition";
                    xlNewSheet13.Cells[1, 13] = "ValueAdditionDetail";
                    xlNewSheet13.Cells[2, 1] = "Style Code";
                    xlNewSheet13.Cells[2, 2] = "Serial number";
                    xlNewSheet13.Cells[2, 3] = "Department Name";
                    xlNewSheet13.Cells[2, 4] = "Order Quantity";
                    xlNewSheet13.Cells[2, 5] = "Sealed Date";
                    xlNewSheet13.Cells[2, 6] = "Pattern Sample Date";
                    xlNewSheet13.Cells[2, 7] = "MinExFactory";
                    xlNewSheet13.Cells[2, 8] = "MaxExFactory";
                    xlNewSheet13.Cells[2, 9] = "SAM(Weighted)";
                    xlNewSheet13.Cells[2, 10] = "BIPL Budget (cost hand + Mach)";
                    xlNewSheet13.Cells[2, 11] = "ValueAddition1";
                    xlNewSheet13.Cells[2, 12] = "ValueAddition1_Supplier";
                    xlNewSheet13.Cells[2, 13] = "InitialAgreementRate1";
                    xlNewSheet13.Cells[2, 14] = "Rate_1";
                    xlNewSheet13.Cells[2, 15] = "ValueAddition2";
                    xlNewSheet13.Cells[2, 16] = "ValueAddition2_Supplier";
                    xlNewSheet13.Cells[2, 17] = "InitialAgreementRate2";
                    xlNewSheet13.Cells[2, 18] = "Rate_2";
                    if (ds.Tables[0].Rows.Count == 0)
                    {
                        return false;
                    }
                    else if (ds.Tables[0].Rows.Count > 0)
                    {
                        int T = 2;
                        int U = 1;
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            int IsFinalOB = 0;
                            xlNewSheet13.Cells[T + 1, 1] = dr["StyleCode"] == DBNull.Value ? string.Empty : Convert.ToString(dr["StyleCode"]);
                            xlNewSheet13.Cells[T + 1, 2] = dr["SerialNumber"] == DBNull.Value ? string.Empty : Convert.ToString(dr["SerialNumber"]);
                            xlNewSheet13.Cells[T + 1, 3] = dr["DepartmentName"] == DBNull.Value ? string.Empty : Convert.ToString(dr["DepartmentName"]);
                            xlNewSheet13.Cells[T + 1, 4] = dr["Quantity"] == DBNull.Value ? string.Empty : Convert.ToInt32(dr["Quantity"]).ToString("N0"); //Added Code By bharat on 12-12-19 
                            xlNewSheet13.Cells[T + 1, 5] = dr["SealDate"] == DBNull.Value ? string.Empty : Convert.ToString(dr["SealDate"]);
                            xlNewSheet13.Cells[T + 1, 6] = dr["MinPatternsampleDate"] == DBNull.Value ? string.Empty : Convert.ToString(dr["MinPatternsampleDate"]);
                            xlNewSheet13.Cells[T + 1, 7] = dr["MinExfactory"] == DBNull.Value ? string.Empty : Convert.ToString(dr["MinExfactory"]);
                            xlNewSheet13.Cells[T + 1, 8] = dr["MaxExfactory"] == DBNull.Value ? string.Empty : Convert.ToString(dr["MaxExfactory"]);
                            xlNewSheet13.Cells[T + 1, 9] = dr["Sam"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Sam"]);
                            xlNewSheet13.Cells[T + 1, 10] = dr["biplbudget"] == DBNull.Value ? string.Empty : Convert.ToString(dr["biplbudget"]);

                            xlNewSheet13.Cells[T + 1, 11] = dr["ValueAddition1"] == DBNull.Value ? string.Empty : Convert.ToString(dr["ValueAddition1"]);
                            xlNewSheet13.Cells[T + 1, 12] = dr["ValueAddition1_Supplier"] == DBNull.Value ? string.Empty : Convert.ToString(dr["ValueAddition1_Supplier"]);
                            xlNewSheet13.Cells[T + 1, 13] = Convert.ToString(dr["IntialAgreementRate1"]) == "0" ? string.Empty : Convert.ToString(dr["IntialAgreementRate1"]);
                            xlNewSheet13.Cells[T + 1, 14] = Convert.ToString(dr["ValueAddition1_Rate"]) == "0" ? string.Empty : Convert.ToString(dr["ValueAddition1_Rate"]);

                            xlNewSheet13.Cells[T + 1, 15] = dr["ValueAddition2"] == DBNull.Value ? string.Empty : Convert.ToString(dr["ValueAddition2"]);
                            xlNewSheet13.Cells[T + 1, 16] = dr["ValueAddition2_Supplier"] == DBNull.Value ? string.Empty : Convert.ToString(dr["ValueAddition2_Supplier"]);
                            xlNewSheet13.Cells[T + 1, 17] = Convert.ToString(dr["IntialAgreementRate2"]) == "0" ? string.Empty : Convert.ToString(dr["IntialAgreementRate2"]);
                            xlNewSheet13.Cells[T + 1, 18] = Convert.ToString(dr["ValueAddition2_Rate"]) == "0" ? string.Empty : Convert.ToString(dr["ValueAddition2_Rate"]);
                            IsFinalOB = dr["IsFinalOB"] == DBNull.Value ? 0 : Convert.ToInt32(dr["IsFinalOB"]);

                            U = T + 1;

                            xlNewSheet13.Range["A" + U, "A" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet13.Range["A" + U, "A" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet13.Range["A" + U, "A" + U].Font.Name = "Calibri";
                            xlNewSheet13.Range["A" + U, "A" + U].Font.Size = 11;
                            xlNewSheet13.Range["A" + U, "A" + U].Font.FontStyle = "Bold";
                            //xlNewSheet13.Range["A" + U, "A" + U].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.DarkBlue);

                            xlNewSheet13.Range["B" + U, "B" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet13.Range["B" + U, "B" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet13.Range["B" + U, "B" + U].Font.Name = "Calibri";
                            xlNewSheet13.Range["B" + U, "B" + U].Font.Size = 11;
                            xlNewSheet13.Range["B" + U, "B" + U].Font.FontStyle = "Bold";
                            xlNewSheet13.Range["B" + U, "B" + U].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.DarkBlue);


                            xlNewSheet13.Range["C" + U, "C" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet13.Range["C" + U, "C" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet13.Range["C" + U, "C" + U].Font.Name = "Calibri";
                            xlNewSheet13.Range["C" + U, "C" + U].Font.Size = 10;
                            xlNewSheet13.Range["C" + U, "C" + U].Font.FontStyle = "Ragular";

                            if (IsFinalOB == 0)
                            {
                                xlNewSheet13.Range["A" + U, "A" + U].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Red);

                                //xlNewSheet12.get_Range("A2", "A2").Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;

                            }

                            xlNewSheet13.Range["D" + U, "D" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet13.Range["D" + U, "D" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet13.Range["D" + U, "D" + U].Font.Name = "Calibri";
                            xlNewSheet13.Range["D" + U, "D" + U].Font.Size = 12;
                            xlNewSheet13.Range["D" + U, "D" + U].Font.FontStyle = "Bold";



                            xlNewSheet13.Range["E" + U, "E" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet13.Range["E" + U, "E" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet13.Range["E" + U, "E" + U].Font.Name = "Calibri";
                            xlNewSheet13.Range["E" + U, "E" + U].Font.Size = 10;
                            xlNewSheet13.Range["E" + U, "E" + U].Font.FontStyle = "Ragular";


                            xlNewSheet13.Range["F" + U, "F" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet13.Range["F" + U, "F" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet13.Range["F" + U, "F" + U].Font.Name = "Calibri";
                            xlNewSheet13.Range["F" + U, "F" + U].Font.Size = 10;
                            xlNewSheet13.Range["F" + U, "F" + U].Font.FontStyle = "Ragular";


                            xlNewSheet13.Range["G" + U, "G" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet13.Range["G" + U, "G" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet13.Range["G" + U, "G" + U].Font.Name = "Calibri";
                            xlNewSheet13.Range["G" + U, "G" + U].Font.Size = 10;
                            xlNewSheet13.Range["G" + U, "G" + U].Font.FontStyle = "Ragular";

                            xlNewSheet13.Range["H" + U, "H" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet13.Range["H" + U, "H" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet13.Range["H" + U, "H" + U].Font.Name = "Calibri";
                            xlNewSheet13.Range["H" + U, "H" + U].Font.Size = 10;
                            xlNewSheet13.Range["H" + U, "H" + U].Font.FontStyle = "Ragular";

                            xlNewSheet13.Range["I" + U, "I" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet13.Range["I" + U, "I" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet13.Range["I" + U, "I" + U].Font.Name = "Calibri";
                            xlNewSheet13.Range["I" + U, "I" + U].Font.Size = 10;
                            xlNewSheet13.Range["I" + U, "I" + U].Font.FontStyle = "Ragular";
                            xlNewSheet13.Range["I" + U, "I" + U].Font.FontStyle = "Bold";

                            xlNewSheet13.Range["J" + U, "J" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet13.Range["J" + U, "J" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet13.Range["J" + U, "J" + U].Font.Name = "Calibri";
                            xlNewSheet13.Range["J" + U, "J" + U].Font.Size = 11;
                            xlNewSheet13.Range["J" + U, "J" + U].Font.FontStyle = "Bold";
                            xlNewSheet13.Range["J" + U, "J" + U].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red);

                            xlNewSheet13.Range["K" + U, "K" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet13.Range["K" + U, "K" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet13.Range["K" + U, "K" + U].Font.Name = "Calibri";
                            xlNewSheet13.Range["K" + U, "K" + U].Font.Size = 11;
                            xlNewSheet13.Range["K" + U, "K" + U].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.DarkBlue);
                            xlNewSheet13.Range["K" + U, "K" + U].Font.FontStyle = "Bold";

                            xlNewSheet13.Range["L" + U, "L" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet13.Range["L" + U, "L" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet13.Range["L" + U, "L" + U].Font.Name = "Calibri";
                            xlNewSheet13.Range["L" + U, "L" + U].Font.Size = 11;
                            xlNewSheet13.Range["L" + U, "L" + U].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.DarkBlue);
                            xlNewSheet13.Range["L" + U, "L" + U].Font.FontStyle = "Bold";

                            xlNewSheet13.Range["M" + U, "M" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet13.Range["M" + U, "M" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet13.Range["M" + U, "M" + U].Font.Name = "Calibri";
                            xlNewSheet13.Range["M" + U, "M" + U].Font.Size = 11;
                            xlNewSheet13.Range["M" + U, "M" + U].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Green);
                            xlNewSheet13.Range["M" + U, "M" + U].Font.FontStyle = "Bold";

                            xlNewSheet13.Range["N" + U, "N" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet13.Range["N" + U, "N" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet13.Range["N" + U, "N" + U].Font.Name = "Calibri";
                            xlNewSheet13.Range["N" + U, "N" + U].Font.Size = 11;
                            xlNewSheet13.Range["N" + U, "N" + U].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Green);
                            xlNewSheet13.Range["N" + U, "N" + U].Font.FontStyle = "Bold";

                            xlNewSheet13.Range["O" + U, "O" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet13.Range["O" + U, "O" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet13.Range["O" + U, "O" + U].Font.Name = "Calibri";
                            xlNewSheet13.Range["O" + U, "O" + U].Font.Size = 11;
                            xlNewSheet13.Range["O" + U, "O" + U].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.DarkBlue);
                            xlNewSheet13.Range["O" + U, "O" + U].Font.FontStyle = "Bold";

                            xlNewSheet13.Range["P" + U, "P" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet13.Range["P" + U, "P" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet13.Range["P" + U, "P" + U].Font.Name = "Calibri";
                            xlNewSheet13.Range["P" + U, "P" + U].Font.Size = 11;
                            xlNewSheet13.Range["P" + U, "P" + U].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.DarkBlue);
                            xlNewSheet13.Range["P" + U, "P" + U].Font.FontStyle = "Bold";

                            xlNewSheet13.Range["Q" + U, "Q" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet13.Range["Q" + U, "Q" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet13.Range["Q" + U, "Q" + U].Font.Name = "Calibri";
                            xlNewSheet13.Range["Q" + U, "Q" + U].Font.Size = 11;
                            xlNewSheet13.Range["Q" + U, "Q" + U].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Green);
                            xlNewSheet13.Range["Q" + U, "Q" + U].Font.FontStyle = "Bold";

                            xlNewSheet13.Range["R" + U, "R" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet13.Range["R" + U, "R" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet13.Range["R" + U, "R" + U].Font.Name = "Calibri";
                            xlNewSheet13.Range["R" + U, "R" + U].Font.Size = 11;
                            xlNewSheet13.Range["R" + U, "R" + U].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Green);
                            xlNewSheet13.Range["R" + U, "R" + U].Font.FontStyle = "Bold";



                            T++;
                        }
                        xlNewSheet13.Columns.AutoFit();
                        xlNewSheet13.get_Range("A1", "A2").Merge();
                        xlNewSheet13.get_Range("B1", "B2").Merge();
                        xlNewSheet13.get_Range("C1", "C2").Merge();
                        xlNewSheet13.get_Range("D1", "D2").Merge();
                        xlNewSheet13.get_Range("E1", "E2").Merge();
                        xlNewSheet13.get_Range("F1", "F2").Merge();
                        xlNewSheet13.get_Range("G1", "G2").Merge();
                        xlNewSheet13.get_Range("H1", "H2").Merge();
                        xlNewSheet13.get_Range("I1", "I2").Merge();
                        xlNewSheet13.get_Range("J1", "J2").Merge();
                        //xlNewSheet13.get_Range("K1", "K2").Merge();

                        xlNewSheet13.Range["A1", "A2"].Font.Bold = true;
                        xlNewSheet13.Range["A1", "A2"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet13.Range["B1", "B2"].Font.Bold = true;
                        xlNewSheet13.Range["B1", "B2"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet13.Range["C1", "C2"].Font.Bold = true;
                        xlNewSheet13.Range["C1", "C2"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet13.Range["D1", "D2"].Font.Bold = true;
                        xlNewSheet13.Range["D1", "D2"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet13.Range["E1", "E2"].Font.Bold = true;
                        xlNewSheet13.Range["E1", "E2"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet13.Range["F1", "F2"].Font.Bold = true;
                        xlNewSheet13.Range["F1", "F2"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet13.Range["G1", "G2"].Font.Bold = true;
                        xlNewSheet13.Range["G1", "G2"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet13.Range["H1", "H2"].Font.Bold = true;
                        xlNewSheet13.Range["H1", "H2"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet13.Range["I1", "I2"].Font.Bold = true;
                        xlNewSheet13.Range["I1", "I2"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet13.Range["J1", "J2"].Font.Bold = true;
                        xlNewSheet13.Range["J1", "J2"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                        //xlNewSheet13.Range["K1", "K2"].Font.Bold = true;
                        //xlNewSheet13.Range["K1", "K2"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                        xlNewSheet13.Range["A1", "R1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        xlNewSheet13.Range["A2", "R2"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        xlNewSheet13.Range["A1", "R1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                        xlNewSheet13.Range["A2", "R2"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                        xlNewSheet13.Range["A1", "R1"].EntireColumn.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet13.Range["A2", "R2"].EntireColumn.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet13.get_Range("A1:R" + T).Cells.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                        xlNewSheet13.get_Range("A2:R" + T).Cells.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                        xlNewSheet13.Range["E1"].Cells.EntireColumn.NumberFormat = "d mmm (ddd);@";
                        xlNewSheet13.Range["F1"].Cells.EntireColumn.NumberFormat = "d mmm (ddd);@";
                        xlNewSheet13.Range["G1"].Cells.EntireColumn.NumberFormat = "d mmm (ddd);@";
                        xlNewSheet13.Range["H1"].Cells.EntireColumn.NumberFormat = "d mmm (ddd);@";
                        xlNewSheet13.Range["J1"].Cells.EntireColumn.NumberFormat = "₹0.00";
                        xlNewSheet13.Range["M1"].Cells.EntireColumn.NumberFormat = "₹0.00";
                        xlNewSheet13.Range["N1"].Cells.EntireColumn.NumberFormat = "₹0.00";
                        xlNewSheet13.Range["Q1"].Cells.EntireColumn.NumberFormat = "₹0.00";
                        xlNewSheet13.Range["R1"].Cells.EntireColumn.NumberFormat = "₹0.00";

                        xlNewSheet13.get_Range("K1", "R1").Merge();
                        xlNewSheet13.get_Range("K1", "R1").Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;



                        xlNewSheet13.Select();
                        ((Excel.Worksheet)xlApp.ActiveWorkbook.Sheets[1]).Activate();
                        releaseObject(xlNewSheet13);
                        //((Excel.Worksheet)xlApp.ActiveWorkbook.Sheets[1]).Activate();


                    }
                }
                if (ReportType == "Ern_orders_with_ValueAddition")
                {
                    CultureInfo ci = new CultureInfo("en-IN");
                    ci.NumberFormat.CurrencySymbol = "₹";
                    GlobalCount = GlobalCount + 1;
                    var xlNewSheet13 = (Excel.Worksheet)worksheets.Add(worksheets[GlobalCount], Type.Missing, Type.Missing, Type.Missing);
                    xlNewSheet13.Name = "Ern_orders_with_ValueAddition";
                    xlNewSheet13.Cells[1, 13] = "ValueAdditionDetail";
                    xlNewSheet13.Cells[2, 1] = "Style Code";
                    xlNewSheet13.Cells[2, 2] = "Serial number";
                    xlNewSheet13.Cells[2, 3] = "Department Name";
                    xlNewSheet13.Cells[2, 4] = "Order Quantity";
                    xlNewSheet13.Cells[2, 5] = "Sealed Date";
                    xlNewSheet13.Cells[2, 6] = "Pattern Sample Date";
                    xlNewSheet13.Cells[2, 7] = "MinExFactory";
                    xlNewSheet13.Cells[2, 8] = "MaxExFactory";
                    xlNewSheet13.Cells[2, 9] = "SAM(Weighted)";
                    xlNewSheet13.Cells[2, 10] = "BIPL Budget (cost hand + Mach)";
                    xlNewSheet13.Cells[2, 11] = "ValueAddition1";
                    xlNewSheet13.Cells[2, 12] = "ValueAddition1_Supplier";
                    xlNewSheet13.Cells[2, 13] = "InitialAgreementRate1";
                    xlNewSheet13.Cells[2, 14] = "Rate_1";
                    xlNewSheet13.Cells[2, 15] = "ValueAddition2";
                    xlNewSheet13.Cells[2, 16] = "ValueAddition2_Supplier";
                    xlNewSheet13.Cells[2, 17] = "InitialAgreementRate2";
                    xlNewSheet13.Cells[2, 18] = "Rate_2";
                    if (ds.Tables[0].Rows.Count == 0)
                    {
                        return false;
                    }
                    else if (ds.Tables[0].Rows.Count > 0)
                    {
                        int T = 2;
                        int U = 1;
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            int IsFinalOB = 0;
                            xlNewSheet13.Cells[T + 1, 1] = dr["StyleCode"] == DBNull.Value ? string.Empty : Convert.ToString(dr["StyleCode"]);
                            xlNewSheet13.Cells[T + 1, 2] = dr["SerialNumber"] == DBNull.Value ? string.Empty : Convert.ToString(dr["SerialNumber"]);
                            xlNewSheet13.Cells[T + 1, 3] = dr["DepartmentName"] == DBNull.Value ? string.Empty : Convert.ToString(dr["DepartmentName"]);
                            xlNewSheet13.Cells[T + 1, 4] = dr["Quantity"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Quantity"]);
                            xlNewSheet13.Cells[T + 1, 5] = dr["SealDate"] == DBNull.Value ? string.Empty : Convert.ToString(dr["SealDate"]);
                            xlNewSheet13.Cells[T + 1, 6] = dr["MinPatternsampleDate"] == DBNull.Value ? string.Empty : Convert.ToString(dr["MinPatternsampleDate"]);
                            xlNewSheet13.Cells[T + 1, 7] = dr["MinExfactory"] == DBNull.Value ? string.Empty : Convert.ToString(dr["MinExfactory"]);
                            xlNewSheet13.Cells[T + 1, 8] = dr["MaxExfactory"] == DBNull.Value ? string.Empty : Convert.ToString(dr["MaxExfactory"]);
                            xlNewSheet13.Cells[T + 1, 9] = dr["Sam"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Sam"]);
                            xlNewSheet13.Cells[T + 1, 10] = dr["biplbudget"] == DBNull.Value ? string.Empty : Convert.ToString(dr["biplbudget"]);

                            xlNewSheet13.Cells[T + 1, 11] = dr["ValueAddition1"] == DBNull.Value ? string.Empty : Convert.ToString(dr["ValueAddition1"]);
                            xlNewSheet13.Cells[T + 1, 12] = dr["ValueAddition1_Supplier"] == DBNull.Value ? string.Empty : Convert.ToString(dr["ValueAddition1_Supplier"]);
                            xlNewSheet13.Cells[T + 1, 13] = Convert.ToString(dr["IntialAgreementRate1"]) == "0" ? string.Empty : Convert.ToString(dr["IntialAgreementRate1"]);
                            xlNewSheet13.Cells[T + 1, 14] = Convert.ToString(dr["ValueAddition1_Rate"]) == "0" ? string.Empty : Convert.ToString(dr["ValueAddition1_Rate"]);

                            xlNewSheet13.Cells[T + 1, 15] = dr["ValueAddition2"] == DBNull.Value ? string.Empty : Convert.ToString(dr["ValueAddition2"]);
                            xlNewSheet13.Cells[T + 1, 16] = dr["ValueAddition2_Supplier"] == DBNull.Value ? string.Empty : Convert.ToString(dr["ValueAddition2_Supplier"]);
                            xlNewSheet13.Cells[T + 1, 17] = Convert.ToString(dr["IntialAgreementRate2"]) == "0" ? string.Empty : Convert.ToString(dr["IntialAgreementRate2"]);
                            xlNewSheet13.Cells[T + 1, 18] = Convert.ToString(dr["ValueAddition2_Rate"]) == "0" ? string.Empty : Convert.ToString(dr["ValueAddition2_Rate"]);
                            IsFinalOB = dr["IsFinalOB"] == DBNull.Value ? 0 : Convert.ToInt32(dr["IsFinalOB"]);

                            U = T + 1;

                            xlNewSheet13.Range["A" + U, "A" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet13.Range["A" + U, "A" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet13.Range["A" + U, "A" + U].Font.Name = "Calibri";
                            xlNewSheet13.Range["A" + U, "A" + U].Font.Size = 11;
                            xlNewSheet13.Range["A" + U, "A" + U].Font.FontStyle = "Bold";
                            //xlNewSheet13.Range["A" + U, "A" + U].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.DarkBlue);

                            xlNewSheet13.Range["B" + U, "B" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet13.Range["B" + U, "B" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet13.Range["B" + U, "B" + U].Font.Name = "Calibri";
                            xlNewSheet13.Range["B" + U, "B" + U].Font.Size = 11;
                            xlNewSheet13.Range["B" + U, "B" + U].Font.FontStyle = "Bold";
                            xlNewSheet13.Range["B" + U, "B" + U].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.DarkBlue);


                            xlNewSheet13.Range["C" + U, "C" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet13.Range["C" + U, "C" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet13.Range["C" + U, "C" + U].Font.Name = "Calibri";
                            xlNewSheet13.Range["C" + U, "C" + U].Font.Size = 10;
                            xlNewSheet13.Range["C" + U, "C" + U].Font.FontStyle = "Ragular";

                            if (IsFinalOB == 0)
                            {
                                xlNewSheet13.Range["A" + U, "A" + U].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Red);

                                //xlNewSheet12.get_Range("A2", "A2").Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;

                            }

                            xlNewSheet13.Range["D" + U, "D" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet13.Range["D" + U, "D" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet13.Range["D" + U, "D" + U].Font.Name = "Calibri";
                            xlNewSheet13.Range["D" + U, "D" + U].Font.Size = 12;
                            xlNewSheet13.Range["D" + U, "D" + U].Font.FontStyle = "Bold";



                            xlNewSheet13.Range["E" + U, "E" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet13.Range["E" + U, "E" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet13.Range["E" + U, "E" + U].Font.Name = "Calibri";
                            xlNewSheet13.Range["E" + U, "E" + U].Font.Size = 10;
                            xlNewSheet13.Range["E" + U, "E" + U].Font.FontStyle = "Ragular";


                            xlNewSheet13.Range["F" + U, "F" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet13.Range["F" + U, "F" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet13.Range["F" + U, "F" + U].Font.Name = "Calibri";
                            xlNewSheet13.Range["F" + U, "F" + U].Font.Size = 10;
                            xlNewSheet13.Range["F" + U, "F" + U].Font.FontStyle = "Ragular";


                            xlNewSheet13.Range["G" + U, "G" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet13.Range["G" + U, "G" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet13.Range["G" + U, "G" + U].Font.Name = "Calibri";
                            xlNewSheet13.Range["G" + U, "G" + U].Font.Size = 10;
                            xlNewSheet13.Range["G" + U, "G" + U].Font.FontStyle = "Ragular";

                            xlNewSheet13.Range["H" + U, "H" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet13.Range["H" + U, "H" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet13.Range["H" + U, "H" + U].Font.Name = "Calibri";
                            xlNewSheet13.Range["H" + U, "H" + U].Font.Size = 10;
                            xlNewSheet13.Range["H" + U, "H" + U].Font.FontStyle = "Ragular";

                            xlNewSheet13.Range["I" + U, "I" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet13.Range["I" + U, "I" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet13.Range["I" + U, "I" + U].Font.Name = "Calibri";
                            xlNewSheet13.Range["I" + U, "I" + U].Font.Size = 10;
                            xlNewSheet13.Range["I" + U, "I" + U].Font.FontStyle = "Ragular";
                            xlNewSheet13.Range["I" + U, "I" + U].Font.FontStyle = "Bold";

                            xlNewSheet13.Range["J" + U, "J" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet13.Range["J" + U, "J" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet13.Range["J" + U, "J" + U].Font.Name = "Calibri";
                            xlNewSheet13.Range["J" + U, "J" + U].Font.Size = 11;
                            xlNewSheet13.Range["J" + U, "J" + U].Font.FontStyle = "Bold";
                            xlNewSheet13.Range["J" + U, "J" + U].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red);

                            xlNewSheet13.Range["K" + U, "K" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet13.Range["K" + U, "K" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet13.Range["K" + U, "K" + U].Font.Name = "Calibri";
                            xlNewSheet13.Range["K" + U, "K" + U].Font.Size = 11;
                            xlNewSheet13.Range["K" + U, "K" + U].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.DarkBlue);
                            xlNewSheet13.Range["K" + U, "K" + U].Font.FontStyle = "Bold";

                            xlNewSheet13.Range["L" + U, "L" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet13.Range["L" + U, "L" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet13.Range["L" + U, "L" + U].Font.Name = "Calibri";
                            xlNewSheet13.Range["L" + U, "L" + U].Font.Size = 11;
                            xlNewSheet13.Range["L" + U, "L" + U].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.DarkBlue);
                            xlNewSheet13.Range["L" + U, "L" + U].Font.FontStyle = "Bold";

                            xlNewSheet13.Range["M" + U, "M" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet13.Range["M" + U, "M" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet13.Range["M" + U, "M" + U].Font.Name = "Calibri";
                            xlNewSheet13.Range["M" + U, "M" + U].Font.Size = 11;
                            xlNewSheet13.Range["M" + U, "M" + U].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Green);
                            xlNewSheet13.Range["M" + U, "M" + U].Font.FontStyle = "Bold";

                            xlNewSheet13.Range["N" + U, "N" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet13.Range["N" + U, "N" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet13.Range["N" + U, "N" + U].Font.Name = "Calibri";
                            xlNewSheet13.Range["N" + U, "N" + U].Font.Size = 11;
                            xlNewSheet13.Range["N" + U, "N" + U].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Green);
                            xlNewSheet13.Range["N" + U, "N" + U].Font.FontStyle = "Bold";

                            xlNewSheet13.Range["O" + U, "O" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet13.Range["O" + U, "O" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet13.Range["O" + U, "O" + U].Font.Name = "Calibri";
                            xlNewSheet13.Range["O" + U, "O" + U].Font.Size = 11;
                            xlNewSheet13.Range["O" + U, "O" + U].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.DarkBlue);
                            xlNewSheet13.Range["O" + U, "O" + U].Font.FontStyle = "Bold";

                            xlNewSheet13.Range["P" + U, "P" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet13.Range["P" + U, "P" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet13.Range["P" + U, "P" + U].Font.Name = "Calibri";
                            xlNewSheet13.Range["P" + U, "P" + U].Font.Size = 11;
                            xlNewSheet13.Range["P" + U, "P" + U].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.DarkBlue);
                            xlNewSheet13.Range["P" + U, "P" + U].Font.FontStyle = "Bold";

                            xlNewSheet13.Range["Q" + U, "Q" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet13.Range["Q" + U, "Q" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet13.Range["Q" + U, "Q" + U].Font.Name = "Calibri";
                            xlNewSheet13.Range["Q" + U, "Q" + U].Font.Size = 11;
                            xlNewSheet13.Range["Q" + U, "Q" + U].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Green);
                            xlNewSheet13.Range["Q" + U, "Q" + U].Font.FontStyle = "Bold";

                            xlNewSheet13.Range["R" + U, "R" + U].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet13.Range["R" + U, "R" + U].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet13.Range["R" + U, "R" + U].Font.Name = "Calibri";
                            xlNewSheet13.Range["R" + U, "R" + U].Font.Size = 11;
                            xlNewSheet13.Range["R" + U, "R" + U].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Green);
                            xlNewSheet13.Range["R" + U, "R" + U].Font.FontStyle = "Bold";



                            T++;
                        }
                        xlNewSheet13.Columns.AutoFit();
                        xlNewSheet13.get_Range("A1", "A2").Merge();
                        xlNewSheet13.get_Range("B1", "B2").Merge();
                        xlNewSheet13.get_Range("C1", "C2").Merge();
                        xlNewSheet13.get_Range("D1", "D2").Merge();
                        xlNewSheet13.get_Range("E1", "E2").Merge();
                        xlNewSheet13.get_Range("F1", "F2").Merge();
                        xlNewSheet13.get_Range("G1", "G2").Merge();
                        xlNewSheet13.get_Range("H1", "H2").Merge();
                        xlNewSheet13.get_Range("I1", "I2").Merge();
                        xlNewSheet13.get_Range("J1", "J2").Merge();
                        //xlNewSheet13.get_Range("K1", "K2").Merge();

                        xlNewSheet13.Range["A1", "A2"].Font.Bold = true;
                        xlNewSheet13.Range["A1", "A2"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet13.Range["B1", "B2"].Font.Bold = true;
                        xlNewSheet13.Range["B1", "B2"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet13.Range["C1", "C2"].Font.Bold = true;
                        xlNewSheet13.Range["C1", "C2"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet13.Range["D1", "D2"].Font.Bold = true;
                        xlNewSheet13.Range["D1", "D2"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet13.Range["E1", "E2"].Font.Bold = true;
                        xlNewSheet13.Range["E1", "E2"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet13.Range["F1", "F2"].Font.Bold = true;
                        xlNewSheet13.Range["F1", "F2"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet13.Range["G1", "G2"].Font.Bold = true;
                        xlNewSheet13.Range["G1", "G2"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet13.Range["H1", "H2"].Font.Bold = true;
                        xlNewSheet13.Range["H1", "H2"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet13.Range["I1", "I2"].Font.Bold = true;
                        xlNewSheet13.Range["I1", "I2"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet13.Range["J1", "J2"].Font.Bold = true;
                        xlNewSheet13.Range["J1", "J2"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                        //xlNewSheet13.Range["K1", "K2"].Font.Bold = true;
                        //xlNewSheet13.Range["K1", "K2"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                        xlNewSheet13.Range["A1", "R1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        xlNewSheet13.Range["A2", "R2"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        xlNewSheet13.Range["A1", "R1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                        xlNewSheet13.Range["A2", "R2"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                        xlNewSheet13.Range["A1", "R1"].EntireColumn.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet13.Range["A2", "R2"].EntireColumn.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet13.get_Range("A1:R" + T).Cells.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                        xlNewSheet13.get_Range("A2:R" + T).Cells.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                        xlNewSheet13.Range["E1"].Cells.EntireColumn.NumberFormat = "d mmm (ddd);@";
                        xlNewSheet13.Range["F1"].Cells.EntireColumn.NumberFormat = "d mmm (ddd);@";
                        xlNewSheet13.Range["G1"].Cells.EntireColumn.NumberFormat = "d mmm (ddd);@";
                        xlNewSheet13.Range["H1"].Cells.EntireColumn.NumberFormat = "d mmm (ddd);@";
                        xlNewSheet13.Range["J1"].Cells.EntireColumn.NumberFormat = "₹0.00";
                        xlNewSheet13.Range["M1"].Cells.EntireColumn.NumberFormat = "₹0.00";
                        xlNewSheet13.Range["N1"].Cells.EntireColumn.NumberFormat = "₹0.00";
                        xlNewSheet13.Range["Q1"].Cells.EntireColumn.NumberFormat = "₹0.00";
                        xlNewSheet13.Range["R1"].Cells.EntireColumn.NumberFormat = "₹0.00";

                        xlNewSheet13.get_Range("K1", "R1").Merge();
                        xlNewSheet13.get_Range("K1", "R1").Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;



                        xlNewSheet13.Select();
                        ((Excel.Worksheet)xlApp.ActiveWorkbook.Sheets[1]).Activate();
                        releaseObject(xlNewSheet13);
                        //((Excel.Worksheet)xlApp.ActiveWorkbook.Sheets[1]).Activate();


                    }
                }




                if (ReportType == "Buyer_OnHold_Pending")
                {
                    // iKandi.Common.Constants.WorkSheetCount_ForExcel = iKandi.Common.Constants.WorkSheetCount_ForExcel + 1;
                    GlobalCount_OnHold = GlobalCount_OnHold + 1;
                    var xlNewSheet16 = (Excel.Worksheet)worksheets.Add(worksheets[GlobalCount_OnHold], Type.Missing, Type.Missing, Type.Missing);
                    xlNewSheet16.Name = "PO_Onhold_report";
                    xlNewSheet16.Cells[1, 1] = "Serial number";
                    xlNewSheet16.Cells[1, 2] = "Style number";
                    xlNewSheet16.Cells[1, 3] = "Department Name";
                    xlNewSheet16.Cells[1, 4] = "Contract Number";
                    xlNewSheet16.Cells[1, 5] = "Line-Item Number";
                    xlNewSheet16.Cells[1, 6] = "First Fabric";
                    xlNewSheet16.Cells[1, 7] = "Quantity";
                    xlNewSheet16.Cells[1, 8] = "Unit Name";
                    xlNewSheet16.Cells[1, 9] = "ExFactory";
                    xlNewSheet16.Cells[1, 10] = "AM";
                    xlNewSheet16.Cells[1, 11] = "DC";
                    xlNewSheet16.Cells[1, 12] = "Order Date";
                    xlNewSheet16.Cells[1, 13] = "Order Description";

                    //xlNewSheet11.Cells[1, 17] = "STC Requested But Grading Pending";
                    //xlNewSheet11.Cells[1, 18] = "STC Done But Pattern Sample Pending";
                    //xlNewSheet11.Cells[1, 19] = "Pattern Sample Done But Production Pending";



                    if (ds.Tables[0].Rows.Count == 0)
                    {
                        return false;
                    }
                    else if (ds.Tables[0].Rows.Count > 0)
                    {
                        int S = 1;
                        int J = 1;
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {

                            xlNewSheet16.Cells[S + 1, 1] = dr["Serialnumber"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Serialnumber"]);
                            xlNewSheet16.Cells[S + 1, 2] = dr["Stylenumber"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Stylenumber"]);
                            xlNewSheet16.Cells[S + 1, 3] = dr["DepartmentName"] == DBNull.Value ? string.Empty : Convert.ToString(dr["DepartmentName"]);
                            xlNewSheet16.Cells[S + 1, 4] = dr["ContractNumber"] == DBNull.Value ? string.Empty : Convert.ToString(dr["ContractNumber"]);
                            xlNewSheet16.Cells[S + 1, 5] = dr["LineItemNumber"] == DBNull.Value ? string.Empty : Convert.ToString(dr["LineItemNumber"]);
                            xlNewSheet16.Cells[S + 1, 6] = dr["Fabric1Details"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Fabric1Details"]);
                            xlNewSheet16.Cells[S + 1, 7] = dr["Quantity"] == DBNull.Value ? string.Empty : Convert.ToInt32(dr["Quantity"]).ToString("N0");//add Code By bharat on 12-12-19;
                            xlNewSheet16.Cells[S + 1, 8] = dr["UnitName"] == DBNull.Value ? string.Empty : Convert.ToString(dr["UnitName"]);
                            xlNewSheet16.Cells[S + 1, 9] = dr["ExFactory"] == DBNull.Value ? string.Empty : dr["ExFactory"];
                            xlNewSheet16.Cells[S + 1, 10] = dr["AM"] == DBNull.Value ? string.Empty : Convert.ToString(dr["AM"]);
                            xlNewSheet16.Cells[S + 1, 11] = dr["DC"] == DBNull.Value ? string.Empty : Convert.ToString(dr["DC"]);
                            xlNewSheet16.Cells[S + 1, 12] = dr["OrderDate"] == DBNull.Value ? string.Empty : Convert.ToString(dr["OrderDate"]);
                            xlNewSheet16.Cells[S + 1, 13] = dr["Description"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Description"]);


                            J = S + 1;
                            //if (S != 1)
                            //{

                            //}




                            S++;
                        }
                        xlNewSheet16.Columns.AutoFit();
                        xlNewSheet16.Range["A1", "M1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);

                        xlNewSheet16.Range["A1", "M1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                        //xlNewSheet16.Range["A1", "J1"].Font.Bold = true;

                        xlNewSheet16.Range["A1", "M1"].EntireColumn.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet16.Range["A1"].EntireColumn.Font.Bold = true;
                        xlNewSheet16.Range["B1"].EntireColumn.Font.Bold = true;
                        xlNewSheet16.Range["G1"].EntireColumn.Font.Bold = true;
                        xlNewSheet16.Range["I1"].EntireColumn.Font.Bold = true;
                        xlNewSheet16.Range["A1"].EntireColumn.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Blue);
                        xlNewSheet16.Range["I1"].EntireColumn.Font.Size = 14;
                        xlNewSheet16.Range["A1"].Cells.Font.Bold = false;
                        xlNewSheet16.Range["B1"].Cells.Font.Bold = false;
                        xlNewSheet16.Range["G1"].Cells.Font.Bold = false;
                        xlNewSheet16.Range["I1"].Cells.Font.Bold = false;
                        xlNewSheet16.Range["A1"].Cells.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black);
                        xlNewSheet16.Range["I1"].Cells.ColumnWidth = 16;
                        xlNewSheet16.Range["A1", "M1"].EntireColumn.WrapText = true;
                        xlNewSheet16.Range["I1"].Cells.Font.Size = 11;

                        xlNewSheet16.Range["K1"].EntireColumn.Font.Bold = true;
                        xlNewSheet16.Range["K1"].EntireColumn.Font.Size = 14;
                        xlNewSheet16.Range["K1"].Cells.Font.Bold = false;
                        xlNewSheet16.Range["K1"].Cells.ColumnWidth = 16;
                        xlNewSheet16.Range["K1"].Cells.Font.Size = 11;

                        xlNewSheet16.Range["L1"].EntireColumn.Font.Bold = true;
                        xlNewSheet16.Range["L1"].EntireColumn.Font.Size = 14;
                        xlNewSheet16.Range["L1"].Cells.Font.Bold = false;
                        xlNewSheet16.Range["L1"].Cells.ColumnWidth = 16;
                        xlNewSheet16.Range["L1"].Cells.Font.Size = 11;


                        //----------change date format with filter created by Surendra Sharma on 09-03-2018.----
                        xlNewSheet16.Range["I1"].Cells.EntireColumn.NumberFormat = "dd mmm (ddd);@";
                        xlNewSheet16.Range["K1"].Cells.EntireColumn.NumberFormat = "dd mmm (ddd);@";
                        xlNewSheet16.Range["L1"].Cells.EntireColumn.NumberFormat = "dd mmm (ddd);@";
                        //-------------End-----------------------------------------------------------------------

                        xlNewSheet16.get_Range("A1:M" + S).Cells.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;

                        releaseObject(xlNewSheet16);
                        ((Excel.Worksheet)xlApp.ActiveWorkbook.Sheets[1]).Activate();

                    }

                }

                if (ReportType == "Buyer_POPending")
                {
                    // iKandi.Common.Constants.WorkSheetCount_ForExcel = iKandi.Common.Constants.WorkSheetCount_ForExcel + 1;
                    GlobalCount_PO = GlobalCount_PO + 1;
                    var xlNewSheet16 = (Excel.Worksheet)worksheets.Add(worksheets[GlobalCount_PO], Type.Missing, Type.Missing, Type.Missing);
                    xlNewSheet16.Name = "Buyer_POPending";
                    xlNewSheet16.Cells[1, 1] = "Serial number";
                    xlNewSheet16.Cells[1, 2] = "Style number";
                    xlNewSheet16.Cells[1, 3] = "Department Name";
                    xlNewSheet16.Cells[1, 4] = "Contract Number";
                    xlNewSheet16.Cells[1, 5] = "Line-Item Number";
                    xlNewSheet16.Cells[1, 6] = "First Fabric";
                    xlNewSheet16.Cells[1, 7] = "Quantity";
                    xlNewSheet16.Cells[1, 8] = "Unit Name";
                    xlNewSheet16.Cells[1, 9] = "ExFactory";
                    xlNewSheet16.Cells[1, 10] = "AM";
                    xlNewSheet16.Cells[1, 11] = "DC";
                    xlNewSheet16.Cells[1, 12] = "Order Date";
                    xlNewSheet16.Cells[1, 13] = "Order Description";

                    //xlNewSheet11.Cells[1, 17] = "STC Requested But Grading Pending";
                    //xlNewSheet11.Cells[1, 18] = "STC Done But Pattern Sample Pending";
                    //xlNewSheet11.Cells[1, 19] = "Pattern Sample Done But Production Pending";



                    if (ds.Tables[0].Rows.Count == 0)
                    {
                        return false;
                    }
                    else if (ds.Tables[0].Rows.Count > 0)
                    {
                        int S = 1;
                        int J = 1;
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {

                            xlNewSheet16.Cells[S + 1, 1] = dr["Serialnumber"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Serialnumber"]);
                            xlNewSheet16.Cells[S + 1, 2] = dr["Stylenumber"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Stylenumber"]);
                            xlNewSheet16.Cells[S + 1, 3] = dr["DepartmentName"] == DBNull.Value ? string.Empty : Convert.ToString(dr["DepartmentName"]);
                            xlNewSheet16.Cells[S + 1, 4] = dr["ContractNumber"] == DBNull.Value ? string.Empty : Convert.ToString(dr["ContractNumber"]);
                            xlNewSheet16.Cells[S + 1, 5] = dr["LineItemNumber"] == DBNull.Value ? string.Empty : Convert.ToString(dr["LineItemNumber"]);
                            xlNewSheet16.Cells[S + 1, 6] = dr["Fabric1Details"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Fabric1Details"]);
                            xlNewSheet16.Cells[S + 1, 7] = dr["Quantity"] == DBNull.Value ? string.Empty : Convert.ToInt32(dr["Quantity"]).ToString("N0");//Add Code By Bharat on 12-12-19;
                            xlNewSheet16.Cells[S + 1, 8] = dr["UnitName"] == DBNull.Value ? string.Empty : Convert.ToString(dr["UnitName"]);
                            xlNewSheet16.Cells[S + 1, 9] = dr["ExFactory"] == DBNull.Value ? string.Empty : dr["ExFactory"];
                            xlNewSheet16.Cells[S + 1, 10] = dr["AM"] == DBNull.Value ? string.Empty : Convert.ToString(dr["AM"]);
                            xlNewSheet16.Cells[S + 1, 11] = dr["DC"] == DBNull.Value ? string.Empty : Convert.ToString(dr["DC"]);
                            xlNewSheet16.Cells[S + 1, 12] = dr["OrderDate"] == DBNull.Value ? string.Empty : Convert.ToString(dr["OrderDate"]);
                            xlNewSheet16.Cells[S + 1, 13] = dr["Description"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Description"]);


                            J = S + 1;
                            //if (S != 1)
                            //{

                            //}




                            S++;
                        }
                        xlNewSheet16.Columns.AutoFit();
                        xlNewSheet16.Range["A1", "M1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);

                        xlNewSheet16.Range["A1", "M1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                        //xlNewSheet16.Range["A1", "J1"].Font.Bold = true;

                        xlNewSheet16.Range["A1", "M1"].EntireColumn.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet16.Range["A1"].EntireColumn.Font.Bold = true;
                        xlNewSheet16.Range["B1"].EntireColumn.Font.Bold = true;
                        xlNewSheet16.Range["G1"].EntireColumn.Font.Bold = true;
                        xlNewSheet16.Range["I1"].EntireColumn.Font.Bold = true;
                        xlNewSheet16.Range["A1"].EntireColumn.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Blue);
                        xlNewSheet16.Range["I1"].EntireColumn.Font.Size = 14;
                        xlNewSheet16.Range["A1"].Cells.Font.Bold = false;
                        xlNewSheet16.Range["B1"].Cells.Font.Bold = false;
                        xlNewSheet16.Range["G1"].Cells.Font.Bold = false;
                        xlNewSheet16.Range["I1"].Cells.Font.Bold = false;
                        xlNewSheet16.Range["A1"].Cells.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black);
                        xlNewSheet16.Range["I1"].Cells.ColumnWidth = 16;
                        xlNewSheet16.Range["A1", "M1"].EntireColumn.WrapText = true;
                        xlNewSheet16.Range["I1"].Cells.Font.Size = 11;

                        xlNewSheet16.Range["K1"].EntireColumn.Font.Bold = true;
                        xlNewSheet16.Range["K1"].EntireColumn.Font.Size = 14;
                        xlNewSheet16.Range["K1"].Cells.Font.Bold = false;
                        xlNewSheet16.Range["K1"].Cells.ColumnWidth = 16;
                        xlNewSheet16.Range["K1"].Cells.Font.Size = 11;

                        xlNewSheet16.Range["L1"].EntireColumn.Font.Bold = true;
                        xlNewSheet16.Range["L1"].EntireColumn.Font.Size = 14;
                        xlNewSheet16.Range["L1"].Cells.Font.Bold = false;
                        xlNewSheet16.Range["L1"].Cells.ColumnWidth = 16;
                        xlNewSheet16.Range["L1"].Cells.Font.Size = 11;


                        //----------change date format with filter created by Surendra Sharma on 09-03-2018.----
                        xlNewSheet16.Range["I1"].Cells.EntireColumn.NumberFormat = "dd mmm (ddd);@";
                        xlNewSheet16.Range["K1"].Cells.EntireColumn.NumberFormat = "dd mmm (ddd);@";
                        xlNewSheet16.Range["L1"].Cells.EntireColumn.NumberFormat = "dd mmm (ddd);@";
                        //-------------End-----------------------------------------------------------------------

                        xlNewSheet16.get_Range("A1:M" + S).Cells.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;

                        releaseObject(xlNewSheet16);
                        ((Excel.Worksheet)xlApp.ActiveWorkbook.Sheets[1]).Activate();

                    }

                }
                if (ReportType == "Reallocation_OutHouse")
                {
                    //iKandi.Common.Constants.WorkSheetCount_ForExcel = iKandi.Common.Constants.WorkSheetCount_ForExcel + 1;
                    ColorConverter cc = new ColorConverter();
                    GlobalCount_OutHouse = GlobalCount_OutHouse + 1;
                    var xlNewSheet17 = (Excel.Worksheet)worksheets.Add(worksheets[GlobalCount_OutHouse], Type.Missing, Type.Missing, Type.Missing);
                    xlNewSheet17.Name = "OutHouseReport";
                    xlNewSheet17.Cells[1, 1] = "Unit";
                    xlNewSheet17.Cells[1, 2] = "Type";
                    xlNewSheet17.Cells[1, 3] = "Fabricator";
                    xlNewSheet17.Cells[1, 4] = "Style Number";
                    xlNewSheet17.Cells[1, 5] = "Serail No.";
                    xlNewSheet17.Cells[1, 6] = "Color";
                    xlNewSheet17.Cells[1, 7] = "Agreed Qty";
                    xlNewSheet17.Cells[1, 8] = "Cut Issue Tdy.";
                    xlNewSheet17.Cells[1, 9] = "Cut Issue Tot.";
                    xlNewSheet17.Cells[1, 10] = "Stitch Recvd Today";
                    xlNewSheet17.Cells[1, 11] = "Stitch Recvd Total";
                    xlNewSheet17.Cells[1, 12] = "St.Start Dt.";
                    xlNewSheet17.Cells[1, 13] = "St.End Dt.";
                    xlNewSheet17.Cells[1, 14] = "Pcs/day";
                    xlNewSheet17.Cells[1, 15] = "Bal To St.";
                    xlNewSheet17.Cells[1, 16] = "Ex date";
                    xlNewSheet17.Cells[1, 17] = "Man Power Employed";
                    xlNewSheet17.Cells[1, 18] = "QC";
                    xlNewSheet17.Cells[1, 19] = "Checker";
                    xlNewSheet17.Cells[1, 20] = "Total Machines";
                    //xlNewSheet17.Cells[2, 20] = "Remark";

                    if (ds.Tables[0].Rows.Count == 0)
                    {
                        return false;
                    }
                    else if (ds.Tables[0].Rows.Count > 0)
                    {
                        int i = 2;
                        int j = 1;
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            int BgColorRed = 0;

                            BgColorRed = dr["BgColorRed"] == DBNull.Value ? 0 : Convert.ToInt32(dr["BgColorRed"]);


                            xlNewSheet17.Cells[i, 1] = (dr["Unit"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["Unit"]);
                            xlNewSheet17.Cells[i, 2] = (dr["TYPE"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["TYPE"]);
                            xlNewSheet17.Cells[i, 3] = (dr["Fabricator"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["Fabricator"]);
                            xlNewSheet17.Cells[i, 4] = (dr["StyleNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["StyleNumber"]);
                            xlNewSheet17.Cells[i, 5] = (dr["SerialNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["SerialNumber"]);
                            xlNewSheet17.Cells[i, 6] = (dr["Fabric1Details"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["Fabric1Details"]);
                            xlNewSheet17.Cells[i, 7] = (dr["AgrredQty"] == DBNull.Value) ? string.Empty : Convert.ToInt32(dr["AgrredQty"]).ToString("N0"); //Add Code By Bharat on 12-12-19
                            xlNewSheet17.Cells[i, 8] = Convert.ToString(dr["CutIssueToday"]) == "0" ? string.Empty : dr["CutIssueToday"];
                            xlNewSheet17.Cells[i, 9] = Convert.ToString(dr["CutHouseTotal"]) == "0" ? string.Empty : dr["CutHouseTotal"];
                            xlNewSheet17.Cells[i, 10] = Convert.ToString(dr["StitchedReceivedToday"]) == "0" ? string.Empty : dr["StitchedReceivedToday"];
                            xlNewSheet17.Cells[i, 11] = Convert.ToString(dr["StichedReceivedTotal"]) == "0" ? string.Empty : dr["StichedReceivedTotal"];
                            xlNewSheet17.Cells[i, 12] = (dr["StitchStartDate"] == DBNull.Value) ? string.Empty : dr["StitchStartDate"];
                            xlNewSheet17.Cells[i, 13] = (dr["StitchEndDate"] == DBNull.Value) ? string.Empty : dr["StitchEndDate"];
                            xlNewSheet17.Cells[i, 14] = (dr["PcsPerDay"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["PcsPerDay"]);
                            xlNewSheet17.Cells[i, 15] = Convert.ToString(dr["BalanceToStitch"]) == "0" ? string.Empty : dr["BalanceToStitch"];
                            xlNewSheet17.Cells[i, 16] = (dr["ExFactory"] == DBNull.Value) ? string.Empty : dr["ExFactory"];
                            xlNewSheet17.Cells[i, 17] = Convert.ToString(dr["OutHouseManpower"]) == "0" ? string.Empty : dr["OutHouseManpower"];
                            xlNewSheet17.Cells[i, 18] = (dr["OutHouseQC"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["OutHouseQC"]);
                            xlNewSheet17.Cells[i, 19] = (dr["OutHouseChecker"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["OutHouseChecker"]);
                            xlNewSheet17.Cells[i, 20] = (dr["TotalMachine"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["TotalMachine"]);



                            xlNewSheet17.Range["A" + j, "A" + j].Font.Color = ColorTranslator.ToOle(System.Drawing.Color.Black);
                            xlNewSheet17.Range["C" + j, "C" + j].Font.Color = ColorTranslator.ToOle(System.Drawing.Color.Black);
                            xlNewSheet17.Range["E" + j, "E" + j].Font.Color = ColorTranslator.ToOle(System.Drawing.Color.DeepSkyBlue);
                            //xlNewSheet17.Range["E" + j, "E" + j].Font.Color = ColorTranslator.ToOle(System.Drawing.Color.DeepSkyBlue);
                            xlNewSheet17.Range["E" + j, "E" + j].Font.Color = ColorTranslator.ToOle((Color)cc.ConvertFromString("#0070c0"));
                            xlNewSheet17.Range["G" + j, "G" + j].Font.Color = ColorTranslator.ToOle(System.Drawing.Color.Black);
                            xlNewSheet17.Range["J" + j, "J" + j].Font.Color = ColorTranslator.ToOle(System.Drawing.Color.Black);
                            xlNewSheet17.Range["L" + j, "L" + j].Font.Color = ColorTranslator.ToOle(System.Drawing.Color.Black);
                            xlNewSheet17.Range["M" + j, "M" + j].Font.Color = ColorTranslator.ToOle(System.Drawing.Color.Black);
                            xlNewSheet17.Range["P" + j, "P" + j].Font.Color = ColorTranslator.ToOle(System.Drawing.Color.Black);

                            if (BgColorRed == 1)
                            {
                                //xlNewSheet17.Range["A" + j, "A" + j].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Red);
                                //xlNewSheet17.Range["B" + j, "B" + j].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Red);
                                //xlNewSheet17.Range["C" + j, "C" + j].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Red);
                                //xlNewSheet17.Range["D" + j, "D" + j].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Red);
                                //xlNewSheet17.Range["E" + j, "E" + j].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Red);
                                //xlNewSheet17.Range["F" + j, "F" + j].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Red);
                                //xlNewSheet17.Range["G" + j, "G" + j].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Red);
                                //xlNewSheet17.Range["H" + j, "H" + j].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Red);
                                //xlNewSheet17.Range["I" + j, "I" + j].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Red);
                                //xlNewSheet17.Range["J" + j, "J" + j].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Red);
                                //xlNewSheet17.Range["K" + j, "K" + j].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Red);
                                xlNewSheet17.Range["L" + j, "L" + j].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Red);
                                //xlNewSheet17.Range["M" + j, "M" + j].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Red);
                                //xlNewSheet17.Range["N" + j, "N" + j].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Red);
                                //xlNewSheet17.Range["O" + j, "O" + j].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Red);
                                //xlNewSheet17.Range["P" + j, "P" + j].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Red);
                                //xlNewSheet17.Range["Q" + j, "Q" + j].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Red);
                                //xlNewSheet17.Range["R" + j, "R" + j].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Red);
                                //xlNewSheet17.Range["S" + j, "S" + j].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Red);

                            }
                            else
                            {
                                //xlNewSheet17.Range["A" + j, "A" + j].Font.Color = ColorTranslator.ToOle(System.Drawing.Color.Gray);
                                //xlNewSheet17.Range["B" + j, "B" + j].Font.Color = ColorTranslator.ToOle(System.Drawing.Color.Gray);
                                //xlNewSheet17.Range["C" + j, "C" + j].Font.Color = ColorTranslator.ToOle(System.Drawing.Color.Gray);
                                //xlNewSheet17.Range["D" + j, "D" + j].Font.Color = ColorTranslator.ToOle(System.Drawing.Color.Gray);
                                //xlNewSheet17.Range["E" + j, "E" + j].Font.Color = ColorTranslator.ToOle(System.Drawing.Color.Black);
                                //xlNewSheet17.Range["F" + j, "F" + j].Font.Color = ColorTranslator.ToOle(System.Drawing.Color.Black);
                                //xlNewSheet17.Range["G" + j, "G" + j].Font.Color = ColorTranslator.ToOle(System.Drawing.Color.Black);
                                //xlNewSheet17.Range["H" + j, "H" + j].Font.Color = ColorTranslator.ToOle(System.Drawing.Color.Gray);
                                //xlNewSheet17.Range["I" + j, "I" + j].Font.Color = ColorTranslator.ToOle(System.Drawing.Color.Gray);
                                //xlNewSheet17.Range["J" + j, "J" + j].Font.Color = ColorTranslator.ToOle(System.Drawing.Color.Blue);
                                //xlNewSheet17.Range["K" + j, "K" + j].Font.Color = ColorTranslator.ToOle(System.Drawing.Color.Black);
                                xlNewSheet17.Range["L" + j, "L" + j].Font.Color = ColorTranslator.ToOle(System.Drawing.Color.Green);
                                //xlNewSheet17.Range["M" + j, "M" + j].Font.Color = ColorTranslator.ToOle(System.Drawing.Color.Black);
                                //xlNewSheet17.Range["N" + j, "N" + j].Font.Color = ColorTranslator.ToOle(System.Drawing.Color.Black);
                                //xlNewSheet17.Range["O" + j, "O" + j].Font.Color = ColorTranslator.ToOle(System.Drawing.Color.Black);
                                //xlNewSheet17.Range["P" + j, "P" + j].Font.Color = ColorTranslator.ToOle(System.Drawing.Color.Black);
                                //xlNewSheet17.Range["Q" + j, "Q" + j].Font.Color = ColorTranslator.ToOle(System.Drawing.Color.Black);
                                //xlNewSheet17.Range["R" + j, "R" + j].Font.Color = ColorTranslator.ToOle(System.Drawing.Color.Black);
                                //xlNewSheet17.Range["S" + j, "S" + j].Font.Color = ColorTranslator.ToOle(System.Drawing.Color.Black);
                            }


                            //xlNewSheet17.Range["A2", "A2"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            //xlNewSheet17.Range["B2", "B2"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            //xlNewSheet17.Range["C2", "C2"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            //xlNewSheet17.Range["D2", "D2"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            //xlNewSheet17.Range["E2", "E2"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            //xlNewSheet17.Range["F2", "F2"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            //xlNewSheet17.Range["G2", "G2"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            //xlNewSheet17.Range["H2", "H2"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            //xlNewSheet17.Range["I2", "I2"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            //xlNewSheet17.Range["J2", "J2"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            //xlNewSheet17.Range["K2", "K2"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            //xlNewSheet17.Range["L2", "L2"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            //xlNewSheet17.Range["M2", "M2"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            //xlNewSheet17.Range["N2", "N2"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            //xlNewSheet17.Range["O2", "O2"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            //xlNewSheet17.Range["P2", "P2"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            //xlNewSheet17.Range["Q2", "Q2"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            //xlNewSheet17.Range["R2", "R2"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            //xlNewSheet17.Range["S2", "S2"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            //xlNewSheet17.Range["T2", "T2"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet17.Range["A" + j, "A" + j].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet17.Range["B" + j, "B" + j].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet17.Range["C" + j, "C" + j].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet17.Range["D" + j, "D" + j].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet17.Range["E" + j, "E" + j].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet17.Range["F" + j, "F" + j].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet17.Range["G" + j, "G" + j].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet17.Range["H" + i, "H" + j].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet17.Range["I" + j, "I" + j].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet17.Range["J" + j, "J" + j].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet17.Range["K" + j, "K" + j].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet17.Range["L" + j, "L" + j].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet17.Range["M" + j, "M" + j].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet17.Range["N" + j, "N" + j].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet17.Range["O" + j, "O" + j].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet17.Range["P" + j, "P" + j].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet17.Range["Q" + j, "Q" + j].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet17.Range["R" + j, "R" + j].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet17.Range["S" + j, "S" + j].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet17.Range["T" + j, "T" + j].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;

                            xlNewSheet17.Range["A" + j, "A" + j].Font.Bold = true;
                            xlNewSheet17.Range["C" + j, "C" + j].Font.Bold = true;
                            xlNewSheet17.Range["E" + j, "E" + j].Font.Bold = true;
                            xlNewSheet17.Range["G" + j, "G" + j].Font.Bold = true;
                            xlNewSheet17.Range["H" + j, "H" + j].Font.Bold = true;
                            xlNewSheet17.Range["J" + j, "J" + j].Font.Bold = true;
                            xlNewSheet17.Range["K" + j, "K" + j].Font.Bold = true;
                            xlNewSheet17.Range["L" + j, "L" + j].Font.Bold = true;
                            xlNewSheet17.Range["M" + j, "M" + j].Font.Bold = true;
                            xlNewSheet17.Range["P" + j, "P" + j].Font.Bold = true;

                            j = j + 1;

                            //xlNewSheet17.Cells[i + 1, 20] = (dr["Unit"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["Unit"]);
                            i++;

                        }
                        xlNewSheet17.Columns.AutoFit();
                        xlNewSheet17.Range["A1", "T1"].Interior.Color = ColorTranslator.ToOle((Color)cc.ConvertFromString("#0070c0"));
                        //xlNewSheet17.Range["E" + j, "E" + j].Font.Color = ColorTranslator.ToOle((Color)cc.ConvertFromString("#0070c0"));
                        //xlNewSheet17.Range["A2", "T2"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.LightSteelBlue);
                        xlNewSheet17.Range["A1", "T1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                        xlNewSheet17.Range["A1", "T1"].Font.Bold = true;
                        //xlNewSheet17.Range["A2", "T2"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                        //xlNewSheet17.Range["A2", "T2"].Font.Bold = true;

                        releaseObject(xlNewSheet17);

                    }
                }
                if (ReportType == "Reallocation_OutHouse_Emb")
                {
                    ColorConverter cc = new ColorConverter();
                    //iKandi.Common.Constants.WorkSheetCount_ForExcel = iKandi.Common.Constants.WorkSheetCount_ForExcel + 1;
                    GlobalCount_OutHouse_Emb = GlobalCount_OutHouse_Emb + 1;
                    var xlNewSheet18 = (Excel.Worksheet)worksheets.Add(worksheets[GlobalCount_OutHouse_Emb], Type.Missing, Type.Missing, Type.Missing);
                    xlNewSheet18.Name = "Reallocation_OutHouse_Emb";
                    xlNewSheet18.Cells[1, 1] = "Unit";
                    xlNewSheet18.Cells[1, 2] = "Type";
                    xlNewSheet18.Cells[1, 3] = "Fabricator";
                    xlNewSheet18.Cells[1, 4] = "Style Number";
                    xlNewSheet18.Cells[1, 5] = "Serail No.";
                    xlNewSheet18.Cells[1, 6] = "Color";
                    xlNewSheet18.Cells[1, 7] = "Value Addition St.Date.";
                    xlNewSheet18.Cells[1, 8] = "Value Addition End.Date.";
                    xlNewSheet18.Cells[1, 9] = "Pcs/day";
                    xlNewSheet18.Cells[1, 10] = "Ex date";
                    //xlNewSheet18.Cells[1, 11] = "Total Machines";

                    //xlNewSheet17.Cells[2, 20] = "Remark";

                    if (ds.Tables[0].Rows.Count == 0)
                    {
                        return false;
                    }
                    else if (ds.Tables[0].Rows.Count > 0)
                    {
                        int i = 1;
                        int j = 2;
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            int BgColorRed = 0;

                            BgColorRed = dr["BgColorRed"] == DBNull.Value ? 0 : Convert.ToInt32(dr["BgColorRed"]);


                            xlNewSheet18.Cells[i + 1, 1] = (dr["Name"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["Name"]);
                            xlNewSheet18.Cells[i + 1, 2] = (dr["Type"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["Type"]);
                            xlNewSheet18.Cells[i + 1, 3] = (dr["Fabricator"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["Fabricator"]);
                            xlNewSheet18.Cells[i + 1, 4] = (dr["StyleNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["StyleNumber"]);
                            xlNewSheet18.Cells[i + 1, 5] = (dr["SerialNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["SerialNumber"]);
                            xlNewSheet18.Cells[i + 1, 6] = (dr["Fabric1Details"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["Fabric1Details"]);
                            xlNewSheet18.Cells[i + 1, 7] = (dr["ValueAdditionStartDate"] == DBNull.Value) ? string.Empty : dr["ValueAdditionStartDate"];
                            xlNewSheet18.Cells[i + 1, 8] = Convert.ToString(dr["ValueAdditionEndDate"]) == "0" ? string.Empty : dr["ValueAdditionEndDate"];
                            xlNewSheet18.Cells[i + 1, 9] = Convert.ToString(dr["PcsPerday"]) == "0" ? string.Empty : dr["PcsPerday"];
                            xlNewSheet18.Cells[i + 1, 10] = Convert.ToString(dr["ExFactory"]) == "0" ? string.Empty : dr["ExFactory"];
                            //xlNewSheet18.Cells[i + 1, 11] = Convert.ToString(dr["TotalMachine"]) == "0" ? string.Empty : dr["TotalMachine"];

                            //xlNewSheet18.Range["A2", "A2"].Font.Color = ColorTranslator.ToOle(System.Drawing.Color.Black);
                            //xlNewSheet18.Range["C2", "C2"].Font.Color = ColorTranslator.ToOle(System.Drawing.Color.Black);
                            //xlNewSheet18.Range["E2", "E2"].Font.Color = ColorTranslator.ToOle(System.Drawing.Color.DeepSkyBlue);
                            //xlNewSheet18.Range["G2", "G2"].Font.Color = ColorTranslator.ToOle(System.Drawing.Color.Black);
                            //xlNewSheet18.Range["J2", "J2"].Font.Color = ColorTranslator.ToOle(System.Drawing.Color.Black);

                            xlNewSheet18.Range["A" + j, "A" + j].Font.Color = ColorTranslator.ToOle(System.Drawing.Color.Black);
                            xlNewSheet18.Range["C" + j, "C" + j].Font.Color = ColorTranslator.ToOle(System.Drawing.Color.Black);
                            xlNewSheet18.Range["E" + j, "E" + j].Font.Color = ColorTranslator.ToOle((Color)cc.ConvertFromString("#0070c0"));
                            xlNewSheet18.Range["G" + j, "G" + j].Font.Color = ColorTranslator.ToOle(System.Drawing.Color.Black);
                            xlNewSheet18.Range["J" + j, "J" + j].Font.Color = ColorTranslator.ToOle(System.Drawing.Color.Black);

                            if (BgColorRed == 1)
                            {
                                //xlNewSheet18.Range["J2", "J2"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Red);
                                xlNewSheet18.Range["J" + j, "J" + j].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Red);
                            }
                            else
                            {
                                //xlNewSheet18.Range["J2", "J2"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Green);
                                xlNewSheet18.Range["J" + j, "J" + j].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Green);
                            }


                            //if (BgColorRed == 1)
                            //{
                            //    xlNewSheet17.Range["A" + j, "A" + j].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Red);
                            //    xlNewSheet17.Range["B" + j, "B" + j].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Red);
                            //    xlNewSheet17.Range["C" + j, "C" + j].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Red);
                            //    xlNewSheet17.Range["D" + j, "D" + j].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Red);
                            //    xlNewSheet17.Range["E" + j, "E" + j].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Red);
                            //    xlNewSheet17.Range["F" + j, "F" + j].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Red);
                            //    xlNewSheet17.Range["G" + j, "G" + j].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Red);
                            //    xlNewSheet17.Range["H" + j, "H" + j].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Red);
                            //    xlNewSheet17.Range["I" + j, "I" + j].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Red);
                            //    xlNewSheet17.Range["J" + j, "J" + j].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Red);
                            //    xlNewSheet17.Range["K" + j, "K" + j].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Red);
                            //    xlNewSheet17.Range["L" + j, "L" + j].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Red);
                            //    xlNewSheet17.Range["M" + j, "M" + j].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Red);
                            //    xlNewSheet17.Range["N" + j, "N" + j].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Red);
                            //    xlNewSheet17.Range["O" + j, "O" + j].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Red);
                            //    xlNewSheet17.Range["P" + j, "P" + j].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Red);
                            //    xlNewSheet17.Range["Q" + j, "Q" + j].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Red);
                            //    xlNewSheet17.Range["R" + j, "R" + j].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Red);
                            //    xlNewSheet17.Range["S" + j, "S" + j].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Red);

                            //}
                            //else
                            //{
                            //    xlNewSheet17.Range["A" + j, "A" + j].Font.Color = ColorTranslator.ToOle(System.Drawing.Color.Gray);
                            //    xlNewSheet17.Range["B" + j, "B" + j].Font.Color = ColorTranslator.ToOle(System.Drawing.Color.Gray);
                            //    xlNewSheet17.Range["C" + j, "C" + j].Font.Color = ColorTranslator.ToOle(System.Drawing.Color.Gray);
                            //    xlNewSheet17.Range["D" + j, "D" + j].Font.Color = ColorTranslator.ToOle(System.Drawing.Color.Gray);
                            //    xlNewSheet17.Range["E" + j, "E" + j].Font.Color = ColorTranslator.ToOle(System.Drawing.Color.Black);
                            //    xlNewSheet17.Range["F" + j, "F" + j].Font.Color = ColorTranslator.ToOle(System.Drawing.Color.Black);
                            //    xlNewSheet17.Range["G" + j, "G" + j].Font.Color = ColorTranslator.ToOle(System.Drawing.Color.Black);
                            //    xlNewSheet17.Range["H" + j, "H" + j].Font.Color = ColorTranslator.ToOle(System.Drawing.Color.Gray);
                            //    xlNewSheet17.Range["I" + j, "I" + j].Font.Color = ColorTranslator.ToOle(System.Drawing.Color.Gray);
                            //    xlNewSheet17.Range["J" + j, "J" + j].Font.Color = ColorTranslator.ToOle(System.Drawing.Color.Blue);
                            //    xlNewSheet17.Range["K" + j, "K" + j].Font.Color = ColorTranslator.ToOle(System.Drawing.Color.Black);
                            //    xlNewSheet17.Range["L" + j, "L" + j].Font.Color = ColorTranslator.ToOle(System.Drawing.Color.Black);
                            //    xlNewSheet17.Range["M" + j, "M" + j].Font.Color = ColorTranslator.ToOle(System.Drawing.Color.Black);
                            //    xlNewSheet17.Range["N" + j, "N" + j].Font.Color = ColorTranslator.ToOle(System.Drawing.Color.Black);
                            //    xlNewSheet17.Range["O" + j, "O" + j].Font.Color = ColorTranslator.ToOle(System.Drawing.Color.Black);
                            //    xlNewSheet17.Range["P" + j, "P" + j].Font.Color = ColorTranslator.ToOle(System.Drawing.Color.Black);
                            //    xlNewSheet17.Range["Q" + j, "Q" + j].Font.Color = ColorTranslator.ToOle(System.Drawing.Color.Black);
                            //    xlNewSheet17.Range["R" + j, "R" + j].Font.Color = ColorTranslator.ToOle(System.Drawing.Color.Black);
                            //    xlNewSheet17.Range["S" + j, "S" + j].Font.Color = ColorTranslator.ToOle(System.Drawing.Color.Black);
                            //}

                            //xlNewSheet18.Range["A1", "A2"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            //xlNewSheet17.Range["B2", "B2"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            //xlNewSheet17.Range["C2", "C2"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            //xlNewSheet17.Range["D2", "D2"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            //xlNewSheet17.Range["E2", "E2"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            //xlNewSheet17.Range["F2", "F2"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            //xlNewSheet17.Range["G2", "G2"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            //xlNewSheet17.Range["H2", "H2"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            //xlNewSheet17.Range["I2", "I2"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            //xlNewSheet17.Range["J2", "J2"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            //xlNewSheet17.Range["K2", "K2"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            //xlNewSheet17.Range["L2", "L2"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            //xlNewSheet17.Range["M2", "M2"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            //xlNewSheet17.Range["N2", "N2"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            //xlNewSheet17.Range["O2", "O2"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            //xlNewSheet17.Range["P2", "P2"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            //xlNewSheet17.Range["Q2", "Q2"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            //xlNewSheet17.Range["R2", "R2"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            //xlNewSheet17.Range["S2", "S2"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;

                            xlNewSheet18.Range["A" + j, "A" + j].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet18.Range["B" + j, "B" + j].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet18.Range["C" + j, "C" + j].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet18.Range["D" + j, "D" + j].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet18.Range["E" + j, "E" + j].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet18.Range["F" + j, "F" + j].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet18.Range["G" + j, "G" + j].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet18.Range["H" + j, "H" + j].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet18.Range["I" + j, "I" + j].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlNewSheet18.Range["J" + j, "J" + j].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;

                            //xlNewSheet18.Range["A2", "A2"].Font.Bold = true;
                            //xlNewSheet18.Range["C2", "C2" ].Font.Bold = true;
                            //xlNewSheet18.Range["E2", "E2"].Font.Bold = true;
                            //xlNewSheet18.Range["G2", "G2"].Font.Bold = true;
                            //xlNewSheet18.Range["H2", "H2" ].Font.Bold = true;
                            //xlNewSheet18.Range["J2", "J2"].Font.Bold = true;

                            xlNewSheet18.Range["A" + j, "A" + j].Font.Bold = true;
                            xlNewSheet18.Range["C" + j, "C" + j].Font.Bold = true;
                            xlNewSheet18.Range["E" + j, "E" + j].Font.Bold = true;
                            xlNewSheet18.Range["G" + j, "G" + j].Font.Bold = true;
                            xlNewSheet18.Range["H" + j, "H" + j].Font.Bold = true;
                            xlNewSheet18.Range["J" + j, "J" + j].Font.Bold = true;


                            //xlNewSheet18.Range["A2" , "A2"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            //xlNewSheet18.Range["B2" , "B2"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            //xlNewSheet18.Range["C2", "C2"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            //xlNewSheet18.Range["D2" , "D2"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            //xlNewSheet18.Range["E2", "E2"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            //xlNewSheet18.Range["F2" , "F2"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            //xlNewSheet18.Range["G2", "G2"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            //xlNewSheet18.Range["H2" , "H2"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            //xlNewSheet18.Range["I2", "I2"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            //xlNewSheet18.Range["J2" , "J2"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            //xlNewSheet18.Range["K2" , "K2"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            //xlNewSheet18.Range["L2", "L2"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            //xlNewSheet18.Range["M2" , "M2"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;

                            j = j + 1;



                            //xlNewSheet17.Cells[i + 1, 20] = (dr["Unit"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["Unit"]);
                            i++;

                        }
                        xlNewSheet18.Columns.AutoFit();
                        xlNewSheet18.Range["A1", "J1"].Interior.Color = ColorTranslator.ToOle((Color)cc.ConvertFromString("#0070c0"));
                        //xlNewSheet18.Range["A2", "S2"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.LightSteelBlue);
                        xlNewSheet18.Range["A1", "J1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                        xlNewSheet18.Range["A1", "J1"].Font.Bold = true;
                        //xlNewSheet18.Range["A2", "S2"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                        //xlNewSheet18.Range["A2", "S2"].Font.Bold = true;

                        releaseObject(xlNewSheet18);

                    }
                }
                if (ReportType == "InHouseFabricWIP")
                {
                    //iKandi.Common.Constants.WorkSheetCount_ForExcel = iKandi.Common.Constants.WorkSheetCount_ForExcel + 1;
                    GlobalCount_Fabric_Wip = GlobalCount_Fabric_Wip + 1;
                    float IsumFabricMeterage = 0;
                    float IsSumFabricCost = 0;
                    float IsumFabric2Meterage = 0;
                    float IsSumFabric2Cost = 0;
                    float IsumFabric3Meterage = 0;
                    float IsSumFabric3Cost = 0;
                    float IsumFabric4Meterage = 0;
                    float IsSumFabric4Cost = 0;
                    float TotalPCSCut = 0;
                    var xlNewSheet8 = (Excel.Worksheet)worksheets.Add(worksheets[GlobalCount_Fabric_Wip], Type.Missing, Type.Missing, Type.Missing);
                    xlNewSheet8.Name = "Fabric Issued WIP";
                    xlNewSheet8.Cells[1, 1] = "StyleNumber";
                    xlNewSheet8.Cells[1, 2] = "SerialNumber";
                    xlNewSheet8.Cells[1, 3] = "Quantity(Pcs)";
                    xlNewSheet8.Cells[1, 4] = "LineItemNumber";
                    xlNewSheet8.Cells[1, 5] = "Fabric1 Metrage (Mtr.)";
                    xlNewSheet8.Cells[1, 6] = "Fab1Cost";
                    xlNewSheet8.Cells[1, 7] = "Fabric2 Meterage (Mtr.)";
                    xlNewSheet8.Cells[1, 8] = "Fab2Cost";
                    xlNewSheet8.Cells[1, 9] = "Fabric3 Meterage";
                    xlNewSheet8.Cells[1, 10] = "Fab3Cost";
                    xlNewSheet8.Cells[1, 11] = "Fabric4 Meterage (Mtr.)";
                    xlNewSheet8.Cells[1, 12] = "Fab4Cost";
                    xlNewSheet8.Cells[1, 13] = "TotalPcsCut";


                    if (ds.Tables[0].Rows.Count == 0)
                    {
                        return false;
                    }
                    else if (ds.Tables[0].Rows.Count > 0)
                    {
                        int O = 1;
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {



                            xlNewSheet8.Cells[O + 1, 1] = dr["StyleNumber"] == DBNull.Value ? string.Empty : Convert.ToString(dr["StyleNumber"]);
                            xlNewSheet8.Cells[O + 1, 2] = dr["SerialNumber"] == DBNull.Value ? string.Empty : Convert.ToString(dr["SerialNumber"]);
                            xlNewSheet8.Cells[O + 1, 3] = dr["Quantity"] == DBNull.Value ? string.Empty : Convert.ToString(Convert.ToInt32(dr["Quantity"]).ToString("N0"));
                            xlNewSheet8.Cells[O + 1, 4] = dr["LineItemNumber"] == DBNull.Value ? string.Empty : Convert.ToString(dr["LineItemNumber"]);
                            xlNewSheet8.Cells[O + 1, 5] = Convert.ToString(dr["TotalFab1pendingMeterage"]) == "0" ? string.Empty : Convert.ToString(Convert.ToInt32(dr["TotalFab1pendingMeterage"]).ToString("N0"));
                            IsumFabricMeterage = IsumFabricMeterage + Convert.ToInt32(dr["TotalFab1pendingMeterage"]);

                            xlNewSheet8.Cells[O + 1, 6] = Convert.ToString(dr["TotalFab1Cost"]) == "0" ? string.Empty : Convert.ToString(Convert.ToInt32(dr["TotalFab1Cost"]));
                            IsSumFabricCost = IsSumFabricCost + Convert.ToInt32(dr["TotalFab1Cost"]);
                            xlNewSheet8.Cells[O + 1, 7] = Convert.ToString(dr["TotalFab2pendingMeterage"]) == "0" ? string.Empty : Convert.ToString(Convert.ToInt32(dr["TotalFab2pendingMeterage"]).ToString("N0"));
                            IsumFabric2Meterage = IsumFabric2Meterage + Convert.ToInt32(dr["TotalFab2pendingMeterage"]);
                            xlNewSheet8.Cells[O + 1, 8] = Convert.ToString(dr["TotalFab2Cost"]) == "0" ? string.Empty : Convert.ToString(Convert.ToInt32(dr["TotalFab2Cost"]));
                            IsSumFabric2Cost = IsSumFabric2Cost + Convert.ToInt32(dr["TotalFab2Cost"]);
                            xlNewSheet8.Cells[O + 1, 9] = Convert.ToString(dr["TotalFab3pendingMeterage"]) == "0" ? string.Empty : Convert.ToString(Convert.ToInt32(dr["TotalFab3pendingMeterage"]).ToString("N0"));
                            IsumFabric3Meterage = IsumFabric3Meterage + Convert.ToInt32(dr["TotalFab3pendingMeterage"]);
                            xlNewSheet8.Cells[O + 1, 10] = Convert.ToString(dr["TotalFab3Cost"]) == "0" ? string.Empty : Convert.ToString(Convert.ToInt32(dr["TotalFab3Cost"]));
                            IsSumFabric3Cost = IsSumFabric3Cost + Convert.ToInt32(dr["TotalFab3Cost"]);
                            xlNewSheet8.Cells[O + 1, 11] = Convert.ToString(dr["TotalFab4pendingMeterage"]) == "0" ? string.Empty : Convert.ToString(Convert.ToInt32(dr["TotalFab4pendingMeterage"]).ToString("N0"));
                            IsumFabric4Meterage = IsumFabric4Meterage + Convert.ToInt32(dr["TotalFab4pendingMeterage"]);
                            xlNewSheet8.Cells[O + 1, 12] = Convert.ToString(dr["TotalFab4Cost"]) == "0" ? string.Empty : Convert.ToString(Convert.ToInt32(dr["TotalFab4Cost"]));
                            IsSumFabric4Cost = IsSumFabric4Cost + Convert.ToInt32(dr["TotalFab4Cost"]);
                            xlNewSheet8.Cells[O + 1, 13] = Convert.ToString(dr["TotalPcsCut"]) == "0" ? string.Empty : Convert.ToString(Convert.ToInt32(dr["TotalPcsCut"]).ToString("N0"));
                            TotalPCSCut = TotalPCSCut + Convert.ToInt32(dr["TotalPcsCut"]);




                            O++;
                            //xlNewSheet8.Range["E" + O, "E" + O].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Gray);
                            //xlNewSheet8.Range["G" + O, "G" + O].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Gray);
                            //xlNewSheet8.Range["I" + O, "I" + O].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Gray);
                            //xlNewSheet8.Range["K" + O, "K" + O].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Gray);
                            //xlNewSheet8.Range["F" + O, "F" + O].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.LightSlateGray);
                            //xlNewSheet8.Range["H" + O, "H" + O].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.LightSlateGray);
                            //xlNewSheet8.Range["J" + O, "J" + O].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.LightSlateGray);
                            //xlNewSheet8.Range["L" + O, "L" + O].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.LightSlateGray);
                        }
                        int J = O + 1;
                        xlNewSheet8.Cells[O + 1, 4] = "Total";
                        xlNewSheet8.Cells[O + 1, 5] = Convert.ToString(Math.Round(IsumFabricMeterage, 0)) == "0" ? string.Empty : Convert.ToString(Convert.ToInt32(Math.Round(IsumFabricMeterage, 0)).ToString("N0"));

                        xlNewSheet8.Cells[O + 1, 6] = Convert.ToString(Math.Round(IsSumFabricCost, 0)) == "0" ? string.Empty : Convert.ToString(Convert.ToInt32(Math.Round(IsSumFabricCost, 0)).ToString("N0"));

                        xlNewSheet8.Cells[O + 1, 7] = Convert.ToString(Math.Round(IsumFabric2Meterage, 0)) == "0" ? string.Empty : Convert.ToString(Convert.ToInt32(Math.Round(IsumFabric2Meterage, 0)).ToString("N0"));
                        xlNewSheet8.Cells[O + 1, 8] = Convert.ToString(Math.Round(IsSumFabric2Cost, 0)) == "0" ? string.Empty : Convert.ToString(Convert.ToInt32(Math.Round(IsSumFabric2Cost, 0)).ToString("N0"));
                        xlNewSheet8.Cells[O + 1, 9] = Convert.ToString(Math.Round(IsumFabric3Meterage, 0)) == "0" ? string.Empty : Convert.ToString(Convert.ToInt32(Math.Round(IsumFabric3Meterage, 0)).ToString("N0"));
                        xlNewSheet8.Cells[O + 1, 10] = Convert.ToString(Math.Round(IsSumFabric3Cost, 0)) == "0" ? string.Empty : Convert.ToString(Convert.ToInt32(Math.Round(IsSumFabric3Cost, 0)).ToString("N0"));
                        xlNewSheet8.Cells[O + 1, 11] = Convert.ToString(Math.Round(IsumFabric4Meterage, 0)) == "0" ? string.Empty : Convert.ToString(Convert.ToInt32(Math.Round(IsumFabric4Meterage, 0)).ToString("N0"));
                        xlNewSheet8.Cells[O + 1, 12] = Convert.ToString(Math.Round(IsSumFabric4Cost, 0)) == "0" ? string.Empty : Convert.ToString(Convert.ToInt32(Math.Round(IsSumFabric4Cost, 0)).ToString("N0"));
                        xlNewSheet8.Cells[O + 1, 13] = Convert.ToString(Math.Round(TotalPCSCut, 0)) == "0" ? string.Empty : Convert.ToString(Convert.ToInt32(Math.Round(TotalPCSCut, 0)).ToString("N0"));
                        //xlNewSheet8.Range["D" + J, "D" + J].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.DarkGray);
                        //xlNewSheet8.Range["E" + J, "E" + J].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.DarkGray);
                        //xlNewSheet8.Range["F" + J, "F" + J].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.DarkGray);
                        //xlNewSheet8.Range["G" + J, "G" + J].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.DarkGray);
                        //xlNewSheet8.Range["H" + J, "H" + J].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.DarkGray);
                        //xlNewSheet8.Range["I" + J, "I" + J].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.DarkGray);
                        //xlNewSheet8.Range["J" + J, "J" + J].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.DarkGray);
                        //xlNewSheet8.Range["K" + J, "K" + J].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.DarkGray);
                        //xlNewSheet8.Range["L" + J, "L" + J].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.DarkGray);
                        //xlNewSheet8.Range["M" + J, "M" + J].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.DarkGray);

                        xlNewSheet8.Columns.AutoFit();
                        xlNewSheet8.Range["A1", "M1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        xlNewSheet8.Range["A1", "M1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                        //xlNewSheet8.Range["A1", "N1"].Font.Bold = true;
                        xlNewSheet8.Range["A1", "M1"].EntireColumn.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet8.Range["C1"].EntireColumn.Font.Bold = true;
                        xlNewSheet8.Range["C1"].Cells.Font.Bold = false;
                        xlNewSheet8.Range["C1"].Cells.ColumnWidth = 9;
                        xlNewSheet8.Range["A1", "M1"].EntireColumn.WrapText = true;
                        xlNewSheet8.Range["B1"].EntireColumn.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Blue);
                        xlNewSheet8.Range["B1"].Cells.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black);

                        xlNewSheet8.Range["B1"].EntireColumn.Font.Bold = true;
                        xlNewSheet8.Range["B1"].Cells.Font.Bold = false;
                        xlNewSheet8.Range["M1"].EntireColumn.Font.Bold = true;
                        xlNewSheet8.Range["M1"].Cells.Font.Bold = false;
                        xlNewSheet8.Range["F1"].Cells.EntireColumn.NumberFormat = "₹ 0,0";
                        xlNewSheet8.Range["H1"].Cells.EntireColumn.NumberFormat = "₹ 0,0";
                        xlNewSheet8.Range["J1"].Cells.EntireColumn.NumberFormat = "₹ 0,0";
                        xlNewSheet8.Range["L1"].Cells.EntireColumn.NumberFormat = "₹ 0,0";

                        ((Excel.Worksheet)xlApp.ActiveWorkbook.Sheets[1]).Activate();

                        //----------change date format with filter created by Surendra Sharma on 09-03-2018.----

                        //-------------End-----------------------------------------------------------------------

                        xlNewSheet8.get_Range("A1:M" + O).Cells.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                        xlNewSheet8.get_Range("D" + J).Cells.Font.Bold = true;
                        xlNewSheet8.get_Range("E" + J).Cells.Font.Bold = true;
                        xlNewSheet8.get_Range("F" + J).Cells.Font.Bold = true;
                        xlNewSheet8.get_Range("G" + J).Cells.Font.Bold = true;
                        xlNewSheet8.get_Range("H" + J).Cells.Font.Bold = true;
                        xlNewSheet8.get_Range("I" + J).Cells.Font.Bold = true;
                        xlNewSheet8.get_Range("J" + J).Cells.Font.Bold = true;
                        xlNewSheet8.get_Range("K" + J).Cells.Font.Bold = true;
                        xlNewSheet8.get_Range("L" + J).Cells.Font.Bold = true;
                        xlNewSheet8.get_Range("M" + J).Cells.Font.Bold = true;
                        releaseObject(xlNewSheet8);
                    }

                }
                if (ReportType == "CUT_StitchWIP")
                {
                    //iKandi.Common.Constants.WorkSheetCount_ForExcel = iKandi.Common.Constants.WorkSheetCount_ForExcel + 1;
                    GlobalCount_Fabric_Wip = GlobalCount_Fabric_Wip + 1;
                    float IsumCutPcsCost = 0;
                    float IsSumCutPcsCount = 0;


                    var xlNewSheet8 = (Excel.Worksheet)worksheets.Add(worksheets[GlobalCount_Fabric_Wip], Type.Missing, Type.Missing, Type.Missing);
                    xlNewSheet8.Name = "Cut WIP";
                    xlNewSheet8.Cells[1, 1] = "StyleNumber";
                    xlNewSheet8.Cells[1, 2] = "SerialNumber";
                    xlNewSheet8.Cells[1, 3] = "Quantity(Pcs)";
                    xlNewSheet8.Cells[1, 4] = "LineItemNumber";
                    xlNewSheet8.Cells[1, 5] = "Cut Pcs Cost Pndg to Stitch";
                    xlNewSheet8.Cells[1, 6] = "Cut Pcs count Pndg to Stitch ";



                    if (ds.Tables[0].Rows.Count == 0)
                    {
                        return false;
                    }
                    else if (ds.Tables[0].Rows.Count > 0)
                    {
                        int O = 1;
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {

                            xlNewSheet8.Cells[O + 1, 1] = dr["StyleNumber"] == DBNull.Value ? string.Empty : Convert.ToString(dr["StyleNumber"]);
                            xlNewSheet8.Cells[O + 1, 2] = dr["SerialNumber"] == DBNull.Value ? string.Empty : Convert.ToString(dr["SerialNumber"]);
                            xlNewSheet8.Cells[O + 1, 3] = dr["Quantity"] == DBNull.Value ? string.Empty : Convert.ToString(Convert.ToInt32(dr["Quantity"]).ToString("N0"));
                            xlNewSheet8.Cells[O + 1, 4] = dr["LineItemNumber"] == DBNull.Value ? string.Empty : Convert.ToString(dr["LineItemNumber"]);
                            xlNewSheet8.Cells[O + 1, 5] = Convert.ToString(dr["TotalPndgCutPcsCost"]) == "0" ? string.Empty : Convert.ToString(Convert.ToInt32(dr["TotalPndgCutPcsCost"]));
                            IsumCutPcsCost = IsumCutPcsCost + Convert.ToInt32(dr["TotalPndgCutPcsCost"]);
                            xlNewSheet8.Cells[O + 1, 6] = Convert.ToString(dr["CutQtyPendingTostitch"]) == "0" ? string.Empty : Convert.ToString(Convert.ToInt32(dr["CutQtyPendingTostitch"]).ToString("N0"));
                            IsSumCutPcsCount = IsSumCutPcsCount + Convert.ToInt32(dr["CutQtyPendingTostitch"]);

                            O++;
                        }
                        int X = O + 1;
                        xlNewSheet8.Cells[O + 1, 4] = "Total";
                        xlNewSheet8.Cells[O + 1, 5] = Convert.ToString(Math.Round(IsumCutPcsCost, 0)) == "0" ? string.Empty : Convert.ToString(Convert.ToInt32(Math.Round(IsumCutPcsCost, 0)).ToString("N0"));
                        xlNewSheet8.Cells[O + 1, 6] = Convert.ToString(Math.Round(IsSumCutPcsCount, 0)) == "0" ? string.Empty : Convert.ToString(Convert.ToInt32(Math.Round(IsSumCutPcsCount, 0)).ToString("N0"));
                        //xlNewSheet8.Range["D" + X, "D" + X].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.DarkGray);
                        //xlNewSheet8.Range["E" + X, "E" + X].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.DarkGray);
                        //xlNewSheet8.Range["F" + X, "F" + X].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.DarkGray);
                        xlNewSheet8.Columns.AutoFit();
                        xlNewSheet8.Range["A1", "F1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        xlNewSheet8.Range["A1", "F1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                        //xlNewSheet8.Range["A1", "N1"].Font.Bold = true;
                        xlNewSheet8.Range["A1", "F1"].EntireColumn.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet8.Range["C1"].EntireColumn.Font.Bold = true;
                        xlNewSheet8.Range["C1"].Cells.Font.Bold = false;
                        xlNewSheet8.Range["C1"].Cells.ColumnWidth = 9;
                        xlNewSheet8.Range["A1", "F1"].EntireColumn.WrapText = true;
                        xlNewSheet8.Range["B1"].EntireColumn.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Blue);
                        xlNewSheet8.Range["B1"].Cells.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black);

                        xlNewSheet8.Range["B1"].EntireColumn.Font.Bold = true;
                        xlNewSheet8.Range["B1"].Cells.Font.Bold = false;

                        xlNewSheet8.Range["E1"].Cells.EntireColumn.NumberFormat = "₹ 0,0";


                        xlNewSheet8.get_Range("A1:F" + O).Cells.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                        xlNewSheet8.get_Range("D" + X).Cells.Font.Bold = true;
                        xlNewSheet8.get_Range("E" + X).Cells.Font.Bold = true;
                        xlNewSheet8.get_Range("F" + X).Cells.Font.Bold = true;

                        releaseObject(xlNewSheet8);
                    }

                }

                if (ReportType == "Stitch_PackWIP")
                {
                    //iKandi.Common.Constants.WorkSheetCount_ForExcel = iKandi.Common.Constants.WorkSheetCount_ForExcel + 1;
                    GlobalCount_Fabric_Wip = GlobalCount_Fabric_Wip + 1;
                    float IsumStitchPcsCost = 0;
                    float IsSumStitchPcsCount = 0;

                    var xlNewSheet8 = (Excel.Worksheet)worksheets.Add(worksheets[GlobalCount_Fabric_Wip], Type.Missing, Type.Missing, Type.Missing);
                    xlNewSheet8.Name = "Stitch WIP";
                    xlNewSheet8.Cells[1, 1] = "StyleNumber";
                    xlNewSheet8.Cells[1, 2] = "SerialNumber";
                    xlNewSheet8.Cells[1, 3] = "Quantity(Pcs)";
                    xlNewSheet8.Cells[1, 4] = "LineItemNumber";
                    xlNewSheet8.Cells[1, 5] = "Stitch Pcs Cost Pndg to Pack";
                    xlNewSheet8.Cells[1, 6] = "Stitch Pcs count  Pndg to Pack";



                    if (ds.Tables[0].Rows.Count == 0)
                    {
                        return false;
                    }
                    else if (ds.Tables[0].Rows.Count > 0)
                    {
                        int O = 1;
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {

                            xlNewSheet8.Cells[O + 1, 1] = dr["StyleNumber"] == DBNull.Value ? string.Empty : Convert.ToString(dr["StyleNumber"]);
                            xlNewSheet8.Cells[O + 1, 2] = dr["SerialNumber"] == DBNull.Value ? string.Empty : Convert.ToString(dr["SerialNumber"]);
                            xlNewSheet8.Cells[O + 1, 3] = dr["Quantity"] == DBNull.Value ? string.Empty : Convert.ToString(Convert.ToInt32(dr["Quantity"]).ToString("N0"));
                            xlNewSheet8.Cells[O + 1, 4] = dr["LineItemNumber"] == DBNull.Value ? string.Empty : Convert.ToString(dr["LineItemNumber"]);
                            xlNewSheet8.Cells[O + 1, 5] = Convert.ToString(dr["TotalPndgStitchPcsCost"]) == "0" ? string.Empty : Convert.ToString(Convert.ToInt32(dr["TotalPndgStitchPcsCost"]));
                            IsumStitchPcsCost = IsumStitchPcsCost + Convert.ToInt32(dr["TotalPndgStitchPcsCost"]);
                            xlNewSheet8.Cells[O + 1, 6] = Convert.ToString(dr["StitchQtyPendingToPack"]) == "0" ? string.Empty : Convert.ToString(Convert.ToInt32(dr["StitchQtyPendingToPack"]).ToString("N0"));
                            IsSumStitchPcsCount = IsSumStitchPcsCount + Convert.ToInt32(dr["StitchQtyPendingToPack"]);
                            O++;
                        }
                        int Y = O + 1;
                        xlNewSheet8.Cells[O + 1, 4] = "Total";
                        xlNewSheet8.Cells[O + 1, 5] = Convert.ToString(Math.Round(IsumStitchPcsCost, 0)) == "0" ? string.Empty : Convert.ToString(Convert.ToInt32(Math.Round(IsumStitchPcsCost, 0)).ToString("N0"));
                        xlNewSheet8.Cells[O + 1, 6] = Convert.ToString(Math.Round(IsSumStitchPcsCount, 0)) == "0" ? string.Empty : Convert.ToString(Convert.ToInt32(Math.Round(IsSumStitchPcsCount, 0)).ToString("N0"));

                        //xlNewSheet8.Range["D" + Y, "D" + Y].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.DarkGray);
                        //xlNewSheet8.Range["E" + Y, "E" + Y].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.DarkGray);
                        //xlNewSheet8.Range["F" + Y, "F" + Y].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.DarkGray);


                        xlNewSheet8.Columns.AutoFit();
                        xlNewSheet8.Range["A1", "F1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        xlNewSheet8.Range["A1", "F1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                        //xlNewSheet8.Range["A1", "N1"].Font.Bold = true;
                        xlNewSheet8.Range["A1", "F1"].EntireColumn.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet8.Range["C1"].EntireColumn.Font.Bold = true;
                        xlNewSheet8.Range["C1"].Cells.Font.Bold = false;
                        xlNewSheet8.Range["C1"].Cells.ColumnWidth = 9;
                        xlNewSheet8.Range["A1", "F1"].EntireColumn.WrapText = true;
                        xlNewSheet8.Range["B1"].EntireColumn.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Blue);
                        xlNewSheet8.Range["B1"].Cells.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black);

                        xlNewSheet8.Range["B1"].EntireColumn.Font.Bold = true;
                        xlNewSheet8.Range["B1"].Cells.Font.Bold = false;

                        xlNewSheet8.Range["E1"].Cells.EntireColumn.NumberFormat = "₹ 0,0";


                        xlNewSheet8.get_Range("A1:F" + O).Cells.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                        xlNewSheet8.get_Range("D" + Y).Cells.Font.Bold = true;
                        xlNewSheet8.get_Range("E" + Y).Cells.Font.Bold = true;
                        xlNewSheet8.get_Range("F" + Y).Cells.Font.Bold = true;
                        releaseObject(xlNewSheet8);
                    }

                }
                if (ReportType == "Pack_ShipWIP")
                {
                    //iKandi.Common.Constants.WorkSheetCount_ForExcel = iKandi.Common.Constants.WorkSheetCount_ForExcel + 1;
                    GlobalCount_Fabric_Wip = GlobalCount_Fabric_Wip + 1;
                    float IsumPackPcsCost = 0;
                    float IsSumPackPcsCount = 0;
                    var xlNewSheet8 = (Excel.Worksheet)worksheets.Add(worksheets[GlobalCount_Fabric_Wip], Type.Missing, Type.Missing, Type.Missing);
                    xlNewSheet8.Name = "Pack WIP";
                    xlNewSheet8.Cells[1, 1] = "StyleNumber";
                    xlNewSheet8.Cells[1, 2] = "SerialNumber";
                    xlNewSheet8.Cells[1, 3] = "Quantity(Pcs)";
                    xlNewSheet8.Cells[1, 4] = "LineItemNumber";
                    xlNewSheet8.Cells[1, 5] = "Pack Pcs Cost Pndg to Ship";
                    xlNewSheet8.Cells[1, 6] = "Pack Pcs count Pndg to Ship";



                    if (ds.Tables[0].Rows.Count == 0)
                    {
                        return false;
                    }
                    else if (ds.Tables[0].Rows.Count > 0)
                    {
                        int O = 1;
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {

                            xlNewSheet8.Cells[O + 1, 1] = dr["StyleNumber"] == DBNull.Value ? string.Empty : Convert.ToString(dr["StyleNumber"]);
                            xlNewSheet8.Cells[O + 1, 2] = dr["SerialNumber"] == DBNull.Value ? string.Empty : Convert.ToString(dr["SerialNumber"]);
                            xlNewSheet8.Cells[O + 1, 3] = dr["Quantity"] == DBNull.Value ? string.Empty : Convert.ToString(Convert.ToInt32(dr["Quantity"]).ToString("N0"));
                            xlNewSheet8.Cells[O + 1, 4] = dr["LineItemNumber"] == DBNull.Value ? string.Empty : Convert.ToString(dr["LineItemNumber"]);
                            xlNewSheet8.Cells[O + 1, 5] = Convert.ToString(dr["TotalPndgStitchPcsCost"]) == "0" ? string.Empty : Convert.ToString(Convert.ToInt32(dr["TotalPndgStitchPcsCost"]));
                            IsumPackPcsCost = IsumPackPcsCost + Convert.ToInt32(dr["TotalPndgStitchPcsCost"]);
                            xlNewSheet8.Cells[O + 1, 6] = Convert.ToString(dr["PackQtyPendingToShip"]) == "0" ? string.Empty : Convert.ToString(Convert.ToInt32(dr["PackQtyPendingToShip"]).ToString("N0"));
                            IsSumPackPcsCount = IsSumPackPcsCount + Convert.ToInt32(dr["PackQtyPendingToShip"]);

                            O++;
                        }
                        int Z = O + 1;
                        xlNewSheet8.Cells[O + 1, 4] = "Total";
                        xlNewSheet8.Cells[O + 1, 5] = Convert.ToString(Math.Round(IsumPackPcsCost, 0)) == "0" ? string.Empty : Convert.ToString(Convert.ToInt32(Math.Round(IsumPackPcsCost, 0)).ToString("N0"));
                        xlNewSheet8.Cells[O + 1, 6] = Convert.ToString(Math.Round(IsSumPackPcsCount, 0)) == "0" ? string.Empty : Convert.ToString(Convert.ToInt32(Math.Round(IsSumPackPcsCount, 0)).ToString("N0"));
                        //xlNewSheet8.Range["D" + Z, "D" + Z].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.DarkGray);
                        //xlNewSheet8.Range["E" + Z, "E" + Z].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.DarkGray);
                        //xlNewSheet8.Range["F" + Z, "F" + Z].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.DarkGray);
                        xlNewSheet8.Columns.AutoFit();
                        xlNewSheet8.Range["A1", "F1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        xlNewSheet8.Range["A1", "F1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                        //xlNewSheet8.Range["A1", "N1"].Font.Bold = true;
                        xlNewSheet8.Range["A1", "F1"].EntireColumn.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet8.Range["C1"].EntireColumn.Font.Bold = true;
                        xlNewSheet8.Range["C1"].Cells.Font.Bold = false;
                        xlNewSheet8.Range["C1"].Cells.ColumnWidth = 9;
                        xlNewSheet8.Range["A1", "F1"].EntireColumn.WrapText = true;
                        xlNewSheet8.Range["B1"].EntireColumn.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Blue);
                        xlNewSheet8.Range["B1"].Cells.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black);

                        xlNewSheet8.Range["B1"].EntireColumn.Font.Bold = true;
                        xlNewSheet8.Range["B1"].Cells.Font.Bold = false;



                        xlNewSheet8.Range["E1"].Cells.EntireColumn.NumberFormat = "₹ 0,0";


                        xlNewSheet8.get_Range("A1:F" + O).Cells.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                        xlNewSheet8.get_Range("D" + Z).Cells.Font.Bold = true;
                        xlNewSheet8.get_Range("E" + Z).Cells.Font.Bold = true;
                        xlNewSheet8.get_Range("F" + Z).Cells.Font.Bold = true;
                        releaseObject(xlNewSheet8);
                    }

                }

                if (ReportType == "AMPerformance_STC")
                {
                    //iKandi.Common.Constants.WorkSheetCount_ForExcel = iKandi.Common.Constants.WorkSheetCount_ForExcel + 1;
                    GlobalCount_AM = GlobalCount_AM + 1;

                    var xlNewSheet8 = (Excel.Worksheet)worksheets.Add(worksheets[GlobalCount_AM], Type.Missing, Type.Missing, Type.Missing);
                    xlNewSheet8.Name = "AM_Seal";
                    xlNewSheet8.Cells[1, 1] = "Order Date";
                    xlNewSheet8.Cells[1, 2] = "Serial Number";
                    xlNewSheet8.Cells[1, 3] = "Style Number";
                    xlNewSheet8.Cells[1, 4] = "Contract Number";
                    xlNewSheet8.Cells[1, 5] = "Line Item Number";
                    xlNewSheet8.Cells[1, 6] = "STC Tgt";
                    xlNewSheet8.Cells[1, 7] = "STC Act";
                    xlNewSheet8.Cells[1, 8] = "Avg ETA Weeks";
                    xlNewSheet8.Cells[1, 9] = "Avg Actual Weeks";
                    xlNewSheet8.Cells[1, 10] = "Delay STC/PP Sample(in WK)";
                    xlNewSheet8.Cells[1, 11] = "Ex-Factory Date";
                    xlNewSheet8.Cells[1, 12] = "AM";


                    if (ds.Tables[0].Rows.Count == 0)
                    {
                        return false;
                    }
                    else if (ds.Tables[0].Rows.Count > 0)
                    {
                        int O = 1;
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {


                            int y = 0;
                            xlNewSheet8.Cells[O + 1, 1] = dr["OrderDate"] == DBNull.Value ? string.Empty : Convert.ToString(dr["OrderDate"]);
                            xlNewSheet8.Cells[O + 1, 2] = dr["SerialNumber"] == DBNull.Value ? string.Empty : Convert.ToString(dr["SerialNumber"]);
                            xlNewSheet8.Cells[O + 1, 3] = dr["StyleNumber"] == DBNull.Value ? string.Empty : Convert.ToString(dr["StyleNumber"]);
                            xlNewSheet8.Cells[O + 1, 4] = dr["ContractNumber"] == DBNull.Value ? string.Empty : Convert.ToString(dr["ContractNumber"]);
                            xlNewSheet8.Cells[O + 1, 5] = dr["LineItemNumber"] == DBNull.Value ? string.Empty : Convert.ToString(dr["LineItemNumber"]);
                            xlNewSheet8.Cells[O + 1, 6] = Convert.ToString(dr["STCEta"]) == "0" ? string.Empty : dr["STCEta"];
                            xlNewSheet8.Cells[O + 1, 7] = Convert.ToString(dr["STCActionDate"]) == "0" ? string.Empty : dr["STCActionDate"];

                            xlNewSheet8.Cells[O + 1, 8] = Convert.ToString(dr["AvgExWeek"]) == "0" ? string.Empty : dr["AvgExWeek"];
                            xlNewSheet8.Cells[O + 1, 9] = Convert.ToString(dr["AvgActual_ExWeek"]) == "0" ? string.Empty : dr["AvgActual_ExWeek"];

                            xlNewSheet8.Cells[O + 1, 10] = Convert.ToString(dr["STC Delay"]) == "0" ? string.Empty : dr["STC Delay"];

                            y = O + 1;
                            int STC_Delay = Convert.ToInt32(dr["STC Delay"]);
                            if (STC_Delay > 0)
                                xlNewSheet8.Range["J" + y, "J" + y].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Red);
                            else
                                xlNewSheet8.Range["J" + y, "J" + y].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Green);
                            xlNewSheet8.Range["J" + y, "J" + y].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                            xlNewSheet8.Cells[O + 1, 11] = Convert.ToString(dr["ExFactory"]) == "0" ? string.Empty : dr["ExFactory"];
                            xlNewSheet8.Cells[O + 1, 12] = Convert.ToString(dr["AM"]) == "0" ? string.Empty : dr["AM"];
                            O++;

                        }



                        xlNewSheet8.Columns.AutoFit();
                        xlNewSheet8.Range["A1", "L1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        xlNewSheet8.Range["A1", "L1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                        //xlNewSheet8.Range["A1", "N1"].Font.Bold = true;
                        xlNewSheet8.Range["A1", "L1"].EntireColumn.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        //xlNewSheet8.Range["C1"].EntireColumn.Font.Bold = true;
                        //xlNewSheet8.Range["C1"].Cells.Font.Bold = false;
                        //xlNewSheet8.Range["C1"].Cells.ColumnWidth = 9;
                        xlNewSheet8.Range["A1", "L1"].EntireColumn.WrapText = true;
                        xlNewSheet8.Range["B1"].EntireColumn.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Blue);
                        xlNewSheet8.Range["B1"].Cells.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black);

                        xlNewSheet8.Range["B1"].EntireColumn.Font.Bold = true;
                        xlNewSheet8.Range["B1"].Cells.Font.Bold = false;
                        xlNewSheet8.Range["L1"].EntireColumn.Font.Bold = true;
                        xlNewSheet8.Range["L1"].Cells.Font.Bold = false;
                        xlNewSheet8.get_Range("A1:L" + O).Cells.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                        xlNewSheet8.Range["A1"].Cells.EntireColumn.NumberFormat = "dd mmm (ddd);@";
                        xlNewSheet8.Range["F1"].Cells.EntireColumn.NumberFormat = "dd mmm (ddd);@";
                        xlNewSheet8.Range["G1"].Cells.EntireColumn.NumberFormat = "dd mmm (ddd);@";
                        xlNewSheet8.Range["K1"].Cells.EntireColumn.NumberFormat = "dd mmm (ddd);@";


                        ((Excel.Worksheet)xlApp.ActiveWorkbook.Sheets[1]).Activate();

                        //----------change date format with filter created by Surendra Sharma on 09-03-2018.----

                        //-------------End-----------------------------------------------------------------------


                        releaseObject(xlNewSheet8);
                    }


                }
                if (ReportType == "AMPerformance_BIH")
                {
                    //iKandi.Common.Constants.WorkSheetCount_ForExcel = iKandi.Common.Constants.WorkSheetCount_ForExcel + 1;
                    GlobalCount_AM = GlobalCount_AM + 1;

                    var xlNewSheet8 = (Excel.Worksheet)worksheets.Add(worksheets[GlobalCount_AM], Type.Missing, Type.Missing, Type.Missing);
                    xlNewSheet8.Name = "AM_BIH";
                    xlNewSheet8.Cells[1, 1] = "Order Date";
                    xlNewSheet8.Cells[1, 2] = "Serial Number";
                    xlNewSheet8.Cells[1, 3] = "Style Number";
                    xlNewSheet8.Cells[1, 4] = "Contract Number";
                    xlNewSheet8.Cells[1, 5] = "Line Item Number";
                    xlNewSheet8.Cells[1, 6] = "BIH Tgt";
                    xlNewSheet8.Cells[1, 7] = "First Fabric BIH Act";
                    xlNewSheet8.Cells[1, 8] = "Avg ETA Weeks";
                    xlNewSheet8.Cells[1, 9] = "Avg Actual Weeks";
                    xlNewSheet8.Cells[1, 10] = "Delay Fabric(in WK)";
                    xlNewSheet8.Cells[1, 11] = "Ex-Factory Date";
                    xlNewSheet8.Cells[1, 12] = "AM";


                    if (ds.Tables[0].Rows.Count == 0)
                    {
                        return false;
                    }
                    else if (ds.Tables[0].Rows.Count > 0)
                    {

                        int O = 1;
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {

                            int y = 0;

                            xlNewSheet8.Cells[O + 1, 1] = dr["OrderDate"] == DBNull.Value ? string.Empty : Convert.ToString(dr["OrderDate"]);
                            xlNewSheet8.Cells[O + 1, 2] = dr["SerialNumber"] == DBNull.Value ? string.Empty : Convert.ToString(dr["SerialNumber"]);
                            xlNewSheet8.Cells[O + 1, 3] = dr["StyleNumber"] == DBNull.Value ? string.Empty : Convert.ToString(dr["StyleNumber"]);
                            xlNewSheet8.Cells[O + 1, 4] = dr["ContractNumber"] == DBNull.Value ? string.Empty : Convert.ToString(dr["ContractNumber"]);
                            xlNewSheet8.Cells[O + 1, 5] = dr["LineItemNumber"] == DBNull.Value ? string.Empty : Convert.ToString(dr["LineItemNumber"]);
                            xlNewSheet8.Cells[O + 1, 6] = Convert.ToString(dr["BIHTgtDate"]) == "0" ? string.Empty : dr["BIHTgtDate"];
                            xlNewSheet8.Cells[O + 1, 7] = Convert.ToString(dr["FirstFabricBIHActual"]) == "0" ? string.Empty : dr["FirstFabricBIHActual"];
                            xlNewSheet8.Cells[O + 1, 8] = Convert.ToString(dr["AvgExWeek"]) == "0" ? string.Empty : dr["AvgExWeek"];
                            xlNewSheet8.Cells[O + 1, 9] = Convert.ToString(dr["AvgActual_ExWeek"]) == "0" ? string.Empty : dr["AvgActual_ExWeek"];
                            xlNewSheet8.Cells[O + 1, 10] = Convert.ToString(dr["Fabric Delay"]) == "0" ? string.Empty : dr["Fabric Delay"];
                            y = O + 1;
                            int Fabric_Delay = Convert.ToInt32(dr["Fabric Delay"]);
                            if (Fabric_Delay > 0)
                                xlNewSheet8.Range["J" + y, "J" + y].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Red);
                            else
                                xlNewSheet8.Range["J" + y, "J" + y].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Green);

                            xlNewSheet8.Range["J" + y, "J" + y].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                            xlNewSheet8.Cells[O + 1, 11] = Convert.ToString(dr["ExFactory"]) == "0" ? string.Empty : dr["ExFactory"];
                            xlNewSheet8.Cells[O + 1, 12] = Convert.ToString(dr["AM"]) == "0" ? string.Empty : dr["AM"];
                            O++;


                        }



                        xlNewSheet8.Columns.AutoFit();
                        xlNewSheet8.Range["A1", "L1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        xlNewSheet8.Range["A1", "L1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                        //xlNewSheet8.Range["A1", "N1"].Font.Bold = true;
                        xlNewSheet8.Range["A1", "L1"].EntireColumn.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        //xlNewSheet8.Range["C1"].EntireColumn.Font.Bold = true;
                        //xlNewSheet8.Range["C1"].Cells.Font.Bold = false;
                        //xlNewSheet8.Range["C1"].Cells.ColumnWidth = 9;
                        xlNewSheet8.Range["A1", "L1"].EntireColumn.WrapText = true;
                        xlNewSheet8.Range["B1"].EntireColumn.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Blue);
                        xlNewSheet8.Range["B1"].Cells.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black);

                        xlNewSheet8.Range["B1"].EntireColumn.Font.Bold = true;
                        xlNewSheet8.Range["B1"].Cells.Font.Bold = false;
                        xlNewSheet8.Range["L1"].EntireColumn.Font.Bold = true;
                        xlNewSheet8.Range["L1"].Cells.Font.Bold = false;
                        xlNewSheet8.get_Range("A1:L" + O).Cells.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                        xlNewSheet8.Range["A1"].Cells.EntireColumn.NumberFormat = "dd mmm (ddd);@";
                        xlNewSheet8.Range["F1"].Cells.EntireColumn.NumberFormat = "dd mmm (ddd);@";
                        xlNewSheet8.Range["G1"].Cells.EntireColumn.NumberFormat = "dd mmm (ddd);@";
                        xlNewSheet8.Range["K1"].Cells.EntireColumn.NumberFormat = "dd mmm (ddd);@";



                        //----------change date format with filter created by Surendra Sharma on 09-03-2018.----

                        //-------------End-----------------------------------------------------------------------


                        releaseObject(xlNewSheet8);
                    }


                }


                //---------Code Added By Bharat----------------------------------

                if (ReportType == "AMPerformance_Acc_BIH")
                {
                    //iKandi.Common.Constants.WorkSheetCount_ForExcel = iKandi.Common.Constants.WorkSheetCount_ForExcel + 1;
                    GlobalCount_AM = GlobalCount_AM + 1;

                    var xlNewSheet8 = (Excel.Worksheet)worksheets.Add(worksheets[GlobalCount_AM], Type.Missing, Type.Missing, Type.Missing);
                    xlNewSheet8.Name = "AM_Acc_BIH";
                    xlNewSheet8.Cells[1, 1] = "Order Date";
                    xlNewSheet8.Cells[1, 2] = "Serial Number";
                    xlNewSheet8.Cells[1, 3] = "Style Number";
                    xlNewSheet8.Cells[1, 4] = "Contract Number";
                    xlNewSheet8.Cells[1, 5] = "Line Item Number";
                    xlNewSheet8.Cells[1, 6] = "BIH Tgt";
                    xlNewSheet8.Cells[1, 7] = "Acc. BIH Act";
                    xlNewSheet8.Cells[1, 8] = "Avg ETA Weeks";
                    xlNewSheet8.Cells[1, 9] = "Avg Actual Weeks";
                    xlNewSheet8.Cells[1, 10] = "Delay Acc. (in WK)";
                    xlNewSheet8.Cells[1, 11] = "Ex-Factory Date";
                    xlNewSheet8.Cells[1, 12] = "AM";


                    if (ds.Tables[0].Rows.Count == 0)
                    {
                        return false;
                    }
                    else if (ds.Tables[0].Rows.Count > 0)
                    {

                        int O = 1;
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {

                            int y = 0;

                            xlNewSheet8.Cells[O + 1, 1] = dr["OrderDate"] == DBNull.Value ? string.Empty : Convert.ToString(dr["OrderDate"]);
                            xlNewSheet8.Cells[O + 1, 2] = dr["SerialNumber"] == DBNull.Value ? string.Empty : Convert.ToString(dr["SerialNumber"]);
                            xlNewSheet8.Cells[O + 1, 3] = dr["StyleNumber"] == DBNull.Value ? string.Empty : Convert.ToString(dr["StyleNumber"]);
                            xlNewSheet8.Cells[O + 1, 4] = dr["ContractNumber"] == DBNull.Value ? string.Empty : Convert.ToString(dr["ContractNumber"]);
                            xlNewSheet8.Cells[O + 1, 5] = dr["LineItemNumber"] == DBNull.Value ? string.Empty : Convert.ToString(dr["LineItemNumber"]);
                            xlNewSheet8.Cells[O + 1, 6] = Convert.ToString(dr["BIHTgtDate"]) == "0" ? string.Empty : dr["BIHTgtDate"];
                            xlNewSheet8.Cells[O + 1, 7] = Convert.ToString(dr["FirstFabricBIHActual"]) == "0" ? string.Empty : dr["FirstFabricBIHActual"];
                            xlNewSheet8.Cells[O + 1, 8] = Convert.ToString(dr["AvgExWeek"]) == "0" ? string.Empty : dr["AvgExWeek"];
                            xlNewSheet8.Cells[O + 1, 9] = Convert.ToString(dr["AvgActual_ExWeek"]) == "0" ? string.Empty : dr["AvgActual_ExWeek"];
                            xlNewSheet8.Cells[O + 1, 10] = Convert.ToString(dr["Fabric Delay"]) == "0" ? string.Empty : dr["Fabric Delay"];
                            y = O + 1;
                            int Fabric_Delay = Convert.ToInt32(dr["Fabric Delay"]);
                            if (Fabric_Delay > 0)
                                xlNewSheet8.Range["J" + y, "J" + y].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Red);
                            else
                                xlNewSheet8.Range["J" + y, "J" + y].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Green);

                            xlNewSheet8.Range["J" + y, "J" + y].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                            xlNewSheet8.Cells[O + 1, 11] = Convert.ToString(dr["ExFactory"]) == "0" ? string.Empty : dr["ExFactory"];
                            xlNewSheet8.Cells[O + 1, 12] = Convert.ToString(dr["AM"]) == "0" ? string.Empty : dr["AM"];
                            O++;


                        }



                        xlNewSheet8.Columns.AutoFit();
                        xlNewSheet8.Range["A1", "L1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        xlNewSheet8.Range["A1", "L1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                        //xlNewSheet8.Range["A1", "N1"].Font.Bold = true;
                        xlNewSheet8.Range["A1", "L1"].EntireColumn.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        //xlNewSheet8.Range["C1"].EntireColumn.Font.Bold = true;
                        //xlNewSheet8.Range["C1"].Cells.Font.Bold = false;
                        //xlNewSheet8.Range["C1"].Cells.ColumnWidth = 9;
                        xlNewSheet8.Range["A1", "L1"].EntireColumn.WrapText = true;
                        xlNewSheet8.Range["B1"].EntireColumn.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Blue);
                        xlNewSheet8.Range["B1"].Cells.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black);

                        xlNewSheet8.Range["B1"].EntireColumn.Font.Bold = true;
                        xlNewSheet8.Range["B1"].Cells.Font.Bold = false;
                        xlNewSheet8.Range["L1"].EntireColumn.Font.Bold = true;
                        xlNewSheet8.Range["L1"].Cells.Font.Bold = false;
                        xlNewSheet8.get_Range("A1:L" + O).Cells.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                        xlNewSheet8.Range["A1"].Cells.EntireColumn.NumberFormat = "dd mmm (ddd);@";
                        xlNewSheet8.Range["F1"].Cells.EntireColumn.NumberFormat = "dd mmm (ddd);@";
                        xlNewSheet8.Range["G1"].Cells.EntireColumn.NumberFormat = "dd mmm (ddd);@";
                        xlNewSheet8.Range["K1"].Cells.EntireColumn.NumberFormat = "dd mmm (ddd);@";



                        //----------change date format with filter created by Surendra Sharma on 09-03-2018.----

                        //-------------End-----------------------------------------------------------------------


                        releaseObject(xlNewSheet8);
                    }

                    //end
                }

                //-----------------------------
                xlWorkBook.Save();
                xlWorkBook.Close();
                releaseObject(worksheets);
                releaseObject(xlWorkBook);
                releaseObject(xlApp);
                return true;

                //return genExcal.GenerateExcel();
            }
            else
            {
                return false;
            }

        }
        public string Get_Remarks(string sComment)
        {
            string finalCommentes = string.Empty;
            if (sComment != "")
            {
                string Comment = "";
                string[] ArrComment = sComment.Trim().Split('~');
                if (ArrComment.Length > 0)
                {
                    for (int i = 0; i < ArrComment.Length; i++)
                    {
                        Comment = Comment + ArrComment[i].Trim().ToString() + "</br>";
                    }
                    finalCommentes = Comment.ToString();
                }
            }
            finalCommentes = finalCommentes.Replace("</br>", Environment.NewLine);
            return finalCommentes;
        }

        private void releaseObject(object obj)
        {

            try
            {

                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);

                obj = null;

            }

            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                obj = null;

                //MessageBox.Show("Exception Occured while releasing object " + ex.ToString());

            }

            finally
            {

                GC.Collect();

            }

        }


        //end
        //Pending Payment Report abhishek 22 sep 17===============================//

        int pendingBankPaymentscount = 0;
        public List<PackingDelivery> GetBankPaymentReport(string SearchText, DateTime frm, DateTime to, int PaymentType, int pageIndex, int PageSize, out int recordCount)
        {
            return this.ReportDataProviderInstance.GetBankPaymentReport(SearchText, frm, to, PaymentType, pageIndex, PageSize, out recordCount);
        }
        public System.Data.DataTable GetSerialNumber(string Flag, string ShipmentNo)
        {
            return this.ReportDataProviderInstance.GetSerialNumber(Flag, ShipmentNo);
        }

        public int GetBankPaymentReportcounts(int startIndex, int pageSize, string SearchText)
        {
            return pendingBankPaymentscount;
        }
        public string[] getcomment(string str)
        {

            string[] Collection = str.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            //int i = 1;
            //foreach (string s in Collection)
            //{
            //  strcomment = strcomment + "(" + i + " :)" + s + "\r\n";
            //  i = i + 1;
            //}
            return Collection;
        }
        //end


        //new Work start :Girish
        #region Report generated for Material section
        public bool GenerateMaterialReportExcel(string ExcelFilePath, string ReportType, DataSet ds)
        {
            AdminController objadmin = new AdminController();

            if (ds.Tables[0].Rows.Count > 0)
            {
                Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
                xlApp.DisplayAlerts = false;
                Excel.Workbook xlWorkBook = xlApp.Workbooks.Open(ExcelFilePath, 0, false, 5, "", "", false, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "", true, false, 0, true, false, false);
                Excel.Sheets worksheets = xlWorkBook.Worksheets;

                #region ReportType :- Fabric_PO_Detail
                if (ReportType == "Fabric_PO_Detail")
                {
                    foreach (DataTable dt in ds.Tables)
                    {
                        if (dt.Rows.Count > 0)
                        {
                            string SupplyType = "";
                            GlobalCount_Fabric_Po_Details = GlobalCount_Fabric_Po_Details + 1;

                            var xlNewSheet8 = (Excel.Worksheet)worksheets.Add(worksheets[GlobalCount_Fabric_Po_Details], Type.Missing, Type.Missing, Type.Missing);

                            xlNewSheet8.Name = dt.Rows[0]["Po_Type"].ToString();

                            xlNewSheet8.Cells[1, 1] = "Fabric Quality";
                            xlNewSheet8.Cells[1, 2] = "Count Construction";
                            xlNewSheet8.Cells[1, 3] = "GSM";
                            xlNewSheet8.Cells[1, 4] = "Supplier Name";
                            xlNewSheet8.Cells[1, 5] = "PO Number";
                            xlNewSheet8.Cells[1, 6] = "PO Date";
                            xlNewSheet8.Cells[1, 7] = "ETA";
                            xlNewSheet8.Cells[1, 8] = "Rate";
                            xlNewSheet8.Cells[1, 9] = "Serial Number";
                            xlNewSheet8.Cells[1, 10] = "Supply Type";
                            xlNewSheet8.Cells[1, 11] = "Color print";
                            xlNewSheet8.Cells[1, 12] = "PO Raised Qty";
                            xlNewSheet8.Cells[1, 13] = "SRV Received";
                            xlNewSheet8.Cells[1, 14] = "SRV Balance (Failed Adjusted)";
                            xlNewSheet8.Cells[1, 15] = "PO Raised Qty-SRV Received(Qty)";
                            xlNewSheet8.Cells[1, 16] = "Checked SRV Qty";
                            xlNewSheet8.Cells[1, 17] = "Pass Qty";
                            xlNewSheet8.Cells[1, 18] = "Fail Qty";
                            xlNewSheet8.Cells[1, 19] = "Overall Usable Stock";
                            xlNewSheet8.Cells[1, 20] = "Moved Checked Stock";
                            xlNewSheet8.Cells[1, 21] = "Challan Qty";
                            xlNewSheet8.Cells[1, 22] = "Pending With Party (With Previous Stage)";

                            int O = 1;
                            foreach (DataRow dr in dt.Rows)
                            {
                                O++;

                                SupplyType = dr["SupplyType"] == DBNull.Value ? string.Empty : Convert.ToString(dr["SupplyType"]);
                                xlNewSheet8.Cells[O, 1] = dr["FabricQuality"] == DBNull.Value ? string.Empty : Convert.ToString(dr["FabricQuality"]);
                                xlNewSheet8.Cells[O, 2] = dr["CountConstruction"] == DBNull.Value ? string.Empty : Convert.ToString(dr["CountConstruction"]);
                                xlNewSheet8.Cells[O, 3] = dr["GSM"] == DBNull.Value ? string.Empty : Convert.ToString(dr["GSM"]);
                                xlNewSheet8.Cells[O, 4] = dr["SupplierName"] == DBNull.Value ? string.Empty : Convert.ToString(dr["SupplierName"]);
                                xlNewSheet8.Cells[O, 5] = dr["PO_Number"] == DBNull.Value ? string.Empty : Convert.ToString(dr["PO_Number"]);
                                xlNewSheet8.Cells[O, 6] = dr["PODate"] == DBNull.Value ? string.Empty : Convert.ToString(dr["PODate"]);
                                xlNewSheet8.Cells[O, 7] = dr["ETA"] == DBNull.Value ? string.Empty : Convert.ToString(dr["ETA"]);
                                xlNewSheet8.Cells[O, 8] = dr["Rate"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Rate"]);
                                xlNewSheet8.Cells[O, 9] = dr["SerialNumber"] == DBNull.Value ? string.Empty : Convert.ToString(dr["SerialNumber"]);
                                xlNewSheet8.Cells[O, 10] = dr["SupplyType"] == DBNull.Value ? string.Empty : Convert.ToString(dr["SupplyType"]);
                                xlNewSheet8.Cells[O, 11] = dr["Color_print"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Color_print"]);
                                xlNewSheet8.Cells[O, 12] = dr["PORaisedQty"] == DBNull.Value ? string.Empty : Convert.ToString(dr["PORaisedQty"]);
                                xlNewSheet8.Cells[O, 13] = dr["SRVReceived"] == DBNull.Value ? string.Empty : Convert.ToString(dr["SRVReceived"]);
                                xlNewSheet8.Cells[O, 14] = dr["SRVBalance"] == DBNull.Value ? string.Empty : Convert.ToString(dr["SRVBalance"]);
                                xlNewSheet8.Cells[O, 15] = dr["ExtraQty"] == DBNull.Value ? string.Empty : Convert.ToString(dr["ExtraQty"]);
                                xlNewSheet8.Cells[O, 16] = dr["CheckedSRVQty"] == DBNull.Value ? string.Empty : Convert.ToString(dr["CheckedSRVQty"]);
                                xlNewSheet8.Cells[O, 17] = dr["PassQty"] == DBNull.Value ? string.Empty : Convert.ToString(dr["PassQty"]);
                                xlNewSheet8.Cells[O, 18] = dr["FailQty"] == DBNull.Value ? string.Empty : Convert.ToString(dr["FailQty"]);
                                xlNewSheet8.Cells[O, 19] = dr["OverallUsableStock"] == DBNull.Value ? string.Empty : Convert.ToString(dr["OverallUsableStock"]);
                                xlNewSheet8.Cells[O, 20] = dr["MovedCheckedStock"] == DBNull.Value ? string.Empty : Convert.ToString(dr["MovedCheckedStock"]);
                                xlNewSheet8.Cells[O, 21] = dr["SendChallanQty"] == DBNull.Value ? string.Empty : Convert.ToString(dr["SendChallanQty"]);
                                xlNewSheet8.Cells[O, 22] = dr["PreviousWithParty"] == DBNull.Value ? string.Empty : Convert.ToString(dr["PreviousWithParty"]);


                            }
                            xlNewSheet8.Range["A1"].EntireColumn.Font.Bold = true;
                            xlNewSheet8.Range["A1"].EntireColumn.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Blue);  //fabricquality

                            xlNewSheet8.Range["I1"].EntireColumn.Font.Bold = true;
                            xlNewSheet8.Range["I1"].EntireColumn.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Blue); //SerialNumber

                            xlNewSheet8.Range["K1"].EntireColumn.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.ColorTranslator.FromHtml("#000"));//colorprint

                            xlNewSheet8.Range["H1"].EntireColumn.Font.Bold = true;
                            xlNewSheet8.Range["H1"].EntireColumn.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.ColorTranslator.FromHtml("#008000")); //Rate


                            xlNewSheet8.Range["B2", "B" + O].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;

                            xlNewSheet8.Range["C2", "C" + O].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;

                            xlNewSheet8.Range["A1", "V1"].Font.Color = ColorTranslator.ToOle(System.Drawing.Color.Black);

                            xlNewSheet8.Range["A1", "V1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);

                            xlNewSheet8.Range["A1", "V1"].Cells.Font.Bold = true;

                            xlNewSheet8.Range["A1", "V1"].Cells.Font.Size = 12;

                            xlNewSheet8.get_Range("A1:V" + O).Cells.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;

                            xlNewSheet8.Range["F1"].Cells.EntireColumn.NumberFormat = "dd mmm (ddd);@";

                            xlNewSheet8.Range["G1"].Cells.EntireColumn.NumberFormat = "dd mmm (ddd);@";

                            xlNewSheet8.Range["A1", "V1"].Cells.WrapText = true;

                            xlNewSheet8.Range["A1"].Cells.EntireColumn.ColumnWidth = 23.29;
                            xlNewSheet8.Range["B1"].Cells.EntireColumn.ColumnWidth = 16;
                            xlNewSheet8.Range["C1"].Cells.EntireColumn.ColumnWidth = 4.86;
                            xlNewSheet8.Range["D1"].Cells.EntireColumn.ColumnWidth = 26;
                            xlNewSheet8.Range["E1"].Cells.EntireColumn.ColumnWidth = 8.29;
                            xlNewSheet8.Range["F1"].Cells.EntireColumn.ColumnWidth = 12.43;
                            xlNewSheet8.Range["G1"].Cells.EntireColumn.ColumnWidth = 12.29;
                            xlNewSheet8.Range["H1"].Cells.EntireColumn.ColumnWidth = 8;
                            xlNewSheet8.Range["I1"].Cells.EntireColumn.ColumnWidth = 28.29;
                            xlNewSheet8.Range["J1"].Cells.EntireColumn.ColumnWidth = 8.14;
                            xlNewSheet8.Range["K1"].Cells.EntireColumn.ColumnWidth = 26;
                            xlNewSheet8.Range["L1"].Cells.EntireColumn.ColumnWidth = 8;
                            xlNewSheet8.Range["M1"].Cells.EntireColumn.ColumnWidth = 9;
                            xlNewSheet8.Range["N1"].Cells.EntireColumn.ColumnWidth = 12.14;
                            xlNewSheet8.Range["O1"].Cells.EntireColumn.ColumnWidth = 15;
                            xlNewSheet8.Range["P1"].Cells.EntireColumn.ColumnWidth = 8.86;
                            xlNewSheet8.Range["Q1"].Cells.EntireColumn.ColumnWidth = 8;
                            xlNewSheet8.Range["R1"].Cells.EntireColumn.ColumnWidth = 5.57;
                            xlNewSheet8.Range["S1"].Cells.EntireColumn.ColumnWidth = 8;
                            xlNewSheet8.Range["T1"].Cells.EntireColumn.ColumnWidth = 8.43;
                            xlNewSheet8.Range["U1"].Cells.EntireColumn.ColumnWidth = 7.43;
                            xlNewSheet8.Range["V1"].Cells.EntireColumn.ColumnWidth = 16.29;

                            xlNewSheet8.Range["A1", "V1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet8.Range["A1", "V1"].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;

                            xlNewSheet8.Range["A2", "V" + O].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignTop;

                            xlNewSheet8.Range["A2", "V" + O].Cells.WrapText = true;

                            if (SupplyType.ToLower() == "Griege".ToLower())
                            {
                                xlNewSheet8.Range["K1"].Columns.Hidden = true;
                            }

                            Excel.Range firstRow = (Excel.Range)xlNewSheet8.Rows[1];
                            firstRow.AutoFilter(1,
                                                Type.Missing,
                                                Excel.XlAutoFilterOperator.xlAnd,
                                                Type.Missing,
                                                true);
                            releaseObject(xlNewSheet8);
                        }
                    }
                    for (int i = 6; i >= 1; i--)
                    {
                        ((Excel.Worksheet)xlApp.ActiveWorkbook.Sheets[i]).Activate();
                        xlWorkBook.Application.ActiveWindow.SplitRow = 1;
                        xlWorkBook.Application.ActiveWindow.FreezePanes = true;
                    }
                }
                #endregion

                #region ReportType :- Accessory_PO_Detail
                else if (ReportType == "Accessory_PO_Detail")
                {
                    foreach (DataTable dt in ds.Tables)
                    {
                        if (dt.Rows.Count > 0)
                        {
                            GlobalCount_Accessory_Po_Details = GlobalCount_Accessory_Po_Details + 1;

                            var xlNewSheet8 = (Excel.Worksheet)worksheets.Add(worksheets[GlobalCount_Accessory_Po_Details], Type.Missing, Type.Missing, Type.Missing);
                            xlNewSheet8.Name = dt.Rows[0]["Po_Type"].ToString();
                            xlNewSheet8.Cells[1, 1] = "Accessory Name";
                            xlNewSheet8.Cells[1, 2] = "Supplier Name";
                            xlNewSheet8.Cells[1, 3] = "PO Number";
                            xlNewSheet8.Cells[1, 4] = "PO Date";
                            xlNewSheet8.Cells[1, 5] = "ETA";
                            xlNewSheet8.Cells[1, 6] = "Rate";
                            xlNewSheet8.Cells[1, 7] = "Serial Number";
                            xlNewSheet8.Cells[1, 8] = "Supply Type";
                            xlNewSheet8.Cells[1, 9] = "Color print";
                            xlNewSheet8.Cells[1, 10] = "PO Raised Qty";
                            xlNewSheet8.Cells[1, 11] = "SRV Received";
                            xlNewSheet8.Cells[1, 12] = "SRV Balance";
                            xlNewSheet8.Cells[1, 13] = "Checked SRV Qty";
                            xlNewSheet8.Cells[1, 14] = "Pass Qty";
                            xlNewSheet8.Cells[1, 15] = "Fail Qty";
                            xlNewSheet8.Cells[1, 16] = "Stock Qty";

                            int O = 1;
                            foreach (DataRow dr in dt.Rows)
                            {
                                O++;
                                xlNewSheet8.Cells[O, 1] = dr["AccessoryName"] == DBNull.Value ? string.Empty : Convert.ToString(dr["AccessoryName"]);
                                xlNewSheet8.Cells[O, 2] = dr["SupplierName"] == DBNull.Value ? string.Empty : Convert.ToString(dr["SupplierName"]);
                                xlNewSheet8.Cells[O, 3] = dr["PO_Number"] == DBNull.Value ? string.Empty : Convert.ToString(dr["PO_Number"]);
                                xlNewSheet8.Cells[O, 4] = dr["PODate"] == DBNull.Value ? string.Empty : Convert.ToString(dr["PODate"]);
                                xlNewSheet8.Cells[O, 5] = dr["ETA"] == DBNull.Value ? string.Empty : Convert.ToString(dr["ETA"]);
                                xlNewSheet8.Cells[O, 6] = dr["Rate"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Rate"]);
                                xlNewSheet8.Cells[O, 7] = dr["SerialNumber"] == DBNull.Value ? string.Empty : Convert.ToString(dr["SerialNumber"]);
                                xlNewSheet8.Cells[O, 8] = dr["SupplyType"] == DBNull.Value ? string.Empty : Convert.ToString(dr["SupplyType"]);
                                xlNewSheet8.Cells[O, 9] = dr["Color_print"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Color_print"]);
                                xlNewSheet8.Cells[O, 10] = dr["PORaisedQty"] == DBNull.Value ? string.Empty : Convert.ToString(dr["PORaisedQty"]);
                                xlNewSheet8.Cells[O, 11] = dr["SRVReceived"] == DBNull.Value ? string.Empty : Convert.ToString(dr["SRVReceived"]);
                                xlNewSheet8.Cells[O, 12] = dr["SRVBalance"] == DBNull.Value ? string.Empty : Convert.ToString(dr["SRVBalance"]);
                                xlNewSheet8.Cells[O, 13] = dr["CheckedSRVQty"] == DBNull.Value ? string.Empty : Convert.ToString(dr["CheckedSRVQty"]);
                                xlNewSheet8.Cells[O, 14] = dr["PassQty"] == DBNull.Value ? string.Empty : Convert.ToString(dr["PassQty"]);
                                xlNewSheet8.Cells[O, 15] = dr["FailQty"] == DBNull.Value ? string.Empty : Convert.ToString(dr["FailQty"]);
                                xlNewSheet8.Cells[O, 16] = dr["StockQty"] == DBNull.Value ? string.Empty : Convert.ToString(dr["StockQty"]);


                            }
                            xlNewSheet8.Range["A1"].EntireColumn.Font.Bold = true;
                            xlNewSheet8.Range["A1"].EntireColumn.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Blue);  //AccessoryName
                            xlNewSheet8.Range["G1"].EntireColumn.Font.Bold = true;
                            xlNewSheet8.Range["G1"].EntireColumn.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Blue); //SerialNumber
                            xlNewSheet8.Range["I1"].EntireColumn.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.ColorTranslator.FromHtml("#000"));//colorprint
                            xlNewSheet8.Range["F1"].EntireColumn.Font.Bold = true;
                            xlNewSheet8.Range["F1"].EntireColumn.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.ColorTranslator.FromHtml("#008000")); //rate

                            xlNewSheet8.Range["A1", "P1"].Font.Color = ColorTranslator.ToOle(System.Drawing.Color.Black);

                            xlNewSheet8.Range["A1", "P1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);

                            xlNewSheet8.Range["A1", "P1"].Cells.Font.Bold = true;

                            xlNewSheet8.Range["A1", "P1"].Cells.Font.Size = 12;

                            xlNewSheet8.get_Range("A1:P" + O).Cells.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;

                            xlNewSheet8.Range["D1"].Cells.EntireColumn.NumberFormat = "dd mmm (ddd);@";
                            xlNewSheet8.Range["E1"].Cells.EntireColumn.NumberFormat = "dd mmm (ddd);@";

                            xlNewSheet8.Range["A1", "P1"].Cells.WrapText = true;

                            xlNewSheet8.Range["A1"].Cells.EntireColumn.ColumnWidth = 25;
                            xlNewSheet8.Range["B1"].Cells.EntireColumn.ColumnWidth = 27;
                            xlNewSheet8.Range["C1"].Cells.EntireColumn.ColumnWidth = 10;
                            xlNewSheet8.Range["D1"].Cells.EntireColumn.ColumnWidth = 12.14;
                            xlNewSheet8.Range["E1"].Cells.EntireColumn.ColumnWidth = 12.43;
                            xlNewSheet8.Range["F1"].Cells.EntireColumn.ColumnWidth = 7.57;
                            xlNewSheet8.Range["G1"].Cells.EntireColumn.ColumnWidth = 20;
                            xlNewSheet8.Range["H1"].Cells.EntireColumn.ColumnWidth = 9;
                            xlNewSheet8.Range["I1"].Cells.EntireColumn.ColumnWidth = 13.43;
                            xlNewSheet8.Range["J1"].Cells.EntireColumn.ColumnWidth = 10.86;
                            xlNewSheet8.Range["K1"].Cells.EntireColumn.ColumnWidth = 10.86;
                            xlNewSheet8.Range["L1"].Cells.EntireColumn.ColumnWidth = 10.86;
                            xlNewSheet8.Range["M1"].Cells.EntireColumn.ColumnWidth = 10.86;
                            xlNewSheet8.Range["N1"].Cells.EntireColumn.ColumnWidth = 10.86;
                            xlNewSheet8.Range["O1"].Cells.EntireColumn.ColumnWidth = 10.86;
                            xlNewSheet8.Range["P1"].Cells.EntireColumn.ColumnWidth = 10.86;

                            xlNewSheet8.Range["A2", "P" + O].Cells.WrapText = true;

                            xlNewSheet8.Range["A1", "P1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlNewSheet8.Range["A1", "P1"].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            xlNewSheet8.Range["A2", "P" + O].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignTop;



                            Excel.Range firstRow = (Excel.Range)xlNewSheet8.Rows[1];
                            firstRow.AutoFilter(1,
                                                Type.Missing,
                                                Excel.XlAutoFilterOperator.xlAnd,
                                                Type.Missing,
                                                true);
                            releaseObject(xlNewSheet8);


                        }

                    }
                    for (int i = 3; i >= 1; i--)
                    {
                        ((Excel.Worksheet)xlApp.ActiveWorkbook.Sheets[i]).Activate();
                        xlWorkBook.Application.ActiveWindow.SplitRow = 1;
                        xlWorkBook.Application.ActiveWindow.FreezePanes = true;
                    }


                }
                #endregion

                #region ReportType :- CutIssueStatusExcel
                else if (ReportType == "Cut Issue Status")
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        var xlNewSheet8 = (Excel.Worksheet)worksheets.Add(worksheets[1], Type.Missing, Type.Missing, Type.Missing);
                        xlNewSheet8.Name = ds.Tables[0].Rows[0]["WorkbookName"].ToString();
                        xlNewSheet8.Cells[1, 1] = "Fabric Quality";
                        xlNewSheet8.Cells[1, 2] = "Count Construction";
                        xlNewSheet8.Cells[1, 3] = "GSM";
                        xlNewSheet8.Cells[1, 4] = "Serial Number";
                        xlNewSheet8.Cells[1, 5] = "Required Qty.";
                        xlNewSheet8.Cells[1, 6] = "LastStage SRVQty.";
                        xlNewSheet8.Cells[1, 7] = "LastStage PassQty.";
                        xlNewSheet8.Cells[1, 8] = "Total Issued";
                        xlNewSheet8.Cells[1, 9] = "Balance To Issue";


                        int O = 1;
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            O++;
                            xlNewSheet8.Cells[O, 1] = dr["FabricQuality"] == DBNull.Value ? string.Empty : Convert.ToString(dr["FabricQuality"]);
                            xlNewSheet8.Cells[O, 2] = dr["CountConstruction"] == DBNull.Value ? string.Empty : Convert.ToString(dr["CountConstruction"]);
                            xlNewSheet8.Cells[O, 3] = dr["GSM"] == DBNull.Value ? string.Empty : Convert.ToString(dr["GSM"]);
                            xlNewSheet8.Cells[O, 4] = dr["SerialNumber"] == DBNull.Value ? string.Empty : Convert.ToString(dr["SerialNumber"]);
                            xlNewSheet8.Cells[O, 5] = dr["RequiredQty"] == DBNull.Value ? string.Empty : Convert.ToString(dr["RequiredQty"]);
                            xlNewSheet8.Cells[O, 6] = dr["LastStageSRVQty"] == DBNull.Value ? string.Empty : Convert.ToString(dr["LastStageSRVQty"]);
                            xlNewSheet8.Cells[O, 7] = dr["LastStagePassQty"] == DBNull.Value ? string.Empty : Convert.ToString(dr["LastStagePassQty"]);
                            xlNewSheet8.Cells[O, 8] = dr["TotalIssued"] == DBNull.Value ? string.Empty : Convert.ToString(dr["TotalIssued"]);
                            xlNewSheet8.Cells[O, 9] = dr["Qty to Issue"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Qty to Issue"]);
                        }

                        xlNewSheet8.Range["A1"].EntireColumn.Font.Bold = true;
                        xlNewSheet8.Range["A1"].EntireColumn.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Blue);  //fabricquality

                        xlNewSheet8.Range["D1"].EntireColumn.Font.Bold = true;
                        xlNewSheet8.Range["D1"].EntireColumn.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Blue); //SerialNumber                      

                        xlNewSheet8.Range["B2", "B" + O].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;

                        xlNewSheet8.Range["A1", "I1"].Font.Color = ColorTranslator.ToOle(System.Drawing.Color.Black);

                        xlNewSheet8.Range["A1", "I1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);

                        //int lastUsedRow = xlNewSheet8.Cells.Find("*", System.Reflection.Missing.Value,
                        //   System.Reflection.Missing.Value, System.Reflection.Missing.Value,
                        //   Excel.XlSearchOrder.xlByRows, Excel.XlSearchDirection.xlPrevious,
                        //   false, System.Reflection.Missing.Value, System.Reflection.Missing.Value).Row;

                        //string LastRowNumber = lastUsedRow.ToString();
                        //string ExcelLastRow = "I" + LastRowNumber;                    

                        xlNewSheet8.Range["A1", "I1"].Cells.Font.Bold = true;
                        xlNewSheet8.Range["A1", "I1"].Cells.Font.Size = 12;
                        xlNewSheet8.get_Range("A1:I" + O).Cells.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;

                        xlNewSheet8.Range["A1"].Cells.EntireColumn.ColumnWidth = 20.29;
                        xlNewSheet8.Range["B1"].Cells.EntireColumn.ColumnWidth = 26.29;
                        xlNewSheet8.Range["C1"].Cells.EntireColumn.ColumnWidth = 4.86;
                        xlNewSheet8.Range["D1"].Cells.EntireColumn.ColumnWidth = 14.43;

                        xlNewSheet8.Range["E1"].Cells.EntireColumn.ColumnWidth = 9.14;
                        xlNewSheet8.Range["F1"].Cells.EntireColumn.ColumnWidth = 10.14;
                        xlNewSheet8.Range["G1"].Cells.EntireColumn.ColumnWidth = 10.14;
                        xlNewSheet8.Range["H1"].Cells.EntireColumn.ColumnWidth = 6.43;
                        xlNewSheet8.Range["I1"].Cells.EntireColumn.ColumnWidth = 8;


                        xlNewSheet8.Range["A1", "I1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet8.Range["A1", "I1"].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        xlNewSheet8.Range["A2", "I" + O].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignTop;



                        xlNewSheet8.Range["A1", "I1"].Cells.WrapText = true;
                        xlNewSheet8.Range["A2", "I" + O].Cells.WrapText = true;

                        Excel.Range firstRow = (Excel.Range)xlNewSheet8.Rows[1];
                        firstRow.AutoFilter(1,
                                            Type.Missing,
                                            Excel.XlAutoFilterOperator.xlAnd,
                                            Type.Missing,
                                            true);
                        releaseObject(xlNewSheet8);
                    }


                    ((Excel.Worksheet)xlApp.ActiveWorkbook.Sheets[1]).Activate();
                    xlWorkBook.Application.ActiveWindow.SplitRow = 1;
                    xlWorkBook.Application.ActiveWindow.FreezePanes = true;

                }
                #endregion

                #region ReportType :- AccessoryIssueQuantityExcel
                else if (ReportType == "Accessory_Issued_Quantity")
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        var xlNewSheet8 = (Excel.Worksheet)worksheets.Add(worksheets[1], Type.Missing, Type.Missing, Type.Missing);
                        xlNewSheet8.Name = ds.Tables[0].Rows[0]["WorkbookName"].ToString();
                        xlNewSheet8.Cells[1, 1] = "Accessory Quality";
                        xlNewSheet8.Cells[1, 2] = "Serial Number";
                        xlNewSheet8.Cells[1, 3] = "Required Qty.";
                        xlNewSheet8.Cells[1, 4] = "LastStage SRVQty.";
                        xlNewSheet8.Cells[1, 5] = "LastStage PassQty.";
                        xlNewSheet8.Cells[1, 6] = "Total Issued";
                        xlNewSheet8.Cells[1, 7] = "Balance To Issue";
                        xlNewSheet8.Cells[1, 8] = "Considered Wastage %";

                        int O = 1;
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            O++;
                            xlNewSheet8.Cells[O, 1] = dr["AccessoryQuality"] == DBNull.Value ? string.Empty : Convert.ToString(dr["AccessoryQuality"]);
                            xlNewSheet8.Cells[O, 2] = dr["SerialNumber"] == DBNull.Value ? string.Empty : Convert.ToString(dr["SerialNumber"]);
                            xlNewSheet8.Cells[O, 3] = dr["RequiredQty"] == DBNull.Value ? string.Empty : Convert.ToString(dr["RequiredQty"]);
                            xlNewSheet8.Cells[O, 4] = dr["LastStageSRVQty"] == DBNull.Value ? string.Empty : Convert.ToString(dr["LastStageSRVQty"]);
                            xlNewSheet8.Cells[O, 5] = dr["LastStagePassQty"] == DBNull.Value ? string.Empty : Convert.ToString(dr["LastStagePassQty"]);
                            xlNewSheet8.Cells[O, 6] = dr["TotalIssued"] == DBNull.Value ? string.Empty : Convert.ToString(dr["TotalIssued"]);
                            xlNewSheet8.Cells[O, 7] = dr["Qty to Issue"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Qty to Issue"]);
                            xlNewSheet8.Cells[O, 8] = dr["Considered Wastage %"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Considered Wastage %"]);

                        }

                        xlNewSheet8.Range["A1"].EntireColumn.Font.Bold = true;
                        xlNewSheet8.Range["A1"].EntireColumn.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Blue);  //AccessoryName
                        xlNewSheet8.Range["B1"].EntireColumn.Font.Bold = true;
                        xlNewSheet8.Range["B1"].EntireColumn.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Blue); //SerialNumber
                        xlNewSheet8.Range["A1", "H1"].Font.Color = ColorTranslator.ToOle(System.Drawing.Color.Black);
                        xlNewSheet8.Range["A1", "H1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);

                        //int lastUsedRow = xlNewSheet8.Cells.Find("*", System.Reflection.Missing.Value,
                        //   System.Reflection.Missing.Value, System.Reflection.Missing.Value,
                        //   Excel.XlSearchOrder.xlByRows, Excel.XlSearchDirection.xlPrevious,
                        //   false, System.Reflection.Missing.Value, System.Reflection.Missing.Value).Row;

                        xlNewSheet8.Range["A1", "H1"].Cells.Font.Bold = true;
                        xlNewSheet8.Range["A1", "H1"].Cells.Font.Size = 12;
                        xlNewSheet8.get_Range("A1:H" + O).Cells.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;

                        xlNewSheet8.Range["A1"].Cells.EntireColumn.ColumnWidth = 33;
                        xlNewSheet8.Range["B1"].Cells.EntireColumn.ColumnWidth = 11;
                        xlNewSheet8.Range["C1"].Cells.EntireColumn.ColumnWidth = 11;
                        xlNewSheet8.Range["D1"].Cells.EntireColumn.ColumnWidth = 11;
                        xlNewSheet8.Range["E1"].Cells.EntireColumn.ColumnWidth = 11;
                        xlNewSheet8.Range["G1"].Cells.EntireColumn.ColumnWidth = 11;
                        xlNewSheet8.Range["G1"].Cells.EntireColumn.ColumnWidth = 11;
                        xlNewSheet8.Range["H1"].Cells.EntireColumn.ColumnWidth = 11;

                        xlNewSheet8.Range["A1", "H1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet8.Range["A1", "H1"].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        xlNewSheet8.Range["A2", "H" + O].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignTop;

                        xlNewSheet8.Range["A1", "H1"].Cells.WrapText = true;
                        xlNewSheet8.Range["A2", "H" + O].Cells.WrapText = true;

                        Excel.Range firstRow = (Excel.Range)xlNewSheet8.Rows[1];
                        firstRow.AutoFilter(1,
                                            Type.Missing,
                                            Excel.XlAutoFilterOperator.xlAnd,
                                            Type.Missing,
                                            true);
                        releaseObject(xlNewSheet8);
                    }


                    ((Excel.Worksheet)xlApp.ActiveWorkbook.Sheets[1]).Activate();
                    xlWorkBook.Application.ActiveWindow.SplitRow = 1;
                    xlWorkBook.Application.ActiveWindow.FreezePanes = true;

                }
                #endregion

                #region ReportType :- Production_Stock_Detail
                else if (ReportType == "Production Stock Detail")
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        var xlNewSheet8 = (Excel.Worksheet)worksheets.Add(worksheets[1], Type.Missing, Type.Missing, Type.Missing);
                        xlNewSheet8.Name = ds.Tables[0].Rows[0]["WorkbookName"].ToString();
                        xlNewSheet8.Cells[1, 1] = "Serial Number";
                        xlNewSheet8.Cells[1, 2] = "Contract Qty.";
                        xlNewSheet8.Cells[1, 3] = "BIPL Price";
                        xlNewSheet8.Cells[1, 4] = "Conversion Rate";

                        xlNewSheet8.Cells[1, 5] = "Issued Qty.";
                        xlNewSheet8.Cells[1, 6] = "Issue Balance";
                        xlNewSheet8.Cells[1, 7] = "Pending IssueVal.";

                        xlNewSheet8.Cells[1, 8] = "Cut Qty.";
                        xlNewSheet8.Cells[1, 9] = "Cut Balance";
                        xlNewSheet8.Cells[1, 10] = "Pending CutVal.";

                        xlNewSheet8.Cells[1, 11] = "Stitched Qty.";
                        xlNewSheet8.Cells[1, 12] = "Stitch Balance";
                        xlNewSheet8.Cells[1, 13] = "Pending StitchVal.";

                        xlNewSheet8.Cells[1, 14] = "Pack Value";
                        xlNewSheet8.Cells[1, 15] = "Pending PackVal.";

                        int O = 1;
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            O++;
                            xlNewSheet8.Cells[O, 1] = dr["SerialNumber"] == DBNull.Value ? string.Empty : Convert.ToString(dr["SerialNumber"]);
                            xlNewSheet8.Cells[O, 2] = dr["ContractQuantity"] == DBNull.Value ? string.Empty : Convert.ToString(dr["ContractQuantity"]);
                            xlNewSheet8.Cells[O, 3] = dr["BIPLPrice"] == DBNull.Value ? string.Empty : Convert.ToString(dr["BIPLPrice"]);
                            xlNewSheet8.Cells[O, 4] = dr["ConversionRate"] == DBNull.Value ? string.Empty : Convert.ToString(dr["ConversionRate"]);

                            xlNewSheet8.Cells[O, 5] = dr["IssuedQty"] == DBNull.Value ? string.Empty : Convert.ToString(dr["IssuedQty"]);
                            xlNewSheet8.Cells[O, 6] = dr["IssueBalance"] == DBNull.Value ? string.Empty : Convert.ToString(dr["IssueBalance"]);
                            xlNewSheet8.Cells[O, 7] = dr["PendingIssueValue"] == DBNull.Value ? string.Empty : Convert.ToString(dr["PendingIssueValue"]); ;

                            xlNewSheet8.Cells[O, 8] = dr["CutQuantity"] == DBNull.Value ? string.Empty : Convert.ToString(dr["CutQuantity"]);
                            xlNewSheet8.Cells[O, 9] = dr["CutBalance"] == DBNull.Value ? string.Empty : Convert.ToString(dr["CutBalance"]);
                            xlNewSheet8.Cells[O, 10] = dr["PendingCutValue"] == DBNull.Value ? string.Empty : Convert.ToString(dr["PendingCutValue"]);

                            xlNewSheet8.Cells[O, 11] = dr["StitchedQty"] == DBNull.Value ? string.Empty : Convert.ToString(dr["StitchedQty"]);
                            xlNewSheet8.Cells[O, 12] = dr["StitchBalance"] == DBNull.Value ? string.Empty : Convert.ToString(dr["StitchBalance"]);
                            xlNewSheet8.Cells[O, 13] = dr["PendingStitchValue"] == DBNull.Value ? string.Empty : Convert.ToString(dr["PendingStitchValue"]);

                            xlNewSheet8.Cells[O, 14] = dr["PackValue"] == DBNull.Value ? string.Empty : Convert.ToString(dr["PackValue"]);
                            xlNewSheet8.Cells[O, 15] = dr["PendingPackValue"] == DBNull.Value ? string.Empty : Convert.ToString(dr["PendingPackValue"]);

                        }

                        xlNewSheet8.Range["A1"].EntireColumn.Font.Bold = true;
                        xlNewSheet8.Range["A1"].EntireColumn.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Blue); //SerialNumber
                        xlNewSheet8.Range["A1", "O1"].Font.Color = ColorTranslator.ToOle(System.Drawing.Color.Black);
                        xlNewSheet8.Range["A1", "O1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);

                        xlNewSheet8.Range["A1", "O1"].Cells.Font.Bold = true;
                        xlNewSheet8.Range["A1", "O1"].Cells.Font.Size = 12;
                        xlNewSheet8.get_Range("A1:O" + O).Cells.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;

                        xlNewSheet8.Range["A1"].Cells.EntireColumn.ColumnWidth = 14.57;
                        xlNewSheet8.Range["B1"].Cells.EntireColumn.ColumnWidth = 9;
                        xlNewSheet8.Range["C1"].Cells.EntireColumn.ColumnWidth = 5.29;
                        xlNewSheet8.Range["D1"].Cells.EntireColumn.ColumnWidth = 13.29;
                        xlNewSheet8.Range["E1"].Cells.EntireColumn.ColumnWidth = 10.86;
                        xlNewSheet8.Range["F1"].Cells.EntireColumn.ColumnWidth = 11.71;
                        xlNewSheet8.Range["G1"].Cells.EntireColumn.ColumnWidth = 13.14;
                        xlNewSheet8.Range["H1"].Cells.EntireColumn.ColumnWidth = 10.86;
                        xlNewSheet8.Range["I1"].Cells.EntireColumn.ColumnWidth = 11.29;
                        xlNewSheet8.Range["J1"].Cells.EntireColumn.ColumnWidth = 13.00;
                        xlNewSheet8.Range["K1"].Cells.EntireColumn.ColumnWidth = 10.86;
                        xlNewSheet8.Range["L1"].Cells.EntireColumn.ColumnWidth = 11.71;
                        xlNewSheet8.Range["M1"].Cells.EntireColumn.ColumnWidth = 13.00;
                        xlNewSheet8.Range["N1"].Cells.EntireColumn.ColumnWidth = 10.29;
                        xlNewSheet8.Range["O1"].Cells.EntireColumn.ColumnWidth = 13.00;


                        xlNewSheet8.Range["A1", "O1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet8.Range["A1", "O1"].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignTop;
                        xlNewSheet8.Range["A2", "O" + O].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignTop;


                        xlNewSheet8.Range["A1", "O1"].Cells.WrapText = true;

                        xlNewSheet8.Range["A2", "O" + O].Cells.WrapText = true;

                        xlNewSheet8.Range["A1", "O1"].Cells.VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;


                        Excel.Range firstRow = (Excel.Range)xlNewSheet8.Rows[1];
                        firstRow.AutoFilter(1,
                                            Type.Missing,
                                            Excel.XlAutoFilterOperator.xlAnd,
                                            Type.Missing,
                                            true);
                        releaseObject(xlNewSheet8);
                    }


                    ((Excel.Worksheet)xlApp.ActiveWorkbook.Sheets[1]).Activate();
                    xlWorkBook.Application.ActiveWindow.SplitRow = 1;
                    xlWorkBook.Application.ActiveWindow.FreezePanes = true;

                }
                #endregion

                #region ReportType :- Rates
                else if (ReportType == "Rates")
                {
                    #region FabricRates 2 Year
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        var xlNewSheet8 = (Excel.Worksheet)worksheets.Add(worksheets[1], Type.Missing, Type.Missing, Type.Missing);
                        xlNewSheet8.Name = ds.Tables[0].Rows[0]["WorkbookName"].ToString();
                        xlNewSheet8.Cells[1, 1] = "Financial Year";
                        xlNewSheet8.Cells[1, 2] = "Fabric Quality";
                        xlNewSheet8.Cells[1, 3] = "Griege C&C";
                        xlNewSheet8.Cells[1, 4] = "C&C";
                        xlNewSheet8.Cells[1, 5] = "GSM";
                        xlNewSheet8.Cells[1, 6] = "Cut Width";
                        xlNewSheet8.Cells[1, 7] = "Griege Shrinkage";
                        xlNewSheet8.Cells[1, 8] = "Res Shrinkage";
                        xlNewSheet8.Cells[1, 9] = "Type";
                        xlNewSheet8.Cells[1, 10] = "Supplier Name";
                        xlNewSheet8.Cells[1, 11] = "Rate";
                        xlNewSheet8.Cells[1, 12] = "PO Number";
                        xlNewSheet8.Cells[1, 13] = "Serial Number";
                        xlNewSheet8.Cells[1, 14] = "PODate";
                        xlNewSheet8.Cells[1, 15] = "Unit";

                        int O = 1;
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            O++;
                            xlNewSheet8.Cells[O, 1] = dr["FinancialYear"] == DBNull.Value ? string.Empty : Convert.ToString(dr["FinancialYear"]);
                            xlNewSheet8.Cells[O, 2] = dr["FabricQuality"] == DBNull.Value ? string.Empty : Convert.ToString(dr["FabricQuality"]);
                            xlNewSheet8.Cells[O, 3] = dr["GreigeC&C"] == DBNull.Value ? string.Empty : Convert.ToString(dr["GreigeC&C"]);
                            xlNewSheet8.Cells[O, 4] = dr["C&C"] == DBNull.Value ? string.Empty : Convert.ToString(dr["C&C"]);
                            xlNewSheet8.Cells[O, 5] = dr["GSM"] == DBNull.Value ? string.Empty : Convert.ToString(dr["GSM"]);
                            xlNewSheet8.Cells[O, 6] = dr["CutWidth"] == DBNull.Value ? string.Empty : Convert.ToString(dr["CutWidth"]);
                            xlNewSheet8.Cells[O, 7] = dr["GerigeShrinkage"] == DBNull.Value ? string.Empty : Convert.ToString(dr["GerigeShrinkage"]);
                            xlNewSheet8.Cells[O, 8] = dr["ResShrinkage"] == DBNull.Value ? string.Empty : Convert.ToString(dr["ResShrinkage"]);
                            xlNewSheet8.Cells[O, 9] = dr["Type"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Type"]);
                            xlNewSheet8.Cells[O, 10] = dr["SupplierName"] == DBNull.Value ? string.Empty : Convert.ToString(dr["SupplierName"]);
                            xlNewSheet8.Cells[O, 11] = dr["Rate"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Rate"]);
                            xlNewSheet8.Cells[O, 12] = dr["PO_Number"] == DBNull.Value ? string.Empty : Convert.ToString(dr["PO_Number"]);
                            xlNewSheet8.Cells[O, 13] = dr["SerialNumber"] == DBNull.Value ? string.Empty : Convert.ToString(dr["SerialNumber"]);
                            xlNewSheet8.Cells[O, 14] = dr["PODate"] == DBNull.Value ? string.Empty : Convert.ToString(dr["PODate"]);
                            xlNewSheet8.Cells[O, 15] = dr["Unit"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Unit"]);
                        }
                        xlNewSheet8.Range["B1"].EntireColumn.Font.Bold = true;
                        xlNewSheet8.Range["B1"].EntireColumn.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Blue);  //fabricquality           
                        xlNewSheet8.Range["C2", "C" + O].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                        xlNewSheet8.Range["D2", "D" + O].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                        xlNewSheet8.Range["E2", "E" + O].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                        xlNewSheet8.Range["F2", "F" + O].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                        xlNewSheet8.Range["G2", "G" + O].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                        xlNewSheet8.Range["H2", "H" + O].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;

                        xlNewSheet8.Range["K1"].EntireColumn.Font.Bold = true;
                        xlNewSheet8.Range["K1"].EntireColumn.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.ColorTranslator.FromHtml("#008000")); //Rate

                        xlNewSheet8.Range["A1", "O1"].Font.Color = ColorTranslator.ToOle(System.Drawing.Color.Black);
                        xlNewSheet8.Range["A1", "O1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        xlNewSheet8.Range["A1", "O1"].Cells.Font.Bold = true;
                        xlNewSheet8.Range["A1", "O1"].Cells.Font.Size = 12;
                        xlNewSheet8.get_Range("A1:O" + O).Cells.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;

                        xlNewSheet8.Range["N1"].Cells.EntireColumn.NumberFormat = "dd mmm (yyy);@";

                        xlNewSheet8.Range["A1"].Cells.EntireColumn.ColumnWidth = 9.57;
                        xlNewSheet8.Range["B1"].Cells.EntireColumn.ColumnWidth = 33;
                        xlNewSheet8.Range["C1"].Cells.EntireColumn.ColumnWidth = 25;
                        xlNewSheet8.Range["D1"].Cells.EntireColumn.ColumnWidth = 25;

                        xlNewSheet8.Range["E1"].Cells.EntireColumn.ColumnWidth = 9.43;
                        xlNewSheet8.Range["G1"].Cells.EntireColumn.ColumnWidth = 12.29;
                        xlNewSheet8.Range["H1"].Cells.EntireColumn.ColumnWidth = 12.29;
                        xlNewSheet8.Range["I1"].Cells.EntireColumn.ColumnWidth = 14;
                        xlNewSheet8.Range["J1"].Cells.EntireColumn.ColumnWidth = 34;
                        xlNewSheet8.Range["K1"].Cells.EntireColumn.ColumnWidth = 9.29;
                        xlNewSheet8.Range["L1"].Cells.EntireColumn.ColumnWidth = 12.86;
                        xlNewSheet8.Range["M1"].Cells.EntireColumn.ColumnWidth = 10; //SerialNumber
                        xlNewSheet8.Range["N1"].Cells.EntireColumn.ColumnWidth = 12;

                        xlNewSheet8.Range["A1", "O1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet8.Range["A1", "O1"].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        xlNewSheet8.Range["A2", "O" + O].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignTop;

                        xlNewSheet8.Range["A1", "O1"].Cells.WrapText = true;
                        xlNewSheet8.Range["A2", "O" + O].Cells.WrapText = true;

                        Excel.Range firstRow = (Excel.Range)xlNewSheet8.Rows[1];
                        firstRow.AutoFilter(1,
                                            Type.Missing,
                                            Excel.XlAutoFilterOperator.xlAnd,
                                            Type.Missing,
                                            true);
                        releaseObject(xlNewSheet8);
                    }
                    #endregion

                    #region AccessoryRate 2 Year
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        var xlNewSheet8 = (Excel.Worksheet)worksheets.Add(worksheets[1], Type.Missing, Type.Missing, Type.Missing);
                        xlNewSheet8.Name = ds.Tables[1].Rows[0]["WorkbookName"].ToString();
                        xlNewSheet8.Cells[1, 1] = "Financial Year";
                        xlNewSheet8.Cells[1, 2] = "Accessory Quality";
                        xlNewSheet8.Cells[1, 3] = "Size";
                        xlNewSheet8.Cells[1, 4] = "Shrinkage";
                        xlNewSheet8.Cells[1, 5] = "Wastage";
                        xlNewSheet8.Cells[1, 6] = "Type";
                        xlNewSheet8.Cells[1, 7] = "SupplierName";
                        xlNewSheet8.Cells[1, 8] = "Rate";
                        xlNewSheet8.Cells[1, 9] = "PO Number";
                        xlNewSheet8.Cells[1, 10] = "Serial Number";
                        xlNewSheet8.Cells[1, 11] = "PODate";
                        xlNewSheet8.Cells[1, 12] = "Unit";

                        int O = 1;
                        foreach (DataRow dr in ds.Tables[1].Rows)
                        {
                            O++;
                            xlNewSheet8.Cells[O, 1] = dr["FinancialYear"] == DBNull.Value ? string.Empty : Convert.ToString(dr["FinancialYear"]);
                            xlNewSheet8.Cells[O, 2] = dr["AccessoryQuality"] == DBNull.Value ? string.Empty : Convert.ToString(dr["AccessoryQuality"]);
                            xlNewSheet8.Cells[O, 3] = dr["Size"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Size"]);
                            xlNewSheet8.Cells[O, 4] = dr["Shrinkage"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Shrinkage"]);
                            xlNewSheet8.Cells[O, 5] = dr["Wastage"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Wastage"]);
                            xlNewSheet8.Cells[O, 6] = dr["Type"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Type"]);
                            xlNewSheet8.Cells[O, 7] = dr["SupplierName"] == DBNull.Value ? string.Empty : Convert.ToString(dr["SupplierName"]);
                            xlNewSheet8.Cells[O, 8] = dr["Rate"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Rate"]);
                            xlNewSheet8.Cells[O, 9] = dr["PO_Number"] == DBNull.Value ? string.Empty : Convert.ToString(dr["PO_Number"]);
                            xlNewSheet8.Cells[O, 10] = dr["SerialNumber"] == DBNull.Value ? string.Empty : Convert.ToString(dr["SerialNumber"]);
                            xlNewSheet8.Cells[O, 11] = dr["PODate"] == DBNull.Value ? string.Empty : Convert.ToString(dr["PODate"]);
                            xlNewSheet8.Cells[O, 12] = dr["Unit"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Unit"]);
                        }
                        xlNewSheet8.Range["B1"].EntireColumn.Font.Bold = true;
                        xlNewSheet8.Range["B1"].EntireColumn.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Blue);  //fabricquality           
                        xlNewSheet8.Range["C2", "C" + O].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                        xlNewSheet8.Range["D2", "D" + O].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                        xlNewSheet8.Range["E2", "E" + O].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;

                        xlNewSheet8.Range["H1"].EntireColumn.Font.Bold = true;
                        xlNewSheet8.Range["H1"].EntireColumn.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.ColorTranslator.FromHtml("#008000")); //Rate

                        xlNewSheet8.Range["A1", "L1"].Font.Color = ColorTranslator.ToOle(System.Drawing.Color.Black);
                        xlNewSheet8.Range["A1", "L1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        xlNewSheet8.Range["A1", "L1"].Cells.Font.Bold = true;
                        xlNewSheet8.Range["A1", "L1"].Cells.Font.Size = 12;

                        xlNewSheet8.get_Range("A1:L" + O).Cells.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;

                        xlNewSheet8.Range["K1"].Cells.EntireColumn.NumberFormat = "dd mmm (yyy);@";

                        xlNewSheet8.Range["A1"].Cells.EntireColumn.ColumnWidth = 9.57;
                        xlNewSheet8.Range["B1"].Cells.EntireColumn.ColumnWidth = 45;
                        xlNewSheet8.Range["C1"].Cells.EntireColumn.ColumnWidth = 12.57;
                        xlNewSheet8.Range["D1"].Cells.EntireColumn.ColumnWidth = 11.14;

                        xlNewSheet8.Range["E1"].Cells.EntireColumn.ColumnWidth = 9.14;
                        xlNewSheet8.Range["F1"].Cells.EntireColumn.ColumnWidth = 9.57;

                        xlNewSheet8.Range["G1"].Cells.EntireColumn.ColumnWidth = 18.86;
                        xlNewSheet8.Range["H1"].Cells.EntireColumn.ColumnWidth = 12.29;
                        xlNewSheet8.Range["I1"].Cells.EntireColumn.ColumnWidth = 14;
                        xlNewSheet8.Range["J1"].Cells.EntireColumn.ColumnWidth = 10; //SerialNumber
                        xlNewSheet8.Range["K1"].Cells.EntireColumn.ColumnWidth = 12.43;
                        xlNewSheet8.Range["L1"].Cells.EntireColumn.ColumnWidth = 9;

                        xlNewSheet8.Range["A1", "L1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet8.Range["A1", "L1"].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        xlNewSheet8.Range["A2", "L" + O].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignTop;

                        xlNewSheet8.Range["A1", "L1"].Cells.WrapText = true;
                        xlNewSheet8.Range["A2", "L" + O].Cells.WrapText = true;

                        Excel.Range firstRow = (Excel.Range)xlNewSheet8.Rows[1];
                        firstRow.AutoFilter(1,
                                            Type.Missing,
                                            Excel.XlAutoFilterOperator.xlAnd,
                                            Type.Missing,
                                            true);
                        releaseObject(xlNewSheet8);
                    }
                    #endregion

                    #region FabricRates Top 3
                    if (ds.Tables[2].Rows.Count > 0)
                    {
                        var xlNewSheet8 = (Excel.Worksheet)worksheets.Add(worksheets[1], Type.Missing, Type.Missing, Type.Missing);
                        xlNewSheet8.Name = ds.Tables[2].Rows[0]["WorkbookName"].ToString();
                        xlNewSheet8.Cells[1, 1] = "Financial Year";
                        xlNewSheet8.Cells[1, 2] = "Fabric Quality";
                        xlNewSheet8.Cells[1, 3] = "Griege C&C";
                        xlNewSheet8.Cells[1, 4] = "C&C";
                        xlNewSheet8.Cells[1, 5] = "GSM";
                        xlNewSheet8.Cells[1, 6] = "Cut Width";
                        xlNewSheet8.Cells[1, 7] = "Griege Shrinkage";
                        xlNewSheet8.Cells[1, 8] = "Res Shrinkage";
                        xlNewSheet8.Cells[1, 9] = "Type";
                        xlNewSheet8.Cells[1, 10] = "Supplier Name";
                        xlNewSheet8.Cells[1, 11] = "Rate";
                        xlNewSheet8.Cells[1, 12] = "PO Number";
                        xlNewSheet8.Cells[1, 13] = "Serial Number";
                        xlNewSheet8.Cells[1, 14] = "PODate";
                        xlNewSheet8.Cells[1, 15] = "Unit";

                        int O = 1;
                        foreach (DataRow dr in ds.Tables[2].Rows)
                        {
                            O++;
                            xlNewSheet8.Cells[O, 1] = dr["FinancialYear"] == DBNull.Value ? string.Empty : Convert.ToString(dr["FinancialYear"]);
                            xlNewSheet8.Cells[O, 2] = dr["FabricQuality"] == DBNull.Value ? string.Empty : Convert.ToString(dr["FabricQuality"]);
                            xlNewSheet8.Cells[O, 3] = dr["GreigeC&C"] == DBNull.Value ? string.Empty : Convert.ToString(dr["GreigeC&C"]);
                            xlNewSheet8.Cells[O, 4] = dr["C&C"] == DBNull.Value ? string.Empty : Convert.ToString(dr["C&C"]);
                            xlNewSheet8.Cells[O, 5] = dr["GSM"] == DBNull.Value ? string.Empty : Convert.ToString(dr["GSM"]);
                            xlNewSheet8.Cells[O, 6] = dr["CutWidth"] == DBNull.Value ? string.Empty : Convert.ToString(dr["CutWidth"]);
                            xlNewSheet8.Cells[O, 7] = dr["GerigeShrinkage"] == DBNull.Value ? string.Empty : Convert.ToString(dr["GerigeShrinkage"]);
                            xlNewSheet8.Cells[O, 8] = dr["ResShrinkage"] == DBNull.Value ? string.Empty : Convert.ToString(dr["ResShrinkage"]);
                            xlNewSheet8.Cells[O, 9] = dr["Type"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Type"]);
                            xlNewSheet8.Cells[O, 10] = dr["SupplierName"] == DBNull.Value ? string.Empty : Convert.ToString(dr["SupplierName"]);
                            xlNewSheet8.Cells[O, 11] = dr["Rate"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Rate"]);
                            xlNewSheet8.Cells[O, 12] = dr["PO_Number"] == DBNull.Value ? string.Empty : Convert.ToString(dr["PO_Number"]);
                            xlNewSheet8.Cells[O, 13] = dr["SerialNumber"] == DBNull.Value ? string.Empty : Convert.ToString(dr["SerialNumber"]);
                            xlNewSheet8.Cells[O, 14] = dr["PODate"] == DBNull.Value ? string.Empty : Convert.ToString(dr["PODate"]);
                            xlNewSheet8.Cells[O, 15] = dr["Unit"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Unit"]);
                        }
                        xlNewSheet8.Range["B1"].EntireColumn.Font.Bold = true;
                        xlNewSheet8.Range["B1"].EntireColumn.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Blue);  //fabricquality           
                        xlNewSheet8.Range["C2", "C" + O].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                        xlNewSheet8.Range["D2", "D" + O].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                        xlNewSheet8.Range["E2", "E" + O].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                        xlNewSheet8.Range["F2", "F" + O].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                        xlNewSheet8.Range["G2", "G" + O].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                        xlNewSheet8.Range["H2", "H" + O].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;

                        xlNewSheet8.Range["K1"].EntireColumn.Font.Bold = true;
                        xlNewSheet8.Range["K1"].EntireColumn.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.ColorTranslator.FromHtml("#008000")); //Rate

                        xlNewSheet8.Range["A1", "O1"].Font.Color = ColorTranslator.ToOle(System.Drawing.Color.Black);
                        xlNewSheet8.Range["A1", "O1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        xlNewSheet8.Range["A1", "O1"].Cells.Font.Bold = true;
                        xlNewSheet8.Range["A1", "O1"].Cells.Font.Size = 12;
                        xlNewSheet8.get_Range("A1:O" + O).Cells.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;

                        xlNewSheet8.Range["N1"].Cells.EntireColumn.NumberFormat = "dd mmm (yyy);@";

                        xlNewSheet8.Range["A1"].Cells.EntireColumn.ColumnWidth = 9.57;
                        xlNewSheet8.Range["B1"].Cells.EntireColumn.ColumnWidth = 33;
                        xlNewSheet8.Range["C1"].Cells.EntireColumn.ColumnWidth = 25;
                        xlNewSheet8.Range["D1"].Cells.EntireColumn.ColumnWidth = 25;

                        xlNewSheet8.Range["E1"].Cells.EntireColumn.ColumnWidth = 9.43;
                        xlNewSheet8.Range["G1"].Cells.EntireColumn.ColumnWidth = 12.29;
                        xlNewSheet8.Range["H1"].Cells.EntireColumn.ColumnWidth = 12.29;
                        xlNewSheet8.Range["I1"].Cells.EntireColumn.ColumnWidth = 14;
                        xlNewSheet8.Range["J1"].Cells.EntireColumn.ColumnWidth = 34;
                        xlNewSheet8.Range["K1"].Cells.EntireColumn.ColumnWidth = 9.29;
                        xlNewSheet8.Range["L1"].Cells.EntireColumn.ColumnWidth = 12.86;
                        xlNewSheet8.Range["M1"].Cells.EntireColumn.ColumnWidth = 10; //SerialNumber
                        xlNewSheet8.Range["N1"].Cells.EntireColumn.ColumnWidth = 12;

                        xlNewSheet8.Range["A1", "O1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet8.Range["A1", "O1"].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        xlNewSheet8.Range["A2", "O" + O].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignTop;

                        xlNewSheet8.Range["A1", "O1"].Cells.WrapText = true;
                        xlNewSheet8.Range["A2", "O" + O].Cells.WrapText = true;

                        Excel.Range firstRow = (Excel.Range)xlNewSheet8.Rows[1];
                        firstRow.AutoFilter(1,
                                            Type.Missing,
                                            Excel.XlAutoFilterOperator.xlAnd,
                                            Type.Missing,
                                            true);
                        releaseObject(xlNewSheet8);
                    }
                    #endregion

                    #region AccessoryRate Top 3
                    if (ds.Tables[3].Rows.Count > 0)
                    {
                        var xlNewSheet8 = (Excel.Worksheet)worksheets.Add(worksheets[1], Type.Missing, Type.Missing, Type.Missing);
                        xlNewSheet8.Name = ds.Tables[3].Rows[0]["WorkbookName"].ToString();
                        xlNewSheet8.Cells[1, 1] = "Financial Year";
                        xlNewSheet8.Cells[1, 2] = "Accessory Quality";
                        xlNewSheet8.Cells[1, 3] = "Size";
                        xlNewSheet8.Cells[1, 4] = "Shrinkage";
                        xlNewSheet8.Cells[1, 5] = "Wastage";
                        xlNewSheet8.Cells[1, 6] = "Type";
                        xlNewSheet8.Cells[1, 7] = "SupplierName";
                        xlNewSheet8.Cells[1, 8] = "Rate";
                        xlNewSheet8.Cells[1, 9] = "PO Number";
                        xlNewSheet8.Cells[1, 10] = "Serial Number";
                        xlNewSheet8.Cells[1, 11] = "PODate";
                        xlNewSheet8.Cells[1, 12] = "Unit";

                        int O = 1;
                        foreach (DataRow dr in ds.Tables[3].Rows)
                        {
                            O++;
                            xlNewSheet8.Cells[O, 1] = dr["FinancialYear"] == DBNull.Value ? string.Empty : Convert.ToString(dr["FinancialYear"]);
                            xlNewSheet8.Cells[O, 2] = dr["AccessoryQuality"] == DBNull.Value ? string.Empty : Convert.ToString(dr["AccessoryQuality"]);
                            xlNewSheet8.Cells[O, 3] = dr["Size"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Size"]);
                            xlNewSheet8.Cells[O, 4] = dr["Shrinkage"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Shrinkage"]);
                            xlNewSheet8.Cells[O, 5] = dr["Wastage"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Wastage"]);
                            xlNewSheet8.Cells[O, 6] = dr["Type"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Type"]);
                            xlNewSheet8.Cells[O, 7] = dr["SupplierName"] == DBNull.Value ? string.Empty : Convert.ToString(dr["SupplierName"]);
                            xlNewSheet8.Cells[O, 8] = dr["Rate"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Rate"]);
                            xlNewSheet8.Cells[O, 9] = dr["PO_Number"] == DBNull.Value ? string.Empty : Convert.ToString(dr["PO_Number"]);
                            xlNewSheet8.Cells[O, 10] = dr["SerialNumber"] == DBNull.Value ? string.Empty : Convert.ToString(dr["SerialNumber"]);
                            xlNewSheet8.Cells[O, 11] = dr["PODate"] == DBNull.Value ? string.Empty : Convert.ToString(dr["PODate"]);
                            xlNewSheet8.Cells[O, 12] = dr["Unit"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Unit"]);
                        }
                        xlNewSheet8.Range["B1"].EntireColumn.Font.Bold = true;
                        xlNewSheet8.Range["B1"].EntireColumn.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Blue);  //fabricquality           
                        xlNewSheet8.Range["C2", "C" + O].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                        xlNewSheet8.Range["D2", "D" + O].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                        xlNewSheet8.Range["E2", "E" + O].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;

                        xlNewSheet8.Range["H1"].EntireColumn.Font.Bold = true;
                        xlNewSheet8.Range["H1"].EntireColumn.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.ColorTranslator.FromHtml("#008000")); //Rate

                        xlNewSheet8.Range["A1", "L1"].Font.Color = ColorTranslator.ToOle(System.Drawing.Color.Black);
                        xlNewSheet8.Range["A1", "L1"].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        xlNewSheet8.Range["A1", "L1"].Cells.Font.Bold = true;
                        xlNewSheet8.Range["A1", "L1"].Cells.Font.Size = 12;

                        xlNewSheet8.get_Range("A1:L" + O).Cells.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;

                        xlNewSheet8.Range["K1"].Cells.EntireColumn.NumberFormat = "dd mmm (yyy);@";

                        xlNewSheet8.Range["A1"].Cells.EntireColumn.ColumnWidth = 9.57;
                        xlNewSheet8.Range["B1"].Cells.EntireColumn.ColumnWidth = 45;
                        xlNewSheet8.Range["C1"].Cells.EntireColumn.ColumnWidth = 12.57;
                        xlNewSheet8.Range["D1"].Cells.EntireColumn.ColumnWidth = 11.14;

                        xlNewSheet8.Range["E1"].Cells.EntireColumn.ColumnWidth = 9.14;
                        xlNewSheet8.Range["F1"].Cells.EntireColumn.ColumnWidth = 9.57;

                        xlNewSheet8.Range["G1"].Cells.EntireColumn.ColumnWidth = 18.86;
                        xlNewSheet8.Range["H1"].Cells.EntireColumn.ColumnWidth = 12.29;
                        xlNewSheet8.Range["I1"].Cells.EntireColumn.ColumnWidth = 14;
                        xlNewSheet8.Range["J1"].Cells.EntireColumn.ColumnWidth = 10; //SerialNumber
                        xlNewSheet8.Range["K1"].Cells.EntireColumn.ColumnWidth = 12.43;
                        xlNewSheet8.Range["L1"].Cells.EntireColumn.ColumnWidth = 9;

                        xlNewSheet8.Range["A1", "L1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        xlNewSheet8.Range["A1", "L1"].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        xlNewSheet8.Range["A2", "L" + O].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignTop;

                        xlNewSheet8.Range["A1", "L1"].Cells.WrapText = true;
                        xlNewSheet8.Range["A2", "L" + O].Cells.WrapText = true;

                        Excel.Range firstRow = (Excel.Range)xlNewSheet8.Rows[1];
                        firstRow.AutoFilter(1,
                                            Type.Missing,
                                            Excel.XlAutoFilterOperator.xlAnd,
                                            Type.Missing,
                                            true);
                        releaseObject(xlNewSheet8);
                    }


                    #endregion

                    ((Excel.Worksheet)xlApp.ActiveWorkbook.Sheets[1]).Activate();
                    xlWorkBook.Application.ActiveWindow.SplitRow = 1;
                    xlWorkBook.Application.ActiveWindow.FreezePanes = true;

                }
                #endregion

                #region ReportType :- Daily Fabric Movement
                else if (ReportType == "Daily Fabric Movement")
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        var myExcelWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets[1];

                        myExcelWorkSheet.Name = ds.Tables[0].Rows[0]["WorkbookName"].ToString();

                        int O = 4;
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            O++;
                            myExcelWorkSheet.Cells[O, 1] = dr["Date"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Date"]);
                            myExcelWorkSheet.Cells[O, 2] = dr["Po_number"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Po_number"]);
                            myExcelWorkSheet.Cells[O, 3] = dr["SupplierName"] == DBNull.Value ? string.Empty : Convert.ToString(dr["SupplierName"]);
                            myExcelWorkSheet.Cells[O, 4] = dr["ChallanNo"] == DBNull.Value ? string.Empty : Convert.ToString(dr["ChallanNo"]);
                            myExcelWorkSheet.Cells[O, 5] = dr["InvoiceNo"] == DBNull.Value ? string.Empty : Convert.ToString(dr["InvoiceNo"]);
                            myExcelWorkSheet.Cells[O, 6] = dr["SerialNumber"] == DBNull.Value ? string.Empty : Convert.ToString(dr["SerialNumber"]);
                            myExcelWorkSheet.Cells[O, 7] = dr["FabricQuality"] == DBNull.Value ? string.Empty : Convert.ToString(dr["FabricQuality"]);
                            myExcelWorkSheet.Cells[O, 8] = dr["ColorPrint"] == DBNull.Value ? string.Empty : Convert.ToString(dr["ColorPrint"]);

                            myExcelWorkSheet.Cells[O, 9] = dr["SrvInQtyy"] == DBNull.Value ? string.Empty : Convert.ToString(dr["SrvInQtyy"]);
                            myExcelWorkSheet.Cells[O, 10] = dr["SrvInShortUnitt"] == DBNull.Value ? string.Empty : Convert.ToString(dr["SrvInShortUnitt"]);
                            myExcelWorkSheet.Cells[O, 11] = dr["SrvInStage"] == DBNull.Value ? string.Empty : Convert.ToString(dr["SrvInStage"]);
                            myExcelWorkSheet.Cells[O, 12] = dr["SrvInQty"] == DBNull.Value ? string.Empty : Convert.ToString(dr["SrvInQty"]);
                            myExcelWorkSheet.Cells[O, 13] = dr["SrvInValue"] == DBNull.Value ? string.Empty : Convert.ToString(dr["SrvInValue"]);

                            myExcelWorkSheet.Cells[O, 14] = dr["SrvOutQtyy"] == DBNull.Value ? string.Empty : Convert.ToString(dr["SrvOutQtyy"]);
                            myExcelWorkSheet.Cells[O, 15] = dr["SrvOutShortUnitt"] == DBNull.Value ? string.Empty : Convert.ToString(dr["SrvOutShortUnitt"]);
                            myExcelWorkSheet.Cells[O, 16] = dr["SrvOutStage"] == DBNull.Value ? string.Empty : Convert.ToString(dr["SrvOutStage"]);
                            myExcelWorkSheet.Cells[O, 17] = dr["SrvOutQty"] == DBNull.Value ? string.Empty : Convert.ToString(dr["SrvOutQty"]);
                            myExcelWorkSheet.Cells[O, 18] = dr["SrvOutValue"] == DBNull.Value ? string.Empty : Convert.ToString(dr["SrvOutValue"]);

                            myExcelWorkSheet.Cells[O, 19] = dr["PassQtyStage"] == DBNull.Value ? string.Empty : Convert.ToString(dr["PassQtyStage"]);
                            myExcelWorkSheet.Cells[O, 20] = dr["CheckedQtyy"] == DBNull.Value ? string.Empty : Convert.ToString(dr["CheckedQtyy"]);
                            myExcelWorkSheet.Cells[O, 21] = dr["CheckedQty"] == DBNull.Value ? string.Empty : Convert.ToString(dr["CheckedQty"]);
                            myExcelWorkSheet.Cells[O, 22] = dr["passqtyy"] == DBNull.Value ? string.Empty : Convert.ToString(dr["passqtyy"]);
                            myExcelWorkSheet.Cells[O, 23] = dr["PassQty"] == DBNull.Value ? string.Empty : Convert.ToString(dr["PassQty"]);
                            myExcelWorkSheet.Cells[O, 24] = dr["FailQtyy"] == DBNull.Value ? string.Empty : Convert.ToString(dr["FailQtyy"]);
                            myExcelWorkSheet.Cells[O, 25] = dr["FailQty"] == DBNull.Value ? string.Empty : Convert.ToString(dr["FailQty"]);
                            myExcelWorkSheet.Cells[O, 26] = dr["Remarks"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Remarks"]);

                            myExcelWorkSheet.Cells[O, 27] = dr["IssueQtyy"] == DBNull.Value ? string.Empty : Convert.ToString(dr["IssueQtyy"]);
                            myExcelWorkSheet.Cells[O, 28] = dr["IssueQtyShortUnitt"] == DBNull.Value ? string.Empty : Convert.ToString(dr["IssueQtyShortUnitt"]);
                            myExcelWorkSheet.Cells[O, 29] = dr["IssueStage"] == DBNull.Value ? string.Empty : Convert.ToString(dr["IssueStage"]);
                            myExcelWorkSheet.Cells[O, 30] = dr["IssueQty"] == DBNull.Value ? string.Empty : Convert.ToString(dr["IssueQty"]);
                            myExcelWorkSheet.Cells[O, 31] = dr["IssueQtyValue"] == DBNull.Value ? string.Empty : Convert.ToString(dr["IssueQtyValue"]);

                        }
                        myExcelWorkSheet.Range["G1"].EntireColumn.Font.Bold = true;
                        myExcelWorkSheet.Range["G1"].EntireColumn.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Blue);  //fabricquality

                        myExcelWorkSheet.Range["F1"].EntireColumn.Font.Bold = true;
                        myExcelWorkSheet.Range["F1"].EntireColumn.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Blue); //SerialNumber               

                        myExcelWorkSheet.Range["A1"].Cells.EntireColumn.NumberFormat = "dd mmm (ddd);@";

                        myExcelWorkSheet.get_Range("A5:AE" + O).Cells.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;

                        Excel.Range firstRow = (Excel.Range)myExcelWorkSheet.Range["A4", "AE" + O];
                        firstRow.AutoFilter(1, Type.Missing, Excel.XlAutoFilterOperator.xlAnd, Type.Missing, true);

                        int rng = O + 2;

                        //In BIPL Formula

                        string FormulaForSrvInQtyy = string.Empty;
                        FormulaForSrvInQtyy = "=SUMPRODUCT(SUBTOTAL(109,OFFSET(I5,ROW(I5:I" + O.ToString() + ")-ROW(I5),,1)),--(J5:J" + O.ToString() + "=\"mtr\"))";
                        myExcelWorkSheet.Range["I" + rng].Formula = FormulaForSrvInQtyy;

                        string FormulaForSrvInShortUnitt = string.Empty;
                        FormulaForSrvInShortUnitt = "=SUMPRODUCT(SUBTOTAL(109,OFFSET(I5,ROW(I5:I" + O.ToString() + ")-ROW(I5),,1)),--(J5:J" + O.ToString() + "=\"kg\"))";
                        myExcelWorkSheet.Range["J" + rng].Formula = FormulaForSrvInShortUnitt;

                        string FormulaForSRVIn = string.Empty;
                        FormulaForSRVIn = "=CONCATENATE(IF(I" + rng.ToString() + "=0,\"\",I" + rng.ToString() + "),IF(I" + rng.ToString() + "=0,\" \",\" mtr\"),\" \",IF(J" + rng.ToString() + "=0,\"\",J" + rng.ToString() + "),IF(J" + rng.ToString() + "=0,\"\",\" kg\"))";
                        myExcelWorkSheet.Range["L" + rng].Formula = FormulaForSRVIn;

                        string FormulaForSRVInValue = string.Empty;
                        FormulaForSRVInValue = "=IF(VALUE(SUBTOTAL(9,M5:M" + O.ToString() + "))=0,\"\",SUBTOTAL(9,M5:M" + O.ToString() + "))";
                        myExcelWorkSheet.Range["M" + rng].Formula = FormulaForSRVInValue;
                        myExcelWorkSheet.Range["M1"].EntireColumn.NumberFormat = "₹ #,##0";

                        //Out Of BIPL Formula

                        string FormulaForSrvOutQtyy = string.Empty;
                        FormulaForSrvOutQtyy = "=SUMPRODUCT(SUBTOTAL(109,OFFSET(N5,ROW(N5:N" + O.ToString() + ")-ROW(N5),,1)),--(O5:O" + O.ToString() + "=\"mtr\"))";
                        myExcelWorkSheet.Range["N" + rng].Formula = FormulaForSrvOutQtyy;

                        string FormulaForSrvOutShortUnitt = string.Empty;
                        FormulaForSrvOutShortUnitt = "=SUMPRODUCT(SUBTOTAL(109,OFFSET(N5,ROW(N5:N" + O.ToString() + ")-ROW(N5),,1)),--(O5:O" + O.ToString() + "=\"kg\"))";
                        myExcelWorkSheet.Range["O" + rng].Formula = FormulaForSrvOutShortUnitt;

                        string FormulaForSrvOutQty = string.Empty;
                        FormulaForSrvOutQty = "=CONCATENATE(IF(N" + rng.ToString() + "=0,\"\",N" + rng.ToString() + "),IF(N" + rng.ToString() + "=0,\" \",\" mtr\"),\" \",IF(O" + rng.ToString() + "=0,\"\",O" + rng.ToString() + "),IF(O" + rng.ToString() + "=0,\"\",\" kg\"))";
                        myExcelWorkSheet.Range["Q" + rng].Formula = FormulaForSrvOutQty;

                        string FormulaForSrvOutValue = string.Empty;
                        FormulaForSrvOutValue = "=IF(VALUE(SUBTOTAL(9,R5:R" + O.ToString() + "))=0,\"\",SUBTOTAL(9,R5:R" + O.ToString() + "))";
                        myExcelWorkSheet.Range["R" + rng].Formula = FormulaForSrvOutValue;
                        myExcelWorkSheet.Range["R1"].EntireColumn.NumberFormat = "₹ #,##0";

                        //PassQty Formula

                        string FormulaForCheckedQtyy = string.Empty;
                        FormulaForCheckedQtyy = "=SUBTOTAL(9,T5:T" + O.ToString() + ")";
                        myExcelWorkSheet.Range["T" + rng].Formula = FormulaForCheckedQtyy;

                        string FormulaForCheckedQty = string.Empty;
                        FormulaForCheckedQty = "=CONCATENATE(IF(T" + rng.ToString() + "=0,\"\",T" + rng.ToString() + "),IF(T" + rng.ToString() + "=0,\"\",\" mtr\"))";
                        myExcelWorkSheet.Range["U" + rng].Formula = FormulaForCheckedQty;

                        string FormulaForpassqtyy = string.Empty;
                        FormulaForpassqtyy = "=SUBTOTAL(9,V5:V" + O.ToString() + ")";
                        myExcelWorkSheet.Range["V" + rng].Formula = FormulaForpassqtyy;

                        string FormulaForpassqty = string.Empty;
                        FormulaForpassqty = "=CONCATENATE(IF(V" + rng.ToString() + "=0,\"\",V" + rng.ToString() + "),IF(V" + rng.ToString() + "=0,\"\",\" mtr\"))";
                        myExcelWorkSheet.Range["W" + rng].Formula = FormulaForpassqty;

                        string FormulaForFailQtyy = string.Empty;
                        FormulaForFailQtyy = "=SUBTOTAL(9,X5:X" + O.ToString() + ")";
                        myExcelWorkSheet.Range["X" + rng].Formula = FormulaForFailQtyy;

                        string FormulaForFailQty = string.Empty;
                        FormulaForFailQty = "=CONCATENATE(IF(X" + rng.ToString() + "=0,\"\",X" + rng.ToString() + "),IF(X" + rng.ToString() + "=0,\"\",\" mtr\"))";
                        myExcelWorkSheet.Range["Y" + rng].Formula = FormulaForFailQty;

                        //In Cutting Formula

                        string FormulaForIssueQtyy = string.Empty;
                        FormulaForIssueQtyy = "=SUMPRODUCT(SUBTOTAL(109,OFFSET(AA5,ROW(AA5:AA" + O.ToString() + ")-ROW(AA5),,1)),--(AB5:AB" + O.ToString() + "=\"mtr\"))";
                        myExcelWorkSheet.Range["AA" + rng].Formula = FormulaForIssueQtyy;

                        string FormulaForIssueQtyShortUnitt = string.Empty;
                        FormulaForIssueQtyShortUnitt = "=SUMPRODUCT(SUBTOTAL(109,OFFSET(AA5,ROW(AA5:AA" + O.ToString() + ")-ROW(AA5),,1)),--(AB5:AB" + O.ToString() + "=\"kg\"))";
                        myExcelWorkSheet.Range["AB" + rng].Formula = FormulaForIssueQtyShortUnitt;

                        string FormulaForIssueQty = string.Empty;
                        FormulaForIssueQty = "=CONCATENATE(IF(AA" + rng.ToString() + "=0,\"\",AA" + rng.ToString() + "),IF(AA" + rng.ToString() + "=0,\" \",\" mtr\"),\" \",IF(AB" + rng.ToString() + "=0,\"\",AB" + rng.ToString() + "),IF(AB" + rng.ToString() + "=0,\"\",\" kg\"))";
                        myExcelWorkSheet.Range["AD" + rng].Formula = FormulaForIssueQty;

                        string FormulaForIssueQtyValue = string.Empty;
                        FormulaForIssueQtyValue = "=IF(VALUE(SUBTOTAL(9,AE5:AE" + O.ToString() + "))=0,\"\",SUBTOTAL(9,AE5:AE" + O.ToString() + "))";
                        myExcelWorkSheet.Range["AE" + rng].Formula = FormulaForIssueQtyValue;
                        myExcelWorkSheet.Range["AE1"].EntireColumn.NumberFormat = "₹ #,##0";

                        myExcelWorkSheet.Cells[rng, 11] = "Total";
                        myExcelWorkSheet.Cells[rng, 16] = "Total";
                        myExcelWorkSheet.Cells[rng, 19] = "Total";
                        myExcelWorkSheet.Cells[rng, 29] = "Total";

                        myExcelWorkSheet.Range["K" + rng].Cells.Font.Bold = true;
                        myExcelWorkSheet.Range["L" + rng].Cells.Font.Bold = true;
                        myExcelWorkSheet.Range["M" + rng].Cells.Font.Bold = true;

                        myExcelWorkSheet.Range["P" + rng].Cells.Font.Bold = true;
                        myExcelWorkSheet.Range["Q" + rng].Cells.Font.Bold = true;
                        myExcelWorkSheet.Range["R" + rng].Cells.Font.Bold = true;

                        myExcelWorkSheet.Range["S" + rng].Cells.Font.Bold = true;
                        myExcelWorkSheet.Range["U" + rng].Cells.Font.Bold = true;
                        myExcelWorkSheet.Range["W" + rng].Cells.Font.Bold = true;
                        myExcelWorkSheet.Range["Y" + rng].Cells.Font.Bold = true;

                        myExcelWorkSheet.Range["AC" + rng].Cells.Font.Bold = true;
                        myExcelWorkSheet.Range["AD" + rng].Cells.Font.Bold = true;
                        myExcelWorkSheet.Range["AE" + rng].Cells.Font.Bold = true;

                        myExcelWorkSheet.Range["A5", "AE" + O].Cells.WrapText = true;

                        myExcelWorkSheet.Range["I1"].Columns.Hidden = true;
                        myExcelWorkSheet.Range["J1"].Columns.Hidden = true;

                        myExcelWorkSheet.Range["N1"].Columns.Hidden = true;
                        myExcelWorkSheet.Range["O1"].Columns.Hidden = true;

                        myExcelWorkSheet.Range["T1"].Columns.Hidden = true;
                        myExcelWorkSheet.Range["V1"].Columns.Hidden = true;
                        myExcelWorkSheet.Range["X1"].Columns.Hidden = true;

                        myExcelWorkSheet.Range["AA1"].Columns.Hidden = true;
                        myExcelWorkSheet.Range["AB1"].Columns.Hidden = true;


                        myExcelWorkSheet.Range["A4"].Cells.EntireColumn.ColumnWidth = 12.14;
                        myExcelWorkSheet.Range["B4"].Cells.EntireColumn.ColumnWidth = 10.71;
                        myExcelWorkSheet.Range["C4"].Cells.EntireColumn.ColumnWidth = 28;
                        myExcelWorkSheet.Range["D4"].Cells.EntireColumn.ColumnWidth = 14.43;
                        myExcelWorkSheet.Range["E4"].Cells.EntireColumn.ColumnWidth = 14.43;
                        myExcelWorkSheet.Range["F4"].Cells.EntireColumn.ColumnWidth = 12.29;
                        myExcelWorkSheet.Range["G4"].Cells.EntireColumn.ColumnWidth = 20;
                        myExcelWorkSheet.Range["H4"].Cells.EntireColumn.ColumnWidth = 15.43;

                        myExcelWorkSheet.Range["K4"].Cells.EntireColumn.ColumnWidth = 11.43;
                        myExcelWorkSheet.Range["L4"].Cells.EntireColumn.ColumnWidth = 9.86;
                        myExcelWorkSheet.Range["M4"].Cells.EntireColumn.ColumnWidth = 12.71;

                        myExcelWorkSheet.Range["P4"].Cells.EntireColumn.ColumnWidth = 11.43;
                        myExcelWorkSheet.Range["Q4"].Cells.EntireColumn.ColumnWidth = 9.86;
                        myExcelWorkSheet.Range["R4"].Cells.EntireColumn.ColumnWidth = 12.71;

                        myExcelWorkSheet.Range["S4"].Cells.EntireColumn.ColumnWidth = 11.43;
                        myExcelWorkSheet.Range["U4"].Cells.EntireColumn.ColumnWidth = 9.86;
                        myExcelWorkSheet.Range["W4"].Cells.EntireColumn.ColumnWidth = 9.86;
                        myExcelWorkSheet.Range["Y4"].Cells.EntireColumn.ColumnWidth = 9.86;
                        myExcelWorkSheet.Range["Z4"].Cells.EntireColumn.ColumnWidth = 13;

                        myExcelWorkSheet.Range["AC4"].Cells.EntireColumn.ColumnWidth = 11.43;
                        myExcelWorkSheet.Range["AD4"].Cells.EntireColumn.ColumnWidth = 9.86;
                        myExcelWorkSheet.Range["AE4"].Cells.EntireColumn.ColumnWidth = 12.71;

                        myExcelWorkSheet.Range["D5", "D" + O].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                        myExcelWorkSheet.Range["A5", "AE" + O].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignTop;

                        myExcelWorkSheet.Range["K" + rng].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        myExcelWorkSheet.Range["P" + rng].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        myExcelWorkSheet.Range["S" + rng].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        myExcelWorkSheet.Range["AC" + rng].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);

                        myExcelWorkSheet.Range["K" + rng, "AE" + rng].Cells.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;

                        myExcelWorkSheet.Range["M1"].EntireColumn.Font.Bold = true;
                        myExcelWorkSheet.Range["M1"].EntireColumn.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.ColorTranslator.FromHtml("#808080"));

                        myExcelWorkSheet.Range["R1"].EntireColumn.Font.Bold = true;
                        myExcelWorkSheet.Range["R1"].EntireColumn.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.ColorTranslator.FromHtml("#808080"));

                        myExcelWorkSheet.Range["AE1"].EntireColumn.Font.Bold = true;
                        myExcelWorkSheet.Range["AE1"].EntireColumn.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.ColorTranslator.FromHtml("#808080"));

                        myExcelWorkSheet.Range["F4", "G4"].Font.Color = ColorTranslator.ToOle(System.Drawing.Color.Black);
                        myExcelWorkSheet.Range["M4"].Cells.Font.Color = ColorTranslator.ToOle(System.Drawing.Color.Black);
                        myExcelWorkSheet.Range["R4"].Cells.Font.Color = ColorTranslator.ToOle(System.Drawing.Color.Black);
                        myExcelWorkSheet.Range["AE4"].Cells.Font.Color = ColorTranslator.ToOle(System.Drawing.Color.Black);

                        releaseObject(myExcelWorkSheet);
                    }

                }
                #endregion

                #region ReportType :- Daily Accessory Movement
                else if (ReportType == "Daily Accessory Movement")
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        var myExcelWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets[1];

                        myExcelWorkSheet.Name = ds.Tables[0].Rows[0]["WorkbookName"].ToString();

                        int O = 4;
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            O++;
                            myExcelWorkSheet.Cells[O, 1] = dr["Date"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Date"]);
                            myExcelWorkSheet.Cells[O, 2] = dr["Po_number"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Po_number"]);
                            myExcelWorkSheet.Cells[O, 3] = dr["SupplierName"] == DBNull.Value ? string.Empty : Convert.ToString(dr["SupplierName"]);
                            myExcelWorkSheet.Cells[O, 4] = dr["ChallanNo"] == DBNull.Value ? string.Empty : Convert.ToString(dr["ChallanNo"]);
                            myExcelWorkSheet.Cells[O, 5] = dr["InvoiceNo"] == DBNull.Value ? string.Empty : Convert.ToString(dr["InvoiceNo"]);
                            myExcelWorkSheet.Cells[O, 6] = dr["SerialNumber"] == DBNull.Value ? string.Empty : Convert.ToString(dr["SerialNumber"]);
                            myExcelWorkSheet.Cells[O, 7] = dr["AccessoryQuality"] == DBNull.Value ? string.Empty : Convert.ToString(dr["AccessoryQuality"]);
                            myExcelWorkSheet.Cells[O, 8] = dr["Size"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Size"]);
                            myExcelWorkSheet.Cells[O, 9] = dr["ColorPrint"] == DBNull.Value ? string.Empty : Convert.ToString(dr["ColorPrint"]);

                            myExcelWorkSheet.Cells[O, 10] = dr["SrvInQtyy"] == DBNull.Value ? string.Empty : Convert.ToString(dr["SrvInQtyy"]);
                            myExcelWorkSheet.Cells[O, 11] = dr["SrvInShortUnitt"] == DBNull.Value ? string.Empty : Convert.ToString(dr["SrvInShortUnitt"]);
                            myExcelWorkSheet.Cells[O, 12] = dr["SrvInStage"] == DBNull.Value ? string.Empty : Convert.ToString(dr["SrvInStage"]);
                            myExcelWorkSheet.Cells[O, 13] = dr["SrvInQty"] == DBNull.Value ? string.Empty : Convert.ToString(dr["SrvInQty"]);
                            myExcelWorkSheet.Cells[O, 14] = dr["SrvInValue"] == DBNull.Value ? string.Empty : Convert.ToString(dr["SrvInValue"]);

                            myExcelWorkSheet.Cells[O, 15] = dr["SrvOutQtyy"] == DBNull.Value ? string.Empty : Convert.ToString(dr["SrvOutQtyy"]);
                            myExcelWorkSheet.Cells[O, 16] = dr["SrvOutShortUnitt"] == DBNull.Value ? string.Empty : Convert.ToString(dr["SrvOutShortUnitt"]);
                            myExcelWorkSheet.Cells[O, 17] = dr["SrvOutStage"] == DBNull.Value ? string.Empty : Convert.ToString(dr["SrvOutStage"]);
                            myExcelWorkSheet.Cells[O, 18] = dr["SrvOutQty"] == DBNull.Value ? string.Empty : Convert.ToString(dr["SrvOutQty"]);
                            myExcelWorkSheet.Cells[O, 19] = dr["SrvOutValue"] == DBNull.Value ? string.Empty : Convert.ToString(dr["SrvOutValue"]);

                            myExcelWorkSheet.Cells[O, 20] = dr["PassQtyStage"] == DBNull.Value ? string.Empty : Convert.ToString(dr["PassQtyStage"]);

                            myExcelWorkSheet.Cells[O, 21] = dr["CheckedQtyy"] == DBNull.Value ? string.Empty : Convert.ToString(dr["CheckedQtyy"]);
                            myExcelWorkSheet.Cells[O, 22] = dr["CheckedQtyShortUnit"] == DBNull.Value ? string.Empty : Convert.ToString(dr["CheckedQtyShortUnit"]);
                            myExcelWorkSheet.Cells[O, 23] = dr["CheckedQty"] == DBNull.Value ? string.Empty : Convert.ToString(dr["CheckedQty"]);
                            //myExcelWorkSheet.Cells[O, 24] = dr["CheckedValue"] == DBNull.Value ? string.Empty : Convert.ToString(dr["CheckedValue"]);

                            myExcelWorkSheet.Cells[O, 25] = dr["passqtyy"] == DBNull.Value ? string.Empty : Convert.ToString(dr["passqtyy"]);
                            myExcelWorkSheet.Cells[O, 26] = dr["PassQtyShortUnit"] == DBNull.Value ? string.Empty : Convert.ToString(dr["PassQtyShortUnit"]);
                            myExcelWorkSheet.Cells[O, 27] = dr["PassQty"] == DBNull.Value ? string.Empty : Convert.ToString(dr["PassQty"]);
                            //myExcelWorkSheet.Cells[O, 28] = dr["PassedValue"] == DBNull.Value ? string.Empty : Convert.ToString(dr["PassedValue"]);

                            myExcelWorkSheet.Cells[O, 29] = dr["FailQtyy"] == DBNull.Value ? string.Empty : Convert.ToString(dr["FailQtyy"]);
                            myExcelWorkSheet.Cells[O, 30] = dr["FailQtyShortUnit"] == DBNull.Value ? string.Empty : Convert.ToString(dr["FailQtyShortUnit"]);
                            myExcelWorkSheet.Cells[O, 31] = dr["FailQty"] == DBNull.Value ? string.Empty : Convert.ToString(dr["FailQty"]);
                            //myExcelWorkSheet.Cells[O, 32] = dr["FailValue"] == DBNull.Value ? string.Empty : Convert.ToString(dr["FailValue"]);

                            myExcelWorkSheet.Cells[O, 33] = dr["Remarks"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Remarks"]);

                            myExcelWorkSheet.Cells[O, 34] = dr["IssueQtyy"] == DBNull.Value ? string.Empty : Convert.ToString(dr["IssueQtyy"]);
                            myExcelWorkSheet.Cells[O, 35] = dr["IssueQtyShortUnitt"] == DBNull.Value ? string.Empty : Convert.ToString(dr["IssueQtyShortUnitt"]);
                            myExcelWorkSheet.Cells[O, 36] = dr["IssueStage"] == DBNull.Value ? string.Empty : Convert.ToString(dr["IssueStage"]);
                            myExcelWorkSheet.Cells[O, 37] = dr["IssueQty"] == DBNull.Value ? string.Empty : Convert.ToString(dr["IssueQty"]);
                            myExcelWorkSheet.Cells[O, 38] = dr["IssueQtyValue"] == DBNull.Value ? string.Empty : Convert.ToString(dr["IssueQtyValue"]);
                        }

                        myExcelWorkSheet.Range["G1"].EntireColumn.Font.Bold = true;
                        myExcelWorkSheet.Range["G1"].EntireColumn.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Blue);  //fabricquality

                        myExcelWorkSheet.Range["F1"].EntireColumn.Font.Bold = true;
                        myExcelWorkSheet.Range["F1"].EntireColumn.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Blue); //SerialNumber               

                        myExcelWorkSheet.Range["A1"].Cells.EntireColumn.NumberFormat = "dd mmm (ddd);@";

                        myExcelWorkSheet.get_Range("A5:AL" + O).Cells.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;

                        Excel.Range firstRow = (Excel.Range)myExcelWorkSheet.Range["A4", "AL" + O];
                        firstRow.AutoFilter(1, Type.Missing, Excel.XlAutoFilterOperator.xlAnd, Type.Missing, true);

                        int rng = O + 2;

                        //---------------------------------------------------------------
                        DataTable dt = ds.Tables[1];
                        List<string> distinctValues = new List<string>();
                        foreach (DataRow row in dt.Rows)
                        {
                            string unit = row["unit"].ToString();
                            if (!distinctValues.Contains(unit))
                            {
                                distinctValues.Add(unit);
                            }
                        }
                        string[] units = distinctValues.ToArray();
                        //---------------------------------------------------------------

                        string Formula = "";

                        //SRVIN Formula
                        Formula = GetCommaSeparatedValue_ExcelFormula("J", "K", "5", O.ToString(), units);
                        myExcelWorkSheet.Range["J" + rng].Formula = Formula;
                        string FormulaForSRVIn = string.Empty;
                        FormulaForSRVIn = "=IF(RIGHT(J" + rng + ",1)=\",\",LEFT(J" + rng + ",LEN(J" + rng + ")-1),J" + rng + ")";
                        myExcelWorkSheet.Range["M" + rng].Formula = FormulaForSRVIn;

                        string FormulaForSRVInValue = string.Empty;
                        FormulaForSRVInValue = "=IF(VALUE(SUBTOTAL(9,N5:N" + O.ToString() + "))=0,\"\",SUBTOTAL(9,N5:N" + O.ToString() + "))";
                        myExcelWorkSheet.Range["N" + rng].Formula = FormulaForSRVInValue;
                        myExcelWorkSheet.Range["N1"].EntireColumn.NumberFormat = "₹ #,##0";

                        //Out Of BIPL Formula
                        Formula = GetCommaSeparatedValue_ExcelFormula("O", "P", "5", O.ToString(), units);
                        myExcelWorkSheet.Range["O" + rng].Formula = Formula;
                        string FormulaForSrvOutQty = string.Empty;
                        FormulaForSrvOutQty = "=IF(RIGHT(O" + rng + ",1)=\",\",LEFT(O" + rng + ",LEN(O" + rng + ")-1),O" + rng + ")";
                        myExcelWorkSheet.Range["R" + rng].Formula = FormulaForSrvOutQty;

                        string FormulaForSrvOutValue = string.Empty;
                        FormulaForSrvOutValue = "=IF(VALUE(SUBTOTAL(9,S5:S" + O.ToString() + "))=0,\"\",SUBTOTAL(9,S5:S" + O.ToString() + "))";
                        myExcelWorkSheet.Range["S" + rng].Formula = FormulaForSrvOutValue;
                        myExcelWorkSheet.Range["S1"].EntireColumn.NumberFormat = "₹ #,##0";

                        //CheckedQty Formula
                        Formula = GetCommaSeparatedValue_ExcelFormula("U", "V", "5", O.ToString(), units);
                        myExcelWorkSheet.Range["U" + rng].Formula = Formula;
                        string FormulaForCheckedQtyy = string.Empty;
                        FormulaForCheckedQtyy = "=IF(RIGHT(U" + rng + ",1)=\",\",LEFT(U" + rng + ",LEN(U" + rng + ")-1),U" + rng + ")";
                        myExcelWorkSheet.Range["W" + rng].Formula = FormulaForCheckedQtyy;

                        //X For Value

                        //PassQty Formula
                        Formula = GetCommaSeparatedValue_ExcelFormula("Y", "Z", "5", O.ToString(), units);
                        myExcelWorkSheet.Range["Y" + rng].Formula = Formula;
                        string FormulaForpassqtyy = string.Empty;
                        FormulaForpassqtyy = "=IF(RIGHT(Y" + rng + ",1)=\",\",LEFT(Y" + rng + ",LEN(Y" + rng + ")-1),Y" + rng + ")";
                        myExcelWorkSheet.Range["AA" + rng].Formula = FormulaForpassqtyy;

                        //AB For Value

                        //FailQty Formula
                        Formula = GetCommaSeparatedValue_ExcelFormula("AC", "AD", "5", O.ToString(), units);
                        myExcelWorkSheet.Range["AC" + rng].Formula = Formula;
                        string FormulaForFailQtyy = string.Empty;
                        FormulaForFailQtyy = "=IF(RIGHT(AC" + rng + ",1)=\",\",LEFT(AC" + rng + ",LEN(AC" + rng + ")-1),AC" + rng + ")";
                        myExcelWorkSheet.Range["AE" + rng].Formula = FormulaForFailQtyy;

                        //AF For Value
                        //AG For Remarks

                        //In Cutting Formula
                        Formula = GetCommaSeparatedValue_ExcelFormula("AH", "AI", "5", O.ToString(), units);
                        myExcelWorkSheet.Range["AH" + rng].Formula = Formula;
                        string FormulaForIssueQtyy = string.Empty;
                        FormulaForIssueQtyy = "=IF(RIGHT(AH" + rng + ",1)=\",\",LEFT(AH" + rng + ",LEN(AH" + rng + ")-1),AH" + rng + ")";
                        myExcelWorkSheet.Range["AK" + rng].Formula = FormulaForIssueQtyy;

                        string FormulaForIssueQtyValue = string.Empty;
                        FormulaForIssueQtyValue = "=IF(VALUE(SUBTOTAL(9,AL5:AL" + O.ToString() + "))=0,\"\",SUBTOTAL(9,AL5:AL" + O.ToString() + "))";
                        myExcelWorkSheet.Range["AL" + rng].Formula = FormulaForIssueQtyValue;
                        myExcelWorkSheet.Range["AL1"].EntireColumn.NumberFormat = "₹ #,##0";

                        myExcelWorkSheet.Cells[rng, 12] = "Total";
                        myExcelWorkSheet.Cells[rng, 17] = "Total";
                        myExcelWorkSheet.Cells[rng, 20] = "Total";
                        myExcelWorkSheet.Cells[rng, 36] = "Total";

                        myExcelWorkSheet.Range["L" + rng].Cells.Font.Bold = true;
                        myExcelWorkSheet.Range["M" + rng].Cells.Font.Bold = true;
                        myExcelWorkSheet.Range["N" + rng].Cells.Font.Bold = true;

                        myExcelWorkSheet.Range["Q" + rng].Cells.Font.Bold = true;
                        myExcelWorkSheet.Range["R" + rng].Cells.Font.Bold = true;
                        myExcelWorkSheet.Range["S" + rng].Cells.Font.Bold = true;

                        myExcelWorkSheet.Range["T" + rng].Cells.Font.Bold = true;
                        myExcelWorkSheet.Range["W" + rng].Cells.Font.Bold = true;
                        myExcelWorkSheet.Range["AA" + rng].Cells.Font.Bold = true;
                        myExcelWorkSheet.Range["AE" + rng].Cells.Font.Bold = true;

                        myExcelWorkSheet.Range["AI" + rng].Cells.Font.Bold = true;
                        myExcelWorkSheet.Range["AJ" + rng].Cells.Font.Bold = true;
                        myExcelWorkSheet.Range["AK" + rng].Cells.Font.Bold = true;

                        myExcelWorkSheet.Range["A5", "AL" + O].Cells.WrapText = true;

                        myExcelWorkSheet.Range["J1"].Columns.Hidden = true;
                        myExcelWorkSheet.Range["K1"].Columns.Hidden = true;

                        myExcelWorkSheet.Range["O1"].Columns.Hidden = true;
                        myExcelWorkSheet.Range["P1"].Columns.Hidden = true;

                        myExcelWorkSheet.Range["U1"].Columns.Hidden = true;
                        myExcelWorkSheet.Range["V1"].Columns.Hidden = true;
                        myExcelWorkSheet.Range["X1"].Columns.Hidden = true;

                        myExcelWorkSheet.Range["Y1"].Columns.Hidden = true;
                        myExcelWorkSheet.Range["Z1"].Columns.Hidden = true;
                        myExcelWorkSheet.Range["AB1"].Columns.Hidden = true;

                        myExcelWorkSheet.Range["AC1"].Columns.Hidden = true;
                        myExcelWorkSheet.Range["AD1"].Columns.Hidden = true;
                        myExcelWorkSheet.Range["AF1"].Columns.Hidden = true;

                        myExcelWorkSheet.Range["AH1"].Columns.Hidden = true;
                        myExcelWorkSheet.Range["AI1"].Columns.Hidden = true;

                        //myExcelWorkSheet.Range["A4"].Cells.EntireColumn.ColumnWidth = 12.14;

                        myExcelWorkSheet.Range["D5", "D" + O].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                        myExcelWorkSheet.Range["A5", "AE" + O].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignTop;

                        myExcelWorkSheet.Range["L" + rng].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        myExcelWorkSheet.Range["Q" + rng].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        myExcelWorkSheet.Range["T" + rng].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        myExcelWorkSheet.Range["AJ" + rng].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);

                        myExcelWorkSheet.Range["L" + rng, "AL" + rng].Cells.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;

                        myExcelWorkSheet.Range["N1"].EntireColumn.Font.Bold = true;
                        myExcelWorkSheet.Range["N1"].EntireColumn.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.ColorTranslator.FromHtml("#808080"));
                        myExcelWorkSheet.Range["S1"].EntireColumn.Font.Bold = true;
                        myExcelWorkSheet.Range["S1"].EntireColumn.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.ColorTranslator.FromHtml("#808080"));
                        myExcelWorkSheet.Range["AL1"].EntireColumn.Font.Bold = true;
                        myExcelWorkSheet.Range["AL1"].EntireColumn.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.ColorTranslator.FromHtml("#808080"));

                        myExcelWorkSheet.Range["F4", "G4"].Font.Color = ColorTranslator.ToOle(System.Drawing.Color.Black);
                        myExcelWorkSheet.Range["N4"].Cells.Font.Color = ColorTranslator.ToOle(System.Drawing.Color.Black);
                        myExcelWorkSheet.Range["S4"].Cells.Font.Color = ColorTranslator.ToOle(System.Drawing.Color.Black);
                        myExcelWorkSheet.Range["AL4"].Cells.Font.Color = ColorTranslator.ToOle(System.Drawing.Color.Black);

                        releaseObject(myExcelWorkSheet);
                    }

                }
                #endregion

                #region ReportType :- Stock Summary Excel
                else if (ReportType == "Stock Summary Excel")
                {
                    int WorkBookCount = 0;
                    foreach (DataTable dt in ds.Tables)
                    {
                        WorkBookCount++;

                        var myExcelWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets[WorkBookCount];

                        int O = 2;
                        if (dt.Rows.Count > 0)
                        {
                            int SupplyTypeId = 0;
                            foreach (DataRow dr in dt.Rows)
                            {
                                O++;
                                SupplyTypeId = dr["SupplyTypeId"] == DBNull.Value ? 0 : Convert.ToInt32(dr["SupplyTypeId"]);

                                myExcelWorkSheet.Cells[O, 1] = dr["FabricQuality"] == DBNull.Value ? string.Empty : Convert.ToString(dr["FabricQuality"]);
                                myExcelWorkSheet.Cells[O, 2] = dr["CountConstruction"] == DBNull.Value ? string.Empty : Convert.ToString(dr["CountConstruction"]);
                                myExcelWorkSheet.Cells[O, 3] = dr["GSM"] == DBNull.Value ? string.Empty : Convert.ToString(dr["GSM"]);
                                myExcelWorkSheet.Cells[O, 4] = dr["Width"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Width"]);

                                myExcelWorkSheet.Cells[O, 5] = dr["ColorPrint"] == DBNull.Value ? string.Empty : Convert.ToString(dr["ColorPrint"]);
                                myExcelWorkSheet.Cells[O, 6] = dr["ShortUnit"] == DBNull.Value ? string.Empty : Convert.ToString(dr["ShortUnit"]);

                                myExcelWorkSheet.Cells[O, 7] = dr["GlobalStock_Qty"] == DBNull.Value ? string.Empty : Convert.ToString(dr["GlobalStock_Qty"]);
                                myExcelWorkSheet.Cells[O, 8] = dr["GlobalStock_Value"] == DBNull.Value ? string.Empty : Convert.ToString(dr["GlobalStock_Value"]);

                                myExcelWorkSheet.Cells[O, 9] = dr["WithProcessor_Qty"] == DBNull.Value ? string.Empty : Convert.ToString(dr["WithProcessor_Qty"]);
                                myExcelWorkSheet.Cells[O, 10] = dr["WithProcessor_Value"] == DBNull.Value ? string.Empty : Convert.ToString(dr["WithProcessor_Value"]);

                                myExcelWorkSheet.Cells[O, 11] = dr["SRVInInspection_Qty"] == DBNull.Value ? string.Empty : Convert.ToString(dr["SRVInInspection_Qty"]);
                                myExcelWorkSheet.Cells[O, 12] = dr["SRVInInspection_Value"] == DBNull.Value ? string.Empty : Convert.ToString(dr["SRVInInspection_Value"]);

                                myExcelWorkSheet.Cells[O, 13] = dr["PassStock_Qty"] == DBNull.Value ? string.Empty : Convert.ToString(dr["PassStock_Qty"]);
                                myExcelWorkSheet.Cells[O, 14] = dr["PassStock_Value"] == DBNull.Value ? string.Empty : Convert.ToString(dr["PassStock_Value"]);

                                myExcelWorkSheet.Cells[O, 15] = dr["FailedStock_Qty"] == DBNull.Value ? string.Empty : Convert.ToString(dr["FailedStock_Qty"]);
                                myExcelWorkSheet.Cells[O, 16] = dr["FailedStock_value"] == DBNull.Value ? string.Empty : Convert.ToString(dr["FailedStock_value"]);
                                myExcelWorkSheet.Cells[O, 17] = dr["DebitRaised_Qty"] == DBNull.Value ? string.Empty : Convert.ToString(dr["DebitRaised_Qty"]);

                            }


                            myExcelWorkSheet.Range["A3", "Q" + O].VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignTop;
                            myExcelWorkSheet.Range["E2", "E" + O].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;

                            myExcelWorkSheet.Range["A3", "A" + O].Cells.Font.Bold = true;
                            myExcelWorkSheet.Range["A3", "A" + O].Cells.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Blue);  //fabricquality
                            myExcelWorkSheet.Range["A3", "Q" + O].Cells.WrapText = true;

                            myExcelWorkSheet.get_Range("A3:Q" + O).Cells.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;  // For Border                            

                            int rng = O + 2;
                            //formula Start
                            myExcelWorkSheet.Cells[rng, 6] = "Total";
                            myExcelWorkSheet.Range["F" + rng].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);

                            string ColName = "";

                            ColName = "G";
                            myExcelWorkSheet.Range[ColName + rng].Formula = "=IF(SUBTOTAL(9," + ColName + "3:" + ColName + "" + O.ToString() + ")=0,\"\",SUBTOTAL(9," + ColName + "3:" + ColName + "" + O.ToString() + "))";
                            myExcelWorkSheet.Range[ColName + "1"].EntireColumn.NumberFormat = "#,##0";

                            ColName = "H";
                            myExcelWorkSheet.Range[ColName + rng].Formula = "=IF(SUBTOTAL(9," + ColName + "3:" + ColName + "" + O.ToString() + ")=0,\"\",SUBTOTAL(9," + ColName + "3:" + ColName + "" + O.ToString() + "))";
                            myExcelWorkSheet.Range[ColName + "1"].EntireColumn.NumberFormat = "₹ #,##0";
                            myExcelWorkSheet.Range[ColName + "1"].EntireColumn.Font.Bold = true;
                            myExcelWorkSheet.Range[ColName + "1"].EntireColumn.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.ColorTranslator.FromHtml("#808080"));

                            ColName = "I";
                            myExcelWorkSheet.Range[ColName + rng].Formula = "=IF(SUBTOTAL(9," + ColName + "3:" + ColName + "" + O.ToString() + ")=0,\"\",SUBTOTAL(9," + ColName + "3:" + ColName + "" + O.ToString() + "))";
                            myExcelWorkSheet.Range[ColName + "1"].EntireColumn.NumberFormat = "#,##0";

                            ColName = "J";
                            myExcelWorkSheet.Range[ColName + rng].Formula = "=IF(SUBTOTAL(9," + ColName + "3:" + ColName + "" + O.ToString() + ")=0,\"\",SUBTOTAL(9," + ColName + "3:" + ColName + "" + O.ToString() + "))";
                            myExcelWorkSheet.Range[ColName + "1"].EntireColumn.NumberFormat = "₹ #,##0";
                            myExcelWorkSheet.Range[ColName + "1"].EntireColumn.Font.Bold = true;
                            myExcelWorkSheet.Range[ColName + "1"].EntireColumn.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.ColorTranslator.FromHtml("#808080"));

                            ColName = "K";
                            myExcelWorkSheet.Range[ColName + rng].Formula = "=IF(SUBTOTAL(9," + ColName + "3:" + ColName + "" + O.ToString() + ")=0,\"\",SUBTOTAL(9," + ColName + "3:" + ColName + "" + O.ToString() + "))";
                            myExcelWorkSheet.Range[ColName + "1"].EntireColumn.NumberFormat = "#,##0";

                            ColName = "L";
                            myExcelWorkSheet.Range[ColName + rng].Formula = "=IF(SUBTOTAL(9," + ColName + "3:" + ColName + "" + O.ToString() + ")=0,\"\",SUBTOTAL(9," + ColName + "3:" + ColName + "" + O.ToString() + "))";
                            myExcelWorkSheet.Range[ColName + "1"].EntireColumn.NumberFormat = "₹ #,##0";
                            myExcelWorkSheet.Range[ColName + "1"].EntireColumn.Font.Bold = true;
                            myExcelWorkSheet.Range[ColName + "1"].EntireColumn.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.ColorTranslator.FromHtml("#808080"));

                            ColName = "M";
                            myExcelWorkSheet.Range[ColName + rng].Formula = "=IF(SUBTOTAL(9," + ColName + "3:" + ColName + "" + O.ToString() + ")=0,\"\",SUBTOTAL(9," + ColName + "3:" + ColName + "" + O.ToString() + "))";
                            myExcelWorkSheet.Range[ColName + "1"].EntireColumn.NumberFormat = "#,##0";

                            ColName = "N";
                            myExcelWorkSheet.Range[ColName + rng].Formula = "=IF(SUBTOTAL(9," + ColName + "3:" + ColName + "" + O.ToString() + ")=0,\"\",SUBTOTAL(9," + ColName + "3:" + ColName + "" + O.ToString() + "))";
                            myExcelWorkSheet.Range[ColName + "1"].EntireColumn.NumberFormat = "₹ #,##0";
                            myExcelWorkSheet.Range[ColName + "1"].EntireColumn.Font.Bold = true;
                            myExcelWorkSheet.Range[ColName + "1"].EntireColumn.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.ColorTranslator.FromHtml("#808080"));

                            ColName = "O";
                            myExcelWorkSheet.Range[ColName + rng].Formula = "=IF(SUBTOTAL(9," + ColName + "3:" + ColName + "" + O.ToString() + ")=0,\"\",SUBTOTAL(9," + ColName + "3:" + ColName + "" + O.ToString() + "))";
                            myExcelWorkSheet.Range[ColName + "1"].EntireColumn.NumberFormat = "#,##0";

                            ColName = "P";
                            myExcelWorkSheet.Range[ColName + rng].Formula = "=IF(SUBTOTAL(9," + ColName + "3:" + ColName + "" + O.ToString() + ")=0,\"\",SUBTOTAL(9," + ColName + "3:" + ColName + "" + O.ToString() + "))";
                            myExcelWorkSheet.Range[ColName + "1"].EntireColumn.NumberFormat = "₹ #,##0";
                            myExcelWorkSheet.Range[ColName + "1"].EntireColumn.Font.Bold = true;
                            myExcelWorkSheet.Range[ColName + "1"].EntireColumn.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.ColorTranslator.FromHtml("#808080"));

                            ColName = "Q";
                            myExcelWorkSheet.Range[ColName + rng].Formula = "=IF(SUBTOTAL(9," + ColName + "3:" + ColName + "" + O.ToString() + ")=0,\"\",SUBTOTAL(9," + ColName + "3:" + ColName + "" + O.ToString() + "))";
                            myExcelWorkSheet.Range[ColName + "1"].EntireColumn.NumberFormat = "#,##0";
                            //formula End

                            myExcelWorkSheet.Range["F" + rng, "Q" + rng].Cells.Font.Bold = true;
                            myExcelWorkSheet.Range["F" + rng, "Q" + rng].Cells.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;  // For Border

                            //width
                            myExcelWorkSheet.Range["A3"].Cells.EntireColumn.ColumnWidth = 33;
                            myExcelWorkSheet.Range["B3"].Cells.EntireColumn.ColumnWidth = 19.29;
                            myExcelWorkSheet.Range["C3"].Cells.EntireColumn.ColumnWidth = 7;
                            myExcelWorkSheet.Range["D3"].Cells.EntireColumn.ColumnWidth = 10;
                            myExcelWorkSheet.Range["E4"].Cells.EntireColumn.ColumnWidth = 38;
                            myExcelWorkSheet.Range["F4"].Cells.EntireColumn.ColumnWidth = 7;
                            myExcelWorkSheet.Range["G4"].Cells.EntireColumn.ColumnWidth = 14;
                            myExcelWorkSheet.Range["H1"].Cells.EntireColumn.ColumnWidth = 14;
                            myExcelWorkSheet.Range["I1"].Cells.EntireColumn.ColumnWidth = 14;
                            myExcelWorkSheet.Range["J1"].Cells.EntireColumn.ColumnWidth = 14;
                            myExcelWorkSheet.Range["K1"].Cells.EntireColumn.ColumnWidth = 14;
                            myExcelWorkSheet.Range["L1"].Cells.EntireColumn.ColumnWidth = 14;
                            myExcelWorkSheet.Range["M1"].Cells.EntireColumn.ColumnWidth = 14;
                            myExcelWorkSheet.Range["N1"].Cells.EntireColumn.ColumnWidth = 14;
                            myExcelWorkSheet.Range["O1"].Cells.EntireColumn.ColumnWidth = 14;
                            myExcelWorkSheet.Range["P1"].Cells.EntireColumn.ColumnWidth = 14;
                            myExcelWorkSheet.Range["Q1"].Cells.EntireColumn.ColumnWidth = 14;

                            myExcelWorkSheet.Range["B3", "B" + O].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;

                            myExcelWorkSheet.Range["G2", "Q2"].Cells.Font.Color = ColorTranslator.ToOle(System.Drawing.Color.Black);

                            if (SupplyTypeId == 1 || SupplyTypeId == 291)
                            {
                                myExcelWorkSheet.Range["E1"].Columns.Hidden = true;
                            }

                            releaseObject(myExcelWorkSheet);
                        }
                    }
                }
                #endregion

                #region ReportType :- Stock Summary Excel Accessory
                else if (ReportType == "Stock Summary Excel_A")
                {
                    int WorkBookCount = 0;
                    foreach (DataTable dt in ds.Tables)
                    {
                        WorkBookCount++;

                        var myExcelWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets[WorkBookCount];

                        int O = 2;
                        if (dt.Rows.Count > 0)
                        {
                            int SupplyTypeId = 0;
                            foreach (DataRow dr in dt.Rows)
                            {
                                O++;
                                SupplyTypeId = dr["SupplyTypeId"] == DBNull.Value ? 0 : Convert.ToInt32(dr["SupplyTypeId"]);

                                myExcelWorkSheet.Cells[O, 1] = dr["AccessoryQuality"] == DBNull.Value ? string.Empty : Convert.ToString(dr["AccessoryQuality"]);
                                myExcelWorkSheet.Cells[O, 2] = dr["Size"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Size"]);
                                myExcelWorkSheet.Cells[O, 3] = dr["ColorPrint"] == DBNull.Value ? string.Empty : Convert.ToString(dr["ColorPrint"]);
                                myExcelWorkSheet.Cells[O, 4] = dr["ShortUnit"] == DBNull.Value ? string.Empty : Convert.ToString(dr["ShortUnit"]);

                                myExcelWorkSheet.Cells[O, 5] = dr["GlobalStock_Qty"] == DBNull.Value ? string.Empty : Convert.ToString(dr["GlobalStock_Qty"]);
                                myExcelWorkSheet.Cells[O, 6] = dr["GlobalStock_Value"] == DBNull.Value ? string.Empty : Convert.ToString(dr["GlobalStock_Value"]);

                                myExcelWorkSheet.Cells[O, 7] = dr["WithProcessor_Qty"] == DBNull.Value ? string.Empty : Convert.ToString(dr["WithProcessor_Qty"]);
                                myExcelWorkSheet.Cells[O, 8] = dr["WithProcessor_Value"] == DBNull.Value ? string.Empty : Convert.ToString(dr["WithProcessor_Value"]);

                                myExcelWorkSheet.Cells[O, 9] = dr["SRVInInspection_Qty"] == DBNull.Value ? string.Empty : Convert.ToString(dr["SRVInInspection_Qty"]);
                                myExcelWorkSheet.Cells[O, 10] = dr["SRVInInspection_Value"] == DBNull.Value ? string.Empty : Convert.ToString(dr["SRVInInspection_Value"]);

                                myExcelWorkSheet.Cells[O, 11] = dr["PassStock_Qty"] == DBNull.Value ? string.Empty : Convert.ToString(dr["PassStock_Qty"]);
                                myExcelWorkSheet.Cells[O, 12] = dr["PassStock_Value"] == DBNull.Value ? string.Empty : Convert.ToString(dr["PassStock_Value"]);

                                myExcelWorkSheet.Cells[O, 13] = dr["FailedStock_Qty"] == DBNull.Value ? string.Empty : Convert.ToString(dr["FailedStock_Qty"]);
                                myExcelWorkSheet.Cells[O, 14] = dr["FailedStock_value"] == DBNull.Value ? string.Empty : Convert.ToString(dr["FailedStock_value"]);
                                myExcelWorkSheet.Cells[O, 15] = dr["DebitRaised_Qty"] == DBNull.Value ? string.Empty : Convert.ToString(dr["DebitRaised_Qty"]);

                            }
                            myExcelWorkSheet.Range["A3", "O" + O].VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignTop;
                            myExcelWorkSheet.Range["C2", "C" + O].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;

                            myExcelWorkSheet.Range["A3", "A" + O].Cells.Font.Bold = true;
                            myExcelWorkSheet.Range["A3", "A" + O].Cells.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Blue);  //fabricquality
                            myExcelWorkSheet.Range["A3", "O" + O].Cells.WrapText = true;

                            myExcelWorkSheet.get_Range("A3:O" + O).Cells.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;  // For Border                            

                            int rng = O + 2;
                            //formula Start
                            myExcelWorkSheet.Cells[rng, 4] = "Total";
                            myExcelWorkSheet.Range["D" + rng].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);

                            string ColName = "";

                            ColName = "E";
                            myExcelWorkSheet.Range[ColName + rng].Formula = "=IF(SUBTOTAL(9," + ColName + "3:" + ColName + "" + O.ToString() + ")=0,\"\",SUBTOTAL(9," + ColName + "3:" + ColName + "" + O.ToString() + "))";
                            myExcelWorkSheet.Range[ColName + "1"].EntireColumn.NumberFormat = "#,##0";

                            ColName = "F";
                            myExcelWorkSheet.Range[ColName + rng].Formula = "=IF(SUBTOTAL(9," + ColName + "3:" + ColName + "" + O.ToString() + ")=0,\"\",SUBTOTAL(9," + ColName + "3:" + ColName + "" + O.ToString() + "))";
                            myExcelWorkSheet.Range[ColName + "1"].EntireColumn.NumberFormat = "#,##0";
                            myExcelWorkSheet.Range[ColName + "1"].EntireColumn.Font.Bold = true;
                            myExcelWorkSheet.Range[ColName + "1"].EntireColumn.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.ColorTranslator.FromHtml("#808080"));

                            ColName = "G";
                            myExcelWorkSheet.Range[ColName + rng].Formula = "=IF(SUBTOTAL(9," + ColName + "3:" + ColName + "" + O.ToString() + ")=0,\"\",SUBTOTAL(9," + ColName + "3:" + ColName + "" + O.ToString() + "))";
                            myExcelWorkSheet.Range[ColName + "1"].EntireColumn.NumberFormat = "#,##0";

                            ColName = "H";
                            myExcelWorkSheet.Range[ColName + rng].Formula = "=IF(SUBTOTAL(9," + ColName + "3:" + ColName + "" + O.ToString() + ")=0,\"\",SUBTOTAL(9," + ColName + "3:" + ColName + "" + O.ToString() + "))";
                            myExcelWorkSheet.Range[ColName + "1"].EntireColumn.NumberFormat = "#,##0";
                            myExcelWorkSheet.Range[ColName + "1"].EntireColumn.Font.Bold = true;
                            myExcelWorkSheet.Range[ColName + "1"].EntireColumn.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.ColorTranslator.FromHtml("#808080"));

                            ColName = "I";
                            myExcelWorkSheet.Range[ColName + rng].Formula = "=IF(SUBTOTAL(9," + ColName + "3:" + ColName + "" + O.ToString() + ")=0,\"\",SUBTOTAL(9," + ColName + "3:" + ColName + "" + O.ToString() + "))";
                            myExcelWorkSheet.Range[ColName + "1"].EntireColumn.NumberFormat = "#,##0";

                            ColName = "J";
                            myExcelWorkSheet.Range[ColName + rng].Formula = "=IF(SUBTOTAL(9," + ColName + "3:" + ColName + "" + O.ToString() + ")=0,\"\",SUBTOTAL(9," + ColName + "3:" + ColName + "" + O.ToString() + "))";
                            myExcelWorkSheet.Range[ColName + "1"].EntireColumn.NumberFormat = "#,##0";
                            myExcelWorkSheet.Range[ColName + "1"].EntireColumn.Font.Bold = true;
                            myExcelWorkSheet.Range[ColName + "1"].EntireColumn.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.ColorTranslator.FromHtml("#808080"));

                            ColName = "K";
                            myExcelWorkSheet.Range[ColName + rng].Formula = "=IF(SUBTOTAL(9," + ColName + "3:" + ColName + "" + O.ToString() + ")=0,\"\",SUBTOTAL(9," + ColName + "3:" + ColName + "" + O.ToString() + "))";
                            myExcelWorkSheet.Range[ColName + "1"].EntireColumn.NumberFormat = "#,##0";

                            ColName = "L";
                            myExcelWorkSheet.Range[ColName + rng].Formula = "=IF(SUBTOTAL(9," + ColName + "3:" + ColName + "" + O.ToString() + ")=0,\"\",SUBTOTAL(9," + ColName + "3:" + ColName + "" + O.ToString() + "))";
                            myExcelWorkSheet.Range[ColName + "1"].EntireColumn.NumberFormat = "#,##0";
                            myExcelWorkSheet.Range[ColName + "1"].EntireColumn.Font.Bold = true;
                            myExcelWorkSheet.Range[ColName + "1"].EntireColumn.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.ColorTranslator.FromHtml("#808080"));

                            ColName = "M";
                            myExcelWorkSheet.Range[ColName + rng].Formula = "=IF(SUBTOTAL(9," + ColName + "3:" + ColName + "" + O.ToString() + ")=0,\"\",SUBTOTAL(9," + ColName + "3:" + ColName + "" + O.ToString() + "))";
                            myExcelWorkSheet.Range[ColName + "1"].EntireColumn.NumberFormat = "#,##0";

                            ColName = "N";
                            myExcelWorkSheet.Range[ColName + rng].Formula = "=IF(SUBTOTAL(9," + ColName + "3:" + ColName + "" + O.ToString() + ")=0,\"\",SUBTOTAL(9," + ColName + "3:" + ColName + "" + O.ToString() + "))";
                            myExcelWorkSheet.Range[ColName + "1"].EntireColumn.NumberFormat = "#,##0";
                            myExcelWorkSheet.Range[ColName + "1"].EntireColumn.Font.Bold = true;
                            myExcelWorkSheet.Range[ColName + "1"].EntireColumn.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.ColorTranslator.FromHtml("#808080"));

                            ColName = "O";
                            myExcelWorkSheet.Range[ColName + rng].Formula = "=IF(SUBTOTAL(9," + ColName + "3:" + ColName + "" + O.ToString() + ")=0,\"\",SUBTOTAL(9," + ColName + "3:" + ColName + "" + O.ToString() + "))";
                            myExcelWorkSheet.Range[ColName + "1"].EntireColumn.NumberFormat = "#,##0";

                            //formula End

                            myExcelWorkSheet.Range["D" + rng, "O" + rng].Cells.Font.Bold = true;
                            myExcelWorkSheet.Range["D" + rng, "O" + rng].Cells.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;  // For Border

                            //width
                            myExcelWorkSheet.Range["A3"].Cells.EntireColumn.ColumnWidth = 33;
                            myExcelWorkSheet.Range["B4"].Cells.EntireColumn.ColumnWidth = 14;
                            myExcelWorkSheet.Range["C4"].Cells.EntireColumn.ColumnWidth = 24;
                            myExcelWorkSheet.Range["D4"].Cells.EntireColumn.ColumnWidth = 7;
                            myExcelWorkSheet.Range["E4"].Cells.EntireColumn.ColumnWidth = 14;
                            myExcelWorkSheet.Range["F1"].Cells.EntireColumn.ColumnWidth = 14;
                            myExcelWorkSheet.Range["G1"].Cells.EntireColumn.ColumnWidth = 14;
                            myExcelWorkSheet.Range["I1"].Cells.EntireColumn.ColumnWidth = 14;
                            myExcelWorkSheet.Range["K1"].Cells.EntireColumn.ColumnWidth = 14;
                            myExcelWorkSheet.Range["M1"].Cells.EntireColumn.ColumnWidth = 14;

                            myExcelWorkSheet.Range["D2", "O2"].Cells.Font.Color = ColorTranslator.ToOle(System.Drawing.Color.Black);

                            if (SupplyTypeId == 1)
                            {
                                myExcelWorkSheet.Range["C1"].Columns.Hidden = true;
                            }

                            releaseObject(myExcelWorkSheet);
                        }
                    }
                }
                #endregion

                xlWorkBook.Save();
                xlWorkBook.Close();

                releaseObject(worksheets);
                releaseObject(xlWorkBook);
                releaseObject(xlApp);
                return true;
            }
            else
            {
                return false;
            }

        }
        //new work end :Girish


        //created by Girish For Material Daily Excel
        protected string GetCommaSeparatedValue_ExcelFormula(string ExcelColumn_ContainsQty, string ExcelColumn_ContainsUnit, string ExcelColumn_StartAt, string ExcelColumn_EndAt, string[] units)
        {
            string Formula = "";


            for (int i = 0; i < units.Length; i++)
            {
                Formula += "IF(SUMPRODUCT(SUBTOTAL(109,OFFSET(" + ExcelColumn_ContainsQty + ExcelColumn_StartAt + ",ROW(" + ExcelColumn_ContainsQty + ExcelColumn_StartAt + ":" + ExcelColumn_ContainsQty + "" + ExcelColumn_EndAt + ")-ROW(" + ExcelColumn_ContainsQty + ExcelColumn_StartAt + "),,1)),--(" + ExcelColumn_ContainsUnit + ExcelColumn_StartAt + ":" + ExcelColumn_ContainsUnit + "" + ExcelColumn_EndAt + "=\"" + units[i] + "\"))>0,SUMPRODUCT(SUBTOTAL(109,OFFSET(" + ExcelColumn_ContainsQty + ExcelColumn_StartAt + ",ROW(" + ExcelColumn_ContainsQty + ExcelColumn_StartAt + ":" + ExcelColumn_ContainsQty + "" + ExcelColumn_EndAt + ")-ROW(" + ExcelColumn_ContainsQty + ExcelColumn_StartAt + "),,1)),--(" + ExcelColumn_ContainsUnit + ExcelColumn_StartAt + ":" + ExcelColumn_ContainsUnit + "" + ExcelColumn_EndAt + "=\"" + units[i] + "\"))&\"" + units[i] + ",\",\"\")&";

                if (i == units.Length - 1)
                {
                    Formula = "=" + Formula.Substring(0, Formula.Length - 1);
                }
            }
            return Formula;
        }

        #endregion
    }
}