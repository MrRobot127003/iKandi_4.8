<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="OrderSummary.ascx.cs"
    Inherits="iKandi.Web.OrderSummary" %>
<%@ Register Assembly="iKandi.Web" Namespace="iKandi.Components.UI" TagPrefix="cc1" %>

<script type="text/javascript">

var serviceUrl = '<%= ResolveUrl("~/Webservices/iKandiService.asmx/") %>';
var proxy = new ServiceProxy(serviceUrl);
var jscriptPageVariables = null;
var selectedSort;
var selectedClient;
var SearchText = '<%= txtsearch.ClientID %>';
var BuyerDDClientID = '<%=ddlClient.ClientID%>' ;
var SortedByDD = '<%= ddlSortedBy.ClientID %>';
var SortedByDD2 = '<%= ddlOrder2.ClientID %>';
var SortedByDD3 = '<%= ddlOrder3.ClientID %>';
var SortedByDD4 = '<%= ddlOrder4.ClientID %>'; 
var FactoryManagerId = '<%=hdnProductionUnitManager.ClientID %>';
var ExDateFrom  = '<%= txtExDateFrom.ClientID %>';
var ExDateTo  = '<%= txtExDateTo.ClientID %>';
var objLooggedInUserID = '<%=hdnLoogedinUserID.ClientID %>';

$(function () {
    //added by yaten
    $(".loadingimage").hide();
    BindControls();
    
     $("#"+BuyerDDClientID,'#main_content').change(function(){
        var clientId = $(this).val();
     
        setClientName();
     });
     
      $("#"+SortedByDD,'#main_content').change(function(){
               setSortedBy();
     });
     
      $("#"+SortedByDD2,'#main_content').change(function(){
               setSortedBy2();
     });
     
      $("#"+SortedByDD3,'#main_content').change(function(){
               setSortedBy3();
     });
     
      $("#"+SortedByDD4,'#main_content').change(function(){
               setSortedBy4();
     });

 });
 
 function setClientName()   
{
selectedClient = $("#"+BuyerDDClientID,"#main_content").find("option:selected").val();
}

function setSortedBy()
{
selectedSort = $("#"+SortedByDD,"#main_content").find("option:selected").val();
}

function setSortedBy2()
{
selectedSort2 = $("#"+SortedByDD2,"#main_content").find("option:selected").val();
}

function setSortedBy3()
{
selectedSort3 = $("#"+SortedByDD3,"#main_content").find("option:selected").val();
}

function setSortedBy4()
{
selectedSort4 = $("#"+SortedByDD4,"#main_content").find("option:selected").val();
}

function showFabricPopup(StyleID,OrderDetailID, OrderID, ClientID, Fabric1, Fabric2, Fabric3, Fabric4, Fabric1Details, Fabric2Details, Fabric3Details, Fabric4Details)
  {
      proxy.invoke("ShowManageOrderFabricDatesPopup", { StyleID: StyleID,OrderDetailID: OrderDetailID, OrderID: OrderID, ClientID: ClientID, Fabric1: Fabric1, Fabric2: Fabric2, Fabric3: Fabric3, Fabric4: Fabric4, Fabric1Details: Fabric1Details, Fabric2Details: Fabric2Details, Fabric3Details: Fabric3Details, Fabric4Details: Fabric4Details }, function(result)
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
  
    function GetManageOrderiKandiQuantityByMode(Mode)
  { 
     proxy.invoke("GetManageOrderiKandiQuantityByMode", {Mode:Mode}, function(result)
     {
        jQuery.facebox(result); 
     },  onPageError, false, false);
  }
  
//  function ShowFitsPopup(StyleNumber,DepartmentID,OrderDetailID)
//  {
//   proxy.invoke("ManageOrderFitsInfoPopup", {StyleNumber:StyleNumber,DepartmentID:DepartmentID,OrderDetailID:OrderDetailID}, function(result)
//     {
//        jQuery.facebox(result); 
//     },  onPageError, false, false);
//  }
  
  function GetManageOrderiKandiQuantityByDept(DepartmentID)
  {
   proxy.invoke("GetManageOrderiKandiQuantityByDept", {DepartmentID:DepartmentID}, function(result)
     {
        jQuery.facebox(result); 
     },  onPageError, false, false);
  }

  // added by yaten
function PrintOrderSummaryPDF()
{
    $(".loadingimage").show();
    $(".print ").hide();
    setClientName();
    setSortedBy();
    setSortedBy2();
    setSortedBy3();
    setSortedBy4();
    
    var FactoryManagerID = $("#" + FactoryManagerId).val();    
    var SearchText = "";
    var ClientId = selectedClient;
    var SortedBy =  selectedSort;
    var SortedBy2 =  selectedSort2;
    var SortedBy3 =  selectedSort3;
    var SortedBy4 =  selectedSort4;
    var PageSize = 100000; 
    var PageIndex = 0;
    var objTotalQuantity = '<%=hdnTotalQuantity.ClientID%>';
    var TotalQuantity = $("#"+ objTotalQuantity).val();
    var loggenInUserId = $("#" + objLooggedInUserID).val();
    var FromExDate  = $("#" + ExDateFrom).val();
    var ToExDate   = $("#" + ExDateTo).val();

    proxy.invoke("GenerateDailyOrderSummaryReport", { PageSize: PageSize, PageIndex: PageIndex, SearchText: SearchText, ClientId: ClientId, SortedBy: SortedBy, SortedBy2: SortedBy2, SortedBy3: SortedBy3, SortedBy4: SortedBy4, TotalQuantity: TotalQuantity, FactoryManagerUserID: FactoryManagerID, UserId: loggenInUserId, FromExDate: FromExDate, ToExDate: ToExDate }, function (result) {
        if ($.trim(result) == '')
            jQuery.facebox("Some error occured on the server, please try again later.");
        else {
            window.open("/uploads/temp/" + result);
            $(".loadingimage").hide();
            $(".print").show();
        }
    });   
    
  return false;
}



  
</script>

<div class="print-box">
    <div class="form_box">
        <div class="form_heading">
            Order Summary Report
        </div>
        <div>
            <table width="1400px" cellspacing="5">
                <tr>
                    <td>
                        <asp:Label ID="lblSelectClient" Text="Select Client :" runat="server"></asp:Label>
                    </td>
                    <td class="hide_me">
                        <asp:TextBox ID="txtsearch" CssClass="do-not-disable" MaxLength="40" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlClient" runat="server" CssClass="do-not-disable">
                            <asp:ListItem Selected="True" Text="Select All ..." Value="-1"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:Label ID="lblSelectFactoryManager" Text="Factory Manager :" runat="server"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlProductionUnitManager" runat="server" title="Please select a Production Unit Manager">
                            <asp:ListItem Text="Select All ..." Value="-1" Selected="True"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:HiddenField ID="hdnProductionUnitManager" runat="server" Value="0" />
                    </td>
                    <td>
                        Ex-Fact Date from :
                    </td>
                    <td>
                         <asp:TextBox ID="txtExDateFrom" Width="90px" CssClass="do-not-disable date-picker" runat="server"></asp:TextBox>
                    </td>
                    <td>
                    To :
                    </td>
                    <td>
                         <asp:TextBox ID="txtExDateTo" Width="90px" CssClass="do-not-disable date-picker" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label ID="lblSortedBy" runat="server" CssClass="do-not-disable" Text="Sorted By :"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlSortedBy" runat="server" CssClass="do-not-disable">
                            <asp:ListItem Selected="True" Text="Select...." Value="-1"></asp:ListItem>
                            <asp:ListItem Value="1">Buyer</asp:ListItem>
                            <asp:ListItem Value="2">Style Number</asp:ListItem>
                            <asp:ListItem Value="3">Dept.</asp:ListItem>
                            <asp:ListItem Value="4">Ex-Factory</asp:ListItem>
                            <asp:ListItem Value="5">Status</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlOrder2" CssClass="do-not-disable">
                            <asp:ListItem Text="Select ....." Value="-1"></asp:ListItem>
                            <asp:ListItem Value="1">Buyer</asp:ListItem>
                            <asp:ListItem Value="2">Style Number</asp:ListItem>
                            <asp:ListItem Value="3">Dept.</asp:ListItem>
                            <asp:ListItem Value="4">Ex-Factory</asp:ListItem>
                            <asp:ListItem Value="5">Status</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlOrder3" CssClass="do-not-disable">
                            <asp:ListItem Text="Select ....." Value="-1"></asp:ListItem>
                            <asp:ListItem Value="1">Buyer</asp:ListItem>
                            <asp:ListItem Value="2">Style Number</asp:ListItem>
                            <asp:ListItem Value="3">Dept.</asp:ListItem>
                            <asp:ListItem Value="4">Ex-Factory</asp:ListItem>
                            <asp:ListItem Value="5">Status</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlOrder4" CssClass="do-not-disable">
                            <asp:ListItem Text="Select ....." Value="-1"></asp:ListItem>
                            <asp:ListItem Value="1">Buyer</asp:ListItem>
                            <asp:ListItem Value="2">Style Number</asp:ListItem>
                            <asp:ListItem Value="3">Dept.</asp:ListItem>
                            <asp:ListItem Value="4">Ex-Factory</asp:ListItem>
                            <asp:ListItem Value="5">Status</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:HiddenField ID="hdnLoogedinUserID" runat="server" Value="-1" />
                        <asp:Button ID="btnSearch" runat="server" CssClass="go do-not-disable" OnClick="btnSearch_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <table width="300px" class="item_list1">
        <tr>
            <th>
                Total Quantity
            </th>
            <td>
                <asp:Label runat="server" ID="lblTotalQuantity"></asp:Label>
                <asp:HiddenField ID="hdnTotalQuantity" runat="server" />
            </td>
        </tr>
    </table>
    <div class="form_box">
        <asp:GridView CssClass=" fixed-header item_list1" ID="GridView1" runat="server" AutoGenerateColumns="False"
            OnRowDataBound="GridView1_RowDataBound">
            <Columns>
                <asp:TemplateField HeaderText="Serial No." HeaderStyle-CssClass="vertical_header"
                    ItemStyle-CssClass="vertical_text" HeaderStyle-Width="28px">
                    <ItemTemplate>
                        <input type="hidden" id="hdnOrderID" value='<%# Eval("OrderID") %>' />
                        <a id="hypSerial" runat="server" class="hide_me"></a>                      
                        <asp:Label Height="80px" ID="lblSerialNo" CssClass="bold_text" runat="server" Text='<%# (Eval("ParentOrder") as iKandi.Common.Order).SerialNumber %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Order Dt." HeaderStyle-CssClass="vertical_header"
                    ItemStyle-CssClass="vertical_text date_style" HeaderStyle-Width="28px">
                    <ItemTemplate>
                        <input type="hidden" id="orderDetailID<%# Container.DataItemIndex + 1 %>" name="orderDetailID<%# Container.DataItemIndex + 1 %>"
                            value='<%# Eval("OrderDetailID") %>' />
                        <input type="hidden" id="OrderID<%# Container.DataItemIndex + 1 %>" name="OrderID<%# Container.DataItemIndex + 1 %>"
                            value='<%# Eval("OrderID") %>' />
                        <input type="hidden" id="ClientID<%# Container.DataItemIndex + 1 %>" name="ClientID<%# Container.DataItemIndex + 1 %>"
                            value='<%# (Eval("ParentOrder") as iKandi.Common.Order).Style.client.ClientID %>' />
                        <input type="hidden" id="hdnOrderDate<%# Container.DataItemIndex + 1 %>" name="hdnOrderDate<%# Container.DataItemIndex + 1 %>"
                            value='<%# (Convert.ToDateTime((Eval("ParentOrder") as iKandi.Common.Order).OrderDate) == DateTime.MinValue)? "" : (Eval("ParentOrder") as iKandi.Common.Order).OrderDate.ToString("dd MMM yy (ddd)") %>' />
                        <input type="hidden" id="hdnExFactory<%# Container.DataItemIndex + 1 %>" name="hdnExFactory<%# Container.DataItemIndex + 1 %>"
                            value='<%# (Convert.ToDateTime(Eval("ExFactory")) == DateTime.MinValue) ? "" : (Convert.ToDateTime(Eval("ExFactory"))).ToString("dd MMM yy (ddd)")%>' />
                        <span>
                            <%# (Convert.ToDateTime((Eval("ParentOrder") as iKandi.Common.Order).OrderDate) == DateTime.MinValue)? "" : (Eval("ParentOrder") as iKandi.Common.Order).OrderDate.ToString("dd MMM yy (ddd)") %>
                        </span>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Line No" SortExpression="LineItemNumber" HeaderStyle-CssClass="vertical_header"
                    ItemStyle-CssClass="vertical_text" HeaderStyle-Width="28px">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblLIneNo" Text='<%# Eval("LineItemNumber") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="contrt." SortExpression="ContractNumber" HeaderStyle-CssClass="vertical_header"
                    ItemStyle-CssClass="vertical_text" HeaderStyle-Width="28px">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblContractNo" Text='<%# Eval("ContractNumber") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Dept." HeaderStyle-CssClass="vertical_header" ItemStyle-CssClass="vertical_text"
                    HeaderStyle-Width="28px">
                    <ItemTemplate>                      
                        <span>
                            <%# (Eval("ParentOrder") as iKandi.Common.Order).Style.cdept.Name%>
                        </span>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Style Number" ItemStyle-CssClass="bold_text">
                    <ItemTemplate>
                        <span>
                            <nobr>
                           <%# (Eval("ParentOrder") as iKandi.Common.Order).Style.StyleNumber %>
                        </nobr>
                        </span>
                        <br />
                        <a title="CLICK TO VIEW ENLARGED IMAGE" href="javascript:void(0)" onclick='showStylePhotoWithOutScroll(<%# (Eval("ParentOrder") as iKandi.Common.Order).Style.StyleID +",-1,"+Eval("OrderDetailID").ToString()%>)'>
                            <img style="height: 150px ! important;" title="CLICK TO VIEW ENLARGED IMAGE" border="0px"
                                src='<%# ResolveUrl("~/uploads/style/thumb-" + (Eval("ParentOrder") as iKandi.Common.Order).Style.SampleImageURL1.ToString()) %>' /></a>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="desc" SortExpression="Description" HeaderStyle-CssClass="vertical_header "
                    ItemStyle-CssClass="vertical_text ">
                    <ItemTemplate>
                        <asp:Label ID="lblDiscription" runat="server" Height="150px" Text='<%# Eval("Description") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Fabric" SortExpression="Fabric1" HeaderStyle-Width="400px"
                    ItemStyle-Width="400px">
                    <ItemTemplate>
                        <div class="fabric_left_style">
                            <span>
                                <nobr>
                             <span runat="server" id="fabric1name">
                            <a title="CLICK TO VIEW APPROVALS FORM" target="FabricApprovals" 
                           href='<%#(Eval("Fabric1Details").ToString().IndexOf("PRD:") > -1)? "/Internal/Fabric/FabricApprovals.aspx?styleid="+(Eval("ParentOrder") as iKandi.Common.Order).Style.StyleID+"&clientid="+(Eval("ParentOrder") as iKandi.Common.Order).Style.client.ClientID+"&fabric="+Server.UrlEncode(Eval("Fabric1").ToString().Replace(@"""", @"&quot;").Replace("'", "&#39;").Replace("&#39;", @"&rsquo;"))+"&orderid="+"&fabricdetails="+Server.UrlEncode(Eval("Fabric1Details").ToString().Replace("PRD:","").Replace(@"""", @"&quot;").Replace("'", "&#39;").Replace("&#39;", @"&rsquo;")):"/Internal/Fabric/FabricApprovals.aspx?styleid="+(Eval("ParentOrder") as iKandi.Common.Order).Style.StyleID+"&clientid="+(Eval("ParentOrder") as iKandi.Common.Order).Style.client.ClientID+"&fabric="+Server.UrlEncode(Eval("Fabric1").ToString().Replace(@"""", @"&quot;").Replace("'", "&#39;").Replace("&#39;", @"&rsquo;"))+"&orderid="+Eval("OrderID")+"&fabricdetails="+Server.UrlEncode(Eval("Fabric1Details").ToString().Replace(@"""", @"&quot;").Replace("'", "&#39;").Replace("&#39;", @"&rsquo;")) %>'>
                            <%# Eval("Fabric1")%></a>
                        </span>
                    <label class="<%#(Eval("Fabric1Details").ToString().Trim() == "" ) ? "hide_me": "" %>">
                        : <%# Eval("Fabric1Details")%></label>
                         <label  class="<%#((Eval("ParentOrder") as iKandi.Common.Order).FabricApprovalDetails.F5BulkStatus.ToString().Trim() == "" ) ? "hide_me": "fabric_small_font fabricApprovalColor" %>">
                            (
                            <%# (Eval("ParentOrder") as iKandi.Common.Order).FabricApprovalDetails.F5BulkStatus%>
                            )
                        </label> <label style="color:Blue" class="<%#((Eval("ParentOrder") as iKandi.Common.Order).FabricInhouseHistory.Fabric1Percent == 0 ) ? "hide_me": "" %>">
                            (
                            <%# (Eval("ParentOrder") as iKandi.Common.Order).FabricInhouseHistory.Fabric1Percent %>%
                            )
                        </label></nobr>
                                <nobr>
                            <br />
                        <span runat="server" id="fabric2name">
                            <a target="FabricApprovals" 
                            href='<%#(Eval("Fabric2Details").ToString().IndexOf("PRD:") > -1)? "/Internal/Fabric/FabricApprovals.aspx?styleid="+(Eval("ParentOrder") as iKandi.Common.Order).Style.StyleID+"&clientid="+(Eval("ParentOrder") as iKandi.Common.Order).Style.client.ClientID+"&fabric="+Server.UrlEncode(Eval("Fabric2").ToString().Replace(@"""", @"&quot;").Replace("'", "&#39;").Replace("&#39;", @"&rsquo;"))+"&orderid="+"&fabricdetails="+Server.UrlEncode(Eval("Fabric2Details").ToString().Replace("PRD:","").Replace(@"""", @"&quot;").Replace("'", "&#39;").Replace("&#39;", @"&rsquo;")):"/Internal/Fabric/FabricApprovals.aspx?styleid="+(Eval("ParentOrder") as iKandi.Common.Order).Style.StyleID+"&clientid="+(Eval("ParentOrder") as iKandi.Common.Order).Style.client.ClientID+"&fabric="+Server.UrlEncode(Eval("Fabric2").ToString().Replace(@"""", @"&quot;").Replace("'", "&#39;").Replace("&#39;", @"&rsquo;"))+"&orderid="+Eval("OrderID")+"&fabricdetails="+Server.UrlEncode(Eval("Fabric2Details").ToString().Replace(@"""", @"&quot;").Replace("'", "&#39;").Replace("&#39;", @"&rsquo;")) %>'>
                             <%# Eval("Fabric2")%></a>
                        </span>
                    
                    <label class="<%#(Eval("Fabric2Details").ToString().Trim() == "" ) ? "hide_me": "" %>">
                        : <%# Eval("Fabric2Details")%></label>
                        
                        <label class="<%#((Eval("ParentOrder") as iKandi.Common.Order).FabricApprovalDetails.F6BulkStatus.ToString().Trim() == "" ) ? "hide_me": "fabric_small_font fabricApprovalColor" %>">
                            (
                            <%# (Eval("ParentOrder") as iKandi.Common.Order).FabricApprovalDetails.F6BulkStatus%>
                            )
                        </label><label style="color:Blue" class="<%#((Eval("ParentOrder") as iKandi.Common.Order).FabricInhouseHistory.Fabric2Percent == 0 ) ? "hide_me": "" %>">
                            (
                            <%# (Eval("ParentOrder") as iKandi.Common.Order).FabricInhouseHistory.Fabric2Percent %>%
                            )
                        </label> </nobr>
                                <nobr>
                            <br />
                        <span runat="server" id="fabric3name">
                            <a target="FabricApprovals" 
                            href='<%#(Eval("Fabric3Details").ToString().IndexOf("PRD:") > -1)? "/Internal/Fabric/FabricApprovals.aspx?styleid="+(Eval("ParentOrder") as iKandi.Common.Order).Style.StyleID+"&clientid="+(Eval("ParentOrder") as iKandi.Common.Order).Style.client.ClientID+"&fabric="+Server.UrlEncode(Eval("Fabric3").ToString().Replace(@"""", @"&quot;").Replace("'", "&#39;").Replace("&#39;", @"&rsquo;"))+"&orderid="+"&fabricdetails="+Server.UrlEncode(Eval("Fabric3Details").ToString().Replace("PRD:","").Replace(@"""", @"&quot;").Replace("'", "&#39;").Replace("&#39;", @"&rsquo;")):"/Internal/Fabric/FabricApprovals.aspx?styleid="+(Eval("ParentOrder") as iKandi.Common.Order).Style.StyleID+"&clientid="+(Eval("ParentOrder") as iKandi.Common.Order).Style.client.ClientID+"&fabric="+Server.UrlEncode(Eval("Fabric3").ToString().Replace(@"""", @"&quot;").Replace("'", "&#39;").Replace("&#39;", @"&rsquo;"))+"&orderid="+Eval("OrderID")+"&fabricdetails="+Server.UrlEncode(Eval("Fabric3Details").ToString().Replace(@"""", @"&quot;").Replace("'", "&#39;").Replace("&#39;", @"&rsquo;")) %>'>
                            <%# Eval("Fabric3")%></a>
                        </span>
                    
                    <label class="<%#(Eval("Fabric3Details").ToString().Trim() == "" ) ? "hide_me": "" %>">
                        : <%# Eval("Fabric3Details")%></label>
                        
                       
                             <label class="<%#((Eval("ParentOrder") as iKandi.Common.Order).FabricApprovalDetails.F7BulkStatus.ToString().Trim() == "" ) ? "hide_me": "fabric_small_font fabricApprovalColor" %>">
                            (
                            <%# (Eval("ParentOrder") as iKandi.Common.Order).FabricApprovalDetails.F7BulkStatus%>
                            )
                       
                        </label> <label style="color:Blue" class="<%#((Eval("ParentOrder") as iKandi.Common.Order).FabricInhouseHistory.Fabric3Percent == 0 ) ? "hide_me": "" %>">
                            (
                            <%# (Eval("ParentOrder") as iKandi.Common.Order).FabricInhouseHistory.Fabric3Percent %>%
                            )
                             </label></nobr>
                                <nobr>
                            <br />
                         <span runat="server" id="fabric4name">
                            <a target="FabricApprovals" 
                            href='<%#(Eval("Fabric4Details").ToString().IndexOf("PRD:") > -1)? "/Internal/Fabric/FabricApprovals.aspx?styleid="+(Eval("ParentOrder") as iKandi.Common.Order).Style.StyleID+"&clientid="+(Eval("ParentOrder") as iKandi.Common.Order).Style.client.ClientID+"&fabric="+Server.UrlEncode(Eval("Fabric4").ToString().Replace(@"""", @"&quot;").Replace("'", "&#39;").Replace("&#39;", @"&rsquo;"))+"&orderid="+"&fabricdetails="+Server.UrlEncode(Eval("Fabric4Details").ToString().Replace("PRD:","").Replace(@"""", @"&quot;").Replace("'", "&#39;").Replace("&#39;", @"&rsquo;")):"/Internal/Fabric/FabricApprovals.aspx?styleid="+(Eval("ParentOrder") as iKandi.Common.Order).Style.StyleID+"&clientid="+(Eval("ParentOrder") as iKandi.Common.Order).Style.client.ClientID+"&fabric="+Server.UrlEncode(Eval("Fabric4").ToString().Replace(@"""", @"&quot;").Replace("'", "&#39;").Replace("&#39;", @"&rsquo;"))+"&orderid="+Eval("OrderID")+"&fabricdetails="+Server.UrlEncode(Eval("Fabric4Details").ToString().Replace(@"""", @"&quot;").Replace("'", "&#39;").Replace("&#39;", @"&rsquo;")) %>'>
                            <%# Eval("Fabric4")%></a>
                        </span> 
                    
                    <label class="<%#(Eval("Fabric4Details").ToString().Trim() == "" ) ? "hide_me": "" %>">
                        : <%# Eval("Fabric4Details")%></label>
                       
                         <label  class="<%#((Eval("ParentOrder") as iKandi.Common.Order).FabricApprovalDetails.F8BulkStatus.ToString().Trim() == "" ) ? "hide_me": "fabric_small_font fabricApprovalColor" %>">
                            (
                            <%# (Eval("ParentOrder") as iKandi.Common.Order).FabricApprovalDetails.F8BulkStatus%>
                            ) </label> <label style="color:Blue" class="<%#((Eval("ParentOrder") as iKandi.Common.Order).FabricInhouseHistory.Fabric4Percent == 0 ) ? "hide_me": "" %>">
                            (
                            <%# (Eval("ParentOrder") as iKandi.Common.Order).FabricInhouseHistory.Fabric4Percent %>%
                            )
                        </label>
                            </span></nobr>
                        </div>
                        <br />
                        <span>
                            <img title="CLICK TO SEE FABRIC POPUP" src="/App_Themes/ikandi/images/view_icon.png"
                                border="0" onclick="showFabricPopup('<%# (Eval("ParentOrder") as iKandi.Common.Order).Style.StyleID %>','<%# Eval("OrderDetailID") %>','<%# Eval("OrderID") %>','<%# (Eval("ParentOrder") as iKandi.Common.Order).Style.client.ClientID %>','<%# Eval("Fabric1").ToString().Replace(@"""", @"&quot;").Replace("'", "&#39;").Replace("&#39;", @"&rsquo;")%>','<%# Eval("Fabric2").ToString().Replace(@"""", @"&quot;").Replace("'", "&#39;").Replace("&#39;", @"&rsquo;")%>','<%# Eval("Fabric3").ToString().Replace(@"""", @"&quot;").Replace("'", "&#39;").Replace("&#39;", @"&rsquo;")%>','<%# Eval("Fabric4").ToString().Replace(@"""", @"&quot;").Replace("'", "&#39;").Replace("&#39;", @"&rsquo;")%>','<%# Eval("Fabric1Details").ToString().Replace(@"""", @"&quot;").Replace("'", "&#39;").Replace("&#39;", @"&rsquo;")%>','<%# Eval("Fabric2Details").ToString().Replace(@"""", @"&quot;").Replace("'", "&#39;").Replace("&#39;", @"&rsquo;")%>','<%# Eval("Fabric3Details").ToString().Replace(@"""", @"&quot;").Replace("'", "&#39;").Replace("&#39;", @"&rsquo;")%>','<%# Eval("Fabric4Details").ToString().Replace(@"""", @"&quot;").Replace("'", "&#39;").Replace("&#39;", @"&rsquo;")%>')" /></span>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="STC Tgt." HeaderStyle-CssClass="vertical_header" ItemStyle-CssClass="vertical_text date_style"
                    ItemStyle-Width="28px ">
                    <ItemTemplate>
                        <%# (Convert.ToDateTime(Eval("STCUnallocated")) == DateTime.MinValue) ? "" : (Convert.ToDateTime(Eval("STCUnallocated"))).ToString("dd MMM yy (ddd)")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Fits" HeaderStyle-CssClass="" HeaderStyle-Width="200px"
                    ItemStyle-Width="200px" ItemStyle-CssClass="remarks_text2 vertical_top" ItemStyle-VerticalAlign="Top">
                    <ItemTemplate>
                        <table class="item_list vertical_top" style="vertical-align: top ! important; text-align: top;
                            padding-top: 0px ! important; align: top;">
                            <tr>
                                <td style="padding-top: 0px ! important;">
                                    <asp:Label ID="lblMon" runat="server" CssClass="" Text="Mon"></asp:Label>
                                </td>
                                <td style="padding-top: 0px ! important;">
                                    <asp:Label ID="lblTue" runat="server" CssClass="" Text="Tue"></asp:Label>
                                </td>
                                <td style="padding-top: 0px ! important;">
                                    <asp:Label ID="lblWed" runat="server" CssClass="" Text="Wed"></asp:Label>
                                </td>
                                <td style="padding-top: 0px ! important;">
                                    <asp:Label ID="lblThu" runat="server" CssClass="" Text="Thu"></asp:Label>
                                </td>
                                <td style="padding-top: 0px ! important;">
                                    <asp:Label ID="lblFri" runat="server" CssClass="" Text="Fri"></asp:Label>
                                </td>
                            </tr>
                        </table>
                        <br />
                        <asp:Label ID="lblSealDate" Width="180px" Text='<%# Eval("FitStatus")%>' runat="server"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Bulk Tgt." ItemStyle-CssClass=" date_style vertical_text "
                    HeaderStyle-CssClass="vertical_header">
                    <ItemTemplate>
                        <asp:Label ID="lblbulkAppTgt" runat="server" Text='<%# (Convert.ToDateTime(Eval("BulkTarget")) == DateTime.MinValue) ? "" : Convert.ToDateTime(Eval("BulkTarget")).ToString("dd MMM yy (ddd)")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Top Actual" HeaderStyle-CssClass="vertical_header"
                    ItemStyle-CssClass=" date_style vertical_text ">
                    <ItemTemplate>
                        <asp:Label CssClass="" ID="lblTopActual" runat="server" Text='<%# (Convert.ToDateTime((Eval("ParentOrder") as iKandi.Common.Order).InlinePPMOrderContract.TopSentActual) == DateTime.MinValue) ? "" : (Eval("ParentOrder") as iKandi.Common.Order).InlinePPMOrderContract.TopSentActual.ToString("dd MMM yy (ddd)")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Qty." ItemStyle-CssClass="numeric_text quantity_style"
                    HeaderStyle-Width="100px" ItemStyle-Width="100px">
                    <ItemTemplate>                      
                        <asp:Label ID="lblQty" Width="100px" runat="server" Text='<%# (Convert.ToInt32(Eval("Quantity"))).ToString("N0") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Mode" HeaderStyle-CssClass="vertical_header" ItemStyle-CssClass="vertical_text">
                    <ItemTemplate>                     
                        <asp:Label runat="server" CssClass="" ID="lblMode" Text=' <%# Eval("ModeName")%>'
                            ToolTip='<%# iKandi.BLL.CommonHelper.GetDeliveryModeToolTip(Convert.ToInt32(Eval("Mode"))) %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Ex-Factory" SortExpression="ExFactory" ItemStyle-CssClass="date_style bold_text"
                    HeaderStyle-Width="140px" ItemStyle-Width="140px">
                    <ItemTemplate>
                        <asp:Label ID="lblEx" runat="server" Width="140px" Text='<%# (Convert.ToDateTime(Eval("ExFactory")) == DateTime.MinValue) ? "" : (Convert.ToDateTime(Eval("ExFactory"))).ToString("dd MMM yy (ddd)")%>'></asp:Label>
                        <br />
                        <asp:Label ID="lblPlannedExfactoryDate" CssClass="small_Font" runat="server" Text=' <%# (Convert.ToDateTime(Eval("PlannedEx")) == DateTime.MinValue) ? "" : "(" + (Convert.ToDateTime(Eval("PlannedEx"))).ToString("dd MMM yy (ddd)") +")"%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="MDA Number" HeaderStyle-CssClass="vertical_header"
                    ItemStyle-CssClass="vertical_text">
                    <ItemTemplate>
                        <asp:Label ID="lblMdaNumber" runat="server" Text='<%# Eval("MDANumber") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Status" HeaderStyle-CssClass="vertical_header" ItemStyle-CssClass="vertical_text bold_text"
                    HeaderStyle-Width="28px">
                    <ItemTemplate>
                        <a id="hypstatusmode" runat="server" class="hide_me"></a>                     
                        <%# (Eval("ParentOrder") as iKandi.Common.Order).WorkflowInstanceDetail.StatusMode %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Unit Name" HeaderStyle-CssClass="vertical_header"
                    ItemStyle-CssClass="vertical_text quantity_style">
                    <ItemTemplate>
                        <span><a id="hypUnit" runat="server" class="hide_me"></a>
                            <asp:Label ID="lblUnit" runat="server" ToolTip='<%# (Eval("Unit") as iKandi.Common.ProductionUnit).FactoryCode %>'
                                Text='<%# (Eval("Unit") as iKandi.Common.ProductionUnit).FactoryName %>'></asp:Label>
                        </span>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Shipping Remarks" SortExpression="SanjeevRemarks"
                    HeaderStyle-Width="200px" ItemStyle-Width="200px" ItemStyle-CssClass="remarks_text remarks_text2">
                    <ItemTemplate>
                        <div style="width: 200px ! important;">
                            <label id="lblsanjeevRemarks<%# Container.DataItemIndex + 1 %>" name="lblsanjeevRemarks<%# Container.DataItemIndex + 1 %>">
                                <%#(Eval("SanjeevRemarks").ToString().IndexOf("~") > -1) ? Eval("SanjeevRemarks").ToString().Substring(Eval("SanjeevRemarks").ToString().LastIndexOf("~") + 2 ) : Eval("SanjeevRemarks").ToString()%>
                            </label>
                        </div>
                        <br />
                        <img alt="Shipping Remarks" title="CLICK TO SEE REMARKS POPUP" src="/App_Themes/ikandi/images/remark.gif"
                            border="0" onclick="showRemarks('<%# Eval("OrderDetailID") %>',0,'<%# (Eval("SanjeevRemarks").ToString().IndexOf("~") > -1) ? Eval("SanjeevRemarks").ToString().Replace("~", "<br/>").Replace("\n", "").Replace("\r", "").Replace("/n/r", "").Replace(@"""", @"&quot;").Replace(" ", "&#39;").Replace("&#39;", @"&rsquo;")  : Eval("SanjeevRemarks").ToString().Replace("\n", "").Replace("\r", "").Replace("/n/r", "").Replace(@"""", @"&quot;").Replace("'", "&#39;").Replace("&#39;", @"&rsquo;")  %>','SanjeevRemarks','Order_summary_Report',0)" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Production Remarks" SortExpression="SanjeevRemarks"
                    HeaderStyle-Width="200px" ItemStyle-Width="200px" ItemStyle-CssClass="remarks_text remarks_text2">
                    <ItemTemplate>
                        <div style="width: 200px ! important;">
                            <asp:Label ID="lblProdRemarks" runat="server" Text='<%# ((Eval("ParentOrder") as iKandi.Common.Order).StitchingDetail.ProdRemarks.ToString().IndexOf("$$") > -1) ? (Eval("ParentOrder") as iKandi.Common.Order).StitchingDetail.ProdRemarks.ToString().Substring((Eval("ParentOrder") as iKandi.Common.Order).StitchingDetail.ProdRemarks.ToString().LastIndexOf("$$") + 2) : (Eval("ParentOrder") as iKandi.Common.Order).StitchingDetail.ProdRemarks.ToString() %>'></asp:Label>
                        </div>
                        <br />
                        <img alt="Production Remarkks" title="CLICK TO SEE REMARKS POPUP" src="/App_Themes/ikandi/images/remark.gif"
                            border="0" onclick="showRemarks('<%# (Eval("ParentOrder") as iKandi.Common.Order).StitchingDetail.ID %>','<%# Eval("OrderDetailID") %>','<%# ((Eval("ParentOrder") as iKandi.Common.Order).StitchingDetail.ProdRemarks.ToString().IndexOf("$$") > -1) ? (Eval("ParentOrder") as iKandi.Common.Order).StitchingDetail.ProdRemarks.ToString().Replace("$$", "<br />").Replace("\n", "").Replace("\r", "").Replace("/n/r", "").Replace(@"""", @"&quot;").Replace("'", "&#39;").Replace("&#39;", @"&rsquo;")  : (Eval("ParentOrder") as iKandi.Common.Order).StitchingDetail.ProdRemarks.ToString().Replace("\n", "").Replace("\r", "").Replace("/n/r", "").Replace(@"""", @"&quot;").Replace("'", "&#39;").Replace("&#39;", @"&rsquo;")  %>','ProdRemarks','MANAGE_ORDER_FILE',0)" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <EmptyDataTemplate>
                <label>
                    No records Found</label></EmptyDataTemplate>
        </asp:GridView>
    </div>
    <div style="margin-top: 5px; text-align: right;">
        <cc1:HyperLinkPager ID="HyperLinkPager1" runat="server" PageSize="10">
        </cc1:HyperLinkPager>
    </div>
</div>
<div id="links" class="hide_me">
    <a href="/Internal/Sales/Order.aspx" target="OrderForm" title="CLICK TO VIEW ORDER FORM"
        class="hyp">Order Form</a><br />
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
 <asp:Image ID="LoadImg" Style="position: fixed; z-index: 52111; top: 20%; left: 50%;
        width: 5%;" CssClass="loadingimage" ImageUrl="~/App_Themes/ikandi/images1/loading7.gif"
        runat="server" />
<input type="button" id="btnPrint" class="print" onclick="return PrintOrderSummaryPDF();" />
<%--<asp:Button runat="server" ID="btnPrint" CssClass="print  do-not-disable" OnClick=" btnPrint_click()" /> --%>
