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

namespace iKandi.Web
{
    public partial class frmComplaineOutHouse_AuditMail : System.Web.UI.Page
    {
        AdminController objadmin = new AdminController();
        ReportController controller = new ReportController();
        ProductionController objProductionController = new ProductionController();

        string MailType = string.Empty;
        string Flag = string.Empty;
        string EmailContent = string.Empty;
        string WriteFile;
        protected void Page_Load(object sender, EventArgs e)
        {
            randorComplianceHtml_OutHouse();
        }
        public void randorComplianceHtml_OutHouse()
        {
            WebRequest quest;
            WebResponse ponse;
            StreamReader reader;
            StreamWriter writer;
            string strHTML;
            ProductionController objProductionController = new ProductionController();
            DataSet dtClients = objProductionController.GetSlotId();

            quest = WebRequest.Create(Constants.MainIpMail + "/ComplienceAuditReport.aspx?processType=-1&UnitId=-1");
            quest.Timeout = Convert.ToInt32(99999999);
            ponse = quest.GetResponse();
            reader = new StreamReader(ponse.GetResponseStream());

            strHTML = reader.ReadToEnd();

            string ComplienceAudit_ReportHtml = "";
            DateTime now = DateTime.Now;
            string Day = now.ToString("dd");
            string Month = now.ToString("MMM");

            ComplienceAudit_ReportHtml = "ComplienceAuditReport_Out_House_" + Day + "_" + Month + ".html";
            writer = File.CreateText(Server.MapPath("~/Uploads/Audit_Report/" + ComplienceAudit_ReportHtml));
            writer.WriteLine(strHTML);
            writer.Close();
            // WriteFile = Server.MapPath("~/uploads/Audit_Report/" + ComplienceAudit_ReportHtml);
            WriteFile = Constants.MainUrlMail + "/uploads/Audit_Report/" + ComplienceAudit_ReportHtml;
            // Response.WriteFile();   
        }
    }
}