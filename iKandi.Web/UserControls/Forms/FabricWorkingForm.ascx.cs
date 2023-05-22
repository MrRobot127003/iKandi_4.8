#region Assembly Reference

using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using iKandi.Common;
using iKandi.Web.Components;
using System.Web.UI;
using iKandi.BLL;
using System.Drawing;

#endregion

namespace iKandi.Web
{
    public partial class FabricForm : BaseUserControl
    {
        #region Properties

        private int OrderId
        {
            get
            {
                if (null != Request.QueryString["orderid"])
                {
                    int orderid;

                    if (int.TryParse(Request.QueryString["orderid"], out orderid))
                        return orderid;
                }

                return -1;
            }
        }
        private string OrderDetailID
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.QueryString["OrderDetailID"]))
                {
                    return Request.QueryString["OrderDetailID"];
                }
                return "-1";
            }
        }
        private int IsUcknowledge
        {
            get
            {
                if (null != Request.QueryString["IsUcknowledge"])
                {
                    int isUcknowledg;

                    if (int.TryParse(Request.QueryString["IsUcknowledge"], out isUcknowledg))
                        return isUcknowledg;
                }

                return -1;
            }
        }

        #endregion

        #region Event Handlers
        //FabricWorking fabricWorking = null;
        FabricWorking fabricWorking = new FabricWorking();
        

        //abhishek on-- 1/2/2016
        OrderController objOrderController = new OrderController();
        //end
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //iKandi.Web.Components.PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.FABRIC_WORKING_FORM_ALL_REMARKS);
                BindControls();
                GetCurrentStatus();
                txtTotalFabric1.Attributes.Add("readonly", "readonly");
                txtTotalFabric2.Attributes.Add("readonly", "readonly");
                txtTotalFabric3.Attributes.Add("readonly", "readonly");
                txtTotalFabric4.Attributes.Add("readonly", "readonly");
                if (IsUcknowledge == 1)
                {
                    chkUcknowledgment.Enabled = true;
                }

            }
        }
        private void GetCurrentStatus()
        {
            PermissionController objpermissionController = new PermissionController();
            string CurentStatus = objpermissionController.GetStatusByOrderId(OrderId);

            if (CurentStatus != "")
            {

                if (objOrderController.FindStatus_Modes_Sequence(CurentStatus, 1) == objOrderController.FindStatus_Modes_Sequence("SEALED TO CUT", 1))
                {
                    txtFabric1UsableWidth.Attributes.Remove("readonly");
                    txtFabric2UsableWidth.Attributes.Remove("readonly");
                    txtFabric3UsableWidth.Attributes.Remove("readonly");
                    txtFabric4UsableWidth.Attributes.Remove("readonly");
                }
                else
                {
                    txtFabric1UsableWidth.Attributes.Add("readonly", "readonly");
                    txtFabric2UsableWidth.Attributes.Add("readonly", "readonly");
                    txtFabric3UsableWidth.Attributes.Add("readonly", "readonly");
                    txtFabric4UsableWidth.Attributes.Add("readonly", "readonly");
                }

            }

            int IsOrderConfirm = objpermissionController.IsOrderConfirm(OrderId);
            if (IsOrderConfirm != 1)
            {
                btnSubmit.Visible = false;
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
                return;
            SaveFabricWorkingData();
        }

        protected void btnRefresh_click(object sender, EventArgs e)
        {
            BindControls();
            ShowAlert("Remarks have been submitted successfully");

        }

        #endregion
        #region Private Methods

        private void BindControls()
        {
            lnkOrderLimitation.NavigateUrl = ResolveUrl("~/internal/sales/OrderLimitations.aspx?orderid=" + OrderId);

            lblCreationDate.Text = DateTime.Now.ToString("dd MMM yy (ddd)");

            if (OrderId != -1)
            {
                int a = iKandi.Web.Components.PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.MANAGE_ORDERS_FILE_FABRIC_FABRIC_REMARKS) ? 1 : 0;
                Common.Order order = OrderControllerInstance.GetOrder(OrderId);
                lblSerial.Text = order.SerialNumber;
                lblOrderDate.Text = order.OrderDate == DateTime.MinValue
                                        ? ""
                                        : order.OrderDate.ToString("dd MMM yy (ddd) ");
                lblStyleNumber.Text = order.Style.StyleNumber;
                hiddenStyleID.Value = order.Style.StyleID.ToString();
                imgFront.ImageUrl = ResolveUrl("~/uploads/style/thumb-" + order.Style.SampleImageURL1);
                lblBuyer.Text = order.Style.client.CompanyName;
                lblDescription.Text = order.Description;
                lblTotalQuantity.Text = order.TotalQuantity.ToString();

                if (order.OrderBreakdown != null && order.OrderBreakdown.Count > 0)
                {
                    lblBulkETA.Text = order.OrderBreakdown[0].BulkTarget == DateTime.MinValue
                                          ? ""
                                          : order.OrderBreakdown[0].BulkTarget.ToString("dd MMM yy (ddd) ");

                    lblBulkApproval.Text = order.OrderBreakdown[0].BulkApprovalTarget == DateTime.MinValue
                                               ? ""
                                               : order.OrderBreakdown[0].BulkApprovalTarget.ToString("dd MMM yy (ddd) ");

                    lblLabDipApproval.Text = order.OrderBreakdown[0].LabDipTarget == DateTime.MinValue
                                                 ? ""
                                                 : order.OrderBreakdown[0].LabDipTarget.ToString("dd MMM yy (ddd) ");
                }

                //imgFront.ImageUrl = ResolveUrl("~/Uploads/Style/thumb-" + order.Style.SampleImageURL1);

                txtFabric1InitialWidth.DataBind();
                txtFabric1UsableWidth.DataBind();
                txtFabric2InitialWidth.DataBind();
                txtFabric2UsableWidth.DataBind();
                txtFabric3InitialWidth.DataBind();
                txtFabric3UsableWidth.DataBind();
                txtFabric4InitialWidth.DataBind();
                txtFabric4UsableWidth.DataBind();
                txtFabricRemarks.DataBind();
                ddlAvgUnit1.DataBind();
                ddlAvgUnit2.DataBind();
                ddlAvgUnit3.DataBind();
                ddlAvgUnit4.DataBind();
                txtRemarksFabric1.DataBind();
                txtCuttingWastageFabric1.DataBind();
                txtRemarksFabric2.DataBind();
                txtCuttingWastageFabric2.DataBind();
                txtRemarksFabric3.DataBind();
                txtCuttingWastageFabric3.DataBind();
                txtRemarksFabric4.DataBind();
                txtCuttingWastageFabric4.DataBind();
                txtShrinkageFabric1.DataBind();
                txtShrinkageFabric2.DataBind();
                txtShrinkageFabric3.DataBind();
                txtShrinkageFabric4.DataBind();
                txtFinalFabricOrderPlacedFabric1.DataBind();
                txtFinalFabricOrderPlacedFabric2.DataBind();
                txtFinalFabricOrderPlacedFabric3.DataBind();
                txtFinalFabricOrderPlacedFabric4.DataBind();
                //chkboxAccountMgr.DataBind();
                //chkboxFabricManager.DataBind();
                txtRemarks.DataBind();

                /* --//abhishek on-- 1/2/2016
                if ((ApplicationHelper.LoggedInUser.UserData.Designation == Designation.BIPL_Fabrics_Manager)
                    || (ApplicationHelper.LoggedInUser.UserData.Designation == Designation.BIPL_Fabrics_AssistantEntry)
                    || (ApplicationHelper.LoggedInUser.UserData.Designation == Designation.BIPL_Fabrics_ManagerStore)
                    ||
                    (ApplicationHelper.LoggedInUser.UserData.Designation == Designation.BIPL_Fabrics_ManagerProcessing)
                    || (ApplicationHelper.LoggedInUser.UserData.Designation == Designation.BIPL_Fabrics_Assistant))
                {
                    chkboxFabricManager.Enabled = true;
                    chkboxAccountMgr.Enabled = false;
                    chkboxAvgChecked.Enabled = false;
                    txtRemarksFabric1.Enabled = true;
                    txtCuttingWastageFabric1.Enabled = true;
                    txtRemarksFabric2.Enabled = true;
                    txtCuttingWastageFabric2.Enabled = true;
                    txtRemarksFabric3.Enabled = true;
                    txtCuttingWastageFabric3.Enabled = true;
                    txtRemarksFabric4.Enabled = true;
                    txtCuttingWastageFabric4.Enabled = true;
                    txtShrinkageFabric1.Enabled = true;
                    txtShrinkageFabric2.Enabled = true;
                    txtShrinkageFabric3.Enabled = true;
                    txtShrinkageFabric4.Enabled = true;
                    txtFinalFabricOrderPlacedFabric1.Enabled = true;
                    txtFinalFabricOrderPlacedFabric2.Enabled = true;
                    txtFinalFabricOrderPlacedFabric3.Enabled = true;
                    txtFinalFabricOrderPlacedFabric4.Enabled = true;
                }
                else if ((ApplicationHelper.LoggedInUser.UserData.Designation ==
                          Designation.BIPL_Merchandising_AccountManager) ||
                         (ApplicationHelper.LoggedInUser.UserData.Designation ==
                          Designation.BIPL_Merchandising_FitMerchant))
                {
                    chkboxFabricManager.Enabled = false;
                    chkboxAccountMgr.Enabled = true;
                    chkboxAvgChecked.Enabled = true;
                    txtRemarksFabric1.Attributes.Add("class", "do-no-allow-typing");
                    txtCuttingWastageFabric1.Attributes.Add("class", "do-no-allow-typing");
                    txtRemarksFabric2.Attributes.Add("class", "do-no-allow-typing");
                    txtCuttingWastageFabric2.Attributes.Add("class", "do-no-allow-typing");
                    txtRemarksFabric3.Attributes.Add("class", "do-no-allow-typing");
                    txtCuttingWastageFabric3.Attributes.Add("class", "do-no-allow-typing");
                    txtRemarksFabric4.Attributes.Add("class", "do-no-allow-typing");
                    txtCuttingWastageFabric4.Attributes.Add("class", "do-no-allow-typing");
                    txtShrinkageFabric1.Attributes.Add("class", "do-no-allow-typing");
                    txtShrinkageFabric2.Attributes.Add("class", "do-no-allow-typing");
                    txtShrinkageFabric3.Attributes.Add("class", "do-no-allow-typing");
                    txtShrinkageFabric4.Attributes.Add("class", "do-no-allow-typing");
                    txtFinalFabricOrderPlacedFabric1.Attributes.Add("class", "do-no-allow-typing");
                    txtFinalFabricOrderPlacedFabric2.Attributes.Add("class", "do-no-allow-typing");
                    txtFinalFabricOrderPlacedFabric3.Attributes.Add("class", "do-no-allow-typing");
                    txtFinalFabricOrderPlacedFabric4.Attributes.Add("class", "do-no-allow-typing");
                }
                else
                {
                    chkboxFabricManager.Enabled = false;
                    chkboxAccountMgr.Enabled = false;
                    chkboxAvgChecked.Enabled = false;
                    txtRemarksFabric1.Attributes.Add("class", "do-no-allow-typing");
                    txtCuttingWastageFabric1.Attributes.Add("class", "do-no-allow-typing");
                    txtRemarksFabric2.Attributes.Add("class", "do-no-allow-typing");
                    txtCuttingWastageFabric2.Attributes.Add("class", "do-no-allow-typing");
                    txtRemarksFabric3.Attributes.Add("class", "do-no-allow-typing");
                    txtCuttingWastageFabric3.Attributes.Add("class", "do-no-allow-typing");
                    txtRemarksFabric4.Attributes.Add("class", "do-no-allow-typing");
                    txtCuttingWastageFabric4.Attributes.Add("class", "do-no-allow-typing");
                    txtShrinkageFabric1.Attributes.Add("class", "do-no-allow-typing");
                    txtShrinkageFabric2.Attributes.Add("class", "do-no-allow-typing");
                    txtShrinkageFabric3.Attributes.Add("class", "do-no-allow-typing");
                    txtShrinkageFabric4.Attributes.Add("class", "do-no-allow-typing");
                    txtFinalFabricOrderPlacedFabric1.Attributes.Add("class", "do-no-allow-typing");
                    txtFinalFabricOrderPlacedFabric2.Attributes.Add("class", "do-no-allow-typing");
                    txtFinalFabricOrderPlacedFabric3.Attributes.Add("class", "do-no-allow-typing");
                    txtFinalFabricOrderPlacedFabric4.Attributes.Add("class", "do-no-allow-typing");
                }

                if (ApplicationHelper.LoggedInUser.UserData.Designation == Designation.BIPL_Merchandising_FitMerchant)
                {
                    chkboxFabricManager.Enabled = false;
                    chkboxAccountMgr.Enabled = false;
                    chkboxAvgChecked.Enabled = false;
                }
               --//end by abhishek 1/2/2016    */
                PopulateFabricData();

                //if (order.StatusModeSequence >= 8)
                //    btnSubmit.Visible = true;
                //PopulatedPrintColorDetail()

            }
        }


        private void PopulateFabricData()
        {
            //fabricWorking = FabricWorkingControllerInstance.GetFabricWorking(OrderId, OrderDetailID);
            //added by abhishek on 21/12/2015
            //fabricWorking = FabricWorkingControllerInstance.GetFabricWorking(OrderId);
            //end by abhishek on 21/12/2015
            if (fabricWorking.Fabric1File != "")
            {
                viewolay1.NavigateUrl = "~/Uploads/Photo/" + fabricWorking.Fabric1File;
                viewolay1.Attributes.Add("style", "display:block;");
            }

            if (fabricWorking.Fabric2File != "")
            {
                viewolay2.NavigateUrl = "~/Uploads/Photo/" + fabricWorking.Fabric2File;
                viewolay2.Attributes.Add("style", "display:block;");
            }

            if (fabricWorking.Fabric3File != "")
            {
                viewolay3.NavigateUrl = "~/Uploads/Photo/" + fabricWorking.Fabric3File;
                viewolay3.Attributes.Add("style", "display:block;");
            }

            if (fabricWorking.Fabric4File != "")
            {
                viewolay4.NavigateUrl = "~/Uploads/Photo/" + fabricWorking.Fabric4File;
                viewolay4.Attributes.Add("style", "display:block;");
            }

            lblCreationDate.Text = fabricWorking.CreationDate.ToString("dd MMM yy (ddd)");
            txtCuttingWastageFabric1.Text = Convert.ToString(fabricWorking.Fabric1Wastage);
            txtShrinkageFabric1.Text = Convert.ToString(fabricWorking.Fabric1Shrinkage);
            txtTotalRequirementGreigeFabric1.Text = Convert.ToString(Math.Round(fabricWorking.Fabric1Greige));
            txtFinalFabricOrderPlacedFabric1.Text = Convert.ToString(fabricWorking.Fabric1FinalOrder);

            txtCuttingWastageFabric2.Text = Convert.ToString(fabricWorking.Fabric2Wastage);
            txtShrinkageFabric2.Text = Convert.ToString(fabricWorking.Fabric2Shrinkage);
            txtTotalRequirementGreigeFabric2.Text = Convert.ToString(Math.Round(fabricWorking.Fabric2Greige));
            txtFinalFabricOrderPlacedFabric2.Text = Convert.ToString(fabricWorking.Fabric2FinalOrder);
            txtCuttingWastageFabric3.Text = Convert.ToString(fabricWorking.Fabric3Wastage);
            txtShrinkageFabric3.Text = Convert.ToString(fabricWorking.Fabric3Shrinkage);
            txtTotalRequirementGreigeFabric3.Text = Convert.ToString(Math.Round(fabricWorking.Fabric3Greige));
            txtFinalFabricOrderPlacedFabric3.Text = Convert.ToString(fabricWorking.Fabric3FinalOrder);
            txtCuttingWastageFabric4.Text = Convert.ToString(fabricWorking.Fabric4Wastage);
            txtShrinkageFabric4.Text = Convert.ToString(fabricWorking.Fabric4Shrinkage);
            txtTotalRequirementGreigeFabric4.Text = Convert.ToString(Math.Round(fabricWorking.Fabric4Greige));
            txtFinalFabricOrderPlacedFabric4.Text = Convert.ToString(fabricWorking.Fabric4FinalOrder);
            txtRemarksFabric1.Text = fabricWorking.Fabric1Remarks;
            txtRemarksFabric2.Text = fabricWorking.Fabric2Remarks;
            txtRemarksFabric3.Text = fabricWorking.Fabric3Remarks;
            txtRemarksFabric4.Text = fabricWorking.Fabric4Remarks;
            txtFabricRemarks.Text = fabricWorking.FabricRemarks;
            //txtTotalGreigeFabric.Text = Convert.ToString(fabricWorking.TotalGreigeFabric);
            txtFabric1InitialWidth.Text = Convert.ToString(fabricWorking.Fabric1InitialWidth);
            txtFabric1UsableWidth.Text = Convert.ToString(fabricWorking.Fabric1UsableWidth);
            txtFabric2InitialWidth.Text = Convert.ToString(fabricWorking.Fabric2InitialWidth);
            txtFabric2UsableWidth.Text = Convert.ToString(fabricWorking.Fabric2UsableWidth);
            txtFabric3InitialWidth.Text = Convert.ToString(fabricWorking.Fabric3InitialWidth);
            txtFabric3UsableWidth.Text = Convert.ToString(fabricWorking.Fabric3UsableWidth);
            txtFabric4InitialWidth.Text = Convert.ToString(fabricWorking.Fabric4InitialWidth);
            txtFabric4UsableWidth.Text = Convert.ToString(fabricWorking.Fabric4UsableWidth);
            txtRemarks.Text = fabricWorking.AllRemarks;
            ddlAvgUnit1.SelectedValue = fabricWorking.UnitOfAverage1;
            ddlAvgUnit2.SelectedValue = fabricWorking.UnitOfAverage2;
            ddlAvgUnit3.SelectedValue = fabricWorking.UnitOfAverage3;
            ddlAvgUnit4.SelectedValue = fabricWorking.UnitOfAverage4;



            #region Gajendra Commented 13-04-2016
            //added by abhishek on 21/12/2015
            //chkREFReceived_1.Checked = fabricWorking.PrintColorRecdFabric1 == 1 ? true : false; ;
            // chkREFReceived_2.Checked = fabricWorking.PrintColorRecdFabric2 == 1 ? true : false; ;
            // chkREFReceived_3.Checked = fabricWorking.PrintColorRecdFabric3 == 1 ? true : false; ;
            // chkREFReceived_4.Checked = fabricWorking.PrintColorRecdFabric4 == 1 ? true : false; ;

            // //chkREFReceived_1.Enabled = fabricWorking.PrintColorRecdFabric1 == 1 ? false : true; ;
            // chkREFReceived_2.Enabled = fabricWorking.PrintColorRecdFabric2 == 1 ? false : true; ;
            // chkREFReceived_3.Enabled = fabricWorking.PrintColorRecdFabric3 == 1 ? false : true; ;
            // chkREFReceived_4.Enabled = fabricWorking.PrintColorRecdFabric4 == 1 ? false : true; ;

            // //chkQualityApproved_1.Checked = fabricWorking.FabricQualtityAprdFabric1 == 1 ? true : false;
            // //chkQualityApproved_2.Checked = fabricWorking.FabricQualtityAprdFabric2 == 1 ? true : false;
            // //chkQualityApproved_3.Checked = fabricWorking.FabricQualtityAprdFabric3 == 1 ? true : false;
            // //chkQualityApproved_4.Checked = fabricWorking.FabricQualtityAprdFabric4 == 1 ? true : false;

            // //ddlQtyApvd_1.SelectedValue = fabricWorking.FabricQualtityAprdFabric1 == 0 ? "-1" : fabricWorking.FabricQualtityAprdFabric1.ToString();
            // ddlQtyApvd_2.SelectedValue = fabricWorking.FabricQualtityAprdFabric2 == 0 ? "-1" : fabricWorking.FabricQualtityAprdFabric2.ToString();
            // ddlQtyApvd_3.SelectedValue = fabricWorking.FabricQualtityAprdFabric3 == 0 ? "-1" : fabricWorking.FabricQualtityAprdFabric3.ToString();
            // ddlQtyApvd_4.SelectedValue = fabricWorking.FabricQualtityAprdFabric4 == 0 ? "-1" : fabricWorking.FabricQualtityAprdFabric4.ToString();

            // //ddlinitial_1.SelectedValue = fabricWorking.IntialAprdFabric1 == 0 ? "-1" : fabricWorking.IntialAprdFabric1.ToString();
            // ddlinitial_2.SelectedValue = fabricWorking.IntialAprdFabric2 == 0 ? "-1" : fabricWorking.IntialAprdFabric2.ToString();
            // ddlinitial_3.SelectedValue = fabricWorking.IntialAprdFabric3 == 0 ? "-1" : fabricWorking.IntialAprdFabric3.ToString();
            // ddlinitial_4.SelectedValue = fabricWorking.IntialAprdFabric4 == 0 ? "-1" : fabricWorking.IntialAprdFabric4.ToString();


            // //ddlbulkApvd_1.SelectedValue = fabricWorking.BulkAprdFabric1 == 0 ? "-1" : fabricWorking.BulkAprdFabric1.ToString();
            // ddlbulkApvd_2.SelectedValue = fabricWorking.BulkAprdFabric2 == 0 ? "-1" : fabricWorking.BulkAprdFabric2.ToString();
            // ddlbulkApvd_3.SelectedValue = fabricWorking.BulkAprdFabric3 == 0 ? "-1" : fabricWorking.BulkAprdFabric3.ToString();
            // ddlbulkApvd_4.SelectedValue = fabricWorking.BulkAprdFabric4 == 0 ? "-1" : fabricWorking.BulkAprdFabric4.ToString();



            // //ddlbulkApvd_1.Enabled = fabricWorking.IntialAprdFabric1 == 2 ? true : false;
            // ddlbulkApvd_2.Enabled = fabricWorking.IntialAprdFabric2 == 2 ? true : false;
            // ddlbulkApvd_3.Enabled = fabricWorking.IntialAprdFabric3 == 2 ? true : false;
            // ddlbulkApvd_4.Enabled = fabricWorking.IntialAprdFabric4 == 2 ? true : false;
            // /////
            // //chkREFReceived_1.Enabled = fabricWorking.PrintColorRecdFabric1 == 1 ? false : true; ;
            // chkREFReceived_2.Enabled = fabricWorking.PrintColorRecdFabric2 == 1 ? false : true; ;
            // chkREFReceived_3.Enabled = fabricWorking.PrintColorRecdFabric3 == 1 ? false : true; ;
            // chkREFReceived_4.Enabled = fabricWorking.PrintColorRecdFabric4 == 1 ? false : true; ;

            //// ddlQtyApvd_1.Enabled = fabricWorking.FabricQualtityAprdFabric1 == 2 ? false : true;
            // ddlQtyApvd_2.Enabled = fabricWorking.FabricQualtityAprdFabric2 == 2 ? false : true;
            // ddlQtyApvd_3.Enabled = fabricWorking.FabricQualtityAprdFabric3 == 2 ? false : true;
            // ddlQtyApvd_4.Enabled = fabricWorking.FabricQualtityAprdFabric4 == 2 ? false : true;

            // //ddlinitial_1.Enabled = fabricWorking.IntialAprdFabric1 == 2 ? false : true;
            // ddlinitial_2.Enabled = fabricWorking.IntialAprdFabric2 == 2 ? false : true;
            // ddlinitial_3.Enabled = fabricWorking.IntialAprdFabric3 == 2 ? false : true;
            // ddlinitial_4.Enabled = fabricWorking.IntialAprdFabric4 == 2 ? false : true;

            // //ddlbulkApvd_1.Enabled = fabricWorking.BulkAprdFabric1 == 2 ? false : true;
            // ddlbulkApvd_2.Enabled = fabricWorking.BulkAprdFabric2 == 2 ? false : true;
            // ddlbulkApvd_3.Enabled = fabricWorking.BulkAprdFabric3 == 2 ? false : true;
            // ddlbulkApvd_4.Enabled = fabricWorking.BulkAprdFabric4 == 2 ? false : true;

            // //=================================31-03-2016==============1=======================================
            // if (fabricWorking.FabricQualtityAprdFabric1 == 3)
            // {
            //    // ddlQtyApvd_1.ForeColor = Color.Red;
            //     //lblQualityupdatedate_1.ForeColor = Color.Red;
            // }
            // else if (fabricWorking.FabricQualtityAprdFabric1 == 2)
            // {
            //     //ddlQtyApvd_1.ForeColor = Color.Gray;
            //     //lblQualityupdatedate_1.ForeColor = Color.Gray;
            // }          
            // else
            //     //lblQualityupdatedate_1.ForeColor = Color.Blue;
            // // ---------------------------------------------------------------------------------------
            // if (fabricWorking.IntialAprdFabric1 == 3)
            // {
            //     //ddlinitial_1.ForeColor = Color.Red;
            //     //lblinitialupdatedate_1.ForeColor = Color.Red;
            // }
            // //else if (fabricWorking.IntialAprdFabric1 == 2)
            // //{
            // //    ddlinitial_1.ForeColor = Color.Gray;
            // //    lblinitialupdatedate_1.ForeColor = Color.Gray;
            // //}
            // //else
            // //    lblinitialupdatedate_1.ForeColor = Color.Blue;

            // //// ---------------------------------------------------------------------------------------
            // //if (fabricWorking.BulkAprdFabric1 == 3)
            // //{
            // //    ddlbulkApvd_1.ForeColor = Color.Red;
            // //    lblBulkupdatedate_1.ForeColor = Color.Red;
            // //}
            // //else if (fabricWorking.BulkAprdFabric1 == 2)
            // //{
            // //    ddlbulkApvd_1.ForeColor = Color.Gray;
            // //    lblBulkupdatedate_1.ForeColor = Color.Gray;
            // //}
            // //else
            // //    lblBulkupdatedate_1.ForeColor = Color.Blue;

            // //==========================================2=============================================

            // if (fabricWorking.FabricQualtityAprdFabric2 == 3)
            // {
            //     ddlQtyApvd_2.ForeColor = Color.Red;
            //     lblQualityupdatedate_2.ForeColor = Color.Red;
            // }
            // else if (fabricWorking.FabricQualtityAprdFabric2 == 2)
            // {
            //     ddlQtyApvd_2.ForeColor = Color.Gray;
            //     lblQualityupdatedate_2.ForeColor = Color.Gray;
            // }
            // else
            //     lblQualityupdatedate_2.ForeColor = Color.Blue;
            // // ---------------------------------------------------------------------------------------
            // if (fabricWorking.IntialAprdFabric2 == 3)
            // {
            //     ddlinitial_2.ForeColor = Color.Red;
            //     lblinitialupdatedate_2.ForeColor = Color.Red;
            // }
            // else if (fabricWorking.IntialAprdFabric2 == 2)
            // {
            //     ddlinitial_2.ForeColor = Color.Gray;
            //     lblinitialupdatedate_2.ForeColor = Color.Gray;
            // }
            // else
            //     lblinitialupdatedate_2.ForeColor = Color.Blue;

            // // ---------------------------------------------------------------------------------------
            // if (fabricWorking.BulkAprdFabric2 == 3)
            // {
            //     ddlbulkApvd_2.ForeColor = Color.Red;
            //     lblBulkupdatedate_2.ForeColor = Color.Red;
            // }
            // else if (fabricWorking.BulkAprdFabric2 == 2)
            // {
            //     ddlbulkApvd_2.ForeColor = Color.Gray;
            //     lblBulkupdatedate_2.ForeColor = Color.Gray;
            // }
            // else
            //     lblBulkupdatedate_2.ForeColor = Color.Blue;
            // //======================================3=====================================================
            // if (fabricWorking.FabricQualtityAprdFabric3 == 3)
            // {
            //     ddlQtyApvd_3.ForeColor = Color.Red;
            //     lblQualityupdatedate_3.ForeColor = Color.Red;
            // }
            // else if (fabricWorking.FabricQualtityAprdFabric3 == 2)
            // {
            //     ddlQtyApvd_3.ForeColor = Color.Gray;
            //     lblQualityupdatedate_3.ForeColor = Color.Gray;
            // }
            // else
            //     lblQualityupdatedate_3.ForeColor = Color.Blue;
            // // ---------------------------------------------------------------------------------------
            // if (fabricWorking.IntialAprdFabric3 == 3)
            // {
            //     ddlinitial_3.ForeColor = Color.Red;
            //     lblinitialupdatedate_3.ForeColor = Color.Red;
            // }
            // else if (fabricWorking.IntialAprdFabric3 == 2)
            // {
            //     ddlinitial_3.ForeColor = Color.Gray;
            //     lblinitialupdatedate_3.ForeColor = Color.Gray;
            // }
            // else
            //     lblinitialupdatedate_3.ForeColor = Color.Blue;

            // // ---------------------------------------------------------------------------------------
            // if (fabricWorking.BulkAprdFabric3 == 3)
            // {
            //     ddlbulkApvd_3.ForeColor = Color.Red;
            //     lblBulkupdatedate_3.ForeColor = Color.Red;
            // }
            // else if (fabricWorking.BulkAprdFabric3 == 2)
            // {
            //     ddlbulkApvd_3.ForeColor = Color.Gray;
            //     lblBulkupdatedate_3.ForeColor = Color.Gray;
            // }
            // else
            //     lblBulkupdatedate_3.ForeColor = Color.Blue;

            // //======================================4=====================================================
            // if (fabricWorking.FabricQualtityAprdFabric4 == 3)
            // {
            //     ddlQtyApvd_4.ForeColor = Color.Red;
            //     lblQualityupdatedate_4.ForeColor = Color.Red;
            // }
            // else if (fabricWorking.FabricQualtityAprdFabric4 == 2)
            // {
            //     ddlQtyApvd_4.ForeColor = Color.Gray;
            //     lblQualityupdatedate_4.ForeColor = Color.Gray;
            // }
            // else
            //     lblQualityupdatedate_4.ForeColor = Color.Blue;
            // // ---------------------------------------------------------------------------------------
            // if (fabricWorking.IntialAprdFabric4 == 3)
            // {
            //     ddlinitial_4.ForeColor = Color.Red;
            //     lblinitialupdatedate_4.ForeColor = Color.Red;
            // }
            // else if (fabricWorking.IntialAprdFabric4 == 2)
            // {
            //     ddlinitial_4.ForeColor = Color.Gray;
            //     lblinitialupdatedate_4.ForeColor = Color.Gray;
            // }
            // else
            //     lblinitialupdatedate_4.ForeColor = Color.Blue;

            // // ---------------------------------------------------------------------------------------
            // if (fabricWorking.BulkAprdFabric4 == 3)
            // {
            //     ddlbulkApvd_4.ForeColor = Color.Red;
            //     lblBulkupdatedate_4.ForeColor = Color.Red;
            // }
            // else if (fabricWorking.BulkAprdFabric4 == 2)
            // {
            //     ddlbulkApvd_4.ForeColor = Color.Gray;
            //     lblBulkupdatedate_4.ForeColor = Color.Gray;
            // }
            // else
            //     lblBulkupdatedate_4.ForeColor = Color.Blue;

            // //============================END============================================================

            // if (fabricWorking.PrintColorRecdOnFabric1 != "")
            // {
            //     //lblrefupdateddate_1.Text = "(" + Convert.ToDateTime(fabricWorking.PrintColorRecdOnFabric1).ToString("dd MMM  (yy)") + ")";
            // }
            // if (fabricWorking.FabricQualtityAprdOnFabric1 != "")
            // {
            //     //lblQualityupdatedate_1.Text = "(" + Convert.ToDateTime(fabricWorking.FabricQualtityAprdOnFabric1).ToString("dd MMM  (yy)") + ")";
            // }
            // if (fabricWorking.IntialAprdOnFabric1 != "")
            // {
            //     //lblinitialupdatedate_1.Text = "(" + Convert.ToDateTime(fabricWorking.IntialAprdOnFabric1).ToString("dd MMM  (yy)") + ")";
            // }
            // if (fabricWorking.BulkAprdOnFabric1 != "")
            // {
            //     //lblBulkupdatedate_1.Text = "(" + Convert.ToDateTime(fabricWorking.BulkAprdOnFabric1).ToString("dd MMM  (yy)") + ")";
            // }

            // if (fabricWorking.PrintColorRecdOnFabric2 != "")
            // {
            //     lblrefupdateddate_2.Text = "(" + Convert.ToDateTime(fabricWorking.PrintColorRecdOnFabric2).ToString("dd MMM  (yy)") + ")";
            // }

            // if (fabricWorking.FabricQualtityAprdOnFabric2 != "")
            // {
            //     lblQualityupdatedate_2.Text = "(" + Convert.ToDateTime(fabricWorking.FabricQualtityAprdOnFabric2).ToString("dd MMM  (yy)") + ")";
            // }
            // if (fabricWorking.IntialAprdOnFabric2 != "")
            // {
            //     lblinitialupdatedate_2.Text = "(" + Convert.ToDateTime(fabricWorking.IntialAprdOnFabric2).ToString("dd MMM  (yy)") + ")";
            // }
            // if (fabricWorking.BulkAprdOnFabric2 != "")
            // {
            //     lblBulkupdatedate_2.Text = "(" + Convert.ToDateTime(fabricWorking.BulkAprdOnFabric2).ToString("dd MMM  (yy)") + ")";
            // }


            // if (fabricWorking.PrintColorRecdOnFabric3 != "")
            // {
            //     lblrefupdateddate_3.Text = "(" + Convert.ToDateTime(fabricWorking.PrintColorRecdOnFabric3).ToString("dd MMM  (yy)") + ")";
            // }

            // if (fabricWorking.FabricQualtityAprdOnFabric3 != "")
            // {
            //     lblQualityupdatedate_3.Text = "(" + Convert.ToDateTime(fabricWorking.FabricQualtityAprdOnFabric3).ToString("dd MMM  (yy)") + ")";
            // }
            // if (fabricWorking.FabricQualtityAprdOnFabric3 != "")
            // {
            //     lblQualityupdatedate_3.Text = "(" + Convert.ToDateTime(fabricWorking.FabricQualtityAprdOnFabric3).ToString("dd MMM  (yy)") + ")";
            // }
            // if (fabricWorking.IntialAprdOnFabric3 != "")
            // {
            //     lblinitialupdatedate_3.Text = "(" + Convert.ToDateTime(fabricWorking.IntialAprdOnFabric3).ToString("dd MMM  (yy)") + ")";
            // }
            // if (fabricWorking.BulkAprdOnFabric3 != "")
            // {
            //     lblBulkupdatedate_3.Text = "(" + Convert.ToDateTime(fabricWorking.BulkAprdOnFabric3).ToString("dd MMM  (yy)") + ")";
            // }

            // if (fabricWorking.PrintColorRecdOnFabric4 != "")
            // {
            //     lblrefupdateddate_4.Text = "(" + Convert.ToDateTime(fabricWorking.PrintColorRecdOnFabric4).ToString("dd MMM  (yy)") + ")";
            // }

            // if (fabricWorking.FabricQualtityAprdOnFabric4 != "")
            // {
            //     lblQualityupdatedate_4.Text = "(" + Convert.ToDateTime(fabricWorking.FabricQualtityAprdOnFabric4).ToString("dd MMM  (yy)") + ")";
            // }
            // if (fabricWorking.FabricQualtityAprdOnFabric4 != "")
            // {
            //     lblQualityupdatedate_4.Text = "(" + Convert.ToDateTime(fabricWorking.FabricQualtityAprdOnFabric4).ToString("dd MMM  (yy)") + ")";
            // }
            // if (fabricWorking.IntialAprdOnFabric4 != "")
            // {
            //     lblinitialupdatedate_4.Text = "(" + Convert.ToDateTime(fabricWorking.IntialAprdOnFabric4).ToString("dd MMM  (yy)") + ")";
            // }
            // if (fabricWorking.BulkAprdOnFabric4 != "")
            // {
            //     lblBulkupdatedate_4.Text = "(" + Convert.ToDateTime(fabricWorking.BulkAprdOnFabric4).ToString("dd MMM  (yy)") + ")";
            // }
            //here show commet popup by using orderid and Flag and faricDeayils 


            //end by abhishek on 21/12/2015

            #endregion

            if (Convert.ToInt32(fabricWorking.UnitOfAverage1) == 1)
                lblUnit1.Text = "KG";
            else if (Convert.ToInt32(fabricWorking.UnitOfAverage1) == 2)
                lblUnit1.Text = "MTRS";
            else
                lblUnit1.Text = string.Empty;

            if (Convert.ToInt32(fabricWorking.UnitOfAverage2) == 1)
                lblUnit2.Text = "KG";
            else if (Convert.ToInt32(fabricWorking.UnitOfAverage2) == 2)
                lblUnit2.Text = "MTRS";
            else
                lblUnit2.Text = string.Empty;

            if (Convert.ToInt32(fabricWorking.UnitOfAverage3) == 1)
                lblUnit3.Text = "KG";
            else if (Convert.ToInt32(fabricWorking.UnitOfAverage3) == 2)
                lblUnit3.Text = "MTRS";
            else
                lblUnit3.Text = string.Empty;

            if (Convert.ToInt32(fabricWorking.UnitOfAverage4) == 1)
                lblUnit4.Text = "KG";
            else if (Convert.ToInt32(fabricWorking.UnitOfAverage4) == 2)
                lblUnit4.Text = "MTRS";
            else
                lblUnit4.Text = string.Empty;

            if (fabricWorking.AvgChecked == 1)
            {
                chkboxAvgChecked.Checked = true;
                chkboxAvgChecked.Enabled = false;
            }
            if (fabricWorking.ApprovedByAccountManager == 1)
            {
                chkboxAccountMgr.Checked = true;
                chkboxAccountMgr.Enabled = false;
            }
            if (fabricWorking.ApprovedByFabricManager == 1)
            {
                chkboxFabricManager.Checked = true;
                chkboxFabricManager.Enabled = false;
            }
            if (fabricWorking.ApprovedAcknowledgementManager == 1)
            {
                chkUcknowledgment.Checked = true;
                chkUcknowledgment.Enabled = false;
            }

            repeaterOrderBreakdown.DataSource = fabricWorking.order.OrderBreakdown;
            repeaterOrderBreakdown.DataBind();
            //added by abhishek on 21/12/2015


            string userName = iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.FirstName;




            foreach (OrderDetail od in fabricWorking.order.OrderBreakdown)
            {
                if (!string.IsNullOrEmpty(od.Fabric1))
                {
                    lblFabric1.Text = od.Fabric1;
                    lblFabric111.Text = od.CCGSM1;
                    txtFabric1InitialWidth.Enabled = false;
                    txtFabric1UsableWidth.Enabled = true;
                    ddlAvgUnit1.Enabled = true;

                    //chkREFReceived_1.Enabled = true;

                    //hlnViewComments_1.Attributes.Add("onclick", "javascript:UploadComentsFabricWorking('" + OrderId + "','" + od.Fabric1 + "','" + "FAB1" + "','" + userName + "')");
                    hlnViewComments_1.Attributes.Add("onclick", "javascript:UploadComentsFabricWorking('" + OrderId + "','" + "" + "','" + "FAB1" + "','" + userName + "')");





                }
                else
                {
                    txtFabric1InitialWidth.Enabled = false;
                    txtFabric1UsableWidth.Enabled = false;
                    ddlAvgUnit1.Enabled = false;

                    //chkREFReceived_1.Enabled = false;



                }

                if (!string.IsNullOrEmpty(od.Fabric2))
                {
                    lblFabric2.Text = od.Fabric2;
                    lblFabric112.Text = od.CCGSM2;
                    txtFabric2InitialWidth.Enabled = false;
                    txtFabric2UsableWidth.Enabled = true;
                    ddlAvgUnit2.Enabled = true;



                    //chkREFReceived_2.Enabled = true;
                    //hlnViewComments_2.Attributes.Add("onclick", "javascript:UploadComentsFabricWorking('" + OrderId + "','" + od.Fabric2 + "','" + "FAB2" + "','" + userName + "')");
                    hlnViewComments_2.Attributes.Add("onclick", "javascript:UploadComentsFabricWorking('" + OrderId + "','" + "" + "','" + "FAB2" + "','" + userName + "')");
                }
                else
                {
                    txtFabric2InitialWidth.Enabled = false;
                    txtFabric2UsableWidth.Enabled = false;
                    ddlAvgUnit2.Enabled = false;


                    //chkREFReceived_2.Enabled = false;

                }
                if (!string.IsNullOrEmpty(od.Fabric3))
                {
                    lblFabric3.Text = od.Fabric3;
                    lblFabric113.Text = od.CCGSM3;
                    txtFabric3InitialWidth.Enabled = false;
                    txtFabric3UsableWidth.Enabled = true;
                    ddlAvgUnit3.Enabled = true;

                    //chkREFReceived_3.Enabled = true;
                    //hlnViewComments_3.Attributes.Add("onclick", "javascript:UploadComentsFabricWorking('" + OrderId + "','" + od.Fabric3 + "','" + "FAB3" + "','" + userName + "')");
                    hlnViewComments_3.Attributes.Add("onclick", "javascript:UploadComentsFabricWorking('" + OrderId + "','" + "" + "','" + "FAB3" + "','" + userName + "')");

                }
                else
                {
                    txtFabric3InitialWidth.Enabled = false;
                    txtFabric3UsableWidth.Enabled = false;
                    ddlAvgUnit3.Enabled = false;


                    //chkREFReceived_3.Enabled = false;

                }
                if (!string.IsNullOrEmpty(od.Fabric4))
                {
                    lblFabric4.Text = od.Fabric4;
                    lblFabric114.Text = od.CCGSM4;
                    txtFabric4InitialWidth.Enabled = false;
                    txtFabric4UsableWidth.Enabled = true;
                    ddlAvgUnit4.Enabled = true;

                    //chkREFReceived_4.Enabled = true;
                    //hlnViewComments_4.Attributes.Add("onclick", "javascript:UploadComentsFabricWorking('" + OrderId + "','" + od.Fabric4 + "','" + "FAB4" + "','" + userName + "')");
                    hlnViewComments_4.Attributes.Add("onclick", "javascript:UploadComentsFabricWorking('" + OrderId + "','" + "" + "','" + "FAB4" + "','" + userName + "')");
                }
                else
                {
                    txtFabric4InitialWidth.Enabled = false;
                    txtFabric4UsableWidth.Enabled = false;
                    ddlAvgUnit4.Enabled = false;

                    //chkREFReceived_4.Enabled = false;

                }

                //int prdNumber =0;
                //if (int.TryParse(od.Fabric1Details, out prdNumber))
                //{
                //    od.Fabric1Details = "PRD " + od.Fabric1Details;
                //}
                //if (int.TryParse(od.Fabric2Details, out prdNumber))
                //{
                //    od.Fabric2Details = "PRD " + od.Fabric2Details;
                //}
                //if (int.TryParse(od.Fabric3Details, out prdNumber))
                //{
                //    od.Fabric3Details = "PRD " + od.Fabric3Details;
                //}
                //if (int.TryParse(od.Fabric4Details, out prdNumber))
                //{
                //    od.Fabric4Details = "PRD " + od.Fabric4Details;
                //}



                lblFab1ColPrd.Text = od.Fabric1;
                lblFab2ColPrd.Text = od.Fabric2;
                lblFab3ColPrd.Text = od.Fabric3;
                lblFab4ColPrd.Text = od.Fabric4;


                if (lblFab1ColPrd.Text == "")
                {
                    Fabric1Upload.Visible = false;
                    viewolay1.Visible = false;

                    //chkREFReceived_1.Visible = false;
                    // chkQualityApproved_1.Visible = false;
                    DivFabricSection_1.Visible = false;


                }

                if (lblFab2ColPrd.Text == "")
                {
                    Fabric2Upload.Visible = false;
                    viewolay2.Visible = false;

                    //chkREFReceived_2.Visible = false;
                    //chkQualityApproved_2.Visible = false;
                    DivFabricSection_2.Visible = false;
                }

                if (lblFab3ColPrd.Text == "")
                {
                    Fabric3Upload.Visible = false;
                    viewolay3.Visible = false;

                    //chkREFReceived_3.Visible = false;
                    //chkQualityApproved_3.Visible = false;
                    DivFabricSection_3.Visible = false;
                }

                if (lblFab4ColPrd.Text == "")
                {
                    Fabric4Upload.Visible = false;
                    viewolay4.Visible = false;


                    //chkREFReceived_4.Visible = false;
                    //chkQualityApproved_4.Visible = false;
                    DivFabricSection_4.Visible = false;
                }


            }

            //end by abhishek on 21/12/2015

            if (fabricWorking.History.IndexOf("$$") > -1)
            {
                fabricWorking.History = fabricWorking.History.Replace("$$", "<br/>");
                lblHistory.Text = fabricWorking.History.Replace("<br/><br/>", "<br/>");
            }
            else
            {
                lblHistory.Text = fabricWorking.History;
            }

            //SetFabricMangerVisibility(fabricWorking);
            CheckFabricManagerVisibility(fabricWorking);

            if (fabricWorking.ApprovedByAccountManager == 1)
            {
                chkboxAccountMgr.Checked = true;
                chkboxAccountMgr.Enabled = false;
            }
            if (fabricWorking.ApprovedByFabricManager == 1)
            {
                chkboxFabricManager.Checked = true;
                chkboxFabricManager.Enabled = false;
            }
            if (fabricWorking.ApprovedAcknowledgementManager == 1)
            {
                chkUcknowledgment.Checked = true;
            }
            //chkREFReceived_1.Enabled = fabricWorking.PrintColorRecdFabric1 == 1 ? false : true; ;
            //chkREFReceived_2.Enabled = fabricWorking.PrintColorRecdFabric2 == 1 ? false : true; ;
            //chkREFReceived_3.Enabled = fabricWorking.PrintColorRecdFabric3 == 1 ? false : true; ;
            //chkREFReceived_4.Enabled = fabricWorking.PrintColorRecdFabric4 == 1 ? false : true; ;
        }
        //setting facric manager checkbox Diable & Enable
        //added by abhishek on 21/12/2015
        //public void SetFabricMangerVisibility(FabricWorking fw)
        //{

        //    IsFabricMangerApproved += lblFab1ColPrd.Text == "" ? 0 : 1;
        //    IsFabricMangerApproved += lblFab2ColPrd.Text == "" ? 0 : 1;
        //    IsFabricMangerApproved += lblFab3ColPrd.Text == "" ? 0 : 1;
        //    IsFabricMangerApproved += lblFab4ColPrd.Text == "" ? 0 : 1;

        //    switch (IsFabricMangerApproved)
        //    {
        //        case 1:
        //            if (fw.BulkAprdFabric1 == 2)
        //            {
        //                chkboxFabricManager.Enabled = true;
        //            }
        //            break;
        //        case 2:
        //            if (fw.BulkAprdFabric1 == 2 && fw.BulkAprdFabric2 == 2)
        //            {
        //                chkboxFabricManager.Enabled = true;
        //            }
        //            break;
        //        case 3:
        //            if (fw.BulkAprdFabric1 == 2 && fw.BulkAprdFabric2 == 2 && fw.BulkAprdFabric3 == 2)
        //            {
        //                chkboxFabricManager.Enabled = true;
        //            }
        //            break;

        //        case 4:
        //            if (fw.BulkAprdFabric1 == 2 && fw.BulkAprdFabric2 == 2 && fw.BulkAprdFabric3 == 2 && fw.BulkAprdFabric4 == 2)
        //            {
        //                chkboxFabricManager.Enabled = true;
        //            }
        //            break;
        //        default:

        //            break;
        //    }


        //    //if (fw.PrintColorRecdFabric1 == 1 && fw.FabricQualtityAprdFabric1 == 1)
        //    //{

        //    //    chkboxFabricManager.Enabled = true;
        //    //}
        //    //if (fw.PrintColorRecdFabric2 == 1 && fw.FabricQualtityAprdFabric2 == 1)
        //    //{

        //    //    chkboxFabricManager.Enabled = true;
        //    //}
        //    //if (fw.PrintColorRecdFabric3 == 1 && fw.FabricQualtityAprdFabric3 == 1)
        //    //{

        //    //    chkboxFabricManager.Enabled = true;
        //    //}
        //    //if (fw.PrintColorRecdFabric4 == 1 && fw.FabricQualtityAprdFabric4 == 1)
        //    //{

        //    //    chkboxFabricManager.Enabled = true;
        //    //}

        //}
        //end by abhishek on 21/12/2015
        public void ShowAlert(string stringAlertMsg)
        {
            string myStringVariable = string.Empty;
            myStringVariable = stringAlertMsg;
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);
        }
        private void SaveFabricWorkingData()
        {
            //string differences = "";
            //DateTime dt = DateTime.Now;
            //string s = String.Format("{0:G}", dt);
            //s = s.Replace(" ", "_");
            //s = s.Replace(':', '/');
            //s = s.Replace('/', '-');
            //var fabricWorking = new FabricWorking();
            //fabricWorking.OrderDetailID = OrderDetailID;
            //FabricWorking fabricWorking1 = FabricWorkingControllerInstance.GetFabricWorking(OrderId, OrderDetailID);

            //fabricWorking.CreationDate = DateHelper.ParseDate(lblCreationDate.Text).Value;

            //// Add By Ravi kumar on 11/12/2014


            ////Added By Ashish on 7/1/2014
            //if (lblFab1ColPrd.Text != "")
            //{
            //    if (chkboxAccountMgr.Enabled == true && chkboxAccountMgr.Checked == true)
            //    {
            //        if (Fabric1Upload.FileName == "")
            //        {
            //            ShowAlert("Please upload marker against each fabric");
            //            return;
            //        }
            //    }
            //}

            //if (lblFab2ColPrd.Text != "")
            //{
            //    if (chkboxAccountMgr.Enabled == true && chkboxAccountMgr.Checked == true)
            //    {
            //        if (Fabric2Upload.FileName == "")
            //        {
            //            ShowAlert("Please upload marker against each fabric");
            //            return;
            //        }
            //    }
            //}

            //if (lblFab3ColPrd.Text != "")
            //{
            //    if (chkboxAccountMgr.Enabled == true && chkboxAccountMgr.Checked == true)
            //    {
            //        if (Fabric3Upload.FileName == "")
            //        {
            //            ShowAlert("Please upload marker against each fabric");
            //            return;
            //        }
            //    }
            //}

            //if (lblFab4ColPrd.Text != "")
            //{
            //    if (chkboxAccountMgr.Enabled == true && chkboxAccountMgr.Checked == true)
            //    {
            //        if (Fabric4Upload.FileName == "")
            //        {
            //            ShowAlert("Please upload marker against each fabric");
            //            return;
            //        }
            //    }
            //}
            ////END

            //string Fabric1UploadFileName = Fabric1Upload.FileName;
            //string sLayFileName1 = viewolay1.NavigateUrl.ToString();



            //string Exten = System.IO.Path.GetExtension(Fabric1Upload.FileName);

            //string timestamp = DateTime.Now.ToString("hh.mm.ss.ffffff");
            //if (lblSerial.Text != "" && Fabric1Upload.HasFile)
            //{
            //    Fabric1UploadFileName = "FAB1_" + "_" + lblStyleNumber.Text + Exten;
            //}
            ////else
            ////{
            ////    Fabric1UploadFileName = 1 + "_FAB1_" + s + timestamp + "_" + Exten;

            ////}



            //if (Fabric1UploadFileName != "")
            //{
            //    Fabric1Upload.SaveAs(Server.MapPath("~/Uploads/Photo/") + s + Fabric1UploadFileName);
            //    fabricWorking.Fabric1File = Fabric1UploadFileName == "" ? "" : s + Fabric1UploadFileName;
            //}
            ////else
            ////{
            ////    if (sLayFileName1 != "")
            ////    {
            ////        string[] sName = sLayFileName1.Split(new char[] { '/' });
            ////        sLayFileName1 = sName[3].ToString();
            ////        fabricWorking.Fabric1File = sLayFileName1 == "" ? "" : sLayFileName1;
            ////    }
            ////}


            //string Fabric2UploadFileName = Fabric2Upload.FileName;
            //string sLayFileName2 = viewolay2.NavigateUrl.ToString();



            //string Exten2 = System.IO.Path.GetExtension(Fabric2Upload.FileName);


            //if (lblSerial.Text != "" && Fabric2Upload.HasFile)
            //{
            //    Fabric2UploadFileName = "FAB2_" + lblStyleNumber.Text + Exten2;
            //}
            ////else
            ////{
            ////    Fabric2UploadFileName = 2 + "_FAB2_" + s + DateTime.Now.ToString("hh.mm.ss.ffffff") + "_" + Exten2;

            ////}

            //if (Fabric2UploadFileName != "")
            //{
            //    Fabric2Upload.SaveAs(Server.MapPath("~/Uploads/Photo/") + s + Fabric2UploadFileName);
            //    fabricWorking.Fabric2File = Fabric2UploadFileName == "" ? "" : s + Fabric2UploadFileName;
            //}
            ////else
            ////{
            ////    if (sLayFileName2 != "")
            ////    {
            ////        string[] sName = sLayFileName2.Split(new char[] { '/' });
            ////        sLayFileName2 = sName[3].ToString();
            ////        fabricWorking.Fabric2File = sLayFileName2 == "" ? "" : sLayFileName2;
            ////    }
            ////}

            //string Fabric3UploadFileName = Fabric3Upload.FileName;
            //string sLayFileName3 = viewolay3.NavigateUrl.ToString();


            //string Exten3 = System.IO.Path.GetExtension(Fabric3Upload.FileName);


            //if (lblSerial.Text != "" && Fabric3Upload.HasFile)
            //{
            //    Fabric3UploadFileName = "FAB3_" + lblStyleNumber.Text + Exten3;
            //}
            ////else
            ////{
            ////    Fabric3UploadFileName = 3 + "_FAB3_" + s + DateTime.Now.ToString("hh.mm.ss.ffffff") + "_" + Exten3;

            ////}


            //if (Fabric3UploadFileName != "")
            //{
            //    Fabric3Upload.SaveAs(Server.MapPath("~/Uploads/Photo/") + s + Fabric3UploadFileName);
            //    fabricWorking.Fabric3File = Fabric3UploadFileName == "" ? "" : s + Fabric3UploadFileName;
            //}

            ////else
            ////{
            ////    if (sLayFileName3 != "")
            ////    {
            ////        string[] sName = sLayFileName3.Split(new char[] { '/' });
            ////        sLayFileName3 = sName[3].ToString();
            ////        fabricWorking.Fabric3File = sLayFileName3 == "" ? "" : sLayFileName3;
            ////    }
            ////}

            //string Fabric4UploadFileName = Fabric4Upload.FileName;
            //string sLayFileName4 = viewolay4.NavigateUrl.ToString();


            //string Exten4 = System.IO.Path.GetExtension(Fabric4Upload.FileName);


            //if (lblSerial.Text != "" && Fabric4Upload.HasFile)
            //{
            //    Fabric4UploadFileName = "FAB4_" + lblStyleNumber.Text + Exten4;
            //}
            ////else
            ////{
            ////    Fabric4UploadFileName = 1 + "_FAB4_" + s + DateTime.Now.ToString("hh.mm.ss.ffffff") + "_" + Exten4;

            ////}


            //if (Fabric4UploadFileName != "")
            //{
            //    Fabric3Upload.SaveAs(Server.MapPath("~/Uploads/Photo/") + s + Fabric4UploadFileName);
            //    fabricWorking.Fabric4File = Fabric3UploadFileName == "" ? "" : s + Fabric4UploadFileName;
            //}





            ////if (Fabric4UploadFileName != "")
            ////{
            ////    Fabric4Upload.SaveAs(Server.MapPath("~/Uploads/Photo/") + Fabric4UploadFileName);
            ////    fabricWorking.Fabric4File = Fabric4UploadFileName == "" ? "" :  Fabric4UploadFileName;
            ////}
            ////else
            ////{
            ////    if (sLayFileName4 != "")
            ////    {
            ////        string[] sName = sLayFileName4.Split(new char[] { '/' });
            ////        sLayFileName4 = sName[3].ToString();
            ////        fabricWorking.Fabric4File = sLayFileName4 == "" ? "" : sLayFileName4;
            ////    }
            ////}


            //if (!string.IsNullOrEmpty(txtCuttingWastageFabric1.Text))
            //    fabricWorking.Fabric1Wastage = Convert.ToDouble(txtCuttingWastageFabric1.Text);

            //if (!string.IsNullOrEmpty(txtShrinkageFabric1.Text))
            //    fabricWorking.Fabric1Shrinkage = Convert.ToDouble(txtShrinkageFabric1.Text);

            //if (!string.IsNullOrEmpty(txtTotalRequirementGreigeFabric1.Text))
            //    fabricWorking.Fabric1Greige = Convert.ToDouble(txtTotalRequirementGreigeFabric1.Text);

            ////string txtTotalFabric1 = txtTotalFabric1

            //if (!string.IsNullOrEmpty(txtTotalFabric1.Text))
            //    fabricWorking.TotalFabric1Greige = Convert.ToDouble(txtTotalFabric1.Text);

            //if (!string.IsNullOrEmpty(txtTotalFabric2.Text))
            //    fabricWorking.TotalFabric2Greige = Convert.ToDouble(txtTotalFabric2.Text);

            //if (!string.IsNullOrEmpty(txtTotalFabric3.Text))
            //    fabricWorking.TotalFabric3Greige = Convert.ToDouble(txtTotalFabric3.Text);

            //if (!string.IsNullOrEmpty(txtTotalFabric4.Text))
            //    fabricWorking.TotalFabric4Greige = Convert.ToDouble(txtTotalFabric4.Text);


            //if (!string.IsNullOrEmpty(txtFinalFabricOrderPlacedFabric1.Text))
            //    fabricWorking.Fabric1FinalOrder = Convert.ToDouble(txtFinalFabricOrderPlacedFabric1.Text);

            //if (!string.IsNullOrEmpty(txtCuttingWastageFabric2.Text))
            //    fabricWorking.Fabric2Wastage = Convert.ToDouble(txtCuttingWastageFabric2.Text);

            //if (!string.IsNullOrEmpty(txtShrinkageFabric2.Text))
            //    fabricWorking.Fabric2Shrinkage = Convert.ToDouble(txtShrinkageFabric2.Text);

            //if (!string.IsNullOrEmpty(txtTotalRequirementGreigeFabric2.Text))
            //    fabricWorking.Fabric2Greige = Convert.ToDouble(txtTotalRequirementGreigeFabric2.Text);

            //if (!string.IsNullOrEmpty(txtFinalFabricOrderPlacedFabric2.Text))
            //    fabricWorking.Fabric2FinalOrder = Convert.ToDouble(txtFinalFabricOrderPlacedFabric2.Text);

            //if (!string.IsNullOrEmpty(txtCuttingWastageFabric3.Text))
            //    fabricWorking.Fabric3Wastage = Convert.ToDouble(txtCuttingWastageFabric3.Text);

            //if (!string.IsNullOrEmpty(txtShrinkageFabric3.Text))
            //    fabricWorking.Fabric3Shrinkage = Convert.ToDouble(txtShrinkageFabric3.Text);

            //if (!string.IsNullOrEmpty(txtTotalRequirementGreigeFabric3.Text))
            //    fabricWorking.Fabric3Greige = Convert.ToDouble(txtTotalRequirementGreigeFabric3.Text);

            //if (!string.IsNullOrEmpty(txtFinalFabricOrderPlacedFabric3.Text))
            //    fabricWorking.Fabric3FinalOrder = Convert.ToDouble(txtFinalFabricOrderPlacedFabric3.Text);

            //if (!string.IsNullOrEmpty(txtCuttingWastageFabric4.Text))
            //    fabricWorking.Fabric4Wastage = Convert.ToDouble(txtCuttingWastageFabric4.Text);

            //if (!string.IsNullOrEmpty(txtShrinkageFabric4.Text))
            //    fabricWorking.Fabric4Shrinkage = Convert.ToDouble(txtShrinkageFabric4.Text);

            //if (!string.IsNullOrEmpty(txtTotalRequirementGreigeFabric4.Text))
            //    fabricWorking.Fabric4Greige = Convert.ToDouble(txtTotalRequirementGreigeFabric4.Text);

            //if (!string.IsNullOrEmpty(txtFinalFabricOrderPlacedFabric4.Text))
            //    fabricWorking.Fabric4FinalOrder = Convert.ToDouble(txtFinalFabricOrderPlacedFabric4.Text);

            //if (!string.IsNullOrEmpty(txtRemarksFabric1.Text))
            //    fabricWorking.Fabric1Remarks = txtRemarksFabric1.Text;

            //if (!string.IsNullOrEmpty(txtRemarksFabric2.Text))
            //    fabricWorking.Fabric2Remarks = txtRemarksFabric2.Text;

            //if (!string.IsNullOrEmpty(txtRemarksFabric3.Text))
            //    fabricWorking.Fabric3Remarks = txtRemarksFabric3.Text;

            //if (!string.IsNullOrEmpty(txtRemarksFabric4.Text))
            //    fabricWorking.Fabric4Remarks = txtRemarksFabric4.Text;

            //if (!string.IsNullOrEmpty(txtFabricRemarks.Text))
            //    fabricWorking.FabricRemarks = txtFabricRemarks.Text;

            ////if (!string.IsNullOrEmpty(txtTotalGreigeFabric.Text))
            ////  fabricWorking.TotalGreigeFabric = Convert.ToDouble(txtTotalGreigeFabric.Text);


            ////if ((ApplicationHelper.LoggedInUser.UserData.Designation == Designation.BIPL_Fabrics_Manager) ||
            ////    (ApplicationHelper.LoggedInUser.UserData.Designation == Designation.BIPL_Fabrics_AssistantEntry) ||
            ////    (ApplicationHelper.LoggedInUser.UserData.Designation == Designation.BIPL_Fabrics_ManagerStore) ||
            ////    (ApplicationHelper.LoggedInUser.UserData.Designation == Designation.BIPL_Fabrics_ManagerProcessing) ||
            ////    (ApplicationHelper.LoggedInUser.UserData.Designation == Designation.BIPL_Fabrics_Assistant))
            ////{
            //fabricWorking.ApprovedByFabricManager = Convert.ToInt32(Convert.ToBoolean(chkboxFabricManager.Checked));
            //fabricWorking.ApprovedByAccountManager = Convert.ToInt32(Convert.ToBoolean(chkboxAccountMgr.Checked));
            //fabricWorking.ApprovedByAccountManagerOn = fabricWorking.ApprovedByAccountManagerOn;
            //if ((chkboxFabricManager.Enabled == true))
            //{
            //    if ((chkboxFabricManager.Checked))
            //    {
            //        fabricWorking.ApprovedByFabricManagerOn = fabricWorking.ApprovedByFabricManager == 1
            //                                                      ? DateTime.Now
            //                                                      : fabricWorking.ApprovedByFabricManagerOn;
            //    }
            //}
            //else
            //{
            //    fabricWorking.ApprovedByFabricManagerOn = fabricWorking1.ApprovedByFabricManagerOn;
            //}

            ////if ((ApplicationHelper.LoggedInUser.UserData.Designation == Designation.BIPL_Merchandising_AccountManager) ||
            ////    (ApplicationHelper.LoggedInUser.UserData.Designation == Designation.BIPL_Merchandising_FitMerchant))
            ////{
            ////fabricWorking.ApprovedByAccountManager = Convert.ToInt32(Convert.ToBoolean(chkboxAccountMgr.Checked));
            ////fabricWorking.ApprovedByFabricManager = fabricWorking1.ApprovedByFabricManager;
            ////fabricWorking.ApprovedByFabricManagerOn = fabricWorking1.ApprovedByFabricManagerOn;
            //if ((chkboxAccountMgr.Enabled == true))
            //{
            //    if ((chkboxAccountMgr.Checked))
            //    {
            //        if (fabricWorking.ApprovedByAccountManager == 1)
            //        {
            //            fabricWorking.ApprovedByAccountManagerOn =DateTime.Now;
            //            //fabricWorking.AvgCheckedOn = DateTime.Now;
            //        }
            //        else
            //        {
            //            fabricWorking1.ApprovedByAccountManagerOn = fabricWorking.ApprovedByAccountManagerOn;
            //            //fabricWorking1.AvgCheckedOn = fabricWorking.AvgCheckedOn;
            //        }
            //    }
            //}
            //else
            //{
            //    fabricWorking.ApprovedByAccountManagerOn = fabricWorking1.ApprovedByAccountManagerOn;
            //    //fabricWorking.AvgCheckedOn = fabricWorking1.AvgCheckedOn;
            //}


            //if (!string.IsNullOrEmpty(txtFabric1InitialWidth.Text))
            //    fabricWorking.Fabric1InitialWidth = Convert.ToDouble(txtFabric1InitialWidth.Text);

            //if (!string.IsNullOrEmpty(txtFabric2InitialWidth.Text))
            //    fabricWorking.Fabric2InitialWidth = Convert.ToDouble(txtFabric2InitialWidth.Text);

            //if (!string.IsNullOrEmpty(txtFabric3InitialWidth.Text))
            //    fabricWorking.Fabric3InitialWidth = Convert.ToDouble(txtFabric3InitialWidth.Text);

            //if (!string.IsNullOrEmpty(txtFabric4InitialWidth.Text))
            //    fabricWorking.Fabric4InitialWidth = Convert.ToDouble(txtFabric4InitialWidth.Text);

            //if (!string.IsNullOrEmpty(txtFabric1UsableWidth.Text))
            //    fabricWorking.Fabric1UsableWidth = Convert.ToDouble(txtFabric1UsableWidth.Text);

            //if (!string.IsNullOrEmpty(txtFabric2UsableWidth.Text))
            //    fabricWorking.Fabric2UsableWidth = Convert.ToDouble(txtFabric2UsableWidth.Text);

            //if (!string.IsNullOrEmpty(txtFabric3UsableWidth.Text))
            //    fabricWorking.Fabric3UsableWidth = Convert.ToDouble(txtFabric3UsableWidth.Text);

            //if (!string.IsNullOrEmpty(txtFabric4UsableWidth.Text))
            //    fabricWorking.Fabric4UsableWidth = Convert.ToDouble(txtFabric4UsableWidth.Text);

            //if (!string.IsNullOrEmpty(txtRemarks.Text))
            //    fabricWorking.AllRemarks = txtRemarks.Text;

            //if (!string.IsNullOrEmpty(Request.Params[ddlAvgUnit1.UniqueID]) &&
            //    Request.Params[ddlAvgUnit1.UniqueID] != "-1")
            //{
            //    fabricWorking.UnitOfAverage1 = Request.Params[ddlAvgUnit1.UniqueID];
            //}

            //if (!string.IsNullOrEmpty(Request.Params[ddlAvgUnit2.UniqueID]) &&
            //    Request.Params[ddlAvgUnit2.UniqueID] != "-1")
            //{
            //    fabricWorking.UnitOfAverage2 = Request.Params[ddlAvgUnit2.UniqueID];
            //}

            //if (!string.IsNullOrEmpty(Request.Params[ddlAvgUnit3.UniqueID]) &&
            //    Request.Params[ddlAvgUnit3.UniqueID] != "-1")
            //{
            //    fabricWorking.UnitOfAverage3 = Request.Params[ddlAvgUnit3.UniqueID];
            //}

            //if (!string.IsNullOrEmpty(Request.Params[ddlAvgUnit4.UniqueID]) &&
            //    Request.Params[ddlAvgUnit4.UniqueID] != "-1")
            //{
            //    fabricWorking.UnitOfAverage4 = Request.Params[ddlAvgUnit4.UniqueID];
            //}

            //fabricWorking.order = new Common.Order { OrderID = OrderId, OrderBreakdown = new List<OrderDetail>() };

            //foreach (RepeaterItem item in repeaterOrderBreakdown.Items)
            //{
            //    var ord = new OrderDetail();
            //    ord.OrderID = OrderId;
            //    ord.OrderDetailID = !String.IsNullOrEmpty(((HiddenField)item.FindControl("hiddenOrderDetailID")).Value)
            //                            ? Convert.ToInt32(((HiddenField)item.FindControl("hiddenOrderDetailID")).Value)
            //                            : 0;
            //    ord.Fabric1Average = !String.IsNullOrEmpty(((TextBox)item.FindControl("txtFabric1Average")).Text)
            //                             ? Convert.ToDouble(((TextBox)item.FindControl("txtFabric1Average")).Text)
            //                             : 0;
            //    ord.Fabric1lblAverage = !String.IsNullOrEmpty(((Label)item.FindControl("lblFabric1Average")).Text)
            //                             ? Convert.ToDouble(((Label)item.FindControl("lblFabric1Average")).Text)
            //                             : 0;
            //    HiddenField hdnIsCutAvg1 = (HiddenField)item.FindControl("hdnIsCutAvg1");
            //    if (hdnIsCutAvg1 != null)
            //    {
            //        ord.IsCutAvg1 = hdnIsCutAvg1.Value;
            //    }

            //    if (ord.IsCutAvg1 == "YES")
            //    {
            //        ord.Fabric1Average = ord.Fabric1lblAverage;
            //    }

            //    ord.Fabric1Quantity = !String.IsNullOrEmpty(((TextBox)item.FindControl("txtFabric1Quantity")).Text)
            //                              ? Convert.ToDouble(((TextBox)item.FindControl("txtFabric1Quantity")).Text)
            //                              : 0;
            //    ord.Fabric2Average = !String.IsNullOrEmpty(((TextBox)item.FindControl("txtFabric2Average")).Text)
            //                             ? Convert.ToDouble(((TextBox)item.FindControl("txtFabric2Average")).Text)
            //                             : 0;

            //    ord.Fabric2lblAverage = !String.IsNullOrEmpty(((Label)item.FindControl("lblFabric2Average")).Text)
            //                           ? Convert.ToDouble(((Label)item.FindControl("lblFabric2Average")).Text)
            //                           : 0;

            //    //if (ord.Fabric2lblAverage != 0.0)
            //    //    ord.Fabric2Average = ord.Fabric2lblAverage;
            //    HiddenField hdnIsCutAvg2 = (HiddenField)item.FindControl("hdnIsCutAvg2");
            //    if (hdnIsCutAvg2 != null)
            //    {
            //        ord.IsCutAvg2 = hdnIsCutAvg2.Value;
            //    }

            //    if (ord.IsCutAvg2 == "YES")
            //    {
            //        ord.Fabric2Average = ord.Fabric2lblAverage;
            //    }


            //    ord.Fabric2Quantity = !String.IsNullOrEmpty(((TextBox)item.FindControl("txtFabric2Quantity")).Text)
            //                              ? Convert.ToDouble(((TextBox)item.FindControl("txtFabric2Quantity")).Text)
            //                              : 0;
            //    ord.Fabric3Average = !String.IsNullOrEmpty(((TextBox)item.FindControl("txtFabric3Average")).Text)
            //                             ? Convert.ToDouble(((TextBox)item.FindControl("txtFabric3Average")).Text)
            //                             : 0;

            //    ord.Fabric3lblAverage = !String.IsNullOrEmpty(((Label)item.FindControl("lblFabric3Average")).Text)
            //                         ? Convert.ToDouble(((Label)item.FindControl("lblFabric3Average")).Text)
            //                         : 0;

            //    //if (ord.Fabric3lblAverage != 0.0)
            //    //    ord.Fabric3Average = ord.Fabric3lblAverage;
            //    HiddenField hdnIsCutAvg3 = (HiddenField)item.FindControl("hdnIsCutAvg3");
            //    if (hdnIsCutAvg3 != null)
            //    {
            //        ord.IsCutAvg3 = hdnIsCutAvg3.Value;
            //    }

            //    if (ord.IsCutAvg3 == "YES")
            //    {
            //        ord.Fabric3Average = ord.Fabric3lblAverage;
            //    }

            //    ord.Fabric3Quantity = !String.IsNullOrEmpty(((TextBox)item.FindControl("txtFabric3Quantity")).Text)
            //                              ? Convert.ToDouble(((TextBox)item.FindControl("txtFabric3Quantity")).Text)
            //                              : 0;
            //    ord.Fabric4Average = !String.IsNullOrEmpty(((TextBox)item.FindControl("txtFabric4Average")).Text)
            //                             ? Convert.ToDouble(((TextBox)item.FindControl("txtFabric4Average")).Text)
            //                             : 0;

            //    ord.Fabric4lblAverage = !String.IsNullOrEmpty(((Label)item.FindControl("lblFabric4Average")).Text)
            //                       ? Convert.ToDouble(((Label)item.FindControl("lblFabric4Average")).Text)
            //                       : 0;
            //    ord.Fabric4Quantity = !String.IsNullOrEmpty(((TextBox)item.FindControl("txtFabric4Quantity")).Text)
            //                              ? Convert.ToDouble(((TextBox)item.FindControl("txtFabric4Quantity")).Text)
            //                              : 0;

            //    //if (ord.Fabric4lblAverage != 0.0)
            //    //    ord.Fabric4Average = ord.Fabric4lblAverage;
            //    HiddenField hdnIsCutAvg4 = (HiddenField)item.FindControl("hdnIsCutAvg4");
            //    if (hdnIsCutAvg4 != null)
            //    {
            //        ord.IsCutAvg4 = hdnIsCutAvg4.Value;
            //    }

            //    if (ord.IsCutAvg4 == "YES")
            //    {
            //        ord.Fabric4Average = ord.Fabric4lblAverage;
            //    }
            //    fabricWorking.order.OrderBreakdown.Add(ord);
            //}


            //fabricWorking.order.StyleID = Convert.ToInt32(hiddenStyleID.Value);
            //fabricWorking.AvgChecked = Convert.ToInt32(Convert.ToBoolean(chkboxAvgChecked.Checked));
            //if ((chkboxAvgChecked.Enabled == true))
            //{
            //    if ((chkboxAvgChecked.Checked))
            //    {
            //        if (fabricWorking.AvgChecked == 1)
            //        {
            //            fabricWorking.AvgCheckedOn = DateTime.Now;
            //        }
            //        else
            //        {
            //            fabricWorking1.AvgCheckedOn = fabricWorking.AvgCheckedOn;
            //        }
            //    }
            //}
            //else
            //{
            //    fabricWorking.AvgCheckedOn = fabricWorking1.AvgCheckedOn;
            //}
            //fabricWorking.AcknowledgmentChecked = Convert.ToInt32(Convert.ToBoolean(chkUcknowledgment.Checked));

            //fabricWorking.ApprovedAcknowledgementManager = Convert.ToInt32(Convert.ToBoolean(chkUcknowledgment.Checked));

            //#region Gajendra 13-04-2016
            //fabricWorking.PrintColorRecdFabric1 = fabricWorking1.PrintColorRecdFabric1;
            //fabricWorking.PrintColorRecdFabric2 = fabricWorking1.PrintColorRecdFabric2;
            //fabricWorking.PrintColorRecdFabric3 = fabricWorking1.PrintColorRecdFabric3;
            //fabricWorking.PrintColorRecdFabric4 = fabricWorking1.PrintColorRecdFabric4;


            //fabricWorking.FabricQualtityAprdFabric1 = fabricWorking1.FabricQualtityAprdFabric1;
            //fabricWorking.FabricQualtityAprdFabric2 = fabricWorking1.FabricQualtityAprdFabric2;
            //fabricWorking.FabricQualtityAprdFabric3 = fabricWorking1.FabricQualtityAprdFabric3;
            //fabricWorking.FabricQualtityAprdFabric4 = fabricWorking1.FabricQualtityAprdFabric4;

            //fabricWorking.IntialAprdFabric1 = fabricWorking1.IntialAprdFabric1;
            //fabricWorking.IntialAprdFabric2 = fabricWorking1.IntialAprdFabric2;
            //fabricWorking.IntialAprdFabric3 = fabricWorking1.IntialAprdFabric3;
            //fabricWorking.IntialAprdFabric4 = fabricWorking1.IntialAprdFabric4;

            //fabricWorking.BulkAprdFabric1 = fabricWorking1.BulkAprdFabric1;
            //fabricWorking.BulkAprdFabric2 = fabricWorking1.BulkAprdFabric2;
            //fabricWorking.BulkAprdFabric3 = fabricWorking1.BulkAprdFabric3;
            //fabricWorking.BulkAprdFabric4 = fabricWorking1.BulkAprdFabric4;
            //#endregion

            //#region Gajendra Commented 13-04-2016
            ////added by abhishek 21/12/2015

            ////fabricWorking.PrintColorRecdFabric1 = chkREFReceived_1.Enabled == true ? (chkREFReceived_1.Checked == true ? 1 : 0) : -1;
            ////fabricWorking.PrintColorRecdFabric2 = chkREFReceived_2.Enabled == true ? (chkREFReceived_2.Checked == true ? 1 : 0) : -1;
            ////fabricWorking.PrintColorRecdFabric3 = chkREFReceived_3.Enabled == true ? (chkREFReceived_3.Checked == true ? 1 : 0) : -1;
            ////fabricWorking.PrintColorRecdFabric4 = chkREFReceived_4.Enabled == true ? (chkREFReceived_4.Checked == true ? 1 : 0) : -1;


            ////fabricWorking.FabricQualtityAprdFabric1 = ddlQtyApvd_1.Enabled == true ? (ddlQtyApvd_1.SelectedValue == "-1" ? -1 : Convert.ToInt32(ddlQtyApvd_1.SelectedValue)) : Convert.ToInt32(ddlQtyApvd_1.SelectedValue);
            ////fabricWorking.FabricQualtityAprdFabric2 = ddlQtyApvd_2.Enabled == true ? (ddlQtyApvd_2.SelectedValue == "-1" ? -1 : Convert.ToInt32(ddlQtyApvd_2.SelectedValue)) : Convert.ToInt32(ddlQtyApvd_2.SelectedValue);
            ////fabricWorking.FabricQualtityAprdFabric3 = ddlQtyApvd_3.Enabled == true ? (ddlQtyApvd_3.SelectedValue == "-1" ? -1 : Convert.ToInt32(ddlQtyApvd_3.SelectedValue)) : Convert.ToInt32(ddlQtyApvd_3.SelectedValue);
            ////fabricWorking.FabricQualtityAprdFabric4 = ddlQtyApvd_4.Enabled == true ? (ddlQtyApvd_4.SelectedValue == "-1" ? -1 : Convert.ToInt32(ddlQtyApvd_4.SelectedValue)) : Convert.ToInt32(ddlQtyApvd_4.SelectedValue);

            ////fabricWorking.IntialAprdFabric1 = ddlinitial_1.Enabled == true ? (ddlinitial_1.SelectedValue == "-1" ? -1 : Convert.ToInt32(ddlinitial_1.SelectedValue)) : Convert.ToInt32(ddlinitial_1.SelectedValue);
            ////fabricWorking.IntialAprdFabric2 = ddlinitial_2.Enabled == true ? (ddlinitial_2.SelectedValue == "-1" ? -1 : Convert.ToInt32(ddlinitial_2.SelectedValue)) : Convert.ToInt32(ddlinitial_2.SelectedValue);
            ////fabricWorking.IntialAprdFabric3 = ddlinitial_3.Enabled == true ? (ddlinitial_3.SelectedValue == "-1" ? -1 : Convert.ToInt32(ddlinitial_3.SelectedValue)) : Convert.ToInt32(ddlinitial_3.SelectedValue);
            ////fabricWorking.IntialAprdFabric4 = ddlinitial_4.Enabled == true ? (ddlinitial_4.SelectedValue == "-1" ? -1 : Convert.ToInt32(ddlinitial_4.SelectedValue)) : Convert.ToInt32(ddlinitial_4.SelectedValue);

            ////fabricWorking.BulkAprdFabric1 = ddlbulkApvd_1.Enabled == true ? (ddlbulkApvd_1.SelectedValue == "-1" ? -1 : Convert.ToInt32(ddlbulkApvd_1.SelectedValue)) : Convert.ToInt32(ddlbulkApvd_1.SelectedValue);
            ////fabricWorking.BulkAprdFabric2 = ddlbulkApvd_2.Enabled == true ? (ddlbulkApvd_2.SelectedValue == "-1" ? -1 : Convert.ToInt32(ddlbulkApvd_2.SelectedValue)) : Convert.ToInt32(ddlbulkApvd_2.SelectedValue);
            ////fabricWorking.BulkAprdFabric3 = ddlbulkApvd_3.Enabled == true ? (ddlbulkApvd_3.SelectedValue == "-1" ? -1 : Convert.ToInt32(ddlbulkApvd_3.SelectedValue)) : Convert.ToInt32(ddlbulkApvd_3.SelectedValue);
            ////fabricWorking.BulkAprdFabric4 = ddlbulkApvd_4.Enabled == true ? (ddlbulkApvd_4.SelectedValue == "-1" ? -1 : Convert.ToInt32(ddlbulkApvd_4.SelectedValue)) : Convert.ToInt32(ddlbulkApvd_4.SelectedValue);


            ////end by abhishek 21/12/2015
            //#endregion

            //if (fabricWorking.AcknowledgmentChecked == 1)
            //{
            //    fabricWorking.ApprovedAcknowledgementManagerOn = DateTime.Now;
            //}

            //if (OrderId == fabricWorking1.order.OrderID)
            //{
            //    differences = ShowDifferences(fabricWorking, fabricWorking1);
            //    if (!String.IsNullOrEmpty(fabricWorking1.History))
            //        fabricWorking.History = fabricWorking1.History + "$$" + differences;
            //    else
            //        fabricWorking.History = differences;
            //    FabricWorkingControllerInstance.UpdateFabricWorking(fabricWorking, DivFabricSection_1.Visible, DivFabricSection_2.Visible, DivFabricSection_3.Visible, DivFabricSection_4.Visible);
            //}
            //else
            //{
            //    differences = ShowDifferences(fabricWorking, fabricWorking1);
            //    fabricWorking.History = differences;
            //    FabricWorkingControllerInstance.InsertFabricWorking(fabricWorking);
            //}


            //pnlForm.Visible = false;
            //pnlMessage.Visible = true;
        }

        private string ShowDifferences(FabricWorking fabricWorking, FabricWorking fabricWorkingOld)
        {
            string differences = "";
            int i = 0;
            NotificationEmailHistory NEH = new NotificationEmailHistory();
            BLL.NotificationController nn = new BLL.NotificationController();
            NEH.Type = "105";
            NEH.EmailID = "14";
            NEH.OrderDetailsID = "0";
            NEH.OrderID = fabricWorking.order.OrderID.ToString();
            #region Gajendra Commented 13-04-2016
            // ==================================Gajendra 18-03-2016==================================================
            // var FabricQualtityAprdFabricOldText_1 = "N/A";
            // var FabricQualtityAprdFabricOldText_2 = "N/A";
            // var FabricQualtityAprdFabricOldText_3 = "N/A";
            // var FabricQualtityAprdFabricOldText_4 = "N/A";

            // fabricWorkingOld.FabricQualtityAprdFabric1 = fabricWorkingOld.FabricQualtityAprdFabric1 == 0 ? -1 : fabricWorkingOld.FabricQualtityAprdFabric1;
            // fabricWorkingOld.FabricQualtityAprdFabric2 = fabricWorkingOld.FabricQualtityAprdFabric2 == 0 ? -1 : fabricWorkingOld.FabricQualtityAprdFabric2;
            // fabricWorkingOld.FabricQualtityAprdFabric3 = fabricWorkingOld.FabricQualtityAprdFabric3 == 0 ? -1 : fabricWorkingOld.FabricQualtityAprdFabric3;
            // fabricWorkingOld.FabricQualtityAprdFabric4 = fabricWorkingOld.FabricQualtityAprdFabric4 == 0 ? -1 : fabricWorkingOld.FabricQualtityAprdFabric4;

            // if (fabricWorkingOld.FabricQualtityAprdFabric1 == 1)
            //     FabricQualtityAprdFabricOldText_1 = "Sent for approval";
            // else if (fabricWorkingOld.FabricQualtityAprdFabric1 == 2)
            //     FabricQualtityAprdFabricOldText_1 = "Approved";
            // else if (fabricWorking.FabricQualtityAprdFabric1 == 3)
            //     FabricQualtityAprdFabricOldText_1 = "Rejected";

            //  if (fabricWorkingOld.FabricQualtityAprdFabric2 == 1)
            //     FabricQualtityAprdFabricOldText_2 = "Sent for approval";
            // else if (fabricWorkingOld.FabricQualtityAprdFabric2 == 2)
            //     FabricQualtityAprdFabricOldText_2 = "Approved";
            // else if (fabricWorking.FabricQualtityAprdFabric2 == 3)
            //     FabricQualtityAprdFabricOldText_2 = "Rejected";

            //  if (fabricWorkingOld.FabricQualtityAprdFabric3 == 1)
            //      FabricQualtityAprdFabricOldText_3 = "Sent for approval";
            //  else if (fabricWorkingOld.FabricQualtityAprdFabric3 == 2)
            //      FabricQualtityAprdFabricOldText_3 = "Approved";
            //  else if (fabricWorking.FabricQualtityAprdFabric3 == 3)
            //      FabricQualtityAprdFabricOldText_3 = "Rejected";


            //  if (fabricWorkingOld.FabricQualtityAprdFabric4 == 1)
            //      FabricQualtityAprdFabricOldText_4 = "Sent for approval";
            //  else if (fabricWorkingOld.FabricQualtityAprdFabric4 == 2)
            //      FabricQualtityAprdFabricOldText_4 = "Approved";
            //  else if (fabricWorking.FabricQualtityAprdFabric1 == 3)
            //      FabricQualtityAprdFabricOldText_4 = "Rejected";

            //  //var QtyApvd_1 = ddlQtyApvd_1.SelectedItem.Text == "Select" ? "N/A" : ddlQtyApvd_1.SelectedItem.Text;
            //  var QtyApvd_2 = ddlQtyApvd_2.SelectedItem.Text == "Select" ? "N/A" : ddlQtyApvd_2.SelectedItem.Text;
            //  var QtyApvd_3 = ddlQtyApvd_3.SelectedItem.Text == "Select" ? "N/A" : ddlQtyApvd_3.SelectedItem.Text;
            //  var QtyApvd_4 = ddlQtyApvd_4.SelectedItem.Text == "Select" ? "N/A" : ddlQtyApvd_4.SelectedItem.Text;

            ////--------------------------------------------I----------------------------------------------------------
            // var IntialAprdFabricOldText_1 = "N/A";
            // var IntialAprdFabricOldText_2 = "N/A";
            // var IntialAprdFabricOldText_3 = "N/A";
            // var IntialAprdFabricOldText_4 = "N/A";

            // fabricWorkingOld.IntialAprdFabric1 = fabricWorkingOld.IntialAprdFabric1 == 0 ? -1 : fabricWorkingOld.IntialAprdFabric1;
            // fabricWorkingOld.IntialAprdFabric2 = fabricWorkingOld.IntialAprdFabric2 == 0 ? -1 : fabricWorkingOld.IntialAprdFabric2;
            // fabricWorkingOld.IntialAprdFabric3 = fabricWorkingOld.IntialAprdFabric3 == 0 ? -1 : fabricWorkingOld.IntialAprdFabric3;
            // fabricWorkingOld.IntialAprdFabric4 = fabricWorkingOld.IntialAprdFabric4 == 0 ? -1 : fabricWorkingOld.IntialAprdFabric4;

            // if (fabricWorkingOld.IntialAprdFabric1 == 1)
            //     IntialAprdFabricOldText_1 = "Sent for approval";
            // else if (fabricWorkingOld.IntialAprdFabric1 == 2)
            //     IntialAprdFabricOldText_1 = "Approved";
            // else if (fabricWorking.IntialAprdFabric1 == 3)
            //     IntialAprdFabricOldText_1 = "Rejected";

            // if (fabricWorkingOld.IntialAprdFabric2 == 1)
            //     IntialAprdFabricOldText_2 = "Sent for approval";
            // else if (fabricWorkingOld.IntialAprdFabric2 == 2)
            //     IntialAprdFabricOldText_2 = "Approved";
            // else if (fabricWorking.IntialAprdFabric2 == 3)
            //     IntialAprdFabricOldText_2 = "Rejected";

            // if (fabricWorkingOld.IntialAprdFabric3 == 1)
            //     IntialAprdFabricOldText_3 = "Sent for approval";
            // else if (fabricWorkingOld.IntialAprdFabric3 == 2)
            //     IntialAprdFabricOldText_3 = "Approved";
            // else if (fabricWorking.IntialAprdFabric3 == 3)
            //     IntialAprdFabricOldText_3 = "Rejected";


            // if (fabricWorkingOld.IntialAprdFabric4 == 1)
            //     IntialAprdFabricOldText_4 = "Sent for approval";
            // else if (fabricWorkingOld.IntialAprdFabric4 == 2)
            //     IntialAprdFabricOldText_4 = "Approved";
            // else if (fabricWorking.IntialAprdFabric1 == 3)
            //     IntialAprdFabricOldText_4 = "Rejected";

            // //var initial_1 = ddlinitial_1.SelectedItem.Text == "Select" ? "N/A" : ddlinitial_1.SelectedItem.Text;
            // var initial_2 = ddlinitial_2.SelectedItem.Text == "Select" ? "N/A" : ddlinitial_2.SelectedItem.Text;
            // var initial_3 = ddlinitial_3.SelectedItem.Text == "Select" ? "N/A" : ddlinitial_3.SelectedItem.Text;
            // var initial_4 = ddlinitial_4.SelectedItem.Text == "Select" ? "N/A" : ddlinitial_4.SelectedItem.Text;
            // //-------------------------------------------B-------------------------------------------------------------

            // var BulkAprdFabricOldText_1 = "N/A";
            // var BulkAprdFabricOldText_2 = "N/A";
            // var BulkAprdFabricOldText_3 = "N/A";
            // var BulkAprdFabricOldText_4 = "N/A";

            // fabricWorkingOld.BulkAprdFabric1 = fabricWorkingOld.BulkAprdFabric1 == 0 ? -1 : fabricWorkingOld.BulkAprdFabric1;
            // fabricWorkingOld.BulkAprdFabric2 = fabricWorkingOld.BulkAprdFabric2 == 0 ? -1 : fabricWorkingOld.BulkAprdFabric2;
            // fabricWorkingOld.BulkAprdFabric3 = fabricWorkingOld.BulkAprdFabric3 == 0 ? -1 : fabricWorkingOld.BulkAprdFabric3;
            // fabricWorkingOld.BulkAprdFabric4 = fabricWorkingOld.BulkAprdFabric4 == 0 ? -1 : fabricWorkingOld.BulkAprdFabric4;

            // if (fabricWorkingOld.BulkAprdFabric1 == 1)
            //     BulkAprdFabricOldText_1 = "Sent for approval";
            // else if (fabricWorkingOld.BulkAprdFabric1 == 2)
            //     BulkAprdFabricOldText_1 = "Approved";
            // else if (fabricWorking.BulkAprdFabric1 == 3)
            //     BulkAprdFabricOldText_1 = "Rejected";

            // if (fabricWorkingOld.BulkAprdFabric2 == 1)
            //     BulkAprdFabricOldText_2 = "Sent for approval";
            // else if (fabricWorkingOld.BulkAprdFabric2 == 2)
            //     BulkAprdFabricOldText_2 = "Approved";
            // else if (fabricWorking.BulkAprdFabric2 == 3)
            //     BulkAprdFabricOldText_2 = "Rejected";

            // if (fabricWorkingOld.BulkAprdFabric3 == 1)
            //     BulkAprdFabricOldText_3 = "Sent for approval";
            // else if (fabricWorkingOld.BulkAprdFabric3 == 2)
            //     BulkAprdFabricOldText_3 = "Approved";
            // else if (fabricWorking.BulkAprdFabric3 == 3)
            //     BulkAprdFabricOldText_3 = "Rejected";


            // if (fabricWorkingOld.BulkAprdFabric4 == 1)
            //     BulkAprdFabricOldText_4 = "Sent for approval";
            // else if (fabricWorkingOld.BulkAprdFabric4 == 2)
            //     BulkAprdFabricOldText_4 = "Approved";
            // else if (fabricWorking.BulkAprdFabric1 == 3)
            //     BulkAprdFabricOldText_4 = "Rejected";

            // //var bulkApvd_1 = ddlbulkApvd_1.SelectedItem.Text == "Select" ? "N/A" : ddlbulkApvd_1.SelectedItem.Text;
            // var bulkApvd_2 = ddlbulkApvd_2.SelectedItem.Text == "Select" ? "N/A" : ddlbulkApvd_2.SelectedItem.Text;
            // var bulkApvd_3 = ddlbulkApvd_3.SelectedItem.Text == "Select" ? "N/A" : ddlbulkApvd_3.SelectedItem.Text;
            // var bulkApvd_4 = ddlbulkApvd_4.SelectedItem.Text == "Select" ? "N/A" : ddlbulkApvd_4.SelectedItem.Text;

            // //---------------------------------------------F-------------------------------------------------------------

            // if (fabricWorking.FabricQualtityAprdFabric1 != fabricWorkingOld.FabricQualtityAprdFabric1)
            // {
            //     differences += "$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " +
            //                    "Fabric1 for Fabric Qlty Aprd changed by " +
            //                    ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " +
            //                   QtyApvd_1 + " was " + FabricQualtityAprdFabricOldText_1;
            // }
            // if (fabricWorking.FabricQualtityAprdFabric2 != fabricWorkingOld.FabricQualtityAprdFabric2)
            // {
            //     differences += "$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " +
            //                    "Fabric2 for Fabric Qlty Aprd changed by " +
            //                    ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " +
            //                   QtyApvd_2 + " was " + FabricQualtityAprdFabricOldText_2;
            // }
            // if (fabricWorking.FabricQualtityAprdFabric3 != fabricWorkingOld.FabricQualtityAprdFabric3)
            // {
            //     differences += "$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " +
            //                    "Fabric3 for Fabric Qlty Aprd changed by " +
            //                    ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " +
            //                    QtyApvd_3 + " was " + FabricQualtityAprdFabricOldText_3;
            // }
            // if (fabricWorking.FabricQualtityAprdFabric4 != fabricWorkingOld.FabricQualtityAprdFabric4)
            // {
            //     differences += "$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " +
            //                    "Fabric4 for Fabric Qlty Aprd changed by " +
            //                    ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " +
            //                    QtyApvd_4 + " was " + FabricQualtityAprdFabricOldText_4;
            // }
            // //------------------------------------------------------I--------------------------------------------------------------------------------------------------
            // if (fabricWorking.IntialAprdFabric1 != fabricWorkingOld.IntialAprdFabric1)
            // {
            //     differences += "$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " +
            //                    "Fabric1 for Initial Aprd changed by " +
            //                    ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " +
            //                   initial_1 + " was " + IntialAprdFabricOldText_1;
            // }
            // if (fabricWorking.IntialAprdFabric2 != fabricWorkingOld.IntialAprdFabric2)
            // {
            //     differences += "$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " +
            //                    "Fabric2 for Initial Aprd changed by " +
            //                    ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " +
            //                    initial_2 + " was " + IntialAprdFabricOldText_2;
            // }
            // if (fabricWorking.IntialAprdFabric3 != fabricWorkingOld.IntialAprdFabric3)
            // {
            //     differences += "$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " +
            //                    "Fabric3 for Initial Aprd changed by " +
            //                    ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " +
            //                    initial_3 + " was " + IntialAprdFabricOldText_3;
            // }
            // if (fabricWorking.IntialAprdFabric4 != fabricWorkingOld.IntialAprdFabric4)
            // {
            //     differences += "$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " +
            //                    "Fabric4 for Initial Aprd changed by " +
            //                    ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " +
            //                    initial_4 + " was " + IntialAprdFabricOldText_4;
            // }
            // //------------------------------------------------------B-------------------------------------------------------------------------------------------------

            // if (fabricWorking.BulkAprdFabric1 != fabricWorkingOld.BulkAprdFabric1)
            // {
            //     differences += "$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " +
            //                    "Fabric1 for Bulk Aprd changed by " +
            //                    ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " +
            //                   bulkApvd_1 + " was " + BulkAprdFabricOldText_1;
            // }
            // if (fabricWorking.BulkAprdFabric2 != fabricWorkingOld.BulkAprdFabric2)
            // {
            //     differences += "$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " +
            //                    "Fabric2 for Bulk Aprd changed by " +
            //                    ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " +
            //                    bulkApvd_2 + " was " + BulkAprdFabricOldText_2;
            // }
            // if (fabricWorking.BulkAprdFabric3 != fabricWorkingOld.BulkAprdFabric3)
            // {
            //     differences += "$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " +
            //                    "Fabric3 for Bulk Aprd changed by " +
            //                    ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " +
            //                    bulkApvd_3 + " was " + BulkAprdFabricOldText_3;
            // }
            // if (fabricWorking.BulkAprdFabric4 != fabricWorkingOld.BulkAprdFabric4)
            // {
            //     differences += "$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " +
            //                    "Fabric4 for Bulk Aprd changed by " +
            //                    ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " +
            //                    bulkApvd_4 + " was " + BulkAprdFabricOldText_4;
            // }

            // =================================END By Gajendra===================================================
            #endregion

            if (fabricWorking.Fabric1InitialWidth != fabricWorkingOld.Fabric1InitialWidth)
            {
                differences += "$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " +
                               "Fabric1 initial width changed by " +
                               ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " +
                               fabricWorking.Fabric1InitialWidth + " was " + fabricWorkingOld.Fabric1InitialWidth;

                NEH.Remarks = DateTime.Now.ToString("dd MMM yy (ddd)") + ": <b>" + lblSerial.Text + " " + lblStyleNumber.Text + "</b> <b>Fabric1 initial</b> width changed by <b>" +
                               ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " +
                               fabricWorking.Fabric1InitialWidth + "</b> was <b>" + fabricWorkingOld.Fabric1InitialWidth + "</b>";

                this.NotificationControllerInstance.NotificationEmailHistory_Ins(NEH);
            }

            if (fabricWorking.Fabric2InitialWidth != fabricWorkingOld.Fabric2InitialWidth)
            {
                differences += "$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " +
                               "Fabric2 initial width changed by " +
                               ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " +
                               fabricWorking.Fabric2InitialWidth + " was " + fabricWorkingOld.Fabric2InitialWidth;

                NEH.Remarks = DateTime.Now.ToString("dd MMM yy (ddd)") + ": <b>" + lblSerial.Text + " " + lblStyleNumber.Text + "</b> <b>Fabric2 initial width</b> changed by <b>" +
                               ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " +
                               fabricWorking.Fabric2InitialWidth + "</b> was <b>" + fabricWorkingOld.Fabric2InitialWidth + "</b>";

                this.NotificationControllerInstance.NotificationEmailHistory_Ins(NEH);
            }

            if (fabricWorking.Fabric3InitialWidth != fabricWorkingOld.Fabric3InitialWidth)
            {
                differences += "$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " +
                               "Fabric3 initial width changed by " +
                               ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " +
                               fabricWorking.Fabric3InitialWidth + " was " + fabricWorkingOld.Fabric3InitialWidth;

                NEH.Remarks = DateTime.Now.ToString("dd MMM yy (ddd)") + ": <b>" + lblSerial.Text + " " + lblStyleNumber.Text + "</b> <b>Fabric3 initial width</b> changed by <b>" +
                              ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " +
                              fabricWorking.Fabric3InitialWidth + "</b> was <b>" + fabricWorkingOld.Fabric3InitialWidth + "</b>";

                this.NotificationControllerInstance.NotificationEmailHistory_Ins(NEH);
            }

            if (fabricWorking.Fabric4InitialWidth != fabricWorkingOld.Fabric4InitialWidth)
            {
                differences += "$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " +
                               "Fabric4 initial width changed by " +
                               ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " +
                               fabricWorking.Fabric4InitialWidth + " was " + fabricWorkingOld.Fabric4InitialWidth;


                NEH.Remarks = DateTime.Now.ToString("dd MMM yy (ddd)") + ": <b>" + lblSerial.Text + " " + lblStyleNumber.Text + "</b> <b>Fabric4 initial width</b> changed by <b>" +
                              ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " +
                              fabricWorking.Fabric4InitialWidth + "</b> was <b>" + fabricWorkingOld.Fabric4InitialWidth + "</b>";
                this.NotificationControllerInstance.NotificationEmailHistory_Ins(NEH);
            }

            if (fabricWorking.Fabric1UsableWidth != fabricWorkingOld.Fabric1UsableWidth)
            {
                differences += "$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " +
                               "Fabric1 usable width changed by " +
                               ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " +
                               fabricWorking.Fabric1UsableWidth + " was " + fabricWorkingOld.Fabric1UsableWidth;

                NEH.Remarks = DateTime.Now.ToString("dd MMM yy (ddd)") + ": <b>" + lblSerial.Text + " " + lblStyleNumber.Text + "</b> <b>Fabric1 Usable Width</b> changed by <b>" +
                              ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " +
                              fabricWorking.Fabric1UsableWidth + "</b> was <b>" + fabricWorkingOld.Fabric1UsableWidth + "</b>";

                this.NotificationControllerInstance.NotificationEmailHistory_Ins(NEH);
            }

            if (fabricWorking.Fabric2UsableWidth != fabricWorkingOld.Fabric2UsableWidth)
            {
                differences += "$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " +
                               "Fabric2 usable width changed by " +
                               ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " +
                               fabricWorking.Fabric2UsableWidth + " was " + fabricWorkingOld.Fabric2UsableWidth;

                NEH.Remarks = DateTime.Now.ToString("dd MMM yy (ddd)") + ": <b>" + lblSerial.Text + " " + lblStyleNumber.Text + "</b> <b>Fabric2 Usable Width</b> changed by <b>" +
                              ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " +
                              fabricWorking.Fabric2UsableWidth + "</b> was <b>" + fabricWorkingOld.Fabric2UsableWidth + "</b>";

                this.NotificationControllerInstance.NotificationEmailHistory_Ins(NEH);
            }

            if (fabricWorking.Fabric3UsableWidth != fabricWorkingOld.Fabric3UsableWidth)
            {
                differences += "$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " +
                               "Fabric3 usable width changed by " +
                               ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " +
                               fabricWorking.Fabric3UsableWidth + " was " + fabricWorkingOld.Fabric3UsableWidth;

                NEH.Remarks = DateTime.Now.ToString("dd MMM yy (ddd)") + ": <b>" + lblSerial.Text + " " + lblStyleNumber.Text + "</b> <b>Fabric3 Usable Width</b> changed by <b>" +
                              ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " +
                              fabricWorking.Fabric3UsableWidth + "</b> was <b>" + fabricWorkingOld.Fabric3UsableWidth + "</b>";

                this.NotificationControllerInstance.NotificationEmailHistory_Ins(NEH);
            }

            if (fabricWorking.Fabric4UsableWidth != fabricWorkingOld.Fabric4UsableWidth)
            {
                differences += "$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " +
                               "Fabric4 usable width changed by " +
                               ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " +
                               fabricWorking.Fabric4UsableWidth + " was " + fabricWorkingOld.Fabric4UsableWidth;


                NEH.Remarks = DateTime.Now.ToString("dd MMM yy (ddd)") + ": <b>" + lblSerial.Text + " " + lblStyleNumber.Text + "</b> <b>Fabric4 Usable Width</b> changed by <b>" +
                             ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " +
                             fabricWorking.Fabric4UsableWidth + "</b> was <b>" + fabricWorkingOld.Fabric4UsableWidth + "</b>";

                this.NotificationControllerInstance.NotificationEmailHistory_Ins(NEH);
            }

            if (!String.IsNullOrEmpty(fabricWorking.FabricRemarks) && !String.IsNullOrEmpty(fabricWorkingOld.FabricRemarks))
                fabricWorking.FabricRemarks = String.IsNullOrEmpty(fabricWorking.FabricRemarks) == true ? "" : fabricWorking.FabricRemarks;
            fabricWorkingOld.FabricRemarks = String.IsNullOrEmpty(fabricWorkingOld.FabricRemarks) == true ? "" : fabricWorkingOld.FabricRemarks;


            if (fabricWorking.FabricRemarks != fabricWorkingOld.FabricRemarks)
            {
                differences += "$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " +
                               "Merchandising Remarks changed by " +
                               ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " +
                               fabricWorking.FabricRemarks + " was " + fabricWorkingOld.FabricRemarks;


                NEH.Remarks = DateTime.Now.ToString("dd MMM yy (ddd)") + ": <b>" + lblSerial.Text + " " + lblStyleNumber.Text + "</b> <b>Merchandising Remarks<b> changed by <b>" +
                         ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " +
                         fabricWorking.FabricRemarks + "</b> was <b>" + fabricWorkingOld.FabricRemarks + "</b>";

                this.NotificationControllerInstance.NotificationEmailHistory_Ins(NEH);
            }

            if (fabricWorking.Fabric1Wastage != fabricWorkingOld.Fabric1Wastage)
            {
                differences += "$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " +
                               "Fabric1 Cutting Wastage(%) changed by " +
                               ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " +
                               fabricWorking.Fabric1Wastage + "%" + " was " + fabricWorkingOld.Fabric1Wastage + "%";

                NEH.Remarks = DateTime.Now.ToString("dd MMM yy (ddd)") + ": <b>" + lblSerial.Text + " " + lblStyleNumber.Text + "</b> <b>Fabric1 Wastage</b> changed by <b>" +
                            ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " +
                            fabricWorking.Fabric1Wastage + "</b> was <b>" + fabricWorkingOld.Fabric1Wastage + "</b>";

                this.NotificationControllerInstance.NotificationEmailHistory_Ins(NEH);
            }

            if (fabricWorking.Fabric2Wastage != fabricWorkingOld.Fabric2Wastage)
            {
                differences += "$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " +
                               "Fabric2 Cutting Wastage(%) changed by " +
                               ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " +
                               fabricWorking.Fabric2Wastage + "%" + " was " + fabricWorkingOld.Fabric2Wastage + "%";

                NEH.Remarks = DateTime.Now.ToString("dd MMM yy (ddd)") + ": <b>" + lblSerial.Text + " " + lblStyleNumber.Text + "</b> <b>Fabric2 Wastage</b> changed by <b>" +
                            ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " +
                            fabricWorking.Fabric2Wastage + "</b> was <b>" + fabricWorkingOld.Fabric2Wastage + "</b>";

                this.NotificationControllerInstance.NotificationEmailHistory_Ins(NEH);
            }

            if (fabricWorking.Fabric3Wastage != fabricWorkingOld.Fabric3Wastage)
            {
                differences += "$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " +
                               "Fabric3 Cutting Wastage(%) changed by " +
                               ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " +
                               fabricWorking.Fabric3Wastage + "%" + " was " + fabricWorkingOld.Fabric3Wastage + "%";

                NEH.Remarks = DateTime.Now.ToString("dd MMM yy (ddd)") + ": <b>" + lblSerial.Text + " " + lblStyleNumber.Text + "</b> <b>Fabric3 Wastage</b> changed by <b>" +
                           ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " +
                           fabricWorking.Fabric3Wastage + "</b> was <b>" + fabricWorkingOld.Fabric3Wastage + "</b>";

                this.NotificationControllerInstance.NotificationEmailHistory_Ins(NEH);
            }

            if (fabricWorking.Fabric4Wastage != fabricWorkingOld.Fabric4Wastage)
            {
                differences += "$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " +
                               "Fabric4 Cutting Wastage(%) changed by " +
                               ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " +
                               fabricWorking.Fabric4Wastage + "%" + " was " + fabricWorkingOld.Fabric4Wastage + "%";

                NEH.Remarks = DateTime.Now.ToString("dd MMM yy (ddd)") + ": <b>" + lblSerial.Text + " " + lblStyleNumber.Text + "</b> <b>Fabric4 Wastage</b> changed by <b>" +
                           ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " +
                           fabricWorking.Fabric4Wastage + "</b> was <b>" + fabricWorkingOld.Fabric4Wastage + "</b>";

                this.NotificationControllerInstance.NotificationEmailHistory_Ins(NEH);
            }

            if (fabricWorking.Fabric1Shrinkage != fabricWorkingOld.Fabric1Shrinkage)
            {
                differences += "$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " +
                               "Fabric1 Shrinkage(%) changed by " +
                               ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " +
                               fabricWorking.Fabric1Shrinkage + "%" + " was " + fabricWorkingOld.Fabric1Shrinkage + "%";

                NEH.Remarks = DateTime.Now.ToString("dd MMM yy (ddd)") + ": <b>" + lblSerial.Text + " " + lblStyleNumber.Text + "</b> <b>Fabric1 Shrinkage</b> changed by <b>" +
                           ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " +
                           fabricWorking.Fabric1Shrinkage + "</b> was <b>" + fabricWorkingOld.Fabric1Shrinkage + "</b>";

                this.NotificationControllerInstance.NotificationEmailHistory_Ins(NEH);
            }

            if (fabricWorking.Fabric2Shrinkage != fabricWorkingOld.Fabric2Shrinkage)
            {
                differences += "$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " +
                               "Fabric2 Shrinkage(%) changed by " +
                               ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " +
                               fabricWorking.Fabric2Shrinkage + "%" + " was " + fabricWorkingOld.Fabric2Shrinkage + "%";

                NEH.Remarks = DateTime.Now.ToString("dd MMM yy (ddd)") + ": <b>" + lblSerial.Text + " " + lblStyleNumber.Text + "</b> <b>Fabric2 Shrinkage</b> changed by <b>" +
                           ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " +
                           fabricWorking.Fabric2Shrinkage + "</b> was <b>" + fabricWorkingOld.Fabric2Shrinkage + "</b>";

                this.NotificationControllerInstance.NotificationEmailHistory_Ins(NEH);
            }

            if (fabricWorking.Fabric3Shrinkage != fabricWorkingOld.Fabric3Shrinkage)
            {
                differences += "$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " +
                               "Fabric3 Shrinkage(%) changed by " +
                               ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " +
                               fabricWorking.Fabric3Shrinkage + "%" + " was " + fabricWorkingOld.Fabric3Shrinkage + "%";

                NEH.Remarks = DateTime.Now.ToString("dd MMM yy (ddd)") + ": <b>" + lblSerial.Text + " " + lblStyleNumber.Text + "</b> <b>Fabric3 Shrinkage</b> changed by <b>" +
                           ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " +
                           fabricWorking.Fabric3Shrinkage + "</b> was <b>" + fabricWorkingOld.Fabric3Shrinkage + "</b>";

                this.NotificationControllerInstance.NotificationEmailHistory_Ins(NEH);
            }

            if (fabricWorking.Fabric4Shrinkage != fabricWorkingOld.Fabric4Shrinkage)
            {
                differences += "$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " +
                               "Fabric4 Shrinkage(%) changed by " +
                               ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " +
                               fabricWorking.Fabric4Shrinkage + "%" + " was " + fabricWorkingOld.Fabric4Shrinkage + "%";

                NEH.Remarks = DateTime.Now.ToString("dd MMM yy (ddd)") + ": <b>" + lblSerial.Text + " " + lblStyleNumber.Text + "</b> <b>Fabric4 Shrinkage</b> changed by <b>" +
                          ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " +
                          fabricWorking.Fabric4Shrinkage + "</b> was <b>" + fabricWorkingOld.Fabric4Shrinkage + "</b>";

                this.NotificationControllerInstance.NotificationEmailHistory_Ins(NEH);

            }

            if (fabricWorking.Fabric1Greige != fabricWorkingOld.Fabric1Greige)
            {
                differences += "$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " +
                               "Fabric1 Total Requirement Greige changed by " +
                               ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " +
                               fabricWorking.Fabric1Greige + " was " + fabricWorkingOld.Fabric1Greige;

                NEH.Remarks = DateTime.Now.ToString("dd MMM yy (ddd)") + ": <b>" + lblSerial.Text + " " + lblStyleNumber.Text + "</b> <b>Fabric1 Greige</b> changed by <b>" +
                          ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " +
                          fabricWorking.Fabric1Greige + "</b> was <b>" + fabricWorkingOld.Fabric1Greige + "</b>";

                this.NotificationControllerInstance.NotificationEmailHistory_Ins(NEH);
            }

            if (fabricWorking.Fabric2Greige != fabricWorkingOld.Fabric2Greige)
            {
                differences += "$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " +
                               "Fabric2 Total Requirement Greige changed by " +
                               ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " +
                               fabricWorking.Fabric2Greige + " was " + fabricWorkingOld.Fabric2Greige;

                NEH.Remarks = DateTime.Now.ToString("dd MMM yy (ddd)") + ": <b>" + lblSerial.Text + " " + lblStyleNumber.Text + "</b> <b>Fabric2 Greige</b> changed by <b>" +
                          ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " +
                          fabricWorking.Fabric2Greige + "</b> was <b>" + fabricWorkingOld.Fabric2Greige + "</b>";

                this.NotificationControllerInstance.NotificationEmailHistory_Ins(NEH);
            }

            if (fabricWorking.Fabric3Greige != fabricWorkingOld.Fabric3Greige)
            {
                differences += "$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " +
                               "Fabric3 Total Requirement Greige changed by " +
                               ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " +
                               fabricWorking.Fabric3Greige + " was " + fabricWorkingOld.Fabric3Greige;


                NEH.Remarks = DateTime.Now.ToString("dd MMM yy (ddd)") + ": <b>" + lblSerial.Text + " " + lblStyleNumber.Text + "</b> <b>Fabric3 Greige</b> changed by <b>" +
                          ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " +
                          fabricWorking.Fabric3Greige + "</b> was <b>" + fabricWorkingOld.Fabric3Greige + "</b>";

                this.NotificationControllerInstance.NotificationEmailHistory_Ins(NEH);
            }

            if (fabricWorking.Fabric4Greige != fabricWorkingOld.Fabric4Greige)
            {
                differences += "$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " +
                               "Fabric4 Total Requirement Greige changed by " +
                               ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " +
                               fabricWorking.Fabric4Greige + " was " + fabricWorkingOld.Fabric4Greige;

                NEH.Remarks = DateTime.Now.ToString("dd MMM yy (ddd)") + ": <b>" + lblSerial.Text + " " + lblStyleNumber.Text + "</b> <b>Fabric4 Greige</b> changed by <b>" +
                         ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " +
                         fabricWorking.Fabric4Greige + "</b> was <b>" + fabricWorkingOld.Fabric4Greige + "</b>";

                this.NotificationControllerInstance.NotificationEmailHistory_Ins(NEH);
            }

            if (fabricWorking.Fabric1FinalOrder != fabricWorkingOld.Fabric1FinalOrder)
            {
                differences += "$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " +
                               "Fabric1 Final Order Placed changed by " +
                               ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " +
                               fabricWorking.Fabric1FinalOrder + " was " + fabricWorkingOld.Fabric1FinalOrder;

                NEH.Remarks = DateTime.Now.ToString("dd MMM yy (ddd)") + ": <b>" + lblSerial.Text + " " + lblStyleNumber.Text + "</b> <b>Fabric1 Final Order Placed</b> changed by <b>" +
                        ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " +
                        fabricWorking.Fabric2FinalOrder + "</b> was <b>" + fabricWorkingOld.Fabric2FinalOrder + "</b>";

                this.NotificationControllerInstance.NotificationEmailHistory_Ins(NEH);
            }

            if (fabricWorking.Fabric2FinalOrder != fabricWorkingOld.Fabric2FinalOrder)
            {
                differences += "$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " +
                               "Fabric2 Final Order Placed changed by " +
                               ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " +
                               fabricWorking.Fabric2FinalOrder + " was " + fabricWorkingOld.Fabric2FinalOrder;


                NEH.Remarks = DateTime.Now.ToString("dd MMM yy (ddd)") + ": <b>" + lblSerial.Text + " " + lblStyleNumber.Text + "</b> <b>Fabric2 Final Order Placed</b> changed by <b>" +
                        ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " +
                        fabricWorking.Fabric2FinalOrder + "</b> was <b>" + fabricWorkingOld.Fabric2FinalOrder + "</b>";

                this.NotificationControllerInstance.NotificationEmailHistory_Ins(NEH);
            }

            if (fabricWorking.Fabric3FinalOrder != fabricWorkingOld.Fabric3FinalOrder)
            {
                differences += "$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " +
                               "Fabric3 Final Order Placed changed by " +
                               ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " +
                               fabricWorking.Fabric3FinalOrder + " was " + fabricWorkingOld.Fabric3FinalOrder;

                NEH.Remarks = DateTime.Now.ToString("dd MMM yy (ddd)") + ": <b>" + lblSerial.Text + " " + lblStyleNumber.Text + "</b> <b>Fabric3 Final Order Placed</b> changed by <b>" +
                        ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " +
                        fabricWorking.Fabric3FinalOrder + "</b> was <b>" + fabricWorkingOld.Fabric3FinalOrder + "</b>";

                this.NotificationControllerInstance.NotificationEmailHistory_Ins(NEH);
            }

            if (fabricWorking.Fabric4FinalOrder != fabricWorkingOld.Fabric4FinalOrder)
            {
                differences += "$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " +
                               "Fabric4 Final Order Placed changed by " +
                               ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " +
                               fabricWorking.Fabric4FinalOrder + " was " + fabricWorkingOld.Fabric4FinalOrder;

                NEH.Remarks = DateTime.Now.ToString("dd MMM yy (ddd)") + ": <b>" + lblSerial.Text + " " + lblStyleNumber.Text + "</b> <b>Fabric4 Final Order Placed</b> changed by <b>" +
                       ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " +
                       fabricWorking.Fabric4FinalOrder + "</b> was <b>" + fabricWorkingOld.Fabric4FinalOrder + "</b>";

                this.NotificationControllerInstance.NotificationEmailHistory_Ins(NEH);
            }

            if (fabricWorking.UnitOfAverage1 != null && fabricWorkingOld.UnitOfAverage1 != null)
            {
                if (fabricWorking.UnitOfAverage1 != fabricWorkingOld.UnitOfAverage1)
                {
                    if (fabricWorking.UnitOfAverage1 == "1")
                    {
                        differences += "$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " +
                                       "Fabric1 Unit Of Average changed by " +
                                       ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " KG was MTRS";

                        NEH.Remarks = DateTime.Now.ToString("dd MMM yy (ddd)") + ": <b>" + lblSerial.Text + " " + lblStyleNumber.Text + "</b> <b>Fabric1 Unit Of Average</b> changed by <b>" +
                       "<b>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + "</b>" + " KG was MTRS";


                        this.NotificationControllerInstance.NotificationEmailHistory_Ins(NEH);
                    }
                    else if (fabricWorking.UnitOfAverage1 == "2")
                    {
                        differences += "$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " +
                                       "Fabric1 Unit Of Average changed by " +
                                       ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " MTRS was KG";

                        NEH.Remarks = DateTime.Now.ToString("dd MMM yy (ddd)") + ": <b>" + lblSerial.Text + " " + lblStyleNumber.Text + "</b> <b>Fabric1 Unit Of Average</b> changed by <b>" +
                      "<b>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + "</b>" + "  MTRS was KG";


                        this.NotificationControllerInstance.NotificationEmailHistory_Ins(NEH);
                    }
                    else if (fabricWorking.UnitOfAverage1 != "-1" && fabricWorkingOld.UnitOfAverage1 == "-1")
                    {
                        if (fabricWorking.UnitOfAverage1 == "1")
                        {
                            differences += "$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " +
                                           "Fabric1 Unit Of Average changed by " +
                                           ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " KG was ...";

                            NEH.Remarks = DateTime.Now.ToString("dd MMM yy (ddd)") + ": <b>" + lblSerial.Text + " " + lblStyleNumber.Text + "</b> <b>Fabric1 Unit Of Average</b> changed by <b>" +
                     "<b>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + "</b>" + " KG was ...";


                            this.NotificationControllerInstance.NotificationEmailHistory_Ins(NEH);
                        }
                        else
                        {
                            differences += "$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " +
                                           "Fabric1 Unit Of Average changed by " +
                                           ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " MTRS was ...";

                            NEH.Remarks = DateTime.Now.ToString("dd MMM yy (ddd)") + ": <b>" + lblSerial.Text + " " + lblStyleNumber.Text + "</b> <b>Fabric1 Unit Of Average</b> changed by <b>" +
                   "<b>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + "</b>" + " MTRS was ...";


                            this.NotificationControllerInstance.NotificationEmailHistory_Ins(NEH);
                        }
                    }
                    else if (fabricWorking.UnitOfAverage1 == "-1" && fabricWorkingOld.UnitOfAverage1 != "-1")
                    {
                        if (fabricWorkingOld.UnitOfAverage1 == "1")
                        {
                            differences += "$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " +
                                           "Fabric1 Unit Of Average changed by " +
                                           ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " ... was KG";


                            NEH.Remarks = DateTime.Now.ToString("dd MMM yy (ddd)") + ": <b>" + lblSerial.Text + " " + lblStyleNumber.Text + "</b> <b>Fabric1 Unit Of Average</b> changed by <b>" +
                  "<b>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + "</b>" + " ... was KG";


                            this.NotificationControllerInstance.NotificationEmailHistory_Ins(NEH);
                        }
                        else
                        {
                            differences += "$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " +
                                           "Fabric1 Unit Of Average changed by " +
                                           ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " ... was MTRS";

                            NEH.Remarks = DateTime.Now.ToString("dd MMM yy (ddd)") + ": <b>" + lblSerial.Text + " " + lblStyleNumber.Text + "</b> <b>Fabric1 Unit Of Average</b> changed by <b>" +
                 "<b>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + "</b>" + " ... was MTRS";


                            this.NotificationControllerInstance.NotificationEmailHistory_Ins(NEH);
                        }
                    }
                    else if (fabricWorking.UnitOfAverage1 == "-1" && fabricWorkingOld.UnitOfAverage1 == "-1")
                    {
                    }
                }
                else if (fabricWorking.UnitOfAverage1 == "-1" && fabricWorkingOld.UnitOfAverage1 == "-1")
                {
                }
            }

            if (fabricWorking.UnitOfAverage2 != null && fabricWorkingOld.UnitOfAverage2 != null)
            {
                if (fabricWorking.UnitOfAverage2 != fabricWorkingOld.UnitOfAverage2)
                {
                    if (fabricWorking.UnitOfAverage2 == "1")
                    {
                        differences += "$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " +
                                       "Fabric2 Unit Of Average changed by " +
                                       ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " KG was MTRS";


                        NEH.Remarks = DateTime.Now.ToString("dd MMM yy (ddd)") + ": <b>" + lblSerial.Text + " " + lblStyleNumber.Text + "</b> <b>Fabric2 Unit Of Average</b> changed by <b>" +
                "<b>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + "</b>" + " KG was MTRS";


                        this.NotificationControllerInstance.NotificationEmailHistory_Ins(NEH);

                    }
                    else if (fabricWorking.UnitOfAverage2 == "2")
                    {
                        differences += "$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " +
                                       "Fabric2 Unit Of Average changed by " +
                                       ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " MTRS was KG";


                        NEH.Remarks = DateTime.Now.ToString("dd MMM yy (ddd)") + ": <b>" + lblSerial.Text + " " + lblStyleNumber.Text + "</b> <b>Fabric2 Unit Of Average</b> changed by <b>" +
               "<b>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + "</b>" + " MTRS was KG";


                        this.NotificationControllerInstance.NotificationEmailHistory_Ins(NEH);
                    }
                    else if (fabricWorking.UnitOfAverage2 != "-1" && fabricWorkingOld.UnitOfAverage2 == "-1")
                    {
                        if (fabricWorking.UnitOfAverage2 == "1")
                        {
                            differences += "$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " +
                                           "Fabric2 Unit Of Average changed by " +
                                           ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " KG was ...";

                            NEH.Remarks = DateTime.Now.ToString("dd MMM yy (ddd)") + ": <b>" + lblSerial.Text + " " + lblStyleNumber.Text + "</b> <b>Fabric2 Unit Of Average</b> changed by <b>" +
              "<b>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + "</b>" + " KG was ...";


                            this.NotificationControllerInstance.NotificationEmailHistory_Ins(NEH);
                        }
                        else
                        {
                            differences += "$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " +
                                           "Fabric2 Unit Of Average changed by " +
                                           ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " MTRS was ...";

                            NEH.Remarks = DateTime.Now.ToString("dd MMM yy (ddd)") + ": <b>" + lblSerial.Text + " " + lblStyleNumber.Text + "</b> <b>Fabric2 Unit Of Average</b> changed by <b>" +
             "<b>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + "</b>" + " MTRS was ...";


                            this.NotificationControllerInstance.NotificationEmailHistory_Ins(NEH);
                        }
                    }
                    else if (fabricWorking.UnitOfAverage2 == "-1" && fabricWorkingOld.UnitOfAverage2 != "-1")
                    {
                        if (fabricWorkingOld.UnitOfAverage2 == "1")
                        {
                            differences += "$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " +
                                           "Fabric2 Unit Of Average changed by " +
                                           ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " ... was KG";

                            NEH.Remarks = DateTime.Now.ToString("dd MMM yy (ddd)") + ": <b>" + lblSerial.Text + " " + lblStyleNumber.Text + "</b> <b>Fabric2 Unit Of Average</b> changed by <b>" +
             "<b>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + "</b>" + " ... was KG";


                            this.NotificationControllerInstance.NotificationEmailHistory_Ins(NEH);
                        }
                        else
                        {
                            differences += "$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " +
                                           "Fabric2 Unit Of Average changed by " +
                                           ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " ... was MTRS";

                            NEH.Remarks = DateTime.Now.ToString("dd MMM yy (ddd)") + ": <b>" + lblSerial.Text + " " + lblStyleNumber.Text + "</b> <b>Fabric2 Unit Of Average</b> changed by <b>" +
           "<b>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + "</b>" + " ... was MTRS";


                            this.NotificationControllerInstance.NotificationEmailHistory_Ins(NEH);
                        }
                    }
                    else if (fabricWorking.UnitOfAverage2 == "-1" && fabricWorkingOld.UnitOfAverage2 == "-1")
                    {
                    }
                }
                else if (fabricWorking.UnitOfAverage2 == "-1" && fabricWorkingOld.UnitOfAverage2 == "-1")
                {
                }
            }

            if (fabricWorking.UnitOfAverage3 != null && fabricWorkingOld.UnitOfAverage3 != null)
            {
                if (fabricWorking.UnitOfAverage3 != fabricWorkingOld.UnitOfAverage3)
                {
                    if (fabricWorking.UnitOfAverage3 == "1")
                    {
                        differences += "$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " +
                                       "Fabric3 Unit Of Average changed by " +
                                       ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " KG was MTRS";

                        NEH.Remarks = DateTime.Now.ToString("dd MMM yy (ddd)") + ": <b>" + lblSerial.Text + " " + lblStyleNumber.Text + "</b> <b>Fabric3 Unit Of Average</b> changed by <b>" +
          "<b>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + "</b>" + " KG was MTRS";


                        this.NotificationControllerInstance.NotificationEmailHistory_Ins(NEH);
                    }
                    else if (fabricWorking.UnitOfAverage3 == "2")
                    {
                        differences += "$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " +
                                       "Fabric3 Unit Of Average changed by " +
                                       ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " MTRS was KG";


                        NEH.Remarks = DateTime.Now.ToString("dd MMM yy (ddd)") + ": <b>" + lblSerial.Text + " " + lblStyleNumber.Text + "</b> <b>Fabric3 Unit Of Average</b> changed by <b>" +
         "<b>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + "</b>" + " MTRS was KG";


                        this.NotificationControllerInstance.NotificationEmailHistory_Ins(NEH);
                    }
                    else if (fabricWorking.UnitOfAverage3 != "-1" && fabricWorkingOld.UnitOfAverage3 == "-1")
                    {
                        if (fabricWorking.UnitOfAverage3 == "1")
                        {
                            differences += "$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " +
                                           "Fabric3 Unit Of Average changed by " +
                                           ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " KG was ...";

                            NEH.Remarks = DateTime.Now.ToString("dd MMM yy (ddd)") + ": <b>" + lblSerial.Text + " " + lblStyleNumber.Text + "</b> <b>Fabric3 Unit Of Average</b> changed by <b>" +
        "<b>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + "</b>" + " KG was ...";


                            this.NotificationControllerInstance.NotificationEmailHistory_Ins(NEH);
                        }
                        else
                        {
                            differences += "$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " +
                                           "Fabric3 Unit Of Average changed by " +
                                           ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " MTRS was ...";

                            NEH.Remarks = DateTime.Now.ToString("dd MMM yy (ddd)") + ": <b>" + lblSerial.Text + " " + lblStyleNumber.Text + "</b> <b>Fabric3 Unit Of Average</b> changed by <b>" +
       "<b>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + "</b>" + " MTRS was ...";


                            this.NotificationControllerInstance.NotificationEmailHistory_Ins(NEH);
                        }
                    }
                    else if (fabricWorking.UnitOfAverage3 == "-1" && fabricWorkingOld.UnitOfAverage3 != "-1")
                    {
                        if (fabricWorkingOld.UnitOfAverage3 == "1")
                        {
                            differences += "$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " +
                                           "Fabric3 Unit Of Average changed by " +
                                           ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " ... was KG";

                            NEH.Remarks = DateTime.Now.ToString("dd MMM yy (ddd)") + ": <b>" + lblSerial.Text + " " + lblStyleNumber.Text + "</b> <b>Fabric3 Unit Of Average</b> changed by <b>" +
      "<b>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + "</b>" + " ... was KG";


                            this.NotificationControllerInstance.NotificationEmailHistory_Ins(NEH);
                        }
                        else
                        {
                            differences += "$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " +
                                           "Fabric3 Unit Of Average changed by " +
                                           ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " ... was MTRS";

                            NEH.Remarks = DateTime.Now.ToString("dd MMM yy (ddd)") + ": <b>" + lblSerial.Text + " " + lblStyleNumber.Text + "</b> <b>Fabric3 Unit Of Average</b> changed by <b>" +
      "<b>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + "</b>" + " ... was MTRS";


                            this.NotificationControllerInstance.NotificationEmailHistory_Ins(NEH);
                        }
                    }
                    else if (fabricWorking.UnitOfAverage3 == "-1" && fabricWorkingOld.UnitOfAverage3 == "-1")
                    {
                    }
                }
                else if (fabricWorking.UnitOfAverage3 == "-1" && fabricWorkingOld.UnitOfAverage3 == "-1")
                {
                }
            }

            if (fabricWorking.UnitOfAverage4 != null && fabricWorkingOld.UnitOfAverage4 != null)
            {
                if (fabricWorking.UnitOfAverage4 != fabricWorkingOld.UnitOfAverage4)
                {
                    if (fabricWorking.UnitOfAverage4 == "1")
                    {
                        differences += "$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " +
                                       "Fabric4 Unit Of Average changed by " +
                                       ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " KG was MTRS";

                        NEH.Remarks = DateTime.Now.ToString("dd MMM yy (ddd)") + ": <b>" + lblSerial.Text + " " + lblStyleNumber.Text + "</b> <b>Fabric4 Unit Of Average</b> changed by <b>" +
      "<b>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + "</b>" + " KG was MTRS";


                        this.NotificationControllerInstance.NotificationEmailHistory_Ins(NEH);
                    }
                    else if (fabricWorking.UnitOfAverage4 == "2")
                    {
                        differences += "$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " +
                                       "Fabric4 Unit Of Average changed by " +
                                       ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " MTRS was KG";

                        NEH.Remarks = DateTime.Now.ToString("dd MMM yy (ddd)") + ": <b>" + lblSerial.Text + " " + lblStyleNumber.Text + "</b> <b>Fabric4 Unit Of Average</b> changed by <b>" +
      "<b>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + "</b>" + " MTRS was KG";


                        this.NotificationControllerInstance.NotificationEmailHistory_Ins(NEH);
                    }
                    else if (fabricWorking.UnitOfAverage4 != "-1" && fabricWorkingOld.UnitOfAverage4 == "-1")
                    {
                        if (fabricWorking.UnitOfAverage4 == "1")
                        {
                            differences += "$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " +
                                           "Fabric4 Unit Of Average changed by " +
                                           ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " KG was ...";

                            NEH.Remarks = DateTime.Now.ToString("dd MMM yy (ddd)") + ": <b>" + lblSerial.Text + " " + lblStyleNumber.Text + "</b> <b>Fabric4 Unit Of Average</b> changed by <b>" +
      "<b>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + "</b>" + " KG was ...";


                            this.NotificationControllerInstance.NotificationEmailHistory_Ins(NEH);
                        }
                        else
                        {
                            differences += "$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " +
                                           "Fabric4 Unit Of Average changed by " +
                                           ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " MTRS was ...";


                            NEH.Remarks = DateTime.Now.ToString("dd MMM yy (ddd)") + ": <b>" + lblSerial.Text + " " + lblStyleNumber.Text + "</b> <b>Fabric4 Unit Of Average</b> changed by <b>" +
      "<b>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + "</b>" + " MTRS was ...";


                            this.NotificationControllerInstance.NotificationEmailHistory_Ins(NEH);
                        }
                    }
                    else if (fabricWorking.UnitOfAverage4 == "-1" && fabricWorkingOld.UnitOfAverage4 != "-1")
                    {
                        if (fabricWorkingOld.UnitOfAverage4 == "1")
                        {
                            differences += "$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " +
                                           "Fabric4 Unit Of Average changed by " +
                                           ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " ... was KG";

                            NEH.Remarks = DateTime.Now.ToString("dd MMM yy (ddd)") + ": <b>" + lblSerial.Text + " " + lblStyleNumber.Text + "</b> <b>Fabric4 Unit Of Average</b> changed by <b>" +
     "<b>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + "</b>" + " ... was KG";


                            this.NotificationControllerInstance.NotificationEmailHistory_Ins(NEH);
                        }
                        else
                        {
                            differences += "$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " +
                                           "Fabric4 Unit Of Average changed by " +
                                           ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " ... was MTRS";

                            NEH.Remarks = DateTime.Now.ToString("dd MMM yy (ddd)") + ": <b>" + lblSerial.Text + " " + lblStyleNumber.Text + "</b> <b>Fabric4 Unit Of Average</b> changed by <b>" +
   "<b>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + "</b>" + " ... was MTRS";


                            this.NotificationControllerInstance.NotificationEmailHistory_Ins(NEH);
                        }
                    }
                    else if (fabricWorking.UnitOfAverage4 == "-1" && fabricWorkingOld.UnitOfAverage4 == "-1")
                    {
                    }
                }
                else if (fabricWorking.UnitOfAverage4 == "-1" && fabricWorkingOld.UnitOfAverage4 == "-1")
                {
                }
            }

            if (fabricWorkingOld.order.OrderBreakdown != null && fabricWorkingOld.order.OrderBreakdown.Count > 0)
            {
                int rowcountDiff = fabricWorking.order.OrderBreakdown.Count -
                                   fabricWorkingOld.order.OrderBreakdown.Count;
                if (rowcountDiff < 0)
                {
                }
                else
                {
                    foreach (OrderDetail od in fabricWorking.order.OrderBreakdown)
                    {
                        if (fabricWorkingOld.order.OrderBreakdown.Count >= i + 1)
                        {
                            if (fabricWorkingOld.order.OrderBreakdown[i].Fabric1Average !=
                                fabricWorking.order.OrderBreakdown[i].Fabric1Average)
                            {
                                differences += "$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " +
                                               fabricWorkingOld.order.OrderBreakdown[i].ContractNumber.ToUpper() + " : " +
                                               "Fabric1 Average changed by " +
                                               ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " +
                                               fabricWorking.order.OrderBreakdown[i].Fabric1Average + " was " +
                                               fabricWorkingOld.order.OrderBreakdown[i].Fabric1Average;


                                NEH.Remarks = DateTime.Now.ToString("dd MMM yy (ddd)") + ": <b>" + lblSerial.Text + " " + lblStyleNumber.Text + "</b> <b>Fabric1 Average</b> changed by <b>" +
                           ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " +
                           fabricWorking.order.OrderBreakdown[i].Fabric1Average + "</b> was <b>" + fabricWorkingOld.order.OrderBreakdown[i].Fabric1Average + "</b>";

                                this.NotificationControllerInstance.NotificationEmailHistory_Ins(NEH);



                            }

                            if (fabricWorkingOld.order.OrderBreakdown[i].Fabric2Average !=
                                fabricWorking.order.OrderBreakdown[i].Fabric2Average)
                            {
                                differences += "$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " +
                                               fabricWorkingOld.order.OrderBreakdown[i].ContractNumber.ToUpper() + " : " +
                                               "Fabric2 Average changed by " +
                                               ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " +
                                               fabricWorking.order.OrderBreakdown[i].Fabric2Average + " was " +
                                               fabricWorkingOld.order.OrderBreakdown[i].Fabric2Average;


                                NEH.Remarks = DateTime.Now.ToString("dd MMM yy (ddd)") + ": <b>" + lblSerial.Text + " " + lblStyleNumber.Text + "</b> <b>Fabric2 Average</b> changed by <b>" +
                           ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " +
                           fabricWorking.order.OrderBreakdown[i].Fabric2Average + "</b> was <b>" + fabricWorkingOld.order.OrderBreakdown[i].Fabric2Average + "</b>";

                                this.NotificationControllerInstance.NotificationEmailHistory_Ins(NEH);
                            }

                            if (fabricWorkingOld.order.OrderBreakdown[i].Fabric3Average !=
                                fabricWorking.order.OrderBreakdown[i].Fabric3Average)
                            {
                                differences += "$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " +
                                               fabricWorkingOld.order.OrderBreakdown[i].ContractNumber.ToUpper() + " : " +
                                               "Fabric3 Average changed by " +
                                               ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " +
                                               fabricWorking.order.OrderBreakdown[i].Fabric3Average + " was " +
                                               fabricWorkingOld.order.OrderBreakdown[i].Fabric3Average;

                                NEH.Remarks = DateTime.Now.ToString("dd MMM yy (ddd)") + ": <b>" + lblSerial.Text + " " + lblStyleNumber.Text + "</b> <b>Fabric3 Average</b> changed by <b>" +
                          ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " +
                          fabricWorking.order.OrderBreakdown[i].Fabric3Average + "</b> was <b>" + fabricWorkingOld.order.OrderBreakdown[i].Fabric3Average + "</b>";

                                this.NotificationControllerInstance.NotificationEmailHistory_Ins(NEH);
                            }

                            if (fabricWorkingOld.order.OrderBreakdown[i].Fabric4Average !=
                                fabricWorking.order.OrderBreakdown[i].Fabric4Average)
                            {
                                differences += "$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " +
                                               fabricWorkingOld.order.OrderBreakdown[i].ContractNumber.ToUpper() + " : " +
                                               "Fabric4 Average changed by " +
                                               ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " +
                                               fabricWorking.order.OrderBreakdown[i].Fabric4Average + " was " +
                                               fabricWorkingOld.order.OrderBreakdown[i].Fabric4Average;


                                NEH.Remarks = DateTime.Now.ToString("dd MMM yy (ddd)") + ": <b>" + lblSerial.Text + " " + lblStyleNumber.Text + "</b> <b>Fabric4 Average</b> changed by <b>" +
                          ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " +
                          fabricWorking.order.OrderBreakdown[i].Fabric4Average + "</b> was <b>" + fabricWorkingOld.order.OrderBreakdown[i].Fabric4Average + "</b>";

                                this.NotificationControllerInstance.NotificationEmailHistory_Ins(NEH);
                            }

                            if (Convert.ToInt32(fabricWorkingOld.order.OrderBreakdown[i].Fabric1Quantity) !=
                                Convert.ToInt32(fabricWorking.order.OrderBreakdown[i].Fabric1Quantity))
                            {
                                differences += "$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " +
                                               fabricWorkingOld.order.OrderBreakdown[i].ContractNumber.ToUpper() + " : " +
                                               "Fabric1 Quantity changed by " +
                                               ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " +
                                               fabricWorking.order.OrderBreakdown[i].Fabric1Quantity + " was " +
                                               fabricWorkingOld.order.OrderBreakdown[i].Fabric1Quantity;


                                NEH.Remarks = DateTime.Now.ToString("dd MMM yy (ddd)") + ": <b>" + lblSerial.Text + " " + lblStyleNumber.Text + "</b> <b>Fabric1 Quantity</b> changed by  <b>" +
                         ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " +
                         fabricWorking.order.OrderBreakdown[i].Fabric1Quantity + "</b> was <b>" + fabricWorkingOld.order.OrderBreakdown[i].Fabric1Quantity + "</b>";

                                this.NotificationControllerInstance.NotificationEmailHistory_Ins(NEH);
                            }

                            if (Convert.ToInt32(fabricWorkingOld.order.OrderBreakdown[i].Fabric2Quantity) !=
                                Convert.ToInt32(fabricWorking.order.OrderBreakdown[i].Fabric2Quantity))
                            {
                                differences += "$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " +
                                               fabricWorkingOld.order.OrderBreakdown[i].ContractNumber.ToUpper() + " : " +
                                               "Fabric2 Quantity changed by " +
                                               ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " +
                                               fabricWorking.order.OrderBreakdown[i].Fabric2Quantity + " was " +
                                               fabricWorkingOld.order.OrderBreakdown[i].Fabric2Quantity;

                                NEH.Remarks = DateTime.Now.ToString("dd MMM yy (ddd)") + ": <b>" + lblSerial.Text + " " + lblStyleNumber.Text + "</b> <b>Fabric2 Quantity</b> changed by  <b>" +
                        ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " +
                        fabricWorking.order.OrderBreakdown[i].Fabric2Quantity + "</b> was <b>" + fabricWorkingOld.order.OrderBreakdown[i].Fabric2Quantity + "</b>";

                                this.NotificationControllerInstance.NotificationEmailHistory_Ins(NEH);
                            }

                            if (Convert.ToInt32(fabricWorkingOld.order.OrderBreakdown[i].Fabric3Quantity) !=
                                Convert.ToInt32(fabricWorking.order.OrderBreakdown[i].Fabric3Quantity))
                            {
                                differences += "$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " +
                                               fabricWorkingOld.order.OrderBreakdown[i].ContractNumber.ToUpper() + " : " +
                                               "Fabric3 Quantity changed by " +
                                               ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " +
                                               fabricWorking.order.OrderBreakdown[i].Fabric3Quantity + " was " +
                                               fabricWorkingOld.order.OrderBreakdown[i].Fabric3Quantity;

                                NEH.Remarks = DateTime.Now.ToString("dd MMM yy (ddd)") + ": <b>" + lblSerial.Text + " " + lblStyleNumber.Text + "</b> <b>Fabric3 Quantity</b> changed by  <b>" +
                       ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " +
                       fabricWorking.order.OrderBreakdown[i].Fabric3Quantity + "</b> was <b>" + fabricWorkingOld.order.OrderBreakdown[i].Fabric3Quantity + "</b>";

                                this.NotificationControllerInstance.NotificationEmailHistory_Ins(NEH);
                            }

                            if (Convert.ToInt32(fabricWorkingOld.order.OrderBreakdown[i].Fabric4Quantity) !=
                                Convert.ToInt32(fabricWorking.order.OrderBreakdown[i].Fabric4Quantity))
                            {
                                differences += "$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " +
                                               fabricWorkingOld.order.OrderBreakdown[i].ContractNumber.ToUpper() + " : " +
                                               "Fabric4 Quantity changed by " +
                                               ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " +
                                               fabricWorking.order.OrderBreakdown[i].Fabric4Quantity + " was " +
                                               fabricWorkingOld.order.OrderBreakdown[i].Fabric4Quantity;

                                NEH.Remarks = DateTime.Now.ToString("dd MMM yy (ddd)") + ": <b>" + lblSerial.Text + " " + lblStyleNumber.Text + "</b> <b>Fabric4 Quantity</b> changed by  <b>" +
                      ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " +
                      fabricWorking.order.OrderBreakdown[i].Fabric4Quantity + "</b> was <b>" + fabricWorkingOld.order.OrderBreakdown[i].Fabric4Quantity + "</b>";

                                this.NotificationControllerInstance.NotificationEmailHistory_Ins(NEH);
                            }
                        }

                        i++;
                    }
                }
            }

            //if (differences !=string.Empty)
            //{
            //    NEH.Remarks = differences + " Updated  by " + "<b>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper().ToString() + "</b>";
            //    nn.NotificationEmailHistory_Ins(NEH);
            //}
            return differences;
        }

        #endregion

        protected void repeaterOrderBreakdown_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                HiddenField hdnIsCutAvg1 = (HiddenField)e.Item.FindControl("hdnIsCutAvg1");
                HiddenField hdnIsAckAvg1 = (HiddenField)e.Item.FindControl("hdnIsAckAvg1");
                TextBox txtFabric1Avg = (TextBox)e.Item.FindControl("txtFabric1Average");
                Label lblFabric1Avg = (Label)e.Item.FindControl("lblFabric1Average");
                Label lblFabricAvgName1 = (Label)e.Item.FindControl("lblFabricAvgName1");
                Label lblOrderName1 = (Label)e.Item.FindControl("lblOrderName1");

                //Added By Ashish on 7/1/2014
                TextBox txtFabric1Quantity = (TextBox)e.Item.FindControl("txtFabric1Quantity");
                TextBox txtFabric2Quantity = (TextBox)e.Item.FindControl("txtFabric2Quantity");
                TextBox txtFabric3Quantity = (TextBox)e.Item.FindControl("txtFabric3Quantity");
                TextBox txtFabric4Quantity = (TextBox)e.Item.FindControl("txtFabric4Quantity");

                txtFabric1Quantity.Text = Math.Round(Convert.ToDecimal(txtFabric1Quantity.Text)).ToString();
                txtFabric2Quantity.Text = Math.Round(Convert.ToDecimal(txtFabric2Quantity.Text)).ToString();
                txtFabric3Quantity.Text = Math.Round(Convert.ToDecimal(txtFabric3Quantity.Text)).ToString();
                txtFabric4Quantity.Text = Math.Round(Convert.ToDecimal(txtFabric4Quantity.Text)).ToString();


                if (txtFabric1Quantity.Text == "0")
                {
                    txtFabric1Quantity.Text = "";
                }
                if (txtFabric2Quantity.Text == "0")
                {
                    txtFabric2Quantity.Text = "";
                }
                if (txtFabric3Quantity.Text == "0")
                {
                    txtFabric3Quantity.Text = "";
                }
                if (txtFabric4Quantity.Text == "0")
                {
                    txtFabric4Quantity.Text = "";
                }


                //END


                if (hdnIsCutAvg1 != null)
                {
                    if (hdnIsCutAvg1.Value == "YES")
                    {
                        txtFabric1Avg.CssClass = "do-not-allow-typing";
                        lblFabric1Avg.Visible = true;
                        lblFabricAvgName1.Text = "C :";
                        lblOrderName1.Text = "O :";
                    }
                    else
                    {
                        lblFabric1Avg.Visible = false;
                    }
                }
                if (hdnIsAckAvg1 != null)
                {
                    if (hdnIsAckAvg1.Value == "YES")
                    {
                        txtFabric1Avg.ForeColor = System.Drawing.Color.Blue;
                    }
                }

                //Added By Ashish on 6/1/2014 for Hide Zero
                if (lblFabricAvgName1 != null)
                {
                    if (lblFabric1Avg.Text == "(0)")
                    {
                        lblFabricAvgName1.Text = "";
                    }
                }
                //END

                HiddenField hdnIsCutAvg2 = (HiddenField)e.Item.FindControl("hdnIsCutAvg2");
                HiddenField hdnIsAckAvg2 = (HiddenField)e.Item.FindControl("hdnIsAckAvg2");
                TextBox txtFabric2Avg = (TextBox)e.Item.FindControl("txtFabric2Average");
                Label lblFabric2Avg = (Label)e.Item.FindControl("lblFabric2Average");
                Label lblFabricAvgName2 = (Label)e.Item.FindControl("lblFabricAvgName2");
                Label lblOrderName2 = (Label)e.Item.FindControl("lblOrderName2");
                TextBox txtFabric2OrdAverage = (TextBox)e.Item.FindControl("txtFabric2OrdAverage");

                if (hdnIsCutAvg2 != null)
                {
                    if (hdnIsCutAvg2.Value == "YES")
                    {
                        txtFabric2Avg.CssClass = "do-not-allow-typing";
                        lblFabric2Avg.Visible = true;
                        lblFabricAvgName2.Text = "C :";
                        lblOrderName2.Text = "O :";
                    }
                    else
                    {
                        lblFabric2Avg.Visible = false;
                    }
                }
                if (hdnIsAckAvg2 != null)
                {
                    if (hdnIsAckAvg2.Value == "YES")
                    {
                        txtFabric2Avg.ForeColor = System.Drawing.Color.Blue;
                    }
                }

                //Added By Ashish on 6/1/2014 for Hide Zero
                if (lblFabricAvgName2 != null)
                {
                    if (lblFabric2Avg.Text == "(0)")
                    {
                        lblFabricAvgName2.Text = "";
                    }
                }
                //END

                HiddenField hdnIsCutAvg3 = (HiddenField)e.Item.FindControl("hdnIsCutAvg3");
                HiddenField hdnIsAckAvg3 = (HiddenField)e.Item.FindControl("hdnIsAckAvg3");
                TextBox txtFabric3Avg = (TextBox)e.Item.FindControl("txtFabric3Average");
                Label lblFabric3Avg = (Label)e.Item.FindControl("lblFabric3Average");
                Label lblFabricAvgName3 = (Label)e.Item.FindControl("lblFabricAvgName3");
                Label lblOrderName3 = (Label)e.Item.FindControl("lblOrderName3");
                TextBox txtFabric3OrdAverage = (TextBox)e.Item.FindControl("txtFabric3OrdAverage");

                if (hdnIsCutAvg3 != null)
                {
                    if (hdnIsCutAvg3.Value == "YES")
                    {
                        txtFabric3Avg.CssClass = "do-not-allow-typing";
                        lblFabric3Avg.Visible = true;
                        lblFabricAvgName3.Text = "C :";
                        lblOrderName3.Text = "O :";
                    }
                    else
                    {
                        lblFabric3Avg.Visible = false;
                    }
                }
                if (hdnIsAckAvg3 != null)
                {
                    if (hdnIsAckAvg3.Value == "YES")
                    {
                        txtFabric3Avg.ForeColor = System.Drawing.Color.Blue;
                        txtFabric3Avg.Font.Bold = true;
                    }
                }

                //Added By Ashish on 6/1/2014 for Hide Zero
                if (lblFabricAvgName3 != null)
                {
                    if (lblFabric3Avg.Text == "(0)")
                    {
                        lblFabricAvgName3.Text = "";
                    }
                }
                //END

                HiddenField hdnIsCutAvg4 = (HiddenField)e.Item.FindControl("hdnIsCutAvg4");
                HiddenField hdnIsAckAvg4 = (HiddenField)e.Item.FindControl("hdnIsAckAvg4");
                TextBox txtFabric4Avg = (TextBox)e.Item.FindControl("txtFabric4Average");
                Label lblFabric4Avg = (Label)e.Item.FindControl("lblFabric4Average");
                Label lblFabricAvgName4 = (Label)e.Item.FindControl("lblFabricAvgName4");
                Label lblOrderName4 = (Label)e.Item.FindControl("lblOrderName4");
                TextBox txtFabric4OrdAverage = (TextBox)e.Item.FindControl("txtFabric4OrdAverage");

                if (hdnIsCutAvg4 != null)
                {
                    if (hdnIsCutAvg4.Value == "YES")
                    {
                        txtFabric4Avg.CssClass = "do-not-allow-typing";
                        lblFabric4Avg.Visible = true;
                        lblFabricAvgName4.Text = "C :";
                        lblOrderName4.Text = "O :";
                        //txtFabric4OrdAverage.Visible = false;
                    }
                    else
                    {
                        lblFabric4Avg.Visible = false;
                    }
                }
                if (hdnIsAckAvg4 != null)
                {
                    if (hdnIsAckAvg4.Value == "YES")
                    {
                        txtFabric4Avg.ForeColor = System.Drawing.Color.Blue;
                    }
                }

                //Added By Ashish on 6/1/2014 for Hide Zero
                if (lblFabricAvgName4 != null)
                {
                    if (lblFabric4Avg.Text == "(0)")
                    {
                        lblFabricAvgName4.Text = "";
                    }
                }
                //END

            }
        }
        //added by abhishek -----------//
        #region Gajendra Commented 12-04-2016
        //protected void ddlQtyApvd_1_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    FabricWorking fabricWorking_new = FabricWorkingControllerInstance.GetFabricWorking(OrderId,OrderDetailID);
        //    if (ddlQtyApvd_1.SelectedValue != "-1")
        //    {
        //        if (ddlQtyApvd_1.SelectedValue == "2")
        //        {
        //            ddlinitial_1.Enabled = true;
        //            ddlinitial_1.SelectedValue = fabricWorking_new.IntialAprdFabric1 == 0 ? "-1" : fabricWorking_new.IntialAprdFabric1.ToString();
        //        }
        //        else
        //        {
        //            ddlinitial_1.SelectedValue = fabricWorking_new.IntialAprdFabric1 == 0 ? "-1" : fabricWorking_new.IntialAprdFabric1.ToString();
        //            ddlinitial_1.Enabled = false;
        //        }
        //    }
        //    else
        //    {
        //        ddlinitial_1.Enabled = false;
        //    }

        //}

        //protected void ddlinitial_1_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    FabricWorking fabricWorking_new = FabricWorkingControllerInstance.GetFabricWorking(OrderId,OrderDetailID);
        //    if (ddlinitial_1.SelectedValue != "-1")
        //    {
        //        if (ddlinitial_1.SelectedValue == "2")
        //        {
        //            ddlbulkApvd_1.Enabled = true;
        //            ddlbulkApvd_1.SelectedValue = fabricWorking_new.BulkAprdFabric1 == 0 ? "-1" : fabricWorking_new.BulkAprdFabric1.ToString();
        //        }
        //        else
        //        {
        //            ddlbulkApvd_1.SelectedValue = fabricWorking_new.BulkAprdFabric1 == 0 ? "-1" : fabricWorking_new.BulkAprdFabric1.ToString();
        //            ddlbulkApvd_1.Enabled = false;
        //        }
        //    }
        //    else
        //    {
        //        ddlbulkApvd_1.Enabled = false;
        //    }

        //}

        //protected void ddlQtyApvd_2_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    FabricWorking fabricWorking_new = FabricWorkingControllerInstance.GetFabricWorking(OrderId,OrderDetailID);
        //    if (ddlQtyApvd_2.SelectedValue != "-1")
        //    {
        //        if (ddlQtyApvd_2.SelectedValue == "2")
        //        {
        //            ddlinitial_2.Enabled = true;
        //            ddlinitial_2.SelectedValue = fabricWorking_new.IntialAprdFabric2 == 0 ? "-1" : fabricWorking_new.IntialAprdFabric2.ToString();
        //        }
        //        else
        //        {
        //            ddlinitial_2.SelectedValue = fabricWorking_new.IntialAprdFabric2 == 0 ? "-1" : fabricWorking_new.IntialAprdFabric2.ToString();
        //            ddlinitial_2.Enabled = false;
        //        }
        //    }
        //    else
        //    {
        //        ddlinitial_2.Enabled = false;
        //    }


        //}

        //protected void ddlinitial_2_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    FabricWorking fabricWorking_new = FabricWorkingControllerInstance.GetFabricWorking(OrderId,OrderDetailID);
        //    if (ddlinitial_2.SelectedValue != "-1")
        //    {
        //        if (ddlinitial_2.SelectedValue == "2")
        //        {
        //            ddlbulkApvd_2.Enabled = true;
        //            ddlbulkApvd_2.SelectedValue = fabricWorking_new.BulkAprdFabric2 == 0 ? "-1" : fabricWorking_new.BulkAprdFabric2.ToString();
        //        }
        //        else
        //        {
        //            ddlbulkApvd_2.SelectedValue = fabricWorking_new.BulkAprdFabric2 == 0 ? "-1" : fabricWorking_new.BulkAprdFabric2.ToString();
        //            ddlbulkApvd_2.Enabled = false;
        //        }
        //    }
        //    else
        //    {
        //        ddlbulkApvd_2.Enabled = false;
        //    }

        //}

        //protected void ddlQtyApvd_3_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    FabricWorking fabricWorking_new = FabricWorkingControllerInstance.GetFabricWorking(OrderId,OrderDetailID);
        //    if (ddlQtyApvd_3.SelectedValue != "-1")
        //    {
        //        if (ddlQtyApvd_3.SelectedValue == "2")
        //        {
        //            ddlinitial_3.Enabled = true;
        //            ddlinitial_3.SelectedValue = fabricWorking_new.IntialAprdFabric3 == 0 ? "-1" : fabricWorking_new.IntialAprdFabric3.ToString();
        //        }
        //        else
        //        {
        //            ddlinitial_3.SelectedValue = fabricWorking_new.IntialAprdFabric3 == 0 ? "-1" : fabricWorking_new.IntialAprdFabric3.ToString();
        //            ddlinitial_3.Enabled = false;
        //        }
        //    }
        //    else
        //    {
        //        ddlinitial_3.Enabled = false;
        //    }
        //}

        //protected void ddlinitial_3_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    FabricWorking fabricWorking_new = FabricWorkingControllerInstance.GetFabricWorking(OrderId,OrderDetailID);
        //    if (ddlinitial_3.SelectedValue != "-1")
        //    {
        //        if (ddlinitial_3.SelectedValue == "2")
        //        {
        //            ddlbulkApvd_3.Enabled = true;
        //            ddlbulkApvd_3.SelectedValue = fabricWorking_new.BulkAprdFabric3 == 0 ? "-1" : fabricWorking_new.BulkAprdFabric3.ToString();
        //        }
        //        else
        //        {
        //            ddlbulkApvd_3.SelectedValue = fabricWorking_new.BulkAprdFabric3 == 0 ? "-1" : fabricWorking_new.BulkAprdFabric3.ToString();
        //            ddlbulkApvd_3.Enabled = false;
        //        }
        //    }
        //    else
        //    {
        //        ddlbulkApvd_3.Enabled = false;
        //    }

        //}

        //protected void ddlQtyApvd_4_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    FabricWorking fabricWorking_new = FabricWorkingControllerInstance.GetFabricWorking(OrderId,OrderDetailID);
        //    if (ddlQtyApvd_4.SelectedValue != "-1")
        //    {
        //        if (ddlQtyApvd_4.SelectedValue == "2")
        //        {
        //            ddlinitial_4.Enabled = true;
        //            ddlinitial_4.SelectedValue = fabricWorking.IntialAprdFabric4 == 0 ? "-1" : fabricWorking.IntialAprdFabric4.ToString();
        //        }
        //        else
        //        {
        //            ddlinitial_4.SelectedValue = fabricWorking.IntialAprdFabric4 == 0 ? "-1" : fabricWorking.IntialAprdFabric4.ToString();
        //            ddlinitial_4.Enabled = false;
        //        }
        //    }
        //    else
        //    {
        //        ddlinitial_4.Enabled = false;
        //    }
        //}

        //protected void ddlinitial_4_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    FabricWorking fabricWorking_new = FabricWorkingControllerInstance.GetFabricWorking(OrderId, OrderDetailID);
        //    if (ddlinitial_4.SelectedValue != "-1")
        //    {
        //        if (ddlinitial_4.SelectedValue == "2")
        //        {
        //            ddlbulkApvd_4.Enabled = true;
        //            ddlbulkApvd_4.SelectedValue = fabricWorking.BulkAprdFabric4 == 0 ? "-1" : fabricWorking.BulkAprdFabric4.ToString();
        //        }
        //        else
        //        {
        //            ddlbulkApvd_4.SelectedValue = fabricWorking.BulkAprdFabric4 == 0 ? "-1" : fabricWorking.BulkAprdFabric4.ToString();
        //            ddlbulkApvd_4.Enabled = false;
        //        }
        //    }
        //    else
        //    {
        //        ddlbulkApvd_4.Enabled = false;
        //    }

        //}
        #endregion

        /*here check all fabric drodown selected value should be 
        Approved then Enable Fabric Mangaer Checkbox otherwise disable*/
        public void CheckFabricManagerVisibility(FabricWorking fw)
        {
            //bool IsCheck = chkboxFabricManager.Enabled;
            //// FabricWorking fw = FabricWorkingControllerInstance.Get_FabricApprovalDetails(OrderDetailID);
            //IsFabricMangerApproved += lblFab1ColPrd.Text == "" ? 0 : 1;
            //IsFabricMangerApproved += lblFab2ColPrd.Text == "" ? 0 : 1;
            //IsFabricMangerApproved += lblFab3ColPrd.Text == "" ? 0 : 1;
            //IsFabricMangerApproved += lblFab4ColPrd.Text == "" ? 0 : 1;

            //switch (IsFabricMangerApproved)
            //{
            //    case 1:
            //        if (fw.BulkAprdFabric1 == 2)//ddlbulkApvd_1.SelectedValue == "2"
            //        {
            //            chkboxFabricManager.Enabled = true;
            //        }
            //        else
            //        {
            //            if (fw.ApprovedByFabricManager == 1)
            //            {
            //                chkboxFabricManager.Checked = true;
            //                chkboxFabricManager.Enabled = false;
            //            }
            //        }
            //        break;
            //    case 2:
            //        if (fw.BulkAprdFabric1 == 2 && fw.BulkAprdFabric2 == 2)//ddlbulkApvd_1.SelectedValue == "2" && ddlbulkApvd_2.SelectedValue == "2"
            //        {
            //            chkboxFabricManager.Enabled = true;
            //        }
            //        else
            //        {
            //            if (fw.ApprovedByFabricManager == 1)
            //            {
            //                chkboxFabricManager.Checked = true;
            //                chkboxFabricManager.Enabled = false;
            //            }
            //        }
            //        break;
            //    case 3:
            //        if (fw.BulkAprdFabric1 == 2 && fw.BulkAprdFabric2 == 2 && fw.BulkAprdFabric3 == 2)//ddlbulkApvd_1.SelectedValue == "2" && ddlbulkApvd_2.SelectedValue == "2" && ddlbulkApvd_1.SelectedValue == "2"
            //        {
            //            chkboxFabricManager.Enabled = true;
            //        }
            //        else
            //        {
            //            if (fw.ApprovedByFabricManager == 1)
            //            {
            //                chkboxFabricManager.Checked = true;
            //                chkboxFabricManager.Enabled = false;
            //            }
            //        }
            //        break;

            //    case 4:
            //        if (fw.BulkAprdFabric1 == 2 && fw.BulkAprdFabric2 == 2 && fw.BulkAprdFabric3 == 2 && fw.BulkAprdFabric4 == 2)//ddlbulkApvd_1.SelectedValue == "2" && ddlbulkApvd_2.SelectedValue == "2" && ddlbulkApvd_3.SelectedValue == "2" && ddlbulkApvd_4.SelectedValue == "2"
            //        {
            //            chkboxFabricManager.Enabled = true;
            //        }
            //        else
            //        {
            //            if (fw.ApprovedByFabricManager == 1)
            //            {
            //                chkboxFabricManager.Checked = true;
            //                chkboxFabricManager.Enabled = false;
            //            }
            //        }
            //        break;
            //    default:
            //        break;
            //}
        }
        //protected void ddlbulkApvd_1_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    CheckFabricManagerVisibility();
        //}

        //protected void ddlbulkApvd_2_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    CheckFabricManagerVisibility();

        //}

        //protected void ddlbulkApvd_3_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    CheckFabricManagerVisibility();

        //}

        //protected void ddlbulkApvd_4_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    CheckFabricManagerVisibility();

        //}
    }
}