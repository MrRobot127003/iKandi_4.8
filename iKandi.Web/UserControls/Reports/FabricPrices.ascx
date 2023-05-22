<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FabricPrices.ascx.cs" Inherits="iKandi.Web.FabricPrices" %>
<%@ Register Assembly="iKandi.Web" Namespace="iKandi.Components.UI" TagPrefix="cc1" %>


<div class="form_box">
    <div class="form_heading">
        Fabric Prices Report
    </div>
    <div>
      <table>
             <tr>
                <td>
                    Search
                </td>  
                <td>
                     <asp:TextBox runat="server" ID="txtSearchText" CssClass="do-not-disable"></asp:TextBox>
                </td>    
                <td>
                     Price
                </td>     
                <td>
                     <asp:TextBox runat="server" ID="txtPriceFrom" CssClass="do-not-disable numeric-field-without-decimal-places"></asp:TextBox>
                </td>
                <td>
                      to
                </td>
                <td>
                     <asp:TextBox runat="server" ID="txtPriceTo" CssClass="do-not-disable numeric-field-without-decimal-places"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" CssClass="do-not-disable go" />
                </td> 
             </tr>
      </table>       
    </div>
</div>
<div class="form_box">
    <asp:GridView ID="grdFabricPrices" runat="server" AutoGenerateColumns="false"
        CssClass="item_list fixed-header">
        <Columns>
             <asp:TemplateField HeaderText="Fabric" >
                <ItemTemplate>
                    <asp:Label ID="Label9" runat="server" Text='<%# Eval("Fabric")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Source">
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("SupplierName")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Width" ItemStyle-CssClass="numeric_text">
                <ItemTemplate>
                    <asp:Label ID="Label11" runat="server" Text='<%# Eval("Width")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Price Dyed By Air">
                <ItemTemplate>
                    <asp:Label ID="lblPrice1" runat="server" Text='<%# Eval("PriceForDyedByAir")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Price Dyed By Sea">
                <ItemTemplate>
                    <asp:Label ID="lblPrice2" runat="server" Text='<%# Eval("PriceForDyedBySea")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Price Printed By Air">
                <ItemTemplate>
                    <asp:Label ID="lblPrice3" runat="server" Text='<%# Eval("PriceForPrintedByAir")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Price Printed By Sea">
                <ItemTemplate>
                    <asp:Label ID="lblPrice4" runat="server" Text='<%# Eval("PriceForPrintedBySea")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Last Updated" ItemStyle-CssClass="date_style">
                <ItemTemplate>
                     <%# (Convert.ToDateTime((Eval("UpdatedOn") == DBNull.Value) ? DateTime.MinValue : (Convert.ToDateTime(Eval("UpdatedOn")))) == DateTime.MinValue) ? "" : (Convert.ToDateTime(Eval("UpdatedOn"))).ToString("dd MMM yy (ddd)")%>
                </ItemTemplate>
            </asp:TemplateField>            
        </Columns>
        <EmptyDataTemplate><label>NO RECORD FOUND</label></EmptyDataTemplate>
    </asp:GridView>
</div>
<div style="margin-top: 5px; text-align: right;">
    <cc1:HyperLinkPager ID="HyperLinkPager1" runat="server" PageSize="10">
    </cc1:HyperLinkPager>
</div>
