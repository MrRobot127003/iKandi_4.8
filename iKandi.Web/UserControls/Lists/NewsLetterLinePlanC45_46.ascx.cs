using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using iKandi.BLL;
using iKandi.BLL.Production;
using iKandi.Common;
using iKandi.Web.Components;

namespace iKandi.Web.UserControls.Lists
{
    public partial class NewsLetterLinePlanC45_46 : System.Web.UI.UserControl
    {
        int UnitId, LineNo;
        DateTime MaxEndDate;
        NewsLetter objNewsLetter = new NewsLetter();
        ProductionController objProductionController = new ProductionController();
        string sQuery = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            UnitId = 11;
            if (!IsPostBack)
            {
                GetNewsLetterLinePlan();
                GetNewsLetterLinePlanSummary();
            }
        }

        private void GetNewsLetterLinePlan()
        {
            DataSet dsLinePlan = objProductionController.GetNewsLetterLinePlan(UnitId, 0, 1);
            DataTable dtLine = dsLinePlan.Tables[0];
            DataTable dtPlanDate = dsLinePlan.Tables[1];
            ViewState["dtPlanDate"] = dtPlanDate;
            if (dtLine.Rows.Count > 0)
            {
                gvNewsLetterLinePlan.DataSource = dtLine;
                gvNewsLetterLinePlan.DataBind();
            }

        }

        protected void gvNewsLetterLinePlan_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HiddenField hdnLineNo = (HiddenField)e.Row.FindControl("hdnLineNo");
                Label lblLineNo = (Label)e.Row.FindControl("lblLineNo");

                if (hdnLineNo != null)
                {
                    LineNo = Convert.ToInt32(hdnLineNo.Value);
                    if (LineNo == 0)
                    {
                        if (ViewState["dtPlanDate"] != null)
                        {
                            DataTable dtPlanDate = (DataTable)ViewState["dtPlanDate"];
                            if (dtPlanDate.Rows.Count > 0)
                            {
                                for (int i = 0; i < dtPlanDate.Rows.Count; i++)
                                {
                                    DateTime PlanDate = dtPlanDate.Rows[i]["PlanDate"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(dtPlanDate.Rows[i]["PlanDate"]);
                                    bool IsHoliday = dtPlanDate.Rows[i]["IsHoliday"] == DBNull.Value ? false : Convert.ToBoolean(dtPlanDate.Rows[i]["IsHoliday"]);
                                    MaxEndDate = PlanDate;
                                    if (LineNo == 0)
                                    {
                                        e.Row.Cells[i + 1].Text = PlanDate == DateTime.MinValue ? "" : PlanDate.ToString("dd-MMM");
                                        e.Row.Cells[i + 1].CssClass = "date";
                                        if (IsHoliday == true)
                                            e.Row.Cells[i + 1].CssClass = "IsHoliday";
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        lblLineNo.Text = "Line " + hdnLineNo.Value;
                        DataSet dsLinePlan = objProductionController.GetNewsLetterLinePlan(UnitId, LineNo, 2);
                        DataTable dtLinePlan = dsLinePlan.Tables[0];
                        sQuery = "";
                        int cellwidth = 0;
                        int Margin = 0;
                        int DateDiff = 0;
                        if (dtLinePlan.Rows.Count > 0)
                        {
                            e.Row.Cells[1].ColumnSpan = 30;
                            for (int icell = 1 + 1; icell <= 30; icell++)
                            {
                                e.Row.Cells[icell].Visible = false;
                            }

                            for (int irow = 0; irow < dtLinePlan.Rows.Count; irow++)
                            {
                                Margin = 0;
                                cellwidth = 47;
                                string colorCode = "";
                                DateTime StartDate = dtLinePlan.Rows[irow]["StartDate"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(dtLinePlan.Rows[irow]["StartDate"]);
                                DateTime EndDate = dtLinePlan.Rows[irow]["EndDate"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(dtLinePlan.Rows[irow]["EndDate"]);
                                string LinePlanFrameId = dtLinePlan.Rows[irow]["LinePlanFrameId"] == DBNull.Value ? "" : dtLinePlan.Rows[irow]["LinePlanFrameId"].ToString();
                                string StyleCode = dtLinePlan.Rows[irow]["StyleCode"].ToString();
                                int Quantity = dtLinePlan.Rows[irow]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtLinePlan.Rows[irow]["Quantity"]);
                                DateTime ExFactory = dtLinePlan.Rows[irow]["ExFactory"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(dtLinePlan.Rows[irow]["ExFactory"]);
                                string sExFactory = ExFactory == DateTime.MinValue ? "" : ExFactory.ToString("dd-MMM");
                                string SAM = dtLinePlan.Rows[irow]["SAM"].ToString();
                                string OB = dtLinePlan.Rows[irow]["OB"].ToString();
                                string SketchUrl = dtLinePlan.Rows[irow]["SketchUrl"].ToString();
                                if (irow == 0)
                                    colorCode = "#808080";
                                else if (irow == 1)
                                    colorCode = "#CD853F";
                                else if (irow == 2)
                                    colorCode = "#808000";
                                else if (irow == 3)
                                    colorCode = "#4169E1";
                                else if (irow == 4)
                                    colorCode = "#EE82EE";
                                else if (irow == 5)
                                    colorCode = "#ceb196";
                                else if (irow == 6)
                                    colorCode = "#5a9c45";
                                else if (irow == 7)
                                    colorCode = "#9c5a45";
                                else if (irow == 8)
                                    colorCode = "#697e82";

                                sQuery = sQuery + "<table cellpadding='0' cellspacing='0' frame='void'><tr>";
                                SketchUrl = SketchUrl == "" ? "" : "/Uploads/Style/" + SketchUrl;
                                string strQuantity = Quantity.ToString("#,##0");

                                if (EndDate.Date > MaxEndDate.Date)
                                    EndDate = MaxEndDate;
                                string datavalue = "<a href='#' title='" + SketchUrl + "' class='preview'><img src='" + SketchUrl + "' style='width:30px;height:30px;vertical-align:middle;' /></a> &nbsp; " + StyleCode + "&nbsp; Qty &nbsp;" + strQuantity + "&nbsp; OB &nbsp;" + OB + "&nbsp; SAM &nbsp;" + SAM + "&nbsp; EX. &nbsp;" + sExFactory;
                                string TitleTd = "&nbsp;" + StyleCode + "&nbsp; Qty :&nbsp;" + strQuantity + "&nbsp; OB :&nbsp;" + OB + "&nbsp; SAM :&nbsp;" + SAM + "&nbsp; EX.Fact : &nbsp;" + sExFactory;

                                if (StartDate.Date <= DateTime.Now.Date)
                                {
                                    StartDate = DateTime.Now.Date;
                                    DateDiff = (EndDate.Date - StartDate.Date).Days;
                                    cellwidth = cellwidth * (DateDiff + 1);
                                    sQuery = sQuery + "<td title='" + TitleTd + "' style='color:white; width:" + cellwidth + "px;text-overflow: ellipsis;overflow: hidden;display: block;white-space: nowrap;height: 30px;background:" + colorCode + "'>" + datavalue + "</td>";
                                    if (EndDate < MaxEndDate)
                                    {
                                        DateDiff = (MaxEndDate.Date - EndDate.Date).Days;

                                        for (int i = 0; i < DateDiff; i++)
                                        {
                                            sQuery = sQuery + "<td style='width:47px;'></td>";
                                        }
                                    }
                                    sQuery = sQuery + "</tr></table>";
                                }
                                else
                                {
                                    Margin = (StartDate.Date - DateTime.Now.Date).Days;
                                    for (int i = 0; i < Margin; i++)
                                    {
                                        sQuery = sQuery + "<td style='width:47px;'></td>";
                                    }

                                    DateDiff = (EndDate.Date - StartDate.Date).Days;
                                    cellwidth = cellwidth * (DateDiff + 1);
                                    sQuery = sQuery + "<td title='" + TitleTd + "' style='color:white; width:" + cellwidth + "px;text-overflow: ellipsis;overflow: hidden;display: block;white-space: nowrap;height: 30px;background:" + colorCode + "'>" + datavalue + "</td>";

                                    if (EndDate < MaxEndDate)
                                    {
                                        DateDiff = (MaxEndDate.Date - EndDate.Date).Days;
                                        for (int i = 0; i < DateDiff; i++)
                                        {
                                            sQuery = sQuery + "<td style='width:47px;'></td>";
                                        }
                                    }
                                    sQuery = sQuery + "</tr></table>";

                                }
                            }
                            e.Row.Cells[1].Text = sQuery;
                        }
                    }
                }

            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                if (ViewState["dtPlanDate"] != null)
                {
                    DataTable dtPlanDate = (DataTable)ViewState["dtPlanDate"];
                    if (dtPlanDate.Rows.Count > 0)
                    {
                        for (int i = 0; i < dtPlanDate.Rows.Count; i++)
                        {
                            DateTime PlanDate = dtPlanDate.Rows[i]["PlanDate"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(dtPlanDate.Rows[i]["PlanDate"]);
                            bool IsHoliday = dtPlanDate.Rows[i]["IsHoliday"] == DBNull.Value ? false : Convert.ToBoolean(dtPlanDate.Rows[i]["IsHoliday"]);

                            e.Row.Cells[i + 1].Text = PlanDate == DateTime.MinValue ? "" : PlanDate.ToString("dd-MMM");
                            e.Row.Cells[i + 1].CssClass = "date";

                            if (IsHoliday == true)
                                e.Row.Cells[i + 1].CssClass = "IsHoliday";
                        }
                    }
                }
            }
        }


        private void GetNewsLetterLinePlanSummary()
        {
            DataSet dsPlanSummary = objProductionController.GetNewsLetterLinePlanSummary(-1);
            DataTable dtInHousePlanedQty_47 = dsPlanSummary.Tables[0];
            DataTable dtInHousePlanedQty_C45_46 = dsPlanSummary.Tables[1];
            DataTable dtOutHousePlanedQty = dsPlanSummary.Tables[2];
            DataTable dtTotal = dsPlanSummary.Tables[3];
            DataTable dtUnPlanned = dsPlanSummary.Tables[4];
            string sDayStitch = "";
            sQuery = "";
            // for C 47
            if (dtInHousePlanedQty_47.Rows.Count > 0)
            {
                sQuery = sQuery + "<table class='item_list' cellpadding='0' cellspacing='0' border='1' style='width:1460px;margin: 0px auto;'><tr><td style='width:50px;'>Inhs Plnd C 47</td>";
                for (int j = 0; j < dtInHousePlanedQty_47.Rows.Count; j++)
                {
                    int DayStitch = dtInHousePlanedQty_47.Rows[j]["DayStitch"] == DBNull.Value ? 0 : Convert.ToInt32(dtInHousePlanedQty_47.Rows[j]["DayStitch"]);
                    if (DayStitch > 1000)
                        sDayStitch = Math.Round(Convert.ToDouble(DayStitch) / 1000, 1).ToString() + " k";
                    else
                        sDayStitch = DayStitch == 0 ? "" : DayStitch.ToString();

                    sQuery = sQuery + "<td style='width:46px;'>" + sDayStitch + "</td>";
                }
                sQuery = sQuery + "</tr></table>";
            }

            // for C45-46
            if (dtInHousePlanedQty_C45_46.Rows.Count > 0)
            {
                sQuery = sQuery + "<table class='item_list' cellpadding='0' cellspacing='0' border='1' style='width:1460px;margin: 0px auto;'><tr><td style='width:50px;'>Inhs Plnd C 45-46</td>";
                for (int j = 0; j < dtInHousePlanedQty_C45_46.Rows.Count; j++)
                {
                    int DayStitch = dtInHousePlanedQty_C45_46.Rows[j]["DayStitch"] == DBNull.Value ? 0 : Convert.ToInt32(dtInHousePlanedQty_C45_46.Rows[j]["DayStitch"]);
                    if (DayStitch > 1000)
                        sDayStitch = Math.Round(Convert.ToDouble(DayStitch) / 1000, 1).ToString() + " k";
                    else
                        sDayStitch = DayStitch == 0 ? "" : DayStitch.ToString();

                    sQuery = sQuery + "<td style='width:46px;'>" + sDayStitch + "</td>";
                }
                sQuery = sQuery + "</tr></table>";
            }

            // for Out House
            if (dtOutHousePlanedQty.Rows.Count > 0)
            {
                sQuery = sQuery + "<table class='item_list' cellpadding='0' cellspacing='0' border='1' style='width:1460px;margin: 0px auto;'><tr><td style='width:50px;'>Out House Plnd</td>";
                for (int j = 0; j < dtOutHousePlanedQty.Rows.Count; j++)
                {
                    int DayStitch = dtOutHousePlanedQty.Rows[j]["DayStitch"] == DBNull.Value ? 0 : Convert.ToInt32(dtOutHousePlanedQty.Rows[j]["DayStitch"]);
                    if (DayStitch > 1000)
                        sDayStitch = Math.Round(Convert.ToDouble(DayStitch) / 1000, 1).ToString() + " k";
                    else
                        sDayStitch = DayStitch == 0 ? "" : DayStitch.ToString();

                    sQuery = sQuery + "<td style='width:46px;'>" + sDayStitch + "</td>";
                }
                sQuery = sQuery + "</tr></table>";
            }

            //for Total
            if (dtTotal.Rows.Count > 0)
            {
                sQuery = sQuery + "<table class='item_list' cellpadding='0' cellspacing='0' border='1' style='width:1460px;margin: 0px auto;'><tr><td style='width:50px; color:black;'>Total</td>";
                for (int j = 0; j < dtTotal.Rows.Count; j++)
                {
                    int DayStitch = dtTotal.Rows[j]["DayStitch"] == DBNull.Value ? 0 : Convert.ToInt32(dtTotal.Rows[j]["DayStitch"]);
                    if (DayStitch > 1000)
                        sDayStitch = Math.Round(Convert.ToDouble(DayStitch) / 1000, 1).ToString() + " k";
                    else
                        sDayStitch = DayStitch == 0 ? "" : DayStitch.ToString();

                    sQuery = sQuery + "<td style='width:46px; color:black;'>" + sDayStitch + "</td>";
                }
                sQuery = sQuery + "</tr></table>";
            }
            //for UnPlanned
            if (dtUnPlanned.Rows.Count > 0)
            {
                string sUnPlannedQty = "";
                sQuery = sQuery + "<table class='item_list' cellpadding='0' cellspacing='0' border='1' style='width:1460px;margin: 0px auto;'><tr><td style='width:50px; color:black;'>Un Plnd Qty</td>";
                for (int j = 0; j < dtUnPlanned.Rows.Count; j++)
                {
                    int UnPlannedQty = dtUnPlanned.Rows[j]["UnPlannedQty"] == DBNull.Value ? 0 : Convert.ToInt32(dtUnPlanned.Rows[j]["UnPlannedQty"]);
                    if (UnPlannedQty > 1000)
                        sUnPlannedQty = Math.Round(Convert.ToDouble(UnPlannedQty) / 1000, 1).ToString() + " k";
                    else
                        sUnPlannedQty = UnPlannedQty == 0 ? "" : UnPlannedQty.ToString();

                    sQuery = sQuery + "<td style='width:46px; color:black;'>" + sUnPlannedQty + "</td>";
                }
                sQuery = sQuery + "</tr></table>";
            }

            lblStringQuery.Text = sQuery;
        }
    }
}