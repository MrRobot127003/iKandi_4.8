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
    public partial class Accessory : System.Web.UI.Page
    {
        public int SupplierPoId
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.QueryString["SupplierPoId"]))
                {
                    return Convert.ToInt32(Request.QueryString["SupplierPoId"]);
                }
                return 6;
            }
        }
        public int OrderDetailId
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.QueryString["OrderDetailId"]))
                {
                    return Convert.ToInt32(Request.QueryString["OrderDetailId"]);
                }
                return -1;
            }
        }
        AccessoryWorkingController objAccessory = new AccessoryWorkingController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (iKandi.Web.Components.ApplicationHelper.LoggedInUser == null || iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData == null)
                Response.Redirect("~/public/Login.aspx");

            if (!IsPostBack)
                BindData();
        }

        private void BindData()
        {
            try
            {
                if (OrderDetailId > 0)
                {
                    AccessoryPending objAccessoryPending = objAccessory.GetAccessory_PoDetails_Liability(SupplierPoId, OrderDetailId);

                    lblPoNo.Text = objAccessoryPending.PoNumber;
                    txtPoDate.Text = objAccessoryPending.PoDate == DateTime.MinValue ? "" : Convert.ToDateTime(objAccessoryPending.PoDate).ToString("dd MMM yy (ddd)");
                    txtETADate.Text = objAccessoryPending.PoEta == DateTime.MinValue ? "" : Convert.ToDateTime(objAccessoryPending.PoEta).ToString("dd MMM yy (ddd)");
                    lblSupplier.Text = objAccessoryPending.SupplierName;

                    lblAccessoryQuality.Text = objAccessoryPending.AccessoryName;
                    if (objAccessoryPending.Size != "")
                        lblSize.Text = objAccessoryPending.Size == "Default" ? "" : "(" + objAccessoryPending.Size + ")";

                    lblcolorprint.Text = objAccessoryPending.Color_Print;
                    lblShrinkage.Text = objAccessoryPending.Shrinkage == 0 ? "" : objAccessoryPending.Shrinkage.ToString() + " %";
                    lblWastage.Text = objAccessoryPending.Wastage == 0 ? "" : objAccessoryPending.Wastage.ToString() + " %";

                    if (objAccessoryPending.SupplyType == 1)
                        lblAccessType.Text = "Greige";
                    else if (objAccessoryPending.SupplyType == 2)
                        lblAccessType.Text = "Process";
                    else if (objAccessoryPending.SupplyType == 3)
                        lblAccessType.Text = "Finish";

                    lblPoQty.Text = objAccessoryPending.PoQuantity == 0 ? "" : objAccessoryPending.PoQuantity.ToString("N0");
                    hdnPoQty.Value = objAccessoryPending.PoQuantity.ToString();

                    lblContractQty.Text = objAccessoryPending.QuantityToOrder == 0 ? "" : objAccessoryPending.QuantityToOrder.ToString("N0");
                    hdnOrderQty.Value = objAccessoryPending.QuantityToOrder.ToString();

                    lblSrvQty.Text = objAccessoryPending.SRVQuantity == 0 ? "" : objAccessoryPending.SRVQuantity.ToString("N0");
                    hdnSrvQty.Value = objAccessoryPending.SRVQuantity.ToString();
                   
                    lblSendQty.Text = objAccessoryPending.SendQty == 0 ? "" : objAccessoryPending.SendQty.ToString("N0");
                    hdnSendQty.Value = objAccessoryPending.SendQty.ToString();

                    if (objAccessoryPending.LiabilityQty > 0)
                    {
                        txtLiabilityQty.Text = objAccessoryPending.LiabilityQty.ToString();
                        hdnLiabilityQty.Value = objAccessoryPending.LiabilityQty.ToString();
                    }
                    //else
                    //{
                    //    txtLiabilityQty.Text = objAccessoryPending.SRVQuantity == 0 ? "" : objAccessoryPending.SRVQuantity.ToString("N0");
                    //    hdnLiabilityQty.Value = "0";
                    //}
                }
            }
            catch (Exception ex)
            {
                
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtLiabilityQty.Text != "")
            {
                AccessoryPending objAccessoryPending = new AccessoryPending();
                objAccessoryPending.OrderDetailId = OrderDetailId;
                objAccessoryPending.SupplierPoId = SupplierPoId;
                objAccessoryPending.QuantityToOrder = hdnOrderQty.Value == "" ? 0 : Convert.ToInt32(hdnOrderQty.Value);
                objAccessoryPending.PoQuantity = hdnPoQty.Value == "" ? 0 : Convert.ToInt32(hdnPoQty.Value);
                objAccessoryPending.SRVQuantity = hdnSrvQty.Value == "" ? 0 : Convert.ToInt32(hdnSrvQty.Value);
                objAccessoryPending.SendQty = hdnSendQty.Value == "" ? 0 : Convert.ToInt32(hdnSendQty.Value);
                objAccessoryPending.LiabilityQty = txtLiabilityQty.Text == "" ? 0 : Convert.ToInt32(txtLiabilityQty.Text.Replace(",", ""));

                int UserId = iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.UserID;

                int iSave = objAccessory.Save_AccessoryLiability(objAccessoryPending, UserId);
            }
        }
    }
}