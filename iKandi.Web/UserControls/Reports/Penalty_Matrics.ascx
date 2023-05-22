<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Penalty_Matrics.ascx.cs"
    Inherits="iKandi.Web.UserControls.Reports.Penalty_Matrics" %>
<style type="text/css">
    .Main-header
    {
        background: #405d99;
        color: White;
        font-size: 15px;
        text-transform: uppercase;
        font-weight: bold;
        text-align: center;
        border: 2px solid white;
        height: 30px;
        font-family: Verdana;
    }
    .Unit-header
    {
        background: #405d99;
        color: White;
        font-size: 9px;
        text-align: center;
        border: 1px solid white;
        height: 20px;
        font-family: Verdana;
    }
    .head-in
    {
        color: gray;
        font-family: Verdana;
        font-size: 11px;
        border-bottom: 1px solid #dbddff;
        height: 20px;
        text-align: center;
    }
    .head-in-bottom
    {
        color: gray;
        font-family: Verdana;
        font-size: 11px;
        border-bottom: none;
        height: 20px;
        text-align: center;
    }
    .comp
    {
        color: gray;
        font-family: Verdana;
        font-size: 12px;
        font-weight: bold;
        text-align: center;
        text-transform: capitalize;
    }
    .blue span
    {
        color: Blue;
    }
    .total-penal span
    {
        color: Black;
    }
    .bold
    {
        font-weight: bold;
    }
    .bot-bor
    {
        display: table-cell;
    }
</style>
<script src="../../js/jquery-1.5.2-jquery.min.js" type="text/javascript"></script>
<script type="text/javascript">
     $(window).load(function () {
        $("span").each(function () {
            var el = $(this);
            var value = parseFloat(el.text);

            if (value == 0.0%) {
               
                el
             .css("display", "none")
            }
        });
    });

  

</script>
<div style="text-align: center; width: 3000px;">
    <h2 style="background: #3a5795; padding: 5px 0px; color: #fff; margin: 0; font-family: Verdana;">
        Penalty Metrics
    </h2>
</div>
<table cellpadding="0" cellspacing="0" width="3000">
    <tr>
        <td valign="top" width="900">
            <table cellpadding="0" cellspacing="0" width="100%">
                <tr>
                    <td class="Main-header">
                        C 47
                    </td>
                </tr>
                <tr>
                    <td class="comp">
                        Penalty
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:GridView ID="gvPenalty_Matrics_Unit1" runat="server" AutoGenerateColumns="false"
                            Width="100%" ShowFooter="false" ShowHeader="true" RowStyle-HorizontalAlign="Center"
                            HeaderStyle-HorizontalAlign="Center" HeaderStyle-CssClass="top-header" BorderColor="#dbddff"
                            Style="table-layout: fixed; border-collapse: collapse; padding: 0px; margin: 0px;">
                            <Columns>
                                <asp:TemplateField ItemStyle-Width="100" HeaderStyle-Width="100" HeaderStyle-CssClass="Unit-header"
                                    HeaderText="Company">
                                    <ItemTemplate>
                                        <table width="100%" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td class="comp" rowspan="4" valign="middle">
                                                    <%# Eval("CompanyName") %>
                                                    <asp:HiddenField ID="hdnfClientID" runat="server" Value='<%# Eval("ClientId") %>' />
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-Width="105" HeaderStyle-Width="105" HeaderStyle-CssClass="Unit-header"
                                    HeaderText="Time">
                                    <ItemTemplate>
                                        <table width="100%" cellpadding="0" cellspacing="0" class="bold">
                                            <tr>
                                                <td class="head-in">
                                                    1 Week
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="head-in">
                                                    3 Month
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="head-in">
                                                    6 Month
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="head-in-bottom">
                                                    1 Year
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-Width="65" HeaderStyle-Width="65" HeaderText="Express Airing To UK"
                                    HeaderStyle-CssClass="Unit-header">
                                    <ItemTemplate>
                                        <table width="100%" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td class="head-in">
                                                    <asp:Label ID="lblExpressAiringToUK_1Week_C47" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="head-in">
                                                    <asp:Label ID="lblExpressAiringToUK_1Month_C47" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="head-in">
                                                    <asp:Label ID="lblExpressAiringToUK_6Month_C47" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="head-in-bottom">
                                                    <asp:Label ID="lblExpressAiringToUK_1Year_C47" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-Width="65" HeaderStyle-Width="65" HeaderText="CIF Air"
                                    HeaderStyle-CssClass="Unit-header">
                                    <ItemTemplate>
                                        <table width="100%" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td class="head-in">
                                                    <asp:Label ID="lblCIFAir_1Week_C47" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="head-in">
                                                    <asp:Label ID="lblCIFAir_1Month_C47" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="head-in">
                                                    <asp:Label ID="lblCIFAir_6Month_C47" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="head-in-bottom">
                                                    <asp:Label ID="lblCIFAir_1Year_C47" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-Width="65" HeaderStyle-Width="65" HeaderText="50% CIF Air"
                                    HeaderStyle-CssClass="Unit-header">
                                    <ItemTemplate>
                                        <table width="100%" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td class="head-in">
                                                    <asp:Label ID="lblFiftyPercentCIFAir_1Week_C47" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="head-in">
                                                    <asp:Label ID="lblFiftyPercentCIFAir_1Month_C47" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="head-in bot-bor">
                                                    <asp:Label ID="lblFiftyPercentCIFAir_6Month_C47" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="head-in-bottom">
                                                    <asp:Label ID="lblFiftyPercentCIFAir_1Year_C47" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-Width="65" HeaderStyle-Width="65" HeaderText="Air To Mumbai"
                                    HeaderStyle-CssClass="Unit-header">
                                    <ItemTemplate>
                                        <table width="100%" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td class="head-in">
                                                    <asp:Label ID="lblAirToMumbai_1Week_C47" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="head-in">
                                                    <asp:Label ID="lblAirToMumbai_1Month_C47" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="head-in bot-bor">
                                                    <asp:Label ID="lblAirToMumbai_6Month_C47" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="head-in-bottom">
                                                    <asp:Label ID="lblAirToMumbai_1Year_C47" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-Width="65" HeaderStyle-Width="65" HeaderText="Inspection Fail & Transport"
                                    HeaderStyle-CssClass="Unit-header">
                                    <ItemTemplate>
                                        <table width="100%" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td class="head-in">
                                                    <asp:Label ID="lblInspectionFailandTransport_1Week_C47" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="head-in">
                                                    <asp:Label ID="lblInspectionFailandTransport_1Month_C47" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="head-in bot-bor">
                                                    <asp:Label ID="lblInspectionFailandTransport_6Month_C47" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="head-in-bottom">
                                                    <asp:Label ID="lblInspectionFailandTransport_1Year_C47" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-Width="65" HeaderStyle-Width="65" HeaderText="Total Penalty"
                                    HeaderStyle-CssClass="Unit-header">
                                    <ItemTemplate>
                                        <table width="100%" cellpadding="0" cellspacing="0" class="total-penal">
                                            <tr>
                                                <td class="head-in">
                                                    <asp:Label ID="lblTotalPenalty_1Week_C47" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="head-in">
                                                    <asp:Label ID="lblTotalPenalty_1Month_C47" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="head-in bot-bor">
                                                    <asp:Label ID="lblTotalPenalty_6Month_C47" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="head-in-bottom">
                                                    <asp:Label ID="lblTotalPenalty_1Year_C47" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-Width="65" HeaderStyle-Width="65" HeaderText="Shipped Value"
                                    HeaderStyle-CssClass="Unit-header">
                                    <ItemTemplate>
                                        <table width="100%" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td class="head-in">
                                                    <asp:Label ID="lblShippedValue_1Week_C47" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="head-in">
                                                    <asp:Label ID="lblShippedValue_1Month_C47" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="head-in bot-bor">
                                                    <asp:Label ID="lblShippedValue_6Month_C47" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="head-in-bottom">
                                                    <asp:Label ID="lblShippedValue_1Year_C47" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-Width="65" HeaderStyle-Width="65" HeaderText="Penalty %Age To shipped value"
                                    HeaderStyle-CssClass="Unit-header">
                                    <ItemTemplate>
                                        <table width="100%" cellpadding="0" cellspacing="0" class="blue">
                                            <tr>
                                                <td class="head-in">
                                                    <asp:Label ID="lblPenaltyPercentAge_1Week_C47" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="head-in">
                                                    <asp:Label ID="lblPenaltyPercentAge_1Month_C47" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="head-in bot-bor">
                                                    <asp:Label ID="lblPenaltyPercentAge_6Month_C47" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="head-in-bottom">
                                                    <asp:Label ID="lblPenaltyPercentAge_1Year_C47" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-Width="170" HeaderStyle-Width="170" HeaderText="CTSL"
                                    HeaderStyle-CssClass="Unit-header">
                                    <ItemTemplate>
                                        <table width="100%" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td class="head-in">
                                                    <asp:Label ID="lblCTSL_1Week_C47" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="head-in">
                                                    <asp:Label ID="lblCTSL_1Month_C47" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="head-in bot-bor">
                                                    <asp:Label ID="lblCTSL_6Month_C47" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="head-in-bottom">
                                                    <asp:Label ID="lblCTSL_1Year_C47" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </td>
        <td valign="top" width="690">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td class="Main-header">
                        C 45-46
                    </td>
                </tr>
                <tr>
                    <td class="comp">
                        Penalty
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:GridView ID="gvPenalty_Matrics_Unit2" runat="server" AutoGenerateColumns="false"
                            Width="100%" ShowFooter="false" ShowHeader="true" RowStyle-HorizontalAlign="Center"
                            HeaderStyle-HorizontalAlign="Center" HeaderStyle-CssClass="top-header" BorderColor="#dbddff"
                            Style="table-layout: fixed; border-collapse: collapse; padding: 0px; margin: 0px;">
                            <Columns>
                                <asp:TemplateField ItemStyle-Width="65" HeaderStyle-Width="65" HeaderText="Express Airing To UK"
                                    HeaderStyle-CssClass="Unit-header">
                                    <ItemTemplate>
                                        <table width="100%" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td class="head-in">
                                                    <asp:HiddenField ID="hdnfClientID" runat="server" Value='<%# Eval("ClientId") %>' />
                                                    <asp:Label ID="lblExpressAiringToUK_1Week_C47" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="head-in">
                                                    <asp:Label ID="lblExpressAiringToUK_1Month_C47" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="head-in">
                                                    <asp:Label ID="lblExpressAiringToUK_6Month_C47" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="head-in-bottom">
                                                    <asp:Label ID="lblExpressAiringToUK_1Year_C47" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-Width="65" HeaderStyle-Width="65" HeaderText="CIF Air"
                                    HeaderStyle-CssClass="Unit-header">
                                    <ItemTemplate>
                                        <table width="100%" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td class="head-in">
                                                    <asp:Label ID="lblCIFAir_1Week_C47" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="head-in">
                                                    <asp:Label ID="lblCIFAir_1Month_C47" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="head-in">
                                                    <asp:Label ID="lblCIFAir_6Month_C47" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="head-in-bottom">
                                                    <asp:Label ID="lblCIFAir_1Year_C47" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-Width="65" HeaderStyle-Width="65" HeaderText="50% CIF Air"
                                    HeaderStyle-CssClass="Unit-header">
                                    <ItemTemplate>
                                        <table width="100%" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td class="head-in">
                                                    <asp:Label ID="lblFiftyPercentCIFAir_1Week_C47" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="head-in">
                                                    <asp:Label ID="lblFiftyPercentCIFAir_1Month_C47" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="head-in bot-bor">
                                                    <asp:Label ID="lblFiftyPercentCIFAir_6Month_C47" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="head-in-bottom">
                                                    <asp:Label ID="lblFiftyPercentCIFAir_1Year_C47" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-Width="65" HeaderStyle-Width="65" HeaderText="Air To Mumbai"
                                    HeaderStyle-CssClass="Unit-header">
                                    <ItemTemplate>
                                        <table width="100%" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td class="head-in">
                                                    <asp:Label ID="lblAirToMumbai_1Week_C47" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="head-in">
                                                    <asp:Label ID="lblAirToMumbai_1Month_C47" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="head-in bot-bor">
                                                    <asp:Label ID="lblAirToMumbai_6Month_C47" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="head-in-bottom">
                                                    <asp:Label ID="lblAirToMumbai_1Year_C47" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-Width="65" HeaderStyle-Width="65" HeaderText="Inspection Fail & Transport"
                                    HeaderStyle-CssClass="Unit-header">
                                    <ItemTemplate>
                                        <table width="100%" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td class="head-in">
                                                    <asp:Label ID="lblInspectionFailandTransport_1Week_C47" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="head-in">
                                                    <asp:Label ID="lblInspectionFailandTransport_1Month_C47" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="head-in bot-bor">
                                                    <asp:Label ID="lblInspectionFailandTransport_6Month_C47" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="head-in-bottom">
                                                    <asp:Label ID="lblInspectionFailandTransport_1Year_C47" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-Width="65" HeaderStyle-Width="65" HeaderText="Total Penalty"
                                    HeaderStyle-CssClass="Unit-header">
                                    <ItemTemplate>
                                        <table width="100%" cellpadding="0" cellspacing="0" class="total-penal">
                                            <tr>
                                                <td class="head-in">
                                                    <asp:Label ID="lblTotalPenalty_1Week_C47" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="head-in">
                                                    <asp:Label ID="lblTotalPenalty_1Month_C47" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="head-in bot-bor">
                                                    <asp:Label ID="lblTotalPenalty_6Month_C47" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="head-in-bottom">
                                                    <asp:Label ID="lblTotalPenalty_1Year_C47" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-Width="65" HeaderStyle-Width="65" HeaderText="Shipped Value"
                                    HeaderStyle-CssClass="Unit-header">
                                    <ItemTemplate>
                                        <table width="100%" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td class="head-in">
                                                    <asp:Label ID="lblShippedValue_1Week_C47" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="head-in">
                                                    <asp:Label ID="lblShippedValue_1Month_C47" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="head-in bot-bor">
                                                    <asp:Label ID="lblShippedValue_6Month_C47" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="head-in-bottom">
                                                    <asp:Label ID="lblShippedValue_1Year_C47" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-Width="65" HeaderStyle-Width="65" HeaderText="Penalty %Age To shipped value"
                                    HeaderStyle-CssClass="Unit-header">
                                    <ItemTemplate>
                                        <table width="100%" cellpadding="0" cellspacing="0" class="blue">
                                            <tr>
                                                <td class="head-in">
                                                    <asp:Label ID="lblPenaltyPercentAge_1Week_C47" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="head-in">
                                                    <asp:Label ID="lblPenaltyPercentAge_1Month_C47" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="head-in bot-bor">
                                                    <asp:Label ID="lblPenaltyPercentAge_6Month_C47" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="head-in-bottom">
                                                    <asp:Label ID="lblPenaltyPercentAge_1Year_C47" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-Width="170" HeaderStyle-Width="170" HeaderText="CTSL"
                                    HeaderStyle-CssClass="Unit-header">
                                    <ItemTemplate>
                                        <table width="100%" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td class="head-in">
                                                    <asp:Label ID="lblCTSL_1Week_C47" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="head-in">
                                                    <asp:Label ID="lblCTSL_1Month_C47" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="head-in bot-bor">
                                                    <asp:Label ID="lblCTSL_6Month_C47" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="head-in-bottom">
                                                    <asp:Label ID="lblCTSL_1Year_C47" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </td>
        <td valign="top" width="690">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td class="Main-header">
                        B 45
                    </td>
                </tr>
                <tr>
                    <td class="comp">
                        Penalty
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:GridView ID="gvPenalty_Matrics_Unit3" runat="server" AutoGenerateColumns="false"
                            Width="100%" ShowFooter="false" ShowHeader="true" RowStyle-HorizontalAlign="Center"
                            HeaderStyle-HorizontalAlign="Center" HeaderStyle-CssClass="top-header" BorderColor="#dbddff"
                            Style="table-layout: fixed; border-collapse: collapse; padding: 0px; margin: 0px;">
                            <Columns>
                                <asp:TemplateField ItemStyle-Width="65" HeaderStyle-Width="65" HeaderText="Express Airing To UK"
                                    HeaderStyle-CssClass="Unit-header">
                                    <ItemTemplate>
                                        <table width="100%" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td class="head-in">
                                                    <asp:HiddenField ID="hdnfClientID" runat="server" Value='<%# Eval("ClientId") %>' />
                                                    <asp:Label ID="lblExpressAiringToUK_1Week_C47" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="head-in">
                                                    <asp:Label ID="lblExpressAiringToUK_1Month_C47" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="head-in">
                                                    <asp:Label ID="lblExpressAiringToUK_6Month_C47" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="head-in-bottom">
                                                    <asp:Label ID="lblExpressAiringToUK_1Year_C47" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-Width="65" HeaderStyle-Width="65" HeaderText="CIF Air"
                                    HeaderStyle-CssClass="Unit-header">
                                    <ItemTemplate>
                                        <table width="100%" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td class="head-in">
                                                    <asp:Label ID="lblCIFAir_1Week_C47" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="head-in">
                                                    <asp:Label ID="lblCIFAir_1Month_C47" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="head-in">
                                                    <asp:Label ID="lblCIFAir_6Month_C47" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="head-in-bottom">
                                                    <asp:Label ID="lblCIFAir_1Year_C47" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-Width="65" HeaderStyle-Width="65" HeaderText="50% CIF Air"
                                    HeaderStyle-CssClass="Unit-header">
                                    <ItemTemplate>
                                        <table width="100%" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td class="head-in">
                                                    <asp:Label ID="lblFiftyPercentCIFAir_1Week_C47" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="head-in">
                                                    <asp:Label ID="lblFiftyPercentCIFAir_1Month_C47" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="head-in bot-bor">
                                                    <asp:Label ID="lblFiftyPercentCIFAir_6Month_C47" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="head-in-bottom">
                                                    <asp:Label ID="lblFiftyPercentCIFAir_1Year_C47" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-Width="65" HeaderStyle-Width="65" HeaderText="Air To Mumbai"
                                    HeaderStyle-CssClass="Unit-header">
                                    <ItemTemplate>
                                        <table width="100%" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td class="head-in">
                                                    <asp:Label ID="lblAirToMumbai_1Week_C47" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="head-in">
                                                    <asp:Label ID="lblAirToMumbai_1Month_C47" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="head-in bot-bor">
                                                    <asp:Label ID="lblAirToMumbai_6Month_C47" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="head-in-bottom">
                                                    <asp:Label ID="lblAirToMumbai_1Year_C47" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-Width="65" HeaderStyle-Width="65" HeaderText="Inspection Fail & Transport"
                                    HeaderStyle-CssClass="Unit-header">
                                    <ItemTemplate>
                                        <table width="100%" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td class="head-in">
                                                    <asp:Label ID="lblInspectionFailandTransport_1Week_C47" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="head-in">
                                                    <asp:Label ID="lblInspectionFailandTransport_1Month_C47" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="head-in bot-bor">
                                                    <asp:Label ID="lblInspectionFailandTransport_6Month_C47" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="head-in-bottom">
                                                    <asp:Label ID="lblInspectionFailandTransport_1Year_C47" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-Width="65" HeaderStyle-Width="65" HeaderText="Total Penalty"
                                    HeaderStyle-CssClass="Unit-header">
                                    <ItemTemplate>
                                        <table width="100%" cellpadding="0" cellspacing="0" class="total-penal">
                                            <tr>
                                                <td class="head-in">
                                                    <asp:Label ID="lblTotalPenalty_1Week_C47" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="head-in">
                                                    <asp:Label ID="lblTotalPenalty_1Month_C47" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="head-in bot-bor">
                                                    <asp:Label ID="lblTotalPenalty_6Month_C47" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="head-in-bottom">
                                                    <asp:Label ID="lblTotalPenalty_1Year_C47" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-Width="65" HeaderStyle-Width="65" HeaderText="Shipped Value"
                                    HeaderStyle-CssClass="Unit-header">
                                    <ItemTemplate>
                                        <table width="100%" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td class="head-in">
                                                    <asp:Label ID="lblShippedValue_1Week_C47" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="head-in">
                                                    <asp:Label ID="lblShippedValue_1Month_C47" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="head-in bot-bor">
                                                    <asp:Label ID="lblShippedValue_6Month_C47" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="head-in-bottom">
                                                    <asp:Label ID="lblShippedValue_1Year_C47" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-Width="65" HeaderStyle-Width="65" HeaderText="Penalty %Age To shipped value"
                                    HeaderStyle-CssClass="Unit-header">
                                    <ItemTemplate>
                                        <table width="100%" cellpadding="0" cellspacing="0" class="blue">
                                            <tr>
                                                <td class="head-in">
                                                    <asp:Label ID="lblPenaltyPercentAge_1Week_C47" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="head-in">
                                                    <asp:Label ID="lblPenaltyPercentAge_1Month_C47" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="head-in bot-bor">
                                                    <asp:Label ID="lblPenaltyPercentAge_6Month_C47" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="head-in-bottom">
                                                    <asp:Label ID="lblPenaltyPercentAge_1Year_C47" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-Width="170" HeaderStyle-Width="170" HeaderText="CTSL"
                                    HeaderStyle-CssClass="Unit-header">
                                    <ItemTemplate>
                                        <table width="100%" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td class="head-in">
                                                    <asp:Label ID="lblCTSL_1Week_C47" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="head-in">
                                                    <asp:Label ID="lblCTSL_1Month_C47" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="head-in bot-bor">
                                                    <asp:Label ID="lblCTSL_6Month_C47" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="head-in-bottom">
                                                    <asp:Label ID="lblCTSL_1Year_C47" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </td>
        <td valign="top" width="690">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td class="Main-header">
                        BIPL
                    </td>
                </tr>
                <tr>
                    <td class="comp">
                        Penalty
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:GridView ID="gvPenalty_Matrics_BIPL" runat="server" AutoGenerateColumns="false"
                            Width="100%" ShowFooter="false" ShowHeader="true" RowStyle-HorizontalAlign="Center"
                            HeaderStyle-HorizontalAlign="Center" HeaderStyle-CssClass="top-header" BorderColor="#dbddff"
                            Style="table-layout: fixed; border-collapse: collapse; padding: 0px; margin: 0px;">
                            <Columns>
                                <asp:TemplateField ItemStyle-Width="65" HeaderStyle-Width="65" HeaderText="Express Airing To UK"
                                    HeaderStyle-CssClass="Unit-header">
                                    <ItemTemplate>
                                        <table width="100%" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td class="head-in">
                                                    <asp:HiddenField ID="hdnfClientID" runat="server" Value='<%# Eval("ClientId") %>' />
                                                    <asp:Label ID="lblExpressAiringToUK_1Week_C47" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="head-in">
                                                    <asp:Label ID="lblExpressAiringToUK_1Month_C47" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="head-in">
                                                    <asp:Label ID="lblExpressAiringToUK_6Month_C47" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="head-in-bottom">
                                                    <asp:Label ID="lblExpressAiringToUK_1Year_C47" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-Width="65" HeaderStyle-Width="65" HeaderText="CIF Air"
                                    HeaderStyle-CssClass="Unit-header">
                                    <ItemTemplate>
                                        <table width="100%" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td class="head-in">
                                                    <asp:Label ID="lblCIFAir_1Week_C47" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="head-in">
                                                    <asp:Label ID="lblCIFAir_1Month_C47" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="head-in">
                                                    <asp:Label ID="lblCIFAir_6Month_C47" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="head-in-bottom">
                                                    <asp:Label ID="lblCIFAir_1Year_C47" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-Width="65" HeaderStyle-Width="65" HeaderText="50% CIF Air"
                                    HeaderStyle-CssClass="Unit-header">
                                    <ItemTemplate>
                                        <table width="100%" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td class="head-in">
                                                    <asp:Label ID="lblFiftyPercentCIFAir_1Week_C47" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="head-in">
                                                    <asp:Label ID="lblFiftyPercentCIFAir_1Month_C47" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="head-in bot-bor">
                                                    <asp:Label ID="lblFiftyPercentCIFAir_6Month_C47" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="head-in-bottom">
                                                    <asp:Label ID="lblFiftyPercentCIFAir_1Year_C47" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-Width="65" HeaderStyle-Width="65" HeaderText="Air To Mumbai"
                                    HeaderStyle-CssClass="Unit-header">
                                    <ItemTemplate>
                                        <table width="100%" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td class="head-in">
                                                    <asp:Label ID="lblAirToMumbai_1Week_C47" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="head-in">
                                                    <asp:Label ID="lblAirToMumbai_1Month_C47" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="head-in bot-bor">
                                                    <asp:Label ID="lblAirToMumbai_6Month_C47" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="head-in-bottom">
                                                    <asp:Label ID="lblAirToMumbai_1Year_C47" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-Width="65" HeaderStyle-Width="65" HeaderText="Inspection Fail & Transport"
                                    HeaderStyle-CssClass="Unit-header">
                                    <ItemTemplate>
                                        <table width="100%" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td class="head-in">
                                                    <asp:Label ID="lblInspectionFailandTransport_1Week_C47" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="head-in">
                                                    <asp:Label ID="lblInspectionFailandTransport_1Month_C47" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="head-in bot-bor">
                                                    <asp:Label ID="lblInspectionFailandTransport_6Month_C47" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="head-in-bottom">
                                                    <asp:Label ID="lblInspectionFailandTransport_1Year_C47" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-Width="65" HeaderStyle-Width="65" HeaderText="Total Penalty"
                                    HeaderStyle-CssClass="Unit-header">
                                    <ItemTemplate>
                                        <table width="100%" cellpadding="0" cellspacing="0" class="total-penal">
                                            <tr>
                                                <td class="head-in">
                                                    <asp:Label ID="lblTotalPenalty_1Week_C47" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="head-in">
                                                    <asp:Label ID="lblTotalPenalty_1Month_C47" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="head-in bot-bor">
                                                    <asp:Label ID="lblTotalPenalty_6Month_C47" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="head-in-bottom">
                                                    <asp:Label ID="lblTotalPenalty_1Year_C47" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-Width="65" HeaderStyle-Width="65" HeaderText="Shipped Value"
                                    HeaderStyle-CssClass="Unit-header">
                                    <ItemTemplate>
                                        <table width="100%" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td class="head-in">
                                                    <asp:Label ID="lblShippedValue_1Week_C47" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="head-in">
                                                    <asp:Label ID="lblShippedValue_1Month_C47" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="head-in bot-bor">
                                                    <asp:Label ID="lblShippedValue_6Month_C47" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="head-in-bottom">
                                                    <asp:Label ID="lblShippedValue_1Year_C47" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-Width="65" HeaderStyle-Width="65" HeaderText="Penalty %Age To shipped value"
                                    HeaderStyle-CssClass="Unit-header">
                                    <ItemTemplate>
                                        <table width="100%" cellpadding="0" cellspacing="0" class="blue">
                                            <tr>
                                                <td class="head-in">
                                                    <asp:Label ID="lblPenaltyPercentAge_1Week_C47" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="head-in">
                                                    <asp:Label ID="lblPenaltyPercentAge_1Month_C47" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="head-in bot-bor">
                                                    <asp:Label ID="lblPenaltyPercentAge_6Month_C47" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="head-in-bottom">
                                                    <asp:Label ID="lblPenaltyPercentAge_1Year_C47" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-Width="170" HeaderStyle-Width="170" HeaderText="CTSL"
                                    HeaderStyle-CssClass="Unit-header">
                                    <ItemTemplate>
                                        <table width="100%" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td class="head-in">
                                                    <asp:Label ID="lblCTSL_1Week_C47" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="head-in">
                                                    <asp:Label ID="lblCTSL_1Month_C47" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="head-in bot-bor">
                                                    <asp:Label ID="lblCTSL_6Month_C47" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="head-in-bottom">
                                                    <asp:Label ID="lblCTSL_1Year_C47" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
