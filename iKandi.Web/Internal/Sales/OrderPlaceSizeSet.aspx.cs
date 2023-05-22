using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iKandi.BLL;
using iKandi.Common;
using System.Web.UI.HtmlControls;
using iKandi.Web.Components;

namespace iKandi.Web.Internal.Sales
{
    public partial class OrderPlaceSizeSet : System.Web.UI.Page
    {
        public int OrderDetailId { get { if (!string.IsNullOrEmpty(Request.QueryString["OrderDetailId"])) { return Convert.ToInt32(Request.QueryString["OrderDetailId"]); } return -1; } }
        public int Quantity { get { if (!string.IsNullOrEmpty(Request.QueryString["Quantity"])) { return Convert.ToInt32(Request.QueryString["Quantity"]); } return -1; } }
        public int ClientId { get { if (!string.IsNullOrEmpty(Request.QueryString["ClientId"])) { return Convert.ToInt32(Request.QueryString["ClientId"]); } return -1; } }
        public int DeptId { get { if (!string.IsNullOrEmpty(Request.QueryString["DeptId"])) { return Convert.ToInt32(Request.QueryString["DeptId"]); } return -1; } }
        public string ContractNumber { get { if (!string.IsNullOrEmpty(Request.QueryString["ContractNumber"])) { return Request.QueryString["ContractNumber"]; } return string.Empty; } }
        public string LineNumber { get { if (!string.IsNullOrEmpty(Request.QueryString["LineNumber"])) { return Request.QueryString["LineNumber"]; } return string.Empty; } }

        OrderPlaceController objOrderPlaceController = new OrderPlaceController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                hdnOrderDetailId.Value = OrderDetailId.ToString();
                lblContractNo.Text = ContractNumber;
                lblLineNo.Text = LineNumber;
                lblQuantity.Text = Quantity.ToString("N0");
                hdnTotalQuantity.Value = Quantity.ToString();
                lblRemainingQty.Text = Quantity.ToString("N0");
                GetSizeSet();
            }
        }

        private void GetSizeSet()
        {
            List<ContractDetailSize> objContractDetailSize = objOrderPlaceController.GetSizeSetDetails(ClientId, DeptId, 0, OrderDetailId);
            for (int i = 0; i < objContractDetailSize.Count; i++)
            {
                string Option = objContractDetailSize[i].SizeOption.ToString();
                rbtnOption.Items.Add(new ListItem("Option " + Option, Option));
                int OrderSizeOption = Convert.ToInt32(objContractDetailSize[i].OrderSizeOption);
                if (OrderSizeOption > 0)
                {
                    rbtnOption.Items[i].Selected = true;
                    hdnOption.Value = OrderSizeOption.ToString();
                }
                else
                {
                    rbtnOption.Items[0].Selected = true;
                }
            }
            foreach (ListItem item in rbtnOption.Items)
            {
                item.Attributes.Add("onclick", "GetSizeSet(this);");
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            int UserId = Convert.ToInt32(ApplicationHelper.LoggedInUser.UserData.UserID.ToString());
            try
            {
                int SizeLength = hdnSizeLength.Value == "" ? 0 : Convert.ToInt32(hdnSizeLength.Value);
                int OptionId = Convert.ToInt32(rbtnOption.SelectedValue);
                if (OptionId > 0)
                {
                    int PrevOption = hdnOption.Value == "" ? 0 : Convert.ToInt16(hdnOption.Value);
                    int OrderDetailId = hdnOrderDetailId.Value == "" ? 0 : Convert.ToInt32(hdnOrderDetailId.Value);
                    for (var Sno = 1; Sno <= SizeLength; Sno++)
                    {
                        ContractDetailSize objSizeDetail = new ContractDetailSize();

                        TextBox txtSize = (TextBox)this.form1.FindControl("txtsize_" + Sno);
                        HtmlInputText txtSingle = (HtmlInputText)this.form1.FindControl("single_" + Sno);
                        HtmlInputText txtRatioPack = (HtmlInputText)this.form1.FindControl("ratio_pack_" + Sno);
                        HtmlInputText txtRatio = (HtmlInputText)this.form1.FindControl("ratio_" + Sno);

                        objSizeDetail.Size = txtSize.Text.Trim();
                        objSizeDetail.Singles = txtSingle.Value == "" ? 0 : Convert.ToInt32(txtSingle.Value);
                        objSizeDetail.RatioPack = txtRatioPack.Value == "" ? 0 : Convert.ToInt32(txtRatioPack.Value);
                        objSizeDetail.Ratio = txtRatio.Value == "" ? 0 : Convert.ToInt32(txtRatio.Value);
                        objSizeDetail.OrderDetailID = OrderDetailId;
                        objSizeDetail.SizeOption = OptionId;

                        bool Save = objOrderPlaceController.Insert_Update_OrderDetail_Size(objSizeDetail, UserId);

                    }
                }
            }
            catch { }

            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "closeSizeSet();", true);
        }

    }
}