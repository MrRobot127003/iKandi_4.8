<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AccessoryDebitNote.aspx.cs" Inherits="iKandi.Web.Internal.Accessory.AccessoryDebitNote" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .FabricCreaditNote
        {
            max-width: 99.8%;
            margin: 0 auto;
            font-family: arial;
        }
        .top_heading
        {
            text-transform: capitalize;
            font-size: 16px;
            font-weight: 500;
            padding-top: 3px;
            text-align: center;
            padding-bottom: 2px;
            background: #39589c;
            color: #fff;
        }
        .address_head
        {
            font-weight: 500;
            font-size: 11px;
            line-height: 15px;
        }
        .border_right
        {
            border-right: 1px solid #999 !important;
        }
        .border_left
        {
            border-left: 1px solid #999 !important;
        }
        .headerbold
        {
            background: #e4e2e2;
            text-align: center;
            border-right: 1px solid #999999;
        }
        .gridtable td
        {
            border-bottom: 1px solid #dbd8d8;
        }
        .txtwdth
        {
            width: 71%;
        }
        .txtbillwidth
        {
            width: 45%;
        }
        input
        {
            font-size: 10px !important;
        }
        .txtdatewidth
        {
            width: 54%;
        }
        .inputfildwidth
        {
            width: 95% !important;
        }
        
        .grdviewtable th
        {
            background: #e4e2e2;
            text-align: center;
            font-weight: 500;
            font-size: 12px !important;
            color: #6b6464;
        }
        .grdviewtable td
        {
            text-align: center;
            font-size: 11px !important;
            border-color: #9999;
        }
        .grdviewtable td:nth-child(2)
        {
            text-align: left;
            padding-left: 2px;
            word-break: break-all;
        }
        .txtColorGray
        {
            color: Gray;
        }
        .emptytable th
        {
            background: #e4e2e2;
            text-align: center;
            border: 1px solid #9999;
            color: #6b6464;
        }
        .emptytable td
        {
            text-align: center;
        }
        .grdviewtable
        {
            min-width: 694px;
        }
        .grdviewtable th
        {
            border-top: 0px;
            border-color: #999;
            color: #6b6464;
        }
        .btnClose
        {
            margin-left: 10px;
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
        }
        .btnClose:hover
        {
            color: red;
        }
        .btnSubmit
        {
            margin-left: 10px;
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
        }
        .btnSubmit:hover
        {
            color: Yellow !important;
        }
        .btnPrint
        {
            margin-left: 10px;
            font-size: 12px !important;
            float: left;
            color: rgb(255, 255, 255);
            font-weight: bold;
            width: 52px;
            cursor: pointer;
            background: #39589c !important;
            height: 24px;
            line-height: 24px;
            border: none !important;
            border-radius: 2px;
        }
        .btnPrint:hover
        {
            color: Yellow !important;
        }
        /* .footerClass td
        {
            border-bottom-color: #999;
        }*/
        .footerClass td:first-child
        {
            border-left-color: #999;
        }
        .footerClass td:last-child
        {
            border-right-color: #999;
        }
        a
        {
            text-decoration: none;
        }
        .bottomtable td
        {
            font-size: 11px;
        }
        input[type='text']
        {
            font-size: 11px !important;
            padding-left: 2px;
            border-radius: 2px;
            font-family: arial;
            margin: 2px 0px;
        }
        .txtEditWidth
        {
            width: 88% !important;
            text-align: center;
        }
        .txtEditParticular
        {
            width: 97% !important;
            text-align: left !important;
            text-transform: inherit !important;
        }
        .TaskFabricTable
        {
            width: 800px !important;
            margin-top: 5px;
        }
        /*
       code added by bharat on 21-june
       Click Print button the hide botton
         
       */
        @media print
        {
            body
            {
                -webkit-print-color-adjust: exact;
            }
            .printHideButton
            {
                display: none;
            }
            .GST_TAble
            {
                min-width: 100% !important;
                max-width: 100% !important;
            }
            .FabricCreaditNote
            {
                max-width: 99.8% !important;
            }
            .PrientClass
            {
                width: 501px !important;
            }
            .PrientClass1
            {
                width: 84px !important;
                border-bottom: 1px solid #9999;
                border-right: 1px solid #999
            }
            .PrientClass2
            {
                width: 84px !important;
            }
            .PrientClass3
            {
                width: 67px !important;
            }
        
            .PrientClass4
            {
                width: 70px;
                border-bottom: 1px solid #9999;
            }
            .GST_TAble td input[type="text"]
            {
                width: 40px !important;
                text-align: center;
            }
            input[type='text']
            {
                margin: 2px 0px;
            }
        }
        
        .indianCurr::after
        {
            content: "₹";
            color: green;
        }
        input[type=text], textarea
        {
            border: 1px solid #cccccc;
            text-transform: capitalize;
            font-size: 11px;
        }
        
        .GSTTAble td input[type="text"]
        {
            margin: 2px 0px;
            font-size: 11px;
        }
        .GSTTAble td
        {
            border-right: 1px solid #9999;
            font-size: 11px;
            height: 20px;
        }
        .EmptyRow td[colspan="6"]
        {
            border: 0px;
        }
        .GSTTAbleEmp td input[type="text"]
        {
            margin: 2px 0px;
            font-size: 11px;
            text-align: center;
        }
        .GSTTAbleEmp td
        {
            border: 1px solid #c3bcbc99;
        }
        .GSTTAbleEmp th
        {
            border: 1px solid #9999;
        }
        .txtFooterWidth
        {
            width: 89% !important;
        }
        .txtLeft
        {
            text-align: left !important;
        }
        .footerClass td:first-child
        {
            border-bottom-color: #999 !important;
        }
        .footerClass td:nth-child(2)
        {
            border-bottom-color: #999 !important;
        }
        .GST_TAble td input[type="text"]
        {
            text-align: center;
        }
        th
        {
            color: #6b6464;
        }
        #sb-wrapper
        {
            width: 706px !important;
        }
    </style>
</head>
<body>
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
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/form.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/progress.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/jquery.validate.min.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/jquery-jtemplates.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/jquery.form.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/ui.core.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/jquery.jcarousel.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/jquery.autocomplete.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/jquery.fixedtableheader-1-0-2.min.js")%>'></script>
    <script src='<%= Page.ResolveUrl("~/js/jquery.easydrag.js")%>' type="text/javascript"></script>
    <script src='<%= Page.ResolveUrl("~/js/jquery.jqprint.0.3.js")%>' type="text/javascript"></script>
    <script src='<%= Page.ResolveUrl("~/js/jquery.MultiFile.pack.js")%>' type="text/javascript"></script>
    <script src='<%= Page.ResolveUrl("~/js/jquery.hoverIntent.min.js")%>' type="text/javascript"></script>
    <script src='<%= Page.ResolveUrl("~/js/jquery.tools.min.js")%>' type="text/javascript"></script>
    <script src='<%= Page.ResolveUrl("~/js/jquery.checkbox.min.js")%>' type="text/javascript"></script>
    <script src='<%= Page.ResolveUrl("~/js/fna.js")%>' type="text/javascript"></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/date.js")%>'></script>
    <script type="text/javascript" src="../../js/iKandi.js"></script>
    <script type="text/javascript">

        var txtIGSTClientID = '<%=txtIGST.ClientID %>';
        var txtCGSTClientID = '<%=txtCGST.ClientID %>';
        var txtSGSTClientID = '<%=txtSGST.ClientID %>';
        var lblIGSTAmountClientID = '<%=lblIGSTAmount.ClientID %>';
        var lblCGSTAmountClientID = '<%=lblCGSTAmount.ClientID %>';
        var lblSGSTAmountClientID = '<%=lblSGSTAmount.ClientID %>';

        var hdnIGSTAmountClientID = '<%=hdnIGSTAmount.ClientID %>';
        var hdnCGSTAmountClientID = '<%=hdnCGSTAmount.ClientID %>';
        var hdnSGSTAmountClientID = '<%=hdnSGSTAmount.ClientID %>';
        var lblGrandTotalAmountClientID = '<%=lblGrandTotalAmount.ClientID %>';
        var lblRupeesClientID = '<%=lblRupees.ClientID %>';
        var hdnTotalAmount = '<%=hdnTotalAmount.ClientID %>';
        var hdnSRVQuantity = '<%=hdnSRVQty.ClientID %>';
        var hdnGrandTotalAmountClientID = '<%=hdnGrandTotalAmount.ClientID %>';
        var hdnBillAmountClientID = '<%=hdnBillAmount.ClientID %>';
        var hdnRupees = '<%=hdnRupees.ClientID %>';

        $(document).ready(function () {
            //alert();
            //debugger;            
            var GSTNo = $("#hdnGST_No").val();
            if (GSTNo == "") {
                $('.clsIGST').css("display", "none");
                $('.clsCGST_SGST').css("display", "none");
            }
            else {
                if (GSTNo != "") {
                    var stateId = GSTNo.substr(0, 2);
                    //alert(stateId);

                    if (stateId == '09') {
                        $('.clsIGST').css("display", "none");
                        $('.clsCGST_SGST').css("display", "display");
                    }
                    else {
                        $('.clsIGST').css("display", "display");
                        $('.clsCGST_SGST').css("display", "none");
                    }
                }
            }
        })

        function HideShowGST() {
                    //   alert("Hello");
                    debugger;
            var GSTNo = $("#hdnGST_No").val();
            if (GSTNo == "" || GSTNo == "0") {
                $('.clsIGST').css("display", "none");
                $('.clsCGST_SGST').css("display", "none");
            }
            else {
                if (GSTNo != "") {
                    var stateId = GSTNo.substr(0, 2);

                    if (stateId == '09') {
                        $('.clsIGST').css("display", "none");
                        $('.clsCGST_SGST').css("display", "display");
                    }
                    else {
                        $('.clsIGST').css("display", "display");
                        $('.clsCGST_SGST').css("display", "none");
                    }
                }
            }
        }

        function CalculateGridAmount(obj, type, ValueType) {
            //debugger;
            var TotalAmount = 0;
            var TotalDebitQty = 0;

            var value = $(obj).val();
            //            if ((value == '') || (value == '0')) {
            //                $(obj).val('');
            //                return false;
            //            }

            var GridRow = $(".gvRow").length;

            if (ValueType == 'Qty') {

                var RowId = 0;
                var gvId = '';
                for (var row = 1; row <= GridRow; row++) {
                    RowId = parseInt(row) + 1;
                    if (RowId < 10)
                        gvId = 'ctl0' + RowId;
                    else
                        gvId = 'ctl' + RowId;

                    var DebitQty = $("#<%= grdAccessoryDebitNot.ClientID %> span[id*='" + gvId + "_lblDebitQty" + "']").text().replace(',', '');

                    if (DebitQty != undefined) {
                        TotalDebitQty = parseFloat(TotalDebitQty) + parseFloat(DebitQty);
                    }
                }
                TotalDebitQty = parseFloat(TotalDebitQty) + parseFloat(value);

                var SRVQuantity = $("#" + hdnSRVQuantity).val();

                if (parseFloat(TotalDebitQty) > parseFloat(SRVQuantity)) {
                    alert('Total Debit quantity can not be greater than SRV Quantity ' + SRVQuantity);
                    $(obj).val('');
                    return false;
                }
            }

            var TotalDebitQty = 0;
            var TotalDebitRate = 0;
            var IGSTAmount = 0;
            var CGSTAmount = 0;
            var SGSTAmount = 0;
            var GrandTotalAmount = 0;
            var FooterAmount = 0;

            if (type == 'Empty') {
                var gvId = "ctl01";
                var DebitQty = $("#<%= grdAccessoryDebitNot.ClientID %> input[id*='" + gvId + "_txtDebitQty_Empty" + "']").val().replace(',', '');
                var DebitRate = $("#<%= grdAccessoryDebitNot.ClientID %> input[id*='" + gvId + "_txtDebitRate_Empty" + "']").val().replace(',', '');

                if (DebitQty == '')
                    DebitQty = 0;

                if (DebitRate == '')
                    DebitRate = 0;

                TotalDebitQty = DebitQty;
                TotalDebitRate = DebitRate;

                TotalAmount = parseFloat(DebitQty) * parseFloat(DebitRate);
                $("#" + hdnTotalAmount).val(TotalAmount);

                if (parseFloat(TotalAmount) > 0) {
                    $("#<%= grdAccessoryDebitNot.ClientID %> span[id*='" + gvId + "_lblAmount_Empty" + "']").text(TotalAmount.toFixed(2));
                    $("#<%= grdAccessoryDebitNot.ClientID %> input[id*='" + gvId + "_hdnAmount_Empty" + "']").val(TotalAmount.toFixed(2));
                }
                else {
                    $("#<%= grdAccessoryDebitNot.ClientID %> span[id*='" + gvId + "_lblAmount_Empty" + "']").text('');
                    $("#<%= grdAccessoryDebitNot.ClientID %> input[id*='" + gvId + "_hdnAmount_Empty" + "']").val(TotalAmount);
                }
            }
            if (type == 'Edit') {
                var Ids = obj.id;
                var gvId = Ids.split("_")[1].substr(3);

                var hdnDebitQty = $("#<%= grdAccessoryDebitNot.ClientID %> input[id*='" + gvId + "_hdnDebitQty" + "']").val();
                var hdnDebitRate = $("#<%= grdAccessoryDebitNot.ClientID %> input[id*='" + gvId + "_hdnDebitRate" + "']").val();

                var DebitQty = $("#<%= grdAccessoryDebitNot.ClientID %> input[id*='" + gvId + "_txtDebitQty" + "']").val().replace(',', '');
                var DebitRate = $("#<%= grdAccessoryDebitNot.ClientID %> input[id*='" + gvId + "_txtDebitRate" + "']").val().replace(',', '');

                if (DebitQty == '')
                    DebitQty = 0;

                if (DebitRate == '')
                    DebitRate = 0;

                TotalDebitQty = DebitQty;
                TotalDebitRate = DebitRate;

                var EditAmount = parseFloat(DebitQty) * parseFloat(DebitRate);
                if (parseFloat(EditAmount) > 0) {
                    $("#<%= grdAccessoryDebitNot.ClientID %> span[id*='" + gvId + "_lblAmountEdit" + "']").text(EditAmount.toFixed(2));
                    $("#<%= grdAccessoryDebitNot.ClientID %> input[id*='" + gvId + "_hdnAmountEdit" + "']").val(EditAmount.toFixed(2));
                }
                else {
                    $("#<%= grdAccessoryDebitNot.ClientID %> span[id*='" + gvId + "_lblAmountEdit" + "']").text('');
                    $("#<%= grdAccessoryDebitNot.ClientID %> input[id*='" + gvId + "_hdnAmountEdit" + "']").val(EditAmount);
                }

                var RowId = 0;
                gvId = '';
                for (var row = 1; row <= GridRow; row++) {
                    RowId = parseInt(row) + 1;
                    if (RowId < 10)
                        gvId = 'ctl0' + RowId;
                    else
                        gvId = 'ctl' + RowId;

                    var Amount = $("#<%= grdAccessoryDebitNot.ClientID %> input[id*='" + gvId + "_hdnAmount" + "']").val();
                    TotalAmount = parseFloat(TotalAmount) + parseFloat(Amount);
                }

                $("#" + hdnTotalAmount).val(TotalAmount);
            }
            if (type == 'Footer') {
                var RowId = parseInt(GridRow) + 2;
                var gvId;
                if (RowId < 10)
                    gvId = 'ctl0' + RowId;
                else
                    gvId = 'ctl' + RowId;

                var DebitQty = $("#<%= grdAccessoryDebitNot.ClientID %> input[id*='" + gvId + "_txtDebitQty_Footer" + "']").val().replace(',', '');
                var DebitRate = $("#<%= grdAccessoryDebitNot.ClientID %> input[id*='" + gvId + "_txtDebitRate_Footer" + "']").val().replace(',', '');

                if (DebitQty == '')
                    DebitQty = 0;

                if (DebitRate == '')
                    DebitRate = 0;

                TotalDebitQty = DebitQty;
                TotalDebitRate = DebitRate;

                FooterAmount = parseFloat(DebitQty) * parseFloat(DebitRate);
                TotalAmount = $("#" + hdnTotalAmount).val();
                TotalAmount = parseFloat(TotalAmount) + parseFloat(FooterAmount);
                $("#" + hdnTotalAmount).val(TotalAmount);

                if (parseFloat(FooterAmount) > 0) {
                    $("#<%= grdAccessoryDebitNot.ClientID %> span[id*='" + gvId + "_lblAmount_Footer" + "']").text(FooterAmount.toFixed(2));
                    $("#<%= grdAccessoryDebitNot.ClientID %> input[id*='" + gvId + "_hdnAmount_Footer" + "']").val(FooterAmount.toFixed(2));
                }
                else {
                    $("#<%= grdAccessoryDebitNot.ClientID %> span[id*='" + gvId + "_lblAmount_Footer" + "']").text('');
                    $("#<%= grdAccessoryDebitNot.ClientID %> input[id*='" + gvId + "_hdnAmount_Footer" + "']").val(FooterAmount);
                }

            }

            var GSTRate = $("#" + txtIGSTClientID).val();
            var GSTRate = $("#" + txtIGSTClientID).val();
            if ((GSTRate == '') || (GSTRate == '0')) {
                $("#" + hdnIGSTAmountClientID).val(0);
                $("#" + lblIGSTAmountClientID).text('');
            }
            else {
                var Amount = (parseFloat(GSTRate) * parseFloat(TotalAmount)) / 100;
                $("#" + hdnIGSTAmountClientID).val(Amount.toFixed(2));
                $("#" + lblIGSTAmountClientID).text(Amount.toFixed(2));
            }

            var CGSTRate = $("#" + txtCGSTClientID).val();
            if ((CGSTRate == '') || (CGSTRate == '0')) {
                $("#" + hdnCGSTAmountClientID).val(0);
                $("#" + lblCGSTAmountClientID).text('');
            }
            else {
                var Amount = (parseFloat(CGSTRate) * parseFloat(TotalAmount)) / 100;
                $("#" + hdnCGSTAmountClientID).val(Amount.toFixed(2));
                $("#" + lblCGSTAmountClientID).text(Amount.toFixed(2));
            }

            var SGSTRate = $("#" + txtSGSTClientID).val();
            var Amount = (parseFloat(SGSTRate) * parseFloat(TotalAmount)) / 100;

            if ((SGSTRate == '') || (SGSTRate == '0')) {
                $("#" + hdnSGSTAmountClientID).val(0);
                $("#" + lblSGSTAmountClientID).text('');
            }
            else {
                var Amount = (parseFloat(SGSTRate) * parseFloat(TotalAmount)) / 100;
                $("#" + hdnSGSTAmountClientID).val(Amount.toFixed(2));
                $("#" + lblSGSTAmountClientID).text(Amount.toFixed(2));
            }

            IGSTAmount = $("#" + hdnIGSTAmountClientID).val();
            if (IGSTAmount == null)
                IGSTAmount = 0;

            CGSTAmount = $("#" + hdnCGSTAmountClientID).val();
            if (CGSTAmount == null)
                CGSTAmount = 0;

            SGSTAmount = $("#" + hdnSGSTAmountClientID).val();
            if (SGSTAmount == null)
                SGSTAmount = 0;
            //debugger;
            GrandTotalAmount = parseFloat(TotalAmount) + parseFloat(IGSTAmount) + parseFloat(CGSTAmount) + parseFloat(SGSTAmount);

            var BillAmount = $("#" + hdnBillAmountClientID).val();
            if (BillAmount != "") {
                if (parseFloat(GrandTotalAmount) > parseFloat(BillAmount)) {
                    //debugger;
                    alert("Total Amount (" + parseFloat(GrandTotalAmount).toFixed(2) + ") can not be greater than bill Amount (" + BillAmount + ") \n Please Manage either Bill Amount or Particular");
                    $(obj).val('0');
                    if (type == 'Footer') {
                        var NewAmount = parseFloat(TotalAmount) - parseFloat(FooterAmount)
                        $("#" + hdnTotalAmount).val(NewAmount);
                    }
                    else if (type == 'Edit') {
                        $("#<%= grdAccessoryDebitNot.ClientID %> input[id*='" + gvId + "_txtDebitQty" + "']").val(hdnDebitQty);
                        $("#<%= grdAccessoryDebitNot.ClientID %> input[id*='" + gvId + "_txtDebitRate" + "']").val(hdnDebitRate);
                    }
                    CalculateGridAmount(obj, type, ValueType);
                    return false;
                }
                else {
                    //debugger;
                    $("#" + hdnGrandTotalAmountClientID).val(GrandTotalAmount.toFixed(2));
                    if (parseFloat(GrandTotalAmount) > 0) {
                        $("#" + lblGrandTotalAmountClientID).text(GrandTotalAmount.toFixed(2));
                        convertNumberToWords(GrandTotalAmount.toFixed(2));
                    }
                }
            }
        }

        function CalculateGSTAmount(obj, type) {
            //debugger;
            var TotalAmount = 0;
            var Amount = 0;
            TotalAmount = $("#" + hdnTotalAmount).val();
            if (parseFloat(TotalAmount) > 0) {

                if (type == 1) {
                    var GSTRate = $("#" + txtIGSTClientID).val();
                    if ((GSTRate == '') || (GSTRate == '0')) {
                        $("#" + hdnIGSTAmountClientID).val(0);
                        $("#" + lblIGSTAmountClientID).text('');
                        $("#" + txtIGSTClientID).val('');
                    }
                    else {
                        Amount = (parseFloat(GSTRate) * parseFloat(TotalAmount)) / 100;
                        $("#" + hdnIGSTAmountClientID).val(Amount.toFixed(2));
                        $("#" + lblIGSTAmountClientID).text(Amount.toFixed(2));
                    }
                }

                if (type == 2) {
                    var GSTRate = $("#" + txtCGSTClientID).val();
                    if ((GSTRate == '') || (GSTRate == '0')) {
                        $("#" + hdnCGSTAmountClientID).val(0);
                        $("#" + lblCGSTAmountClientID).text('');
                        $("#" + txtCGSTClientID).val('');
                    }
                    else {
                        Amount = (parseFloat(GSTRate) * parseFloat(TotalAmount)) / 100;
                        $("#" + hdnCGSTAmountClientID).val(Amount.toFixed(2));
                        $("#" + lblCGSTAmountClientID).text(Amount.toFixed(2));
                    }
                }

                if (type == 3) {
                    var GSTRate = $("#" + txtSGSTClientID).val();

                    if ((GSTRate == '') || (GSTRate == '0')) {
                        $("#" + hdnSGSTAmountClientID).val(0);
                        $("#" + lblSGSTAmountClientID).text('');
                        $("#" + txtSGSTClientID).val('');
                    }
                    else {
                        Amount = (parseFloat(GSTRate) * parseFloat(TotalAmount)) / 100;
                        $("#" + hdnSGSTAmountClientID).val(Amount.toFixed(2));
                        $("#" + lblSGSTAmountClientID).text(Amount.toFixed(2));
                    }
                }
                var IGSTAmount = 0;
                var CGSTAmount = 0;
                var SGSTAmount = 0;

                IGSTAmount = $("#" + hdnIGSTAmountClientID).val();
                if (IGSTAmount == null)
                    IGSTAmount = 0;

                CGSTAmount = $("#" + hdnCGSTAmountClientID).val();
                if (CGSTAmount == null)
                    CGSTAmount = 0;

                SGSTAmount = $("#" + hdnSGSTAmountClientID).val();
                if (SGSTAmount == null)
                    SGSTAmount = 0;

                var GrandTotalAmount = parseFloat(TotalAmount) + parseFloat(IGSTAmount) + parseFloat(CGSTAmount) + parseFloat(SGSTAmount);

                var BillAmount = $("#" + hdnBillAmountClientID).val();

                if (BillAmount != "") {
                    if (parseFloat(GrandTotalAmount) > parseFloat(BillAmount)) {
                        //debugger;
                        alert("Total Amount (" + GrandTotalAmount.toFixed(2) + ") can not be greater than bill Amount (" + BillAmount + ") \n Please Manage either Bill Amount or Particular");
                        $(obj).val('0');
                        CalculateGSTAmount(obj, type)
                        return false;
                    }
                    else {
                        //debugger;                    
                        $("#" + hdnGrandTotalAmountClientID).val(GrandTotalAmount.toFixed(2));
                        if (parseFloat(GrandTotalAmount) > 0) {
                            $("#" + lblGrandTotalAmountClientID).text(GrandTotalAmount.toFixed(2));
                            convertNumberToWords(GrandTotalAmount.toFixed(2));
                        }

                    }
                }

            }
        }

        function ValidateGrid(obj, type) {
            //debugger;
            var DebitParticular = '';
            var DebitQty = '';
            var DebitRate = '';
            if (type == 'Empty') {
                var gvId = "ctl01";
                var DebitParticular = $("#<%= grdAccessoryDebitNot.ClientID %> input[id*='" + gvId + "_txtDebitParticular_Empty" + "']").val();
                var DebitQty = $("#<%= grdAccessoryDebitNot.ClientID %> input[id*='" + gvId + "_txtDebitQty_Empty" + "']").val();
                var DebitRate = $("#<%= grdAccessoryDebitNot.ClientID %> input[id*='" + gvId + "_txtDebitRate_Empty" + "']").val();
            }
            if (type == 'Edit') {
                var Ids = obj.id;
                var gvId = Ids.split("_")[1].substr(3);

                var DebitParticular = $("#<%= grdAccessoryDebitNot.ClientID %> input[id*='" + gvId + "_txtDebitParticular" + "']").val();
                var DebitQty = $("#<%= grdAccessoryDebitNot.ClientID %> input[id*='" + gvId + "_txtDebitQty" + "']").val();
                var DebitRate = $("#<%= grdAccessoryDebitNot.ClientID %> input[id*='" + gvId + "_txtDebitRate" + "']").val();
            }
            if (type == 'Footer') {
                var GridRow = $(".gvRow").length;
                var RowId = parseInt(GridRow) + 2;
                var gvId;
                if (RowId < 10)
                    gvId = 'ctl0' + RowId;
                else
                    gvId = 'ctl' + RowId;

                var DebitParticular = $("#<%= grdAccessoryDebitNot.ClientID %> input[id*='" + gvId + "_txtDebitParticur_Footer" + "']").val();
                var DebitQty = $("#<%= grdAccessoryDebitNot.ClientID %> input[id*='" + gvId + "_txtDebitQty_Footer" + "']").val();
                var DebitRate = $("#<%= grdAccessoryDebitNot.ClientID %> input[id*='" + gvId + "_txtDebitRate_Footer" + "']").val();
            }

            if (DebitQty == '')
                DebitQty = '0';

            if (DebitRate == '')
                DebitRate = '0';

            if (DebitParticular == '') {
                alert('Debit Particular can not be Empty');
                return false;
            }
            if (DebitQty == '0') {
                alert('Debit Quantity can not be Empty or zero');
                return false;
            }
            if (DebitRate == '0') {
                alert('Debit Rate can not be Empty or zero');
                return false;
            }
        }

        function ChangeBillNumber() {
            //debugger;
            var BillDetails = $("#ddlBillNo option:selected").text();
            var BillPart1 = BillDetails.split("(");
            var BillPart2 = BillPart1[1].split(")");
            var sAmount = BillPart2[0].trim();
            $("#" + hdnBillAmountClientID).val(sAmount);

            $("#btnRefresh").click();
        }

        function closePage() {
            if ($("#hdnMailSentStatus").val() == "0") {
                alert('Saved Successfully!');
            }
            self.parent.parent.PageReload();
            self.parent.Shadowbox.close()
        }

        function Debitnote_Validation() {
            //debugger;

            var GridRow = $(".gvRow").length;

            if (parseInt(GridRow) == 0) {
                var gvId = "ctl01";
                var DebitQty = $("#<%= grdAccessoryDebitNot.ClientID %> input[id*='" + gvId + "_txtDebitQty_Empty" + "']").val();
                var DebitRate = $("#<%= grdAccessoryDebitNot.ClientID %> input[id*='" + gvId + "_txtDebitRate_Empty" + "']").val();

                if (DebitQty == '')
                    DebitQty = 0;

                if (DebitRate == '')
                    DebitRate = 0;

                if ((DebitQty == 0) || (DebitRate == 0)) {
                    alert('Debit Quantity or Rate can not be Empty or zero');
                    return false;
                }
            }
            else {
                var RowId = 0;
                var gvId = '';
                for (var row = 1; row <= GridRow; row++) {
                    RowId = parseInt(row) + 1;
                    if (RowId < 10)
                        gvId = 'ctl0' + RowId;
                    else
                        gvId = 'ctl' + RowId;

                    var DebitQty = $("#<%= grdAccessoryDebitNot.ClientID %> input[id*='" + gvId + "_txtDebitQty" + "']").val();
                    var DebitRate = $("#<%= grdAccessoryDebitNot.ClientID %> input[id*='" + gvId + "_txtDebitRate" + "']").val();
                    if (DebitQty != undefined) {
                        if (DebitQty == '')
                            DebitQty = 0;

                        if (DebitRate == '')
                            DebitRate = 0;

                        if ((DebitQty == 0) || (DebitRate == 0)) {
                            alert('Debit Quantity or Rate can not be Empty or zero');
                            return false;
                        }
                    }
                }
            }
            //debugger;
            var GrandTotal = $("#" + hdnGrandTotalAmountClientID).val();
            var BillAmount = $("#" + hdnBillAmountClientID).val();

            if (parseFloat(GrandTotal) > parseFloat(BillAmount)) {
                //debugger;
                alert("Total Amount (" + parseFloat(GrandTotal).toFixed(2) + ") can not be greater than bill Amount (" + BillAmount + ") \n Please Manage either Bill Amount or Particular");
                return false;
            }

        }

        //Convert number to Words
        function convertNumberToWords(amount) {
            //alert(amount);
            //debugger;
            var words = new Array();
            words[0] = '';
            words[1] = 'One';
            words[2] = 'Two';
            words[3] = 'Three';
            words[4] = 'Four';
            words[5] = 'Five';
            words[6] = 'Six';
            words[7] = 'Seven';
            words[8] = 'Eight';
            words[9] = 'Nine';
            words[10] = 'Ten';
            words[11] = 'Eleven';
            words[12] = 'Twelve';
            words[13] = 'Thirteen';
            words[14] = 'Fourteen';
            words[15] = 'Fifteen';
            words[16] = 'Sixteen';
            words[17] = 'Seventeen';
            words[18] = 'Eighteen';
            words[19] = 'Nineteen';
            words[20] = 'Twenty';
            words[30] = 'Thirty';
            words[40] = 'Forty';
            words[50] = 'Fifty';
            words[60] = 'Sixty';
            words[70] = 'Seventy';
            words[80] = 'Eighty';
            words[90] = 'Ninety';
            amount = amount.toString();
            var atemp = amount.split(".");
            var number = atemp[0].split(",").join("");
            var DecimalVal = 0;
            var DecimalChar = '';
            if (atemp.length > 1) {
                DecimalVal = parseInt(atemp[1]);
                DecimalChar = DecimalPlaceString(DecimalVal);
            }

            var n_length = number.length;
            var words_string = "";
            if (n_length <= 9) {
                var n_array = new Array(0, 0, 0, 0, 0, 0, 0, 0, 0);
                var received_n_array = new Array();
                for (var i = 0; i < n_length; i++) {
                    received_n_array[i] = number.substr(i, 1);
                }
                for (var i = 9 - n_length, j = 0; i < 9; i++, j++) {
                    n_array[i] = received_n_array[j];
                }
                for (var i = 0, j = 1; i < 9; i++, j++) {
                    if (i == 0 || i == 2 || i == 4 || i == 7) {
                        if (n_array[i] == 1) {
                            n_array[j] = 10 + parseInt(n_array[j]);
                            n_array[i] = 0;
                        }
                    }
                }
                value = "";
                for (var i = 0; i < 9; i++) {
                    if (i == 0 || i == 2 || i == 4 || i == 7) {
                        value = n_array[i] * 10;
                    } else {
                        value = n_array[i];
                    }
                    if (value != 0) {
                        words_string += words[value] + " ";
                    }
                    if ((i == 1 && value != 0) || (i == 0 && value != 0 && n_array[i + 1] == 0)) {
                        words_string += "Crores ";
                    }
                    if ((i == 3 && value != 0) || (i == 2 && value != 0 && n_array[i + 1] == 0)) {
                        words_string += "Lakhs ";
                    }
                    if ((i == 5 && value != 0) || (i == 4 && value != 0 && n_array[i + 1] == 0)) {
                        words_string += "Thousand ";
                    }
                    if (i == 6 && value != 0 && (n_array[i + 1] != 0 && n_array[i + 2] != 0)) {
                        words_string += "Hundred ";
                    } else if (i == 6 && value != 0) {
                        words_string += "Hundred ";
                    }
                }
                words_string = words_string.split("  ").join(" ");
            }
            //return words_string;
            if (DecimalChar != '') {
                words_string = words_string + 'and ' + DecimalChar + ' paise';
            }
            $("#" + lblRupeesClientID).text(words_string);
            $("#" + hdnRupees).val(words_string);

            //new line
            if ($("#" + lblRupeesClientID).text() != "") {
                $("#chkAuthorised").attr("disabled", false);
            }

        }

        function DecimalPlaceString(number) {
            var words = new Array();
            words[0] = '';
            words[1] = 'One';
            words[2] = 'Two';
            words[3] = 'Three';
            words[4] = 'Four';
            words[5] = 'Five';
            words[6] = 'Six';
            words[7] = 'Seven';
            words[8] = 'Eight';
            words[9] = 'Nine';
            words[10] = 'Ten';
            words[11] = 'Eleven';
            words[12] = 'Twelve';
            words[13] = 'Thirteen';
            words[14] = 'Fourteen';
            words[15] = 'Fifteen';
            words[16] = 'Sixteen';
            words[17] = 'Seventeen';
            words[18] = 'Eighteen';
            words[19] = 'Nineteen';
            words[20] = 'Twenty';
            words[21] = 'Twenty One';
            words[22] = 'Twenty Two';
            words[23] = 'Twenty Three';
            words[24] = 'Twenty Four';
            words[25] = 'Twenty Five';
            words[26] = 'Twenty Six';
            words[27] = 'Twenty Seven';
            words[28] = 'Twenty Eight';
            words[29] = 'Twenty Nine';
            words[30] = 'Thirty';
            words[31] = 'Thirty One';
            words[32] = 'Thirty Two';
            words[33] = 'Thirty Three';
            words[34] = 'Thirty Four';
            words[35] = 'Thirty Five';
            words[36] = 'Thirty Six';
            words[37] = 'Thirty Seven';
            words[38] = 'Thirty Eight';
            words[39] = 'Thirty Nine';
            words[40] = 'Forty';
            words[41] = 'Forty One';
            words[42] = 'Forty Two';
            words[43] = 'Forty Three';
            words[44] = 'Forty Four';
            words[45] = 'Forty Five';
            words[46] = 'Forty Six';
            words[47] = 'Forty Seven';
            words[48] = 'Forty Eight';
            words[49] = 'Forty Nine';
            words[50] = 'Fifty';
            words[51] = 'Fifty One';
            words[52] = 'Fifty Two';
            words[53] = 'Fifty Three';
            words[54] = 'Fifty Four';
            words[55] = 'Fifty Five';
            words[56] = 'Fifty Six';
            words[57] = 'Fifty Seven';
            words[58] = 'Fifty Eight';
            words[59] = 'Fifty Nine';
            words[60] = 'Sixty';
            words[61] = 'Sixty One';
            words[62] = 'Sixty Two';
            words[63] = 'Sixty Three';
            words[64] = 'Sixty Four';
            words[65] = 'Sixty Five';
            words[66] = 'Sixty Six';
            words[67] = 'Sixty Seven';
            words[68] = 'Sixty Eight';
            words[69] = 'Sixty Nine';
            words[70] = 'Seventy';
            words[71] = 'Seventy One';
            words[72] = 'Seventy Two';
            words[73] = 'Seventy Three';
            words[74] = 'Seventy Four';
            words[75] = 'Seventy Five';
            words[76] = 'Seventy Six';
            words[77] = 'Seventy Seven';
            words[78] = 'Seventy Eight';
            words[79] = 'Seventy Nine';
            words[80] = 'Eighty';
            words[81] = 'Eighty One';
            words[82] = 'Eighty Two';
            words[83] = 'Eighty Three';
            words[84] = 'Eighty Four';
            words[85] = 'Eighty Five';
            words[86] = 'Eighty Six';
            words[87] = 'Eighty Seven';
            words[88] = 'Eighty Eight';
            words[89] = 'Eighty Nine';
            words[90] = 'Ninety';
            words[91] = 'Ninety One';
            words[92] = 'Ninety Two';
            words[93] = 'Ninety Three';
            words[94] = 'Ninety Four';
            words[95] = 'Ninety Five';
            words[96] = 'Ninety Six';
            words[97] = 'Ninety Seven';
            words[98] = 'Ninety Eight';
            words[99] = 'Ninety Nine';
            words[100] = 'Hundred';
            return words[number];
        }

        function PrintThisPage() {
            $("#lblFailQty").css("display", "none");
            window.print();
            $("#lblFailQty").css("display", "block");
            return false;
        }

        function disablePage() {
            for (var i = 0; i < document.forms[0].elements.length; i++) {
                //document.forms[0].elements[i].disabled = true;
                $('input[type=text]').attr('readonly', 'readonly');
                $('textarea').attr('disabled', 'disabled');
                $('input[type=checkbox]').attr('disabled', 'disabled');
            }
            var GridRow = $(".gvRow").length;
            var RowId = 0;
            gvId = '';
            for (var row = 1; row <= GridRow; row++) {
                RowId = parseInt(row) + 1;
                if (RowId < 10)
                    gvId = 'ctl0' + RowId;
                else
                    gvId = 'ctl' + RowId;

                $("#<%= grdAccessoryDebitNot.ClientID %> a[id*='" + gvId + "_lkEdit" + "']").hide();
                $("#<%= grdAccessoryDebitNot.ClientID %> a[id*='" + gvId + "_lnkDelete" + "']").hide();

            }
        }

        function DisplaySendMail() {
            //debugger;
            if ($("#chkAuthorised").is(':checked')) {
                $("#dvSendMail").css("display", "")
                return false;
            }
            else {
                $("#dvSendMail").css("display", "none")
                return false;
            }

        }
        

    </script>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="sm" runat="server" EnablePartialRendering="true">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="Updatepanel1" runat="server">
        <ContentTemplate>
            <asp:UpdateProgress runat="server" ID="uproTargetAdmin" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="0">
                <ProgressTemplate>
                    <img src="../../App_Themes/ikandi/images1/loading36.gif" alt="" style="position: fixed; z-index: 52111; top: 40%; left: 45%; width: 8%;" />
                </ProgressTemplate>
            </asp:UpdateProgress>
            <div class="FabricCreaditNote">
                <asp:HiddenField ID="hdnrowcount" runat="server" />
                <asp:HiddenField ID="hdnDebitnotid" runat="server" />
                <asp:HiddenField ID="hdnGST_No" runat="server" Value="0" />
                <asp:HiddenField ID="hdnPO_Number" Value="0" runat="server" />
                <asp:HiddenField ID="hdnBill_Number" Value="0" runat="server" />
                <asp:HiddenField ID="hdnMailSentStatus" Value="0" runat="server" />
                <%--new line--%>
                <table style="max-width: 100%; width: 100%; border: 1px solid #999999; border-bottom: 0px solid #999999" cellspacing="0" cellpadding="0">
                    <thead>
                        <tr>
                            <td colspan="3" class="top_heading">
                                Accessory Debit Note
                            </td>
                        </tr>
                        <tr>
                            <td style="vertical-align: top; width: 125px; border-right: 0px;">
                                <div style="padding: 9px 7px">
                                    <img id="ctl00_boutiquelogo" src="../../images/200x50 bipllog.png" />
                                </div>
                            </td>
                            <td style="text-align: left; border-left: 0px;border-right: 1px solid lightgray;">
                                <div id="divbipladdress" runat="server">
                                </div>
                            </td>
                            <td style="font-size: 11px;padding-left: 5px;">
                                <table border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td class="txtColorGray">
                                            Debit Number: &nbsp;
                                        </td>
                                        <td>
                                            <asp:Label ID="lblDebitNo" Style="font-size: 11px; font-weight: bold;" runat="server" Text=""></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </thead>
                </table>
                <table class="gridtable" style="max-width: 100%; width: 100%; border: 1px solid #999999; border-bottom: 0px solid #999999; border-top-color: #dbd8d8;" cellspacing="0" cellpadding="0">
                    <tr>
                        <td colspan="2" style="width:50%;font-size: 12px; padding: 5px; border-top-color: #dbd8d8;border-right:1px solid #dbd8d8;">
                          <span style="padding-bottom: 10px; color: gray;width:75px;display:inline-block;">M/S:</span>
                            <asp:Label ID="lblSupllierName" Text="" runat="server"></asp:Label><br />
                          <span style="padding-bottom: 10px; color: gray;width:75px;display:inline-block;">GST No:</span>
                            <asp:Label ID="lblSupplierGstNo" Text="" runat="server"></asp:Label><br />
                           <span style="padding-bottom: 10px; color: gray;width:75px;display:inline-block;float:left;">Address:</span>
                            <asp:Label ID="lblSupplierAddress" Text="" runat="server"></asp:Label>
                        </td>
                        <td colspan="2" style="width:50%;font-size: 11px; padding-left: 5px; border-top-color: #dbd8d8;line-height:20px;">
                         <%--rajeevs --%>
                     
                         <span class="txtColorGray" style="width:80px;display:inline-block;" runat="server" id="spn_HSNCode"></span>
                             <asp:Label ID="lblHSNCode" runat="server" CssClass="th style-eta date_style" ReadOnly="true" style="max-width: 200px;width: 100px;padding: 3px;" ></asp:Label> 
                            <br>
                            <%--rajeevS--%><span class="txtColorGray" 
                                style="width:80px;display:inline-block;">Date:</span>
                            <asp:TextBox ID="txtDate" runat="server" CssClass="th style-eta date_style" 
                                onkeypress="return false;" ReadOnly="true" 
                                style="max-width: 200px;width: 100px;padding: 3px;" Text=""></asp:TextBox>
                            <br />
                            <span class="txtColorGray" style="width:80px;display:inline-block;">Against Bill 
                            No.</span>
                            <asp:DropDownList ID="ddlBillNo" runat="server" CssClass="txt" 
                                onchange="ChangeBillNumber()" style="border-color: lightgray;max-width:250px;">
                            </asp:DropDownList>
                            <asp:HiddenField ID="hdnBillAmount" runat="server" Value="0" />
                            <asp:HiddenField ID="hdnSRVQty" runat="server" Value="0" />
                            <asp:HiddenField ID="hdnGarmentUnitName" runat="server" Value="" />
                            <br>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="width:50%;padding: 5px;border-bottom: 0!important;border-right:1px solid #dbd8d8;">
                         <span class="txtColorGray" style="width:105px;display:inline-block;">AccQualityName:</span>
                             <asp:Label ID="lblAccQualityName" runat="server"></asp:Label>
                        </td>

                         <td style="border-bottom: 0!important;padding-left: 10px;">
                           <span class="txtColorGray" style="width:75px;display:inline-block;">Color-Print:</span>
                           <asp:Label ID="lblColor_Print" runat="server"></asp:Label>
                      </td>
                    </tr>
                   
<%--                    <tr>
                        <td colspan="2" style="font-size: 11px;text-align: right; padding-right: 10px;">
                            <asp:Label ID="lblFailQty" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>--%>
                </table>
                <div>
                    <asp:GridView ID="grdAccessoryDebitNot" runat="server" CssClass="grdviewtable" AutoGenerateColumns="false" OnRowDataBound="grdAccessoryDebitNot_RowDataBound" OnRowCommand="grdAccessoryDebitNot_RowCommand" OnRowDeleting="grdAccessoryDebitNot_RowDeleting" ShowFooter="true" OnRowEditing="grdAccessoryDebitNot_RowEditing" OnRowUpdating="grdAccessoryDebitNot_RowUpdating" OnRowCancelingEdit="grdAccessoryDebitNot_RowCancelingEdit">
                        <RowStyle CssClass="gvRow" />
                        <FooterStyle CssClass="footerClass" />
                        <EmptyDataRowStyle CssClass="EmptyRow" />
                        <Columns>
                            <asp:TemplateField HeaderText="Sr. No.">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex + 1 %>
                                    <asp:HiddenField ID="hdnId" Value='<%# Container.DataItemIndex + 1 %>' runat="server" />
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <%# Container.DataItemIndex + 1 %>
                                    <asp:HiddenField ID="hdnIdEdit" Value='<%# Container.DataItemIndex + 1 %>' runat="server" />
                                </EditItemTemplate>
                                <ItemStyle Width="50" CssClass="border_left" />
                                <HeaderStyle Width="44" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Srv NO.">
                                <ItemTemplate>
                                    <asp:Label ID="lblSrvno" runat="server" Text='<%# Eval("SrvNo") %>'></asp:Label>
                                    <asp:HiddenField ID="hdnsrvNo" runat="server" Value='<%# Eval("SrvNo") %>' />
                                     <asp:Label ID="lblBillNo" runat="server" Text='<%# Eval("PartyBillNumber") %>'></asp:Label>
                                     <asp:HiddenField ID="HdnBillNumber" runat="server" value='<%# Eval("PartyBillNumber") %>'/>
                                </ItemTemplate> 
                                <EditItemTemplate>
                                    <asp:Label ID="lblSrvnoedit" runat="server" Text='<%# Eval("SrvNo") %>'></asp:Label>
                                    <asp:Label ID="lblBillNo_edit" runat="server" Text='<%# Eval("PartyBillNumber") %>'></asp:Label>
                                    <asp:HiddenField ID="hdnsrvNo" runat="server" Value='<%# Eval("SrvNo") %>' />
                                    <asp:HiddenField ID="HdnBillNumber" runat="server" value='<%# Eval("PartyBillNumber") %>'/>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:Label ID="lblSrvNo_Footer" CssClass="txtEditParticular" Width="97%" runat="server"></asp:Label>
                                      <asp:Label ID="lblBillNo_Footer" runat="server" Text='<%# Eval("PartyBillNumber") %>' ></asp:Label>
                                </FooterTemplate>
                                <ItemStyle Width="75" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Particulars">
                                <ItemTemplate>
                                    <asp:Label ID="lblDebitParticur" runat="server" Text='<%# Eval("ParticularName") %>'></asp:Label>
                                    <asp:HiddenField ID="hdnParticularId" runat="server" Value='<%# Eval("DebitNoteParticularId") %>' />
                                    <asp:HiddenField ID="hdnDebitNote_SRVID" runat="server" Value='<%# Eval("Acc_DebitNote_SRVID") %>' />
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtDebitParticur" CssClass="txtEditParticular" runat="server" Text='<%# Eval("ParticularName") %>'></asp:TextBox>
                                    <asp:HiddenField ID="hdnParticularIdEdit" runat="server" Value='<%# Eval("DebitNoteParticularId") %>' />
                                    <asp:HiddenField ID="hdnDebitNote_SRVIDEdit" runat="server" Value='<%# Eval("Acc_DebitNote_SRVID") %>' />
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtDebitParticur_Footer" CssClass="txtEditParticular" Width="97%" runat="server"></asp:TextBox>
                                </FooterTemplate>
                                <ItemStyle Width="500" />
                                <FooterStyle Width="500" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Debit Type">
                                <ItemTemplate>
                                    <asp:Label ID="lblExtraQty" runat="server" Text=""></asp:Label>
                                    <asp:HiddenField ID="hdnIsExtrQty" Value='<%# Eval("IsExtraQty") %>' runat="server" />
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:Label ID="lblExtraQtyEdit" runat="server" Text=""></asp:Label>
                                    <asp:HiddenField ID="hdnIsExtrQtyEdit" Value='<%# Eval("IsExtraQty") %>' runat="server" />
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:Label ID="lblExtraQtyFooter" runat="server" Text=""></asp:Label>
                                    <asp:HiddenField ID="hdnIsExtrQtyFooter" Value="-1" runat="server" />
                                </FooterTemplate>
                                <ItemStyle Width="60" />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <asp:Label ID="lblQtyHeader" runat="server" Text=""></asp:Label>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblDebitQty" Style="text-transform: capitalize;" runat="server" Text='<%# Eval("DebitQuantity") %>'></asp:Label>
                                    <asp:Label ID="lblunits" Style="text-transform: capitalize;" runat="server"></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtDebitQty" MaxLength="8" CssClass="txtEditWidth" onblur="CalculateGridAmount(this, 'Edit', 'Qty')" onkeypress="return isNumberKey(event)" Text='<%# Eval("DebitQuantity") %>' runat="server"></asp:TextBox>
                                    <asp:HiddenField ID="hdnDebitQty" Value='<%# Eval("DebitQuantity") %>' runat="server" />
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtDebitQty_Footer" Style="text-align: center" onblur="CalculateGridAmount(this, 'Footer', 'Qty')" CssClass="txtEditWidth" MaxLength="8" onkeypress="return isNumberKey(event)" runat="server"></asp:TextBox>
                                </FooterTemplate>
                                <ItemStyle Width="70" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Rate">
                                <ItemTemplate>
                                    <span class="indianCurr"></span>
                                    <asp:Label ID="lblDebitRate" runat="server" Text='<%# Eval("DebitRate") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtDebitRate" MaxLength="5" CssClass="txtEditWidth" onblur="CalculateGridAmount(this, 'Edit', 'Rate')" onkeypress="return isNumberKeydec(event)" runat="server" Text='<%# Eval("DebitRate") %>'></asp:TextBox>
                                    <asp:HiddenField ID="hdnDebitRate" Value='<%# Eval("DebitRate") %>' runat="server" />
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtDebitRate_Footer" Style="text-align: center" CssClass="txtFooterWidth" onblur="CalculateGridAmount(this, 'Footer', 'Rate')" MaxLength="5" onkeypress="return isNumberKeydec(event)" runat="server"></asp:TextBox>
                                </FooterTemplate>
                                <FooterStyle Width="80" CssClass="txtLeft" />
                                <ItemStyle Width="80" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Amount">
                                <ItemTemplate>
                                    <span class="indianCurr"></span>
                                    <asp:Label ID="lblAmount" runat="server" Text='<%# Eval("Amount") %>'></asp:Label>
                                    <asp:HiddenField ID="hdnAmount" Value='<%# Eval("Amount") %>' runat="server" />
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:Label ID="lblAmountEdit" runat="server" Text='<%# Eval("Amount") %>'></asp:Label>
                                    <asp:HiddenField ID="hdnAmountEdit" Value='<%# Eval("Amount") %>' runat="server" />
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <div id="indianCurrS" runat="server">
                                    </div>
                                    <asp:Label ID="lblAmount_Footer" runat="server"></asp:Label>
                                    <asp:HiddenField ID="hdnAmount_Footer" Value='<%# Eval("Amount") %>' runat="server" />
                                </FooterTemplate>
                                <ItemStyle Width="100" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Action">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lkEdit" runat="server" CausesValidation="False" CommandName="Edit" OnClientClick="javascript:return HideShowGST()"> <img src="../../images/edit2.png" alt="Edit" title="Edit" /></asp:LinkButton>
                                    <asp:LinkButton ForeColor="black" Width="30px" ID="lnkDelete" runat="server" CommandName="Delete" OnClientClick="return confirm('Are you sure you want to delete?');HideShowGST()"> <img src="../../images/del-butt.png" /></asp:LinkButton>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:LinkButton ID="lkUpdate" runat="server" ValidationGroup="Edit" CausesValidation="true" OnClientClick="javascript:return ValidateGrid(this, 'Edit');HideShowGST()" CommandName="Update"> <img src="../../images/save.png" alt="Update" title="Update" border="0" style="width:18px;" /></asp:LinkButton>
                                    <asp:LinkButton ID="lkCancel" runat="server" CausesValidation="False" CommandName="Cancel"> <img src="../../images/cancel1.jpg" alt="Cancel" title="Cancel" border="0" style="width:25px;position: relative; top: 3px;"/></asp:LinkButton>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:LinkButton runat="server" ID="Submit" OnClientClick="javascript:return ValidateGrid(this, 'Footer');HideShowGST()" CommandName="Insert"> <img src="../../images/add-butt.png" /></asp:LinkButton>
                                </FooterTemplate>
                                <ItemStyle Width="100" CssClass="border_right" />
                            </asp:TemplateField>
                        </Columns>
                        <EmptyDataTemplate>
                            <table cellpadding="0" class="emptytable GSTTAbleEmp" cellspacing="0" style="max-width: 700px; width: 693px; border-top: 0px solid !important;">
                                <tr>
                                    <th style="width: 50px; max-width: 50px;">
                                        Sr. No.
                                    </th>
                                    <th style="width: 50px; max-width: 50px;">
                                        SrvNo
                                    </th>
                                    <th style="width: 509px; max-width: 509px;">
                                        Particulars
                                    </th>
                                    <th style="width: 60px; max-width: 60px;">
                                        Debit Type
                                    </th>
                                    <th style="width: 70px; max-width: 70px;">
                                        <asp:Label ID="lblEmptyQtyHeader" runat="server" Text=""></asp:Label>
                                    </th>
                                    <th style="width: 80px; max-width: 80px;">
                                        Rate
                                    </th>
                                    <th style="width: 100px; max-width: 100px;">
                                        Amount
                                    </th>
                                    <th style="width: 100px; max-width: 100px;">
                                        Action
                                    </th>
                                </tr>
                                <tr>
                                    <td style="width: 50px; max-width: 50px;">
                                    </td>
                                    <td style="width: 50px; max-width: 50px;">
                                        <asp:Label ID="srvno_Empty" runat="server"></asp:Label>
                                    </td>
                                    <td style="width: 509px; max-width: 509px;">
                                        <asp:TextBox runat="server" ID="txtDebitParticular_Empty" CssClass="txtEditParticular" Width="96%" Text=""></asp:TextBox>
                                    </td>
                                    <td style="width: 60px; max-width: 60px;">
                                        &nbsp;
                                        <asp:Label ID="lblExtrQty_Empty" runat="server" Text="N/A"></asp:Label>
                                        <asp:HiddenField ID="hdnExtrQty_Empty" Value="-1" runat="server" />
                                    </td>
                                    <td style="width: 70px; max-width: 70px;">
                                        <asp:TextBox runat="server" ID="txtDebitQty_Empty" MaxLength="8" onkeypress="return isNumberKey(event)" Width="90%" Text="" onblur="CalculateGridAmount(this, 'Empty', 'Qty')"></asp:TextBox>
                                    </td>
                                    <td class="txtLeft" style="padding-left: 2px; width: 80px; max-width: 80px;">
                                        <asp:TextBox runat="server" ID="txtDebitRate_Empty" MaxLength="5" onkeypress="return isNumberKeydec(event)" Width="69%" Text="" onblur="CalculateGridAmount(this, 'Empty', 'Rate')"></asp:TextBox>
                                    </td>
                                    <td style="width: 100px; max-width: 100px;">
                                        &nbsp;
                                        <asp:Label ID="lblAmount_Empty" runat="server" Text=""></asp:Label>
                                        <asp:HiddenField ID="hdnAmount_Empty" Value="0" runat="server" />
                                    </td>
                                    <td style="width: 100px; max-width: 100px;">
                                        <asp:LinkButton runat="server" ID="Submit" OnClientClick="javascript:return ValidateGrid(this, 'Empty');HideShowGST()" CommandName="AddEmpty"> <img src="../../images/add-butt.png" /></asp:LinkButton>
                                    </td>
                                </tr>
                            </table>
                        </EmptyDataTemplate>
                    </asp:GridView>
                </div>
                <div>
                    <table cellpadding="0" class="emptytable GSTTAble GST_TAble" cellspacing="0" style="max-width: 983px; border-top: 0px solid !important; border-color: #d0cece">
                        <tr id="tdIIGST" runat="server" class="clsIGST">
                            <td style="width:628px;border-right-color: #999;" class="PrientClass ">
                                &nbsp;
                            </td>
                            <td style="width:68px;border-bottom:1px solid #999999;" class="PrientClass4 txtColorGray">
                                IGST
                            </td>
                            <td style="width:75px;border-bottom:1px solid #999999;" class="PrientClass3">
                                <asp:TextBox runat="server" ID="txtIGST" MaxLength="5" onkeypress="return isNumberKeydec(event)" Width="50%" Text="" onblur="CalculateGSTAmount(this, 1);" Enabled="false"></asp:TextBox>
                                <span>%</span>
                            </td>
                            <td style="width:95px;border-bottom:1px solid #999999;" class="PrientClass2">
                                <asp:Label ID="lblIgstCurrency" runat="server"></asp:Label>
                                <asp:Label ID="lblIGSTAmount" runat="server" Text=""></asp:Label>
                                <asp:HiddenField ID="hdnIGSTAmount" Value="0" runat="server" />
                            </td>
                            <td style="width: 93px;border-bottom:1px solid #999999;" class="PrientClass1">
                                &nbsp;
                            </td>
                        </tr>
                        <tr id="tdCGST" runat="server" class="clsCGST_SGST">
                            <td style="width: 613px; max-width:613px; border-right: 1px solid #999;">
                                &nbsp;
                            </td>
                            <td style="border-bottom: 1px solid #9999; width: 68px; max-width: 68px;" class="txtColorGray">
                                CGST
                            </td>
                            <td style="border-bottom: 1px solid #9999; width: 75px; max-width: 75px;">
                                <asp:TextBox runat="server" ID="txtCGST" MaxLength="5" onkeypress="return isNumberKeydec(event)" Width="50%" Text="" onblur="CalculateGSTAmount(this, 2);" Enabled="false"></asp:TextBox>
                                <span>%</span>
                            </td>
                            <td style="border-bottom: 1px solid #9999; width: 95px; max-width: 95px;">
                                <asp:Label ID="lblCgstCurrency" runat="server"></asp:Label>
                                <asp:Label ID="lblCGSTAmount" runat="server" Text=""></asp:Label>
                                <asp:HiddenField ID="hdnCGSTAmount" Value="0" runat="server" />
                            </td>
                            <td style="border-bottom: 1px solid #9999; border-right: 1px solid #999; width: 93px; max-width: 93px">
                                &nbsp;
                            </td>
                        </tr>
                        <tr id="tdSGST" runat="server" class="clsCGST_SGST">
                            <td style="width: 487px; max-width: 505px; border-right: 1px solid #999;">
                                &nbsp;
                            </td>
                            <td style="border-bottom: 1px solid #9999; width: 67px; max-width: 67px;" class="txtColorGray">
                                SGST
                            </td>
                            <td style="border-bottom: 1px solid #9999; width: 69px; max-width: 69px;">
                                <asp:TextBox runat="server" ID="txtSGST" MaxLength="5" onkeypress="return isNumberKeydec(event)" Width="50%" Text="" onblur="CalculateGSTAmount(this, 3);" Enabled="false"></asp:TextBox>
                                <span>%</span>
                            </td>
                            <td style="border-bottom: 1px solid #9999; width: 87px; max-width: 87px;">
                                <asp:Label ID="lblSgstCurrency" runat="server"></asp:Label>
                                <asp:Label ID="lblSGSTAmount" runat="server" Text=""></asp:Label>
                                <asp:HiddenField ID="hdnSGSTAmount" Value="0" runat="server" />
                            </td>
                            <td style="border-bottom: 1px solid #9999; border-right: 1px solid #999; width: 89px; max-width: 89px;">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 487px; max-width: 505px; border-right: 1px solid #999;">
                                &nbsp;
                            </td>
                            <td style="border-bottom: 1px solid #999; width: 136px; max-width: 136px" colspan="2" class="txtColorGray">
                                Total
                            </td>
                            <td style="border-bottom: 1px solid #999; width: 87px; max-width: 87px;">
                                <asp:Label ID="lblGranTotalCurrency" runat="server"></asp:Label>
                                <asp:Label ID="lblGrandTotalAmount" runat="server" Text=""></asp:Label>
                                <asp:HiddenField ID="hdnTotalAmount" runat="server" />
                                <asp:HiddenField ID="hdnGrandTotalAmount" runat="server" />
                            </td>
                            <td style="border-bottom: 1px solid #999; border-right: 1px solid #999; width: 89px; max-width: 89px;">
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </div>
                <div style="max-width: 100%; height: 15px;">
                </div>
                <div class="bottomtable">
                    <table style="max-width: 100%; width: 100%; border: 1px solid #999999; border-collapse: collapse;">
                        <tbody>
                            <tr>
                                <td style="width: 137px; border-bottom: 1px solid #999999; padding-left: 5px;" class="txtColorGray">
                                    Returned Challan No. <span></span>
                                </td>
                                <td style="border-right: 1px solid #999999; width: 118px; border-bottom: 1px solid #999999">
                                    <asp:TextBox ID="txtReturnChallan" Width="90%" Enabled="false" runat="server" Text=""></asp:TextBox>
                                </td>
                                
                                <td style="width: 32px; border-bottom: 1px solid #999999; padding-left: 2px;" class="txtColorGray">
                                    Date:
                                </td>
                                <td style="border-right: 1px solid #999999; width: 120px; border-bottom: 1px solid #999999">
                                    <asp:TextBox ID="txtreturndate" Enabled="false" Width="94%" runat="server" CssClass="th style-eta date_style" Text=""></asp:TextBox>
                                </td>
                                <td style="width: 42px; border-bottom: 1px solid #999999; padding-left: 2px; color: #000; font-weight: 600;" class="txtColorGray">
                                    Rupees
                                </td>
                                <td style="width: 360px; border-bottom: 1px solid #999999; font-size: 11px">
                                    <asp:Label ID="lblRupees" Font-Bold="true" ForeColor="#000" runat="server"></asp:Label>
                                    <asp:HiddenField ID="hdnRupees" runat="server" />
                                </td>
                            </tr>
                        </tbody>
                    </table>
                    <table style="max-width: 100%; width: 100%; border: none" cellspacing="0" cellpadding="0">
                        <thead>
                            <tr>
                                <td colspan="4" style="width: 70%">
                                    &nbsp;
                                    <asp:Label ID="lblGstMsg" ForeColor="Red" Font-Bold="true" runat="server" Text=""></asp:Label>
                                </td>
                                <td style="text-align: center; padding-right: 8px; padding-top: 15px; color: #000; font-size: 12px;line-height:25px;">
                                    <span style="font-weight: bold">Boutique International Pvt. Ltd.</span>
                                    <div id="divChkAuthorized" runat="server">
                                        <asp:HiddenField ID="hdnIsChecked" Value="0" runat="server" />
                                        <asp:CheckBox ID="chkAuthorised" runat="server" onclick="DisplaySendMail()" Enabled="false" />
                                        (Authorized Signature)
                                    </div>
                                    <div id="divSigAuthorized" runat="server" visible="false">
                                        <asp:Image ID="imgAuthorized" runat="server" Height="40px" Width="110px" />
                                        <br />
                                        <asp:Label ID="lblAuthorizedName" runat="server" Style="line-height: 20px;"></asp:Label>
                                        <br />
                                        <asp:Label ID="lblAuthorizedOnDate" runat="server"></asp:Label>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="5" style="text-align: center; padding: 5px 0px;">
                                    <div class="form_buttom" style="float: left;">
                                        <asp:Button ID="btnSubmit" CssClass="btnSubmit printHideButton" ClientIDMode="Static" OnClientClick="this.disabled = true; Debitnote_Validation();" UseSubmitBehavior="False" runat="server" Text="Save" OnClick="btnSubmit_Click" />
                                    </div>
                                    <div class="btnClose printHideButton" id="Closesbox" onclick="javascript:self.parent.Shadowbox.close();">
                                        Close
                                    </div>
                                    <div class="btnPrint printHideButton" onclick="PrintThisPage()">
                                        Print
                                    </div>
                                    <div id="dvSendMail" style="width: 400px; font-weight: bold; top: 5px; display: none;" runat="server">
                                        &nbsp; &nbsp; Is E-Mail Send:<asp:RadioButton ID="rbtnYes" Text="Yes" GroupName="Mail" runat="server" />
                                        <asp:RadioButton ID="rbtnNo" Text="No" GroupName="Mail" Checked="true" runat="server" />
                                    </div>
                                </td>
                            </tr>
                        </thead>
                    </table>
                    <asp:Button ID="btnRefresh" Style="display: none;" runat="server" Text="" OnClick="btnRefresh_Click" />
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
