using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using iKandi.Common;
using iKandi.BLL;
using System.Data;

namespace iKandi.Web.Internal.Reports
{
    public partial class FabricPurchasePdfPage : System.Web.UI.Page
    {
        AccessoryWorkingController objAccessoryWorking = new AccessoryWorkingController();
        string CompanyAddress = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DataTable dt = objAccessoryWorking.Getbipladdress("BIPLAddress3");
                CompanyAddress = dt.Rows[0]["VALUE"].ToString();
                BindTopSectionFabric();
                FabricTableQuality();
                FabricTableHistoryRevise();
                FabricTableHistory();
                FabricTableSignature();
            }
        }

        public void BindTopSectionFabric()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<table border='1' cellspacing='0' cellpadding='0'>");
            sb.Append("<tr>");
            sb.Append("<td style='border-bottom: 0px;border-right:0px;padding:4px 7px 5px;width: 363px;text-align: left;'>" + "<img src='../../images/boutique-logo.png'>" + "</td>");
            sb.Append("<td rowspan='2' style='border-bottom: 0px;border-left:0px;text-align:left;font-size: 25px;vertical-align: top;padding-top:30px'>Purchase Order</td>");
            sb.Append("</tr>");
            sb.Append("<tr><td style='border-top: 0px;border-right: 0px;text-align: left;padding-left: 4px;'>" + CompanyAddress.ToString() + "</td></tr>");
            sb.Append("<tr><td colspan='2' style='text-align:left'>PO No: <span style='width:80px;display:inline-block'>" + "ATF9" + "</span> PO Date: <span style='width:80px;display:inline-block'>" + " Date" + "</span>Supplier: <span style='width:290px;display:inline-block'>" + " Haryana Tex Prints Ltd. ₹14 (22 Days) 25 Jan 2021" + "</span> ETA Date: <span style='width:80px;display:inline-block'>" + " ETA Date" + "</span></td></tr>");
            sb.Append("<tr><td colspan='2' style='text-align:left'>Dear Sir,<br>Please Arrange Following As Per Details Given Below:</td></tr>");
            sb.Append("</table>");

            TopSection.InnerHtml = sb.ToString();
        }
        public void FabricTableQuality() {
            StringBuilder FabricTable = new StringBuilder();
            FabricTable.Append("<table border='0' border='0' cellspacing='0' cellpadding='0'>");
            FabricTable.Append("<tr>");
            FabricTable.Append("<th rowspan='2'>Fabric Quality (GSM) C&C Width <br>Color/Print</th>");
            FabricTable.Append("<th rowspan='2'>G.Sh. %</th>");
            FabricTable.Append("<th rowspan='2'>R.Sh. %</th>");
            FabricTable.Append("<th rowspan='2'>Fabric Type</th>");
            FabricTable.Append("<th colspan='3'>Quantity</th>");
            FabricTable.Append("<th colspan='2'>Finance</th>");
            FabricTable.Append("</tr>");
            FabricTable.Append("<tr>");
            FabricTable.Append("<th>Send</th>");
            FabricTable.Append("<th>Received</th>");
            FabricTable.Append("<th>Unit</th>");
            FabricTable.Append("<th>Rate</th>");
            FabricTable.Append("<th>Total Amount</th>");
            FabricTable.Append("</tr>");
            FabricTable.Append("<tr>");
            FabricTable.Append("<td>"+"1"+"</td>");
            FabricTable.Append("<td>" + "2" + "</td>");
            FabricTable.Append("<td>" + "3" + "</td>");
            FabricTable.Append("<td>" + "4" + "</td>");
            FabricTable.Append("<td>" + "5" + "</td>");
            FabricTable.Append("<td>" + "6" + "</td>");
            FabricTable.Append("<td>" + "7" + "</td>");
            FabricTable.Append("<td>" + "8" + "</td>");
            FabricTable.Append("<td>" + "9" + "</td>");
            FabricTable.Append("</tr>");
            FabricTable.Append("</table>");

            FabricQuality.InnerHtml = FabricTable.ToString();
        }

        public void FabricTableHistoryRevise()
        {
            StringBuilder FabricTableHistoryRevise = new StringBuilder();
            FabricTableHistoryRevise.Append("<table border='1' cellspacing='0' cellpadding='0' style='width:200px;background-color: #dddfe4;float:left;margin-right:20px;'>");
            FabricTableHistoryRevise.Append("<tr>");
            FabricTableHistoryRevise.Append("<th colspan='2' style='border:0px;border-bottom: 1px solid #999;background:#dddfe4'>History Of Revise Purchase Order</th>");
            FabricTableHistoryRevise.Append("</tr>");
            FabricTableHistoryRevise.Append("<tr style='background:#dddfe4'>");
            FabricTableHistoryRevise.Append("<th style='background:#dddfe4'>Date</th>");
            FabricTableHistoryRevise.Append("<th style='background:#dddfe4'>PO Quantity</th>");
            FabricTableHistoryRevise.Append("</tr>");
            FabricTableHistoryRevise.Append("<tr>");
            FabricTableHistoryRevise.Append("<td>" + "1" + "</td>");
            FabricTableHistoryRevise.Append("<td>" + "2" + "</td>");
            FabricTableHistoryRevise.Append("</tr>");
            FabricTableHistoryRevise.Append("</table>");
            FabrichistoryRevise.InnerHtml = FabricTableHistoryRevise.ToString();
        }

        public void FabricTableHistory()
        {
            StringBuilder FabricTableHistory = new StringBuilder();
            FabricTableHistory.Append("<table border='1' cellspacing='0' cellpadding='0' style='background-color: #dddfe4;width:200px;float:left;margin-top: 22px;'>");
            FabricTableHistory.Append("<tr>");
            FabricTableHistory.Append("<th style='border-top:1px solid #999'>From</th>");
            FabricTableHistory.Append("<th style='border-top:1px solid #999'>To</th>");
            FabricTableHistory.Append("<th style='border-top:1px solid #999'>Date</th>");
            FabricTableHistory.Append("</tr>");
            FabricTableHistory.Append("<tr>");
            FabricTableHistory.Append("<td>" + "1" + "</td>");
            FabricTableHistory.Append("<td>" + "2" + "</td>");
            FabricTableHistory.Append("<td>" + "3" + "</td>");
            FabricTableHistory.Append("</tr>");
            FabricTableHistory.Append("</table>");
            FabricHistory.InnerHtml = FabricTableHistory.ToString();


            GeneralInstraction.InnerText = "All Bills Must State The Purchase Order Number. Missing PO Numbers On Bills Will Nullify The Bill.";
        }

        public void FabricTableSignature()
        {
            StringBuilder FabricTableSignature = new StringBuilder();
            FabricTableSignature.Append("<table border='0' border='0' cellspacing='0' cellpadding='0' style='margin-top: 10px;'>");
            FabricTableSignature.Append("<tr>");
            FabricTableSignature.Append("<td style='text-align:left;border:0px'>Boutique International Pvt. Ltd.</td>");
            FabricTableSignature.Append("<td style='text-align:right;border:0px'>Accepted By</td>");
            FabricTableSignature.Append("</tr>");
            FabricTableSignature.Append("<tr>");
            FabricTableSignature.Append("<td style='border:0px;text-align:left'>" + "Image1" + "</td>");
            FabricTableSignature.Append("<td style='border:0px;text-align:right'>" + "Image2" + "</td>");
            FabricTableSignature.Append("</tr>");
            FabricTableSignature.Append("<tr>");
            FabricTableSignature.Append("<td style='text-align:left;border:0px'>" + "Hemant Thakur" + "</td>");
            FabricTableSignature.Append("<td style='text-align:right;border:0px'>" + "Hemant Thakur" + "</td>");
            FabricTableSignature.Append("</tr>");
            FabricTableSignature.Append("<tr>");
            FabricTableSignature.Append("<td style='text-align:left;border:0px'>" + "Date1" + "</td>");
            FabricTableSignature.Append("<td style='text-align:right;border:0px'>" + "Date2" + "</td>");
            FabricTableSignature.Append("</tr>");
            FabricTableSignature.Append("</table>");
            FabricSignature.InnerHtml = FabricTableSignature.ToString();
        }
    }
}