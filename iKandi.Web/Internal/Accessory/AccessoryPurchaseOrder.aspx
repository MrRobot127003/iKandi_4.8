<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AccessoryPurchaseOrder.aspx.cs" Inherits="iKandi.Web.Internal.Accessory.AccessoryPurchaseOrder" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<link href="../../css/colorbox.css" rel="stylesheet" type="text/css" />
<link href="../../css/jquery-combined.css" rel="stylesheet" type="text/css" />
<link href="../../css/report.css" rel="stylesheet" type="text/css" />
<link href="../../css/technical-module.css" rel="stylesheet" type="text/css" />
<style type="text/css">
    /* @media print{@page {size: landscape}}*/
    body {
        background: #fff none repeat scroll 0 0;
        font-family: arial !important;
    }
    table {
        font-family: arial;
        border-color: #dbd8d8;
        border-collapse: collapse;
    }
    table td {
        height: 15px;
        font-size: 10px;
        text-transform: capitalize;
    }
    
    .ddlisNotQuoted
        {
           background-color:gray !important ; 
            
            }
            
             .ddlisQuoted
        {
           background-color:white; 
            
            }
    
    .ths {
        background: #dddfe4;
        font-weight: normal;
        color: #575759;
        font-family: arial;
        font-size: 10px;
        padding: 5px 0px;
        text-align: center;
        text-transform: capitalize;
        border: 1px solid #c6c0c0;
    }
    .AccessoryTable th {
        background: #dddfe4;
        border: 1px solid #999;
        padding: 5px 0px;
        text-align: center;
        font-weight: 500;
        font-size: 11px;
        font-family: Arial;
    }
    .AccessoryTable td {
        border: 1px solid #dbd8d8;
        padding: 2px 0px;
        text-align: center;
        font-weight: 500;
        font-size: 10px;
        height: 20px;
        font-family: Arial;
    }
    .AccessoryTable td:first-child {
        border-left-color: #999 !important;
    }
    .AccessoryTable td:last-child {
        border-right-color: #999 !important;
    }
    .AccessoryTable tr:nth-last-child(1) > td {
        border-bottom-color: #999 !important;
    }
    .AccessoryTable td input[type="text"] {
        width: 85%;
        font-size: 10px;
        height: 15px;
    }
    input[type="text"] {
        font-size: 10px !important;
    }
    .purchase_order {
        width: 100%;
        border: 1px solid #dbd8d8;
    }
    .purchase_order input {
        margin: 1px 0px;
        height: 15px;
    }
    select {
        height: 19px !important;
    }
    .purchase_order thead th {
        border: 1px solid #dbd8d8;
        padding: 2px 0px;
        text-align: center;
        text-align: center;
        font-weight: 600 !important;
        font-size: 11px;
    }
    .purchase_order tbody th {
        border: 1px solid #999;
        padding: 5px 7px;
        font-weight: 500;
        font-size: 11px;
    }
    .purchase_order tbody td {
        padding: 2px 5px;
        border-color: #dbd8d8;
    }
    select {
        width: 76px;
    }
    
    .supplieretadatetable td input[type="text"] {
        width: 92%;
        margin: 1px 0px;
    }
    .supplieretadatetable td {
        text-align: center;
    }
    #ctl00_cph_main_content_grdqtyrange th {
        background: #dddfe4;
        padding: 2px 2px;
        width: 98px;
        text-align: center;
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
    }
    .receivehis {
        float: left;
        margin-right: 10px;
        margin-bottom: 10px;
    }
    .receivehis th {
        background: #dddfe4;
        padding: 2px 2px;
        text-align: center;
        border: 1px solid #999;
        font-size: 11px;
        font-family: Arial;
        color: #575759;
        font-weight: 500;
    }
    .receivehis td {
        padding: 2px 2px;
        text-align: center;
        border: 1px solid #dbd8d8;
        font-size: 10px;
        font-family: Arial;
    }
    .receivehis td:first-child {
        border-left: 1px solid #999 !important;
    }
    
    .receivehis td:last-child {
        border-right: 1px solid #999 !important;
    }
    
    .receivehis tr:nth-last-child(1) > td {
        border-bottom: 1px solid #999 !important;
    }
    
    .lastrow td {
        text-align: center;
    }
    
    .txtcenter {
        text-align: center;
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
    .btnSubmit {
        color: rgb(255, 255, 255);
        font-size: 12px !important;
        float: left;
        font-weight: 600;
        width: 52px;
        cursor: pointer;
        background: rgb(19, 167, 71);
        height: 24px;
        line-height: 23px;
        border: none !important;
        border-radius: 2px;
        margin-left: 5px;
        text-align: center;
    }
    #ValidationSummary1 ul li {
        color: Red;
        font-size: 11px;
    }
    .clsDivHistory {
        background: #dddfe4;
        font-weight: 600;
        color: #575759;
        font-family: sans-serif;
        font-size: 11px;
        padding: 5px 0px;
        text-align: center;
        text-transform: capitalize;
        border: 1px solid #999;
        border-bottom: 0px;
        max-width: 298px;
        margin-top: 10px;
        border-bottom: 0px;
    }
    .AuthoriImage {
        max-width: 150px;
        min-width: 100px;
    }
    .AuthoriImage img {
        height: 40px;
        margin-top: 5px;
    }
    
    .btnClose {
        margin-left: 3px;
        color: rgb(255, 255, 255);
        font-size: 12px !important;
        float: left;
        font-weight: bold;
        width: 52px;
        cursor: pointer;
        background: rgb(19, 167, 71);
        height: 24px;
        line-height: 24px;
        border: none !important;
        border-radius: 2px;
        text-align: center;
        text-transform: capitalize;
        margin-top: 2px;
    }
    .btnClose:hover {
        color: red;
    }
    #divguidline div {
        width: 99.8% !important;
        border-color: #999 !important;
    }
    input[type="checkbox"] {
        position: relative;
        top: 3px;
    }
    input {
        text-transform: capitalize !important;
        margin: 2px 2px;
    }
    .AddCuurency::after {
        content: "₹ ";
        color: green;
        font-size: 12px;
        padding-left: 4px;
        position: relative;
        top: 1px;
    }
    input[readonly] {
        background-color: #ccc;
    }
    .modalNew {
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
    #Unitpopup {
        background: #eae7e7;
        margin: 0 auto;
        width: 286px;
        max-height: 200px;
        height: 112px;
        border-radius: 5px;
    }
    .BodyContect .btnOk {
        background: #4CAF50;
        color: #fff;
        border: 1px solid #4CAF50;
        border-radius: 2px;
        cursor: pointer;
        font-size: 12px;
        margin-top: 10px;
    }
    .BodyContect .btnCancel {
        background: #39589c;
        color: #fff;
        border: 1px solid #39589c;
        border-radius: 2px;
        cursor: pointer;
        font-size: 12px;
    }
    .UnitHeader {
        width: 99%;
        padding: 2px;
        background: #1f335d;
        color: #f8f8f8;
        margin: 0px 0px 3px 0px;
        text-align: center;
    }
    .UnitTable td .btnSubmit {
        font-weight: bold;
        width: 52px;
        cursor: pointer;
        background: rgb(19, 167, 71);
        height: 21px;
        line-height: 16px;
        border: none !important;
        border-radius: 2px;
        margin-left: 5px;
        text-align: center;
        float: unset;
        margin-top: 5px;
    }
    
    /* .UnitTable th
      {
           background: #dddfe4;
           border:1px solid #999;
           padding:5px 0px;
           text-align:center;
           font-weight: 500;
           font-size: 11px; 
           font-family:Arial;
       }*/
    .UnitTable td {
        text-align: center;
    }
    .SelectedColor {
        background-color: Yellow;
    }
    .BackColor {
        background: #fff;
    }
    .BackColor.SelectBackColor {
        background-color: Yellow;
    }
    .ModelPo {
        width: 280px;
        text-align: center;
        position: fixed;
        z-index: 100000;
        top: calc(50% - 10px/2);
        left: calc(40% - 20px/2);
    }
    .ModelPo2 {
        background: #e6e6e6;
        width: 470px;
        top: 50%;
        left: 50%;
        transform: translate(-50%, -50%);
        text-align: center;
        position: absolute;
        z-index: 100000;
        padding: 0px 0px 15px;
    }
    .backcolorpo {
        background: #eae7e7;
        width: 100%;
        min-height: 89px;
        padding: 0px 0px; /* box-shadow: 0px 0px 1px 3px #c5a0a099; */
        border-radius: 2px;
    }
    .BodyContect h2 {
        color: #fff;
        background: #39589c;
        width: 100%;
        padding: 2px 0px;
        font-size: 14px;
    }
    #ui-datepicker-div {
        background: #ff000000 !important;
        border-color: #1b1b1b00 !important;
    }
    #Pohistory {
        line-height: 20px;
        padding-top: 6px;
    }
    .Accessorytooltip {
        position: relative;
        display: inline-block;
    }
    
    .Accessorytooltip .tooltiptext {
        visibility: hidden;
        width: 300px;
        background-color: black;
        color: #fff;
        text-align: center;
        border-radius: 6px;
        padding: 8px 5px;
        position: absolute;
        z-index: 1;
        bottom: 150%;
        left: 50%;
        margin-left: -60px;
    }
    
    .Accessorytooltip .tooltiptext::after {
        content: "";
        position: absolute;
        top: 100%;
        left: 25%;
        margin-left: -5px;
        border-width: 5px;
        border-style: solid;
        border-color: black transparent transparent transparent;
    }
    
    .Accessorytooltip:hover .tooltiptext {
        visibility: visible;
    }
    
    .btnPrint {
        margin-left: 5px;
        font-size: 12px !important;
        color: rgb(255, 255, 255);
        font-weight: 600;
        width: 52px;
        cursor: pointer;
        background: #39589c !important;
        height: 24px;
        line-height: 26px;
        border: none !important;
        border-radius: 2px;
        float: left;
        text-align: center;
        margin-top: 2px;
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
    #sb-wrapper-inner.BorderPopup {
        background: #fff;
    }
    input[type="radio"] {
        position: relative;
        top: 2px;
    }
</style>
<script type="text/javascript" src='<%= Page.ResolveUrl("~/js/jquery-1.4.4.min.js")%>'></script>
<script type="text/javascript" src='<%= Page.ResolveUrl("~/js/jquery-ui-1.8.6.custom.min.js")%>'></script>
<script type="text/javascript" src='<%= Page.ResolveUrl("~/js/facebox.js")%>'></script>
<script type="text/javascript" src='<%= Page.ResolveUrl("~/js/js.js")%>'></script>
<script type="text/javascript" src='<%= Page.ResolveUrl("~/js/ImageFaceBox.js")%>'></script>
<script type="text/javascript" src='<%= Page.ResolveUrl("~/js/thickbox.js")%>'></script>
<script type="text/javascript" src='<%= Page.ResolveUrl("~/js/jquery.lightbox-0.5.min.js ")%>'></script>
<script type="text/javascript" src='<%= Page.ResolveUrl("~/js/jquery.dataTables.min.js ")%>'></script>
<script type="text/javascript" src='<%= Page.ResolveUrl("~/js/jquery.dataTables.js ")%>'></script>
<script type="text/javascript" src='<%= Page.ResolveUrl("~/js/ui.mask.js")%>'></script>
<script type="text/javascript" src='<%= Page.ResolveUrl("~/js/service.min.js")%>'></script>
<script type="text/javascript" src='<%= Page.ResolveUrl("~/js/jquery-ui.min.js")%>'></script>
<script type="text/javascript" src='<%= Page.ResolveUrl("~/js/jquery.ajaxQueue.js")%>'></script>
<script type="text/javascript" src='<%= Page.ResolveUrl("~/js/jquery.bgiframe.min.js")%>'></script>
<script type="text/javascript" src='<%=Page.ResolveUrl("~/js/form.js")%>'></script>
<script type="text/javascript" src='<%= Page.ResolveUrl("~/js/progress.js")%>'></script>
<script type="text/javascript" src='<%= Page.ResolveUrl("~/js/jquery.validate.min.js")%>'></script>
<script type="text/javascript" src='<%= Page.ResolveUrl("~/js/jquery-jtemplates.js")%>'></script>
<script type="text/javascript" src='<%= Page.ResolveUrl("~/js/jquery.form.js")%>'></script>
<script type="text/javascript" src='<%= Page.ResolveUrl("~/js/ui.core.js")%>'></script>
<script type="text/javascript" src='<%= Page.ResolveUrl("~/js/iKandi.js")%>'></script>
<script type="text/javascript" src='<%= Page.ResolveUrl("~/js/date.js")%>'></script>
<script type="text/javascript" src='<%= Page.ResolveUrl("~/js/jquery.jcarousel.js")%>'></script>
<script type="text/javascript" src='<%= Page.ResolveUrl("~/js/jquery.autocomplete.js")%>'></script>
<script type="text/javascript" src='<%= Page.ResolveUrl("~/js/jquery.fixedtableheader-1-0-2.min.js")%>'></script>
<script src='<%= Page.ResolveUrl("~/js/jquery.easydrag.js")%>' type="text/javascript"></script>
<script src='<%= Page.ResolveUrl("~/js/jquery.jqprint.0.3.js")%>' type="text/javascript"></script>
<script src='<%= Page.ResolveUrl("~/js/jquery.MultiFile.pack.js")%>' type="text/javascript"></script>
<script src='<%= Page.ResolveUrl("~/js/jquery.hoverIntent.min.js")%>' type="text/javascript"></script>
<script src='<%= Page.ResolveUrl("~/js/jquery.simpletip-1.3.1.pack.js")%>' type="text/javascript"></script>
<script src='<%= Page.ResolveUrl("~/js/jquery.tools.min.js")%>' type="text/javascript"></script>
<script src='<%= Page.ResolveUrl("~/js/colorpicker.js")%>' type="text/javascript"></script>
<script src='<%= Page.ResolveUrl("~/js/jquery.checkbox.min.js")%>' type="text/javascript"></script>
<script src='<%= Page.ResolveUrl("~/js/fna.js")%>' type="text/javascript"></script>
<script type="text/javascript">

    $(document).ready(function () {
        $('#txtETADate').attr('disabled', true);

        if ($('#ddlSupplierName').is(':disabled')) {
            SetCalenderMinAndMaxDateOnRevisePO_Accessory();
        }

    });

    function pageLoad(sender, args) {
        if (args.get_isPartialLoad()) {
            if ($('#ddlSupplierName').is(':disabled')) {
                SetCalenderMinAndMaxDateOnRevisePO_Accessory();
            }
            else {
                SetCalenderMinAndMaxDateOnRaisePO_Accessory();
            }

        }
    }

    var weekday = new Array(7);
    weekday[0] = "Sunday";
    weekday[1] = "Monday";
    weekday[2] = "Tuesday";
    weekday[3] = "Wednesday";
    weekday[4] = "Thursday";
    weekday[5] = "Friday";
    weekday[6] = "Saturday";

    var serviceUrl = '<%= ResolveUrl("~/Webservices/iKandiService.asmx/") %>';
    var proxy = new ServiceProxy(serviceUrl);

    var ddlSupplierName = '<%=ddlSupplierName.ClientID%>';
    var ddlAccessUnitClientId = '<%=ddlAccessUnit.ClientID%>';
    var hdnSupplierIdClientId = '<%=hdnSupplierId.ClientID%>';
    var lblPoNoClientId = '<%=lblPoNo.ClientID%>';
    var hdnPoNoClientId = '<%=hdnPoNo.ClientID%>';
    var txtPoDateClientId = '<%=txtPoDate.ClientID%>';
    var txtETADateClientId = '<%=txtETADate.ClientID%>';
    var txtRateClientId = '<%=txtRate.ClientID%>';
    var hdnBaseAccessUnitValClientId = '<%=hdnBaseAccessUnitVal.ClientID%>';
    var hdnSrvCountClientId = '<%=hdnSrvCount.ClientID%>';

    var txtUnitValueClientId = '<%=txtUnitValue.ClientID%>';
    var hdnConversionValClientId = '<%=hdnConversionVal.ClientID%>';
    var hdnUnitChangeClientId = '<%=hdnUnitChange.ClientID%>';

    var hdnReceivedBaseClientId = '<%=hdnReceivedBase.ClientID%>';
    var hdnReceived_CalBaseClientId = '<%=hdnReceived_CalBase.ClientID%>';
    var hdnReceivedClientId = '<%=hdnReceivedQty.ClientID%>';
    var hdnTotalAmountClientId = '<%=hdnTotalAmount.ClientID %>'; // shubhendu 20/09/21
    var hdnSendBaseClientId = '<%=hdnSendBase.ClientID%>';
    var hdnSend_CalBaseClientId = '<%=hdnSend_CalBase.ClientID%>';
    var hdnSendClientId = '<%=hdnSendQty.ClientID%>';
    var hdnShrinkageClientId = '<%=hdnShrinkage.ClientID%>';
    var hdnSrvQtyClientId = '<%=hdnSrvQty.ClientID%>';

    var lblTotalAmountClientId = '<%=lblTotalAmount.ClientID%>';
    var txtReceivedqtyClientId = '<%=txtReceivedqty.ClientID%>';
    var txtsentQtyClientId = '<%=txtsentQty.ClientID%>';
    var hdnoldrateClientID = '<%=hdnoldrate.ClientID%>';
    var AccessoryType = '<%=this.AccessoryType %>';
    var AccessoryMasterId = '<%=this.AccessoryMasterId %>';
    var Size = '<%=this.Size %>';
    var ColorPrint = '<%=this.ColorPrint %>';
    var QtyToOrder = '<%=this.QtyToOrder %>';
    var SupplierPoId = '<%=this.BaseSupplierPoId %>';


    $(function () {
        
        MyDatePickerFunction();
        var txtRate = $("#txtRate").val();      
        Sys.WebForms.PageRequestManager.getInstance().add_endRequest(MyDatePickerFunction);
        if ((AccessoryType == 1) || (AccessoryType == 3)) {
            $("#" + txtsentQtyClientId).attr('readonly', 'readonly');
        }
        else {
            $("#" + txtReceivedqtyClientId).attr('readonly', 'readonly');
        }

    });
    function MyDatePickerFunction() {
         
        var EtaMinDate = new Date();
        var POMinDate = new Date();

        var POMaxDate = new Date().addDays(30);
        var EtaMaxDate = new Date().addDays(120);

        $(".PODate").datepicker({ dateFormat: "dd M y (D)", minDate: POMinDate, maxDate: POMaxDate }).val();
        $(".EtaDate").datepicker({ dateFormat: "dd M y (D)", minDate: EtaMinDate, maxDate: EtaMaxDate }).val();
        //        $("#hdnETADateval").datepicker({ dateFormat: "dd M y (D)", minDate: EtaMinDate, maxDate: EtaMaxDate }).val();
    }

    function UpdateAccessoryRemarks(elem) {
         

        Po_Number = $('#' + hdnPoNoClientId).val();
        var UserId = $("#hdnUserid").val();
        var id = elem.id;

        ComVal = $('#' + id).val().trim();
     


        proxy.invoke("UpdateAccessoryRemarks", { Po_number: Po_Number, CommentRemarks: ComVal, UserId: UserId },
                    function (result) {
                    });

    }






    function GetSupplierChange() {

        var podate = $('#txtPoDate').val();
        $('#txtETADate').val(podate);
        $('#txtETADate').attr('disabled', true);
        var Rate = $("#" + txtRateClientId).val();

        $("#" + lblPoNoClientId).text('');
        $("#" + hdnPoNoClientId).val('');
        var SupplierId = $("#" + ddlSupplierName).val();
        $("#" + hdnSupplierIdClientId).val(SupplierId);
        if (SupplierId != "-1") {

            var url = "../../Webservices/iKandiService.asmx";

            $.ajax({
                type: "POST",
                url: url + "/GetAccessory_SupplierCode",
                data: "{ AccessoryMasterId:'" + AccessoryMasterId + "', Size:'" + Size + "', ColorPrint:'" + ColorPrint + "',SupplierId:'" + SupplierId + "',AccessoryType:'" + AccessoryType + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: OnSuccessCall,
                error: OnErrorCall
            });

            function OnSuccessCall(response) {
           
                var PoNumber = response.d[0].PoNumber;
                var Rate = response.d[0].QuotedLandedRate;

                $("#" + lblPoNoClientId).text(PoNumber);
                $("#" + hdnPoNoClientId).val(PoNumber);
                $("#" + txtRateClientId).val(Rate.toFixed(2));
                $("#" + hdnoldrateClientID).val(Rate);
                var RecievedQty = $("#" + hdnReceivedClientId).val();
                var TotalAmount = parseFloat(RecievedQty) * parseFloat(Rate);
                $("#" + hdnTotalAmountClientId).val(TotalAmount);
                $("#" + lblTotalAmountClientId).text(formatNumber(Math.round(TotalAmount, 0)));
                $("#" + ddlAccessUnitClientId).removeAttr("disabled");

                if ($('#ddlSupplierName').is(':disabled')) {
                    SetCalenderMinAndMaxDateOnRevisePO_Accessory();
                }
                else {
                    SetCalenderMinAndMaxDateOnRaisePO_Accessory();
                }
//                ResetGrd();
             
            }

            function OnErrorCall(response) {
                alert(response.status + " " + response.statusText);
            }

        }

    }
    function ChangeRate(obj) {

     
        var Rate = $(obj).val();
        if (Rate == "") {
            Rate = 0;
        }

        if (parseFloat(Rate) > 0) {
            var RecievedQty = $("#" + hdnReceivedClientId).val();
            var TotalAmount = parseFloat(RecievedQty) * parseFloat(Rate);
              $("#" + lblTotalAmountClientId).text(formatNumber(Math.round(TotalAmount, 0))); //shubhendu 20/09/2021
        }
        else {
            alert('Rate can not be empty or zero');
            $("#" + txtRateClientId).val('');
            $("#" + lblTotalAmountClientId).text('');
            $("#" + txtRateClientId).focus();
            return false;
        }
    }

    function ChangeRecievedQty() {
         
        var SupplierId = $("#" + ddlSupplierName).val();
        if (SupplierId == "-1") {
            alert('Please Select Supplier');
            $("#" + txtReceivedqtyClientId).val(formatNumber($("#" + hdnReceivedClientId).val()));
            return false;
        }
        var RecievedQty = $("#" + txtReceivedqtyClientId).val();
        RecievedQty = RecievedQty.replace(",", "");

        var SrvQty = $("#" + hdnSrvQtyClientId).val();
        var ConversionVal = $("#" + hdnConversionValClientId).val();
        var UnitChange = $("#" + hdnUnitChangeClientId).val();

        if (RecievedQty == "") {
            RecievedQty = 0;
        }
        if (parseFloat(RecievedQty) < parseFloat(SrvQty)) {
            alert('Po Qty can not be less than SRV Qty (' + SrvQty + ')');
            $("#" + txtReceivedqtyClientId).val(formatNumber($("#" + hdnReceivedClientId).val()));
            return false;
        }

        var hdnReceivedBase = $("#" + hdnReceivedBaseClientId).val();

        if (parseInt(RecievedQty) > 0) {

            if (SupplierPoId != "-1") {
                var TotalRecievedQty = 0;

                if ((UnitChange == '1') && (parseFloat(ConversionVal) > 0)) {
                    TotalRecievedQty = (parseFloat(hdnReceivedBase) + parseFloat(QtyToOrder)) * parseFloat(ConversionVal);
                }
                else {
                    TotalRecievedQty = parseInt(hdnReceivedBase) + parseInt(QtyToOrder);
                }

                if (parseInt(RecievedQty) > parseInt(TotalRecievedQty)) {
                    alert('Recieved Qty can not be Greater than Pending Qty (' + TotalRecievedQty + ')');
                    $("#" + txtReceivedqtyClientId).val(formatNumber($("#" + hdnReceivedClientId).val()));
                    $("#btnUpdateGrid").click();
                    return false;
                }
            }
            else {
                var NewQtyToOrder = QtyToOrder;
                if ((UnitChange == '1') && (parseFloat(ConversionVal) > 0)) {
                    var NewQtyToOrder = parseFloat(QtyToOrder) * parseFloat(ConversionVal);
                }
                if (parseInt(RecievedQty) > parseInt(NewQtyToOrder)) {
                    alert('Recieved Qty can not be Greater than Pending Qty (' + NewQtyToOrder + ')');
                    $("#" + txtReceivedqtyClientId).val(formatNumber($("#" + hdnReceivedClientId).val()));
                    $("#btnUpdateGrid").click();
                    return false;
                }
            }

            $("#" + hdnReceivedClientId).val(Math.round(RecievedQty, 0));
            $("#" + txtReceivedqtyClientId).val(formatNumber(Math.round(RecievedQty, 0)));

            if ((UnitChange == '1') && (parseFloat(ConversionVal) > 0)) {
                var BaseRecievedQty = Math.round(parseFloat(RecievedQty) / parseFloat(ConversionVal), 0);
                $("#" + hdnReceived_CalBaseClientId).val(BaseRecievedQty);
                //$("#" + hdnoldrateClientID).val(txtRateClientId);// shubhendu
            }
            else {
                $("#" + hdnReceived_CalBaseClientId).val(Math.round(RecievedQty, 0));
            }

            var Rate = $("#" + txtRateClientId).val();
            //shubhendu
            var TotalAmount = parseFloat(RecievedQty) * parseFloat(Rate);

            //  $("#" + lblTotalAmountClientId).text(formatNumber(Math.round(TotalAmount, 0)));// Shubhendu 20/09/2021
            $("#btnUpdateGrid").click();

            var PoNumber = $("#" + hdnPoNoClientId).val();
            $("#" + lblPoNoClientId).text(PoNumber);

        }
        else {
            alert('Recieved Qty can not be empty or zero');
            if (SupplierPoId != "-1") {
                var hdnRecievedQty = $("#" + hdnReceivedClientId).val();
                $("#" + txtReceivedqtyClientId).val(formatNumber(hdnRecievedQty));
            }
            else {
                var Received_CalBase = $("#" + hdnReceived_CalBaseClientId).val();
                $("#" + txtReceivedqtyClientId).val(formatNumber(Received_CalBase));
                $("#" + hdnReceivedClientId).val(Received_CalBase);
            }

            return false;
        }
    }

    function ChangeSendQty(obj) {
         
        var SupplierId = $("#" + ddlSupplierName).val();
        if (SupplierId == "-1") {
            alert('Please Select Supplier');
            $("#" + txtsentQtyClientId).val(formatNumber($("#" + hdnSendClientId).val()));
            return false;
        }
        var SendQty = $(obj).val();
        SendQty = SendQty.replace(",", "");

        var ConversionVal = $("#" + hdnConversionValClientId).val();
        var UnitChange = $("#" + hdnUnitChangeClientId).val();

        if (SendQty == "") {
            SendQty = 0;
        }
        var hdnSendBase = $("#" + hdnSendBaseClientId).val();
        var hdnShrinkage = $("#" + hdnShrinkageClientId).val();
        var RecievedQty = 0;

        if (parseInt(SendQty) > 0) {

            if (SupplierPoId != "-1") {
                var TotalSendQty = 0;
                if ((UnitChange == '1') && (parseFloat(ConversionVal) > 0)) {
                    TotalSendQty = (parseFloat(hdnSendBase) + parseFloat(QtyToOrder)) * parseFloat(ConversionVal);
                }
                else {
                    TotalSendQty = parseInt(hdnSendBase) + parseInt(QtyToOrder);
                }

                if (parseInt(SendQty) > parseInt(TotalSendQty)) {
                    alert('Send Qty can not be Greater than Pending Qty (' + TotalSendQty + ')');
                    $("#" + txtsentQtyClientId).val(formatNumber($("#" + hdnSendClientId).val()));
                    $("#btnUpdateGrid").click();
                    return false;
                }
            }
            else {
                var NewQtyToOrder = QtyToOrder;
                if ((UnitChange == '1') && (parseFloat(ConversionVal) > 0)) {
                    var NewQtyToOrder = parseFloat(QtyToOrder) * parseFloat(ConversionVal);
                }
                if (parseInt(SendQty) > parseInt(NewQtyToOrder)) {
                    alert('Send Qty can not be Greater than Pending Qty (' + NewQtyToOrder + ')');
                    $("#" + txtsentQtyClientId).val(formatNumber($("#" + hdnSendClientId).val()));
                    $("#btnUpdateGrid").click();

                    return false;
                }
            }

            if (parseInt(hdnShrinkage) > 0) {
                RecievedQty = parseFloat(SendQty) - ((parseFloat(SendQty) * parseFloat(hdnShrinkage)) / 100)
            }
            else {
                RecievedQty = SendQty;
            }

            $("#" + hdnReceivedClientId).val(Math.round(RecievedQty, 0));
            $("#" + txtReceivedqtyClientId).val(Math.round(RecievedQty, 0));

            if ((UnitChange == '1') && (parseFloat(ConversionVal) > 0)) {
                var BaseRecievedQty = Math.round(parseFloat(RecievedQty) / parseFloat(ConversionVal), 0);
                $("#" + hdnReceived_CalBaseClientId).val(BaseRecievedQty);

                var BaseSendQty = Math.round(parseFloat(SendQty) / parseFloat(ConversionVal), 0);
                $("#" + hdnSend_CalBaseClientId).val(BaseSendQty);
            }
            else {
                $("#" + hdnReceived_CalBaseClientId).val(RecievedQty);
                $("#" + hdnSend_CalBaseClientId).val(SendQty);
            }

            $("#" + hdnSendClientId).val(Math.round(SendQty, 0));

            $("#" + txtsentQtyClientId).val(formatNumber(Math.round(SendQty, 0)));
            var Rate = $("#" + txtRateClientId).val();
            var TotalAmount = parseFloat(RecievedQty) * parseFloat(Rate);
            $("#" + lblTotalAmountClientId).text(formatNumber(Math.round(TotalAmount, 0)));
            //   $("#lblTotalAmount").text(formatNumber(Math.round(TotalAmount, 0)));
            $("#btnUpdateGrid").click();
            var PoNumber = $("#" + hdnPoNoClientId).val();
            $("#" + lblPoNoClientId).text(PoNumber);
        }
        else {
            alert('Send Qty can not be empty or zero');
            if (SupplierPoId != "-1") {
                var hdnSendQty = $("#" + hdnSendClientId).val();
                $("#" + txtsentQtyClientId).val(formatNumber(hdnSendQty));
            }
            else {
                var Send_CalBase = $("#" + hdnSend_CalBaseClientId).val();
                $("#" + txtsentQtyClientId).val(formatNumber(Send_CalBase));
                $("#" + hdnSendClientId).val(Send_CalBase);
            }

            return false;
        }
    }

    function ValidateControls() {
         
        var SupplierId = $("#" + hdnSupplierIdClientId).val();
        if (SupplierId == "-1") {
            alert('Please Select Supplier');
            $("#" + ddlSupplierName).focus();
            return false;
        }
        var RecievedQty = $("#" + hdnReceivedClientId).val();
        if (RecievedQty == "") {
            RecievedQty = 0;
        }
        if (parseInt(RecievedQty) <= 0) {
            alert('Recieved Qty can not be empty or zero');
            $("#" + txtReceivedqtyClientId).focus();
            return false;
        }
        var Rate = $("#" + txtRateClientId).val();
        if (Rate == "") {
            Rate = 0;
        }
        if (parseFloat(Rate) <= 0) {
            alert('Rate can not be empty or zero');
            $("#" + txtRateClientId).focus();
            return false;
        }
        var UnitId = $("#" + ddlAccessUnitClientId).val();
        if (parseInt(UnitId) <= 0) {
            alert('Please Select Unit');
            $("#" + txtReceivedqtyClientId).focus();
            return false;
        }

        var RowId = 0;
        var gvId;
        var GridRow = $(".gvQtyRangeRow").length;
        for (var row = 1; row <= GridRow; row++) {
            RowId = parseInt(row) + 1;
            if (RowId < 10)
                gvId = 'ctl0' + RowId;
            else
                gvId = 'ctl' + RowId;

            var ToQty = $("#<%= grdQtyRange.ClientID %> input[id*='" + gvId + "_txtToQty" + "']").val();
            var Eta = $("#<%= grdQtyRange.ClientID %> input[id*='" + gvId + "_txtRangeEta" + "']").val();

            if (ToQty == '') {
                alert('To qty cannot be Empty');
                $("#<%= grdQtyRange.ClientID %> input[id*='" + gvId + "_txtToQty" + "']").focus();
                return false;
            }
            if (Eta == '') {
                alert('Eta cannot be Empty');
                return false;
            }
        }
    }

    function formatNumber(num) {
        return num.toString().replace(/(\d)(?=(\d{3})+(?!\d))/g, '$1,')
    }

    function CheckToQty(obj) {
         
        var Ids = obj.id;
        var gvId = Ids.split("_")[1].substr(3);
        var ToQty = $(obj).val();

        if (ToQty == '') {
            alert('To qty cannot be Empty');
            $(obj).focus();
            return false;
        }

        var BaseToQty = $("#<%= grdQtyRange.ClientID %> input[id*='ctl" + gvId + "_hdnToQty" + "']").val();

        if (ToQty == "") {
            ToQty = 0;
        }
        var TotalQty = 0;
        TotalQty = $("#" + hdnReceivedClientId).val();

        if (parseInt(ToQty) > parseInt(TotalQty)) {
            alert('To qty cannot be greather then total received qty');
            $(obj).val(BaseToQty);
            $(obj).focus();
            return false;
        }
        var FromQty = $("#<%= grdQtyRange.ClientID %> input[id*='ctl" + gvId + "_txtFromQty" + "']").val();
        if (parseInt(FromQty) > parseInt(ToQty)) {
            alert('To qty cannot be less then from qty');
            $(obj).val(BaseToQty);
            $(obj).focus();
            return false;
        }

        $("#<%= grdQtyRange.ClientID %> input[id*='ctl" + gvId + "_txtRangeEta" + "']").val('');
    }
    function ValidateQtyRange(obj) {
         
        var Ids = obj.id;
        if (Ids == 2)
            return;
        var gvId = Ids.split("_")[1].substr(3);

        var ToQty = $("#<%= grdQtyRange.ClientID %> input[id*='ctl" + gvId + "_txtToQty" + "']").val();
        var Eta = $("#<%= grdQtyRange.ClientID %> input[id*='ctl" + gvId + "_txtRangeEta" + "']").val();

        if (ToQty == '') {
            alert('To qty cannot be Empty');
            $("#<%= grdQtyRange.ClientID %> input[id*='ctl" + gvId + "_txtToQty" + "']").focus();
            return false;
        }
        if (Eta == '') {
            alert('Eta cannot be Empty');
            return false;
        }
    }

    function CheckEtaDates(obj) {
         
        var selecteddates = $(obj).val();
        var Ids = obj.id.split("_")[1].substr(3);
        var thisId = 'ctl' + Ids;
        var PrevId = '';
        var IdInt = parseInt(Ids) - 1;
        if (IdInt < 10)
            PrevId = 'ctl0' + IdInt;
        else
            PrevId = 'ctl' + IdInt;

        if (selecteddates != '') {
            var PoDate = $("#" + txtPoDateClientId).val();
            var EtaDate = $("#" + txtETADateClientId).val();

            var DateThis = new Date(ParseDateToSimpleDate(selecteddates));
            var MinDate = new Date(ParseDateToSimpleDate(PoDate));
            var MaxDate = new Date(ParseDateToSimpleDate(EtaDate));

            if ((DateThis < MinDate) || (DateThis > MaxDate)) {
                alert('this range date must between PO date and Eta Date');
                $(obj).val('');
                return false;
            }

            var year_a = DateThis.getFullYear();
            var month_a = DateThis.getMonth() + 1;
            var day_a = DateThis.getDate();

            var SelectedDate = month_a + '/' + day_a + '/' + year_a;

            var RowId = 0;
            var gvId;
            var GridRow = $(".gvQtyRangeRow").length;
            for (var row = 1; row <= GridRow; row++) {
                RowId = parseInt(row) + 1;
                if (RowId < 10)
                    gvId = 'ctl0' + RowId;
                else
                    gvId = 'ctl' + RowId;

                 

                if (thisId != gvId) {
                    var lbldatesEta = $("#<%= grdQtyRange.ClientID %> span[id*='" + gvId + "_lbldates" + "']").text();
                    var RangeDate = new Date(ParseDateToSimpleDate(lbldatesEta));

                    var year_b = RangeDate.getFullYear();
                    var month_b = RangeDate.getMonth() + 1;
                    var day_b = RangeDate.getDate();

                    var CurrentDate = month_b + '/' + day_b + '/' + year_b;

                    if (SelectedDate == CurrentDate) {
                        alert('duplicate Date range');
                        $(obj).val('');
                        return false;
                    }
                }
            }
            var PrevEtaDate = $("#<%= grdQtyRange.ClientID %> span[id*='" + PrevId + "_lbldates" + "']").text();
            if (PrevEtaDate != '') {
                var PrevRangeDate = new Date(ParseDateToSimpleDate(PrevEtaDate));

                var year_c = PrevRangeDate.getFullYear();
                var month_c = PrevRangeDate.getMonth() + 1;
                var day_c = PrevRangeDate.getDate();

                var PrevDate = month_c + '/' + day_c + '/' + year_c;

                if (new Date(SelectedDate) < new Date(PrevDate)) {
                    alert('this Date range can not be less than Previous Date Range');
                    $(obj).val('');
                    return false;
                }
            }
        }

    }
    function ResetGrd() {
        debugger;
        var SupplierId = $("#" + ddlSupplierName).val();
        if (SupplierId != "-1") {
            $("#btnUpdateGrid").click();

            //            $("#hdnETADateval").val($("#" + txtPoDateClientId).val());

            //            alert($("#hdnETADateval").val());
        }
        else {
            alert('Please Select Supplier');
            var PrevEta = $("#hdnEtaDate").val();
            $("#" + txtETADateClientId).val(PrevEta);
            return false;
        }
    }
    function closePageWithMessage() {
         
        if ($("#hdnMailSentStatus").val() == "0") {
            alert('Saved Successfully!');
        }
        var TypeName = '';

        if (AccessoryType == 1)
            TypeName = 'GREIGE';
        else if (AccessoryType == 2)
            TypeName = 'PROCESS';
        else if (AccessoryType == 3)
            TypeName = 'FINISHING';

        self.parent.parent.ShowHideSuppliergrd(TypeName);
        self.parent.Shadowbox.close();
    }

    function closePage() {
         
        var TypeName = '';

        if (AccessoryType == 1)
            TypeName = 'GREIGE';
        else if (AccessoryType == 2)
            TypeName = 'PROCESS';
        else if (AccessoryType == 3)
            TypeName = 'FINISHING';

        self.parent.parent.ShowHideSuppliergrd(TypeName);
        self.parent.Shadowbox.close();
    }

    function OpenUnitPopup(obj) {
         
        var SelectedUnitName = $(obj).find("option:selected").text();
        var SelectedUnitId = $(obj).find("option:selected").val();
        var hdnAccessUnitValClientId = '<%=hdnAccessUnitVal.ClientID%>';
        // var  = $("#" + txtRateClientId).val();//shubhendu
        //  var hdnoldrate1 = $("#" + txtRateClientId).val(); //shubhendu
        var PrevUnitId = $("#" + hdnAccessUnitValClientId).val();

        if (SelectedUnitId == '-1') {
            alert('Please select valid Unit');
            $("#" + ddlAccessUnitClientId).val(PrevUnitId);
            return false;
        }

        $("#" + txtUnitValueClientId).val('');
        var BaseUnitId = $("#" + hdnBaseAccessUnitValClientId).val();
        var oldrate = $("#" + txtRateClientId).val();
        // $("#" + hdnoldrateClientID).val(oldrate); //
        // alert(oldrate);


        //new code to get conversion value start 23/03/2021
        var CurrentUnitId = SelectedUnitId;
        var PreviousUnitId = PrevUnitId;
        proxy.invoke("GetAccessory_ConversionValue", { CurrentUnitId: CurrentUnitId, PreviousUnitId: PreviousUnitId },
            function (result) {
                if (result > 0) {
                    //alert(result.toString());
                    $("#txtUnitValue").val(result);
                }
            });
        //new code to get conversion value end 23/03/2021

        if (SelectedUnitId == BaseUnitId) {
            if ((AccessoryType == 1) || (AccessoryType == 3)) {

                var ReceivedBaseQty = $("#" + hdnReceived_CalBaseClientId).val();
                //hdnoldrate
                $("#" + hdnReceivedClientId).val(ReceivedBaseQty);
                $("#" + txtReceivedqtyClientId).val(formatNumber(ReceivedBaseQty));

                var setRate = $("#" + hdnoldrateClientID).val();
                $("#" + txtRateClientId).val(setRate);
                var Rate = $("#" + txtRateClientId).val();
                if (Rate != '') {
                    var TotalAmount = parseFloat(ReceivedBaseQty) * parseFloat(Rate);
                    //  $("#" + lblTotalAmountClientId).text(formatNumber(Math.round(TotalAmount, 0))); //Shubhendu 20/09/2021
                }
            }
            else if (AccessoryType == 2) {

                var ReceivedBaseQty = $("#" + hdnReceived_CalBaseClientId).val();
                var SendBaseQty = $("#" + hdnSend_CalBaseClientId).val();
                var BaseRate = $("#" + hdnoldrateClientID).val();
                $("#" + txtRateClientId).val(BaseRate);
                $("#" + hdnReceivedClientId).val(ReceivedBaseQty);
                $("#" + txtReceivedqtyClientId).val(formatNumber(ReceivedBaseQty));

                $("#" + hdnSendClientId).val(Math.round(SendBaseQty, 0));
                $("#" + txtsentQtyClientId).val(formatNumber(SendBaseQty));

                // var Rate = $("#" + txtRateClientId).val();// shubhendu
                var Rate = $("#" + hdnoldrateClientID).val();
                if (Rate != '') {
                    var TotalAmount = parseFloat(ReceivedBaseQty) * parseFloat(Rate);
                    //    $("#" + lblTotalAmountClientId).text(formatNumber(Math.round(TotalAmount, 0)));// shubhendu 20/09/2021
                }
            }
            $("#" + hdnUnitChangeClientId).val(0);
            $("#btnUpdateGrid").click();
        }
        else {
            if (SupplierPoId == "-1") {
                var hdnReceivedBase = $("#" + hdnReceivedBaseClientId).val();

                $("#" + hdnReceived_CalBaseClientId).val(hdnReceivedBase);
                $("#" + hdnReceivedClientId).val(hdnReceivedBase);
                $("#" + txtReceivedqtyClientId).val(formatNumber(hdnReceivedBase));

                if (AccessoryType == 2) {
                    var SendBaseQty = $("#" + hdnSendBaseClientId).val();

                    $("#" + hdnSend_CalBaseClientId).val(SendBaseQty);
                    $("#" + hdnSendClientId).val(Math.round(SendBaseQty, 0));
                    $("#" + txtsentQtyClientId).val(formatNumber(SendBaseQty));
                }
            }
            else {
                var ReceivedBaseQty = $("#" + hdnReceived_CalBaseClientId).val();
                $("#" + hdnReceivedClientId).val(Math.round(ReceivedBaseQty));
                $("#" + txtReceivedqtyClientId).val(formatNumber(Math.round(ReceivedBaseQty)));

                var SendBaseQty = $("#" + hdnSend_CalBaseClientId).val();
                $("#" + hdnSendClientId).val(Math.round(SendBaseQty, 0));
                $("#" + txtsentQtyClientId).val(formatNumber(SendBaseQty));
            }

            var hdnUnitNameClientId = '<%=hdnAccessUnitName.ClientID%>';
            var lblPreviousUnitClientId = '<%=lblPreviousUnit.ClientID%>';
            var lblCurrentUnitClientId = '<%=lblCurrentUnit.ClientID%>';

            var UnitName = $("#" + hdnUnitNameClientId).val();

            $("#" + lblPreviousUnitClientId).text(UnitName);
            $("#" + lblCurrentUnitClientId).text(SelectedUnitName);

            $("#dvUnit").css("display", "block");
            $(".ui-helper-clearfix").css("display", "inline-block !important;");

        }
    }

    function UnitSubmit() {
         
        var txtUnitValue = $("#" + txtUnitValueClientId).val();
        if ((txtUnitValue == '') || (txtUnitValue == '0')) {
            alert('Unit value can not be empty');
            $("#" + txtUnitValueClientId).val('');
            return false;
        }
        $("#" + hdnConversionValClientId).val(txtUnitValue);
        if ((AccessoryType == 1) || (AccessoryType == 3)) {
            // --------------------------------------------- Griege and Finish work ------------------------------------------
            var RecievedQty = $("#" + hdnReceivedClientId).val();
            var oldrate = $("#" + hdnoldrateClientID).val();
            //    alert(oldrate);

            if (parseInt(RecievedQty) > 0) {
                var NewRecievedQty = parseFloat(RecievedQty) * parseFloat(txtUnitValue);

                $("#" + hdnReceivedClientId).val(Math.round(NewRecievedQty, 0));
                $("#" + txtReceivedqtyClientId).val(formatNumber(Math.round(NewRecievedQty, 0)));
                // var Rate = $("#" + txtRateClientId).val();//commented by shubhendu
                var Rate = $("#" + hdnoldrateClientID).val();

                // ("#"+hdnoldrate).val(Rate)

                if (Rate != '') {
                    //   var TotalAmount = parseFloat(NewRecievedQty) * parseFloat(Rate);
                    // by shubhendu
                    //     $("#" + lblTotalAmountClientId).text(formatNumber(Math.round(TotalAmount, 0)));
                    var NewRate = Rate * 1 / txtUnitValue;
                    var RateVal = NewRate.toFixed(2);
                    $("#" + txtRateClientId).text(RateVal);
                    $("#" + txtRateClientId).val(RateVal);
                    //  $("#" + lblTotalAmountClientId).text(formatNumber(Math.round(TotalAmount, 0)));// shubhendu
                }
            }
        }
        else if (AccessoryType == 2) {
            // --------------------------------------------- Process work ------------------------------------------
            var RecievedQty = $("#" + hdnReceivedClientId).val();
            var SendQty = $("#" + hdnSendClientId).val();


            if (parseInt(RecievedQty) > 0) {
                var NewRecievedQty = parseFloat(RecievedQty) * parseFloat(txtUnitValue);
                var NewSendQty = parseFloat(SendQty) * parseFloat(txtUnitValue);

                $("#" + hdnReceivedClientId).val(Math.round(NewRecievedQty, 0));
                $("#" + txtReceivedqtyClientId).val(formatNumber(Math.round(NewRecievedQty, 0)));

                $("#" + hdnSendClientId).val(Math.round(NewSendQty, 0));
                $("#" + txtsentQtyClientId).val(formatNumber(Math.round(NewSendQty, 0)));

                //  var Rate = $("#" + txtRateClientId).val();//commented by shubhendu
                var Rate = $("#" + hdnoldrateClientID).val();

                if (Rate != '') {
                    // var TotalAmount = parseFloat(NewRecievedQty) * parseFloat(Rate);
                    var NewRate = Rate * 1 / txtUnitValue;
                    var NewRateVal = NewRate.toFixed(2);
                    $("#" + txtRateClientId).text(NewRateVal);
                    $("#" + txtRateClientId).val(NewRateVal);
                    // $("#" + lblTotalAmountClientId).text(formatNumber(Math.round(TotalAmount, 0)));// shubhendu 09/20/2021                                                                                                                                                 
                }
            }
        }
        $("#dvUnit").hide();
        $("#" + hdnUnitChangeClientId).val(1);
        $("#btnUpdateGrid").click();

        return false;
    }

    function UnitCancel() {
         
        var hdnAccessUnitValClientId = '<%=hdnAccessUnitVal.ClientID%>';
        var AccessUnitVal = $("#" + hdnAccessUnitValClientId).val();
        $("#" + ddlAccessUnitClientId).val(AccessUnitVal);

        var hdnCancel_ReceivedQtyClientId = '<%=hdnCancel_ReceivedQty.ClientID%>';

        var CancelReceivedQty = $("#" + hdnCancel_ReceivedQtyClientId).val();

        $("#" + hdnReceivedClientId).val(Math.round(CancelReceivedQty));
        $("#" + txtReceivedqtyClientId).val(formatNumber(Math.round(CancelReceivedQty)));

        if (AccessoryType == 2) {

            var hdnCancel_SendQtyClientId = '<%=hdnCancel_SendQty.ClientID%>';

            var CancelSendQty = $("#" + hdnCancel_SendQtyClientId).val();

            $("#" + hdnSendClientId).val(Math.round(CancelSendQty, 0));
            $("#" + txtsentQtyClientId).val(formatNumber(CancelSendQty));
        }

        $("#dvUnit").hide();
        return false;
    }

    function closeUnitPopup() {

        $("#dvUnit").hide();
    }

    //created by Girish on 2023-03-16
    function isNumberWithDecimal(evt, obj) {

        var charCode = (evt.which) ? evt.which : event.keyCode
        var value = obj.value;
        var dotcontains = value.indexOf(".") != -1;
        if (dotcontains)
            if (charCode == 46) return false;
        if (charCode == 46) return true;
        if (charCode > 31 && (charCode < 48 || charCode > 57))
            return false;
        return true;
    }
    //created by Girish on 2023-03-16



    function EtagrdRest() {

  
        var grdtable = document.getElementById('grdQtyRange');
        var rowLength = grdtable.rows.length;  
        var _globalqty = $("#" + hdnReceivedClientId).val();      
        var POETAdate = $("#txtETADate").val();
        $('#grdQtyRange_ctl02_lblFromQty' + parseInt(0).toString()).val(1);
        $('#grdQtyRange_ctl02_txttoqty' + parseInt(0).toString()).val(_globalqty);

        for (var i = 1; i < rowLength; i += 1) {
            var row = grdtable.rows[i];
            // $('#trbreaek' + parseInt(i).toString()).hide();

            $('#grdQtyRange_ctl02_lblFromQty' + parseInt(i).toString()).val("");
            $('#grdQtyRange_ctl02_txttoqty' + parseInt(i).toString()).val("");
            $('#grdQtyRange_ctl02_lbldates' + parseInt(i).toString()).val("");

            $('#grdQtyRange_ctl02_lblFromQty' + parseInt(i).toString()).text("");
            $('##grdQtyRange_ctl02_txttoqty' + parseInt(i).toString()).text("");
            $('#grdQtyRange_ctl02_lbldates' + parseInt(i).toString()).text("");

            $('#grdQtyRange_ctl02_lblFromQty' + parseInt(i).toString()).hide();
            $('#grdQtyRange_ctl02_txttoqty' + parseInt(i).toString()).hide();


            $('#edit' + i).hide();
            $('#grdQtyRange_ctl02_lbldates' + parseInt(i).toString()).hide();

            $('#editcancel' + parseInt(i).toString()).hide();
            $('#editupdate' + parseInt(i).toString()).hide();
            $('#editdelete' + parseInt(i).toString()).hide();
        }
    }



    function ChangeColorDropDown() {

        $("#ddlAccessUnit").addClass('SelectedColor');
        $("#ddlAccessUnit").find('option').addClass('BackColor');
        $('option:selected').addClass('SelectBackColor');

    }

    function BaseColorDropDown() {
        $("#ddlAccessUnit").removeClass('SelectedColor');
        $('option:selected').removeClass('SelectBackColor');
        $("#ddlAccessUnit").find('option').addClass('BackColor');
    }
    function history_Click() {
         
        var SupplierPOId = $("#hdnSupplierPoId").val();

        //alert(SupplierPOId);
        var hist = "";
        proxy.invoke("GetPOAccesoryHistory", { SupplierPOId: SupplierPOId },
                    function (response) {
                        if (response.length > 0) {
                            $("#divhistory").show();
                            for (var i = 0; i < response.length; i++) {
                                hist += response[i].DetailDescription + "<br>";
                                // alert(hist);
                            }
                            $("#Pohistory").html(hist);
                        }


                    });
    }
    function showhistory() {
        $("#divhistory").hide();
    }
    function DisplaySendMail() {
        // 
        //        if ($("#chkAuthorizedSignatory").is(':checked') && $("#chkpartysignature").is(':checked')) {
        if ($("#chkAuthorizedSignatory").is(':checked')) { // && $("#chkpartysignature").is(':checked')) {
            $("#dvSendMail").css("display", "block")
            return false;
        }
        else {
            $("#dvSendMail").css("display", "none")
            return false;
        }

    }

    function SetCalenderMinAndMaxDateOnRevisePO_Accessory() {
        $('#txtETADate').attr('disabled', false);
        var SupplierId = $("#" + ddlSupplierName).val();

        var url = "../../Webservices/iKandiService.asmx";
        $.ajax({
            type: "POST",
            url: url + "/GetAccessory_SupplierCode",
            data: "{  AccessoryMasterId:'" + AccessoryMasterId + "', Size:'" + Size + "', ColorPrint:'" + ColorPrint + "',SupplierId:'" + SupplierId + "',AccessoryType:'" + AccessoryType + "'}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: OnSuccessCall,
            error: OnErrorCall
        });

        function OnSuccessCall(response) {
            debugger;
            var SupplierLeadDays = response.d[0].leadday;
            var SupplierLeadRange = response.d[0].leadrange;          

            var d1 = new Date($('#txtPoDate').val());
            var d2 = new Date($("#txtETADate").val());
                $("#txtETADate").datepicker("option", "minDate", new Date(d1.setDate(d1.getDate() )));
                var maxxdate = new Date(d2.setDate(d2.getDate()));//04052023

                if (new Date($("#txtETADate").val()) > maxxdate) {
                    $("#txtETADate").datepicker("option", "maxDate", new Date($("#txtETADate").val()));
                }
                else {
                    $("#txtETADate").datepicker("option", "maxDate", maxxdate);
                }
                $('#ui-datepicker-div').css("display", "none");
              
//            if (SupplierLeadDays != null && SupplierLeadDays != '') {
//                var d1 = new Date($('#txtPoDate').val());
//                $("#txtETADate").datepicker("option", "minDate", new Date(d1.setDate(d1.getDate() + parseInt(SupplierLeadDays))));
//                var maxxdate = new Date(d1.setDate(d1.getDate() + parseInt(SupplierLeadRange)));

//                if (new Date($("#txtETADate").val()) > maxxdate) {
//                    $("#txtETADate").datepicker("option", "maxDate", new Date($("#txtETADate").val()));
//                }
//                else {
//                    $("#txtETADate").datepicker("option", "maxDate", maxxdate);
//                }
//                $('#ui-datepicker-div').css("display", "none");
//            }
        }

        function OnErrorCall(response) {
            alert(response.status + " " + response.statusText);
        }
    }

    function SetCalenderMinAndMaxDateOnRaisePO_Accessory() {
        $('#txtETADate').attr('disabled', false);
        var SupplierId = $("#" + ddlSupplierName).val();

        var url = "../../Webservices/iKandiService.asmx";
        $.ajax({
            type: "POST",
            url: url + "/GetAccessory_SupplierCode",
            data: "{  AccessoryMasterId:'" + AccessoryMasterId + "', Size:'" + Size + "', ColorPrint:'" + ColorPrint + "',SupplierId:'" + SupplierId + "',AccessoryType:'" + AccessoryType + "'}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: OnSuccessCall,
            error: OnErrorCall
        });

        function OnSuccessCall(response) {
            var SupplierLeadDays = response.d[0].leadday;
            var SupplierLeadRange = response.d[0].leadrange;

            if (SupplierLeadDays != null && SupplierLeadDays != '') {
                var d1 = new Date($('#txtPoDate').val());
                $("#txtETADate").datepicker("option", "minDate", new Date(d1.setDate(d1.getDate() )));
                $("#txtETADate").datepicker("option", "maxDate", new Date(d1.setDate(d1.getDate() + parseInt(SupplierLeadDays))));
                $("#txtETADate").datepicker("setDate", new Date(d1.setDate(d1.getDate() + parseInt(SupplierLeadDays))));
                $('#ui-datepicker-div').css("display", "none");

            }
        }
        function OnErrorCall(response) {
            alert(response.status + " " + response.statusText);
        }
    }
</script>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdateProgress runat="server" ID="uproTargetAdmin" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="0">
        <ProgressTemplate>
            <img src="../../App_Themes/ikandi/images1/loading36.gif" alt="" style="position: fixed; z-index: 52111; top: 40%; left: 45%; width: 6%;" />
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
        <ContentTemplate>
            <asp:HiddenField ID="hdnMailSentStatus" Value="0" runat="server" />
            <asp:HiddenField ID="hdnStageName" runat="server" Value="" />
            <div style="width: 99%; margin: 0 auto">
                <div>
                    <table class="purchase_order" style="margin-top: 3px; border-bottom: 0px; border-right-color: #999; border-left-color: #999;">
                        <thead>
                            <tr>
                                <th style="display: flex;text-align: left;align-items: center;border: 0;border-right: 1px solid lightgray;padding-right: 17px;box-sizing: border-box;width:700px" class="barder_top_color">
                                    <div style="padding: 5px 7px 8px">
                                        <img src="../../images/boutique-logo.png">
                                    </div>
                                    <div id="divbipladdress" runat="server" style="padding-left: 5px;">
                                    </div>
                                </th>
                                <th style="text-align: left; border-left: 0px;border-bottom: 0;"  rowspan="2" class="barder_top_color">
                                    <span id="Order_text" runat="server" style="font-size:20px;font-weight:500;margin-right: 50px;"></span>
                                    <a onclick="history_Click()" id="ShowImgHis" class="printHideButton" runat="server" visible="false" style="color: Blue; position: absolute; right: 10px; cursor: pointer;" target="_blank">
                                        <img src="../../images/history1.png" /></a>
                                </th>
                            </tr>
                        </thead>
                    </table>
                    <table class="purchase_order" style="margin-top: 0px; border-bottom: 0px; border-right-color: #999; border-left-color: #999;">
                        <tbody>
                            <tr>
                                <td style="padding-left: 7px; border-left-color: #999; width: 46px">
                                    PO No:
                                </td>
                                <td>
                                    <asp:Label ID="lblPoNo" Width="80px" Style="font-weight: bold; font-size: 13px;" runat="server"></asp:Label>
                                    <asp:HiddenField ID="hdnPoNo" runat="server" />
                                    <asp:HiddenField ID="hdnSupplierPoId" Value="-1" runat="server" />
                                </td>
                                <td style="text-align: right;">
                                    PO Date
                                </td>
                                <td>
                                    <asp:TextBox ID="txtPoDate" style=" Width:75px;color:black;font-weight:600;" CssClass="PODate do-not-allow-typing" onchange="Resetetagrd()" runat="server" disabled></asp:TextBox>
                                </td>
                                <td style="text-align: right;">
                                    Supplier<span style="color: red; font-size: 12px;">*</span>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlSupplierName" runat="server" Width="275px" CssClass="" onchange="javascript:GetSupplierChange();">
                                    </asp:DropDownList>
                                    <asp:HiddenField ID="hdnSupplierId" Value="-1" runat="server" />
                                    <asp:HiddenField ID="hdnSupplierEmail" Value="" runat="server" />
                                </td>
                                <td style="text-align: right;">
                                    ETA Date<span style="color: red; font-size: 12px;">*</span>
                                </td>
                                <td style="border-right-color: #999;">
                                    <%--<asp:TextBox ID="txtETADate" onchange="ResetGrd()" Width="80px" onkeypress="return false;" CssClass="EtaDate do-not-allow-typing" runat="server"></asp:TextBox>--%>
                                    <asp:TextBox ID="txtETADate" style="Width:100px;color:black;font-weight:600;" onkeypress="return false;" CssClass="EtaDate do-not-allow-typing" runat="server"></asp:TextBox>
                                    <asp:HiddenField ID="hdnEtaDate" runat="server" />
                                    <asp:HiddenField ID="hdnETADateval" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <th colspan="10" style="border-top-color: #dbd8d8; text-align: left; border-right-color: #999; border-bottom: 0px">
                                    <span style="font-size: 12px; margin-top: -7px;color:Gray;">Client Code:</span> <span style="font-weight: bold">
                                        <asp:Label ID="lblClientCode" runat="server"></asp:Label>
                                    </span>
                                </th>
                            </tr>
                            <%--RajeevS 13022023 --%>
                             <tr>
                                <th colspan="10" style="border-top-color: #dbd8d8; text-align: left; border-right-color: #999; border-bottom: 0px">
                                    <span style="font-size: 12px; margin-top: -7px;color:Gray;" runat="server" id="spn_HSNCode"></span> <span style="font-weight: bold">
                                        <asp:Label ID="lblHSNCode" runat="server"></asp:Label>
                                    </span>
                                </th>
                            </tr>
                            <%--RajeevS--%>
                        </tbody>
                    </table>
                    <table border="0" cellpadding="0" cellspacing="0" class="AccessoryTable" style="width: 100%;">
                        <thead>
                            <tr>
                                <th class="ths" rowspan="2">
                                    Accessory Quality (Size) Color/Print
                                </th>
                                <th class="ths" rowspan="2">
                                    Shrinkage (%)
                                </th>
                                <th class="ths" rowspan="2">
                                    Wastage (%)
                                </th>
                                <th class="ths" rowspan="2">
                                    Accessory Type
                                </th>
                                <th class="ths" colspan="3">
                                    Quantity<span style="color: red; font-size: 12px;">*</span>
                                </th>
                                <th class="ths" colspan="2">
                                    Finance<span style="color: red; font-size: 12px;">*</span>
                                </th>
                            </tr>
                            <tr>
                                <th class="ths" style="width: 60px;">
                                    Send
                                </th>
                                <th class="ths" style="width: 80px;">
                                    Receivable
                                </th>
                                <th class="ths" style="width: 60px;">
                                    Unit
                                </th>
                                <th class="ths" style="width: 60px;">
                                    Rate
                                </th>
                                <th class="ths" style="width: 80px;">
                                    Total Amount
                                </th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td>
                                    <asp:Label ID="lblAccessoryQuality" ForeColor="blue" Font-Bold="true" Text="" runat="server"></asp:Label>
                                    <asp:HiddenField ID="hdnAccessoryQuality" runat="server" Value="" />
                                    <asp:Label ID="lblSize" ForeColor="Gray" Text="" runat="server"></asp:Label>
                                    <br />
                                    <asp:Label ID="lblcolorprint" Font-Bold="true" ForeColor="Black" Text="" runat="server"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblShrinkage" runat="server" Text=""></asp:Label>
                                    <asp:HiddenField ID="hdnShrinkage" Value="0" runat="server" />
                                </td>
                                <td>
                                    <asp:Label ID="lblWastage" runat="server" Text=""></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblAccessType" runat="server"></asp:Label>
                                </td>
                                <td>
                                    <div class="Accessorytooltip">
                                        <asp:TextBox ID="txtsentQty" CssClass="numeric-field-without-decimal-places" Style="text-align: center;font-weight:600;" onchange="ChangeSendQty(this)" runat="server"></asp:TextBox>
                                        <span id="AccessoryTooltipTxt" runat="server"></span>
                                    </div>
                                    <asp:HiddenField ID="hdnSendQty" runat="server" />
                                    <asp:HiddenField ID="hdnSendBase" runat="server" />
                                    <asp:HiddenField ID="hdnSend_CalBase" runat="server" />
                                    <asp:HiddenField ID="hdnCancel_SendQty" runat="server" />
                                </td>
                                <td>
                                    <%--<asp:TextBox ID="txtReceivedqty" CssClass="numeric-field-without-decimal-places" onkeypress="return validateFloatKeyPress(this,event);" onchange="ChangeRecievedQty()" Style="width: 73px !important; text-align: center;" runat="server"></asp:TextBox>--%>
                                    <asp:TextBox ID="txtReceivedqty" CssClass="numeric-field-without-decimal-places"  onchange="ChangeRecievedQty()" Style="width: 73px !important; text-align: center;font-weight:600;" runat="server"></asp:TextBox>
                                    <asp:HiddenField ID="hdnReceivedBase" runat="server" />
                                    <asp:HiddenField ID="hdnReceived_CalBase" runat="server" />
                                    <asp:HiddenField ID="hdnReceivedQty" runat="server" />
                                    <asp:HiddenField ID="hdnCancel_ReceivedQty" runat="server" />
                                </td>
                                <td style="width: 80px">
                                    <asp:DropDownList ID="ddlAccessUnit" onchange="OpenUnitPopup(this)" runat="server">
                                    </asp:DropDownList>
                                    <asp:HiddenField ID="hdnBaseAccessUnitVal" runat="server" />
                                    <asp:HiddenField ID="hdnAccessUnitVal" runat="server" />
                                    <asp:HiddenField ID="hdnAccessUnitName" runat="server" />
                                    <asp:HiddenField ID="hdnUnitChange" Value="0" runat="server" />
                                    <asp:HiddenField ID="hdnSrvCount" Value="0" runat="server" />
                                    <asp:HiddenField ID="hdnSrvQty" Value="0" runat="server" />
                                    <asp:HiddenField ID="hdnIsUnitDisabled" Value="0" runat="server" />
                                    <asp:HiddenField ID="hdnoldrate" runat="server" />
                                    <asp:HiddenField ID="hdnTotalAmount" runat="server" />
                                    <asp:HiddenField ID="hdnUserid" runat="server" Value="" />
                                </td>
                                <td>
                                 <span style='color: green; font-size: 16px; margin-right: 3px'>₹</span>
                                    <asp:TextBox ID="txtRate" Style="width: 35px;text-align: center;color: green;font-size: 13px!important;font-weight: 600;" CssClass="numeric-field-with-decimal-places" onchange="ChangeRate(this)" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <span id="AddIndianCurrency" runat="server"></span>
                                    <asp:Label ID="lblTotalAmount" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
                <div>
                    <div style="border: 1px solid #999; margin: 5px 0px; padding-left: 5px; width: 99%;">
                        <table cellpadding="0" cellspacing="0" width="100%">
                            <tr>
                                <td style="min-width: 330px; vertical-align: top;">
                                    <div class="clsDivHistory" style="display: none; margin-left: 10px;" id="dvHeader" runat="server">
                                    </div>
                                    <asp:GridView ID="grdHistoryQty" CssClass="table receivehis lastrow" runat="server" AutoGenerateColumns="false" Width="300px" OnRowDataBound="grdHistoryQty_RowDataBound" Style="margin-left: 10px; margin-right: 10px;">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Date" ItemStyle-Width="100px">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbldate" runat="server" Text='<%# (Convert.ToDateTime(Eval("PORevisedDate")) == Convert.ToDateTime("01-01-0001")) ? "" : Convert.ToDateTime(Eval("PORevisedDate")).ToString("dd MMM yy (ddd)")%>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle CssClass="txtcenter border_left_color" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Send Quantity" ItemStyle-Width="100px">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSendQty" runat="server" Font-Bold="true" Text=""></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle CssClass="txtcenter" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="PO Quantity" ItemStyle-Width="100px">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPoQuantity" runat="server" Font-Bold="true" Text=""></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle CssClass="txtcenter border_right_color" />
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </td>
                                <td style="width: 100%; vertical-align: top; text-align: right; padding-top: 10px;">
                                    <asp:Button ID="btnUpdateGrid" Style="display: none;" runat="server" Text="" OnClick="btnUpdateGrid_Click" />
                                    <asp:GridView ID="grdQtyRange" runat="server" AutoGenerateColumns="False" EmptyDataText="No Record Found!" HeaderStyle-Font-Names="Arial" HeaderStyle-HorizontalAlign="Center" ShowFooter="false" CssClass="table receivehis lastrow" Width="430px" ShowHeader="true" Style="border-top: 0px; border-bottom: 1px bolid #999; margin-left: 7px; float: right;" OnRowDeleting="grdQtyRange_RowDeleting" OnRowEditing="grdQtyRange_RowEditing" OnRowUpdating="grdQtyRange_RowUpdating" OnRowCancelingEdit="grdQtyRange_RowCancelingEdit" OnRowDataBound="grdQtyRange_RowDataBound">
                                        <RowStyle CssClass="gvQtyRangeRow" />
                                        <Columns>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblHdrFromQty" runat="server" Text=""></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblFromQty" Font-Bold="true" Text='<%# Eval("FromQty")%>' runat="server"></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtFromQty" Style="text-align: center; width: 80%;" ReadOnly="true" Text='<%# Eval("FromQty")%>' CssClass="do-not-allow-typing" runat="server" MaxLength="7"></asp:TextBox>
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblHdrToQty" runat="server" Text=""></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:HiddenField ID="hdnsupplierpoid" runat="server" Value='<%# Eval("SupplierPO_Id")%>' />
                                                    <asp:HiddenField ID="hdnSupplierPO_ETA_Id" runat="server" Value='<%# Eval("SupplierPO_ETA_Id")%>' />
                                                    <asp:HiddenField ID="hdnRowNumber" runat="server" Value='<%# Eval("RowNumber")%>' />
                                                    <asp:Label ID="lbltoqty" runat="server" Font-Bold="true" Text='<%# Eval("ToQty")%>'></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:HiddenField ID="hdnsupplierpoid" runat="server" Value='<%# Eval("SupplierPO_Id")%>' />
                                                    <asp:HiddenField ID="hdnSupplierPO_ETA_Id" runat="server" Value='<%# Eval("SupplierPO_ETA_Id")%>' />
                                                    <asp:HiddenField ID="hdnRowNumber" runat="server" Value='<%# Eval("RowNumber")%>' />
                                                    <asp:TextBox ID="txtToQty" Text='<%# Eval("ToQty")%>' CssClass="storedata" Style="text-align: center; width: 80%" runat="server" onkeypress="return isNumberKey(event)" MaxLength="7" onchange="CheckToQty(this)"></asp:TextBox>
                                                    <asp:HiddenField ID="hdnToQty" runat="server" Value='<%# Eval("ToQty")%>' />
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    ETA Dates
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lbldates" Text='<%# (Convert.ToDateTime(Eval("POETADate")) == Convert.ToDateTime("01-01-0001")) ? "" : Convert.ToDateTime(Eval("POETADate")).ToString("dd MMM yy (ddd)")%>' runat="server"></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtRangeEta" CssClass="EtaDate do-not-allow-typing" Text='<%# (Convert.ToDateTime(Eval("POETADate")) == Convert.ToDateTime("01-01-0001")) ? "" : Convert.ToDateTime(Eval("POETADate")).ToString("dd MMM yy (ddd)")%>' runat="server" Style="text-align: center; width: 80%" onchange="CheckEtaDates(this)"></asp:TextBox>
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    Action
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="LinkButton1" Text="../../images/edit2.png" alt="edit" CommandName="Edit" runat="server"><img src="../../images/edit2.png" alt="edit" /></asp:LinkButton>
                                                    <asp:LinkButton ID="lnkDelete" runat="server" CommandName="Delete" ForeColor="black" ToolTip="Delete" Width="20px"> <img src="../../images/del-butt.png" /> </asp:LinkButton>
                                                </ItemTemplate>
                                                <ItemStyle CssClass="Actiont_63 border_right_color" />
                                                <EditItemTemplate>
                                                    <asp:LinkButton ID="btnupdate" runat="server" OnClientClick="javascript:return ValidateQtyRange(this)" CommandName="Update" Text="Update"><img src="../../App_Themes/ikandi/images/green_tick.gif" /></asp:LinkButton>
                                                    <asp:LinkButton ID="btncancel" runat="server" CommandName="Cancel" Text="Cancel"><img src="../../images/Cancel1.jpg" style="position: relative;top:2px;width:17px" /></asp:LinkButton>
                                                </EditItemTemplate>
                                                <HeaderStyle Width="80px" />
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div>
              <div style="width:1100px;display:flex;align-items:center;margin:10px 0;">
                <label style="font-size: 11px;color: gray; margin-right: 5px;"> Remarks:</label>
                   <textarea id="txtAccessoryComment" runat="server" cols="5" row="4" style="width: 50%;border: 1px solid #cccccc;text-transform: Capitalize;font-size: 12px;height: 18px;font-family: Verdana, Sans-Serif , Aparajita; color: #666;"></textarea>
              </div>
                    <div id="divguidline" runat="server">
                    </div>
                    <div style="width: 100%;border: 1px solid darkgray;display: flex;margin: 10px 0;padding: 10px 0;">
                                 <div style="width: 33%;display: flex;text-align: center;flex-direction: column;align-items: center;">
                                 <b>Boutique International Pvt. Ltd.</b>
                                    <div class="AuthoriImage" id="divJuniorSignatorySig" runat="server" visible="false" style="display: flex;flex-direction: column;align-items: center;">
                                        <asp:Image ID="imgJuniorSignatory" runat="server" style="margin-bottom:8px;" />
                                        <asp:Label ID="lblJuniorName" runat="server"></asp:Label>
                                        <asp:Label ID="lblJuniorSignatorydate" CssClass="AuthorizedSignatorydate" runat="server"></asp:Label>
                                    </div>
                                    <div id="divJuniorSignatorySigchk" runat="server">
                                        <asp:CheckBox ID="chkJuniorSignatory" runat="server" Style="position: relative; top: 2px; margin-left: -5px;" />
                                        <span style="position: relative; right: 0%; display: inherit;" runat="server" id="spanJuniorSig">(Subordinate Signature)</span>
                                    </div>
                                </div>
                                <div style="width: 33%;display: flex;text-align: center;flex-direction: column;align-items: center;">
                                 <b>Boutique International Pvt. Ltd.</b>          
                                    <div class="AuthoriImage" id="divAuthorizedSig" runat="server" visible="false" style="display: flex;flex-direction: column;align-items: center;">
                                        <asp:Image ID="imgAuthorizedSignatory" class="disabledCheckboxes" runat="server" style="margin-bottom:6px;" />
                                        <asp:Label ID="lblAuthorizedName" runat="server"></asp:Label>
                                        <asp:Label ID="lblAuthorizedDate" runat="server"></asp:Label>
                                    </div>
                                    <div id="divAuthorizedSigchk" runat="server">
                                        <asp:CheckBox ID="chkAuthorizedSignatory" onclick="DisplaySendMail()" runat="server" Style="position: relative; top: 2px; margin-left: -5px;" />
                                        (Authorized Signature)
                                    </div>
                                </div>
                               <div style="width: 33%;display: flex;text-align: center;flex-direction: column;align-items: center;">
                                    <b>Accepted by</b>
                                    <div class="AuthoriImage" id="divPartySig" runat="server" visible="false" style="display: flex;flex-direction: column;align-items: center;">
                                        <asp:Image ID="imgpartysingature" runat="server" style="margin-bottom:6px;" />
                                        <asp:Label ID="lblPartyName" runat="server"></asp:Label>
                                        <asp:Label ID="lblPartyDate" runat="server"></asp:Label>
                                    </div>
                                    <div id="divPartySigchk" runat="server">
                                        <asp:CheckBox ID="chkpartysignature" onclick="DisplaySendMail()" runat="server" Style="position: relative; top: 2px;" />
                                        (Party Signature)
                                    </div>
                                </div>
                    </div>
                    <div style="display:flex;">
                    <asp:Button ID="btnSubmit" Style="" runat="server" Text="Submit" OnClientClick="javascript:return ValidateControls(); " CssClass="btnSubmit printHideButton" OnClick="btnSubmit_Click" />
                    <div class="btnClose printHideButton" onclick="javascript:self.parent.Shadowbox.close();"> Close </div>
                    <div class="btnPrint printHideButton" onclick="window.print();return false">Print</div>
                    <div id="dvSendMail" style="margin-top: 3px;" runat="server">
                        &nbsp; &nbsp; Is E-Mail Send:
                        <asp:RadioButton ID="rbtnYes" Text="Yes" GroupName="Mail" runat="server" />
                        <asp:RadioButton ID="rbtnNo" Text="No" GroupName="Mail" Checked="true" runat="server" />
                    </div>
                </div>
            </div>
            <div class="ModelPo" id="dvUnit" style="display: none">
                <div class="backcolorpo">
                    <div class="BodyContect">
                        <h2>
                            Convert Unit Ratio</h2>
                        <div style="width: 150px; display: initial">
                            <span style="margin-right: 5px;">From </span>
                            <asp:Label ID="lblPreviousUnit" ForeColor="Black" runat="server" Text=""></asp:Label>
                            <asp:TextBox ID="txtPreviousUnitVal" ReadOnly="true" Style="text-align: center;" Width="40px" runat="server" Text="1"></asp:TextBox>
                            <span style="margin-right: 5px;">To </span>
                            <asp:Label ID="lblCurrentUnit" runat="server" Text=""></asp:Label>
                            <asp:TextBox ID="txtUnitValue" Style="text-align: center;" onkeypress="return isNumberWithDecimal(event,this)" MaxLength="5" Width="40px" runat="server"></asp:TextBox>
                            <asp:HiddenField ID="hdnConversionVal" Value="0" runat="server" />
                        </div>
                        <div style="width: 100%">
                        </div>
                        <input id="btnUnit" type="button" class="btnOk" onclick="UnitSubmit()" value="Ok" />
                        <input id="btnUnitCancel" class="btnCancel" type="button" onclick="UnitCancel()" value="Cancel" />
                    </div>
                </div>
            </div>
            <div class="ModelPo2" id="divhistory" style="display: none">
                <table cellpadding="0" cellspacing="0" style="width: 100%;">
                    <tr>
                        <th style='background: #39589c !important; padding: 3px 5px; color: #fff !important; text-align: center'>
                            History<span style='float: right; cursor: pointer; color: #fff' onclick="showhistory()" titel='Close'>X</span>
                        </th>
                    </tr>
                    <tr>
                        <td style="width: 50%; text-align: left; padding: 0px 10px;">
                            <div id="Pohistory">
                            </div>
                            <%--  <asp:Label ID="lblh" style="text-align:left;line-height: 15px;color:#737272; font-size: 11px;" runat="server"></asp:Label>--%>
                        </td>
                    </tr>
                </table>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
