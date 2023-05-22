<%@ Page Title="" Language="C#" MasterPageFile="~/layout/Secure.Master" AutoEventWireup="true"
    CodeBehind="AccessoriesQualityIssuing.aspx.cs" Inherits="iKandi.Web.Internal.Accessory.AccessoriesQualityIssuing" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_main_content" runat="server">
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
    <link href="../../css/report.css" rel="stylesheet" type="text/css" />
    <link href="../../css/report.css" rel="stylesheet" type="text/css" />
    <link href="../../css/CommanTooltip.css" rel="stylesheet" type="text/css" />
    <style>
        body {
            font-family: Arial;
        }

        .StyleContextup {
            text-align: center;
            white-space: nowrap;
            vertical-align: middle;
            width: 2em;
            position: relative;
        }

        .headercontentSr div {
            transform: rotate(-90.0deg) !important;
            -moz-transform: rotate(-90.0deg) !important; /* FF3.5+ */
            -o-transform: rotate(-90.0deg); /* Opera 10.5 */
            -webkit-transform: rotate(-90.0deg); /* Saf3.1+, Chrome */
            filter: progid:DXImageTransform.Microsoft.BasicImage(rotation=0.083); /* IE6,IE7 */
            -ms-filter: "progid:DXImageTransform.Microsoft.BasicImage(rotation=0.083)"; /* IE8 */
            margin-left: -10em;
            margin-right: -10em;
            font-weight: 500;
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
            position: relative;
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

        td.ContactNoCol {
            padding: 0px !important;
            text-align: center;
        }

        th.ContactNoCol {
            padding: 0px !important;
            text-align: center;
        }

        .innertable {
            border-collapse: collapse;
        }

            .innertable td {
                border-left: 1px solid #999;
                padding: 2px 0px;
                min-width: 50px;
                max-width: 50px;
                text-align: center;
            }

                .innertable td:first-child {
                    border-left: 0px;
                }

        td.challanCol {
            padding: 0px 0px !important;
            border-bottom: 1px solid #999999;
            min-width: 300px;
        }

        th.challanCol {
            padding: 0px 0px !important;
            height: 15px;
        }

        .border_last_bottom_color {
            border-bottom-color: #999 !important;
        }

        .AddClass_Table td {
            font-size: 10px;
            border-left: 0px;
            border-top: 0px;
        }

        .search_1 {
            font-size: 10px !important;
            ;
            padding-left: 4px;
        }

        #sb-body {
            background: #fff;
        }

        #sb-wrapper-inner {
            border: 5px solid #999;
            border-radius: 3px;
        }

        .ChallanTableInner td {
            border-collapse: collapse;
            border-left: 0px;
        }

        .ChallanTableInner {
            border-collapse: collapse;
        }

        .AddClass_Table td .ChallanTableInner tr:nth-child(1) > td {
            border-bottom: 0px !important;
            border-top: 0px;
        }

        .AddClass_Table {
            border: 1px solid #999;
            border-collapse: separate !important;
        }

        .divMoveStockQty {
            position: fixed;
            top: 44%;
            left: 43%;
            /* width: 30em; */
            min-height: 150px;
            margin-top: -9em;
            margin-left: -15em;
            border: 1px solid #ccc;
            background-color: #f3f3f3;
            z-index: 2;
            width: 274px;
        }

            .divMoveStockQty th, td {
                font-family: Arial;
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

        .EmptyRow td {
            padding-left: 0px !important;
            border: 0px;
        }

        .clsChallan_Table td {
            border-right: 1px solid #dbd8d8 !important;
            font-size: 9px !important;
            font-family: arial !important;
            text-align: center;
            border-bottom: 1px solid #999;
            border-top: 1px solid #999;
            font-family: arial !important;
        }

        th.qaheader {
            border-right: 1px solid #999 !important;
            padding: 3px 5px !important;
            background: #cecccc;
        }

        .clsChallan_Table td:first-child {
            border-left: 1px solid #999 !important
        }

        .clsChallan_Table td:last-child {
            border-right: 1px solid #999 !important
        }

        .clsChallan_Table tr:nth-last-child(1) > td {
            border-bottom: 1px solid #999 !important
        }

        th.qaheader:first-child {
            border-left: 1px solid #999 !important
        }

        .clsChallan_Table th {
            color: #575759;
            background-color: #dddfe4;
            text-transform: capitalize;
            text-align: center;
            font-weight: normal;
            font-size: 11px;
            border-right: 0px;
        }

        .clsChallan_Table {
            position: fixed;
            top: 50%;
            left: 82%;
            z-index: 0;
            background: #fff;
            width: 234px;
        }

        .abc .clsChallan_Table {
            border-collapse: collapse;
        }

        .clsChallan_Table td {
            font-size: 11px !important;
            padding: 2px 3px !important;
        }

        .abc {
            height: 100%;
            width: 100%;
            position: absolute;
            top: 0px;
        }

        .qatableheader {
            content: "";
            position: absolute;
            top: 0%;
            right: -7%;
            margin-left: -5px;
            border-width: 8px;
            border-style: solid;
            border-color: transparent transparent transparent #39589c;
        }

        .AddClass_Table th {
            padding: 0px 0px;
            text-align: center;
            font-weight: 500;
            background: #dddfe4;
            text-transform: capitalize;
            color: #6b6464;
            font-size: 11px;
            font-family: Arial !important;
            height: 15px;
            position: sticky;
            top: 25px;
            border-left: 0px;
            z-index: 1;
        }

        .AccessToltip {
            position: relative;
            display: inline-block;
        }

            .AccessToltip .TooltipTxt {
                visibility: hidden;
                width: 140px;
                background-color: #373737;
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

                .AccessToltip .TooltipTxt::after {
                    content: "";
                    position: absolute;
                    top: 100%;
                    left: 50%;
                    margin-left: -5px;
                    border-width: 5px;
                    border-style: solid;
                    border-color: black transparent transparent transparent;
                }

            .AccessToltip:hover .TooltipTxt {
                visibility: visible;
            }

        .headerSticky {
            width: 100%;
            min-width: 1200px;
            font-weight: 500;
            padding: 1px 0px;
            background: #3b5998;
            color: #fff;
            font-weight: 500;
            font-size: 14px;
        }

        td.StyleContextup {
            border-left: 1px solid #999;
        }

        th.borderThLeft {
            border-left: 1px solid #999;
        }

        #PopTableW {
            width: 1252p;
            position: sticky;
            top: 0px;
            z-index: 9;
            text-align: center;
            padding-bottom: 2px;
            background: #fff
        }

        td.TxtRight {
            text-align: right;
            padding-right: 5px !important;
        }

        @media print {
            body {
                -webkit-print-color-adjust: exact;
            }

            .printHideButton {
                display: none;
            }

            #PopTableW {
                width: 1252p;
                position: initial;
                top: none;
                z-index: 9;
                text-align: center;
                padding-bottom: 2px;
                background: #fff
            }

            .AddClass_Table th {
                padding: 0px 0px;
                text-align: center;
                font-weight: 500;
                background: #dddfe4;
                text-transform: capitalize;
                color: #6b6464;
                font-size: 11px;
                font-family: Arial !important;
                height: 15px;
                position: initial;
                top: 25px;
                border-left: 0px;
                z-index: 1;
            }

            .SrNoContextup div {
                margin-top: 100px;
            }

            .StyleContextup div {
                margin-top: 100px;
            }
        }

        .margin-top:first-child {
            margin-top: 12px;
        }

        .create_challan_link:hover {
            color: Green !important;
        }
    </style>
    <script type="text/javascript">
        var serviceUrl = '<%= ResolveUrl("~/Webservices/iKandiService.asmx/") %>';
        var proxy = new ServiceProxy(serviceUrl);

        $(document).ready(function () {
            $('.process').click(function (e) { //Default mouse Position                 
                // alert(e.pageX + ' , ' + e.pageY);
                $('#here_table').html("");
                var d = document.getElementById('here_table');
                d.style.position = "absolute";
                d.style.left = (e.pageX - 270) + 'px';
                d.style.top = (e.pageY - 50) + 'px';
            });
            // added by shubhendu 23/03/2022--------------------------------

            var Unitid = $("#ctl00_cph_main_content_grdAccessory_ctl01_ddlFactoryUnit").val();
            if (Unitid < 0) {

                $("#ctl00_cph_main_content_grdAccessory_ctl01_chkRaiseReuestAll").attr("disabled", "true");


            }
            $("#ctl00_cph_main_content_grdAccessory_ctl01_ddlFactoryUnit").change(function () {
                debugger;
                var Unitid = $("#ctl00_cph_main_content_grdAccessory_ctl01_ddlFactoryUnit").val();
                if (Unitid < 0) {

                    $("#ctl00_cph_main_content_grdAccessory_ctl01_chkRaiseReuestAll").attr("disabled", "true");

                }
                else {
                    $("#ctl00_cph_main_content_grdAccessory_ctl01_chkRaiseReuestAll").attr("disabled", "");
                }



            });
            //till here --------------------------------------------------------------------------
            var GridviewRows = $("#<%=grdAccessory.ClientID%> tr").length;
            var rowlenght = GridviewRows - 1;
            var id = 0;
            for (var i = 2; i < rowlenght + 2; i++) {
                id = i;
                if (id < 10) {
                    id = 'ctl0' + i.toString();
                }
                else {
                    id = 'ctl' + i.toString();
                }
                var ContactNumberMaxVal = $("#<%= grdAccessory.ClientID %>_" + id + "_hdnContactNumber").val();
                var ContactMaxLen = 0;
                if (ContactNumberMaxVal) {
                    ContactMaxLen = ContactNumberMaxVal.toString().length;
                }




                if (ContactMaxLen > 10) {
                    $(".ContactNumberMax span").text(function (index, currentText) {
                        var maxLength = $(this).parent().attr('data-maxlength');
                        if (currentText.length >= maxLength) {
                            return currentText.substr(0, maxLength) + "...";
                        } else {
                            return currentText
                        }
                    });

                    $("#<%= grdAccessory.ClientID %>_" + id + "_lblContactNo").attr('data-title', ContactNumberMaxVal);

                }
            }
        });


        //        function OpenChallan(OrderDetailId, AccessoryMaster_Id, Color_Print, Size, Challan_Id, AvailableQty) {
        //            //debugger;            
        //            if ((AvailableQty == undefined) || (AvailableQty == ''))
        //                AvailableQty = '0'

        //            var sURL = 'AccessoryInternalChallan.aspx?OrderDetailId=' + OrderDetailId + '&AccessoryMasterId=' + AccessoryMaster_Id + '&ColorPrint=' + Color_Print + '&Size=' + Size + '&ChallanId=' + Challan_Id + '&AvailableQty=' + AvailableQty + '&Flag=' + 'OpenChallan' + '&flagOption=' + 'SignaturePending';
        //            Shadowbox.init({ animate: true, animateFade: true, modal: true });
        //            Shadowbox.open({ content: sURL, type: "iframe", player: "iframe", title: "", height: 600, width: 750, modal: true, animate: true, animateFade: true, options: { onClose: SBClose} });
        //            return false;
        //        }

        function SBClose() { }

        function PageReload() {
            location.reload(true);
        }
        //        function CreateNewChallan(OrderDetailId, AccessoryMaster_Id, Color_Print, Size, AvailableQty) {
        //            //debugger;
        //            if ((AvailableQty == undefined) || (AvailableQty == ''))
        //                AvailableQty = '0'
        //            var sURL = 'AccessoryInternalChallan.aspx?OrderDetailId=' + OrderDetailId + '&AccessoryMasterId=' + AccessoryMaster_Id + '&ColorPrint=' + Color_Print + '&Size=' + Size + '&AvailableQty=' + AvailableQty + '&Flag=' + 'OpenChallan' + '&flagOption=' + 'NewChallan';
        //            Shadowbox.init({ animate: true, animateFade: true, modal: true });
        //            Shadowbox.open({ content: sURL, type: "iframe", player: "iframe", title: "", width: 1150, modal: true, animate: true, animateFade: true, options: { onClose: SBClose} });
        //            return false;
        //        }



        function CreateNewChallan(SerialNumber, CanMakeNewChallan) {

            if (CanMakeNewChallan.toLowerCase() == "true".toLowerCase()) {
                var sURL = 'AccessoryInternalChallan.aspx?Flag=' + 'OpenChallan' + '&flagOption=' + 'NewChallan' + '&SerialNumber=' + SerialNumber + '&ChallanType=' + 'INTERNAL_CHALLAN';
                Shadowbox.init({ animate: true, animateFade: true, modal: true });
                Shadowbox.open({ content: sURL, type: "iframe", player: "iframe", title: "", width: 1150, modal: true, animate: true, animateFade: true, options: { onClose: SBClose } });
            }
            else alert("Please Clear Previous Challan First.");
            return false;
        }

        function OpenChallan(ChallanNumber, flagOption, SerialNumber) {

            if (flagOption.toLowerCase() == "SignaturePending".toLowerCase())
                var sURL = 'AccessoryInternalChallan.aspx?Flag=' + 'OpenChallan' + '&flagOption=' + flagOption + '&SerialNumber=' + SerialNumber + '&ChallanNumber=' + ChallanNumber + '&ChallanType=' + 'INTERNAL_CHALLAN';
            else
                var sURL = 'AccessoryInternalChallan.aspx?Flag=' + 'GetChallanDetails' + '&SerialNumber=' + SerialNumber + '&ChallanNumber=' + ChallanNumber + '&ChallanType=' + 'INTERNAL_CHALLAN';

            Shadowbox.init({ animate: true, animateFade: true, modal: true });
            Shadowbox.open({ content: sURL, type: "iframe", player: "iframe", title: "", width: 1150, modal: true, animate: true, animateFade: true, options: { onClose: SBClose } });
            return false;
        }


        function UpdateCompleteIssueReq(elem) {
            debugger;
            var Idsn = elem.innerHTML.split("_")[5];
            var QtyLeft = $("#<%= grdAccessory.ClientID %>_" + Idsn + "_hdnLeftQuantity").val();
            if (parseInt(QtyLeft) > 0) {
                MoveToStockPopupOpen(Idsn);
                var str1 = elem.innerHTML.split('"');
                $('#' + str1[1]).attr('checked', false);
            }
            //            else {
            //                var result = confirm("After selection checkbox will be freezed!");
            //                var str1 = elem.innerHTML.split('"');
            //                if (result) {
            //                    $('#' + str1[1]).attr('disabled', 'disabled');
            //                } else {
            //                    $('#' + str1[1]).attr('checked', false);
            //                }
            //            }
        }



        function HideDiv() {
            $(".divMoveStockQty").hide();
        }
        function ShowDiv() {
            $(".divMoveStockQty").show();
        }

        function OnchangeStockQty() {
            $("#ctl00_cph_main_content_lblleftmoveqty").text('');

            var StockQty = $("#ctl00_cph_main_content_txtStockqty").val();
            var DebitQty = $("#ctl00_cph_main_content_txtDebitqty").val();

            var ActualQty = $("#ctl00_cph_main_content_hdnmoveqty").val();
            if (StockQty == "") {
                StockQty = 0;
            }
            if (DebitQty == "") {
                DebitQty = 0;
            }
            if (ActualQty == "") {
                ActualQty = 0;
            }
            var TotalQty = parseFloat(StockQty) + parseFloat(DebitQty);

            if (parseFloat(TotalQty) > parseFloat(ActualQty)) {
                alert("Entered qty. cannot be greater than: " + ActualQty);
                $("#ctl00_cph_main_content_txtStockqty").val('');
                $("#ctl00_cph_main_content_txtDebitqty").val('');
                $("#ctl00_cph_main_content_lblleftmoveqty").text(ActualQty.toFixed(2));
                return false;
            }
            else {
                var BalanceQty = (parseFloat(ActualQty) - parseFloat(TotalQty));
                if (parseFloat(BalanceQty) > 0) {
                    $("#ctl00_cph_main_content_lblleftmoveqty").text(numberWithCommas(BalanceQty.toFixed(2)));
                }
            }

            if (parseFloat(DebitQty) > 0) {
                $("#ctl00_cph_main_content_txtParticular").removeAttr("disabled");
            }

        }

        //        function isNumber(val,evt) {
        //            debugger;
        //            value= $(val);
        //            var iKeyCode = (evt.which) ? evt.which : evt.keyCode
        //            if (iKeyCode > 31 && (iKeyCode < 48 || iKeyCode > 57 ) && value.index('.')==-1)
        //                return false;


        //            return true;
        //        }
        function isNumber(val, evt) {


            //            var charCode = (evt.which) ? evt.which : evt.keyCode;
            //            if (charCode != 46 && charCode > 31
            //            && (charCode < 48 || charCode > 57))
            //                return false;
            //  alert(evt.which);
            console.log(val.value);
            if ((evt.which != 46 || val.value.indexOf('.') != -1) && (evt.which < 48 || evt.which > 57)) {
                //event it's fine
                return false;

            }
            var input = val.value;



            if ((input.indexOf('.') != -1) && (input.substring(input.indexOf('.')).length > 2)) {
                return false;
            }





        }
        function MoveToStockPopupOpen(Idsn) {

            $("#ctl00_cph_main_content_lblleftmoveqty").text('');
            $("#ctl00_cph_main_content_hdnmoveqty").val(0);
            $("#ctl00_cph_main_content_hdnBaseOrderDetailId").val(-1);
            $("#ctl00_cph_main_content_hdnAccessoryMasterId").val(-1);
            $("#ctl00_cph_main_content_hdnSize").val('');
            $("#ctl00_cph_main_content_hdnColorPrint").val('');
            $("#ctl00_cph_main_content_hdnSupplyType").val('');
            $("#ctl00_cph_main_content_hdnAccessoryWorkingDetailId").val(-1);
            $("#ctl00_cph_main_content_txtStockqty").val('');
            $("#ctl00_cph_main_content_txtDebitqty").val('');
            $("#ctl00_cph_main_content_txtParticular").val('');

            var QtyLeft = $("#<%= grdAccessory.ClientID %>_" + Idsn + "_hdnLeftQuantity").val();
            var OrderDetailId = $("#<%= grdAccessory.ClientID %>_" + Idsn + "_hdnOrderDetailId").val();
            var AccessoryMasterId = $("#<%= grdAccessory.ClientID %>_" + Idsn + "_hdnAccessoryMasterId").val();
            var Size = $("#<%= grdAccessory.ClientID %>_" + Idsn + "_hdnAccessSize").val();
            var ColorPrint = $("#<%= grdAccessory.ClientID %>_" + Idsn + "_lblColorPrint").text();
            var SupplyType = $("#<%= grdAccessory.ClientID %>_" + Idsn + "_hdnSupplyType").val();
            var AccessoryWorkingDetailId = $("#<%= grdAccessory.ClientID %>_" + Idsn + "_hdnAccessoryWorkingDetailId").val();

            QtyLeft = QtyLeft.replace(',', '')
            $("#ctl00_cph_main_content_lblleftmoveqty").text(numberWithCommas(QtyLeft));
            $("#ctl00_cph_main_content_hdnmoveqty").val(QtyLeft);
            $("#ctl00_cph_main_content_hdnBaseOrderDetailId").val(OrderDetailId);
            $("#ctl00_cph_main_content_hdnAccessoryMasterId").val(AccessoryMasterId);
            $("#ctl00_cph_main_content_hdnSize").val(Size);
            $("#ctl00_cph_main_content_hdnColorPrint").val(ColorPrint);
            $("#ctl00_cph_main_content_hdnSupplyType").val(SupplyType);
            $("#ctl00_cph_main_content_hdnAccessoryWorkingDetailId").val(AccessoryWorkingDetailId);

            $("#ctl00_cph_main_content_txtParticular").attr("disabled", "true");

            $("#ctl00_cph_main_content_divmovestock").show();
        }

        function ValidateStock() {

            var StockQty = $("#ctl00_cph_main_content_txtStockqty").val() == "" ? 0 : $("#ctl00_cph_main_content_txtStockqty").val();

            var DebitQty = $("#ctl00_cph_main_content_txtDebitqty").val() == "" ? 0 : $("#ctl00_cph_main_content_txtDebitqty").val();
            var Particular = $("#ctl00_cph_main_content_txtParticular").val();
            var lefQty = $("#ctl00_cph_main_content_lblleftmoveqty").val();

            if (StockQty == "") {
                StockQty = 0;
            }
            if (DebitQty == "") {
                DebitQty = 0;
            }
            var TotalQty = parseFloat(StockQty) + parseFloat(DebitQty);
            if (parseFloat(TotalQty) == 0) {
                alert('Please Enter Stock Qty or Debit Qty');
                return false;
            }
            if ((parseFloat(DebitQty) > 0) && (Particular == '')) {
                alert('Please Enter Particular for Debit Qty');
                return false;
            }
            if (parseFloat(DebitQty) + parseFloat(StockQty) != parseFloat(lefQty) && lefQty != "") {
                alert('Please Must Resolve Left Qty');
                return false;
            }
        }

        function GetAllChallan(OrderDetailId, AccessoryMasterId, Size, ColorPrint, LeftQty) {

            $('#here_table').html("");
            proxy.invoke("GetChallanDetailsByOrderDetailId", { OrderDetailId: OrderDetailId, AccessoryMasterId: AccessoryMasterId, Size: Size, ColorPrint: ColorPrint },
                function (result) {
                    closeChallanPopup();
                    if (result.length > 0) {
                        $('#here_table').append('<table cellspacing="0" border="0" class="ss qatableheader" cellpedding="0">');
                        $('#here_table').append("<tr><th colspan='3' style='background: #39589c;color:#f5f5f5;border-right:1px solid #39589c'>Challan History<span style='float:right;padding-right:10px;cursor: pointer;' titel='Close' onclick='HideSupplierDiv();'>X</span></th></tr>");
                        $('#here_table').append("<tr><th class='qaheader contactorderwidth'>Challan Number</th><th class='qaheader contactorderwidth'>Issued Qty. </th><th class='qaheader qtyupdatewidth'> Issued On </th></tr>")
                        for (var i = 0; i < result.length; i++) {
                            debugger;
                            $('#here_table').append("<tr><td class='textcenter'>" + "<a onclick='OpenChallan(" + OrderDetailId + ", " + AccessoryMasterId + ", " + "&apos;" + ColorPrint + "&apos;" + ", " + "&apos;" + Size + "&apos;" + ", " + result[i]["ChallanId"] + ", " + LeftQty + ")' style='color:blue;cursor:pointer' >" + result[i]["ChallanNumber"] + "</a>" + " </td><td class='textcenter'>" + numberWithCommas(result[i]["ChallanQty"]) + "</td><td class='textcenter'>" + result[i]["ChallanDateWithFormat"] + "</td></tr>");

                            $('#here_table').append('</table>');
                            if (result.length > 0) {
                                $("#here_table").show();
                                $(".backColorFade").addClass('abc');
                            }
                            else {
                                $('#here_table').html("");
                            }
                        }
                    }
                });

        }

        function CheckAllRequest(elem) {


            if ($(elem).is(':checked')) {
                $('.chkRow').find("input[type=checkbox]").attr('checked', 'checked');
                $('.chkRow').find("input[type=checkbox]").attr('disabled', 'disabled');
                $('.unitname').text($('#ctl00_cph_main_content_grdAccessory_ctl01_ddlFactoryUnit :selected').text());
                $('#ctl00_cph_main_content_grdAccessory_ctl01_ddlFactoryUnit').attr("disabled", "true");
            }
            else {
                // debugger; 
                $('.chkRow').find("input[type=checkbox]").attr('checked', false);
                $('#ctl00_cph_main_content_grdAccessory_ctl01_ddlFactoryUnit').attr("disabled", "");
            }

        }
        $("ctl00_cph_main_content_btnSubmit").click(function () {


            $('#ctl00_cph_main_content_grdAccessory_ctl01_ddlFactoryUnit').attr("disabled", "true");


        });



        function HideSupplierDiv() {
            $("#here_table").hide();
            $(".backColorFade").removeClass('abc');
        }
        function closeChallanPopup() {
            self.parent.Shadowbox.close();
        }
        function numberWithCommas(x) {
            return x.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",");
        }
        function PrintFunt() {
            window.print()
        }
    </script>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdateProgress runat="server" ID="uproTargetAdmin" AssociatedUpdatePanelID="UpdatePanel1"
        DisplayAfter="0">
        <ProgressTemplate>
            <img src="../../App_Themes/ikandi/images1/loading36.gif" alt="" style="position: fixed; z-index: 52111; top: 40%; left: 45%; width: 6%;" />
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="divMoveStockQty" runat="server" id="divmovestock" style="display: none; text-align: center;">
                <table cellpadding="2" cellspacing="0" style="width: 100%;">
                    <tr>
                        <th style='background: #39589c !important; font-weight: 500; font-size: 12px; width: 100%; padding: 2px 0px; text-align: center; color: #fff !important'>Move stock/debit quantity<span style='float: right; padding-right: 10px; cursor: pointer; color: #fff'
                            title='Close' onclick='HideDiv();'>X</span>
                        </th>
                    </tr>
                    <tr>
                        <td style="vertical-align: top; text-align: left; padding-left: 5px; width: 100%;">
                            <span style="color: Gray; display: inline-block; width: 79px">Left Quantity </span>
                            <asp:Label ID="lblleftmoveqty" runat="server"></asp:Label>
                            <asp:HiddenField ID="hdnmoveqty" runat="server" />
                            <asp:HiddenField ID="hdnBaseOrderDetailId" runat="server" />
                            <asp:HiddenField ID="hdnAccessoryWorkingDetailId" runat="server" />
                            <asp:HiddenField ID="hdnAccessoryMasterId" runat="server" />
                            <asp:HiddenField ID="hdnSize" runat="server" />
                            <asp:HiddenField ID="hdnColorPrint" runat="server" />
                            <asp:HiddenField ID="hdnSupplyType" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: left; padding-left: 5px; width: 100%;">
                            <span style="color: Gray; display: inline-block; width: 79px">Move to Stock </span>
                            <asp:TextBox ID="txtStockqty" autocomplete="off" onchange="OnchangeStockQty();" onkeypress="javascript:return isNumber(this,event)"
                                runat="server" Style="width: 100px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: left; padding-left: 5px; width: 100%;">
                            <span style="color: Gray; display: inline-block; width: 79px">Move to Debit </span>
                            <asp:TextBox ID="txtDebitqty" autocomplete="off" onchange="OnchangeStockQty();" onkeypress="javascript:return isNumber(this,event)"
                                runat="server" Style="width: 100px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: left; padding-left: 5px; width: 100%;">
                            <span style="color: Gray; vertical-align: top; display: inline-block; width: 79px">Particular:
                            </span>
                            <asp:TextBox ID="txtParticular" TextMode="MultiLine" autocomplete="off" runat="server"
                                Style="width: 168px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right; padding-right: 10px;">
                            <asp:Button ID="Submit" CssClass="btnMoveQty" runat="server" Text="Submit" OnClientClick="javascript:return ValidateStock()"
                                OnClick="MoveStockQty_Click" />
                        </td>
                    </tr>
                </table>
            </div>
            <div id="PopTableW" style="">
                <div class="headerSticky">
                    Internal Accessory Quality Issuing
                </div>
                <%--  <h2 style="width: 1252px; font-weight: 500; background: #3b5998;
            color: White; text-align: center; padding: 6px 0px; line-height: 11px; height: 12px;
            font-size: 14px;">
            Internal Accessory Quality Issuing</h2>--%>
            </div>
            <div id="dvSearch" runat="server" style="width: 100%; padding-top: 5px; height: 25px">
                <asp:TextBox ID="txtsearchkeyswords" Width="21%" class="search_1" placeholder="Search Accessory Quality/Style No/Serial No"
                    runat="server" autocomplete="off"></asp:TextBox>
                <asp:Button ID="btnSearch" runat="server" CssClass="btnbutton_Com do-not-disable"
                    Text="Search" Style="padding: 2px 7px;" OnClick="btnSearch_Click" />
            </div>
            <div style="position: relative; margin-bottom: 10px;" class="table_width">

                <asp:GridView ID="grdAccessory" CssClass="AddClass_Table" BorderWidth="0" runat="server"
                    CellPadding="0" ShowHeader="true" AutoGenerateColumns="false" Width="100%" OnRowDataBound="grdAccessory_RowDatabound"
                    OnDataBound="grdAccessory_DataBound">
                    <EmptyDataRowStyle CssClass="EmptyRow" />
                    <RowStyle CssClass="gvRow" />
                    <Columns>

                        <asp:TemplateField HeaderText="<div><span>Style No.</span></div>">
                            <ItemTemplate>
                                <div>
                                    <asp:Label ID="lblStyleNumber" Text='<%# Eval("StyleNumber") %>' runat="server"></asp:Label>
                                </div>
                            </ItemTemplate>
                            <ItemStyle CssClass="StyleContextup" />
                            <HeaderStyle Height="50" CssClass="headercontentSr borderThLeft" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="<div><span>Sr. No.</span></div>">
                            <ItemTemplate>
                                <div>
                                    <asp:Label ID="lblSerial" runat="server" Text='<%# Eval("SerialNumber") %>'></asp:Label>
                                </div>
                            </ItemTemplate>
                            <ItemStyle Width="20px" CssClass="SrNoContextup ProAccessWaTable" />
                            <HeaderStyle CssClass="headercontentSr" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="">
                            <HeaderTemplate>
                                <table style="width: 100%;" cellspacing="0" cellpadding="0" border="0">
                                    <tr>
                                        <td style="border-bottom: 1px solid #ddd7d7; border-top: 0px; border-right: 0px; border-left: 0px; color: #6b6464">Contract No.
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="border: 0px; color: #6b6464">Quantity
                                        </td>
                                    </tr>
                                </table>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                    <tr>
                                        <td style="border-bottom: 1px solid #9999; height: 18px; border-left: 0px; border-right: 0px; border-top: 0px">
                                            <div class="ContactNumberMax" data-maxlength="10">
                                                <asp:Label ID="lblContactNo" runat="server" Text='<%# Eval("ContractNumber") %>'></asp:Label>
                                                <asp:HiddenField ID="hdnContactNumber" runat="server" Value='<%# Eval("ContractNumber") %>' />
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="border: 0px; height: 18px; text-transform: none;">
                                            <asp:Label ID="lblQuantity" Text='<%# (Eval("ContractQty") == DBNull.Value  || (Eval("ContractQty").ToString().Trim() == string.Empty)) ? string.Empty : Convert.ToDecimal(Eval("ContractQty")).ToString("N0") %>'
                                                runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                            <ItemStyle Width="0" CssClass="ContactNoCol" />
                            <HeaderStyle CssClass="ContactNoCol" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Accessory Detail (Size)/Color Print</br>Average">
                            <ItemTemplate>
                                <asp:Label ID="lblAccessoriesDetail" runat="server" ForeColor="blue" Text='<%# Eval("TradName") %>'></asp:Label>
                                <asp:HiddenField ID="hdnAccessSize" Value='<%# Eval("Size") %>' runat="server" />
                                <asp:Label ID="lblSize" runat="server" ForeColor="gray" Text='<%# Eval("Size") %>'></asp:Label><span>/</span><asp:Label
                                    ID="lblColorPrint" ForeColor="black" Font-Bold="true" runat="server" Text='<%#Eval("Color_Print") %>'></asp:Label><span>/</span><asp:Label
                                        ID="lblAverage" ForeColor="black" Font-Bold="true" runat="server" Text='<%#Eval("AccessoryAvg") %>'></asp:Label>
                                <asp:HiddenField ID="hdnAccessoryWorkingDetailId" runat="server" Value='<%# Eval("AccessoryWorkingDetailId") %>' />
                                <asp:HiddenField ID="hdnOrderId" runat="server" Value='<%# Eval("OrderId") %>' />
                                <asp:HiddenField ID="hdnOrderDetailId" runat="server" Value='<%# Eval("OrderDetailId") %>' />
                                <asp:HiddenField ID="hdnAccessoryMasterId" runat="server" Value='<%# Eval("AccessoryMasterId") %>' />
                                <asp:HiddenField ID="hdnSupplyType" runat="server" Value='<%# Eval("SupplyType") %>' />
                            </ItemTemplate>
                            <ItemStyle />
                        </asp:TemplateField>

                        <asp:TemplateField>
                            <HeaderTemplate>
                                <table border="0" style="width: 100%; text-align: center;">
                                    <tr>
                                        <th style="border: 0px;">Actual Required<br />
                                            <span style="color: Gray; font-size: 9px;">Contract<span style="position: relative; top: 2px; font-size: 11px;"> * </span>Avg.</span>
                                        </th>
                                    </tr>
                                </table>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblTotalAccessoriesRequired" runat="server" Text='<%# Eval("totalRequired") %>'></asp:Label>
                                <asp:Label ID="Unit1" ForeColor="Gray" Font-Bold="true" runat="server" Text='<%# " " + Eval("GarmentUnitName") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="left" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Available Qty. To Issue">
                            <ItemTemplate>
                                <asp:Label ID="lblAvailableQtyToIssue" runat="server" Text='<%# Eval("AvailableQtyToIssued") %>'></asp:Label>
                                <asp:Label ID="Unit2" ForeColor="Gray" Font-Bold="true" runat="server" Text='<%# " " + Eval("GarmentUnitName") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="left" Width="70" />
                        </asp:TemplateField>

                        <asp:TemplateField>
                            <HeaderTemplate>
                                <table style="width: 100%;">
                                    <tr>
                                        <th style="border: 0px; text-align: left; width: 33.33%">Raise Request
                                        </th>
                                        <th style="border: 0px; text-align: center; width: 33.33%">Date
                                        </th>
                                        <th style="border: 0px; text-align: left; width: 33.33%">Unit
                                        </th>
                                    </tr>
                                    <tr>
                                        <td style="border: 0px; color: gray; text-align: left;">
                                            <asp:CheckBox ID="chkRaiseReuestAll" CssClass="chkHeader" OnClick="javascript:CheckAllRequest(this)"
                                                Enabled="false" runat="server" />
                                        </td>

                                        <td colspan="2" style="border: 0px; color: gray;">
                                            <asp:DropDownList ID="ddlFactoryUnit" runat="server" DataTextField="name" DataValueField="id"
                                                Style="width: 80%;">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                </table>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                                    <tr>
                                        <td style="border: 0px">
                                            <asp:CheckBox ID="cbIssueRequest" CssClass="chkRow" runat="server" Enabled="false" />
                                        </td>
                                        <td style="border: 0px; text-align: center;">
                                            <asp:HiddenField ID="hdnIssueRequest" runat="server" Value='<%# Eval("IsIssueRequest") %>' />
                                            <asp:Label ID="lblRequestDate" runat="server" Text=""></asp:Label>
                                        </td>
                                        <td style="border: 0px">
                                            <asp:Label ID="lblUnitName" runat="server" CssClass="unitname"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                            <ItemStyle Width="230" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Required Qty.</br>(Include Wastage)">
                            <ItemTemplate>
                                <div class="AccessToltip">
                                    <asp:Label ID="lblRequiredQty" runat="server" Text='<%# Eval("RequiredQty").ToString() == "0.000"? "" : Eval("RequiredQty").ToString() %>'></asp:Label>
                                    <asp:Label ID="Unit3" ForeColor="Gray" Font-Bold="true" runat="server" Text='<%# " " + Eval("GarmentUnitName") %>'></asp:Label>
                                    <asp:Label ID="lblTooltip" runat="server" Text=""></asp:Label>
                                </div>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="left" Width="90" />
                        </asp:TemplateField>

                        <asp:TemplateField>
                            <HeaderTemplate>
                                <table style="width: 100%; height: 100%;">
                                    <tr>
                                        <%-- <th style="text-align:left;border:0;">
                                            <span>Create</span><br />
                                            <span style="margin:5px;display:inline-block;">
                                                <asp:Image ID="imgEdit" Style="cursor: pointer;" src="../../images/edit.png" runat="server" />
                                                <asp:HiddenField runat="server" ID="hdnCanMakeNewChallan" Value='<%# Eval("CanMakeNewChallan") %>'/>
                                            </span>
                                        </th>--%>
                                        <th colspan="4" style="border: 0px;">Challan
                                        </th>
                                    </tr>
                                    <tr>
                                        <td style="border: 0px; color: gray; width: 25%; text-align: center;">Challan No.
                                        </td>
                                        <td style="border: 0px; color: gray; width: 25%; text-align: center;">Challan Date
                                        </td>
                                        <td style="border: 0px; color: gray; width: 50%; text-align: right;">Overall Issued
                                        </td>
                                    </tr>
                                </table>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                                    <tr>
                                        <td style="border: none; padding-right: 0; padding-left: 0;">
                                            <table style="width: 100%; text-align: right;">

                                                <tr>
                                                    <td style="display: flex; justify-content: center; border: 0; text-align: center; position: sticky; top: 67px; padding: 2px; padding-right: 15%; border-bottom: 1px solid lightgray;">
                                                        <asp:Label ID="imgEdit" CssClass="create_challan_link" runat="server" Text="Create Challan" Style="cursor: pointer; color: blue; font-weight: 600;" Visible="false"></asp:Label>
                                                        <asp:HiddenField runat="server" ID="hdnCanMakeNewChallan" Value='<%# Eval("CanMakeNewChallan") %>' />
                                                    </td>

                                                </tr>
                                                <asp:Repeater ID="rpt1" runat="server" OnItemDataBound="rpt1_ItemDataBound">
                                                    <ItemTemplate>
                                                        <tr class="margin-top" style="display: flex; padding-top: 3px; padding-bottom: 2px; border-bottom: 1px solid #dbd8d8;">

                                                            <td style="border: none; color: blue; font-size: 10px; width: 25%; text-align: center;">
                                                                <span runat="server" id="tdChallanNumber"><%# Eval("ChallanNumber")%></span>
                                                            </td>
                                                            <td style="border: none; color: Black; font-size: 10px; width: 25%; text-align: center;" runat="server" id="tdChallanDate"><%# Convert.ToDateTime(Eval("ChallanDate")).ToString("dd MMM")%></td>
                                                            <td style="border: none; color: Black; font-size: 10px; width: 50%; text-align: right;" runat="server" id="tdIssuedQty"><%# Eval("IssuedQty")%></td>

                                                            <asp:HiddenField runat="server" ID="hdnflagOption" Value='<%# Eval("SignatureStatus")%> ' />
                                                            <asp:HiddenField runat="server" ID="hdnSerialNumber" Value='<%# Eval("SerialNumber")%> ' />
                                                            <asp:HiddenField runat="server" ID="hdnColor" Value='<%# Eval("Color")%> ' />

                                                        </tr>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </table>
                                        </td>
                                    </tr>
                                </table>

                                <%--  <table style="width: 100%; height: 100%; display: none;" class="innertable">
                                    <tr>
                                        <td style="border: 0px;">
                                            <asp:Image ID="imgEdit" Style="position: relative; top: -2px; cursor: pointer; display: none;"
                                                src="../../images/edit.png" runat="server" />
                                        </td>
                                        <td style="border: 0px;" class="process">
                                            <asp:Image ID="imgView" Style="width: 19px; cursor: pointer; display: none;" src="../../images/viewicon.png"
                                                runat="server" />
                                        </td>
                                    </tr>
                                </table>--%>
                            </ItemTemplate>
                            <ItemStyle VerticalAlign="Top" CssClass="challanCol" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText=" Total Issued">
                            <ItemTemplate>
                                <div>
                                    <asp:Label ID="lblTotalIssued" Text='<%# (Convert.ToDecimal(Eval("TotalSendChallanQty")) == 0) ? "" : Convert.ToDecimal(Eval("TotalSendChallanQty")).ToString("#,#.##")%>'
                                        runat="server"></asp:Label>

                                    <asp:Label ID="lblReturnedQty" Text='<%# (Convert.ToDecimal(Eval("ReturnedQty")) == 0) ? "" : Convert.ToDecimal(Eval("ReturnedQty")).ToString("#,#.##")%>'
                                        runat="server"></asp:Label>
                                </div>
                                <div style="vertical-align: text-bottom;">
                                    <asp:Label ID="lblStock_DebitQty" ForeColor="Gray" Font-Size="9px" runat="server"
                                        Text=""></asp:Label>
                                </div>
                            </ItemTemplate>
                            <ItemStyle Width="150" HorizontalAlign="right" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Issue <br>Complete">
                            <ItemTemplate>
                                <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                                    <tr>
                                        <td style="border: 0px">
                                            <asp:CheckBox ID="cbIssueComplete" runat="server" Enabled="false" onchange="UpdateCompleteIssueReq(this)" />
                                        </td>
                                        <td style="border: 0px; text-align: center;">
                                            <asp:Label ID="lblIssueCompleteDate" runat="server" Style="position: relative;" Text=""></asp:Label>
                                            <asp:HiddenField ID="hdnIssueComplete" runat="server" Value='<%# Eval("IsCompleteIssue") %>' />
                                            <asp:HiddenField ID="hdnLeftQuantity" runat="server" Value='<%# Eval("LeftQuantity") %>' />
                                        </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                            <ItemStyle />
                        </asp:TemplateField>

                    </Columns>

                    <EmptyDataTemplate>
                        <table class="AddClass_Table" cellpadding="0" cellspacing="0" style="width: 100%;">
                            <tr>
                                <th>
                                    <div>
                                        <span>Style No.</span>
                                    </div>
                                </th>
                                <th>
                                    <div>
                                        <span>Sr. No.</span>
                                    </div>
                                </th>
                                <th>Contract No.
                                    <br />
                                    Quantity
                                </th>
                                <th>Accessory Detail (Size)/Color Print<br></br>
                                    /Average
                                </th>
                                <th>Actual Accessory Required
                                </th>
                                <th>Available Qty. To Issue
                                </th>
                                <th>Raise Accessory Request Date
                                </th>
                                <th>Required Qty.<br></br>
                                    (With Wastage)
                                </th>
                                <th>
                                    <table style="width: 100%; height: 100%;" class="innertable">
                                        <tr>
                                            <th style="border: 0px; border-right: 1px solid #999; color: #6b6464">Challan No.
                                            </th>
                                            <th style="border: 0px; color: #6b6464">Total Issued
                                            </th>
                                        </tr>
                                    </table>
                                </th>
                                <th>Add New Challan
                                </th>
                                <th>Issue Complete
                                </th>
                            </tr>
                            <tr>
                                <td colspan="12" style="text-align: center">
                                    <img src="../../images/sorry.png" />
                                    <div style="text-align: center; padding: 10px;">
                                        <asp:Label ID="lblEmptyMsg" Font-Size="12px" ForeColor="Red" runat="server" Text=""></asp:Label>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </EmptyDataTemplate>

                </asp:GridView>



                <asp:HiddenField ID="ChdnIssueRequest" Value="0" runat="server" />
            </div>
            <div style="padding-bottom: 50px; display: flex;">
                <span style="float: left">
                    <asp:Button ID="btnSubmit" runat="server" Style="margin-right: 5px;" CssClass="btnbutton_Com printHideButton"
                        Text="Submit" OnClick="btnSubmit_Click" />
                </span>
                <asp:Button ID="btnPrint" runat="server" CssClass="btnPrint printHideButton" Style="margin-left: 0px;"
                    Text="Print" OnClientClick="PrintFunt()" />
            </div>
            <div class="backColorFade">
                <div id="here_table" class="clsChallan_Table">
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
