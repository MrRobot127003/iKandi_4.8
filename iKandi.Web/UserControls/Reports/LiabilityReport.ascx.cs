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


namespace iKandi.Web
{
    public partial class LiabilityReport : BaseUserControl
    {
        DataSet ds = new DataSet();
        int year;

        protected void Page_Load(object sender, EventArgs e)
        {            
            BindControls();
        }

        private void FillBuyers()
        {
            ddlBuyer.DataSource = this.PrintControllerInstance.GetAllClientForBuyingHouseBAL(0,0);
            ddlBuyer.DataTextField = "companyname";
            ddlBuyer.DataValueField = "ClientId";
            ddlBuyer.DataBind();
        }
        private void BindControls()
        {
            if (!IsPostBack)
            {                
                DropdownHelper.BindYears(ddlYear as ListControl);
                ddlYear.SelectedValue = DateTime.Now.Year.ToString();
                DropdownHelper.BindAllClients(ddlClients);

                FillBuyers();
                

                pnlLiabilitySearchForm.Visible = PermissionHelper.IsReadPermitted((int)AppModule.LIABILITY_FORM);
                
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

            DateTime fromDate = DateTime.MinValue;
            DateTime toDate = DateTime.MinValue;

            if (!string.IsNullOrEmpty(txtFromDate.Text))
                fromDate = DateHelper.ParseDate(txtFromDate.Text).Value;
            if (!string.IsNullOrEmpty(txtToDate.Text))
                toDate = DateHelper.ParseDate(txtToDate.Text).Value;

            if (Convert.ToInt32(ddlYear.SelectedValue) == -1)
            {
                year = DateTime.Now.Year;
            }
            else
            {
                year = Convert.ToInt32(ddlYear.SelectedValue);
            }

            ds = this.LiabilityControllerInstance.GetLiabilityReport(HyperLinkPager1.PageSize, this.HyperLinkPager1.PageIndex, out TotalRowCount, Convert.ToInt32(ddlPaymentStatus.SelectedValue), fromDate, toDate, year,Convert.ToInt32(ddlBuyer.SelectedValue),txtSearch.Text);
         //   ViewState["tblLiability"] = ds.Tables[0];
            grdLiability.DataSource = ds.Tables[0];
            grdLiability.DataBind();

            this.HyperLinkPager1.TotalRecords = TotalRowCount;
            int TotalPageCount = this.HyperLinkPager1.CalculateTotalPages();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindControls();
        }

        protected void grdLiability_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.DataRow)
                return;
         //   DataTable dt = (DataTable)ViewState["tblLiability"];



            Label lblFab1Price = e.Row.FindControl("lblFab1Price") as Label;
            Label lblFab2Price = e.Row.FindControl("lblFab2Price") as Label;
            Label lblFab3Price = e.Row.FindControl("lblFab3Price") as Label;
            Label lblFab4Price = e.Row.FindControl("lblFab4Price") as Label;
            Label lblFab1PriceSign = e.Row.FindControl("lblFab1PriceSign") as Label;
            Label lblFab2PriceSign = e.Row.FindControl("lblFab2PriceSign") as Label;
            Label lblFab3PriceSign = e.Row.FindControl("lblFab3PriceSign") as Label;
            Label lblFab4PriceSign = e.Row.FindControl("lblFab4PriceSign") as Label;
            Label lblFab1Qty = e.Row.FindControl("lblFab1Qty") as Label;
            Label lblFab2Qty = e.Row.FindControl("lblFab2Qty") as Label;
            Label lblFab3Qty = e.Row.FindControl("lblFab3Qty") as Label;
            Label lblFab4Qty = e.Row.FindControl("lblFab4Qty") as Label;
            Label lblCancelCost = e.Row.FindControl("lblCancelCost") as Label;
            Label lblCancelCostSign = e.Row.FindControl("lblCancelCostSign") as Label;
            Label LabelInNo = e.Row.FindControl("LabelInNo") as Label;
            Label lblQtyCancelled = e.Row.FindControl("lblQtyCancelled") as Label;
            Label lblCancelledDate = e.Row.FindControl("lblCancelledDate") as Label;
            Label lblInvoiceDate = e.Row.FindControl("lblInvoiceDate") as Label;
            Label lblRaisedOn = e.Row.FindControl("lblRaisedOn") as Label;
            Label lblNextActionDate = e.Row.FindControl("lblNextActionDate") as Label;
            Label lblAcknowledgedOn = e.Row.FindControl("lblAcknowledgedOn") as Label;
            Label lblHoldTillDate = e.Row.FindControl("lblHoldTillDate") as Label;
            Label lblAcceptedOn = e.Row.FindControl("lblAcceptedOn") as Label;
            Label lblInvoiceRaisedOn = e.Row.FindControl("lblInvoiceRaisedOn") as Label;
       //     Label lblAsse = e.Row.FindControl("lblAsscesoriesLiabilityAmount") as Label;



            Label lblLiabilitySign = e.Row.FindControl("lblAsscesoriesLiabilitySign") as Label;
            Label lblFabricSign = e.Row.FindControl("lblFabricLiabilitySign") as Label;

            int sign = -1;
            string currencySign = "&pound;";
            DateTime CreatedOn = DateTime.MinValue;

            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {

                  //  if (ds.Tables[0].Rows[e.Row.RowIndex]["ConvertTo"] != DBNull.Value && ds.Tables[0].Rows[e.Row.RowIndex]["ConvertTo"].ToString() != string.Empty)
                  //  {
                  //      sign = Convert.ToInt32(ds.Tables[0].Rows[e.Row.RowIndex]["ConvertTo"]);
                  //  }

                    iKandi.Common.Liability liability = this.LiabilityControllerInstance.GetLiabilityData(-1, Convert.ToInt32(ds.Tables[0].Rows[e.Row.RowIndex]["Id"]));
                    double doubleAccessoryLiability = 0;
                    for(int i=0;i<=liability.AccessoryLiability.Count-1;i++)
                        doubleAccessoryLiability = doubleAccessoryLiability + liability.AccessoryLiability[i].Amount;
                 //   lblAsse.Text = Convert.ToString(doubleAccessoryLiability);

                    if (ds.Tables[0].Rows[e.Row.RowIndex]["ConvertTo"] != DBNull.Value && ds.Tables[0].Rows[e.Row.RowIndex]["ConvertTo"].ToString() != string.Empty)
                    {
                        sign = Convert.ToInt32(ds.Tables[0].Rows[e.Row.RowIndex]["ConvertTo"]);
                    }

                    currencySign = iKandi.Common.Constants.GetCurrencySymbalByCurrencyType(sign);

                    if (ds.Tables[0].Rows[e.Row.RowIndex]["Fabric1Price"] == DBNull.Value)
                        lblFab1Price.Text = "0";
                    else if (ds.Tables[0].Rows[e.Row.RowIndex]["Fabric1Price"].ToString() == string.Empty)
                        lblFab1Price.Text = "0";
                    else
                        lblFab1Price.Text = Convert.ToDecimal(ds.Tables[0].Rows[e.Row.RowIndex]["Fabric1Price"]).ToString("N2");

                    if (lblFab1Price.Text != string.Empty)
                    {
                        lblFab1PriceSign.Text  = currencySign;
                        lblLiabilitySign.Text = currencySign;
                        lblFabricSign.Text = currencySign;
                    }

                    if (ds.Tables[0].Rows[e.Row.RowIndex]["Fabric2Price"] == DBNull.Value)
                        lblFab2Price.Text = "0";
                    else if (ds.Tables[0].Rows[e.Row.RowIndex]["Fabric2Price"].ToString() == string.Empty)
                        lblFab2Price.Text = "0";
                    else
                        lblFab2Price.Text = Convert.ToDecimal(ds.Tables[0].Rows[e.Row.RowIndex]["Fabric2Price"]).ToString("N2");

                    if (lblFab2Price.Text != string.Empty)
                    {
                        lblFab2PriceSign.Text = currencySign;





                    }

                    if (ds.Tables[0].Rows[e.Row.RowIndex]["Fabric3Price"] == DBNull.Value)
                        lblFab3Price.Text = "0";
                    else if (ds.Tables[0].Rows[e.Row.RowIndex]["Fabric3Price"].ToString() == string.Empty)
                        lblFab3Price.Text = "0";
                    else
                        lblFab3Price.Text = Convert.ToDecimal(ds.Tables[0].Rows[e.Row.RowIndex]["Fabric3Price"]).ToString("N2");

                    if( lblFab3Price.Text != string.Empty)
                    {
                       lblFab3PriceSign.Text = currencySign;
                    }

                    if (ds.Tables[0].Rows[e.Row.RowIndex]["Fabric4Price"] == DBNull.Value)
                        lblFab4Price.Text = "0";
                    else if (ds.Tables[0].Rows[e.Row.RowIndex]["Fabric4Price"].ToString() == string.Empty)
                        lblFab4Price.Text = "0";
                    else
                        lblFab4Price.Text = Convert.ToDecimal(ds.Tables[0].Rows[e.Row.RowIndex]["Fabric4Price"]).ToString("N2");

                    if(lblFab4Price.Text != string.Empty)
                    {
                      lblFab4PriceSign.Text = currencySign;
                    }

                    if (ds.Tables[0].Rows[e.Row.RowIndex]["Fabric1Quantity"] == DBNull.Value)
                        lblFab1Qty.Text = "0";
                    else if (ds.Tables[0].Rows[e.Row.RowIndex]["Fabric1Quantity"] == DBNull.Value)
                        lblFab1Qty.Text = "0";
                    else
                        lblFab1Qty.Text = Convert.ToInt32(ds.Tables[0].Rows[e.Row.RowIndex]["Fabric1Quantity"]).ToString("N2");

                    if (ds.Tables[0].Rows[e.Row.RowIndex]["Fabric2Quantity"] == DBNull.Value)
                        lblFab2Qty.Text = "0";
                    else if (ds.Tables[0].Rows[e.Row.RowIndex]["Fabric2Quantity"] == DBNull.Value)
                        lblFab2Qty.Text = "0";
                    else
                        lblFab2Qty.Text = Convert.ToInt32(ds.Tables[0].Rows[e.Row.RowIndex]["Fabric2Quantity"]).ToString("N2");

                    if (ds.Tables[0].Rows[e.Row.RowIndex]["Fabric3Quantity"] == DBNull.Value)
                        lblFab3Qty.Text = "0";
                    else if (ds.Tables[0].Rows[e.Row.RowIndex]["Fabric3Quantity"].ToString() == string.Empty)
                        lblFab3Qty.Text = "0";
                    else
                        lblFab3Qty.Text = Convert.ToInt32(ds.Tables[0].Rows[e.Row.RowIndex]["Fabric3Quantity"]).ToString("N2");

                    if (ds.Tables[0].Rows[e.Row.RowIndex]["Fabric4Quantity"] == DBNull.Value)
                        lblFab4Qty.Text = "0";
                    else if (ds.Tables[0].Rows[e.Row.RowIndex]["Fabric4Quantity"].ToString() == string.Empty)
                        lblFab4Qty.Text = "0";
                    else
                        lblFab4Qty.Text = Convert.ToInt32(ds.Tables[0].Rows[e.Row.RowIndex]["Fabric4Quantity"]).ToString("N2");

                   // if (ds.Tables[0].Rows[e.Row.RowIndex]["CancellationCost"] == DBNull.Value)
                     //   lblCancelCost.Text = "0";
                  //  else if (ds.Tables[0].Rows[e.Row.RowIndex]["CancellationCost"].ToString() == string.Empty)
                  //      lblCancelCost.Text = "0";
                  //  else
                 //   {
                        double doubleFabricLiabilityPricetemp;
                        doubleFabricLiabilityPricetemp = (Convert.ToDouble(lblFab1Price.Text) * Convert.ToDouble(lblFab1Qty.Text));
                        doubleFabricLiabilityPricetemp = doubleFabricLiabilityPricetemp + (Convert.ToDouble(lblFab2Price.Text) * Convert.ToDouble(lblFab2Qty.Text));
                        doubleFabricLiabilityPricetemp = doubleFabricLiabilityPricetemp + (Convert.ToDouble(lblFab3Price.Text) * Convert.ToDouble(lblFab3Qty.Text));
                        doubleFabricLiabilityPricetemp = doubleFabricLiabilityPricetemp + (Convert.ToDouble(lblFab4Price.Text) * Convert.ToDouble(lblFab4Qty.Text));
                      
                     
                       // lblFabLiablityPrice.Text = Convert.ToString(doubleFabricLiabilityPrice);
                       // lblCancelCost.Text = Convert.ToDecimal(ds.Tables[0].Rows[e.Row.RowIndex]["CancellationCost"]).ToString("N2");
                       // lblCancelCost.Text = Convert.ToDecimal(doubleFabricLiabilityPricetemp) + Convert.ToDecimal(ds.Tables[0].Rows[e.Row.RowIndex]["TotalQty"]).ToString("N2");
                        Decimal df1 = Convert.ToDecimal(doubleFabricLiabilityPricetemp);
                        Decimal df2= Convert.ToDecimal(ds.Tables[0].Rows[e.Row.RowIndex]["TotalQty"].ToString());
                        decimal dfTotal = df1 + df2;
                        lblCancelCost.Text = dfTotal.ToString();
                  //  }
                    if(lblCancelCost.Text != string.Empty)
                    {
                        lblCancelCostSign.Text = currencySign;

                    }

                    if (ds.Tables[0].Rows[e.Row.RowIndex]["InvoiceNumber"] == DBNull.Value)
                        LabelInNo.Text = string.Empty;
                    else
                        LabelInNo.Text = (ds.Tables[0].Rows[e.Row.RowIndex]["InvoiceNumber"]).ToString();

                    if (ds.Tables[0].Rows[e.Row.RowIndex]["QuantityCancelled"] == DBNull.Value)
                        lblQtyCancelled.Text = "0";
                    else if (ds.Tables[0].Rows[e.Row.RowIndex]["QuantityCancelled"].ToString() == string.Empty)
                        lblQtyCancelled.Text = "0";
                    else
                        lblQtyCancelled.Text = Convert.ToInt32(ds.Tables[0].Rows[e.Row.RowIndex]["QuantityCancelled"]).ToString("N0");

                    if (ds.Tables[0].Rows[e.Row.RowIndex]["DateCancelled"] == DBNull.Value || ds.Tables[0].Rows[e.Row.RowIndex]["DateCancelled"].ToString() == string.Empty || Convert.ToDateTime(ds.Tables[0].Rows[e.Row.RowIndex]["DateCancelled"]) == DateTime.MinValue)
                        lblCancelledDate.Text = string.Empty;
                    else
                        lblCancelledDate.Text = Convert.ToDateTime(ds.Tables[0].Rows[e.Row.RowIndex]["DateCancelled"]).ToString("dd MMM yy (ddd)");

                    if (ds.Tables[0].Rows[e.Row.RowIndex]["InvoiceDate"] == DBNull.Value || Convert.ToDateTime(ds.Tables[0].Rows[e.Row.RowIndex]["InvoiceDate"]) == DateTime.MinValue)
                        lblInvoiceDate.Text = string.Empty;
                    else
                        lblInvoiceDate.Text = Convert.ToDateTime(ds.Tables[0].Rows[e.Row.RowIndex]["InvoiceDate"]).ToString("dd MMM yy (ddd)");

                    int IkandiAcknowledge;
                    if (ds.Tables[0].Rows[e.Row.RowIndex]["IkandiAcknowledge"] == DBNull.Value)
                    {
                        IkandiAcknowledge = 0;
                    }
                    else if (ds.Tables[0].Rows[e.Row.RowIndex]["IkandiAcknowledge"].ToString() == string.Empty)
                    {
                        IkandiAcknowledge = 0;
                    }
                    else
                    {
                        IkandiAcknowledge = Convert.ToInt32(ds.Tables[0].Rows[e.Row.RowIndex]["IkandiAcknowledge"]);
                    }


                    int AcceptanceToSettle;
                    if (ds.Tables[0].Rows[e.Row.RowIndex]["AcceptanceToSettle"] == DBNull.Value)
                    {
                        AcceptanceToSettle = 0;
                    }
                    else if (ds.Tables[0].Rows[e.Row.RowIndex]["AcceptanceToSettle"].ToString() == string.Empty)
                    {
                        AcceptanceToSettle = 0;
                    }
                    else
                    {
                        AcceptanceToSettle = Convert.ToInt32(ds.Tables[0].Rows[e.Row.RowIndex]["AcceptanceToSettle"]);
                    }

                    int RaiseCustomerInvoice;
                    if (ds.Tables[0].Rows[e.Row.RowIndex]["RaiseCustomerInvoice"] == DBNull.Value)
                    {
                        RaiseCustomerInvoice = 0;
                    }
                    else if (ds.Tables[0].Rows[e.Row.RowIndex]["RaiseCustomerInvoice"].ToString() == string.Empty)
                    {
                        RaiseCustomerInvoice = 0;
                    }
                    else
                    {
                        RaiseCustomerInvoice = Convert.ToInt32(ds.Tables[0].Rows[e.Row.RowIndex]["RaiseCustomerInvoice"]);
                    }


                    string Owner = string.Empty;
                    if (ds.Tables[0].Rows[e.Row.RowIndex]["Owner"] != DBNull.Value)
                    {
                        Owner = Convert.ToString(ds.Tables[0].Rows[e.Row.RowIndex]["Owner"]);
                    }


                    if (IkandiAcknowledge == 0)
                    {
                        if (ds.Tables[0].Rows[e.Row.RowIndex]["CreatedOn"] == DBNull.Value || Convert.ToDateTime(ds.Tables[0].Rows[e.Row.RowIndex]["CreatedOn"]) == DateTime.MinValue)
                        {
                            lblNextActionDate.Text = string.Empty;
                            lblRaisedOn.Text = string.Empty;
                        }
                        else
                        {
                            lblRaisedOn.Text = "Raised on: " + Convert.ToDateTime(ds.Tables[0].Rows[e.Row.RowIndex]["CreatedOn"]).ToString("dd MMM yy (ddd)");
                            CreatedOn = Convert.ToDateTime(ds.Tables[0].Rows[e.Row.RowIndex]["CreatedOn"]);
                            CreatedOn = CreatedOn.AddDays(1);
                            if (CreatedOn.DayOfWeek == DayOfWeek.Sunday)
                                CreatedOn = CreatedOn.AddDays(1);
                            else if (CreatedOn.DayOfWeek == DayOfWeek.Saturday)
                                CreatedOn = CreatedOn.AddDays(2);
                            lblNextActionDate.Text = "Next action date: " + CreatedOn.ToString("dd MMM yy (ddd)");
                        }

                        lblAcknowledgedOn.Text = string.Empty;
                        lblHoldTillDate.Text = string.Empty;
                        lblAcceptedOn.Text = string.Empty;
                        lblInvoiceRaisedOn.Text = string.Empty;
                    }

                    else if (IkandiAcknowledge == 1 && AcceptanceToSettle == 1 && Owner.ToUpper() == "IKANDI")
                    {
                        if (ds.Tables[0].Rows[e.Row.RowIndex]["SettlementDate"] == DBNull.Value || Convert.ToDateTime(ds.Tables[0].Rows[e.Row.RowIndex]["SettlementDate"]) == DateTime.MinValue)
                            lblAcceptedOn.Text = string.Empty;
                        else
                            lblAcceptedOn.Text = "Accepted on: " + Convert.ToDateTime(ds.Tables[0].Rows[e.Row.RowIndex]["SettlementDate"]).ToString("dd MMM yy (ddd)");


                        lblRaisedOn.Text = string.Empty;
                        lblNextActionDate.Text = string.Empty;
                        lblAcknowledgedOn.Text = string.Empty;
                        lblInvoiceRaisedOn.Text = string.Empty;
                    }
                    else if (IkandiAcknowledge == 1 && RaiseCustomerInvoice == 0)
                    {
                        if (ds.Tables[0].Rows[e.Row.RowIndex]["AcknowledgementDate"] == DBNull.Value || Convert.ToDateTime(ds.Tables[0].Rows[e.Row.RowIndex]["AcknowledgementDate"]) == DateTime.MinValue)
                            lblAcknowledgedOn.Text = string.Empty;
                        else
                            lblAcknowledgedOn.Text = "Acknowledged on: " + Convert.ToDateTime(ds.Tables[0].Rows[e.Row.RowIndex]["AcknowledgementDate"]).ToString("dd MMM yy (ddd)");

                        if (ds.Tables[0].Rows[e.Row.RowIndex]["HoldTillDate"] == DBNull.Value || Convert.ToDateTime(ds.Tables[0].Rows[e.Row.RowIndex]["HoldTillDate"]) == DateTime.MinValue)
                            lblHoldTillDate.Text = string.Empty;
                        else
                            lblHoldTillDate.Text = "Next action date :" + Convert.ToDateTime(ds.Tables[0].Rows[e.Row.RowIndex]["HoldTillDate"]).ToString("dd MMM yy (ddd)");
                        lblRaisedOn.Text = string.Empty;
                        lblNextActionDate.Text = string.Empty;
                        lblAcceptedOn.Text = string.Empty;
                        lblInvoiceRaisedOn.Text = string.Empty;
                    }

                    else if (IkandiAcknowledge == 1 && RaiseCustomerInvoice == 1)
                    {
                        if (ds.Tables[0].Rows[e.Row.RowIndex]["SettlementDate"] == DBNull.Value || Convert.ToDateTime(ds.Tables[0].Rows[e.Row.RowIndex]["SettlementDate"]) == DateTime.MinValue)
                            lblAcceptedOn.Text = string.Empty;
                        else
                            lblAcceptedOn.Text = "Accepted on :" + Convert.ToDateTime(ds.Tables[0].Rows[e.Row.RowIndex]["SettlementDate"]).ToString("dd MMM yy (ddd)");

                        if (ds.Tables[0].Rows[e.Row.RowIndex]["HoldTillDate"] == DBNull.Value || Convert.ToDateTime(ds.Tables[0].Rows[e.Row.RowIndex]["HoldTillDate"]) == DateTime.MinValue)
                            lblInvoiceRaisedOn.Text = string.Empty;
                        else
                            lblInvoiceRaisedOn.Text = "Raised Invoice on :" + Convert.ToDateTime(ds.Tables[0].Rows[e.Row.RowIndex]["HoldTillDate"]).ToString("dd MMM yy (ddd)");

                        lblAcknowledgedOn.Text = string.Empty;
                        lblHoldTillDate.Text = string.Empty;
                        lblRaisedOn.Text = string.Empty;
                        lblNextActionDate.Text = string.Empty;
                    }








                    double doubleFabricLiabilityPrice;
                    doubleFabricLiabilityPrice = (Convert.ToDouble(lblFab1Price.Text) * Convert.ToDouble(lblFab1Qty.Text));
                    doubleFabricLiabilityPrice = doubleFabricLiabilityPrice + (Convert.ToDouble(lblFab2Price.Text) * Convert.ToDouble(lblFab2Qty.Text));
                    doubleFabricLiabilityPrice = doubleFabricLiabilityPrice + (Convert.ToDouble(lblFab3Price.Text) * Convert.ToDouble(lblFab3Qty.Text));
                    doubleFabricLiabilityPrice = doubleFabricLiabilityPrice + (Convert.ToDouble(lblFab4Price.Text) * Convert.ToDouble(lblFab4Qty.Text));
                       Label lblFabLiablityPrice = e.Row.FindControl("lblFabricLiabilityPrice") as Label;
                       lblFabLiablityPrice.Text = Convert.ToString(doubleFabricLiabilityPrice);
                   
           




                   
                }
            }
        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {
            int TotalRowCount = 0;

            DateTime fromDate = DateTime.MinValue;
            DateTime toDate = DateTime.MinValue;

            if (!string.IsNullOrEmpty(txtFromDate.Text))
                fromDate = DateHelper.ParseDate(txtFromDate.Text).Value;
            if (!string.IsNullOrEmpty(txtToDate.Text))
                toDate = DateHelper.ParseDate(txtToDate.Text).Value;

            if (Convert.ToInt32(ddlYear.SelectedValue) == -1)
            {
                year = DateTime.Now.Year;
            }
            else
            {
                year = Convert.ToInt32(ddlYear.SelectedValue);
            }
            ds = this.LiabilityControllerInstance.GetLiabilityReport(100000, 0, out TotalRowCount, Convert.ToInt32(ddlPaymentStatus.SelectedValue), fromDate, toDate, year, Convert.ToInt32(ddlBuyer.SelectedValue), txtSearch.Text);
            string PDFfile = this.PDFControllerInstance.LiabilityFormGeneratePDF(ds.Tables[0]);
            this.RenderFile(PDFfile, "Liability Report.PDF", Constants.CONTENT_TYPE_PDF);
        }
    }
}