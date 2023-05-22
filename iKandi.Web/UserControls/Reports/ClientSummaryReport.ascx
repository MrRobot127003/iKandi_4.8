<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ClientSummaryReport.ascx.cs" Inherits="iKandi.Web.ClientSummaryReport" %>
<table class="item_list" border="1px solid black" width="1000px">
    <tbody>
        <tr>
            <th>
                Buyer
            </th>
            <th>
                QTY(pcs) on order
            </th>
            <th>
                No.Of Orders
            </th>
            <%-- <th class="ex-factory">
                ExFactory's this Week
            </th>--%>
            <th class="bulk-basic hide_me">
                Bulk In House This Week
            </th>
            <th class="bulk-fabric hide_me">
                Bulk In House This Week
            </th>
            <th class="bulk-accessory hide_me">
                Bulk In House This Week
            </th>
            <th class="pcs-cut hide_me">
                Pcs Cut This Week
            </th>
            <th class="pcs-stitched hide_me">
                Pcs Stitched This Week
            </th>
            <th>
                Qty this week
            </th>
        </tr>
        <tr>
            <td width="10%">
                <asp:Label runat="server" ID="lblBuyer"></asp:Label>
            </td>
            <td width="10%">
                <asp:Label runat="server" ID="lblTotalQuantity"></asp:Label>
            </td>
            <td width="10%">
                <asp:Label runat="server" ID="lblTotalOrders"></asp:Label>
            </td>
            <%--<td width="20%" class="ex-factory">
                <asp:Label runat="server" ID="lblExFactory"></asp:Label>
            </td>--%>
            <td width="10%" class="bulk-basic hide_me">
                <asp:Label runat="server" ID="basic"></asp:Label>
            </td>
            <td width="10%" class="bulk-fabric hide_me">
                <asp:Label runat="server" ID="fabric"></asp:Label>
            </td>
            <td width="10%" class="bulk-accessory hide_me">
                <asp:Label runat="server" ID="accessory"></asp:Label>
            </td>
            <td width="10%" class="pcs-cut hide_me">
                <asp:Label runat="server" ID="cut"></asp:Label>
            </td>
            <td width="10%" class="pcs-stitched hide_me">
                <asp:Label runat="server" ID="stitched"></asp:Label>
            </td>
            <td width="10%">
                <asp:Label runat="server" ID="lblQuantity"></asp:Label>
            </td>
        </tr>
    </tbody>
</table>