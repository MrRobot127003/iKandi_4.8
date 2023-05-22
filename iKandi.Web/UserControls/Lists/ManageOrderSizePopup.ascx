<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ManageOrderSizePopup.ascx.cs" Inherits="iKandi.Web.ManageOrderSizePopup" %>
<script type="text/javascript">
 $(function() {
 }
</script>
<div class="form_box">
 <div class="form_heading" >
            Order Sizes</div><br />
<asp:ObjectDataSource ID="odsBasicInfo" runat="server" SelectMethod="GetOrderDetailSizes"
    TypeName="iKandi.BLL.OrderController"></asp:ObjectDataSource>
<asp:GridView CssClass="item_list" ID="GridView1" runat="server" AutoGenerateColumns="False"
    DataSourceID="odsBasicInfo">
    <Columns>
        <asp:BoundField DataField="Size" HeaderText="Size" SortExpression="Size" ItemStyle-CssClass="numeric_text" />
        <asp:BoundField DataField="QuantityString" HeaderText="Quantity" SortExpression="Quantity" ItemStyle-CssClass="numeric_text"/>
        <asp:BoundField DataField="RatioPackString" HeaderText="Ratio Pack" SortExpression="RatioPack" ItemStyle-CssClass="numeric_text" />
        <asp:BoundField DataField="RatioString" HeaderText="Ratio" SortExpression="Ratio" ItemStyle-CssClass="numeric_text" />
        <asp:BoundField DataField="SinglesString" HeaderText="Singles" SortExpression="Singles" ItemStyle-CssClass="numeric_text"  />
    </Columns>
</asp:GridView>
</div>