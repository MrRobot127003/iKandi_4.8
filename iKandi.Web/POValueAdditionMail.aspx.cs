using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iKandi.BLL.Production;
using iKandi.Common;
using System.Text;
using System.Data;

namespace iKandi.Web
{
    public partial class POValueAdditionMail : System.Web.UI.Page
    {
        public string RiskVA_SupplierId
        {
            get;
            set;
        }

        public string RiskVA_PONumber
        {
            get;
            set;
        }
        ProductionController objProductionController = new ProductionController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["RiskVASupplierId"] != null)
            {
                RiskVA_SupplierId = Request.QueryString["RiskVASupplierId"].ToString();
            }

            if (Request.QueryString["PONumber"] != null)
            {
                RiskVA_PONumber = Request.QueryString["PONumber"].ToString();
            }
            else
                RiskVA_PONumber = "0";

            if (!IsPostBack)
            {
                Bind();
            }
        }


        protected void Bind()
        {
            PO_Valueaddition objPO_Valueaddition = objProductionController.GetValueAdditonPo(Convert.ToInt32(RiskVA_SupplierId), RiskVA_PONumber);
            StringBuilder POMailSB = new StringBuilder();

            string topHeader = " <table border='0' style='width: 500px; max-width: 500px; border: 0px;font-size:10px; border-bottom: 0px;font-family: sans-serif !important;' cellspacing='0' cellpadding='0'><tr><td style='width:150px;'> <img src='http://boutique.in:82/images/200x80bipllog.png' style='width:130px;height:80px;' /></td><td style='min-width:400px;font-size:22px;font-weight:700;color:#000'>Purchase Order</td><td style='width:60px'></td></tr></table>";
            string SignatureCon = "<table border='0'  style='width: 500px; max-width: 500px; border: 0px;font-size:10px; border-bottom: 0px;font-family: sans-serif !important;' cellspacing='0' cellpadding='0'><tr><td style='width:200px;font-weight:700;color:#000'>Vendor Signature</td><td style='width:208px;font-weight:700;color:#000'>BIPL Management</td><td style='width:126px;font-weight:700;color:#000'>GM Planning/Out House</td></tr></table>";
            string StitchPoNumber = objPO_Valueaddition.PoNumber;
            string StitchDateofIssue = objPO_Valueaddition.DateofIssue == DateTime.MinValue ? "" : objPO_Valueaddition.DateofIssue.ToString("dd MMM yy");
            string StitchAgreedQty = objPO_Valueaddition.AgreedQty == 0 ? "" : objPO_Valueaddition.AgreedQty.ToString("N0");
            string StitchAgreedRate = objPO_Valueaddition.AgreedRate == 0 ? "" : objPO_Valueaddition.AgreedRate.ToString();
            string StitchDeliveryStartDate = objPO_Valueaddition.DeliveryStartDate == DateTime.MinValue ? "" : objPO_Valueaddition.DeliveryStartDate.ToString("dd MMM yy");
            string StitchDeliveryEndDate = objPO_Valueaddition.DeliveryEndDate == DateTime.MinValue ? "" : objPO_Valueaddition.DeliveryEndDate.ToString("dd MMM yy");
            string StitchDebitforLateDelivery = objPO_Valueaddition.DebitforLateDelivery == 0 ? "" : objPO_Valueaddition.DebitforLateDelivery.ToString("N0");
            string StitchActualEndDate = objPO_Valueaddition.ActualEndDate == DateTime.MinValue ? "" : objPO_Valueaddition.ActualEndDate.ToString("dd MMM yy");
            string StitchDebitforAltration = objPO_Valueaddition.DebitforAltration == 0 ? "" : objPO_Valueaddition.DebitforAltration.ToString("N0");
            string StitchSupplierName = objPO_Valueaddition.SupplierName;

            string StitchSAM = objPO_Valueaddition.SAM;
            string StitchStyleNo = objPO_Valueaddition.StyleNo;

            string VendorNameSi = "";
            string ManagemntName = "";
            string GMPlanningName = "";
            if (objPO_Valueaddition.VendorSignature == true)
            {

                VendorNameSi = objPO_Valueaddition.SupplierName;
            }
            if (objPO_Valueaddition.BIPLMngtSignature == true)
            {
                ManagemntName = "Samrat Verma";
            }
            if (objPO_Valueaddition.GMPlanningSignature == true)
            {
                GMPlanningName = "karan Gupta";
            }

            string StitchSerialNo = objPO_Valueaddition.SerialNo;
            string StitchUnit = objPO_Valueaddition.Unit;
            DataSet ds = new DataSet();
            ds = objProductionController.PO_ValueAdditionName(objPO_Valueaddition.job);
            string Stitchjob = ds.Tables[0].Rows[0].ItemArray[0].ToString();
            string StitchRemarks = objPO_Valueaddition.Remarks;

            var TermaCondition = " <ul style='font-family: sans-serif !important;text-align: justify;max-width:510px;width:510px;margin:0px;padding:15px 12px;color: #757373 !important;font-size: 8px;line-height: 16px;padding:10px 10px'> <li style='color: #757373;font-family: sans-serif !important;text-align: justify;'>All bills and challans against an order must state our purchase order number.</li> <li style='color: #757373;font-family: sans-serif !important;text-align: justify;'>Vendor must quote prices based on examining the sample in BIPL. Pcs or material cannot be taken out of premises.</li><li style='color: #757373;font-family: sans-serif !important;text-align: justify;'>Bulk cutting will only be issued once 2 Pcs have been passed by CQD in presence of proper report and technician from vendor present. Also PO must be signed for rate, quantity and delivery by vendor and counter signed by BIPL management.</li> <li style='color: #757373;font-family: sans-serif !important;text-align: justify;'>All Goods to be delivered in Poly Bags. If any goods found to be delivered without the poly bags, Company has full right to put damage and rescan charges on to the supplier. </li> <li style='color: #757373;font-family: sans-serif !important;text-align: justify;'>No invoices/bills will be entertained without PO duly signed by the management of the company.</li> <li style='color: #757373;font-family: sans-serif !important;text-align: justify;'>Any Pcs stitched outside of agreed premises will be liable for 100% agreed price discount and discontinuation of further orders.</li><li style='color: #757373;font-family: sans-serif !important;text-align: justify;'>All bills must be put within 5 days of completion of the style and 8 days prior to the 30th of every month after which bills will not be accepted. Payment cycle is 10th-15th and 26th-30th of every month. </li> <li style='color: #757373;font-family: sans-serif !important;text-align: justify;'>All samples, fabric, rejected cutting and accessories should be returned along with the last lot of delivery of goods. Anything returned after the shipment leaves will not be accepted and supplier will be liable for the same. </li><li style='color: #757373;font-family: sans-serif !important;text-align: justify;'>Dates committed on the PO must be adhered for agreed quantity. Every single day delay will cost ₹1 per piece to the supplier as late delivery charges.</li>   <li style='color: #757373;font-family: sans-serif !important;text-align: justify;'>No single piece should be dispatched from the stitching unit without QC report. Any pieces sent without the report will be returned back on suppliers cost. </li><li style='color: #757373;font-family: sans-serif !important;text-align: justify;'>Factory Manager/BIPL management holds the full right to debit for any alteration in the pieces.</li>  <li>All goods should be submitted or kept on the checking table of the factory and acknowledged by the company’s issue/receiving team within working hours only. </li></ul>";
            string StitchSignatureDate = objPO_Valueaddition.VendorSignatureDate == DateTime.MinValue ? "" : objPO_Valueaddition.VendorSignatureDate.ToString("dd MMM yy (ddd)");
            string StitchBIPLMngtSignatureDate = objPO_Valueaddition.BIPLMngtSignatureDate == DateTime.MinValue ? "" : objPO_Valueaddition.BIPLMngtSignatureDate.ToString("dd MMM yy (ddd)");
            string StitchGMPlanningSignatureDate = objPO_Valueaddition.GMPlanningSignatureDate == DateTime.MinValue ? "" : objPO_Valueaddition.GMPlanningSignatureDate.ToString("dd MMM yy (ddd)");
            string SignatureDate = "<table style='width: 500px; max-width: 500px; border: 0px;font-size:10px; border-bottom: 0px;font-family: sans-serif !important;' cellspacing='0' cellpadding='0'><tr><td style='width:200px;padding-left:8px;'>" + StitchSignatureDate + "</td><td style='width:208px;padding-left:12px'>" + StitchBIPLMngtSignatureDate + "</td><td style='width:126px;padding-left:15px'>" + StitchGMPlanningSignatureDate + "</td></tr></table>";
            string SignatureConName = "<table style='width: 500px; max-width: 500px; border: 0px;font-size:10px; border-bottom: 0px;font-family: sans-serif !important;' cellspacing='0' cellpadding='0'><tr><td style='width:200px;padding-left:3px;'>" + VendorNameSi + "</td><td style='width:208px;padding-left:12px'>" + ManagemntName + "</td><td style='width:126px;padding-left:15px'>" + GMPlanningName + "</td></tr></table>";
          
            POMailSB.Append(" <table style='width: 500px; max-width: 500px;font-size:10px;font-family: sans-serif !important;border:0px' cellspacing='0' cellpadding='0'>");
            POMailSB.Append("<tr>");
            POMailSB.Append("<td colspan='4'>" + topHeader + "</td>");
            POMailSB.Append("</tr>");

            POMailSB.Append("<tr>");
            POMailSB.Append("<td colspan='4' style='font-size:10px;color:#000;font-weight: 500;;font-weight:500;padding:2px 0px;'><b>Boutique International Private Limited</b></td>");
            POMailSB.Append("</tr>");

            POMailSB.Append("<tr>");
            POMailSB.Append("<td colspan='4' style='font-size:10px;color:#000;font-weight: 500;padding:2px 0px;'>C 45-46 Hosiery Complex, Noida Phase-2</td>");
            POMailSB.Append("</tr>");

            POMailSB.Append("<tr>");
            POMailSB.Append("<td colspan='4' style='font-size:10px;color:#000;font-weight: 500;padding:2px 0px;'>UP-201305(U.P) <b> Office:</b> +91 120 6797979</td>");
            POMailSB.Append("</tr>");


            POMailSB.Append("<tr>");
            POMailSB.Append("<td colspan='4' style='font-size:10px;color:#000;font-weight: 500;padding:2px 0px;'><b>TIN NO:</b>  09765708265<b> GSTIN :</b> 099AAACB4905C1Z5</td>");
            POMailSB.Append("</tr>");

            POMailSB.Append("<tr>");
            POMailSB.Append("<td colspan='4' style='border-bottom:1px solid #999;padding:5px 0px !important'></td>");
            POMailSB.Append("</tr>");

            POMailSB.Append("<tr>");
            POMailSB.Append("<td style='width:100px;font-size:10px;color:#757373;font-weight: 500;padding:25px 0px 3px;'>Supplier Name</td>");
            POMailSB.Append("<td style='width:120px;font-size:10px;color:#000;font-weight: 500;padding:25px 0px 3px;'>" + StitchSupplierName + "</td>");
            POMailSB.Append("<td style='width:160px;font-size:10px;color:#757373;font-weight: 500;padding:25px 0px 3px;'>Agreed Rate</td>");
            POMailSB.Append("<td style='width:100px;font-size:10px;color:#000;font-weight: 500;padding:25px 0px 3px;'>" + StitchAgreedRate + "</td>");
            POMailSB.Append("</tr>");

            POMailSB.Append("<tr>");
            POMailSB.Append("<td style='width:100px;font-size:10px;color:#757373;font-weight: 500;padding:3px 0px;'>PO No.</td>");
            POMailSB.Append("<td style='width:120px;font-size:10px;color:#000;font-weight: 500;padding:3px 0px;'>" + StitchPoNumber + "</td>");
            POMailSB.Append("<td style='width:160px;font-size:10px;color:#757373;font-weight: 500;padding:3px 0px;'>Delivery Starts From(Date)</td>");
            POMailSB.Append("<td style='width:110px;font-size:10px;color:#000;font-weight: 500;padding:3px 0px;'>" + StitchDeliveryStartDate + "</td>");
            POMailSB.Append("</tr>");

            POMailSB.Append("<tr>");
            POMailSB.Append("<td style='width:100px;font-size:10px;color:#757373;font-weight: 500;padding:3px 0px;'>Date of Issue</td>");
            POMailSB.Append("<td style='width:120px;font-size:10px;color:#000;font-weight: 500;padding:3px 0px;'>" + StitchDateofIssue + "</td>");
            POMailSB.Append("<td style='width:160px;font-size:10px;color:#757373;font-weight: 500;padding:3px 0px;'>Delivery Ends From(Date)</td>");
            POMailSB.Append("<td style='width:110px;font-size:10px;color:#000;font-weight: 500;padding:3px 0px;'>" + StitchDeliveryEndDate + "</td>");
            POMailSB.Append("</tr>");

            POMailSB.Append("<tr>");
            POMailSB.Append("<td style='width:100px;font-size:10px;color:#757373;font-weight: 500;padding:3px 0px;'>Serial No.</td>");
            POMailSB.Append("<td style='width:120px;font-size:10px;color:#000;font-weight: 500;padding:3px 0px;'>" + StitchSerialNo + "</td>");
            POMailSB.Append("<td style='width:160px;font-size:10px;color:#757373;font-weight: 500;padding:3px 0px;'>Actual Ends(Date)</td>");
            POMailSB.Append("<td style='width:110px;font-size:10px;color:#000;font-weight: 500;padding:3px 0px;'>" + StitchActualEndDate + "</td>");
            POMailSB.Append("</tr>");

            POMailSB.Append("<tr>");
            POMailSB.Append("<td style='width:100px;font-size:10px;color:#757373;font-weight: 500;padding:3px 0px;'>Style No.</td>");
            POMailSB.Append("<td style='width:120px;font-size:10px;color:#000;font-weight: 500;padding:3px 0px;'>" + StitchStyleNo + "</td>");
            POMailSB.Append("<td style='width:160px;font-size:10px;color:#757373;font-weight: 500;padding:3px 0px;'>Debit for Late Delivery</td>");
            POMailSB.Append("<td style='width:110px;font-size:10px;color:#000;font-weight: 500;padding:3px 0px;'>" + StitchDebitforLateDelivery + "</td>");
            POMailSB.Append("</tr>");

            POMailSB.Append("<tr>");
            POMailSB.Append("<td style='width:100px;font-size:10px;color:#757373;font-weight: 500;padding:3px 0px;'>SAM</td>");
            POMailSB.Append("<td style='width:120px;font-size:10px;color:#000;font-weight: 500;padding:3px 0px;'>" + StitchSAM + "</td>");
            POMailSB.Append("<td style='width:160px;font-size:10px;color:#757373;font-weight: 500;padding:3px 0px;'>Debit For Alteration</td>");
            POMailSB.Append("<td style='width:110px;font-size:10px;color:#000;font-weight: 500;padding:3px 0px;'>" + StitchDebitforAltration + "</td>");
            POMailSB.Append("</tr>");

            POMailSB.Append("<tr>");
            POMailSB.Append("<td style='width:100px;font-size:10px;color:#757373;font-weight: 500;padding:3px 0px;'>Agreed Qty.</td>");
            POMailSB.Append("<td style='width:120px;font-size:10px;color:#000;font-weight: 500;padding:3px 0px;'>" + StitchAgreedQty + " " + StitchUnit + "</td>");
            POMailSB.Append("<td style='width:160px;font-size:10px;color:#757373;font-weight: 500;padding:3px 0px;'>Type of Job</td>");
            POMailSB.Append("<td style='width:110px;font-size:10px;color:#000;font-weight: 500;padding:3px 0px;'>" + Stitchjob + "</td>");
            POMailSB.Append("</tr>");

            POMailSB.Append("<tr>");
            POMailSB.Append("<td style='width:160px;font-size:10px;color:#757373;font-weight: 500;padding:3px 0px;'>Remarks</td>");
            POMailSB.Append("<td colspan='3'><span style='font-size:10px;color:#000;font-weight: 500;'>" + StitchRemarks + "</span></td>");
            POMailSB.Append("</tr>");

            POMailSB.Append("<tr>");
            POMailSB.Append("<td colspan='4' style='color:gray;padding-top:45px'><b>Terms & Conditions</b></td>");
            POMailSB.Append("</tr>");

            POMailSB.Append("<tr>");
            POMailSB.Append("<td colspan='4'>" + TermaCondition + "</td>");
            POMailSB.Append("</tr>");

            POMailSB.Append("<tr>");
            POMailSB.Append("<td colspan='4'style='color:gray;padding:30px 10px'></td>");
            POMailSB.Append("</tr>");

            POMailSB.Append("<tr>");
            POMailSB.Append("<td colspan='4' style='font-size:10px;padding:5px 5px'>" + SignatureConName + "</td>");
            POMailSB.Append("</tr>");

            POMailSB.Append("<tr>");
            POMailSB.Append("<td colspan='4' style='font-size:10px'>" + SignatureCon + "</td>");
            POMailSB.Append("</tr>");

            POMailSB.Append("<tr>");
            POMailSB.Append("<td colspan='4' style='font-size:10px;font-weight:500;color:#000;padding:5px 0px'>" + SignatureDate + "</td>");
            POMailSB.Append("</tr>");

            POMailSB.Append("</table>");
            ValueAdditionBinddata.InnerHtml = POMailSB.ToString();

        }
    }
}