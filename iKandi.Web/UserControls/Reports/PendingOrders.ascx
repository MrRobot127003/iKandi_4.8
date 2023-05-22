<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PendingOrders.ascx.cs"
    Inherits="iKandi.Web.PendingOrders" %>

<script type="text/javascript">

    var hdnPagesizeClientID = '<%=hdnPagesize.ClientID %>';
    var hdnPageIndexClientID = '<%=hdnPageIndex.ClientID %>';
    $(function() {

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
  
  
 
  
</script>

<div class="form_box">
    <div class="form_heading">
        Pending Orders
    </div>
    <div>
        <table width="500px" cellspacing="5">
            <tr>
                <td>
                    ExFactory/DC
                </td>
                <td>
                    <asp:DropDownList ID="ddlExFactoryDC" runat="server" CssClass="do-not-disable mo_dropdown_style1">
                        <asp:ListItem Text="Both" Value="3"></asp:ListItem>
                        <asp:ListItem Text="ExFactory" Value="1"></asp:ListItem>
                        <asp:ListItem Text="DC" Value="2"></asp:ListItem>
                        <asp:ListItem Text="None" Selected="True" Value="-1"></asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:Label ID="lblfrom" Text="From" runat="server"></asp:Label>
                </td>
                <td>
                    <input type="text" id="txtfrom" style="width: 90px ! important;" class="date-picker do-not-disable"
                        runat="server" />
                </td>
                <td>
                    <asp:Label ID="lblTo" Text="To" runat="server"></asp:Label>
                </td>
                <td>
                    <input type="text" id="txtTo" style="width: 90px ! important;" class="date-picker do-not-disable"
                        runat="server" />
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
    <table width="600px" class="item_list1">
        <tr>
            <th>
                Total Quantity
            </th>
            <td>
                <asp:Label runat="server" ID="lblTotalQuantity"></asp:Label>
            </td>
            <th>
                Total Amount
            </th>
            <td>
                &pound;<asp:Label runat="server" ID="lblTotalAmount"></asp:Label>
            </td>
        </tr>
    </table>
    <asp:GridView CssClass=" fixed-header item_list1" ID="GridView1" runat="server" AutoGenerateColumns="False"
        OnRowDataBound="GridView1_RowDataBound" OnPageIndexChanging="GridView1_PageIndexChanging"
        AllowPaging="True" DataSourceID="odsPendingOrders">
        <Columns>
            <asp:TemplateField HeaderText="Buyer" HeaderStyle-CssClass="vertical_header" ItemStyle-CssClass="vertical_text">
                <ItemTemplate>
                    <asp:Label runat="server" ID="lblBuyer" Text='<%# Eval("Buyer") != DBNull.Value ?  Eval("Buyer") : ""  %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle CssClass="vertical_header"></HeaderStyle>
                <ItemStyle CssClass="vertical_text"></ItemStyle>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Order No." HeaderStyle-CssClass="vertical_header "
                ItemStyle-CssClass="vertical_text quantity_style">
                <ItemTemplate>
                    <asp:HiddenField ID="hdnSerial" runat="server" />
                    <a id="hypSerial" runat="server" class="hide_me"></a><span class="quantity_style">
                        <%# Eval("OrderNumber") != DBNull.Value ? Eval("OrderNumber") : "" %></span>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Style No." HeaderStyle-Width="60px" ItemStyle-Width="60px">
                <ItemTemplate>
                    <span>
                        <nobr>
                    <%# Eval("StyleNumber") != DBNull.Value ? Eval("StyleNumber") : "" %>
                    </nobr>
                    </span>
                    <br />
                    <a title="CLICK TO VIEW ENLARGED IMAGE" href="javascript:void(0)" onclick='showStylePhotoWithOutScroll(<%# Eval("StyleID").ToString()+",-1,"+Eval("OrderDetailID").ToString() %>)'>
                        <img style="height: 75px ! important" title="CLICK TO VIEW ENLARGED IMAGE" border="0px"
                            src='<%# ResolveUrl("~/uploads/style/thumb-" + Eval("SampleImageURL1").ToString()) %>' /></a>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="LineItemNumber" HeaderText="Line No" SortExpression="LineItemNumber"
                HeaderStyle-CssClass="vertical_header" ItemStyle-CssClass="vertical_text" HeaderStyle-Width="28px"
                ItemStyle-Width="28px"></asp:BoundField>
            <asp:TemplateField HeaderText="Description" SortExpression="Description" HeaderStyle-Width="150px"
                ItemStyle-Width="150px" HeaderStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:Label ID="lblDiscription" runat="server" Height="100px" Width="150px" Text='<%# Eval("Description") != DBNull.Value ? Eval("Description") : "" %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Fabric/Details" SortExpression="Fabric1" HeaderStyle-Width="200px"
                ItemStyle-Width="200px">
                <ItemTemplate>
                    <div class="fabric_left_style" style="width: 200px ! important;">
                        <span>
                            <nobr>
                            <span runat="server" id="fabric1name">
                                <%# Eval("Fabric1") != DBNull.Value ? Eval("Fabric1") : ""%>
                            </span>
                            <label class="<%#(Eval("Fabric1Details").ToString().Trim() == "" || Eval("Fabric1Details") == DBNull.Value ) ? "hide_me": "" %>">
                            : <%# Eval("Fabric1Details") != DBNull.Value ? Eval("Fabric1Details") : "" %></label>
                        </nobr>
                            <nobr>
                            <br />
                            <span runat="server" id="fabric2name">
                                <%# Eval("Fabric2") != DBNull.Value ? Eval("Fabric2") : "" %>
                            </span>
                            <label class="<%#(Eval("Fabric2Details").ToString().Trim() == "" || Eval("Fabric2Details") == DBNull.Value ) ? "hide_me": "" %>">
                            : <%# Eval("Fabric2Details") != DBNull.Value ? Eval("Fabric2Details") : ""%></label>
                        </nobr>
                            <nobr>
                            <br />
                            <span runat="server" id="fabric3name">
                                <%# Eval("Fabric3") != DBNull.Value ? Eval("Fabric3") : ""%>
                            </span>
                            <label class="<%#(Eval("Fabric3Details").ToString().Trim() == ""  || Eval("Fabric3Details") == DBNull.Value) ? "hide_me": "" %>">
                            : <%# Eval("Fabric3Details") != DBNull.Value ? Eval("Fabric3Details") : ""%></label>
                        </nobr>
                            <nobr>
                            <br />
                            <span runat="server" id="fabric4name">
                                <%# Eval("Fabric4") != DBNull.Value ? Eval("Fabric4") : "" %>
                            </span>
                            <label class="<%#(Eval("Fabric4Details").ToString().Trim() == "" || Eval("Fabric4Details") == DBNull.Value ) ? "hide_me": "" %>">
                            : <%# Eval("Fabric4Details") != DBNull.Value ?  Eval("Fabric4Details") : "" %></label>
                        </nobr>
                    </div>
                    <br />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Total QTY" HeaderStyle-Width="80px" ItemStyle-Width="80px">
                <ItemTemplate>
                    <asp:Label ID="lblQty" Width="80px" runat="server" CssClass="quantity_style" Text='<%# Eval("Quantity") == DBNull.Value ? "" : Convert.ToInt32(Eval("Quantity")).ToString("N0") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Price in FC" ItemStyle-CssClass="numeric_text" HeaderStyle-Width="100px"
                ItemStyle-Width="100px">
                <ItemTemplate>
                    <span style="width: 100px! important;">
                        <nobr>
                        <asp:Label ID="lblPriceInFCSign" runat="server"></asp:Label>
                            <asp:Label ID="lblPriceInFC" runat="server" Text='<%# Eval("BIPLPrice")!=DBNull .Value ? Convert.ToDouble(Eval("BIPLPrice")).ToString("N2"):""%>'></asp:Label>
                        </nobr>
                    </span>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Amount in FC" ItemStyle-CssClass="numeric_text" HeaderStyle-Width="100px"
                ItemStyle-Width="100px">
                <ItemTemplate>
                    <span style="width: 100px ! important;">
                        <nobr>
                        <asp:Label ID="lblAmountInFCSign" runat="server"></asp:Label>
                        <asp:Label ID="lblAmountInFC" runat="server" Text='<%# Eval("Amount")!=DBNull .Value ? Convert.ToDouble(Eval("Amount")).ToString("N2"):""%>'></asp:Label>
                        </nobr>
                    </span>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Ex Factory Date" SortExpression="ExFactory" ItemStyle-CssClass="date_style bold_text"
                HeaderStyle-Width="140px" ItemStyle-Width="140px">
                <ItemTemplate>
                    <asp:Label ID="lblExFactoryDate" runat="server" Width="140px" Text='<%# (Eval("ExFactory") == DBNull.Value || Convert.ToDateTime(Eval("ExFactory")) == DateTime.MinValue) ? "" : Convert.ToDateTime(Eval("ExFactory")).ToString("dd MMM yy (ddd)")%>'></asp:Label>
                    <asp:HiddenField runat="server" ID="lblEx" Value='<%# (Eval("ExFactory") == DBNull.Value || Convert.ToDateTime(Eval("ExFactory")) == DateTime.MinValue) ? "" : (Convert.ToDateTime(Eval("ExFactory"))).ToString("dd MMM yy (ddd)")%>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Mode" HeaderStyle-CssClass="vertical_header" ItemStyle-CssClass="vertical_text">
                <ItemTemplate>
                    <asp:Label runat="server" ID="lblMode" Text=' <%# Eval("ModeName") != DBNull.Value ? Eval("ModeName") : "" %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Dc Date" SortExpression="DC" ItemStyle-CssClass="date_style bold_text"
                HeaderStyle-Width="140px" ItemStyle-Width="140px">
                <ItemTemplate>
                    <asp:Label ID="lblDcDate" runat="server" Width="140px" Text='<%# (Eval("DC") == DBNull.Value || Convert.ToDateTime(Eval("DC")) == DateTime.MinValue) ? "" : Convert.ToDateTime(Eval("DC")).ToString("dd MMM yy (ddd)")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Status" HeaderStyle-Width="100px" ItemStyle-Width="100px">
                <ItemTemplate>
                    <asp:Label ID="lblStatusMode" runat="server" Width="100px" Text='<%# Eval("Name") != DBNull.Value ? Eval("Name") : ""%>'></asp:Label>
                    <asp:HiddenField ID="hdnStatusMode" runat="server" Value='<%# Eval("StatusModeID") == DBNull.Value ? "-1" : ( Eval("StatusModeID").ToString()) %>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Unit" HeaderStyle-CssClass="vertical_header" ItemStyle-CssClass="vertical_text quantity_style">
                <ItemTemplate>
                    <asp:Label ID="lblUnit" runat="server" ToolTip='<%# Eval("FactoryName") != DBNull.Value ? Eval("FactoryName") : "" %>'
                        Text='<%# Eval("FactoryCode") == DBNull.Value ? string.Empty : Eval("FactoryCode").ToString() %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Remarks" HeaderStyle-Width="250px" ItemStyle-Width="250px"
                ItemStyle-CssClass="remarks_text remarks_text2">
                <ItemTemplate>
                    <asp:Label ID="lblRemarks" runat="server" Width="250px" Text='<%# Eval("Remarks") == DBNull.Value ? "" : Eval("Remarks").ToString().Replace("$$", "<br />") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <EmptyDataTemplate>
            <label>
                No records Found</label></EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource ID="odsPendingOrders" runat="server" SelectMethod="GetPendingOrdersReport"
        TypeName="iKandi.BLL.ReportController" StartRowIndexParameterName="startIndex"
        EnablePaging="True" MaximumRowsParameterName="pageSize" SelectCountMethod="GetPendingOrdersReportCount"
        OldValuesParameterFormatString="original_{0}">
        <SelectParameters>
            <asp:Parameter Name="startIndex" Type="Int32" />
            <asp:Parameter Name="pageSize" Type="Int32" />
            <asp:SessionParameter Name="start" SessionField="StartDate" Type="DateTime" />
            <asp:SessionParameter Name="end" SessionField="EndDate" Type="DateTime" />
            <asp:ControlParameter ControlID="ddlExFactoryDC" DefaultValue="3" Name="datetype"
                PropertyName="SelectedValue" Type="Int32" />
            <asp:ControlParameter ControlID="ddlClients" DefaultValue="-1" Name="clientID" PropertyName="SelectedValue"
                Type="Int32" />
            <asp:ControlParameter ControlID="ddlModes" DefaultValue="-1" Name="supplyType" PropertyName="SelectedValue"
                Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
</div>
