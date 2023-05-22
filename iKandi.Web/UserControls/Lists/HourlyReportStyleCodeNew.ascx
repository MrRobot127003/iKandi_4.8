<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HourlyReportStyleCodeNew.ascx.cs" Inherits="iKandi.Web.UserControls.Lists.HourlyReportStyleCodeNew" %>
<style type="text/css">
    body {
        background: #f9f9fa;
        font-family: sans-serif,arial,verdana;
        margin: 0px;
        padding: 0px;
    }
    .item_list th {
        font-weight: bold;
        background: #dddfe4;
        color: #575759;
        font-family: verdana;
        font-size: 9px;
    }
    .item_list_Report th {
        font-size: 10px;
        font-family: arial, halvetica;
        background: #dddfe4;
        color: #575759;
        font-weight: normal;
        border-color: #999999;
    }
    .blue {
        font-weight: bold;
        color: #3a5695;
        text-align: center;
    }
    .ROWMERGE table tr td {
        border-bottom: 0px !important;
    }
    .stic {
        color: #5610c7;
        font-weight: normal;
    }
    .WIPRed {
        color: red !important;
        font-weight: bold !important;
        height: 14px;
    }
    .WIPGreen {
        color: green !important;
        height: 14px;
    }
    .stic1 {
        color: red;
        font-weight: normal;
    }
    .blue-per {
        color: blue;
    }
    .slot {
        text-align: center !important;
        vertical-align: middle;
        border-collapse: collapse;
    }
    .slot-height td {
        height: 40px !important;
    }
    .slot td {
        text-align: center !important;
        vertical-align: middle;
        border: 1px solid #bfbfbf;
    }
    .SlotFinish {
        text-align: center !important;
        vertical-align: middle;
    }
    
    .SlotFinish span {
        font-weight: bold;
        font-size: 12px;
        color: #fff;
    }
    .item_list_Report th {
        padding: 0px;
        text-transform: capitalize;
    }
    
    .item_list_Report th table td {
        font-size: 9px;
        background: #dddfe4;
        color: #575759;
        font-weight: normal;
        text-transform: capitalize !important;
        border-color: #999999;
    }
    .item_list_Report {
        background: #fff;
    }
    .bol td {
        color: #3a5695;
        font-weight: normal;
        text-align: center !important;
        padding: 5px;
    }
    .bol .bol {
        text-align: center !important;
        font-size: 12px !important;
    }
    .bol td b {
        font-size: 11px !important;
        text-transform: uppercase !important;
    }
    .item_list_Report td {
        font-size: 8px !important;
        text-align: left;
        padding: 0px !important;
        color: Gray;
    }
    
    
    .item_list_Report td table.slot td {
        border: 1px solid #bfbfbf;
    }
    .item_list_Report td span {
        text-align: center;
    }
    .item_list_Report th table td {
        text-align: center;
    }
    .TGT {
        border-bottom: 1px solid #000;
    }
    
    .TGT th {
        height: 19px;
    }
    .TGT td {
        background: none;
        border: 1px solid #bfbfbf;
    }
    h1, h2, h3, h4, h5, h6 {
        margin: 5px 0px;
        padding: 0px;
    }
    
    .check_box_text {
        text-align: center !important;
    }
    
    .fact-name {
        background: #3a5695;
        color: #fff;
        text-align: center;
        font-family: arial;
        font-size: 16px;
        padding: 2px 0px;
    }
    .main-table-width h2 {
        min-width: 1000px;
    }
    .empty-msg {
        font-family: Helvetica;
        font-size: 12px !important;
        line-height: 24px;
        text-transform: capitalize;
        border: 1px solid #ccc;
        padding: 0px 10px;
    }
    
    .repeat-div div {
        border-bottom: 1px solid #ccc;
        padding: 2px;
    }
    .repeat-div div:last-child {
        border-bottom: 0px;
    }
    .gray {
        color: Gray;
    }
    .yellow {
        color: Yellow !important;
        font-weight: bold;
        height: 20px;
        text-align: center;
    }
    .yellow span {
        font-size: 10px !important;
    }
    .yellow span:first-child {
        font-size: 11px !important;
    }
    .yellowFactory .yellow {
        background: #fff;
        font-weight: normal;
        height: 20px;
        text-align: center;
    }
    .yellowFactory .yellow span {
        font-size: 11px !important;
    }
    
    .yellowfooter {
        color: Yellow !important;
        font-weight: normal !important;
        height: 20px;
        text-align: center;
    }
    .yellowfooter span {
        font-size: 10px !important;
    }
    
    .yellowfooter span:first-child {
        font-size: 11px !important;
    }
    .yellow-pass {
        color: Yellow !important;
        font-weight: normal;
        height: 20px;
        text-align: center;
    }
    .yellow-pass span {
        font-size: 14px !important;
    }
    .bol {
        vertical-align: top;
    }
    .line_td td {
        border: 1px solid #bfbfbf;
        text-align: center !important;
        vertical-align: middle;
    }
    .line_td {
        border-collapse: collapse;
    }
    .bol .line_td td {
        border: none;
    }
    .bol-new {
        border-right-color: #ffffff !important;
    }
    .bol-new {
        border-right-color: #ffffff !important;
    }
    .show-table {
        /* display:inline-table;*
}
.hide-table
{
  /*  display:none;max-height:0; mso-hide:all; overflow:hidden; font-size:0; line-height: 0*/
    }
    .actObGreen {
        color: green;
    }
    .actObRed {
        color: red;
    }
    
    .ClassObStGreen {
        color: green;
        font-weight: bold;
    }
    .ClassObStRed {
        color: red;
        font-weight: bold;
    }
    
    .AgrdOBBlack {
        color: Black;
    }
    .AgrdOBBlue {
        color: Blue;
    }
    .wipstitched {
        height: 14px;
    }
    .gray-light span {
        color: Gray !important;
    }
    .wipstitched span span {
        color: Gray !important;
    }
    .wipf {
        height: 14px;
    }
    .wipf span span {
        color: Gray !important;
    }
    .yellowFactory .today-stitch {
        font-weight: normal;
    }
    .disp-none {
        display: none;
    }
    .align-center {
        text-align: center !important;
    }
    .StitchPendingQty {
        text-transform: lowercase;
        text-align: center !important;
        color: Black !important; /*font-weight:bold !important;*/
        font-size: 8px !improtant;
        border-color: Gray;
    }
    .EstDateLessExFactory {
        text-transform: lowercase;
        text-align: center !important;
        font-weight: normal !important;
        font-size: 8px !improtant;
        color: Green !important;
        border-color: Gray;
    }
    .EstDateGreaterExFactory {
        text-transform: lowercase;
        text-align: center !important;
        font-weight: normal !important;
        font-size: 8px !improtant;
        color: Red !important;
        border-color: Gray;
    }
    /* Created New for pending stitch */
    .EstDateLessExFactoryRowindex1 {
        text-transform: lowercase;
        text-align: center !important;
        font-weight: Bold !important;
        font-size: 8px !improtant;
        color: Green !important;
        border-color: Gray;
    }
    .EstDateGreaterExFactoryRowindex1 {
        text-transform: lowercase;
        text-align: center !important;
        font-weight: Bold !important;
        font-size: 8px !improtant;
        color: Red !important;
        border-color: Gray;
    }
    
    .EstHours {
        text-transform: lowercase;
        text-align: center !important;
        color: Gray !important;
        font-weight: normal !important;
        font-size: 8px !improtant;
        border-color: Gray;
    }
    .Achievement {
        color: Black !important;
        font-size: 10px !important;
    }
    .item_list_Report td span span b {
        font-size: 11px;
    }
    .bgred {
        background: red !important;
        text-align: center !important;
    }
    .bggreen {
        background: green !important;
        text-align: center !important;
    }
    .bgorange {
        background: orange !important;
        text-align: center !important;
    }
    .timetable th {
        color: #575759;
        background-color: #DDDFE4;
        border-color: #999999;
        font-family: arial;
        font-size: 7px;
        font-weight: normal;
    }
    .timetable td {
        color: Gray;
        font-size: 7px;
        font-weight: bold;
    }
    .font-normal {
        font-weight: normal !important;
    }
    .today-stitch {
        font-size: 11px;
        font-weight: bold;
    }
    .TodayAchieved {
        font-size: 11px;
        font-weight: bold;
    }
    table.namebor td:last-child {
        border-right: 1px solid #999999;
    }
    .WIPRedBack {
        background-color: Red;
    }
    .WIPGreenBack {
        background-color: Green;
    }
    
    .lblLinehover {
        border: 1px solid #999999;
        background: yellow;
        width: 10px !important;
        height: 10px;
        border-radius: 50%;
        position: relative;
    }
    lblLinehover .tooltiptextLine {
        visibility: hidden;
        width: 250px;
        background-color: yellow;
        color: red;
        text-align: center;
        border-radius: 6px;
        padding: 5px 5px;
        position: absolute;
        z-index: 1;
        bottom: 101%;
        left: 0%;
        margin-left: -120px;
        border: 1px solid black;
        transition: opacity 0.3s;
        margin-top: 0px;
        height: 4px;
        line-height: 5px;
        margin-top: -10px;
    }
    
    /*Tooltip Css*/
    [data-title] {
        position: relative;
        font-weight: normal;
    }
    
    [data-title]:hover::before {
        content: attr(data-title);
        position: absolute;
        bottom: -26px;
        display: inline-block;
        padding: 3px 6px;
        border-radius: 2px;
        background: #000;
        color: #fff;
        font-size: 10px;
        right: 0;
        font-family: sans-serif;
        white-space: nowrap;
        font-weight: normal;
        opacity: .8;
    }
    [data-title]:hover::after {
        content: '';
        position: absolute;
        bottom: -10px;
        left: 0;
        display: inline-block;
        color: #fff;
        border: 8px solid transparent;
        border-bottom: 8px solid #000;
        opacity: .8;
    }
    
    .Cmttooltip {
        position: relative;
        display: inline-block;
    }
    .Cmttooltip .tooltiptext {
        bottom: 88px;
        visibility: hidden;
        width: 120px;
        background-color: yellow;
        color: red;
        text-align: center;
        border-radius: 6px;
        padding: 0px 0px;
        position: absolute;
        z-index: 1;
        right: -2px;
        left: -33px;
        transition: opacity 0.3s;
        height: 100%;
        line-height: 5px;
        margin-left: 3px;
    }
    
    .Cmttooltip .tooltiptext::after {
        content: "";
        position: absolute;
        right: 60%;
        border-width: 7px;
        border-style: solid;
        border-color: #a2a3a7 transparent transparent transparent;
    }
    .Cmttooltip:hover .tooltiptext {
        visibility: visible;
        opacity: 1;
    }
    
    .Cmttooltip .cmtTable th {
        padding: 5px 5px !important;
        font-size: 11px !important;
        font-weight: 600;
        background: #a2a3a7 !important;
        color: #fff !important;
        border-collapse: collapse;
    }
    .Cmttooltip .cmtTable td {
        padding: 5px 5px !important;
        background: #f5f5f5 !important;
        font-size: 10px !important;
        text-align: right !important;
        color: gray !important;
        border-top: 0px !important;
        border-collapse: collapse;
        min-width: 40px;
    }
    .Cmttooltip .cmtTable td:nth-child(2) {
        color: #000 !important;
        font-weight: 600;
        background: #f5f5f5 !important;
        border-left: 0px;
        text-align: right;
    }
    .Cmttooltip .cmtTable2 td {
        padding: 5px 5px !important;
        background: #f5f5f5 !important;
        font-size: 10px !important;
        text-align: right !important;
        border: 1px solid #999;
        color: gray !important;
        border-top: 0px !important;
        border-collapse: collapse;
        min-width: 40px;
    }
    .Cmttooltip .cmtTable2 td:nth-child(2) {
        color: #000 !important;
        font-weight: 600;
        background: #f5f5f5 !important;
        text-align: right;
        border-left: 0px;
    }
    .Cmttooltip .cmtTable2 th {
        padding: 5px 5px !important;
        font-size: 11px !important;
        font-weight: 600;
        background: #a2a3a7 !important;
        color: #fff !important;
        border-collapse: collapse;
    }
    cmtTable2 {
        border: 1px solid #999;
        border-collapse: collapse;
    }
    cmtTable {
        border: 1px solid #999;
        border-collapse: collapse;
    }
    .cmtTable td b {
        text-transform: capitalize !important;
    }
</style>
<table cellpadding="0" cellspacing="0" width="100%" style="display: inline-block;">
    <tr>
        <td style="width: 100%;">
            <table style="display: inline-block; width: 100%;" class="main-table-width">
                <tr>
                    <td>
                        <asp:GridView ID="gvHourlyStitchingReport" RowStyle-Font-Size="9px" HeaderStyle-Font-Bold="false" HeaderStyle-Font-Size="10px" ShowHeader="true" ShowFooter="true" AutoGenerateColumns="false" runat="server" OnRowDataBound="gvHourlyStitchingReport_RowDataBound" CssClass="item_list_Report" Style="margin-top: 10px; display: inline-block;" OnDataBound="gvHourlyStitchingReport_DataBound">
                            <Columns>
                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="80" ItemStyle-Font-Bold="true" ItemStyle-ForeColor="gray" ItemStyle-VerticalAlign="Middle">
                                    <HeaderTemplate>
                                        Unit
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <h3 style="font-size: 12px; padding: 0px; margin: 0px; text-align: center;">
                                            <asp:Label ID="lblUnit" runat="server" Text='<%#Eval("FactoryName") %>'></asp:Label>
                                            <asp:Label ID="lblUnitTotal" runat="server" Text=""></asp:Label>
                                            <img id="imgStyle" runat="server" style="height: 60px !important; width: 60px !important;" />
                                            <asp:HiddenField runat="server" ID="hdnImgStyle" Value='<%#Eval("StyleImgPath")%>' />
                                        </h3>
                                        <asp:HiddenField ID="hdnEmptyMsg" Value='<%#Eval("EmptyMsg") %>' runat="server" />
                                        <asp:HiddenField ID="hdnserialColorCode" runat="server" Value='<%#Eval("ClientColorCode")%>' />
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <h3 class="slot" style="font-size: 12px; padding: 0px; margin: 0px; text-align: center;">
                                            BIPL Total</h3>
                                    </FooterTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="95" HeaderStyle-Width="95" ItemStyle-HorizontalAlign="Left" Visible="false">
                                    <HeaderTemplate>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                    </ItemTemplate>
                                    <ItemStyle VerticalAlign="Top" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="220" HeaderStyle-Width="220" ItemStyle-HorizontalAlign="Left">
                                    <HeaderTemplate>
                                        <table frame="void" rules="all" class="line_td" width="100%" cellspacing="0" cellpadding="0" border="0">
                                            <tbody>
                                                <tr>
                                                    <td style="height: 15px;">
                                                        Serial No | Style No | Dept. Name
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 15px;">
                                                        Line (Day)COT | B E Pcs | St. Tgt. Eff | St. Tgt. Pcs
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 15px;">
                                                        St. SAM | Act OB (Agrd/POB) | PCpty | Fn. Act OB (Press OB)
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 15px;">
                                                        H S Name | CWIP Pcs | SWIP Pcs | FWIP Pcs
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:HiddenField ID="hdnLineNo" Value='<%#Eval("Line_No") %>' runat="server" />
                                        <asp:HiddenField ID="hdnUnitId" Value='<%#Eval("UnitID") %>' runat="server" />
                                        <table id="tblEffHide" runat="server" cellpadding="0" cellspacing="0" width="100%" rules="ALL" frame="VOID" border="0">
                                            <tr>
                                                <td>
                                                    <table id="tblEmptyMsg" visible="false" runat="server" cellpadding="0" cellspacing="0" width="100%" border="0" rules="ALL" frame="VOID" class="line_td">
                                                        <tr>
                                                            <td style="color: Red; padding: 10px !important; text-align: center; font-size: 14px !important;">
                                                                <asp:Label ID="lblEmptyMsg" runat="server" Text='<%#Eval("EmptyMsg")%>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <table frame="void" rules="all" width="100%" cellspacing="0" cellpadding="0">
                                                        <tbody>
                                                            <tr>
                                                                <td style="width: 20%; text-align: center; height: 20px;" runat="server" id="tdserialno">
                                                                    <font color="black"><b>
                                                                        <%#Eval("SerialNumber")%>
                                                                    </b></font>
                                                                </td>
                                                                <td style="text-align: center; width: 30%; text-align: center; height: 20px;">
                                                                    <font color="black">
                                                                        <%#Eval("StyleCode")%>
                                                                    </font>
                                                                </td>
                                                                <td style="width: 50%; text-align: center; height: 20px;">
                                                                    <font color="Blue">
                                                                        <%#Eval("Client_DepartName")%>
                                                                    </font>
                                                                </td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <table width="100%" cellspacing="0" cellpadding="0" border="0">
                                                        <tbody>
                                                            <tr>
                                                                <td style="width: 25%; border-right: 1px solid #bfbfbf; height: 14px; text-align: center;">
                                                                    <asp:Label ID="lblLineNumber" Font-Bold="true" ForeColor="Black" runat="server" Text='<%#Eval("LineNumber")%>'></asp:Label>
                                                                    <asp:Label ID="lblProdDay" runat="server" ForeColor="Blue" Text='<%#Eval("ProdDay")%>'></asp:Label>
                                                                    <asp:Label ID="lblCOT" runat="server" Text="" ForeColor="gray"></asp:Label>
                                                                </td>
                                                                <td style="border-right: 1px solid #bfbfbf; height: 15px; text-align: center; width: 30%">
                                                                    <asp:Label ID="lblBreakEvenQty" CssClass="gray" Font-Bold="true" runat="server" Text=""></asp:Label>
                                                                </td>
                                                                <td style="border-right: 1px solid #bfbfbf; height: 15px; text-align: center; width: 20%;">
                                                                    <asp:Label ID="lblTargetEff" runat="server" ForeColor="Black" Font-Bold="true" Style="font-size: 11px !important" Text=""></asp:Label>
                                                                </td>
                                                                <td id="tdTargetQty" runat="server" style="border-right: 1px solid #bfbfbf; height: 15px; text-align: center; width: 25%;">
                                                                    <asp:Label ID="lblTargetQty" runat="server" Text="" Style="color: Black; font-size: 11px;"></asp:Label>
                                                                </td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: center; height: 15px; border-bottom: 1px solid #bfbfbf;">
                                                    <table width="100%" cellspacing="0" cellpadding="0" border="0">
                                                        <tbody>
                                                            <tr>
                                                                <td style="width: 25%; border-right: 1px solid #bfbfbf; height: 15px; text-align: center;">
                                                                    <asp:Label ID="lblStchSAM" Font-Bold="true" ForeColor="Black" runat="server" Text=""></asp:Label>
                                                                </td>
                                                                <td style="border-right: 1px solid #bfbfbf; width: 25%; height: 15px; text-align: center;">
                                                                    <asp:Label ID="lblStchActOB" runat="server" Font-Bold="true" Text=""></asp:Label>
                                                                    <asp:Label ID="lblStchAgreedOB" runat="server" Text=""></asp:Label>
                                                                </td>
                                                                <td style="width: 25%; height: 15px; text-align: center; border-right: 1px solid #bfbfbf;">
                                                                    <asp:Label ID="lblStchPkCpty" runat="server" Text=""></asp:Label>
                                                                    <asp:Label ID="lblStchPkEff" ForeColor="Gray" runat="server" Text="" Visible="false"></asp:Label>
                                                                </td>
                                                                <td style="width: 25%; height: 15px; text-align: center;">
                                                                    <asp:Label ID="lblFinActOB" runat="server" Font-Bold="true" Text=""></asp:Label>&nbsp;
                                                                    <%-- <asp:Label ID="lblFinAgreedOB" runat="server"  Text=""></asp:Label>--%>
                                                                    <asp:Label ID="lblFinPressActualOB" runat="server" ForeColor="Black" Font-Bold="true" Text=""></asp:Label>
                                                                </td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: center;">
                                                    <table width="100%" cellspacing="0" cellpadding="0" border="0">
                                                        <tbody>
                                                            <tr>
                                                                <td style="width: 25%; border-right: 1px solid #bfbfbf; height: 15px; text-align: center;">
                                                                    <font color="black"><b>
                                                                        <%#Eval("OperationName")%>
                                                                    </b></font>
                                                                </td>
                                                                <td style="width: 25%; border-right: 1px solid #bfbfbf; height: 15px; text-align: center;">
                                                                    <asp:Label ID="lblwipCutPcs" ForeColor="Black" Text="" runat="server"></asp:Label>
                                                                </td>
                                                                <td id="tdWIPStiched" runat="server" style="width: 25%; border-right: 1px solid #bfbfbf; height: 15px; text-align: center;">
                                                                    <asp:Label ID="lblWIPStichedPcs" ForeColor="Yellow" Font-Size="11px" Text="" runat="server"></asp:Label>
                                                                </td>
                                                                <td style="width: 25%; height: 15px; text-align: center;">
                                                                    <asp:Label ID="lblWIPFinishedPcs" ForeColor="Black" Text="" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr style="display: none;">
                                                <td style="text-align: center; border-bottom: 1px solid #bfbfbf; height: 15px">
                                                    <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                        <%-- <td style="width:50%; border-right:1px solid #bfbfbf;height:15px;text-align:center;">--%>
                                                        <td style="height: 15px; text-align: center;">
                                                        </td>
                                                        <td style="width: 50%; height: 15px; text-align: center; display: none;" runat="server" id="tdFncpty">
                                                            <asp:Label ID="lblFinPkCpty" runat="server" Text=""></asp:Label>
                                                        </td>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                        <table id="tblEffShow" runat="server" cellpadding="0" cellspacing="0" width="100%" rules="ALL" frame="VOID" border="0" class="line_td">
                                            <tr>
                                                <td style="font-size: 12px; padding: 0px; margin: 0px; height: 20px; text-align: center;">
                                                    <h3 style="font-weight: normal; font-size: 12px; padding: 0px; margin: 0px;">
                                                        <asp:Label ID="lblEfficiency" runat="server" Text=""> </asp:Label></h3>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="font-size: 12px; padding: 0px; margin: 0px; height: 20px; text-align: center;">
                                                    <h3 style="font-weight: normal; font-size: 12px; padding: 0px; margin: 0px;">
                                                        <asp:Label ID="lblAchievement" runat="server" Text=""> </asp:Label></h3>
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                    <ItemStyle VerticalAlign="Top" />
                                    <FooterTemplate>
                                        <div id="dvFooter" runat="server">
                                        </div>
                                    </FooterTemplate>
                                    <FooterStyle CssClass="bol bol-new" />
                                </asp:TemplateField>
                                <%--     <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top"
                                    ItemStyle-Width="75" HeaderStyle-Width="75" ItemStyle-HorizontalAlign="Left" Visible="false">
                                    <HeaderTemplate>--%>
                                <%--Hourly Target--%>
                                <%-- St. Tgt. 
                                        <br />
                                        Break Even
                                    </HeaderTemplate>
                                    
                                    <ItemTemplate>
                                    <table rules="ALL" frame="VOID" width="100%" cellpadding="0" cellspacing="0">
                                    <tr>
                                    <td  align="center" style="width: 40%; height:15px; border-right:1px solid #bfbfbf; text-align:center;border-bottom:1px solid #bfbfbf;">
                                     </td>
                                    <td   align="center" style="width: 60%; text-align:center;border-bottom:1px solid #bfbfbf;">
                                        
                                      </td>
                                      </tr>                                     
                                        <tr><td style="text-align:center;  border-right:1px solid #bfbfbf;">
                                        
                                         </td>
                                  <td style="text-align:center;">
                                       </td></tr>
                                        
                                    </table>                                     
                                    </ItemTemplate>
                                     <FooterTemplate>
                                                                    
                                    </FooterTemplate>
                                    <FooterStyle CssClass="bol" />
                                </asp:TemplateField>--%>
                                <%-- Slot 1--%>
                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="35" HeaderStyle-Width="35" ItemStyle-HorizontalAlign="Left">
                                    <HeaderTemplate>
                                        <table width="100%" class="slot" border="0" rules="ALL" frame="VOID">
                                            <tr>
                                                <td align="center">
                                                    Slot 1<font color="red">*</font>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" style="width: 45px;">
                                                    St. Qty
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" style="width: 45px;">
                                                    DHU
                                                </td>
                                            </tr>
                                        </table>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <table id="tbl1" runat="server" width="100%" class="slot" rules="ALL" frame="VOID">
                                            <tr>
                                                <td id="tdSlot1Pass" runat="server" align="center" class="yellow">
                                                    <asp:Label ID="lblSlot1Pass" runat="server" Text='<%#Eval("Slot1Pass") %>'></asp:Label>
                                                </td>
                                            </tr>
                                            <tr id="tr1" runat="server">
                                                <td style="height: 27px; vertical-align: middle;" align="center" id="td1Dhu" runat="server">
                                                    <span class="gray">
                                                        <asp:Label ID="lblSlot1DHU" runat="server" Text='<%#Eval("Slot1DHU") %>'></asp:Label>
                                                    </span>
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <table width="100%" class="slot" rules="ALL" frame="VOID">
                                            <tr>
                                                <td id="tdSlot1PassTotal" runat="server" align="center" style="height: 23px" class="yellowfooter">
                                                    <asp:Label ID="lblSlot1PassTotal" Font-Bold="true" runat="server" Text=""></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="height: 59px; vertical-align: middle;" align="center">
                                                    <span class="gray">
                                                        <asp:Label ID="lblSlot1DHUTotal" runat="server" Text=""></asp:Label>
                                                    </span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="height: 20px; vertical-align: middle;" align="center">
                                                    <b>
                                                        <asp:Label ID="lbl1StitchEff_Foo" runat="server" Text=""></asp:Label>
                                                    </b>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="height: 20px; vertical-align: middle;" align="center" id="td1Achieved_Foo" runat="server">
                                                    <b>
                                                        <asp:Label ID="lbl1Achieved_Foo" runat="server" Text=""></asp:Label>
                                                    </b>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="height: 20px; color: Black; vertical-align: middle;" align="center" id="td1BiplPrice_Foo" runat="server">
                                                    <b>
                                                        <asp:Label ID="lbl1BiplPrice_Foo" runat="server" Text=""></asp:Label>
                                                    </b>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="height: 20px; color: Black; vertical-align: middle;" align="center" id="td1CMT_Foo" runat="server">
                                                    <div class="Cmttooltip">
                                                        <b>
                                                            <asp:Label ID="lbl1CMT_Foo" runat="server" Text=""></asp:Label>
                                                        </b>
                                                        <asp:Label ID="lblCmtTooltip1" runat="server" Text=""></asp:Label>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </FooterTemplate>
                                    <FooterStyle CssClass="bol" />
                                </asp:TemplateField>
                                <%-- Slot 2--%>
                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="35" HeaderStyle-Width="35" ItemStyle-HorizontalAlign="Left">
                                    <HeaderTemplate>
                                        <table width="100%" class="slot" border="0" rules="ALL" frame="VOID">
                                            <tr>
                                                <td align="center">
                                                    Slot 2<font color="red">*</font>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" style="width: 45px;">
                                                    St. Qty
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" style="width: 45px;">
                                                    DHU
                                                </td>
                                            </tr>
                                        </table>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <table id="tbl2" runat="server" width="100%" class="slot" rules="ALL" frame="VOID">
                                            <tr>
                                                <td id="tdSlot2Pass" runat="server" align="center" class="yellow">
                                                    <asp:Label ID="lblSlot2Pass" runat="server" Text='<%#Eval("Slot2Pass") %>'></asp:Label>
                                                </td>
                                            </tr>
                                            <tr id="tr2" runat="server">
                                                <td style="height: 27px; vertical-align: middle;" align="center" id="td2Dhu" runat="server">
                                                    <span class="gray">
                                                        <asp:Label ID="lblSlot2DHU" runat="server" Text='<%#Eval("Slot2DHU") %>'></asp:Label>
                                                    </span>
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <table width="100%" class="slot" rules="ALL" frame="VOID">
                                            <tr>
                                                <td id="tdSlot2PassTotal" runat="server" style="height: 23px" align="center" class="yellowfooter">
                                                    <asp:Label ID="lblSlot2PassTotal" Font-Bold="true" runat="server" Text=""></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="height: 59px; vertical-align: middle;" align="center">
                                                    <span class="gray">
                                                        <asp:Label ID="lblSlot2DHUTotal" runat="server" Text=""></asp:Label>
                                                    </span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="height: 20px; vertical-align: middle;" align="center">
                                                    <b>
                                                        <asp:Label ID="lbl2StitchEff_Foo" runat="server" Text=""></asp:Label>
                                                    </b>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="height: 20px; vertical-align: middle;" align="center" id="td2Achieved_Foo" runat="server">
                                                    <b>
                                                        <asp:Label ID="lbl2Achieved_Foo" runat="server" Text=""></asp:Label>
                                                    </b>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="height: 20px; color: Black; vertical-align: middle;" align="center" id="td2BiplPrice_Foo" runat="server">
                                                    <b>
                                                        <asp:Label ID="lbl2BiplPrice_Foo" runat="server" Text=""></asp:Label>
                                                    </b>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="height: 20px; color: Black; vertical-align: middle;" align="center" id="td2CMT_Foo" runat="server">
                                                    <div class="Cmttooltip">
                                                        <b>
                                                            <asp:Label ID="lbl2CMT_Foo" runat="server" Text=""></asp:Label>
                                                        </b>
                                                        <asp:Label ID="lblCmtTooltip2" runat="server" Text=""></asp:Label>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </FooterTemplate>
                                    <FooterStyle CssClass="bol" />
                                </asp:TemplateField>
                                <%-- Slot 3--%>
                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="35" HeaderStyle-Width="35" ItemStyle-HorizontalAlign="Left">
                                    <HeaderTemplate>
                                        <table width="100%" class="slot" border="0" rules="ALL" frame="VOID">
                                            <tr>
                                                <td align="center">
                                                    Slot 3<font color="red">*</font>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" style="width: 45px;">
                                                    St. Qty
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" style="width: 45px;">
                                                    DHU
                                                </td>
                                            </tr>
                                        </table>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <table id="tbl3" runat="server" width="100%" class="slot" rules="ALL" frame="VOID">
                                            <tr>
                                                <td id="tdSlot3Pass" runat="server" align="center" class="yellow">
                                                    <asp:Label ID="lblSlot3Pass" runat="server" Text='<%#Eval("Slot3Pass") %>'></asp:Label>
                                                </td>
                                            </tr>
                                            <tr id="tr3" runat="server">
                                                <td style="height: 27px; vertical-align: middle;" align="center" id="td3Dhu" runat="server">
                                                    <span class="gray">
                                                        <asp:Label ID="lblSlot3DHU" runat="server" Text='<%#Eval("Slot3DHU") %>'></asp:Label>
                                                    </span>
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <table width="100%" class="slot" rules="ALL" frame="VOID">
                                            <tr>
                                                <td id="tdSlot3PassTotal" runat="server" style="height: 23px" align="center" class="yellowfooter">
                                                    <asp:Label ID="lblSlot3PassTotal" Font-Bold="true" runat="server" Text=""></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="height: 59px; vertical-align: middle;" align="center">
                                                    <span class="gray">
                                                        <asp:Label ID="lblSlot3DHUTotal" runat="server" Text=""></asp:Label>
                                                    </span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="height: 20px; vertical-align: middle;" align="center">
                                                    <b>
                                                        <asp:Label ID="lbl3StitchEff_Foo" runat="server" Text=""></asp:Label>
                                                    </b>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="height: 20px; vertical-align: middle;" align="center" id="td3Achieved_Foo" runat="server">
                                                    <b>
                                                        <asp:Label ID="lbl3Achieved_Foo" runat="server" Text=""></asp:Label>
                                                    </b>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="height: 20px; color: Black; vertical-align: middle;" align="center" id="td3BiplPrice_Foo" runat="server">
                                                    <b>
                                                        <asp:Label ID="lbl3BiplPrice_Foo" runat="server" Text=""></asp:Label>
                                                    </b>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="height: 20px; color: Black; vertical-align: middle;" align="center" id="td3CMT_Foo" runat="server">
                                                    <div class="Cmttooltip">
                                                        <b>
                                                            <asp:Label ID="lbl3CMT_Foo" runat="server" Text=""></asp:Label>
                                                        </b>
                                                        <asp:Label ID="lblCmtTooltip3" runat="server" Text=""></asp:Label>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </FooterTemplate>
                                    <FooterStyle CssClass="bol" />
                                </asp:TemplateField>
                                <%-- Slot 4--%>
                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="35" HeaderStyle-Width="35" ItemStyle-HorizontalAlign="Left">
                                    <HeaderTemplate>
                                        <table width="100%" class="slot" border="0" rules="ALL" frame="VOID">
                                            <tr>
                                                <td align="center">
                                                    Slot 4<font color="red">*</font>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" style="width: 45px;">
                                                    St. Qty
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" style="width: 45px;">
                                                    DHU
                                                </td>
                                            </tr>
                                        </table>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <table id="tbl4" runat="server" width="100%" class="slot" rules="ALL" frame="VOID">
                                            <tr>
                                                <td id="tdSlot4Pass" runat="server" align="center" class="yellow">
                                                    <asp:Label ID="lblSlot4Pass" runat="server" Text='<%#Eval("Slot4Pass") %>'></asp:Label>
                                                </td>
                                            </tr>
                                            <tr id="tr4" runat="server">
                                                <td style="height: 27px; vertical-align: middle;" align="center" id="td4Dhu" runat="server">
                                                    <span class="gray">
                                                        <asp:Label ID="lblSlot4DHU" runat="server" Text='<%#Eval("Slot4DHU") %>'></asp:Label>
                                                    </span>
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <table width="100%" class="slot" rules="ALL" frame="VOID">
                                            <tr>
                                                <td id="tdSlot4PassTotal" runat="server" style="height: 23px" align="center" class="yellowfooter">
                                                    <asp:Label ID="lblSlot4PassTotal" Font-Bold="true" runat="server" Text=""></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="height: 59px; vertical-align: middle;" align="center">
                                                    <span class="gray">
                                                        <asp:Label ID="lblSlot4DHUTotal" runat="server" Text=""></asp:Label>
                                                    </span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="height: 20px; vertical-align: middle;" align="center">
                                                    <b>
                                                        <asp:Label ID="lbl4StitchEff_Foo" runat="server" Text=""></asp:Label>
                                                    </b>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="height: 20px; vertical-align: middle;" align="center" id="td4Achieved_Foo" runat="server">
                                                    <b>
                                                        <asp:Label ID="lbl4Achieved_Foo" runat="server" Text=""></asp:Label>
                                                    </b>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="height: 20px; color: Black; vertical-align: middle;" align="center" id="td4BiplPrice_Foo" runat="server">
                                                    <b>
                                                        <asp:Label ID="lbl4BiplPrice_Foo" runat="server" Text=""></asp:Label>
                                                    </b>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="height: 20px; color: Black; vertical-align: middle;" align="center" id="td4CMT_Foo" runat="server">
                                                    <div class="Cmttooltip">
                                                        <b>
                                                            <asp:Label ID="lbl4CMT_Foo" runat="server" Text=""></asp:Label>
                                                        </b>
                                                        <asp:Label ID="lblCmtTooltip4" runat="server" Text=""></asp:Label>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </FooterTemplate>
                                    <FooterStyle CssClass="bol" />
                                </asp:TemplateField>
                                <%-- Slot 5--%>
                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="35" HeaderStyle-Width="35" ItemStyle-HorizontalAlign="Left">
                                    <HeaderTemplate>
                                        <table width="100%" class="slot" border="0" rules="ALL" frame="VOID">
                                            <tr>
                                                <td align="center">
                                                    Slot 5<font color="red">*</font>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" style="width: 45px;">
                                                    St. Qty
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" style="width: 45px;">
                                                    DHU
                                                </td>
                                            </tr>
                                        </table>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <table id="tbl5" runat="server" width="100%" class="slot" rules="ALL" frame="VOID">
                                            <tr>
                                                <td id="tdSlot5Pass" runat="server" align="center" class="yellow">
                                                    <asp:Label ID="lblSlot5Pass" runat="server" Text='<%#Eval("Slot5Pass") %>'></asp:Label>
                                                </td>
                                            </tr>
                                            <tr id="tr5" runat="server">
                                                <td style="height: 27px; vertical-align: middle;" align="center" id="td5Dhu" runat="server">
                                                    <span class="gray">
                                                        <asp:Label ID="lblSlot5DHU" runat="server" Text='<%#Eval("Slot5DHU") %>'></asp:Label>
                                                    </span>
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <table width="100%" class="slot" rules="ALL" frame="VOID">
                                            <tr>
                                                <td id="tdSlot5PassTotal" style="height: 23px" runat="server" align="center" class="yellowfooter">
                                                    <asp:Label ID="lblSlot5PassTotal" Font-Bold="true" runat="server" Text=""></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="height: 59px; vertical-align: middle;" align="center">
                                                    <span class="gray">
                                                        <asp:Label ID="lblSlot5DHUTotal" runat="server" Text=""></asp:Label>
                                                    </span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="height: 20px; vertical-align: middle;" align="center">
                                                    <b>
                                                        <asp:Label ID="lbl5StitchEff_Foo" runat="server" Text=""></asp:Label>
                                                    </b>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="height: 20px; vertical-align: middle;" align="center" id="td5Achieved_Foo" runat="server">
                                                    <b>
                                                        <asp:Label ID="lbl5Achieved_Foo" runat="server" Text=""></asp:Label>
                                                    </b>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="height: 20px; color: Black; vertical-align: middle;" align="center" id="td5BiplPrice_Foo" runat="server">
                                                    <b>
                                                        <asp:Label ID="lbl5BiplPrice_Foo" runat="server" Text=""></asp:Label>
                                                    </b>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="height: 20px; color: Black; vertical-align: middle;" align="center" id="td5CMT_Foo" runat="server">
                                                    <div class="Cmttooltip">
                                                        <b>
                                                            <asp:Label ID="lbl5CMT_Foo" runat="server" Text=""></asp:Label>
                                                        </b>
                                                        <asp:Label ID="lblCmtTooltip5" runat="server" Text=""></asp:Label>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </FooterTemplate>
                                    <FooterStyle CssClass="bol" />
                                </asp:TemplateField>
                                <%-- Slot 6--%>
                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="35" HeaderStyle-Width="35" ItemStyle-HorizontalAlign="Left">
                                    <HeaderTemplate>
                                        <table width="100%" class="slot" border="0" rules="ALL" frame="VOID">
                                            <tr>
                                                <td align="center">
                                                    Slot 6<font color="red">*</font>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" style="width: 45px;">
                                                    St. Qty
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" style="width: 45px;">
                                                    DHU
                                                </td>
                                            </tr>
                                        </table>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <table id="tbl6" runat="server" width="100%" class="slot" rules="ALL" frame="VOID">
                                            <tr>
                                                <td id="tdSlot6Pass" runat="server" align="center" class="yellow">
                                                    <asp:Label ID="lblSlot6Pass" runat="server" Text='<%#Eval("Slot6Pass") %>'></asp:Label>
                                                </td>
                                            </tr>
                                            <tr id="tr6" runat="server">
                                                <td style="height: 27px; vertical-align: middle;" align="center" id="td6Dhu" runat="server">
                                                    <span class="gray">
                                                        <asp:Label ID="lblSlot6DHU" runat="server" Text='<%#Eval("Slot6DHU") %>'></asp:Label>
                                                    </span>
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <table width="100%" class="slot" rules="ALL" frame="VOID">
                                            <tr>
                                                <td id="tdSlot6PassTotal" style="height: 23px" runat="server" align="center" class="yellowfooter">
                                                    <asp:Label ID="lblSlot6PassTotal" Font-Bold="true" runat="server" Text=""></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="height: 59px; vertical-align: middle;" align="center">
                                                    <span class="gray">
                                                        <asp:Label ID="lblSlot6DHUTotal" runat="server" Text=""></asp:Label>
                                                    </span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="height: 20px; vertical-align: middle;" align="center">
                                                    <b>
                                                        <asp:Label ID="lbl6StitchEff_Foo" runat="server" Text=""></asp:Label>
                                                    </b>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="height: 20px; vertical-align: middle;" align="center" id="td6Achieved_Foo" runat="server">
                                                    <b>
                                                        <asp:Label ID="lbl6Achieved_Foo" runat="server" Text=""></asp:Label>
                                                    </b>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="height: 20px; color: Black; vertical-align: middle;" align="center" id="td6BiplPrice_Foo" runat="server">
                                                    <b>
                                                        <asp:Label ID="lbl6BiplPrice_Foo" runat="server" Text=""></asp:Label>
                                                    </b>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="height: 20px; color: Black; vertical-align: middle;" align="center" id="td6CMT_Foo" runat="server">
                                                    <div class="Cmttooltip">
                                                        <b>
                                                            <asp:Label ID="lbl6CMT_Foo" runat="server" Text=""></asp:Label>
                                                        </b>
                                                        <asp:Label ID="lblCmtTooltip6" runat="server" Text=""></asp:Label>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </FooterTemplate>
                                    <FooterStyle CssClass="bol" />
                                </asp:TemplateField>
                                <%-- Slot 7--%>
                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="35" HeaderStyle-Width="35" ItemStyle-HorizontalAlign="Left">
                                    <HeaderTemplate>
                                        <table width="100%" class="slot" border="0" rules="ALL" frame="VOID">
                                            <tr>
                                                <td align="center">
                                                    Slot 7<font color="red">*</font>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" style="width: 45px;">
                                                    St. Qty
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" style="width: 45px;">
                                                    DHU
                                                </td>
                                            </tr>
                                        </table>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <table id="tbl7" runat="server" width="100%" class="slot" rules="ALL" frame="VOID">
                                            <tr>
                                                <td id="tdSlot7Pass" runat="server" align="center" class="yellow">
                                                    <asp:Label ID="lblSlot7Pass" runat="server" Text='<%#Eval("Slot7Pass") %>'></asp:Label>
                                                </td>
                                            </tr>
                                            <tr id="tr7" runat="server">
                                                <td style="height: 27px; vertical-align: middle;" align="center" id="td7Dhu" runat="server">
                                                    <span class="gray">
                                                        <asp:Label ID="lblSlot7DHU" runat="server" Text='<%#Eval("Slot7DHU") %>'></asp:Label>
                                                    </span>
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <table width="100%" class="slot" rules="ALL" frame="VOID">
                                            <tr>
                                                <td id="tdSlot7PassTotal" style="height: 23px" runat="server" align="center" class="yellowfooter">
                                                    <asp:Label ID="lblSlot7PassTotal" Font-Bold="true" runat="server" Text=""></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="height: 59px; vertical-align: middle;" align="center">
                                                    <span class="gray">
                                                        <asp:Label ID="lblSlot7DHUTotal" runat="server" Text=""></asp:Label>
                                                    </span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="height: 20px; vertical-align: middle;" align="center">
                                                    <b>
                                                        <asp:Label ID="lbl7StitchEff_Foo" runat="server" Text=""></asp:Label>
                                                    </b>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="height: 20px; vertical-align: middle;" align="center" id="td7Achieved_Foo" runat="server">
                                                    <b>
                                                        <asp:Label ID="lbl7Achieved_Foo" runat="server" Text=""></asp:Label>
                                                    </b>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="height: 20px; color: Black; vertical-align: middle;" align="center" id="td7BiplPrice_Foo" runat="server">
                                                    <b>
                                                        <asp:Label ID="lbl7BiplPrice_Foo" runat="server" Text=""></asp:Label>
                                                    </b>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="height: 20px; color: Black; vertical-align: middle;" align="center" id="td7CMT_Foo" runat="server">
                                                    <div class="Cmttooltip">
                                                        <b>
                                                            <asp:Label ID="lbl7CMT_Foo" runat="server" Text=""></asp:Label>
                                                        </b>
                                                        <asp:Label ID="lblCmtTooltip7" runat="server" Text=""></asp:Label>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </FooterTemplate>
                                    <FooterStyle CssClass="bol" />
                                </asp:TemplateField>
                                <%-- Slot 8--%>
                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="35" HeaderStyle-Width="35" ItemStyle-HorizontalAlign="Left">
                                    <HeaderTemplate>
                                        <table width="100%" class="slot" border="0" rules="ALL" frame="VOID">
                                            <tr>
                                                <td align="center">
                                                    Slot 8<font color="red">*</font>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" style="width: 45px;">
                                                    St. Qty
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" style="width: 45px;">
                                                    DHU
                                                </td>
                                            </tr>
                                        </table>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <table id="tbl8" runat="server" width="100%" class="slot" rules="ALL" frame="VOID">
                                            <tr>
                                                <td id="tdSlot8Pass" runat="server" align="center" class="yellow">
                                                    <asp:Label ID="lblSlot8Pass" runat="server" Text='<%#Eval("Slot8Pass") %>'></asp:Label>
                                                </td>
                                            </tr>
                                            <tr id="tr8" runat="server">
                                                <td style="height: 27px; vertical-align: middle;" align="center" id="td8Dhu" runat="server">
                                                    <span class="gray">
                                                        <asp:Label ID="lblSlot8DHU" runat="server" Text='<%#Eval("Slot8DHU") %>'></asp:Label>
                                                    </span>
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <table width="100%" class="slot" rules="ALL" frame="VOID">
                                            <tr>
                                                <td id="tdSlot8PassTotal" style="height: 23px" runat="server" align="center" class="yellowfooter">
                                                    <asp:Label ID="lblSlot8PassTotal" Font-Bold="true" runat="server" Text=""></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="height: 59px; vertical-align: middle;" align="center">
                                                    <span class="gray">
                                                        <asp:Label ID="lblSlot8DHUTotal" runat="server" Text=""></asp:Label>
                                                    </span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="height: 20px; vertical-align: middle;" align="center">
                                                    <b>
                                                        <asp:Label ID="lbl8StitchEff_Foo" runat="server" Text=""></asp:Label>
                                                    </b>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="height: 20px; vertical-align: middle;" align="center" id="td8Achieved_Foo" runat="server">
                                                    <b>
                                                        <asp:Label ID="lbl8Achieved_Foo" runat="server" Text=""></asp:Label>
                                                    </b>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="height: 20px; color: Black; vertical-align: middle;" align="center" id="td8BiplPrice_Foo" runat="server">
                                                    <b>
                                                        <asp:Label ID="lbl8BiplPrice_Foo" runat="server" Text=""></asp:Label>
                                                    </b>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="height: 20px; color: Black; vertical-align: middle;" align="center" id="td8CMT_Foo" runat="server">
                                                    <div class="Cmttooltip">
                                                        <b>
                                                            <asp:Label ID="lbl8CMT_Foo" runat="server" Text=""></asp:Label>
                                                        </b>
                                                        <asp:Label ID="lblCmtTooltip8" runat="server" Text=""></asp:Label>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </FooterTemplate>
                                    <FooterStyle CssClass="bol" />
                                </asp:TemplateField>
                                <%-- Slot 9--%>
                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="35" HeaderStyle-Width="35" ItemStyle-HorizontalAlign="Left">
                                    <HeaderTemplate>
                                        <table width="100%" class="slot" border="0" rules="ALL" frame="VOID">
                                            <tr>
                                                <td align="center">
                                                    Slot 9<font color="red">*</font>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" style="width: 45px;">
                                                    St. Qty
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" style="width: 45px;">
                                                    DHU
                                                </td>
                                            </tr>
                                        </table>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <table id="tbl9" runat="server" width="100%" class="slot" rules="ALL" frame="VOID">
                                            <tr>
                                                <td id="tdSlot9Pass" runat="server" align="center" class="yellow">
                                                    <asp:Label ID="lblSlot9Pass" runat="server" Text='<%#Eval("Slot9Pass") %>'></asp:Label>
                                                </td>
                                            </tr>
                                            <tr id="tr9" runat="server">
                                                <td style="height: 27px; vertical-align: middle;" align="center" id="td9Dhu" runat="server">
                                                    <span class="gray">
                                                        <asp:Label ID="lblSlot9DHU" runat="server" Text='<%#Eval("Slot9DHU") %>'></asp:Label>
                                                    </span>
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <table width="100%" class="slot" rules="ALL" frame="VOID">
                                            <tr>
                                                <td id="tdSlot9PassTotal" style="height: 23px" font-bold="true" runat="server" align="center" class="yellowfooter">
                                                    <asp:Label ID="lblSlot9PassTotal" runat="server" Text=""></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="height: 59px; vertical-align: middle;" align="center">
                                                    <span class="gray">
                                                        <asp:Label ID="lblSlot9DHUTotal" runat="server" Text=""></asp:Label>
                                                    </span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="height: 20px; vertical-align: middle;" align="center">
                                                    <b>
                                                        <asp:Label ID="lbl9StitchEff_Foo" runat="server" Text=""></asp:Label>
                                                    </b>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="height: 20px; vertical-align: middle;" align="center" id="td9Achieved_Foo" runat="server">
                                                    <b>
                                                        <asp:Label ID="lbl9Achieved_Foo" runat="server" Text=""></asp:Label>
                                                    </b>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="height: 20px; color: Black; vertical-align: middle;" align="center" id="td9BiplPrice_Foo" runat="server">
                                                    <b>
                                                        <asp:Label ID="lbl9BiplPrice_Foo" runat="server" Text=""></asp:Label>
                                                    </b>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="height: 20px; color: Black; vertical-align: middle;" align="center" id="td9CMT_Foo" runat="server">
                                                    <div class="Cmttooltip">
                                                        <b>
                                                            <asp:Label ID="lbl9CMT_Foo" runat="server" Text=""></asp:Label>
                                                        </b>
                                                        <asp:Label ID="lblCmtTooltip9" runat="server" Text=""></asp:Label>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </FooterTemplate>
                                    <FooterStyle CssClass="bol" />
                                </asp:TemplateField>
                                <%-- Slot 10--%>
                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="35" HeaderStyle-Width="35" ItemStyle-HorizontalAlign="Left">
                                    <HeaderTemplate>
                                        <table width="100%" class="slot" border="0" rules="ALL" frame="VOID">
                                            <tr>
                                                <td align="center">
                                                    Slot 10<font color="red">*</font>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" style="width: 45px;">
                                                    St. Qty
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" style="width: 45px;">
                                                    DHU
                                                </td>
                                            </tr>
                                        </table>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <table id="tbl10" runat="server" width="100%" class="slot" rules="ALL" frame="VOID">
                                            <tr>
                                                <td id="tdSlot10Pass" runat="server" align="center" class="yellow">
                                                    <asp:Label ID="lblSlot10Pass" runat="server" Text='<%#Eval("Slot10Pass") %>'></asp:Label>
                                                </td>
                                            </tr>
                                            <tr id="tr10" runat="server">
                                                <td style="height: 27px; vertical-align: middle;" align="center" id="td10Dhu" runat="server">
                                                    <span class="gray">
                                                        <asp:Label ID="lblSlot10DHU" runat="server" Text='<%#Eval("Slot10DHU") %>'></asp:Label>
                                                    </span>
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <table width="100%" class="slot" rules="ALL" frame="VOID">
                                            <tr>
                                                <td id="tdSlot10PassTotal" style="height: 23px" runat="server" align="center" class="yellowfooter">
                                                    <asp:Label ID="lblSlot10PassTotal" Font-Bold="true" runat="server" Text=""></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="height: 59px; vertical-align: middle;" align="center">
                                                    <span class="gray">
                                                        <asp:Label ID="lblSlot10DHUTotal" runat="server" Text=""></asp:Label>
                                                    </span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="height: 20px; vertical-align: middle;" align="center">
                                                    <b>
                                                        <asp:Label ID="lbl10StitchEff_Foo" runat="server" Text=""></asp:Label>
                                                    </b>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="height: 20px; vertical-align: middle;" align="center" id="td10Achieved_Foo" runat="server">
                                                    <b>
                                                        <asp:Label ID="lbl10Achieved_Foo" runat="server" Text=""></asp:Label>
                                                    </b>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="height: 20px; color: Black; vertical-align: middle;" align="center" id="td10BiplPrice_Foo" runat="server">
                                                    <b>
                                                        <asp:Label ID="lbl10BiplPrice_Foo" runat="server" Text=""></asp:Label>
                                                    </b>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="height: 20px; color: Black; vertical-align: middle;" align="center" id="td10CMT_Foo" runat="server">
                                                    <div class="Cmttooltip">
                                                        <b>
                                                            <asp:Label ID="lbl10CMT_Foo" runat="server" Text=""></asp:Label>
                                                        </b>
                                                        <asp:Label ID="lblCmtTooltip10" runat="server" Text=""></asp:Label>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </FooterTemplate>
                                    <FooterStyle CssClass="bol" />
                                </asp:TemplateField>
                                <%-- Slot 11--%>
                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="35" HeaderStyle-Width="35" ItemStyle-HorizontalAlign="Left">
                                    <HeaderTemplate>
                                        <table width="100%" class="slot" border="0" rules="ALL" frame="VOID">
                                            <tr>
                                                <td align="center">
                                                    Slot 11<font color="red">*</font>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" style="width: 45px;">
                                                    St. Qty
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" style="width: 45px;">
                                                    DHU
                                                </td>
                                            </tr>
                                        </table>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <table id="tbl11" runat="server" width="100%" class="slot" rules="ALL" frame="VOID">
                                            <tr>
                                                <td id="tdSlot11Pass" runat="server" align="center" class="yellow">
                                                    <asp:Label ID="lblSlot11Pass" runat="server" Text='<%#Eval("Slot11Pass") %>'></asp:Label>
                                                </td>
                                            </tr>
                                            <tr id="tr11" runat="server">
                                                <td style="height: 27px; vertical-align: middle;" align="center" id="td11Dhu" runat="server">
                                                    <span class="gray">
                                                        <asp:Label ID="lblSlot11DHU" runat="server" Text='<%#Eval("Slot11DHU") %>'></asp:Label>
                                                    </span>
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <table width="100%" class="slot" rules="ALL" frame="VOID">
                                            <tr>
                                                <td id="tdSlot11PassTotal" style="height: 23px" runat="server" align="center" class="yellowfooter">
                                                    <asp:Label ID="lblSlot11PassTotal" Font-Bold="true" runat="server" Text=""></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="height: 59px; vertical-align: middle;" align="center">
                                                    <span class="gray">
                                                        <asp:Label ID="lblSlot11DHUTotal" runat="server" Text=""></asp:Label>
                                                    </span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="height: 20px; vertical-align: middle;" align="center">
                                                    <b>
                                                        <asp:Label ID="lbl11StitchEff_Foo" runat="server" Text=""></asp:Label>
                                                    </b>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="height: 20px; vertical-align: middle;" align="center" id="td11Achieved_Foo" runat="server">
                                                    <b>
                                                        <asp:Label ID="lbl11Achieved_Foo" runat="server" Text=""></asp:Label>
                                                    </b>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="height: 20px; color: Black; vertical-align: middle;" align="center" id="td11BiplPrice_Foo" runat="server">
                                                    <b>
                                                        <asp:Label ID="lbl11BiplPrice_Foo" runat="server" Text=""></asp:Label>
                                                    </b>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="height: 20px; color: Black; vertical-align: middle;" align="center" id="td11CMT_Foo" runat="server">
                                                    <div class="Cmttooltip">
                                                        <b>
                                                            <asp:Label ID="lbl11CMT_Foo" runat="server" Text=""></asp:Label>
                                                        </b>
                                                        <asp:Label ID="lblCmtTooltip11" runat="server" Text=""></asp:Label>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </FooterTemplate>
                                    <FooterStyle CssClass="bol" />
                                </asp:TemplateField>
                                <%-- Slot 12--%>
                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="35" HeaderStyle-Width="35" ItemStyle-HorizontalAlign="Left">
                                    <HeaderTemplate>
                                        <table width="100%" class="slot" border="0" rules="ALL" frame="VOID">
                                            <tr>
                                                <td align="center">
                                                    Slot 12<font color="red">*</font>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" style="width: 45px;">
                                                    St. Qty
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" style="width: 45px;">
                                                    DHU
                                                </td>
                                            </tr>
                                        </table>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <table id="tbl12" runat="server" width="100%" class="slot" rules="ALL" frame="VOID">
                                            <tr>
                                                <td id="tdSlot12Pass" runat="server" align="center" class="yellow">
                                                    <asp:Label ID="lblSlot12Pass" runat="server" Text='<%#Eval("Slot12Pass") %>'></asp:Label>
                                                </td>
                                            </tr>
                                            <tr id="tr12" runat="server">
                                                <td style="height: 27px; vertical-align: middle;" align="center" id="td12Dhu" runat="server">
                                                    <span class="gray">
                                                        <asp:Label ID="lblSlot12DHU" runat="server" Text='<%#Eval("Slot12DHU") %>'></asp:Label>
                                                    </span>
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <table width="100%" class="slot" rules="ALL" frame="VOID">
                                            <tr>
                                                <td id="tdSlot12PassTotal" style="height: 23px" runat="server" align="center" class="yellowfooter">
                                                    <asp:Label ID="lblSlot12PassTotal" Font-Bold="true" runat="server" Text=""></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="height: 59px; vertical-align: middle;" align="center">
                                                    <span class="gray">
                                                        <asp:Label ID="lblSlot12DHUTotal" runat="server" Text=""></asp:Label>
                                                    </span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="height: 20px; vertical-align: middle;" align="center">
                                                    <b>
                                                        <asp:Label ID="lbl12StitchEff_Foo" runat="server" Text=""></asp:Label>
                                                    </b>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="height: 20px; vertical-align: middle;" align="center" id="td12Achieved_Foo" runat="server">
                                                    <b>
                                                        <asp:Label ID="lbl12Achieved_Foo" runat="server" Text=""></asp:Label>
                                                    </b>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="height: 20px; color: Black; vertical-align: middle;" align="center" id="td12BiplPrice_Foo" runat="server">
                                                    <b>
                                                        <asp:Label ID="lbl12BiplPrice_Foo" runat="server" Text=""></asp:Label>
                                                    </b>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="height: 20px; color: Black; vertical-align: middle;" align="center" id="td12CMT_Foo" runat="server">
                                                    <div class="Cmttooltip">
                                                        <b>
                                                            <asp:Label ID="lbl12CMT_Foo" runat="server" Text=""></asp:Label>
                                                        </b>
                                                        <asp:Label ID="lblCmtTooltip12" runat="server" Text=""></asp:Label>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </FooterTemplate>
                                    <FooterStyle CssClass="bol" />
                                </asp:TemplateField>
                                <%-- Slot 13--%>
                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="35" HeaderStyle-Width="35" ItemStyle-HorizontalAlign="Left">
                                    <HeaderTemplate>
                                        <table width="100%" class="slot" border="0" rules="ALL" frame="VOID">
                                            <tr>
                                                <td align="center">
                                                    Slot 13<font color="red">*</font>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" style="width: 45px;">
                                                    St. Qty
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" style="width: 45px;">
                                                    DHU
                                                </td>
                                            </tr>
                                        </table>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <table id="tbl13" runat="server" width="100%" class="slot" rules="ALL" frame="VOID">
                                            <tr>
                                                <td id="tdSlot13Pass" runat="server" align="center" class="yellow">
                                                    <asp:Label ID="lblSlot13Pass" runat="server" Text='<%#Eval("Slot13Pass") %>'></asp:Label>
                                                </td>
                                            </tr>
                                            <tr id="tr13" runat="server">
                                                <td style="height: 27px; vertical-align: middle;" align="center" id="td13Dhu" runat="server">
                                                    <span class="gray">
                                                        <asp:Label ID="lblSlot13DHU" runat="server" Text='<%#Eval("Slot13DHU") %>'></asp:Label>
                                                    </span>
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <table width="100%" class="slot" rules="ALL" frame="VOID">
                                            <tr>
                                                <td id="tdSlot13PassTotal" style="height: 23px" runat="server" align="center" class="yellowfooter">
                                                    <asp:Label ID="lblSlot13PassTotal" Font-Bold="true" runat="server" Text=""></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="height: 59px; vertical-align: middle;" align="center">
                                                    <span class="gray">
                                                        <asp:Label ID="lblSlot13DHUTotal" runat="server" Text=""></asp:Label>
                                                    </span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="height: 20px; vertical-align: middle;" align="center">
                                                    <b>
                                                        <asp:Label ID="lbl13StitchEff_Foo" runat="server" Text=""></asp:Label>
                                                    </b>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="height: 20px; vertical-align: middle;" align="center" id="td13Achieved_Foo" runat="server">
                                                    <b>
                                                        <asp:Label ID="lbl13Achieved_Foo" runat="server" Text=""></asp:Label>
                                                    </b>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="height: 20px; color: Black; vertical-align: middle;" align="center" id="td13BiplPrice_Foo" runat="server">
                                                    <b>
                                                        <asp:Label ID="lbl13BiplPrice_Foo" runat="server" Text=""></asp:Label>
                                                    </b>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="height: 20px; color: Black; vertical-align: middle;" align="center" id="td13CMT_Foo" runat="server">
                                                    <div class="Cmttooltip">
                                                        <b>
                                                            <asp:Label ID="lbl13CMT_Foo" runat="server" Text=""></asp:Label>
                                                        </b>
                                                        <asp:Label ID="lblCmtTooltip13" runat="server" Text=""></asp:Label>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </FooterTemplate>
                                    <FooterStyle CssClass="bol" />
                                </asp:TemplateField>
                                <%-- Slot 14--%>
                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="35" HeaderStyle-Width="35" ItemStyle-HorizontalAlign="Left">
                                    <HeaderTemplate>
                                        <table width="100%" class="slot" border="0" rules="ALL" frame="VOID">
                                            <tr>
                                                <td align="center">
                                                    Slot 14<font color="red">*</font>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" style="width: 45px;">
                                                    St. Qty
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" style="width: 45px;">
                                                    DHU
                                                </td>
                                            </tr>
                                        </table>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <table id="tbl14" runat="server" width="100%" class="slot" rules="ALL" frame="VOID">
                                            <tr>
                                                <td id="tdSlot14Pass" runat="server" align="center" class="yellow">
                                                    <asp:Label ID="lblSlot14Pass" runat="server" Text='<%#Eval("Slot14Pass") %>'></asp:Label>
                                                </td>
                                            </tr>
                                            <tr id="tr14" runat="server">
                                                <td style="height: 27px; vertical-align: middle;" align="center" id="td14Dhu" runat="server">
                                                    <span class="gray">
                                                        <asp:Label ID="lblSlot14DHU" runat="server" Text='<%#Eval("Slot14DHU") %>'></asp:Label>
                                                    </span>
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <table width="100%" class="slot" rules="ALL" frame="VOID">
                                            <tr>
                                                <td id="tdSlot14PassTotal" style="height: 23px" runat="server" align="center" class="yellowfooter">
                                                    <asp:Label ID="lblSlot14PassTotal" Font-Bold="true" runat="server" Text=""></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="height: 59px; vertical-align: middle;" align="center">
                                                    <span class="gray">
                                                        <asp:Label ID="lblSlot14DHUTotal" runat="server" Text=""></asp:Label>
                                                    </span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="height: 20px; vertical-align: middle;" align="center">
                                                    <b>
                                                        <asp:Label ID="lbl14StitchEff_Foo" runat="server" Text=""></asp:Label>
                                                    </b>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="height: 20px; vertical-align: middle;" align="center" id="td14Achieved_Foo" runat="server">
                                                    <b>
                                                        <asp:Label ID="lbl14Achieved_Foo" runat="server" Text=""></asp:Label>
                                                    </b>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="height: 20px; color: Black; vertical-align: middle;" align="center" id="td14BiplPrice_Foo" runat="server">
                                                    <b>
                                                        <asp:Label ID="lbl14BiplPrice_Foo" runat="server" Text=""></asp:Label>
                                                    </b>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="height: 20px; color: Black; vertical-align: middle;" align="center" id="td14CMT_Foo" runat="server">
                                                    <div class="Cmttooltip">
                                                        <b>
                                                            <asp:Label ID="lbl14CMT_Foo" runat="server" Text=""></asp:Label>
                                                        </b>
                                                        <asp:Label ID="lblCmtTooltip14" runat="server" Text=""></asp:Label>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </FooterTemplate>
                                    <FooterStyle CssClass="bol" />
                                </asp:TemplateField>
                                <%-- Slot 15--%>
                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="35" HeaderStyle-Width="35" ItemStyle-HorizontalAlign="Left">
                                    <HeaderTemplate>
                                        <table width="100%" class="slot" border="0" rules="ALL" frame="VOID">
                                            <tr>
                                                <td align="center">
                                                    Slot 15<font color="red">*</font>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" style="width: 45px;">
                                                    St. Qty
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" style="width: 45px;">
                                                    DHU
                                                </td>
                                            </tr>
                                        </table>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <table id="tbl15" runat="server" width="100%" class="slot" rules="ALL" frame="VOID">
                                            <tr>
                                                <td id="tdSlot15Pass" runat="server" align="center" class="yellow">
                                                    <asp:Label ID="lblSlot15Pass" runat="server" Text='<%#Eval("Slot15Pass") %>'></asp:Label>
                                                </td>
                                            </tr>
                                            <tr id="tr15" runat="server">
                                                <td style="height: 27px; vertical-align: middle;" align="center" id="td15Dhu" runat="server">
                                                    <span class="gray">
                                                        <asp:Label ID="lblSlot15DHU" runat="server" Text='<%#Eval("Slot15DHU") %>'></asp:Label>
                                                    </span>
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <table width="100%" class="slot" rules="ALL" frame="VOID">
                                            <tr>
                                                <td id="tdSlot15PassTotal" style="height: 23px" runat="server" align="center" class="yellowfooter">
                                                    <asp:Label ID="lblSlot15PassTotal" Font-Bold="true" runat="server" Text=""></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="height: 59px; vertical-align: middle;" align="center">
                                                    <span class="gray">
                                                        <asp:Label ID="lblSlot15DHUTotal" runat="server" Text=""></asp:Label>
                                                    </span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="height: 20px; vertical-align: middle;" align="center">
                                                    <b>
                                                        <asp:Label ID="lbl15StitchEff_Foo" runat="server" Text=""></asp:Label>
                                                    </b>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="height: 20px; vertical-align: middle;" align="center" id="td15Achieved_Foo" runat="server">
                                                    <b>
                                                        <asp:Label ID="lbl15Achieved_Foo" runat="server" Text=""></asp:Label>
                                                    </b>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="height: 20px; color: Black; vertical-align: middle;" align="center" id="td15BiplPrice_Foo" runat="server">
                                                    <b>
                                                        <asp:Label ID="lbl15BiplPrice_Foo" runat="server" Text=""></asp:Label>
                                                    </b>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="height: 20px; color: Black; vertical-align: middle;" align="center" id="td15CMT_Foo" runat="server">
                                                    <div class="Cmttooltip">
                                                        <b>
                                                            <asp:Label ID="lbl15CMT_Foo" runat="server" Text=""></asp:Label>
                                                        </b>
                                                        <asp:Label ID="lblCmtTooltip15" runat="server" Text=""></asp:Label>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </FooterTemplate>
                                    <FooterStyle CssClass="bol" />
                                </asp:TemplateField>
                                <%-- Slot 16--%>
                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="35" HeaderStyle-Width="35" ItemStyle-HorizontalAlign="Left">
                                    <HeaderTemplate>
                                        <table width="100%" class="slot" border="0" rules="ALL" frame="VOID">
                                            <tr>
                                                <td align="center">
                                                    Slot 16<font color="red">*</font>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" style="width: 45px;">
                                                    St. Qty
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" style="width: 45px;">
                                                    DHU
                                                </td>
                                            </tr>
                                        </table>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <table id="tbl16" runat="server" width="100%" class="slot" rules="ALL" frame="VOID">
                                            <tr>
                                                <td id="tdSlot16Pass" runat="server" align="center" class="yellow">
                                                    <asp:Label ID="lblSlot16Pass" runat="server" Text='<%#Eval("Slot16Pass") %>'></asp:Label>
                                                </td>
                                            </tr>
                                            <tr id="tr16" runat="server">
                                                <td style="height: 27px; vertical-align: middle;" align="center" id="td16Dhu" runat="server">
                                                    <span class="gray">
                                                        <asp:Label ID="lblSlot16DHU" runat="server" Text='<%#Eval("Slot16DHU") %>'></asp:Label>
                                                    </span>
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <table width="100%" class="slot" rules="ALL" frame="VOID">
                                            <tr>
                                                <td id="tdSlot16PassTotal" style="height: 23px" runat="server" align="center" class="yellowfooter">
                                                    <asp:Label ID="lblSlot16PassTotal" Font-Bold="true" runat="server" Text=""></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="height: 59px; vertical-align: middle;" align="center">
                                                    <span class="gray">
                                                        <asp:Label ID="lblSlot16DHUTotal" runat="server" Text=""></asp:Label>
                                                    </span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="height: 20px; vertical-align: middle;" align="center">
                                                    <b>
                                                        <asp:Label ID="lbl16StitchEff_Foo" runat="server" Text=""></asp:Label>
                                                    </b>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="height: 20px; vertical-align: middle;" align="center" id="td16Achieved_Foo" runat="server">
                                                    <b>
                                                        <asp:Label ID="lbl16Achieved_Foo" runat="server" Text=""></asp:Label>
                                                    </b>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="height: 20px; color: Black; vertical-align: middle;" align="center" id="td16BiplPrice_Foo" runat="server">
                                                    <b>
                                                        <asp:Label ID="lbl16BiplPrice_Foo" runat="server" Text=""></asp:Label>
                                                    </b>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="height: 20px; color: Black; vertical-align: middle;" align="center" id="td16CMT_Foo" runat="server">
                                                    <div class="Cmttooltip">
                                                        <b>
                                                            <asp:Label ID="lbl16CMT_Foo" runat="server" Text=""></asp:Label>
                                                        </b>
                                                        <asp:Label ID="lblCmtTooltip16" runat="server" Text=""></asp:Label>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </FooterTemplate>
                                    <FooterStyle CssClass="bol" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="85" HeaderStyle-Width="85" ItemStyle-HorizontalAlign="Left">
                                    <HeaderTemplate>
                                        <table cellpadding="0" cellspacing="0" width="100%" rules="all" frame="void" border="1">
                                            <tr>
                                                <td>
                                                    Stitching
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Tdy Pcs (Avg Pc/Hr.)
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Tdy Eff (Sty Eff) - CMT%
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    DHU Achieved
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Tdy Fin. (Avg Pc/Hr.) Fin. Cost / pcs
                                                </td>
                                            </tr>
                                        </table>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <table id="tblStitch" runat="server" cellpadding="0" cellspacing="0" width="100%">
                                            <tr>
                                                <td id="tdTodayPass" runat="server" style="border-bottom: 1px solid #bfbfbf; height: 15px; text-align: center;">
                                                    <asp:Label ID="lblTodayPassStitch" Style="font-size: 12px;" runat="server" Text=""></asp:Label>
                                                    <asp:Label ID="lblStchAvgPcsHr" Style="color: Gray;" runat="server" Font-Bold="true" Text=''></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td id="tdTodayEff" runat="server" style="text-align: center; border-bottom: 1px solid #bfbfbf; vertical-align: middle; height: 15px;">
                                                    <asp:Label ID="lblTodayEff_Stitch" runat="server" CssClass="today-stitch" Text=""></asp:Label>
                                                    <asp:Label ID="lblStyleEff_Stitch" Style="color: Gray;" runat="server" Text=""></asp:Label>
                                                     <div class="Cmttooltip">
                                                        <b>
                                                           <asp:Label ID="lblCmtPer_Stitch" Style="color: Blue;" runat="server" Text=""></asp:Label>
                                                        </b>
                                                        <asp:Label ID="lblCmtPer_StitchTooltip" runat="server" Text=""></asp:Label>
                                                    </div>
                                                    
                                                </td>
                                            </tr>
                                            <tr>
                                                <td id="tdTodayAlt" runat="server" style="text-align: center; vertical-align: middle; height: 15px; border-bottom: 1px solid #bfbfbf;">
                                                    <asp:Label ID="lblTodayAltPcs" Style="display: none;" runat="server" Text=""></asp:Label>
                                                    <asp:Label class="" ID="lblTodayDHU" Style="color: Gray;" runat="server" Text=""></asp:Label>&nbsp;&nbsp;
                                                    <asp:Label class="TodayAchieved" ID="lblTodayAchieved" Font-Bold="true" Font-Size="11px" runat="server" Text=""></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="height: 15px; text-align: center; font-size: 9px !important;">
                                                    <asp:Label ID="lblTodayPassFinish" Style="font-size: 12px;" runat="server" Text=""></asp:Label>
                                                    <asp:Label ID="lblFinishAvgPcs" Style="color: Gray;" runat="server" Text=''></asp:Label>
                                                    <asp:Label ID="lblFinishCost" runat="server" Style="" Text="" Font-Bold="true"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                    <ItemStyle VerticalAlign="Top" />
                                    <FooterTemplate>
                                        <table cellpadding="0" cellspacing="0" width="100%" frame="void" rules="all">
                                            <tr>
                                                <td id="tdSlotAllPassTotal" runat="server" style="border-bottom: 1px solid #bfbfbf; font-weight: bold; height: 23px; text-align: center;">
                                                    <asp:Label ID="lblTodayPassStitch_Foo" Style="font-size: 12px;" runat="server" Text=""></asp:Label>
                                                    <asp:Label ID="lblStchAvgPcsHr_foo" Style="color: Gray;" runat="server" Text=''></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td id="tdTodayEffTotal" runat="server" style="text-align: center; width: 100%; border-bottom: 1px solid #bfbfbf; height: 15px">
                                                    <asp:Label ID="lblTodayEff_Stitch_Foo" runat="server" Text=""></asp:Label>
                                                    <asp:Label ID="lblStyleEff_Stitch_Foo" Style="color: Gray;" runat="server" Text=""></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td id="tdTodayAltTotal" runat="server" style="text-align: center; height: 15px; vertical-align: middle; border-bottom: 1px solid #bfbfbf;">
                                                    <asp:Label ID="lblTodayAltPcs_Foo" Style="display: none;" runat="server" Text=""></asp:Label>
                                                    <asp:Label ID="lblTodayDHU_Foo" Style="color: Gray;" runat="server" Text=""></asp:Label>&nbsp;&nbsp;
                                                    <asp:Label class="" ID="lblTodayAchieved_Foo" Font-Bold="true" Font-Size="11px" runat="server" Text=""></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="height: 70px; vertical-align: top; text-align: center; font-size: 9px !important; line-height: 14px;">
                                                    <asp:Label ID="lblTodayPassFinish_Foo" Style="font-size: 12px;" runat="server" Text=""></asp:Label>
                                                    <asp:Label ID="lblFinishAvgPcs_foo" Style="color: Gray;" runat="server" Text=''></asp:Label>
                                                    <asp:Label ID="lblFInishCost_total" Style="" runat="server" Font-Bold="true" Text=""></asp:Label>
                                                    <asp:HiddenField ID="hdnFinishCost_total" Value="0" runat="server" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="height: 20px;">
                                                    <asp:Label ID="lblBiplPriceTotal_foo" Style="color: #000; position: relative; top: 2px; font-weight: 600; font-size: 13px" runat="server" Text=''></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="height: 20px;">
                                                    <div class="Cmttooltip">
                                                        <asp:Label ID="lblCMTTotal_foo" Style="color: #000; position: relative; top: 2px; font-weight: 600; font-size: 13px" runat="server" Text=''></asp:Label>
                                                        <asp:Label ID="lblCmtTooltip_foo" runat="server" Text=""></asp:Label>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </FooterTemplate>
                                    <FooterStyle CssClass="bol" VerticalAlign="Top" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="85" HeaderStyle-Width="85" ItemStyle-HorizontalAlign="Left">
                                    <HeaderTemplate>
                                        <table cellpadding="0" cellspacing="0" width="100%" rules="all" frame="void" border="1">
                                            <tr>
                                                <td style="border-bottom: 1px solid #999999">
                                                    Order (Pndg Rscn) Qty
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="border-bottom: 1px solid #999999">
                                                    Fab (Cut) Qty
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="border-bottom: 1px solid #999999">
                                                    Stch. (Fin.) Qty
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    OH Issued (Stch.) Qty
                                                </td>
                                            </tr>
                                        </table>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <table id="tblOrderQty" runat="server" cellpadding="0" cellspacing="0" width="100%">
                                            <tr>
                                                <td style="border-bottom: 1px solid #bfbfbf; height: 15px; text-align: center;">
                                                    <asp:Label runat="server" ID="lblOrderQty" Style="font-size: 10px !important;" ForeColor="Black" Text=""></asp:Label>
                                                    <asp:Label runat="server" ID="lblRescanQty" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="border-bottom: 1px solid #bfbfbf; height: 15px; text-align: center;">
                                                    <asp:Label ID="lblFabQty" runat="server" Font-Bold="true" Text=""></asp:Label>
                                                    <asp:Label ID="lblCutQty" runat="server" Font-Bold="true" Text=""></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="border-bottom: 1px solid #bfbfbf; height: 15px; text-align: center;">
                                                    <asp:Label ID="lblStitchQty" ForeColor="Black" Style="font-size: 11px !important;" Font-Bold="true" runat="server" Text=""></asp:Label>
                                                    <asp:Label ID="lblFinishQty" ForeColor="Blue" Style="font-size: 11px !important;" runat="server" Text=""></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: center; text-align: center; height: 15px; vertical-align: middle;">
                                                    <asp:Label ID="lblOutHouseCutIssue" runat="server" ForeColor="Black" Text=""></asp:Label>
                                                    <asp:Label ID="lblOutHouseStch" runat="server" ForeColor="Black" Text=""></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                    <ItemStyle VerticalAlign="Top" />
                                    <FooterTemplate>
                                        <table id="tblOrderQtyFoo" runat="server" cellpadding="0" cellspacing="0" width="100%" frame="void" rules="all">
                                            <tr>
                                                <td style="text-align: center; text-align: center; height: 23px; vertical-align: middle;">
                                                    <asp:Label ForeColor="black" ID="lblOrderQty_Foo" Style="font-size: 11px;" runat="server" Text=""></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="border-bottom: 1px solid #bfbfbf; height: 15px; text-align: center;">
                                                    <asp:Label ID="lblFabQty_Foo" runat="server" Font-Bold="true" Text=""></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="border-bottom: 1px solid #bfbfbf; height: 15px; text-align: center;">
                                                    <asp:Label ID="lblCutQty_Foo" runat="server" Font-Bold="true" Text=""></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: center; height: 15px; vertical-align: middle;">
                                                    <asp:Label ID="lblStitchQty_Foo" ForeColor="Black" Font-Size="11px" Font-Bold="true" runat="server" Text=""></asp:Label>
                                                    <asp:Label ID="lblFinishQty_Foo" ForeColor="Blue" Font-Size="11px" runat="server" Text=""></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </FooterTemplate>
                                    <FooterStyle CssClass="bol" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="70" HeaderStyle-Width="70" ItemStyle-HorizontalAlign="Left" Visible="false">
                                    <HeaderTemplate>
                                        <table cellpadding="0" cellspacing="0" width="100%" rules="all" frame="void" border="1">
                                            <tr>
                                                <td>
                                                    Finishing
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Tdy Fin. (Avg Pc/Hr.)
                                                </td>
                                            </tr>
                                            <%--<tr>
                                     <td> % prfmnce</td>
                                     </tr> --%>
                                            <tr>
                                                <td>
                                                    Fin. Cost / pcs
                                                </td>
                                            </tr>
                                        </table>
                                    </HeaderTemplate>
                                    <HeaderStyle VerticalAlign="Top" />
                                    <ItemTemplate>
                                        <table cellpadding="0" cellspacing="0" width="100%">
                                            <tr>
                                                <td style="border-bottom: 1px solid #bfbfbf; height: 15px; text-align: center; font-size: 9px !important; font-weight: bold;">
                                                </td>
                                            </tr>
                                            <tr style="display: none;">
                                                <td id="tdPercentPerformance" runat="server" style="text-align: center; height: 15px; border-bottom: 1px solid #bfbfbf; color: White; font-weight: bold; vertical-align: middle; display: none;">
                                                    <asp:Label ID="lblPercentPerformance" runat="server" Style="" Text=""></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: center; height: 20px; font-weight: bold; vertical-align: middle;" id="tdFinishCost" runat="server">
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <table cellpadding="0" cellspacing="0" width="100%" frame="void" rules="all">
                                            <tr>
                                                <td style="border-bottom: 1px solid #bfbfbf; height: 15px; color: Black; font-size: 9px !important; text-align: center; font-weight: bold;">
                                                </td>
                                            </tr>
                                            <tr style="display: none;">
                                                <td id="tdPercentPerformanceTotal" runat="server" style="text-align: center; height: 15px; border-bottom: 1px solid #bfbfbf; color: White; font-weight: bold; vertical-align: middle; display: none;">
                                                    <asp:Label ID="lblPercentPerformance_Foo" Style="" runat="server" Text=""></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: center; height: 20px; font-weight: bold; vertical-align: middle;" id="tdFinishCost_footer" runat="server">
                                                </td>
                                            </tr>
                                        </table>
                                    </FooterTemplate>
                                    <FooterStyle CssClass="bol" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center" Visible="false" ItemStyle-VerticalAlign="Top" ItemStyle-Width="60" HeaderStyle-Width="60" ItemStyle-HorizontalAlign="Left">
                                    <HeaderTemplate>
                                        <table rules="all" frame="void" width="100%" cellspacing="0" cellpadding="0" class="line_td">
                                            <tbody>
                                                <tr>
                                                    <th>
                                                        clos time
                                                    </th>
                                                </tr>
                                                <tr>
                                                    <th>
                                                        Mtrl short
                                                    </th>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Repeater ID="rptPlanning" OnItemDataBound="rptPlanning_ItemDataBound" runat="server">
                                            <ItemTemplate>
                                                <table rules="all" frame="void" width="100%" cellspacing="0" cellpadding="0" class="line_td">
                                                    <tbody>
                                                        <tr>
                                                            <td align="center" style="height: 20px;">
                                                                <asp:Label ID="lblClosingTime" runat="server" Style="color: Black; font-weight: bold;" Text='<%#Eval("ClosingTime")%>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td id="tdDelay" runat="server" align="center">
                                                                <asp:Label ID="lblFabricCount" Style="color: Black;" runat="server" Text='<%#Eval("FabricCount")%>'>
                                                                </asp:Label>
                                                                <asp:Label ID="lblAccessCount" Style="color: Black;" runat="server" Text='<%#Eval("AccessCount")%>'></asp:Label>
                                                                <br>
                                                                <asp:Label ID="lblLinePlanDate" Style="color: Black;" runat="server" Text='<%#Eval("LinePlanningDate")%>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" FooterStyle-VerticalAlign="Top" ItemStyle-Width="215px" HeaderStyle-Width="215px" ItemStyle-HorizontalAlign="Left" FooterStyle-Width="215px">
                                    <HeaderTemplate>
                                        <table width="100%" cellspacing="0" cellpadding="0">
                                            <tbody>
                                                <tr>
                                                    <td>
                                                        QC Details
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <table rules="all" frame="void" style="border-top: 1px solid gray;" width="100%" cellspacing="0" cellpadding="0">
                                                            <tbody>
                                                                <tr>
                                                                    <th colspan="4" style="text-align: center">
                                                                        Today
                                                                    </th>
                                                                    <th rowspan="2" style="text-align: center; width: 155px;">
                                                                        Inspection
                                                                    </th>
                                                                </tr>
                                                                <tr>
                                                                    <th style="text-align: center; width: 15px">
                                                                        S
                                                                    </th>
                                                                    <th style="text-align: center; width: 15px">
                                                                        P
                                                                    </th>
                                                                    <th style="text-align: center; width: 15px">
                                                                        R
                                                                    </th>
                                                                    <th style="text-align: center; width: 15px">
                                                                        R%
                                                                    </th>
                                                                </tr>
                                                                <tr>
                                                                    <th colspan="5">
                                                                        Faults
                                                                    </th>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <table rules="all" frame="void" width="100%" cellspacing="0" cellpadding="0">
                                            <tbody>
                                                <tr>
                                                    <td style="text-align: center; width: 15px">
                                                        <div style="width: 10px; height: 10px; border-radius: 50%; margin: 0px auto;" runat="server" id="divCircle">
                                                            &nbsp;</div>
                                                    </td>
                                                    <td style="text-align: center; width: 15px">
                                                        <asp:Label runat="server" ID="lblQCPassCOunt" ForeColor="Black"> </asp:Label>
                                                    </td>
                                                    <td style="text-align: center; width: 15px">
                                                        <asp:Label runat="server" ID="lblQCFailCOunt" ForeColor="Black"> </asp:Label>
                                                    </td>
                                                    <td style="text-align: center; width: 15px">
                                                        <asp:Label runat="server" ID="lblQCFailPercent" ForeColor="Red"> </asp:Label>
                                                    </td>
                                                    <td style="padding-left: 2px !important; width: 155px;">
                                                        <table cellpadding="0" cellspacing="0" width="100%" rules="all" frame="void">
                                                            <tr>
                                                                <asp:Repeater ID="dlstInspection" runat="server" OnItemDataBound="dlstInspection_ItemDataBound">
                                                                    <ItemTemplate>
                                                                        <td runat="server" id="tdInspectionDetails">
                                                                            <asp:Label ID="lblInspectionDetails" runat="server" Text='<%#Eval("InspectionDetails")%>'></asp:Label>
                                                                        </td>
                                                                    </ItemTemplate>
                                                                </asp:Repeater>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="5">
                                                        <asp:Repeater ID="rptQCFaultDetails" OnItemDataBound="rptQCFaultDetails_ItemDataBound" runat="server">
                                                            <ItemTemplate>
                                                                <div style="padding-left: 5px">
                                                                    <asp:Label ID="lblFaultCode" Text='<%#Eval("FaultCode")%>' runat="server" Style="color: blue;"></asp:Label>
                                                                    <asp:Label ID="lblFaultCount" Text='<%#Eval("FaultCount")%>' Style="color: blue; font-weight: bold;" runat="server"></asp:Label>
                                                                    <asp:Label ID="lblFaultPercent" Text='<%#Eval("FaultPercent")%>' Style="color: red; font-weight: bold;" runat="server"></asp:Label>
                                                                </div>
                                                            </ItemTemplate>
                                                        </asp:Repeater>
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <table rules="all" frame="void" width="100%" cellspacing="0" cellpadding="0">
                                            <tbody>
                                                <tr>
                                                    <td style="text-align: center; width: 15px">
                                                        <div style="width: 10px; height: 10px; border-radius: 50%; margin: 0px auto;" runat="server" id="divCircle">
                                                            &nbsp;</div>
                                                    </td>
                                                    <td style="text-align: center; width: 15px">
                                                        <asp:Label runat="server" ID="lblQCPassCountFoo" ForeColor="Black"> </asp:Label>
                                                    </td>
                                                    <td style="text-align: center; width: 15px">
                                                        <asp:Label runat="server" ID="lblQCFailCountFoo" ForeColor="Black"> </asp:Label>
                                                    </td>
                                                    <td style="text-align: center; width: 15px">
                                                        <asp:Label runat="server" ID="lblQCFailPercentFoo" ForeColor="Red"> </asp:Label>
                                                    </td>
                                                    <td style="padding-left: 2px !important; width: 155px;">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="5">
                                                        <asp:Repeater ID="rptQCFaultDetailsFoo" OnItemDataBound="rptQCFaultDetailsFoo_ItemDataBound" runat="server">
                                                            <ItemTemplate>
                                                                <div style="padding-left: 5px">
                                                                    <asp:Label ID="lblFaultCodeFoo" Text='<%#Eval("FaultCode")%>' runat="server" Style="color: blue;"></asp:Label>
                                                                    <asp:Label ID="lblFaultCountFoo" Text='<%#Eval("FaultCount")%>' Style="color: blue; font-weight: bold;" runat="server"></asp:Label>
                                                                    <asp:Label ID="lblFaultPercentFoo" Text='<%#Eval("FaultPercent")%>' Style="color: red; font-weight: bold;" runat="server"></asp:Label>
                                                                </div>
                                                            </ItemTemplate>
                                                        </asp:Repeater>
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </FooterTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="85" HeaderStyle-Width="85" ItemStyle-HorizontalAlign="Left" Visible="false">
                                    <HeaderTemplate>
                                        <table cellpadding="0" cellspacing="0" width="100%">
                                            <tr>
                                                <td>
                                                    Inspection
                                                </td>
                                            </tr>
                                        </table>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="180" HeaderStyle-Width="180" ItemStyle-HorizontalAlign="Left">
                                    <HeaderTemplate>
                                        <table cellpadding="0" cellspacing="0" width="100%">
                                            <tr>
                                                <td>
                                                    Remark
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="border-bottom: 1px solid #bfbfbf">
                                                    Top Bottle Neck Description
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <table rules="all" frame="void" width="100%" cellspacing="0" cellpadding="0">
                                                        <tbody>
                                                            <tr>
                                                                <td style="width: 120px;">
                                                                    Operation
                                                                </td>
                                                                <td style="width: 20px;">
                                                                    Agreed Cpty
                                                                </td>
                                                                <td style="width: 20px;">
                                                                    Act. Output
                                                                </td>
                                                                <td style="width: 20px;">
                                                                    dump pcs
                                                                </td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <table cellpadding="5px" cellspacing="1px" width="100%" border="1" rules="all" frame="void">
                                            <tr>
                                                <td colspan="4">
                                                    <span style="color: Black;">
                                                        <%#Eval("Remark")%>
                                                    </span>
                                                </td>
                                            </tr>
                                            <asp:Repeater ID="rptBottleNeck" OnItemDataBound="BottleNeck_ItemDataBound" runat="server">
                                                <ItemTemplate>
                                                    <tr>
                                                        <td style="width: 120px; padding-left: 5px !important">
                                                            <asp:Label runat="server" ID="lblFactoryWorkSpace" Text='<%#Eval("FactoryWorkSpace")%>' ForeColor="Blue"> </asp:Label>
                                                            <asp:HiddenField ID="hdnSectionName" Value='<%#Eval("OBSectionName")%>' runat="server" />
                                                        </td>
                                                        <td style="width: 20px; text-align: center;">
                                                            <asp:Label runat="server" ID="lblTgtAgrdQuantity" Text='<%#Eval("TgtAgrdQuantity")%>' ForeColor="Black"> </asp:Label>
                                                        </td>
                                                        <td style="width: 20px; text-align: center;">
                                                            <asp:Label runat="server" ID="lblActOutPut" Text='<%#Eval("PerHrPcs")%>' ForeColor="Black"> </asp:Label>
                                                        </td>
                                                        <td style="width: 20px; text-align: center;">
                                                            <asp:Label runat="server" ID="lblDumpPcs" Text='<%#Eval("DumpPcs")%>' ForeColor="Red"> </asp:Label>
                                                        </td>
                                                    </tr>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </table>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="40" HeaderStyle-Width="40" ItemStyle-CssClass="check_box_text">
                                    <HeaderTemplate>
                                        <table cellpadding="0" cellspacing="0" border="0" width="100%" frame="void" rules="all" class="line_td">
                                            <tr>
                                                <td colspan="2">
                                                    Is Closed
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: center; width: 50%; height: 15px">
                                                    Sth
                                                </td>
                                                <td style="text-align: center; width: 50%; height: 15px">
                                                    Fin
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: center; width: 50%; height: 15px">
                                                    Day
                                                </td>
                                                <td style="text-align: center; width: 50%; height: 15px">
                                                    H S
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    Ld. Stch.
                                                </td>
                                            </tr>
                                        </table>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <table cellpadding="0" cellspacing="0" border="0" width="100%" frame="void" rules="all" class="line_td">
                                            <tr>
                                                <td style="text-align: center; width: 50%; height: 20px">
                                                    <asp:CheckBox ID="chkIsStitched" Checked='<%# Eval("IsStitched") %>' runat="server" Enabled="false" />
                                                </td>
                                                <td style="text-align: center; width: 50%; height: 20px">
                                                    <asp:CheckBox ID="chkIsFinished" Checked='<%# Eval("IsFinished") %>' runat="server" Enabled="false" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: center; width: 50%; height: 20px">
                                                    <asp:CheckBox ID="chkMarkAsDayClose" Checked='<%# Eval("IsDayClosed") %>' runat="server" Enabled="false" />
                                                </td>
                                                <td style="text-align: center; width: 50%; height: 20px">
                                                    <asp:CheckBox ID="chkHalfStitch" Checked='<%# Eval("IsHalfStitched") %>' runat="server" Enabled="false" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <asp:CheckBox ID="ChkLoadStitch" Checked='<%# Eval("CheckRequiredActualOb") %>' runat="server" Enabled="false" />
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="450" HeaderStyle-Width="450" ItemStyle-HorizontalAlign="Left">
                                    <HeaderTemplate>
                                        <table cellpadding="5px" cellspacing="0" width="100%" style="border-collapse: collapse;">
                                            <tr>
                                                <td colspan="4" style="border-bottom: 1px solid #999999;">
                                                    Line/Designation
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: center; width: 10%; border-right: 1px solid #999999">
                                                    L. M.
                                                </td>
                                                <td style="text-align: center; width: 10%; border-right: 1px solid #999999">
                                                    F. I.
                                                </td>
                                                <td style="text-align: center; width: 10%; border-right: 1px solid #999999">
                                                    QC
                                                </td>
                                                <td style="text-align: center; width: 70%;">
                                                    <table cellpadding="0" cellspacing="0" border="0" frame="void" rules="all" width="100%" style="border-right: 1px solid #ccc; border-collapse: collapse;">
                                                        <tr>
                                                            <td width="42px">
                                                                PL Qty
                                                            </td>
                                                            <td width="42px">
                                                                SAM
                                                            </td>
                                                            <td width="69px">
                                                                1<sup>st</sup> Ex. Dt.
                                                            </td>
                                                            <td width="49px">
                                                                Last Ex. Dt.
                                                            </td>
                                                            <td width="40px">
                                                                Cut WIp
                                                            </td>
                                                            <td width="63px">
                                                                S.C
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="4" style="border-top: 1px solid #999999;">
                                                    UnShipped Style Code Pending Quantity Details
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="4">
                                                    <table rules="all" style="width: 100%; border-color: #c2c2c2; border-collapse: collapse;" cellspacing="0" border="1">
                                                        <tbody>
                                                            <tr>
                                                                <td class="align-center" valign="top">
                                                                    <span style="text-transform: capitalize;">Pnd St. Qty (fin. Qty)</span>
                                                                </td>
                                                                <td rowspan="3" style="width: 60px;">
                                                                    Style Image
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="align-center" valign="top">
                                                                    <span style="text-transform: capitalize;">St. Est Cmpl. (Est Hrs.)</span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="align-center" valign="top">
                                                                    <span style="text-transform: capitalize;">Fin. Est Cmpl. (Est Hrs.)</span>
                                                                </td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <table cellpadding="0" cellspacing="0" width="100%" border="0" style="border-collapse: collapse;">
                                            <tr>
                                                <td style="width: 30%">
                                                    <asp:DataList ID="dlstLineDesignation" RepeatDirection="Horizontal" Width="100%" runat="server" frame="void" rules="all">
                                                        <ItemTemplate>
                                                            <table cellpadding="0" cellspacing="0" width="100%">
                                                                <tr>
                                                                    <td style="text-align: center; width: 100%;">
                                                                        <%#Eval("LineManName") %>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </ItemTemplate>
                                                        <ItemStyle Width="33%" />
                                                    </asp:DataList>
                                                </td>
                                                <td id="tdUpcomingStyle" runat="server" style="border-right: 1px solid #ccc; text-align: center; font-size: 9px; font-weight: normal; width: 70%;">
                                                    <asp:Label ID="lblUpcommingStyle" runat="server"></asp:Label>
                                                    <table cellpadding="0" cellspacing="0" border="1" frame="void" rules="all" width="100%" runat="server" id="tableUpComingStyle" style="border-collapse: collapse; border-left: 1px solid #999999;">
                                                        <tr>
                                                            <td width="42px" style="text-align: center;">
                                                                <asp:Label runat="server" ID="lblUpcomingPndgStitchQty" ForeColor="Black"></asp:Label>
                                                            </td>
                                                            <td width="42px" style="text-align: center;">
                                                                <asp:Label runat="server" ID="lblUpcomingPndgsAM" ForeColor="Black"></asp:Label>
                                                            </td>
                                                            <td width="69px" style="text-align: center;">
                                                                <asp:Label runat="server" ID="lblFistExFactoryDate" ForeColor="Black" Font-Bold="true"></asp:Label>
                                                            </td>
                                                            <td width="49px" style="text-align: center;">
                                                                <asp:Label runat="server" ID="lblLastExFactoryDate" ForeColor="Black" Font-Bold="true"></asp:Label>
                                                            </td>
                                                            <td width="40px" style="text-align: center;">
                                                                <asp:Label runat="server" ID="lblUpcomingCutWip" ForeColor="Black"></asp:Label>
                                                            </td>
                                                            <td id="tdUpcomingStyleCode" runat="server" width="63px" style="text-align: center;">
                                                                <asp:Label runat="server" ID="lblUpcomingStyleCode" ForeColor="Black"></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <table cellpadding="0" cellspacing="0" width="100%" rules="all" frame="void">
                                                        <tr>
                                                            <td style="vertical-align: top">
                                                                <asp:GridView ID="gvPending" AutoGenerateColumns="false" CssClass="item_list" runat="server" OnRowDataBound="gvPending_RowDataBound" Style="width: 100%; border-color: #c2c2c2;">
                                                                    <Columns>
                                                                        <%-- Column 0--%>
                                                                        <asp:TemplateField HeaderStyle-Width="60px" ItemStyle-Width="60px" ItemStyle-CssClass="align-center" Visible="false">
                                                                            <HeaderTemplate>
                                                                            </HeaderTemplate>
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblPendingCol" runat="server" Text='<%# Eval("PendingCol") %>' Style="text-transform: capitalize;"></asp:Label>
                                                                            </ItemTemplate>
                                                                            <ItemStyle VerticalAlign="Top" />
                                                                        </asp:TemplateField>
                                                                        <%-- Column 1--%>
                                                                        <asp:TemplateField HeaderStyle-Width="20%" ItemStyle-Width="20%" HeaderStyle-CssClass="align-center">
                                                                            <HeaderTemplate>
                                                                                <asp:Label ID="lblExFactoryHdr1" runat="server" Text=""></asp:Label>
                                                                            </HeaderTemplate>
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblExFactory1" runat="server" Text=""></asp:Label>
                                                                            </ItemTemplate>
                                                                            <ItemStyle VerticalAlign="Top" />
                                                                        </asp:TemplateField>
                                                                        <%-- Column 2--%>
                                                                        <asp:TemplateField HeaderStyle-Width="20%" ItemStyle-Width="20%" HeaderStyle-CssClass="align-center">
                                                                            <HeaderTemplate>
                                                                                <asp:Label ID="lblExFactoryHdr2" runat="server" Text=""></asp:Label>
                                                                            </HeaderTemplate>
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblExFactory2" runat="server" Text=""></asp:Label>
                                                                            </ItemTemplate>
                                                                            <ItemStyle VerticalAlign="Top" />
                                                                        </asp:TemplateField>
                                                                        <%-- Column 3--%>
                                                                        <asp:TemplateField HeaderStyle-Width="20%" ItemStyle-Width="20%" HeaderStyle-CssClass="align-center">
                                                                            <HeaderTemplate>
                                                                                <asp:Label ID="lblExFactoryHdr3" runat="server" Text=""></asp:Label>
                                                                            </HeaderTemplate>
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblExFactory3" runat="server" Text=""></asp:Label>
                                                                            </ItemTemplate>
                                                                            <ItemStyle VerticalAlign="Top" />
                                                                        </asp:TemplateField>
                                                                        <%-- Column 4--%>
                                                                        <asp:TemplateField HeaderStyle-Width="20%" ItemStyle-Width="20%" HeaderStyle-CssClass="align-center">
                                                                            <HeaderTemplate>
                                                                                <asp:Label ID="lblExFactoryHdr4" runat="server" Text=""></asp:Label>
                                                                            </HeaderTemplate>
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblExFactory4" runat="server" Text=""></asp:Label>
                                                                            </ItemTemplate>
                                                                            <ItemStyle VerticalAlign="Top" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderStyle-Width="20%" ItemStyle-Width="20%" HeaderStyle-CssClass="align-center">
                                                                            <HeaderTemplate>
                                                                                <asp:Label ID="lblExFactoryHdr5" runat="server" Text=""></asp:Label>
                                                                            </HeaderTemplate>
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblExFactory5" runat="server" Text=""></asp:Label>
                                                                            </ItemTemplate>
                                                                            <ItemStyle VerticalAlign="Top" />
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                </asp:GridView>
                                                            </td>
                                                            <td style="width: 60px">
                                                                <img id="imgStyleIdImgPath" runat="server" style="height: 55px !important; width: 60px !important;" />
                                                                <asp:HiddenField runat="server" ID="hdnimgStyleIdImgPath" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td id="Stitch1EmptyMsg" class="empty-msg" runat="server" visible="false">
                        <div style="border-bottom: 1px dashed #ccc;">
                            <asp:Label ID="lblStitch1EmptyMsg1" runat="server" Text=""></asp:Label>
                        </div>
                        <asp:Label ID="lblStitch1EmptyMsg2" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <h3 style="background: #dddfe4 !important; color: #575759 !important; font-size: 11px; padding: 5px">
                            <font color="red">*</font>Slot Detail</h3>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:GridView ID="grvSlotTiming" runat="server" OnRowDataBound="grvSlotTiming_RowDataBound" CssClass="timetable" AutoGenerateColumns="false">
                            <Columns>
                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center">
                                    <HeaderTemplate>
                                        Slot 1
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblSlot1Timing" runat="server" Text=""></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center">
                                    <HeaderTemplate>
                                        Slot 2
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblSlot2Timing" runat="server" Text=""></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center">
                                    <HeaderTemplate>
                                        Slot 3
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblSlot3Timing" runat="server" Text=""></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center">
                                    <HeaderTemplate>
                                        Slot 4
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblSlot4Timing" runat="server" Text=""></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center">
                                    <HeaderTemplate>
                                        Slot 5
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblSlot5Timing" runat="server" Text=""></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center">
                                    <HeaderTemplate>
                                        Slot 6
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblSlot6Timing" runat="server" Text=""></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center">
                                    <HeaderTemplate>
                                        Slot 7
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblSlot7Timing" runat="server" Text=""></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center">
                                    <HeaderTemplate>
                                        Slot 8
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblSlot8Timing" runat="server" Text=""></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center">
                                    <HeaderTemplate>
                                        Slot 9
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblSlot9Timing" runat="server" Text=""></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center">
                                    <HeaderTemplate>
                                        Slot 10
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblSlot10Timing" runat="server" Text=""></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center">
                                    <HeaderTemplate>
                                        Slot 11
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblSlot11Timing" runat="server" Text=""></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center">
                                    <HeaderTemplate>
                                        Slot 12
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblSlot12Timing" runat="server" Text=""></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center">
                                    <HeaderTemplate>
                                        Slot 13
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblSlot13Timing" runat="server" Text=""></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center">
                                    <HeaderTemplate>
                                        Slot 14
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblSlot14Timing" runat="server" Text=""></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center">
                                    <HeaderTemplate>
                                        Slot 15
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblSlot15Timing" runat="server" Text=""></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center">
                                    <HeaderTemplate>
                                        Slot 16
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblSlot16Timing" runat="server" Text=""></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td id="Stitching" runat="server">
                        <asp:HiddenField ID="hdnProductionUnit" runat="server" />
                        <asp:HiddenField ID="hdnSlotId" runat="server" />
                        <asp:HiddenField ID="hdnStartDate" runat="server" />
                        <%-- <h2 style="background: #3a5695; color: #fff; text-align: center; font-family: arial;
                            font-size: 16px; padding: 2px 0px;">
                            Hourly Production Report</h2>--%>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <asp:Button ID="btnSendMail" Visible="false" runat="server" Text="Send via Mail" OnClick="btnSendMail_Click" />
</table>
