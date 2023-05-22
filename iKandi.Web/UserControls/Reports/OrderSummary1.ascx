<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="OrderSummary1.ascx.cs" Inherits="iKandi.Web.OrderSummary1" %>

<script type="text/javascript">
$(function() 
{
});
    var currentDate = new Date();
    var Today = (currentDate.getMonth()+1) + '/' + currentDate.getDate() + '/'+ currentDate.getFullYear();
    var dateToday = Date.parse(Today).toString('dd MMM yy (ddd)') ;
    $(function(){
    $("#hdnDate").val(dateToday);
    });
    
    var serviceUrl = '<%= ResolveUrl("~/Webservices/iKandiService.asmx/") %>';
    var proxy = new ServiceProxy(serviceUrl);
 
//  function showFabricPopup(OrderDetailID,OrderID,ClientID,Fabric1,Fabric2,Fabric3,Fabric4)
//  { 
//     proxy.invoke("ShowManageOrderFabricDatesPopup", {OrderDetailID:OrderDetailID,OrderID:OrderID,ClientID:ClientID,Fabric1:Fabric1,Fabric2:Fabric2,Fabric3:Fabric3,Fabric4:Fabric4}, function(result)
//     {
//        jQuery.facebox(result); 
//     },  onPageError, false, false);
//  }
//  
//  function showSizePopup(OrderDetailID)
//  { 
//     proxy.invoke("GetSizesPopup", {OrderDetailID:OrderDetailID}, function(result)
//     {
//        jQuery.facebox(result); 
//     },  onPageError, false, false);
//  }
//  
//  function GetManageOrderiKandiQuantityByDept(DepartmentID)
//  {
//   proxy.invoke("GetManageOrderiKandiQuantityByDept", {DepartmentID:DepartmentID}, function(result)
//     {
//        jQuery.facebox(result); 
//     },  onPageError, false, false);
//  }
</script>

<div class="print-box">
<asp:GridView CssClass="item_list" ID="grdorderSummary" runat="server" AutoGenerateColumns="False"
    DataSourceID="odsOrderSummaryReport fixed-header">
    <Columns>
     <asp:TemplateField HeaderText="Order Date" ItemStyle-CssClass="date_style">
     <ItemTemplate>
        <input type="hidden" id="orderDetailID<%# Container.DataItemIndex + 1 %>" name="orderDetailID<%# Container.DataItemIndex + 1 %>"
                    value='<%# Eval("OrderDetailID") %>' />
                <input type="hidden" id="OrderID<%# Container.DataItemIndex + 1 %>" name="OrderID<%# Container.DataItemIndex + 1 %>"
                    value='<%# Eval("OrderID") %>' />
                <input type="hidden" id="ClientID<%# Container.DataItemIndex + 1 %>" name="ClientID<%# Container.DataItemIndex + 1 %>"
                    value='<%# (Eval("ParentOrder") as iKandi.Common.Order).Style.client.ClientID %>' />
                <input type="hidden" id="hdnDate" name="hdnDate" value="" />
                <span style="width : 100px">
                  <%# (Convert.ToDateTime((Eval("ParentOrder") as iKandi.Common.Order).OrderDate) == DateTime.MinValue)? "" : (Eval("ParentOrder") as iKandi.Common.Order).OrderDate.ToString("dd MMM yy (ddd)") %> </span>
            </ItemTemplate>
        </asp:TemplateField>
         <asp:TemplateField HeaderText="Serial No.">
            <ItemTemplate>
            <span><%# (Eval("ParentOrder") as iKandi.Common.Order).SerialNumber%></span>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Dept.">
            <ItemTemplate>
            <span>
                 <%# (Eval("ParentOrder") as iKandi.Common.Order).Style.DepartmentName%></span>
            </ItemTemplate>
        </asp:TemplateField>
        
   <%-- <asp:BoundField DataField="OrderDate" HeaderText="Order Date" />--%>
     <%--   <asp:BoundField DataField="DepartmentName" HeaderText="Dept." />--%>
       <asp:TemplateField HeaderText="Style No." HeaderStyle-CssClass="vertical_header" ItemStyle-CssClass="vertical_text">
                <ItemTemplate>
                    <span>
                        <%# (Eval("ParentOrder") as iKandi.Common.Order).Style.StyleNumber %></span>
                </ItemTemplate>
            </asp:TemplateField>
        <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" HeaderStyle-CssClass="vertical_header" ItemStyle-CssClass="vertical_text"  />
        <asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="Quantity" HeaderStyle-CssClass="vertical_header" ItemStyle-CssClass="numeric_text" />
        <asp:TemplateField HeaderText="Fabric/Details" SortExpression="Fabric1" >
            <ItemTemplate>
                <label>
                    <%# Eval("Fabric1")%></label>
                :
                <label>
                    <%# Eval("Fabric1Details")%></label><br />
                <label>
                    <%# Eval("Fabric2")%></label>
                :
                <label>
                    <%# Eval("Fabric2Details")%></label><br />
                <label>
                    <%# Eval("Fabric3")%></label>
                :
                <label>
                    <%# Eval("Fabric3Details")%></label><br />
                <label>
                    <%# Eval("Fabric4")%></label>
                :
                <label>
                    <%# Eval("Fabric4Details")%></label>
          </ItemTemplate>
       </asp:TemplateField>
       <asp:TemplateField HeaderText="STC Target" SortExpression="ExFactory" HeaderStyle-CssClass="vertical_header" ItemStyle-CssClass="vertical_text date_style">
                    <ItemTemplate>
                         <div style="width : 100px">
                            <%# (Convert.ToDateTime(Eval("ExFactory")) == DateTime.MinValue) ? "" : (Convert.ToDateTime(Eval("ExFactory"))).ToString("dd MMM yy (ddd)")%>
                        </div>
                    </ItemTemplate>
                </asp:TemplateField>
        <asp:BoundField DataField="" DataFormatString="{0:dd MMM yy (ddd)}" HeaderText="Fit"
            SortExpression="ExFactory" HeaderStyle-Width="100px" ItemStyle-Width="100px" />
       <asp:TemplateField HeaderText="Top Sent Target" SortExpression="ExFactory" HeaderStyle-CssClass="vertical_header" ItemStyle-CssClass="vertical_text date_style">
                    <ItemTemplate>
                         <div style="width : 100px">
                             <%# (Convert.ToDateTime(Eval("ExFactory")) == DateTime.MinValue) ? "" : (Convert.ToDateTime(Eval("ExFactory"))).ToString("dd MMM yy (ddd)")%>
                        </div>
                    </ItemTemplate>
                </asp:TemplateField>
        <asp:TemplateField HeaderText="Cutting">
            <ItemTemplate>
                <span></span>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Stiching">
            <ItemTemplate>
                <span></span>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Packed">
            <ItemTemplate>
                <span></span>
            </ItemTemplate>
        </asp:TemplateField>
         <asp:BoundField DataField="Mode" HeaderText="Mode" SortExpression="Mode"  HeaderStyle-CssClass="vertical_header" ItemStyle-CssClass="vertical_text"/>
        <%--<asp:BoundField DataField="ExFactory" DataFormatString="{0:dd MMM yy (ddd)}" HeaderText="Ex Factory"
            SortExpression="ExFactory"  />--%>
            <asp:TemplateField HeaderText="Ex Factory" ItemStyle-CssClass="date_style">
                    <ItemTemplate>
                         <div style="width : 100px">
                            <%# (Convert.ToDateTime(Eval("ExFactory")) == DateTime.MinValue) ? "" : (Convert.ToDateTime(Eval("ExFactory"))).ToString("dd MMM yy (ddd)")%>
                        </div>
                    </ItemTemplate>
                </asp:TemplateField>
        <%--<asp:BoundField DataField="DC" DataFormatString="{0:dd MMM yy (ddd)}" HeaderText="DC Date"
            SortExpression="DC" />--%>
            <asp:TemplateField HeaderText="DC Date" ItemStyle-CssClass="date_style">
                    <ItemTemplate>
                         <div style="width : 100px">
                            <%# (Convert.ToDateTime(Eval("DC")) == DateTime.MinValue) ? "" : (Convert.ToDateTime(Eval("DC"))).ToString("dd MMM yy (ddd)")%>
                        </div>
                    </ItemTemplate>
                </asp:TemplateField>
             <asp:TemplateField HeaderText="Price" ItemStyle-CssClass="numeric_text">
            <ItemTemplate>
                   <span> <%# Eval("ikandiPrice")%></span>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField DataField="StatusMode" HeaderText="Mode" SortExpression="StatusMode" />
       <asp:BoundField DataField="SanjeevRemarks" HeaderText="Sanjeev Remarks" SortExpression="SanjeevRemarks" ItemStyle-CssClass="remarks_text remarks_text2" />
        <asp:BoundField DataField="MerchantNotes" HeaderText="Merchant Notes" SortExpression="MerchantNotes" ItemStyle-CssClass="remarks_text remarks_text2" />
        </Columns>
        <EmptyDataTemplate><label>NO RECORD FOUND</label></EmptyDataTemplate>
</asp:GridView>

<asp:ObjectDataSource ID="odsOrderSummaryReport" runat="server" 
    SelectMethod="GetOrderSummaryReports" TypeName="iKandi.BLL.ReportController">
</asp:ObjectDataSource>

</div>