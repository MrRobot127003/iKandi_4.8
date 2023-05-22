using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iKandi.BLL;
using iKandi.Common;
using System.Data;
using iKandi.Web.Components;

namespace iKandi.Web.Internal.Sales
{
    public partial class OrderProcess : BasePage
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
        int ClientId = -1;
        int DepartmentId = -1;
        string StyleNumber = "";
        string SerialNumber = "";

        int Userid = ApplicationHelper.LoggedInUser.UserData.UserID;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //BindControls();
                BindDepartment(-1);
                PopulateOrderData();
                //var vv = iKandi.Web.Components.PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_ORDER_DATE) ? "date-picker date_style" : " date_style do-not-allow-typing";

            }
        }

        private void PopulateOrderData()
        {

            iKandi.Common.Order order;

            if (this.OrderID == -1)
            {
                lblOrderDate.Text = DateTime.Now.ToString("dd MMM yy (ddd)");
                //order = new iKandi.Common.Order();
                //order.TypeOfPacking = Convert.ToInt32(ddlTypeOfPacking.SelectedValue);
                //lblBiplPriceSign.Text = "£";
                //order.OrderBreakdown = new List<OrderDetail>();
                //OrderDetail orderDetail = new OrderDetail();
                //orderDetail.OrderSizes = new List<OrderDetailSizes>();
                //orderDetail.ParentOrder = new iKandi.Common.Order();
                //orderDetail.ParentOrder.Costing = new iKandi.Common.Costing();

                //orderDetail.LineItemNumber = string.Empty;
                //orderDetail.ContractNumber = string.Empty;
                //orderDetail.Fabric1 = "Fabric";
                //orderDetail.Fabric1Details = "Color / PRD";
                //orderDetail.Fabric2 = "Fabric";
                //orderDetail.Fabric2Details = "Color / PRD";
                //orderDetail.Fabric3 = "Fabric";
                //orderDetail.Fabric3Details = "Color / PRD";
                //orderDetail.Fabric4 = "Fabric";
                //orderDetail.Fabric4Details = "Color / PRD";
                ////orderDetail.ColorPrint = string.Empty;
                //orderDetail.Quantity = 0;
                //orderDetail.iKandiPrice = 0;
                //orderDetail.ExFactory = DateTime.MinValue;
                //orderDetail.WeekToEx = 1;
                //orderDetail.DC = DateTime.Today;
                //orderDetail.WeeksToDC = 1;
                //orderDetail.OrderDetailID = -1;
                //orderDetail.StatusModeID = -1;
                //orderDetail.StatusModeSequence = -1;
                //orderDetail.IsAirFabric1 = false;
                //orderDetail.IsAirFabric2 = false;
                //orderDetail.IsAirFabric3 = false;
                //orderDetail.IsAirFabric4 = false;
                //orderDetail.ParentOrder.Costing.CurrencySign = "£";

                //order.OrderBreakdown.Add(orderDetail);

                //if (order.OrderBreakdown != null && order.OrderBreakdown.Count > 0)
                //{
                //    System.Web.Script.Serialization.JavaScriptSerializer oSerializer =
                //    new System.Web.Script.Serialization.JavaScriptSerializer();

                //    string sJSON = oSerializer.Serialize(order.OrderBreakdown);

                //    PageHelper.AddJScriptVariable("orderDetail", "{" + string.Format("table: {0}", sJSON) + "}");
                //}

                gvContractDetail.DataSource = null;
                gvContractDetail.DataBind();

            }
            if (this.OrderID > -1)
            {
                order = this.OrderControllerInstance.GetOrderOrderForm(OrderID);

                lblOrderDate.Text = order.OrderDate.ToString("dd MMM yy (ddd)");
                txtStyleNumber.Value = order.Style.StyleNumber;
                txtSerialNumber.Value = order.SerialNumber;
                lblBuyer.Text = order.Style.client.CompanyName;
                hdnClientId.Value = order.ClientID.ToString();
                BindDepartment(order.Style.cdept.DeptID);
               
                lblCmt.Text = order.Costing.CMT == 0 ? "" : order.Costing.CMT.ToString();
                lblProductTime.Text = order.ProdDays == 0 ? "" : order.ProdDays.ToString();
                lblBihTgt.Text = order.BIHdate == DateTime.MinValue ? "" : order.BIHdate.ToString("dd MMM yy (ddd)");
                lblBulkTgtDate.Text = order.BulkApprTarget == DateTime.MinValue ? "" : order.BulkApprTarget.ToString("dd MMM yy (ddd)");
                LblInitialApprTgt.Text = order.InitialApprTarget == DateTime.MinValue ? "" : order.InitialApprTarget.ToString("dd MMM yy (ddd)");
                lblAccountManager.Text = order.AccountManagerName.ToString();
                lblTotQty.Text = order.TotalQuantity.ToString();
                if (order.Description != "")
                {
                    imgDescription.Visible = true;
                    lblDescription.Text = order.Description;
                }

                if ((order.Style.SampleImageURL1 != "") && (order.Style.SampleImageURL1 != null))
                {
                    imgPrint.ImageUrl = "/Uploads/Style/thumb-" + order.Style.SampleImageURL1;
                    imgPrint.CssClass = "RemoveHide";

                }
                if ((order.Style.SampleImageURL2 != "") && (order.Style.SampleImageURL2 != null))
                {
                    imgStyle.ImageUrl = "/Uploads/Style/thumb-" + order.Style.SampleImageURL2;
                    imgStyle.CssClass = "RemoveHide";
                }
                if ((order.Style.SampleImageURL3 != "") && (order.Style.SampleImageURL3 != null))
                {
                    imagePrint.ImageUrl = "/Uploads/Style/thumb-" + order.Style.SampleImageURL3;
                    imagePrint.CssClass = "RemoveHide";
                }

                ddlOrderType.SelectedValue = order.OrderTypes.ToString();

                gvContractDetail.DataSource = order.OrderBreakdown;
                gvContractDetail.DataBind();

            }

        }

        private void BindDepartment(int DeptId)
        {
            ClientId = Convert.ToInt32(hdnClientId.Value);

            List<ClientDepartment> cd = this.ClientControllerInstance.GetClientDeptsByClientID(Convert.ToInt32(ClientId));
            foreach (ClientDepartment client in cd)
            {
                ddlDepartment.Items.Add(new ListItem(client.Name, client.DeptID.ToString()));
            }           
            if(DeptId != -1)
            {
                ddlDepartment.SelectedValue = DeptId.ToString();
            }

        }

        protected void btnStyle_Click(object sender, EventArgs e)
        {
            StyleNumber = txtStyleNumber.Value;
            if (StyleNumber != "")
            {
                iKandi.Common.Order objOrder = new Common.Order();
                objOrder = this.OrderControllerInstance.GetInfoByStyleNumber(StyleNumber);
                ClientId = objOrder.Costing.ClientID;
                hdnClientId.Value = objOrder.Costing.ClientID.ToString();
                lblBuyer.Text = objOrder.Costing.ClientName;
                SerialNumber = this.OrderControllerInstance.GetNewSerialNumber(ClientId);
                txtSerialNumber.Value = SerialNumber;
                DepartmentId = objOrder.Costing.DepartmentID;
                BindDepartment(DepartmentId);
                lblCmt.Text = objOrder.Costing.CMT == 0 ? "" : objOrder.Costing.CMT.ToString();

                lblProductTime.Text = "";
                lblBihTgt.Text = "";
                lblBulkTgtDate.Text = "";
                LblInitialApprTgt.Text = "";
                lblAccountManager.Text = "";
                lblTotQty.Text = "";

                if ((objOrder.Style.SampleImageURL1 != "")&&(objOrder.Style.SampleImageURL1 != null))
                {
                    imgPrint.ImageUrl = "/Uploads/Style/thumb-" + objOrder.Style.SampleImageURL1;
                    imgPrint.CssClass = "RemoveHide";                    

                }
                if ((objOrder.Style.SampleImageURL2 != "") && (objOrder.Style.SampleImageURL2 != null))
                {
                    imgStyle.ImageUrl = "/Uploads/Style/thumb-" + objOrder.Style.SampleImageURL2;
                    imgStyle.CssClass = "RemoveHide";     
                }
                if ((objOrder.Style.SampleImageURL3 != "") && (objOrder.Style.SampleImageURL3 != null))
                {
                    imagePrint.ImageUrl = "/Uploads/Style/thumb-" + objOrder.Style.SampleImageURL3;
                    imagePrint.CssClass = "RemoveHide";     
                }

                gvContractDetail.DataSource = null;
                gvContractDetail.DataBind();
            }
            else
            {

            }
        }

        protected void gvContractDetail_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                TextBox txtLineItemNo = (TextBox)e.Row.FindControl("txtLineItemNo");
                TextBox txtContractNo = (TextBox)e.Row.FindControl("txtContractNo");

                HyperLink hlkPoUpload1 = (HyperLink)e.Row.FindControl("hlkPoUpload1");
                HyperLink hlkPoUpload2 = (HyperLink)e.Row.FindControl("hlkPoUpload2");
                HyperLink hlkPoUpload3 = (HyperLink)e.Row.FindControl("hlkPoUpload3");
                HyperLink hlkPoUpload4 = (HyperLink)e.Row.FindControl("hlkPoUpload4");

                TextBox txtQuanity = (TextBox)e.Row.FindControl("txtQuanity");
                DropDownList ddlMode = (DropDownList)e.Row.FindControl("ddlMode");
                TextBox txtBiplPrice = (TextBox)e.Row.FindControl("txtBiplPrice");
                TextBox txtikandiPrice = (TextBox)e.Row.FindControl("txtikandiPrice");
                TextBox txtPcdDate = (TextBox)e.Row.FindControl("txtPcdDate");
                TextBox txtExFactory = (TextBox)e.Row.FindControl("txtExFactory");

                txtLineItemNo.Text =  DataBinder.Eval(e.Row.DataItem, "LineItemNumber").ToString();
                txtContractNo.Text =  DataBinder.Eval(e.Row.DataItem, "ContractNumber").ToString();
                if ((DataBinder.Eval(e.Row.DataItem, "File1").ToString() != "") &&(DataBinder.Eval(e.Row.DataItem, "File1") != null))
                {
                    hlkPoUpload1.Visible = true;
                    string File1 = DataBinder.Eval(e.Row.DataItem, "File1").ToString();
                    hlkPoUpload1.NavigateUrl = "/Uploads/Order/ " + File1;
                }
                if ((DataBinder.Eval(e.Row.DataItem, "File2").ToString() != "") && (DataBinder.Eval(e.Row.DataItem, "File2") != null))
                {
                    hlkPoUpload2.Visible = true;
                    string File2 = DataBinder.Eval(e.Row.DataItem, "File2").ToString();
                    hlkPoUpload2.NavigateUrl = "/Uploads/Order/ " + File2;
                }
                if ((DataBinder.Eval(e.Row.DataItem, "File3").ToString() != "") && (DataBinder.Eval(e.Row.DataItem, "File3") != null))
                {
                    hlkPoUpload3.Visible = true;
                    string File3 = DataBinder.Eval(e.Row.DataItem, "File3").ToString();
                    hlkPoUpload3.NavigateUrl = "/Uploads/Order/ " + File3;
                }
                if ((DataBinder.Eval(e.Row.DataItem, "File4").ToString() != "") && (DataBinder.Eval(e.Row.DataItem, "File4") != null))
                {
                    hlkPoUpload4.Visible = true;
                    string File4 = DataBinder.Eval(e.Row.DataItem, "File4").ToString();
                    hlkPoUpload4.NavigateUrl = "/Uploads/Order/ " + File4;
                }

                txtQuanity.Text = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Quantity")) == -1 ? "" : DataBinder.Eval(e.Row.DataItem, "Quantity").ToString();
                
                ddlMode.DataSource = iKandi.BLL.CommonHelper.GetDeliveryModes(true);
                ddlMode.DataValueField = "Id";
                ddlMode.DataTextField = "Code";
                ddlMode.DataBind();

                ddlMode.SelectedItem.Value = DataBinder.Eval(e.Row.DataItem, "Mode").ToString();
                //txtBiplPrice.Text = 
                txtikandiPrice.Text = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "iKandiPrice")) == 0 ? "" : DataBinder.Eval(e.Row.DataItem, "iKandiPrice").ToString();

                txtPcdDate.Text = Convert.ToDateTime(DataBinder.Eval(e.Row.DataItem, "PCDDate")) == DateTime.MinValue ? "" : Convert.ToDateTime(DataBinder.Eval(e.Row.DataItem, "PCDDate")).ToString("dd MMM yy (ddd)");
                txtExFactory.Text = Convert.ToDateTime(DataBinder.Eval(e.Row.DataItem, "ExFactory")) == DateTime.MinValue ? "" : Convert.ToDateTime(DataBinder.Eval(e.Row.DataItem, "ExFactory")).ToString("dd MMM yy (ddd)");

            }
            if (e.Row.RowType == DataControlRowType.EmptyDataRow)
            {
                DropDownList ddlModeEmpty = (DropDownList)e.Row.FindControl("ddlModeEmpty");

                ddlModeEmpty.DataSource = iKandi.BLL.CommonHelper.GetDeliveryModes(true);
                ddlModeEmpty.DataValueField = "Id";
                ddlModeEmpty.DataTextField = "Code";
                ddlModeEmpty.DataBind();
            }
        }
    }
}