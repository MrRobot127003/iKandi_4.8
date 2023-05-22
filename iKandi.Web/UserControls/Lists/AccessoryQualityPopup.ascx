<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AccessoryQualityPopup.ascx.cs"
    Inherits="iKandi.Web.AccessoryQualityPopup" %>
<div class="heading_name">
    ACCESSORY QUALITY QUICK DETAILS
</div>
<ul>
    <li><span class="blue-text">GROUP</span> :
        <asp:Label runat="server" ID="lblGroup"></asp:Label>
    </li>
    <li><span class="blue-text">SUB GROUP</span> :
        <asp:Label runat="server" ID="lblSubGroup"></asp:Label></li>
    <li><span class="blue-text">DESCRIPTION</span> :
        <asp:Label runat="server" ID="lblDesc"></asp:Label></li>
    <li><span class="blue-text">WASTAGE</span> :
        <asp:Label runat="server" ID="lblWst"></asp:Label>%</li>
    <li><span class="blue-text">LEAD TIME </span>:
        <asp:Label runat="server" ID="lblLeadTime"></asp:Label>
        Days</li>
    <li><span class="blue-text">PRICE </span>:
        <asp:Label runat="server" ID="lblPrice"></asp:Label>
        Rs.</li>
</ul>
<div align="center">
    <asp:HyperLink runat="server" Target="_blank" ID="hypLink" Text="ACCESSORY QUALITY FORM"></asp:HyperLink>
</div>
