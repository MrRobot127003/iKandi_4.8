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
using System.Collections.Generic;
using iKandi.Web.Components;
using iKandi.BLL;

namespace iKandi.Web
{
    public partial class ikandiInvoiceQuery : BaseUserControl
    {
        int ClientId = -1;
        int ikandiInvoiceId = -1;
        int IkandiInvoiceFirstRow = -1;
        string SearchText = string.Empty;
        DateTime FromDate1 = DateTime.MinValue;
        DateTime ToDate1;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DropdownHelper.BindClients(ddlClients as ListControl);
            }

            if (IsPostBack)
            {
                BindControls();
            }
        }

        protected void grdikandiInvoicing_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.DataRow)
                return;
            InvoiceOrder io = (e.Row.DataItem as InvoiceOrder);
            string[] delim = { "," };

            HiddenField hdnSerial = e.Row.FindControl("hdnSerial") as HiddenField;
            (hdnSerial.Parent as TableCell).BackColor = System.Drawing.ColorTranslator.FromHtml(Constants.GetSerialNumberColor(io.ExFactory));

            Label lblStatus = e.Row.FindControl("lblStatus") as Label;
            (lblStatus.Parent as TableCell).BackColor = System.Drawing.ColorTranslator.FromHtml(Constants.GetStatusModeColor(io.StatusModeID));

            Label lblIkandiInvoiceAmountSymbal = e.Row.FindControl("lblIkandiInvoiceAmountSymbal") as Label;
            lblIkandiInvoiceAmountSymbal.Text = Constants.GetCurrencySymbalByCurrencyType(io.ParentOrder.Costing.ConvertTo);

            string biplInvoiceQuantity = io.Invoice.AssocaitedBiplInvoicedQuantity;
            
            Label lblBiplInvoiceQty = e.Row.FindControl("lblBiplInvoiceQty") as Label;

            if (biplInvoiceQuantity != null)
            {
                if (biplInvoiceQuantity.IndexOf(",") > -1)
                {
                    string[] biplInvoiceQuantityArray = biplInvoiceQuantity.Split(delim, StringSplitOptions.None);
                    for (int i = 0; i < biplInvoiceQuantityArray.Length; i++)
                    {
                        Label lbl = new Label();
                        lbl.Text = Convert.ToInt32(biplInvoiceQuantityArray[i]).ToString("N0") + "<br/>";
                        lblBiplInvoiceQty.Controls.Add(lbl);
                    }
                }
                else
                {
                    Label lbl = new Label();
                    lbl.Text = Convert.ToInt32(biplInvoiceQuantity).ToString("N0") + "<br/>";
                    lblBiplInvoiceQty.Controls.Add(lbl);
                }
            }

            string biplInvoiceAmoumt = io.Invoice.AssocaitedBiplInvoicedAmount;
            Label lblBiplInvoiceAmount = e.Row.FindControl("lblBiplInvoiceAmount") as Label;

            if (biplInvoiceAmoumt != null)
            {
                if (biplInvoiceAmoumt.IndexOf(",") > -1)
                {
                    string[] biplInvoiceAmoumtArray = biplInvoiceAmoumt.Split(delim, StringSplitOptions.None);
                    for (int i = 0; i < biplInvoiceAmoumtArray.Length; i++)
                    {
                        Label lbl = new Label();
                        lbl.Text = Constants.GetCurrencySymbalByCurrencyType(io.ParentOrder.Costing.ConvertTo) + Convert.ToDouble(biplInvoiceAmoumtArray[i]).ToString("N2") + "<br/>";
                        lblBiplInvoiceAmount.Controls.Add(lbl);
                    }
                }
                else
                {
                    Label lbl = new Label();
                    lbl.Text = Constants.GetCurrencySymbalByCurrencyType(io.ParentOrder.Costing.ConvertTo) + Convert.ToDouble(biplInvoiceAmoumt).ToString("N0") + "<br/>";
                    lblBiplInvoiceAmount.Controls.Add(lbl);
                }
            }

            Panel pnlBiplInvoiceDetail = e.Row.FindControl("pnlBiplInvoiceDetail") as Panel;

            string biplInvoiceId = io.Invoice.AssocaitedBiplInvoicedId;
            string biplInvoiceNumber = io.Invoice.AssocaitedBiplInvoicedNo;
            string[] biplInvoiceIdArray;
            string[] biplInvoiceNumberArray;

            biplInvoiceNumberArray = biplInvoiceNumber.Split(delim, StringSplitOptions.None);


            if (biplInvoiceId != null)
            {
                if (biplInvoiceId.IndexOf(",") > -1)
                {
                    biplInvoiceIdArray = biplInvoiceId.Split(delim, StringSplitOptions.None);
                    for (int i = 0; i < biplInvoiceIdArray.Length - 1; i++)
                    {
                        if (biplInvoiceNumberArray[i].Trim() == "")
                        {
                            biplInvoiceNumberArray[i] = "View Bipl Invoice";
                        }

                        string invoiceNumber = biplInvoiceNumberArray[i];
                        string biplInvoiceNum = string.Empty;
                        string strBiplInvoiceDate = string.Empty;
                        DateTime date;
                        int year = 0;
                        int month = 0;
                        int day = 0;
                        if (invoiceNumber.IndexOf("$$") > -1)
                        {
                            biplInvoiceNum = invoiceNumber.Substring(0, (invoiceNumber.IndexOf("$$")));
                            strBiplInvoiceDate = invoiceNumber.Substring((invoiceNumber.IndexOf("$$")+2));
                            string[] delim1 = { "-" };
                            string[] dateAray = strBiplInvoiceDate.Trim().Split(delim1, StringSplitOptions.None);
                            
                            for (int j = 0; j < dateAray.Length ; j++)
                            {
                                if (j == 0)
                                {
                                    year = Convert.ToInt32(dateAray[j].Trim());
                                }
                                else if (j == 1)
                                {
                                    month = Convert.ToInt32(dateAray[j].Trim());
                                }
                                else if (j == 2)
                                {
                                    if (dateAray[j].Trim().IndexOf(" ") > -1)
                                    {
                                        day = Convert.ToInt32((dateAray[j].Trim().Substring(0, dateAray[j].Trim().IndexOf(" "))).Trim());

                                    }
                                }
                                else
                                {
                                    continue;
                                }                   

                            }                           

                        }

                        int id = Convert.ToInt32(biplInvoiceIdArray[i]);

                        HyperLink hypBiplInvoicedetail = new HyperLink();
                        hypBiplInvoicedetail.Text = biplInvoiceNum + "<br/>";
                        hypBiplInvoicedetail.Style.Add("width", "120px ! important");
                        hypBiplInvoicedetail.Attributes.Add("onclick", "javascript:launchBiplInvoice('" + id + "')");
                        pnlBiplInvoiceDetail.Controls.Add(hypBiplInvoicedetail);

                        if (year > 1 && month > 0 && day > 0)
                        {
                            date = new DateTime(year, month, day, 0, 0, 0);
                            Label lblBiplInvoiceDate = new Label();
                            lblBiplInvoiceDate.Text = "(" + date.ToString("dd MMM yyyy (ddd)") + ")<br/>";
                            lblBiplInvoiceDate.CssClass = "font_color_blue";
                            pnlBiplInvoiceDetail.Controls.Add(lblBiplInvoiceDate);
                        }

                    }
                }

            }

            if (ikandiInvoiceId == io.Invoice.ParentIkandiInvoiceID)
            {
                grdikandiInvoicing.Rows[IkandiInvoiceFirstRow].Cells[0].RowSpan += 1;
                e.Row.Cells[0].Visible = false;
                grdikandiInvoicing.Rows[IkandiInvoiceFirstRow].Cells[1].RowSpan += 1;
                e.Row.Cells[1].Visible = false;
                grdikandiInvoicing.Rows[IkandiInvoiceFirstRow].Cells[2].RowSpan += 1;
                e.Row.Cells[2].Visible = false;
                grdikandiInvoicing.Rows[IkandiInvoiceFirstRow].Cells[3].RowSpan += 1;
                e.Row.Cells[3].Visible = false;
                grdikandiInvoicing.Rows[IkandiInvoiceFirstRow].Cells[4].RowSpan += 1;
                e.Row.Cells[4].Visible = false;
                grdikandiInvoicing.Rows[IkandiInvoiceFirstRow].Cells[5].RowSpan += 1;
                e.Row.Cells[5].Visible = false;
                grdikandiInvoicing.Rows[IkandiInvoiceFirstRow].Cells[6].RowSpan += 1;
                e.Row.Cells[6].Visible = false;
                grdikandiInvoicing.Rows[IkandiInvoiceFirstRow].Cells[7].RowSpan += 1;
                e.Row.Cells[7].Visible = false;
                grdikandiInvoicing.Rows[IkandiInvoiceFirstRow].Cells[8].RowSpan += 1;
                e.Row.Cells[8].Visible = false;
                grdikandiInvoicing.Rows[IkandiInvoiceFirstRow].Cells[9].RowSpan += 1;
                e.Row.Cells[9].Visible = false;
                grdikandiInvoicing.Rows[IkandiInvoiceFirstRow].Cells[10].RowSpan += 1;
                e.Row.Cells[10].Visible = false;
                grdikandiInvoicing.Rows[IkandiInvoiceFirstRow].Cells[11].RowSpan += 1;
                e.Row.Cells[11].Visible = false;
                grdikandiInvoicing.Rows[IkandiInvoiceFirstRow].Cells[12].RowSpan += 1;
                e.Row.Cells[12].Visible = false;
                grdikandiInvoicing.Rows[IkandiInvoiceFirstRow].Cells[13].RowSpan += 1;
                e.Row.Cells[13].Visible = false;
                grdikandiInvoicing.Rows[IkandiInvoiceFirstRow].Cells[14].RowSpan += 1;
                e.Row.Cells[14].Visible = false;
                grdikandiInvoicing.Rows[IkandiInvoiceFirstRow].Cells[15].RowSpan += 1;
                e.Row.Cells[15].Visible = false;
                
            }
            else
            {
                ikandiInvoiceId = io.Invoice.IkandiInvoiceID;
                IkandiInvoiceFirstRow = e.Row.RowIndex;


                e.Row.Cells[0].RowSpan = 1;
                e.Row.Cells[1].RowSpan = 1;
                e.Row.Cells[2].RowSpan = 1;
                e.Row.Cells[3].RowSpan = 1;
                e.Row.Cells[4].RowSpan = 1;
                e.Row.Cells[5].RowSpan = 1;
                e.Row.Cells[6].RowSpan = 1;
                e.Row.Cells[7].RowSpan = 1;
                e.Row.Cells[8].RowSpan = 1;
                e.Row.Cells[9].RowSpan = 1;
                e.Row.Cells[10].RowSpan = 1;
                e.Row.Cells[11].RowSpan = 1;
                e.Row.Cells[12].RowSpan = 1;
                e.Row.Cells[13].RowSpan = 1;
                e.Row.Cells[14].RowSpan = 1;
                e.Row.Cells[15].RowSpan = 1;
            }
        }

     

        protected void btn_search_Click(object sender, EventArgs e)
        {
            if (txtsearch.Text != "" || txtFrom1.Value != string.Empty || txtTo1.Value != string.Empty || Convert.ToInt32(ddlClients.SelectedValue) > 1)
            {
                BindControls();
            }
        }


        private void BindControls()
        {
            SearchText = txtsearch.Text;
            FromDate1 = DateTime.MinValue;
            ToDate1 = DateTime.MinValue;
            ClientId = Convert.ToInt32(ddlClients.SelectedValue);

            if (txtFrom1.Value != "")
            {
                FromDate1 = DateHelper.ParseDate(txtFrom1.Value).Value;
            }

            if (txtTo1.Value != "")
            {
                ToDate1 = DateHelper.ParseDate(txtTo1.Value).Value;
            }
            if (!string.IsNullOrEmpty(Request.QueryString["PageIndex"]))
            {
                this.HyperLinkPager1.PageIndex = Convert.ToInt32(Request.QueryString["PageIndex"]);
            }
            else
            {
                this.HyperLinkPager1.PageIndex = 0;
            }

            int TotalRowCount = 0;


            List<InvoiceOrder> IOs = this.InvoiceControllerInstance.GetIKandiInvoiceOrders(HyperLinkPager1.PageSize, (!string.IsNullOrEmpty(Request.QueryString["PageIndex"])) ? Convert.ToInt32(Request.QueryString["PageIndex"]) : 0, out TotalRowCount, ClientId, FromDate1, ToDate1, SearchText);

            this.HyperLinkPager1.TotalRecords = TotalRowCount;
            int TotalPageCount = this.HyperLinkPager1.CalculateTotalPages();

            grdikandiInvoicing.DataSource = IOs;
            grdikandiInvoicing.DataBind();



        }
    }
}