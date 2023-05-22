using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI.WebControls;
using iKandi.Common;
using iKandi.Web.Components;

namespace iKandi.Web
{
    public partial class SendShipmentEmail : BasePage
    {
        #region Properties

        public int ShipmentID
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.Params["shipmentid"]))
                    return Convert.ToInt32(Request.Params["shipmentid"]);

                return -1;
            }
        }

        public int BookingID
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.Params["bookingid"]))
                    return Convert.ToInt32(Request.Params["bookingid"]);

                return -1;
            }
        }

        public int Mode
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.Params["mode"]))
                    return Convert.ToInt32(Request.Params["mode"]);

                return -1;
            }
        }

        #endregion

        #region Event Handlers

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                BindControls();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            var cc = new List<string>();

            foreach (ListItem item in ddlUsers.Items)
                if (item.Selected)
                    cc.Add(item.Value);

            if (!string.IsNullOrEmpty(txtAdditionalEmails.Text))
            {
                string[] emails = txtAdditionalEmails.Text.Split(new[] {','});

                foreach (string email in emails)
                    cc.Add(email);
            }

            bool success = false;
            switch (Mode)
            {
                case 1:

                    success = NotificationControllerInstance.SendShipmentPreAlertEmail(ShipmentID, cc, txtRemarks.Text);

                    if (success)
                    {
                        DeliveryControllerInstance.UpdateShipmentEmailInfo(ShipmentID, (int) ShipmentEmailType.PRE_ALERT);
                        pnlForm.Visible = false;
                        pnlMessage.Visible = true;
                    }

                    break;

                case 2:
                    success = NotificationControllerInstance.SendShipmentAdviseEmail(ShipmentID, cc, txtRemarks.Text,
                                                                                     GetOrdersForShipmentPlanningAdvise(
                                                                                         ShipmentID));

                    if (success)
                    {
                        DeliveryControllerInstance.UpdateShipmentEmailInfo(ShipmentID,
                                                                           (int) ShipmentEmailType.POST_SHIPMENT);
                        pnlForm.Visible = false;
                        pnlMessage.Visible = true;
                    }

                    break;

                case 3:

                    success = NotificationControllerInstance.SendBookingEmail(BookingID, cc, txtRemarks.Text);

                    if (success)
                    {
                        DeliveryControllerInstance.UpdateBookingEmailInfo(BookingID, true);
                        pnlForm.Visible = false;
                        pnlMessage.Visible = true;
                    }

                    break;
            }
        }

        #endregion

        #region Private

        private void BindControls()
        {
            DropdownHelper.BindUsersEmail(ddlUsers);

            switch (Mode)
            {
                case 1:
                    lblHeading.Text = "Shipment Planning";
                    break;

                case 2:
                    lblHeading.Text = "Shipment Advise";
                    break;

                case 3:
                    lblHeading.Text = "Booking Advise";
                    break;

                case 4:
                    lblHeading.Text = "Delivered";
                    break;
            }
        }

        private string GetOrdersForShipmentPlanningAdvise(int shipmentId)
        {
            DataSet dsOrderDetail = DeliveryControllerInstance.GetOrderDetailByShipmentId(shipmentId);

            var properties = new Dictionary<string, object>();
            properties.Add("OrderDetailsForShipmentAdvise", dsOrderDetail);
            return PageHelper.GetControlHtml("~/UserControls/Lists/ShipmentPlanningAdviseOrdersPopup.ascx", properties);
        }

        #endregion
    }
}