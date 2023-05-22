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
using System.Collections.Generic;
using iKandi.BLL;
using System.Text;

namespace iKandi.Web.Internal.Fabric
{
    public partial class FabricAMPerformanceReport : System.Web.UI.Page
    {

        public static int QualityId
        {
            get;
            set;
        }
        public static int OrderDetailID
        {
            get;
            set;
        }
        public static string FabricDetails
        {
            get;
            set;
        }
        public static string Fabric
        {
            get;
            set;
        }
        iKandi.BLL.OrderProcessController obj_ProcessController = new BLL.OrderProcessController();
        protected void Page_Load(object sender, EventArgs e)
        {

            GetQueryString();
            if (!Page.IsPostBack)
            {
                FabricAMPerFormanceRep();
            }

        }
        public void GetQueryString()
        {
            if (Request.QueryString["QualityId"] != null)
                QualityId = Convert.ToInt32(Request.QueryString["QualityId"]);
            else
            {
                //OrderID = 7182; //1fab
                QualityId = 23; //4feb
                //OrderID = 8983; //2feb
            }
            if (Request.QueryString["OrderDetailID"] != null)
                OrderDetailID = Convert.ToInt32(Request.QueryString["OrderDetailID"]);
            else
                OrderDetailID = 30518;

            if (Request.QueryString["FabricDetails"] != null)
                FabricDetails = Request.QueryString["FabricDetails"].ToString();
            else
                FabricDetails = "red";

            if (Request.QueryString["Fabric"] != null)
                Fabric = Request.QueryString["Fabric"].ToString();
            else
                Fabric = "N/A";


        }

        protected void FabricAMPerFormanceRep()
        {
            StringBuilder FabricPer = new StringBuilder();
            DataSet ds = obj_ProcessController.Get_FabricFinish_details(QualityId, OrderDetailID, FabricDetails);
            DataTable dtGetFinished = ds.Tables[0];
          
            int CountRow = dtGetFinished.Columns.Count - 2;
            FabricPer.Append("<table cellspace='0' cellpadding='0' class='AddClass_Table'>");
            foreach (DataRow dr in dtGetFinished.Rows)
            {
                int SeqID = Convert.ToInt32(dr[0]);
                if (SeqID == 1) // for Difrent color for Stock Moved Qty
                {
                    FabricPer.Append("<tr style='background:#FFFF99'>");
                }
                else
                {
                    FabricPer.Append("<tr>");
                }               

                if (SeqID == 0) // for header
                {
                    FabricPer.Append("<th>" + dr[1] + "</th>");
                    for (int i = 0; i < CountRow; i++)
                    {
                        string thclassname = "";
                        if (CountRow == 1) { thclassname = "minColwidthOne"; }
                        else if (CountRow == 2) { thclassname = "minColwidth_2"; }
                        else { thclassname = "minColwidth"; }
                        FabricPer.Append("<th class='" + thclassname + "'><b>" + dr[i + 2] + "</b></th>");
                    }
                }
                else
                {
                    FabricPer.Append("<td>" + dr[1] + "</td>");
                    for (int i = 0; i < CountRow; i++)
                    {
                        if (SeqID == 2 || SeqID == 7) // for mearge of "AM Fabric Approval Date" and "Cut Issue Date (%)"
                        {
                            if (i == 0) { FabricPer.Append("<td colspan='" + CountRow + "' style='color:black'>" + dr[i + 2] + "</td>"); }
                            else { FabricPer.Append("<td style='display:none'>" + dr[i + 2] + "</td>"); }
                        }
                        else { FabricPer.Append("<td style='width:100px' class='tdclass'>" + dr[i + 2] + "</td>"); }
                    }
                }
                FabricPer.Append("</tr>");
            }
            FabricPer.Append("</table>");
            FabricperFormance.InnerHtml = FabricPer.ToString();           

        }
    }
}