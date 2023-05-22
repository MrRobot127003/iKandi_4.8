using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using iKandi.Web.Components;
using iKandi.BLL;
using iKandi.Common;
using System.Data;

namespace iKandi.Web.UserControls.Lists
{
    public partial class AccessoriesPopup : System.Web.UI.UserControl
    {
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
        OrderPlaceController objOrderPlaceController = new OrderPlaceController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //PopulateOrderData(null);
            }
        }

        //private void PopulateOrderData(List<ContractDetailAccessories> objAccessCollection)
        //{
        //    int UserId = ApplicationHelper.LoggedInUser.UserData.UserID;

        //    if (objAccessCollection == null)
        //    {
        //        objAccessCollection = objOrderPlaceController.Get_Accessories_Section_OrderPlace(OrderID);

        //        dlstAccessoriesPopup.DataSource = objAccessCollection;
        //        dlstAccessoriesPopup.DataBind();
        //    }
        //    else
        //    {
        //        dlstAccessoriesPopup.DataSource = objAccessCollection;
        //        dlstAccessoriesPopup.DataBind();
        //    }
        //}

        //protected void dlstAccessoriesPopup_ItemDataBound(object sender, DataListItemEventArgs e)
        //{
        //    int iRowIndex = e.Item.ItemIndex;
        //    if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        //    {
        //        HiddenField hdnIndex = (HiddenField)e.Item.FindControl("hdnIndex");
        //        HiddenField hdnAccessName = (HiddenField)e.Item.FindControl("hdnAccessName");
        //        HtmlInputHidden hdnSizeId = (HtmlInputHidden)e.Item.FindControl("hdnSizeId");
        //        HiddenField hdnAccessSize = (HiddenField)e.Item.FindControl("hdnAccessSize");
        //        TextBox txtAccessName = (TextBox)e.Item.FindControl("txtAccessName");
        //        string AccessName = hdnAccessName.Value;

        //        if (hdnSizeId.Value != "-1")
        //        {
        //            txtAccessName.Text = AccessName + " (" + hdnAccessSize.Value + ")";
        //            txtAccessName.ToolTip = hdnAccessName.Value + " (" + hdnAccessSize.Value + ")";
        //        }
        //        else
        //        {
        //            txtAccessName.Text = AccessName;
        //            txtAccessName.ToolTip = hdnAccessName.Value;

        //        }
        //        hdnIndex.Value = iRowIndex.ToString();
        //    }
        //}

        //protected void dlstAccessoriesPopup_DeleteCommand(object source, DataListCommandEventArgs e)
        //{
        //    int SeqId = Convert.ToInt32(e.CommandArgument);

        //    List<ContractDetailAccessories> objAccessCollection = new List<ContractDetailAccessories>();

        //    for (int AccNo = 0; AccNo < dlstAccessoriesPopup.Items.Count; AccNo++)
        //    {
        //        HtmlInputHidden hdnAccessId = (HtmlInputHidden)dlstAccessoriesPopup.Items[AccNo].FindControl("hdnAccessId");
        //        HiddenField hdnAccessName = (HiddenField)dlstAccessoriesPopup.Items[AccNo].FindControl("hdnAccessName");
        //        HtmlInputHidden hdnSizeId = (HtmlInputHidden)dlstAccessoriesPopup.Items[AccNo].FindControl("hdnSizeId");
        //        HiddenField hdnAccessSize = (HiddenField)dlstAccessoriesPopup.Items[AccNo].FindControl("hdnAccessSize");
        //        HiddenField hdnSeqId = (HiddenField)dlstAccessoriesPopup.Items[AccNo].FindControl("hdnSeqId");
        //        HiddenField hdnId = (HiddenField)dlstAccessoriesPopup.Items[AccNo].FindControl("hdnId");
        //        if (SeqId == Convert.ToInt16(hdnSeqId.Value))
        //        {
        //            if (hdnId.Value != "")
        //            {
        //                if (Convert.ToInt64(hdnId.Value) > 0)
        //                {
        //                    bool iDelete = objOrderPlaceController.Delete_Accessories_OrderPlace(Convert.ToInt64(hdnId.Value));
        //                }
        //            }
        //        }
        //        else
        //        {
        //            ContractDetailAccessories orderDetailAccess = new ContractDetailAccessories();
        //            orderDetailAccess.AccessoriesId = hdnAccessId.Value == "" ? -1 : Convert.ToInt32(hdnAccessId.Value);
        //            orderDetailAccess.AccessoriesName = hdnAccessName.Value;
        //            orderDetailAccess.SizeId = hdnSizeId.Value == "" ? -1 : Convert.ToInt32(hdnSizeId.Value);
        //            orderDetailAccess.Size = hdnAccessSize.Value;
        //            orderDetailAccess.AccId = hdnId.Value == "" ? -1 : Convert.ToInt64(hdnId.Value);
        //            orderDetailAccess.SeqId = AccNo;

        //            objAccessCollection.Add(orderDetailAccess);
        //        }
        //    }

        //    PopulateOrderData(objAccessCollection);
        //}

        //protected void imgbtnAdd_Click(object sender, ImageClickEventArgs e)
        //{

        //    List<ContractDetailAccessories> objAccessCollection = new List<ContractDetailAccessories>();
        //    int MaxAccNo = 0;

        //    if (dlstAccessoriesPopup.Items.Count > 19)
        //    {
        //        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "jQuery.facebox('you can not add more than 20 accessories for an order');", true);
        //        return;
        //    }

        //    for (int AccNo = 0; AccNo < dlstAccessoriesPopup.Items.Count; AccNo++)
        //    {
        //        HtmlInputHidden hdnAccessId = (HtmlInputHidden)dlstAccessoriesPopup.Items[AccNo].FindControl("hdnAccessId");
        //        HiddenField hdnAccessName = (HiddenField)dlstAccessoriesPopup.Items[AccNo].FindControl("hdnAccessName");
        //        HtmlInputHidden hdnSizeId = (HtmlInputHidden)dlstAccessoriesPopup.Items[AccNo].FindControl("hdnSizeId");
        //        HiddenField hdnAccessSize = (HiddenField)dlstAccessoriesPopup.Items[AccNo].FindControl("hdnAccessSize");
        //        HiddenField hdnSeqId = (HiddenField)dlstAccessoriesPopup.Items[AccNo].FindControl("hdnSeqId");
        //        HiddenField hdnId = (HiddenField)dlstAccessoriesPopup.Items[AccNo].FindControl("hdnId");

        //        ContractDetailAccessories orderDetailAccess = new ContractDetailAccessories();
        //        orderDetailAccess.AccessoriesId = hdnAccessId.Value == "" ? -1 : Convert.ToInt32(hdnAccessId.Value);
        //        orderDetailAccess.AccessoriesName = hdnAccessName.Value;
        //        orderDetailAccess.SizeId = hdnSizeId.Value == "" ? -1 : Convert.ToInt32(hdnSizeId.Value);
        //        orderDetailAccess.Size = hdnAccessSize.Value;
        //        orderDetailAccess.AccId = hdnId.Value == "" ? -1 : Convert.ToInt64(hdnId.Value);
        //        orderDetailAccess.SeqId = AccNo;
        //        MaxAccNo = AccNo;

        //        objAccessCollection.Add(orderDetailAccess);

        //    }
        //    ContractDetailAccessories orderDetailAccess1 = new ContractDetailAccessories();
        //    orderDetailAccess1.AccessoriesId = -1;
        //    orderDetailAccess1.AccessoriesName = null;
        //    orderDetailAccess1.SizeId = -1;
        //    orderDetailAccess1.Size = null;
        //    orderDetailAccess1.AccId = -1;
        //    orderDetailAccess1.SeqId = MaxAccNo + 1;

        //    objAccessCollection.Add(orderDetailAccess1);

        //    PopulateOrderData(objAccessCollection);

        //}

        //protected void btnSubmit_Click(object sender, EventArgs e)
        //{
        //    List<ContractDetailAccessories> objAccessCollection = new List<ContractDetailAccessories>();

        //    for (int AccNo = 0; AccNo < dlstAccessoriesPopup.Items.Count; AccNo++)
        //    {
        //        HtmlInputHidden hdnAccessId = (HtmlInputHidden)dlstAccessoriesPopup.Items[AccNo].FindControl("hdnAccessId");
        //        HiddenField hdnAccessName = (HiddenField)dlstAccessoriesPopup.Items[AccNo].FindControl("hdnAccessName");
        //        HtmlInputHidden hdnSizeId = (HtmlInputHidden)dlstAccessoriesPopup.Items[AccNo].FindControl("hdnSizeId");
        //        HiddenField hdnAccessSize = (HiddenField)dlstAccessoriesPopup.Items[AccNo].FindControl("hdnAccessSize");
        //        HiddenField hdnSeqId = (HiddenField)dlstAccessoriesPopup.Items[AccNo].FindControl("hdnSeqId");
        //        HiddenField hdnId = (HiddenField)dlstAccessoriesPopup.Items[AccNo].FindControl("hdnId");
        //        TextBox txtAccessName = (TextBox)dlstAccessoriesPopup.Items[AccNo].FindControl("txtAccessName");

        //        if (txtAccessName.Text != "")
        //        {
        //            ContractDetailAccessories orderDetailAccess = new ContractDetailAccessories();
        //            orderDetailAccess.AccessoriesId = hdnAccessId.Value == "" ? -1 : Convert.ToInt32(hdnAccessId.Value);
        //            orderDetailAccess.AccessoriesName = hdnAccessName.Value;
        //            orderDetailAccess.SizeId = hdnSizeId.Value == "" ? -1 : Convert.ToInt32(hdnSizeId.Value);
        //            orderDetailAccess.Size = hdnAccessSize.Value;
        //            orderDetailAccess.AccId = hdnId.Value == "" ? -1 : Convert.ToInt64(hdnId.Value);
        //            orderDetailAccess.SeqId = AccNo;
        //            orderDetailAccess.ColorPrint = DBNull.Value.ToString();
        //            orderDetailAccess.IsDtm = false;

        //            objAccessCollection.Add(orderDetailAccess);
        //        }

        //    }

        //    bool save = objOrderPlaceController.Insert_Update_Accessories(objAccessCollection, OrderID, -1);
        //    if (save == true)
        //    {
        //        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "submit", "CallParentPage();", true);
        //    }
        //    else
        //    {
        //        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "jQuery.facebox('some error occured during save');", true);
        //        return;
        //    }
        //}
    }
}