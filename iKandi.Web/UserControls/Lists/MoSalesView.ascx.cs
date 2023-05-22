using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iKandi.BLL;
using iKandi.Common;
using System.Data;

namespace iKandi.Web.UserControls.Lists
{
    public partial class MoSalesView : System.Web.UI.UserControl
    {
        public int Year
        {
            get;
            set;
        }
        public string Years
        {
            get;
            set;
        }
        public int FromWeek
        {
            get;
            set;
        }

        public int ToWeek
        {
            get;
            set;
        }
        public int ClientId
        {
            get;
            set;
        }
        public int BH
        {
            get;
            set;
        }
        public int UnitId
        {
            get;
            set;
        }
        public int DateType
        {
            get;
            set;
        }
        public int StatusMode
        {
            get;
            set;
        }
        public int StatusModeSequence
        {
            get;
            set;
        }
        public int Month
        {
            get;
            set;
        }
        public int Week
        {
            get;
            set;
        }
        public int AM
        {
            get;
            set;
        }
        public int DeptID
        {
            get;
            set;
        }

        DateTime StartDate = DateTime.Now, EndDate = DateTime.Now;

        BuyingHouseController objBuyingHouseController = new BuyingHouseController();
        OrderController objOrderController = new OrderController();
        DataSet dtSales = new DataSet();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (null != Request.QueryString["Year"])
            {
                Years = Request.QueryString["Year"].ToString();
            }
            if (null != Request.QueryString["FromWeek"])
            {
                FromWeek = Convert.ToInt32(Request.QueryString["FromWeek"]);
            }
            if (null != Request.QueryString["ToWeek"])
            {
                ToWeek = Convert.ToInt32(Request.QueryString["ToWeek"]);
            }
            if (null != Request.QueryString["BH"])
            {
                BH = Convert.ToInt32(Request.QueryString["BH"]);
                hdnBH.Value = BH.ToString();
            }
            if (null != Request.QueryString["ClientId"])
            {
                ClientId = Convert.ToInt32(Request.QueryString["ClientId"]);
            }
            if (null != Request.QueryString["UnitId"])
            {
                UnitId = Convert.ToInt32(Request.QueryString["UnitId"]);
            }
            if (null != Request.QueryString["DateType"])
            {
                DateType = Convert.ToInt32(Request.QueryString["DateType"]);
                if (DateType == 1)
                {
                    hdnWeekHeader.Value = "Ex-fac";
                }
                if (DateType == 2)
                {
                    hdnWeekHeader.Value = "DC";
                }
                if (DateType == 3)
                {
                    hdnWeekHeader.Value = "Order";
                }
            }
            if (null != Request.QueryString["StatusMode"])
            {
                StatusMode = Convert.ToInt32(Request.QueryString["StatusMode"]);
            }
            if (null != Request.QueryString["StatusModeSequence"])
            {
                StatusModeSequence = Convert.ToInt32(Request.QueryString["StatusModeSequence"]);
            }
            if (null != Request.QueryString["AMId"])
            {
                AM = Convert.ToInt32(Request.QueryString["AMId"]);
            }
            if (!IsPostBack)
            {
                GetSalesReport();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "disableCheckBox", "window.onload = disableCheckBox();", true);
            }
        }

        private void GetSalesReport()
        {
            //dtSales = objBuyingHouseController.GetBipl_Ikandi_MIS_ReportBAL(Years, FromWeek, ToWeek, ClientId, DateType, 1, StatusMode, StatusModeSequence, UnitId, BH, Convert.ToString(Session.SessionID),AM,DeptID,ParentDeptID);
            //gvSalesView.DataSource = dtSales.Tables[0];
            //gvSalesView.DataBind();

            //gvSalesView.Columns[3].Visible = Convert.ToInt32(hdnBH.Value) == 1 ? true : false;
        }

        private void GetDates()
        {
            HiddenField hdnFromDate = (HiddenField)gvSalesView.Rows[0].FindControl("hdnFromDate");
            HiddenField hdnToDate = (HiddenField)gvSalesView.Rows[gvSalesView.Rows.Count - 1].FindControl("hdnToDate");
            StartDate = Convert.ToDateTime(hdnFromDate.Value);
            EndDate = Convert.ToDateTime(hdnToDate.Value);
        }

        decimal TotalIkandiPrice = 0, TotalBiplPrice = 0, TotalFabricAndAccessoryCost_Sum = 0, TotalCMTValue = 0, TotalMinutes_Unstitch = 0;
        int TotalStyleNumber = 0, TotalQuantity = 0, TotalQuantity_Cut = 0, TotalQuantity_Stitch = 0, TotalQuantity_Unstitch = 0, TotalShippedQty = 0, TotalCutQty = 0, TotalActualShippedQty = 0;
        int TotalCTSLDiff = 0, TotalQuantity_Packed = 0, TotalSealCount = 0, TotalBIHCount = 0, TotalBIHSealCount = 0;
        protected void gvSalesView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblMonth = e.Row.FindControl("lblMonth") as Label;
                CheckBox chkMonth = e.Row.FindControl("chkMonth") as CheckBox;

                if (lblMonth.Text == "")
                {
                    chkMonth.Visible = false;
                }

                Label lblIkandiPrice = (Label)e.Row.FindControl("lblIkandiPrice");
                TotalIkandiPrice = Convert.ToDecimal(lblIkandiPrice.Text) > 0 ? TotalIkandiPrice + Convert.ToDecimal(lblIkandiPrice.Text) : TotalIkandiPrice;
                lblIkandiPrice.Text = Convert.ToDecimal(lblIkandiPrice.Text) > 0 ? "£ " + lblIkandiPrice.Text + " Million" : "";

                Label lblBiplPrice = (Label)e.Row.FindControl("lblBiplPrice");
                TotalBiplPrice = Convert.ToDecimal(lblBiplPrice.Text) > 0 ? TotalBiplPrice + Convert.ToDecimal(lblBiplPrice.Text) : TotalBiplPrice;
                lblBiplPrice.Text = Convert.ToDecimal(lblBiplPrice.Text) > 0 ? "₹ " + lblBiplPrice.Text + " Cr" : "";

                Label lblTotalFabricAndAccessoryCost = (Label)e.Row.FindControl("lblTotalFabricAndAccessoryCost");
                TotalFabricAndAccessoryCost_Sum = Convert.ToDecimal(lblTotalFabricAndAccessoryCost.Text) > 0 ? TotalFabricAndAccessoryCost_Sum + Convert.ToDecimal(lblTotalFabricAndAccessoryCost.Text) : TotalFabricAndAccessoryCost_Sum;
                lblTotalFabricAndAccessoryCost.Text = Convert.ToDecimal(lblTotalFabricAndAccessoryCost.Text) > 0 ? "₹ " + lblTotalFabricAndAccessoryCost.Text + " Cr" : "";

                Label lblTotalFabricAndAccessoryCostPer = (Label)e.Row.FindControl("lblTotalFabricAndAccessoryCostPer");
                if (lblTotalFabricAndAccessoryCost.Text != "" && lblBiplPrice.Text != "")
                {
                    lblTotalFabricAndAccessoryCostPer.Text = "(" + Convert.ToInt32(((Convert.ToDecimal(lblTotalFabricAndAccessoryCost.Text.Replace("₹ ", "").Replace(" Cr", "")) / Convert.ToDecimal(lblBiplPrice.Text.Replace("₹ ", "").Replace(" Cr", ""))) * 100)).ToString() + "%)";
                }

                Label lblCMTValue = (Label)e.Row.FindControl("lblCMTValue");
                TotalCMTValue = Convert.ToDecimal(lblCMTValue.Text) > 0 ? TotalCMTValue + Convert.ToDecimal(lblCMTValue.Text) : TotalCMTValue;
                lblCMTValue.Text = Convert.ToDecimal(lblCMTValue.Text) > 0 ? "₹ " + lblCMTValue.Text + " Cr" : "";

                Label lblCMTValuePer = (Label)e.Row.FindControl("lblCMTValuePer");
                if (lblCMTValue.Text != "" && lblBiplPrice.Text != "")
                {
                    lblCMTValuePer.Text = "(" + Convert.ToInt32(((Convert.ToDecimal(lblCMTValue.Text.Replace("₹ ", "").Replace(" Cr", "")) / Convert.ToDecimal(lblBiplPrice.Text.Replace("₹ ", "").Replace(" Cr", ""))) * 100)).ToString() + "%)";
                }

                Label lblBreakevenEfficiency = (Label)e.Row.FindControl("lblBreakevenEfficiency");
                if (Convert.ToDecimal(lblBreakevenEfficiency.Text) > 0)
                {
                    lblBreakevenEfficiency.Text = lblBreakevenEfficiency.Text + "%";
                }
                else
                {
                    lblBreakevenEfficiency.Text = "";
                }

                Label lblStyleNumber = (Label)e.Row.FindControl("lblStyleNumber");
                TotalStyleNumber = Convert.ToInt32(lblStyleNumber.Text) > 0 ? TotalStyleNumber + Convert.ToInt32(lblStyleNumber.Text) : TotalStyleNumber;

                Label lblSealCount = (Label)e.Row.FindControl("lblSealCount");
                TotalSealCount = Convert.ToInt32(lblSealCount.Text) > 0 ? TotalSealCount + Convert.ToInt32(lblSealCount.Text) : TotalSealCount;
                lblSealCount.Text = Convert.ToInt32(lblSealCount.Text) > 0 ? lblSealCount.Text : "";

                Label lblBIHCount = (Label)e.Row.FindControl("lblBIHCount");
                TotalBIHCount = Convert.ToInt32(lblBIHCount.Text) > 0 ? TotalBIHCount + Convert.ToInt32(lblBIHCount.Text) : TotalBIHCount;
                lblBIHCount.Text = Convert.ToInt32(lblBIHCount.Text) > 0 ? lblBIHCount.Text : "";

                Label lblBIHSealCount = (Label)e.Row.FindControl("lblBIHSealCount");
                TotalBIHSealCount = Convert.ToInt32(lblBIHSealCount.Text) > 0 ? TotalBIHSealCount + Convert.ToInt32(lblBIHSealCount.Text) : TotalBIHSealCount;
                lblBIHSealCount.Text = Convert.ToInt32(lblBIHSealCount.Text) > 0 ? lblBIHSealCount.Text : "";

                Label lblQuantity = (Label)e.Row.FindControl("lblQuantity");
                TotalQuantity = Convert.ToInt32(lblQuantity.Text) > 0 ? TotalQuantity + Convert.ToInt32(lblQuantity.Text) : TotalQuantity;
                lblQuantity.Text = Convert.ToInt32(lblQuantity.Text) > 0 ? lblQuantity.Text + " k" : "";

                Label lblQuantity_Stitch = (Label)e.Row.FindControl("lblQuantity_Stitch");
                TotalQuantity_Stitch = Convert.ToInt32(lblQuantity_Stitch.Text) > 0 ? TotalQuantity_Stitch + Convert.ToInt32(lblQuantity_Stitch.Text) : TotalQuantity_Stitch;
                lblQuantity_Stitch.Text = Convert.ToInt32(lblQuantity_Stitch.Text) > 0 ? lblQuantity_Stitch.Text + " k" : "";

                Label lblQuantity_Cut = (Label)e.Row.FindControl("lblQuantity_Cut");
                TotalQuantity_Cut = Convert.ToInt32(lblQuantity_Cut.Text) > 0 ? TotalQuantity_Cut + Convert.ToInt32(lblQuantity_Cut.Text) : TotalQuantity_Cut;
                lblQuantity_Cut.Text = Convert.ToInt32(lblQuantity_Cut.Text) > 0 ? lblQuantity_Cut.Text + " k" : "";

                Label lblQuantity_Packed = (Label)e.Row.FindControl("lblQuantity_Packed");
                TotalQuantity_Packed = Convert.ToInt32(lblQuantity_Packed.Text) > 0 ? TotalQuantity_Packed + Convert.ToInt32(lblQuantity_Packed.Text) : TotalQuantity_Packed;
                lblQuantity_Packed.Text = Convert.ToInt32(lblQuantity_Packed.Text) > 0 ? lblQuantity_Packed.Text + " k" : "";

                Label lblQuantity_Unstitch = (Label)e.Row.FindControl("lblQuantity_Unstitch");
                TotalQuantity_Unstitch = Convert.ToInt32(lblQuantity_Unstitch.Text) > 0 ? TotalQuantity_Unstitch + Convert.ToInt32(lblQuantity_Unstitch.Text) : TotalQuantity_Unstitch;
                lblQuantity_Unstitch.Text = Convert.ToInt32(lblQuantity_Unstitch.Text) > 0 ? lblQuantity_Unstitch.Text + " k" : "";

                Label lblShippedQty = (Label)e.Row.FindControl("lblShippedQty");
                TotalShippedQty = Convert.ToInt32(lblShippedQty.Text) > 0 ? TotalShippedQty + Convert.ToInt32(lblShippedQty.Text) : TotalShippedQty;
                lblShippedQty.Text = Convert.ToInt32(lblShippedQty.Text) > 0 ? lblShippedQty.Text + " k" : "";

                HiddenField hdnShippedQty = (HiddenField)e.Row.FindControl("hdnShippedQty");
                TotalActualShippedQty = Convert.ToInt32(hdnShippedQty.Value) > 0 ? TotalActualShippedQty + Convert.ToInt32(hdnShippedQty.Value) : TotalActualShippedQty;

                HiddenField hdnCutQty = (HiddenField)e.Row.FindControl("hdnCutQty");
                lblShippedQty.Text = lblShippedQty.Text == "" ? "0" : lblShippedQty.Text;
                TotalCutQty = Convert.ToInt32(hdnCutQty.Value) > 0 && Convert.ToInt32(lblShippedQty.Text.Replace(" k", "")) > 0 ? TotalCutQty + Convert.ToInt32(hdnCutQty.Value) : TotalCutQty;
                lblShippedQty.Text = lblShippedQty.Text == "0" ? "" : lblShippedQty.Text;

                Label lblCTSL = (Label)e.Row.FindControl("lblCTSL");
                lblCTSL.Text = Convert.ToDecimal(lblCTSL.Text) > 0 ? lblCTSL.Text + "%" : "";
                lblCTSL.Text = lblShippedQty.Text == "" ? "" : lblCTSL.Text;

                Label lblCTSLDiff = (Label)e.Row.FindControl("lblCTSLDiff");
                lblQuantity_Cut.Text = lblQuantity_Cut.Text == "" ? "0" : lblQuantity_Cut.Text;
                lblShippedQty.Text = lblShippedQty.Text == "" ? "0" : lblShippedQty.Text;
                lblCTSLDiff.Text = " (" + (Convert.ToInt32(lblQuantity_Cut.Text.Replace(" k", "")) - Convert.ToInt32(lblShippedQty.Text.Replace(" k", ""))).ToString() + " k)";
                lblQuantity_Cut.Text = lblQuantity_Cut.Text == "0" ? "" : lblQuantity_Cut.Text;
                lblShippedQty.Text = lblShippedQty.Text == "0" ? "" : lblShippedQty.Text;
                lblCTSLDiff.Visible = lblShippedQty.Text == "" ? false : true;
                TotalCTSLDiff = lblCTSLDiff.Visible == true ? TotalCTSLDiff + Convert.ToInt32(lblCTSLDiff.Text.Replace(" (", "").Replace(" k)", "")) : TotalCTSLDiff;

                Label lblMinutes_Unstitch = (Label)e.Row.FindControl("lblMinutes_Unstitch");
                TotalMinutes_Unstitch = Convert.ToDecimal(lblMinutes_Unstitch.Text) > 0 ? TotalMinutes_Unstitch + Convert.ToDecimal(lblMinutes_Unstitch.Text) : TotalMinutes_Unstitch;
                lblMinutes_Unstitch.Text = Convert.ToDecimal(lblMinutes_Unstitch.Text) > 0 ? Convert.ToInt32(lblMinutes_Unstitch.Text).ToString() + " L" : "";

                Label lblOB = (Label)e.Row.FindControl("lblOB");
                lblOB.Text = Convert.ToDecimal(lblOB.Text) > 0 ? " (" + Convert.ToInt32(lblOB.Text).ToString() + ")" : "";
            }

            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label lblTotalIkandiPrice = (Label)e.Row.FindControl("lblTotalIkandiPrice");
                lblTotalIkandiPrice.Text = TotalIkandiPrice > 0 ? "£ " + TotalIkandiPrice.ToString() + " Million" : "";

                Label lblTotalBiplPrice = (Label)e.Row.FindControl("lblTotalBiplPrice");
                lblTotalBiplPrice.Text = TotalBiplPrice > 0 ? "₹ " + TotalBiplPrice.ToString() + " Cr" : "";

                Label lblTotalFabricAndAccessoryCost_Sum = (Label)e.Row.FindControl("lblTotalFabricAndAccessoryCost_Sum");
                lblTotalFabricAndAccessoryCost_Sum.Text = TotalFabricAndAccessoryCost_Sum > 0 ? "₹ " + TotalFabricAndAccessoryCost_Sum.ToString() + " Cr" : "";

                Label lblTotalFabricAndAccessoryCost_SumPer = (Label)e.Row.FindControl("lblTotalFabricAndAccessoryCost_SumPer");
                if (lblTotalFabricAndAccessoryCost_Sum.Text != "" && lblTotalBiplPrice.Text != "")
                {
                    lblTotalFabricAndAccessoryCost_SumPer.Text = "(" + Convert.ToInt32(((Convert.ToDecimal(lblTotalFabricAndAccessoryCost_Sum.Text.Replace("₹ ", "").Replace(" Cr", "")) / Convert.ToDecimal(lblTotalBiplPrice.Text.Replace("₹ ", "").Replace(" Cr", ""))) * 100)).ToString() + "%)";
                }

                Label lblTotalCMTValue = (Label)e.Row.FindControl("lblTotalCMTValue");
                lblTotalCMTValue.Text = TotalCMTValue > 0 ? "₹ " + TotalCMTValue.ToString() + " Cr" : "";

                Label lblTotalCMTValuePer = (Label)e.Row.FindControl("lblTotalCMTValuePer");
                if (lblTotalCMTValue.Text != "" && lblTotalBiplPrice.Text != "")
                {
                    lblTotalCMTValuePer.Text = "(" + Convert.ToInt32(((Convert.ToDecimal(lblTotalCMTValue.Text.Replace("₹ ", "").Replace(" Cr", "")) / Convert.ToDecimal(lblTotalBiplPrice.Text.Replace("₹ ", "").Replace(" Cr", ""))) * 100)).ToString() + "%)";
                }

                Label lblTotalStyleNumber = (Label)e.Row.FindControl("lblTotalStyleNumber");
                lblTotalStyleNumber.Text = TotalStyleNumber > 0 ? TotalStyleNumber.ToString() : "";

                Label lblTotalSealCount = (Label)e.Row.FindControl("lblTotalSealCount");
                lblTotalSealCount.Text = TotalSealCount > 0 ? TotalSealCount.ToString() : "";

                Label lblTotalBIHCount = (Label)e.Row.FindControl("lblTotalBIHCount");
                lblTotalBIHCount.Text = TotalBIHCount > 0 ? TotalBIHCount.ToString() : "";

                Label lblTotalBIHSealCount = (Label)e.Row.FindControl("lblTotalBIHSealCount");
                lblTotalBIHSealCount.Text = TotalBIHSealCount > 0 ? TotalBIHSealCount.ToString() : "";

                Label lblTotalQuantity = (Label)e.Row.FindControl("lblTotalQuantity");
                lblTotalQuantity.Text = TotalQuantity > 0 ? TotalQuantity.ToString() + " k" : "";

                Label lblTotalQuantity_Cut = (Label)e.Row.FindControl("lblTotalQuantity_Cut");
                lblTotalQuantity_Cut.Text = TotalQuantity_Cut > 0 ? TotalQuantity_Cut.ToString() + " k" : "";

                Label lblTotalQuantity_Packed = (Label)e.Row.FindControl("lblTotalQuantity_Packed");
                lblTotalQuantity_Packed.Text = TotalQuantity_Packed > 0 ? TotalQuantity_Packed.ToString() + " k" : "";

                Label lblTotalQuantity_Stitch = (Label)e.Row.FindControl("lblTotalQuantity_Stitch");
                lblTotalQuantity_Stitch.Text = TotalQuantity_Stitch > 0 ? TotalQuantity_Stitch.ToString() + " k" : "";

                Label lblTotalQuantity_Unstitch = (Label)e.Row.FindControl("lblTotalQuantity_Unstitch");
                lblTotalQuantity_Unstitch.Text = TotalQuantity_Unstitch > 0 ? TotalQuantity_Unstitch.ToString() + " k" : "";

                Label lblTotalShippedQty = (Label)e.Row.FindControl("lblTotalShippedQty");
                lblTotalShippedQty.Text = TotalShippedQty > 0 ? TotalShippedQty.ToString() + " k" : "";

                Label lblTotalMinutes_Unstitch = (Label)e.Row.FindControl("lblTotalMinutes_Unstitch");
                lblTotalMinutes_Unstitch.Text = TotalMinutes_Unstitch > 0 ? Convert.ToInt32(TotalMinutes_Unstitch).ToString() + " L" : "";

                GetDates();
                DataTable dtBreakEvenEff = objBuyingHouseController.GetBiplTotalBreakEvenEffBAL(ClientId, DateType, StatusMode, StatusModeSequence, UnitId, BH, StartDate, EndDate, System.Web.HttpContext.Current.Session.SessionID,AM,DeptID);

                Label lblTotalAvgSAM = (Label)e.Row.FindControl("lblTotalAvgSAM");
                Label lblTotalOB = (Label)e.Row.FindControl("lblTotalOB");
                lblTotalAvgSAM.Text = Convert.ToInt32(dtBreakEvenEff.Rows[0]["AvgSAM"]) > 0 ? dtBreakEvenEff.Rows[0]["AvgSAM"].ToString() : "";
                lblTotalOB.Text = Convert.ToInt32(dtBreakEvenEff.Rows[0]["OB"]) > 0 ? " (" + dtBreakEvenEff.Rows[0]["OB"].ToString() + ")" : "";

                Label lblTotalBreakevenEfficiency = (Label)e.Row.FindControl("lblTotalBreakevenEfficiency");
                lblTotalBreakevenEfficiency.Text = Convert.ToInt32(dtBreakEvenEff.Rows[0]["BreakevenEfficiency"]) > 0 ? dtBreakEvenEff.Rows[0]["BreakevenEfficiency"].ToString() + " %" : "";

                Label lblTotalCTSL = (Label)e.Row.FindControl("lblTotalCTSL");
                if (TotalCutQty == 0)
                {
                    lblTotalCTSL.Text = "";
                }
                else
                {
                    lblTotalCTSL.Text = Convert.ToDecimal((((Convert.ToDecimal(TotalCutQty - TotalActualShippedQty)) / Convert.ToDecimal(TotalCutQty)) * 100)).ToString("#.#") + "%";
                }
                lblTotalCTSL.Text = lblTotalShippedQty.Text == "" ? "" : lblTotalCTSL.Text;

                Label lblTotalCTSLDiff = (Label)e.Row.FindControl("lblTotalCTSLDiff");
                lblTotalCTSLDiff.Text = TotalCTSLDiff > 0 ? " (" + Convert.ToInt32(TotalCTSLDiff).ToString() + " k)" : "";
            }
        }

        protected void gvSalesView_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                GridViewRow gvrow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);

                TableCell Cell = new TableCell();
                Cell.Text = "<table border='0' cellpadding='0' cellspacing='0' width='100%'>";
                Cell.Text += "<tr><td align='center' style='height:35px; background-color:#405D99; color:#FFFFFF;'>Sales Report</td></tr>";
                Cell.Text += "</table>";
                Cell.HorizontalAlign = HorizontalAlign.Center;
                Cell.Font.Bold = true;
                Cell.ColumnSpan = Convert.ToInt32(hdnBH.Value) == 1 ? 21 : 20;
                Cell.Font.Size = 12;
                gvrow.Cells.Add(Cell);

                gvSalesView.Controls[0].Controls.AddAt(0, gvrow);
            }

            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[0].ColumnSpan = 3;
                e.Row.Cells[1].Visible = false;
                e.Row.Cells[2].Visible = false;
                e.Row.Cells[0].Text = "<table border='0' cellpadding='0' cellspacing='0' width='100%'>";
                e.Row.Cells[0].Text += "<tr><td align='center' style='height:30px; background-color:#405D99; color:#FFFFFF;'>Total</td></tr>";
                e.Row.Cells[0].Text += "<tr><td style='height:1px; background-color:#FFFFFF;'></td></tr>";
                e.Row.Cells[0].Text += "<tr><td align='center' style='height:30px; background-color:#405D99; color:#FFFFFF;'>Total Based On Selection</td></tr>";
                e.Row.Cells[0].Text += "</table>";
                e.Row.Cells[0].HorizontalAlign = HorizontalAlign.Center;
                e.Row.Cells[0].Font.Size = 11;
                e.Row.Cells[0].Font.Bold = true;
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (gvSalesView.Rows.Count > 0)
            {
                objOrderController.DeleteSession(System.Web.HttpContext.Current.Session.SessionID);
                bool IschkDateRange = true;
                for (int i = 0; i < gvSalesView.Rows.Count; i++)
                {
                    CheckBox chkStyleNumber = (CheckBox)gvSalesView.Rows[i].FindControl("chkStyleNumber");
                    CheckBox chkSealCount = (CheckBox)gvSalesView.Rows[i].FindControl("chkSealCount");
                    CheckBox chkBIHCount = (CheckBox)gvSalesView.Rows[i].FindControl("chkBIHCount");
                    CheckBox chkBIHSealCount = (CheckBox)gvSalesView.Rows[i].FindControl("chkBIHSealCount");
                    if (chkStyleNumber.Checked || chkSealCount.Checked || chkBIHCount.Checked || chkBIHSealCount.Checked)
                    {
                        IschkDateRange = false;
                    }
                }

                if (IschkDateRange)
                {
                    for (int i = 0; i < gvSalesView.Rows.Count; i++)
                    {
                        CheckBox chkDateRange = (CheckBox)gvSalesView.Rows[i].FindControl("chkDateRange");
                        if (chkDateRange.Checked)
                        {
                            HiddenField hdnYear = (HiddenField)gvSalesView.Rows[i].FindControl("hdnYear");
                            HiddenField hdnMonth = (HiddenField)gvSalesView.Rows[i].FindControl("hdnMonth");
                            HiddenField hdnWeek = (HiddenField)gvSalesView.Rows[i].FindControl("hdnWeek");
                            if (hdnYear != null)
                            {
                                Year = Convert.ToInt32(hdnYear.Value);
                            }
                            if (hdnMonth != null)
                            {
                                Month = Convert.ToInt32(hdnMonth.Value);
                            }
                            if (hdnWeek != null)
                            {
                                Week = Convert.ToInt32(hdnWeek.Value);
                            }
                            objBuyingHouseController.InsertSalesView(Year, Month, Week, System.Web.HttpContext.Current.Session.SessionID);
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < gvSalesView.Rows.Count; i++)
                    {
                        CheckBox chkDateRange = (CheckBox)gvSalesView.Rows[i].FindControl("chkDateRange");
                        CheckBox chkStyleNumber = (CheckBox)gvSalesView.Rows[i].FindControl("chkStyleNumber");
                        CheckBox chkSealCount = (CheckBox)gvSalesView.Rows[i].FindControl("chkSealCount");
                        CheckBox chkBIHCount = (CheckBox)gvSalesView.Rows[i].FindControl("chkBIHCount");
                        CheckBox chkBIHSealCount = (CheckBox)gvSalesView.Rows[i].FindControl("chkBIHSealCount");

                        HiddenField hdnYear = (HiddenField)gvSalesView.Rows[i].FindControl("hdnYear");
                        HiddenField hdnMonth = (HiddenField)gvSalesView.Rows[i].FindControl("hdnMonth");
                        HiddenField hdnWeek = (HiddenField)gvSalesView.Rows[i].FindControl("hdnWeek");
                        HiddenField hdnFromDate = (HiddenField)gvSalesView.Rows[i].FindControl("hdnFromDate");
                        HiddenField hdnToDate = (HiddenField)gvSalesView.Rows[i].FindControl("hdnToDate");

                        if (chkSealCount.Checked)
                        {

                            if (hdnYear != null)
                            {
                                Year = Convert.ToInt32(hdnYear.Value);
                            }
                            if (hdnMonth != null)
                            {
                                Month = Convert.ToInt32(hdnMonth.Value);
                            }
                            if (hdnWeek != null)
                            {
                                Week = Convert.ToInt32(hdnWeek.Value);
                            }
                            objBuyingHouseController.InsertSalesView(Year, Month, Week, System.Web.HttpContext.Current.Session.SessionID);
                            objBuyingHouseController.InsertSalesView_Styles(Convert.ToDateTime(hdnFromDate.Value), Convert.ToDateTime(hdnToDate.Value), ClientId, DateType, StatusMode, StatusModeSequence, UnitId, BH, chkSealCount.Checked, false, false, System.Web.HttpContext.Current.Session.SessionID);
                        }
                        else if (chkBIHCount.Checked)
                        {
                            if (hdnYear != null)
                            {
                                Year = Convert.ToInt32(hdnYear.Value);
                            }
                            if (hdnMonth != null)
                            {
                                Month = Convert.ToInt32(hdnMonth.Value);
                            }
                            if (hdnWeek != null)
                            {
                                Week = Convert.ToInt32(hdnWeek.Value);
                            }
                            objBuyingHouseController.InsertSalesView(Year, Month, Week, System.Web.HttpContext.Current.Session.SessionID);
                            objBuyingHouseController.InsertSalesView_Styles(Convert.ToDateTime(hdnFromDate.Value), Convert.ToDateTime(hdnToDate.Value), ClientId, DateType, StatusMode, StatusModeSequence, UnitId, BH, false, chkBIHCount.Checked, false, System.Web.HttpContext.Current.Session.SessionID);
                        }
                        else if (chkBIHSealCount.Checked)
                        {
                            if (hdnYear != null)
                            {
                                Year = Convert.ToInt32(hdnYear.Value);
                            }
                            if (hdnMonth != null)
                            {
                                Month = Convert.ToInt32(hdnMonth.Value);
                            }
                            if (hdnWeek != null)
                            {
                                Week = Convert.ToInt32(hdnWeek.Value);
                            }
                            objBuyingHouseController.InsertSalesView(Year, Month, Week, System.Web.HttpContext.Current.Session.SessionID);
                            objBuyingHouseController.InsertSalesView_Styles(Convert.ToDateTime(hdnFromDate.Value), Convert.ToDateTime(hdnToDate.Value), ClientId, DateType, StatusMode, StatusModeSequence, UnitId, BH, false, false, chkBIHSealCount.Checked, System.Web.HttpContext.Current.Session.SessionID);
                        }
                        else if (chkStyleNumber.Checked)
                        {
                            if (hdnYear != null)
                            {
                                Year = Convert.ToInt32(hdnYear.Value);
                            }
                            if (hdnMonth != null)
                            {
                                Month = Convert.ToInt32(hdnMonth.Value);
                            }
                            if (hdnWeek != null)
                            {
                                Week = Convert.ToInt32(hdnWeek.Value);
                            }
                            objBuyingHouseController.InsertSalesView(Year, Month, Week, System.Web.HttpContext.Current.Session.SessionID);
                            objBuyingHouseController.InsertSalesView_Styles(Convert.ToDateTime(hdnFromDate.Value), Convert.ToDateTime(hdnToDate.Value), ClientId, DateType, StatusMode, StatusModeSequence, UnitId, BH, chkSealCount.Checked, chkBIHCount.Checked, chkBIHSealCount.Checked, System.Web.HttpContext.Current.Session.SessionID);
                        }
                    }
                }
            }
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "UpdateManageOrder", "UpdateManageOrder();", true);
        }
    }
}

