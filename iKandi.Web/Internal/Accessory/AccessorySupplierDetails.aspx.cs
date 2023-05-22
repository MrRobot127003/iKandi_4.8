using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iKandi.Common;
using iKandi.BLL;

namespace iKandi.Web.Internal.Accessory
{
    public partial class AccessorySupplierDetails : System.Web.UI.Page
    {
        private int AccessoryType, AccessoryMasterId;
        private string Size, ColorPrint;
        AccessoryWorkingController objAccessory = new AccessoryWorkingController();  
       
    
        protected void Page_Load(object sender, EventArgs e)
        {
            if (iKandi.Web.Components.ApplicationHelper.LoggedInUser == null || iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData == null)
                Response.Redirect("~/public/Login.aspx");

            getquerystring();
            if (!IsPostBack)
            {
                BindData();
            }
        }

        public void getquerystring()
        {
            if (Request.QueryString["AccessoryType"] != null)
            {
                AccessoryType = Convert.ToInt32(Request.QueryString["AccessoryType"]);
            }
            else
            {
                AccessoryType = 1;
            }
            if (Request.QueryString["AccessoryMasterId"] != null)
            {
                AccessoryMasterId = Convert.ToInt32(Request.QueryString["AccessoryMasterId"]);
            }
            else
            {
                AccessoryMasterId = -1;
            }
            if (Request.QueryString["Size"] != null)
            {
                Size = Request.QueryString["Size"].ToString();
            }
            else
            {
                Size = "";
            }
            if (Request.QueryString["ColorPrint"] != null)
            {
                ColorPrint = Request.QueryString["ColorPrint"].ToString();
            }
            else
            {
                ColorPrint = "";
            }
        }

        private void BindData()
        {
            List<AccessoryPending> AccessList = objAccessory.GetAccessory_SupplierDetails(AccessoryMasterId, Size, ColorPrint, AccessoryType);
            grdSupplier.DataSource = AccessList;
            grdSupplier.DataBind();
            if (AccessoryType == 3)
                grdSupplier.Columns[1].Visible = false;
        }

        protected void grdSupplier_DataBound(object sender, EventArgs e)
        {
            for (int i = grdSupplier.Rows.Count - 1; i > 0; i--)
            {
                GridViewRow row = grdSupplier.Rows[i];
                GridViewRow previousRow = grdSupplier.Rows[i - 1];
                string CurrentAccessory = "";
                string PreviousAccessory = "";

                HiddenField hdAccessoryMasterId = (HiddenField)row.FindControl("hdAccessoryMasterId");
                HiddenField hdnAccessoryQualitySize = (HiddenField)row.FindControl("hdnAccessoryQualitySize");
                CurrentAccessory = hdAccessoryMasterId.Value + hdnAccessoryQualitySize.Value.Trim();


                HiddenField hdAccessoryMasterId_Previous = (HiddenField)previousRow.FindControl("hdAccessoryMasterId");
                HiddenField hdnAccessoryQualitySize_Previous = (HiddenField)previousRow.FindControl("hdnAccessoryQualitySize");
                PreviousAccessory = hdAccessoryMasterId_Previous.Value + hdnAccessoryQualitySize_Previous.Value.Trim();

                if (CurrentAccessory == PreviousAccessory)
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
                Label lblShrinkage = (Label)row.FindControl("lblShrinkage");
                Label lblShrinkagePrev = (Label)previousRow.FindControl("lblShrinkage");

                if (lblShrinkage.Text == lblShrinkagePrev.Text)
                {
                    if (previousRow.Cells[1].RowSpan == 0)
                    {
                        if (row.Cells[1].RowSpan == 0)
                        {
                            previousRow.Cells[1].RowSpan += 2;
                        }
                        else
                        {
                            previousRow.Cells[1].RowSpan = row.Cells[1].RowSpan + 1;
                        }
                        row.Cells[1].Visible = false;
                    }
                }
                Label lblWastage = (Label)row.FindControl("lblWastage");
                Label lblWastagePrev = (Label)previousRow.FindControl("lblWastage");

                if (lblWastage.Text == lblWastagePrev.Text)
                {
                    if (previousRow.Cells[2].RowSpan == 0)
                    {
                        if (row.Cells[2].RowSpan == 0)
                        {
                            previousRow.Cells[2].RowSpan += 2;
                        }
                        else
                        {
                            previousRow.Cells[2].RowSpan = row.Cells[2].RowSpan + 1;
                        }
                        row.Cells[2].Visible = false;
                    }
                }

                Label lblIdealRate = (Label)row.FindControl("lblIdealRate");
                Label lblIdealRatePrev = (Label)previousRow.FindControl("lblIdealRate");

                if (lblIdealRate.Text == lblIdealRatePrev.Text)
                {
                    if (previousRow.Cells[3].RowSpan == 0)
                    {
                        if (row.Cells[3].RowSpan == 0)
                        {
                            previousRow.Cells[3].RowSpan += 2;
                        }
                        else
                        {
                            previousRow.Cells[3].RowSpan = row.Cells[3].RowSpan + 1;
                        }
                        row.Cells[3].Visible = false;
                    }
                }               

            }
        }

        protected void grdSupplier_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblSize = (Label)e.Row.FindControl("lblSize");
                Label lblsuppliername = (Label)e.Row.FindControl("lblsuppliername");

                if (lblSize.Text != "")
                    lblSize.Text = lblSize.Text == "Default" ? "" : "(" + lblSize.Text + ")";

                Label lblIdealRate = (Label)e.Row.FindControl("lblIdealRate");
                if (lblIdealRate.Text != "")
                    lblIdealRate.Text = "<span style='color:green'>₹ </span>" + lblIdealRate.Text;

                Label lblQuotedLandedRate = (Label)e.Row.FindControl("lblQuotedLandedRate");
                if (lblQuotedLandedRate.Text != "")
                    lblQuotedLandedRate.Text = "<span style='color:green'>₹ </span>" + lblQuotedLandedRate.Text;

                Label lblQuotedLeadTime = (Label)e.Row.FindControl("lblQuotedLeadTime");
                if (lblQuotedLeadTime.Text != "")
                    lblQuotedLeadTime.Text = lblQuotedLeadTime.Text != "0" ? "(" + lblQuotedLeadTime.Text + " Days)" : "";

                DateTime QuotationDate = Convert.ToDateTime(DataBinder.Eval(e.Row.DataItem, "QuotedDate"));

                if (QuotationDate != DateTime.MinValue)
                    lblsuppliername.Text = lblsuppliername.Text + " (" + QuotationDate.ToString("dd MMM yyyy") + ")";
            }
        }
    }
}