<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WeeklyShipment.ascx.cs"
    Inherits="iKandi.Web.WeeklyShipment" %>

<script type="text/javascript">

    var hdnPagesizeClientID = '<%=hdnPagesize.ClientID %>';
    var hdnPageIndexClientID = '<%=hdnPageIndex.ClientID %>';
    var hdnStartDateClientID = '<%=tbStart.ClientID %>';
    var hdnEndDateClientID = '<%=tbEnd.ClientID %>';
    $(function() {
        $("#" + hdnStartDateClientID).datepicker({
            dateFormat: "dd M y (D)",
            onSelect: function(dateText, inst) {
                var the_date = $.datepicker.parseDate("dd M y (D)", dateText).addDays(7);
                $("#" + hdnEndDateClientID).datepicker('setDate', the_date);
            }
        });
        $("#" + hdnEndDateClientID).datepicker({
            dateFormat: "dd M y (D)",
            onSelect: function(dateText, inst) {
            }
        });


        $("#hdnpageindex").val($("#" + hdnPageIndexClientID).val());
        $("#hdnpagesize").val($("#" + hdnPagesizeClientID).val());

        $('#lightbox-image-details-caption').hide();
        $('#lightbox-image-details-currentNumber').hide();
        $("a[rel=lightbox]").lightBox({

            imageLoading: '/app_themes/ikandi/images/lightbox-ico-loading.gif',

            imageBtnClose: '/app_themes/ikandi/images/lightbox-btn-close.gif',

            imageBlank: '/app_themes/ikandi/images/lightbox-blank.gif',
            showTitle: false
        });

    });

    var serviceUrl = '<%= ResolveUrl("~/Webservices/iKandiService.asmx/") %>';
    var proxy = new ServiceProxy(serviceUrl);


    function hideLinks(srcElem) {
        var objRow = $(srcElem).parents("tr");
        $("#links").hide();
    }

    function showFabricPopup(StyleID,OrderDetailID, OrderID, ClientID, Fabric1, Fabric2, Fabric3, Fabric4, Fabric1Details, Fabric2Details, Fabric3Details, Fabric4Details) {
        proxy.invoke("ShowManageOrderFabricDatesPopup", { StyleID:StyleID,OrderDetailID: OrderDetailID, OrderID: OrderID, ClientID: ClientID, Fabric1: Fabric1, Fabric2: Fabric2, Fabric3: Fabric3, Fabric4: Fabric4, Fabric1Details: Fabric1Details, Fabric2Details: Fabric2Details, Fabric3Details: Fabric3Details, Fabric4Details: Fabric4Details }, function(result) {
            jQuery.facebox(result);
        }, onPageError, false, false);
    }

    function showSizePopup(OrderDetailID) {
        proxy.invoke("GetSizesPopup", { OrderDetailID: OrderDetailID }, function(result) {
            jQuery.facebox(result);

        }, onPageError, false, false);
    }

    function GetManageOrderiKandiQuantityByDept(DepartmentID) {
        proxy.invoke("GetManageOrderiKandiQuantityByDept", { DepartmentID: DepartmentID }, function(result) {
            jQuery.facebox(result);
        }, onPageError, false, false);
    }

    function GetManageOrderiKandiQuantityByMode(Mode) {
        proxy.invoke("GetManageOrderiKandiQuantityByMode", { Mode: Mode }, function(result) {
            jQuery.facebox(result);
        }, onPageError, false, false);
    }

    function showStatusMeeting(OrderDetailID) {
        proxy.invoke("showStatusMeeting", { OrderDetailID: OrderDetailID }, function(result) {
            jQuery.facebox(result);
        }, onPageError, false, false);
    }

    function launchBiplInvoice(invoiceid) {
        window.open('/Internal/Delivery/BIPLInvoice.aspx?type=2&packingId=-1&invoiceid=' + invoiceid, "Invoice", 'height=900,width=1000,status=yes,resizable=no,menubar=no, scrollbars=yes,toolbar=no,location=no,directories=no,center:yes');

    }
  
  
 
  
</script>

<div class="form_box">
    <div class="form_heading">
        Weekly Shipments
    </div>
    <div>
        <table width="500px" cellspacing="5">
            <tr>
                <td>
                    Start&nbsp;Date:
                </td>
                <td>
                    <asp:TextBox ID="tbStart" runat="server" CssClass="date_style" />
                </td>
                <td>
                    End&nbsp;Date:
                </td>
                <td>
                    <asp:TextBox ID="tbEnd" runat="server" CssClass="date_style" />
                </td>
                <td>
                    Client
                </td>
                <td>
                    <asp:DropDownList ID="ddlClients" runat="server" CssClass="do-not-disable mo_dropdown_style1">
                        <asp:ListItem Selected="True" Text="All" Value="-1"></asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    Mode
                </td>
                <td>
                    <asp:DropDownList ID="ddlModes" runat="server" CssClass="do-not-disable mo_dropdown_style1">
                        <asp:ListItem Selected="True" Text="Both" Value="-1"></asp:ListItem>
                        <asp:ListItem Text="L" Value="1"></asp:ListItem>
                        <asp:ListItem Text="D" Value="2"></asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:Button ID="btnGo" runat="server" class="go do-not-disable" OnClick="btnGo_click" />
                </td>
            </tr>
        </table>
    </div>
</div>
<div class="form_box">
    <asp:HiddenField ID="hdnPagesize" runat="server" />
    <asp:HiddenField ID="hdnPageIndex" runat="server" />
    <input type="hidden" id="hdnpageindex" name="hdnpageindex" />
    <input type="hidden" id="hdnpagesize" name="hdnpagesize" />
    <asp:GridView CssClass=" fixed-header item_list1" ID="GridView1" runat="server" AutoGenerateColumns="False"
        OnRowDataBound="GridView1_RowDataBound" OnPageIndexChanging="GridView1_PageIndexChanging"
        AllowPaging="true" PageSize="10" DataSourceID="odsWeeklyShipments">
        <Columns>
            <asp:TemplateField HeaderText="Buyer" HeaderStyle-CssClass="vertical_header" ItemStyle-CssClass="vertical_text">
                <ItemTemplate>
                    <asp:Label runat="server" ID="lblBuyer" Text='<%# Eval("Buyer") != DBNull.Value ?  Eval("Buyer").ToString() : ""  %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Order No." HeaderStyle-CssClass="vertical_header "
                ItemStyle-CssClass="vertical_text quantity_style">
                <ItemTemplate>
                    <asp:HiddenField ID="hdnSerial" runat="server" />
                    <a id="hypSerial" runat="server" class="hide_me"></a><span class="quantity_style">
                        <%# Eval("OrderNumber") != DBNull.Value ? Eval("OrderNumber").ToString() : ""  %></span>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Style No." HeaderStyle-Width="80px" ItemStyle-Width="80px"
                HeaderStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <span>
                    <nobr>
                        <%# Eval("StyleNumber") != DBNull.Value ? Eval("StyleNumber").ToString() : ""  %></nobr></span>
                    <br />
                    <a title="CLICK TO VIEW ENLARGED IMAGE" href="javascript:void(0)" onclick='showStylePhotoWithOutScroll(<%# Eval("StyleID").ToString()+",-1,"+Eval("OrderDetailID").ToString() %>)'>
                        <img style="height: 75px ! important" title="CLICK TO VIEW ENLARGED IMAGE" border="0px"
                            src='<%# ResolveUrl("~/uploads/style/thumb-" + Eval("SampleImageURL1").ToString()) %>' /></a>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="LineItemNumber" HeaderText="Line No" SortExpression="LineItemNumber"
                HeaderStyle-CssClass="vertical_header" ItemStyle-CssClass="vertical_text" HeaderStyle-Width="28px" />
            <asp:TemplateField HeaderText="Description" SortExpression="Description" HeaderStyle-Width="150px"
                ItemStyle-Width="150px" HeaderStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:Label ID="lblDiscription" runat="server" Height="100px" Width="150px" Text='<%# Eval("Description") != DBNull.Value ? Eval("Description") : ""  %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Fabric/Details" SortExpression="Fabric1" HeaderStyle-Width="250px"
                ItemStyle-Width="250px" HeaderStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <div class="fabric_left_style">
                        <span style="width: 250px ! important;">
                            <nobr>
                            <span runat="server" id="fabric1name">
                                <%# Eval("Fabric1") != DBNull.Value ? Eval("Fabric1").ToString() : ""%>
                            </span>
                            <label class="<%#(Eval("Fabric1Details").ToString().Trim() == "" || Eval("Fabric1Details") == DBNull.Value) ? "hide_me": "" %>">
                            : <%# Eval("Fabric1Details") != DBNull.Value ? Eval("Fabric1Details") : "" %></label>
                        </nobr>
                            <nobr>
                            <br />
                            <span runat="server" id="fabric2name">
                                <%# Eval("Fabric2") != DBNull.Value ? Eval("Fabric2") : "" %>
                            </span>
                            <label class="<%#(Eval("Fabric2Details").ToString().Trim() == "" || Eval("Fabric2Details") == DBNull.Value) ? "hide_me": "" %>">
                            : <%# Eval("Fabric2Details") != DBNull.Value ? Eval("Fabric2Details").ToString() : "" %></label>
                        </nobr>
                            <nobr>
                            <br />
                            <span runat="server" id="fabric3name">
                                <%# Eval("Fabric3") != DBNull.Value ?  Eval("Fabric3") : "" %>
                            </span>
                            <label class="<%#(Eval("Fabric3Details").ToString().Trim() == "" || Eval("Fabric3Details") == DBNull.Value ) ? "hide_me": "" %>">
                            : <%# Eval("Fabric3Details") != DBNull.Value ? Eval("Fabric3Details") : ""  %></label>
                        </nobr>
                            <nobr>
                            <br />
                            <span runat="server" id="fabric4name">
                                <%# Eval("Fabric4") != DBNull.Value ? Eval("Fabric4") : "" %>
                            </span>
                            <label class="<%#(Eval("Fabric4Details").ToString().Trim() == "" || Eval("Fabric4Details") == DBNull.Value ) ? "hide_me": "" %>">
                            : <%# Eval("Fabric4Details") != DBNull.Value ? Eval("Fabric4Details") : ""%></label>
                        </nobr>
                        </span>
                    </div>
                    <br />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Total QTY" SortExpression="Quantity" ItemStyle-CssClass="numeric_text quantity_style"
                HeaderStyle-Width="80px" ItemStyle-Width="80px">
                <ItemTemplate>
                    <asp:Label ID="lblQuantity" runat="server" Width="80px" Text='<%# Eval("Quantity") != DBNull.Value ? Convert.ToDouble(Eval("Quantity")).ToString("N0") : "0" %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Price in FC" ItemStyle-CssClass="numeric_text" HeaderStyle-Width="90px"
                ItemStyle-Width="90px" HeaderStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <span style="width: 90px ! important;">
                        <nobr>
                        <asp:Label ID="lblPriceInFCSymbal" runat="server"></asp:Label>
                        <%# Eval("BIPLPrice") != DBNull.Value ? Convert.ToDouble(Eval("BIPLPrice")).ToString("N2") : ""%>
                        </nobr>
                    </span>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Amount in FC" ItemStyle-CssClass="numeric_text" HeaderStyle-Width="90px"
                ItemStyle-Width="90px" HeaderStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <span style="width: 90px ! important;">
                        <nobr>
                    <asp:Label ID="lblAmountInFCSign" runat="server"></asp:Label>
                        <%# Eval("Amount") != DBNull.Value ? Convert.ToDouble(Eval("Amount")).ToString("N2") : ""%>
                        </nobr>
                    </span>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Shippment Date" SortExpression="ActionDate" ItemStyle-CssClass="date_style bold_text"
                HeaderStyle-Width="140px" ItemStyle-Width="140px">
                <ItemTemplate>
                    <asp:Label ID="lblShippingDate" runat="server" Width="140px" Text='<%# (Eval("ActionDate") == DBNull.Value || Convert.ToDateTime(Eval("ActionDate")) == DateTime.MinValue) ? "" : Convert.ToDateTime(Eval("ActionDate")).ToString("dd MMM yy (ddd)")%>'></asp:Label>
                    <asp:HiddenField runat="server" ID="lblEx" Value='<%# (Eval("ActionDate") == DBNull.Value || Convert.ToDateTime(Eval("ActionDate")) == DateTime.MinValue) ? "" : (Convert.ToDateTime(Eval("ActionDate"))).ToString("dd MMM yy (ddd)")%>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Mode" HeaderStyle-CssClass="vertical_header" ItemStyle-CssClass="vertical_text">
                <ItemTemplate>
                    <asp:Label runat="server" ID="lblMode" Text=' <%# Eval("ModeName") != DBNull.Value ?  Eval("ModeName").ToString() : "" %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText=" Invoice No." ItemStyle-CssClass="quantity_style"
                ItemStyle-Width="140px" HeaderStyle-Width="140px">
                <ItemTemplate>
                    <span style="width: 140px ! important;"><a class='<%# (Eval("InvoiceId") != DBNull.Value)? "":"hide_me" %>'
                        onclick="launchBiplInvoice('<%#Eval("InvoiceId")%>')">
                        <%# Eval("InvoiceNumber") != DBNull.Value ? (Eval("InvoiceNumber").ToString().Trim() == "" ? "View" : Eval("InvoiceNumber").ToString()) : (Eval("InvoiceId") != DBNull.Value ? "View" : "")%>
                    </a></span>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Shipment No." HeaderStyle-Width="120px" ItemStyle-Width="120px">
                <ItemTemplate>
                    <asp:Label runat="server" Width="120px" ID="lblShipmentNo" Text='<%# Eval("ShipmentNo") != DBNull.Value ?  Eval("ShipmentNo") : "" %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Unit" HeaderStyle-CssClass="vertical_header" ItemStyle-CssClass="vertical_text quantity_style">
                <ItemTemplate>
                    <span><a id="hypUnit" runat="server" class="hide_me"></a>
                        <asp:Label ID="lblUnit" runat="server" ToolTip='<%# Eval("FactoryName") != DBNull.Value ?  Eval("FactoryName").ToString() : "" %>'
                            Text='<%# Eval("FactoryCode") != DBNull.Value ? Eval("FactoryCode").ToString() : "" %>'></asp:Label>
                    </span>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <EmptyDataTemplate>
            <label>
                No records Found</label></EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource ID="odsWeeklyShipments" runat="server" SelectMethod="GetWeeklyShipmentsReport"
        TypeName="iKandi.BLL.ReportController" StartRowIndexParameterName="startIndex"
        EnablePaging="True" MaximumRowsParameterName="pageSize" SelectCountMethod="GetWeeklyShipmentsReportCount"
        OldValuesParameterFormatString="original_{0}">
        <SelectParameters>
            <asp:Parameter Name="startIndex" Type="Int32" />
            <asp:Parameter Name="pageSize" Type="Int32" />
            <asp:SessionParameter DefaultValue="" Name="start" SessionField="StartDate" Type="DateTime" />
            <asp:SessionParameter Name="end" SessionField="EndDate" Type="DateTime" />
            <asp:ControlParameter ControlID="ddlClients" DefaultValue="-1" Name="clientId" PropertyName="SelectedValue"
                Type="Int32" />
            <asp:ControlParameter ControlID="ddlModes" DefaultValue="-1" Name="supplyType" PropertyName="SelectedValue"
                Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
</div>
