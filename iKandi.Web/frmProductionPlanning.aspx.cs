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
    public partial class frmProductionPlanning : System.Web.UI.Page
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

            string GlobalType_Upcomming_Exfactory = "ProductionPlanningReports.xlsx";
            if ((System.IO.File.Exists(Constants.FITS_FOLDER_PATH + GlobalType_Upcomming_Exfactory)))
            {
                System.IO.File.Delete(Constants.FITS_FOLDER_PATH + GlobalType_Upcomming_Exfactory);
            }
            if ((System.IO.File.Exists("\\\\192.168.0.4\\UpComming_Exfactory\\ProductionPlanningReports.xlsx")))
            {
                System.IO.File.Delete("\\\\192.168.0.4\\UpComming_Exfactory\\ProductionPlanningReports.xlsx");
            }
            //---------------------------New UpComming production style code---------------------------------------------//
            string GlobalType_Production_Plan_Stylecode = "PPlanning_WithStylecode_Reports.xlsx";
            if ((System.IO.File.Exists(Constants.FITS_FOLDER_PATH + GlobalType_Production_Plan_Stylecode)))
            {
                System.IO.File.Delete(Constants.FITS_FOLDER_PATH + GlobalType_Production_Plan_Stylecode);
            }
            if ((System.IO.File.Exists("\\\\192.168.0.4\\UpComming_Exfactory\\PPlanning_WithStylecode_Reports.xlsx")))
            {
                System.IO.File.Delete("\\\\192.168.0.4\\UpComming_Exfactory\\PPlanning_WithStylecode_Reports.xlsx");
            }
            //---------------------------end-----------------------------------------------------------------------------//
            string targetPath_UpcommingExfactory = Constants.FITS_FOLDER_PATH + GlobalType_Upcomming_Exfactory;
            string sourceFile_UpcommingExfactory = System.IO.Path.Combine(sourcePath, GlobalType_Upcomming_Exfactory);
            string destFile_UpcommingExfactory = System.IO.Path.Combine(targetPath_UpcommingExfactory, GlobalType_Upcomming_Exfactory);
            System.IO.File.Copy(sourceFile_UpcommingExfactory, targetPath_UpcommingExfactory, true);
            string ReportType = "Production_Planning";
            //name = ReportType + "-" + DateTime.Now.ToString("dd MMM yyy") + ".xls";
            string pdfFilePath_Upcomming_Exfactory = Path.Combine(Constants.FITS_FOLDER_PATH, GlobalType_Upcomming_Exfactory);
            bool success = controller.GenerateFitsReportExcel(pdfFilePath_Upcomming_Exfactory, ReportType, ds = objadmin.GetFitsReport("Production_Planning"), GlobalType_Upcomming_Exfactory);
            //   System.IO.File.Copy("C:\\test\\copy.txt", "\\\\192.168.0.4\\UpComming_Exfactory\\Upcoming_exfactory.xlsx", true);
            System.IO.File.Copy(targetPath_UpcommingExfactory, "\\\\192.168.0.4\\UpComming_Exfactory\\ProductionPlanningReports.xlsx", true);
            //--------------------------------------------For Production planning Style code--------------------------------------//
            string targetPath_PPlanning_WithStylecode = Constants.FITS_FOLDER_PATH + GlobalType_Production_Plan_Stylecode;
            string sourceFile_PPlanning_WithStylecode = System.IO.Path.Combine(sourcePath, GlobalType_Production_Plan_Stylecode);
            string destFile_PPlanning_WithStylecode = System.IO.Path.Combine(targetPath_PPlanning_WithStylecode, GlobalType_Production_Plan_Stylecode);
            System.IO.File.Copy(sourceFile_PPlanning_WithStylecode, targetPath_PPlanning_WithStylecode, true);
            ReportType = "Production_Planning_AgainstStyleCode";
            //name = ReportType + "-" + DateTime.Now.ToString("dd MMM yyy") + ".xls";
             pdfFilePath_Upcomming_Exfactory = Path.Combine(Constants.FITS_FOLDER_PATH, GlobalType_Production_Plan_Stylecode);
             success = controller.GenerateFitsReportExcel(pdfFilePath_Upcomming_Exfactory, ReportType, ds = objadmin.GetFitsReport("Production_Planning_AgainstStyleCode"), GlobalType_Production_Plan_Stylecode);
            //   System.IO.File.Copy("C:\\test\\copy.txt", "\\\\192.168.0.4\\UpComming_Exfactory\\Upcoming_exfactory.xlsx", true);
             System.IO.File.Copy(targetPath_PPlanning_WithStylecode, "\\\\192.168.0.4\\UpComming_Exfactory\\PPlanning_WithStylecode_Reports.xlsx", true);

            //--------------------------------------------end---------------------------------------------------------------------//



        }
    }
}