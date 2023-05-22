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
using iKandi.BLL;
using iKandi.Web.Components;
using iKandi.Common;
using System.Text;
using System.Collections.Generic;

namespace iKandi.Web
{
    public partial class LiabilityForm : BaseUserControl
    {
        #region Fields

        UserTask _OrderCacellationTask = null;
        UserTask _HoldTillOrderCacellationTask = null;
        UserTask _OrderCacellationTaskLiability = null;
        UserTask _HoldTillOrderCacellationTaskLiability = null;
        int _DesignationID = (ApplicationHelper.LoggedInUser.UserData.DesignationID == (int)Designation.iKandi_Sales_Manager ? (int)Designation.iKandi_Sales_SalesManager : ApplicationHelper.LoggedInUser.UserData.DesignationID);


        #endregion

        #region Properties

        public int OrderDetailID
        {
            get
            {
                if (null != Request.QueryString["orderDetailId"])
                {
                    int orderDetailId;

                    if (int.TryParse(Request.QueryString["orderDetailId"].ToString(), out orderDetailId))
                        return orderDetailId;
                }

                return -1;
            }
        }

        public int LiabilityID
        {
            get
            {
                if (null != Request.QueryString["liabilityID"])
                {
                    int liabilityID;

                    if (int.TryParse(Request.QueryString["liabilityID"].ToString(), out liabilityID))
                        return liabilityID;
                }

                return -1;
            }
        }

        public UserTask OrderCacellationTask
        {
            get
            {
                if (_OrderCacellationTask == null)
                    _OrderCacellationTask = this.UserTaskControllerInstance.GetUserTasksByOrderDetailID(this.OrderDetailID, UserTaskType.OrderCancellation, _DesignationID);

                return _OrderCacellationTask;
            }

        }

        public UserTask HoldTillOrderCacellationTask
        {
            get
            {
                if (_HoldTillOrderCacellationTask == null)
                    _HoldTillOrderCacellationTask = this.UserTaskControllerInstance.GetUserTasksByOrderDetailID(this.OrderDetailID, UserTaskType.HoldTillOrderCancellation, _DesignationID);

                return _HoldTillOrderCacellationTask;
            }

        }

        public UserTask OrderCacellationTaskLiability
        {
            get
            {
                if (_OrderCacellationTaskLiability == null)
                    _OrderCacellationTaskLiability = this.UserTaskControllerInstance.GetUserTasksByLiabilityID(this.LiabilityID, UserTaskType.OrderCancellation, _DesignationID);

                return _OrderCacellationTaskLiability;
            }

        }

        public UserTask HoldTillOrderCacellationTaskLiability
        {
            get
            {
                if (_HoldTillOrderCacellationTaskLiability == null)
                    _HoldTillOrderCacellationTaskLiability = this.UserTaskControllerInstance.GetUserTasksByLiabilityID(this.LiabilityID, UserTaskType.HoldTillOrderCancellation, _DesignationID);

                return _HoldTillOrderCacellationTaskLiability;
            }
        }

        #endregion

        #region Event Handlers

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindControls();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
                return;
            SaveLiability();
        }

        #endregion

        #region Private methods

        private void BindControls()
        {
            DropdownHelper.BindLiabilityPaymentStatus(ddlPayment as ListControl);
            ddlPayment.SelectedValue = "2";
            string currencySign = "£";
            
            if (OrderDetailID > 0 || LiabilityID > 0)
            {
                lblLbtyNo.Text = "LBTY " + this.LiabilityControllerInstance.GetNewLiabilityNumber().ToString();

                iKandi.Common.Liability liabilityBasic = LiabilityControllerInstance.GetLiability(OrderDetailID, LiabilityID);

                iKandi.Common.OrderDetail od = this.OrderControllerInstance.GetOrderDetailByOrderDetailId((this.OrderDetailID > 0 ? this.OrderDetailID : liabilityBasic.OrderDetail.OrderDetailID));
                if (this.OrderDetailID > 0)
                    Session["Id"] = this.OrderDetailID;
                else
                    Session["Id"] = liabilityBasic.OrderDetail.OrderDetailID;
               
                currencySign = od.ParentOrder.Costing.CurrencySign;
                hdnCurrencySign.Value = currencySign;

                lblOrderDate.Text = od.ParentOrder.OrderDate.ToString("dd MMM yy (ddd)");
                lblSerial.Text = od.ParentOrder.SerialNumber.ToString();
                lblDepartment.Text = od.ParentOrder.Style.cdept.Name;
                lblStyle.Text = od.ParentOrder.Style.StyleNumber.ToString();
                lblDescription.Text = od.ParentOrder.Description.ToString();
                txtDateCancelled.Text = DateTime.Now.ToString("dd MMM yy (ddd)");
                txtHoldTillDate.Text = DateTime.Now.AddMonths(3).ToString("dd MMM yy (ddd)");

                lblFab1Length.Text = Math.Round(Convert.ToDouble(liabilityBasic.Fabric1Length), 2).ToString();
                lblFab2Length.Text = Math.Round(Convert.ToDouble(liabilityBasic.Fabric2Length), 2).ToString();
                lblFab3Length.Text = Math.Round(Convert.ToDouble(liabilityBasic.Fabric3Length), 2).ToString();
                lblFab4Length.Text = Math.Round(Convert.ToDouble(liabilityBasic.Fabric4Length), 2).ToString();

                lblFabric1Avg.Text = Math.Round(Convert.ToDouble(od.Fabric1Average), 2).ToString();
                lblFabric2Avg.Text = Math.Round(Convert.ToDouble(od.Fabric2Average), 2).ToString();
                lblFabric3Avg.Text = Math.Round(Convert.ToDouble(od.Fabric3Average), 2).ToString();
                lblFabric4Avg.Text = Math.Round(Convert.ToDouble(od.Fabric4Average), 2).ToString();
                
                txtFabric1Price.Text = Math.Round(Convert.ToDecimal(od.Fabric1Price), 2).ToString();
                txtFabric2Price.Text = Math.Round(Convert.ToDecimal(od.Fabric2Price), 2).ToString();
                txtFabric3Price.Text = Math.Round(Convert.ToDecimal(od.Fabric3Price), 2).ToString();
                txtFabric4Price.Text = Math.Round(Convert.ToDecimal(od.Fabric4Price), 2).ToString();

                if (od.OrderDetailID == (this.OrderDetailID > 0 ? this.OrderDetailID : liabilityBasic.OrderDetail.OrderDetailID))
                {
                    txtQuantityCancelled.Text = od.Quantity.ToString();

                    if (string.IsNullOrEmpty(lblContracts.Text))
                        lblContracts.Text = od.ContractNumber.ToString();
                    else
                        lblContracts.Text = lblContracts.Text + "," + od.ContractNumber.ToString();

                    int prdNumber = 0;
                    if (int.TryParse(od.Fabric1Details, out prdNumber))
                    {
                        od.Fabric1Details = " " + od.Fabric1Details;
                    }
                    if (int.TryParse(od.Fabric2Details, out prdNumber))
                    {
                        od.Fabric2Details = " " + od.Fabric2Details;
                    }
                    if (int.TryParse(od.Fabric3Details, out prdNumber))
                    {
                        od.Fabric3Details = " " + od.Fabric3Details;
                    }
                    if (int.TryParse(od.Fabric4Details, out prdNumber))
                    {
                        od.Fabric4Details = " " + od.Fabric4Details;
                    }

                    lblfabric1.Text = od.Fabric1 + "" + od.Fabric1Details;
                    lblfabric2.Text = od.Fabric2 + "" + od.Fabric2Details;
                    lblfabric3.Text = od.Fabric3 + "" + od.Fabric3Details;
                    lblfabric4.Text = od.Fabric4 + "" + od.Fabric4Details;

                    if (String.IsNullOrEmpty((od.Fabric1).ToString()))
                        trFabric1.Visible = false;
                    else
                        trFabric1.Visible = true;

                    if (String.IsNullOrEmpty((od.Fabric2).ToString()))
                        trFabric2.Visible = false;
                    else
                        trFabric2.Visible = true;

                    if (String.IsNullOrEmpty((od.Fabric3).ToString()))
                        trFabric3.Visible = false;
                    else
                        trFabric3.Visible = true;

                    if (String.IsNullOrEmpty((od.Fabric4).ToString()))
                        trFabric4.Visible = false;
                    else
                        trFabric4.Visible = true;
                }

                ddlOwner.Items.Add(new ListItem(od.ParentOrder.Style.client.CompanyName, od.ParentOrder.Style.client.CompanyName));
                ddlOwner.Items.Add(new ListItem("BIPL", "BIPL"));
                ddlOwner.Items.Add(new ListItem("iKandi", "iKandi"));
                
                iKandi.Common.Liability liability = this.LiabilityControllerInstance.GetLiabilityData(OrderDetailID, LiabilityID);

                if (liability != null)
                {
                    if (LiabilityID == liability.Id)
                    {
                        if (!String.IsNullOrEmpty(liability.LiabilityNumber))
                            lblLbtyNo.Text = "LBTY " + liability.LiabilityNumber.ToString();
                        else
                            lblLbtyNo.Text = string.Empty;
                     // double sum = 0;
                      //  for (int i = 0; i <= liability.AccessoryLiability.Count - 1;i++ )
                      //  {
                      //      sum =sum + liability.AccessoryLiability[i].Amount;
                      //  }

                        int sum = this.LiabilityControllerInstance.GetAccessoryTotalBAL(LiabilityID);
                        lblAssSum.Text ="£ " + Convert.ToString(sum);
                        if (liability.DateCancelled == DateTime.MinValue)
                            {
                                txtDateCancelled.Text = string.Empty;
                            }
                            else
                            {
                                txtDateCancelled.Text = liability.DateCancelled.ToString("dd MMM yy (ddd)");
                            }

                        txtDateCancelled.Enabled = false;

                        if (liability.QuantityCancelled == 0)
                            txtQuantityCancelled.Text = od.Quantity.ToString();
                        else
                            txtQuantityCancelled.Text = liability.QuantityCancelled.ToString();

                        txtFabric1Price.Text = Math.Round(Convert.ToDecimal(liability.Fabric1Price), 2).ToString();
                        txtFabric2Price.Text = Math.Round(Convert.ToDecimal(liability.Fabric2Price), 2).ToString();
                        txtFabric3Price.Text = Math.Round(Convert.ToDecimal(liability.Fabric3Price), 2).ToString();
                        txtFabric4Price.Text = Math.Round(Convert.ToDecimal(liability.Fabric4Price), 2).ToString();

                       Avg1.Value = lblFabric1Avg.Text = Math.Round(Convert.ToDecimal(liability.Fabric1Average), 2).ToString();
                       Avg2.Value = lblFabric2Avg.Text = Math.Round(Convert.ToDecimal(liability.Fabric2Average), 2).ToString();
                       Avg3.Value = lblFabric3Avg.Text = Math.Round(Convert.ToDecimal(liability.Fabric3Average), 2).ToString();
                       Avg4.Value = lblFabric4Avg.Text = Math.Round(Convert.ToDecimal(liability.Fabric4Average), 2).ToString();
                   //    if (Avg1.Value == lblFabric1Avg.Text.Trim() && Avg2.Value == lblFabric2Avg.Text.Trim() && Avg3.Value == lblFabric3Avg.Text.Trim() && Avg4.Value == lblFabric4Avg.Text.Trim())
                        lblFab1Length.Text = Math.Round(Convert.ToDecimal(liability.Fabric1Quantity), 2).ToString();
                        lblFab2Length.Text = Math.Round(Convert.ToDecimal(liability.Fabric2Quantity), 2).ToString();
                        lblFab3Length.Text = Math.Round(Convert.ToDecimal(liability.Fabric3Quantity), 2).ToString();
                        lblFab4Length.Text = Math.Round(Convert.ToDecimal(liability.Fabric4Quantity), 2).ToString();
                        if (liability.InvoiceDate == DateTime.MinValue)
                            txtInvoiceDate.Text = string.Empty;
                        else
                            txtInvoiceDate.Text = liability.InvoiceDate.ToString("dd MMM yy (ddd)");
                        ddlOwner.SelectedValue = liability.Owner.ToString();
                        ddlPayment.SelectedValue = liability.PaymentStatus.ToString();
                        //Liability Waived-Off
                        txtMerchantRemarks.Text = liability.MerchantRemarks.ToString();
                        txtDocumentationRemarks.Text = liability.DocumentationRemarks.ToString();
                        txtCalcellationCost.Text = liability.CancellationCost.ToString();
                        repeaterAccessories.DataSource = liability.AccessoryLiability;
                        repeaterAccessories.DataBind();
                        if (liability.HoldTillDate == DateTime.MinValue)
                            txtHoldTillDate.Text = string.Empty;
                        else
                            txtHoldTillDate.Text = liability.HoldTillDate.ToString("dd MMM yy (ddd)");
                        txtInvoiceNumber.Text = liability.InvoiceNumber.ToString();
                        chkCustInvoice.Checked = Convert.ToBoolean(liability.RaiseCustomerInvoice);
                        chkSettle.Checked = Convert.ToBoolean(liability.AcceptanceToSettle);
                        chkAck.Checked = Convert.ToBoolean(liability.IkandiAcknowledge);
                        if (chkAck.Checked)
                        {
                            if (liability.AcknowledgementDate == DateTime.MinValue)
                                lblAckDate.Text = string.Empty;
                            else
                                lblAckDate.Text = liability.AcknowledgementDate.ToString("dd MMM yy (ddd)");
                        }
                        if (chkSettle.Checked)
                        {
                            if (liability.SettlementDate == DateTime.MinValue)
                                lblSettlementDate.Text = string.Empty;
                            else
                                lblSettlementDate.Text = liability.SettlementDate.ToString("dd MMM yy (ddd)");
                        }
                        if (chkCustInvoice.Checked)
                        {
                            if (liability.InvoiceRaisedDate == DateTime.MinValue)
                                lblRaiseInvoiceDate.Text = string.Empty;
                            else
                                lblRaiseInvoiceDate.Text = liability.InvoiceRaisedDate.ToString("dd MMM yy (ddd)");
                        }
                        hdnLiabilityDocs.Value = liability.LiabilityDocuments;
                        lblLibilityDocs.Text = liability.LiabilityDocuments;
                    }
                    else
                    {
                        repeaterAccessories.DataSource = liabilityBasic.AccessoryLiability;
                        repeaterAccessories.DataBind();
                    }
                }
                else
                {
                    repeaterAccessories.DataSource = liabilityBasic.AccessoryLiability;
                    repeaterAccessories.DataBind();
                }

                //if (!iKandi.Web.Components.PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.LIABILITY_DOCUMENTATION_REMARKS))
                //    txtDocumentationRemarks.CssClass = "do-not-allow-typing";
                //else
                //    txtDocumentationRemarks.CssClass = "";
               
                if (ddlOwner.SelectedValue != "BIPL" && (ApplicationHelper.LoggedInUser.UserData.DesignationID == (int)Designation.iKandi_Sales_Manager || ApplicationHelper.LoggedInUser.UserData.DesignationID == (int)Designation.iKandi_Sales_SalesManager))
                    chkAck.Enabled = (!chkAck.Checked) ? true : false;
                else
                    chkAck.Enabled = false;


                if (ddlOwner.SelectedValue != "BIPL" && (ApplicationHelper.LoggedInUser.UserData.DesignationID == (int)Designation.iKandi_Sales_Manager || ApplicationHelper.LoggedInUser.UserData.DesignationID == (int)Designation.iKandi_Sales_SalesManager) && (this.LiabilityID > 0 ? HoldTillOrderCacellationTaskLiability.ID > 0 : HoldTillOrderCacellationTask.ID > 0))
                    chkSettle.Enabled = (!chkSettle.Checked) ? true : false;
                else
                    chkSettle.Enabled = false;

                if (ddlOwner.SelectedValue != "iKandi" && ddlOwner.SelectedValue != "BIPL" && ApplicationHelper.LoggedInUser.UserData.DesignationID == (int)Designation.iKandi_FinanceLogistics_Accountant && liability.HoldTillDate != DateTime.MinValue)
                    chkCustInvoice.Enabled = (!chkCustInvoice.Checked) ? true : false;
                else
                    chkCustInvoice.Enabled = false;

                if (this.LiabilityID > 0 ? HoldTillOrderCacellationTaskLiability.ID > 0 : HoldTillOrderCacellationTask.ID > 0)
                {
                    txtInvoiceNumber.Enabled = true;
                    txtInvoiceDate.Enabled = true;
                }
                else
                {
                    txtInvoiceNumber.Enabled = false;
                    txtInvoiceDate.Enabled = false;
                }

                if (ddlOwner.SelectedValue == "BIPL")
                {
                    chkAck.Enabled = false;
                    chkSettle.Enabled = false;
                    chkCustInvoice.Enabled = false;
                }

                //if (!iKandi.Web.Components.PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.LIABILITY_BOUTIQUE_SETTLEMENT_SECTION))
                //{
                //    txtInvoiceDate.CssClass = "disable date_style do-not-allow-typing";
                //    txtHoldTillDate.CssClass = "disable date_style do-not-allow-typing";
                //    ddlOwner.CssClass = "disable-dropdown";
                //    ddlPayment.CssClass = "disable-dropdown";
                //    fileUploadLiabilityDocs.Enabled = false;
                //    txtInvoiceNumber.CssClass = "do-not-allow-typing";
                //}
                //else
                //{
                //    txtInvoiceDate.CssClass = "date-picker date_style";
                //    txtHoldTillDate.CssClass = "date-picker date_style";
                //    ddlOwner.CssClass = "";
                //    ddlPayment.CssClass = "";
                //    fileUploadLiabilityDocs.Enabled = true;
                //    txtInvoiceNumber.CssClass = "";
                //}

                //if (!iKandi.Web.Components.PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.LIABILITY_FORM_MERCHANT_REMARKS))
                //    txtMerchantRemarks.CssClass = "do-not-allow-typing";
                //else
                //    txtMerchantRemarks.CssClass = "";

                //if (iKandi.Web.Components.PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.LIABILITY_OVERALL_SECTION) && !chkAck.Checked)
                //{
                //    txtDateCancelled.CssClass = "date-picker date_style";
                //    txtQuantityCancelled.CssClass = "";
                //    txtFabric1Price.CssClass = "numeric-field-with-two-decimal-places";
                //    txtFabric2Price.CssClass = "numeric-field-with-two-decimal-places";
                //    txtFabric3Price.CssClass = "numeric-field-with-two-decimal-places";
                //    txtFabric4Price.CssClass = "numeric-field-with-two-decimal-places";
                //    lblFab1Length.CssClass = "numeric-field-with-two-decimal-places";
                //    lblFab2Length.CssClass = "numeric-field-with-two-decimal-places";
                //    lblFab3Length.CssClass = "numeric-field-with-two-decimal-places";
                //    lblFab4Length.CssClass = "numeric-field-with-two-decimal-places";


                //    foreach (RepeaterItem item in repeaterAccessories.Items)
                //    {
                //        ((TextBox)item.FindControl("txtAmount")).Enabled = true;
                //    }
                //}
                //else
                //{
                //    ddlOwner.CssClass = "disable-dropdown";
                //    txtDateCancelled.CssClass = "disable date_style do-not-allow-typing";
                //    txtQuantityCancelled.CssClass = "do-not-allow-typing";
                //    txtFabric1Price.CssClass = "do-not-allow-typing";
                //    txtFabric2Price.CssClass = "do-not-allow-typing";
                //    txtFabric3Price.CssClass = "do-not-allow-typing";
                //    txtFabric4Price.CssClass = "do-not-allow-typing";
                //    lblFab1Length.CssClass = "do-not-allow-typing";
                //    lblFab2Length.CssClass = "do-not-allow-typing";
                //    lblFab3Length.CssClass = "do-not-allow-typing";
                //    lblFab4Length.CssClass = "do-not-allow-typing";
                //    foreach (RepeaterItem item in repeaterAccessories.Items)
                //    {
                //        ((TextBox)item.FindControl("txtAmount")).Enabled = false;
                //    }
                //}

                if (!string.IsNullOrEmpty(txtHoldTillDate.Text) && (chkCustInvoice.Checked || chkSettle.Checked) && ddlOwner.SelectedValue != "BIPL")
                {
                    txtHoldTillDate.Enabled = false;
                }
                else
                    txtHoldTillDate.Enabled = true;
               
            }

        }

        private void SaveLiability()
        {

            iKandi.Common.Liability liability = new iKandi.Common.Liability();

            iKandi.Common.Liability liabilityOld = this.LiabilityControllerInstance.GetLiabilityData(OrderDetailID, LiabilityID);
            liability.OrderDetail = new iKandi.Common.OrderDetail();

            liability.OrderDetail.OrderDetailID = OrderDetailID;

            liability.Id = LiabilityID;

            if (!string.IsNullOrEmpty(txtDateCancelled.Text))
                liability.DateCancelled = DateHelper.ParseDate(txtDateCancelled.Text).Value;

            if (!string.IsNullOrEmpty(txtQuantityCancelled.Text))
                liability.QuantityCancelled = Convert.ToInt32(txtQuantityCancelled.Text);

            if (!string.IsNullOrEmpty(txtFabric1Price.Text))
                liability.Fabric1Price = Convert.ToDouble(txtFabric1Price.Text);

            if (!string.IsNullOrEmpty(txtFabric2Price.Text))
                liability.Fabric2Price = Convert.ToDouble(txtFabric2Price.Text);

            if (!string.IsNullOrEmpty(txtFabric3Price.Text))
                liability.Fabric3Price = Convert.ToDouble(txtFabric3Price.Text);

            if (!string.IsNullOrEmpty(txtFabric4Price.Text))
                liability.Fabric4Price = Convert.ToDouble(txtFabric4Price.Text);

            if (!string.IsNullOrEmpty(lblFab1Length.Text))
                liability.Fabric1Quantity = Convert.ToDouble(lblFab1Length.Text);

            if (!string.IsNullOrEmpty(lblFab2Length.Text))
                liability.Fabric2Quantity = Convert.ToDouble(lblFab2Length.Text);

            if (!string.IsNullOrEmpty(lblFab3Length.Text))
                liability.Fabric3Quantity = Convert.ToDouble(lblFab3Length.Text);

            if (!string.IsNullOrEmpty(lblFab4Length.Text))
                liability.Fabric4Quantity = Convert.ToDouble(lblFab4Length.Text);

            if (!string.IsNullOrEmpty(txtInvoiceDate.Text))
                liability.InvoiceDate = DateHelper.ParseDate(txtInvoiceDate.Text).Value;

            if (!string.IsNullOrEmpty(txtMerchantRemarks.Text))
                liability.MerchantRemarks = txtMerchantRemarks.Text;

            if (!string.IsNullOrEmpty(txtDocumentationRemarks.Text))
                liability.DocumentationRemarks = txtDocumentationRemarks.Text;

            if (!string.IsNullOrEmpty(txtCalcellationCost.Text))
                liability.CancellationCost = Convert.ToDouble(txtCalcellationCost.Text);

            liability.Owner = ddlOwner.SelectedValue;

            if (!string.IsNullOrEmpty(txtInvoiceNumber.Text))
                liability.InvoiceNumber = txtInvoiceNumber.Text;

            liability.PaymentStatus = Convert.ToInt32(ddlPayment.SelectedValue);

            if (!string.IsNullOrEmpty(txtHoldTillDate.Text))
                liability.HoldTillDate = DateHelper.ParseDate(txtHoldTillDate.Text).Value;

            liability.RaiseCustomerInvoice = Convert.ToInt32(chkCustInvoice.Checked);

            if (chkCustInvoice.Enabled && (!Convert.ToBoolean(liabilityOld.RaiseCustomerInvoice)) && Convert.ToBoolean(liability.RaiseCustomerInvoice))
                liability.InvoiceRaisedDate = DateTime.Now;
            else if ((!chkCustInvoice.Enabled) && Convert.ToBoolean(liabilityOld.RaiseCustomerInvoice))
                liability.InvoiceRaisedDate = liabilityOld.InvoiceRaisedDate;

            liability.AcceptanceToSettle = Convert.ToInt32(chkSettle.Checked);

            if (chkSettle.Enabled && (!Convert.ToBoolean(liabilityOld.AcceptanceToSettle)) && Convert.ToBoolean(liability.AcceptanceToSettle))
                liability.SettlementDate = DateTime.Now;
            else if ((!chkSettle.Enabled) && Convert.ToBoolean(liabilityOld.AcceptanceToSettle))
                liability.SettlementDate = liabilityOld.SettlementDate;

            liability.IkandiAcknowledge = Convert.ToInt32(chkAck.Checked);

            if (chkAck.Enabled && (!Convert.ToBoolean(liabilityOld.IkandiAcknowledge)) && Convert.ToBoolean(liability.IkandiAcknowledge))
                liability.AcknowledgementDate = DateTime.Now;
            else if ((!chkAck.Enabled) && Convert.ToBoolean(liabilityOld.IkandiAcknowledge))
                liability.AcknowledgementDate = liabilityOld.AcknowledgementDate;

            string fileName = hdnLiabilityDocs.Value;
            liability.LiabilityDocuments = GetUploadedFileNames(fileName, fileUploadLiabilityDocs.UniqueID);

            var lNo = lblLbtyNo.Text.Split(' ');
            if (!string.IsNullOrEmpty(lblLbtyNo.Text))
                liability.LiabilityNumber = lNo[1].ToString();

            liability.AccessoryLiability = new System.Collections.Generic.List<LiabilityAccessory>();
           // int ss = 0;
            foreach (RepeaterItem item in repeaterAccessories.Items)
            {
                LiabilityAccessory liabilityAccessory = new LiabilityAccessory();
                liabilityAccessory.AccessoryWorkingDetail = new AccessoryWorkingDetail();
                // if (OrderDetailID == (liabilityOld.OrderDetail != null ? liabilityOld.OrderDetail.OrderDetailID : 0))
                // {
                liabilityAccessory.Id = Convert.ToInt32(((HiddenField)item.FindControl("hiddenId")).Value);
                // }
                //  else
                //      liabilityAccessory.Id = -1;
                liabilityAccessory.AccessoryWorkingDetail.Id = Convert.ToInt32(((HiddenField)item.FindControl("hiddenAccessoryWorkingDetailID")).Value);

                liabilityAccessory.Amount = Convert.ToDouble(((TextBox)item.FindControl("txtAmount")).Text);
               
                liabilityAccessory.TotalQuantity = Convert.ToInt32(((Label)item.FindControl("lblTotalQuantity")).Text);
               // ss = ss + Convert.ToInt32(((Label)item.FindControl("lblTotalQuantity")).Text);
                
                liability.AccessoryLiability.Add(liabilityAccessory);
            }
           // ((Label)FindControl("lblTotalQuantity")).Text = Convert.ToString(ss);
        // lblAssSum.Text = Convert.ToString(ss);

            bool isSaved = false;

            if (LiabilityID > 0)
            {
                liability.Id = liabilityOld.Id;
                isSaved = this.LiabilityControllerInstance.UpdateLiability(liability);
            }
            else if (OrderDetailID > 0)
            {
                isSaved = this.LiabilityControllerInstance.InsertLiability(liability);
                if (isSaved && ddlOwner.SelectedValue != "BIPL")
                {
                    UserTask task = new UserTask();
                    task.AssignedToDesigntation = (int)Designation.iKandi_Sales_SalesManager;
                    task.CreatedBy = ApplicationHelper.LoggedInUser.UserData.UserID;
                    task.CreatedOn = DateTime.Now;
                    task.ETA = DateTime.Now;
                    task.OrderDetail = new iKandi.Common.OrderDetail();
                    task.OrderDetail.OrderDetailID = OrderDetailID;
                    task.IntField1 = liability.Id;
                    task.Type = UserTaskType.OrderCancellation;
                    this.UserTaskControllerInstance.InsertUserTask(task);
                }
                this.NotificationControllerInstance.SendCancelledOrderEmail(OrderDetailID, liability.QuantityCancelled, string.Empty);
            }

            if (isSaved)
            {
                if (chkCustInvoice.Checked && !string.IsNullOrEmpty(txtCalcellationCost.Text) && Convert.ToDouble(txtCalcellationCost.Text) > 0 && ApplicationHelper.LoggedInUser.UserData.Designation == Designation.iKandi_FinanceLogistics_Accountant)
                {
                    this.NotificationControllerInstance.SendRaiseCancelledOrderInvoice(this.OrderDetailID, this.LiabilityID);
                }
                if (this.OrderDetailID > 0)
                {
                    if (OrderCacellationTask.ID > 0)
                    {
                        if (ApplicationHelper.LoggedInUser.UserData.Designation == Designation.BIPL_Logistics_Manager)
                        {
                            if (!string.IsNullOrEmpty(txtHoldTillDate.Text))
                            {
                                OrderCacellationTask.ActionDate = DateTime.Now;
                                OrderCacellationTask.ActionedBy = ApplicationHelper.LoggedInUser.UserData.UserID;
                                this.UserTaskControllerInstance.UpdateUserTask(OrderCacellationTask);
                            }

                            if (ddlOwner.SelectedValue != "BIPL")
                            {
                                UserTask task = new UserTask();
                                task.AssignedToDesigntation = (int)Designation.iKandi_Sales_SalesManager;
                                task.CreatedBy = ApplicationHelper.LoggedInUser.UserData.UserID;
                                task.CreatedOn = DateTime.Now;
                                task.ETA = DateTime.Now;
                                task.OrderDetail = new iKandi.Common.OrderDetail();
                                task.OrderDetail.OrderDetailID = OrderDetailID;
                                task.Type = UserTaskType.OrderCancellation;
                                this.UserTaskControllerInstance.InsertUserTask(task);
                            }
                        }
                        if (ApplicationHelper.LoggedInUser.UserData.Designation == Designation.iKandi_Sales_Manager || ApplicationHelper.LoggedInUser.UserData.Designation == Designation.iKandi_Sales_SalesManager)
                        {
                            if (chkAck.Checked)
                            {
                                OrderCacellationTask.ActionDate = DateTime.Now;
                                OrderCacellationTask.ActionedBy = ApplicationHelper.LoggedInUser.UserData.UserID;
                                this.UserTaskControllerInstance.UpdateUserTask(OrderCacellationTask);
                            }
                        }
                    }

                    if (!string.IsNullOrEmpty(txtHoldTillDate.Text))
                    {
                        if (HoldTillOrderCacellationTask.ID > 0)
                        {
                            if (!String.IsNullOrEmpty(txtInvoiceNumber.Text) && ApplicationHelper.LoggedInUser.UserData.Designation == Designation.BIPL_Logistics_Manager)
                            {
                                HoldTillOrderCacellationTask.ActionDate = DateTime.Now;
                                HoldTillOrderCacellationTask.ActionedBy = ApplicationHelper.LoggedInUser.UserData.UserID;
                                this.UserTaskControllerInstance.UpdateUserTask(HoldTillOrderCacellationTask);
                            }

                            if (ApplicationHelper.LoggedInUser.UserData.Designation == Designation.BIPL_Logistics_Manager && String.IsNullOrEmpty(txtInvoiceNumber.Text) && DateHelper.ParseDate(txtHoldTillDate.Text).Value != HoldTillOrderCacellationTask.ETA)
                            {
                                HoldTillOrderCacellationTask.ETA = DateHelper.ParseDate(txtHoldTillDate.Text).Value;
                                this.UserTaskControllerInstance.UpdateUserTaskETA(HoldTillOrderCacellationTask);
                            }

                            if (chkSettle.Checked && (ApplicationHelper.LoggedInUser.UserData.Designation == Designation.iKandi_Sales_SalesManager || ApplicationHelper.LoggedInUser.UserData.Designation == Designation.iKandi_Sales_Manager))
                            {
                                HoldTillOrderCacellationTask.ActionDate = DateTime.Now;
                                HoldTillOrderCacellationTask.ActionedBy = ApplicationHelper.LoggedInUser.UserData.UserID;
                                this.UserTaskControllerInstance.UpdateUserTask(HoldTillOrderCacellationTask);
                            }

                            if (ddlOwner.SelectedValue != "iKandi" && ddlOwner.SelectedValue != "BIPL" && chkCustInvoice.Checked && ApplicationHelper.LoggedInUser.UserData.Designation == Designation.iKandi_FinanceLogistics_Accountant)
                            {
                                HoldTillOrderCacellationTask.ActionDate = DateTime.Now;
                                HoldTillOrderCacellationTask.ActionedBy = ApplicationHelper.LoggedInUser.UserData.UserID;
                                this.UserTaskControllerInstance.UpdateUserTask(HoldTillOrderCacellationTask);
                            }


                        }
                        else
                        {
                            UserTask task;

                            if (ApplicationHelper.LoggedInUser.UserData.DesignationID == (int)Designation.iKandi_Sales_Manager || ApplicationHelper.LoggedInUser.UserData.DesignationID == (int)Designation.iKandi_Sales_SalesManager)
                            {
                                if (liabilityOld.IkandiAcknowledge == 0 && chkAck.Checked && liability.AcknowledgementDate.Date == DateTime.Now.Date)
                                {
                                    task = new UserTask();
                                    task.AssignedToDesigntation = (int)Designation.BIPL_Logistics_Manager;
                                    task.CreatedBy = ApplicationHelper.LoggedInUser.UserData.UserID;
                                    task.CreatedOn = DateTime.Now;
                                    task.ETA = DateHelper.ParseDate(txtHoldTillDate.Text).Value;
                                    task.OrderDetail = new iKandi.Common.OrderDetail();
                                    task.OrderDetail.OrderDetailID = OrderDetailID;
                                    task.Type = UserTaskType.HoldTillOrderCancellation;
                                    this.UserTaskControllerInstance.InsertUserTask(task);

                                    if (ddlOwner.SelectedValue != "BIPL" && ddlOwner.SelectedValue != "iKandi" && !chkSettle.Checked)
                                    {
                                        task = new UserTask();
                                        task.AssignedToDesigntation = (int)Designation.iKandi_FinanceLogistics_Accountant;
                                        task.CreatedBy = ApplicationHelper.LoggedInUser.UserData.UserID;
                                        task.CreatedOn = DateTime.Now;
                                        task.ETA = DateHelper.ParseDate(txtHoldTillDate.Text).Value;
                                        task.OrderDetail = new iKandi.Common.OrderDetail();
                                        task.OrderDetail.OrderDetailID = OrderDetailID;
                                        task.Type = UserTaskType.HoldTillOrderCancellation;
                                        this.UserTaskControllerInstance.InsertUserTask(task);
                                    }

                                    if (ddlOwner.SelectedValue != "BIPL" && !chkSettle.Checked)
                                    {
                                        task = new UserTask();
                                        task.AssignedToDesigntation = (int)Designation.iKandi_Sales_SalesManager;
                                        task.CreatedBy = ApplicationHelper.LoggedInUser.UserData.UserID;
                                        task.CreatedOn = DateTime.Now;
                                        task.ETA = DateHelper.ParseDate(txtHoldTillDate.Text).Value;
                                        task.OrderDetail = new iKandi.Common.OrderDetail();
                                        task.OrderDetail.OrderDetailID = OrderDetailID;
                                        task.Type = UserTaskType.HoldTillOrderCancellation;
                                        this.UserTaskControllerInstance.InsertUserTask(task);
                                    }
                                }
                            }
                        }
                    }
                }
                else if (this.LiabilityID > 0)
                {
                    if (OrderCacellationTaskLiability.ID > 0)
                    {
                        if (ApplicationHelper.LoggedInUser.UserData.Designation == Designation.BIPL_Logistics_Manager)
                        {
                            if (!string.IsNullOrEmpty(txtHoldTillDate.Text))
                            {
                                OrderCacellationTaskLiability.ActionDate = DateTime.Now;
                                OrderCacellationTaskLiability.ActionedBy = ApplicationHelper.LoggedInUser.UserData.UserID;
                                this.UserTaskControllerInstance.UpdateUserTask(OrderCacellationTaskLiability);
                            }

                            if (ddlOwner.SelectedValue != "BIPL")
                            {
                                UserTask task = new UserTask();
                                task.AssignedToDesigntation = (int)Designation.iKandi_Sales_SalesManager;
                                task.CreatedBy = ApplicationHelper.LoggedInUser.UserData.UserID;
                                task.CreatedOn = DateTime.Now;
                                task.ETA = DateTime.Now;
                                task.OrderDetail = new iKandi.Common.OrderDetail();
                                task.IntField1 = LiabilityID;
                                task.Type = UserTaskType.OrderCancellation;
                                this.UserTaskControllerInstance.InsertUserTask(task);
                            }
                        }
                        if (ApplicationHelper.LoggedInUser.UserData.Designation == Designation.iKandi_Sales_Manager || ApplicationHelper.LoggedInUser.UserData.Designation == Designation.iKandi_Sales_SalesManager)
                        {
                            if (chkAck.Checked)
                            {
                                OrderCacellationTaskLiability.ActionDate = DateTime.Now;
                                OrderCacellationTaskLiability.ActionedBy = ApplicationHelper.LoggedInUser.UserData.UserID;
                                this.UserTaskControllerInstance.UpdateUserTask(OrderCacellationTaskLiability);
                            }
                        }
                    }

                    if (!string.IsNullOrEmpty(txtHoldTillDate.Text))
                    {
                        if (HoldTillOrderCacellationTaskLiability.ID > 0)
                        {
                            if (!String.IsNullOrEmpty(txtInvoiceNumber.Text) && ApplicationHelper.LoggedInUser.UserData.Designation == Designation.BIPL_Logistics_Manager)
                            {
                                HoldTillOrderCacellationTaskLiability.ActionDate = DateTime.Now;
                                HoldTillOrderCacellationTaskLiability.ActionedBy = ApplicationHelper.LoggedInUser.UserData.UserID;
                                this.UserTaskControllerInstance.UpdateUserTask(HoldTillOrderCacellationTaskLiability);
                            }

                            if (ApplicationHelper.LoggedInUser.UserData.Designation == Designation.BIPL_Logistics_Manager && String.IsNullOrEmpty(txtInvoiceNumber.Text) && DateHelper.ParseDate(txtHoldTillDate.Text).Value != HoldTillOrderCacellationTask.ETA)
                            {
                                HoldTillOrderCacellationTaskLiability.ETA = DateHelper.ParseDate(txtHoldTillDate.Text).Value;
                                this.UserTaskControllerInstance.UpdateUserTaskETA(HoldTillOrderCacellationTaskLiability);
                            }

                            if (chkSettle.Checked && (ApplicationHelper.LoggedInUser.UserData.Designation == Designation.iKandi_Sales_SalesManager || ApplicationHelper.LoggedInUser.UserData.Designation == Designation.iKandi_Sales_Manager))
                            {
                                HoldTillOrderCacellationTaskLiability.ActionDate = DateTime.Now;
                                HoldTillOrderCacellationTaskLiability.ActionedBy = ApplicationHelper.LoggedInUser.UserData.UserID;
                                this.UserTaskControllerInstance.UpdateUserTask(HoldTillOrderCacellationTaskLiability);
                            }

                            if (ddlOwner.SelectedValue != "iKandi" && ddlOwner.SelectedValue != "BIPL" && chkCustInvoice.Checked && ApplicationHelper.LoggedInUser.UserData.Designation == Designation.iKandi_FinanceLogistics_Accountant)
                            {
                                HoldTillOrderCacellationTaskLiability.ActionDate = DateTime.Now;
                                HoldTillOrderCacellationTaskLiability.ActionedBy = ApplicationHelper.LoggedInUser.UserData.UserID;
                                this.UserTaskControllerInstance.UpdateUserTask(HoldTillOrderCacellationTaskLiability);
                            }


                        }
                        else
                        {
                            UserTask task;

                            if (ApplicationHelper.LoggedInUser.UserData.DesignationID == (int)Designation.iKandi_Sales_Manager || ApplicationHelper.LoggedInUser.UserData.DesignationID == (int)Designation.iKandi_Sales_SalesManager)
                            {
                                if (liabilityOld.IkandiAcknowledge == 0 && chkAck.Checked && liability.AcknowledgementDate.Date == DateTime.Now.Date)
                                {
                                    task = new UserTask();
                                    task.AssignedToDesigntation = (int)Designation.BIPL_Logistics_Manager;
                                    task.CreatedBy = ApplicationHelper.LoggedInUser.UserData.UserID;
                                    task.CreatedOn = DateTime.Now;
                                    task.ETA = DateHelper.ParseDate(txtHoldTillDate.Text).Value;
                                    task.IntField1 = LiabilityID;
                                    task.Type = UserTaskType.HoldTillOrderCancellation;
                                    this.UserTaskControllerInstance.InsertUserTask(task);

                                    if (ddlOwner.SelectedValue != "BIPL" && ddlOwner.SelectedValue != "iKandi" && !chkSettle.Checked)
                                    {
                                        task = new UserTask();
                                        task.AssignedToDesigntation = (int)Designation.iKandi_FinanceLogistics_Accountant;
                                        task.CreatedBy = ApplicationHelper.LoggedInUser.UserData.UserID;
                                        task.CreatedOn = DateTime.Now;
                                        task.ETA = DateHelper.ParseDate(txtHoldTillDate.Text).Value;
                                        task.IntField1 = LiabilityID;
                                        task.Type = UserTaskType.HoldTillOrderCancellation;
                                        this.UserTaskControllerInstance.InsertUserTask(task);
                                    }

                                    if (ddlOwner.SelectedValue != "BIPL" && !chkSettle.Checked)
                                    {
                                        task = new UserTask();
                                        task.AssignedToDesigntation = (int)Designation.iKandi_Sales_SalesManager;
                                        task.CreatedBy = ApplicationHelper.LoggedInUser.UserData.UserID;
                                        task.CreatedOn = DateTime.Now;
                                        task.ETA = DateHelper.ParseDate(txtHoldTillDate.Text).Value;
                                        task.IntField1 = LiabilityID;
                                        task.Type = UserTaskType.HoldTillOrderCancellation;
                                        this.UserTaskControllerInstance.InsertUserTask(task);
                                    }
                                }
                            }
                        }
                    }
                }
            }

            pnlForm.Visible = false;
            pnlMessage.Visible = true;

            if (Avg1.Value != lblFabric1Avg.Text.Trim() || Avg2.Value != lblFabric2Avg.Text.Trim() || Avg3.Value != lblFabric3Avg.Text.Trim() || Avg4.Value != lblFabric4Avg.Text.Trim())
            {
                this.LiabilityControllerInstance.UpdateAvgLiabilityBAL(lblFabric1Avg.Text.Trim(), lblFabric2Avg.Text.Trim(), lblFabric3Avg.Text.Trim(), lblFabric4Avg.Text.Trim(), Convert.ToInt32(Session["Id"]));
            }


        }

        private string GetUploadedFileNames(string originalFiles, string fileUploadKey)
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

        #endregion
    }
}