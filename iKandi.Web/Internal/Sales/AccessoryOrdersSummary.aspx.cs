using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iKandi.BLL;
using iKandi.Web.Components;
using iKandi.Common;
using System.Data;
using System.Text;

namespace iKandi.Web.Internal.Sales
{
    public partial class AccessoryOrdersSummary : System.Web.UI.Page
    {
        public string Flag
        {
            get;
            set;
        }
        public int orderid
        {
            get;
            set;
        }
        public int OrderTab
        {
            get;
            set;
        }
        public static int TaskStatus
        {
            get;
            set;
        }
        AccessoryQualityController objacc = new AccessoryQualityController();
        AccessoryWorkingController objwc = new AccessoryWorkingController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (ApplicationHelper.LoggedInUser == null)
            {
                Response.Redirect("~/public/Login.aspx");
            }
            else
            {
                hdnUserId.Value = ApplicationHelper.LoggedInUser.UserData.UserID.ToString();
            }

            if (Request.QueryString["Flag"] != null)
            {
                Flag = Convert.ToString(Request.QueryString["Flag"]);
            }
            else
            {
                Flag = "";
            }

            if (Request.QueryString["orderid"] != null)
            {
                orderid = Convert.ToInt32(Request.QueryString["orderid"]);
            }
            hdnOrderID.Value = orderid.ToString();

            if (Request.QueryString["OrderTab"] != null)
            {
                OrderTab = Convert.ToInt32(Request.QueryString["OrderTab"]);
            }
            else
            {
                OrderTab = 3;
                // grdaccsize.CssClass = "gridleft headertopfixed";
            }
            if (Request.QueryString["TaskStatus"] != null)
            {
                TaskStatus = Convert.ToInt32(Request.QueryString["TaskStatus"]);
            }
            else
            {
                TaskStatus = -1;
            }
            hdnorderTabClose.Value = OrderTab.ToString();

            if (!IsPostBack)
            {
                BindOrderAccessory();
            }
        }

        public void BindOrderAccessory()
        {
            if (!PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.ACCESSORY_DETAIL_AVG))
                hdnIsReadOnly.Value = "1";

            DataSet ds = new DataSet();
            DataTable DtOrderDetails = new DataTable();

            ds = objacc.GetAccessoryOrderSizedeatils("1", orderid, "");

            DtOrderDetails = ds.Tables[2];
            lblacname.Text = DtOrderDetails.Rows[0]["AcName"].ToString();
            lblserialno.Text = DtOrderDetails.Rows[0]["serialno"].ToString();
            lblstylenumber.Text = DtOrderDetails.Rows[0]["stylenumber"].ToString();

            DataTable DtAccessoryHeader = new DataTable();
            DataTable DtContract = new DataTable();
            DataTable DtAccessoryOrder = new DataTable();

            DataSet dsAccess = new DataSet();

            //new work start:Girish
            if (Flag.ToLower() == "IEAverage".ToLower())
            {
                dsAccess = objacc.Get_AccessoryPrintOrderSummary(orderid, -1, 3);
                hdnIsNeedToBypassForIETeam.Value = "1";
                btnSubmit.Visible = false;
            }
            else
            {
                dsAccess = objacc.Get_AccessoryPrintOrderSummary(orderid, -1, 1);
            }
            //new work End

            DtAccessoryHeader = dsAccess.Tables[0];// for no accessory by shubhendu
            if (DtAccessoryHeader.Rows.Count > 0)
            {
                chkboxAccountMgr.Enabled = true;
            }
            else
            {
                chkboxAccountMgr.Enabled = false;
            }
            DtContract = dsAccess.Tables[1];

            bool IsCutting = false, IsHistoryExist = false;
            bool IsCheckboxChecked = false;
            if (DtAccessoryHeader.Rows.Count > 0)
            {
                if (DtAccessoryHeader.Rows[0]["IsApprovedAMForAccessory"] != DBNull.Value)
                {
                    IsCheckboxChecked = Convert.ToBoolean(DtAccessoryHeader.Rows[0]["IsApprovedAMForAccessory"]) == true ? true : false;
                }
                else
                {
                    IsCheckboxChecked = false;
                }
                if (DtAccessoryHeader.Rows[0]["IsOrderConfirm"].ToString() == "0")
                {
                    chkboxAccountMgr.Enabled = false;
                }
            }

            if (IsCheckboxChecked)
            {
                chkboxAccountMgr.Checked = true;
                chkboxAccountMgr.Enabled = false;
                // Below need to be coment to open check before cutting entry 
                // hdnIsCutting.Value = "1";
                //  ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "BindDropDownList();", true);       
            }

            if (DtAccessoryHeader.Rows.Count > 0)
            {
                IsCutting = DtAccessoryHeader.Rows[0]["IsCutting"].ToString() == "" ? false : Convert.ToBoolean(DtAccessoryHeader.Rows[0]["IsCutting"]);

                if (IsCutting == true)
                    hdnIsCutting.Value = "1";

                IsHistoryExist = DtAccessoryHeader.Rows[0]["HistoryExist"].ToString() == "" ? false : Convert.ToBoolean(DtAccessoryHeader.Rows[0]["HistoryExist"]);
                if (IsHistoryExist == true)
                {
                    ShowImgHis.Visible = true;
                }
            }

            int totalQty = 0;
            int countHeader = DtAccessoryHeader.Rows.Count;

            StringBuilder PrintOrderAccessory = new StringBuilder();
            int CountCollSpan = 2 + countHeader;

            PrintOrderAccessory.Append("<table class='AddClass_Table' border='0' cellspacing='0' cellpadding='0'>");
            PrintOrderAccessory.Append("<tr>");
            PrintOrderAccessory.Append("<th class='CellWidthH1 FirstHeaderth'>Contract No. <br> <span style='color:gray;'>Ex-Factory</span></th>");
            PrintOrderAccessory.Append("<th class='CellWidthH FirstHeaderth2'>Contract<br> Qty.</th>");
            int UnitIncri = 1;
            string ss = "";
            string sUnit = "";

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
                int AccessoryworkingdetailId = Convert.ToInt32(DtAccessoryHeader.Rows[i]["AccessoryworkingdetailId"]);

                //double afterDecimal = Math.Floor(Number);
                //if (afterDecimal > 0)
                Average = Math.Round(Number, 2);
                //else
                //    Average = Convert.ToInt32(Number);


                PrintOrderAccessory.Append("<th class='CellWidth' style='padding:0px 0px'>");
                PrintOrderAccessory.Append("<table class='Inner_Table' border='0' cellspacing='0' cellpadding='0'>");
                PrintOrderAccessory.Append("<tr><th style='height:27px'><span style='color:Blue'>" + DtAccessoryHeader.Rows[i]["TradeName"] + "</span> " + sizeName + "</th></tr>");
                PrintOrderAccessory.Append("<tr><th style='padding-right: 38px;'>" + "<span class='FloatLeft'>Shrnk:<span style='color:#000'>" + shrinkage + "</span></span>" + "<span class='FloatRight'>Wstg: <span style='color:#000'>" + wastage + "</span></span></th></tr>");
                PrintOrderAccessory.Append("<tr><th style='padding: 0px 2px 3px 2px;'>" + "<span class='FloatLeft'>Avg: <input type='text' onchange='calculateAvgUnit(this, " + AccessoryworkingdetailId + ", 1)' value='" + Average + "' class='txtAvg' id='AccessoryAvg" + UnitIncri + "'>" + "</span> <span class='FloatRight'>Unit: <select class='dropdownUnit' name='ddlUnit' id='ddlUnit" + UnitIncri + "' onchange='calculateAvgUnit(this, " + AccessoryworkingdetailId + ", 2)'></select>  " + "</span></th></tr>");
                PrintOrderAccessory.Append("<tr><th style='text-align:center;height:18px;border-bottom: 1px solid #999;border-top: 1px solid #999'> Quantity</th></tr>");
                PrintOrderAccessory.Append("<tr><th style='text-align:center;;height:18px'> Color/Print</th></tr>");
                PrintOrderAccessory.Append("</table>");
                PrintOrderAccessory.Append("</th>");

                ss = ss + "," + AccessoryworkingdetailId.ToString();

                DataTable dtAccessoryUnit = objwc.Get_AccessoryUnit_ForOrder(orderid, AccessoryworkingdetailId);
                int AccessoryUnit = 0;
                AccessoryUnit = Convert.ToInt32(DtAccessoryHeader.Rows[i]["GarmentUnit"]);
                if (AccessoryUnit <= 0)
                {
                    foreach (DataRow row in dtAccessoryUnit.Rows)
                    {
                        if (!string.IsNullOrEmpty(row["AccessoryUnit"].ToString()))
                        {
                            AccessoryUnit = Convert.ToInt32(row["AccessoryUnit"].ToString());
                        }
                    }
                }

                sUnit = sUnit + "," + AccessoryUnit.ToString();

                UnitIncri = UnitIncri + 1;

            }
            hdnAccessDetailId.Value = ss.TrimStart(',');
            hdnUnitId.Value = sUnit.TrimStart(',');

            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "BindDropDownList();", true);

            PrintOrderAccessory.Append("</tr>");

            PrintOrderAccessory.Append("<tr>");

            for (int i = 0; i < DtAccessoryHeader.Rows.Count; i++)
            {
                int AccessoryworkingdetailId = Convert.ToInt32(DtAccessoryHeader.Rows[i]["AccessoryworkingdetailId"]);
                DataSet dsAccressory = new DataSet();
                dsAccressory = objacc.Get_AccessoryPrintOrderSummary(orderid, AccessoryworkingdetailId, 2);
                DtAccessoryOrder = dsAccressory.Tables[0];

                if (i == 0)
                {
                    int TotAvgQuantity = 0;
                    PrintOrderAccessory.Append("<td colspan='2' class='LeftPositonFix'>");
                    for (int j = 0; j < DtContract.Rows.Count; j++)
                    {
                        string SeparateContract = "";
                        string ContractNumber = DtContract.Rows[j]["ContractNumber"].ToString();//new line
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
                        int Quantity = Convert.ToInt32(DtContract.Rows[j]["Quantity"]); //new line

                        PrintOrderAccessory.Append("<table class='Inner_TableFixed' border='0'  cellspacing='0' cellpadding='0'>");
                        PrintOrderAccessory.Append("<tr>");
                        PrintOrderAccessory.Append("<td class='CellWidth1' style='border-right: 1px solid #999;border-bottom: 1px solid #999;background:#dddfe4'> <span style='color:gray;'>" + SeparateContract + " </span><br> <span style='color:#000;font-weight:600;font-size:11px'>" + DateTime.Parse(DtAccessoryOrder.Rows[j]["ExFactory"].ToString()).ToString("dd MMM yy (ddd)") + "</span></td>");
                        PrintOrderAccessory.Append("<td class='CellWidth2' style='border-right: 1px solid #999;border-bottom: 1px solid #999;background:#dddfe4'>" + Quantity.ToString("N0") + "</td>");    //new line
                        PrintOrderAccessory.Append("</td>");
                        PrintOrderAccessory.Append("</tr>");
                        PrintOrderAccessory.Append("</table>");

                        totalQty = totalQty + Convert.ToInt32(DtContract.Rows[j]["Quantity"]);
                    }
                    PrintOrderAccessory.Append("<table class='FooterTable' border='0'  cellspacing='0' cellpadding='0'>");
                    PrintOrderAccessory.Append("<tr>");
                    PrintOrderAccessory.Append("<td class='CellWidth1' style='background:#dddfe4;border-top:0px'>Total</td>");
                    PrintOrderAccessory.Append("<td class='CellWidth2' style='background:#dddfe4;border-top:0px'>" + totalQty.ToString("N0") + "</td>");
                    PrintOrderAccessory.Append("</tr>");
                    PrintOrderAccessory.Append("</table>");
                    PrintOrderAccessory.Append("</td>");

                    PrintOrderAccessory.Append("<td>");
                    for (int j = 0; j < DtAccessoryOrder.Rows.Count; j++)
                    {

                        int AvgQuantity = Convert.ToInt32(DtAccessoryOrder.Rows[j]["AvgQuantity"]); //new line

                        TotAvgQuantity = TotAvgQuantity + AvgQuantity;
                        PrintOrderAccessory.Append("<table class='Inner_Table' border='0'  cellspacing='0' cellpadding='0'>");
                        if (j == 0)
                        {
                            PrintOrderAccessory.Append("<tr>");
                            PrintOrderAccessory.Append("<td class='txtCenter CellWidth3'>");
                            PrintOrderAccessory.Append("<table class='Inner_TableContent' border='0'  cellspacing='0' cellpadding='0'>");
                            PrintOrderAccessory.Append("<tr>");
                            PrintOrderAccessory.Append("<td>" + AvgQuantity.ToString("N0") + "</td>");
                            PrintOrderAccessory.Append("</tr>");
                            PrintOrderAccessory.Append("<tr>");
                            PrintOrderAccessory.Append("<td style='border-top: 1px solid #dbd8d8;font-weight:600'>" + DtAccessoryOrder.Rows[j]["Color_Print"].ToString() + "</td>");
                            PrintOrderAccessory.Append("</tr>");
                            PrintOrderAccessory.Append("</table>");
                            PrintOrderAccessory.Append("</td>");
                            //  PrintOrderAccessory.Append("<td class='txtCenter CellWidth3'><span style='display:block;border-bottom: 1px solid #dbd8d8;'>" + AvgQuantity.ToString("N0") + "</span><span style='color:#000;font-weight:600'>" + DtAccessoryOrder.Rows[j]["Color_Print"].ToString() + "</span></td>");  //new line
                            PrintOrderAccessory.Append("</tr>");
                        }
                        else
                        {
                            PrintOrderAccessory.Append("<tr>");
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
                            //  PrintOrderAccessory.Append("<td class='txtCenter CellWidth3' style='border-top: 1px solid #dbd8d8;'><span style='display:block;border-bottom: 1px solid #dbd8d8;'>" + AvgQuantity.ToString("N0") + "</span><span style='color:#000;font-weight:600'>" + DtAccessoryOrder.Rows[j]["Color_Print"].ToString() + "</span></td>");  //new line
                            PrintOrderAccessory.Append("</tr>");
                        }
                        PrintOrderAccessory.Append("</table>");
                    }
                    if (i == 0)
                    {
                        PrintOrderAccessory.Append("<table class='FooterTable' border='0'  cellspacing='0' cellpadding='0'>");
                        PrintOrderAccessory.Append("<tr>");
                        // PrintOrderAccessory.Append("<td class='CellWidth1'>Total</td>");
                        // PrintOrderAccessory.Append("<td class='CellWidth2'>" + totalQty.ToString("N0") + "</td>");
                        PrintOrderAccessory.Append("<td class='CellWidth3' style='border-right:0px'>" + TotAvgQuantity.ToString("N0") + "</td>");
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
                        int AvgQuantity = Convert.ToInt32(DtAccessoryOrder.Rows[j]["AvgQuantity"]);
                        TotalAvgQuantity = TotalAvgQuantity + AvgQuantity;
                        PrintOrderAccessory.Append("<table class='Inner_Table' border='0'  cellspacing='0' cellpadding='0'>");
                        if (j == 0)
                        {
                            PrintOrderAccessory.Append("<tr>");
                            PrintOrderAccessory.Append("<td class='txtCenter'>");
                            PrintOrderAccessory.Append("<table class='Inner_TableContent' border='0'  cellspacing='0' cellpadding='0'>");
                            PrintOrderAccessory.Append("<tr>");
                            PrintOrderAccessory.Append("<td>" + AvgQuantity.ToString("N0") + "</td>");
                            PrintOrderAccessory.Append("</tr>");
                            PrintOrderAccessory.Append("<tr>");
                            PrintOrderAccessory.Append("<td style='border-top: 1px solid #dbd8d8;font-weight:600'>" + DtAccessoryOrder.Rows[j]["Color_Print"].ToString() + "</td>");
                            PrintOrderAccessory.Append("</tr>");
                            PrintOrderAccessory.Append("</table>");
                            PrintOrderAccessory.Append("</td>");
                            //PrintOrderAccessory.Append("<td class='txtCenter'><span style='display:block;border-bottom: 1px solid #dbd8d8;'>" + AvgQuantity.ToString("N0") + "</span><span style='color:#000;font-weight:600'>" + DtAccessoryOrder.Rows[j]["Color_Print"].ToString() + "</span></td>");
                            PrintOrderAccessory.Append("</tr>");
                        }
                        else
                        {
                            PrintOrderAccessory.Append("<tr>");
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
                            //  PrintOrderAccessory.Append("<td class='txtCenter' style='border-top: 1px solid #ccc;'><span style='display:block;border-bottom: 1px solid #dbd8d8;'>" + AvgQuantity.ToString("N0") + "</span><span style='color:#000;font-weight:600'>" + DtAccessoryOrder.Rows[j]["Color_Print"].ToString() + "</span></td>"); //new line
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
                        PrintOrderAccessory.Append("</table>");
                    }
                    PrintOrderAccessory.Append("</td>");
                }
            }

            PrintOrderAccessory.Append("</tr>");
            PrintOrderAccessory.Append("</table>");

            //hdnAccessSummary.Value = PrintOrderAccessory.ToString();

            dvAccessorySummary.InnerHtml = PrintOrderAccessory.ToString();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            WorkflowController instance = new WorkflowController();
            AccessoryWorkingController objAccessoryController = new AccessoryWorkingController();
            OrderPlaceController objOrderPlaceController = new OrderPlaceController();
            try
            {
                iKandi.Common.OrderPlace order = new Common.OrderPlace();
                int UserId = Convert.ToInt32(hdnUserId.Value);

                if ((chkboxAccountMgr.Checked) && (chkboxAccountMgr.Enabled))
                {
                    objAccessoryController.Save_Accessory_Average("ACC_CHECK", 0, 0, orderid, -1, true, UserId);
                }

                order = objOrderPlaceController.Get_order_by_OrderId_ForOrderPlace(orderid, UserId);

                List<ContractDetails> orderDetailCollection = order.ContractDetail;

                for (int itemNo = 0; itemNo < orderDetailCollection.Count; itemNo++)
                {
                    int OrderDetailId = Convert.ToInt32(orderDetailCollection[itemNo].OrderDetailId);
                    if (OrderDetailId > 0)
                    {
                        instance.Create_CloseWorkflowPostOrder(orderid, OrderDetailId, TaskMode.Create_Accessories, UserId);

                        if ((chkboxAccountMgr.Checked) && (chkboxAccountMgr.Enabled))
                        {
                            instance.Create_CloseWorkflowPostOrder(orderid, OrderDetailId, TaskMode.Accessory_Approved, UserId);
                            instance.Create_CloseWorkflowPostOrder(orderid, OrderDetailId, TaskMode.Create_Accessories, UserId);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert(" + ex.Message + ");", true);
                return;
            }
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "closeAccesButtion();", true);
        }
    }
}