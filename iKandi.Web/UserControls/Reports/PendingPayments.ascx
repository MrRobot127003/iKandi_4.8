<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PendingPayments.ascx.cs"
    Inherits="iKandi.Web.PendingPayments" %>
<style type="text/css">
    .quantity_style
    {
        font-size: 11px;
    }
    .bold_text
    {
        font-size: 12px;
    }
    .extra_header
    {
        background-color: #F9F5A0 !important;
        text-transform: capitalize !important;
    }
    .item_list td:first-child
    {
        border-left-color: #999 !important;
    }
    .item_list td:last-child
    {
        border-right-color: #999 !important;
    }
    .item_list tr:last-child > td
    {
        border-bottom-color: #999 !important;
    }
    .form_heading {
    padding: 3px 0px;
    clear:both;
    color:#f2f2f2
}
</style>
<script type="text/javascript">

    var hdnPagesizeClientID = '<%=hdnPagesize.ClientID %>';
    var hdnPageIndexClientID = '<%=hdnPageIndex.ClientID %>';
    $(function () {

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

    function ExportToExcel() {
        var html = document.getElementById('<%=GridView1.ClientID%>').outerHTML;
        html = html.replace(/</g, "~!");
        html = html.replace(/>/g, "!~");
        $("#" + '<%=hfexcel.ClientID%>').val(html);
        return true;
    }

    function showFabricPopup(StyleID, OrderDetailID, OrderID, ClientID, Fabric1, Fabric2, Fabric3, Fabric4, Fabric1Details, Fabric2Details, Fabric3Details, Fabric4Details) {

        proxy.invoke("ShowManageOrderFabricDatesPopup", { StyleID: StyleID, OrderDetailID: OrderDetailID, OrderID: OrderID, ClientID: ClientID, Fabric1: Fabric1, Fabric2: Fabric2, Fabric3: Fabric3, Fabric4: Fabric4, Fabric1Details: Fabric1Details, Fabric2Details: Fabric2Details, Fabric3Details: Fabric3Details, Fabric4Details: Fabric4Details }, function (result) {
            jQuery.facebox(result);
        }, onPageError, false, false);
    }

    function showSizePopup(OrderDetailID) {
        proxy.invoke("GetSizesPopup", { OrderDetailID: OrderDetailID }, function (result) {
            jQuery.facebox(result);

        }, onPageError, false, false);
    }

    function GetManageOrderiKandiQuantityByDept(DepartmentID) {
        proxy.invoke("GetManageOrderiKandiQuantityByDept", { DepartmentID: DepartmentID }, function (result) {
            jQuery.facebox(result);
        }, onPageError, false, false);
    }

    function ShowFitsPopup(StyleNumber, DepartmentID, OrderDetailID) {
        proxy.invoke("ManageOrderFitsInfoPopup", { StyleNumber: StyleNumber, DepartmentID: DepartmentID, OrderDetailID: OrderDetailID }, function (result) {
            jQuery.facebox(result);
        }, onPageError, false, false);
    }
    function GetManageOrderiKandiQuantityByMode(Mode) {
        proxy.invoke("GetManageOrderiKandiQuantityByMode", { Mode: Mode }, function (result) {
            jQuery.facebox(result);
        }, onPageError, false, false);
    }

    function showStatusMeeting(OrderDetailID) {
        proxy.invoke("showStatusMeeting", { OrderDetailID: OrderDetailID }, function (result) {
            jQuery.facebox(result);
        }, onPageError, false, false);
    }

    function XLExport() {
        var i;
        var j;
        var mycell;
        var tableID = "<%=GridView1.ClientID%>";

        var objXL = new ActiveXObject("Excel.Application");
        var objWB = objXL.Workbooks.Add();
        var objWS = objWB.ActiveSheet;

        for (i = 0; i < document.getElementById(tableID).rows.length; i++) {
            for (j = 0; j < document.getElementById(tableID).rows(i).cells.length; j++) {
                mycell = document.getElementById(tableID).rows(i).cells(j)
                objWS.Cells(i + 1, j + 1).Value = mycell.innerText;


            }
        }

        //objWS.Range("A1", "L1").Font.Bold = true;

        objWS.Range("A1", "Z1").EntireColumn.AutoFit();

        //objWS.Range("C1", "C1").ColumnWidth = 50;

        objXL.Visible = true;

    }


</script>
<script type="text/javascript">

    $(function () {
        $(".date-picker").datepicker({ dateFormat: 'dd M y (D)' });
    });
  
</script>
<div class="form_heading">
    Pending Payments
</div>

<table width="1100px" cellpadding="0" cellspacing="0" border="0" style="margin: 5px 0px;">
    <tr>
        <td style="width: 165px">
            Group By
            <asp:DropDownList ID="ddlGroup" runat="server" CssClass="do-not-disable mo_dropdown_style1">
                <asp:ListItem Text="Client" Value="CC"></asp:ListItem>
                <asp:ListItem Text="Due Date" Value="DD"></asp:ListItem>
            </asp:DropDownList>
        </td>
        <td style="width: 150px">
            Due/Be &nbsp;
            <asp:DropDownList ID="ddlDueBE" runat="server" CssClass="do-not-disable mo_dropdown_style1">
                <asp:ListItem Text="None" Value="-1"></asp:ListItem>
                <asp:ListItem Text="Both" Value="3"></asp:ListItem>
                <asp:ListItem Text="DueDate" Value="1"></asp:ListItem>
                <asp:ListItem Text="BEDate" Value="2"></asp:ListItem>
            </asp:DropDownList>
        </td>
        <td style="width: 130px">
            <asp:Label ID="lblfrom" Text="From" runat="server"></asp:Label>&nbsp;
            <input type="text" id="txtfrom" style="width: 90px ! important; font-size: 9px;"
                class="date-picker do-not-disable" runat="server" />
        </td>
        <td style="width: 130px">
            <asp:Label ID="lblTo" Text="To" runat="server"></asp:Label>
            &nbsp;
            <input type="text" id="txtTo" style="width: 90px ! important; font-size: 9px;" class="date-picker do-not-disable"
                runat="server" />
        </td>
        <td style="width: 150px">
            Client &nbsp;
            <asp:DropDownList ID="ddlClients" runat="server" CssClass="do-not-disable mo_dropdown_style1">
                <asp:ListItem Selected="True" Text="All" Value="-1"></asp:ListItem>
            </asp:DropDownList>
        </td>
        <td style="width: 210px">
            Be Number &nbsp;
            <asp:TextBox ID="tbBENumber" CssClass="do-not-disable" runat="server"></asp:TextBox>
        </td>
        <td style="width: 40px">
            <asp:Button ID="btnGo" runat="server" class="go do-not-disable" OnClick="btnGo_click"
                Text="Search" />
        </td>
    </tr>
</table>

<asp:HiddenField ID="hdnPagesize" runat="server" />
<asp:HiddenField ID="hdnPageIndex" runat="server" />
<input type="hidden" id="hdnpageindex" name="hdnpageindex" />
<input type="hidden" id="hdnpagesize" name="hdnpagesize" />
<asp:Panel ID="pnl" runat="server">
    <asp:GridView CssClass=" fixed-header item_list" ID="GridView1" runat="server" AutoGenerateColumns="False"
        OnRowDataBound="GridView1_RowDataBound" Width="100%" DataSourceID="odsPendingPayments">
        <Columns>
            <asp:TemplateField HeaderText="BuyerCode">
                <ItemTemplate>
                    <asp:Label runat="server" ID="lblBuyer" ForeColor="Gray" Text='<%# Eval("CompanyName") != DBNull.Value ? Eval("CompanyName") :"" %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Bank Ref. No.">
                <ItemTemplate>
                    <asp:HiddenField ID="hdnBE" runat="server" />
                    <a id="hypBE" runat="server" class="hide_me"></a><span class="quantity_style">
                        <%# Eval("BENumber") != DBNull.Value ? Eval("BENumber") : "" %></span>
                </ItemTemplate>
                <HeaderStyle Width="120px" HorizontalAlign="Center"></HeaderStyle>
                <ItemStyle CssClass="quantity_style" Width="120px"></ItemStyle>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="BE Date" SortExpression="BE Date">
                <ItemTemplate>
                    <%# (Eval("BEDate") == DBNull.Value || Convert.ToDateTime(Eval("BEDate")) == DateTime.MinValue) ? "" : Convert.ToDateTime(Eval("BEDate")).ToString("dd MMM yy (ddd)")%>
                </ItemTemplate>
                <HeaderStyle></HeaderStyle>
                <ItemStyle CssClass="date_style"></ItemStyle>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Date" SortExpression="Date" Visible="false">
                <ItemTemplate>
                    <%# (Eval("BEDate") == DBNull.Value || Convert.ToDateTime(Eval("BEDate")) == DateTime.MinValue) ? "" : Convert.ToDateTime(Eval("BEDate")).ToString("dd MMM yy (ddd)")%>
                </ItemTemplate>
                <HeaderStyle></HeaderStyle>
                <ItemStyle CssClass="date_style"></ItemStyle>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Currency">
                <ItemTemplate>
                    <asp:Label runat="server" ID="lblCurr" ForeColor="Gray" Text='<%# Eval("ConvertTo") != DBNull.Value ? iKandi.BLL.CommonHelper.GetCurrencyName(Convert.ToInt32(Eval("ConvertTo"))) : "" %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Bill Amount">
                <ItemTemplate>
                    <span>
                        <%# Eval("CurrencySymbol") != DBNull.Value ? Convert.ToString(Eval("CurrencySymbol")) : ""%>
                        <%-- &nbsp;--%>
                        <%# Eval("Total")!= DBNull.Value ? Convert.ToDouble(Eval("Total")).ToString("N2"): "" %>
                    </span>
                </ItemTemplate>
                <ItemStyle CssClass="numeric_text"></ItemStyle>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Pending Amount">
                <ItemTemplate>
                    <span>
                        <%# Eval("CurrencySymbol") != DBNull.Value ? Convert.ToString(Eval("CurrencySymbol")) : ""%>
                        <%--&nbsp;--%>
                        <%# Eval("PendingPayment") != DBNull.Value ? Convert.ToDouble(Eval("PendingPayment")).ToString("N2") : ""%>
                    </span>
                </ItemTemplate>
                <ItemStyle CssClass="numeric_text"></ItemStyle>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="DueDate" SortExpression="DueDate">
                <ItemTemplate>
                    <%# (Eval("PaymentDueDate") == DBNull.Value || Convert.ToDateTime(Eval("PaymentDueDate")) == DateTime.MinValue) ? "" : Convert.ToDateTime(Eval("PaymentDueDate")).ToString("dd MMM yy (ddd)")%>
                </ItemTemplate>
                <HeaderStyle></HeaderStyle>
                <ItemStyle CssClass="date_style" Font-Bold="true"></ItemStyle>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Delay">
                <ItemTemplate>
                    <asp:HiddenField ID="hdnDelay" runat="server" />
                    <a id="hypDelay" runat="server" class="hide_me"></a><span class="quantity_style">
                        <%# Eval("Delay") != DBNull.Value ? Eval("Delay") : "" %></span>
                </ItemTemplate>
                <ItemStyle CssClass="quantity_style"></ItemStyle>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Bill Amount(INR)">
                <ItemTemplate>
                    <%--<%# Eval("Total") != DBNull.Value ? (Convert.ToDouble(Eval("Total")) * Convert.ToDouble(iKandi.BLL.CommonHelper.GetExportConversionRate(iKandi.Common.Currency.GBP, iKandi.Common.Currency.INR))).ToString("N2") : ""%>--%>
                    <%# Eval("Total") != DBNull.Value ? (Convert.ToDouble(Eval("Total")) * Convert.ToDouble(Eval("ConversionRateINR"))).ToString("N2") : ""%>
                </ItemTemplate>
                <ItemStyle CssClass="numeric_text quantity_style"></ItemStyle>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Pending Amount(INR)">
                <ItemTemplate>
                    <%# Eval("Total") != DBNull.Value ? (Convert.ToDouble(Eval("PendingPayment")) * Convert.ToDouble(Eval("ConversionRateINR"))).ToString("N2") : ""%>
                </ItemTemplate>
                <ItemStyle CssClass="numeric_text quantity_style"></ItemStyle>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Remarks" Visible="false">
                <ItemTemplate>
                    <asp:HiddenField ID="hdnGroup" runat="server" Value='<%#Eval("GroupField") %>' />
                    <asp:Label runat="server" ID="lblRemarks" Text='<%# Eval("Remarks") == DBNull.Value ? "" : Eval("Remarks").ToString().Replace("$$", "<br/>") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle Width="100px" HorizontalAlign="Center"></HeaderStyle>
                <ItemStyle CssClass="quantity_style" Width="100px"></ItemStyle>
            </asp:TemplateField>
        </Columns>
        <EmptyDataTemplate>
            <label>
                No records Found</label></EmptyDataTemplate>
    </asp:GridView>
</asp:Panel>
<asp:ObjectDataSource ID="odsPendingPayments" runat="server" SelectMethod="GetPendingPaymentsReport"
    TypeName="iKandi.BLL.ReportController" StartRowIndexParameterName="startIndex"
    OldValuesParameterFormatString="original_{0}" OnSelected="odsPendingPayments_Selected">
    <SelectParameters>
        <asp:Parameter Name="startIndex" Type="Int32" />
        <asp:Parameter Name="pageSize" Type="Int32" />
        <asp:SessionParameter Name="startDate" SessionField="StartDate" Type="DateTime" />
        <asp:SessionParameter Name="endDate" SessionField="EndDate" Type="DateTime" />
        <asp:ControlParameter ControlID="tbBENumber" Name="bENumber" PropertyName="Text"
            Type="String" />
        <asp:ControlParameter ControlID="ddlDueBE" DefaultValue="3" Name="datetype" PropertyName="SelectedValue"
            Type="Int32" />
        <asp:ControlParameter ControlID="ddlClients" DefaultValue="-1" Name="clientID" PropertyName="SelectedValue"
            Type="Int32" />
        <asp:ControlParameter ControlID="ddlGroup" DefaultValue="CC" Name="GroupField" PropertyName="SelectedValue"
            Type="String" />
    </SelectParameters>
</asp:ObjectDataSource>

<asp:HiddenField ID="hfexcel" runat="server" />
<div style="margin-top:5px">
<asp:Button ID="btnExportToExcel" runat="server" CssClass="exporttoexcel da_submit_button"
    Text="Export To Excel" OnClick="btnExportToExcel_Click" OnClientClick="JavaScript:return ExportToExcel()" />
&nbsp;&nbsp;
<asp:Button ID="btnExportToPdf" runat="server" CssClass="exporttopdf da_submit_button"
    Text="Export To Pdf" OnClick="btnExportToPdf_Click" OnClientClick="JavaScript:return ExportToExcel()" />
</div>