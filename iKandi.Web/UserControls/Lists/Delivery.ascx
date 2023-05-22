<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Delivery.ascx.cs" Inherits="iKandi.Web.Delivery" %>
 <script type="text/javascript">

     $(function () {
         $(".th").datepicker({ dateFormat: 'dd M y (D)' });
     });
  
  </script> 
<script type="text/javascript">

    $(document).ready(function() {


        var ClientDDClientID = '<%=ddlClients.ClientID%>';

        $("#" + ClientDDClientID, "#main_content").children(":first").text("ALL");

        $("span.upload-booking-documents", "#main_content").each(function() {
            SetupLinks($(this))
        });
    });

    function SetupLinks(container) {
        var data = container.text();
        var dataArr = data.split("$$");

        var html = '';

        for (i = 0; i < dataArr.length; i = i + 2) {
            html += "<span><a  href='/upload/delivery/" + dataArr[i + 1] + "' target='_blank'>" + dataArr[i] + "</a></span><br />";
        }
        container.html(html);
    }

    function SendEmail(mode, bookingID) {
        ShowPopupWindow("/internal/delivery/SendShipmentEmail.aspx?mode=" + mode + "&bookingid=" + bookingID, "new", null, 950, 400);
        $(".go").click();
    }

    function ValidateOrdersForModeAndClient() {
        var isValidated = true;
        var isLoopFirstIteration = true;

        var previousModeId = 0;
        var previousClientId = 0;

        $('span.chk-booking input[type=checkbox]:checked').each(function() {
            if (isLoopFirstIteration) {
                previousModeId = $(this).parents('td').find('span.mode-id').text();
                previousClientId = $(this).parents('td').find('span.client-id').text();

                isLoopFirstIteration = false;
            }
            else {
                if (previousModeId != $(this).parents('td').find('span.mode-id').text() ||
                previousClientId != $(this).parents('td').find('span.client-id').text()) {
                    isValidated = false;
                    return;
                }
            }
        });

        if (!isValidated) {
            jQuery.facebox('Please select orders with same delivery mode and client');
            return false;
        }

    }

    function ShowShipmentPlanningOrders(shipmentId) {
        proxy.invoke("GetOrdersForShipmentPlanningAdvise", { shipmentId: shipmentId },
        function(result) { jQuery.facebox(result); }, onPageError, false, false);
    }
 
</script>

<div class="print-box">
    <div class="grid_heading">
        BOOKING AVAILABLE VIEW</div>
    <div>
        <table width="500px" cellspacing="10">
            <tr>
                <td>
                <nobr>
                    <asp:Label ID="lablsearch" Text="Search Text" runat="server"></asp:Label>
                    </nobr>
                </td>
                <td>
                    <asp:TextBox ID="txtsearch" class="do-not-disable" MaxLength="40" runat="server" Width="187px"></asp:TextBox>
                </td>
                <td>
                    Buyer
                </td>
                <td>
                    <asp:DropDownList ID="ddlClients" runat="server" CssClass="do-not-disable">
                        <asp:ListItem Selected="True" Text="Select.." Value="-1"></asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:Button ID="Button1" runat="server" class="go do-not-disable" OnClick="btnSearch_Click" Text="Search" />
                </td>
            </tr>
        </table>
    </div>
    <br />
    <div class="form_box">
        <asp:HiddenField ID="hdnPagesize" runat="server" />
        <asp:HiddenField ID="hdnPageIndex" runat="server" />
        <input type="hidden" id="hdnpageindex" name="hdnpageindex" />
        <input type="hidden" id="hdnpagesize" name="hdnpagesize" />
        <asp:GridView ID="grdOrderAvailable" runat="server" AutoGenerateColumns="False" CssClass="item_list fixed-header "
            OnRowDataBound="grdOrderAvailable_RowDataBound" OnPageIndexChanging="grdOrderAvailable_PageIndexChanging"
            AllowPaging="true" PageSize="10" Width="120%">
            <Columns>
                <asp:TemplateField HeaderText="Order Date" SortExpression="" HeaderStyle-CssClass="vertical_header"
                    ItemStyle-CssClass="vertical_text date_style">
                    <ItemTemplate>
                        <asp:Label ID="lblOrderDate" runat="server" Text='<%# (Convert.ToDateTime((Eval("ParentOrder") as iKandi.Common.Order).OrderDate) == DateTime.MinValue)? "" : (Eval("ParentOrder") as iKandi.Common.Order).OrderDate.ToString("dd MMM yy (ddd)") %>'></asp:Label>
                        <asp:HiddenField runat="server" ID="hdnProductionPlanningID" Value='<%# Eval("ProductionPlanningID") %>' />
                        <asp:HiddenField runat="server" ID="hdnOrderDetailID" Value='<%# Eval("OrderDetailID") %>' />
                        <asp:HiddenField runat="server" ID="hdnPackingID" Value='<%# (Eval("ShipmentPlanningOrder") as iKandi.Common.ShipmentPlanningOrder).PackingList.PackingID %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Serial No." SortExpression="" HeaderStyle-CssClass="vertical_header"
                    ItemStyle-CssClass="vertical_text">
                    <ItemTemplate>
                        <asp:HiddenField ID="hdnSerial" runat="server" />
                        <asp:Label ID="lblSerialNumber" runat="server" Text='<%# (Eval("ParentOrder") as iKandi.Common.Order).SerialNumber%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Style Number" SortExpression="" HeaderStyle-CssClass="vertical_header"
                    ItemStyle-CssClass="vertical_text">
                    <ItemTemplate>
                        <asp:Label ID="lblStyleNumber" runat="server" Text='<%# (Eval("ParentOrder") as iKandi.Common.Order).Style.StyleNumber %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Dept." SortExpression="" HeaderStyle-CssClass="vertical_header"
                    ItemStyle-CssClass="vertical_text">
                    <ItemTemplate>
                        <asp:Label ID="lblDepartmentName" Height="80px" runat="server" Text='<%# (Eval("ParentOrder") as iKandi.Common.Order).DepartmentName %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="LineItemNumber" HeaderText="Line Number" SortExpression="LineItemNumber"
                    HeaderStyle-CssClass="vertical_header" ItemStyle-CssClass="vertical_text" />
                <asp:BoundField DataField="ContractNumber" HeaderText="Contract" SortExpression="ContractNumber"
                    HeaderStyle-CssClass="vertical_header" ItemStyle-CssClass="vertical_text" />
                <asp:TemplateField HeaderText="Description" SortExpression="" HeaderStyle-CssClass="vertical_header"
                    ItemStyle-CssClass="vertical_text">
                    <ItemTemplate>
                        <asp:Label ID="lblDescription" runat="server" Height="150px" Text='<%# (Eval("ParentOrder") as iKandi.Common.Order).Description %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Main Fabric" SortExpression="Fabric1" HeaderStyle-CssClass="vertical_header"
                    ItemStyle-CssClass="vertical_text">
                    <ItemTemplate>
                        <asp:Label ID="lblMainFabric" Text='<%# Eval("Fabric1") %>' Height="150px" runat="server"></asp:Label><br />
                        <asp:Label ID="lblMainFabric11" Text='<%# Eval("CCGSM") %>' ForeColor="Blue" Font-Size="Smaller" Height="150px" runat="server"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Mode" SortExpression="Mode" HeaderStyle-CssClass="vertical_header"
                    ItemStyle-CssClass="vertical_text">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblMode" Text='<%# Eval("ModeName") %>' ToolTip='<%# iKandi.BLL.CommonHelper.GetDeliveryModeToolTip(Convert.ToInt32(Eval("Mode"))) %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="MDA" HeaderText="MDA Number" SortExpression="" HeaderStyle-CssClass="vertical_header"
                    ItemStyle-CssClass="vertical_text" />
                <asp:TemplateField HeaderText="Ex Factory" ItemStyle-CssClass="date_style">
                    <ItemTemplate>
                        <asp:Label ID="lblExFactory" Text=' <%# (Convert.ToDateTime(Eval("ExFactory")) == DateTime.MinValue) ? "" : (Convert.ToDateTime(Eval("ExFactory"))).ToString("dd MMM yy (ddd)")%>'
                            runat="server" Width="120px"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Status" HeaderStyle-CssClass="vertical_header" ItemStyle-CssClass="vertical_text">
                    <ItemTemplate>
                        <asp:HiddenField runat="server" ID="hdnStatus" />
                        <%# Eval("Status") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="SHIPMENT NO." SortExpression="" HeaderStyle-CssClass="vertical_header"
                    ItemStyle-CssClass="vertical_text">
                    <ItemTemplate>
                        <asp:Label ID="lblShipmentNumber" runat="server" Text='<%# (Eval("ShipmentPlanningOrder") as iKandi.Common.ShipmentPlanningOrder).ShipmentPlanning.ShipmentNumber %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="LANDING Date" SortExpression="" ItemStyle-CssClass="date_style">
                    <ItemTemplate>
                        <asp:Label ID="lblLandingETA" Width="120px" runat="server" Text='<%# (Convert.ToDateTime((Eval("ShipmentPlanningOrder") as iKandi.Common.ShipmentPlanningOrder).ShipmentPlanning.LandingETA) == DateTime.MinValue)? "" : (Eval("ShipmentPlanningOrder") as iKandi.Common.ShipmentPlanningOrder).ShipmentPlanning.LandingETA.ToString("dd MMM yy (ddd)") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="DC DATE" SortExpression="" ItemStyle-CssClass="date_style bold_text"
                    HeaderStyle-Width="130px">
                    <ItemTemplate>
                        <asp:Label ID="lblDCDate" Width="130px" ForeColor="Blue" runat="server" Text='<%# (Convert.ToDateTime(Eval("DC")) == DateTime.MinValue) ? "" : (Convert.ToDateTime( Eval("DC")) ).ToString("dd MMM yy (ddd)" )%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="POQTY" SortExpression="" ItemStyle-CssClass="numeric_text">
                    <ItemTemplate>
                        <asp:Label ID="lblQuantity" runat="server" CssClass="order-quantity" Text='<%# Convert.ToInt32( Eval("Quantity")).ToString("N0") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="BIPL <br/> INVOICE NO." SortExpression="" HeaderStyle-CssClass="vertical_header"
                    ItemStyle-CssClass="vertical_text">
                    <ItemTemplate>
                        <asp:Label ID="lblInvoiceNumber" runat="server" Text='<%# (Eval("ShipmentPlanningOrder") as iKandi.Common.ShipmentPlanningOrder).PackingList.InvoiceNumber %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="QTY Shipped" SortExpression="" HeaderStyle-CssClass="vertical_header"
                    ItemStyle-CssClass="numeric_text vertical_text">
                    <ItemTemplate>
                        <asp:Label ID="lblShipmentQty" runat="server" Text='<%# Convert.ToInt32( Eval("ShipmentQty")).ToString("N0")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="NO. OF <br/>PACKAGES" SortExpression="" HeaderStyle-CssClass="vertical_header"
                    ItemStyle-CssClass="numeric_text vertical_text">
                    <ItemTemplate>
                        <asp:Label ID="lblTotalPackages" runat="server" Text='<%# (Eval("ShipmentPlanningOrder") as iKandi.Common.ShipmentPlanningOrder).PackingList.TotalPackages %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="PACKAGE <br/> NUMBERING" SortExpression="" HeaderStyle-CssClass="vertical_header"
                    ItemStyle-CssClass="numeric_text vertical_text">
                    <ItemTemplate>
                        <asp:Label ID="Label4" runat="server" Text='<%# (Eval("ShipmentPlanningOrder") as iKandi.Common.ShipmentPlanningOrder).PackingList.PackageNumbers %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="CHECK BOX TO BOOK" SortExpression="">
                    <ItemTemplate>
                        <asp:CheckBox ID="chkSelectForBooking" runat="server" CssClass='<%# iKandi.Web.Components.PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.DC_BOOKING_FILE_CHECK_BOX_TO_BOOK)? "chk-booking" : "chk-booking disable-checkbox" %>'>
                        </asp:CheckBox>
                        <span class="mode-id hide_me">
                            <%# Eval("Mode") %></span> <span class="client-id hide_me">
                                <%# (Eval("ParentOrder") as iKandi.Common.Order).ClientID %></span>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <EmptyDataTemplate>
                <label>No records Found</label></EmptyDataTemplate>
        </asp:GridView>        
    </div>
</div>
<br />
<div class="grid_heading">
    BOOKING VIEW
</div>
<br />
<div class="form_box">
    <asp:HiddenField ID="hdnPagesize1" runat="server" />
    <asp:HiddenField ID="hdnPageIndex1" runat="server" />
    <input type="hidden" id="hdnpageindex1" name="hdnpageindex1" />
    <input type="hidden" id="hdnpagesize1" name="hdnpagesize1" />
    <asp:GridView ID="grdBooking" runat="server" AutoGenerateColumns="False" CssClass="item_list fixed-header "
        OnRowDataBound="grdBooking_RowDataBound" OnPageIndexChanging="grdBooking_PageIndexChanging"
        AllowPaging="true" PageSize="10" Width="120%">
        <Columns>
            <asp:TemplateField HeaderText="Order Date" SortExpression="" HeaderStyle-CssClass="vertical_header"
                ItemStyle-CssClass="vertical_text date_style">
                <ItemTemplate>
                    <asp:Label ID="lblOrderDate" runat="server" Text='<%# (Convert.ToDateTime((Eval("ParentOrder") as iKandi.Common.Order).OrderDate) == DateTime.MinValue)? "" : (Eval("ParentOrder") as iKandi.Common.Order).OrderDate.ToString("dd MMM yy (ddd)") %>'></asp:Label>
                    <asp:HiddenField runat="server" ID="hdnBookingID" Value='<%# Eval("BookingID") %>' />
                    <asp:HiddenField runat="server" ID="hdnOrderDetailID" Value='<%# Eval("OrderDetailID") %>' />
                    <asp:HiddenField runat="server" ID="hdnProductionPlanningID" Value='<%# Eval("ProductionPlanningID") %>' />
                    <asp:HiddenField runat="server" ID="hdnPackingID" Value='<%# (Eval("ShipmentPlanningOrder") as iKandi.Common.ShipmentPlanningOrder).PackingList.PackingID %>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Serial No." SortExpression="" HeaderStyle-CssClass="vertical_header"
                ItemStyle-CssClass="vertical_text">
                <ItemTemplate>
                    <asp:HiddenField runat="server" ID="hdnIkandiSerial" />
                    <asp:Label ID="lblSerialNumber" runat="server" Text='<%# (Eval("ParentOrder") as iKandi.Common.Order).SerialNumber%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Style Number" SortExpression="" HeaderStyle-CssClass="vertical_header"
                ItemStyle-CssClass="vertical_text">
                <ItemTemplate>
                    <asp:Label ID="lblStyleNumber" runat="server" Text='<%# (Eval("ParentOrder") as iKandi.Common.Order).Style.StyleNumber %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Dept." SortExpression="" HeaderStyle-CssClass="vertical_header"
                ItemStyle-CssClass="vertical_text">
                <ItemTemplate>
                    <asp:Label ID="lblDepartmentName" runat="server" Text='<%# (Eval("ParentOrder") as iKandi.Common.Order).DepartmentName %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="LineItemNumber" HeaderText="Line Number" SortExpression="LineItemNumber"
                HeaderStyle-CssClass="vertical_header" ItemStyle-CssClass="vertical_text" />
            <asp:BoundField DataField="ContractNumber" HeaderText="Contract" SortExpression="ContractNumber"
                HeaderStyle-CssClass="vertical_header" ItemStyle-CssClass="vertical_text" />
            <asp:TemplateField HeaderText="Description" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle"
                SortExpression="" HeaderStyle-CssClass="vertical_header" ItemStyle-CssClass="vertical_text">
                <ItemTemplate>
                    <asp:Label ID="Label4" Height="150px" runat="server" Text='<%# (Eval("ParentOrder") as iKandi.Common.Order).Description %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Main Fabric" SortExpression="Fabric1" HeaderStyle-CssClass="vertical_header"
                ItemStyle-CssClass="vertical_text">
                <ItemTemplate>
                    <asp:Label ID="lblMainFabric" Text='<%# Eval("Fabric1") %>' Height="150px" runat="server"></asp:Label><br />
                    <asp:Label ID="lblMainFabric113" Text='<%# Eval("CCGSM") %>' Font-Size="Smaller" ForeColor="Blue" Height="150px" runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Mode" SortExpression="Mode" HeaderStyle-CssClass="vertical_header"
                ItemStyle-CssClass="vertical_text">
                <ItemTemplate>
                    <asp:Label runat="server" ID="lblMode" Text='<%# Eval("ModeName") %>' ToolTip='<%# iKandi.BLL.CommonHelper.GetDeliveryModeToolTip(Convert.ToInt32(Eval("Mode"))) %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="MDA" HeaderText="MDA Number" SortExpression="" HeaderStyle-CssClass="vertical_header"
                ItemStyle-CssClass="vertical_text" />
            <asp:TemplateField HeaderText="Ex Factory" ItemStyle-CssClass="date_style vertical_text"
                HeaderStyle-CssClass="vertical_header">
                <ItemTemplate>
                    <asp:HiddenField ID="hdnEx" runat="server" />
                    <%# (Convert.ToDateTime(Eval("ExFactory")) == DateTime.MinValue) ? "" : (Convert.ToDateTime(Eval("ExFactory"))).ToString("dd MMM yy (ddd)")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Status" HeaderStyle-CssClass="vertical_header" ItemStyle-CssClass="vertical_text">
                <ItemTemplate>
                    <asp:HiddenField runat="server" ID="hdnStatus" />
                    <%# Eval("Status") %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="SHIPMENT NO." SortExpression="" HeaderStyle-CssClass="vertical_header"
                ItemStyle-CssClass="vertical_text">
                <ItemTemplate>
                    <a href='javascript:void(0)' id='anchorShipmentNumber' onclick='ShowShipmentPlanningOrders(<%# (Eval("ShipmentPlanningOrder") as iKandi.Common.ShipmentPlanningOrder).ShipmentPlanning.ShipmentID %>)'>
                        <asp:Label ID="Label5" runat="server" Text='<%# (Eval("ShipmentPlanningOrder") as iKandi.Common.ShipmentPlanningOrder).ShipmentPlanning.ShipmentNumber %>'></asp:Label>
                    </a>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="LANDING Date" HeaderStyle-CssClass="vertical_header"
                SortExpression="" ItemStyle-CssClass="date_style vertical_text">
                <ItemTemplate>
                    <%--<asp:Label ID="lblLandingETA" runat="server" Text='<%# (Eval("ShipmentPlanningOrder") as iKandi.Common.ShipmentPlanningOrder).ShipmentPlanning.LandingETA %>'></asp:Label>--%>
                    <asp:Label ID="lblLandingETA" runat="server" Text='<%# (Convert.ToDateTime((Eval("ShipmentPlanningOrder") as iKandi.Common.ShipmentPlanningOrder).ShipmentPlanning.LandingETA) == DateTime.MinValue)? "" : (Eval("ShipmentPlanningOrder") as iKandi.Common.ShipmentPlanningOrder).ShipmentPlanning.LandingETA.ToString("dd MMM yy (ddd)") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="DC DATE" SortExpression="" ItemStyle-CssClass="date_style bold_text"
                HeaderStyle-Width="130px">
                <ItemTemplate>
                    <asp:Label ID="lblDCDate" Width="130px" ForeColor="Blue" runat="server" Text='<%# (Convert.ToDateTime(Eval("DC")) == DateTime.MinValue) ? "" : (Convert.ToDateTime( Eval("DC")) ).ToString("dd MMM yy (ddd)" )%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="POQTY" SortExpression="" ItemStyle-CssClass="numeric_text">
                <ItemTemplate>
                    <asp:Label ID="Label6" runat="server" CssClass="order-quantity" Text='<%#Convert.ToInt32( Eval("Quantity")).ToString("N0") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="BIPL INVOICE NO." SortExpression="" HeaderStyle-CssClass="vertical_header"
                ItemStyle-CssClass="vertical_text">
                <ItemTemplate>
                    <asp:Label ID="Label7" runat="server" Text='<%# (Eval("ShipmentPlanningOrder") as iKandi.Common.ShipmentPlanningOrder).PackingList.InvoiceNumber %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="QTY Shipped" SortExpression="" HeaderStyle-CssClass="vertical_header"
                ItemStyle-CssClass="numeric_text vertical_text">
                <ItemTemplate>
                    <asp:Label ID="lblShipmentQty" runat="server" Text='<%#Convert.ToInt32( Eval("ShipmentQty")).ToString("N0")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="NO. OF <br/> PACKAGES" SortExpression="" HeaderStyle-CssClass="vertical_header"
                ItemStyle-CssClass="numeric_text vertical_text">
                <ItemTemplate>
                    <asp:Label ID="lblTotalPackages" runat="server" Text='<%# (Eval("ShipmentPlanningOrder") as iKandi.Common.ShipmentPlanningOrder).PackingList.TotalPackages %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="PACKAGE <br/> NUMBERING" SortExpression="" HeaderStyle-CssClass="vertical_header"
                ItemStyle-CssClass="numeric_text vertical_text">
                <ItemTemplate>
                    <asp:Label ID="Label8" runat="server" Text='<%# (Eval("ShipmentPlanningOrder") as iKandi.Common.ShipmentPlanningOrder).PackingList.PackageNumbers %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="PKG DIMS (cms)" SortExpression="" HeaderStyle-CssClass="vertical_header"
                ItemStyle-CssClass="vertical_text">
                <ItemTemplate>
                    <asp:Label Height="150" ID="packageDimensions" runat="server" CssClass="package-dimensions"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="BOOKING <br/> REQUESTED ON" HeaderStyle-CssClass="vertical_header"
                SortExpression="" ItemStyle-CssClass="date_style ">
                <ItemTemplate>
                    <asp:TextBox ID="txtBookingRequestedOn" Text='<%# (Convert.ToDateTime(Eval("BookingRequestedOn")) == DateTime.MinValue) ? "" : (Convert.ToDateTime( Eval("BookingRequestedOn")) ).ToString("dd MMM yy (ddd)" ) %>'
                        CssClass='<%# iKandi.Web.Components.PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.DC_BOOKING_FILE_BOOKING_REQUESTED_ON)? "th vertical_text_input date_style invoice_input":"do-not-allow-typing vertical_text_input date_style invoice_input" %>'
                        runat="server"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="BOOKING REF NO." SortExpression="">
                <ItemTemplate>
                    <asp:TextBox ID="txtBookingRefNo" Text='<%# Eval("BookingReferenceNo") %>' runat="server"
                        Width="95%" CssClass='<%# iKandi.Web.Components.PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.DC_BOOKING_FILE_BOOKING_REF_NO)? "invoice_input":"do-not-allow-typing invoice_input" %>'></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="P.LIST ENTERED/SPLITS CONFIRMED (CHECK BOX)" SortExpression="">
                <ItemTemplate>
                    <asp:CheckBox ID="chkConfirm" runat="server" Visible="true" CssClass='<%# iKandi.Web.Components.PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.DC_BOOKING_FILE_P_LIST_ENTERED_SPLITS_CONFIRMED_CHECK_BOX)? "":"disable-checkbox" %>'
                        Checked='<%# Convert.ToBoolean(Eval("IsPackinglistCompleteBooking")) %>'></asp:CheckBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="EXPECTED <br/> INTO DC" HeaderStyle-CssClass="" SortExpression=""
                ItemStyle-CssClass="date_style" ItemStyle-Width="150px">
                <ItemTemplate>
                    <asp:TextBox ID="txtExpectedDC" Width="95%" Text='<%# (Convert.ToDateTime(Eval("ExpectedDC")) == DateTime.MinValue) ? "" : (Convert.ToDateTime( Eval("ExpectedDC")) ).ToString("dd MMM yy (ddd)" ) %>'
                        CssClass='<%# iKandi.Web.Components.PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.DC_BOOKING_FILE_BOOKING_REF_NO_EXPECTED_INTO_DC)? "th  date_style invoice_input":"do-not-allow-typing date_style invoice_input" %>'
                        runat="server"></asp:TextBox>
                    <div>
                        HR:<asp:DropDownList Width="40" runat="server" ID="txtExpectedDCDateHR" SelectedValue='<%# Convert.ToDateTime(Eval("ExpectedDC")).Hour %>'>
                            <asp:ListItem Value="0">00</asp:ListItem>
                            <asp:ListItem Value="1">01</asp:ListItem>
                            <asp:ListItem Value="2">02</asp:ListItem>
                            <asp:ListItem Value="3">03</asp:ListItem>
                            <asp:ListItem Value="4">04</asp:ListItem>
                            <asp:ListItem Value="5">05</asp:ListItem>
                            <asp:ListItem Value="6">06</asp:ListItem>
                            <asp:ListItem Value="7">07</asp:ListItem>
                            <asp:ListItem Value="8">08</asp:ListItem>
                            <asp:ListItem Value="9">09</asp:ListItem>
                            <asp:ListItem Value="10">10</asp:ListItem>
                            <asp:ListItem Value="11">11</asp:ListItem>
                            <asp:ListItem Value="12">12</asp:ListItem>
                            <asp:ListItem Value="13">13</asp:ListItem>
                            <asp:ListItem Value="14">14</asp:ListItem>
                            <asp:ListItem Value="15">15</asp:ListItem>
                            <asp:ListItem Value="16">16</asp:ListItem>
                            <asp:ListItem Value="17">17</asp:ListItem>
                            <asp:ListItem Value="18">18</asp:ListItem>
                            <asp:ListItem Value="19">19</asp:ListItem>
                            <asp:ListItem Value="20">20</asp:ListItem>
                            <asp:ListItem Value="21">21</asp:ListItem>
                            <asp:ListItem Value="22">22</asp:ListItem>
                            <asp:ListItem Value="23">23</asp:ListItem>
                        </asp:DropDownList>
                        MM:<asp:DropDownList Width="40" runat="server" ID="txtExpectedDCDateMM" SelectedValue='<%# Convert.ToDateTime(Eval("ExpectedDC")).Minute %>'>
                            <asp:ListItem Value="0">00</asp:ListItem>
                            <asp:ListItem Value="15">15</asp:ListItem>
                            <asp:ListItem Value="30">30</asp:ListItem>
                            <asp:ListItem Value="45">45</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="ATTACH BOOKING DOCUMENTS" SortExpression="">
                <ItemTemplate>
                    <asp:HiddenField runat="server" ID="hdnBookingDocs" Value='<%# Eval("BookingDocuments") %>' />
                    <span class="upload-booking-documents">
                        <%# Eval("BookingDocuments")%></span>
                    <asp:FileUpload ID="fileBookingDocs" Width="100" CssClass="multi" runat="server"
                        Enabled='<%#iKandi.Web.Components.PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.DC_BOOKING_FILE_ATTACH_BOOKING_DOCUMENTS)? true:false %>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="E-MAIL" SortExpression="" HeaderStyle-CssClass="vertical_header"
                ItemStyle-CssClass="">
                <ItemTemplate>
                    <a href="javascript:void(0)" onclick="SendEmail(3, <%# Eval("BookingID")  %>)">
                        <img alt="email" border="0" src="/App_Themes/ikandi/images/<%#  (Convert.ToBoolean(Eval("IsEmailSent") )) ? "green-email.gif" : "red-email.gif" %>" />
                    </a>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Remove" SortExpression="">
                <ItemTemplate>
                    <asp:CheckBox ID="chkRemove" runat="server" CssClass='<%# iKandi.Web.Components.PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.DC_BOOKING_FILE_REMOVE)? "" : "disable-checkbox" %>'>
                    </asp:CheckBox>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <EmptyDataTemplate>
            <label>No records Found</label></EmptyDataTemplate>
    </asp:GridView>
</div>

<br />
<asp:Button runat="server" ID="btnSubmit" CssClass="submit" Text="Submit" OnClick="btnSubmit_Click"
    OnClientClick="return ValidateOrdersForModeAndClient()" />
