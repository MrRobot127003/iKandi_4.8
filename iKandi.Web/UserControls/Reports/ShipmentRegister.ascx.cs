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
    public partial class ShipmentRegister : BaseUserControl
    { 
   
        //DataSet dsCIFContracts;
        //DataTable dtCIFContracts;
        //int count = 0;

        //protected void Page_Load(object sender, EventArgs e)
        //{
        //    if (!IsPostBack)
        //    {
        //        BindControls();
        //    }

        //}

        //protected void btnGo_click(object sender, EventArgs e)
        //{
        //    BindControls();
        //}

        //protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    iKandi.BLL.Configuration.Configuration config = new iKandi.BLL.Configuration.Configuration();
        //    int i = 0;
        //    GridView grid = (GridView)sender;
        //    //if (e.Row.RowType == DataControlRowType.Header)
        //    //{

        //    //    for (i = 0; i < e.Row.Cells.Count; i++)
        //    //    {
        //    //        if (e.Row.Cells[i].Text.Contains("Placed"))
        //    //        {
        //    //            e.Row.Cells[i].Text = "PLACED";
        //    //        }
        //    //        else if (e.Row.Cells[i].Text.Contains("Shipped"))
        //    //        {
        //    //            e.Row.Cells[i].Text = "SHIPPED";
        //    //        }
        //    //    }

        //    //}

        //    //if (e.Row.RowType == DataControlRowType.DataRow)
        //    //{
        //    //    e.Row.Cells[0].BackColor = System.Drawing.ColorTranslator.FromHtml("#F9ddf4");

        //    //    if (e.Row.RowIndex == count - 1 || e.Row.Cells[0].Text == "Total")
        //    //    {
        //    //        e.Row.Cells[0].CssClass = "bold_text";
        //    //    }
        //    //    for (i = 1; i < e.Row.Cells.Count; i++)
        //    //    {

        //    //        if (e.Row.RowIndex == count - 1 || e.Row.Cells[0].Text == "Total")
        //    //        {
        //    //            e.Row.Cells[i].BackColor = System.Drawing.ColorTranslator.FromHtml("#F9DDF4");
        //    //            e.Row.Cells[i].CssClass = "quantity_style";
        //    //        }
        //    //        else
        //    //        {
        //    //            e.Row.Cells[i].CssClass = "font_color_blue";
        //    //        }
        //    //    }

        //    //    for (i = 1; i < e.Row.Cells.Count; i = i + 2)
        //    //    {
        //    //        if (e.Row.Cells[i].Text != "&nbsp;")
        //    //        {
        //    //            e.Row.Cells[i].Text = Math.Round(Convert.ToDouble(e.Row.Cells[i].Text), 0) == 0 ? string.Empty : Convert.ToDouble(e.Row.Cells[i].Text).ToString("N0");
        //    //            if (i < e.Row.Cells.Count - 1)
        //    //            {
        //    //                e.Row.Cells[i + 1].Text = Math.Round(Convert.ToDouble(e.Row.Cells[i + 1].Text), 0) == 0 ? string.Empty : Convert.ToDouble(e.Row.Cells[i + 1].Text).ToString("N0");
        //    //            }
        //    //        }
        //    //    }
        //    //}
        //}


        //public void BindControls()
        //{
        //    dsCIFContracts = new DataSet();
        //    dtCIFContracts = new DataTable();

        //    if (!IsPostBack)
        //    {
        //        //DropdownHelper.BindProductionUnits(ddlProductionUnits);
        //        //DropdownHelper.BindClients(ddlClients);
        //    }


        //    dsCIFContracts = this.ReportControllerInstance.GetCIFContracts();


        //    // to bind grid
        //    count = dsCIFContracts.Tables[0].Rows.Count;
        //    gvCIFContracts.DataSource = dsCIFContracts;
        //    gvCIFContracts.DataBind();

        //}


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

            HiddenField hdnMode = e.Row.FindControl("hdnMode") as HiddenField;
            HiddenField hdnEx = e.Row.FindControl("hdnEx") as HiddenField;
            HiddenField hdnDC = e.Row.FindControl("hdnDC") as HiddenField;

            DateTime exFactory = DateTime.MinValue;
            DateTime dcDate =  DateTime.MinValue;
            int mode = Convert.ToInt32(hdnMode.Value);

            if (!string.IsNullOrEmpty(hdnEx.Value))
            {
                exFactory = DateHelper.ParseDate(hdnEx.Value).Value;
            }

            if (!string.IsNullOrEmpty(hdnDC.Value))
            {
                dcDate = DateHelper.ParseDate(hdnDC.Value).Value;
            }
           
            HtmlAnchor hypSerial = e.Row.FindControl("hypSerial") as HtmlAnchor;
            (hypSerial.Parent as TableCell).BackColor = System.Drawing.ColorTranslator.FromHtml(Constants.GetSerialNumberColor(exFactory));

            if(mode != 0)
            {
                (hdnMode.Parent as TableCell).BackColor = System.Drawing.ColorTranslator.FromHtml(CommonHelper.GetDeliveryModeColor(mode));
                (hdnEx.Parent as TableCell).BackColor = System.Drawing.ColorTranslator.FromHtml(CommonHelper.GetExFactoryColor(exFactory, dcDate, mode));
            }

            Label lblUnit = e.Row.FindControl("lblUnit") as Label;
            string code = lblUnit.Text.ToString();
            if (code != string.Empty)
            {
                (lblUnit.Parent as TableCell).BackColor = System.Drawing.ColorTranslator.FromHtml(ApplicationHelper.GetUnitColor(code));
            }
        }
        public void BindControls()
        {
            if (!IsPostBack)
            {
                DropdownHelper.BindAllClients(ddlClients as ListControl);
            }
            DateTime startDate = tbStart.Text.Trim() != string.Empty ? DateHelper.ParseDate(tbStart.Text).Value : DateTime.MinValue;
            DateTime endDate = tbEnd.Text.Trim() != string.Empty ? DateHelper.ParseDate(tbEnd.Text).Value : DateTime.MaxValue;
            Session["StartDate"] = startDate;
            Session["EndDate"] = endDate;

            //            GridView1.DataSource = this.ReportControllerInstance.GetWeeklyShipmentsReport(GridView1.PageIndex*GridView1.PageSize, GridView1.PageSize,
            //startDate, endDate);
            GridView1.DataBind();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            hdnPagesize.Value = GridView1.PageSize.ToString();
            hdnPageIndex.Value = GridView1.PageIndex.ToString();
            BindControls();
        }

        //protected String GetHtmlEncode(String strFabric)
        //{
        //    return strFabric.Replace('"', '\"');
        //}

        protected void btnGo_click(object sender, EventArgs e)
        {
            GridView1.PageIndex = 0;
            BindControls();
        }
    }
}