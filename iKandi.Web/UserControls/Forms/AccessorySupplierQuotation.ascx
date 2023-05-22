<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AccessorySupplierQuotation.ascx.cs"
    Inherits="iKandi.Web.UserControls.Forms.AccessorySupplierQuotation" %>
<link href="../../css/colorbox.css" rel="stylesheet" type="text/css" />
<link href="../../css/jquery-combined.css" rel="stylesheet" type="text/css" />
<link rel="stylesheet" type="text/css" href="../../css/jquery-combined.css" />
<style type="text/css">
    .modal
    {
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
    .modal-content
    {
        background-color: #fefefe;
        margin: auto;
        padding: 20px;
        border: 1px solid #888;
        width: 80%;
    }
    .dblock
    {
        display: block;
    }
    .dnone
    {
        display: none;
    }
    
    /* The Close Button */
    .close
    {
        color: #aaaaaa;
        float: right;
        font-size: 28px;
        font-weight: bold;
    }
    
    
    .close:hover, .close:focus
    {
        color: #000;
        text-decoration: none;
        cursor: pointer;
    }
    
    .Popuphide
    {
        display: none;
    }
    .Popupshow
    {
        display: block !important;
    }
    body
    {
        background: #f9f9fa none repeat scroll 0 0;
        font-family: Arial !important;
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
    
    /* table td table td
    {
        border-color: #ddd;
    }*/
    
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
        background: #fdfd96e0;
    }
    
    .Normaltextbox
    {
        border-color: White;
        width: 25% !important;
        border: 1px solid #999 !important;
        border-radius: 2px;
        height: 13px;
        color: Blue;
        font-size: 10px;
        text-align: center;
    }
    .NormaltextboxRed
    {
        border-color: White;
        width: 27% !important;
        border: 1px solid red !important;
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
        text-align: left;
    }
    /* Change background on mouse-over */
    
    .navbar a:hover
    {
        background: #ddd;
        color: black;
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
        font-family: Arial !important;
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
    table th
    {
        position: sticky;
        background-color: #dddfe4;
        border-top: 1px solid #999;
        border-bottom: 1px solid #999;
        border-right: 1px solid #999;
        position: -webkit-sticky;
        font-size: 10px;
        padding: 5px 0px;
        text-align: center;
        font-weight: 500;
        color: #575759;
        top: 149px;
    }
    
    /* Style the tab content */
    
    .tabcontent
    {
        display: none;
        padding: 6px 12px;
        border: 1px solid #ccc;
        border-top: none;
    }
    
    .ActiveAccessory
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
        width: 100%;
        min-width: 1200px;
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
    
    /* .grdgsmcom td:first-child
    {
        border-left-color: #999 !important;
        padding-left: 2px;
    }
    
    .grdgsmcom td:last-child
    {
        border-right-color: #999 !important;
    }
    
    .grdgsmcom tr:nth-last-child(1) > td
    {
        border-bottom-color: #999 !important;
    }*/
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
            width: 99.5% !important;
        }
    }
    .AccessoryGreigeTab
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
        width: 1148px;
        border-bottom: 0px solid #999;
        position: sticky;
        top: 149px;
        display: none;
    }
    .border_last_bottom_color
    {
        border-bottom-color: #999 !important;
        border-bottom: 1px solid #999 !important;
    }
    .grdgsmcom .EmptyRowStyle td[colspan="10"]
    {
        padding: 0px !important;
        border: 0px;
    }
    
    .EmptyRowStyle td th
    {
        background: #dddfe4;
        border-top: 0px;
    }
    .EmptyRowStyle td th:first-child
    {
        border-left: 0px;
    }
    .EmptyRowStyle td th:last-child
    {
        border-right: 0px;
    }
    .EmptyRowStyle td:first-child
    {
        border-left-color: #999 !important;
        padding: 0px !important;
    }
    .EmptyRowStyle table
    {
        width: 100%;
    }
    .word-space
    {
        word-spacing: 50px;
    }
    
    /* .innertablePo
    {
        border: 0px;
        width: 100%;
    }
    .innertablePo td
    {
        border: 0px;
        min-width: 43px;
        max-width: 43px;
        height: 15px;
    }
    .innertablePo td:last-child
    {
        min-width: 50px;
        max-width: 50px;
        height: 15px;
    }*/
</style>
<script type="text/javascript" src="../../js/form.js"></script>
<script src="../../js/jquery-1.9.0-jquery.min.js" type="text/javascript"></script>
<script src="../../js/jqueryui-1.9.1-jquery-ui.min.js" type="text/javascript"></script>
<script type="text/javascript" src="../../js/service.min.js"></script>
<script src="../../js/jquery-1.11.0.min.js" type="text/javascript"></script>
<link rel="stylesheet" type="text/css" href="../../css/jquery-combined.css" />
<script type="text/javascript" src="../../js/jquery-1.5.2-jquery.min.js"></script>
<script type="text/javascript" src="../../js/combined_jquery_scripts4.js"></script>
<script type="text/javascript" src="../../js/form.js"></script>
<script type="text/javascript">

    var SupplierId = -1;
    var AccessoryMasterId = -1;
    var AccessorySize = -1;
    var QuotedRate = -1;
    var QuotedLeadTime = -1;
    var ColorPrint = '';

    $(document).ready(function () {

        $(".tab1").click(function () {
            $(this).addClass('ActiveAccessory').siblings().removeClass('ActiveAccessory');
        });
        $("#AccessoryQuotationForm1_hdnTabAccessory").val('GRIEGE')

        $(".clsDivHdr").html("Pending Greige Orders Supplier View");
        $("#AccessoryQuotationForm1_grdGriege").show();
        $(".AccessoryGreigeTab").addClass('ActiveAccessory');
        $(".AccessoryProcessTab").removeClass('ActiveAccessory');
        $(".AccessoryFinishTab").removeClass('ActiveAccessory');
        $("#AccessoryQuotationForm1_grdProcess").hide();
        $("#AccessoryQuotationForm1_grdFinish").hide();

    });

    function ShowHideAccessorySuppliergrd(type) {
        //        //        alert('aaa');
        //        $("#AccessoryQuotationForm1_hdnTabAccessory").val(type);
        //        if (type == 'GRIEGE') {
        //            $("#AccessoryQuotationForm1_grdGriege").show();
        //            $(".AccessoryGreigeTab").addClass('ActiveAccessory');
        //            $(".AccessoryProcessTab").removeClass('ActiveAccessory');
        //            $(".AccessoryFinishTab").removeClass('ActiveAccessory');
        //            $("#AccessoryQuotationForm1_grdProcess").hide();
        //            $("#AccessoryQuotationForm1_grdFinish").hide();
        //            $("#AccessoryQuotationForm1_dvHeader").text('Pending Greige Orders Supplier View');
        //        }

        //        if (type == 'PROCESS') {
        //            $("#AccessoryQuotationForm1_grdGriege").hide();
        //            $(".AccessoryGreigeTab").removeClass('ActiveAccessory');
        //            $(".AccessoryProcessTab").addClass('ActiveAccessory');
        //            $(".AccessoryFinishTab").removeClass('ActiveAccessory');
        //            $("#AccessoryQuotationForm1_grdProcess").show();
        //            $("#AccessoryQuotationForm1_grdFinish").hide();
        //            $("#AccessoryQuotationForm1_dvHeader").text('Pending Process Orders Supplier View');
        //        }
        //        if (type == 'FINISHING') {
        //            $("#AccessoryQuotationForm1_grdGriege").hide();
        //            $(".AccessoryGreigeTab").removeClass('ActiveAccessory');
        //            $(".AccessoryProcessTab").removeClass('ActiveAccessory');
        //            $(".AccessoryFinishTab").addClass('ActiveAccessory');
        //            $("#AccessoryQuotationForm1_grdProcess").hide();
        //            $("#AccessoryQuotationForm1_grdFinish").show();
        //            $("#AccessoryQuotationForm1_dvHeader").text('Pending Finishing Orders Supplier View');
        //        }

    }

    function RestrictSpaceSpecial(e) {
        var regex = new RegExp("[0123456789.]");
        var key = String.fromCharCode(!event.charCode ? event.which : event.charCode);
        if (!regex.test(key)) {
            event.preventDefault();
            return false;
        }
    }


    function SaveAccessorySupplierQuotation(elem, type) {

        var Idsn = elem.id.split("_");
        var elemVal = $(elem).val();
        var Save = 0;
        if (type == 1) {
            SupplierId = $("#<%= grdGriege.ClientID %>_" + Idsn[2] + "_hdnSupplierID").val();
            AccessoryMasterId = $("#<%= grdGriege.ClientID %>_" + Idsn[2] + "_hdAccessoryMasterId").val();
            AccessorySize = $("#<%= grdGriege.ClientID %>_" + Idsn[2] + "_hdnAccessoryQualitySize").val();
            QuotedRate = $("#<%= grdGriege.ClientID %>_" + Idsn[2] + "_txtquotedval").val();
            QuotedLeadTime = $("#<%= grdGriege.ClientID %>_" + Idsn[2] + "_txtdays").val();
            ColorPrint = $("#<%= grdGriege.ClientID %>_" + Idsn[2] + "_hdnColorprint").val();
            //add code by bharat on 28/11/19
            if (QuotedRate != "") {
                if (QuotedLeadTime == "") {
                    $("#<%= grdGriege.ClientID %>_" + Idsn[2] + "_txtdays").removeClass("Normaltextbox");
                    $("#<%= grdGriege.ClientID %>_" + Idsn[2] + "_txtdays").addClass("NormaltextboxRed");
                } else {
                    $("#<%= grdGriege.ClientID %>_" + Idsn[2] + "_txtdays").removeClass("NormaltextboxRed");
                    $("#<%= grdGriege.ClientID %>_" + Idsn[2] + "_txtdays").addClass("Normaltextbox");
                }
            }
            else {
                $("#<%= grdGriege.ClientID %>_" + Idsn[2] + "_txtdays").removeClass("NormaltextboxRed");
                $("#<%= grdGriege.ClientID %>_" + Idsn[2] + "_txtdays").addClass("Normaltextbox");
            }
            //end
        }
        if (type == 2) {
            SupplierId = $("#<%= grdProcess.ClientID %>_" + Idsn[2] + "_hdnSupplierID").val();
            AccessoryMasterId = $("#<%= grdProcess.ClientID %>_" + Idsn[2] + "_hdAccessoryMasterId").val();
            AccessorySize = $("#<%= grdProcess.ClientID %>_" + Idsn[2] + "_hdnAccessoryQualitySize").val();
            QuotedRate = $("#<%= grdProcess.ClientID %>_" + Idsn[2] + "_txtquotedval").val();
            QuotedLeadTime = $("#<%= grdProcess.ClientID %>_" + Idsn[2] + "_txtdays").val();
            ColorPrint = $("#<%= grdProcess.ClientID %>_" + Idsn[2] + "_hdnColorprint").val();
            //add code by bharat on 28/11/19
            if (QuotedRate != "") {
                if (QuotedLeadTime == "") {
                    $("#<%= grdProcess.ClientID %>_" + Idsn[2] + "_txtdays").removeClass("Normaltextbox");
                    $("#<%= grdProcess.ClientID %>_" + Idsn[2] + "_txtdays").addClass("NormaltextboxRed");
                } else {
                    $("#<%= grdProcess.ClientID %>_" + Idsn[2] + "_txtdays").removeClass("NormaltextboxRed");
                    $("#<%= grdProcess.ClientID %>_" + Idsn[2] + "_txtdays").addClass("Normaltextbox");
                }
            }
            else {
                $("#<%= grdProcess.ClientID %>_" + Idsn[2] + "_txtdays").removeClass("NormaltextboxRed");
                $("#<%= grdProcess.ClientID %>_" + Idsn[2] + "_txtdays").addClass("Normaltextbox");
            }
            //end
        }
        if (type == 3) {
            SupplierId = $("#<%= grdFinish.ClientID %>_" + Idsn[2] + "_hdnSupplierID").val();
            AccessoryMasterId = $("#<%= grdFinish.ClientID %>_" + Idsn[2] + "_hdAccessoryMasterId").val();
            AccessorySize = $("#<%= grdFinish.ClientID %>_" + Idsn[2] + "_hdnAccessoryQualitySize").val();
            QuotedRate = $("#<%= grdFinish.ClientID %>_" + Idsn[2] + "_txtquotedval").val();
            QuotedLeadTime = $("#<%= grdFinish.ClientID %>_" + Idsn[2] + "_txtdays").val();
            ColorPrint = $("#<%= grdFinish.ClientID %>_" + Idsn[2] + "_hdnColorprint").val();
            //add code by bharat on 28/11/19
            if (QuotedRate != "") {
                if (QuotedLeadTime == "") {
                    $("#<%= grdFinish.ClientID %>_" + Idsn[2] + "_txtdays").removeClass("Normaltextbox");
                    $("#<%= grdFinish.ClientID %>_" + Idsn[2] + "_txtdays").addClass("NormaltextboxRed");
                } else {
                    $("#<%= grdFinish.ClientID %>_" + Idsn[2] + "_txtdays").removeClass("NormaltextboxRed");
                    $("#<%= grdFinish.ClientID %>_" + Idsn[2] + "_txtdays").addClass("Normaltextbox");
                }
            }
            else {
                $("#<%= grdFinish.ClientID %>_" + Idsn[2] + "_txtdays").removeClass("NormaltextboxRed");
                $("#<%= grdFinish.ClientID %>_" + Idsn[2] + "_txtdays").addClass("Normaltextbox");
            }
            //end
        }
        if (QuotedRate == '')
            QuotedRate = -1;

        if (QuotedLeadTime == '')
            QuotedLeadTime = -1;

        //        if (confirm("Are you sure want to update ?")) {
        proxy.invoke("Save_Accessory_Supplier_Quotation", { SupplierID: SupplierId, AccessoryMasterId: AccessoryMasterId, Size: AccessorySize, ColorPrint: ColorPrint, QuotedLandedRate: QuotedRate, type: type },
                function (result) {

                    if (parseInt(result) > 0) {
                        Save = 1;
                        $(elem).val(elemVal);
                    }
                });
        //}
        if (Save == 0) {
            $(elem).val('');
            jQuery.facebox('Some error occured during saving');
        }

    }
    function pageLoad() {
        //alert();
        // added code by bharat on 24-Sep 
        var AccmaxRow = 0;
        var AccrowSpan = 0;
        $('.AccGrdGriegeTable td[rowspan]').each(function () {
            var row = $(this).parent().parent().children().index($(this).parent());
            if (row > AccmaxRow) {
                AccmaxRow = row;
                AccrowSpan = 0;
            }
            if ($(this).attr('rowspan') > AccrowSpan) AccrowSpan = $(this).attr('rowspan');
        });
        if (AccmaxRow == $('.AccGrdGriegeTable tr:last td').parent().parent().children().index($('.AccGrdGriegeTable tr:last td').parent()) - (AccrowSpan - 1)) {
            $('.AccGrdGriegeTable td[rowspan]').each(function () {
                var row = $(this).parent().parent().children().index($(this).parent());
                if (row == AccmaxRow && $(this).attr('rowspan') == AccrowSpan) $(this).addClass('border_last_bottom_color');
            });
        }

        var AccmaxRowGCo = 0;
        var AccrowSpanGCo = 0;
        $('.AccGrdGriegeTable td[rowspan].AccGriegeColor').each(function () {
            var row = $(this).parent().parent().children().index($(this).parent());
            if (row > AccmaxRowGCo) {
                AccmaxRowGCo = row;
                AccrowSpanGCo = 0;
            }
            if ($(this).attr('rowspan') > AccrowSpanGCo) AccrowSpanGCo = $(this).attr('rowspan');
        });
        if (AccmaxRowGCo == $('.AccGrdGriegeTable tr:last td').parent().parent().children().index($('.AccGrdGriegeTable tr:last td').parent()) - (AccrowSpanGCo - 1)) {
            $('.AccGrdGriegeTable td[rowspan].AccGriegeColor').each(function () {
                var row = $(this).parent().parent().children().index($(this).parent());
                if (row == AccmaxRowGCo && $(this).attr('rowspan') == AccrowSpanGCo) $(this).addClass('border_last_bottom_color');
            });
        }

        var AccmaxRowGOr = 0;
        var AccrowSpanGOr = 0;
        $('.AccGrdGriegeTable td[rowspan].AccGriegeOrder').each(function () {
            var row = $(this).parent().parent().children().index($(this).parent());
            if (row > AccmaxRowGOr) {
                AccmaxRowGOr = row;
                AccrowSpanGOr = 0;
            }
            if ($(this).attr('rowspan') > AccrowSpanGOr) AccrowSpanGOr = $(this).attr('rowspan');
        });
        if (AccmaxRowGOr == $('.AccGrdGriegeTable tr:last td').parent().parent().children().index($('.AccGrdGriegeTable tr:last td').parent()) - (AccrowSpanGOr - 1)) {
            $('.AccGrdGriegeTable td[rowspan].AccGriegeOrder').each(function () {
                var row = $(this).parent().parent().children().index($(this).parent());
                if (row == AccmaxRowGOr && $(this).attr('rowspan') == AccrowSpanGOr) $(this).addClass('border_last_bottom_color');
            });
        }


        var AccmaxRowGSh = 0;
        var AccrowSpanGSh = 0;
        $('.AccGrdGriegeTable td[rowspan].GriAccessShrTable').each(function () {
            var row = $(this).parent().parent().children().index($(this).parent());
            if (row > AccmaxRowGSh) {
                AccmaxRowGSh = row;
                AccrowSpanGSh = 0;
            }
            if ($(this).attr('rowspan') > AccrowSpanGSh) AccrowSpanGSh = $(this).attr('rowspan');
        });
        if (AccmaxRowGSh == $('.AccGrdGriegeTable tr:last td').parent().parent().children().index($('.AccGrdGriegeTable tr:last td').parent()) - (AccrowSpanGSh - 1)) {
            $('.AccGrdGriegeTable td[rowspan].GriAccessShrTable').each(function () {
                var row = $(this).parent().parent().children().index($(this).parent());
                if (row == AccmaxRowGSh && $(this).attr('rowspan') == AccrowSpanGSh) $(this).addClass('border_last_bottom_color');
            });
        }

        var AccmaxRowGWa = 0;
        var AccrowSpanGWa = 0;
        $('.AccGrdGriegeTable td[rowspan].GriAccessWaTable').each(function () {
            var row = $(this).parent().parent().children().index($(this).parent());
            if (row > AccmaxRowGWa) {
                AccmaxRowGWa = row;
                AccrowSpanGWa = 0;
            }
            if ($(this).attr('rowspan') > AccrowSpanGWa) AccrowSpanGWa = $(this).attr('rowspan');
        });
        if (AccmaxRowGWa == $('.AccGrdGriegeTable tr:last td').parent().parent().children().index($('.AccGrdGriegeTable tr:last td').parent()) - (AccrowSpanGWa - 1)) {
            $('.AccGrdGriegeTable td[rowspan].GriAccessWaTable').each(function () {
                var row = $(this).parent().parent().children().index($(this).parent());
                if (row == AccmaxRowGWa && $(this).attr('rowspan') == AccrowSpanGWa) $(this).addClass('border_last_bottom_color');
            });
        }

        var AccmaxRowGRT = 0;
        var AccrowSpanGRT = 0;
        $('.AccGrdGriegeTable td[rowspan].GriAccessWaGRT').each(function () {
            var row = $(this).parent().parent().children().index($(this).parent());
            if (row > AccmaxRowGRT) {
                AccmaxRowGRT = row;
                AccrowSpanGRT = 0;
            }
            if ($(this).attr('rowspan') > AccrowSpanGRT) AccrowSpanGRT = $(this).attr('rowspan');
        });
        if (AccmaxRowGRT == $('.AccGrdGriegeTable tr:last td').parent().parent().children().index($('.AccGrdGriegeTable tr:last td').parent()) - (AccrowSpanGRT - 1)) {
            $('.AccGrdGriegeTable td[rowspan].GriAccessWaGRT').each(function () {
                var row = $(this).parent().parent().children().index($(this).parent());
                if (row == AccmaxRowGRT && $(this).attr('rowspan') == AccrowSpanGRT) $(this).addClass('border_last_bottom_color');
            });
        }

        var AccmaxRowPr = 0;
        var AccrowSpanPr = 0;
        $('.AccGrdProcessTable td[rowspan]').each(function () {
            var row = $(this).parent().parent().children().index($(this).parent());
            if (row > AccmaxRowPr) {
                AccmaxRowPr = row;
                AccrowSpanPr = 0;
            }
            if ($(this).attr('rowspan') > AccrowSpanPr) AccrowSpanPr = $(this).attr('rowspan');
        });
        if (AccmaxRowPr == $('.AccGrdProcessTable tr:last td').parent().parent().children().index($('.AccGrdProcessTable tr:last td').parent()) - (AccrowSpanPr - 1)) {
            $('.AccGrdProcessTable td[rowspan]').each(function () {
                var row = $(this).parent().parent().children().index($(this).parent());
                if (row == AccmaxRowPr && $(this).attr('rowspan') == AccrowSpanPr) $(this).addClass('border_last_bottom_color');
            });
        }

        var AccmaxRowPrin = 0;
        var AccrowSpanPrin = 0;
        $('.AccGrdProcessTable td[rowspan].ProAccessPrint').each(function () {
            var row = $(this).parent().parent().children().index($(this).parent());
            if (row > AccmaxRowPrin) {
                AccmaxRowPrin = row;
                AccrowSpanPrin = 0;
            }
            if ($(this).attr('rowspan') > AccrowSpanPrin) AccrowSpanPrin = $(this).attr('rowspan');
        });
        if (AccmaxRowPrin == $('.AccGrdProcessTable tr:last td').parent().parent().children().index($('.AccGrdProcessTable tr:last td').parent()) - (AccrowSpanPrin - 1)) {
            $('.AccGrdProcessTable td[rowspan].ProAccessPrint').each(function () {
                var row = $(this).parent().parent().children().index($(this).parent());
                if (row == AccmaxRowPrin && $(this).attr('rowspan') == AccrowSpanPrin) $(this).addClass('border_last_bottom_color');
            });
        }

        var AccmaxRowPQt = 0;
        var AccrowSpanPQt = 0;
        $('.AccGrdProcessTable td[rowspan].ProAccessQty').each(function () {
            var row = $(this).parent().parent().children().index($(this).parent());
            if (row > AccmaxRowPQt) {
                AccmaxRowPQt = row;
                AccrowSpanPQt = 0;
            }
            if ($(this).attr('rowspan') > AccrowSpanPQt) AccrowSpanPQt = $(this).attr('rowspan');
        });
        if (AccmaxRowPQt == $('.AccGrdProcessTable tr:last td').parent().parent().children().index($('.AccGrdProcessTable tr:last td').parent()) - (AccrowSpanPQt - 1)) {
            $('.AccGrdProcessTable td[rowspan].ProAccessQty').each(function () {
                var row = $(this).parent().parent().children().index($(this).parent());
                if (row == AccmaxRowPQt && $(this).attr('rowspan') == AccrowSpanPQt) $(this).addClass('border_last_bottom_color');
            });
        }

        var AccmaxRowPWa = 0;
        var AccrowSpanPWa = 0;
        $('.AccGrdProcessTable td[rowspan].ProAccessWaTable').each(function () {
            var row = $(this).parent().parent().children().index($(this).parent());
            if (row > AccmaxRowPWa) {
                AccmaxRowPWa = row;
                AccrowSpanPWa = 0;
            }
            if ($(this).attr('rowspan') > AccrowSpanPWa) AccrowSpanPWa = $(this).attr('rowspan');
        });
        if (AccmaxRowPWa == $('.AccGrdProcessTable tr:last td').parent().parent().children().index($('.AccGrdProcessTable tr:last td').parent()) - (AccrowSpanPWa - 1)) {
            $('.AccGrdProcessTable td[rowspan].ProAccessWaTable').each(function () {
                var row = $(this).parent().parent().children().index($(this).parent());
                if (row == AccmaxRowPWa && $(this).attr('rowspan') == AccrowSpanPWa) $(this).addClass('border_last_bottom_color');
            });
        }

        var AccmaxRowPSh = 0;
        var AccrowSpanPSh = 0;
        $('.AccGrdProcessTable td[rowspan].ProAccessShTable').each(function () {
            var row = $(this).parent().parent().children().index($(this).parent());
            if (row > AccmaxRowPSh) {
                AccmaxRowPSh = row;
                AccrowSpanPSh = 0;
            }
            if ($(this).attr('rowspan') > AccrowSpanPSh) AccrowSpanPSh = $(this).attr('rowspan');
        });
        if (AccmaxRowPSh == $('.AccGrdProcessTable tr:last td').parent().parent().children().index($('.AccGrdProcessTable tr:last td').parent()) - (AccrowSpanPSh - 1)) {
            $('.AccGrdProcessTable td[rowspan].ProAccessShTable').each(function () {
                var row = $(this).parent().parent().children().index($(this).parent());
                if (row == AccmaxRowPSh && $(this).attr('rowspan') == AccrowSpanPSh) $(this).addClass('border_last_bottom_color');
            });
        }

        var AccmaxRowBQt = 0;
        var AccrowSpanBQt = 0;
        $('.AccGrdProcessTable td[rowspan].GriegeTableProCol').each(function () {
            var row = $(this).parent().parent().children().index($(this).parent());
            if (row > AccmaxRowBQt) {
                AccmaxRowBQt = row;
                AccrowSpanBQt = 0;
            }
            if ($(this).attr('rowspan') > AccrowSpanBQt) AccrowSpanBQt = $(this).attr('rowspan');
        });
        if (AccmaxRowBQt == $('.AccGrdProcessTable tr:last td').parent().parent().children().index($('.AccGrdProcessTable tr:last td').parent()) - (AccrowSpanBQt - 1)) {
            $('.AccGrdProcessTable td[rowspan].GriegeTableProCol').each(function () {
                var row = $(this).parent().parent().children().index($(this).parent());
                if (row == AccmaxRowBQt && $(this).attr('rowspan') == AccrowSpanBQt) $(this).addClass('border_last_bottom_color');
            });
        }



        var AccmaxRowFi = 0;
        var AccrowSpanFi = 0;
        $('.AccGrdFinishTable td[rowspan]').each(function () {
            var row = $(this).parent().parent().children().index($(this).parent());
            if (row > AccmaxRowFi) {
                AccmaxRowFi = row;
                AccrowSpanFi = 0;
            }
            if ($(this).attr('rowspan') > AccrowSpanFi) AccrowSpanFi = $(this).attr('rowspan');
        });
        if (AccmaxRowFi == $('.AccGrdFinishTable tr:last td').parent().parent().children().index($('.AccGrdFinishTable tr:last td').parent()) - (AccrowSpanFi - 1)) {
            $('.AccGrdFinishTable td[rowspan]').each(function () {
                var row = $(this).parent().parent().children().index($(this).parent());
                if (row == AccmaxRowFi && $(this).attr('rowspan') == AccrowSpanFi) $(this).addClass('border_last_bottom_color');
            });
        }

        var AccmaxRowCol = 0;
        var AccrowSpanCol = 0;
        $('.AccGrdFinishTable td[rowspan].GriegeTableCol').each(function () {
            var row = $(this).parent().parent().children().index($(this).parent());
            if (row > AccmaxRowCol) {
                AccmaxRowCol = row;
                AccrowSpanCol = 0;
            }
            if ($(this).attr('rowspan') > AccrowSpanCol) AccrowSpanCol = $(this).attr('rowspan');
        });
        if (AccmaxRowCol == $('.AccGrdFinishTable tr:last td').parent().parent().children().index($('.AccGrdFinishTable tr:last td').parent()) - (AccrowSpanCol - 1)) {
            $('.AccGrdFinishTable td[rowspan].GriegeTableCol').each(function () {
                var row = $(this).parent().parent().children().index($(this).parent());
                if (row == AccmaxRowCol && $(this).attr('rowspan') == AccrowSpanCol) $(this).addClass('border_last_bottom_color');
            });
        }

        var AccmaxRowPCol = 0;
        var AccrowSpanPCol = 0;
        $('.AccGrdFinishTable td[rowspan].GriegeTableProCol').each(function () {
            var row = $(this).parent().parent().children().index($(this).parent());
            if (row > AccmaxRowCol) {
                AccmaxRowPCol = row;
                AccrowSpanPCol = 0;
            }
            if ($(this).attr('rowspan') > AccrowSpanPCol) AccrowSpanPCol = $(this).attr('rowspan');
        });
        if (AccmaxRowPCol == $('.AccGrdFinishTable tr:last td').parent().parent().children().index($('.AccGrdFinishTable tr:last td').parent()) - (AccrowSpanPCol - 1)) {
            $('.AccGrdFinishTable td[rowspan].GriegeTableProCol').each(function () {
                var row = $(this).parent().parent().children().index($(this).parent());
                if (row == AccmaxRowPCol && $(this).attr('rowspan') == AccrowSpanPCol) $(this).addClass('border_last_bottom_color');
            });
        }
        var AccmaxRowFiCol = 0;
        var AccrowSpanFiCol = 0;
        $('.AccGrdFinishTable td[rowspan].GriegeTableFinCol').each(function () {
            var row = $(this).parent().parent().children().index($(this).parent());
            if (row > AccmaxRowFiCol) {
                AccmaxRowFiCol = row;
                AccrowSpanFiCol = 0;
            }
            if ($(this).attr('rowspan') > AccrowSpanFiCol) AccrowSpanFiCol = $(this).attr('rowspan');
        });
        if (AccmaxRowFiCol == $('.AccGrdFinishTable tr:last td').parent().parent().children().index($('.AccGrdFinishTable tr:last td').parent()) - (AccrowSpanFiCol - 1)) {
            $('.AccGrdFinishTable td[rowspan].GriegeTableFinCol').each(function () {
                var row = $(this).parent().parent().children().index($(this).parent());
                if (row == AccmaxRowFiCol && $(this).attr('rowspan') == AccrowSpanFiCol) $(this).addClass('border_last_bottom_color');
            });
        }

    }

    function ShowPurchaseOrder(AccessoryMasterId, Size, ColorPrint, SupplierPoId, type) {

        var url = '../../Internal/Accessory/AccessoryPurchaseOrderView.aspx?AccessoryMasterId=' + AccessoryMasterId + '&Size=' + Size + '&ColorPrint=' + ColorPrint + '&SupplierPoId=' + SupplierPoId + '&AccessoryType=' + type + '&FromPage=' + 1;
        Shadowbox.init({ animate: true, animateFade: true, modal: true });
        Shadowbox.open({ content: url, type: "iframe", player: "iframe", title: "", height: 900, width: 1500, modal: true, animate: true, animateFade: true, options: { onClose: SBClose} });
        return false;
    }
    function ClosePopupAcc() {



        $("#<%=dvMypopupdata.ClientID %>").removeClass("Popupshow");

        //   $("#<%=dvMypopupdata.ClientID%>").hide();



    }
    function SBClose() { }
    $(document).ready(function () {

        $('.numeric-field-with-two-decimal-places').keyup(function (e) {
            if (this.value != '-')
                while (isNaN(this.value))
                    this.value = this.value.split('').reverse().join('').replace(/[\D]/i, '')
                                   .split('').reverse().join('');
        })
    })
</script>
<div>
    <asp:HiddenField ID="hdnTabAccessory" runat="server" />
    <asp:UpdateProgress runat="server" ID="updateProgressAccessory" AssociatedUpdatePanelID="UpdatePanelAccessory"
        DisplayAfter="0">
        <ProgressTemplate>
            <%--<img src="../../App_Themes/ikandi/images1/loading36.gif" alt="" style="position: fixed;
                z-index: 52111; top: 40%; left: 45%; width: 6%;" />--%>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdatePanel ID="UpdatePanelAccessory" runat="server">
        <ContentTemplate>
            <div style="clear: both">
            </div>
            <div style="width: 100%; position: sticky; top: 119px; display: flex; align-items: center;
                padding: 4px 7px 4px; z-index: 1; background-color: #f9f8f8;">
                <div class="tab" style="width: 60%;">
                    <%--        <a runat="server" id="aGreige" class="AccessoryGreigeTab" onclick="ShowHideAccessorySuppliergrd('GRIEGE');">
                        Greige</a> <a runat="server" id="aProcess" class="AccessoryProcessTab" onclick="ShowHideAccessorySuppliergrd('PROCESS');">
                            Process</a> <a runat="server" id="aFinish" class="AccessoryFinishTab" onclick="ShowHideAccessorySuppliergrd('FINISHING');">
                                Finish</a>--%>
                    <asp:LinkButton ID="LnkGRIEGE" runat="server" CssClass="AccessoryGreigeTab" CommandArgument="GRIEGE"
                        OnClick="LinkSupplyTab_Click"> Greige</asp:LinkButton>
                    <asp:LinkButton ID="LnkPROCESS" runat="server" CssClass="AccessoryProcessTab" CommandArgument="PROCESS"
                        OnClick="LinkSupplyTab_Click"> Process</asp:LinkButton>
                    <asp:LinkButton ID="LnkFINISHING" runat="server" CssClass="AccessoryFinishTab" CommandArgument="FINISHING"
                        OnClick="LinkSupplyTab_Click"> Finish</asp:LinkButton>
                </div>
                <div style="width: 40%; text-align: right;">
                    <asp:DropDownList ID="DdlSearchType" runat="server">
                        <asp:ListItem Value="1" Text="Accessory Quality"></asp:ListItem>
                        <asp:ListItem Value="2" Text="Color Print"></asp:ListItem>
                        <asp:ListItem Value="3" Text="Supplier"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:TextBox ID="txtsearchkeyswords" CssClass="search_1 searchtxt" placeholder="Search Accessory Quality/Color Print/Supplier"
                        runat="server" Style="text-transform: unset; width: 50%;"></asp:TextBox>
                    <asp:Button ID="btnSearch" runat="server" CssClass="go do-not-disable" Text="Search"
                        Style="padding: 3px 7px; border-radius: 2px;" OnClick="btnSearch_Click" />
                </div>
            </div>
            <div class="maincontentcontainer Accessory">
                <div class="clsDivHdr" id="dvHeader" runat="server">
                </div>
                <asp:GridView ID="grdGriege" CssClass="grdgsmcom AccGrdGriegeTable" Visible="false"
                    Style="width: 100%;" runat="server" AutoGenerateColumns="False" ShowHeader="true"
                    OnRowDataBound="grdGriege_RowDataBound" OnDataBound="grdGriege_DataBound" EmptyDataText="No Record Found!"
                    HeaderStyle-Font-Names="Arial" BorderWidth="0" HeaderStyle-HorizontalAlign="Center"
                    rules="all" HeaderStyle-CssClass="ths" ShowHeaderWhenEmpty="true">
                    <SelectedRowStyle BackColor="#A1DCF2" />
                    <RowStyle CssClass="RowCountDy" />
                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                    <Columns>
                        <asp:TemplateField HeaderText="Accessory Quality">
                            <ItemStyle HorizontalAlign="Center" Width="150px" CssClass="txtLeft FabFirstLeftbor AccGriegeColor" />
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <%-- <asp:Label ID="lblAccessoryQuality" runat="server" ForeColor="blue" Text='<%# Eval("AccessoryName")%>'></asp:Label>--%>
                                <asp:LinkButton ID="lnkOpenPopup" runat="server" OnClick="lnkOpenPopup_Click" Text='<%# Eval("AccessoryName") %>'></asp:LinkButton>
                                <asp:HiddenField ID="hdnAccessoryName" runat="server" Value='<%# Eval("AccessoryName") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Size">
                            <ItemStyle HorizontalAlign="Center" Width="70px" CssClass="txtLeft FabFirstLeftbor AccGriegeColor" />
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <%-- <asp:Label ID="lblAccessoryQuality" runat="server" ForeColor="blue" Text='<%# Eval("AccessoryName")%>'></asp:Label>--%>
                                <asp:Label ID="lblSize" runat="server" Text='<%# Eval("Size")%>'></asp:Label><br />
                                <asp:HiddenField ID="hdnSize" runat="server" Value='<%# Eval("Size")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Color/Print" Visible="false">
                            <ItemStyle HorizontalAlign="Center" Width="150px" CssClass="txtLeft FabFirstLeftbor AccGriegeColor" />
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <%-- <asp:Label ID="lblAccessoryQuality" runat="server" ForeColor="blue" Text='<%# Eval("AccessoryName")%>'></asp:Label>--%>
                                <asp:Label ID="lblcolorprint" runat="server" ForeColor="Black" Font-Bold="true" Text='<%# Eval("Color_Print")%>'></asp:Label>
                                <asp:HiddenField ID="hdnColor_Print" runat="server" Value='<%# Eval("Color_Print")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Style Number">
                            <ItemTemplate>
                                <asp:Repeater ID="RptStyle" runat="server">
                                    <ItemTemplate>
                                        <table style='width: 100%;' border="0">
                                            <tr>
                                                <td style='border-top: none; border-right: none;text-align: left; color: black;'>
                                                    <%# Eval("StyleNumber")%>
                                                    <asp:HiddenField ID="hdnStyleNumber" runat="server" Value=' <%# Eval("StyleNumber")%>' />
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </ItemTemplate>
                            <ItemStyle Width="70px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Serial Number">
                            <ItemTemplate>
                                <asp:Repeater runat="server" ID="RptStyle1">
                                    <ItemTemplate>
                                        <table style='width: 100%;' border="0">
                                            <tr>
                                                <td style='border-top: none; border-right: none;text-align: left; color: Blue;'>
                                                    <%# Eval("SerialNumber")%>
                                                    <asp:HiddenField ID="hdnSerialNumber" runat="server" Value=' <%# Eval("SerialNumber")%>' />
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </ItemTemplate>
                            <ItemStyle Width="60px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Cut meterage required ">
                            <ItemTemplate>
                                <asp:Label ID="lblQuantityToOrder" CssClass="color_black" Text='<%# (Eval("QuantityToOrder") == DBNull.Value  || (Eval("QuantityToOrder").ToString().Trim() == string.Empty)) ? string.Empty : (Convert.ToInt32((Eval("QuantityToOrder"))).ToString("N0")) %>'
                                    runat="server" style="margin-right:0;"></asp:Label>
                                &nbsp;
                                <asp:HiddenField ID="hdnQuantityToOrder" runat="server" Value='<%# (Eval("QuantityToOrder") == DBNull.Value  || (Eval("QuantityToOrder").ToString().Trim() == string.Empty)) ? string.Empty : (Convert.ToInt32((Eval("QuantityToOrder"))).ToString("N0")) %>' />
                                <asp:Label ID="lblUnitName" Font-Bold="true" runat="server" Text='<%# Eval("UnitName")%>'></asp:Label>
                                <asp:HiddenField ID="hdnUnitName" runat="server" Value='<%# Eval("UnitName")%>' />
                            </ItemTemplate>
                            <ItemStyle Width="65px" CssClass="AccGriegeOrder"/>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Shrink">
                            <ItemTemplate>
                                <asp:Label ID="lblShrinkage" CssClass="color_black" Text='<%# Convert.ToString(Eval("Shrinkage")) == "0" ? "" : Convert.ToString(Eval("Shrinkage") + " %")%>'
                                    runat="server"></asp:Label>
                                <asp:HiddenField ID="hdnShrinkage" runat="server" Value='<%# Convert.ToString(Eval("Shrinkage")) == "0" ? "" : Convert.ToString(Eval("Shrinkage"))%>' />
                            </ItemTemplate>
                            <ItemStyle CssClass="GriAccessShrTable" Width="30px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Wastage">
                            <ItemTemplate>
                                <asp:Label ID="lblWastage" CssClass="color_black" Text='<%# Convert.ToString(Eval("Wastage")) == "0" ? "" : Convert.ToString(Eval("Wastage") + " %")%>'
                                    runat="server"></asp:Label>
                                <asp:HiddenField ID="hdnWastage" runat="server" Value='<%# Convert.ToString(Eval("Wastage")) == "0" ? "" : Convert.ToString(Eval("Wastage"))%>' />
                            </ItemTemplate>
                            <ItemStyle CssClass="GriAccessWaTable" Width="30px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Best Quote for ref.  Rate & Lead Time" Visible="false">
                            <ItemTemplate>
                                <%--<asp:Label ID="lblBestQuotedRate" CssClass="float_left color_black" Text='<%# Convert.ToString(Eval("MinimumRate")) == "0" ? "" : Convert.ToString(Eval("MinimumRate"))%>'
                                    runat="server"></asp:Label>
                                <asp:Label ID="lblBestQuotedLeadTime" CssClass="float_right color_black" Text='<%# Convert.ToString(Eval("MinimumLeadTime")) == "0" ? "" : Convert.ToString(Eval("MinimumLeadTime"))%>'
                                    runat="server"></asp:Label>--%>
                                <asp:HiddenField ID="hdnMinimumRate" Value='<%# Eval("MinimumRate")%>' runat="server" />
                                <asp:HiddenField ID="hdnMinimumLeadTime" Value='<%# Eval("MinimumLeadTime")%>' runat="server" />
                            </ItemTemplate>
                            <ItemStyle Width="60px" CssClass="GriAccessWaGRT" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Supplier Name" ItemStyle-CssClass="textLeft">
                            <ItemTemplate>
                                <asp:HiddenField ID="hdnSupplierID" runat="server" Value='<%# Eval("SupplierId")%>' />
                                <asp:HiddenField ID="hdnQuotedRate" runat="server" Value='<%# Eval("QuotedLandedRate")%>' />
                                <asp:HiddenField ID="hdnQuotedLeadTime" runat="server" Value='<%# Eval("QuotedLeadTime")%>' />
                                <asp:HiddenField ID="hdAccessoryMasterId" runat="server" Value='<%# Eval("AccessoryMaster_Id")%>' />
                                <asp:HiddenField ID="hdnAccessoryQualitySize" runat="server" Value='<%# Eval("Size")%>' />
                                <asp:HiddenField ID="hdnColorprint" runat="server" Value='<%# Eval("Color_Print")%>' />
                                <asp:Label ID="lblsuppliername" runat="server" CssClass="color_black" Text='<%# Eval("SupplierName") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="150px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Quoted (Rate)">
                            <ItemTemplate>
                                <span style="color: green; font-size: 11px">₹</span>
                                <asp:TextBox ID="txtquotedval" MaxLength="6" onchange="SaveAccessorySupplierQuotation(this, 1)"
                                    onkeypress="RestrictSpaceSpecial();" CssClass="Normaltextbox numeric-field-with-two-decimal-places"
                                    runat="server" BorderColor="White" Text='<%# Convert.ToString(Eval("QuotedLandedRate")) == "0" ? "" : Convert.ToString(Eval("QuotedLandedRate"))%>'></asp:TextBox>
                                <%--<asp:TextBox ID="txtdays" onchange="SaveAccessorySupplierQuotation(this, 1)" CssClass="Normaltextbox" onkeyup="if (/\D/g.test(this.value)) this.value = this.value.replace(/\D/g,'')" Text='<%# Convert.ToString(Eval("QuotedLeadTime")) == "0" ? "" : Convert.ToString(Eval("QuotedLeadTime"))%>' runat="server" BorderColor="White"></asp:TextBox>
                                Days--%>
                            </ItemTemplate>
                            <ItemStyle Width="125px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Quoted Date">
                            <ItemTemplate>
                                <%# (Eval("QuotedDate") == DBNull.Value) ? "" : (Convert.ToDateTime(Eval("QuotedDate")) == Convert.ToDateTime("1/1/1900")) ? "" : Convert.ToDateTime(Eval("QuotedDate")).ToString("dd MMM yy") %>
                            </ItemTemplate>
                            <ItemStyle Width="65px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="<table style='width: 100%' ><tr> <td style='width: 20%' >PO No.</td>  <td style='width: 20%' >Quantity</td>  <td style='width: 20%' >Rate</td>  <td style='width: 20%' >(Date)</td>  <td style='width: 20%' >Action</td> </tr>  </table> "
                            Visible="false">
                            <ItemTemplate>
                                <%--  <asp:Repeater ID="rptPoDetail" runat="server" OnItemDataBound="rptPoDetail_ItemDataBound">
                                    <ItemTemplate>
                                        <div>
                                            <table cellpadding="0" cellspacing="0" class="innertablePo">
                                                <tr id="trPoNumber" runat="server">
                                                    <td>
                                                        <asp:Label ID="lblPoNumber" Style="cursor: pointer; color: Blue;" runat="server"
                                                            Text='<%# Eval("PoNumber")%>'></asp:Label>
                                                        <asp:HiddenField ID="hdnPoSupplirtId" runat="server" Value='<%# Eval("SupplierPoId")%>' />
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblQuanity" Style="color: Black;" runat="server" Text=""></asp:Label>
                                                    </td>
                                                    <td style="width: 20px;">
                                                        <span style="color: green; font-size: 11px">₹</span> <span style="color: Black;">
                                                            <%# Convert.ToString(Eval("Rate")) == "0" ? "" : Convert.ToString(Eval("Rate"))%></span>
                                                    </td>
                                                    <td>
                                                        <%# (Eval("PODate") == DBNull.Value) ? "" : (Convert.ToDateTime(Eval("PODate")) == Convert.ToDateTime("1/1/1900")) ? "" : "(" + (Convert.ToDateTime(Eval("PODate"))).ToString("dd MMM yy") + ")" %>
                                                    </td>
                                                    <td>
                                                        <asp:Button ID="btnAccept" runat="server" Text='Accept' OnClick="btnAccept_Click"
                                                            OnClientClick="ConfirmAccessoryQuotation()" CssClass="Acceptbutton" />
                                                        <asp:HiddenField ID="hdnSupplierPoId" runat="server" Value='<%# Eval("SupplierPoId")%>' />
                                                        <asp:HiddenField ID="hdnIsPartySignature" runat="server" Value='<%# Eval("IsPartySignature")%>' />
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>--%>
                            </ItemTemplate>
                            <ItemStyle CssClass="PoNoUnit" />
                        </asp:TemplateField>
                    </Columns>
                    <EmptyDataTemplate>
                        <div id="dvEmptyData" runat="server">
                        </div>
                    </EmptyDataTemplate>
                </asp:GridView>
                <asp:GridView ID="grdProcess" CssClass="grdgsmcom AccGrdProcessTable" Visible="false"
                    Style="width: 100%; min-width: 1200px;" runat="server" AutoGenerateColumns="False"
                    ShowHeader="true" OnRowDataBound="grdProcess_RowDataBound" OnDataBound="grdProcess_DataBound"
                    EmptyDataText="No Record Found!" HeaderStyle-Font-Names="Arial" HeaderStyle-HorizontalAlign="Center"
                    BorderWidth="0" rules="all" HeaderStyle-CssClass="ths" ShowHeaderWhenEmpty="true">
                    <SelectedRowStyle BackColor="#A1DCF2" />
                    <RowStyle CssClass="RowCountDy" />
                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                    <Columns>
                        <asp:TemplateField HeaderText="Accessory Quality">
                            <ItemStyle HorizontalAlign="Center" Width="150px" CssClass="txtLeft FabFirstLeftbor AccGriegeColor" />
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <%-- <asp:Label ID="lblAccessoryQuality" runat="server" ForeColor="blue" Text='<%# Eval("AccessoryName")%>'></asp:Label>--%>
                                <asp:LinkButton ID="lnkOpenPopup" runat="server" OnClick="lnkOpenPopup_Click" Text='<%# Eval("AccessoryName") %>'></asp:LinkButton>
                                <asp:HiddenField ID="hdnAccessoryName" runat="server" Value='<%# Eval("AccessoryName") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Size">
                            <ItemStyle HorizontalAlign="Center" Width="70px" CssClass="txtLeft FabFirstLeftbor AccGriegeColor" />
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <%-- <asp:Label ID="lblAccessoryQuality" runat="server" ForeColor="blue" Text='<%# Eval("AccessoryName")%>'></asp:Label>--%>
                                <asp:Label ID="lblSize" runat="server" Text='<%# Eval("Size")%>'></asp:Label><br />
                                <asp:HiddenField ID="hdnSize" runat="server" Value='<%# Eval("Size")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Color/Print">
                            <ItemStyle HorizontalAlign="Center" Width="60px" CssClass="txtLeft FabFirstLeftbor AccGriegeColor" />
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <%-- <asp:Label ID="lblAccessoryQuality" runat="server" ForeColor="blue" Text='<%# Eval("AccessoryName")%>'></asp:Label>--%>
                                <asp:Label ID="lblcolorprint" runat="server" ForeColor="Black" Font-Bold="true" Text='<%# Eval("Color_Print")%>'></asp:Label>
                                <asp:HiddenField ID="hdnColor_Print" runat="server" Value='<%# Eval("Color_Print")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Style Number">
                            <ItemTemplate>
                                <asp:Repeater ID="RptStyle" runat="server">
                                    <ItemTemplate>
                                        <table style='width: 100%;' border="0">
                                            <tr>
                                                <td style='border-top: none; border-right: none;text-align: left; color: black;'>
                                                    <%# Eval("StyleNumber")%>
                                                    <asp:HiddenField ID="hdnStyleNumber" runat="server" Value=' <%# Eval("StyleNumber")%>' />
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </ItemTemplate>
                            <ItemStyle Width="70px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Serial Number">
                            <ItemTemplate>
                                <asp:Repeater runat="server" ID="RptStyle1">
                                    <ItemTemplate>
                                        <table style='width: 100%;' border="0">
                                            <tr>
                                                <td style='border-top: none; border-right: none;text-align: left; color: Blue;'>
                                                    <%# Eval("SerialNumber")%>
                                                    <asp:HiddenField ID="hdnSerialNumber" runat="server" Value=' <%# Eval("SerialNumber")%>' />
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </ItemTemplate>
                            <ItemStyle Width="60px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Cut meterage required ">
                            <ItemTemplate>
                                <asp:Label ID="lblQuantityToOrder" CssClass="color_black" Text='<%# (Eval("QuantityToOrder") == DBNull.Value  || (Eval("QuantityToOrder").ToString().Trim() == string.Empty)) ? string.Empty : (Convert.ToInt32((Eval("QuantityToOrder"))).ToString("N0")) %>'
                                    runat="server" style="margin-right:0;"></asp:Label>
                                &nbsp;
                                <asp:HiddenField ID="hdnQuantityToOrder" runat="server" Value='<%# (Eval("QuantityToOrder") == DBNull.Value  || (Eval("QuantityToOrder").ToString().Trim() == string.Empty)) ? string.Empty : (Convert.ToInt32((Eval("QuantityToOrder"))).ToString("N0")) %>' />
                                <asp:Label ID="lblUnitName" Font-Bold="true" runat="server" Text='<%# Eval("UnitName")%>'></asp:Label>
                                <asp:HiddenField ID="hdnUnitName" runat="server" Value='<%# Eval("UnitName")%>' />
                            </ItemTemplate>
                            <ItemStyle Width="65px" CssClass="AccGriegeOrder" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Shrink">
                            <ItemTemplate>
                                <asp:Label ID="lblShrinkage" CssClass="color_black" Text='<%# Convert.ToString(Eval("Shrinkage")) == "0" ? "" : Convert.ToString(Eval("Shrinkage")+ " %")%>'
                                    runat="server"></asp:Label>
                                <asp:HiddenField ID="hdnShrinkage" runat="server" Value='<%# Convert.ToString(Eval("Shrinkage")) == "0" ? "" : Convert.ToString(Eval("Shrinkage"))%>' />
                            </ItemTemplate>
                            <ItemStyle CssClass="GriAccessShrTable" Width="30px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Wastage">
                            <ItemTemplate>
                                <asp:Label ID="lblWastage" CssClass="color_black" Text='<%# Convert.ToString(Eval("Wastage")) == "0" ? "" : Convert.ToString(Eval("Wastage")+ " %")%>'
                                    runat="server"></asp:Label>
                                <asp:HiddenField ID="hdnWastage" runat="server" Value='<%# Convert.ToString(Eval("Wastage")) == "0" ? "" : Convert.ToString(Eval("Wastage"))%>' />
                            </ItemTemplate>
                            <ItemStyle CssClass="GriAccessWaTable" Width="30px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Best Quote for ref.  Rate & Lead Time" Visible="false">
                            <ItemTemplate>
                                <%-- <asp:Label ID="lblBestQuotedRate" CssClass="float_left color_black" Text='<%# Convert.ToString(Eval("MinimumRate")) == "0" ? "" : Convert.ToString(Eval("MinimumRate"))%>'
                                    runat="server"></asp:Label>
                                <asp:Label ID="lblBestQuotedLeadTime" CssClass="float_right color_black" Text='<%# Convert.ToString(Eval("MinimumLeadTime")) == "0" ? "" : Convert.ToString(Eval("MinimumLeadTime"))%>'
                                    runat="server"></asp:Label>--%>
                                <asp:HiddenField ID="hdnMinimumRate" Value='<%# Eval("MinimumRate")%>' runat="server" />
                                <asp:HiddenField ID="hdnMinimumLeadTime" Value='<%# Eval("MinimumLeadTime")%>' runat="server" />
                            </ItemTemplate>
                            <ItemStyle Width="60px" CssClass="GriAccessWaGRT" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Supplier Name" ItemStyle-CssClass="textLeft">
                            <ItemTemplate>
                                <asp:HiddenField ID="hdnSupplierID" runat="server" Value='<%# Eval("SupplierId")%>' />
                                <asp:HiddenField ID="hdnQuotedRate" runat="server" Value='<%# Eval("QuotedLandedRate")%>' />
                                <asp:HiddenField ID="hdnQuotedLeadTime" runat="server" Value='<%# Eval("QuotedLeadTime")%>' />
                                <asp:HiddenField ID="hdAccessoryMasterId" runat="server" Value='<%# Eval("AccessoryMaster_Id")%>' />
                                <asp:HiddenField ID="hdnAccessoryQualitySize" runat="server" Value='<%# Eval("Size")%>' />
                                <asp:HiddenField ID="hdnColorprint" runat="server" Value='<%# Eval("Color_Print")%>' />
                                <asp:Label ID="lblsuppliername" runat="server" CssClass="color_black" Text='<%# Eval("SupplierName") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="150px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Quoted (Rate) / delivery mode">
                            <ItemTemplate>
                                <span style="color: green; font-size: 11px">₹</span>
                                <asp:TextBox ID="txtquotedval" MaxLength="6" onchange="SaveAccessorySupplierQuotation(this, 2)"
                                    onkeypress="RestrictSpaceSpecial();" CssClass="Normaltextbox numeric-field-with-two-decimal-places"
                                    runat="server" BorderColor="White" Text='<%# Convert.ToString(Eval("QuotedLandedRate")) == "0" ? "" : Convert.ToString(Eval("QuotedLandedRate"))%>'></asp:TextBox>
                                <%--  <asp:TextBox ID="txtdays" onchange="SaveAccessorySupplierQuotation(this, 2)" CssClass="Normaltextbox" onkeyup="if (/\D/g.test(this.value)) this.value = this.value.replace(/\D/g,'')" Text='<%# Convert.ToString(Eval("QuotedLeadTime")) == "0" ? "" : Convert.ToString(Eval("QuotedLeadTime"))%>' runat="server" BorderColor="White"></asp:TextBox>
                                Days--%>
                            </ItemTemplate>
                            <ItemStyle Width="125px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Quoted Date">
                            <ItemTemplate>
                                <%# (Eval("QuotedDate") == DBNull.Value) ? "" : (Convert.ToDateTime(Eval("QuotedDate")) == Convert.ToDateTime("1/1/1900")) ? "" : Convert.ToDateTime(Eval("QuotedDate")).ToString("dd MMM yy") %>
                            </ItemTemplate>
                            <ItemStyle Width="65px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="<table style='width: 100%' ><tr> <td style='width: 20%' >PO No.</td>  <td style='width: 20%' >Quantity</td>  <td style='width: 20%' >Rate</td>  <td style='width: 20%' >(Date)</td>  <td style='width: 20%' >Action</td> </tr>  </table> "
                            Visible="false">
                            <ItemTemplate>
                                <%--  <asp:Repeater ID="rptPoDetail" runat="server" OnItemDataBound="rptPoDetail_ItemDataBound">
                                    <ItemTemplate>
                                        <div>
                                            <table cellpadding="0" cellspacing="0" class="innertablePo">
                                                <tr id="trPoNumber" runat="server">
                                                    <td>
                                                        <asp:Label ID="lblPoNumber" Style="cursor: pointer; color: Blue;" runat="server"
                                                            Text='<%# Eval("PoNumber")%>'></asp:Label>
                                                        <asp:HiddenField ID="hdnPoSupplirtId" runat="server" Value='<%# Eval("SupplierPoId")%>' />
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblQuanity" Style="color: Black;" runat="server" Text=""></asp:Label>
                                                    </td>
                                                    <td>
                                                        <span style="color: green; font-size: 11px">₹</span> <span style="color: Black;">
                                                            <%# Convert.ToString(Eval("Rate")) == "0" ? "" : Convert.ToString(Eval("Rate"))%></span>
                                                    </td>
                                                    <td>
                                                        <%# (Eval("PODate") == DBNull.Value) ? "" : (Convert.ToDateTime(Eval("PODate")) == Convert.ToDateTime("1/1/1900")) ? "" : "(" + (Convert.ToDateTime(Eval("PODate"))).ToString("dd MMM yy") + ")" %>
                                                    </td>
                                                    <td>
                                                        <asp:Button ID="btnAccept" runat="server" Text='Accept' OnClick="btnAccept_Click"
                                                            OnClientClick="ConfirmAccessoryQuotation()" CssClass="Acceptbutton" />
                                                        <asp:HiddenField ID="hdnSupplierPoId" runat="server" Value='<%# Eval("SupplierPoId")%>' />
                                                        <asp:HiddenField ID="hdnIsPartySignature" runat="server" Value='<%# Eval("IsPartySignature")%>' />
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>--%>
                            </ItemTemplate>
                            <ItemStyle CssClass="PoNoUnit" />
                        </asp:TemplateField>
                    </Columns>
                    <EmptyDataTemplate>
                        <div id="dvEmptyData" runat="server">
                        </div>
                    </EmptyDataTemplate>
                </asp:GridView>
                <asp:GridView ID="grdFinish" CssClass="grdgsmcom AccGrdFinishTable" Visible="false"
                    Style="width: 100%; min-width: 1250px;" runat="server" AutoGenerateColumns="False"
                    ShowHeader="true" OnRowDataBound="grdFinish_RowDataBound" OnDataBound="grdFinish_DataBound"
                    EmptyDataText="No Record Found!" HeaderStyle-Font-Names="Arial" HeaderStyle-HorizontalAlign="Center"
                    BorderWidth="0" rules="all" HeaderStyle-CssClass="ths" ShowHeaderWhenEmpty="true">
                    <SelectedRowStyle BackColor="#A1DCF2" />
                    <RowStyle CssClass="RowCountDy" />
                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                    <Columns>
                        <asp:TemplateField HeaderText="Accessory Quality">
                            <ItemStyle HorizontalAlign="Center" Width="150px" CssClass="txtLeft FabFirstLeftbor AccGriegeColor" />
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <%-- <asp:Label ID="lblAccessoryQuality" runat="server" ForeColor="blue" Text='<%# Eval("AccessoryName")%>'></asp:Label>--%>
                                <asp:LinkButton ID="lnkOpenPopup" runat="server" OnClick="lnkOpenPopup_Click" Text='<%# Eval("AccessoryName") %>'></asp:LinkButton>
                                <asp:HiddenField ID="hdnAccessoryName" runat="server" Value='<%# Eval("AccessoryName") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Size">
                            <ItemStyle HorizontalAlign="Center" Width="70px" CssClass="txtLeft FabFirstLeftbor AccGriegeColor" />
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <%-- <asp:Label ID="lblAccessoryQuality" runat="server" ForeColor="blue" Text='<%# Eval("AccessoryName")%>'></asp:Label>--%>
                                <asp:Label ID="lblSize" runat="server" Text='<%# Eval("Size")%>'></asp:Label><br />
                                <asp:HiddenField ID="hdnSize" runat="server" Value='<%# Eval("Size")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Color/Print">
                            <ItemStyle HorizontalAlign="Center" Width="90px" CssClass="txtLeft FabFirstLeftbor AccGriegeColor" />
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <%-- <asp:Label ID="lblAccessoryQuality" runat="server" ForeColor="blue" Text='<%# Eval("AccessoryName")%>'></asp:Label>--%>
                                <asp:Label ID="lblcolorprint" runat="server" ForeColor="Black" Font-Bold="true" Text='<%# Eval("Color_Print")%>'></asp:Label>
                                <asp:HiddenField ID="hdnColor_Print" runat="server" Value='<%# Eval("Color_Print")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Style Number">
                            <ItemTemplate>
                                <asp:Repeater ID="RptStyle" runat="server">
                                    <ItemTemplate>
                                        <table style='width: 100%;' border="0">
                                            <tr>
                                                <td style='border-top: none; border-right: none;text-align: left; color: black;'>
                                                    <%# Eval("StyleNumber")%>
                                                    <asp:HiddenField ID="hdnStyleNumber" runat="server" Value=' <%# Eval("StyleNumber")%>' />
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </ItemTemplate>
                            <ItemStyle Width="70px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Serial Number">
                            <ItemTemplate>
                                <asp:Repeater runat="server" ID="RptStyle1">
                                    <ItemTemplate>
                                        <table style='width: 100%;' border="0">
                                            <tr>
                                                <td style='border-top: none; border-right: none;text-align: left; color: Blue;'>
                                                    <%# Eval("SerialNumber")%>
                                                    <asp:HiddenField ID="hdnSerialNumber" runat="server" Value=' <%# Eval("SerialNumber")%>' />
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </ItemTemplate>
                            <ItemStyle Width="60px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Cut meterage required ">
                            <ItemTemplate>
                                <asp:Label ID="lblQuantityToOrder" CssClass="color_black" Text='<%# (Eval("QuantityToOrder") == DBNull.Value  || (Eval("QuantityToOrder").ToString().Trim() == string.Empty)) ? string.Empty : (Convert.ToInt32((Eval("QuantityToOrder"))).ToString("N0")) %>'
                                    runat="server" style="margin-right:0;"></asp:Label>
                                &nbsp;
                                <asp:HiddenField ID="hdnQuantityToOrder" runat="server" Value='<%# (Eval("QuantityToOrder") == DBNull.Value  || (Eval("QuantityToOrder").ToString().Trim() == string.Empty)) ? string.Empty : (Convert.ToInt32((Eval("QuantityToOrder"))).ToString("N0")) %>' />
                                <asp:Label ID="lblUnitName" Font-Bold="true" runat="server" Text='<%# Eval("UnitName")%>'></asp:Label>
                                <asp:HiddenField ID="hdnUnitName" runat="server" Value='<%# Eval("UnitName")%>' />
                            </ItemTemplate>
                            <ItemStyle Width="65px" CssClass="AccGriegeOrder" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Shrink">
                            <ItemTemplate>
                                <asp:Label ID="lblShrinkage" CssClass="color_black" Text='<%# Convert.ToString(Eval("Shrinkage")) == "0" ? "" : Convert.ToString(Eval("Shrinkage")+ " %")%>'
                                    runat="server"></asp:Label>
                                <asp:HiddenField ID="hdnShrinkage" runat="server" Value='<%# Convert.ToString(Eval("Shrinkage")) == "0" ? "" : Convert.ToString(Eval("Shrinkage"))%>' />
                            </ItemTemplate>
                            <ItemStyle CssClass="GriAccessShrTable" Width="30px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Wastage">
                            <ItemTemplate>
                                <asp:Label ID="lblWastage" CssClass="color_black" Text='<%# Convert.ToString(Eval("Wastage")) == "0" ? "" : Convert.ToString(Eval("Wastage") + " %")%>'
                                    runat="server"></asp:Label>
                                <asp:HiddenField ID="hdnWastage" runat="server" Value='<%# Convert.ToString(Eval("Wastage")) == "0" ? "" : Convert.ToString(Eval("Wastage"))%>' />
                            </ItemTemplate>
                            <ItemStyle CssClass="GriAccessWaTable" Width="30px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Best Quote for ref.  Rate & Lead Time" Visible="false">
                            <ItemTemplate>
                                <%-- <asp:Label ID="lblBestQuotedRate" CssClass="float_left color_black" Text='<%# Convert.ToString(Eval("MinimumRate")) == "0" ? "" : Convert.ToString(Eval("MinimumRate"))%>'
                                    runat="server"></asp:Label>
                                <asp:Label ID="lblBestQuotedLeadTime" CssClass="float_right color_black" Text='<%# Convert.ToString(Eval("MinimumLeadTime")) == "0" ? "" : Convert.ToString(Eval("MinimumLeadTime"))%>'
                                    runat="server"></asp:Label>--%>
                                <asp:HiddenField ID="hdnMinimumRate" Value='<%# Eval("MinimumRate")%>' runat="server" />
                                <asp:HiddenField ID="hdnMinimumLeadTime" Value='<%# Eval("MinimumLeadTime")%>' runat="server" />
                            </ItemTemplate>
                            <ItemStyle Width="60px" CssClass="GriAccessWaGRT" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Supplier Name" ItemStyle-CssClass="textLeft">
                            <ItemTemplate>
                                <asp:HiddenField ID="hdnSupplierID" runat="server" Value='<%# Eval("SupplierId")%>' />
                                <asp:HiddenField ID="hdnQuotedRate" runat="server" Value='<%# Eval("QuotedLandedRate")%>' />
                                <asp:HiddenField ID="hdnQuotedLeadTime" runat="server" Value='<%# Eval("QuotedLeadTime")%>' />
                                <asp:HiddenField ID="hdAccessoryMasterId" runat="server" Value='<%# Eval("AccessoryMaster_Id")%>' />
                                <asp:HiddenField ID="hdnAccessoryQualitySize" runat="server" Value='<%# Eval("Size")%>' />
                                <asp:HiddenField ID="hdnColorprint" runat="server" Value='<%# Eval("Color_Print")%>' />
                                <asp:Label ID="lblsuppliername" runat="server" CssClass="color_black" Text='<%# Eval("SupplierName") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="150px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Quoted (Rate)">
                            <ItemTemplate>
                                <span style="color: green; font-size: 11px">₹</span>
                                <asp:TextBox ID="txtquotedval" MaxLength="6" onchange="SaveAccessorySupplierQuotation(this, 3)"
                                    onkeypress="RestrictSpaceSpecial();" CssClass="Normaltextbox numeric-field-with-two-decimal-places"
                                    runat="server" BorderColor="White" Text='<%# Convert.ToString(Eval("QuotedLandedRate")) == "0" ? "" : Convert.ToString(Eval("QuotedLandedRate"))%>'></asp:TextBox>
                                <%-- <asp:TextBox ID="txtdays" onchange="SaveAccessorySupplierQuotation(this, 3)" CssClass="Normaltextbox" onkeyup="if (/\D/g.test(this.value)) this.value = this.value.replace(/\D/g,'')" Text='<%# Convert.ToString(Eval("QuotedLeadTime")) == "0" ? "" : Convert.ToString(Eval("QuotedLeadTime"))%>' runat="server" BorderColor="White"></asp:TextBox>
                                Days--%>
                            </ItemTemplate>
                            <ItemStyle Width="125px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Quoted Date">
                            <ItemTemplate>
                                <%# (Eval("QuotedDate") == DBNull.Value) ? "" : (Convert.ToDateTime(Eval("QuotedDate")) == Convert.ToDateTime("1/1/1900")) ? "" : Convert.ToDateTime(Eval("QuotedDate")).ToString("dd MMM yy") %>
                            </ItemTemplate>
                            <ItemStyle Width="65px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="<table style='width: 100%' ><tr> <td style='width: 20%' >PO No.</td>  <td style='width: 20%' >Quantity</td>  <td style='width: 20%' >Rate</td>  <td style='width: 20%' >(Date)</td>  <td style='width: 20%' >Action</td> </tr>  </table> "
                            Visible="false">
                            <ItemTemplate>
                                <%-- <asp:Repeater ID="rptPoDetail" runat="server" OnItemDataBound="rptPoDetail_ItemDataBound">
                                    <ItemTemplate>
                                        <div>
                                            <table cellpadding="0" cellspacing="0" class="innertablePo">
                                                <tr id="trPoNumber" runat="server">
                                                    <td>
                                                        <asp:Label ID="lblPoNumber" Style="cursor: pointer; color: Blue;" runat="server"
                                                            Text='<%# Eval("PoNumber")%>'></asp:Label>
                                                        <asp:HiddenField ID="hdnPoSupplirtId" runat="server" Value='<%# Eval("SupplierPoId")%>' />
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblQuanity" Style="color: Black;" runat="server" Text=""></asp:Label>
                                                    </td>
                                                    <td>
                                                        <span style="color: green; font-size: 11px">₹</span> <span style="color: Black;">
                                                            <%# Convert.ToString(Eval("Rate")) == "0" ? "" : Convert.ToString(Eval("Rate"))%></span>
                                                    </td>
                                                    <td>
                                                        <%# (Eval("PODate") == DBNull.Value) ? "" : (Convert.ToDateTime(Eval("PODate")) == Convert.ToDateTime("1/1/1900")) ? "" : "(" + (Convert.ToDateTime(Eval("PODate"))).ToString("dd MMM yy") + ")" %>
                                                    </td>
                                                    <td>
                                                        <asp:Button ID="btnAccept" runat="server" Text='Accept' OnClick="btnAccept_Click"
                                                            OnClientClick="ConfirmAccessoryQuotation()" CssClass="Acceptbutton" />
                                                        <asp:HiddenField ID="hdnSupplierPoId" runat="server" Value='<%# Eval("SupplierPoId")%>' />
                                                        <asp:HiddenField ID="hdnIsPartySignature" runat="server" Value='<%# Eval("IsPartySignature")%>' />
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>--%>
                            </ItemTemplate>
                            <ItemStyle CssClass="PoNoUnit" />
                        </asp:TemplateField>
                    </Columns>
                    <EmptyDataTemplate>
                        <div id="dvEmptyData" runat="server">
                        </div>
                    </EmptyDataTemplate>
                </asp:GridView>
            </div>
            <div id="dvMypopupdata" runat="server" class="modal Popuphide">
                <div class="modal-content  " style="width: 60% !important; height: auto;">
                    <span class="close" id="closebutton" onclick="ClosePopupAcc();return false;">&times;</span>
                    <asp:Repeater ID="rptPoDetail" runat="server" OnItemDataBound="rptPoDetail_ItemDataBound">
                        <HeaderTemplate>
                            <table cellpadding="0" cellspacing="0" class="innertablePo">
                                <tr>
                                    <td>
                                        PoNumber
                                    </td>
                                    <td>
                                        Quantity
                                    </td>
                                    <td>
                                        SupplierName
                                    </td>
                                    <td>
                                        Rate
                                    </td>
                                    <td>
                                        PoDate
                                    </td>
                                    <td>
                                        Action
                                    </td>
                                </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr id="trPoNumber" runat="server">
                                <td>
                                    <asp:Label ID="lblPoNumber" Style="cursor: pointer; color: Blue;" runat="server"
                                        Text='<%# Eval("PoNumber")%>'></asp:Label>
                                    <asp:HiddenField ID="hdnPoSupplirtId" runat="server" Value='<%# Eval("SupplierPoId")%>' />
                                </td>
                                <td>
                                    <asp:Label ID="lblQuanity" Style="color: Black; font-weight: 600;" runat="server"
                                        Text=""></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblSupplierName" Style="color: Black;" runat="server" Text='<%# Eval("SupplierName") %>'></asp:Label>
                                </td>
                                <td>
                                    <span style="color: green; font-size: 11px">₹</span> <span style="color: Black; font-weight: 600;">
                                        <%# Convert.ToString(Eval("Rate")) == "0" ? "" : Convert.ToString(Eval("Rate"))%></span>
                                </td>
                                <td>
                                    <%# (Eval("PODate") == DBNull.Value) ? "" : (Convert.ToDateTime(Eval("PODate")) == Convert.ToDateTime("1/1/1900")) ? "" : "(" + (Convert.ToDateTime(Eval("PODate"))).ToString("dd MMM yy") + ")" %>
                                </td>
                                <td>
                                    <asp:Button ID="btnAccept" runat="server" Text='Accept' OnClick="btnAccept_Click"
                                        OnClientClick="ConfirmAccessoryQuotation()" CssClass="Acceptbutton" />
                                    <asp:HiddenField ID="hdnSupplierPoId" runat="server" Value='<%# Eval("SupplierPoId")%>' />
                                    <asp:HiddenField ID="hdnIsPartySignature" runat="server" Value='<%# Eval("IsPartySignature")%>' />
                                </td>
                            </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                            </table>
                        </FooterTemplate>
                    </asp:Repeater>
                    <div id="NoRecordMessage" runat="server" class="dnone">
                        <span style="color: red; font-size: 22px; display: block; text-align: center;">No Record
                            Found</span>
                    </div>
                </div>
            </div>
            <div id="secure_footer" style="text-align: center; text-align: center; padding: 10px 0;
                background-color: #39589c; color: #bfbfbf; width: 100%; position: fixed; left: 0;
                bottom: 0;">
                <script>                    document.write((new Date()).getFullYear())</script>
                © Boutique International Pvt. Ltd. All Rights Reserved.
            </div>
            <asp:HiddenField ID="confirm_value" runat="server" Value="No" />
            <script type="text/javascript">
                function ConfirmAccessoryQuotation() {
                    if (confirm("Please confirm, you have reviewed PO!")) {
                        document.getElementById("AccessoryQuotationForm1_confirm_value").value = "Yes";
                    } else {
                        document.getElementById("AccessoryQuotationForm1_confirm_value").value = "No";
                    }
                }
            </script>
        </ContentTemplate>
    </asp:UpdatePanel>
</div>
