<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProductionPlanning.ascx.cs"
    Inherits="iKandi.Web.ProductionPlanningList" %>
    <script type="text/javascript">

        $(function () {
            $(".th").datepicker({ dateFormat: 'dd M y (D)' });
            
        });
  
  </script>
<script type="text/javascript">
    var hdnPathClientId = '<%=hdnPath.ClientID %>';
    $(document).ready(function () {
        // added by yaten
        $(".loadingimage").hide();
        var totalBalanceQuantity = 0;
        var defaultShipmentQuantity = 0;

        var txtShipmentQuantity = $('input[type=text].shipped-quantity', '#main_content');
        var ClientDDClientID = '<%=ddlClients.ClientID%>';

        $("#" + ClientDDClientID, "#main_content").children(":first").text("ALL");

        txtShipmentQuantity.focus(function () {
            defaultShipmentQuantity = $(this).val();
            var orderDetailId = $(this).parents('tr').find('span.order-detail-id').text();
            var productionPlanningID = $(this).parents('tr').find('span.production-planning-id').text();
            totalBalanceQuantity = parseInt($('span.balance-quantity' + orderDetailId.toString() + productionPlanningID.toString()).text()) + parseInt(defaultShipmentQuantity);
            //alert(totalBalanceQuantity);
        });

        txtShipmentQuantity.change(function () {
            if ($(this).val() == '') $(this).val(0);

            var objRow = $(this).parents('tr');
            var orderDetailId = objRow.find('span.order-detail-id').text();
            var productionPlanningID = $(this).parents('tr').find('span.production-planning-id').text();
            var reasonBox = objRow.find('.reason-short-coming');

            var balanceQty = 0;

            if (objRow.find('input[type=checkbox]').attr('checked')) {
                // alert("this");
                if (parseInt($(this).val()) > parseInt(objRow.find('span.hidden-shipped-quantity').text()))
                    $(this).val(objRow.find('span.hidden-shipped-quantity').text());
                reasonBox.attr({ disabled: false });
            }
            else {
                // alert(objRow.find('span.mode-name').text());

                if (parseInt($(this).val()) > totalBalanceQuantity || objRow.find('span.mode-name').text().toLowerCase().search('x') > -1) {
                    $(this).val(defaultShipmentQuantity); //alert($(this).val());
                }
                balanceQty = parseInt(totalBalanceQuantity) - parseInt($(this).val()); //alert("bal = " + balanceQty);
                if (balanceQty != 0)
                    reasonBox.attr({ disabled: false });
                else
                    reasonBox.attr({ disabled: true });
            }

            $('span.balance-quantity' + orderDetailId.toString() + productionPlanningID.toString()).text(balanceQty);

        });

        $('.chk-shipment-planning').change(function () {
            var orderDetailId = $(this).parents('tr').find('span.order-detail-id').text();
            var productionPlanningID = $(this).parents('tr').find('span.production-planning-id').text();
            var lblBalance = $(this).parents('td').find('span.balance-shipment-quantity' + orderDetailId.toString() + productionPlanningID.toString());
            var objRow = $(this).parents("tr");
            var rowindex = objRow.get(0).rowIndex;
            //alert(rowindex);

            if ($(this).find('input').attr('checked')) {
                lblBalance.text('0');
            }
            else {
                var totalShipmentQuantity = parseInt($(this).parents('tr').find('span.hidden-shipped-quantity').text());

                //   if ($(this).parents('tr').find('span.mode-name').text().toLowerCase().search('/h') == -1 && $(this).parents('tr').find('span.mode-name').text().toLowerCase().search('/bh') == -1) {

                if ($(this).parents('tr').find('span.mode-name').text().toLowerCase().search('x') > -1) {

                    objRow.find('input[type=text].shipped-quantity').val(totalShipmentQuantity);

                    lblBalance.text('0');
                }
                else {
                    var shipmentQuantity = parseInt(objRow.find('input[type=text].shipped-quantity').val());
                    lblBalance.text(totalShipmentQuantity - shipmentQuantity);
                }
            }
        });
    });

    var isExpanded = true;
    function showHide(prmThis) {
        var gridObj = $("#<%=grdOrderAvailable.ClientID %>");
        var divObj = $("#divOrderAvailable");

        if (isExpanded) {
            divObj.hide();
            gridObj.hide();
            isExpanded = false;
            $(prmThis).text("Expand");
        }
        else {
            divObj.show();
            gridObj.show();
            isExpanded = true;
            $(prmThis).text("Collapse");
        }
    }

    var effectedRow;

    function LaunchPackingList(packingId, orderId, productionPlanningID, sender) {
        effectedRow = $(sender).parents('tr');

        if (packingId == -1)
            ShowPopupWindow(GetUrlWithDummyQueryString('/Internal/Packing/PackingList.aspx?oid=' + orderId + '&pid=' + productionPlanningID), "Packing List", 'UpdatePackingData', '1100px', '900px');
        else
            ShowPopupWindow(GetUrlWithDummyQueryString('/Internal/Packing/PackingList.aspx?pid=' + packingId + '&pid=' + productionPlanningID), "Packing List", 'UpdatePackingData', '1100px', '900px');
    }

    function UpdatePackingData(result) {
        var splittedResult = result.split('~~');

        if (splittedResult.length == 2) {
            window.location = GetUrlWithDummyQueryString(window.location.href);

            effectedRow.find('span.total-packages').text(splittedResult[0]);
            effectedRow.find('span.package-numbers').text(splittedResult[1]);
        }
    }



    // added by yaten



    function PrintPDFPPM(Url, height, width) {
        $(".loadingimage").show();
        $(".print").hide();

        var url;
        var ht = parseInt($(document).height()) - 130;
        var wd = parseInt($(document).width()) - 100;

        if (height != '' && height != null) {
            ht = height;
        }
        if (width != '' && width != null) {
            wd = width;
        }

        if (Url == '' || Url == null) {
            url = window.location.pathname;
        }
        else {
            url = Url;
        }

        if (url.indexOf('/') != 0)
            url = '/' + url;



        proxy.invoke("GeneratePDF", { Url: url + window.location.querystring, Width: wd, Height: ht }, function (result) {
            if ($.trim(result) == '') {

                jQuery.facebox("Some error occured on the server, please try again later.");
            }
            else {
                window.open(result);
                $(".loadingimage").hide();
                $(".print").show();
            }
        });





        return true;
    }


</script>
<div class="print-box">
    <div class="grid_heading" cssclass="item_list fixed-header">
        Orders Available for Shipment
    </div>
    <div>
    </div>
    <br />
    <a href="javascript:void(0)" onclick="showHide(this)">Collapse</a><br />
    <div class="form_box" id="divOrderAvailable">
        <asp:HiddenField ID="hdnPagesize" runat="server" />
        <asp:HiddenField ID="hdnPageIndex" runat="server" />
        <input type="hidden" id="hdnpageindex" name="hdnpageindex" />
        <input type="hidden" id="hdnpagesize" name="hdnpagesize" />
        <table width="500px" cellspacing="10">
            <tr>
                <td>
                    <asp:Label ID="lablsearch" Text="Search Text" runat="server" meta:resourcekey="lablsearchResource1"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtsearch" class="do-not-disable" MaxLength="40" runat="server"
                        meta:resourcekey="txtsearchResource1"></asp:TextBox>
                </td>
                <td>
                    Buyer
                </td>
                <td>
                    <asp:DropDownList ID="ddlClients" runat="server" CssClass="do-not-disable" meta:resourcekey="ddlClientsResource1">
                        <asp:ListItem Selected="True" Text="Select.." Value="-1" meta:resourcekey="ListItemResource1"></asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:Button ID="Button1" runat="server" class="go do-not-disable" OnClick="btnSearch_Click"
                        meta:resourcekey="Button1Resource1" Text="Search" />
                </td>
            </tr>
        </table>
        <asp:GridView ID="grdOrderAvailable" runat="server" OnRowDataBound="grdOrderPlanning_RowDataBound"
            AutoGenerateColumns="False" CssClass="item_list fixed-header" OnPageIndexChanging="grdOrderAvailable_PageIndexChanging"
            AllowPaging="True" EnableModelValidation="True" meta:resourcekey="grdOrderAvailableResource1">
            <Columns>
                <asp:TemplateField HeaderText="Order Date" HeaderStyle-CssClass="vertical_header"
                    ItemStyle-CssClass="vertical_text date_style" meta:resourcekey="TemplateFieldResource1">
                    <ItemTemplate>
                        <asp:Label ID="Label1" CssClass="date_style" runat="server" Text='<%# (Convert.ToDateTime((Eval("ParentOrder") as iKandi.Common.Order).OrderDate) == DateTime.MinValue)? "" : (Eval("ParentOrder") as iKandi.Common.Order).OrderDate.ToString("dd MMM yy (ddd)") %>'
                            meta:resourcekey="Label1Resource1"></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle CssClass="vertical_header"></HeaderStyle>
                    <ItemStyle CssClass="vertical_text date_style"></ItemStyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Serial No." ItemStyle-CssClass="quantity_style" meta:resourcekey="TemplateFieldResource2">
                    <ItemTemplate>
                        <asp:HiddenField ID="hdnSerial" runat="server" />
                        <asp:Label ID="Label21" runat="server" Text='<%# (Eval("ParentOrder") as iKandi.Common.Order).SerialNumber %>'
                            meta:resourcekey="Label21Resource1"></asp:Label>
                    </ItemTemplate>
                    <ItemStyle CssClass="quantity_style"></ItemStyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Style Number" meta:resourcekey="TemplateFieldResource3">
                    <ItemTemplate>
                        <nobr>
                        <asp:Label ID="Label2" runat="server" 
                            Text='<%# (Eval("ParentOrder") as iKandi.Common.Order).Style.StyleNumber %>' 
                            meta:resourcekey="Label2Resource1"></asp:Label>
                        </nobr>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Dept." HeaderStyle-CssClass="vertical_header" ItemStyle-CssClass="vertical_text"
                    meta:resourcekey="TemplateFieldResource4">
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" Text='<%# (Eval("ParentOrder") as iKandi.Common.Order).DepartmentName %>'
                            meta:resourcekey="Label3Resource1"></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle CssClass="vertical_header"></HeaderStyle>
                    <ItemStyle CssClass="vertical_text"></ItemStyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Unit" ItemStyle-CssClass="" meta:resourcekey="TemplateFieldResource5">
                    <ItemTemplate>
                        <asp:HiddenField ID="hdnUnit" runat="server" />
                        <asp:Label ID="Label31" runat="server" Text='<%# (Eval("Unit") as iKandi.Common.ProductionUnit).FactoryCode %>'
                            meta:resourcekey="Label31Resource1"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="LineItemNumber" HeaderText="Line Number" SortExpression="LineItemNumber"
                    HeaderStyle-CssClass="vertical_header" ItemStyle-CssClass=" vertical_text" meta:resourcekey="BoundFieldResource1">
                    <HeaderStyle CssClass="vertical_header"></HeaderStyle>
                    <ItemStyle CssClass=" vertical_text"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="ContractNumber" HeaderText="Contract" SortExpression="ContractNumber"
                    HeaderStyle-CssClass="vertical_header" ItemStyle-CssClass="vertical_text" meta:resourcekey="BoundFieldResource2">
                    <HeaderStyle CssClass="vertical_header"></HeaderStyle>
                    <ItemStyle CssClass="vertical_text"></ItemStyle>
                </asp:BoundField>
                <asp:TemplateField HeaderText="Description" HeaderStyle-CssClass="vertical_header"
                    ItemStyle-CssClass="vertical_text" meta:resourcekey="TemplateFieldResource6">
                    <ItemTemplate>
                        <asp:Label ID="Label4" Height="100px" runat="server" Text='<%# (Eval("ParentOrder") as iKandi.Common.Order).Description %>'
                            meta:resourcekey="Label4Resource1"></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle CssClass="vertical_header"></HeaderStyle>
                    <ItemStyle CssClass="vertical_text"></ItemStyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Quantity" ItemStyle-CssClass="numeric_text quantity_style"
                    meta:resourcekey="TemplateFieldResource7">
                    <ItemTemplate>
                        <asp:Label ID="lblPOQty" runat="server" CssClass="order-quantity quantity_style"
                            Text='<%# Eval("Quantity") %>' meta:resourcekey="lblPOQtyResource1"></asp:Label>
                    </ItemTemplate>
                    <ItemStyle CssClass="numeric_text quantity_style"></ItemStyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Main Fabric" SortExpression="Fabric1" HeaderStyle-CssClass="vertical_header"
                    ItemStyle-CssClass="vertical_text" meta:resourcekey="TemplateFieldResource8">
                    <ItemTemplate>
                        <asp:Label ID="lblFabric1" runat="server" class="fabcol" Height="100px" Text='<%# Eval("Fabric1") %>'
                            meta:resourcekey="lblFabric1Resource1"></asp:Label>
                        <div>
                            <asp:Label ID="lblCCGSM" runat="server" Height="100px" class="ccgsm_color" Text='<%# Eval("CCGSM") %>'
                                meta:resourcekey="lblCCGSMResource1"></asp:Label>
                        </div>
                    </ItemTemplate>
                    <HeaderStyle CssClass="vertical_header"></HeaderStyle>
                    <ItemStyle CssClass="vertical_text"></ItemStyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Color / Print" SortExpression="Fabric1Details" HeaderStyle-CssClass="vertical_header"
                    ItemStyle-CssClass="vertical_text" meta:resourcekey="TemplateFieldResource9">
                    <ItemTemplate>
                        <asp:Label ID="iblFabric1Detail" runat="server" Height="100px" Text='<%# Eval("Fabric1Details") %>'
                            meta:resourcekey="iblFabric1DetailResource1"></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle CssClass="vertical_header"></HeaderStyle>
                    <ItemStyle CssClass="vertical_text"></ItemStyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Top ETA" SortExpression="TopSentTarget" ItemStyle-CssClass=" date_style date_style"
                    meta:resourcekey="TemplateFieldResource10">
                    <ItemTemplate>
                        <asp:Label ID="lblTopEta" Width="120px" runat="server" Text='<%# (Convert.ToDateTime(Eval("TopSentTarget")) == DateTime.MinValue) ? "" : (Convert.ToDateTime( Eval("TopSentTarget")) ).ToString("dd MMM yy (ddd)" ) %>'
                            meta:resourcekey="lblTopEtaResource1"></asp:Label>
                    </ItemTemplate>
                    <ItemStyle CssClass=" date_style date_style"></ItemStyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Top Approval Actual" SortExpression="TopActualApproval"
                    ItemStyle-CssClass=" date_style date_style" meta:resourcekey="TemplateFieldResource11">
                    <ItemTemplate>
                        <asp:Label ID="lblTopApprovalActual" Width="120px" runat="server" Text='<%# (Convert.ToDateTime(Eval("TopActualApproval")) == DateTime.MinValue) ? "" : (Convert.ToDateTime( Eval("TopActualApproval")) ).ToString("dd MMM yy (ddd)" ) %>'
                            meta:resourcekey="lblTopApprovalActualResource1"></asp:Label>
                    </ItemTemplate>
                    <ItemStyle CssClass=" date_style date_style"></ItemStyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Mode" SortExpression="ModeName" meta:resourcekey="TemplateFieldResource12">
                    <ItemTemplate>
                        <asp:Label ID="lblMode" runat="server" Text='<%# Eval("ModeName") %>' ToolTip='<%# iKandi.BLL.CommonHelper.GetDeliveryModeToolTip(Convert.ToInt32(Eval("Mode"))) %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ExFactory" SortExpression="ExFactory" HeaderStyle-CssClass=""
                    HeaderStyle-Width="140px" ItemStyle-Width="140px" ItemStyle-CssClass="date_style bold_text"
                    meta:resourcekey="TemplateFieldResource13">
                    <ItemTemplate>
                        <asp:Label ID="lblExFactory" Width="140px" runat="server" Text='<%# (Convert.ToDateTime(Eval("ExFactory")) == DateTime.MinValue) ? "" : (Convert.ToDateTime(Eval("ExFactory"))).ToString("dd MMM yy (ddd)") %>'
                            meta:resourcekey="lblExFactoryResource1"></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle Width="140px"></HeaderStyle>
                    <ItemStyle CssClass="date_style bold_text" Width="140px"></ItemStyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Status" meta:resourcekey="TemplateFieldResource14">
                    <ItemTemplate>
                        <asp:HiddenField runat="server" ID="lblStatus" />
                        <asp:Label ID="Label221" runat="server" Text='<%# Eval("Status") %>' meta:resourcekey="Label221Resource1"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Shipping Remarks" SortExpression="SanjeevRemarks"
                    HeaderStyle-Width="200px" ItemStyle-Width="200px" ItemStyle-CssClass="remarks_text remarks_text2"
                    meta:resourcekey="TemplateFieldResource15">
                    <ItemTemplate>
                        <div style="width: 200px ! important;">
                            <%#(Eval("SanjeevRemarks").ToString().IndexOf("$$") > -1) ? Eval("SanjeevRemarks").ToString().Substring(Eval("SanjeevRemarks").ToString().LastIndexOf("$$") + 2 ) : Eval("SanjeevRemarks").ToString()%>
                        </div>
                        <br />
                        <img alt="Shipping Remarks" title="CLICK TO SEE REMARKS POPUP" src="/App_Themes/ikandi/images/remark.gif"
                            border="0" onclick="showRemarks(0,0,'<%# (Eval("SanjeevRemarks").ToString().IndexOf("$$") > -1) ? Eval("SanjeevRemarks").ToString().Replace("$$", "<br/>").Replace("\n", "").Replace("\r", "").Replace("/n/r", "").Replace(@"""", @"&quot;").Replace("'", "&#39;").Replace("&#39;", @"&rsquo;") : Eval("SanjeevRemarks").ToString().Replace("\n", "").Replace("\r", "").Replace("/n/r", "").Replace(@"""", @"&quot;").Replace("'", "&#39;").Replace("&#39;", @"&rsquo;") %>','SanjeevRemarks','PRODUCTION_PLANNING_FILE',0)" />
                    </ItemTemplate>
                    <HeaderStyle Width="200px"></HeaderStyle>
                    <ItemStyle CssClass="remarks_text remarks_text2" Width="200px"></ItemStyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Qty being shipped" ItemStyle-CssClass="numeric_text"
                    meta:resourcekey="TemplateFieldResource16">
                    <ItemTemplate>
                        <asp:TextBox runat="server" ID="txtShipmentQty" CssClass='<%# iKandi.Web.Components.PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.PRODUCTION_PLANNING_FORM_QTY_BEING_SHIPPED)? "shipped-quantity  numeric-field-without-decimal-places numeric_text":"shipped-quantity  numeric-field-without-decimal-places numeric_text do-not-allow-typing" %>'
                            Text='<%# Eval("ShipmentQty") %>' meta:resourcekey="txtShipmentQtyResource1"></asp:TextBox>
                        <asp:Label ID="lblPrevShipmentQty" runat="server" Text='<%# Eval("ShipmentQty") %>'
                            CssClass="hide_me hidden-shipped-quantity" meta:resourcekey="lblPrevShipmentQtyResource1"></asp:Label>
                    </ItemTemplate>
                    <ItemStyle CssClass="numeric_text"></ItemStyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="BAL To Be Shipped" ItemStyle-CssClass="numeric_text"
                    meta:resourcekey="TemplateFieldResource17">
                    <ItemTemplate>
                        <asp:Label ID="lblMode1" runat="server" Text='<%# Eval("ModeName") %>' ToolTip='<%# iKandi.BLL.CommonHelper.GetDeliveryModeToolTip(Convert.ToInt32(Eval("Mode"))) %>'
                            CssClass="mode-name hide_me"></asp:Label>
                        <asp:Label ID="lblBalanceQty" runat="server" Text='<%# Eval("BalanceQty") %>' CssClass='<%# "balance-shipment-quantity balance-quantity" + Eval("OrderDetailID") + Eval("ProductionPlanningID") %>'
                            meta:resourcekey="lblBalanceQtyResource1"></asp:Label>
                        <br />
                        <asp:CheckBox ID="chkIsShortShipment" runat="server" ToolTip="Is Short Shipment"
                            Checked='<%# Convert.ToBoolean(Eval("IsShortShipment")) %>' CssClass='<%# iKandi.Web.Components.PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.PRODUCTION_PLANNING_FORM_CHECK_TO_ENTER_SHIPMENT_PLANNING)? "chk-shipment-planning":"disable-checkbox chk-shipment-planning" %>'
                            meta:resourcekey="chkIsShortShipmentResource1"></asp:CheckBox>
                    </ItemTemplate>
                    <ItemStyle CssClass="numeric_text"></ItemStyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="REASONS FOR SHORT SHIPPING" meta:resourcekey="TemplateFieldResource18">
                    <ItemTemplate>
                        <asp:TextBox ID="txtReasonForShortComing" runat="server" Enabled="False" TextMode="MultiLine"
                            Width="100px" Height="70px" CssClass='<%# iKandi.Web.Components.PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.PRODUCTION_PLANNING_FORM_REASONS_FOR_SHORT_SHIPPING)? "reason-short-coming":"reason-short-coming do-not-allow-typing" %>'
                            Text='<%# Bind("ReasonForShortShipping") %>' meta:resourcekey="txtReasonForShortComingResource1"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ENTER PACKING LIST" SortExpression="" meta:resourcekey="TemplateFieldResource19">
                    <ItemTemplate>
                        <a href="javascript:void(0)" onclick='LaunchPackingList(<%# (Eval("Packing") as iKandi.Common.Packing).PackingID %>, <%# Eval("OrderID") %>, <%# Eval("ProductionPlanningID") %>,this)'>
                            <img border="0" src='/App_Themes/ikandi/images/<%# ((Eval("Packing") as iKandi.Common.Packing).PackingID > 0) ? (Convert.ToInt32(Eval("StatusModeID")) >= 17 ? "box-close-green.jpg" : "box-close-yellow.jpg") : "box-open-red.jpg" %>' /></a>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="PLANNED EX BY PRODUCTION" ItemStyle-CssClass="date_style"
                    meta:resourcekey="TemplateFieldResource20">
                    <ItemTemplate>
                        <asp:TextBox ID="txtPlannedEx" CssClass='<%# iKandi.Web.Components.PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.PRODUCTION_PLANNING_FORM_PLANNED_EX_BY_PRODUCTION) && Convert.ToInt32(Eval("StatusModeSequence")) >= 15 ? "th":"do-not-allow-typing" %>'
                            runat="server" Text='<%# (Convert.ToDateTime(Eval("PlannedEx")) == DateTime.MinValue) ? "" : (Convert.ToDateTime( Eval("PlannedEx")) ).ToString("dd MMM yy (ddd)" ) %>'
                            meta:resourcekey="txtPlannedExResource1"></asp:TextBox>
                        <asp:Label runat="server" ID="lblProductionPlanningID" Text='<%# Eval("ProductionPlanningID") %>'
                            CssClass="production-planning-id hide_me" meta:resourcekey="lblProductionPlanningIDResource1" />
                        <asp:Label runat="server" ID="lblIsPartShipment" Text='<%# Eval("IsPartShipment") %>'
                            CssClass="hide_me" meta:resourcekey="lblIsPartShipmentResource1" />
                        <asp:Label runat="server" ID="lblOrderDetailID" Text='<%# Eval("OrderDetailID") %>'
                            CssClass="order-detail-id hide_me" meta:resourcekey="lblOrderDetailIDResource1" />
                        <asp:Label runat="server" ID="lblPackingID" Text='<%# (Eval("Packing") as iKandi.Common.Packing).PackingID %>'
                            CssClass="packing-id hide_me" meta:resourcekey="lblPackingIDResource1" />
                    </ItemTemplate>
                    <ItemStyle CssClass="date_style"></ItemStyle>
                </asp:TemplateField>
            </Columns>
            <EmptyDataTemplate>
                <label>
                    No records Found</label></EmptyDataTemplate>
        </asp:GridView>
    </div>
    <br />
    <div>
        <asp:Image ID="LoadImg" Style="position: fixed; z-index: 52111; top: 20%; left: 50%;
            width: 5%;" CssClass="loadingimage" ImageUrl="~/App_Themes/ikandi/images1/loading7.gif"
            runat="server" meta:resourcekey="LoadImgResource1" />
        <asp:HiddenField runat="server" ID="hdnPath" />
        <asp:Button runat="server" ID="btnSubmit" CssClass="submit" Text="Submit" OnClick="btnSubmit_Click"
            meta:resourcekey="btnSubmitResource1" />
        <input type="button" id="btnPrint" class="print da_submit_button" value="Print" onclick="return PrintPDFPPM('','',1980);" />
    </div>
</div>
