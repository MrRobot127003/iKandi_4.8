<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ShipmentMonthlyDetails.ascx.cs"
    Inherits="iKandi.Web.ShipmentMonthlyDetails" %>

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
        Monthly Details Of Shipment
    </div>
    <div>
        <table width="500px" cellspacing="5">
            <tr>
                <td>
                    Month:
                </td>
                <td>
                    <asp:DropDownList Width="125px" ID="ddlMonths" runat="server" CssClass="do-not-disable">
                    </asp:DropDownList>
                </td>
                <td>
                    Year:
                </td>
                <td>
                    <asp:DropDownList Width="125px" ID="ddlYears" runat="server" CssClass="do-not-disable">
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
    <asp:GridView CssClass=" fixed-header item_list1" ID="GridView1" runat="server" ShowFooter="true"
        AutoGenerateColumns="False" OnRowDataBound="GridView1_RowDataBound" DataSourceID="odsMonthlyShipments">
        <Columns>
            <asp:TemplateField HeaderText="Bill To">
                <ItemTemplate>
                    <asp:HiddenField ID="hdnSupplyType" runat="server" Value='<%# Eval("SupplyType") %>' />
                    <asp:Label runat="server" ID="lblBillTo" Text='<%# Convert.ToInt32(Eval("SupplyType")) == 1 ? "IKANDI" : (Eval("CompanyName") != DBNull.Value ? Eval("CompanyName") : "") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle CssClass="vertical_header"></HeaderStyle>
                <ItemStyle CssClass="vertical_text"></ItemStyle>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Division">
                <ItemTemplate>
                    <asp:Label runat="server" ID="lblDivision" Text='<%# Eval("CompanyName") != DBNull.Value ? Eval("CompanyName") : "" %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle CssClass="vertical_header"></HeaderStyle>
                <ItemStyle CssClass="vertical_text"></ItemStyle>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="AWB/BLNo.">
                <ItemTemplate>
                    <span class="quantity_style">
                        <%# Eval("BLAWBNo") != DBNull.Value ? Eval("BLAWBNo") : ""%></span>
                </ItemTemplate>
                <HeaderStyle CssClass="vertical_header "></HeaderStyle>
                <ItemStyle CssClass="vertical_text quantity_style"></ItemStyle>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="HAWBNo.">
                <ItemTemplate>
                    <span class="quantity_style">
                        <%# Eval("HAWBNO") != DBNull.Value ? Eval("HAWBNO") : "" %></span>
                </ItemTemplate>
                <HeaderStyle CssClass="vertical_header "></HeaderStyle>
                <ItemStyle CssClass="vertical_text quantity_style"></ItemStyle>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="AWB.DATE" SortExpression="HAWBDate">
                <ItemTemplate>
                    <span style="width: 140px ! important;">
                        <%# (Eval("HAWBDate") == DBNull.Value || Convert.ToDateTime(Eval("HAWBDate")) == DateTime.MinValue) ? "" : Convert.ToDateTime(Eval("HAWBDate")).ToString("dd MMM yy (ddd)")%>
                    </span>
                </ItemTemplate>
                <HeaderStyle Width="140px"></HeaderStyle>
                <ItemStyle CssClass="date_style bold_text" Width="140px"></ItemStyle>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Invoice No." HeaderStyle-Width="140px" ItemStyle-Width="140px">
                <ItemTemplate>
                    <span style="width: 140px ! important"><a class='<%# (Eval("InvoiceId") != DBNull.Value)? "":"hide_me" %>'
                        onclick="launchBiplInvoice('<%#Eval("InvoiceId")%>')">
                        <%# Eval("InvoiceNumber") != DBNull.Value ? (Eval("InvoiceNumber").ToString().Trim() == "" ? "View" : Eval("InvoiceNumber").ToString()) : (Eval("InvoiceId") != DBNull.Value ? "View" : "")%>
                    </a></span>
                </ItemTemplate>
                <ItemStyle CssClass="quantity_style"></ItemStyle>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Order No.">
                <ItemTemplate>
                    <asp:HiddenField ID="hdnSerial" runat="server" />
                    <a id="hypSerial" runat="server" class="hide_me"></a><span class="quantity_style">
                        <%# Eval("OrderNumber") != DBNull.Value ? Eval("OrderNumber") : ""%></span>
                </ItemTemplate>
                <HeaderStyle CssClass="vertical_header "></HeaderStyle>
                <ItemStyle CssClass="vertical_text quantity_style"></ItemStyle>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Style No.">
                <ItemTemplate>
                    <span style="width: 80px ! important;">
                        <nobr><%# Eval("StyleNumber") != DBNull.Value ? Eval("StyleNumber") : "" %></nobr>
                    </span>
                    <br />
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" Width="80px"></HeaderStyle>
                <ItemStyle Width="80px"></ItemStyle>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Quantity" HeaderStyle-Width="70px" ItemStyle-Width="70px">
                <ItemTemplate>
                    <asp:Label ID="lblQty" Width="70px" runat="server" CssClass="quantity_style" Text='<%# (Eval("Quantity") == DBNull.Value || Eval("Quantity") == "") ? "" :  Convert.ToInt32(Eval("Quantity")).ToString("N0") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="UNIT PRICE">
                <ItemTemplate>
                    <span style="width: 90px ! important;">
                        <nobr>
                        <asp:Label ID="lblUnitPriceSign" runat="server"></asp:Label>
                        <asp:Label ID="lblUnitPric" runat="server" Text='<%# Eval("UnitPrice") == DBNull.Value ? "" :  ( Convert.ToDouble(Eval("UnitPrice")).ToString("N2"))%>'></asp:Label>
                        </nobr>
                        <asp:HiddenField ID="hdnUnitPrice" runat="server" Value='<%#Eval("UnitPrice") == DBNull.Value ? "0" : Eval("UnitPrice")%>' />
                    </span>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" Width="90px"></HeaderStyle>
                <ItemStyle CssClass="numeric_text" Width="90px"></ItemStyle>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="FOB VALUE">
                <ItemTemplate>
                    <span style="width: 90px ! important;">
                        <nobr>
                        <asp:Label ID="lblFobValueSign" runat="server"></asp:Label>
                        <asp:Label ID="lblFobValue" runat="server" Text='<%# Eval("FOBValue") == DBNull.Value ? "" : ( Convert.ToDouble(Eval("FOBValue")).ToString("N2"))%>'></asp:Label>
                            </nobr>
                    </span>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" Width="90px"></HeaderStyle>
                <ItemStyle CssClass="numeric_text" Width="90px"></ItemStyle>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="FREIGHT">
                <ItemTemplate>
                    <span style="width: 90px ! important;">
                        <nobr>
                        <asp:Label ID="lblFreightSign" runat="server"></asp:Label>
                        <asp:Label ID="lblFreight" runat="server" Text='<%# Eval("Freight") == DBNull.Value ? "" : ( Convert.ToDouble(Eval("Freight")).ToString("N2"))%>'></asp:Label>
                    </nobr>
                    </span>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" Width="90px"></HeaderStyle>
                <ItemStyle CssClass="numeric_text" Width="90px"></ItemStyle>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="INSURANCE">
                <ItemTemplate>
                    <span style="width: 90px ! important;">
                        <nobr>
                        <asp:Label ID="lblInsuranceSign" runat="server"></asp:Label>
                        <asp:Label ID="lblInsurance" runat="server" Text='<%# Eval("Insurance") == DBNull.Value ? "" : (Convert.ToDouble(Eval("Insurance")).ToString("N2"))%>'></asp:Label>
                    </nobr>
                    </span>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" Width="90px"></HeaderStyle>
                <ItemStyle CssClass="numeric_text" Width="90px"></ItemStyle>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="TOTAL CIF">
                <ItemTemplate>
                    <span style="width: 90px ! important;">
                        <nobr>
                        <asp:Label ID="lblCifSign" runat="server"></asp:Label>
                        <asp:Label ID="lblTotalCif" runat="server" Text='<%# Eval("TotalCIF") == DBNull.Value ? "" : (Convert.ToDouble(Eval("TotalCIF")).ToString("N2"))%>'></asp:Label>
                        <asp:HiddenField ID="hdnTotalBill" runat="server" Value='<%#Eval("TotalBill") == DBNull.Value ? "0" : Eval("TotalBIll")%>' />
                    
                    </nobr>
                    </span>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" Width="90px"></HeaderStyle>
                <ItemStyle CssClass="numeric_text" Width="90px"></ItemStyle>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="TOTAL BILL">
                <ItemTemplate>
                    <span style="width: 90px ! important;"></span>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" Width="90px"></HeaderStyle>
                <ItemStyle CssClass="numeric_text" Width="90px"></ItemStyle>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="BANK REF">
                <ItemTemplate>
                    <span class="quantity_style" style="width: 140px ! important;">
                        <%# Eval("BENumber") != DBNull.Value ?  Eval("BENumber") : ""%></span>
                </ItemTemplate>
                <HeaderStyle Width="140" HorizontalAlign="Center"></HeaderStyle>
                <ItemStyle Width="140" CssClass="quantity_style" HorizontalAlign="Center"></ItemStyle>
            </asp:TemplateField>
        </Columns>
        <EmptyDataTemplate>
            <label>
                No records Found</label>
        </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource ID="odsMonthlyShipments" runat="server" SelectMethod="GetShipmentMonthlyDetailsReport"
        TypeName="iKandi.BLL.ReportController" StartRowIndexParameterName="startIndex"
        EnablePaging="True" MaximumRowsParameterName="pageSize" SelectCountMethod="GetShipmentMonthlyDetailsReportCount"
        OldValuesParameterFormatString="original_{0}">
        <SelectParameters>
            <asp:Parameter Name="startIndex" Type="Int32" />
            <asp:Parameter Name="pageSize" Type="Int32" />
            <asp:ControlParameter ControlID="ddlMonths" DefaultValue="-1" Name="month" PropertyName="SelectedValue"
                Type="Int32" />
            <asp:ControlParameter ControlID="ddlYears" DefaultValue="-1" Name="year" PropertyName="SelectedValue"
                Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
</div>
