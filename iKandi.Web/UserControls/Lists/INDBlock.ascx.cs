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
using iKandi.BLL;
using iKandi.Common;
using iKandi.Web.Components;
using System.Collections.Generic;

namespace iKandi.Web.UserControls.Lists
{
    public partial class INDBlock : BaseUserControl
    {
        # region Fields

        

        # endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            BindControls();

        }

        private void BindControls()
        {
            if (!IsPostBack)
            {
                DropdownHelper.BindAllClients(ddlClients);
                //if (ddlClients.Items.Count > 1)
                //    ddlClients.SelectedIndex = 1;
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

            List<iKandi.Common.INDBlock> objBlocks = this.INDBlockControllerInstance.GetAllBlocks(HyperLinkPager1.PageSize, (!string.IsNullOrEmpty(Request.QueryString["PageIndex"])) ? Convert.ToInt32(Request.QueryString["PageIndex"]) : 0, out TotalRowCount, Convert.ToInt32(ddlClients.SelectedValue), txtSearch.Text);
            grdPrint.DataSource = objBlocks;
            grdPrint.DataBind();

            this.HyperLinkPager1.TotalRecords = TotalRowCount;
            int TotalPageCount = this.HyperLinkPager1.CalculateTotalPages();

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindControls();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.DataRow)
                return;
            iKandi.Common.INDBlock block = (e.Row.DataItem as iKandi.Common.INDBlock);

            Label lblCurrency = e.Row.FindControl("lblCurrency") as Label;
            lblCurrency.Text = Constants.GetCurrencySign(Enum.GetName(typeof(Currency), block.BlockCostCurrency));


        }






    }
}