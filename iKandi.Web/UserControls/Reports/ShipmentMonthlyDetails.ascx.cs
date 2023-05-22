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
    public partial class ShipmentMonthlyDetails : BaseUserControl
    {
        int boutiqueBillingId = 0;
        int boutiqueBillingRowIndex = -1;
        double grandTotal = 0;
        double billValue = 0;
        int boutiqueBillingRowIndexForSupplyType = -1;
        string billTo = "";
       

        protected void Page_Load(object sender, EventArgs e)
        {

            hdnPagesize.Value = GridView1.PageSize.ToString();
            hdnPageIndex.Value = GridView1.PageIndex.ToString();
            if (!IsPostBack)
            {
                BindControls();
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Footer)
            {    
                for (int i = 1; i < 14; i++)
                {
                    e.Row.Cells.RemoveAt(0);
                }
                e.Row.Cells[0].Text = "Grand Total";
                e.Row.Cells[0].ColumnSpan = 14;
                e.Row.Cells[1].Text = "£" + grandTotal.ToString("N2");
                e.Row.CssClass = "extra_header";
                e.Row.Cells[0].CssClass = "extra_header";
                e.Row.Cells[1].CssClass = "extra_header numeric_text";
                e.Row.Cells[2].CssClass = "extra_header ";

                return;
            }

            if (e.Row.RowType != DataControlRowType.DataRow)
                return;

            int sign = (DataBinder.Eval(e.Row.DataItem, "ConvertTo") != DBNull.Value && DataBinder.Eval(e.Row.DataItem, "ConvertTo").ToString().Trim() != string.Empty) ? Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "ConvertTo")) : -1;
            string currencySymbal = iKandi.Common.Constants.GetCurrencySymbalByCurrencyType(sign);

            Label lblUnitPriceSign = e.Row.FindControl("lblUnitPriceSign") as Label;
            Label lblUnitPric = e.Row.FindControl("lblUnitPric") as Label;

            if (lblUnitPric.Text.ToString().Trim() != string.Empty)
            {
                lblUnitPriceSign.Text = currencySymbal;
            }

            Label lblFobValueSign = e.Row.FindControl("lblFobValueSign") as Label;
            Label lblFobValue = e.Row.FindControl("lblFobValue") as Label;

            if (lblFobValue.Text != string.Empty)
            {
                lblFobValueSign.Text = currencySymbal;
            }

            Label lblFreightSign = e.Row.FindControl("lblFreightSign") as Label;
            Label lblFreight = e.Row.FindControl("lblFreight") as Label;

            if (lblFreight.Text != string.Empty)
            {
                lblFreightSign.Text = currencySymbal;
            }

            Label lblInsuranceSign = e.Row.FindControl("lblInsuranceSign") as Label;
            Label lblInsurance = e.Row.FindControl("lblInsurance") as Label;

            if (lblInsurance.Text != string.Empty)
            {
                lblInsuranceSign.Text = currencySymbal;
            }

            Label lblCifSign = e.Row.FindControl("lblCifSign") as Label;
            Label lblTotalCif = e.Row.FindControl("lblTotalCif") as Label;

            if (lblTotalCif.Text != string.Empty)
            {
                lblCifSign.Text = currencySymbal;
            }
                        
            HiddenField hdnTotalBill = e.Row.FindControl("hdnTotalBill") as HiddenField;
            
            double ConversionRatio = 1.0;
            if (Enum.IsDefined(typeof(Currency), sign))
                ConversionRatio = iKandi.BLL.CommonHelper.GetCurrencyRate((Currency)sign, Currency.GBP);
            double value = Convert.ToDouble(hdnTotalBill.Value) * ConversionRatio;

            grandTotal += value;

            //code for merging data for a single column across multiple rows
            if (DataBinder.Eval(e.Row.DataItem, "BoutiqueBillingID") != DBNull.Value)
            {

                if (boutiqueBillingId == Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "BoutiqueBillingID")) && boutiqueBillingId > -1)
                {
                    billValue += value;
                    GridView1.Rows[boutiqueBillingRowIndex].Cells[14].Text = "&pound;" + billValue.ToString("N2");
                    GridView1.Rows[boutiqueBillingRowIndex].Cells[14].RowSpan += 1;
                    GridView1.Rows[boutiqueBillingRowIndex].Cells[15].RowSpan += 1;
                    e.Row.Cells[14].Visible = false;
                    e.Row.Cells[15].Visible = false;
                }
                else
                {
                    boutiqueBillingId = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "BoutiqueBillingID"));
                    boutiqueBillingRowIndex = e.Row.RowIndex;
                    billValue = value;
                    e.Row.Cells[14].Text = "&pound;" + (billValue).ToString("N2");
                    e.Row.Cells[14].RowSpan = 1;
                    e.Row.Cells[15].RowSpan = 1;
                }
            }

            Label lblBillTo = e.Row.FindControl("lblBillTo") as Label;

            if (billTo.ToUpper() == lblBillTo.Text.ToUpper())
            {
                GridView1.Rows[boutiqueBillingRowIndexForSupplyType].Cells[0].RowSpan += 1;
                e.Row.Cells[0].Visible = false;
            }
            else
            {
                billTo = lblBillTo.Text.ToUpper();
                boutiqueBillingRowIndexForSupplyType = e.Row.RowIndex;
                e.Row.Cells[0].RowSpan = 1;

            }

            DateTime exFactory = DataBinder.Eval(e.Row.DataItem, "ExFactory") != DBNull.Value ? Convert.ToDateTime(DataBinder.Eval(e.Row.DataItem, "ExFactory")) : DateTime.MinValue;


            if (exFactory != DateTime.MinValue)
            {
                HtmlAnchor hypSerial = e.Row.FindControl("hypSerial") as HtmlAnchor;
                (hypSerial.Parent as TableCell).BackColor = System.Drawing.ColorTranslator.FromHtml(Constants.GetSerialNumberColor(exFactory));

            }

        }
        public void BindControls()
        {
            if (!IsPostBack)
            {
                DropdownHelper.BindMonths(ddlMonths as ListControl);
                DropdownHelper.BindYears(ddlYears as ListControl);
                ddlMonths.SelectedValue = (Convert.ToInt32(DateTime.Today.Month)).ToString();
                ddlYears.SelectedValue = (Convert.ToInt32(DateTime.Today.Year)).ToString();
            }

            GridView1.DataBind();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            hdnPagesize.Value = GridView1.PageSize.ToString();
            hdnPageIndex.Value = GridView1.PageIndex.ToString();
            BindControls();
        }

        protected void btnGo_click(object sender, EventArgs e)
        {
            GridView1.PageIndex = 0;
            BindControls();
        }
    }
}