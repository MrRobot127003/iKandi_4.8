using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;
using iKandi.Common;
using iKandi.Web.Components;
using iKandi.BLL;

namespace iKandi.Web.Internal.Merchandising
{
    public partial class AllocatedWithFactory : System.Web.UI.Page
    {
        iKandi.BLL.OrderController ord = new BLL.OrderController();
        public int OrderDetailId
        {
            get;
            set;
        }

        public int StyleId
        {
            get;
            set;
        }
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                BindlineGrid();
            }
        }

        private void BindlineGrid()
        {
            try
            {
                if (null != Request.QueryString["OrderDetailId"])
                {
                    OrderDetailId = Convert.ToInt32(Request.QueryString["OrderDetailId"]);
                }

                if (null != Request.QueryString["StyleId"])
                {
                    StyleId = Convert.ToInt32(Request.QueryString["StyleId"]);
                }

                DataSet dsAllocation = new DataSet();
                DataRow drAllocation = null;

                dsAllocation = ord.GetReAllocationDetailsById(OrderDetailId, 0);
                lblTotalQty.Text = dsAllocation.Tables[0].Rows[0]["TotalQty"].ToString();

                dsAllocation.Tables[0].Columns.Add(new DataColumn("Column1", typeof(string)));
                dsAllocation.Tables[0].Columns.Add(new DataColumn("Column2", typeof(string)));
                dsAllocation.Tables[0].Columns.Add(new DataColumn("Column3", typeof(string)));
                dsAllocation.Tables[0].Columns.Add(new DataColumn("Column4", typeof(string)));
                dsAllocation.Tables[0].Columns.Add(new DataColumn("Column5", typeof(string)));
                dsAllocation.Tables[0].Columns.Add(new DataColumn("Column6", typeof(string)));

                if (dsAllocation.Tables[0].Rows.Count == 0)
                {
                    drAllocation = dsAllocation.Tables[0].NewRow();

                    drAllocation["Column1"] = string.Empty;
                    drAllocation["Column2"] = string.Empty;
                    drAllocation["Column3"] = string.Empty;
                    drAllocation["Column4"] = string.Empty;
                    drAllocation["Column5"] = string.Empty;
                    drAllocation["Column6"] = string.Empty;
                    dsAllocation.Tables[0].Rows.Add(drAllocation);
                }

                ViewState["dtReAllocationUnit"] = dsAllocation.Tables[0];

                gvReAllocation.DataSource = dsAllocation.Tables[0];
                gvReAllocation.DataBind();

                ViewState["UnallocatedQty"] = dsAllocation.Tables[3].Rows[0]["Totalunallocated"].ToString();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
            }
        }

        protected void gvReAllocation_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.DataRow)
                return;

            DropDownList ddlFactory = (DropDownList)e.Row.FindControl("ddlFactory");
            TextBox txtUnAllocated = (TextBox)e.Row.FindControl("txtUnAllocated");
            HiddenField hdnUnit = (HiddenField)e.Row.FindControl("hdnUnit");
            HiddenField hdnReallocationID = (HiddenField)e.Row.FindControl("hdnReallocationID");
            Label lblLineQty = (Label)e.Row.FindControl("lblLineQty");

            int ReAllocationId = 0;
            if (hdnReallocationID != null)
            {
                if (hdnReallocationID.Value != "")
                {
                    ReAllocationId = Convert.ToInt32(hdnReallocationID.Value);
                }
                else
                {
                    ReAllocationId = 0;
                }
            }

            if (null != Request.QueryString["OrderDetailId"])
            {
                OrderDetailId = Convert.ToInt32(Request.QueryString["OrderDetailId"]);
            }

            DataSet dtReAllocationUnit = new DataSet();
            OrderController OrderControllerInstance = new OrderController();
            dtReAllocationUnit = OrderControllerInstance.GetReAllocationUnit(OrderDetailId, ReAllocationId);

            ddlFactory.DataSource = dtReAllocationUnit.Tables[0];
            ddlFactory.DataValueField = "UnitID";
            ddlFactory.DataTextField = "UnitName";
            ddlFactory.DataBind();

            if (dtReAllocationUnit.Tables[1].Rows.Count > 1)
            {
                int unitId = Convert.ToInt32(dtReAllocationUnit.Tables[1].Rows[1]["UnitID"].ToString());
                ddlFactory.SelectedValue = unitId.ToString();
                ddlFactory.Enabled = Convert.ToInt32((lblLineQty.Text).Replace(",", "")) > 0 ? false : true;
            }
            OrderControllerInstance = null;
        }

        protected void ddlFactory_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddl = sender as DropDownList;
            GridViewRow row = ddl.NamingContainer as GridViewRow;
            int rowIndex = row.RowIndex;

            DropDownList ddlFactory = (DropDownList)gvReAllocation.Rows[rowIndex].FindControl("ddlFactory");

            for (int j = 0; j < gvReAllocation.Rows.Count; j++)
            {
                DropDownList ddlCheckFactory = (DropDownList)gvReAllocation.Rows[j].FindControl("ddlFactory");

                if (ddlCheckFactory.SelectedValue == ddlFactory.SelectedValue && j != rowIndex && ddlFactory.SelectedValue != "-1")
                {
                    ddlFactory.SelectedValue = "-1";
                    Page page = HttpContext.Current.Handler as Page;
                    ScriptManager.RegisterStartupScript(page, page.GetType(), "err_msg", "alert('You can not select this factory because it is already selected.');", true);
                    return;
                }
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            AddNewRow();
        }

        private void AddNewRow()
        {
            int rowIndex = 0;
            if (ViewState["dtReAllocationUnit"] != null)
            {
                DataTable dtCurrentReAllocationUnit = (DataTable)ViewState["dtReAllocationUnit"];
                DataRow drCurrentReAllocationUnitRow = null;
                if (dtCurrentReAllocationUnit.Rows.Count > 0)
                {
                    for (int i = 1; i <= dtCurrentReAllocationUnit.Rows.Count; i++)
                    {
                        DropDownList ddlFactory = (DropDownList)gvReAllocation.Rows[rowIndex].Cells[1].FindControl("ddlFactory");
                        Label lblUnAllocatedQty = (Label)gvReAllocation.Rows[rowIndex].Cells[2].FindControl("lblUnAllocatedQty");
                        Label lblLineQty = (Label)gvReAllocation.Rows[rowIndex].Cells[3].FindControl("lblLineQty");
                        TextBox txtUnAllocated = (TextBox)gvReAllocation.Rows[rowIndex].Cells[4].FindControl("txtUnAllocated");
                        HiddenField hdnUnit = (HiddenField)gvReAllocation.Rows[rowIndex].Cells[4].FindControl("hdnUnit");
                        HiddenField hdnReallocationID = (HiddenField)gvReAllocation.Rows[rowIndex].Cells[4].FindControl("hdnReallocationID");

                        int iBlankRow = 0;
                        for (int j = 0; j < gvReAllocation.Rows.Count; j++)
                        {
                            if (Convert.ToInt32(ddlFactory.SelectedValue) == -1 && txtUnAllocated.Text == "")
                            {
                                iBlankRow++;
                            }
                        }

                        if (iBlankRow > 0)
                        {
                            Page page = HttpContext.Current.Handler as Page;
                            ScriptManager.RegisterStartupScript(page, page.GetType(), "err_msg", "alert('Blank row need to be filled first.');", true);
                            return;
                        }
                        else
                        {
                            lblnm.Text = "";
                        }

                        drCurrentReAllocationUnitRow = dtCurrentReAllocationUnit.NewRow();

                        dtCurrentReAllocationUnit.Rows[i - 1]["Column1"] = ddlFactory.SelectedValue;
                        dtCurrentReAllocationUnit.Rows[i - 1]["Column2"] = lblUnAllocatedQty.Text;
                        dtCurrentReAllocationUnit.Rows[i - 1]["Column3"] = lblLineQty.Text;
                        dtCurrentReAllocationUnit.Rows[i - 1]["Column4"] = txtUnAllocated.Text;
                        dtCurrentReAllocationUnit.Rows[i - 1]["Column5"] = hdnUnit.Value;
                        dtCurrentReAllocationUnit.Rows[i - 1]["Column6"] = hdnReallocationID.Value;

                        rowIndex++;
                    }

                    dtCurrentReAllocationUnit.Rows.Add(drCurrentReAllocationUnitRow);

                    ViewState["dtReAllocationUnit"] = dtCurrentReAllocationUnit;

                    gvReAllocation.DataSource = dtCurrentReAllocationUnit;
                    gvReAllocation.DataBind();
                }
            }
            else
            {
                Response.Write("ViewState is null");
            }

            SetPreviousDataSet();
        }

        private void SetPreviousDataSet()
        {
            int rowIndex = 0;

            if (ViewState["dtReAllocationUnit"] != null)
            {
                DataTable dtReAllocationUnit = (DataTable)ViewState["dtReAllocationUnit"];
                if (dtReAllocationUnit.Rows.Count > 0)
                {
                    for (int i = 0; i < dtReAllocationUnit.Rows.Count; i++)
                    {
                        DropDownList ddlFactory = (DropDownList)gvReAllocation.Rows[rowIndex].Cells[1].FindControl("ddlFactory");
                        Label lblUnAllocatedQty = (Label)gvReAllocation.Rows[rowIndex].Cells[2].FindControl("lblUnAllocatedQty");
                        Label lblLineQty = (Label)gvReAllocation.Rows[rowIndex].Cells[3].FindControl("lblLineQty");
                        TextBox txtUnAllocated = (TextBox)gvReAllocation.Rows[rowIndex].Cells[4].FindControl("txtUnAllocated");
                        HiddenField hdnUnit = (HiddenField)gvReAllocation.Rows[rowIndex].Cells[4].FindControl("hdnUnit");
                        HiddenField hdnReallocationID = (HiddenField)gvReAllocation.Rows[rowIndex].Cells[4].FindControl("hdnReallocationID");

                        ddlFactory.SelectedValue = dtReAllocationUnit.Rows[i]["Column1"].ToString();

                        lblUnAllocatedQty.Text = dtReAllocationUnit.Rows[i]["Column2"].ToString();
                        lblLineQty.Text = dtReAllocationUnit.Rows[i]["Column3"].ToString();
                        txtUnAllocated.Text = dtReAllocationUnit.Rows[i]["Column4"].ToString();
                        hdnUnit.Value = dtReAllocationUnit.Rows[i]["Column5"].ToString();
                        hdnReallocationID.Value = dtReAllocationUnit.Rows[i]["Column6"].ToString();

                        rowIndex++;
                    }
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                int TotalResuffleQty = 0, TotalUnAllocatedQty = 0;

                if (null != Request.QueryString["OrderDetailId"])
                {
                    OrderDetailId = Convert.ToInt32(Request.QueryString["OrderDetailId"]);
                }

                if (null != Request.QueryString["StyleId"])
                {
                    StyleId = Convert.ToInt32(Request.QueryString["StyleId"]);
                }

                bool Validate = true;

                foreach (GridViewRow gvr in gvReAllocation.Rows)
                {
                    DropDownList ddlFactory = (DropDownList)gvr.FindControl("ddlFactory");
                    Label lblUnAllocatedQty = (Label)gvr.FindControl("lblUnAllocatedQty");
                    TextBox txtUnAllocated = (TextBox)gvr.FindControl("txtUnAllocated");

                    if (Convert.ToInt32(ddlFactory.SelectedValue) <= 0)
                    {
                        Validate = false;
                    }

                    if (lblUnAllocatedQty.Text != "")
                    {
                        TotalUnAllocatedQty = TotalUnAllocatedQty + Convert.ToInt32((lblUnAllocatedQty.Text).Replace(",", ""));
                    }

                    if (txtUnAllocated.Text != "")
                    {
                        TotalResuffleQty = TotalResuffleQty + Convert.ToInt32((txtUnAllocated.Text).Replace(",", ""));
                    }
                }

                if (Validate)
                {
                    DataSet dsAllocation = new DataSet();
                    dsAllocation = ord.GetReAllocationDetailsById(OrderDetailId, 0);

                    int NotAssignedStitchingShare = Convert.ToInt32(dsAllocation.Tables[6].Rows[0]["NotAssignedStitchingShare"]);

                    if (NotAssignedStitchingShare > 0)
                    {
                        if (TotalResuffleQty > NotAssignedStitchingShare)
                        {
                            Page page = HttpContext.Current.Handler as Page;
                            ScriptManager.RegisterStartupScript(page, page.GetType(), "err_msg", "alert('You cannot add more than '" + NotAssignedStitchingShare.ToString() + "' in Not Loaded Qty. Please Check.');", true);
                            Validate = false;
                        }
                    }
                    else
                    {
                        if (TotalUnAllocatedQty < TotalResuffleQty)
                        {
                            Page page = HttpContext.Current.Handler as Page;
                            ScriptManager.RegisterStartupScript(page, page.GetType(), "err_msg", "alert('Total Reshuffle Not Loaded Qty cannot be greater then Not Loaded Qty. Please Check.');", true);
                            Validate = false;
                        }
                        if (TotalUnAllocatedQty > TotalResuffleQty)
                        {
                            Page page = HttpContext.Current.Handler as Page;
                            ScriptManager.RegisterStartupScript(page, page.GetType(), "err_msg", "alert('Total Reshuffle Not Loaded Qty cannot be less then Not Loaded Qty. Please Check.');", true);
                            Validate = false;
                        }
                    }
                }

                if (Validate)
                {
                    foreach (GridViewRow gvr in gvReAllocation.Rows)
                    {
                        TotalResuffleQty = 0;

                        DropDownList ddlFactory = (DropDownList)gvr.FindControl("ddlFactory");
                        Label lblUnAllocatedQty = (Label)gvr.FindControl("lblUnAllocatedQty");
                        Label lblLineQty = (Label)gvr.FindControl("lblLineQty");
                        TextBox txtUnAllocated = (TextBox)gvr.FindControl("txtUnAllocated");

                        txtUnAllocated.Text = txtUnAllocated.Text == "" ? "0" : txtUnAllocated.Text;
                        lblLineQty.Text = lblLineQty.Text == "" ? "0" : lblLineQty.Text;
                        //if (txtUnAllocated.Text != "")
                        //{
                        TotalResuffleQty = Convert.ToInt32((txtUnAllocated.Text).Replace(",", "")) + Convert.ToInt32((lblLineQty.Text).Replace(",", ""));
                        //}
                        int UserID = ApplicationHelper.LoggedInUser.UserData.UserID;
                        int Result = ord.UpdatelineQty_unitQty(TotalResuffleQty, Convert.ToInt32(ddlFactory.SelectedValue), OrderDetailId, "unitQty", 0, UserID);
                    }
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "Close", "window.top.location.replace('/Internal/Merchandising/ReAllocationForm.aspx?styleId=" + Convert.ToInt32(StyleId) + "');", true);
                    // change by surendra2 on 04-04-2018
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Close", "window.top.location.reload();", true);
                }

            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
            }
        }
    }
}