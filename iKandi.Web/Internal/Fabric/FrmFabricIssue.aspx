<%@ Page Title="" Language="C#" MasterPageFile="~/layout/Secure.Master" AutoEventWireup="true"
    CodeBehind="FrmFabricIssue.aspx.cs" Inherits="iKandi.Web.Internal.Fabric.FrmFabricIssue" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_main_content" runat="server">
    <style type="text/css">
        disabled {
            color: currentColor;
            cursor: not-allowed;
            opacity: 0.5;
            text-decoration: none;
        }

        @media print {
            body {
                -webkit-print-color-adjust: exact;
            }
        }

        .FabricConainer {
            width: 800px;
            margin: 0 auto;
        }

        .toptable thead span {
            line-height: 20px;
        }

        input[type=text] {
            font-family: arial !important;
            text-transform: unset;
        }

        .toptable thead input[type="text"] {
            width: 50px;
            height: 12px;
            padding-left: 3px;
            font-size: 10px;
            border: 1px solid #999;
            border-radius: 2px;
            font-family: arial !important;
        }

        .bottomtable input[type="text"] {
            width: 80px;
            height: 12px;
            padding-left: 3px;
            font-size: 10px;
            border: 1px solid #999;
            border-radius: 2px;
            font-family: arial !important;
        }

        .srvtable input[type="text"] {
            height: 12px;
            padding-left: 3px;
            font-size: 10px;
            border: 1px solid #999;
            border-radius: 2px;
            font-family: arial !important;
        }

        .header1 {
            background: #dddfe4;
        }

        .srvtable {
            min-width: 1200px;
            width: 100%;
            margin-top: 5px;
        }

            .srvtable td {
                padding: 0px 0px;
                height: 20px;
                font-family: arial !important;
                font-size: 10px;
            }

            .srvtable th table td {
                font-family: arial !important;
                font-size: 11px;
            }

        .widhcol1 {
            width: 30px;
        }

        .widhcol2 {
            min-width: 60px;
            max-width: 60px;
        }

        .widhConQty {
            min-width: 125px;
        }

        .widhcol4 {
            min-width: 250px;
            max-width: 250px;
        }

        .widhcol3 {
            width: 40px;
        }

        .srvtable th {
            padding: 0px 0px;
            text-align: center;
            font-weight: 500;
            background: #dddfe4;
            text-transform: capitalize;
            color: #6b6464;
            font-size: 11px;
            font-family: Arial !important;
            height: 15px;
        }

        .srvtable td {
            text-align: center;
            border-color: #9999;
        }

        td.process {
            border-color: #9999;
            border-bottom: 1px solid #9999;
            height: 33px;
            text-align: center !important;
            font-family: arial !important;
        }

        .IssueChallan_width {
            min-width: 85px;
            max-width: 85px;
        }

        .da_astrx_mand {
            color: Red;
        }

        @media print {
            body {
                -webkit-print-color-adjust: exact;
            }
        }

        #sb-wrapper-inner {
            border: 5px solid #999;
            border-radius: 5px;
        }

        #sb-wrapper-inner {
            background: #fff;
        }

        .StyleContextup {
            text-align: center;
            white-space: nowrap;
            vertical-align: middle;
            width: 2em;
        }

            .StyleContextup div {
                -moz-transform: rotate(-90.0deg); /* FF3.5+ */
                -o-transform: rotate(-90.0deg); /* Opera 10.5 */
                -webkit-transform: rotate(-90.0deg); /* Saf3.1+, Chrome */
                filter: progid:DXImageTransform.Microsoft.BasicImage(rotation=0.083); /* IE6,IE7 */
                -ms-filter: "progid:DXImageTransform.Microsoft.BasicImage(rotation=0.083)"; /* IE8 */
                margin-left: -10em;
                margin-right: -10em;
                color: #405d9a;
                font-weight: bold;
            }

        .SrNoContextup {
            text-align: center;
            white-space: nowrap;
            vertical-align: middle;
            width: 2em;
        }

            .SrNoContextup div {
                -moz-transform: rotate(-90.0deg); /* FF3.5+ */
                -o-transform: rotate(-90.0deg); /* Opera 10.5 */
                -webkit-transform: rotate(-90.0deg); /* Saf3.1+, Chrome */
                filter: progid:DXImageTransform.Microsoft.BasicImage(rotation=0.083); /* IE6,IE7 */
                -ms-filter: "progid:DXImageTransform.Microsoft.BasicImage(rotation=0.083)"; /* IE8 */
                margin-left: -10em;
                margin-right: -10em;
                color: #405d9a;
                font-weight: bold;
            }

        .StyleContextupH {
            text-align: center;
            white-space: nowrap;
            vertical-align: middle;
            width: 2em;
        }

            .StyleContextupH div {
                -moz-transform: rotate(-90.0deg); /* FF3.5+ */
                -o-transform: rotate(-90.0deg); /* Opera 10.5 */
                -webkit-transform: rotate(-90.0deg); /* Saf3.1+, Chrome */
                filter: progid:DXImageTransform.Microsoft.BasicImage(rotation=0.083); /* IE6,IE7 */
                -ms-filter: "progid:DXImageTransform.Microsoft.BasicImage(rotation=0.083)"; /* IE8 */
                margin-left: -10em;
                margin-right: -10em;
            }

        .SrNoContextupH {
            text-align: center;
            white-space: nowrap;
            vertical-align: middle;
            width: 2em;
            width: 25px;
        }

            .SrNoContextupH div {
                -moz-transform: rotate(-90.0deg); /* FF3.5+ */
                -o-transform: rotate(-90.0deg); /* Opera 10.5 */
                -webkit-transform: rotate(-90.0deg); /* Saf3.1+, Chrome */
                filter: progid:DXImageTransform.Microsoft.BasicImage(rotation=0.083); /* IE6,IE7 */
                -ms-filter: "progid:DXImageTransform.Microsoft.BasicImage(rotation=0.083)"; /* IE8 */
                margin-left: -10em;
                margin-right: -10em;
            }

        .Required_width {
            min-width: 50px;
            max-width: 50px;
        }

        .topsupplier {
            border-collapse: collapse;
        }

            .topsupplier th {
                background: #536EA9;
                color: #d4d4d4f8;
                text-align: center;
                border: 1px solid #999;
                font-family: arial !important;
                font-size: 11px;
            }

            .topsupplier td {
                text-align: center;
                border: 1px solid #999;
                font-weight: bold;
            }

        .divspplier {
            position: absolute;
            top: 50%;
            left: 43%; /* width: 30em; */
            min-height: 200px;
            margin-top: -9em;
            margin-left: -15em;
            border: 1px solid #ccc;
            background-color: #f3f3f3;
        }

        .Qa_grid_table td {
            border-right: 1px solid #dbd8d8 !important;
            font-size: 9px !important;
            font-family: arial !important;
            text-align: center;
            border-bottom: 1px solid #9999;
            border-top: 1px solid #9999;
            font-family: arial !important;
        }

        th.qaheader {
            border-right: 1px solid #999 !important;
            padding: 3px 5px !important;
            background: #cecccc;
        }

        .Qa_grid_table td:first-child {
            border-left: 1px solid #999 !important
        }

        .Qa_grid_table td:last-child {
            border-right: 1px solid #999 !important
        }

        .Qa_grid_table tr:nth-last-child(1) > td {
            border-bottom: 1px solid #999 !important
        }

        th.qaheader:first-child {
            border-left: 1px solid #999 !important
        }

        .Qa_grid_table th {
            color: #575759;
            background-color: #dddfe4;
            text-transform: capitalize;
            text-align: center;
            font-weight: normal;
            font-size: 11px;
            border-right: 0px;
        }

        .Qa_grid_table {
            position: fixed;
            top: 50%;
            left: 82%;
            z-index: 0;
            background: #fff;
            width: 235px;
        }

        .abc .Qa_grid_table {
            border-collapse: collapse;
        }

        .Qa_grid_table td {
            font-size: 11px !important;
            padding: 2px 3px !important;
        }

        [data-title] {
            position: relative;
        }

            [data-title]:hover::after {
                content: attr(data-title);
                position: absolute;
                top: -22px;
                left: 0px;
                padding: 3px 3px;
                background: #403c3c;
                color: #fff;
                z-index: 9;
                font-size: 10px;
                height: auto;
                line-height: 12px;
                border-radius: 3px;
                white-space: pre-line;
                word-wrap: break-word;
                min-width: 100px;
            }

            [data-title]:hover::before {
                content: '';
                position: absolute;
                bottom: 2px;
                left: 5px;
                display: inline-block;
                color: #fff;
                border: 8px solid transparent;
                border-top: 8px solid #403c3c;
            }
        /* search box*/
        .searchbox_1 {
            background-color: #fffbf8;
            padding: 13px;
            width: 335px;
            margin: 100px auto;
            -webkit-box-sizing: border-box;
            -moz-box-sizing: border-box;
        }

        .search_1 {
            width: 250px;
            height: 24px;
            padding-left: 5px;
            border-radius: 2px;
            border: none;
            color: #0F0D0D;
            ;
            font-weight: 500;
            font-size: 10px !important;
        }

        .submit_1 {
            width: 35px;
            height: 30px;
            background-image: url(img/search-btn.png);
            background-repeat: no-repeat;
            background-position: 17px 2px;
            background-color: transparent;
            -webkit-background-size: 20px 20px;
            background-size: 20px 20px;
            border: none;
            cursor: pointer;
            font-size: 11px !important
        }

        .search_1:focus {
            outline: 0;
        }

        .innertable {
            border-collapse: collapse;
        }

            .innertable td {
                border-left: 1px solid #999;
                padding: 18px 0px;
                min-width: 57px;
                max-width: 57px;
            }

                .innertable td:first-child {
                    border-left: 0px;
                }

        td table tr:nth-last-child(1) > td.process {
            border-bottom: 0px !important;
        }

        td table td.process {
            border-bottom-color: #9999 !important;
        }

        .challanIssuTo td.process {
            min-width: 80px;
            max-width: 80px;
        }

        .do-not-disable {
            border-radius: 2px;
        }

        .abc {
            background: #00000069;
            height: 100%;
            width: 100%;
            position: absolute;
            top: 0px;
        }

        .hideHederFabricIss {
            display: none;
        }

        #PopTableW {
            width: 100%;
            margin-bottom: 7px;
        }

        .DisplayNoneH {
            display: none;
        }

        .widthPaading {
            width: 100%;
            padding: 0px;
        }

        .PaddingLeftRight {
            padding-right: 5px !important;
        }

        .srvtable td:first-child {
            border-left-color: #999 !important
        }

        .srvtable td:last-child {
        }

        .srvtable tr:nth-last-child(1) > td {
            border-bottom-color: #999 !important
        }

        #here_table {
            position: relative;
        }

        .qatableheader {
            content: "";
            position: absolute;
            top: 0%;
            right: -7%;
            margin-left: -5px;
            border-width: 9px;
            border-style: solid;
            border-color: transparent transparent transparent #39589c;
        }

            .qatableheader th {
                border: 1px solid #999;
            }

            .qatableheader td {
                border: 1px solid #dbd8d8;
            }

        ::-webkit-scrollbar {
            width: 8px;
            height: 8px;
        }

        #data {
            height: 100%;
        }
        /*  @media screen and (max-width: 1366px) {
            .table_width
            {
                 max-width: 1300px;
                 overflow: auto;
            }    
        }*/
        .widhcol4 table td {
            color: Gray;
        }

        .divspplier {
            position: fixed;
            top: 44%;
            left: 43%;
            /* width: 30em; */
            min-height: 120px;
            margin-top: -9em;
            margin-left: -15em;
            border: 1px solid #ccc;
            background-color: #f3f3f3;
            z-index: 2;
            width: 274px;
        }

        a:link {
            color: red;
        }

        /* visited link */
        a:visited {
            color: green;
        }

        /* mouse over link */
        a:hover {
            color: hotpink;
        }

        /* selected link */
        a:active {
            color: blue;
        }

        .btnSubmit {
            color: rgb(255, 255, 255);
            font-size: 12px !important;
            float: left;
            font-weight: bold;
            width: 52px;
            cursor: pointer;
            background: rgb(19, 167, 71);
            height: 24px;
            line-height: 23px;
            border: none !important;
            border-radius: 2px;
        }

            .btnSubmit:hover {
                color: Yellow !important;
            }

        .btnMoveQty {
            color: rgb(255, 255, 255);
            font-size: 12px !important;
            width: 52px;
            cursor: pointer;
            background: rgb(19, 167, 71);
            height: 18px;
            line-height: 18px;
            border: none !important;
            border-radius: 2px;
            text-align: center;
        }

            .btnMoveQty:hover {
                color: Yellow !important;
            }

        .DisNone {
            display: none;
        }

        [data-title] {
            position: relative;
        }

            [data-title]:hover::after {
                content: attr(data-title);
                position: absolute;
                top: -22px;
                left: 0px;
                padding: 3px 3px;
                background: #403c3c;
                color: #fff;
                z-index: 9;
                font-size: 10px;
                height: auto;
                line-height: 12px;
                border-radius: 3px;
                white-space: pre-line;
                word-wrap: break-word;
                min-width: 100px;
            }

            [data-title]:hover::before {
                content: '';
                position: absolute;
                bottom: 2px;
                left: 5px;
                display: inline-block;
                color: #fff;
                border: 8px solid transparent;
                border-top: 8px solid #403c3c;
            }

        .FabToltip {
            position: relative;
            display: inline-block;
        }

            .FabToltip .TooltipTxt {
                visibility: hidden;
                width: 120px;
                background-color: black;
                color: #fff;
                text-align: center;
                border-radius: 6px;
                padding: 5px 0;
                position: absolute;
                z-index: 1;
                bottom: 150%;
                left: 50%;
                margin-left: -60px;
            }

                .FabToltip .TooltipTxt::after {
                    content: "";
                    position: absolute;
                    top: 100%;
                    left: 50%;
                    margin-left: -5px;
                    border-width: 5px;
                    border-style: solid;
                    border-color: black transparent transparent transparent;
                }

            .FabToltip:hover .TooltipTxt {
                visibility: visible;
            }

        .EmptychallanIssuTo td.process {
            min-width: 80px;
            max-width: 80px;
        }

        #secure_footer {
            display: none !important;
        }
    </style>
    <%--<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1/jquery.min.js"></script>--%>
    <%--  <script src="../../js/jquery-1.9.0-jquery.min.js" type="text/javascript"></script>--%>
    <%--  <script src="../../js/jqueryui-1.9.1-jquery-ui.min.js" type="text/javascript"></script>--%>
    <%--  <script type="text/javascript" src='<%= Page.ResolveUrl("../../js/jquery-1.4.4.min.js")%>'></script>--%>
    <script type="text/javascript" src="../../js/service.min.js"></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("../../js/jquery.autocomplete.js")%>'></script>
    <link rel="stylesheet" type="text/css" href="../../css/jquery-combined.css" />
    <script type="text/javascript" src="../../js/combined_jquery_scripts4.js"></script>
    <script type="text/javascript" src="../../js/form.js"></script>
    <script type="text/javascript">
        var url = "../../Webservices/iKandiService.asmx";
        $(document).ready(function (e) {

            $('.process').click(function (e) { //Default mouse Position 
                // alert(e.pageX + ' , ' + e.pageY);
                $('#here_table').html("");
                var d = document.getElementById('here_table');
                d.style.position = "absolute";
                d.style.left = (e.pageX - 270) + 'px';
                d.style.top = (e.pageY - 50) + 'px';
            });

            //            $('.process').click(function (e) { //Offset mouse Position
            //                var posX = $(this).offset().left,
            //            posY = $(this).offset().top;
            //                alert((e.pageX - posX) + ' , ' + (e.pageY - posY));
            //            });

            //            $('.process').click(function (e) { //Relative ( to its parent) mouse position 
            //                var posX = $(this).position().left,
            //            posY = $(this).position().top;
            //                alert((e.pageX - posX) + ' , ' + (e.pageY - posY));
            //            });

            $("#ctl00_cph_main_content_txtmoveqty").keypress(function (e) {
                //if the letter is not digit then display error and don't type anything
                if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {
                    //display error message
                    $("#errmsg").html("Digits Only").show().fadeOut("slow");
                    return false;
                }
            });

            $("#ctl00_cph_main_content_txtmovetodebit").keypress(function (e) {
                //if the letter is not digit then display error and don't type anything
                if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {
                    //display error message
                    $("#errmsg").html("Digits Only").show().fadeOut("slow");
                    return false;
                }
            });

            $("#ctl00_cph_main_content_txtResiShrinkQty").keypress(function (e) {
                //if the letter is not digit then display error and don't type anything
                if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {
                    //display error message
                    $("#errmsg").html("Digits Only").show().fadeOut("slow");
                    return false;
                }
            });


        });

        var urls = "../../Webservices/iKandiService.asmx";
        var proxy = new ServiceProxy(serviceUrl);

        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            if (charCode != 46 && charCode > 31
                && (charCode < 48 || charCode > 57))
                return false;

            return true;
        }
        $(document).ready(function () {
            //   alert();

            var unitid = $("#ctl00_cph_main_content_grdfabric_ctl01_ddlFactoryUnit").val();
            if (unitid < 0) {

                $("#ctl00_cph_main_content_grdfabric_ctl01_chkraisecuttingall").attr("disabled", "true");

            }

            $("#ctl00_cph_main_content_grdfabric_ctl01_ddlFactoryUnit").change(function () {

                if ($("#ctl00_cph_main_content_grdfabric_ctl01_ddlFactoryUnit").val() < 0) {

                    $("#ctl00_cph_main_content_grdfabric_ctl01_chkraisecuttingall").attr("disabled", "true");
                }
                else {

                    $("#ctl00_cph_main_content_grdfabric_ctl01_chkraisecuttingall").attr("disabled", "");
                }







            });



            // this code added by  bharat on 2-july
            //            debugger;
            //            var vars = [], hash;
            //            var hashes = window.location.href.slice(window.location.href.indexOf('?') + 1).split('&');
            //            hash = hashes[0].split('=');
            //           // alert(hash[1] != -1 && hash[1]);
            //            if (hash[1] != -1 && hash[1] != undefined) {
            //                $("#ctl00_cph_main_content_txtsearchkeyswords").hide();
            //                $("#ctl00_cph_main_content_btnSearch").hide();
            //            }
            var hdnHeader = $("#" + '<%= hdnheaderID.ClientID %>').val();
            //alert(hdnHeader);
            if (hdnHeader == 2) {
                $("#secure_greyline").addClass("hideHederFabricIss");
                $(".secure_center_contentWrapper").addClass('widthPaading');
                $("#secure_banner_cor").addClass('PaddingLeftRight');
            }
            else {
                $('#PopTableW').addClass("DisplayNoneH");
            }
            // end

            // alert();
            //  var con = $.noConflict();
            //            $(".allownumericwithoutdecimal").on("keypress keyup blur", function (event) {
            //                $(this).val($(this).val().replace(/[^\d].+/, ""));
            //                if ((event.which < 48 || event.which > 57)) {
            //                    event.preventDefault();
            //                }
            //            });


        });


        //public int UpdateFabricRaise(int IsCheck, string flag, int OrderDetailID, int FabQtyID)
        function UpdateRaiseCuttingReq(elem, OrderDetailsID, fabQtyID, FabricDetails) {

            var Values = 0;

            var result = confirm("Selected checkbox will be freez after checked");
            if (elem.checked) {
                Values = 1;
            }
            else {
                Values = 0;
            }
            if (result) {


                if (Values == 1) {
                    $("#" + elem.id).attr('disabled', 'disabled');
                }
                else {
                    return false;
                }

                var unitid = $("#ctl00_cph_main_content_grdfabric_ctl01_ddlFactoryUnit").val();

                if (unitid != null && unitid != undefined && unitid != "" && unitid != "-1") {
                    var url = "../../Webservices/iKandiService.asmx";
                    $.ajax({
                        type: "POST",
                        url: url + "/UpdateFabricRaise",
                        data: "{ IsCheck:'" + Values + "', flag:'" + "CUTTINGRAISE" + "', OrderDetailID:'" + OrderDetailsID + "', FabQtyID:'" + fabQtyID + "', FabricDetails:'" + FabricDetails + "',UnitID:'" + unitid + "' }",
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: OnSuccessCall,
                        error: OnErrorCall
                    });

                    function OnSuccessCall(response) {
                        alert("Saved Sucessfully");
                    }

                    function OnErrorCall(response) {
                        alert(response.status + " " + response.statusText);
                    }

                }
            }
            else {
                elem.checked = false;
            }
        }
        function UpdateIssueComplete(elem, OrderDetailsID, fabQtyID, FabricDetails) {

            alert("Ochnage Clicked");
            var Values = 0;

            var result = confirm("Selected checkbox will be freez after checked");
            if (elem.checked) {
                Values = 1;
            }
            else {
                Values = 0;
            }
            //            if (result) {

            //                //alert(elem.id);
            //                str1 = elem.id.replace(/^\D+/g, '');

            //                if (Values == 1) {
            //                    $("#" + "chkfaissue" + str1).attr('disabled', 'disabled');
            //                    $("#" + "chkfabCutreq" + str1).attr('disabled', 'disabled');
            //                    $("#" + "txtCutwas" + str1).attr('disabled', 'disabled');

            //                    $("#" + elem.id).attr('disabled', 'disabled');

            //                }
            //                else {
            //                    return false;
            //                }
            //                //var OrderDetailsID = document.getElementById("ctl00_cph_main_content_grdfabric_" + rowid + "_" + "hdnOrderdetailID").value;
            //                var url = "../../Webservices/iKandiService.asmx";
            //                $.ajax({
            //                    type: "POST",
            //                    url: url + "/UpdateFabricRaise",
            //                    data: "{ IsCheck:'" + Values + "', flag:'" + "ISSUECOMPLETE" + "', OrderDetailID:'" + OrderDetailsID + "', FabQtyID:'" + fabQtyID + "', FabricDetails:'" + FabricDetails + "' }",
            //                    contentType: "application/json; charset=utf-8",
            //                    dataType: "json",
            //                    success: OnSuccessCall,
            //                    error: OnErrorCall
            //                });

            //                function OnSuccessCall(response) {
            //                    alert("Saved Sucessfully");
            //                }

            //                function OnErrorCall(response) {
            //                    alert(response.status + " " + response.statusText);
            //                }
            //            }
            //            else {
            //                elem.checked = false;
            //            }
        }
        function chk() {

            StockQty = document.getElementById("ctl00_cph_main_content_txtmovetodebit").value;
            if (StockQty == "") {
                StockQty = "0";
            }
            if (parseInt(StockQty) > 0) {
                document.getElementById("ctl00_cph_main_content_txtparticular").removeAttribute("disabled");
                document.getElementById("ctl00_cph_main_content_txtparticular").value = "";
            }
            else {
                document.getElementById("ctl00_cph_main_content_txtparticular").setAttribute("disabled", "");
                document.getElementById("ctl00_cph_main_content_txtparticular").value = "";
            }
        }
        function UpdateStockQtysub() {
            FabQtyID = document.getElementById("ctl00_cph_main_content_hdnfabricqtyid").value;
            FabricDetails = document.getElementById("ctl00_cph_main_content_hdnfabricdetails").value;
            StockQty = document.getElementById("ctl00_cph_main_content_txtmoveqty").value;
            OrderDetailsID = document.getElementById("ctl00_cph_main_content_hdnorderdetailsID").value;


            EntredStockQty = document.getElementById("ctl00_cph_main_content_txtmoveqty").value;
            EntredDebitStockQty = document.getElementById("ctl00_cph_main_content_txtmovetodebit").value;
            EntredResiShrinkQty = document.getElementById("ctl00_cph_main_content_txtResiShrinkQty").value;
            EntredExtraWastageQty = document.getElementById("ctl00_cph_main_content_txtExtraWastageQty").value //03052023
            ActualQty = document.getElementById("ctl00_cph_main_content_hdnstaockqty").value = document.getElementById("ctl00_cph_main_content_hdnstaockqty").value;
            //ActualQty = document.getElementById("ctl00_cph_main_content_lblleftmoveqty").innerText;
            particular = document.getElementById("ctl00_cph_main_content_txtparticular").value;
            if (EntredDebitStockQty == "") { EntredDebitStockQty = 0; }
            if (EntredResiShrinkQty == "") { EntredResiShrinkQty = 0; }
            if (EntredExtraWastageQty == "") { EntredExtraWastageQty = 0; }
            if (EntredStockQty == "") { EntredStockQty = 0; }
            if (ActualQty == "") { ActualQty = 0; }

            qtyleft = parseInt(ActualQty) - (parseInt(EntredStockQty) + parseInt(EntredDebitStockQty) + parseInt(EntredResiShrinkQty) + parseInt(EntredExtraWastageQty))

            if ((parseInt(EntredStockQty) + parseInt(EntredDebitStockQty) + parseInt(EntredResiShrinkQty)) > parseInt(ActualQty)) {
                alert("Entered qty cannot be greater than: " + ActualQty);
                return false;
            }
            else {
                BalanceQty = parseInt(ActualQty) - (parseInt(EntredStockQty) + parseInt(EntredDebitStockQty) + parseInt(EntredResiShrinkQty) + parseInt(EntredExtraWastageQty));
            }
            var BalanceQty2 = parseInt(ActualQty) - (parseInt(EntredStockQty) + parseInt(EntredDebitStockQty) + parseInt(EntredResiShrinkQty) + parseInt(EntredExtraWastageQty));
            if (parseInt(BalanceQty2) > 0) {
                alert("Cut issue cannot be completed with left over qty.: " + qtyleft);
                //return false;
            }
            else if (parseInt(EntredDebitStockQty) > 0 && particular == "") { alert("Enter Particular"); }
            else { $('.btnshowsrv').click(); }

            //            if (parseInt(ActualQty) <= (parseInt(EntredStockQty) + parseInt(EntredDebitStockQty))) {
            //                $.ajax({
            //                    type: "POST",
            //                    url: url + "/UpdateFabricRaise",
            //                    data: "{ IsCheck:'" + 1 + "', flag:'" + "ISSUECOMPLETE" + "', OrderDetailID:'" + OrderDetailsID + "', FabQtyID:'" + FabQtyID + "', FabricDetails:'" + FabricDetails + "' }",
            //                    contentType: "application/json; charset=utf-8",
            //                    dataType: "json"
            //                    ,
            //                    success: OnSuccessCall,
            //                    error: OnErrorCall

            //                });
            //            }


            //            $.ajax({
            //                type: "POST",
            //                url: url + "/UpdateStockQty",
            //                data: "{ flag:'" + 'UPDATESTOACKQTY' + "', FabQtyID:'" + FabQtyID + "', FabricDetails:'" + FabricDetails + "', StockQty:'" + StockQty + "', orderdetailid:'" + OrderDetailsID + "', debitqty:'" + EntredDebitStockQty + "', particular:'" + particular + "'}",
            //                contentType: "application/json; charset=utf-8",
            //                dataType: "json"
            //                ,
            //                success: OnSuccessCall,
            //                error: OnErrorCall
            //            });

            //            function OnSuccessCall(response) {

            //$('.btnshowsrv').click();
            //                $(".divspplier").hide();
            //                return false;
            //                location.reload();
            //            }

            //            function OnErrorCall(response) {

            //                alert(response.status + " " + response.statusText);
            //            }
            //            location.reload();
            //            return false;

        }
        function UpdateWastage(elem, OrderDetailsID, fabQtyID) {

            var Values = elem.value;
            if (Values == "") {
                elem.value = elem.defaultValue;
            }
            var result = confirm("Are you sure want to update ?");
            if (result) {
                var id = elem.id;
                var rowid = elem.id.split("_")[5];

                //int CuttingRequest_IssueSheet_Id, decimal wastage, string flag, int OrderDetailID, int FabQtyID
                //var OrderDetailsID = document.getElementById("ctl00_cph_main_content_grdfabric_" + rowid + "_" + "hdnOrderdetailID").value;
                var url = "../../Webservices/iKandiService.asmx";
                $.ajax({
                    type: "POST",
                    url: url + "/UpdateFabricWastage",
                    data: "{ CuttingRequest_IssueSheet_Id:'" + -1 + "',wastage:'" + Values + "', flag:'" + "UPDATECUTWASTAGE" + "', OrderDetailID:'" + OrderDetailsID + "', FabQtyID:'" + fabQtyID + "' }",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: OnSuccessCall,
                    error: OnErrorCall
                });

                function OnSuccessCall(response) {
                    alert("Saved Sucessfully");
                }

                function OnErrorCall(response) {
                    alert(response.status + " " + response.statusText);
                }
            }
            else {
                elem.checked = false;
            }
        }



        function ShowAllSupplier(issuecomplete, DebitNote_Id, SupplierPoID, challanid, Type, sendqty, OrderDetailsID, FabricQualityID, FabricDetails) {


            var status;
            if ($("#" + issuecomplete).is(':checked') && $("#" + issuecomplete).is(':disabled')) {
                status = 2; //checked and disabled
            }
            else if ($("#" + issuecomplete).is(':disabled')) {
                if ($("#" + issuecomplete).is(':checked')) {
                }

                else {
                    status = 0; //not checked but disabled
                }
            }
            else {
                status = 1; //ready to check and also not disabled
            }



            var url = "../../Webservices/iKandiService.asmx";

            $.ajax({
                type: "POST",
                url: url + "/ListChallan",
                data: "{ Flag:'" + 'Get_Internal_Challan_List' + "', OrderDetailID:'" + OrderDetailsID + "', FabQtyID:'" + FabricQualityID + "', FabricDetails:'" + FabricDetails + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: OnSuccessCall,
                error: OnErrorCall
            });

            function OnSuccessCall(response) {

                closeAMFabButtion();

                $('#here_table').append('<table cellspacing="0" border="0" class="ss qatableheader" cellpedding="0">');
                $('#here_table').append("<tr><th colspan='4' style='background: #39589c;color:#f5f5f5;border-right:1px solid #39589c'>Challan History<span style='float:right;padding-right:10px;cursor: pointer;' titel='Close' onclick='HideSupplierDiv();'>X</span></th></tr>");
                $('#here_table').append("<tr><th class='qaheader contactorderwidth'>Challan Number</th><th class='qaheader contactorderwidth' style='width:26%'>Issued Qty. - Returned Qty.</th><th class='qaheader contactorderwidth'>Returned Challan Qty. </th><th class='qaheader qtyupdatewidth'> Issued On </th></tr>")
                for (var i = 0; i < response.d.length; i++) {

                    var rtqty = response.d[i]["ReturnedChallanQty"].toString() == "0" ? "" : response.d[i]["ReturnedChallanQty"].toString() + "Mtr";

                    $('#here_table').append("<tr><td class='textcenter'>" + "<a onclick='ShowSupplierChallanScreenSend(" + status + "," + response.d[i]["ChallanID"] + "," + response.d[i]["OrderDetailsID"] + "," + response.d[i]["FabricQualityID"] + "," + "&apos;" + response.d[i]["FabricDetails"] + "&apos;" + ")' style='color:blue;cursor:pointer' >" + response.d[i]["ChallanNumber"] + "</a>" + " </td><td class='textcenter'>" + response.d[i]["IssueQty"] + " mtr</td><td class='textcenter'>" + rtqty + "</td><td class='textcenter'>" + response.d[i]["IssueDate"] + "</td></tr>");
                }
                $('#here_table').append('</table>');
                if (response.d.length > 0) {
                    $("#here_table").show();
                    $(".backColorFade").addClass('abc');
                }
                else {
                    $('#here_table').html("");
                }
            }

            function OnErrorCall(response) {

                $('#here_table').html("");
                alert(response.status + " " + response.statusText);
            }
        }

        function ShowStockIssuedChallan(issuecomplete, DebitNote_Id, SupplierPoID, challanid, Type, sendqty, OrderDetailsID, FabricQualityID, FabricDetails) {


            var status;
            if ($("#" + issuecomplete).is(':checked') && $("#" + issuecomplete).is(':disabled')) {
                status = 2; //checked and disabled
            }
            else if ($("#" + issuecomplete).is(':disabled')) {
                if ($("#" + issuecomplete).is(':checked')) {
                }

                else {
                    status = 0; //not checked but disabled
                }
            }
            else {
                status = 1; //ready to check and also not disabled
            }

            var url = "../../Webservices/iKandiService.asmx";

            $.ajax({
                type: "POST",
                url: url + "/ListChallan",
                data: "{ Flag:'" + 'Get_ExtraStockIssue_Challan_List' + "', OrderDetailID:'" + OrderDetailsID + "', FabQtyID:'" + FabricQualityID + "', FabricDetails:'" + FabricDetails + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: OnSuccessCall,
                error: OnErrorCall
            });

            function OnSuccessCall(response) {
                closeAMFabButtion();

                $('#here_table').append('<table cellspacing="0" border="0" class="ss qatableheader" cellpedding="0">');
                $('#here_table').append("<tr><th colspan='4' style='background: #39589c;color:#f5f5f5;border-right:1px solid #39589c'>Challan History<span style='float:right;padding-right:10px;cursor: pointer;' titel='Close' onclick='HideSupplierDiv();'>X</span></th></tr>");
                $('#here_table').append("<tr><th class='qaheader contactorderwidth'>Challan Number</th><th class='qaheader contactorderwidth' style='width:26%'>Issued Qty. </th><th class='qaheader contactorderwidth'>Returned Challan Qty. </th><th class='qaheader qtyupdatewidth'> Issued On </th></tr>")
                for (var i = 0; i < response.d.length; i++) {

                    var rtqty = response.d[i]["ReturnedChallanQty"].toString() == "0" ? "" : response.d[i]["ReturnedChallanQty"].toString() + "Mtr";

                    $('#here_table').append("<tr><td class='textcenter'>" + "<a onclick='ShowExtraStockIssue(" + status + "," + response.d[i]["ChallanID"] + "," + response.d[i]["OrderDetailsID"] + "," + response.d[i]["FabricQualityID"] + "," + "&apos;" + response.d[i]["FabricDetails"] + "&apos;" + ")' style='color:blue;cursor:pointer' >" + response.d[i]["ChallanNumber"] + "</a>" + " </td><td class='textcenter'>" + response.d[i]["IssueQty"] + " mtr</td><td class='textcenter'>" + rtqty + "</td><td class='textcenter'>" + response.d[i]["IssueDate"] + "</td></tr>");
                }
                $('#here_table').append('</table>');
                if (response.d.length > 0) {
                    $("#here_table").show();
                    $(".backColorFade").addClass('abc');
                }
                else {
                    $('#here_table').html("");
                }
            }

            function OnErrorCall(response) {

                $('#here_table').html("");
                alert(response.status + " " + response.statusText);
            }
        }

        function ShowSupplierChallanScreenSendNEW(IsCompleteIssue, DebitNote_Id, SupplierPoID, challanid, Type, sendqty, OrderDetailsID, FabricQualityID, fabricdetails, CanMakeNewChallan) {
            if (IsCompleteIssue == 'True') {
                return false;
            }
            if (parseInt(CanMakeNewChallan) != 1) {
                alert("Please clear Previous Challan First.");
                return false;
            }

            var sURL = 'FabricSupplierChallanDetails.aspx?Debit_Note_ID=' + DebitNote_Id + "&SupplierPoID=" + 0 + "&ChallanType=" + "INTERNAL" + "&ChallanID=" + challanid + "&FabType=" + Type + "&SendQty=" + sendqty + "&IsNewChallan=" + 'NEWCHALLAN' + "&OrderDetailsID=" + OrderDetailsID + "&FabricQualityID=" + FabricQualityID + "&fabricdetails=" + fabricdetails;
            Shadowbox.init({ animate: true, animateFade: true, modal: true });
            Shadowbox.open({ content: sURL, type: "iframe", player: "iframe", title: "", height: 600, width: 750, modal: true, animate: true, animateFade: true, options: { onClose: SBClose } });

            return false;
        }

        function ShowSupplierChallanScreenSend(status, challanid, OrderDetailsID, FabricQualityID, FabricDetails, availableqty) {


            var heightHis = 3;
            var sURL = 'FabricSupplierChallanDetails.aspx?Debit_Note_ID=' + -1 + "&SupplierPoID=" + 0 + "&ChallanType=" + "INTERNAL" + "&ChallanID=" + challanid + "&FabType=" + '' + "&SendQty=" + 0 + "&IsNewChallan=" + 'Oldchallan' + "&OrderDetailsID=" + OrderDetailsID + "&FabricQualityID=" + FabricQualityID + "&heightHis=" + heightHis + "&FabricDetails=" + FabricDetails + "&availableqty=" + availableqty + "&status=" + status;
            Shadowbox.init({ animate: true, animateFade: true, modal: true });
            Shadowbox.open({ content: sURL, type: "iframe", player: "iframe", title: "", height: 600, width: 750, modal: true, animate: true, animateFade: true, options: { onClose: SBClose } });

            return false;
        }

        function ShowExtraStockIssueNew(IsSettlementDone, IsCompleteIssue, Type, OrderDetailsID, FabricQualityID, fabricdetails, IsQtyAvailableForIssue) {
            if (IsCompleteIssue === "True" && parseInt(IsQtyAvailableForIssue) === 1) {
                alert("You Cannot Issue From Stock as you haven't fully utilized the Issued Quantity yet and have Marked Cut Issue Complete.");
                return false;
            }
            if (parseInt(IsQtyAvailableForIssue) === 1) {
                alert("Please make Challan from Available Qty. First.");
                return false;
            }
            else if (IsSettlementDone === "True") {
                return false;
            }
            var sURL = 'FabricSupplierChallanDetails.aspx?OrderDetailsID=' + OrderDetailsID + "&FabricQualityID=" + FabricQualityID + "&ColorPrint=" + fabricdetails + "&IsNewChallan=" + 'NEWCHALLAN' + "&ChallanType=" + Type;
            Shadowbox.init({ animate: true, animateFade: true, modal: true });
            Shadowbox.open({ content: sURL, type: "iframe", player: "iframe", title: "", height: 600, width: 750, modal: true, animate: true, animateFade: true, options: { onClose: SBClose } });
            return false;
        }

        function ShowExtraStockIssue(status, challanid, OrderDetailsID, FabricQualityID, FabricDetails, availableqty) {
            var heightHis = 3;
            var sURL = 'FabricSupplierChallanDetails.aspx?OrderDetailsID=' + OrderDetailsID + "&FabricQualityID=" + FabricQualityID + "&ColorPrint=" + FabricDetails + "&IsNewChallan=" + '' + "&ChallanType=" + 'ExtraStockIssue' + "&ChallanID=" + challanid;
            Shadowbox.init({ animate: true, animateFade: true, modal: true });
            Shadowbox.open({ content: sURL, type: "iframe", player: "iframe", title: "", height: 600, width: 750, modal: true, animate: true, animateFade: true, options: { onClose: SBClose } });
            return false;
        }


        function SBClose() { }
        function CallThisPage() {
            $("#here_table").hide();
            window.parent.Shadowbox.close();
            $('.btnshowsrv').click();
        }

        function closeAMFabButtion() {
            self.parent.Shadowbox.close();
        }
        function HideSupplierDiv() {
            $("#here_table").hide();
            $(".backColorFade").removeClass('abc');
        }

        // this code added by bharat on 2-july
        function closeFabCutIssButtion() {
            // alert();
            self.parent.Shadowbox.close();
        }

        function HideSupplierDiv2() {
            $(".divspplier").hide();
            window.location.reload();
        }
        function OnchangeStockQty(ctrl) {


            // document.getElementById("ctl00_cph_main_content_lblleftmoveqty").innerText = '';
            EntredStockQty = document.getElementById("ctl00_cph_main_content_txtmoveqty").value;
            EntredDebitStockQty = document.getElementById("ctl00_cph_main_content_txtmovetodebit").value;
            EntredResiShrinkQty = document.getElementById("ctl00_cph_main_content_txtResiShrinkQty").value;
            EntredExtraWastageQty = document.getElementById("ctl00_cph_main_content_txtExtraWastageQty").value //03052023
            ActualQty = document.getElementById("ctl00_cph_main_content_hdnstaockqty").value = document.getElementById("ctl00_cph_main_content_hdnstaockqty").value;
            //ActualQty = document.getElementById("ctl00_cph_main_content_lblleftmoveqty").innerText;
            if (EntredDebitStockQty == "") { EntredDebitStockQty = 0; }
            if (EntredResiShrinkQty == "") { EntredResiShrinkQty = 0; }
            if (EntredExtraWastageQty == "") { EntredExtraWastageQty = 0; }
            if (EntredStockQty == "") { EntredStockQty = 0; }
            if (ActualQty == "") { ActualQty = 0; }

            BalanceQty = (parseInt(ActualQty) - (parseInt(EntredStockQty) + parseInt(EntredDebitStockQty) + parseInt(EntredResiShrinkQty)+ parseInt(EntredExtraWastageQty)));
            if (parseInt(BalanceQty) > 0) {
                //  alert("Cut issue cannot be completed with left over qty.: " + BalanceQty);
                document.getElementById("ctl00_cph_main_content_lblleftmoveqty").innerText = BalanceQty.toString();
                return false;
            }
            if (parseInt(EntredDebitStockQty) > 0) {
                document.getElementById("ctl00_cph_main_content_txtparticular").removeAttribute("disabled");
                document.getElementById("ctl00_cph_main_content_txtparticular").value = "";
            }
            else {
                document.getElementById("ctl00_cph_main_content_txtparticular").setAttribute("disabled", "");
                document.getElementById("ctl00_cph_main_content_txtparticular").value = "";
            }

            if ((parseInt(EntredDebitStockQty) + parseInt(EntredStockQty) + parseInt(EntredResiShrinkQty) + parseInt(EntredExtraWastageQty)) < parseInt(ActualQty)) {
                document.getElementById("ctl00_cph_main_content_lblleftmoveqty").innerText = BalanceQty.toString();
                ctrl.value = '';
            }
            else {
                if ((parseInt(EntredStockQty) + parseInt(EntredDebitStockQty) + parseInt(EntredResiShrinkQty) + parseInt(EntredExtraWastageQty)) > parseInt(ActualQty)) {
                    alert("Overall quantity sum cannot be greater than: " + ActualQty);
                    document.getElementById("ctl00_cph_main_content_lblleftmoveqty").innerText = (parseInt(ActualQty) - (parseInt(EntredStockQty) + parseInt(EntredDebitStockQty) + parseInt(EntredResiShrinkQty) + parseInt(EntredExtraWastageQty)) + parseInt(ctrl.value));
                    ctrl.value = '';
                    return false;
                }
                else {
                    document.getElementById("ctl00_cph_main_content_lblleftmoveqty").innerText = BalanceQty.toString();
                }
            }
        }

        function IssueComplete(item, maxqty, SupplierPoID, challanid, Type, sendqty, OrderDetailsID, FabricQualityID, FabricDetails, stockqty, debitqty, particular) {
            debugger;
            var id = item.id;
            $('#' + id).attr('disabled', true);
            if (confirm("Are you Sure You Want to Mark Cut Issue Complete") == false) {
                window.location.reload();

                return false;
            }
            $.ajax({
                type: "POST",
                url: url + "/UpdateFabricRaise",
                data: "{ IsCheck:'" + 1 + "', flag:'" + "ISSUECOMPLETE" + "', OrderDetailID:'" + OrderDetailsID + "', FabQtyID:'" + FabricQualityID + "', FabricDetails:'" + FabricDetails + "',Unitid:-1 }",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: OnSuccessCall,
                error: OnErrorCall
            });

            function OnSuccessCall(response) {
                $('.btnshowsrv').click();
            }

            function OnErrorCall(response) {
                alert(response.status + " " + response.statusText);
            }

        }

        function MoveQty(item, maxqty, SupplierPoID, challanid, Type, sendqty, OrderDetailsID, FabricQualityID, FabricDetails, stockqty, debitqty, particular) {

            var id = item.id;
            $('#' + id).attr('disabled', true);
            document.getElementById("ctl00_cph_main_content_hdnfabricdetails").value = FabricDetails;
            document.getElementById("ctl00_cph_main_content_hdnfabricqtyid").value = FabricQualityID;
            document.getElementById("ctl00_cph_main_content_lblleftmoveqty").innerText = maxqty;
            document.getElementById("ctl00_cph_main_content_txtmoveqty").value = stockqty == "0" ? "" : stockqty;
            document.getElementById("ctl00_cph_main_content_txtmovetodebit").value = debitqty == "0" ? "" : debitqty;;
            document.getElementById("ctl00_cph_main_content_hdnstaockqty").value = maxqty;
            document.getElementById("ctl00_cph_main_content_hdndebit").value = debitqty;
            document.getElementById("ctl00_cph_main_content_hdnorderdetailsID").value = OrderDetailsID;
            if (document.getElementById("ctl00_cph_main_content_txtmovetodebit").value == "" || document.getElementById("ctl00_cph_main_content_txtmovetodebit").value == "0") {
                document.getElementById("ctl00_cph_main_content_txtparticular").value = "";
            }
            else {
                document.getElementById("ctl00_cph_main_content_txtparticular").value = particular;
                document.getElementById("ctl00_cph_main_content_txtparticular").removeAttribute("disabled");

            }
            if (parseFloat(maxqty) > 0) {
                $(".divspplier").show();
            }
            else {
                $('.btnshowsrv').click();
            }

        }

        $(document).ready(function () {
            //sb - wrapper

            $('.number').keypress(function (event) {
                var $this = $(this);
                if ((event.which != 46 || $this.val().indexOf('.') != -1) &&
                    ((event.which < 48 || event.which > 57) &&
                        (event.which != 0 && event.which != 8))) {
                    event.preventDefault();
                }

                var text = $(this).val();
                if ((event.which == 46) && (text.indexOf('.') == -1)) {
                    setTimeout(function () {
                        if ($this.val().substring($this.val().indexOf('.')).length > 3) {
                            $this.val($this.val().substring(0, $this.val().indexOf('.') + 3));
                        }
                    }, 1);
                }

                if ((text.indexOf('.') != -1) &&
                    (text.substring(text.indexOf('.')).length > 2) &&
                    (event.which != 0 && event.which != 8) &&
                    ($(this)[0].selectionStart >= text.length - 2)) {
                    event.preventDefault();
                }
            });

            $('.number').bind("paste", function (e) {
                var text = e.originalEvent.clipboardData.getData('Text');
                if ($.isNumeric(text)) {
                    if ((text.substring(text.indexOf('.')).length > 3) && (text.indexOf('.') > -1)) {
                        e.preventDefault();
                        $(this).val(text.substring(0, text.indexOf('.') + 3));
                    }
                }
                else {
                    e.preventDefault();
                }
            });

            //            $('input[type=text]').on("cut copy paste", function (e) {
            //                e.preventDefault();
            //            });
        });
        function callpage() { $('.btnshowsrv').click(); }


    </script>
    <div>
        <asp:HiddenField ID="hdnstaockqty" runat="server" />
        <asp:HiddenField ID="hdnfabricdetails" runat="server" />
        <asp:HiddenField ID="hdnfabricqtyid" runat="server" />
        <asp:HiddenField ID="hdnorderdetailsID" runat="server" />
        <asp:HiddenField ID="hdnparticular" runat="server" />
        <asp:HiddenField ID="hdndebit" runat="server" />
        <asp:HiddenField ID="hdnUnitid" runat="server" Value="0" />
        <asp:HiddenField ID="hdnissuecomplete" runat="server" Value="0" />
        <h2 style="min-width: 1200px; width: 100%; margin: 0px 0px 0px; font-weight: 500; background: #3b5998; color: White; text-align: center; padding: 6px 0px; line-height: 11px; height: 12px; font-size: 14px; clear: both">Fabric Cutting Issue
            <%--<span style="float: right; padding-right: 5px; margin-top: 0px;
                font-size: 14px; cursor: pointer" onclick="closeFabCutIssButtion()">x</span>--%>
        </h2>
    </div>
    <div style="width: 100%; display: none">
        <asp:TextBox ID="txtsearchkeyswords" Width="21%" class="search_1" placeholder="Search Fabric Quality/Style No/Serial No"
            runat="server"></asp:TextBox>
        <asp:Button ID="btnSearch" runat="server" CssClass="go do-not-disable" Text="Search"
            OnClick="btnSearch_Click" Style="padding: 2px 7px;" />
        <asp:Label ID="lbltotalrequest" runat="server"></asp:Label>&nbsp;&nbsp;&nbsp;<asp:Label
            ID="lblpending" runat="server"></asp:Label>
        <asp:HiddenField ID="hdnheaderID" runat="server" />
    </div>
    <table class="srvtable" cellspacing="0" cellpadding="0" rules="all" border="1" runat="server"
        id="emptyrow" style="border-collapse: collapse; display: none">
        <tbody>
            <tr>
                <th class="StyleContextupH" scope="col" style="width: 25px;">
                    <div>
                        <span id="ctl00_cph_main_content_grdfabric_ctl01_lblstyle">Style No.</span>
                    </div>
                </th>
                <th class="SrNoContextupH" scope="col" style="width: 25px;">
                    <div>
                        <span id="ctl00_cph_main_content_grdfabric_ctl01_lblSrNo">Sr. No.</span>
                    </div>
                </th>
                <th scope="col">
                    <table style="width: 100%;" cellspacing="0" cellpadding="0">
                        <tbody>
                            <tr>
                                <td style="border-bottom: 1px solid #ddd7d7;">Contract. No.
                                </td>
                            </tr>
                            <tr>
                                <td>Quantity <span style="color: Gray; font-weight: 600">Pcs</span>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </th>
                <th scope="col">
                    <table style="width: 100%;" cellspacing="0" cellpadding="0">
                        <tbody>
                            <tr>
                                <td>Cut Wastage %
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </th>
                <th scope="col">
                    <table style="width: 100%;">
                        <tbody>
                            <tr>
                                <td>Fabric Details/Color Print/Avg.
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </th>
                <th scope="col">
                    <table>
                        <tbody>
                            <tr>
                                <td>Actual Fabric Required<br />
                                    <span style="color: Gray; font-size: 9px;">Contract<span style="vertical-align: center;">
                                        * </span>Avg.</span>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </th>
                <th scope="col">
                    <table style="width: 100%">
                        <tbody>
                            <tr>
                                <td>Cut Width
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </th>
                <th scope="col">
                    <table>
                        <tbody>
                            <tr>
                                <td>Available qty. to issue
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </th>
                <th scope="col">
                    <table>
                        <tbody>
                            <tr>
                                <td>Raise Cutting Request Date
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </th>
                <th scope="col">
                    <table>
                        <tbody>
                            <tr>
                                <td>Required Qty.<br />
                                    (Include Cut Wastage)
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </th>
                <th scope="col">
                    <table style="width: 100%; height: 100%;" class="innertable">
                        <tbody>
                            <tr>
                                <td>Challan No.
                                </td>

                                <td>Total Issued
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </th>
                <th scope="col" style="display: none">
                    <table style="width: 100%">
                        <tbody>
                            <tr>
                                <td>View<br>
                                    Ch. His.
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </th>
                <th scope="col">
                    <table>
                        <tbody>
                            <tr>
                                <td>Issue Complete
                                    <br>
                                    CutIssue Settlement
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </th>
                <th scope="col">
                    <table>
                        <tbody>
                            <tr>
                                <td>Qty. left after issue complete
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </th>
            </tr>
            <tr>
                <td class="" colspan="15" style="height: 95px;">
                    <img src='../../images/sorry.png' alt='No record found' />
                </td>
            </tr>
        </tbody>
    </table>
    <div style="position: relative; margin-bottom: 50px;" class="table_width">
        <asp:GridView ID="grdfabric" OnDataBound="grdfabric_DataBound" runat="server" CellPadding="0"
            ShowHeader="true" CssClass="srvtable" OnRowDataBound="grdfabric_RowDatabound"
            AutoGenerateColumns="false">
            <RowStyle CssClass="FabricIssuedRow" />
            <Columns>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <div>
                            <asp:Label ID="lblstyle" Text="Style No." runat="server"></asp:Label>
                        </div>
                    </HeaderTemplate>
                    <HeaderStyle CssClass="StyleContextupH" Width="25px" />
                    <ItemTemplate>
                        <div>
                            <asp:Label ID="lblstylenumber" Text='<%# Eval("StyleNumber") %>' runat="server"></asp:Label>
                        </div>
                    </ItemTemplate>
                    <ItemStyle CssClass="widhcol1 StyleContextup" Height="95px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="">
                    <HeaderTemplate>
                        <div>
                            <asp:Label ID="lblSrNo" Text="Sr. No." runat="server"></asp:Label>
                        </div>
                    </HeaderTemplate>
                    <HeaderStyle CssClass="SrNoContextupH" Width="25px" />
                    <ItemTemplate>
                        <div>
                            <asp:Label ID="lblserial" runat="server" Text='<%# Eval("SerialNumber") %>'></asp:Label>
                        </div>
                    </ItemTemplate>
                    <ItemStyle CssClass="SrNoContextup" />
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <table style="width: 100%;" cellspacing="0" cellpadding="0">
                            <tr>
                                <td style="border-bottom: 1px solid #ddd7d7;">Contract No.
                                </td>
                            </tr>
                            <tr>
                                <td>Quantity
                                </td>
                            </tr>
                        </table>
                    </HeaderTemplate>
                    <HeaderStyle Width="111px" />
                    <ItemTemplate>
                        <table cellpadding="0" cellspacing="0" style="width: 100%">
                            <tr>
                                <td style="border-bottom: 1px solid #9999;">
                                    <asp:Label ID="lblcontract" Text='<%# Eval("ContractNumber") %>' runat="server"></asp:Label>
                                    <asp:HiddenField ID="hdnContactNumber" runat="server" Value='<%# Eval("ContractNumber") %>' />
                                    <asp:HiddenField ID="hdnavailableqty" runat="server" />
                                </td>
                            </tr>
                            <%-- <tr>
                            <td style="border-bottom: 1px solid #ddd7d7;">
                               <asp:TextBox ID="txtcutwastage" Width="92%" onchange="UpdateWastage(this);" CssClass="allownumericwithdecimal"
                                    runat="server"></asp:TextBox>
                            </td>
                        </tr>--%>
                            <tr>
                                <td>
                                    <asp:Label ID="lblqty" Text='<%# (Eval("Quantity") == DBNull.Value  || (Eval("Quantity").ToString().Trim() == string.Empty)) ? string.Empty : Convert.ToDecimal(Eval("Quantity")).ToString("N0") %>'
                                        runat="server"></asp:Label>
                                    <span style="color: gray">pcs.</span>
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                    <ItemStyle CssClass="widhConQty widhConQty1" />
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <table style="width: 100%;" cellspacing="0" cellpadding="0">
                            <tr>
                                <td>Cut<br />
                                    Wastage %
                                </td>
                            </tr>
                        </table>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:HiddenField ID="hdnOrderdetailID" runat="server" Value='<%# Eval("OderDetailID") %>' />
                        <table cellpadding="0" cellspacing="0" style="width: 100%">
                            <tr>
                                <td style="border-bottom: 1px solid #ddd7d7;"></td>
                            </tr>
                        </table>
                    </ItemTemplate>
                    <ItemStyle CssClass="widhcol2" />
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <table style="width: 100%;">
                            <tr>
                                <td>Fabric Details/Color Print/Avg.
                                </td>
                            </tr>
                        </table>
                    </HeaderTemplate>
                    <ItemTemplate>
                    </ItemTemplate>
                    <ItemStyle CssClass="widhcol4" />
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <table>
                            <tr>
                                <td>Actual Fabric Required<br />
                                    <span style="color: Gray; font-size: 9px;">Contract<span style="vertical-align: center;">
                                        * </span>Avg.</span>
                                </td>
                            </tr>
                        </table>
                    </HeaderTemplate>
                    <ItemTemplate>
                    </ItemTemplate>
                    <ItemStyle CssClass="Required_width" />
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <table style="width: 100%">
                            <tr>
                                <td>Cut
                                    <br />
                                    Width
                                </td>
                            </tr>
                        </table>
                    </HeaderTemplate>
                    <ItemTemplate>
                    </ItemTemplate>
                    <ItemStyle CssClass="Required_width" />
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <table>
                            <tr>
                                <td>Available qty. to issue
                                </td>
                            </tr>
                        </table>
                    </HeaderTemplate>
                    <ItemTemplate>
                    </ItemTemplate>
                    <ItemStyle CssClass="Required_width" />
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <table>
                            <tr>
                                <td>Raise Cutting Request Date &nbsp;&nbsp;(Unit)
                                    <asp:CheckBox ID="chkraisecuttingall" Style="float: left;" runat="server" AutoPostBack="true"
                                        OnCheckedChanged="chkraisecuttingall_CheckedChanged" />
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlFactoryUnit" runat="server" DataTextField="name" DataValueField="id">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                        </table>
                    </HeaderTemplate>
                    <ItemTemplate>
                    </ItemTemplate>
                    <ItemStyle CssClass="Required_width" />
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <table>
                            <tr>
                                <td>Required Qty.<br>
                                    (Include Cut Wastage)
                                </td>
                            </tr>
                        </table>
                    </HeaderTemplate>
                    <ItemTemplate>
                    </ItemTemplate>
                    <ItemStyle CssClass="Required_width" />
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <table style="width: 100%;" class="innertable">
                            <tr>
                                <td style="padding: 0px; padding-top: 14px;">Challan No.
                                    <table style="width: 100%; height: 100%; border: 0px;">
                                        <tr>
                                            <td style="border: 0px; padding: 0px; color: Gray">
                                                <span style="margin-right: 10px;">Create</span>
                                                <span>View</spa>
                                            </td>
                                        </tr>
                                    </table>
                                </td>

                            </tr>
                        </table>
                    </HeaderTemplate>
                    <ItemTemplate>
                    </ItemTemplate>
                    <ItemStyle CssClass="IssueChallan_width" />
                </asp:TemplateField>

                <asp:TemplateField>
                    <HeaderTemplate>
                        <table style="width: 100%" class="">
                            <tr>
                                <td style="padding: 0px; padding-top: 12px; border-right: 1px solid darkgray; width: 50%;">Extra Stock Issue
                                    <table style="width: 100%; height: 100%; border: 0px;">
                                        <tr>
                                            <td style="border: 0px; padding-top: 0; height: auto; padding-bottom: 5px; color: Gray">
                                                <span style="margin-right: 10px;">Create</span>
                                                <span>View</spa>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td style="padding: 0px;">Total Issued
                                </td>

                            </tr>
                        </table>
                    </HeaderTemplate>
                    <ItemTemplate>
                    </ItemTemplate>
                    <ItemStyle CssClass="" Width="300px" />
                </asp:TemplateField>

                <asp:TemplateField Visible="false">
                    <HeaderTemplate>
                        <table style="width: 100%">
                            <tr>
                                <td>View<br />
                                    Ch. His.
                                </td>
                            </tr>
                        </table>
                    </HeaderTemplate>
                    <ItemTemplate>
                    </ItemTemplate>
                    <ItemStyle CssClass="" />
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <table>
                            <tr>
                                <td>Issue Complete
                                    <br>
                                    CutIssue Settl.
                                </td>
                            </tr>
                        </table>
                    </HeaderTemplate>
                    <ItemTemplate>
                    </ItemTemplate>
                    <ItemStyle Width="82px" />
                </asp:TemplateField>
                <asp:TemplateField Visible="false">
                    <HeaderTemplate>
                        <table>
                            <tr>
                                <td>Qty. left after issue complete
                                </td>
                            </tr>
                        </table>
                    </HeaderTemplate>
                    <ItemTemplate>
                    </ItemTemplate>
                    <ItemStyle Width="70px" />
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
    <div class="divspplier" style="display: none;">
        <table cellpadding="0" cellspacing="0" style="width: 100%;">
            <tr>
                <th colspan="2" style='background: #39589c !important; font-weight: 500; color: #fff !important; text-align: center'>Move stock/Debit quantity/Resi Shrink Qty <span style='float: right; padding-right: 10px; cursor: pointer; color: #fff'
                    title='Close' onclick='HideSupplierDiv2();'>X</span>
                </th>
            </tr>
            <tr>
                <td style="padding: 5px 5px;">
                    <span style="dispaly: inline-block; width: 80px;">Left Qty: </span>
                    <asp:Label ID="lblleftmoveqty" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="text-align: left; padding: 5px 5px;">
                    <span style="dispaly: inline-block; width: 80px;">Move To Stock: </span>
                    <asp:TextBox ID="txtmoveqty" onchange="OnchangeStockQty(this)" CssClass="number"
                        runat="server" Style="width: 80px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="text-align: left; padding: 5px 5px;">
                    <span style="dispaly: inline-block; width: 80px;">Move To Debit: </span>
                    <asp:TextBox ID="txtmovetodebit" onchange="chk(); OnchangeStockQty(this)" CssClass="number"
                        runat="server" Style="width: 80px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="text-align: left; padding: 5px 5px;">
                    <span style="dispaly: inline-block; width: 80px;">Resi Shrink Qty: </span>
                    <asp:TextBox ID="txtResiShrinkQty" onchange="OnchangeStockQty(this)" CssClass="number"
                        runat="server" Style="width: 80px"></asp:TextBox>
                </td>
            </tr>
             <tr>
                <td style="text-align: left; padding: 5px 5px;">
                    <span style="dispaly: inline-block; width: 80px;">Extra Wastage: </span>
                    <asp:TextBox ID="txtExtraWastageQty" onchange="OnchangeStockQty(this)" CssClass="number"
                        runat="server" Style="width: 80px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="text-align: left; padding: 5px 5px;">
                    <span style="dispaly: inline-block; width: 80px;">Particular: </span>
                    <asp:TextBox ID="txtparticular" Enabled="false" CssClass="allownumericwithoutdecimal"
                        runat="server" Style="width: 195px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="float: right; padding: 10px 10px">
                    <div class="btnMoveQty printHideButton" id="divSubmit" onclick="return UpdateStockQtysub();">
                        Submit
                    </div>
                </td>
            </tr>
        </table>
    </div>
    <asp:Button ID="btnshow" runat="server" Style="display: none;" CssClass="btnshowsrv"
        OnClick="btnshow_Click" />
    <div class="backColorFade">
        <div id="here_table" class="Qa_grid_table">
        </div>
    </div>
</asp:Content>
