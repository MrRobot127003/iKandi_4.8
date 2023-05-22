<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ikandiInvoiceQuery.ascx.cs"
    Inherits="iKandi.Web.ikandiInvoiceQuery" %>
<%@ Register Assembly="iKandi.Web" Namespace="iKandi.Components.UI" TagPrefix="cc1" %>

<script type="text/javascript">

    var serviceUrl = '<%= ResolveUrl("~/Webservices/iKandiService.asmx/") %>';
    var proxy = new ServiceProxy(serviceUrl);

    function launchInvoice(packingId, invoiceid) {

        window.open('/Internal/Delivery/iKandiInvoice.aspx?type=1&packingId=' + packingId + '&invoiceid=' + invoiceid, "Invoice", 'height=900,width=1000,status=yes,resizable=yes,menubar=no, scrollbars=yes,toolbar=no,location=no,directories=no,center:yes');
    }

    function launchBiplInvoice(invoiceid) {

        window.open('/Internal/Delivery/BIPLInvoice.aspx?type=2&packingId=-1&invoiceid=' + invoiceid, "Invoice", 'height=900,width=1000,status=yes,resizable=no,menubar=no, scrollbars=yes,toolbar=no,location=no,directories=no,center:yes');
    }

    function LaunchPackingList(packingId, orderId, productionPlanningId, sender) {
        if (packingId == -1)
            ShowPopupWindow(GetUrlWithDummyQueryString('/Internal/Packing/PackingList.aspx?oid=' + orderId + '&ppid=' + productionPlanningId), "Packing List", 'UpdatePackingData', '1100px', '900px')
        else
            ShowPopupWindow(GetUrlWithDummyQueryString('/Internal/Packing/PackingList.aspx?pid=' + packingId + '&ppid=' + productionPlanningId), "Packing List", 'UpdatePackingData', '1100px', '900px')
    }

    $(document).ready(function() {

        $("span.buyer-plist-doc", "#main_content").each(function() {
            SetupLinks($(this));
        });

        $("span.upload-pre-doc", "#main_content").each(function() {
            SetupLinks($(this));
        });

        $("span.upload-post-doc", "#main_content").each(function() {
            SetupLinks($(this));
        });

        $('span.qa-status').each(function() {
            $(this).parents('td').css('background-color', $(this).css('background-color'));
        });
    });

    function SetupLinks(container) {
        var html = '';
        var data = container.text();
        var dataArr = data.split('$$');

        for (i = 0; i < dataArr.length; i = i + 2) {
            html += '<span><a  href="/uploads/delivery/' + dataArr[i + 1] + '" target="_blank">' + dataArr[i] + '</a></span><br />';
        }
        container.html(html);
    }

    
</script>

<div class="print-box">
    <div class="grid_heading" cssclass="item_list">
        Invoice query</div>
    <br />
    <div id="Div1">
        <table width="1000px" cellspacing="5">
            <tr>
                <td>
                    <asp:Label ID="lblSelectClient" Text="Search :" runat="server"></asp:Label>
                </td>
                <td class="do-not-disable">
                    <asp:TextBox ID="txtsearch" CssClass="do-not-disable" MaxLength="40" runat="server" Width="200px"></asp:TextBox>
                </td>
                <td>
                    IK Invoice Date :
                </td>
                <td>
                    <asp:Label ID="lblFrom1" Text="From" runat="server"></asp:Label>
                </td>
                <td>
                    <input type="text" id="txtFrom1" class="date-picker do-not-disable" runat="server" />
                </td>
                <td>
                    <asp:Label ID="lblTo1" Text="To" runat="server"></asp:Label>
                </td>
                <td>
                    <input type="text" id="txtTo1" class="date-picker do-not-disable" runat="server" />
                </td>
                <td>
                    Client
                </td>
                <td>
                    <asp:DropDownList ID="ddlClients" runat="server" CssClass="do-not-disable">
                        <asp:ListItem Value="-1">Select..</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:Button ID="btn_search1" OnClick="btn_search_Click" runat="server" CssClass="search do-not-disable" />
                </td>
            </tr>
        </table>
    </div>
    <br />
    <div class="form_box">
        <asp:GridView ID="grdikandiInvoicing" runat="server" AutoGenerateColumns="False"
            CssClass="item_list fixed-header" OnRowDataBound="grdikandiInvoicing_RowDataBound">
            <Columns>
                <asp:TemplateField HeaderText="Buyer" SortExpression="">
                    <ItemTemplate>
                        <asp:Label ID="lblClient" runat="server" Text='<%# (Eval("ParentOrder") as iKandi.Common.Order).Client.CompanyName%>'></asp:Label>
                        <asp:HiddenField runat="server" ID="hdnInvoiceID" Value='<%# (Eval("Invoice") as iKandi.Common.Invoice).InvoiceID %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Serial No." SortExpression="">
                    <ItemTemplate>
                        <asp:HiddenField ID="hdnSerial" runat="server" />
                        <asp:Label ID="Label21" runat="server" Text='<%# (Eval("ParentOrder") as iKandi.Common.Order).SerialNumber%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="SHIPMENT NO." SortExpression="" HeaderStyle-CssClass="vertical_header"
                    ItemStyle-CssClass="vertical_text">
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# (Eval("ShipmentPlanning") as iKandi.Common.ShipmentPlanning).ShipmentNumber %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Dept." SortExpression="" HeaderStyle-CssClass="vertical_header"
                    ItemStyle-CssClass="vertical_text">
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" Text='<%# (Eval("ParentOrder") as iKandi.Common.Order).DepartmentName %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Style Number" SortExpression="">
                    <ItemTemplate>
                        <nobr><asp:Label ID="Label22" runat="server" Text='<%# (Eval("ParentOrder") as iKandi.Common.Order).Style.StyleNumber %>'></asp:Label></nobr>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="LineItemNumber" HeaderText="Line Number" SortExpression="LineItemNumber" />
                <asp:BoundField DataField="ContractNumber" HeaderText="Contract" SortExpression="ContractNumber" />
                <asp:TemplateField HeaderText="Description" SortExpression="" HeaderStyle-CssClass="vertical_header"
                    ItemStyle-CssClass="vertical_text">
                    <ItemTemplate>
                        <asp:Label Height="100px" ID="Label4" runat="server" Text='<%# (Eval("ParentOrder") as iKandi.Common.Order).Description %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Status">
                    <ItemTemplate>
                        <asp:Label ID="lblStatus" Text='<%# Eval("Status")%>' runat="server"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="DC DATE" SortExpression="" ItemStyle-CssClass="date_style vertical_text"
                    HeaderStyle-CssClass="vertical_header">
                    <ItemTemplate>
                        <asp:Label ID="lblDCDate" runat="server" Text='<%#  (Convert.ToDateTime(Eval("DC")) == DateTime.MinValue)? "" : Eval("DC", "{0:dd MMM yy (ddd)}")  %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="PO QTY" SortExpression="" ItemStyle-CssClass="numeric_text quantity_style">
                    <ItemTemplate>
                        <asp:Label ID="Label24" runat="server" Text='<%# Convert.ToInt32(Eval("Quantity")).ToString("N0") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="BIPL INVOICE NO./ Detail" SortExpression="" ItemStyle-CssClass="numeric_text print_align_left remarks_text2 "
                    HeaderStyle-Width="150px" ItemStyle-Width="150px" HeaderStyle-CssClass="">
                    <ItemTemplate>
                        <asp:Panel ID="pnlBiplInvoiceDetail" Width="150px" runat="server">
                        </asp:Panel>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Bipl Invoice QTY" SortExpression="" ItemStyle-CssClass="numeric_text quantity_style">
                    <ItemTemplate>
                        <asp:Label ID="lblBiplInvoiceQty" runat="server"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Bipl Invoice Amount" SortExpression="" ItemStyle-CssClass="numeric_text quantity_style">
                    <ItemTemplate>
                        <asp:Label ID="lblBiplInvoiceAmount" runat="server"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="BOOKING REF NO." SortExpression="">
                    <ItemTemplate>
                        <asp:Label ID="Label33" runat="server" Text='<%# (Eval("DeliveryBooking") as iKandi.Common.DeliveryBooking ).BookingReferenceNo%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="DELIVERED DATE/DELIVERY NOTE RECEIVED ON" SortExpression=""
                    ItemStyle-CssClass="date_style">
                    <ItemTemplate>
                        <asp:Label ID="lbldelivertedDate" CssClass="quantity_style" runat="server" Text='<%#  ((Eval("DeliveryBooking") as iKandi.Common.DeliveryBooking ).DeliveredDate== DateTime.MinValue)? "" : (Eval("DeliveryBooking") as iKandi.Common.DeliveryBooking ).DeliveredDate.ToString("dd MMM yy (ddd)")    %>'></asp:Label>
                        <asp:Label ID="lblDelivertedNoteReceivedOn" runat="server" Text='<%#  ((Eval("DeliveryBooking") as iKandi.Common.DeliveryBooking ).DeliveryNoteReceivedOn== DateTime.MinValue)? "" : (Eval("DeliveryBooking") as iKandi.Common.DeliveryBooking ).DeliveryNoteReceivedOn.ToString("dd MMM yy (ddd)")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Ikandi INVOICE NO./ DETAIL" SortExpression="" HeaderStyle-Width="150px"
                    ItemStyle-Width="150px" ItemStyle-CssClass="print_align_left remarks_text2">
                    <ItemTemplate>
                        <div style="width: 150px! important;">
                            <a href="javascript:void(0)" onclick="launchInvoice( <%#(Eval("Invoice") as iKandi.Common.Invoice).PackingID %>, <%#(Eval("Invoice") as iKandi.Common.Invoice).IkandiInvoiceID %>)">
                                <%# (Eval("Invoice") as iKandi.Common.Invoice ).InvoiceNo%></a><br />
                            <asp:Label ID="lblIkandiInvoiceDate" CssClass="font_color_blue" Width="140px" runat="server"
                                Text='<%# Convert.ToDateTime((Eval("Invoice") as iKandi.Common.Invoice ).IkandiInvoiceDate) == DateTime.MinValue ? "" : "(" +(Eval("Invoice") as iKandi.Common.Invoice ).IkandiInvoiceDate.ToString("dd MMM yy (ddd)") + ")" %>'></asp:Label>
                        </div>
                        <div>
                        <a href="javascript:void(0)" onclick="LaunchPackingList( <%#(Eval("Invoice") as iKandi.Common.Invoice).PackingID %>, <%#(Eval("ParentOrder") as iKandi.Common.Order).OrderID %>, <%# (Eval("ProductionPlanning") as iKandi.Common.ProductionPlanning).ProductionPlanningID %>, this )">
                        View Packing List</a><br />
                        <a target="_blank" href='<%# ((Eval("ShipmentPlanning") as iKandi.Common.ShipmentPlanning).ShipmentPlanningOrder.UploadDocument == null || string.IsNullOrEmpty((Eval("ShipmentPlanning") as iKandi.Common.ShipmentPlanning).ShipmentPlanningOrder.UploadDocument.ToString()) || !((Eval("ShipmentPlanning") as iKandi.Common.ShipmentPlanning).ShipmentPlanningOrder.UploadDocument.ToString().Contains("$$"))) ? "" : ResolveUrl("~/uploads/delivery/" + (Eval("ShipmentPlanning") as iKandi.Common.ShipmentPlanning).ShipmentPlanningOrder.UploadDocument.ToString().Split(new string[] { "$$" }, StringSplitOptions.RemoveEmptyEntries)[1])%>'
                        class="<%# ( string.IsNullOrEmpty((Eval("ShipmentPlanning") as iKandi.Common.ShipmentPlanning).ShipmentPlanningOrder.UploadDocument) ) ? "hide_me": "" %>">
                        UPLOAD DOCUMENTS (PRE) </a>
                    <br />
                    <a target="_blank" href='<%# ((Eval("ShipmentPlanning") as iKandi.Common.ShipmentPlanning).ShipmentPlanningOrder.UploadCustomList == null || string.IsNullOrEmpty((Eval("ShipmentPlanning") as iKandi.Common.ShipmentPlanning).ShipmentPlanningOrder.UploadCustomList.ToString()) || !((Eval("ShipmentPlanning") as iKandi.Common.ShipmentPlanning).ShipmentPlanningOrder.UploadCustomList.ToString().Contains("$$"))) ? "" : ResolveUrl("~/uploads/delivery/" + (Eval("ShipmentPlanning") as iKandi.Common.ShipmentPlanning).ShipmentPlanningOrder.UploadCustomList.ToString().Split(new string[] { "$$" }, StringSplitOptions.RemoveEmptyEntries)[1])%>'
                        class="<%# ( string.IsNullOrEmpty((Eval("ShipmentPlanning") as iKandi.Common.ShipmentPlanning).ShipmentPlanningOrder.UploadCustomList) ) ? "hide_me": "" %>">
                       UPLOAD CUSTOM P List </a>
                        </div>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Ikandi Invoice QTY" SortExpression="" ItemStyle-CssClass="numeric_text quantity_style">
                    <ItemTemplate>
                        <asp:Label ID="lblIkandiInvoiceQty" runat="server" Text='<%# (Eval("Invoice") as iKandi.Common.Invoice).IkandiInvoiceQuantity.ToString("N0") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="INVOICE AMOUNT" SortExpression="" ItemStyle-CssClass="numeric_text quantity_style">
                    <ItemTemplate>
                    
                        <nobr>
                        <asp:Label ID="lblIkandiInvoiceAmountSymbal" runat="server"></asp:Label>
                        <asp:Label ID="lblInvoiceAmount" runat="server" Text='<%# (Eval("Invoice") as iKandi.Common.Invoice ).IkandiInvoiceGrandTotal.ToString("N2") %>'></asp:Label></nobr>
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Ikandi Invoice Sage Details" SortExpression="" ItemStyle-CssClass="numeric_text quantity_style">
                    <ItemTemplate>
                        <asp:Label ID="lblIkandiInvoiceSageDeatil" runat="server" Text='<%# (Eval("Invoice") as iKandi.Common.Invoice ).IkandiInvoiceDetails.ToString() %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <EmptyDataTemplate>
                <label>
                    No records Found</label></EmptyDataTemplate>
        </asp:GridView>
    </div>
    <div style="margin-top: 5px; text-align: right;">
        <cc1:HyperLinkPager ID="HyperLinkPager1" runat="server" PageSize="20">
        </cc1:HyperLinkPager>
    </div>
</div>
<br />
<div id="ordersplit" class="hide_me do-not-include divSplit">
    <div class="form_box">
        <div class="form_heading">
            ikandi Invoice Split</div>
        <br />
        <table class="order_split_table" id="tblsplit" width="800px">
            <tbody>
                <tr>
                    <th width="20%" id="newLable">
                        No. Of Splits
                    </th>
                    <td width="20%">
                        <input type="text" id="splitValue" class="splitValueFor" value="0" />
                    </td>
                    <th width="20%" id="thInvoiceNumber" class="hide_me">
                        Invoice Number
                    </th>
                    <td width="20%" id="thInvoiceNumberInput" class="hide_me">
                        <input type="text" id="txtInvoiceNumber" class="invoiceNumberInput" value="0" />
                    </td>
                    <td width="20%" rowspan="10" align="left" style="vertical-align: top">
                        <input type="hidden" value="-1" id="hdnrowindex" />
                        <input type="hidden" value="-1" id="hdnquantity" />
                        <input type="hidden" value="-1" id="hdnInvoiceNumber" />
                        <input type="hidden" value="-1" id="hdnInvoiceID" />
                        <input type="hidden" value="-1" id="HdnPackingID" />
                        <input type="hidden" value="-1" id="hdnSplittedQuantity" />
                        <input type="hidden" value="-1" id="hdnSplittedInvoiceNumber" />
                        <input type="button" id="btnOk" onclick="addsplitTableRow( this)" class="ok" />
                    </td>
                </tr>
            </tbody>
        </table>
        <br />
        <div style="padding: 5px">
            <table width="100px">
                <tr>
                    <td id="thBtnSubmit" class="hide_me">
                        <input type="button" id="btnsubmit" class="submit hide_me" onclick="if(checkSplitValues()) {webServiceCallForSpliteValues();}"
                            style="display: block !important;" />
                    </td>
                    <td>
                        <input type="button" id="cancel" class="cancel" onclick="closeSplitTable()" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
</div>
