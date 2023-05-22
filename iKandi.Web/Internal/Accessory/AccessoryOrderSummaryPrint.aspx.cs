using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using iKandi.Common;
using iKandi.BLL;
using iKandi.Web.Components;
namespace iKandi.Web.Internal.Accessory
{
    public partial class AccessoryOrderSummaryPrint : System.Web.UI.Page
    {
        AccessoryQualityController ObjAccessoryPrintOr = new AccessoryQualityController();
        public int orderid
        {
            get;
            set;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            GetQueryString();
            BindPrintOrderAccessory();
            BindPrintOrderAccessoryNew();
        }
        private void GetQueryString()
        {
            if (Request.QueryString["orderid"] != null)
            {
                orderid = Convert.ToInt32(Request.QueryString["orderid"]);
            }
            else
            {
                orderid = -1;
            }
        }

        public void BindPrintOrderAccessory()
        {

            DataSet dsHeaderInfo = new DataSet();
            DataTable DtOrderDetails = new DataTable();
            string AccountManager = "", SerialNo = "", StyleNo = "", DeptName = "";
            dsHeaderInfo = ObjAccessoryPrintOr.GetAccessoryOrderSizedeatils("1", orderid, "");
            DtOrderDetails = dsHeaderInfo.Tables[2];
            int IsApprovedAMForAccessory = Convert.ToInt16(DtOrderDetails.Rows[0]["IsApprovedByAccessoryManager"] == DBNull.Value ? 0 : DtOrderDetails.Rows[0]["IsApprovedByAccessoryManager"]);
            if (IsApprovedAMForAccessory > 0)
            {
                chkboxAccountMgr.Checked = true;

            }

            if (DtOrderDetails.Rows.Count > 0)
            {
                AccountManager = DtOrderDetails.Rows[0]["AcName"].ToString();
                SerialNo = DtOrderDetails.Rows[0]["serialno"].ToString();
                StyleNo = DtOrderDetails.Rows[0]["stylenumber"].ToString();
                DeptName = DtOrderDetails.Rows[0]["DepartmentName"].ToString();
            }

            DataTable DtAccessoryHeader = new DataTable();
            DataTable DtAccessoryOrder = new DataTable();
            DataSet ds = new DataSet();

            ds = ObjAccessoryPrintOr.Get_AccessoryPrintOrderSummary(orderid, -1, 1);
            DtAccessoryHeader = ds.Tables[0];


            int totalQty = 0;

            int countHeader = DtAccessoryHeader.Rows.Count;

            int CountAcce = countHeader;
            StringBuilder PrintOrderAccessory = new StringBuilder();
            int CountCollSpan = 3 + countHeader;

            PrintOrderAccessory.Append("<table class='AddClass_Table' border='0' cellspacing='0' cellpadding='0'>");
            PrintOrderAccessory.Append("<tr><th colspan='" + CountCollSpan + "' class='TopHeader'>Accessories Details</th></tr>");
            //PrintOrderAccessory.Append("<tr><th colspan='" + CountCollSpan + "' style='text-align: left;'><span style='display:inline-block;width:235px;font-size:12px'>Account Manager: <b style='color:#000'>" + DtAccessoryHeader.Rows[0]["AcName"] + "</b></span><span style='display:inline-block;width:200px;font-size:12px'>Serial Number: <b style='color:#000'>" + DtAccessoryHeader.Rows[0]["SerialNumber"] + "</b> </span><span style='display:inline-block;width:200px;font-size:12px'> Style Number: <b style='color:#000'>" + DtAccessoryHeader.Rows[0]["StyleNumber"] + "</b></span></th></tr>");
            PrintOrderAccessory.Append("<tr><th colspan='" + CountCollSpan + "' style='text-align: left;'><span style='display:inline-block;width:122px;font-size:12px'>Sr No: <b style='color:#000'>" + SerialNo + "</b> </span><span style='display:inline-block;width:200px;font-size:12px'> Dt Name: <b style='color:#000'>" + DeptName + "</b></span><span style='display:inline-block;width:180px;font-size:12px'> Style No: <b style='color:#000'>" + StyleNo + "</b></span><span style='display:inline-block;width:235px;font-size:12px'>AM: <b style='color:#000'>" + AccountManager + "</b></span></th></tr>");
            PrintOrderAccessory.Append("<tr>");
            PrintOrderAccessory.Append("<th class='CellWidth'>Contract No. <br> <span style='color:gray;'>BIH</span> <br> <span style='color:gray;'>Ex-Factory</span></th>");
            PrintOrderAccessory.Append("<th class='CellWidth'>Contract<br> Qty.<br> Color</th>");

            for (int i = 0; i < countHeader; i++)
            {
                string shrinkage = "";
                string wastage = "";
                double Number = 0;
                double Average = 0;
                string sizeName = "";
                if (DtAccessoryHeader.Rows[i]["Shrinkage"] != System.DBNull.Value)
                {
                    shrinkage = DtAccessoryHeader.Rows[i]["Shrinkage"].ToString() == "0" ? "" : DtAccessoryHeader.Rows[i]["Shrinkage"].ToString() + "%";
                }
                if (DtAccessoryHeader.Rows[i]["Wastage"] != System.DBNull.Value)
                {
                    wastage = DtAccessoryHeader.Rows[i]["Wastage"].ToString() == "0" ? "" : DtAccessoryHeader.Rows[i]["Wastage"].ToString() + "%";
                }
                if (DtAccessoryHeader.Rows[i]["Number"] != System.DBNull.Value)
                {
                    Number = Convert.ToDouble(DtAccessoryHeader.Rows[i]["Number"]);
                }
                if (DtAccessoryHeader.Rows[i]["SizeName"] != System.DBNull.Value)
                {
                    sizeName = DtAccessoryHeader.Rows[i]["SizeName"].ToString() == "0" ? "" : "(" + DtAccessoryHeader.Rows[i]["SizeName"].ToString() + ")";
                }
                //double afterDecimal = Math.Floor(Number);
                //if (afterDecimal > 0)
                Average = Math.Round(Number, 2);
                //else
                //Average = Convert.ToInt32(Number);
                PrintOrderAccessory.Append("<th class='CellWidth' style='padding:0px 0px'>");
                PrintOrderAccessory.Append("<table class='Inner_Table' border='0' cellspacing='0' cellpadding='0'>");
                PrintOrderAccessory.Append("<tr><th style='height:27px'><span style='color:Blue'>" + DtAccessoryHeader.Rows[i]["TradeName"] + "</span> " + sizeName + "</th></tr>");
                PrintOrderAccessory.Append("<tr><th>" + "<span class='FloatLeft TooltipShrnkWat'>S:<span style='color:#000'>" + shrinkage + "</span> <span class='TooltipContent'>Shrinkage</span></span><span class='FloatRight TooltipShrnkWat'>W:<span style='color:#000'>" + wastage + "</span><span class='TooltipContent'>Wastage</span></span></th></tr>");
                PrintOrderAccessory.Append("<tr><th style='padding: 0px 2px 3px 2px;'>" + "<span class='FloatLeft'>Avg:<span style='color:#000'>" + Average + "</span></span><span style='color:gray;font-weight:600;float:right;'> " + DtAccessoryHeader.Rows[i]["GarmentUnitName"] + "</span></span></th></tr>");
                PrintOrderAccessory.Append("<tr><th style='text-align:center;height:18px;border-bottom: 1px solid #999;border-top: 1px solid #999'> Quantity</th></tr>");
                PrintOrderAccessory.Append("<tr><th style='text-align:center;;height:18px'> Color/Print</th></tr>");
                PrintOrderAccessory.Append("</table>");
                PrintOrderAccessory.Append("</th>");



            }
            PrintOrderAccessory.Append("<th class='CellWidth'>Description</th>");
            PrintOrderAccessory.Append("</tr>");

            PrintOrderAccessory.Append("<tr>");


            for (int i = 0; i < DtAccessoryHeader.Rows.Count; i++)
            {
                int AccessoryworkingdetailId = Convert.ToInt32(DtAccessoryHeader.Rows[i]["AccessoryworkingdetailId"]);
                DataSet dsAccressory = new DataSet();
                dsAccressory = ObjAccessoryPrintOr.Get_AccessoryPrintOrderSummary(orderid, AccessoryworkingdetailId, 2);
                DtAccessoryOrder = dsAccressory.Tables[0];
                if (i == 0)
                {
                    int TotAvgQuantity = 0;

                    PrintOrderAccessory.Append("<td colspan='3'>");
                    for (int j = 0; j < DtAccessoryOrder.Rows.Count; j++)
                    {
                        string SeparateContract = "";
                        string ContractNumber = DtAccessoryOrder.Rows[j]["ContractNumber"].ToString();//new line
                        if (ContractNumber.Contains("/"))
                        {
                            string[] SplitContract = ContractNumber.Split('/');
                            foreach (string splitCont in SplitContract)
                            {
                                SeparateContract = SeparateContract + splitCont + "/" + "<br>";
                            }
                            SeparateContract = SeparateContract.Remove(SeparateContract.Length - 6, 6);
                        }
                        else
                        {
                            SeparateContract = ContractNumber;
                        }

                        int Quantity = Convert.ToInt32(DtAccessoryOrder.Rows[j]["Quantity"]); //new line
                        int AvgQuantity = Convert.ToInt32(DtAccessoryOrder.Rows[j]["AvgQuantity"]); //new line
                        TotAvgQuantity = TotAvgQuantity + AvgQuantity;
                        PrintOrderAccessory.Append("<table class='Inner_Table' border='0'  cellspacing='0' cellpadding='0'>");
                        if (j == 0)
                        {
                            PrintOrderAccessory.Append("<tr>");
                            PrintOrderAccessory.Append("<td class='CellWidth1' style='border-right: 1px solid #dbd8d8;'> <span style='color:gray;'>" + SeparateContract + " </span><br> <span style='color:#000;font-weight:600;font-size:11px'>" + DateTime.Parse(DtAccessoryOrder.Rows[j]["BulkAccsesoryTarget"].ToString()).ToString("dd MMM yy (ddd)") + "</span><br> <span style='color:gray;font-weight:600;font-size:11px'>" + DateTime.Parse(DtAccessoryOrder.Rows[j]["ExFactory"].ToString()).ToString("dd MMM yy (ddd)") + "</span></td>");
                            PrintOrderAccessory.Append("<td class='CellWidth2' style='border-right: 1px solid #dbd8d8;'>" + Quantity.ToString("N0") + " <br> <span style='color:#000;font-weight:600;font-size:11px'> " + DtAccessoryOrder.Rows[j]["ContractColor"].ToString() + "</span> </td>");    //new line
                            PrintOrderAccessory.Append("<td class='txtCenter CellWidth3'>");
                            PrintOrderAccessory.Append("<table class='Inner_TableContent' border='0'  cellspacing='0' cellpadding='0'>");
                            PrintOrderAccessory.Append("<tr>");
                            PrintOrderAccessory.Append("<td style='border-top: 0px solid #dbd8d8;'>" + AvgQuantity.ToString("N0") + "</td>");
                            PrintOrderAccessory.Append("</tr>");
                            PrintOrderAccessory.Append("<tr>");
                            PrintOrderAccessory.Append("<td style='border-top: 1px solid #dbd8d8;font-weight:600'>" + DtAccessoryOrder.Rows[j]["Color_Print"].ToString() + "</td>");
                            PrintOrderAccessory.Append("</tr>");
                            PrintOrderAccessory.Append("</table>");
                            PrintOrderAccessory.Append("</td>");
                            PrintOrderAccessory.Append("</tr>");
                        }
                        else
                        {
                            PrintOrderAccessory.Append("<tr>");
                            PrintOrderAccessory.Append("<td class='CellWidth1' style='border-right: 1px solid #dbd8d8;border-top:1px solid #dbd8d8'> <span style='color:gray;'>" + SeparateContract + " </span><br> <span style='color:#000;font-weight:600;font-size:11px'>" + DateTime.Parse(DtAccessoryOrder.Rows[j]["BulkAccsesoryTarget"].ToString()).ToString("dd MMM yy (ddd)") + "</span><br> <span style='color:gray;font-weight:600;font-size:11px'>" + DateTime.Parse(DtAccessoryOrder.Rows[j]["ExFactory"].ToString()).ToString("dd MMM yy (ddd)") + "</span></td>");
                            PrintOrderAccessory.Append("<td class='CellWidth2' style='border-right: 1px solid #dbd8d8;border-top:1px solid #ccc'>" + Quantity.ToString("N0") + " <br> <span style='color:#000;font-weight:600;font-size:11px'> " + DtAccessoryOrder.Rows[j]["ContractColor"].ToString() + "</span></td>");    //new line
                            PrintOrderAccessory.Append("<td class='txtCenter CellWidth3'>");
                            PrintOrderAccessory.Append("<table class='Inner_TableContent' border='0'  cellspacing='0' cellpadding='0'>");
                            PrintOrderAccessory.Append("<tr>");
                            PrintOrderAccessory.Append("<td style='border-top: 1px solid #dbd8d8;'>" + AvgQuantity.ToString("N0") + "</td>");
                            PrintOrderAccessory.Append("</tr>");
                            PrintOrderAccessory.Append("<tr>");
                            PrintOrderAccessory.Append("<td style='border-top: 1px solid #dbd8d8;font-weight:600'>" + DtAccessoryOrder.Rows[j]["Color_Print"].ToString() + "</td>");
                            PrintOrderAccessory.Append("</tr>");
                            PrintOrderAccessory.Append("</table>");
                            PrintOrderAccessory.Append("</td>");
                            PrintOrderAccessory.Append("</tr>");
                        }
                        PrintOrderAccessory.Append("</table>");

                        totalQty = totalQty + Convert.ToInt32(DtAccessoryOrder.Rows[j]["Quantity"]);
                    }
                    if (i == 0)
                    {
                        PrintOrderAccessory.Append("<table class='FooterTable' border='0'  cellspacing='0' cellpadding='0'>");

                        PrintOrderAccessory.Append("<tr>");
                        PrintOrderAccessory.Append("<td class='CellWidth1'>Total</td>");
                        PrintOrderAccessory.Append("<td class='CellWidth2'>" + totalQty.ToString("N0") + "</td>");
                        PrintOrderAccessory.Append("<td class='CellWidth3' style='border-right:0px'>" + TotAvgQuantity.ToString("N0") + "</td>");
                        PrintOrderAccessory.Append("</tr>");
                        PrintOrderAccessory.Append("<tr>");
                        PrintOrderAccessory.Append("<td class='CellWidth1'>Swatches</td>");
                        PrintOrderAccessory.Append("<td class='CellWidth2'></td>");
                        PrintOrderAccessory.Append("<td class='CellWidth3' style='border-right:0px;height:30px;'></td>");
                        PrintOrderAccessory.Append("</tr>");
                        PrintOrderAccessory.Append("</table>");
                    }

                    PrintOrderAccessory.Append("</td>");
                }
                else
                {
                    PrintOrderAccessory.Append("<td>");
                    int TotalAvgQuantity = 0;
                    for (int j = 0; j < DtAccessoryOrder.Rows.Count; j++)
                    {

                        int AvgQuantity = Convert.ToInt32(DtAccessoryOrder.Rows[j]["AvgQuantity"]); //new line

                        TotalAvgQuantity = TotalAvgQuantity + AvgQuantity;
                        PrintOrderAccessory.Append("<table class='Inner_Table' border='0'  cellspacing='0' cellpadding='0'>");
                        if (j == 0)
                        {
                            PrintOrderAccessory.Append("<tr>");
                            // PrintOrderAccessory.Append("<td class='txtCenter'><span style='display:block;border-bottom: 1px solid #dbd8d8;'>" + AvgQuantity.ToString("N0") + "</span><span style='color:#000;font-weight:600'>" + DtAccessoryOrder.Rows[j]["Color_Print"].ToString() + "</span></td>");
                            PrintOrderAccessory.Append("<td class='txtCenter CellWidth3'>");
                            PrintOrderAccessory.Append("<table class='Inner_TableContent' border='0'  cellspacing='0' cellpadding='0'>");
                            PrintOrderAccessory.Append("<tr>");
                            PrintOrderAccessory.Append("<td style='border-top: 0px solid #dbd8d8;'>" + AvgQuantity.ToString("N0") + "</td>");
                            PrintOrderAccessory.Append("</tr>");
                            PrintOrderAccessory.Append("<tr>");
                            PrintOrderAccessory.Append("<td style='border-top: 1px solid #dbd8d8;font-weight:600'>" + DtAccessoryOrder.Rows[j]["Color_Print"].ToString() + "</td>");
                            PrintOrderAccessory.Append("</tr>");
                            PrintOrderAccessory.Append("</table>");
                            PrintOrderAccessory.Append("</td>");
                            PrintOrderAccessory.Append("</tr>");
                        }
                        else
                        {
                            PrintOrderAccessory.Append("<tr>");
                            //  PrintOrderAccessory.Append("<td class='txtCenter' style='border-top: 1px solid #ccc;'><span style='display:block;border-bottom: 1px solid #dbd8d8;'>" + AvgQuantity.ToString("N0") + "</span><span style='color:#000;font-weight:600'>" + DtAccessoryOrder.Rows[j]["Color_Print"].ToString() + "</span></td>"); //new line
                            PrintOrderAccessory.Append("<td class='txtCenter CellWidth3'>");
                            PrintOrderAccessory.Append("<table class='Inner_TableContent' border='0'  cellspacing='0' cellpadding='0'>");
                            PrintOrderAccessory.Append("<tr>");
                            PrintOrderAccessory.Append("<td style='border-top: 1px solid #dbd8d8;'>" + AvgQuantity.ToString("N0") + "</td>");
                            PrintOrderAccessory.Append("</tr>");
                            PrintOrderAccessory.Append("<tr>");
                            PrintOrderAccessory.Append("<td style='border-top: 1px solid #dbd8d8;font-weight:600'>" + DtAccessoryOrder.Rows[j]["Color_Print"].ToString() + "</td>");
                            PrintOrderAccessory.Append("</tr>");
                            PrintOrderAccessory.Append("</table>");
                            PrintOrderAccessory.Append("</td>");
                            PrintOrderAccessory.Append("</tr>");
                        }
                        PrintOrderAccessory.Append("</table>");


                    }
                    if (i > 0)
                    {
                        PrintOrderAccessory.Append("<table class='FooterTable' border='0'  cellspacing='0' cellpadding='0'>");
                        PrintOrderAccessory.Append("<tr>");
                        PrintOrderAccessory.Append("<td style='border-right:0px'>" + TotalAvgQuantity.ToString("N0") + "</td>");
                        PrintOrderAccessory.Append("</tr>");
                        PrintOrderAccessory.Append("<tr>");
                        PrintOrderAccessory.Append("<td style='border-right:0px;height:30px;'></td>");
                        PrintOrderAccessory.Append("</tr>");
                        PrintOrderAccessory.Append("</table>");
                    }
                    PrintOrderAccessory.Append("</td>");
                    int z = i + 1;
                    if (CountAcce == z)
                    {
                        PrintOrderAccessory.Append("<td style='vertical-align: initial;'>");
                        for (int j = 0; j < DtAccessoryOrder.Rows.Count; j++)
                        {
                            int OrderDetailId = Convert.ToInt32(DtAccessoryOrder.Rows[j]["Orderdetailid"]);
                            string DetailDescription = DtAccessoryOrder.Rows[j]["AccessoryDetailDescription"].ToString();
                            PrintOrderAccessory.Append("<table class='Inner_Table' border='0'  cellspacing='0' cellpadding='0'>");

                            PrintOrderAccessory.Append("<tr>");
                            int CountId = j + 1;
                            PrintOrderAccessory.Append("<td class='txtCenter' style='border-bottom:1px solid #dad8d8;border-bottom-color:#dad8d8 !important'>" + "<textarea id='Comment" + CountId + "' style='height:98%; text-transform:none; text-align:left;' onblur='SaveDescription(" + OrderDetailId + ", this)'> " + DetailDescription + "</textarea>" + "</td>");
                            PrintOrderAccessory.Append("</tr>");

                            PrintOrderAccessory.Append("</table>");
                            string AccessoryRemarks = DtAccessoryOrder.Rows[j]["AccessoryRemarks"].ToString();
                            txtRemarks.Text = AccessoryRemarks.Trim();

                        }
                        PrintOrderAccessory.Append("</td>");
                    }
                }
            }
            PrintOrderAccessory.Append("</tr>");
            PrintOrderAccessory.Append("</table>");

            AccessoryPrintSummary.InnerHtml = PrintOrderAccessory.ToString();
            hdnOrderid.Value = orderid.ToString();

        }

        public void BindPrintOrderAccessoryNew()
        {

            DataSet DsAccessoryOrderSummary = ObjAccessoryPrintOr.GetAccessoryOrderSummaryPrint(1, orderid);
            DataTable DtHeader = new DataTable();
            string AccountManager = "", SerialNo = "", StyleNo = "", DeptName = "", AccessoryRemark = "";
            int SignedByAccessoryManager = 0, SignedByAccountManager = 0, ContractCount = 0, AccessoryCount = 0;

            DtHeader = DsAccessoryOrderSummary.Tables[0];
            if (DtHeader.Rows.Count > 0)
            {
                SignedByAccountManager = Convert.ToInt32(DtHeader.Rows[0]["SignedByAccountManager"] == DBNull.Value ? 0 : DtHeader.Rows[0]["SignedByAccountManager"]);
                SignedByAccessoryManager = Convert.ToInt32(DtHeader.Rows[0]["SignedByAccessoryManager"] == DBNull.Value ? 0 : DtHeader.Rows[0]["SignedByAccessoryManager"]);
                ContractCount = Convert.ToInt32(DtHeader.Rows[0]["ContractCount"] == DBNull.Value ? 0 : DtHeader.Rows[0]["ContractCount"]);
                AccessoryCount = Convert.ToInt32(DtHeader.Rows[0]["AccessoryCount"] == DBNull.Value ? 0 : DtHeader.Rows[0]["AccessoryCount"]);
                AccountManager = DtHeader.Rows[0]["AcName"].ToString();
                SerialNo = DtHeader.Rows[0]["serialno"].ToString();
                StyleNo = DtHeader.Rows[0]["stylenumber"].ToString();
                DeptName = DtHeader.Rows[0]["DepartmentName"].ToString();
                AccessoryRemark = DtHeader.Rows[0]["AccessoryRemark"].ToString();
                if (SignedByAccountManager > 0) { chkboxAccountMgr.Checked = true; }
                if (SignedByAccessoryManager > 0) { chkboxAccessoryMgr.Checked = true; }
            }

            DataTable DtAccessoryDetails = new DataTable();
            DtAccessoryDetails = DsAccessoryOrderSummary.Tables[1];
            StringBuilder PrintOrderAccessory = new StringBuilder();
            int CountCollSpan = 3 + ContractCount;

            PrintOrderAccessory.Append("<table class='OrderSummery_Table' border='0' cellspacing='0' cellpadding='0'>");
            PrintOrderAccessory.Append(@"<tr><th colspan='" + CountCollSpan + @"' class='TopHeader'>Accessories Details</th></tr>");
            PrintOrderAccessory.Append(@"<tr>
                                            <th colspan='" + CountCollSpan + @"' style='text-align: left;'>
                                                <span style='display:inline-block;font-size:12px;margin-right: 20px;'>Sr No: <b style='color:#000'>" + SerialNo + @"</b> </span>
                                                <span style='display:inline-block;font-size:12px;margin-right: 20px;'>Dt Name: <b style='color:#000'>" + DeptName + @"</b></span>
                                                <span style='display:inline-block;font-size:12px;margin-right: 20px;'>Style No: <b style='color:#000'>" + StyleNo + @"</b></span>
                                                <span style='display:inline-block;font-size:12px;margin-right: 20px;'>AM: <b style='color:#000'>" + AccountManager + @"</b></span>
                                                <span style='display:inline-block;font-size:12px;                   '>Order Quantity: <b style='color:#000'>" + DtAccessoryDetails.Rows[4]["Total"].ToString() + @"</b></span>
                                            </th>
                                        </tr>");

            PrintOrderAccessory.Append("<tr>");
            PrintOrderAccessory.Append("<th class='AccessDetail'> Contract No. <br />BIH<br />Ex-Factory</th>");
            for (int c = 1; c <= ContractCount; c++)
            {
                string ContractNo = DtAccessoryDetails.Rows[0]["Cont_Quant_" + c.ToString()].ToString();
                string BIH = DtAccessoryDetails.Rows[2]["Cont_Quant_" + c.ToString()].ToString();
                string ExFactory = DtAccessoryDetails.Rows[3]["Cont_Quant_" + c.ToString()].ToString();
                PrintOrderAccessory.Append(@"<th>" + ContractNo + " <br />" + BIH + "<br />" + ExFactory + "</th>");
            }
            PrintOrderAccessory.Append("<th rowspan=3 class='Total'> Total </th>");
            PrintOrderAccessory.Append("<th rowspan=3 class='Swatches'> Swatches </th>");
            PrintOrderAccessory.Append("</tr>");

            PrintOrderAccessory.Append("<tr>");
            PrintOrderAccessory.Append("<th class='AccessDetail'> Contract Qty. <br />Color.</th>");
            for (int c = 1; c <= ContractCount; c++)
            {
                string ContractQty = DtAccessoryDetails.Rows[4]["Cont_Quant_" + c.ToString()].ToString();
                string Color = DtAccessoryDetails.Rows[4]["Cont_Print_" + c.ToString()].ToString();
                PrintOrderAccessory.Append(@"<th>" + ContractQty + " <br /> " + Color + " </th>");
            }
            // PrintOrderAccessory.Append("<th class='Total'> " + DtAccessoryDetails.Rows[4]["Total"].ToString() + " </th>");
            // PrintOrderAccessory.Append("<th class='Swatches'>  </th>");
            PrintOrderAccessory.Append("</tr>");

            PrintOrderAccessory.Append("<tr>");
            PrintOrderAccessory.Append("<th class='AccessDetail'> Accessory Detail </th>");
            for (int c = 1; c <= ContractCount; c++)
            {
                PrintOrderAccessory.Append(@"<th> Quantity<br /> Color/Print </th>");
            }
            // PrintOrderAccessory.Append("<th class='Total'> Total </th>");
            // PrintOrderAccessory.Append("<th class='Swatches'> Swatches </th>");
            PrintOrderAccessory.Append("</tr>");

            for (int i = 0; i < AccessoryCount; i++)
            {
                int A = i + 6;
                string AccessName = DtAccessoryDetails.Rows[A]["AccessName"].ToString();
                string Access_Size = DtAccessoryDetails.Rows[A]["Access_Size"].ToString();
                string Access_Shrinkage = DtAccessoryDetails.Rows[A]["Access_Shrinkage"].ToString();
                string Access_Wastage = DtAccessoryDetails.Rows[A]["Access_Wastage"].ToString();
                string Access_Average = DtAccessoryDetails.Rows[A]["Access_Average"].ToString();
                string Access_Unit = DtAccessoryDetails.Rows[A]["Access_Unit"].ToString();


                PrintOrderAccessory.Append(@"<tr>
                                                <th class='AccessDetail'>
                                                    <span style='color:Blue'>" + AccessName + @"</span>  (" + Access_Size + @") 
                                                    <br />
                                                    <span style='padding: 0px 2px 3px 2px;'>
                                                        <span class='FloatLeft TooltipShrnkWat'>S:
                                                                <span style='color:#000'>" + Access_Shrinkage + @"</span> 
                                                                <span class='TooltipContent'>Shrinkage</span>
                                                        </span>
                                                        <span class='FloatRight TooltipShrnkWat'>W:
                                                                <span style='color:#000'>" + Access_Wastage + @"</span>
                                                                <span class='TooltipContent'>Wastage</span>
                                                        </span>
                                                        <br />                                                           
                                                        <span class='FloatLeft'>Avg:
                                                                <span style='color:#000'>" + Access_Average + @"</span>
                                                        </span>
                                                        <span class='FloatRight' style='color:gray;font-weight:600;'>Unit: 
                                                                <span style='color:#000'>" + Access_Unit + @"</span>
                                                        </span>
                                                    </span>
                                                   
                                                </th>");
                for (int c = 1; c <= ContractCount; c++)
                {
                    string OrderDetailId = DtAccessoryDetails.Rows[1]["Cont_Quant_" + c.ToString()].ToString();
                    string Quantity = DtAccessoryDetails.Rows[A]["Cont_Quant_" + c.ToString()].ToString();
                    string ColorPrint = DtAccessoryDetails.Rows[A]["Cont_Print_" + c.ToString()].ToString();
                    PrintOrderAccessory.Append(@"<td class='txtCenter'>  " + Quantity + @"  <br /> <span style='font-weight:600;'>" + ColorPrint + @"</span> </td>");
                }
                string Access_Total = DtAccessoryDetails.Rows[A]["Total"].ToString();
                PrintOrderAccessory.Append("<td>" + Access_Total + "</td>");
                PrintOrderAccessory.Append("<td> </td>");
                PrintOrderAccessory.Append("</tr>");


            }
            PrintOrderAccessory.Append("<tr>");
            PrintOrderAccessory.Append("<th>Description</th>");
            for (int c = 1; c <= ContractCount; c++)
            {
                string OrderDetailId = DtAccessoryDetails.Rows[1]["Cont_Quant_" + c.ToString()].ToString();
                string DetailDescription = DtAccessoryDetails.Rows[5]["Cont_Quant_" + c.ToString()].ToString();
                PrintOrderAccessory.Append(@"<td class='txtCenter'>
                                                    <textarea id='Comment" + c + @"' style='height:70px; width:95px;text-transform:none; text-align:left;' 
                                                                onblur='SaveDescription(" + OrderDetailId + @", this)'>" + DetailDescription + @"</textarea>
                                            </td>");
            }
            PrintOrderAccessory.Append("<td></td>");
            PrintOrderAccessory.Append("<td></td>");
            PrintOrderAccessory.Append("</tr>");

            PrintOrderAccessory.Append("</table>");

            txtRemarks.Text = AccessoryRemark;
            AccessoryPrintSummaryNew.InnerHtml = PrintOrderAccessory.ToString();
            hdnOrderid.Value = orderid.ToString();
        }
    }
}