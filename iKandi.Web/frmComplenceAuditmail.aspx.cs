using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.IO;
using iKandi.BLL.Production;
using System.Data;
using iKandi.Common;
namespace iKandi.Web
{
    public partial class frmComplenceAuditmail : System.Web.UI.Page
    {
        string MailType = string.Empty;
        string Flag = string.Empty;
        string EmailContent = string.Empty;
        string WriteFile;



        protected void Page_Load(object sender, EventArgs e)
        {
            // randorComplianceHtml_OutHouse();
            randorComplianceHtml_Unit_3_Process_1();
            randorComplianceHtml_Unit_3_Process_2();
            randorComplianceHtml_Unit_11_Process_1();
            randorComplianceHtml_Unit_11_Process_2();
            randorComplianceHtml_Unit_169_Process_1();
            randorComplianceHtml_Unit_169_Process_2();
            randorComplianceHtml_Unit_120_Process_1();
            randorComplianceHtml_Unit_120_Process_2();
            DeleteAudit_ReportBeforeTenDays();
        }


        public void randorComplianceHtml_Unit_3_Process_1()
        {
            WebRequest quest;
            WebResponse ponse;
            StreamReader reader;
            StreamWriter writer;
            string strHTML;
            ProductionController objProductionController = new ProductionController();
            DataSet dtClients = objProductionController.GetSlotId();

            quest = WebRequest.Create(Constants.MainIpMail + "/ComplienceAuditReport.aspx?processType=1&UnitId=3");
            quest.Timeout = Convert.ToInt32(99999999);
            ponse = quest.GetResponse();
            reader = new StreamReader(ponse.GetResponseStream());

            strHTML = reader.ReadToEnd();



            string ComplienceAudit_ReportHtml = "";
            DateTime now = DateTime.Now;
            string Day = now.ToString("dd");
            string Month = now.ToString("MMM");

            ComplienceAudit_ReportHtml = "ComplienceAuditReport_UnitId_3_ProcessType_1_" + Day + "_" + Month + ".html";
            writer = File.CreateText(Server.MapPath("~/Uploads/Audit_Report/" + ComplienceAudit_ReportHtml));
            writer.WriteLine(strHTML);
            writer.Close();
            // WriteFile = Server.MapPath("~/uploads/Audit_Report/" + ComplienceAudit_ReportHtml);
            WriteFile = Constants.MainUrlMail+"/uploads/Audit_Report/" + ComplienceAudit_ReportHtml;
            // Response.WriteFile();   
        }

        public void randorComplianceHtml_Unit_3_Process_2()
        {
            WebRequest quest;
            WebResponse ponse;
            StreamReader reader;
            StreamWriter writer;
            string strHTML;
            ProductionController objProductionController = new ProductionController();
            DataSet dtClients = objProductionController.GetSlotId();

            quest = WebRequest.Create(Constants.MainIpMail + "/ComplienceAuditReport.aspx?processType=2&UnitId=3");
            quest.Timeout = Convert.ToInt32(99999999);
            ponse = quest.GetResponse();
            reader = new StreamReader(ponse.GetResponseStream());

            strHTML = reader.ReadToEnd();



            string ComplienceAudit_ReportHtml = "";
            DateTime now = DateTime.Now;
            string Day = now.ToString("dd");
            string Month = now.ToString("MMM");

            ComplienceAudit_ReportHtml = "ComplienceAuditReport_UnitId_3_ProcessType_2_" + Day + "_" + Month + ".html";
            writer = File.CreateText(Server.MapPath("~/Uploads/Audit_Report/" + ComplienceAudit_ReportHtml));
            writer.WriteLine(strHTML);
            writer.Close();
            //WriteFile = Server.MapPath("~/uploads/Audit_Report/" + ComplienceAudit_ReportHtml);
            WriteFile = Constants.MainUrlMail + "/uploads/Audit_Report/" + ComplienceAudit_ReportHtml;
            // Response.WriteFile();   
        }

        public void randorComplianceHtml_Unit_11_Process_1()
        {
            WebRequest quest;
            WebResponse ponse;
            StreamReader reader;
            StreamWriter writer;
            string strHTML;
            ProductionController objProductionController = new ProductionController();
            DataSet dtClients = objProductionController.GetSlotId();

            quest = WebRequest.Create(Constants.MainIpMail + "/ComplienceAuditReport.aspx?processType=1&UnitId=11");
            quest.Timeout = Convert.ToInt32(99999999);
            ponse = quest.GetResponse();
            reader = new StreamReader(ponse.GetResponseStream());

            strHTML = reader.ReadToEnd();



            string ComplienceAudit_ReportHtml = "";
            DateTime now = DateTime.Now;
            string Day = now.ToString("dd");
            string Month = now.ToString("MMM");

            ComplienceAudit_ReportHtml = "ComplienceAuditReport_UnitId_11_ProcessType_1_" + Day + "_" + Month + ".html";
            writer = File.CreateText(Server.MapPath("~/Uploads/Audit_Report/" + ComplienceAudit_ReportHtml));
            writer.WriteLine(strHTML);
            writer.Close();
            //WriteFile = Server.MapPath("~/uploads/Audit_Report/" + ComplienceAudit_ReportHtml);
            WriteFile = Constants.MainUrlMail + "/uploads/Audit_Report/" + ComplienceAudit_ReportHtml;
            // Response.WriteFile();   
        }
        public void randorComplianceHtml_Unit_169_Process_1()
        {
            WebRequest quest;
            WebResponse ponse;
            StreamReader reader;
            StreamWriter writer;
            string strHTML;
            ProductionController objProductionController = new ProductionController();
            DataSet dtClients = objProductionController.GetSlotId();

            quest = WebRequest.Create(Constants.MainIpMail + "/ComplienceAuditReport.aspx?processType=1&UnitId=96");
            quest.Timeout = Convert.ToInt32(99999999);
            ponse = quest.GetResponse();
            reader = new StreamReader(ponse.GetResponseStream());

            strHTML = reader.ReadToEnd();



            string ComplienceAudit_ReportHtml = "";
            DateTime now = DateTime.Now;
            string Day = now.ToString("dd");
            string Month = now.ToString("MMM");

            ComplienceAudit_ReportHtml = "ComplienceAuditReport_UnitId_169_ProcessType_1_" + Day + "_" + Month + ".html";
            writer = File.CreateText(Server.MapPath("~/Uploads/Audit_Report/" + ComplienceAudit_ReportHtml));
            writer.WriteLine(strHTML);
            writer.Close();
            //WriteFile = Server.MapPath("~/uploads/Audit_Report/" + ComplienceAudit_ReportHtml);
            WriteFile = Constants.MainUrlMail + "/uploads/Audit_Report/" + ComplienceAudit_ReportHtml;
            // Response.WriteFile();   
        }

        public void randorComplianceHtml_Unit_11_Process_2()
        {
            WebRequest quest;
            WebResponse ponse;
            StreamReader reader;
            StreamWriter writer;
            string strHTML;
            ProductionController objProductionController = new ProductionController();
            DataSet dtClients = objProductionController.GetSlotId();

            // Give your ASP.NET Page address            
            quest = WebRequest.Create(Constants.MainIpMail + "/ComplienceAuditReport.aspx?processType=2&UnitId=11");
            quest.Timeout = Convert.ToInt32(99999999);
            ponse = quest.GetResponse();
            reader = new StreamReader(ponse.GetResponseStream());

            strHTML = reader.ReadToEnd();



            string ComplienceAudit_ReportHtml = "";
            DateTime now = DateTime.Now;
            string Day = now.ToString("dd");
            string Month = now.ToString("MMM");

            ComplienceAudit_ReportHtml = "ComplienceAuditReport_UnitId_11_ProcessType_2_" + Day + "_" + Month + ".html";
            writer = File.CreateText(Server.MapPath("~/Uploads/Audit_Report/" + ComplienceAudit_ReportHtml));
            writer.WriteLine(strHTML);
            writer.Close();
            //WriteFile = Server.MapPath("~/uploads/Audit_Report/" + ComplienceAudit_ReportHtml);
            WriteFile = Constants.MainUrlMail + "/uploads/Audit_Report/" + ComplienceAudit_ReportHtml;
            // Response.WriteFile();   
        }
        public void randorComplianceHtml_Unit_169_Process_2()
        {
            WebRequest quest;
            WebResponse ponse;
            StreamReader reader;
            StreamWriter writer;
            string strHTML;
            ProductionController objProductionController = new ProductionController();
            DataSet dtClients = objProductionController.GetSlotId();

            // Give your ASP.NET Page address            
            quest = WebRequest.Create(Constants.MainIpMail + "/ComplienceAuditReport.aspx?processType=2&UnitId=96");
            quest.Timeout = Convert.ToInt32(99999999);
            ponse = quest.GetResponse();
            reader = new StreamReader(ponse.GetResponseStream());

            strHTML = reader.ReadToEnd();



            string ComplienceAudit_ReportHtml = "";
            DateTime now = DateTime.Now;
            string Day = now.ToString("dd");
            string Month = now.ToString("MMM");

            ComplienceAudit_ReportHtml = "ComplienceAuditReport_UnitId_169_ProcessType_2_" + Day + "_" + Month + ".html";
            writer = File.CreateText(Server.MapPath("~/Uploads/Audit_Report/" + ComplienceAudit_ReportHtml));
            writer.WriteLine(strHTML);
            writer.Close();
            //WriteFile = Server.MapPath("~/uploads/Audit_Report/" + ComplienceAudit_ReportHtml);
            WriteFile = Constants.MainUrlMail + "/uploads/Audit_Report/" + ComplienceAudit_ReportHtml;
            // Response.WriteFile();   
        }

        public void randorComplianceHtml_Unit_120_Process_1()
        {
            WebRequest quest;
            WebResponse ponse;
            StreamReader reader;
            StreamWriter writer;
            string strHTML;
            ProductionController objProductionController = new ProductionController();
            DataSet dtClients = objProductionController.GetSlotId();

            quest = WebRequest.Create(Constants.MainIpMail + "/ComplienceAuditReport.aspx?processType=1&UnitId=120");
            //quest = WebRequest.Create("http://localhost:3220/ComplienceAuditReport.aspx?processType=1&UnitId=120");
            quest.Timeout = Convert.ToInt32(99999999);
            ponse = quest.GetResponse();
            reader = new StreamReader(ponse.GetResponseStream());

            strHTML = reader.ReadToEnd();



            string ComplienceAudit_ReportHtml = "";
            DateTime now = DateTime.Now;
            string Day = now.ToString("dd");
            string Month = now.ToString("MMM");

            ComplienceAudit_ReportHtml = "ComplienceAuditReport_UnitId_120_ProcessType_1_" + Day + "_" + Month + ".html";
            writer = File.CreateText(Server.MapPath("~/Uploads/Audit_Report/" + ComplienceAudit_ReportHtml));
            writer.WriteLine(strHTML);
            writer.Close();
            // WriteFile = Server.MapPath("~/uploads/Audit_Report/" + ComplienceAudit_ReportHtml);
            WriteFile = Constants.MainUrlMail + "/uploads/Audit_Report/" + ComplienceAudit_ReportHtml;
            //WriteFile = "http://localhost:3220/uploads/Audit_Report/" + ComplienceAudit_ReportHtml;
            // Response.WriteFile();   
        }

        public void randorComplianceHtml_Unit_120_Process_2()
        {
            WebRequest quest;
            WebResponse ponse;
            StreamReader reader;
            StreamWriter writer;
            string strHTML;
            ProductionController objProductionController = new ProductionController();
            DataSet dtClients = objProductionController.GetSlotId();

            quest = WebRequest.Create(Constants.MainIpMail + "/ComplienceAuditReport.aspx?processType=2&UnitId=120");
            quest.Timeout = Convert.ToInt32(99999999);
            ponse = quest.GetResponse();
            reader = new StreamReader(ponse.GetResponseStream());

            strHTML = reader.ReadToEnd();



            string ComplienceAudit_ReportHtml = "";
            DateTime now = DateTime.Now;
            string Day = now.ToString("dd");
            string Month = now.ToString("MMM");

            ComplienceAudit_ReportHtml = "ComplienceAuditReport_UnitId_120_ProcessType_2_" + Day + "_" + Month + ".html";
            writer = File.CreateText(Server.MapPath("~/Uploads/Audit_Report/" + ComplienceAudit_ReportHtml));
            writer.WriteLine(strHTML);
            writer.Close();
            //WriteFile = Server.MapPath("~/uploads/Audit_Report/" + ComplienceAudit_ReportHtml);
            WriteFile = Constants.MainUrlMail + "/uploads/Audit_Report/" + ComplienceAudit_ReportHtml;
            // Response.WriteFile();   
        }

        public void DeleteAudit_ReportBeforeTenDays()
        {
            string[] Files = Directory.GetFiles(Server.MapPath("~/Uploads/Audit_Report/"));
            foreach (string file in Files)
            {
                string str = System.IO.File.GetLastWriteTime(file).ToString("D");
                DateTime dt = Convert.ToDateTime(str);
                DateTime oneTwentyDaysAgo = DateTime.Today.AddDays(-31);
                if (dt < oneTwentyDaysAgo)
                    File.Delete(file);

            }
        }
    }
}