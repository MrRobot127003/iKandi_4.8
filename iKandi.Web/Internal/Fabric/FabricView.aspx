<%@ Page Title="" Language="C#" MasterPageFile="~/layout/Secure.Master" AutoEventWireup="true"
    CodeBehind="FabricView.aspx.cs" Inherits="iKandi.Web.Internal.Fabric.FabricView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_head" EnableViewState="true" runat="server">
    <style type="text/css">
        body {
            background: #fff none repeat scroll 0 0;
            font-family: arial !important;
        }         
        table {
            font-family: arial;
            border-color: gray;
            border-collapse: collapse;
            width: 100%;
        }

        .topsupplier td {
            text-align: center;
            border: 1px solid #999;
            font-weight: 500;
        }

        table td {
            font-size: 10px;
            text-align: center;
            border-color: #e2dddd99;
            text-transform: capitalize;
            color: #000;
            padding: 0px 0px;
            font-family: arial;
            height: 20px;
        }

        .AccessToltip {
            position: relative;
            display: inline-block;
            z-index: 10;
        }

            .AccessToltip .TooltipTxt {
                visibility: hidden;
                width: 200px;
                background-color: #767676;
                color: #fff;
                text-align: left;
                border-radius: 6px;
                padding: 5px 5px;
                position: absolute;
                z-index: 1;
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

        #ctl00_cph_main_content_updatepnl {
            width: 1313px;
        }

        .textLeft {
            text-align: left !important;
            padding-left: 2px;
        }

        .per {
            color: blue;
        }

        .gray {
            color: gray;
        }

        h2

        .row-fir th {
            font-weight: bold;
            font-size: 11px;
        }

        table td table td {
            border-color: #e2dddd99;
            padding-left: 2px;
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

        .ths {
            background: #3b5998;
            font-weight: normal;
            color: #fff;
            font-family: arial;
            font-size: 10px;
            padding: 5px 0px;
            text-align: center;
            text-transform: capitalize;
        }


        .backcolorstages {
            background: #fdfd96e0;
        }

        input[type="text"] {
            border-color: White;
            width: 34% !important;
            border: 1px solid #e2dddd99 !important;
            border-radius: 2px;
            height: 13px !important;
            color: Blue !important;
            font-size: 10px !important;
        }

        .float_left {
            float: left;
            padding-left: 3px;
        }

        .float_right {
            float: right;
            padding-ight: 3px;
        }

        .color_black {
            color: Black;
        }

        .navbar {
            overflow: hidden;
            background-color: #333;
            position: fixed; /* Set the navbar to fixed position */
            top: 0; /* Position the navbar at the top of the page */
            width: 308px; /* Full width */
        }

            /* Links inside the navbar */
            .navbar a {
                width: 73px;
                text-decoration: none;
                border: 1px solid #fff;
                display: inline-table;
                height: 30px;
                line-height: 30px;
                color: #fff;
            }

        .borderDy {
            border: 0px !important;
        }
        /* Change background on mouse-over */
        .navbar a:hover {
            background: #ddd;
            color: black;
        }

        .abc.tab {
            overflow: hidden;
            border: 0px solid #ccc;
            background-color: #fff;
            font-family: Arial !important;
            float: left;
            width: 908px;
            position: sticky;
            top: 23px;
            padding-top: 5px;
            z-index: 7;
        }

        /* Style the buttons inside the tab */
        .tab a {
            background-color: inherit;
            border: none;
            outline: none;
            cursor: pointer;
            /* padding: 14px 16px; */
            transition: 0.3s;
            font-size: 13px;
            border: 1px solid #999;
            width: 72px;
            display: inline-block;
            text-align: center;
            border-top-left-radius: 3px;
            border-top-right-radius: 3px;
            margin-right: 2px;
            font-family: arial !important;
            padding: 4px 2px;
            border-bottom: 0px;
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
            color: #f8f8f8;
        }

        .navbar tab {
            border: 1px solid #fff;
        }

        .maincontentcontainer {
            width: 1100px;
            margin: 20px 0 0px;
        }

        .headerSticky {
            width: 1313px !important;
        }

        td.GriegeStageRe {
            border-left: 1px solid #999;
        }

        #data tbody > tr:last-child > td {
            border-bottom: 0 !important;
        }

        .btnrpo {
            cursor: pointer;
            background-color: blue;
            color: #f5f5f5 !important;
            width: 30px;
            font-size: 9px;
            border-radius: 20px;
            padding: 2px 2px;
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
            float: left;
            margin: 2px 2px;
        }

        p:nth-last-child(2) {
            background: red;
        }

        td.process:last-child {
            height: 24px;
        }

        .HideRaisebtn {
            display: none !important;
        }

        .divspplier {
            position: fixed;
            top: 44%;
            left: 43%;
            /* width: 30em; */
            min-height: 200px;
            margin-top: -9em;
            margin-left: -15em;
            border: 1px solid #ccc;
            background-color: #f3f3f3;
            z-index: 2;
        }

        .topsupplier {
            border-collapse: collapse !important;
        }

            .topsupplier th {
                background: #dddfe4;
                color: #575759;
                text-align: center;
                border: 1px solid #999;
                font-size: 10px;
                padding: 3px 0px;
            }

            .topsupplier td {
                text-align: center;
                border: 1px solid #999;
                font-weight: bold;
            }

            .topsupplier th:first-child {
                border-left: 0px;
            }

            .topsupplier th:last-child {
                border-right: 0px;
            }

            .topsupplier td:first-child {
                border-left: 0px;
            }

            .topsupplier td:last-child {
                border-right: 0px;
            }

        table.greigegrdbor td table.Griegetable td:first-child {
            text-align: left;
        }

        table.greigegrdbor td table.Griegetable td:last-child {
            text-align: right;
        }

        td[colspan="17"] {
            border-left: 1px solid #999 !important;
            padding: 0px !important
        }

        td[colspan="14"] {
            border-left: 1px solid #999 !important;
            padding: 0px !important
        }

        td[colspan="15"] {
            border-left: 1px solid #999 !important;
            padding: 0px !important
        }

        .grdgsmcom td[colspan="4"] {
            padding: 0px !important;
        }

            .grdgsmcom td[colspan="4"] th {
                border-top: 0px;
            }
    </style>
    <style>
        body {
            font-family: Arial, Helvetica, sans-serif;
        }

        /* The Modal (background) */
        .modal {
            display: none; /* Hidden by default */
            position: fixed; /* Stay in place */
            z-index: 1; /* Sit on top */
            padding-top: 100px; /* Location of the box */
            left: 0;
            top: 0;
            width: 100%; /* Full width */
            height: 100%; /* Full height */
            overflow: auto; /* Enable scroll if needed */
            background-color: rgb(0,0,0); /* Fallback color */
            background-color: rgba(0,0,0,0.4); /* Black w/ opacity */
        }

        /* Modal Content */
        .modal-content {
            position: relative;
            background-color: #fefefe;
            margin: auto;
            padding: 0;
            border: 1px solid #888;
            width: 80%;
            box-shadow: 0 4px 8px 0 rgba(0,0,0,0.2),0 6px 20px 0 rgba(0,0,0,0.19);
            -webkit-animation-name: animatetop;
            -webkit-animation-duration: 0.4s;
            animation-name: animatetop;
            animation-duration: 0.4s
        }

        /* Add Animation */
        @-webkit-keyframes animatetop {
            from {
                top: -300px;
                opacity: 0
            }

            to {
                top: 0;
                opacity: 1
            }
        }

        @keyframes animatetop {
            from {
                top: -300px;
                opacity: 0
            }

            to {
                top: 0;
                opacity: 1
            }
        }

        /* The Close Button */
        .close {
            color: white;
            float: right;
            font-size: 28px;
            font-weight: bold;
        }

            .close:hover,
            .close:focus {
                color: #000;
                text-decoration: none;
                cursor: pointer;
            }

        .modal-header {
            padding: 2px 16px;
            background-color: #5cb85c;
            color: white;
        }

        .modal-body {
            padding: 2px 16px;
        }

        .modal-footer {
            padding: 2px 16px;
            background-color: #5cb85c;
            color: white;
        }

        .hide_me {
            display: none;
        }

        .show_me {
            display: block !important;
        }

        #data {
            width: 100%;
        }

        .toptd {
            padding: 5px 0px;
            font-size: 13px !important;
        }

        .textboxAslabel {
            border: none;
            background-color: #FFF;
            border-color: #FFF;
        }

        .greigegrdbor {
            border: 1px solid #999;
        }

        .HeaderClass td:first-child {
            padding-left: 0px !important;
        }

        table.greigegrdbor td:first-child {
            border-left-color: #999 !important;
        }

        table.greigegrdbor td:last-child {
            border-right-color: #999 !important;
        }

        table.greigegrdbor tr:nth-last-child(1) > td {
            border-bottom-color: #999 !important;
        }

        table.greigegrdbor table td:first-child {
            border-left-color: #e2dddd99 !important;
        }

        table.greigegrdbor table td:last-child {
            border-right-color: #e2dddd99 !important;
        }

        table.greigegrdbor table tr:nth-last-child(1) > td {
            border-bottom-color: #e2dddd99 !important;
        }

        #secure_footer {
            display: none;
        }

        #sb-wrapper-inner {
            border: 5px solid #999;
            border-radius: 5px;
            background: #fff;
        }
        /*  #sb-wrapper{top:100px !important;
                  left:193px !important;
                  }*/

        .widthAction {
            min-width: 35px !important
        }

        .widthPending {
            min-width: 80px !important
        }

        .greigegrd tr td:nth-child(2) > table td {
            text-align: center;
        }

        .lbls {
            input [type='text']:not(.userListBox)

        {
            background: transparent !important;
            border: none !important;
            outline: none !important;
            padding: 0 0 0 0 !important;
        }
        /* Clearable text inputs */
        .clearable {
            position: relative;
            display: inline-block;
        }

            .clearable input[type=text] {
                padding-right: 24px;
                width: 100%;
                box-sizing: border-box;
            }

        .clearable__clear {
            display: none;
            position: absolute;
            right: 0;
            top: 0;
            padding: 0 8px;
            font-style: normal;
            font-size: 1.2em;
            user-select: none;
            cursor: pointer;
        }

        .clearable input::-ms-clear { /* Remove IE default X */
            display: none;
        }

        .grdDyedtable td {
            border: 1px solid #999;
        }

        .PrintRowCount td {
            padding: 0px 0px !important;
        }

        .greigegrdbor.nobordertd {
            border: 0px;
        }

            .greigegrdbor.nobordertd .HeaderClass td {
                border: 1px solid #999;
            }

            .greigegrdbor.nobordertd td {
                border: 0px;
            }

        ::placeholder {
            padding-left: 5px;
        }

        .leftagligh {
            text-align: left;
        }

        .rightagligh {
            text-align: left;
        }

        #spinnL {
            position: fixed;
            left: 0px;
            top: 0px;
            width: 100%;
            height: 100%;
            z-index: 9999;
            background: url(../../App_Themes/ikandi/images1/loading128.gif) 50% 50% no-repeat #EBF1FA;
        }

        .selectedCell {
            background-color: #9caac1 !important;
        }

        .unselectedCell {
            background-color: white !important;
        }

        .numbers {
            font-family: Tahoma;
            color: red;
            /* unvisited link */
            a: link

        {
            color: green;
        }

        /* visited link */
        a:visited {
            color: gray;
        }

        /* mouse over link */
        a:hover {
            color: red;
        }

        /* selected link */
        a:active {
            color: yellow;
        }

        a {
            text-decoration: none;
        }

        .fade-in {
            animation: fadeIn ease 10s;
            -webkit-animation: fadeIn ease 10s;
            -moz-animation: fadeIn ease 10s;
            -o-animation: fadeIn ease 10s;
            -ms-animation: fadeIn ease 10s;
        }

        @keyframes fadeIn {
            0% {
                opacity: 0.5;
            }

            100% {
                opacity: 0.5;
            }
        }

        @-moz-keyframes fadeIn {
            0% {
                opacity: 0.5;
            }

            100% {
                opacity: 0.5;
            }
        }

        @-webkit-keyframes fadeIn {
            0% {
                opacity: 0.5;
            }

            100% {
                opacity: 0.5;
            }
        }

        @-o-keyframes fadeIn {
            0% {
                opacity: 0.5;
            }

            100% {
                opacity: 0.5;
            }
        }

        @-ms-keyframes fadeIn {
            0% {
                opacity: 0.5;
            }

            100% {
                opacity: 0.5;
            }

            #spinner {
                position: fixed;
                left: 0px;
                top: 0px;
                width: 100%;
                height: 100%;
                z-index: 9999;
                background: url(../../App_Themes/ikandi/images1/loading128.gif) 50% 50% no-repeat;
            }

            .clsDivHdr {
                background: #dddfe4;
                font-weight: 500;
                color: #575759;
                font-family: arila;
                font-size: 11px;
                padding: 5px 0px;
                text-align: center;
                text-transform: capitalize;
                width: 544px;
            }

                .RowBackColor {
                    background-color: #f1eaf0 !important;
                }

            .class1 {
                background-color: red;
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
    <%-- <script type="text/javascript" src="../../js/jquery-ui.min.js"></script>
        <link href="../../CommonJquery/ToolTip_plugin/css/tooltipster.bundle.min.css" rel="stylesheet"
        type="text/css" />
    <script src="../../CommonJquery/ToolTip_plugin/js/tooltipster.bundle.min.js" type="text/javascript"></script>--%>
    <script type="text/javascript">

        function PermissionAlertMsg() {
            debugger;
            alert("You don't have permission");
        }

        $(function () {
            //            $('.tooltip').tooltipster();
            //            $('HTML').click(function (e) {
            //                lnkProductionpopup = e.target.parentNode.id.split("_")[6];
            //                if (lnkProductionpopup != 'lnkProductionpopup') {
            //                    $(".divspplier").fadeOut(1000);
            //                }
            //            });

            $(".clearable").each(function () {

                var $inp = $(this).find("input:text"),
                    $cle = $(this).find(".clearable__clear");

                $inp.on("input", function () {
                    $cle.toggle(!!this.value);
                });

                $cle.on("touchstart click", function (e) {
                    e.preventDefault();
                    $inp.val("").trigger("input");
                });

            });
            //            $(".loadingimage").show();
            //            $('body').css('display', 'none');
            //            $('body').fadeIn(500);

            $(".datesfileds").keydown(function (e) {
                var key = e.keyCode || e.charCode;
                e.preventDefault();
                e.stopPropagation();

            });

            $("input[type='text']").each(function () {

                if ($(this).val() == "0") {
                    $(this).val("");
                }

            })
            //Add code by bharat on 5-Oct-20
            //            $('.greigegrdbor tr').click(function () {
            //                $('.greigegrdbor tr').removeClass('RowBackColor');
            //                $(this).toggleClass('RowBackColor');
            //            })
            // End
            //            $('.greigegrdbor tr').click(function () {

            //                $(this).find('td').removeClass('RowBackColor');
            //                $(this).find('td').addClass('RowBackColor');
            //            })

        });
        var serviceUrl = '<%= ResolveUrl("~/Webservices/iKandiService.asmx/") %>';
        var proxy = new ServiceProxy(serviceUrl);
        var urls = "../../Webservices/iKandiService.asmx";
        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            if (charCode != 46 && charCode > 31
                && (charCode < 48 || charCode > 57))
                return false;

            return true;
        }
        function validateFloatKeyPress(el, evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode;
            var number = el.value.split('.');
            if (charCode != 46 && charCode > 31 && (charCode < 48 || charCode > 57)) {
                return false;
            }
            //just one dot
            if (number.length > 1 && charCode == 46) {
                return false;
            }
            //get the carat position
            var caratPos = getSelectionStart(el);
            var dotPos = el.value.indexOf(".");
            if (caratPos > dotPos && dotPos > -1 && (number[1].length > 1)) {
                return false;
            }
            return true;
        }

        //thanks: http://javascript.nwbox.com/cursor_position/
        function getSelectionStart(o) {
            if (o.createTextRange) {
                var r = document.selection.createRange().duplicate()
                r.moveEnd('character', o.value.length)
                if (r.text == '') return o.value.length
                return o.value.lastIndexOf(r.text)
            } else return o.selectionStart
        }
       $(document).ready(function () {

            //CalculateOnLoad();
            //  CalculateOnLoadDayed(2);  
            //   CalculateOnLoadPrint(2);
            // CalculateOnLoadFinish();
            //$(".tab1").click(function () {
            //    $(this).addClass('activeback').siblings().removeClass('activeback');
            //});

            Fabtype = $("#ctl00_cph_main_content_hdnFabtype").val();
            if (Fabtype != "") {

                // ShowHideSuppliergrd('<%=Session["CallBackTab"] %>');
            }


           $("#ctl00_cph_main_content_grdEmbellishment tr,#ctl00_cph_main_content_grdvalueadditionRFD tr,#ctl00_cph_main_content_grdgreigerasiepo tr,#ctl00_cph_main_content_grdfinishing tr,#ctl00_cph_main_content_grdgayed tr ,#ctl00_cph_main_content_grdEmbroidery tr").click(function () {
                $('#ctl00_cph_main_content_grdvalueadditionRFD  > tbody > tr').not(':first').find('td').css("background-color", "#FFFFFF");
                $('#ctl00_cph_main_content_grdgreigerasiepo  > tbody > tr').not(':first').find('td').css("background-color", "#FFFFFF");
                $('#ctl00_cph_main_content_grdEmbellishment  > tbody > tr').not(':first').find('td').css("background-color", "#FFFFFF");
                $('#ctl00_cph_main_content_grdfinishing  > tbody > tr').not(':first').find('td').css("background-color", "#FFFFFF");
                $('#ctl00_cph_main_content_grdgayed  > tbody > tr').not(':first').find('td').css("background-color", "#FFFFFF");
                $('#ctl00_cph_main_content_grdEmbroidery  > tbody > tr').not(':first').find('td').css("background-color", "#FFFFFF");
                if ($(this).hasClass("HeaderClass") == false) {
                    $(this).find('td').css("background-color", "");
                }
            })
        });
        window.onload = function () {
            //            SaveGreigeDetails();
        };
        function SaveGreigeDetails() {

            $(".classfabsave").each(function () {
                var id = $(this).attr('id');
                //                alert($(this).val());
                var Idsn = id.split("_")[5];


                FabQualityID = $("#<%= grdgreigerasiepo.ClientID %>_" + Idsn[0] + "_hdnfabricQuality").val();
                Greige_Sh = $("#<%= grdgreigerasiepo.ClientID %>_" + Idsn[0] + "_txtGreige_Sh").val();
                QtyToOrder = $("#<%= grdgreigerasiepo.ClientID %>_" + Idsn[0] + "_lblfabricorderavg").val();
                PendingQtyToOrder = $("#<%= grdgreigerasiepo.ClientID %>_" + Idsn[0] + "_lblFabQtyRemaning").val();
                UserID = '<%=this.Userid %>';

                if (Greige_Sh == "") {
                    Greige_Sh = 0;
                }
                if (QtyToOrder == "") {
                    QtyToOrder = 0;
                }
                if (PendingQtyToOrder == "") {
                    PendingQtyToOrder = 0;
                }
                $.ajax({
                    type: 'POST',
                    contentType: "application/json; charset=utf-8",
                    url: urls + "/updatePendingGreigeOrders",
                    data: "{ Flag:'" + 'GRIEGE' + "', FlagOption:'" + 'UPDATE' + "', GreigedShrinkage:'" + Greige_Sh + "',QtyToOrder:'" + QtyToOrder + "',UserID:'" + UserID + "', PendingQtyToOrder:'" + PendingQtyToOrder + "', FabricQualityID:'" + FabQualityID + "'}",
                    dataType: 'JSON',
                    success: OnSuccessCall,
                    error: OnErrorCall
                });

                function OnSuccessCall(response) {
                    alert("Saved Sucessfully");
                }

                function OnErrorCall(response) {
                    alert(response.status + " " + response.statusText);
                }
            });
        }
        function UpdateGrige(elem, fabQtyID) {
            //
            var Idsn = elem.id.split("_");
            Selectedval = elem.value;

            if (Selectedval == "") {
                Selectedval = 0;
            }
            if (confirm("Are you sure want to update ?")) {
                $.ajax({
                    type: 'POST',
                    contentType: "application/json; charset=utf-8",
                    url: urls + "/updateGreigeValue",
                    data: "{ Flag:'" + 'GRIEGE' + "', FlagOption:'" + 'UPDATEGRIGE' + "', GreigedShrinkage:'" + Selectedval + "',FabricQualityID:'" + fabQtyID + "',Isresidualshrnkpplyongerige:'" + fabQtyID + "'}",
                    dataType: 'JSON',
                    success: OnSuccessCall,
                    error: OnErrorCall
                });
                return false;

            }
            else {
                elem.value = elem.value;
            }
            function OnSuccessCall(response) {
                //
                CalculateOnLoad();
                alert("Saved Sucessfully");
            }

            function OnErrorCall(response) {
                alert(response.status + " " + response.statusText);
            }
        }
        function UpdateResidualShrinkage(elem, fabQtyID) {
            //
            var Idsn = elem.id.split("_");
            Selectedval = elem.value;

            if (Selectedval == "") {
                Selectedval = 0;
            }
            if (confirm("Are you sure want to update ?")) {
                $.ajax({
                    type: 'POST',
                    contentType: "application/json; charset=utf-8",
                    url: urls + "/updateGreigeValue",
                    data: "{ Flag:'" + 'FINISHING' + "', FlagOption:'" + 'UPDATEFINISH' + "', GreigedShrinkage:'" + Selectedval + "',FabricQualityID:'" + fabQtyID + "',Isresidualshrnkpplyongerige:'" + 0 + "'}",
                    dataType: 'JSON',
                    success: OnSuccessCall,
                    error: OnErrorCall
                });
                return false;

            }
            else {
                elem.value = elem.value;
            }
            function OnSuccessCall(response) {
                CalculateOnLoadFinish();
                alert("Saved Sucessfully");
            }

            function OnErrorCall(response) {
                alert(response.status + " " + response.statusText);
            }

        }

        function ShowHideSuppliergrd(type) {
            debugger;
            //            SelectedTab = '<%=this.SelectedTab %>';
            //            var s = "";
            //            alert(SelectedTab);
            //$("#ctl00_cph_main_content_hdnIsMailSend").val("");
            //$("#ctl00_cph_main_content_hdnFabtype").val(type);
            //          
            //            if (SelectedTab != "") {
            //                type = SelectedTab;
            //            }
            if (type.toLowerCase() == 'GRIEGE'.toLowerCase()) {

                $("#ctl00_cph_main_content_hdnFabtype").val('GRIEGE');
                $("#ctl00_cph_main_content_btnSearch").click();
                //                $("#ctl00_cph_main_content_grdgreigerasiepo").show();
                //                $(".tab1greige").addClass('activeback');
                //                $(".tab1Dayed").removeClass('activeback');
                //                $(".tab1Print").removeClass('activeback');
                //                $(".tab1finished").removeClass('activeback');
                //                $("#ctl00_cph_main_content_grdfinishing").hide();
                //                $("#ctl00_cph_main_content_grdgayed").hide();
                //                $("#ctl00_cph_main_content_grdprint").hide();
            }
            else if (type.toLowerCase() == 'DYED'.toLowerCase()) {

                $("#ctl00_cph_main_content_hdnFabtype").val('DYED');
                $("#ctl00_cph_main_content_btnSearch").click();
                //                $("#ctl00_cph_main_content_grdgayed").show();
                //                $(".tab1Dayed").addClass('activeback');

                //                $(".tab1greige").removeClass('activeback');
                //                $(".tab1Print").removeClass('activeback');
                //                $(".tab1finished").removeClass('activeback');

                //                $("#ctl00_cph_main_content_grdfinishing").hide();
                //                $("#ctl00_cph_main_content_grdgreigerasiepo").hide();
                //                $("#ctl00_cph_main_content_grdprint").hide();
                //added Code by Bharat On 13-may-20

            }
            else if (type.toLowerCase() == 'PRINT'.toLowerCase()) {

                $("#ctl00_cph_main_content_hdnFabtype").val('PRINT');
                $("#ctl00_cph_main_content_btnSearch").click();
                //                $(".tab1Print").addClass('activeback');
                //                $(".tab1Dayed").removeClass('activeback');
                //                $(".tab1greige").removeClass('activeback');
                //                $(".tab1finished").removeClass('activeback');

                //                $("#ctl00_cph_main_content_grdprint").show();
                //                $("#ctl00_cph_main_content_grdgayed").hide();
                //                $("#ctl00_cph_main_content_grdfinishing").hide();
                //                $("#ctl00_cph_main_content_grdgreigerasiepo").hide();

            }
            else if (type.toLowerCase() == 'RFD'.toLowerCase()) {

                $("#ctl00_cph_main_content_hdnFabtype").val('RFD');
                $("#ctl00_cph_main_content_btnSearch").click();
                //RFDBorderBottom();

            }
            else if (type.toLowerCase() == 'Embellishment'.toLowerCase()) {

                $("#ctl00_cph_main_content_hdnFabtype").val('Embellishment');
                $("#ctl00_cph_main_content_btnSearch").click();

            }
            else if (type.toLowerCase() == 'Embroidery'.toLowerCase()) {

                $("#ctl00_cph_main_content_hdnFabtype").val('Embroidery');
                $("#ctl00_cph_main_content_btnSearch").click();

            }
            else if (type.toLowerCase() == 'FINISHING'.toLowerCase() || type.toLowerCase() == 'FINISHED'.toLowerCase()) {

                $("#ctl00_cph_main_content_hdnFabtype").val('FINISHING');
                $("#ctl00_cph_main_content_btnSearch").click();
                // CalculateOnLoadFinish();

                //                $("#ctl00_cph_main_content_grdfinishing").show();
                //                $(".tab1finished").addClass('activeback');
                //                $(".tab1Dayed").removeClass('activeback');
                //                $(".tab1Print").removeClass('activeback');
                //                $(".tab1greige").removeClass('activeback');
                //                $("#ctl00_cph_main_content_grdgayed").hide();
                //                $("#ctl00_cph_main_content_grdprint").hide();
                //                $("#ctl00_cph_main_content_grdgreigerasiepo").hide();

            }
            else {

                $("#ctl00_cph_main_content_hdnFabtype").val('GRIEGE');
                $("#ctl00_cph_main_content_btnSearch").click();
                //                $("#ctl00_cph_main_content_grdgreigerasiepo").show();
                //                $(".tab1greige").addClass('activeback');
                //                $(".tab1Dayed").removeClass('activeback');
                //                $(".tab1Print").removeClass('activeback');
                //                $(".tab1finished").removeClass('activeback');
                //                $("#ctl00_cph_main_content_grdfinishing").hide();
                //                $("#ctl00_cph_main_content_grdgayed").hide();
                //                $("#ctl00_cph_main_content_grdprint").hide();
            }


        }
        function ShowpurchasedSupplierForm(id, FabQualityID, SupplierMasterID, MasterPoID, colorprintdetail, gerige, residual, cutwastage, Stage1, stage2, stage3, stage4) {
            //    alert("test");
            debugger;
            HideSupplierDiv();
            var Idsn = id.split("_");
            var urls = window.location.href.replace('#', '');
            Fabtype = $("#ctl00_cph_main_content_hdnFabtype").val();
            residual = 0;
            gerige = 0;
            var Idsn = id.split("_");
            residual = 0;
            var currentstage = 0;
            var previousstage = 0;
            var isStyleSpecific = 0;
            var styleid = 0;
            var Vals = "";

            if (Fabtype == 'GRIEGE') {

                gerige = document.getElementById('ctl00_cph_main_content_grdgreigerasiepo_' + Idsn[5] + '_hdnmaxgrige').value;
                residual = 0

            }
            else if (Fabtype == 'FINISHING') {

                gerige = 0;
                residual = document.getElementById('ctl00_cph_main_content_grdfinishing_' + Idsn[5] + '_hdnResidualShrinkage').value.replace(',', '');
            }
            else if (Fabtype == 'PRINT') {
                currentstage = document.getElementById('ctl00_cph_main_content_grdprint_' + Idsn[5] + '_hdnCurrentstage').value.replace(',', '');
                previousstage = document.getElementById('ctl00_cph_main_content_grdprint_' + Idsn[5] + '_hdnperiviousstgae').value.replace(',', '');
                Vals = document.getElementById('ctl00_cph_main_content_grdprint_' + Idsn[5] + '_hdnIsStyleSpecific').value.replace(',', '');
                if (Vals == 'True') {
                    isStyleSpecific = 1;
                }
                styleid = document.getElementById('ctl00_cph_main_content_grdprint_' + Idsn[5] + '_hdnStyleID').value.replace(',', '');
            }
            else if (Fabtype == 'DYED') {
                currentstage = document.getElementById('ctl00_cph_main_content_grdgayed_' + Idsn[5] + '_hdnCurrentstage').value.replace(',', '');
                previousstage = document.getElementById('ctl00_cph_main_content_grdgayed_' + Idsn[5] + '_hdnperiviousstgae').value.replace(',', '');
                Vals = document.getElementById('ctl00_cph_main_content_grdgayed_' + Idsn[5] + '_hdnIsStyleSpecific').value.replace(',', '');
                if (Vals == 'True') {
                    isStyleSpecific = 1;
                }
                styleid = document.getElementById('ctl00_cph_main_content_grdgayed_' + Idsn[5] + '_hdnStyleID').value.replace(',', '');
            }
            else if (Fabtype == 'RFD') {
                currentstage = document.getElementById('ctl00_cph_main_content_grdvalueadditionRFD_' + Idsn[5] + '_hdnCurrentstage').value.replace(',', '');
                previousstage = document.getElementById('ctl00_cph_main_content_grdvalueadditionRFD_' + Idsn[5] + '_hdnperiviousstgae').value.replace(',', '');
                Vals = document.getElementById('ctl00_cph_main_content_grdvalueadditionRFD_' + Idsn[5] + '_hdnIsStyleSpecific').value.replace(',', '');
                if (Vals == 'True') {
                    isStyleSpecific = 1;
                }
                styleid = document.getElementById('ctl00_cph_main_content_grdvalueadditionRFD_' + Idsn[5] + '_hdnStyleID').value.replace(',', '');
            }
            else if (Fabtype == 'Embellishment') {
                currentstage = document.getElementById('ctl00_cph_main_content_grdEmbellishment_' + Idsn[5] + '_hdnCurrentstage').value.replace(',', '');
                previousstage = document.getElementById('ctl00_cph_main_content_grdEmbellishment_' + Idsn[5] + '_hdnperiviousstgae').value.replace(',', '');
                Vals = document.getElementById('ctl00_cph_main_content_grdEmbellishment_' + Idsn[5] + '_hdnIsStyleSpecific').value.replace(',', '');
                if (Vals == 'True') {
                    isStyleSpecific = 1;
                }
                styleid = document.getElementById('ctl00_cph_main_content_grdEmbellishment_' + Idsn[5] + '_hdnStyleID').value.replace(',', '');
            }
            else if (Fabtype == 'Embroidery') {
                currentstage = document.getElementById('ctl00_cph_main_content_grdEmbroidery_' + Idsn[5] + '_hdnCurrentstage').value.replace(',', '');
                previousstage = document.getElementById('ctl00_cph_main_content_grdEmbroidery_' + Idsn[5] + '_hdnperiviousstgae').value.replace(',', '');
                Vals = document.getElementById('ctl00_cph_main_content_grdEmbroidery_' + Idsn[5] + '_hdnIsStyleSpecific').value.replace(',', '');
                if (Vals == 'True') {
                    isStyleSpecific = 1;
                }
                styleid = document.getElementById('ctl00_cph_main_content_grdEmbroidery_' + Idsn[5] + '_hdnStyleID').value.replace(',', '');
            }
            var sURL = 'FabricPurChasedForm.aspx?FabricQualityID=' + FabQualityID + "&Fabtype=" + Fabtype + "&Potype=" + 'RAISE' + "&ParentPageUrlWithQuerystring=" + urls + "&MasterPoID=" + MasterPoID + "&colorprintdetail=" + colorprintdetail + "&gerige=" + gerige + "&residual=" + residual + "&cutwastage=" + cutwastage + "&currentstage=" + currentstage + "&previousstage=" + previousstage + "&isStyleSpecific=" + isStyleSpecific + "&styleid=" + styleid + "&stage1=" + Stage1 + "&stage2=" + stage2 + "&stage3=" + stage3 + "&stage4=" + stage4;
            // window.open(sURL);     
            Shadowbox.init({ animate: true, animateFade: true, modal: true });

            Shadowbox.open({ content: sURL, type: "iframe", player: "iframe", title: "", height: 900, width: 1500, modal: true, animate: true, animateFade: true, options: { onClose: SBClose } });
            $('#sb-wrapper').addClass("PurchaseOrder");
            return false;

        }
        function ShowpurchasedSupplierFormReraise(FabQualityID, SupplierMasterID, MasterPoID, elem, gerige, residual, cutwastage, id, Stage1, stage2, stage3, stage4) {

            HideSupplierDiv();
            var Idsn = id.split("_");
            var urls = window.location.href.replace('#', '');
            var currentstage = 0;
            var previousstage = 0;
            var isStyleSpecific = 0;
            var styleid = 0;
            var Vals = "";
            Fabtype = $("#ctl00_cph_main_content_hdnFabtype").val();
            //            alert(Fabtype);
            if (Fabtype == 'GRIEGEDYED') {
                Fabtype = 'DYED';
            }
            else if (Fabtype == 'PRINT') {
                currentstage = document.getElementById('ctl00_cph_main_content_grdprint_' + Idsn[5] + '_hdnCurrentstage').value.replace(',', '');
                previousstage = document.getElementById('ctl00_cph_main_content_grdprint_' + Idsn[5] + '_hdnperiviousstgae').value.replace(',', '');
                Vals = document.getElementById('ctl00_cph_main_content_grdprint_' + Idsn[5] + '_hdnIsStyleSpecific').value.replace(',', '');
                if (Vals == 'True') {
                    isStyleSpecific = 1;
                }
                styleid = document.getElementById('ctl00_cph_main_content_grdprint_' + Idsn[5] + '_hdnStyleID').value.replace(',', '');
            }
            else if (Fabtype == 'DYED') {
                currentstage = document.getElementById('ctl00_cph_main_content_grdgayed_' + Idsn[5] + '_hdnCurrentstage').value.replace(',', '');
                previousstage = document.getElementById('ctl00_cph_main_content_grdgayed_' + Idsn[5] + '_hdnperiviousstgae').value.replace(',', '');
                Vals = document.getElementById('ctl00_cph_main_content_grdgayed_' + Idsn[5] + '_hdnIsStyleSpecific').value.replace(',', '');
                if (Vals == 'True') {
                    isStyleSpecific = 1;
                }
                styleid = document.getElementById('ctl00_cph_main_content_grdgayed_' + Idsn[5] + '_hdnStyleID').value.replace(',', '');
            }
            else if (Fabtype == 'RFD') {
                currentstage = document.getElementById('ctl00_cph_main_content_grdvalueadditionRFD_' + Idsn[5] + '_hdnCurrentstage').value.replace(',', '');
                previousstage = document.getElementById('ctl00_cph_main_content_grdvalueadditionRFD_' + Idsn[5] + '_hdnperiviousstgae').value.replace(',', '');
                Vals = document.getElementById('ctl00_cph_main_content_grdvalueadditionRFD_' + Idsn[5] + '_hdnIsStyleSpecific').value.replace(',', '');
                if (Vals == 'True') {
                    isStyleSpecific = 1;
                }
                styleid = document.getElementById('ctl00_cph_main_content_grdvalueadditionRFD_' + Idsn[5] + '_hdnStyleID').value.replace(',', '');

            }
            else if (Fabtype == 'Embellishment') {
                currentstage = document.getElementById('ctl00_cph_main_content_grdEmbellishment_' + Idsn[5] + '_hdnCurrentstage').value.replace(',', '');
                previousstage = document.getElementById('ctl00_cph_main_content_grdEmbellishment_' + Idsn[5] + '_hdnperiviousstgae').value.replace(',', '');
                Vals = document.getElementById('ctl00_cph_main_content_grdEmbellishment_' + Idsn[5] + '_hdnIsStyleSpecific').value.replace(',', '');
                if (Vals == 'True') {
                    isStyleSpecific = 1;
                }
                styleid = document.getElementById('ctl00_cph_main_content_grdEmbellishment_' + Idsn[5] + '_hdnStyleID').value.replace(',', '');
            }
            else if (Fabtype == 'Embroidery') {
                currentstage = document.getElementById('ctl00_cph_main_content_grdEmbroidery_' + Idsn[5] + '_hdnCurrentstage').value.replace(',', '');
                previousstage = document.getElementById('ctl00_cph_main_content_grdEmbroidery_' + Idsn[5] + '_hdnperiviousstgae').value.replace(',', '');
                Vals = document.getElementById('ctl00_cph_main_content_grdEmbroidery_' + Idsn[5] + '_hdnIsStyleSpecific').value.replace(',', '');
                if (Vals == 'True') {
                    isStyleSpecific = 1;
                }
                styleid = document.getElementById('ctl00_cph_main_content_grdEmbroidery_' + Idsn[5] + '_hdnStyleID').value.replace(',', '');
            }
            //<a href="../../FabricPurChasedFormPrint.aspx">../../FabricPurChasedFormPrint.aspx</a>
            // var sURL = '../../FabricPurChasedFormPrint.aspx?FabricQualityID=' + FabQualityID + "&Fabtype=" + Fabtype + "&Potype=" + 'RERAISE' + "&ParentPageUrlWithQuerystring=" + urls + "&MasterPoID=" + MasterPoID + "&colorprintdetail=" + elem + "&gerige=" + gerige + "&residual=" + residual + "&cutwastage=" + cutwastage + "&currentstage=" + currentstage + "&previousstage=" + previousstage + "&isStyleSpecific=" + isStyleSpecific + "&styleid=" + styleid + "&stage1=" + Stage1 + "&stage2=" + stage2 + "&stage3=" + stage3 + "&stage4=" + stage4;
            var sURL = 'FabricPurChasedForm.aspx?FabricQualityID=' + FabQualityID + "&Fabtype=" + Fabtype + "&Potype=" + 'RERAISE' + "&ParentPageUrlWithQuerystring=" + urls + "&MasterPoID=" + MasterPoID + "&colorprintdetail=" + elem + "&gerige=" + gerige + "&residual=" + residual + "&cutwastage=" + cutwastage + "&currentstage=" + currentstage + "&previousstage=" + previousstage + "&isStyleSpecific=" + isStyleSpecific + "&styleid=" + styleid + "&stage1=" + Stage1 + "&stage2=" + stage2 + "&stage3=" + stage3 + "&stage4=" + stage4;
            //window.open(sURL);     
            Shadowbox.init({ animate: true, animateFade: true, modal: true });
            Shadowbox.open({ content: sURL, type: "iframe", player: "iframe", title: "", height: 700, width: 1500, modal: true, animate: true, animateFade: true, options: { onClose: SBClose } });
            $('#sb-wrapper').addClass("PurchaseOrder");
            return false;
        }
        function SBClose() { }

        function CallThisPage(Po_number, SupplierNasterID, IsMailSend, hdnSessionQ) {
            debugger;
            //alert(Po_number + "" + SupplierNasterID + " " + IsMailSend)
            //var userName = "Po_number + "," + SupplierNasterID + "," + IsMailSend;

            var Podetails = Po_number + "," + SupplierNasterID + "," + IsMailSend;
            var url = new URL(window.location.href);
            url.searchParams.set('Po_number', Po_number);
            url.searchParams.set('SupplierNasterID', SupplierNasterID);
            url.searchParams.set('IsMailSend', IsMailSend);
            url.searchParams.set('TradeName', getUrlParameter("FabricQuality", hdnSessionQ));

            $("#ctl00_cph_main_content_hdnponumber").val(Po_number);
            $("#ctl00_cph_main_content_hdnmasterpoid").val(SupplierNasterID);
            $("#ctl00_cph_main_content_hdnIsMailSend").val(IsMailSend);
            //$("#ctl00_cph_main_content_btnSearch").click();
            window.location.href = url.href;
            //this.window.location.reload();
            //alert("ss");
            //            Shadowbox.close();
            //ShowHideSuppliergrd($("#ctl00_cph_main_content_hdnFabtype").val());

        }
        function getUrlParameter(sParam, sPageURL) {
            var sURLVariables = sPageURL.split('&'), sParameterName, i;
            for (i = 0; i < sURLVariables.length; i++) {
                sParameterName = sURLVariables[i].split('=');
                if (sParameterName[0] === sParam) {
                    return typeof sParameterName[1] === undefined ? true : decodeURIComponent(sParameterName[1]);
                }
            }
            return false;
        };

        function ShowAllSupplier2(FabQualityID, SupplierMasterID, MasterPoID, elem, gerige, residual, cutwastage, id, Stage1, stage2, stage3, stage4, fab) {
            debugger;
            // HideSupplierDiv();
            var Idsn = id.split("_");
            var urls = window.location.href.replace('#', '');
            var currentstage = 0;
            var previousstage = 0;
            var isStyleSpecific = 0;
            var styleid = 0;
            var Vals = "";
            var fabqty = "";
            var fabricdetails = "";
            var gsm = "";
            var cc = "";
            var width = "";

            Fabtype = $("#ctl00_cph_main_content_hdnFabtype").val();
            //            alert(Fabtype);
            if (Fabtype == 'GRIEGEDYED') {
                Fabtype = 'DYED';
            }
            if (Fabtype == 'GRIEGE') {

                currentstage = 0;
                previousstage = 0;
                Vals = 0;

                fabqty = document.getElementById('ctl00_cph_main_content_grdgreigerasiepo_' + Idsn[5] + '_lblFabricQuality').innerText.replace(',', '');
                fabricdetails = "";
                gsm = document.getElementById('ctl00_cph_main_content_grdgreigerasiepo_' + Idsn[5] + '_lblgsm').innerText.replace(',', '');
                cc = document.getElementById('ctl00_cph_main_content_grdgreigerasiepo_' + Idsn[5] + '_lblcountconstraction').innerText.replace(',', '');
                width = document.getElementById('ctl00_cph_main_content_grdgreigerasiepo_' + Idsn[5] + '_lblwidth').innerText.replace(',', '');

            }
            else if (Fabtype == 'PRINT') {
                currentstage = document.getElementById('ctl00_cph_main_content_grdprint_' + Idsn[5] + '_hdnCurrentstage').value.replace(',', '');
                previousstage = document.getElementById('ctl00_cph_main_content_grdprint_' + Idsn[5] + '_hdnperiviousstgae').value.replace(',', '');
                Vals = document.getElementById('ctl00_cph_main_content_grdprint_' + Idsn[5] + '_hdnIsStyleSpecific').value.replace(',', '');

                fabqty = document.getElementById('ctl00_cph_main_content_grdprint_' + Idsn[5] + '_lblFabricQuality').innerText.replace(',', '');
                fabricdetails = document.getElementById('ctl00_cph_main_content_grdprint_' + Idsn[5] + '_lblfabriccolor').innerText.replace(',', '');
                gsm = document.getElementById('ctl00_cph_main_content_grdprint_' + Idsn[5] + '_lblgsm').innerText.replace(',', '');
                cc = document.getElementById('ctl00_cph_main_content_grdprint_' + Idsn[5] + '_lblcountconstraction').innerText.replace(',', '');
                width = document.getElementById('ctl00_cph_main_content_grdprint_' + Idsn[5] + '_lblwidth').innerText.replace(',', '');

                if (Vals == 'True') {
                    isStyleSpecific = 1;
                }
                styleid = document.getElementById('ctl00_cph_main_content_grdprint_' + Idsn[5] + '_hdnStyleID').value.replace(',', '');
            }
            else if (Fabtype == 'DYED') {
                currentstage = document.getElementById('ctl00_cph_main_content_grdgayed_' + Idsn[5] + '_hdnCurrentstage').value.replace(',', '');
                previousstage = document.getElementById('ctl00_cph_main_content_grdgayed_' + Idsn[5] + '_hdnperiviousstgae').value.replace(',', '');
                Vals = document.getElementById('ctl00_cph_main_content_grdgayed_' + Idsn[5] + '_hdnIsStyleSpecific').value.replace(',', '');

                fabqty = document.getElementById('ctl00_cph_main_content_grdgayed_' + Idsn[5] + '_lblFabricQuality').innerText.replace(',', '');
                fabricdetails = document.getElementById('ctl00_cph_main_content_grdgayed_' + Idsn[5] + '_lblfabriccolor').innerText.replace(',', '');
                gsm = document.getElementById('ctl00_cph_main_content_grdgayed_' + Idsn[5] + '_lblgsm').innerText.replace(',', '');
                cc = document.getElementById('ctl00_cph_main_content_grdgayed_' + Idsn[5] + '_lblcountconstraction').innerText.replace(',', '');
                width = document.getElementById('ctl00_cph_main_content_grdgayed_' + Idsn[5] + '_lblwidth').innerText.replace(',', '');


                if (Vals == 'True') {
                    isStyleSpecific = 1;
                }
                styleid = document.getElementById('ctl00_cph_main_content_grdgayed_' + Idsn[5] + '_hdnStyleID').value.replace(',', '');
            }
            else if (Fabtype == 'RFD') {
                currentstage = document.getElementById('ctl00_cph_main_content_grdvalueadditionRFD_' + Idsn[5] + '_hdnCurrentstage').value.replace(',', '');
                previousstage = document.getElementById('ctl00_cph_main_content_grdvalueadditionRFD_' + Idsn[5] + '_hdnperiviousstgae').value.replace(',', '');
                Vals = document.getElementById('ctl00_cph_main_content_grdvalueadditionRFD_' + Idsn[5] + '_hdnIsStyleSpecific').value.replace(',', '');


                fabqty = document.getElementById('ctl00_cph_main_content_grdvalueadditionRFD_' + Idsn[5] + '_lblFabricQuality').innerText.replace(',', '');
                fabricdetails = document.getElementById('ctl00_cph_main_content_grdvalueadditionRFD_' + Idsn[5] + '_lblfabriccolor').innerText.replace(',', '');
                gsm = document.getElementById('ctl00_cph_main_content_grdvalueadditionRFD_' + Idsn[5] + '_lblgsm').innerText.replace(',', '');
                cc = document.getElementById('ctl00_cph_main_content_grdvalueadditionRFD_' + Idsn[5] + '_lblcountconstraction').innerText.replace(',', '');
                width = document.getElementById('ctl00_cph_main_content_grdvalueadditionRFD_' + Idsn[5] + '_lblwidth').innerText.replace(',', '');


                if (Vals == 'True') {
                    isStyleSpecific = 1;
                }
                styleid = document.getElementById('ctl00_cph_main_content_grdvalueadditionRFD_' + Idsn[5] + '_hdnStyleID').value.replace(',', '');

            }
            else if (Fabtype == 'Embellishment') {
                currentstage = document.getElementById('ctl00_cph_main_content_grdEmbellishment_' + Idsn[5] + '_hdnCurrentstage').value.replace(',', '');
                previousstage = document.getElementById('ctl00_cph_main_content_grdEmbellishment_' + Idsn[5] + '_hdnperiviousstgae').value.replace(',', '');
                Vals = document.getElementById('ctl00_cph_main_content_grdEmbellishment_' + Idsn[5] + '_hdnIsStyleSpecific').value.replace(',', '');
                if (Vals == 'True') {
                    isStyleSpecific = 1;
                }
                styleid = document.getElementById('ctl00_cph_main_content_grdEmbellishment_' + Idsn[5] + '_hdnStyleID').value.replace(',', '');

                fabqty = document.getElementById('ctl00_cph_main_content_grdEmbellishment_' + Idsn[5] + '_lblFabricQuality').innerText.replace(',', '');
                fabricdetails = document.getElementById('ctl00_cph_main_content_grdEmbellishment_' + Idsn[5] + '_lblfabriccolor').innerText.replace(',', '');
                gsm = document.getElementById('ctl00_cph_main_content_grdEmbellishment_' + Idsn[5] + '_lblgsm').innerText.replace(',', '');
                cc = document.getElementById('ctl00_cph_main_content_grdEmbellishment_' + Idsn[5] + '_lblcountconstraction').innerText.replace(',', '');
                width = document.getElementById('ctl00_cph_main_content_grdEmbellishment_' + Idsn[5] + '_lblwidth').innerText.replace(',', '');


            }
            else if (Fabtype == 'Embroidery') {
                currentstage = document.getElementById('ctl00_cph_main_content_grdEmbroidery_' + Idsn[5] + '_hdnCurrentstage').value.replace(',', '');
                previousstage = document.getElementById('ctl00_cph_main_content_grdEmbroidery_' + Idsn[5] + '_hdnperiviousstgae').value.replace(',', '');
                Vals = document.getElementById('ctl00_cph_main_content_grdEmbroidery_' + Idsn[5] + '_hdnIsStyleSpecific').value.replace(',', '');
                if (Vals == 'True') {
                    isStyleSpecific = 1;
                }
                styleid = document.getElementById('ctl00_cph_main_content_grdEmbroidery_' + Idsn[5] + '_hdnStyleID').value.replace(',', '');

                fabqty = document.getElementById('ctl00_cph_main_content_grdEmbroidery_' + Idsn[5] + '_lblFabricQuality').innerText.replace(',', '');
                fabricdetails = document.getElementById('ctl00_cph_main_content_grdEmbroidery_' + Idsn[5] + '_lblfabriccolor').innerText.replace(',', '');
                gsm = document.getElementById('ctl00_cph_main_content_grdEmbroidery_' + Idsn[5] + '_lblgsm').innerText.replace(',', '');
                cc = document.getElementById('ctl00_cph_main_content_grdEmbroidery_' + Idsn[5] + '_lblcountconstraction').innerText.replace(',', '');
                width = document.getElementById('ctl00_cph_main_content_grdEmbroidery_' + Idsn[5] + '_lblwidth').innerText.replace(',', '');

            }
            var sURL = 'FabricSupplierDetails.aspx?FabricQualityID=' + FabQualityID + "&Fabtype=" + Fabtype + "&Potype=" + 'RERAISE' + "&ParentPageUrlWithQuerystring=" + urls + "&MasterPoID=" + MasterPoID + "&colorprintdetail=" + elem + "&gerige=" + gerige + "&residual=" + residual + "&cutwastage=" + cutwastage + "&currentstage=" + currentstage + "&previousstage=" + previousstage + "&isStyleSpecific=" + isStyleSpecific + "&styleid=" + styleid + "&stage1=" + Stage1 + "&stage2=" + stage2 + "&stage3=" + stage3 + "&stage4=" + stage4 + "&fabqty=" + fabqty + "&fabricdetails=" + fabricdetails + "&gsm=" + gsm + "&cc=" + cc + "&width=" + width;
            //window.open(sURL);     
            Shadowbox.init({ animate: true, animateFade: true, modal: true });
            Shadowbox.open({ content: sURL, type: "iframe", player: "iframe", title: "", height: 220, width: 700, modal: true, animate: true, animateFade: true, options: { onClose: SBClose } });
            //$('#sb-wrapper').addClass("PurchaseOrder");
            $('#sb-wrapper').removeClass("PurchaseOrder");
            return false;
        }
        function ShowAllSupplier(innerhtml) {

            if (innerhtml == "empty") {
                var url = '../../Internal/Accessory/AccessorySupplierDetails.aspx?AccessoryMasterId=' + 0 + '&Size=' + 0 + '&ColorPrint=' + 'Fabric' + '&AccessoryType=' + '0';
                Shadowbox.init({ animate: true, animateFade: true, modal: true });
                Shadowbox.open({ content: url, type: "iframe", player: "iframe", title: "", height: 220, width: 700, modal: true, animate: true, animateFade: true, options: { onClose: SBClose } });
                //                $("#sb-wrapper-inner").removeClass("BorderPopup");
                //                $("#sb-wrapper-inner").addClass("BorderPopupDetails");

                return false;


            }
            else {
                $(".divspplier").html(innerhtml);
                $(".divspplier").show(innerhtml);
                $('#sb-wrapper').removeClass("PurchaseOrder");
            }
        }
        function HideSupplierDiv() {
            $(".divspplier").hide();
        }
        function Alert(msg) {
            alert(msg);
        }
        function showhideresidualshrinke(elem) {
            debugger;
            var Idsn = "";
            if (elem.id == "") {
                Idsn = elem.innerHTML.split("_");
            }
            else {
                Idsn = elem.id.split("_");
            }


            Selectedval = 0;
            var Isresidualshrnkpplyongerige = 0;
            Isresidualshrnkpplyongerige = $("#<%= grdgreigerasiepo.ClientID %>_" + Idsn[5] + "_txtResidualSh").val();
            var checkboxapply = $("#<%= grdgreigerasiepo.ClientID %>_" + Idsn[5] + "_chkApplyResShrinkage").is(":checked");
            var xbox = confirm("Are you sure want to update ?")
            var fabQtyID = $("#<%= grdgreigerasiepo.ClientID %>_" + Idsn[5] + "_hdnfabricQuality").val();

            if (xbox == false) {

                if (checkboxapply == false) {
                    $("#<%= grdgreigerasiepo.ClientID %>_" + Idsn[5] + "_txtResidualSh").addClass('show_me');
                    $("#<%= grdgreigerasiepo.ClientID %>_" + Idsn[5] + "_txtResidualSh").removeClass('hide_me');
                    $("#<%= grdgreigerasiepo.ClientID %>_" + Idsn[5] + "_chkApplyResShrinkage").attr('checked', 'checked');
                }
                else {
                    $("#<%= grdgreigerasiepo.ClientID %>_" + Idsn[5] + "_txtResidualSh").removeClass('show_me');
                    $("#<%= grdgreigerasiepo.ClientID %>_" + Idsn[5] + "_txtResidualSh").addClass('hide_me');
                    $("#<%= grdgreigerasiepo.ClientID %>_" + Idsn[5] + "_chkApplyResShrinkage").removeAttr('checked');
                }

            }
            else {

                if (checkboxapply == true) {

                    $("#<%= grdgreigerasiepo.ClientID %>_" + Idsn[5] + "_txtResidualSh").addClass('show_me');
                    $("#<%= grdgreigerasiepo.ClientID %>_" + Idsn[5] + "_txtResidualSh").removeClass('hide_me');
                    $("#<%= grdgreigerasiepo.ClientID %>_" + Idsn[5] + "_chkApplyResShrinkage").attr('checked', 'checked');
                }
                else {
                    Isresidualshrnkpplyongerige = 0;
                    $("#<%= grdgreigerasiepo.ClientID %>_" + Idsn[5] + "_txtResidualSh").removeClass('show_me');
                    $("#<%= grdgreigerasiepo.ClientID %>_" + Idsn[5] + "_txtResidualSh").addClass('hide_me');
                    $("#<%= grdgreigerasiepo.ClientID %>_" + Idsn[5] + "_chkApplyResShrinkage").removeAttr('checked');
                }

                $.ajax({
                    type: 'POST',
                    contentType: "application/json; charset=utf-8",
                    url: urls + "/updateGreigeValue",
                    data: "{ Flag:'" + 'GRIEGE' + "', FlagOption:'" + 'UPDATEGRIGEWITHCHECKBOX' + "', GreigedShrinkage:'" + Selectedval + "',FabricQualityID:'" + fabQtyID + "',Isresidualshrnkpplyongerige:'" + Isresidualshrnkpplyongerige + "'}",
                    dataType: 'JSON',
                    success: OnSuccessCall,
                    error: OnErrorCall
                });
            }
        }
        function OnSuccessCall(response) {
            CalculateOnLoad();
            alert("Saved Sucessfully");

        }
        function OnErrorCall(response) {
            alert(response.status + " " + response.statusText);
        }
        function OnSuccess(response, userContext, methodName) {
            //            alert(response);
        }
        function numberWithCommas(x) {
            return x.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",");
        }
        $(document).ready(function () {


        });
        function CalculateOnLoad() {
            //

            ctlid = "";
            var FabQty = 0;
            var QtyToOrder = 0;
            var GreigeShrn = 0;
            var IsChkRsk = 0;
            var ResidualShrn = 0;
            var ReceiveQty = 0;
            var GridId = "<%=grdgreigerasiepo.ClientID %>";
            var grid = document.getElementById(GridId);
            if (grid != null) {
                rowscount = grid.rows.length - 2;
                var RowIndexs = 04;
                var i;
                for (i = 1; i <= rowscount; i++) {
                    if (RowIndexs < 10) {
                        ctlid = 'ctl' + '0' + RowIndexs;
                    }
                    else {
                        ctlid = 'ctl' + RowIndexs;
                    }
                    RowIndexs = RowIndexs + 1;
                    //FabQty = document.getElementById('ctl00_cph_main_content_grdgreigerasiepo_' + ctlid + '_lblfabricorderavg2').innerText.replace(',', '');
                    FabQty = document.getElementById('ctl00_cph_main_content_grdgreigerasiepo_' + ctlid + '_lblTotalFabRequired').innerText.replace(',', '');
                    QtyToOrder = document.getElementById('ctl00_cph_main_content_grdgreigerasiepo_' + ctlid + '_lblFabQtyRemaning2').innerText.replace(',', '');
                    //                    GreigeShrn = document.getElementById('ctl00_cph_main_content_grdgreigerasiepo_' + ctlid + '_txtGreige_Sh').value.replace(',', '');
                    //                    ResidualShrn = document.getElementById('ctl00_cph_main_content_grdgreigerasiepo_' + ctlid + '_txtResidualSh').value.replace(',', '');
                    //                    var checkBox = document.getElementById('ctl00_cph_main_content_grdgreigerasiepo_' + ctlid + '_chkApplyResShrinkage');
                    ReceiveQty = document.getElementById('ctl00_cph_main_content_grdgreigerasiepo_' + ctlid + '_recqty').innerText.replace(',', '');
                    cutwastage = document.getElementById('ctl00_cph_main_content_grdgreigerasiepo_' + ctlid + '_lblcutwastgae').innerText.replace(',', '');
                    lblcolor = document.getElementById('ctl00_cph_main_content_grdgreigerasiepo_' + ctlid + '_lblcolor').innerText.replace(',', '');
                    balanceInhOuse = document.getElementById('ctl00_cph_main_content_grdgreigerasiepo_' + ctlid + '_lblbalanceinhouseqty').innerText.replace(',', '');
                    if (balanceInhOuse == '') {
                        balanceInhOuse = 0;
                    }
                    //                    if (checkBox.checked == true) {
                    //                        IsChkRsk = 1;
                    //                    }
                    //                    else {
                    //                        IsChkRsk = 0;
                    //                    }
                    // if (GreigeShrn == '') {
                    // GreigeShrn = 0;
                    //}
                    //if (ResidualShrn == '') {
                    // ResidualShrn = 0;
                    // }
                    if (FabQty == '') {
                        FabQty = 0;
                    }
                    if (ReceiveQty == '') {
                        ReceiveQty = 0;
                    }
                    if (cutwastage == '') {
                        cutwastage = 0;
                    }
                    // var FinalPendingqty = parseInt(FabQty) - parseInt(balanceInhOuse);
                    var FinalPendingqty = parseInt(FabQty);
                    // if (IsChkRsk == 1) {
                    //alert(((parseFloat(FinalPendingqty) * parseFloat(cutwastage)) / parseFloat(100)));
                    calculate = parseFloat(FinalPendingqty) + ((parseFloat(FinalPendingqty) * parseFloat(cutwastage)) / parseFloat(100));

                    //  }
                    //                    else {
                    //                        //calculate = parseFloat(FabQty) * (1 + (parseFloat(GreigeShrn) / 100) + (parseFloat(cutwastage) / 100));
                    //                        calculate = ((parseFloat(FinalPendingqty) * parseFloat(100)) / (parseFloat(100) - (parseFloat(GreigeShrn) + parseFloat(cutwastage))));
                    //                    }
                    // calculate = parseFloat(calculate) + (parseFloat(calculate) * parseFloat(cutwastage) / 100);
                    if (calculate > 0) {
                        document.getElementById('ctl00_cph_main_content_grdgreigerasiepo_' + ctlid + '_lblFabQtyRemaning2').innerText = numberWithCommas(Math.round(calculate));
                        QtytoOrder_ = Math.round(document.getElementById('ctl00_cph_main_content_grdgreigerasiepo_' + ctlid + '_lblFabQtyRemaning2').innerText.replace(',', ''));
                        pendingqty = (parseInt(Math.round(calculate)) - parseInt(balanceInhOuse) - parseInt(Math.round(ReceiveQty)));
                        var x = 0;
                        if (pendingqty == "0") {
                            x = "";
                        }
                        else {

                            x = numberWithCommas(Math.round(pendingqty));
                        }
                        document.getElementById('ctl00_cph_main_content_grdgreigerasiepo_' + ctlid + '_pendingQtyinorder').innerText = x;
                        ////                        updatePendingGreigeOrdersProxy(string flag, string FlagOption, int QtyToOrder, int PendingQtyToOrder, int FabricQualityID)
                        FabricQualityID = document.getElementById('ctl00_cph_main_content_grdgreigerasiepo_' + ctlid + '_hdnfabricQuality').value;
                        calculate = parseInt(calculate);
                        var url = "../../Webservices/iKandiService.asmx";
                        $.ajax({
                            type: "POST",
                            url: url + "/updatePendingGreigeOrdersProxy",
                            data: "{ flag:'" + 'GRIEGE' + "', FlagOption:'" + 'UPDATEPROXY' + "', PendingQtyToOrder:'" + pendingqty + "', FabricQualityID:'" + FabricQualityID + "', QtyToOrder:'" + QtytoOrder_ + "',FabricDetails:'" + '' + "' }",
                            contentType: "application/json; charset=utf-8",
                            dataType: "json",
                            success: OnSuccessCall,
                            error: OnErrorCall
                        });

                        function OnSuccessCall(response) {

                        }

                        function OnErrorCall(response) {
                        }

                    }
                }
            }
        }
        function CalculateOnLoadFinish() {


            ctlid = "";
            var FabQty = 0;
            var QtyToOrder = 0;
            var GreigeShrn = 0;
            var IsChkRsk = 0;
            var ResidualShrn = 0;
            var ReceiveQty = 0;
            var GridId = "<%=grdfinishing.ClientID %>";
            var grid = document.getElementById(GridId);
            if (grid != null) {
                rowscount = grid.rows.length - 2;
                var RowIndexs = 04;
                var i;
                for (i = 1; i <= rowscount; i++) {
                    if (RowIndexs < 10) {
                        ctlid = 'ctl' + '0' + RowIndexs;
                    }
                    else {
                        ctlid = 'ctl' + RowIndexs;
                    }
                    debugger;
                    RowIndexs = RowIndexs + 1;
                    //FabQty = document.getElementById('ctl00_cph_main_content_grdfinishing_' + ctlid + '_lblfabricorderavg2').innerText.replace(',', '');
                    FabQty = document.getElementById('ctl00_cph_main_content_grdfinishing_' + ctlid + '_lblFabQtyRemaning2').innerText.replace(',', '');
                    QtyToOrder = document.getElementById('ctl00_cph_main_content_grdfinishing_' + ctlid + '_lblFabQtyRemaning2').innerText.replace(',', '');

                    ResidualShrn = document.getElementById('ctl00_cph_main_content_grdfinishing_' + ctlid + '_txtFinishedResidualShrinkage').value.replace(',', '');
                    ReceiveQty = document.getElementById('ctl00_cph_main_content_grdfinishing_' + ctlid + '_recqty').innerText.replace(',', '');
                    Cutwastage = document.getElementById('ctl00_cph_main_content_grdfinishing_' + ctlid + '_lblcutwastgae').innerText.replace(',', '');
                    lblcolor = document.getElementById('ctl00_cph_main_content_grdfinishing_' + ctlid + '_lblcolor').innerText.replace(',', '');
                    balanceInhOuse = document.getElementById('ctl00_cph_main_content_grdfinishing_' + ctlid + '_lblbalanceinhouseqty').innerText.replace(',', '');
                    if (balanceInhOuse == '') {
                        balanceInhOuse = 0;
                    }
                    if (ResidualShrn == '') {
                        ResidualShrn = 0;
                    }
                    if (FabQty == '') {
                        FabQty = 0;
                    }
                    if (ReceiveQty == '') {
                        ReceiveQty = 0;
                    }
                    if (Cutwastage == '') {
                        Cutwastage = 0;
                    }
                    // var FinalPendingqty = parseInt(FabQty) - parseInt(balanceInhOuse);
                    var FinalPendingqty = parseInt(FabQty);
                    // calculate = ((parseFloat(FinalPendingqty) * parseFloat(100)) / (parseFloat(100) - (parseFloat(ResidualShrn) + parseFloat(Cutwastage))));
                    calculate = parseFloat(FinalPendingqty) + ((parseFloat(FinalPendingqty) * parseFloat(cutwastage)) / parseFloat(100));
                    //  alert(calculate);
                    if (calculate > 0) {
                        document.getElementById('ctl00_cph_main_content_grdfinishing_' + ctlid + '_lblFabQtyRemaning2').innerText = numberWithCommas(Math.round(calculate));
                        pendingqty = (parseInt(Math.round(calculate)) - (parseInt(ReceiveQty) + parseInt(balanceInhOuse)));
                        var x = 0;
                        if (pendingqty == "0") {
                            x = "";
                        }
                        else {

                            x = numberWithCommas(Math.round(pendingqty));
                        }
                        document.getElementById('ctl00_cph_main_content_grdfinishing_' + ctlid + '_pendingQtyinorder').innerText = x;
                        FabricQualityID = document.getElementById('ctl00_cph_main_content_grdfinishing_' + ctlid + '_hdnfabricQuality').value;
                        calculate = parseInt(Math.round(calculate));
                        pendingqty = parseInt(Math.round(pendingqty));
                        var url = "../../Webservices/iKandiService.asmx";
                        $.ajax({
                            type: "POST",
                            url: url + "/updatePendingGreigeOrdersProxy",
                            data: "{ flag:'" + 'FINISHING' + "', FlagOption:'" + 'UPDATEPROXY' + "', PendingQtyToOrder:'" + pendingqty + "', FabricQualityID:'" + FabricQualityID + "', QtyToOrder:'" + calculate + "',FabricDetails:'" + lblcolor + "' }",
                            contentType: "application/json; charset=utf-8",
                            dataType: "json",
                            success: OnSuccessCall,
                            error: OnErrorCall
                        });

                        function OnSuccessCall(response) {
                        }

                        function OnErrorCall(response) {
                        }

                    }
                }
            }
        }

        function updateresidual(elem) {
            debugger;
            var Idsn = elem.id.split("_");
            ResidualShnk = $("#<%= grdfinishing.ClientID %>_" + Idsn[5] + "_txtFinishedResidualShrinkage").val();
            var fabQtyID = $("#<%= grdfinishing.ClientID %>_" + Idsn[5] + "_hdnfabricQualityresi").val();
            var fabDetails = $("#<%= grdfinishing.ClientID %>_" + Idsn[5] + "_hdnfanricdetails").val();

            if (confirm("Are you sure want to update ?")) {
                CalculateOnLoadFinish();
                $.ajax({
                    type: 'POST',
                    contentType: "application/json; charset=utf-8",
                    url: urls + "/UpdareResidualShrinkage",
                    data: "{ Flag:'" + 'FINISHING' + "', FlagOption:'" + 'UPDATEFINISH' + "', residualshrinkage:'" + ResidualShnk + "',FabricQualityID:'" + fabQtyID + "',FabricDetails:'" + fabDetails + "'}",
                    dataType: 'JSON',
                    success: OnSuccessCall,
                    error: OnErrorCall

                });
                return false;
            }
            else {
                elem.value = elem.value;

            }

        }
        function UpdategerigeResidualshrkfordayed(elem) {
            //
            var Idsn = elem.id.split("_");
            ResidualShnk = $("#<%= grdgayed.ClientID %>_" + Idsn[5] + "_txtResidualShak").val();
            Gerrige = $("#<%= grdgayed.ClientID %>_" + Idsn[5] + "_txtGreigeshrk").val();

            var Isresidualshrnkpplyongerige = 0;
            var fabQtyID = $("#<%= grdgreigerasiepo.ClientID %>_" + Idsn[5] + "_hdnfabricQuality").val();
            if ($("#<%= grdgreigerasiepo.ClientID %>_" + Idsn[5] + "_chkApplyResShrinkage").is(":checked")) {

                $("#<%= grdgreigerasiepo.ClientID %>_" + Idsn[5] + "_txtResidualSh").addClass('show_me');
                $("#<%= grdgreigerasiepo.ClientID %>_" + Idsn[5] + "_txtResidualSh").removeClass('hide_me');
                Isresidualshrnkpplyongerige = 1;
                Selectedval = $("#<%= grdgreigerasiepo.ClientID %>_" + Idsn[5] + "_txtResidualSh").val();
            }
            else {
                Isresidualshrnkpplyongerige = 0;
                $("#<%= grdgreigerasiepo.ClientID %>_" + Idsn[5] + "_txtResidualSh").removeClass('show_me');
                $("#<%= grdgreigerasiepo.ClientID %>_" + Idsn[5] + "_txtResidualSh").addClass('hide_me');
            }

            if (confirm("Are you sure want to update ?")) {
                $.ajax({
                    type: 'POST',
                    contentType: "application/json; charset=utf-8",
                    url: urls + "/updateGreigeValue",
                    data: "{ Flag:'" + 'GRIEGE' + "', FlagOption:'" + 'UPDATEGRIGEWITHCHECKBOX' + "', GreigedShrinkage:'" + Selectedval + "',FabricQualityID:'" + fabQtyID + "',Isresidualshrnkpplyongerige:'" + Isresidualshrnkpplyongerige + "'}",
                    dataType: 'JSON',
                    success: OnSuccessCall,
                    error: OnErrorCall
                });
                return false;
            }
            else {
                elem.value = elem.value;

            }
        }
        function OnSuccessCall(response) {
            // CalculateOnLoad();
            //  CalculateOnLoadDayed(1);
            alert("Saved Sucessfully");

        }
        function OnErrorCall(response) {
            alert(response.status + " " + response.statusText);
        }
        function CalculateOnLoadDayed(Type) {


            ctlid = "";
            var FabQty = 0;
            var QtyToOrder = 0;
            var GreigeShrn = 0;
            var IsChkRsk = 0;
            var ResidualShrn = 0;
            var BalanceInHouse = 0;
            var Cutwastgae = 0;
            var ReceiveQty = 0;

            var GridId = "<%=grdgayed.ClientID %>";

            var grid = document.getElementById(GridId);
            if (grid != null) {
                rowscount = grid.rows.length - 2;
                var RowIndexs = 04;
                var i;
                for (i = 1; i <= rowscount; i++) {
                    if (RowIndexs < 10) {
                        ctlid = 'ctl' + '0' + RowIndexs;
                    }
                    else {
                        ctlid = 'ctl' + RowIndexs;
                    }
                    RowIndexs = RowIndexs + 1;
                    FabQty = document.getElementById('ctl00_cph_main_content_grdgayed_' + ctlid + '_lblfabricQty').innerText.replace(',', '');
                    BalanceInHouse = document.getElementById('ctl00_cph_main_content_grdgayed_' + ctlid + '_lblbalanceinhouseqty').innerText.replace(',', '');
                    ResidualShrn = document.getElementById('ctl00_cph_main_content_grdgayed_' + ctlid + '_txtResidualShak').value.replace(',', '');
                    GreigeShrn = document.getElementById('ctl00_cph_main_content_grdgayed_' + ctlid + '_txtGreigeshrk').value.replace(',', '');
                    QtyToOrder = document.getElementById('ctl00_cph_main_content_grdgayed_' + ctlid + '_lblFabQtyToOrder').innerText.replace(',', '');
                    ReceiveQty = document.getElementById('ctl00_cph_main_content_grdgayed_' + ctlid + '_recqty').innerText.replace(',', '');
                    Cutwastgae = document.getElementById('ctl00_cph_main_content_grdgayed_' + ctlid + '_lblcutwastgae').innerText.replace(',', '');

                    if (balanceInhOuse == '') {
                        balanceInhOuse = 0;
                    }

                    if (ResidualShrn == '') {
                        ResidualShrn = 0;
                    }
                    if (FabQty == '') {
                        FabQty = 0;
                    }
                    if (ReceiveQty == '') {
                        ReceiveQty = 0;
                    }
                    if (GreigeShrn == '') {
                        GreigeShrn = 0;
                    }
                    if (BalanceInHouse == '') {
                        BalanceInHouse = 0;
                    }
                    if (Cutwastgae == '') {
                        Cutwastgae = 0;
                    }
                    // var FinalPendingqty = parseInt(FabQty) - parseInt(BalanceInHouse);
                    var FinalPendingqty = parseInt(FabQty)

                    //                    finalval = parseFloat(GreigeShrn) + parseFloat(ResidualShrn) + parseFloat(Cutwastgae); 
                    //                    calculate = parseFloat(FabQty) + (parseFloat(FabQty) * parseFloat(finalval) / 100);
                    calculate = ((parseFloat(FinalPendingqty) * parseFloat(100)) / (parseFloat(100) - (parseFloat(GreigeShrn) + parseFloat(ResidualShrn) + parseFloat(Cutwastgae))));

                    if (calculate > 0) {
                        document.getElementById('ctl00_cph_main_content_grdgayed_' + ctlid + '_lbltotalqtytosend').innerText = numberWithCommas(Math.round(calculate));
                        //pendingqty = (parseInt(calculate) - parseInt(ReceiveQty));


                        FabricQualityID = document.getElementById('ctl00_cph_main_content_grdgayed_' + ctlid + '_hdnfabricQuality').value;
                        calculate = parseInt(calculate);
                        if (Type == 1) {
                            var url = "../../Webservices/iKandiService.asmx";
                            $.ajax({
                                type: "POST",
                                url: url + "/updateDayedValue",
                                data: "{ Flag:'" + 'DYED' + "', FlagOption:'" + 'UPDATEDAYED' + "', GreigedShrinkage:'" + GreigeShrn + "',FabricQualityID:'" + FabricQualityID + "',ResidualShrinkage:'" + ResidualShrn + "'}",
                                contentType: "application/json; charset=utf-8",
                                dataType: "json",
                                success: OnSuccessCall,
                                error: OnErrorCall
                            });

                            function OnSuccessCall(response) {
                            }

                            function OnErrorCall(response) {
                            }
                        }
                    }
                }
            }

        }

        function CalculateOnLoadPrint(Type) {

            ctlid = "";
            var FabQty = 0;
            var QtyToOrder = 0;
            var GreigeShrn = 0;
            var IsChkRsk = 0;
            var ResidualShrn = 0;
            var BalanceInHouse = 0;
            var ReceiveQty = 0;
            var GridId = "<%=grdprint.ClientID %>";
            var grid = document.getElementById(GridId);
            if (grid != null) {
                rowscount = grid.rows.length - 2;
                var RowIndexs = 04;
                var i;
                for (i = 1; i <= rowscount; i++) {
                    if (RowIndexs < 10) {
                        ctlid = 'ctl' + '0' + RowIndexs;
                    }
                    else {
                        ctlid = 'ctl' + RowIndexs;
                    }
                    RowIndexs = RowIndexs + 1;
                    FabQty = document.getElementById('ctl00_cph_main_content_grdprint_' + ctlid + '_lblfabricQty').innerText.replace(',', '');
                    BalanceInHouse = document.getElementById('ctl00_cph_main_content_grdprint_' + ctlid + '_lblbalanceinhouseqty').innerText.replace(',', '');
                    ResidualShrn = document.getElementById('ctl00_cph_main_content_grdprint_' + ctlid + '_txtResidualShak').value.replace(',', '');
                    GreigeShrn = document.getElementById('ctl00_cph_main_content_grdprint_' + ctlid + '_txtGreigeshrk').value.replace(',', '');
                    QtyToOrder = document.getElementById('ctl00_cph_main_content_grdprint_' + ctlid + '_lblFabQtyToOrder').innerText.replace(',', '');
                    ReceiveQty = document.getElementById('ctl00_cph_main_content_grdprint_' + ctlid + '_recqty').innerText.replace(',', '');
                    Cutwastage = document.getElementById('ctl00_cph_main_content_grdprint_' + ctlid + '_lblcutwastgae').innerText.replace(',', '');

                    if (BalanceInHouse == '') {
                        BalanceInHouse = 0;
                    }

                    if (ResidualShrn == '') {
                        ResidualShrn = 0;
                    }
                    if (FabQty == '') {
                        FabQty = 0;
                    }
                    if (ReceiveQty == '') {
                        ReceiveQty = 0;
                    }
                    if (GreigeShrn == '') {
                        GreigeShrn = 0;
                    }
                    if (BalanceInHouse == '') {
                        BalanceInHouse = 0;
                    }
                    if (Cutwastage == '') {
                        Cutwastage = 0;
                    }
                    // var FinalPendingqty = parseInt(FabQty) - parseInt(balanceInhOuse);
                    var FinalPendingqty = parseInt(FabQty);  //- parseInt(balanceInhOuse);

                    calculate = ((parseFloat(FinalPendingqty) * parseFloat(100)) / (parseFloat(100) - (parseFloat(GreigeShrn) + parseFloat(ResidualShrn) + parseFloat(Cutwastage))));

                    if (calculate > 0) {
                        document.getElementById('ctl00_cph_main_content_grdprint_' + ctlid + '_lbltotalqtytosend').innerText = numberWithCommas(Math.round(calculate));
                        FabricQualityID = document.getElementById('ctl00_cph_main_content_grdprint_' + ctlid + '_hdnfabricQuality').value;
                        calculate = parseInt(calculate);
                        if (Type == 1) {
                            var url = "../../Webservices/iKandiService.asmx";
                            $.ajax({
                                type: "POST",
                                url: url + "/updateDayedValue",
                                data: "{ Flag:'" + 'PRINT' + "', FlagOption:'" + 'UPDATEPRINT' + "', GreigedShrinkage:'" + GreigeShrn + "',FabricQualityID:'" + FabricQualityID + "',ResidualShrinkage:'" + ResidualShrn + "'}",
                                contentType: "application/json; charset=utf-8",
                                dataType: "json",
                                success: OnSuccessCall,
                                error: OnErrorCall
                            });

                            function OnSuccessCall(response) {
                            }

                            function OnErrorCall(response) {
                            }
                        }
                    }
                }
            }
        }
        function OpenWastageAdmin(FabType, FabricQualityID, FabricDetails, cutwastage) {
            if (cutwastage == "") {
                cutwastage = 0;
            }
            var sURL = 'FrmFabricWastageEntry.aspx?FabricQualityID=' + FabricQualityID + "&FabType=" + FabType + "&FabricDetails=" + FabricDetails + "&IsExecute=" + "FABRICVIEW" + "&cutwastage=" + cutwastage;
            Shadowbox.init({ animate: false, animateFade: true, modal: true });
            Shadowbox.open({ content: sURL, type: "iframe", player: "iframe", title: "", height: 400, width: 1100, modal: true, animate: true, oversized: true, animateFade: true, options: { onClose: SBClose } });
            $('#sb-wrapper').removeClass("PurchaseOrder");
            return false;
        }
        function Setwidthwastagescreen(width, Height) {

            if (width <= 1172) {
                $("#sb-wrapper").css("width", parseInt(width) - 5 + "px");
            }
            if (width == 1172) {
                $("#sb-wrapper").css("left", "100px");
            }
            if (width <= 752) {
                $("#sb-wrapper").css("left", "300px");
            }
            if (Height <= 300) {
                $("#sb-wrapper-inner").css("height", parseInt(Height) + 150 + "px");
            }

        }
        function callparentpage() {

            ShowHideSuppliergrd($("#ctl00_cph_main_content_hdnFabtype").val());

        }
        function OpenWastageAdminPrint(FabType, FabricQualityID, FabricDetails, CurrentStage, PreviousStage, IsStyleSpecific, StyleID, stage1, stage2, stage3, stage4, cutwastage) {

            var sURL = 'FrmFabricWastageEntry.aspx?FabricQualityID=' + FabricQualityID + "&FabType=" + FabType + "&FabricDetails=" + FabricDetails + "&CurrentStage=" + CurrentStage + "&PreviousStage=" + PreviousStage + "&IsStyleSpecfic=" + IsStyleSpecific + "&StyleID=" + StyleID + "&stage1=" + stage1 + "&stage2=" + stage2 + "&stage3=" + stage3 + "&stage4=" + stage4 + "&cutwastage=" + cutwastage + "&IsExecute=" + "FABRICVIEW";
            Shadowbox.init({ animate: true, animateFade: true, modal: true });
            Shadowbox.open({ content: sURL, type: "iframe", player: "iframe", title: "", height: 450, width: 800, modal: true, animate: true, oversized: true, animateFade: true, options: { onClose: SBClose} });
            $('#sb-wrapper').removeClass("PurchaseOrder");
            return false;
        }
        function funcolor(cls) {
            //            alert(cls);
            //            $('td').removeAttr("style");
            //            $(".bgon" + cls).find('td').css("background-color", "#f1eaf0");
        }
        function pageLoad() {

            $("#ctl00_cph_main_content_grdEmbellishment tr,#ctl00_cph_main_content_grdvalueadditionRFD tr,#ctl00_cph_main_content_grdgreigerasiepo tr,#ctl00_cph_main_content_grdfinishing tr,#ctl00_cph_main_content_grdgayed tr ,#ctl00_cph_main_content_grdEmbroidery tr").click(function () {
                $('#ctl00_cph_main_content_grdvalueadditionRFD  > tbody > tr').not(':first').find('td').css("background-color", "#FFFFFF");
                $('#ctl00_cph_main_content_grdgreigerasiepo  > tbody > tr').not(':first').find('td').css("background-color", "#FFFFFF");
                $('#ctl00_cph_main_content_grdEmbellishment  > tbody > tr').not(':first').find('td').css("background-color", "#FFFFFF");
                $('#ctl00_cph_main_content_grdfinishing  > tbody > tr').not(':first').find('td').css("background-color", "#FFFFFF");
                $('#ctl00_cph_main_content_grdgayed  > tbody > tr').not(':first').find('td').css("background-color", "#FFFFFF");
                $('#ctl00_cph_main_content_grdEmbroidery  > tbody > tr').not(':first').find('td').css("background-color", "#FFFFFF");
                if ($(this).hasClass("HeaderClass") == false) {
                    $(this).find('td').css("background-color", "");
                }
            })

        }

        function RFDBorderBottom() {

            var FabmaxRowRFD = 0;
            var FabrowSpanRFD = 0;
            $('.FabRFDTable td[rowspan]').each(function () {
                var row = $(this).parent().parent().children().index($(this).parent());
                if (row > FabmaxRowRFD) {
                    FabmaxRowRFD = row;
                    FabrowSpanRFD = 0;
                }
                if ($(this).attr('rowspan') > FabrowSpanRFD) FabrowSpanRFD = $(this).attr('rowspan');
            });
            if (FabmaxRowRFD == $('.FabRFDTable tr:last td').parent().parent().children().index($('.FabRFDTable tr:last td').parent()) - (FabrowSpanRFD - 1)) {
                $('.FabRFDTable td[rowspan]').each(function () {
                    var row = $(this).parent().parent().children().index($(this).parent());
                    if (row == FabmaxRowRFD && $(this).attr('rowspan') == FabrowSpanRFD) $(this).addClass('border_last_bottom_color');
                });
            }
        }
        //End

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_main_content" runat="server">


    <asp:ScriptManager ID="scriptmanager1" runat="server" AsyncPostBackTimeout="600">
    </asp:ScriptManager>
    <asp:UpdateProgress runat="server" ID="uproTargetAdmin" AssociatedUpdatePanelID="updatepnl"
        DisplayAfter="0">
        <ProgressTemplate>
            <div id="spinner" class="fade-in">
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdatePanel ID="updatepnl" runat="server" >
        <ContentTemplate>

            <asp:HiddenField ID="hdntabvalue" runat="server" />
            <asp:HiddenField ID="hdnponumber" runat="server" />
            <asp:HiddenField ID="hdnmasterpoid" runat="server" />
            <asp:HiddenField ID="hdnIsMailSend" runat="server" />
            <asp:HiddenField ID="hdnStageName" runat="server" Value="" />
            <asp:HiddenField ID="hdnFabTypeForMail" runat="server" Value="" />
            <div class="headerSticky">Raise <span style="text-transform: lowercase;">and</span> Revise Fabric PO</div>

            <%-- <div style="clear:both;margin-top:50px;"></div>--%>

            <div class="abc tab">

                <a onclick="ShowHideSuppliergrd('GRIEGE');" runat="server" id="agreige" class="tab1greige">Greige</a>
                <a onclick="ShowHideSuppliergrd('DYED');" runat="server" id="adayed" class="tab1Dayed">Dyed</a>
                <a onclick="ShowHideSuppliergrd('PRINT');" runat="server" id="aprint" class="tab1Print">Print</a>
                <a onclick="ShowHideSuppliergrd('FINISHING');" runat="server" id="afinished" class="tab1finished">Finished</a>
                <a onclick="ShowHideSuppliergrd('RFD');" runat="server" id="ava" class="tab1VA">RFD</a>
                <a onclick="ShowHideSuppliergrd('Embellishment');" runat="server" title="This process is Value added based" style="width: 100px;" id="aEmbellishment" class="tabEmbellishment">Embellishment</a>
                <a onclick="ShowHideSuppliergrd('Embroidery');" runat="server" title="This process is Value added based" style="width: 100px;" id="aEmbroidery" class="tabEmbroidery">Embroidery</a>

            </div>
            <div class="SearchBoxDiv" style="width: 396px">
                <div class="SearchBox">
                    <asp:TextBox ID="txtsearchkeyswords" type="search" class="search_1" placeholder="Search Fabric Quality"
                        runat="server" Style="width: 177px !important; margin: 2px 0px 1px; padding-left: 3px; height: 16px !important"></asp:TextBox>
                    <%--status <asp:DropDownList ID="ddlstatus" runat="server">
        <asp:ListItem value="-1">All</asp:ListItem>
        <asp:ListItem value="0">Open</asp:ListItem>
        <asp:ListItem value="1">Cancel</asp:ListItem>
        <asp:ListItem value="2">Closed</asp:ListItem>
        <asp:ListItem value="5">Cancel & Closed</asp:ListItem>
        </asp:DropDownList>--%>
                    <asp:Button ID="btnSearch" runat="server" CssClass="go do-not-disable" Text="Search"
                        OnClick="btnSearch_Click" Style="padding: 2px 7px;" />
                </div>
            </div>

            <asp:HiddenField ID="hdnFabtype" runat="server" Value='GRIEGE' />
            <asp:GridView ID="grdgreigerasiepo" class="greigegrd greigegrdbor"
                ShowHeader="false" runat="server" AutoGenerateColumns="False" EmptyDataText=""
                Width="1313px" HeaderStyle-Font-Names="Arial" HeaderStyle-HorizontalAlign="Center"
                ShowHeaderWhenEmpty="true" BorderWidth="0" rules="all" OnRowDataBound="grdgreigerasiepo_RowDataBound"
                HeaderStyle-CssClass="ths">
                <SelectedRowStyle BackColor="#A1DCF2" />
                <EditRowStyle CssClass="EmpltyTable" />
                <Columns>
                    <asp:TemplateField HeaderText="Fabric Quality (GSM) Width<br> Print/Color">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemTemplate>
                            <asp:Label ID="recqty" Style="display: none;" runat="server"></asp:Label>
                            <asp:HiddenField ID="hdnfabricQuality" runat="server" Value='<%# Eval("Fabric_QualityID")%>' />
                            <asp:Label ID="lblFabricQuality" ForeColor="blue" CssClass="color_black classfabsave"
                                Text='<%# Eval("TradeName")%>' runat="server"></asp:Label>
                            <asp:Label ID="lblgsm" CssClass="gray" Text='<%# "("+Eval("GSM")+ ") "%>' runat="server"></asp:Label>
                            <asp:Label ID="lblcountconstraction" CssClass="gray" Text='<%# Eval("CountConstruction").ToString()%>'
                                runat="server"></asp:Label>
                            <asp:Label ID="lblwidth" CssClass="gray" Text='<%# Eval("width").ToString()+"&quot" %>'
                                runat="server"></asp:Label><br />
                            <asp:Label ID="lblcolor" CssClass="color_black" Font-Bold="true" ForeColor="black"
                                runat="server" Text='<%# Eval("FabricDetails").ToString() %>'></asp:Label>
                            <%--added by raghvinder on 25-09-2020 start--%>
                            <asp:Label ID="lblUnit" CssClass="gray" Font-Bold="true" ForeColor="gray" runat="server"
                                Text='<%# Eval("UnitName").ToString() == "" ? "" :  Eval("UnitName") %>'></asp:Label>
                            <%--added by raghvinder on 25-09-2020 end--%>
                            <asp:HiddenField ID="hdnmaxgrige" runat="server" Value='<%# (Eval("Greige_Sh") == DBNull.Value  || (Eval("Greige_Sh").ToString().Trim() == string.Empty)) ? string.Empty : Eval("Greige_Sh").ToString().Trim() %>' />
                            <asp:HiddenField ID="hdnstage1" runat="server" Value='<%# Eval("Stage1")%>' />
                            <asp:HiddenField ID="hdnstage2" runat="server" Value='<%# Eval("Stage2")%>' />
                            <asp:HiddenField ID="hdnstage3" runat="server" Value='<%# Eval("Stage3")%>' />
                            <asp:HiddenField ID="hdnstage4" runat="server" Value='<%# Eval("Stage4")%>' />
                            <asp:HiddenField ID="hdnadjustmentqty" runat="server" Value='<%# Eval("adjustmentqty")%>' />
                            <br />
                            <asp:Label ID="lblGriege" CssClass="GriegeStage" Font-Bold="false" ForeColor="gray" runat="server"
                                Text='1'></asp:Label>
                        </ItemTemplate>


                        <ItemStyle CssClass="textLeft GriegeStageRe" Width="140px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Style No.">
                        <ItemTemplate>
                            <asp:Label ID="lblstyleno" CssClass="color_black" runat="server"></asp:Label>
                            <asp:GridView ID="grdstylenumber" ShowHeader="false" runat="server" AutoGenerateColumns="False"
                                EmptyDataText="No Record Found!" Width="98%" HeaderStyle-Font-Names="Arial" HeaderStyle-HorizontalAlign="Center"
                                CssClass="grdDyedtable Griegetable" BorderWidth="0" rules="all" HeaderStyle-CssClass="ths">
                                <SelectedRowStyle BackColor="#A1DCF2" />
                                <RowStyle CssClass="DyedRowCount" />
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:HiddenField ID="hdnStyleid" runat="server" Value='<%# Eval("StyleID")%>' />
                                            <asp:Label ID="lblStyleNumber" Text='<%# Eval("StyleNumber")%>' runat="server"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" CssClass="borderDy" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <%--  <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />:
                                    <asp:Label--%>
                                            <asp:Label ID="lblSerialNumber" Text='<%# "("+Eval("SerialNumber")+ ") "%>' runat="server"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Right" CssClass="borderDy" />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </ItemTemplate>
                        <ItemStyle Width="70px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Overall to order/send<span style='color:gray'> Mtr.</span>">
                        <ItemTemplate>
                            <asp:Label ID="lblfabricorderavg" Style="display: none;" runat="server"></asp:Label>

                            <table border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td style='border-bottom: 1px solid #e2dddd99'>
                                        <asp:Label ID="lblfabricorderavg2"
                                            CssClass="clfabqty" runat="server"></asp:Label>
                                        <asp:Label ID="lblcutwastgae" Style="display: none" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblrequiredqty" title="Click here to view wastage details & get reuired quantity"
                                            Style="color: blue; cursor: pointer;" CssClass="clfabqty" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </table>

                        </ItemTemplate>
                        <ItemStyle Width="70px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Greige" Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="lblGreige" CssClass="color_black" Visible="false" Text='<%# (Eval("Greige_Sh") == DBNull.Value  || (Eval("Greige_Sh").ToString().Trim() == string.Empty)) ? string.Empty : Eval("Greige_Sh").ToString().Trim() %>'
                                runat="server"></asp:Label>
                            <asp:TextBox ID="txtGreige_Sh" onchange="CalculateOnLoad();" onkeypress="return validateFloatKeyPress(this,event);"
                                Style="width: 85% !important; text-align: center;" runat="server" Text='<%# (Eval("Greige_Sh") == DBNull.Value  || (Eval("Greige_Sh").ToString().Trim() == string.Empty)) ? string.Empty : Eval("Greige_Sh").ToString().Trim() %>'></asp:TextBox>
                        </ItemTemplate>
                        <ItemStyle Width="50px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="IsApply" Visible="false">
                        <ItemTemplate>
                            <asp:CheckBox ID="chkApplyResShrinkage" Style="float: left" onchange="showhideresidualshrinke(this)"
                                class="Classapplyshrink" runat="server" Checked='<%#((bool)Eval("IsResidualShrinkaage"))%>' />
                            <asp:TextBox ID="txtResidualSh" onchange="CalculateOnLoad();" onkeypress="return validateFloatKeyPress(this,event);"
                                MaxLength="5" runat="server" Text='<%# (Eval("ResidualShrinkaage") == DBNull.Value  || (Eval("ResidualShrinkaage").ToString().Trim() == string.Empty)) ? string.Empty : Eval("ResidualShrinkaage").ToString().Trim() %>'
                                Style="width: 35px !important; text-align: center; float: left;" class='<%# Convert.ToInt32(Eval("IsResidualShrinkaage")) == 0 ? "hide_me" : "show_me"  %>'></asp:TextBox>
                            <asp:Label ID="lblresidualshrink" Style="color: Gray; float: right; padding-right: 2px; position: relative; top: 4px"
                                runat="server"></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="123px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Balance In House">
                        <ItemTemplate>
                            <div class="AccessToltip">
                                <asp:Label ID="lblbalanceinhouseqty" Text='<%# (Eval("BalanceHouseQty") == DBNull.Value  || (Eval("BalanceHouseQty").ToString().Trim() == "0")) ? string.Empty : Eval("BalanceHouseQty").ToString().Trim() %>'
                                    runat="server"></asp:Label>
                                <asp:Label ID="lblBalanceTooltip" runat="server" Text=""></asp:Label>
                            </div>
                        </ItemTemplate>
                        <ItemStyle Width="80px" />
                    </asp:TemplateField>
                    <asp:TemplateField Visible="false" HeaderText="Qty To Order(Required)">
                        <ItemTemplate>
                            <asp:Label ID="lblFabQtyRemaning" Style="display: none;" runat="server"></asp:Label>
                            <asp:Label ID="lblFabQtyRemaning2" runat="server"></asp:Label>
                            <asp:Label ID="lblTotalFabRequired" Style="display: none;" runat="server"></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="80px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Qoute1">
                        <ItemTemplate>
                            <asp:Label ID="lblQouteRate_1" runat="server"></asp:Label>
                            <asp:Label ID="lblQouteTime_1" runat="server"></asp:Label><br />
                            <asp:Label ID="lblQouteSupplierName_1" runat="server"></asp:Label><br />
                            <asp:Label ID="lblQouteLeadDays_1" runat="server"></asp:Label>
                        </ItemTemplate>
                        <ItemStyle CssClass="backColor1" Width="140px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Qoute2">
                        <ItemTemplate>
                            <asp:Label ID="lblQouteRate_2" runat="server"></asp:Label>
                            <asp:Label ID="lblQouteTime_2" runat="server"></asp:Label><br />
                            <asp:Label ID="lblQouteSupplierName_2" runat="server"></asp:Label><br />
                            <asp:Label ID="lblQouteLeadDays_2" runat="server"></asp:Label>
                        </ItemTemplate>
                        <ItemStyle CssClass="backColor2" Width="140px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Qoute3">
                        <ItemTemplate>
                            <asp:Label ID="lblQouteRate_3" runat="server"></asp:Label>
                            <asp:Label ID="lblQouteTime_3" runat="server"></asp:Label><br />
                            <asp:Label ID="lblQouteSupplierName_3" runat="server"></asp:Label><br />
                            <asp:Label ID="lblQouteLeadDays_3" runat="server"></asp:Label>
                        </ItemTemplate>
                        <ItemStyle CssClass="backColor3" Width="140px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="PO Numbaer">
                        <ItemTemplate>
                        </ItemTemplate>
                        <ItemStyle Width="50px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Supplier">
                        <ItemTemplate>
                        </ItemTemplate>
                        <ItemStyle Width="50px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Qty">
                        <ItemTemplate>
                        </ItemTemplate>
                        <ItemStyle Width="50px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Action">
                        <ItemTemplate>
                        </ItemTemplate>
                        <ItemStyle Width="50px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Pending Qty (To order)">
                        <ItemTemplate>
                            <table border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td style="min-width: 40px; text-align: right">
                                        <asp:Label ID="pendingQtyinorder" runat="server"></asp:Label>
                                    </td>
                                    <td style="min-width: 12px;">
                                        <a id="lnkProductionpopup" runat="server" style="font-size: 8px; position: relative; top: -2px;">
                                            <img src="../../App_Themes/ikandi/images/zoom_icon1.gif" style="cursor: pointer;" />
                                        </a>
                                    </td>
                                    <td style="min-width: 40px;">
                                        <asp:Button ID="btnrapo" Style="display: none;" runat="server" Text="R.PO" />
                                        <div class="btnrpo tooltip" runat="server" id="divraise">
                                            R.PO
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </ItemTemplate>
                        <ItemStyle Width="50px" />
                    </asp:TemplateField>
                </Columns>
                <EmptyDataTemplate>
                    <table cellspacing="0" rules="all" class="greigegrd greigegrdbor nobordertd" border="0"
                        id="ctl00_cph_main_content_grdgreigerasiepo" style="border-width: 0px; width: 100%; border-collapse: collapse;">
                        <tbody>
                            <tr class="HeaderClass">
                                <td align="center" style="min-width: 180px;">
                                    <table>
                                        <tbody>
                                            <tr>
                                                <td colspan="3" style="border: 0px">Fabric Quality (GSM) C&amp;C Width<br>
                                                    Color/Print (Unit)</td>
                                            </tr>
                                            <tr>
                                                <td>Current Stage</td>
                                                <td>Previous Stage</td>
                                                <td>Style Specific</td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </td>
                                <td align="center" style="min-width: 150px;">Style No. (Serial No.)</td>
                                <td align="center" style="width: 60px;">
                                    <table>
                                        <tbody>
                                            <tr>
                                                <td style="border: 0px">Overall to order/send</td>
                                            </tr>
                                            <tr>
                                                <td>required qty</td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </td>
                                <td align="center" style="width: 40px;">Balance
                                    <br>
                                    In House </td>
                                <td align="center" style="width: 160px;">Quote 1 (Rate &amp; Time)<br>
                                    Supplier Name<br>
                                    Lead Time</td>
                                <td align="center" style="width: 160px;">Quote 2 (Rate &amp; Time)<br>
                                    Supplier Name<br>
                                    Lead Time</td>
                                <td align="center" style="width: 160px;">Quote 3 (Rate &amp; Time)<br>
                                    Supplier Name<br>
                                    Lead Time</td>
                                <td align="center" style="width: 80px;">PO Number</td>
                                <td align="center" style="min-width: 130px;">PO Supplier Name</td>
                                <td align="center" style="width: 60px;">Rcvd. Qty. </td>
                                <td align="center" class="widthAction">Revise PO</td>
                                <td align="center" class="widthPending">Qty. to Raise PO</td>
                            </tr>
                            <tr>
                                <td colspan="12" style="text-align: center; border: 0px;">
                                    <img src='../../images/sorry.png' alt='No record found' />
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </EmptyDataTemplate>
            </asp:GridView>

            <asp:GridView ID="grdfinishing" ShowHeader="false" runat="server"
                AutoGenerateColumns="False" EmptyDataText="No Record Found!" Width="100%" HeaderStyle-Font-Names="Arial"
                HeaderStyle-HorizontalAlign="Center" CssClass="greigegrdbor" BorderWidth="0"
                rules="all" OnRowDataBound="grdfinishing_RowDataBound" HeaderStyle-CssClass="ths">
                <SelectedRowStyle BackColor="#A1DCF2" />
                <EditRowStyle CssClass="EmpltyTable" />
                <Columns>
                    <asp:TemplateField HeaderText="Fabric Quality (GSM) Width<br> Print/Color">
                        <ItemStyle CssClass="textLeft GriegeStageRe" Width="140px" />
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemTemplate>
                            <asp:Label ID="recqty" Style="display: none;" runat="server"></asp:Label>
                            <asp:HiddenField ID="hdnfabricQuality" runat="server" Value='<%# Eval("Fabric_QualityID")%>' />
                            <asp:Label ID="lblFabricQuality" ForeColor="blue" CssClass="color_black classfabsave"
                                Text='<%# Eval("TradeName")%>' runat="server"></asp:Label>
                            <asp:Label ID="lblgsm" CssClass="gray" Text='<%# "("+Eval("GSM")+ ") "%>' runat="server"></asp:Label>
                            <asp:Label ID="lblcountconstraction" CssClass="gray" Text='<%# Eval("CountConstruction").ToString()%>'
                                runat="server"></asp:Label>
                            <asp:Label ID="lblwidth" CssClass="gray" Text='<%# Eval("width").ToString()+"&quot" %>'
                                runat="server"></asp:Label><br />
                            <asp:Label ID="lblcolor" CssClass="color_black" Font-Bold="true" ForeColor="black"
                                runat="server" Text='<%# Eval("FabricDetails").ToString() %>'></asp:Label>
                            <%--added by raghvinder on 25-09-2020 start--%>
                            <asp:Label ID="lblUnit" CssClass="gray" Font-Bold="true" ForeColor="gray" runat="server"
                                Text='<%# Eval("UnitName").ToString() == "" ? "" : Eval("UnitName")%>'></asp:Label>
                            <%--added by raghvinder on 25-09-2020 end--%>
                            <asp:HiddenField ID="hdncutwastage" runat="server" />
                            <asp:HiddenField ID="hdnResidualShrinkage" runat="server" Value='<%# (Eval("Residual_Sh") == DBNull.Value  || (Eval("Residual_Sh").ToString().Trim() == string.Empty)) ? string.Empty : Eval("Residual_Sh").ToString().Trim() %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Style No.">
                        <ItemTemplate>
                            <asp:GridView ID="grdstylenumber" ShowHeader="false" runat="server" AutoGenerateColumns="False"
                                EmptyDataText="No Record Found!" Width="98%" HeaderStyle-Font-Names="Arial" HeaderStyle-HorizontalAlign="Center"
                                CssClass="grdDyedtable Griegetable" BorderWidth="0" rules="all" HeaderStyle-CssClass="ths">
                                <SelectedRowStyle BackColor="#A1DCF2" />
                                <RowStyle CssClass="DyedRowCount" />
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:HiddenField ID="hdnStyleid" runat="server" Value='<%# Eval("StyleID")%>' />
                                            <asp:Label ID="lblStyleNumber" Text='<%# Eval("StyleNumber")%>' runat="server"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" CssClass="leftagligh borderDy" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <%--  <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />:
                                    <asp:Label--%>
                                            <asp:Label ID="lblSerialNumber" Text='<%# "("+Eval("SerialNumber")+ ") "%>' runat="server"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="right" CssClass="rightagligh borderDy " />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </ItemTemplate>
                        <ItemStyle Width="70px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Overall to order/send">
                        <ItemTemplate>
                            <table border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td style='border-bottom: 1px solid #e2dddd99'>
                                        <asp:Label ID="lblfabricorderavg2" CssClass="clfabqty" runat="server"></asp:Label>
                                        <asp:HiddenField ID="hdnfabricQualityresi" runat="server" Value='<%# Eval("Fabric_QualityID")%>' />
                                        <asp:HiddenField ID="hdnfanricdetails" runat="server" Value='<%# Eval("FabricDetails")%>' />
                                        <asp:Label ID="lblfabricorderavg" Style="display: none;" runat="server"></asp:Label>
                                        <asp:HiddenField ID="hdnfabprint" runat="server" Value='<%# Eval("FabricDetails").ToString() %>' />
                                        <asp:HiddenField ID="hdnstage1" runat="server" Value='<%# Eval("Stage1")%>' />
                                        <asp:HiddenField ID="hdnstage2" runat="server" Value='<%# Eval("Stage2")%>' />
                                        <asp:HiddenField ID="hdnstage3" runat="server" Value='<%# Eval("Stage3")%>' />
                                        <asp:HiddenField ID="hdnstage4" runat="server" Value='<%# Eval("Stage4")%>' />
                                        <asp:HiddenField ID="hdnadjustmentqty" runat="server" Value='<%# Eval("adjustmentqty")%>' />
                                        <asp:Label ID="lblcutwastgae" Style="display: none" runat="server"></asp:Label>

                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblrequiredqty" title="Click here to view wastage details & get reuired quantity"
                                            Style="color: blue; cursor: pointer;" CssClass="clfabqty" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </ItemTemplate>
                        <ItemStyle Width="70px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Finish" Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="lblfinish" CssClass="color_black" Visible="false" Text='<%# (Eval("Residual_Sh") == DBNull.Value  || (Eval("Residual_Sh").ToString().Trim() == string.Empty)) ? string.Empty : Eval("Residual_Sh").ToString().Trim() %>'
                                runat="server"></asp:Label>
                            <asp:TextBox ID="txtFinishedResidualShrinkage" onkeypress="return validateFloatKeyPress(this,event);"
                                onchange="updateresidual(this)" Style="width: 90% !important; text-align: center;"
                                runat="server" Text='<%# (Eval("Residual_Sh") == DBNull.Value  || (Eval("Residual_Sh").ToString().Trim() == string.Empty)) ? string.Empty : Eval("Residual_Sh").ToString().Trim() %>'></asp:TextBox>
                        </ItemTemplate>
                        <ItemStyle Width="50px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Balance In House">
                        <ItemTemplate>


                            <div class="AccessToltip">
                                <asp:Label ID="lblbalanceinhouseqty" Text='<%# (Eval("BalanceHouseQty") == DBNull.Value  || (Eval("BalanceHouseQty").ToString().Trim() == "0")) ? string.Empty : Eval("BalanceHouseQty").ToString().Trim() %>'
                                    runat="server"></asp:Label>
                                <asp:Label ID="lblBalanceTooltip" runat="server" Text=""></asp:Label>
                            </div>

                        </ItemTemplate>
                        <ItemStyle Width="80px" />
                    </asp:TemplateField>
                    <asp:TemplateField Visible="false" HeaderText="Qty To Order(Required)">
                        <ItemTemplate>
                            <asp:Label ID="lblFabQtyRemaning" Style="display: none;" runat="server"></asp:Label>
                            <asp:Label ID="lblFabQtyRemaning2" runat="server"></asp:Label>
                            <asp:Label ID="lblTotalFabRequired" Visible="false" runat="server"></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="80px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Qoute1">
                        <ItemTemplate>
                            <asp:Label ID="lblQouteRate_1" runat="server"></asp:Label>
                            <asp:Label ID="lblQouteTime_1" runat="server"></asp:Label><br />
                            <asp:Label ID="lblQouteSupplierName_1" runat="server"></asp:Label><br />
                            <asp:Label ID="lblQouteLeadDays_1" runat="server"></asp:Label>
                        </ItemTemplate>
                        <ItemStyle CssClass="backColor1" Width="140px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Qoute2">
                        <ItemTemplate>
                            <asp:Label ID="lblQouteRate_2" runat="server"></asp:Label>
                            <asp:Label ID="lblQouteTime_2" runat="server"></asp:Label><br />
                            <asp:Label ID="lblQouteSupplierName_2" runat="server"></asp:Label><br />
                            <asp:Label ID="lblQouteLeadDays_2" runat="server"></asp:Label>
                        </ItemTemplate>
                        <ItemStyle CssClass="backColor2" Width="140px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Qoute3">
                        <ItemTemplate>
                            <asp:Label ID="lblQouteRate_3" runat="server"></asp:Label>
                            <asp:Label ID="lblQouteTime_3" runat="server"></asp:Label><br />
                            <asp:Label ID="lblQouteSupplierName_3" runat="server"></asp:Label><br />
                            <asp:Label ID="lblQouteLeadDays_3" runat="server"></asp:Label>
                        </ItemTemplate>
                        <ItemStyle CssClass="backColor3" Width="140px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="PO Numbaer">
                        <ItemTemplate>
                        </ItemTemplate>
                        <ItemStyle Width="50px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Supplier">
                        <ItemTemplate>
                        </ItemTemplate>
                        <ItemStyle Width="50px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Qty">
                        <ItemTemplate>
                        </ItemTemplate>
                        <ItemStyle Width="50px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Action">
                        <ItemTemplate>
                        </ItemTemplate>
                        <ItemStyle Width="50px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Pending Qty (To order)">
                        <ItemTemplate>
                            <table border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td style="min-width: 40px; text-align: right">
                                        <asp:Label ID="pendingQtyinorder" runat="server"></asp:Label>
                                    </td>
                                    <td style="min-width: 12px;">
                                        <a id="lnkProductionpopup" runat="server" style="font-size: 8px; position: relative; top: -2px;">
                                            <img src="../../App_Themes/ikandi/images/zoom_icon1.gif" style="cursor: pointer;" /></a>
                                    </td>
                                    <td style="min-width: 40px;">
                                        <asp:Button ID="btnrapo" Style="display: none;" runat="server" Text="R.PO" />
                                        <div class="btnrpo tooltip" runat="server" id="divraise">
                                            R.PO
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </ItemTemplate>
                        <ItemStyle Width="50px" />
                    </asp:TemplateField>
                </Columns>
                <EmptyDataTemplate>
                    <table cellspacing="0" rules="all" class="greigegrd greigegrdbor nobordertd" border="0"
                        id="ctl00_cph_main_content_grdgreigerasiepo" style="border-width: 0px; width: 100%; border-collapse: collapse;">
                        <tbody>

                            <tr class="HeaderClass">
                                <td align="center" style="min-width: 200px;">
                                    <table>
                                        <tbody>
                                            <tr>
                                                <td colspan="3" style="border: 0px;">Fabric Quality (GSM) C&amp;C Width<br>
                                                    Color/Print (Unit)</td>
                                            </tr>
                                            <tr>
                                                <td>Current Stage</td>
                                                <td>Previous Stage</td>
                                                <td>Style Specific</td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </td>
                                <td align="center" style="min-width: 150px;">Style No. (Serial No.)</td>
                                <td align="center" style="width: 60px;">
                                    <table>
                                        <tbody>
                                            <tr>
                                                <td style="border: 0px">Overall to order/send</td>
                                            </tr>
                                            <tr>
                                                <td>required qty</td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </td>
                                <td align="center" style="width: 40px;">Balance
                                    <br>
                                    In House </td>
                                <td align="center" style="width: 80px;">Total In House </td>
                                <td align="center" style="width: 80px;">Total Send </td>
                                <td align="center" style="width: 160px;">Quote 1 (Rate &amp; Time)<br>
                                    Supplier Name<br>
                                    Lead Time</td>
                                <td align="center" style="width: 160px;">Quote 2 (Rate &amp; Time)<br>
                                    Supplier Name<br>
                                    Lead Time</td>
                                <td align="center" style="width: 160px;">Quote 3 (Rate &amp; Time)<br>
                                    Supplier Name<br>
                                    Lead Time</td>
                                <td align="center" style="width: 80px;">PO Number</td>
                                <td align="center" style="min-width: 130px;">PO Supplier Name</td>
                                <td align="center" style="width: 60px;">Rcvd. Qty.</td>
                                <td align="center" class="widthAction">Revise PO</td>
                                <td align="center" class="widthPending">Qty. to Raise PO </td>
                            </tr>
                            <tr>
                                <td colspan="14" style="text-align: center; border: 0px;">
                                    <img src='../../images/sorry.png' alt='No record found' />
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </EmptyDataTemplate>
            </asp:GridView>

            <asp:GridView ID="grdgayed" class="grdgayeds greigegrdbor"
                ShowHeader="false" runat="server" AutoGenerateColumns="False" EmptyDataText="No Record Found!"
                Width="100%" HeaderStyle-Font-Names="Arial" HeaderStyle-HorizontalAlign="Center"
                BorderWidth="0" rules="all" OnRowDataBound="grdgayed_RowDataBound" HeaderStyle-CssClass="ths">
                <SelectedRowStyle BackColor="#A1DCF2" />
                <EditRowStyle CssClass="EmpltyTable" />
                <Columns>
                    <asp:TemplateField HeaderText="Fabric Quality (GSM) Width<br> Print/Color">
                        <ItemStyle CssClass="textLeft GriegeStageRe" Width="140px" />
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemTemplate>
                            <asp:Label ID="recqty" Style="display: none;" runat="server"></asp:Label>
                            <asp:HiddenField ID="hdnfabricQuality" runat="server" Value='<%# Eval("FabricQualityID")%>' />
                            <asp:Label ID="lblFabricQuality" ForeColor="blue" CssClass="color_black classfabsave"
                                Text='<%# Eval("FabricName")%>' runat="server"></asp:Label>
                            <asp:Label ID="lblgsm" CssClass="gray" Text='<%# "("+Eval("GSM")+ ") "%>' runat="server"></asp:Label>
                            <asp:Label ID="lblcountconstraction" CssClass="gray" Text='<%# Eval("CountConstruction").ToString()%>'
                                runat="server"></asp:Label>
                            <asp:Label ID="lblwidth" CssClass="gray" Text='<%# Eval("width").ToString()+"&quot" %>'
                                runat="server"></asp:Label><br />
                            <asp:Label ID="lblfabriccolor" CssClass="color_black" Font-Bold="true" ForeColor="black"
                                Text='<%# Eval("FabricColor").ToString() %>' runat="server"></asp:Label><br />
                            <%--added by raghvinder on 25-09-2020 start--%>
                            <asp:Label ID="lblUnit" CssClass="gray" Font-Bold="true" ForeColor="gray" runat="server"
                                Text='<%# Eval("UnitName").ToString() == "" ? "" : Eval("UnitName")%>'></asp:Label>
                            <%--added by raghvinder on 25-09-2020 end--%>
                            <asp:HiddenField ID="hdnCurrentstage" runat="server" Value='<%# Eval("CurrentStage")%>' />
                            <asp:HiddenField ID="hdnperiviousstgae" runat="server" Value='<%# Eval("PeriviousStage")%>' />
                            <asp:HiddenField ID="hdnIsStyleSpecific" runat="server" Value='<%# Eval("IsStyleSpecific")%>' />
                            <asp:HiddenField ID="hdnStyleID" runat="server" Value='<%# Eval("StyleID")%>' />
                            <asp:HiddenField ID="hdnstage1" runat="server" Value='<%# Eval("Stage1")%>' />
                            <asp:HiddenField ID="hdnstage2" runat="server" Value='<%# Eval("Stage2")%>' />
                            <asp:HiddenField ID="hdnstage3" runat="server" Value='<%# Eval("Stage3")%>' />
                            <asp:HiddenField ID="hdnstage4" runat="server" Value='<%# Eval("Stage4")%>' />
                            <asp:HiddenField ID="hdnadjustmentqty" runat="server" Value='<%# Eval("adjustmentqty")%>' />
                            <asp:HiddenField ID="hdnPreviousadjustmentqty" runat="server" Value='<%# Eval("Previousadjustmentqty")%>' />
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td style="border: 0px !important">
                                        <asp:Label ID="lblcurrentstagetext" CssClass="" Text='<%# string.Concat("", " ", Eval("CurrentStage"))%>'
                                            runat="server"></asp:Label>
                                    </td>
                                    <td style="border: 0px !important">
                                        <asp:Label ID="lblperiviousstage" Text='<%# string.Concat("", " ", Eval("PreviousStageName"))%>'
                                            runat="server"></asp:Label>
                                    </td>
                                    <td style="border: 0px !important">
                                        <asp:Label ID="lblisstylespecific" CssClass="tooltip" Title="Currently this quality runing on style based due to VA included in some stages"
                                            Text='<%# string.Concat("", " ", Eval("IsStyleSpecificCaption"))%>' ForeColor="blue"
                                            runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Style No. (Serial No.)">
                        <ItemTemplate>
                            <asp:GridView ID="grdstylenumber" ShowHeader="false" runat="server" AutoGenerateColumns="False"
                                EmptyDataText="No Record Found!" Width="98%" HeaderStyle-Font-Names="Arial" HeaderStyle-HorizontalAlign="Center"
                                CssClass="grdDyedtable Griegetable" BorderWidth="0" rules="all" HeaderStyle-CssClass="ths">
                                <SelectedRowStyle BackColor="#A1DCF2" />
                                <RowStyle CssClass="DyedRowCount" />
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:HiddenField ID="hdnfabricQuality" runat="server" Value='<%# Eval("FabricQualityID")%>' />
                                            <asp:HiddenField ID="hdnStyleid" runat="server" Value='<%# Eval("StyleID")%>' />
                                            <asp:Label ID="lblStyleNumber" Text='<%# Eval("StyleNumber")%>' runat="server"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle CssClass="borderDy" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <%--  <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />:
                                    <asp:Label--%>
                                            <asp:Label ID="lblSerialNumber" Text='<%# "("+Eval("SerialNumber")+ ") "%>' runat="server"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle CssClass="borderDy" />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </ItemTemplate>
                        <ItemStyle Width="70px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Overall to order/send">
                        <ItemTemplate>
                            <asp:HiddenField ID="hdnfabprint" runat="server" Value='<%# Eval("FabricColor").ToString() %>' />
                            <table border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td style='border-bottom: 1px solid #e2dddd99'>
                                        <asp:Label ID="lblfabricQty" Style=""
                                            title="Click here to view wastage details & get reuired quantity" runat="server"></asp:Label>
                                        <asp:Label ID="lblcutwastgae" Style="display: none" runat="server"></asp:Label>


                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblrequiredqty" title="Click here to view wastage details & get reuired quantity"
                                            Style="color: blue; cursor: pointer;" CssClass="clfabqty" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </ItemTemplate>
                        <ItemStyle Width="70px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Greige" Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="lblGreige" CssClass="color_black" Visible="false" Text='<%# (Eval("GreigedShrinkage") == DBNull.Value  || (Eval("GreigedShrinkage").ToString().Trim() == string.Empty)) ? string.Empty : Eval("GreigedShrinkage").ToString().Trim() %>'
                                runat="server"></asp:Label>
                            <asp:TextBox ID="txtGreigeshrk" Enabled="false" CssClass="textboxAslabel" onchange="CalculateOnLoadDayed(1);"
                                onkeypress="return validateFloatKeyPress(this,event);" Style="width: 90% !important; text-align: center;"
                                runat="server" Text='<%# (Eval("GreigedShrinkage") == DBNull.Value  || (Eval("GreigedShrinkage").ToString().Trim() == string.Empty)) ? string.Empty : Eval("GreigedShrinkage").ToString().Trim() %>'></asp:TextBox>
                        </ItemTemplate>
                        <ItemStyle Width="50px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Residual" Visible="false">
                        <ItemTemplate>
                            <asp:TextBox ID="txtResidualShak" CssClass="textboxAslabel datesfileds lbls" onchange="CalculateOnLoadDayed(1);"
                                onkeypress="return validateFloatKeyPress(this,event);" Style="width: 90% !important; background: transparent !important; border: none !important; outline: none !important; padding: 0px 0px 0px 0px !important; text-align: center; outline: none;"
                                runat="server"
                                Text='<%# (Eval("ResidualShrinkage").ToString() == "0"  || (Eval("ResidualShrinkage").ToString().Trim() == string.Empty)) ? string.Empty : Eval("ResidualShrinkage").ToString().Trim() %>'></asp:TextBox>
                        </ItemTemplate>
                        <ItemStyle Width="50px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Balance In House">
                        <ItemTemplate>


                            <div class="AccessToltip">
                                <asp:Label ID="lblbalanceinhouseqty" Text='<%# (Eval("BalanceInHouse") == DBNull.Value  || (Eval("BalanceInHouse").ToString().Trim() == "0")) ? string.Empty : Eval("BalanceInHouse").ToString().Trim() %>'
                                    runat="server"></asp:Label>
                                <asp:Label ID="lblBalanceTooltip" runat="server" Text=""></asp:Label>

                            </div>

                        </ItemTemplate>
                        <ItemStyle Width="80px" />
                    </asp:TemplateField>
                    <asp:TemplateField Visible="false" HeaderText="Qty To Order">
                        <ItemTemplate>
                            <asp:Label ID="lbltotalqtytosend" runat="server"></asp:Label>
                            <asp:Label ID="lblFabQtyToOrder" Style="display: none;" runat="server"></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="80px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="perior">
                        <ItemTemplate>
                            <asp:Label ID="lblpriorstageQty" Text='<%# (Eval("PirorStageQty") == DBNull.Value  || (Eval("PirorStageQty").ToString().Trim() == string.Empty) || (Eval("PirorStageQty").ToString().Trim() == "0")) ? string.Empty : Convert.ToInt32(Eval("PirorStageQty")).ToString("N0") %>'
                                runat="server"></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="80px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Total Qty. To Send">
                        <ItemTemplate>
                            <asp:TextBox ID="txtqtytosend" Enabled="false" onchange="CalculateOnLoad();" onkeypress="return validateFloatKeyPress(this,event);"
                                Style="width: 90% !important; text-align: center;" runat="server"></asp:TextBox>
                        </ItemTemplate>
                        <ItemStyle Width="80px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Qoute1">
                        <ItemTemplate>
                            <asp:Label ID="lblQouteRate_1" runat="server"></asp:Label>
                            <asp:Label ID="lblQouteTime_1" runat="server"></asp:Label><br />
                            <asp:Label ID="lblQouteSupplierName_1" runat="server"></asp:Label><br />
                            <asp:Label ID="lblQouteLeadDays_1" runat="server"></asp:Label>
                        </ItemTemplate>
                        <ItemStyle CssClass="backColor1" Width="140px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Qoute2">
                        <ItemTemplate>
                            <asp:Label ID="lblQouteRate_2" runat="server"></asp:Label>
                            <asp:Label ID="lblQouteTime_2" runat="server"></asp:Label><br />
                            <asp:Label ID="lblQouteSupplierName_2" runat="server"></asp:Label><br />
                            <asp:Label ID="lblQouteLeadDays_2" runat="server"></asp:Label>
                        </ItemTemplate>
                        <ItemStyle CssClass="backColor2" Width="140px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Qoute3">
                        <ItemTemplate>
                            <asp:Label ID="lblQouteRate_3" runat="server"></asp:Label>
                            <asp:Label ID="lblQouteTime_3" runat="server"></asp:Label><br />
                            <asp:Label ID="lblQouteSupplierName_3" runat="server"></asp:Label><br />
                            <asp:Label ID="lblQouteLeadDays_3" runat="server"></asp:Label>
                        </ItemTemplate>
                        <ItemStyle CssClass="backColor2" Width="140px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="PO Numbaer">
                        <ItemTemplate>
                        </ItemTemplate>
                        <ItemStyle Width="50px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Supplier">
                        <ItemTemplate>
                        </ItemTemplate>
                        <ItemStyle Width="50px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Qty">
                        <ItemTemplate>
                        </ItemTemplate>
                        <ItemStyle Width="50px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Action">
                        <ItemTemplate>
                        </ItemTemplate>
                        <ItemStyle Width="50px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Pending Qty (To order)">
                        <ItemTemplate>
                            <table border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td style="min-width: 40px; text-align: right">
                                        <asp:Label ID="pendingQtyinorder" runat="server"></asp:Label>
                                    </td>
                                    <td style="min-width: 12px;">
                                        <a id="lnkProductionpopup" runat="server" style="font-size: 8px; position: relative; top: -2px">
                                            <img src="../../App_Themes/ikandi/images/zoom_icon1.gif" style="cursor: pointer;" /></a>
                                    </td>
                                    <td style="min-width: 40px;">
                                        <asp:Button ID="btnrapo" Style="display: none;" runat="server" Text="R.PO" />
                                        <div class="btnrpo tooltip" runat="server" id="divraise">
                                            R.PO
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </ItemTemplate>
                        <ItemStyle Width="100px" />
                    </asp:TemplateField>
                </Columns>
                <EmptyDataTemplate>
                    <table cellspacing="0" rules="all" class="greigegrd greigegrdbor nobordertd" border="0"
                        id="ctl00_cph_main_content_grdgayed" style="border-width: 0px; width: 100%; border-collapse: collapse;">
                        <tbody>
                            <tr class="HeaderClass">
                                <td align="center" style="min-width: 200px;">
                                    <table>
                                        <tbody>
                                            <tr>
                                                <td colspan="3" style="border: 0px;">Fabric Quality (GSM) C&amp;C Width<br>
                                                    Color/Print (Unit)</td>
                                            </tr>
                                            <tr>
                                                <td>Current Stage</td>
                                                <td>Previous Stage</td>
                                                <td>Style Specific</td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </td>
                                <td align="center" style="min-width: 150px;">Style No. (Serial No.)</td>
                                <td align="center" style="width: 60px;">
                                    <table>
                                        <tbody>
                                            <tr>
                                                <td style="border: 0px">Overall to order/send</td>
                                            </tr>
                                            <tr>
                                                <td>required qty</td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </td>
                                <td align="center" style="width: 40px;">Balance
                                    <br>
                                    In House </td>
                                <td align="center" style="width: 80px;">Total In House </td>
                                <td align="center" style="width: 80px;">Total Send </td>
                                <td align="center" style="width: 160px;">Quote 1 (Rate &amp; Time)<br>
                                    Supplier Name<br>
                                    Lead Time</td>
                                <td align="center" style="width: 160px;">Quote 2 (Rate &amp; Time)<br>
                                    Supplier Name<br>
                                    Lead Time</td>
                                <td align="center" style="width: 160px;">Quote 3 (Rate &amp; Time)<br>
                                    Supplier Name<br>
                                    Lead Time</td>
                                <td align="center" style="width: 80px;">PO Number</td>
                                <td align="center" style="min-width: 130px;">PO Supplier Name</td>
                                <td align="center" style="width: 60px;">Rcvd. Qty. </td>
                                <td align="center" class="widthAction">Revise PO</td>
                                <td align="center" class="widthPending">Qty. to Raise PO </td>
                            </tr>
                            <tr>
                                <td colspan="14" style="text-align: center; border: 0px;">
                                    <img src='../../images/sorry.png' alt='No record found' />
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </EmptyDataTemplate>
            </asp:GridView>

            <asp:GridView ID="grdprint" class="grdgayeds" ShowHeader="false"
                runat="server" AutoGenerateColumns="False" EmptyDataText="No Record Found!" Width="100%"
                HeaderStyle-Font-Names="Arial" CssClass="greigegrdbor" HeaderStyle-HorizontalAlign="Center"
                BorderWidth="0" rules="all" OnRowDataBound="grdprint_RowDataBound" HeaderStyle-CssClass="ths">
                <SelectedRowStyle BackColor="#A1DCF2" />
                <EditRowStyle CssClass="EmpltyTable" />
                <Columns>
                    <asp:TemplateField HeaderText="Fabric Quality (GSM) Width<br> Print/Color">
                        <ItemStyle Width="140px" CssClass="textLeft GriegeStageRe" />
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemTemplate>
                            <asp:Label ID="recqty" Style="display: none;" runat="server"></asp:Label>
                            <asp:HiddenField ID="hdnfabricQuality" runat="server" Value='<%# Eval("FabricQualityID")%>' />
                            <asp:Label ID="lblFabricQuality" ForeColor="blue" CssClass="color_black classfabsave"
                                Text='<%# Eval("FabricName")%>' runat="server"></asp:Label>
                            <asp:Label ID="lblgsm" CssClass="gray" Text='<%# "("+Eval("GSM")+ ") "%>' runat="server"></asp:Label>
                            <asp:Label ID="lblcountconstraction" CssClass="gray" Text='<%# Eval("CountConstruction").ToString()%>'
                                runat="server"></asp:Label>
                            <asp:Label ID="lblwidth" CssClass="gray" Text='<%# Eval("width").ToString()+"&quot" %>'
                                runat="server"></asp:Label><br />
                            <asp:Label ID="lblfabriccolor" CssClass="color_black" Font-Bold="true" ForeColor="black"
                                Text='<%# Eval("FabricColor").ToString() %>' runat="server"></asp:Label><br />
                            <asp:Label ID="lblcolor" Style="display: none" CssClass="color_black" runat="server"
                                Text='<%# Eval("FabricColor").ToString() %>'></asp:Label>
                            <%--added by raghvinder on 25-09-2020 start--%>
                            <asp:Label ID="lblUnit" CssClass="gray" Font-Bold="true" ForeColor="gray" runat="server" Text='<%# Eval("UnitName").ToString() == "" ? "" : Eval("UnitName")%>'></asp:Label>
                            <%--added by raghvinder on 25-09-2020 end--%>
                            <asp:HiddenField ID="hdnCurrentstage" runat="server" Value='<%# Eval("CurrentStage")%>' />
                            <asp:HiddenField ID="hdnperiviousstgae" runat="server" Value='<%# Eval("PeriviousStage")%>' />
                            <asp:HiddenField ID="hdnIsStyleSpecific" runat="server" Value='<%# Eval("IsStyleSpecific")%>' />
                            <asp:HiddenField ID="hdnStyleID" runat="server" Value='<%# Eval("StyleID")%>' />
                            <asp:HiddenField ID="hdnstage1" runat="server" Value='<%# Eval("Stage1")%>' />
                            <asp:HiddenField ID="hdnstage2" runat="server" Value='<%# Eval("Stage2")%>' />
                            <asp:HiddenField ID="hdnstage3" runat="server" Value='<%# Eval("Stage3")%>' />
                            <asp:HiddenField ID="hdnstage4" runat="server" Value='<%# Eval("Stage4")%>' />
                            <asp:HiddenField ID="hdnadjustmentqty" runat="server" Value='<%# Eval("adjustmentqty")%>' />
                            <asp:HiddenField ID="hdnPreviousadjustmentqty" runat="server" Value='<%# Eval("Previousadjustmentqty")%>' />
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td style="border: 0px !important">
                                        <asp:Label ID="lblcurrentstagetext" CssClass="" Text='<%# string.Concat("", " ", Eval("CurrentStage"))%>'
                                            runat="server"></asp:Label>
                                    </td>
                                    <td style="border: 0px !important">
                                        <asp:Label ID="lblperiviousstage" Text='<%# string.Concat("", " ", Eval("PreviousStageName"))%>'
                                            runat="server"></asp:Label>
                                    </td>
                                    <td style="border: 0px !important">
                                        <asp:Label ID="lblisstylespecific" CssClass="tooltip" Title="Currently this quality runing on style based due to VA included in some stages"
                                            Text='<%# string.Concat("", " ", Eval("IsStyleSpecificCaption"))%>' ForeColor="blue"
                                            runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Style No. (Serial No.)">
                        <ItemTemplate>
                            <asp:GridView ID="grdstylenumber" ShowHeader="false" runat="server" AutoGenerateColumns="False"
                                EmptyDataText="No Record Found!" Width="98%" HeaderStyle-Font-Names="Arial" HeaderStyle-HorizontalAlign="Center"
                                CssClass="Griegetable" BorderWidth="0" rules="all" HeaderStyle-CssClass="ths">
                                <RowStyle CssClass="PrintRowCount" />
                                <SelectedRowStyle BackColor="#A1DCF2" />
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:HiddenField ID="hdnfabricQuality" runat="server" Value='<%# Eval("FabricQualityID")%>' />
                                            <asp:HiddenField ID="hdnStyleid" runat="server" Value='<%# Eval("StyleID")%>' />
                                            <asp:Label ID="lblStyleNumber" Text='<%# Eval("StyleNumber")%>' runat="server"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle CssClass="borderDy" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <%-- <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />:<asp:Label--%>
                                            <asp:Label ID="lblSerialNumber" Text='<%# "("+Eval("SerialNumber")+ ") "%>' runat="server"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle CssClass="borderDy" />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </ItemTemplate>
                        <ItemStyle Width="70px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Overall to order/send">
                        <ItemTemplate>
                            <table border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td style='border-bottom: 1px solid #e2dddd99'>
                                        <asp:Label ID="lblfabricQty"
                                            title="Click here to view wastage details & get reuired quantity" runat="server"></asp:Label>
                                        <asp:Label ID="lblcutwastgae" Style="display: none" runat="server"></asp:Label>


                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblrequiredqty" title="Click here to view wastage details & get reuired quantity"
                                            Style="color: blue; cursor: pointer;" CssClass="clfabqty" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </ItemTemplate>
                        <ItemStyle Width="70px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Greige" Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="lblGreige" CssClass="color_black" Visible="false" Text='<%# (Eval("GreigedShrinkage") == DBNull.Value  || (Eval("GreigedShrinkage").ToString().Trim() == string.Empty)) ? string.Empty : Eval("GreigedShrinkage").ToString().Trim() %>'
                                runat="server"></asp:Label>
                            <asp:TextBox ID="txtGreigeshrk" Enabled="false" CssClass="textboxAslabel" onchange="CalculateOnLoadPrint(1);"
                                onkeypress="return validateFloatKeyPress(this,event);" Style="width: 90% !important; text-align: center;"
                                runat="server" Text='<%# (Eval("GreigedShrinkage") == DBNull.Value  || (Eval("GreigedShrinkage").ToString().Trim() == string.Empty)) ? string.Empty : Eval("GreigedShrinkage").ToString().Trim() %>'></asp:TextBox>
                        </ItemTemplate>
                        <ItemStyle Width="50px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Residual" Visible="false">
                        <ItemTemplate>
                            <asp:TextBox ID="txtResidualShak" CssClass="textboxAslabel datesfileds" onchange="CalculateOnLoadPrint(1);"
                                onkeypress="return validateFloatKeyPress(this,event);" Style="width: 90% !important; background: transparent !important; border: none !important; outline: none !important; padding: 0px 0px 0px 0px !important; text-align: center; outline: none;"
                                runat="server"
                                Text='<%# (Eval("ResidualShrinkage") == DBNull.Value  || (Eval("ResidualShrinkage").ToString().Trim() == string.Empty)) ? string.Empty : Eval("ResidualShrinkage").ToString().Trim() %>'></asp:TextBox>
                        </ItemTemplate>
                        <ItemStyle Width="50px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Balance In House">
                        <ItemTemplate>


                            <div class="AccessToltip">
                                <asp:Label ID="lblbalanceinhouseqty" Text='<%# (Eval("BalanceInHouse") == DBNull.Value  || (Eval("BalanceInHouse").ToString().Trim() == "0")) ? string.Empty : Eval("BalanceInHouse").ToString().Trim() %>'
                                    runat="server"></asp:Label>
                                <asp:Label ID="lblBalanceTooltip" runat="server" Text=""></asp:Label>
                            </div>

                        </ItemTemplate>
                        <ItemStyle Width="80px" />
                    </asp:TemplateField>
                    <asp:TemplateField Visible="false" HeaderText="Qty To Order">
                        <ItemTemplate>
                            <asp:Label ID="lbltotalqtytosend" Style="font-family: cursive;" CssClass="numbers"
                                runat="server"></asp:Label>
                            <asp:Label ID="lblFabQtyToOrder" Style="display: none;" runat="server"></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="80px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="perior">
                        <ItemTemplate>
                            <asp:Label ID="lblpriorstageQty" Text='<%# (Eval("PirorStageQty") == DBNull.Value  || (Eval("PirorStageQty").ToString().Trim() == string.Empty) || (Eval("PirorStageQty").ToString().Trim() == "0")) ? string.Empty : Convert.ToInt32(Eval("PirorStageQty")).ToString("N0") %>'
                                runat="server"></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="80px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Total Qty. To Send">
                        <ItemTemplate>
                            <asp:TextBox ID="txtqtytosend" Enabled="false" onchange="CalculateOnLoad();" onkeypress="return validateFloatKeyPress(this,event);"
                                Style="width: 90% !important; text-align: center;" runat="server"></asp:TextBox>
                        </ItemTemplate>
                        <ItemStyle Width="80px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Qoute1">
                        <ItemTemplate>
                            <asp:Label ID="lblQouteRate_1" runat="server"></asp:Label>
                            <asp:Label ID="lblQouteTime_1" runat="server"></asp:Label><br />
                            <asp:Label ID="lblQouteSupplierName_1" runat="server"></asp:Label><br />
                            <asp:Label ID="lblQouteLeadDays_1" runat="server"></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="140px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Qoute2">
                        <ItemTemplate>
                            <asp:Label ID="lblQouteRate_2" runat="server"></asp:Label>
                            <asp:Label ID="lblQouteTime_2" runat="server"></asp:Label><br />
                            <asp:Label ID="lblQouteSupplierName_2" runat="server"></asp:Label><br />
                            <asp:Label ID="lblQouteLeadDays_2" runat="server"></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="140px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Qoute3">
                        <ItemTemplate>
                            <asp:Label ID="lblQouteRate_3" runat="server"></asp:Label>
                            <asp:Label ID="lblQouteTime_3" runat="server"></asp:Label><br />
                            <asp:Label ID="lblQouteSupplierName_3" runat="server"></asp:Label><br />
                            <asp:Label ID="lblQouteLeadDays_3" runat="server"></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="140px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="PO Numbaer">
                        <ItemTemplate>
                        </ItemTemplate>
                        <ItemStyle Width="50px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Supplier">
                        <ItemTemplate>
                        </ItemTemplate>
                        <ItemStyle Width="50px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Qty">
                        <ItemTemplate>
                        </ItemTemplate>
                        <ItemStyle Width="50px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Action">
                        <ItemTemplate>
                        </ItemTemplate>
                        <ItemStyle Width="40px" HorizontalAlign="center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Pending Qty (To order)">
                        <ItemTemplate>
                            <table border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td style="min-width: 40px; text-align: right">
                                        <asp:Label ID="pendingQtyinorder" runat="server"></asp:Label>
                                    </td>
                                    <td style="min-width: 12px;">
                                        <a id="lnkProductionpopup" runat="server" style="font-size: 8px; position: relative; top: -2px">
                                            <img src="../../App_Themes/ikandi/images/zoom_icon1.gif" style="cursor: pointer;" /></a>
                                    </td>
                                    <td style="min-width: 40px;">
                                        <div class="btnrpo tooltip" runat="server" id="divraise">
                                            R.PO
                                        </div>
                                        <asp:Button ID="btnrapo" Style="display: none;" runat="server" Text="R.PO" />
                                    </td>
                                </tr>
                            </table>
                        </ItemTemplate>
                        <ItemStyle Width="100px" />
                    </asp:TemplateField>
                </Columns>
                <EmptyDataTemplate>
                    <table cellspacing="0" rules="all" class="greigegrd greigegrdbor nobordertd" border="0"
                        id="ctl00_cph_main_content_grdprint" style="border-width: 0px; width: 100%; border-collapse: collapse;">
                        <tbody>

                            <tr class="HeaderClass">
                                <td align="center" style="min-width: 200px;">
                                    <table>
                                        <tbody>
                                            <tr>
                                                <td colspan="3" style="border: 0px;">Fabric Quality (GSM) C&amp;C Width<br>
                                                    Color/Print (Unit)</td>
                                            </tr>
                                            <tr>
                                                <td>Current Stage</td>
                                                <td>Previous Stage</td>
                                                <td>Style Specific</td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </td>
                                <td align="center" style="min-width: 150px;">Style No. (Serial No.)</td>
                                <td align="center" style="width: 60px;">
                                    <table>
                                        <tbody>
                                            <tr>
                                                <td style="border: 0px">Overall to order/send</td>
                                            </tr>
                                            <tr>
                                                <td>required qty</td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </td>
                                <td align="center" style="width: 40px;">Balance
                                    <br>
                                    In House </td>
                                <td align="center" style="width: 80px;">Total In House </td>
                                <td align="center" style="width: 80px;">Total Send </td>
                                <td align="center" style="width: 160px;">Quote 1 (Rate &amp; Time)<br>
                                    Supplier Name<br>
                                    Lead Time</td>
                                <td align="center" style="width: 160px;">Quote 2 (Rate &amp; Time)<br>
                                    Supplier Name<br>
                                    Lead Time</td>
                                <td align="center" style="width: 160px;">Quote 3 (Rate &amp; Time)<br>
                                    Supplier Name<br>
                                    Lead Time</td>
                                <td align="center" style="width: 80px;">PO Number</td>
                                <td align="center" style="min-width: 130px;">PO Supplier Name</td>
                                <td align="center" style="width: 60px;">Rcvd. Qty. </td>
                                <td align="center" class="widthAction">Revise PO</td>
                                <td align="center" class="widthPending">Qty. to Raise PO </td>
                            </tr>

                            <tr>
                                <td colspan="14" style="text-align: center; border: 0px;">
                                    <img src='../../images/sorry.png' alt='No record found' />
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </EmptyDataTemplate>
            </asp:GridView>

            <asp:GridView ID="grdvalueadditionRFD" ShowHeader="false"
                runat="server" AutoGenerateColumns="False" EmptyDataText="No Record Found!" Width="100%"
                HeaderStyle-Font-Names="Arial" CssClass="greigegrdbor grdgayeds FabRFDTable"
                HeaderStyle-HorizontalAlign="Center" BorderWidth="0" rules="all" OnRowDataBound="grdvalueadditionRFD_RowDataBound"
                HeaderStyle-CssClass="ths">
                <SelectedRowStyle BackColor="#A1DCF2" />
                <EditRowStyle CssClass="EmpltyTable" />
                <Columns>
                    <asp:TemplateField HeaderText="Fabric Quality (GSM) Width<br> Print/Color">
                        <ItemStyle Width="140px" CssClass="textLeft GriegeStageRe" />
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemTemplate>
                            <asp:Label ID="recqty" Style="display: none;" runat="server"></asp:Label>
                            <asp:HiddenField ID="hdnfabricQuality" runat="server" Value='<%# Eval("FabricQualityID")%>' />
                            <asp:Label ID="lblFabricQuality" ForeColor="blue" CssClass="color_black classfabsave"
                                Text='<%# Eval("FabricName")%>' runat="server"></asp:Label>
                            <asp:Label ID="lblgsm" CssClass="gray" Text='<%# "("+Eval("GSM")+ ") "%>' runat="server"></asp:Label>
                            <asp:Label ID="lblcountconstraction" CssClass="gray" Text='<%# Eval("CountConstruction").ToString()%>'
                                runat="server"></asp:Label>
                            <asp:Label ID="lblwidth" CssClass="gray" Text='<%# Eval("width").ToString()+"&quot" %>'
                                runat="server"></asp:Label><br />
                            <asp:Label ID="lblfabriccolor" CssClass="color_black" Font-Bold="true" ForeColor="black"
                                runat="server"></asp:Label><br />
                            <asp:Label ID="lblcolor" CssClass="color_black" runat="server"></asp:Label>

                            <asp:Label ID="lblUnit" CssClass="gray" Font-Bold="true" ForeColor="gray" runat="server"
                                Text='<%# Eval("UnitName").ToString() == "" ? "" : Eval("UnitName")%>'></asp:Label>

                            <asp:HiddenField ID="hdnCurrentstage" runat="server" Value='<%# Eval("CurrentStage")%>' />
                            <asp:HiddenField ID="hdnperiviousstgae" runat="server" Value='<%# Eval("PeriviousStage")%>' />
                            <asp:HiddenField ID="hdnIsStyleSpecific" runat="server" Value='<%# Eval("IsStyleSpecific")%>' />
                            <asp:HiddenField ID="hdnStyleID" runat="server" Value='<%# Eval("StyleID")%>' />
                            <asp:HiddenField ID="hdnstage1" runat="server" Value='<%# Eval("Stage1")%>' />
                            <asp:HiddenField ID="hdnstage2" runat="server" Value='<%# Eval("Stage2")%>' />
                            <asp:HiddenField ID="hdnstage3" runat="server" Value='<%# Eval("Stage3")%>' />
                            <asp:HiddenField ID="hdnstage4" runat="server" Value='<%# Eval("Stage4")%>' />
                            <asp:HiddenField ID="hdnadjustmentqty" runat="server" Value='<%# Eval("adjustmentqty")%>' />
                            <asp:HiddenField ID="hdnPreviousadjustmentqty" runat="server" Value='<%# Eval("Previousadjustmentqty")%>' />

                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td style="border: 0px !important">
                                        <asp:Label ID="lblcurrentstagetext" CssClass="" Text='<%# string.Concat("", " ", Eval("CurrentStage"))%>'
                                            runat="server"></asp:Label>
                                    </td>
                                    <td style="border: 0px !important">
                                        <asp:Label ID="lblperiviousstage" Text='<%# string.Concat("", " ", Eval("PreviousStageName"))%>'
                                            runat="server"></asp:Label>
                                    </td>
                                    <td style="border: 0px !important">
                                        <asp:Label ID="lblisstylespecific" CssClass="tooltip" Title="Currently this quality runing on style based due to VA included in some stages"
                                            Text='<%# string.Concat("", " ", Eval("IsStyleSpecificCaption"))%>' ForeColor="blue"
                                            runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Style No. (Serial No.)">
                        <ItemTemplate>
                            <asp:GridView ID="grdstylenumber" ShowHeader="false" runat="server" AutoGenerateColumns="False"
                                EmptyDataText="No Record Found!" Width="98%" HeaderStyle-Font-Names="Arial" HeaderStyle-HorizontalAlign="Center"
                                CssClass="Griegetable" BorderWidth="0" rules="all" HeaderStyle-CssClass="ths">
                                <RowStyle CssClass="PrintRowCount" />
                                <SelectedRowStyle BackColor="#A1DCF2" />
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:HiddenField ID="hdnfabricQuality" runat="server" Value='<%# Eval("FabricQualityID")%>' />
                                            <asp:HiddenField ID="hdnStyleid" runat="server" Value='<%# Eval("StyleID")%>' />
                                            <asp:Label ID="lblStyleNumber" Text='<%# Eval("StyleNumber")%>' runat="server"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle CssClass="borderDy" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <%-- <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />:<asp:Label--%>
                                            <asp:Label ID="lblSerialNumber" Text='<%# "("+Eval("SerialNumber")+ ") "%>' runat="server"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle CssClass="borderDy" />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </ItemTemplate>
                        <ItemStyle Width="70px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Overall to order/send">
                        <ItemTemplate>
                            <table border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td style='border-bottom: 1px solid #e2dddd99'>
                                        <asp:Label ID="lblfabricQty"
                                            title="Click here to view wastage details & get reuired quantity" runat="server"></asp:Label>
                                        <asp:Label ID="lblcutwastgae" Style="display: none" runat="server"></asp:Label>


                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblrequiredqty" title="Click here to view wastage details & get reuired quantity"
                                            Style="color: blue; cursor: pointer;" CssClass="clfabqty" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </ItemTemplate>
                        <ItemStyle Width="70px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Greige" Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="lblGreige" CssClass="color_black" Visible="false" Text='<%# (Eval("GreigedShrinkage") == DBNull.Value  || (Eval("GreigedShrinkage").ToString().Trim() == string.Empty)) ? string.Empty : Eval("GreigedShrinkage").ToString().Trim() %>'
                                runat="server"></asp:Label>
                            <asp:TextBox ID="txtGreigeshrk" Enabled="false" CssClass="textboxAslabel" onchange="CalculateOnLoadPrint(1);"
                                onkeypress="return validateFloatKeyPress(this,event);" Style="width: 90% !important; text-align: center;"
                                runat="server" Text='<%# (Eval("GreigedShrinkage") == DBNull.Value  || (Eval("GreigedShrinkage").ToString().Trim() == string.Empty)) ? string.Empty : Eval("GreigedShrinkage").ToString().Trim() %>'></asp:TextBox>
                        </ItemTemplate>
                        <ItemStyle Width="50px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Residual" Visible="false">
                        <ItemTemplate>
                            <asp:TextBox ID="txtResidualShak" CssClass="textboxAslabel datesfileds" onchange="CalculateOnLoadPrint(1);"
                                onkeypress="return validateFloatKeyPress(this,event);" Style="width: 90% !important; background: transparent !important; border: none !important; outline: none !important; padding: 0px 0px 0px 0px !important; text-align: center; outline: none;"
                                runat="server"
                                Text='<%# (Eval("ResidualShrinkage") == DBNull.Value  || (Eval("ResidualShrinkage").ToString().Trim() == string.Empty)) ? string.Empty : Eval("ResidualShrinkage").ToString().Trim() %>'></asp:TextBox>
                        </ItemTemplate>
                        <ItemStyle Width="50px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Balance In House">
                        <ItemTemplate>


                            <div class="AccessToltip">
                                <asp:Label ID="lblbalanceinhouseqty" Text='<%# (Eval("BalanceInHouse") == DBNull.Value  || (Eval("BalanceInHouse").ToString().Trim() == "0")) ? string.Empty : Eval("BalanceInHouse").ToString().Trim() %>'
                                    runat="server"></asp:Label>
                                <asp:Label ID="lblBalanceTooltip" runat="server" Text=""></asp:Label>
                            </div>


                        </ItemTemplate>
                        <ItemStyle Width="80px" />
                    </asp:TemplateField>
                    <asp:TemplateField Visible="false" HeaderText="Qty To Order">
                        <ItemTemplate>
                            <asp:Label ID="lbltotalqtytosend" Style="font-family: cursive;" CssClass="numbers"
                                runat="server"></asp:Label>
                            <asp:Label ID="lblFabQtyToOrder" Style="display: none;" runat="server"></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="80px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="perior">
                        <ItemTemplate>
                            <asp:Label ID="lblpriorstageQty" Text='<%# (Eval("PirorStageQty") == DBNull.Value  || (Eval("PirorStageQty").ToString().Trim() == string.Empty) || (Eval("PirorStageQty").ToString().Trim() == "0")) ? string.Empty : Convert.ToInt32(Eval("PirorStageQty")).ToString("N0") %>'
                                runat="server"></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="80px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Total Qty. To Send">
                        <ItemTemplate>
                            <asp:TextBox ID="txtqtytosend" Enabled="false" onchange="CalculateOnLoad();" onkeypress="return validateFloatKeyPress(this,event);"
                                Style="width: 90% !important; text-align: center;" runat="server"></asp:TextBox>
                        </ItemTemplate>
                        <ItemStyle Width="80px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Qoute1">
                        <ItemTemplate>
                            <asp:Label ID="lblQouteRate_1" runat="server"></asp:Label>
                            <asp:Label ID="lblQouteTime_1" runat="server"></asp:Label><br />
                            <asp:Label ID="lblQouteSupplierName_1" runat="server"></asp:Label><br />
                            <asp:Label ID="lblQouteLeadDays_1" runat="server"></asp:Label>
                        </ItemTemplate>
                        <ItemStyle CssClass="backColor1" Width="140px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Qoute2">
                        <ItemTemplate>
                            <asp:Label ID="lblQouteRate_2" runat="server"></asp:Label>
                            <asp:Label ID="lblQouteTime_2" runat="server"></asp:Label><br />
                            <asp:Label ID="lblQouteSupplierName_2" runat="server"></asp:Label><br />
                            <asp:Label ID="lblQouteLeadDays_2" runat="server"></asp:Label>
                        </ItemTemplate>
                        <ItemStyle CssClass="backColor2" Width="140px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Qoute3">
                        <ItemTemplate>
                            <asp:Label ID="lblQouteRate_3" runat="server"></asp:Label>
                            <asp:Label ID="lblQouteTime_3" runat="server"></asp:Label><br />
                            <asp:Label ID="lblQouteSupplierName_3" runat="server"></asp:Label><br />
                            <asp:Label ID="lblQouteLeadDays_3" runat="server"></asp:Label>
                        </ItemTemplate>
                        <ItemStyle CssClass="backColor3" Width="140px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="PO Numbaer">
                        <ItemTemplate>
                        </ItemTemplate>
                        <ItemStyle Width="50px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Supplier">
                        <ItemTemplate>
                        </ItemTemplate>
                        <ItemStyle Width="50px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Qty">
                        <ItemTemplate>
                        </ItemTemplate>
                        <ItemStyle Width="50px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Action">
                        <ItemTemplate>
                        </ItemTemplate>
                        <ItemStyle Width="40px" HorizontalAlign="center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Pending Qty (To order)">
                        <ItemTemplate>
                            <table border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td style="min-width: 40px; text-align: right">
                                        <asp:Label ID="pendingQtyinorder" runat="server"></asp:Label>
                                    </td>
                                    <td style="min-width: 12px;">
                                        <a id="lnkProductionpopup" runat="server" style="font-size: 8px; position: relative; top: -2px">
                                            <img src="../../App_Themes/ikandi/images/zoom_icon1.gif" style="cursor: pointer;" /></a>
                                    </td>
                                    <td style="min-width: 40px;">
                                        <div class="btnrpo tooltip" runat="server" id="divraise">
                                            R.PO
                                        </div>
                                        <asp:Button ID="btnrapo" Style="display: none;" runat="server" Text="R.PO" />
                                    </td>
                                </tr>
                            </table>
                        </ItemTemplate>
                        <ItemStyle Width="100px" />
                    </asp:TemplateField>
                </Columns>
                <EmptyDataTemplate>
                    <table cellspacing="0" rules="all" class="greigegrd greigegrdbor nobordertd" border="0"
                        id="ctl00_cph_main_content_grdprint" style="border-width: 0px; width: 100%; border-collapse: collapse;">
                        <tbody>

                            <tr class="HeaderClass">
                                <td align="center" style="min-width: 200px;">
                                    <table>
                                        <tbody>
                                            <tr>
                                                <td colspan="3" style="border: 0px;">Fabric Quality (GSM) C&amp;C Width<br>
                                                    Color/Print (Unit)</td>
                                            </tr>
                                            <tr>
                                                <td>Current Stage</td>
                                                <td>Previous Stage</td>
                                                <td>Style Specific</td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </td>
                                <td align="center" style="min-width: 150px;">Style No. (Serial No.)</td>
                                <td align="center" style="width: 60px;">
                                    <table>
                                        <tbody>
                                            <tr>
                                                <td style="border: 0px">Overall to order/send</td>
                                            </tr>
                                            <tr>
                                                <td>required qty</td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </td>
                                <td align="center" style="width: 40px;">Balance
                                    <br>
                                    In House </td>
                                <td align="center" style="width: 80px;">Total In House </td>
                                <td align="center" style="width: 80px;">Total Send </td>
                                <td align="center" style="width: 160px;">Quote 1 (Rate &amp; Time)<br>
                                    Supplier Name<br>
                                    Lead Time</td>
                                <td align="center" style="width: 160px;">Quote 2 (Rate &amp; Time)<br>
                                    Supplier Name<br>
                                    Lead Time</td>
                                <td align="center" style="width: 160px;">Quote 3 (Rate &amp; Time)<br>
                                    Supplier Name<br>
                                    Lead Time</td>
                                <td align="center" style="width: 80px;">PO Number</td>
                                <td align="center" style="min-width: 130px;">PO Supplier Name</td>
                                <td align="center" style="width: 60px;">Rcvd. Qty. </td>
                                <td align="center" class="widthAction">Revise PO</td>
                                <td align="center" class="widthPending">Qty. to Raise PO </td>
                            </tr>
                            <tr>
                                <td colspan="14" style="text-align: center; border: 0px;">
                                    <img src='../../images/sorry.png' alt='No record found' />
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </EmptyDataTemplate>
            </asp:GridView>

            <asp:GridView ID="grdEmbellishment" class="grdgayeds" ShowHeader="false"
                runat="server" AutoGenerateColumns="False" EmptyDataText="No Record Found!" Width="100%"
                HeaderStyle-Font-Names="Arial" CssClass="greigegrdbor" HeaderStyle-HorizontalAlign="Center"
                BorderWidth="0" rules="all" OnRowDataBound="grdEmbellishment_RowDataBound" HeaderStyle-CssClass="ths">
                <SelectedRowStyle BackColor="#A1DCF2" />
                <EditRowStyle CssClass="EmpltyTable" />
                <Columns>
                    <asp:TemplateField HeaderText="Fabric Quality (GSM) Width<br> Print/Color">
                        <ItemStyle Width="140px" CssClass="textLeft GriegeStageRe" />
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemTemplate>
                            <asp:Label ID="recqty" Style="display: none;" runat="server"></asp:Label>
                            <asp:HiddenField ID="hdnfabricQuality" runat="server" Value='<%# Eval("FabricQualityID")%>' />
                            <asp:Label ID="lblFabricQuality" ForeColor="blue" CssClass="color_black classfabsave"
                                Text='<%# Eval("FabricName")%>' runat="server"></asp:Label>
                            <asp:Label ID="lblgsm" CssClass="gray" Text='<%# "("+Eval("GSM")+ ") "%>' runat="server"></asp:Label>
                            <asp:Label ID="lblcountconstraction" CssClass="gray" Text='<%# Eval("CountConstruction").ToString()%>'
                                runat="server"></asp:Label>
                            <asp:Label ID="lblwidth" CssClass="gray" Text='<%# Eval("width").ToString()+"&quot" %>'
                                runat="server"></asp:Label><br />
                            <asp:Label ID="lblfabriccolor" CssClass="color_black" Font-Bold="true" ForeColor="black"
                                Text='<%# Eval("FabricColor").ToString() %>' runat="server"></asp:Label><br />
                            <asp:Label ID="lblcolor" Style="display: none" CssClass="color_black" runat="server"
                                Text='<%# Eval("FabricColor").ToString() %>'></asp:Label>
                            <%--added by raghvinder on 25-09-2020 start--%>
                            <asp:Label ID="lblUnit" CssClass="gray" Font-Bold="true" ForeColor="gray" runat="server"
                                Text='<%# Eval("UnitName").ToString() == "" ? "" : Eval("UnitName")%>'></asp:Label>
                            <%--added by raghvinder on 25-09-2020 end--%>
                            <asp:HiddenField ID="hdnCurrentstage" runat="server" Value='<%# Eval("CurrentStage")%>' />
                            <asp:HiddenField ID="hdnperiviousstgae" runat="server" Value='<%# Eval("PeriviousStage")%>' />
                            <asp:HiddenField ID="hdnIsStyleSpecific" runat="server" Value='<%# Eval("IsStyleSpecific")%>' />
                            <asp:HiddenField ID="hdnStyleID" runat="server" Value='<%# Eval("StyleID")%>' />
                            <asp:HiddenField ID="hdnstage1" runat="server" Value='<%# Eval("Stage1")%>' />
                            <asp:HiddenField ID="hdnstage2" runat="server" Value='<%# Eval("Stage2")%>' />
                            <asp:HiddenField ID="hdnstage3" runat="server" Value='<%# Eval("Stage3")%>' />
                            <asp:HiddenField ID="hdnstage4" runat="server" Value='<%# Eval("Stage4")%>' />
                            <asp:HiddenField ID="hdnadjustmentqty" runat="server" Value='<%# Eval("adjustmentqty")%>' />
                            <asp:HiddenField ID="hdnPreviousadjustmentqty" runat="server" Value='<%# Eval("Previousadjustmentqty")%>' />
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td style="border: 0px !important">
                                        <asp:Label ID="lblcurrentstagetext" CssClass="" Text='<%# string.Concat("", " ", Eval("CurrentStage"))%>'
                                            runat="server"></asp:Label>
                                    </td>
                                    <td style="border: 0px !important">
                                        <asp:Label ID="lblperiviousstage" Text='<%# string.Concat("", " ", Eval("PreviousStageName"))%>'
                                            runat="server"></asp:Label>
                                    </td>
                                    <td style="border: 0px !important">
                                        <asp:Label ID="lblisstylespecific" CssClass="tooltip" Title="Currently this quality runing on style based due to VA included in some stages"
                                            Text='<%# string.Concat("", " ", Eval("IsStyleSpecificCaption"))%>' ForeColor="blue"
                                            runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Style No. (Serial No.)">
                        <ItemTemplate>
                            <asp:GridView ID="grdstylenumber" ShowHeader="false" runat="server" AutoGenerateColumns="False"
                                EmptyDataText="No Record Found!" Width="98%" HeaderStyle-Font-Names="Arial" HeaderStyle-HorizontalAlign="Center"
                                CssClass="Griegetable" BorderWidth="0" rules="all" HeaderStyle-CssClass="ths">
                                <RowStyle CssClass="PrintRowCount" />
                                <SelectedRowStyle BackColor="#A1DCF2" />
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:HiddenField ID="hdnfabricQuality" runat="server" Value='<%# Eval("FabricQualityID")%>' />
                                            <asp:HiddenField ID="hdnStyleid" runat="server" Value='<%# Eval("StyleID")%>' />
                                            <asp:Label ID="lblStyleNumber" Text='<%# Eval("StyleNumber")%>' runat="server"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle CssClass="borderDy" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <%-- <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />:<asp:Label--%>
                                            <asp:Label ID="lblSerialNumber" Text='<%# "("+Eval("SerialNumber")+ ") "%>' runat="server"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle CssClass="borderDy" />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </ItemTemplate>
                        <ItemStyle Width="70px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Overall to order/send">
                        <ItemTemplate>
                            <table border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td style='border-bottom: 1px solid #e2dddd99'>
                                        <asp:Label ID="lblfabricQty"
                                            title="Click here to view wastage details & get reuired quantity" runat="server"></asp:Label>
                                        <asp:Label ID="lblcutwastgae" Style="display: none" runat="server"></asp:Label>


                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblrequiredqty" title="Click here to view wastage details & get reuired quantity"
                                            Style="color: blue; cursor: pointer;" CssClass="clfabqty" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </ItemTemplate>
                        <ItemStyle Width="70px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Greige" Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="lblGreige" CssClass="color_black" Visible="false" Text='<%# (Eval("GreigedShrinkage") == DBNull.Value  || (Eval("GreigedShrinkage").ToString().Trim() == string.Empty)) ? string.Empty : Eval("GreigedShrinkage").ToString().Trim() %>'
                                runat="server"></asp:Label>
                            <asp:TextBox ID="txtGreigeshrk" Enabled="false" CssClass="textboxAslabel" onchange="CalculateOnLoadPrint(1);"
                                onkeypress="return validateFloatKeyPress(this,event);" Style="width: 90% !important; text-align: center;"
                                runat="server" Text='<%# (Eval("GreigedShrinkage") == DBNull.Value  || (Eval("GreigedShrinkage").ToString().Trim() == string.Empty)) ? string.Empty : Eval("GreigedShrinkage").ToString().Trim() %>'></asp:TextBox>
                        </ItemTemplate>
                        <ItemStyle Width="50px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Residual" Visible="false">
                        <ItemTemplate>
                            <asp:TextBox ID="txtResidualShak" CssClass="textboxAslabel datesfileds" onchange="CalculateOnLoadPrint(1);"
                                onkeypress="return validateFloatKeyPress(this,event);" Style="width: 90% !important; background: transparent !important; border: none !important; outline: none !important; padding: 0px 0px 0px 0px !important; text-align: center; outline: none;"
                                runat="server"
                                Text='<%# (Eval("ResidualShrinkage") == DBNull.Value  || (Eval("ResidualShrinkage").ToString().Trim() == string.Empty)) ? string.Empty : Eval("ResidualShrinkage").ToString().Trim() %>'></asp:TextBox>
                        </ItemTemplate>
                        <ItemStyle Width="50px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Balance In House">
                        <ItemTemplate>


                            <div class="AccessToltip">
                                <asp:Label ID="lblbalanceinhouseqty" Text='<%# (Eval("BalanceInHouse") == DBNull.Value  || (Eval("BalanceInHouse").ToString().Trim() == "0")) ? string.Empty : Eval("BalanceInHouse").ToString().Trim() %>'
                                    runat="server"></asp:Label>
                                <asp:Label ID="lblBalanceTooltip" runat="server" Text=""></asp:Label>
                            </div>

                        </ItemTemplate>
                        <ItemStyle Width="80px" />
                    </asp:TemplateField>
                    <asp:TemplateField Visible="false" HeaderText="Qty To Order">
                        <ItemTemplate>
                            <asp:Label ID="lbltotalqtytosend" Style="font-family: cursive;" CssClass="numbers"
                                runat="server"></asp:Label>
                            <asp:Label ID="lblFabQtyToOrder" Style="display: none;" runat="server"></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="80px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="perior">
                        <ItemTemplate>
                            <asp:Label ID="lblpriorstageQty" Text='<%# (Eval("PirorStageQty") == DBNull.Value  || (Eval("PirorStageQty").ToString().Trim() == string.Empty) || (Eval("PirorStageQty").ToString().Trim() == "0")) ? string.Empty : Convert.ToInt32(Eval("PirorStageQty")).ToString("N0") %>'
                                runat="server"></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="80px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Total Qty. To Send">
                        <ItemTemplate>
                            <asp:TextBox ID="txtqtytosend" Enabled="false" onchange="CalculateOnLoad();" onkeypress="return validateFloatKeyPress(this,event);"
                                Style="width: 90% !important; text-align: center;" runat="server"></asp:TextBox>
                        </ItemTemplate>
                        <ItemStyle Width="80px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Qoute1">
                        <ItemTemplate>
                            <asp:Label ID="lblQouteRate_1" runat="server"></asp:Label>
                            <asp:Label ID="lblQouteTime_1" runat="server"></asp:Label><br />
                            <asp:Label ID="lblQouteSupplierName_1" runat="server"></asp:Label><br />
                            <asp:Label ID="lblQouteLeadDays_1" runat="server"></asp:Label>
                        </ItemTemplate>
                        <ItemStyle CssClass="backColor1" Width="140px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Qoute2">
                        <ItemTemplate>
                            <asp:Label ID="lblQouteRate_2" runat="server"></asp:Label>
                            <asp:Label ID="lblQouteTime_2" runat="server"></asp:Label><br />
                            <asp:Label ID="lblQouteSupplierName_2" runat="server"></asp:Label><br />
                            <asp:Label ID="lblQouteLeadDays_2" runat="server"></asp:Label>
                        </ItemTemplate>
                        <ItemStyle CssClass="backColor2" Width="140px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Qoute3">
                        <ItemTemplate>
                            <asp:Label ID="lblQouteRate_3" runat="server"></asp:Label>
                            <asp:Label ID="lblQouteTime_3" runat="server"></asp:Label><br />
                            <asp:Label ID="lblQouteSupplierName_3" runat="server"></asp:Label><br />
                            <asp:Label ID="lblQouteLeadDays_3" runat="server"></asp:Label>
                        </ItemTemplate>
                        <ItemStyle CssClass="backColor3" Width="140px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="PO Numbaer">
                        <ItemTemplate>
                        </ItemTemplate>
                        <ItemStyle Width="50px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Supplier">
                        <ItemTemplate>
                        </ItemTemplate>
                        <ItemStyle Width="50px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Qty">
                        <ItemTemplate>
                        </ItemTemplate>
                        <ItemStyle Width="50px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Action">
                        <ItemTemplate>
                        </ItemTemplate>
                        <ItemStyle Width="40px" HorizontalAlign="center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Pending Qty (To order)">
                        <ItemTemplate>
                            <table border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td style="min-width: 40px; text-align: right">
                                        <asp:Label ID="pendingQtyinorder" runat="server"></asp:Label>
                                    </td>
                                    <td style="min-width: 12px;">
                                        <a id="lnkProductionpopup" runat="server" style="font-size: 8px; position: relative; top: -2px">
                                            <img src="../../App_Themes/ikandi/images/zoom_icon1.gif" style="cursor: pointer;" /></a>
                                    </td>
                                    <td style="min-width: 40px;">
                                        <div class="btnrpo tooltip" runat="server" id="divraise">
                                            R.PO
                                        </div>
                                        <asp:Button ID="btnrapo" Style="display: none;" runat="server" Text="R.PO" />
                                    </td>
                                </tr>
                            </table>
                        </ItemTemplate>
                        <ItemStyle Width="100px" />
                    </asp:TemplateField>
                </Columns>
                <EmptyDataTemplate>
                    <table cellspacing="0" rules="all" class="greigegrd greigegrdbor nobordertd" border="0"
                        id="ctl00_cph_main_content_grdprint" style="border-width: 0px; width: 100%; border-collapse: collapse;">
                        <tbody>

                            <tr class="HeaderClass">
                                <td align="center" style="min-width: 200px;">
                                    <table>
                                        <tbody>
                                            <tr>
                                                <td colspan="3" style="border: 0px;">Fabric Quality (GSM) C&amp;C Width<br>
                                                    Color/Print (Unit)</td>
                                            </tr>
                                            <tr>
                                                <td>Current Stage</td>
                                                <td>Previous Stage</td>
                                                <td>Style Specific</td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </td>
                                <td align="center" style="min-width: 150px;">Style No. (Serial No.)</td>
                                <td align="center" style="width: 60px;">
                                    <table>
                                        <tbody>
                                            <tr>
                                                <td style="border: 0px">Overall to order/send</td>
                                            </tr>
                                            <tr>
                                                <td>required qty</td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </td>
                                <td align="center" style="width: 40px;">Balance
                                    <br>
                                    In House </td>
                                <td align="center" style="width: 80px;">Total In House </td>
                                <td align="center" style="width: 80px;">Total Send </td>
                                <td align="center" style="width: 160px;">Quote 1 (Rate &amp; Time)<br>
                                    Supplier Name<br>
                                    Lead Time</td>
                                <td align="center" style="width: 160px;">Quote 2 (Rate &amp; Time)<br>
                                    Supplier Name<br>
                                    Lead Time</td>
                                <td align="center" style="width: 160px;">Quote 3 (Rate &amp; Time)<br>
                                    Supplier Name<br>
                                    Lead Time</td>
                                <td align="center" style="width: 80px;">PO Number</td>
                                <td align="center" style="min-width: 130px;">PO Supplier Name</td>
                                <td align="center" style="width: 60px;">Rcvd. Qty. </td>
                                <td align="center" class="widthAction">Revise PO</td>
                                <td align="center" class="widthPending">Qty. to Raise PO </td>
                            </tr>
                            <tr>
                                <td colspan="14" style="text-align: center; border: 0px;">
                                    <img src='../../images/sorry.png' alt='No record found' />
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </EmptyDataTemplate>
            </asp:GridView>

            <asp:GridView ID="grdEmbroidery" class="grdgayeds" ShowHeader="false"
                runat="server" AutoGenerateColumns="False" EmptyDataText="No Record Found!" Width="100%"
                HeaderStyle-Font-Names="Arial" CssClass="greigegrdbor" HeaderStyle-HorizontalAlign="Center"
                BorderWidth="0" rules="all" OnRowDataBound="grdEmbroidery_RowDataBound" HeaderStyle-CssClass="ths">
                <SelectedRowStyle BackColor="#A1DCF2" />
                <EditRowStyle CssClass="EmpltyTable" />
                <Columns>
                    <asp:TemplateField HeaderText="Fabric Quality (GSM) Width<br> Print/Color">
                        <ItemStyle Width="140px" CssClass="textLeft GriegeStageRe" />
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemTemplate>
                            <asp:Label ID="recqty" Style="display: none;" runat="server"></asp:Label>
                            <asp:HiddenField ID="hdnfabricQuality" runat="server" Value='<%# Eval("FabricQualityID")%>' />
                            <asp:Label ID="lblFabricQuality" ForeColor="blue" CssClass="color_black classfabsave"
                                Text='<%# Eval("FabricName")%>' runat="server"></asp:Label>
                            <asp:Label ID="lblgsm" CssClass="gray" Text='<%# "("+Eval("GSM")+ ") "%>' runat="server"></asp:Label>
                            <asp:Label ID="lblcountconstraction" CssClass="gray" Text='<%# Eval("CountConstruction").ToString()%>'
                                runat="server"></asp:Label>
                            <asp:Label ID="lblwidth" CssClass="gray" Text='<%# Eval("width").ToString()+"&quot" %>'
                                runat="server"></asp:Label><br />
                            <asp:Label ID="lblfabriccolor" CssClass="color_black" Font-Bold="true" ForeColor="black"
                                Text='<%# Eval("FabricColor").ToString() %>' runat="server"></asp:Label><br />
                            <asp:Label ID="lblcolor" Style="display: none" CssClass="color_black" runat="server"
                                Text='<%# Eval("FabricColor").ToString() %>'></asp:Label>
                            <%--added by raghvinder on 25-09-2020 start--%>
                            <asp:Label ID="lblUnit" CssClass="gray" Font-Bold="true" ForeColor="gray" runat="server"
                                Text='<%# Eval("UnitName").ToString() == "" ? "" : Eval("UnitName")%>'></asp:Label>
                            <%--added by raghvinder on 25-09-2020 end--%>
                            <asp:HiddenField ID="hdnCurrentstage" runat="server" Value='<%# Eval("CurrentStage")%>' />
                            <asp:HiddenField ID="hdnperiviousstgae" runat="server" Value='<%# Eval("PeriviousStage")%>' />
                            <asp:HiddenField ID="hdnIsStyleSpecific" runat="server" Value='<%# Eval("IsStyleSpecific")%>' />
                            <asp:HiddenField ID="hdnStyleID" runat="server" Value='<%# Eval("StyleID")%>' />
                            <asp:HiddenField ID="hdnstage1" runat="server" Value='<%# Eval("Stage1")%>' />
                            <asp:HiddenField ID="hdnstage2" runat="server" Value='<%# Eval("Stage2")%>' />
                            <asp:HiddenField ID="hdnstage3" runat="server" Value='<%# Eval("Stage3")%>' />
                            <asp:HiddenField ID="hdnstage4" runat="server" Value='<%# Eval("Stage4")%>' />
                            <asp:HiddenField ID="hdnadjustmentqty" runat="server" Value='<%# Eval("adjustmentqty")%>' />
                            <asp:HiddenField ID="hdnPreviousadjustmentqty" runat="server" Value='<%# Eval("Previousadjustmentqty")%>' />
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td style="border: 0px !important">
                                        <asp:Label ID="lblcurrentstagetext" CssClass="" Text='<%# string.Concat("", " ", Eval("CurrentStage"))%>'
                                            runat="server"></asp:Label>
                                    </td>
                                    <td style="border: 0px !important">
                                        <asp:Label ID="lblperiviousstage" Text='<%# string.Concat("", " ", Eval("PreviousStageName"))%>'
                                            runat="server"></asp:Label>
                                    </td>
                                    <td style="border: 0px !important">
                                        <asp:Label ID="lblisstylespecific" CssClass="tooltip" Title="Currently this quality runing on style based due to VA included in some stages"
                                            Text='<%# string.Concat("", " ", Eval("IsStyleSpecificCaption"))%>' ForeColor="blue"
                                            runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Style No. (Serial No.)">
                        <ItemTemplate>
                            <asp:GridView ID="grdstylenumber" ShowHeader="false" runat="server" AutoGenerateColumns="False"
                                EmptyDataText="No Record Found!" Width="98%" HeaderStyle-Font-Names="Arial" HeaderStyle-HorizontalAlign="Center"
                                CssClass="Griegetable" BorderWidth="0" rules="all" HeaderStyle-CssClass="ths">
                                <RowStyle CssClass="PrintRowCount" />
                                <SelectedRowStyle BackColor="#A1DCF2" />
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:HiddenField ID="hdnfabricQuality" runat="server" Value='<%# Eval("FabricQualityID")%>' />
                                            <asp:HiddenField ID="hdnStyleid" runat="server" Value='<%# Eval("StyleID")%>' />
                                            <asp:Label ID="lblStyleNumber" Text='<%# Eval("StyleNumber")%>' runat="server"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle CssClass="borderDy" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <%-- <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />:<asp:Label--%>
                                            <asp:Label ID="lblSerialNumber" Text='<%# "("+Eval("SerialNumber")+ ") "%>' runat="server"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle CssClass="borderDy" />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </ItemTemplate>
                        <ItemStyle Width="70px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Overall to order/send">
                        <ItemTemplate>
                            <table border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td style='border-bottom: 1px solid #e2dddd99'>
                                        <asp:Label ID="lblfabricQty"
                                            title="Click here to view wastage details & get reuired quantity" runat="server"></asp:Label>
                                        <asp:Label ID="lblcutwastgae" Style="display: none" runat="server"></asp:Label>


                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblrequiredqty" title="Click here to view wastage details & get reuired quantity"
                                            Style="color: blue; cursor: pointer;" CssClass="clfabqty" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </ItemTemplate>
                        <ItemStyle Width="70px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Greige" Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="lblGreige" CssClass="color_black" Visible="false" Text='<%# (Eval("GreigedShrinkage") == DBNull.Value  || (Eval("GreigedShrinkage").ToString().Trim() == string.Empty)) ? string.Empty : Eval("GreigedShrinkage").ToString().Trim() %>'
                                runat="server"></asp:Label>
                            <asp:TextBox ID="txtGreigeshrk" Enabled="false" CssClass="textboxAslabel" onchange="CalculateOnLoadPrint(1);"
                                onkeypress="return validateFloatKeyPress(this,event);" Style="width: 90% !important; text-align: center;"
                                runat="server" Text='<%# (Eval("GreigedShrinkage") == DBNull.Value  || (Eval("GreigedShrinkage").ToString().Trim() == string.Empty)) ? string.Empty : Eval("GreigedShrinkage").ToString().Trim() %>'></asp:TextBox>
                        </ItemTemplate>
                        <ItemStyle Width="50px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Residual" Visible="false">
                        <ItemTemplate>
                            <asp:TextBox ID="txtResidualShak" CssClass="textboxAslabel datesfileds" onchange="CalculateOnLoadPrint(1);"
                                onkeypress="return validateFloatKeyPress(this,event);" Style="width: 90% !important; background: transparent !important; border: none !important; outline: none !important; padding: 0px 0px 0px 0px !important; text-align: center; outline: none;"
                                runat="server"
                                Text='<%# (Eval("ResidualShrinkage") == DBNull.Value  || (Eval("ResidualShrinkage").ToString().Trim() == string.Empty)) ? string.Empty : Eval("ResidualShrinkage").ToString().Trim() %>'></asp:TextBox>
                        </ItemTemplate>
                        <ItemStyle Width="50px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Balance In House">
                        <ItemTemplate>


                            <div class="AccessToltip">
                                <asp:Label ID="lblbalanceinhouseqty" Text='<%# (Eval("BalanceInHouse") == DBNull.Value  || (Eval("BalanceInHouse").ToString().Trim() == "0")) ? string.Empty : Eval("BalanceInHouse").ToString().Trim() %>'
                                    runat="server"></asp:Label>
                                <asp:Label ID="lblBalanceTooltip" runat="server" Text=""></asp:Label>
                            </div>

                        </ItemTemplate>
                        <ItemStyle Width="80px" />
                    </asp:TemplateField>
                    <asp:TemplateField Visible="false" HeaderText="Qty To Order">
                        <ItemTemplate>
                            <asp:Label ID="lbltotalqtytosend" Style="font-family: cursive;" CssClass="numbers"
                                runat="server"></asp:Label>
                            <asp:Label ID="lblFabQtyToOrder" Style="display: none;" runat="server"></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="80px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="perior">
                        <ItemTemplate>
                            <asp:Label ID="lblpriorstageQty" Text='<%# (Eval("PirorStageQty") == DBNull.Value  || (Eval("PirorStageQty").ToString().Trim() == string.Empty) || (Eval("PirorStageQty").ToString().Trim() == "0")) ? string.Empty : Convert.ToInt32(Eval("PirorStageQty")).ToString("N0") %>'
                                runat="server"></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="80px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Total Qty. To Send">
                        <ItemTemplate>
                            <asp:TextBox ID="txtqtytosend" Enabled="false" onchange="CalculateOnLoad();" onkeypress="return validateFloatKeyPress(this,event);"
                                Style="width: 90% !important; text-align: center;" runat="server"></asp:TextBox>
                        </ItemTemplate>
                        <ItemStyle Width="80px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Qoute1">
                        <ItemTemplate>
                            <asp:Label ID="lblQouteRate_1" runat="server"></asp:Label>
                            <asp:Label ID="lblQouteTime_1" runat="server"></asp:Label><br />
                            <asp:Label ID="lblQouteSupplierName_1" runat="server"></asp:Label><br />
                            <asp:Label ID="lblQouteLeadDays_1" runat="server"></asp:Label>
                        </ItemTemplate>
                        <ItemStyle CssClass="backColor1" Width="140px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Qoute2">
                        <ItemTemplate>
                            <asp:Label ID="lblQouteRate_2" runat="server"></asp:Label>
                            <asp:Label ID="lblQouteTime_2" runat="server"></asp:Label><br />
                            <asp:Label ID="lblQouteSupplierName_2" runat="server"></asp:Label><br />
                            <asp:Label ID="lblQouteLeadDays_2" runat="server"></asp:Label>
                        </ItemTemplate>
                        <ItemStyle CssClass="backColor2" Width="140px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Qoute3">
                        <ItemTemplate>
                            <asp:Label ID="lblQouteRate_3" runat="server"></asp:Label>
                            <asp:Label ID="lblQouteTime_3" runat="server"></asp:Label><br />
                            <asp:Label ID="lblQouteSupplierName_3" runat="server"></asp:Label><br />
                            <asp:Label ID="lblQouteLeadDays_3" runat="server"></asp:Label>
                        </ItemTemplate>
                        <ItemStyle CssClass="backColor3" Width="140px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="PO Numbaer">
                        <ItemTemplate>
                        </ItemTemplate>
                        <ItemStyle Width="50px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Supplier">
                        <ItemTemplate>
                        </ItemTemplate>
                        <ItemStyle Width="50px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Qty">
                        <ItemTemplate>
                        </ItemTemplate>
                        <ItemStyle Width="50px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Action">
                        <ItemTemplate>
                        </ItemTemplate>
                        <ItemStyle Width="40px" HorizontalAlign="center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Pending Qty (To order)">
                        <ItemTemplate>
                            <table border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td style="min-width: 40px; text-align: right">
                                        <asp:Label ID="pendingQtyinorder" runat="server"></asp:Label>
                                    </td>
                                    <td style="min-width: 12px;">
                                        <a id="lnkProductionpopup" runat="server" style="font-size: 8px; position: relative; top: -2px">
                                            <img src="../../App_Themes/ikandi/images/zoom_icon1.gif" style="cursor: pointer;" /></a>
                                    </td>
                                    <td style="min-width: 40px;">
                                        <div class="btnrpo tooltip" runat="server" id="divraise">
                                            R.PO
                                        </div>
                                        <asp:Button ID="btnrapo" Style="display: none;" runat="server" Text="R.PO" />
                                    </td>
                                </tr>
                            </table>
                        </ItemTemplate>
                        <ItemStyle Width="100px" />
                    </asp:TemplateField>
                </Columns>
                <EmptyDataTemplate>
                    <table cellspacing="0" rules="all" class="greigegrd greigegrdbor nobordertd" border="0"
                        id="ctl00_cph_main_content_grdprint" style="border-width: 0px; width: 100%; border-collapse: collapse;">
                        <tbody>

                            <tr class="HeaderClass">
                                <td align="center" style="min-width: 200px;">
                                    <table>
                                        <tbody>
                                            <tr>
                                                <td colspan="3" style="border: 0px;">Fabric Quality (GSM) C&amp;C Width<br>
                                                    Color/Print (Unit)</td>
                                            </tr>
                                            <tr>
                                                <td>Current Stage</td>
                                                <td>Previous Stage</td>
                                                <td>Style Specific</td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </td>
                                <td align="center" style="min-width: 150px;">Style No. (Serial No.)</td>
                                <td align="center" style="width: 60px;">
                                    <table>
                                        <tbody>
                                            <tr>
                                                <td style="border: 0px">Overall to order/send</td>
                                            </tr>
                                            <tr>
                                                <td>required qty</td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </td>
                                <td align="center" style="width: 40px;">Balance
                                    <br>
                                    In House </td>
                                <td align="center" style="width: 80px;">Total In House </td>
                                <td align="center" style="width: 80px;">Total Send </td>
                                <td align="center" style="width: 160px;">Quote 1 (Rate &amp; Time)<br>
                                    Supplier Name<br>
                                    Lead Time</td>
                                <td align="center" style="width: 160px;">Quote 2 (Rate &amp; Time)<br>
                                    Supplier Name<br>
                                    Lead Time</td>
                                <td align="center" style="width: 160px;">Quote 3 (Rate &amp; Time)<br>
                                    Supplier Name<br>
                                    Lead Time</td>
                                <td align="center" style="width: 80px;">PO Number</td>
                                <td align="center" style="min-width: 130px;">PO Supplier Name</td>
                                <td align="center" style="width: 60px;">Rcvd. Qty. </td>
                                <td align="center" class="widthAction">Revise PO</td>
                                <td align="center" class="widthPending">Qty. to Raise PO</td>
                            </tr>
                            <tr>
                                <td colspan="14" style="text-align: center; border: 0px;">
                                    <img src='../../images/sorry.png' alt='No record found' />
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </EmptyDataTemplate>
            </asp:GridView>
            <div class="divspplier" style="display: none;">
            </div>
            <asp:Button ID="btnsave" runat="server" Style="display: none" CssClass="classsave"
                OnClick="btnsave_Click" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
