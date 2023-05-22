using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using iKandi.BLL;
using iKandi.Common;
using iKandi.Web.Components;

namespace iKandi.Web
{
    public partial class PackingList : BasePage
    {
        private string distributionRow =
            @"<tr class='class{12} class{13}'><td style='width:9%; vertical-align:middle;'><input style='width:20px;' id='txtPkgNoFrom' name='txtPkgNoFrom' class='pkg-no-from numeric-field-without-decimal-places' value='{0}' /><span name='txtPkgNoFrom'>To</span><input style='width:20px;' id='txtPkgNoTo' name='txtPkgNoTo' class='pkg-no-to numeric-field-without-decimal-places' value='{1}' /></td><td style='vertical-align:middle;' class='packing-line-number'><div><span>{2}</span></div><div><span>{3}</span></div></td><td style='vertical-align:middle;'>-do-</td><td style='vertical-align:middle;'>-do-</td><td style='vertical-align:middle;'>-do-</td><td style='vertical-align:middle;'>-do-</td><td style='width:15%; vertical-align:middle;' class='packing-quantity'>{4}</td><td style='vertical-align:middle; font-weight:bold;' class='numeric_text'><div style='display:none;' class='packing-ratio'>{5}</div><div style='width:10px; float:left;'></div><div class='packing-total-quantity {14}'>{6}</div><input style='width:20px;' class='txt-is-ratio {15}' value='{7}'></td><td style='vertical-align:middle;'><img style='cursor:hand;' class='packing-delete-row' src='/App_Themes/ikandi/images/minus.gif' width='12' height='12'><div id='divRatio1'><span>Ratio:</span><input class='chk-is-ratio' type='checkbox' {8} ></div></td><td style='vertical-align:middle;'><span class='hide_me production_planning_id'>{9}</span><span class='hide_me'>#</span><span class='order-detail-id hide_me'>{10}</span><span style='display:none;' class='order-selection hide_me'><input checked type='checkbox' {11}></span></td></tr>";

        #region Properties

        private int OrderId
        {
            get
            {
                if (null != Request.QueryString["oid"])
                {
                    int oid;
                    if (int.TryParse(Request.QueryString["oid"], out oid))
                    {
                        if (oid > 0)
                            return oid;
                    }
                }
                return -1;
            }
        }
      
        private int ProductionUnitManagerId
        {
            get
            {
                if (ApplicationHelper.LoggedInUser.UserData.Designation == Designation.BIPL_Production_FactoryManager)
                    return ApplicationHelper.LoggedInUser.UserData.UserID;
                else if (ApplicationHelper.LoggedInUser.UserData.Designation ==
                         Designation.BIPL_Production_AssistantFactory)
                    return ApplicationHelper.LoggedInUser.UserData.ManagerID;
                return -1;
            }
        }
       

        private int PackingId
        {
            get
            {
                if (null != Request.QueryString["pid"])
                {
                    int pid;
                    if (int.TryParse(Request.QueryString["pid"], out pid))
                    {
                        if (pid > 0)
                            return pid;
                    }
                }
                return -1;
            }
        }

        private Packing PackingListItem
        {
            get
            {
                if (null == Session["packing"])
                {
                    Packing objPacking = InvoiceControllerInstance.GetPackingCollection(OrderId, PackingId,
                                                                                        ProductionUnitManagerId);
                    Session["packing"] = objPacking;
                }

                return (Packing) Session["packing"];
            }
            set { Session["packing"] = value; }
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            // System.Diagnostics.Debugger.Break();
            hdnPackingId.Value = PackingId.ToString();
            hdnOrderId.Value = OrderId.ToString();

            PackingListItem = null;
            var config = new BLL.Configuration.Configuration();

            if (null != PackingListItem && PackingId > 0)
            {
                txtExporter.Text = PackingListItem.Exporter;
                txtBuyerOrderNumber.Text = PackingListItem.BuyerOrderNumber;
                txtSerialNumber.Text = PackingListItem.SerialNumber;
                txtBuyerOrderDate.Text = PackingListItem.BuyerOrderDate.ToString("dd MMM yy (ddd)");
                txtBuyerOtherThanConsignee.Text = PackingListItem.BuyerOtherThanConsignee;
                txtConsignee.Text = PackingListItem.Consignee;
                txtCountryOfFinalDestination.Text = PackingListItem.CountryOfFinalDestination;
                txtCountryOfOriginOfGoods.Text = PackingListItem.CountryOfOriginOfGoods;
                txtDescriptionOfGoods.Text = PackingListItem.DescriptionOfGoods;
                //txtExporter.Text = PackingListItem.Exporter;
                txtFinalDestination.Text = PackingListItem.FinalDestination;
                txtFlightNumber.Text = PackingListItem.FlightNumber;
                txtInvoiceDate.Text = PackingListItem.InvoiceDate.ToString("dd MMM yy (ddd)");
                txtInvoiceNumber.Text = PackingListItem.InvoiceNumber;
                hdnInvoiceNumber.Value = PackingListItem.InvoiceNumber;
                txtMarksAndContainerNumber.Text = PackingListItem.MarksAndContainerNumber;
                //txtNumberAndKindOfPackages.Text = PackingListItem.NumberAndKindOfPackages;
                txtOtherReferences.Text = PackingListItem.OtherReferences;
                txtPlaceOfReceiptByPreCarrier.Text = PackingListItem.PlaceOfReceiptByPreCarrier;
                txtPortOfDischarge.Text = PackingListItem.PortOfDischarge;
                txtPortOfLoading.Text = PackingListItem.PortOfLoading;
                txtPreCarriageBy.Text = PackingListItem.PreCarriageBy;
                txtRemarks.Text = PackingListItem.Remarks;
                txtTermsOfDeliveryAndPayment.Text = PackingListItem.TermsOfDeliveryAndPayment;
                txtGrossWeight.Text = PackingListItem.TotalGrossWeight.ToString();
                txtNetWeight.Text = PackingListItem.TotalNetWeight.ToString();
            }
            else
            {
                txtExporter.Text = BLLCache.GetConfigurationKeyValue(Constants.BIPL_ADDRESS);
                txtPlaceOfReceiptByPreCarrier.Text = "NEW DELHI";
                txtPortOfLoading.Text = "MUMBAI";
                txtCountryOfOriginOfGoods.Text = "INDIA";
                txtConsignee.Text = BLLCache.GetConfigurationKeyValue(Constants.IKANDI_ADDRESS);
                txtPortOfDischarge.Text = "LONDON";
                txtCountryOfFinalDestination.Text = "UNITED KINGDOM";
                txtInvoiceDate.Text = DateTime.Today.ToString("dd MMM yy (ddd)");
                txtBuyerOrderDate.Text = DateTime.Today.ToString("dd MMM yy (ddd)");
                txtFinalDestination.Text = "UNITED KINGDOM";
            }

            if (null != PackingListItem && (PackingId > 0 || OrderId > 0))
            {
                if (PackingListItem.Distributions != null && PackingListItem.Distributions.Count > 0)
                {
                    //string mode = Constants.GetOrderDeliveryMode(PackingListItem.Distributions[0].Mode);
                    string mode = CommonHelper.GetOrderDeliveryMode(PackingListItem.Distributions[0].Mode);

                    if (mode.ToLower().EndsWith("/f"))
                        lblPackingMode.Text = "Flat";
                    else if (mode.ToLower().EndsWith("/h"))
                        lblPackingMode.Text = "Hanging";

                    if (mode.ToLower().Contains("a/"))
                    {
                        txtPortOfLoading.Text = "NEW DELHI";
                        txtPortOfDischarge.Text = "LONDON";
                    }
                    else if (mode.ToLower().Contains("s/"))
                    {
                        txtPortOfLoading.Text = "MUMBAI";
                        txtPortOfDischarge.Text = "FELIXTOWE";
                    }

                    if (mode.ToLower().Contains("fob"))
                    {
                        txtConsignee.Text = PackingListItem.Consignee;
                    }

                    gvPackingList.DataSource = GetDataTableForPacking(PackingListItem.Distributions);
                    gvPackingList.DataBind();
                }
            }

            if (PackingId != -1 && PackingListItem != null)
                BindPackingData();
        }

        private DataTable GetDataTableForPacking(List<PackingDistribution> objPackingDistributionList)
        {
            var dt = new DataTable();

            dt.Columns.Add("OrderDetailID");
            dt.Columns.Add("LineItemNumber");
            dt.Columns.Add("StyleNumber");
            dt.Columns.Add("FabricColor");
            dt.Columns.Add("Item");
            dt.Columns.Add("Fabric");
            dt.Columns.Add("Quantity");
            dt.Columns.Add("ShippingQuantity");
            dt.Columns.Add("ProductionPlanningID");
            dt.Columns.Add("ContractNumber");
            dt.Columns.Add("PackingID");

            dt.PrimaryKey = new[] {dt.Columns["ProductionPlanningID"]};

            foreach (PackingDistribution objPackingDistribution in objPackingDistributionList)
            {
                DataRow dr = dt.Rows.Find(objPackingDistribution.ProductionPlanningID);

                if (null == dr)
                {
                    dr = dt.NewRow();

                    dr["OrderDetailID"] = objPackingDistribution.OrderDetailID;
                    dr["LineItemNumber"] = objPackingDistribution.LineItemNumber;
                    dr["StyleNumber"] = objPackingDistribution.StyleNumber;
                    dr["FabricColor"] = objPackingDistribution.FabricColor;
                    dr["Item"] = objPackingDistribution.Item;
                    dr["Fabric"] = objPackingDistribution.Fabric;
                    dr["Quantity"] = objPackingDistribution.Quantity;
                    dr["ShippingQuantity"] = objPackingDistribution.ShippingQuantity;
                    dr["ProductionPlanningID"] = objPackingDistribution.ProductionPlanningID;
                    dr["ContractNumber"] = objPackingDistribution.ContractNumber;
                    dr["PackingID"] = PackingId;

                    dt.Rows.Add(dr);
                }
            }

            return dt;
        }

        private void BindPackingData()
        {
            ScriptManager.RegisterStartupScript(Page, typeof (Page), "AddDistributionRow", hiddenScript.Value, true);

            hiddenScript.Value = string.Empty;

            int isFirstRow = 1;

            if (PackingListItem.Dimensions != null && PackingListItem.Dimensions.Count > 0)
            {
                foreach (PackingDimension dimension in PackingListItem.Dimensions)
                {
                    hiddenScript.Value = hiddenScript.Value + "BindDimensionValues('" + dimension.Dimension + "', '" +
                                         dimension.Quantity + "', " + isFirstRow + ");";
                    isFirstRow = 0;
                }
            }

            ScriptManager.RegisterStartupScript(Page, typeof (Page), "AddDimensionRow",
                                                hiddenScript.Value +
                                                "CalculateAndShowTotal();CalculateAndShowSummary(false);", true);

            string isWritePermitted =
                PermissionHelper.IsWritePermittedOnColumn((int) AppModuleColumn.PACKING_LIST_TOP_SECTION).ToString().
                    ToLower();

            ScriptManager.RegisterStartupScript(Page, typeof (Page), "ApplyPermissions",
                                                "ApplyPermissionsOnPackingListColumns(" + isWritePermitted + ")", true);
        }

        protected void gvPackingList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            int totalSingles = 0;
            int totalRatioPack = 0;
            int ratioPack = 0;

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var ratioHTML = new StringBuilder();

                int counter = 0;
                DataRow drPackingDistribution = (e.Row.DataItem as DataRowView).Row;

                PackingDistribution objPackingDistribution =
                    PackingListItem.Distributions.Find(
                        delegate(PackingDistribution p)
                            {
                                return (p.ProductionPlanningID ==
                                        Convert.ToInt32(drPackingDistribution["ProductionPlanningID"]));
                            });

                foreach (OrderDetailSizes packingSize in objPackingDistribution.PackingSizes)
                {
                    if (counter == 12)
                    {
                        break;
                    }
                    var txtSize = gvPackingList.HeaderRow.FindControl("txtSize" + counter) as TextBox;
                    txtSize.Visible = true;
                    txtSize.Text = packingSize.Size;

                    txtSize = e.Row.FindControl("txtSize" + counter) as TextBox;
                    txtSize.Visible = true;
                    txtSize.Text = packingSize.Quantity.ToString();

                    //if (packingSize.Singles.Value > 0)
                    //{
                    totalSingles = totalSingles + packingSize.Singles.Value;

                    var lblSingles = e.Row.FindControl("lblSingles" + counter) as Label;
                    lblSingles.Visible = true;
                    lblSingles.Text = packingSize.Singles.Value.ToString();
                    lblSingles.CssClass = "singles-quantity";

                    e.Row.FindControl("divSingles").Visible = true;
                    // }

                    //if (packingSize.Ratio.Value > 0)
                    //{
                    totalRatioPack = totalRatioPack + packingSize.RatioPack.Value;

                    var lblRatio = e.Row.FindControl("lblRatio" + counter) as Label;
                    lblRatio.Visible = true;
                    lblRatio.Text = packingSize.Ratio.Value.ToString();
                    lblRatio.CssClass = "ratio-quantity";

                    ratioHTML.AppendFormat(
                        "<span style='width:30px; display:inline-block;' class='ratio-quantity' id='lblRatio" + counter +
                        "'>{0}</span>", packingSize.Ratio.Value);

                    ratioPack += packingSize.Ratio.Value;

                    e.Row.FindControl("divRatio").Visible = true;
                    // }

                    counter++;
                }

                (e.Row.FindControl("lblSinglesQuantity") as Label).Text = totalSingles.ToString();
                (e.Row.FindControl("lblRatioPackQuantity") as Label).Text = totalRatioPack.ToString();

                if (PackingId == -1)
                    return;

                List<PackingDistribution> packingDistributionList =
                    PackingListItem.Distributions.FindAll(
                        delegate(PackingDistribution p)
                            {
                                return (p.OrderDetailID == objPackingDistribution.OrderDetailID &&
                                        p.ProductionPlanningID == objPackingDistribution.ProductionPlanningID);
                            });

                //if (packingDistributionList.Count > 0)
                //{
                //    HtmlImage imgAddRow = e.Row.FindControl("imgAddRow") as HtmlImage;

                //    foreach (PackingDistribution item in packingDistributionList)
                //    {
                //        int sizeCounter = 0;
                //        string sizeValues = string.Empty;

                //        foreach (OrderDetailSizes size in item.PackingSizes)
                //        {
                //            if (sizeValues == string.Empty)
                //                sizeValues = item.Sizes[sizeCounter].ToString();
                //            else
                //                sizeValues = sizeValues + "~~" + item.Sizes[sizeCounter].ToString();

                //            sizeCounter++;
                //        }

                //        hiddenScript.Value = hiddenScript.Value + "var rowClass = AddPackingRow($('#' + '" + imgAddRow.ClientID + "'), true); BindPackingValues(rowClass, '" + item.PkgNoFrom + "', '" + item.PkgNoTo + "', '" + sizeValues + "', '" + item.IsRatioPack + "', '" + item.RatioPackQtyPerPkg + "');";
                //    }
                //}

                var sb = new StringBuilder();

                if (packingDistributionList.Count > 0)
                {
                    var imgAddRow = e.Row.FindControl("imgAddRow") as HtmlImage;

                    int i = 0;

                    foreach (PackingDistribution item in packingDistributionList)
                    {
                        int totalSize = 0;
                        int sizeCounter = 0;
                        string sizeValues = string.Empty;

                        var sizesString = new StringBuilder();

                        foreach (OrderDetailSizes size in item.PackingSizes)
                        {
                            if (sizeCounter == 16)
                            {
                                break;
                            }
                            int qty = item.Sizes[sizeCounter];
                            string txtValue = qty.ToString();
                            if (txtValue == "0")
                            {
                                txtValue = string.Empty;
                            }

                            if (item.IsRatioPack)
                                qty = 0;

                            totalSize += qty;

                            sizesString.AppendFormat(
                                "<input style='width:30px;' id='txtSize" + sizeCounter +
                                "' class='packing-quantity-assigned numeric-field-without-decimal-places " +
                                ((qty != 0 || item.IsRatioPack) ? "packing-quantity-assigned-value" : string.Empty) +
                                "' value='{0}'> ", txtValue);

                            //if (sizeValues == string.Empty)
                            //    sizeValues = qty.ToString();
                            //else
                            //    sizeValues = sizeValues + "~~" + qty.ToString();

                            sizeCounter++;
                        }

                        string qtyPCS = string.Empty;

                        int boxes = (item.PkgNoTo - item.PkgNoFrom + 1);

                        if (!item.IsRatioPack)
                        {
                            qtyPCS = totalSize + " X " + boxes + " = " + (totalSize*boxes) + " PCS";
                        }
                        else
                        {
                            qtyPCS = ratioPack + " X " + item.RatioPackQtyPerPkg + " = " +
                                     (ratioPack*item.RatioPackQtyPerPkg) + " X " + boxes + " = " +
                                     (ratioPack*item.RatioPackQtyPerPkg*boxes) + " PCS";
                        }

                        sb.AppendFormat(distributionRow,
                                        item.PkgNoFrom,
                                        item.PkgNoTo,
                                        item.ContractNumber,
                                        item.LineItemNumber,
                                        qtyPCS,
                                        ratioHTML,
                                        sizesString,
                                        item.RatioPackQtyPerPkg,
                                        ((item.IsRatioPack) ? "checked='true'" : string.Empty),
                                        objPackingDistribution.ProductionPlanningID,
                                        objPackingDistribution.OrderDetailID,
                                        string.Empty,
                                        objPackingDistribution.ProductionPlanningID.ToString(),
                                        objPackingDistribution.ProductionPlanningID + i.ToString(),
                                        ((item.IsRatioPack) ? "hide_me" : string.Empty),
                                        ((!item.IsRatioPack) ? "hide_me" : string.Empty));

                        i++;

                        //  hiddenScript.Value = hiddenScript.Value + "var rowClass = AddPackingRow($('#' + '" + imgAddRow.ClientID + "'), true); BindPackingValues(rowClass, '" + item.PkgNoFrom + "', '" + item.PkgNoTo + "', '" + sizeValues + "', '" + item.IsRatioPack + "', '" + item.RatioPackQtyPerPkg + "');";
                    }

                    hiddenScript.Value = hiddenScript.Value + @" LoadDistributionRows($('#' + '" + imgAddRow.ClientID +
                                         @"'), """ +
                                         sb.ToString().Replace("\n", "").Replace("\r", "").Replace("\n\r", "").Replace(
                                             "\r\n", "") + @""");";
                }
            }
        }

        protected void btnPrintList_Click(object sender, EventArgs e)
        {
            string fileName = DeliveryControllerInstance.GeneratePackingListExcel(OrderId, PackingId, "Packing_List");

            string FilePath = Path.Combine(Constants.TEMP_FOLDER_PATH, fileName);
            RenderFile(FilePath, fileName, Constants.CONTENT_TYPE_EXCEL);
        }
    }
}