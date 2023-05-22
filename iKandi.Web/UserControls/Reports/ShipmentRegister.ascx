<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ShipmentRegister.ascx.cs"
    Inherits="iKandi.Web.ShipmentRegister" %>

<script type="text/javascript">

var hdnPagesizeClientID = '<%=hdnPagesize.ClientID %>';
var hdnPageIndexClientID = '<%=hdnPageIndex.ClientID %>';
$(function() 
{ 

$("#hdnpageindex").val($("#"+hdnPageIndexClientID).val());
$("#hdnpagesize").val($("#"+hdnPagesizeClientID).val());

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
    
 
  function hideLinks(srcElem)
  {
   var objRow = $(srcElem).parents("tr");
  $("#links").hide();
  }
 
  function showFabricPopup(StyleID,OrderDetailID,OrderID,ClientID,Fabric1,Fabric2,Fabric3,Fabric4,Fabric1Details,Fabric2Details,Fabric3Details,Fabric4Details)
  { 
     proxy.invoke("ShowManageOrderFabricDatesPopup", {StyleID:StyleID,OrderDetailID:OrderDetailID,OrderID:OrderID,ClientID:ClientID,Fabric1:Fabric1,Fabric2:Fabric2,Fabric3:Fabric3,Fabric4:Fabric4,Fabric1Details:Fabric1Details,Fabric2Details:Fabric2Details,Fabric3Details:Fabric3Details,Fabric4Details:Fabric4Details}, function(result)
     {
        jQuery.facebox(result); 
     },  onPageError, false, false);
  }
  
  function showSizePopup(OrderDetailID)
  { 
     proxy.invoke("GetSizesPopup", {OrderDetailID:OrderDetailID}, function(result)
     {
        jQuery.facebox(result);
     
     },  onPageError, false, false);
  }
  
  function GetManageOrderiKandiQuantityByDept(DepartmentID)
  {
   proxy.invoke("GetManageOrderiKandiQuantityByDept", {DepartmentID:DepartmentID}, function(result)
     {
        jQuery.facebox(result); 
     },  onPageError, false, false);
  }
  
//  function ShowFitsPopup(StyleID,DepartmentID,OrderDetailID)
//  {
//   proxy.invoke("ManageOrderFitsInfoPopup", {StyleID:StyleID,DepartmentID:DepartmentID,OrderDetailID:OrderDetailID}, function(result)
//     {
//        jQuery.facebox(result); 
//     },  onPageError, false, false);
//  }
    function GetManageOrderiKandiQuantityByMode(Mode)
  { 
     proxy.invoke("GetManageOrderiKandiQuantityByMode", {Mode:Mode}, function(result)
     {
        jQuery.facebox(result); 
     },  onPageError, false, false);
  }
  
  function showStatusMeeting(OrderDetailID)
  {
     proxy.invoke("showStatusMeeting", {OrderDetailID:OrderDetailID}, function(result)
     {
        jQuery.facebox(result); 
     },  onPageError, false, false);
  }
   
  function launchBiplInvoice(invoiceid)
  {
     window.open('/Internal/Delivery/BIPLInvoice.aspx?type=2&packingId=-1&invoiceid='+invoiceid,"Invoice",'height=900,width=1000,status=yes,resizable=no,menubar=no, scrollbars=yes,toolbar=no,location=no,directories=no,center:yes');
     
  }
  
  
  
 
  
</script>

<div class="form_box">
    <div class="form_heading">
        Shipment Register
    </div>
    <div>
        <table width="500px" cellspacing="5">
            <tr>
                <td>
                    Start&nbsp;Date:
                </td>
                <td>
                    <asp:TextBox ID="tbStart" runat="server" CssClass="date-picker date_style" />
                </td>
                <td>
                    End&nbsp;Date:
                </td>
                <td>
                    <asp:TextBox ID="tbEnd" runat="server" CssClass="date-picker date_style" />
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
        AllowPaging="True" PageSize="10" DataSourceID="odsShipmentRegister">
        <Columns>
            <asp:TemplateField HeaderText="Invoice No." HeaderStyle-Width="140px" ItemStyle-Width="140px">
                <ItemTemplate>
                  <nobr>  <span style="width: 140px ! important"><a style="width : 140px ! important;" class='<%# (Eval("InvoiceId") != DBNull.Value)? "":"hide_me" %>'
                        onclick="launchBiplInvoice('<%#Eval("InvoiceId")%>')">
                        <%# Eval("InvoiceNumber") != DBNull.Value ? (Eval("InvoiceNumber").ToString().Trim() == "" ? "View" : Eval("InvoiceNumber").ToString()) : (Eval("InvoiceId") != DBNull.Value ? "View" : "")%>
                    </a></span>
                    </nobr>
                </ItemTemplate>
                <ItemStyle CssClass="quantity_style"></ItemStyle>
            </asp:TemplateField>
             <asp:TemplateField HeaderText="Shipment No." HeaderStyle-Width="120px" ItemStyle-Width="120px">
                <ItemTemplate>
                    <asp:Label runat="server" Width="120px" ID="lblShipmentNo" Text='<%# Eval("ShipmentNo") != DBNull.Value ?  Eval("ShipmentNo") : "" %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Buyer" HeaderStyle-CssClass="vertical_header" ItemStyle-CssClass="vertical_text">
                <ItemTemplate>
                    <asp:Label runat="server" ID="lblBuyer" Text='<%# Eval("Buyer") != DBNull.Value ?  Eval("Buyer") : "" %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Order No." HeaderStyle-CssClass="vertical_header"
                ItemStyle-CssClass="vertical_text quantity_style">
                <ItemTemplate>
                    <asp:HiddenField ID="hdnSerial" runat="server" />
                    <a id="hypSerial" runat="server" class="hide_me"></a><span class="quantity_style">
                        <%# Eval("OrderNumber") != DBNull.Value ?  Eval("OrderNumber") : "" %>
                    </span>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Style No." HeaderStyle-Width="70px" ItemStyle-Width="70px">
                <ItemTemplate>
                    <span style="width: 70px ! important;">
                        <nobr>
                    <%# Eval("StyleNumber") != DBNull.Value ? Eval("StyleNumber") : "" %>
                    </nobr>
                    </span>
                    <br />
                    <a title="CLICK TO VIEW ENLARGED IMAGE" href="javascript:void(0)" class='<%# (Eval("SampleImageURL1") != DBNull.Value)? "":"hide_me" %>'
                        onclick='showStylePhotoWithOutScroll(<%# Eval("StyleID").ToString()+",-1,"+Eval("OrderDetailID").ToString() %>)'>
                        <img style="height: 75px ! important" title="CLICK TO VIEW ENLARGED IMAGE" border="0px"
                            src='<%# ResolveUrl("~/uploads/style/thumb-" + Eval("SampleImageURL1").ToString()) %>' /></a>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="LineItemNumber" HeaderText="Line No" SortExpression="LineItemNumber"
                HeaderStyle-CssClass="vertical_header" ItemStyle-CssClass="vertical_text" HeaderStyle-Width="28px"
                ItemStyle-Width="28px"></asp:BoundField>
            <asp:BoundField DataField="ContractNumber" HeaderText="Contract No" SortExpression="ContractNumber"
                HeaderStyle-CssClass="vertical_header" ItemStyle-CssClass="vertical_text" HeaderStyle-Width="28px"
                ItemStyle-Width="28px"></asp:BoundField>
            <asp:TemplateField HeaderText="Total QTY" ItemStyle-CssClass="numeric_text quantity_style"
                HeaderStyle-Width="80px" ItemStyle-Width="80px">
                <ItemTemplate>
                    <asp:Label ID="lblQuantity" runat="server" Width="80px" Text='<%# (Eval("Quantity") == DBNull.Value || Eval("Quantity") == "") ? "0" : Convert.ToInt32(Eval("Quantity")).ToString("N0")  %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="FOB Price(FC)" HeaderStyle-CssClass="vertical_header"
                ItemStyle-CssClass="numeric_text vertical_text" HeaderStyle-Width="28px" ItemStyle-Width="28px">
                <ItemTemplate>
                    <span>&pound;
                        <%# (Eval("Amount") != DBNull.Value || Eval("Amount") != "") ? Convert.ToDouble(Eval("Amount")).ToString("N2") : ""%>
                    </span>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Packages" SortExpression="Packages" ItemStyle-CssClass="date_style bold_text"
                HeaderStyle-Width="120px" ItemStyle-Width="120px">
                <ItemTemplate>
                    <asp:Label ID="lblTotalPkg" runat="server" Width="120px" Text='<%# Eval("TotalPackages") != DBNull.Value ? Eval("TotalPackages") : "" %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Mode" HeaderStyle-CssClass="vertical_header" ItemStyle-CssClass="vertical_text">
                <ItemTemplate>
                    <asp:Label runat="server" ID="lblMode" Text='<%# Eval("ModeName") != DBNull.Value ? Eval("ModeName") : "" %>'></asp:Label>
                    <asp:HiddenField ID="hdnMode" runat="server" Value='<%# Eval("Mode") != DBNull.Value ? Eval("Mode") : "0" %>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Ex Factory" SortExpression="ExFactory" ItemStyle-CssClass="date_style bold_text"
                HeaderStyle-Width="140px" ItemStyle-Width="140px">
                <ItemTemplate>
                    <asp:Label ID="lblExFactory" runat="server" Width="140px" Text='<%# ( Eval("Exfactory")== DBNull.Value || Convert.ToDateTime(Eval("ExFactory")) == DateTime.MinValue) ? "" : Convert.ToDateTime(Eval("ExFactory")).ToString("dd MMM yy (ddd)")%>'></asp:Label>
                    <asp:HiddenField runat="server" ID="hdnEx" Value='<%#(Eval("Exfactory") == DBNull.Value ) ?  "" : (Convert.ToDateTime(Eval("ExFactory"))).ToString("dd MMM yy (ddd)")%>' />
                    <asp:HiddenField runat="server" ID="hdnDC" Value='<%# (Eval("DC") == DBNull .Value ) ?  "" : (Convert.ToDateTime(Eval("DC"))).ToString("dd MMM yy (ddd)")%>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Shipment Date" HeaderStyle-Width="120px" ItemStyle-Width="120px">
                <ItemTemplate>
                      <asp:Label ID="lblShipmentDate" runat="server" Width="120px" Text='<%# ( Eval("ShipmentDate")== DBNull.Value || Convert.ToDateTime(Eval("ShipmentDate")) == DateTime.MinValue) ? "" : Convert.ToDateTime(Eval("ShipmentDate")).ToString("dd MMM yy (ddd)")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Agent Name" SortExpression="Agent Name" HeaderStyle-Width="120px"
                ItemStyle-Width="120px">
                <ItemTemplate>
                    <asp:Label ID="lblAgentName" runat="server" Width="120px" Text='<%# Eval("PartnerName") != DBNull.Value ? Eval("PartnerName") : ""  %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="AWB/B.L.No." SortExpression="AWB/B.L.No." HeaderStyle-Width="120px"
                ItemStyle-Width="120px">
                <ItemTemplate>
                    <asp:Label ID="lblBLAWBNo" runat="server" Width="120px" Text='<%# Eval("BLAWBNo") != DBNull.Value ? Eval("BLAWBNo") : "" %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="AWB Date" SortExpression="LandingETA" ItemStyle-CssClass="date_style bold_text"
                HeaderStyle-Width="140px" ItemStyle-Width="140px">
                <ItemTemplate>
                    <asp:Label ID="lblAWBDate" runat="server" Width="140px" Text='<%# (Eval("LandingETA") == DBNull.Value || Convert.ToDateTime(Eval("LandingETA")) == DateTime.MinValue) ? "" : Convert.ToDateTime(Eval("LandingETA")).ToString("dd MMM yy (ddd)")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Flight No." SortExpression="Flight No." HeaderStyle-Width="120px"
                ItemStyle-Width="120px">
                <ItemTemplate>
                    <asp:Label ID="lblFlightNumber" runat="server" Width="120px" Text='<%# Eval("FlightNumber") != DBNull.Value ? Eval("FlightNumber") : ""  %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Unit" HeaderStyle-CssClass="vertical_header" ItemStyle-CssClass="vertical_text quantity_style">
                <ItemTemplate>
                    <span><a id="hypUnit" runat="server" class="hide_me"></a>
                        <asp:Label ID="lblUnit" runat="server" ToolTip='<%# Eval("FactoryName") != DBNull.Value ? Eval("FactoryName") : "" %>' Text='<%# Eval("FactoryCode") != DBNull.Value ? Eval("FactoryCode") : "" %>'></asp:Label>
                    </span>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <EmptyDataTemplate>
            <label>
                No records Found</label></EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource ID="odsShipmentRegister" runat="server" SelectMethod="GetShipmentRegisterReport"
        TypeName="iKandi.BLL.ReportController" StartRowIndexParameterName="startIndex"
        EnablePaging="True" MaximumRowsParameterName="pageSize" SelectCountMethod="GetShipmentRegisterReportCount"
        OldValuesParameterFormatString="original_{0}">
        <SelectParameters>
            <asp:Parameter Name="startIndex" Type="Int32" />
            <asp:Parameter Name="pageSize" Type="Int32" />
            <asp:SessionParameter Name="start" SessionField="StartDate" Type="DateTime" />
            <asp:SessionParameter Name="end" SessionField="EndDate" Type="DateTime" />
            <asp:ControlParameter ControlID="ddlClients" DefaultValue="-1" Name="clientId" PropertyName="SelectedValue"
                Type="Int32" />
            <asp:ControlParameter ControlID="ddlModes" DefaultValue="3" Name="supplyType" PropertyName="SelectedValue"
                Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
</div>
