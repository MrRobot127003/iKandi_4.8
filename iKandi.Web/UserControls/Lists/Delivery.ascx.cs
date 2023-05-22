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
    public partial class Delivery : BaseUserControl
    {
        #region Fields

        int packingID = 0;
        int shipmentID = 0;
        int packingFirstRow = -1;
        int shipmentFirstRow = -1;
        int packingID2 = 0;
        int shipmentID2 = 0;
        int packingFirstRow2 = -1;
        int shipmentFirstRow2 = -1;

        string bookingReferenceNo = string.Empty;
        int bookingFirstRow = 0;

        #endregion

        #region Public Fields

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
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
                HiddenField hdnPlanningField = row.FindControl("hdnProductionPlanningID") as HiddenField;
                HiddenField hdnPackingField = row.FindControl("hdnPackingID") as HiddenField;
                HiddenField hdnOrderDetailID = row.FindControl("hdnOrderDetailID") as HiddenField;
                CheckBox chkSelectForBooking = row.FindControl("chkSelectForBooking") as CheckBox;

                if (chkSelectForBooking.Checked)
                {
                    DeliveryBooking db = new DeliveryBooking();
                    db.OrderDetailID = Convert.ToInt32(hdnOrderDetailID.Value);
                    db.ProductionPlanningID = Convert.ToInt32(hdnPlanningField.Value);
                    db.IsBooking = true;
                    this.DeliveryControllerInstance.AddOrderForBooking(db);
                }
            }

            foreach (GridViewRow row in grdBooking.Rows)
            {
                HiddenField hdnBookingID = row.FindControl("hdnBookingID") as HiddenField;
                CheckBox chkRemove = row.FindControl("chkRemove") as CheckBox;

                if (chkRemove.Checked)
                {
                    this.DeliveryControllerInstance.RemoveOrderFromBookingView(Convert.ToInt32(hdnBookingID.Value));
                }
                else
                {
                    HiddenField hdnPackingField = row.FindControl("hdnPackingID") as HiddenField;
                    HiddenField hdnOrderDetailID = row.FindControl("hdnOrderDetailID") as HiddenField;
                    TextBox txtBookingRequestedOn = row.FindControl("txtBookingRequestedOn") as TextBox;
                    TextBox txtBookingRefNo = row.FindControl("txtBookingRefNo") as TextBox;
                    TextBox txtExpectedDC = row.FindControl("txtExpectedDC") as TextBox;
                    DropDownList txtExpectedDCDateHR = row.FindControl("txtExpectedDCDateHR") as DropDownList;
                    DropDownList txtExpectedDCDateMM = row.FindControl("txtExpectedDCDateMM") as DropDownList;
                    CheckBox chkConfirm = row.FindControl("chkConfirm") as CheckBox;
                    HiddenField hdnBookingDocs = row.FindControl("hdnBookingDocs") as HiddenField;
                    FileUpload fileBookingDocs = row.FindControl("fileBookingDocs") as FileUpload;
                    HiddenField hdnProductionPlanningID = row.FindControl("hdnProductionPlanningID") as HiddenField;

                    DeliveryBooking db = new DeliveryBooking();
                    db.OrderDetailID = Convert.ToInt32(hdnOrderDetailID.Value);
                    db.IsBooking = true;
                    db.BookingID = Convert.ToInt32(hdnBookingID.Value);
                    db.ProductionPlanningID = Convert.ToInt32(hdnProductionPlanningID.Value);

                    if (!string.IsNullOrEmpty(txtBookingRequestedOn.Text))
                        db.BookingRequestedOn = DateHelper.ParseDate(txtBookingRequestedOn.Text).Value;

                    db.BookingReferenceNo = txtBookingRefNo.Text;
                    db.IsPackinglistCompleteBooking = chkConfirm.Checked;

                    if (!string.IsNullOrEmpty(txtExpectedDC.Text))
                    {
                        db.ExpectedDC = DateHelper.ParseDate(txtExpectedDC.Text).Value;
                        db.ExpectedDC = new DateTime(db.ExpectedDC.Year, db.ExpectedDC.Month, db.ExpectedDC.Day, Convert.ToInt32(txtExpectedDCDateHR.SelectedValue), Convert.ToInt32(txtExpectedDCDateMM.SelectedValue), 00);
                    }

                    string fileName = hdnBookingDocs.Value;
                    db.BookingDocuments = GetUploadeFileNames(fileName, fileBookingDocs.UniqueID);

                    this.DeliveryControllerInstance.UpdateBookingOrder(db);
                }
            }
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "startupscript", "$(function(){alert('Data has been saved successfully!');});", true);
            BindControls();
        }

        protected void grdOrderAvailable_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdOrderAvailable.PageIndex = e.NewPageIndex;
            hdnPagesize.Value = grdOrderAvailable.PageSize.ToString();
            hdnPageIndex.Value = grdOrderAvailable.PageIndex.ToString();
            BindControls();
        }

        protected void grdBooking_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdBooking.PageIndex = e.NewPageIndex;
            hdnPagesize1.Value = grdBooking.PageSize.ToString();
            hdnPageIndex1.Value = grdBooking.PageIndex.ToString();
            BindControls();
        }

        #endregion

        #region Private Methods

        private void BindControls()
        {


            hdnPagesize.Value = grdOrderAvailable.PageSize.ToString();
            hdnPageIndex.Value = grdOrderAvailable.PageIndex.ToString();
            hdnPagesize1.Value = grdBooking.PageSize.ToString();
            hdnPageIndex1.Value = grdBooking.PageIndex.ToString();

            List<DeliveryBooking> orders = this.DeliveryControllerInstance.GetBookingOrders(Convert.ToInt32(ddlClients.SelectedValue), txtsearch.Text);

            List<DeliveryBooking> availableOrders = orders.FindAll(delegate(DeliveryBooking db)
            {

                return db.IsBooking == false;
            });

            List<DeliveryBooking> bookingOrders = orders.FindAll(delegate(DeliveryBooking db)
            {
                return db.IsBooking == true;
            });

            grdOrderAvailable.DataSource = availableOrders;
            grdOrderAvailable.DataBind();

            grdBooking.DataSource = bookingOrders;
            grdBooking.DataBind();



            //grdOrderAvailable.Columns[21].Visible = PermissionHelper.IsReadPermittedOnColumn((int)AppModuleColumn.DC_BOOKING_FILE_CHECK_BOX_TO_BOOK);
            //grdBooking.Columns[22].Visible = PermissionHelper.IsReadPermittedOnColumn((int)AppModuleColumn.DC_BOOKING_FILE_BOOKING_REQUESTED_ON);
            //grdBooking.Columns[23].Visible = PermissionHelper.IsReadPermittedOnColumn((int)AppModuleColumn.DC_BOOKING_FILE_BOOKING_REF_NO);
            //grdBooking.Columns[24].Visible = PermissionHelper.IsReadPermittedOnColumn((int)AppModuleColumn.DC_BOOKING_FILE_P_LIST_ENTERED_SPLITS_CONFIRMED_CHECK_BOX);
            //grdBooking.Columns[25].Visible = PermissionHelper.IsReadPermittedOnColumn((int)AppModuleColumn.DC_BOOKING_FILE_BOOKING_REF_NO_EXPECTED_INTO_DC);
            //grdBooking.Columns[26].Visible = PermissionHelper.IsReadPermittedOnColumn((int)AppModuleColumn.DC_BOOKING_FILE_ATTACH_BOOKING_DOCUMENTS);
        }

        #endregion

        protected void grdBooking_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.DataRow) return;

            DeliveryBooking booking = e.Row.DataItem as DeliveryBooking;

            if (booking.ShipmentPlanningOrder != null && booking.ShipmentPlanningOrder.PackingList != null && packingID == booking.ShipmentPlanningOrder.PackingList.PackingID && packingID > 0)
            {
                grdBooking.Rows[packingFirstRow].Cells[20].RowSpan += 1;
                e.Row.Cells[20].Visible = false;
                grdBooking.Rows[packingFirstRow].Cells[18].RowSpan += 1;
                e.Row.Cells[18].Visible = false;
                grdBooking.Rows[packingFirstRow].Cells[19].RowSpan += 1;
                e.Row.Cells[19].Visible = false;
                grdBooking.Rows[packingFirstRow].Cells[16].RowSpan += 1;
                e.Row.Cells[16].Visible = false;
            }
            else if (booking.ShipmentPlanningOrder.PackingList != null)
            {
                packingID = booking.ShipmentPlanningOrder.PackingList.PackingID;
                packingFirstRow = e.Row.RowIndex;

                e.Row.Cells[20].RowSpan = 1;
                e.Row.Cells[18].RowSpan = 1;
                e.Row.Cells[19].RowSpan = 1;
                e.Row.Cells[16].RowSpan = 1;
            }

            if (booking.ShipmentPlanningOrder != null && booking.ShipmentPlanningOrder.ShipmentPlanning != null && shipmentID == booking.ShipmentPlanningOrder.ShipmentPlanning.ShipmentID && shipmentID > 0)
            {
                grdBooking.Rows[shipmentFirstRow].Cells[12].RowSpan += 1;
                e.Row.Cells[12].Visible = false;
                grdBooking.Rows[shipmentFirstRow].Cells[13].RowSpan += 1;
                e.Row.Cells[13].Visible = false;
            }
            else if (booking.ShipmentPlanningOrder != null && booking.ShipmentPlanningOrder.ShipmentPlanning != null)
            {
                shipmentID = booking.ShipmentPlanningOrder.ShipmentPlanning.ShipmentID;
                shipmentFirstRow = e.Row.RowIndex;

                e.Row.Cells[12].RowSpan = 1;
                e.Row.Cells[13].RowSpan = 1;
            }

            if (booking != null && bookingReferenceNo == booking.BookingReferenceNo && bookingReferenceNo != string.Empty)
            {
                for (int i = 22; i < grdBooking.Rows[bookingFirstRow].Cells.Count - 1; i++)
                {
                    grdBooking.Rows[bookingFirstRow].Cells[i].RowSpan += 1;
                    e.Row.Cells[i].Visible = false;
                }
            }
            else if (booking != null)
            {
                bookingReferenceNo = booking.BookingReferenceNo;
                bookingFirstRow = e.Row.RowIndex;

                for (int i = 22; i < e.Row.Cells.Count - 1; i++)
                {
                    e.Row.Cells[i].RowSpan = 1;
                }
            }

            Label packageDimensions = e.Row.FindControl("packageDimensions") as Label;

            if (booking != null && booking.ShipmentPlanningOrder != null && booking.ShipmentPlanningOrder.PackingList != null && booking.ShipmentPlanningOrder.PackingList.Dimensions != null && booking.ShipmentPlanningOrder.PackingList.Dimensions.Count > 0)
                packageDimensions.Text = this.GetPackingDimensions(booking.ShipmentPlanningOrder.PackingList.Dimensions);


            HiddenField hdnIkandiSerial = e.Row.FindControl("hdnIkandiSerial") as HiddenField;
            (hdnIkandiSerial.Parent as TableCell).BackColor = System.Drawing.ColorTranslator.FromHtml(Constants.GetSerialNumberColor(booking.ExFactory));

            Label lblMode = e.Row.FindControl("lblMode") as Label;
            (lblMode.Parent as TableCell).BackColor = System.Drawing.ColorTranslator.FromHtml(iKandi.BLL.CommonHelper.GetDeliveryModeColor(booking.Mode));

            HiddenField hdnEx = e.Row.FindControl("hdnEx") as HiddenField;
            (hdnEx.Parent as TableCell).BackColor = System.Drawing.ColorTranslator.FromHtml(iKandi.BLL.CommonHelper.GetExFactoryColor(booking.ExFactory, booking.DC, booking.Mode));

            HiddenField hdnStatus = e.Row.FindControl("hdnStatus") as HiddenField;
            (hdnStatus.Parent as TableCell).BackColor = System.Drawing.ColorTranslator.FromHtml(Constants.GetStatusModeColor(booking.StatusModeID));

            FileUpload fileUpload = e.Row.FindControl("fileBookingDocs") as FileUpload;
            fileUpload.Attributes.Add("RowDataBound", "readonly");


        }

        protected void grdOrderAvailable_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.DataRow) return;

            DeliveryBooking booking = e.Row.DataItem as DeliveryBooking;

            if (booking.ShipmentPlanningOrder != null && booking.ShipmentPlanningOrder.PackingList != null && packingID2 == booking.ShipmentPlanningOrder.PackingList.PackingID && packingID2 > 0)
            {
                //grdOrderAvailable.Rows[packingFirstRow2].Cells[18].RowSpan += 1;
                //e.Row.Cells[18].Visible = false;
                grdOrderAvailable.Rows[packingFirstRow2].Cells[18].RowSpan += 1;
                e.Row.Cells[18].Visible = false;
                grdOrderAvailable.Rows[packingFirstRow2].Cells[19].RowSpan += 1;
                e.Row.Cells[19].Visible = false;
                grdOrderAvailable.Rows[packingFirstRow2].Cells[16].RowSpan += 1;
                e.Row.Cells[16].Visible = false;
            }
            else if (booking.ShipmentPlanningOrder.PackingList != null)
            {
                packingID2 = booking.ShipmentPlanningOrder.PackingList.PackingID;
                packingFirstRow2 = e.Row.RowIndex;

                //e.Row.Cells[18].RowSpan = 1;
                e.Row.Cells[18].RowSpan = 1;
                e.Row.Cells[19].RowSpan = 1;
                e.Row.Cells[16].RowSpan = 1;
            }

            if (booking.ShipmentPlanningOrder != null && booking.ShipmentPlanningOrder.ShipmentPlanning != null && shipmentID2 == booking.ShipmentPlanningOrder.ShipmentPlanning.ShipmentID && shipmentID2 > 0)
            {
                grdOrderAvailable.Rows[shipmentFirstRow2].Cells[12].RowSpan += 1;
                e.Row.Cells[12].Visible = false;
                grdOrderAvailable.Rows[shipmentFirstRow2].Cells[13].RowSpan += 1;
                e.Row.Cells[13].Visible = false;
            }
            else if (booking.ShipmentPlanningOrder != null && booking.ShipmentPlanningOrder.ShipmentPlanning != null)
            {
                shipmentID2 = booking.ShipmentPlanningOrder.ShipmentPlanning.ShipmentID;
                shipmentFirstRow2 = e.Row.RowIndex;

                e.Row.Cells[12].RowSpan = 1;
                e.Row.Cells[13].RowSpan = 1;
            }

            HiddenField hdnSerial = e.Row.FindControl("hdnSerial") as HiddenField;
            (hdnSerial.Parent as TableCell).BackColor = System.Drawing.ColorTranslator.FromHtml(Constants.GetSerialNumberColor(booking.ExFactory));

            Label lblMode = e.Row.FindControl("lblMode") as Label;
            (lblMode.Parent as TableCell).BackColor = System.Drawing.ColorTranslator.FromHtml(iKandi.BLL.CommonHelper.GetDeliveryModeColor(booking.Mode));

            Label lblExFactory = e.Row.FindControl("lblExFactory") as Label;
            (lblExFactory.Parent as TableCell).BackColor = System.Drawing.ColorTranslator.FromHtml(iKandi.BLL.CommonHelper.GetExFactoryColor(booking.ExFactory, booking.DC, booking.Mode));

            HiddenField hdnStatus = e.Row.FindControl("hdnStatus") as HiddenField;
            (hdnStatus.Parent as TableCell).BackColor = System.Drawing.ColorTranslator.FromHtml(Constants.GetStatusModeColor(booking.StatusModeID));
        }

        private string GetUploadeFileNames(string originalFiles, string fileUploadKey)
        {
            int fileCounter = 0;

            string strSplitedKey = fileUploadKey.Substring(fileUploadKey.LastIndexOf("$"));
            fileUploadKey = fileUploadKey.Replace(strSplitedKey, string.Empty);
            fileUploadKey = fileUploadKey.Substring(fileUploadKey.LastIndexOf("$")) + strSplitedKey;

            foreach (string key in Request.Files)
            {
                if (key.Contains(fileUploadKey))
                {
                    HttpPostedFile file = Request.Files[fileCounter];

                    if (Request.Files[key].ContentLength == 0)
                        continue;

                    string savedFileName = FileHelper.SaveFile(file.InputStream, file.FileName, Constants.DELIVERY_FOLDER_PATH, false, string.Empty);

                    string fullFileName = file.FileName;
                    int index = fullFileName.LastIndexOf("\\");

                    fullFileName = fullFileName.Substring(index + 1);

                    if (originalFiles == string.Empty)
                        originalFiles = fullFileName + "$$" + savedFileName;
                    else
                        originalFiles += "$$" + fullFileName + "$$" + savedFileName;
                }

                fileCounter++;
            }

            return originalFiles;
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

    }
}