<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PendingBuyingSamples.ascx.cs"
    Inherits="iKandi.Web.PendingBuyingSamples" %>
<%@ Register Assembly="iKandi.Web" Namespace="iKandi.Components.UI" TagPrefix="cc1" %>
<div class="form_box">
    <div class="form_heading">
        Pending Buying Samples
    </div>
    <div>
        <table>
            <tr>
                <td>
                    Style Number
                </td>
                <td>
                    <asp:TextBox ID="txtStyleNo" runat="server" Width="190px"></asp:TextBox>
                </td>
                <td>
                    Due Date
                </td>
                <td>
                    <asp:Label ID="lblfrom" Text="From" runat="server"></asp:Label>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtfrom" class="date-picker do-not-disable"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="lblTo" Text="To" runat="server"></asp:Label>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtTo" class="date-picker do-not-disable"></asp:TextBox>
                </td>
                <td>
                    <asp:Button runat="server" ID="btnSearch" OnClick="btnSearch_Click" class="go" />
                </td>
            </tr>
        </table>
    </div>
</div>
<div class="form_box">
    <asp:GridView CssClass="item_list1 fixed-header" ID="grdPendingSamples" runat="server"
        AutoGenerateColumns="False" PageSize="20" OnRowDataBound="grdPendingSamples_RowDataBound" Width="100%">
        <Columns>
            <asp:TemplateField HeaderText="Style Number.">
                <ItemTemplate>
                    <%# Eval("StyleNumber")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Due Date" >
                <ItemTemplate>
                    <asp:Label ID="lblDueDate" runat="server"></asp:Label>
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
