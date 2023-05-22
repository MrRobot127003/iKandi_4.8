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
    public partial class AccessoryExChallalPdf : System.Web.UI.Page
    {
        AccessoryWorkingController objAccessoryWorking = new AccessoryWorkingController();
        string CompanyAddress = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dt = objAccessoryWorking.Getbipladdress("BIPLAddress3");
            CompanyAddress = dt.Rows[0]["VALUE"].ToString();

            BindTopSectionAccessory();
            AccessoryTableSentQty();
            AccessoryTableSignature();
        }

        public void BindTopSectionAccessory()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<table border='0'  border='0' cellspacing='0' cellpadding='0'>");
            sb.Append("<tr>");
            sb.Append("<td colspan='2' style='background: #39589c;color: #fff;font-size:15px'>Accessory challan</td>");
            sb.Append("</tr>");
            sb.Append("<tr>");
            sb.Append("<td style='border-right:0px;padding:4px 7px 5px;width: 85px;text-align: left;'>" + "<img src='../../images/boutique-logo.png'>" + "</td>");
            sb.Append("<td style='border-left:0px;text-align:left;'>" + CompanyAddress.ToString() + "</td>");
            sb.Append("</tr>");
            sb.Append("<tr>");
            sb.Append("<td style='border:0px;text-align:left;border-left:1px solid #999'>Challan No:</td>");
            sb.Append("<td style='border:0px;text-align:left;border-right:1px solid #999'>" + "Challan No" + "</td>");
            sb.Append("</tr>");
            sb.Append("<tr>");
            sb.Append("<td style='border:0px;text-align:left;border-left:1px solid #999'>Date: </td>");
            sb.Append("<td style='border:0px;text-align:left;border-right:1px solid #999'>"+"Date"+"</td>");
            sb.Append("</tr>");
            sb.Append("<tr>");
            sb.Append("<td style='border:0px;text-align:left;border-left:1px solid #999'>PO No: </td>");
            sb.Append("<td style='border:0px;text-align:left;border-right:1px solid #999'>" + "PO No" + "</td>");
            sb.Append("</tr>");
          
            sb.Append("<tr>");
            sb.Append("<td style='border:0px;text-align:left;border-left:1px solid #999'>Select: </td>");
            sb.Append("<td style='border:0px;text-align:left;border-right:1px solid #999'>" + "PO No" + "</td>");
            sb.Append("</tr>");

            sb.Append("<tr>");
            sb.Append("<td style='border:0px;text-align:left;border-left:1px solid #999'>To: <span>" + " External" + "</span></td>");
            sb.Append("<td style='border:0px;text-align:left;border-right:1px solid #999'><span style='color:#000;font-weight:600'>M/S: </span>" + "  Ansh Thread India" + "</span></td>");
            sb.Append("</tr>");
            sb.Append("<tr>");
            sb.Append("<td style='border:0px;text-align:left;border-left:1px solid #999'>Accessories/Color Print: </td>");
            sb.Append("<td style='border:0px;text-align:left;border-right:1px solid #999'>" + "<span style='color:blue'>"+"Fabric Covered Button"+"</span>"+ "(14L)"+" <span style='color:#000;font-weight:600'>rr</span>" + "</td>");
            sb.Append("</tr>");
            sb.Append("<td style='border:0px;text-align:left;border-left:1px solid #999;border-bottom:1px solid #999'>Description</td>");
            sb.Append("<td style='border:0px;text-align:left;border-right:1px solid #999;border-bottom:1px solid #999'>" + "Fabric Covered Button" + "</td>");
            sb.Append("</tr>");
            sb.Append("</table>");

            TopSection.InnerHtml = sb.ToString();
        }
        public void AccessoryTableSentQty()
        {
            StringBuilder AccessoryTableSignature = new StringBuilder();
            AccessoryTableSignature.Append("<table border='0' border='0' cellspacing='0' cellpadding='0'>");
            AccessoryTableSignature.Append("<tr>");
            AccessoryTableSignature.Append("<td style='text-align:left;border-right:0px;'>Send Qty. <span style='color:#000'>" + " 1,234 " +"</span>"+ "Unit" +"</td>");
            AccessoryTableSignature.Append("<td style='text-align:left;border-left:0px;'>Remaining Qty. <span style='color:#000'>" + " 4563 " + "</span>" + "Unit" + "</td>");
            AccessoryTableSignature.Append("</tr>");
            AccessoryTableSignature.Append("</table>");
            AccessoryRemaQty.InnerHtml = AccessoryTableSignature.ToString();
        }
        public void AccessoryTableSignature()
        {
            StringBuilder FabricTableSignature = new StringBuilder();
            FabricTableSignature.Append("<table border='0' border='0' cellspacing='0' cellpadding='0'>");
            FabricTableSignature.Append("<tr>");
            FabricTableSignature.Append("<td style='text-align:left;border:0px;color:#000;font-weight: 600;'>Received the goods in good condition</td>");
            FabricTableSignature.Append("<td style='text-align:right;border:0px;color:#000;font-weight: 600;'>Boutique International Pvt. Ltd.</td>");
            FabricTableSignature.Append("</tr>");
            FabricTableSignature.Append("<tr>");
            FabricTableSignature.Append("<td style='border:0px;text-align:left'>" + "Image1" + "</td>");
            FabricTableSignature.Append("<td style='border:0px;text-align:right'>" + "Image2" + "</td>");
            FabricTableSignature.Append("</tr>");
            FabricTableSignature.Append("<tr>");
            FabricTableSignature.Append("<td style='text-align:left;border:0px'>" + " Receiver's Signature" + "</td>");
            FabricTableSignature.Append("<td style='text-align:right;border:0px'>" + "Authorized Signature" + "</td>");
            FabricTableSignature.Append("</tr>");
            //FabricTableSignature.Append("<tr>");
            //FabricTableSignature.Append("<td style='text-align:left;border:0px'>" + "Date1" + "</td>");
            //FabricTableSignature.Append("<td style='text-align:right;border:0px'>" + "Date2" + "</td>");
            //FabricTableSignature.Append("</tr>");
            FabricTableSignature.Append("</table>");
            FabricSignature.InnerHtml = FabricTableSignature.ToString();
        }
    }
}