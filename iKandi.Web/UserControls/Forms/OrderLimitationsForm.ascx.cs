#region Assembly Reference

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Web.UI.WebControls;
using iKandi.BLL;
using iKandi.Common;
using iKandi.Web.Components;
using Microsoft.VisualBasic;
using System.Web.UI.HtmlControls;
using FirstDayOfWeek = Microsoft.VisualBasic.FirstDayOfWeek;
using System.Data;

#endregion

namespace iKandi.Web
{
    public partial class OrderLimitationsForm : BaseUserControl
    {
        #region Fields

        private UserTask _costingConfirmationTask;

        #endregion

        #region Properties

        public int OrderId
        {
            get
            {
                if (null != Request.QueryString["orderid"])
                {
                    int oid;
                    if (int.TryParse(Request.QueryString["orderid"], out oid))
                        return oid;
                }

                return -1;
            }
        }

        public UserTask BulkInHouseApprovalTask
        {
            get
            {
                if (ApplicationHelper.LoggedInUser.UserData.Designation == Designation.BIPL_Sales_Manager &&
                    _costingConfirmationTask == null)
                    _costingConfirmationTask = UserTaskControllerInstance.GetUserTasksByOrderID(OrderId, UserTaskType.BulkInHouseTarget);
                return _costingConfirmationTask;
            }
        }

        #endregion


        #region Event Handlers

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                hdnOrderId.Value = OrderId.ToString();
                BindControls();                        
               
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
                return;
            SaveLimitation();
            //Added by abhishek on 29/7/2015
            updateriskRemarks(OrderId);
            //END

        }

        protected void grdOrderBreakdown_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            OrderLimitation orderLimitation = new OrderLimitation();
            List<OrderLimitation> orderLimitationCollection = OrderControllerInstance.GetOrderLimitation(OrderId);
            if (orderLimitationCollection.Count > 0)
            {
                orderLimitation = orderLimitationCollection[0];
            }

            List<OrderDetail> orderDetailCollection = OrderControllerInstance.GetOrderDetailById(OrderId);
            OrderDetail orderDetail = new OrderDetail();
            if (orderDetailCollection.Count > 0)
            {
                orderDetail = orderDetailCollection[0];
            }

            if (e.Row.RowType == DataControlRowType.Footer)
            {
                TextBox txtFabric1Days = (TextBox)e.Row.FindControl("txtCalcFabric1");
                HtmlInputHidden htmlHdnFabric1 = (HtmlInputHidden)e.Row.FindControl("hdnCalcFabric1");

                txtFabric1Days.Text = orderLimitation.CalcFabric1Days.ToString() == "0" ? "" : orderLimitation.CalcFabric1Days.ToString();
                htmlHdnFabric1.Value = orderLimitation.CalcFabric1Days.ToString() == "0" ? "" : orderLimitation.CalcFabric1Days.ToString();

                if (orderLimitation.CalcFabric1Days != 0)
                {
                    txtFabric1Days.CssClass = "do-not-allow-typing print-box";
                }

                if (orderDetail.BIHFabric1 == DateTime.MinValue)
                {
                    txtFabric1Days.Attributes.Add("style", "display:none;");
                }

                TextBox txtFabric2Days = (TextBox)e.Row.FindControl("txtCalcFabric2");
                HtmlInputHidden htmlHdnFabric2 = (HtmlInputHidden)e.Row.FindControl("hdnCalcFabric2");

                txtFabric2Days.Text = orderLimitation.CalcFabric2Days.ToString() == "0" ? "" : orderLimitation.CalcFabric2Days.ToString();
                htmlHdnFabric2.Value = orderLimitation.CalcFabric2Days.ToString() == "0" ? "" : orderLimitation.CalcFabric2Days.ToString();

                if (orderLimitation.CalcFabric2Days != 0)
                {
                    txtFabric2Days.CssClass = "do-not-allow-typing print-box";
                }

                if (orderDetail.BIHFabric2 == DateTime.MinValue)
                {
                    txtFabric2Days.Attributes.Add("style", "display:none;");
                }

                TextBox txtFabric3Days = (TextBox)e.Row.FindControl("txtCalcFabric3");
                HtmlInputHidden htmlHdnFabric3 = (HtmlInputHidden)e.Row.FindControl("hdnCalcFabric3");

                txtFabric3Days.Text = orderLimitation.CalcFabric3Days.ToString() == "0" ? "" : orderLimitation.CalcFabric3Days.ToString();
                htmlHdnFabric3.Value = orderLimitation.CalcFabric3Days.ToString() == "0" ? "" : orderLimitation.CalcFabric3Days.ToString();

                if (orderLimitation.CalcFabric3Days != 0)
                {
                    txtFabric3Days.CssClass = "do-not-allow-typing print-box";
                }

                if (orderDetail.BIHFabric3 == DateTime.MinValue)
                {
                    txtFabric3Days.Attributes.Add("style", "display:none;");
                }

                TextBox txtFabric4Days = (TextBox)e.Row.FindControl("txtCalcFabric4");
                HtmlInputHidden htmlHdnFabric4 = (HtmlInputHidden)e.Row.FindControl("hdnCalcFabric4");

                txtFabric4Days.Text = orderLimitation.CalcFabric4Days.ToString() == "0" ? "" : orderLimitation.CalcFabric4Days.ToString();
                htmlHdnFabric4.Value = orderLimitation.CalcFabric4Days.ToString() == "0" ? "" : orderLimitation.CalcFabric4Days.ToString();

                if (orderLimitation.CalcFabric4Days != 0)
                {
                    txtFabric4Days.CssClass = "do-not-allow-typing print-box";
                }

                if (orderDetail.BIHFabric4 == DateTime.MinValue)
                {
                    txtFabric4Days.Attributes.Add("style", "display:none;");
                }
            }
        }

        #endregion

        #region Private Method

        private void BindControls()
        {
            //txtIA.DataBind();
            //txtBIH.DataBind();

            if (OrderId != -1)
            {
                //if (BulkInHouseApprovalTask != null && BulkInHouseApprovalTask.ID > 0)
                //{
                //    pnlSalesApproval.Visible = true;
                //}
                //else
                //{
                //    pnlSalesApproval.Visible = false;
                //}

                txtIkandiComments.DataBind();

                Common.Order order = OrderControllerInstance.GetOrder(OrderId);

                lblIkandiOrderDate.Text = order.OrderDate.ToString("dd MMM yy (ddd)");
                lblIkandiStyleNumber.Text = order.Style.StyleNumber;
                hiddenStyleID.Value = order.Style.StyleID.ToString();
                lblBuyer.Text = order.Style.client.CompanyName;
                lblIkandiSerial.Text = order.SerialNumber;
                lblDescription.Text = order.Description;
                lblDepartment.Text = order.Style.cdept.Name;
                lblTotalQuantity.Text = order.TotalQuantity.ToString();
                hiddenAcc.Value = DateTime.Now.ToShortDateString();
                hiddenFab.Value = DateTime.Now.ToShortDateString();
                //hiddenMerch.Value = DateTime.Now.ToShortDateString();

                //Added by abhishek on 13/1/2015
                lbLabDipTarget.Text = order.LabdipTargetETA == DateTime.MinValue ? "" : order.LabdipTargetETA.ToString("dd MMM yy (ddd)");
                //end by abhishek on 13/1/2015



                grdOrderBreakdown.DataSource = order.OrderBreakdown;
                grdOrderBreakdown.DataBind();
                /* commted by abhishek 1/2/2016
                  if ((ApplicationHelper.LoggedInUser.UserData.Designation == Designation.BIPL_Fabrics_Manager))
                  {
                      chkboxFabricMgr.Enabled = true;
                      txtFabric.CssClass = "";
                      txtAccessories.CssClass = "do-not-allow-typing";
                      //txtMerchandising.CssClass = "do-not-allow-typing";
                      chkboxAccessoriesMgr.Enabled = false;
                      //chkboxMerchandisingMgr.Enabled = false;
                  }
                  else if ((ApplicationHelper.LoggedInUser.UserData.Designation == Designation.BIPL_Accessory_Manager))
                  {
                      chkboxFabricMgr.Enabled = false;
                      chkboxAccessoriesMgr.Enabled = true;
                      txtAccessories.CssClass = "";
                      //txtMerchandising.CssClass = "do-not-allow-typing";
                      TextBox txtFabric1 = (TextBox)grdOrderBreakdown.FooterRow.FindControl("txtCalcFabric1");
                      txtFabric1.CssClass = "do-not-allow-typing CaclFabric1";

                      TextBox txtFabric2 = (TextBox)grdOrderBreakdown.FooterRow.FindControl("txtCalcFabric2");
                      txtFabric2.CssClass = "do-not-allow-typing CaclFabric2";

                      TextBox txtFabric3 = (TextBox)grdOrderBreakdown.FooterRow.FindControl("txtCalcFabric3");
                      txtFabric3.CssClass = "do-not-allow-typing CaclFabric3";

                      TextBox txtFabric4 = (TextBox)grdOrderBreakdown.FooterRow.FindControl("txtCalcFabric4");
                      txtFabric4.CssClass = "do-not-allow-typing CaclFabric4";

                      txtFabric.CssClass = "do-not-allow-typing";
                      //chkboxMerchandisingMgr.Enabled = false;
                  }


                  else if ((ApplicationHelper.LoggedInUser.UserData.Designation == Designation.BIPL_Merchandising_Manager))
                  {
                      chkboxFabricMgr.Enabled = false;
                      chkboxAccessoriesMgr.Enabled = false;
                      //chkboxMerchandisingMgr.Enabled = true;
                      //txtMerchandising.CssClass = "";
                      txtFabric.CssClass = "do-not-allow-typing";
                      txtAccessories.CssClass = "do-not-allow-typing";
                      TextBox txtFabric1 = (TextBox)grdOrderBreakdown.FooterRow.FindControl("txtCalcFabric1");
                      txtFabric1.CssClass = "do-not-allow-typing CaclFabric1";

                      TextBox txtFabric2 = (TextBox)grdOrderBreakdown.FooterRow.FindControl("txtCalcFabric2");
                      txtFabric2.CssClass = "do-not-allow-typing CaclFabric2";

                      TextBox txtFabric3 = (TextBox)grdOrderBreakdown.FooterRow.FindControl("txtCalcFabric3");
                      txtFabric3.CssClass = "do-not-allow-typing CaclFabric3";

                      TextBox txtFabric4 = (TextBox)grdOrderBreakdown.FooterRow.FindControl("txtCalcFabric4");
                      txtFabric4.CssClass = "do-not-allow-typing CaclFabric4";

                      int StyleId = Convert.ToInt32(hiddenStyleID.Value);
                      int thisOrderId = Convert.ToInt32(hdnOrderId.Value);
                    
                  }

                  else
                  {
                      chkboxFabricMgr.Enabled = false;
                      chkboxAccessoriesMgr.Enabled = false;
                      //chkboxMerchandisingMgr.Enabled = false;
                      //txtMerchandising.CssClass = "do-not-allow-typing";
                      txtAccessories.CssClass = "do-not-allow-typing";
                      txtFabric.CssClass = "do-not-allow-typing";

                      TextBox txtFabric1 = (TextBox)grdOrderBreakdown.FooterRow.FindControl("txtCalcFabric1");
                      txtFabric1.CssClass = "do-not-allow-typing CaclFabric1";

                      TextBox txtFabric2 = (TextBox)grdOrderBreakdown.FooterRow.FindControl("txtCalcFabric2");
                      txtFabric2.CssClass = "do-not-allow-typing CaclFabric2";

                      TextBox txtFabric3 = (TextBox)grdOrderBreakdown.FooterRow.FindControl("txtCalcFabric3");
                      txtFabric3.CssClass = "do-not-allow-typing CaclFabric3";

                      TextBox txtFabric4 = (TextBox)grdOrderBreakdown.FooterRow.FindControl("txtCalcFabric4");
                      txtFabric4.CssClass = "do-not-allow-typing CaclFabric4";
                  }
                  commted by abhishek 1/2/2016   */
                //bool isIaDateEnabled = false;

                if (order.OrderBreakdown.Count > 0)
                {
                    // Find the OrderDetail with min Ex-Factory
                    order.OrderBreakdown.Sort((od1, od2) => od1.ExFactory.CompareTo(od2.ExFactory));

                    OrderDetail od = order.OrderBreakdown[0];

                //    if ((od.IAFabric1 && od.Fabric1 != string.Empty && od.Fabric2 == string.Empty &&
                //         od.Fabric3 == string.Empty && od.Fabric4 == string.Empty)
                //        ||
                //        (od.IAFabric1 && od.Fabric1 != string.Empty && od.IAFabric2 && od.Fabric2 != string.Empty &&
                //         od.Fabric3 == string.Empty && od.Fabric4 == string.Empty)
                //        ||
                //        (od.IAFabric1 && od.Fabric1 != string.Empty && od.IAFabric2 && od.Fabric2 != string.Empty &&
                //         od.IAFabric3 && od.Fabric3 != string.Empty && od.Fabric4 == string.Empty)
                //        ||
                //        (od.IAFabric1 && od.Fabric1 != string.Empty && od.IAFabric2 && od.Fabric2 != string.Empty &&
                //         od.IAFabric3 && od.Fabric3 != string.Empty && od.IAFabric4 && od.Fabric4 != string.Empty))
                //    {
                //        isIaDateEnabled = false;
                //    }
                //    else
                //    {
                //        isIaDateEnabled = true;
                //    }
                }


                List<OrderLimitation> orderLimitationCollection = OrderControllerInstance.GetOrderLimitation(OrderId);
                if (orderLimitationCollection.Count != 0)
                {
                    OrderLimitation orderLimitation = orderLimitationCollection[0];

                    hdnBarrierDaysCMT.Value = orderLimitation.BarrierDaysCMT.ToString();
                    lblBasicCMT.Text = orderLimitation.BasicCMT.ToString();
                    lblBasicBarrierDays.Text = orderLimitation.BasicBarrierDays.ToString();

                    if (orderLimitation.BarrierDaysCMT != 0)
                    {
                        int OldCMT = orderLimitation.BasicCMT;
                        int NewCMT = orderLimitation.BarrierDaysCMT;
                        int CalcBarrierDays = orderLimitation.CalcBarrierDays;

                        lblLeadTimeMsg.Text = "Prod Time After Lead Time Changes : ";
                        lblLeadTime.Text = CalcBarrierDays.ToString();

                        lblCMTmsg.Text = "CMT After Lead Time Changes : ";
                        lblCalcCMT.Text = "Rs. " + NewCMT.ToString();

                        double profitloss = (OldCMT - NewCMT) * order.TotalQuantity;
                        string sProfitloss = "";
                        if (profitloss < 0)
                        {
                            sProfitloss = profitloss.ToString();
                            sProfitloss = sProfitloss.Substring(1, sProfitloss.Length - 1);
                        }
                        lblProdLossMsg.Text = "Loss : ";
                        lblProdLoss.Text = "Rs. " + sProfitloss;
                    }
                    else
                    {
                        lblLeadTimeMsg.Text = "";
                        lblLeadTime.Text = "";
                        lblCMTmsg.Text = "";
                        lblCalcCMT.Text = "";
                        lblProdLossMsg.Text = "";
                        lblProdLoss.Text = "";
                    }


                    // Find the OrderDetail with min Ex-Factory
                    order.OrderBreakdown.Sort((od1, od2) => od1.ExFactory.CompareTo(od2.ExFactory));

                    if (order.OrderBreakdown.Count > 0)
                    {
                        OrderDetail od = order.OrderBreakdown[0];

                        int iAdays = 0;
                        if ((od.IAFabric1 && od.Fabric1 != string.Empty && od.Fabric2 == string.Empty &&
                             od.Fabric3 == string.Empty && od.Fabric4 == string.Empty)
                            ||
                            (od.IAFabric1 && od.Fabric1 != string.Empty && od.IAFabric2 && od.Fabric2 != string.Empty &&
                             od.Fabric3 == string.Empty && od.Fabric4 == string.Empty)
                            ||
                            (od.IAFabric1 && od.Fabric1 != string.Empty && od.IAFabric2 && od.Fabric2 != string.Empty &&
                             od.IAFabric3 && od.Fabric3 != string.Empty && od.Fabric4 == string.Empty)
                            ||
                            (od.IAFabric1 && od.Fabric1 != string.Empty && od.IAFabric2 && od.Fabric2 != string.Empty &&
                             od.IAFabric3 && od.Fabric3 != string.Empty && od.IAFabric4 && od.Fabric4 != string.Empty))
                        {
                            //txtIA.Text = "0";
                            iAdays = 0;
                        }
                        else
                        {
                            iAdays = orderLimitation.IADays;
                            //txtIA.Text = orderLimitation.IADays.ToString();
                        }

                        //txtBIH.Text = orderLimitation.BIHDays.ToString();

                    }

                    if (OrderId == orderLimitation.OrderID)
                    {
                        if (orderLimitation.FabricComments.IndexOf("$$") > -1)
                        {
                            txtFabric.Text = orderLimitation.FabricComments.Replace("$$", "\n");
                            ;
                        }
                        else
                        {
                            txtFabric.Text = orderLimitation.FabricComments;
                        }
                        txtAccessories.Text = orderLimitation.AccessoriesComments;
                        //txtProduction.Text = orderLimitation.ProductionComments;
                        //txtMerchandising.Text = orderLimitation.MerchandisingComments;
                        //txtIkandiComments.Text = orderLimitation.IkandiComments;

                        if (orderLimitation.FabricApprovedByMgr == 1)
                        {
                            chkboxFabricMgr.Checked = true;
                            chkboxFabricMgr.Enabled = false;
                            txtFabric.CssClass = "do-not-allow-typing";
                        }
                        if (orderLimitation.AccessoriesApprovedByMgr == 1)
                        {
                            chkboxAccessoriesMgr.Checked = true;
                            chkboxAccessoriesMgr.Enabled = false;
                            txtAccessories.CssClass = "do-not-allow-typing";
                        }

                        //if (orderLimitation.MerchandisingApprovedByMgr == 1)
                        //{
                        //    chkboxMerchandisingMgr.Checked = true;
                        //    chkboxMerchandisingMgr.Enabled = false;
                        //    txtMerchandising.CssClass = "do-not-allow-typing";
                        //}
                    }
                }
                else
                {
                    string[] sBaseCMT = OrderControllerInstance.GetCMTbyOrderID(OrderId, 0);
                    if (sBaseCMT.Length > 0)
                    {
                        lblBasicCMT.Text = sBaseCMT[0].ToString();
                        lblBasicBarrierDays.Text = sBaseCMT[1].ToString();
                        lblCMTmsg.Text = "";
                    }

                }

            }
        }

        private void SaveLimitation()
        {
            //System.Diagnostics.Debugger.Break();

            OrderLimitation orderLimitation = new OrderLimitation();
            List<OrderLimitation> orderLimitationCollection = OrderControllerInstance.GetOrderLimitation(OrderId);
            OrderLimitation orderLimitation1 = new OrderLimitation();
            if (orderLimitationCollection.Count > 0)
            {
                orderLimitation1 = orderLimitationCollection[0];
            }

            orderLimitation.OrderID = OrderId;

            if (!String.IsNullOrEmpty(txtFabric.Text) && orderLimitation1 != null &&
                !string.IsNullOrEmpty(orderLimitation1.FabricComments))
            {
                if (txtFabric.Text.Replace("\n", "").ToUpper() ==
                    orderLimitation1.FabricComments.Replace("$$", "").Replace("\n", "").ToUpper())
                    orderLimitation.FabricComments = "";
                else
                    orderLimitation.FabricComments = txtFabric.Text;
            }
            else
            {
                orderLimitation.FabricComments = txtFabric.Text;
            }

            if (!String.IsNullOrEmpty(txtAccessories.Text))
                orderLimitation.AccessoriesComments = txtAccessories.Text;


            //if (!String.IsNullOrEmpty(txtMerchandising.Text))
            //    orderLimitation.MerchandisingComments = txtMerchandising.Text;

            if (!String.IsNullOrEmpty(txtIkandiComments.Text))
                orderLimitation.IkandiComments = txtIkandiComments.Text;

            Common.Order order = OrderControllerInstance.GetOrder(OrderId);

            {
                order.BIHdate = DateTime.MinValue;
            }

            if ((ApplicationHelper.LoggedInUser.UserData.Designation == Designation.BIPL_Fabrics_Manager) || ApplicationHelper.LoggedInUser.UserData.Designation == Designation.BIPL_Sourcing_Director)
            {
                orderLimitation.FabricApprovedByMgr = Convert.ToInt32(Convert.ToBoolean(chkboxFabricMgr.Checked));
                orderLimitation.AccessoriesApprovedByMgr = orderLimitation1.AccessoriesApprovedByMgr;
                orderLimitation.MerchandisingApprovedByMgr = orderLimitation1.MerchandisingApprovedByMgr;
                orderLimitation.ProductionApprovedByMgr = orderLimitation1.ProductionApprovedByMgr;
                orderLimitation.AccessoriesApprovedOn = orderLimitation1.AccessoriesApprovedOn;
                orderLimitation.MerchandisingApprovedOn = orderLimitation1.MerchandisingApprovedOn;
                orderLimitation.ProductionApprovedOn = orderLimitation1.ProductionApprovedOn;

                if ((chkboxFabricMgr.Checked))
                    orderLimitation.FabricApprovedOn = orderLimitation1.FabricApprovedByMgr == 0
                                                           ? Convert.ToDateTime(hiddenFab.Value)
                                                           : orderLimitation1.FabricApprovedOn;

                TextBox txtCalcFabric1 = (TextBox)(grdOrderBreakdown.FooterRow.FindControl("txtCalcFabric1"));
                orderLimitation.CalcFabric1Days = txtCalcFabric1.Text == "" ? 0 : Convert.ToInt32(txtCalcFabric1.Text);

                TextBox txtCalcFabric2 = (TextBox)(grdOrderBreakdown.FooterRow.FindControl("txtCalcFabric2"));
                orderLimitation.CalcFabric2Days = txtCalcFabric2.Text == "" ? 0 : Convert.ToInt32(txtCalcFabric2.Text);

                TextBox txtCalcFabric3 = (TextBox)(grdOrderBreakdown.FooterRow.FindControl("txtCalcFabric3"));
                orderLimitation.CalcFabric3Days = txtCalcFabric3.Text == "" ? 0 : Convert.ToInt32(txtCalcFabric3.Text);

                TextBox txtCalcFabric4 = (TextBox)(grdOrderBreakdown.FooterRow.FindControl("txtCalcFabric4"));
                orderLimitation.CalcFabric4Days = txtCalcFabric4.Text == "" ? 0 : Convert.ToInt32(txtCalcFabric4.Text);

            }
            else
            {
                orderLimitation.FabricApprovedByMgr = orderLimitation1.FabricApprovedByMgr;
                orderLimitation.FabricApprovedOn = orderLimitation1.FabricApprovedOn;
            }

            if ((ApplicationHelper.LoggedInUser.UserData.Designation == Designation.BIPL_Accessory_Manager))
            {
                orderLimitation.AccessoriesApprovedByMgr =
                    Convert.ToInt32(Convert.ToBoolean(chkboxAccessoriesMgr.Checked));
                orderLimitation.FabricApprovedByMgr = orderLimitation1.FabricApprovedByMgr;
                orderLimitation.MerchandisingApprovedByMgr = orderLimitation1.MerchandisingApprovedByMgr;
                orderLimitation.ProductionApprovedByMgr = orderLimitation1.ProductionApprovedByMgr;
                orderLimitation.FabricApprovedOn = orderLimitation1.FabricApprovedOn;
                orderLimitation.MerchandisingApprovedOn = orderLimitation1.MerchandisingApprovedOn;
                orderLimitation.ProductionApprovedOn = orderLimitation1.ProductionApprovedOn;

                if ((chkboxAccessoriesMgr.Checked))
                    orderLimitation.AccessoriesApprovedOn = orderLimitation1.AccessoriesApprovedByMgr == 0
                                                                ? Convert.ToDateTime(hiddenAcc.Value)
                                                                : orderLimitation1.AccessoriesApprovedOn;
            }
            else
            {
                orderLimitation.AccessoriesApprovedByMgr = orderLimitation1.AccessoriesApprovedByMgr;
                orderLimitation.AccessoriesApprovedOn = orderLimitation1.AccessoriesApprovedOn;
            }

            if ((ApplicationHelper.LoggedInUser.UserData.Designation == Designation.BIPL_Production_Manager))
            {
                //orderLimitation.ProductionApprovedByMgr = Convert.ToInt32(Convert.ToBoolean(chkboxProductionMgr.Checked));
                orderLimitation.FabricApprovedByMgr = orderLimitation1.FabricApprovedByMgr;
                orderLimitation.MerchandisingApprovedByMgr = orderLimitation1.MerchandisingApprovedByMgr;
                orderLimitation.AccessoriesApprovedByMgr = orderLimitation1.AccessoriesApprovedByMgr;
                orderLimitation.FabricApprovedOn = orderLimitation1.FabricApprovedOn;
                orderLimitation.MerchandisingApprovedOn = orderLimitation1.MerchandisingApprovedOn;
                orderLimitation.AccessoriesApprovedOn = orderLimitation1.AccessoriesApprovedOn;

                //if ((chkboxProductionMgr.Checked))
                //    orderLimitation.ProductionApprovedOn = orderLimitation1.ProductionApprovedByMgr == 0
                //                                               ? Convert.ToDateTime(hiddenProd.Value)
                //                                               : orderLimitation1.ProductionApprovedOn;
            }
            else
            {
                orderLimitation.ProductionApprovedByMgr = orderLimitation1.ProductionApprovedByMgr;
                orderLimitation.ProductionApprovedOn = orderLimitation1.ProductionApprovedOn;
            }

            //if ((ApplicationHelper.LoggedInUser.UserData.Designation == Designation.BIPL_Merchandising_Manager))
            //{
            //    //orderLimitation.MerchandisingApprovedByMgr =
            //    //    Convert.ToInt32(Convert.ToBoolean(chkboxMerchandisingMgr.Checked));
            //    orderLimitation.AccessoriesApprovedByMgr = orderLimitation1.AccessoriesApprovedByMgr;
            //    orderLimitation.FabricApprovedByMgr = orderLimitation1.FabricApprovedByMgr;
            //    orderLimitation.ProductionApprovedByMgr = orderLimitation1.ProductionApprovedByMgr;
            //    orderLimitation.AccessoriesApprovedOn = orderLimitation1.AccessoriesApprovedOn;
            //    orderLimitation.FabricApprovedOn = orderLimitation1.FabricApprovedOn;
            //    orderLimitation.ProductionApprovedOn = orderLimitation1.ProductionApprovedOn;

            //    if ((chkboxMerchandisingMgr.Checked))
            //        if (orderLimitation1.MerchandisingApprovedByMgr == 0)
            //            orderLimitation.MerchandisingApprovedOn = Convert.ToDateTime(hiddenMerch.Value);
            //        else
            //            orderLimitation.MerchandisingApprovedOn = orderLimitation1.MerchandisingApprovedOn;
            //}
            //else
            //{
            //    orderLimitation.MerchandisingApprovedByMgr = orderLimitation1.MerchandisingApprovedByMgr;
            //    orderLimitation.MerchandisingApprovedOn = orderLimitation1.MerchandisingApprovedOn;
            //}
            
            orderLimitation.BasicCMT = Convert.ToInt32(lblBasicCMT.Text);
            orderLimitation.BasicBarrierDays = Convert.ToInt32(lblBasicBarrierDays.Text);
            orderLimitation.CalcBarrierDays = Convert.ToInt32(hdnCalcBarrierDays.Value);
            orderLimitation.BarrierDaysCMT = Convert.ToInt32(hdnBarrierDaysCMT.Value);

            orderLimitation.Order = new Common.Order();
            orderLimitation.Order.OrderBreakdown = new List<OrderDetail>();

            foreach (GridViewRow row in grdOrderBreakdown.Rows)
            {
                if (row.RowType != DataControlRowType.DataRow) continue;

                HiddenField hdnDetailId = row.FindControl("hiddenOrderDetailID") as HiddenField;
                OrderDetail od = new OrderDetail();
                od.OrderDetailID = Convert.ToInt32(hdnDetailId.Value);
                TextBox bihFabric1 = row.FindControl("txtBihFabric1") as TextBox;
                TextBox bihFabric2 = row.FindControl("txtBihFabric2") as TextBox;
                TextBox bihFabric3 = row.FindControl("txtBihFabric3") as TextBox;
                TextBox bihFabric4 = row.FindControl("txtBihFabric4") as TextBox;
                TextBox PcdDate = row.FindControl("txtPCD") as TextBox;


                od.BIHFabric1 = bihFabric1.Text == "" ? DateTime.MinValue : DateHelper.ParseDate(bihFabric1.Text).Value;

                od.BIHFabric2 = bihFabric2.Text == "" ? DateTime.MinValue : DateHelper.ParseDate(bihFabric2.Text).Value;

                od.BIHFabric3 = bihFabric3.Text == "" ? DateTime.MinValue : DateHelper.ParseDate(bihFabric3.Text).Value;

                od.BIHFabric4 = bihFabric4.Text == "" ? DateTime.MinValue : DateHelper.ParseDate(bihFabric4.Text).Value;

                od.PCDDATE = PcdDate.Text == "" ? DateTime.MinValue : DateHelper.ParseDate(PcdDate.Text).Value;



                od.OrderID = OrderId;
                orderLimitation.Order.OrderBreakdown.Add(od);
            }

            // update by Ravi kumar for OB and Risk task ON 31/7/2015
            string LineIntimation = "";
            int daysdiff = Convert.ToInt32(hdnDaysDiff.Value);
            int IsPCDChange = Convert.ToInt32(hdnIsPCD_Change.Value);
            if ((daysdiff > 0) || (daysdiff == 0))
            {
                if ((IsPCDChange == -1) || (IsPCDChange == 1))
                {
                    if ((IsPCDChange != 0) && (IsPCDChange != -1))
                    {
                        LineIntimation = OrderControllerInstance.LineUpdateByLimitation(orderLimitation.OrderID, daysdiff);
                    }
                    if (LineIntimation == "")
                    {
                        if (OrderId == orderLimitation1.OrderID)
                        {
                            LineIntimation = OrderControllerInstance.UpdateOrderLimitation(orderLimitation);
                        }
                        else
                        {
                            LineIntimation = OrderControllerInstance.AddOrderLimitation(orderLimitation);
                        }
                    }
                    if (LineIntimation != "")
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "ShowMsg", "alert('" + LineIntimation + "');", true);
                        hdnIsPCD_Change.Value = "-1";
                        BindControls();
                        return;
                    }
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "ShowAlerMsg", "ShowAlerMsg();", true);
                    hdnDaysDiff.Value = "0";
                    hdnIsPCD_Change.Value = "-1";
                    BindControls();
                    return;
                }
            }
            else
            {

                Page.ClientScript.RegisterStartupScript(this.GetType(), "ShowAlerMsg", "ShowAlerMsg();", true);
                hdnDaysDiff.Value = "0";
                hdnIsPCD_Change.Value = "-1";
                BindControls();
                return;
            }


            pnlForm.Visible = false;
            pnlMessage.Visible = true;
        }
        //Added By abhishek on 29/7/2015
        //---------------------------------------------------------Updated Remarks--------------------------------------------------------------------//
        public void updateriskRemarks(int OrderID)
        {
        AdminController objAdminController = new AdminController();
            DataTable dt = new DataTable();
            DataTable splitdt = new DataTable();
            dt = objAdminController.getcountRiskremarks(OrderID);
            DataTable dtfillterrow = new DataTable();
            int SequenceNo = 0;
            foreach (DataRow row in dt.Rows) // Loop over the rows.
            {
                
               // int Order_ID = Convert.ToInt32(row["OrderID"]);



                dtfillterrow = objAdminController.getreptedremakrsWithStyleid(OrderID);
               



                if (dtfillterrow.Rows.Count > 0)
                {



                    foreach (DataRow rows in dtfillterrow.Rows)
                    {
                        string FabricComments_1 = "";
                        string Accessories_1 = "";
                        int StyleID_1 = -1;
                        string CreatedOn_1 = "";
                        int CreatedBy_1 = -1;
                        string stylecode_1 = "";

                        int UpdatedBy_1 = -1;

                        string UpdatedOn_1 = "";
                        string FabricApprovedOn = "";
                        string AccessoriesApprovedOn = "";

                        FabricComments_1 = (rows["FabricComments"]).ToString();
                        Accessories_1 = rows["Accessories"].ToString();

                        StyleID_1 = Convert.ToInt32(rows["StyleID"]);

                        //if (rows["CreatedOn"] != DBNull.Value)
                        //{
                        //    CreatedOn_1 = (rows["CreatedOn"]).ToString();

                        //}
                        //if (rows["CreatedBy"] != DBNull.Value)
                        //{
                        //    CreatedBy_1 = Convert.ToInt32(rows["CreatedBy"]);

                        //}
                        if (rows["stylecode"] != DBNull.Value)
                        {
                            stylecode_1 = (rows["stylecode"]).ToString();

                        }
                        //if (rows["UpdatedBy"] != DBNull.Value)
                        //{
                        //    UpdatedBy_1 = Convert.ToInt32(rows["UpdatedBy"]);

                        //}

                        //if (rows["UpdatedOn"] != DBNull.Value)
                        //{
                        //    UpdatedOn_1 = (rows["UpdatedOn"]).ToString();

                        //}

                        if (rows["FabricApprovedOn"] != DBNull.Value)
                        {
                            FabricApprovedOn = (rows["FabricApprovedOn"]).ToString();

                        }

                        if (rows["AccessoriesApprovedOn"] != DBNull.Value)
                        {
                            AccessoriesApprovedOn = (rows["AccessoriesApprovedOn"]).ToString();

                        }



                        SequenceNo = SequenceNo + 1;
                        //updated by abhishek on 17/8/2015
                        int result = objAdminController.insertOrderLimitationremarks(FabricComments_1, Accessories_1, StyleID_1, CreatedOn_1, CreatedBy_1, stylecode_1, UpdatedBy_1, @UpdatedOn_1, SequenceNo, FabricApprovedOn, AccessoriesApprovedOn,OrderId);
                        //end on 17/8/2015
                        FabricComments_1 = "";
                        Accessories_1 = "";

                    }
                    SequenceNo = 0;



                }

            }


            }
        //---------------------------------------------------------END--------------------------------------------------------------------------------//

        //END
        #endregion
    }
}

