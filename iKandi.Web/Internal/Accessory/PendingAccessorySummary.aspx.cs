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
    public partial class PendingAccessorySummary : System.Web.UI.Page
    {
        AccessoryWorkingController objAccessoryController = new AccessoryWorkingController();

        public int OrderId
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.QueryString["OrderId"]))
                {
                    return Convert.ToInt32(Request.QueryString["OrderId"]);
                }
                return -1;
            }
        }
        public int AccessoryMasterId
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.QueryString["AccessoryMasterId"]))
                {
                    return Convert.ToInt32(Request.QueryString["AccessoryMasterId"]);
                }
                return -1;
            }
        }
        public string Size
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.QueryString["Size"]))
                {
                    return Request.QueryString["Size"].ToString();
                }
                return "";
            }
        }
        public string ColorPrint
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.QueryString["ColorPrint"]))
                {
                    return Request.QueryString["ColorPrint"].ToString();
                }
                return "";
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (iKandi.Web.Components.ApplicationHelper.LoggedInUser == null || iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData == null)
                Response.Redirect("~/public/Login.aspx");

            if (!IsPostBack)
            {
                GetPendingAccessories();
            }
        }

        private void GetPendingAccessories()
        {
            if (OrderId > 0)
            {
                txtsearchkeyswords.Style.Add("display", "none");
                btnSearch.Style.Add("display", "none");
            }

            List<AccessoryPending> AccessPendingList = objAccessoryController.Get_AccessoryPending_Orders(OrderId, AccessoryMasterId, Size, ColorPrint, txtsearchkeyswords.Text.Trim());
            GrdAccessory.DataSource = AccessPendingList;
            GrdAccessory.DataBind();
        }

        protected void GrdAccessory_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HiddenField hdnStage1 = (HiddenField)e.Row.FindControl("hdnStage1");
                HiddenField hdnStage2 = (HiddenField)e.Row.FindControl("hdnStage2");
                DropDownList ddlStage1 = (DropDownList)e.Row.FindControl("ddlStage1");
                DropDownList ddlStage2 = (DropDownList)e.Row.FindControl("ddlStage2");
                HiddenField hdnIsDefaultAccessory = (HiddenField)e.Row.FindControl("hdnIsDefaultAccessory");
                HiddenField hdnIsAccessoryFinish = (HiddenField)e.Row.FindControl("hdnIsAccessoryFinish");
                HiddenField hdnStage1SrvQty = (HiddenField)e.Row.FindControl("hdnStage1SrvQty");
                HiddenField hdnStage2SrvQty = (HiddenField)e.Row.FindControl("hdnStage2SrvQty");
                HiddenField hdnColorPrint = (HiddenField)e.Row.FindControl("hdnColorPrint");

                Label lblSize = (Label)e.Row.FindControl("lblSize");
                Label lblcolorprint = (Label)e.Row.FindControl("lblcolorprint");

                ddlStage1.SelectedValue = hdnStage1.Value == null ? "-1" : hdnStage1.Value;
                ddlStage2.SelectedValue = hdnStage2.Value == null ? "-1" : hdnStage2.Value;
                lblSize.Text = lblSize.Text != "" ? "(" + lblSize.Text + ")" : "";

                ddlStage1.Enabled = Convert.ToInt32(hdnStage1SrvQty.Value) > 0 ? false : true;
                ddlStage2.Enabled = Convert.ToInt32(hdnStage2SrvQty.Value) > 0 ? false : true;

                if ((hdnStage1.Value == "-1") || (hdnStage1.Value == "2") || (hdnColorPrint.Value == "N/A"))
                {
                    ddlStage2.Enabled = false;
                }

                // if ((hdnIsDefaultAccessory.Value == "1") || (hdnColorPrint.Value == "N/A"))
                // Above condition is changed for default Accessory
                if (hdnColorPrint.Value == "N/A")
                {
                    ddlStage2.Enabled = false;
                    ddlStage1.Items[1].Enabled = false;
                }
                if (hdnIsAccessoryFinish.Value == "True")
                {
                    e.Row.Enabled = false;
                }

                if (Convert.ToInt32(hdnStage2.Value) > 1)
                {
                    ddlStage1.Enabled = false;
                }

                Label lblAccessoryQty = (Label)e.Row.FindControl("lblAccessoryQty");
                if (lblAccessoryQty.Text != "")
                {
                    lblAccessoryQty.Text = Convert.ToInt32(lblAccessoryQty.Text).ToString("N0");
                }
                if (hdnColorPrint.Value.ToUpper() == "TBD")
                {
                    lblcolorprint.BackColor = System.Drawing.Color.Orange;
                    e.Row.Cells[0].ToolTip = "For TBD as color You can select only Greige in Stage1";
                    ddlStage1.Items[2].Attributes.Add("disabled", "disabled");
                    ddlStage2.Items[1].Attributes.Add("disabled", "disabled");
                }
            }
        }

        protected void GrdAccessory_DataBound(object sender, EventArgs e)
        {
            for (int i = GrdAccessory.Rows.Count - 1; i > 0; i--)
            {
                GridViewRow row = GrdAccessory.Rows[i];
                GridViewRow previousRow = GrdAccessory.Rows[i - 1];
                string CurrentAccessory = "";
                string PreviousAccessory = "";

                HiddenField hdnAccessoryMasterId = (HiddenField)row.Cells[0].FindControl("hdnAccessoryMasterId");
                HiddenField hdnAccessoryMasterId_Prev = (HiddenField)previousRow.Cells[0].FindControl("hdnAccessoryMasterId");

                HiddenField hdnSizeId = (HiddenField)row.Cells[0].FindControl("hdnSizeId");
                HiddenField hdnSizeId_Prev = (HiddenField)previousRow.Cells[0].FindControl("hdnSizeId");

                Label lblcolorprint = (Label)row.Cells[0].FindControl("lblcolorprint");
                Label lblcolorprint_Prev = (Label)previousRow.Cells[0].FindControl("lblcolorprint");

                Label lblstylenumber = (Label)row.Cells[0].FindControl("lblstylenumber");
                Label lblstylenumber_Prev = (Label)previousRow.Cells[0].FindControl("lblstylenumber");

                Label lblSerialNo = (Label)row.Cells[0].FindControl("lblSerialNo");
                Label lblSerialNo_Prev = (Label)previousRow.Cells[0].FindControl("lblSerialNo");

                CurrentAccessory = hdnAccessoryMasterId.Value + hdnSizeId.Value.Trim() + lblcolorprint.Text.Trim().ToUpper();
                PreviousAccessory = hdnAccessoryMasterId_Prev.Value + hdnSizeId_Prev.Value.Trim() + lblcolorprint_Prev.Text.Trim().ToUpper();

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

                    if (lblstylenumber.Text == lblstylenumber_Prev.Text)
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

                        if (lblSerialNo.Text == lblSerialNo_Prev.Text)
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
                    }
                }

            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            GetPendingAccessories();
        }
    }
}