using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using iKandi.BLL.Production;
using System.Data;

namespace iKandi.Web
{
    public partial class VAMinRate_Rrport : System.Web.UI.Page
    {
        ProductionController objProductionController = new ProductionController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
               
            }
        }

        protected void BindData()
        { 
            
             
           DataTable dt = objProductionController.VAMinRateReport();

            StringBuilder VAMinRateVal = new StringBuilder();

            VAMinRateVal.Append("<table class='CommoAdmin_Table' cellspacing='0' cellpadding='0' style='width: 700px; max-width: 700px;border:0px'>");
            VAMinRateVal.Append("<tr>");
            VAMinRateVal.Append("<th colspan='7' style='text-align:center'><span style='font-size:12px;font-weight:700;color:#000'>VA Min Rate Report</span></th>");
            VAMinRateVal.Append("</tr>");
            VAMinRateVal.Append("<tr>");
            VAMinRateVal.Append("<th style='width:40px;max-width:40px;text-align:center'>Sr.No.</th>");
            //VAMinRateVal.Append("<th style='width:80px;max-width:80px;'>From Status</th>");
            //VAMinRateVal.Append("<th style='width:80px;max-width:80px;'>To Status</th>");
            VAMinRateVal.Append("<th style='width:150px;max-width:150px;'>VA Name</th>");
            VAMinRateVal.Append("<th style='width:70px;max-width:70px;'>Lowest Rate</th>");
            VAMinRateVal.Append("<th style='width:110px;max-width:110px;'>Lowest Rate Date</th>");
            VAMinRateVal.Append("<th style='width:130px;max-width:130px;'>Lowest Rate Vendor</th>");
            VAMinRateVal.Append("<th style='width:180px;max-width:180px;'>Other Vendors</th>");
            VAMinRateVal.Append("</tr>");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var Podate = Convert.ToDateTime(dt.Rows[i]["PO_Date"]).ToString("dd MMM yy (ddd)");
                VAMinRateVal.Append("<tr>");
                VAMinRateVal.Append("<td style='width:40px;max-width:40px;color:gray' class='alignCenter'>" + dt.Rows[i]["P_Id"] + "</td>");
                VAMinRateVal.Append("<td style='width:150px;max-width:150px;'>" + dt.Rows[i]["ValueAdditionName"] + "</td>");
                VAMinRateVal.Append("<td style='width:70px;max-width:70px;text-align:right;'>" + dt.Rows[i]["Rate"] + "</td>");
                VAMinRateVal.Append("<td style='width:120px;max-width:120px;'>" + Podate + "</td>");
                VAMinRateVal.Append("<td style='width:180px;max-width:130px;'>" + dt.Rows[i]["SupplerName"] + "</td>");
                VAMinRateVal.Append("<td style='width:180px;max-width:180px;'>" + dt.Rows[i]["Another_Supplier"] + "</td>");
                VAMinRateVal.Append("</tr>");
            }
            VAMinRateVal.Append("</table>");

            VAMinRate.InnerHtml = VAMinRateVal.ToString();
        }


        //protected void BindVendor()
        //{


        //    DataTable dt = objProductionController.VendorServiceDetails();

        //    StringBuilder VendorServiceDet = new StringBuilder();

        //    VendorServiceDet.Append("<table class='CommoAdmin_Table' cellspacing='0' cellpadding='0' style='width: 400px; max-width: 400px;'>");
        //    VendorServiceDet.Append("<tr>");
        //    VendorServiceDet.Append("<th colspan='3'><span style='font-size:12px;font-weight:700;color:#000'>Vendor VA Service Details</span></th>");
        //    VendorServiceDet.Append("</tr>");
        //    VendorServiceDet.Append("<tr>");
        //    VendorServiceDet.Append("<th style='width:40px;max-width:40px;'>Sr.No.</th>");
        //    VendorServiceDet.Append("<th style='width:140px;max-width:140px;'>Vendor Name</th>");
        //    VendorServiceDet.Append("<th style='width:180px;max-width:180px;'>VA Handled</th>");
        //    VendorServiceDet.Append("</tr>");
        //    for (int i = 0; i < dt.Rows.Count; i++)
        //    {
        //        VendorServiceDet.Append("<tr>");
        //        VendorServiceDet.Append("<td  style='width:50px;max-width:50px;color:gray' class='alignCenter'>" + dt.Rows[i]["P_Id"] + "</td>");
        //        VendorServiceDet.Append("<td  style='width:150px;max-width:150px;'>" + dt.Rows[i]["Supplier"] + "</td>");
        //        VendorServiceDet.Append("<td style='width:200px;max-width:200px;'>" + dt.Rows[i]["ValueAddition"] + "</td>");
        //        VendorServiceDet.Append("</tr>");
        //    }
        //    VendorServiceDet.Append("</table>");

        //    VendorService.InnerHtml = VendorServiceDet.ToString();
        //}


    }
}