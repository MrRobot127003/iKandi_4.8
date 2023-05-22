<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FabricQualityList.ascx.cs"
    Inherits="iKandi.Web.UserControls.Lists.FabricQualityList" %>
<%@ Register Assembly="iKandi.Web" Namespace="iKandi.Components.UI" TagPrefix="cc1" %>

<script type="text/javascript">
    var serviceUrl = '<%= ResolveUrl("~/Webservices/iKandiService.asmx/") %>';
    var proxy = new ServiceProxy(serviceUrl);
    var jscriptPageVariables = null;
    var GroupDDClientID = '<%=ddlGroup.ClientID%>';
    var SubGroupDDClientID = '<%=ddlSubGroup.ClientID%>';
    var hdnSubGroupClientID = '<%=hiddenSubGroupId.ClientID %>';
    var objddlGroup = '<%= ddlGroup.ClientID %>';
    var objddlSubGroup = '<%= ddlSubGroup.ClientID %>';
    var objddlReg = '<%= ddlReg.ClientID %>';
    var objOrderBy1 = '<%= ddlOrder1.ClientID %>';
    var objOrderBy2 = '<%= ddlOrder2.ClientID %>';
    var objOrderBy3 = '<%= ddlOrder3.ClientID %>';
    var objOrderBy4 = '<%= ddlOrder4.ClientID %>';


    $(function () {
        BindControls();
        $("a[rel=lightbox]").lightBox({

            imageLoading: '/app_themes/ikandi/images/lightbox-ico-loading.gif',

            imageBtnPrev: '/app_themes/ikandi/images/lightbox-btn-prev.gif',

            imageBtnNext: '/app_themes/ikandi/images/lightbox-btn-next.gif',

            imageBtnClose: '/app_themes/ikandi/images/lightbox-btn-close.gif',

            imageBlank: '/app_themes/ikandi/images/lightbox-blank.gif'

        });

        $("#" + GroupDDClientID, '#main_content').change(function () {
            var groupId = $(this).val();
            populateSubGroups($(this).val());
        });

        $("#" + SubGroupDDClientID, '#main_content').change(function () {
            $("#" + hdnSubGroupClientID, "#main_content").val($(this).val());
            selectedSubGroup = $("#" + SubGroupDDClientID).find("option:selected").text();
            setSubGroup();
        });
        populateSubGroups($("#" + GroupDDClientID, '#main_content').val());



        $("#" + objddlGroup, '#main_content').change(function () {
            setDDlGroupByValue();
        });

        $("#" + objddlSubGroup, '#main_content').change(function () {
            setDDLSubGroupbyValue();
        });

        $("#" + objddlReg, '#main_content').change(function () {
            SetobjddlRegByValue();
        });

    });

    function populateSubGroups(groupId, selectedSubGroupID) {
        //debugger;
        if (groupId > 0)
            bindDropdown(serviceUrl, SubGroupDDClientID, "GetSubGroupByGroupID", { CategoryID: groupId }, "CategoryName", "CategoryID", true, (jscriptPageVariables != null) ? jscriptPageVariables.selectedSubGroupID : selectedSubGroupID, onPageError, setSubGroup);
        if (jscriptPageVariables != null && jscriptPageVariables.selectedSubGroupID != null && jscriptPageVariables.selectedSubGroupID != '')
            jscriptPageVariables.selectedSubGroupID = '';
        $("#" + SubGroupDDClientID, '#main_content').val($("#" + hdnSubGroupClientID, "#main_content").val());
    }

    function setSubGroup() {
        selectedSubGroup = $("#" + SubGroupDDClientID, "#main_content").val();
        $("#" + SubGroupDDClientID, '#main_content').val($("#" + hdnSubGroupClientID, "#main_content").val());
    }

    function setDDlGroupByValue() {
        selectedGroupValue = $("#" + objddlGroup, "#main_content").find("option:selected").val();

    }

    function setDDLSubGroupbyValue() {
        selectedSubGroupValue = $("#" + objddlSubGroup, "#main_content").find("option:selected").val();

    }
    function SetobjddlRegByValue() {
        selectedddlRegByValue = $("#" + objddlReg, "#main_content").find("option:selected").val();

    }

    function PrintFabricQuality() {
        setDDlGroupByValue();
        setDDLSubGroupbyValue();
        SetobjddlRegByValue();

        var PageSize = 9;
        var PageIndex = '<%=this.PageIndex %>';

        var objSearchText = '<%=txtSearch.ClientID%>';
        var SearchText = $("#" + objSearchText).val();
        //alert("Search" + SearchText);

        // var objGroupId = '<%=hdnDDGroup.ClientID%>';
        var GroupId = selectedGroupValue;
        //alert("GroupId" + GroupId);

        //var objSubGroupID = '<%=hiddenSubGroupId.ClientID%>';
        var SubGroupId = selectedSubGroupValue;
        //alert("SubGroup" + SubGroupId);

        var objGsmFrom = '<%=txtGsmFrom.ClientID%>';
        var GsmFrom = $("#" + objGsmFrom).val();
        // alert("GsmFrom" + GsmFrom);

        var objGsmTo = '<%=txtGsmTo.ClientID%>';
        var GsmTo = $("#" + objGsmTo).val();
        // alert("Gsm to" + GsmTo);

        var objWidthFrom = '<%=txtWidthFrom.ClientID%>';
        var WidthFrom = $("#" + objWidthFrom).val();
        // alert("widthfrom" + WidthFrom);

        var objWidthTo = '<%=txtWidthTo.ClientID%>';
        var WidthTo = $("#" + objWidthTo).val();
        // alert("widthTo" + WidthTo);

        var objPriceFrom = '<%=txtPriceFrom.ClientID%>';
        var PriceFrom = $("#" + objPriceFrom).val();
        // alert("PriceFrom" + PriceFrom);

        var objPriceTo = '<%=txtPriceTo.ClientID%>';
        var PriceTo = $("#" + objPriceTo).val();
        //  alert("PriceTo" + PriceTo);

        //var objIsReg ='<%=hdnDDIsReg.ClientID%>';
        var IsReg = selectedddlRegByValue;
        //alert("IsReg" + IsReg);

        proxy.invoke("GenerateFabricQualityPDF", { PageSize: PageSize, PageIndex: PageIndex, SearchText: SearchText, GroupId: GroupId, SubGroupId: SubGroupId, GsmFrom: GsmFrom, GsmTo: GsmTo, WidthFrom: WidthFrom, WidthTo: WidthTo, PriceFrom: PriceFrom, PriceTo: PriceTo, IsReg: IsReg, Order1: $("#" + objOrderBy1, "#main_content").val(), Order2: $("#" + objOrderBy2, "#main_content").val(), Order3: $("#" + objOrderBy3, "#main_content").val(), Order4: $("#" + objOrderBy4, "#main_content").val() }, function (result) {
            if ($.trim(result) == '')
                jQuery.facebox("Some error occured on the server, please try again later.");
            else
                window.open("/uploads/temp/" + result);
        });

        return false;
    }
</script>
<link href="../../css/technical-module.css" rel="stylesheet" type="text/css" />
<style type="text/css">
.fixed-header th {
    font-size: 12px;
    text-align: center;
}
.grid_heading 
{
    background:#39589c;
    color: #fff;
    font-size: 18px;
    text-align:center;
    padding:5px;
}
</style>
<div class="grid_heading">
    Fabric Quality</div>
<br />
<div>
    <div id="search">
        <fieldset>
            <legend>Filters:</legend>
            <table>
                <tr>
                    <td>
                        Search:
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtSearch" MaxLength="40" CssClass="do-not-disable" Width="100px"></asp:TextBox>
                    </td>
                    <td>
                        Group:
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlGroup" runat="server" Width="100px">
                            <asp:ListItem Selected="True" Text="Select.." Value="-1"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:HiddenField runat="server" ID="hdnDDGroup" Value="-1" />
                    </td>
                    <td>
                        SubGroup:
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlSubGroup" runat="server" Width="100px">
                            <asp:ListItem Selected="True" Text="Select.." Value="-1"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:HiddenField runat="server" ID="hiddenSubGroupId" Value="-1" />
                    </td>
                    <td>
                        GSM:
                    </td>
                    <td>
                        From
                    </td>
                    <td>
                        <asp:TextBox ID="txtGsmFrom" runat="server" Width="50px"></asp:TextBox>
                    </td>
                    <td>
                        To
                    </td>
                    <td>
                        <asp:TextBox ID="txtGsmTo" runat="server" Width="50px"></asp:TextBox>
                    </td>
                    <td>
                        Width
                    </td>
                    <td>
                        From
                    </td>
                    <td>
                        <asp:TextBox ID="txtWidthFrom" runat="server" Width="50px"></asp:TextBox>
                    </td>
                    <td>
                        To
                    </td>
                    <td>
                        <asp:TextBox ID="txtWidthTo" runat="server" Width="50px"></asp:TextBox>
                    </td>
                    <td>
                        Price
                    </td>
                    <td>
                        From
                    </td>
                    <td>
                        <asp:TextBox ID="txtPriceFrom" runat="server" Width="50px"></asp:TextBox>
                    </td>
                    <td>
                        To
                    </td>
                    <td>
                        <asp:TextBox ID="txtPriceTo" runat="server" Width="50px"></asp:TextBox>
                    </td>
                    <td>
                        <nobr>Is Reg:</nobr>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlReg" runat="server" Width="100px">
                            <asp:ListItem Selected="True" Text="Select.." Value="-1"></asp:ListItem>
                            <asp:ListItem Selected="False" Text="Yes" Value="1"></asp:ListItem>
                            <asp:ListItem Selected="False" Text="No" Value="0"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:HiddenField runat="server" ID="hdnDDIsReg" Value="-1" />
                    </td>
                </tr>
            </table>
        </fieldset>
       
        <table>
        <tr>
            <td>
            <fieldset>
                        <legend>Sort By:</legend>
                        <table width="400px" cellspacing="5" style="font-size: 9px ! important;">
                            <tr>
                                <td>
                                    <asp:Label Visible="false" ID="lblSortedBy" runat="server" CssClass="do-not-disable"
                                        Text="Sorted By"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlOrder1" runat="server" font-size="9px" width="100px">
                                        <asp:ListItem Text="Select...." Value="-1"></asp:ListItem>
                                        <asp:ListItem Selected="True" Value="1">Trade Name</asp:ListItem>
                                        <asp:ListItem Value="2">Origin</asp:ListItem>
                                        <asp:ListItem Value="3">Width</asp:ListItem>
                                        <asp:ListItem Value="4">GSM</asp:ListItem>                                        
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:DropDownList runat="server" ID="ddlOrder2" CssClass="do-not-disable"  font-size="9px" width="100px">
                                        <asp:ListItem Text="Select...." Value="-1"></asp:ListItem>
                                        <asp:ListItem Value="1">Trade Name</asp:ListItem>
                                        <asp:ListItem Selected="True" Value="2">Origin</asp:ListItem>
                                        <asp:ListItem Value="3">Width</asp:ListItem>
                                        <asp:ListItem Value="4">GSM</asp:ListItem>   
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:DropDownList runat="server" ID="ddlOrder3" CssClass="do-not-disable"  font-size="9px" width="100px">
                                        <asp:ListItem Text="Select...." Value="-1"></asp:ListItem>
                                        <asp:ListItem Value="1">Trade Name</asp:ListItem>
                                        <asp:ListItem Value="2">Origin</asp:ListItem>
                                        <asp:ListItem Selected="True" Value="3">Width</asp:ListItem>
                                        <asp:ListItem Value="4">GSM</asp:ListItem>   
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:DropDownList runat="server" ID="ddlOrder4" CssClass="do-not-disable"  font-size="9px" width="100px">
                                        <asp:ListItem Text="Select...." Value="-1"></asp:ListItem>
                                        <asp:ListItem Value="1">Trade Name</asp:ListItem>
                                        <asp:ListItem Value="2">Origin</asp:ListItem>
                                        <asp:ListItem Value="3">Width</asp:ListItem>
                                        <asp:ListItem Selected="True" Value="4">GSM</asp:ListItem>   
                                    </asp:DropDownList>
                                </td>
                            </tr>
                        </table>                         
                    </fieldset>            
            </td>
        <td>
            <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text="Search" CssClass="do-not-disable go" />   
        </td>
        </tr>
        </table>
                    
                                    
                      
    </div>
</div>
<br />
<div class="print-box">
    <asp:GridView ID="grdFabricQuality" runat="server" AutoGenerateColumns="false" CssClass="item_list fixed-header"
        OnRowDataBound="grdFabricQuality_RowDataBound" Width="100%">
        <Columns>
            <asp:TemplateField HeaderText="Identification">
                <ItemTemplate>
                    <%# Eval("Identification")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="CategoryName" HeaderText="Group Name" SortExpression="CategoryName" />
            <asp:BoundField DataField="SubCategoryName" HeaderText="SubGroup Name" SortExpression="SubCategoryName" />
            <asp:BoundField DataField="FabricQualityID" HeaderText="Fabric Quality ID" SortExpression="FabricQualityID"
                Visible="false" />
            <asp:BoundField DataField="TradeName" HeaderText="Trade Name" SortExpression="TradeName" />
            <%--<asp:BoundField DataField="SupplierReference" HeaderText="Supplier Reference" SortExpression="SupplierReference" />--%>
            <asp:BoundField DataField="SupplierName" HeaderText="Supplier" SortExpression="SupplierReference" />
            <%--<asp:TemplateField HeaderText="Buyer Name" SortExpression="Buyer Name">
                <ItemTemplate>
                    <asp:Label ID="lblBuyerName" runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>--%>
            <%--<asp:BoundField DataField="FabricDesign" HeaderText="Fabric Design" SortExpression="DesignFullNo" ItemStyle-CssClass="numeric_text" />--%>
            
            <%--<asp:BoundField DataField="Origin" HeaderText="Origin" SortExpression="Origin"/>--%>
            <asp:BoundField DataField="Composition" HeaderText="Composition" SortExpression="Composition" />
            <asp:BoundField DataField="CountConstruction" HeaderText="Count Construction" SortExpression="CountConstruction" />
            <asp:BoundField DataField="GSM" HeaderText="GSM" SortExpression="GSM" ItemStyle-CssClass="numeric_text" />
            <%--<asp:BoundField DataField="Fabric" HeaderText="Fabric" SortExpression="Fabric" />--%>
            <asp:TemplateField HeaderText="Image">
                <ItemTemplate>
                    <a title="CLICK TO VIEW ENLARGED IMAGE" href="javascript:void(0)" onclick='showFabricAccessoryPhoto(<%# (Eval("FabricQualityID")).ToString()+","+1 %>)'>
                        <asp:Image runat="server" ID="imgFabricQuality" CssClass="lightbox" Width="60px"
                            Height="60px" />
                    </a>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Width" HeaderText="Width" SortExpression="Width" ItemStyle-CssClass="numeric_text" />
            <asp:TemplateField HeaderText="Wastage" SortExpression="Wastage">
                <ItemTemplate>
                    <asp:Label ID="lblWst" Text='<%# Eval("Wastage").ToString() + "%"  %>' runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <%--<asp:BoundField DataField="Remarks" HeaderText="Remarks" SortExpression="Remarks" ItemStyle-CssClass="remarks_text remarks_text2" HeaderStyle-Width="200px" ItemStyle-Width="200px"/>--%>
            <%--<asp:BoundField DataField="ClientName" HeaderText="Buyer" SortExpression="ClientName"/>--%>
            <asp:TemplateField HeaderText="Origin" SortExpression="Origin">
                <ItemTemplate>
                    <asp:Label ID="lblOrigin" runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <div visible='<%# (Eval("Origin") == null || Convert.ToInt32( Eval("Origin")) == 1 || Convert.ToInt32( Eval("Origin")) == -1) ? false: true %>'>
                        <table border="0" id="tblPriceList" runat="server">
                            <tr>
                                <td>
                                </td>
                                <td>
                                    By Sea
                                </td>
                                <td>
                                    By Air
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Price For Dyed
                                </td>
                                <td class="numeric_text">
                                    <asp:Label ID="lblPriceForDyedBySea" runat="server" Text='<%# Eval("PriceForDyedBySea") %>'></asp:Label>
                                </td>
                                <td class="numeric_text">
                                    <asp:Label ID="lblPriceForDyedByAir" runat="server" Text='<%# Eval("PriceForDyedByAir") %>'></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Price For Printed
                                </td>
                                <td class="numeric_text">
                                    <asp:Label ID="lblPriceForPrintedBySea" runat="server" Text='<%# Eval("PriceForPrintedBySea") %>'></asp:Label>
                                </td>
                                <td class="numeric_text">
                                    <asp:Label ID="lblPriceForPrintedByAir" runat="server" Text='<%# Eval("PriceForPrintedByAir") %>'></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div visible='<%# (Eval("Origin") == null || Convert.ToInt32( Eval("Origin")) == 2 || Convert.ToInt32( Eval("Origin")) == -1 ) ? false: true %>'>
                        <table border="0" id="Table1" runat="server">
                            <tr>
                                <td>
                                    Price For Dyed
                                </td>
                                <td class="numeric_text">
                                    <asp:Label ID="Label10" runat="server" Text='<%# Eval("PriceDyedIndian") %>'></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Price For Printed
                                </td>
                                <td class="numeric_text">
                                    <asp:Label ID="Label12" runat="server" Text='<%# Eval("PricePrintedIndian") %>'></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </div>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Is Reg.">
                <ItemTemplate>
                    <%# (Convert.ToBoolean((Eval("IsBiplRegistered"))) == false) ? "NO" : "YES"%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:HyperLinkField DataNavigateUrlFields="FabricQualityID" DataNavigateUrlFormatString="~/internal/Fabric/FabricQualityEdit.aspx?fabricqualityid={0}"
                Text="Edit" HeaderText="edit"></asp:HyperLinkField>
            <asp:TemplateField HeaderText="Delete">
                <ItemTemplate>
                    <asp:LinkButton runat="server" ID="lnkDelete" CommandName="Delete" CommandArgument='<%#Eval("FabricQualityID") %>'
                        OnClick="lnkDelete_Click" OnClientClick="return confirm('Are you sure, you want to delete this fabric quality?')"
                        Text="Delete"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <EmptyDataTemplate>
            <label>
                No records Found</label></EmptyDataTemplate>
        <FooterStyle HorizontalAlign="Right" />
    </asp:GridView>
    <div style="margin-top: 5px; text-align: right;">
        <cc1:HyperLinkPager ID="HyperLinkPager1" runat="server" PageSize="10">
        </cc1:HyperLinkPager>
    </div>
    <asp:ObjectDataSource ID="osdFabricQualityList" runat="server" SelectMethod="GetSelectedRecords"
        TypeName="iKandi.BLL.FabricQualityController.cs"></asp:ObjectDataSource>
</div>
<input type="button" id="btnPrint" class="print do-not-disable da_submit_button" value="Print" onclick="return PrintFabricQuality();" />
<asp:Button ID="Button1" runat="server" CssClass="add" PostBackUrl="~/Internal/Fabric/FabricQualityEdit.aspx" />
<%-- <input type="button" id="btnPrint" class="print"  onclick="return PrintPDF();" />--%>
<%--  <asp:TextBox id="txtsearch" runat="server"></asp:TextBox>
   <asp:TextBox runat="server" id="txtfrom" class="date-picker"></asp:TextBox>
    <asp:TextBox runat="server" id="txtTo" class="date-picker"></asp:TextBox>
<%--<asp:TextBox ID="txtDate" runat="server" CssClass="date-picker"></asp:TextBox>--%>
<%--<asp:DropDownList ID="ddlClients" runat="server">
                        </asp:DropDownList>
<asp:Button ID="btnTest" runat="server" Text="PDF Test" OnClick="btnTest_Click" />--%>