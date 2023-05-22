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
using iKandi.BLL;
using iKandi.Common;
using System.Collections.Generic;

namespace iKandi.Web
{
    public partial class AverageLeadTimes : BaseUserControl
    {
        #region Fields

        DataSet dsAvgLeadTimes = null;
        DataTable dtAvgLeadTimes = null;
        bool IsExtraheaderCreated = false;
        int totalModes = 0;
        int clientDepts = 0;
        string ClientName = String.Empty;
        int parentRow = -1;
        int clientId = -1;

        # endregion

        #region Event Handlers

        protected void Page_Load(object sender, EventArgs e)
        {
            BindControls();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindControls();
        }

        protected void grdAvgLeadTimes_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[0].BackColor = System.Drawing.ColorTranslator.FromHtml("#F9ddf4");
            e.Row.Cells[1].BackColor = System.Drawing.ColorTranslator.FromHtml("#F9ddf4");

            if (e.Row.RowType == DataControlRowType.Header)
            {
                for (int i = 0; i < 2; i++)
                {
                    e.Row.Cells[i].Visible = false;
                }
                for (int i = 2; i < e.Row.Cells.Count-2; i++)
                {
                    if (e.Row.Cells[i].Text.Contains("Created-Target :"))
                    {
                        e.Row.Cells[i].Text = "Created-Target";
                    }
                    else if (e.Row.Cells[i].Text.Contains("Created-Actual :"))
                    {
                        e.Row.Cells[i].Text = "Created-Actual";
                    }                    
                }
            }

            else if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (ClientName == e.Row.Cells[0].Text)
                {
                    if (grdAvgLeadTimes.Rows.Count > parentRow)
                    {
                        grdAvgLeadTimes.Rows[parentRow].Cells[0].RowSpan += 1;
                        e.Row.Cells[0].Visible = false;
                    }
                }
                else
                {
                    parentRow = e.Row.RowIndex;
                    ClientName = e.Row.Cells[0].Text;
                    e.Row.Cells[0].RowSpan = 1;
                }

                //if (e.Row.RowIndex == clientDepts - 1 && clientId > 0)
                //    grdAvgLeadTimes.Rows[parentRow].Cells[0].RowSpan += 1;

                e.Row.Cells[0].CssClass = "font_color_blue text_align_left";
                e.Row.Cells[1].CssClass = "font_color_blue text_align_left";

                for (int i = 2; i < e.Row.Cells.Count; i++)
                {
                    e.Row.Cells[i].CssClass = "font_color_blue";
                    e.Row.Cells[i].Text = e.Row.Cells[i].Text == "0" || e.Row.Cells[i].Text == string.Empty || e.Row.Cells[i].Text == "&nbsp;" ? string.Empty : Convert.ToInt32(e.Row.Cells[i].Text).ToString("N0");
                }
            }
        }

        protected void grdAvgLeadTimes_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (IsExtraheaderCreated == false)
            {
                if (dsAvgLeadTimes != null && dsAvgLeadTimes.Tables.Count > 0)
                {
                    if (dsAvgLeadTimes.Tables[0].Rows.Count > 0)
                    {
                        totalModes = dsAvgLeadTimes.Tables[0].Rows.Count;
                    }

                    GridView HeaderGrid = (GridView)sender;

                    GridViewRow HeaderGridRow =
                    new GridViewRow(0, 0, DataControlRowType.Header,
                    DataControlRowState.Insert);

                    TableCell HeaderCell;

                    HeaderCell = new TableCell();
                    HeaderCell.Text = "CLIENT";
                    HeaderCell.CssClass = "extra_header";
                    HeaderCell.ColumnSpan = 1;
                    HeaderCell.RowSpan = 2;
                    HeaderGridRow.Cells.Add(HeaderCell);

                    HeaderCell = new TableCell();
                    HeaderCell.Text = "DEPARTMENT";
                    HeaderCell.CssClass = "extra_header";
                    HeaderCell.ColumnSpan = 1;
                    HeaderCell.RowSpan = 2;
                    HeaderGridRow.Cells.Add(HeaderCell);


                    for (int i = 1; i <= totalModes; i++)
                    {
                        HeaderCell = new TableCell();
                        HeaderCell.Text = dsAvgLeadTimes.Tables[0].Rows[i - 1]["Code"].ToString();
                        HeaderCell.CssClass = "extra_header font_color_blue";
                        HeaderCell.ColumnSpan = 2;
                        HeaderCell.RowSpan = 1;
                        HeaderGridRow.Cells.Add(HeaderCell);
                    }

                    HeaderCell = new TableCell();
                    HeaderCell.Text = "SAMPLE LEAD TIMES";
                    HeaderCell.CssClass = "extra_header";
                    HeaderCell.ColumnSpan = 2;
                    HeaderCell.RowSpan = 1;
                    HeaderGridRow.Cells.Add(HeaderCell);

                    grdAvgLeadTimes.Controls[0].Controls.AddAt(0, HeaderGridRow);
                }
                IsExtraheaderCreated = true;
            }
        }

        # endregion

        #region Private Methods

        public void BindControls()
        {
            if (!IsPostBack)
            {
                DropdownHelper.BindClients(ddlClients);
            }

            clientId = Convert.ToInt32(ddlClients.SelectedValue);

            dsAvgLeadTimes = this.ReportControllerInstance.GetAverageLeadTimesReport(Convert.ToInt32(radioDate.SelectedValue), clientId);
            dtAvgLeadTimes = new DataTable();
            clientDepts = dsAvgLeadTimes.Tables[1].Rows.Count;
            DataRowCollection clientDeptRows = dsAvgLeadTimes.Tables[1].Rows;
            DataRowCollection modeRows = dsAvgLeadTimes.Tables[0].Rows;

            if (dsAvgLeadTimes.Tables[2].Rows.Count == 0)
                return;

            if (dsAvgLeadTimes.Tables.Count > 0 && dsAvgLeadTimes.Tables[0].Rows.Count > 0)
            {
                totalModes = dsAvgLeadTimes.Tables[0].Rows.Count;
            }

            dtAvgLeadTimes.Columns.Add("CLIENT");
            dtAvgLeadTimes.Columns.Add("DEPARTMENT");
            for (int i = 0; i < totalModes; i++)
            {
                DataColumn tgt = new DataColumn();
                tgt.ColumnName = "Created-Target :" + i;
                dtAvgLeadTimes.Columns.Add(tgt);

                DataColumn act = new DataColumn();
                act.ColumnName = "Created-Actual :" + i;
                dtAvgLeadTimes.Columns.Add(act);
            }

            dtAvgLeadTimes.Columns.Add("Created-Target Dispatch(DAYS)");
            dtAvgLeadTimes.Columns.Add("Created-Actual Dispatch(DAYS)");

            for (int rows = 0; rows < clientDepts; rows++)
            {
                DataRow drAvgLeadTimes = dtAvgLeadTimes.NewRow();
                for (int i = 0; i < totalModes; i++)
                {
                    int targetDays = 0;
                    int actualDays = 0;
                    int odtoexdays = 0;
                    int odtoexdaysActual = 0;

                    string str = "ClientId =" + clientDeptRows[rows]["ClientId"] + " and DepartmentId=" + clientDeptRows[rows]["Id"] + " and ModeName='" + modeRows[i]["Code"] + "'";
                    DataRow[] dr = dsAvgLeadTimes.Tables[2].Select(str);

                    string str1 = "ClientId =" + clientDeptRows[rows]["ClientId"] + " and DepartmentId=" + clientDeptRows[rows]["Id"];
                    DataRow[] dr1 = dsAvgLeadTimes.Tables[2].Select(str1);

                    drAvgLeadTimes["CLIENT"] = (clientDeptRows[rows]["CompanyName"] == DBNull.Value) ? String.Empty : clientDeptRows[rows]["CompanyName"].ToString();
                    drAvgLeadTimes["DEPARTMENT"] = (clientDeptRows[rows]["DepartmentName"] == DBNull.Value) ? String.Empty : clientDeptRows[rows]["DepartmentName"].ToString();

                    string modeName = dsAvgLeadTimes.Tables[0].Rows[i]["Code"].ToString();
                    if (dr.Length > 0)
                    {
                        for (int z = 0; z < dr.Length; z++)
                        {
                            odtoexdays += ((dr[z]["ODtoEx"] == DBNull.Value) ? 0 : Convert.ToInt32(dr[z]["ODtoEx"]));
                            odtoexdaysActual += ((dr[z]["ODtoExActual"] == DBNull.Value) ? 0 : Convert.ToInt32(dr[z]["ODtoExActual"]));
                        }
                        odtoexdays = odtoexdays / dr.Length;
                        odtoexdaysActual = odtoexdaysActual / dr.Length;
                    }
                    drAvgLeadTimes["Created-Target :" + i] = odtoexdays.ToString();
                    drAvgLeadTimes["Created-Actual :" + i] = odtoexdaysActual.ToString();

                    if (dr1.Length > 0)
                    {
                        for (int z = 0; z < dr1.Length; z++)
                        {
                            targetDays += ((dr1[z]["TGTDays"] == DBNull.Value) ? 0 : Convert.ToInt32(dr1[z]["TGTDays"]));
                            actualDays += ((dr1[z]["ACTDays"] == DBNull.Value) ? 0 : Convert.ToInt32(dr1[z]["ACTDays"]));
                        }
                        targetDays = targetDays / dr1.Length;
                        actualDays = actualDays / dr1.Length;
                    }
                    drAvgLeadTimes["Created-Target Dispatch(DAYS)"] = targetDays.ToString();
                    drAvgLeadTimes["Created-Actual Dispatch(DAYS)"] = actualDays.ToString();
                }

                dtAvgLeadTimes.Rows.Add(drAvgLeadTimes);
            }

            IsExtraheaderCreated = false;

            grdAvgLeadTimes.DataSource = dtAvgLeadTimes;
            grdAvgLeadTimes.DataBind();
        }

        # endregion
    }
}