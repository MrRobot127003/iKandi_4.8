using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;
using iKandi.Common;
using iKandi.BLL;
using System.Text;

namespace iKandi.Web.Internal.Accessory
{
    public partial class AccessoryOrderPlacement : System.Web.UI.Page
    {
        int stage1 = 1;
        AccessoryWorkingController objAccessory = new AccessoryWorkingController();
        Designation[] PoRaiseDesig = { Designation.BIPL_Admin, Designation.BIPL_Fabrics_Manager, Designation.BIPL_Accessory_Manager, Designation.BIPL_Accessory_Accountant };
        Designation[] PoReviseDesig = { Designation.BIPL_Admin, Designation.BIPL_Fabrics_Manager, Designation.BIPL_Accessory_Manager, Designation.BIPL_Accessory_Accountant };
        public string AccessoryName { get; set; }
        public string PoSuplytype { get; set; }
        public void getquerystring()
        {
            if (Request.QueryString["PoSuplytype"] != null) { PoSuplytype = Request.QueryString["PoSuplytype"].ToString(); }
            if (Request.QueryString["AccessoryName"] != null) { AccessoryName = Request.QueryString["AccessoryName"].ToString(); } else { AccessoryName = ""; }
            if (Request.QueryString["stage1"] != null) { stage1 = Convert.ToInt32(Request.QueryString["stage1"]); } else { stage1 = 1; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (iKandi.Web.Components.ApplicationHelper.LoggedInUser == null || iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData == null)
                Response.Redirect("~/public/Login.aspx");
            getquerystring();
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(AccessoryName)) { txtsearchkeyswords.Text = AccessoryName; }
                if (!string.IsNullOrEmpty(PoSuplytype))
                {
                    if (Convert.ToInt32(PoSuplytype) == 1) stage1 = 1;
                    else if (Convert.ToInt32(PoSuplytype) == 2) stage1 = 3;
                    else if (Convert.ToInt32(PoSuplytype) == 3) stage1 = 2;
                }
                if (stage1 == 1)
                {
                    hdntabvalue.Value = "GREIGE";
                }
                else if (stage1 == 2)
                {
                    hdntabvalue.Value = "FINISHING";
                }
                else if (stage1 == 3)
                {
                    hdntabvalue.Value = "PROCESS";
                }
                btnTab_Click(sender, e);
            }
        }

        private string PoNumberWithLink(bool IsJuniorSignatory, bool IsAuthorizedSignatory, bool IsPartySignature, string PO_Number)
        {
            string PoLink = "<td style='min-width:54px;max-width:54px;'> <a target='_blank' ";

            if (IsJuniorSignatory == false && IsAuthorizedSignatory == false) // No Signature
            {
                PoLink += " style='color: #d5334b !important;text-decoration: none;' ";
            }
            else if (IsJuniorSignatory == true && IsAuthorizedSignatory == false) // only Junier Sign
            {
                PoLink += " style='color: #ff8c6a !important; text-decoration: none;' ";
            }
            else if (IsJuniorSignatory == true && IsAuthorizedSignatory == true && IsPartySignature == false) // only Junier & GM Sign
            {
                PoLink += " style='color: #515354 !important; text-decoration: none;' ";
            }
            else if (IsJuniorSignatory == true && IsAuthorizedSignatory == true && IsPartySignature == true) // All Sign
            {
                PoLink += " style='text-decoration: none;' href='AccessoryWorkingOnRaisePO.aspx?PONumber=" + Server.UrlEncode(PO_Number) + "' ";
            }

            PoLink += " > " + PO_Number + " </a> </td>";

            return PoLink;
        }
        protected void grdStyle_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblSerialNo = (Label)e.Row.FindControl("lblSerialNo");
                if (lblSerialNo.Text != "")
                {
                    lblSerialNo.Text = "(" + lblSerialNo.Text + ")";
                }
            }
        }
        protected void grdGreige_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblSize = (Label)e.Row.FindControl("lblSize");
                Label lblAccessoryQty = (Label)e.Row.FindControl("lblAccessoryQty");
                Label lblbalanceinhouseqty = (Label)e.Row.FindControl("lblbalanceinhouseqty");
                TextBox txtShrnkg = (TextBox)e.Row.FindControl("txtShrnkg");
                TextBox txtWastage = (TextBox)e.Row.FindControl("txtWastage");
                HiddenField hdnQuantityToOrder = (HiddenField)e.Row.FindControl("hdnQuantityToOrder");
                Label lblQuantityToOrder = (Label)e.Row.FindControl("lblQuantityToOrder");
                HiddenField hdnTotalPassQty = (HiddenField)e.Row.FindControl("hdnTotalPassQty");
                Label lblShrnkgValue = (Label)e.Row.FindControl("lblShrnkgValue");
                Label lblWastageValue = (Label)e.Row.FindControl("lblWastageValue");
                Label lblTooltip = (Label)e.Row.FindControl("lblTooltip");
                Label lblBalanceTooltip = (Label)e.Row.FindControl("lblBalanceTooltip");

                double Shrinkage = txtShrnkg.Text == "" ? 0 : Convert.ToDouble(txtShrnkg.Text);
                double Wastage = txtWastage.Text == "" ? 0 : Convert.ToDouble(txtWastage.Text);
                int AccessoryQty = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "AccessoryQty"));
                int Stage1ReverseQty = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Stage1ReverseQty"));
                int QtyToOrder = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "QuantityToOrder"));
                double FirstVaraible = 0; double SecondVariable = 0;

                if (lblAccessoryQty.Text != "")
                {
                    lblAccessoryQty.Text = Convert.ToInt32(lblAccessoryQty.Text).ToString("N0");
                }
                if (lblSize.Text != "")
                    lblSize.Text = lblSize.Text.ToLower() == "default".ToLower() ? "" : "(" + lblSize.Text + ")";

                if (lblbalanceinhouseqty.Text != "")
                {
                    lblbalanceinhouseqty.Text = Convert.ToInt32(lblbalanceinhouseqty.Text).ToString("N0");
                    if (Stage1ReverseQty > 0)
                    {
                        lblBalanceTooltip.Text = "Process Stock Greige Adjustment: <span style='color:yellow'>" + Stage1ReverseQty.ToString() + "</span>";
                        lblBalanceTooltip.CssClass = "TooltipTxt";
                    }
                }

                // Updated on 17 march 2021 RSB and RK
                //QtyToOrder = AccessoryQty;
                if ((100 - (Shrinkage + Wastage)) > 0)
                {
                    FirstVaraible = (Convert.ToDouble(AccessoryQty) * 100) / (Convert.ToDouble(100) - Convert.ToDouble(Shrinkage));
                    SecondVariable = (Convert.ToDouble(FirstVaraible) * 100) / (Convert.ToDouble(100) - Convert.ToDouble(Wastage));
                }

                if (txtShrnkg.Text != "")
                {
                    lblShrnkgValue.Text = "(" + Math.Round((FirstVaraible - Convert.ToDouble(AccessoryQty)), 0).ToString("N0") + ")";
                }
                if (txtWastage.Text != "")
                {
                    lblWastageValue.Text = "(" + Math.Round((SecondVariable - FirstVaraible), 0).ToString("N0") + ")";
                }

                if (QtyToOrder > 0)
                {
                    hdnQuantityToOrder.Value = QtyToOrder.ToString();
                    lblQuantityToOrder.Text = QtyToOrder.ToString("N0");
                    // edit by surendra on 13-01-2021 for tool tip
                    string shr = "";
                    string Grg = "";
                    string shrFor = "";
                    string GrgFor = "";
                    if (txtShrnkg.Text == "")
                    {
                        shr = "";
                        shrFor = "";
                    }
                    else
                    {
                        shr = txtShrnkg.Text;
                        shrFor = "/(1-" + shr + "%)";
                    }

                    if (txtWastage.Text == "")
                    {
                        Grg = "";
                        GrgFor = "";
                    }
                    else
                    {
                        Grg = txtWastage.Text;
                        GrgFor = "/(1-" + Grg + "%)";
                    }
                    lblTooltip.Text = "<span style='color:#d9dac7'> Send Qty: </span> (" + lblAccessoryQty.Text + shrFor + ")" + GrgFor;
                    lblTooltip.CssClass = "TooltipTxt";
                }

                int AccessoryMasterId = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "AccessoryMasterId"));
                string Size = DataBinder.Eval(e.Row.DataItem, "Size").ToString();
                string ColorPrint = "";

                DataSet dsAccessory = objAccessory.GetAccessory_Supplier_OrderPlacement(AccessoryMasterId, Size, ColorPrint, 1);
                DataTable dtStyle = dsAccessory.Tables[0];
                // DataTable dtSupplier = dsAccessory.Tables[1];

                // Style and Serial no binding

                GridView grdStyle = (GridView)e.Row.FindControl("grdStyle");

                if (dtStyle.Rows.Count > 0)
                {
                    grdStyle.DataSource = dtStyle;
                    grdStyle.DataBind();

                    for (int i = grdStyle.Rows.Count - 1; i > 0; i--)
                    {
                        GridViewRow row = grdStyle.Rows[i];
                        GridViewRow previousRow = grdStyle.Rows[i - 1];

                        Label lblStyle = (Label)row.FindControl("lblStyle");
                        Label lblStylePrev = (Label)previousRow.FindControl("lblStyle");

                        if (lblStyle.Text == lblStylePrev.Text)
                        {
                            if (previousRow.Cells[0].RowSpan == 0)
                            {
                                if (row.Cells[0].RowSpan == 0)
                                {
                                    previousRow.Cells[0].RowSpan += 2;
                                }
                                else
                                {
                                    previousRow.Cells[0].RowSpan = row.Cells[0].RowSpan + 1;
                                }
                                row.Cells[0].Visible = false;
                            }
                        }

                        Label lblSerialNoNext = (Label)row.FindControl("lblSerialNo");
                        Label lblSerialNoPrev = (Label)previousRow.FindControl("lblSerialNo");


                        if (lblSerialNoNext.Text == lblSerialNoPrev.Text)
                        {
                            if (previousRow.Cells[1].RowSpan == 0)
                            {
                                if (row.Cells[1].RowSpan == 0)
                                {
                                    previousRow.Cells[1].RowSpan += 2;
                                }
                                else
                                {
                                    previousRow.Cells[1].RowSpan = row.Cells[1].RowSpan + 1;
                                }
                                row.Cells[1].Visible = false;
                            }
                        }
                    }
                }

                HtmlGenericControl divraise = e.Row.FindControl("divraise") as HtmlGenericControl;
                divraise.Style.Add("display", "");

                // For Supplier Quotation work

                HtmlAnchor lnkProductionpopup = e.Row.FindControl("lnkProductionpopup") as HtmlAnchor;
                lnkProductionpopup.Attributes.Add("onclick", "javascript:ShowAllSupplier(" + AccessoryMasterId + ", '" + Size.Trim() + "', '" + ColorPrint.Trim() + "', 1)");

                Label lblPendingQtyToOrder = (Label)e.Row.FindControl("lblPendingQtyToOrder");
                HiddenField hdnPendingQtyToOrder = (HiddenField)e.Row.FindControl("hdnPendingQtyToOrder");


                int QtyRecieved = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "TotalQtyRecieved"));
                int HoldQty = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "TotalHoldQty"));


                int TotalPassQty = hdnTotalPassQty.Value == "" ? 0 : Convert.ToInt32(hdnTotalPassQty.Value);
                int QtyFromStock = lblbalanceinhouseqty.Text == "" ? 0 : Convert.ToInt32(lblbalanceinhouseqty.Text.Replace(",", ""));
                int RemainingQty = 0;

                RemainingQty = QtyToOrder - QtyRecieved - QtyFromStock;

                if (RemainingQty > HoldQty)
                    RemainingQty = RemainingQty - HoldQty;

                //if (RemainingQty == 1)
                //{
                //    RemainingQty = 0;
                //}

                hdnPendingQtyToOrder.Value = RemainingQty.ToString();
                lblPendingQtyToOrder.Text = RemainingQty == 0 ? "" : RemainingQty.ToString("N0");

                string tooltipHoldQty = HoldQty <= 0 ? "" : "Hold Qty:" + " " + HoldQty.ToString("N0");
                lblPendingQtyToOrder.ToolTip = tooltipHoldQty;

                if (RemainingQty > 0)
                {
                    int SupplierPoId = -1;
                    divraise.Attributes.Add("onclick", "javascript:ShowPurchaseOrder(this," + AccessoryMasterId + ", '" + Size.Trim() + "', '" + ColorPrint.Trim() + "', " + SupplierPoId + ", 1)");
                }
                else
                {
                    divraise.Style.Add("display", "none");
                }
                // For Supplier PO
                List<AccessoryPending> AccessListPO = objAccessory.GetAccessory_SupplierPO_DETAILS(AccessoryMasterId, Size.Trim(), ColorPrint.Trim(), 1);

                StringBuilder sbGreige = new StringBuilder();
                if (AccessListPO.Count > 0)
                {
                    sbGreige.Append("<table border='0' cellspacing='0' cellpadding='0' class='PoTable' style='width:100%'>");
                    int QtyToOrderGreige = RemainingQty;
                    for (int i = 0; i < AccessListPO.Count; i++)
                    {
                        sbGreige.Append("<tr>");
                        sbGreige.Append(PoNumberWithLink(AccessListPO[i].IsJuniorSignatory, AccessListPO[i].IsAuthorizedSignatory, AccessListPO[i].IsPartySignature, AccessListPO[i].PoNumber));
                        sbGreige.Append("<td style='min-width:87px;max-width:87px;'>" + AccessListPO[i].SupplierName + "</td>");
                        sbGreige.Append("<td style='min-width:42px;max-width:42px;'>" + AccessListPO[i].ReceivedQty.ToString("N0") + "</td>");
                        if (AccessListPO[i].TotalHoldQty.ToString("N0") == "0")
                        {
                            sbGreige.Append("<td style='min-width:37px;max-width:37px;text-align:center'><div  class='btnrepo tooltip' onclick='javascript:ShowPurchaseOrderPo(" + AccessoryMasterId + "," + "&apos;" + Size.Trim() + "&apos;" + "," + "&apos;" + ColorPrint.Trim() + "&apos;" + "," + QtyToOrderGreige + "," + AccessListPO[i].SupplierPoId + ",1)'>Re.PO</div></td>");
                        }
                        else
                        {
                            sbGreige.Append("<td style='min-width:37px;max-width:37px;text-align:center'><div class='btnrepo tooltip' onclick='javascript:ShowPurchaseOrderPo(" + AccessoryMasterId + "," + "&apos;" + Size.Trim() + "&apos;" + "," + "&apos;" + ColorPrint.Trim() + "&apos;" + "," + QtyToOrderGreige + "," + AccessListPO[i].SupplierPoId + ",1)'>Re.PO</div></td>");
                        }
                        sbGreige.Append("</tr>");
                    }
                    sbGreige.Append("</table>");
                    e.Row.Cells[7].Text = sbGreige.ToString();

                }
                else
                {
                    sbGreige.Append("<table border='0' cellspacing='0' cellpadding='0' class='PoTable' style='width:100%'>");
                    sbGreige.Append("<tr>");
                    sbGreige.Append("<td style='min-width:54px;max-width:54px;border-top:0px;border-bottom:0px'>" + "" + "</td>");
                    sbGreige.Append("<td style='min-width:87px;max-width:87px;border-top:0px;border-bottom:0px'>" + "" + "</td>");
                    sbGreige.Append("<td style='min-width:42px;max-width:42px;border-top:0px;border-bottom:0px'>" + "" + "</td>");
                    sbGreige.Append("<td style='min-width:37px;max-width:37px;text-align:center;border-top:0px;border-bottom:0px'></td>");
                    sbGreige.Append("</tr>");

                    sbGreige.Append("</table>");
                    e.Row.Cells[7].Text = sbGreige.ToString();
                }

            }
        }
        protected void grdProcess_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblSize = (Label)e.Row.FindControl("lblSize");
                Label lblProAccessoryQty = (Label)e.Row.FindControl("lblProAccessoryQty");
                Label lblbalanceinhouseqty = (Label)e.Row.FindControl("lblbalanceinhouseqty");
                Label lblAccessSendQty = (Label)e.Row.FindControl("lblAccessSendQty");
                TextBox txtShrnkg = (TextBox)e.Row.FindControl("txtShrnkg");
                TextBox txtWastage = (TextBox)e.Row.FindControl("txtWastage");
                Label lblAccessTotalQtySend = (Label)e.Row.FindControl("lblAccessTotalQtySend");
                Label lblunipcs = (Label)e.Row.FindControl("lblunipcs");
                Label lblShrnkgValue = (Label)e.Row.FindControl("lblShrnkgValue");
                Label lblWastageValue = (Label)e.Row.FindControl("lblWastageValue");
                Label lblAccessPriorQty = (Label)e.Row.FindControl("lblAccessPriorQty");
                Label lblQtyunitpcs = (Label)e.Row.FindControl("lblQtyunitpcs");
                HtmlGenericControl divraise = e.Row.FindControl("divraise") as HtmlGenericControl;
                Label lblPendingQtyToOrder = (Label)e.Row.FindControl("lblPendingQtyToOrder");
                HiddenField hdnPendingQtyToOrder = (HiddenField)e.Row.FindControl("hdnPendingQtyToOrder");
                HtmlAnchor lnkProductionpopup = e.Row.FindControl("lnkProductionpopup") as HtmlAnchor;

                int AccessoryQty = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "AccessoryQty"));
                int QtyToOrder = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "QuantityToOrder"));
                int AccessoryMasterId = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "AccessoryMasterId"));
                string Size = DataBinder.Eval(e.Row.DataItem, "Size").ToString();
                string ColorPrint = DataBinder.Eval(e.Row.DataItem, "Color_Print").ToString();         
                int GreigePoQty = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "PoQuantity"));
                int SendQty = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "SendQty"));
                int HoldQty = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "TotalHoldQty"));
                int QtyFromStock = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "BalanceQty"));

                double Shrinkage = txtShrnkg.Text == "" ? 0 : Convert.ToDouble(txtShrnkg.Text);
                double Wastage = txtWastage.Text == "" ? 0 : Convert.ToDouble(txtWastage.Text);
                double FirstVaraible = 0; double SecondVariable = 0;

                if (lblProAccessoryQty.Text != "") { lblProAccessoryQty.Text = Convert.ToInt32(lblProAccessoryQty.Text).ToString("N0"); }
                if (lblAccessSendQty.Text != "") { lblAccessSendQty.Text = Convert.ToInt32(lblAccessSendQty.Text).ToString("N0"); }                             
                if ((100 - (Shrinkage + Wastage)) > 0)
                {
                    FirstVaraible = (Convert.ToDouble(AccessoryQty) * 100) / (Convert.ToDouble(100) - Convert.ToDouble(Shrinkage));
                    SecondVariable = (Convert.ToDouble(FirstVaraible) * 100) / (Convert.ToDouble(100) - Convert.ToDouble(Wastage));
                }
                if (txtShrnkg.Text != "") { lblShrnkgValue.Text = "(" + Math.Round((FirstVaraible - Convert.ToDouble(AccessoryQty)), 0).ToString("N0") + ")"; }
                if (txtWastage.Text != "") { lblWastageValue.Text = "(" + Math.Round((SecondVariable - FirstVaraible), 0).ToString("N0") + ")"; }
                Label lblProcessTooltip = (Label)e.Row.FindControl("lblProcessTooltip");
                if (QtyToOrder > 0)
                {
                    string shr = "";
                    string Grg = "";
                    string shrnk = "";
                    string shrnkMul = "";
                    string greige = "";
                    string multiplierSign = "";
                    if (lblShrnkgValue.Text == "") { shr = ""; shrnk = ""; } else { shr = txtShrnkg.Text; shrnk = "/(1-" + shr + "%)"; }
                    if (lblShrnkgValue.Text == "") { shr = ""; shrnkMul = ""; } else { shr = txtShrnkg.Text; shrnkMul = "(1-" + shr + "%)"; }
                    if (lblWastageValue.Text == "") { Grg = ""; greige = ""; } else { Grg = txtWastage.Text; greige = "/(1-" + Grg + "%)"; }
                    if (shr != "" && Grg != "") { multiplierSign = "<span style='position:relative;top:2px'> * </span>"; } else { multiplierSign = ""; }
                    if (txtWastage.Text == "") { Grg = ""; } else { Grg = txtWastage.Text; }
                    lblAccessTotalQtySend.Text = QtyToOrder.ToString("N0");
                    string ProcessTol1 = " <span style='color:#d9dac7'> Send Qty: </span>(" + lblProAccessoryQty.Text + shrnk + ")" + greige;
                    string ProcessTol2 = " <span style='color:#d9dac7'> Rec Qty: </span>(" + lblProAccessoryQty.Text + "" + shrnk + greige + multiplierSign + shrnkMul + ")";
                    lblProcessTooltip.Text = ProcessTol1 + "<br>" + ProcessTol2;
                    lblProcessTooltip.CssClass = "TooltipTxt";
                }           

                if (lblAccessPriorQty.Text != "") { lblAccessPriorQty.Text = Convert.ToInt32(lblAccessPriorQty.Text).ToString("N0"); }
                if (lblSize.Text != "") { lblSize.Text = lblSize.Text.ToLower() == "Default".ToLower() ? "" : "(" + lblSize.Text + ")"; }
                if (lblbalanceinhouseqty.Text != "") { lblbalanceinhouseqty.Text = Convert.ToInt32(lblbalanceinhouseqty.Text).ToString("N0"); }
                         
                DataSet dsAccessory = objAccessory.GetAccessory_Supplier_OrderPlacement(AccessoryMasterId, Size, ColorPrint, 2);
                DataTable dtStyle = dsAccessory.Tables[0];

                GridView grdStyle = (GridView)e.Row.FindControl("grdProStyle");

                if (dtStyle.Rows.Count > 0)
                {
                    grdStyle.DataSource = dtStyle;
                    grdStyle.DataBind();

                    for (int i = grdStyle.Rows.Count - 1; i > 0; i--)
                    {
                        GridViewRow row = grdStyle.Rows[i];
                        GridViewRow previousRow = grdStyle.Rows[i - 1];

                        Label lblStyle = (Label)row.FindControl("lblStyle");
                        Label lblStylePrev = (Label)previousRow.FindControl("lblStyle");

                        if (lblStyle.Text == lblStylePrev.Text)
                        {
                            if (previousRow.Cells[0].RowSpan == 0)
                            {
                                if (row.Cells[0].RowSpan == 0)
                                {
                                    previousRow.Cells[0].RowSpan += 2;
                                }
                                else
                                {
                                    previousRow.Cells[0].RowSpan = row.Cells[0].RowSpan + 1;
                                }
                                row.Cells[0].Visible = false;
                            }
                        }

                        Label lblSerialNoCurent = (Label)row.FindControl("lblSerialNo");
                        Label lblSerialNoPrev = (Label)previousRow.FindControl("lblSerialNo");

                        if (lblSerialNoCurent.Text == lblSerialNoPrev.Text)
                        {
                            if (previousRow.Cells[1].RowSpan == 0)
                            {
                                if (row.Cells[1].RowSpan == 0)
                                {
                                    previousRow.Cells[1].RowSpan += 2;
                                }
                                else
                                {
                                    previousRow.Cells[1].RowSpan = row.Cells[1].RowSpan + 1;
                                }
                                row.Cells[1].Visible = false;
                            }
                        }
                    }
                }               
               
                divraise.Style.Add("display", "");                
                lnkProductionpopup.Attributes.Add("onclick", "javascript:ShowAllSupplier(" + AccessoryMasterId + ", '" + Size.Trim() + "', '" + ColorPrint.Trim() + "', 2)");
             
                int RemainingQty = 0;
                if (GreigePoQty > 0)
                {
                    RemainingQty = QtyToOrder - SendQty - QtyFromStock;

                    if (RemainingQty > HoldQty)
                        RemainingQty = RemainingQty - HoldQty;
                }

                //if (RemainingQty == 1)
                //{
                //    RemainingQty = 0;
                //}
                lblPendingQtyToOrder.Text = RemainingQty == 0 ? "" : RemainingQty.ToString("N0");
                               
                hdnPendingQtyToOrder.Value = RemainingQty.ToString();
                string tooltipHoldQty = HoldQty <= 0 ? "" : "Hold Qty:" + " " + HoldQty.ToString("N0");
                lblPendingQtyToOrder.ToolTip = tooltipHoldQty;
                if (RemainingQty > 0)
                {
                    int SupplierPoId = -1;
                    divraise.Attributes.Add("onclick", "javascript:ShowPurchaseOrder(this," + AccessoryMasterId + ", '" + Size.Trim() + "', '" + ColorPrint.Trim() + "', " + SupplierPoId + ", 2)");
                }
                else
                {
                    divraise.Style.Add("display", "none");
                }

                // For Supplier PO
                List<AccessoryPending> AccessListPO = objAccessory.GetAccessory_SupplierPO_DETAILS(AccessoryMasterId, Size.Trim(), ColorPrint.Trim(), 2);

                if (AccessListPO.Count > 0)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append("<table border='0' cellspacing='0' cellpadding='0' class='PoTable' style='width:100%'>");
                    QtyToOrder = RemainingQty;

                    for (int i = 0; i < AccessListPO.Count; i++)
                    {
                        sb.Append("<tr>");
                        sb.Append(PoNumberWithLink(AccessListPO[i].IsJuniorSignatory, AccessListPO[i].IsAuthorizedSignatory, AccessListPO[i].IsPartySignature, AccessListPO[i].PoNumber));
                        sb.Append("<td style='min-width:87px;max-width:87px;'>" + AccessListPO[i].SupplierName + "</td>");
                        sb.Append("<td style='min-width:42px;max-width:42px;'>" + AccessListPO[i].ReceivedQty.ToString("N0") + "</td>");
                        sb.Append("<td style='min-width:37px;max-width:37px;text-align:center'><div class='btnrepo tooltip' onclick='javascript:ShowPurchaseOrderPo(" + AccessoryMasterId + "," + "&apos;" + Size.Trim() + "&apos;" + "," + "&apos;" + ColorPrint.Trim() + "&apos;" + "," + QtyToOrder + "," + AccessListPO[i].SupplierPoId + ",2)'>Re.PO</div></td>");
                        sb.Append("</tr>");
                    }
                    sb.Append("</table>");
                    e.Row.Cells[9].Text = sb.ToString();
                }
                else
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append("<table border='0' cellspacing='0' cellpadding='0' class='PoTable' style='width:100%'>");
                    sb.Append("<tr>");
                    sb.Append("<td style='min-width:54px;max-width:54px;border-top:0px;border-bottom:0px'>" + "" + "</td>");
                    sb.Append("<td style='min-width:87px;max-width:87px;border-top:0px;border-bottom:0px'>" + "" + "</td>");
                    sb.Append("<td style='min-width:42px;max-width:42px;border-top:0px;border-bottom:0px'>" + "" + "</td>");
                    sb.Append("<td style='min-width:37px;max-width:37px;text-align:center;border-top:0px;border-bottom:0px'></td>");
                    sb.Append("</tr>");
                    sb.Append("</table>");
                    e.Row.Cells[9].Text = sb.ToString();
                }
            }
        }
        protected void grdFinish_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblSize = (Label)e.Row.FindControl("lblSize");
                Label lblFinAccessoryQty = (Label)e.Row.FindControl("lblFinAccessoryQty");
                Label lblbalanceinhouseqty = (Label)e.Row.FindControl("lblbalanceinhouseqty");
                Label lblQuantityToOrder = (Label)e.Row.FindControl("lblQuantityToOrder");
                TextBox txtWastage = (TextBox)e.Row.FindControl("txtWastage");
                Label lblWastageValue = (Label)e.Row.FindControl("lblWastageValue");
                HiddenField hdnQuantityToOrder = (HiddenField)e.Row.FindControl("hdnQuantityToOrder");
                HiddenField hdnTotalPassQty = (HiddenField)e.Row.FindControl("hdnTotalPassQty");
                Label lblTooltip = (Label)e.Row.FindControl("lblTooltip");

                if (lblFinAccessoryQty.Text != "") lblFinAccessoryQty.Text = Convert.ToInt32(lblFinAccessoryQty.Text).ToString("N0");
                if (lblSize.Text != "") lblSize.Text = lblSize.Text.ToLower() == "Default".ToLower() ? "" : "(" + lblSize.Text + ")";
                if (lblbalanceinhouseqty.Text != "") lblbalanceinhouseqty.Text = Convert.ToInt32(lblbalanceinhouseqty.Text).ToString("N0");
                double Wastage = txtWastage.Text == "" ? 0 : Convert.ToDouble(txtWastage.Text);
                int AccessoryQty = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "AccessoryQty"));
                double QtyToOrder = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "QuantityToOrder"));
                if (txtWastage.Text != "") { lblWastageValue.Text = "(" + Math.Round((QtyToOrder - AccessoryQty), 2).ToString("N0") + ")"; }
                if (QtyToOrder > 0)
                {
                    hdnQuantityToOrder.Value = QtyToOrder.ToString();
                    lblQuantityToOrder.Text = QtyToOrder.ToString("N0");
                    string shr = ""; string shrFormu = "";
                    if (txtWastage.Text == "") { shr = ""; shrFormu = ""; }
                    else { shr = txtWastage.Text; shrFormu = "/(1-" + shr + "%)"; }
                    lblTooltip.Text = " <span style='color:#d9dac7'> Send Qty: </span> (" + lblFinAccessoryQty.Text + shrFormu + ")";
                    lblTooltip.CssClass = "TooltipTxt";
                }

                int AccessoryMasterId = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "AccessoryMasterId"));
                string Size = DataBinder.Eval(e.Row.DataItem, "Size").ToString();
                string ColorPrint = DataBinder.Eval(e.Row.DataItem, "Color_Print").ToString();

                DataSet dsAccessory = objAccessory.GetAccessory_Supplier_OrderPlacement(AccessoryMasterId, Size, ColorPrint, 3);
                DataTable dtStyle = dsAccessory.Tables[0];
                // DataTable dtSupplier = dsAccessory.Tables[1];

                // Style and Serial no binding

                GridView grdStyle = (GridView)e.Row.FindControl("grdFiniStyle");

                if (dtStyle.Rows.Count > 0)
                {
                    grdStyle.DataSource = dtStyle;
                    grdStyle.DataBind();

                    for (int i = grdStyle.Rows.Count - 1; i > 0; i--)
                    {
                        GridViewRow row = grdStyle.Rows[i];
                        GridViewRow previousRow = grdStyle.Rows[i - 1];

                        Label lblStyle = (Label)row.FindControl("lblStyle");
                        Label lblStylePrev = (Label)previousRow.FindControl("lblStyle");

                        if (lblStyle.Text == lblStylePrev.Text)
                        {
                            if (previousRow.Cells[0].RowSpan == 0)
                            {
                                if (row.Cells[0].RowSpan == 0)
                                {
                                    previousRow.Cells[0].RowSpan += 2;
                                }
                                else
                                {
                                    previousRow.Cells[0].RowSpan = row.Cells[0].RowSpan + 1;
                                }
                                row.Cells[0].Visible = false;
                            }
                        }

                        Label lblSerialNo = (Label)row.FindControl("lblSerialNo");
                        Label lblSerialNoPrev = (Label)previousRow.FindControl("lblSerialNo");

                        if (lblSerialNo.Text == lblSerialNoPrev.Text)
                        {
                            if (previousRow.Cells[1].RowSpan == 0)
                            {
                                if (row.Cells[1].RowSpan == 0)
                                {
                                    previousRow.Cells[1].RowSpan += 2;
                                }
                                else
                                {
                                    previousRow.Cells[1].RowSpan = row.Cells[1].RowSpan + 1;
                                }
                                row.Cells[1].Visible = false;
                            }
                        }
                    }
                }


                HtmlGenericControl divraise = e.Row.FindControl("divraise") as HtmlGenericControl;
                divraise.Style.Add("display", "");


                // For Supplier Quotation work

                HtmlAnchor lnkProductionpopup = e.Row.FindControl("lnkProductionpopup") as HtmlAnchor;
                lnkProductionpopup.Attributes.Add("onclick", "javascript:ShowAllSupplier(" + AccessoryMasterId + ", '" + Size.Trim() + "', '" + ColorPrint.Trim() + "', 3)");

                Label lblPendingQtyToOrder = (Label)e.Row.FindControl("lblPendingQtyToOrder");
                HiddenField hdnPendingQtyToOrder = (HiddenField)e.Row.FindControl("hdnPendingQtyToOrder");

                int QtyRecieved = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "TotalQtyRecieved"));
                int TotalPassQty = hdnTotalPassQty.Value == "" ? 0 : Convert.ToInt32(hdnTotalPassQty.Value);
                int QtyFromStock = lblbalanceinhouseqty.Text == "" ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "BalanceQty"));
                int HoldQty = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "TotalHoldQty"));

                int RemainingQty = 0;
                RemainingQty = Convert.ToInt32(QtyToOrder) - QtyRecieved - QtyFromStock;

                if (RemainingQty > HoldQty)
                    RemainingQty = RemainingQty - HoldQty;

                //if (RemainingQty == 1)
                //{
                //    RemainingQty = 0;
                //}


                hdnPendingQtyToOrder.Value = RemainingQty.ToString();
                lblPendingQtyToOrder.Text = RemainingQty == 0 ? "" : RemainingQty.ToString("N0");

                string tooltipHoldQty = HoldQty <= 0 ? "" : "Hold Qty:" + " " + HoldQty.ToString("N0");

                lblPendingQtyToOrder.ToolTip = tooltipHoldQty;


                if (RemainingQty > 0)
                {
                    int SupplierPoId = -1;
                    divraise.Attributes.Add("onclick", "javascript:ShowPurchaseOrder(this," + AccessoryMasterId + ", '" + Size.Trim() + "', '" + ColorPrint.Trim() + "', " + SupplierPoId + ", 3)");
                }
                else
                {
                    divraise.Style.Add("display", "none");
                }

                // For Supplier PO
                List<AccessoryPending> AccessListPO = objAccessory.GetAccessory_SupplierPO_DETAILS(AccessoryMasterId, Size.Trim(), ColorPrint.Trim(), 3);

                StringBuilder sbFinish = new StringBuilder();
                if (AccessListPO.Count > 0)
                {
                    sbFinish.Append("<table border='0' cellspacing='0' cellpadding='0' class='PoTable' style='width:100%'>");
                    for (int i = 0; i < AccessListPO.Count; i++)
                    {
                        sbFinish.Append("<tr>");
                        sbFinish.Append(PoNumberWithLink(AccessListPO[i].IsJuniorSignatory, AccessListPO[i].IsAuthorizedSignatory, AccessListPO[i].IsPartySignature, AccessListPO[i].PoNumber));
                        sbFinish.Append("<td style='min-width:87px;max-width:87px;'>" + AccessListPO[i].SupplierName + "</td>");
                        sbFinish.Append("<td style='min-width:42px;max-width:42px;'>" + AccessListPO[i].ReceivedQty.ToString("N0") + "</td>");
                        sbFinish.Append("<td style='min-width:37px;max-width:37px;text-align:center'><div class='btnrepo tooltip' onclick='javascript:ShowPurchaseOrderPo(" + AccessoryMasterId + "," + "&apos;" + Size.Trim() + "&apos;" + "," + "&apos;" + ColorPrint.Trim() + "&apos;" + "," + RemainingQty + "," + AccessListPO[i].SupplierPoId + ",3)'>Re.PO</div></td>");
                        sbFinish.Append("</tr>");
                    }
                    sbFinish.Append("</table>");
                    e.Row.Cells[6].Text = sbFinish.ToString();
                }
                else
                {
                    sbFinish.Append("<table border='0' cellspacing='0' cellpadding='0' class='PoTable' style='width:100%'>");
                    sbFinish.Append("<tr>");
                    sbFinish.Append("<td style='min-width:54px;max-width:54px;border-top:0px;border-bottom:0px'> </td>");
                    sbFinish.Append("<td style='min-width:87px;max-width:87px;border-top:0px;border-bottom:0px'> </td>");
                    sbFinish.Append("<td style='min-width:42px;max-width:42px;border-top:0px;border-bottom:0px'> </td>");
                    sbFinish.Append("<td style='min-width:37px;max-width:37px;text-align:center;border-top:0px;border-bottom:0px'> </td>");
                    sbFinish.Append("</tr>");
                    sbFinish.Append("</table>");
                    e.Row.Cells[6].Text = sbFinish.ToString();
                }
            }
        }
        protected void btnTab_Click(object sender, EventArgs e)
        {
            if (hdntabvalue.Value == "GREIGE")
            {
                aGreige.Attributes.Add("class", "tab1greige activeback");
                aProcess.Attributes.Remove("class");
                aFinish.Attributes.Remove("class");
                aProcess.Attributes.Add("class", "tab1Process");
                aFinish.Attributes.Add("class", "tab1finished");

                grdGreige.Style.Add("display", "");
                grdProcess.Style.Add("display", "none");
                grdFinish.Style.Add("display", "none");

                List<AccessoryPending> AccessList = objAccessory.GetAccessory_OrderPlacement(0, 1, txtsearchkeyswords.Text.Trim());
                grdGreige.DataSource = AccessList;
                grdGreige.DataBind();
            }
            if (hdntabvalue.Value == "PROCESS")
            {
                aProcess.Attributes.Add("class", "tab1greige activeback");
                aGreige.Attributes.Remove("class");
                aFinish.Attributes.Remove("class");
                aGreige.Attributes.Add("class", "tab1Process");
                aFinish.Attributes.Add("class", "tab1finished");

                //aProcess.Attributes.Add("class", "tab1Process activeback");
                //aGreige.Attributes.Remove("class");
                //aFinish.Attributes.Remove("class");
                //aGreige.Attributes.Add("class", "tab1greige");
                //aFinish.Attributes.Add("class", "tab1finished");

                grdGreige.Style.Add("display", "none");
                grdProcess.Style.Add("display", "");
                grdFinish.Style.Add("display", "none");

                List<AccessoryPending> AccessList = objAccessory.GetAccessory_OrderPlacement(0, 2, txtsearchkeyswords.Text.Trim());
                grdProcess.DataSource = AccessList;
                grdProcess.DataBind();

            }
            if (hdntabvalue.Value == "FINISHING")
            {
                aFinish.Attributes.Add("class", "tab1greige activeback");
                aGreige.Attributes.Remove("class");
                aProcess.Attributes.Remove("class");
                aGreige.Attributes.Add("class", "tab1Process");
                aProcess.Attributes.Add("class", "tab1finished");

                //aFinish.Attributes.Add("class", "tab1finished activeback");
                //aGreige.Attributes.Remove("class");
                //aProcess.Attributes.Remove("class");
                //aGreige.Attributes.Add("class", "tab1greige");
                //aProcess.Attributes.Add("class", "tab1Process");

                grdGreige.Style.Add("display", "none");
                grdProcess.Style.Add("display", "none");
                grdFinish.Style.Add("display", "");

                List<AccessoryPending> AccessList = objAccessory.GetAccessory_OrderPlacement(0, 3, txtsearchkeyswords.Text.Trim());
                grdFinish.DataSource = AccessList;
                grdFinish.DataBind();

            }
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            btnTab_Click(sender, e);
        }
    }
}