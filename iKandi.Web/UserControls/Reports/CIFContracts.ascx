<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CIFContracts.ascx.cs"
    Inherits="iKandi.Web.CIFContracts" %>

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
        proxy.invoke("ShowManageOrderFabricDatesPopup", { StyleID: StyleID,OrderDetailID: OrderDetailID, OrderID: OrderID, ClientID: ClientID, Fabric1: Fabric1, Fabric2: Fabric2, Fabric3: Fabric3, Fabric4: Fabric4, Fabric1Details: Fabric1Details, Fabric2Details: Fabric2Details, Fabric3Details: Fabric3Details, Fabric4Details: Fabric4Details }, function(result) {
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
        CIF Contracts
    </div>
    <div>
        <table width="500px" cellspacing="5">
            <tr>
                <td>
                    Month:
                </td>
                <td>
                    <asp:DropDownList Width="125px" ID="ddlMonths" runat="server" CssClass="do-not-disable">
                        <asp:ListItem Text="ALL" Value="-1" Selected="True"></asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    Year:
                </td>
                <td>
                    <asp:DropDownList Width="125px" ID="ddlYears" runat="server" CssClass="do-not-disable">
                        <asp:ListItem Text="ALL" Value="-1" Selected="True"></asp:ListItem>
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
        AllowPaging="true" PageSize="10" Width="100%">
        <Columns>
            <asp:TemplateField HeaderText="Order Date" HeaderStyle-HorizontalAlign="Center" ItemStyle-CssClass="date_style"
                HeaderStyle-Width="60px" ItemStyle-Width="60px">
                <ItemTemplate>
                    <span>
                        <%# (Convert.ToDateTime(Eval("OrderDate")) == DateTime.MinValue)? "" : Convert.ToDateTime(Eval("OrderDate")).ToString("dd MMM yy (ddd)") %>
                    </span>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Serial No." ItemStyle-CssClass="hypSerial" HeaderStyle-Width="60px"
                ItemStyle-Width="60px" HeaderStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <input type="hidden" id="hdnOrderID" value='<%# Eval("OrderID") %>' />
                    <asp:Label ID="lblSerialNo" runat="server" CssClass="quantity_style" Text='<%# Eval("SerialNumber")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Dept." HeaderStyle-Width="50px" ItemStyle-Width="50px"
                HeaderStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <span>
                        <%# Eval("DepartmentName")%></span>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Style No." HeaderStyle-Width="60px" ItemStyle-Width="60px">
                <ItemTemplate>
                    <span>
                        <nobr>
                        <%# Eval("StyleNumber") %>
                        </nobr>
                    </span>
                    <br />
                    <a title="CLICK TO VIEW ENLARGED IMAGE" href="javascript:void(0)" onclick='showStylePhotoWithOutScroll(<%# Eval("StyleID").ToString()+",-1,"+Eval("OrderDetailID").ToString() %>)'>
                        <img style="height: 75px ! important" title="CLICK TO VIEW ENLARGED IMAGE" border="0px"
                            src='<%# ResolveUrl("~/uploads/style/thumb-" + Eval("SampleImageURL1").ToString()) %>' /></a>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Weight" HeaderText="Weight" SortExpression="Weight" HeaderStyle-Width="40px" />
            <asp:BoundField DataField="LineItemNumber" HeaderText="Line No" SortExpression="LineItemNumber"
                HeaderStyle-CssClass="vertical_header" ItemStyle-CssClass="vertical_text" HeaderStyle-Width="28px" />
            <asp:BoundField DataField="ContractNumber" HeaderText="Contract No" SortExpression="ContractNumber"
                HeaderStyle-CssClass="vertical_header" ItemStyle-CssClass="vertical_text" HeaderStyle-Width="28px" />
            <asp:TemplateField HeaderText="Description" SortExpression="Description" HeaderStyle-Width="150px"
                ItemStyle-Width="150px" HeaderStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:Label ID="lblDiscription" runat="server" Height="100px" Text='<%# Eval("Description") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Qty" ItemStyle-CssClass="numeric_text quantity_style"
                HeaderStyle-Width="60px" ItemStyle-Width="60px">
                <ItemTemplate>
                    <span style="width: 60px !important">
                        <%#Eval("Quantity") %></span>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Fabric/Details" SortExpression="Fabric1" HeaderStyle-Width="200px"
                ItemStyle-Width="200px">
                <ItemTemplate>
                    <div class="fabric_left_style">
                        <span>
                            <nobr>
                            <span runat="server" id="fabric1name">
                                <%# Eval("Fabric1")%>
                            </span>
                            <label class="<%#(Eval("Fabric1Details").ToString().Trim() == "" ) ? "hide_me": "" %>">
                            : <%# Eval("Fabric1Details")%></label>
                        </nobr>
                            <nobr>
                            <br />
                            <span runat="server" id="fabric2name">
                                <%# Eval("Fabric2")%>
                            </span>
                            <label class="<%#(Eval("Fabric2Details").ToString().Trim() == "" ) ? "hide_me": "" %>">
                            : <%# Eval("Fabric2Details")%></label>
                        </nobr>
                            <nobr>
                            <br />
                            <span runat="server" id="fabric3name">
                                <%# Eval("Fabric3")%>
                            </span>
                            <label class="<%#(Eval("Fabric3Details").ToString().Trim() == "" ) ? "hide_me": "" %>">
                            : <%# Eval("Fabric3Details")%></label>
                        </nobr>
                            <nobr>
                            <br />
                            <span runat="server" id="fabric4name">
                                <%# Eval("Fabric4")%>
                            </span>
                            <label class="<%#(Eval("Fabric4Details").ToString().Trim() == "" ) ? "hide_me": "" %>">
                            : <%# Eval("Fabric4Details")%></label>
                        </nobr>
                    </div>
                    <br />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Ex Factory" SortExpression="ExFactory" ItemStyle-CssClass="date_style bold_text"
                HeaderStyle-Width="120px">
                <ItemTemplate>
                    <%# (Convert.ToDateTime(Eval("ExFactory")) == DateTime.MinValue) ? "" : Convert.ToDateTime(Eval("ExFactory")).ToString("dd MMM yy (ddd)")%>
                    <asp:HiddenField runat="server" ID="lblEx" Value='<%# (Convert.ToDateTime(Eval("ExFactory")) == DateTime.MinValue) ? "" : (Convert.ToDateTime(Eval("ExFactory"))).ToString("dd MMM yy (ddd)")%>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="DC Date" SortExpression="DC" HeaderStyle-HorizontalAlign="Center"
                ItemStyle-CssClass="date_style" HeaderStyle-Width="60px" ItemStyle-Width="60px">
                <ItemTemplate>
                    <%# (Convert.ToDateTime(Eval("DC")) == DateTime.MinValue) ? "" : (Convert.ToDateTime(Eval("DC"))).ToString("dd MMM yy (ddd)")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Price" HeaderStyle-CssClass="vertical_header" ItemStyle-CssClass="numeric_text vertical_text"
                HeaderStyle-Width="28px">
                <ItemTemplate>
                    <%# iKandi.Common.Constants.GetCurrencySymbalByCurrencyType(Eval("ConvertTo") == DBNull.Value ? -1 : Convert.ToInt32(Eval("ConvertTo")))%>
                    <span>
                        <%#Convert.ToDouble(Eval("BIPLPrice")).ToString("N2")%>
                    </span>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Status" HeaderStyle-CssClass="vertical_header" ItemStyle-CssClass="vertical_text"
                HeaderStyle-Width="28px">
                <ItemTemplate>
                    <span id="spanstatusmode" runat="server">
                        <%# Eval("StatusMode")%>
                    </span>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <EmptyDataTemplate>
            <label>
                No records Found</label></EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource ID="odsCIFContracts" runat="server" SelectMethod="GetCIFContracts"
        TypeName="iKandi.BLL.ReportController" OldValuesParameterFormatString="original_{0}">
    </asp:ObjectDataSource>
</div>
