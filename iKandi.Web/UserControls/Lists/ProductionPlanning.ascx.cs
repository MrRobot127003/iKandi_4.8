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
using System.Collections.Generic;
using iKandi.Common;
using iKandi.Web.Components;

namespace iKandi.Web
{
    public partial class ProductionPlanningList : BaseUserControl
    {
        #region Fields

        int planningOrderDetailID = 0;
        int planningFirstRow = -1;
        int shipmentQty = 0;

        private int ProductionUnitManagerId
        {
            get
            {
                if (ApplicationHelper.LoggedInUser.UserData.Designation == Designation.BIPL_Production_FactoryManager)
                    return ApplicationHelper.LoggedInUser.UserData.UserID;
                else if (ApplicationHelper.LoggedInUser.UserData.Designation == Designation.BIPL_Production_AssistantFactory)
                    return ApplicationHelper.LoggedInUser.UserData.ManagerID;

                return -1;
            }
        }

        #endregion

        #region Event Handlers

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["scroll"] == "1")
                {
                    grdOrderAvailable.AllowPaging = false;
                }
                DropdownHelper.BindClients(ddlClients as ListControl);

                if (!string.IsNullOrEmpty(Request.Params["ClientID"]))
                {
                    int ClientID = Convert.ToInt32(Request.Params["ClientID"]);

                    if (ddlClients.Items.FindByValue(ClientID.ToString()) != null)
                        ddlClients.SelectedValue = ClientID.ToString();
                }

                if (!string.IsNullOrEmpty(Request.Params["SerialNumber"]))
                {
                    txtsearch.Text = Request.Params["SerialNumber"];
                }

                BindControls();


            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindControls();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row in grdOrderAvailable.Rows)
            {
                Label planningField = row.FindControl("lblProductionPlanningID") as Label;
                Label orderDetailField = row.FindControl("lblOrderDetailID") as Label;
                Label hdnPrevShipmentQty = row.FindControl("lblPrevShipmentQty") as Label;
                Label IsPartShipmentField = row.FindControl("lblIsPartShipment") as Label;
                TextBox txtShipmentQty = row.FindControl("txtShipmentQty") as TextBox;

                Label lblPOQty = row.FindControl("lblPOQty") as Label;
                Label lblBalanceQty = row.FindControl("lblBalanceQty") as Label;
                TextBox txtReasonForShortComing = row.FindControl("txtReasonForShortComing") as TextBox;
                CheckBox chkIsShortShipment = row.FindControl("chkIsShortShipment") as CheckBox;

                TextBox txtPlannedEx = row.FindControl("txtPlannedEx") as TextBox;

                ProductionPlanning pp = new ProductionPlanning();
                pp.ProductionPlanningID = Convert.ToInt32(planningField.Text);

                if (!string.IsNullOrEmpty(txtShipmentQty.Text))
                    pp.ShipmentQty = Convert.ToInt32(txtShipmentQty.Text);

                pp.ReasonForShortShipping = txtReasonForShortComing.Text;
                pp.IsShortShipment = chkIsShortShipment.Checked;
                pp.OrderDetailID = Convert.ToInt32(orderDetailField.Text);
                pp.Quantity = Convert.ToInt32(hdnPrevShipmentQty.Text);

                if ((((pp.Quantity - pp.ShipmentQty) > 0) && !pp.IsShortShipment) || Convert.ToBoolean(IsPartShipmentField.Text))
                    pp.IsPartShipment = true;

                if (!string.IsNullOrEmpty(txtPlannedEx.Text))
                {
                    DateTime? plannedEx = DateHelper.ParseDate(txtPlannedEx.Text);

                    if (plannedEx.HasValue)
                    {
                        pp.PlannedEx = plannedEx.Value;
                    }
                }

                this.DeliveryControllerInstance.UpdateProductionPlanningOrder(pp);
            }

            BindControls();
        }

        protected void grdOrderPlanning_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType != DataControlRowType.DataRow) return;

            TextBox txtShipmentQty = e.Row.FindControl("txtShipmentQty") as TextBox;

            ProductionPlanning order = e.Row.DataItem as ProductionPlanning;

            if (planningOrderDetailID == order.OrderDetailID)
            {
                grdOrderAvailable.Rows[planningFirstRow].Cells[0].RowSpan += 1;
                e.Row.Cells[0].Visible = false;
                grdOrderAvailable.Rows[planningFirstRow].Cells[1].RowSpan += 1;
                e.Row.Cells[1].Visible = false;
                grdOrderAvailable.Rows[planningFirstRow].Cells[2].RowSpan += 1;
                e.Row.Cells[2].Visible = false;
                grdOrderAvailable.Rows[planningFirstRow].Cells[3].RowSpan += 1;
                e.Row.Cells[3].Visible = false;
                grdOrderAvailable.Rows[planningFirstRow].Cells[4].RowSpan += 1;
                e.Row.Cells[4].Visible = false;
                grdOrderAvailable.Rows[planningFirstRow].Cells[5].RowSpan += 1;
                e.Row.Cells[5].Visible = false;
                grdOrderAvailable.Rows[planningFirstRow].Cells[6].RowSpan += 1;
                e.Row.Cells[6].Visible = false;
                grdOrderAvailable.Rows[planningFirstRow].Cells[7].RowSpan += 1;
                e.Row.Cells[7].Visible = false;
                grdOrderAvailable.Rows[planningFirstRow].Cells[8].RowSpan += 1;
                e.Row.Cells[8].Visible = false;
                grdOrderAvailable.Rows[planningFirstRow].Cells[9].RowSpan += 1;
                e.Row.Cells[9].Visible = false;
                grdOrderAvailable.Rows[planningFirstRow].Cells[10].RowSpan += 1;
                e.Row.Cells[10].Visible = false;
                grdOrderAvailable.Rows[planningFirstRow].Cells[11].RowSpan += 1;
                e.Row.Cells[11].Visible = false;
                grdOrderAvailable.Rows[planningFirstRow].Cells[12].RowSpan += 1;
                e.Row.Cells[12].Visible = false;
                grdOrderAvailable.Rows[planningFirstRow].Cells[13].RowSpan += 1;
                e.Row.Cells[13].Visible = false;
                grdOrderAvailable.Rows[planningFirstRow].Cells[14].RowSpan += 1;
                e.Row.Cells[14].Visible = false;
                grdOrderAvailable.Rows[planningFirstRow].Cells[15].RowSpan += 1;
                e.Row.Cells[15].Visible = false;
                grdOrderAvailable.Rows[planningFirstRow].Cells[16].RowSpan += 1;
                e.Row.Cells[16].Visible = false;
                //grdOrderAvailable.Rows[planningFirstRow].Cells[18].RowSpan += 1;
                //e.Row.Cells[18].Visible = false;

                this.shipmentQty += Convert.ToInt32(txtShipmentQty.Text);
            }
            else
            {
                planningOrderDetailID = order.OrderDetailID;
                planningFirstRow = e.Row.RowIndex;
                this.shipmentQty = 0;

                e.Row.Cells[0].RowSpan = 1;
                e.Row.Cells[1].RowSpan = 1;
                e.Row.Cells[2].RowSpan = 1;
                e.Row.Cells[3].RowSpan = 1;
                e.Row.Cells[4].RowSpan = 1;
                e.Row.Cells[5].RowSpan = 1;
                e.Row.Cells[6].RowSpan = 1;
                e.Row.Cells[7].RowSpan = 1;
                e.Row.Cells[8].RowSpan = 1;
                e.Row.Cells[9].RowSpan = 1;
                e.Row.Cells[10].RowSpan = 1;
                e.Row.Cells[11].RowSpan = 1;
                e.Row.Cells[12].RowSpan = 1;
                e.Row.Cells[13].RowSpan = 1;
                e.Row.Cells[14].RowSpan = 1;
                e.Row.Cells[15].RowSpan = 1;
                e.Row.Cells[16].RowSpan = 1;
                //e.Row.Cells[18].RowSpan = 1;

                this.shipmentQty = Convert.ToInt32(txtShipmentQty.Text);
            }

            HiddenField hdnSerial = e.Row.FindControl("hdnSerial") as HiddenField;
            (hdnSerial.Parent as TableCell).BackColor = System.Drawing.ColorTranslator.FromHtml(Constants.GetSerialNumberColor(order.ExFactory));

            HiddenField hdnUnit = e.Row.FindControl("hdnUnit") as HiddenField;
            (hdnUnit.Parent as TableCell).BackColor = System.Drawing.ColorTranslator.FromHtml(ApplicationHelper.GetUnitColor(order.Unit.FactoryCode));

            Label lblMode = e.Row.FindControl("lblMode") as Label;
            (lblMode.Parent as TableCell).BackColor = System.Drawing.ColorTranslator.FromHtml(iKandi.BLL.CommonHelper.GetDeliveryModeColor(order.Mode));

            HiddenField lblStatus = e.Row.FindControl("lblStatus") as HiddenField;
            (lblStatus.Parent as TableCell).BackColor = System.Drawing.ColorTranslator.FromHtml(Constants.GetStatusModeColor(order.StatusModeID));

            Label lblExFactory = e.Row.FindControl("lblExFactory") as Label;
            (lblExFactory.Parent as TableCell).BackColor = System.Drawing.ColorTranslator.FromHtml(iKandi.BLL.CommonHelper.GetExFactoryColor(order.ExFactory, order.DC, order.Mode));
        }

        protected void grdOrderAvailable_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdOrderAvailable.PageIndex = e.NewPageIndex;
            hdnPagesize.Value = grdOrderAvailable.PageSize.ToString();
            hdnPageIndex.Value = grdOrderAvailable.PageIndex.ToString();
            BindControls();
        }

        #endregion

        #region Private Methods

        private void BindControls()
        {
            hdnPagesize.Value = grdOrderAvailable.PageSize.ToString();
            hdnPageIndex.Value = grdOrderAvailable.PageIndex.ToString();

            grdOrderAvailable.DataSource = this.DeliveryControllerInstance.GetProductionPlanningOrders(ProductionUnitManagerId, Convert.ToInt32(ddlClients.SelectedValue), txtsearch.Text);
            grdOrderAvailable.DataBind();
        }

        private int CompareProductionPlanning(ProductionPlanning ObjA, ProductionPlanning ObjB)
        {
            if (ObjA.Packing.PackingID == ObjB.Packing.PackingID)
                return 0;

            if (ObjA.Packing.PackingID > ObjB.Packing.PackingID)
                return 1;

            if (ObjA.Packing.PackingID < ObjB.Packing.PackingID)
                return -1;

            return 0;
        }

        private string GetPackingDimensions(List<PackingDimension> PackingDimensions)
        {

            string dimentions = string.Empty;

            foreach (PackingDimension pd in PackingDimensions)
            {
                if (dimentions == string.Empty)
                    dimentions = pd.Dimension + " (" + pd.Quantity.ToString() + " Pkgs)";
                else
                    dimentions += "," + Environment.NewLine + pd.Dimension + " (" + pd.Quantity.ToString() + " Pkgs)";
            }

            return dimentions;
        }

        #endregion


        protected void btnPrint_Click(object sender, EventArgs e)
        {
            //string s = "~/uploads/temp/Accessory-23 Jan 2013 11-24-03.pdf";
           // string s = Convert.ToString(Session["PathForPDF"]);   // hdnPath.Value;
            //string s = hid.Value;
            //if (s != "")
            //{
            //    Response.ClearContent();
            //    Response.ClearHeaders();
            //    Response.AddHeader("Content-Disposition", "attachment;filename=" + s);
            //    Response.ContentType = "application/pdf";
            //    Response.WriteFile(s);
            //}
        }


    }
}

