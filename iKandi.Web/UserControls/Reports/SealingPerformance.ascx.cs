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
using iKandi.Common;
using iKandi.Web.Components;


namespace iKandi.Web
{
    public partial class SealingPerformance : BaseUserControl
    {
        #region Fields

        public DataSet ds;
        public Int32 rows;
        public Int32 i;
        public Decimal cm3 = 0;
        public Decimal cm2 = 0;
        public Decimal cm1 = 0;
        public Decimal c0 = 0;
        public Decimal c1 = 0;
        public Decimal c2 = 0;
        public Decimal c3 = 0;
        public Decimal flag = 0;

        #endregion

        #region Event Handler

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)

                Bindcontrols();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Bindcontrols();
        }

        protected void grdSealing_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {               
                e.Row.Cells[0].CssClass = "column_color text_align_left font_color_blue";
                e.Row.Cells[1].CssClass = "column_color text_align_left font_color_blue";
                e.Row.Cells[9].CssClass = "font_color_blue";

                Label lblm3 = e.Row.FindControl("Label3") as Label;
                var per = lblm3.Text.Split('%');
                if (per[0].ToString() != "&nbsp;" && per[0].ToString() != string.Empty && Convert.ToInt32(per[0]) >= 0)
                (lblm3.Parent as TableCell).BackColor = System.Drawing.ColorTranslator.FromHtml(Constants.GetPercentageColor(Convert.ToInt32(per[0])));

                Label lblm2 = e.Row.FindControl("Label4") as Label;
                var per1 = lblm2.Text.Split('%');
                if (per1[0].ToString() != "&nbsp;" && per1[0].ToString() != string.Empty && Convert.ToInt32(per1[0]) >= 0)
                    (lblm2.Parent as TableCell).BackColor = System.Drawing.ColorTranslator.FromHtml(Constants.GetPercentageColor(Convert.ToInt32(per1[0])));

                Label lblm1 = e.Row.FindControl("Label6") as Label;
                var per2 = lblm1.Text.Split('%');
                if (per2[0].ToString() != "&nbsp;" && per2[0].ToString() != string.Empty && Convert.ToInt32(per2[0]) >= 0)
                    (lblm1.Parent as TableCell).BackColor = System.Drawing.ColorTranslator.FromHtml(Constants.GetPercentageColor(Convert.ToInt32(per2[0])));

                Label lbl0 = e.Row.FindControl("Label7") as Label;
                var per3 = lbl0.Text.Split('%');
                if (per3[0].ToString() != "&nbsp;" && per3[0].ToString() != string.Empty && Convert.ToInt32(per3[0]) >= 0)
                    (lbl0.Parent as TableCell).BackColor = System.Drawing.ColorTranslator.FromHtml(Constants.GetPercentageColor(Convert.ToInt32(per3[0])));

                Label lbl1 = e.Row.FindControl("Label9") as Label;
                var per4 = lbl1.Text.Split('%');
                if (per4[0].ToString() != "&nbsp;" && per4[0].ToString() != string.Empty && Convert.ToInt32(per4[0]) >= 0)
                    (lbl1.Parent as TableCell).BackColor = System.Drawing.ColorTranslator.FromHtml(Constants.GetPercentageColor(Convert.ToInt32(per4[0])));

                Label lbl2 = e.Row.FindControl("Label10") as Label;
                var per5 = lbl2.Text.Split('%');
                if (per5[0].ToString() != "&nbsp;" && per5[0].ToString() != string.Empty && Convert.ToInt32(per5[0]) >= 0)
                    (lbl2.Parent as TableCell).BackColor = System.Drawing.ColorTranslator.FromHtml(Constants.GetPercentageColor(Convert.ToInt32(per5[0])));

                Label lbl3 = e.Row.FindControl("Label11") as Label;
                var per6 = lbl3.Text.Split('%');
                if (per6[0].ToString() != "&nbsp;" && per6[0].ToString() != string.Empty && Convert.ToInt32(per6[0]) >= 0)
                    (lbl3.Parent as TableCell).BackColor = System.Drawing.ColorTranslator.FromHtml(Constants.GetPercentageColor(Convert.ToInt32(per6[0])));
                               
            }
        }

        #endregion


        #region Private Method
        private void Bindcontrols()
        {     
            ds = this.ReportControllerInstance.GetSealingPerformance(Convert.ToInt32(ddlOrderDt.SelectedValue));

            DataTable sealingData = ds.Tables[0];
            DataTable clientDeptData = ds.Tables[1];
            DataTable sealingTable = new DataTable();
            sealingTable.Columns.Add("CompanyName");            
            sealingTable.Columns.Add("DepartmentName");
            sealingTable.Columns.Add("-3");
            sealingTable.Columns.Add("-2");
            sealingTable.Columns.Add("-1");
            sealingTable.Columns.Add("0");
            sealingTable.Columns.Add("1");
            sealingTable.Columns.Add("2");
            sealingTable.Columns.Add("3");
            sealingTable.Columns.Add("AvgWeeks");

            foreach (DataRow dr in clientDeptData.Rows)
            {
                int clientID = Convert.ToInt32(dr["ClientID"]);
                int departmentID = Convert.ToInt32(dr["DeptID"]);
                DataRow[] rows = sealingData.Select("ClientID=" + clientID.ToString() + " AND DeptID = " + departmentID.ToString());

                int totalRows = rows.Length;

                if (totalRows == 0)
                    continue;

                DataRow newRow = sealingTable.NewRow();

                newRow["-3"] = 0;
                newRow["-2"] = 0;
                newRow["-1"] = 0;
                newRow["0"] = 0;
                newRow["1"] = 0;
                newRow["2"] = 0;
                newRow["3"] = 0;
                newRow["CompanyName"] = rows[0]["CompanyName"];
                newRow["DepartmentName"] = rows[0]["DepartmentName"];
               // newRow["AvgWeeks"] = "0";

                decimal avgWeeks = 0;
                int pctDeviation = 0;
                // -3
                rows = sealingData.Select("ClientID=" + clientID.ToString() + " AND DeptID = " + departmentID.ToString() + " AND Deviation <= -3");

                if (rows.Length > 0)
                {
                    pctDeviation = (int)((100 * rows.Length) / totalRows);
                    newRow["-3"] = pctDeviation.ToString("N0");
                    avgWeeks = avgWeeks + (-3 * rows.Length);
                }

                // -2
                rows = sealingData.Select("ClientID=" + clientID.ToString() + " AND DeptID = " + departmentID.ToString() + " AND Deviation=-2");

                if (rows.Length > 0)
                {
                    pctDeviation = pctDeviation + ((100 * rows.Length) / totalRows);
                    newRow["-2"] = pctDeviation.ToString("N0");
                    avgWeeks = avgWeeks + (-2 * rows.Length);
                }

                // -1
                rows = sealingData.Select("ClientID=" + clientID.ToString() + " AND DeptID = " + departmentID.ToString() + " AND Deviation=-1");

                if (rows.Length > 0)
                {
                    pctDeviation = pctDeviation + ((100 * rows.Length) / totalRows);
                    newRow["-1"] = pctDeviation.ToString("N0");
                    avgWeeks = avgWeeks + (-1 * rows.Length);
                }

                // 0
                rows = sealingData.Select("ClientID=" + clientID.ToString() + " AND DeptID = " + departmentID.ToString() + " AND Deviation=0");

                if (rows.Length > 0)
                {
                    pctDeviation = pctDeviation + ((100 * rows.Length) / totalRows);
                    newRow["0"] = pctDeviation.ToString("N0");
                    avgWeeks = avgWeeks + (0 * rows.Length);
                }

                // +1
                rows = sealingData.Select("ClientID=" + clientID.ToString() + " AND DeptID = " + departmentID.ToString() + " AND Deviation=1");

                if (rows.Length > 0)
                {
                    pctDeviation = pctDeviation + ((100 * rows.Length) / totalRows);
                    newRow["1"] = pctDeviation.ToString("N0");
                    avgWeeks = avgWeeks + (1 * rows.Length);
                }

                // +2
                rows = sealingData.Select("ClientID=" + clientID.ToString() + " AND DeptID = " + departmentID.ToString() + " AND Deviation=2");

                if (rows.Length > 0)
                {
                    pctDeviation = pctDeviation + ((100 * rows.Length) / totalRows);
                    newRow["2"] = pctDeviation.ToString("N0");
                    avgWeeks = avgWeeks + (2 * rows.Length);
                }

                // +3
                rows = sealingData.Select("ClientID=" + clientID.ToString() + " AND DeptID = " + departmentID.ToString() + " AND Deviation >= 3");

                if (rows.Length > 0)
                {
                    pctDeviation = pctDeviation + ((100 * rows.Length) / totalRows);
                    newRow["3"] = pctDeviation.ToString("N0");
                    avgWeeks = avgWeeks + (3 * rows.Length);
                }

                //avg weeks
                newRow["AvgWeeks"] = (Convert.ToDecimal(avgWeeks / totalRows)).ToString("N2");
                
                sealingTable.Rows.Add(newRow);
            }


            /*
            for (i = 0; i < ds.Tables[1].Rows.Count; i++)
            {
                cm3 = 0;
                cm2 = 0;
                cm1 = 0;
                c0 = 0;
                c1 = 0;
                c2 = 0;
                c3 = 0;

                DataRow row = sealingTable.NewRow();

                row["-3"] = 0;
                row["-2"] = 0;
                row["-1"] = 0;
                row["0"] = 0;
                row["1"] = 0;
                row["2"] = 0;
                row["3"] = 0;
                row["CompanyName"] = ds.Tables[1].Rows[i]["CompanyName"];
                row["DepartmentName"] = ds.Tables[1].Rows[i]["DepartmentName"];
                row["AvgWeeks"] = ds.Tables[1].Rows[i]["AvgWeeks"];

                foreach (DataRow dr in sealingTable1.Rows)
                {


                    if (Convert.ToInt32(dr["ClientID"]) == Convert.ToInt32(ds.Tables[1].Rows[i]["ClientID"]) && (Convert.ToInt32(dr["DeptID"]) == Convert.ToInt32(ds.Tables[1].Rows[i]["DeptID"])))
                    {

                        if (Convert.ToDecimal(dr["AvgWeeks"]) <= -3)
                        {
                            row["-3"] = Convert.ToDecimal(row["-3"]) + Convert.ToDecimal(dr["AvgWeeks"]);
                            cm1++;
                        }

                        if (Convert.ToDecimal(dr["AvgWeeks"]) > -3 && Convert.ToDecimal(dr["AvgWeeks"]) <= -2)
                        {
                            row["-2"] = Convert.ToDecimal(row["-2"]) + Convert.ToDecimal(dr["AvgWeeks"]);
                            cm2++;
                        }

                        if (Convert.ToDecimal(dr["AvgWeeks"]) > -2 && Convert.ToDecimal(dr["AvgWeeks"]) <= -1)
                        {
                            row["-1"] = Convert.ToDecimal(row["-1"]) + Convert.ToDecimal(dr["AvgWeeks"]);
                            cm1++;
                        }

                        if (Convert.ToDecimal(dr["AvgWeeks"]) > -1 && Convert.ToDecimal(dr["AvgWeeks"]) <= 0)
                        {
                            row["0"] = Convert.ToDecimal(row["0"]) + Convert.ToDecimal(dr["AvgWeeks"]);
                            c0++;
                        }

                        if (Convert.ToDecimal(dr["AvgWeeks"]) > 0 && Convert.ToDecimal(dr["AvgWeeks"]) <= 1)
                        {
                            row["1"] = Convert.ToDecimal(row["1"]) + Convert.ToDecimal(dr["AvgWeeks"]);
                            c1++;
                        }

                        if (Convert.ToDecimal(dr["AvgWeeks"]) > 1 && Convert.ToDecimal(dr["AvgWeeks"]) <= 2)
                        {
                            row["2"] = Convert.ToDecimal(row["2"]) + Convert.ToDecimal(dr["AvgWeeks"]);
                            c2++;
                        }

                        if (Convert.ToDecimal(dr["AvgWeeks"]) > 2)
                        {
                            row["3"] = Convert.ToDecimal(row["3"]) + Convert.ToDecimal(dr["AvgWeeks"]);
                            c3++;
                        }
                        flag = 1;
                    }

                }
                if (flag == 1)
                {
                    if (cm3 > 0)
                        row["-3"] = Convert.ToDecimal(row["-3"]) / cm3;
                    if (cm2 > 0)
                        row["-2"] = Convert.ToDecimal(row["-2"]) / cm2;
                    if (cm1 > 0)
                        row["-1"] = Convert.ToDecimal(row["-1"]) / cm1;
                    if (c0 > 0)
                        row["0"] = Convert.ToDecimal(row["0"]) / c0;
                    if (c1 > 0)
                        row["1"] = Convert.ToDecimal(row["1"]) / c1;
                    if (c2 > 0)
                        row["2"] = Convert.ToDecimal(row["2"]) / c2;
                    if (c3 > 0)
                        row["3"] = Convert.ToDecimal(row["3"]) / c3;
                    sealingTable.Rows.Add(row);
                }

                flag = 0;
            }
             * 
             */

            grdSealing.DataSource = sealingTable;
            grdSealing.DataBind();
        }
        #endregion


    }
}