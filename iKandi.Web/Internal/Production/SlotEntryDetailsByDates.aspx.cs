using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iKandi.BLL.Production;
using System.Data;
using System.IO;
using System.Text;
using System.Web.UI.HtmlControls;
using System.Drawing;
using iKandi.Web.Components;
using iKandi.Common;


namespace iKandi.Web.Internal.Production
{
    public partial class SlotEntryDetailsByDates : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindDdlDate();
                ddlslotdate.SelectedValue = DateTime.Now.ToShortDateString();
                BindGrd();
                
            }
        }
        public void BindDdlDate()
        {
            List<ListItem> items = new List<ListItem>();
            for (int i = -31; i <= 2; i++)
            {
                if (i == 1)
                {
                    break;
                }
                items.Add(new ListItem(DateTime.Now.AddDays(i).ToShortDateString(), DateTime.Now.AddDays(i).ToShortDateString()));
            }
            ddlslotdate.DataSource = items;
            ddlslotdate.DataBind();
            ddlslotdate.Items[4].Selected = true;//currebr
        }
        public void BindGrd()
        {
            ProductionController objProductionController = new ProductionController();
            DataSet ds = objProductionController.GetSlotEntryDetails(Convert.ToDateTime(ddlslotdate.SelectedValue));
            DataTable dt = ds.Tables[0];
            GrdSlotEntry.DataSource = dt;
            GrdSlotEntry.DataBind();

            DataTable dtcluster = ds.Tables[1];
            grdcluster.DataSource = dtcluster;
            grdcluster.DataBind();


            // MergeRows(GrdSlotEntry);
        }
        protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            BindGrd();
        }
        protected void GrdSlotEntry_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HyperLink lnkContractNo = (HyperLink)e.Row.FindControl("lnkContractNo");
                if (lnkContractNo != null)
                {
                    DataRowView drv = (DataRowView)e.Row.DataItem;
                    string SlotDate = ddlslotdate.SelectedValue;
                    string LinePlanningID = drv["LinePlanningID"].ToString();
                    string OrderDetailsID = drv["OrderDetailsID"].ToString();
                    string UnitId = drv["UnitID"].ToString();
                    if ((ApplicationHelper.LoggedInUser.UserData.Designation == Designation.BIPL_GM_IE)||(ApplicationHelper.LoggedInUser.UserData.Designation == Designation.BIPL_Sales_Manager))
                    {
                        lnkContractNo.Enabled = true;
                        lnkContractNo.NavigateUrl = "~/Internal/Production/SlotEntryDetailsByDatesUpdate.aspx?UnitId=" + UnitId.ToString() + "&LinePlanningID=" + LinePlanningID.ToString() + "&SlotCreateDate=" +
                        Server.UrlEncode(SlotDate.ToString()) + "&OrderDetailsID=" + OrderDetailsID.ToString();
                    }
                }

            }
        }
        protected void GrdSlotEntry_DataBound(object sender, EventArgs e)
        {
            for (int i = GrdSlotEntry.Rows.Count - 1; i > 0; i--)
            {
                GridViewRow row = GrdSlotEntry.Rows[i];
                GridViewRow previousRow = GrdSlotEntry.Rows[i - 1];

                Label lblEntity = (Label)row.Cells[0].FindControl("lblUnit");
                Label lblPreviousEntity = (Label)previousRow.Cells[0].FindControl("lblUnit");

                if (lblEntity.Text == lblPreviousEntity.Text)
                {
                    if (previousRow.Cells[0].RowSpan == 0)
                    {
                        if (row.Cells[0].RowSpan == 0)
                        {
                            previousRow.Cells[0].RowSpan += 2;
                        }
                        else
                        {
                            previousRow.Cells[0].RowSpan = row.Cells[0].RowSpan + 1;
                        }
                        row.Cells[0].Visible = false;
                    }
                }
            }
        }
        protected void grdcluster_DataBound(object sender, EventArgs e)
        {
            for (int i = grdcluster.Rows.Count - 1; i > 0; i--)
            {
                GridViewRow row = grdcluster.Rows[i];
                GridViewRow previousRow = grdcluster.Rows[i - 1];

                Label lblEntity = (Label)row.Cells[0].FindControl("lblUnit");
                Label lblPreviousEntity = (Label)previousRow.Cells[0].FindControl("lblUnit");

                if (lblEntity.Text == lblPreviousEntity.Text)
                {
                    if (previousRow.Cells[0].RowSpan == 0)
                    {
                        if (row.Cells[0].RowSpan == 0)
                        {
                            previousRow.Cells[0].RowSpan += 2;
                        }
                        else
                        {
                            previousRow.Cells[0].RowSpan = row.Cells[0].RowSpan + 1;
                        }
                        row.Cells[0].Visible = false;
                    }
                }
            }
        }

        protected void grdcluster_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HyperLink lnkContractNo = (HyperLink)e.Row.FindControl("lnkContractNo");
                if (lnkContractNo != null)
                {
                    DataRowView drv = (DataRowView)e.Row.DataItem;
                    string SlotDate = ddlslotdate.SelectedValue;
                    string ClusterId = drv["ClusterId"].ToString();
                    string OrderDetailsID = drv["OrderDetailsID"].ToString();
                    string UnitId = drv["UnitID"].ToString();
                    //if (iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.UserID.ToString() == "646")
                    if ((ApplicationHelper.LoggedInUser.UserData.Designation == Designation.BIPL_GM_IE) || (ApplicationHelper.LoggedInUser.UserData.Designation == Designation.BIPL_Sales_Manager))
                    {
                        lnkContractNo.Enabled = true;
                        lnkContractNo.NavigateUrl = "~/Internal/Production/SlotEntryDetailsByDatesUpdate.aspx?UnitId=" + UnitId.ToString() + "&ClusterId=" + ClusterId.ToString() + "&SlotCreateDate=" +
                        Server.UrlEncode(SlotDate.ToString()) + "&OrderDetailsID=" + OrderDetailsID.ToString();
                    }
                }

            }

        }

    }
}
