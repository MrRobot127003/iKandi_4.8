using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Globalization;
using System.Drawing;
using iKandi.BLL;
using iKandi.Common;
using iKandi.Web.Components;

namespace iKandi.Web.Admin
{
    public partial class ValueAddition : System.Web.UI.Page
    {
        public int OrderDetailId = 0, UnitId = 0;
        iKandi.BLL.OrderController OrderControllerInstance = new BLL.OrderController();
        OrderProcessController objProcessController = new OrderProcessController();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["OrderDetailId"] != null)
            {
                OrderDetailId = Convert.ToInt32(Request.QueryString["OrderDetailId"]);
                UnitId = Convert.ToInt32(Request.QueryString["UnitId"]);
            }
            else
            {
                OrderDetailId = 9390;
                UnitId = 12;
            }

            if (!IsPostBack)
            {
                if (objProcessController.GetPackingListSizeDetails(OrderDetailId).Rows.Count > 0)
                {
                    lblUnit.Text = objProcessController.GetUnitName(UnitId);
                    FillValueAdditionDetails();
                }
                else
                {
                    trMessage.Visible = true;
                    lblMessage.Visible = true;
                }
            }

        }

        private void FillValueAdditionDetails()
        {
            DataTable dtValueAddition = objProcessController.GetValueAdditionDetails(OrderDetailId);
            gvValueAddition.DataSource = dtValueAddition;
            gvValueAddition.DataBind();
        }

        protected void gvValueAddition_DataBound(object sender, EventArgs e)
        {
            for (int i = gvValueAddition.Rows.Count - 1; i > 0; i--)
            {
                GridViewRow row = gvValueAddition.Rows[i];
                GridViewRow previousRow = gvValueAddition.Rows[i - 1];

                Label lblFromStatus_ToStatus = (Label)row.Cells[0].FindControl("lblFromStatus_ToStatus");
                Label lblPreviousFromStatus_ToStatus = (Label)previousRow.Cells[0].FindControl("lblFromStatus_ToStatus");

                if (lblFromStatus_ToStatus.Text == lblPreviousFromStatus_ToStatus.Text)
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


        public void bindChecker(DropDownList ddlchecker, int CheckerId)
        {
            DataSet dsAllocation = new DataSet();
            dsAllocation = OrderControllerInstance.GetReAllocationDetailsById(OrderDetailId, UnitId);
            DataTable dtQcChecker = dsAllocation.Tables[8];
            if (dtQcChecker.Rows.Count > 0)
            {
                ddlchecker.DataSource = dtQcChecker;
                ddlchecker.DataTextField = "firstname";
                ddlchecker.DataValueField = "UserID";
                ddlchecker.DataBind();
                if (CheckerId > 0)
                {
                    ddlchecker.SelectedValue = CheckerId.ToString();
                }
                ddlchecker.Items.Insert(0, new ListItem("Select", "0"));
            }

        }

        private void BindAllQC(DropDownList ddlQC, int QCId)
        {
            iKandi.BLL.Production.ProductionController objProductionController = new BLL.Production.ProductionController();

            DataTable dtQC = objProductionController.GetAllFactory_QC();
            ddlQC.DataSource = dtQC;
            ddlQC.DataTextField = "FactoryQC";
            ddlQC.DataValueField = "UserId";
            ddlQC.DataBind();
            if (QCId > 0)
            {
                ddlQC.SelectedValue = QCId.ToString();
            }
            ddlQC.Items.Insert(0, new ListItem("Select", "0"));
        }

        protected void gvValueAddition_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            OrderProcessController oOrderProcessController = new OrderProcessController();

            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                HiddenField hdnValueAdditionId = (HiddenField)e.Row.FindControl("hdnValueAdditionId");
                Label lblValueAdditionName = (Label)e.Row.FindControl("lblValueAdditionName");
                lblValueAdditionName.Text = lblValueAdditionName.Text.Substring(0, 1).ToUpper() + lblValueAdditionName.Text.Substring(1).ToLower();

                HiddenField hdnQC = (HiddenField)e.Row.FindControl("hdnQC");
                HiddenField hdnChecker = (HiddenField)e.Row.FindControl("hdnChecker");

                DropDownList ddlQC = (DropDownList)e.Row.FindControl("ddlQC");
                DropDownList ddlChecker = (DropDownList)e.Row.FindControl("ddlChecker");

                int QCId = hdnQC != null ? Convert.ToInt32(hdnQC.Value) : -1;
                int CheckerId = hdnChecker != null ? Convert.ToInt32(hdnChecker.Value) : -1;

                BindAllQC(ddlQC, QCId);
                bindChecker(ddlChecker, CheckerId);

                CheckBox chkIsComplete = (CheckBox)e.Row.FindControl("chkIsComplete");
                if (chkIsComplete.Checked)
                    chkIsComplete.Enabled = false;
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row in gvValueAddition.Rows)
            {
                try
                {
                    TextBox txtManPower = (TextBox)row.FindControl("txtManPower");
                    TextBox txtValueAddQty = (TextBox)row.FindControl("txtValueAddQty");
                    DropDownList ddlQC = (DropDownList)row.FindControl("ddlQC");
                    DropDownList ddlChecker = (DropDownList)row.FindControl("ddlChecker");
                    HiddenField hdnValueAdditionId = (HiddenField)row.FindControl("hdnValueAdditionId");
                    CheckBox chkIsComplete = (CheckBox)row.FindControl("chkIsComplete");

                    int ValueAdditionId = Convert.ToInt32(hdnValueAdditionId.Value);
                    int ManPower = txtManPower.Text == "" ? -1 : Convert.ToInt32(txtManPower.Text);
                    int ValueAddQty = txtValueAddQty.Text == "" ? -1 : Convert.ToInt32(txtValueAddQty.Text);

                    if ((ManPower > 0) && (ValueAddQty > -1))
                    {
                        int QCId = Convert.ToInt32(ddlQC.SelectedValue);
                        int CheckerId = Convert.ToInt32(ddlChecker.SelectedValue);
                        int UserId = iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.UserID;
                        bool IsComplete = chkIsComplete.Enabled ? chkIsComplete.Checked : false;

                        int iupdate = objProcessController.UpdateValueAddition(OrderDetailId, ValueAdditionId, ValueAddQty, ManPower, QCId, CheckerId, UnitId, IsComplete, UserId);
                    }
                }
                catch (Exception ex)
                {

                }
            }

            Response.Redirect(Request.RawUrl, false);

        }

    }
}