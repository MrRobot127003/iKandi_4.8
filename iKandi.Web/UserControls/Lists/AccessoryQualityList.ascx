<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AccessoryQualityList.ascx.cs"
    Inherits="iKandi.Web.UserControls.Lists.AccessoryQualityList" %>
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
    $(function() {
        //BindControls();
        $("a[rel=lightbox]").lightBox({

            imageLoading: '/app_themes/ikandi/images/lightbox-ico-loading.gif',

            imageBtnPrev: '/app_themes/ikandi/images/lightbox-btn-prev.gif',

            imageBtnNext: '/app_themes/ikandi/images/lightbox-btn-next.gif',

            imageBtnClose: '/app_themes/ikandi/images/lightbox-btn-close.gif',

            imageBlank: '/app_themes/ikandi/images/lightbox-blank.gif'

        });

        $("#" + GroupDDClientID, '#main_content').change(function() {
            var groupId = $(this).val();
            populateSubGroups($(this).val());
        });
        $("#" + objddlGroup, '#main_content').change(function () {
            setDDlGroupByValue();
        });
        $("#" + objddlSubGroup, '#main_content').change(function () {
            setDDLSubGroupbyValue();
        });
        $("#" + objddlReg, '#main_content').change(function () {
            SetobjddlRegByValue();
        });

        $("#" + SubGroupDDClientID, '#main_content').change(function() {
            $("#" + hdnSubGroupClientID, "#main_content").val($(this).val());
            selectedSubGroup = $("#" + SubGroupDDClientID).find("option:selected").text();
            setSubGroup();
        });
        populateSubGroups($("#" + GroupDDClientID, '#main_content').val());

    });

    function PrintFabricQuality() {
        
        setDDlGroupByValue();
        setDDLSubGroupbyValue();
        SetobjddlRegByValue();
      
        var PageSize = 999999999;
        var PageIndex = 0;

        var objSearchText = '<%=txtSearch.ClientID%>';
        var SearchText = $("#" + objSearchText).val();
        //alert("Search" + SearchText);

        // var objGroupId = '<%=hdnDDGroup.ClientID%>';
        var GroupId = selectedGroupValue;
        //alert("GroupId" + GroupId);

        //var objSubGroupID = '<%=hiddenSubGroupId.ClientID%>';
        var SubGroupId = selectedSubGroupValue;
        //alert("SubGroup" + SubGroupId);

        var objPriceFrom = '<%=txtPriceFrom.ClientID%>';
        var PriceFrom = $("#" + objPriceFrom).val();
        // alert("PriceFrom" + PriceFrom);

        var objPriceTo = '<%=txtPriceTo.ClientID%>';
        var PriceTo = $("#" + objPriceTo).val();
        //  alert("PriceTo" + PriceTo);

        //var objIsReg ='<%=hdnDDIsReg.ClientID%>';
        var IsReg = selectedddlRegByValue;
        //alert("IsReg" + IsReg);
       
        proxy.invoke("GenerateAccessoryQualityPDF", { PageSize: PageSize, PageIndex: PageIndex, SearchText: SearchText, GroupId: GroupId, SubGroupId: SubGroupId, PriceFrom: PriceFrom, PriceTo: PriceTo, IsReg: IsReg, Order1: $("#" + objOrderBy1, "#main_content").val(), Order2: $("#" + objOrderBy2, "#main_content").val(), Order3: $("#" + objOrderBy3, "#main_content").val() }, function (result) {
          
            if ($.trim(result) == '')
                jQuery.facebox("Some error occured on the server, please try again later.");
            else
                window.open("/uploads/temp/" + result);
        });

        return false;
    }
    function populateSubGroups(groupId, selectedSubGroupID) {
        if (groupId > 0)
            bindDropdown(serviceUrl, SubGroupDDClientID, "GetSubGroupByGroupID", { CategoryID: groupId }, "CategoryName", "CategoryID", true, (jscriptPageVariables != null) ? jscriptPageVariables.selectedSubGroupID : selectedSubGroupID, onPageError, setSubGroup);
        if (jscriptPageVariables != null && jscriptPageVariables.selectedSubGroupID != null && jscriptPageVariables.selectedSubGroupID != '')
            jscriptPageVariables.selectedSubGroupID = '';
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
    function setSubGroup() {
        selectedSubGroup = $("#" + SubGroupDDClientID, "#main_content").val();
        $("#" + SubGroupDDClientID, '#main_content').val($("#" + hdnSubGroupClientID, "#main_content").val());
    }
   
</script>
<link href="../../css/technical-module.css" rel="stylesheet" type="text/css" />
<style type="text/css">
.fixed-header th {
    font-size: 12px;
    text-align: center;
}
fieldset legend
{
    font-weight:bold;
    color:#39589c;
    font-family:Verdana;
}
.grid_heading {
    color: #fff;
    font-size: 16px;
    background-color: #39589c;
    color: #ffffff !important;
    text-align:center;
    padding:5px 0px;
}

</style>
<div class="grid_heading">
    Accessory Quality</div>
<br />
<div>
    <div id="search">
     <table>
        <tr>
        <td>
        <fieldset>
            <legend>Filters:</legend>
            <table  cellspacing="5" style="font-size: 9px ! important;">
                <tr>
                    <td>
                        Search:
                    </td>
                    <td>
                        <asp:TextBox runat="server" MaxLength="40" ID="txtSearch" CssClass="do-not-disable"></asp:TextBox>
                    </td>
                    <td>
                        Group:
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlGroup" runat="server">
                            <asp:ListItem Selected="True" Text="Select.." Value="-1"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:HiddenField runat="server" ID="hdnDDGroup" Value="-1" />
                    </td>
                    <td>
                        SubGroup:
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlSubGroup" runat="server">
                            <asp:ListItem Selected="True" Text="Select.." Value="-1"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:HiddenField runat="server" ID="hiddenSubGroupId" Value="-1" />
                    </td>                  
                    <td>
                        Price
                    </td>
                    <td>
                        From
                    </td>
                    <td>
                        <asp:TextBox ID="txtPriceFrom" runat="server" Width="40px"></asp:TextBox>
                    </td>
                    <td>
                        To
                    </td>
                    <td>
                        <asp:TextBox ID="txtPriceTo" runat="server" Width="40px"></asp:TextBox>
                    </td>
                    <td>
                        <nobr>Is Reg:</nobr>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlReg" runat="server">
                            <asp:ListItem Selected="True" Text="Select.." Value="-1"></asp:ListItem>
                            <asp:ListItem Selected="False" Text="Yes" Value="1"></asp:ListItem>
                            <asp:ListItem Selected="False" Text="No" Value="0"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:HiddenField runat="server" ID="hdnDDIsReg" Value="-1" />
                    </td>
                </tr>
            </table>
        </fieldset>      
       </td>
            <td>
            <fieldset>
                        <legend>Sort By:</legend>
                        <table width="300px" cellspacing="5" style="font-size: 9px ! important;">
                            <tr>
                                <td>
                                    <asp:Label Visible="false" ID="lblSortedBy" runat="server" CssClass="do-not-disable"
                                        Text="Sorted By"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlOrder1" runat="server" font-size="9px" width="90px">
                                        <asp:ListItem Text="Select...." Value="-1"></asp:ListItem>
                                        <asp:ListItem Selected="True" Value="1">Trade Name</asp:ListItem>
                                        <asp:ListItem Value="2">Origin</asp:ListItem>
                                        <asp:ListItem Value="3">Lead Time</asp:ListItem>                                                                        
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:DropDownList runat="server" ID="ddlOrder2" CssClass="do-not-disable"  font-size="9px" width="90px">
                                        <asp:ListItem Text="Select...." Value="-1"></asp:ListItem>
                                        <asp:ListItem Value="1">Trade Name</asp:ListItem>
                                        <asp:ListItem Selected="True" Value="2">Origin</asp:ListItem>
                                        <asp:ListItem Value="3">Lead Time</asp:ListItem>                                       
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:DropDownList runat="server" ID="ddlOrder3" CssClass="do-not-disable"  font-size="9px" width="90px">
                                        <asp:ListItem Text="Select...." Value="-1"></asp:ListItem>
                                        <asp:ListItem Value="1">Trade Name</asp:ListItem>
                                        <asp:ListItem Value="2">Origin</asp:ListItem>
                                        <asp:ListItem Selected="True" Value="3">Lead Time</asp:ListItem>
                                    </asp:DropDownList>
                                </td>                               
                            </tr>
                        </table>                        
                    </fieldset>           
            </td>
        <td>
           <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" CssClass="do-not-disable go" Text="Search" />
        </td>
        </tr>
        </table>             
    </div>
</div>
<br />
<div class="print-box">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" CssClass="item_list fixed-header"
        OnRowDataBound="GridView_RowDataBound">
        <Columns>
            <asp:BoundField DataField="AccessoryQualityID" HeaderText="Accessory Quality ID"
                SortExpression="AccessoryQualityID" Visible="false" />
            <asp:TemplateField HeaderText="Identification">
                <ItemTemplate>
                    <%# Eval("Identification")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="CategoryName" HeaderText="Group Name" SortExpression="CategoryName" />
            <asp:BoundField DataField="SubCategoryName" HeaderText="SubGroup Name" SortExpression="SubCategoryName" />
            <asp:BoundField DataField="TradeName" HeaderText="Trade Name" SortExpression="TradeName" /> 
             <asp:TemplateField HeaderText="Price" SortExpression="Price">
                <ItemTemplate>
                    <asp:Label ID="lblPrice" runat="server" Text='<%# Eval("Price") %>'></asp:Label>
                    </asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="SupplierName" HeaderText="Supplier Name" SortExpression="SupplierName" />
            <asp:BoundField DataField="SupplierReference" HeaderText="Supplier Reference" SortExpression="SupplierReference" />
            <asp:TemplateField HeaderText="Buyer Name" SortExpression="Buyer Name">
                <ItemTemplate>
                    <asp:Label ID="lblBuyerName" runat="server">
                    </asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <%--<asp:BoundField DataField="Category" HeaderText="Category" SortExpression="Category" />--%>
            <asp:BoundField DataField="Composition" HeaderText="Composition" SortExpression="Composition" />
            
            <%--<asp:TemplateField HeaderText="Accessory Reference">
<ItemTemplate>
         ACC<%# Eval("FullAccRef") %>
</ItemTemplate>
</asp:TemplateField>--%>
            <%--<asp:BoundField DataField="CompanyName" HeaderText="Buyer" SortExpression="CompanyName" />--%>
            
            
            
            <asp:TemplateField HeaderText="Origin" SortExpression="Origin" FooterStyle-HorizontalAlign="Right">
                <ItemTemplate>
                    <asp:Label ID="lblOriginName" runat="server">
                    </asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Image">
                <ItemTemplate>
                    <a title="CLICK TO VIEW ENLARGED IMAGE" href="javascript:void(0)" onclick='showFabricAccessoryPhoto(<%# (Eval("AccessoryQualityID")).ToString()+","+0 %>)'>
                        <asp:Image runat="server" ID="imgAccessoryQuality" CssClass="lightbox" Width="60px"
                            Height="60px" />
                    </a>
                    <%--<a title="CLICK TO VIEW ENLARGED IMAGE" href="javascript:void(0)" onclick='showFabricAccessoryPhoto(<%# (Eval("AccessoryQualityID")).ToString()+","+0 %>)'>
                        <img style="height: 60px ! important" title="CLICK TO VIEW ENLARGED IMAGE" border="0px"
                         src='<%# (((Eval("Pictures") as System.Collections.Generic.List<iKandi.Common.AccessoryQualityPicture>) == null) && (Eval("Pictures") as System.Collections.Generic.List<iKandi.Common.AccessoryQualityPicture>).Count > 0) ? "" : ( ((Eval("Pictures") as System.Collections.Generic.List<iKandi.Common.AccessoryQualityPicture>)[0].ImageFile.ToString() == "") ? "" : ResolveUrl("~/uploads/quality/thumb-" + (Eval("Pictures") as System.Collections.Generic.List<iKandi.Common.AccessoryQualityPicture>)[0].ImageFile.ToString())) %>'  /></a>--%>
                </ItemTemplate>
            </asp:TemplateField>
            <%--<asp:BoundField DataField="Remarks" HeaderText="Remarks" SortExpression="Remarks" ItemStyle-CssClass="remarks_text remarks_text2 " HeaderStyle-Width="200px" ItemStyle-Width="200px" />--%>
            <asp:BoundField DataField="LeadTime" HeaderText="Lead Time(In Days)" SortExpression="LeadTime"
                ItemStyle-CssClass="numeric_text" />
             <asp:TemplateField HeaderText="Is Reg.">
                <ItemTemplate>
                    <%# (Convert.ToBoolean((Eval("IsBiplRegistered"))) == false) ? "NO" : "YES"%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:HyperLinkField DataNavigateUrlFields="AccessoryQualityID" DataNavigateUrlFormatString="~/Internal/Fabric/AccessoryQualityEdit.aspx?accessoryqualityid={0}"
                 HeaderText="edit"  Text="<img src='../../images/edit2.png'/>">
              
              
                </asp:HyperLinkField>
            <asp:TemplateField HeaderText="Delete">
                <ItemTemplate>
                    <asp:LinkButton runat="server" ID="lnkDelete" CommandName="Delete" CommandArgument='<%#Eval("AccessoryQualityID") %>'
                        OnClick="lnkDelete_Click" OnClientClick="return confirm('Are you sure, you want to delete this accessory quality?')"
                        Text=""> <img src="../../images/delete-icon.png" /> </asp:LinkButton>
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
    <asp:ObjectDataSource ID="osdAccessoryQuality" runat="server" SelectMethod="GetAccessoryQuality"
        TypeName="iKandi.BLL.AccessoryQualityController"></asp:ObjectDataSource>
</div>
<input type="button" id="Button2" class="print do-not-disable da_submit_button" value="Print" onclick="return PrintFabricQuality();" />
<asp:Button ID="Button1" runat="server" CssClass="add" PostBackUrl="~/Internal/Fabric/AccessoryQualityEdit.aspx" />

