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
    public partial class frm_pending_cost_confirmation : System.Web.UI.UserControl
    {
        AdminController objadmin = new AdminController();


        public int PenCostCount
        {
            get;
            set;
        }

        public int PenCostNextFiveWeek
        {
            get;
            set;
        }
        public int exfactory
        {
            get;
            set;
        }
        public int PenCostPendingTotal
        {
            get;
            set;
        }
        public int PenCostNext11WeekToEnd
        {
            get;
            set;
        }
        public int PenCostDiffence
        {
            get;
            set;
        }
        
        int Count = 0;
        DataSet ds = new DataSet();

        protected void Page_Load(object sender, EventArgs e)
        {
            bindHeader();
            GridViewRow grdfrmpendingcostconfirmationrow = grdfrmpendingcostconfirmation.Rows[(grdfrmpendingcostconfirmation.Rows.Count) - 1];
            grdfrmpendingcostconfirmationrow.CssClass = "frmPOUPload";
            grdfrmpendingcostconfirmationrow.Font.Bold = true;
            //updated Code by bharat 12-feb
            Label PenCostCount = grdfrmpendingcostconfirmationrow.FindControl("PenCostCount") as Label;
            Label PenCostNextFiveWeek = grdfrmpendingcostconfirmationrow.FindControl("PenCostNextFiveWeek") as Label;
            Label Exfactory = grdfrmpendingcostconfirmationrow.FindControl("Exfactory") as Label;
            PenCostCount.Style.Add("color", "#000 !important");
            PenCostNextFiveWeek.Style.Add("color", "#000 !important");

            //end
        }
        protected void bindHeader()
        {
            ds = objadmin.GetHeaderPendingCostConfirmation();

            grdfrmpendingcostconfirmation.DataSource = ds.Tables[0];
            grdfrmpendingcostconfirmation.DataBind();

            TemplateField AM = new TemplateField();
            //AM.HeaderText = "AM";
            AM.ItemTemplate = new iKandi.Common.GridViewTemplate("label", "AccountManagerName", "AccountManagerName");
            grdfrmpendingcostconfirmation.Columns.Insert(0, AM);
            AM.HeaderStyle.Width = 100;



            TemplateField PrevPendCostCon = new TemplateField();
            // PrevPendPO.HeaderText = "Prev PO";
            PrevPendCostCon.ItemTemplate = new iKandi.Common.GridViewTemplate("label", "PenCostCount", "PenCostCount");
            PrevPendCostCon.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            grdfrmpendingcostconfirmation.Columns.Insert(1, PrevPendCostCon);
            PrevPendCostCon.HeaderStyle.Width = 40;

            TemplateField FiveWeekPendCostCon = new TemplateField();
            // FiveWeekPend.HeaderText = "Today + 5 Wk";
            FiveWeekPendCostCon.ItemTemplate = new iKandi.Common.GridViewTemplate("label", "PenCostNextFiveWeek", "PenCostNextFiveWeek");
            FiveWeekPendCostCon.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            grdfrmpendingcostconfirmation.Columns.Insert(2, FiveWeekPendCostCon);
            FiveWeekPendCostCon.HeaderStyle.Width = 40;

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
                    grdfrmpendingcostconfirmation.Columns.Insert(i + 3, Exfactory);
                    Exfactory.HeaderStyle.Width = 40;
                }

            }

            TemplateField ElevenWeekEnd = new TemplateField();
            //  ElevenWeekEnd.HeaderText = "11 Wk Till End";
            ElevenWeekEnd.ItemTemplate = new iKandi.Common.GridViewTemplate("label", "PenCostNext11WeekToEnd", "PenCostNext11WeekToEnd");
            ElevenWeekEnd.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            grdfrmpendingcostconfirmation.Columns.Insert(Count + 4, ElevenWeekEnd);
            ElevenWeekEnd.HeaderStyle.Width = 50;


            TemplateField PendTot = new TemplateField();
            // PendTot.HeaderText = "Total";
            PendTot.ItemTemplate = new iKandi.Common.GridViewTemplate("label", "PenCostPendingTotal", "PenCostPendingTotal");
            PendTot.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            grdfrmpendingcostconfirmation.Columns.Insert(Count + 5, PendTot);
            PendTot.HeaderStyle.Width = 50;

            TemplateField PenCostDiffence = new TemplateField();
            // PendTot.HeaderText = "Total";
            PenCostDiffence.ItemTemplate = new iKandi.Common.GridViewTemplate("label", "PenCostDiffence", "PenCostDiffence");
            PenCostDiffence.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            grdfrmpendingcostconfirmation.Columns.Insert(Count + 6, PenCostDiffence);
            PendTot.HeaderStyle.Width = 50;

            grdfrmpendingcostconfirmation.DataSource = ds.Tables[0];
            grdfrmpendingcostconfirmation.DataBind();
        }

        protected void grdfrmpendingcostconfirmation_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                GridViewRow headerRow1 = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
                GridViewRow headerRow2 = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
                headerRow1.Attributes.Add("class", "header4");
                headerRow2.Attributes.Add("class", "header5");

                TableCell HeaderCell = new TableCell();

                HeaderCell = new TableCell();
                HeaderCell.Text = "Name";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.RowSpan = 2;
                HeaderCell.Width = 100;
                headerRow1.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Pending Cost Confirmation Report";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.ColumnSpan = Count + 6;
                headerRow1.Cells.Add(HeaderCell);

                //-------------second Row-----------------------

                HeaderCell = new TableCell();
                HeaderCell.Text = "Prev On Hold";
                HeaderCell.Width = 60;
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Today + 5 Wk";
                HeaderCell.Width = 60;
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
                        headerRow2.Cells.Add(HeaderCell);
                    }
                }





                HeaderCell = new TableCell();
                HeaderCell.Text = "11 Wk Till End";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Width = 50;
                headerRow2.Cells.Add(HeaderCell);


                HeaderCell = new TableCell();
                HeaderCell.Text = "Total";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Width = 50;
                headerRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Cost Difference";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Width = 50;
                headerRow2.Cells.Add(HeaderCell);
                //==================End Of Second Row=================
                grdfrmpendingcostconfirmation.Controls[0].Controls.AddAt(0, headerRow2);
                grdfrmpendingcostconfirmation.Controls[0].Controls.AddAt(0, headerRow1);
                //-------------End Of Header-------------


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

                Label PenCostCount = e.Row.FindControl("PenCostCount") as Label;
                if (PrevPendPO == "0" || PrevPendPO == "")
                {
                    e.Row.Cells[1].CssClass = "Background-green";
                }
                else
                {
                    PenCostCount.Text = PrevPendPO;
                    e.Row.Cells[1].CssClass = "Background-red";
                }

                Label PenCostNextFiveWeek = e.Row.FindControl("PenCostNextFiveWeek") as Label;

                if (FiveWeekPend == "0" || FiveWeekPend == "")
                {
                    e.Row.Cells[2].CssClass = "Background-green";
                }
                else
                {
                    e.Row.Cells[2].CssClass = "Background-red";
                    PenCostNextFiveWeek.Text = FiveWeekPend;
                }

                int Count = Convert.ToInt32(ds.Tables[1].Rows.Count);
                string AMName = AM;
                int PoTotalvalue = 0;
                if (Convert.ToInt32(ds.Tables[1].Rows.Count) > 0)
                {
                    int TotalInternalDelay = 0;
                    for (int iExfactory = 0; iExfactory < Count; iExfactory++)
                    {
                        string AMexFactor = Convert.ToString(ds.Tables[1].Rows[iExfactory]["Exfactory"]);
                        HtmlTableCell exfactorynew = e.Row.FindControl("Exfactory" + Convert.ToString(ds.Tables[1].Rows[iExfactory]["Exfactory"])) as HtmlTableCell;
                        Label exfactory = e.Row.FindControl("Exfactory" + Convert.ToString(ds.Tables[1].Rows[iExfactory]["Exfactory"])) as Label;
                        exfactory.Text = objadmin.Usp_GetPenCostCon_Contract_Status_BreakDown(AMName, AMexFactor); // EFW.ToString();
                        // exfactory.Value = "2"; // EFW.ToString();                                      
                        if (exfactory.Text == "0" || exfactory.Text == "")
                        {
                            e.Row.Cells[iExfactory + 3].CssClass = "Background-green";
                            exfactory.Text = "";

                        }
                        else
                        {
                            TotalInternalDelay = TotalInternalDelay + Convert.ToInt32(exfactory.Text);

                            e.Row.Cells[iExfactory + 3].CssClass = "Background-red";
                        }
                        if (AMName == "Total")
                        {
                            exfactory.Style.Add("color", "#000 !important");
                        }

                    }
                    PoTotalvalue = TotalInternalDelay;
                }
                //----------------------End Of Loop----------------------//
                string ElevenWeek = drv.Row.ItemArray[3] == DBNull.Value ? "" : drv.Row.ItemArray[3].ToString();
                Label PenCostNext11WeekToEnd = e.Row.FindControl("PenCostNext11WeekToEnd") as Label;
                PenCostNext11WeekToEnd.Style.Add("color", "#000 !important");
                if (ElevenWeek == "" || ElevenWeek == "0")
                {
                    PenCostNext11WeekToEnd.Text = "";


                }
                else
                {
                    PenCostNext11WeekToEnd.Text = ElevenWeek;

                }
                string PoTotal = drv.Row.ItemArray[4] == DBNull.Value ? "" : drv.Row.ItemArray[4].ToString();
                Label PenCostPendingTotal = e.Row.FindControl("PenCostPendingTotal") as Label;
                PenCostPendingTotal.Style.Add("color", "#000 !important");

                if (PoTotal == "" || PoTotal == "0")
                {
                    PenCostPendingTotal.Text = "";
                }
                else
                {
                    //PendingTotal.Text = Convert.ToString(Convert.ToInt32(PoTotal) + Convert.ToInt32(PoTotalvalue));
                    //PendingTotal.Text = Convert.ToString(Convert.ToInt32(PoTotalvalue));
                    //Added by Yadvendra on 12/12/19
                    PenCostPendingTotal.Text = Convert.ToInt32(PoTotal).ToString("N0");
                }

                 string PenCostDiff = drv.Row.ItemArray[5] == DBNull.Value ? "" : drv.Row.ItemArray[5].ToString();
                 Label PenCostDiffence = e.Row.FindControl("PenCostDiffence") as Label;
                 PenCostDiffence.Style.Add("color", "green !important");

                 if (PenCostDiff == "" || PenCostDiff == "0")
                {
                    PenCostDiffence.Text = "";
                }
                else
                {

                    //PenCostDiffence.Text = "₹ " + Convert.ToInt32(PenCostDiff).ToString("N0");
                    PenCostDiffence.Text = "₹ " + PenCostDiff;
                }
            }



        }
    }
}