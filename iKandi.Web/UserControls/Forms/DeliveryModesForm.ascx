<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DeliveryModesForm.ascx.cs" Inherits="iKandi.Web.DeliveryModesForm" %>
<link href="../../css/jquery-combined.css" rel="stylesheet" type="text/css" />
<script src="../../js/jquery-1.11.0.min.js" type="text/javascript"></script>
<script src="../../js/jquery-1.9.0-jquery.min.js" type="text/javascript"></script>
<script src="../../js/jqueryui-1.9.1-jquery-ui.min.js" type="text/javascript"></script>
<script type="text/javascript" src="../../js/service.min.js"></script>
<script type="text/javascript" src="../../js/form.js"></script>
<script type="text/javascript" src="../../js/facebox.js"></script>
<script src="../../js/CostRange/ProDuctShadowBox.js" type="text/javascript"></script>
<style>
    body {
        font-family: Arial;
        font-size: 11px;
    }
    .AddClass_Table {
        border-collapse: collapse;
        font-family: Arial;
        max-width: 975px;
        border: 1px solid #999;
    }
    .AddClass_Table th {
        background: #dddfe4;
        border: 1px solid #999;
        border-collapse: collapse;
        font-size: 11px;
        font-weight: 500;
        padding: 3px 3px;
        color: #6b6464;
        font-family: Arial;
        text-align: left;
    }
    .RightSide table {
        border-collapse: collapse;
    }
    .RightSide table th {
        color: #6b6464;
        font-weight: 500;
        border: 1px solid #d2d2d2;
        padding: 5px 5px;
    }
    .RightSide table td {
        border: 1px solid #dbd8d8;
        padding: 5px 5px;
    }
    .minWidthTh {
        min-width: 80px;
    }
    .minWidthThSize {
        min-width: 120px;
    }
    .AddClass_Table td {
        border: 1px solid #dbd8d8;
        font-size: 11px;
        padding: 0px 3px;
        color: #0c0c0c;
        height: 12px;
        font-family: Arial;
        min-width: 80px;
    }
    .AddClass_Table td:first-child {
        border-left-color: #999 !important;
    }
    .AddClass_Table td:last-child {
        border-right-color: #999 !important;
    }
    
    .AddClass_Table.MarTop th {
        text-align: center;
    }
    .AddClass_Table.MarTop td {
        text-align: center;
    }
    .ColorBlackBold {
        color: #000;
        font-weight: 600;
    }
    .ColorBlue {
        color: blue;
    }
    .ColorGray {
        color: gray;
    }
    .ColorGrayBold {
        color: gray;
        font-weight: 600;
    }
    .ColorRedStrick {
        color: red;
        position: relative;
        top: -2px;
    }
    .TopHeader {
        width: 100%;
        font-size: 15px;
        color: #fff;
        text-align: center;
        background: #39589C;
        margin-bottom: 5px;
        padding: 3px 0px;
        position: relative;
    }
    .TopHeader span {
        color: #fff;
    }
    
    td.minWidth {
        min-width: 104px;
    }
    .txtCenter {
        text-align: center;
    }
    th.txtCenter {
        text-align: center;
    }
    .GrdtxtControl {
        width: 85%;
        margin: 2px 2px;
    }
    .MarTop {
        margin-top: 5px;
    }
    td.RadioLable {
        width: 100px;
    }
    td.RadioLable label {
        position: relative;
        top: -3px;
    }
    .facolor {
        font-size: 15px;
    }
    .bordertable i {
        font-size: 12px;
        margin: 0 2px;
    }
    .editbucolor {
        color: green;
    }
    .m-r-5 {
        margin-right: 5px;
    }
    .TotalRw td {
        text-align: center;
        font-size: 13px;
        background: #f1f1f1;
        font-weight: 600;
        padding: 3px 5px;
    }
    ul {
        margin: 0px;
        padding: 5px 0px 0px 14px;
    }
    ul li {
        padding: 5px 0px 0px 0px;
        color: gray;
    }
    .RightSide input[type="radio"] {
        position: relative;
        top: 2px;
    }
    .RightSide {
        /* box-shadow: -13px -2px 36px -2px #ccc; */
        box-shadow: 1px 0px 5px 1px #ccc;
        padding: 10px 10px;
        position: relative;
        top: 6px;
        padding-top: 30px;
    }
    input[type="checkbox"] {
        position: relative;
        top: 2px;
    }
    .GMCheckbox {
        text-align: left;
        padding-right: 10px;
        padding-top: 60px;
        padding-bottom: 0px;
        font-size: 12px;
        width: 117px;
        float: right;
    }
    .QACheckbox {
        text-align: left;
        padding-right: 10px;
        padding-top: 10px;
        font-size: 12px;
        width: 246px;
        float: left;
    }
    .QACheckbox2 {
        text-align: right;
    }
    .AllChecker {
        text-align: center;
        padding-top: 30px;
        clear: both;
    }
    .btnSubmit {
        font-size: 12px;
        padding: 5px 10px;
        color: #fff;
        background: green;
        margin-right: 5px;
        border-radius: 2px;
        border: 1px solid green;
        cursor: pointer;
    }
    .btnClose {
        font-size: 12px;
        padding: 5px 10px;
        color: #fff;
        background: green;
        margin-right: 5px;
        border-radius: 2px;
        cursor: pointer;
    }
    .btnPrint {
        font-size: 12px;
        padding: 5px 15px;
        color: #fff;
        background: #39589C;
        margin-right: 5px;
        border-radius: 2px;
        border: 1px solid #39589C;
        cursor: pointer;
    }
    .RightSide span {
        color: #6b6464;
    }
    .GreigeShrnk {
        position: absolute;
        left: 5px;
        font-size: 12px;
        top: 5px;
        color: #d8d8d8;
    }
    .ReshShrnk {
        position: absolute;
        left: 133px;
        font-size: 12px;
        top: 5px;
        color: #d8d8d8;
    }
    
    .ChangePositionReshShrnk {
        position: fixed;
        left: 0px;
        font-size: 12px;
        top: 5px;
        color: #d8d8d8;
        margin-left: 10px;
    }
    .ChangePositionlblShrinkage {
        position: fixed;
        left: 77px;
        font-size: 12px;
        top: 5px;
        color: #d8d8d8;
    }
    .GreigeShrnk span {
        color: #d8d8d8;
    }
    .ReshShrnk span {
        color: #d8d8d8;
    }
    .DisplayBlock {
        display: block;
        width: 116px;
    }
    .DisplayBlock .txtRaise {
        width: 36px;
        height: 11px;
        text-align: center;
        margin: 2px 2px;
    }
    .DisInlineBlock {
        width: 65px;
        display: inline-block;
    }
    .LavContainer {
        padding-top: 1px;
    }
    .LavContainer span {
        color: #6b6464;
    }
    .LavContainer table {
        border-collapse: collapse;
        width: 98%;
    }
    .LavContainer table th {
        color: #6b6464;
        font-weight: 500;
        border: 1px solid #999;
        padding: 5px 5px;
        background: #f2f2f2;
    }
    .LavContainer table td {
        border: 1px solid #d2d2d2;
        padding: 4px 4px;
    }
    .txtWidth {
        float: left;
        height: 10px;
        width: 30px;
    }
    #fileToUpload {
        width: 84px;
        font-size: 10px;
    }
    select {
        font-size: 10px;
    }
    .RightSidedate {
        float: right;
        position: relative;
        top: 2px;
    }
    
    .Passfail {
        background: #fff1f1;
    }
    .Passfail label {
        position: relative;
        top: -2px;
    }
    input[type="text"] {
        font-size: 11px;
        width: 95%;
        text-transform: capitalize;
        margin: 2px 0px;
    }
    .BalckgroundColor {
        background: #fff1f1;
    }
    textarea {
        text-transform: capitalize;
        font-size: 10px;
    }
    #dvHistory {
        width: 98%;
        padding: 6px 0px;
        height: 47px;
        max-height: 47px;
        overflow: auto;
    }
    a {
        text-decoration: none;
    }
    .TotalTable {
        border: 0px;
        border-collapse: collapse;
        width: 973px;
    }
    .TotalTable td {
        border: 1px solid #d2d2d2;
        border-top: 0px;
        min-width: 96px;
        padding: 5px 0px;
        border-bottom-color: #999;
    }
    
    #grv_Accessories_Inspection td input[type='text'] {
        text-align: center;
        font-size: 11px;
        height: 13px;
        margin: 2px 0px;
    }
    #totalAccInspection td {
        text-align: center;
        font-size: 12px;
        font-weight: bold;
    }
    
    #grv_Accessories_Inspection {
        max-width: 975px;
    }
    #grv_Accessories_Inspection td {
        min-width: 90px;
        max-width: 90px;
    }
    .EmptyRowTable td {
        padding: 0px 0px !important;
        border: 0px;
    }
    .EmptyRowTable td[colspan="10"] {
        padding: 0px 0px !important;
        border: 0px;
    }
    .EmptyRowTable td table.EmptyTable {
        width: 973px;
    }
    .EmptyRowTable td .EmptyTable th {
        min-width: 90px;
        max-width: 90px;
    }
    .EmptyRowTable td .EmptyTable td {
        border: 1px solid #9999;
    }
    .EmptyRowTable td .EmptyTable td input[type="text"] {
        width: 85%;
    }
    ::-webkit-scrollbar {
        width: 8px;
        height: 8px;
    }
    ::-webkit-scrollbar-thumb {
        background: #999;
        border: 1px solid #ddd7d7;
        border-radius: 10px;
    }
    ul {
        margin: 0px;
        padding: 5px 0px 0px 14px;
    }
    li {
        padding: 5px 0px 0px 0px;
        color: gray;
        list-style: none;
    }
    div.historyDiv {
        margin: 2px 0px;
    }
    div span.CommentBullet {
        width: 5px;
        height: 5px;
        border-radius: 50%;
        display: inline-block;
        background: gray;
        margin-right: 4px;
        margin-left: 5px;
        position: relative;
        top: -1px;
    }
</style>
<script type="text/javascript">



    function SBClose() { }
    function OpenTestReportDelivery(url, id) {
        url += "?Modeid=" + id;

        var width = (screen.width * 90) / 100;
        var height = (screen.height * 70) / 100;
        Shadowbox.init({ animate: true, animateFade: true, modal: true });
        Shadowbox.open({ content: url, type: "iframe", player: "iframe", title: "", height: height, width: width, modal: true, animate: true, animateFade: true, options: { onClose: SBClose} });

        return false;
    }





    function delets(elem) {
        debugger
        var p = o.parentNode.parentNode;
        p.parentNode.removeChild(p);
        return false;
    }
    $(function () {

        //        //        $('table').on('click', 'input[type="button"]', function (e) {
        //        //            $(this).closest('tr').remove()
        //        //        })

        //        $('.color-picker', '#main_content').ColorPicker(
        //        {
        //            onShow: function (colpkr) {
        //                $(colpkr).fadeIn(300);
        //                return false;
        //            },
        //            onHide: function (colpkr) {
        //                $(colpkr).fadeOut(300);
        //                return false;
        //            },
        //            onChange: function (hsb, hex, rgb) {
        //            },
        //            onSubmit: function (hsb, hex, rgb, el) {

        //                $(el).val('#' + hex);

        //                $(el).ColorPickerHide();
        //            }
        //        });
        //        // alert("test");

        //        $("[id*=gotoclientAssociation]").click(function (event) {
        //            debugger;
        //            event.preventDefault();
        //            var Modeid = $("[id*=hdnID]").val();
        //            alert(Modeid);


        //        });


    });



    function ValidateLeadTime(srcElem) {

        var bool = 0;
        var txt = $(srcElem).val();

        if (parseInt(txt) > 0) {
            bool = 1;
            return true;
        }

        if (bool == 0) {
            alert('Value should be greater than Zero');
            $(srcElem).val("1");
            return false;
        }
    }
</script>
<link href="../../css/technical-module.css" rel="stylesheet" type="text/css" />
<style type="text/css">
    .item_list td {
        overflow: hidden;
        padding: 5px 2px !important;
    }
    .item_list th {
        border-color: #999 !important;
        border: 1px solid #999 !important;
    }
 .item_list tr:first-child {
       position:sticky;
       top:-1px;
       z-index:9999999;
    }
  .item_list tr:nth-child(2) {
       position:sticky;
       top:24px;
       z-index:9999999;
    }
   .first_child tbody tr
   {
       z-index:22!important;
   }
    td[colspan="15"] {
        border-left-color: #999 !important;
        border-right-color: #999 !important;
        border-bottom-color: #999 !important;
    }
    .item_list td {
        border-color: #dbd8d8;
    }
    input[type='checkbox'] {
        position: relative;
        top: 3px;
    }
    .hideTd {
        display: none;
    }
    .item_list TD .TxtAreaCl {
        width: 90%;
        height: 60px;
        color: Gray;
    }
    .item_list TD input[type="text"] {
        width: 85%;
    }
    ::-webkit-scrollbar {
        width: 4px;
        height: 4px;
    }
</style>
<div style="clear: both">
    <h2 style="border: 1px solid gray;">
        Modes</h2>
</div>
<table width="1472px" class="item_list form_table" cellpadding="0" cellspacing="0" border="1" style="border-left-color: #999; border-bottom-color: #999; border-right-color: #999;">
    <asp:Repeater ID="rptModes" runat="server" OnItemDataBound="rptModes_ItemDataBound" OnItemCommand="rptModes_ItemCommand">
        <HeaderTemplate>
            <tr>
                <th width="100px" rowspan="2">
                    <span>Supply type</span>
                </th>
                <th width="100px" rowspan="2">
                    mode
                </th>
                <th width="100px" rowspan="2">
                    packing
                </th>
                <th width="100px" rowspan="2">
                    terms
                </th>
                <th width="100px" rowspan="2">
                    code
                </th>
                <th width="100px" style="display: none">
                    system(dc-ex)
                </th>
                <th width="150px" rowspan="2">
                    tooltip
                </th>
                <th width="100px" style="display: none">
                    green range
                </th>
                <th width="100px" style="display: none">
                    amber range
                </th>
                <th width="100px" style="display: none">
                    red range
                </th>
                <th colspan="2">
                    UK & GR
                </th>
                <th colspan="2">
                    US
                </th>
                <th colspan="2">
                    BL
                </th>
                <th colspan="2">
                    Poland
                </th>
                <th colspan="2" class="hideTd">
                    KR
                </th>
                <th colspan="2" class="hideTd">
                    RK
                </th>
                <th width="100px" style="display: none">
                    Color
                </th>
                <th colspan="2">
                    IN
                </th>
                <th colspan="2">
                    NS
                </th>
                <%--    <th width="100px" colspan="2">
                   
                </th>--%>
                <th width="430px" rowspan="2">
                    Is Visible / delivery days
                </th>
                <th width="100px" rowspan="2">
                    Order's Packing Type
                </th>
                <th width="100px" rowspan="2">
                    Clint Association
                </th>
                <th width="20px" rowspan="2">
                    Action
                </th>
            </tr>
            <tr>
                <th style="width: 65px">
                    actual<br />
                    (dc-ex)
                </th>
                <th style="width: 65px">
                    Lead Time
                </th>
                <th style="width: 65px">
                    actual<br />
                    (dc-ex)
                </th>
                <th style="width: 65px">
                    Lead Time
                </th>
                <th style="width: 65px">
                    actual<br />
                    (dc-ex)
                </th>
                <th style="width: 65px">
                    Lead Time
                </th>
                <th style="width: 65px">
                    actual<br />
                    (dc-ex)
                </th>
                <th style="width: 65px">
                    Lead Time
                </th>
                <th style="width: 65px" class="hideTd">
                    actual<br />
                    (dc-ex)
                </th>
                <th style="width: 65px" class="hideTd">
                    Lead Time
                </th>
                <th style="width: 65px" class="hideTd">
                    actual<br />
                    (dc-ex)
                </th>
                <th style="width: 65px" class="hideTd">
                    Lead Time
                </th>
                <th style="width: 65px">
                    actual<br />
                    (dc-ex)
                </th>
                <th style="width: 65px">
                    Lead Time
                </th>
                <th style="width: 65px">
                    actual<br />
                    (dc-ex)
                </th>
                <th style="width: 65px">
                    Lead Time
                </th>
            </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td class="form_small_heading_light_yellow border_left_color">
                    <asp:HiddenField ID="hdnID" runat="server" />
                    <asp:DropDownList ID="ddlSupply" runat="server">
                        <asp:ListItem Value="1">LANDED</asp:ListItem>
                        <asp:ListItem Value="2">DIRECT_EX_FACTORY</asp:ListItem>
                        <asp:ListItem Value="3">DIRECT_EX_PORT</asp:ListItem>
                    </asp:DropDownList>
                    <asp:HiddenField ID="hdnisdeleting" runat="server" Value="0" />
                </td>
                <td class="form_small_heading_light_yellow">
                    <asp:DropDownList ID="ddlMode" runat="server">
                        <asp:ListItem Value="1">SEA</asp:ListItem>
                        <asp:ListItem Value="2">AIR</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="form_small_heading_light_yellow">
                    <asp:DropDownList ID="ddlPacking" runat="server">
                        <asp:ListItem Value="1">HANGING</asp:ListItem>
                        <asp:ListItem Value="2">FLAT</asp:ListItem>
                        <asp:ListItem Value="3">BOX_HANGING</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="form_small_heading_light_yellow">
                    <asp:DropDownList ID="ddlTerms" runat="server">
                        <asp:ListItem Value="1">FOB</asp:ListItem>
                        <asp:ListItem Value="2">CIF</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="form_small_heading_light_yellow">
                    <asp:TextBox ID="txtCode" runat="server" TextMode="MultiLine" CssClass="TxtAreaCl"></asp:TextBox>
                </td>
                <td class="form_small_heading_light_yellow" style="display: none">
                    <asp:TextBox ID="txtSystemdcex" runat="server" CssClass="numeric-field-without-decimal-places"></asp:TextBox>
                </td>
                <td class="form_small_heading_light_yellow">
                    <%-- <asp:TextBox ID="txtActualdcex" runat="server" CssClass="numeric-field-without-decimal-places"></asp:TextBox>--%>
                    <asp:TextBox ID="txtTooltip" runat="server" TextMode="MultiLine" CssClass="TxtAreaCl"></asp:TextBox>
                </td>
                <td class="form_small_heading_light_yellow" style="display: none">
                    <asp:TextBox ID="txtGreenStart" runat="server" Width="20" CssClass="numeric-field-without-decimal-places-negative"></asp:TextBox>
                    To
                    <asp:TextBox ID="txtGreenEnd" Width="20" runat="server" CssClass="numeric-field-without-decimal-places-negative"></asp:TextBox>
                </td>
                <td class="form_small_heading_light_yellow" style="display: none">
                    <asp:TextBox ID="txtAmberStart" runat="server" Width="20" CssClass="numeric-field-without-decimal-places-negative"></asp:TextBox>
                    To
                    <asp:TextBox ID="txtAmberEnd" Width="20" runat="server" CssClass="numeric-field-without-decimal-places-negative"></asp:TextBox>
                </td>
                <td class="form_small_heading_light_yellow" style="display: none">
                    <asp:TextBox ID="txtRedStart" runat="server" Width="20" CssClass="numeric-field-without-decimal-places-negative"></asp:TextBox>
                    To
                    <asp:TextBox ID="txtRedEnd" Width="20" runat="server" CssClass="numeric-field-without-decimal-places-negative"></asp:TextBox>
                </td>
                <td class="form_small_heading_light_yellow">
                    <%--<asp:TextBox ID="txtTooltip" runat="server" CssClass=""></asp:TextBox>--%>
                    <asp:TextBox ID="txtActualdcex" runat="server" CssClass="numeric-field-without-decimal-places"></asp:TextBox>
                </td>
                <td class="form_small_heading_light_yellow" style="display: none">
                    <asp:TextBox ID="txtColor" runat="server" CssClass="color-picker do-not-allow-typing"></asp:TextBox>
                </td>
                <td class="form_small_heading_light_yellow">
                    <asp:TextBox ID="txtLeadTime" runat="server" CssClass=""></asp:TextBox>
                </td>
                <td class="form_small_heading_light_yellow">
                    <asp:TextBox ID="txtUSSystemEXDC" runat="server"></asp:TextBox>
                </td>
                <td class="form_small_heading_light_yellow">
                    <asp:TextBox ID="txtUSLeadTime" runat="server"></asp:TextBox>
                </td>
                <td class="form_small_heading_light_yellow">
                    <asp:TextBox ID="txtBLSystemEXDC" runat="server"></asp:TextBox>
                </td>
                <td class="form_small_heading_light_yellow">
                    <asp:TextBox ID="txtBLLeadTime" runat="server"></asp:TextBox>
                </td>
                <%-- add code by bharat on 06-Dec-19--%>
                <td class="form_small_heading_light_yellow">
                    <asp:TextBox ID="txtPLSystemEXDC" runat="server"></asp:TextBox>
                </td>
                <td class="form_small_heading_light_yellow">
                    <asp:TextBox ID="txtPLLeadTime" runat="server"></asp:TextBox>
                </td>
                <td class="form_small_heading_light_yellow hideTd">
                    <asp:TextBox ID="txtKRSystemEXDC" runat="server"></asp:TextBox>
                </td>
                <td class="form_small_heading_light_yellow hideTd">
                    <asp:TextBox ID="txtKRLeadTime" runat="server"></asp:TextBox>
                </td>
                <td class="form_small_heading_light_yellow hideTd">
                    <asp:TextBox ID="txtRKSystemEXDC" runat="server"></asp:TextBox>
                </td>
                <td class="form_small_heading_light_yellow hideTd">
                    <asp:TextBox ID="txtRKLeadTime" runat="server"></asp:TextBox>
                </td>
                <td class="form_small_heading_light_yellow">
                    <asp:TextBox ID="txtINSystemEXDC" runat="server"></asp:TextBox>
                </td>
                <td class="form_small_heading_light_yellow">
                    <asp:TextBox ID="txtINLeadTime" runat="server"></asp:TextBox>
                </td>
                <td class="form_small_heading_light_yellow">
                    <asp:TextBox ID="txtNSSystemEXDC" runat="server"></asp:TextBox>
                </td>
                <td class="form_small_heading_light_yellow">
                    <asp:TextBox ID="txtNSLeadTime" runat="server"></asp:TextBox>
                </td>
                <%-- end code by bharat on 06-Dec-19--%>
                <td class="form_small_heading_light_yellow">
                    Is Visible<asp:CheckBox ID="chkDelete" runat="server" />
                    &nbsp;&nbsp;<asp:CheckBoxList ID="ckhdays" runat="server" RepeatDirection="Horizontal" CssClass="first_child">
                        <asp:ListItem Value="1">Monday</asp:ListItem>
                        <asp:ListItem Value="2">Tuesday</asp:ListItem>
                        <asp:ListItem Value="3">Wednesday</asp:ListItem>
                        <asp:ListItem Value="4">Thursday</asp:ListItem>
                        <asp:ListItem Value="5">Friday</asp:ListItem>
                        <asp:ListItem Value="6">Saturday</asp:ListItem>
                    </asp:CheckBoxList>
                </td>
                <td class="form_small_heading_light_yellow">
                    <asp:DropDownList ID="ddlTypeOfPacking" runat="server">
                    </asp:DropDownList>
                </td>
                <td valign="top" class="border_right_color">
                    <%--      <asp:ListBox ID="Listclientname" ToolTip="Press (Shift+End/Home key for select all or go up & down)"
                        runat="server" AppendDataBoundItems="true" Style="width: 150px" SelectionMode="Multiple"
                        BackColor="Beige"  >
                        <asp:ListItem Selected="True" style="color: Maroon; text-decoration: line-through;"
                            Value="0">None</asp:ListItem>
                    </asp:ListBox>--%>
                    <a id="gotoclientAssociation" onclick="OpenTestReportDelivery('ClientAssociation.aspx','<%# Eval("Id") %>')">view client map</a> <span style="font-size: 8px;"></span>
                </td>
                <td class="form_small_heading_light_yellow">
                    <asp:LinkButton ForeColor="black" Width="50px" ID="lnkDelete" ToolTip="Delete this mode" runat="server" CommandName="Delete" OnClientClick="return  confirm('Are you sure you want to delete?')"> <img src="../../images/delete-icon.png" /> </asp:LinkButton>
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            <tr>
                <td style="text-align: right;" colspan="15">
                    <asp:Button runat="server" ID="btnAddNewRow" CssClass="da_submit_button" Text="Add" CommandName="AddRow" />
                </td>
            </tr>
        </FooterTemplate>
    </asp:Repeater>
</table>
<br />
<div class="form_buttom">
    <asp:Button runat="server" ID="btnSubmit" CssClass="da_submit_button submit" Text="Submit" OnClientClick="" OnClick="btnSubmit_Click" />
</div>
