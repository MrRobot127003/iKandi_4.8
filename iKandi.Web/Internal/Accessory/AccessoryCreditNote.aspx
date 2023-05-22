<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AccessoryCreditNote.aspx.cs"
    Inherits="iKandi.Web.Internal.Accessory.AccessoryCreditNote" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
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
        font-family: Arial !important;
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
    .txtColorGray
    {
        color: Gray;
    }
    .emptytable th
    {
        background: #e4e2e2;
        text-align: center;
        border: 1px solid #9999;
    }
    .emptytable td
    {
        text-align: center;
    }
    .grdviewtable
    {
        border-top: 0px;
        max-width: 100%;
        min-width: 100%;
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
        line-height: 23px;
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
        line-height: 23px;
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
        line-height: 23px;
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
        font-family: arila;
        margin: 2px 0px;
        text-transform: capitalize;
    }
    .txtEditWidth
    {
        width: 88% !important;
        text-align: center;
    }
    .txtEditParticular
    {
        width: 97% !important;
        text-align: left;
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
            width: 64px !important;
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
        text-transform: inherit;
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
        width: 75% !important;
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
    .grdviewtable td:nth-child(2)
    {
        padding-left: 2px;
        text-align: left;
        word-break: break-all;
    }
    .grdviewtable td:input[type="text"]
    {
        text-transform: inherit;
    }
   
</style>
<head runat="server">
    <title></title>
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
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/iKandi.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/jquery.jcarousel.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/jquery.autocomplete.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/jquery.fixedtableheader-1-0-2.min.js")%>'></script>
    <script src='<%= Page.ResolveUrl("~/js/jquery.easydrag.js")%>' type="text/javascript"></script>
    <script src='<%= Page.ResolveUrl("~/js/jquery.jqprint.0.3.js")%>' type="text/javascript"></script>
    <script src='<%= Page.ResolveUrl("~/js/jquery.MultiFile.pack.js")%>' type="text/javascript"></script>
    <script src='<%= Page.ResolveUrl("~/js/jquery.hoverIntent.min.js")%>' type="text/javascript"></script>
    <%-- <script src='<%= Page.ResolveUrl("~/js/jquery.simpletip-1.3.1.pack.js")%>' type="text/javascript"></script>--%>
    <script src='<%= Page.ResolveUrl("~/js/jquery.tools.min.js")%>' type="text/javascript"></script>
    <script src='<%= Page.ResolveUrl("~/js/jquery.checkbox.min.js")%>' type="text/javascript"></script>
    <script src='<%= Page.ResolveUrl("~/js/fna.js")%>' type="text/javascript"></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/date.js")%>'></script>
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
        var hdnTotalAmount = '<%=hdnTotalAmount.ClientID %>';
        var hdnGrandTotalAmountClientID = '<%=hdnGrandTotalAmount.ClientID %>';
        var hdnBillAmountClientID = '<%=hdnBillAmount.ClientID %>';

        var lblRupeesClientID = '<%=lblRupees.ClientID %>'; //new line
        var hdnRupees = '<%=hdnRupees.ClientID %>'; //new line

        //new code start
        $(document).ready(function () {
            //debugger;
            var GSTNo = $("#hdnGST_No").val();
            if (GSTNo == "" || GSTNo == "0") {
                $('.clsIGST').css("display", "display");
                $('.clsCGST_SGST').css("display", "display");
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
        })

        function HideShowGST() {
//            alert("Hello");
//            debugger;
            var GSTNo = $("#hdnGST_No").val();
            if (GSTNo == "" || GSTNo == "0") {
                $('.clsIGST').css("display", "display");
                $('.clsCGST_SGST').css("display", "display");
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
        //new code end

        //new code for Converting Number to Word Start
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

//                var rupees = '';
//                if (DecimalChar == '') {
//                    rupees = words_string != '' ? 'rupees' : '';
//                }

            }
            //return words_string;
            if (DecimalChar != '') {
                words_string = words_string  + 'and ' + DecimalChar + ' paise';
//                words_string = words_string + ' rupees ' + 'and ' + DecimalChar + ' paise';
            }
            $("#" + lblRupeesClientID).text(words_string);
            //$("#" + lblRupeesClientID).text(words_string + rupees);
            $("#" + hdnRupees).val(words_string);
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
        //new code fro Converting Number to Word End




        function CalculateGridAmount(obj, type) {
            //debugger;
            var TotalAmount = 0;
            var value = $(obj).val();

            var TotalCreditQty = 0;
            var TotalCreditRate = 0;
            var IGSTAmount = 0;
            var CGSTAmount = 0;
            var SGSTAmount = 0;
            var GrandTotalAmount = 0;

            var FooterAmount = 0;

            if (type == 'Empty') {
                var gvId = "ctl01";
                var CreditQty = $("#<%= grdAccessoryCreditNot.ClientID %> input[id*='" + gvId + "_txtCreditQty_Empty" + "']").val();
                var CreditRate = $("#<%= grdAccessoryCreditNot.ClientID %> input[id*='" + gvId + "_txtCreditRate_Empty" + "']").val();

                if (CreditQty == '')
                    CreditQty = 0;

                if (CreditRate == '')
                    CreditRate = 0;

                TotalCreditQty = CreditQty;
                TotalCreditRate = CreditRate;

                TotalAmount = parseFloat(CreditQty) * parseFloat(CreditRate);
                $("#" + hdnTotalAmount).val(TotalAmount);

                if (parseFloat(TotalAmount) > 0) {
                    $("#<%= grdAccessoryCreditNot.ClientID %> span[id*='" + gvId + "_lblAmount_Empty" + "']").text(TotalAmount.toFixed(2));
                    $("#<%= grdAccessoryCreditNot.ClientID %> input[id*='" + gvId + "_hdnAmount_Empty" + "']").val(TotalAmount.toFixed(2));
                }
                else {
                    $("#<%= grdAccessoryCreditNot.ClientID %> span[id*='" + gvId + "_lblAmount_Empty" + "']").text('');
                    $("#<%= grdAccessoryCreditNot.ClientID %> input[id*='" + gvId + "_hdnAmount_Empty" + "']").val(TotalAmount);
                }

            }
            if (type == 'Edit') {
                var Ids = obj.id;
                var gvId = Ids.split("_")[1].substr(3);

                var hdnCreditQty = $("#<%= grdAccessoryCreditNot.ClientID %> input[id*='" + gvId + "_hdnCreditQty" + "']").val();
                var hdnCreditRate = $("#<%= grdAccessoryCreditNot.ClientID %> input[id*='" + gvId + "_hdnCreditRate" + "']").val();

                var CreditQty = $("#<%= grdAccessoryCreditNot.ClientID %> input[id*='" + gvId + "_txtCreditQty" + "']").val();
                var CreditRate = $("#<%= grdAccessoryCreditNot.ClientID %> input[id*='" + gvId + "_txtCreditRate" + "']").val();

                if (CreditQty == '')
                    CreditQty = 0;

                if (CreditRate == '')
                    CreditRate = 0;

                TotalCreditQty = CreditQty;
                TotalCreditRate = CreditRate;

                var EditAmount = parseFloat(CreditQty) * parseFloat(CreditRate);

                if (parseFloat(EditAmount) > 0) {
                    $("#<%= grdAccessoryCreditNot.ClientID %> span[id*='" + gvId + "_lblAmountEdit" + "']").text(EditAmount.toFixed(2));
                    $("#<%= grdAccessoryCreditNot.ClientID %> input[id*='" + gvId + "_hdnAmountEdit" + "']").val(EditAmount.toFixed(2));
                }
                else {
                    $("#<%= grdAccessoryCreditNot.ClientID %> span[id*='" + gvId + "_lblAmountEdit" + "']").text('');
                    $("#<%= grdAccessoryCreditNot.ClientID %> input[id*='" + gvId + "_hdnAmountEdit" + "']").val(EditAmount);
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

                    var Amount = $("#<%= grdAccessoryCreditNot.ClientID %> input[id*='" + gvId + "_hdnAmount" + "']").val();
                    TotalAmount = parseFloat(TotalAmount) + parseFloat(Amount);
                }

                $("#" + hdnTotalAmount).val(TotalAmount);
            }
            if (type == 'Footer') {
                var GridRow = $(".gvRow").length;
                var RowId = parseInt(GridRow) + 2;
                var gvId;
                if (RowId < 10)
                    gvId = 'ctl0' + RowId;
                else
                    gvId = 'ctl' + RowId;

                var CreditQty = $("#<%= grdAccessoryCreditNot.ClientID %> input[id*='" + gvId + "_txtCreditQty_Footer" + "']").val();
                var CreditRate = $("#<%= grdAccessoryCreditNot.ClientID %> input[id*='" + gvId + "_txtCreditRate_Footer" + "']").val();

                if (CreditQty == '')
                    CreditQty = 0;

                if (CreditRate == '')
                    CreditRate = 0;

                TotalCreditQty = CreditQty;
                TotalCreditRate = CreditRate;

                FooterAmount = parseFloat(CreditQty) * parseFloat(CreditRate);
                TotalAmount = $("#" + hdnTotalAmount).val();
                TotalAmount = parseFloat(TotalAmount) + parseFloat(FooterAmount);
                $("#" + hdnTotalAmount).val(TotalAmount);

                if (parseFloat(FooterAmount) > 0) {
                    $("#<%= grdAccessoryCreditNot.ClientID %> span[id*='" + gvId + "_lblAmount_Footer" + "']").text(FooterAmount.toFixed(2));
                    $("#<%= grdAccessoryCreditNot.ClientID %> input[id*='" + gvId + "_hdnAmount_Footer" + "']").val(FooterAmount.toFixed(2));
                }
                else {
                    $("#<%= grdAccessoryCreditNot.ClientID %> span[id*='" + gvId + "_lblAmount_Footer" + "']").text('');
                    $("#<%= grdAccessoryCreditNot.ClientID %> input[id*='" + gvId + "_hdnAmount_Footer" + "']").val(FooterAmount);
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

            GrandTotalAmount = parseFloat(TotalAmount) + parseFloat(IGSTAmount) + parseFloat(CGSTAmount) + parseFloat(SGSTAmount);

            var BillAmount = $("#" + hdnBillAmountClientID).val();
            if (BillAmount != "") {
                if (parseFloat(GrandTotalAmount) > parseFloat(BillAmount)) {
                    alert('Total Amount can not be greater than bill amount');
                    $(obj).val('0');

                    if (type == 'Footer') {
                        var NewAmount = parseFloat(TotalAmount) - parseFloat(FooterAmount)
                        $("#" + hdnTotalAmount).val(NewAmount);
                    }
                    else if (type == 'Edit') {
                        $("#<%= grdAccessoryCreditNot.ClientID %> input[id*='" + gvId + "_txtCreditQty" + "']").val(hdnCreditQty);
                        $("#<%= grdAccessoryCreditNot.ClientID %> input[id*='" + gvId + "_txtCreditRate" + "']").val(hdnCreditRate);
                    }
                    CalculateGridAmount(obj, type);
                }
                else {
                    $("#" + hdnGrandTotalAmountClientID).val(GrandTotalAmount.toFixed(2));

                    if (parseFloat(GrandTotalAmount) > 0) {
                        $("#" + lblGrandTotalAmountClientID).text(GrandTotalAmount.toFixed(2));
                        convertNumberToWords(GrandTotalAmount.toFixed(2));//new line                    
                    }                   
                }
            }

        }

        function CalculateGSTAmount(obj, type) {
            //debugger;
            var TotalAmount = 0;
            var Amount = 0;
            TotalAmount = $("#" + hdnTotalAmount).val();
            if (parseInt(TotalAmount) > 0) {

                if (type == 1) {
                    var GSTRate = $("#" + txtIGSTClientID).val();
                    if ((GSTRate == '') || (GSTRate == '0')) {
                        $("#" + hdnIGSTAmountClientID).val(0);
                        $("#" + lblIGSTAmountClientID).text('');
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
                        alert('Total Amount can not be greater than bill amount');
                        //$("#btnRefresh").click();
                        $(obj).val('0');
                        CalculateGSTAmount(obj, type)
                    }
                    else {
                        
                        $("#" + hdnGrandTotalAmountClientID).val(GrandTotalAmount.toFixed(2));
                        if (parseFloat(GrandTotalAmount) > 0) {
                            $("#" + lblGrandTotalAmountClientID).text(GrandTotalAmount.toFixed(2));
                            convertNumberToWords(GrandTotalAmount.toFixed(2)); //new line
                        } 
                    }
                }

            }
        }

        function ValidateGrid(obj, type) {
            debugger;
            var CreditParticular = '';
            var CreditQty = '';
            var CreditRate = '';
            if (type == 'Empty') {
                var gvId = "ctl01";
                var CreditParticular = $("#<%= grdAccessoryCreditNot.ClientID %> input[id*='" + gvId + "_txtCreditParticular_Empty" + "']").val();
                var CreditQty = $("#<%= grdAccessoryCreditNot.ClientID %> input[id*='" + gvId + "_txtCreditQty_Empty" + "']").val();
                var CreditRate = $("#<%= grdAccessoryCreditNot.ClientID %> input[id*='" + gvId + "_txtCreditRate_Empty" + "']").val();
            }
            if (type == 'Edit') {
                var Ids = obj.id;
                var gvId = Ids.split("_")[1].substr(3);

                var CreditParticular = $("#<%= grdAccessoryCreditNot.ClientID %> input[id*='" + gvId + "_txtCreditParticular" + "']").val();
                var CreditQty = $("#<%= grdAccessoryCreditNot.ClientID %> input[id*='" + gvId + "_txtCreditQty" + "']").val();
                var CreditRate = $("#<%= grdAccessoryCreditNot.ClientID %> input[id*='" + gvId + "_txtCreditRate" + "']").val();
            }
            if (type == 'Footer') {
                var GridRow = $(".gvRow").length;
                var RowId = parseInt(GridRow) + 2;
                var gvId;
                if (RowId < 10)
                    gvId = 'ctl0' + RowId;
                else
                    gvId = 'ctl' + RowId;

                var CreditParticular = $("#<%= grdAccessoryCreditNot.ClientID %> input[id*='" + gvId + "_txtCreditParticur_Footer" + "']").val();
                var CreditQty = $("#<%= grdAccessoryCreditNot.ClientID %> input[id*='" + gvId + "_txtCreditQty_Footer" + "']").val();
                var CreditRate = $("#<%= grdAccessoryCreditNot.ClientID %> input[id*='" + gvId + "_txtCreditRate_Footer" + "']").val();
            }

            if (CreditQty == '')
                CreditQty = '0';

            if (CreditRate == '')
                CreditRate = '0';

            if (CreditParticular == '') {
                alert('Credit Particular can not be Empty');
                return false;
            }
            if (CreditQty == '0') {
                alert('Credit Quantity can not be Empty or zero');
                return false;
            }
            if (CreditRate == '0') {
                alert('Credit Rate can not be Empty or zero');
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

        function Creditnote_Validation() {
            debugger;
            var GridRow = $(".gvRow").length;

            if (parseInt(GridRow) == 0) {
                var gvId = "ctl01";
                var CreditQty = $("#<%= grdAccessoryCreditNot.ClientID %> input[id*='" + gvId + "_txtCreditQty_Empty" + "']").val();
                var CreditRate = $("#<%= grdAccessoryCreditNot.ClientID %> input[id*='" + gvId + "_txtCreditRate_Empty" + "']").val();

                if (CreditQty == '')
                    CreditQty = 0;

                if (CreditRate == '')
                    CreditRate = 0;

                if ((CreditQty == 0) || (CreditRate == 0)) {
                    alert('Credit Quantity or Rate can not be Empty or zero');
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

                    var CreditQty = $("#<%= grdAccessoryCreditNot.ClientID %> input[id*='" + gvId + "_txtCreditQty" + "']").val();
                    var CreditRate = $("#<%= grdAccessoryCreditNot.ClientID %> input[id*='" + gvId + "_txtCreditRate" + "']").val();
                    if (CreditQty != undefined) {
                        if (CreditQty == '')
                            CreditQty = 0;

                        if (CreditRate == '')
                            CreditRate = 0;

                        if ((CreditQty == 0) || (CreditRate == 0)) {
                            alert('Credit Quantity or Rate can not be Empty or zero');
                            return false;
                        }
                    }
                }
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

        function confirmAlert(txt) {            
            var id = txt.id;
            if ($('#' + id).attr("disabled", "disabled")) {
                return false;
            }
            else {
                if (confirm('Are you sure you want to delete?')) return true;
                else return false;
            }
            return true;
        }
    </script>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="sm" runat="server" EnablePartialRendering="true">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="Updatepanel1" runat="server">
        <ContentTemplate>
         <asp:UpdateProgress runat="server" ID="uproTargetAdmin" AssociatedUpdatePanelID="UpdatePanel1"
        DisplayAfter="0">
        <ProgressTemplate>
            <img src="../../App_Themes/ikandi/images1/loading36.gif" alt="" style="position: fixed;
                z-index: 52111; top: 40%; left: 45%; width: 8%;" />
        </ProgressTemplate>
    </asp:UpdateProgress>

            <div class="FabricCreaditNote">
                <asp:HiddenField ID="hdnrowcount" runat="server" />
                <asp:HiddenField ID="hdnCreditnotid" runat="server" />
                <asp:HiddenField ID="hdnGST_No" runat="server" value="0" />    <%--new line--%>
                <asp:HiddenField ID="hdnPO_Number" Value="0" runat="server" />
                <asp:HiddenField ID="hdnMailSentStatus" Value="0" runat="server" />
                <asp:HiddenField ID="hdnDebitNoteNumber" Value="0" runat="server" />
                
                <table style="max-width: 100%; width: 100%; border: 1px solid #999999; border-bottom: 0px solid #999999"
                    cellspacing="0" cellpadding="0">
                    <thead>
                        <tr>
                            <td colspan="3" class="top_heading">
                                Accessory Credit Note
                            </td>
                        </tr>
                        <tr>
                            <td style="vertical-align:top;width:125px;">
                              <div style="padding:9px 7px">
                                    <img src="../../images/boutique-logo.png"/>
                              </div>
                            </td>
                            <td style="text-align: left;padding-left:10px;border-right: 1px solid lightgray;">
                              <%--span class="address_head">H.O. C-45-46 Hosiery Complex Phase-II Extn. NOIDA -201305(U.P)</span><br />
                                <span class="address_head">Tel. +911206797979, Fax:- 6797999, E-mail-boutique@boutique.in</span>--%>
                                <div id="divbipladdress" runat="server" style="font-size:10px">
                                </div>
                            </td>
                            <td style=" font-size: 11px;padding-left: 5px;">
                                <table border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td class="txtColorGray">
                                            Credit Number: &nbsp;
                                        </td>
                                        <td>
                                            <asp:Label ID="lblCreditNo" Style="font-size: 11px; font-weight: bold;" runat="server"
                                                Text=""></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </thead>
                </table>
                <table class="gridtable" style="max-width: 100%; width: 100%; border: 1px solid #999999;
                    border-bottom: 0px solid #999999; border-top-color: #dbd8d8;" cellspacing="0"
                    cellpadding="0">
                    <thead>
                        <tr>
                          <td colspan="2" style="width:50%;font-size: 12px; padding: 5px; border-top-color: #dbd8d8;border-right:1px solid #dbd8d8;">
                            <span style="padding-bottom: 10px; color: gray;width:75px;display:inline-block;" class="txtColorGray">M/S:</span>
                            <asp:Label ID="lblSupllierName" Text="" runat="server"></asp:Label><br />
                            <span style="padding-bottom: 10px; color: gray;width:75px;display:inline-block;">GST No:</span>
                            <asp:Label ID="lblSupplierGstNo" Text="" runat="server"></asp:Label><br />
                           <span style="padding-bottom: 10px; color: gray;width:75px;display:inline-block;float:left;">Address:</span>
                           <asp:Label ID="lblSupplierAddress" Text="" runat="server"></asp:Label>                          
                         </td>
                            <td style="width:50%; font-size: 11px; padding-left: 5px; border-top-color: #dbd8d8;line-height: 25px;">

                                 <span style="width:112px;display:inline-block;" class="txtColorGray">Date:</span>
                                <asp:TextBox ID="txtDate" runat="server" onkeypress="return false;" CssClass="th style-eta date_style txtwdth" Text="" style="max-width: 200px;width: 100px;padding: 3px;"></asp:TextBox><br />
                                 <%-- rajeevS --%>
                                <span style="width:112px;display:inline-block;" class="txtColorGray" runat="server" id="spn_HSNCode"></span>
                                <asp:Label ID="lblHSNCode" Text="" runat="server" CssClass="th style-eta date_style txtwdth" style="max-width: 200px;width: 100px;padding: 3px;"></asp:Label> <br />                         
                                <%-- rajeevS --%>
                                <asp:DropDownList ID="ddlType" runat="server" ForeColor="gray" AutoPostBack="True" OnSelectedIndexChanged="ddlType_SelectedIndexChanged" style="width:112px;display:inline-block;">
                                    <asp:ListItem Value="DEBIT" Text="Against Debit No."></asp:ListItem>
                                    <asp:ListItem Value="BILL" Text="Against Bill No."></asp:ListItem>
                                </asp:DropDownList>
                                <asp:DropDownList ID="ddlBillNo" runat="server" CssClass="txt" onchange="ChangeBillNumber()" style="border-color: lightgray!important;max-width:250px;">
                                </asp:DropDownList>
                                <asp:HiddenField ID="hdnBillAmount" Value="0" runat="server" />
                                
                               
                            </td>
                        </tr>
                        
                    </thead>
                </table>
                <div>
                    <asp:GridView ID="grdAccessoryCreditNot" runat="server" CssClass="grdviewtable" AutoGenerateColumns="false"
                        OnRowDataBound="grdAccessoryCreditNot_RowDataBound" OnRowCommand="grdAccessoryCreditNot_RowCommand"
                        OnRowDeleting="grdAccessoryCreditNot_RowDeleting" ShowFooter="true" OnRowEditing="grdAccessoryCreditNot_RowEditing"
                        OnRowUpdating="grdAccessoryCreditNot_RowUpdating" OnRowCancelingEdit="grdAccessoryCreditNot_RowCancelingEdit">
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
                            <asp:TemplateField HeaderText="Particulars">
                                <ItemTemplate>
                                    <asp:Label ID="lblCreditParticur" runat="server" Text='<%# Eval("ParticularName") %>'></asp:Label>
                                    <asp:HiddenField ID="hdnParticularId" runat="server" Value='<%# Eval("CreditNoteParticularId") %>' />
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtCreditParticur" CssClass="txtEditParticular" runat="server" Text='<%# Eval("ParticularName") %>'></asp:TextBox>
                                    <asp:HiddenField ID="hdnParticularIdEdit" runat="server" Value='<%# Eval("CreditNoteParticularId") %>' />
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtCreditParticur_Footer" CssClass="txtEditParticular" runat="server"></asp:TextBox>
                                </FooterTemplate>
                                <ItemStyle Width="550" />
                                <FooterStyle Width="550" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Quantity">
                                <ItemTemplate>
                                    <asp:Label ID="lblCreditQty" runat="server" Text='<%# Eval("CreditQuantity") %>'></asp:Label>
                                    <asp:Label ID="lblunits" runat="server"></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtCreditQty" MaxLength="8" CssClass="txtEditWidth" onblur="javascript:return CalculateGridAmount(this, 'Edit')"
                                        onkeypress="return isNumberKey(event)" Text='<%# Eval("CreditQuantity") %>' runat="server"></asp:TextBox>
                                    <asp:HiddenField ID="hdnCreditQty" Value='<%# Eval("CreditQuantity") %>' runat="server" />
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtCreditQty_Footer" onblur="javascript:return CalculateGridAmount(this, 'Footer')"
                                        CssClass="txtEditWidth" MaxLength="8" onkeypress="return isNumberKey(event)"
                                        runat="server"></asp:TextBox>
                                </FooterTemplate>
                                <ItemStyle Width="70" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Rate">
                                <ItemTemplate>
                                    <span class="indianCurr"></span>
                                    <asp:Label ID="lblCreditRate" runat="server" Text='<%# Eval("CreditRate") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtCreditRate" MaxLength="5" CssClass="txtEditWidth" onblur="javascript:return CalculateGridAmount(this, 'Edit')"
                                        onkeypress="return isNumberKeydec(event)" runat="server" Text='<%# Eval("CreditRate") %>'></asp:TextBox>
                                    <asp:HiddenField ID="hdnCreditRate" Value='<%# Eval("CreditRate") %>' runat="server" />
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtCreditRate_Footer" CssClass="txtEditWidth" onblur="CalculateGridAmount(this, 'Footer')"
                                        MaxLength="5" onkeypress="return isNumberKeydec(event)" runat="server"></asp:TextBox>
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
                                    <asp:LinkButton ID="lkEdit" runat="server" CausesValidation="False" CommandName="Edit" OnClientClick="javascript:return HideShowGST()">
                                        <asp:image src="../../images/edit2.png" alt="Edit" title="Edit" runat="server" id="lkEditImage" />
                                    </asp:LinkButton>
                                    <asp:LinkButton ForeColor="black" Width="30px" ID="lnkDelete" runat="server" CommandName="Delete"
                                        OnClientClick="javascript:return confirmAlert(this);HideShowGST()"> 
                                        <asp:image src="../../images/del-butt.png" alt="Delete" runat="server" id="lnkDeleteImage" /> 

                              

                                     </asp:LinkButton>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:LinkButton ID="lkUpdate" runat="server" ValidationGroup="Edit" CausesValidation="true"
                                        OnClientClick="javascript:return ValidateGrid(this, 'Edit');HideShowGST()" CommandName="Update">
                                    <img src="../../images/save.png" alt="Update" title="Update" border="0" style="width:18px;" />
                                    </asp:LinkButton>
                                    <asp:LinkButton ID="lkCancel" runat="server" CausesValidation="False" CommandName="Cancel" OnClientClick="javascript:return HideShowGST()">
                                     <img src="../../images/cancel1.jpg" alt="Cancel" title="Cancel" border="0" style="width:25px;position: relative; top: 3px;"/>
                                    </asp:LinkButton>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:LinkButton runat="server" ID="Submit" OnClientClick="javascript:return ValidateGrid(this, 'Footer');HideShowGST()"
                                        CommandName="Insert">
                                  <img src="../../images/add-butt.png" />
                                    </asp:LinkButton>
                                </FooterTemplate>
                                <ItemStyle Width="100" CssClass="border_right" />
                            </asp:TemplateField>
                        </Columns>
                        <EmptyDataTemplate>
                            <table cellpadding="0" class="emptytable GSTTAbleEmp" cellspacing="0" width="100%"
                                style="max-width: 983px; border-top: 0px solid !important;">
                                <tr>
                                    <th style="width: 50px;">
                                        Sr. No.
                                    </th>
                                    <th style="width: 365px;">
                                        Particulars
                                    </th>
                                    <th style="width: 53px;">
                                        Quantity
                                    </th>
                                    <th style="width: 57px;">
                                        Rate
                                    </th>
                                    <th style="width: 78px;">
                                        Amount
                                    </th>
                                    <th style="width: 75px;">
                                        Action
                                    </th>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtCreditParticular_Empty" CssClass="txtEditParticular"
                                            Width="96%" Text=""></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtCreditQty_Empty" CssClass="txtEditWidth" MaxLength="8"
                                            onkeypress="return isNumberKey(event)" Width="90%" Text="" onblur="javascript:return CalculateGridAmount(this, 'Empty')"></asp:TextBox>
                                    </td>
                                    <td class="txtLeft" style="padding-left: 2px;">
                                        <asp:TextBox runat="server" ID="txtCreditRate_Empty" CssClass="txtEditWidth" MaxLength="5"
                                            onkeypress="return isNumberKeydec(event)" Width="69%" Text="" onblur="javascript:return CalculateGridAmount(this, 'Empty')"></asp:TextBox>
                                    </td>
                                    <td>
                                        &nbsp;
                                        <asp:Label ID="lblAmount_Empty" runat="server" Text=""></asp:Label>
                                        <asp:HiddenField ID="hdnAmount_Empty" Value="0" runat="server" />
                                    </td>
                                    <td>
                                        <asp:LinkButton runat="server" ID="Submit" OnClientClick="javascript:return ValidateGrid(this, 'Empty');HideShowGST()"
                                            CommandName="AddEmpty">
                            <img src="../../images/add-butt.png" />
                                        </asp:LinkButton>
                                    </td>
                                </tr>
                            </table>
                        </EmptyDataTemplate>
                    </asp:GridView>
                </div>
                <div>
                    <table cellpadding="0" class="emptytable GSTTAble GST_TAble" cellspacing="0" style="max-width: 983px;
                        border-top: 0px solid !important; border-color: #d0cece">
                        <tr class="clsIGST">
                            <td style="width: 486px; border-right-color: #999;" class="PrientClass ">
                                &nbsp;
                            </td>
                            <td style="border-bottom: 1px solid #9999; width: 64px" class="PrientClass4 txtColorGray">
                                IGST
                            </td>
                            <td style="border-bottom: 1px solid #9999; width: 66px;" class="PrientClass3">
                                <asp:TextBox runat="server" ID="txtIGST" MaxLength="5" onkeypress="return isNumberKeydec(event)"
                                    Width="50%" Text="" onblur="CalculateGSTAmount(this, 1);" Enabled="false"></asp:TextBox>
                                <span>%</span>
                            </td>
                            <td style="border-bottom: 1px solid #9999; width: 92px;" class="PrientClass2">
                                <asp:Label ID="lblIgstCurrency" runat="server"></asp:Label>
                                <asp:Label ID="lblIGSTAmount" runat="server" Text=""></asp:Label>
                                <asp:HiddenField ID="hdnIGSTAmount" Value="0" runat="server" />
                            </td>
                            <td style="width: 90px; border-bottom: 1px solid #9999; border-right: 1px solid #999"
                                class="PrientClass1">
                                &nbsp;
                            </td>
                        </tr>
                        <tr class="clsCGST_SGST">
                            <td style="border-right: 1px solid #999;width:61%;">
                                &nbsp
                            </td>
                            <td style="border-bottom: 1px solid #9999;width:60px;" class="txtColorGray">
                                CGST
                            </td>
                            <td style="border-bottom: 1px solid #9999;width:68px;">
                                <asp:TextBox runat="server" ID="txtCGST" MaxLength="5" onkeypress="return isNumberKeydec(event)"
                                    Width="50%" Text="" onblur="CalculateGSTAmount(this, 2);" Enabled="false"></asp:TextBox>
                                <span>%</span>
                            </td>
                            <td style="border-bottom: 1px solid #9999;width:90px;">
                                <asp:Label ID="lblCgstCurrency" runat="server"></asp:Label>
                                <asp:Label ID="lblCGSTAmount" runat="server" Text=""></asp:Label>
                                <asp:HiddenField ID="hdnCGSTAmount" Value="0" runat="server" />
                            </td>
                            <td style="border-bottom: 1px solid #9999; border-right: 1px solid #999;width:90px;">
                                &nbsp;
                            </td>
                        </tr>
                        <tr class="clsCGST_SGST">
                            <td style="border-right: 1px solid #999; width: 60.6%;">
                                &nbsp;
                            </td>
                            <td style="border-bottom: 1px solid #9999;width:60px;" class="txtColorGray">
                                SGST
                            </td>
                            <td style="border-bottom: 1px solid #9999;width:66px;">
                                <asp:TextBox runat="server" ID="txtSGST" MaxLength="5" onkeypress="return isNumberKeydec(event)"
                                    Width="50%" Text="" onblur="CalculateGSTAmount(this, 3);" Enabled="false"></asp:TextBox>
                                <span>%</span>
                            </td>
                            <td style="border-bottom: 1px solid #9999;width:85px;">
                                <asp:Label ID="lblSgstCurrency" runat="server"></asp:Label>
                                <asp:Label ID="lblSGSTAmount" runat="server" Text=""></asp:Label>
                                <asp:HiddenField ID="hdnSGSTAmount" Value="0" runat="server" />
                            </td>
                            <td style="border-bottom: 1px solid #9999; border-right: 1px solid #999;width:82px;">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td style="border-right: 1px solid #999;width:445px;">
                                &nbsp;
                            </td>
                            <td style="border-bottom: 1px solid #999;" colspan="2" class="txtColorGray">
                                Total
                            </td>
                            <%--   <td style="border-bottom: 1px solid #999;">                                                                
                                </td>--%>
                            <td style="border-bottom: 1px solid #999;">
                                <asp:Label ID="lblGranTotalCurrency" runat="server"></asp:Label>
                                <asp:Label ID="lblGrandTotalAmount" runat="server" Text=""></asp:Label>
                                <asp:HiddenField ID="hdnTotalAmount" runat="server" />
                                <asp:HiddenField ID="hdnGrandTotalAmount" runat="server" />
                            </td>
                            <td style="border-bottom: 1px solid #999; border-right: 1px solid #999">
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </div>
                <div style="max-width: 100%; height: 15px;">
                </div>
                <div class="bottomtable">
                <%--new table added start--%>
                <table style="max-width: 100%; width: 100%; border: 1px solid #999999; border-collapse: collapse;">
                        <tbody>
                            <tr>                               
                                <td style="width: 100%; border-bottom: 1px solid #999999; font-size: 11px">
                                <span style="color: #000000; text-transform:capitalize; font-weight:bold;margin-left:3px;">Rupees</span>
                                    <asp:Label ID="lblRupees" Font-Bold="true" style="color: #000000; text-transform:capitalize;margin-left: 4px;" runat="server"></asp:Label>
                                    <asp:HiddenField ID="hdnRupees" runat="server" />
                                </td>
                            </tr>
                        </tbody>
                    </table>
                <%--new table added end--%>

                    <table style="max-width: 100%; width: 100%; border: none" cellspacing="0" cellpadding="0">
                        <thead>
                            <tr>
                                <td colspan="4" style="width: 70%">
                                    &nbsp;
                                </td>
                                <td style="text-align: center; padding-right: 8px; padding-top: 15px; color: #000;
                                    font-size: 12px;">
                                    <span style="font-weight: bold">Boutique International Pvt. Ltd.</span>
                                    <div id="divChkAuthorized" runat="server">
                                        <asp:HiddenField ID="hdnIsChecked" Value="0" runat="server" />
                                        <asp:CheckBox ID="chkAuthorised" runat="server" onclick="DisplaySendMail()" />
                                        (Authorized Signature)
                                    </div>
                                    <div id="divSigAuthorized" runat="server" visible="false">
                                        <asp:Image ID="imgAuthorized" runat="server" Height="40px" Width="110px" />
                                        <asp:HiddenField runat="server" ID ="IsCreditNoteSigned" Value="0"/>
                                        <br />
                                        <asp:Label ID="lblAuthorizedName" runat="server" Style="line-height: 20px;"></asp:Label>
                                        <br />
                                        <asp:Label ID="lblAuthorizedOnDate" runat="server"></asp:Label>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="5" style="text-align: center; padding-top: 5px;">
                                    <div class="form_buttom" style="float: left;">
                                        <asp:Button ID="btnSubmit" CssClass="btnSubmit printHideButton" ClientIDMode="Static" 
                                            OnClientClick="this.disabled = true; Creditnote_Validation();" 
                                            UseSubmitBehavior="False"
                                            runat="server" Text="Save" OnClick="btnSubmit_Click" />
                                    </div>
                                    <div class="btnClose printHideButton" id="Closesbox" onclick="javascript:self.parent.Shadowbox.close();">
                                        Close</div>
                                    <div class="btnPrint printHideButton" onclick="window.print();return false">
                                        Print</div>
                                    <div id="dvSendMail" style="width: 400px; font-weight: bold; top: 5px; display: none;"
                                        runat="server">
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
