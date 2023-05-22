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
    public partial class frmPoUploadPendingBreakDown : System.Web.UI.UserControl
    {

        AdminController objadmin = new AdminController();
       


        public int POCount
        {
            get;
            set;
        }

        public int PONextFiveWeek
        {
            get;
            set;
        }
        public int exfactory
        {
            get;
            set;
        }
        public int PendingTotal
        {
            get;
            set;
        }
        public int PONext11WeekToEnd
        {
            get;
            set;
        }

        public int TopPndgSent
        {
            get;
            set;
        }

        public int TopPndgAppr
        {
            get;
            set;
        }
        public int AvgTopApprOne
        {
            get;
            set;
        }
        public int TopSendgSentWeekBef
        {
            get;
            set;
        }
        public int TopAprvdBtMDA
        {
            get;
            set;
        }

        int Count=0;
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            bindHeader();
            GridViewRow grdPoUploadPendingBreakDownrow = grdPoUploadPendingBreakDown.Rows[(grdPoUploadPendingBreakDown.Rows.Count) - 1];
            // grdPoUploadPendingBreakDownrow.BackColor = System.Drawing.Color.FromName("#FFF0A5");
            grdPoUploadPendingBreakDownrow.CssClass = "frmPOUPload";
            grdPoUploadPendingBreakDownrow.Font.Bold = true;
            //updated code by bharat 12-feb
            //Label POCount = grdPoUploadPendingBreakDownrow.FindControl("POCount") as Label;
           //end
        }

        protected void bindHeader()
        {
            // dsMiddle = objadmin.GetHeaderPOUploadPendingMiddle();           
            ds = objadmin.GetHeaderPOUploadPending();
            if (grdPoUploadPendingBreakDown.Columns.Count > 0)
            {
                grdPoUploadPendingBreakDown.Columns.Clear();

            }

            TemplateField AM = new TemplateField();
            //AM.HeaderText = "AM";
            AM.ItemTemplate = new iKandi.Common.GridViewTemplate("label", "AccountManagerName", "AccountManagerName");
            grdPoUploadPendingBreakDown.Columns.Insert(0, AM);
            AM.HeaderStyle.Width = 100;

            TemplateField PrevPendPO = new TemplateField();
           // PrevPendPO.HeaderText = "Prev PO";
            PrevPendPO.ItemTemplate = new iKandi.Common.GridViewTemplate("label", "POCount", "POCount");
            PrevPendPO.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            grdPoUploadPendingBreakDown.Columns.Insert(1, PrevPendPO);
            PrevPendPO.HeaderStyle.Width = 40;

            TemplateField FiveWeekPend = new TemplateField();
           // FiveWeekPend.HeaderText = "Today + 5 Wk";
            FiveWeekPend.ItemTemplate = new iKandi.Common.GridViewTemplate("label", "PONextFiveWeek", "PONextFiveWeek");
            FiveWeekPend.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            grdPoUploadPendingBreakDown.Columns.Insert(2, FiveWeekPend);
            FiveWeekPend.HeaderStyle.Width = 40;

             Count = Convert.ToInt32(ds.Tables[1].Rows.Count) - 1;
            if (Convert.ToInt32(ds.Tables[1].Rows.Count) > 0)
            {
                for (int i = 0; i <= Count; i++)
                {
                    TemplateField Exfactory = new TemplateField();
                    Exfactory.HeaderText = Convert.ToString(ds.Tables[1].Rows[i]["Exfactory"]);
                    Exfactory.ItemTemplate = new iKandi.Common.GridViewTemplate("label", "Exfactory" + Convert.ToString(ds.Tables[1].Rows[i]["Exfactory"]), "Exfactory" + Convert.ToString(ds.Tables[1].Rows[i]["Exfactory"]));
                    // Exfactory.ItemStyle.CssClass = "accorforstyle14";
                    //CN.ItemStyle.Width = 80;
                    Exfactory.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                    grdPoUploadPendingBreakDown.Columns.Insert(i + 3, Exfactory);
                    Exfactory.HeaderStyle.Width = 40;
                }

            }

            TemplateField ElevenWeekEnd = new TemplateField();
          //  ElevenWeekEnd.HeaderText = "11 Wk Till End";
            ElevenWeekEnd.ItemTemplate = new iKandi.Common.GridViewTemplate("label", "PONext11WeekToEnd", "PONext11WeekToEnd");
            ElevenWeekEnd.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            grdPoUploadPendingBreakDown.Columns.Insert(Count + 4, ElevenWeekEnd);
            ElevenWeekEnd.HeaderStyle.Width = 50;


            TemplateField PendTot = new TemplateField();
           // PendTot.HeaderText = "Total";
            PendTot.ItemTemplate = new iKandi.Common.GridViewTemplate("label", "PendingTotal", "PendingTotal");
            PendTot.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            grdPoUploadPendingBreakDown.Columns.Insert(Count + 5, PendTot);
            PendTot.HeaderStyle.Width = 50;

            TemplateField AveragePOUploadtime = new TemplateField();
            // PendTot.HeaderText = "Total";
            AveragePOUploadtime.ItemTemplate = new iKandi.Common.GridViewTemplate("label", "AveragePOUploadtime", "AveragePOUploadtime");
            AveragePOUploadtime.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            grdPoUploadPendingBreakDown.Columns.Insert(Count + 6, AveragePOUploadtime);
            PendTot.HeaderStyle.Width = 50;


            //------------Top Summery Merge-----------------------//
            TemplateField TopPndgSentCount = new TemplateField();
           // TopPndgSentCount.HeaderText = "TOP Pndg to Sent";
            TopPndgSentCount.ItemTemplate = new iKandi.Common.GridViewTemplate("label", "TopPndgSentCount", "TopPndgSentCount");
            TopPndgSentCount.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            grdPoUploadPendingBreakDown.Columns.Insert(Count + 7, TopPndgSentCount);
            TopPndgSentCount.HeaderStyle.Width = 80;

            TemplateField TopSentRptPenCount = new TemplateField();
           // TopSentRptPenCount.HeaderText = "TOP Pndg to Sent";
            TopSentRptPenCount.ItemTemplate = new iKandi.Common.GridViewTemplate("label", "TopSentRptPenCount", "TopSentRptPenCount");
            TopSentRptPenCount.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            grdPoUploadPendingBreakDown.Columns.Insert(Count + 8, TopSentRptPenCount);
            TopSentRptPenCount.HeaderStyle.Width = 80;


          // update code by bharat on 28-feb
            TemplateField TopPndgCount = new TemplateField();
          //  TopPndgAppr.HeaderText = "TOP Pndg Approval";
            TopPndgCount.ItemTemplate = new iKandi.Common.GridViewTemplate("label", "TopPndgCount", "TopPndgCount");
            TopPndgCount.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            grdPoUploadPendingBreakDown.Columns.Insert(Count + 9, TopPndgCount);
            TopPndgCount.HeaderStyle.Width = 80;

            TemplateField TopPndgTestRPTPNDGCount = new TemplateField();
            //  TopPndgAppr.HeaderText = "TOP Pndg Approval";
            TopPndgTestRPTPNDGCount.ItemTemplate = new iKandi.Common.GridViewTemplate("label", "TopPndgTestRPTPNDGCount", "TopPndgTestRPTPNDGCount");
            TopPndgTestRPTPNDGCount.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            grdPoUploadPendingBreakDown.Columns.Insert(Count + 10, TopPndgTestRPTPNDGCount);
            TopPndgTestRPTPNDGCount.HeaderStyle.Width = 80;

            //End
            //updated code by bharat 12-feb
            TemplateField AvgTopApprOne_1Month = new TemplateField();
           // AvgTopApprOne.HeaderText = "Avg TOP Approval Days 1M (3M)";
            AvgTopApprOne_1Month.ItemTemplate = new iKandi.Common.GridViewTemplate("label", "AvgTopApprOne_1Month", "AvgTopApprOne_1Month");
            AvgTopApprOne_1Month.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            grdPoUploadPendingBreakDown.Columns.Insert(Count + 11, AvgTopApprOne_1Month);
            AvgTopApprOne_1Month.HeaderStyle.Width = 80;

            TemplateField AvgTopApprOne_3Month = new TemplateField();
            // AvgTopApprOne.HeaderText = "Avg TOP Approval Days 1M (3M)";
            AvgTopApprOne_3Month.ItemTemplate = new iKandi.Common.GridViewTemplate("label", "AvgTopApprOne_3Month", "AvgTopApprOne_3Month");
            AvgTopApprOne_3Month.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            grdPoUploadPendingBreakDown.Columns.Insert(Count + 12, AvgTopApprOne_3Month);
            AvgTopApprOne_3Month.HeaderStyle.Width = 80;


            TemplateField TopSendgSentWeekBef_1Month = new TemplateField();
           // TopSendgSentWeekBef.HeaderText = "TOP sendg Week Befr. Ex 1M (3M)";
            TopSendgSentWeekBef_1Month.ItemTemplate = new iKandi.Common.GridViewTemplate("label", "TopSendgSentWeekBef_1Month", "TopSendgSentWeekBef_1Month");
            TopSendgSentWeekBef_1Month.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            grdPoUploadPendingBreakDown.Columns.Insert(Count + 13, TopSendgSentWeekBef_1Month);
            TopSendgSentWeekBef_1Month.HeaderStyle.Width = 80;

            TemplateField TopSendgSentWeekBef_3Month = new TemplateField();
            // TopSendgSentWeekBef.HeaderText = "TOP sendg Week Befr. Ex 1M (3M)";
            TopSendgSentWeekBef_3Month.ItemTemplate = new iKandi.Common.GridViewTemplate("label", "TopSendgSentWeekBef_3Month", "TopSendgSentWeekBef_3Month");
            TopSendgSentWeekBef_3Month.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            grdPoUploadPendingBreakDown.Columns.Insert(Count + 14, TopSendgSentWeekBef_3Month);
            TopSendgSentWeekBef_3Month.HeaderStyle.Width = 80;

            //end
            TemplateField TopAprvdBtMDA = new TemplateField();
            //TopAprvdBtMDA.HeaderText = "TOP aprd but MDA Pndg Cnt ( ASOS)";
            TopAprvdBtMDA.ItemTemplate = new iKandi.Common.GridViewTemplate("label", "TopAprvdBtMDA", "TopAprvdBtMDA");
            TopAprvdBtMDA.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            TopAprvdBtMDA.ItemStyle.CssClass = "t1";
            grdPoUploadPendingBreakDown.Columns.Insert(Count + 15, TopAprvdBtMDA);
            TopAprvdBtMDA.HeaderStyle.Width = 80;
            //---------------End Of TOP Summery Header-------------//


            grdPoUploadPendingBreakDown.DataSource = ds.Tables[0];
            grdPoUploadPendingBreakDown.DataBind();
        }

        protected void grdPoUploadPendingBreakDown_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                GridViewRow headerRow1 = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
                GridViewRow headerRow2 = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
                GridViewRow headerRow3 = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
                headerRow1.Attributes.Add("class", "header4");
                headerRow2.Attributes.Add("class", "header5");
                headerRow3.Attributes.Add("class", "header6");

                TableCell HeaderCell = new TableCell();
                Count = Convert.ToInt32(ds.Tables[1].Rows.Count) - 1;
                HeaderCell = new TableCell();
                HeaderCell.Text = "AM";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.RowSpan = 3;
                HeaderCell.Width = 100;
                headerRow1.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = " PO Upload Track Report (Pending PO Contract) <span style='color:#c7c5c5;' > (For ref. Review <b style='font-size:11px'>BuyerPOPendingReports</b> excel) </span>";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.ColumnSpan = Count+6;
                headerRow1.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "TOP Summary Report <span style='color:#c7c5c5;' > (For ref. Review <b style='font-size:11px'>TOP Reports</b> excel) </span>";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.ColumnSpan = 10;
                headerRow1.Cells.Add(HeaderCell);


                //-------------second Row-----------------------

                HeaderCell = new TableCell();
                HeaderCell.Text = "Prev PO";
                HeaderCell.Width = 40;
                HeaderCell.RowSpan = 2;
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Today + 5 Wk";
                HeaderCell.Width = 40;
                HeaderCell.RowSpan = 2;
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow2.Cells.Add(HeaderCell);

                //=============Loop of header-----------------
                   
                   if (Convert.ToInt32(ds.Tables[1].Rows.Count) > 0)
                   {
                       for (int i = 0; i <= Count; i++)
                       {
                           HeaderCell = new TableCell();
                           HeaderCell.Text = Convert.ToString(ds.Tables[1].Rows[i]["Exfactory"]);
                           HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                           HeaderCell.Width = 40;
                           HeaderCell.RowSpan = 2;
                           headerRow2.Cells.Add(HeaderCell);
                       }
                   }
                //-------------End Of Header-------------

                HeaderCell = new TableCell();
                HeaderCell.Text = "11 Wk Till End";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Width = 50;
                HeaderCell.RowSpan = 2;
                headerRow2.Cells.Add(HeaderCell);


                HeaderCell = new TableCell();
                HeaderCell.Text = "Total";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Width = 50;
                HeaderCell.RowSpan = 2;
                headerRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Avg.PO Upld(Wk)";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Width = 65;
                HeaderCell.RowSpan = 2;
                headerRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "TOP Pndg To Sent";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Width = 80;
                HeaderCell.ColumnSpan = 2;
                headerRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "TOP Pndg Approval";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Width = 80;
                HeaderCell.ColumnSpan = 2;
                headerRow2.Cells.Add(HeaderCell);

                //updated code by bharat 12-feb
                HeaderCell = new TableCell();
                HeaderCell.Text = "Avg TOP Approval Days";
                HeaderCell.ColumnSpan = 2;
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Width = 80;
                headerRow2.Cells.Add(HeaderCell);

                //HeaderCell = new TableCell();
                //HeaderCell.Text = "Avg TOP Approval Days";
                ////HeaderCell.ColumnSpan = 2;
                //HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                //HeaderCell.Width = 80;
                //headerRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "TOP Sendg Week Befr. Ex";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.ColumnSpan = 2;
                HeaderCell.Width = 80;
                headerRow2.Cells.Add(HeaderCell);

                //HeaderCell = new TableCell();
                //HeaderCell.Text = "TOP Sendg Week Befr. Ex";
                //HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                ////HeaderCell.ColumnSpan = 2;
                //HeaderCell.Width = 80;
                //headerRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "TOP Aprd But MDA Pndg Cnt ( ASOS)";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Width = 80;
                HeaderCell.RowSpan = 2;
                headerRow2.Cells.Add(HeaderCell);

                // 3rd row
                HeaderCell = new TableCell();
                HeaderCell.Text = "Count";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Width = 50;
                headerRow3.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Test Rpt Pndg Count";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Width = 50;
                headerRow3.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Count";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Width = 50;
                headerRow3.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Test Rpt Pndg Count";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Width = 50;
                headerRow3.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "1Month";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Width = 50;
                headerRow3.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "3Month";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Width = 50;
                headerRow3.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "1Month ";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Width = 50;
                headerRow3.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "3Month";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Width = 50;
                headerRow3.Cells.Add(HeaderCell);

                //==================End Of Second Row=================
                grdPoUploadPendingBreakDown.Controls[0].Controls.AddAt(0, headerRow3);
                //updated code by bharat 12-feb
                grdPoUploadPendingBreakDown.Controls[0].Controls.AddAt(0, headerRow2);
                grdPoUploadPendingBreakDown.Controls[0].Controls.AddAt(0, headerRow1);

                grdPoUploadPendingBreakDown.Width = 500 + 80 + 100 + 12 + Count * 40 + Count;
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
              
                DataRowView drv = (DataRowView)e.Row.DataItem;

                string AM = drv.Row.ItemArray[0] == DBNull.Value ? "" : drv.Row.ItemArray[0].ToString();
                string PrevPendPO = drv.Row.ItemArray[1] == DBNull.Value ? "" : drv.Row.ItemArray[1].ToString();
                string FiveWeekPend = drv.Row.ItemArray[2] == DBNull.Value ? "" : drv.Row.ItemArray[2].ToString();

                Label AccountManagerName = e.Row.FindControl("AccountManagerName") as Label;
                AccountManagerName.Text = AM;
                AccountManagerName.Style.Add("color", "gray");
                e.Row.Cells[0].Width = 100;

                Label POCount = e.Row.FindControl("POCount") as Label;
                if (PrevPendPO == "0" || PrevPendPO == "")
                {
                    e.Row.Cells[1].CssClass = "Background-green";
                }
                else
                {
                    POCount.Text = PrevPendPO;
                    e.Row.Cells[1].CssClass = "Background-red";
                }

                Label PONextFiveWeek = e.Row.FindControl("PONextFiveWeek") as Label;
                if (FiveWeekPend == "0" || FiveWeekPend == "")
                {
                    e.Row.Cells[2].CssClass = "Background-green";
                }
                else
                {
                    e.Row.Cells[2].CssClass = "Background-red";
                    PONextFiveWeek.Text = FiveWeekPend;
                }
                

                int Count = Convert.ToInt32(ds.Tables[1].Rows.Count);
                string AMName = AM;
                int iCheck = 0;
                if (Convert.ToInt32(ds.Tables[1].Rows.Count) > 0)
                {
                    for (int iExfactory = 0; iExfactory < Count; iExfactory++)
                    {
                        string AMexFactor = Convert.ToString(ds.Tables[1].Rows[iExfactory]["Exfactory"]);
                        HtmlTableCell exfactorynew = e.Row.FindControl("Exfactory" + Convert.ToString(ds.Tables[1].Rows[iExfactory]["Exfactory"])) as HtmlTableCell;
                        Label exfactory = e.Row.FindControl("Exfactory" + Convert.ToString(ds.Tables[1].Rows[iExfactory]["Exfactory"])) as Label;
                        exfactory.Text = objadmin.Get_POBreakDown(AMName, AMexFactor); // EFW.ToString();
                        // exfactory.Value = "2"; // EFW.ToString();                                      
                        if (exfactory.Text == "0" || exfactory.Text == "")
                        {
                            e.Row.Cells[iExfactory + 3].CssClass = "Background-green";
                            exfactory.Text = "";
                            iCheck = iExfactory + 3;
                        }
                        else
                        {
                            e.Row.Cells[iExfactory + 3].CssClass = "Background-red";
                            iCheck = iExfactory + 3;
                        }

                        if (AMName == "Total")
                        {
                            e.Row.Cells[iExfactory + 3].Style.Add("color", "#000 !important");
                        }

                    }

                }



                //-------------------------Backup Loop Row-----------------//

                //int AMCount = Convert.ToInt32(ds.Tables[0].Rows.Count);
                //int Count = Convert.ToInt32(ds.Tables[1].Rows.Count);
                //if (AMCount > 0)
                //{
                //    for (int i = 0; i < AMCount - 1; i++)
                //    {
                //        if ((AMCount - 1) == i)
                //            break;
                //        string AMName = Convert.ToString(ds.Tables[0].Rows[i]["AccountManagerName"]);
                //        if (Convert.ToInt32(ds.Tables[1].Rows.Count) > 0)
                //        {
                //            for (int iExfactory = 0; iExfactory < Count; iExfactory++)
                //            {
                //                if ((Count - 1) == iExfactory)
                //                    break;
                //                string AMexFactor = Convert.ToString(ds.Tables[1].Rows[iExfactory]["Exfactory"]);
                //                HtmlInputText exfactory = e.Row.FindControl("Exfactory" + Convert.ToString(ds.Tables[1].Rows[iExfactory]["Exfactory"])) as HtmlInputText;
                //                exfactory.Value = objadmin.Get_POBreakDown(AMName, AMexFactor); // EFW.ToString();
                //                exfactory.Style.Add("width", "70px");
                //                // exfactory.Value = "2"; // EFW.ToString();                                      
                //                if (exfactory.Value == "0" || exfactory.Value == "")
                //                {
                //                    exfactory.Style.Add("background", "red");
                //                    exfactory.Value = "";
                //                }
                //                else
                //                {
                //                    exfactory.Style.Add("background", "green");
                //                    exfactory.Style.Add("color", "yellow");
                //                    exfactory.Style.Add("text-align", "center");
                //                }

                //            }

                //        }
                //    }
                //}


                //----------------------End Of Loop----------------------//
                string ElevenWeek = drv.Row.ItemArray[3] == DBNull.Value ? "" : drv.Row.ItemArray[3].ToString();
                Label PONext11WeekToEnd = e.Row.FindControl("PONext11WeekToEnd") as Label;
                // PONext11WeekToEnd.Value = ElevenWeek;
                if (ElevenWeek == "" || ElevenWeek == "0")
                {
                    PONext11WeekToEnd.Text = "";
                }
                else
                {
                    PONext11WeekToEnd.Text = ElevenWeek;
                }
                string PoTotal = drv.Row.ItemArray[4] == DBNull.Value ? "" : drv.Row.ItemArray[4].ToString();
                Label PendingTotal = e.Row.FindControl("PendingTotal") as Label;

                if (PoTotal == "" || PoTotal == "0")
                {
                    PendingTotal.Text = "";
                }
                else
                {
                    //Added by Yadvendra on 12/12/19
                    PendingTotal.Text = Convert.ToInt32(PoTotal).ToString("N0");
                }

                string averagePOUploadtime = drv.Row.ItemArray[5] == DBNull.Value ? "" : drv.Row.ItemArray[5].ToString();
                Label AveragePOUploadtime = e.Row.FindControl("AveragePOUploadtime") as Label;

                if (averagePOUploadtime == "" || averagePOUploadtime == "0")
                {
                    AveragePOUploadtime.Text = "";
                }
                else
                {
                    AveragePOUploadtime.Text = averagePOUploadtime;
                }
                // update code by bharat on 28-feb
                string TopPndgSentcountVal = drv.Row.ItemArray[8] == DBNull.Value ? "" : drv.Row.ItemArray[8].ToString();
                string TopSentRptPndCountVal = drv.Row.ItemArray[18] == DBNull.Value ? "" : drv.Row.ItemArray[18].ToString();
                Label TopPndgSentCount = e.Row.FindControl("TopPndgSentCount") as Label;
                Label TopSentRptPenCount = e.Row.FindControl("TopSentRptPenCount") as Label;
                if (TopPndgSentcountVal == "" || TopPndgSentcountVal == "0")
                {
                    TopPndgSentCount.Text = "";
                }
                else
                {
                    TopPndgSentCount.Text = TopPndgSentcountVal;                    
                }

                if (TopSentRptPndCountVal == "" || TopSentRptPndCountVal == "0")
                {
                    TopSentRptPenCount.Text = "";
                }
                else
                {
                    TopSentRptPenCount.Text = TopSentRptPndCountVal;
                }
              
                string TopPndgCountVal = drv.Row.ItemArray[9] == DBNull.Value ? "" : drv.Row.ItemArray[9].ToString();
                string ToprEeportPenCountVal = drv.Row.ItemArray[17] == DBNull.Value ? "" : drv.Row.ItemArray[17].ToString();
                Label TopPndgCount = e.Row.FindControl("TopPndgCount") as Label;
                Label TopPndgTestRPTPNDGCount = e.Row.FindControl("TopPndgTestRPTPNDGCount") as Label;
                if (TopPndgCountVal == "" || TopPndgCountVal == "0")
                {
                    TopPndgCount.Text = "";
                }
                else
                {
                    TopPndgCount.Text = TopPndgCountVal;
                }

                if (ToprEeportPenCountVal == "" || ToprEeportPenCountVal == "0")
                {
                    TopPndgTestRPTPNDGCount.Text = "";
                }
                else
                {
                    TopPndgTestRPTPNDGCount.Text = ToprEeportPenCountVal;
                }

                //updated code by bharat
                string Avg_Between_TopSent_and_Top_Approved_For1Monthes = drv.Row.ItemArray[14] == DBNull.Value ? "" : drv.Row.ItemArray[14].ToString();
                string Avg_Between_TopSent_and_Top_Approved_For3Monthes = drv.Row.ItemArray[13] == DBNull.Value ? "" : drv.Row.ItemArray[13].ToString();
                Label AvgTopApprOne_1Month = e.Row.FindControl("AvgTopApprOne_1Month") as Label;
                Label AvgTopApprOne_3Month = e.Row.FindControl("AvgTopApprOne_3Month") as Label;
                if (Avg_Between_TopSent_and_Top_Approved_For1Monthes != "" && Avg_Between_TopSent_and_Top_Approved_For3Monthes != "")
                {
                    if (Avg_Between_TopSent_and_Top_Approved_For1Monthes != "0")
                    {
                        if (Avg_Between_TopSent_and_Top_Approved_For3Monthes != "0")
                        {
                           
                                AvgTopApprOne_3Month.Text = Avg_Between_TopSent_and_Top_Approved_For3Monthes;
                                AvgTopApprOne_1Month.Text = Avg_Between_TopSent_and_Top_Approved_For1Monthes;
                        }
                        else
                        {
                            AvgTopApprOne_1Month.Text = Avg_Between_TopSent_and_Top_Approved_For1Monthes;
                        }
                    }
                    else
                    {
                        if (Avg_Between_TopSent_and_Top_Approved_For3Monthes != "0")
                        {
                            AvgTopApprOne_3Month.Text =  Avg_Between_TopSent_and_Top_Approved_For3Monthes;
                        }
                    }

                    if (AvgTopApprOne_1Month.Text != "")
                    {
                        if (Convert.ToInt32(AvgTopApprOne_1Month.Text) > 3)
                        {
                            e.Row.Cells[iCheck + 8].Attributes.Add("class", "backgrondcolrAvg");
                        }
                    }
                    if (AvgTopApprOne_3Month.Text != "")
                    {
                        if (Convert.ToInt32(AvgTopApprOne_3Month.Text) > 3)
                        {
                            e.Row.Cells[iCheck + 9].Attributes.Add("class", "backgrondcolrAvg");
                        }
                    }
                }

                string TopExfactoryLeadTimeDays = drv.Row.ItemArray[11] == DBNull.Value ? "" : drv.Row.ItemArray[11].ToString();
                string TopSent_ETA = drv.Row.ItemArray[10] == DBNull.Value ? "" : drv.Row.ItemArray[10].ToString();
                Label TopSendgSentWeekBef_1Month = e.Row.FindControl("TopSendgSentWeekBef_1Month") as Label;
                Label TopSendgSentWeekBef_3Month = e.Row.FindControl("TopSendgSentWeekBef_3Month") as Label;
                if (TopExfactoryLeadTimeDays != "" && TopSent_ETA != "")
                {
                    if (TopExfactoryLeadTimeDays != "0")
                    {
                        if (TopSent_ETA != "0")
                        {
                            TopSendgSentWeekBef_1Month.Text = TopExfactoryLeadTimeDays ;
                            TopSendgSentWeekBef_3Month.Text = TopSent_ETA;
                        }
                        else
                        {
                            TopSendgSentWeekBef_1Month.Text = TopExfactoryLeadTimeDays;
                        }
                    }
                    else
                    {
                        if (TopSent_ETA != "0")
                        {
                            TopSendgSentWeekBef_3Month.Text = TopSent_ETA;
                        }                        
                    }
                    if (TopSendgSentWeekBef_1Month.Text != "")
                    {
                        if (Convert.ToInt32(TopSendgSentWeekBef_1Month.Text) < 2)
                        {
                            e.Row.Cells[iCheck + 10].Attributes.Add("class", "backgrondcolrAvg");
                        }
                    }
                    if (TopSendgSentWeekBef_3Month.Text != "")
                    {
                        if (Convert.ToInt32(TopSendgSentWeekBef_3Month.Text) < 2)
                        {
                            e.Row.Cells[iCheck + 11].Attributes.Add("class", "backgrondcolrAvg");
                        }
                    }
                }



                string TopMDACount = drv.Row.ItemArray[12] == DBNull.Value ? "" : drv.Row.ItemArray[12].ToString();
                Label TopAprvdBtMDA = e.Row.FindControl("TopAprvdBtMDA") as Label;
                if (TopMDACount == "" || TopMDACount == "0")
                {
                    TopAprvdBtMDA.Text = "";
                }
                else
                {
                    TopAprvdBtMDA.Text = TopMDACount;
                }

             
            }
        }

    }
}