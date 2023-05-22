<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AccessorySupplierQuotation.aspx.cs"
    Inherits="iKandi.Web.Internal.Accessory.AccessoryGrease_Finish_Supplier" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<link href="../../css/colorbox.css" rel="stylesheet" type="text/css" />
<link href="../../css/jquery-combined.css" rel="stylesheet" type="text/css" />

 <script src="../../js/jquery-1.9.0-jquery.min.js" type="text/javascript"></script>
    <script src="../../js/jqueryui-1.9.1-jquery-ui.min.js" type="text/javascript"></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("../../js/jquery-1.4.4.min.js")%>'></script>
    <script type="text/javascript" src="../../js/service.min.js"></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("../../js/jquery.autocomplete.js")%>'></script>
    <script src="../../js/jquery-1.11.0.min.js" type="text/javascript"></script>
    <link rel="stylesheet" type="text/css" href="../../css/jquery-combined.css" />
    <script type="text/javascript" src="../../js/jquery-1.5.2-jquery.min.js"></script>
    <script type="text/javascript" src="../../js/combined_jquery_scripts4.js"></script>
    <script type="text/javascript" src="../../js/form.js"></script>



<%--<script type="text/javascript" src="../../js/jquery-1.4.4.min.js"></script>
<script type="text/javascript" src="../../js/service.min.js"></script>
<script type="text/javascript" src="../../js/jquery.autocomplete.js"></script>
<script src="../../js/jquery-1.11.0.min.js" type="text/javascript"></script>
<script type="text/javascript" src="../../js/form.js"></script>
<script type="text/javascript" src="../../js/jquery-1.5.2-jquery.min.js"></script>
<script type="text/javascript" src="../../js/combined_jquery_scripts4.js"></script>
<script type="text/javascript" src='<%= Page.ResolveUrl("~/js/facebox.js")%>'></script>--%>

<script type="text/javascript">
    var serviceUrl = '<%= ResolveUrl("~/Webservices/iKandiService.asmx/") %>';
    var proxy = new ServiceProxy(serviceUrl);

    var SupplierId = -1;
    var AccessoryMasterId = -1;
    var AccessorySize = -1;
    var QuotedRate = -1;
    var QuotedLeadTime = -1;
    var ColorPrint = '';

    $(document).ready(function () {
        $(".tab1").click(function () {
            $(this).addClass('activeback').siblings().removeClass('activeback');
        });

        $("#hdntabvalue").val('GRIEGE')
        $(".clsDivHdr").html("Pending Griege Orders Supplier View");
        $("#grdGriege").show();
        $(".tab1greige").addClass('activeback');
        $(".tab1Process").removeClass('activeback');
        $(".tab1finished").removeClass('activeback');
        $("#grdProcess").hide();
        $("#grdFinish").hide();

    });

    function ShowHideSuppliergrd(type) {
        //debugger;
        $("#hdntabvalue").val(type);

        $(".clsBtnTab").click();
    }


    function SaveAccessorySupplierQuotation(elem, type) {
        //debugger;
        var Idsn = elem.id.split("_");
        var elemVal = $(elem).val();
        var Save = 0;
        if (type == 1) {
            SupplierId = $("#<%= grdGriege.ClientID %>_" + Idsn[1] + "_hdnSupplierID").val();
            AccessoryMasterId = $("#<%= grdGriege.ClientID %>_" + Idsn[1] + "_hdAccessoryMasterId").val();
            AccessorySize = $("#<%= grdGriege.ClientID %>_" + Idsn[1] + "_hdnAccessoryQualitySize").val();
            QuotedRate = $("#<%= grdGriege.ClientID %>_" + Idsn[1] + "_txtquotedval").val();
            QuotedLeadTime = $("#<%= grdGriege.ClientID %>_" + Idsn[1] + "_txtdays").val();
            ColorPrint = $("#<%= grdGriege.ClientID %>_" + Idsn[1] + "_hdnColorprint").val();
        }
        if (type == 2) {
            SupplierId = $("#<%= grdProcess.ClientID %>_" + Idsn[1] + "_hdnSupplierID").val();
            AccessoryMasterId = $("#<%= grdProcess.ClientID %>_" + Idsn[1] + "_hdAccessoryMasterId").val();
            AccessorySize = $("#<%= grdProcess.ClientID %>_" + Idsn[1] + "_hdnAccessoryQualitySize").val();
            QuotedRate = $("#<%= grdProcess.ClientID %>_" + Idsn[1] + "_txtquotedval").val();
            QuotedLeadTime = $("#<%= grdProcess.ClientID %>_" + Idsn[1] + "_txtdays").val();
            ColorPrint = $("#<%= grdProcess.ClientID %>_" + Idsn[1] + "_hdnColorprint").val();
        }
        if (type == 3) {
            SupplierId = $("#<%= grdFinish.ClientID %>_" + Idsn[1] + "_hdnSupplierID").val();
            AccessoryMasterId = $("#<%= grdFinish.ClientID %>_" + Idsn[1] + "_hdAccessoryMasterId").val();
            AccessorySize = $("#<%= grdFinish.ClientID %>_" + Idsn[1] + "_hdnAccessoryQualitySize").val();
            QuotedRate = $("#<%= grdFinish.ClientID %>_" + Idsn[1] + "_txtquotedval").val();
            QuotedLeadTime = $("#<%= grdFinish.ClientID %>_" + Idsn[1] + "_txtdays").val();
            ColorPrint = $("#<%= grdFinish.ClientID %>_" + Idsn[1] + "_hdnColorprint").val();
        }
        if (QuotedRate == '')
            QuotedRate = -1;

        if (QuotedLeadTime == '')
            QuotedLeadTime = -1;

        if (confirm("Are you sure want to update ?")) {
            proxy.invoke("Save_Accessory_Supplier_Quotation", { SupplierID: SupplierId, AccessoryMasterId: AccessoryMasterId, Size: AccessorySize, ColorPrint: ColorPrint, QuotedLandedRate: QuotedRate, LeadTimes: QuotedLeadTime, type: type },
                function (result) {
                    //debugger;
                    if (parseInt(result) > 0) {
                        Save = 1;
                        $(elem).val(elemVal);
                        //jQuery.facebox('Saved Successfully');
                    }
                });
        }
        if (Save == 0) {
            $(elem).val('');
            jQuery.facebox('Some error occured during saving');
        }

    }
    function pageLoad() {
        // alert();
        // added code by bharat on 24-Sep 
        var maxRow = 0;
        var rowSpan = 0;
        $('.GrdGriegeTable td[rowspan]').each(function () {
            var row = $(this).parent().parent().children().index($(this).parent());
            if (row > maxRow) {
                maxRow = row;
                rowSpan = 0;
            }
            if ($(this).attr('rowspan') > rowSpan) rowSpan = $(this).attr('rowspan');
        });
        if (maxRow == $('.GrdGriegeTable tr:last td').parent().parent().children().index($('.GrdGriegeTable tr:last td').parent()) - (rowSpan - 1)) {
            $('.GrdGriegeTable td[rowspan]').each(function () {
                var row = $(this).parent().parent().children().index($(this).parent());
                if (row == maxRow && $(this).attr('rowspan') == rowSpan) $(this).addClass('border_last_bottom_color');
            });
        }

        var maxRowGSh = 0;
        var rowSpanGSh = 0;
        $('.GrdGriegeTable td[rowspan].GriAccessShrTable').each(function () {
            var row = $(this).parent().parent().children().index($(this).parent());
            if (row > maxRowGSh) {
                maxRowGSh = row;
                rowSpanGSh = 0;
            }
            if ($(this).attr('rowspan') > rowSpanGSh) rowSpanGSh = $(this).attr('rowspan');
        });
        if (maxRowGSh == $('.GrdGriegeTable tr:last td').parent().parent().children().index($('.GrdGriegeTable tr:last td').parent()) - (rowSpanGSh - 1)) {
            $('.GrdGriegeTable td[rowspan].GriAccessShrTable').each(function () {
                var row = $(this).parent().parent().children().index($(this).parent());
                if (row == maxRowGSh && $(this).attr('rowspan') == rowSpanGSh) $(this).addClass('border_last_bottom_color');
            });
        }

        var maxRowGWa = 0;
        var rowSpanGWa = 0;
        $('.GrdGriegeTable td[rowspan].GriAccessWaTable').each(function () {
            var row = $(this).parent().parent().children().index($(this).parent());
            if (row > maxRowGWa) {
                maxRowGWa = row;
                rowSpanGWa = 0;
            }
            if ($(this).attr('rowspan') > rowSpanGWa) rowSpanGWa = $(this).attr('rowspan');
        });
        if (maxRowGWa == $('.GrdGriegeTable tr:last td').parent().parent().children().index($('.GrdGriegeTable tr:last td').parent()) - (rowSpanGWa - 1)) {
            $('.GrdGriegeTable td[rowspan].GriAccessWaTable').each(function () {
                var row = $(this).parent().parent().children().index($(this).parent());
                if (row == maxRowGWa && $(this).attr('rowspan') == rowSpanGWa) $(this).addClass('border_last_bottom_color');
            });
        }

        var maxRowPWa = 0;
        var rowSpanPWa = 0;
        $('.GrdProcessTable td[rowspan].ProAccessWaTable').each(function () {
            var row = $(this).parent().parent().children().index($(this).parent());
            if (row > maxRowPWa) {
                maxRowPWa = row;
                rowSpanPWa = 0;
            }
            if ($(this).attr('rowspan') > rowSpanPWa) rowSpanPWa = $(this).attr('rowspan');
        });
        if (maxRowPWa == $('.GrdProcessTable tr:last td').parent().parent().children().index($('.GrdProcessTable tr:last td').parent()) - (rowSpanPWa - 1)) {
            $('.GrdProcessTable td[rowspan].ProAccessWaTable').each(function () {
                var row = $(this).parent().parent().children().index($(this).parent());
                if (row == maxRowPWa && $(this).attr('rowspan') == rowSpanPWa) $(this).addClass('border_last_bottom_color');
            });
        }

        var maxRowPSh = 0;
        var rowSpanPSh = 0;
        $('.GrdProcessTable td[rowspan].ProAccessShTable').each(function () {
            var row = $(this).parent().parent().children().index($(this).parent());
            if (row > maxRowPSh) {
                maxRowPSh = row;
                rowSpanPSh = 0;
            }
            if ($(this).attr('rowspan') > rowSpanPSh) rowSpanPSh = $(this).attr('rowspan');
        });
        if (maxRowPSh == $('.GrdProcessTable tr:last td').parent().parent().children().index($('.GrdProcessTable tr:last td').parent()) - (rowSpanPSh - 1)) {
            $('.GrdProcessTable td[rowspan].ProAccessShTable').each(function () {
                var row = $(this).parent().parent().children().index($(this).parent());
                if (row == maxRowPSh && $(this).attr('rowspan') == rowSpanPSh) $(this).addClass('border_last_bottom_color');
            });
        }





        var maxRowPr = 0;
        var rowSpanPr = 0;
        $('.GrdProcessTable td[rowspan]').each(function () {
            var row = $(this).parent().parent().children().index($(this).parent());
            if (row > maxRowPr) {
                maxRowPr = row;
                rowSpanPr = 0;
            }
            if ($(this).attr('rowspan') > rowSpanPr) rowSpanPr = $(this).attr('rowspan');
        });
        if (maxRowPr == $('.GrdProcessTable tr:last td').parent().parent().children().index($('.GrdProcessTable tr:last td').parent()) - (rowSpanPr - 1)) {
            $('.GrdProcessTable td[rowspan]').each(function () {
                var row = $(this).parent().parent().children().index($(this).parent());
                if (row == maxRowPr && $(this).attr('rowspan') == rowSpanPr) $(this).addClass('border_last_bottom_color');
            });
        }

        var maxRowFi = 0;
        var rowSpanFi = 0;
        $('.GrdFinishTable td[rowspan]').each(function () {
            var row = $(this).parent().parent().children().index($(this).parent());
            if (row > maxRowFi) {
                maxRowFi = row;
                rowSpanFi = 0;
            }
            if ($(this).attr('rowspan') > rowSpanFi) rowSpanFi = $(this).attr('rowspan');
        });
        if (maxRowFi == $('.GrdFinishTable tr:last td').parent().parent().children().index($('.GrdFinishTable tr:last td').parent()) - (rowSpanFi - 1)) {
            $('.GrdFinishTable td[rowspan]').each(function () {
                var row = $(this).parent().parent().children().index($(this).parent());
                if (row == maxRowFi && $(this).attr('rowspan') == rowSpanFi) $(this).addClass('border_last_bottom_color');
            });
        }

        var maxRowCol = 0;
        var rowSpanCol = 0;
        $('.GrdGriegeTable td[rowspan].GriegeTableCol').each(function () {
            var row = $(this).parent().parent().children().index($(this).parent());
            if (row > maxRowCol) {
                maxRowCol = row;
                rowSpanCol = 0;
            }
            if ($(this).attr('rowspan') > rowSpanCol) rowSpanCol = $(this).attr('rowspan');
        });
        if (maxRowCol == $('.GrdGriegeTable tr:last td').parent().parent().children().index($('.GrdGriegeTable tr:last td').parent()) - (rowSpanCol - 1)) {
            $('.GrdGriegeTable td[rowspan].GriegeTableCol').each(function () {
                var row = $(this).parent().parent().children().index($(this).parent());
                if (row == maxRowCol && $(this).attr('rowspan') == rowSpanCol) $(this).addClass('border_last_bottom_color');
            });
        }

        var maxRowPCol = 0;
        var rowSpanPCol = 0;
        $('.GrdProcessTable td[rowspan].GriegeTableProCol').each(function () {
            var row = $(this).parent().parent().children().index($(this).parent());
            if (row > maxRowCol) {
                maxRowPCol = row;
                rowSpanPCol = 0;
            }
            if ($(this).attr('rowspan') > rowSpanPCol) rowSpanPCol = $(this).attr('rowspan');
        });
        if (maxRowPCol == $('.GrdProcessTable tr:last td').parent().parent().children().index($('.GrdProcessTable tr:last td').parent()) - (rowSpanPCol - 1)) {
            $('.GrdProcessTable td[rowspan].GriegeTableProCol').each(function () {
                var row = $(this).parent().parent().children().index($(this).parent());
                if (row == maxRowPCol && $(this).attr('rowspan') == rowSpanPCol) $(this).addClass('border_last_bottom_color');
            });
        }
        var maxRowFiCol = 0;
        var rowSpanFiCol = 0;
        $('.GrdFinishTable td[rowspan].GriegeTableFinCol').each(function () {
            var row = $(this).parent().parent().children().index($(this).parent());
            if (row > maxRowFiCol) {
                maxRowFiCol = row;
                rowSpanFiCol = 0;
            }
            if ($(this).attr('rowspan') > rowSpanFiCol) rowSpanFiCol = $(this).attr('rowspan');
        });
        if (maxRowFiCol == $('.GrdFinishTable tr:last td').parent().parent().children().index($('.GrdFinishTable tr:last td').parent()) - (rowSpanFiCol - 1)) {
            $('.GrdFinishTable td[rowspan].GriegeTableFinCol').each(function () {
                var row = $(this).parent().parent().children().index($(this).parent());
                if (row == maxRowFiCol && $(this).attr('rowspan') == rowSpanFiCol) $(this).addClass('border_last_bottom_color');
            });
        }

    }

    function ShowPurchaseOrder(AccessoryMasterId, Size, ColorPrint, SupplierPoId, type) {
        debugger;
        var url = 'AccessoryPurchaseOrder.aspx?AccessoryMasterId=' + AccessoryMasterId + '&Size=' + Size + '&ColorPrint=' + ColorPrint + '&SupplierPoId=' + SupplierPoId + '&AccessoryType=' + type + '&FromPage=' + 1;
        Shadowbox.init({ animate: true, animateFade: true, modal: true });
        Shadowbox.open({ content: url, type: "iframe", player: "iframe", title: "", height: 900, width: 1500, modal: true, animate: true, animateFade: true, options: { onClose: SBClose} });
        return false;
    }
    function SBClose() { }
</script>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta content="Fashion Garments" name="DESCRIPTION" />
    <meta content="Fashion" name="KEYWORDS" />
    <meta content="text/html; charset=utf-8" http-equiv="Content-Type" />
    <title></title>
    <style type="text/css">
        body
        {
            background: #f9f9fa none repeat scroll 0 0;
            font-family: sans-serif !important;
        }
        
        table
        {
            font-family: sans-serif;
            border-color: gray;
            border-collapse: collapse;
        }
        
        .HeaderClass td
        {
            background: #dddfe4;
            font-weight: bold;
            color: #575759;
            font-family: sans-serif;
            font-size: 10px;
            padding: 4px 1px;
            border-color: #999;
        }
        
        .HeaderClass1 td
        {
            background: #dddfe4;
            font-weight: bold;
            color: #575759;
            font-family: sans-serif;
            font-size: 11px;
            padding: 5px 0px;
            border-color: #999;
        }
        
        table td
        {
            font-size: 10px;
            text-align: center;
            text-transform: capitalize;
            color: gray;
            padding: 2px 0px;
            font-family: arial;
            border-color: #dbd8d8;
        }
        .grdgsmcom th
        {
            border: 1px solid #999;
            font-weight: 500;
            color: #575759;
            font-family: arial;
            font-size: 11px;
            padding: 3px 0px;
            border-color: #999;
        }
        .grdgsmcom td
        {
            font-family: arial;
            font-size: 10px;
            border: 1px solid #dbd8d8;
        }
        .per
        {
            color: blue;
        }
        
        .gray
        {
            color: gray;
        }
        
        h2 .row-fir th
        {
            font-weight: bold;
            font-size: 11px;
        }
        
        table td table td
        {
            border-color: #ddd;
        }
        
        .SUPPLY-MANA td input
        {
            width: 35%;
        }
        
        .imageField
        {
            background-image: url(submit.jpg);
            height: 28px;
            width: 105px;
        }
        
        .pad
        {
            text-align: left;
            padding-left: 25px;
        }
        
        .ths
        {
            background: #dddfe4;
            font-weight: normal;
            color: #575759;
            font-family: sans-serif;
            font-size: 10px;
            padding: 5px 0px;
            text-align: center;
            text-transform: capitalize;
            border: 1px solid #c6c0c0;
        }
        .backcolorstages
        {
            background: #fdfd96e0 !important;
        }
        
        .Normaltextbox
        {
            border-color: White;
            width: 21% !important;
            border: 1px solid #999 !important;
            border-radius: 2px;
            height: 13px;
            color: Blue;
            font-size: 10px;
            text-align: center;
        }
        
        .float_left
        {
            float: left;
            padding-left: 3px;
        }
        
        .float_right
        {
            padding-right: 3px;
        }
        
        .color_black
        {
            color: #2f2d2d;
        }
        
        .txtLeft
        {
            text-align:left;
         }
        /* Change background on mouse-over */
        
        .navbar a:hover
        {
            background: #ddd;
            color: black;
        }
        
        .tab
        {
            overflow: hidden;
            border: 0px solid #ccc;
            background-color: #f9f8f8;
            margin-left: 14px;
            width: 25%;
            float: left;
        }
        .searchtxt
        {
            height: 17px;
            width: 27.8%;
            border-radius: 2px;
            padding-left: 2px;
        }
        
        /* Style the buttons inside the tab */
        
        .tab a
        {
            background-color: inherit;
            border: none;
            outline: none;
            cursor: pointer; /* padding: 14px 16px; */
            transition: 0.3s;
            font-size: 13px;
            border: 1px solid #999;
            width: 72px;
            text-align: center;
            border-top-left-radius: 3px;
            border-top-right-radius: 3px;
            margin-right: 2px;
            font-family: sans-serif !important;
            padding: 3px 2px;
            border-bottom: 0px;
            float: left;
        }
        
        
        /* Change background color of buttons on hover */
        
        .tab a:hover
        {
            background-color: #ddd;
        }
        
        
        /* Create an active/current tablink class */
        
        .tab a.active
        {
            background-color: #ccc;
        }
        
        
        /* Style the tab content */
        
        .tabcontent
        {
            display: none;
            padding: 6px 12px;
            border: 1px solid #ccc;
            border-top: none;
        }
        
        .activeback
        {
            background: green !important;
            color: #fff;
        }
        
        .navbar tab
        {
            border: 1px solid #fff;
        }
        
        .maincontentcontainer
        {
            width: 1100px;
            margin: 0px 0px 0px 14px;
        }
        
        .decoratedErrorField
        {
            width: 27% !important;
            border: 2px solid red !important;
        }
        
        .UsernameColor
        {
            font-weight: 600;
        }
        
        .grdgsmcom td:first-child
        {
            border-left-color: #999 !important;
          
            padding-left: 2px
        }
        
        .grdgsmcom td:last-child
        {
            border-right-color: #999 !important;
        }
        
        .grdgsmcom tr:nth-last-child(1) > td
        {
            border-bottom-color: #999 !important;
        }
        td.border_bottom_rowspan
        {
            border-bottom-color: #999 !important;
        }
        /* #grdfinishing td[rowspan]:first-child
    {
         border-bottom-color: #999 !important; 
     }  */
        @media screen and (max-width: 1366px)
        {
            .textright
            {
                width: 63.2% !important;
            }
        }
        .tab1greige
        {
            cursor: pointer;
        }
        .clsDivHdr
        {
            background: #dddfe4;
            font-weight: bold;
            color: #575759;
            font-family: arial;
            font-size: 11px;
            padding: 5px 0px;
            text-align: center;
            text-transform: capitalize;
            border: 1px solid #999;
            width: 848px;
            border-bottom: 0px;
        }
        .border_last_bottom_color
        {
            border-bottom-color:#999 !important;
        }
        #sb-wrapper-inner
        {
            border: 5px solid #999;
             border-radius: 5px;
         }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:HiddenField ID="hdntabvalue" runat="server" />

        <div id="header" style="float: left; width: 200px; padding-left: 15px;">
            <asp:Image ID="boutiquelogo" runat="server" Height="48px" Width="164px" />
        </div>
        <div class="centerdiv" style="float: left; width: 70%; margin-top: 20px; text-align: center">
            <asp:Label ID="lblusername" runat="server"></asp:Label>
        </div>
        <div style="float: right; width: 28px; margin-top: 18px">
            <a href='<%= (Request.IsAuthenticated) ? ResolveUrl("~/internal/Logout.aspx") : ResolveUrl("~/public/login.aspx") %>'
                class="topmenu2border" style="text-transform: capitalize !important;">
                <%= (Request.IsAuthenticated) ? "" : "" %>
                <img src="../../Uploads/Photo/log_out.png" title="Log Out" alt="Log Out" style="height: 25px;
                    width: 25px; position: relative; top: -8px; right: 10px;" /></a>
        </div>

        <asp:ScriptManager ID="script1" runat="server">
        </asp:ScriptManager>
        <asp:UpdateProgress runat="server" ID="uproTargetAdmin" AssociatedUpdatePanelID="UpdatePanel1"
            DisplayAfter="0">
            <ProgressTemplate>
                <img src="../../App_Themes/ikandi/images1/loading36.gif" alt="" style="position: fixed;
                    z-index: 52111; top: 40%; left: 45%; width: 6%;" />
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div style="clear: both">
                </div>
                <div class="tab">
                    <a runat="server" id="aGreige" class="tab1greige" onclick="ShowHideSuppliergrd('GRIEGE');">
                        Greige</a> <a runat="server" id="aProcess" class="tab1Process" onclick="ShowHideSuppliergrd('PROCESS');">
                            Process</a> <a runat="server" id="aFinish" class="tab1finished" onclick="ShowHideSuppliergrd('FINISHING');">
                                Finish</a>
                </div>
                <div style="width: 47.8%; text-align: right;" class="textright">
                    <asp:TextBox ID="txtsearchkeyswords" class="search_1 searchtxt" placeholder="Search Access Quality or Supplier"
                        runat="server" Style="text-transform: unset"></asp:TextBox>
                    <asp:Button ID="btnSearch" runat="server" placeholder="Quality/ supplier name" CssClass="go do-not-disable"
                        Text="Search" Style="padding: 3px 7px; border-radius: 2px;" OnClick="btnSearch_Click" />
                    <asp:Button ID="btnTab" CssClass="clsBtnTab" runat="server" Style="display: none;"
                        Text="" OnClick="btnTab_Click" />
                </div>
                <div style="clear: both">
                </div>
                <div class="maincontentcontainer">
                    <div class="clsDivHdr" id="dvHeader" runat="server">
                    </div>
                    <asp:GridView ID="grdGriege" CssClass="grdgsmcom GrdGriegeTable" Style="display: none;
                        min-width: 850px; max-width: 850px;" runat="server" AutoGenerateColumns="False"
                        ShowHeader="true" OnRowDataBound="grdGriege_RowDataBound" OnDataBound="grdGriege_DataBound"
                        EmptyDataText="No Record Found!" HeaderStyle-Font-Names="Arial" HeaderStyle-HorizontalAlign="Center"
                        BorderWidth="1" rules="all" HeaderStyle-CssClass="ths">
                        <SelectedRowStyle BackColor="#A1DCF2" />
                        <RowStyle CssClass="RowCountDy" />
                        <Columns>
                            <asp:TemplateField HeaderText="Accessory Quality (Size)<br> Color/Print">
                                <ItemStyle HorizontalAlign="Center" Width="160px" CssClass="txtLeft" />
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <asp:Label ID="lblAccessoryQuality" ForeColor="blue" Text='<%# Eval("AccessoryName")%>'
                                        runat="server"></asp:Label>
                                    <asp:Label ID="lblSize" Text='<%# Eval("Size")%>' runat="server"></asp:Label>
                                    <br />
                                    <asp:Label ID="lblcolorprint" ForeColor="Black" Font-Bold="true" Text='<%# Eval("Color_Print")%>'
                                        runat="server"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Shrinkage %">
                                <ItemTemplate>
                                    <asp:Label ID="lblShrinkage" CssClass="color_black" Text='<%# Convert.ToString(Eval("Shrinkage")) == "0" ? "" : Convert.ToString(Eval("Shrinkage"))%>'
                                        runat="server"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle CssClass="GriAccessShrTable" Width="50px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Wastage %">
                                <ItemTemplate>
                                    <asp:Label ID="lblWastage" CssClass="color_black" Text='<%# Convert.ToString(Eval("Wastage")) == "0" ? "" : Convert.ToString(Eval("Wastage"))%>'
                                        runat="server"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle CssClass="GriAccessWaTable" Width="50px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Qty. to Order">
                                <ItemTemplate>
                                    <asp:Label ID="lblQuantityToOrder" CssClass="color_black" Text='<%# (Eval("QuantityToOrder") == DBNull.Value  || (Eval("QuantityToOrder").ToString().Trim() == string.Empty)) ? string.Empty : (Convert.ToInt32((Eval("QuantityToOrder"))).ToString("N0")) %>'
                                        runat="server"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Width="50px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Supplier Name">
                                <ItemTemplate>
                                    <asp:HiddenField ID="hdnSupplierID" runat="server" Value='<%# Eval("SupplierId")%>' />
                                    <asp:Label ID="lblsuppliername" CssClass="color_black" Text='<%# Convert.ToString(Eval("SupplierName")) == "0" ? "" : Convert.ToString(Eval("SupplierName"))%>'
                                        runat="server"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Width="90px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Best Quote for ref. </br> Landed Rate & Time">
                                <ItemTemplate>
                                    <span style="color: green; font-size: 12px; float: left; padding-left: 4px;">₹</span>
                                    <asp:Label ID="lblBestQuotedRate" CssClass="float_left color_black" Text='<%# Convert.ToString(Eval("MinimumRate")) == "-1" ? "" : Convert.ToString(Eval("MinimumRate"))%>'
                                        runat="server"></asp:Label>
                                    <asp:Label ID="lblBestQuotedLeadTime" CssClass="float_right color_black" Text='<%# Convert.ToString(Eval("MinimumLeadTime")) == "-1" ? "" : Convert.ToString(Eval("MinimumLeadTime"))%>'
                                        runat="server"></asp:Label>
                                    <asp:HiddenField ID="hdnMinimumRate" Value='<%# Eval("MinimumRate")%>' runat="server" />
                                    <asp:HiddenField ID="hdnMinimumLeadTime" Value='<%# Eval("MinimumLeadTime")%>' runat="server" />
                                </ItemTemplate>
                                <ItemStyle Width="80px" CssClass="GriegeTableCol" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Quoted (landed Rate & Time)" Visible="false">
                                <ItemTemplate>
                                    <span style="color: green; font-size: 12px">₹</span>
                                    <asp:TextBox ID="txtquotedval" MaxLength="6" onchange="SaveAccessorySupplierQuotation(this, 1)"
                                        onkeypress="return isNumberKey(event)" CssClass="Normaltextbox" runat="server"
                                        BorderColor="White" Text='<%# Convert.ToString(Eval("QuotedLandedRate")) == "-1" ? "" : Convert.ToString(Eval("QuotedLandedRate"))%>'></asp:TextBox>
                                   <%-- <asp:TextBox ID="txtdays" onchange="SaveAccessorySupplierQuotation(this, 1)" CssClass="Normaltextbox"
                                        onkeyup="if (/\D/g.test(this.value)) this.value = this.value.replace(/\D/g,'')"
                                        Text='<%# Convert.ToString(Eval("QuotedLeadTime")) == "-1" ? "" : Convert.ToString(Eval("QuotedLeadTime"))%>'
                                        runat="server" BorderColor="White"></asp:TextBox>
                                    Days--%>
                                    <asp:HiddenField ID="hdAccessoryMasterId" Value='<%# Eval("AccessoryMasterId")%>'
                                        runat="server" />
                                    <asp:HiddenField ID="hdnAccessoryQualitySize" Value='<%# Eval("Size")%>' runat="server" />
                                    <asp:HiddenField ID="hdnColorprint" Value='<%# Eval("Color_Print")%>' runat="server" />
                                </ItemTemplate>
                                <ItemStyle Width="100px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Quotation Date">
                                <ItemTemplate>    
                                    <asp:Label ID="lblQuotationDate" style=""  runat="server" Text='<%# (Convert.ToDateTime(Eval("QuotedDate")) == DateTime.MinValue) ? "" : (Convert.ToDateTime(Eval("QuotedDate"))).ToString("dd MMM yyyy")%>'></asp:Label>                                    
                                </ItemTemplate>
                                <ItemStyle Width="70px" />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="PO Number">
                                <ItemTemplate>    
                                    <asp:Label ID="lblPoNumber" style="cursor:pointer; color:Blue;"  runat="server" Text='<%# Eval("PoNumber")%>'></asp:Label>
                                    <asp:HiddenField ID="hdnPoSupplirtId" runat="server" Value='<%# Eval("SupplierPoId")%>' />
                                </ItemTemplate>
                                <ItemStyle Width="50px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="PO Date">
                                <ItemTemplate>
                                   <asp:Label ID="lblPODate" runat="server" Text='<%# (Convert.ToDateTime(Eval("PoDate")) == DateTime.MinValue) ? "" : (Convert.ToDateTime(Eval("PoDate"))).ToString("dd MMM yyyy")%>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Width="70px" />
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="PO Qty.">
                                <ItemTemplate>
                                     <asp:Label ID="lblPoReceivedQty" runat="server" Text='<%# Convert.ToString(Eval("ReceivedQty")) == "0" ? "" : Convert.ToInt32(Eval("ReceivedQty")).ToString("N0")%>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Width="50px" />
                            </asp:TemplateField>
                        </Columns>
                        <EmptyDataTemplate>
                            <asp:Label ID="lblEmptyRow" Style="font-size: 12px; color: Red;" runat="server" Text="Griege Data not available"></asp:Label>
                        </EmptyDataTemplate>
                    </asp:GridView>
                    <asp:GridView ID="grdProcess" CssClass="grdgsmcom GrdProcessTable" Style="display: none; min-width: 850px;
                        max-width: 850px;" runat="server" AutoGenerateColumns="False" ShowHeader="true"
                        OnRowDataBound="grdProcess_RowDataBound" OnDataBound="grdProcess_DataBound" EmptyDataText="No Record Found!"
                        HeaderStyle-Font-Names="Arial" HeaderStyle-HorizontalAlign="Center" BorderWidth="1"
                        rules="all" HeaderStyle-CssClass="ths">
                        <SelectedRowStyle BackColor="#A1DCF2" />
                        <RowStyle CssClass="RowCountDy" />
                        <Columns>
                            <asp:TemplateField HeaderText="Accessory Quality (Size)<br> Color/Print">
                                <ItemStyle HorizontalAlign="Center" Width="160px" CssClass="txtLeft" />
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <asp:Label ID="lblAccessoryQuality" ForeColor="blue" Text='<%# Eval("AccessoryName")%>'
                                        runat="server"></asp:Label>
                                    <asp:Label ID="lblSize" Text='<%# Eval("Size")%>' ForeColor="gray" runat="server"></asp:Label>
                                    <br />
                                    <asp:Label ID="lblcolorprint" ForeColor="Black" Font-Bold="true" Text='<%# Eval("Color_Print")%>'
                                        runat="server"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Shrinkage %">
                                <ItemTemplate>
                                    <asp:Label ID="lblShrinkage" CssClass="color_black" Text='<%# Convert.ToString(Eval("Shrinkage")) == "0" ? "" : Convert.ToString(Eval("Shrinkage"))%>'
                                        runat="server"></asp:Label>
                              
                                </ItemTemplate>
                               <ItemStyle CssClass="ProAccessShTable" Width="50px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Wastage %">
                                <ItemTemplate>
                                    <asp:Label ID="lblWastage" CssClass="color_black" Text='<%# Convert.ToString(Eval("Wastage")) == "0" ? "" : Convert.ToString(Eval("Wastage"))%>'
                                        runat="server"></asp:Label>
                                </ItemTemplate>
                              <ItemStyle CssClass="ProAccessWaTable" Width="50px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Qty. to Order">
                                <ItemTemplate>
                                    <asp:Label ID="lblQuantityToOrder" CssClass="color_black" Text='<%# (Eval("QuantityToOrder") == DBNull.Value  || (Eval("QuantityToOrder").ToString().Trim() == string.Empty)) ? string.Empty : (Convert.ToInt32((Eval("QuantityToOrder"))).ToString("N0")) %>'
                                        runat="server"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Width="50px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Supplier Name">
                                <ItemTemplate>
                                    <asp:HiddenField ID="hdnSupplierID" runat="server" Value='<%# Eval("SupplierId")%>' />
                                    <asp:Label ID="lblsuppliername" CssClass="color_black" Text='<%# Convert.ToString(Eval("SupplierName")) == "0" ? "" : Convert.ToString(Eval("SupplierName"))%>'
                                        runat="server"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Width="90px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Best Quote for ref. </br> Landed Rate & Time">
                                <ItemTemplate>
                                    <span style="color: green; font-size: 12px; float: left; padding-left: 4px;">₹</span>
                                    <asp:Label ID="lblBestQuotedRate" CssClass="float_left color_black" Text='<%# Convert.ToString(Eval("MinimumRate")) == "-1" ? "" : Convert.ToString(Eval("MinimumRate"))%>'
                                        runat="server"></asp:Label>
                                    <asp:Label ID="lblBestQuotedLeadTime" CssClass="float_right color_black" Text='<%# Convert.ToString(Eval("MinimumLeadTime")) == "-1" ? "" : Convert.ToString(Eval("MinimumLeadTime"))%>'
                                        runat="server"></asp:Label>
                                    <asp:HiddenField ID="hdnMinimumRate" Value='<%# Eval("MinimumRate")%>' runat="server" />
                                    <asp:HiddenField ID="hdnMinimumLeadTime" Value='<%# Eval("MinimumLeadTime")%>' runat="server" />
                                </ItemTemplate>
                                <ItemStyle Width="80px" CssClass="GriegeTableProCol" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Quoted (landed Rate & Time)" Visible="false">
                                <ItemTemplate>
                                    <span style="color: green; font-size: 12px">₹</span>
                                    <asp:TextBox ID="txtquotedval" MaxLength="6" onchange="SaveAccessorySupplierQuotation(this, 2)"
                                        onkeypress="return isNumberKey(event)" CssClass="Normaltextbox" runat="server"
                                        BorderColor="White" Text='<%# Convert.ToString(Eval("QuotedLandedRate")) == "-1" ? "" : Convert.ToString(Eval("QuotedLandedRate"))%>'></asp:TextBox>
                                   <%-- <asp:TextBox ID="txtdays" onchange="SaveAccessorySupplierQuotation(this, 2)" CssClass="Normaltextbox"
                                        onkeyup="if (/\D/g.test(this.value)) this.value = this.value.replace(/\D/g,'')"
                                        Text='<%# Convert.ToString(Eval("QuotedLeadTime")) == "-1" ? "" : Convert.ToString(Eval("QuotedLeadTime"))%>'
                                        runat="server" BorderColor="White"></asp:TextBox>
                                    Days--%>
                                    <asp:HiddenField ID="hdAccessoryMasterId" Value='<%# Eval("AccessoryMasterId")%>'
                                        runat="server" />
                                    <asp:HiddenField ID="hdnAccessoryQualitySize" Value='<%# Eval("Size")%>' runat="server" />
                                    <asp:HiddenField ID="hdnColorprint" Value='<%# Eval("Color_Print")%>' runat="server" />
                                </ItemTemplate>
                                <ItemStyle Width="100px" />
                            </asp:TemplateField>

                             <asp:TemplateField HeaderText="Quotation Date">
                                <ItemTemplate>    
                                    <asp:Label ID="lblQuotationDate" style=""  runat="server" Text='<%# (Convert.ToDateTime(Eval("QuotedDate")) == DateTime.MinValue) ? "" : (Convert.ToDateTime(Eval("QuotedDate"))).ToString("dd MMM yyyy")%>'></asp:Label>                                    
                                </ItemTemplate>
                                <ItemStyle Width="70px" />
                            </asp:TemplateField>

                           <asp:TemplateField HeaderText="PO Number">
                                <ItemTemplate>
                                    <asp:Label ID="lblPoNumber" style="cursor:pointer; color:Blue;"  runat="server" Text='<%# Eval("PoNumber")%>'></asp:Label>
                                    <asp:HiddenField ID="hdnPoSupplirtId" runat="server" Value='<%# Eval("SupplierPoId")%>' />
                                </ItemTemplate>
                                <ItemStyle Width="50px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="PO Date">
                                <ItemTemplate>
                                   <asp:Label ID="lblPODate" runat="server" Text='<%# (Convert.ToDateTime(Eval("PoDate")) == DateTime.MinValue) ? "" : (Convert.ToDateTime(Eval("PoDate"))).ToString("dd MMM yyyy")%>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Width="70px" />
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="PO Qty.">
                                <ItemTemplate>
                                     <asp:Label ID="lblPoReceivedQty" runat="server" Text='<%# Convert.ToString(Eval("ReceivedQty")) == "0" ? "" : Convert.ToInt32(Eval("ReceivedQty")).ToString("N0")%>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Width="50px" />
                            </asp:TemplateField>
                        </Columns>
                        <EmptyDataTemplate>
                            <asp:Label ID="lblEmptyRow" Style="font-size: 12px; color: Red;" runat="server" Text="Process Data not available"></asp:Label>
                        </EmptyDataTemplate>
                    </asp:GridView>
                    <asp:GridView ID="grdFinish" CssClass="grdgsmcom GrdFinishTable" Style="display: none; min-width: 850px;
                        max-width: 850px;" runat="server" AutoGenerateColumns="False" ShowHeader="true"
                        OnRowDataBound="grdFinish_RowDataBound" OnDataBound="grdFinish_DataBound" EmptyDataText="No Record Found!"
                        HeaderStyle-Font-Names="Arial" HeaderStyle-HorizontalAlign="Center" BorderWidth="1"
                        rules="all" HeaderStyle-CssClass="ths">
                        <SelectedRowStyle BackColor="#A1DCF2" />
                        <RowStyle CssClass="RowCountDy" />
                        <Columns>
                            <asp:TemplateField HeaderText="Accessory Quality (Size)<br> Color/Print">
                                <ItemStyle HorizontalAlign="Center" Width="160px" CssClass="txtLeft" />
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <asp:Label ID="lblAccessoryQuality" ForeColor="blue" Text='<%# Eval("AccessoryName")%>'
                                        runat="server"></asp:Label>
                                    <asp:Label ID="lblSize" Text='<%# Eval("Size")%>' ForeColor="gray" runat="server"></asp:Label>
                                    <br />
                                    <asp:Label ID="lblcolorprint" ForeColor="Black" Font-Bold="true" Text='<%# Eval("Color_Print")%>'
                                        runat="server"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Shrinkage %">
                                <ItemTemplate>
                                    <asp:Label ID="lblShrinkage" CssClass="color_black" Text='<%# Convert.ToString(Eval("Shrinkage")) == "0" ? "" : Convert.ToString(Eval("Shrinkage"))%>'
                                        runat="server"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Width="50px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Wastage %">
                                <ItemTemplate>
                                    <asp:Label ID="lblWastage" CssClass="color_black" Text='<%# Convert.ToString(Eval("Wastage")) == "0" ? "" : Convert.ToString(Eval("Wastage"))%>'
                                        runat="server"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Width="50px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Qty. to Order">
                                <ItemTemplate>
                                    <asp:Label ID="lblQuantityToOrder" CssClass="color_black" Text='<%# (Eval("QuantityToOrder") == DBNull.Value  || (Eval("QuantityToOrder").ToString().Trim() == string.Empty)) ? string.Empty : (Convert.ToInt32((Eval("QuantityToOrder"))).ToString("N0")) %>'
                                        runat="server"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Width="50px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Supplier Name">
                                <ItemTemplate>
                                    <asp:HiddenField ID="hdnSupplierID" runat="server" Value='<%# Eval("SupplierId")%>' />
                                    <asp:Label ID="lblsuppliername" CssClass="color_black" Text='<%# Convert.ToString(Eval("SupplierName")) == "0" ? "" : Convert.ToString(Eval("SupplierName"))%>'
                                        runat="server"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Width="90px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Best Quote for ref. </br> Landed Rate & Time" Visible="false">
                                <ItemTemplate>
                                   <%-- <span style="color: green; font-size: 12px; float: left; padding-left: 4px;">₹</span>
                                    <asp:Label ID="lblBestQuotedRate" CssClass="float_left color_black" Text='<%# Convert.ToString(Eval("MinimumRate")) == "-1" ? "" : Convert.ToString(Eval("MinimumRate"))%>'
                                        runat="server"></asp:Label>
                                    <asp:Label ID="lblBestQuotedLeadTime" CssClass="float_right color_black" Text='<%# Convert.ToString(Eval("MinimumLeadTime")) == "-1" ? "" : Convert.ToString(Eval("MinimumLeadTime"))%>'
                                        runat="server"></asp:Label>
                                    <asp:HiddenField ID="hdnMinimumRate" Value='<%# Eval("MinimumRate")%>' runat="server" />
                                    <asp:HiddenField ID="hdnMinimumLeadTime" Value='<%# Eval("MinimumLeadTime")%>' runat="server" />--%>
                                </ItemTemplate>
                                <ItemStyle Width="80px" CssClass="GriegeTableFinCol" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Quoted (landed Rate)">
                                <ItemTemplate>
                                    <span style="color: green; font-size: 12px">₹</span>
                                    <asp:TextBox ID="txtquotedval" MaxLength="6" onchange="SaveAccessorySupplierQuotation(this, 3)"
                                        onkeypress="return isNumberKey(event)" CssClass="Normaltextbox" runat="server"
                                        BorderColor="White" Text='<%# Convert.ToString(Eval("QuotedLandedRate")) == "-1" ? "" : Convert.ToString(Eval("QuotedLandedRate"))%>'></asp:TextBox>
<%--                                    <asp:TextBox ID="txtdays" onchange="SaveAccessorySupplierQuotation(this, 3)" CssClass="Normaltextbox"
                                        onkeyup="if (/\D/g.test(this.value)) this.value = this.value.replace(/\D/g,'')"
                                        Text='<%# Convert.ToString(Eval("QuotedLeadTime")) == "-1" ? "" : Convert.ToString(Eval("QuotedLeadTime"))%>'
                                        runat="server" BorderColor="White"></asp:TextBox>
                                    Days--%>
                                    <asp:HiddenField ID="hdAccessoryMasterId" Value='<%# Eval("AccessoryMasterId")%>'
                                        runat="server" />
                                    <asp:HiddenField ID="hdnAccessoryQualitySize" Value='<%# Eval("Size")%>' runat="server" />
                                    <asp:HiddenField ID="hdnColorprint" Value='<%# Eval("Color_Print")%>' runat="server" />
                                </ItemTemplate>
                                <ItemStyle Width="100px" />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Quotation Date" Visible="false">
                                <ItemTemplate>    
                                    <asp:Label ID="lblQuotationDate" style=""  runat="server" Text='<%# (Convert.ToDateTime(Eval("QuotedDate")) == DateTime.MinValue) ? "" : (Convert.ToDateTime(Eval("QuotedDate"))).ToString("dd MMM yyyy")%>'></asp:Label>                                    
                                </ItemTemplate>
                                <ItemStyle Width="70px" />
                            </asp:TemplateField>

                           <asp:TemplateField HeaderText="PO Number">
                                <ItemTemplate>
                                    <asp:Label ID="lblPoNumber" style="cursor:pointer; color:Blue;"  runat="server" Text='<%# Eval("PoNumber")%>'></asp:Label>
                                    <asp:HiddenField ID="hdnPoSupplirtId" runat="server" Value='<%# Eval("SupplierPoId")%>' />
                                </ItemTemplate>
                                <ItemStyle Width="50px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="PO Date">
                                <ItemTemplate>
                                   <asp:Label ID="lblPODate" runat="server" Text='<%# (Convert.ToDateTime(Eval("PoDate")) == DateTime.MinValue) ? "" : (Convert.ToDateTime(Eval("PoDate"))).ToString("dd MMM yyyy")%>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Width="70px" />
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="PO Qty.">
                                <ItemTemplate>
                                     <asp:Label ID="lblPoReceivedQty" runat="server" Text='<%# Convert.ToString(Eval("ReceivedQty")) == "0" ? "" : Convert.ToInt32(Eval("ReceivedQty")).ToString("N0")%>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Width="50px" />
                            </asp:TemplateField>
                        </Columns>
                        <EmptyDataTemplate>
                            <asp:Label ID="lblEmptyRow" Style="font-size: 12px; color: Red;" runat="server" Text="Finish Data not available"></asp:Label>
                        </EmptyDataTemplate>
                    </asp:GridView>
                </div>
                <div id="footer" style="text-align: center;">
                    <script type="text/javascript">                        document.write((new Date()).getFullYear())</script>
                    © Boutique International Pvt. Ltd. All Rights Reserved
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    </form>
</body>
</html>
