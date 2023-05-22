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
using iKandi.BLL;

namespace iKandi.Web
{
    public partial class WeeklyShipment : BaseUserControl
    {

        public string searchText
        {
            get;
            set;
        }

        public DateTime FromDate
        {
            get;
            set;
        }

        public DateTime ToDate
        {
            get;
            set;
        }
        public int ClientId
        {
            get;
            set;
        }

        public int DateType
        {
            get;
            set;
        }

        public int StatusMode
        {
            get;
            set;
        }

        public int StatusModeSequence
        {
            get;
            set;
        }

        public int OrderBy1
        {
            get;
            set;
        }

        public int OrderBy2
        {
            get;
            set;
        }

        public int OrderBy3
        {
            get;
            set;
        }

        public int OrderBy4
        {
            get;
            set;
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            hdnPagesize.Value = GridView1.PageSize.ToString();
            hdnPageIndex.Value = GridView1.PageIndex.ToString();
            if (!IsPostBack)
            {
                tbStart.Text = DateTime.Today.AddDays(-7).ToString("dd MMM yy (ddd)");
                tbEnd.Text = DateTime.Today.ToString("dd MMM yy (ddd)");
                BindControls();
            }

        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.DataRow)
                return;

            DateTime exFactory = DataBinder.Eval(e.Row.DataItem, "ExFactory") != DBNull.Value ? Convert.ToDateTime(DataBinder.Eval(e.Row.DataItem, "ExFactory")) : DateTime.MinValue;
            DateTime actionDate = DataBinder.Eval(e.Row.DataItem, "ActionDate") != DBNull.Value ? Convert.ToDateTime(DataBinder.Eval(e.Row.DataItem, "ActionDate")) : DateTime.MinValue;
            int mode = (DataBinder.Eval(e.Row.DataItem, "Mode") != DBNull.Value) ? Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Mode")) : -1;

            HtmlAnchor hypSerial = e.Row.FindControl("hypSerial") as HtmlAnchor;
            (hypSerial.Parent as TableCell).BackColor = System.Drawing.ColorTranslator.FromHtml(Constants.GetSerialNumberColor(actionDate));

            Label lblMode = e.Row.FindControl("lblMode") as Label;
            (lblMode.Parent as TableCell).BackColor = System.Drawing.ColorTranslator.FromHtml(CommonHelper.GetDeliveryModeColor(mode));

            HiddenField lblEx = e.Row.FindControl("lblEx") as HiddenField;
            (lblEx.Parent as TableCell).BackColor = System.Drawing.ColorTranslator.FromHtml(Constants.GetActualDateColor(exFactory, actionDate));

            Label lblUnit = e.Row.FindControl("lblUnit") as Label;
            string code = lblUnit.Text.ToString();
            if (code != string.Empty)
            {
                (lblUnit.Parent as TableCell).BackColor = System.Drawing.ColorTranslator.FromHtml(ApplicationHelper.GetUnitColor(code));
            }

            int sign = (DataBinder.Eval(e.Row.DataItem, "ConvertTo") != DBNull.Value && DataBinder.Eval(e.Row.DataItem, "ConvertTo").ToString().Trim() != string.Empty) ? Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "ConvertTo")) : -1;
            string currencySymbal = iKandi.Common.Constants.GetCurrencySymbalByCurrencyType(sign);

            Label lblPriceInFCSymbal = e.Row.FindControl("lblPriceInFCSymbal") as Label;
            lblPriceInFCSymbal.Text = currencySymbal;

            Label lblAmountInFCSign = e.Row.FindControl("lblAmountInFCSign") as Label;
            lblAmountInFCSign.Text = currencySymbal;


        }
        public void BindControls()
        {
            if (!IsPostBack)
            {
                DropdownHelper.BindClients(ddlClients as ListControl);
            }
            DateTime startDate = tbStart.Text.Trim() != string.Empty ? DateHelper.ParseDate(tbStart.Text).Value : DateTime.MinValue;
            DateTime endDate = tbEnd.Text.Trim() != string.Empty ? DateHelper.ParseDate(tbEnd.Text).Value : DateTime.MaxValue;
            Session["StartDate"] = startDate;
            Session["EndDate"] = endDate;
            GridView1.DataBind();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            hdnPagesize.Value = GridView1.PageSize.ToString();
            hdnPageIndex.Value = GridView1.PageIndex.ToString();
            BindControls();
        }

        protected String GetHtmlEncode(String strFabric)
        {
            return strFabric.Replace('"', '\"');
        }

        protected void btnGo_click(object sender, EventArgs e)
        {
            GridView1.PageIndex = 0;
            BindControls();
        }
    }
}