using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Collections.Generic;
using iKandi.Common;
using iKandi.Web.Components;
using iKandi.BLL;

namespace iKandi.Web.UserControls.Forms
{
    public partial class BookingCalculator : BaseUserControl
    {
        List<DeliveryMode> DeliveryModeCollection = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (ApplicationHelper.LoggedInUser.UserData.Designation == Designation.BIPL_Sales_Manager ||
            //    ApplicationHelper.LoggedInUser.UserData.Designation == Designation.BIPL_Sales_Advisor ||
            //    ApplicationHelper.LoggedInUser.UserData.Designation == Designation.iKandi_Sales_Manager ||
            //    ApplicationHelper.LoggedInUser.UserData.Designation == Designation.iKandi_Sales_SalesManager ||
            //    ApplicationHelper.LoggedInUser.UserData.PrimaryGroup == Group.BIPL_Logistics ||
            //    ApplicationHelper.LoggedInUser.ClientData != null)
            //{
            //    this.Visible = true;
            //}
            //else
            //{
            //    this.Visible = false;
            //    return;
            //}
            if (!IsPostBack)
            {
                DeliveryModeCollection = this.AdminControllerInstance.GetBookingModes();
                txtAFLeadTime.Text = DeliveryModeCollection[0].LeadTime.ToString();
                txtAHLeadTime.Text = DeliveryModeCollection[1].LeadTime.ToString();
                txtSFLeadTime.Text = DeliveryModeCollection[2].LeadTime.ToString();
                txtSHLeadTime.Text = DeliveryModeCollection[3].LeadTime.ToString();
                txtFOBLeadTime.Text = DeliveryModeCollection[4].LeadTime.ToString();

                //txtAFLeadTime.Text = "12";
                //txtAHLeadTime.Text = "13";
                //txtSFLeadTime.Text = "17";
                //txtSHLeadTime.Text = "18";
                //txtFOBLeadTime.Text = "12";

                txtAFExpectedBookingDate.Text = txtAHExpectedBookingDate.Text = txtSFExpectedBookingDate.Text =
                txtSHExpectedBookingDate.Text = txtFOBExpectedBookingDate.Text = DateHelper.GetNextMondayDate();

                DateTime dt1 = DateTime.ParseExact(txtAFExpectedBookingDate.Text, "dd MMM yy (ddd)", System.Globalization.CultureInfo.InvariantCulture);
                txtAFCalculatedDeliveryDate.Text = dt1.AddDays(Convert.ToInt32(DeliveryModeCollection[0].LeadTime) * 7).ToString("dd MMM yy (ddd)");

                DateTime dt2 = DateTime.ParseExact(txtAHExpectedBookingDate.Text, "dd MMM yy (ddd)", System.Globalization.CultureInfo.InvariantCulture);
                txtAHCalculatedDeliveryDate.Text = dt2.AddDays(Convert.ToInt32(DeliveryModeCollection[1].LeadTime) * 7).ToString("dd MMM yy (ddd)");

                DateTime dt3 = DateTime.ParseExact(txtSFExpectedBookingDate.Text, "dd MMM yy (ddd)", System.Globalization.CultureInfo.InvariantCulture);
                txtSFCalculatedDeliveryDate.Text = dt3.AddDays(Convert.ToInt32(DeliveryModeCollection[2].LeadTime) * 7).ToString("dd MMM yy (ddd)");

                DateTime dt4 = DateTime.ParseExact(txtSHExpectedBookingDate.Text, "dd MMM yy (ddd)", System.Globalization.CultureInfo.InvariantCulture);
                txtSHCalculatedDeliveryDate.Text = dt4.AddDays(Convert.ToInt32(DeliveryModeCollection[3].LeadTime) * 7).ToString("dd MMM yy (ddd)");

                DateTime dt5 = DateTime.ParseExact(txtFOBExpectedBookingDate.Text, "dd MMM yy (ddd)", System.Globalization.CultureInfo.InvariantCulture);
                txtFOBCalculatedDeliveryDate.Text = dt5.AddDays(Convert.ToInt32(DeliveryModeCollection[4].LeadTime) * 7).ToString("dd MMM yy (ddd)");               

            }
        }
    }
}