<%@ Page Title="" Language="C#" MasterPageFile="~/layout/Secure.Master" AutoEventWireup="true" CodeBehind="AccessoryOrderPlacement.aspx.cs" Inherits="iKandi.Web.Internal.Accessory.AccessoryOrderPlacement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_head" runat="server">
    <style type="text/css">
        body {
            background: #f9f9fa none repeat scroll 0 0;
            font-family: arial !important;
        }
        
        table {
            font-family: arial;
            border-color: gray;
            border-collapse: collapse;
        }
        
        table td {
            font-size: 10px;
            text-align: center;
            border-color: #aaa;
            text-transform: capitalize;
            padding: 0px 0px;
            font-family: arial;
            border-color: #dbd8d8;
            height: 20px;
            border: 1px solid #dbd8d8;
        }
        
        .per {
            color: blue;
        }
        
        .gray {
            color: gray;
        }
        
        h2 .row-fir th {
            font-weight: bold;
            font-size: 11px;
        }
        
        table td table td {
            border-color: #ddd;
        }
        
        .SUPPLY-MANA td input {
            width: 35%;
        }
        
        .imageField {
            background-image: url(submit.jpg);
            height: 28px;
            width: 105px;
        }
        
        .pad {
            text-align: left;
            padding-left: 25px;
        }
        
        
        .backcolorstages {
            background: #fdfd96e0 !important;
        }
        
        .float_left {
            float: left;
            padding-left: 3px;
        }
        
        .float_right {
            padding-right: 3px;
        }
        
        .color_black {
            color: #2f2d2d;
        }
        
        /* Change background on mouse-over */
        
        .navbar a:hover {
            background: #ddd;
            color: black;
        }
        
        .tab {
            overflow: hidden;
            border: 0px solid #ccc;
            background-color: #f9f8f8;
            position: sticky;
            top: 21px;
            padding-top: 3px;
            z-index: 7;
        }
        table th {
            top: 46px !important;
        }
        .tab a {
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
        
        .tab a:hover {
            background-color: #ddd;
        }
        /* Create an active/current tablink class */
        
        .tab a.active {
            background-color: #ccc;
        }
        
        /* Style the tab content */
        
        .tabcontent {
            display: none;
            padding: 6px 12px;
            border: 1px solid #ccc;
            border-top: none;
        }
        
        .activeback {
            background: green !important;
            color: #fff;
        }
        
        .navbar tab {
            border: 1px solid #fff;
        }
        
        .maincontentcontainer {
            width: 100%;
            margin: auto;
        }
        
        .decoratedErrorField {
            width: 27% !important;
            border: 2px solid red !important;
        }
        
        .UsernameColor {
            font-weight: 600;
        }
        .grdgsmcom {
            border: 1px solid #999;
        }
        .grdgsmcom td:first-child {
            border-left-color: #999 !important;
        }
        
        .grdgsmcom td:last-child {
            border-right-color: #999 !important;
        }
        
        .grdgsmcom tr:nth-last-child(1) > td {
            border-bottom-color: #999 !important;
        }
        td.border_bottom_rowspan {
            border-bottom-color: #999 !important;
        }
        .clsSupplier td {
            border: 1px solid #999;
            width: 150px;
        }
        @media screen and (max-width: 1366px) {
            .textright {
                width: 56.1% !important;
            }
        }
        .tab1greige {
            cursor: pointer;
        }
        .clsDivHdr {
            background: #39589c;
            font-weight: normal;
            color: #fff;
            font-family: arial;
            font-size: 13px;
            padding: 5px 0px;
            text-align: center;
            text-transform: capitalize;
            border: 1px solid #999;
            width: 1318px;
            border-bottom: 0px;
        }
        
        .btnrpo {
            cursor: pointer;
            background-color: blue;
            color: #f5f5f5 !important;
            width: 30px;
            font-size: 9px;
            border-radius: 20px;
            padding: 3px 2px;
            float: right;
            margin: 0 2px;
        }
        .btnrepo {
            cursor: pointer;
            background-color: #FFA500;
            color: #000 !important;
            width: 30px;
            font-size: 9px;
            border-radius: 20px;
            padding: 2px 2px;
            margin: 2px auto;
        }
        td.clsSupplier {
            border-right: 1px solid #999;
            padding: 0px 4px;
            min-width: 110px;
            max-width: 110px;
        }
        .SupplierTable {
            height: 100%;
        }
        .SuppleirMainTd {
            min-width: 350px;
            max-width: 360px;
        }
        .grdStyleg {
            border: 0px !important;
        }
        .grdStyleg td {
            border-left: 0px !important;
        }
        .grdStyleg td.border_right {
            border-right: 0px !important;
        }
        .grdgsmcom .grdStyleg tr:nth-last-child(1) > td {
            border-bottom-color: #dbd8d8 !important;
        }
        #sb-wrapper-inner.BorderPopup {
            border: 5px solid #999;
            border-radius: 5px;
            background: #fff;
        }
        #sb-wrapper-inner.BorderPopupDetails {
            border: 1px solid #999;
        }
        .PoDetailsinner td {
            min-width: 40px;
            max-width: 40px;
            border: 1px solid #dbd8d8;
            border-top: 0px;
            border-collapse: collapse;
            border-right: 0px;
        }
        .PoDetailsinner th {
            min-width: 40px;
            max-width: 40px;
            border: 0px solid #999;
            border-top: 0px;
            border-collapse: collapse;
            border-right: 1px solid #999;
            border-left: 0px !important;
        }
        .PoDetailsinner th:last-child {
            border-right: 0px !important;
        }
        
        .grdgsmcom th {
            padding: 0px 2px;
            height: 15px;
            background: #dddfe4;
            font-weight: 500;
            color: #575759;
            font-family: arial;
            font-size: 10px;
            border-color: #999;
            z-index: 99;
        }
        .grdgsmcom td {
            font-family: arial;
            font-size: 10px;
            height: 15px;
        }
        .grdgsmcom td .PoTable {
            width: 100%;
            height: 100%;
        }
        .grdgsmcom td .PoTable tr:nth-last-child(1) > td {
            border-bottom: 0px;
        }
        td table.PoTable td:last-child {
            border-right: 0px !important;
        }
        .grdgsmcom td .PoTable td:first-child {
            border-left: 0px;
        }
        .grdgsmcom td .PoTable tr:first-child td {
            border-top: 0;
        }
        .PoDetailsinnertdwidth_100 {
            min-width: 77px !important;
            max-width: 77px !important;
        }
        .border_right_0 {
            border: 0px;
        }
        .txtLeft {
            text-align: left;
        }
        .txtRight {
            text-align: right;
        }
        .txtLeftPaddingL {
            text-align: left;
            padding-left: 2px;
            border-left: 1px solid #999;
        }
        .txtWaste {
            text-align: center;
            font-size: 10px !important;
            font-family: Arial;
            border-radius: 2px;
            height: 13px !important;
            color: Blue !important;
        }
        .grdgsmcom td .PoTable td {
            border: 0px;
            border-right: 1px solid #dbd8d8;
        }
        td.border_right_0 {
            border-right: 0px !important;
        }
        /* .Pheight
        {
            height:600px !important;
        }*/
        
        [data-title] {
            position: relative;
        }
        
        [data-title]:hover::after {
            content: attr(data-title);
            position: absolute;
            top: 17px;
            left: 0px;
            width: auto;
            padding: 5px 8px;
            background: #403c3c;
            color: #fff;
            z-index: 9;
            font-size: 10px;
            height: auto;
            line-height: 12px;
            border-radius: 3px;
            white-space: pre-line;
            word-wrap: break-word;
            min-width: 70px;
        }
        [data-title]:hover::before {
            content: '';
            position: absolute;
            bottom: -6px;
            left: 5px;
            display: inline-block;
            color: #fff;
            border: 10px solid transparent;
            border-bottom: 10px solid #403c3c;
        }
        .RowBackColor {
            background: #f1eaf0;
        }
        .InnerTableShrn td:last-child {
            border-right: 0px !important;
            height: 20px;
        }
        td[colspan="12"] {
            padding-left: 0px !important;
        }
        td[colspan="15"] {
            padding-left: 0px !important;
        }
        td[colspan="11"] {
            padding-left: 0px !important;
        }
        .StarVerticalCenter {
            position: relative;
            top: 3px;
            font-size: 11px;
        }
        .AccessToltip {
            position: relative;
            display: inline-block;
        }
        
        .AccessToltip .TooltipTxt {
            visibility: hidden;
            width: 180px;
            background-color: #767676;
            color: #fff;
            text-align: left;
            border-radius: 6px;
            padding: 5px 5px;
            position: absolute;
            z-index: 999;
            bottom: 150%;
            left: 0%;
            margin-left: -60px;
            line-height: 15px;
        }
        
        .AccessToltip .TooltipTxt::after {
            content: "";
            position: absolute;
            top: 100%;
            left: 35%;
            margin-left: -5px;
            border-width: 5px;
            border-style: solid;
            border-color: black transparent transparent transparent;
        }
        
        .AccessToltip:hover .TooltipTxt {
            visibility: visible;
        }
    </style>
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
    <link href="../../css/TopHeaderFixed.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">

        var grdGreigeClientId = '<%=grdGreige.ClientID %>';
        var grdProcessClientId = '<%=grdProcess.ClientID %>';
        var grdFinishClientId = '<%=grdFinish.ClientID %>';
        var hdnTab = '<%=hdntabvalue.ClientID %>';
        var btnSearch = '<%=btnSearch.ClientID%>';


        $(document).ready(function () {
            //alert("test");
            var stage1 = GetParameterValues('stage1');

            //  alert("Hello " + stage1);
            function GetParameterValues(param) {
                var url = window.location.href.slice(window.location.href.indexOf('?') + 1).split('&');
                for (var i = 0; i < url.length; i++) {
                    var urlparam = url[i].split('=');
                    if (urlparam[0] == param) {
                        return urlparam[1];
                    }
                }
            }
            $(".tab1").click(function () {
                $(this).addClass('activeback').siblings().removeClass('activeback');
            });
            if (stage1 == 2) {
                $("#" + hdnTab).val('FINISHING');

                $(".tab1finished").addClass('activeback');
                $(".tab1Process").removeClass('activeback');
                $(".tab1griege").removeClass('activeback');
                $("#" + btnSearch).click();
                $("#" + grdGreigeClientId).show();
                $("#" + grdProcessClientId).show();
                $("#" + grdFinishClientId).show();


            } else if (stage1 == 1) {
                $("#" + hdnTab).val('GREIGE');
                $(".tab1greige").addClass('activeback');
                $(".tab1Process").removeClass('activeback');
                $(".tab1finished").removeClass('activeback');
                $("#" + btnSearch).click();
                $("#" + grdGreigeClientId).show();
                $("#" + grdProcessClientId).show();
                $("#" + grdFinishClientId).show();

            }
            else if (stage1 == 0) {
                $("#" + hdnTab).val('GREIGE');
                //$(".clsDivHdr").html("Pending Greige Orders and Order Placement");

                $(".tab1greige").addClass('activeback');
                $(".tab1Process").removeClass('activeback');
                $(".tab1finished").removeClass('activeback');
                $("#" + btnSearch).click();
                $("#" + grdGreigeClientId).show();
                $("#" + grdProcessClientId).show();
                $("#" + grdFinishClientId).show();

            }
            $("#" + hdnTab).val('GREIGE');
            //$(".clsDivHdr").html("Pending Greige Orders and Order Placement");

            $(".tab1greige").addClass('activeback');
            $(".tab1Process").removeClass('activeback');
            $(".tab1finished").removeClass('activeback');

            $("#" + grdGreigeClientId).show();
            $("#" + grdProcessClientId).show();
            $("#" + grdFinishClientId).show();
        });

        function ShowHideSuppliergrd(type) {
            //   
            // alert(type);            
            $("#" + hdnTab).val(type);
            $(".clsBtnTab").click();
        }

        function ShowAllSupplier(AccessoryMasterId, Size, ColorPrint, type) {
            // 
            var url = '../../Internal/Accessory/AccessorySupplierDetails.aspx?AccessoryMasterId=' + AccessoryMasterId + '&Size=' + Size + '&ColorPrint=' + ColorPrint + '&AccessoryType=' + type;
            Shadowbox.init({ animate: true, animateFade: true, modal: true });
            Shadowbox.open({ content: url, type: "iframe", player: "iframe", title: "", height: 220, width: 700, modal: true, animate: true, animateFade: true, options: { onClose: SBClose} });
            $("#sb-wrapper-inner").removeClass("BorderPopup");
            $("#sb-wrapper-inner").addClass("BorderPopupDetails");
            return false;
        }

        function ShowPurchaseOrder(obj, AccessoryMasterId, Size, ColorPrint, SupplierPoId, type) {
            // 
            var gvId = obj.id.split("_")[5];
            var Shrinkage = 0;
            var Wastage = 0;
            var QtyToOrder = 0;

            if (type == 1) {
                Shrinkage = $("#<%= grdGreige.ClientID %> input[id*='" + gvId + "_txtShrnkg" + "']").val();
                Wastage = $("#<%= grdGreige.ClientID %> input[id*='" + gvId + "_txtWastage" + "']").val();
                QtyToOrder = $("#<%= grdGreige.ClientID %> input[id*='" + gvId + "_hdnPendingQtyToOrder" + "']").val();
            }
            if (type == 2) {
                Shrinkage = $("#<%= grdProcess.ClientID %> input[id*='" + gvId + "_txtShrnkg" + "']").val();
                Wastage = $("#<%= grdProcess.ClientID %> input[id*='" + gvId + "_txtWastage" + "']").val();
                QtyToOrder = $("#<%= grdProcess.ClientID %> input[id*='" + gvId + "_hdnPendingQtyToOrder" + "']").val();
            }
            if (type == 3) {
                Wastage = $("#<%= grdFinish.ClientID %> input[id*='" + gvId + "_txtWastage" + "']").val();
                QtyToOrder = $("#<%= grdFinish.ClientID %> input[id*='" + gvId + "_hdnPendingQtyToOrder" + "']").val();
            }

            if (Shrinkage == '')
                Shrinkage = 0;

            if (Wastage == '')
                Wastage = 0;

            var url = 'AccessoryPurchaseOrder.aspx?Shrinkage=' + Shrinkage + '&Wastage=' + Wastage + '&AccessoryMasterId=' + AccessoryMasterId + '&Size=' + Size + '&ColorPrint=' + ColorPrint + '&QtyToOrder=' + QtyToOrder + '&SupplierPoId=' + SupplierPoId + '&AccessoryType=' + type;
            Shadowbox.init({ animate: true, animateFade: true, modal: true });
            Shadowbox.open({ content: url, type: "iframe", player: "iframe", title: "", height: 900, width: 1200, modal: true, animate: true, animateFade: true, options: { onClose: SBClose} });
            $("#sb-wrapper-inner").removeClass("BorderPopupDetails");
            $("#sb-wrapper-inner").addClass("BorderPopup");
            return false;
        }

        function ShowPurchaseOrderPo(AccessoryMasterId, Size, ColorPrint, QtyToOrder, SupplierPoId, type) {
            //             
            var url = 'AccessoryPurchaseOrder.aspx?AccessoryMasterId=' + AccessoryMasterId + '&Size=' + Size + '&ColorPrint=' + ColorPrint + '&QtyToOrder=' + QtyToOrder + '&SupplierPoId=' + SupplierPoId + '&AccessoryType=' + type;
            Shadowbox.init({ animate: true, animateFade: true, modal: true });
            Shadowbox.open({ content: url, type: "iframe", player: "iframe", title: "", width: 1200, modal: true, animate: true, animateFade: true, options: { onClose: SBClose} });
            $("#sb-wrapper-inner").removeClass("BorderPopupDetails");
            $("#sb-wrapper-inner").addClass("BorderPopup");
            return false;
        }

        function SBClose() { }

        function DeletePo(SupplierPoID) {
            // 
            //alert(SupplierPoID);
            var TabVal = $("#" + hdnTab).val();
            if (SupplierPoID != "-1") {
                if (confirm('Are you sure want to delete this P.O ?')) {
                    proxy.invoke("Delete_AccessoryPO", { SupplierPoId: SupplierPoID },
                    function (result) {
                        if (result > 0) {
                            ShowHideSuppliergrd(TabVal);
                            return false;
                        }
                    });
                }
            }
        }

        function CalculateQuantity(elem, type) {

            var gvId = elem.id.split("_")[5];
            var Shrinkage = 0;
            var Wastage = 0;
            var AccessoryQty = 0;
            var TotalQtyRecieved = 0;
            var QtyToOrder = 0;
            //For Greige
            if (type == 1) {
                Shrinkage = $("#<%= grdGreige.ClientID %> input[id*='" + gvId + "_txtShrnkg" + "']").val();
                Wastage = $("#<%= grdGreige.ClientID %> input[id*='" + gvId + "_txtWastage" + "']").val();
                AccessoryQty = $("#<%= grdGreige.ClientID %> input[id*='" + gvId + "_hdnAccessoryQty" + "']").val();
                TotalQtyRecieved = $("#<%= grdGreige.ClientID %> input[id*='" + gvId + "_hdnTotalQtyRecieved" + "']").val();

                if (Shrinkage == '')
                    Shrinkage = 0;

                if (Wastage == '')
                    Wastage = 0;

                var FirstVaraible = 0;
                var SecondVariable = 0;

                if ((100 - (parseFloat(Shrinkage) + parseFloat(Wastage))) > 0) {
                    FirstVaraible = (parseFloat(AccessoryQty) * 100) / (100 - (parseFloat(Shrinkage)));
                    SecondVariable = (parseFloat(FirstVaraible) * 100) / (100 - (parseFloat(Wastage)));

//                    QtyToOrder = Math.ceil((parseFloat(FirstVaraible) * 100) / (100 - (parseFloat(Wastage))));
                    QtyToOrder = Math.round((parseFloat(FirstVaraible) * 100) / (100 - (parseFloat(Wastage))));
                }
                else {
                    QtyToOrder = AccessoryQty
                }
                if (parseFloat(Shrinkage) > 0) {
                    var ShrinkageValue = (parseFloat(FirstVaraible) - parseFloat(AccessoryQty)).toFixed(0);
                    $("#<%= grdGreige.ClientID %> span[id*='" + gvId + "_lblShrnkgValue" + "']").text('(' + numberWithCommas(ShrinkageValue) + ')');
                }
                else {
                    $("#<%= grdGreige.ClientID %> span[id*='" + gvId + "_lblShrnkgValue" + "']").text('');
                }
                if (parseFloat(Wastage) > 0) {
                    var WastageValue = (parseFloat(SecondVariable) - parseFloat(FirstVaraible)).toFixed(0);
                    $("#<%= grdGreige.ClientID %> span[id*='" + gvId + "_lblWastageValue" + "']").text('(' + numberWithCommas(WastageValue) + ')');
                }
                else {
                    $("#<%= grdGreige.ClientID %> span[id*='" + gvId + "_lblWastageValue" + "']").text('');
                }

                $("#<%= grdGreige.ClientID %> input[id*='" + gvId + "_hdnQuantityToOrder" + "']").val(QtyToOrder);
                $("#<%= grdGreige.ClientID %> span[id*='" + gvId + "_lblQuantityToOrder" + "']").text(numberWithCommas(QtyToOrder));

                var RemainingQty = parseInt(QtyToOrder) - parseInt(TotalQtyRecieved);

                $("#<%= grdGreige.ClientID %> input[id*='" + gvId + "_hdnPendingQtyToOrder" + "']").val(RemainingQty);
                $("#<%= grdGreige.ClientID %> span[id*='" + gvId + "_lblPendingQtyToOrder" + "']").text(numberWithCommas(RemainingQty));
//                if (parseInt(RemainingQty) > 0) {
//                    $("#<%= grdGreige.ClientID %> span[id*='" + gvId + "_lblPendingQtyToOrder" + "']").text(numberWithCommas(RemainingQty));
//                }
//                else {
//                    $("#<%= grdGreige.ClientID %> span[id*='" + gvId + "_lblPendingQtyToOrder" + "']").text('');
//                }
            }

            //For Process
            if (type == 2) {
                Shrinkage = $("#<%= grdProcess.ClientID %> input[id*='" + gvId + "_txtShrnkg" + "']").val();
                Wastage = $("#<%= grdProcess.ClientID %> input[id*='" + gvId + "_txtWastage" + "']").val();
                AccessoryQty = $("#<%= grdProcess.ClientID %> input[id*='" + gvId + "_hdnAccessoryQty" + "']").val();

                if (Shrinkage == '')
                    Shrinkage = 0;

                if (Wastage == '')
                    Wastage = 0;

                var FirstVaraible = 0;
                var SecondVariable = 0;

                if ((100 - (parseFloat(Shrinkage) + parseFloat(Wastage))) > 0) {
                    FirstVaraible = (parseFloat(AccessoryQty) * 100) / (100 - (parseFloat(Shrinkage)));
                    SecondVariable = (parseFloat(FirstVaraible) * 100) / (100 - (parseFloat(Wastage)));

//                    QtyToOrder = Math.ceil((parseFloat(FirstVaraible) * 100) / (100 - (parseFloat(Wastage))));
                    QtyToOrder = Math.round((parseFloat(FirstVaraible) * 100) / (100 - (parseFloat(Wastage))));
                }
                else {
                    QtyToOrder = AccessoryQty
                }
                if (parseInt(Shrinkage) > 0) {
                    var ShrinkageValue = (parseFloat(FirstVaraible) - parseFloat(AccessoryQty)).toFixed(0);
                    $("#<%= grdProcess.ClientID %> span[id*='" + gvId + "_lblShrnkgValue" + "']").text('(' + numberWithCommas(ShrinkageValue) + ')');
                }
                else {
                    $("#<%= grdProcess.ClientID %> span[id*='" + gvId + "_lblShrnkgValue" + "']").text('');
                }
                if (parseInt(Wastage) > 0) {
                    var WastageValue = (parseFloat(SecondVariable) - parseFloat(FirstVaraible)).toFixed(0);
                    $("#<%= grdProcess.ClientID %> span[id*='" + gvId + "_lblWastageValue" + "']").text('(' + numberWithCommas(WastageValue) + ')');
                }
                else {
                    $("#<%= grdProcess.ClientID %> span[id*='" + gvId + "_lblWastageValue" + "']").text('');
                }

                $("#<%= grdProcess.ClientID %> span[id*='" + gvId + "_lblAccessTotalQtySend" + "']").text(numberWithCommas(QtyToOrder));

                //var TotalPassQty = $("#<%= grdProcess.ClientID %> input[id*='" + gvId + "_hdnTotalPassQty" + "']").val();
                var SendQty = $("#<%= grdProcess.ClientID %> input[id*='" + gvId + "_hdnSendQty" + "']").val();

                var RemainingQty = parseInt(QtyToOrder) - parseInt(SendQty);

                $("#<%= grdProcess.ClientID %> input[id*='" + gvId + "_hdnPendingQtyToOrder" + "']").val(RemainingQty);
//                if (parseInt(RemainingQty) > 0) {
                    $("#<%= grdProcess.ClientID %> span[id*='" + gvId + "_lblPendingQtyToOrder" + "']").text(numberWithCommas(RemainingQty));
//                } else {
//                    $("#<%= grdProcess.ClientID %> span[id*='" + gvId + "_lblPendingQtyToOrder" + "']").text('');
//                }
            }

            //For Finish
            if (type == 3) {
                Wastage = $("#<%= grdFinish.ClientID %> input[id*='" + gvId + "_txtWastage" + "']").val();
                AccessoryQty = $("#<%= grdFinish.ClientID %> input[id*='" + gvId + "_hdnAccessoryQty" + "']").val();
                TotalQtyRecieved = $("#<%= grdFinish.ClientID %> input[id*='" + gvId + "_hdnTotalQtyRecieved" + "']").val();

                if (Wastage == '')
                    Wastage = 0;

                if (100 - (parseInt(Wastage)) > 0) {
//                    QtyToOrder = Math.ceil((parseFloat(AccessoryQty) * 100) / (100 - parseFloat(Wastage)));
                    QtyToOrder = Math.round((parseFloat(AccessoryQty) * 100) / (100 - parseFloat(Wastage)));
                }
                else {
                    QtyToOrder = AccessoryQty
                }

                if (parseFloat(Wastage) > 0) {
                    var WastageValue = (parseFloat(QtyToOrder) - parseFloat(AccessoryQty)).toFixed(0);
                    $("#<%= grdFinish.ClientID %> span[id*='" + gvId + "_lblWastageValue" + "']").text('(' + numberWithCommas(WastageValue) + ')');
                }
                else {
                    $("#<%= grdFinish.ClientID %> span[id*='" + gvId + "_lblWastageValue" + "']").text('');
                }

                $("#<%= grdFinish.ClientID %> input[id*='" + gvId + "_hdnQuantityToOrder" + "']").val(QtyToOrder);
                $("#<%= grdFinish.ClientID %> span[id*='" + gvId + "_lblQuantityToOrder" + "']").text(numberWithCommas(QtyToOrder));

                var RemainingQty = parseInt(QtyToOrder) - parseInt(TotalQtyRecieved);

                $("#<%= grdFinish.ClientID %> input[id*='" + gvId + "_hdnPendingQtyToOrder" + "']").val(RemainingQty);
//                if (parseInt(RemainingQty) > 0) {
                    $("#<%= grdFinish.ClientID %> span[id*='" + gvId + "_lblPendingQtyToOrder" + "']").text(numberWithCommas(RemainingQty));
//                }
//                else {
//                    $("#<%= grdFinish.ClientID %> span[id*='" + gvId + "_lblPendingQtyToOrder" + "']").text('');
//                }
            }

        }

        function numberWithCommas(x) {
            return x.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",");
        }

        $("document").ready(function () {
            $('.grdgsmcom tr').click(function () {
                $('.grdgsmcom tr').removeClass('RowBackColor');
                $(this).toggleClass('RowBackColor');
            })
        })
        function pageLoad() {
            $('.grdgsmcom tr').click(function () {
                $('.grdgsmcom tr').removeClass('RowBackColor');
                $(this).toggleClass('RowBackColor');
            })
        }

        //new code start
        function ShowFormulaeForGreige(elem) {
            // 
            var gvId = elem.id.split("_")[5];
            var Shrinkage = "";
            var Wastage = "";
            var ShrinkageWithBrackets = "";
            var WastageWithBrackets = "";
            var AccessoryQty = 0;
            Shrinkage = $("#<%= grdGreige.ClientID %> input[id*='" + gvId + "_txtShrnkg" + "']").val();
            Wastage = $("#<%= grdGreige.ClientID %> input[id*='" + gvId + "_txtWastage" + "']").val();
            AccessoryQty = $("#<%= grdGreige.ClientID %> input[id*='" + gvId + "_hdnAccessoryQty" + "']").val();
            ShrinkageWithBrackets = (Shrinkage == "" || Shrinkage == "0") ? ShrinkageWithBrackets = "" : ShrinkageWithBrackets = "/(1-" + Shrinkage + "%)";
            WastageWithBrackets = (Wastage == "" || Wastage == "0") ? WastageWithBrackets = "" : WastageWithBrackets = "/(1-" + Wastage + "%)";

            $("#ctl00_cph_main_content_grdGreige_" + gvId + "_lblTooltip").text('');
            var formula = '<span style="color:#d9dac7"> Send Qty: </span> (' + AccessoryQty + ShrinkageWithBrackets + ")" + WastageWithBrackets;
            $("#ctl00_cph_main_content_grdGreige_" + gvId + "_lblTooltip").html(formula);
            $("#ctl00_cph_main_content_grdGreige_" + gvId + "_lblTooltip").addClass("TooltipTxt");
        }

        function ShowFormulaeForProcess(elem) {
            // 
            var gvId = elem.id.split("_")[5];
            var Shrinkage = "";
            var Wastage = "";
            var ShrinkageWithBrackets = "";
            var WastageWithBrackets = "";
            var ShrinkageWithoutSlash = ""
            var AccessoryQty = 0;
            var MultiplierSign = "";

            Shrinkage = $("#<%= grdProcess.ClientID %> input[id*='" + gvId + "_txtShrnkg" + "']").val();
            Wastage = $("#<%= grdProcess.ClientID %> input[id*='" + gvId + "_txtWastage" + "']").val();
            AccessoryQty = $("#<%= grdProcess.ClientID %> input[id*='" + gvId + "_hdnAccessoryQty" + "']").val();
            ShrinkageWithBrackets = (Shrinkage == "" || Shrinkage == "0") ? ShrinkageWithBrackets = "" : ShrinkageWithBrackets = "/(1-" + Shrinkage + "%)";
            ShrinkageWithoutSlash = (Shrinkage == "" || Shrinkage == "0") ? ShrinkageWithoutSlash = "" : ShrinkageWithoutSlash = "(1-" + Shrinkage + "%)";
            WastageWithBrackets = (Wastage == "" || Wastage == "0") ? WastageWithBrackets = "" : WastageWithBrackets = "/(1-" + Wastage + "%)";
            MultiplierSign = ((Shrinkage != "" && Shrinkage != "0") && (Wastage != "" && Wastage != "0")) ? '<span style="position:relative;top:2px:> * </span>' : "";

            $("#ctl00_cph_main_content_grdProcess_" + gvId + "_lblProcessTooltip").text('');
            var SendQtyFormula = " <span style='color:#d9dac7'> Send Qty: </span>(" + AccessoryQty + ShrinkageWithBrackets + ")" + WastageWithBrackets;
            var RecQtyFormula = " <span style='color:#d9dac7'> Rec Qty: </span>(" + AccessoryQty + "" + ShrinkageWithBrackets + WastageWithBrackets + MultiplierSign + ShrinkageWithoutSlash + ")";
            var formula = SendQtyFormula + '<br>' + RecQtyFormula;
            $("#ctl00_cph_main_content_grdProcess_" + gvId + "_lblProcessTooltip").html(formula);
            $("#ctl00_cph_main_content_grdProcess_" + gvId + "_lblProcessTooltip").addClass("TooltipTxt");
        }

        function ShowFormulaeForFinish(elem) {
            // 
            var gvId = elem.id.split("_")[5];
            var Wastage = "";
            var WastageWithBrackets = "";
            var AccessoryQty = 0;
            Wastage = $("#<%= grdFinish.ClientID %> input[id*='" + gvId + "_txtWastage" + "']").val();
            AccessoryQty = $("#<%= grdFinish.ClientID %> input[id*='" + gvId + "_hdnAccessoryQty" + "']").val();
            WastageWithBrackets = (Wastage == "" || Wastage == "0") ? WastageWithBrackets = "" : WastageWithBrackets = "/(1-" + Wastage + "%)";

            $("#ctl00_cph_main_content_grdFinish_" + gvId + "_lblTooltip").text('');
            var formula = '<span style="color:#d9dac7"> Send Qty: </span> (' + AccessoryQty + WastageWithBrackets + ')';
            $("#ctl00_cph_main_content_grdFinish_" + gvId + "_lblTooltip").html(formula);
            $("#ctl00_cph_main_content_grdFinish_" + gvId + "_lblTooltip").addClass("TooltipTxt");
        }

        //added by Girish on 2023-03-14
        function isDecimalNumber(event) {
            var charCode = (event.which) ? event.which : event.keyCode;
            var input = event.target.value;
            var decimalIndex = input.indexOf('.');
            if (charCode == 46) {
                // allow decimal point if there is no decimal point yet
                if (decimalIndex == -1) {
                    return true;
                } else {
                    return false;
                }
            } else if (charCode > 31 && (charCode < 48 || charCode > 57)) {
                // disallow any non-numeric character
                return false;
            }
            return true;
        }
        //added by Girish on 2023-03-14

        //new code end
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_main_content" runat="server">
    <asp:ScriptManager ID="script1" runat="server">
    </asp:ScriptManager>
    <asp:UpdateProgress runat="server" ID="uproTargetAdmin" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="0">
        <ProgressTemplate>
            <img src="../../App_Themes/ikandi/images1/loading36.gif" alt="" style="position: fixed; z-index: 52111; top: 40%; left: 45%; width: 6%;" />
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:HiddenField ID="hdntabvalue" runat="server" />
            <div class="headerSticky" style="width: 100%; margin: auto;">
                Raise<span style="text-transform: lowercase"> and</span> Revise Accessory PO</div>
            <div style="clear: both">
            </div>
            <div style="width: 100%; background-color: White; z-index: 999;" class="tab">
                <a runat="server" id="aGreige" class="tab1greige" onclick="ShowHideSuppliergrd('GREIGE');">Greige</a> <a runat="server" id="aProcess" class="tab1Process" onclick="ShowHideSuppliergrd('PROCESS');">Process</a> <a runat="server" id="aFinish" class="tab1finished" onclick="ShowHideSuppliergrd('FINISHING');">Finish</a>
                <div style="float: right;">
                    <asp:TextBox ID="txtsearchkeyswords" class="search_1" placeholder="Search Accessory Quality/Color Print" runat="server" Style="width: 250px !important; margin: 0px 0px 1px; padding-left: 4px; text-align: left; font-size: 11px;"></asp:TextBox>
                    <asp:Button ID="btnSearch" runat="server" CssClass="go do-not-disable" Text="Search" Style="padding: 2px 7px;" OnClick="btnSearch_Click" />
                </div>
            </div>
            <div style="clear: both">
            </div>
            <div class="maincontentcontainer">
                <asp:Button ID="btnTab" CssClass="clsBtnTab" runat="server" Style="display: none;" Text="" OnClick="btnTab_Click" />
                <asp:GridView ID="grdGreige" CssClass="grdgsmcom" Style="display: none;" runat="server" AutoGenerateColumns="False" EmptyDataText="No Record Found!" Width="100%" HeaderStyle-Font-Names="Arial" HeaderStyle-HorizontalAlign="Center" BorderWidth="0" rules="all" HeaderStyle-CssClass="ths" OnRowDataBound="grdGreige_RowDataBound">
                    <SelectedRowStyle BackColor="#A1DCF2" />
                    <Columns>
                        <asp:TemplateField HeaderText="Accessory Quality (Size)<br> Unit">
                            <ItemStyle HorizontalAlign="Center" CssClass="txtLeftPaddingL" Width="170px" />
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Label ID="lblAccessoryQuality" ForeColor="blue" Text='<%# Eval("AccessoryName")%>' runat="server"></asp:Label>
                                <asp:Label ID="lblSize" Text='<%# Eval("Size")%>' ForeColor="gray" runat="server"></asp:Label>
                                <br />
                                <asp:Label ID="lblUnit" Text='<%# Eval("GarmentUnitName")%>' ForeColor="gray" Font-Bold="true" runat="server"></asp:Label>
                                <asp:HiddenField ID="hdnAccessoryMasterId" Value='<%# Eval("AccessoryMasterId")%>' runat="server" />
                                <asp:HiddenField ID="hdnSize" Value='<%# Eval("Size")%>' runat="server" />
                                <asp:HiddenField ID="hdnColorPrint" Value='<%# Eval("Color_Print")%>' runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <table border="0" cellpadding="0" cellspacing="0" style="width: 100%; height: 100%; margin: 0 auto;">
                                    <tr>
                                        <th class="border_right_0" style="border: 0px !important;text-align: left;">
                                            Style No.
                                        </th>
                                        <th class="border_right_0" style="border: 0px !important;text-align: right;">(Serial No.)</th>
                                    </tr>
                                </table>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:GridView ID="grdStyle" CssClass="grdgsmcom grdStyleg" Width="98%" EmptyDataText="No Record Found"  AutoGenerateColumns="false" Border="0" ShowFooter="false" OnRowDataBound="grdStyle_RowDataBound" ShowHeader="false" runat="server" Style="margin: 0 auto" >
                                    <Columns>
                                        <asp:TemplateField ItemStyle-Width="80px">
                                            <ItemTemplate>
                                                <asp:Label ID="lblStyle" runat="server" Text='<%# Eval("StyleNumber")%>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle CssClass="border_right_0 txtLeft" />
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-Width="80px">
                                            <ItemTemplate>
                                                <asp:Label ID="lblSerialNo" runat="server" Text='<%# Eval("SerialNumber")%>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle CssClass="border_right_0 txtRight" />
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </ItemTemplate>
                            <ItemStyle Width="150px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Accessory Qty.</br> <span style='color:gray;font-size:8px;line-height: 14px;'>Contract Qty<span class='StarVerticalCenter'>*</span>Avg </span>">
                            <ItemTemplate>
                                <asp:Label ID="lblAccessoryQty" runat="server" Text='<%# Convert.ToString(Eval("AccessoryQty")) == "0" ? "" : Convert.ToString(Eval("AccessoryQty")) %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="70px" />
                            <HeaderStyle Width="70px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Shrnk.%<span style='color:gray;font-size:8px;line-height: 14px;'>(Shrnk. Val.)</span>">
                            <ItemTemplate>
                                <table class="InnerTableShrn">
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="txtShrnkg" onkeypress="return isDecimalNumber(event)" onchange="CalculateQuantity(this, 1);ShowFormulaeForGreige(this)" CssClass="numeric-field-with-decimal-places txtWaste" MaxLength="5" Text='<%# Convert.ToString(Eval("Shrinkage")) == "0" ? "" : Convert.ToString(Eval("Shrinkage")) %>' runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblShrnkgValue" ForeColor="Gray" runat="server" Text=""></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                            <ItemStyle Width="50px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Wstg.%<br><span style='color:gray;font-size:8px;line-height: 14px;'>(Wstg. Val.)</span>">
                            <ItemTemplate>
                                <table class="InnerTableShrn">
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="txtWastage" onkeypress="return isDecimalNumber(event)" onchange="CalculateQuantity(this, 1);ShowFormulaeForGreige(this)" CssClass="numeric-field-with-decimal-places txtWaste" MaxLength="5" Text='<%# Convert.ToString(Eval("Wastage")) == "0" ? "" : Convert.ToString(Eval("Wastage")) %>' runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblWastageValue" ForeColor="Gray" runat="server" Text=""></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                            <ItemStyle Width="55px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Balance In House <br> (Allocated from Stock)">
                            <ItemTemplate>
                                <div class="AccessToltip">
                                    <asp:Label ID="lblbalanceinhouseqty" runat="server" Text='<%# Convert.ToString(Eval("BalanceQty")) == "0" ? "" : Convert.ToString(Eval("BalanceQty"))%>'></asp:Label>
                                    <asp:Label ID="lblBalanceTooltip" runat="server" Text=""></asp:Label>
                                </div>
                            </ItemTemplate>
                            <ItemStyle Width="70px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Qty. To Order">
                            <ItemTemplate>
                                <div class="AccessToltip">
                                    <asp:Label ID="lblQuantityToOrder" runat="server" Text=""></asp:Label>
                                    <asp:Label ID="lblTooltip" runat="server" Text=""></asp:Label>
                                </div>
                                <asp:HiddenField ID="hdnQuantityToOrder" Value="0" runat="server" />
                                <asp:HiddenField ID="hdnTotalQtyRecieved" Value='<%# Eval("TotalQtyRecieved") %>' runat="server" />
                                <asp:HiddenField ID="hdnAccessoryQty" Value='<%# Eval("AccessoryQty") %>' runat="server" />
                                <asp:HiddenField ID="hdnTotalPassQty" Value='<%# Eval("TotalPassQty")%>' runat="server" />
                            </ItemTemplate>
                            <ItemStyle Width="60px" />
                        </asp:TemplateField>
                     <%--   <asp:TemplateField Visible="false">
                            <HeaderTemplate>
                                <span>Quote 1
                                    <br />
                                    (Rate & Time)<br>
                                    Supplier Name<br>
                                    Lead Time </span>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblQouteRate_1" runat="server"></asp:Label><br />
                                <asp:Label ID="lblQouteSupplierName_1" runat="server"></asp:Label><br />
                                <asp:Label ID="lblQouteLeadDays_1" runat="server"></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="120px" />
                        </asp:TemplateField>
                        <asp:TemplateField Visible="false">
                            <HeaderTemplate>
                                <span>Quote 2
                                    <br />
                                    (Rate & Time)<br>
                                    Supplier Name<br>
                                    Lead Time </span>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblQouteRate_2" runat="server"></asp:Label>
                                <asp:Label ID="lblQouteTime_2" runat="server"></asp:Label><br />
                                <asp:Label ID="lblQouteSupplierName_2" runat="server"></asp:Label><br />
                                <asp:Label ID="lblQouteLeadDays_2" runat="server"></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="120px" />
                        </asp:TemplateField>
                        <asp:TemplateField Visible="false">
                            <HeaderTemplate>
                                <span>Quote 3
                                    <br />
                                    (Rate & Time)<br>
                                    Supplier Name<br>
                                    Lead Time </span>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblQouteRate_3" runat="server"></asp:Label>
                                <asp:Label ID="lblQouteTime_3" runat="server"></asp:Label><br />
                                <asp:Label ID="lblQouteSupplierName_3" runat="server"></asp:Label><br />
                                <asp:Label ID="lblQouteLeadDays_3" runat="server"></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="120px" />
                        </asp:TemplateField>--%>
                        <asp:TemplateField HeaderText="">
                            <HeaderTemplate>
                                <table width="100%" cellpadding="0" cellspacing="0" class="PoDetailsinner" style="height: 100%;">
                                    <tr>
                                        <th style="min-width: 54px; max-width: 54px;">
                                            PO Number
                                        </th>
                                        <th style="min-width: 89px; max-width: 89px;">
                                            PO Supplier Name
                                        </th>
                                        <th style="min-width: 41px; max-width: 41px;">
                                            Rcvd. Qty.
                                        </th>
                                        <th style="min-width: 34px; max-width: 34px;">
                                            Revise PO
                                        </th>
                                    </tr>
                                </table>
                            </HeaderTemplate>
                            <ItemTemplate>
                            </ItemTemplate>
                            <ItemStyle Width="300px" VerticalAlign="Top" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText=" Qty. To Raise PO">
                            <ItemTemplate>
                                <table border="0" cellpadding="0" cellspacing="0" style="width: 100%;">
                                    <tr>
                                        <td style="width: 60px;" class="border_right_0">
                                            <asp:Label ID="lblPendingQtyToOrder" runat="server"></asp:Label>
                                            <asp:HiddenField ID="hdnPendingQtyToOrder" Value="0" runat="server" />
                                        </td>
                                        <td style="width: 12px;" class="border_right_0">
                                            <a id="lnkProductionpopup" title="View All Supplier" runat="server" style="font-size: 8px;">
                                                <img src="../../App_Themes/ikandi/images/zoom_icon1.gif" style="cursor: pointer; position: relative; top: -2px;" />
                                            </a>
                                        </td>
                                        <td style="min-width: 40px;" class="border_right_0">
                                            <asp:Button ID="btnrapo" Style="display: none;" runat="server" Text="R.PO" />
                                            <div class="btnrpo tooltip" style="display: none;" runat="server" id="divraise">
                                                R.PO</div>
                                        </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                            <ItemStyle Width="110px" />
                        </asp:TemplateField>
                    </Columns>
                    <EmptyDataTemplate>
                        <table class="grdgsmcom" cellspacing="0" rules="all" border="0" style="border-width: 0px; width: 100%; border-collapse: collapse;">
                            <tbody>
                                <tr class="ths" align="center" style="font-family: Arial;">
                                    <th align="center" style="border-left: 1px solid #999 !important;" scope="col">
                                        Accessory Quality (Size)<br>
                                        Color/Print &nbsp;&nbsp;&nbsp;&nbsp; (Unit)
                                    </th>
                                    <th scope="col">
                                        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%; height: 100%; margin: 0 auto;">
                                            <tbody>
                                                <tr>
                                                    <th class="border_right_0" style="border: 0px !important;">
                                                        Style No. (Serial No.)
                                                    </th>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </th>
                                    <th scope="col">
                                        Accessory Qty.<br />
                                        <span style='color: gray; font-size: 8px'>Contact Qty<span class='StarVerticalCenter'>*</span>Avg </span>
                                    </th>
                                    <th scope="col">
                                        Shrnk.%
                                        <br />
                                        <span style='color: gray; font-size: 8px'>(Shrnk. Val.)</span>
                                    </th>
                                    <th scope="col">
                                        Wstg.%<br />
                                        <span style='color: gray; font-size: 8px'>(Wstg. Val.)</span>
                                    </th>
                                    <th scope="col">
                                        Balance In House
                                        <br />
                                         (Allocated from Stock)
                                    </th>
                                    <th scope="col">
                                        Qty. To Order
                                    </th>
                                   <%-- <th scope="col">
                                        <span>Quote 1
                                            <br />
                                            (Rate &amp; Time)<br>
                                            Supplier Name<br>
                                            Lead Time </span>
                                    </th>
                                    <th scope="col">
                                        <span>Quotes 2
                                            <br />
                                            (Rate &amp; Time)<br>
                                            Supplier Name<br>
                                            Lead Time </span>
                                    </th>
                                    <th scope="col">
                                        <span>Quotes 3
                                            <br />
                                            (Rate &amp; Time)<br>
                                            Supplier Name<br>
                                            Lead Time </span>
                                    </th>--%>
                                    <th scope="col">
                                        <table width="100%" cellpadding="0" cellspacing="0" class="PoDetailsinner" style="height: 100%;">
                                            <tbody>
                                                <tr>
                                                    <th style="min-width: 54px; max-width: 54px;">
                                                        PO Number
                                                    </th>
                                                    <th style="min-width: 89px; max-width: 89px;">
                                                        PO Supplier Name
                                                    </th>
                                                    <th style="min-width: 41px; max-width: 41px;">
                                                        Rcvd. Qty.
                                                    </th>
                                                    <th style="min-width: 34px; max-width: 34px;">
                                                        Revise PO
                                                    </th>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </th>
                                    <th scope="col" style="border-right: 0px;">
                                        Qty. To Raise PO
                                    </th>
                                </tr>
                                <tr>
                                    <td colspan="15" style="border-left: 1px solid #999; border-bottom: 0px; border-right: 0px; text-align: center">
                                        <img src="../../images/sorry.png" />
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </EmptyDataTemplate>
                </asp:GridView>
              
                <asp:GridView ID="grdProcess" CssClass="grdgsmcom" Style="display: none;" runat="server" AutoGenerateColumns="False" EmptyDataText="No Record Found!" Width="100%" HeaderStyle-Font-Names="Arial" HeaderStyle-HorizontalAlign="Center" BorderWidth="0" rules="all" HeaderStyle-CssClass="ths" OnRowDataBound="grdProcess_RowDataBound">
                    <SelectedRowStyle BackColor="#A1DCF2" />
                    <Columns>
                        <asp:TemplateField HeaderText="Accessory Quality (Size)<br> Color/Print <br> Unit">
                            <ItemStyle HorizontalAlign="Center" CssClass="txtLeftPaddingL" Width="170px" />
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Label ID="lblAccessoryQuality" ForeColor="blue" Text='<%# Eval("AccessoryName")%>' runat="server"></asp:Label>
                                <asp:Label ID="lblSize" Text='<%# Eval("Size")%>' runat="server"></asp:Label>
                                <br />
                                <asp:Label ID="lblcolorprint" Height="15px" Font-Bold="true" ForeColor="Black" Text='<%# Eval("Color_Print")%>' runat="server"></asp:Label></div>
                                <br />
                                <asp:Label ID="lblUnit" Text='<%# Eval("GarmentUnitName")%>' Font-Bold="true" ForeColor="gray" runat="server"></asp:Label>
                                <asp:HiddenField ID="hdnAccessoryMasterId" Value='<%# Eval("AccessoryMasterId")%>' runat="server" />
                                <asp:HiddenField ID="hdnSize" Value='<%# Eval("Size")%>' runat="server" />
                                <asp:HiddenField ID="hdnColorPrint" Value='<%# Eval("Color_Print")%>' runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                 <table border="0" cellpadding="0" cellspacing="0" style="width: 100%; height: 100%; margin: 0 auto;">
                                    <tr>
                                        <th class="border_right_0" style="border: 0px !important;text-align: left;">
                                            Style No.
                                        </th>
                                        <th class="border_right_0" style="border: 0px !important;text-align: right;">(Serial No.)</th>
                                    </tr>
                                </table>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:GridView ID="grdProStyle" CssClass="grdgsmcom grdStyleg" Width="98%" AutoGenerateColumns="false" ShowFooter="false" OnRowDataBound="grdStyle_RowDataBound" ShowHeader="false" runat="server" Style="margin: 0 auto">
                                    <Columns>
                                        <asp:TemplateField ItemStyle-Width="80px">
                                            <ItemTemplate>
                                                <asp:Label ID="lblStyle" runat="server" Text='<%# Eval("StyleNumber")%>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle CssClass="border_right_0 txtLeft" />
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-Width="80px">
                                            <ItemTemplate>
                                                <asp:Label ID="lblSerialNo" runat="server" Text='<%# Eval("SerialNumber")%>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle CssClass="border_right_0 txtRight" />
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </ItemTemplate>
                            <ItemStyle Width="150px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Accessory Qty.</br> <span style='color:gray;font-size:8px;line-height: 14px;'>Contract Qty<span class='StarVerticalCenter'>*</span>Avg </span>">
                            <ItemTemplate>
                                <asp:Label ID="lblProAccessoryQty" runat="server" Text='<%# Convert.ToString(Eval("AccessoryQty")) == "0" ? "" : Convert.ToString(Eval("AccessoryQty")) %>'></asp:Label>
                                <asp:HiddenField ID="hdnAccessoryQty" Value='<%# Eval("AccessoryQty")%>' runat="server" />
                            </ItemTemplate>
                            <ItemStyle Width="70px" />
                            <HeaderStyle Width="70px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Shrnk.% <span style='color:gray;font-size:8px;line-height: 14px;'>(Shrnk. Val.)</span>">
                            <ItemTemplate>
                                <table class="InnerTableShrn">
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="txtShrnkg"  onchange="CalculateQuantity(this, 2);ShowFormulaeForProcess(this)" onkeydown="return false;" CssClass="txtWaste" MaxLength="5" Text='<%# Convert.ToString(Eval("Shrinkage")) == "0" ? "" : Convert.ToString(Eval("Shrinkage")) %>' runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblShrnkgValue" ForeColor="Gray" runat="server" Text=""></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                            <ItemStyle Width="50px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Wstg.% <br><span style='color:gray;font-size:8px;line-height: 14px;'>(Wstg. Val.)</span>">
                            <ItemTemplate>
                                <table class="InnerTableShrn">
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="txtWastage" onchange="CalculateQuantity(this, 2);ShowFormulaeForProcess(this)" onkeydown="return false;" CssClass="txtWaste" MaxLength="5" Text='<%# Convert.ToString(Eval("Wastage")) == "0" ? "" : Convert.ToString(Eval("Wastage")) %>' runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblWastageValue" ForeColor="Gray" runat="server" Text=""></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                            <ItemStyle Width="55px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Balance In House <br> (Allocated from Stock)">
                            <ItemTemplate>
                                <asp:Label ID="lblbalanceinhouseqty" runat="server" Text='<%# Convert.ToString(Eval("BalanceQty")) == "0" ? "" : Convert.ToString(Eval("BalanceQty"))%>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="70px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Total Greige To Send">
                            <ItemTemplate>
                                <div class="AccessToltip">
                                    <asp:Label ID="lblAccessTotalQtySend" Text="" runat="server"></asp:Label>
                                    <asp:Label ID="lblProcessTooltip" Text="" runat="server"></asp:Label>
                                </div>
                            </ItemTemplate>
                            <ItemStyle Width="70px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Total Greige in house">
                            <ItemTemplate>
                                <asp:Label ID="lblAccessPriorQty" Text='<%# Convert.ToString(Eval("TotalPassQty")) == "0" ? "" : Convert.ToString(Eval("TotalPassQty")) %>' runat="server"></asp:Label>
                                <asp:HiddenField ID="hdnTotalPassQty" Value='<%# Eval("TotalPassQty")%>' runat="server" />
                                <asp:Label ID="lblQtyunitpcs" runat="server"></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="70px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Total Greige Send">
                            <ItemTemplate>
                                <asp:Label ID="lblAccessSendQty" Text='<%# Convert.ToString(Eval("SendQty")) == "0" ? "" : Convert.ToString(Eval("SendQty")) %>' runat="server"></asp:Label>
                                <asp:HiddenField ID="hdnSendQty" Value='<%# Eval("SendQty")%>' runat="server" />
                            </ItemTemplate>
                            <ItemStyle Width="70px" />
                        </asp:TemplateField>
                      <%--  <asp:TemplateField Visible="false">
                            <HeaderTemplate>
                                <span>Quote 1
                                    <br />
                                    (Rate & Time)<br>
                                    Supplier Name<br>
                                    Lead Time </span>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblQouteRate_1" runat="server"></asp:Label><br />
                                <asp:Label ID="lblQouteSupplierName_1" runat="server"></asp:Label><br />
                                <asp:Label ID="lblQouteLeadDays_1" runat="server"></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="130px" />
                        </asp:TemplateField>
                        <asp:TemplateField Visible="false">
                            <HeaderTemplate>
                                <span>Quote 2
                                    <br />
                                    (Rate & Time)<br>
                                    Supplier Name<br>
                                    Lead Time </span>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblQouteRate_2" runat="server"></asp:Label>
                                <asp:Label ID="lblQouteTime_2" runat="server"></asp:Label><br />
                                <asp:Label ID="lblQouteSupplierName_2" runat="server"></asp:Label><br />
                                <asp:Label ID="lblQouteLeadDays_2" runat="server"></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="130px" />
                        </asp:TemplateField>
                        <asp:TemplateField Visible="false">
                            <HeaderTemplate>
                                <span>Quote 3
                                    <br />
                                    (Rate & Time)<br>
                                    Supplier Name<br>
                                    Lead Time </span>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblQouteRate_3" runat="server"></asp:Label>
                                <asp:Label ID="lblQouteTime_3" runat="server"></asp:Label><br />
                                <asp:Label ID="lblQouteSupplierName_3" runat="server"></asp:Label><br />
                                <asp:Label ID="lblQouteLeadDays_3" runat="server"></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="130px" />
                        </asp:TemplateField>--%>
                        <asp:TemplateField HeaderText="">
                            <HeaderTemplate>
                                <table width="100%" cellpadding="0" cellspacing="0" class="PoDetailsinner" style="height: 100%;">
                                    <tr>
                                        <th style="min-width: 54px; max-width: 54px;">
                                            PO Number
                                        </th>
                                        <th style="min-width: 89px; max-width: 89px;">
                                            PO Supplier Name
                                        </th>
                                        <th style="min-width: 42px; max-width: 42px;">
                                            Rcvd. Qty.
                                        </th>
                                        <th style="min-width: 34px; max-width: 34px;">
                                            Revise PO
                                        </th>
                                    </tr>
                                </table>
                            </HeaderTemplate>
                            <ItemTemplate>
                            </ItemTemplate>
                            <ItemStyle Width="300px" VerticalAlign="Top" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText=" Qty. To Raise PO">
                            <ItemTemplate>
                                <table border="0" cellpadding="0" cellspacing="0" style="width: 100%;">
                                    <tr>
                                        <td style="width: 50px;" class="border_right_0">
                                            <asp:Label ID="lblPendingQtyToOrder" runat="server"></asp:Label>
                                            <asp:HiddenField ID="hdnPendingQtyToOrder" Value="0" runat="server" />
                                        </td>
                                        <td style="width: 12px;" class="border_right_0">
                                            <a id="lnkProductionpopup" title="View All Supplier" runat="server" style="font-size: 8px;">
                                                <img src="../../App_Themes/ikandi/images/zoom_icon1.gif" style="cursor: pointer; position: relative; top: -2px;" />
                                            </a>
                                        </td>
                                        <td style="min-width: 40px;" class="border_right_0">
                                            <asp:Button ID="btnrapo" Style="display: none;" runat="server" Text="R.PO" />
                                            <div class="btnrpo tooltip" style="display: none;" runat="server" id="divraise">
                                                R.PO</div>
                                        </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                            <ItemStyle Width="100px" />
                        </asp:TemplateField>
                    </Columns>
                    <EmptyDataTemplate>
                        <table class="grdgsmcom" cellspacing="0" rules="all" border="0" style="border-width: 0px; width: 100%; border-collapse: collapse;">
                            <tbody>
                                <tr class="ths" align="center" style="font-family: Arial;">
                                    <th align="center" style="border-left: 1px solid #999;" scope="col">
                                        Accessory Quality (Size)<br>
                                        Color/Print &nbsp;&nbsp;&nbsp;&nbsp; (Unit)
                                    </th>
                                    <th scope="col">
                                       <table border="0" cellpadding="0" cellspacing="0" style="width: 100%; height: 100%; margin: 0 auto;">
                                    <tr>
                                        <th class="border_right_0" style="border: 0px !important;text-align: left;">
                                            Style No.
                                        </th>
                                        <th class="border_right_0" style="border: 0px !important;text-align: right;">(Serial No.)</th>
                                    </tr>
                                </table>
                                    </th>
                                    <th scope="col">
                                        Accessory Qty.<br />
                                        <span style='color: gray; font-size: 8px'>Contact Qty<span class="StarVerticalCenter">*</span>Avg </span>
                                    </th>
                                    <th scope="col">
                                        Shrnk.%
                                        <br />
                                        <span style='color: gray; font-size: 8px'>(Shrnk. Val.)</span>
                                    </th>
                                    <th scope="col">
                                        Wstg.%<br />
                                        <span style='color: gray; font-size: 8px'>(Wstg. Val.)</span>
                                    </th>
                                    <th scope="col">
                                        Balance In House
                                        <br />
                                        (Allocated from Stock)
                                    </th>
                                    <th scope="col">
                                        Total Greige To Send
                                    </th>
                                    <th scope="col">
                                        Total Greige in house
                                    </th>
                                    <th scope="col">
                                        Total Greige Send
                                    </th>
                                    <%--<th scope="col">
                                        <span>Quote 1
                                            <br />
                                            (Rate &amp; Time)<br>
                                            Supplier Name<br>
                                            Lead Time </span>
                                    </th>
                                    <th scope="col">
                                        <span>Quotes 2
                                            <br />
                                            (Rate &amp; Time)<br>
                                            Supplier Name<br>
                                            Lead Time </span>
                                    </th>
                                    <th scope="col">
                                        <span>Quotes 3
                                            <br />
                                            (Rate &amp; Time)<br>
                                            Supplier Name<br>
                                            Lead Time </span>
                                    </th>--%>
                                    <th scope="col">
                                        <table width="100%" cellpadding="0" cellspacing="0" class="PoDetailsinner" style="height: 100%;">
                                            <tbody>
                                                <tr>
                                                    <th style="min-width: 54px; max-width: 54px;">
                                                        PO Number
                                                    </th>
                                                    <th style="min-width: 89px; max-width: 89px;">
                                                        PO Supplier Name
                                                    </th>
                                                    <th style="min-width: 42px; max-width: 42px;">
                                                        Rcvd. Qty.
                                                    </th>
                                                    <th style="min-width: 34px; max-width: 34px;">
                                                        Revise PO
                                                    </th>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </th>
                                    <th style="border-right: 0px;" scope="col">
                                        Qty. To Raise PO
                                    </th>
                                </tr>
                                <tr>
                                    <td colspan="15" style="border-left: 1px solid #999; border-bottom: 0px; border-right: 0px; text-align: center">
                                        <img src="../../images/sorry.png" />
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </EmptyDataTemplate>
                </asp:GridView>
              
                <asp:GridView ID="grdFinish" CssClass="grdgsmcom" Style="display: none;" runat="server" AutoGenerateColumns="False" EmptyDataText="No Record Found!" Width="100%" HeaderStyle-Font-Names="Arial" HeaderStyle-HorizontalAlign="Center" BorderWidth="0" rules="all" HeaderStyle-CssClass="ths" OnRowDataBound="grdFinish_RowDataBound">
                    <SelectedRowStyle BackColor="#A1DCF2" />
                    <Columns>
                        <asp:TemplateField HeaderText="Accessory Quality (Size)<br> Color/Print <br> Unit">
                            <ItemStyle HorizontalAlign="Center" CssClass="txtLeftPaddingL" Width="170px" />
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Label ID="lblAccessoryQuality" ForeColor="blue" Text='<%# Eval("AccessoryName")%>' runat="server"></asp:Label>
                                <asp:Label ID="lblSize" Text='<%# Eval("Size")%>' ForeColor="gray" runat="server"></asp:Label>
                                <br />
                                <asp:Label ID="lblcolorprint" Height="15px" Font-Bold="true" ForeColor="Black" Text='<%# Eval("Color_Print")%>' runat="server"></asp:Label>
                                <br />
                                <asp:Label ID="lblUnit" Text='<%# Eval("GarmentUnitName")%>' Font-Bold="true" ForeColor="gray" runat="server"></asp:Label>
                                <asp:HiddenField ID="hdnAccessoryMasterId" Value='<%# Eval("AccessoryMasterId")%>' runat="server" />
                                <asp:HiddenField ID="hdnSize" Value='<%# Eval("Size")%>' runat="server" />
                                <asp:HiddenField ID="hdnColorPrint" Value='<%# Eval("Color_Print")%>' runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                 <table border="0" cellpadding="0" cellspacing="0" style="width: 100%; height: 100%; margin: 0 auto;">
                                    <tr>
                                        <th class="border_right_0" style="border: 0px !important;text-align: left;">
                                            Style No.
                                        </th>
                                        <th class="border_right_0" style="border: 0px !important;text-align: right;">(Serial No.)</th>
                                    </tr>
                                </table>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:GridView ID="grdFiniStyle" CssClass="grdgsmcom grdStyleg" Width="98%" AutoGenerateColumns="false" BorderWidth="0" ShowFooter="false" OnRowDataBound="grdStyle_RowDataBound" ShowHeader="false" runat="server" Style="margin: 0 auto">
                                    <Columns>
                                        <asp:TemplateField ItemStyle-Width="85px">
                                            <ItemTemplate>
                                                <asp:Label ID="lblStyle" runat="server" Text='<%# Eval("StyleNumber")%>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle CssClass="border_right_0 txtLeft" />
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-Width="75px">
                                            <ItemTemplate>
                                                <asp:Label ID="lblSerialNo" runat="server" Text='<%# Eval("SerialNumber")%>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle CssClass="border_right_0 txtRight" />
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </ItemTemplate>
                            <ItemStyle Width="150px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Accessory Qty.</br> <span style='color:gray;font-size:8px;line-height: 14px;'>Contract Qty<span class='StarVerticalCenter'>*</span>Avg </span>">
                            <ItemTemplate>
                                <asp:Label ID="lblFinAccessoryQty" runat="server" Text='<%# Convert.ToString(Eval("AccessoryQty")) == "0" ? "" : Convert.ToString(Eval("AccessoryQty")) %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="70px" />
                            <HeaderStyle Width="70px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Wstg. % <br><span style='color:gray;font-size:8px;line-height: 14px;'>(Wstg. Val.)</span>">
                            <ItemTemplate>
                                <table class="InnerTableShrn">
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="txtWastage" onkeypress="return isDecimalNumber(event)" onchange="CalculateQuantity(this, 3);ShowFormulaeForFinish(this)" CssClass="numeric-field-with-decimal-places txtWaste" MaxLength="5" Text='<%# Convert.ToString(Eval("Wastage")) == "0" ? "" : Convert.ToString(Eval("Wastage")) %>' runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblWastageValue" ForeColor="Gray" runat="server" Text=""></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                            <ItemStyle Width="50px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Balance In House <br> (Allocated from Stock)">
                            <ItemTemplate>
                                <asp:Label ID="lblbalanceinhouseqty" runat="server" Text='<%# Convert.ToString(Eval("BalanceQty")) == "0" ? "" : Convert.ToString(Eval("BalanceQty"))%>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="70px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Qty. To Order">
                            <ItemTemplate>
                                <div class="AccessToltip">
                                    <asp:Label ID="lblQuantityToOrder" runat="server" Text=""></asp:Label>
                                    <asp:Label ID="lblTooltip" runat="server" Text=""></asp:Label>
                                </div>
                                <asp:HiddenField ID="hdnQuantityToOrder" Value="0" runat="server" />
                                <asp:HiddenField ID="hdnTotalQtyRecieved" Value='<%# Eval("TotalQtyRecieved") %>' runat="server" />
                                <asp:HiddenField ID="hdnAccessoryQty" Value='<%# Eval("AccessoryQty") %>' runat="server" />
                                <asp:HiddenField ID="hdnTotalPassQty" Value='<%# Eval("TotalPassQty")%>' runat="server" />
                            </ItemTemplate>
                            <ItemStyle Width="60px" />
                        </asp:TemplateField>
               <%--         <asp:TemplateField Visible="false">
                            <HeaderTemplate>
                                <span>Quote 1
                                    <br />
                                    (Rate & Time)<br>
                                    Supplier Name<br>
                                    Lead Time </span>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblQouteRate_1" runat="server"></asp:Label><br />
                                <asp:Label ID="lblQouteSupplierName_1" runat="server"></asp:Label><br />
                                <asp:Label ID="lblQouteLeadDays_1" runat="server"></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="125px" />
                        </asp:TemplateField>
                        <asp:TemplateField Visible="false">
                            <HeaderTemplate>
                                <span>Quote 2
                                    <br />
                                    (Rate & Time)<br>
                                    Supplier Name<br>
                                    Lead Time </span>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblQouteRate_2" runat="server"></asp:Label>
                                <asp:Label ID="lblQouteTime_2" runat="server"></asp:Label><br />
                                <asp:Label ID="lblQouteSupplierName_2" runat="server"></asp:Label><br />
                                <asp:Label ID="lblQouteLeadDays_2" runat="server"></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="125px" />
                        </asp:TemplateField>
                        <asp:TemplateField Visible="false">
                            <HeaderTemplate>
                                <span>Quote 3
                                    <br />
                                    (Rate & Time)<br>
                                    Supplier Name<br>
                                    Lead Time </span>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblQouteRate_3" runat="server"></asp:Label>
                                <asp:Label ID="lblQouteTime_3" runat="server"></asp:Label><br />
                                <asp:Label ID="lblQouteSupplierName_3" runat="server"></asp:Label><br />
                                <asp:Label ID="lblQouteLeadDays_3" runat="server"></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="125px" />
                        </asp:TemplateField>--%>
                        <asp:TemplateField HeaderText="">
                            <HeaderTemplate>
                                <table width="100%" cellpadding="0" cellspacing="0" class="PoDetailsinner" style="height: 100%;">
                                    <tr>
                                        <th style="min-width: 54px; max-width: 54px;">
                                            PO Number
                                        </th>
                                        <th style="min-width: 90px; max-width: 87px;">
                                            PO Supplier Name
                                        </th>
                                        <th style="min-width: 41px; max-width: 41px;">
                                            Rcvd. Qty.
                                        </th>
                                        <th style="min-width: 34px; max-width: 34px;">
                                            Revise PO
                                        </th>
                                    </tr>
                                </table>
                            </HeaderTemplate>
                            <ItemTemplate>
                            </ItemTemplate>
                            <ItemStyle Width="300px" VerticalAlign="Top" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Qty. To Raise PO">
                            <ItemTemplate>
                                <table border="0" cellpadding="0" cellspacing="0" style="width: 100%;">
                                    <tr>
                                        <td style="width: 60px;" class="border_right_0">
                                            <asp:Label ID="lblPendingQtyToOrder" runat="server"></asp:Label>
                                            <asp:HiddenField ID="hdnPendingQtyToOrder" Value="0" runat="server" />
                                        </td>
                                        <td style="width: 12px;" class="border_right_0">
                                            <a id="lnkProductionpopup" title="View All Supplier" runat="server" style="font-size: 8px;">
                                                <img src="../../App_Themes/ikandi/images/zoom_icon1.gif" style="cursor: pointer; position: relative; top: -2px;" />
                                            </a>
                                        </td>
                                        <td style="min-width: 40px;" class="border_right_0">
                                            <asp:Button ID="btnrapo" Style="display: none;" runat="server" Text="R.PO" />
                                            <div class="btnrpo tooltip" style="display: none;" runat="server" id="divraise">
                                                R.PO</div>
                                        </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                            <ItemStyle Width="110px" />
                        </asp:TemplateField>
                    </Columns>
                    <EmptyDataTemplate>
                        <table class="grdgsmcom" cellspacing="0" rules="all" border="0" style="border-width: 0px; width: 100%; border-collapse: collapse; display;">
                            <tbody>
                                <tr class="ths" align="center" style="font-family: Arial;">
                                    <th align="center" style="border-left: 1px solid #999;" scope="col">
                                        Accessory Quality (Size)<br>
                                        Color/Print &nbsp;&nbsp;&nbsp;&nbsp; (Unit)
                                    </th>
                                    <th scope="col">
                                      <table border="0" cellpadding="0" cellspacing="0" style="width: 100%; height: 100%; margin: 0 auto;">
                                    <tr>
                                        <th class="border_right_0" style="border: 0px !important;text-align: left;">
                                            Style No.
                                        </th>
                                        <th class="border_right_0" style="border: 0px !important;text-align: right;">(Serial No.)</th>
                                    </tr>
                                </table>
                                    </th>
                                    <th scope="col">
                                        Accessory Qty.<br />
                                        <span style='color: gray; font-size: 8px'>Contact Qty<span class='StarVerticalCenter'>*</span>Avg </span>
                                    </th>
                                    <th scope="col">
                                        Wstg.%
                                        <br></br>
                                        <span style='color: gray; font-size: 8px'>(Wstg. Val.)</span>
                                    </th>
                                    <th scope="col">
                                        Balance In House
                                        <br />
                                        (Allocated from Stock)
                                    </th>
                                    <th scope="col">
                                        Qty. To Order
                                    </th>
                            <%--        <th scope="col">
                                        <span>Quote 1
                                            <br />
                                            (Rate &amp; Time)<br>
                                            Supplier Name<br>
                                            Lead Time </span>
                                    </th>
                                    <th scope="col">
                                        <span>Quotes 2
                                            <br />
                                            (Rate &amp; Time)<br>
                                            Supplier Name<br>
                                            Lead Time </span>
                                    </th>
                                    <th scope="col">
                                        <span>Quotes 3
                                            <br />
                                            (Rate &amp; Time)<br>
                                            Supplier Name<br>
                                            Lead Time </span>
                                    </th>--%>
                                    <th scope="col">
                                        <table width="100%" cellpadding="0" cellspacing="0" class="PoDetailsinner" style="height: 100%;">
                                            <tbody>
                                                <tr>
                                                    <th style="min-width: 54px; max-width: 54px">
                                                        PO Number
                                                    </th>
                                                    <th style="min-width: 90px; max-width: 87px;">
                                                        Supplier
                                                    </th>
                                                    <th style="min-width: 41px; max-width: 41px;">
                                                        Rcvd. Qty.
                                                    </th>
                                                    <th style="min-width: 34px; max-width: 34px;">
                                                        Revise PO
                                                    </th>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </th>
                                    <th scope="col" style="border-right: 0px;">
                                        Qty. To Raise PO
                                    </th>
                                </tr>
                                <tr>
                                    <td colspan="15" style="border-left: 1px solid #999; border-bottom: 0px; border-right: 0px; text-align: center">
                                        <img src="../../images/sorry.png" />
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </EmptyDataTemplate>
                </asp:GridView>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
