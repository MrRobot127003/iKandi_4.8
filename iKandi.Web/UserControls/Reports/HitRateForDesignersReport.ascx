<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HitRateForDesignersReport.ascx.cs"
    Inherits="iKandi.Web.HitRateForDesignersReport" %>
<style>
    item_list th
    {
        padding: 5px !important;
    }
    item_list td
    {
        border: 1px solid #CCCCCC !important;
    }
</style>
<table id="tblDesignerHitRates" runat="server" class="item_list2 portlet" style="border: 1px solid #CCCCCC;
    width: 265px! important; font-size: 10px">
    <tr>
        <th colspan="2">
        </th>
    </tr>
    <tr>
        <th style="width: 80%">
            TOTAL STYLES CREATED THIS YEAR
        </th>
        <td style="width: 20%">
            <asp:Label ID="lbltotalsamplesmadeyear" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <th>
            TOTAL STYLES SOLD THIS YEAR
        </th>
        <td>
            <asp:Label ID="lbltotalsamplessoldyear" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <th>
            &nbsp;
        </th>
        <td>
            &nbsp;
        </td>
    </tr>
    <tr>
        <th>
            TOTAL STYLES CREATED THIS MONTH
        </th>
        <td>
            <asp:Label ID="lbltotalsamplesmademonth" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <th>
            TOTAL STYLES SOLD THIS MONTH
        </th>
        <td>
            <asp:Label ID="lbltotalsamplessoldmonth" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <th>
            &nbsp;
        </th>
        <td>
            &nbsp;
        </td>
    </tr>
    <tr>
        <th>
            YEARLY HIT RATE
        </th>
        <td>
            <asp:Label ID="lbltargetrate" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <th>
        </th>
        <td>
        </td>
    </tr>
</table>
