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


namespace iKandi.Web
{
    public partial class AccessoryPerformance : BaseUserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)

                Bindcontrols();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Bindcontrols();
        }

        private void Bindcontrols()
        {
           

            DataSet ds = this.ReportControllerInstance.GetAccessoryPerformance(Convert.ToInt32(ddlOrderDt.SelectedValue));


            DataTable accData = ds.Tables[0];
            DataTable accCategory = ds.Tables[1];

            DataTable accessoryTable = new DataTable();
            accessoryTable.Columns.Add("Category");
            accessoryTable.Columns.Add("SubCategory");
            accessoryTable.Columns.Add("-3");
            accessoryTable.Columns.Add("-2");
            accessoryTable.Columns.Add("-1");
            accessoryTable.Columns.Add("0");
            accessoryTable.Columns.Add("1");
            accessoryTable.Columns.Add("2");
            accessoryTable.Columns.Add("3");


            foreach (DataRow dr in accCategory.Rows)
            {
                int catID = Convert.ToInt32(dr["CategoryID"]);
                int subcatID = Convert.ToInt32(dr["SubCategoryID"]);
               
                DataRow[] rows = accData.Select("CategoryID=" + catID.ToString() + " AND SubCategoryID = " + subcatID.ToString() );

                int totalRows = rows.Length;

                if (totalRows == 0)
                    continue;

                DataRow newRow = accessoryTable.NewRow();

                newRow["-3"] = 0;
                newRow["-2"] = 0;
                newRow["-1"] = 0;
                newRow["0"] = 0;
                newRow["1"] = 0;
                newRow["2"] = 0;
                newRow["3"] = 0;
                newRow["Category"] = rows[0]["Category"];
                newRow["SubCategory"] = rows[0]["SubCategory"];
               
                int pctDeviation = 0;
                // -3
                rows = accData.Select("CategoryID=" + catID.ToString() + " AND SubCategoryID = " + subcatID.ToString()  + " AND Deviation <= -3");

                if (rows.Length > 0)
                {
                    pctDeviation = (int)((100 * rows.Length) / totalRows);
                    newRow["-3"] = pctDeviation.ToString("N0");
                }

                // -2
                rows = accData.Select("CategoryID=" + catID.ToString() + " AND SubCategoryID = " + subcatID.ToString()  + " AND Deviation=-2");

                if (rows.Length > 0)
                {
                    pctDeviation = pctDeviation + ((100 * rows.Length) / totalRows);
                    newRow["-2"] = pctDeviation.ToString("N0");
                }

                // -1
                rows = accData.Select("CategoryID=" + catID.ToString() + " AND SubCategoryID = " + subcatID.ToString()  + " AND Deviation=-1");

                if (rows.Length > 0)
                {
                    pctDeviation = pctDeviation + ((100 * rows.Length) / totalRows);
                    newRow["-1"] = pctDeviation.ToString("N0");
                }

                // 0
                rows = accData.Select("CategoryID=" + catID.ToString() + " AND SubCategoryID = " + subcatID.ToString()  + " AND Deviation=0");

                if (rows.Length > 0)
                {
                    pctDeviation = pctDeviation + ((100 * rows.Length) / totalRows);
                    newRow["0"] = pctDeviation.ToString("N0");
                }

                // +1
                rows = accData.Select("CategoryID=" + catID.ToString() + " AND SubCategoryID = " + subcatID.ToString()  + " AND Deviation=1");

                if (rows.Length > 0)
                {
                    pctDeviation = pctDeviation + ((100 * rows.Length) / totalRows);
                    newRow["1"] = pctDeviation.ToString("N0");
                }

                // +2
                rows = accData.Select("CategoryID=" + catID.ToString() + " AND SubCategoryID = " + subcatID.ToString()  + " AND Deviation=2");

                if (rows.Length > 0)
                {
                    pctDeviation = pctDeviation + ((100 * rows.Length) / totalRows);
                    newRow["2"] = pctDeviation.ToString("N0");
                }

                // +3
                rows = accData.Select("CategoryID=" + catID.ToString() + " AND SubCategoryID = " + subcatID.ToString()  + " AND Deviation >= 3");

                if (rows.Length > 0)
                {
                    pctDeviation = pctDeviation + ((100 * rows.Length) / totalRows);
                    newRow["3"] = pctDeviation.ToString("N0");
                }

                accessoryTable.Rows.Add(newRow);
            }

            /*
            DataRow row = accessoryTable.NewRow();

            if (ds.Tables[0].Rows.Count > 0)
                row["-3"] = ds.Tables[0].Rows[0]["avgdays"];
            else
                row["-3"] = 0;
            if (ds.Tables[1].Rows.Count > 0)
                row["-2"] = ds.Tables[1].Rows[0]["avgdays"];
            else
                row["-2"] = 0;
            if (ds.Tables[2].Rows.Count > 0)
                row["-1"] = ds.Tables[2].Rows[0]["avgdays"];
            else
                row["-1"] = 0;
            if (ds.Tables[3].Rows.Count > 0)
                row["0"] = ds.Tables[3].Rows[0]["avgdays"];
            else
                row["0"] = 0;
            if (ds.Tables[4].Rows.Count > 0)
                row["1"] = ds.Tables[4].Rows[0]["avgdays"];
            else
                row["1"] = 0;
            if (ds.Tables[5].Rows.Count > 0)
                row["2"] = ds.Tables[5].Rows[0]["avgdays"];
            else
                row["2"] = 0;
            if (ds.Tables[6].Rows.Count > 0)
                row["3"] = ds.Tables[6].Rows[0]["avgdays"];
            row["3"] = 0;

            row["AvgWeeks"] = (Convert.ToDecimal(row["-3"]) + Convert.ToDecimal(row["-2"]) + Convert.ToDecimal(row["-1"]) + Convert.ToDecimal(row["0"]) + Convert.ToDecimal(row["1"]) + Convert.ToDecimal(row["2"]) + Convert.ToDecimal(row["3"])) / 7;


            accessoryTable.Rows.Add(row);
            */

            grdAccessory.DataSource = accessoryTable;
            grdAccessory.DataBind();
        }
    }
}