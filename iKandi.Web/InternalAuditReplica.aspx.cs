using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.IO;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text;
using iKandi.BLL;
using System.Data;

namespace iKandi.Web
{
    public partial class AuditTestReplica : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            AdminController adminController = new AdminController();
            List<Unit1> units = new List<Unit1>();
            DataSet ds = adminController.GetAllUnit();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                units.Add(new Unit1() { Id = Convert.ToString(ds.Tables[0].Rows[i]["Id"]), UnitName = Convert.ToString(ds.Tables[0].Rows[i]["UnitName"]) });
            }

            List<UnitLink> unitLinks = new List<UnitLink>();

            foreach (var unit in units)
            {
                 int count = adminController.InternalAuditCount(Convert.ToInt32(unit.Id));
                 if (count > 0)
                 {
                     DateTime now = DateTime.Now;
                     string WriteFile = "";
                     // string Day = now.ToString("dd");
                     string Month = "";
                     Month = now.AddMonths(-1).ToString("MMM");
                     string Attandence_url = "InternalAudit_" + Month + "_" + unit.UnitName + ".html";
                     WriteFile = "http://localhost:3220/Uploads/Internal_Audit/" + Attandence_url;
                     unitLinks.Add(new UnitLink() { Unithref = WriteFile, UnitName = unit.UnitName });
                 }
            }

            rptLink.DataSource = unitLinks;
            rptLink.DataBind();
        }

        class UnitLink
        {
            public string Unithref
            {
                get;
                set;
            }
            public string UnitName
            {
                get;
                set;
            }
        }

    }
}