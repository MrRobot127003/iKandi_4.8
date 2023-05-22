<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ManageOrderiKandiQuantityByDeptPopup.ascx.cs"
    Inherits="iKandi.Web.ManageOrderiKandiQuantityByDeptPopup" %>
<div class="form_box">
    <div class="form_heading">
        Department Wise B/D Of Orders</div>
    <br />
    <asp:GridView CssClass="item_list" ID="GridView1" runat="server" AutoGenerateColumns="False"
        DataSourceID="odsBasicInfo">
        <Columns>
            <asp:TemplateField HeaderText="Serial No.">
                <ItemTemplate>
                    <span>
                        <%# (Eval("ParentOrder") as iKandi.Common.Order).SerialNumber%></span>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="ContractNumber" HeaderText="Contract No" SortExpression="ContractNumber"
                ItemStyle-CssClass="numeric_text" />
                <asp:TemplateField HeaderText="Style No.">
                <ItemTemplate>
                    <span>
                        <%# (Eval("ParentOrder") as iKandi.Common.Order).Style.StyleNumber %></span>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="Quantity"
                ItemStyle-CssClass="numeric_text" />
        </Columns>
    </asp:GridView>
</div>
<asp:ObjectDataSource ID="odsBasicInfo" runat="server" SelectMethod="GetManageOrderiKandiQuantityByDept"
    TypeName="iKandi.BLL.OrderController"></asp:ObjectDataSource>
