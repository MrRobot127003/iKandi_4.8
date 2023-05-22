<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CriticalPathReports.ascx.cs"
    Inherits="iKandi.Web.CriticalPathReports" %>

<script type="text/javascript">

    var serviceUrl = '<%= ResolveUrl("~/Webservices/iKandiService.asmx/") %>';
    var proxy = new ServiceProxy(serviceUrl);
    var BuyerDDClientID = '<%=ddlClients.ClientID%>';
    var DeptDDClientID = '<%=ddlDepartment.ClientID%>';
    var jscriptPageVariables = null;
    var selectedDept;
    var hdnDeptIdClientID = '<%=hiddenDeptId.ClientID %>';

    $(function() {
        $("#" + BuyerDDClientID, '#main_content').change(function() {
            var clientId = $(this).val();
            populateDepartments($(this).val());
        });

        $("#" + DeptDDClientID, '#main_content').change(function() {
            selectedDept = $("#" + DeptDDClientID).find("option:selected").text();
            setDeptName();
        });

        populateDepartments($("#" + BuyerDDClientID, '#main_content').val());
    });

    function populateDepartments(clientId) {
        bindDropdown(serviceUrl, DeptDDClientID, 'GetClientDeptsByClientID', { ClientID: clientId }, 'Name', 'DeptID', false, '', onPageError)
    }


    function populateDepartments(clientId, selectedDeptID) {
        bindDropdown(serviceUrl, DeptDDClientID, "GetClientDeptsByClientID", { ClientID: clientId }, "Name", "DeptID", true, (jscriptPageVariables != null) ? jscriptPageVariables.selectedDeptID : selectedDeptID, onPageError, setDeptName)
        if (jscriptPageVariables != null && jscriptPageVariables.selectedDeptID != null && jscriptPageVariables.selectedDeptID != '')
            jscriptPageVariables.selectedDeptID = '';
    }

    function setDeptName() {
        selectedDept = $("#" + DeptDDClientID, "#main_content").val();
        $("#" + hdnDeptIdClientID, "#main_content").val(selectedDept);
        $("#" + DeptDDClientID, "#main_content").children(":first").text("ALL");
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

    function GetManageOrderiKandiQuantityByMode(Mode) {
        proxy.invoke("GetManageOrderiKandiQuantityByMode", { Mode: Mode }, function(result) {
            jQuery.facebox(result);
        }, onPageError, false, false);
    }

    function ShowFitsPopup(StyleNumber, DepartmentID, OrderDetailID) {
        proxy.invoke("ManageOrderFitsInfoPopup", { StyleNumber: StyleNumber, DepartmentID: DepartmentID, OrderDetailID: OrderDetailID }, function(result) {
            jQuery.facebox(result);
        }, onPageError, false, false);
    }

    function PrintCriticalPathPDF() {
        objSearch = '<%=txtsearch.ClientID%>';
        objClientId = '<%=hdnClientId.ClientID%>';
        objDeptId = '<%=hdnDeptId.ClientID%>';
        objSupplyType = '<%=hdnSupplyType.ClientID%>';
        objModeType = '<%=hdnModeType.ClientID%>';
        objPackingType = '<%=hdnPackingType.ClientID%>';
        objTermType = '<%=hdnTermType.ClientID%>';
        var SearchText;
        var ClientId;
        var DeptId;
        var SupplyType;
        var ModeType;
        var PackingType;
        var TermType;

        SearchText = $("#" + objSearch).val();
        ClientId = $("#" + objClientId).val();
        DeptId = $("#" + objDeptId).val();
        SupplyType = $("#" + objSupplyType).val();
        ModeType = $("#" + objModeType).val();
        PackingType = $("#" + objPackingType).val();
        TermType = $("#" + objTermType).val();

        proxy.invoke("GenerateCriticalPathReport", { SearchText: SearchText, ClientId: ClientId, DeptId: DeptId, SupplyType: SupplyType, ModeType: ModeType, PackingType: PackingType, Terms: TermType }, function(result) {
            if ($.trim(result) == '')
                jQuery.facebox("Some error occured on the server, please try again later.");
            else
                window.open("/uploads/temp/" + result);
        });
        return false;
    }

 
 
</script>

<style>
    
    .incHght
    {
        height: 200px;
    }
    .incHght1
    {
        height: 200px;
    }
    .bulkappr
    {
        color: blue;
        font-size: 10px;
    }
    #btntoExcel
    {
        margin-left:150px;
     }
</style>
<div class="">
    <div style="border: solid 1px #000; width: 125%; vertical-align:top;">
        <div class="form_heading">
            Critical Path Report
        </div>
        <table width="105%">
            <tr >
                <td style="width: 82%" runat="server" id="tdFilter">
                    <fieldset title="Filters" style="margin-left: 5px; margin-right: 5px;">
                        <legend>Filters</legend>
                        <table border="0" align="left" cellpadding="3" cellspacing="6" style="margin-left: 0px;
                            margin-right: 5px;">
                            <tr style="vertical-align: top" valign="top">
                                <td>
                                <nobr>
                                    Search:
                                    <asp:TextBox ID="txtsearch" class="do-not-disable" MaxLength="40" runat="server" Text="" Width="200px" ></asp:TextBox>
                                    </nobr>
                                </td>
                              
                              <td id="tdBH"  runat="server">
                              <nobr>
                                    Buying House:<asp:DropDownList Width="80px" ID="ddlBH" runat="server" AutoPostBack="true"
                                        CssClass="do-not-disable" 
                                        onselectedindexchanged="ddlBH_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    </nobr>
                                </td>
                                    <td id="tdClients"  runat="server">
                                    <nobr>
                                    Client:<asp:DropDownList Width="80px" ID="ddlClients" runat="server"
                                        CssClass="do-not-disable">
                                    </asp:DropDownList>
                                    </nobr>
                                </td>
                                <td id="tdDepartment" runat="server">
                                <nobr>
                                    Department:<asp:DropDownList Width="80px" ID="ddlDepartment" runat="server"
                                        CssClass="do-not-disable">
                                    </asp:DropDownList>
                                    </nobr>
                                </td>
                                <td>
                                <nobr>
                                    Supply:<asp:DropDownList Width="80px" ID="ddlSupplyType" runat="server"
                                        CssClass="do-not-disable">
                                        <asp:ListItem Selected="True" Text="All" Value="-1"></asp:ListItem>
                                        <asp:ListItem Text="LANDED" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="DIRECT EX-FACTORY" Value="2"></asp:ListItem>
                                        <asp:ListItem Text="DIRECT EX-PORT" Value="3"></asp:ListItem>
                                    </asp:DropDownList>
                                    </nobr>
                                </td>
                                <td>
                                <nobr>
                                    Mode:
                                    <asp:DropDownList Width="80px" ID="ddlModeType" runat="server" CssClass="do-not-disable">
                                        <asp:ListItem Text="All" Value="-1"></asp:ListItem>
                                        <asp:ListItem Text="SEA" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="AIR" Value="2"></asp:ListItem>
                                    </asp:DropDownList>
                                    </nobr>
                                </td>
                                <td>
                                <nobr>
                                    Packing:
                                    <asp:DropDownList Width="80px" ID="ddlPackingType" runat="server" CssClass="do-not-disable">
                                        <asp:ListItem Selected="True" Text="All" Value="-1"></asp:ListItem>
                                        <asp:ListItem Text="HANGING" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="FLAT" Value="2"></asp:ListItem>
                                    </asp:DropDownList>
                                    </nobr>
                                </td>
                                <td>
                                <nobr>
                                    Term:
                                    <asp:DropDownList Width="80px" ID="ddlTermType" runat="server" CssClass="do-not-disable">
                                        <asp:ListItem Selected="True" Text="All" Value="-1"></asp:ListItem>
                                        <asp:ListItem Text="FOB" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="CIF" Value="2"></asp:ListItem>
                                    </asp:DropDownList>
                                    </nobr>
                                </td>                            
                            </tr>
                        </table>
                    </fieldset>
                </td>
                <td style="width: 18%">
                    <fieldset title="Sort By" style="margin-left: 5px; margin-right: 5px;">
                        <legend>Sort By</legend>
                        <table width="30%" border="0" align="left" cellpadding="3" cellspacing="6" style="margin-left: 5px;">
                            <tr>
                                <td>
                                    <asp:DropDownList Width="80px" ID="ddlSort1" runat="server" CssClass="do-not-disable">
                                        <asp:ListItem Selected="True" Text="DC Date" Value="DC"></asp:ListItem>
                                        <asp:ListItem Text="Order Date" Value="OrderDate1"></asp:ListItem>
                                        <asp:ListItem Text="Qty" Value="Quantity"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:DropDownList Width="80px" ID="ddlSort2" runat="server" CssClass="do-not-disable">
                                        <asp:ListItem Text="DC Date" Value="DC"></asp:ListItem>
                                        <asp:ListItem Selected="True" Text="Order Date" Value="OrderDate1"></asp:ListItem>
                                        <asp:ListItem Text="Qty" Value="Quantity"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:DropDownList Width="80px" ID="ddlSort3" runat="server" CssClass="do-not-disable">
                                        <asp:ListItem Text="DC Date" Value="DC"></asp:ListItem>
                                        <asp:ListItem Text="Order Date" Value="OrderDate1"></asp:ListItem>
                                        <asp:ListItem Selected="True" Text="Qty" Value="Quantity"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                        </table>
                    </fieldset>
                </td>
            </tr>
            <tr>
               <td>
                    <asp:Button ID="btnSearch" runat="server" class="btns" OnClick="btnSearch_Click go" Text="Search" />
                    <asp:Button ID="btnExport" runat="server" class="top_btns" OnClick="btnExport_Click" Text="Export" />
                    <asp:Button ID="btnExport0" runat="server" class="top_btns" 
                        OnClick="btnExport0_Click" Text="Export PDF" />
                        
                    <asp:RadioButton ID="rdoVertical" Checked="true" GroupName="ViewType"  Text ="Vertical View" 
                        runat="server" oncheckedchanged="rdoVertical_CheckedChanged"  AutoPostBack="true"/>
                    <asp:RadioButton ID="rdoHorizontal" Text ="Horizontal View"  GroupName="ViewType" runat="server" 
                        oncheckedchanged="rdoHorizontal_CheckedChanged" AutoPostBack="true" />
                </td>
            </tr>
        </table>
    </div>
    <br />
    <div id="DivCriticalPath" class="form_box2" runat="server">
        <asp:PlaceHolder ID="plcCriticalPath" runat="server"></asp:PlaceHolder>
    </div>
    <div id="dvPaging" runat="server" visible="false" style="text-align: center">
        <asp:LinkButton ID="lnkFirst" runat="server" Text="<<" OnClick="lnkFirst_Click"></asp:LinkButton>
        &nbsp;
        <asp:LinkButton ID="lnkPre" runat="server" Text="<" OnClick="lnkPre_Click"></asp:LinkButton>
        &nbsp;
        <asp:Label ID="lblPage" runat="server" Text="Page 1 To 100"></asp:Label>
        &nbsp;
        <asp:LinkButton ID="lnkNext" runat="server" Text=">" OnClick="lnkNext_Click"></asp:LinkButton>
        &nbsp;
        <asp:LinkButton ID="lnkLast" runat="server" Text=">>" OnClick="lnkLast_Click"></asp:LinkButton>
        &nbsp;
        <asp:HiddenField ID="hdnPage" Value="1" runat="server" />
    </div>
</div>
<div id="links" class="hide_me">
    <a href="/Internal/Sales/Order.aspx" target="OrderForm" title="CLICK TO VIEW ORDER FORM"
        class="hyp">Order Formclass="hyp">Order Form</a><br />
    <a href="/Internal/Sales/OrderLimitations.aspx" target="OrderLimitationsForm" title="CLICK TO VIEW ORDER LIMITATION FORM"
        class="hyp">Order Limitations Form</a><br />
    <a href="/Internal/Fabric/FabricWorkingSheet.aspx" target="FabricWorkingSheetForm"
        title="CLICK TO VIEW FABRIC WORKING SHEET FORM" class="hyp">Fabric Working Sheet</a><br />
    <a href="/Internal/Fabric/FabricAccessoriesWorkSheet.aspx" target="FabricAccessoriesWorkSheetForm"
        title="CLICK TO VIEW FABRIC ACCESSARIES WORKING SHEET FORM" class="hyp">Fabric Accessories
        Working Sheet</a><br />
    <a href="/Internal/Fabric/CuttingSheet.aspx" target="CuttingSheetForm" title="CLICK TO VIEW CUTTING SHEET FORM"
        class="hyp">Cutting Sheet</a>
</div>
<div style="width: 143px">
    <table width='<%= (hdnIsClient.Value == "1" )? "300px" : "1200px" %>' cellspacing="3"
        class="" style="display: none;">
        <tr>
            <td>
                <asp:HiddenField ID="hdnIsClient" runat="server" Value="0" />
                <asp:HiddenField ID="hdnClientId" runat="server" Value="0" />
                <asp:HiddenField ID="hdnDeptId" runat="server" Value="0" />
            </td>
            <td class='<%= (hdnIsClient.Value == "1" )? "hide_me" : "" %>'>
            </td>
            <td class='<%= (hdnIsClient.Value == "1" )? "hide_me" : "" %>'>
            </td>
            <td class='<%= (hdnIsClient.Value == "1" )? "hide_me" : "" %>'>
            </td>
            <td class='<%= (hdnIsClient.Value == "1" )? "hide_me" : "" %>'>
                <asp:HiddenField runat="server" ID="hiddenDeptId" Value="-1" />
            </td>
            <td class='<%= (hdnIsClient.Value == "1" )? "hide_me" : "" %>'>
            </td>
            <td class='<%= (hdnIsClient.Value == "1" )? "hide_me" : "" %>'>
                <asp:HiddenField runat="server" ID="hdnSupplyType" Value="-1" />
            </td>
            <td class='<%= (hdnIsClient.Value == "1" )? "hide_me" : "" %>'>
            </td>
            <td class='<%= (hdnIsClient.Value == "1" )? "hide_me" : "" %>'>
                <asp:HiddenField runat="server" ID="hdnModeType" Value="-1" />
            </td>
            <td class='<%= (hdnIsClient.Value == "1" )? "hide_me" : "" %>'>
            </td>
            <td class='<%= (hdnIsClient.Value == "1" )? "hide_me" : "" %>'>
                <asp:HiddenField runat="server" ID="hdnPackingType" Value="-1" />
            </td>
            <td class='<%= (hdnIsClient.Value == "1" )? "hide_me" : "" %>'>
            </td>
            <td class='<%= (hdnIsClient.Value == "1" )? "hide_me" : "" %>'>
                <asp:HiddenField runat="server" ID="hdnTermType" Value="-1" />
            </td>
            <td class='<%= (hdnIsClient.Value == "1" )? "hide_me" : "" %>'>
            </td>
            <td class='<%= (hdnIsClient.Value == "1" )? "hide_me" : "" %>'>
                <asp:HiddenField runat="server" ID="HiddenField1" Value="-1" />
            </td>
            <td class='<%= (hdnIsClient.Value == "1" )? "hide_me" : "" %>'>
                <asp:HiddenField runat="server" ID="HiddenField2" Value="-1" />
            </td>
            <td class='<%= (hdnIsClient.Value == "1" )? "hide_me" : "" %>'>
                <asp:HiddenField runat="server" ID="HiddenField3" Value="-1" />
            </td>
        </tr>
    </table>
</div>
<input type="button" id="btnPrint" class="print" style="visibility:hidden;margin-left:150px;" onclick="return PrintCriticalPathPDF();" />
