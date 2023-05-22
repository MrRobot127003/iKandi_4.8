<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WhereAreMyOrders.ascx.cs"
 Inherits="iKandi.Web.WhereAreMyOrders" %>
<div class="form_box">
    <div class="form_heading">
        Where Are My Orders
    </div>
</div>
<div class="form_box">
    <asp:GridView CssClass=" fixed-header item_list" ID="GridView1" runat="server" AutoGenerateColumns="False"
        OnRowDataBound="GridView1_RowDataBound">
        <Columns>
            <asp:BoundField HeaderText="Status" DataField="NAME" SortExpression="NAME" />
            <asp:BoundField HeaderText="Number Of Contracts" DataField="NumberOfContracts" SortExpression="NumberOfContracts" />
            <asp:BoundField HeaderText="Total Quantity" DataField="TotalQuantity" SortExpression="TotalQuantity" />
        </Columns>
        <EmptyDataTemplate>
            <label>
                No records Found</label></EmptyDataTemplate>
    </asp:GridView>
</div>
