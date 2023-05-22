using System;
using System.Data;
using iKandi.Common;
using System.IO;
using iKandi.BLL;

using System.Collections.Generic;
using iTextSharp.text;
using System.Net.Mail;
using System.Web.UI;

//created By Girish 

namespace iKandi.Web
{
    public partial class MaterialDetailsAccessory : System.Web.UI.Page
    {
        AdminController objadmin = new AdminController();
        ReportController controller = new ReportController();

        readonly string Accessory_Po_Detail = "Accessory_PO_Detail";
        readonly string Accessory_Supplier_summary = "Accessory_Supplier_summary";
        readonly string Accessory_PO_Supplier_Summary = "Accessory_PO_Supplier_Summary";
        readonly string Accessory_Issued_Quantity = "Accessory_Issued_Quantity";
        readonly string Accessory_Daily_Report = "Accessory_Daily_Report";
        readonly string Daily_Accessory_Movement = "Daily Accessory Movement";

        readonly string Stock_Summary_Excel = "Stock Summary Excel_A";
        readonly string Stock_Summary_Mail = "Stock Summary Mail_A";


        Boolean isDebug = Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings["isDebug"]);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["Type"] != null && Request.QueryString["Type"].ToString() != "")
            {
                string Type = Request.QueryString["Type"].ToString();
                if (Type.ToLower() == Accessory_Po_Detail.ToLower())
                {
                    string ReportMailBodyHeader = @"<div style='font-family:arial; font-size:12px;padding:0 15px;'>
                                                    <div style='padding: 10px 0 0 10px;color: #39589c;font-size: 14px;'> Hi Team,</div>
                                                         <br/> 
                                                    <div style='padding: 10px 0 0 10px;color: #39589c;font-size: 14px;'>Please Find the Details and Excel attached. </div> 
                                                        <br/>

                                                    <style>
                                                            .sticky1 {
                                                              position: -webkit-sticky;
                                                              position: sticky;
                                                              top: 0;                                                          
                                                            }
                                                       .sticky {
                                                              position: -webkit-sticky;
                                                              position: sticky;
                                                              top: 18px;                                                          
                                                            }
                                                    </style>                
                                                    ";

                    string ReportMailBody1 = "", ReportMailBody2 = "", ReportMailBody3 = "", ReportMailBody4 = "";

                    ReportMailBody1 = CreateMailBody(objadmin.GetMaterialReport(Stock_Summary_Mail), Stock_Summary_Mail);
                    ReportMailBody2 = CreateMailBody(objadmin.GetMaterialReport(Accessory_Daily_Report), Accessory_Daily_Report);
                    ReportMailBody3 = CreateMailBody(objadmin.GetMaterialReport(Accessory_Supplier_summary), Accessory_Supplier_summary);
                    ReportMailBody4 = CreateMailBody(objadmin.GetMaterialReport(Accessory_PO_Supplier_Summary), Accessory_PO_Supplier_Summary);

                    string FinalBody = ReportMailBodyHeader + "<br>" +
                                        ReportMailBody1 + "<br>" +
                                        ReportMailBody2 + "<br>" +
                                        ReportMailBody3 + "<br>" +
                                        ReportMailBody4;

                    Response.Write(FinalBody);

                    CreateExcel(objadmin.GetMaterialReport(Accessory_Po_Detail), Accessory_Po_Detail);
                    CreateExcel(objadmin.GetMaterialReport(Accessory_Issued_Quantity), Accessory_Issued_Quantity);
                    CreateExcel(objadmin.GetMaterialReport(Daily_Accessory_Movement), Daily_Accessory_Movement);
                    CreateExcel(objadmin.GetMaterialReport(Stock_Summary_Excel), Stock_Summary_Excel);


                    SendEmailWithAttachment(Accessory_Po_Detail, FinalBody);
                }
                else
                {
                    Response.Write("wrong parameter");
                }
            }
            else
            {
                Response.Write("Nothing");
            }

        }

        private string CreateMailBody(DataSet ds, string ReportMailType)
        {
            string ReportMailBody = "";
            if (ReportMailType == "Stock Summary Mail_A")
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ReportMailBody += @"
                                            <table cellspacing='0' cellpadding='3'  style='font-size: 9px !important; text-align:center;border: 1px solid #a5a5a5;border-collapse: collapse;'>
                                            <tbody>
                                                  <tr class='' style='background-color:#e4e2e2; color:#484747;border: 1px solid #a5a5a5;'>
                                                  <td colspan='13'>Stock Summary Report</td> 
                                                 </tr>

                                                 <tr class='' style='background-color:#e4e2e2; color:#484747;border: 1px solid #a5a5a5;'>                                               
                                                    <td rowspan='2' style='border: 1px solid #a5a5a5;'>Supply Type</td>
                                                    <td colspan='2' style='border: 1px solid #a5a5a5;'>Global Stock</td>
                                                    <td colspan='2' style='border: 1px solid #a5a5a5;'>With Processor</td>
                                                    <td colspan='2' style='border: 1px solid #a5a5a5;'>SRV IN Inspection</td>
                                                    <td colspan='2' style='border: 1px solid #a5a5a5;'>Pass Stock</td>
                                                    <td colspan='2' style='border: 1px solid #a5a5a5;'>Fail Stock</td>
                                                    <td colspan='2' style='border: 1px solid #a5a5a5;color:blue;'>Total</td>
                                                </tr>
                                                <tr class='' style='background-color:#E4E2E2; color:#484747;border: 1px solid #a5a5a5;'>
                                                    <td style='border: 1px solid #a5a5a5;'>Qty.</td>
                                                    <td style='border: 1px solid #a5a5a5;'>Value (L)</td>

                                                    <td style='border: 1px solid #a5a5a5;'>Qty.</td>
                                                    <td style='border: 1px solid #a5a5a5;'>Value (L)</td>

                                                    <td style='border: 1px solid #a5a5a5;'>Qty.</td>
                                                    <td style='border: 1px solid #a5a5a5;'>Value (L)</td>

                                                    <td style='border: 1px solid #a5a5a5;'>Qty.</td>
                                                    <td style='border: 1px solid #a5a5a5;'>Value (L)</td>

                                                    <td style='border: 1px solid #a5a5a5;'>Qty.</td>
                                                    <td style='border: 1px solid #a5a5a5;'>Value (L)</td>

                                                    <td style='border: 1px solid #a5a5a5;color:blue;'>Qty.</td>
                                                    <td style='border: 1px solid #a5a5a5;color:blue;'>Value (L)</td>
                                                </tr>";

                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        if (dr["SupplyType"].ToString().ToLower() == "Total".ToLower())
                        {
                            ReportMailBody += @"<tr style='border: 1px solid #a5a5a5;'>
                                                    <td style='border: 1px solid #a5a5a5;background-color:#f9f9fae8;color:blue;'>" + dr["SupplyType"] + @"</td>

                                                    <td style='border: 1px solid #a5a5a5;background-color:#ffffbf;color:blue;'>" + dr["GlobalStock_Qty"] + @"</td>
                                                    <td style='border: 1px solid #a5a5a5;background-color:#ffffbf;color:blue;'>" + dr["GlobalStock_Value"] + @"</td>

                                                    <td style='border: 1px solid #a5a5a5;background-color:#ffffbf;color:blue;'>" + dr["WithProcessor_Qty"] + @"</td>
                                                    <td style='border: 1px solid #a5a5a5;background-color:#ffffbf;color:blue;'>" + dr["WithProcessor_Value"] + @"</td>
                                                  
                                                    <td style='border: 1px solid #a5a5a5;background-color:#ffffbf;color:blue;'>" + dr["SRVInInspection_Qty"] + @"</td>
                                                    <td style='border: 1px solid #a5a5a5;background-color:#ffffbf;color:blue;'>" + dr["SRVInInspection_Value"] + @"</td>
                                                   
                                                    <td style='border: 1px solid #a5a5a5;background-color:#ffffbf;color:blue;'>" + dr["PassStock_Qty"] + @"</td>
                                                    <td style='border: 1px solid #a5a5a5;background-color:#ffffbf;color:blue;'>" + dr["PassStock_Value"] + @"</td>
                                                     
                                                    <td style='border: 1px solid #a5a5a5;background-color:#ffffbf;color:blue;'>" + dr["FailedStock_Qty"] + @"</td>
                                                    <td style='border: 1px solid #a5a5a5;background-color:#ffffbf;color:blue;'>" + dr["FailedStock_value"] + @"</td>

                                                    <td style='border: 1px solid #a5a5a5;background-color:#ffffbf;color:blue;'>" + dr["TotalQty"] + @"</td>
                                                    <td style='border: 1px solid #a5a5a5;background-color:#ffffbf;color:blue;'>" + dr["TotalValue"] + @"</td>
                                                </tr>  
                                              ";

                        }
                        else
                        {
                            ReportMailBody += @"<tr style='border: 1px solid #a5a5a5;'>
                                                    <td style='background-color:#f9f9fae8;border: 1px solid #a5a5a5;'>" + dr["SupplyType"] + @"</td>

                                                    <td style='background-color:#f9f9fae8;border: 1px solid #a5a5a5;'>" + dr["GlobalStock_Qty"] + @"</td>
                                                    <td style='background-color:#F2F2F2;border: 1px solid #a5a5a5;'>" + dr["GlobalStock_Value"] + @"</td>

                                                    <td style='background-color:#f9f9fae8;border: 1px solid #a5a5a5;'>" + dr["WithProcessor_Qty"] + @"</td>
                                                    <td style='background-color:#F2F2F2;border: 1px solid #a5a5a5;'>" + dr["WithProcessor_Value"] + @"</td>
                                                  
                                                    <td style='background-color:#f9f9fae8;border: 1px solid #a5a5a5;'>" + dr["SRVInInspection_Qty"] + @"</td>
                                                    <td style='background-color:#F2F2F2;border: 1px solid #a5a5a5;'>" + dr["SRVInInspection_Value"] + @"</td>
                                                   
                                                    <td style='background-color:#f9f9fae8;border: 1px solid #a5a5a5;'>" + dr["PassStock_Qty"] + @"</td>
                                                    <td style='background-color:#F2F2F2;border: 1px solid #a5a5a5;'>" + dr["PassStock_Value"] + @"</td>
                                                     
                                                    <td style='background-color:#f9f9fae8;border: 1px solid #a5a5a5;'>" + dr["FailedStock_Qty"] + @"</td>
                                                    <td style='background-color:#F2F2F2;border: 1px solid #a5a5a5;'>" + dr["FailedStock_value"] + @"</td>

                                                    <td style='border: 1px solid #a5a5a5;background-color:#ffffbf;color:blue;'>" + dr["TotalQty"] + @"</td>
                                                    <td style='border: 1px solid #a5a5a5;background-color:#ffffbf;color:blue;'>" + dr["TotalValue"] + @"</td>
                                                </tr>  
                                              ";
                        }
                    }
                }
                ReportMailBody += @"    </tbody>
                                        </table>
                                                ";
            }
            else if (ReportMailType == Accessory_Daily_Report)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {

                        ReportMailBody += @"
                                            <table  cellspacing='0' cellpadding='3'  style='font-size: 9px !important; text-align:center;border-collapse: collapse;border: 1px solid #a5a5a5;'>
                                            <tbody>
                                                <tr class='sticky' style='background-color:#E4E2E2; color:#484747;border: 1px solid #a5a5a5;'>
                                                    <td colspan='7'>Daily In/Out Summary Report (This is Complete Value Including all Stage Prices.)</td>     
                                                 </tr>

                                                 <tr class='sticky1' style='background-color:#E4E2E2; color:#484747;border: 1px solid #a5a5a5;'>                                               
                                                    <td rowspan='2' style='border: 1px solid #a5a5a5;'></td>
                                                    <td colspan='2' style='border: 1px solid #a5a5a5;'>Greige</td>
                                                    <td colspan='2' style='border: 1px solid #a5a5a5;'>Process</td>
                                                    <td colspan='2' style='border: 1px solid #a5a5a5;'>Finished</td>
                                                </tr>
                                                <tr class='sticky2' style='background-color:#E4E2E2; color:#484747;border: 1px solid #a5a5a5;'>
                                                    <td style='border: 1px solid #a5a5a5;'>Qty.</td>
                                                    <td style='border: 1px solid #a5a5a5;'>Value (L)</td>

                                                    <td style='border: 1px solid #a5a5a5;'>Qty.</td>
                                                    <td style='border: 1px solid #a5a5a5;'>Value (L)</td>

                                                    <td style='border: 1px solid #a5a5a5;'>Qty.</td>
                                                    <td style='border: 1px solid #a5a5a5;'>Value (L)</td>
                                                </tr>

                                                <tr style='border: 1px solid #a5a5a5;'>
                                                    <td style='background-color:aliceblue;border: 1px solid #a5a5a5;'>SRV IN</td>

                                                    <td style='background-color:#f9f9fae8;border: 1px solid #a5a5a5;'>" + dr["GriegeSRVIn"] + @"</td>
                                                    <td style='background-color:#F2F2F2;border: 1px solid #a5a5a5;'>" + dr["GriegeSRVInValue"] + @"</td>

                                                    <td style='background-color:#f9f9fae8;border: 1px solid #a5a5a5;'>" + dr["ProcessSRVIn"] + @"</td>
                                                    <td style='background-color:#F2F2F2;border: 1px solid #a5a5a5;'>" + dr["ProcessSRVInValue"] + @"</td>
                                                  
                                                    <td style='background-color:#f9f9fae8;border: 1px solid #a5a5a5;'>" + dr["FinishSRVIn"] + @"</td>
                                                    <td style='background-color:#F2F2F2;border: 1px solid #a5a5a5;'>" + dr["FinishSRVInValue"] + @"</td>                                                 
                                                     

                                                </tr>

                                                <tr style='border: 1px solid #a5a5a5;'>
                                                    <td style='background-color:aliceblue;'>SRV OUT </td>

                                                    <td style='background-color:#f9f9fae8;border: 1px solid #a5a5a5;'>" + dr["GriegeSRVOut"] + @"</td>
                                                    <td style='background-color:#F2F2F2;border: 1px solid #a5a5a5;'>" + dr["GriegeSRVOutValue"] + @"</td>
                                                     
                                                    <td style='background-color:#f9f9fae8;border: 1px solid #a5a5a5;'>" + dr["ProcessSRVOut"] + @"</td>
                                                    <td style='background-color:#F2F2F2;border: 1px solid #a5a5a5;'>" + dr["ProcessSRVOutValue"] + @"</td>
                                               
                                                    <td style='background-color:#f9f9fae8;border: 1px solid #a5a5a5;'>" + dr["FinishSRVOut"] + @"</td>
                                                    <td style='background-color:#F2F2F2;border: 1px solid #a5a5a5;'>" + dr["FinishSRVOutValue"] + @"</td>
                                                    
                                                </tr>
                                                <tr style='border: 1px solid #a5a5a5;border: 1px solid #a5a5a5;'>
                                                    <td style='background-color:aliceblue;border: 1px solid #a5a5a5;'>4 Point Inspection Pass</td>

                                                    <td style='background-color:#f9f9fae8;border: 1px solid #a5a5a5;'>" + dr["GriegePassQty"] + @"</td>
                                                    <td style='background-color:#F2F2F2;border: 1px solid #a5a5a5;'>" + dr["GriegePassQtyValue"] + @"</td>

                                                    
                                                    <td style='background-color:#f9f9fae8;border: 1px solid #a5a5a5;'>" + dr["ProcessPassQty"] + @"</td>
                                                    <td style='background-color:#F2F2F2;border: 1px solid #a5a5a5;'>" + dr["ProcessPassQtyValue"] + @"</td>

                                                   
                                                    <td style='background-color:#f9f9fae8;border: 1px solid #a5a5a5;'>" + dr["FinishPassQty"] + @"</td>
                                                    <td style='background-color:#F2F2F2;border: 1px solid #a5a5a5;'>" + dr["FinishPassQtyValue"] + @"</td>

                                                
                                               </tr>

                                                <tr style='border: 1px solid #a5a5a5;'>
                                                    <td style='background-color:aliceblue;border: 1px solid #a5a5a5;'>Issue to Cutting</td>

                                                    <td style='background-color:#f9f9fae8;border: 1px solid #a5a5a5;'>" + dr["GriegeIssueQty"] + @"</td>
                                                    <td style='background-color:#F2F2F2;border: 1px solid #a5a5a5;'>" + dr["GriegeIssueQtyValue"] + @"</td>

                                                
                                                    <td style='background-color:#f9f9fae8;border: 1px solid #a5a5a5;'>" + dr["ProcessIssueQty"] + @"</td>
                                                    <td style='background-color:#F2F2F2;border: 1px solid #a5a5a5;'>" + dr["ProcessIssueQtyValue"] + @"</td>

                                                   
                                                    <td style='background-color:#f9f9fae8;border: 1px solid #a5a5a5;'>" + dr["FinishIssueQty"] + @"</td>
                                                    <td style='background-color:#F2F2F2;border: 1px solid #a5a5a5;'>" + dr["FinishIssueQtyValue"] + @"</td>
                                                   
                                                </tr>

                                              ";
                    }
                }
                ReportMailBody += @"    </tbody>
                                        </table>
                                                ";

            }

            else if (ReportMailType == Accessory_Supplier_summary)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ReportMailBody += @"<table cellspacing='0' cellpadding='3'  style='font-size: 9px !important; text-align:center;border-collapse: collapse;border: 1px solid #a5a5a5;'>
                                            <tbody>
                                                <tr class='sticky1' style='background-color:#E4E2E2; color:#484747;border: 1px solid #a5a5a5;'>
                                                    <td rowspan='2' style='border: 1px solid #a5a5a5;'>Supplier</td>

                                                    <td colspan='2' style='border: 1px solid #a5a5a5;'>Total Active PO</td>
                                                    <td colspan='2' style='border: 1px solid #a5a5a5;'>With Mill</td>
                                                    <td colspan='2' style='border: 1px solid #a5a5a5;'>Inhouse</td>

                                                </tr>
                                                <tr class='sticky' style='background-color:#E4E2E2; color:#484747;border: 1px solid #a5a5a5;'>
                                                    <td style='border: 1px solid #a5a5a5;'>Qty (With Unit)</td>
                                                    <td style='border: 1px solid #a5a5a5;'>Value (L)</td>

                                                    <td style='border: 1px solid #a5a5a5;'>Qty (With Unit)</td>                                                   
                                                    <td style='border: 1px solid #a5a5a5;'>Value (L)</td>

                                                    <td style='border: 1px solid #a5a5a5;'>Qty (With Unit)</td>
                                                    <td style='border: 1px solid #a5a5a5;'>Value (L)</td>                                             
                                                </tr>";
                    int i = 1;
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {

                        if (i == 1)
                        {
                            ReportMailBody += @"    <tr style='border: 1px solid #a5a5a5;'> ";

                        }
                        if ("100000" == dr["RowSpan"].ToString()) { i = 1; }
                        else { i++; }

                        if (i == 1)
                        {
                            ReportMailBody += @"    <td style='text-align: left; !important; background-color: aliceblue;border: 1px solid #a5a5a5;'>" + dr["SupplierName"] + @"</td>                                                 
                                                    <td style='background-color: #ffffbf;border: 1px solid #a5a5a5;'>" + dr["POQty"] + @"</td>
                                                    <td style='background-color: #ffffbf;border: 1px solid #a5a5a5;'>" + dr["PoValue"] + @"</td>
                                                    <td style='background-color: #ffffbf;border: 1px solid #a5a5a5;'>" + dr["MillQty"] + @"</td>
                                                    <td style='background-color: #ffffbf;border: 1px solid #a5a5a5;'>" + dr["MillValue"] + @"</td>
                                                    <td style='background-color: #ffffbf;border: 1px solid #a5a5a5;'>" + dr["InhouseQty"] + @"</td>
                                                    <td style='background-color: #ffffbf;border: 1px solid #a5a5a5;'>" + dr["InhouseValue"] + @"</td>
                                                </tr>";
                        }
                        else
                        {
                            ReportMailBody += @"    <td style='text-align: left; !important; background-color: aliceblue;border: 1px solid #a5a5a5;'>" + dr["SupplierName"] + @"</td>                                                 
                                                    <td style='background-color: #f9f9fae8;border: 1px solid #a5a5a5;'>" + dr["POQty"] + @"</td>
                                                    <td style='background-color: #F2F2F2;border: 1px solid #a5a5a5;'>" + dr["PoValue"] + @"</td>
                                                    <td style='background-color: #f9f9fae8;border: 1px solid #a5a5a5;'>" + dr["MillQty"] + @"</td>
                                                    <td style='background-color: #F2F2F2;border: 1px solid #a5a5a5;'>" + dr["MillValue"] + @"</td>
                                                    <td style='background-color: #f9f9fae8;border: 1px solid #a5a5a5;'>" + dr["InhouseQty"] + @"</td>
                                                    <td style='background-color: #F2F2F2;border: 1px solid #a5a5a5;'>" + dr["InhouseValue"] + @"</td>
                                                </tr>";
                        }
                    }
                }
                ReportMailBody += @"    </tbody>
                                        </table>";
            }

            else if (ReportMailType == Accessory_PO_Supplier_Summary)
            {


                if (ds.Tables[0].Rows.Count > 0)
                {
                    ReportMailBody += @"<table cellspacing='0' cellpadding='3'  style='font-size: 9px !important; text-align:center;border-collapse: collapse;border: 1px solid #a5a5a5;'>
                                            <tbody>
                                                <tr class='sticky1' style='background-color:#E4E2E2; color:#484747;border: 1px solid #a5a5a5;'>

                                                    <td rowspan='2' style='border: 1px solid #a5a5a5;'>Supplier</td>
                                                    <td rowspan='2' style='border: 1px solid #a5a5a5;'>AccessoryName</td>
                                                    <td rowspan='2' style='border: 1px solid #a5a5a5;'>Size</td>

                                                    <td colspan='2' style='border: 1px solid #a5a5a5;'>Griege</td>
                                                    <td colspan='2' style='border: 1px solid #a5a5a5;'>Process</td>
                                                    <td colspan='2' style='border: 1px solid #a5a5a5;'>Finish</td>                                                    
                                                </tr>
                                                <tr class='sticky' style='background-color:#E4E2E2; color:#484747;border: 1px solid #a5a5a5;'>

                                                   <td style='border: 1px solid #a5a5a5;'>PO QTY (With Unit)</td>
                                                   <td style='border: 1px solid #a5a5a5;'>Value (L)</td>    

                                                    <td style='border: 1px solid #a5a5a5;'>PO QTY (With Unit)</td>
                                                   <td style='border: 1px solid #a5a5a5;'>Value (L)</td>  

                                                    <td style='border: 1px solid #a5a5a5;'>PO QTY (With Unit)</td>
                                                   <td style='border: 1px solid #a5a5a5;'>Value (L)</td>                                              
                                                </tr>";
                    int i = 1, j = 1;
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {


                        ReportMailBody += @"    <tr style='border: 1px solid #a5a5a5;'> ";
                        if (i == 1)
                        {
                            ReportMailBody += @"    <td rowspan='" + dr["RowSpan"] + @"' style='text-align: left !important; background-color: aliceblue;border: 1px solid #a5a5a5;'>" + dr["SupplierName"] + @"</td> ";
                            j++;
                        }
                        if ("100000" == dr["RowSpan"].ToString()) { i = 1; j = 1; } else { i++; j++; }

                        if (j == 1)
                        {
                            ReportMailBody += @"    <td style='text-align: left; !important; background-color: aliceblue;border: 1px solid #a5a5a5;'>" + dr["AccessoryName"] + @"</td>
                                                    <td style='background-color:  #ffffbf;color:#a3a4a5;border: 1px solid #a5a5a5;'>" + dr["Size"] + @"</td>
                                                
                                                    <td style='background-color:  #ffffbf;border: 1px solid #a5a5a5;'>" + dr["GriegePoQty"] + @"</td>
                                                    <td style='background-color:  #ffffbf;border: 1px solid #a5a5a5;'>" + dr["GriegePOValue"] + @"</td>
                                                    <td style='background-color:  #ffffbf;border: 1px solid #a5a5a5;'>" + dr["ProcessPoQty"] + @"</td>
                                                    <td style='background-color:  #ffffbf;border: 1px solid #a5a5a5;'>" + dr["ProcessPoValue"] + @"</td>
                                                    <td style='background-color:  #ffffbf;border: 1px solid #a5a5a5;'>" + dr["FinishPoQty"] + @"</td>
                                                    <td style='background-color:  #ffffbf;border: 1px solid #a5a5a5;'>" + dr["FinishPoValue"] + @"</td>
                                                </tr> ";
                        }
                        else
                        {
                            ReportMailBody += @"  
                                                    <td style='text-align: left; !important; background-color: aliceblue;border: 1px solid #a5a5a5;'>" + dr["AccessoryName"] + @"</td>
                                                    <td style='background-color: #f9f9fae8;color:#a3a4a5;border: 1px solid #a5a5a5;'>" + dr["Size"] + @"</td>
                        
                                                    <td style='background-color: #f9f9fae8;border: 1px solid #a5a5a5;'>" + dr["GriegePoQty"] + @"</td>
                                                    <td style='background-color: #F2F2F2;border: 1px solid #a5a5a5;'>" + dr["GriegePOValue"] + @"</td>
                                                    <td style='background-color: #f9f9fae8;border: 1px solid #a5a5a5;'>" + dr["ProcessPoQty"] + @"</td>
                                                    <td style='background-color: #F2F2F2;border: 1px solid #a5a5a5;'>" + dr["ProcessPoValue"] + @"</td>
                                                    <td style='background-color: #f9f9fae8;border: 1px solid #a5a5a5;'>" + dr["FinishPoQty"] + @"</td>
                                                    <td style='background-color: #F2F2F2;border: 1px solid #a5a5a5;'>" + dr["FinishPoValue"] + @"</td>

                                                </tr> ";
                        }

                    }

                    ReportMailBody += @"    </tbody>
                                        </table>";

                }

                ReportMailBody += @"                
                                    <strong style='padding: 10px 0 0 10px;color: #39589c;'>Thanks & Best Regards </strong> 
                                        <br/>     <br/> 
                                    <strong style='padding: 10px 0 0 10px;color: #39589c;'> BIPL Team</strong> 
                                    <div style='margin-top:10px; padding: 10px 0 0 10px;'>   
                                        <img src='http://boutique.in/images/certificate.jpg' />
                                    </div></div>";
            }
            return ReportMailBody;
        }

        private void CreateExcel(DataSet ds, string ReportMailType)
        {
            string sourcePath = @"E:\";
            string FileName = ReportMailType + ".xlsx";

            if ((System.IO.File.Exists(Constants.MATERIAL_FOLDER_PATH + FileName))) { System.IO.File.Delete(Constants.MATERIAL_FOLDER_PATH + FileName); }

            string targetPath_Accessory_PO_Details = Constants.MATERIAL_FOLDER_PATH + FileName;

            string sourceFile_Accessory_PO_Details = System.IO.Path.Combine(sourcePath, FileName);

            System.IO.File.Copy(sourceFile_Accessory_PO_Details, targetPath_Accessory_PO_Details, true);

            string ExcelFilePath_Accessory_PO_Details = Path.Combine(Constants.MATERIAL_FOLDER_PATH, FileName);

            bool success_Rescan = controller.GenerateMaterialReportExcel(ExcelFilePath_Accessory_PO_Details, ReportMailType, ds);
        }

        private Boolean SendEmailWithAttachment(string ReportMailType, string ReportMailBody)
        {
            try
            {
                String fromName = BLLCache.GetConfigurationKeyValue("FROMEMAIL");
                List<String> to = new List<String>();

                NotificationController objcontroller = new NotificationController();
                DataSet ds = objcontroller.GetpRODUCTMAIL(ReportMailType);
                DataTable dt = ds.Tables[0];
                string email = ds.Tables[0].Rows[0]["EmailName"].ToString();
                string[] email2 = email.Split(',');
                foreach (string em in email2) { to.Add(em); }

                if (ReportMailType != string.Empty)
                {
                    if (ReportMailType == Accessory_Po_Detail)
                    {
                        List<Attachment> atts = new List<Attachment>();

                        string ExcellPath = "";

                        if (File.Exists(Constants.MATERIAL_FOLDER_PATH + "Accessory_PO_Detail.xlsx"))
                        {
                            ExcellPath = Path.Combine(Constants.MATERIAL_FOLDER_PATH, "Accessory_PO_Detail.xlsx");
                            atts.Add(new Attachment(ExcellPath));
                        }
                        if (File.Exists(Constants.MATERIAL_FOLDER_PATH + "Accessory_Issued_Quantity.xlsx"))
                        {
                            ExcellPath = Path.Combine(Constants.MATERIAL_FOLDER_PATH, "Accessory_Issued_Quantity.xlsx");
                            atts.Add(new Attachment(ExcellPath));
                        }
                        if (File.Exists(Constants.MATERIAL_FOLDER_PATH + "Daily Accessory Movement.xlsx"))
                        {
                            ExcellPath = Path.Combine(Constants.MATERIAL_FOLDER_PATH, "Daily Accessory Movement.xlsx");
                            atts.Add(new Attachment(ExcellPath));
                        }
                        if (File.Exists(Constants.MATERIAL_FOLDER_PATH + "Stock Summary Excel_A.xlsx"))
                        {
                            ExcellPath = Path.Combine(Constants.MATERIAL_FOLDER_PATH, "Stock Summary Excel_A.xlsx");
                            atts.Add(new Attachment(ExcellPath));
                        }
                        this.SendEmail(fromName, to, null, null, "Accessory Po Details", ReportMailBody, atts);
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                return false;
            }
        }

        private Boolean SendEmail(String FromEmail, List<String> To, List<String> CC, List<String> BCC, String MailSubject, String Content, List<Attachment> Attachments)
        {
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(FromEmail);
            mailMessage.ReplyTo = new MailAddress(FromEmail);
            mailMessage.Priority = MailPriority.Normal;
            mailMessage.Subject = MailSubject;
            mailMessage.IsBodyHtml = true;


            AlternateView htmlView = AlternateView.CreateAlternateViewFromString(Content, null, "text/html");
            mailMessage.AlternateViews.Add(htmlView);

            mailMessage.Body = Content;

            if (isDebug)
            {
                mailMessage.To.Add(System.Configuration.ConfigurationManager.AppSettings["debugModeEmailId"]);
            }
            else
            {
                foreach (String to in To)
                    mailMessage.To.Add(to);

                if (CC != null)
                    foreach (String to in CC)
                        mailMessage.CC.Add(to);

                if (BCC != null)
                    foreach (String to in BCC)
                        mailMessage.Bcc.Add(to);

                mailMessage.Bcc.Add(System.Configuration.ConfigurationManager.AppSettings["debugModeEmailId"]);
            }

            SmtpClient smtpClient = new SmtpClient(Constants.SMTP_HOST, Constants.SMTP_PORT);

            if (Attachments != null)
            {
                foreach (Attachment att in Attachments)
                {
                    mailMessage.Attachments.Add(att);
                }
            }

            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.Timeout = Constants.SMTP_TIMEOUT;

            if (Constants.SMTP_SECURE)
            {
                smtpClient.EnableSsl = true;
            }

            if (Constants.SMTP_IS_AUTH_REQUIRED)
            {
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new System.Net.NetworkCredential(Constants.SMTP_USERNAME, Constants.SMTP_PASSWORD);
            }
            try
            {
                smtpClient.Timeout = 300000;
                smtpClient.Send(mailMessage);
                System.Diagnostics.Trace.WriteLine("Email Having Subject of --" + MailSubject.ToString() + " is send successfully on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt") + "\n");
                return true;

            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Some error has been occur in Email having subject of ---" + MailSubject.ToString() + " On" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                System.Diagnostics.Trace.WriteLine("Sorry !! Email has not been send on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt") + "\n");
                return false;
            }

            finally
            {
                try
                {
                    if (Attachments != null)
                    {
                        foreach (Attachment att in Attachments)
                        {
                            att.Dispose();
                        }

                        Attachments = null;
                    }

                    foreach (Attachment att in mailMessage.Attachments)
                    {
                        att.Dispose();
                    }

                    mailMessage = null;

                }
                catch (Exception ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                }
            }
        }
    }
}