using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iKandi.BLL.Production;
using System.Data;
using System.Web.UI.HtmlControls;

namespace iKandi.Web.UserControls.Reports
{
    public partial class NewsLetter : System.Web.UI.UserControl
    {
        ProductionController objProductionController = new ProductionController();
        static int MonthDays;
        protected void Page_Load(object sender, EventArgs e)
        {
            int Year = DateTime.Now.Year;
            int Month = DateTime.Now.Month;
            MonthDays = DateTime.DaysInMonth(Year, Month);
            if (!IsPostBack)
            {
                GetNewsLetterHeader();
            }
        }

        private void GetNewsLetterHeader()
        {
            DataSet ds;
            ds = objProductionController.Get_ProductionDateOfMonth();
            DataTable dtNewsLetterHeader = ds.Tables[0];
            ViewState["dtNewsLetterHeader"] = dtNewsLetterHeader;
            DataTable dtNewLetterStyle = new DataTable();
            dtNewLetterStyle = ds.Tables[1];
            gvNewsLetterHeader.DataSource = dtNewLetterStyle;
            gvNewsLetterHeader.DataBind();
        }

        private void HideNewsLetterHeaderColumn()
        {
            int ColumnCount = gvNewsLetterHeader.Columns.Count;
            MonthDays = MonthDays + 1;
            if (MonthDays < ColumnCount)
            {
                for (int i = MonthDays - 1; i <= ColumnCount; i++)
                {
                    gvNewsLetterHeader.Columns[i].Visible = false;
                }
            }
            
        }

        protected void gvNewsLetterHeader_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            DataTable dtNewsLetterHeader = (DataTable)ViewState["dtNewsLetterHeader"];
            if (e.Row.RowType == DataControlRowType.Header)
            {
                Label lblDaysName1 = (Label)e.Row.FindControl("lblDaysName1");
                Label lblDayDisplay1 = (Label)e.Row.FindControl("lblDayDisplay1");
                Label lblSpecialDay1 = (Label)e.Row.FindControl("lblSpecialDay1");

                Label lblDaysName2 = (Label)e.Row.FindControl("lblDaysName2");
                Label lblDayDisplay2 = (Label)e.Row.FindControl("lblDayDisplay2");
                Label lblSpecialDay2 = (Label)e.Row.FindControl("lblSpecialDay2");

                Label lblDaysName3 = (Label)e.Row.FindControl("lblDaysName3");
                Label lblDayDisplay3 = (Label)e.Row.FindControl("lblDayDisplay3");
                Label lblSpecialDay3 = (Label)e.Row.FindControl("lblSpecialDay3");

                Label lblDaysName4 = (Label)e.Row.FindControl("lblDaysName4");
                Label lblDayDisplay4 = (Label)e.Row.FindControl("lblDayDisplay4");
                Label lblSpecialDay4 = (Label)e.Row.FindControl("lblSpecialDay4");

                Label lblDaysName5 = (Label)e.Row.FindControl("lblDaysName5");
                Label lblDayDisplay5 = (Label)e.Row.FindControl("lblDayDisplay5");
                Label lblSpecialDay5 = (Label)e.Row.FindControl("lblSpecialDay5");

                Label lblDaysName6 = (Label)e.Row.FindControl("lblDaysName6");
                Label lblDayDisplay6 = (Label)e.Row.FindControl("lblDayDisplay6");
                Label lblSpecialDay6 = (Label)e.Row.FindControl("lblSpecialDay6");

                Label lblDaysName7 = (Label)e.Row.FindControl("lblDaysName7");
                Label lblDayDisplay7 = (Label)e.Row.FindControl("lblDayDisplay7");
                Label lblSpecialDay7 = (Label)e.Row.FindControl("lblSpecialDay7");

                Label lblDaysName8 = (Label)e.Row.FindControl("lblDaysName8");
                Label lblDayDisplay8 = (Label)e.Row.FindControl("lblDayDisplay8");
                Label lblSpecialDay8 = (Label)e.Row.FindControl("lblSpecialDay8");

                Label lblDaysName9 = (Label)e.Row.FindControl("lblDaysName9");
                Label lblDayDisplay9 = (Label)e.Row.FindControl("lblDayDisplay9");
                Label lblSpecialDay9 = (Label)e.Row.FindControl("lblSpecialDay9");

                Label lblDaysName10 = (Label)e.Row.FindControl("lblDaysName10");
                Label lblDayDisplay10 = (Label)e.Row.FindControl("lblDayDisplay10");
                Label lblSpecialDay10 = (Label)e.Row.FindControl("lblSpecialDay10");

                Label lblDaysName11 = (Label)e.Row.FindControl("lblDaysName11");
                Label lblDayDisplay11 = (Label)e.Row.FindControl("lblDayDisplay11");
                Label lblSpecialDay11 = (Label)e.Row.FindControl("lblSpecialDay11");

                Label lblDaysName12 = (Label)e.Row.FindControl("lblDaysName12");
                Label lblDayDisplay12 = (Label)e.Row.FindControl("lblDayDisplay12");
                Label lblSpecialDay12 = (Label)e.Row.FindControl("lblSpecialDay12");

                Label lblDaysName13 = (Label)e.Row.FindControl("lblDaysName13");
                Label lblDayDisplay13 = (Label)e.Row.FindControl("lblDayDisplay13");
                Label lblSpecialDay13 = (Label)e.Row.FindControl("lblSpecialDay13");

                Label lblDaysName14 = (Label)e.Row.FindControl("lblDaysName14");
                Label lblDayDisplay14 = (Label)e.Row.FindControl("lblDayDisplay14");
                Label lblSpecialDay14 = (Label)e.Row.FindControl("lblSpecialDay14");

                Label lblDaysName15 = (Label)e.Row.FindControl("lblDaysName15");
                Label lblDayDisplay15 = (Label)e.Row.FindControl("lblDayDisplay15");
                Label lblSpecialDay15 = (Label)e.Row.FindControl("lblSpecialDay15");

                Label lblDaysName16 = (Label)e.Row.FindControl("lblDaysName16");
                Label lblDayDisplay16 = (Label)e.Row.FindControl("lblDayDisplay16");
                Label lblSpecialDay16 = (Label)e.Row.FindControl("lblSpecialDay16");

                Label lblDaysName17 = (Label)e.Row.FindControl("lblDaysName17");
                Label lblDayDisplay17 = (Label)e.Row.FindControl("lblDayDisplay17");
                Label lblSpecialDay17 = (Label)e.Row.FindControl("lblSpecialDay17");

                Label lblDaysName18 = (Label)e.Row.FindControl("lblDaysName18");
                Label lblDayDisplay18 = (Label)e.Row.FindControl("lblDayDisplay18");
                Label lblSpecialDay18 = (Label)e.Row.FindControl("lblSpecialDay18");

                Label lblDaysName19 = (Label)e.Row.FindControl("lblDaysName19");
                Label lblDayDisplay19 = (Label)e.Row.FindControl("lblDayDisplay19");
                Label lblSpecialDay19 = (Label)e.Row.FindControl("lblSpecialDay19");

                Label lblDaysName20 = (Label)e.Row.FindControl("lblDaysName20");
                Label lblDayDisplay20 = (Label)e.Row.FindControl("lblDayDisplay20");
                Label lblSpecialDay20 = (Label)e.Row.FindControl("lblSpecialDay20");

                Label lblDaysName21 = (Label)e.Row.FindControl("lblDaysName21");
                Label lblDayDisplay21 = (Label)e.Row.FindControl("lblDayDisplay21");
                Label lblSpecialDay21 = (Label)e.Row.FindControl("lblSpecialDay21");

                Label lblDaysName22 = (Label)e.Row.FindControl("lblDaysName22");
                Label lblDayDisplay22 = (Label)e.Row.FindControl("lblDayDisplay22");
                Label lblSpecialDay22 = (Label)e.Row.FindControl("lblSpecialDay22");

                Label lblDaysName23 = (Label)e.Row.FindControl("lblDaysName23");
                Label lblDayDisplay23 = (Label)e.Row.FindControl("lblDayDisplay23");
                Label lblSpecialDay23 = (Label)e.Row.FindControl("lblSpecialDay23");

                Label lblDaysName24 = (Label)e.Row.FindControl("lblDaysName24");
                Label lblDayDisplay24 = (Label)e.Row.FindControl("lblDayDisplay24");
                Label lblSpecialDay24 = (Label)e.Row.FindControl("lblSpecialDay24");

                Label lblDaysName25 = (Label)e.Row.FindControl("lblDaysName25");
                Label lblDayDisplay25 = (Label)e.Row.FindControl("lblDayDisplay25");
                Label lblSpecialDay25 = (Label)e.Row.FindControl("lblSpecialDay25");

                Label lblDaysName26 = (Label)e.Row.FindControl("lblDaysName26");
                Label lblDayDisplay26 = (Label)e.Row.FindControl("lblDayDisplay26");
                Label lblSpecialDay26 = (Label)e.Row.FindControl("lblSpecialDay26");

                Label lblDaysName27 = (Label)e.Row.FindControl("lblDaysName27");
                Label lblDayDisplay27 = (Label)e.Row.FindControl("lblDayDisplay27");
                Label lblSpecialDay27 = (Label)e.Row.FindControl("lblSpecialDay27");

                Label lblDaysName28 = (Label)e.Row.FindControl("lblDaysName28");
                Label lblDayDisplay28 = (Label)e.Row.FindControl("lblDayDisplay28");
                Label lblSpecialDay28 = (Label)e.Row.FindControl("lblSpecialDay28");

                Label lblDaysName29 = (Label)e.Row.FindControl("lblDaysName29");
                Label lblDayDisplay29 = (Label)e.Row.FindControl("lblDayDisplay29");
                Label lblSpecialDay29 = (Label)e.Row.FindControl("lblSpecialDay29");

                Label lblDaysName30 = (Label)e.Row.FindControl("lblDaysName30");
                Label lblDayDisplay30 = (Label)e.Row.FindControl("lblDayDisplay30");
                Label lblSpecialDay30 = (Label)e.Row.FindControl("lblSpecialDay30");

                Label lblDaysName31 = (Label)e.Row.FindControl("lblDaysName31");
                Label lblDayDisplay31 = (Label)e.Row.FindControl("lblDayDisplay31");
                Label lblSpecialDay31 = (Label)e.Row.FindControl("lblSpecialDay31");
                

                for(int irow = 0; irow < dtNewsLetterHeader.Rows.Count; irow++)
                {
                    if (irow == 0)
                    {
                        lblDaysName1.Text = dtNewsLetterHeader.Rows[irow]["DaysName"].ToString();
                        lblDayDisplay1.Text = dtNewsLetterHeader.Rows[irow]["DayDisplay"].ToString();
                        if (dtNewsLetterHeader.Rows[irow]["WrkHours"].ToString() != "")
                        {
                            lblSpecialDay1.Text = "(" + dtNewsLetterHeader.Rows[irow]["EventDesc"].ToString() + ")" + dtNewsLetterHeader.Rows[irow]["WrkHours"].ToString() + " Hrs";
                        }
                    }
                    if (irow == 1)
                    {
                        lblDaysName2.Text = dtNewsLetterHeader.Rows[irow]["DaysName"].ToString();
                        lblDayDisplay2.Text = dtNewsLetterHeader.Rows[irow]["DayDisplay"].ToString();
                        if (dtNewsLetterHeader.Rows[irow]["WrkHours"].ToString() != "")
                        {
                            lblSpecialDay2.Text = "(" + dtNewsLetterHeader.Rows[irow]["EventDesc"].ToString() + ")" + dtNewsLetterHeader.Rows[irow]["WrkHours"].ToString() + " Hrs";
                        }
                    }
                    if (irow == 2)
                    {
                        lblDaysName3.Text = dtNewsLetterHeader.Rows[irow]["DaysName"].ToString();
                        lblDayDisplay3.Text = dtNewsLetterHeader.Rows[irow]["DayDisplay"].ToString();
                        if (dtNewsLetterHeader.Rows[irow]["WrkHours"].ToString() != "")
                        {
                            lblSpecialDay3.Text = "(" + dtNewsLetterHeader.Rows[irow]["EventDesc"].ToString() + ")" + dtNewsLetterHeader.Rows[irow]["WrkHours"].ToString() + " Hrs";
                        }
                    }
                    if (irow == 3)
                    {
                        lblDaysName4.Text = dtNewsLetterHeader.Rows[irow]["DaysName"].ToString();
                        lblDayDisplay4.Text = dtNewsLetterHeader.Rows[irow]["DayDisplay"].ToString();
                        if (dtNewsLetterHeader.Rows[irow]["WrkHours"].ToString() != "")
                        {
                            lblSpecialDay4.Text = "(" + dtNewsLetterHeader.Rows[irow]["EventDesc"].ToString() + ")" + dtNewsLetterHeader.Rows[irow]["WrkHours"].ToString() + " Hrs";
                        }
                    }
                    if (irow == 4)
                    {
                        lblDaysName5.Text = dtNewsLetterHeader.Rows[irow]["DaysName"].ToString();
                        lblDayDisplay5.Text = dtNewsLetterHeader.Rows[irow]["DayDisplay"].ToString();
                        if (dtNewsLetterHeader.Rows[irow]["WrkHours"].ToString() != "")
                        {
                            lblSpecialDay5.Text = "(" + dtNewsLetterHeader.Rows[irow]["EventDesc"].ToString() + ")" + dtNewsLetterHeader.Rows[irow]["WrkHours"].ToString() + " Hrs";
                        }
                    }
                    if (irow == 5)
                    {
                        lblDaysName6.Text = dtNewsLetterHeader.Rows[irow]["DaysName"].ToString();
                        lblDayDisplay6.Text = dtNewsLetterHeader.Rows[irow]["DayDisplay"].ToString();
                        if (dtNewsLetterHeader.Rows[irow]["WrkHours"].ToString() != "")
                        {
                            lblSpecialDay6.Text = "(" + dtNewsLetterHeader.Rows[irow]["EventDesc"].ToString() + ")" + dtNewsLetterHeader.Rows[irow]["WrkHours"].ToString() + " Hrs";
                        }
                    }
                    if (irow == 6)
                    {
                        lblDaysName7.Text = dtNewsLetterHeader.Rows[irow]["DaysName"].ToString();
                        lblDayDisplay7.Text = dtNewsLetterHeader.Rows[irow]["DayDisplay"].ToString();
                        if (dtNewsLetterHeader.Rows[irow]["WrkHours"].ToString() != "")
                        {
                            lblSpecialDay7.Text = "(" + dtNewsLetterHeader.Rows[irow]["EventDesc"].ToString() + ")" + dtNewsLetterHeader.Rows[irow]["WrkHours"].ToString() + " Hrs";
                        }
                    }
                    if (irow == 7)
                    {
                        lblDaysName8.Text = dtNewsLetterHeader.Rows[irow]["DaysName"].ToString();
                        lblDayDisplay8.Text = dtNewsLetterHeader.Rows[irow]["DayDisplay"].ToString();
                        if (dtNewsLetterHeader.Rows[irow]["WrkHours"].ToString() != "")
                        {
                            lblSpecialDay8.Text = "(" + dtNewsLetterHeader.Rows[irow]["EventDesc"].ToString() + ")" + dtNewsLetterHeader.Rows[irow]["WrkHours"].ToString() + " Hrs";
                        }
                    }
                    if (irow == 8)
                    {
                        lblDaysName9.Text = dtNewsLetterHeader.Rows[irow]["DaysName"].ToString();
                        lblDayDisplay9.Text = dtNewsLetterHeader.Rows[irow]["DayDisplay"].ToString();
                        if (dtNewsLetterHeader.Rows[irow]["WrkHours"].ToString() != "")
                        {
                            lblSpecialDay9.Text = "(" + dtNewsLetterHeader.Rows[irow]["EventDesc"].ToString() + ")" + dtNewsLetterHeader.Rows[irow]["WrkHours"].ToString() + " Hrs";
                        }
                    }
                    if (irow == 9)
                    {
                        lblDaysName10.Text = dtNewsLetterHeader.Rows[irow]["DaysName"].ToString();
                        lblDayDisplay10.Text = dtNewsLetterHeader.Rows[irow]["DayDisplay"].ToString();
                        if (dtNewsLetterHeader.Rows[irow]["WrkHours"].ToString() != "")
                        {
                            lblSpecialDay10.Text = "(" + dtNewsLetterHeader.Rows[irow]["EventDesc"].ToString() + ")" + dtNewsLetterHeader.Rows[irow]["WrkHours"].ToString() + " Hrs";
                        }
                    }
                    if (irow == 10)
                    {
                        lblDaysName11.Text = dtNewsLetterHeader.Rows[irow]["DaysName"].ToString();
                        lblDayDisplay11.Text = dtNewsLetterHeader.Rows[irow]["DayDisplay"].ToString();
                        if (dtNewsLetterHeader.Rows[irow]["WrkHours"].ToString() != "")
                        {
                            lblSpecialDay11.Text = "(" + dtNewsLetterHeader.Rows[irow]["EventDesc"].ToString() + ")" + dtNewsLetterHeader.Rows[irow]["WrkHours"].ToString() + " Hrs";
                        }
                    }
                    if (irow == 11)
                    {
                        lblDaysName12.Text = dtNewsLetterHeader.Rows[irow]["DaysName"].ToString();
                        lblDayDisplay12.Text = dtNewsLetterHeader.Rows[irow]["DayDisplay"].ToString();
                        if (dtNewsLetterHeader.Rows[irow]["WrkHours"].ToString() != "")
                        {
                            lblSpecialDay12.Text = "(" + dtNewsLetterHeader.Rows[irow]["EventDesc"].ToString() + ")" + dtNewsLetterHeader.Rows[irow]["WrkHours"].ToString() + " Hrs";
                        }
                    }
                    if (irow == 12)
                    {
                        lblDaysName13.Text = dtNewsLetterHeader.Rows[irow]["DaysName"].ToString();
                        lblDayDisplay13.Text = dtNewsLetterHeader.Rows[irow]["DayDisplay"].ToString();
                        if (dtNewsLetterHeader.Rows[irow]["WrkHours"].ToString() != "")
                        {
                            lblSpecialDay13.Text = "(" + dtNewsLetterHeader.Rows[irow]["EventDesc"].ToString() + ")" + dtNewsLetterHeader.Rows[irow]["WrkHours"].ToString() + " Hrs";
                        }
                    }
                    if (irow == 13)
                    {
                        lblDaysName14.Text = dtNewsLetterHeader.Rows[irow]["DaysName"].ToString();
                        lblDayDisplay14.Text = dtNewsLetterHeader.Rows[irow]["DayDisplay"].ToString();
                        if (dtNewsLetterHeader.Rows[irow]["WrkHours"].ToString() != "")
                        {
                            lblSpecialDay14.Text = "(" + dtNewsLetterHeader.Rows[irow]["EventDesc"].ToString() + ")" + dtNewsLetterHeader.Rows[irow]["WrkHours"].ToString() + " Hrs";
                        }
                    }
                    if (irow == 14)
                    {
                        lblDaysName15.Text = dtNewsLetterHeader.Rows[irow]["DaysName"].ToString();
                        lblDayDisplay15.Text = dtNewsLetterHeader.Rows[irow]["DayDisplay"].ToString();
                        if (dtNewsLetterHeader.Rows[irow]["WrkHours"].ToString() != "")
                        {
                            lblSpecialDay15.Text = "(" + dtNewsLetterHeader.Rows[irow]["EventDesc"].ToString() + ")" + dtNewsLetterHeader.Rows[irow]["WrkHours"].ToString() + " Hrs";
                        }
                    }
                    if (irow == 15)
                    {
                        lblDaysName16.Text = dtNewsLetterHeader.Rows[irow]["DaysName"].ToString();
                        lblDayDisplay16.Text = dtNewsLetterHeader.Rows[irow]["DayDisplay"].ToString();
                        if (dtNewsLetterHeader.Rows[irow]["WrkHours"].ToString() != "")
                        {
                            lblSpecialDay16.Text = "(" + dtNewsLetterHeader.Rows[irow]["EventDesc"].ToString() + ")" + dtNewsLetterHeader.Rows[irow]["WrkHours"].ToString() + " Hrs";
                        }
                    }
                    if (irow == 16)
                    {
                        lblDaysName17.Text = dtNewsLetterHeader.Rows[irow]["DaysName"].ToString();
                        lblDayDisplay17.Text = dtNewsLetterHeader.Rows[irow]["DayDisplay"].ToString();
                        if (dtNewsLetterHeader.Rows[irow]["WrkHours"].ToString() != "")
                        {
                            lblSpecialDay17.Text = "(" + dtNewsLetterHeader.Rows[irow]["EventDesc"].ToString() + ")" + dtNewsLetterHeader.Rows[irow]["WrkHours"].ToString() + " Hrs";
                        }
                    }
                    if (irow == 17)
                    {
                        lblDaysName18.Text = dtNewsLetterHeader.Rows[irow]["DaysName"].ToString();
                        lblDayDisplay18.Text = dtNewsLetterHeader.Rows[irow]["DayDisplay"].ToString();
                        if (dtNewsLetterHeader.Rows[irow]["WrkHours"].ToString() != "")
                        {
                            lblSpecialDay18.Text = "(" + dtNewsLetterHeader.Rows[irow]["EventDesc"].ToString() + ")" + dtNewsLetterHeader.Rows[irow]["WrkHours"].ToString() + " Hrs";
                        }
                    }
                    if (irow == 18)
                    {
                        lblDaysName19.Text = dtNewsLetterHeader.Rows[irow]["DaysName"].ToString();
                        lblDayDisplay19.Text = dtNewsLetterHeader.Rows[irow]["DayDisplay"].ToString();
                        if (dtNewsLetterHeader.Rows[irow]["WrkHours"].ToString() != "")
                        {
                            lblSpecialDay19.Text = "(" + dtNewsLetterHeader.Rows[irow]["EventDesc"].ToString() + ")" + dtNewsLetterHeader.Rows[irow]["WrkHours"].ToString() + " Hrs";
                        }
                    }
                    if (irow == 19)
                    {
                        lblDaysName20.Text = dtNewsLetterHeader.Rows[irow]["DaysName"].ToString();
                        lblDayDisplay20.Text = dtNewsLetterHeader.Rows[irow]["DayDisplay"].ToString();
                        if (dtNewsLetterHeader.Rows[irow]["WrkHours"].ToString() != "")
                        {
                            lblSpecialDay20.Text = "(" + dtNewsLetterHeader.Rows[irow]["EventDesc"].ToString() + ")" + dtNewsLetterHeader.Rows[irow]["WrkHours"].ToString() + " Hrs";
                        }
                    }
                    if (irow == 20)
                    {
                        lblDaysName21.Text = dtNewsLetterHeader.Rows[irow]["DaysName"].ToString();
                        lblDayDisplay21.Text = dtNewsLetterHeader.Rows[irow]["DayDisplay"].ToString();
                        if (dtNewsLetterHeader.Rows[irow]["WrkHours"].ToString() != "")
                        {
                            lblSpecialDay21.Text = "(" + dtNewsLetterHeader.Rows[irow]["EventDesc"].ToString() + ")" + dtNewsLetterHeader.Rows[irow]["WrkHours"].ToString() + " Hrs";
                        }
                    }
                    if (irow == 21)
                    {
                        lblDaysName22.Text = dtNewsLetterHeader.Rows[irow]["DaysName"].ToString();
                        lblDayDisplay22.Text = dtNewsLetterHeader.Rows[irow]["DayDisplay"].ToString();
                        if (dtNewsLetterHeader.Rows[irow]["WrkHours"].ToString() != "")
                        {
                            lblSpecialDay22.Text = "(" + dtNewsLetterHeader.Rows[irow]["EventDesc"].ToString() + ")" + dtNewsLetterHeader.Rows[irow]["WrkHours"].ToString() + " Hrs";
                        }
                    }
                    if (irow == 22)
                    {
                        lblDaysName23.Text = dtNewsLetterHeader.Rows[irow]["DaysName"].ToString();
                        lblDayDisplay23.Text = dtNewsLetterHeader.Rows[irow]["DayDisplay"].ToString();
                        if (dtNewsLetterHeader.Rows[irow]["WrkHours"].ToString() != "")
                        {
                            lblSpecialDay23.Text = "(" + dtNewsLetterHeader.Rows[irow]["EventDesc"].ToString() + ")" + dtNewsLetterHeader.Rows[irow]["WrkHours"].ToString() + " Hrs";
                        }
                    }
                    if (irow == 23)
                    {
                        lblDaysName24.Text = dtNewsLetterHeader.Rows[irow]["DaysName"].ToString();
                        lblDayDisplay24.Text = dtNewsLetterHeader.Rows[irow]["DayDisplay"].ToString();
                        if (dtNewsLetterHeader.Rows[irow]["WrkHours"].ToString() != "")
                        {
                            lblSpecialDay24.Text = "(" + dtNewsLetterHeader.Rows[irow]["EventDesc"].ToString() + ")" + dtNewsLetterHeader.Rows[irow]["WrkHours"].ToString() + " Hrs";
                        }
                    }
                    if (irow == 24)
                    {
                        lblDaysName25.Text = dtNewsLetterHeader.Rows[irow]["DaysName"].ToString();
                        lblDayDisplay25.Text = dtNewsLetterHeader.Rows[irow]["DayDisplay"].ToString();
                        if (dtNewsLetterHeader.Rows[irow]["WrkHours"].ToString() != "")
                        {
                            lblSpecialDay25.Text = "(" + dtNewsLetterHeader.Rows[irow]["EventDesc"].ToString() + ")" + dtNewsLetterHeader.Rows[irow]["WrkHours"].ToString() + " Hrs";
                        }
                    }
                    if (irow == 25)
                    {
                        lblDaysName26.Text = dtNewsLetterHeader.Rows[irow]["DaysName"].ToString();
                        lblDayDisplay26.Text = dtNewsLetterHeader.Rows[irow]["DayDisplay"].ToString();
                        if (dtNewsLetterHeader.Rows[irow]["WrkHours"].ToString() != "")
                        {
                            lblSpecialDay26.Text = "(" + dtNewsLetterHeader.Rows[irow]["EventDesc"].ToString() + ")" + dtNewsLetterHeader.Rows[irow]["WrkHours"].ToString() + " Hrs";
                        }
                    }
                    if (irow == 26)
                    {
                        lblDaysName27.Text = dtNewsLetterHeader.Rows[irow]["DaysName"].ToString();
                        lblDayDisplay27.Text = dtNewsLetterHeader.Rows[irow]["DayDisplay"].ToString();
                        if (dtNewsLetterHeader.Rows[irow]["WrkHours"].ToString() != "")
                        {
                            lblSpecialDay27.Text = "(" + dtNewsLetterHeader.Rows[irow]["EventDesc"].ToString() + ")" + dtNewsLetterHeader.Rows[irow]["WrkHours"].ToString() + " Hrs";
                        }
                    }
                    if (irow == 27)
                    {
                        lblDaysName28.Text = dtNewsLetterHeader.Rows[irow]["DaysName"].ToString();
                        lblDayDisplay28.Text = dtNewsLetterHeader.Rows[irow]["DayDisplay"].ToString();
                        if (dtNewsLetterHeader.Rows[irow]["WrkHours"].ToString() != "")
                        {
                            lblSpecialDay28.Text = "(" + dtNewsLetterHeader.Rows[irow]["EventDesc"].ToString() + ")" + dtNewsLetterHeader.Rows[irow]["WrkHours"].ToString() + " Hrs";
                        }
                    }
                    if (irow == 28)
                    {
                        lblDaysName29.Text = dtNewsLetterHeader.Rows[irow]["DaysName"].ToString();
                        lblDayDisplay29.Text = dtNewsLetterHeader.Rows[irow]["DayDisplay"].ToString();
                        if (dtNewsLetterHeader.Rows[irow]["WrkHours"].ToString() != "")
                        {
                            lblSpecialDay29.Text = "(" + dtNewsLetterHeader.Rows[irow]["EventDesc"].ToString() + ")" + dtNewsLetterHeader.Rows[irow]["WrkHours"].ToString() + " Hrs";
                        }
                    }
                    if (irow == 29)
                    {
                        lblDaysName30.Text = dtNewsLetterHeader.Rows[irow]["DaysName"].ToString();
                        lblDayDisplay30.Text = dtNewsLetterHeader.Rows[irow]["DayDisplay"].ToString();
                        if (dtNewsLetterHeader.Rows[irow]["WrkHours"].ToString() != "")
                        {
                            lblSpecialDay30.Text = "(" + dtNewsLetterHeader.Rows[irow]["EventDesc"].ToString() + ")" + dtNewsLetterHeader.Rows[irow]["WrkHours"].ToString() + " Hrs";
                        }
                    }
                    if (irow == 30)
                    {
                        lblDaysName31.Text = dtNewsLetterHeader.Rows[irow]["DaysName"].ToString();
                        lblDayDisplay31.Text = dtNewsLetterHeader.Rows[irow]["DayDisplay"].ToString();
                        if (dtNewsLetterHeader.Rows[irow]["WrkHours"].ToString() != "")
                        {
                            lblSpecialDay31.Text = "(" + dtNewsLetterHeader.Rows[irow]["EventDesc"].ToString() + ")" + dtNewsLetterHeader.Rows[irow]["WrkHours"].ToString() + " Hrs";
                        }
                    }

                }
            }
        }
    }
}