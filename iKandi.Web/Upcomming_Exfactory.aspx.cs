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

namespace iKandi.Web
{
    public partial class Upcomming_Exfactory : System.Web.UI.Page
    {
        AdminController objadmin = new AdminController();
        ReportController controller = new ReportController();
        protected void Page_Load(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            CreateExcel(ds);
        }
        public void CreateExcel(DataSet ds)
        {

            string sourcePath = @"E:\";

            //if ((System.IO.File.Exists(Constants.FITS_FOLDER_PATH + GlobalType_Upcomming_Exfactory)))
            //{
            //    System.IO.File.Delete(Constants.FITS_FOLDER_PATH + GlobalType_Upcomming_Exfactory);
            //}
            //if ((System.IO.File.Exists("\\\\192.168.0.4\\UpComming_Exfactory\\Upcoming_exfactory.xlsx")))
            //{
            //    System.IO.File.Delete("\\\\192.168.0.4\\UpComming_Exfactory\\Upcoming_exfactory.xlsx");
            //}
            //string targetPath_UpcommingExfactory = Constants.FITS_FOLDER_PATH + GlobalType_Upcomming_Exfactory;
            //string sourceFile_UpcommingExfactory = System.IO.Path.Combine(sourcePath, GlobalType_Upcomming_Exfactory);
            //string destFile_UpcommingExfactory = System.IO.Path.Combine(targetPath_UpcommingExfactory, GlobalType_Upcomming_Exfactory);
            //System.IO.File.Copy(sourceFile_UpcommingExfactory, targetPath_UpcommingExfactory, true);
            //string ReportType = "Upcoming_exfactory";
            ////name = ReportType + "-" + DateTime.Now.ToString("dd MMM yyy") + ".xls";
            //string pdfFilePath_Upcomming_Exfactory = Path.Combine(Constants.FITS_FOLDER_PATH, GlobalType_Upcomming_Exfactory);
            //bool success = controller.GenerateFitsReportExcel(pdfFilePath_Upcomming_Exfactory, ReportType, ds = objadmin.GetFitsReport("Upcoming_exfactory"), GlobalType_Upcomming_Exfactory);
            ////   System.IO.File.Copy("C:\\test\\copy.txt", "\\\\192.168.0.4\\UpComming_Exfactory\\Upcoming_exfactory.xlsx", true);
            //System.IO.File.Copy(targetPath_UpcommingExfactory, "\\\\192.168.0.4\\UpComming_Exfactory\\Upcoming_exfactory.xlsx", true);

            string GlobalType_Rescan = "Rescan.xlsx";
            if ((System.IO.File.Exists(Constants.FITS_FOLDER_PATH + GlobalType_Rescan)))
            {
                System.IO.File.Delete(Constants.FITS_FOLDER_PATH + GlobalType_Rescan);
            }
            if ((System.IO.File.Exists("\\\\192.168.0.4\\UpComming_Exfactory\\Rescan.xlsx")))
            {
                System.IO.File.Delete("\\\\192.168.0.4\\UpComming_Exfactory\\Rescan.xlsx");
            }
            string targetPath_Rescan = Constants.FITS_FOLDER_PATH + GlobalType_Rescan;
            string sourceFile_Rescan = System.IO.Path.Combine(sourcePath, GlobalType_Rescan);
            string destFile_Rescan = System.IO.Path.Combine(targetPath_Rescan, GlobalType_Rescan);
            System.IO.File.Copy(sourceFile_Rescan, targetPath_Rescan, true);
            string ReportType_Rescan = "Rescan";
            //name = ReportType + "-" + DateTime.Now.ToString("dd MMM yyy") + ".xls";
            string pdfFilePath_Rescan = Path.Combine(Constants.FITS_FOLDER_PATH, GlobalType_Rescan);
            bool success_Rescan = controller.GenerateFitsReportExcel(pdfFilePath_Rescan, ReportType_Rescan, ds = objadmin.GetFitsReport("Rescan"), GlobalType_Rescan);
            //   System.IO.File.Copy("C:\\test\\copy.txt", "\\\\192.168.0.4\\UpComming_Exfactory\\Upcoming_exfactory.xlsx", true);
            System.IO.File.Copy(targetPath_Rescan, "\\\\192.168.0.4\\UpComming_Exfactory\\Rescan.xlsx", true);
            //string GlobalType_WIP = "WIP.xlsx";
            //if ((System.IO.File.Exists(Constants.FITS_FOLDER_PATH + GlobalType_WIP)))
            //{
            //    System.IO.File.Delete(Constants.FITS_FOLDER_PATH + GlobalType_WIP);
            //}
            //if ((System.IO.File.Exists("\\\\192.168.0.4\\UpComming_Exfactory\\WIP.xlsx")))
            //{
            //    System.IO.File.Delete("\\\\192.168.0.4\\UpComming_Exfactory\\WIP.xlsx");
            //}
            //string targetPath_WIP = Constants.FITS_FOLDER_PATH + GlobalType_WIP;
            //string sourceFile_WIP = System.IO.Path.Combine(sourcePath, GlobalType_WIP);
            //string destFile_WIP = System.IO.Path.Combine(targetPath_WIP, GlobalType_WIP);
            //System.IO.File.Copy(sourceFile_WIP, targetPath_WIP, true);
            //string ReportType_WIP = "CUT_WIP";
            ////name = ReportType + "-" + DateTime.Now.ToString("dd MMM yyy") + ".xls";
            //string pdfFilePath_WIP = Path.Combine(Constants.FITS_FOLDER_PATH, GlobalType_WIP);
            //bool success_WIP = controller.GenerateFitsReportExcel(pdfFilePath_WIP, ReportType_WIP, ds = objadmin.GetFitsReport("CUT_WIP"), GlobalType_WIP);

            //ReportType_WIP = "Finished_WIP";
            ////name = ReportType + "-" + DateTime.Now.ToString("dd MMM yyy") + ".xls";
            //pdfFilePath_WIP = Path.Combine(Constants.FITS_FOLDER_PATH, GlobalType_WIP);
            //success_WIP = controller.GenerateFitsReportExcel(pdfFilePath_WIP, ReportType_WIP, ds = objadmin.GetFitsReport("Finished_WIP"), GlobalType_WIP);

            ////   System.IO.File.Copy("C:\\test\\copy.txt", "\\\\192.168.0.4\\UpComming_Exfactory\\Upcoming_exfactory.xlsx", true);
            //System.IO.File.Copy(targetPath_WIP, "\\\\192.168.0.4\\UpComming_Exfactory\\WIP.xlsx", true);
            //--------------------------FOR FABRIC WIP-------------------------------------------------------//
            string GlobalType_Fabric_WIP = "WIP.xlsx";
            if ((System.IO.File.Exists(Constants.FITS_FOLDER_PATH + GlobalType_Fabric_WIP)))
            {
                System.IO.File.Delete(Constants.FITS_FOLDER_PATH + GlobalType_Fabric_WIP);
            }
            if ((System.IO.File.Exists("\\\\192.168.0.4\\UpComming_Exfactory\\WIP.xlsx")))
            {
                System.IO.File.Delete("\\\\192.168.0.4\\UpComming_Exfactory\\WIP.xlsx");
            }
            string targetPath_Fabric_WIP = Constants.FITS_FOLDER_PATH + GlobalType_Fabric_WIP;
            string sourceFile_Fabric_WIP = System.IO.Path.Combine(sourcePath, GlobalType_Fabric_WIP);

            string destFile_Fabric_WIP = System.IO.Path.Combine(targetPath_Fabric_WIP, GlobalType_Fabric_WIP);
            System.IO.File.Copy(sourceFile_Fabric_WIP, targetPath_Fabric_WIP, true);
            string pdfFilePath_Fabric_WIP = Path.Combine(Constants.FITS_FOLDER_PATH, GlobalType_Fabric_WIP);
            string ReportTypeFabric_WIP = "InHouseFabricWIP";
             bool success_WIP = controller.GenerateFitsReportExcel(pdfFilePath_Fabric_WIP, ReportTypeFabric_WIP, ds = objadmin.GetFitsReport("InHouseFabricWIP"), GlobalType_Fabric_WIP);

            ReportTypeFabric_WIP = "CUT_StitchWIP";
            //name = ReportType + "-" + DateTime.Now.ToString("dd MMM yyy") + ".xls";
            pdfFilePath_Fabric_WIP = Path.Combine(Constants.FITS_FOLDER_PATH, GlobalType_Fabric_WIP);
            success_WIP = controller.GenerateFitsReportExcel(pdfFilePath_Fabric_WIP, ReportTypeFabric_WIP, ds = objadmin.GetFitsReport("CUT_StitchWIP"), GlobalType_Fabric_WIP);

            //   System.IO.File.Copy("C:\\test\\copy.txt", "\\\\192.168.0.4\\UpComming_Exfactory\\Upcoming_exfactory.xlsx", true);

            ReportTypeFabric_WIP = "Stitch_PackWIP";
            //name = ReportType + "-" + DateTime.Now.ToString("dd MMM yyy") + ".xls";
            pdfFilePath_Fabric_WIP = Path.Combine(Constants.FITS_FOLDER_PATH, GlobalType_Fabric_WIP);
            success_WIP = controller.GenerateFitsReportExcel(pdfFilePath_Fabric_WIP, ReportTypeFabric_WIP, ds = objadmin.GetFitsReport("Stitch_PackWIP"), GlobalType_Fabric_WIP);

            ReportTypeFabric_WIP = "Pack_ShipWIP";
            //name = ReportType + "-" + DateTime.Now.ToString("dd MMM yyy") + ".xls";
            pdfFilePath_Fabric_WIP = Path.Combine(Constants.FITS_FOLDER_PATH, GlobalType_Fabric_WIP);
            success_WIP = controller.GenerateFitsReportExcel(pdfFilePath_Fabric_WIP, ReportTypeFabric_WIP, ds = objadmin.GetFitsReport("Pack_ShipWIP"), GlobalType_Fabric_WIP);


            System.IO.File.Copy(targetPath_Fabric_WIP, "\\\\192.168.0.4\\UpComming_Exfactory\\WIP.xlsx", true);


        }

    }
}