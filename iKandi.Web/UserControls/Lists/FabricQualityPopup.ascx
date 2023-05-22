<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FabricQualityPopup.ascx.cs"
    Inherits="iKandi.Web.FabricQualityPopup" %>
<div class="heading_name">
    FABRIC QUICK DETAILS
</div>
<ul>
    <li><span class="blue-text">GROUP</span> :
        <asp:Label runat="server" ID="lblGroup"></asp:Label>
    </li>
    <li><span class="blue-text">SUB GROUP</span> :
        <asp:Label runat="server" ID="lblSubGroup"></asp:Label></li>
    <li><span class="blue-text">COUNT CONSTRUCTION</span> :
        <asp:Label runat="server" ID="lblCountConstruction"></asp:Label></li>
    <li><span class="blue-text">COMPOSITION</span> :
        <asp:Label runat="server" ID="lblComposition"></asp:Label></li>
    <li><span class="blue-text">GSM </span>:
        <asp:Label runat="server" ID="lblGSM"></asp:Label></li>
    <li><span class="blue-text">MINIMUM ORDER QTY</span> :
        <asp:Label runat="server" ID="lblMinOrderQty"></asp:Label></li>
    <li><span class="blue-text">LEAD TIME (DYED/PRINTED</span>) :
        <asp:Label runat="server" ID="lblLeadTimeDyed"></asp:Label>/<asp:Label runat="server"
            ID="lblLeadTimePrinted"></asp:Label></li>
    <li><span class="blue-text">PRICE (DYED/PRINTED)</span> :
        <asp:Label runat="server" ID="lblPriceDyed"></asp:Label>/<asp:Label runat="server"
            ID="lblPricePrinted"></asp:Label></li>
</ul>
<div align="center">
    <asp:HyperLink runat="server" Target="_blank" ID="hypLink" Text="FABRIC QUALITY FORM"></asp:HyperLink>
</div>
