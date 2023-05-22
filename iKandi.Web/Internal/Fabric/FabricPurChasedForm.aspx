<%@ Page Title="" Language="C#" MasterPageFile="~/layout/Secure.Master" AutoEventWireup="true"
    CodeBehind="FabricPurChasedForm.aspx.cs" Inherits="iKandi.Web.Internal.Fabric.FabricPurChasedForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_head" runat="server">
    <style type="text/css">
      @media print{
             @page {
                    size: Portrait;
                 }
          
             }
            
      @media print {
            @page {
                margin: 20px;
                
            }
            body {
                margin: 20px;
            }
        }           
             
        body {
            background: #fff none repeat scroll 0 0;
            font-family: arial !important;
        }
        .receivehis tbody tr th
        {
            background-color: #dddfe4;
            }

        table {
            font-family: arial;
            border-color: #dbd8d8;
            border-collapse: collapse;
            text-transform: capitalize;
        }

            table td {
                height: 15px; 
                font-size: 10px;
            }




        .HeaderClass td {
            background: #dddfe4;
            font-weight: normal;
            color: #575759;
            font-family: arial;
            font-size: 11px;
            padding: 0px 0px;
            border-color: #999;
            font-family: arial !important;
        }

        .purchase_order {
            width: 1100px;
            border: 1px solid #dbd8d8;
        }

            .purchase_order input {
                margin: 1px 0px;
            }

        input[type="text"] {
            margin: 2px 1px;
            font-size: 10px !important;
            font-family: Arial !important;
            height: 15px;
        }

        .purchase_order thead th {
            border: 1px solid #dbd8d8;
            padding: 5px 0px;
            text-align: center;
            text-align: center;
            font-weight: 600 !important;
            font-size: 12px;
        }

        .purchase_order tbody th {
            border: 1px solid #999;
            padding: 5px 7px;
            font-weight: 500;
        }

        .purchase_order tbody td {
            padding: 0px 5px;
            border-color: #dbd8d8;
        }

        select {
            width: 90px;
            height: 19px;
        }

        .supplieretadatetable td input[type="text"] {
            width: 92%;
            margin: 1px 0px;
            font-size: 10px !important;
            font-family: Arial !important;
        }

        .supplieretadatetable td {
            text-align: center;
        }
        

        #ctl00_cph_main_content_grdqtyrange th {
            background: #dddfe4;
            padding: 2px 2px;
            width: 98px;
            text-align: center;
            border-color: #999;
            color: #575759;
        }

        ul {
            list-style-type: none;
            margin: 0;
            padding: 0px 2px;
            max-width: 98%;
        }

        li {
            padding: 1px 0px 1px;
            font-size: 10px;
            line-height: 13px;
            color: Gray;
            font-family: arial;
            text-transform: capitalize;
        }

        .receivehis {
            float: left;
            margin-right: 10px;
        }

      .receivehis th {
                background: #dddfe4;
                padding: 2px 2px;
                text-align: center;
                border: 1px solid #999;
                color: gray;
            }

      .receivehis td:first-child {
                border-left-color: #999 !important
            }

        .lastrow td {
            text-align: center;
        }

        .txtcenter {
            text-align: center
        }

        .lastrow tr:nth-last-child(1) > td {
            border-bottom-color: #999 !important;
        }

        @media print {
            body {
                -webkit-print-color-adjust: exact;
            }

            .printHideButton {
                display: none;
            }
        }
 
        a.tooltips {
            position: relative;
            display: inline;
        }
        .boldness
        {
             font-weight:bold;
        }
        .color_black{color:Black !important;}

            a.tooltips span {
                position: absolute;
                width: 350px;
                color: #FFFFFF;
                background: #000000;
                height: 30px;
                line-height: 30px;
                text-align: center;
                visibility: hidden;
                border-radius: 6px;
            }

                a.tooltips span:after {
                    content: '';
                    position: absolute;
                    top: 100%;
                    left: 35%;
                    margin-left: -8px;
                    width: 0;
                    height: 0;
                    border-top: 8px solid #000000;
                    border-right: 8px solid transparent;
                    border-left: 8px solid transparent;
                }

        a:hover.tooltips span {
            visibility: visible;
            opacity: 0.8;
            bottom: 30px;
            left: 50%;
            margin-left: -140px;
            z-index: 999;
        }

        #sb-wrapper-inner {
            border: 5px solid #999;
            border-radius: 4px;
        }

        #ctl00_cph_main_content_divguidline div {
            border-color: #999 !important;
            padding-top: 5px !important;
        }
        .ddlisNotQuoted
        {
           background-color:gray !important ; 
            
            }
     .ddlisQuoted
        {
           background-color:white; 
            
            }
        .btnClose {
            margin-left: 10px;
            color: rgb(255, 255, 255);
            font-size: 12px !important;
            float: left;
            font-weight: 600;
            width: 52px;
            cursor: pointer;
            background: rgb(19, 167, 71);
            height: 24px !important;
            line-height: 24px !important;
            border: none !important;
            border-radius: 2px;
            text-align: center;
            text-transform: capitalize;
            font-family: arial !important;
        }

            .btnClose:hover {
                color: red;
            }

        .btnSubmit {
            font-size: 12px !important;
            cursor: pointer;
            background: rgb(19, 167, 71);
            height: 24px !important;
            line-height: 24px !important;
            border: none !important;
            border-radius: 2px;
            margin-left: 5px;
            text-align: center;
            text-transform: capitalize;
            font-family: arial !important;
        }

            .btnSubmit:hover {
                color: Yellow !important;
            }

        .footerCotent #btnok {
            background: green;
            color: #fff;
            cursor: pointer;
            padding: 1px 7px;
            border: 1px solid green;
            border-radius: 2px;
            font-size: 11px;
            position: relative;
            transition: .5s ease;
            top: 8px;
            left: 157px;
            right: 0px;
        }

        .footerCotent #Btncancel {
            background: red;
            color: #fff;
            cursor: pointer;
            padding: 1px 7px;
            border: 1px solid red;
            border-radius: 2px;
            font-size: 11px;
            position: relative;
            top: 8px;
            left: 4px;
            right: 0px;
            float: right;
        }

        .footerCotent {
            height: auto;
            width: 94%;
            margin: 5px auto;
            text-align: right;
            padding-right: 5px;
        }

        .btnPrint {
            margin-left: 10px;
            font-size: 12px !important;
            float: left;
            color: rgb(255, 255, 255);
            font-weight: 500;
            width: 52px;
            cursor: pointer;
            background: #39589c !important;
            height: 24px !important;
            line-height: 24px !important;
            border: none !important;
            border-radius: 2px;
            text-align: center;
            text-transform: capitalize;
            font-family: arial !important;
        }

            .btnPrint:hover {
                color: Yellow !important;
            }

        #secure_footer {
            display: none;
        }

        #secure_banner_cor {
            padding: 0px !important;
        }

        #main_content {
            width: 100% !important;
        }

        #secure_center_contentWrapper {
            width: 99.5% !important;
        }

        input[readonly] {
            background: #dddddd;
            color: #8e8e8e;
            border: 1px solid #666;
            font-family: Arial;
            font-size: 10px !important;
        }

        .displaynoneSup th:last-child {
            display: none;
        }

        .displaynoneSup td:last-child {
            display: none;
        }

        .AuthoriImage {
            max-width: 116px;
            min-width: 100px;
            max-height: 46px;
            position: relative;
            top: -5px;
            right: 2%;
        }

        .AuthoriImage img {
                width: 80%;
                height: 29px;
            }

        .center_bodyCentering {
            overflow-x: hidden;
        }

        .border_right_color {
            border-right-color: #999 !important;
        }

        #ctl00_cph_main_content_grdqtyrange {
            text-align: center;
        }

            #ctl00_cph_main_content_grdqtyrange td:first-child {
                border-left-color: #999 !important;
            }

            #ctl00_cph_main_content_grdqtyrange td:last-child {
                border-right-color: #999 !important;
            }

            #ctl00_cph_main_content_grdqtyrange tr:nth-last-child(1) > td {
                border-bottom-color: #999 !important;
            }

        .colwidthG {
            min-width: 40px;
            max-width: 40px;
            height: 29px;

        }

        .colwidthC {
            min-width: 40px;
            max-width: 40px;
            height: 29px;
        }

        td.colwidthG {
            border-right: 1px solid #999;
        }

        .colwidthinnr {
            min-width: 40px;
            max-width: 49px;
            height: 29px;
            line-height: 30px;
        }

        td.colwidthinnr {
            border-right: 1px solid #dbd8d8;
            <%--display:none; --%>         
        }
        

        .tdpadding0 {
            padding: 0px !important;
        }

        input[type="checkbox"] {
            position: relative;
            top: 2px;
        }

     /*       .AuthorizedSignatorydate {
                float: right;
                right: 35%;
                position: relative;
            }*/

        .AuthorizedSignatorydate1 {
            float: left;
            position: relative;
           <%-- <%--left: 46%;--%>--%>
        }

        .PositionRight {
            right: 11% !important;
        }

        .RightCheckBox input[type="checkbox"] {
            right: 5px;
        }

        .center {
            margin: auto;
            width: 90%;
            border: 3px solid #73AD21;
            padding: 10px;
            margin-top: -416px;
            background: #39589c;
        }
        .hide
        {
            display:none;
        }
        .ModelPo {
            background: #fff;
            width: 300px;
            margin: -32% auto;
            text-align: center;
            position: relative;
            z-index: 100000;
        }

        .ModelPo2 {
            background: #e6e6e6;
            width: 570px;
            margin: -40% 15%;
            text-align: center;
            position: relative;
            z-index: 100000;
            padding: 0px 0px 15px;
            border: 2px solid darkgray;
        }

        .backcolorpo {
            background: #eae7e7;
            width: 285px;
            min-height: 89px;
            padding: 0px 0px;
            position: fixed;
            /* box-shadow: 0px 0px 1px 3px #c5a0a099; */
            border-radius: 2px;
            top: calc(50% - 50px/2);
            left: calc(40% - 50px/2)
        }

        .BodyContect h2 {
            color: #fff;
            background: #39589c;
            width: 100%;
            padding: 8px 0px;
        }

        .backcolorpo .btnOk {
            background: #4CAF50;
            color: #fff;
            border: 1px solid #4CAF50;
            border-radius: 2px;
            cursor: pointer;
            font-size: 12px;
        }

        .backcolorpo .btnCancel {
            background: #39589c;
            color: #fff;
            border: 1px solid #39589c;
            border-radius: 2px;
            cursor: pointer;
            font-size: 12px;
        }

        .BodyContect {
            margin-bottom: 10px;
        }

        .etadate {
            font-size: 11px !important;
            width: 80% !important;
        }

        .tableCenter td input {
            text-align: center;
        }

        .tableCenter td {
            text-align: center;
            border: 1px solid #9999;
        }

            .tableCenter td:last-child {
                border-right-color: #999;
            }

        .tableCenter tr:last-child > td {
            border-bottom-color: #999;
        }

        input[type="radio"] {
            position: relative;
            top: 2px
        }

        <style >
        /* tr:nth-child(even) */
        tr.even {
            background-color: #F4F4F8;
        }
        /* tr:nth-child(odd) */
        tr.odd {
            background-color: #EFF1F1;
        }

        @media screen and (max-width:1066px) {
            .ModelPo2 {
                margin: -60% 10%;
            }
        }

        .HistoryUl {
            position: relative;
            left: -1px;
            margin: 0px;
        }

        .imgviewhi {
            max-height: 18px;
            max-width: 33px;
            vertical-align: bottom;
        }

        #ctl00_cph_main_content_divbipladdress span {
            font-size: 11px !important;
        }

        HistoryUl ::marker {
            content: "•";
            color: red;
            display: inline-block;
            width: 1em;
            margin-left: -1em
        }

        .LiCircel {
            width: 7px;
            height: 7px;
            border-radius: 50px;
            background: gray;
            display: inline-block;
            margin-right: 3px;
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

        #sb-wrapper-inner {
            background: #fff;
        }

        .center_bodyCentering {
            background: #fff !important;
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
                background: url(../../App_Themes/ikandi/images1/loading128.gif) 50% 50% no-repeat opacity:1;
            }

            #ctl00_cph_main_content_grdfabricpurchased_ctl04_txtsendQty readonly {
                background-color: #A9A9A9!important;
            }
            
/*dinesh*/  

 </style>
    <script type="text/javascript" src="../../js/service.min.js"></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("../../js/jquery.autocomplete.js")%>'></script>
    <script type="text/javascript" src="../../js/form.js"></script>
    <script src="../../js/jquery-1.11.0.min.js" type="text/javascript"></script>
    <script type="text/javascript">

        var weekday = new Array(7);
        weekday[0] = "Sunday";
        weekday[1] = "Monday";
        weekday[2] = "Tuesday";
        weekday[3] = "Wednesday";
        weekday[4] = "Thursday";
        weekday[5] = "Friday";
        weekday[6] = "Saturday";
        var ddlSupplierName = '<%=ddlSupplierName.ClientID%>';


        var serviceUrl = '<%= ResolveUrl("~/Webservices/iKandiService.asmx/") %>';
        var proxy = new ServiceProxy(serviceUrl);
        var urls = "../../Webservices/iKandiService.asmx";
        var Potype = '<%=this.Potype %>';
        function isPositiveInteger(n) {
            return 0 === n % (!isNaN(parseFloat(n)) && 0 <= ~ ~n);
        }
        function pageLoad() {

            currentstagee = $('#ctl00_cph_main_content_hdncurrentstage').val();
            if (FabType.toLowerCase() == 'GRIEGE'.toLowerCase() || FabType.toLowerCase() == 'FINISHING'.toLowerCase() || (FabType.toLowerCase() == 'RFD'.toLowerCase() && currentstagee == "1")) {
                $('#ctl00_cph_main_content_Order_text').text("Purchase Order");
            }
            else {
                $('#ctl00_cph_main_content_Order_text').text("Process Order");
            }


            // $("#sb-container").contents().find("#sb-wrapper-inner").css('height', '350px');
            //            $("#sb-wrapper-inner").css("width", "20px");
            var SupplierNasterID = $("#" + ddlSupplierName).val();
            MasterPoID = '<%=this.MasterPoID %>';
            FabType = '<%=this.Fabtype %>';
            var PoNumberCode = '<%=lblPoNo.ClientID%>';
            var currentstagenumber = '<%=this.currentstage %>';
            $(':input').live('focus', function () {
                $(this).attr('autocomplete', 'off');
            });
            $("span").each(function (index, elem) {
                //debugger;
                if (elem = $("[id$='lblcolorprint']")) {
                }
                else {
                    if (isPositiveInteger($(elem).text()))
                        $(elem).text(numberWithCommas($(elem).text()));
                }
            });

            //ManipulateGrid();
            $("#ctl00_cph_main_content_grdqtyrange_ctl02_txtdates").val($("#ctl00_cph_main_content_hdntxtdates").val());
            $("#ctl00_cph_main_content_txtPoDate").val($("[id$=_hdnstorepodate]").val());
            $("#" + ddlSupplierName).val($("[id$=_hdnstoresupplierid]").val());
            $("[id$=_txtETADate]").val($("[id$=_hdnstoreetadate]").val());
            $("[id$=_txtsendQty]").val($("[id$=_hdnstoresendqty]").val());
            $("[id$=_txtreceivedqty]").val($("[id$=_hdnstorereceivedqty]").val());
            $("#ctl00_cph_main_content_grdfabricpurchased_ctl04_ddlunits").val($("[id$=_hdnstoreunitsid]").val());
            $("[id$=_txtrateSupplierQuotedRate]").val($("[id$=_hdnstorerate]").val());
            $("[id$=_lbltotalAmount]").text($("[id$=_hdnstoretotalamount]").val());
            $("[id$=_lblPoNo]").text($("[id$=_hdintialsuppliercode]").val());

            $("[id$=_hdnstorepodate]").val($("#ctl00_cph_main_content_txtPoDate").val());
            $("[id$=_hdnstoresupplierid]").val($("#" + ddlSupplierName).val());
            $("[id$=_hdnstoreetadate]").val($("[id$=_txtETADate]").val());
            //            $("[id$=_hdnstoresendqty]").val($("[id$=_txtsendQty]").val());
            //            $("[id$=_hdnstorereceivedqty]").val($("[id$=_txtreceivedqty]").val());
            $("[id$=_hdnstoreunitsid]").val($("#ctl00_cph_main_content_grdfabricpurchased_ctl04_ddlunits").val());
            $("[id$=_hdnstorerate]").val($("[id$=_txtrateSupplierQuotedRate]").val());
            $("[id$=_hdnstoretotalamount]").val($("[id$=_lbltotalAmount]").text());
            $("[id$=_hdintialsuppliercode]").val($("[id$=_lblPoNo]").text());

            $(".storedata").change(function () {

                $("[id$=_hdnstorepodate]").val($("#ctl00_cph_main_content_txtPoDate").val());
                $("[id$=_hdnstoresupplierid]").val($("#" + ddlSupplierName).val());
                $("[id$=_hdnstoreetadate]").val($("[id$=_txtETADate]").val());
                //                $("[id$=_hdnstoresendqty]").val($("[id$=_txtsendQty]").val());
                //                $("[id$=_hdnstorereceivedqty]").val($("[id$=_txtreceivedqty]").val());
                $("[id$=_hdnstoreunitsid]").val($("#ctl00_cph_main_content_grdfabricpurchased_ctl04_ddlunits").val());
                $("[id$=_hdnstorerate]").val($("[id$=_txtrateSupplierQuotedRate]").val());
                $("[id$=_hdnstoretotalamount]").val($("[id$=_lbltotalAmount]").text());
                $("[id$=_hdintialsuppliercode]").val($("[id$=_lblPoNo]").text());
            });
            proxy.invoke("GetSupplierIntialCode", { flag: "CHECKSRV", SupplierMasterID: MasterPoID }, function (result) {
                if (result[0] == 'EXIST') {
                    //                    $('#ctl00_cph_main_content_txtETADate').attr('disabled', 'disabled');
                    $('#ctl00_cph_main_content_grdfabricpurchased_ctl04_txtrateSupplierQuotedRate').attr('disabled', 'disabled');
                }
            }, onPageError, false, false);

            //            proxy.invoke("GetSupplierIntialCode", { flag: "GETSUPPLIERCODE", SupplierMasterID: SupplierNasterID, PoID: MasterPoID }, function (result) {
            //                $("#" + PoNumberCode).text(result[0]);
            //            }, onPageError, false, false);


            if (FabType.toLowerCase() == 'DYED'.toLowerCase() || FabType.toLowerCase() == 'PRINT'.toLowerCase() || FabType.toLowerCase() == 'RFD'.toLowerCase() || FabType.toLowerCase() == 'Embellishment'.toLowerCase() || FabType.toLowerCase() == 'Embroidery'.toLowerCase()) {

                if (FabType.toLowerCase() == 'RFD'.toLowerCase() && currentstagenumber == "1") {

                    $('#ctl00_cph_main_content_grdfabricpurchased_ctl04_txtreceivedqty').removeAttr('readonly', 'readonly');
                    $('#ctl00_cph_main_content_grdfabricpurchased_ctl04_txtsendQty').attr('readonly', 'readonly');
                    $('#ctl00_cph_main_content_grdfabricpurchased_ctl04_txtsendQty').val('');
                }
                else {
                    $('#ctl00_cph_main_content_grdfabricpurchased_ctl04_txtsendQty').removeAttr('readonly', 'readonly');
                    $('#ctl00_cph_main_content_grdfabricpurchased_ctl04_txtreceivedqty').attr('readonly', 'readonly');

                }

                validatepageChangeState();
            }

            $("#secure_greyline").css({ "display": "none" });

            $(".datesfileds").keydown(function (e) {
                var key = e.keyCode || e.charCode;
                e.preventDefault();
                e.stopPropagation();

            });
            //                        $("#ctl00_cph_main_content_txtETADate").change(function () {
            //                            
            //                            var date = new Date();
            //                            $(".etadate").datepicker({
            //                                minDate: new Date($("#ctl00_cph_main_content_txtPoDate").val()),
            //                                maxDate: new Date($("#ctl00_cph_main_content_txtETADate").val()),
            //                                dateFormat: "dd M y (D)",
            //                                defaultDate: "+1w",
            //                                changeMonth: true,
            //                                numberOfMonths: 3
            //                            });
            //                            
            //                        });
            var minSelecteddate = $("#ctl00_cph_main_content_txtPoDate").val();
            var minSelectRowparts = minSelecteddate.split(' ');
            var min = new Date('20' + minSelectRowparts[2], retunmonth(minSelectRowparts[1]) - 1, minSelectRowparts[0]);

            var maxSelecteddate = $("#ctl00_cph_main_content_txtETADate").val();
            var maxSelectRowparts = maxSelecteddate.split(' ');
            var max = new Date('20' + maxSelectRowparts[2], retunmonth(maxSelectRowparts[1]) - 1, maxSelectRowparts[0]);
            var date = new Date();
            $(".etadate").datepicker({

                //                beforeShowDay: noSunday,
                minDate: new Date($("#ctl00_cph_main_content_txtPoDate").val()),
                maxDate: new Date($("#ctl00_cph_main_content_txtETADate").val()),
                //                minDate: new Date(min),
                //                maxDate: new Date(max),
                dateFormat: "dd M y (D)",
                defaultDate: "+1w",
                changeMonth: true,
                numberOfMonths: 1

            });

            function noSunday(date) {

                return [date.getDay() != 0 && date.getDay() != 6, ''];

                //return [date!='2020-10-28'];
            };
            //var sun = new Date(input.getFullYear(), input.getMonth(), getDay() + (input.getDate() - 6));

            // var array = ["2020-10-28", "2013-03-15", "2013-03-16"]
            $('.th2').datepicker({
                dateFormat: "dd M y (D)",
                minDate: new Date($("#ctl00_cph_main_content_txtPoDate").val()),
                //  beforeShowDay: noSunday,
                //                 beforeShowDay: function(date){
                //        var string = $.datepicker.formatDate('yy-mm-dd', date);
                //        return [ array.indexOf(string) == -1 ]
                //    },
                onSelect: function () {
                    //debugger;
                    var minSelecteddate = $("#ctl00_cph_main_content_txtPoDate").val();
                    var minSelectRowparts = minSelecteddate.split(' ');
                    var min = new Date('20' + minSelectRowparts[2], retunmonth(minSelectRowparts[1]) - 1, minSelectRowparts[0]);

                    var maxSelecteddate = $("#ctl00_cph_main_content_txtETADate").val();
                    var maxSelectRowparts = maxSelecteddate.split(' ');
                    var max = new Date('20' + maxSelectRowparts[2], retunmonth(maxSelectRowparts[1]) - 1, maxSelectRowparts[0]);

                    var string = $.datepicker.formatDate('yy-mm-dd', $('.th2').datepicker("getDate"));
                    var string2 = $.datepicker.formatDate('yy-mm-dd', max);

                    //                    if (string != string2) {
                    //                       
                    //                    }
                    ////                    if (weekday[$('.th2').datepicker("getDate").getDay()] == 'Sunday') {
                    ////                        alert('Sunday not allowed');
                    ////                        return false;
                    ////                    }
                    //                    beforeShowDay: function (date) {
                    //                        var day = date.getDay();
                    //                        return [day != 0, ''];
                    //                    }


                    Resetetagrd();
                    //                    $('.etadate').datepicker('setDate', null);
                    var date = new Date();
                    $(".etadate").datepicker({
                        dateFormat: "dd M y (D)",
                        defaultDate: "+1w",
                        changeMonth: true,
                        numberOfMonths: 1,
                        autoclose: true,
                        inline: true
                        //                        beforeShowDay: noSunday

                    });
                    $(".etadate").datepicker("option", "minDate", new Date($("#ctl00_cph_main_content_txtPoDate").val()));
                    $(".etadate").datepicker("option", "maxDate", new Date($("#ctl00_cph_main_content_txtETADate").val()));

                    $('#ctl00_cph_main_content_txtetabreakedate0').val(this.value);
                    $('#ctl00_cph_main_content_lbletabreakedate0').text(this.value);
                }

            });

            ////            $(".th").datepicker({ dateFormat: 'dd M y (D)' });

            ////            var datepicker2 = $('.th2').datepicker(
            ////                             { minDate: ($(".th").datepicker("getDate")), dateFormat: 'dd M y (D)' }

            ////                         );

            CheckSelectedSupplier();




            if (Potype == 'RERAISE' || Potype == 'RAISE') {

                if (FabType.toLowerCase() != 'DYED'.toLowerCase() && FabType.toLowerCase() != 'PRINT'.toLowerCase() && FabType.toLowerCase() != 'RFD'.toLowerCase()) {
                    //GetSupplierRateChange();
                    validatepageChangeState();
                }


            }

            $(".spchange").change(function () {

                if ($(this).val() != "-1") {
                    //                       
                    $('input[type=text]').removeAttr('disabled', 'disabled');
                    $("input").removeAttr('disabled', 'disabled');
                    $('input[type=text]').removeAttr('title');
                    $('#ctl00_cph_main_content_grdfabricpurchased_ctl04_ddlunits').removeAttr('disabled', 'disabled');


                }
                else {
                    $("input").attr('disabled', 'disabled');
                    $("input").attr('disabled', 'disabled');
                    $("#ctl00_cph_main_content_grdfabricpurchased_ctl04_ddlunits").attr('disabled', 'disabled');
                    $('input[type=text]').attr('title', 'your must have to select supplier to fill value');

                    ReloadFunctionIfError("manual");
                    $("#ctl00_cph_main_content_chkAuthorizedSignatory").removeAttr('disabled', 'disabled');
                    $("#ctl00_cph_main_content_chkpartysignature").removeAttr('disabled', 'disabled');

                    MailCheck()
                }

            });


            $("#ctl00_cph_main_content_txtETADate").keydown(function (e) {
                if (e.which == 8 && !$(':focus').length) {
                    e.preventDefault();
                }
            });

            DisableFiledByPo_type();
            //    
            Supplier = '<%=this.ParentPageUrlWithQuerystring %>';
            if (Supplier == "SuPPLIERVIEW") {

                DisabledFiledForSupplierView();
                $("#divmail").hide();
            }

            //            ValidateMinReceiveQty();
            if (Potype == 'RAISE') {

                $(".hisclass").hide();


            }
            else {
                //if ($("#ctl00_cph_main_content_chkAuthorizedSignatory").is(':checked') && $("#ctl00_cph_main_content_chkpartysignature").is(':checked')) {
                // Above is comented and below is writen to open mail funcanality in regvise po
                if ($("#ctl00_cph_main_content_chkAuthorizedSignatory").is(':checked')) {
                    //$("#ctl00_cph_main_content_btnSubmit").show();
                    if (Supplier != "SuPPLIERVIEW") {

                        $("#divmail").show();
                    }

                }
            }
            var elmnt = document.getElementById("ctl00_cph_main_content_grdfabricpurchased");
            //var txt = "Height with padding and border: " + elmnt.offsetWidth + "px<br>";

            //            window.parent.Setwidth(parseInt(elmnt.offsetWidth) + 27);


            //window.parent.Shadowbox.close();
        }
        $(function () {


        });
        function MailSent() {

            window.parent.Shadowbox.close();
        }
        function CheckSelectedSupplier() {
            var SupplierNasterID = $("#" + ddlSupplierName).val();
            //               
            if (SupplierNasterID == "-1") {
                $("input").attr('CheckSelectedSupplier', 'disabled');
                $('input[type=text]').attr('title', 'your must have to select supplier to fill value');

                $("#ctl00_cph_main_content_grdfabricpurchased_ctl04_txtrateSupplierQuotedRate").val("");
                //$("#ctl00_cph_main_content_txtETADate").val("");
                //  $("#ctl00_cph_main_content_grdfabricpurchased_ctl04_ddlunits").val("-1");
                $("#ctl00_cph_main_content_grdfabricpurchased_ctl04_ddlunits").removeAttr('disabled', 'disabled');
                $("#ctl00_cph_main_content_grdfabricpurchased_ctl04_lbltotalAmount").text("");
                // $("#ctl00_cph_main_content_chkAuthorizedSignatory").removeAttr('disabled', 'disabled');
                // $("#ctl00_cph_main_content_chkpartysignature").removeAttr('disabled', 'disabled');
                $("#divconversionorder").css("display", "none");

            }
            else {
                $("input").removeAttr('disabled', 'disabled');
                $("#ctl00_cph_main_content_grdfabricpurchased_ctl04_ddlunits").removeAttr('disabled', 'disabled');
                $('input[type=text]').removeAttr('title', 'your must have to select supplier to fill value');
            }

        }
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
            if (el.value.length > 4 && charCode != 46) {
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


        function getSelectionStart(o) {
            if (o.createTextRange) {
                var r = document.selection.createRange().duplicate()
                r.moveEnd('character', o.value.length)
                if (r.text == '') return o.value.length
                return o.value.lastIndexOf(r.text)
            } else return o.selectionStart
        }
        function closeButton() {

            this.parent.Shadowbox.close();

        }
        function numberWithCommas(x) {
            return x.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",");
        }

        function ValidateMinReceiveQty(elem) {

            var resulterr = "";
            var Potype = '<%=this.Potype %>';
            var Fabtypes = '<%=this.Fabtype %>';
            var PoNumber = '<%=this.PoNumber %>';
            MasterPoID = '<%=this.MasterPoID %>';
            var FabricQualityID = '<%=this.FabricQualityID %>';
            var resullt = "";
            var validateRemaningQty = '<%=this.RemaningQty %>';
            var currentstagenumber = '<%=this.currentstage %>';
            var RemainingQtys = $("#<%= grdfabricpurchased.ClientID %>_" + "ctl04" + "_hdnremainingQty").val();
            var Qtys = 0;
            var minsrv = $("#ctl00_cph_main_content_hdnminsrv").val()
            var oldRececiveQty = $("#ctl00_cph_main_content_hdnstorereceivedqty").val();

            if (currentstagenumber > 1) {
                var oldRececiveQty = $("#ctl00_cph_main_content_hdnstoresendqty").val();
            }

            if (minsrv == "") {
                minsrv = 0
            }
            if (Fabtypes.toUpperCase() == 'GRIEGE'.toUpperCase() || Fabtypes.toUpperCase() == 'FINISHING'.toUpperCase() || (Fabtypes.toUpperCase() == 'RFD'.toUpperCase() && currentstagenumber == "1")) {
                Qtys = $("#<%= grdfabricpurchased.ClientID %>_" + "ctl04" + "_txtreceivedqty").val().replace(",", "");
            }
            else {
                Qtys = $("#ctl00_cph_main_content_grdfabricpurchased_ctl04_txtsendQty").val().replace(",", "");
            }
            if (RemainingQtys == "") {
                RemainingQtys = validateRemaningQty;
            }
            if (Qtys == "") {
                Qtys = 0

            }
            if (oldRececiveQty == "") {
                oldRececiveQty = 0;
            }
            var diif = (parseInt(Qtys.replace(",", "")) - parseInt(oldRececiveQty.replace(",", "")));

            if (diif < 0) {
                if (parseInt(minsrv) > 0) {
                    if (parseInt(Qtys) < parseInt(minsrv)) {
                        //    
                        resulterr = "Qty cannot be less than total SRV qty :" + minsrv;

                        $("#ctl00_cph_main_content_grdfabricpurchased_ctl04_txtreceivedqty").val($("#ctl00_cph_main_content_hdnstorereceivedqty").val());
                        $("#ctl00_cph_main_content_grdfabricpurchased_ctl04_txtsendQty").val($("#ctl00_cph_main_content_hdnstoresendqty").val());
                        //Resetetagrd();
                    }
                }
            }
            else if (diif > 0) {
                //                if (parseInt(minsrv) > 0) {
                if (parseInt(Qtys) > (parseInt(RemainingQtys) + parseInt(oldRececiveQty.replace(",", "")))) {
                    //    
                    resulterr = "Qty cannot be greater than available qty :" + (parseInt(RemainingQtys));
                    $("#ctl00_cph_main_content_grdfabricpurchased_ctl04_txtreceivedqty").val($("#ctl00_cph_main_content_hdnstorereceivedqty").val());
                    $("#ctl00_cph_main_content_grdfabricpurchased_ctl04_txtsendQty").val($("#ctl00_cph_main_content_hdnstoresendqty").val());
                    $("#ctl00_cph_main_content_lbltoqty0").text(oldreceivedqty);
                    Resetetagrd();
                }
                //}
            }
            //            if (parseInt(Qtys) > parseInt(minsrv)) {
            //                //    
            //                resulterr = "Qty cannot be greater than total SRV qty :" + minsrv;

            //                $("#ctl00_cph_main_content_grdfabricpurchased_ctl04_txtreceivedqty").val($("#ctl00_cph_main_content_hdnstorereceivedqty").val());
            //                $("#ctl00_cph_main_content_grdfabricpurchased_ctl04_txtsendQty").val($("#ctl00_cph_main_content_hdnstoresendqty").val());
            //                //Resetetagrd();
            //            }
            //            else if (parseInt(Qtys) < parseInt(minsrv)) {
            //                //    
            //                resulterr = "Qty cannot be less than total SRV qty :" + minsrv;

            //                $("#ctl00_cph_main_content_grdfabricpurchased_ctl04_txtreceivedqty").val($("#ctl00_cph_main_content_hdnstorereceivedqty").val());
            //                $("#ctl00_cph_main_content_grdfabricpurchased_ctl04_txtsendQty").val($("#ctl00_cph_main_content_hdnstoresendqty").val());
            //                //Resetetagrd();
            //            }
            //            else {
            //                //                Resetetagrd();
            //            }
            //                        
            //                    }.
            //            if (Potype == 'RERAISE') {
            //                proxy.invoke("ValidateMinReceiveQty", { flag: "VALIRECIVEQTY", SupplierMasterID: MasterPoID }, function (result) {
            //                    if (parseInt(Qtys) < parseInt(result[0])) {
            //                           
            //                        resulterr = "Qty cannot be less than total SRV qty :" + result[0];

            //                        $("#ctl00_cph_main_content_grdfabricpurchased_ctl04_txtreceivedqty").val($("#ctl00_cph_main_content_hdnstorereceivedqty").val());
            //                        $("#ctl00_cph_main_content_grdfabricpurchased_ctl04_txtsendQty").val($("#ctl00_cph_main_content_hdnstoresendqty").val());
            //                        //$("#<%= grdfabricpurchased.ClientID %>_" + "ctl04" + "_txtreceivedqty").val(numberWithCommas($("#<%= grdfabricpurchased.ClientID %>_" + "ctl04" + "_hdnreceivedqty").val()));
            //                        // ConversionValueChange('OK');
            //                        //validatepageChangeState();
            //                        Resetetagrd();
            //                        
            //                    }
            //                }, onPageError, false, false);
            //            }

            return resulterr;
        }
        function validatepageChangeState() {

            // debugger;

            if ($('#ctl00_cph_main_content_grdfabricpurchased_ctl04_ddlsupplytype').val() == '1') {
                $('.colwidthG:first-child').css("display", "none");
                $('.colwidthinnr:first-child').css("display", "none");

            }



            var SupplierNasterID = $("#" + ddlSupplierName).val();
            var SupplierName = $("#ctl00_cph_main_content_ddlSupplierName:selected").text(); // shubhendu

            if (SupplierNasterID == "-1") {
                return;
            }
            if ($("#<%= grdfabricpurchased.ClientID %>_" + "ctl04" + "_txtrateSupplierQuotedRate").val() == "") {
                $("#<%= grdfabricpurchased.ClientID %>_" + "ctl04" + "_txtrateSupplierQuotedRate").val($("#ctl00_cph_main_content_grdfabricpurchased_" + "ctl04" + "_hdnrateSupplierQuotedRate").val());
                //  $("#<%= grdfabricpurchased.ClientID %>_" + "ctl04" + "_txtrateSupplierQuotedRate").val($("[id$=_hdnstorerate]").val()); //shubhendu

            }
            var SupplierQuotedRate = $("#<%= grdfabricpurchased.ClientID %>_" + "ctl04" + "_txtrateSupplierQuotedRate").val();
            var ReceviedQty = $("#<%= grdfabricpurchased.ClientID %>_" + "ctl04" + "_txtreceivedqty").val().replace(",", "");
            if (ReceviedQty == "") {
                ReceviedQty = 0;
            }
            if (SupplierQuotedRate == "") {
                SupplierQuotedRate = 0;
                SupplierQuotedRate = $("#ctl00_cph_main_content_grdfabricpurchased_" + "ctl04" + "_hdnrateSupplierQuotedRate").val();
            }
            var TotalReceviedQty = numberWithCommas(Math.round((parseFloat($("#ctl00_cph_main_content_grdfabricpurchased_ctl04_txtreceivedqty").val().replace(",", ""))) * (parseFloat(SupplierQuotedRate)), 0));

            // var TotalReceviedQty = numberWithCommas(Math.round((parseFloat(ReceviedQty)) * (parseFloat(SupplierQuotedRate)), 0));
            if (TotalReceviedQty <= 0) {

                //                alert("Total amount is 0 please check your rate & received qty");
                if (SupplierNasterID != -"1") {
                    var QuotedRate = $("#<%= grdfabricpurchased.ClientID %>_" + "ctl04" + "_hdnrateSupplierQuotedRate").val();
                    var ReceviedQty = $("#<%= grdfabricpurchased.ClientID %>_" + "ctl04" + "_hdnreceivedqty").val();
                    $("#<%= grdfabricpurchased.ClientID %>_" + "ctl04" + "_txtrateSupplierQuotedRate").val(QuotedRate);
                    $("#<%= grdfabricpurchased.ClientID %>_" + "ctl04" + "_txtreceivedqty").val(ReceviedQty);
                    ReloadFunctionIfError("manual");

                }
                else {
                    $("#<%= grdfabricpurchased.ClientID %>_" + "ctl04" + "_txtrateSupplierQuotedRate").val("");
                    $("#<%= grdfabricpurchased.ClientID %>_" + "ctl04" + "_txtreceivedqty").val($("#<%= grdfabricpurchased.ClientID %>_" + "ctl04" + "_hdnreceivedqty").val());
                }
            }
            else {
                $("#<%= grdfabricpurchased.ClientID %>_" + "ctl04" + "_lbltotalAmount").text(TotalReceviedQty);
            }

            SetCalenderMinAndMaxDateOnRevisePO();
        }
        function ReloadFunctionIfError(type) {
            //   debugger;
            if (type == "manual") {
                // GetSupplierRateChange();// comment by shubhendu
            }
            else if (type == "onsupplierchange") {
                //GetSupplierChange(); need to checks
            }
        }
        $(window).on('load', function () {
            //            var LogedInDesignation = '<%=this.LogedInDesignation %>';
            //            if (LogedInDesignation == "122") {

            //                $('#ctl00_cph_main_content_imgAuthorizedSignatory').removeAttr("disabled");
            //                //  $('#ctl00_cph_main_content_imgAuthorizedSignatory').removeAttr("disabled");
            //                //  $('#ctl00_cph_main_content_chkpartysignature').attr('disabled', 'disabled');
            //            }
        });

        function GetSupplierChange() {

            FabType = '<%=this.Fabtype %>';
            var FabricQualityID = '<%=this.FabricQualityID %>';
            var SupplierNasterID = $("#" + ddlSupplierName).val();
            if ($("#ctl00_cph_main_content_ddlSupplierName option:selected").text() == "Please Select Supplier From  Qty Admin") {// added by shubhendu for select supplier message 21-07-2022
                $("#ctl00_cph_main_content_btnSubmit").attr("disabled", "disabled");
            }
            var PoNumberCode = '<%=lblPoNo.ClientID%>';
            var hdintialsuppliercode = '<%=hdintialsuppliercode.ClientID%>';
            colorprintdetail = $("#ctl00_cph_main_content_grdfabricpurchased_ctl04_lblcolorprint").text().replace(',', '');

            MasterPoID = '<%=this.MasterPoID %>';
            var ReceviedQty = 0;
            var SupplierQuotedRate = 0;
            var currentstagenumber = '<%=this.currentstage %>';
            var previousstagenumber = '<%=this.previousstage %>';
            var isStyleSpecific = '<%=this.isStyleSpecific %>';
            var styleid = '<%=this.styleid %>';
            var resullt = "";
            var validateRemaningQty = '<%=this.RemaningQty %>';
            var SendQty = $("#ctl00_cph_main_content_grdfabricpurchased_" + "ctl04" + "_txtsendQty").val()
            if (SendQty == "") {
                SendQty = 0;
            }
            if (isStyleSpecific == 'False') {
                styleid = -1;
            }
            if (SupplierNasterID != '-1') {



                proxy.invoke("GetSupplierIntialCode", { flag: "GETSUPPLIERCODE", SupplierMasterID: SupplierNasterID, PoID: MasterPoID }, function (result) {
                    $("#" + PoNumberCode).text(result[0]);

                    $("#ctl00_cph_main_content_hdintialsuppliercode").val(result[0]);
                    $("[id$=_hdintialsuppliercode]").val(result[0]);
                }, onPageError, false, false);

                if (FabType.toLowerCase() == 'RFD'.toLowerCase()) {

                    proxy.invoke("GetSupplierRateVA", { flag: FabType.toString(), flagOtion: 'GETSUPPLIERRATE', FabricQualityID: FabricQualityID, SupplierMasterID: SupplierNasterID, faricdetails: colorprintdetail, Styleid: styleid }, function (result) {
                        //     debugger;

                        $("#<%= grdfabricpurchased.ClientID %>_" + "ctl04" + "_txtrateSupplierQuotedRate").val(result[0]);

                        validatepageChangeState();
                        SupplierQuotedRate = $("#<%= grdfabricpurchased.ClientID %>_" + "ctl04" + "_txtrateSupplierQuotedRate").val();
                        $("[id$=_hdnstorerate]").val(SupplierQuotedRate);

                        ReceviedQty = $("#<%= grdfabricpurchased.ClientID %>_" + "ctl04" + "_txtreceivedqty").val().replace(",", "");
                        if (ReceviedQty == "") {
                            ReceviedQty = 0;
                        }
                        if (SupplierQuotedRate == "") {
                            SupplierQuotedRate = 0;
                        }
                        var TotalReceviedQty = numberWithCommas(Math.round((parseFloat(ReceviedQty)) * (parseFloat(SupplierQuotedRate)), 0));
                        $("[id$=_hdnstoretotalamount]").val(TotalReceviedQty);
                        if (TotalReceviedQty <= 0) {
                            //                            alert("Total amount is 0 please check your rate & received qty");
                            if (SupplierNasterID != -"1") {
                                var QuotedRate = $("#<%= grdfabricpurchased.ClientID %>_" + "ctl04" + "_hdnrateSupplierQuotedRate").val();
                                var ReceviedQty = $("#<%= grdfabricpurchased.ClientID %>_" + "ctl04" + "_hdnreceivedqty").val();
                                $("#<%= grdfabricpurchased.ClientID %>_" + "ctl04" + "_txtrateSupplierQuotedRate").val(QuotedRate);
                                $("#<%= grdfabricpurchased.ClientID %>_" + "ctl04" + "_txtreceivedqty").val(ReceviedQty);
                                ReloadFunctionIfError("onsupplierchange");
                            }
                            else {
                                $("#<%= grdfabricpurchased.ClientID %>_" + "ctl04" + "_txtrateSupplierQuotedRate").val("");
                                $("#<%= grdfabricpurchased.ClientID %>_" + "ctl04" + "_txtreceivedqty").val($("#<%= grdfabricpurchased.ClientID %>_" + "ctl04" + "_hdnreceivedqty").val());
                            }
                        }
                        else {
                            //                            alert('abc');
                            //                            alert(TotalReceviedQty);
                            $("#<%= grdfabricpurchased.ClientID %>_" + "ctl04" + "_lbltotalAmount").text(TotalReceviedQty);
                            validatepageChangeState();
                        }
                        EtagrdRest();
                    }, onPageError, false, false);
                }
                else {


                    proxy.invoke("GetSupplierRate", { flag: FabType.toString(), flagOtion: 'GETSUPPLIERRATE', FabricQualityID: FabricQualityID, SupplierMasterID: SupplierNasterID, faricdetails: colorprintdetail, Styleid: styleid },
                     function (result) {
                         //     debugger;
                         $("#<%= grdfabricpurchased.ClientID %>_" + "ctl04" + "_txtrateSupplierQuotedRate").val(result[0]);

                         SupplierQuotedRate = $("#<%= grdfabricpurchased.ClientID %>_" + "ctl04" + "_txtrateSupplierQuotedRate").val();
                         $("[id$=_hdnstorerate]").val(SupplierQuotedRate);
                         ReceviedQty = $("#<%= grdfabricpurchased.ClientID %>_" + "ctl04" + "_txtreceivedqty").val().replace(",", "");
                         if (ReceviedQty == "") {
                             ReceviedQty = 0;
                         }
                         if (SupplierQuotedRate == "") {
                             SupplierQuotedRate = 0;
                         }

                         var TotalReceviedQty = numberWithCommas(Math.round((parseFloat(ReceviedQty)) * (parseFloat(SupplierQuotedRate)), 0));

                         $("[id$=_hdnstoretotalamount]").val(TotalReceviedQty);
                         if (TotalReceviedQty <= 0) {
                             //                            alert("Total amount is 0 please check your rate & received qty"); check here 
                             if (SupplierNasterID != -"1") {
                                 var QuotedRate = $("#<%= grdfabricpurchased.ClientID %>_" + "ctl04" + "_hdnrateSupplierQuotedRate").val();
                                 var ReceviedQty = $("#<%= grdfabricpurchased.ClientID %>_" + "ctl04" + "_hdnreceivedqty").val();
                                 $("#<%= grdfabricpurchased.ClientID %>_" + "ctl04" + "_txtrateSupplierQuotedRate").val(QuotedRate);
                                 $("#<%= grdfabricpurchased.ClientID %>_" + "ctl04" + "_txtreceivedqty").val(ReceviedQty);
                                 TotalReceviedQty = (parseFloat(ReceviedQty.replace(",", ""))) * (parseFloat(QuotedRate));

                                 ReloadFunctionIfError("onsupplierchange");
                             }
                             else {
                                 $("#<%= grdfabricpurchased.ClientID %>_" + "ctl04" + "_txtrateSupplierQuotedRate").val("");
                                 $("#<%= grdfabricpurchased.ClientID %>_" + "ctl04" + "_txtreceivedqty").val($("#<%= grdfabricpurchased.ClientID %>_" + "ctl04" + "_hdnreceivedqty").val());
                             }
                         }
                         else {
                             $("#<%= grdfabricpurchased.ClientID %>_" + "ctl04" + "_lbltotalAmount").text(TotalReceviedQty);
                         }

                         if ($('#ctl00_cph_main_content_ddlSupplierName').is(':disabled') != "disabled" && ($('#ctl00$cph_main_content$chkJuniorSignatory').val() != null || $('#ctl00$cph_main_content$chkJuniorSignatory').val() != '')) {
                             SetCalenderMinAndMaxDateOnRaisePO();
                         }

                         EtagrdRest();
                     }, onPageError, false, false);
                }

            }
            else {
                $("#<%= grdfabricpurchased.ClientID %>_" + "ctl04" + "_txtrateSupplierQuotedRate").val("");
                $("#<%= grdfabricpurchased.ClientID %>_" + "ctl04" + "_lbltotalAmount").text("");
                $("#" + PoNumberCode).text($("#" + hdintialsuppliercode).val());
                $("#divconversionorder").css("display", "none");
            }
            GetDeliveryType();
        }

        function GetDeliveryType() {

            var FabType = '<%=this.Fabtype %>';
            var FabricQualityID = '<%=this.FabricQualityID %>';
            var SupplierMasterID = $("#" + ddlSupplierName).val();
            var ColorPrint = $("#ctl00_cph_main_content_grdfabricpurchased_ctl04_lblcolorprint").text().replace(',', '');
            var isStyleSpecific = '<%=this.isStyleSpecific %>';
            var styleid = '<%=this.styleid %>';
            var url = "../../Webservices/iKandiService.asmx";

            $.ajax({
                type: "POST",
                url: url + "/GetDeliveryType",
                data: "{ Flag:'" + 'GETDELIVERYTYPE' + "', FlagOption:'" + FabType + "', FabricQualityID:'" + FabricQualityID + "', SupplierMasterID:'" + SupplierMasterID + "',FabricDetails:'" + ColorPrint + "',styleida:'" + styleid + "',isStyleSpecific:'" + isStyleSpecific + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: OnSuccessCall,
                error: OnErrorCall
            });

            function OnSuccessCall(response) {

                var DeliveryType = response.d[0];

                if (DeliveryType == '1') {

                    $('#ctl00_cph_main_content_rdybtnListRateType_1').attr('checked', true)

                }
                else if (DeliveryType == '2') {
                    $('#ctl00_cph_main_content_rdybtnListRateType_2').attr('checked', true)
                }

                else {
                    $('#ctl00_cph_main_content_rdybtnListRateType_0').attr('checked', true)
                }


            }
            function OnErrorCall(response) {
                alert(response.status + " " + response.statusText);
            }

        }


        function checkValidation() {

            var isuccess = true;
            FabType = '<%=this.Fabtype %>';
            var currentstagenumber = '<%=this.currentstage %>';
            var garmentunits = $("[id$=_hdndefualtorderunit]").val();
            var converttounit = $("#ctl00_cph_main_content_grdfabricpurchased_ctl04_ddlunits").val();
            var conversionvalue = $("[id$=hdnconversionvalue]").val();
            var SupplierNasterID = $("#" + ddlSupplierName).val();
            conversionvalue = conversionvalue == "" ? 0 : conversionvalue;
            if (SupplierNasterID == "-1" || $('#ctl00_cph_main_content_ddlSupplierName option:selected').text() == "Please Select Supplier From  Qty Admin") {
                alert('select supplier name');
                isuccess = false;
                return false;
            }
            if ($("#ctl00_cph_main_content_txtPoDate").val() == "") {
                //                ShowMessage(true, 'select PO Date', 'Fabric PurChased Form ', 'validation');
                alert('select PO Date');
                isuccess = false;
                return;
            }
            if ($("#ctl00_cph_main_content_txtETADate").val() == "") {

                alert('select Eta Date');
                isuccess = false;
                return;
            }
            if (FabType.toLowerCase() != "GRIEGE".toLowerCase() && FabType.toLowerCase() != "FINISHING".toLowerCase() && (FabType.toLowerCase() == 'RFD'.toLowerCase() && currentstagenumber != "1")) {

                if ($("#ctl00_cph_main_content_grdfabricpurchased_ctl04_txtsendQty").val() == "") {

                    alert('Enter send Quantity');
                    isuccess = false;
                    return false;
                }
            }

            if ($("#ctl00_cph_main_content_grdfabricpurchased_ctl04_txtreceivedqty").val() == "") {

                alert('Enter Received Quantity');
                isuccess = false;
                return false;
            }
            if ($("#ctl00_cph_main_content_grdfabricpurchased_ctl04_txtrateSupplierQuotedRate").val() == "") {

                alert('Enter Finance Rate');
                isuccess = false;
                return false;
            }
            if ($("#ctl00_cph_main_content_grdfabricpurchased_ctl04_ddlunits").val() == "-1") {

                alert('Select unit');
                isuccess = false;
                return false;
            }
            if (garmentunits.toString() != converttounit.toString()) {

                if (parseFloat(conversionvalue) <= 0) {
                    alert('Enter conversion value');
                    isuccess = false;
                    return false;
                }

            }
            if (isuccess == true) {

                SubmitFabricOrderForm();
                $("#ctl00_cph_main_content_btnsave").click();
                // SaveEtaRangeQty();
                //                window.parent.CallThisPage();
                //                window.parent.Shadowbox.close();

                //                if ($("#rdoyes").is(":checked")) {

                //                    return true;
                //                }
                //                else {                     
                //                     window.parent.CallThisPage();
                //                     window.parent.Shadowbox.close();
                //                     return false;
                //                }


            }
            else {
                return false;
            }
            return false;
        }





        function UpdateComment(elem) {
            Po_Number = $("#ctl00_cph_main_content_lblPoNo").text();
            var id = elem.id;
            ComVal = $('#' + id).val().trim();
            proxy.invoke("UpdateComment_ON_PO", { Po_Number: Po_Number, CommentRemarks: ComVal },
                    function (result) {
                    });
        }



        function SubmitFabricOrderForm() {

            // DeletePo();
            hdnSessionQ = '<%=this.hdnSessionQ %>';
            FabType = '<%=this.Fabtype %>';
            Userid = '<%=this.Userid %>';
            MasterPoID = '<%=this.MasterPoID %>';
            colorprintdetail = $("#ctl00_cph_main_content_grdfabricpurchased_ctl04_lblcolorprint").text().replace(",", "");
            IsMailSend = 0;
            if ($("#ctl00_cph_main_content_rdoyes").is(":checked")) {


                IsMailSend = 1;

            }

            //            $('#<%=rdybtnListRateType.ClientID %> input:checked').val()
            var RateType = $('#<%=rdybtnListRateType.ClientID %> input:checked').val();


            var potypes_ = "";
            if (Potype == 'RERAISE') {
                potypes_ = "REVISEUPDATED";
            }
            else if (Potype == 'RAISE') {
                potypes_ = "RAISEINSERT";
            }

            var FabricQualityID = '<%=this.FabricQualityID %>';
            var SupplierNasterID = $("#" + ddlSupplierName).val();
            //            var garmentunits = $("#ctl00_cph_main_content_grdfabricpurchased_ctl04_ddlunits").val();

            var garmentunits = $("[id$=_hdndefualtorderunit]").val();
            var converttounit = $("#ctl00_cph_main_content_grdfabricpurchased_ctl04_ddlunits").val();
            var conversionvalue = $("[id$=hdnconversionvalue]").val();
            if (conversionvalue == "" || conversionvalue == "0") {
                conversionvalue = 1;
            }
            var Po_number = $("#ctl00_cph_main_content_lblPoNo").text();
            var Po_Date = $("#ctl00_cph_main_content_txtPoDate").val();
            var Po_ETADate = $("#ctl00_cph_main_content_txtETADate").val();
            var Po_ReceivedQty = 0;
            var gerige = $("#ctl00_cph_main_content_lblgerigeshrinkage").text();
            var residual = $("#ctl00_cph_main_content_lblresidualshrinkage").text();
            var currentstagenumber = '<%=this.currentstage %>';
            var previousstagenumber = '<%=this.previousstage %>';
            var isStyleSpecific = '<%=this.isStyleSpecific %>';
            var styleid = '<%=this.styleid %>';
            var stage1 = '<%=this.Stage1 %>';
            var stage2 = '<%=this.Stage2 %>';
            var stage3 = '<%=this.Stage3 %>';
            var stage4 = '<%=this.Stage4 %>';
            var HdnConvertTounit = $('#ctl00_cph_main_content_grdfabricpurchased_ctl04_hdnConvertTounit').val();
            var HdnConvertTounit = $('#ctl00_cph_main_content_grdfabricpurchased_ctl04_hdnConvertTounit').val();
            var select = document.getElementById('ctl00_cph_main_content_grdfabricpurchased_ctl04_ddlunits');
            var defualtorderUnit = $("[id$=_hdndefualtorderunit]").val();
            var hdnsaveconversionvalue = $('#ctl00_cph_main_content_grdfabricpurchased_ctl04_hdnsaveconversionvalue').val();
            var cutwastage = $("#ctl00_cph_main_content_hdncutwastage").val();

            if (hdnsaveconversionvalue == '') {
                hdnsaveconversionvalue = 0;
            }
            if (gerige == '') {
                gerige = 0;
            }
            if (cutwastage == '') {
                cutwastage = 0;
            }
            if (isStyleSpecific == 'False') {
                styleid = -1;
            }
            if (residual == '') {
                residual = 0;
            }
            var SendQty = $("#ctl00_cph_main_content_grdfabricpurchased_ctl04_txtsendQty").val().replace(",", "");
            if (SendQty == '') {
                SendQty = 0;
            }
            var Po_ReceivedQty = $("#ctl00_cph_main_content_grdfabricpurchased_ctl04_txtreceivedqty").val().replace(",", "");
            if (Po_ReceivedQty == '') {
                Po_ReceivedQty = 0;
            }

            var Po_SupplierQuotedRate = $("#ctl00_cph_main_content_grdfabricpurchased_ctl04_txtrateSupplierQuotedRate").val();
            var SupplierNasterID = $("#" + ddlSupplierName).val();
            var IsAuthIsg = 0;
            var IsPartySign = 0;
            var IsJuniorSign = 0;
            if ($("#ctl00_cph_main_content_chkJuniorSignatory").is(':checked')) {
                IsJuniorSign = 1;
            } else {
                IsJuniorSign = 0;
            }
            if ($("#ctl00_cph_main_content_chkAuthorizedSignatory").is(':checked')) {
                IsAuthIsg = 1;
            } else {
                IsAuthIsg = 0;
            }
            if ($("#ctl00_cph_main_content_chkpartysignature").is(':checked')) {
                IsPartySign = 1;
            } else {
                IsPartySign = 0;
            }

            if ($(select).val().toString() == defualtorderUnit.toString()) {
                conversionvalue = 1;
            }
            else {
                if (SendQty != 0) {
                    SendQty = Math.round(parseFloat(SendQty) / parseFloat(conversionvalue));
                }
                if (Po_ReceivedQty != 0) {
                    Po_ReceivedQty = Math.round(parseFloat(Po_ReceivedQty) / parseFloat(conversionvalue));
                }
            }
            var h = CreateHistory();
            var values = "";
            $("#tblbreakedown tr").each(function (index) {

                loopfromqty = $("#ctl00_cph_main_content_lblfromqty" + $(this).attr('id').substring(8, 9)).text().replace(",", "");
                looptoqty = $("#ctl00_cph_main_content_lbltoqty" + $(this).attr('id').substring(8, 9)).text().replace(",", "");
                etadatevalue = $("#ctl00_cph_main_content_lbletabreakedate" + $(this).attr('id').substring(8, 9)).text().replace(",", "");
                if (loopfromqty != "" && looptoqty != "") {

                    values = values + loopfromqty + "," + looptoqty + "," + etadatevalue + "##";
                }

            });

            //$("#ctl00_cph_main_content_hdnhistory").val(h);

            proxy.invoke("UpdateFabricPurchasedDetails", { Flag: FabType.toString(), FlagOption: potypes_, FabricQualityID: FabricQualityID, SuppliermasterID: SupplierNasterID, Po_Number: Po_number, Podate: Po_Date, UserID: Userid, ReceviedQty: Po_ReceivedQty, rate: Po_SupplierQuotedRate, ENDETA: Po_ETADate, garmentunits: garmentunits, sendqty: SendQty, colorprintdetail: colorprintdetail, IsAuthSign: IsAuthIsg, IsPartySign: IsPartySign, IsJuniorSign: IsJuniorSign, gerige: gerige, residual: residual, Currentstage: currentstagenumber, previousstage: previousstagenumber, isstylespecific: isStyleSpecific, styleid: styleid, stage1: stage1, stage2: stage2, stage3: stage3, stage4: stage4, Converttounit: converttounit, conversionvalue: conversionvalue, History: h, cutwastage: cutwastage, eta: values, RateType: RateType },
             function (result) {
                 if (result == true) {

                     //$("#ctl00_cph_main_content_btnsave").click();
                     //   

                     //window.parent.Shadowbox.close();
                     //                    if ($("#rdoyes").is(":checked")) {                        
                     //                       
                     //                        $("#ctl00_cph_main_content_btnSubmit").click();
                     //                        alert("Page submit and mail sent successfully");
                     //                        window.parent.CallThisPage();
                     //                        window.parent.Shadowbox.close();
                     //                    }
                     //                    else {
                     //                        alert("Page submit successfully");

                     //                        window.parent.CallThisPage();
                     //                        window.parent.Shadowbox.close();
                     //                    }
                 }
             },
            onPageError, false, true);
            //SaveEtaRangeQty();
            // Added by shubh
            var comment = $("#ctl00_cph_main_content_comment").val();

            proxy.invoke("UpdateComment_ON_PO", { Po_Number: Po_number, CommentRemarks: comment }, function (result) { });

            var SupplyType = $('#ctl00_cph_main_content_hdnSupplyType').val();

            window.parent.CallThisPage(Po_number, SupplierNasterID, IsMailSend, hdnSessionQ, SupplyType);


        }
        function DeletePo() {
            FabType = '<%=this.Fabtype %>';
            Userid = '<%=this.Userid %>';
            MasterPoID = '<%=this.MasterPoID %>';
            PoNumber = '<%=this.PoNumber %>';
            var IsAuthIsg = 0;
            var IsPartySign = 0;
            if ($("#ctl00_cph_main_content_chkAuthorizedSignatory").is(':checked')) {
                IsAuthIsg = 1;
            } else {
                IsAuthIsg = 0;
            }
            if ($("#ctl00_cph_main_content_chkpartysignature").is(':checked')) {
                IsPartySign = 1;
            } else {
                IsPartySign = 0;
            }

            proxy.invoke("UpdateFabricPurchasedETA", { Flag: FabType.toString(), FlagOption: 'GETPOSUPPLIERETA_DELETE', ETAdate: '02 Apr 19 (Tue)', UserID: Userid, FromQty: 0, ToQty: 0, MasterPoID: MasterPoID, Po_Number: PoNumber, IsAuthSign: IsAuthIsg, IsPartySign: IsPartySign }, function (result) {
            }, onPageError, false, false);

            //            SaveEtaRangeQty();
        }
        function SaveEtaRangeQty() {

            FabType = '<%=this.Fabtype %>';
            Userid = '<%=this.Userid %>';
            MasterPoID = '<%=this.MasterPoID %>';
            PoNumber = $("#ctl00_cph_main_content_lblPoNo").text();
            //            PoNumber = '<%=this.PoNumber %>';
            var GridId = "<%=grdqtyrange.ClientID %>";
            var grid = document.getElementById(GridId);

            var IsAuthIsg = 0;
            var IsPartySign = 0;
            var IsJuniorSign = 0;
            if ($("#ctl00_cph_main_content_chkJuniorSignatory").is(':checked')) {
                IsJuniorSign = 1;
            } else {
                IsJuniorSign = 0;
            }
            if ($("#ctl00_cph_main_content_chkAuthorizedSignatory").is(':checked')) {
                IsAuthIsg = 1;
            } else {
                IsAuthIsg = 0;
            }
            if ($("#ctl00_cph_main_content_chkpartysignature").is(':checked')) {
                IsPartySign = 1;
            } else {
                IsPartySign = 0;
            }

            var html = /(<([^>]+)>)/gi;



            $("#tblbreakedown tr").each(function (index) {
                if ($(this).css('display') == 'none') {

                    $(this).remove();
                }
            });
            var values = "";
            $("#tblbreakedown tr").each(function (index) {

                loopfromqty = $("#ctl00_cph_main_content_lblfromqty" + $(this).attr('id').substring(8, 9)).text().replace(",", "");
                looptoqty = $("#ctl00_cph_main_content_lbltoqty" + $(this).attr('id').substring(8, 9)).text().replace(",", "");
                etadatevalue = $("#ctl00_cph_main_content_lbletabreakedate" + $(this).attr('id').substring(8, 9)).text().replace(",", "");
                if (loopfromqty != "" && looptoqty != "") {

                    values = values + loopfromqty + "," + looptoqty + "," + etadatevalue + "##";
                    proxy.invoke("UpdateFabricPurchasedETA", { Flag: FabType.toString(), FlagOption: 'GETPOSUPPLIERETA_INSERT', ETAdate: etadatevalue, UserID: Userid, FromQty: loopfromqty, ToQty: looptoqty, MasterPoID: MasterPoID, Po_Number: PoNumber, IsAuthSign: IsAuthIsg, IsPartySign: IsPartySign, IsJuniorSign: IsJuniorSign }, function (result) {

                    }, onPageError, false, false);
                    //console.log("Page submit successfully");
                }
            });

            $("[id$=hdnetastring]").val(values);


            //window.parent.CallThisPage();

        }
        function Hitback() {

            window.parent.CallThisPage();
            //Shadowbox.close();
        }
        function disablekey(event) {

            event.preventDefault();
        }
        function DisableFiledByPo_type() {
            var IsAuthIsg = 0;
            var IsPartySign = 0;
            var IsJuniorSign = 0;
            if ($("#ctl00_cph_main_content_chkJuniorSignatory").is(':checked')) {
                IsJuniorSign = 1;
            } else {
                IsJuniorSign = 0;
            }
            if ($("#ctl00_cph_main_content_chkAuthorizedSignatory").is(':checked')) {
                IsAuthIsg = 1;
            } else {
                IsAuthIsg = 0;
            }
            if ($("#ctl00_cph_main_content_chkpartysignature").is(':checked')) {
                IsPartySign = 1;
            } else {
                IsPartySign = 0;
            }

            if (Potype == 'RERAISE') {
                $("#ctl00_cph_main_content_ddlSupplierName").attr('disabled', 'disabled');
                $("#ctl00_cph_main_content_txtPoDate").attr('disabled', 'disabled');
                // $("#ctl00_cph_main_content_txtETADate").attr('disabled', 'disabled');
                //$("#ctl00_cph_main_content_grdfabricpurchased_ctl04_txtrateSupplierQuotedRate").attr('disabled', 'disabled');
                if (IsAuthIsg == 1 && IsPartySign == 1) {
                    $("#ctl00_cph_main_content_grdfabricpurchased_ctl04_ddlunits").attr('disabled', 'disabled');
                }
                else {
                    $("#ctl00_cph_main_content_grdfabricpurchased_ctl04_ddlunits").removeAttr('disabled', 'disabled');
                }

            }
            else if (Potype == 'RAISE') {
                // $("#ctl00_cph_main_content_ddlSupplierName").removeAttr('disabled', 'disabled'); commented by shubhendu 20/07/2022

                $("#ctl00_cph_main_content_txtPoDate").removeAttr('disabled', 'disabled');
                $("#ctl00_cph_main_content_txtETADate").removeAttr('disabled', 'disabled');
                $("#ctl00_cph_main_content_grdfabricpurchased_ctl04_txtrateSupplierQuotedRate").removeAttr('disabled', 'disabled');

            }
            var SupplierNasterID = $("#" + ddlSupplierName).val();

            if (SupplierNasterID == "-1") {
                $("input").attr('disabled', 'disabled');
                $('input[type=text]').attr('title', 'your must have to select supplier to fill value');

                $("#ctl00_cph_main_content_grdfabricpurchased_ctl04_txtrateSupplierQuotedRate").val("");
                //$("#ctl00_cph_main_content_txtETADate").val("");
                //                $("#ctl00_cph_main_content_grdfabricpurchased_ctl04_ddlunits").val("-1");
                $("#ctl00_cph_main_content_grdfabricpurchased_ctl04_ddlunits").attr('disabled', 'disabled');
                $("#ctl00_cph_main_content_grdfabricpurchased_ctl04_lbltotalAmount").text("");
                // $("#ctl00_cph_main_content_chkAuthorizedSignatory").removeAttr('disabled', 'disabled');
                //  $("#ctl00_cph_main_content_chkpartysignature").removeAttr('disabled', 'disabled');
                $("#divconversionorder").css("display", "none");

            }
        }

    </script>
    <script type="text/javascript">
        var _oldsends = "";
        var _oldrececive = "";
        var ddlSupplierName = '<%=ddlSupplierName.ClientID%>';

        var SupplierNasterID = $("#" + ddlSupplierName).val();
        $(function () {
            //   debugger;
            $("#rdybtnListRateType").attr("disabled", "");
            $("#" + ddlSupplierName)


            $("[id$=_hdnstorepodate]").val($("#ctl00_cph_main_content_txtPoDate").val());
            $("[id$=_hdnstoresupplierid]").val($("#" + ddlSupplierName).val());
            $("[id$=_hdnstoreetadate]").val($("[id$=_txtETADate]").val());
            //            $("[id$=_hdnstoresendqty]").val($("[id$=_txtsendQty]").val());
            //            $("[id$=_hdnstorereceivedqty]").val($("[id$=_txtreceivedqty]").val());
            $("[id$=_hdnstoreunitsid]").val($("#ctl00_cph_main_content_grdfabricpurchased_ctl04_ddlunits").val());
            $("[id$=_hdnstorerate]").val($("[id$=_txtrateSupplierQuotedRate]").val());
            $("[id$=_hdnstoretotalamount]").val($("[id$=_lbltotalAmount]").text());
            $("[id$=_hdintialsuppliercode]").val($("[id$=_lblPoNo]").text());
            //
            $(".storedata").change(function () {

                $("[id$=_hdnstorepodate]").val($("#ctl00_cph_main_content_txtPoDate").val());
                $("[id$=_hdnstoresupplierid]").val($("#" + ddlSupplierName).val());
                $("[id$=_hdnstoreetadate]").val($("[id$=_txtETADate]").val());
                //                $("[id$=_hdnstoresendqty]").val($("[id$=_txtsendQty]").val());
                //                $("[id$=_hdnstorereceivedqty]").val($("[id$=_txtreceivedqty]").val());
                $("[id$=_hdnstoreunitsid]").val($("#ctl00_cph_main_content_grdfabricpurchased_ctl04_ddlunits").val());
                $("[id$=_hdnstorerate]").val($("[id$=_txtrateSupplierQuotedRate]").val());
                $("[id$=_hdnstoretotalamount]").val($("[id$=_lbltotalAmount]").text());
                $("[id$=_hdintialsuppliercode]").val($("[id$=_lblPoNo]").text());

                //                if ($("#ctl00_cph_main_content_ddlSupplierName:selected").text() == 'Please Select Supplier From  Qty Admin') {

                //                    $("ctl00_cph_main_content_btnSubmit").attr("disabled", "true");
                //                }

            });

            $('input').attr('autocomplete', 'off');
            $(".noonly").keypress(function (e) {
                //if the letter is not digit then display error and don't type anything
                if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {
                    return false;
                }
            });
            $("[id*=btnAdd]").click(function () {

                var IsSucess = true;
                var inputfromQty = parseInt($("[id*=txtqtyfrom]").val().replace(',', ''));
                var inputtoQty = parseInt($("[id*=txtqtyto]").val().replace(',', ''));

                if ($("[id*=txtqtyfrom]").val() == "" || parseInt($("[id*=txtqtyfrom]").val()) <= 0) {
                    alert("From qty cannot be empty");
                    return false;
                }

                if ($("[id*=txtqtyto]").val() == "" || parseInt($("[id*=txtqtyto]").val()) <= 0) {
                    alert("To qty cannot be empty");
                    return false;
                }
                if ($("[id*=txtetadateSupplier]").val() == "") {
                    alert("ETA date cannot be empty");
                    return false;
                }
                if (inputfromQty > inputtoQty) {
                    alert("From qty cannot be greater than toqty");
                    $("[id*=txtqtyfrom]").val("");
                    $("[id*=txtqtyto]").val("");
                    return false;
                }

                //                if (ValidateEtaFromToValue() == false) {
                //                    return false;
                //                }

                var gridView = $("[id*=gvqtyrange]");
                var row = gridView.find("tr").eq(1);

                //Check if row is dummy, if yes then remove.
                //                if ($.trim(row.find("td").eq(0).html()) == "") {
                //                    row.remove();
                //                }

                $("#ctl00_cph_main_content_gvqtyrange tr").each(function (e) {
                    var fromqty = $(this).find('input[name$=fromqtyval]');
                    var toqty = $(this).find('input[name$=toqtyval]');

                    if ($(fromqty).val() !== undefined && $(toqty).val() !== undefined) {
                        var Fqty = parseInt($(fromqty).val().replace(',', ''));
                        var Toqty = parseInt($(toqty).val().replace(',', ''));

                        if (inputfromQty <= Toqty) {
                            alert(inputfromQty + " is exits between " + Fqty + " " + Toqty);
                            IsSucess = false
                            return false;
                        }
                        else {
                            IsSucess = true
                        }
                    }
                });
                if (IsSucess == false) {
                    return false;
                }
                row = row.clone(true);

                var txtfromQty = $("[id*=txtqtyfrom]");
                SetValue(row, 0, "fromqtyval", txtfromQty);

                var txtToQty = $("[id*=txtqtyto]");
                SetValue(row, 1, "toqtyval", txtToQty);

                var txtetadate = $("[id*=txtetadateSupplier]");
                SetValue(row, 2, "Etadate", txtetadate);

                var btndele = $("[id*=dele]");
                SetValue(row, 3, "dlete", btndele);

                gridView.append(row);

                return false;
            });
            function SetValue(row, index, name, textbox) {

                if (index != "3") {
                    row.find("td").eq(index).html(numberWithCommas(textbox.val()));
                    var input = $("<input type = 'hidden' />");
                    input.attr("name", name);
                    input.val(textbox.val());
                    row.find("td").eq(index).append(input);
                }
                else if (index == "3") {
                    row.find("td").eq(index).html(textbox.val());
                    var inputdele = $("<input type = 'image' />");
                    inputdele.attr("name", "deleteetarow");
                    inputdele.attr("src", "../../images/del-butt.png");
                    //                    inputdele.attr("style", "position: relative; top: 5px;");
                    inputdele.attr("OnClick", "DeleteRow();return false;");
                    row.find("td").eq(index).append(inputdele);
                }
                textbox.val("");
            }
            //    debugger;
            ConversionValueChange('REOPEN');
            Addnew('SHOW')
            $('#tblbreakedown').each(function () {
                $('tr:odd', this).addClass('odd').removeClass('even');
                $('tr:even', this).addClass('even').removeClass('odd');
            });
            var input = document.getElementById("ctl00_cph_main_content_txttounit");
            input.addEventListener("focus", function () {
                //                this.style.bordercolor = "pink";
                $("#ctl00_cph_main_content_txttounit").css("border-color", "");
            });
            if (document.getElementById('ctl00_cph_main_content_lblh').innerHTML == "") {

                $("#lnkhistoryshow").hide();

            }

            $("#ctl00_cph_main_content_txtETADate").change(function () { });
            $(".uts").text($("#ctl00_cph_main_content_grdfabricpurchased_ctl04_ddlunits option:selected").text());



        });
        function DeleteRow() {
            if (confirm("Are you sure want to delete row!")) {
                var td = event.target.parentNode;
                var tr = td.parentNode; // the row to be removed
                tr.parentNode.removeChild(tr);
            }
            return false;
        }
        //        function ValidateEtaFromToValue() {
        //          //    

        //            var inputfromQty = parseInt($("[id*=txtqtyfrom]").val().replace(',', ''));
        //            var inputtoQty = parseInt($("[id*=txtqtyto]").val().replace(',', ''));

        //            $("#ctl00_cph_main_content_gvqtyrange tr").each(function (e) {
        //                var fromqty = $(this).find('input[name$=fromqtyval]');
        //                var toqty = $(this).find('input[name$=toqtyval]');

        //                if ($(fromqty).val() !== undefined && $(toqty).val() !== undefined) {
        //                    var Fqty = parseInt($(fromqty).val().replace(',',''));
        //                    var Toqty = parseInt($(toqty).val().replace(',', ''));

        //                    if (inputfromQty <= Toqty) {
        //                        alert(inputfromQty + " is exits between " + Fqty + " " + Toqty);
        //                        return false
        //                    }
        //                    else {
        //                        return true;
        //                    }
        //                }
        //            });

        //        }
        function DisabledFiledForSupplierView() {

            $("#ctl00_cph_main_content_txtPoDate").attr('disabled', 'disabled');
            $("#ctl00_cph_main_content_grdfabricpurchased_ctl04_txtreceivedqty").attr('disabled', 'disabled');
            $("#ctl00_cph_main_content_ddlSupplierName").attr('disabled', 'disabled');
            $("#ctl00_cph_main_content_grdfabricpurchased_ctl04_ddlunits").attr('disabled', 'disabled');
            $("#ctl00_cph_main_content_grdfabricpurchased_ctl04_txtrateSupplierQuotedRate").attr('disabled', 'disabled');
            $("#ctl00_cph_main_content_txtETADate").attr('disabled', 'disabled');
            $("#btnAdd").attr('disabled', 'disabled');
            $("#ctl00_cph_main_content_gvqtyrange").addClass('displaynoneSup');
            // $(".supplieretadatetable").hide();
            $("#ctl00_cph_main_content_gvqtyrange").find("th:nth-child(" + 3 + "), td:nth-child(" + 3 + ")").hide();
            $('.border_left').addClass('border_right_color');
            $("#ctl00_cph_main_content_divSubmit").hide();

            // $("#ctl00_cph_main_content_divSubmit").css("display", "none");
            Supplier = '<%=this.ParentPageUrlWithQuerystring %>';
            //            if (Supplier == 'SuPPLIERVIEW') {
            //                $('.btnSubmit').hide();
            //            }
        }
        function CheckToQty(elem) {

            var Idsn = elem.id.split("_");
            Toqty = $("#<%= grdqtyrange.ClientID %>_" + Idsn[5] + "_txtedittoqty").val();
            Fromqty = $("#<%= grdqtyrange.ClientID %>_" + Idsn[5] + "_txteditfromqty").val();
            Etadates = $("#<%= grdqtyrange.ClientID %>_" + Idsn[5] + "_txtdates").val();
            $("#<%= grdqtyrange.ClientID %>_" + Idsn[5] + "_txtdates").val("");
            receivedqty = $("#<%= grdfabricpurchased.ClientID %>_" + "ctl04" + "_txtreceivedqty").val().replace(",", "");
            MinDate = $("#ctl00_cph_main_content_txtPoDate").val();
            MaxDate = $("#ctl00_cph_main_content_txtETADate").val();
            if (Toqty == "0") {
                alert("To qty cannot be zero ");
                $("#<%= grdqtyrange.ClientID %>_" + Idsn[5] + "_txtedittoqty").val("");
            }
            if (Fromqty == "0") {
                alert("To from cannot be zero ");
                $("#<%= grdqtyrange.ClientID %>_" + Idsn[5] + "_txteditfromqty").val("");
            }
            if (parseInt(Toqty) > parseInt(receivedqty)) {
                alert("To qty cannot be greather then total received qty");
                $("#<%= grdqtyrange.ClientID %>_" + Idsn[5] + "_txtedittoqty").val(receivedqty);
            }
            if (parseInt(Toqty) < parseInt(Fromqty)) {
                alert("To qty cannot be less then from qty");
                $("#<%= grdqtyrange.ClientID %>_" + Idsn[5] + "_txtedittoqty").val(receivedqty);
            }
            $("#ctl00_cph_main_content_hdntoqty").val(Toqty);
        }
        function CheckEtadates(elem) {

            var Idsn = elem.id.split("_");
            selecteddates = $("#<%= grdqtyrange.ClientID %>_" + Idsn[5] + "_txtdates").val();
            $("#ctl00_cph_main_content_hdntxtdates").val(selecteddates);
            MinDate = $("#ctl00_cph_main_content_txtPoDate").val();
            MaxDate = $("#ctl00_cph_main_content_txtETADate").val();

            var pattern = /(.*?)\/(.*?)\/(.*?)$/;
            var result = MinDate.replace(pattern, function (match, p1, p2, p3) {
                var months = ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec'];
                return (p2 < 10 ? "0" + p2 : p2) + " " + months[(p1 - 1)] + " " + p3;
            });

            var fDate, lDate, cDate;
            fDate = Date.parse(MinDate);
            lDate = Date.parse(MaxDate);
            cDate = Date.parse(selecteddates);

            if ((cDate <= lDate && cDate >= fDate)) {
                return true;
            }
            return false;
        }

        function Resetetagrd() {
            $.ajax({
                type: "POST",
                url: "FabricPurChasedForm.aspx/SetSession",
                data: "{ sessionval:'" + '' + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (msg) {
                }
            });


            EtagrdRest();

            var OldRate = $("[id$=_hdnstorerate]").val(); // added by shubhendu

            $("#ctl00_cph_main_content_grdqtyrange_ctl02_txtdates").val($("#ctl00_cph_main_content_txtETADate").val());
            $("#ctl00_cph_main_content_grdqtyrange_ctl02_txtedittoqty").val($("#ctl00_cph_main_content_grdfabricpurchased_ctl04_txtreceivedqty").val());
            $("#ctl00_cph_main_content_grdqtyrange").find("tr:gt(1)").remove();
            $("[id$=_lblfromqty]").text("1");
            $("[id$=_lbltoqty]").text($("#ctl00_cph_main_content_grdfabricpurchased_ctl04_txtreceivedqty").val());
            $("[id$=_lbldates]").text($("#ctl00_cph_main_content_txtETADate").val());
            $("#ctl00_cph_main_content_hdntxtdates").val($("#ctl00_cph_main_content_txtETADate").val());
            $("#ctl00_cph_main_content_hdintialsuppliercode").val($("#ctl00_cph_main_content_lblPoNo").text())
            var TotalReceviedQty = numberWithCommas(
                Math.round(
                    (parseFloat($("#ctl00_cph_main_content_grdfabricpurchased_ctl04_txtreceivedqty").val().replace(",", ""))) *
                    (parseFloat($("#ctl00_cph_main_content_grdfabricpurchased_ctl04_txtrateSupplierQuotedRate").val().replace(",", ""))),
                    0));

            //   $("#ctl00_cph_main_content_grdfabricpurchased_ctl04_lbltotalAmount").text(TotalReceviedQty);
            //            $(".uts").text($("#ctl00_cph_main_content_grdfabricpurchased_ctl04_ddlunits option:selected").text());
        }
        function setbackviewstate() {

            $("#ctl00_cph_main_content_grdqtyrange_ctl02_txtdates").val($("#ctl00_cph_main_content_hdntxtdates").val());
            $("#ctl00_cph_main_content_txtPoDate").val($("[id$=_hdnstorepodate]").val());
            $("#" + ddlSupplierName).val($("[id$=_hdnstoresupplierid]").val());
            $("[id$=_txtETADate]").val($("[id$=_hdnstoreetadate]").val());
            $("[id$=_txtsendQty]").val($("[id$=_hdnstoresendqty]").val());
            $("[id$=_txtreceivedqty]").val($("[id$=_hdnstorereceivedqty]").val());
            $("#ctl00_cph_main_content_grdfabricpurchased_ctl04_ddlunits").val($("[id$=_hdnstoreunitsid]").val());
            $("[id$=_txtrateSupplierQuotedRate]").val($("[id$=_hdnstorerate]").val());
            $("[id$=_lbltotalAmount]").text($("[id$=_hdnstoretotalamount]").val());
            $("[id$=_lblPoNo]").text($("[id$=_hdintialsuppliercode]").val());

        }
        function GetSupplierRateChange() {
            // debugger;

            var Potype = '<%=this.Potype %>';
            var Fabtypes = '<%=this.Fabtype %>';
            var PoNumber = '<%=this.PoNumber %>';
            MasterPoID = '<%=this.MasterPoID %>';
            var FabricQualityID = '<%=this.FabricQualityID %>';
            var resullt = "";
            var validateRemaningQty = '<%=this.RemaningQty %>';
            var RemainingQtys = $("#<%= grdfabricpurchased.ClientID %>_" + "ctl04" + "_hdnremainingQty").val().replace(",", "");
            var RececivedQtys = $("#<%= grdfabricpurchased.ClientID %>_" + "ctl04" + "_txtreceivedqty").val().replace(",", "");
            var Receiveqtydefaultvalue = $("#<%= grdfabricpurchased.ClientID %>_" + "ctl04" + "_hdnreceivedqty").val().replace(",", "");
            var oldreceivedqty = $("#<%= grdfabricpurchased.ClientID %>_" + "ctl04" + "_hdnreceivedqty").val().replace(",", "");

            var conversionvalue = $("[id$=hdnconversionvalue]").val();

            var HdnConvertTounit = $('#ctl00_cph_main_content_grdfabricpurchased_ctl04_hdnConvertTounit').val();
            var hdnsaveconversionvalue = $('#ctl00_cph_main_content_grdfabricpurchased_ctl04_hdnsaveconversionvalue').val();
            var select = document.getElementById('ctl00_cph_main_content_grdfabricpurchased_ctl04_ddlunits');
            var defualtorderUnit = $("[id$=_hdndefualtorderunit]").val();
            var availablrqty = $("#<%= grdfabricpurchased.ClientID %>_" + "ctl04" + "_hdnreceivedqty").val().replace(',', '');
            var rqtydefaultvalue = $("#<%= grdfabricpurchased.ClientID %>_" + "ctl04" + "_hdnreceivedqty").val().replace(",", "");

            if (RemainingQtys == "") {
                RemainingQtys = validateRemaningQty.replace(",", "");
            }
            if (RemainingQtys <= 0) {
                RemainingQtys = 0;
            }
            if (parseInt(RemainingQtys) <= 0) {
                RemainingQtys = 0;
            }
            if (RececivedQtys == "") {
                RececivedQtys = 0
            }
            if (RemainingQtys == "") {
                RemainingQtys = 0
            }
            var conversionvalue = $("[id$=hdnconversionvalue]").val();
            if (conversionvalue == '') {
                conversionvalue = 0;
            }
            if (Receiveqtydefaultvalue == '') {
                Receiveqtydefaultvalue = 0;

            }
            //            if (Potype == 'RAISE') {
            //                oldreceivedqty = 0;
            //            }

            //            if (parseFloat(conversionvalue) > 0) {

            //                RemainingQtys = parseFloat(RemainingQtys) * parseFloat(conversionvalue);
            //                Receiveqtydefaultvalue = parseFloat(Receiveqtydefaultvalue) * parseFloat(conversionvalue);
            //                //                RececivedQtys = parseFloat(RececivedQtys) * parseFloat(conversionvalue);
            //            }
            colorprintdetail = $("#ctl00_cph_main_content_grdfabricpurchased_ctl04_lblcolorprint").text();
            //if (Potype == 'RERAISE') {

            //            if (Potype == 'RAISE') {

            //                if ($(select).val().toString() == defualtorderUnit.toString()) {
            //                    availablrqty = Math.round((parseFloat(availablrqty) * parseFloat(1)));
            //                    oldreceivedqty = Math.round((parseFloat(oldreceivedqty) / parseFloat(1)));

            //                }
            //                else if ($(select).val().toString() != defualtorderUnit.toString()) {

            //                    availablrqty = Math.round((parseFloat(availablrqty) * parseFloat(conversionvalue)));
            //                    oldreceivedqty = Math.round(((parseFloat(oldreceivedqty) / parseFloat(hdnsaveconversionvalue)) * parseFloat(conversionvalue)));

            //                }

            //                if (parseFloat(RececivedQtys) > (parseFloat(availablrqty))) {
            //                    alert("Received qty cannot be  greater than available qty " + (parseInt(availablrqty)));
            //                    $("#<%= grdfabricpurchased.ClientID %>_" + "ctl04" + "_txtreceivedqty").val(numberWithCommas(Math.round(Receiveqtydefaultvalue)));
            //                    // elem.value = elem.defaultValue;
            //                    if (_oldrececive != "") {
            //                        $("#<%= grdfabricpurchased.ClientID %>_" + "ctl04" + "_txtreceivedqty").val(_oldrececive);
            //                    }
            //                    else {
            //                        $("#<%= grdfabricpurchased.ClientID %>_" + "ctl04" + "_txtreceivedqty").val(numberWithCommas(Math.round(oldreceivedqty)));
            //                    }

            //                    Resetetagrd();
            //                }
            //            }
            //            else {
            if (Potype == 'RAISE') {
                if ($(select).val().toString() != defualtorderUnit.toString()) {
                    RemainingQtys = Math.round((parseFloat(RemainingQtys) * parseFloat(conversionvalue)));
                    oldreceivedqty = Math.round((parseFloat(oldreceivedqty) * parseFloat(conversionvalue)));
                }
                //  debugger;
                if (parseFloat(RececivedQtys) > (parseFloat(RemainingQtys))) {
                    alert("Received qty cannot be  greater than available qty " + (parseFloat(RemainingQtys)));
                    $("#<%= grdfabricpurchased.ClientID %>_" + "ctl04" + "_txtreceivedqty").val(numberWithCommas(Math.round(oldreceivedqty)));


                    Resetetagrd();
                }
            }
            else {
                if ($(select).val().toString() != defualtorderUnit.toString()) {
                    RemainingQtys = Math.round((parseFloat(RemainingQtys) * parseFloat(conversionvalue)));
                    oldreceivedqty = Math.round((parseFloat(oldreceivedqty) * parseFloat(conversionvalue)));
                }
                if (parseFloat(RececivedQtys) > (parseFloat(RemainingQtys) + parseFloat(oldreceivedqty))) {
                    alert("Received qty cannot be  greater than available qty " + (parseFloat(RemainingQtys) + parseFloat(oldreceivedqty)));
                    $("#<%= grdfabricpurchased.ClientID %>_" + "ctl04" + "_txtreceivedqty").val(numberWithCommas(Math.round(oldreceivedqty)));
                    Resetetagrd();
                }
            }

            // }
            validatepageChangeState();

            ////            if (FabType != 'DYED' && FabType != 'PRINT') {
            ////                proxy.invoke("ValidateRececiedQty", { flag: Fabtypes, flagOtion: 'VALIDATERECEVIEQTY', FabricQualityID: FabricQualityID, ReceviedQty: RececivedQtys, Potype: Potype, PoNumber: PoNumber, MasterPoID: MasterPoID,fabricdetails:colorprintdetail}, function (result) {

            ////                    if (result[0] == "Received qty cannot be  greater than remaining qty" || result[0] == "") {

            ////                        
            ////                        $("#<%= grdfabricpurchased.ClientID %>_" + "ctl04" + "_txtreceivedqty").val(numberWithCommas($("#<%= grdfabricpurchased.ClientID %>_" + "ctl04" + "_hdnreceivedqty").val()));
            ////                       
            ////                        validatepageChangeState();
            ////                    }
            ////                    else {
            ////                        validatepageChangeState();
            ////                    }
            ////                }, onPageError, false, false);                                               
            ////            }
            ////            else {
            ////                validatepageChangeState();
            ////            }
        }
        function CheckSendQty(elem) {
            // debugger;
            var resulterr = ValidateMinReceiveQty(elem);
            if (resulterr != "") {
                $("#ctl00_cph_main_content_grdfabricpurchased_ctl04_txtreceivedqty").val($("#ctl00_cph_main_content_hdnstorereceivedqty").val());
                $("#ctl00_cph_main_content_grdfabricpurchased_ctl04_txtsendQty").val($("#ctl00_cph_main_content_hdnstoresendqty").val());
                return false;
            }
            var Potype = '<%=this.Potype %>';
            var Fabtypes = '<%=this.Fabtype %>';
            var PoNumber = '<%=this.PoNumber %>';
            var MasterPoID = '<%=this.MasterPoID %>';
            var FabricQualityID = '<%=this.FabricQualityID %>';
            var currentstagenumber = '<%=this.currentstage %>';
            var previousstagenumber = '<%=this.previousstage %>';
            var resullt = "";
            var validateRemaningQty = '<%=this.RemaningQty %>';
            var isStyleSpecific = '<%=this.isStyleSpecific %>';
            var styleid = '<%=this.styleid %>';
            colorprintdetail = $("#ctl00_cph_main_content_grdfabricpurchased_ctl04_lblcolorprint").text();

            ids = elem.id;
            var Idsn = elem.id.split("_");

            var QtySend = $("#<%= grdfabricpurchased.ClientID %>_" + "ctl04" + "_txtsendQty").val().replace(',', '');
            var OldSendQty = $("#<%= grdfabricpurchased.ClientID %>_" + "ctl04" + "_hdnsendqty").val().replace(',', '');
            var Residualshrnk = $("#<%= grdfabricpurchased.ClientID %>_" + "ctl04" + "_hdnResidualshrnk").val().replace(',', '');
            var gerigeshrnk = $("#<%= grdfabricpurchased.ClientID %>_" + "ctl04" + "_hdngerigeshrnk").val().replace(',', '');
            oldreceivedqty = $("#<%= grdfabricpurchased.ClientID %>_" + "ctl04" + "_hdnreceivedqty").val().replace(',', '');
            var ActualSendQty = $("#<%= grdfabricpurchased.ClientID %>_" + "ctl04" + "_hdnSendQtyValidate").val().replace(',', '');
            var availablesendqty = $("#<%= grdfabricpurchased.ClientID %>_" + "ctl04" + "_hdnavailablesendqty").val().replace(',', '');
            var retrunval = 0;
            var conversionvalue = $("[id$=hdnconversionvalue]").val();
            var Sendqtydefaultvalue = elem.defaultValue.replace(',', '');
            var HdnConvertTounit = $('#ctl00_cph_main_content_grdfabricpurchased_ctl04_hdnConvertTounit').val();
            var hdnsaveconversionvalue = $('#ctl00_cph_main_content_grdfabricpurchased_ctl04_hdnsaveconversionvalue').val();
            var select = document.getElementById('ctl00_cph_main_content_grdfabricpurchased_ctl04_ddlunits');
            var defualtorderUnit = $("[id$=_hdndefualtorderunit]").val();
            var RemainingQtys = $("#<%= grdfabricpurchased.ClientID %>_" + "ctl04" + "_hdnremainingQty").val().replace(",", "");

            RemainingQtys = validateRemaningQty.replace(",", "");
            //}
            if (RemainingQtys <= 0) {
                RemainingQtys = 0;
            }
            if (QtySend == '') {
                QtySend = 0;
            }

            if (OldSendQty == '') {
                OldSendQty = 0;
            }

            if (Residualshrnk == '') {
                Residualshrnk = 0;
            }
            if (gerigeshrnk == '') {
                gerigeshrnk = 0;
            }

            if (isStyleSpecific == 'False') {
                styleid = -1;
            }
            if (availablesendqty == '') {
                availablesendqty = 0;
            }

            if (conversionvalue == '') {
                conversionvalue = 0;
            }
            if (hdnsaveconversionvalue == '') {
                hdnsaveconversionvalue = 0;
            }
            if (Sendqtydefaultvalue == '') {
                Sendqtydefaultvalue = 0;
            }



            if (Potype == 'RERAISE') {
                if ($(select).val().toString() != defualtorderUnit.toString()) {
                    RemainingQtys = Math.round((parseFloat(RemainingQtys) * parseFloat(conversionvalue)));
                    OldSendQty = Math.round((parseFloat(OldSendQty) * parseFloat(conversionvalue)));
                    oldreceivedqty = Math.round((parseFloat(oldreceivedqty) * parseFloat(conversionvalue)));
                }


                if (Math.round(parseFloat(QtySend)) > Math.round(parseFloat(RemainingQtys) + parseFloat(OldSendQty))) { //shubhendu
                    alert("Send qty cannot be greater than available qty " + (Math.round(parseFloat(RemainingQtys) + parseFloat(OldSendQty))));

                    //                if (Math.round(parseFloat(QtySend)) >  parseFloat(OldSendQty)) {
                    //                    //elem.value = elem.defaultValue;
                    //                    alert("Send qty cannot be greater than available qty " + (Math.round(parseFloat(RemainingQtys))));
                    elem.value = numberWithCommas(Math.round(OldSendQty));
                    $("#<%= grdfabricpurchased.ClientID %>_" + "ctl04" + "_txtreceivedqty").val(numberWithCommas(Math.round(oldreceivedqty)));
                    $("#ctl00_cph_main_content_txttoqty0").text(oldreceivedqty);



                    Resetetagrd();
                }
                else {

                    var Residualshnk = 0;
                    var Gerigeshnk = 0;
                    var finalval = 0;
                    ///Residualshnk = parseFloat(QtySend) - ((parseFloat(QtySend) * parseFloat(gerigeshrnk) / parseFloat(100)));,

                    proxy.invoke("GetReceiveQtyBySendQty", { flag: Fabtypes, flagoption: "RECEIVEBYSNEDQTY", fabricqualityid: FabricQualityID, fabricdetails: colorprintdetail, currentstagenumber: currentstagenumber, previousstagenumber: previousstagenumber, pendingqty: QtySend, IsStyleSpecific: isStyleSpecific, styleid: styleid }, function (result) {

                        $("#<%= grdfabricpurchased.ClientID %>_" + "ctl04" + "_txtreceivedqty").val(numberWithCommas(result[0]));
                        $("[id$=_hdnstorepodate]").val($("#ctl00_cph_main_content_txtPoDate").val());
                        $("[id$=_hdnstoresupplierid]").val($("#" + ddlSupplierName).val());
                        $("[id$=_hdnstoreetadate]").val($("[id$=_txtETADate]").val());
                        //                        $("[id$=_hdnstoresendqty]").val($("[id$=_txtsendQty]").val());
                        //                        $("[id$=_hdnstorereceivedqty]").val($("[id$=_txtreceivedqty]").val());
                        $("[id$=_hdnstoreunitsid]").val($("#ctl00_cph_main_content_grdfabricpurchased_ctl04_ddlunits").val());
                        $("[id$=_hdnstorerate]").val($("[id$=_txtrateSupplierQuotedRate]").val());
                        $("[id$=_hdnstoretotalamount]").val($("[id$=_lbltotalAmount]").text());
                        $("[id$=_hdintialsuppliercode]").val($("[id$=_lblPoNo]").text());
                        Resetetagrd();
                        // $("#<%= grdfabricpurchased.ClientID %>_" + "ctl04" + "_txtreceivedqty").val(numberWithCommas($("#<%= grdfabricpurchased.ClientID %>_" + "ctl04" + "_hdnreceivedqty").val()));
                        //validatepageChangeState();

                    }, onPageError, false, false);
                    // Gerigeshnk = parseFloat(Residualshnk) - (parseFloat(Residualshnk) * parseFloat(gerigeshrnk) / parseFloat(100));
                    if (QtySend <= 0) {
                        alert("Receive qty cannot be 0");
                        $("#<%= grdfabricpurchased.ClientID %>_" + "ctl04" + "_txtreceivedqty").val(numberWithCommas(Math.round(oldreceivedqty)));
                    }
                    else {
                        $("#<%= grdfabricpurchased.ClientID %>_" + "ctl04" + "_txtreceivedqty").val(numberWithCommas(Math.round(QtySend)));
                    }


                    var SupplierQuotedRate = $("#<%= grdfabricpurchased.ClientID %>_" + "ctl04" + "_txtrateSupplierQuotedRate").val();
                    var ReceviedQty = $("#<%= grdfabricpurchased.ClientID %>_" + "ctl04" + "_txtreceivedqty").val().replace(",", "");
                    if (ReceviedQty == "") {
                        ReceviedQty = 0;
                    }
                    if (SupplierQuotedRate == "") {
                        SupplierQuotedRate = 0;
                    }
                    var TotalReceviedQty = numberWithCommas(
                        Math.round((
                            parseFloat($("#ctl00_cph_main_content_grdfabricpurchased_ctl04_txtreceivedqty").val().replace(",", ""))) *
                            (parseFloat(SupplierQuotedRate)),
                            0));
                    $("#<%= grdfabricpurchased.ClientID %>_" + "ctl04" + "_lbltotalAmount").text(TotalReceviedQty);
                }
            }
            else {


                if ($(select).val().toString() != defualtorderUnit.toString()) {
                    RemainingQtys = Math.round((parseFloat(RemainingQtys) * parseFloat(conversionvalue)));
                    OldSendQty = Math.round((parseFloat(OldSendQty) * parseFloat(conversionvalue)));
                    oldreceivedqty = Math.round((parseFloat(oldreceivedqty) * parseFloat(conversionvalue)));
                }

                if (Math.round(parseFloat(QtySend)) > Math.round(parseFloat(RemainingQtys))) {
                    alert("Send qty cannot be greater than available qty " + Math.round(parseFloat(RemainingQtys)));

                    elem.value = numberWithCommas(Math.round(OldSendQty));
                    $("#ctl00_cph_main_content_grdfabricpurchased_ctl04_txtreceivedqty").val(numberWithCommas(Math.round(oldreceivedqty)));
                    $("#ctl00_cph_main_content_lbltoqty0").text(oldreceivedqty);

                    Resetetagrd();
                }
                else {
                    var Residualshnk = 0;
                    var Gerigeshnk = 0;
                    var finalval = 0;
                    // Residualshnk = parseFloat(QtySend) - ((parseFloat(QtySend) * parseFloat(gerigeshrnk) / parseFloat(100)));
                    //GetReceiveQtyBySendQty(string flag, string flagoption, int fabricqualityid, string fabricdetails, int currentstagenumber, int previousstagenumber)

                    proxy.invoke("GetReceiveQtyBySendQty", { flag: Fabtypes, flagoption: "RECEIVEBYSNEDQTY", fabricqualityid: FabricQualityID, fabricdetails: colorprintdetail, currentstagenumber: currentstagenumber, previousstagenumber: previousstagenumber, pendingqty: QtySend, IsStyleSpecific: isStyleSpecific, styleid: styleid }, function (result) {

                        retrunval = result[0];

                        $("#<%= grdfabricpurchased.ClientID %>_" + "ctl04" + "_txtreceivedqty").val(numberWithCommas(result[0]));
                        $("[id$=_hdnstorepodate]").val($("#ctl00_cph_main_content_txtPoDate").val());
                        $("[id$=_hdnstoresupplierid]").val($("#" + ddlSupplierName).val());
                        $("[id$=_hdnstoreetadate]").val($("[id$=_txtETADate]").val());
                        //                        $("[id$=_hdnstoresendqty]").val($("[id$=_txtsendQty]").val());
                        //                        $("[id$=_hdnstorereceivedqty]").val($("[id$=_txtreceivedqty]").val());
                        $("[id$=_hdnstoreunitsid]").val($("#ctl00_cph_main_content_grdfabricpurchased_ctl04_ddlunits").val());
                        $("[id$=_hdnstorerate]").val($("[id$=_txtrateSupplierQuotedRate]").val());
                        $("[id$=_hdnstoretotalamount]").val($("[id$=_lbltotalAmount]").text());
                        $("[id$=_hdintialsuppliercode]").val($("[id$=_lblPoNo]").text());
                        // $("#<%= grdfabricpurchased.ClientID %>_" + "ctl04" + "_txtreceivedqty").val(numberWithCommas($("#<%= grdfabricpurchased.ClientID %>_" + "ctl04" + "_hdnreceivedqty").val()));
                        //validatepageChangeState();
                        Resetetagrd();


                        var SupplierQuotedRate = $("#<%= grdfabricpurchased.ClientID %>_" + "ctl04" + "_txtrateSupplierQuotedRate").val();
                        var ReceviedQty = $("#<%= grdfabricpurchased.ClientID %>_" + "ctl04" + "_txtreceivedqty").val().replace(",", "");
                        if (ReceviedQty == "") {
                            ReceviedQty = 0;
                        }
                        if (SupplierQuotedRate == "") {
                            SupplierQuotedRate = 0;
                        }
                        var TotalReceviedQty = numberWithCommas(Math.round(
                            (parseFloat($("#ctl00_cph_main_content_grdfabricpurchased_ctl04_txtreceivedqty").val().replace(",", ""))) *
                            (parseFloat(SupplierQuotedRate)), 0));
                        $("#<%= grdfabricpurchased.ClientID %>_" + "ctl04" + "_lbltotalAmount").text(TotalReceviedQty);

                    }, onPageError, false, false);

                    if ($("#<%= grdfabricpurchased.ClientID %>_" + "ctl04" + "_txtreceivedqty").val() == "0") {
                        alert("Receive qty cannot be 0");
                        $("#<%= grdfabricpurchased.ClientID %>_" + "ctl04" + "_txtreceivedqty").val(numberWithCommas(Math.round(oldreceivedqty)));
                    }
                    else {
                        $("#<%= grdfabricpurchased.ClientID %>_" + "ctl04" + "_txtreceivedqty").val(numberWithCommas(Math.round(Residualshnk)));
                    }
                }
            }

        }
        function ConversionValueChange(flag) {
            //  debugger;
            var Potype = '<%=this.Potype %>';
            var Fabtypes = '<%=this.Fabtype %>';
            var PoNumber = '<%=this.PoNumber %>';
            var MasterPoID = '<%=this.MasterPoID %>';
            var FabricQualityID = '<%=this.FabricQualityID %>';
            var currentstagenumber = '<%=this.currentstage %>';
            var previousstagenumber = '<%=this.previousstage %>';

            var resullt = "";
            var validateRemaningQty = '<%=this.RemaningQty %>';

            var isStyleSpecific = '<%=this.isStyleSpecific %>';
            var styleid = '<%=this.styleid %>';
            colorprintdetail = $("#ctl00_cph_main_content_grdfabricpurchased_ctl04_lblcolorprint").text();

            FabType = '<%=this.Fabtype %>';
            $("[id$=hdnconversionvalue]").val();
            var defualtorderUnit = $("[id$=_hdndefualtorderunit]").val();
            var ddlSelectdunit = $("#ctl00_cph_main_content_grdfabricpurchased_ctl04_ddlunits").val();
            var Enterdconversionvalue = $("#ctl00_cph_main_content_txttounit").val();
            var select = document.getElementById('ctl00_cph_main_content_grdfabricpurchased_ctl04_ddlunits');
            var OldRate = $("[id$=_txtrateSupplierQuotedRate]").val($("[id$=_hdnstorerate]").val());
            var OldRate = $("[id$=_hdnstorerate]").val();

            var QtySend = $("#<%= grdfabricpurchased.ClientID %>_" + "ctl04" + "_txtsendQty").val().replace(',', '');
            var OldSendQty = $("#<%= grdfabricpurchased.ClientID %>_" + "ctl04" + "_hdnsendqty").val().replace(',', '');
            oldreceivedqty = $("#<%= grdfabricpurchased.ClientID %>_" + "ctl04" + "_hdnreceivedqty").val().replace(',', '');
            var ActualSendQty = $("#<%= grdfabricpurchased.ClientID %>_" + "ctl04" + "_hdnSendQtyValidate").val().replace(',', '');
            var availablesendqty = $("#<%= grdfabricpurchased.ClientID %>_" + "ctl04" + "_hdnavailablesendqty").val().replace(',', '');
            var receiveqty = $('#ctl00_cph_main_content_grdfabricpurchased_ctl04_txtreceivedqty').val().replace(',', '');
            var OldSupplierRate = $("#ctl00_cph_main_content_grdfabricpurchased_ctl04_txtrateSupplierQuotedRate").val(); // added by shubhendu

            var HdnConvertTounit = $('#ctl00_cph_main_content_grdfabricpurchased_ctl04_hdnConvertTounit').val();
            var hdnsaveconversionvalue = $('#ctl00_cph_main_content_grdfabricpurchased_ctl04_hdnsaveconversionvalue').val();
            var cosval = $("[id$=hdnconversionvalue]").val();

            cosval = cosval == "" ? 0 : cosval;
            var retrunval = 0;
            if (QtySend == '') {
                QtySend = 0;
            }
            if (OldSendQty == '') {
                OldSendQty = 0;
            }
            if (receiveqty == '') {
                receiveqty = 0;
            }

            //            if (isStyleSpecific == 'False') {
            //                styleid = -1;
            //            }
            if (availablesendqty == '') {
                availablesendqty = 0;
            }

            if (Enterdconversionvalue == '') {
                Enterdconversionvalue = '0';
            }
            if (hdnsaveconversionvalue == '-1') {
                hdnsaveconversionvalue = 1;
            }
            if (flag == 'OK') {

                if (parseFloat(Enterdconversionvalue) <= 0) {
                    $('#ctl00_cph_main_content_txttounit').css('border-color', 'red');
                    alert("Enter valid conversion value");
                    $("#ctl00_cph_main_content_txttounit").val("");
                    //                    $("#ctl00_cph_main_content_txttounit").focus();

                }
                else {

                    $('#ctl00_cph_main_content_divSubmit').show();
                    $("[id$=hdnconversionvalue]").val(Enterdconversionvalue);

                    var Sendvals = parseFloat(OldSendQty) * parseFloat(Enterdconversionvalue);
                    //Change by shubhendu
                    var Receivevals = parseFloat(oldreceivedqty) * (parseFloat(Enterdconversionvalue) / hdnsaveconversionvalue);

                    var NewSupplierQuotedRate1 = parseFloat($("#ctl00_cph_main_content_grdfabricpurchased_ctl04_txtrateSupplierQuotedRate").val()) * (1 / Enterdconversionvalue);

                    // till here-------------------------------------------------------------------------------------------------------------

                    if (FabType.toLowerCase() == 'DYED'.toLowerCase() || FabType.toLowerCase() == 'PRINT'.toLowerCase() || FabType.toLowerCase() == 'RFD'.toLowerCase() || FabType.toLowerCase() == 'Embellishment'.toLowerCase() || FabType.toLowerCase() == 'Embroidery'.toLowerCase()) {

                        if (FabType.toLowerCase() == 'RFD'.toLowerCase() && currentstagenumber == "1") {

                            $("#ctl00_cph_main_content_grdfabricpurchased_ctl04_txtreceivedqty").val(numberWithCommas(Math.round(Receivevals)));
                            $('#ctl00_cph_main_content_grdfabricpurchased_ctl04_txtreceivedqty').removeAttr('readonly', 'readonly');
                            $('#ctl00_cph_main_content_grdfabricpurchased_ctl04_txtsendQty').attr('readonly', 'readonly');
                            $('#ctl00_cph_main_content_grdfabricpurchased_ctl04_txtsendQty').val('');
                            $("#ctl00_cph_main_content_grdfabricpurchased_ctl04_txtrateSupplierQuotedRate").val(NewSupplierQuotedRate1.toFixed(2));  //shubhendu;
                        }
                        else {
                            $('#ctl00_cph_main_content_grdfabricpurchased_ctl04_txtsendQty').removeAttr('readonly', 'readonly');
                            $("#ctl00_cph_main_content_grdfabricpurchased_ctl04_txtsendQty").val(numberWithCommas(Math.round(Sendvals)));
                            $("#ctl00_cph_main_content_grdfabricpurchased_ctl04_txtreceivedqty").val(numberWithCommas(Math.round(Receivevals)));
                            $("#ctl00_cph_main_content_grdfabricpurchased_ctl04_txtrateSupplierQuotedRate").val(NewSupplierQuotedRate1.toFixed(2)); //shubhendu
                        }

                        $("#divconversionorder").css("display", "none");
                    }
                    else {

                        $('#ctl00_cph_main_content_grdfabricpurchased_ctl04_txtreceivedqty').removeAttr('readonly', 'readonly');
                        $("#ctl00_cph_main_content_grdfabricpurchased_ctl04_txtreceivedqty").val(numberWithCommas(Math.round(Receivevals)));
                        $("#ctl00_cph_main_content_grdfabricpurchased_ctl04_txtrateSupplierQuotedRate").val(NewSupplierQuotedRate1.toFixed(2)); //shubhendu
                        $("#divconversionorder").css("display", "none");
                    }
                    Resetetagrd();


                }

            }
            else if (flag == 'CANCEL') {
                if (confirm('want to cancel selection')) {

                    $('#ctl00_cph_main_content_divSubmit').show();
                    $("#divconversionorder").css("display", "none");

                    document.getElementById('ctl00_cph_main_content_grdfabricpurchased_ctl04_ddlunits').setAttribute('title', '');
                    $(select).css('background-color', 'white');
                    for (var i = 0; i < select.options.length; i++) {
                        select.options[i].style.backgroundColor = 'white';
                        select.options[i].setAttribute('title', '');
                    }

                    if ($(select).val().toString() != defualtorderUnit.toString()) {
                        $("#ctl00_cph_main_content_grdfabricpurchased_ctl04_ddlunits").val(HdnConvertTounit);
                        if (Potype == 'RAISE') {
                            if (defualtorderUnit == "1") {
                            }
                        }
                        else {

                            $(select).css('background-color', 'yellow');
                            document.getElementById('ctl00_cph_main_content_grdfabricpurchased_ctl04_ddlunits').setAttribute('title', 'yellow color for you have moved to diffrent unit');
                            if ($(select).val().toString() == "1") {
                                $("#ctl00_cph_main_content_lbltounit").text("Mtr");
                                for (var i = 0; i < select.options.length; i++) {
                                    select.options["0"].style.backgroundColor = 'yellow';
                                }
                            }
                            else if ($(select).val().toString() == "4") {
                                $("#ctl00_cph_main_content_lbltounit").text("yard")
                                for (var i = 0; i < select.options.length; i++) {
                                    select.options["1"].style.backgroundColor = 'yellow';
                                }
                            }
                            else if ($(select).val().toString() == "3") {
                                $("#ctl00_cph_main_content_lbltounit").text("kg")
                                for (var i = 0; i < select.options.length; i++) {
                                    select.options["2"].style.backgroundColor = 'yellow';
                                }
                            }
                        }
                    }
                    else {
                        $("#ctl00_cph_main_content_grdfabricpurchased_ctl04_ddlunits").val(defualtorderUnit);
                    }
                    if (FabType.toLowerCase() == 'DYED'.toLowerCase() || FabType.toLowerCase() == 'PRINT'.toLowerCase() || FabType.toLowerCase() == 'RFD'.toLowerCase() || FabType.toLowerCase() == 'Embellishment'.toLowerCase() || FabType.toLowerCase() == 'Embroidery'.toLowerCase()) {
                        if (cosval > 0) {
                            var _Sendvals = Math.round((parseFloat(OldSendQty) * parseFloat(cosval)));
                            var _Receivevals = Math.round((parseFloat(oldreceivedqty) * parseFloat(cosval)));

                            if ($(select).val().toString() == HdnConvertTounit.toString()) {

                                if (Potype == 'RAISE') {
                                    $("#ctl00_cph_main_content_grdfabricpurchased_ctl04_txtsendQty").val(numberWithCommas(Math.round(OldSendQty)));
                                    $("#ctl00_cph_main_content_grdfabricpurchased_ctl04_txtreceivedqty").val(numberWithCommas(Math.round(oldreceivedqty)));
                                }
                                else {
                                    $("#ctl00_cph_main_content_grdfabricpurchased_ctl04_txtsendQty").val(numberWithCommas(Math.round(_Sendvals)));
                                    $("#ctl00_cph_main_content_grdfabricpurchased_ctl04_txtreceivedqty").val(numberWithCommas(Math.round(_Receivevals)));
                                }
                            }
                            else {
                                $("#ctl00_cph_main_content_grdfabricpurchased_ctl04_txtsendQty").val(numberWithCommas(Math.round(OldSendQty)));
                                $("#ctl00_cph_main_content_grdfabricpurchased_ctl04_txtreceivedqty").val(numberWithCommas(Math.round(oldreceivedqty)));
                            }

                            //--$("[id$=hdnconversionvalue]").val('0');

                            if (FabType.toLowerCase() == 'RFD'.toLowerCase() && currentstagenumber == "1") {

                                $('#ctl00_cph_main_content_grdfabricpurchased_ctl04_txtreceivedqty').removeAttr('readonly', 'readonly');
                                $('#ctl00_cph_main_content_grdfabricpurchased_ctl04_txtsendQty').attr('readonly', 'readonly');
                                $('#ctl00_cph_main_content_grdfabricpurchased_ctl04_txtsendQty').val('');
                            }
                            else {
                                $('#ctl00_cph_main_content_grdfabricpurchased_ctl04_txtsendQty').removeAttr('readonly', 'readonly');
                                $('#ctl00_cph_main_content_grdfabricpurchased_ctl04_txtreceivedqty').attr('readonly', 'readonly');

                            }


                        }
                        else {
                            if (OldSendQty == 0) {
                                OldSendQty = "";
                                $("#ctl00_cph_main_content_grdfabricpurchased_ctl04_txtsendQty").val(OldSendQty)// added by shubhe
                            }
                            $("#ctl00_cph_main_content_grdfabricpurchased_ctl04_txtreceivedqty").val(numberWithCommas(Math.round(oldreceivedqty)));
                            if (OldSendQty == "") {
                                OldSendQty = 0;
                            }
                        }

                        $('#ctl00_cph_main_content_grdfabricpurchased_ctl04_txtsendQty').removeAttr('readonly', 'readonly');
                    }
                    else {
                        if (cosval > 0) {
                            var _Sendvals = Math.round((parseFloat(OldSendQty) * parseFloat(cosval)));
                            var _Receivevals = Math.round((parseFloat(oldreceivedqty) * parseFloat(cosval)));

                            if ($(select).val().toString() == HdnConvertTounit.toString()) {
                                if (Potype == 'RAISE') {
                                    $("#ctl00_cph_main_content_grdfabricpurchased_ctl04_txtreceivedqty").val(numberWithCommas(Math.round(oldreceivedqty)));
                                }
                                else {
                                    $("#ctl00_cph_main_content_grdfabricpurchased_ctl04_txtreceivedqty").val(numberWithCommas(Math.round(_Receivevals)));
                                }
                            }
                            else {

                                $("#ctl00_cph_main_content_grdfabricpurchased_ctl04_txtreceivedqty").val(numberWithCommas(Math.round(oldreceivedqty)));
                            }
                            //-- $("[id$=hdnconversionvalue]").val('0');
                        }
                        else {
                            $("#ctl00_cph_main_content_grdfabricpurchased_ctl04_txtreceivedqty").val(numberWithCommas(Math.round(oldreceivedqty)));
                        }
                        $('#ctl00_cph_main_content_grdfabricpurchased_ctl04_txtreceivedqty').removeAttr('readonly', 'readonly');
                    }
                }
                else {
                    alert('Why did you press cancel? You should have confirmed');
                }
                //                $("[id$=hdnconversionvalue]").val('0');

                Resetetagrd();
            }
            else if (flag == 'UNITCHANGE') {


                Resetetagrd();
                document.getElementById('ctl00_cph_main_content_grdfabricpurchased_ctl04_ddlunits').setAttribute('title', '');

                $(select).css('background-color', 'white');
                for (var i = 0; i < select.options.length; i++) {
                    select.options[i].style.backgroundColor = 'white';
                    select.options[i].setAttribute('title', '');
                }

                if (cosval > 0) {
                    var _Sendvals = 0;
                    var _Receivevals = 0;
                    if (Potype == 'RERAISE') {
                        _Sendvals = Math.round((parseFloat(OldSendQty) * parseFloat(hdnsaveconversionvalue)));
                        _Receivevals = Math.round((parseFloat(oldreceivedqty) * parseFloat(hdnsaveconversionvalue)));
                    }
                    else {
                        _Sendvals = Math.round((parseFloat(OldSendQty) * parseFloat(1)));
                        _Receivevals = Math.round((parseFloat(oldreceivedqty) * parseFloat(1)));
                    }

                    if (FabType.toLowerCase() == 'DYED'.toLowerCase() || FabType.toLowerCase() == 'PRINT'.toLowerCase() || FabType.toLowerCase() == 'RFD'.toLowerCase() || FabType.toLowerCase() == 'Embellishment'.toLowerCase() || FabType.toLowerCase() == 'Embroidery'.toLowerCase()) {

                        if ($(select).val().toString() == HdnConvertTounit.toString()) {
                            $("#ctl00_cph_main_content_grdfabricpurchased_ctl04_txtsendQty").val(numberWithCommas(Math.round(_Sendvals)));
                            $("#ctl00_cph_main_content_grdfabricpurchased_ctl04_txtreceivedqty").val(numberWithCommas(Math.round(_Receivevals)));
                            $("[id$=_txtrateSupplierQuotedRate]").val($("[id$=_hdnstorerate]").val()); // added by shubhendu
                            $("#ctl00_cph_main_content_txttounit").val(hdnsaveconversionvalue);
                            $("[id$=hdnconversionvalue]").val(hdnsaveconversionvalue);
                            $("#divconversionorder").css("display", "block");

                            if (FabType.toLowerCase() == 'RFD'.toLowerCase() && currentstagenumber == "1") {

                                $('#ctl00_cph_main_content_grdfabricpurchased_ctl04_txtreceivedqty').removeAttr('readonly', 'readonly');
                                $('#ctl00_cph_main_content_grdfabricpurchased_ctl04_txtsendQty').attr('readonly', 'readonly');
                                $('#ctl00_cph_main_content_grdfabricpurchased_ctl04_txtsendQty').val('');
                            }
                            else {
                                $('#ctl00_cph_main_content_grdfabricpurchased_ctl04_txtsendQty').removeAttr('readonly', 'readonly');
                                $('#ctl00_cph_main_content_grdfabricpurchased_ctl04_txtreceivedqty').attr('readonly', 'readonly');

                            }

                        }
                        else {

                            $("#ctl00_cph_main_content_grdfabricpurchased_ctl04_txtsendQty").val(numberWithCommas(Math.round(OldSendQty)));
                            $("#ctl00_cph_main_content_grdfabricpurchased_ctl04_txtreceivedqty").val(numberWithCommas(Math.round(oldreceivedqty)));
                        }

                    }
                    else {
                        if ($(select).val().toString() == HdnConvertTounit.toString()) {
                            $("#ctl00_cph_main_content_grdfabricpurchased_ctl04_txtreceivedqty").val(numberWithCommas(Math.round(_Receivevals)));
                            $("[id$=_txtrateSupplierQuotedRate]").val(OldRate);
                        }
                        else {
                            $("#ctl00_cph_main_content_grdfabricpurchased_ctl04_txtreceivedqty").val(numberWithCommas(Math.round(oldreceivedqty)));
                        }
                    }
                    // $("[id$=hdnconversionvalue]").val('0');
                }
                else {

                    if (FabType.toLowerCase() == 'DYED'.toLowerCase() || FabType.toLowerCase() == 'PRINT'.toLowerCase() || FabType.toLowerCase() == 'RFD'.toLowerCase() || FabType.toLowerCase() == 'Embellishment'.toLowerCase() || FabType.toLowerCase() == 'Embroidery'.toLowerCase()) {
                        $("#ctl00_cph_main_content_grdfabricpurchased_ctl04_txtsendQty").val(OldSendQty)
                        $("#ctl00_cph_main_content_grdfabricpurchased_ctl04_txtreceivedqty").val(numberWithCommas(Math.round(oldreceivedqty)));

                        $("#ctl00_cph_main_content_grdfabricpurchased_ctl04_txtrateSupplierQuotedRate").val(($("[id$=_hdnstorerate]").val())); // added by shubhendu

                        if (FabType.toLowerCase() == 'RFD'.toLowerCase() && currentstagenumber == "1") {

                            $('#ctl00_cph_main_content_grdfabricpurchased_ctl04_txtreceivedqty').removeAttr('readonly', 'readonly');
                            $('#ctl00_cph_main_content_grdfabricpurchased_ctl04_txtsendQty').attr('readonly', 'readonly');
                            $('#ctl00_cph_main_content_grdfabricpurchased_ctl04_txtsendQty').val('');
                        }
                        else {
                            $('#ctl00_cph_main_content_grdfabricpurchased_ctl04_txtsendQty').removeAttr('readonly', 'readonly');
                            $('#ctl00_cph_main_content_grdfabricpurchased_ctl04_txtreceivedqty').attr('readonly', 'readonly');

                        }


                    }
                    else {
                        $('#ctl00_cph_main_content_grdfabricpurchased_ctl04_txtreceivedqty').removeAttr('readonly', 'readonly');
                        $("#ctl00_cph_main_content_grdfabricpurchased_ctl04_txtreceivedqty").val(numberWithCommas(Math.round(oldreceivedqty)));
                    }
                }
                if (ddlSelectdunit.toString() != defualtorderUnit.toString()) {
                    $('#ctl00_cph_main_content_divSubmit').hide();
                    $("#divconversionorder").css("display", "block");

                    $(select).css('background-color', 'yellow');
                    if ($(select).val().toString() != HdnConvertTounit.toString()) {
                        $("#ctl00_cph_main_content_txttounit").val("");
                    }

                    if (FabType.toLowerCase() == 'DYED'.toLowerCase() || FabType.toLowerCase() == 'PRINT'.toLowerCase() || FabType.toLowerCase() == 'RFD'.toLowerCase() || FabType.toLowerCase() == 'Embellishment'.toLowerCase() || FabType.toLowerCase() == 'Embroidery'.toLowerCase()) {

                        $('#ctl00_cph_main_content_grdfabricpurchased_ctl04_txtsendQty').attr('readonly', 'readonly');


                    }
                    else {
                        $('#ctl00_cph_main_content_grdfabricpurchased_ctl04_txtreceivedqty').attr('readonly', 'readonly');
                    }
                    if ($(select).val().toString() == HdnConvertTounit.toString()) {
                        // $("#divconversionorder").css("display", "none");
                        $("#ctl00_cph_main_content_txttounit").val($("[id$=hdnconversionvalue]").val());
                        if (FabType.toLowerCase() == 'DYED'.toLowerCase() || FabType.toLowerCase() == 'PRINT'.toLowerCase() || FabType.toLowerCase() == 'RFD'.toLowerCase() || FabType.toLowerCase() == 'Embellishment'.toLowerCase() || FabType.toLowerCase() == 'Embroidery'.toLowerCase()) {

                            $('#ctl00_cph_main_content_grdfabricpurchased_ctl04_txtsendQty').removeAttr('readonly', 'readonly');

                            if (FabType.toLowerCase() == 'RFD'.toLowerCase() && currentstagenumber == "1") {

                                $('#ctl00_cph_main_content_grdfabricpurchased_ctl04_txtreceivedqty').removeAttr('readonly', 'readonly');
                                $('#ctl00_cph_main_content_grdfabricpurchased_ctl04_txtsendQty').attr('readonly', 'readonly');
                                $('#ctl00_cph_main_content_grdfabricpurchased_ctl04_txtsendQty').val('');
                            }
                            else {
                                $('#ctl00_cph_main_content_grdfabricpurchased_ctl04_txtsendQty').removeAttr('readonly', 'readonly');
                                $('#ctl00_cph_main_content_grdfabricpurchased_ctl04_txtreceivedqty').attr('readonly', 'readonly');

                            }


                        }
                        else {
                            $('#ctl00_cph_main_content_grdfabricpurchased_ctl04_txtreceivedqty').removeAttr('readonly', 'readonly');
                        }
                    }
                    document.getElementById('ctl00_cph_main_content_grdfabricpurchased_ctl04_ddlunits').setAttribute('title', 'yellow color for you have moved to diffrent unit');

                    if (defualtorderUnit == "1") {
                        $("#ctl00_cph_main_content_lblfromunit").text("Mtr");
                    }
                    else if (defualtorderUnit == "4") {
                        $("#ctl00_cph_main_content_lblfromunit").text("yard")
                    }
                    else if (defualtorderUnit == "3") {
                        $("#ctl00_cph_main_content_lblfromunit").text("kg")
                    }

                    if (ddlSelectdunit == "1") {
                        $("#ctl00_cph_main_content_lbltounit").text("Mtr");
                        for (var i = 0; i < select.options.length; i++) {
                            select.options["0"].style.backgroundColor = 'yellow';
                        }
                    }
                    else if (ddlSelectdunit == "4") {
                        $("#ctl00_cph_main_content_lbltounit").text("yard")
                        for (var i = 0; i < select.options.length; i++) {
                            select.options["1"].style.backgroundColor = 'yellow';
                        }
                    }
                    else if (ddlSelectdunit == "3") {
                        $("#ctl00_cph_main_content_lbltounit").text("kg")
                        for (var i = 0; i < select.options.length; i++) {
                            select.options["2"].style.backgroundColor = 'yellow';
                        }
                    }
                }
                else {
                    // $("[id$=hdnconversionvalue]").val('0');
                    $('#ctl00_cph_main_content_divSubmit').show();
                    $("#divconversionorder").css("display", "none");

                    if (FabType.toLowerCase() == 'DYED'.toLowerCase() || FabType.toLowerCase() == 'PRINT'.toLowerCase() || FabType.toLowerCase() == 'RFD'.toLowerCase() || FabType.toLowerCase() == 'Embellishment'.toLowerCase() || FabType.toLowerCase() == 'Embroidery'.toLowerCase()) {
                        $('#ctl00_cph_main_content_grdfabricpurchased_ctl04_txtsendQty').removeAttr('readonly', 'readonly');

                        if (FabType.toLowerCase() == 'RFD'.toLowerCase() && currentstagenumber == "1") {

                            $('#ctl00_cph_main_content_grdfabricpurchased_ctl04_txtreceivedqty').removeAttr('readonly', 'readonly');
                            $('#ctl00_cph_main_content_grdfabricpurchased_ctl04_txtsendQty').attr('readonly', 'readonly');
                            $('#ctl00_cph_main_content_grdfabricpurchased_ctl04_txtsendQty').val('');
                        }
                        else {
                            $('#ctl00_cph_main_content_grdfabricpurchased_ctl04_txtsendQty').removeAttr('readonly', 'readonly');
                            $('#ctl00_cph_main_content_grdfabricpurchased_ctl04_txtreceivedqty').attr('readonly', 'readonly');

                        }

                    }
                    else {
                        $('#ctl00_cph_main_content_grdfabricpurchased_ctl04_txtreceivedqty').removeAttr('readonly', 'readonly');
                    }
                    Resetetagrd();
                }
            }
            else if (flag == "REOPEN") {
                document.getElementById('ctl00_cph_main_content_grdfabricpurchased_ctl04_ddlunits').setAttribute('title', '');
                $(select).css('background-color', 'white');
                for (var i = 0; i < select.options.length; i++) {
                    select.options[i].style.backgroundColor = 'white';
                    select.options[i].setAttribute('title', '');
                }
                if (ddlSelectdunit.toString() != defualtorderUnit.toString()) {


                    $(select).css('background-color', 'yellow');
                    $("#ctl00_cph_main_content_txttounit").val("");
                    //                    if (FabType == 'DYED' || FabType == 'PRINT' || FabType == 'RFD' || FabType == 'Embellishment' || FabType == 'Embroidery') {

                    //                        $('#ctl00_cph_main_content_grdfabricpurchased_ctl04_txtsendQty').attr('readonly', 'readonly');
                    //                    }
                    //                    else {

                    //                        $('#ctl00_cph_main_content_grdfabricpurchased_ctl04_txtreceivedqty').attr('readonly', 'readonly');
                    //                    }

                    if (defualtorderUnit == "1") {
                        $("#ctl00_cph_main_content_lblfromunit").text("Mtr");
                    }
                    else if (defualtorderUnit == "4") {
                        $("#ctl00_cph_main_content_lblfromunit").text("yard")
                    }
                    else if (defualtorderUnit == "3") {
                        $("#ctl00_cph_main_content_lblfromunit").text("kg")
                    }

                    if (ddlSelectdunit == "1") {
                        $("#ctl00_cph_main_content_lbltounit").text("Mtr");
                        for (var i = 0; i < select.options.length; i++) {
                            select.options["0"].style.backgroundColor = 'yellow';
                        }
                    }
                    else if (ddlSelectdunit == "4") {
                        $("#ctl00_cph_main_content_lbltounit").text("yard")
                        for (var i = 0; i < select.options.length; i++) {
                            select.options["1"].style.backgroundColor = 'yellow';
                        }
                    }
                    else if (ddlSelectdunit == "3") {
                        $("#ctl00_cph_main_content_lbltounit").text("kg")
                        for (var i = 0; i < select.options.length; i++) {
                            select.options["2"].style.backgroundColor = 'yellow';
                        }
                    }
                    document.getElementById('ctl00_cph_main_content_grdfabricpurchased_ctl04_ddlunits').setAttribute('title', 'Unit Changed (Conversion Value ' + $("[id$=hdnconversionvalue]").val() + ' )');
                }
            }
            //change by shubhendu
            //  var SupplierQuotedRate1 = parseFloat($("#ctl00_cph_main_content_grdfabricpurchased_ctl04_txtrateSupplierQuotedRate").val())*2;

            var TotalReceviedQty = numberWithCommas(Math.round((parseFloat($("#ctl00_cph_main_content_grdfabricpurchased_ctl04_txtreceivedqty").val().replace(",", ""))) *
                    (parseFloat($("#ctl00_cph_main_content_grdfabricpurchased_ctl04_txtrateSupplierQuotedRate").val().replace(",", "")) * 2)), 0);


            $("#ctl00_cph_main_content_grdfabricpurchased_ctl04_lbltotalAmount").text(TotalReceviedQty);

            //            $(".uts").text($("#ctl00_cph_main_content_grdfabricpurchased_ctl04_ddlunits option:selected").text());    

            $("#ctl00_cph_main_content_lblunitto").text($("#ctl00_cph_main_content_grdfabricpurchased_ctl04_ddlunits option:selected").text());
            $("#ctl00_cph_main_content_lblunitfrom").text($("#ctl00_cph_main_content_grdfabricpurchased_ctl04_ddlunits option:selected").text());
        }

        function Setfn() {
            _oldsends = $("#ctl00_cph_main_content_grdfabricpurchased_ctl04_txtsendQty").val();
            _oldrececive = $("#ctl00_cph_main_content_grdfabricpurchased_ctl04_txtreceivedqty").val();

        }
        function Addnew(flag) {

            var Haserror = true;
            var addtxtfromqty = $("#ctl00_cph_main_content_txtfromqty").val();
            var addtxttoqty = $("#ctl00_cph_main_content_txttoqty").val();
            var addtxtetabreakedate = $("#ctl00_cph_main_content_txtetabreakedate").val();
            if (flag == 'ADD') {
                if (addtxtfromqty == '') {
                    alert('Enter from qty');
                    Haserror = false;
                }
                else if (addtxttoqty == '') {
                    alert('Enter to qty');
                    Haserror = false;
                }
                else if (addtxtetabreakedate == '') {
                    alert('Enter date qty');
                    Haserror = false;
                }
                if (Haserror == true) {
                    for (i = 1; i <= 10; i++) {

                        if ($('#ctl00_cph_main_content_txtfromqty' + i).val() == '' && $('#ctl00_cph_main_content_txttoqty' + i).val() == '') {
                            $('#trbreaek' + i).show();

                            $('#ctl00_cph_main_content_txtfromqty' + i).val(addtxtfromqty);
                            $('#ctl00_cph_main_content_txttoqty' + i).val(addtxttoqty);

                            $('#ctl00_cph_main_content_lblfromqty' + i).text(addtxtfromqty);
                            $('#ctl00_cph_main_content_lbltoqty' + i).text(addtxttoqty);

                            $('#ctl00_cph_main_content_lbletabreakedate' + i).text(addtxttoqty);
                            $('#ctl00_cph_main_content_txtetabreakedate' + i).val(addtxttoqty);

                            $("#ctl00_cph_main_content_txtfromqty").val("");
                            $("#ctl00_cph_main_content_txttoqty").val("");
                            $("#ctl00_cph_main_content_txtetabreakedate").val("");

                            break;
                        }

                    }
                }

            }
            else if (flag == 'SHOW') {
                var table = document.getElementById('tblbreakedown');
                var rowLength = table.rows.length;

                for (var i = 0; i < rowLength; i += 1) {
                    var row = table.rows[i];
                    if (row.cells[0].innerText.trim() != "" && row.cells[1].innerText.trim() != "") {
                        $('#trbreaek' + parseInt(i).toString()).show();
                    }
                }
            }

        }
        function retunmonth(month) {
            if (month == 'Jan') {
                return 1
            }
            else if (month == 'Feb') {
                return 2
            }
            else if (month == 'Mar') {
                return 3
            }
            else if (month == 'Apr') {
                return 4
            }
            else if (month == 'May') {
                return 5
            }
            else if (month == 'Jun') {
                return 6
            }
            else if (month == 'Jul') {
                return 7
            }
            else if (month == 'Aug') {
                return 8
            }
            else if (month == 'Sep') {
                return 9
            }
            else if (month == 'Oct') {
                return 10
            }
            else if (month == 'Nov') {
                return 11
            }
            else if (month == 'Dec') {
                return 12
            }
        }
        function CheckEtadates2(rowindex) {


            var table = document.getElementById('tblbreakedown');
            var rowLength = table.rows.length;

            var _globalqty = $("#ctl00_cph_main_content_grdfabricpurchased_ctl04_txtreceivedqty").val().replace(",", "");
            var enterdval = $('#ctl00_cph_main_content_txttoqty' + rowindex).val().replace(",", "");

            var Selecteddate = $('#ctl00_cph_main_content_txtetabreakedate' + rowindex).val();
            var SelectRowparts = Selecteddate.split(' ');
            var SelectRowmydate = new Date('20' + SelectRowparts[2], retunmonth(SelectRowparts[1]) - 1, SelectRowparts[0]);

            var fromdate;
            var fromdateRowparts;
            var fromRowmydate;

            var todate;
            var todateRowparts;
            var toRowmydate;

            var maxdate = $('#ctl00_cph_main_content_txtETADate').val();
            var maxdateRowparts = maxdate.split(' ');
            var maxRowmydate = new Date('20' + maxdateRowparts[2], retunmonth(maxdateRowparts[1]) - 1, maxdateRowparts[0]);

            var previousindex = 0;
            var nextindex = 1;
            if (rowindex != 0) {

                previousindex = parseInt(rowindex) - 1;
                nextindex = parseInt(rowindex) + 1;

                fromdate = $('#ctl00_cph_main_content_lbletabreakedate' + previousindex).text();
                fromdateRowparts = fromdate.split(' ');
                fromRowmydate = new Date('20' + fromdateRowparts[2], retunmonth(fromdateRowparts[1]) - 1, fromdateRowparts[0]);
            }
            else {
                fromdate = $('#ctl00_cph_main_content_txtPoDate').val();
                fromdateRowparts = fromdate.split(' ');
                fromRowmydate = new Date('20' + fromdateRowparts[2], retunmonth(fromdateRowparts[1]) - 1, fromdateRowparts[0] - 1);
            }

            todate = $('#ctl00_cph_main_content_lbletabreakedate' + nextindex).text();
            if (todate == "") {
                todate = $('#ctl00_cph_main_content_txtETADate').val();

            }

            todateRowparts = todate.split(' ');
            toRowmydate = new Date('20' + todateRowparts[2], retunmonth(todateRowparts[1]) - 1, todateRowparts[0]);


            if ((SelectRowmydate > fromRowmydate && SelectRowmydate < toRowmydate)) {

            }
            else if ((SelectRowmydate <= fromRowmydate || SelectRowmydate >= toRowmydate)) {
                if (parseInt(enterdval) < parseInt(_globalqty)) {
                    alert("Selected date already exsting in previous date ETA");
                    $('#ctl00_cph_main_content_txtetabreakedate' + rowindex).val("");
                }
                else {
                    if (SelectRowmydate <= fromRowmydate) {
                        alert("Selected date already exsting in previous date ETA");
                        $('#ctl00_cph_main_content_txtetabreakedate' + rowindex).val("");
                    }
                }
            }
            else {

                if (parseInt(enterdval) < parseInt(_globalqty)) {
                    if ($('#ctl00_cph_main_content_txtetabreakedate' + rowindex).val() == $('#ctl00_cph_main_content_txtETADate').val()) {
                        $('#ctl00_cph_main_content_txtetabreakedate' + rowindex).val("");
                    }
                    //                    else {
                    //                        //                        $('#ctl00_cph_main_content_txtetabreakedate' + rowindex).val($('#ctl00_cph_main_content_lbletabreakedate' + rowindex).text());
                    //                        $('#ctl00_cph_main_content_txtetabreakedate' + rowindex).val("");
                    //                    }

                }
                else if (parseInt(enterdval) == parseInt(_globalqty)) {

                }
                else {

                    $('#ctl00_cph_main_content_txtetabreakedate' + rowindex).val($('#ctl00_cph_main_content_lbletabreakedate' + rowindex).text());
                }
                return false;
            }
            if (SelectRowmydate > maxRowmydate) {
                alert("this range date must between PO date and Eta Date");
                $('#ctl00_cph_main_content_txtetabreakedate' + rowindex).val($('#ctl00_cph_main_content_lbletabreakedate' + rowindex).text());
                return false;
            }
            //}
        }
        function EtagrdRest() {


            var table = document.getElementById('tblbreakedown');
            var rowLength = table.rows.length;
            var _globalqty = $("#ctl00_cph_main_content_grdfabricpurchased_ctl04_txtreceivedqty").val();
            var POETAdate = $("#ctl00_cph_main_content_txtETADate").val();
            $('#ctl00_cph_main_content_txtfromqty' + parseInt(0).toString()).val(1);
            $('#ctl00_cph_main_content_txttoqty' + parseInt(0).toString()).val(_globalqty);
            //$('#ctl00_cph_main_content_txtetabreakedate' + parseInt(0).toString()).val(POETAdate);

            $('#ctl00_cph_main_content_lblfromqty' + +parseInt(0).toString()).text(1);
            $('#ctl00_cph_main_content_lbltoqty' + parseInt(0).toString()).text(_globalqty);
            $('#ctl00_cph_main_content_lbletabreakedate' + parseInt(0).toString()).text(POETAdate);


            for (var i = 1; i < rowLength; i += 1) {
                var row = table.rows[i];
                $('#trbreaek' + parseInt(i).toString()).hide();

                $('#ctl00_cph_main_content_txtfromqty' + parseInt(i).toString()).val("");
                $('#ctl00_cph_main_content_txttoqty' + parseInt(i).toString()).val("");
                $('#ctl00_cph_main_content_txtetabreakedate' + parseInt(i).toString()).val("");

                $('#ctl00_cph_main_content_lblfromqty' + parseInt(i).toString()).text("");
                $('#ctl00_cph_main_content_lbltoqty' + parseInt(i).toString()).text("");
                $('#ctl00_cph_main_content_lbletabreakedate' + parseInt(i).toString()).text("");

                $('#ctl00_cph_main_content_txtfromqty' + parseInt(i).toString()).hide();
                $('#ctl00_cph_main_content_txttoqty' + parseInt(i).toString()).hide();


                $('#edit' + i).hide();
                $('#ctl00_cph_main_content_txtetabreakedate' + parseInt(i).toString()).hide();

                $('#editcancel' + parseInt(i).toString()).hide();
                $('#editupdate' + parseInt(i).toString()).hide();
                $('#editdelete' + parseInt(i).toString()).hide();
            }
        }
        function Edit(commandname, rowindex) {

            if (rowindex == 7)
                return;

            var Potype = '<%=this.Potype %>';
            var POETAdate = $("#ctl00_cph_main_content_txtETADate").val();
            var _globalqty = parseInt($("#ctl00_cph_main_content_grdfabricpurchased_ctl04_txtreceivedqty").val().replace(",", ""));
            if (commandname == 'EDIT') {
                var table = document.getElementById('tblbreakedown');
                var rowLength = table.rows.length;

                for (var i = 0; i < rowLength; i += 1) {
                    var row = table.rows[i];

                    $('#ctl00_cph_main_content_txtfromqty' + parseInt(i).toString()).hide();
                    $('#ctl00_cph_main_content_txttoqty' + parseInt(i).toString()).hide();

                    $('#ctl00_cph_main_content_lblfromqty' + parseInt(i).toString()).show();
                    $('#ctl00_cph_main_content_lbltoqty' + parseInt(i).toString()).show();

                    $('#ctl00_cph_main_content_txtfromqty' + parseInt(i).toString()).val($('#ctl00_cph_main_content_lblfromqty' + +parseInt(i).toString()).text());
                    $('#ctl00_cph_main_content_txttoqty' + parseInt(i).toString()).val($('#ctl00_cph_main_content_lbltoqty' + +parseInt(i).toString()).text());

                    $('#ctl00_cph_main_content_txtetabreakedate' + parseInt(i).toString()).hide();
                    $('#ctl00_cph_main_content_lbletabreakedate' + parseInt(i).toString()).show();

                    $('#editcancel' + parseInt(i).toString()).hide();
                    $('#editupdate' + parseInt(i).toString()).hide();
                    $('#editdelete' + parseInt(i).toString()).show();
                    $('#edit' + parseInt(i).toString()).show();


                }


                $('#ctl00_cph_main_content_txtfromqty' + rowindex).show();
                $('#ctl00_cph_main_content_txttoqty' + rowindex).show();
                $('#ctl00_cph_main_content_lblfromqty' + rowindex).hide();
                $('#ctl00_cph_main_content_lbltoqty' + rowindex).hide();
                $('#ctl00_cph_main_content_lbletabreakedate' + rowindex).hide();
                $('#ctl00_cph_main_content_txtetabreakedate' + rowindex).show();
                $('#edit' + rowindex).hide();
                $('#editdelete' + rowindex).hide();
                $('#editcancel' + rowindex).show();
                $('#editupdate' + rowindex).show();



                for (var i = 0; i < rowLength; i += 1) {
                    var row = table.rows[i];
                    if (i != rowindex) {


                        $('#ctl00_cph_main_content_txtfromqty' + parseInt(i).toString()).hide();
                        $('#ctl00_cph_main_content_txttoqty' + parseInt(i).toString()).hide();

                        $('#ctl00_cph_main_content_lblfromqty' + parseInt(i).toString()).show();
                        $('#ctl00_cph_main_content_lbltoqty' + parseInt(i).toString()).show();

                        $('#ctl00_cph_main_content_txtfromqty' + parseInt(i).toString()).val($('#ctl00_cph_main_content_lblfromqty' + +parseInt(i).toString()).text());
                        $('#ctl00_cph_main_content_txttoqty' + parseInt(i).toString()).val($('#ctl00_cph_main_content_lbltoqty' + +parseInt(i).toString()).text());

                        $('#ctl00_cph_main_content_txtetabreakedate' + parseInt(i).toString()).hide();
                        $('#ctl00_cph_main_content_lbletabreakedate' + parseInt(i).toString()).show();

                        $('#editcancel' + parseInt(i).toString()).hide();
                        $('#editupdate' + parseInt(i).toString()).hide();
                        $('#editdelete' + parseInt(i).toString()).show();
                    }
                }
            }
            if (commandname == 'DELETE') {
                //                   

                var f = isNaN(parseInt($('#ctl00_cph_main_content_txtfromqty' + parseInt(rowindex - 1).toString()).val().replace(",", ""))) ? 0 : parseInt($('#ctl00_cph_main_content_txtfromqty' + parseInt(rowindex - 1).toString()).val().replace(",", ""));
                var t = isNaN(parseInt($('#ctl00_cph_main_content_txttoqty' + parseInt(rowindex - 1).toString()).val().replace(",", ""))) ? 0 : parseInt($('#ctl00_cph_main_content_txttoqty' + parseInt(rowindex - 1).toString()).val().replace(",", ""));

                var table = document.getElementById('tblbreakedown');
                var rowLength = table.rows.length;


                var _globalqty = $("#ctl00_cph_main_content_grdfabricpurchased_ctl04_txtreceivedqty").val();
                var POETAdate = $("#ctl00_cph_main_content_txtETADate").val();


                if (confirm("Are you sure want to delete row!")) {


                    //$('#trbreaek' + parseInt(rowindex)+1).show();
                    $('#ctl00_cph_main_content_txtfromqty' + (parseInt(rowindex)).toString()).val(t + 1);
                    $('#ctl00_cph_main_content_lblfromqty' + +parseInt(parseInt(rowindex)).toString()).text(t + 1);
                    $('#ctl00_cph_main_content_txttoqty' + parseInt(parseInt(rowindex)).toString()).val(_globalqty);
                    $('#ctl00_cph_main_content_lbltoqty' + parseInt(parseInt(rowindex)).toString()).text(_globalqty);

                    $('#ctl00_cph_main_content_txtetabreakedate' + parseInt(parseInt(rowindex)).toString()).val(POETAdate);
                    $('#ctl00_cph_main_content_lbletabreakedate' + parseInt(parseInt(rowindex)).toString()).text(POETAdate);


                    for (var i = rowindex; i < rowLength; i += 1) {
                        var row = table.rows[i];
                        $('#trbreaek' + (parseInt(i) + 1).toString()).hide();

                        $('#ctl00_cph_main_content_txtfromqty' + (parseInt(i) + 1).toString()).val("");
                        $('#ctl00_cph_main_content_txttoqty' + (parseInt(i) + 1).toString()).val("");
                        $('#ctl00_cph_main_content_txtetabreakedate' + (parseInt(i) + 1).toString()).val("");

                        $('#ctl00_cph_main_content_lblfromqty' + (parseInt(i) + 1).toString()).text("");
                        $('#ctl00_cph_main_content_lbltoqty' + (parseInt(i) + 1).toString()).text("");


                        $('#ctl00_cph_main_content_txtfromqty' + (parseInt(i) + 1).toString()).hide();
                        $('#ctl00_cph_main_content_txttoqty' + (parseInt(i) + 1).toString()).hide();

                        $('#ctl00_cph_main_content_lbletabreakedate' + (parseInt(i) + 1).toString()).text("");
                        $('#ctl00_cph_main_content_txtetabreakedate' + (parseInt(i) + 1).toString()).hide();
                    }
                }
            }
            else if (commandname == 'CANCELEDIT') {

                var table = document.getElementById('tblbreakedown');
                var rowLength = table.rows.length;

                for (var i = rowindex; i < rowLength; i += 1) {
                    var row = table.rows[i];



                    $('#ctl00_cph_main_content_txtfromqty' + i).hide();
                    $('#ctl00_cph_main_content_txttoqty' + i).hide();

                    $('#ctl00_cph_main_content_lblfromqty' + i).show();
                    $('#ctl00_cph_main_content_lbltoqty' + i).show();
                    $('#edit' + i).show();

                    $('#ctl00_cph_main_content_txtfromqty' + i).val($('#ctl00_cph_main_content_lblfromqty' + +parseInt(i).toString()).text().replace(",", ""));
                    $('#ctl00_cph_main_content_txttoqty' + i).val($('#ctl00_cph_main_content_lbltoqty' + +parseInt(i).toString()).text().replace(",", ""));

                    $('#ctl00_cph_main_content_txtetabreakedate' + i).hide();
                    $('#ctl00_cph_main_content_lbletabreakedate' + i).show();

                    $('#editcancel' + i).hide();
                    $('#editupdate' + i).hide();
                    $('#editdelete' + i).show();



                }


            }
            else if (commandname == 'UPDATE') {
                var table = document.getElementById('tblbreakedown');
                var rowLength = table.rows.length;

                var f = isNaN(parseInt($('#ctl00_cph_main_content_txtfromqty' + parseInt(rowindex).toString()).val().replace(",", ""))) ? 0 : parseInt($('#ctl00_cph_main_content_txtfromqty' + parseInt(rowindex).toString()).val().replace(",", ""));
                var t = isNaN(parseInt($('#ctl00_cph_main_content_txttoqty' + parseInt(rowindex).toString()).val().replace(",", ""))) ? 0 : parseInt($('#ctl00_cph_main_content_txttoqty' + parseInt(rowindex).toString()).val().replace(",", ""));
                var d = $('#ctl00_cph_main_content_txtetabreakedate' + parseInt(rowindex).toString()).val();

                var str = "";
                if (t == "") {
                    alert("Enter value");
                    $('#ctl00_cph_main_content_txttoqty' + rowindex).val($('#ctl00_cph_main_content_lbltoqty' + rowindex).text().replace(",", ""));
                    return;
                }
                else if (t <= 0) {
                    alert("Enter valid value");
                    $('#ctl00_cph_main_content_txttoqty' + rowindex).val($('#ctl00_cph_main_content_lbltoqty' + rowindex).text().replace(",", ""));
                    return;
                }
                else if (t > _globalqty) {
                    alert("entred qty cannot be greater than receive qty: " + _globalqty);
                    $('#ctl00_cph_main_content_txttoqty' + rowindex).val($('#ctl00_cph_main_content_lbltoqty' + rowindex).text().replace(",", ""));
                    return;
                }
                else if (t < f) {
                    alert("entred qty cannot be less  than from qty: " + f);
                    $('#ctl00_cph_main_content_txttoqty' + rowindex).val($('#ctl00_cph_main_content_lbltoqty' + rowindex).text().replace(",", ""));
                    return;
                }
                if (d == "") {
                    alert("Enter date");

                    return;
                }
                else {

                    for (var i = 0; i <= rowindex; i += 1) {
                        var row = table.rows[i];
                        if (row != undefined) {
                            if (i != rowindex) {

                                if (row.cells[0].innerText.trim() != "" && row.cells[1].innerText.trim() != "") {

                                    var loopfromqty = parseInt(row.cells[0].innerText.trim().replace(",", ""));
                                    var looptoqty = parseInt(row.cells[1].innerText.trim().replace(",", ""));
                                    var Etadate = row.cells[2].innerText.trim();

                                    if (t >= loopfromqty && t <= looptoqty) {

                                        str = "entred value exists between " + loopfromqty + " to " + looptoqty;
                                        alert(str);
                                        $('#ctl00_cph_main_content_txttoqty' + rowindex).val($('#ctl00_cph_main_content_lbltoqty' + rowindex).text());

                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
                if (str == "") {

                    if (t <= _globalqty) {
                        if (t == _globalqty) {

                            //if (POETAdate.toString() != $('#ctl00_cph_main_content_txtetabreakedate' + parseInt(parseInt(rowindex)).toString()).val()) {
                            $('#ctl00_cph_main_content_lbletabreakedate' + parseInt(parseInt(rowindex)).toString()).text($('#ctl00_cph_main_content_txtetabreakedate' + parseInt(parseInt(rowindex)).toString()).val());
                            // }
                        }
                        else {
                            $('#trbreaek' + parseInt(parseInt(rowindex) + 1).toString()).show();
                            $('#ctl00_cph_main_content_txtfromqty' + (parseInt(rowindex) + 1).toString()).val(t + 1);
                            $('#ctl00_cph_main_content_lblfromqty' + +parseInt(parseInt(rowindex) + 1).toString()).text(t + 1);

                            if (t != $('#ctl00_cph_main_content_lbltoqty' + parseInt(parseInt(rowindex)).toString()).text().replace(",", "")) {
                                $('#ctl00_cph_main_content_lbletabreakedate' + parseInt(parseInt(rowindex)).toString()).text($('#ctl00_cph_main_content_txtetabreakedate' + parseInt(parseInt(rowindex)).toString()).val());
                                $('#ctl00_cph_main_content_txttoqty' + parseInt(parseInt(rowindex) + 1).toString()).val(_globalqty);
                                $('#ctl00_cph_main_content_lbltoqty' + parseInt(parseInt(rowindex) + 1).toString()).text(_globalqty);

                                $('#ctl00_cph_main_content_txtetabreakedate' + parseInt(parseInt(rowindex) + 1).toString()).val(POETAdate);
                                $('#ctl00_cph_main_content_lbletabreakedate' + parseInt(parseInt(rowindex) + 1).toString()).text(POETAdate);
                            }
                            if (POETAdate != $('#ctl00_cph_main_content_txtetabreakedate' + parseInt(parseInt(rowindex)).toString()).val()) {
                                $('#ctl00_cph_main_content_lbletabreakedate' + parseInt(parseInt(rowindex)).toString()).text($('#ctl00_cph_main_content_txtetabreakedate' + parseInt(parseInt(rowindex)).toString()).val());
                            }
                        }
                    }

                    for (var i = rowindex; i < rowLength; i += 1) {
                        var row = table.rows[i + 2];
                        if (row != undefined) {
                            if (t != $('#ctl00_cph_main_content_lbltoqty' + rowindex).text().replace(",", "")) {
                                $('#trbreaek' + parseInt(parseInt(i) + 2).toString()).hide();

                                if (row.cells[0].innerText.trim() != "" && row.cells[2].innerText.trim() != "") {


                                    $('#ctl00_cph_main_content_txtfromqty' + parseInt(i + 2).toString()).val("");
                                    $('#ctl00_cph_main_content_txttoqty' + parseInt(i + 2).toString()).val("");
                                    $('#ctl00_cph_main_content_txtetabreakedate' + parseInt(i + 2).toString()).val("");

                                    $('#ctl00_cph_main_content_lblfromqty' + +parseInt(i + 2).toString()).text("");
                                    $('#ctl00_cph_main_content_lbltoqty' + parseInt(i + 2).toString()).text("");
                                    $('#ctl00_cph_main_content_lbletabreakedate' + parseInt(i + 2).toString()).text();
                                }

                            }
                        }

                    }
                    $('#ctl00_cph_main_content_lblfromqty' + parseInt(rowindex).toString()).text(f);
                    $('#ctl00_cph_main_content_lbltoqty' + parseInt(rowindex).toString()).text(t);
                    for (var i = 0; i < rowLength; i += 1) {
                        var row = table.rows[i];

                        $('#ctl00_cph_main_content_txtfromqty' + parseInt(i).toString()).hide();
                        $('#ctl00_cph_main_content_txttoqty' + parseInt(i).toString()).hide();

                        $('#ctl00_cph_main_content_lblfromqty' + parseInt(i).toString()).show();
                        $('#ctl00_cph_main_content_lbltoqty' + parseInt(i).toString()).show();

                        $('#ctl00_cph_main_content_txtfromqty' + parseInt(i).toString()).val($('#ctl00_cph_main_content_lblfromqty' + +parseInt(i).toString()).text());
                        $('#ctl00_cph_main_content_txttoqty' + parseInt(i).toString()).val($('#ctl00_cph_main_content_lbltoqty' + +parseInt(i).toString()).text());

                        $('#ctl00_cph_main_content_txtetabreakedate' + parseInt(i).toString()).hide();
                        $('#ctl00_cph_main_content_lbletabreakedate' + parseInt(i).toString()).show();

                        $('#editcancel' + parseInt(i).toString()).hide();
                        $('#editupdate' + parseInt(i).toString()).hide();
                        $('#editdelete' + parseInt(i).toString()).show();
                        $('#edit' + parseInt(i).toString()).show();


                    }

                }
            }
            var table = document.getElementById('tblbreakedown');
            var rowLength = table.rows.length;

            for (var i = 0; i < rowLength; i += 1) {
                var row = table.rows[i];
                $('#ctl00_cph_main_content_lblfromqty' + parseInt(i).toString()).text(numberWithCommas($('#ctl00_cph_main_content_lblfromqty' + parseInt(i).toString()).text()));
                $('#ctl00_cph_main_content_lbltoqty' + parseInt(i).toString()).text(numberWithCommas($('#ctl00_cph_main_content_lbltoqty' + parseInt(i).toString()).text()));

            }
        }
        function checkqtys(elem, index) {

            //loopfromqty = $("#ctl00_cph_main_content_lblfromqty" + $(this).attr('id').substring(8, 9)).text();
            var Idsn = elem.id.split("_");
            var i = Idsn[4].substring(8, 9);
            var _globalqty = $("#ctl00_cph_main_content_grdfabricpurchased_ctl04_txtreceivedqty").val();
            var enterdval = $('#ctl00_cph_main_content_txttoqty' + parseInt(i).toString()).val();
            var fromq = $('#ctl00_cph_main_content_lblfromqty' + parseInt(i).toString()).text();
            var tomqty = $('#ctl00_cph_main_content_lbltoqty' + parseInt(i).toString()).text();


            //elem.value = elem.defaultValue;
            if (enterdval == "") {
                enterdval = 0;
            }
            if (parseInt(enterdval) <= 0) {
                alert("value cannot be zero");
                elem.value = tomqty;
                return;
            }
            if (parseInt(enterdval) < parseInt(fromq)) {
                alert("value cannot less then from qty");
                elem.value = tomqty;
                return;
            }
            if (parseInt(enterdval) != parseInt(elem.defaultValue)) {
                $("#ctl00_cph_main_content_txtetabreakedate" + index).val("");
                return;

            }
            //            else {
            //                elem.value = elem.defaultValue;
            //            }

        }
        function format() {
            var args = arguments;
            if (args.length <= 1) {
                return args;
            }
            var result = args[0];
            for (var i = 1; i < args.length; i++) {
                result = result.replace(new RegExp("\\{" + (i - 1) + "\\}", "g"), args[i]);
            }
            return result;
        }
        function CreateHistory() {

            var result = "";
            var Potype = '<%=this.Potype %>';
            var TodayDate = '<%=this.TodayDate %>';
            var UserName = '<%=this.UserName %>';
            var Fabtypes = '<%=this.Fabtype %>';
            var PoNumber = '<%=this.PoNumber %>';
            var MasterPoID = '<%=this.MasterPoID %>';
            var FabricQualityID = '<%=this.FabricQualityID %>';
            var currentstagenumber = '<%=this.currentstage %>';
            var previousstagenumber = '<%=this.previousstage %>';
            var resullt = "";
            var validateRemaningQty = '<%=this.RemaningQty %>';
            var isStyleSpecific = '<%=this.isStyleSpecific %>';
            var styleid = '<%=this.styleid %>';
            colorprintdetail = $("#ctl00_cph_main_content_grdfabricpurchased_ctl04_lblcolorprint").text();

            FabType = '<%=this.Fabtype %>';
            $("[id$=hdnconversionvalue]").val();
            var defualtorderUnit = $("[id$=_hdndefualtorderunit]").val();
            var ddlSelectdunit = $("#ctl00_cph_main_content_grdfabricpurchased_ctl04_ddlunits").val();
            var Enterdconversionvalue = $("#ctl00_cph_main_content_txttounit").val();
            var select = document.getElementById('ctl00_cph_main_content_grdfabricpurchased_ctl04_ddlunits');

            var QtySend = $("#<%= grdfabricpurchased.ClientID %>_" + "ctl04" + "_txtsendQty").val().replace(',', '');
            var OldSendQty = $("#<%= grdfabricpurchased.ClientID %>_" + "ctl04" + "_hdnsendqty").val().replace(',', '');
            oldreceivedqty = $("#<%= grdfabricpurchased.ClientID %>_" + "ctl04" + "_hdnreceivedqty").val().replace(',', '');
            NewReceiveQty = $("#ctl00_cph_main_content_grdfabricpurchased_ctl04_txtreceivedqty").val().replace(',', '');
            var ActualSendQty = $("#<%= grdfabricpurchased.ClientID %>_" + "ctl04" + "_hdnSendQtyValidate").val().replace(',', '');
            var availablesendqty = $("#<%= grdfabricpurchased.ClientID %>_" + "ctl04" + "_hdnavailablesendqty").val().replace(',', '');
            var receiveqty = $('#ctl00_cph_main_content_grdfabricpurchased_ctl04_txtreceivedqty').val().replace(',', '');
            var HdnConvertTounit = $('#ctl00_cph_main_content_grdfabricpurchased_ctl04_hdnConvertTounit').val();
            var hdnsaveconversionvalue = $('#ctl00_cph_main_content_grdfabricpurchased_ctl04_hdnsaveconversionvalue').val();
            var oldSupplierQuotedRate = $('#ctl00_cph_main_content_grdfabricpurchased_ctl04_hdnrateSupplierQuotedRate').val();

            var newSupplierQuotedRate = $('#ctl00_cph_main_content_grdfabricpurchased_ctl04_txtrateSupplierQuotedRate').val();
            oldSupplierQuotedRate == "" ? 0 : oldSupplierQuotedRate;
            newSupplierQuotedRate == "" ? 0 : newSupplierQuotedRate;
            var cosval = $("[id$=hdnconversionvalue]").val();
            var oldetadate = $('#ctl00_cph_main_content_hdnstoreetadate').val();
            var newetadate = $("#ctl00_cph_main_content_txtETADate").val();
            var selectedunit = $(select).val().toString();
            var OldRemarks = $("#<%= hdnOldremak.ClientID %>").val().trim();
            var NewRemarks_commentClientID = $("#<%= comment.ClientID %>").val().trim();

            cosval = cosval == "" ? 0 : cosval;

            var retrunval = 0;
            if (QtySend == '') {
                QtySend = 0;
            }
            if (OldSendQty == '') {
                OldSendQty = 0;
            }
            if (oldreceivedqty == '') {
                oldreceivedqty = 0;
            }
            if (NewReceiveQty == '') {
                NewReceiveQty = 0;
            }
            if (availablesendqty == '') {
                availablesendqty = 0;
            }

            if (Enterdconversionvalue == '') {
                Enterdconversionvalue = 0;
            }
            if (hdnsaveconversionvalue == '') {
                hdnsaveconversionvalue = 0;
            }
            if (hdnsaveconversionvalue == '') {
                hdnsaveconversionvalue = 0;
            }
            var _Sendvals = 0;
            var _Receivevals = 0;

            OldSendQty = Math.round((parseFloat(OldSendQty) * parseFloat(hdnsaveconversionvalue)));
            oldreceivedqty = Math.round((parseFloat(oldreceivedqty) * parseFloat(hdnsaveconversionvalue)));

            var sb = "";
            var isChanges = 0;
            if (Potype == 'RERAISE') {
                if (QtySend != OldSendQty) {
                    isChanges = 1;
                    sb = sb + "###" + "<li'> " + " <span class='LiCircel'></span>" + " " + "<b>" + TodayDate + "</b>" + ": " + "<b>Send quantity </b>" + format("{0} was {1} " + " " + "Changed " + "by" + " " + "<b>" + UserName + "</b>", "<b>" + QtySend + " " + GetUnitname($(select).val().toString()) + " " + "</b>", "<b>" + OldSendQty + " " + GetUnitname(HdnConvertTounit.toString()) + "</b>") + "</li>";
                }
                if (NewReceiveQty != oldreceivedqty) {
                    isChanges = 1;
                    sb = sb + "###" + "<li'> " + " <span class='LiCircel'></span>" + " " + "<b>" + TodayDate + "</b>" + ": " + "<b>Received quantity </b>" + format("{0} was {1} " + " " + "Changed " + "by" + " " + "<b>" + UserName + "</b>", "<b>" + NewReceiveQty + " " + GetUnitname($(select).val().toString()) + " " + "</b>", "<b>" + oldreceivedqty + " " + GetUnitname(HdnConvertTounit.toString()) + "</b>") + "</li>";
                }
                if ($(select).val().toString() != HdnConvertTounit.toString()) {
                    isChanges = 1;
                    sb = sb + "###" + "<li> " + " <span class='LiCircel'></span>" + " " + "<b>" + TodayDate + "</b>" + ": " + "<b>Quantity unit </b>" + format("{0} was {1} " + " " + "Changed " + "by" + " " + "<b>" + UserName + "</b>", "<b>" + GetUnitname($(select).val().toString()) + " " + "</b>", "<b>" + GetUnitname(HdnConvertTounit.toString()) + "</b>") + "</li>";
                }
                if (hdnsaveconversionvalue != cosval) {
                    isChanges = 1;
                    sb = sb + "###" + "<li> " + "<span class='LiCircel'></span> " + " " + "<b>" + TodayDate + "</b>" + "<b>" + ": " + "<b>Conversion value </b>" + format("{0} was {1} " + " " + "Changed " + "by" + " " + "<b>" + UserName + "</b>", "<b>" + cosval + " " + "</b>", "<b>" + hdnsaveconversionvalue + "</b>") + "</li>";

                }
                if (oldSupplierQuotedRate != newSupplierQuotedRate) {
                    isChanges = 1;
                    sb = sb + "###" + "<li> " + "<span class='LiCircel'></span> " + " " + "<b>" + TodayDate + "</b>" + "<b>" + ": " + "<b>Supplier rate </b>" + format("{0} was {1} " + " " + "Changed " + "by" + " " + "<b>" + UserName + "</b>", "<b>" + newSupplierQuotedRate + " " + "</b>", "<b>" + oldSupplierQuotedRate + "</b>") + "</li>";

                }
                if (oldetadate != newetadate) {
                    isChanges = 1;
                    sb = sb + "###" + "<li> " + "<span class='LiCircel'></span> " + " " + "<b>" + TodayDate + "</b>" + "<b>" + ": " + "<b>ETA date </b>" + format("{0} was {1} " + " " + "Changed " + "by" + " " + "<b>" + UserName + "</b>", "<b>" + newetadate + " " + "</b>", "<b>" + oldetadate + "</b>") + "</li>";

                }

                if (OldRemarks.trim() != NewRemarks_commentClientID.trim()) {

                    isChanges = 1;
                    sb = sb + "###" + "<li> " + "<span class='LiCircel'></span> " + " " + "<b>" + TodayDate + "</b>" + "<b>" + ": " + "<b>PO Remark </b>" + NewRemarks_commentClientID + " was " + OldRemarks + " Changed " + "by" + " " + "<b>" + UserName + "</b>", "<b>" + NewRemarks_commentClientID + " " + "</b>", "<b>" + OldRemarks + "</b>" + "</li>";
                }
            }
            if (isChanges == 1) {

                sb = "<ul class='HistoryUl'>" + sb + "</ul>"
            }


            var result = sb.toString();
            sb = "";
            return result;
        }
        function GetUnitname(unitid) {


            if (unitid == "1") {
                return "Mtr"
            }
            if (unitid == "3") {
                return "Kg"
            }
            if (unitid == "4") {
                return "yard"
            }
            if (unitid == "5") {
                return "pcs"
            }
            if (unitid == "7") {
                return "box"
            }
        }
        function showhistory(flag) {

            $("#ctl00_cph_main_content_divhistory").css("display", flag);
        }
        function getPageHTML() {


            //$("ctl00_cph_main_content_btnSubmit").click();
            return true;
        }
        function MailCheck() {

            Supplier = '<%=this.ParentPageUrlWithQuerystring %>';

            //  if ($("#ctl00_cph_main_content_chkAuthorizedSignatory").is(':checked') && $("#ctl00_cph_main_content_chkpartysignature").is(':checked')) {
            // Above is comented by sanjeev on 28/01/2021 to give option of mail only on Authorized Signatory Check
            if ($("#ctl00_cph_main_content_chkAuthorizedSignatory").is(':checked')) {
                //$("#ctl00_cph_main_content_btnSubmit").show();
                if (Supplier != "SuPPLIERVIEW") {

                    $("#divmail").show();
                }

            }
            else {
                $("#rdoNo").attr('checked', 'checked');
                $("#divmail").hide();
            }
        }


        function SetCalenderMinAndMaxDateOnRevisePO() {
            //    debugger;

            FabType = '<%=this.Fabtype %>';
            var FabricQualityID = '<%=this.FabricQualityID %>';
            var SupplierMasterID = $("#" + ddlSupplierName).val();
            var colorprintdetail = $("#ctl00_cph_main_content_grdfabricpurchased_ctl04_lblcolorprint").text().replace(',', '');
            var styleid = '<%=this.styleid %>';

            proxy.invoke("GetSupplierRate",
                            { flag: FabType.toString(), flagOtion: 'GETSUPPLIERRATE', FabricQualityID: FabricQualityID, SupplierMasterID: SupplierMasterID, faricdetails: colorprintdetail, Styleid: styleid
                            },
                          function (result) {
                             // debugger;
                              var SupplierLeadDays = result[1];
                              var SupplierLeadRange = result[2];                             
                                  var d1 = new Date($('#ctl00_cph_main_content_txtPoDate').val());
                                  var d2 = new Date($("#ctl00_cph_main_content_txtETADate").val());
                                  $("#ctl00_cph_main_content_txtETADate").datepicker("option", "minDate", new Date(d1.setDate(d1.getDate() )));                                 
                                  var maxxdate = new Date(d2.setDate(d2.getDate())); // //04052023                                 
                                  if (new Date($("#ctl00_cph_main_content_txtETADate").val()) > maxxdate) {
                                      $("#ctl00_cph_main_content_txtETADate").datepicker("option", "maxDate", new Date($("#ctl00_cph_main_content_txtETADate").val()));
                                  } else {
                                      $("#ctl00_cph_main_content_txtETADate").datepicker("option", "maxDate", maxxdate);
                                  }
                                  $('#ui-datepicker-div').css("display", "none");
                             
//                              if (SupplierLeadDays != null && SupplierLeadDays != '') {                                 
//                                  var d1 = new Date($('#ctl00_cph_main_content_txtPoDate').val());
//                                  var d2 = new Date();
//                                  $("#ctl00_cph_main_content_txtETADate").datepicker("option", "minDate", new Date(d1.setDate(d1.getDate() + parseInt(SupplierLeadDays))));
//                                  var maxxdate = new Date(d1.setDate(d1.getDate() + parseInt(SupplierLeadRange)));                                                                
//                                  if (new Date($("#ctl00_cph_main_content_txtETADate").val()) > maxxdate) {
//                                      $("#ctl00_cph_main_content_txtETADate").datepicker("option", "maxDate", new Date($("#ctl00_cph_main_content_txtETADate").val()));
//                                  } else {
//                                      $("#ctl00_cph_main_content_txtETADate").datepicker("option", "maxDate", maxxdate);
//                                  }
//                                  $('#ui-datepicker-div').css("display", "none");
//                              }
                          }, onPageError, false, false);
        }

        function SetCalenderMinAndMaxDateOnRaisePO() {
            //   debugger;

            FabType = '<%=this.Fabtype %>';
            var FabricQualityID = '<%=this.FabricQualityID %>';
            var SupplierMasterID = $("#" + ddlSupplierName).val();
            var colorprintdetail = $("#ctl00_cph_main_content_grdfabricpurchased_ctl04_lblcolorprint").text().replace(',', '');
            var styleid = '<%=this.styleid %>';

            proxy.invoke("GetSupplierRate",
								{ flag: FabType.toString(), flagOtion: 'GETSUPPLIERRATE', FabricQualityID: FabricQualityID, SupplierMasterID: SupplierMasterID, faricdetails: colorprintdetail, Styleid: styleid
								},
							  function (result) {
							      //debugger;
							      var SupplierLeadDays = result[1];
							      var SupplierLeadRange = result[2];
							      if (SupplierLeadDays != null && SupplierLeadDays != '') {
							          var d1 = new Date($('#ctl00_cph_main_content_txtPoDate').val());							        
							          $("#ctl00_cph_main_content_txtETADate").datepicker("option", "minDate", new Date(d1.setDate(d1.getDate())));
							          $("#ctl00_cph_main_content_txtETADate").datepicker("option", "maxDate", new Date(d1.setDate(d1.getDate() + parseInt(SupplierLeadDays))));							       						          						          						         						         
							          $("#ctl00_cph_main_content_txtETADate").datepicker("setDate", new Date(d1.setDate(d1.getDate() + parseInt(SupplierLeadDays))));
                                      $('#ui-datepicker-div').css("display", "none");
							      }

							  }, onPageError, false, false);

        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_main_content" runat="server">
    <asp:ScriptManager ID="script1" EnablePageMethods="true" runat="server">
    </asp:ScriptManager>
    <asp:UpdateProgress runat="server" ID="uproTargetAdmin" AssociatedUpdatePanelID="UpdatePanel1"
        DisplayAfter="0">
        <ProgressTemplate>
            <div id="spinner" class="fade-in">
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:HiddenField ID="hdncurrentstage" runat="server" />
            <asp:HiddenField ID="hdnSupplyType" runat="server" />
            <asp:HiddenField ID="hdintialsuppliercode" runat="server" />
            <asp:HiddenField ID="hdnstorepodate" runat="server" />
            <asp:HiddenField ID="hdnstoresupplierid" runat="server" />
            <asp:HiddenField ID="hdnstoreetadate" runat="server" />
            <asp:HiddenField ID="hdnstoresendqty" runat="server" />
            <asp:HiddenField ID="hdnstorereceivedqty" runat="server" />
            <asp:HiddenField ID="hdnstoreunitsid" runat="server" />
            <asp:HiddenField ID="hdnstorerate" runat="server" />
            <asp:HiddenField ID="hdnstoretotalamount" runat="server" />
            <asp:HiddenField ID="hdntxtdates" runat="server" />
            <asp:HiddenField ID="hdntoqty" runat="server" />
            <asp:HiddenField ID="hdnconversionvalue" runat="server" />
            <asp:HiddenField ID="hdnminsrv" runat="server" />
            <asp:HiddenField ID="hdnetastring" runat="server" />
            <asp:HiddenField ID="hdncutwastage" runat="server" />
            <asp:HiddenField ID="hdnFabricQuality" runat="server" Value="" />
            <asp:HiddenField ID="hdnOldremak" runat="server" Value="" />
            <asp:HiddenField ID="hdnhistory" runat="server" Value="" />
            <asp:HiddenField ID="isQuoted" runat="server" Value="" />
            <asp:HiddenField ID="HiddenField1" runat="server" Value="" />
            <asp:HiddenField ID="HiddenField2" runat="server" Value="" />
            <asp:HiddenField ID="HiddenField3" runat="server" Value="" />
            <asp:Label ID="lblgerigeshrinkage" runat="server" Style="display: none;"></asp:Label>
            <asp:Label ID="lblresidualshrinkage" runat="server" Style="display: none;"></asp:Label>
            <table class="purchase_order" style="margin-top: 5px; border-right-color: #999; border-left-color: #999;
                border-bottom: 0px;">
                <thead>
                    <tr style="display: none;">
                        <th colspan="8" style="color: #fff; padding: 1px 0px; background: #39589c; font-weight: normal !important;
                            font-size: 15px; border-color: #999">
                            <span style="float: left; font-size: 12px; padding-left: 5px;">All <span style="color: Red;
                                font-size: 12px;">*</span> (asterisk) mark field mandatory</span> <span style="padding-right: 20%;">
                                    Purchase Order</span>
                            <%--   <a onclick="showhistory('block')" id="lnkhistoryshow" style="color: Blue;float:right;margin-right:5px;cursor: pointer;" target="_blank">
                               <img src="../../images/history.png" /></a>--%>
                        </th>
                    </tr>
                    <tr>
                        <th style="display: flex; text-align: left; align-items: center; border: 0; border-right: 1px solid lightgray;
                            padding-right: 17px; box-sizing: border-box; width: fit-content;" class="barder_top_color">
                            <div style="padding: 0px 7px 5px">
                                <img src="../../images/boutique-logo.png">
                            </div>
                            <div id="divbipladdress" runat="server" style="padding-left: 10px;">
                            </div>
                        </th>
                        <th style="border-left: 0px; text-align: left; border-right-color: #999; font-size: 24px;
                            position: relative; font-weight: 400 !important; border-bottom: 0px">
                            <span id="Order_text" runat="server" style="margin-right: 185px;"></span><a onclick="showhistory('block')"
                                id="lnkhistoryshow" class="printHideButton" style="color: Blue; position: absolute;
                                right: 10px; cursor: pointer;" target="_blank">
                                <img src="../../images/history1.png" /></a>
                        </th>
                    </tr>
                </thead>
            </table>
            <table class="purchase_order" style="margin-top: 0px; border-right-color: #999; border-left-color: #999;
                border-bottom: 0px;">
                <tbody>
                    <tr style="border-bottom: 1px solid #999; border-right: 1px solid #999;">
                        <td style="padding-left: 7px; border-left-color: #999; width: 40px; padding-right: 0px;">
                            PO No:
                        </td>
                        <td>
                            <asp:Label ID="lblPoNo" Style="font-weight: bold; font-size: 13px;" runat="server"></asp:Label>
                        </td>
                        <td style="text-align: right; width: 50px;">
                            PO Date
                        </td>
                        <td style="width: 100px;">
                            <asp:TextBox ID="txtPoDate" ReadOnly="true" Style="width: 90px; color: Black; font-weight: bold;"
                                CssClass="datesfileds" onchange="Resetetagrd()" runat="server"></asp:TextBox>
                        </td>
                        <td style="text-align: right;">
                            Supplier<span style="color: red; font-size: 12px;">*</span>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlSupplierName" Width="350px" Style="margin: 2px 0px; height: 18px;"
                                CssClass="spchange storedata" onchange="javascript:GetSupplierChange(); Resetetagrd()"
                                AppendDataBoundItems="true" runat="server">
                                <asp:ListItem Text="Select" Value="-1" />
                            </asp:DropDownList>
                        </td>
                        <td style="text-align: right; width: 50px;">
                            ETA Date<span style="color: red; font-size: 12px;">*</span>
                        </td>
                        <td style="border-right-color: #999; width: 120px">
                            <asp:TextBox ID="txtETADate" Style="width: 94%; color: Black; font-weight: bold;"
                                onkeypress="return false;" CssClass="th2 datesfileds storedata" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th colspan="10" style="border-bottom: none;">
                            <span style="font-size: 12px; margin-top: -7px; color: Gray;">Client Code:</span>
                            <span style="font-weight: bold">
                                <asp:Label ID="lblClientcode" runat="server"></asp:Label></span>
                        </th>
                    </tr>
                    <%--RajeevS --%>
                    <tr>
                        <th colspan="10" style="border-bottom: none;">
                            <span style="padding-bottom: 12px; color: gray" runat="server" id="spn_HSNCode">
                            </span>
                            <asp:Label ID="lblHSNCode" runat="server"></asp:Label>
                        </th>
                    </tr>
                    <%--RajeevS --%>
                </tbody>
            </table>
            <asp:GridView ID="grdfabricpurchased" ShowHeader="false" runat="server" AutoGenerateColumns="False"
                EmptyDataText="No Record Found!" Width="1100px" HeaderStyle-Font-Names="Arial"
                HeaderStyle-HorizontalAlign="Center" BorderWidth="1" rules="all" OnRowDataBound="grdfabricpurchased_RowDataBound"
                HeaderStyle-CssClass="ths" CssClass="lastrow">
                <SelectedRowStyle BackColor="#A1DCF2" />
                <Columns>
                    <asp:TemplateField HeaderText="Fabric Quality">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemTemplate>
                            <asp:HiddenField ID="hdnremainingQty" runat="server" Value='<%# Eval("PendingQtyToOrder")%>' />
                            <asp:HiddenField ID="hdnfabricQuality" runat="server" Value='<%# Eval("Fabric_QualityID")%>' />
                            <asp:HiddenField ID="hdnSupplierMasterID" runat="server" Value='<%# Eval("supplier_master_Id")%>' />
                            <asp:Label ID="lblFabricQuality" ForeColor="Blue" Font-Bold="true" Text='<%# Eval("TradeName")%>'
                                runat="server"></asp:Label>
                            <%-- <asp:Label ID="lblgsm" ForeColor="Gray" Text='<%# Eval("GSM")%>' runat="server" CssClass=" color_black boldness"></asp:Label>--%>
                            <%-- <asp:Label ID="lblcountconstraction" ForeColor="Gray" Text='<%# Eval("CountConstruction").ToString()%>' runat="server"></asp:Label>--%>
                            <%-- <asp:Label ID="lblwidth" ForeColor="Gray" CssClass=" color_black boldness" Text='<%# Eval("width").ToString()+"&quot in" %>' runat="server"></asp:Label>--%><br />
                            <%--  <asp:Label ID="lblcolorprint" Font-Bold="true" Text='<%# Eval("FabricDetails")%>' runat="server"></asp:Label>--%>
                        </ItemTemplate>
                        <ItemStyle CssClass="border_left_color" Width="160px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="C&C">
                        <ItemTemplate>
                            <asp:Label ID="lblcountconstraction" ForeColor="black" Text='<%# Eval("CountConstruction").ToString()%>'
                                runat="server"></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="70px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="GSM">
                        <ItemTemplate>
                            <asp:Label ID="lblgsm" ForeColor="Gray" Text='<%# Eval("GSM")%>' runat="server" CssClass=" color_black"></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="70px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Width">
                        <ItemTemplate>
                            <asp:Label ID="lblwidth" ForeColor="Gray" CssClass=" color_black boldness" Text='<%# Eval("width").ToString()+"&quot in" %>'
                                runat="server"></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="70px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="ColorPrint">
                        <ItemTemplate>
                            <asp:Label ID="lblcolorprint" Font-Bold="true" Text='<%# Eval("FabricDetails")%>'
                                runat="server"></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="70px" />
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Label ID="lblGreige" Text='<%# (Eval("Greige_Sh") == DBNull.Value  || (Eval("Greige_Sh").ToString().Trim() == string.Empty)) ? string.Empty : Eval("Greige_Sh").ToString().Trim() %>'
                                runat="server"></asp:Label>
                        </ItemTemplate>
                        <ItemStyle CssClass="tdpadding0" Width="50px" />
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:DropDownList ID="ddlsupplytype" DataTextField="Name" CssClass="storedata" AppendDataBoundItems="true"
                                DataValueField="SupplierType_Id" DataSourceID="SqlDataSource1" runat="server">
                                <asp:ListItem Text="Select" Value="-1" />
                            </asp:DropDownList>
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ connectionStrings:LocalMySqlServer %>"
                                SelectCommand="select SupplierType_Id,	case when Name='Griege' then 'Greige' else Name end Name ,Type from tblSupplierType where type in (1,4) and SupplierType_Id in (1,2,3,10,27,28,29,30,31)">
                            </asp:SqlDataSource>
                        </ItemTemplate>
                        <ItemStyle Width="100px" />
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:HiddenField ID="hdnResidualshrnk" runat="server" Value='<%# (Eval("Greige_Sh") == DBNull.Value  || (Eval("Greige_Sh").ToString().Trim() == string.Empty)) ? string.Empty : Eval("Greige_Sh").ToString().Trim() %>' />
                            <asp:HiddenField ID="hdnSendQtyValidate" runat="server" />
                            <asp:HiddenField ID="hdngerigeshrnk" runat="server" />
                            <asp:HiddenField runat="server" ID="hdnsendqty" />
                            <a runat="server" id="ansendtooltip" class="tooltips">
                                <asp:TextBox ID="txtsendQty" ReadOnly="true" onchange="return CheckSendQty(this);"
                                    MaxLength="8" onkeypress="return isNumberKey(event)" Style="width: 50px !important;
                                    color: #000; text-align: center; font-weight: bold;" runat="server" CssClass="storedata"></asp:TextBox>
                                <span id="spanmsgsendqty" runat="server"></span>
                                <asp:HiddenField ID="hdnavailablesendqty" runat="server" Value='<%# (Eval("PendingQtyToOrder") != null) ? Eval("PendingQtyToOrder").ToString() : ((Eval("PendingQtyToOrder") != null) ? Eval("PendingQtyToOrder") : "")%>' />
                            </a>
                        </ItemTemplate>
                        <ItemStyle Width="80px" />
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:HiddenField runat="server" ID="hdnreceivedqty" Value='<%# (Eval("QtyToOrder") == DBNull.Value  || (Eval("QtyToOrder").ToString().Trim() == string.Empty)) ? string.Empty : Convert.ToDecimal(Eval("QtyToOrder")).ToString("N0") %>' />
                            <a runat="server" id="anreceivetooltip" class="tooltips">
                                <asp:TextBox ID="txtreceivedqty" class="classfabsave storedata" onkeypress="return isNumberKey(event)"
                                    onchange="javascript:ValidateMinReceiveQty(this); GetSupplierRateChange();  Resetetagrd();"
                                    Style="width: 50px !important; text-align: center; color: #000; font-weight: bold;"
                                    runat="server" Text='<%# (Eval("QtyToOrder") == DBNull.Value  || (Eval("QtyToOrder").ToString().Trim() == string.Empty)) ? string.Empty : Convert.ToDecimal(Eval("QtyToOrder")).ToString("N0") %>'></asp:TextBox>
                                <span id="spanmsgsendqtys" runat="server"></span></a>
                        </ItemTemplate>
                        <ItemStyle Width="70px" />
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <%--<asp:DropDownList ID="ddlunits" SelectedValue='<%# Eval("GarmentUnit") %>' DataTextField="UnitName"
                        AppendDataBoundItems="true" DataValueField="GroupUnitID" DataSourceID="SqlDataSource2"
                        runat="server">
                        <asp:ListItem Text="All" Value="-1" />
                    </asp:DropDownList>--%>
                            <%--  <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ connectionStrings:LocalMySqlServer %>"
                        SelectCommand="select GroupUnitID,UnitName from tblGroupUnit where ACTIVE=1 and GroupUnitID in (1,4)">
                    </asp:SqlDataSource>--%>
                            <asp:DropDownList ID="ddlunits" onchange="javascript:ConversionValueChange('UNITCHANGE');"
                                CssClass="storedata" SelectedValue='<%# Eval("ConvertTounit") %>' runat="server">
                                <%--  <asp:ListItem Text="All" Value="-1" />--%>
                                <asp:ListItem id="rMeter" Text="Mtr" Value="1" />
                                <asp:ListItem id="ryard" Text="yd" Value="4" />
                                <asp:ListItem id="rkg" Text="kg" Value="3" />
                            </asp:DropDownList>
                            <asp:HiddenField runat="server" ID="hdndefualtorderunit" Value='<%# (Eval("GarmentUnit") == DBNull.Value  || (Eval("GarmentUnit").ToString().Trim() == string.Empty)) ? -1 : Eval("GarmentUnit") %>' />
                            <asp:HiddenField runat="server" ID="hdnConvertTounit" Value='<%# (Eval("ConvertTounit") == DBNull.Value  || (Eval("ConvertTounit").ToString().Trim() == string.Empty)) ? -1 : Eval("ConvertTounit") %>' />
                            <asp:HiddenField runat="server" ID="hdnsaveconversionvalue" Value='<%# (Eval("ConversionValue") == DBNull.Value  || (Eval("ConvertTounit").ToString().Trim() == string.Empty)) ? 1 : Eval("ConversionValue") %>' />
                        </ItemTemplate>
                        <ItemStyle Width="80px" />
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:HiddenField runat="server" ID="hdnrateSupplierQuotedRate" Value='<%# (Eval("SupplierQuotedRate") == DBNull.Value  || (Eval("SupplierQuotedRate").ToString().Trim() == string.Empty)) ? string.Empty : Eval("SupplierQuotedRate").ToString().Trim() %>' />
                            <span style='color: green; font-size: 16px;'>₹</span>
                            <asp:TextBox ID="txtrateSupplierQuotedRate" onchange="javascript:GetSupplierRateChange();"
                                onkeypress="return validateFloatKeyPress(this,event);" CssClass="storedata" Style="width: 49px !important;
                                text-align: center; color: green; font-size: 13px!important; font-weight: 600;"
                                runat="server" Text='<%# (Eval("SupplierQuotedRate") == DBNull.Value  || (Eval("SupplierQuotedRate").ToString().Trim() == string.Empty)) ? string.Empty : Eval("SupplierQuotedRate").ToString().Trim() %>'></asp:TextBox>
                        </ItemTemplate>
                        <ItemStyle Width="80px" />
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <span style="color: green; font-size: 13px; float: left; position: relative; top: 1px;
                                margin-right: 3px;">₹</span>
                            <asp:Label ID="lbltotalAmount" runat="server" Font-Size="12px"></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="100px" CssClass="border_right_color" />
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <div style="border: 1px solid #999; border: 1px solid #999; width: 1098px; margin: 10px 0;
                padding: 1px 0px;">
                <table style="width: 99%">
                    <tr>
                        <th class="hisclass" style="width: 200px; text-align: center; color: #575759;">
                            <span class="hisclass">History of Revise Purchase Order</span>
                        </th>
                        <th style="text-align: right; padding-bottom: 10px; float: right; vertical-align: middle;
                            display: flex; justify-content: center; align-items: center; color: gray;">
                            <%--   <input type='radio' name='group' ng-model='mValue' value='first' />Landed 
                        <input type='radio' name='group' ng-model='mValue' value='second' /> Ex Mill--%>
                            <asp:RadioButtonList ID="rdybtnListRateType" runat="server" RepeatDirection="Horizontal"
                                CssClass="radoibg_color" Style="float: right; margin-right: 10px; color: dimgray;">
                                <asp:ListItem Text="Select" Value="0" Selected="True" style="display: none;"></asp:ListItem>
                                <asp:ListItem Text="Landed" Value="1"></asp:ListItem>
                                <asp:ListItem Text="Ex-Mill" Value="2"></asp:ListItem>
                            </asp:RadioButtonList>
                        </th>
                    </tr>
                    <tr>
                        <td style="vertical-align: top; padding-left: 10px;">
                            <asp:GridView ID="grdReceiveQtyHistory" Style="width: 357px; float: right" CssClass="table receivehis lastrow"
                                runat="server" AutoGenerateColumns="false" OnRowDataBound="grdReceiveQtyHistory_RowDataBound">
                                <Columns>
                                    <asp:TemplateField HeaderText="Date" ItemStyle-Width="100px">
                                        <ItemTemplate>
                                            <asp:Label ID="lbldate" runat="server" Text='<%# Eval("PORevisedDates")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle CssClass="txtcenter border_left_color" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="PO Quantity" ItemStyle-Width="100px">
                                        <ItemTemplate>
                                            <asp:Label ID="lblsign" Style="font-size: 16px; font-weight: 900; position: relative;
                                                top: 1px;" runat="server" ForeColor='<%# System.Drawing.ColorTranslator.FromHtml((String)Eval("CheckQty")) %>'
                                                Text='<%# Eval("POQuantitybysign")%>'></asp:Label>
                                            <asp:Label ID="lblpoqty" runat="server" Font-Bold="true" Text='<%# Eval("POQuantity")%>'></asp:Label>&nbsp;
                                            <asp:Label ID="lnluntis" class="" ForeColor="Gray" Font-Bold="true" runat="server"
                                                Text='<%# Eval("unitsname")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle CssClass="txtcenter border_right_color" />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                            <asp:GridView ID="grdhistorysend" CssClass="table receivehis lastrow" runat="server"
                                AutoGenerateColumns="false" Width="300px" OnRowDataBound="grdhistorysend_RowDataBound">
                                <Columns>
                                    <asp:TemplateField HeaderText="Date" ItemStyle-Width="100px">
                                        <ItemTemplate>
                                            <asp:Label ID="lbldate" runat="server" Text='<%# Eval("PORevisedDates")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle CssClass="txtcenter border_left_color" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Send Quantity" ItemStyle-Width="100px">
                                        <ItemTemplate>
                                            <asp:Label ID="lblsign" Style="font-size: 16px; font-weight: 900; position: relative;
                                                top: 1px;" runat="server" ForeColor='<%# System.Drawing.ColorTranslator.FromHtml((String)Eval("SendCheckQty")) %>'
                                                Text='<%# Eval("SendQuantitybysign")%>'></asp:Label>
                                            <asp:Label ID="lblpoqty" runat="server" Font-Bold="true" Text='<%# (Eval("SendQty") == DBNull.Value  || (Eval("SendQty").ToString().Trim() == "0")) ? string.Empty : Eval("SendQty").ToString().Trim() %>'></asp:Label>&nbsp;
                                            <asp:Label ID="lnluntis" class="" ForeColor="Gray" Font-Bold="true" runat="server"
                                                Text='<%# Eval("unitsname")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle CssClass="txtcenter" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="PO Quantity" ItemStyle-Width="100px">
                                        <ItemTemplate>
                                            <asp:Label ID="lblsignr" Style="font-size: 16px; font-weight: 900; position: relative;
                                                top: 1px;" runat="server" ForeColor='<%# System.Drawing.ColorTranslator.FromHtml((String)Eval("CheckQty")) %>'
                                                Text='<%# Eval("POQuantitybysign")%>'></asp:Label>
                                            <asp:Label ID="lblpoqtyre" runat="server" Font-Bold="true" Text='<%# Eval("POQuantity")%>'></asp:Label>&nbsp;
                                            <asp:Label ID="lnluntisre" runat="server" ForeColor="Gray" Font-Bold="true" Text='<%# Eval("unitsname")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle CssClass="txtcenter border_right_color" />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </td>
                        <td style="vertical-align: top;">
                            <asp:GridView ID="grdqtyrange" runat="server" AutoGenerateColumns="False" EmptyDataText="No Record Found!"
                                HeaderStyle-Font-Names="Arial" HeaderStyle-HorizontalAlign="Center" ShowFooter="false"
                                OnRowUpdating="grdqtyrange_RowUpdating" OnRowCancelingEdit="grdqtyrange_RowCancelingEdit"
                                OnRowCommand="grdqtyrange_RowCommand" OnRowEditing="grdqtyrange_RowEditing" OnRowDataBound="grdqtyrange_RowDataBound"
                                OnRowDeleting="grdqtyrange_RowDeleting" CssClass="supplieretadatetable" Width="349px"
                                ShowHeader="true" Style="border-top: 0px; border-bottom: 1px bolid #999; display: none">
                                <Columns>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            From Qty.
                                            <%--<span style="color:gray">(Mtr.)</span>--%>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblfromqty" Text='<%# Eval("FromQty")%>' runat="server"></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txteditfromqty" Text='<%# Eval("FromQty")%>' runat="server" onkeypress="return isNumberKey(event)"
                                                ReadOnly="true" MaxLength="5" onchange="checkzero(this)"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfv_txtFromqty_Edit" runat="server" Display="None"
                                                ValidationGroup="gedit" ControlToValidate="txteditfromqty" ErrorMessage="Enter from qty"></asp:RequiredFieldValidator>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            To Qty.
                                            <%--<span style="color:gray">(Mtr.)</span>--%>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:HiddenField ID="hdnrownumber" runat="server" Value='<%# Eval("Row_Number")%>' />
                                            <asp:HiddenField ID="hdnsupplierpoid" runat="server" Value='<%# Eval("SupplierPO_Id")%>' />
                                            <asp:HiddenField ID="hdnSupplierPO_ETA_Id" runat="server" Value='<%# Eval("SupplierPO_ETA_Id")%>' />
                                            <asp:Label ID="lbltoqty" runat="server" Text='<%# Eval("ToQty")%>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:HiddenField ID="hdnrownumber" runat="server" Value='<%# Eval("Row_Number")%>' />
                                            <asp:HiddenField ID="hdnsupplierpoid" runat="server" Value='<%# Eval("SupplierPO_Id")%>' />
                                            <asp:HiddenField ID="hdnSupplierPO_ETA_Id" runat="server" Value='<%# Eval("SupplierPO_ETA_Id")%>' />
                                            <asp:TextBox ID="txtedittoqty" Text='<%# Eval("ToQty")%>' CssClass="storedata" runat="server"
                                                onkeypress="return isNumberKey(event)" MaxLength="5" onchange="CheckToQty(this)"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfv_txttoqty_Edit" runat="server" Display="None"
                                                ValidationGroup="gedit" ControlToValidate="txtedittoqty" ErrorMessage="Enter to qty."></asp:RequiredFieldValidator>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            ETA dates
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lbldates" Text='<%# Eval("POETADate")%>' runat="server"></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtdates" CssClass="th datesfileds storedata" Text='<%# Eval("POETADate")%>'
                                                runat="server" onkeypress="return isNumberKey(event)" MaxLength="5" onchange="CheckEtadates(this)"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfv_txtETA_Edit" runat="server" Display="None" ValidationGroup="gedit"
                                                ControlToValidate="txtdates" ErrorMessage="select dates"></asp:RequiredFieldValidator>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Action
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="LinkButton1" Text="../../images/edit2.png" alt="edit" CommandName="Edit"
                                                runat="server" OnClientClick="setbackviewstate()"><img src="../../images/edit2.png" alt="edit" /></asp:LinkButton>
                                            <asp:LinkButton ID="lnkDelete" runat="server" CommandName="Delete" ForeColor="black"
                                                ToolTip="Delete" Width="20px"> <img src="../../images/del-butt.png" /> </asp:LinkButton>
                                        </ItemTemplate>
                                        <ItemStyle CssClass="Actiont_63 border_right_color" />
                                        <EditItemTemplate>
                                            <asp:LinkButton ID="btnupdate" runat="server" ValidationGroup="gedit" CommandName="Update"
                                                Text="Update"><img src="../../App_Themes/ikandi/images/green_tick.gif" /></asp:LinkButton>
                                            <asp:LinkButton ID="btncancel" runat="server" CommandName="Cancel" Text="Cancel"><img src="../../images/Cancel1.jpg" style="position: relative;top:2px;width:17px" /></asp:LinkButton>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                            <asp:GridView ID="gvqtyrange" Style="display: none" CssClass="table lastrow" runat="server"
                                DataFormatString="{0:c}" OnRowDataBound="gvqtyrange_RowDataBound" AutoGenerateColumns="false">
                                <Columns>
                                    <asp:TemplateField HeaderText="From" ItemStyle-Width="100px">
                                        <ItemTemplate>
                                            <%# Eval("FromQty")%>
                                        </ItemTemplate>
                                        <ItemStyle CssClass="txtcenter border_left_color" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="To" ItemStyle-Width="100px">
                                        <ItemTemplate>
                                            <%# Eval("ToQty")%>
                                        </ItemTemplate>
                                        <ItemStyle CssClass="txtcenter" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="ETA Date" ItemStyle-Width="100px">
                                        <ItemTemplate>
                                            <%# Eval("POETADate")%>
                                        </ItemTemplate>
                                        <ItemStyle CssClass="txtcenter border_left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Action" ItemStyle-Width="100px">
                                        <ItemTemplate>
                                        </ItemTemplate>
                                        <ItemStyle CssClass="txtcenter border_right_color" />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                            <br />
                            <%--<table border="1" cellpadding="0" class="supplieretadatetable" cellspacing="0" style="margin-top:-13px; display:block; border-top:0px;">
    <tr>
        <td style="width: 102px">         
            <asp:TextBox ID="txtqtyfrom" class="noonly" runat="server"  Text="" />
        </td>
        <td style="width: 102px">       
            <asp:TextBox ID="txtqtyto" class="noonly" runat="server"  Text="" />
        </td>
        <td style="width: 102px">        
            <asp:TextBox ID="txtetadateSupplier" CssClass="th datesfileds" runat="server" Text="" />
        </td>
        <td style="width: 100px;display:none">        
            <input type="image" id="dele" onclick="DeleteRow();return false;" />
        </td>
        <td style="width: 102px">      
           
                <img src="../../images/add-butt.png" id="btnAdd"  />
           
        </td>
    </tr>
</table>--%>
                            <table border="0" class="receivehis tableCenter" cellpadding="0" cellspacing="0"
                                style="margin-top: -13px; border-top: 0px; width: 352px; float: right; margin-right: 0px;">
                                <thead>
                                    <tr>
                                        <th style="width: 91px;">
                                            From (<asp:Label ID="lblunitto" runat="server"></asp:Label>)
                                        </th>
                                        <th style="width: 91px;">
                                            To (<asp:Label ID="lblunitfrom" runat="server"></asp:Label>)
                                        </th>
                                        <th style="width: 149px;">
                                            Date
                                        </th>
                                        <th style="width: 90px;">
                                            Action
                                        </th>
                                    </tr>
                                </thead>
                                <tbody id="tblbreakedown">
                                    <tr id="trbreaek0" style="">
                                        <td style="width: 91px; font-weight: 600;">
                                            <asp:Label ID="lblfromqty0" runat="server"></asp:Label>
                                            <asp:TextBox ID="txtfromqty0" ReadOnly="true" class="noonly" runat="server" Style="display: none"
                                                Text="" />
                                        </td>
                                        <td style="width: 91px">
                                            <asp:Label ID="lbltoqty0" runat="server" Font-Bold="true"></asp:Label>
                                            <asp:TextBox ID="txttoqty0" onchange="checkqtys(this,0)" class="noonly" Style="display: none"
                                                runat="server" Text="" />
                                        </td>
                                        <td style="width: 149px">
                                            <asp:Label ID="lbletabreakedate0" runat="server"></asp:Label>
                                            <asp:TextBox ID="txtetabreakedate0" onchange="CheckEtadates2(0)" CssClass="etadate datesfileds"
                                                Style="display: none" runat="server" Text="" />
                                        </td>
                                        <td style="width: 90px;">
                                            <img id="edit0" onclick="Edit('EDIT',0)" src="../../images/edit2.png" style="" alt="edit" />
                                            <img id="editupdate0" onclick="Edit('UPDATE',0)" src="../../images/update-new.png"
                                                style="display: none; cursor: pointer;" />
                                            <img id="editcancel0" onclick="Edit('CANCELEDIT',0)" src="../../images/Cancel1.png"
                                                style="position: relative; top: 2px; width: 22px; cursor: pointer; display: none" />
                                        </td>
                                        <td style="width: 90px; display: none">
                                        </td>
                                    </tr>
                                    <tr id="trbreaek1" style="display: none">
                                        <td style="width: 90px">
                                            <asp:Label ID="lblfromqty1" runat="server"></asp:Label>
                                            <asp:TextBox ID="txtfromqty1" ReadOnly="true" class="noonly" runat="server" Style="display: none"
                                                Text="" />
                                        </td>
                                        <td style="width: 90px">
                                            <asp:Label ID="lbltoqty1" runat="server"></asp:Label>
                                            <asp:TextBox ID="txttoqty1" onchange="checkqtys(this,1)" class="noonly" Style="display: none"
                                                runat="server" Text="" />
                                        </td>
                                        <td style="width: 150px">
                                            <asp:Label ID="lbletabreakedate1" runat="server"></asp:Label>
                                            <asp:TextBox ID="txtetabreakedate1" onchange="CheckEtadates2(1)" CssClass="etadate datesfileds"
                                                Style="display: none" runat="server" Text="" />
                                        </td>
                                        <td style="width: 90px;">
                                            <img id="edit1" onclick="Edit('EDIT',1)" src="../../images/edit2.png" style="" alt="edit" />
                                            <img id="editupdate1" onclick="Edit('UPDATE',1)" src="../../images/update-new.png"
                                                style="display: none" />
                                            <img id="editcancel1" onclick="Edit('CANCELEDIT',1)" src="../../images/Cancel1.png"
                                                style="position: relative; top: 2px; width: 22px; display: none" />
                                            <img id="editdelete1" onclick="Edit('DELETE',1)" src="../../images/del-butt.png" />
                                        </td>
                                        <td style="width: 90px; display: none">
                                        </td>
                                    </tr>
                                    <tr id="trbreaek2" style="display: none">
                                        <td style="width: 90px">
                                            <asp:Label ID="lblfromqty2" runat="server"></asp:Label>
                                            <asp:TextBox ID="txtfromqty2" ReadOnly="true" class="noonly" runat="server" Style="display: none"
                                                Text="" />
                                        </td>
                                        <td style="width: 90px">
                                            <asp:Label ID="lbltoqty2" runat="server"></asp:Label>
                                            <asp:TextBox ID="txttoqty2" onchange="checkqtys(this,2)" class="noonly" Style="display: none"
                                                runat="server" Text="" />
                                        </td>
                                        <td style="width: 150px">
                                            <asp:Label ID="lbletabreakedate2" runat="server"></asp:Label>
                                            <asp:TextBox ID="txtetabreakedate2" onchange="CheckEtadates2(2)" CssClass="etadate datesfileds"
                                                Style="display: none" runat="server" Text="" />
                                        </td>
                                        <td style="width: 90px;">
                                            <img id="edit2" onclick="Edit('EDIT',2)" src="../../images/edit2.png" style="" alt="edit" />
                                            <img id="editupdate2" onclick="Edit('UPDATE',2)" src="../../images/update-new.png"
                                                style="display: none" />
                                            <img id="editcancel2" onclick="Edit('CANCELEDIT',2)" src="../../images/Cancel1.png"
                                                style="position: relative; top: 2px; width: 22px; display: none" />
                                            <img id="editdelete2" onclick="Edit('DELETE',2)" src="../../images/del-butt.png" />
                                        </td>
                                        <td style="width: 90px; display: none">
                                        </td>
                                    </tr>
                                    <tr id="trbreaek3" style="display: none">
                                        <td style="width: 90px">
                                            <asp:Label ID="lblfromqty3" runat="server"></asp:Label>
                                            <asp:TextBox ID="txtfromqty3" ReadOnly="true" class="noonly" runat="server" Style="display: none"
                                                Text="" />
                                        </td>
                                        <td style="width: 90px">
                                            <asp:Label ID="lbltoqty3" runat="server"></asp:Label>
                                            <asp:TextBox ID="txttoqty3" onchange="checkqtys(this,3)" class="noonly" Style="display: none"
                                                runat="server" Text="" />
                                        </td>
                                        <td style="width: 150px">
                                            <asp:Label ID="lbletabreakedate3" runat="server"></asp:Label>
                                            <asp:TextBox ID="txtetabreakedate3" onchange="CheckEtadates2(3)" CssClass="etadate datesfileds"
                                                Style="display: none" runat="server" Text="" />
                                        </td>
                                        <td style="width: 90px;">
                                            <img id="edit3" onclick="Edit('EDIT',3)" src="../../images/edit2.png" style="" alt="edit" />
                                            <img id="editupdate3" onclick="Edit('UPDATE',3)" src="../../images/update-new.png"
                                                style="display: none" />
                                            <img id="editcancel3" onclick="Edit('CANCELEDIT',3)" src="../../images/Cancel1.png"
                                                style="position: relative; top: 2px; width: 22px; display: none" />
                                            <img id="editdelete3" onclick="Edit('DELETE',3)" src="../../images/del-butt.png" />
                                        </td>
                                        <td style="width: 90px; display: none">
                                        </td>
                                    </tr>
                                    <tr id="trbreaek4" style="display: none">
                                        <td style="width: 90px">
                                            <asp:Label ID="lblfromqty4" runat="server"></asp:Label>
                                            <asp:TextBox ID="txtfromqty4" ReadOnly="true" class="noonly" runat="server" Style="display: none"
                                                Text="" />
                                        </td>
                                        <td style="width: 90px">
                                            <asp:Label ID="lbltoqty4" runat="server"></asp:Label>
                                            <asp:TextBox ID="txttoqty4" onchange="checkqtys(this,4)" class="noonly" Style="display: none"
                                                runat="server" Text="" />
                                        </td>
                                        <td style="width: 150px">
                                            <asp:Label ID="lbletabreakedate4" runat="server"></asp:Label>
                                            <asp:TextBox ID="txtetabreakedate4" onchange="CheckEtadates2(4)" CssClass="etadate datesfileds"
                                                Style="display: none" runat="server" Text="" />
                                        </td>
                                        <td style="width: 90px;">
                                            <img id="edit4" onclick="Edit('EDIT',4)" src="../../images/edit2.png" style="" alt="edit" />
                                            <img id="editupdate4" onclick="Edit('UPDATE',4)" src="../../images/update-new.png"
                                                style="display: none" />
                                            <img id="editcancel4" onclick="Edit('CANCELEDIT',4)" src="../../images/Cancel1.png"
                                                style="position: relative; top: 2px; width: 22px; display: none" />
                                            <img id="editdelete4" onclick="Edit('DELETE',4)" src="../../images/del-butt.png" />
                                        </td>
                                        <td style="width: 90px; display: none">
                                        </td>
                                    </tr>
                                    <tr id="trbreaek5" style="display: none">
                                        <td style="width: 90px">
                                            <asp:Label ID="lblfromqty5" runat="server"></asp:Label>
                                            <asp:TextBox ID="txtfromqty5" ReadOnly="true" class="noonly" runat="server" Style="display: none"
                                                Text="" />
                                        </td>
                                        <td style="width: 90px">
                                            <asp:Label ID="lbltoqty5" runat="server"></asp:Label>
                                            <asp:TextBox ID="txttoqty5" onchange="checkqtys(this,5)" class="noonly" Style="display: none"
                                                runat="server" Text="" />
                                        </td>
                                        <td style="width: 150px">
                                            <asp:Label ID="lbletabreakedate5" runat="server"></asp:Label>
                                            <asp:TextBox ID="txtetabreakedate5" onchange="CheckEtadates2(5)" CssClass="etadate datesfileds"
                                                Style="display: none" runat="server" Text="" />
                                        </td>
                                        <td style="width: 90px;">
                                            <img id="edit5" onclick="Edit('EDIT',5)" src="../../images/edit2.png" style="" alt="edit" />
                                            <img id="editupdate5" onclick="Edit('UPDATE',5)" src="../../images/update-new.png"
                                                style="display: none" />
                                            <img id="editcancel5" onclick="Edit('CANCELEDIT',5)" src="../../images/Cancel1.png"
                                                style="position: relative; top: 2px; width: 22px; display: none" />
                                            <img id="editdelete5" onclick="Edit('DELETE',5)" src="../../images/del-butt.png" />
                                        </td>
                                        <td style="width: 90px; display: none">
                                        </td>
                                    </tr>
                                    <tr id="trbreaek6" style="display: none">
                                        <td style="width: 90px">
                                            <asp:Label ID="lblfromqty6" runat="server"></asp:Label>
                                            <asp:TextBox ID="txtfromqty6" ReadOnly="true" class="noonly" runat="server" Style="display: none"
                                                Text="" />
                                        </td>
                                        <td style="width: 90px">
                                            <asp:Label ID="lbltoqty6" runat="server"></asp:Label>
                                            <asp:TextBox ID="txttoqty6" onchange="checkqtys(this,6)" class="noonly" Style="display: none"
                                                runat="server" Text="" />
                                        </td>
                                        <td style="width: 150px">
                                            <asp:Label ID="lbletabreakedate6" runat="server"></asp:Label>
                                            <asp:TextBox ID="txtetabreakedate6" onchange="CheckEtadates2(6)" CssClass="etadate datesfileds"
                                                Style="display: none" runat="server" Text="" />
                                        </td>
                                        <td style="width: 90px;">
                                            <img id="edit6" onclick="Edit('EDIT',6)" src="../../images/edit2.png" style="" alt="edit" />
                                            <img id="editupdate6" onclick="Edit('UPDATE',6)" src="../../images/update-new.png"
                                                style="display: none" />
                                            <img id="editcancel6" onclick="Edit('CANCELEDIT',6)" src="../../images/Cancel1.png"
                                                style="position: relative; top: 2px; width: 22px; display: none" />
                                            <img id="editdelete6" onclick="Edit('DELETE',6)" src="../../images/del-butt.png" />
                                        </td>
                                        <td style="width: 90px; display: none">
                                        </td>
                                    </tr>
                                    <tr id="trbreaek7" style="display: none">
                                        <td style="width: 90px">
                                            <asp:Label ID="lblfromqty7" runat="server"></asp:Label>
                                            <asp:TextBox ID="txtfromqty7" ReadOnly="true" class="noonly" runat="server" Style="display: none"
                                                Text="" />
                                        </td>
                                        <td style="width: 90px">
                                            <asp:Label ID="lbltoqty7" runat="server"></asp:Label>
                                            <asp:TextBox ID="txttoqty7" onchange="checkqtys(this,7)" class="noonly" Style="display: none"
                                                runat="server" Text="" />
                                        </td>
                                        <td style="width: 150px">
                                            <asp:Label ID="lbletabreakedate7" runat="server"></asp:Label>
                                            <asp:TextBox ID="txtetabreakedate7" onchange="CheckEtadates2(7)" CssClass="etadate datesfileds"
                                                Style="display: none" runat="server" Text="" />
                                        </td>
                                        <td style="width: 90px;">
                                            <img id="edit7" onclick="Edit('EDIT',7)" src="../../images/edit2.png" style="" alt="edit" />
                                            <img id="editupdate7" onclick="Edit('UPDATE',7)" src="../../images/update-new.png"
                                                style="display: none" />
                                            <img id="editcancel7" onclick="Edit('CANCELEDIT',7)" src="../../images/Cancel1.png"
                                                style="position: relative; top: 2px; width: 22px; display: none" />
                                            <img id="editdelete7" onclick="Edit('DELETE',7)" src="../../images/del-butt.png" />
                                        </td>
                                        <td style="width: 90px; display: none">
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                            <%--   <table border="1"  class="receivehis tableCenter" cellpadding="0"
                                cellspacing="0" style="width: 99.7%; display: block; border-top: 0px;">--%>
                            <%-- <tr id="trbreaek0" style="">
                                    <td style="width: 91px">
                                        <asp:Label ID="lblfromqty0" runat="server"></asp:Label>
                                        <asp:TextBox ID="txtfromqty0" ReadOnly="true" class="noonly" runat="server" Style="display: none"
                                            Text="" />
                                    </td>
                                    <td style="width: 91px">
                                        <asp:Label ID="lbltoqty0" runat="server"></asp:Label>
                                        <asp:TextBox ID="txttoqty0" onchange="checkqtys(this,0)" class="noonly" Style="display: none"
                                            runat="server" Text="" />
                                    </td>
                                    <td style="width: 149px">
                                        <asp:Label ID="lbletabreakedate0" runat="server"></asp:Label>
                                        <asp:TextBox ID="txtetabreakedate0" onchange="CheckEtadates2(0)" CssClass="etadate datesfileds"
                                            Style="display: none" runat="server" Text="" />
                                    </td>
                                    <td style="width: 90px;">
                                        <img id="edit0" onclick="Edit('EDIT',0)" src="../../images/edit2.png" style="" alt="edit" />
                                        <img id="editcancel0" onclick="Edit('CANCELEDIT',0)" src="../../images/Cancel1.jpg"
                                            style="position: relative; top: 2px; width: 17px; display: none" />
                                        <img id="editupdate0" onclick="Edit('UPDATE',0)" src="../../App_Themes/ikandi/images/green_tick.gif"
                                            style="display: none" />
                                    </td>
                                    <td style="width: 90px; display: none">
                                    </td>
                                </tr>
                                <tr id="trbreaek1" style="display: none">
                                    <td style="width: 90px">
                                        <asp:Label ID="lblfromqty1" runat="server"></asp:Label>
                                        <asp:TextBox ID="txtfromqty1" ReadOnly="true" class="noonly" runat="server" Style="display: none"
                                            Text="" />
                                    </td>
                                    <td style="width: 90px">
                                        <asp:Label ID="lbltoqty1" runat="server"></asp:Label>
                                        <asp:TextBox ID="txttoqty1" onchange="checkqtys(this,1)" class="noonly" Style="display: none"
                                            runat="server" Text="" />
                                    </td>
                                    <td style="width: 150px">
                                        <asp:Label ID="lbletabreakedate1" runat="server"></asp:Label>
                                        <asp:TextBox ID="txtetabreakedate1" onchange="CheckEtadates2(1)" CssClass="etadate datesfileds"
                                            Style="display: none" runat="server" Text="" />
                                    </td>
                                    <td style="width: 90px;">
                                        <img id="edit1" onclick="Edit('EDIT',1)" src="../../images/edit2.png" style="" alt="edit" />
                                        <img id="editcancel1" onclick="Edit('CANCELEDIT',1)" src="../../images/Cancel1.jpg"
                                            style="position: relative; top: 2px; width: 17px; display: none" />
                                        <img id="editupdate1" onclick="Edit('UPDATE',1)" src="../../App_Themes/ikandi/images/green_tick.gif"
                                            style="display: none" />
                                        <img id="editdelete1" onclick="Edit('DELETE',1)" src="../../images/del-butt.png" />
                                    </td>
                                    <td style="width: 90px; display: none">
                                    </td>
                                </tr>
                                <tr id="trbreaek2" style="display: none">
                                    <td style="width: 90px">
                                        <asp:Label ID="lblfromqty2" runat="server"></asp:Label>
                                        <asp:TextBox ID="txtfromqty2" ReadOnly="true" class="noonly" runat="server" Style="display: none"
                                            Text="" />
                                    </td>
                                    <td style="width: 90px">
                                        <asp:Label ID="lbltoqty2" runat="server"></asp:Label>
                                        <asp:TextBox ID="txttoqty2" onchange="checkqtys(this,2)" class="noonly" Style="display: none"
                                            runat="server" Text="" />
                                    </td>
                                    <td style="width: 150px">
                                        <asp:Label ID="lbletabreakedate2" runat="server"></asp:Label>
                                        <asp:TextBox ID="txtetabreakedate2" onchange="CheckEtadates2(2)" CssClass="etadate datesfileds"
                                            Style="display: none" runat="server" Text="" />
                                    </td>
                                    <td style="width: 90px;">
                                        <img id="edit2" onclick="Edit('EDIT',2)" src="../../images/edit2.png" style="" alt="edit" />
                                        <img id="editcancel2" onclick="Edit('CANCELEDIT',2)" src="../../images/Cancel1.jpg"
                                            style="position: relative; top: 2px; width: 17px; display: none" />
                                        <img id="editupdate2" onclick="Edit('UPDATE',2)" src="../../App_Themes/ikandi/images/green_tick.gif"
                                            style="display: none" />
                                        <img id="editdelete2" onclick="Edit('DELETE',2)" src="../../images/del-butt.png" />
                                    </td>
                                    <td style="width: 90px; display: none">
                                    </td>
                                </tr>
                                <tr id="trbreaek3" style="display: none">
                                    <td style="width: 90px">
                                        <asp:Label ID="lblfromqty3" runat="server"></asp:Label>
                                        <asp:TextBox ID="txtfromqty3" ReadOnly="true" class="noonly" runat="server" Style="display: none"
                                            Text="" />
                                    </td>
                                    <td style="width: 90px">
                                        <asp:Label ID="lbltoqty3" runat="server"></asp:Label>
                                        <asp:TextBox ID="txttoqty3" onchange="checkqtys(this,3)" class="noonly" Style="display: none"
                                            runat="server" Text="" />
                                    </td>
                                    <td style="width: 150px">
                                        <asp:Label ID="lbletabreakedate3" runat="server"></asp:Label>
                                        <asp:TextBox ID="txtetabreakedate3" onchange="CheckEtadates2(3)" CssClass="etadate datesfileds"
                                            Style="display: none" runat="server" Text="" />
                                    </td>
                                    <td style="width: 90px;">
                                        <img id="edit3" onclick="Edit('EDIT',3)" src="../../images/edit2.png" style="" alt="edit" />
                                        <img id="editcancel3" onclick="Edit('CANCELEDIT',3)" src="../../images/Cancel1.jpg"
                                            style="position: relative; top: 2px; width: 17px; display: none" />
                                        <img id="editupdate3" onclick="Edit('UPDATE',3)" src="../../App_Themes/ikandi/images/green_tick.gif"
                                            style="display: none" />
                                        <img id="editdelete3" onclick="Edit('DELETE',3)" src="../../images/del-butt.png" />
                                    </td>
                                    <td style="width: 90px; display: none">
                                    </td>
                                </tr>
                                <tr id="trbreaek4" style="display: none">
                                    <td style="width: 90px">
                                        <asp:Label ID="lblfromqty4" runat="server"></asp:Label>
                                        <asp:TextBox ID="txtfromqty4" ReadOnly="true" class="noonly" runat="server" Style="display: none"
                                            Text="" />
                                    </td>
                                    <td style="width: 90px">
                                        <asp:Label ID="lbltoqty4" runat="server"></asp:Label>
                                        <asp:TextBox ID="txttoqty4" onchange="checkqtys(this,4)" class="noonly" Style="display: none"
                                            runat="server" Text="" />
                                    </td>
                                    <td style="width: 150px">
                                        <asp:Label ID="lbletabreakedate4" runat="server"></asp:Label>
                                        <asp:TextBox ID="txtetabreakedate4" onchange="CheckEtadates2(4)" CssClass="etadate datesfileds"
                                            Style="display: none" runat="server" Text="" />
                                    </td>
                                    <td style="width: 90px;">
                                        <img id="edit4" onclick="Edit('EDIT',4)" src="../../images/edit2.png" style="" alt="edit" />
                                        <img id="editcancel4" onclick="Edit('CANCELEDIT',4)" src="../../images/Cancel1.jpg"
                                            style="position: relative; top: 2px; width: 17px; display: none" />
                                        <img id="editupdate4" onclick="Edit('UPDATE',4)" src="../../App_Themes/ikandi/images/green_tick.gif"
                                            style="display: none" />
                                        <img id="editdelete4" onclick="Edit('DELETE',4)" src="../../images/del-butt.png" />
                                    </td>
                                    <td style="width: 90px; display: none">
                                    </td>
                                </tr>
                                <tr id="trbreaek5" style="display: none">
                                    <td style="width: 90px">
                                        <asp:Label ID="lblfromqty5" runat="server"></asp:Label>
                                        <asp:TextBox ID="txtfromqty5" ReadOnly="true" class="noonly" runat="server" Style="display: none"
                                            Text="" />
                                    </td>
                                    <td style="width: 90px">
                                        <asp:Label ID="lbltoqty5" runat="server"></asp:Label>
                                        <asp:TextBox ID="txttoqty5" onchange="checkqtys(this,5)" class="noonly" Style="display: none"
                                            runat="server" Text="" />
                                    </td>
                                    <td style="width: 150px">
                                        <asp:Label ID="lbletabreakedate5" runat="server"></asp:Label>
                                        <asp:TextBox ID="txtetabreakedate5" onchange="CheckEtadates2(5)" CssClass="etadate datesfileds"
                                            Style="display: none" runat="server" Text="" />
                                    </td>
                                    <td style="width: 90px;">
                                        <img id="edit5" onclick="Edit('EDIT',5)" src="../../images/edit2.png" style="" alt="edit" />
                                        <img id="editcancel5" onclick="Edit('CANCELEDIT',5)" src="../../images/Cancel1.jpg"
                                            style="position: relative; top: 2px; width: 17px; display: none" />
                                        <img id="editupdate5" onclick="Edit('UPDATE',5)" src="../../App_Themes/ikandi/images/green_tick.gif"
                                            style="display: none" />
                                        <img id="editdelete5" onclick="Edit('DELETE',5)" src="../../images/del-butt.png" />
                                    </td>
                                    <td style="width: 90px; display: none">
                                    </td>
                                </tr>
                                <tr id="trbreaek6" style="display: none">
                                    <td style="width: 90px">
                                        <asp:Label ID="lblfromqty6" runat="server"></asp:Label>
                                        <asp:TextBox ID="txtfromqty6" ReadOnly="true" class="noonly" runat="server" Style="display: none"
                                            Text="" />
                                    </td>
                                    <td style="width: 90px">
                                        <asp:Label ID="lbltoqty6" runat="server"></asp:Label>
                                        <asp:TextBox ID="txttoqty6" onchange="checkqtys(this,6)" class="noonly" Style="display: none"
                                            runat="server" Text="" />
                                    </td>
                                    <td style="width: 150px">
                                        <asp:Label ID="lbletabreakedate6" runat="server"></asp:Label>
                                        <asp:TextBox ID="txtetabreakedate6" onchange="CheckEtadates2(6)" CssClass="etadate datesfileds"
                                            Style="display: none" runat="server" Text="" />
                                    </td>
                                    <td style="width: 90px;">
                                        <img id="edit6" onclick="Edit('EDIT',6)" src="../../images/edit2.png" style="" alt="edit" />
                                        <img id="editcancel6" onclick="Edit('CANCELEDIT',6)" src="../../images/Cancel1.jpg"
                                            style="position: relative; top: 2px; width: 17px; display: none" />
                                        <img id="editupdate6" onclick="Edit('UPDATE',6)" src="../../App_Themes/ikandi/images/green_tick.gif"
                                            style="display: none" />
                                        <img id="editdelete6" onclick="Edit('DELETE',6)" src="../../images/del-butt.png" />
                                    </td>
                                    <td style="width: 90px; display: none">
                                    </td>
                                </tr>
                                <tr id="trbreaek7" style="display: none">
                                    <td style="width: 90px">
                                        <asp:Label ID="lblfromqty7" runat="server"></asp:Label>
                                        <asp:TextBox ID="txtfromqty7" ReadOnly="true" class="noonly" runat="server" Style="display: none"
                                            Text="" />
                                    </td>
                                    <td style="width: 90px">
                                        <asp:Label ID="lbltoqty7" runat="server"></asp:Label>
                                        <asp:TextBox ID="txttoqty7" onchange="checkqtys(this,7)" class="noonly" Style="display: none"
                                            runat="server" Text="" />
                                    </td>
                                    <td style="width: 150px">
                                        <asp:Label ID="lbletabreakedate7" runat="server"></asp:Label>
                                        <asp:TextBox ID="txtetabreakedate7" onchange="CheckEtadates2(7)" CssClass="etadate datesfileds"
                                            Style="display: none" runat="server" Text="" />
                                    </td>
                                    <td style="width: 90px;">
                                        <img id="edit7" onclick="Edit('EDIT',7)" src="../../images/edit2.png" style="" alt="edit" />
                                        <img id="editcancel7" onclick="Edit('CANCELEDIT',7)" src="../../images/Cancel1.jpg"
                                            style="position: relative; top: 2px; width: 17px; display: none" />
                                        <img id="editupdate7" onclick="Edit('UPDATE',7)" src="../../App_Themes/ikandi/images/green_tick.gif"
                                            style="display: none" />
                                        <img id="editdelete7" onclick="Edit('DELETE',7)" src="../../images/del-butt.png" />
                                    </td>
                                    <td style="width: 90px; display: none">
                                    </td>
                                </tr>--%>
                            <%-- <tr>
        <td style="width: 90px">         
            <asp:TextBox ID="txtfromqty" class="noonly" runat="server"  Text="" />
        </td>
        <td style="width: 90px">       
            <asp:TextBox ID="txttoqty" class="noonly" runat="server"  Text="" />
        </td>
        <td style="width: 150px;text-align:center">        
            <asp:TextBox ID="txtetabreakedate" CssClass="th datesfileds" Width="90%" runat="server" Text="" />
        </td>
        <td style="width: 90px;display:none">        
            <input type="image" id="Image1" onclick="DeleteRow();return false;" />
        </td>
        <td style="width: 90px">      
           
                <img src="../../images/add-butt.png" onclick="Addnew('ADD')" id="Img1"  />
           
        </td>
    </tr>--%>
                            <%--                            </table>--%>
                        </td>
                    </tr>
                </table>
            </div>
            <div style="width: 1100px; display: flex; align-items: center; margin: 10px 0;">
                <label>
                    Remarks:</label>
                <textarea id="comment" runat="server" cols="5" rows="4" style="width: 50%;"> </textarea>
            </div>
            <div id="divguidline" runat="server" style="width: 1100px;">
            </div>
            <div style="width: 1100px; border: 1px solid darkgray; display: flex; margin: 10px 0; padding: 10px 0;">
                <div style="width: 33%; display: flex; text-align: center; flex-direction: column;align-items: center; justify-content: center;">
                 <b style="font-family: sans-serif;">Boutique International Pvt. Ltd.</b>
                    <asp:Image ID="imgJuniorSignatory" runat="server" Style="max-width: 150px; max-height: 50px;
                        border: 1px solid gray!important; padding: 5px; margin: 10px 0px;" />
                    <asp:Label ID="lblJuniorName" runat="server" Style="text-align: center; font-size: 9px;
                        margin: 5px;"></asp:Label>
                    <asp:Label ID="lblJuniorSignatorydate" CssClass="AuthorizedSignatorydate" runat="server"></asp:Label>
                    <asp:CheckBox ID="chkJuniorSignatory" runat="server" Style="position: relative; top: 2px;
                        margin-left: -5px;" />
                    <span style="position: relative; right: 0%; display: inherit;" runat="server" id="spanJuniorSig">
                        (Subordinate Signature)</span>
                </div>
                <div style="width: 33%; display: flex; text-align: center; flex-direction: column;align-items: center; justify-content: center;">
                 <b style="font-family: sans-serif;">Boutique International Pvt. Ltd.</b>
                    <asp:Image ID="imgAuthorizedSignatory" runat="server" Style="max-width: 150px; max-height: 50px;
                        border: 1px solid gray!important; padding: 5px; margin: 10px 0px;" />
                    <asp:Label ID="lblAuthorizedName" runat="server" Style="text-align: center; font-size: 9px;
                        margin: 5px;"></asp:Label>
                    <asp:Label ID="lblAuthorizedSignatorydate" CssClass="AuthorizedSignatorydate" runat="server"></asp:Label>
                    <asp:CheckBox ID="chkAuthorizedSignatory" onclick="MailCheck()" runat="server" Style="position: relative;
                        top: 2px; margin-left: -5px;" />
                    <span style="position: relative; right: 0%; display: inherit;" runat="server" id="spanAuthorizedSig">
                        (Authorized Signature)</span>
                </div>
                <div style="width: 33%; display: flex; text-align: center; flex-direction: column;
                    align-items: center; justify-content: center;">
                    <b style="font-family: sans-serif;">Accepted by</b>
                    <asp:Image ID="imgpartysingature" runat="server" Style="max-width: 150px; max-height: 50px;
                        border: 1px solid gray!important; padding: 5px; margin: 10px 0px;" />
                    <asp:Label ID="lblPartyName" runat="server" CssClass="AuthorizedSignatorydate1" Style="text-align: center;
                        font-size: 9px; margin: 5px;"></asp:Label>
                    <asp:Label ID="lblimgpartysingature" CssClass="AuthorizedSignatorydate1" runat="server"
                        Style="width: 100%; text-align: center;"></asp:Label>
                    <asp:CheckBox ID="chkpartysignature" onclick="MailCheck()" runat="server" Style="position: relative;
                        top: 2px; margin-left: -5px;" CssClass="RightCheckBox" />
                    <span style="position: relative; right: 0%;" id="PositonRightM" runat="server">(Party
                        Signature)</span>
                </div>
            </div>
            <div style="display: flex; width: 1100px;">
                <asp:Button ID="btnSubmit" runat="server" class="Call_Prent" Text="Submit" CssClass="btnSubmit"
                    OnClientClick="javascript:return checkValidation();" />
                <div class="btnSubmit printHideButton" id="divSubmit" visible="false" style="display: none;"
                    runat="server" onclick="checkValidation();">
                    Submit
                </div>
                <div class="btnClose printHideButton" onclick="javascript:self.parent.Shadowbox.close();">
                    Close
                </div>
                <div class="btnPrint printHideButton" onclick="window.print();return false">
                    Print
                </div>
                <div id="divmail" style="display: none; position: relative; left: 10px; width: 200px;">
                    Send Mail &nbsp;<input type="radio" id="rdoyes" runat="server" name="Mail" value="Yes">Yes
                    &nbsp;<input type="radio" id="rdoNo" runat="server" checked="true" name="Mail" value="No">No
                </div>
            </div>
            <asp:Button ID="btnshow" runat="server" Style="display: none;" CssClass="btnshowsrv"
                OnClick="btnshow_Click" />
            <asp:Button ID="btnsave" runat="server" Style="display: none;" OnClick="btnsave_Click" />
            <asp:ValidationSummary ID="ValidationSummary2" runat="server" ValidationGroup="gedit"
                ShowMessageBox="True" ShowSummary="False" />
        </ContentTemplate>
    </asp:UpdatePanel>
    <div class="ModelPo" id="divconversionorder" style="display: none">
        <div class="backcolorpo">
            <div class="BodyContect">
                <h2 style="padding: 0px 0px; font-weight: 500; font-size: 14px;">
                    Convert Unit Ratio</h2>
                <div style="width: 150px; display: initial">
                    <span style="margin-right: 5px;">From </span>
                    <asp:Label ID="lblfromunit" runat="server" Text="Mtr" Style="color: #232222; margin-right: 5px;"></asp:Label>
                    <asp:TextBox ID="txtfromunit" Style="width: 60px;" runat="server" Text="1" ReadOnly="true"></asp:TextBox>
                </div>
                <span style="margin-right: 5px;">To </span>
                <asp:Label ID="lbltounit" Text="Mtr" runat="server" Style="color: black"></asp:Label>
                <asp:TextBox ID="txttounit" Style="width: 60px; margin-right: 5px;" runat="server"
                    onkeypress="return validateFloatKeyPress(this,event);" Text=""></asp:TextBox>
            </div>
            <input type="button" class="btnOk" onclick="ConversionValueChange('OK');" title="sumbit pop up"
                value="Ok" />
            <input type="button" class="btnCancel" onclick="ConversionValueChange('CANCEL');"
                title="cancel pop up" value="Cancel" />
        </div>
    </div>
    <div class="ModelPo2" id="divhistory" runat="server" style="display: none">
        <table cellpadding="0" cellspacing="0" style="width: 100%;">
            <tr>
                <th style='background: #39589c !important; padding: 3px 5px; color: #fff !important;
                    text-align: center'>
                    History<span style='float: right; cursor: pointer; color: #fff' titel='Close' onclick="showhistory('none');">X</span>
                </th>
            </tr>
            <tr>
                <td style="width: 50%; text-align: left; padding: 0px 10px;">
                    <asp:Label ID="lblh" Style="text-align: left; line-height: 15px; color: #737272;
                        font-size: 11px;" runat="server"></asp:Label>
                    <asp:Label ID="lblremarkh" Style="text-align: left; line-height: 15px; color: #737272;
                        font-size: 11px;" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
