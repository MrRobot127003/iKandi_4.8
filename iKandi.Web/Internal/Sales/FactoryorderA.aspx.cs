using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iKandi.BLL;
using iKandi.Web.Components;
using iKandi.Common;

namespace iKandi.Web.Internal.Sales
{
    public partial class FactoryorderA : System.Web.UI.Page
    {
        string Status = string.Empty;
        #region Properties

        public int OrderID
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.QueryString["orderid"]))
                {
                    return Convert.ToInt32(Request.QueryString["orderid"]);
                }

                return -1;
            }
        }

        #endregion
        protected bool bChechFirstPage;
        protected void Page_Load(object sender, EventArgs e)
        {
            string squerystring = Request.QueryString["orderid"];
            if (squerystring == null)
                bChechFirstPage = true;
            else
                bChechFirstPage = false;

             ddlDeliveryMode.DataSource = iKandi.BLL.CommonHelper.GetDeliveryModes(true);
             ddlDeliveryMode.DataTextField = "Code";
             ddlDeliveryMode.DataValueField = "Id";
             ddlDeliveryMode.DataBind();

            Page.Form.Enctype = "multipart/form-data";
            
            if (!IsPostBack)
            {
                hdnOrderId.Value = this.OrderID.ToString();
                BindControls();
                // PopulateOrderData();
            }
        }

        private void BindControls()
        {
            txtOrderDate.Text = DateTime.Now.ToString("dd MMM yy (ddd)");
            DropdownHelper.BindAllClients(ddlClient as ListControl);
            hdnExpectedDate.Value = DateHelper.GetNextMondayDate().ToString();
            txtOrderDate.DataBind();
            txtStyleNumber.DataBind();
            txtDescription.DataBind();
            ddlClient.DataBind();
            txtBIPLPrice.DataBind();
            // btnsentProposal.DataBind();
            DropdownHelper.BindAllOrderTypeOfPacking(ddlTypeOfPacking as ListControl);
        }

      
    }
}