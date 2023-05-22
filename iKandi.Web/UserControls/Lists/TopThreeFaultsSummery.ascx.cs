using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iKandi.BLL.Production;
using System.Data;
using System.IO;
using System.Text;
using System.Net.Mail;
using System.Web.UI.HtmlControls;
using System.Drawing;
using iKandi.BLL;


namespace iKandi.Web.UserControls.Lists
{
    public partial class TopThreeFaultsSummery : System.Web.UI.UserControl
    {
        public int ProductionUnit
        {
            get;
            set;
        }
        public int SlotId
        {
            get;
            set;
        }
        public int LineNo
        {
            get;
            set;
        }
        public int StyleId
        {
            get;
            set;
        }
        public string StartDate
        {
            get;
            set;
        }

        int FactoryTotal = 0;

        int OrderQty_Total = 0;
        int COTValue_Total = 0;
        int DHU_Today_Total = 0;

        int UnitId = -1;
        

        ProductionController objProductionController = new ProductionController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                GetStitchingHourlyReport();

            }
        }
        #region Stitching



        private void GetStitchingHourlyReport()
        {
            DataSet ds;
            Stitch1EmptyMsg.Visible = false;
            lblStitch1EmptyMsg1.Text = "";
            lblStitch1EmptyMsg2.Text = "";
            ds = objProductionController.GetHourlyStitchingReport_top3fualtsSammury("", StyleId, -1, -1, -1, "HourlyReport");
            gvHourlyStitchingReport.DataSource = ds.Tables[0];
            gvHourlyStitchingReport.DataBind();


        }



        protected void gvHourlyStitchingReport_DataBound(object sender, EventArgs e)
        {
            for (int i = gvHourlyStitchingReport.Rows.Count - 1; i > 0; i--)
            {
                GridViewRow row = gvHourlyStitchingReport.Rows[i];
                GridViewRow previousRow = gvHourlyStitchingReport.Rows[i - 1];

                Label lblUnit = (Label)row.Cells[0].FindControl("lblUnit");
                Label lblPreviousUnit = (Label)previousRow.Cells[0].FindControl("lblUnit");

                if (lblUnit.Text == lblPreviousUnit.Text)
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


            }
        }



        protected void gvHourlyStitchingReport_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataSet dsfualt = new DataSet();
                DataTable dt = new DataTable();
                AdminController objadmin = new AdminController();

                HtmlTableCell tdserialno = (HtmlTableCell)e.Row.FindControl("tdserialno");
                HiddenField hdnserialColorCode = (HiddenField)e.Row.FindControl("hdnserialColorCode");
                HiddenField hdnOrderId = (HiddenField)e.Row.FindControl("hdnOrderId");
                HtmlTableCell tdstcpty = (HtmlTableCell)e.Row.FindControl("tdstcpty");
                HtmlTableCell tdFncpty = (HtmlTableCell)e.Row.FindControl("tdFncpty");
                Label lblTodayDHU = (Label)e.Row.FindControl("lblTodayDHU");
                string ClientColorCode = DataBinder.Eval(e.Row.DataItem, "ClientColorCode").ToString();
                if (ClientColorCode != "")
                {
                    tdserialno.Style.Add(HtmlTextWriterStyle.BackgroundColor, ClientColorCode);
                }
                
                HiddenField hdnEmptyMsg = (HiddenField)e.Row.FindControl("hdnEmptyMsg");
                Label lblUnit = (Label)e.Row.FindControl("lblUnit");

                Label lblDay = (Label)e.Row.FindControl("lblDay");
                Label lblOrderQty = (Label)e.Row.FindControl("lblOrderQty");

                Label lblLineNumber = (Label)e.Row.FindControl("lblLineNumber");
                Label lblProdDay = (Label)e.Row.FindControl("lblProdDay");
                Label lblCOT = (Label)e.Row.FindControl("lblCOT");

                UnitId = DataBinder.Eval(e.Row.DataItem, "UnitID") == DBNull.Value ? -1 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "UnitID"));


                int COT = DataBinder.Eval(e.Row.DataItem, "COTValue") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "COTValue"));

                int TodayDHU = DataBinder.Eval(e.Row.DataItem, "DHU_Today") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "DHU_Today"));
                lblTodayDHU.Text = TodayDHU == 0 ? "" : "(" + TodayDHU.ToString() + "%)";

                if (TodayDHU > 5)
                {
                    lblTodayDHU.Style.Add("color", "#FF0000");
                }

                lblProdDay.Text = "D " + lblProdDay.Text;

                lblCOT.Text = COT == 0 ? "" : COT.ToString();


                int OrderQty = DataBinder.Eval(e.Row.DataItem, "OrderQty") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "OrderQty"));


                if ((lblUnit.Text == "") && (UnitId != 0))
                {
                    e.Row.Cells[0].ColumnSpan = 3;
                    e.Row.Cells[1].Visible = false;
                    e.Row.Cells[2].Visible = false;
                    e.Row.Attributes.Add("class", "yellowFactory");


                    Label lblUnitTotal = (Label)e.Row.FindControl("lblUnitTotal");
                    lblUnitTotal.Text = "Factory Total";
                    COTValue_Total += DataBinder.Eval(e.Row.DataItem, "COTValue") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "COTValue"));

                    GridViewRow prevrow = gvHourlyStitchingReport.Rows[e.Row.RowIndex - 1];
                    Label lblPreviousUnit = (Label)prevrow.Cells[0].FindControl("lblUnit");
                    int Units =0;
                    if (lblPreviousUnit.Text == "C 47")
                    {
                        Units = 3;
                    }
                    else if (lblPreviousUnit.Text == "C 45-46")
                    {
                        Units = 11;
                    }
                    else

                    {
                        Units = 0;
                    }
                    OrderQty_Total += DataBinder.Eval(e.Row.DataItem, "OrderQty") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "OrderQty"));
                    DHU_Today_Total += DataBinder.Eval(e.Row.DataItem, "DHU_Today") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "DHU_Today"));

                    FactoryTotal = FactoryTotal + 1;

                    DataSet dsFaults;
                    dsFaults = objProductionController.GetHourlyStitchingReport_top3fualtsSammury(lblUnit.Text, StyleId, -1, LineNo, Units, "FAULTSTOTAL");
                    DataList dlstFaults = e.Row.FindControl("dlstFaults") as DataList;
                    dlstFaults.DataSource = dsFaults.Tables[0];
                    dlstFaults.DataBind();



                   
                        dsfualt = objadmin.GetTopQaFualtReport__top3FualtSummary(Units, 1, "TOPFUALTSTOTAL", -1, -1);
                        dt = dsfualt.Tables[0];
                        if (dt.Rows.Count > 0)
                        {

                            Repeater rptinceptionC47 = (Repeater)e.Row.FindControl("rptinceptionC47");
                            rptinceptionC47.DataSource = dt;
                            rptinceptionC47.DataBind();
                        }
                   


                }
                if ((hdnEmptyMsg.Value == DBNull.Value.ToString()) && (lblUnit.Text != ""))
                {
                    int OrderId = -1;
                    //int LinePlanningId = -1;
                    int ProductionUnit = -1;
                    HtmlTable tblEmptyMsg = (HtmlTable)e.Row.FindControl("tblEmptyMsg");
                    tblEmptyMsg.Visible = false;
                    HtmlTable tblLinePlan = (HtmlTable)e.Row.FindControl("tblLinePlan");
                    tblLinePlan.Visible = true;

                    HiddenField hdnStyleId = (HiddenField)e.Row.FindControl("hdnStyleId");
                    HiddenField hdnLineNo = (HiddenField)e.Row.FindControl("hdnLineNo");

                    HiddenField hdnUnitId = (HiddenField)e.Row.FindControl("hdnUnitId");
                    HtmlTableCell tdUpcomingStyle = (HtmlTableCell)e.Row.FindControl("tdUpcomingStyle");

                    if (hdnStyleId.Value != DBNull.Value.ToString())
                        StyleId = Convert.ToInt32(hdnStyleId.Value);
                    if (hdnLineNo.Value != DBNull.Value.ToString())
                        LineNo = Convert.ToInt32(hdnLineNo.Value);
                    if (hdnOrderId.Value != DBNull.Value.ToString())
                        OrderId = Convert.ToInt32(hdnOrderId.Value);
                    if (hdnUnitId.Value != DBNull.Value.ToString())
                        ProductionUnit = Convert.ToInt32(hdnUnitId.Value);

                    //DataSet ds;
                    //ds = objProductionController.GetHourlyStitchingReport_top3fualtsSammury(lblUnit.Text, StyleId, OrderId, LineNo, ProductionUnit, "LinePlanning");
                    //DataList dlstLineDesignation = e.Row.FindControl("dlstLineDesignation") as DataList;
                    //dlstLineDesignation.DataSource = ds.Tables[0];
                    //dlstLineDesignation.DataBind();

                    //Label lblUpcommingStyle = e.Row.FindControl("lblUpcommingStyle") as Label;

                    //string UpcomingStyle = objProductionController.GetUpcomingStyle(ProductionUnit, StyleId, LineNo);


                    DataSet dsInspection;
                    dsInspection = objProductionController.GetHourlyStitchingReport_top3fualtsSammury(lblUnit.Text, StyleId, OrderId, LineNo, ProductionUnit, "Inspection");
                    DataList dlstInspection = e.Row.FindControl("dlstInspection") as DataList;
                    dlstInspection.DataSource = dsInspection.Tables[0];
                    dlstInspection.DataBind();

                    DataSet dsFaults;
                    dsFaults = objProductionController.GetHourlyStitchingReport_top3fualtsSammury(lblUnit.Text, StyleId, OrderId, LineNo, ProductionUnit, "Faults");
                    DataList dlstFaults = e.Row.FindControl("dlstFaults") as DataList;
                    dlstFaults.DataSource = dsFaults.Tables[0];
                    dlstFaults.DataBind();

                }

                try
                {

                    int OrderID = DataBinder.Eval(e.Row.DataItem, "OrderId") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "OrderId"));
                    int UnitID = DataBinder.Eval(e.Row.DataItem, "UnitId") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "UnitId"));
                    DataSet dsfualts = objadmin.GetTopQaFualtReport__top3FualtSummary(UnitID, 1, "TOPFUALTS", OrderID, LineNo);
                    DataTable dtfualts = dsfualts.Tables[0];
                    if (dtfualts.Rows.Count > 0)
                    {

                        Repeater rptinceptionC47 = (Repeater)e.Row.FindControl("rptinceptionC47");
                        rptinceptionC47.DataSource = dtfualts;
                        rptinceptionC47.DataBind();
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                }

            }

            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[0].ColumnSpan = 3;
                e.Row.Cells[1].Visible = false;
                e.Row.Cells[2].Visible = false;
                e.Row.Attributes.Add("class", "yellowFactory");

                AdminController obc = new AdminController();
                
                DataList dlstFaultsfoter = (DataList)e.Row.FindControl("dlstFaultsfoter");
                Label lblTodayDHU_Foo = (Label)e.Row.FindControl("lblTodayDHU_Foo");
                DataSet dsFaults = objProductionController.GetHourlyStitchingReport_top3fualtsSammury("", StyleId, -1, 0, 0, "FAULTSTOTAL");
                //DataList dlstFaults = e.Row.FindControl("dlstFaults") as DataList;
                dlstFaultsfoter.DataSource = dsFaults.Tables[0];
                dlstFaultsfoter.DataBind();

                Repeater rptinceptionC47foter = (Repeater)e.Row.FindControl("rptinceptionC47foter");

                DataSet dsFaultsinpec = obc.GetTopQaFualtReport__top3FualtSummary(0, 1, "TOPFUALTSFACTORYTOTAL", -1, -1);
                //DataList dlstFaults = e.Row.FindControl("dlstFaults") as DataList;
                rptinceptionC47foter.DataSource = dsFaultsinpec.Tables[0];
                rptinceptionC47foter.DataBind();

                if (DHU_Today_Total != 0)
                    lblTodayDHU_Foo.Text = "(" + Math.Round(Convert.ToDouble(DHU_Today_Total) / Convert.ToDouble(FactoryTotal), 0).ToString() + "%)";
            }

        }

        #endregion Stitching


        public string GetGridviewData(GridView gv)
        {
            StringBuilder strBuilder = new StringBuilder();
            StringWriter strWriter = new StringWriter(strBuilder);
            HtmlTextWriter htw = new HtmlTextWriter(strWriter);
            gv.RenderControl(htw);
            return strBuilder.ToString();
        }

        protected void btnSendMail_Click(object sender, EventArgs e)
        {
            string strMailBody = GetGridviewData(gvHourlyStitchingReport);
        }



    }

}