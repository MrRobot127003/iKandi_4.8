<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="OrdersPlacedVsShipped.ascx.cs" Inherits="iKandi.Web.OrdersPlacedVsShipped" %>
<div class="form_box">
    <div class="form_heading">
        Orders Placed V/S Shipped
    </div>
    <div>
        <table width="300px" cellspacing="5">
            <tr>                
                <td>
                    Select Factory:
                </td>
                <td>
                    <asp:DropDownList Width="125px" ID="ddlProductionUnits" runat="server" CssClass="do-not-disable">
                     <asp:ListItem Text = "all" Value="-1" Selected="True"></asp:ListItem>
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
    <asp:GridView CssClass=" fixed-header item_list" ID="gvOrdersPlacedVsShipped" runat="server" AutoGenerateColumns="True"
        OnRowCreated="GridView1_OnRowCreated" OnRowDataBound="GridView1_RowDataBound">
        <Columns>
        </Columns>
        <EmptyDataTemplate>
            <label>
                No records Found</label></EmptyDataTemplate>
    </asp:GridView>
</div>