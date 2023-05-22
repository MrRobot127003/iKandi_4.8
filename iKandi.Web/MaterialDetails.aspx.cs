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
    public partial class MaterialDetails : System.Web.UI.Page
    {
        AdminController objadmin = new AdminController();
        ReportController controller = new ReportController();

        readonly string Fabric_Po_Detail = "Fabric_PO_Detail";
        readonly string Fabric_Supplier_summary = "Fabric_Supplier_summary";
        readonly string Fabric_PO_Supplier_Summary = "Fabric_PO_Supplier_Summary";
        readonly string Cut_Issue_Status = "Cut Issue Status";
        readonly string Fabric_Daily_Report = "Fabric_Daily_Report";
        readonly string Production_Stock_Detail = "Production Stock Detail";
        readonly string Daily_Fabric_Movement = "Daily Fabric Movement";

        readonly string Stock_Summary_Excel = "Stock Summary Excel";
        readonly string Stock_Summary_Mail = "Stock Summary Mail";
        readonly string Latest_Three_PORates = "Rates";

        Boolean isDebug = Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings["isDebug"]);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["Type"] != null && Request.QueryString["Type"].ToString() != "")
            {
                string Type = Request.QueryString["Type"].ToString();

                if (Type.ToLower() == Fabric_Po_Detail.ToLower())
                {
                    string ReportMailBodyHeader = @"
                                                 <div style='font-family:arial; font-size:12px;padding:0 15px;'>
                                                    <div style='padding: 10px 0 0 10px;color: #39589c;font-size: 14px;'> Hi Team,</div>
                                                        <br/> 
                                                    <div style='padding: 10px 0 0 10px;color: #39589c;font-size: 14px;'>Please Find the Details and Excel Attached. </div> 
                                                        <br/>
                                                    <style>                                                            
                                                            .sticky {
                                                              position: -webkit-sticky;
                                                              position: sticky;
                                                              top: 0px;                                                          
                                                            }
                                                            .sticky1 {
                                                              position: -webkit-sticky;
                                                              position: sticky;
                                                              top: 18px;                                                          
                                                            }
                                                            .sticky2 {
                                                              position: -webkit-sticky;
                                                              position: sticky;
                                                              top: 30px;                                                          
                                                            }
                                                    </style>                
                                                    ";

                    string ReportMailBody1 = "", ReportMailBody2 = "", ReportMailBody3 = "", ReportMailBody4 = "";

                    ReportMailBody1 = CreateMailBody(objadmin.GetMaterialReport(Stock_Summary_Mail), Stock_Summary_Mail);
                    ReportMailBody2 = CreateMailBody(objadmin.GetMaterialReport(Fabric_Daily_Report), Fabric_Daily_Report);
                    ReportMailBody3 = CreateMailBody(objadmin.GetMaterialReport(Fabric_Supplier_summary), Fabric_Supplier_summary);
                    ReportMailBody4 = CreateMailBody(objadmin.GetMaterialReport(Fabric_PO_Supplier_Summary), Fabric_PO_Supplier_Summary);

                    string FinalBody = ReportMailBodyHeader + "<br>" +
                                        ReportMailBody1 + "<br>" +
                                        ReportMailBody2 + "<br>" +
                                        ReportMailBody3 + "<br>" +
                                        ReportMailBody4;

                    Response.Write(FinalBody);

                    CreateExcel(objadmin.GetMaterialReport(Fabric_Po_Detail), Fabric_Po_Detail);
                    CreateExcel(objadmin.GetMaterialReport(Cut_Issue_Status), Cut_Issue_Status);
                    CreateExcel(objadmin.GetMaterialReport(Production_Stock_Detail), Production_Stock_Detail);
                    CreateExcel(objadmin.GetMaterialReport(Daily_Fabric_Movement), Daily_Fabric_Movement);
                    CreateExcel(objadmin.GetMaterialReport(Stock_Summary_Excel), Stock_Summary_Excel);
                    CreateExcel(objadmin.GetMaterialReport(Latest_Three_PORates), Latest_Three_PORates);


                    SendEmailWithAttachment(Fabric_Po_Detail, FinalBody);
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

            if (ReportMailType == "Stock Summary Mail")
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
                                                    <td style='border: 1px solid #a5a5a5;background-color:#f9f9fae8;color:blue;'>" + dr["SupplyType"]               + @"</td>

                                                    <td style='border: 1px solid #a5a5a5;background-color:#ffffbf;color:blue;'>"   + dr["GlobalStock_Qty"]          + @"</td>
                                                    <td style='border: 1px solid #a5a5a5;background-color:#ffffbf;color:blue;'>"   + dr["GlobalStock_Value"]        + @"</td>

                                                    <td style='border: 1px solid #a5a5a5;background-color:#ffffbf;color:blue;'>"   + dr["WithProcessor_Qty"]        + @"</td>
                                                    <td style='border: 1px solid #a5a5a5;background-color:#ffffbf;color:blue;'>"   + dr["WithProcessor_Value"]      + @"</td>
                                                  
                                                    <td style='border: 1px solid #a5a5a5;background-color:#ffffbf;color:blue;'>"   + dr["SRVInInspection_Qty"]      + @"</td>
                                                    <td style='border: 1px solid #a5a5a5;background-color:#ffffbf;color:blue;'>"   + dr["SRVInInspection_Value"]    + @"</td>
                                                   
                                                    <td style='border: 1px solid #a5a5a5;background-color:#ffffbf;color:blue;'>"   + dr["PassStock_Qty"]            + @"</td>
                                                    <td style='border: 1px solid #a5a5a5;background-color:#ffffbf;color:blue;'>"   + dr["PassStock_Value"]          + @"</td>
                                                     
                                                    <td style='border: 1px solid #a5a5a5;background-color:#ffffbf;color:blue;'>"   + dr["FailedStock_Qty"]          + @"</td>
                                                    <td style='border: 1px solid #a5a5a5;background-color:#ffffbf;color:blue;'>"   + dr["FailedStock_value"]        + @"</td>

                                                    <td style='border: 1px solid #a5a5a5;background-color:#ffffbf;color:blue;'>"   + dr["TotalQty"]                 + @"</td>
                                                    <td style='border: 1px solid #a5a5a5;background-color:#ffffbf;color:blue;'>"   + dr["TotalValue"]               + @"</td>
                                                </tr>  
                                              ";

                        }
                        else
                        {
                            ReportMailBody += @"<tr style='border: 1px solid #a5a5a5;'>
                                                    <td style='background-color:#f9f9fae8;border: 1px solid #a5a5a5;'>"          + dr["SupplyType"]             + @"</td>

                                                    <td style='background-color:#f9f9fae8;border: 1px solid #a5a5a5;'>"          + dr["GlobalStock_Qty"]        + @"</td>
                                                    <td style='background-color:#F2F2F2;border: 1px solid #a5a5a5;'>"            + dr["GlobalStock_Value"]      + @"</td>

                                                    <td style='background-color:#f9f9fae8;border: 1px solid #a5a5a5;'>"          + dr["WithProcessor_Qty"]      + @"</td>
                                                    <td style='background-color:#F2F2F2;border: 1px solid #a5a5a5;'>"            + dr["WithProcessor_Value"]    + @"</td>
                                                  
                                                    <td style='background-color:#f9f9fae8;border: 1px solid #a5a5a5;'>"          + dr["SRVInInspection_Qty"]    + @"</td>
                                                    <td style='background-color:#F2F2F2;border: 1px solid #a5a5a5;'>"            + dr["SRVInInspection_Value"]  + @"</td>
                                                   
                                                    <td style='background-color:#f9f9fae8;border: 1px solid #a5a5a5;'>"          + dr["PassStock_Qty"]          + @"</td>
                                                    <td style='background-color:#F2F2F2;border: 1px solid #a5a5a5;'>"            + dr["PassStock_Value"]        + @"</td>
                                                     
                                                    <td style='background-color:#f9f9fae8;border: 1px solid #a5a5a5;'>"          + dr["FailedStock_Qty"]        + @"</td>
                                                    <td style='background-color:#F2F2F2;border: 1px solid #a5a5a5;'>"            + dr["FailedStock_value"]      + @"</td>

                                                    <td style='border: 1px solid #a5a5a5;background-color:#ffffbf;color:blue;'>" + dr["TotalQty"]               + @"</td>
                                                    <td style='border: 1px solid #a5a5a5;background-color:#ffffbf;color:blue;'>" + dr["TotalValue"]             + @"</td>
                                                </tr>  
                                              ";
                        }
                    }
                }
                ReportMailBody += @"    </tbody>
                                        </table>
                                                ";
            }

            else if (ReportMailType == "Fabric_Daily_Report")
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {

                        ReportMailBody += @"
                                            <table cellspacing='0' cellpadding='3'  style='font-size: 9px !important; text-align:center;border: 1px solid #a5a5a5;border-collapse: collapse;'>
                                            <tbody>
                                                <tr class='' style='background-color:#e4e2e2; color:#484747;border: 1px solid #a5a5a5;'>
                                                    <td colspan='15'>Daily In/Out Summary Report (This is Complete Value Including all Stage Prices.)</td>         
                                                 </tr>

                                                 <tr class='' style='background-color:#e4e2e2; color:#484747;border: 1px solid #a5a5a5;'>                                               
                                                    <td rowspan='2' style='border: 1px solid #a5a5a5;'></td>
                                                    <td colspan='2' style='border: 1px solid #a5a5a5;'>Greige</td>
                                                    <td colspan='2' style='border: 1px solid #a5a5a5;'>Dyed</td>
                                                    <td colspan='2' style='border: 1px solid #a5a5a5;'>Print</td>
                                                    <td colspan='2' style='border: 1px solid #a5a5a5;'>Finished</td>
                                                    <td colspan='2' style='border: 1px solid #a5a5a5;'>RFD</td>
                                                    <td colspan='2' style='border: 1px solid #a5a5a5;'>Embellishment</td>
                                                    <td colspan='2' style='border: 1px solid #a5a5a5;'>Embroidery</td>


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

                                                    <td style='border: 1px solid #a5a5a5;'>Qty.</td>
                                                    <td style='border: 1px solid #a5a5a5;'>Value (L)</td>

                                                    <td style='border: 1px solid #a5a5a5;'>Qty.</td>
                                                    <td style='border: 1px solid #a5a5a5;'>Value (L)</td>
                                                </tr>

                                                <tr style='border: 1px solid #a5a5a5;'>
                                                    <td style='background-color:aliceblue;border: 1px solid #a5a5a5;'>SRV IN</td>

                                                    <td style='background-color:#f9f9fae8;border: 1px solid #a5a5a5;'>" + dr["GriegeSRVIn"]             + @"</td>
                                                    <td style='background-color:#F2F2F2;border: 1px solid #a5a5a5;'>"   + dr["GriegeSRVInValue"]        + @"</td>

                                                    <td style='background-color:#f9f9fae8;border: 1px solid #a5a5a5;'>" + dr["DyedSRVIn"]               + @"</td>
                                                    <td style='background-color:#F2F2F2;border: 1px solid #a5a5a5;'>"   + dr["DyedSRVInValue"]          + @"</td>
                                                  
                                                    <td style='background-color:#f9f9fae8;border: 1px solid #a5a5a5;'>" + dr["PrintSRVIn"]              + @"</td>
                                                    <td style='background-color:#F2F2F2;border: 1px solid #a5a5a5;'>"   + dr["PrintSRVInValue"]         + @"</td>
                                                   
                                                    <td style='background-color:#f9f9fae8;border: 1px solid #a5a5a5;'>" + dr["FinishedSRVIn"]           + @"</td>
                                                    <td style='background-color:#F2F2F2;border: 1px solid #a5a5a5;'>"   + dr["FinishedSRVInValue"]      + @"</td>
                                                     
                                                    <td style='background-color:#f9f9fae8;border: 1px solid #a5a5a5;'>" + dr["RFDSRVIn"]                + @"</td>
                                                    <td style='background-color:#F2F2F2;border: 1px solid #a5a5a5;'>"   + dr["RFDSRVInValue"]           + @"</td>
                                                     
                                                    <td style='background-color:#f9f9fae8;border: 1px solid #a5a5a5;'>" + dr["EmbellishmentSRVIn"]      + @"</td>
                                                    <td style='background-color:#F2F2F2;border: 1px solid #a5a5a5;'>"   + dr["EmbellishmentSRVInValue"] + @"</td>
                                                     
                                                    <td style='background-color:#f9f9fae8;border: 1px solid #a5a5a5;'>" + dr["EmbroiderySRVIn"]         + @"</td>
                                                    <td style='background-color:#F2F2F2;border: 1px solid #a5a5a5;'>"   + dr["EmbroiderySRVInValue"]    + @"</td>
                                                     

                                                </tr>
                                                <tr style='border: 1px solid #a5a5a5;'>
                                                    <td style='background-color:aliceblue;border: 1px solid #a5a5a5;'>SRV OUT </td>

                                                    <td style='background-color:#f9f9fae8;border: 1px solid #a5a5a5;'>" + dr["GriegeSRVOut"]                + @"</td>
                                                    <td style='background-color:#F2F2F2;border: 1px solid #a5a5a5;'>"   + dr["GriegeSRVOutValue"]           + @"</td>
                                                     
                                                    <td style='background-color:#f9f9fae8;border: 1px solid #a5a5a5;'>" + dr["DyedSRVOut"]                  + @"</td>
                                                    <td style='background-color:#F2F2F2;border: 1px solid #a5a5a5;'>"   + dr["DyedSRVOutValue"]             + @"</td>
                                               
                                                    <td style='background-color:#f9f9fae8;border: 1px solid #a5a5a5;'>" + dr["PrintSRVOut"]                 + @"</td>
                                                    <td style='background-color:#F2F2F2;border: 1px solid #a5a5a5;'>"   + dr["PrintSRVOutValue"]            + @"</td>
                                                    
                                                    <td style='background-color:#f9f9fae8;border: 1px solid #a5a5a5;'>" + dr["FinishedSRVOut"]              + @"</td>
                                                    <td style='background-color:#F2F2F2;border: 1px solid #a5a5a5;'>"   + dr["FinishedSRVOutValue"]         + @"</td>
                                                    
                                                    <td style='background-color:#f9f9fae8;border: 1px solid #a5a5a5;'>" + dr["RFDSRVOut"]                   + @"</td>
                                                    <td style='background-color:#F2F2F2;border: 1px solid #a5a5a5;'>"   + dr["RFDSRVOutValue"]              + @"</td>
                                                     
                                                    <td style='background-color:#f9f9fae8;border: 1px solid #a5a5a5;'>" + dr["EmbellishmentSRVOut"]         + @"</td>
                                                    <td style='background-color:#F2F2F2;border: 1px solid #a5a5a5;'>"   + dr["EmbellishmentSRVOutValue"]    + @"</td>
                                                   
                                                    <td style='background-color:#f9f9fae8;border: 1px solid #a5a5a5;'>" + dr["EmbroiderySRVOut"]            + @"</td>
                                                    <td style='background-color:#F2F2F2;border: 1px solid #a5a5a5;'>"   + dr["EmbroiderySRVOutValue"]       + @"</td>
                                                    
                                                </tr>
                                                <tr style='border: 1px solid #a5a5a5;'>
                                                    <td style='background-color:aliceblue;border: 1px solid #a5a5a5;'>4 Point Inspection Pass</td>

                                                    <td style='background-color:#f9f9fae8;border: 1px solid #a5a5a5;'>" + dr["GriegePassQty"]               + @"</td>
                                                    <td style='background-color:#F2F2F2;border: 1px solid #a5a5a5;'>"   + dr["GriegePassQtyValue"]          + @"</td>

                                                    
                                                    <td style='background-color:#f9f9fae8;border: 1px solid #a5a5a5;'>" + dr["DyedPassQty"]                 + @"</td>
                                                    <td style='background-color:#F2F2F2;border: 1px solid #a5a5a5;'>"   + dr["DyedPassQtyValue"]            + @"</td>

                                                   
                                                    <td style='background-color:#f9f9fae8;border: 1px solid #a5a5a5;'>" + dr["PrintPassQty"]                + @"</td>
                                                    <td style='background-color:#F2F2F2;border: 1px solid #a5a5a5;'>"   + dr["PrintPassQtyValue"]           + @"</td>

                                                    
                                                    <td style='background-color:#f9f9fae8;border: 1px solid #a5a5a5;'>" + dr["FinishedPassQty"]             + @"</td>
                                                    <td style='background-color:#F2F2F2;border: 1px solid #a5a5a5;'>"   + dr["FinishedPassQtyValue"]        + @"</td>

                                                   
                                                    <td style='background-color:#f9f9fae8;border: 1px solid #a5a5a5;'>" + dr["RFDPassQty"]                  + @"</td>
                                                    <td style='background-color:#F2F2F2;border: 1px solid #a5a5a5;'>"   + dr["RFDPassQtyValue"]             + @"</td>

                                                  
                                                    <td style='background-color:#f9f9fae8;border: 1px solid #a5a5a5;'>" + dr["EmbellishmentPassQty"]        + @"</td>
                                                    <td style='background-color:#F2F2F2;border: 1px solid #a5a5a5;'>"   + dr["EmbellishmentPassQtyValue"]   + @"</td>

                                                  
                                                    <td style='background-color:#f9f9fae8;border: 1px solid #a5a5a5;'>" + dr["EmbroideryPassQty"]           + @"</td>
                                                    <td style='background-color:#F2F2F2;border: 1px solid #a5a5a5;'>"   + dr["EmbroideryPassQtyValue"]      + @"</td>

                                                
                                                </tr>
                                                <tr style='border: 1px solid #a5a5a5;'>
                                                    <td style='background-color:aliceblue;border: 1px solid #a5a5a5;'>Issue to Cutting</td>

                                                    <td style='background-color:#f9f9fae8;border: 1px solid #a5a5a5;'>"     + dr["GriegeIssueQty"]              + @"</td>
                                                    <td style='background-color:#F2F2F2;border: 1px solid #a5a5a5;'>"       + dr["GriegeIssueQtyValue"]         + @"</td>

                                                
                                                    <td style='background-color:#f9f9fae8;border: 1px solid #a5a5a5;'>"     + dr["DyedIssueQty"]                + @"</td>
                                                    <td style='background-color:#F2F2F2;border: 1px solid #a5a5a5;'>"       + dr["DyedIssueQtyValue"]           + @"</td>

                                                   
                                                    <td style='background-color:#f9f9fae8;border: 1px solid #a5a5a5;'>"     + dr["PrintIssueQty"]               + @"</td>
                                                    <td style='background-color:#F2F2F2;border: 1px solid #a5a5a5;'>"       + dr["PrintIssueQtyValue"]          + @"</td>

                                                    
                                                    <td style='background-color:#f9f9fae8;border: 1px solid #a5a5a5;'>"     + dr["FinishedIssueQty"]            + @"</td>
                                                    <td style='background-color:#F2F2F2;border: 1px solid #a5a5a5;'>"       + dr["FinishedIssueQtyValue"]       + @"</td>

                                                   
                                                    <td style='background-color:#f9f9fae8;border: 1px solid #a5a5a5;'>"     + dr["RFDssueQty"]                  + @"</td>
                                                    <td style='background-color:#F2F2F2;border: 1px solid #a5a5a5;'>"       + dr["RFDIssueQtyValue"]            + @"</td>

                                               
                                                    <td style='background-color:#f9f9fae8;border: 1px solid #a5a5a5;'>"     + dr["EmbellishmentIssueQty"]       + @"</td>
                                                    <td style='background-color:#F2F2F2;border: 1px solid #a5a5a5;'>"       + dr["EmbellishmentIssueQtyValue"]  + @"</td>

                                               
                                                    <td style='background-color:#f9f9fae8;border: 1px solid #a5a5a5;'>"     + dr["EmbroideryIssueQty"]          + @"</td>
                                                    <td style='background-color:#F2F2F2;border: 1px solid #a5a5a5;'>"       + dr["EmbroideryIssueQtyValue"]     + @"</td>
                                                </tr>

                                              ";
                    }
                }
                ReportMailBody += @"    </tbody>
                                        </table>
                                                ";

            }

            else if (ReportMailType == "Fabric_Supplier_summary")
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ReportMailBody += @"
                                           <table cellspacing='0' cellpadding='3'  style='font-size: 9px !important; text-align:center;border: 1px solid #a5a5a5;border-collapse: collapse;'>
                                                <tbody>
                                                    <tr class='' style='background-color:#e4e2e2; color:#484747;border: 1px solid #a5a5a5;'>
                                                        <td rowspan='2' style='border: 1px solid #a5a5a5;'>Supplier</td>

                                                        <td colspan='2' style='border: 1px solid #a5a5a5;'>Total Active PO</td>
                                                        <td colspan='2' style='border: 1px solid #a5a5a5;'>With Mill</td>
                                                        <td colspan='2' style='border: 1px solid #a5a5a5;'>Inhouse</td>

                                                    </tr>
                                                    <tr class='' style='background-color:#e4e2e2; color:#484747;border: 1px solid #a5a5a5;'>
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
                            ReportMailBody += @"    <td style='text-align: left; !important; background-color: aliceblue;border: 1px solid #a5a5a5;'>"  + dr["SupplierName"]    + @"</td>                                                 
                                                    <td style='background-color: #ffffbf;border: 1px solid #a5a5a5;'>"                                  + dr["POQty"]           + @"</td>
                                                    <td style='background-color: #ffffbf;border: 1px solid #a5a5a5;'>"                                  + dr["PoValue"]         + @"</td>
                                                    <td style='background-color: #ffffbf;border: 1px solid #a5a5a5;'>"                                  + dr["MillQty"]         + @"</td>
                                                    <td style='background-color: #ffffbf;border: 1px solid #a5a5a5;'>"                                  + dr["MillValue"]       + @"</td>
                                                    <td style='background-color: #ffffbf;border: 1px solid #a5a5a5;'>"                                  + dr["InhouseQty"]      + @"</td>
                                                    <td style='background-color: #ffffbf;border: 1px solid #a5a5a5;'>"                                  + dr["InhouseValue"]    + @"</td>
                                                </tr>";
                        }
                        else
                        {
                            ReportMailBody += @"    <td style='text-align: left; !important; background-color: aliceblue;border: 1px solid #a5a5a5;'>"  + dr["SupplierName"]    + @"</td>                                                 
                                                    <td style='background-color: #f9f9fae8;border: 1px solid #a5a5a5;'>"                                + dr["POQty"]           + @"</td>
                                                    <td style='background-color: #F2F2F2;border: 1px solid #a5a5a5;''>"                                 + dr["PoValue"]         + @"</td>
                                                    <td style='background-color: #f9f9fae8;border: 1px solid #a5a5a5;''>"                               + dr["MillQty"]         + @"</td>
                                                    <td style='background-color: #F2F2F2;border: 1px solid #a5a5a5;''>"                                 + dr["MillValue"]       + @"</td>
                                                    <td style='background-color: #f9f9fae8;border: 1px solid #a5a5a5;''>"                               + dr["InhouseQty"]      + @"</td>
                                                    <td style='background-color: #F2F2F2;border: 1px solid #a5a5a5;''>"                                 + dr["InhouseValue"]    + @"</td>
                                                </tr>";

                        }
                    }


                }
                ReportMailBody += @"    </tbody>
                                        </table>
                                         ";


            }
            else if (ReportMailType == "Fabric_PO_Supplier_Summary")
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ReportMailBody += @"<table  cellspacing='0' cellpadding='3' style='font-size: 9px !important; text-align:center; margin-bottom: 20px;width:100%;border: 1px solid #a5a5a5;border-collapse: collapse;'>
                                            <tbody>
                                                <tr class='' style='background-color:#e4e2e2; color:#484747;border: 1px solid #a5a5a5;'>
                                                    <td rowspan='2' style='border: 1px solid #a5a5a5;'>Supplier</td>
                                                    <td rowspan='2' style='border: 1px solid #a5a5a5;'>FabricQuality</td>
                                                    <td rowspan='2' style='border: 1px solid #a5a5a5;'>CountConstruction</td>
                                                    <td rowspan='2' style='border: 1px solid #a5a5a5;'>GSM</td>

                                                    <td colspan='2' style='border: 1px solid #a5a5a5;'>Griege</td>
                                                    <td colspan='2' style='border: 1px solid #a5a5a5;'>Dyed</td>
                                                    <td colspan='2' style='border: 1px solid #a5a5a5;'>Print</td>
                                                    <td colspan='2' style='border: 1px solid #a5a5a5;'>Finish</td>
                                                    <td colspan='2' style='border: 1px solid #a5a5a5;'>RFD</td>
                                                    <td colspan='2' style='border: 1px solid #a5a5a5;'>Embroidery</td>
                                                    <td colspan='2' style='border: 1px solid #a5a5a5;'>Embellishment</td>
                                                </tr>
                                                <tr class='' style='background-color:#e4e2e2; color:#484747;border: 1px solid #a5a5a5;'>
													<td style='border: 1px solid #a5a5a5;'>PO QTY (With Unit)</td>
                                                    <td style='border: 1px solid #a5a5a5;'>Value (L)</td>

                                                    <td style='border: 1px solid #a5a5a5;'>PO QTY (With Unit)</td>
                                                    <td style='border: 1px solid #a5a5a5;'>Value (L)</td>

                                                    <td style='border: 1px solid #a5a5a5;'>PO QTY (With Unit)</td>
                                                    <td style='border: 1px solid #a5a5a5;'>Value (L)</td>

                                                    <td style='border: 1px solid #a5a5a5;'>PO QTY (With Unit)</td>
                                                    <td style='border: 1px solid #a5a5a5;'>Value (L)</td>

                                                    <td style='border: 1px solid #a5a5a5;'>PO QTY (With Unit)</td>
                                                    <td style='border: 1px solid #a5a5a5;'>Value (L)</td>

                                                    <td style='border: 1px solid #a5a5a5;'>PO QTY (With Unit)</td>
                                                    <td style='border: 1px solid #a5a5a5;'>Value (L)</td>

                                                    <td style='border: 1px solid #a5a5a5;'>PO QTY (With Unit)</td>
                                                    <td style='border: 1px solid #a5a5a5;'>Value (L)</td>
                                                </tr>";
                    int i = 1, J = 1;
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {


                        ReportMailBody += @"    <tr style='border: 1px solid #a5a5a5;'> ";
                        if (i == 1)
                        {
                            ReportMailBody += @"    <td rowspan='" + dr["RowSpan"] + @"' style='text-align: left !important; background-color: aliceblue;border: 1px solid #a5a5a5;''>" + dr["SupplierName"] + @"</td> ";

                            J++;

                        }
                        if ("100000" == dr["RowSpan"].ToString()) { i = 1; J = 1; }
                        else { i++; J++; }

                        if (J == 1)
                        {
                            ReportMailBody += @"    <td style='text-align: left; !important; background-color: aliceblue;border: 1px solid #a5a5a5;''>" + dr["FabricQuality"]            + @"</td>
                                                    <td style='background-color:  #ffffbf;color:#a3a4a5;border: 1px solid #a5a5a5;''>"                  + dr["CountConstruction"]        + @"</td>
                                                    <td style='background-color:  #ffffbf;color:#8faadc;border: 1px solid #a5a5a5;''>"                  + dr["GSM"]                      + @"</td>
                                                    <td style='background-color:  #ffffbf;border: 1px solid #a5a5a5;''>"                                + dr["GriegePoQty"]              + @"</td>
                                                    <td style='background-color:  #ffffbf;border: 1px solid #a5a5a5;''>"                                + dr["GriegePOValue"]            + @"</td>
                                                    <td style='background-color:  #ffffbf;border: 1px solid #a5a5a5;''>"                                + dr["DyedPoQty"]                + @"</td>
                                                    <td style='background-color:  #ffffbf;border: 1px solid #a5a5a5;''>"                                + dr["DyedPOValue"]              + @"</td>
                                                    <td style='background-color:  #ffffbf;border: 1px solid #a5a5a5;''>"                                + dr["PrintedPoQty"]             + @"</td>
                                                    <td style='background-color:  #ffffbf;border: 1px solid #a5a5a5;''>"                                + dr["PrintedPOValue"]           + @"</td>
                                                    <td style='background-color:  #ffffbf;border: 1px solid #a5a5a5;''>"                                + dr["FinishedPoQty"]            + @"</td>
                                                    <td style='background-color:  #ffffbf;border: 1px solid #a5a5a5;''  >"                              + dr["FinishedPOValue"]          + @"</td>
                                                    <td style='background-color:  #ffffbf;border: 1px solid #a5a5a5;''  >"                              + dr["RFDPoQty"]                 + @"</td>
                                                    <td style='background-color:  #ffffbf;border: 1px solid #a5a5a5;''  >"                              + dr["RDFPOValue"]               + @"</td>
                                                    <td style='background-color:  #ffffbf;border: 1px solid #a5a5a5;''  >"                              + dr["EmdellishmentPoQty"]       + @"</td>
                                                    <td style='background-color:  #ffffbf;border: 1px solid #a5a5a5;''  >"                              + dr["EmdellishmentPOValue"]     + @"</td>
                                                    <td style='background-color:  #ffffbf;border: 1px solid #a5a5a5;''  >"                              + dr["EmbroideryPoQty"]          + @"</td>
                                                    <td style='background-color:  #ffffbf;border: 1px solid #a5a5a5;''  >"                              + dr["EmbroideryPOValue"]        + @"</td>
                                                </tr> ";
                        }
                        else
                        {
                            ReportMailBody += @"    <td style='text-align: left; !important; background-color: aliceblue;border: 1px solid #a5a5a5;''>" + dr["FabricQuality"]           + @"</td>
                                                    <td style='background-color: #f9f9fae8;color:#a3a4a5;border: 1px solid #a5a5a5;''>"                 + dr["CountConstruction"]       + @"</td>
                                                    <td style='background-color: #f9f9fae8;color:#8faadc;border: 1px solid #a5a5a5;''>"                 + dr["GSM"]                     + @"</td>
                                                    <td style='background-color: #f9f9fae8;border: 1px solid #a5a5a5;''>"                               + dr["GriegePoQty"]             + @"</td>
                                                    <td style='background-color: #F2F2F2;border: 1px solid #a5a5a5;''>"                                 + dr["GriegePOValue"]           + @"</td>
                                                    <td style='background-color: #f9f9fae8;border: 1px solid #a5a5a5;''>"                               + dr["DyedPoQty"]               + @"</td>
                                                    <td style='background-color: #F2F2F2;border: 1px solid #a5a5a5;''>"                                 + dr["DyedPOValue"]             + @"</td>
                                                    <td style='background-color: #f9f9fae8;border: 1px solid #a5a5a5;''>"                               + dr["PrintedPoQty"]            + @"</td>
                                                    <td style='background-color: #F2F2F2;border: 1px solid #a5a5a5;''>"                                 + dr["PrintedPOValue"]          + @"</td>
                                                    <td style='background-color: #f9f9fae8;border: 1px solid #a5a5a5;''>"                               + dr["FinishedPoQty"]           + @"</td>
                                                    <td style='background-color: #F2F2F2;border: 1px solid #a5a5a5;''  >"                               + dr["FinishedPOValue"]         + @"</td>
                                                    <td style='background-color: #f9f9fae8;border: 1px solid #a5a5a5;''  >"                             + dr["RFDPoQty"]                + @"</td>
                                                    <td style='background-color: #F2F2F2;border: 1px solid #a5a5a5;''  >"                               + dr["RDFPOValue"]              + @"</td>
                                                    <td style='background-color: #f9f9fae8;border: 1px solid #a5a5a5;''  >"                             + dr["EmdellishmentPoQty"]      + @"</td>
                                                    <td style='background-color: #F2F2F2;border: 1px solid #a5a5a5;''  >"                               + dr["EmdellishmentPOValue"]    + @"</td>
                                                    <td style='background-color: #f9f9fae8;border: 1px solid #a5a5a5;''  >"                             + dr["EmbroideryPoQty"]         + @"</td>
                                                    <td style='background-color: #F2F2F2;border: 1px solid #a5a5a5;''  >"                               + dr["EmbroideryPOValue"]       + @"</td>
                                                </tr> ";
                        }
                    }

                    ReportMailBody += @"    </tbody>
                                        </table>";

                }

                ReportMailBody += @"                
                                    <strong style='padding: 10px 0 0 10px;color: #39589c;'>Thanks & Best Regards </strong> 
                                            <br/>  <br/> 
                                    <strong style='padding: 10px 0 0 10px;color: #39589c;'> BIPL Team</strong> 

                                    <div style='margin-top:10px; padding: 10px 0 0 10px;'>   
                                        <img src='http://boutique.in/images/certificate.jpg' />
                                    </div></div> ";
            }

            return ReportMailBody;
        }

        private void CreateExcel(DataSet ds, string ReportMailType)
        {
            string sourcePath = @"E:\";
            string FileName = ReportMailType + ".xlsx";

            if ((System.IO.File.Exists(Constants.MATERIAL_FOLDER_PATH + FileName))) { System.IO.File.Delete(Constants.MATERIAL_FOLDER_PATH + FileName); }

            string targetPath_Fabric_Po_Details = Constants.MATERIAL_FOLDER_PATH + FileName;

            string sourceFile_Fabric_Po_Details = System.IO.Path.Combine(sourcePath, FileName);

            System.IO.File.Copy(sourceFile_Fabric_Po_Details, targetPath_Fabric_Po_Details, true);

            string ExcelFilePath_Fabric_Po_Details = Path.Combine(Constants.MATERIAL_FOLDER_PATH, FileName);

            bool success_Rescan = controller.GenerateMaterialReportExcel(ExcelFilePath_Fabric_Po_Details, ReportMailType, ds);
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
                    if (ReportMailType == Fabric_Po_Detail)
                    {
                        List<Attachment> atts = new List<Attachment>();

                        string ExcellPath = "";

                        if (File.Exists(Constants.MATERIAL_FOLDER_PATH + "Fabric_PO_Detail.xlsx"))
                        {
                            ExcellPath = Path.Combine(Constants.MATERIAL_FOLDER_PATH, "Fabric_PO_Detail.xlsx");
                            atts.Add(new Attachment(ExcellPath));
                        }
                        if (File.Exists(Constants.MATERIAL_FOLDER_PATH + "Cut Issue Status.xlsx"))
                        {
                            ExcellPath = Path.Combine(Constants.MATERIAL_FOLDER_PATH, "Cut Issue Status.xlsx");
                            atts.Add(new Attachment(ExcellPath));
                        }
                        if (File.Exists(Constants.MATERIAL_FOLDER_PATH + "Daily Fabric Movement.xlsx"))
                        {
                            ExcellPath = Path.Combine(Constants.MATERIAL_FOLDER_PATH, "Daily Fabric Movement.xlsx");
                            atts.Add(new Attachment(ExcellPath));
                        }
                        if (File.Exists(Constants.MATERIAL_FOLDER_PATH + "Stock Summary Excel.xlsx"))
                        {
                            ExcellPath = Path.Combine(Constants.MATERIAL_FOLDER_PATH, "Stock Summary Excel.xlsx");
                            atts.Add(new Attachment(ExcellPath));
                        }

                        //if (File.Exists(Constants.MATERIAL_FOLDER_PATH + "Latest Three PORates.xlsx"))
                        //{
                        //    ExcellPath = Path.Combine(Constants.MATERIAL_FOLDER_PATH, "Latest Three PORates.xlsx");
                        //    atts.Add(new Attachment(ExcellPath));
                        //} //Excel will be generated here and genrated Excel will be sent along with BIPL Core Figure Mail.

                        //if (File.Exists(Constants.MATERIAL_FOLDER_PATH + "Production Stock Detail.xlsx"))
                        //{
                        //    ExcellPath = Path.Combine(Constants.MATERIAL_FOLDER_PATH, "Production Stock Detail.xlsx");
                        //    atts.Add(new Attachment(ExcellPath));
                        //}
                        //Excel will be generated here and genrated Excel will be sent along with BIPL Core Figure Mail.

                        this.SendEmail(fromName, to, null, null, "Fabric Po Details", ReportMailBody, atts);
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