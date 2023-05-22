<%@ Page Title="" Language="C#" MasterPageFile="~/layout/Secure.Master" AutoEventWireup="true"
    CodeBehind="FabricViewAll.aspx.cs" Inherits="iKandi.Web.Internal.Fabric.FabricViewAll" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_head" runat="server">
    <script src="../../js/jquery-1.11.0.min.js" type="text/javascript"></script>
    <script src="../../js/jqueryui-1.9.1-jquery-ui.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="../../js/service.min.js"></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("../../js/jquery.autocomplete.js")%>'></script>
    <script type="text/javascript" src="../../js/jquery-1.5.2-jquery.min.js"></script>
    <script type="text/javascript" src="../../js/combined_jquery_scripts4.js"></script>
    <script type="text/javascript" src="../../js/form.js"></script>
    <link rel="stylesheet" type="text/css" href="../../css/jquery-combined.css" />
    <link href="../../css/TopHeaderFixed.css" rel="stylesheet" type="text/css" />
    <link href="../../css/FabricView.css" rel="stylesheet" type="text/css" />
    <style type="text/css">      
        .displayBlock
        {
            display: block;
        }
        .displayNone
        {
            display: none;
        }
        #sb-wrapper
        {
            left: 50% !important;
            top: 50% !important;
            transform: translate(-50%, -50%) !important;
        }
        
        .HeaderClass td:first-child
        {
            padding: 0px !important;
            box-sizing: border-box;
        }
        /* added by Girish  For Sorting Radion Button */
        .SortingRadioButton tr
        {
            display: flex;
        }
        .SortingRadioButton tr td
        {
            border: none;
            display: flex;
            align-items: center;
            justify-content: center;
        }
        .SortingRadioButton tr td input
        {
            margin-top: -3px;
        }
        .SortingRadioButton tr td label
        {
            margin-top: -3px;
        }
        .SortingRadioButton tr td:first-child input::before
        {
            content: "Sort By -";
            position: absolute;
            left: -50px;
            top: 0px;
            background-color: white;
            height: 28px;
            line-height: 28px;
            font-size: 11px;
        }
        
        .clearfix
        {
            clear: both;
        }
        
        @media screen and (min-width:1760px)
        {
            .SearchBoxDiv
            {
                width: 25%;
            }
            .abc.tab
            {
                width: 70%;
            }
        }
        
        .ac_results{width:130px!important;}
    </style>
    <script type="text/javascript">

        function SpinnShow() {
            $("#spinnL").css("display", "block");
            $('body').scrollTop($('body')[0].scrollHeight);
        }

        function PermissionAlertMsg() {
            alert("You don't have permission");
        }

        $(function () {



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



            Fabtype = $("#ctl00_cph_main_content_hdnFabtype").val();
            if (Fabtype != "") {

                // ShowHideSuppliergrd('<%=Session["CallBackTab"] %>');
            }


            $("#ctl00_cph_main_content_grdEMBELLISHMENT tr,#ctl00_cph_main_content_grdRFD tr,#ctl00_cph_main_content_grdGRIEGE tr,#ctl00_cph_main_content_grdFINISHED tr,#ctl00_cph_main_content_grdDYED tr ,#ctl00_cph_main_content_grdEMBROIDERY tr").click(function () {
                $('#ctl00_cph_main_content_grdRFD  > tbody > tr').not(':first').find('td').css("background-color", "#FFFFFF");
                $('#ctl00_cph_main_content_grdGRIEGE  > tbody > tr').not(':first').find('td').css("background-color", "#FFFFFF");
                $('#ctl00_cph_main_content_grdEMBELLISHMENT  > tbody > tr').not(':first').find('td').css("background-color", "#FFFFFF");
                $('#ctl00_cph_main_content_grdFINISHED  > tbody > tr').not(':first').find('td').css("background-color", "#FFFFFF");
                $('#ctl00_cph_main_content_grdDYED  > tbody > tr').not(':first').find('td').css("background-color", "#FFFFFF");
                $('#ctl00_cph_main_content_grdEMBROIDERY  > tbody > tr').not(':first').find('td').css("background-color", "#FFFFFF");
                if ($(this).hasClass("HeaderClass") == false) {
                    $(this).find('td').css("background-color", "");
                }
            })
        });

        function SaveGreigeDetails() {

            $(".classfabsave").each(function () {
                var id = $(this).attr('id');
                //                alert($(this).val());
                var Idsn = id.split("_")[5];


                FabQualityID = $("#<%= grdGRIEGE.ClientID %>_" + Idsn[0] + "_hdnfabricQuality").val();
                GreigedShrinkage = $("#<%= grdGRIEGE.ClientID %>_" + Idsn[0] + "_txtGreigedShrinkage").val();
                QtyToOrder = $("#<%= grdGRIEGE.ClientID %>_" + Idsn[0] + "_lblfabricorderavg").val();
                PendingQtyToOrder = $("#<%= grdGRIEGE.ClientID %>_" + Idsn[0] + "_lblFabQtyRemaning").val();
                UserID = '<%=this.Userid %>';

                if (GreigedShrinkage == "") {
                    GreigedShrinkage = 0;
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
                    data: "{ Flag:'" + 'GRIEGE' + "', FlagOption:'" + 'UPDATE' + "', GreigedShrinkage:'" + GreigedShrinkage + "',QtyToOrder:'" + QtyToOrder + "',UserID:'" + UserID + "', PendingQtyToOrder:'" + PendingQtyToOrder + "', FabricQualityID:'" + FabQualityID + "'}",
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
                    data: "{ Flag:'" + 'FINISHED' + "', FlagOption:'" + 'UPDATEFINISH' + "', GreigedShrinkage:'" + Selectedval + "',FabricQualityID:'" + fabQtyID + "',Isresidualshrnkpplyongerige:'" + 0 + "'}",
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


        function ShowpurchasedSupplierForm(id, FabQualityID, SupplierMasterID, MasterPoID, colorprintdetail, gerige, residual, cutwastage, Stage1, stage2, stage3, stage4) {
            //    alert("test");

            HideSupplierDiv();
            var Idsn = id.split("_");

            //  alert(gerige);
            var urls = window.location.href.replace('#', '');
            residual = residual;
            // gerige = 0;
            var Idsn = id.split("_");

            var currentstage = 0;
            var previousstage = 0;
            var isStyleSpecific = 0;
            var styleid = 0;
            var Vals = "";

            Fabtype = $("#ctl00_cph_main_content_hdnFabtype").val();

            if (Fabtype == 'GRIEGE') {
                gerige = document.getElementById('ctl00_cph_main_content_grdGRIEGE_' + Idsn[5] + '_hdnmaxgrige').value.replace(',', '');
                residual = 0;
                // alert(document.getElementById('ctl00_cph_main_content_grdGRIEGE_' + Idsn[5] + '_lblSerialNumber'));
                // var serialNumber=  document.getElementById('ctl00_cph_main_content_grdGRIEGE_' + Idsn[5] + '_lblSerialNumber').value
            }
            else if (Fabtype == 'FINISHED') {
                gerige = 0;
                residual = document.getElementById('ctl00_cph_main_content_grdFINISHED_' + Idsn[5] + '_hdnResidualShrinkage').value.replace(',', '');
                //                var serialNumber = document.getElementById('ctl00_cph_main_content_grdFINISHED_' + Idsn[5] + '_lblSerialNumber').value;
            }
            else if (Fabtype == 'PRINT') {
                currentstage = document.getElementById('ctl00_cph_main_content_grdPRINT_' + Idsn[5] + '_hdnCurrentstage').value.replace(',', '');
                previousstage = document.getElementById('ctl00_cph_main_content_grdPRINT_' + Idsn[5] + '_hdnperiviousstgae').value.replace(',', '');
                //                var serialNumber = document.getElementById('ctl00_cph_main_content_grdPRINT_' + Idsn[5] + '_lblSerialNumber').value;
                Vals = document.getElementById('ctl00_cph_main_content_grdPRINT_' + Idsn[5] + '_hdnIsStyleSpecific').value.replace(',', '');
                if (Vals == 'True') {
                    isStyleSpecific = 1;
                }
                styleid = document.getElementById('ctl00_cph_main_content_grdPRINT_' + Idsn[5] + '_hdnStyleID').value.replace(',', '');
            }
            else if (Fabtype == 'DYED') {
                currentstage = document.getElementById('ctl00_cph_main_content_grdDYED_' + Idsn[5] + '_hdnCurrentstage').value.replace(',', '');
                previousstage = document.getElementById('ctl00_cph_main_content_grdDYED_' + Idsn[5] + '_hdnperiviousstgae').value.replace(',', '');
                Vals = document.getElementById('ctl00_cph_main_content_grdDYED_' + Idsn[5] + '_hdnIsStyleSpecific').value.replace(',', '');
                //                var serialNumber = document.getElementById('ctl00_cph_main_content_grdDYED_' + Idsn[5] + '_lblSerialNumber').value;
                if (Vals == 'True') {
                    isStyleSpecific = 1;
                }
                styleid = document.getElementById('ctl00_cph_main_content_grdDYED_' + Idsn[5] + '_hdnStyleID').value.replace(',', '');
            }
            else if (Fabtype == 'RFD') {
                currentstage = document.getElementById('ctl00_cph_main_content_grdRFD_' + Idsn[5] + '_hdnCurrentstage').value.replace(',', '');
                previousstage = document.getElementById('ctl00_cph_main_content_grdRFD_' + Idsn[5] + '_hdnperiviousstgae').value.replace(',', '');
                Vals = document.getElementById('ctl00_cph_main_content_grdRFD_' + Idsn[5] + '_hdnIsStyleSpecific').value.replace(',', '');
                //                var serialNumber = document.getElementById('ctl00_cph_main_content_grdRFD_' + Idsn[5] + '_lblSerialNumber').value;
                if (Vals == 'True') {
                    isStyleSpecific = 1;
                }
                styleid = document.getElementById('ctl00_cph_main_content_grdRFD_' + Idsn[5] + '_hdnStyleID').value.replace(',', '');
            }
            else if (Fabtype == 'EMBELLISHMENT') {
                currentstage = document.getElementById('ctl00_cph_main_content_grdEMBELLISHMENT_' + Idsn[5] + '_hdnCurrentstage').value.replace(',', '');
                previousstage = document.getElementById('ctl00_cph_main_content_grdEMBELLISHMENT_' + Idsn[5] + '_hdnperiviousstgae').value.replace(',', '');
                Vals = document.getElementById('ctl00_cph_main_content_grdEMBELLISHMENT_' + Idsn[5] + '_hdnIsStyleSpecific').value.replace(',', '');
                //                var serialNumber = document.getElementById('ctl00_cph_main_content_grdEMBELLISHMENT_' + Idsn[5] + '_lblSerialNumber').value;
                if (Vals == 'True') {
                    isStyleSpecific = 1;
                }
                styleid = document.getElementById('ctl00_cph_main_content_grdEMBELLISHMENT_' + Idsn[5] + '_hdnStyleID').value.replace(',', '');
            }
            else if (Fabtype == 'EMBROIDERY') {
                currentstage = document.getElementById('ctl00_cph_main_content_grdEMBROIDERY_' + Idsn[5] + '_hdnCurrentstage').value.replace(',', '');
                previousstage = document.getElementById('ctl00_cph_main_content_grdEMBROIDERY_' + Idsn[5] + '_hdnperiviousstgae').value.replace(',', '');
                Vals = document.getElementById('ctl00_cph_main_content_grdEMBROIDERY_' + Idsn[5] + '_hdnIsStyleSpecific').value.replace(',', '');
                //                var serialNumber = document.getElementById('ctl00_cph_main_content_grdEMBROIDERY_' + Idsn[5] + '_lblSerialNumber').value;
                if (Vals == 'True') {
                    isStyleSpecific = 1;
                }
                styleid = document.getElementById('ctl00_cph_main_content_grdEMBROIDERY_' + Idsn[5] + '_hdnStyleID').value.replace(',', '');
            }
            var sURL = 'FabricPurChasedForm.aspx?FabricQualityID=' + FabQualityID + "&Fabtype=" + Fabtype + "&Potype=" + 'RAISE' + "&ParentPageUrlWithQuerystring=" + urls + "&MasterPoID=" + MasterPoID + "&colorprintdetail=" + colorprintdetail + "&gerige=" + gerige + "&residual=" + residual + "&cutwastage=" + cutwastage + "&currentstage=" + currentstage + "&previousstage=" + previousstage + "&isStyleSpecific=" + isStyleSpecific + "&styleid=" + styleid + "&stage1=" + Stage1 + "&stage2=" + stage2 + "&stage3=" + stage3 + "&stage4=" + stage4;
            // window.open(sURL);     
            Shadowbox.init({ animate: true, animateFade: true, modal: true });

            Shadowbox.open({ content: sURL, type: "iframe", player: "iframe", title: "", height: 900, width: 1500, modal: true, animate: true, oversized: true, animateFade: true, options: { onClose: SBClose} });
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
            //alert(gerige);
            Fabtype = $("#ctl00_cph_main_content_hdnFabtype").val();
            //            alert(Fabtype);

            if (Fabtype == 'GRIEGE') {
                Fabtype = 'GRIEGE';
                //                var serialNumber = document.getElementById('ctl00_cph_main_content_grdGRIEGE_' + Idsn[5] + '_lblSerialNumber').value;
            }
            else if (Fabtype == 'PRINT') {
                currentstage = document.getElementById('ctl00_cph_main_content_grdPRINT_' + Idsn[5] + '_hdnCurrentstage').value.replace(',', '');
                previousstage = document.getElementById('ctl00_cph_main_content_grdPRINT_' + Idsn[5] + '_hdnperiviousstgae').value.replace(',', '');
                Vals = document.getElementById('ctl00_cph_main_content_grdPRINT_' + Idsn[5] + '_hdnIsStyleSpecific').value.replace(',', '');
                //                var serialNumber = document.getElementById('ctl00_cph_main_content_grdPRINT_' + Idsn[5] + '_lblSerialNumber').value
                if (Vals == 'True') {
                    isStyleSpecific = 1;
                }
                styleid = document.getElementById('ctl00_cph_main_content_grdPRINT_' + Idsn[5] + '_hdnStyleID').value.replace(',', '');
            }
            else if (Fabtype == 'DYED') {
                currentstage = document.getElementById('ctl00_cph_main_content_grdDYED_' + Idsn[5] + '_hdnCurrentstage').value.replace(',', '');
                previousstage = document.getElementById('ctl00_cph_main_content_grdDYED_' + Idsn[5] + '_hdnperiviousstgae').value.replace(',', '');
                Vals = document.getElementById('ctl00_cph_main_content_grdDYED_' + Idsn[5] + '_hdnIsStyleSpecific').value.replace(',', '');
                //                var serialNumber = document.getElementById('ctl00_cph_main_content_grdDYED_' + Idsn[5] + '_lblSerialNumber').value;
                if (Vals == 'True') {
                    isStyleSpecific = 1;
                }
                styleid = document.getElementById('ctl00_cph_main_content_grdDYED_' + Idsn[5] + '_hdnStyleID').value.replace(',', '');
            }
            else if (Fabtype == 'RFD') {
                currentstage = document.getElementById('ctl00_cph_main_content_grdRFD_' + Idsn[5] + '_hdnCurrentstage').value.replace(',', '');
                previousstage = document.getElementById('ctl00_cph_main_content_grdRFD_' + Idsn[5] + '_hdnperiviousstgae').value.replace(',', '');
                Vals = document.getElementById('ctl00_cph_main_content_grdRFD_' + Idsn[5] + '_hdnIsStyleSpecific').value.replace(',', '');
                //                var serialNumber = document.getElementById('ctl00_cph_main_content_grdRFD_' + Idsn[5] + '_lblSerialNumber').value;
                if (Vals == 'True') {
                    isStyleSpecific = 1;
                }
                styleid = document.getElementById('ctl00_cph_main_content_grdRFD_' + Idsn[5] + '_hdnStyleID').value.replace(',', '');

            }
            else if (Fabtype == 'EMBELLISHMENT') {
                currentstage = document.getElementById('ctl00_cph_main_content_grdEMBELLISHMENT_' + Idsn[5] + '_hdnCurrentstage').value.replace(',', '');
                previousstage = document.getElementById('ctl00_cph_main_content_grdEMBELLISHMENT_' + Idsn[5] + '_hdnperiviousstgae').value.replace(',', '');
                Vals = document.getElementById('ctl00_cph_main_content_grdEMBELLISHMENT_' + Idsn[5] + '_hdnIsStyleSpecific').value.replace(',', '');
                //                var serialNumber = document.getElementById('ctl00_cph_main_content_grdEMBELLISHMENT_' + Idsn[5] + '_lblSerialNumber').value;
                if (Vals == 'True') {
                    isStyleSpecific = 1;
                }
                styleid = document.getElementById('ctl00_cph_main_content_grdEMBELLISHMENT_' + Idsn[5] + '_hdnStyleID').value.replace(',', '');
            }
            else if (Fabtype == 'EMBROIDERY') {
                currentstage = document.getElementById('ctl00_cph_main_content_grdEMBROIDERY_' + Idsn[5] + '_hdnCurrentstage').value.replace(',', '');
                previousstage = document.getElementById('ctl00_cph_main_content_grdEMBROIDERY_' + Idsn[5] + '_hdnperiviousstgae').value.replace(',', '');
                Vals = document.getElementById('ctl00_cph_main_content_grdEMBROIDERY_' + Idsn[5] + '_hdnIsStyleSpecific').value.replace(',', '');
                //                var serialNumber = document.getElementById('ctl00_cph_main_content_grdEMBROIDERY_' + Idsn[5] + '_lblSerialNumber').value
                if (Vals == 'True') {
                    isStyleSpecific = 1;
                }
                styleid = document.getElementById('ctl00_cph_main_content_grdEMBROIDERY_' + Idsn[5] + '_hdnStyleID').value.replace(',', '');
            }
            var sURL = 'FabricPurChasedForm.aspx?FabricQualityID=' + FabQualityID + "&Fabtype=" + Fabtype + "&Potype=" + 'RERAISE' + "&ParentPageUrlWithQuerystring=" + urls + "&MasterPoID=" + MasterPoID + "&colorprintdetail=" + elem + "&gerige=" + gerige + "&residual=" + residual + "&cutwastage=" + cutwastage + "&currentstage=" + currentstage + "&previousstage=" + previousstage + "&isStyleSpecific=" + isStyleSpecific + "&styleid=" + styleid + "&stage1=" + Stage1 + "&stage2=" + stage2 + "&stage3=" + stage3 + "&stage4=" + stage4;

            Shadowbox.init({ animate: true, animateFade: true, modal: true });
            Shadowbox.open({ content: sURL, type: "iframe", player: "iframe", title: "", height: 700, width: 1200, modal: true, animate: true, oversized: true, animateFade: true, options: { onClose: SBClose} });
            $('#sb-wrapper').addClass("PurchaseOrder");

            return false;
        }
        function SBClose() { }

        function CallThisPage(Po_number, SupplierNasterID, IsMailSend, hdnSessionQ, SupplyType) {

            var Podetails = Po_number + "," + SupplierNasterID + "," + IsMailSend + "," + hdnSessionQ;
            var oldTradeName = getUrlParameter("TradeName", window.location.href);
            var url = new URL(window.location.protocol + '//' + window.location.host + window.location.pathname);
            url.searchParams.set('Po_number', Po_number);
            url.searchParams.set('SupplierNasterID', SupplierNasterID);
            url.searchParams.set('IsMailSend', IsMailSend);

            if (oldTradeName != null && oldTradeName != undefined && oldTradeName != "") {
                var treadename = ((oldTradeName.split('+').join(' ')).split('%2B').join(' ')).split('%20').join(' ');
                url.searchParams.set('TradeName', treadename);
            }
            url.searchParams.set('SupplyType', SupplyType);
            // url.searchParams.set('FabType', getUrlParameter("Fabtype", hdnSessionQ));          
            window.location.replace(url.href);
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

                fabqty = document.getElementById('ctl00_cph_main_content_grdGRIEGE_' + Idsn[5] + '_lblFabricQuality').innerText.replace(',', '');
                fabricdetails = "";
                gsm = document.getElementById('ctl00_cph_main_content_grdGRIEGE_' + Idsn[5] + '_lblgsm').innerText.replace(',', '');
                cc = document.getElementById('ctl00_cph_main_content_grdGRIEGE_' + Idsn[5] + '_lblcountconstraction').innerText.replace(',', '');
                width = document.getElementById('ctl00_cph_main_content_grdGRIEGE_' + Idsn[5] + '_lblwidth').innerText.replace(',', '');

            }
            else if (Fabtype == 'FINISHED') {

                fabqty = document.getElementById('ctl00_cph_main_content_grdFINISHED_' + Idsn[5] + '_lblFabricQuality').innerText.replace(',', '');
                fabricdetails = document.getElementById('ctl00_cph_main_content_grdFINISHED_' + Idsn[5] + '_lblfabriccolor').innerText.replace(',', '');
                gsm = document.getElementById('ctl00_cph_main_content_grdFINISHED_' + Idsn[5] + '_lblgsm').innerText.replace(',', '');
                cc = document.getElementById('ctl00_cph_main_content_grdFINISHED_' + Idsn[5] + '_lblcountconstraction').innerText.replace(',', '');
                width = document.getElementById('ctl00_cph_main_content_grdFINISHED_' + Idsn[5] + '_lblwidth').innerText.replace(',', '');


            }
            else if (Fabtype == 'PRINT') {
                currentstage = document.getElementById('ctl00_cph_main_content_grdPRINT_' + Idsn[5] + '_hdnCurrentstage').value.replace(',', '');
                previousstage = document.getElementById('ctl00_cph_main_content_grdPRINT_' + Idsn[5] + '_hdnperiviousstgae').value.replace(',', '');
                Vals = document.getElementById('ctl00_cph_main_content_grdPRINT_' + Idsn[5] + '_hdnIsStyleSpecific').value.replace(',', '');

                fabqty = document.getElementById('ctl00_cph_main_content_grdPRINT_' + Idsn[5] + '_lblFabricQuality').innerText.replace(',', '');
                fabricdetails = document.getElementById('ctl00_cph_main_content_grdPRINT_' + Idsn[5] + '_lblfabriccolor').innerText.replace(',', '');
                gsm = document.getElementById('ctl00_cph_main_content_grdPRINT_' + Idsn[5] + '_lblgsm').innerText.replace(',', '');
                cc = document.getElementById('ctl00_cph_main_content_grdPRINT_' + Idsn[5] + '_lblcountconstraction').innerText.replace(',', '');
                width = document.getElementById('ctl00_cph_main_content_grdPRINT_' + Idsn[5] + '_lblwidth').innerText.replace(',', '');

                if (Vals == 'True') {
                    isStyleSpecific = 1;
                }
                styleid = document.getElementById('ctl00_cph_main_content_grdPRINT_' + Idsn[5] + '_hdnStyleID').value.replace(',', '');
            }
            else if (Fabtype == 'DYED') {
                currentstage = document.getElementById('ctl00_cph_main_content_grdDYED_' + Idsn[5] + '_hdnCurrentstage').value.replace(',', '');
                previousstage = document.getElementById('ctl00_cph_main_content_grdDYED_' + Idsn[5] + '_hdnperiviousstgae').value.replace(',', '');
                Vals = document.getElementById('ctl00_cph_main_content_grdDYED_' + Idsn[5] + '_hdnIsStyleSpecific').value.replace(',', '');

                fabqty = document.getElementById('ctl00_cph_main_content_grdDYED_' + Idsn[5] + '_lblFabricQuality').innerText.replace(',', '');
                fabricdetails = document.getElementById('ctl00_cph_main_content_grdDYED_' + Idsn[5] + '_lblfabriccolor').innerText.replace(',', '');
                gsm = document.getElementById('ctl00_cph_main_content_grdDYED_' + Idsn[5] + '_lblgsm').innerText.replace(',', '');
                cc = document.getElementById('ctl00_cph_main_content_grdDYED_' + Idsn[5] + '_lblcountconstraction').innerText.replace(',', '');
                width = document.getElementById('ctl00_cph_main_content_grdDYED_' + Idsn[5] + '_lblwidth').innerText.replace(',', '');


                if (Vals == 'True') {
                    isStyleSpecific = 1;
                }
                styleid = document.getElementById('ctl00_cph_main_content_grdDYED_' + Idsn[5] + '_hdnStyleID').value.replace(',', '');
            }
            else if (Fabtype == 'RFD') {
                currentstage = document.getElementById('ctl00_cph_main_content_grdRFD_' + Idsn[5] + '_hdnCurrentstage').value.replace(',', '');
                previousstage = document.getElementById('ctl00_cph_main_content_grdRFD_' + Idsn[5] + '_hdnperiviousstgae').value.replace(',', '');
                Vals = document.getElementById('ctl00_cph_main_content_grdRFD_' + Idsn[5] + '_hdnIsStyleSpecific').value.replace(',', '');


                fabqty = document.getElementById('ctl00_cph_main_content_grdRFD_' + Idsn[5] + '_lblFabricQuality').innerText.replace(',', '');
                fabricdetails = document.getElementById('ctl00_cph_main_content_grdRFD_' + Idsn[5] + '_lblfabriccolor').innerText.replace(',', '');
                gsm = document.getElementById('ctl00_cph_main_content_grdRFD_' + Idsn[5] + '_lblgsm').innerText.replace(',', '');
                cc = document.getElementById('ctl00_cph_main_content_grdRFD_' + Idsn[5] + '_lblcountconstraction').innerText.replace(',', '');
                width = document.getElementById('ctl00_cph_main_content_grdRFD_' + Idsn[5] + '_lblwidth').innerText.replace(',', '');


                if (Vals == 'True') {
                    isStyleSpecific = 1;
                }
                styleid = document.getElementById('ctl00_cph_main_content_grdRFD_' + Idsn[5] + '_hdnStyleID').value.replace(',', '');

            }
            else if (Fabtype == 'EMBELLISHMENT') {
                currentstage = document.getElementById('ctl00_cph_main_content_grdEMBELLISHMENT_' + Idsn[5] + '_hdnCurrentstage').value.replace(',', '');
                previousstage = document.getElementById('ctl00_cph_main_content_grdEMBELLISHMENT_' + Idsn[5] + '_hdnperiviousstgae').value.replace(',', '');
                Vals = document.getElementById('ctl00_cph_main_content_grdEMBELLISHMENT_' + Idsn[5] + '_hdnIsStyleSpecific').value.replace(',', '');
                if (Vals == 'True') {
                    isStyleSpecific = 1;
                }
                styleid = document.getElementById('ctl00_cph_main_content_grdEMBELLISHMENT_' + Idsn[5] + '_hdnStyleID').value.replace(',', '');

                fabqty = document.getElementById('ctl00_cph_main_content_grdEMBELLISHMENT_' + Idsn[5] + '_lblFabricQuality').innerText.replace(',', '');
                fabricdetails = document.getElementById('ctl00_cph_main_content_grdEMBELLISHMENT_' + Idsn[5] + '_lblfabriccolor').innerText.replace(',', '');
                gsm = document.getElementById('ctl00_cph_main_content_grdEMBELLISHMENT_' + Idsn[5] + '_lblgsm').innerText.replace(',', '');
                cc = document.getElementById('ctl00_cph_main_content_grdEMBELLISHMENT_' + Idsn[5] + '_lblcountconstraction').innerText.replace(',', '');
                width = document.getElementById('ctl00_cph_main_content_grdEMBELLISHMENT_' + Idsn[5] + '_lblwidth').innerText.replace(',', '');


            }
            else if (Fabtype == 'EMBROIDERY') {
                currentstage = document.getElementById('ctl00_cph_main_content_grdEMBROIDERY_' + Idsn[5] + '_hdnCurrentstage').value.replace(',', '');
                previousstage = document.getElementById('ctl00_cph_main_content_grdEMBROIDERY_' + Idsn[5] + '_hdnperiviousstgae').value.replace(',', '');
                Vals = document.getElementById('ctl00_cph_main_content_grdEMBROIDERY_' + Idsn[5] + '_hdnIsStyleSpecific').value.replace(',', '');
                if (Vals == 'True') {
                    isStyleSpecific = 1;
                }
                styleid = document.getElementById('ctl00_cph_main_content_grdEMBROIDERY_' + Idsn[5] + '_hdnStyleID').value.replace(',', '');

                fabqty = document.getElementById('ctl00_cph_main_content_grdEMBROIDERY_' + Idsn[5] + '_lblFabricQuality').innerText.replace(',', '');
                fabricdetails = document.getElementById('ctl00_cph_main_content_grdEMBROIDERY_' + Idsn[5] + '_lblfabriccolor').innerText.replace(',', '');
                gsm = document.getElementById('ctl00_cph_main_content_grdEMBROIDERY_' + Idsn[5] + '_lblgsm').innerText.replace(',', '');
                cc = document.getElementById('ctl00_cph_main_content_grdEMBROIDERY_' + Idsn[5] + '_lblcountconstraction').innerText.replace(',', '');
                width = document.getElementById('ctl00_cph_main_content_grdEMBROIDERY_' + Idsn[5] + '_lblwidth').innerText.replace(',', '');

            }

            var sURL = 'FabricSupplierDetails.aspx?FabricQualityID=' + FabQualityID + "&Fabtype=" + Fabtype + "&Potype=" + 'RERAISE' + "&ParentPageUrlWithQuerystring=" + urls + "&MasterPoID=" + MasterPoID + "&colorprintdetail=" + elem + "&gerige=" + gerige + "&residual=" + residual + "&cutwastage=" + cutwastage + "&currentstage=" + currentstage + "&previousstage=" + previousstage + "&isStyleSpecific=" + isStyleSpecific + "&styleid=" + styleid + "&stage1=" + Stage1 + "&stage2=" + stage2 + "&stage3=" + stage3 + "&stage4=" + stage4 + "&fabqty=" + fabqty + "&fabricdetails=" + fabricdetails + "&gsm=" + gsm + "&cc=" + cc + "&width=" + width;
            Shadowbox.init({ animate: false, animateFade: true, modal: true, handleOversize: true });
            Shadowbox.open({ content: sURL, type: "iframe", player: "iframe", title: "", height: 300, width: 900, modal: true, animate: true, oversized: true, animateFade: true, options: { onClose: SBClose} });
            $('#sb-wrapper').removeClass("PurchaseOrder");
            return false;
        }
        //        function ShowAllSupplier(innerhtml) {

        //            if (innerhtml == "empty") {
        //                var url = '../../Internal/Accessory/AccessorySupplierDetails.aspx?AccessoryMasterId=' + 0 + '&Size=' + 0 + '&ColorPrint=' + 'Fabric' + '&AccessoryType=' + '0';
        //                Shadowbox.init({ animate: false, animateFade: true, modal: true });
        //                Shadowbox.open({ content: url, type: "iframe", player: "iframe", title: "", height: 400, width: 973, modal: true, animate: true, oversized: true, animateFade: true, options: { onClose: SBClose} });
        //                return false;
        //            }
        //            else {
        //                $(".divspplier").html(innerhtml);
        //                $(".divspplier").show(innerhtml);
        //                $('#sb-wrapper').removeClass("PurchaseOrder");
        //            }
        //        }
        function HideSupplierDiv() {
            $(".divspplier").hide();
        }
        function Alert(msg) {
            alert(msg);
        }
        function showhideresidualshrinke(elem) {

            var Idsn = "";
            if (elem.id == "") {
                Idsn = elem.innerHTML.split("_");
            }
            else {
                Idsn = elem.id.split("_");
            }


            Selectedval = 0;
            var Isresidualshrnkpplyongerige = 0;
            Isresidualshrnkpplyongerige = $("#<%= grdGRIEGE.ClientID %>_" + Idsn[5] + "_txtResidualSh").val();
            var checkboxapply = $("#<%= grdGRIEGE.ClientID %>_" + Idsn[5] + "_chkApplyResShrinkage").is(":checked");
            var xbox = confirm("Are you sure want to update ?")
            var fabQtyID = $("#<%= grdGRIEGE.ClientID %>_" + Idsn[5] + "_hdnfabricQuality").val();

            if (xbox == false) {

                if (checkboxapply == false) {
                    $("#<%= grdGRIEGE.ClientID %>_" + Idsn[5] + "_txtResidualSh").addClass('show_me');
                    $("#<%= grdGRIEGE.ClientID %>_" + Idsn[5] + "_txtResidualSh").removeClass('hide_me');
                    $("#<%= grdGRIEGE.ClientID %>_" + Idsn[5] + "_chkApplyResShrinkage").attr('checked', 'checked');
                }
                else {
                    $("#<%= grdGRIEGE.ClientID %>_" + Idsn[5] + "_txtResidualSh").removeClass('show_me');
                    $("#<%= grdGRIEGE.ClientID %>_" + Idsn[5] + "_txtResidualSh").addClass('hide_me');
                    $("#<%= grdGRIEGE.ClientID %>_" + Idsn[5] + "_chkApplyResShrinkage").removeAttr('checked');
                }

            }
            else {

                if (checkboxapply == true) {

                    $("#<%= grdGRIEGE.ClientID %>_" + Idsn[5] + "_txtResidualSh").addClass('show_me');
                    $("#<%= grdGRIEGE.ClientID %>_" + Idsn[5] + "_txtResidualSh").removeClass('hide_me');
                    $("#<%= grdGRIEGE.ClientID %>_" + Idsn[5] + "_chkApplyResShrinkage").attr('checked', 'checked');
                }
                else {
                    Isresidualshrnkpplyongerige = 0;
                    $("#<%= grdGRIEGE.ClientID %>_" + Idsn[5] + "_txtResidualSh").removeClass('show_me');
                    $("#<%= grdGRIEGE.ClientID %>_" + Idsn[5] + "_txtResidualSh").addClass('hide_me');
                    $("#<%= grdGRIEGE.ClientID %>_" + Idsn[5] + "_chkApplyResShrinkage").removeAttr('checked');
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

        function CalculateOnLoad() {


            ctlid = "";
            var FabQty = 0;
            var QtyToOrder = 0;
            var GreigeShrn = 0;
            var IsChkRsk = 0;
            var ResidualShrn = 0;
            var ReceiveQty = 0;
            var GridId = "<%=grdGRIEGE.ClientID %>";
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
                    //FabQty = document.getElementById('ctl00_cph_main_content_grdGRIEGE_' + ctlid + '_lblfabricorderavg2').innerText.replace(',', '');
                    FabQty = document.getElementById('ctl00_cph_main_content_grdGRIEGE_' + ctlid + '_lblTotalFabRequired').innerText.replace(',', '');
                    QtyToOrder = document.getElementById('ctl00_cph_main_content_grdGRIEGE_' + ctlid + '_lblFabQtyRemaning2').innerText.replace(',', '');
                    //                    GreigeShrn = document.getElementById('ctl00_cph_main_content_grdGRIEGE_' + ctlid + '_txtGreigedShrinkage').value.replace(',', '');
                    //                    ResidualShrn = document.getElementById('ctl00_cph_main_content_grdGRIEGE_' + ctlid + '_txtResidualSh').value.replace(',', '');
                    //                    var checkBox = document.getElementById('ctl00_cph_main_content_grdGRIEGE_' + ctlid + '_chkApplyResShrinkage');
                    ReceiveQty = document.getElementById('ctl00_cph_main_content_grdGRIEGE_' + ctlid + '_recqty').innerText.replace(',', '');
                    cutwastage = document.getElementById('ctl00_cph_main_content_grdGRIEGE_' + ctlid + '_lblcutwastgae').innerText.replace(',', '');
                    lblcolor = document.getElementById('ctl00_cph_main_content_grdGRIEGE_' + ctlid + '_lblcolor').innerText.replace(',', '');
                    balanceInhOuse = document.getElementById('ctl00_cph_main_content_grdGRIEGE_' + ctlid + '_lblbalanceinhouseqty').innerText.replace(',', '');
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
                        document.getElementById('ctl00_cph_main_content_grdGRIEGE_' + ctlid + '_lblFabQtyRemaning2').innerText = numberWithCommas(Math.round(calculate));
                        QtytoOrder_ = Math.round(document.getElementById('ctl00_cph_main_content_grdGRIEGE_' + ctlid + '_lblFabQtyRemaning2').innerText.replace(',', ''));
                        pendingqty = (parseInt(Math.round(calculate)) - parseInt(balanceInhOuse) - parseInt(Math.round(ReceiveQty)));
                        var x = 0;
                        if (pendingqty == "0") {
                            x = "";
                        }
                        else {

                            x = numberWithCommas(Math.round(pendingqty));
                        }
                        document.getElementById('ctl00_cph_main_content_grdGRIEGE_' + ctlid + '_pendingQtyinorder').innerText = x;
                        ////                        updatePendingGreigeOrdersProxy(string flag, string FlagOption, int QtyToOrder, int PendingQtyToOrder, int FabricQualityID)
                        FabricQualityID = document.getElementById('ctl00_cph_main_content_grdGRIEGE_' + ctlid + '_hdnfabricQuality').value;
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

        function OnSuccessCall(response) {
            // CalculateOnLoad();
            //  CalculateOnLoadDayed(1);
            alert("Saved Sucessfully");

        }
        function OnErrorCall(response) {
            alert(response.status + " " + response.statusText);
        }


        function OpenWastageAdmin(FabType, FabricQualityID, FabricDetails, cutwastage) {
            if (cutwastage == "") {
                cutwastage = 0;
            }
            var sURL = 'FrmFabricWastageEntry.aspx?FabricQualityID=' + FabricQualityID + "&FabType=" + FabType + "&FabricDetails=" + FabricDetails + "&IsExecute=" + "FABRICVIEW" + "&cutwastage=" + cutwastage;
            Shadowbox.init({ animate: false, animateFade: true, modal: true });
            Shadowbox.open({ content: sURL, type: "iframe", player: "iframe", title: "", height: 400, width: 800, modal: true, animate: true, oversized: true, animateFade: true, options: { onClose: SBClose} });
            $('#sb-wrapper').removeClass("PurchaseOrder");


            return false;
        }

        function Setwidthwastagescreen(width, Height) {

            if (width <= 1172) {
                $("#sb-wrapper").css("width", parseInt(width) - 5 + "px");
            }
                        if (width <= 800) {
                            $("#sb-wrapper .divh .HeaderClass1").css({ "text-align": "center" });

                        }
            //        if (width < 1170) {
            //                $("#sb-wrapper").css("left", "200px");
            //             
            //         }

            if (Height <= 300) {
                $("#sb-wrapper-inner").css("height", parseInt(Height) + 150 + "px");
            }

        }
        function callparentpage() {
            $("#ctl00_cph_main_content_btnSearch").click();
            // ShowHideSuppliergrd($("#ctl00_cph_main_content_hdnFabtype").val());

        }
        function OpenWastageAdminPrint(FabType, FabricQualityID, FabricDetails, CurrentStage, PreviousStage, IsStyleSpecific, StyleID, stage1, stage2, stage3, stage4, cutwastage) {

            var sURL = 'FrmFabricWastageEntry.aspx?FabricQualityID=' + FabricQualityID + "&FabType=" + FabType + "&FabricDetails=" + FabricDetails + "&CurrentStage=" + CurrentStage + "&PreviousStage=" + PreviousStage + "&IsStyleSpecfic=" + IsStyleSpecific + "&StyleID=" + StyleID + "&stage1=" + stage1 + "&stage2=" + stage2 + "&stage3=" + stage3 + "&stage4=" + stage4 + "&cutwastage=" + cutwastage + "&IsExecute=" + "FABRICVIEW";
            Shadowbox.init({ animate: true, animateFade: true, modal: true });
            Shadowbox.open({ content: sURL, type: "iframe", player: "iframe", title: "", height: 400, width: 800, modal: true, animate: true, oversized: true, animateFade: true, options: { onClose: SBClose} });
            $('#sb-wrapper').removeClass("PurchaseOrder");
            return false;
        }

        function funcolor(cls) {
            //            alert(cls);
            //            $('td').removeAttr("style");
            //            $(".bgon" + cls).find('td').css("background-color", "#f1eaf0");
        }
        function pageLoad() {

            $("#ctl00_cph_main_content_grdEMBELLISHMENT tr,#ctl00_cph_main_content_grdRFD tr,#ctl00_cph_main_content_grdGRIEGE tr,#ctl00_cph_main_content_grdFINISHED tr,#ctl00_cph_main_content_grdDYED tr ,#ctl00_cph_main_content_grdEMBROIDERY tr").click(function () {
                $('#ctl00_cph_main_content_grdRFD  > tbody > tr').not(':first').find('td').css("background-color", "#FFFFFF");
                $('#ctl00_cph_main_content_grdGRIEGE  > tbody > tr').not(':first').find('td').css("background-color", "#FFFFFF");
                $('#ctl00_cph_main_content_grdEMBELLISHMENT  > tbody > tr').not(':first').find('td').css("background-color", "#FFFFFF");
                $('#ctl00_cph_main_content_grdFINISHED  > tbody > tr').not(':first').find('td').css("background-color", "#FFFFFF");
                $('#ctl00_cph_main_content_grdDYED  > tbody > tr').not(':first').find('td').css("background-color", "#FFFFFF");
                $('#ctl00_cph_main_content_grdEMBROIDERY  > tbody > tr').not(':first').find('td').css("background-color", "#FFFFFF");
                if ($(this).hasClass("HeaderClass") == false) {
                    $(this).find('td').css("background-color", "");
                }
            });
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
    <asp:ScriptManager ID="script1" runat="server" AsyncPostBackTimeout="600">
    </asp:ScriptManager>
    <asp:UpdateProgress DynamicLayout="true" runat="server" ID="updateProgressSupplyType"
        AssociatedUpdatePanelID="UpdatePanelSupplyType">
        <ProgressTemplate>
            <div id="spinner" class="fade-in">
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdatePanel ID="UpdatePanelSupplyType" runat="server">
        <ContentTemplate>
            <div class="headerSticky">
                <asp:HiddenField ID="hdntabvalue" runat="server" />
                <asp:HiddenField ID="hdnponumber" runat="server" />
                <asp:HiddenField ID="hdnmasterpoid" runat="server" />
                <asp:HiddenField ID="hdnIsMailSend" runat="server" />
                <asp:HiddenField ID="hdnStageName" runat="server" Value="" />
                <asp:HiddenField ID="hdnFabTypeForMail" runat="server" Value="" />
                <asp:HiddenField ID="hdnSessionQ" runat="server" Value="" />
                <h2>
                    Raise <span style="text-transform: lowercase;">and</span> Revise Fabric PO
                </h2>
            </div>
            <div class="raiseandrevise_topmenu" style="position: sticky; top: 23px; background-color: White;
                z-index: 99;">
                <div class="abc tab">
                    <asp:LinkButton ID="LnkGRIEGE" runat="server" CommandArgument="GRIEGE" OnClick="LinkSupplyTab_Click"> Greige</asp:LinkButton>
                    <asp:LinkButton ID="LnkDYED" runat="server" CommandArgument="DYED" OnClick="LinkSupplyTab_Click"> Dyed</asp:LinkButton>
                    <asp:LinkButton ID="LnkPRINT" runat="server" CommandArgument="PRINT" OnClick="LinkSupplyTab_Click"> Print</asp:LinkButton>
                    <asp:LinkButton ID="LnkFINISHED" runat="server" CommandArgument="FINISHED" OnClick="LinkSupplyTab_Click"> Finished</asp:LinkButton>
                    <asp:LinkButton ID="LnkRFD" runat="server" CommandArgument="RFD" OnClick="LinkSupplyTab_Click"> RFD</asp:LinkButton>
                    <asp:LinkButton ID="LnkEMBELLISHMENT" runat="server" CommandArgument="EMBELLISHMENT"
                        OnClick="LinkSupplyTab_Click"> Embellishment</asp:LinkButton>
                    <asp:LinkButton ID="LnkEMBROIDERY" runat="server" CommandArgument="EMBROIDERY" OnClick="LinkSupplyTab_Click"> Embroidery</asp:LinkButton>
                </div>
                <div class="SearchBoxDiv">
                    <%--added By Girish on 2023-03-09 For Sorting--%>
                    <asp:RadioButtonList runat="server" ID="rdb_SortBY" RepeatDirection="Horizontal"
                        CssClass="SortingRadioButton" Style="display: inline-block;">
                        <asp:ListItem Text="PO Date" Value="1"></asp:ListItem>
                        <asp:ListItem Text="Quality Name" Value="2"></asp:ListItem>
                    </asp:RadioButtonList>
                    <div class="SearchBox" style="position: absolute; bottom: 5px; left: 156px;">
                        <asp:TextBox ID="txtsearchkeyswords" type="search" class="search_1" placeholder="Search Fabric Quality/ Color Print"
                            runat="server" Style="width: 200px !important; margin: 2px 0px 1px; padding-left: 3px;
                            height: 16px !important"></asp:TextBox>
                        <asp:Button ID="btnSearch" runat="server" CssClass="go do-not-disable" Text="Search"
                            OnClick="btnSearch_Click" Style="padding: 2px 7px;" />
                    </div>
                </div>
                <div class="clearfix">
                </div>
            </div>
            <div style="width: 100%; margin: auto; padding-bottom: 6px;">
                <asp:HiddenField ID="hdnFabtype" runat="server" Value='GRIEGE' />
                <div id="DivGRIEGE" runat="server" style="display: none;">
                    <asp:GridView ID="grdGRIEGE" CssClass="greigegrdbor" ShowHeader="false" runat="server"
                        AutoGenerateColumns="False" EmptyDataText="" Width="100%" HeaderStyle-Font-Names="Arial"
                        HeaderStyle-HorizontalAlign="Center" ShowHeaderWhenEmpty="true" BorderWidth="0"
                        rules="all" OnRowDataBound="grdGRIEGE_RowDataBound" HeaderStyle-CssClass="ths">
                        <SelectedRowStyle BackColor="#A1DCF2" />
                        <EditRowStyle CssClass="EmpltyTable" />
                        <Columns>
                            <asp:TemplateField HeaderText="Fabric Quality">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <asp:Label ID="recqty" Style="display: none;" runat="server"></asp:Label>
                                    <asp:HiddenField ID="hdnfabricQuality" runat="server" Value='<%# Eval("FabricQualityID")%>' />
                                    <asp:Label ID="lblFabricQuality" ForeColor="blue" CssClass="color_black classfabsave"
                                        Text='<%# Eval("FabricName")%>' runat="server"></asp:Label>
                                    <asp:Label ID="lblcolor" CssClass="color_black" Font-Bold="true" ForeColor="black"
                                        runat="server" Text='<%# Eval("ColorPrint").ToString() %>'></asp:Label>
                                    <asp:Label ID="lblUnit" CssClass="gray" Font-Bold="true" ForeColor="gray" runat="server"
                                        Text='<%# Eval("UnitName").ToString() == "" ? "" :  Eval("UnitName") %>'></asp:Label>
                                    <asp:HiddenField ID="hdnmaxgrige" runat="server" Value='<%# (Eval("GreigedShrinkage") == DBNull.Value  || (Eval("GreigedShrinkage").ToString().Trim() == string.Empty)) ? string.Empty : Eval("GreigedShrinkage").ToString().Trim() %>' />
                                    <asp:HiddenField ID="hdnstage1" runat="server" Value='<%# Eval("Stage1")%>' />
                                    <asp:HiddenField ID="hdnstage2" runat="server" Value='<%# Eval("Stage2")%>' />
                                    <asp:HiddenField ID="hdnstage3" runat="server" Value='<%# Eval("Stage3")%>' />
                                    <asp:HiddenField ID="hdnstage4" runat="server" Value='<%# Eval("Stage4")%>' />
                                    <asp:HiddenField ID="hdnadjustmentqty" runat="server" Value='<%# Eval("adjustmentqty")%>' />
                                </ItemTemplate>
                                <ItemStyle CssClass="textLeft GriegeStageRe" Width="140px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Count Construction">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <asp:Label ID="lblcountconstraction" CssClass="gray" Text='<%# Eval("CountConstruction").ToString()%>'
                                        runat="server"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="GSM">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <asp:Label ID="lblgsm" CssClass="gray" Text='<%# Eval("GSM")%>' runat="server"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Width">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <asp:Label ID="lblwidth" CssClass="gray" Text='<%# Eval("width").ToString() +"&quot" + " in" %>'
                                        runat="server"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="StyleNumber">
                                <ItemTemplate>
                                    <asp:Label ID="lblstyleno" CssClass="color_black" runat="server"></asp:Label>
                                    <asp:GridView ID="grdstylenumber" ShowHeader="false" runat="server" AutoGenerateColumns="False"
                                        EmptyDataText="No Record Found!" Width="98%" HeaderStyle-Font-Names="Arial" HeaderStyle-HorizontalAlign="Center"
                                        CssClass="" BorderWidth="0" rules="all" HeaderStyle-CssClass="ths">
                                        <SelectedRowStyle BackColor="#A1DCF2" />
                                        <RowStyle CssClass="DYEDRowCount" />
                                        <Columns>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:HiddenField ID="hdnStyleid" runat="server" Value='<%# Eval("StyleID")%>' />
                                                    <asp:Label ID="lblStyleNumber" Text='<%# Eval("StyleNumber")%>' runat="server" Style="text-align: left;"></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" CssClass="borderDy textLeft" />
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </ItemTemplate>
                                <ItemStyle Width="70px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="SerialNumber">
                                <ItemTemplate>
                                    <asp:GridView ID="grdserialnumber" ShowHeader="false" runat="server" AutoGenerateColumns="False"
                                        EmptyDataText="No Record Found!" Width="98%" HeaderStyle-Font-Names="Arial" HeaderStyle-HorizontalAlign="Center"
                                        CssClass="" BorderWidth="0" rules="all" HeaderStyle-CssClass="ths">
                                        <SelectedRowStyle BackColor="#A1DCF2" />
                                        <RowStyle CssClass="DYEDRowCount" />
                                        <Columns>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSerialNumber" Text='<%# Eval("SerialNumber") %>' runat="server"></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="center" CssClass="borderDy textLeft" />
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </ItemTemplate>
                                <ItemStyle Width="70px" />
                            </asp:TemplateField>
                            <asp:TemplateField Visible="false">
                                <ItemTemplate>
                                    <table border="0" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td style='border-bottom: 1px solid #e2dddd99'>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                            </td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                                <ItemStyle Width="70px" />
                            </asp:TemplateField>
                            <asp:TemplateField Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblGreige" CssClass="color_black" Visible="false" Text='<%# (Eval("GreigedShrinkage") == DBNull.Value  || (Eval("GreigedShrinkage").ToString().Trim() == string.Empty)) ? string.Empty : Eval("GreigedShrinkage").ToString().Trim() %>'
                                        runat="server"></asp:Label>
                                    <asp:TextBox ID="txtGreigedShrinkage" onchange="CalculateOnLoad();" onkeypress="return validateFloatKeyPress(this,event);"
                                        Style="width: 85% !important; text-align: center;" runat="server" Text='<%# (Eval("GreigedShrinkage") == DBNull.Value  || (Eval("GreigedShrinkage").ToString().Trim() == string.Empty)) ? string.Empty : Eval("GreigedShrinkage").ToString().Trim() %>'></asp:TextBox>
                                </ItemTemplate>
                                <ItemStyle Width="50px" />
                            </asp:TemplateField>
                            <asp:TemplateField Visible="false">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkApplyResShrinkage" Style="float: left" onchange="showhideresidualshrinke(this)"
                                        class="Classapplyshrink" runat="server" Checked='<%# Eval("IsResidualShrinkage") %>' />
                                    <asp:TextBox ID="txtResidualSh" onchange="CalculateOnLoad();" onkeypress="return validateFloatKeyPress(this,event);"
                                        MaxLength="5" runat="server" Text='<%# (Eval("ResidualShrinkage") == DBNull.Value  || (Eval("ResidualShrinkage").ToString().Trim() == string.Empty)) ? string.Empty : Eval("ResidualShrinkage").ToString().Trim() %>'
                                        Style="width: 35px !important; text-align: center; float: left;" class='<%# Convert.ToInt32(Eval("IsResidualShrinkage")) == 0 ? "hide_me" : "show_me"  %>'></asp:TextBox>
                                    <asp:Label ID="lblresidualshrink" Style="color: Gray; float: right; padding-right: 2px;
                                        position: relative; top: 4px" runat="server"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Width="123px" />
                            </asp:TemplateField>
                            <asp:TemplateField Visible="false">
                                <ItemTemplate>
                                    <div class="AccessToltip">
                                    </div>
                                </ItemTemplate>
                                <ItemStyle Width="80px" />
                            </asp:TemplateField>
                            <asp:TemplateField Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblFabQtyRemaning" Style="display: none;" runat="server"></asp:Label>
                                    <asp:Label ID="lblFabQtyRemaning2" runat="server"></asp:Label>
                                    <asp:Label ID="lblTotalFabRequired" Style="display: none;" runat="server"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Width="80px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="PO Number">
                                <ItemTemplate>
                                </ItemTemplate>
                                <ItemStyle Width="50px" HorizontalAlign="left" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="PO Supplier Name">
                                <ItemTemplate>
                                </ItemTemplate>
                                <ItemStyle Width="50px" HorizontalAlign="left" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="PO Rcvd. Qty.">
                                <ItemTemplate>
                                </ItemTemplate>
                                <ItemStyle Width="50px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Revise PO">
                                <ItemTemplate>
                                </ItemTemplate>
                                <ItemStyle Width="50px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Quantity Breakdown">
                                <ItemTemplate>
                                    <table border="0" cellpadding="0" cellspacing="0" class="Quantity_Breakdown_column">
                                        <tr>
                                            <td style="width: 60%; text-align: left; border: 1px solid #e2dddd99!important; border-top: 0!important;
                                                border-left: 0!important; padding-left: 5px; padding-left: 5px;">
                                                <span>To Order</span>
                                            </td>
                                            <td style="border: 1px solid #e2dddd99!important; border-left: 0!important; border-top: 0!important;
                                                border-right: 0!important;">
                                                <asp:Label ID="lblfabricorderavg" Style="display: none;" runat="server"></asp:Label>
                                                <asp:Label ID="lblfabricorderavg2" Style="float: right; margin-right: 10px;" CssClass="clfabqty"
                                                    runat="server"></asp:Label>
                                                <asp:Label ID="lblcutwastgae" Style="display: none" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 60%; text-align: left; border: 1px solid #e2dddd99!important; border-top: 0!important;
                                                border-left: 0!important; padding-left: 5px; padding-left: 5px;">
                                                <span>To Receive (After Shr./ Waste.)</span>
                                            </td>
                                            <td style="border: 1px solid #e2dddd99!important; border-left: 0!important; border-top: 0!important;
                                                border-right: 0!important;">
                                                <asp:Label ID="lblrequiredqty" title="Click here to view wastage details & get required quantity"
                                                    Style="color: blue; cursor: pointer; float: right; margin-right: 10px;" CssClass="clfabqty"
                                                    runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 60%; text-align: left; border: 1px solid #e2dddd99!important; border-top: 0!important;
                                                border-left: 0!important; padding-left: 5px; padding-left: 5px;">
                                                <span>Stock in House</span>
                                            </td>
                                            <td style="border: 1px solid #e2dddd99!important; border-left: 0!important; border-top: 0!important;
                                                border-right: 0!important;">
                                                <asp:Label ID="lblbalanceinhouseqty" Style="float: right; margin-right: 10px;" Text='<%# (Eval("BalanceQty") == DBNull.Value  || (Eval("BalanceQty").ToString().Trim() == "0")) ? string.Empty : Eval("BalanceQty").ToString().Trim() %>'
                                                    runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr id="balancetooltipp" runat="server" style="display: none">
                                            <td style="text-align: left; border: 1px solid #e2dddd99!important; border-left: 0!important;
                                                border-top: 0!important; padding-left: 5px;">
                                                <asp:Label ID="lblBalanceTooltip" runat="server" Text=""></asp:Label>
                                            </td>
                                            <td style="border: 1px solid #e2dddd99!important; border-left: 0!important; border-top: 0!important;
                                                border-right: 0!important; text-align: right; padding-right: 10px;">
                                                <asp:Label ID="lbladjustmentqtyy" runat="server" Text=""></asp:Label>
                                            </td>
                                        </tr>
                                        <%-- <tr>
                                            <td style="text-align: left">
                                                <span style="width: 60%; display: inline-block;">PO Ordered (send)</span><span>:</span>
                                            </td>
                                        </tr>--%>
                                        <tr>
                                            <td style="width: 60%; text-align: left; border: 1px solid #e2dddd99!important; border-top: 0!important;
                                                border-left: 0!important; padding-left: 5px; padding-left: 5px;">
                                                <span>Total Po To Receive</span>
                                            </td>
                                           
                                            <td style="border: 1px solid #e2dddd99!important; border-left: 0!important; border-top: 0!important;
                                                border-right: 0!important;">
                                                <asp:Label runat="server" ID="ToReceive" Style="float: right; margin-right: 10px;"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr runat="server" id="trArchieveRow" visible="false">
                                            <td style="width: 60%; text-align: left; border: 1px solid #e2dddd99!important; border-top: 0!important;
                                                border-left: 0!important; padding-left: 5px; padding-left: 5px;">
                                                <span>Cut Issued Qty</span>
                                            </td>
                                            <td style="border: 1px solid #e2dddd99!important; border-left: 0!important; border-top: 0!important;
                                                border-right: 0!important;">
                                                <asp:Label runat="server" ID="lblArchieveQty" Style="float: right; margin-right: 10px;"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" style="text-align: left; border: 1px solid #e2dddd99!important; border-left: 0!important;
                                                border-top: 0!important; border-right: 0!important; padding-left: 5px;">
                                                <span style="width: 40%; display: inline-block;">Pending to Order</span>
                                                <asp:Label ID="pendingQtyinorder" runat="server" onclick="var split=id.split('pendingQtyinorder');$('#'+split[0]+'quantity_breakdown').css('display','inline-table');"
                                                    Style="color: blue; float: right; margin-right: 10px; cursor: pointer"></asp:Label>
                                                <span><a id="lnkProductionpopup" runat="server" style="font-size: 8px; position: relative;
                                                    top: -4px; float: right; margin: 0 10px;">
                                                    <img src="../../App_Themes/ikandi/images/zoom_icon1.gif" style="cursor: pointer;" />
                                                </a></span><span>
                                                    <asp:Button ID="btnrapo" Style="display: none;" runat="server" Text="R.PO" />
                                                    <div class="btnrpo tooltip" runat="server" id="divraise">
                                                        R.PO
                                                    </div>
                                                </span>
                                                <table id="quantity_breakdown" style="display: none; position: relative; margin-top: 12px;"
                                                    runat="server">
                                                    <tr>
                                                        <th>
                                                            Actual
                                                        </th>
                                                        <th>
                                                            Shipped But Not Complete Issued
                                                        </th>
                                                        <th>
                                                            Shipped And Issued
                                                        </th>
                                                        <th>
                                                            Total
                                                        </th>
                                                        <th onclick="$('#'+$(this).closest('table').attr('id')).css('display','none');" style="position: absolute;
                                                            right: 0; top: -12px; padding: 0px 8px; border-left: 1px solid grey; border-bottom: 0;
                                                            cursor: pointer">
                                                            X
                                                        </th>
                                                    </tr>
                                                    <tr>
                                                        <td style="border: 1px solid lightgray;">
                                                            <%# Eval("Actual") %>
                                                        </td>
                                                        <td style="border: 1px solid lightgray;">
                                                            <%# Eval("ShippedButNotIssued") %>
                                                        </td>
                                                        <td style="border: 1px solid lightgray;">
                                                            <%# Eval("ShippedAndIssued") %>
                                                        </td>
                                                        <td style="border: 1px solid lightgray;">
                                                            <%# Eval("Total") %>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="4" style="color: gray;">
                                                            Please Check Fabric Avg. Also.
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                                <ItemStyle Width="270px" />
                            </asp:TemplateField>
                        </Columns>
                        <EmptyDataTemplate>
                            <table cellspacing="0" rules="all" class="nobordertd" border="0" id="ctl00_cph_main_content_grdGRIEGE"
                                style="border-width: 0px; width: 100%; border-collapse: collapse;">
                                <tbody>
                                    <tr class="HeaderClass">
                                        <td align="center" style="min-width: 180px;">
                                            <table>
                                                <tbody>
                                                    <tr>
                                                        <td colspan="3" style="border: 0px">
                                                            Fabric Quality (GSM) C&amp;C Width<br>
                                                            Color/Print (Unit)
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            Current Stage
                                                        </td>
                                                        <td>
                                                            Previous Stage
                                                        </td>
                                                        <td>
                                                            Style Specific
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </td>
                                        <td align="center" style="min-width: 150px;">
                                            Style No. (Serial No.)
                                        </td>
                                        <td align="center" style="width: 60px;">
                                            <table>
                                                <tbody>
                                                    <tr>
                                                        <td style="border: 0px">
                                                            Qty to order
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            Qty Recieved
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </td>
                                        <td align="center" style="width: 40px;">
                                            Balance
                                            <br>
                                            In House
                                        </td>
                                        <td align="left" style="width: 80px;">
                                            PO Number
                                        </td>
                                        <td align="left" style="min-width: 130px;">
                                            PO Supplier Name
                                        </td>
                                        <td align="center" style="width: 60px;">
                                            PO Rcvd. Qty.
                                        </td>
                                        <td align="center" class="widthAction">
                                            Revise PO
                                        </td>
                                        <td align="center" class="widthPending">
                                            Qty. to Raise PO
                                        </td>
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
                </div>
                <div id="DivDYED" runat="server" style="display: none;">
                    <asp:GridView ID="grdDYED" CssClass="greigegrdbor" ShowHeader="false" runat="server"
                        AutoGenerateColumns="False" EmptyDataText="No Record Found!" Width="100%" HeaderStyle-Font-Names="Arial"
                        HeaderStyle-HorizontalAlign="Center" BorderWidth="0" rules="all" OnRowDataBound="grdDYED_RowDataBound"
                        HeaderStyle-CssClass="ths">
                        <SelectedRowStyle BackColor="#A1DCF2" />
                        <EditRowStyle CssClass="EmpltyTable" />
                        <Columns>
                            <asp:TemplateField HeaderText="Fabric Quality">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <asp:Label ID="recqty" Style="display: none;" runat="server"></asp:Label>
                                    <asp:HiddenField ID="hdnfabricQuality" runat="server" Value='<%# Eval("FabricQualityID")%>' />
                                    <asp:Label ID="lblFabricQuality" ForeColor="blue" CssClass="color_black classfabsave"
                                        Text='<%# Eval("FabricName")%>' runat="server"></asp:Label>
                                    <asp:Label ID="lblUnit" CssClass="gray" Font-Bold="true" ForeColor="gray" runat="server"
                                        Text='<%# Eval("UnitName").ToString() == "" ? "" : Eval("UnitName")%>'></asp:Label>
                                    <asp:HiddenField ID="hdnCurrentstage" runat="server" Value='<%# Eval("CurrentStage")%>' />
                                    <asp:HiddenField ID="hdnperiviousstgae" runat="server" Value='<%# Eval("PreviousStage")%>' />
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
                                <ItemStyle CssClass="textLeft GriegeStageRe" Width="140px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="CountConstruction">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <asp:Label ID="lblcountconstraction" CssClass="gray" Text='<%# Eval("CountConstruction").ToString()%>'
                                        runat="server"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="GSM">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <asp:Label ID="lblgsm" CssClass="gray" Text='<%# Eval("GSM")%>' runat="server"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Width">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <asp:Label ID="lblwidth" CssClass="gray" Text='<%# Eval("width").ToString()+"&quot" + " in" %>'
                                        runat="server"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ColorPrint">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <asp:Label ID="lblfabriccolor" CssClass="color_black" Font-Bold="true" ForeColor="black"
                                        Text='<%# Eval("ColorPrint").ToString() %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle CssClass="textLeft" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="StyleNumber">
                                <ItemTemplate>
                                    <asp:GridView ID="grdstylenumber" ShowHeader="false" runat="server" AutoGenerateColumns="False"
                                        EmptyDataText="No Record Found!" Width="98%" HeaderStyle-Font-Names="Arial" HeaderStyle-HorizontalAlign="Center"
                                        CssClass="grdDYEDtable" BorderWidth="0" rules="all" HeaderStyle-CssClass="ths">
                                        <SelectedRowStyle BackColor="#A1DCF2" />
                                        <RowStyle CssClass="DYEDRowCount" />
                                        <Columns>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:HiddenField ID="hdnfabricQuality" runat="server" Value='<%# Eval("Fabric_QualityID")%>' />
                                                    <asp:HiddenField ID="hdnStyleid" runat="server" Value='<%# Eval("StyleID")%>' />
                                                    <asp:Label ID="lblStyleNumber" Text='<%# Eval("StyleNumber")%>' runat="server" Style="text-align: left;"></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle CssClass="borderDy textLeft" />
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </ItemTemplate>
                                <ItemStyle Width="70px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Serial No.">
                                <ItemTemplate>
                                    <asp:GridView ID="grdserialnumber" ShowHeader="false" runat="server" AutoGenerateColumns="False"
                                        EmptyDataText="No Record Found!" Width="98%" HeaderStyle-Font-Names="Arial" HeaderStyle-HorizontalAlign="Center"
                                        CssClass="grdDYEDtable" BorderWidth="0" rules="all" HeaderStyle-CssClass="ths">
                                        <SelectedRowStyle BackColor="#A1DCF2" />
                                        <RowStyle CssClass="DYEDRowCount" />
                                        <Columns>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSerialNumber" Text='<%# Eval("SerialNumber")%>' runat="server"></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle CssClass="borderDy textLeft" />
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </ItemTemplate>
                                <ItemStyle Width="70px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Qty to order" Visible="false">
                                <ItemTemplate>
                                    <asp:HiddenField ID="hdnfabprint" runat="server" Value='<%# Eval("ColorPrint").ToString() %>' />
                                    <%--  <table border="0" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td style='border-bottom: 1px solid #e2dddd99'>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                            </td>
                                        </tr>
                                    </table>--%>
                                </ItemTemplate>
                                <ItemStyle Width="70px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Greige" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblGreige" CssClass="color_black" Visible="false" Text='<%# (Eval("GreigedShrinkage") == DBNull.Value  || (Eval("GreigedShrinkage").ToString().Trim() == string.Empty)) ? string.Empty : Eval("GreigedShrinkage").ToString().Trim() %>'
                                        runat="server"></asp:Label>
                                    <asp:TextBox ID="txtGreigeshrk" Enabled="false" CssClass="textboxAslabel" onchange="CalculateOnLoadDayed(1);"
                                        onkeypress="return validateFloatKeyPress(this,event);" Style="width: 90% !important;
                                        text-align: center;" runat="server" Text='<%# (Eval("GreigedShrinkage") == DBNull.Value  || (Eval("GreigedShrinkage").ToString().Trim() == string.Empty)) ? string.Empty : Eval("GreigedShrinkage").ToString().Trim() %>'></asp:TextBox>
                                    <asp:HiddenField ID="hdnGreigeshrk" runat="server" Value='<%# (Eval("GreigedShrinkage") == DBNull.Value  || (Eval("GreigedShrinkage").ToString().Trim() == string.Empty)) ? string.Empty : Eval("GreigedShrinkage").ToString().Trim() %>' />
                                </ItemTemplate>
                                <ItemStyle Width="50px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Residual" Visible="false">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtResidualShak" CssClass="textboxAslabel datesfileds lbls" onchange="CalculateOnLoadDayed(1);"
                                        onkeypress="return validateFloatKeyPress(this,event);" Style="width: 90% !important;
                                        background: transparent !important; border: none !important; outline: none !important;
                                        padding: 0px 0px 0px 0px !important; text-align: center; outline: none;" runat="server"
                                        Text='<%# (Eval("ResidualShrinkage").ToString() == "0"  || (Eval("ResidualShrinkage").ToString().Trim() == string.Empty)) ? string.Empty : Eval("ResidualShrinkage").ToString().Trim() %>'></asp:TextBox>
                                </ItemTemplate>
                                <ItemStyle Width="50px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Balance In House" Visible="false">
                                <ItemTemplate>
                                    <div class="AccessToltip">
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
                            <asp:TemplateField HeaderText="perior" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblpriorstageQty" Text='<%# (Eval("PirorStageQty") == DBNull.Value  || (Eval("PirorStageQty").ToString().Trim() == string.Empty) || (Eval("PirorStageQty").ToString().Trim() == "0")) ? string.Empty : Convert.ToInt32(Eval("PirorStageQty")).ToString("N0") %>'
                                        runat="server"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Width="80px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Total Qty. To Send" Visible="false">
                                <ItemTemplate>
                                </ItemTemplate>
                                <ItemStyle Width="80px" />
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
                            <asp:TemplateField HeaderText="Quantity Breakdown">
                                <ItemTemplate>
                                    <table border="0" cellpadding="0" cellspacing="0" class="Quantity_Breakdown_column">
                                        <tr>
                                            <td style="width: 60%; text-align: left; border: 1px solid #e2dddd99!important; border-top: 0!important;
                                                border-left: 0!important; padding-left: 5px; padding-left: 5px;">
                                                <span>To Order</span>
                                            </td>
                                            <td style="border: 1px solid #e2dddd99!important; border-left: 0!important; border-top: 0!important;
                                                border-right: 0!important;">
                                                <asp:Label ID="lblfabricQty" Style="float: right; margin-right: 10px;" runat="server"></asp:Label>
                                                <asp:Label ID="lblcutwastgae" Style="display: none" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 60%; text-align: left; border: 1px solid #e2dddd99!important; border-top: 0!important;
                                                border-left: 0!important; padding-left: 5px; padding-left: 5px;">
                                                <span>To Receive (After Shr./ Waste.)</span>
                                            </td>
                                            <td style="border: 1px solid #e2dddd99!important; border-left: 0!important; border-top: 0!important;
                                                border-right: 0!important;">
                                                <asp:Label ID="lblrequiredqty" title="Click here to view wastage details & get required quantity"
                                                    Style="float: right; margin-right: 10px; color: blue; cursor: pointer;" CssClass="clfabqty"
                                                    runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 60%; text-align: left; border: 1px solid #e2dddd99!important; border-top: 0!important;
                                                border-left: 0!important; padding-left: 5px; padding-left: 5px;">
                                                <span>Stock in House</span>
                                            </td>
                                            <td style="border: 1px solid #e2dddd99!important; border-left: 0!important; border-top: 0!important;
                                                border-right: 0!important;">
                                                <asp:Label ID="lblbalanceinhouseqty" Text='<%# (Eval("BalanceQty") == DBNull.Value  || (Eval("BalanceQty").ToString().Trim() == "0")) ? string.Empty : Eval("BalanceQty").ToString().Trim() %>'
                                                    runat="server" Style="float: right; margin-right: 10px;"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr id="balancetooltipp" runat="server" style="display: none">
                                            <td style="text-align: left; border: 1px solid #e2dddd99!important; border-left: 0!important;
                                                border-top: 0!important; padding-left: 5px;">
                                                <asp:Label ID="lblBalanceTooltip" runat="server" Text=""></asp:Label>
                                            </td>
                                            <td style="border: 1px solid #e2dddd99!important; border-left: 0!important; border-top: 0!important;
                                                border-right: 0!important; text-align: right; padding-right: 10px;">
                                                <asp:Label ID="lbladjustmentqtyy" runat="server" Text=""></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 60%; text-align: left; border: 1px solid #e2dddd99!important; border-top: 0!important;
                                                border-left: 0!important; padding-left: 5px; padding-left: 5px;">
                                                <span>PO Ordered (send)</span>
                                            </td>
                                            <td style="border: 1px solid #e2dddd99!important; border-left: 0!important; border-top: 0!important;
                                                border-right: 0!important;">
                                                <asp:Label ID="txtqtytosend" Enabled="false" Style="float: right; margin-right: 10px;"
                                                    runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 60%; text-align: left; border: 1px solid #e2dddd99!important; border-top: 0!important;
                                                border-left: 0!important; padding-left: 5px; padding-left: 5px;">
                                                <span>Total Po To Receive</span>
                                            </td>
                                            <td style="border: 1px solid #e2dddd99!important; border-left: 0!important; border-top: 0!important;
                                                border-right: 0!important;">
                                                <asp:Label runat="server" ID="ToReceive_Dyed" Style="float: right; margin-right: 10px;"></asp:Label>
                                            </td>
                                        </tr>
                                         <tr runat="server" id="trArchieveRow" visible="false">
                                            <td style="width: 60%; text-align: left; border: 1px solid #e2dddd99!important; border-top: 0!important;
                                                border-left: 0!important; padding-left: 5px; padding-left: 5px;">
                                                <span>Cut Issued Qty</span>
                                            </td>
                                            <td style="border: 1px solid #e2dddd99!important; border-left: 0!important; border-top: 0!important;
                                                border-right: 0!important;">
                                                <asp:Label runat="server" ID="lblArchieveQty" Style="float: right; margin-right: 10px;"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" style="text-align: left; border: 1px solid #e2dddd99!important; border-left: 0!important;
                                                border-top: 0!important; border-right: 0!important; padding-left: 5px;">
                                                <span style="width: 40%; display: inline-block;">Pending to Order</span>
                                                <asp:Label ID="pendingQtyinorder" runat="server" onclick="var split=id.split('pendingQtyinorder');$('#'+split[0]+'quantity_breakdown_dyed').css('display','inline-table');"
                                                    Style="color: blue; float: right; margin-right: 10px; cursor: pointer"></asp:Label>
                                                <span><a id="lnkProductionpopup" runat="server" style="font-size: 8px; position: relative;
                                                    top: -4px; float: right; margin: 0 10px;">
                                                    <img src="../../App_Themes/ikandi/images/zoom_icon1.gif" style="cursor: pointer;" />
                                                </a></span><span>
                                                    <asp:Button ID="btnrapo" Style="display: none;" runat="server" Text="R.PO" />
                                                    <div class="btnrpo tooltip" runat="server" id="divraise">
                                                        R.PO
                                                    </div>
                                                </span>
                                                <table id="quantity_breakdown_dyed" style="display: none; position: relative; margin-top: 12px;"
                                                    runat="server">
                                                    <tr>
                                                        <th>
                                                            Actual
                                                        </th>
                                                        <th>
                                                            Shipped But Not Complete Issued
                                                        </th>
                                                        <th>
                                                            Shipped And Issued
                                                        </th>
                                                        <th>
                                                            Total
                                                        </th>
                                                        <th onclick="$('#'+$(this).closest('table').attr('id')).css('display','none');" style="position: absolute;
                                                            right: 0; top: -12px; padding: 0px 8px; border-left: 1px solid grey; border-bottom: 0;
                                                            cursor: pointer">
                                                            X
                                                        </th>
                                                    </tr>
                                                    <tr>
                                                        <td style="border: 1px solid lightgray;">
                                                            <%# Eval("Actual") %>
                                                        </td>
                                                        <td style="border: 1px solid lightgray;">
                                                            <%# Eval("ShippedButNotIssued") %>
                                                        </td>
                                                        <td style="border: 1px solid lightgray;">
                                                            <%# Eval("ShippedAndIssued") %>
                                                        </td>
                                                        <td style="border: 1px solid lightgray;">
                                                            <%# Eval("Total") %>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="4" style="color: gray;">
                                                            Please Check Fabric Avg. Also.
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                                <ItemStyle Width="270px" />
                            </asp:TemplateField>
                        </Columns>
                        <EmptyDataTemplate>
                            <table cellspacing="0" rules="all" class="greigegrd greigegrdbor nobordertd" border="0"
                                id="ctl00_cph_main_content_grdDYED" style="border-width: 0px; width: 100%; border-collapse: collapse;">
                                <tbody>
                                    <tr class="HeaderClass">
                                        <td align="center" style="min-width: 200px;">
                                            <table>
                                                <tbody>
                                                    <tr>
                                                        <td colspan="3" style="border: 0px;">
                                                            Fabric Quality (GSM) C&amp;C Width<br>
                                                            Color/Print (Unit)
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            Current Stage
                                                        </td>
                                                        <td>
                                                            Previous Stage
                                                        </td>
                                                        <td>
                                                            Style Specific
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </td>
                                        <td align="center" style="min-width: 150px;">
                                            Style No. (Serial No.)
                                        </td>
                                        <td align="center" style="width: 60px;">
                                            <table>
                                                <tbody>
                                                    <tr>
                                                        <td style="border: 0px">
                                                            Qty to order
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            Qty To Received
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </td>
                                        <td align="center" style="width: 40px;">
                                            Balance
                                            <br>
                                            In House
                                        </td>
                                        <td align="center" style="width: 80px;">
                                            Total In House
                                        </td>
                                        <td align="center" style="width: 80px;">
                                            Total Send
                                        </td>
                                        <td align="left" style="width: 80px;">
                                            PO Number
                                        </td>
                                        <td align="left" style="min-width: 130px;">
                                            PO Supplier Name
                                        </td>
                                        <td align="center" style="width: 60px;">
                                            Rcvd. Qty.
                                        </td>
                                        <td align="center" class="widthAction">
                                            Revise PO
                                        </td>
                                        <td align="center" class="widthPending">
                                            Qty. to Raise PO
                                        </td>
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
                </div>
                <div id="DivPRINT" runat="server" style="display: none;">
                    <asp:GridView ID="grdPRINT" class="grdgayeds" ShowHeader="false" runat="server" AutoGenerateColumns="False"
                        EmptyDataText="No Record Found!" Width="100%" HeaderStyle-Font-Names="Arial"
                        CssClass="greigegrdbor" HeaderStyle-HorizontalAlign="Center" BorderWidth="0"
                        rules="all" OnRowDataBound="grdPRINT_RowDataBound" HeaderStyle-CssClass="ths">
                        <SelectedRowStyle BackColor="#A1DCF2" />
                        <EditRowStyle CssClass="EmpltyTable" />
                        <Columns>
                            <asp:TemplateField HeaderText="Fabric Quality">
                                <ItemStyle Width="140px" CssClass="textLeft GriegeStageRe" />
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <asp:Label ID="recqty" Style="display: none;" runat="server"></asp:Label>
                                    <asp:HiddenField ID="hdnfabricQuality" runat="server" Value='<%# Eval("FabricQualityID")%>' />
                                    <asp:Label ID="lblFabricQuality" ForeColor="blue" CssClass="color_black classfabsave"
                                        Text='<%# Eval("FabricName")%>' runat="server"></asp:Label>
                                    <asp:Label ID="lblcolor" Style="display: none" CssClass="color_black" runat="server"
                                        Text='<%# Eval("ColorPrint").ToString() %>'></asp:Label>
                                    <asp:Label ID="lblUnit" CssClass="gray" Font-Bold="true" ForeColor="gray" runat="server"
                                        Text='<%# Eval("UnitName").ToString() == "" ? "" : Eval("UnitName")%>'></asp:Label>
                                    <asp:HiddenField ID="hdnCurrentstage" runat="server" Value='<%# Eval("CurrentStage")%>' />
                                    <asp:HiddenField ID="hdnperiviousstgae" runat="server" Value='<%# Eval("PreviousStage")%>' />
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
                            <asp:TemplateField HeaderText="CountConstruction">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <asp:Label ID="lblcountconstraction" CssClass="gray" Text='<%# Eval("CountConstruction").ToString()%>'
                                        runat="server"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="GSM">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <asp:Label ID="lblgsm" CssClass="gray" Text='<%# Eval("GSM")%>' runat="server"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Width">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <asp:Label ID="lblwidth" CssClass="gray" Text='<%# Eval("width").ToString()+"&quot" + " in" %>'
                                        runat="server"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ColorPrint">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <asp:Label ID="lblfabriccolor" CssClass="color_black" Font-Bold="true" ForeColor="black"
                                        Text='<%# Eval("ColorPrint").ToString() %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle CssClass="textLeft" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Style No.">
                                <ItemTemplate>
                                    <asp:GridView ID="grdstylenumber" ShowHeader="false" runat="server" AutoGenerateColumns="False"
                                        EmptyDataText="No Record Found!" Width="98%" HeaderStyle-Font-Names="Arial" HeaderStyle-HorizontalAlign="Center"
                                        CssClass="" BorderWidth="0" rules="all" HeaderStyle-CssClass="ths">
                                        <RowStyle CssClass="PrintRowCount" />
                                        <SelectedRowStyle BackColor="#A1DCF2" />
                                        <Columns>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:HiddenField ID="hdnfabricQuality" runat="server" Value='<%# Eval("Fabric_QualityID")%>' />
                                                    <asp:HiddenField ID="hdnStyleid" runat="server" Value='<%# Eval("StyleID")%>' />
                                                    <asp:Label ID="lblStyleNumber" Text='<%# Eval("StyleNumber")%>' runat="server" Style="text-align: left;"></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle CssClass="borderDy textLeft" />
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </ItemTemplate>
                                <ItemStyle Width="70px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Serial No">
                                <ItemTemplate>
                                    <asp:GridView ID="grdserialnumber" ShowHeader="false" runat="server" AutoGenerateColumns="False"
                                        EmptyDataText="No Record Found!" Width="98%" HeaderStyle-Font-Names="Arial" HeaderStyle-HorizontalAlign="Center"
                                        CssClass="" BorderWidth="0" rules="all" HeaderStyle-CssClass="ths">
                                        <RowStyle CssClass="PrintRowCount" />
                                        <SelectedRowStyle BackColor="#A1DCF2" />
                                        <Columns>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSerialNumber" Text='<%# Eval("SerialNumber")%>' runat="server"></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle CssClass="borderDy textLeft" />
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </ItemTemplate>
                                <ItemStyle Width="70px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Qty to order" Visible="false">
                                <ItemTemplate>
                                </ItemTemplate>
                                <ItemStyle Width="70px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Greige" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblGreige" CssClass="color_black" Visible="false" Text='<%# (Eval("GreigedShrinkage") == DBNull.Value  || (Eval("GreigedShrinkage").ToString().Trim() == string.Empty)) ? string.Empty : Eval("GreigedShrinkage").ToString().Trim() %>'
                                        runat="server"></asp:Label>
                                    <asp:TextBox ID="txtGreigeshrk" Enabled="false" CssClass="textboxAslabel" onchange="CalculateOnLoadPrint(1);"
                                        onkeypress="return validateFloatKeyPress(this,event);" Style="width: 90% !important;
                                        text-align: center;" runat="server" Text='<%# (Eval("GreigedShrinkage") == DBNull.Value  || (Eval("GreigedShrinkage").ToString().Trim() == string.Empty)) ? string.Empty : Eval("GreigedShrinkage").ToString().Trim() %>'></asp:TextBox>
                                    <asp:HiddenField ID="hdnGreigeshrk" runat="server" Value='<%# (Eval("GreigedShrinkage") == DBNull.Value  || (Eval("GreigedShrinkage").ToString().Trim() == string.Empty)) ? string.Empty : Eval("GreigedShrinkage").ToString().Trim() %>' />
                                </ItemTemplate>
                                <ItemStyle Width="50px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Residual" Visible="false">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtResidualShak" CssClass="textboxAslabel datesfileds" onchange="CalculateOnLoadPrint(1);"
                                        onkeypress="return validateFloatKeyPress(this,event);" Style="width: 90% !important;
                                        background: transparent !important; border: none !important; outline: none !important;
                                        padding: 0px 0px 0px 0px !important; text-align: center; outline: none;" runat="server"
                                        Text='<%# (Eval("ResidualShrinkage") == DBNull.Value  || (Eval("ResidualShrinkage").ToString().Trim() == string.Empty)) ? string.Empty : Eval("ResidualShrinkage").ToString().Trim() %>'></asp:TextBox>
                                </ItemTemplate>
                                <ItemStyle Width="50px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Balance In House" Visible="false">
                                <ItemTemplate>
                                    <%-- <div class="AccessToltip">
                                        <asp:Label ID="lblbalanceinhouseqty" Text='<%# (Eval("BalanceQty") == DBNull.Value  || (Eval("BalanceQty").ToString().Trim() == "0")) ? string.Empty : Eval("BalanceQty").ToString().Trim() %>'
                                            runat="server"></asp:Label>
                                        <asp:Label ID="lblBalanceTooltip" runat="server" Text=""></asp:Label>
                                    </div>--%>
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
                            <asp:TemplateField HeaderText="perior" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblpriorstageQty" Text='<%# (Eval("PirorStageQty") == DBNull.Value  || (Eval("PirorStageQty").ToString().Trim() == string.Empty) || (Eval("PirorStageQty").ToString().Trim() == "0")) ? string.Empty : Convert.ToInt32(Eval("PirorStageQty")).ToString("N0") %>'
                                        runat="server"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Width="80px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Total Qty. To Send" Visible="false">
                                <ItemTemplate>
                                </ItemTemplate>
                                <ItemStyle Width="80px" />
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
                            <asp:TemplateField HeaderText="Quantity_breakdown">
                                <ItemTemplate>
                                    <table border="0" cellpadding="0" cellspacing="0" class="Quantity_Breakdown_column">
                                        <tr>
                                            <td style="width: 60%; text-align: left; border: 1px solid #e2dddd99!important; border-top: 0!important;
                                                border-left: 0!important; padding-left: 5px; padding-left: 5px;">
                                                <span>To Order</span>
                                            </td>
                                            <td style="border: 1px solid #e2dddd99!important; border-left: 0!important; border-top: 0!important;
                                                border-right: 0!important;">
                                                <asp:Label ID="lblfabricQty" Style="float: right; margin-right: 10px;" runat="server"></asp:Label>
                                                <asp:Label ID="lblcutwastgae" Style="display: none" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 60%; text-align: left; border: 1px solid #e2dddd99!important; border-top: 0!important;
                                                border-left: 0!important; padding-left: 5px; padding-left: 5px;">
                                                <span>To Receive (After Shr./ Waste.)</span>
                                            </td>
                                            <td style="border: 1px solid #e2dddd99!important; border-left: 0!important; border-top: 0!important;
                                                border-right: 0!important;">
                                                <asp:Label ID="lblrequiredqty" title="Click here to view wastage details & get required quantity"
                                                    Style="float: right; margin-right: 10px; color: blue; cursor: pointer;" CssClass="clfabqty"
                                                    runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 60%; text-align: left; border: 1px solid #e2dddd99!important; border-top: 0!important;
                                                border-left: 0!important; padding-left: 5px;">
                                                <span>Stock in House</span>
                                            </td>
                                            <td style="border: 1px solid #e2dddd99!important; border-left: 0!important; border-top: 0!important;
                                                border-right: 0!important;">
                                                <asp:Label ID="lblbalanceinhouseqty" Text='<%# (Eval("BalanceQty") == DBNull.Value  || (Eval("BalanceQty").ToString().Trim() == "0")) ? string.Empty : Eval("BalanceQty").ToString().Trim() %>'
                                                    runat="server" Style="float: right; margin-right: 10px;"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr id="balancetooltipp" runat="server" style="display: none">
                                            <td style="text-align: left; border: 1px solid #e2dddd99!important; border-left: 0!important;
                                                border-top: 0!important; padding-left: 5px;">
                                                <asp:Label ID="lblBalanceTooltip" runat="server" Text=""></asp:Label>
                                            </td>
                                            <td style="border: 1px solid #e2dddd99!important; border-left: 0!important; border-top: 0!important;
                                                border-right: 0!important; text-align: right; padding-right: 10px;">
                                                <asp:Label ID="lbladjustmentqtyy" runat="server" Text=""></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 60%; text-align: left; border: 1px solid #e2dddd99!important; border-top: 0!important;
                                                border-left: 0!important; padding-left: 5px;">
                                                <span>PO Ordered (send)</span>
                                            </td>
                                            <td style="border: 1px solid #e2dddd99!important; border-left: 0!important; border-top: 0!important;
                                                border-right: 0!important;">
                                                <asp:Label ID="txtqtytosend" Enabled="false" Style="float: right; margin-right: 10px;"
                                                    runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 60%; text-align: left; border: 1px solid #e2dddd99!important; border-top: 0!important;
                                                border-left: 0!important; padding-left: 5px;">
                                                <span>Total Po To Receive</span>
                                            </td>
                                            <td style="border: 1px solid #e2dddd99!important; border-left: 0!important; border-top: 0!important;
                                                border-right: 0!important;">
                                                <asp:Label runat="server" ID="ToReceive_print" Style="float: right; margin-right: 10px;"></asp:Label>
                                            </td>
                                        </tr>
                                         <tr runat="server" id="trArchieveRow" visible="false">
                                            <td style="width: 60%; text-align: left; border: 1px solid #e2dddd99!important; border-top: 0!important;
                                                border-left: 0!important; padding-left: 5px; padding-left: 5px;">
                                                <span>Cut Issued Qty</span>
                                            </td>
                                            <td style="border: 1px solid #e2dddd99!important; border-left: 0!important; border-top: 0!important;
                                                border-right: 0!important;">
                                                <asp:Label runat="server" ID="lblArchieveQty" Style="float: right; margin-right: 10px;"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" style="text-align: left; border: 1px solid #e2dddd99!important; border-left: 0!important;
                                                border-top: 0!important; border-right: 0!important; padding-left: 5px;">
                                                <span style="width: 60%; display: inline-block;">Pending to Order</span>
                                                <asp:Label ID="pendingQtyinorder" runat="server" onclick="var split=id.split('pendingQtyinorder');$('#'+split[0]+'quantity_breakdown_print').css('display','inline-table');"
                                                    Style="color: blue; float: right; margin-right: 10px; cursor: pointer"></asp:Label>
                                                <span><a id="lnkProductionpopup" runat="server" style="font-size: 8px; position: relative;
                                                    top: -4px; float: right; margin: 0 10px;">
                                                    <img src="../../App_Themes/ikandi/images/zoom_icon1.gif" style="cursor: pointer;" />
                                                </a></span><span>
                                                    <asp:Button ID="Button1" Style="display: none;" runat="server" Text="R.PO" />
                                                    <div class="btnrpo tooltip" runat="server" id="divraise">
                                                        R.PO
                                                    </div>
                                                </span>
                                                <table id="quantity_breakdown_print" style="display: none; position: relative; margin-top: 12px;"
                                                    runat="server">
                                                    <tr>
                                                        <th>
                                                            Actual
                                                        </th>
                                                        <th>
                                                            Shipped But Not Complete Issued
                                                        </th>
                                                        <th>
                                                            Shipped And Issued
                                                        </th>
                                                        <th>
                                                            Total
                                                        </th>
                                                        <th onclick="$('#'+$(this).closest('table').attr('id')).css('display','none');" style="position: absolute;
                                                            right: 0; top: -12px; padding: 0px 8px; border-left: 1px solid grey; border-bottom: 0;
                                                            cursor: pointer">
                                                            X
                                                        </th>
                                                    </tr>
                                                    <tr>
                                                        <td style="border: 1px solid lightgray;">
                                                            <%# Eval("Actual") %>
                                                        </td>
                                                        <td style="border: 1px solid lightgray;">
                                                            <%# Eval("ShippedButNotIssued") %>
                                                        </td>
                                                        <td style="border: 1px solid lightgray;">
                                                            <%# Eval("ShippedAndIssued") %>
                                                        </td>
                                                        <td style="border: 1px solid lightgray;">
                                                            <%# Eval("Total") %>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="4" style="color: gray;">
                                                            Please Check Fabric Avg. Also.
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                                <ItemStyle Width="270px" />
                            </asp:TemplateField>
                        </Columns>
                        <EmptyDataTemplate>
                            <table cellspacing="0" rules="all" class="greigegrd greigegrdbor nobordertd" border="0"
                                id="ctl00_cph_main_content_grdPRINT" style="border-width: 0px; width: 100%; border-collapse: collapse;">
                                <tbody>
                                    <tr class="HeaderClass">
                                        <td align="center" style="min-width: 200px;">
                                            <table>
                                                <tbody>
                                                    <tr>
                                                        <td colspan="3" style="border: 0px;">
                                                            Fabric Quality (GSM) C&amp;C Width<br>
                                                            Color/Print (Unit)
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            Current Stage
                                                        </td>
                                                        <td>
                                                            Previous Stage
                                                        </td>
                                                        <td>
                                                            Style Specific
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </td>
                                        <td align="center" style="min-width: 150px;">
                                            Style No. (Serial No.)
                                        </td>
                                        <td align="center" style="width: 60px;">
                                            <table>
                                                <tbody>
                                                    <tr>
                                                        <td style="border: 0px">
                                                            Qty to order
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            Qty To Received
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </td>
                                        <td align="center" style="width: 40px;">
                                            Balance
                                            <br>
                                            In House
                                        </td>
                                        <td align="center" style="width: 80px;">
                                            Total In House
                                        </td>
                                        <td align="center" style="width: 80px;">
                                            Total Send
                                        </td>
                                        <td align="left" style="width: 80px;">
                                            PO Number
                                        </td>
                                        <td align="left" style="min-width: 130px;">
                                            PO Supplier Name
                                        </td>
                                        <td align="center" style="width: 60px;">
                                            Rcvd. Qty.
                                        </td>
                                        <td align="center" class="widthAction">
                                            Revise PO
                                        </td>
                                        <td align="center" class="widthPending">
                                            Qty. to Raise PO
                                        </td>
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
                </div>
                <div id="DivFINISHED" runat="server" style="display: none;">
                    <asp:GridView ID="grdFINISHED" ShowHeader="false" runat="server" AutoGenerateColumns="False"
                        EmptyDataText="No Record Found!" Width="100%" HeaderStyle-Font-Names="Arial"
                        HeaderStyle-HorizontalAlign="Center" CssClass="greigegrdbor" BorderWidth="0"
                        rules="all" OnRowDataBound="grdFINISHED_RowDataBound" HeaderStyle-CssClass="ths">
                        <SelectedRowStyle BackColor="#A1DCF2" />
                        <EditRowStyle CssClass="EmpltyTable" />
                        <Columns>
                            <asp:TemplateField HeaderText="Fabric Quality">
                                <ItemStyle CssClass="textLeft GriegeStageRe" Width="140px" />
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <asp:Label ID="recqty" Style="display: none;" runat="server"></asp:Label>
                                    <asp:HiddenField ID="hdnfabricQuality" runat="server" Value='<%# Eval("FabricQualityID")%>' />
                                    <asp:Label ID="lblFabricQuality" ForeColor="blue" CssClass="color_black classfabsave"
                                        Text='<%# Eval("FabricName")%>' runat="server"></asp:Label>
                                    <asp:Label ID="lblUnit" CssClass="gray" Font-Bold="true" ForeColor="gray" runat="server"
                                        Text='<%# Eval("UnitName").ToString() == "" ? "" : Eval("UnitName")%>'></asp:Label>
                                    <asp:HiddenField ID="hdncutwastage" runat="server" />
                                    <asp:HiddenField ID="hdnResidualShrinkage" runat="server" Value='<%# (Eval("ResidualShrinkage") == DBNull.Value  || (Eval("ResidualShrinkage").ToString().Trim() == string.Empty)) ? string.Empty : Eval("ResidualShrinkage").ToString().Trim() %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="CountConstruction">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <asp:Label ID="lblcountconstraction" CssClass="gray" Text='<%# Eval("CountConstruction").ToString()%>'
                                        runat="server"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="GSM">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <asp:Label ID="lblgsm" CssClass="gray" Text='<%# Eval("GSM")%>' runat="server"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Width">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <asp:Label ID="lblwidth" CssClass="gray" Text='<%# Eval("width").ToString()+"&quot" + " in" %>'
                                        runat="server"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ColorPrint">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <asp:Label ID="lblfabriccolor" CssClass="color_black" Font-Bold="true" ForeColor="black"
                                        Text='<%# Eval("ColorPrint").ToString() %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle CssClass="textLeft" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Style No.">
                                <ItemTemplate>
                                    <asp:GridView ID="grdstylenumber" ShowHeader="false" runat="server" AutoGenerateColumns="False"
                                        EmptyDataText="No Record Found!" Width="98%" HeaderStyle-Font-Names="Arial" HeaderStyle-HorizontalAlign="Center"
                                        CssClass="" BorderWidth="0" rules="all" HeaderStyle-CssClass="ths">
                                        <SelectedRowStyle BackColor="#A1DCF2" />
                                        <RowStyle CssClass="DyedRowCount" />
                                        <Columns>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:HiddenField ID="hdnStyleid" runat="server" Value='<%# Eval("StyleID")%>' />
                                                    <asp:Label ID="lblStyleNumber" Text='<%# Eval("StyleNumber")%>' runat="server" Style="text-align: left;"></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle CssClass="borderDy textLeft" />
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </ItemTemplate>
                                <ItemStyle Width="70px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="SerialNumber">
                                <ItemTemplate>
                                    <asp:GridView ID="grdserialnumber" ShowHeader="false" runat="server" AutoGenerateColumns="False"
                                        EmptyDataText="No Record Found!" Width="98%" HeaderStyle-Font-Names="Arial" HeaderStyle-HorizontalAlign="Center"
                                        CssClass="" BorderWidth="0" rules="all" HeaderStyle-CssClass="ths">
                                        <SelectedRowStyle BackColor="#A1DCF2" />
                                        <RowStyle CssClass="DyedRowCount" />
                                        <Columns>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSerialNumber" Text='<%# Eval("SerialNumber")%>' runat="server"></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle CssClass="borderDy textLeft" />
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </ItemTemplate>
                                <ItemStyle Width="70px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Qty to order" Visible="false">
                                <ItemTemplate>
                                </ItemTemplate>
                                <ItemStyle Width="70px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Finish" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblfinish" CssClass="color_black" Visible="false" Text='<%# (Eval("ResidualShrinkage") == DBNull.Value  || (Eval("ResidualShrinkage").ToString().Trim() == string.Empty)) ? string.Empty : Eval("ResidualShrinkage").ToString().Trim() %>'
                                        runat="server"></asp:Label>
                                    <asp:TextBox ID="txtFinishedResidualShrinkage" onkeypress="return validateFloatKeyPress(this,event);"
                                        onchange="updateresidual(this)" Style="width: 90% !important; text-align: center;"
                                        runat="server" Text='<%# (Eval("ResidualShrinkage") == DBNull.Value  || (Eval("ResidualShrinkage").ToString().Trim() == string.Empty)) ? string.Empty : Eval("ResidualShrinkage").ToString().Trim() %>'></asp:TextBox>
                                </ItemTemplate>
                                <ItemStyle Width="50px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Balance In House" Visible="false">
                                <ItemTemplate>
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
                            <asp:TemplateField HeaderText="Quantity Breakdown">
                                <ItemTemplate>
                                    <table border="0" cellpadding="0" cellspacing="0" class="Quantity_Breakdown_column">
                                        <tr>
                                            <td style="width: 60%; text-align: left; border: 1px solid #e2dddd99!important; border-top: 0!important;
                                                border-left: 0!important; padding-left: 5px;">
                                                <span>To Order</span>
                                            </td>
                                            <td style="border: 1px solid #e2dddd99!important; border-left: 0!important; border-top: 0!important;
                                                border-right: 0!important;">
                                                <asp:Label ID="lblfabricorderavg2" Style="float: right; margin-right: 10px;" runat="server"></asp:Label>
                                                <asp:HiddenField ID="hdnfabricQualityresi" runat="server" Value='<%# Eval("FabricQualityID")%>' />
                                                <asp:HiddenField ID="hdnfanricdetails" runat="server" Value='<%# Eval("ColorPrint")%>' />
                                                <asp:Label ID="lblfabricorderavg" Style="display: none;" runat="server"></asp:Label>
                                                <asp:HiddenField ID="hdnfabprint" runat="server" Value='<%# Eval("ColorPrint").ToString() %>' />
                                                <asp:HiddenField ID="hdnstage1" runat="server" Value='<%# Eval("Stage1")%>' />
                                                <asp:HiddenField ID="hdnstage2" runat="server" Value='<%# Eval("Stage2")%>' />
                                                <asp:HiddenField ID="hdnstage3" runat="server" Value='<%# Eval("Stage3")%>' />
                                                <asp:HiddenField ID="hdnstage4" runat="server" Value='<%# Eval("Stage4")%>' />
                                                <asp:HiddenField ID="hdnadjustmentqty" runat="server" Value='<%# Eval("adjustmentqty")%>' />
                                                <asp:Label ID="lblcutwastgae" Style="display: none" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 60%; text-align: left; border: 1px solid #e2dddd99!important; border-top: 0!important;
                                                border-left: 0!important; padding-left: 5px;">
                                                <span>To Receive (After Shr./ Waste.)</span>
                                            </td>
                                            <td style="border: 1px solid #e2dddd99!important; border-left: 0!important; border-top: 0!important;
                                                border-right: 0!important;">
                                                <asp:Label ID="lblrequiredqty" title="Click here to view wastage details & get required quantity"
                                                    Style="float: right; margin-right: 10px; color: blue; cursor: pointer;" CssClass="clfabqty"
                                                    runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 60%; text-align: left; border: 1px solid #e2dddd99!important; border-top: 0!important;
                                                border-left: 0!important; padding-left: 5px;">
                                                <span>Stock in House</span>
                                            </td>
                                            <td style="border: 1px solid #e2dddd99!important; border-left: 0!important; border-top: 0!important;
                                                border-right: 0!important;">
                                                <asp:Label ID="lblbalanceinhouseqty" Text='<%# (Eval("BalanceQty") == DBNull.Value  || (Eval("BalanceQty").ToString().Trim() == "0")) ? string.Empty : Eval("BalanceQty").ToString().Trim() %>'
                                                    runat="server" Style="float: right; margin-right: 10px;"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr id="balancetooltipp" runat="server" style="display: none">
                                            <td style="text-align: left; border: 1px solid #e2dddd99!important; border-left: 0!important;
                                                border-top: 0!important; padding-left: 5px;">
                                                <asp:Label ID="lblBalanceTooltip" runat="server" Text=""></asp:Label>
                                            </td>
                                            <td style="border: 1px solid #e2dddd99!important; border-left: 0!important; border-top: 0!important;
                                                border-right: 0!important; text-align: right; padding-right: 10px;">
                                                <asp:Label ID="lbladjustmentqtyy" runat="server" Text=""></asp:Label>
                                            </td>
                                        </tr>
                                        <%--   <tr>
                                            <td style="text-align: left">
                                                <span style="width: 60%; display: inline-block;">PO Ordered (send)</span><span>:</span>
                                                <asp:Label ID="txtqtytosend" Enabled="false" Style="float: right; margin-right: 10px;"
                                                    runat="server"></asp:Label>
                                            </td>
                                        </tr>--%>
                                        <tr>
                                            <td style="width: 60%; text-align: left; border: 1px solid #e2dddd99!important; border-top: 0!important;
                                                border-left: 0!important; padding-left: 5px; padding-left: 5px;">
                                                <span>To Receive</span>
                                            </td>
                                            <td style="border: 1px solid #e2dddd99!important; border-left: 0!important; border-top: 0!important;
                                                border-right: 0!important;">
                                                <asp:Label runat="server" ID="ToReceive_finished" Style="float: right; margin-right: 10px;"></asp:Label>
                                            </td>
                                        </tr>
                                         <tr runat="server" id="trArchieveRow" visible="false">
                                            <td style="width: 60%; text-align: left; border: 1px solid #e2dddd99!important; border-top: 0!important;
                                                border-left: 0!important; padding-left: 5px; padding-left: 5px;">
                                                <span>Cut Issued Qty</span>
                                            </td>
                                            <td style="border: 1px solid #e2dddd99!important; border-left: 0!important; border-top: 0!important;
                                                border-right: 0!important;">
                                                <asp:Label runat="server" ID="lblArchieveQty" Style="float: right; margin-right: 10px;"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" style="text-align: left; border: 1px solid #e2dddd99!important; border-left: 0!important;
                                                border-top: 0!important; border-right: 0!important; padding-left: 5px;">
                                                <span>Pending to Order</span>
                                                <asp:Label ID="pendingQtyinorder" runat="server" onclick="var split=id.split('pendingQtyinorder');$('#'+split[0]+'quantity_breakdown_finished').css('display','inline-table');"
                                                    Style="color: blue; float: right; margin-right: 10px; cursor: pointer"></asp:Label>
                                                <span><a id="lnkProductionpopup" runat="server" style="font-size: 8px; position: relative;
                                                    top: -4px; float: right; margin: 0 10px;">
                                                    <img src="../../App_Themes/ikandi/images/zoom_icon1.gif" style="cursor: pointer;" />
                                                </a></span><span>
                                                    <asp:Button ID="Button1" Style="display: none;" runat="server" Text="R.PO" />
                                                    <div class="btnrpo tooltip" runat="server" id="divraise">
                                                        R.PO
                                                    </div>
                                                </span>
                                                <table id="quantity_breakdown_finished" style="display: none; position: relative;
                                                    margin-top: 12px;" runat="server">
                                                    <tr>
                                                        <th>
                                                            Actual
                                                        </th>
                                                        <th>
                                                            Shipped But Not Complete Issued
                                                        </th>
                                                        <th>
                                                            Shipped And Issued
                                                        </th>
                                                        <th>
                                                            Total
                                                        </th>
                                                        <th onclick="$('#'+$(this).closest('table').attr('id')).css('display','none');" style="position: absolute;
                                                            right: 0; top: -12px; padding: 0px 8px; border-left: 1px solid grey; border-bottom: 0;
                                                            cursor: pointer">
                                                            X
                                                        </th>
                                                    </tr>
                                                    <tr>
                                                        <td style="border: 1px solid lightgray;">
                                                            <%# Eval("Actual") %>
                                                        </td>
                                                        <td style="border: 1px solid lightgray;">
                                                            <%# Eval("ShippedButNotIssued") %>
                                                        </td>
                                                        <td style="border: 1px solid lightgray;">
                                                            <%# Eval("ShippedAndIssued") %>
                                                        </td>
                                                        <td style="border: 1px solid lightgray;">
                                                            <%# Eval("Total") %>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="4" style="color: gray;">
                                                            Please Check Fabric Avg. Also.
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                                <ItemStyle Width="270" />
                            </asp:TemplateField>
                        </Columns>
                        <EmptyDataTemplate>
                            <table cellspacing="0" rules="all" class="greigegrd greigegrdbor nobordertd" border="0"
                                id="ctl00_cph_main_content_grdgreigerasiepo" style="border-width: 0px; width: 100%;
                                border-collapse: collapse;">
                                <tbody>
                                    <tr class="HeaderClass">
                                        <td align="center" style="min-width: 200px; padding: 0px !important">
                                            <table>
                                                <tbody>
                                                    <tr>
                                                        <td colspan="3" style="border: 0px;">
                                                            Fabric Quality (GSM) C&amp;C Width<br>
                                                            Color/Print (Unit)
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            Current Stage
                                                        </td>
                                                        <td>
                                                            Previous Stage
                                                        </td>
                                                        <td>
                                                            Style Specific
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </td>
                                        <td align="center" style="min-width: 150px;">
                                            Style No. (Serial No.)
                                        </td>
                                        <td align="center" style="width: 60px;">
                                            <table>
                                                <tbody>
                                                    <tr>
                                                        <td style="border: 0px">
                                                            Qty to order
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            Qty To Received
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </td>
                                        <td align="center" style="width: 40px;">
                                            Balance
                                            <br>
                                            In House
                                        </td>
                                        <td align="center" style="width: 80px;">
                                            Total In House
                                        </td>
                                        <td align="center" style="width: 80px;">
                                            Total Send
                                        </td>
                                        <td align="left" style="width: 80px;">
                                            PO Number
                                        </td>
                                        <td align="left" style="min-width: 130px;">
                                            PO Supplier Name
                                        </td>
                                        <td align="center" style="width: 60px;">
                                            Rcvd. Qty.
                                        </td>
                                        <td align="center" class="widthAction">
                                            Revise PO
                                        </td>
                                        <td align="center" class="widthPending">
                                            Qty. to Raise PO
                                        </td>
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
                    </idv>
                </div>
                <div id="DivRFD" runat="server" style="display: none;">
                    <asp:GridView ID="grdRFD" ShowHeader="false" runat="server" AutoGenerateColumns="False"
                        EmptyDataText="No Record Found!" Width="100%" HeaderStyle-Font-Names="Arial"
                        CssClass="greigegrdbor grdgayeds FabRFDTable" HeaderStyle-HorizontalAlign="Center"
                        BorderWidth="0" rules="all" OnRowDataBound="grdRFD_RowDataBound" HeaderStyle-CssClass="ths">
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
                                    <asp:Label ID="lblUnit" CssClass="gray" Font-Bold="true" ForeColor="gray" runat="server"
                                        Text='<%# Eval("UnitName").ToString() == "" ? "" : Eval("UnitName")%>'></asp:Label>
                                    <asp:HiddenField ID="hdnCurrentstage" runat="server" Value='<%# Eval("CurrentStage")%>' />
                                    <asp:HiddenField ID="hdnperiviousstgae" runat="server" Value='<%# Eval("PreviousStage")%>' />
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
                            <asp:TemplateField HeaderText="CountConstruction">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <asp:Label ID="lblcountconstraction" CssClass="gray" Text='<%# Eval("CountConstruction").ToString()%>'
                                        runat="server"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="GSM">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <asp:Label ID="lblgsm" CssClass="gray" Text='<%# Eval("GSM")%>' runat="server"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Width">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <asp:Label ID="lblwidth" CssClass="gray" Text='<%# Eval("width").ToString()+"&quot" + " in" %>'
                                        runat="server"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ColorPrint">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <asp:Label ID="lblfabriccolor" CssClass="color_black" Font-Bold="true" ForeColor="black"
                                        Text='<%# Eval("ColorPrint").ToString() %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle CssClass="textLeft" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Style No.">
                                <ItemTemplate>
                                    <asp:GridView ID="grdstylenumber" ShowHeader="false" runat="server" AutoGenerateColumns="False"
                                        EmptyDataText="No Record Found!" Width="98%" HeaderStyle-Font-Names="Arial" HeaderStyle-HorizontalAlign="Center"
                                        CssClass="" BorderWidth="0" rules="all" HeaderStyle-CssClass="ths">
                                        <RowStyle CssClass="PrintRowCount" />
                                        <SelectedRowStyle BackColor="#A1DCF2" />
                                        <Columns>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:HiddenField ID="hdnfabricQuality" runat="server" Value='<%# Eval("Fabric_QualityID")%>' />
                                                    <asp:HiddenField ID="hdnStyleid" runat="server" Value='<%# Eval("StyleID")%>' />
                                                    <asp:Label ID="lblStyleNumber" Text='<%# Eval("StyleNumber")%>' runat="server" Style="text-align: left;"></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle CssClass="borderDy textLeft" />
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </ItemTemplate>
                                <ItemStyle Width="70px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Serial No.">
                                <ItemTemplate>
                                    <asp:GridView ID="grdserialnumber" ShowHeader="false" runat="server" AutoGenerateColumns="False"
                                        EmptyDataText="No Record Found!" Width="98%" HeaderStyle-Font-Names="Arial" HeaderStyle-HorizontalAlign="Center"
                                        CssClass="" BorderWidth="0" rules="all" HeaderStyle-CssClass="ths">
                                        <RowStyle CssClass="PrintRowCount" />
                                        <SelectedRowStyle BackColor="#A1DCF2" />
                                        <Columns>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSerialNumber" Text='<%# Eval("SerialNumber")%>' runat="server"></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle CssClass="borderDy textLeft" />
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </ItemTemplate>
                                <ItemStyle Width="70px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Qty to order" Visible="false">
                                <ItemTemplate>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Greige" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblGreige" CssClass="color_black" Visible="false" Text='<%# (Eval("GreigedShrinkage") == DBNull.Value  || (Eval("GreigedShrinkage").ToString().Trim() == string.Empty)) ? string.Empty : Eval("GreigedShrinkage").ToString().Trim() %>'
                                        runat="server"></asp:Label>
                                    <asp:TextBox ID="txtGreigeshrk" Enabled="false" CssClass="textboxAslabel" onchange="CalculateOnLoadPrint(1);"
                                        onkeypress="return validateFloatKeyPress(this,event);" Style="width: 90% !important;
                                        text-align: center;" runat="server" Text='<%# (Eval("GreigedShrinkage") == DBNull.Value  || (Eval("GreigedShrinkage").ToString().Trim() == string.Empty)) ? string.Empty : Eval("GreigedShrinkage").ToString().Trim() %>'></asp:TextBox>
                                </ItemTemplate>
                                <ItemStyle Width="50px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Residual" Visible="false">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtResidualShak" CssClass="textboxAslabel datesfileds" onchange="CalculateOnLoadPrint(1);"
                                        onkeypress="return validateFloatKeyPress(this,event);" Style="width: 90% !important;
                                        background: transparent !important; border: none !important; outline: none !important;
                                        padding: 0px 0px 0px 0px !important; text-align: center; outline: none;" runat="server"
                                        Text='<%# (Eval("ResidualShrinkage") == DBNull.Value  || (Eval("ResidualShrinkage").ToString().Trim() == string.Empty)) ? string.Empty : Eval("ResidualShrinkage").ToString().Trim() %>'></asp:TextBox>
                                </ItemTemplate>
                                <ItemStyle Width="50px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Balance In House" Visible="false">
                                <ItemTemplate>
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
                            <asp:TemplateField HeaderText="perior" Visible="false">
                                <%--total inhouse quantity for rfd commented--%>
                                <ItemTemplate>
                                    <asp:Label ID="lblpriorstageQty" Text='<%# (Eval("PirorStageQty") == DBNull.Value  || (Eval("PirorStageQty").ToString().Trim() == string.Empty) || (Eval("PirorStageQty").ToString().Trim() == "0")) ? string.Empty : Convert.ToInt32(Eval("PirorStageQty")).ToString("N0") %>'
                                        runat="server"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Width="80px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Total Qty. To Send" Visible="false">
                                <ItemTemplate>
                                </ItemTemplate>
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
                            <asp:TemplateField HeaderText="Quantity Breakdown">
                                <ItemTemplate>
                                    <table border="0" cellpadding="0" cellspacing="0" class="Quantity_Breakdown_column">
                                        <tr>
                                            <td style="width: 60%; text-align: left; border: 1px solid #e2dddd99!important; border-top: 0!important;
                                                border-left: 0!important; padding-left: 5px; padding-left: 5px;">
                                                <span>To Order</span>
                                            </td>
                                            <td style="border: 1px solid #e2dddd99!important; border-left: 0!important; border-top: 0!important;
                                                border-right: 0!important;">
                                                <asp:Label ID="lblfabricQty" Style="float: right; margin-right: 10px;" runat="server"></asp:Label>
                                                <asp:Label ID="lblcutwastgae" Style="display: none" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 60%; text-align: left; border: 1px solid #e2dddd99!important; border-top: 0!important;
                                                border-left: 0!important; padding-left: 5px; padding-left: 5px;">
                                                <span>To Receive (After Shr./ Waste.)</span>
                                            </td>
                                            <td style="border: 1px solid #e2dddd99!important; border-left: 0!important; border-top: 0!important;
                                                border-right: 0!important;">
                                                <asp:Label ID="lblrequiredqty" title="Click here to view wastage details & get required quantity"
                                                    Style="float: right; margin-right: 10px; color: blue; cursor: pointer;" CssClass="clfabqty"
                                                    runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 60%; text-align: left; border: 1px solid #e2dddd99!important; border-top: 0!important;
                                                border-left: 0!important; padding-left: 5px; padding-left: 5px;">
                                                <span>Stock in House</span>
                                            </td>
                                            <td style="border: 1px solid #e2dddd99!important; border-left: 0!important; border-top: 0!important;
                                                border-right: 0!important;">
                                                <asp:Label ID="lblbalanceinhouseqty" Text='<%# (Eval("BalanceQty") == DBNull.Value  || (Eval("BalanceQty").ToString().Trim() == "0")) ? string.Empty : Eval("BalanceQty").ToString().Trim() %>'
                                                    runat="server" Style="float: right; margin-right: 10px;"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr id="balancetooltipp" runat="server" style="display: none">
                                            <td style="text-align: left; border: 1px solid #e2dddd99!important; border-left: 0!important;
                                                border-top: 0!important; padding-left: 5px;">
                                                <asp:Label ID="lblBalanceTooltip" runat="server" Text=""></asp:Label>
                                            </td>
                                            <td style="border: 1px solid #e2dddd99!important; border-left: 0!important; border-top: 0!important;
                                                border-right: 0!important; text-align: right; padding-right: 10px;">
                                                <asp:Label ID="lbladjustmentqtyy" runat="server" Text=""></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 60%; text-align: left; border: 1px solid #e2dddd99!important; border-top: 0!important;
                                                border-left: 0!important; padding-left: 5px; padding-left: 5px;">
                                                <span>PO Ordered (send)</span>
                                            </td>
                                            <td style="border: 1px solid #e2dddd99!important; border-left: 0!important; border-top: 0!important;
                                                border-right: 0!important;">
                                                <asp:Label ID="txtqtytosend" Enabled="false" Style="float: right; margin-right: 10px;"
                                                    runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 60%; text-align: left; border: 1px solid #e2dddd99!important; border-top: 0!important;
                                                border-left: 0!important; padding-left: 5px; padding-left: 5px;">
                                                <span style="width: 60%; display: inline-block;">To Receive</span>
                                            </td>
                                            <td style="border: 1px solid #e2dddd99!important; border-left: 0!important; border-top: 0!important;
                                                border-right: 0!important;">
                                                <asp:Label runat="server" ID="ToReceive_rfd" Style="float: right; margin-right: 10px;"></asp:Label>
                                            </td>
                                        </tr>
                                         <tr runat="server" id="trArchieveRow" visible="false">
                                            <td style="width: 60%; text-align: left; border: 1px solid #e2dddd99!important; border-top: 0!important;
                                                border-left: 0!important; padding-left: 5px; padding-left: 5px;">
                                                <span>Cut Issued Qty</span>
                                            </td>
                                            <td style="border: 1px solid #e2dddd99!important; border-left: 0!important; border-top: 0!important;
                                                border-right: 0!important;">
                                                <asp:Label runat="server" ID="lblArchieveQty" Style="float: right; margin-right: 10px;"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" style="text-align: left; border: 1px solid #e2dddd99!important; border-left: 0!important;
                                                border-top: 0!important; border-right: 0!important; padding-left: 5px;">
                                                <span>Pending to Order</span>
                                                <asp:Label ID="pendingQtyinorder" runat="server" onclick="var split=id.split('pendingQtyinorder');$('#'+split[0]+'quantity_breakdown_rfd').css('display','inline-table');"
                                                    Style="color: blue; float: right; margin-right: 10px; cursor: pointer"></asp:Label>
                                                <span><a id="lnkProductionpopup" runat="server" style="font-size: 8px; position: relative;
                                                    top: -4px; float: right; margin: 0 10px;">
                                                    <img src="../../App_Themes/ikandi/images/zoom_icon1.gif" style="cursor: pointer;" />
                                                </a></span><span>
                                                    <asp:Button ID="Button1" Style="display: none;" runat="server" Text="R.PO" />
                                                    <div class="btnrpo tooltip" runat="server" id="divraise">
                                                        R.PO
                                                    </div>
                                                </span>
                                                <table id="quantity_breakdown_rfd" style="display: none; position: relative; margin-top: 12px;"
                                                    runat="server">
                                                    <tr>
                                                        <th>
                                                            Actual
                                                        </th>
                                                        <th>
                                                            Shipped But Not Complete Issued
                                                        </th>
                                                        <th>
                                                            Shipped And Issued
                                                        </th>
                                                        <th>
                                                            Total
                                                        </th>
                                                        <th onclick="$('#'+$(this).closest('table').attr('id')).css('display','none');" style="position: absolute;
                                                            right: 0; top: -12px; padding: 0px 8px; border-left: 1px solid grey; border-bottom: 0;
                                                            cursor: pointer">
                                                            X
                                                        </th>
                                                    </tr>
                                                    <tr>
                                                        <td style="border: 1px solid lightgray;">
                                                            <%# Eval("Actual") %>
                                                        </td>
                                                        <td style="border: 1px solid lightgray;">
                                                            <%# Eval("ShippedButNotIssued") %>
                                                        </td>
                                                        <td style="border: 1px solid lightgray;">
                                                            <%# Eval("ShippedAndIssued") %>
                                                        </td>
                                                        <td style="border: 1px solid lightgray;">
                                                            <%# Eval("Total") %>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="4" style="color: gray;">
                                                            Please Check Fabric Avg. Also.
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                                <ItemStyle Width="270px" />
                            </asp:TemplateField>
                        </Columns>
                        <EmptyDataTemplate>
                            <table cellspacing="0" rules="all" class="greigegrd greigegrdbor nobordertd" border="0"
                                id="ctl00_cph_main_content_grdPRINT" style="border-width: 0px; width: 100%; border-collapse: collapse;">
                                <tbody>
                                    <tr class="HeaderClass">
                                        <td align="center" style="min-width: 200px;">
                                            <table>
                                                <tbody>
                                                    <tr>
                                                        <td colspan="3" style="border: 0px;">
                                                            Fabric Quality (GSM) C&amp;C Width<br>
                                                            Color/Print (Unit)
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            Current Stage
                                                        </td>
                                                        <td>
                                                            Previous Stage
                                                        </td>
                                                        <td>
                                                            Style Specific
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </td>
                                        <td align="center" style="min-width: 150px;">
                                            Style No. (Serial No.)
                                        </td>
                                        <td align="center" style="width: 60px;">
                                            <table>
                                                <tbody>
                                                    <tr>
                                                        <td style="border: 0px">
                                                            Qty to order
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            Qty To Received
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </td>
                                        <td align="center" style="width: 40px;">
                                            Balance
                                            <br>
                                            In House
                                        </td>
                                        <td align="center" style="width: 80px;">
                                            Total In House
                                        </td>
                                        <td align="center" style="width: 80px;">
                                            Total Send
                                        </td>
                                        <td align="left" style="width: 80px;">
                                            PO Number
                                        </td>
                                        <td align="left" style="min-width: 130px;">
                                            PO Supplier Name
                                        </td>
                                        <td align="center" style="width: 60px;">
                                            Rcvd. Qty.
                                        </td>
                                        <td align="center" class="widthAction">
                                            Revise PO
                                        </td>
                                        <td align="center" class="widthPending">
                                            Qty. to Raise PO
                                        </td>
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
                </div>
                <div id="DivEMBELLISHMENT" runat="server" style="display: none;">
                    <asp:GridView ID="grdEMBELLISHMENT" class="grdgayeds" ShowHeader="false" runat="server"
                        AutoGenerateColumns="False" EmptyDataText="No Record Found!" Width="100%" HeaderStyle-Font-Names="Arial"
                        CssClass="greigegrdbor" HeaderStyle-HorizontalAlign="Center" BorderWidth="0"
                        rules="all" OnRowDataBound="grdEMBELLISHMENT_RowDataBound" HeaderStyle-CssClass="ths">
                        <SelectedRowStyle BackColor="#A1DCF2" />
                        <EditRowStyle CssClass="EmpltyTable" />
                        <Columns>
                            <asp:TemplateField HeaderText="Fabric Quality">
                                <ItemStyle Width="140px" CssClass="textLeft GriegeStageRe" />
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <asp:Label ID="recqty" Style="display: none;" runat="server"></asp:Label>
                                    <asp:HiddenField ID="hdnfabricQuality" runat="server" Value='<%# Eval("FabricQualityID")%>' />
                                    <asp:Label ID="lblFabricQuality" ForeColor="blue" CssClass="color_black classfabsave"
                                        Text='<%# Eval("FabricName")%>' runat="server"></asp:Label>
                                    <asp:Label ID="lblcolor" Style="display: none" CssClass="color_black" runat="server"
                                        Text='<%# Eval("ColorPrint").ToString() %>'></asp:Label>
                                    <asp:Label ID="lblUnit" CssClass="gray" Font-Bold="true" ForeColor="gray" runat="server"
                                        Text='<%# Eval("UnitName").ToString() == "" ? "" : Eval("UnitName")%>'></asp:Label>
                                    <asp:HiddenField ID="hdnCurrentstage" runat="server" Value='<%# Eval("CurrentStage")%>' />
                                    <asp:HiddenField ID="hdnperiviousstgae" runat="server" Value='<%# Eval("PreviousStage")%>' />
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
                            <asp:TemplateField HeaderText="CountConstruction">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <asp:Label ID="lblcountconstraction" CssClass="gray" Text='<%# Eval("CountConstruction").ToString()%>'
                                        runat="server"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="GSM">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <asp:Label ID="lblgsm" CssClass="gray" Text='<%# Eval("GSM") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Width">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <asp:Label ID="lblwidth" CssClass="gray" Text='<%# Eval("width").ToString()+"&quot" + " in" %>'
                                        runat="server"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ColorPrint">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <asp:Label ID="lblfabriccolor" CssClass="color_black" Font-Bold="true" ForeColor="black"
                                        Text='<%# Eval("ColorPrint").ToString() %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle CssClass="textLeft" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Style No">
                                <ItemTemplate>
                                    <asp:GridView ID="grdstylenumber" ShowHeader="false" runat="server" AutoGenerateColumns="False"
                                        EmptyDataText="No Record Found!" Width="98%" HeaderStyle-Font-Names="Arial" HeaderStyle-HorizontalAlign="Center"
                                        CssClass="" BorderWidth="0" rules="all" HeaderStyle-CssClass="ths">
                                        <RowStyle CssClass="PrintRowCount" />
                                        <SelectedRowStyle BackColor="#A1DCF2" />
                                        <Columns>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:HiddenField ID="hdnfabricQuality" runat="server" Value='<%# Eval("Fabric_QualityID")%>' />
                                                    <asp:HiddenField ID="hdnStyleid" runat="server" Value='<%# Eval("StyleID")%>' />
                                                    <asp:Label ID="lblStyleNumber" Text='<%# Eval("StyleNumber")%>' runat="server" Style="text-align: left;"></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle CssClass="borderDy textLeft" />
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </ItemTemplate>
                                <ItemStyle Width="70px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Serial No">
                                <ItemTemplate>
                                    <asp:GridView ID="grdserialnumber" ShowHeader="false" runat="server" AutoGenerateColumns="False"
                                        EmptyDataText="No Record Found!" Width="98%" HeaderStyle-Font-Names="Arial" HeaderStyle-HorizontalAlign="Center"
                                        CssClass="" BorderWidth="0" rules="all" HeaderStyle-CssClass="ths">
                                        <RowStyle CssClass="PrintRowCount" />
                                        <SelectedRowStyle BackColor="#A1DCF2" />
                                        <Columns>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <%-- <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />:<asp:Label--%>
                                                    <asp:Label ID="lblSerialNumber" Text='<%# Eval("SerialNumber") %>' runat="server"></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle CssClass="borderDy textLeft" />
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </ItemTemplate>
                                <ItemStyle Width="70px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Qty to order" Visible="false">
                                <ItemTemplate>
                                    <%--  <table border="0" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td style='border-bottom: 1px solid #e2dddd99'>
                                                <asp:Label ID="lblfabricQty" title="Click here to view wastage details & get required quantity"
                                                    runat="server"></asp:Label>
                                                <asp:Label ID="lblcutwastgae" Style="display: none" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblrequiredqty" title="Click here to view wastage details & get required quantity"
                                                    Style="color: blue; cursor: pointer;" CssClass="clfabqty" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>--%>
                                </ItemTemplate>
                                <ItemStyle Width="70px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Greige" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblGreige" CssClass="color_black" Visible="false" Text='<%# (Eval("GreigedShrinkage") == DBNull.Value  || (Eval("GreigedShrinkage").ToString().Trim() == string.Empty)) ? string.Empty : Eval("GreigedShrinkage").ToString().Trim() %>'
                                        runat="server"></asp:Label>
                                    <asp:TextBox ID="txtGreigeshrk" Enabled="false" CssClass="textboxAslabel" onchange="CalculateOnLoadPrint(1);"
                                        onkeypress="return validateFloatKeyPress(this,event);" Style="width: 90% !important;
                                        text-align: center;" runat="server" Text='<%# (Eval("GreigedShrinkage") == DBNull.Value  || (Eval("GreigedShrinkage").ToString().Trim() == string.Empty)) ? string.Empty : Eval("GreigedShrinkage").ToString().Trim() %>'></asp:TextBox>
                                </ItemTemplate>
                                <ItemStyle Width="50px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Residual" Visible="false">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtResidualShak" CssClass="textboxAslabel datesfileds" onchange="CalculateOnLoadPrint(1);"
                                        onkeypress="return validateFloatKeyPress(this,event);" Style="width: 90% !important;
                                        background: transparent !important; border: none !important; outline: none !important;
                                        padding: 0px 0px 0px 0px !important; text-align: center; outline: none;" runat="server"
                                        Text='<%# (Eval("ResidualShrinkage") == DBNull.Value  || (Eval("ResidualShrinkage").ToString().Trim() == string.Empty)) ? string.Empty : Eval("ResidualShrinkage").ToString().Trim() %>'></asp:TextBox>
                                </ItemTemplate>
                                <ItemStyle Width="50px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Balance In House" Visible="false">
                                <ItemTemplate>
                                    <%--<div class="AccessToltip">
                                        <asp:Label ID="lblbalanceinhouseqty" Text='<%# (Eval("BalanceQty") == DBNull.Value  || (Eval("BalanceQty").ToString().Trim() == "0")) ? string.Empty : Eval("BalanceQty").ToString().Trim() %>'
                                            runat="server"></asp:Label>
                                        <asp:Label ID="lblBalanceTooltip" runat="server" Text=""></asp:Label>
                                    </div>--%>
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
                            <asp:TemplateField HeaderText="perior" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblpriorstageQty" Text='<%# (Eval("PirorStageQty") == DBNull.Value  || (Eval("PirorStageQty").ToString().Trim() == string.Empty) || (Eval("PirorStageQty").ToString().Trim() == "0")) ? string.Empty : Convert.ToInt32(Eval("PirorStageQty")).ToString("N0") %>'
                                        runat="server"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Width="80px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Total Qty. To Send" Visible="false">
                                <ItemTemplate>
                                    <%--  <asp:TextBox ID="txtqtytosend" Enabled="false" onchange="CalculateOnLoad();" onkeypress="return validateFloatKeyPress(this,event);"
                                        Style="width: 90% !important; text-align: center;" runat="server"></asp:TextBox>--%>
                                </ItemTemplate>
                                <ItemStyle Width="80px" />
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
                            <asp:TemplateField HeaderText="Quantity Breakdown">
                                <ItemTemplate>
                                    <table border="0" cellpadding="0" cellspacing="0" class="Quantity_Breakdown_column">
                                        <tr>
                                            <td style="width: 60%; text-align: left; border: 1px solid #e2dddd99!important; border-top: 0!important;
                                                border-left: 0!important; padding-left: 5px; padding-left: 5px;">
                                                <span>To Order</span>
                                            </td>
                                            <td style="border: 1px solid #e2dddd99!important; border-left: 0!important; border-top: 0!important;
                                                border-right: 0!important;">
                                                <asp:Label ID="lblfabricQty" Style="float: right; margin-right: 10px;" runat="server"></asp:Label>
                                                <asp:Label ID="lblcutwastgae" Style="display: none" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 60%; text-align: left; border: 1px solid #e2dddd99!important; border-top: 0!important;
                                                border-left: 0!important; padding-left: 5px; padding-left: 5px;">
                                                <span>To Received (After Shr./ Waste.)</span>
                                            </td>
                                            <td style="border: 1px solid #e2dddd99!important; border-left: 0!important; border-top: 0!important;
                                                border-right: 0!important;">
                                                <asp:Label ID="lblrequiredqty" title="Click here to view wastage details & get required quantity"
                                                    Style="float: right; margin-right: 10px; color: blue; cursor: pointer;" CssClass="clfabqty"
                                                    runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 60%; text-align: left; border: 1px solid #e2dddd99!important; border-top: 0!important;
                                                border-left: 0!important; padding-left: 5px; padding-left: 5px;">
                                                <span>Stock in House</span>
                                            </td>
                                            <td style="border: 1px solid #e2dddd99!important; border-left: 0!important; border-top: 0!important;
                                                border-right: 0!important;">
                                                <asp:Label ID="lblbalanceinhouseqty" Text='<%# (Eval("BalanceQty") == DBNull.Value  || (Eval("BalanceQty").ToString().Trim() == "0")) ? string.Empty : Eval("BalanceQty").ToString().Trim() %>'
                                                    runat="server" Style="float: right; margin-right: 10px;"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr id="balancetooltipp" runat="server" style="display: none">
                                            <td style="text-align: left; border: 1px solid #e2dddd99!important; border-left: 0!important;
                                                border-top: 0!important; padding-left: 5px;">
                                                <asp:Label ID="lblBalanceTooltip" runat="server" Text=""></asp:Label>
                                            </td>
                                            <td style="border: 1px solid #e2dddd99!important; border-left: 0!important; border-top: 0!important;
                                                border-right: 0!important; text-align: right; padding-right: 10px;">
                                                <asp:Label ID="lbladjustmentqtyy" runat="server" Text=""></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 60%; text-align: left; border: 1px solid #e2dddd99!important; border-top: 0!important;
                                                border-left: 0!important; padding-left: 5px; padding-left: 5px;">
                                                <span>PO Ordered (send)</span>
                                            </td>
                                            <td style="border: 1px solid #e2dddd99!important; border-left: 0!important; border-top: 0!important;
                                                border-right: 0!important;">
                                                <asp:Label ID="txtqtytosend" Enabled="false" Style="float: right; margin-right: 10px;"
                                                    runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 60%; text-align: left; border: 1px solid #e2dddd99!important; border-top: 0!important;
                                                border-left: 0!important; padding-left: 5px; padding-left: 5px;">
                                                <span>To Receive</span>
                                            </td>
                                            <td style="border: 1px solid #e2dddd99!important; border-left: 0!important; border-top: 0!important;
                                                border-right: 0!important;">
                                                <asp:Label runat="server" ID="ToReceive_embellishment" Style="float: right; margin-right: 10px;"></asp:Label>
                                            </td>
                                        </tr>
                                         <tr runat="server" id="trArchieveRow" visible="false">
                                            <td style="width: 60%; text-align: left; border: 1px solid #e2dddd99!important; border-top: 0!important;
                                                border-left: 0!important; padding-left: 5px; padding-left: 5px;">
                                                <span>Cut Issued Qty</span>
                                            </td>
                                            <td style="border: 1px solid #e2dddd99!important; border-left: 0!important; border-top: 0!important;
                                                border-right: 0!important;">
                                                <asp:Label runat="server" ID="lblArchieveQty" Style="float: right; margin-right: 10px;"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" style="text-align: left; border: 1px solid #e2dddd99!important; border-left: 0!important;
                                                border-top: 0!important; border-right: 0!important; padding-left: 5px;">
                                                <span>Pending to Order</span>
                                                <asp:Label ID="pendingQtyinorder" runat="server" onclick="var split=id.split('pendingQtyinorder');$('#'+split[0]+'quantity_breakdown_embellishment').css('display','inline-table');"
                                                    Style="color: blue; float: right; margin-right: 10px; cursor: pointer"></asp:Label>
                                                <span><a id="lnkProductionpopup" runat="server" style="font-size: 8px; position: relative;
                                                    top: -4px; float: right; margin: 0 10px;">
                                                    <img src="../../App_Themes/ikandi/images/zoom_icon1.gif" style="cursor: pointer;" />
                                                </a></span><span>
                                                    <asp:Button ID="Button1" Style="display: none;" runat="server" Text="R.PO" />
                                                    <div class="btnrpo tooltip" runat="server" id="divraise">
                                                        R.PO
                                                    </div>
                                                </span>
                                                <table id="quantity_breakdown_embellishment" style="display: none; position: relative;
                                                    margin-top: 12px;" runat="server">
                                                    <tr>
                                                        <th>
                                                            Actual
                                                        </th>
                                                        <th>
                                                            Shipped But Not Complete Issued
                                                        </th>
                                                        <th>
                                                            Shipped And Issued
                                                        </th>
                                                        <th>
                                                            Total
                                                        </th>
                                                        <th onclick="$('#'+$(this).closest('table').attr('id')).css('display','none');" style="position: absolute;
                                                            right: 0; top: -12px; padding: 0px 8px; border-left: 1px solid grey; border-bottom: 0;
                                                            cursor: pointer">
                                                            X
                                                        </th>
                                                    </tr>
                                                    <tr>
                                                        <td style="border: 1px solid lightgray;">
                                                            <%# Eval("Actual") %>
                                                        </td>
                                                        <td style="border: 1px solid lightgray;">
                                                            <%# Eval("ShippedButNotIssued") %>
                                                        </td>
                                                        <td style="border: 1px solid lightgray;">
                                                            <%# Eval("ShippedAndIssued") %>
                                                        </td>
                                                        <td style="border: 1px solid lightgray;">
                                                            <%# Eval("Total") %>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="4" style="color: gray;">
                                                            Please Check Fabric Avg. Also.
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                                <ItemStyle Width="270px" />
                            </asp:TemplateField>
                        </Columns>
                        <EmptyDataTemplate>
                            <table cellspacing="0" rules="all" class="greigegrd greigegrdbor nobordertd" border="0"
                                id="ctl00_cph_main_content_grdPRINT" style="border-width: 0px; width: 100%; border-collapse: collapse;">
                                <tbody>
                                    <tr class="HeaderClass">
                                        <td align="center" style="min-width: 200px;">
                                            <table>
                                                <tbody>
                                                    <tr>
                                                        <td colspan="3" style="border: 0px;">
                                                            Fabric Quality (GSM) C&amp;C Width<br>
                                                            Color/Print (Unit)
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            Current Stage
                                                        </td>
                                                        <td>
                                                            Previous Stage
                                                        </td>
                                                        <td>
                                                            Style Specific
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </td>
                                        <td align="center" style="min-width: 150px;">
                                            Style No. (Serial No.)
                                        </td>
                                        <td align="center" style="width: 60px;">
                                            <table>
                                                <tbody>
                                                    <tr>
                                                        <td style="border: 0px">
                                                            Qty to order
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            Qty To Received
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </td>
                                        <td align="center" style="width: 40px;">
                                            Balance
                                            <br>
                                            In House
                                        </td>
                                        <td align="center" style="width: 80px;">
                                            Total In House
                                        </td>
                                        <td align="center" style="width: 80px;">
                                            Total Send
                                        </td>
                                        <td align="left" style="width: 80px;">
                                            PO Number
                                        </td>
                                        <td align="left" style="min-width: 130px;">
                                            PO Supplier Name
                                        </td>
                                        <td align="center" style="width: 60px;">
                                            Rcvd. Qty.
                                        </td>
                                        <td align="center" class="widthAction">
                                            Revise PO
                                        </td>
                                        <td align="center" class="widthPending">
                                            Qty. to Raise PO
                                        </td>
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
                </div>
                <div id="DivEMBROIDERY" runat="server" style="display: none;">
                    <asp:GridView ID="grdEMBROIDERY" class="grdgayeds" ShowHeader="false" runat="server"
                        AutoGenerateColumns="False" EmptyDataText="No Record Found!" Width="100%" HeaderStyle-Font-Names="Arial"
                        CssClass="greigegrdbor" HeaderStyle-HorizontalAlign="Center" BorderWidth="0"
                        rules="all" OnRowDataBound="grdEMBROIDERY_RowDataBound" HeaderStyle-CssClass="ths">
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
                                    <asp:Label ID="lblcolor" Style="display: none" CssClass="color_black" runat="server"
                                        Text='<%# Eval("ColorPrint").ToString() %>'></asp:Label>
                                    <asp:Label ID="lblUnit" CssClass="gray" Font-Bold="true" ForeColor="gray" runat="server"
                                        Text='<%# Eval("UnitName").ToString() == "" ? "" : Eval("UnitName")%>'></asp:Label>
                                    <asp:HiddenField ID="hdnCurrentstage" runat="server" Value='<%# Eval("CurrentStage")%>' />
                                    <asp:HiddenField ID="hdnperiviousstgae" runat="server" Value='<%# Eval("PreviousStage")%>' />
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
                            <asp:TemplateField HeaderText="CountConstruction">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <asp:Label ID="lblcountconstraction" CssClass="gray" Text='<%# Eval("CountConstruction").ToString()%>'
                                        runat="server"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="GSM">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <asp:Label ID="lblgsm" CssClass="gray" Text='<%# Eval("GSM")%>' runat="server"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Width">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <asp:Label ID="lblwidth" CssClass="gray" Text='<%# Eval("width").ToString()+"&quot" + " in" %>'
                                        runat="server"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ColorPrint">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <asp:Label ID="lblfabriccolor" CssClass="color_black" Font-Bold="true" ForeColor="black"
                                        Text='<%# Eval("ColorPrint").ToString() %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle CssClass="textLeft" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Style No.">
                                <ItemTemplate>
                                    <asp:GridView ID="grdstylenumber" ShowHeader="false" runat="server" AutoGenerateColumns="False"
                                        EmptyDataText="No Record Found!" Width="98%" HeaderStyle-Font-Names="Arial" HeaderStyle-HorizontalAlign="Center"
                                        CssClass="" BorderWidth="0" rules="all" HeaderStyle-CssClass="ths">
                                        <RowStyle CssClass="PrintRowCount" />
                                        <SelectedRowStyle BackColor="#A1DCF2" />
                                        <Columns>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:HiddenField ID="hdnfabricQuality" runat="server" Value='<%# Eval("Fabric_QualityID")%>' />
                                                    <asp:HiddenField ID="hdnStyleid" runat="server" Value='<%# Eval("StyleID")%>' />
                                                    <asp:Label ID="lblStyleNumber" Text='<%# Eval("StyleNumber")%>' runat="server" Style="text-align: left;"></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle CssClass="borderDy textLeft" />
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </ItemTemplate>
                                <ItemStyle Width="70px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Serial No.">
                                <ItemTemplate>
                                    <asp:GridView ID="grdserialnumber" ShowHeader="false" runat="server" AutoGenerateColumns="False"
                                        EmptyDataText="No Record Found!" Width="98%" HeaderStyle-Font-Names="Arial" HeaderStyle-HorizontalAlign="Center"
                                        CssClass="" BorderWidth="0" rules="all" HeaderStyle-CssClass="ths">
                                        <RowStyle CssClass="PrintRowCount" />
                                        <SelectedRowStyle BackColor="#A1DCF2" />
                                        <Columns>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSerialNumber" Text='<%# Eval("SerialNumber")%>' runat="server"></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle CssClass="borderDy textLeft" />
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </ItemTemplate>
                                <ItemStyle Width="70px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Qty to order" Visible="false">
                                <ItemTemplate>
                                </ItemTemplate>
                                <ItemStyle Width="70px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Greige" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblGreige" CssClass="color_black" Visible="false" Text='<%# (Eval("GreigedShrinkage") == DBNull.Value  || (Eval("GreigedShrinkage").ToString().Trim() == string.Empty)) ? string.Empty : Eval("GreigedShrinkage").ToString().Trim() %>'
                                        runat="server"></asp:Label>
                                    <asp:TextBox ID="txtGreigeshrk" Enabled="false" CssClass="textboxAslabel" onchange="CalculateOnLoadPrint(1);"
                                        onkeypress="return validateFloatKeyPress(this,event);" Style="width: 90% !important;
                                        text-align: center;" runat="server" Text='<%# (Eval("GreigedShrinkage") == DBNull.Value  || (Eval("GreigedShrinkage").ToString().Trim() == string.Empty)) ? string.Empty : Eval("GreigedShrinkage").ToString().Trim() %>'></asp:TextBox>
                                </ItemTemplate>
                                <ItemStyle Width="50px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Residual" Visible="false">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtResidualShak" CssClass="textboxAslabel datesfileds" onchange="CalculateOnLoadPrint(1);"
                                        onkeypress="return validateFloatKeyPress(this,event);" Style="width: 90% !important;
                                        background: transparent !important; border: none !important; outline: none !important;
                                        padding: 0px 0px 0px 0px !important; text-align: center; outline: none;" runat="server"
                                        Text='<%# (Eval("ResidualShrinkage") == DBNull.Value  || (Eval("ResidualShrinkage").ToString().Trim() == string.Empty)) ? string.Empty : Eval("ResidualShrinkage").ToString().Trim() %>'></asp:TextBox>
                                </ItemTemplate>
                                <ItemStyle Width="50px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Balance In House" Visible="false">
                                <ItemTemplate>
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
                            <asp:TemplateField HeaderText="perior" Visible="false">
                                <%--total inhouse qty commented--%>
                                <ItemTemplate>
                                    <%-- <asp:Label ID="lblpriorstageQty" Text='<%# (Eval("PirorStageQty") == DBNull.Value  || (Eval("PirorStageQty").ToString().Trim() == string.Empty) || (Eval("PirorStageQty").ToString().Trim() == "0")) ? string.Empty : Convert.ToInt32(Eval("PirorStageQty")).ToString("N0") %>'
                                        runat="server"></asp:Label>--%>
                                </ItemTemplate>
                                <ItemStyle Width="80px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Total Qty. To Send" Visible="false">
                                <ItemTemplate>
                                </ItemTemplate>
                                <ItemStyle Width="80px" />
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
                            <asp:TemplateField HeaderText="QuantityBreakdown">
                                <ItemTemplate>
                                    <table border="0" cellpadding="0" cellspacing="0" class="Quantity_Breakdown_column">
                                        <tr>
                                            <td style="width: 60%; text-align: left; border: 1px solid #e2dddd99!important; border-top: 0!important;
                                                border-left: 0!important; padding-left: 5px; padding-left: 5px;">
                                                <span>To Order</span>
                                            </td>
                                            <td style="border: 1px solid #e2dddd99!important; border-left: 0!important; border-top: 0!important;
                                                border-right: 0!important;">
                                                <asp:Label ID="lblfabricQty" Style="float: right; margin-right: 10px;" runat="server"></asp:Label>
                                                <asp:Label ID="lblcutwastgae" Style="display: none" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 60%; text-align: left; border: 1px solid #e2dddd99!important; border-top: 0!important;
                                                border-left: 0!important; padding-left: 5px; padding-left: 5px;">
                                                <span>To Received (After Shr./ Waste.)</span>
                                            </td>
                                            <td style="border: 1px solid #e2dddd99!important; border-left: 0!important; border-top: 0!important;
                                                border-right: 0!important;">
                                                <asp:Label ID="lblrequiredqty" title="Click here to view wastage details & get required quantity"
                                                    Style="float: right; margin-right: 10px; color: blue; cursor: pointer;" CssClass="clfabqty"
                                                    runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 60%; text-align: left; border: 1px solid #e2dddd99!important; border-top: 0!important;
                                                border-left: 0!important; padding-left: 5px; padding-left: 5px;">
                                                <span>Stock in House</span>
                                            </td>
                                            <td style="border: 1px solid #e2dddd99!important; border-left: 0!important; border-top: 0!important;
                                                border-right: 0!important;">
                                                <asp:Label ID="lblbalanceinhouseqty" Text='<%# (Eval("BalanceQty") == DBNull.Value  || (Eval("BalanceQty").ToString().Trim() == "0")) ? string.Empty : Eval("BalanceQty").ToString().Trim() %>'
                                                    runat="server" Style="float: right; margin-right: 10px;"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr id="balancetooltipp" runat="server" style="display: none">
                                            <td style="text-align: left; border: 1px solid #e2dddd99!important; border-left: 0!important;
                                                border-top: 0!important; padding-left: 5px;">
                                                <asp:Label ID="lblBalanceTooltip" runat="server" Text=""></asp:Label>
                                            </td>
                                            <td style="border: 1px solid #e2dddd99!important; border-left: 0!important; border-top: 0!important;
                                                border-right: 0!important; text-align: right; padding-right: 10px;">
                                                <asp:Label ID="lbladjustmentqtyy" runat="server" Text=""></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 60%; text-align: left; border: 1px solid #e2dddd99!important; border-top: 0!important;
                                                border-left: 0!important; padding-left: 5px; padding-left: 5px;">
                                                <span>PO Ordered (send)</span>
                                            </td>
                                            <td style="border: 1px solid #e2dddd99!important; border-left: 0!important; border-top: 0!important;
                                                border-right: 0!important;">
                                                <asp:Label ID="txtqtytosend" Enabled="false" Style="float: right; margin-right: 10px;"
                                                    runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 60%; text-align: left; border: 1px solid #e2dddd99!important; border-top: 0!important;
                                                border-left: 0!important; padding-left: 5px; padding-left: 5px;">
                                                <span>To Receive</span>
                                            </td>
                                            <td style="border: 1px solid #e2dddd99!important; border-left: 0!important; border-top: 0!important;
                                                border-right: 0!important;">
                                                <asp:Label runat="server" ID="ToReceive_embroidery" Style="float: right; margin-right: 10px;"></asp:Label>
                                            </td>
                                        </tr>
                                         <tr runat="server" id="trArchieveRow" visible="false">
                                            <td style="width: 60%; text-align: left; border: 1px solid #e2dddd99!important; border-top: 0!important;
                                                border-left: 0!important; padding-left: 5px; padding-left: 5px;">
                                                <span>Cut Issued Qty</span>
                                            </td>
                                            <td style="border: 1px solid #e2dddd99!important; border-left: 0!important; border-top: 0!important;
                                                border-right: 0!important;">
                                                <asp:Label runat="server" ID="lblArchieveQty" Style="float: right; margin-right: 10px;"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" style="text-align: left; border: 1px solid #e2dddd99!important; border-left: 0!important;
                                                border-top: 0!important; border-right: 0!important; padding-left: 5px;">
                                                <span>Pending to Order</span>
                                                <asp:Label ID="pendingQtyinorder" runat="server" onclick="var split=id.split('pendingQtyinorder');$('#'+split[0]+'quantity_breakdown_embroidery').css('display','inline-table');"
                                                    Style="color: blue; float: right; margin-right: 10px; cursor: pointer"></asp:Label>
                                                <span><a id="lnkProductionpopup" runat="server" style="font-size: 8px; position: relative;
                                                    top: -4px; float: right; margin: 0 10px;">
                                                    <img src="../../App_Themes/ikandi/images/zoom_icon1.gif" style="cursor: pointer;" />
                                                </a></span><span>
                                                    <asp:Button ID="Button1" Style="display: none;" runat="server" Text="R.PO" />
                                                    <div class="btnrpo tooltip" runat="server" id="divraise">
                                                        R.PO
                                                    </div>
                                                </span>
                                                <table id="quantity_breakdown_embroidery" style="display: none; position: relative;
                                                    margin-top: 12px;" runat="server">
                                                    <tr>
                                                        <th>
                                                            Actual
                                                        </th>
                                                        <th>
                                                            Shipped But Not Complete Issued
                                                        </th>
                                                        <th>
                                                            Shipped And Issued
                                                        </th>
                                                        <th>
                                                            Total
                                                        </th>
                                                        <th onclick="$('#'+$(this).closest('table').attr('id')).css('display','none');" style="position: absolute;
                                                            right: 0; top: -12px; padding: 0px 8px; border-left: 1px solid grey; border-bottom: 0;
                                                            cursor: pointer">
                                                            X
                                                        </th>
                                                    </tr>
                                                    <tr>
                                                        <td style="border: 1px solid lightgray;">
                                                            <%# Eval("Actual") %>
                                                        </td>
                                                        <td style="border: 1px solid lightgray;">
                                                            <%# Eval("ShippedButNotIssued") %>
                                                        </td>
                                                        <td style="border: 1px solid lightgray;">
                                                            <%# Eval("ShippedAndIssued") %>
                                                        </td>
                                                        <td style="border: 1px solid lightgray;">
                                                            <%# Eval("Total") %>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="4" style="color: gray;">
                                                            Please Check Fabric Avg. Also.
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                                <ItemStyle Width="270px" />
                            </asp:TemplateField>
                        </Columns>
                        <EmptyDataTemplate>
                            <table cellspacing="0" rules="all" class="greigegrd greigegrdbor nobordertd" border="0"
                                id="ctl00_cph_main_content_grdPRINT" style="border-width: 0px; width: 100%; border-collapse: collapse;">
                                <tbody>
                                    <tr class="HeaderClass">
                                        <td align="center" style="min-width: 200px;">
                                            <table>
                                                <tbody>
                                                    <tr>
                                                        <td colspan="3" style="border: 0px;">
                                                            Fabric Quality (GSM) C&amp;C Width<br>
                                                            Color/Print (Unit)
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            Current Stage
                                                        </td>
                                                        <td>
                                                            Previous Stage
                                                        </td>
                                                        <td>
                                                            Style Specific
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </td>
                                        <td align="center" style="min-width: 150px;">
                                            Style No. (Serial No.)
                                        </td>
                                        <td align="center" style="width: 60px;">
                                            <table>
                                                <tbody>
                                                    <tr>
                                                        <td style="border: 0px">
                                                            Qty to order
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            Qty To Received
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </td>
                                        <td align="center" style="width: 40px;">
                                            Balance
                                            <br>
                                            In House
                                        </td>
                                        <td align="center" style="width: 80px;">
                                            Total In House
                                        </td>
                                        <td align="center" style="width: 80px;">
                                            Total Send
                                        </td>
                                        <td align="left" style="width: 80px;">
                                            PO Number
                                        </td>
                                        <td align="left" style="min-width: 130px;">
                                            PO Supplier Name
                                        </td>
                                        <td align="center" style="width: 60px;">
                                            Rcvd. Qty.
                                        </td>
                                        <td align="center" class="widthAction">
                                            Revise PO
                                        </td>
                                        <td align="center" class="widthPending">
                                            Qty. to Raise PO
                                        </td>
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
                </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
