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
using iKandi.Web.Components;
using iKandi.Common;
using iKandi.BLL;


namespace iKandi.Web
{
    public partial class ClientDepartmentSalesReport : BaseUserControl
    {
        #region Properties

        public int DateType
        {
            get;
            set;
        }

        public int PriceType
        {
            get;
            set;
        }

        public string OrderDetailIds
        {
            get;
            set;
        }
        public int BuyingHouseId
        {
            get;
            set;
        }
        #endregion

        DataSet dsClientDepartment;
        DataTable dtClientDepartmentTable;
        int count = 0;
        bool IsExtraheaderCreated = false;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                DropdownHelper.BindYears(ddlYear);
                ddlYear.SelectedValue = DateTime.Now.Year.ToString();
                BindBuyingHouse();
                DropdownHelper.FillDropDownClient(ddlClients, Convert.ToInt32(ddlBH.SelectedValue),false,0);
            }

        }

        private void BindBuyingHouse()
        {
            ddlBH.DataSource = this.PrintControllerInstance.GetAllBuyingHouseBAL();
            ddlBH.DataTextField = "CompanyName";
            ddlBH.DataValueField = "ID";
            ddlBH.DataBind();
        }

        protected void btnGo_click(object sender, EventArgs e)
        {
            if (rdOrderDate.Checked == true)
            {
                DateType = 1;
            }
            else if (rdExFactryDate.Checked == true)
            {
                DateType = 2;

            }
            else if (rdDCDate.Checked == true)
            {
                DateType = 3;
            }

            IsExtraheaderCreated = false;
            BindControls();
        }

        protected void GridView1_OnRowCreated(object sender, GridViewRowEventArgs e)
        {
            if (IsExtraheaderCreated == false)
            {
                if (count > 0)
                {
                    GridView HeaderGrid = (GridView)sender;
                    GridViewRow HeaderGridRow =
                    new GridViewRow(0, 0, DataControlRowType.Header,
                    DataControlRowState.Insert);

                    TableCell HeaderCell = new TableCell();

                    HeaderCell.Text = "Dept.";
                    HeaderCell.CssClass = "extra_header";
                    HeaderCell.ColumnSpan = 1;
                    HeaderGridRow.Cells.Add(HeaderCell);

                    if (dsClientDepartment.Tables[1].Rows.Count > 0)
                    {
                        count = dsClientDepartment.Tables[1].Rows.Count;
                    }

                    int i;
                    for (i = 1; i <= count; i++)
                    {
                        HeaderCell = new TableCell();

                        HeaderCell.Text = dsClientDepartment.Tables[1].Rows[i - 1]["DepartmentName"].ToString();
                        HeaderCell.CssClass = "extra_header font_color_blue";
                        HeaderCell.ColumnSpan = 2;
                        HeaderGridRow.Cells.Add(HeaderCell);

                    }

                    HeaderCell = new TableCell();
                    HeaderCell.Text = "Total";
                    HeaderCell.CssClass = "extra_header font_color_blue";
                    HeaderCell.ColumnSpan = 2;
                    HeaderGridRow.Cells.Add(HeaderCell);

                    GridView1.Controls[0].Controls.AddAt
                                (0, HeaderGridRow);

                }
                IsExtraheaderCreated = true;
            }

        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            iKandi.BLL.Configuration.Configuration config = new iKandi.BLL.Configuration.Configuration();
            int i = 0;
            if (e.Row.RowType == DataControlRowType.Header)
            {

                for (i = 0; i < e.Row.Cells.Count; i++)
                {
                    if (e.Row.Cells[i].Text.Contains("Qty"))
                    {
                        e.Row.Cells[i].Text = "QTY";
                    }
                    else if (e.Row.Cells[i].Text.Contains("Revenue"))
                    {
                        e.Row.Cells[i].Text = "Revenue";
                    }
                }

            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[0].BackColor = System.Drawing.ColorTranslator.FromHtml("#F9ddf4");
                if (e.Row.RowIndex >= 12)
                {
                    e.Row.Cells[i].CssClass = "bold_text";
                }

                for (i = 1; i < e.Row.Cells.Count; i++)
                {

                    if (e.Row.RowIndex >= 12)
                    {
                        e.Row.Cells[i].BackColor = System.Drawing.ColorTranslator.FromHtml("#F9DDF4");
                        e.Row.Cells[i].CssClass = "quantity_style";
                    }
                    else
                    {
                        e.Row.Cells[i].CssClass = "font_color_blue";
                    }
                }

                for (i = 1; i < e.Row.Cells.Count; i = i + 2)
                {

                    if (e.Row.RowIndex <= 13)
                    {
                        if (e.Row.Cells[i].Text != "&nbsp;")
                        {
                            e.Row.Cells[i].Text = Math.Round(Convert.ToDouble(e.Row.Cells[i].Text), 0) == 0 ? string.Empty : Convert.ToDouble(e.Row.Cells[i].Text).ToString("N0");
                            if (PriceType == 1)
                            {
                                e.Row.Cells[i + 1].Text = e.Row.Cells[i + 1].Text == "&nbsp;"  ? string.Empty : Math.Round(Convert.ToDouble(e.Row.Cells[i + 1].Text), 0) == 0 ? string.Empty : "&pound;" + Convert.ToDouble(e.Row.Cells[i + 1].Text).ToString("N0");
                            }
                            else
                            {
                                e.Row.Cells[i + 1].Text = e.Row.Cells[i + 1].Text == "&nbsp;" ? string.Empty : Math.Round(Convert.ToDouble(e.Row.Cells[i + 1].Text), 0) == 0 ? string.Empty : "Rs." + (Convert.ToDouble(e.Row.Cells[i + 1].Text) * Convert.ToDouble(BLLCache.GetConfigurationKeyValue(Constants.INR_VALUE))).ToString("N0");
                            }
                        }
                    }

                }
            }
        }


        public void BindControls()
        {
            if (rdOrderDate.Checked == true)
            {
                DateType = 1;
            }
            else if (rdExFactryDate.Checked == true)
            {
                DateType = 2;

            }
            else if (rdDCDate.Checked == true)
            {
                DateType = 3;
            }
            dsClientDepartment = new DataSet();
            dtClientDepartmentTable = new DataTable();
                      

            if (PriceType == 2 && DateType == 0)
            {
                DateType = 2;
                rdExFactryDate.Checked = true;
            }
            else if (PriceType == 1 && DateType == 0)
            {
                DateType = 1;
                rdOrderDate.Checked = true;
            }
            int clientId=0;
            if (ddlClients.SelectedValue=="")
            {
                clientId=0;
            }
            else
            {
                clientId=Convert.ToInt32(ddlClients.SelectedValue);
            }

            dsClientDepartment = this.ReportControllerInstance.GetClientDepartmentSalesReport(clientId, Convert.ToInt32(ddlYear.SelectedValue), this.DateType, this.PriceType, Convert.ToInt32(ddlBH.SelectedValue));

            if (dsClientDepartment.Tables.Count > 0)
            {
                if (dsClientDepartment.Tables[1].Rows.Count > 0)
                {
                    count = dsClientDepartment.Tables[1].Rows.Count;
                }
            }

            int i = 1;

            // to Add Header

            dtClientDepartmentTable.Columns.Add("Month");

            for (i = 1; i <= count+1; i++)
            {
                dtClientDepartmentTable.Columns.Add("Qty" + i);
                dtClientDepartmentTable.Columns.Add("Revenue" + i);
            }
            
            // declearing three array ant assign 0

            int totalIndex = (count+1) * 2;
            double[] total = new double[totalIndex];
            int[] totalQuantity = new int[count + 1];
            double[] totalRevenue = new double[count + 1];
            foreach (int item in total)
            {
                total[item] = 0;
            }
            foreach (int item in totalQuantity)
            {
                totalQuantity[item] = 0;
            }

            foreach (int item in totalRevenue)
            {
                totalRevenue[item] = 0;

            }

            //to Add Rows  Jan -Dec
            for (i = 1; i <= 12; i++)
            {

                DataRow drClientDepartmentDataRow = dtClientDepartmentTable.NewRow();

                drClientDepartmentDataRow["Month"] = String.Format("{0:MMM}", Microsoft.VisualBasic.DateAndTime.MonthName(i, true));

                int quantity = 0;
                double revenue = 0.00;
                int j = 1;
                double TotalQuantity = 0;
                double TotalRevenue = 0;
                for (j = 1; j <= count + 1; j++)
                {
                    if (j <= count)
                    {
                        string str = @"MonthValue =" + i + " and DeptName=\'" + dsClientDepartment.Tables[1].Rows[j - 1]["DepartmentName"].ToString().Replace("'","''") + "\'";
                        DataRow[] dr = dsClientDepartment.Tables[0].Select(str);

                        if (dr.Length > 0)
                        {
                            quantity = (dr[0]["Quantity"] == DBNull.Value) ? 0 : Convert.ToInt32(dr[0]["Quantity"]);
                            revenue = (dr[0]["Revenue"] == DBNull.Value) ? 0 : Convert.ToDouble(dr[0]["Revenue"]);
                            totalQuantity[j - 1] += quantity;
                            totalRevenue[j - 1] += revenue;

                            drClientDepartmentDataRow["Qty" + j] = quantity;
                            drClientDepartmentDataRow["Revenue" + j] = revenue;
                            TotalQuantity += quantity;
                            TotalRevenue += revenue;
                        }
                        else
                        {
                            totalQuantity[j - 1] += 0;
                            totalRevenue[j - 1] += 0;

                            drClientDepartmentDataRow["Qty" + j] = 0;
                            drClientDepartmentDataRow["Revenue" + j] = 0;
                            TotalQuantity += 0;
                            TotalRevenue += 0;
                        
                        }
                       
                    }

                    if (j == count + 1)
                    {
                        drClientDepartmentDataRow["Qty" + j] = TotalQuantity;
                        drClientDepartmentDataRow["Revenue" + j] = TotalRevenue;

                        totalQuantity[j - 1] += Convert.ToInt32(TotalQuantity);
                        totalRevenue[j - 1] += Convert.ToInt32(TotalRevenue);
                    }

                }
               
                dtClientDepartmentTable.Rows.Add(drClientDepartmentDataRow);
            }

            int totalCount;
            int totalQuantityCount = 0;
            int totalRevenueCount = 0;

            // to Add Total
            for (totalCount = 0; totalCount < totalIndex; )
            {
                if (totalCount % 2 == 0)
                {;
                    if (totalQuantityCount < count + 1)
                    {
                        total[totalCount] = totalQuantity[totalQuantityCount];
                        totalQuantityCount++;

                    }
                }
                else
                {
                    if (totalRevenueCount < count + 1)
                    {
                        total[totalCount] = totalRevenue[totalRevenueCount];
                        totalRevenueCount++;
                    }
                }

                totalCount++;

            }

            DataRow drClientDepartmentDataRowForTotal = dtClientDepartmentTable.NewRow();
            drClientDepartmentDataRowForTotal[0] = "Total";
            for (i = 1; i <= totalIndex; i++)
            {
                drClientDepartmentDataRowForTotal[i] = total[i - 1];
            }
            dtClientDepartmentTable.Rows.Add(drClientDepartmentDataRowForTotal);

            // For Estimate

            String currentYear = "01/01/" + DateTime.Now.Year.ToString();
            DateTime currentYearDate = Convert.ToDateTime(currentYear);
            DateTime todayDate = DateTime.Now.Date;
            long days = Math.Abs(Microsoft.VisualBasic.DateAndTime.DateDiff(Microsoft.VisualBasic.DateInterval.Day, currentYearDate, todayDate, Microsoft.VisualBasic.FirstDayOfWeek.Sunday, Microsoft.VisualBasic.FirstWeekOfYear.Jan1));
            
            double estimateFactor = 0;
            double estimate;
            double[] totalEstimate = new double[totalIndex];
            foreach (int item in totalEstimate)
            {
                totalEstimate[item] = 0.00;
            }

            // To Calculate estimate factor
            if (days > 0)
            {
                estimateFactor = (365.00 / (double)days);
            }
            estimateFactor = Math.Round(estimateFactor, 2);

            // to get every column estimate factor

            for (i = 0; i < totalIndex; i++)
            {
                estimate = total[i] * estimateFactor;
                totalEstimate[i] = estimate;
            }

            // Add new row in table
            if (ddlYear.SelectedValue == DateTime.Now.Year.ToString())
            {
                DataRow drClientDepartmentDataRowForEstimate = dtClientDepartmentTable.NewRow();
                drClientDepartmentDataRowForEstimate[0] = "Estimate";
                for (i = 1; i <= totalIndex; i++)
                {
                    drClientDepartmentDataRowForEstimate[i] = totalEstimate[i - 1];
                }

                dtClientDepartmentTable.Rows.Add(drClientDepartmentDataRowForEstimate);
            }

            // to bind grid
            IsExtraheaderCreated = false;
            GridView1.DataSource = dtClientDepartmentTable;
            GridView1.DataBind();


            if (ddlYear.SelectedValue == DateTime.Now.Year.ToString())
            {
                hdnEstimateFactor.Value = "0";
                lblEstimateFactor.Text = (estimateFactor).ToString("N2");
            }
            else
            {
                hdnEstimateFactor.Value = "1";
            }
        }

        protected void ddlBH_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropdownHelper.FillDropDownClient(ddlClients, Convert.ToInt32(ddlBH.SelectedValue),false,0);
        }
    }
}