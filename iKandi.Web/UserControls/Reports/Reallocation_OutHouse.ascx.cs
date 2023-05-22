using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Collections.Generic;
using System.Text;
using iKandi.BLL;
using iKandi.Common;
using iKandi.Web.Components;

namespace iKandi.Web.UserControls.Reports
{
    public partial class Reallocation_OutHouse : System.Web.UI.UserControl
    {
        int foo_AgrredQty = 0;
        int foo_Pcsday = 0;
        int foo_CutIssueToday = 0;
        int foo_CutHouseTotal = 0;
        int foo_StitchedReceivedToday = 0;
        int foo_StichedReceivedTotal = 0;
        int foo_BalanceToStitch = 0;
        // int foo_OutHouseManpower = 0;
        DataTable dtFooter = new DataTable();
        QualityController objQuality = new QualityController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindOutHouseEmb();

            }

        }
        protected void BindOutHouseEmb()
        {
            DataSet Reallocation_OutHouse = this.objQuality.GetReallocation_OutHouse("Reallocation_OutHouse");
            DataTable dtReallocation_OutHouse = Reallocation_OutHouse.Tables[0];
            dtFooter = Reallocation_OutHouse.Tables[1];
            grdReallocation_OutHouse.DataSource = dtReallocation_OutHouse;
            grdReallocation_OutHouse.DataBind();
        }

        protected void frmReallocation_OutHouse_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblExDate = (Label)e.Row.FindControl("lblExDate");
                HiddenField hdnBgColor = (HiddenField)e.Row.FindControl("hdnBgColor");
                TableCell rowCell = (TableCell)lblExDate.Parent;

                HiddenField hdnImgStyle = (HiddenField)e.Row.FindControl("hdnImgStyle");
                HtmlImage imgStyle = (HtmlImage)e.Row.FindControl("imgStyle");
                HiddenField hdnCutIssueTotal = (HiddenField)e.Row.FindControl("hdnCutIssueTotal");

                HtmlTableCell tdCutIssueTotal = (HtmlTableCell)e.Row.FindControl("tdCutIssueTotal");
                if (hdnCutIssueTotal.Value == "1")
                {

                    tdCutIssueTotal.Style.Add("background-color", "#FF0000");
                }
                // HtmlAnchor imgStyleHyper = (HtmlAnchor)e.Row.FindControl("imgStyleHyper");
                imgStyle.Src = "/uploads/style/thumb-" + hdnImgStyle.Value;
                // imgStyleHyper.Title = "/uploads/style/thumb-" + hdnImgStyle.Value;

                if (hdnBgColor.Value != "1")
                {
                    rowCell.Style["background"] = "green";
                }
                else
                {
                    rowCell.Style["background"] = "red";
                }

                string AgrredQty = DataBinder.Eval(e.Row.DataItem, "AgrredQty").ToString();
                if (AgrredQty == "")
                {
                    AgrredQty = "0";
                }
                else
                {
                    AgrredQty = AgrredQty.ToString();
                }
                foo_AgrredQty = foo_AgrredQty + Convert.ToInt32(AgrredQty);


                string PcsPerDay = DataBinder.Eval(e.Row.DataItem, "PcsPerDay").ToString();
                if (PcsPerDay == "")
                {
                    PcsPerDay = "0";
                }
                else
                {
                    PcsPerDay = PcsPerDay.ToString();
                }
                foo_Pcsday = foo_Pcsday + Convert.ToInt32(PcsPerDay);

                string CutIssueToday = DataBinder.Eval(e.Row.DataItem, "CutIssueToday").ToString();
                if (CutIssueToday == "")
                {
                    CutIssueToday = "0";
                }
                else
                {
                    CutIssueToday = CutIssueToday.ToString();
                }
                foo_CutIssueToday = foo_CutIssueToday + Convert.ToInt32(CutIssueToday);


                string CutHouseTotal = DataBinder.Eval(e.Row.DataItem, "CutHouseTotal").ToString();
                if (CutHouseTotal == "")
                {
                    CutHouseTotal = "0";
                }
                else
                {
                    CutHouseTotal = CutHouseTotal.ToString();
                }
                foo_CutHouseTotal = foo_CutHouseTotal + Convert.ToInt32(CutHouseTotal);

                string StitchedReceivedToday = DataBinder.Eval(e.Row.DataItem, "StitchedReceivedToday").ToString();
                if (StitchedReceivedToday == "")
                {
                    StitchedReceivedToday = "0";
                }
                else
                {
                    StitchedReceivedToday = StitchedReceivedToday.ToString();
                }
                foo_StitchedReceivedToday = foo_StitchedReceivedToday + Convert.ToInt32(StitchedReceivedToday);

                string StichedReceivedTotal = DataBinder.Eval(e.Row.DataItem, "StichedReceivedTotal").ToString();
                if (StichedReceivedTotal == "")
                {
                    StichedReceivedTotal = "0";
                }
                else
                {
                    StichedReceivedTotal = StichedReceivedTotal.ToString();
                }
                foo_StichedReceivedTotal = foo_StichedReceivedTotal + Convert.ToInt32(StichedReceivedTotal);


                string BalanceToStitch = DataBinder.Eval(e.Row.DataItem, "BalanceToStitch").ToString();
                if (BalanceToStitch == "")
                {
                    BalanceToStitch = "0";
                }
                else
                {
                    BalanceToStitch = BalanceToStitch.ToString();
                }
                foo_BalanceToStitch = foo_BalanceToStitch + Convert.ToInt32(BalanceToStitch);

                string OutHouseManpower = DataBinder.Eval(e.Row.DataItem, "OutHouseManpower").ToString();
                if (OutHouseManpower == "")
                {
                    OutHouseManpower = "0";
                }
                else
                {
                    OutHouseManpower = OutHouseManpower.ToString();
                }
                //  foo_OutHouseManpower = foo_OutHouseManpower + Convert.ToInt32(OutHouseManpower);




            }

            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label lblfoo_AgrredQty = (Label)e.Row.FindControl("lblfoo_AgrredQty");
                Label lblfoo_Pcsday = (Label)e.Row.FindControl("lblfoo_Pcsday");
                Label lblfoo_CutIssueToday = (Label)e.Row.FindControl("lblfoo_CutIssueToday");
                Label lblfoo_CutHouseTotal = (Label)e.Row.FindControl("lblfoo_CutHouseTotal");
                Label lblfoo_StitchedReceivedToday = (Label)e.Row.FindControl("lblfoo_StitchedReceivedToday");
                Label lblfoo_StichedReceivedTotal = (Label)e.Row.FindControl("lblfoo_StichedReceivedTotal");
                Label lblfoo_BalanceToStitch = (Label)e.Row.FindControl("lblfoo_BalanceToStitch");
                // Label lblfoo_OutHouseManpower = (Label)e.Row.FindControl("lblfoo_OutHouseManpower");
                Label lblfoo_TotalMachine = (Label)e.Row.FindControl("lblfoo_TotalMachine");

                lblfoo_AgrredQty.Text = foo_AgrredQty.ToString() == "0" ? "" : String.Format("{0:#,##0}", Convert.ToInt32(foo_AgrredQty.ToString()));
                lblfoo_Pcsday.Text = foo_Pcsday.ToString() == "0" ? "" : String.Format("{0:#,##0}", Convert.ToInt32(foo_Pcsday.ToString()));
                lblfoo_CutIssueToday.Text = foo_CutIssueToday.ToString() == "0" ? "" : String.Format("{0:#,##0}", Convert.ToInt32(foo_CutIssueToday.ToString()));
                lblfoo_CutHouseTotal.Text = foo_CutHouseTotal.ToString() == "0" ? "" : String.Format("{0:#,##0}", Convert.ToInt32(foo_CutHouseTotal.ToString()));
                lblfoo_StitchedReceivedToday.Text = foo_StitchedReceivedToday.ToString() == "0" ? "" : String.Format("{0:#,##0}", Convert.ToInt32(foo_StitchedReceivedToday.ToString()));
                lblfoo_StichedReceivedTotal.Text = foo_StichedReceivedTotal.ToString() == "0" ? "" : String.Format("{0:#,##0}", Convert.ToInt32(foo_StichedReceivedTotal.ToString()));
                lblfoo_BalanceToStitch.Text = foo_BalanceToStitch.ToString() == "0" ? "" : String.Format("{0:#,##0}", Convert.ToInt32(foo_BalanceToStitch.ToString()));
                // lblfoo_OutHouseManpower.Text = foo_OutHouseManpower.ToString() == "0" ? "" : String.Format("{0:#,##0}", Convert.ToInt32(foo_OutHouseManpower.ToString()));



                if (dtFooter.Rows.Count > 0)
                {
                    lblfoo_TotalMachine.Text = dtFooter.Rows[0]["NumberOfMachines"].ToString() == "0" ? "" : String.Format("{0:#,##0}", Convert.ToInt32(dtFooter.Rows[0]["NumberOfMachines"].ToString()));

                }
                e.Row.Cells[0].ColumnSpan = 6;
                e.Row.Cells[1].Visible = false;
                e.Row.Cells[2].Visible = false;
                e.Row.Cells[3].Visible = false;
                e.Row.Cells[4].Visible = false;
                e.Row.Cells[5].Visible = false;
                // e.Row.Cells[6].Visible = false;

            }
        }
    }
}