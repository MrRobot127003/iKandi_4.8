using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using iKandi.BLL;
using iKandi.Common;
using iKandi.Web.Components;


namespace iKandi.Web
{
    public partial class PendingPayments : BaseUserControl
    {
        int clientID = -1;
        
        double subTotal = 0.0;
        double PendingSubTotal = 0.0;
        double GTPendingSubTotal = 0.0;
        double grandTotal = 0.0;
        string GroupField = string.Empty;
        int count = 0;
        int numberOfSubTotalRows = 0;
        double currConversionFactor = Convert.ToDouble(iKandi.BLL.CommonHelper.GetExportConversionRate(iKandi.Common.Currency.GBP, iKandi.Common.Currency.INR));

        protected void Page_Load(object sender, EventArgs e)
        {

            hdnPagesize.Value = GridView1.PageSize.ToString();
            hdnPageIndex.Value = GridView1.PageIndex.ToString();
            if (!IsPostBack)
            {
                txtfrom.Value = DateTime.Today.AddDays(-7).ToString("dd MMM yy (ddd)");
                txtTo.Value = DateTime.Today.ToString("dd MMM yy (ddd)");
                BindControls();
            }

        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.DataRow)
                return;
            grandTotal += DataBinder.Eval(e.Row.DataItem, "Total") != DBNull.Value ? Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Total")) * Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "ConversionRateINR")) : 0;
            GTPendingSubTotal += DataBinder.Eval(e.Row.DataItem, "PendingPayment") != DBNull.Value ? Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "PendingPayment")) * Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "ConversionRateINR")) : 0;
            bool lastRow = e.Row.RowIndex == count - 1;
       
            if (lastRow)
            {
                if ((Convert.ToString(DataBinder.Eval(e.Row.DataItem, "GroupField")) != GroupField))
                {
                    if (subTotal > 0)
                    {
                    GridViewRow subTotalRow = new GridViewRow(0, 0, DataControlRowType.DataRow, DataControlRowState.Insert);
                    //Edit By Ashish for colspan TableCell on 26/9/2014
                        //subTotalRow.Cells.Add(PrepareTableCell("", "extra_header", 7));
                        subTotalRow.Cells.Add(PrepareTableCell("", "extra_header", 6));
                        //end
                        subTotalRow.Cells.Add(PrepareTableCell("Sub Total", "extra_header bold_text", 2));
                        subTotalRow.Cells.Add(PrepareTableCell(subTotal.ToString("N2"), "extra_header numeric_text quantity_style", 1));
                        subTotalRow.Cells.Add(PrepareTableCell(PendingSubTotal.ToString("N2"), "extra_header numeric_text quantity_style", 1));
                        //Edit By Ashish for Removing TableCell on 26/9/2014
                       // subTotalRow.Cells.Add(PrepareTableCell("", "extra_header", 1));
                        //END
                    



                    int subTotalRowIndex = e.Row.RowIndex + numberOfSubTotalRows + 1;
                    if (subTotalRowIndex >= GridView1.Controls[0].Controls.Count)
                    {
                        GridView1.Controls[0].Controls.Add(subTotalRow);
                    }
                    else
                    {
                        GridView1.Controls[0].Controls.AddAt(subTotalRowIndex, subTotalRow);
                    }
                    numberOfSubTotalRows++;
                    }
                    subTotal = DataBinder.Eval(e.Row.DataItem, "Total") != DBNull.Value ? Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Total")) * Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "ConversionRateINR")) : 0;
                    PendingSubTotal = DataBinder.Eval(e.Row.DataItem, "PendingPayment") != DBNull.Value ? Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "PendingPayment")) * Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "ConversionRateINR")) : 0;

                    clientID = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "ClientID"));
                    GroupField = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "GroupField"));
                    GridViewRow subTotalRow1 = new GridViewRow(0, 0, DataControlRowType.DataRow, DataControlRowState.Insert);
                    //Edit By Ashish for assing colspan in TableCell on 26/9/2014
                    //subTotalRow1.Cells.Add(PrepareTableCell("", "extra_header", 7));
                    subTotalRow1.Cells.Add(PrepareTableCell("", "extra_header", 6));
                    //END
                    subTotalRow1.Cells.Add(PrepareTableCell("Sub Total", "extra_header bold_text", 2));
                    subTotalRow1.Cells.Add(PrepareTableCell(subTotal.ToString("N2"), "numeric_text extra_header quantity_style", 1));
                    subTotalRow1.Cells.Add(PrepareTableCell(PendingSubTotal.ToString("N2"), "numeric_text extra_header quantity_style", 0));
                    //Edit By Ashish for Removing TableCell on 26/9/2014
                   // subTotalRow1.Cells.Add(PrepareTableCell("", "extra_header", 1));
                    //END
                    



                    int subTotalRowIndex1 = e.Row.RowIndex + numberOfSubTotalRows + 2;
                    if (subTotalRowIndex1 >= GridView1.Controls[0].Controls.Count)
                    {
                        GridView1.Controls[0].Controls.Add(subTotalRow1);
                    }
                    else
                    {
                        GridView1.Controls[0].Controls.AddAt(subTotalRowIndex1, subTotalRow1);
                    }
                    numberOfSubTotalRows++;
                   
                        GridViewRow grandTotalRow = new GridViewRow(0, 0, DataControlRowType.DataRow, DataControlRowState.Insert);
                        //Edit By Ashish for assing colspan in TableCell on 26/9/2014
                        //grandTotalRow.Cells.Add(PrepareTableCell("", "extra_header", 7));
                        subTotalRow1.Cells.Add(PrepareTableCell("", "extra_header", 6));
                        //END
                        grandTotalRow.Cells.Add(PrepareTableCell("", "extra_header", 6));
                        grandTotalRow.Cells.Add(PrepareTableCell("Grand Total", "extra_header bold_text", 2));
                        grandTotalRow.Cells.Add(PrepareTableCell(grandTotal.ToString("N2"), "numeric_text extra_header quantity_style", 1));
                        grandTotalRow.Cells.Add(PrepareTableCell(GTPendingSubTotal.ToString("N2"), "numeric_text extra_header quantity_style", 0));
                        //Edit By Ashish for Removing TableCell on 26/9/2014
                        //grandTotalRow.Cells.Add(PrepareTableCell("", "extra_header", 1));
                        //END

                    



                    GridView1.Controls[0].Controls.Add(grandTotalRow);
                }
                else
                {
                    PendingSubTotal += DataBinder.Eval(e.Row.DataItem, "PendingPayment") != DBNull.Value ? Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "PendingPayment")) * Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "ConversionRateINR")) : 0;
                    subTotal += DataBinder.Eval(e.Row.DataItem, "Total") != DBNull.Value ? Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Total")) * Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "ConversionRateINR")) : 0;
                    clientID = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "ClientID"));
                    GroupField = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "GroupField"));
                    if (subTotal > 0)
                    {
                        GridViewRow subTotalRow1 = new GridViewRow(0, 0, DataControlRowType.DataRow, DataControlRowState.Insert);
                        //Edit By Ashish for assing colspan in TableCell on 26/9/2014
                        //subTotalRow1.Cells.Add(PrepareTableCell("", "extra_header", 7));
                        subTotalRow1.Cells.Add(PrepareTableCell("", "extra_header", 6));
                        //END
                        subTotalRow1.Cells.Add(PrepareTableCell("Sub Total", "extra_header bold_text", 2));
                        subTotalRow1.Cells.Add(PrepareTableCell(subTotal.ToString("N2"), "numeric_text extra_header quantity_style", 1));
                        subTotalRow1.Cells.Add(PrepareTableCell(PendingSubTotal.ToString("N2"), "numeric_text extra_header quantity_style", 0));
                        //Edit By Ashish for Removing TableCell on 26/9/2014
                        //subTotalRow1.Cells.Add(PrepareTableCell("", "extra_header", 1));
                        //END

                    



                    int subTotalRowIndex1 = e.Row.RowIndex + numberOfSubTotalRows + 2;
                    if (subTotalRowIndex1 >= GridView1.Controls[0].Controls.Count)
                    {
                        GridView1.Controls[0].Controls.Add(subTotalRow1);
                    }
                    else
                    {
                        GridView1.Controls[0].Controls.AddAt(subTotalRowIndex1, subTotalRow1);
                    }
                    numberOfSubTotalRows++;
                    }
                    GridViewRow grandTotalRow = new GridViewRow(0, 0, DataControlRowType.DataRow, DataControlRowState.Insert);
                    //Edit By Ashish for assing colspan in TableCell on 26/9/2014
                    //grandTotalRow.Cells.Add(PrepareTableCell("", "extra_header",7));
                    grandTotalRow.Cells.Add(PrepareTableCell("", "extra_header", 6));
                    //END
                    grandTotalRow.Cells.Add(PrepareTableCell("Grand Total", "extra_header bold_text", 2));

                    grandTotalRow.Cells.Add(PrepareTableCell(grandTotal.ToString("N2"), "numeric_text extra_header quantity_style", 1));
                    grandTotalRow.Cells.Add(PrepareTableCell(GTPendingSubTotal.ToString("N2"), "numeric_text extra_header quantity_style", 0));
                    //Edit By Ashish for Removing TableCell on 26/9/2014
                    //grandTotalRow.Cells.Add(PrepareTableCell("", "extra_header", 1));
                    //END
                    



                    GridView1.Controls[0].Controls.Add(grandTotalRow);
                }
            }
            else if ((Convert.ToString(DataBinder.Eval(e.Row.DataItem, "GroupField")) != GroupField))
            {
                if (subTotal > 0)
                {
                    GridViewRow subTotalRow = new GridViewRow(0, 0, DataControlRowType.DataRow, DataControlRowState.Insert);
                    //Edit By Ashish for assing colspan in TableCell on 26/9/2014
                    //subTotalRow.Cells.Add(PrepareTableCell("", "extra_header", 7));
                    subTotalRow.Cells.Add(PrepareTableCell("", "extra_header", 6));
                    //END
                    subTotalRow.Cells.Add(PrepareTableCell("Sub Total", "extra_header bold_text", 2));
                    subTotalRow.Cells.Add(PrepareTableCell(subTotal.ToString("N2"), "extra_header numeric_text quantity_style", 1));
                    subTotalRow.Cells.Add(PrepareTableCell(PendingSubTotal.ToString("N2"), "extra_header numeric_text quantity_style", 0));
                    //Edit By Ashish for Removing TableCell on 26/9/2014
                    //subTotalRow.Cells.Add(PrepareTableCell("", "extra_header", 1));
                    //END


                int subTotalRowIndex = e.Row.RowIndex + numberOfSubTotalRows + 1;
                if (subTotalRowIndex >= GridView1.Controls[0].Controls.Count)
                {
                    GridView1.Controls[0].Controls.Add(subTotalRow);
                }
                else
                {
                    GridView1.Controls[0].Controls.AddAt(subTotalRowIndex, subTotalRow);
                }
                numberOfSubTotalRows++;
                }
                subTotal = DataBinder.Eval(e.Row.DataItem, "Total") != DBNull.Value ? Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Total")) * Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "ConversionRateINR")) : 0;
                PendingSubTotal = DataBinder.Eval(e.Row.DataItem, "PendingPayment") != DBNull.Value ? Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "PendingPayment")) * Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "ConversionRateINR")) : 0;
                clientID = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "ClientID"));
                GroupField = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "GroupField"));
            }
            else
            {
                subTotal += DataBinder.Eval(e.Row.DataItem, "Total") != DBNull.Value ? Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Total")) * Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "ConversionRateINR")) : 0;
                PendingSubTotal += DataBinder.Eval(e.Row.DataItem, "PendingPayment") != DBNull.Value ? Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "PendingPayment")) * Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "ConversionRateINR")) : 0;
                clientID = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "ClientID"));
                GroupField = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "GroupField"));
            }
           
        }

        private static TableCell PrepareTableCell(string text, string cssClass, int colSpan)
        {
            TableCell cell = new TableCell();

            cell.Text = text;
            cell.CssClass = cssClass;
            cell.ColumnSpan = colSpan;
            return cell;
        }

        public void BindControls()
        {
            if (!IsPostBack)
            {
                DropdownHelper.BindAllClients(ddlClients as ListControl);
            }
            DateTime startDate = txtfrom.Value.Trim() != string.Empty ? DateHelper.ParseDate(txtfrom.Value).Value : DateTime.MinValue;
            DateTime endDate = txtTo.Value.Trim() != string.Empty ? DateHelper.ParseDate(txtTo.Value).Value : DateTime.MaxValue;
            Session["StartDate"] = startDate;
            Session["EndDate"] = endDate;

            GridView1.DataBind();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
           
        }

        protected void btnGo_click(object sender, EventArgs e)
        {
            GridView1.PageIndex = 0;
            BindControls();
        }

        protected void odsPendingPayments_Selected(object sender, ObjectDataSourceStatusEventArgs e)
        {
            //count = e.ReturnValue is Int32 ? (int)e.ReturnValue : count;
            count = e.ReturnValue is DataSet ? ((DataSet)e.ReturnValue).Tables[0].Rows.Count : count;
        }

        protected void btnExportToExcel_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.AddHeader("content-disposition", "attachment;filename=PendingPayment.xls");
            Response.ContentType = "application/ms-excel";
            Response.Charset = "UTF-8";
            Response.ContentEncoding = Encoding.Default;
            string str = hfexcel.Value;
            str = str.Replace("~!", "<");
            str = str.Replace("!~", ">");
            Response.Write(str);
            Response.End();
        }

        protected void btnExportToPdf_Click(object sender, EventArgs e)
        {
            string myUrl = string.Empty;
            var ExcelImageUpload = Request.Url.OriginalString.ToString().Replace("//", "#").Split('/');
            myUrl = ExcelImageUpload[0].Replace("#", "//");
            myUrl = myUrl + "/Uploads/Style";
            ReportController rpt = new ReportController();
            DataSet ds = rpt.GetPendingPaymentsReport(GridView1.PageIndex, 0,
                                                                 Convert.ToDateTime(Session["StartDate"]),
                                                                 Convert.ToDateTime(Session["EndDate"]), 
                                                                 string.IsNullOrEmpty(tbBENumber.Text.Trim())?null:tbBENumber.Text.Trim(),
                                                                 Convert.ToInt32(ddlDueBE.SelectedValue),
                                                                 Convert.ToInt32(ddlClients.SelectedValue),
                                                                 ddlGroup.SelectedValue);
            string PDFfile = this.PDFControllerInstance.GeneratePDFPendingPayment(ds.Tables[0], myUrl);
            this.RenderFile(PDFfile, "PENDING PAYMENT Report.PDF", Constants.CONTENT_TYPE_PDF);
        }
    }
}