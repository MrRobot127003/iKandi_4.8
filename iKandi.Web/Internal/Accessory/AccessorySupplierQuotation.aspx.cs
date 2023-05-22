using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iKandi.Web.Components;
using iKandi.Common;
using iKandi.BLL;


namespace iKandi.Web.Internal.Accessory
{
    public partial class AccessoryGrease_Finish_Supplier : System.Web.UI.Page
    {
        AccessoryWorkingController objAccessory = new AccessoryWorkingController();
        private string SupplierName;
        private int UserId;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (ApplicationHelper.LoggedInUser == null)
                Response.Redirect("~/internal/Logout.aspx");

            string baseSiteUrl = Constants.BaseSiteUrl.ToUpper().Replace("HTTP://", "").Replace("WWW.", "");
            string siteBaseUrl = Constants.SITE_BASE_URL.ToUpper().Replace("HTTP://", "").Replace("WWW.", "");
            if (baseSiteUrl.Contains(siteBaseUrl))
            {
                boutiquelogo.ImageUrl = "~/App_Themes/ikandi/images/ikandi.gif";
            }
            else
            {
                boutiquelogo.ImageUrl = "~/App_Themes/ikandi/images/new-boutique-logo.png";
            }

            if (!Page.IsPostBack)
            {
                if (ApplicationHelper.LoggedInUser.UserData.Designation == Designation.BIPL_Supplier)
                    UserId = iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.UserID;
                else
                    UserId = -1;

                BindData();

            }
        }

        private void BindData()
        {
            List<AccessoryPending> AccessList = objAccessory.GetAccessory_Supplier_Quotation(UserId, txtsearchkeyswords.Text.Trim(), 1);
            grdGriege.DataSource = AccessList;
            grdGriege.DataBind();
            SupplierName = AccessList[0].SupplierName;

            if (UserId > 0)
                lblusername.Text = "Welcome: <b>" + ApplicationHelper.LoggedInUser.UserData.FirstName + " " + ApplicationHelper.LoggedInUser.UserData.LastName + " (" + SupplierName + ")</b>";
        }

        protected void grdGriege_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblBestQuotedLeadTime = (Label)e.Row.FindControl("lblBestQuotedLeadTime");
                Label lblSize = (Label)e.Row.FindControl("lblSize");
                lblBestQuotedLeadTime.Text = lblBestQuotedLeadTime.Text == "" ? "" : lblBestQuotedLeadTime.Text + "<span style='color:gray'> days</span>";
                if (lblSize.Text != "")
                    lblSize.Text = lblSize.Text == "Default" ? "" : "(" + lblSize.Text + ")";

                Label lblPoNumber = (Label)e.Row.FindControl("lblPoNumber");

                if (lblPoNumber.Text != "")
                {
                    int SupplierPoId = DataBinder.Eval(e.Row.DataItem, "SupplierPoId") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "SupplierPoId"));
                    int AccessoryMasterId = DataBinder.Eval(e.Row.DataItem, "AccessoryMasterId") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "AccessoryMasterId"));
                    string Size = DataBinder.Eval(e.Row.DataItem, "Size").ToString();
                    string Color_Print = DataBinder.Eval(e.Row.DataItem, "Color_Print").ToString();

                    string sLink = "ShowPurchaseOrder(" + AccessoryMasterId + ", '" + Size + "', '" + Color_Print + "', " + SupplierPoId + ", 1)";

                    lblPoNumber.Attributes.Add("onclick", sLink);
                }
            }
        }
        protected void grdProcess_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblBestQuotedLeadTime = (Label)e.Row.FindControl("lblBestQuotedLeadTime");
                Label lblSize = (Label)e.Row.FindControl("lblSize");
                lblBestQuotedLeadTime.Text = lblBestQuotedLeadTime.Text == "" ? "" : lblBestQuotedLeadTime.Text + " <span style='color:gray'> days</span>";
                if (lblSize.Text != "")
                    lblSize.Text = lblSize.Text == "Default" ? "" : "(" + lblSize.Text + ")";

                Label lblPoNumber = (Label)e.Row.FindControl("lblPoNumber");

                if (lblPoNumber.Text != "")
                {
                    int SupplierPoId = DataBinder.Eval(e.Row.DataItem, "SupplierPoId") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "SupplierPoId"));
                    int AccessoryMasterId = DataBinder.Eval(e.Row.DataItem, "AccessoryMasterId") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "AccessoryMasterId"));
                    string Size = DataBinder.Eval(e.Row.DataItem, "Size").ToString();
                    string Color_Print = DataBinder.Eval(e.Row.DataItem, "Color_Print").ToString();

                    string sLink = "ShowPurchaseOrder(" + AccessoryMasterId + ", '" + Size + "', '" + Color_Print + "', " + SupplierPoId + ", 2)";

                    lblPoNumber.Attributes.Add("onclick", sLink);
                }
            }
        }
        protected void grdFinish_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblBestQuotedLeadTime = (Label)e.Row.FindControl("lblBestQuotedLeadTime");
                Label lblSize = (Label)e.Row.FindControl("lblSize");
                lblBestQuotedLeadTime.Text = lblBestQuotedLeadTime.Text == "" ? "" : lblBestQuotedLeadTime.Text + " <span style='color:gray'> days</span>";
                if (lblSize.Text != "")
                    lblSize.Text = lblSize.Text == "Default" ? "" : "(" + lblSize.Text + ")";

                Label lblPoNumber = (Label)e.Row.FindControl("lblPoNumber");

                if (lblPoNumber.Text != "")
                {
                    int SupplierPoId = DataBinder.Eval(e.Row.DataItem, "SupplierPoId") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "SupplierPoId"));
                    int AccessoryMasterId = DataBinder.Eval(e.Row.DataItem, "AccessoryMasterId") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "AccessoryMasterId"));
                    string Size = DataBinder.Eval(e.Row.DataItem, "Size").ToString();
                    string Color_Print = DataBinder.Eval(e.Row.DataItem, "Color_Print").ToString();

                    string sLink = "ShowPurchaseOrder(" + AccessoryMasterId + ", '" + Size + "', '" + Color_Print + "', " + SupplierPoId + ", 3)";

                    lblPoNumber.Attributes.Add("onclick", sLink);
                }
            }
        }

        protected void grdGriege_DataBound(object sender, EventArgs e)
        {
            for (int i = grdGriege.Rows.Count - 1; i > 0; i--)
            {
                GridViewRow row = grdGriege.Rows[i];
                GridViewRow previousRow = grdGriege.Rows[i - 1];
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

                Label lblQuantityToOrder = (Label)row.FindControl("lblQuantityToOrder");
                Label lblQuantityToOrderPrev = (Label)previousRow.FindControl("lblQuantityToOrder");

                if (lblQuantityToOrder.Text == lblQuantityToOrderPrev.Text)
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

                string CurrentRate_LeadTime = "";
                string PreviousRate_LeadTime = "";

                HiddenField hdnMinimumRate = (HiddenField)row.FindControl("hdnMinimumRate");
                HiddenField hdnMinimumLeadTime = (HiddenField)row.FindControl("hdnMinimumLeadTime");

                CurrentRate_LeadTime = hdnMinimumRate.Value.ToString() + hdnMinimumLeadTime.Value.ToString();

                HiddenField hdnMinimumRatePrev = (HiddenField)previousRow.FindControl("hdnMinimumRate");
                HiddenField hdnMinimumLeadTimePrev = (HiddenField)previousRow.FindControl("hdnMinimumLeadTime");

                PreviousRate_LeadTime = hdnMinimumRatePrev.Value.ToString() + hdnMinimumLeadTimePrev.Value.ToString();

                if (CurrentRate_LeadTime == PreviousRate_LeadTime)
                {
                    if (previousRow.Cells[5].RowSpan == 0)
                    {
                        if (row.Cells[5].RowSpan == 0)
                        {
                            previousRow.Cells[5].RowSpan += 2;
                        }
                        else
                        {
                            previousRow.Cells[5].RowSpan = row.Cells[5].RowSpan + 1;
                        }
                        row.Cells[5].Visible = false;
                    }
                }

            }
        }

        protected void grdProcess_DataBound(object sender, EventArgs e)
        {
            for (int i = grdProcess.Rows.Count - 1; i > 0; i--)
            {
                GridViewRow row = grdProcess.Rows[i];
                GridViewRow previousRow = grdProcess.Rows[i - 1];
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

                Label lblQuantityToOrder = (Label)row.FindControl("lblQuantityToOrder");
                Label lblQuantityToOrderPrev = (Label)previousRow.FindControl("lblQuantityToOrder");

                if (lblQuantityToOrder.Text == lblQuantityToOrderPrev.Text)
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

                string CurrentRate_LeadTime = "";
                string PreviousRate_LeadTime = "";

                HiddenField hdnMinimumRate = (HiddenField)row.FindControl("hdnMinimumRate");
                HiddenField hdnMinimumLeadTime = (HiddenField)row.FindControl("hdnMinimumLeadTime");

                CurrentRate_LeadTime = hdnMinimumRate.Value.ToString() + hdnMinimumLeadTime.Value.ToString();

                HiddenField hdnMinimumRatePrev = (HiddenField)previousRow.FindControl("hdnMinimumRate");
                HiddenField hdnMinimumLeadTimePrev = (HiddenField)previousRow.FindControl("hdnMinimumLeadTime");

                PreviousRate_LeadTime = hdnMinimumRatePrev.Value.ToString() + hdnMinimumLeadTimePrev.Value.ToString();

                if (CurrentRate_LeadTime == PreviousRate_LeadTime)
                {
                    if (previousRow.Cells[5].RowSpan == 0)
                    {
                        if (row.Cells[5].RowSpan == 0)
                        {
                            previousRow.Cells[5].RowSpan += 2;
                        }
                        else
                        {
                            previousRow.Cells[5].RowSpan = row.Cells[5].RowSpan + 1;
                        }
                        row.Cells[5].Visible = false;
                    }
                }
            }
        }

        protected void grdFinish_DataBound(object sender, EventArgs e)
        {
            for (int i = grdFinish.Rows.Count - 1; i > 0; i--)
            {
                GridViewRow row = grdFinish.Rows[i];
                GridViewRow previousRow = grdFinish.Rows[i - 1];
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

                Label lblQuantityToOrder = (Label)row.FindControl("lblQuantityToOrder");
                Label lblQuantityToOrderPrev = (Label)previousRow.FindControl("lblQuantityToOrder");

                if (lblQuantityToOrder.Text == lblQuantityToOrderPrev.Text)
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

                string CurrentRate_LeadTime = "";
                string PreviousRate_LeadTime = "";

                HiddenField hdnMinimumRate = (HiddenField)row.FindControl("hdnMinimumRate");
                HiddenField hdnMinimumLeadTime = (HiddenField)row.FindControl("hdnMinimumLeadTime");

                CurrentRate_LeadTime = hdnMinimumRate.Value.ToString() + hdnMinimumLeadTime.Value.ToString();

                HiddenField hdnMinimumRatePrev = (HiddenField)previousRow.FindControl("hdnMinimumRate");
                HiddenField hdnMinimumLeadTimePrev = (HiddenField)previousRow.FindControl("hdnMinimumLeadTime");

                PreviousRate_LeadTime = hdnMinimumRatePrev.Value.ToString() + hdnMinimumLeadTimePrev.Value.ToString();

                if (CurrentRate_LeadTime == PreviousRate_LeadTime)
                {
                    if (previousRow.Cells[5].RowSpan == 0)
                    {
                        if (row.Cells[5].RowSpan == 0)
                        {
                            previousRow.Cells[5].RowSpan += 2;
                        }
                        else
                        {
                            previousRow.Cells[5].RowSpan = row.Cells[5].RowSpan + 1;
                        }
                        row.Cells[5].Visible = false;
                    }
                }
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (hdntabvalue.Value == "GRIEGE")
            {
                aGreige.Attributes.Add("class", "tab1greige activeback");
                aProcess.Attributes.Remove("class");
                aFinish.Attributes.Remove("class");
                aProcess.Attributes.Add("class", "tab1Process");
                aFinish.Attributes.Add("class", "tab1finished");

                aProcess.Style.Add("display", "none");
                aFinish.Style.Add("display", "none");

                grdGriege.Style.Add("display", "");
                grdProcess.Style.Add("display", "none");
                grdFinish.Style.Add("display", "none");

                dvHeader.InnerHtml = "Pending Griege Orders Supplier View";

                List<AccessoryPending> AccessList = objAccessory.GetAccessory_Supplier_Quotation(UserId, txtsearchkeyswords.Text.Trim(), 1);
                grdGriege.DataSource = AccessList;
                grdGriege.DataBind();
                SupplierName = AccessList[0].SupplierName;
            }
            if (hdntabvalue.Value == "PROCESS")
            {
                aProcess.Attributes.Add("class", "tab1greige activeback");
                aGreige.Attributes.Remove("class");
                aFinish.Attributes.Remove("class");
                aGreige.Attributes.Add("class", "tab1Process");
                aFinish.Attributes.Add("class", "tab1finished");

                aGreige.Style.Add("display", "none");
                aFinish.Style.Add("display", "none");

                grdGriege.Style.Add("display", "none");
                grdProcess.Style.Add("display", "");
                grdFinish.Style.Add("display", "none");

                dvHeader.InnerHtml = "Pending Process Orders Supplier View";

                List<AccessoryPending> AccessList = objAccessory.GetAccessory_Supplier_Quotation(UserId, txtsearchkeyswords.Text.Trim(), 2);
                grdProcess.DataSource = AccessList;
                grdProcess.DataBind();
                SupplierName = AccessList[0].SupplierName;

            }
            if (hdntabvalue.Value == "FINISHING")
            {
                aFinish.Attributes.Add("class", "tab1greige activeback");
                aGreige.Attributes.Remove("class");
                aProcess.Attributes.Remove("class");
                aGreige.Attributes.Add("class", "tab1Process");
                aProcess.Attributes.Add("class", "tab1finished");

                aGreige.Style.Add("display", "none");
                aProcess.Style.Add("display", "none");

                grdGriege.Style.Add("display", "none");
                grdProcess.Style.Add("display", "none");
                grdFinish.Style.Add("display", "");

                dvHeader.InnerHtml = "Pending Finishing Orders Supplier View";

                List<AccessoryPending> AccessList = objAccessory.GetAccessory_Supplier_Quotation(UserId, txtsearchkeyswords.Text.Trim(), 3);
                grdFinish.DataSource = AccessList;
                grdFinish.DataBind();
                SupplierName = AccessList[0].SupplierName;
            }

            // BindData();            
        }

        protected void btnTab_Click(object sender, EventArgs e)
        {
            if (hdntabvalue.Value == "GRIEGE")
            {
                aGreige.Attributes.Add("class", "tab1greige activeback");
                aProcess.Attributes.Remove("class");
                aFinish.Attributes.Remove("class");
                aProcess.Attributes.Add("class", "tab1Process");
                aFinish.Attributes.Add("class", "tab1finished");

                grdGriege.Style.Add("display", "");
                grdProcess.Style.Add("display", "none");
                grdFinish.Style.Add("display", "none");

                dvHeader.InnerHtml = "Pending Griege Orders Supplier View";

                List<AccessoryPending> AccessList = objAccessory.GetAccessory_Supplier_Quotation(UserId, txtsearchkeyswords.Text.Trim(), 1);
                grdGriege.DataSource = AccessList;
                grdGriege.DataBind();
                SupplierName = AccessList[0].SupplierName;
            }
            if (hdntabvalue.Value == "PROCESS")
            {
                aProcess.Attributes.Add("class", "tab1greige activeback");
                aGreige.Attributes.Remove("class");
                aFinish.Attributes.Remove("class");
                aGreige.Attributes.Add("class", "tab1Process");
                aFinish.Attributes.Add("class", "tab1finished");

                grdGriege.Style.Add("display", "none");
                grdProcess.Style.Add("display", "");
                grdFinish.Style.Add("display", "none");

                dvHeader.InnerHtml = "Pending Process Orders Supplier View";

                List<AccessoryPending> AccessList = objAccessory.GetAccessory_Supplier_Quotation(UserId, txtsearchkeyswords.Text.Trim(), 2);
                grdProcess.DataSource = AccessList;
                grdProcess.DataBind();
                SupplierName = AccessList[0].SupplierName;


            }
            if (hdntabvalue.Value == "FINISHING")
            {
                aFinish.Attributes.Add("class", "tab1greige activeback");
                aGreige.Attributes.Remove("class");
                aProcess.Attributes.Remove("class");
                aGreige.Attributes.Add("class", "tab1Process");
                aProcess.Attributes.Add("class", "tab1finished");

                grdGriege.Style.Add("display", "none");
                grdProcess.Style.Add("display", "none");
                grdFinish.Style.Add("display", "");

                dvHeader.InnerHtml = "Pending Finishing Orders Supplier View";

                List<AccessoryPending> AccessList = objAccessory.GetAccessory_Supplier_Quotation(UserId, txtsearchkeyswords.Text.Trim(), 3);
                grdFinish.DataSource = AccessList;
                grdFinish.DataBind();
                SupplierName = AccessList[0].SupplierName;
            }
        }
    }
}