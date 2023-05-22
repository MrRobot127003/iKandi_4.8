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

namespace iKandi.Web
{
    public partial class frm_Reallocation_Outhouse_Emb : System.Web.UI.Page
    {
        string MailType = string.Empty;
        string Flag = string.Empty;
        
        string EmailContent = string.Empty;
        string WriteFile;

        protected void Page_Load(object sender, EventArgs e)
        {
            randorHourlyHtml();
            Application["Reallocation_Outhouse_Emb"] = WriteFile;

        }
        public void randorHourlyHtml()
        {
            WebRequest quest;
            WebResponse ponse;
            StreamReader reader;
            StreamWriter writer;
            string strHTML;
            ProductionController objProductionController = new ProductionController();
            DataSet dtClients = objProductionController.GetSlotId();

            // Give your ASP.NET Page address
            if (HttpContext.Current.Request.Url.Host.ToString() == "localhost")
            {
                quest = WebRequest.Create("http://localhost:3240/Reallocation_Outhouse_Emb.aspx");
            }
            else
            {
                quest = WebRequest.Create("http://192.168.0.4/Reallocation_Outhouse_Emb.aspx");
            }
            quest.Timeout = Convert.ToInt32(99999999);
            ponse = quest.GetResponse();
            reader = new StreamReader(ponse.GetResponseStream());

            strHTML = reader.ReadToEnd();

           

            string Reallocation_ReportHtml = "";
            DateTime now = DateTime.Now;
            string Day = now.ToString("dd");
            string Month = now.ToString("MMM");

            Reallocation_ReportHtml = "Reallocation_Outhouse_Emb_" + Day + Month + ".html";
            writer = File.CreateText(Server.MapPath("~/Uploads/Reallocation_Report/" + Reallocation_ReportHtml));
            writer.WriteLine(strHTML);
            writer.Close();
            //WriteFile = Server.MapPath("~/Uploads/Fits/" + HourlyReportHtml);
            if (HttpContext.Current.Request.Url.Host.ToString() == "localhost")
            {
                WriteFile = "http://localhost:3240/uploads/Reallocation_Report/" + Reallocation_ReportHtml;
            }
            else
            {
                WriteFile = "http://www.boutique.in/uploads/Reallocation_Report/" + Reallocation_ReportHtml;
            }
            // Response.WriteFile();   
        }
       

        public void DeleteHrsReportBeforeTenDays()
        {
            string[] Files = Directory.GetFiles(Server.MapPath("~/Uploads/HrlyReports/"));
            foreach (string file in Files)
            {
                string str = System.IO.File.GetLastWriteTime(file).ToString("D");
                DateTime dt = Convert.ToDateTime(str);
                DateTime oneTwentyDaysAgo = DateTime.Today.AddDays(-10);
                if (dt < oneTwentyDaysAgo)
                    File.Delete(file);

            }
        }
    }
}