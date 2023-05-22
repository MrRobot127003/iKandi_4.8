using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using iKandi.Web.Components;

namespace iKandi.Web.Internal.Merchandising
{
    public partial class RemainFinishingQty : System.Web.UI.Page
    {
        iKandi.BLL.OrderController ord = new BLL.OrderController();
        public int OrderDetailId
        {
            get;
            set;
        }

        public int Unitid
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

                if (null != Request.QueryString["unitid"])
                {
                    Unitid = Convert.ToInt32(Request.QueryString["unitid"]);
                }

                if (null != Request.QueryString["StyleId"])
                {
                    StyleId = Convert.ToInt32(Request.QueryString["StyleId"]);
                }

                DataSet dsAllocation = new DataSet();

                dsAllocation = ord.GetReAllocationDetailsById(OrderDetailId, Unitid);
                gvReAllocation.DataSource = dsAllocation.Tables[7];
                gvReAllocation.DataBind();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            int AddQty = 0, MinusQty = 0, UnitQty = 0, SumAddQty = 0, SumMinQty = 0, RemainFinishQty = 0, SumRemainFinishQty = 0, ActualUnitQty = 0, FinishQty = 0, TotalUnAssignFinishQty = 0;
            try
            {
                if (null != Request.QueryString["OrderDetailId"])
                {
                    OrderDetailId = Convert.ToInt32(Request.QueryString["OrderDetailId"]);
                }

                if (null != Request.QueryString["unitid"])
                {
                    Unitid = Convert.ToInt32(Request.QueryString["unitid"]);
                }

                if (null != Request.QueryString["StyleId"])
                {
                    StyleId = Convert.ToInt32(Request.QueryString["StyleId"]);
                }

                foreach (GridViewRow gvr in gvReAllocation.Rows)
                {
                    TextBox txtreshflueplus = (TextBox)gvr.FindControl("txtreshflueplus");
                    TextBox txtRemainFinishQty = (TextBox)gvr.FindControl("txtRemainFinishQty");
                    TextBox txtFinishQty = (TextBox)gvr.FindControl("txtFinishQty");
                    TextBox txtreshflueminus = (TextBox)gvr.FindControl("txtreshflueminus");
                    Label lblUnitQty = (Label)gvr.FindControl("lblUnitQty");
                    HiddenField hdnTotalUnAssignFinishQty = (HiddenField)gvr.FindControl("hdnTotalUnAssignFinishQty");

                    if (txtRemainFinishQty.Text != "")
                    {
                        RemainFinishQty = Convert.ToInt32((txtRemainFinishQty.Text).Replace(",", ""));
                        SumRemainFinishQty = SumRemainFinishQty + RemainFinishQty;
                    }

                    if (txtreshflueplus.Text != "")
                    {
                        AddQty = Convert.ToInt32(txtreshflueplus.Text.Replace(",", ""));
                        SumAddQty = SumAddQty + AddQty;
                    }

                    if (txtreshflueminus.Text != null)
                    {
                        MinusQty = Convert.ToInt32(txtreshflueminus.Text.Replace(",", ""));
                        SumMinQty = SumMinQty + MinusQty;
                    }

                    if (Convert.ToInt32(hdnTotalUnAssignFinishQty.Value) > 0 && hdnTotalUnAssignFinishQty.Value != null)
                    {
                        TotalUnAssignFinishQty = Convert.ToInt32(hdnTotalUnAssignFinishQty.Value.Replace(",", ""));
                    }

                    ActualUnitQty = Convert.ToInt32((lblUnitQty.Text).Replace(",", ""));
                    FinishQty = Convert.ToInt32((txtFinishQty.Text).Replace(",", ""));
                    UnitQty = Convert.ToInt32((lblUnitQty.Text).Replace(",", ""));
                    UnitQty = UnitQty + (AddQty - MinusQty);
                }

                if (SumAddQty > 0 && SumMinQty > 0)
                {
                    lblnm.Text = "You cannot add and remove quantity at the same time.";
                    return;
                }
                else if (RemainFinishQty > 0 && SumAddQty > RemainFinishQty)
                {
                    lblnm.Text = "You cannot add more than Remain Finish Quantity.";
                    return;
                }
                else if (RemainFinishQty > 0 && SumMinQty > RemainFinishQty)
                {
                    lblnm.Text = "You cannot remove more than Remain Finish Quantity.";
                    return;
                }
                else if (Request.QueryString["UnAssignFinishingQty"] != null)
                {
                    if (Convert.ToInt32(Request.QueryString["UnAssignFinishingQty"]) < SumAddQty)
                    {
                        lblnm.Text = "You cannot add more than Total UnAssigned Quantity.";
                        return;
                    }
                }
                else if (TotalUnAssignFinishQty <= 0 && SumAddQty > 0 && Request.QueryString["UnAssignFinishingQty"] == null)
                {
                    lblnm.Text = "You cannot add more than Total UnAssigned Quantity.";
                    return;
                }
                else if (TotalUnAssignFinishQty < SumAddQty && Request.QueryString["UnAssignFinishingQty"] == null)
                {
                    lblnm.Text = "You cannot add more than Total UnAssigned Quantity.";
                    return;
                }

                foreach (GridViewRow gvr in gvReAllocation.Rows)
                {
                    SumAddQty = 0;
                    SumMinQty = 0;

                    TextBox txtreshflueplus = (TextBox)gvr.FindControl("txtreshflueplus");
                    TextBox txtRemainFinishQty = (TextBox)gvr.FindControl("txtRemainFinishQty");
                    TextBox txtreshflueminus = (TextBox)gvr.FindControl("txtreshflueminus");
                    Label lblUnitQty = (Label)gvr.FindControl("lblUnitQty");

                    if (txtRemainFinishQty.Text != "")
                    {
                        RemainFinishQty = Convert.ToInt32((txtRemainFinishQty.Text).Replace(",", ""));
                        SumRemainFinishQty = SumRemainFinishQty + RemainFinishQty;
                    }

                    if (txtreshflueplus.Text != "")
                    {
                        AddQty = Convert.ToInt32(txtreshflueplus.Text.Replace(",", ""));
                        SumAddQty = SumAddQty + AddQty;
                    }

                    if (txtreshflueminus.Text != null)
                    {
                        MinusQty = Convert.ToInt32(txtreshflueminus.Text.Replace(",", ""));
                        SumMinQty = SumMinQty + MinusQty;
                    }

                    UnitQty = Convert.ToInt32((lblUnitQty.Text).Replace(",", ""));
                    UnitQty = UnitQty + (AddQty - MinusQty);

                    int UserID = ApplicationHelper.LoggedInUser.UserData.UserID;

                    ord.UpdateFinishingQty(Unitid, OrderDetailId, UnitQty, UserID);
                }

                //ScriptManager.RegisterStartupScript(this, this.GetType(), "Close", "window.top.location.replace('/Internal/Merchandising/ReAllocationForm.aspx?styleId=" + Convert.ToInt32(StyleId) + "');", true);
                // change by surendra2 on 04-04-2018
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Close", "window.top.location.reload();", true);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
            }
        }

        protected void gvReAllocation_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                TextBox txtRemainFinishQty = (TextBox)e.Row.FindControl("txtRemainFinishQty");
                TextBox txtreshflueplus = (TextBox)e.Row.FindControl("txtreshflueplus");
                TextBox txtreshflueminus = (TextBox)e.Row.FindControl("txtreshflueminus");
                HiddenField hdnTotalUnAssignFinishQty = (HiddenField)e.Row.FindControl("hdnTotalUnAssignFinishQty");

                if (Convert.ToInt32(txtRemainFinishQty.Text.Replace(",", "")) <= 0 && Convert.ToInt32(hdnTotalUnAssignFinishQty.Value.Replace(",", "")) <= 0)
                {
                    txtreshflueplus.Enabled = false;
                    txtreshflueminus.Enabled = false;
                }
            }
        }
    }
}