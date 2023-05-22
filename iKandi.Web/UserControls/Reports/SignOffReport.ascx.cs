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
    public partial class SignOffReport : BaseUserControl
    {
        DataSet ds = new DataSet();

        protected void Page_Load(object sender, EventArgs e)
        {          
            BindControls();
        }

        public void BindControls()
        {
            if (!IsPostBack)
            {
                DropdownHelper.BindClients(ddlClients);
            }
            hdnPagesize.Value = GridView1.PageSize.ToString();
            hdnPageIndex.Value = GridView1.PageIndex.ToString();
            ds = this.ReportControllerInstance.GetSignOff(Convert.ToInt32(ddlClients.SelectedValue));

            GridView1.DataSource = ds;
            GridView1.DataBind();
        }

        protected void GridView1_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            hdnPagesize.Value = GridView1.PageSize.ToString();
            hdnPageIndex.Value = GridView1.PageIndex.ToString();
            BindControls();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindControls();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.DataRow)
                return;

            if (ds.Tables.Count > 0)
            {
                int Pageindex = GridView1.PageIndex;
                int index = Pageindex * 10 + e.Row.RowIndex;

                Label lblStatus = e.Row.FindControl("lblStatus") as Label;
                if (ds.Tables[0].Rows[index]["StatusModeID"] != DBNull.Value && ds.Tables[0].Rows[index]["StatusModeID"].ToString().Trim() != string.Empty)
                    (lblStatus.Parent as TableCell).BackColor = System.Drawing.ColorTranslator.FromHtml(Constants.GetStatusModeColor(Convert.ToInt32(ds.Tables[0].Rows[index]["StatusModeID"])));
                
                Label lblOFMerchandisingMgr = e.Row.FindControl("lblOFMerchandisingMgr") as Label;
                if (ds.Tables[0].Rows[index]["OrderMerchMgr"] != DBNull.Value && Convert.ToBoolean(ds.Tables[0].Rows[index]["OrderMerchMgr"]) == true)
                {
                    (lblOFMerchandisingMgr.Parent as TableCell).BackColor = System.Drawing.ColorTranslator.FromHtml("#01CC01");
                }

                Label lblOFBiplSalesMgr = e.Row.FindControl("lblOFBiplSalesMgr") as Label;
                if (ds.Tables[0].Rows[index]["OrderSalesMgr"] != DBNull.Value && Convert.ToBoolean(ds.Tables[0].Rows[index]["OrderSalesMgr"]) == true)
                {
                    (lblOFBiplSalesMgr.Parent as TableCell).BackColor = System.Drawing.ColorTranslator.FromHtml("#01CC01");
                }

                Label lblFFAccountMgr = e.Row.FindControl("lblFFAccountMgr") as Label;
                if (ds.Tables[0].Rows[index]["FabricOrderAccountMgr"] != DBNull.Value && Convert.ToBoolean(ds.Tables[0].Rows[index]["FabricOrderAccountMgr"]) == true)
                {
                    (lblFFAccountMgr.Parent as TableCell).BackColor = System.Drawing.ColorTranslator.FromHtml("#01CC01");
                }

                Label lblFFFabricMgr = e.Row.FindControl("lblFFFabricMgr") as Label;
                if (ds.Tables[0].Rows[index]["FabricOrderFabMgr"] != DBNull.Value && Convert.ToBoolean(ds.Tables[0].Rows[index]["FabricOrderFabMgr"]) == true)
                {
                    (lblFFFabricMgr.Parent as TableCell).BackColor = System.Drawing.ColorTranslator.FromHtml("#01CC01");
                }

                Label lblAFAccountMgr = e.Row.FindControl("lblAFAccountMgr") as Label;
                if (ds.Tables[0].Rows[index]["AcceryOrderAccountMgr"] != DBNull.Value && ds.Tables[0].Rows[index]["AcceryOrderAccountMgr"].ToString().Trim() != string.Empty && Convert.ToInt32(ds.Tables[0].Rows[index]["AcceryOrderAccountMgr"].ToString().Trim()) != 0)
                {
                    (lblAFAccountMgr.Parent as TableCell).BackColor = System.Drawing.ColorTranslator.FromHtml("#01CC01");
                }

                Label lblAFAccessoryMgr = e.Row.FindControl("lblAFAccessoryMgr") as Label;
                if (ds.Tables[0].Rows[index]["AcceryOrderAccMgr"] != DBNull.Value && ds.Tables[0].Rows[index]["AcceryOrderAccMgr"].ToString().Trim() != string.Empty && Convert.ToInt32(ds.Tables[0].Rows[index]["AcceryOrderAccMgr"].ToString().Trim()) != 0)
                {
                    (lblAFAccessoryMgr.Parent as TableCell).BackColor = System.Drawing.ColorTranslator.FromHtml("#01CC01");
                }

                Label lblOLFFabricMgr = e.Row.FindControl("lblOLFFabricMgr") as Label;
                if (ds.Tables[0].Rows[index]["OrderLimitationFabMgr"] != DBNull.Value && Convert.ToBoolean(ds.Tables[0].Rows[index]["OrderLimitationFabMgr"]) == true)
                {
                    (lblOLFFabricMgr.Parent as TableCell).BackColor = System.Drawing.ColorTranslator.FromHtml("#01CC01");
                }

                Label lblOLFAccessoryMgr = e.Row.FindControl("lblOLFAccessoryMgr") as Label;
                if (ds.Tables[0].Rows[index]["OrderLimitationAccMgr"] != DBNull.Value && Convert.ToBoolean(ds.Tables[0].Rows[index]["OrderLimitationAccMgr"]) == true)
                {
                    (lblOLFAccessoryMgr.Parent as TableCell).BackColor = System.Drawing.ColorTranslator.FromHtml("#01CC01");
                }

                Label lblOLFProdMgr = e.Row.FindControl("lblOLFProdMgr") as Label;
                if (ds.Tables[0].Rows[index]["OrderLimitationProdMgr"] != DBNull.Value && Convert.ToBoolean(ds.Tables[0].Rows[index]["OrderLimitationProdMgr"]) == true)
                {
                    (lblOLFProdMgr.Parent as TableCell).BackColor = System.Drawing.ColorTranslator.FromHtml("#01CC01");
                }
                
                Label lblOLFMerchandMgr = e.Row.FindControl("lblOLFMerchandMgr") as Label;
                if (ds.Tables[0].Rows[index]["OrderLimitationMarchMgr"] != DBNull.Value && Convert.ToBoolean(ds.Tables[0].Rows[index]["OrderLimitationMarchMgr"]) == true)
                {
                    (lblOLFMerchandMgr.Parent as TableCell).BackColor = System.Drawing.ColorTranslator.FromHtml("#01CC01");
                }
            }
        }

        protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                GridView HeaderGrid = (GridView)sender;
                GridViewRow HeaderGridRow =
                new GridViewRow(0, 0, DataControlRowType.Header,
                DataControlRowState.Insert);

                TableCell HeaderCell = new TableCell();

                HeaderCell = new TableCell();

                HeaderCell.Text = "Basic Info.";
                HeaderCell.CssClass = "extra_header";
                HeaderCell.ColumnSpan = 8;
                HeaderGridRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Order Form";
                HeaderCell.CssClass = "extra_header";
                HeaderCell.ColumnSpan = 2;
                HeaderGridRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Fabric Order form ";
                HeaderCell.CssClass = "extra_header";
                HeaderCell.ColumnSpan = 2;
                HeaderGridRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Accessory Order Form";
                HeaderCell.CssClass = "extra_header";
                HeaderCell.ColumnSpan = 2;
                HeaderGridRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Order Limitation Form";
                HeaderCell.CssClass = "extra_header";
                HeaderCell.ColumnSpan = 4;
                HeaderGridRow.Cells.Add(HeaderCell);
                
                GridView1.Controls[0].Controls.AddAt
                (0, HeaderGridRow);
            }
        }
    }
}