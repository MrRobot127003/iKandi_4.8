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
    public partial class CIFContracts : BaseUserControl
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
                BindControls();
            }

        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.DataRow)
                return;          

            DateTime exFactory = Convert.ToDateTime(DataBinder.Eval(e.Row.DataItem, "ExFactory"));
            DateTime dc = Convert.ToDateTime(DataBinder.Eval(e.Row.DataItem, "DC"));
            int mode = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Mode"));
            int statusModeId = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "StatusModeID"));

            Label lblSerialNo = e.Row.FindControl("lblSerialNo") as Label;
            (lblSerialNo.Parent as TableCell).BackColor = System.Drawing.ColorTranslator.FromHtml(Constants.GetSerialNumberColor(exFactory));
             
            HtmlControl spanstatusmode = e.Row.FindControl("spanstatusmode") as HtmlControl;
            (spanstatusmode.Parent as TableCell).BackColor = System.Drawing.ColorTranslator.FromHtml(Constants.GetStatusModeColor(statusModeId));

            HiddenField lblEx = e.Row.FindControl("lblEx") as HiddenField;
            (lblEx.Parent as TableCell).BackColor = System.Drawing.ColorTranslator.FromHtml(iKandi.BLL.CommonHelper.GetExFactoryColor(exFactory, dc, mode));
            
                       
        }
        public void BindControls()
        {
            if (!IsPostBack)
            {
                DropdownHelper.BindYears(ddlYears as ListControl);
                DropdownHelper.BindMonths(ddlMonths as ListControl);
            }
            GridView1.DataSource = this.ReportControllerInstance.GetCIFContracts(
                Convert.ToInt32(ddlMonths.SelectedValue), Convert.ToInt32(ddlYears.SelectedValue));
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
            BindControls();
        }
    }
}