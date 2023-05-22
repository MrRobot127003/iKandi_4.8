<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AccessoryInfoPopup.ascx.cs" Inherits="iKandi.Web.AccessoryInfoPopup" %>

<div class="heading_name">
    ACCESSORY QUICK DETAILS
</div>
<ul>
    <li><span class="blue-text">TYPE</span> :
        <asp:Label runat="server" ID="lblType"></asp:Label>
    </li>
    <li><span class="blue-text">QTY</span> :
        <asp:Label runat="server" ID="lblQty"></asp:Label></li>
    <li><span class="blue-text">TOTAL QTY</span> :
        <asp:Label runat="server" ID="lblTotalQty"></asp:Label></li>
    <li><span class="blue-text">DETAILS</span> :
        <asp:Label runat="server" ID="lblDetails"></asp:Label></li>
    <li><span class="blue-text">IS DTM</span>:
        <asp:Label runat="server" ID="lblIsDTM"></asp:Label>
        </li>
</ul>