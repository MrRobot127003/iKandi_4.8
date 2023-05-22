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
    public partial class RemainCuttingQty : System.Web.UI.Page
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
                gvReAllocation.DataSource = dsAllocation.Tables[5];
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
            int AddQty = 0, MinusQty = 0, UnitQty = 0, SumAddQty = 0, SumMinQty = 0, RemainCutQty = 0, SumRemainCutQty = 0, ActualUnitQty = 0, CutQty = 0, TotalUnAssignCutQty = 0;
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
                    TextBox txtRemainCutQty = (TextBox)gvr.FindControl("txtRemainCutQty");
                    TextBox txtCutQty = (TextBox)gvr.FindControl("txtCutQty");
                    TextBox txtreshflueminus = (TextBox)gvr.FindControl("txtreshflueminus");
                    Label lblUnitQty = (Label)gvr.FindControl("lblUnitQty");
                    HiddenField hdnTotalUnAssignCutQty = (HiddenField)gvr.FindControl("hdnTotalUnAssignCutQty");

                    if (txtRemainCutQty.Text != "")
                    {
                        RemainCutQty = Convert.ToInt32((txtRemainCutQty.Text).Replace(",", ""));
                        SumRemainCutQty = SumRemainCutQty + RemainCutQty;
                    }

                    if (txtreshflueplus.Text != "")
                    {
                        AddQty = Convert.ToInt32(txtreshflueplus.Text);
                        SumAddQty = SumAddQty + AddQty;
                    }

                    if (txtreshflueminus.Text != null)
                    {
                        MinusQty = Convert.ToInt32(txtreshflueminus.Text);
                        SumMinQty = SumMinQty + MinusQty;
                    }

                    if (Convert.ToInt32(hdnTotalUnAssignCutQty.Value) > 0 && hdnTotalUnAssignCutQty.Value != null)
                    {
                        TotalUnAssignCutQty = Convert.ToInt32(hdnTotalUnAssignCutQty.Value);
                    }

                    ActualUnitQty = Convert.ToInt32((lblUnitQty.Text).Replace(",", ""));
                    CutQty = Convert.ToInt32((txtCutQty.Text).Replace(",", ""));
                    UnitQty = Convert.ToInt32((lblUnitQty.Text).Replace(",", ""));
                    UnitQty = UnitQty + (AddQty - MinusQty);
                }

                if (SumAddQty > 0 && SumMinQty > 0)
                {
                    lblnm.Text = "You cannot add and remove quantity at the same time.";
                    return;
                }
                else if (RemainCutQty > 0 && SumAddQty > RemainCutQty)
                {
                    lblnm.Text = "You cannot add more than Remain Cut Quantity.";
                    return;
                }
                else if (RemainCutQty > 0 && SumMinQty > RemainCutQty)
                {
                    lblnm.Text = "You cannot remove more than Remain Cut Quantity.";
                    return;
                }
                else if (Request.QueryString["UnAssignCuttingQty"] != null)
                {
                    if (Convert.ToInt32(Request.QueryString["UnAssignCuttingQty"]) < SumAddQty)
                    {
                        lblnm.Text = "You cannot add more than Total UnAssigned Quantity.";
                        return;
                    }
                }
                else if (TotalUnAssignCutQty <= 0 && SumAddQty > 0 && Request.QueryString["UnAssignCuttingQty"] == null)
                {
                    lblnm.Text = "You cannot add more than Total UnAssigned Quantity.";
                    return;
                }
                else if (TotalUnAssignCutQty < SumAddQty && Request.QueryString["UnAssignCuttingQty"] == null)
                {
                    lblnm.Text = "You cannot add more than Total UnAssigned Quantity.";
                    return;
                }

                foreach (GridViewRow gvr in gvReAllocation.Rows)
                {
                    SumAddQty = 0;
                    SumMinQty = 0;

                    TextBox txtreshflueplus = (TextBox)gvr.FindControl("txtreshflueplus");
                    TextBox txtRemainCutQty = (TextBox)gvr.FindControl("txtRemainCutQty");
                    TextBox txtreshflueminus = (TextBox)gvr.FindControl("txtreshflueminus");
                    Label lblUnitQty = (Label)gvr.FindControl("lblUnitQty");

                    if (txtRemainCutQty.Text != "")
                    {
                        RemainCutQty = Convert.ToInt32((txtRemainCutQty.Text).Replace(",", ""));
                        SumRemainCutQty = SumRemainCutQty + RemainCutQty;
                    }

                    if (txtreshflueplus.Text != "")
                    {
                        AddQty = Convert.ToInt32(txtreshflueplus.Text);
                        SumAddQty = SumAddQty + AddQty;
                    }

                    if (txtreshflueminus.Text != null)
                    {
                        MinusQty = Convert.ToInt32(txtreshflueminus.Text);
                        SumMinQty = SumMinQty + MinusQty;
                    }

                    UnitQty = Convert.ToInt32((lblUnitQty.Text).Replace(",", ""));
                    UnitQty = UnitQty + (AddQty - MinusQty);

                    int UserID = ApplicationHelper.LoggedInUser.UserData.UserID;
                    ord.UpdateCuttingQty(Unitid, OrderDetailId, UnitQty, UserID);
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
                TextBox txtRemainCutQty = (TextBox)e.Row.FindControl("txtRemainCutQty");
                TextBox txtreshflueplus = (TextBox)e.Row.FindControl("txtreshflueplus");
                TextBox txtreshflueminus = (TextBox)e.Row.FindControl("txtreshflueminus");
                HiddenField hdnTotalUnAssignCutQty = (HiddenField)e.Row.FindControl("hdnTotalUnAssignCutQty");

                if (Convert.ToInt32((txtRemainCutQty.Text).Replace(",", "")) <= 0 && Convert.ToInt32(hdnTotalUnAssignCutQty.Value) <= 0)
                {
                    txtreshflueplus.Enabled = false;
                    txtreshflueminus.Enabled = false;
                }
            }
        }
    }
}