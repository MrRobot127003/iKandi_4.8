using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.IO;
using iKandi.BLL;
using System.Data;
using System.Net.Mail;
using iKandi.Common;

namespace iKandi.Web
{
    public partial class FrmProductionPerformanceReport : System.Web.UI.Page
    {
       
        string Flag = string.Empty;
        string FitsPath = string.Empty;
        string WriteFile;
        CommonController objCommon = new CommonController();
        DateTime CommonDate;

        protected void Page_Load(object sender, EventArgs e)
        {
            CommonDate = objCommon.GetCommonRptDateOnPage();

            if (CommonDate.Day == 1)
            {
                CommonDate = CommonDate.AddDays(-1);
            }
 
            randorProductionQcFaultReportHtml();            
            randorProductionQcLeneManAChiveHtml();
            randorProductionQcComplienceC_45ReHtml();
            randorProductionQcComplienceC_47ReHtml();          
        }


        public void randorProductionPerfomenceHtml()
        {
            WebResponse response;
            WebRequest quest;
            StreamReader reader;
            StreamWriter writer;
            string strHTML;
            quest = WebRequest.Create(Constants.MainUrlMail + "/FrmProductionPerformance_QCFaults.aspx");
            quest.Timeout = Convert.ToInt32(99999999);
            response = quest.GetResponse();
            reader = new StreamReader(response.GetResponseStream());
            strHTML = reader.ReadToEnd();

            string Reallocation_ReportHtml = "";
            //DateTime now = DateTime.Now;

            string Month = CommonDate.ToString("MMM");
            string Day = CommonDate.ToString("dd");

            Reallocation_ReportHtml = "FrmProductionPerformanceQCFaultReport_" + Day +"_" + Month + ".html";
            writer = File.CreateText(Server.MapPath("~/Uploads/ProductionPerformance_Report/" + Reallocation_ReportHtml));
            writer.WriteLine(strHTML);
            writer.Close();

            WriteFile = Constants.MainUrlMail + "/uploads/ProductionPerformance_Report/" + Reallocation_ReportHtml;


        }
        public void randorProductionQcFaultReportHtml()
        {
            WebResponse response;
            WebRequest quest;
            StreamReader reader;
            StreamWriter writer;
            string strHTML;
            quest = WebRequest.Create(Constants.MainUrlMail + "/FrmQCPerformanceReport.aspx");
            quest.Timeout = Convert.ToInt32(99999999);
            response = quest.GetResponse();
            reader = new StreamReader(response.GetResponseStream());
            strHTML = reader.ReadToEnd();

            string Reallocation_ReportHtml = "";
            //DateTime now = DateTime.Now;

            string Month = CommonDate.ToString("MMM");
            string Day = CommonDate.ToString("dd");

            Reallocation_ReportHtml = "FrmQCPerformanceReport_" + Day + "_" + Month + ".html";
            writer = File.CreateText(Server.MapPath("~/Uploads/ProductionPerformance_Report/" + Reallocation_ReportHtml));
            writer.WriteLine(strHTML);
            writer.Close();

            WriteFile = Constants.MainUrlMail + "/uploads/ProductionPerformance_Report/" + Reallocation_ReportHtml;


        }
        
        public void randorProductionQcLeneManAChiveHtml()
        {
            WebResponse response;
            WebRequest quest;
            StreamReader reader;
            StreamWriter writer;
            string strHTML;
            quest = WebRequest.Create(Constants.MainUrlMail + "/FrmLineManAchivementPerReport.aspx");
            quest.Timeout = Convert.ToInt32(99999999);
            response = quest.GetResponse();
            reader = new StreamReader(response.GetResponseStream());
            strHTML = reader.ReadToEnd();

            string Reallocation_ReportHtml = "";
            //DateTime now = DateTime.Now;

            string Month = CommonDate.ToString("MMM");
            string Day = CommonDate.ToString("dd");

            Reallocation_ReportHtml = "FrmLineManSumReport_" + Day + "_" + Month + ".html";
            writer = File.CreateText(Server.MapPath("~/Uploads/ProductionPerformance_Report/" + Reallocation_ReportHtml));
            writer.WriteLine(strHTML);
            writer.Close();

            WriteFile = Constants.MainUrlMail + "/uploads/ProductionPerformance_Report/" + Reallocation_ReportHtml;


        }

        public void randorProductionQcComplienceC_45ReHtml()
        {
            WebResponse response;
            WebRequest quest;
            StreamReader reader;
            StreamWriter writer;
            string strHTML;
            quest = WebRequest.Create(Constants.MainUrlMail + "/FrmComplianceAuditC45_Report.aspx");
            quest.Timeout = Convert.ToInt32(99999999);
            response = quest.GetResponse();
            reader = new StreamReader(response.GetResponseStream());
            strHTML = reader.ReadToEnd();

            string Reallocation_ReportHtml = "";
            //DateTime now = DateTime.Now;

            string Month = CommonDate.ToString("MMM");
            string Day = CommonDate.ToString("dd");

            Reallocation_ReportHtml = "FrmComplianceAuditC45_Report_" + Day + "_" + Month + ".html";
            writer = File.CreateText(Server.MapPath("~/Uploads/ProductionPerformance_Report/" + Reallocation_ReportHtml));
            writer.WriteLine(strHTML);
            writer.Close();

            WriteFile = Constants.MainUrlMail + "/ProductionPerformance_Report/" + Reallocation_ReportHtml;


        }

        public void randorProductionQcComplienceC_47ReHtml()
        {
            WebResponse response;
            WebRequest quest;
            StreamReader reader;
            StreamWriter writer;
            string strHTML;
            quest = WebRequest.Create(Constants.MainUrlMail + "/FrmComplianceAuditC47_Report.aspx");
            quest.Timeout = Convert.ToInt32(99999999);
            response = quest.GetResponse();
            reader = new StreamReader(response.GetResponseStream());
            strHTML = reader.ReadToEnd();

            string Reallocation_ReportHtml = "";
            //DateTime now = DateTime.Now;

            string Month = CommonDate.ToString("MMM");
            string Day = CommonDate.ToString("dd");

            Reallocation_ReportHtml = "FrmComplianceAuditC47_Report_" + Day + "_" + Month + ".html";
            writer = File.CreateText(Server.MapPath("~/Uploads/ProductionPerformance_Report/" + Reallocation_ReportHtml));
            writer.WriteLine(strHTML);
            writer.Close();

            WriteFile = Constants.MainUrlMail + "/ProductionPerformance_Report/" + Reallocation_ReportHtml;


        }

    }
}